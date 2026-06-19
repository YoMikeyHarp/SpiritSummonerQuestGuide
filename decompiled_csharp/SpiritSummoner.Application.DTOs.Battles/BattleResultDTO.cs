using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Application.DTOs.Battles;

public class BattleResultDTO
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool Victory
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int OpponentLevel
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsPvP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int LivingSpiritsCount
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public double TotalHealthPercentage
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? QuestTaskId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool QuestTaskCompleted
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int QuestTaskStep
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<SpiritBattleResult> PlayerSpirits
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = new List<SpiritBattleResult>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<SpiritBattleResult> EnemySpirits
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = new List<SpiritBattleResult>();

}
