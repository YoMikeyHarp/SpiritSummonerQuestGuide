using System;

namespace SpiritSummoner.Infrastructure.FirebaseListeners;

public interface IGuildListenerService
{
	bool IsListening { get; }

	event EventHandler<GuildUpdatedEventArgs>? GuildDocumentUpdated;

	event EventHandler<GuildMembersUpdatedEventArgs>? GuildMembersUpdated;

	void StartListeners(string guildId);

	void StopListeners();
}
