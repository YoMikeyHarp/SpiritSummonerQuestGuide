using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Domain.Enums.Guilds;

namespace SpiritSummoner.Domain.Entities.Guilds;

public class GuildMember
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string PlayerId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string PlayerName
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public GuildRole Role
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = GuildRole.Member;


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
	public int Trophies
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Contribution
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int WeeklyContribution
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset JoinedAt
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset LastActiveAt
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsOnline
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? PlayerIcon
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public bool HasIcon => !string.IsNullOrEmpty(PlayerIcon);

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<string> DefenseSquad
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<string>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset? DefenseExpiresAt
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public bool IsDefenseActive => DefenseExpiresAt.HasValue && DefenseExpiresAt.Value > DateTimeOffset.UtcNow;

	public string RoleDisplay => ((object)Role).ToString().Replace('_', ' ');

	public string LevelDisplay => $"Lvl {Level}";

	public TimeSpan TimeSinceJoined => DateTimeOffset.op_Implicit(global::System.DateTime.UtcNow) - JoinedAt;

	public TimeSpan TimeSinceActive => DateTimeOffset.op_Implicit(global::System.DateTime.UtcNow) - LastActiveAt;

	public bool IsActiveToday
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			TimeSpan timeSinceActive = TimeSinceActive;
			return ((TimeSpan)(ref timeSinceActive)).TotalHours < 24.0;
		}
	}

	public bool IsActiveThisWeek
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			TimeSpan timeSinceActive = TimeSinceActive;
			return ((TimeSpan)(ref timeSinceActive)).TotalDays < 7.0;
		}
	}

	public bool CanBePromoted => Role != GuildRole.Guildmaster;

	public bool CanBeDemoted => Role != GuildRole.Member;

	public bool IsLeader => Role == GuildRole.Guildmaster;

	public bool HasOfficerPermissions => Role >= GuildRole.Officer;

	public GuildRole GetPromotedRole()
	{
		GuildRole role = Role;
		if (1 == 0)
		{
		}
		GuildRole result = role switch
		{
			GuildRole.Member => GuildRole.Officer, 
			GuildRole.Officer => GuildRole.Vice_Guildmaster, 
			GuildRole.Vice_Guildmaster => GuildRole.Guildmaster, 
			GuildRole.Guildmaster => GuildRole.Guildmaster, 
			_ => Role, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public GuildRole GetDemotedRole()
	{
		GuildRole role = Role;
		if (1 == 0)
		{
		}
		GuildRole result = role switch
		{
			GuildRole.Guildmaster => GuildRole.Vice_Guildmaster, 
			GuildRole.Vice_Guildmaster => GuildRole.Officer, 
			GuildRole.Officer => GuildRole.Member, 
			GuildRole.Member => GuildRole.Member, 
			_ => Role, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static GuildMember Rehydrate(string playerId, string playerName, GuildRole role, int level, int trophies, int contribution, int weeklyContribution, DateTimeOffset joinedAt, DateTimeOffset lastActiveAt, bool isOnline, List<string>? defenseSquad = null, DateTimeOffset? defenseExpiresAt = null, string? playerIcon = null)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		return new GuildMember
		{
			PlayerId = playerId,
			PlayerName = playerName,
			Role = role,
			Level = level,
			Trophies = trophies,
			Contribution = contribution,
			WeeklyContribution = weeklyContribution,
			JoinedAt = joinedAt,
			LastActiveAt = lastActiveAt,
			IsOnline = isOnline,
			DefenseSquad = (defenseSquad ?? new List<string>()),
			DefenseExpiresAt = defenseExpiresAt,
			PlayerIcon = playerIcon
		};
	}
}
