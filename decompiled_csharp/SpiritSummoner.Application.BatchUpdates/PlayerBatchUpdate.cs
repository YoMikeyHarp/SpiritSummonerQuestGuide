using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Application.DTOs;
using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Application.BatchUpdates;

public class PlayerBatchUpdate
{
	[MergeStrategy(MergeType.Ignore)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string PlayerId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[MergeStrategy(MergeType.LatestWinsNonNull)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string QuestId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[MergeStrategy(MergeType.DictionaryReplace)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, TaskProgress> TaskUpdates
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, TaskProgress>();


	[MergeStrategy(MergeType.Accumulate)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int ExperienceGain
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.Accumulate)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int EnergyChange
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWinsNonNull)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? NewEP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.Accumulate)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int SPChange
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.OrFlags)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool UpdateMaxEXP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.OrFlags)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool UpdateLevel
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.Computed)]
	public bool BattleStatsChange => WinsChange != 0 || LossChange != 0 || ScoreChange != 0;

	[MergeStrategy(MergeType.Accumulate)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int WinsChange
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.Accumulate)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int LossChange
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.Accumulate)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int ScoreChange
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.OrFlags)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool UpdateLeaderboard
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? NewTitle
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.DictionaryAccumulate)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, int> InventoryItemChanges
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, int>();


	[MergeStrategy(MergeType.ListConcat)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<string> InventoryKeysToDelete
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<string>();


	[MergeStrategy(MergeType.DictionaryAccumulate)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, long> CurrencyChanges
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, long>();


	[MergeStrategy(MergeType.OrFlags)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool UpdateReputation
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.OrFlags)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool UpdateInventory
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.ListConcat)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<string>? ViewedShopItems
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? LastShopViewedLevel
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.DeepMerge)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, PlayerSpiritFieldUpdate> SpiritFieldUpdates
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, PlayerSpiritFieldUpdate>();


	[MergeStrategy(MergeType.ListConcat)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<NewSpiritDTO> SpiritsToAdd
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<NewSpiritDTO>();


	[MergeStrategy(MergeType.ListConcat)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<string> SpiritsToRemove
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<string>();


	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? ActiveBattleUnitId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.DictionaryReplace)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, List<string>> SquadUpdates
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, List<string>>();


	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? NewActiveSquadSlot
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<string>? NewActiveSquadComp
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.OrFlags)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool UpdateActiveSquadSlot
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWinsNonNull)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int SlotInSquad
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.DeepMerge)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public PlayerGuildUpdate GuildUpdates
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new PlayerGuildUpdate();


	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool? SetAccountLinked
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWinsNonNull)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int NewPlayerLevel
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWinsNonNull)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int NewMaxEP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWinsNonNull)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public double NewEXP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWinsNonNull)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int NewMaxSP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWinsNonNull)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public double NewMaxEXP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.OrFlags)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool UpdateSpirits
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.OrFlags)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool UpdateActiveSquad
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.OrFlags)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool UpdateBattleUnit
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset? LastEpRegenTime
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset? LastSpRegenTime
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DailyBattleChestUpdate? DailyBattleChestUpdate
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? NewPlayerIcon
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWinsNonNull)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? CurrentGuildId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public bool HasUpdates()
	{
		return ExperienceGain != 0 || UpdateLevel || NewEP.HasValue || EnergyChange != 0 || SPChange != 0 || BattleStatsChange || CurrencyChanges.Count != 0 || InventoryItemChanges.Count != 0 || InventoryKeysToDelete.Count != 0 || TaskUpdates.Count != 0 || SpiritFieldUpdates.Count != 0 || SpiritsToAdd.Count != 0 || SpiritsToRemove.Count != 0 || SquadUpdates.Count != 0 || UpdateActiveSquadSlot || UpdateBattleUnit || UpdateSpirits || UpdateLeaderboard || ViewedShopItems != null || LastShopViewedLevel.HasValue || GuildUpdates.HasUpdates() || SetAccountLinked.HasValue || DailyBattleChestUpdate != null || NewPlayerIcon != null;
	}
}
