using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Domain.Repositories;

public class LeaderboardEntry
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
	public int PlayerLevel
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Score
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string Title
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = "Novice";


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Wins
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Losses
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset LastUpdated
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public static LeaderboardEntry FromPlayer(Player player)
	{
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		return new LeaderboardEntry
		{
			PlayerId = (player.PlayerID ?? string.Empty),
			PlayerName = (player.Playername ?? "Unknown"),
			PlayerLevel = player.PlayerLevel,
			Score = player.BattleStats.Score,
			Title = (player.BattleStats.Title ?? "Novice"),
			Wins = player.BattleStats.Wins,
			Losses = player.BattleStats.Losses,
			LastUpdated = (DateTimeOffset)(((_003F?)player.BattleStats.LastScoreUpdate) ?? DateTimeOffset.UtcNow)
		};
	}
}
