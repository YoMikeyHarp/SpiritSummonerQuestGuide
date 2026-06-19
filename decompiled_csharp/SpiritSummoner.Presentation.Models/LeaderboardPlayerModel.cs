using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;

namespace SpiritSummoner.Presentation.Models;

public class LeaderboardPlayerModel : ObservableObject
{
	[ObservableProperty]
	private string _playerId = string.Empty;

	[ObservableProperty]
	private string _playerName = string.Empty;

	[ObservableProperty]
	private int _playerLevel;

	[ObservableProperty]
	private int _score;

	[ObservableProperty]
	private int _rank;

	[ObservableProperty]
	private string _title = "Novice";

	[ObservableProperty]
	private int _wins;

	[ObservableProperty]
	private int _losses;

	[ObservableProperty]
	private bool _isCurrentPlayer;

	[ObservableProperty]
	private string _rankDisplay = string.Empty;

	public string WinLossRatio => (Wins + Losses > 0) ? $"{Wins}W / {Losses}L" : "0W / 0L";

	public string WinRate
	{
		get
		{
			int num = Wins + Losses;
			if (num == 0)
			{
				return "0%";
			}
			double num2 = (double)Wins / (double)num * 100.0;
			return $"{num2:F1}%";
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string PlayerId
	{
		get
		{
			return _playerId;
		}
		[MemberNotNull("_playerId")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_playerId, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PlayerId);
				_playerId = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PlayerId);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string PlayerName
	{
		get
		{
			return _playerName;
		}
		[MemberNotNull("_playerName")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_playerName, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PlayerName);
				_playerName = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PlayerName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int PlayerLevel
	{
		get
		{
			return _playerLevel;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_playerLevel, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PlayerLevel);
				_playerLevel = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PlayerLevel);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int Score
	{
		get
		{
			return _score;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_score, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Score);
				_score = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Score);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int Rank
	{
		get
		{
			return _rank;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_rank, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Rank);
				_rank = value;
				OnRankChanged(value);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Rank);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Title
	{
		get
		{
			return _title;
		}
		[MemberNotNull("_title")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_title, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Title);
				_title = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Title);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int Wins
	{
		get
		{
			return _wins;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_wins, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Wins);
				_wins = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Wins);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int Losses
	{
		get
		{
			return _losses;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_losses, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Losses);
				_losses = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Losses);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsCurrentPlayer
	{
		get
		{
			return _isCurrentPlayer;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isCurrentPlayer, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsCurrentPlayer);
				_isCurrentPlayer = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsCurrentPlayer);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string RankDisplay
	{
		get
		{
			return _rankDisplay;
		}
		[MemberNotNull("_rankDisplay")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_rankDisplay, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.RankDisplay);
				_rankDisplay = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.RankDisplay);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnRankChanged(int value)
	{
		RankDisplay = ((value > 0) ? $"#{value}" : "Unranked");
	}
}
