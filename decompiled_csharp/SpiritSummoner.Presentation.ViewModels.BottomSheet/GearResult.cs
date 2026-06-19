using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Presentation.ViewModels.BottomSheet;

public class GearResult
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool Success
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? NewItemId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool Unequipped
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public static GearResult Cancel => new GearResult
	{
		Success = false
	};

	public static GearResult GoToShop => new GearResult
	{
		Success = false,
		NewItemId = "SHOP"
	};
}
