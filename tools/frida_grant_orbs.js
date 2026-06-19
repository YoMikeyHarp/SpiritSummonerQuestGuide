// Frida script: grant exact evolution-orb / special-item amounts for currently-owned,
// evolution-eligible spirits. Built on the same vtable-scan pattern as frida_energy3.js
// (one-shot attach, no persistent hooks).
//
// For each entry in player._playerSpirits (PlayerSpirit), look up its base Spirit
// template via StaticDataCacheService.Spirits[BaseSpiritID]. If template.Evolution != 0,
// compute:
//   orbId       = template.Name + " Orb #" + template.ID
//   coresNeeded = Requirements.EvolveRequirements.CoresRequired (fallback 10)
//   special     = Requirements.EvolveRequirements.Special, else GetEvoItemRequired(Type1)
// Then top up player._inventory so the player has *exactly* coresNeeded orbs and
// (if applicable) 1 of the special item - only adding the deficit, never removing.

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

function setInt(obj, klass, fieldName, value) {
    const field = api.mono_class_get_field_from_name(klass, Memory.allocUtf8String(fieldName));
    if (field.isNull()) return false;
    const buf = Memory.alloc(4);
    buf.writeInt(value);
    api.mono_field_set_value(obj, field, buf);
    return true;
}

function getObjField(obj, klass, fieldName) {
    const domain = api.mono_get_root_domain();
    const field = api.mono_class_get_field_from_name(klass, Memory.allocUtf8String(fieldName));
    if (field.isNull()) return null;
    const result = api.mono_field_get_value_object(domain, field, obj);
    return result.isNull() ? null : result;
}

function monoStr(jsStr) {
    const domain = api.mono_get_root_domain();
    return api.mono_string_new(domain, Memory.allocUtf8String(jsStr));
}

function jsStr(monoString) {
    if (!monoString || monoString.isNull()) return null;
    const utf8 = api.mono_string_to_utf8(monoString);
    return utf8.readCString();
}

// Invoke an instance method (resolved on the object's runtime class) with the given
// params array (each element already a NativePointer suitable for mono_runtime_invoke).
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

function ptrFor(value) {
    const buf = Memory.alloc(8);
    buf.writePointer(value);
    return buf;
}

function intArg(value) {
    const buf = Memory.alloc(4);
    buf.writeInt(value);
    return buf;
}

// Dictionary<string, TValue>.TryGetValue(key) -> object or null
function dictTryGetValue(dictObj, keyStr) {
    const keyMono = monoStr(keyStr);
    const outBuf = Memory.alloc(8);
    outBuf.writePointer(ptr(0));
    const ok = unboxBool(invoke(dictObj, 'TryGetValue', 2, [keyMono, outBuf]));
    if (!ok) return null;
    return outBuf.readPointer();
}

// Iterate Dictionary<string, TValue>.Values, calling fn(valueObj) for each.
function forEachDictValue(dictObj, fn) {
    const values = invoke(dictObj, 'get_Values', 0, []);
    const enumerator = invoke(values, 'GetEnumerator', 0, []);
    while (unboxBool(invoke(enumerator, 'MoveNext', 0, []))) {
        const current = invoke(enumerator, 'get_Current', 0, []);
        fn(current);
    }
}

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

const TYPE_NAMES = ['None', 'Neutral', 'Dark', 'Fire', 'Grass', 'Ground', 'Metal', 'Poison', 'Water', 'Wind', 'Electric', 'Light', 'Melee'];
const EVO_ITEM_BY_TYPE = {
    Water: 'seashell',
    Poison: 'mushroom',
    Dark: 'onyx',
    Fire: 'flint',
    Grass: 'seed',
    Light: 'diamond',
    Wind: 'feather',
    Electric: '',
    Ground: 'clay',
    Neutral: 'pearl',
    Metal: '',
    Melee: '',
    None: '',
};

