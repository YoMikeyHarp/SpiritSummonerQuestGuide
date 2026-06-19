using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Microsoft.Maui.Graphics;
using SpiritSummoner.Domain.Enums.Spirits;

namespace SpiritSummoner.Presentation.Models;

public class MoveEditableState : ObservableObject
{
	[ObservableProperty]
	[NotifyPropertyChangedFor("HasChanges")]
	[NotifyPropertyChangedFor("Stroke")]
	[NotifyPropertyChangedFor("BackgroundColor")]
	private bool _isUnlocked;

	[ObservableProperty]
	[NotifyPropertyChangedFor("HasChanges")]
	[NotifyPropertyChangedFor("BackgroundColor")]
	private bool _isActive;

	private readonly bool _originalIsUnlocked;

	private readonly bool _originalIsActive;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string MoveId
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public SpiritType Type
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public MoveType MoveType
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Power
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsBasicMove
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int SpiritLevelRequired
	{
		[CompilerGenerated]
		get;
	}

	public Color Stroke => IsUnlocked ? Color.FromArgb("#000000BF") : Colors.White;

	public Color BackgroundColor => (IsActive && IsUnlocked) ? Colors.Transparent : Colors.DimGray;

	public bool HasChanges => IsUnlocked != _originalIsUnlocked || IsActive != _originalIsActive;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsUnlocked
	{
		get
		{
			return _isUnlocked;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isUnlocked, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsUnlocked);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasChanges);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Stroke);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.BackgroundColor);
				_isUnlocked = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsUnlocked);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasChanges);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Stroke);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.BackgroundColor);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsActive
	{
		get
		{
			return _isActive;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isActive, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsActive);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasChanges);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.BackgroundColor);
				_isActive = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsActive);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasChanges);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.BackgroundColor);
			}
		}
	}

	public MoveEditableState(string moveId, bool isUnlocked, bool isActive, SpiritType type, MoveType moveType, int power, bool isBasicMove = false, int spiritLevelRequired = 0)
	{
		MoveId = moveId;
		_isUnlocked = isUnlocked;
		_isActive = isActive;
		Type = type;
		Power = power;
		MoveType = moveType;
		IsBasicMove = isBasicMove;
		SpiritLevelRequired = spiritLevelRequired;
		_originalIsUnlocked = isUnlocked;
		_originalIsActive = isActive;
	}

	public void ResetToOriginal()
	{
		IsUnlocked = _originalIsUnlocked;
		IsActive = _originalIsActive;
	}
}
