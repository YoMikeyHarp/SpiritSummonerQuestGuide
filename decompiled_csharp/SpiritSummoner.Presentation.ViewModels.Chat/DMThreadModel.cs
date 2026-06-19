using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace SpiritSummoner.Presentation.ViewModels.Chat;

public class DMThreadModel : ObservableObject
{
	[ObservableProperty]
	private string _conversationId = string.Empty;

	[ObservableProperty]
	private string _playerId = string.Empty;

	[ObservableProperty]
	private string _playerName = string.Empty;

	[ObservableProperty]
	private string _icon = string.Empty;

	[ObservableProperty]
	[NotifyPropertyChangedFor("OnlineStatusColor")]
	private DateTimeOffset _lastOnlineAt;

	[ObservableProperty]
	[NotifyPropertyChangedFor("HasMessages")]
	private string _lastMessagePreviewText = string.Empty;

	[ObservableProperty]
	private DateTimeOffset _lastMessageAt;

	[ObservableProperty]
	[NotifyPropertyChangedFor("Background")]
	private bool _isRead;

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

	public Brush Background
	{
		get
		{
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			//IL_0045: Expected O, but got Unknown
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Expected O, but got Unknown
			//IL_0060: Expected O, but got Unknown
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Expected O, but got Unknown
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Expected O, but got Unknown
			_003F val2;
			if (!IsRead)
			{
				GradientStopCollection val = new GradientStopCollection();
				((Collection<GradientStop>)val).Add(new GradientStop(Color.FromArgb("#F9F5C0"), 0f));
				((Collection<GradientStop>)val).Add(new GradientStop(Color.FromArgb("#F6F1A6"), 0.5f));
				((Collection<GradientStop>)val).Add(new GradientStop(Color.FromArgb("#D9D491"), 1f));
				val2 = new LinearGradientBrush(val, new Point(0.0, 0.0), new Point(1.0, 0.0));
			}
			else
			{
				val2 = new SolidColorBrush(Color.FromArgb("#EDF8EA"));
			}
			return (Brush)val2;
		}
	}

	public bool HasMessages => !string.IsNullOrEmpty(LastMessagePreviewText);

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string ConversationId
	{
		get
		{
			return _conversationId;
		}
		[MemberNotNull("_conversationId")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_conversationId, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ConversationId);
				_conversationId = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ConversationId);
			}
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
	public string Icon
	{
		get
		{
			return _icon;
		}
		[MemberNotNull("_icon")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_icon, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Icon);
				_icon = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Icon);
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
	public string LastMessagePreviewText
	{
		get
		{
			return _lastMessagePreviewText;
		}
		[MemberNotNull("_lastMessagePreviewText")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_lastMessagePreviewText, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.LastMessagePreviewText);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasMessages);
				_lastMessagePreviewText = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.LastMessagePreviewText);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasMessages);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public DateTimeOffset LastMessageAt
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _lastMessageAt;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			if (!EqualityComparer<DateTimeOffset>.Default.Equals(_lastMessageAt, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.LastMessageAt);
				_lastMessageAt = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.LastMessageAt);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsRead
	{
		get
		{
			return _isRead;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isRead, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsRead);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Background);
				_isRead = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsRead);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Background);
			}
		}
	}
}
