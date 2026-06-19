using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Application.BatchUpdates;

public class MoveStateUpdate
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string MoveName
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


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

	public MoveStateUpdate()
	{
	}

	public MoveStateUpdate(string moveName, bool isActive, bool isUnlocked)
	{
		MoveName = moveName;
		IsActiveMove = isActive;
		IsUnlocked = isUnlocked;
	}
}
