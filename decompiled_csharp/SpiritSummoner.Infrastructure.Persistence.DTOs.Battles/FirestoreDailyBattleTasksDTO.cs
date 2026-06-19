using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Plugin.Firebase.Firestore;
using SpiritSummoner.Domain.Entities.Battles;

namespace SpiritSummoner.Infrastructure.Persistence.DTOs.Battles;

public sealed class FirestoreDailyBattleTasksDTO : IFirestoreObject
{
	[FirestoreProperty("completeBattles")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public FirestoreBattleTaskProgressDTO? CompleteBattles
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("winBattles")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public FirestoreBattleTaskProgressDTO? WinBattles
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("winPvP1v1Battles")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public FirestoreBattleTaskProgressDTO? WinPvP1v1Battles
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("winPvP3v3Battles")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public FirestoreBattleTaskProgressDTO? WinPvP3v3Battles
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("winNPCBattles")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public FirestoreBattleTaskProgressDTO? WinNPCBattles
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("attackDefenders")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public FirestoreBattleTaskProgressDTO? AttackDefenders
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("registerAsDefender")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public FirestoreBattleTaskProgressDTO? RegisterAsDefender
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public Dictionary<string, PlayerBattleTaskProgress> ToTaskDict()
	{
		Dictionary<string, PlayerBattleTaskProgress> val = new Dictionary<string, PlayerBattleTaskProgress>();
		if (CompleteBattles != null)
		{
			val["completeBattles"] = PlayerBattleTaskProgress.Rehydrate(CompleteBattles.Count, CompleteBattles.Claimed);
		}
		if (WinBattles != null)
		{
			val["winBattles"] = PlayerBattleTaskProgress.Rehydrate(WinBattles.Count, WinBattles.Claimed);
		}
		if (WinPvP1v1Battles != null)
		{
			val["winPvP1v1Battles"] = PlayerBattleTaskProgress.Rehydrate(WinPvP1v1Battles.Count, WinPvP1v1Battles.Claimed);
		}
		if (WinPvP3v3Battles != null)
		{
			val["winPvP3v3Battles"] = PlayerBattleTaskProgress.Rehydrate(WinPvP3v3Battles.Count, WinPvP3v3Battles.Claimed);
		}
		if (WinNPCBattles != null)
		{
			val["winNPCBattles"] = PlayerBattleTaskProgress.Rehydrate(WinNPCBattles.Count, WinNPCBattles.Claimed);
		}
		if (AttackDefenders != null)
		{
			val["attackDefenders"] = PlayerBattleTaskProgress.Rehydrate(AttackDefenders.Count, AttackDefenders.Claimed);
		}
		if (RegisterAsDefender != null)
		{
			val["registerAsDefender"] = PlayerBattleTaskProgress.Rehydrate(RegisterAsDefender.Count, RegisterAsDefender.Claimed);
		}
		return val;
	}

	public static FirestoreDailyBattleTasksDTO FromEntity(PlayerDailyBattleTasks entity)
	{
		FirestoreDailyBattleTasksDTO firestoreDailyBattleTasksDTO = new FirestoreDailyBattleTasksDTO();
		IReadOnlyDictionary<string, PlayerBattleTaskProgress> tasks = entity.Tasks;
		PlayerBattleTaskProgress playerBattleTaskProgress = default(PlayerBattleTaskProgress);
		if (tasks.TryGetValue("completeBattles", ref playerBattleTaskProgress))
		{
			firestoreDailyBattleTasksDTO.CompleteBattles = new FirestoreBattleTaskProgressDTO
			{
				Count = playerBattleTaskProgress.CurrentCount,
				Claimed = playerBattleTaskProgress.IsRewardClaimed
			};
		}
		PlayerBattleTaskProgress playerBattleTaskProgress2 = default(PlayerBattleTaskProgress);
		if (tasks.TryGetValue("winBattles", ref playerBattleTaskProgress2))
		{
			firestoreDailyBattleTasksDTO.WinBattles = new FirestoreBattleTaskProgressDTO
			{
				Count = playerBattleTaskProgress2.CurrentCount,
				Claimed = playerBattleTaskProgress2.IsRewardClaimed
			};
		}
		PlayerBattleTaskProgress playerBattleTaskProgress3 = default(PlayerBattleTaskProgress);
		if (tasks.TryGetValue("winPvP1v1Battles", ref playerBattleTaskProgress3))
		{
			firestoreDailyBattleTasksDTO.WinPvP1v1Battles = new FirestoreBattleTaskProgressDTO
			{
				Count = playerBattleTaskProgress3.CurrentCount,
				Claimed = playerBattleTaskProgress3.IsRewardClaimed
			};
		}
		PlayerBattleTaskProgress playerBattleTaskProgress4 = default(PlayerBattleTaskProgress);
		if (tasks.TryGetValue("winPvP3v3Battles", ref playerBattleTaskProgress4))
		{
			firestoreDailyBattleTasksDTO.WinPvP3v3Battles = new FirestoreBattleTaskProgressDTO
			{
				Count = playerBattleTaskProgress4.CurrentCount,
				Claimed = playerBattleTaskProgress4.IsRewardClaimed
			};
		}
		PlayerBattleTaskProgress playerBattleTaskProgress5 = default(PlayerBattleTaskProgress);
		if (tasks.TryGetValue("winNPCBattles", ref playerBattleTaskProgress5))
		{
			firestoreDailyBattleTasksDTO.WinNPCBattles = new FirestoreBattleTaskProgressDTO
			{
				Count = playerBattleTaskProgress5.CurrentCount,
				Claimed = playerBattleTaskProgress5.IsRewardClaimed
			};
		}
		PlayerBattleTaskProgress playerBattleTaskProgress6 = default(PlayerBattleTaskProgress);
		if (tasks.TryGetValue("attackDefenders", ref playerBattleTaskProgress6))
		{
			firestoreDailyBattleTasksDTO.AttackDefenders = new FirestoreBattleTaskProgressDTO
			{
				Count = playerBattleTaskProgress6.CurrentCount,
				Claimed = playerBattleTaskProgress6.IsRewardClaimed
			};
		}
		PlayerBattleTaskProgress playerBattleTaskProgress7 = default(PlayerBattleTaskProgress);
		if (tasks.TryGetValue("registerAsDefender", ref playerBattleTaskProgress7))
		{
			firestoreDailyBattleTasksDTO.RegisterAsDefender = new FirestoreBattleTaskProgressDTO
			{
				Count = playerBattleTaskProgress7.CurrentCount,
				Claimed = playerBattleTaskProgress7.IsRewardClaimed
			};
		}
		return firestoreDailyBattleTasksDTO;
	}
}
