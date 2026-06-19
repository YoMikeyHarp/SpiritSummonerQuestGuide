using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Domain.Entities.Requirements;
using SpiritSummoner.Domain.Enums.Spirits;

namespace SpiritSummoner.Domain.Entities.Spirits;

public class Move
{
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
	public SpiritType Type
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Power
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public MoveType MoveType
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public MoveRequirements UnlockRequirements
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new MoveRequirements(isFree: false, null, 0, 0);


	public static Move Rehydrate(string name, SpiritType type, int power, MoveType moveType, MoveRequirements unlockRequirements)
	{
		return new Move
		{
			Name = name,
			Type = type,
			Power = power,
			MoveType = moveType,
			UnlockRequirements = unlockRequirements
		};
	}
}
