using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Domain.Entities.Items;

namespace SpiritSummoner.Domain.ValueObjects.Quests;

public class Rewards
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Experience
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Gold
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Reputation
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<Item> Items
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<Item>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<string> ItemIds
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<string>();

}
