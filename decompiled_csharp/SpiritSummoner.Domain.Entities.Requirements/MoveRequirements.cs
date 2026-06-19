using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Domain.Entities.Requirements;

public class MoveRequirements
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsFree
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? RequiredItem
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int RequiredItemCount
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int PlayerLevelRequired
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int SpiritLevelRequired
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public MoveRequirements()
	{
	}

	public MoveRequirements(bool isFree, string? requiredItem, int requiredItemCount, int playerLevelRequired, int spiritLevelRequired = 0)
	{
		IsFree = isFree;
		RequiredItem = requiredItem;
		RequiredItemCount = requiredItemCount;
		PlayerLevelRequired = playerLevelRequired;
		SpiritLevelRequired = spiritLevelRequired;
	}

	public static string GetCrystalRequirement(int power)
	{
		if (1 == 0)
		{
		}
		string result = ((power <= 120) ? ((power > 115) ? "greenCrystal" : "blueCrystal") : ((power > 125) ? "redCrystal" : "goldCrystal"));
		if (1 == 0)
		{
		}
		return result;
	}
}
