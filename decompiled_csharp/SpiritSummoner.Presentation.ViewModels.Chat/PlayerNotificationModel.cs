using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using SpiritSummoner.Domain.Enums.Common;

namespace SpiritSummoner.Presentation.ViewModels.Chat;

public class PlayerNotificationModel : ObservableObject
{
	private bool _isRead;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string Id
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public NotificationType Type
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string Icon
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string Title
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string Body
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset CreatedAt
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public bool IsRead
	{
		get
		{
			return _isRead;
		}
		set
		{
			if (((ObservableObject)this).SetProperty<bool>(ref _isRead, value, "IsRead"))
			{
				((ObservableObject)this).OnPropertyChanged("BackgroundColor");
			}
		}
	}

	public string BackgroundColor => _isRead ? "#1E1E1E" : "#242C1E";

	public string TimeDisplay
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			TimeSpan val = DateTimeOffset.UtcNow - CreatedAt;
			if (((TimeSpan)(ref val)).TotalMinutes < 1.0)
			{
				return "just now";
			}
			if (((TimeSpan)(ref val)).TotalMinutes < 60.0)
			{
				return $"{(int)((TimeSpan)(ref val)).TotalMinutes}m ago";
			}
			if (((TimeSpan)(ref val)).TotalHours < 24.0)
			{
				return $"{(int)((TimeSpan)(ref val)).TotalHours}h ago";
			}
			DateTimeOffset val2 = CreatedAt;
			val2 = ((DateTimeOffset)(ref val2)).ToLocalTime();
			return ((DateTimeOffset)(ref val2)).ToString("MMM d");
		}
	}
}
