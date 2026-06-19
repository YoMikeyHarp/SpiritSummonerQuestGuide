// Frida script: look up a Spirit template by name in StaticDataCacheService.Spirits
// and dump its type, base stats, evolution info, and learnable moves.
// Same one-shot vtable-scan pattern as frida_energy3.js / frida_grant_orbs.js.

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
    mono_class_get_method_from_name: ['pointer', ['pointer', 'pointer', 'int']],
    mono_field_get_value: ['void', ['pointer', 'pointer', 'pointer']],
    mono_field_get_value_object: ['pointer', ['pointer', 'pointer', 'pointer']],
    mono_field_set_value: ['void', ['pointer', 'pointer', 'pointer']],
    mono_runtime_invoke: ['pointer', ['pointer', 'pointer', 'pointer', 'pointer']],
    mono_object_get_class: ['pointer', ['pointer']],
    mono_object_unbox: ['pointer', ['pointer']],
    mono_class_is_valuetype: ['int', ['pointer']],
    mono_string_new: ['pointer', ['pointer', 'pointer']],
    mono_string_to_utf8: ['pointer', ['pointer']],
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

function getObjField(obj, klass, fieldName) {
    const domain = api.mono_get_root_domain();
    const field = api.mono_class_get_field_from_name(klass, Memory.allocUtf8String(fieldName));
    if (field.isNull()) return null;
    const result = api.mono_field_get_value_object(domain, field, obj);
    return result.isNull() ? null : result;
}

function monoStr(jsStrVal) {
    const domain = api.mono_get_root_domain();
    return api.mono_string_new(domain, Memory.allocUtf8String(jsStrVal));
}

function jsStr(monoString) {
    if (!monoString || monoString.isNull()) return null;
    const utf8 = api.mono_string_to_utf8(monoString);
    return utf8.readCString();
}

function invoke(obj, methodName, argCount, params) {
    const klass = api.mono_object_get_class(obj);
    const method = api.mono_class_get_method_from_name(klass, Memory.allocUtf8String(methodName), argCount);
    if (method.isNull()) throw new Error('method not found: ' + methodName + '/' + argCount);
    let paramsPtr = ptr(0);
    if (argCount > 0) {
        paramsPtr = Memory.alloc(8 * argCount);
        for (let i = 0; i < argCount; i++) {
            paramsPtr.add(i * 8).writePointer(params[i]);
        }
    }
    let target = obj;
    if (api.mono_class_is_valuetype(klass)) {
        target = api.mono_object_unbox(obj);
    }
    const excPtr = Memory.alloc(8);
    excPtr.writePointer(ptr(0));
    const result = api.mono_runtime_invoke(method, target, paramsPtr, excPtr);
    const exc = excPtr.readPointer();
    if (!exc.isNull()) throw new Error('exception calling ' + methodName);
    return result;
}

function unboxBool(boxed) {
    const p = api.mono_object_unbox(boxed);
    return p.readU8() !== 0;
}

function unboxInt(boxed) {
    const p = api.mono_object_unbox(boxed);
    return p.readInt();
}

function forEachDictValue(dictObj, fn) {
    const values = invoke(dictObj, 'get_Values', 0, []);
    const enumerator = invoke(values, 'GetEnumerator', 0, []);
    while (unboxBool(invoke(enumerator, 'MoveNext', 0, []))) {
        const current = invoke(enumerator, 'get_Current', 0, []);
        fn(current);
    }
}

function listToArray(listObj) {
    if (!listObj) return [];
    const count = unboxInt(invoke(listObj, 'get_Count', 0, []));
    const out = [];
    for (let i = 0; i < count; i++) {
        const idxBuf = Memory.alloc(4);
        idxBuf.writeInt(i);
        out.push(invoke(listObj, 'get_Item', 1, [idxBuf]));
    }
    return out;
}

