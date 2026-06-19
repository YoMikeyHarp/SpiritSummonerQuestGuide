using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using SpiritSummoner.Domain.Enums.Guilds;

namespace SpiritSummoner.Domain.Entities.Guilds;

public class Guild
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? ID
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Name
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Description
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string Emblem
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = "\ud83d\udc51";


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Rank
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Level
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int CurrentXP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int XPForNextLevel
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? LeaderPlayerId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int MemberCount
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int MaxMembers
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = 20;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, GuildMember> Members
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, GuildMember>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Crystals
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

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
	public Dictionary<string, DefenderData> Defenders
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, DefenderData>();


	public global::System.Collections.Generic.IReadOnlyList<string> DefenderPlayerIds => (global::System.Collections.Generic.IReadOnlyList<string>)Enumerable.ToList<string>((global::System.Collections.Generic.IEnumerable<string>)Defenders.Keys);

	public global::System.Collections.Generic.IReadOnlyList<string> MainDefenderPlayerIds => (global::System.Collections.Generic.IReadOnlyList<string>)Enumerable.ToList<string>(Enumerable.Select<KeyValuePair<string, DefenderData>, string>(Enumerable.Where<KeyValuePair<string, DefenderData>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, DefenderData>>)Defenders, (Func<KeyValuePair<string, DefenderData>, bool>)((KeyValuePair<string, DefenderData> d) => d.Value.IsMainDefender)), (Func<KeyValuePair<string, DefenderData>, string>)((KeyValuePair<string, DefenderData> d) => d.Key)));

	public IReadOnlyDictionary<string, List<string>> DefenderSquads => (IReadOnlyDictionary<string, List<string>>)(object)Enumerable.ToDictionary<KeyValuePair<string, DefenderData>, string, List<string>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, DefenderData>>)Defenders, (Func<KeyValuePair<string, DefenderData>, string>)((KeyValuePair<string, DefenderData> d) => d.Key), (Func<KeyValuePair<string, DefenderData>, List<string>>)((KeyValuePair<string, DefenderData> d) => d.Value.SquadIds));

	public IReadOnlyDictionary<string, DateTimeOffset> DefenderSignUpTimestamps => (IReadOnlyDictionary<string, DateTimeOffset>)(object)Enumerable.ToDictionary<KeyValuePair<string, DefenderData>, string, DateTimeOffset>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, DefenderData>>)Defenders, (Func<KeyValuePair<string, DefenderData>, string>)((KeyValuePair<string, DefenderData> d) => d.Key), (Func<KeyValuePair<string, DefenderData>, DateTimeOffset>)((KeyValuePair<string, DefenderData> d) => d.Value.SignUpAt));

	public IReadOnlyDictionary<string, DateTimeOffset> DefenderExpiryTimestamps => (IReadOnlyDictionary<string, DateTimeOffset>)(object)Enumerable.ToDictionary<KeyValuePair<string, DefenderData>, string, DateTimeOffset>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, DefenderData>>)Defenders, (Func<KeyValuePair<string, DefenderData>, string>)((KeyValuePair<string, DefenderData> d) => d.Key), (Func<KeyValuePair<string, DefenderData>, DateTimeOffset>)((KeyValuePair<string, DefenderData> d) => d.Value.ExpiresAt));

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
	public string? CurrentWarId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsOpenToWar
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = false;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset? GuildBreakEndsAt
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Trophies
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int TotalWins
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int TotalLosses
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int GuildCoins
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, GuildActivePerk> ActivePerks
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, GuildActivePerk>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsPublic
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = true;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool RequiresApproval
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = false;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int MinLevelRequired
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = 1;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int MinTrophiesRequired
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = 0;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset CreatedAt
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset LastActivityAt
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset? DisbandScheduledAt
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public double WinRate => (TotalWins + TotalLosses > 0) ? ((double)TotalWins / (double)(TotalWins + TotalLosses) * 100.0) : 0.0;

	public int XPPercentage => (XPForNextLevel > 0) ? ((int)((double)CurrentXP / (double)XPForNextLevel * 100.0)) : 0;

	public bool IsFull => MemberCount >= MaxMembers;

	public bool IsDisbanding
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			int result;
			if (DisbandScheduledAt.HasValue)
			{
				DateTimeOffset? disbandScheduledAt = DisbandScheduledAt;
				DateTimeOffset utcNow = DateTimeOffset.UtcNow;
				result = ((disbandScheduledAt.HasValue && disbandScheduledAt.GetValueOrDefault() > utcNow) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}
	}

	public TimeSpan? TimeUntilDisband => IsDisbanding ? new TimeSpan?(DisbandScheduledAt.Value - DateTimeOffset.UtcNow) : null;

	public int DefenderCount => Defenders.Count;

	public int MaxDefenders => 20;

	public int MaxMainDefenders => 5;

	public bool HasActiveWarSeason => CurrentSeasonStartDate.HasValue && CurrentSeasonEndDate.HasValue && DateTimeOffset.UtcNow >= CurrentSeasonStartDate.Value && DateTimeOffset.UtcNow <= CurrentSeasonEndDate.Value;

	public bool IsInWarSeason => !string.IsNullOrEmpty(CurrentWarId);

	public bool CanBattle => HasActiveWarSeason && IsInWarSeason;

	public bool IsInGuildBreak => GuildBreakEndsAt.HasValue && GuildBreakEndsAt.Value > DateTimeOffset.UtcNow;

	public TimeSpan? TimeUntilSeasonEnd => CurrentSeasonEndDate.HasValue ? new TimeSpan?(CurrentSeasonEndDate.Value - DateTimeOffset.UtcNow) : null;

	public GuildActivePerk? GetActivePerk(GuildPerkType type)
	{
		GuildActivePerk guildActivePerk = default(GuildActivePerk);
		return ActivePerks.TryGetValue(((object)type).ToString(), ref guildActivePerk) ? guildActivePerk : null;
	}

	public List<GuildMember> GetActiveDefenders()
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		DateTimeOffset now = DateTimeOffset.UtcNow;
		DefenderData defenderData = default(DefenderData);
		return Enumerable.ToList<GuildMember>(Enumerable.Where<GuildMember>((global::System.Collections.Generic.IEnumerable<GuildMember>)Members.Values, (Func<GuildMember, bool>)((GuildMember m) => Defenders.TryGetValue(m.PlayerId, ref defenderData) && defenderData.ExpiresAt > now)));
	}

	public bool IsDefenderActive(string playerId)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		DefenderData defenderData = default(DefenderData);
		return Defenders.TryGetValue(playerId, ref defenderData) && defenderData.ExpiresAt > DateTimeOffset.UtcNow;
	}

	public bool IsDefenderInDowntime(string playerId)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		DefenderData defenderData = default(DefenderData);
		return Defenders.TryGetValue(playerId, ref defenderData) && defenderData.DowntimeEnds.HasValue && defenderData.DowntimeEnds.Value > DateTimeOffset.UtcNow;
	}

	public List<string> GetAvailableDefenderIds()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		DateTimeOffset now = DateTimeOffset.UtcNow;
		return Enumerable.ToList<string>(Enumerable.Select<KeyValuePair<string, DefenderData>, string>(Enumerable.Where<KeyValuePair<string, DefenderData>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, DefenderData>>)Defenders, (Func<KeyValuePair<string, DefenderData>, bool>)((KeyValuePair<string, DefenderData> kv) => kv.Value.ExpiresAt > now && (!kv.Value.DowntimeEnds.HasValue || !(kv.Value.DowntimeEnds.Value > now)))), (Func<KeyValuePair<string, DefenderData>, string>)((KeyValuePair<string, DefenderData> kv) => kv.Key)));
	}

	public static Guild Rehydrate(string? id, string? name, string? description, string emblem, int rank, int level, int currentXP, int xpForNextLevel, string? leaderPlayerId, int memberCount, int maxMembers, Dictionary<string, GuildMember>? members, int crystals, int startingCrystals, Dictionary<string, DefenderData>? defenders, DateTimeOffset? currentSeasonStartDate, DateTimeOffset? currentSeasonEndDate, string? currentWarId, bool isOpenToWar, DateTimeOffset? guildBreakEndsAt, int trophies, int totalWins, int totalLosses, int guildCoins, bool isPublic, bool requiresApproval, int minLevelRequired, int minTrophiesRequired, DateTimeOffset createdAt, DateTimeOffset lastActivityAt, DateTimeOffset? disbandScheduledAt = null, Dictionary<string, GuildActivePerk>? activePerks = null)
	{
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		return new Guild
		{
			ID = id,
			Name = name,
			Description = description,
			Emblem = emblem,
			Rank = rank,
			Level = level,
			CurrentXP = currentXP,
			XPForNextLevel = xpForNextLevel,
			LeaderPlayerId = leaderPlayerId,
			MemberCount = memberCount,
			MaxMembers = maxMembers,
			Members = (members ?? new Dictionary<string, GuildMember>()),
			Crystals = crystals,
			StartingCrystals = startingCrystals,
			Defenders = (defenders ?? new Dictionary<string, DefenderData>()),
			CurrentSeasonStartDate = currentSeasonStartDate,
			CurrentSeasonEndDate = currentSeasonEndDate,
			CurrentWarId = currentWarId,
			IsOpenToWar = isOpenToWar,
			GuildBreakEndsAt = guildBreakEndsAt,
			Trophies = trophies,
			TotalWins = totalWins,
			TotalLosses = totalLosses,
			GuildCoins = guildCoins,
			IsPublic = isPublic,
			RequiresApproval = requiresApproval,
			MinLevelRequired = minLevelRequired,
			MinTrophiesRequired = minTrophiesRequired,
			CreatedAt = createdAt,
			LastActivityAt = lastActivityAt,
			DisbandScheduledAt = disbandScheduledAt,
			ActivePerks = (activePerks ?? new Dictionary<string, GuildActivePerk>())
		};
	}
}
