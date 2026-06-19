using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Plugin.Firebase.Firestore;
using SpiritSummoner.Application.DTOs.Session;
using SpiritSummoner.Application.Events;
using SpiritSummoner.Domain.Enums.Common;
using SpiritSummoner.Infrastructure.Diagnostics;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Players;

namespace SpiritSummoner.Infrastructure.FirebaseListeners;

public class PlayerNotificationListenerService : IPlayerNotificationListenerService
{
	[CompilerGenerated]
	private sealed class _003CGetNotificationHistoryAsync_003Ed__17 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<PlayerNotificationDTO>> _003C_003Et__builder;

		public string playerId;

		public int limit;

		public PlayerNotificationListenerService _003C_003E4__this;

		private IQuerySnapshot<FirestorePlayerNotificationDTO> _003Csnapshot_003E5__1;

		private IQuerySnapshot<FirestorePlayerNotificationDTO> _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<IQuerySnapshot<FirestorePlayerNotificationDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<PlayerNotificationDTO> result;
			try
			{
				if (num != 0 && string.IsNullOrEmpty(playerId))
				{
					result = new List<PlayerNotificationDTO>();
				}
				else
				{
					try
					{
						TaskAwaiter<IQuerySnapshot<FirestorePlayerNotificationDTO>> awaiter;
						if (num != 0)
						{
							awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection("players").GetDocument(playerId).GetCollection("notifications")).OrderBy("createdAt", true).LimitedTo(limit).GetDocumentsAsync<FirestorePlayerNotificationDTO>((Source)0)
								.GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CGetNotificationHistoryAsync_003Ed__17 _003CGetNotificationHistoryAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestorePlayerNotificationDTO>>, _003CGetNotificationHistoryAsync_003Ed__17>(ref awaiter, ref _003CGetNotificationHistoryAsync_003Ed__);
								return;
							}
						}
						else
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestorePlayerNotificationDTO>>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__2 = awaiter.GetResult();
						_003Csnapshot_003E5__1 = _003C_003Es__2;
						_003C_003Es__2 = null;
						if (_003Csnapshot_003E5__1?.Documents == null || !Enumerable.Any<IDocumentSnapshot<FirestorePlayerNotificationDTO>>(_003Csnapshot_003E5__1.Documents))
						{
							result = new List<PlayerNotificationDTO>();
						}
						else
						{
							FirestoreReadCounter.Track("notification history", Enumerable.Count<IDocumentSnapshot<FirestorePlayerNotificationDTO>>(_003Csnapshot_003E5__1.Documents));
							result = Enumerable.ToList<PlayerNotificationDTO>(Enumerable.Select<FirestorePlayerNotificationDTO, PlayerNotificationDTO>(Enumerable.Where<FirestorePlayerNotificationDTO>(Enumerable.Select<IDocumentSnapshot<FirestorePlayerNotificationDTO>, FirestorePlayerNotificationDTO>(_003Csnapshot_003E5__1.Documents, (Func<IDocumentSnapshot<FirestorePlayerNotificationDTO>, FirestorePlayerNotificationDTO>)((IDocumentSnapshot<FirestorePlayerNotificationDTO> d) => d.Data)), (Func<FirestorePlayerNotificationDTO, bool>)((FirestorePlayerNotificationDTO dto) => dto != null)), (Func<FirestorePlayerNotificationDTO, PlayerNotificationDTO>)_003C_003E4__this.MapFirestoreDtoToDto));
						}
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__3 = ex;
						Console.WriteLine($"GetNotificationHistoryAsync error: {_003Cex_003E5__3}");
						result = new List<PlayerNotificationDTO>();
					}
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
	private sealed class _003CGetUnAnswearedNotificationsAsync_003Ed__16 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<PlayerNotificationDTO>> _003C_003Et__builder;

		public string playerId;

		public int limit;

		public PlayerNotificationListenerService _003C_003E4__this;

		private IQuerySnapshot<FirestorePlayerNotificationDTO> _003Csnapshot_003E5__1;

		private List<PlayerNotificationDTO> _003Cnotifications_003E5__2;