const TYPE_NAMES = ['None', 'Neutral', 'Dark', 'Fire', 'Grass', 'Ground', 'Metal', 'Poison', 'Water', 'Wind', 'Electric', 'Light', 'Melee'];
const MOVETYPE_NAMES = ['Physical', 'Special', 'Status'];

function findStateAndPlayer() {
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
    let state = null;
    let scanned = 0;
    for (const range of ranges) {
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
                state = candidate;
                break;
            }
        }
        if (player) break;
    }

    if (!player) return { error: 'no PlayerStateService instance found (scanned ' + scanned + ' vtable matches)' };
    return { player, playerClass, state, stateClass };
}

function dumpSpirit(template) {
    const tClass = api.mono_object_get_class(template);
    const id = jsStr(getObjField(template, tClass, '<ID>k__BackingField'));
    const name = jsStr(getObjField(template, tClass, '<Name>k__BackingField'));
    const type1 = TYPE_NAMES[getInt(template, tClass, '<Type1>k__BackingField')] || 'None';
    const type2 = TYPE_NAMES[getInt(template, tClass, '<Type2>k__BackingField')] || 'None';
    const evolution = getInt(template, tClass, '<Evolution>k__BackingField');
    const preEvolution = getInt(template, tClass, '<PreEvolution>k__BackingField');

    let baseStats = null;
    const bs = getObjField(template, tClass, '<BaseStats>k__BackingField');
    if (bs) {
        const bsClass = api.mono_object_get_class(bs);
        baseStats = {
            level: getInt(bs, bsClass, '<Level>k__BackingField'),
            hp: getInt(bs, bsClass, '<HP>k__BackingField'),
            atk: getInt(bs, bsClass, '<ATK>k__BackingField'),
            def: getInt(bs, bsClass, '<DEF>k__BackingField'),
            satk: getInt(bs, bsClass, '<SATK>k__BackingField'),
            sdef: getInt(bs, bsClass, '<SDEF>k__BackingField'),
            spd: getInt(bs, bsClass, '<SPD>k__BackingField'),
            int: getInt(bs, bsClass, '<INT>k__BackingField'),
        };
    }

    const moves = [];
    const movesList = getObjField(template, tClass, '<LearnableMoves>k__BackingField');
    for (const moveObj of listToArray(movesList)) {
        const mClass = api.mono_object_get_class(moveObj);
        moves.push({
            name: jsStr(getObjField(moveObj, mClass, '<Name>k__BackingField')),
            type: TYPE_NAMES[getInt(moveObj, mClass, '<Type1>k__BackingField') ?? getInt(moveObj, mClass, '<Type>k__BackingField')] || 'None',
            power: getInt(moveObj, mClass, '<Power>k__BackingField'),
            moveType: MOVETYPE_NAMES[getInt(moveObj, mClass, '<MoveType>k__BackingField')] || 'Unknown',
        });
    }

    return { id, name, type1, type2, evolution, preEvolution, baseStats, moves };
}

rpc.exports = {
    lookup(name) {
        const r = findStateAndPlayer();
        if (r.error) return r;
        const { state, stateClass } = r;

        const spiritRepo = getObjField(state, stateClass, '_spiritRepository');
        if (!spiritRepo) return { error: '_spiritRepository not found' };
        const cache = getObjField(spiritRepo, api.mono_object_get_class(spiritRepo), '_staticDataCache');
        if (!cache) return { error: '_staticDataCache not found' };
        const spiritsDict = getObjField(cache, api.mono_object_get_class(cache), '<Spirits>k__BackingField');
        if (!spiritsDict) return { error: 'Spirits dictionary not found' };

        const matches = [];
        const target = name.toLowerCase();
        forEachDictValue(spiritsDict, (spiritObj) => {
            const sClass = api.mono_object_get_class(spiritObj);
            const sName = jsStr(getObjField(spiritObj, sClass, '<Name>k__BackingField'));
            if (sName && sName.toLowerCase().includes(target)) {
                matches.push(dumpSpirit(spiritObj));
            }
        });

        return { matches };
    },
};
