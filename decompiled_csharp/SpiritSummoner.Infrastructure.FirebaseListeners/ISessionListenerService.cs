using System;

namespace SpiritSummoner.Infrastructure.FirebaseListeners;

public interface ISessionListenerService
{
	bool IsListening { get; }

	event EventHandler<SessionInvalidatedEventArgs>? SessionInvalidated;

	void StartListening(string playerId, string localSessionId);

	void StopListening();
}
