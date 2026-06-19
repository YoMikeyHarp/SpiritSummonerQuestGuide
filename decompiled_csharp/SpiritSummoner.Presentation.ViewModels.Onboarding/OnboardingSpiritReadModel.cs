using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Application.Auth;

namespace SpiritSummoner.Presentation.ViewModels.Onboarding;

public class OnboardingSpiritReadModel
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string Name
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string Image
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string Description
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Level
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string Type1
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string Type2
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string TypesDisplay
	{
		[CompilerGenerated]
		get;
	}

	public OnboardingSpiritReadModel(StarterSpiritData data)
	{
		Name = data.Name;
		Image = data.Image;
		Description = data.Description;
		Level = data.Level;
		Type1 = data.Type1;
		Type2 = data.Type2;
		TypesDisplay = ((!string.IsNullOrEmpty(data.Type2) && data.Type2 != "None") ? (data.Type1 + " / " + data.Type2) : data.Type1);
	}
}
