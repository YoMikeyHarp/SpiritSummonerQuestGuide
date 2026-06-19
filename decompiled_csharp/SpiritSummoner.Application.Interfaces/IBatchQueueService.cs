using System;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;

namespace SpiritSummoner.Application.Interfaces;

public interface IBatchQueueService
{
	bool HasPendingUpdates { get; }

	SyncStatus CurrentSyncStatus { get; }

	event EventHandler<int> PendingUpdatesChanged;

	event EventHandler<SyncStatus> SyncStatusChanged;

	event EventHandler<string> ReconciliationRequired;

	global::System.Threading.Tasks.Task InitializeAsync();

	global::System.Threading.Tasks.Task WaitUntilInitializedAsync();

	void QueueUpdate(PlayerBatchUpdate update, bool forceSyncNow = false);

	global::System.Threading.Tasks.Task FlushQueueAsync();

	global::System.Threading.Tasks.Task FlushOnlineActionAsync();
}
