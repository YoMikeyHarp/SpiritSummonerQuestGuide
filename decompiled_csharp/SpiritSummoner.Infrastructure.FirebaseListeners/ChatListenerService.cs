using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Plugin.Firebase.Firestore;
using SpiritSummoner.Domain.Entities.Chat;
using SpiritSummoner.Infrastructure.Diagnostics;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Chat;

namespace SpiritSummoner.Infrastructure.FirebaseListeners;

public class ChatListenerService : IChatListenerService
{
	private readonly IFirebaseFirestore _firestore;

	private global::System.IDisposable? _messageListener;

	private string? _currentConversationId;

	private string? _currentGuildId;

	private string? _currentThreadId;

	private readonly HashSet<string> _processedMessageIds = new HashSet<string>(500);

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private EventHandler<ChatMessageReceivedEventArgs>? m_MessageReceived;

	public bool IsListening => _messageListener != null;

	public event EventHandler<ChatMessageReceivedEventArgs>? MessageReceived
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ChatMessageReceivedEventArgs> val = this.m_MessageReceived;
			EventHandler<ChatMessageReceivedEventArgs> val2;
			do
			{
				val2 = val;
				EventHandler<ChatMessageReceivedEventArgs> val3 = (EventHandler<ChatMessageReceivedEventArgs>)(object)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<ChatMessageReceivedEventArgs>>(ref this.m_MessageReceived, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ChatMessageReceivedEventArgs> val = this.m_MessageReceived;
			EventHandler<ChatMessageReceivedEventArgs> val2;
			do
			{
				val2 = val;
				EventHandler<ChatMessageReceivedEventArgs> val3 = (EventHandler<ChatMessageReceivedEventArgs>)(object)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<ChatMessageReceivedEventArgs>>(ref this.m_MessageReceived, val3, val2);
			}
			while (val != val2);
		}
	}

	public ChatListenerService(IFirebaseFirestore firestore)
	{
		_firestore = firestore;
	}

	public void StartMessageListener(string conversationId)
	{
		if (string.IsNullOrEmpty(conversationId))
		{
			return;
		}
		StopMessageListener();
		_currentConversationId = conversationId;
		try
		{
			_messageListener = ((IQuery)_firestore.GetCollection("conversations").GetDocument(conversationId).GetCollection("messages")).OrderBy("createdAt", true).LimitedTo(50).AddSnapshotListener<FirestoreChatMessageDTO>((Action<IQuerySnapshot<FirestoreChatMessageDTO>>)OnMessagesSnapshot, (Action<global::System.Exception>)OnMessagesError, false);
			Console.WriteLine("Started chat listener for conversation: " + conversationId);
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine("StartMessageListener error: " + ex.Message);
		}
	}

	public void StartGuildThreadMessageListener(string guildId, string threadId)
	{
		if (string.IsNullOrEmpty(guildId) || string.IsNullOrEmpty(threadId))
		{
			return;
		}
		StopMessageListener();
		_currentGuildId = guildId;
		_currentThreadId = threadId;
		_currentConversationId = threadId;
		try
		{
			_messageListener = ((IQuery)_firestore.GetCollection("guilds").GetDocument(guildId).GetCollection("threads")
				.GetDocument(threadId)
				.GetCollection("messages")).OrderBy("createdAt", true).LimitedTo(50).AddSnapshotListener<FirestoreChatMessageDTO>((Action<IQuerySnapshot<FirestoreChatMessageDTO>>)OnMessagesSnapshot, (Action<global::System.Exception>)OnMessagesError, false);
			Console.WriteLine("Started guild thread listener for: guilds/" + guildId + "/threads/" + threadId);
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine("StartGuildThreadMessageListener error: " + ex.Message);
		}
	}

	public void StopMessageListener()
	{
		try
		{
			_messageListener?.Dispose();
			_messageListener = null;
			_currentConversationId = null;
			_currentGuildId = null;
			_currentThreadId = null;
			_processedMessageIds.Clear();
			Console.WriteLine("Stopped chat message listener");
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine("StopMessageListener error: " + ex.Message);
		}
	}

	private void OnMessagesSnapshot(IQuerySnapshot<FirestoreChatMessageDTO>? snapshot)
	{
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		if (snapshot?.Documents == null)
		{
			return;
		}
		try
		{
			FirestoreReadCounter.Track("chat listener", Enumerable.Count<IDocumentSnapshot<FirestoreChatMessageDTO>>(snapshot.Documents));
			global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreChatMessageDTO>> enumerator = snapshot.Documents.GetEnumerator();
			try
			{
				while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
				{
					IDocumentSnapshot<FirestoreChatMessageDTO> current = enumerator.Current;
					if (current.Data != null && !_processedMessageIds.Contains(current.Data.Id))
					{
						_processedMessageIds.Add(current.Data.Id);
						ChatMessage message = new ChatMessage
						{
							Id = current.Data.Id,
							SenderId = current.Data.SenderId,
							SenderName = current.Data.SenderName,
							Content = current.Data.Content,
							CreatedAt = current.Data.CreatedAt
						};
						this.MessageReceived?.Invoke((object)this, new ChatMessageReceivedEventArgs
						{
							Message = message,
							ConversationId = (_currentConversationId ?? string.Empty)
						});
					}
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator)?.Dispose();
			}
			if (_processedMessageIds.Count > 500)
			{
				_processedMessageIds.Clear();
			}
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine("OnMessagesSnapshot error: " + ex.Message);
		}
	}

	private void OnMessagesError(global::System.Exception? error)
	{
		if (error == null)
		{
			return;
		}
		Console.WriteLine("Chat listener error: " + error.Message);
		string guildId = _currentGuildId;
		string threadId = _currentThreadId;
		string conversationId = _currentConversationId;
		global::System.Threading.Tasks.Task.Delay(5000).ContinueWith((Action<global::System.Threading.Tasks.Task>)delegate
		{
			if (!IsListening)
			{
				if (!string.IsNullOrEmpty(guildId) && !string.IsNullOrEmpty(threadId))
				{
					Console.WriteLine("Retrying guild thread listener for: guilds/" + guildId + "/threads/" + threadId);
					StartGuildThreadMessageListener(guildId, threadId);
				}
				else if (!string.IsNullOrEmpty(conversationId))
				{
					Console.WriteLine("Retrying chat listener for: " + conversationId);
					StartMessageListener(conversationId);
				}
			}
		});
	}
}
