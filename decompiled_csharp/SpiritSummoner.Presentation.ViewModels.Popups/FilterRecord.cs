using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;

namespace SpiritSummoner.Presentation.ViewModels.Popups;

public class FilterRecord : ObservableObject
{
	[ObservableProperty]
	private bool _isChecked = false;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string Name
	{
		[CompilerGenerated]
		get;
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsChecked
	{
		get
		{
			return _isChecked;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isChecked, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsChecked);
				_isChecked = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsChecked);
			}
		}
	}

	public FilterRecord(string name)
	{
		Name = name;
	}

	public FilterRecord(string name, bool isChecked)
	{
		Name = name;
		IsChecked = isChecked;
	}
}
