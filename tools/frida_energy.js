// Frida script: Spirit Summoner energy (EP/SP) refill helper
//
// Usage:
//   python -m frida -U -f com.companyname.spiritsummonermauiapp -l frida_energy.js --no-pause
//   (or attach to the already-running process by PID/name with -U -n SpiritSummoner)
//
// Once loaded, from the Frida REPL you can run:
//   rpc.exports.refill()        -> sets EP and SP to their current max values
//   rpc.exports.status()        -> prints current EP/MaxEP/SP/MaxSP
//   rpc.exports.autorefill(true)  -> starts a 5s auto-refill loop
//   rpc.exports.autorefill(false) -> stops the auto-refill loop
//
// How it works:
// 1. Waits for libmonosgen-2.0.so to load, resolves the Mono embedding API.
// 2. Finds the SpiritSummoner.Domain.Entities.Players.Player class in the
//    game's managed assembly.
// 3. Hooks Player.SetEP(int) - this is called every minute by the EP regen
//    use case AND whenever EP is spent, so it's a reliable way to capture a
//    pointer to the LIVE player instance ("this") without guessing offsets.
// 4. Once we have the live instance, we use mono_runtime_invoke to call
//    get_MaxEP / get_MaxSP / SetEP / SetSP on demand.

'use strict';

let monoModule = null;
let api = {};
let playerInstance = null;
let playerClass = null;
let methods = {};
let attachedThread = false;
let autoRefillTimer = null;
let loggedCapture = false;

function resolveMono() {
    const mono = Process.findModuleByName('libmonosgen-2.0.so');
    if (!mono) return false;
    monoModule = mono;

    const names = [
        'mono_get_root_domain',
        'mono_thread_attach',
        'mono_thread_detach',
        'mono_assembly_foreach',
        'mono_assembly_get_image',
        'mono_image_get_name',
        'mono_class_from_name',
        'mono_class_get_method_from_name',
        'mono_compile_method',
        'mono_runtime_invoke',
        'mono_object_unbox',
        'mono_string_to_utf8',
    ];

    for (const n of names) {
        const addr = mono.findExportByName(n);
        if (!addr) {
            console.log('[!] missing export ' + n);
            return false;
        }
        api[n] = new NativeFunction(addr, returnTypeFor(n), argTypesFor(n));
    }
    return true;
}

function returnTypeFor(n) {
    switch (n) {
        case 'mono_image_get_name': return 'pointer';
        case 'mono_string_to_utf8': return 'pointer';
        default: return 'pointer';
    }
}

function argTypesFor(n) {
    switch (n) {
        case 'mono_get_root_domain': return [];
        case 'mono_thread_attach': return ['pointer'];
        case 'mono_thread_detach': return ['pointer'];
        case 'mono_assembly_foreach': return ['pointer', 'pointer'];
        case 'mono_assembly_get_image': return ['pointer'];
        case 'mono_image_get_name': return ['pointer'];
        case 'mono_class_from_name': return ['pointer', 'pointer', 'pointer'];
        case 'mono_class_get_method_from_name': return ['pointer', 'pointer', 'int'];
        case 'mono_compile_method': return ['pointer'];
        case 'mono_runtime_invoke': return ['pointer', 'pointer', 'pointer', 'pointer'];
        case 'mono_object_unbox': return ['pointer'];
        case 'mono_string_to_utf8': return ['pointer'];
        default: return [];
    }
}

function ensureAttached() {
    if (!attachedThread) {
        const domain = api.mono_get_root_domain();
        api.mono_thread_attach(domain);
        attachedThread = true;
    }
}

// Find a class by namespace+name by scanning every loaded assembly's image.
function findClass(ns, name) {
    ensureAttached();

    const nsBuf = Memory.allocUtf8String(ns);
    const nameBuf = Memory.allocUtf8String(name);

    let found = null;
    const cb = new NativeCallback((asm, userData) => {
        if (found) return;
        const image = api.mono_assembly_get_image(asm);
        if (image.isNull()) return;
        const klass = api.mono_class_from_name(image, nsBuf, nameBuf);
        if (!klass.isNull()) {
            found = klass;
        }
    }, 'void', ['pointer', 'pointer']);

    api.mono_assembly_foreach(cb, ptr(0));
    return found;
}

function findPlayerClass() {
    return findClass('SpiritSummoner.Domain.Entities.Players', 'Player');
}

function getMethod(klass, name, paramCount) {
    const nameBuf = Memory.allocUtf8String(name);
    const m = api.mono_class_get_method_from_name(klass, nameBuf, paramCount);
    if (m.isNull()) {
        console.log('[!] method not found: ' + name);
        return null;
    }
    return m;
}

// Calls an instance method that returns Int32, returns a JS number.
function invokeGetInt(method, instance) {
    const excPtr = Memory.alloc(Process.pointerSize);
    excPtr.writePointer(ptr(0));
    const result = api.mono_runtime_invoke(method, instance, ptr(0), excPtr);
    if (!excPtr.readPointer().isNull()) {
        console.log('[!] exception during invoke');
        return null;
    }
    const unboxed = api.mono_object_unbox(result);
    return unboxed.readInt();
}

