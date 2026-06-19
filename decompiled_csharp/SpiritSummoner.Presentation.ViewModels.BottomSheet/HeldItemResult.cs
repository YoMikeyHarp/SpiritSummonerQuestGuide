using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Presentation.ViewModels.BottomSheet;

public class HeldItemResult
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

	public static HeldItemResult Cancel => new HeldItemResult
	{
		Success = false
	};

	public static HeldItemResult GoToShop => new HeldItemResult
	{
		Success = false,
		NewItemId = "SHOP"
	};
}
