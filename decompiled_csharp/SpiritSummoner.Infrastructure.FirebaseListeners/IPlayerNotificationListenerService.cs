using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpiritSummoner.Application.DTOs.Session;
using SpiritSummoner.Application.Events;

namespace SpiritSummoner.Infrastructure.FirebaseListeners;

public interface IPlayerNotificationListenerService
{
	bool IsListening { get; }

	event EventHandler<NotificationReceivedEventArgs>? NotificationReceived;

	void StartListener(string playerId);

	void StopListener();

	global::System.Threading.Tasks.Task MarkAsReadAsync(string notificationId);

	global::System.Threading.Tasks.Task MarkAsAnswearedAsync(string notificationId);

	global::System.Threading.Tasks.Task<List<PlayerNotificationDTO>> GetUnreadNotificationsAsync(string playerId, int limit = 50);

	global::System.Threading.Tasks.Task<List<PlayerNotificationDTO>> GetUnAnswearedNotificationsAsync(string playerId, int limit = 50);

	global::System.Threading.Tasks.Task<List<PlayerNotificationDTO>> GetNotificationHistoryAsync(string playerId, int limit = 50);
}
