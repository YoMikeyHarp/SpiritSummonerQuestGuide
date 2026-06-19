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
        if (!addr) return false;
        api[name] = new NativeFunction(addr, sig[0], sig[1]);
    }
    return true;
}

function ensureAttached() {
    if (!attachedThread) { api.mono_thread_attach(api.mono_get_root_domain()); attachedThread = true; }
}

function findClass(ns, name) {
    const nsBuf = Memory.allocUtf8String(ns), nameBuf = Memory.allocUtf8String(name);
    let found = null;
    const cb = new NativeCallback((asm) => {
        if (found) return;
        const img = api.mono_assembly_get_image(asm);
        if (!img.isNull()) { const k = api.mono_class_from_name(img, nsBuf, nameBuf); if (!k.isNull()) found = k; }
    }, 'void', ['pointer', 'pointer']);
    api.mono_assembly_foreach(cb, ptr(0));
    return found;
}

function ptrPattern(p) {
    const buf = Memory.alloc(8); buf.writePointer(p);
    return Array.from(new Uint8Array(buf.readByteArray(8))).map(b => b.toString(16).padStart(2,'0')).join(' ');
}

function getInt(obj, klass, f) {
    const field = api.mono_class_get_field_from_name(klass, Memory.allocUtf8String(f));
    if (field.isNull()) return 0;
    const buf = Memory.alloc(4); api.mono_field_get_value(obj, field, buf);
    return buf.readInt();
}

function getDbl(obj, klass, f) {
    const field = api.mono_class_get_field_from_name(klass, Memory.allocUtf8String(f));
    if (field.isNull()) return 0;
    const buf = Memory.alloc(8); api.mono_field_get_value(obj, field, buf);
    return buf.readDouble();
}

function getBool(obj, klass, f) {
    const field = api.mono_class_get_field_from_name(klass, Memory.allocUtf8String(f));
    if (field.isNull()) return false;
    const buf = Memory.alloc(1); api.mono_field_get_value(obj, field, buf);
    return buf.readU8() !== 0;
}

function getObjField(obj, klass, f) {
    const domain = api.mono_get_root_domain();
    const field = api.mono_class_get_field_from_name(klass, Memory.allocUtf8String(f));
    if (field.isNull()) return null;
    const r = api.mono_field_get_value_object(domain, field, obj);
    return r.isNull() ? null : r;
}

function monoStr(s) { return api.mono_string_new(api.mono_get_root_domain(), Memory.allocUtf8String(s)); }
function jsStr(ms) { if (!ms || ms.isNull()) return null; return api.mono_string_to_utf8(ms).readCString(); }
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
    if (!excPtr.readPointer().isNull()) throw new Error('exception in ' + methodName);
    return result;
}

function unboxBool(b) { return api.mono_object_unbox(b).readU8() !== 0; }
function unboxInt(b) { return api.mono_object_unbox(b).readInt(); }

function forEachDictEntry(dictObj, fn) {
    const keys = invoke(dictObj, 'get_Keys', 0, []);
    const vals = invoke(dictObj, 'get_Values', 0, []);
    const ke = invoke(keys, 'GetEnumerator', 0, []);
    const ve = invoke(vals, 'GetEnumerator', 0, []);
    while (unboxBool(invoke(ke, 'MoveNext', 0, []))) {
        invoke(ve, 'MoveNext', 0, []);
        const k = invoke(ke, 'get_Current', 0, []);
        const v = invoke(ve, 'get_Current', 0, []);
        fn(k, v);
    }
}

function forEachDictValue(dictObj, fn) {
    const vals = invoke(dictObj, 'get_Values', 0, []);
    const ve = invoke(vals, 'GetEnumerator', 0, []);
    while (unboxBool(invoke(ve, 'MoveNext', 0, []))) fn(invoke(ve, 'get_Current', 0, []));
}

function listToArray(listObj) {
    if (!listObj) return [];
    const count = unboxInt(invoke(listObj, 'get_Count', 0, []));
    const out = [];
    for (let i = 0; i < count; i++) { const b = intArg(i); out.push(invoke(listObj, 'get_Item', 1, [b])); }
    return out;
}

function dictTryGetValue(dictObj, keyStr) {
    const outBuf = Memory.alloc(8); outBuf.writePointer(ptr(0));
    const ok = unboxBool(invoke(dictObj, 'TryGetValue', 2, [monoStr(keyStr), outBuf]));
    if (!ok) return null;
    const p = outBuf.readPointer(); return p.isNull() ? null : p;
}

