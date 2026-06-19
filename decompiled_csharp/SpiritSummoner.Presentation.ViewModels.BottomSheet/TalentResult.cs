using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Presentation.ViewModels.BottomSheet;

public class TalentResult
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

	public static TalentResult Cancel => new TalentResult
	{
		Success = false
	};

	public static TalentResult GoToShop => new TalentResult
	{
		Success = false,
		NewItemId = "SHOP"
	};
}
