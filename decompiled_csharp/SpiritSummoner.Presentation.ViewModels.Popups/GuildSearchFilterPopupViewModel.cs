using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using SpiritSummoner.Presentation.ViewModels.Guilds;

namespace SpiritSummoner.Presentation.ViewModels.Popups;

public class GuildSearchFilterPopupViewModel : ObservableObject
{
	[ObservableProperty]
	private GuildSearchFilters _currentFilters = new GuildSearchFilters();

	[ObservableProperty]
	private int? _minMembers;

	[ObservableProperty]
	private int? _maxMembers = 50;

	[ObservableProperty]
	private int? _minTrophies;

	[ObservableProperty]
	private int? _maxTrophies;

	[ObservableProperty]
	private string? _guildTypeFilter;

	[ObservableProperty]
	private int? _minLevel;

	[ObservableProperty]
	private int? _maxLevel;

	[ObservableProperty]
	private bool _showOnlyJoinable = true;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? applyFiltersMethodCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? clearFiltersCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<string>? setGuildTypeCommand;

	public bool HasActiveFilters => MinMembers.HasValue || MaxMembers.HasValue || MinTrophies.HasValue || MaxTrophies.HasValue || !string.IsNullOrEmpty(GuildTypeFilter) || MinLevel.HasValue || MaxLevel.HasValue;

	public string ActiveFilterCount => HasActiveFilters ? $"{CountActiveFilters()} active" : "No filters";

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public GuildSearchFilters CurrentFilters
	{
		get
		{
			return _currentFilters;
		}
		[MemberNotNull("_currentFilters")]
		set
		{
			if (!EqualityComparer<GuildSearchFilters>.Default.Equals(_currentFilters, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentFilters);
				_currentFilters = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentFilters);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int? MinMembers
	{
		get
		{
			return _minMembers;
		}
		set
		{
			if (!EqualityComparer<int?>.Default.Equals(_minMembers, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.MinMembers);
				_minMembers = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MinMembers);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int? MaxMembers
	{
		get
		{
			return _maxMembers;
		}
		set
		{
			if (!EqualityComparer<int?>.Default.Equals(_maxMembers, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.MaxMembers);
				_maxMembers = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MaxMembers);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int? MinTrophies
	{
		get
		{
			return _minTrophies;
		}
		set
		{
			if (!EqualityComparer<int?>.Default.Equals(_minTrophies, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.MinTrophies);
				_minTrophies = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MinTrophies);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int? MaxTrophies
	{
		get
		{
			return _maxTrophies;
		}
		set
		{
			if (!EqualityComparer<int?>.Default.Equals(_maxTrophies, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.MaxTrophies);
				_maxTrophies = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MaxTrophies);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? GuildTypeFilter
	{
		get
		{
			return _guildTypeFilter;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_guildTypeFilter, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.GuildTypeFilter);
				_guildTypeFilter = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.GuildTypeFilter);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int? MinLevel
	{
		get
		{
			return _minLevel;
		}
		set
		{
			if (!EqualityComparer<int?>.Default.Equals(_minLevel, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.MinLevel);
				_minLevel = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MinLevel);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int? MaxLevel
	{
		get
		{
			return _maxLevel;
		}
		set
		{
			if (!EqualityComparer<int?>.Default.Equals(_maxLevel, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.MaxLevel);
				_maxLevel = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MaxLevel);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowOnlyJoinable
	{
		get
		{
			return _showOnlyJoinable;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showOnlyJoinable, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowOnlyJoinable);
				_showOnlyJoinable = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowOnlyJoinable);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ApplyFiltersMethodCommand
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			RelayCommand obj = applyFiltersMethodCommand;
			if (obj == null)
			{
				RelayCommand val = new RelayCommand(new Action(ApplyFiltersMethod));
				RelayCommand val2 = val;
				applyFiltersMethodCommand = val;
				obj = val2;
			}
			return (IRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ClearFiltersCommand
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			RelayCommand obj = clearFiltersCommand;
			if (obj == null)
			{
				RelayCommand val = new RelayCommand(new Action(ClearFilters));
				RelayCommand val2 = val;
				clearFiltersCommand = val;
				obj = val2;
			}
			return (IRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<string> SetGuildTypeCommand => (IRelayCommand<string>)(object)(setGuildTypeCommand ?? (setGuildTypeCommand = new RelayCommand<string>((Action<string>)SetGuildType)));

	public void LoadFilters(GuildSearchFilters filters)
	{
		CurrentFilters = filters;
		MinMembers = filters.MinMembers;
		MaxMembers = filters.MaxMembers;
		MinTrophies = filters.MinTrophies;
		MaxTrophies = filters.MaxTrophies;
		MinLevel = filters.MinLevel;
		MaxLevel = filters.MaxLevel;
		if (filters.IsPublic.HasValue)
		{
			GuildTypeFilter = (filters.IsPublic.Value ? "public" : "invite");
		}
		else
		{
			GuildTypeFilter = "all";
		}
	}

	[RelayCommand]
	private void ApplyFiltersMethod()
	{
		ApplyFilters();
	}

	public GuildSearchFilters ApplyFilters()
	{
		GuildSearchFilters guildSearchFilters = new GuildSearchFilters
		{
			MinMembers = MinMembers,
			MaxMembers = MaxMembers,
			MinTrophies = MinTrophies,
			MaxTrophies = MaxTrophies,
			MinLevel = MinLevel,
			MaxLevel = MaxLevel
		};
		if (!string.IsNullOrEmpty(GuildTypeFilter) && GuildTypeFilter != "all")
		{
			guildSearchFilters.IsPublic = GuildTypeFilter == "public";
		}
		return guildSearchFilters;
	}

	[RelayCommand]
	public void ClearFilters()
	{
		MinMembers = null;
		MaxMembers = null;
		MinTrophies = null;
		MaxTrophies = null;
		MinLevel = null;
		MaxLevel = null;
		GuildTypeFilter = "all";
		ShowOnlyJoinable = true;
	}

	[RelayCommand]
	public void SetGuildType(string type)
	{
		GuildTypeFilter = type;
	}

	private int CountActiveFilters()
	{
		int num = 0;
		if (MinMembers.HasValue)
		{
			num++;
		}
		if (MaxMembers.HasValue && MaxMembers.GetValueOrDefault() != 50)
		{
			num++;
		}
		if (MinTrophies.HasValue)
		{
			num++;
		}
		if (MaxTrophies.HasValue)
		{
			num++;
		}
		if (MinLevel.HasValue)
		{
			num++;
		}
		if (MaxLevel.HasValue)
		{
			num++;
		}
		if (!string.IsNullOrEmpty(GuildTypeFilter) && GuildTypeFilter != "all")
		{
			num++;
		}
		return num;
	}
}