function buildPlan() {
    const r = findStateAndPlayer();
    if (r.error) return r;
    const { player, playerClass, state, stateClass } = r;

    const spiritRepo = getObjField(state, stateClass, '_spiritRepository');
    if (!spiritRepo) return { error: '_spiritRepository not found' };
    const cache = getObjField(spiritRepo, api.mono_object_get_class(spiritRepo), '_staticDataCache');
    if (!cache) return { error: '_staticDataCache not found' };
    const spiritsDict = getObjField(cache, api.mono_object_get_class(cache), '<Spirits>k__BackingField');
    if (!spiritsDict) return { error: 'Spirits dictionary not found' };

    const playerSpiritsDict = getObjField(player, playerClass, '_playerSpirits');
    if (!playerSpiritsDict) return { error: '_playerSpirits not found' };

    const inventoryDict = getObjField(player, playerClass, '_inventory');
    if (!inventoryDict) return { error: '_inventory not found' };

    const playerSpiritClass = null; // resolved per-object via mono_object_get_class

    const plan = [];
    forEachDictValue(playerSpiritsDict, (psObj) => {
        const psClass = api.mono_object_get_class(psObj);
        const baseSpiritId = getInt(psObj, psClass, '<BaseSpiritID>k__BackingField');
        const ownedName = jsStr(getObjField(psObj, psClass, '<Name>k__BackingField'));

        const template = dictTryGetValue(spiritsDict, String(baseSpiritId));
        if (!template) return;
        const tClass = api.mono_object_get_class(template);

        const evolution = getInt(template, tClass, '<Evolution>k__BackingField');
        if (!evolution) return; // 0 = no evolution

        const tId = jsStr(getObjField(template, tClass, '<ID>k__BackingField'));
        const tName = jsStr(getObjField(template, tClass, '<Name>k__BackingField'));
        const type1Val = getInt(template, tClass, '<Type1>k__BackingField');
        const type1 = TYPE_NAMES[type1Val] || 'None';

        let coresRequired = 10;
        let special = '';
        const requirements = getObjField(template, tClass, '<Requirements>k__BackingField');
        if (requirements) {
            const reqClass = api.mono_object_get_class(requirements);
            const evolveReq = getObjField(requirements, reqClass, '<EvolveRequirements>k__BackingField');
            if (evolveReq) {
                const erClass = api.mono_object_get_class(evolveReq);
                const cores = getInt(evolveReq, erClass, '<CoresRequired>k__BackingField');
                if (cores && cores > 0) coresRequired = cores;
                special = jsStr(getObjField(evolveReq, erClass, '<Special>k__BackingField')) || '';
            }
        }
        if (!special) special = EVO_ITEM_BY_TYPE[type1] || '';

        const orbId = tName + ' Orb #' + tId;

        const needs = [{ item: orbId, amount: coresRequired }];
        if (special) needs.push({ item: special, amount: 1 });

        for (const need of needs) {
            const existing = dictTryGetValue(inventoryDict, need.item);
            let current = 0;
            if (existing) {
                current = getInt(existing, api.mono_object_get_class(existing), '<Amount>k__BackingField');
            }
            const deficit = Math.max(0, need.amount - current);
            plan.push({
                spirit: ownedName,
                baseSpiritId,
                item: need.item,
                required: need.amount,
                current,
                deficit,
            });
        }
    });

    return { player, playerClass, plan };
}

function buildDebug() {
    const r = findStateAndPlayer();
    if (r.error) return r;
    const { player, playerClass, state, stateClass } = r;

    const spiritRepo = getObjField(state, stateClass, '_spiritRepository');
    if (!spiritRepo) return { error: '_spiritRepository not found' };
    const cache = getObjField(spiritRepo, api.mono_object_get_class(spiritRepo), '_staticDataCache');
    if (!cache) return { error: '_staticDataCache not found' };
    const spiritsDict = getObjField(cache, api.mono_object_get_class(cache), '<Spirits>k__BackingField');
    if (!spiritsDict) return { error: 'Spirits dictionary not found' };

    const playerSpiritsDict = getObjField(player, playerClass, '_playerSpirits');
    if (!playerSpiritsDict) return { error: '_playerSpirits not found' };

    const out = [];
    forEachDictValue(playerSpiritsDict, (psObj) => {
        const psClass = api.mono_object_get_class(psObj);
        const baseSpiritId = getInt(psObj, psClass, '<BaseSpiritID>k__BackingField');
        const ownedName = jsStr(getObjField(psObj, psClass, '<Name>k__BackingField'));
        const template = dictTryGetValue(spiritsDict, String(baseSpiritId));
        let evolution = null;
        if (template) {
            const tClass = api.mono_object_get_class(template);
            evolution = getInt(template, tClass, '<Evolution>k__BackingField');
        }
        out.push({ ownedName, baseSpiritId, templateFound: !!template, evolution });
    });
    return { count: out.length, out };
}

rpc.exports = {
    debug() {
        return buildDebug();
    },

    plan() {
        const r = buildPlan();
        if (r.error) return r;
        return { plan: r.plan };
    },

    grant() {
        const r = buildPlan();
        if (r.error) return r;
        const { player, playerClass, plan } = r;

        const granted = [];
        for (const entry of plan) {
            if (entry.deficit <= 0) continue;
            invoke(player, 'AddInventoryItem', 2, [monoStr(entry.item), intArg(entry.deficit)]);
            granted.push({ spirit: entry.spirit, item: entry.item, added: entry.deficit, newTotal: entry.current + entry.deficit });
        }
        return { granted };
    },
};
