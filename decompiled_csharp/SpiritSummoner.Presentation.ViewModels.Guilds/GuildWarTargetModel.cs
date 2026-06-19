using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;

namespace SpiritSummoner.Presentation.ViewModels.Guilds;

public class GuildWarTargetModel : ObservableObject
{
	[ObservableProperty]
	private int _availableDefenders;

	[ObservableProperty]
	private bool _isInGuildBreak;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string Id
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string Name
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string Emblem
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = "\ud83d\udc51";


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Level
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Trophies
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public bool CanRaid => AvailableDefenders == 0;

	public string StatusText => IsInGuildBreak ? "Guild Break — Raid!" : ((AvailableDefenders > 0) ? $"{AvailableDefenders} defender(s)" : "Defenders down — Raid!");

	public string ActionText => CanRaid ? "\ud83d\udc8e RAID" : "⚔ BATTLE";

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int AvailableDefenders
	{
		get
		{
			return _availableDefenders;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_availableDefenders, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.AvailableDefenders);
				_availableDefenders = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.AvailableDefenders);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsInGuildBreak
	{
		get
		{
			return _isInGuildBreak;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isInGuildBreak, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsInGuildBreak);
				_isInGuildBreak = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsInGuildBreak);
			}
		}
	}
}
