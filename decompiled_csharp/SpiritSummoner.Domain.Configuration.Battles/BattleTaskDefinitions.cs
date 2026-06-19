using System;
using System.Collections.Generic;
using System.Linq;
using SpiritSummoner.Domain.Enums.Battles;

namespace SpiritSummoner.Domain.Configuration.Battles;

public static class BattleTaskDefinitions
{
	public static readonly global::System.Collections.Generic.IReadOnlyList<BattleTaskDefinition> All = new BattleTaskDefinition[7]
	{
		new BattleTaskDefinition("completeBattles", BattleTaskType.CompleteBattle, "Battle Veteran", "Complete 15 battles today", 15, IsWarTask: false, 500L, 1, 0L),
		new BattleTaskDefinition("winBattles", BattleTaskType.WinBattle, "Winning Streak", "Win 10 battles today", 10, IsWarTask: false, 300L, 0, 0L),
		new BattleTaskDefinition("winPvP1v1Battles", BattleTaskType.WinBattle1v1, "Winning Streak", "Win 3 1v1 battles today", 3, IsWarTask: false, 300L, 0, 0L),
		new BattleTaskDefinition("winPvP3v3Battles", BattleTaskType.WinBattle3v3, "Winning Streak", "Win 3 3v3 battles today", 3, IsWarTask: false, 300L, 0, 0L),
		new BattleTaskDefinition("winNPCBattles", BattleTaskType.WinBattlePvE, "Monster Slayer", "Win 5 NPC battles today", 5, IsWarTask: false, 200L, 1, 0L),
		new BattleTaskDefinition("attackDefenders", BattleTaskType.AttackWarDefender, "War Attacker", "Attack 15 guild war defenders", 15, IsWarTask: true, 0L, 0, 100L),
		new BattleTaskDefinition("registerAsDefender", BattleTaskType.RegisterAsDefender, "Front Line Defense", "Register as a guild war defender", 1, IsWarTask: true, 0L, 1, 50L)
	};

	public static BattleTaskDefinition? GetById(string taskId)
	{
		string taskId2 = taskId;
		return Enumerable.FirstOrDefault<BattleTaskDefinition>((global::System.Collections.Generic.IEnumerable<BattleTaskDefinition>)All, (Func<BattleTaskDefinition, bool>)((BattleTaskDefinition d) => d.TaskId == taskId2));
	}

	public static global::System.Collections.Generic.IEnumerable<BattleTaskDefinition> GetByType(BattleTaskType type)
	{
		return Enumerable.Where<BattleTaskDefinition>((global::System.Collections.Generic.IEnumerable<BattleTaskDefinition>)All, (Func<BattleTaskDefinition, bool>)((BattleTaskDefinition d) => d.Type == type));
	}
}