// Calls an instance method taking a single Int32 argument (e.g. SetEP(int)).
function invokeSetInt(method, instance, value) {
    const argBuf = Memory.alloc(4);
    argBuf.writeInt(value);
    const argsArr = Memory.alloc(Process.pointerSize);
    argsArr.writePointer(argBuf);

    const excPtr = Memory.alloc(Process.pointerSize);
    excPtr.writePointer(ptr(0));
    api.mono_runtime_invoke(method, instance, argsArr, excPtr);
    if (!excPtr.readPointer().isNull()) {
        console.log('[!] exception during invoke');
        return false;
    }
    return true;
}

function setupHooks() {
    playerClass = findPlayerClass();
    if (!playerClass) {
        console.log('[!] Player class not found yet, will retry');
        return false;
    }
    console.log('[+] Found Player class: ' + playerClass);

    const setEP = getMethod(playerClass, 'SetEP', 1);
    methods.getMaxEP = getMethod(playerClass, 'get_MaxEP', 0);
    methods.getEP = getMethod(playerClass, 'get_EP', 0);
    methods.getMaxSP = getMethod(playerClass, 'get_MaxSP', 0);
    methods.getSP = getMethod(playerClass, 'get_SP', 0);
    methods.setEP = setEP;
    methods.setSP = getMethod(playerClass, 'SetSP', 1);

    if (!setEP) return false;

    // Hook several methods that are likely to run with `this` = the live
    // player instance, so whichever fires first captures the pointer.
    const hookCandidates = [setEP, methods.getEP, methods.getMaxEP, methods.getSP, methods.getMaxSP, methods.setSP]
        .filter(m => m && !m.isNull());

    let hooked = 0;
    for (const m of hookCandidates) {
        const addr = api.mono_compile_method(m);
        if (addr.isNull()) continue;
        Interceptor.attach(addr, {
            onEnter(args) {
                playerInstance = args[0];
                if (!loggedCapture) {
                    console.log('[+] Captured live Player instance: ' + playerInstance);
                    loggedCapture = true;
                }
            }
        });
        hooked++;
    }

    // Also hook PlayerStateService.GetCurrentPlayer() - this returns the
    // live Player instance directly and is called on basically every
    // screen refresh, so it's a much faster way to capture the pointer.
    const stateClass = findClass('SpiritSummoner.Application.State', 'PlayerStateService');
    if (stateClass) {
        const getCurrentPlayer = getMethod(stateClass, 'GetCurrentPlayer', 0);
        if (getCurrentPlayer) {
            const addr = api.mono_compile_method(getCurrentPlayer);
            if (!addr.isNull()) {
                Interceptor.attach(addr, {
                    onLeave(retval) {
                        if (!retval.isNull()) {
                            playerInstance = retval;
                            if (!loggedCapture) {
                                console.log('[+] Captured live Player instance via GetCurrentPlayer: ' + playerInstance);
                                loggedCapture = true;
                            }
                        }
                    }
                });
                hooked++;
                console.log('[+] Hooked PlayerStateService.GetCurrentPlayer');
            }
        }
    } else {
        console.log('[!] PlayerStateService class not found');
    }

    console.log('[+] Hooked ' + hooked + ' total method(s) - waiting for one to fire');
    console.log('[+] (open/refresh any screen in-game, or wait for the ~1 min regen tick)');
    return true;
}

// Retry setup until the assembly is loaded (app may still be starting up).
function init() {
    const tryInterval = setInterval(() => {
        if (!monoModule && !resolveMono()) {
            return;
        }
        if (setupHooks()) {
            clearInterval(tryInterval);
        }
    }, 1000);
}

init();

rpc.exports = {
    status() {
        if (!playerInstance) {
            return { error: 'No live Player instance captured yet. Wait ~1 min for EP regen tick, or open the player/quest screen in-game.' };
        }
        ensureAttached();
        return {
            ep: methods.getEP ? invokeGetInt(methods.getEP, playerInstance) : null,
            maxEp: methods.getMaxEP ? invokeGetInt(methods.getMaxEP, playerInstance) : null,
            sp: methods.getSP ? invokeGetInt(methods.getSP, playerInstance) : null,
            maxSp: methods.getMaxSP ? invokeGetInt(methods.getMaxSP, playerInstance) : null,
        };
    },

    refill() {
        if (!playerInstance) {
            return { error: 'No live Player instance captured yet.' };
        }
        ensureAttached();
        const maxEp = invokeGetInt(methods.getMaxEP, playerInstance);
        const maxSp = invokeGetInt(methods.getMaxSP, playerInstance);
        invokeSetInt(methods.setEP, playerInstance, maxEp);
        if (methods.setSP) invokeSetInt(methods.setSP, playerInstance, maxSp);
        return { ep: maxEp, sp: maxSp, message: 'EP/SP set to max' };
    },

    autorefill(enable) {
        if (enable) {
            if (autoRefillTimer) return { message: 'already running' };
            autoRefillTimer = setInterval(() => {
                if (!playerInstance) return;
                ensureAttached();
                const maxEp = invokeGetInt(methods.getMaxEP, playerInstance);
                const maxSp = invokeGetInt(methods.getMaxSP, playerInstance);
                invokeSetInt(methods.setEP, playerInstance, maxEp);
                if (methods.setSP) invokeSetInt(methods.setSP, playerInstance, maxSp);
            }, 5000);
            return { message: 'auto-refill started (every 5s)' };
        } else {
            if (autoRefillTimer) {
                clearInterval(autoRefillTimer);
                autoRefillTimer = null;
            }
            return { message: 'auto-refill stopped' };
        }
    }
};
