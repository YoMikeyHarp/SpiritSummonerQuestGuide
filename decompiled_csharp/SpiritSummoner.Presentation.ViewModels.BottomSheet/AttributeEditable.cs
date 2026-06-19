using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Microsoft.Maui.Graphics;
using SpiritSummoner.Presentation.Utilities;

namespace SpiritSummoner.Presentation.ViewModels.BottomSheet;

public class AttributeEditable : ObservableObject
{
	[ObservableProperty]
	[NotifyPropertyChangedFor("CurrentValue")]
	[NotifyPropertyChangedFor("CurrentValueColor")]
	[NotifyPropertyChangedFor("HasChanges")]
	private int _points;

	[ObservableProperty]
	private TouchState _currentTouchState = TouchState.Default;

	private readonly int _originalPoints;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string Name
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int BaseValue
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
	public double Bonus
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public float ItemFlatBuff
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public double ItemMultiplier
	{
		[CompilerGenerated]
		get;
	}

	public int CurrentValue => AttributeProgressCalculator.ComputeFinalValue(BaseValue, Points, Bonus, ItemFlatBuff, ItemMultiplier);

	public Color CurrentValueColor => HasChanges ? Colors.Yellow : Colors.White;

	public bool HasChanges => Points != _originalPoints;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int Points
	{
		get
		{
			return _points;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_points, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Points);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentValue);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentValueColor);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasChanges);
				_points = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Points);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentValue);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentValueColor);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasChanges);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public TouchState CurrentTouchState
	{
		get
		{
			return _currentTouchState;
		}
		set
		{
			if (!EqualityComparer<TouchState>.Default.Equals(_currentTouchState, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentTouchState);
				_currentTouchState = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentTouchState);
			}
		}
	}

	public AttributeEditable(string name, int baseValue, int points, double bonus, string description, float itemFlatBuff = 0f, double itemMultiplier = 1.0)
	{
		Name = name;
		BaseValue = baseValue;
		Description = description;
		_points = points;
		_originalPoints = points;
		Bonus = bonus;
		ItemFlatBuff = itemFlatBuff;
		ItemMultiplier = itemMultiplier;
	}
}
