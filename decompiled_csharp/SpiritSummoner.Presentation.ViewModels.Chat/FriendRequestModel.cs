using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;

namespace SpiritSummoner.Presentation.ViewModels.Chat;

public class FriendRequestModel : ObservableObject
{
	[ObservableProperty]
	private string _notificationId = string.Empty;

	[ObservableProperty]
	private string _senderId = string.Empty;

	[ObservableProperty]
	private string _senderName = string.Empty;

	[ObservableProperty]
	private int _senderLevel;

	[ObservableProperty]
	private DateTimeOffset _receivedAt;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string NotificationId
	{
		get
		{
			return _notificationId;
		}
		[MemberNotNull("_notificationId")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_notificationId, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.NotificationId);
				_notificationId = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.NotificationId);
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
	public int SenderLevel
	{
		get
		{
			return _senderLevel;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_senderLevel, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SenderLevel);
				_senderLevel = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SenderLevel);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public DateTimeOffset ReceivedAt
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _receivedAt;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			if (!EqualityComparer<DateTimeOffset>.Default.Equals(_receivedAt, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ReceivedAt);
				_receivedAt = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ReceivedAt);
			}
		}
	}
}
