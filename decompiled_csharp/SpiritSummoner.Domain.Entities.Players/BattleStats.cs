using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Domain.Entities.Players;

public class BattleStats
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Wins
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Losses
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Score
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string Title
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = "Novice";


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset? LastScoreUpdate
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	internal void SetScore(int score)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		Score = Math.Max(0, score);
		LastScoreUpdate = DateTimeOffset.UtcNow;
	}

	internal void SetTitle(string title)
	{
		Title = title;
	}

	internal void IncrementWins()
	{
		Wins++;
	}

	internal void IncrementLosses()
	{
		Losses++;
	}

	internal void DecrementLosses()
	{
		Losses = Math.Max(0, Losses - 1);
	}

	public static BattleStats Rehydrate(int wins, int losses, int score, string title, DateTimeOffset? lastScoreUpdate)
	{
		return new BattleStats
		{
			Wins = wins,
			Losses = losses,
			Score = score,
			Title = title,
			LastScoreUpdate = lastScoreUpdate
		};
	}
}
