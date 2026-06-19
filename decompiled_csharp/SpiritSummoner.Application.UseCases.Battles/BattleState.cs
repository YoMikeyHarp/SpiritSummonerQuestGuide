using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Domain.Enums.Battles;
using SpiritSummoner.Domain.ValueObjects.Battle;

namespace SpiritSummoner.Application.UseCases.Battles;

public class BattleState
{
	public const int FatigueStartTurn = 10;

	private const float FatiguePerTurn = 0.1f;

	private const float MaxDamageBonus = 2f;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public BattleMode BattleMode
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int CurrentTurn
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int ActivePlayerSpiritIndex
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int ActiveOpponentSpiritIndex
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsPlayerTurn
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool BattleEnded
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool PlayerVictory
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? QuestTaskId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int CurrentQuestStep
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? ChallengerBackgroundImage
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? ChallengerName
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? ChallengerGuildName
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<BattleSprite> PlayerBattleSprites
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<BattleSprite>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<BattleSprite> OpponentBattleSprites
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<BattleSprite>();


	public BattleSprite? ActivePlayerSprite => (ActivePlayerSpiritIndex >= 0 && ActivePlayerSpiritIndex < PlayerBattleSprites.Count) ? PlayerBattleSprites[ActivePlayerSpiritIndex] : null;

	public BattleSprite? ActiveOpponentSprite => (ActiveOpponentSpiritIndex >= 0 && ActiveOpponentSpiritIndex < OpponentBattleSprites.Count) ? OpponentBattleSprites[ActiveOpponentSpiritIndex] : null;

	private int FatigueTurns => Math.Max(0, CurrentTurn - 10);

	public float FatigueDamageMultiplier => 1f + Math.Min(2f, (float)FatigueTurns * 0.1f);

	public float FatigueHealMultiplier => Math.Max(0f, 1f - (float)FatigueTurns * 0.1f);

	public float FatigueEvasionMultiplier => Math.Max(0f, 1f - (float)FatigueTurns * 0.1f);
}
