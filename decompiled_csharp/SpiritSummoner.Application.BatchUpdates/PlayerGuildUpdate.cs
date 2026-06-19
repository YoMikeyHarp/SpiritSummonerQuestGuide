using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Application.BatchUpdates;

public class PlayerGuildUpdate
{
	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? GuildRole
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? GuildId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? TargetPlayerId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset? GuildJoinedAt
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public bool HasUpdates()
	{
		return GuildRole != null || GuildId != null || TargetPlayerId != null || GuildJoinedAt.HasValue;
	}
}
