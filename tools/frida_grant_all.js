'use strict';

let api = {};
let attachedThread = false;
let monoObjectNew = null;

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
    mono_object_new: ['pointer', ['pointer', 'pointer']],
};

function resolveMono() {
    const mono = Process.findModuleByName('libmonosgen-2.0.so');
    if (!mono) return false;
    for (const [name, sig] of Object.entries(EXPORTS)) {
        const addr = mono.findExportByName(name);
        if (!addr) { console.log('[!] missing: ' + name); return false; }
        api[name] = new NativeFunction(addr, sig[0], sig[1]);
    }
    return true;
}

function ensureAttached() {
    if (!attachedThread) {
        api.mono_thread_attach(api.mono_get_root_domain());
        attachedThread = true;
    }
}

function findClass(ns, name) {
    const nsBuf = Memory.allocUtf8String(ns);
    const nameBuf = Memory.allocUtf8String(name);
    let found = null;
    const cb = new NativeCallback((asm) => {
        if (found) return;
        const img = api.mono_assembly_get_image(asm);
        if (!img.isNull()) {
            const k = api.mono_class_from_name(img, nsBuf, nameBuf);
            if (!k.isNull()) found = k;
        }
    }, 'void', ['pointer', 'pointer']);
    api.mono_assembly_foreach(cb, ptr(0));
    return found;
}

function ptrPattern(p) {
    const buf = Memory.alloc(8); buf.writePointer(p);
    return Array.from(new Uint8Array(buf.readByteArray(8))).map(b => b.toString(16).padStart(2,'0')).join(' ');
}

function getInt(obj, klass, fieldName) {
    const f = api.mono_class_get_field_from_name(klass, Memory.allocUtf8String(fieldName));
    if (f.isNull()) return 0;
    const buf = Memory.alloc(4); api.mono_field_get_value(obj, f, buf);
    return buf.readInt();
}

function getObjField(obj, klass, fieldName) {
    const domain = api.mono_get_root_domain();
    const f = api.mono_class_get_field_from_name(klass, Memory.allocUtf8String(fieldName));
    if (f.isNull()) return null;
    const r = api.mono_field_get_value_object(domain, f, obj);
    return r.isNull() ? null : r;
}

function monoStr(s) {
    return api.mono_string_new(api.mono_get_root_domain(), Memory.allocUtf8String(s));
}

function jsStr(ms) {
    if (!ms || ms.isNull()) return null;
    return api.mono_string_to_utf8(ms).readCString();
}

function intArg(v) { const b = Memory.alloc(4); b.writeInt(v); return b; }

function invoke(obj, methodName, argCount, params) {
    const klass = api.mono_object_get_class(obj);
    const method = api.mono_class_get_method_from_name(klass, Memory.allocUtf8String(methodName), argCount);
    if (method.isNull()) throw new Error('method not found: ' + methodName);
    let paramsPtr = ptr(0);
    if (argCount > 0) {
        paramsPtr = Memory.alloc(8 * argCount);
        for (let i = 0; i < argCount; i++) paramsPtr.add(i*8).writePointer(params[i]);
    }
    let target = obj;
    if (api.mono_class_is_valuetype(klass)) target = api.mono_object_unbox(obj);
    const excPtr = Memory.alloc(8); excPtr.writePointer(ptr(0));
    const result = api.mono_runtime_invoke(method, target, paramsPtr, excPtr);
    const exc = excPtr.readPointer();
    if (!exc.isNull()) throw new Error('exception calling ' + methodName);
    return result;
}

function invokeOnClass(obj, klass, methodName, argCount, params) {
    const method = api.mono_class_get_method_from_name(klass, Memory.allocUtf8String(methodName), argCount);
    if (method.isNull()) return false;
    let paramsPtr = ptr(0);
    if (argCount > 0) {
        paramsPtr = Memory.alloc(8 * argCount);
        for (let i = 0; i < argCount; i++) paramsPtr.add(i*8).writePointer(params[i]);
    }
    let target = obj;
    if (api.mono_class_is_valuetype(klass)) target = api.mono_object_unbox(obj);
    const excPtr = Memory.alloc(8); excPtr.writePointer(ptr(0));
    api.mono_runtime_invoke(method, target, paramsPtr, excPtr);
    return excPtr.readPointer().isNull();
}

function unboxBool(boxed) { return api.mono_object_unbox(boxed).readU8() !== 0; }
function unboxInt(boxed) { return api.mono_object_unbox(boxed).readInt(); }

function forEachDictValue(dictObj, fn) {
    const values = invoke(dictObj, 'get_Values', 0, []);
    const enumerator = invoke(values, 'GetEnumerator', 0, []);
    while (unboxBool(invoke(enumerator, 'MoveNext', 0, []))) {
        fn(invoke(enumerator, 'get_Current', 0, []));
    }
}

function dictTryGetValue(dictObj, keyStr) {
    const outBuf = Memory.alloc(8); outBuf.writePointer(ptr(0));
    const ok = unboxBool(invoke(dictObj, 'TryGetValue', 2, [monoStr(keyStr), outBuf]));
    if (!ok) return null;
    const p = outBuf.readPointer();
    return p.isNull() ? null : p;
}

