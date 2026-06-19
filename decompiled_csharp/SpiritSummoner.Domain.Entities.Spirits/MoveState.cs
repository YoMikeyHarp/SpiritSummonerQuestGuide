using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Domain.Entities.Spirits;

public class MoveState
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsActiveMove
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsUnlocked
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public MoveState()
	{
	}

	public MoveState(bool isActive, bool isUnlocked)
	{
		IsActiveMove = isActive;
		IsUnlocked = isUnlocked;
	}

	public MoveState(MoveState originalMoveState)
	{
		IsActiveMove = originalMoveState.IsActiveMove;
		IsUnlocked = originalMoveState.IsUnlocked;
	}
}