const TYPE_NAMES = ['None','Neutral','Dark','Fire','Grass','Ground','Metal','Poison','Water','Wind','Electric','Light','Melee'];
const MOVETYPE_NAMES = ['Physical','Special','None'];

function findStateAndPlayer() {
    if (!resolveMono()) return { error: 'mono not loaded' };
    ensureAttached();
    const domain = api.mono_get_root_domain();
    const stateClass = findClass('SpiritSummoner.Application.State', 'PlayerStateService');
    const playerClass = findClass('SpiritSummoner.Domain.Entities.Players', 'Player');
    if (!stateClass || !playerClass) return { error: 'classes not found' };
    const stateVtable = api.mono_class_vtable(domain, stateClass);
    const playerVtable = api.mono_class_vtable(domain, playerClass);
    const sessionField = api.mono_class_get_field_from_name(stateClass, Memory.allocUtf8String('_currentSession'));
    const pattern = ptrPattern(stateVtable);
    let player = null, state = null;
    for (const range of Process.enumerateRanges('rw-')) {
        if (range.size > 256*1024*1024) continue;
        let matches; try { matches = Memory.scanSync(range.base, range.size, pattern); } catch(e) { continue; }
        for (const m of matches) {
            try {
                const playerObj = api.mono_field_get_value_object(domain, sessionField, m.address);
                if (!playerObj.isNull() && playerObj.readPointer().equals(playerVtable)) { player = playerObj; state = m.address; break; }
            } catch(e) {}
        }
        if (player) break;
    }
    if (!player) return { error: 'player not found' };
    return { player, playerClass, state, stateClass };
}

