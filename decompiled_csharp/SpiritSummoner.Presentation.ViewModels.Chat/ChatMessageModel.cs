using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;

namespace SpiritSummoner.Presentation.ViewModels.Chat;

public class ChatMessageModel : ObservableObject
{
	[ObservableProperty]
	private string _id = string.Empty;

	[ObservableProperty]
	private string _senderId = string.Empty;

	[ObservableProperty]
	private string _senderName = string.Empty;

	[ObservableProperty]
	private string _content = string.Empty;

	[ObservableProperty]
	private DateTimeOffset _createdAt;

	[ObservableProperty]
	private bool _isCurrentPlayer;

	public string TimeDisplay
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			DateTimeOffset val = CreatedAt;
			val = ((DateTimeOffset)(ref val)).ToLocalTime();
			return ((DateTimeOffset)(ref val)).ToString("h:mm tt");
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Id
	{
		get
		{
			return _id;
		}
		[MemberNotNull("_id")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_id, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Id);
				_id = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Id);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string SenderId
	{
		get
		{
			return _senderId;
		}
		[MemberNotNull("_senderId")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_senderId, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SenderId);
				_senderId = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SenderId);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string SenderName
	{
		get
		{
			return _senderName;
		}
		[MemberNotNull("_senderName")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_senderName, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SenderName);
				_senderName = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SenderName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Content
	{
		get
		{
			return _content;
		}
		[MemberNotNull("_content")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_content, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Content);
				_content = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Content);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public DateTimeOffset CreatedAt
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _createdAt;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			if (!EqualityComparer<DateTimeOffset>.Default.Equals(_createdAt, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CreatedAt);
				_createdAt = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CreatedAt);
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
}
