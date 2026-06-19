using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Application.BatchUpdates;

[AttributeUsage(/*Could not decode attribute arguments.*/)]
public class MergeStrategyAttribute : global::System.Attribute
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public MergeType Strategy
	{
		[CompilerGenerated]
		get;
	}

	public MergeStrategyAttribute(MergeType strategy)
	{
		Strategy = strategy;
	}
}
