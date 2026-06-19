using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpiritSummoner.Domain.Entities.Chat;

namespace SpiritSummoner.Domain.Repositories;

public interface IChatRepository
{
	global::System.Threading.Tasks.Task<Conversation?> GetOrCreateGuildConversationAsync(string guildId, List<string> memberIds);

	global::System.Threading.Tasks.Task<List<Conversation>> GetGuildThreadsAsync(string guildId, int limit = 30);

	global::System.Threading.Tasks.Task<Conversation?> CreateGuildThreadAsync(string guildId, string subject, string icon, string createdByPlayerId);

	global::System.Threading.Tasks.Task<List<ChatMessage>> GetGuildThreadMessagesAsync(string guildId, string threadId, int limit, DateTimeOffset? before = null);

	global::System.Threading.Tasks.Task<bool> SendGuildThreadMessageAsync(string guildId, string threadId, ChatMessage message);

	global::System.Threading.Tasks.Task<bool> UpdateGuildThreadLastMessageAsync(string guildId, string threadId, string text, string senderId, DateTimeOffset sentAt);

	global::System.Threading.Tasks.Task<Conversation?> GetOrCreateDMConversationAsync(string playerIdA, string playerIdB);

	global::System.Threading.Tasks.Task<List<Conversation>> GetPlayerConversationsAsync(string playerId);

	global::System.Threading.Tasks.Task<bool> SendMessageAsync(string conversationId, ChatMessage message);

	global::System.Threading.Tasks.Task<List<ChatMessage>> GetMessagesAsync(string conversationId, int limit = 50, DateTimeOffset? beforeTimestamp = null);

	global::System.Threading.Tasks.Task<int> GetUnreadMessageCountAsync(string conversationId, DateTimeOffset afterTimestamp, int limit = 30);

	global::System.Threading.Tasks.Task<bool> UpdateConversationLastMessageAsync(string conversationId, string text, string senderId, DateTimeOffset sentAt);

	global::System.Threading.Tasks.Task<List<NewsItem>> GetNewsAsync(int limit = 20);
}
