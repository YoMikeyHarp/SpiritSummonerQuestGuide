using System.Collections.Generic;
using SpiritSummoner.Domain.Entities.Chat;

namespace SpiritSummoner.Application.Services;

public interface IGuildChatCacheService
{
	List<Conversation>? GetThreadList(string guildId);

	void SetThreadList(string guildId, List<Conversation> threads);

	void InvalidateThreadList(string guildId);

	void PrependThread(string guildId, Conversation thread);

	List<ChatMessage>? GetMessages(string threadId);

	void SetMessages(string threadId, List<ChatMessage> messages);

	void AppendMessage(string threadId, ChatMessage message);

	void InvalidateMessages(string threadId);
}
