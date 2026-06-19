using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.Maui.ApplicationModel;

namespace SpiritSummoner.Application.Services;

public class ChatUnreadService : IChatUnreadService
{
	private int _friendRequestCount;

	private int _guildUnreadCount;

	private int _unreadNotificationCount;

	private int _dmUnreadCount;

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private EventHandler? m_UnreadCountChanged;

	public int TotalUnreadCount => _friendRequestCount + _guildUnreadCount + _unreadNotificationCount + _dmUnreadCount;

	public bool HasUnread => TotalUnreadCount > 0;

	public int UnreadNotificationCount => _unreadNotificationCount;

	public event EventHandler UnreadCountChanged
	{
		[CompilerGenerated]
		add
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			EventHandler val = this.m_UnreadCountChanged;
			EventHandler val2;
			do
			{
				val2 = val;
				EventHandler val3 = (EventHandler)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler>(ref this.m_UnreadCountChanged, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			EventHandler val = this.m_UnreadCountChanged;
			EventHandler val2;
			do
			{
				val2 = val;
				EventHandler val3 = (EventHandler)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler>(ref this.m_UnreadCountChanged, val3, val2);
			}
			while (val != val2);
		}
	}

	public void SetFriendRequestCount(int count)
	{
		if (_friendRequestCount != count)
		{
			_friendRequestCount = count;
			Notify();
		}
	}

	public void RecordNewGuildMessage()
	{
		_guildUnreadCount++;
		Notify();
	}

	public void MarkGuildChatAsRead()
	{
		if (_guildUnreadCount != 0)
		{
			_guildUnreadCount = 0;
			Notify();
		}
	}

	public void SetUnreadNotificationCount(int count)
	{
		if (_unreadNotificationCount != count)
		{
			_unreadNotificationCount = count;
			Notify();
		}
	}

	public void SetUnreadDMCount(int count)
	{
		if (_dmUnreadCount != count)
		{
			_dmUnreadCount = count;
			Notify();
		}
	}

	public void MarkDMsAsRead()
	{
		if (_dmUnreadCount != 0)
		{
			_dmUnreadCount = 0;
			Notify();
		}
	}

	private void Notify()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		MainThread.BeginInvokeOnMainThread((Action)([CompilerGenerated] () =>
		{
			EventHandler? unreadCountChanged = this.UnreadCountChanged;
			if (unreadCountChanged != null)
			{
				unreadCountChanged.Invoke((object)this, EventArgs.Empty);
			}
		}));
	}
}
