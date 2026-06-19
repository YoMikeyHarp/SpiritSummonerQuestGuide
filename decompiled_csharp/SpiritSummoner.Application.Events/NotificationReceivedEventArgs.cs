using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Application.DTOs.Session;

namespace SpiritSummoner.Application.Events;

public class NotificationReceivedEventArgs : EventArgs
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public PlayerNotificationDTO Notification
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = null;

}
