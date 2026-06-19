using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Domain.ValueObjects.Quests;

public class QuestParagraph
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Image
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Text
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool View
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = false;

}
