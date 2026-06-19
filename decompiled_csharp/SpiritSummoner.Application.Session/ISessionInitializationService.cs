using System;
using System.Threading.Tasks;

namespace SpiritSummoner.Application.Session;

public interface ISessionInitializationService
{
	bool IsInitialized { get; }

	event EventHandler StaticDataLoaded;

	global::System.Threading.Tasks.Task InitializeStaticDataAsync();

	global::System.Threading.Tasks.Task InitializeNotificationListenerAsync(string playerId);

	void WireUpNotificationProcessor();

	void InvalidateCache();
}