		private IQuerySnapshot<FirestorePlayerNotificationDTO> _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<IQuerySnapshot<FirestorePlayerNotificationDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<PlayerNotificationDTO> result;
			try
			{
				if (num != 0 && string.IsNullOrEmpty(playerId))
				{
					result = new List<PlayerNotificationDTO>();
				}
				else
				{
					try
					{
						TaskAwaiter<IQuerySnapshot<FirestorePlayerNotificationDTO>> awaiter;
						if (num != 0)
						{
							awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection("players").GetDocument(playerId).GetCollection("notifications")).WhereEqualsTo("unansweared", (object)true).OrderBy("createdAt", true).LimitedTo(limit)
								.GetDocumentsAsync<FirestorePlayerNotificationDTO>((Source)0)
								.GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CGetUnAnswearedNotificationsAsync_003Ed__16 _003CGetUnAnswearedNotificationsAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestorePlayerNotificationDTO>>, _003CGetUnAnswearedNotificationsAsync_003Ed__16>(ref awaiter, ref _003CGetUnAnswearedNotificationsAsync_003Ed__);
								return;
							}
						}
						else
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestorePlayerNotificationDTO>>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__3 = awaiter.GetResult();
						_003Csnapshot_003E5__1 = _003C_003Es__3;
						_003C_003Es__3 = null;
						if (_003Csnapshot_003E5__1?.Documents == null || !Enumerable.Any<IDocumentSnapshot<FirestorePlayerNotificationDTO>>(_003Csnapshot_003E5__1.Documents))
						{
							result = new List<PlayerNotificationDTO>();
						}
						else
						{
							FirestoreReadCounter.Track("GetUnAnswearedNotifications", Enumerable.Count<IDocumentSnapshot<FirestorePlayerNotificationDTO>>(_003Csnapshot_003E5__1.Documents));
							_003Cnotifications_003E5__2 = Enumerable.ToList<PlayerNotificationDTO>(Enumerable.Select<FirestorePlayerNotificationDTO, PlayerNotificationDTO>(Enumerable.Where<FirestorePlayerNotificationDTO>(Enumerable.Select<IDocumentSnapshot<FirestorePlayerNotificationDTO>, FirestorePlayerNotificationDTO>(_003Csnapshot_003E5__1.Documents, (Func<IDocumentSnapshot<FirestorePlayerNotificationDTO>, FirestorePlayerNotificationDTO>)((IDocumentSnapshot<FirestorePlayerNotificationDTO> d) => d.Data)), (Func<FirestorePlayerNotificationDTO, bool>)((FirestorePlayerNotificationDTO dto) => dto != null)), (Func<FirestorePlayerNotificationDTO, PlayerNotificationDTO>)_003C_003E4__this.MapFirestoreDtoToDto));
							Console.WriteLine($"Fetched {_003Cnotifications_003E5__2.Count} unanswared guildInvites for player: {playerId}");
							result = _003Cnotifications_003E5__2;
						}
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__4 = ex;
						Console.WriteLine($"GetUnreadNotificationsAsync error: {_003Cex_003E5__4}");
						result = new List<PlayerNotificationDTO>();
					}
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
	private sealed class _003CGetUnreadNotificationsAsync_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<PlayerNotificationDTO>> _003C_003Et__builder;

		public string playerId;

		public int limit;

		public PlayerNotificationListenerService _003C_003E4__this;

		private IQuerySnapshot<FirestorePlayerNotificationDTO> _003Csnapshot_003E5__1;

		private List<PlayerNotificationDTO> _003Cnotifications_003E5__2;