rpc.exports = {
    dumpSpirits() {
        const r = findStateAndPlayer();
        if (r.error) return r;
        const { state, stateClass } = r;
        const spiritRepo = getObjField(state, stateClass, '_spiritRepository');
        const cache = getObjField(spiritRepo, api.mono_object_get_class(spiritRepo), '_staticDataCache');
        const spiritsDict = getObjField(cache, api.mono_object_get_class(cache), '<Spirits>k__BackingField');

        const spirits = [];
        forEachDictValue(spiritsDict, (s) => {
            const sc = api.mono_object_get_class(s);
            const id = jsStr(getObjField(s, sc, '<ID>k__BackingField'));
            const name = jsStr(getObjField(s, sc, '<Name>k__BackingField'));
            const type1 = TYPE_NAMES[getInt(s, sc, '<Type1>k__BackingField')] || 'None';
            const type2 = TYPE_NAMES[getInt(s, sc, '<Type2>k__BackingField')] || 'None';
            const evolution = getInt(s, sc, '<Evolution>k__BackingField');
            const preEvolution = getInt(s, sc, '<PreEvolution>k__BackingField');
            const isUnique = getBool(s, sc, '<IsUnique>k__BackingField');
            const category = jsStr(getObjField(s, sc, '<Category>k__BackingField'));
            const image = jsStr(getObjField(s, sc, '<Image>k__BackingField'));

            let baseStats = null;
            const bs = getObjField(s, sc, '<BaseStats>k__BackingField');
            if (bs) {
                const bsc = api.mono_object_get_class(bs);
                baseStats = {
                    hp: getInt(bs, bsc, '<HP>k__BackingField'),
                    atk: getInt(bs, bsc, '<ATK>k__BackingField'),
                    def: getInt(bs, bsc, '<DEF>k__BackingField'),
                    satk: getInt(bs, bsc, '<SATK>k__BackingField'),
                    sdef: getInt(bs, bsc, '<SDEF>k__BackingField'),
                    spd: getInt(bs, bsc, '<SPD>k__BackingField'),
                    int: getInt(bs, bsc, '<INT>k__BackingField'),
                };
            }

            let evoReq = null;
            const req = getObjField(s, sc, '<Requirements>k__BackingField');
            if (req) {
                const rc = api.mono_object_get_class(req);
                const er = getObjField(req, rc, '<EvolveRequirements>k__BackingField');
                if (er) {
                    const erc = api.mono_object_get_class(er);
                    evoReq = {
                        coresRequired: getInt(er, erc, '<CoresRequired>k__BackingField'),
                        itemRequired: jsStr(getObjField(er, erc, '<ItemRequired>k__BackingField')),
                        special: jsStr(getObjField(er, erc, '<Special>k__BackingField')),
                        levelRequired: getInt(er, erc, '<LevelRequired>k__BackingField'),
                        amount: getInt(er, erc, '<Amount>k__BackingField'),
                    };
                }
                const lr = getObjField(req, rc, '<LevelRequirement>k__BackingField');
                if (lr) {
                    const lrc = api.mono_object_get_class(lr);
                    if (!evoReq) evoReq = {};
                    evoReq.playerLevelRequired = getInt(lr, lrc, '<PlayerLevelRequired>k__BackingField');
                }
            }

            const moves = [];
            for (const mv of listToArray(getObjField(s, sc, '<LearnableMoves>k__BackingField'))) {
                const mvc = api.mono_object_get_class(mv);
                const mname = jsStr(getObjField(mv, mvc, '<Name>k__BackingField'));
                const mtype = TYPE_NAMES[getInt(mv, mvc, '<Type>k__BackingField')] || 'None';
                const mpower = getInt(mv, mvc, '<Power>k__BackingField');
                const mmovetype = MOVETYPE_NAMES[getInt(mv, mvc, '<MoveType>k__BackingField')] || 'None';
                let unlockLv = 0;
                const ur = getObjField(mv, mvc, '<UnlockRequirements>k__BackingField');
                if (ur) { const urc = api.mono_object_get_class(ur); unlockLv = getInt(ur, urc, '<LevelRequired>k__BackingField'); }
                moves.push({ name: mname, type: mtype, power: mpower, moveType: mmovetype, unlockLevel: unlockLv });
            }

            spirits.push({ id, name, type1, type2, evolution, preEvolution, isUnique, category, baseStats, evoReq, moves });
        });

        spirits.sort((a, b) => parseInt(a.id) - parseInt(b.id));
        return spirits;
    },

    dumpQuests() {
        const r = findStateAndPlayer();
        if (r.error) return r;
        const { state, stateClass } = r;
        const spiritRepo = getObjField(state, stateClass, '_spiritRepository');
        const cache = getObjField(spiritRepo, api.mono_object_get_class(spiritRepo), '_staticDataCache');

        // TasksByArea: Dictionary<string, List<QuestTask>>
        const tasksByArea = getObjField(cache, api.mono_object_get_class(cache), '<TasksByArea>k__BackingField');
        // AreasByQuest: Dictionary<string, List<Area>>
        const areasByQuest = getObjField(cache, api.mono_object_get_class(cache), '<AreasByQuest>k__BackingField');
        // Quests: Dictionary<string, Quest>?  or List?
        const questsField = getObjField(cache, api.mono_object_get_class(cache), '<Quests>k__BackingField');
        // Areas dict
        const areasField = getObjField(cache, api.mono_object_get_class(cache), '<Areas>k__BackingField');

        const result = { areas: {}, quests: {} };

        // Dump quests if available
        if (questsField) {
            try {
                forEachDictValue(questsField, (q) => {
                    const qc = api.mono_object_get_class(q);
                    const qid = jsStr(getObjField(q, qc, '<Id>k__BackingField'));
                    const qname = jsStr(getObjField(q, qc, '<Name>k__BackingField'));
                    const qorder = getInt(q, qc, '<Order>k__BackingField');
                    const qlvl = getInt(q, qc, '<LevelRequired>k__BackingField');
                    const qevent = getBool(q, qc, '<Event>k__BackingField');
                    result.quests[qid] = { id: qid, name: qname, order: qorder, levelRequired: qlvl, isEvent: qevent };
                });
            } catch(e) {}
        }

        // Dump areas
        if (areasField) {
            try {
                forEachDictValue(areasField, (a) => {
                    const ac = api.mono_object_get_class(a);
                    const aid = jsStr(getObjField(a, ac, '<Id>k__BackingField'));
                    const aname = jsStr(getObjField(a, ac, '<Name>k__BackingField'));
                    const aorder = getInt(a, ac, '<Order>k__BackingField');
                    const alvl = getInt(a, ac, '<LevelRequired>k__BackingField');
                    const atakreq = jsStr(getObjField(a, ac, '<TaskRequired>k__BackingField'));
                    result.areas[aid] = { id: aid, name: aname, order: aorder, levelRequired: alvl, taskRequired: atakreq, tasks: [] };
                });
            } catch(e) {}
        }

        // Dump tasks per area
        if (tasksByArea) {
            forEachDictEntry(tasksByArea, (areaKeyObj, taskListObj) => {
                const areaKey = jsStr(areaKeyObj);
                const tasks = [];
                for (const task of listToArray(taskListObj)) {
                    const tc = api.mono_object_get_class(task);
                    const tid = jsStr(getObjField(task, tc, '<Id>k__BackingField'));
                    const tname = jsStr(getObjField(task, tc, '<Name>k__BackingField'));
                    const tdesc = jsStr(getObjField(task, tc, '<Description>k__BackingField'));
                    const torder = getInt(task, tc, '<Order>k__BackingField');
                    const tenergy = getInt(task, tc, '<Energy>k__BackingField');
                    const tbattle = getBool(task, tc, '<Battle>k__BackingField');
                    const trepeatable = getBool(task, tc, '<IsRepeatable>k__BackingField');
                    const torderreq = jsStr(getObjField(task, tc, '<OrderRequirement>k__BackingField'));
                    const tlvlreq = getInt(task, tc, '<LevelRequirement>k__BackingField');
                    const toppname = jsStr(getObjField(task, tc, '<OpponentName>k__BackingField'));
                    const toppguild = jsStr(getObjField(task, tc, '<OpponentGuild>k__BackingField'));
                    const tsteps = getInt(task, tc, '<TotalSteps>k__BackingField');

                    // Rewards
                    let rewards = null;
                    const rwObj = getObjField(task, tc, '<Rewards>k__BackingField');
                    if (rwObj) {
                        const rwc = api.mono_object_get_class(rwObj);
                        const xp = getInt(rwObj, rwc, '<Experience>k__BackingField');
                        const gold = getInt(rwObj, rwc, '<Gold>k__BackingField');
                        const rep = getInt(rwObj, rwc, '<Reputation>k__BackingField');
                        const itemsList = getObjField(rwObj, rwc, '<Items>k__BackingField');
                        const items = [];
                        for (const itm of listToArray(itemsList)) {
                            const ic = api.mono_object_get_class(itm);
                            const iname = jsStr(getObjField(itm, ic, '<Name>k__BackingField'));
                            const iid = jsStr(getObjField(itm, ic, '<ID>k__BackingField'));
                            items.push({ id: iid, name: iname });
                        }
                        rewards = { xp, gold, rep, items };
                    }

                    // Opponents
                    const opField = api.mono_class_get_field_from_name(tc, Memory.allocUtf8String('_questOpponents'));
                    const opponents = [];
                    if (!opField.isNull()) {
                        const domain = api.mono_get_root_domain();
                        const oppList = api.mono_field_get_value_object(domain, opField, task);
                        if (!oppList.isNull()) {
                            for (const opp of listToArray(oppList)) {
                                const oc = api.mono_object_get_class(opp);
                                const oid = jsStr(getObjField(opp, oc, '<BaseSpiritId>k__BackingField'));
                                const olevel = getInt(opp, oc, '<Level>k__BackingField');
                                const ohp = getInt(opp, oc, '<HP>k__BackingField');
                                const odrField = api.mono_class_get_field_from_name(oc, Memory.allocUtf8String('<DropRate>k__BackingField'));
                                const odrBuf = Memory.alloc(8); api.mono_field_get_value(opp, odrField, odrBuf);
                                const odr = odrBuf.readDouble();
                                opponents.push({ baseSpiritId: oid, level: olevel, hp: ohp, dropRate: odr });
                            }
                        }
                    }

                    tasks.push({ id: tid, name: tname, description: tdesc, order: torder, energy: tenergy, battle: tbattle, repeatable: trepeatable, orderRequirement: torderreq, levelRequirement: tlvlreq, opponentName: toppname, opponentGuild: toppguild, totalSteps: tsteps, rewards, opponents });
                }
                tasks.sort((a, b) => a.order - b.order);
                if (result.areas[areaKey]) {
                    result.areas[areaKey].tasks = tasks;
                } else {
                    result.areas[areaKey] = { id: areaKey, tasks };
                }
            });
        }

        // Sort areas by order
        const sortedAreas = Object.values(result.areas).sort((a, b) => (a.order || 0) - (b.order || 0));
        return { quests: result.quests, areas: sortedAreas };
    }
};
