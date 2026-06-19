using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Microsoft.Maui.Graphics;

namespace SpiritSummoner.Presentation.ViewModels.Popups;

public class IconOptionModel : ObservableObject
{
	[ObservableProperty]
	private string _fileName = string.Empty;

	[ObservableProperty]
	[NotifyPropertyChangedFor("BorderColor")]
	private bool _isSelected;

	public Color BorderColor => IsSelected ? Colors.Red : Colors.Transparent;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string FileName
	{
		get
		{
			return _fileName;
		}
		[MemberNotNull("_fileName")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_fileName, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.FileName);
				_fileName = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.FileName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsSelected
	{
		get
		{
			return _isSelected;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isSelected, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsSelected);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.BorderColor);
				_isSelected = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsSelected);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.BorderColor);
			}
		}
	}
}
