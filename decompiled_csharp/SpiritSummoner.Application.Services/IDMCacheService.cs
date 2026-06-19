using System.Collections.Generic;
using SpiritSummoner.Domain.Entities.Chat;

namespace SpiritSummoner.Application.Services;

public interface IDMCacheService
{
	List<ChatMessage>? GetMessages(string conversationId);

	string? GetConversationId(string playerIdA, string playerIdB);

	void SetMessages(string conversationId, List<ChatMessage> messages);

	void SetConversationId(string playerIdA, string playerIdB, string conversationId);

	void AppendMessage(string conversationId, ChatMessage message);

	void InvalidateMessages(string conversationId);
}
