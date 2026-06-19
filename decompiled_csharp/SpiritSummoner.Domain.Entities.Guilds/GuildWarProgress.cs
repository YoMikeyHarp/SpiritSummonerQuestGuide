using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Domain.Entities.Guilds;

public class GuildWarProgress
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string ID
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string WarId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string AttackingGuildId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string DefendingGuildId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, DefenderWarRecord> DefeatedDefenders
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, DefenderWarRecord>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int CrystalsStolen
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset LastRaidTime
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string SeasonId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int TotalAttacksCount
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int RaidCount
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, long> PlayerAttackCounts
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, long>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, DateTimeOffset?> PlayerHourlyStarts
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, DateTimeOffset?>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, int> PlayerHourlyCrystals
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, int>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int StartingCrystals
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, int> PlayerRaidCounts
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, int>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, DateTimeOffset?> PlayerRaidHourStarts
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, DateTimeOffset?>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, int> PlayerTotalCrystalsAttack
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, int>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, int> PlayerTotalCrystalsRaid
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, int>();


	public int Wins => Enumerable.Sum<DefenderWarRecord>((global::System.Collections.Generic.IEnumerable<DefenderWarRecord>)DefeatedDefenders.Values, (Func<DefenderWarRecord, int>)((DefenderWarRecord r) => r.DefeatCount));

	public int Losses => Math.Max(0, TotalAttacksCount - Wins);

	public int TotalCrystalsGained => Enumerable.Sum<DefenderWarRecord>((global::System.Collections.Generic.IEnumerable<DefenderWarRecord>)DefeatedDefenders.Values, (Func<DefenderWarRecord, int>)((DefenderWarRecord r) => r.CrystalsGained));

	public int CurrentCrystals => Math.Max(0, StartingCrystals + TotalCrystalsGained - CrystalsStolen);

	public double ProtectionMultiplier => (StartingCrystals > 0) ? Math.Sqrt((double)CurrentCrystals / (double)StartingCrystals) : 1.0;

	public double DefenseFatigueMultiplier
	{
		get
		{
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			DateTimeOffset val = Enumerable.Max<DateTimeOffset>(Enumerable.DefaultIfEmpty<DateTimeOffset>(Enumerable.Select<DefenderWarRecord, DateTimeOffset>(Enumerable.Where<DefenderWarRecord>((global::System.Collections.Generic.IEnumerable<DefenderWarRecord>)DefeatedDefenders.Values, (Func<DefenderWarRecord, bool>)((DefenderWarRecord r) => r.LastFellAt.HasValue)), (Func<DefenderWarRecord, DateTimeOffset>)((DefenderWarRecord r) => r.LastFellAt.Value))));
			if (val == default(DateTimeOffset))
			{
				return 1.0;
			}
			TimeSpan val2 = DateTimeOffset.UtcNow - val;
			double totalHours = ((TimeSpan)(ref val2)).TotalHours;
			if (totalHours >= 8.0)
			{
				return 2.0;
			}
			if (totalHours >= 4.0)
			{
				return 1.5;
			}
			return 1.0;
		}
	}

	public bool IsHourlyWindowActive(string playerId)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		DateTimeOffset? val = default(DateTimeOffset?);
		int result;
		if (PlayerHourlyStarts.TryGetValue(playerId, ref val) && val.HasValue)
		{
			TimeSpan val2 = DateTimeOffset.UtcNow - val.Value;
			result = ((((TimeSpan)(ref val2)).TotalHours < 1.0) ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public int HourlyBudgetRemaining(string playerId)
	{
		return IsHourlyWindowActive(playerId) ? Math.Max(0, 500 - CollectionExtensions.GetValueOrDefault<string, int>((IReadOnlyDictionary<string, int>)(object)PlayerHourlyCrystals, playerId, 0)) : 500;
	}

	public bool IsDefenderInDowntime(string defenderId)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		DefenderWarRecord defenderWarRecord = default(DefenderWarRecord);
		return DefeatedDefenders.TryGetValue(defenderId, ref defenderWarRecord) && DateTimeOffset.UtcNow < defenderWarRecord.DowntimeEnds;
	}

	public bool IsPlayerRaidHourExpired(string playerId)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		DateTimeOffset? val = default(DateTimeOffset?);
		int result;
		if (PlayerRaidHourStarts.TryGetValue(playerId, ref val) && val.HasValue)
		{
			TimeSpan val2 = DateTimeOffset.UtcNow - val.Value;
			result = ((((TimeSpan)(ref val2)).TotalHours >= 1.0) ? 1 : 0);
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	public int GetEffectiveRaidCount(string playerId)
	{
		return (!IsPlayerRaidHourExpired(playerId)) ? CollectionExtensions.GetValueOrDefault<string, int>((IReadOnlyDictionary<string, int>)(object)PlayerRaidCounts, playerId, 0) : 0;
	}

	public TimeSpan GetTimeUntilRaidReset(string playerId)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		DateTimeOffset? val = default(DateTimeOffset?);
		TimeSpan result;
		if (IsPlayerRaidHourExpired(playerId) || !PlayerRaidHourStarts.TryGetValue(playerId, ref val) || !val.HasValue)
		{
			result = TimeSpan.Zero;
		}
		else
		{
			DateTimeOffset value = val.Value;
			result = ((DateTimeOffset)(ref value)).AddHours(1.0) - DateTimeOffset.UtcNow;
		}
		return result;
	}

	public string NextRaidDisplay(string playerId)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (GetEffectiveRaidCount(playerId) < 1)
		{
			return "Ready!";
		}
		TimeSpan timeUntilRaidReset = GetTimeUntilRaidReset(playerId);
		if (((TimeSpan)(ref timeUntilRaidReset)).TotalMinutes < 1.0)
		{
			return "< 1 min";
		}
		if (!(((TimeSpan)(ref timeUntilRaidReset)).TotalMinutes < 60.0))
		{
			return $"{(int)((TimeSpan)(ref timeUntilRaidReset)).TotalHours}h {((TimeSpan)(ref timeUntilRaidReset)).Minutes}m";
		}
		return $"{(int)((TimeSpan)(ref timeUntilRaidReset)).TotalMinutes} min";
	}
}
