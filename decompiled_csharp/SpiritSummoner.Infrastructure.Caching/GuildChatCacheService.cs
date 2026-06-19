using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Application.Services;
using SpiritSummoner.Domain.Entities.Chat;

namespace SpiritSummoner.Infrastructure.Caching;

public class GuildChatCacheService : IGuildChatCacheService
{
	private sealed record MessageCacheEntry(List<ChatMessage> Messages, DateTimeOffset CachedAt)
	{
		[CompilerGenerated]
		private global::System.Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return typeof(MessageCacheEntry);
			}
		}

		[CompilerGenerated]
		public override string ToString()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			StringBuilder val = new StringBuilder();
			val.Append("MessageCacheEntry");
			val.Append(" { ");
			if (PrintMembers(val))
			{
				val.Append(' ');
			}
			val.Append('}');
			return ((object)val).ToString();
		}

		[CompilerGenerated]
		private bool PrintMembers(StringBuilder builder)
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			RuntimeHelpers.EnsureSufficientExecutionStack();
			builder.Append("Messages = ");
			builder.Append((object)Messages);
			builder.Append(", CachedAt = ");
			DateTimeOffset cachedAt = CachedAt;
			builder.Append(((object)(DateTimeOffset)(ref cachedAt)).ToString());
			return true;
		}

		[CompilerGenerated]
		public bool Equals(MessageCacheEntry? other)
		{
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<List<ChatMessage>>.Default.Equals(Messages, other.Messages) && EqualityComparer<DateTimeOffset>.Default.Equals(CachedAt, other.CachedAt));
		}
	}

	private sealed record ThreadListCacheEntry(List<Conversation> Threads, DateTimeOffset CachedAt)
	{
		[CompilerGenerated]
		private global::System.Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return typeof(ThreadListCacheEntry);
			}
		}

		[CompilerGenerated]
		public override string ToString()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			StringBuilder val = new StringBuilder();
			val.Append("ThreadListCacheEntry");
			val.Append(" { ");
			if (PrintMembers(val))
			{
				val.Append(' ');
			}
			val.Append('}');
			return ((object)val).ToString();
		}

		[CompilerGenerated]
		private bool PrintMembers(StringBuilder builder)
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			RuntimeHelpers.EnsureSufficientExecutionStack();
			builder.Append("Threads = ");
			builder.Append((object)Threads);
			builder.Append(", CachedAt = ");
			DateTimeOffset cachedAt = CachedAt;
			builder.Append(((object)(DateTimeOffset)(ref cachedAt)).ToString());
			return true;
		}

		[CompilerGenerated]
		public bool Equals(ThreadListCacheEntry? other)
		{
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<List<Conversation>>.Default.Equals(Threads, other.Threads) && EqualityComparer<DateTimeOffset>.Default.Equals(CachedAt, other.CachedAt));
		}
	}

	private static readonly TimeSpan MessageTtl = TimeSpan.FromMinutes(5L);

	private static readonly TimeSpan ThreadListTtl = TimeSpan.FromMinutes(2L);

	private const int MaxThreadConversations = 5;

	private readonly Dictionary<string, MessageCacheEntry> _messageCache = new Dictionary<string, MessageCacheEntry>();

	private readonly Dictionary<string, ThreadListCacheEntry> _threadListCache = new Dictionary<string, ThreadListCacheEntry>();

	private readonly LinkedList<string> _lruOrder = new LinkedList<string>();

	private readonly Dictionary<string, LinkedListNode<string>> _lruNodes = new Dictionary<string, LinkedListNode<string>>();

	public List<Conversation>? GetThreadList(string guildId)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		ThreadListCacheEntry threadListCacheEntry = default(ThreadListCacheEntry);
		if (!_threadListCache.TryGetValue(guildId, ref threadListCacheEntry))
		{
			return null;
		}
		if (DateTimeOffset.UtcNow - threadListCacheEntry.CachedAt > ThreadListTtl)
		{
			_threadListCache.Remove(guildId);
			return null;
		}
		return threadListCacheEntry.Threads;
	}

	public void SetThreadList(string guildId, List<Conversation> threads)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		_threadListCache[guildId] = new ThreadListCacheEntry(new List<Conversation>((global::System.Collections.Generic.IEnumerable<Conversation>)threads), DateTimeOffset.UtcNow);
	}

	public void InvalidateThreadList(string guildId)
	{
		_threadListCache.Remove(guildId);
	}

	public void PrependThread(string guildId, Conversation thread)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		ThreadListCacheEntry threadListCacheEntry = default(ThreadListCacheEntry);
		if (_threadListCache.TryGetValue(guildId, ref threadListCacheEntry))
		{
			threadListCacheEntry.Threads.Insert(0, thread);
			_threadListCache[guildId] = threadListCacheEntry with
			{
				CachedAt = DateTimeOffset.UtcNow
			};
		}
	}

	public List<ChatMessage>? GetMessages(string threadId)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		MessageCacheEntry messageCacheEntry = default(MessageCacheEntry);
		if (!_messageCache.TryGetValue(threadId, ref messageCacheEntry))
		{
			return null;
		}
		if (DateTimeOffset.UtcNow - messageCacheEntry.CachedAt > MessageTtl)
		{
			_messageCache.Remove(threadId);
			RemoveLruNode(threadId);
			return null;
		}
		TouchLru(threadId);
		return messageCacheEntry.Messages;
	}

	public void SetMessages(string threadId, List<ChatMessage> messages)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		EnsureCapacity();
		_messageCache[threadId] = new MessageCacheEntry(new List<ChatMessage>((global::System.Collections.Generic.IEnumerable<ChatMessage>)messages), DateTimeOffset.UtcNow);
		TouchLru(threadId);
	}

	public void AppendMessage(string threadId, ChatMessage message)
	{
		MessageCacheEntry messageCacheEntry = default(MessageCacheEntry);
		if (_messageCache.TryGetValue(threadId, ref messageCacheEntry))
		{
			messageCacheEntry.Messages.Add(message);
			TouchLru(threadId);
		}
	}

	public void InvalidateMessages(string threadId)
	{
		_messageCache.Remove(threadId);
		RemoveLruNode(threadId);
	}

	private void EnsureCapacity()
	{
		while (_messageCache.Count >= 5 && _lruOrder.Count > 0)
		{
			string value = _lruOrder.Last.Value;
			_lruOrder.RemoveLast();
			_lruNodes.Remove(value);
			_messageCache.Remove(value);
		}
	}

	private void TouchLru(string threadId)
	{
		LinkedListNode<string> val = default(LinkedListNode<string>);
		if (_lruNodes.TryGetValue(threadId, ref val))
		{
			_lruOrder.Remove(val);
		}
		LinkedListNode<string> val2 = _lruOrder.AddFirst(threadId);
		_lruNodes[threadId] = val2;
	}

	private void RemoveLruNode(string threadId)
	{
		LinkedListNode<string> val = default(LinkedListNode<string>);
		if (_lruNodes.TryGetValue(threadId, ref val))
		{
			_lruOrder.Remove(val);
			_lruNodes.Remove(threadId);
		}
	}
}