function listToArray(listObj) {
    if (!listObj) return [];
    const count = unboxInt(invoke(listObj, 'get_Count', 0, []));
    const out = [];
    for (let i = 0; i < count; i++) {
        const b = intArg(i);
        out.push(invoke(listObj, 'get_Item', 1, [b]));
    }
    return out;
}

function findStateAndPlayer() {
    if (!resolveMono()) return { error: 'mono not loaded' };
    ensureAttached();
    const domain = api.mono_get_root_domain();
    const stateClass = findClass('SpiritSummoner.Application.State', 'PlayerStateService');
    if (!stateClass) return { error: 'PlayerStateService not found' };
    const playerClass = findClass('SpiritSummoner.Domain.Entities.Players', 'Player');
    if (!playerClass) return { error: 'Player not found' };
    const stateVtable = api.mono_class_vtable(domain, stateClass);
    const playerVtable = api.mono_class_vtable(domain, playerClass);
    const sessionField = api.mono_class_get_field_from_name(stateClass, Memory.allocUtf8String('_currentSession'));
    if (sessionField.isNull()) return { error: '_currentSession not found' };
    const pattern = ptrPattern(stateVtable);
    let player = null, state = null;
    for (const range of Process.enumerateRanges('rw-')) {
        if (range.size > 256*1024*1024) continue;
        let matches;
        try { matches = Memory.scanSync(range.base, range.size, pattern); } catch(e) { continue; }
        for (const m of matches) {
            try {
                const playerObj = api.mono_field_get_value_object(domain, sessionField, m.address);
                if (playerObj.isNull()) continue;
                if (playerObj.readPointer().equals(playerVtable)) { player = playerObj; state = m.address; break; }
            } catch(e) {}
        }
        if (player) break;
    }
    if (!player) return { error: 'player not found' };
    return { player, playerClass, state, stateClass };
}

function newGuid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
        const r = Math.random()*16|0, v = c==='x' ? r : (r&0x3|0x8);
        return v.toString(16);
    });
}

const TYPE_NAMES = ['None','Neutral','Dark','Fire','Grass','Ground','Metal','Poison','Water','Wind','Electric','Light','Melee'];
const EVO_ITEM_BY_TYPE = {
    Water:'seashell', Poison:'mushroom', Dark:'onyx', Fire:'flint',
    Grass:'seed', Light:'diamond', Wind:'feather', Electric:'',
    Ground:'clay', Neutral:'pearl', Metal:'', Melee:'', None:''
};

