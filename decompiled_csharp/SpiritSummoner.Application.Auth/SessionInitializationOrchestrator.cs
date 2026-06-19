using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Plugin.Firebase.Firestore;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.Interfaces;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Contracts;
using SpiritSummoner.Infrastructure.Diagnostics;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Players;

namespace SpiritSummoner.Application.Auth;

public class SessionInitializationOrchestrator : ISessionInitializationOrchestrator
{
	[CompilerGenerated]
	private sealed class _003CInitializeSessionAsync_003Ed__11 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<Player>> _003C_003Et__builder;

		public string userId;

		public SessionInitializationOrchestrator _003C_003E4__this;

		private Player _003Cplayer_003E5__1;

		private Player _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<Player?> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0217: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0224: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0352: Unknown result type (might be due to invalid IL or missing references)
			//IL_0357: Unknown result type (might be due to invalid IL or missing references)
			//IL_035f: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0319: Unknown result type (might be due to invalid IL or missing references)
			//IL_031e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0333: Unknown result type (might be due to invalid IL or missing references)
			//IL_0335: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01de: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<Player> result;
			try
			{
				if ((uint)num > 5u)
				{
				}
				try
				{
					TaskAwaiter awaiter6;
					TaskAwaiter awaiter5;
					TaskAwaiter awaiter4;
					TaskAwaiter<Player> awaiter3;
					TaskAwaiter awaiter2;
					TaskAwaiter awaiter;
					switch (num)
					{
					default:
						awaiter6 = _003C_003E4__this._batchQueue.WaitUntilInitializedAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter6)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter6;
							_003CInitializeSessionAsync_003Ed__11 _003CInitializeSessionAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CInitializeSessionAsync_003Ed__11>(ref awaiter6, ref _003CInitializeSessionAsync_003Ed__);
							return;
						}
						goto IL_00af;
					case 0:
						awaiter6 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_00af;
					case 1:
						awaiter5 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0122;
					case 2:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_019c;
					case 3:
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<Player>);
						num = (_003C_003E1__state = -1);
						goto IL_0233;
					case 4:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0300;
					case 5:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_0300:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						awaiter = _003C_003E4__this.WriteActiveSessionIdAsync(userId).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 5);
							_003C_003Eu__1 = awaiter;
							_003CInitializeSessionAsync_003Ed__11 _003CInitializeSessionAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CInitializeSessionAsync_003Ed__11>(ref awaiter, ref _003CInitializeSessionAsync_003Ed__);
							return;
						}
						break;
						IL_00af:
						((TaskAwaiter)(ref awaiter6)).GetResult();
						goto IL_01a5;
						IL_01a5:
						if (_003C_003E4__this._batchQueue.HasPendingUpdates)
						{
							awaiter5 = _003C_003E4__this._batchQueue.FlushQueueAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter5;
								_003CInitializeSessionAsync_003Ed__11 _003CInitializeSessionAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CInitializeSessionAsync_003Ed__11>(ref awaiter5, ref _003CInitializeSessionAsync_003Ed__);
								return;
							}
							goto IL_0122;
						}
						awaiter3 = _003C_003E4__this._playerService.AuthenticateAsync(string.Empty, string.Empty, userId).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__2 = awaiter3;
							_003CInitializeSessionAsync_003Ed__11 _003CInitializeSessionAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Player>, _003CInitializeSessionAsync_003Ed__11>(ref awaiter3, ref _003CInitializeSessionAsync_003Ed__);
							return;
						}
						goto IL_0233;
						IL_019c:
						((TaskAwaiter)(ref awaiter4)).GetResult();
						goto IL_01a5;
						IL_0122:
						((TaskAwaiter)(ref awaiter5)).GetResult();
						if (_003C_003E4__this._batchQueue.HasPendingUpdates)
						{
							awaiter4 = global::System.Threading.Tasks.Task.Delay(100).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__1 = awaiter4;
								_003CInitializeSessionAsync_003Ed__11 _003CInitializeSessionAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CInitializeSessionAsync_003Ed__11>(ref awaiter4, ref _003CInitializeSessionAsync_003Ed__);
								return;
							}
							goto IL_019c;
						}
						goto IL_01a5;
						IL_0233:
						_003C_003Es__2 = awaiter3.GetResult();
						_003Cplayer_003E5__1 = _003C_003Es__2;
						_003C_003Es__2 = null;
						if (_003Cplayer_003E5__1 == null)
						{
							result = Result<Player>.FailureResult("Player data not found for authenticated user");
						}
						else
						{
							if (!string.IsNullOrEmpty(_003Cplayer_003E5__1.Playername))
							{
								awaiter2 = _003C_003E4__this.ReconcileAccountLinkingStatusAsync(_003Cplayer_003E5__1).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 4);
									_003C_003Eu__1 = awaiter2;
									_003CInitializeSessionAsync_003Ed__11 _003CInitializeSessionAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CInitializeSessionAsync_003Ed__11>(ref awaiter2, ref _003CInitializeSessionAsync_003Ed__);
									return;
								}
								goto IL_0300;
							}
							result = Result<Player>.FailureResult("Player data is invalid (missing username)");
						}
						goto end_IL_0011;
					}
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003C_003E4__this._playerStateService.SetCurrentSession(_003Cplayer_003E5__1);
					FirestoreReadCounter.LogSummary();
					result = Result<Player>.SuccessResult(_003Cplayer_003E5__1);
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					result = Result<Player>.FailureResult("Failed to initialize session: " + _003Cex_003E5__3.Message);
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
	private sealed class _003CReconcileLocalStateAsync_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<Player>> _003C_003Et__builder;

		public string userId;

		public SessionInitializationOrchestrator _003C_003E4__this;

		private Player _003Cplayer_003E5__1;

		private Player _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<Player?> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<Player> result;
			try
			{
				if ((uint)num > 2u)
				{
				}
				try
				{
					TaskAwaiter awaiter3;
					TaskAwaiter<Player> awaiter2;
					TaskAwaiter awaiter;
					switch (num)
					{
					default:
						awaiter3 = _003C_003E4__this._batchQueue.WaitUntilInitializedAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CReconcileLocalStateAsync_003Ed__15 _003CReconcileLocalStateAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CReconcileLocalStateAsync_003Ed__15>(ref awaiter3, ref _003CReconcileLocalStateAsync_003Ed__);
							return;
						}
						goto IL_0094;
					case 0:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0094;
					case 1:
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<Player>);
						num = (_003C_003E1__state = -1);
						goto IL_0111;
					case 2:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_0111:
						_003C_003Es__2 = awaiter2.GetResult();
						_003Cplayer_003E5__1 = _003C_003Es__2;
						_003C_003Es__2 = null;
						if (_003Cplayer_003E5__1 == null)
						{
							result = Result<Player>.FailureResult("Player data not found for authenticated user");
						}
						else
						{
							if (!string.IsNullOrEmpty(_003Cplayer_003E5__1.Playername))
							{
								awaiter = _003C_003E4__this.ReconcileAccountLinkingStatusAsync(_003Cplayer_003E5__1).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__1 = awaiter;
									_003CReconcileLocalStateAsync_003Ed__15 _003CReconcileLocalStateAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CReconcileLocalStateAsync_003Ed__15>(ref awaiter, ref _003CReconcileLocalStateAsync_003Ed__);
									return;
								}
								break;
							}
							result = Result<Player>.FailureResult("Player data is invalid (missing username)");
						}
						goto end_IL_0011;
						IL_0094:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						awaiter2 = _003C_003E4__this._playerService.AuthenticateAsync(string.Empty, string.Empty, userId).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter2;
							_003CReconcileLocalStateAsync_003Ed__15 _003CReconcileLocalStateAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Player>, _003CReconcileLocalStateAsync_003Ed__15>(ref awaiter2, ref _003CReconcileLocalStateAsync_003Ed__);
							return;
						}
						goto IL_0111;
					}
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003C_003E4__this._playerStateService.SetCurrentSession(_003Cplayer_003E5__1);
					result = Result<Player>.SuccessResult(_003Cplayer_003E5__1);
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					result = Result<Player>.FailureResult("Failed to reconcile local state: " + _003Cex_003E5__3.Message);
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
	private sealed class _003CWriteActiveSessionIdAsync_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string userId;

		public SessionInitializationOrchestrator _003C_003E4__this;

		private IDocumentReference _003CsessionRef_003E5__1;

		private IDocumentSnapshot<FirestoreActiveSessionDTO> _003Csnapshot_003E5__2;

		private DateTimeOffset _003CserverTime_003E5__3;

		private IDocumentSnapshot<FirestoreActiveSessionDTO> _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<IDocumentSnapshot<FirestoreActiveSessionDTO>> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 1u)
				{
					SessionInitializationOrchestrator sessionInitializationOrchestrator = _003C_003E4__this;
					Guid val = Guid.NewGuid();
					sessionInitializationOrchestrator.CurrentSessionId = ((object)(Guid)(ref val)).ToString();
				}
				try
				{
					TaskAwaiter<IDocumentSnapshot<FirestoreActiveSessionDTO>> awaiter;
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<IDocumentSnapshot<FirestoreActiveSessionDTO>>);
							num = (_003C_003E1__state = -1);
							goto IL_0174;
						}
						_003CsessionRef_003E5__1 = _003C_003E4__this._firestore.GetCollection("players").GetDocument(userId).GetCollection("sessions")
							.GetDocument("active");
						IDocumentReference obj = _003CsessionRef_003E5__1;
						Dictionary<object, object> obj2 = new Dictionary<object, object>();
						obj2.Add((object)"sessionId", (object)_003C_003E4__this.CurrentSessionId);
						obj2.Add((object)"serverTime", (object)FieldValue.ServerTimestamp());
						awaiter2 = obj.SetDataAsync(obj2, (SetOptions)null).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CWriteActiveSessionIdAsync_003Ed__14 _003CWriteActiveSessionIdAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CWriteActiveSessionIdAsync_003Ed__14>(ref awaiter2, ref _003CWriteActiveSessionIdAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter2)).GetResult();
					awaiter = _003CsessionRef_003E5__1.GetDocumentSnapshotAsync<FirestoreActiveSessionDTO>((Source)0).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter;
						_003CWriteActiveSessionIdAsync_003Ed__14 _003CWriteActiveSessionIdAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestoreActiveSessionDTO>>, _003CWriteActiveSessionIdAsync_003Ed__14>(ref awaiter, ref _003CWriteActiveSessionIdAsync_003Ed__);
						return;
					}
					goto IL_0174;
					IL_01fe:
					Console.WriteLine("SessionInitializationOrchestrator: Wrote sessionId for " + userId);
					_003CsessionRef_003E5__1 = null;
					_003Csnapshot_003E5__2 = null;
					goto end_IL_0030;
					IL_0174:
					_003C_003Es__4 = awaiter.GetResult();
					_003Csnapshot_003E5__2 = _003C_003Es__4;
					_003C_003Es__4 = null;
					DateTimeOffset? val2 = _003Csnapshot_003E5__2.Data?.ServerTime;
					if (val2.HasValue)
					{
						_003CserverTime_003E5__3 = val2.GetValueOrDefault();
						if (true)
						{
							_003C_003E4__this._serverTimeProvider.SetServerTime(_003CserverTime_003E5__3);
							goto IL_01fe;
						}
					}
					Console.WriteLine("SessionInitializationOrchestrator: ServerTime field missing from session doc — falling back to device clock for regen");
					goto IL_01fe;
					end_IL_0030:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					Console.WriteLine("SessionInitializationOrchestrator: Failed to write activeSessionId: " + _003Cex_003E5__5.Message);
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

	private readonly IPlayerRepository _playerService;

	private readonly IPlayerStateService _playerStateService;

	private readonly IAuthService _authService;

	private readonly IFirebaseFirestore _firestore;

	private readonly IBatchQueueService _batchQueue;

	private readonly IServerTimeProvider _serverTimeProvider;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? CurrentSessionId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	public SessionInitializationOrchestrator(IPlayerRepository playerService, IPlayerStateService playerStateService, IAuthService authService, IFirebaseFirestore firestore, IBatchQueueService batchQueue, IServerTimeProvider serverTimeProvider)
	{
		_playerService = playerService;
		_playerStateService = playerStateService;
		_authService = authService;
		_firestore = firestore;
		_batchQueue = batchQueue;
		_serverTimeProvider = serverTimeProvider;
	}

	[AsyncStateMachine(typeof(_003CInitializeSessionAsync_003Ed__11))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<Player>> InitializeSessionAsync(string userId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			await _batchQueue.WaitUntilInitializedAsync();
			while (_batchQueue.HasPendingUpdates)
			{
				await _batchQueue.FlushQueueAsync();
				if (_batchQueue.HasPendingUpdates)
				{
					await global::System.Threading.Tasks.Task.Delay(100);
				}
			}
			Player player = await _playerService.AuthenticateAsync(string.Empty, string.Empty, userId);
			if (player == null)
			{
				return Result<Player>.FailureResult("Player data not found for authenticated user");
			}
			if (string.IsNullOrEmpty(player.Playername))
			{
				return Result<Player>.FailureResult("Player data is invalid (missing username)");
			}
			await ReconcileAccountLinkingStatusAsync(player);
			await WriteActiveSessionIdAsync(userId);
			_playerStateService.SetCurrentSession(player);
			FirestoreReadCounter.LogSummary();
			return Result<Player>.SuccessResult(player);
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			return Result<Player>.FailureResult("Failed to initialize session: " + ex.Message);
		}
	}

	public bool IsSessionValid()
	{
		Player currentPlayer = _playerStateService.GetCurrentPlayer();
		return currentPlayer != null && !string.IsNullOrEmpty(currentPlayer.PlayerID);
	}

	public void ClearSession()
	{
		CurrentSessionId = null;
		_playerStateService.ClearSession();
	}

	[AsyncStateMachine(typeof(_003CWriteActiveSessionIdAsync_003Ed__14))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task WriteActiveSessionIdAsync(string userId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CWriteActiveSessionIdAsync_003Ed__14 _003CWriteActiveSessionIdAsync_003Ed__ = new _003CWriteActiveSessionIdAsync_003Ed__14();
		_003CWriteActiveSessionIdAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CWriteActiveSessionIdAsync_003Ed__._003C_003E4__this = this;
		_003CWriteActiveSessionIdAsync_003Ed__.userId = userId;
		_003CWriteActiveSessionIdAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CWriteActiveSessionIdAsync_003Ed__._003C_003Et__builder)).Start<_003CWriteActiveSessionIdAsync_003Ed__14>(ref _003CWriteActiveSessionIdAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CWriteActiveSessionIdAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CReconcileLocalStateAsync_003Ed__15))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<Player>> ReconcileLocalStateAsync(string userId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			await _batchQueue.WaitUntilInitializedAsync();
			Player player = await _playerService.AuthenticateAsync(string.Empty, string.Empty, userId);
			if (player == null)
			{
				return Result<Player>.FailureResult("Player data not found for authenticated user");
			}
			if (string.IsNullOrEmpty(player.Playername))
			{
				return Result<Player>.FailureResult("Player data is invalid (missing username)");
			}
			await ReconcileAccountLinkingStatusAsync(player);
			_playerStateService.SetCurrentSession(player);
			return Result<Player>.SuccessResult(player);
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			return Result<Player>.FailureResult("Failed to reconcile local state: " + ex.Message);
		}
	}

	private global::System.Threading.Tasks.Task ReconcileAccountLinkingStatusAsync(Player player)
	{
		if (!_authService.IsCurrentUserAnonymous && !player.IsAccountLinked)
		{
			Console.WriteLine("SessionInitializationOrchestrator: Reconciling account linking status - Firebase is linked but Firestore is not");
			player.SetAccountLinked(isLinked: true);
			_playerService.BatchUpdatePlayerAsync(new PlayerBatchUpdate
			{
				PlayerId = player.PlayerID,
				SetAccountLinked = true
			});
			Console.WriteLine("SessionInitializationOrchestrator: Account linking status reconciled");
		}
		return global::System.Threading.Tasks.Task.CompletedTask;
	}
}
