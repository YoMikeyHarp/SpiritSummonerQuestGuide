using System;

namespace SpiritSummoner.Application.Services;

public interface IChatUnreadService
{
	int TotalUnreadCount { get; }

	bool HasUnread { get; }

	int UnreadNotificationCount { get; }

	event EventHandler UnreadCountChanged;

	void SetFriendRequestCount(int count);

	void RecordNewGuildMessage();

	void MarkGuildChatAsRead();

	void SetUnreadNotificationCount(int count);

	void SetUnreadDMCount(int count);

	void MarkDMsAsRead();
}
