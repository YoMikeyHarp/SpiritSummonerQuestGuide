using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Presentation.Models;

namespace SpiritSummoner.Presentation.ViewModels.Guilds;

public class GuildLevelPage
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Level
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsLocked
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public ObservableCollection<ItemModel> Items
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new ObservableCollection<ItemModel>();

}