		private IQuerySnapshot<FirestorePlayerNotificationDTO> _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<IQuerySnapshot<FirestorePlayerNotificationDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<PlayerNotificationDTO> result;
			try
			{
				if (num != 0 && string.IsNullOrEmpty(playerId))
				{
					result = new List<PlayerNotificationDTO>();
				}
				else
				{
					try
					{
						TaskAwaiter<IQuerySnapshot<FirestorePlayerNotificationDTO>> awaiter;
						if (num != 0)
						{
							awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection("players").GetDocument(playerId).GetCollection("notifications")).WhereEqualsTo("read", (object)false).OrderBy("createdAt", true).LimitedTo(limit)
								.GetDocumentsAsync<FirestorePlayerNotificationDTO>((Source)0)
								.GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CGetUnreadNotificationsAsync_003Ed__15 _003CGetUnreadNotificationsAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestorePlayerNotificationDTO>>, _003CGetUnreadNotificationsAsync_003Ed__15>(ref awaiter, ref _003CGetUnreadNotificationsAsync_003Ed__);
								return;
							}
						}
						else
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestorePlayerNotificationDTO>>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__3 = awaiter.GetResult();
						_003Csnapshot_003E5__1 = _003C_003Es__3;
						_003C_003Es__3 = null;
						if (_003Csnapshot_003E5__1?.Documents == null || !Enumerable.Any<IDocumentSnapshot<FirestorePlayerNotificationDTO>>(_003Csnapshot_003E5__1.Documents))
						{
							result = new List<PlayerNotificationDTO>();
						}
						else
						{
							FirestoreReadCounter.Track("GetUnReadNotifications]", Enumerable.Count<IDocumentSnapshot<FirestorePlayerNotificationDTO>>(_003Csnapshot_003E5__1.Documents));
							_003Cnotifications_003E5__2 = Enumerable.ToList<PlayerNotificationDTO>(Enumerable.Select<FirestorePlayerNotificationDTO, PlayerNotificationDTO>(Enumerable.Where<FirestorePlayerNotificationDTO>(Enumerable.Select<IDocumentSnapshot<FirestorePlayerNotificationDTO>, FirestorePlayerNotificationDTO>(_003Csnapshot_003E5__1.Documents, (Func<IDocumentSnapshot<FirestorePlayerNotificationDTO>, FirestorePlayerNotificationDTO>)((IDocumentSnapshot<FirestorePlayerNotificationDTO> d) => d.Data)), (Func<FirestorePlayerNotificationDTO, bool>)((FirestorePlayerNotificationDTO dto) => dto != null)), (Func<FirestorePlayerNotificationDTO, PlayerNotificationDTO>)_003C_003E4__this.MapFirestoreDtoToDto));
							Console.WriteLine($"Fetched {_003Cnotifications_003E5__2.Count} unread notifications for player: {playerId}");
							result = _003Cnotifications_003E5__2;
						}
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__4 = ex;
						Console.WriteLine($"GetUnreadNotificationsAsync error: {_003Cex_003E5__4}");
						result = new List<PlayerNotificationDTO>();
					}
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
	private sealed class _003CMarkAsAnswearedAsync_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string notificationId;

