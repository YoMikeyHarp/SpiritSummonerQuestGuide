using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Domain.Entities.Items;

public class HPThresholdEffect
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public float Threshold
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool ActivatesBelowThreshold
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = true;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, float>? StatMultipliers
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public float DamageMultiplier
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = 1f;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public float HealPerTurn
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = 0f;

}
