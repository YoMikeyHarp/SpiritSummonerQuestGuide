// Frida script v2: Spirit Summoner EP/SP refill via one-shot heap walk + field access.
// No persistent Interceptor hooks - everything happens inside rpc export calls,
// each of which attaches the thread, does its work, and returns immediately.
//
// Strategy:
// 1. Find SpiritSummoner.Application.State.PlayerStateService class and
//    SpiritSummoner.Domain.Entities.Players.Player class.
// 2. mono_gc_walk_heap() once to find the live PlayerStateService instance
//    (there should be exactly one - it's a DI singleton).
// 3. Read its private `_currentSession` field (a Player reference).
// 4. Read/write the Player's `<EP>k__BackingField`, `<MaxEP>k__BackingField`,
//    `<SP>k__BackingField`, `<MaxSP>k__BackingField` directly via
//    mono_field_get_value / mono_field_set_value.

'use strict';

let api = {};
let monoModule = null;
let attachedThread = false;

const EXPORTS = {
    mono_get_root_domain: ['pointer', []],
    mono_thread_attach: ['pointer', ['pointer']],
    mono_assembly_foreach: ['void', ['pointer', 'pointer']],
    mono_assembly_get_image: ['pointer', ['pointer']],
    mono_class_from_name: ['pointer', ['pointer', 'pointer', 'pointer']],
    mono_object_get_class: ['pointer', ['pointer']],
    mono_class_get_field_from_name: ['pointer', ['pointer', 'pointer']],
    mono_field_get_value: ['void', ['pointer', 'pointer', 'pointer']],
    mono_field_get_value_object: ['pointer', ['pointer', 'pointer', 'pointer']],
    mono_field_set_value: ['void', ['pointer', 'pointer', 'pointer']],
    mono_gc_walk_heap: ['int', ['int', 'pointer', 'pointer']],
};

function resolveMono() {
    const mono = Process.findModuleByName('libmonosgen-2.0.so');
    if (!mono) return false;
    monoModule = mono;
    for (const [name, sig] of Object.entries(EXPORTS)) {
        const addr = mono.findExportByName(name);
        if (!addr) {
            console.log('[!] missing export ' + name);
            return false;
        }
        api[name] = new NativeFunction(addr, sig[0], sig[1]);
    }
    return true;
}

function ensureAttached() {
    if (!attachedThread) {
        const domain = api.mono_get_root_domain();
        api.mono_thread_attach(domain);
        attachedThread = true;
    }
}

function findClass(ns, name) {
    const nsBuf = Memory.allocUtf8String(ns);
    const nameBuf = Memory.allocUtf8String(name);
    let found = null;
    const cb = new NativeCallback((asm, userData) => {
        if (found) return;
        const image = api.mono_assembly_get_image(asm);
        if (image.isNull()) return;
        const klass = api.mono_class_from_name(image, nsBuf, nameBuf);
        if (!klass.isNull()) found = klass;
    }, 'void', ['pointer', 'pointer']);
    api.mono_assembly_foreach(cb, ptr(0));
    return found;
}

// One-shot heap walk to find the single live instance of `targetClass`.
function findInstanceOfClass(targetClass) {
    let found = null;
    const cb = new NativeCallback((obj, klass, size, num, refs, offsets, data) => {
        if (found) return 0;
        if (klass.equals(targetClass)) {
            found = obj;
        }
        return 0;
    }, 'int', ['pointer', 'pointer', 'uint64', 'uint64', 'pointer', 'pointer', 'pointer']);
    const rc = api.mono_gc_walk_heap(0, cb, ptr(0));
    return { found, rc };
}

function getInt(obj, klass, fieldName) {
    const field = api.mono_class_get_field_from_name(klass, Memory.allocUtf8String(fieldName));
    if (field.isNull()) return null;
    const buf = Memory.alloc(4);
    api.mono_field_get_value(obj, field, buf);
    return buf.readInt();
}

function setInt(obj, klass, fieldName, value) {
    const field = api.mono_class_get_field_from_name(klass, Memory.allocUtf8String(fieldName));
    if (field.isNull()) return false;
    const buf = Memory.alloc(4);
    buf.writeInt(value);
    api.mono_field_set_value(obj, field, buf);
    return true;
}

function getPlayerInstance(state) {
    if (!resolveMono()) return { error: 'libmonosgen-2.0.so not loaded yet' };
    ensureAttached();

    const stateClass = findClass('SpiritSummoner.Application.State', 'PlayerStateService');
    if (!stateClass) return { error: 'PlayerStateService class not found' };

    const playerClass = findClass('SpiritSummoner.Domain.Entities.Players', 'Player');
    if (!playerClass) return { error: 'Player class not found' };

    const { found: stateInstance, rc } = findInstanceOfClass(stateClass);
    if (!stateInstance) return { error: 'PlayerStateService instance not found on heap (gc_walk_heap rc=' + rc + ')' };

    const sessionField = api.mono_class_get_field_from_name(stateClass, Memory.allocUtf8String('_currentSession'));
    if (sessionField.isNull()) return { error: '_currentSession field not found' };

    const domain = api.mono_get_root_domain();
    const player = api.mono_field_get_value_object(domain, sessionField, stateInstance);
    if (player.isNull()) return { error: '_currentSession is null (no active session)' };

    return { player, playerClass };
}

rpc.exports = {
    status() {
        const r = getPlayerInstance();
        if (r.error) return r;
        const { player, playerClass } = r;
        return {
            ep: getInt(player, playerClass, '<EP>k__BackingField'),
            maxEp: getInt(player, playerClass, '<MaxEP>k__BackingField'),
            sp: getInt(player, playerClass, '<SP>k__BackingField'),
            maxSp: getInt(player, playerClass, '<MaxSP>k__BackingField'),
        };
    },

    refill() {
        const r = getPlayerInstance();
        if (r.error) return r;
        const { player, playerClass } = r;
        const maxEp = getInt(player, playerClass, '<MaxEP>k__BackingField');
        const maxSp = getInt(player, playerClass, '<MaxSP>k__BackingField');
        setInt(player, playerClass, '<EP>k__BackingField', maxEp);
        setInt(player, playerClass, '<SP>k__BackingField', maxSp);
        return {
            ep: getInt(player, playerClass, '<EP>k__BackingField'),
            sp: getInt(player, playerClass, '<SP>k__BackingField'),
            maxEp, maxSp,
            message: 'EP/SP set to max',
        };
    },
};
