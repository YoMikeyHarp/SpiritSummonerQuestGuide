using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Plugin.Firebase.Firestore;
using SpiritSummoner.Domain.Entities.Chat;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Diagnostics;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Chat;

namespace SpiritSummoner.Infrastructure.Persistence.Repositories;

public class ChatRepository : IChatRepository
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public string playerIdB;

		internal bool _003CGetOrCreateDMConversationAsync_003Eb__0(IDocumentSnapshot<FirestoreConversationDTO> d)
		{
			return d.Data != null && d.Data.ParticipantIds.Contains(playerIdB) && d.Data.ParticipantIds.Count == 2;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public DateTimeOffset now;

		internal bool _003CGetNewsAsync_003Eb__2(NewsItem n)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			int result;
			if (n.ExpiresAt.HasValue)
			{
				DateTimeOffset? expiresAt = n.ExpiresAt;
				DateTimeOffset val = now;
				result = ((expiresAt.HasValue && expiresAt.GetValueOrDefault() > val) ? 1 : 0);
			}
			else
			{
				result = 1;
			}
			return (byte)result != 0;
		}
	}

	[CompilerGenerated]
	private sealed class _003CCreateGuildThreadAsync_003Ed__16 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Conversation> _003C_003Et__builder;

		public string guildId;

		public string subject;

		public string icon;

		public string createdByPlayerId;

		public ChatRepository _003C_003E4__this;

		private DateTimeOffset _003Cnow_003E5__1;

		private FirestoreGuildThreadDTO _003Cdto_003E5__2;

		private IDocumentReference _003CdocRef_003E5__3;

		private IDocumentReference _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<IDocumentReference> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Conversation result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IDocumentReference> awaiter;
					if (num != 0)
					{
						_003Cnow_003E5__1 = DateTimeOffset.UtcNow;
						_003Cdto_003E5__2 = new FirestoreGuildThreadDTO
						{
							Subject = subject,
							Icon = icon,
							CreatedBy = createdByPlayerId,
							CreatedAt = _003Cnow_003E5__1,
							LastMessageAt = _003Cnow_003E5__1,
							LastMessageText = string.Empty,
							LastMessageSenderId = string.Empty
						};
						awaiter = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId).GetCollection("threads")
							.AddDocumentAsync((object)_003Cdto_003E5__2)
							.GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CCreateGuildThreadAsync_003Ed__16 _003CCreateGuildThreadAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentReference>, _003CCreateGuildThreadAsync_003Ed__16>(ref awaiter, ref _003CCreateGuildThreadAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentReference>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__4 = awaiter.GetResult();
					_003CdocRef_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					result = new Conversation
					{
						Id = _003CdocRef_003E5__3.Id,
						Subject = subject,
						Icon = icon,
						CreatedBy = createdByPlayerId,
						LastMessageText = string.Empty,
						LastMessageAt = _003Cnow_003E5__1,
						CreatedAt = _003Cnow_003E5__1
					};
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					Console.WriteLine("CreateGuildThreadAsync error: " + _003Cex_003E5__5.Message);
					result = null;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetGuildThreadMessagesAsync_003Ed__17 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<ChatMessage>> _003C_003Et__builder;

		public string guildId;

		public string threadId;

		public int limit;

		public DateTimeOffset? before;

		public ChatRepository _003C_003E4__this;

		private IQuery _003CbaseQuery_003E5__1;

		private IQuery _003Cquery_003E5__2;

		private IQuerySnapshot<FirestoreChatMessageDTO> _003Csnapshot_003E5__3;

		private IQuerySnapshot<FirestoreChatMessageDTO> _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<IQuerySnapshot<FirestoreChatMessageDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<ChatMessage> result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestoreChatMessageDTO>> awaiter;
					if (num != 0)
					{
						_003CbaseQuery_003E5__1 = ((IQuery)_003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId).GetCollection("threads")
							.GetDocument(threadId)
							.GetCollection("messages")).OrderBy("createdAt", true);
						_003Cquery_003E5__2 = (before.HasValue ? _003CbaseQuery_003E5__1.WhereLessThan("createdAt", (object)before.Value).LimitedTo(limit) : _003CbaseQuery_003E5__1.LimitedTo(limit));
						awaiter = _003Cquery_003E5__2.GetDocumentsAsync<FirestoreChatMessageDTO>((Source)0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetGuildThreadMessagesAsync_003Ed__17 _003CGetGuildThreadMessagesAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreChatMessageDTO>>, _003CGetGuildThreadMessagesAsync_003Ed__17>(ref awaiter, ref _003CGetGuildThreadMessagesAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreChatMessageDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__4 = awaiter.GetResult();
					_003Csnapshot_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					FirestoreReadCounter.Track("GetGuildThreadMessages", Enumerable.Count<IDocumentSnapshot<FirestoreChatMessageDTO>>(_003Csnapshot_003E5__3.Documents));
					result = ((_003Csnapshot_003E5__3?.Documents != null && Enumerable.Any<IDocumentSnapshot<FirestoreChatMessageDTO>>(_003Csnapshot_003E5__3.Documents)) ? Enumerable.ToList<ChatMessage>((global::System.Collections.Generic.IEnumerable<ChatMessage>)Enumerable.OrderBy<ChatMessage, DateTimeOffset>(Enumerable.Select<IDocumentSnapshot<FirestoreChatMessageDTO>, ChatMessage>(Enumerable.Where<IDocumentSnapshot<FirestoreChatMessageDTO>>(_003Csnapshot_003E5__3.Documents, (Func<IDocumentSnapshot<FirestoreChatMessageDTO>, bool>)((IDocumentSnapshot<FirestoreChatMessageDTO> d) => d.Data != null)), (Func<IDocumentSnapshot<FirestoreChatMessageDTO>, ChatMessage>)((IDocumentSnapshot<FirestoreChatMessageDTO> d) => new ChatMessage
					{
						Id = d.Data.Id,
						SenderId = d.Data.SenderId,
						SenderName = d.Data.SenderName,
						Content = d.Data.Content,
						CreatedAt = d.Data.CreatedAt
					})), (Func<ChatMessage, DateTimeOffset>)((ChatMessage m) => m.CreatedAt))) : new List<ChatMessage>());
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					Console.WriteLine("GetGuildThreadMessagesAsync error: " + _003Cex_003E5__5.Message);
					result = new List<ChatMessage>();
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetGuildThreadsAsync_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<Conversation>> _003C_003Et__builder;

		public string guildId;

		public int limit;

		public ChatRepository _003C_003E4__this;

		private IQuerySnapshot<FirestoreGuildThreadDTO> _003Csnapshot_003E5__1;

		private IQuerySnapshot<FirestoreGuildThreadDTO> _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<IQuerySnapshot<FirestoreGuildThreadDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<Conversation> result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestoreGuildThreadDTO>> awaiter;
					if (num != 0)
					{
						awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId).GetCollection("threads")).OrderBy("lastMessageAt", true).LimitedTo(limit).GetDocumentsAsync<FirestoreGuildThreadDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetGuildThreadsAsync_003Ed__15 _003CGetGuildThreadsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreGuildThreadDTO>>, _003CGetGuildThreadsAsync_003Ed__15>(ref awaiter, ref _003CGetGuildThreadsAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreGuildThreadDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Csnapshot_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Csnapshot_003E5__1?.Documents == null || !Enumerable.Any<IDocumentSnapshot<FirestoreGuildThreadDTO>>(_003Csnapshot_003E5__1.Documents))
					{
						result = new List<Conversation>();
					}
					else
					{
						FirestoreReadCounter.Track("GetGuildThreads", Enumerable.Count<IDocumentSnapshot<FirestoreGuildThreadDTO>>(_003Csnapshot_003E5__1.Documents));
						result = Enumerable.ToList<Conversation>(Enumerable.Select<IDocumentSnapshot<FirestoreGuildThreadDTO>, Conversation>(Enumerable.Where<IDocumentSnapshot<FirestoreGuildThreadDTO>>(_003Csnapshot_003E5__1.Documents, (Func<IDocumentSnapshot<FirestoreGuildThreadDTO>, bool>)((IDocumentSnapshot<FirestoreGuildThreadDTO> d) => d.Data != null)), (Func<IDocumentSnapshot<FirestoreGuildThreadDTO>, Conversation>)((IDocumentSnapshot<FirestoreGuildThreadDTO> d) => MapThreadToEntity(d.Data))));
					}
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("GetGuildThreadsAsync error: " + _003Cex_003E5__3.Message);
					result = new List<Conversation>();
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetMessagesAsync_003Ed__9 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<ChatMessage>> _003C_003Et__builder;

		public string conversationId;

		public int limit;

		public DateTimeOffset? beforeTimestamp;

		public ChatRepository _003C_003E4__this;

		private IQuery _003CbaseQuery_003E5__1;

		private IQuery _003Cquery_003E5__2;

		private IQuerySnapshot<FirestoreChatMessageDTO> _003Csnapshot_003E5__3;

		private IQuerySnapshot<FirestoreChatMessageDTO> _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<IQuerySnapshot<FirestoreChatMessageDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<ChatMessage> result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestoreChatMessageDTO>> awaiter;
					if (num != 0)
					{
						_003CbaseQuery_003E5__1 = ((IQuery)_003C_003E4__this._firestore.GetCollection("conversations").GetDocument(conversationId).GetCollection("messages")).OrderBy("createdAt", true);
						_003Cquery_003E5__2 = (beforeTimestamp.HasValue ? _003CbaseQuery_003E5__1.WhereLessThan("createdAt", (object)beforeTimestamp.Value).LimitedTo(limit) : _003CbaseQuery_003E5__1.LimitedTo(limit));
						awaiter = _003Cquery_003E5__2.GetDocumentsAsync<FirestoreChatMessageDTO>((Source)0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetMessagesAsync_003Ed__9 _003CGetMessagesAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreChatMessageDTO>>, _003CGetMessagesAsync_003Ed__9>(ref awaiter, ref _003CGetMessagesAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreChatMessageDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__4 = awaiter.GetResult();
					_003Csnapshot_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003Csnapshot_003E5__3?.Documents == null || !Enumerable.Any<IDocumentSnapshot<FirestoreChatMessageDTO>>(_003Csnapshot_003E5__3.Documents))
					{
						result = new List<ChatMessage>();
					}
					else
					{
						FirestoreReadCounter.Track("GetMessages", Enumerable.Count<IDocumentSnapshot<FirestoreChatMessageDTO>>(_003Csnapshot_003E5__3.Documents));
						result = Enumerable.ToList<ChatMessage>((global::System.Collections.Generic.IEnumerable<ChatMessage>)Enumerable.OrderBy<ChatMessage, DateTimeOffset>(Enumerable.Select<IDocumentSnapshot<FirestoreChatMessageDTO>, ChatMessage>(Enumerable.Where<IDocumentSnapshot<FirestoreChatMessageDTO>>(_003Csnapshot_003E5__3.Documents, (Func<IDocumentSnapshot<FirestoreChatMessageDTO>, bool>)((IDocumentSnapshot<FirestoreChatMessageDTO> d) => d.Data != null)), (Func<IDocumentSnapshot<FirestoreChatMessageDTO>, ChatMessage>)((IDocumentSnapshot<FirestoreChatMessageDTO> d) => new ChatMessage
						{
							Id = d.Data.Id,
							SenderId = d.Data.SenderId,
							SenderName = d.Data.SenderName,
							Content = d.Data.Content,
							CreatedAt = d.Data.CreatedAt
						})), (Func<ChatMessage, DateTimeOffset>)((ChatMessage m) => m.CreatedAt)));
					}
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					Console.WriteLine("GetMessagesAsync error: " + _003Cex_003E5__5.Message);
					result = new List<ChatMessage>();
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetNewsAsync_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<NewsItem>> _003C_003Et__builder;

		public int limit;

		public ChatRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass14_0 _003C_003E8__1;

		private IQuerySnapshot<FirestoreNewsDTO> _003Csnapshot_003E5__2;

		private IQuerySnapshot<FirestoreNewsDTO> _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<IQuerySnapshot<FirestoreNewsDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<NewsItem> result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestoreNewsDTO>> awaiter;
					if (num != 0)
					{
						_003C_003E8__1 = new _003C_003Ec__DisplayClass14_0();
						awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection("news")).OrderBy("createdAt", true).LimitedTo(limit).GetDocumentsAsync<FirestoreNewsDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetNewsAsync_003Ed__14 _003CGetNewsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreNewsDTO>>, _003CGetNewsAsync_003Ed__14>(ref awaiter, ref _003CGetNewsAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreNewsDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter.GetResult();
					_003Csnapshot_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (_003Csnapshot_003E5__2?.Documents == null || !Enumerable.Any<IDocumentSnapshot<FirestoreNewsDTO>>(_003Csnapshot_003E5__2.Documents))
					{
						result = new List<NewsItem>();
					}
					else
					{
						_003C_003E8__1.now = DateTimeOffset.UtcNow;
						result = Enumerable.ToList<NewsItem>(Enumerable.Where<NewsItem>(Enumerable.Select<IDocumentSnapshot<FirestoreNewsDTO>, NewsItem>(Enumerable.Where<IDocumentSnapshot<FirestoreNewsDTO>>(_003Csnapshot_003E5__2.Documents, (Func<IDocumentSnapshot<FirestoreNewsDTO>, bool>)((IDocumentSnapshot<FirestoreNewsDTO> d) => d.Data != null)), (Func<IDocumentSnapshot<FirestoreNewsDTO>, NewsItem>)((IDocumentSnapshot<FirestoreNewsDTO> d) => new NewsItem
						{
							Id = d.Data.Id,
							Title = d.Data.Title,
							Content = d.Data.Content,
							CreatedAt = d.Data.CreatedAt,
							ExpiresAt = d.Data.ExpiresAt
						})), (Func<NewsItem, bool>)delegate(NewsItem n)
						{
							//IL_0018: Unknown result type (might be due to invalid IL or missing references)
							//IL_001d: Unknown result type (might be due to invalid IL or missing references)
							//IL_002c: Unknown result type (might be due to invalid IL or missing references)
							//IL_0031: Unknown result type (might be due to invalid IL or missing references)
							int result2;
							if (n.ExpiresAt.HasValue)
							{
								DateTimeOffset? expiresAt = n.ExpiresAt;
								DateTimeOffset now = _003C_003E8__1.now;
								result2 = ((expiresAt.HasValue && expiresAt.GetValueOrDefault() > now) ? 1 : 0);
							}
							else
							{
								result2 = 1;
							}
							return (byte)result2 != 0;
						}));
					}
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					Console.WriteLine("GetNewsAsync error: " + _003Cex_003E5__4.Message);
					result = new List<NewsItem>();
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetOrCreateDMConversationAsync_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Conversation> _003C_003Et__builder;

		public string playerIdA;

		public string playerIdB;

		public ChatRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass12_0 _003C_003E8__1;

		private IQuerySnapshot<FirestoreConversationDTO> _003Csnapshot_003E5__2;

		private DateTimeOffset _003Cnow_003E5__3;

		private List<string> _003CparticipantIds_003E5__4;

		private FirestoreConversationDTO _003Cdto_003E5__5;

		private IDocumentReference _003CdocRef_003E5__6;

		private IQuerySnapshot<FirestoreConversationDTO> _003C_003Es__7;

		private IDocumentSnapshot<FirestoreConversationDTO> _003Cexisting_003E5__8;

		private IDocumentReference _003C_003Es__9;

		private global::System.Exception _003Cex_003E5__10;

		private TaskAwaiter<IQuerySnapshot<FirestoreConversationDTO>> _003C_003Eu__1;

		private TaskAwaiter<IDocumentReference> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0267: Unknown result type (might be due to invalid IL or missing references)
			//IL_026c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0274: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_022e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0233: Unknown result type (might be due to invalid IL or missing references)
			//IL_0248: Unknown result type (might be due to invalid IL or missing references)
			//IL_024a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Conversation result;
			try
			{
				if ((uint)num > 1u)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass12_0();
					_003C_003E8__1.playerIdB = playerIdB;
				}
				try
				{
					TaskAwaiter<IDocumentReference> awaiter;
					TaskAwaiter<IQuerySnapshot<FirestoreConversationDTO>> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<IDocumentReference>);
							num = (_003C_003E1__state = -1);
							goto IL_0283;
						}
						awaiter2 = ((IQuery)_003C_003E4__this._firestore.GetCollection("conversations")).WhereEqualsTo("type", (object)"dm").WhereArrayContains("participantIds", (object)playerIdA).GetDocumentsAsync<FirestoreConversationDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CGetOrCreateDMConversationAsync_003Ed__12 _003CGetOrCreateDMConversationAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreConversationDTO>>, _003CGetOrCreateDMConversationAsync_003Ed__12>(ref awaiter2, ref _003CGetOrCreateDMConversationAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreConversationDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__7 = awaiter2.GetResult();
					_003Csnapshot_003E5__2 = _003C_003Es__7;
					_003C_003Es__7 = null;
					if (_003Csnapshot_003E5__2?.Documents == null)
					{
						goto IL_0183;
					}
					FirestoreReadCounter.Track("GetOrCreateDM", Enumerable.Count<IDocumentSnapshot<FirestoreConversationDTO>>(_003Csnapshot_003E5__2.Documents));
					_003Cexisting_003E5__8 = Enumerable.FirstOrDefault<IDocumentSnapshot<FirestoreConversationDTO>>(_003Csnapshot_003E5__2.Documents, (Func<IDocumentSnapshot<FirestoreConversationDTO>, bool>)((IDocumentSnapshot<FirestoreConversationDTO> d) => d.Data != null && d.Data.ParticipantIds.Contains(_003C_003E8__1.playerIdB) && d.Data.ParticipantIds.Count == 2));
					if (_003Cexisting_003E5__8?.Data == null)
					{
						_003Cexisting_003E5__8 = null;
						goto IL_0183;
					}
					result = MapToEntity(_003Cexisting_003E5__8.Data);
					goto end_IL_002d;
					IL_0283:
					_003C_003Es__9 = awaiter.GetResult();
					_003CdocRef_003E5__6 = _003C_003Es__9;
					_003C_003Es__9 = null;
					result = new Conversation
					{
						Id = _003CdocRef_003E5__6.Id,
						Type = "dm",
						ParticipantIds = _003CparticipantIds_003E5__4,
						LastMessageText = string.Empty,
						LastMessageAt = _003Cnow_003E5__3,
						CreatedAt = _003Cnow_003E5__3
					};
					goto end_IL_002d;
					IL_0183:
					_003Cnow_003E5__3 = DateTimeOffset.UtcNow;
					List<string> obj = new List<string>();
					obj.Add(playerIdA);
					obj.Add(_003C_003E8__1.playerIdB);
					_003CparticipantIds_003E5__4 = obj;
					_003Cdto_003E5__5 = new FirestoreConversationDTO
					{
						Type = "dm",
						ParticipantIds = _003CparticipantIds_003E5__4,
						LastMessageText = string.Empty,
						LastMessageAt = _003Cnow_003E5__3,
						LastMessageSenderId = string.Empty,
						CreatedAt = _003Cnow_003E5__3
					};
					awaiter = _003C_003E4__this._firestore.GetCollection("conversations").AddDocumentAsync((object)_003Cdto_003E5__5).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter;
						_003CGetOrCreateDMConversationAsync_003Ed__12 _003CGetOrCreateDMConversationAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentReference>, _003CGetOrCreateDMConversationAsync_003Ed__12>(ref awaiter, ref _003CGetOrCreateDMConversationAsync_003Ed__);
						return;
					}
					goto IL_0283;
					end_IL_002d:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__10 = ex;
					Console.WriteLine("GetOrCreateDMConversationAsync error: " + _003Cex_003E5__10.Message);
					result = null;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetOrCreateGuildConversationAsync_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Conversation> _003C_003Et__builder;

		public string guildId;

		public List<string> memberIds;

		public ChatRepository _003C_003E4__this;

		private IQuerySnapshot<FirestoreConversationDTO> _003Csnapshot_003E5__1;

		private DateTimeOffset _003Cnow_003E5__2;

		private FirestoreConversationDTO _003Cdto_003E5__3;

		private IDocumentReference _003CdocRef_003E5__4;

		private IQuerySnapshot<FirestoreConversationDTO> _003C_003Es__5;

		private FirestoreConversationDTO _003Cexisting_003E5__6;

		private IDocumentReference _003C_003Es__7;

		private global::System.Exception _003Cex_003E5__8;

		private TaskAwaiter<IQuerySnapshot<FirestoreConversationDTO>> _003C_003Eu__1;

		private TaskAwaiter<IDocumentReference> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0229: Unknown result type (might be due to invalid IL or missing references)
			//IL_022e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0236: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_020a: Unknown result type (might be due to invalid IL or missing references)
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Conversation result;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter<IDocumentReference> awaiter;
					TaskAwaiter<IQuerySnapshot<FirestoreConversationDTO>> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<IDocumentReference>);
							num = (_003C_003E1__state = -1);
							goto IL_0245;
						}
						awaiter2 = ((IQuery)_003C_003E4__this._firestore.GetCollection("conversations")).WhereEqualsTo("type", (object)"guild").WhereEqualsTo("guildId", (object)guildId).LimitedTo(1)
							.GetDocumentsAsync<FirestoreConversationDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CGetOrCreateGuildConversationAsync_003Ed__7 _003CGetOrCreateGuildConversationAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreConversationDTO>>, _003CGetOrCreateGuildConversationAsync_003Ed__7>(ref awaiter2, ref _003CGetOrCreateGuildConversationAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreConversationDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__5 = awaiter2.GetResult();
					_003Csnapshot_003E5__1 = _003C_003Es__5;
					_003C_003Es__5 = null;
					if (_003Csnapshot_003E5__1?.Documents == null || !Enumerable.Any<IDocumentSnapshot<FirestoreConversationDTO>>(_003Csnapshot_003E5__1.Documents))
					{
						goto IL_0162;
					}
					FirestoreReadCounter.Track("guild conversation", Enumerable.Count<IDocumentSnapshot<FirestoreConversationDTO>>(_003Csnapshot_003E5__1.Documents));
					_003Cexisting_003E5__6 = Enumerable.First<IDocumentSnapshot<FirestoreConversationDTO>>(_003Csnapshot_003E5__1.Documents).Data;
					if (_003Cexisting_003E5__6 == null)
					{
						_003Cexisting_003E5__6 = null;
						goto IL_0162;
					}
					result = MapToEntity(_003Cexisting_003E5__6);
					goto end_IL_0011;
					IL_0245:
					_003C_003Es__7 = awaiter.GetResult();
					_003CdocRef_003E5__4 = _003C_003Es__7;
					_003C_003Es__7 = null;
					result = new Conversation
					{
						Id = _003CdocRef_003E5__4.Id,
						Type = "guild",
						GuildId = guildId,
						ParticipantIds = memberIds,
						LastMessageText = string.Empty,
						LastMessageAt = _003Cnow_003E5__2,
						CreatedAt = _003Cnow_003E5__2
					};
					goto end_IL_0011;
					IL_0162:
					_003Cnow_003E5__2 = DateTimeOffset.UtcNow;
					_003Cdto_003E5__3 = new FirestoreConversationDTO
					{
						Type = "guild",
						GuildId = guildId,
						ParticipantIds = memberIds,
						LastMessageText = string.Empty,
						LastMessageAt = _003Cnow_003E5__2,
						LastMessageSenderId = string.Empty,
						CreatedAt = _003Cnow_003E5__2
					};
					awaiter = _003C_003E4__this._firestore.GetCollection("conversations").AddDocumentAsync((object)_003Cdto_003E5__3).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter;
						_003CGetOrCreateGuildConversationAsync_003Ed__7 _003CGetOrCreateGuildConversationAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentReference>, _003CGetOrCreateGuildConversationAsync_003Ed__7>(ref awaiter, ref _003CGetOrCreateGuildConversationAsync_003Ed__);
						return;
					}
					goto IL_0245;
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__8 = ex;
					Console.WriteLine("GetOrCreateGuildConversationAsync error: " + _003Cex_003E5__8.Message);
					result = null;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetPlayerConversationsAsync_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<Conversation>> _003C_003Et__builder;

		public string playerId;

		public ChatRepository _003C_003E4__this;

		private IQuerySnapshot<FirestoreConversationDTO> _003Csnapshot_003E5__1;

		private IQuerySnapshot<FirestoreConversationDTO> _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<IQuerySnapshot<FirestoreConversationDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<Conversation> result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestoreConversationDTO>> awaiter;
					if (num != 0)
					{
						awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection("conversations")).WhereEqualsTo("type", (object)"dm").WhereArrayContains("participantIds", (object)playerId).OrderBy("lastMessageAt", true)
							.LimitedTo(50)
							.GetDocumentsAsync<FirestoreConversationDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetPlayerConversationsAsync_003Ed__13 _003CGetPlayerConversationsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreConversationDTO>>, _003CGetPlayerConversationsAsync_003Ed__13>(ref awaiter, ref _003CGetPlayerConversationsAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreConversationDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Csnapshot_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Csnapshot_003E5__1?.Documents == null || !Enumerable.Any<IDocumentSnapshot<FirestoreConversationDTO>>(_003Csnapshot_003E5__1.Documents))
					{
						result = new List<Conversation>();
					}
					else
					{
						FirestoreReadCounter.Track("GetPlayerConversations", Enumerable.Count<IDocumentSnapshot<FirestoreConversationDTO>>(_003Csnapshot_003E5__1.Documents));
						result = Enumerable.ToList<Conversation>(Enumerable.Select<IDocumentSnapshot<FirestoreConversationDTO>, Conversation>(Enumerable.Where<IDocumentSnapshot<FirestoreConversationDTO>>(_003Csnapshot_003E5__1.Documents, (Func<IDocumentSnapshot<FirestoreConversationDTO>, bool>)((IDocumentSnapshot<FirestoreConversationDTO> d) => d.Data != null)), (Func<IDocumentSnapshot<FirestoreConversationDTO>, Conversation>)((IDocumentSnapshot<FirestoreConversationDTO> d) => MapToEntity(d.Data))));
					}
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("GetPlayerConversationsAsync error: " + _003Cex_003E5__3.Message);
					result = new List<Conversation>();
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetUnreadMessageCountAsync_003Ed__10 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<int> _003C_003Et__builder;

		public string conversationId;

		public DateTimeOffset afterTimestamp;

		public int limit;

		public ChatRepository _003C_003E4__this;

		private IQuerySnapshot<FirestoreChatMessageDTO> _003Csnapshot_003E5__1;

		private IQuerySnapshot<FirestoreChatMessageDTO> _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<IQuerySnapshot<FirestoreChatMessageDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			int result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestoreChatMessageDTO>> awaiter;
					if (num != 0)
					{
						awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection("conversations").GetDocument(conversationId).GetCollection("messages")).WhereGreaterThan("createdAt", (object)afterTimestamp).LimitedTo(limit).GetDocumentsAsync<FirestoreChatMessageDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetUnreadMessageCountAsync_003Ed__10 _003CGetUnreadMessageCountAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreChatMessageDTO>>, _003CGetUnreadMessageCountAsync_003Ed__10>(ref awaiter, ref _003CGetUnreadMessageCountAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreChatMessageDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Csnapshot_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					FirestoreReadCounter.Track("UnReadMessageCount", Enumerable.Count<IDocumentSnapshot<FirestoreChatMessageDTO>>(_003Csnapshot_003E5__1.Documents));
					result = Enumerable.Count<IDocumentSnapshot<FirestoreChatMessageDTO>>(_003Csnapshot_003E5__1.Documents);
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("GetUnreadMessageCountAsync error: " + _003Cex_003E5__3.Message);
					result = 0;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSendGuildThreadMessageAsync_003Ed__18 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string guildId;

		public string threadId;

		public ChatMessage message;

		public ChatRepository _003C_003E4__this;

		private FirestoreChatMessageDTO _003Cdto_003E5__1;

		private global::System.Exception _003Cex_003E5__2;

		private TaskAwaiter<IDocumentReference> _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter<bool> awaiter;
					TaskAwaiter<IDocumentReference> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							goto IL_01ab;
						}
						_003Cdto_003E5__1 = new FirestoreChatMessageDTO
						{
							SenderId = message.SenderId,
							SenderName = message.SenderName,
							Content = message.Content,
							CreatedAt = message.CreatedAt
						};
						awaiter2 = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId).GetCollection("threads")
							.GetDocument(threadId)
							.GetCollection("messages")
							.AddDocumentAsync((object)_003Cdto_003E5__1)
							.GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CSendGuildThreadMessageAsync_003Ed__18 _003CSendGuildThreadMessageAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentReference>, _003CSendGuildThreadMessageAsync_003Ed__18>(ref awaiter2, ref _003CSendGuildThreadMessageAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentReference>);
						num = (_003C_003E1__state = -1);
					}
					awaiter2.GetResult();
					awaiter = _003C_003E4__this.UpdateGuildThreadLastMessageAsync(guildId, threadId, message.Content, message.SenderId, message.CreatedAt).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter;
						_003CSendGuildThreadMessageAsync_003Ed__18 _003CSendGuildThreadMessageAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CSendGuildThreadMessageAsync_003Ed__18>(ref awaiter, ref _003CSendGuildThreadMessageAsync_003Ed__);
						return;
					}
					goto IL_01ab;
					IL_01ab:
					awaiter.GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__2 = ex;
					Console.WriteLine("SendGuildThreadMessageAsync error: " + _003Cex_003E5__2.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSendMessageAsync_003Ed__8 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string conversationId;

		public ChatMessage message;

		public ChatRepository _003C_003E4__this;

		private FirestoreChatMessageDTO _003Cdto_003E5__1;

		private global::System.Exception _003Cex_003E5__2;

		private TaskAwaiter<IDocumentReference> _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter<bool> awaiter;
					TaskAwaiter<IDocumentReference> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							goto IL_0190;
						}
						_003Cdto_003E5__1 = new FirestoreChatMessageDTO
						{
							SenderId = message.SenderId,
							SenderName = message.SenderName,
							Content = message.Content,
							CreatedAt = message.CreatedAt
						};
						awaiter2 = _003C_003E4__this._firestore.GetCollection("conversations").GetDocument(conversationId).GetCollection("messages")
							.AddDocumentAsync((object)_003Cdto_003E5__1)
							.GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CSendMessageAsync_003Ed__8 _003CSendMessageAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentReference>, _003CSendMessageAsync_003Ed__8>(ref awaiter2, ref _003CSendMessageAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentReference>);
						num = (_003C_003E1__state = -1);
					}
					awaiter2.GetResult();
					awaiter = _003C_003E4__this.UpdateConversationLastMessageAsync(conversationId, message.Content, message.SenderId, message.CreatedAt).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter;
						_003CSendMessageAsync_003Ed__8 _003CSendMessageAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CSendMessageAsync_003Ed__8>(ref awaiter, ref _003CSendMessageAsync_003Ed__);
						return;
					}
					goto IL_0190;
					IL_0190:
					awaiter.GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__2 = ex;
					Console.WriteLine("SendMessageAsync error: " + _003Cex_003E5__2.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CUpdateConversationLastMessageAsync_003Ed__11 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string conversationId;

		public string text;

		public string senderId;

		public DateTimeOffset sentAt;

		public ChatRepository _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._firestore.GetCollection("conversations").GetDocument(conversationId).UpdateDataAsync(new Dictionary<object, object>
						{
							[(object)"lastMessageText"] = text,
							[(object)"lastMessageSenderId"] = senderId,
							[(object)"lastMessageAt"] = sentAt
						})
							.GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CUpdateConversationLastMessageAsync_003Ed__11 _003CUpdateConversationLastMessageAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CUpdateConversationLastMessageAsync_003Ed__11>(ref awaiter, ref _003CUpdateConversationLastMessageAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter)).GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__1 = ex;
					Console.WriteLine("UpdateConversationLastMessageAsync error: " + _003Cex_003E5__1.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CUpdateGuildThreadLastMessageAsync_003Ed__19 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string guildId;

		public string threadId;

		public string text;

		public string senderId;

		public DateTimeOffset sentAt;

		public ChatRepository _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(guildId).GetCollection("threads")
							.GetDocument(threadId)
							.UpdateDataAsync(new Dictionary<object, object>
							{
								[(object)"lastMessageText"] = text,
								[(object)"lastMessageSenderId"] = senderId,
								[(object)"lastMessageAt"] = sentAt
							})
							.GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CUpdateGuildThreadLastMessageAsync_003Ed__19 _003CUpdateGuildThreadLastMessageAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CUpdateGuildThreadLastMessageAsync_003Ed__19>(ref awaiter, ref _003CUpdateGuildThreadLastMessageAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter)).GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__1 = ex;
					Console.WriteLine("UpdateGuildThreadLastMessageAsync error: " + _003Cex_003E5__1.Message);
					result = false;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IFirebaseFirestore _firestore;

	private const string ConversationsCollection = "conversations";

	private const string GuildsCollection = "guilds";

	private const string ThreadsSubcollection = "threads";

	private const string MessagesSubcollection = "messages";

	private const string NewsCollection = "news";

	public ChatRepository(IFirebaseFirestore firestore)
	{
		_firestore = firestore;
	}

	[AsyncStateMachine(typeof(_003CGetOrCreateGuildConversationAsync_003Ed__7))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Conversation?> GetOrCreateGuildConversationAsync(string guildId, List<string> memberIds)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IQuerySnapshot<FirestoreConversationDTO> snapshot = await ((IQuery)_firestore.GetCollection("conversations")).WhereEqualsTo("type", (object)"guild").WhereEqualsTo("guildId", (object)guildId).LimitedTo(1)
				.GetDocumentsAsync<FirestoreConversationDTO>((Source)0);
			if (snapshot?.Documents != null && Enumerable.Any<IDocumentSnapshot<FirestoreConversationDTO>>(snapshot.Documents))
			{
				FirestoreReadCounter.Track("guild conversation", Enumerable.Count<IDocumentSnapshot<FirestoreConversationDTO>>(snapshot.Documents));
				FirestoreConversationDTO existing = Enumerable.First<IDocumentSnapshot<FirestoreConversationDTO>>(snapshot.Documents).Data;
				if (existing != null)
				{
					return MapToEntity(existing);
				}
			}
			DateTimeOffset now = DateTimeOffset.UtcNow;
			FirestoreConversationDTO dto = new FirestoreConversationDTO
			{
				Type = "guild",
				GuildId = guildId,
				ParticipantIds = memberIds,
				LastMessageText = string.Empty,
				LastMessageAt = now,
				LastMessageSenderId = string.Empty,
				CreatedAt = now
			};
			IDocumentReference docRef = await _firestore.GetCollection("conversations").AddDocumentAsync((object)dto);
			return new Conversation
			{
				Id = docRef.Id,
				Type = "guild",
				GuildId = guildId,
				ParticipantIds = memberIds,
				LastMessageText = string.Empty,
				LastMessageAt = now,
				CreatedAt = now
			};
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("GetOrCreateGuildConversationAsync error: " + ex.Message);
			return null;
		}
	}

	[AsyncStateMachine(typeof(_003CSendMessageAsync_003Ed__8))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> SendMessageAsync(string conversationId, ChatMessage message)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			FirestoreChatMessageDTO dto = new FirestoreChatMessageDTO
			{
				SenderId = message.SenderId,
				SenderName = message.SenderName,
				Content = message.Content,
				CreatedAt = message.CreatedAt
			};
			await _firestore.GetCollection("conversations").GetDocument(conversationId).GetCollection("messages")
				.AddDocumentAsync((object)dto);
			await UpdateConversationLastMessageAsync(conversationId, message.Content, message.SenderId, message.CreatedAt);
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("SendMessageAsync error: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CGetMessagesAsync_003Ed__9))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<ChatMessage>> GetMessagesAsync(string conversationId, int limit = 50, DateTimeOffset? beforeTimestamp = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IQuery baseQuery = ((IQuery)_firestore.GetCollection("conversations").GetDocument(conversationId).GetCollection("messages")).OrderBy("createdAt", true);
			IQuery query = (beforeTimestamp.HasValue ? baseQuery.WhereLessThan("createdAt", (object)beforeTimestamp.Value).LimitedTo(limit) : baseQuery.LimitedTo(limit));
			IQuerySnapshot<FirestoreChatMessageDTO> snapshot = await query.GetDocumentsAsync<FirestoreChatMessageDTO>((Source)0);
			if (snapshot?.Documents == null || !Enumerable.Any<IDocumentSnapshot<FirestoreChatMessageDTO>>(snapshot.Documents))
			{
				return new List<ChatMessage>();
			}
			FirestoreReadCounter.Track("GetMessages", Enumerable.Count<IDocumentSnapshot<FirestoreChatMessageDTO>>(snapshot.Documents));
			return Enumerable.ToList<ChatMessage>((global::System.Collections.Generic.IEnumerable<ChatMessage>)Enumerable.OrderBy<ChatMessage, DateTimeOffset>(Enumerable.Select<IDocumentSnapshot<FirestoreChatMessageDTO>, ChatMessage>(Enumerable.Where<IDocumentSnapshot<FirestoreChatMessageDTO>>(snapshot.Documents, (Func<IDocumentSnapshot<FirestoreChatMessageDTO>, bool>)((IDocumentSnapshot<FirestoreChatMessageDTO> d) => d.Data != null)), (Func<IDocumentSnapshot<FirestoreChatMessageDTO>, ChatMessage>)((IDocumentSnapshot<FirestoreChatMessageDTO> d) => new ChatMessage
			{
				Id = d.Data.Id,
				SenderId = d.Data.SenderId,
				SenderName = d.Data.SenderName,
				Content = d.Data.Content,
				CreatedAt = d.Data.CreatedAt
			})), (Func<ChatMessage, DateTimeOffset>)((ChatMessage m) => m.CreatedAt)));
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("GetMessagesAsync error: " + ex.Message);
			return new List<ChatMessage>();
		}
	}

	[AsyncStateMachine(typeof(_003CGetUnreadMessageCountAsync_003Ed__10))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<int> GetUnreadMessageCountAsync(string conversationId, DateTimeOffset afterTimestamp, int limit = 30)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IQuerySnapshot<FirestoreChatMessageDTO> snapshot = await ((IQuery)_firestore.GetCollection("conversations").GetDocument(conversationId).GetCollection("messages")).WhereGreaterThan("createdAt", (object)afterTimestamp).LimitedTo(limit).GetDocumentsAsync<FirestoreChatMessageDTO>((Source)0);
			FirestoreReadCounter.Track("UnReadMessageCount", Enumerable.Count<IDocumentSnapshot<FirestoreChatMessageDTO>>(snapshot.Documents));
			return Enumerable.Count<IDocumentSnapshot<FirestoreChatMessageDTO>>(snapshot.Documents);
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("GetUnreadMessageCountAsync error: " + ex.Message);
			return 0;
		}
	}

	[AsyncStateMachine(typeof(_003CUpdateConversationLastMessageAsync_003Ed__11))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> UpdateConversationLastMessageAsync(string conversationId, string text, string senderId, DateTimeOffset sentAt)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			await _firestore.GetCollection("conversations").GetDocument(conversationId).UpdateDataAsync(new Dictionary<object, object>
			{
				[(object)"lastMessageText"] = text,
				[(object)"lastMessageSenderId"] = senderId,
				[(object)"lastMessageAt"] = sentAt
			});
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("UpdateConversationLastMessageAsync error: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CGetOrCreateDMConversationAsync_003Ed__12))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Conversation?> GetOrCreateDMConversationAsync(string playerIdA, string playerIdB)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string playerIdB2 = playerIdB;
		try
		{
			IQuerySnapshot<FirestoreConversationDTO> snapshot = await ((IQuery)_firestore.GetCollection("conversations")).WhereEqualsTo("type", (object)"dm").WhereArrayContains("participantIds", (object)playerIdA).GetDocumentsAsync<FirestoreConversationDTO>((Source)0);
			if (snapshot?.Documents != null)
			{
				FirestoreReadCounter.Track("GetOrCreateDM", Enumerable.Count<IDocumentSnapshot<FirestoreConversationDTO>>(snapshot.Documents));
				IDocumentSnapshot<FirestoreConversationDTO> existing = Enumerable.FirstOrDefault<IDocumentSnapshot<FirestoreConversationDTO>>(snapshot.Documents, (Func<IDocumentSnapshot<FirestoreConversationDTO>, bool>)((IDocumentSnapshot<FirestoreConversationDTO> d) => d.Data != null && d.Data.ParticipantIds.Contains(playerIdB2) && d.Data.ParticipantIds.Count == 2));
				if (existing?.Data != null)
				{
					return MapToEntity(existing.Data);
				}
			}
			DateTimeOffset now = DateTimeOffset.UtcNow;
			List<string> obj = new List<string>();
			obj.Add(playerIdA);
			obj.Add(playerIdB2);
			List<string> participantIds = obj;
			FirestoreConversationDTO dto = new FirestoreConversationDTO
			{
				Type = "dm",
				ParticipantIds = participantIds,
				LastMessageText = string.Empty,
				LastMessageAt = now,
				LastMessageSenderId = string.Empty,
				CreatedAt = now
			};
			IDocumentReference docRef = await _firestore.GetCollection("conversations").AddDocumentAsync((object)dto);
			return new Conversation
			{
				Id = docRef.Id,
				Type = "dm",
				ParticipantIds = participantIds,
				LastMessageText = string.Empty,
				LastMessageAt = now,
				CreatedAt = now
			};
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("GetOrCreateDMConversationAsync error: " + ex.Message);
			return null;
		}
	}

	[AsyncStateMachine(typeof(_003CGetPlayerConversationsAsync_003Ed__13))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<Conversation>> GetPlayerConversationsAsync(string playerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IQuerySnapshot<FirestoreConversationDTO> snapshot = await ((IQuery)_firestore.GetCollection("conversations")).WhereEqualsTo("type", (object)"dm").WhereArrayContains("participantIds", (object)playerId).OrderBy("lastMessageAt", true)
				.LimitedTo(50)
				.GetDocumentsAsync<FirestoreConversationDTO>((Source)0);
			if (snapshot?.Documents == null || !Enumerable.Any<IDocumentSnapshot<FirestoreConversationDTO>>(snapshot.Documents))
			{
				return new List<Conversation>();
			}
			FirestoreReadCounter.Track("GetPlayerConversations", Enumerable.Count<IDocumentSnapshot<FirestoreConversationDTO>>(snapshot.Documents));
			return Enumerable.ToList<Conversation>(Enumerable.Select<IDocumentSnapshot<FirestoreConversationDTO>, Conversation>(Enumerable.Where<IDocumentSnapshot<FirestoreConversationDTO>>(snapshot.Documents, (Func<IDocumentSnapshot<FirestoreConversationDTO>, bool>)((IDocumentSnapshot<FirestoreConversationDTO> d) => d.Data != null)), (Func<IDocumentSnapshot<FirestoreConversationDTO>, Conversation>)((IDocumentSnapshot<FirestoreConversationDTO> d) => MapToEntity(d.Data))));
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("GetPlayerConversationsAsync error: " + ex.Message);
			return new List<Conversation>();
		}
	}

	[AsyncStateMachine(typeof(_003CGetNewsAsync_003Ed__14))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<NewsItem>> GetNewsAsync(int limit = 20)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IQuerySnapshot<FirestoreNewsDTO> snapshot = await ((IQuery)_firestore.GetCollection("news")).OrderBy("createdAt", true).LimitedTo(limit).GetDocumentsAsync<FirestoreNewsDTO>((Source)0);
			if (snapshot?.Documents == null || !Enumerable.Any<IDocumentSnapshot<FirestoreNewsDTO>>(snapshot.Documents))
			{
				return new List<NewsItem>();
			}
			DateTimeOffset now = DateTimeOffset.UtcNow;
			return Enumerable.ToList<NewsItem>(Enumerable.Where<NewsItem>(Enumerable.Select<IDocumentSnapshot<FirestoreNewsDTO>, NewsItem>(Enumerable.Where<IDocumentSnapshot<FirestoreNewsDTO>>(snapshot.Documents, (Func<IDocumentSnapshot<FirestoreNewsDTO>, bool>)((IDocumentSnapshot<FirestoreNewsDTO> d) => d.Data != null)), (Func<IDocumentSnapshot<FirestoreNewsDTO>, NewsItem>)((IDocumentSnapshot<FirestoreNewsDTO> d) => new NewsItem
			{
				Id = d.Data.Id,
				Title = d.Data.Title,
				Content = d.Data.Content,
				CreatedAt = d.Data.CreatedAt,
				ExpiresAt = d.Data.ExpiresAt
			})), (Func<NewsItem, bool>)delegate(NewsItem n)
			{
				//IL_0018: Unknown result type (might be due to invalid IL or missing references)
				//IL_001d: Unknown result type (might be due to invalid IL or missing references)
				//IL_002c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0031: Unknown result type (might be due to invalid IL or missing references)
				int result;
				if (n.ExpiresAt.HasValue)
				{
					DateTimeOffset? expiresAt = n.ExpiresAt;
					DateTimeOffset val = now;
					result = ((expiresAt.HasValue && expiresAt.GetValueOrDefault() > val) ? 1 : 0);
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			}));
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("GetNewsAsync error: " + ex.Message);
			return new List<NewsItem>();
		}
	}

	[AsyncStateMachine(typeof(_003CGetGuildThreadsAsync_003Ed__15))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<Conversation>> GetGuildThreadsAsync(string guildId, int limit = 30)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IQuerySnapshot<FirestoreGuildThreadDTO> snapshot = await ((IQuery)_firestore.GetCollection("guilds").GetDocument(guildId).GetCollection("threads")).OrderBy("lastMessageAt", true).LimitedTo(limit).GetDocumentsAsync<FirestoreGuildThreadDTO>((Source)0);
			if (snapshot?.Documents == null || !Enumerable.Any<IDocumentSnapshot<FirestoreGuildThreadDTO>>(snapshot.Documents))
			{
				return new List<Conversation>();
			}
			FirestoreReadCounter.Track("GetGuildThreads", Enumerable.Count<IDocumentSnapshot<FirestoreGuildThreadDTO>>(snapshot.Documents));
			return Enumerable.ToList<Conversation>(Enumerable.Select<IDocumentSnapshot<FirestoreGuildThreadDTO>, Conversation>(Enumerable.Where<IDocumentSnapshot<FirestoreGuildThreadDTO>>(snapshot.Documents, (Func<IDocumentSnapshot<FirestoreGuildThreadDTO>, bool>)((IDocumentSnapshot<FirestoreGuildThreadDTO> d) => d.Data != null)), (Func<IDocumentSnapshot<FirestoreGuildThreadDTO>, Conversation>)((IDocumentSnapshot<FirestoreGuildThreadDTO> d) => MapThreadToEntity(d.Data))));
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("GetGuildThreadsAsync error: " + ex.Message);
			return new List<Conversation>();
		}
	}

	[AsyncStateMachine(typeof(_003CCreateGuildThreadAsync_003Ed__16))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Conversation?> CreateGuildThreadAsync(string guildId, string subject, string icon, string createdByPlayerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			DateTimeOffset now = DateTimeOffset.UtcNow;
			FirestoreGuildThreadDTO dto = new FirestoreGuildThreadDTO
			{
				Subject = subject,
				Icon = icon,
				CreatedBy = createdByPlayerId,
				CreatedAt = now,
				LastMessageAt = now,
				LastMessageText = string.Empty,
				LastMessageSenderId = string.Empty
			};
			IDocumentReference docRef = await _firestore.GetCollection("guilds").GetDocument(guildId).GetCollection("threads")
				.AddDocumentAsync((object)dto);
			return new Conversation
			{
				Id = docRef.Id,
				Subject = subject,
				Icon = icon,
				CreatedBy = createdByPlayerId,
				LastMessageText = string.Empty,
				LastMessageAt = now,
				CreatedAt = now
			};
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("CreateGuildThreadAsync error: " + ex.Message);
			return null;
		}
	}

	[AsyncStateMachine(typeof(_003CGetGuildThreadMessagesAsync_003Ed__17))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<ChatMessage>> GetGuildThreadMessagesAsync(string guildId, string threadId, int limit, DateTimeOffset? before = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IQuery baseQuery = ((IQuery)_firestore.GetCollection("guilds").GetDocument(guildId).GetCollection("threads")
				.GetDocument(threadId)
				.GetCollection("messages")).OrderBy("createdAt", true);
			IQuery query = (before.HasValue ? baseQuery.WhereLessThan("createdAt", (object)before.Value).LimitedTo(limit) : baseQuery.LimitedTo(limit));
			IQuerySnapshot<FirestoreChatMessageDTO> snapshot = await query.GetDocumentsAsync<FirestoreChatMessageDTO>((Source)0);
			FirestoreReadCounter.Track("GetGuildThreadMessages", Enumerable.Count<IDocumentSnapshot<FirestoreChatMessageDTO>>(snapshot.Documents));
			if (snapshot?.Documents == null || !Enumerable.Any<IDocumentSnapshot<FirestoreChatMessageDTO>>(snapshot.Documents))
			{
				return new List<ChatMessage>();
			}
			return Enumerable.ToList<ChatMessage>((global::System.Collections.Generic.IEnumerable<ChatMessage>)Enumerable.OrderBy<ChatMessage, DateTimeOffset>(Enumerable.Select<IDocumentSnapshot<FirestoreChatMessageDTO>, ChatMessage>(Enumerable.Where<IDocumentSnapshot<FirestoreChatMessageDTO>>(snapshot.Documents, (Func<IDocumentSnapshot<FirestoreChatMessageDTO>, bool>)((IDocumentSnapshot<FirestoreChatMessageDTO> d) => d.Data != null)), (Func<IDocumentSnapshot<FirestoreChatMessageDTO>, ChatMessage>)((IDocumentSnapshot<FirestoreChatMessageDTO> d) => new ChatMessage
			{
				Id = d.Data.Id,
				SenderId = d.Data.SenderId,
				SenderName = d.Data.SenderName,
				Content = d.Data.Content,
				CreatedAt = d.Data.CreatedAt
			})), (Func<ChatMessage, DateTimeOffset>)((ChatMessage m) => m.CreatedAt)));
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("GetGuildThreadMessagesAsync error: " + ex.Message);
			return new List<ChatMessage>();
		}
	}

	[AsyncStateMachine(typeof(_003CSendGuildThreadMessageAsync_003Ed__18))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> SendGuildThreadMessageAsync(string guildId, string threadId, ChatMessage message)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			FirestoreChatMessageDTO dto = new FirestoreChatMessageDTO
			{
				SenderId = message.SenderId,
				SenderName = message.SenderName,
				Content = message.Content,
				CreatedAt = message.CreatedAt
			};
			await _firestore.GetCollection("guilds").GetDocument(guildId).GetCollection("threads")
				.GetDocument(threadId)
				.GetCollection("messages")
				.AddDocumentAsync((object)dto);
			await UpdateGuildThreadLastMessageAsync(guildId, threadId, message.Content, message.SenderId, message.CreatedAt);
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("SendGuildThreadMessageAsync error: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CUpdateGuildThreadLastMessageAsync_003Ed__19))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> UpdateGuildThreadLastMessageAsync(string guildId, string threadId, string text, string senderId, DateTimeOffset sentAt)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			await _firestore.GetCollection("guilds").GetDocument(guildId).GetCollection("threads")
				.GetDocument(threadId)
				.UpdateDataAsync(new Dictionary<object, object>
				{
					[(object)"lastMessageText"] = text,
					[(object)"lastMessageSenderId"] = senderId,
					[(object)"lastMessageAt"] = sentAt
				});
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("UpdateGuildThreadLastMessageAsync error: " + ex.Message);
			return false;
		}
	}

	private static Conversation MapThreadToEntity(FirestoreGuildThreadDTO dto)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		return new Conversation
		{
			Id = dto.Id,
			Subject = dto.Subject,
			Icon = dto.Icon,
			CreatedBy = dto.CreatedBy,
			LastMessageText = dto.LastMessageText,
			LastMessageAt = dto.LastMessageAt,
			LastMessageSenderId = dto.LastMessageSenderId,
			CreatedAt = dto.CreatedAt
		};
	}

	private static Conversation MapToEntity(FirestoreConversationDTO dto)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		return new Conversation
		{
			Id = dto.Id,
			Type = dto.Type,
			ParticipantIds = dto.ParticipantIds,
			GuildId = dto.GuildId,
			LastMessageText = dto.LastMessageText,
			LastMessageAt = dto.LastMessageAt,
			LastMessageSenderId = dto.LastMessageSenderId,
			CreatedAt = dto.CreatedAt,
			Subject = dto.Subject,
			CreatedBy = dto.CreatedBy
		};
	}
}