		public PlayerNotificationListenerService _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0 && string.IsNullOrEmpty(_003C_003E4__this._currentPlayerId))
				{
					Console.WriteLine("Cannot mark notification as answeared: No active player");
				}
				else
				{
					try
					{
						TaskAwaiter awaiter;
						if (num != 0)
						{
							awaiter = _003C_003E4__this._firestore.GetCollection("players").GetDocument(_003C_003E4__this._currentPlayerId).GetCollection("notifications")
								.GetDocument(notificationId)
								.UpdateDataAsync(new Dictionary<object, object> { [(object)"unansweared"] = false })
								.GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CMarkAsAnswearedAsync_003Ed__14 _003CMarkAsAnswearedAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CMarkAsAnswearedAsync_003Ed__14>(ref awaiter, ref _003CMarkAsAnswearedAsync_003Ed__);
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
						Console.WriteLine("Marked notification as answeared: " + notificationId);
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__1 = ex;
						Console.WriteLine($"MarkAsReadAsync error: {_003Cex_003E5__1}");
					}
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CMarkAsReadAsync_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string notificationId;

		public PlayerNotificationListenerService _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0 && string.IsNullOrEmpty(_003C_003E4__this._currentPlayerId))
				{
					Console.WriteLine("Cannot mark notification as read: No active player");
				}
				else
				{
					try
					{
						TaskAwaiter awaiter;
						if (num != 0)
						{
							awaiter = _003C_003E4__this._firestore.GetCollection("players").GetDocument(_003C_003E4__this._currentPlayerId).GetCollection("notifications")
								.GetDocument(notificationId)
								.UpdateDataAsync(new Dictionary<object, object> { [(object)"read"] = true })
								.GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CMarkAsReadAsync_003Ed__13 _003CMarkAsReadAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CMarkAsReadAsync_003Ed__13>(ref awaiter, ref _003CMarkAsReadAsync_003Ed__);
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
						Console.WriteLine("Marked notification as read: " + notificationId);
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__1 = ex;
						Console.WriteLine($"MarkAsReadAsync error: {_003Cex_003E5__1}");
					}
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IFirebaseFirestore _firestore;

	private string? _currentPlayerId;

	private global::System.IDisposable? _notificationListener;

	private readonly HashSet<string> _processedNotificationIds = new HashSet<string>(1000);

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private EventHandler<NotificationReceivedEventArgs>? m_NotificationReceived;

	public bool IsListening => _notificationListener != null;

	public event EventHandler<NotificationReceivedEventArgs>? NotificationReceived
	{
		[CompilerGenerated]
		add
		{
			EventHandler<NotificationReceivedEventArgs> val = this.m_NotificationReceived;
			EventHandler<NotificationReceivedEventArgs> val2;
			do
			{
				val2 = val;
				EventHandler<NotificationReceivedEventArgs> val3 = (EventHandler<NotificationReceivedEventArgs>)(object)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<NotificationReceivedEventArgs>>(ref this.m_NotificationReceived, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<NotificationReceivedEventArgs> val = this.m_NotificationReceived;
			EventHandler<NotificationReceivedEventArgs> val2;
			do
			{
				val2 = val;
				EventHandler<NotificationReceivedEventArgs> val3 = (EventHandler<NotificationReceivedEventArgs>)(object)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<NotificationReceivedEventArgs>>(ref this.m_NotificationReceived, val3, val2);
			}
			while (val != val2);
		}
	}

	public PlayerNotificationListenerService(IFirebaseFirestore firebaseFirestore)
	{
		_firestore = firebaseFirestore;
	}

	public void StartListener(string playerId)
	{
		if (string.IsNullOrEmpty(playerId))
		{
			Console.WriteLine("Cannot start notification listener: No player ID");
			return;
		}
		StopListener();
		_currentPlayerId = playerId;
		try
		{
			_notificationListener = ((IQuery)_firestore.GetCollection("players").GetDocument(playerId).GetCollection("notifications")).WhereEqualsTo("read", (object)false).OrderBy("createdAt", true).LimitedToLast(50)
				.AddSnapshotListener<FirestorePlayerNotificationDTO>((Action<IQuerySnapshot<FirestorePlayerNotificationDTO>>)([CompilerGenerated] (IQuerySnapshot<FirestorePlayerNotificationDTO> snapshot) =>
				{
					if (snapshot?.Documents != null && Enumerable.Any<IDocumentSnapshot<FirestorePlayerNotificationDTO>>(snapshot.Documents))
					{
						FirestoreReadCounter.Track("notification listener", Enumerable.Count<IDocumentSnapshot<FirestorePlayerNotificationDTO>>(snapshot.Documents));
						global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestorePlayerNotificationDTO>> enumerator = snapshot.Documents.GetEnumerator();
						try
						{
							while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
							{
								IDocumentSnapshot<FirestorePlayerNotificationDTO> current = enumerator.Current;
								if (current.Data != null)
								{
									ProcessNotification(current.Data);
								}
							}
						}
						finally
						{
							((global::System.IDisposable)enumerator)?.Dispose();
						}
					}
				}), (Action<global::System.Exception>)delegate(global::System.Exception error)
				{
					if (error != null)
					{
						Console.WriteLine($"Notification listener error: {error}");
					}
				}, false);
			Console.WriteLine("Started notification listener for player: " + playerId);
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine($"StartListener error: {ex}");
		}
	}

	public void StopListener()
	{
		try
		{
			_notificationListener?.Dispose();
			_notificationListener = null;
			_currentPlayerId = null;
			_processedNotificationIds.Clear();
			Console.WriteLine("Stopped notification listener");
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine($"StopListener error: {ex}");
		}
	}

	private void ProcessNotification(FirestorePlayerNotificationDTO dto)
	{
		try
		{
			if (!_processedNotificationIds.Contains(dto.Id))
			{
				_processedNotificationIds.Add(dto.Id);
				if (_processedNotificationIds.Count > 1000)
				{
					_processedNotificationIds.Clear();
				}
				PlayerNotificationDTO notification = MapFirestoreDtoToDto(dto);
				this.NotificationReceived?.Invoke((object)this, new NotificationReceivedEventArgs
				{
					Notification = notification
				});
			}
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine($"ProcessNotification error: {ex}");
		}
	}

	[AsyncStateMachine(typeof(_003CMarkAsReadAsync_003Ed__13))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task MarkAsReadAsync(string notificationId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CMarkAsReadAsync_003Ed__13 _003CMarkAsReadAsync_003Ed__ = new _003CMarkAsReadAsync_003Ed__13();
		_003CMarkAsReadAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CMarkAsReadAsync_003Ed__._003C_003E4__this = this;
		_003CMarkAsReadAsync_003Ed__.notificationId = notificationId;
		_003CMarkAsReadAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CMarkAsReadAsync_003Ed__._003C_003Et__builder)).Start<_003CMarkAsReadAsync_003Ed__13>(ref _003CMarkAsReadAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CMarkAsReadAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CMarkAsAnswearedAsync_003Ed__14))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task MarkAsAnswearedAsync(string notificationId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CMarkAsAnswearedAsync_003Ed__14 _003CMarkAsAnswearedAsync_003Ed__ = new _003CMarkAsAnswearedAsync_003Ed__14();
		_003CMarkAsAnswearedAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CMarkAsAnswearedAsync_003Ed__._003C_003E4__this = this;
		_003CMarkAsAnswearedAsync_003Ed__.notificationId = notificationId;
		_003CMarkAsAnswearedAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CMarkAsAnswearedAsync_003Ed__._003C_003Et__builder)).Start<_003CMarkAsAnswearedAsync_003Ed__14>(ref _003CMarkAsAnswearedAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CMarkAsAnswearedAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGetUnreadNotificationsAsync_003Ed__15))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<PlayerNotificationDTO>> GetUnreadNotificationsAsync(string playerId, int limit = 50)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(playerId))
		{
			return new List<PlayerNotificationDTO>();
		}
		try
		{
			IQuerySnapshot<FirestorePlayerNotificationDTO> snapshot = await ((IQuery)_firestore.GetCollection("players").GetDocument(playerId).GetCollection("notifications")).WhereEqualsTo("read", (object)false).OrderBy("createdAt", true).LimitedTo(limit)
				.GetDocumentsAsync<FirestorePlayerNotificationDTO>((Source)0);
			if (snapshot?.Documents == null || !Enumerable.Any<IDocumentSnapshot<FirestorePlayerNotificationDTO>>(snapshot.Documents))
			{
				return new List<PlayerNotificationDTO>();
			}
			FirestoreReadCounter.Track("GetUnReadNotifications]", Enumerable.Count<IDocumentSnapshot<FirestorePlayerNotificationDTO>>(snapshot.Documents));
			List<PlayerNotificationDTO> notifications = Enumerable.ToList<PlayerNotificationDTO>(Enumerable.Select<FirestorePlayerNotificationDTO, PlayerNotificationDTO>(Enumerable.Where<FirestorePlayerNotificationDTO>(Enumerable.Select<IDocumentSnapshot<FirestorePlayerNotificationDTO>, FirestorePlayerNotificationDTO>(snapshot.Documents, (Func<IDocumentSnapshot<FirestorePlayerNotificationDTO>, FirestorePlayerNotificationDTO>)((IDocumentSnapshot<FirestorePlayerNotificationDTO> d) => d.Data)), (Func<FirestorePlayerNotificationDTO, bool>)((FirestorePlayerNotificationDTO dto) => dto != null)), (Func<FirestorePlayerNotificationDTO, PlayerNotificationDTO>)MapFirestoreDtoToDto));
			Console.WriteLine($"Fetched {notifications.Count} unread notifications for player: {playerId}");
			return notifications;
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine($"GetUnreadNotificationsAsync error: {ex}");
			return new List<PlayerNotificationDTO>();
		}
	}

	[AsyncStateMachine(typeof(_003CGetUnAnswearedNotificationsAsync_003Ed__16))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<PlayerNotificationDTO>> GetUnAnswearedNotificationsAsync(string playerId, int limit = 50)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(playerId))
		{
			return new List<PlayerNotificationDTO>();
		}
		try
		{
			IQuerySnapshot<FirestorePlayerNotificationDTO> snapshot = await ((IQuery)_firestore.GetCollection("players").GetDocument(playerId).GetCollection("notifications")).WhereEqualsTo("unansweared", (object)true).OrderBy("createdAt", true).LimitedTo(limit)
				.GetDocumentsAsync<FirestorePlayerNotificationDTO>((Source)0);
			if (snapshot?.Documents == null || !Enumerable.Any<IDocumentSnapshot<FirestorePlayerNotificationDTO>>(snapshot.Documents))
			{
				return new List<PlayerNotificationDTO>();
			}
			FirestoreReadCounter.Track("GetUnAnswearedNotifications", Enumerable.Count<IDocumentSnapshot<FirestorePlayerNotificationDTO>>(snapshot.Documents));
			List<PlayerNotificationDTO> notifications = Enumerable.ToList<PlayerNotificationDTO>(Enumerable.Select<FirestorePlayerNotificationDTO, PlayerNotificationDTO>(Enumerable.Where<FirestorePlayerNotificationDTO>(Enumerable.Select<IDocumentSnapshot<FirestorePlayerNotificationDTO>, FirestorePlayerNotificationDTO>(snapshot.Documents, (Func<IDocumentSnapshot<FirestorePlayerNotificationDTO>, FirestorePlayerNotificationDTO>)((IDocumentSnapshot<FirestorePlayerNotificationDTO> d) => d.Data)), (Func<FirestorePlayerNotificationDTO, bool>)((FirestorePlayerNotificationDTO dto) => dto != null)), (Func<FirestorePlayerNotificationDTO, PlayerNotificationDTO>)MapFirestoreDtoToDto));
			Console.WriteLine($"Fetched {notifications.Count} unanswared guildInvites for player: {playerId}");
			return notifications;
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine($"GetUnreadNotificationsAsync error: {ex}");
			return new List<PlayerNotificationDTO>();
		}
	}

	[AsyncStateMachine(typeof(_003CGetNotificationHistoryAsync_003Ed__17))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<PlayerNotificationDTO>> GetNotificationHistoryAsync(string playerId, int limit = 50)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(playerId))
		{
			return new List<PlayerNotificationDTO>();
		}
		try
		{
			IQuerySnapshot<FirestorePlayerNotificationDTO> snapshot = await ((IQuery)_firestore.GetCollection("players").GetDocument(playerId).GetCollection("notifications")).OrderBy("createdAt", true).LimitedTo(limit).GetDocumentsAsync<FirestorePlayerNotificationDTO>((Source)0);
			if (snapshot?.Documents == null || !Enumerable.Any<IDocumentSnapshot<FirestorePlayerNotificationDTO>>(snapshot.Documents))
			{
				return new List<PlayerNotificationDTO>();
			}
			FirestoreReadCounter.Track("notification history", Enumerable.Count<IDocumentSnapshot<FirestorePlayerNotificationDTO>>(snapshot.Documents));
			return Enumerable.ToList<PlayerNotificationDTO>(Enumerable.Select<FirestorePlayerNotificationDTO, PlayerNotificationDTO>(Enumerable.Where<FirestorePlayerNotificationDTO>(Enumerable.Select<IDocumentSnapshot<FirestorePlayerNotificationDTO>, FirestorePlayerNotificationDTO>(snapshot.Documents, (Func<IDocumentSnapshot<FirestorePlayerNotificationDTO>, FirestorePlayerNotificationDTO>)((IDocumentSnapshot<FirestorePlayerNotificationDTO> d) => d.Data)), (Func<FirestorePlayerNotificationDTO, bool>)((FirestorePlayerNotificationDTO dto) => dto != null)), (Func<FirestorePlayerNotificationDTO, PlayerNotificationDTO>)MapFirestoreDtoToDto));
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine($"GetNotificationHistoryAsync error: {ex}");
			return new List<PlayerNotificationDTO>();
		}
	}

	private PlayerNotificationDTO MapFirestoreDtoToDto(FirestorePlayerNotificationDTO firestoreDto)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		NotificationType notificationType = default(NotificationType);
		return new PlayerNotificationDTO
		{
			Id = firestoreDto.Id,
			Type = (global::System.Enum.TryParse<NotificationType>(firestoreDto.Type, ref notificationType) ? notificationType : NotificationType.RewardAvailable),
			CreatedAt = firestoreDto.CreatedAt,
			Read = firestoreDto.Read,
			Ttl = firestoreDto.Ttl,
			Unansweared = firestoreDto.Unansweared,
			Data = new Dictionary<string, object>((IDictionary<string, object>)(object)firestoreDto.Data)
		};
	}
}