rpc.exports = {
    grantAll(excludeIds) {
        const r = findStateAndPlayer();
        if (r.error) return r;
        const { player, playerClass, state, stateClass } = r;
        const domain = api.mono_get_root_domain();

        // Get static data
        const spiritRepo = getObjField(state, stateClass, '_spiritRepository');
        const cache = getObjField(spiritRepo, api.mono_object_get_class(spiritRepo), '_staticDataCache');
        const spiritsDict = getObjField(cache, api.mono_object_get_class(cache), '<Spirits>k__BackingField');
        const tasksByArea = getObjField(cache, api.mono_object_get_class(cache), '<TasksByArea>k__BackingField');

        // PlayerSpirit class
        const psClass = findClass('SpiritSummoner.Domain.Entities.Players', 'PlayerSpirit');
        if (!psClass) return { error: 'PlayerSpirit class not found' };

        // Player's collection dict
        const playerSpiritsDict = getObjField(player, playerClass, '_playerSpirits');

        // Get player ID
        const pidField = api.mono_class_get_field_from_name(playerClass, Memory.allocUtf8String('<PlayerID>k__BackingField'));
        const pidObj = api.mono_field_get_value_object(domain, pidField, player);
        const playerIdStr = jsStr(pidObj) || 'player1';

        // Collect currently owned baseSpiritIDs
        const ownedIds = {};
        forEachDictValue(playerSpiritsDict, (ps) => {
            const bid = getInt(ps, api.mono_object_get_class(ps), '<BaseSpiritID>k__BackingField');
            if (bid) ownedIds[bid] = true;
        });

        // Collect all obtainable spirit IDs from quest opponents (dropRate > 0)
        const toGrantIds = {};
        forEachDictValue(tasksByArea, (taskList) => {
            for (const task of listToArray(taskList)) {
                const tc = api.mono_object_get_class(task);
                const opField = api.mono_class_get_field_from_name(tc, Memory.allocUtf8String('_questOpponents'));
                if (opField.isNull()) continue;
                const oppList = api.mono_field_get_value_object(domain, opField, task);
                if (!oppList || oppList.isNull()) continue;
                for (const opp of listToArray(oppList)) {
                    const oc = api.mono_object_get_class(opp);
                    const idStr = jsStr(getObjField(opp, oc, '<BaseSpiritId>k__BackingField'));
                    if (!idStr) continue;
                    const idInt = parseInt(idStr);
                    if (excludeIds.indexOf(idInt) !== -1) continue;
                    const drField = api.mono_class_get_field_from_name(oc, Memory.allocUtf8String('<DropRate>k__BackingField'));
                    const drBuf = Memory.alloc(8); api.mono_field_get_value(opp, drField, drBuf);
                    if (drBuf.readDouble() > 0) toGrantIds[idStr] = true;
                }
            }
        });

        const spiritsAdded = [], orbsGranted = [], skipped = [];

        // PlayerSpirits dict Add method
        const dictClass = api.mono_object_get_class(playerSpiritsDict);
        const addMethod = api.mono_class_get_method_from_name(dictClass, Memory.allocUtf8String('Add'), 2);

        // PlayerSpirit .ctor
        const ctorMethod = api.mono_class_get_method_from_name(psClass, Memory.allocUtf8String('.ctor'), 0);

        for (const spiritIdStr of Object.keys(toGrantIds)) {
            const idInt = parseInt(spiritIdStr);
            const template = dictTryGetValue(spiritsDict, spiritIdStr);
            if (!template) { skipped.push(spiritIdStr + ' (no template)'); continue; }
            const tc = api.mono_object_get_class(template);
            const tName = jsStr(getObjField(template, tc, '<Name>k__BackingField')) || ('Spirit' + spiritIdStr);
            const evolution = getInt(template, tc, '<Evolution>k__BackingField');
            const type1 = TYPE_NAMES[getInt(template, tc, '<Type1>k__BackingField')] || 'None';
            const bsObj = getObjField(template, tc, '<BaseStats>k__BackingField');
            const baseHp = bsObj ? getInt(bsObj, api.mono_object_get_class(bsObj), '<HP>k__BackingField') : 100;

            // Add spirit to collection if not already owned
            if (!ownedIds[idInt]) {
                try {
                    const guid = newGuid();
                    const newPs = api.mono_object_new(domain, psClass);
                    const ctorExc = Memory.alloc(8); ctorExc.writePointer(ptr(0));
                    api.mono_runtime_invoke(ctorMethod, newPs, ptr(0), ctorExc);

                    // Set fields via internal methods
                    invokeOnClass(newPs, psClass, 'SetPlayerSpiritID', 1, [monoStr(guid)]);
                    invokeOnClass(newPs, psClass, 'SetName', 1, [monoStr(tName)]);
                    invokeOnClass(newPs, psClass, 'SetBaseSpiritID', 1, [intArg(idInt)]);
                    invokeOnClass(newPs, psClass, 'SetLevel', 1, [intArg(1)]);
                    invokeOnClass(newPs, psClass, 'SetHP', 1, [intArg(baseHp || 100)]);
                    invokeOnClass(newPs, psClass, 'SetPlayerName', 1, [monoStr(playerIdStr)]);

                    // dict.Add(guid, newPs)
                    const addParams = Memory.alloc(16);
                    addParams.writePointer(monoStr(guid));
                    addParams.add(8).writePointer(newPs);
                    const addExc = Memory.alloc(8); addExc.writePointer(ptr(0));
                    api.mono_runtime_invoke(addMethod, playerSpiritsDict, addParams, addExc);

                    if (addExc.readPointer().isNull()) {
                        spiritsAdded.push(tName);
                        ownedIds[idInt] = true;
                    } else {
                        skipped.push(tName + ' (dict.Add threw)');
                    }
                } catch(e) {
                    skipped.push(tName + ' (err: ' + e.message + ')');
                }
            } else {
                skipped.push(tName + ' (already owned)');
            }

            // Grant evolution orbs if this spirit can evolve
            if (evolution && evolution !== 0) {
                let coresRequired = 10;
                let special = '';
                const reqObj = getObjField(template, tc, '<Requirements>k__BackingField');
                if (reqObj) {
                    const rc = api.mono_object_get_class(reqObj);
                    const erObj = getObjField(reqObj, rc, '<EvolveRequirements>k__BackingField');
                    if (erObj) {
                        const erc = api.mono_object_get_class(erObj);
                        const cr = getInt(erObj, erc, '<CoresRequired>k__BackingField');
                        if (cr && cr > 0) coresRequired = cr;
                        special = jsStr(getObjField(erObj, erc, '<Special>k__BackingField')) || '';
                    }
                }
                if (!special) special = EVO_ITEM_BY_TYPE[type1] || '';

                const orbId = tName + ' Orb #' + spiritIdStr;
                try {
                    invoke(player, 'AddInventoryItem', 2, [monoStr(orbId), intArg(coresRequired)]);
                    orbsGranted.push(orbId + ' x' + coresRequired);
                } catch(e) {
                    skipped.push('orb ' + orbId + ' failed');
                }
                if (special) {
                    try {
                        invoke(player, 'AddInventoryItem', 2, [monoStr(special), intArg(1)]);
                        orbsGranted.push(special + ' x1');
                    } catch(e) {}
                }
            }
        }

        return { spiritsAdded, orbsGranted, skipped };
    }
};
