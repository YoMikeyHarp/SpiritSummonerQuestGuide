using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Application.Enums;

namespace SpiritSummoner.Application.BatchUpdates;

public class PlayerSpiritFieldUpdate
{
	[MergeStrategy(MergeType.Ignore)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string SpiritId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public SpiritUpdateType UpdateType
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.AccumulateNullable)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? LevelChange
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.AccumulateNullable)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? HPChange
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.AccumulateNullable)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? TrainingPointsChange
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? SetPointsATK
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? SetPointsDEF
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? SetPointsSATK
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? SetPointsSDEF
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? SetPointsSPD
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? SetPointsINT
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? SetNickname
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool? SetFavorite
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? SetHeldItemId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? SetGearId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? SetTalentId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? SetBaseSpiritId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.LatestWins)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? SetName
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[MergeStrategy(MergeType.DictionaryReplace)]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, MoveStateUpdate>? MoveChanges
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}
}
