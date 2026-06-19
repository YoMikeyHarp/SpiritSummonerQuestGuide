using System;

namespace SpiritSummoner.Infrastructure.FirebaseListeners;

public interface IAppVersionListenerService
{
	event EventHandler UpdateRequired;

	void StartListening();

	void StopListening();
}
