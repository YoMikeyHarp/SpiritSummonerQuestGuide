// Frida script v3: Spirit Summoner EP/SP refill via vtable memory scan (no gc_walk_heap,
// no persistent hooks). mono_gc_walk_heap proved unreliable (aborted), so instead we:
//
// 1. Get the MonoVTable* for PlayerStateService and Player via mono_class_vtable.
// 2. Memory.scanSync the process's writable ranges for the byte pattern of the
//    PlayerStateService vtable pointer - every managed object's first 8 bytes
//    (on x86_64) are its vtable pointer, so a match address is a candidate
//    PlayerStateService instance.
// 3. For each candidate, read its `_currentSession` field and verify the
//    resulting object's vtable matches Player's vtable.
// 4. Once verified, read/write EP/MaxEP/SP/MaxSP backing fields directly.

'use strict';

let api = {};
let attachedThread = false;

const EXPORTS = {
    mono_get_root_domain: ['pointer', []],
    mono_thread_attach: ['pointer', ['pointer']],
    mono_assembly_foreach: ['void', ['pointer', 'pointer']],
    mono_assembly_get_image: ['pointer', ['pointer']],
    mono_class_from_name: ['pointer', ['pointer', 'pointer', 'pointer']],
    mono_class_vtable: ['pointer', ['pointer', 'pointer']],
    mono_class_get_field_from_name: ['pointer', ['pointer', 'pointer']],
    mono_field_get_value: ['void', ['pointer', 'pointer', 'pointer']],
    mono_field_get_value_object: ['pointer', ['pointer', 'pointer', 'pointer']],
    mono_field_set_value: ['void', ['pointer', 'pointer', 'pointer']],
};

function resolveMono() {
    const mono = Process.findModuleByName('libmonosgen-2.0.so');
    if (!mono) return false;
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

function ptrPattern(p) {
    const buf = Memory.alloc(8);
    buf.writePointer(p);
    const bytes = buf.readByteArray(8);
    return Array.from(new Uint8Array(bytes)).map(b => b.toString(16).padStart(2, '0')).join(' ');
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

function findPlayerInstance() {
    if (!resolveMono()) return { error: 'libmonosgen-2.0.so not loaded yet' };
    ensureAttached();

    const domain = api.mono_get_root_domain();

    const stateClass = findClass('SpiritSummoner.Application.State', 'PlayerStateService');
    if (!stateClass) return { error: 'PlayerStateService class not found' };
    const playerClass = findClass('SpiritSummoner.Domain.Entities.Players', 'Player');
    if (!playerClass) return { error: 'Player class not found' };

    const stateVtable = api.mono_class_vtable(domain, stateClass);
    const playerVtable = api.mono_class_vtable(domain, playerClass);
    if (stateVtable.isNull() || playerVtable.isNull()) return { error: 'failed to get vtable' };

    const sessionField = api.mono_class_get_field_from_name(stateClass, Memory.allocUtf8String('_currentSession'));
    if (sessionField.isNull()) return { error: '_currentSession field not found' };

    const pattern = ptrPattern(stateVtable);
    const ranges = Process.enumerateRanges('rw-');

    let player = null;
    let scanned = 0;
    for (const range of ranges) {
        // Skip absurdly large ranges to keep this fast / avoid scanning device memory-mapped files.
        if (range.size > 256 * 1024 * 1024) continue;
        let matches;
        try {
            matches = Memory.scanSync(range.base, range.size, pattern);
        } catch (e) {
            continue;
        }
        scanned += matches.length;
        for (const m of matches) {
            const candidate = m.address;
            let playerObj;
            try {
                playerObj = api.mono_field_get_value_object(domain, sessionField, candidate);
            } catch (e) {
                continue;
            }
            if (playerObj.isNull()) continue;
            let vt;
            try {
                vt = playerObj.readPointer();
            } catch (e) {
                continue;
            }
            if (vt.equals(playerVtable)) {
                player = playerObj;
                break;
            }
        }
        if (player) break;
    }

    if (!player) return { error: 'no PlayerStateService instance found (scanned ' + scanned + ' vtable matches)' };
    return { player, playerClass };
}

rpc.exports = {
    status() {
        const r = findPlayerInstance();
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
        const r = findPlayerInstance();
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
