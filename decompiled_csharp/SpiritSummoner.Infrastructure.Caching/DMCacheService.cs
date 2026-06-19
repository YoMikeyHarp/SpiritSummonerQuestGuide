using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Application.Services;
using SpiritSummoner.Domain.Entities.Chat;

namespace SpiritSummoner.Infrastructure.Caching;

public class DMCacheService : IDMCacheService
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

	private static readonly TimeSpan MessageTtl = TimeSpan.FromMinutes(5L);

	private const int MaxConversations = 10;

	private readonly Dictionary<string, MessageCacheEntry> _messageCache = new Dictionary<string, MessageCacheEntry>();

	private readonly Dictionary<string, string> _conversationIdCache = new Dictionary<string, string>();

	private readonly LinkedList<string> _lruOrder = new LinkedList<string>();

	private readonly Dictionary<string, LinkedListNode<string>> _lruNodes = new Dictionary<string, LinkedListNode<string>>();

	public List<ChatMessage>? GetMessages(string conversationId)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		MessageCacheEntry messageCacheEntry = default(MessageCacheEntry);
		if (!_messageCache.TryGetValue(conversationId, ref messageCacheEntry))
		{
			return null;
		}
		if (DateTimeOffset.UtcNow - messageCacheEntry.CachedAt > MessageTtl)
		{
			_messageCache.Remove(conversationId);
			RemoveLruNode(conversationId);
			return null;
		}
		TouchLru(conversationId);
		return messageCacheEntry.Messages;
	}

	public string? GetConversationId(string playerIdA, string playerIdB)
	{
		string text = MakeKey(playerIdA, playerIdB);
		string text2 = default(string);
		return _conversationIdCache.TryGetValue(text, ref text2) ? text2 : null;
	}

	public void SetMessages(string conversationId, List<ChatMessage> messages)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		EnsureCapacity();
		_messageCache[conversationId] = new MessageCacheEntry(new List<ChatMessage>((global::System.Collections.Generic.IEnumerable<ChatMessage>)messages), DateTimeOffset.UtcNow);
		TouchLru(conversationId);
	}

	public void SetConversationId(string playerIdA, string playerIdB, string conversationId)
	{
		_conversationIdCache[MakeKey(playerIdA, playerIdB)] = conversationId;
	}

	public void AppendMessage(string conversationId, ChatMessage message)
	{
		MessageCacheEntry messageCacheEntry = default(MessageCacheEntry);
		if (_messageCache.TryGetValue(conversationId, ref messageCacheEntry))
		{
			messageCacheEntry.Messages.Add(message);
			TouchLru(conversationId);
		}
	}

	public void InvalidateMessages(string conversationId)
	{
		_messageCache.Remove(conversationId);
		RemoveLruNode(conversationId);
	}

	private static string MakeKey(string a, string b)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		ValueTuple<string, string> val = ((string.CompareOrdinal(a, b) <= 0) ? new ValueTuple<string, string>(a, b) : new ValueTuple<string, string>(b, a));
		return val.Item1 + "|" + val.Item2;
	}

	private void EnsureCapacity()
	{
		while (_messageCache.Count >= 10 && _lruOrder.Count > 0)
		{
			string value = _lruOrder.Last.Value;
			_lruOrder.RemoveLast();
			_lruNodes.Remove(value);
			_messageCache.Remove(value);
		}
	}

	private void TouchLru(string conversationId)
	{
		LinkedListNode<string> val = default(LinkedListNode<string>);
		if (_lruNodes.TryGetValue(conversationId, ref val))
		{
			_lruOrder.Remove(val);
		}
		LinkedListNode<string> val2 = _lruOrder.AddFirst(conversationId);
		_lruNodes[conversationId] = val2;
	}

	private void RemoveLruNode(string conversationId)
	{
		LinkedListNode<string> val = default(LinkedListNode<string>);
		if (_lruNodes.TryGetValue(conversationId, ref val))
		{
			_lruOrder.Remove(val);
			_lruNodes.Remove(conversationId);
		}
	}
}
