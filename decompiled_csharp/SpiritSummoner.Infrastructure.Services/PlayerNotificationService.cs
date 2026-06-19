using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Plugin.Firebase.Firestore;
using SpiritSummoner.Application.DTOs.Session;
using SpiritSummoner.Application.Interfaces;
using SpiritSummoner.Domain.Enums.Common;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Players;

namespace SpiritSummoner.Infrastructure.Services;

public class PlayerNotificationService : IPlayerNotificationService
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public IDocumentReference notificationRef;

		public FirestorePlayerNotificationDTO notifactionFirestoreDTO;

		internal bool _003CSendAsync_003Eb__0(ITransaction transaction)
		{
			transaction.SetData(notificationRef, (object)notifactionFirestoreDTO, (SetOptions)null);
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public PlayerNotificationService _003C_003E4__this;

		public NotificationType type;

		public Dictionary<string, object> data;

		internal global::System.Threading.Tasks.Task _003CSendToManyAsync_003Eb__1(string playerId)
		{
			return _003C_003E4__this.SendAsync(playerId, type, data);
		}
	}

	[CompilerGenerated]
	private sealed class _003CSendAsync_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string targetPlayerId;

		public NotificationType type;

		public Dictionary<string, object> data;

		public PlayerNotificationService _003C_003E4__this;

		private _003C_003Ec__DisplayClass5_0 _003C_003E8__1;

		private PlayerNotificationDTO _003Cnotification_003E5__2;

		private bool _003Cconfirmed_003E5__3;

		private bool _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0 && string.IsNullOrEmpty(targetPlayerId))
				{
					Console.WriteLine("SendAsync: targetPlayerId is null or empty");
				}
				else
				{
					try
					{
						TaskAwaiter<bool> awaiter;
						if (num != 0)
						{
							_003C_003E8__1 = new _003C_003Ec__DisplayClass5_0();
							_003Cnotification_003E5__2 = CreateNotification(type, data);
							_003C_003E8__1.notifactionFirestoreDTO = _003C_003E4__this.ConvertNotificationToDTO(_003Cnotification_003E5__2);
							_003C_003E8__1.notificationRef = _003C_003E4__this._firestore.GetCollection("players").GetDocument(targetPlayerId).GetCollection("notifications")
								.GetDocument(_003C_003E8__1.notifactionFirestoreDTO.Id);
							awaiter = _003C_003E4__this._firestore.RunTransactionAsync<bool>((Func<ITransaction, bool>)delegate(ITransaction transaction)
							{
								transaction.SetData(_003C_003E8__1.notificationRef, (object)_003C_003E8__1.notifactionFirestoreDTO, (SetOptions)null);
								return true;
							}).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CSendAsync_003Ed__5 _003CSendAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CSendAsync_003Ed__5>(ref awaiter, ref _003CSendAsync_003Ed__);
								return;
							}
						}
						else
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__4 = awaiter.GetResult();
						_003Cconfirmed_003E5__3 = _003C_003Es__4;
						if (_003Cconfirmed_003E5__3)
						{
							Console.WriteLine($"Sent {type} notification to {targetPlayerId}");
						}
						else
						{
							Console.WriteLine("SendAsync error for " + targetPlayerId);
						}
						_003C_003E8__1 = null;
						_003Cnotification_003E5__2 = null;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__5 = ex;
						Console.WriteLine("SendAsync error for " + targetPlayerId + ": " + _003Cex_003E5__5.Message);
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
	private sealed class _003CSendToManyAsync_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public global::System.Collections.Generic.IEnumerable<string> targetPlayerIds;

		public NotificationType type;

		public Dictionary<string, object> data;

		public PlayerNotificationService _003C_003E4__this;

		private _003C_003Ec__DisplayClass7_0 _003C_003E8__1;

		private List<string> _003CplayerIds_003E5__2;

		private global::System.Collections.Generic.IEnumerable<global::System.Threading.Tasks.Task> _003Ctasks_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0139;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass7_0();
				_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
				_003C_003E8__1.type = type;
				_003C_003E8__1.data = data;
				global::System.Collections.Generic.IEnumerable<string> enumerable = targetPlayerIds;
				_003CplayerIds_003E5__2 = ((enumerable != null) ? Enumerable.ToList<string>(Enumerable.Where<string>(enumerable, (Func<string, bool>)((string id) => !string.IsNullOrEmpty(id)))) : null);
				if (_003CplayerIds_003E5__2 != null && _003CplayerIds_003E5__2.Count != 0)
				{
					_003Ctasks_003E5__3 = Enumerable.Select<string, global::System.Threading.Tasks.Task>((global::System.Collections.Generic.IEnumerable<string>)_003CplayerIds_003E5__2, (Func<string, global::System.Threading.Tasks.Task>)((string playerId) => _003C_003E8__1._003C_003E4__this.SendAsync(playerId, _003C_003E8__1.type, _003C_003E8__1.data)));
					awaiter = global::System.Threading.Tasks.Task.WhenAll(_003Ctasks_003E5__3).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CSendToManyAsync_003Ed__7 _003CSendToManyAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSendToManyAsync_003Ed__7>(ref awaiter, ref _003CSendToManyAsync_003Ed__);
						return;
					}
					goto IL_0139;
				}
				Console.WriteLine("SendToManyAsync: No valid player IDs provided");
				goto end_IL_0007;
				IL_0139:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine($"Sent {_003C_003E8__1.type} notification to {_003CplayerIds_003E5__2.Count} players");
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003CplayerIds_003E5__2 = null;
				_003Ctasks_003E5__3 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003CplayerIds_003E5__2 = null;
			_003Ctasks_003E5__3 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IFirebaseFirestore _firestore;

	private const string PlayerCollection = "players";

	private const string NotificationsSubcollection = "notifications";

	private const int DefaultTtlDays = 30;

	public PlayerNotificationService(IFirebaseFirestore firebaseFirestore)
	{
		_firestore = firebaseFirestore;
	}

	[AsyncStateMachine(typeof(_003CSendAsync_003Ed__5))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task SendAsync(string targetPlayerId, NotificationType type, Dictionary<string, object> data)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSendAsync_003Ed__5 _003CSendAsync_003Ed__ = new _003CSendAsync_003Ed__5();
		_003CSendAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSendAsync_003Ed__._003C_003E4__this = this;
		_003CSendAsync_003Ed__.targetPlayerId = targetPlayerId;
		_003CSendAsync_003Ed__.type = type;
		_003CSendAsync_003Ed__.data = data;
		_003CSendAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSendAsync_003Ed__._003C_003Et__builder)).Start<_003CSendAsync_003Ed__5>(ref _003CSendAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSendAsync_003Ed__._003C_003Et__builder)).Task;
	}

	private FirestorePlayerNotificationDTO ConvertNotificationToDTO(PlayerNotificationDTO notification)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		FirestorePlayerNotificationDTO firestorePlayerNotificationDTO = new FirestorePlayerNotificationDTO();
		Guid val = Guid.NewGuid();
		firestorePlayerNotificationDTO.Id = ((object)(Guid)(ref val)).ToString();
		firestorePlayerNotificationDTO.Type = ((object)notification.Type).ToString();
		firestorePlayerNotificationDTO.CreatedAt = DateTimeOffset.UtcNow;
		firestorePlayerNotificationDTO.Read = false;
		DateTimeOffset utcNow = DateTimeOffset.UtcNow;
		firestorePlayerNotificationDTO.Ttl = ((DateTimeOffset)(ref utcNow)).AddDays(30.0);
		firestorePlayerNotificationDTO.Unansweared = true;
		firestorePlayerNotificationDTO.Data = notification.Data ?? new Dictionary<string, object>();
		return firestorePlayerNotificationDTO;
	}

	[AsyncStateMachine(typeof(_003CSendToManyAsync_003Ed__7))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task SendToManyAsync(global::System.Collections.Generic.IEnumerable<string> targetPlayerIds, NotificationType type, Dictionary<string, object> data)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSendToManyAsync_003Ed__7 _003CSendToManyAsync_003Ed__ = new _003CSendToManyAsync_003Ed__7();
		_003CSendToManyAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSendToManyAsync_003Ed__._003C_003E4__this = this;
		_003CSendToManyAsync_003Ed__.targetPlayerIds = targetPlayerIds;
		_003CSendToManyAsync_003Ed__.type = type;
		_003CSendToManyAsync_003Ed__.data = data;
		_003CSendToManyAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSendToManyAsync_003Ed__._003C_003Et__builder)).Start<_003CSendToManyAsync_003Ed__7>(ref _003CSendToManyAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSendToManyAsync_003Ed__._003C_003Et__builder)).Task;
	}

	private static PlayerNotificationDTO CreateNotification(NotificationType type, Dictionary<string, object> data)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		PlayerNotificationDTO playerNotificationDTO = new PlayerNotificationDTO();
		Guid val = Guid.NewGuid();
		playerNotificationDTO.Id = ((object)(Guid)(ref val)).ToString();
		playerNotificationDTO.Type = type;
		playerNotificationDTO.CreatedAt = DateTimeOffset.UtcNow;
		playerNotificationDTO.Read = false;
		DateTimeOffset utcNow = DateTimeOffset.UtcNow;
		playerNotificationDTO.Ttl = ((DateTimeOffset)(ref utcNow)).AddDays(30.0);
		playerNotificationDTO.Data = data ?? new Dictionary<string, object>();
		return playerNotificationDTO;
	}
}
