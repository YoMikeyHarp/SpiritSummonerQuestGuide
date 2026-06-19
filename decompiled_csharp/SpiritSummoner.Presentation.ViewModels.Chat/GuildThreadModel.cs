using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;

namespace SpiritSummoner.Presentation.ViewModels.Chat;

public class GuildThreadModel : ObservableObject
{
	[ObservableProperty]
	private string _conversationId = string.Empty;

	[ObservableProperty]
	private string _subject = string.Empty;

	[ObservableProperty]
	private string _icon = "\ud83d\udcac";

	[ObservableProperty]
	[NotifyPropertyChangedFor("HasMessages")]
	private string _lastMessageText = string.Empty;

	[ObservableProperty]
	[NotifyPropertyChangedFor("LastActiveDisplay")]
	private DateTimeOffset _lastMessageAt;

	public string LastActiveDisplay
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			if (LastMessageAt == DateTimeOffset.MinValue)
			{
				return string.Empty;
			}
			TimeSpan val = DateTimeOffset.UtcNow - LastMessageAt;
			if (((TimeSpan)(ref val)).TotalMinutes < 1.0)
			{
				return "just now";
			}
			if (!(((TimeSpan)(ref val)).TotalMinutes < 60.0))
			{
				if (!(((TimeSpan)(ref val)).TotalHours < 24.0))
				{
					return $"{(int)((TimeSpan)(ref val)).TotalDays}d ago";
				}
				return $"{(int)((TimeSpan)(ref val)).TotalHours}h ago";
			}
			return $"{(int)((TimeSpan)(ref val)).TotalMinutes}m ago";
		}
	}

	public bool HasMessages => !string.IsNullOrEmpty(LastMessageText);

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
	public string Subject
	{
		get
		{
			return _subject;
		}
		[MemberNotNull("_subject")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_subject, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Subject);
				_subject = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Subject);
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
	public string LastMessageText
	{
		get
		{
			return _lastMessageText;
		}
		[MemberNotNull("_lastMessageText")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_lastMessageText, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.LastMessageText);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasMessages);
				_lastMessageText = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.LastMessageText);
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
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			if (!EqualityComparer<DateTimeOffset>.Default.Equals(_lastMessageAt, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.LastMessageAt);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.LastActiveDisplay);
				_lastMessageAt = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.LastMessageAt);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.LastActiveDisplay);
			}
		}
	}
}
