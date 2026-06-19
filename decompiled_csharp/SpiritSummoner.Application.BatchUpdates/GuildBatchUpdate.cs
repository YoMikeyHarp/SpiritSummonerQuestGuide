using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using SpiritSummoner.Application.State;

namespace SpiritSummoner.Application.BatchUpdates;

public class GuildBatchUpdate
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string GuildId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public GuildUpdateType UpdateType
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = GuildUpdateType.General;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? AffectedPlayerId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? XPGain
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? TrophyChange
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? GuildCoinChange
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool UpdateLevel
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? CrystalChange
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? StartingCrystalsChange
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? WarWinsChange
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? WarLossesChange
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? TotalWinsChange
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? TotalLossesChange
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? AttacksUsedChange
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset? LastAttackTime
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<string> AddedMembers
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<string>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<string> RemovedMembers
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<string>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, int> MemberContributionUpdates
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, int>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<string> AddedDefenders
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<string>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<string> RemovedDefenders
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<string>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<string>? NewMainDefenders
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool? IsPublicUpdate
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool? RequiresApprovalUpdate
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? MinLevelRequiredUpdate
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? MinTrophiesRequiredUpdate
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset? CurrentSeasonStartDate
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset? CurrentSeasonEndDate
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? CurrentWarSeasonId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, GuildActivePerkUpdate>? ActivePerksUpdate
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public bool HasUpdates()
	{
		return XPGain.HasValue || TrophyChange.HasValue || GuildCoinChange.HasValue || CrystalChange.HasValue || StartingCrystalsChange.HasValue || WarWinsChange.HasValue || WarLossesChange.HasValue || TotalWinsChange.HasValue || TotalLossesChange.HasValue || AttacksUsedChange.HasValue || Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)AddedMembers) || Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)RemovedMembers) || Enumerable.Any<KeyValuePair<string, int>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, int>>)MemberContributionUpdates) || Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)AddedDefenders) || Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)RemovedDefenders) || NewMainDefenders != null || IsPublicUpdate.HasValue || RequiresApprovalUpdate.HasValue || MinLevelRequiredUpdate.HasValue || MinTrophiesRequiredUpdate.HasValue || CurrentSeasonStartDate.HasValue || CurrentSeasonEndDate.HasValue || !string.IsNullOrEmpty(CurrentWarSeasonId) || UpdateLevel || ActivePerksUpdate != null;
	}

	public GuildChangeType GetPrimaryChangeType()
	{
		if (Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)AddedMembers) || Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)RemovedMembers))
		{
			return GuildChangeType.Members;
		}
		if (Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)AddedDefenders) || Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)RemovedDefenders) || NewMainDefenders != null)
		{
			return GuildChangeType.Defenders;
		}
		if (CrystalChange.HasValue || AttacksUsedChange.HasValue || CurrentWarSeasonId != null)
		{
			return GuildChangeType.War;
		}
		if (Enumerable.Any<KeyValuePair<string, int>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, int>>)MemberContributionUpdates))
		{
			return GuildChangeType.MemberStats;
		}
		return GuildChangeType.GuildProperties;
	}
}
