using System;

namespace SpiritSummoner.Infrastructure.FirebaseListeners;

public interface IChatListenerService
{
	bool IsListening { get; }

	event EventHandler<ChatMessageReceivedEventArgs>? MessageReceived;

	void StartMessageListener(string conversationId);

	void StartGuildThreadMessageListener(string guildId, string threadId);

	void StopMessageListener();
}
