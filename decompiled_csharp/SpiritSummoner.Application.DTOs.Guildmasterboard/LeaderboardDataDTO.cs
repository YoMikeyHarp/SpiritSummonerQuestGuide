using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Application.DTOs.Guildmasterboard;

public class LeaderboardDataDTO
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<LeaderboardEntryDTO> TopPlayers
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<LeaderboardEntryDTO>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<LeaderboardEntryDTO> NearbyPlayers
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<LeaderboardEntryDTO>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public LeaderboardEntryDTO? CurrentPlayer
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsPlayerUnranked
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset LastRefreshed
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}
}
