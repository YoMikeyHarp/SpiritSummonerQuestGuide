using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;

namespace SpiritSummoner.Presentation.ViewModels.Chat;

public class ChatPlayerModel : ObservableObject
{
	[ObservableProperty]
	private string _playerId = string.Empty;

	[ObservableProperty]
	private string _playerName = string.Empty;

	[ObservableProperty]
	private string _title = string.Empty;

	[ObservableProperty]
	private int _rank;

	[ObservableProperty]
	private DateTimeOffset _addedAt;

	[ObservableProperty]
	private int _unreadCount;

	[ObservableProperty]
	[NotifyPropertyChangedFor("OnlineStatusColor")]
	private DateTimeOffset _lastOnlineAt;

	[ObservableProperty]
	private string _playerIcon = string.Empty;

	public string OnlineStatusColor
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			if (LastOnlineAt == DateTimeOffset.MinValue)
			{
				return "#808080";
			}
			TimeSpan val = DateTimeOffset.UtcNow - LastOnlineAt;
			if (((TimeSpan)(ref val)).TotalMinutes <= 5.0)
			{
				return "#10B981";
			}
			if (((TimeSpan)(ref val)).TotalMinutes <= 60.0)
			{
				return "#F97316";
			}
			return "#808080";
		}
	}

	public bool Unread => UnreadCount > 0;

	public string UnreadCountDisplay => (UnreadCount > 9) ? "9+" : UnreadCount.ToString();

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
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Rank);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public DateTimeOffset AddedAt
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _addedAt;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			if (!EqualityComparer<DateTimeOffset>.Default.Equals(_addedAt, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.AddedAt);
				_addedAt = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.AddedAt);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int UnreadCount
	{
		get
		{
			return _unreadCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_unreadCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.UnreadCount);
				_unreadCount = value;
				OnUnreadCountChanged(value);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.UnreadCount);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public DateTimeOffset LastOnlineAt
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _lastOnlineAt;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			if (!EqualityComparer<DateTimeOffset>.Default.Equals(_lastOnlineAt, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.LastOnlineAt);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.OnlineStatusColor);
				_lastOnlineAt = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.LastOnlineAt);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.OnlineStatusColor);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string PlayerIcon
	{
		get
		{
			return _playerIcon;
		}
		[MemberNotNull("_playerIcon")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_playerIcon, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PlayerIcon);
				_playerIcon = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PlayerIcon);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnUnreadCountChanged(int value)
	{
		((ObservableObject)this).OnPropertyChanged("Unread");
		((ObservableObject)this).OnPropertyChanged("UnreadCountDisplay");
	}
}
