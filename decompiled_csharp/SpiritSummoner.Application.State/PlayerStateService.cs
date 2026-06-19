using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.DTOs;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.Events;
using SpiritSummoner.Application.Interfaces;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.State;

public class PlayerStateService : IPlayerStateService, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003CApplyServiceUpdateAsync_003Ed__18 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<bool>> _003C_003Et__builder;

		public PlayerBatchUpdate batchUpdate;

		public bool immediateSync;

		public PlayerStateService _003C_003E4__this;

		private object _003C_003Es__1;

		private bool _003C_003Es__2;

		private HashSet<PlayerUpdateType> _003CchangeTypes_003E5__3;

		private Dictionary<string, SpiritUpdateType> _003CspiritChanges_003E5__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<bool> result;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003C_003Es__1 = _003C_003E4__this._stateLock;
					_003C_003Es__2 = false;
					try
					{
						Monitor.Enter(_003C_003Es__1, ref _003C_003Es__2);
						if (_003C_003E4__this._currentSession != null)
						{
							try
							{
								_003CchangeTypes_003E5__3 = new HashSet<PlayerUpdateType>();
								_003CspiritChanges_003E5__4 = new Dictionary<string, SpiritUpdateType>();
								_003C_003E4__this.ExtractChangesForEvents(batchUpdate, _003CchangeTypes_003E5__3, _003CspiritChanges_003E5__4);
								_003C_003E4__this._batchQueue.QueueUpdate(batchUpdate, immediateSync);
								_003C_003E4__this.PublishEvents(_003CchangeTypes_003E5__3, _003CspiritChanges_003E5__4, batchUpdate);
								_003CchangeTypes_003E5__3 = null;
								_003CspiritChanges_003E5__4 = null;
							}
							catch (global::System.Exception ex)
							{
								_003Cex_003E5__5 = ex;
								Console.WriteLine("Error applying service update: " + _003Cex_003E5__5.Message);
								result = global::System.Threading.Tasks.Task.FromResult<Result<bool>>(Result<bool>.FailureResult("Failed to apply service update: " + _003Cex_003E5__5.Message)).Result;
								goto end_IL_0007;
							}
							goto end_IL_002a;
						}
						result = global::System.Threading.Tasks.Task.FromResult<Result<bool>>(Result<bool>.FailureResult("No active player session")).Result;
						goto end_IL_0007;
						end_IL_002a:;
					}
					finally
					{
						if (num < 0 && _003C_003Es__2)
						{
							Monitor.Exit(_003C_003Es__1);
						}
					}
					_003C_003Es__1 = null;
					if (!immediateSync)
					{
						goto IL_01d5;
					}
					awaiter = _003C_003E4__this._batchQueue.FlushOnlineActionAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CApplyServiceUpdateAsync_003Ed__18 _003CApplyServiceUpdateAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CApplyServiceUpdateAsync_003Ed__18>(ref awaiter, ref _003CApplyServiceUpdateAsync_003Ed__);
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
				goto IL_01d5;
				IL_01d5:
				result = Result<bool>.SuccessResult(data: true);
				end_IL_0007:;
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
	private sealed class _003CApplyUpdateWithImmediateSyncAsync_003Ed__17 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<bool>> _003C_003Et__builder;

		public PlayerBatchUpdate batchUpdate;

		public PlayerStateService _003C_003E4__this;

		private object _003C_003Es__1;

		private bool _003C_003Es__2;

		private HashSet<PlayerUpdateType> _003CchangeTypes_003E5__3;

		private Dictionary<string, SpiritUpdateType> _003CspiritChanges_003E5__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_019e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_0167: Unknown result type (might be due to invalid IL or missing references)
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<bool> result;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003C_003Es__1 = _003C_003E4__this._stateLock;
					_003C_003Es__2 = false;
					try
					{
						Monitor.Enter(_003C_003Es__1, ref _003C_003Es__2);
						if (_003C_003E4__this._currentSession != null)
						{
							try
							{
								_003CchangeTypes_003E5__3 = new HashSet<PlayerUpdateType>();
								_003CspiritChanges_003E5__4 = new Dictionary<string, SpiritUpdateType>();
								_003C_003E4__this.ExtractChangesForEvents(batchUpdate, _003CchangeTypes_003E5__3, _003CspiritChanges_003E5__4);
								_003C_003E4__this._batchQueue.QueueUpdate(batchUpdate, forceSyncNow: true);
								_003C_003E4__this.PublishEvents(_003CchangeTypes_003E5__3, _003CspiritChanges_003E5__4, batchUpdate);
								_003CchangeTypes_003E5__3 = null;
								_003CspiritChanges_003E5__4 = null;
							}
							catch (global::System.Exception ex)
							{
								_003Cex_003E5__5 = ex;
								Console.WriteLine("Error applying immediate sync update: " + _003Cex_003E5__5.Message);
								result = global::System.Threading.Tasks.Task.FromResult<Result<bool>>(Result<bool>.FailureResult("Failed to sync update: " + _003Cex_003E5__5.Message)).Result;
								goto end_IL_0007;
							}
							goto end_IL_002a;
						}
						result = global::System.Threading.Tasks.Task.FromResult<Result<bool>>(Result<bool>.FailureResult("No active player session")).Result;
						goto end_IL_0007;
						end_IL_002a:;
					}
					finally
					{
						if (num < 0 && _003C_003Es__2)
						{
							Monitor.Exit(_003C_003Es__1);
						}
					}
					_003C_003Es__1 = null;
					awaiter = _003C_003E4__this._batchQueue.FlushOnlineActionAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CApplyUpdateWithImmediateSyncAsync_003Ed__17 _003CApplyUpdateWithImmediateSyncAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CApplyUpdateWithImmediateSyncAsync_003Ed__17>(ref awaiter, ref _003CApplyUpdateWithImmediateSyncAsync_003Ed__);
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
				result = Result<bool>.SuccessResult(data: true);
				end_IL_0007:;
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
	private sealed class _003CEnsureSyncedAsync_003Ed__19 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PlayerStateService _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._batchQueue.FlushOnlineActionAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CEnsureSyncedAsync_003Ed__19 _003CEnsureSyncedAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CEnsureSyncedAsync_003Ed__19>(ref awaiter, ref _003CEnsureSyncedAsync_003Ed__);
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
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
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
	private sealed class _003CSyncWithServerAsync_003Ed__21 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PlayerStateService _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00a8;
				}
				if (_003C_003E4__this._currentSession != null && !string.IsNullOrEmpty(_003C_003E4__this.CurrentPlayerId))
				{
					_003C_003E4__this._lastServerSync = DateTimeOffset.UtcNow;
					awaiter = global::System.Threading.Tasks.Task.CompletedTask.GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CSyncWithServerAsync_003Ed__21 _003CSyncWithServerAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSyncWithServerAsync_003Ed__21>(ref awaiter, ref _003CSyncWithServerAsync_003Ed__);
						return;
					}
					goto IL_00a8;
				}
				Console.WriteLine("⚠\ufe0f Cannot sync - no active session");
				goto end_IL_0007;
				IL_00a8:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
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

	private readonly ISpiritRepository _spiritRepository;

	private readonly IBatchQueueService _batchQueue;

	private readonly object _stateLock = new object();

	private Player? _currentSession;

	private string _currentRoute = "//main";

	private DateTimeOffset _lastServerSync = DateTimeOffset.MinValue;

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private EventHandler<StateChangedEventArgs>? m_StateChanged;

	public string? CurrentPlayerId => _currentSession?.PlayerID;

	public string CurrentRoute => _currentRoute;

	public event EventHandler<StateChangedEventArgs>? StateChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler<StateChangedEventArgs> val = this.m_StateChanged;
			EventHandler<StateChangedEventArgs> val2;
			do
			{
				val2 = val;
				EventHandler<StateChangedEventArgs> val3 = (EventHandler<StateChangedEventArgs>)(object)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<StateChangedEventArgs>>(ref this.m_StateChanged, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<StateChangedEventArgs> val = this.m_StateChanged;
			EventHandler<StateChangedEventArgs> val2;
			do
			{
				val2 = val;
				EventHandler<StateChangedEventArgs> val3 = (EventHandler<StateChangedEventArgs>)(object)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<StateChangedEventArgs>>(ref this.m_StateChanged, val3, val2);
			}
			while (val != val2);
		}
	}

	public PlayerStateService(ISpiritRepository spiritRepository, IBatchQueueService batchQueue)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		_spiritRepository = spiritRepository ?? throw new ArgumentNullException("spiritRepository");
		_batchQueue = batchQueue ?? throw new ArgumentNullException("batchQueue");
	}

	public void SetCurrentSession(Player session)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_currentSession = session ?? throw new ArgumentNullException("session");
		Console.WriteLine("\ud83d\udce2 PlayerStateService.SetCurrentSession: Publishing SessionStart event for player " + session.PlayerID);
		Console.WriteLine($"   Subscriber count: {(((global::System.Delegate)(object)this.StateChanged)?.GetInvocationList()?.Length).GetValueOrDefault()}");
		this.StateChanged?.Invoke((object)this, new StateChangedEventArgs(StateChangeScope.Player, "SessionStart"));
		Console.WriteLine("\ud83d\udce2 SessionStart event published successfully");
	}

	public void ClearSession()
	{
		_currentSession = null;
		_currentRoute = "//main";
		this.StateChanged?.Invoke((object)this, new StateChangedEventArgs(StateChangeScope.Player, "SessionEnd"));
	}

	public void UpdateCurrentRoute(string newRoute)
	{
		if (!(_currentRoute == newRoute))
		{
			_currentRoute = newRoute;
		}
	}

	[AsyncStateMachine(typeof(_003CApplyUpdateWithImmediateSyncAsync_003Ed__17))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<bool>> ApplyUpdateWithImmediateSyncAsync(PlayerBatchUpdate batchUpdate)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		lock (_stateLock)
		{
			if (_currentSession == null)
			{
				return global::System.Threading.Tasks.Task.FromResult<Result<bool>>(Result<bool>.FailureResult("No active player session")).Result;
			}
			try
			{
				HashSet<PlayerUpdateType> changeTypes = new HashSet<PlayerUpdateType>();
				Dictionary<string, SpiritUpdateType> spiritChanges = new Dictionary<string, SpiritUpdateType>();
				ExtractChangesForEvents(batchUpdate, changeTypes, spiritChanges);
				_batchQueue.QueueUpdate(batchUpdate, forceSyncNow: true);
				PublishEvents(changeTypes, spiritChanges, batchUpdate);
			}
			catch (global::System.Exception ex)
			{
				Console.WriteLine("Error applying immediate sync update: " + ex.Message);
				return global::System.Threading.Tasks.Task.FromResult<Result<bool>>(Result<bool>.FailureResult("Failed to sync update: " + ex.Message)).Result;
			}
		}
		await _batchQueue.FlushOnlineActionAsync();
		return Result<bool>.SuccessResult(data: true);
	}

	[AsyncStateMachine(typeof(_003CApplyServiceUpdateAsync_003Ed__18))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<bool>> ApplyServiceUpdateAsync(PlayerBatchUpdate batchUpdate, bool immediateSync = false)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		lock (_stateLock)
		{
			if (_currentSession == null)
			{
				return global::System.Threading.Tasks.Task.FromResult<Result<bool>>(Result<bool>.FailureResult("No active player session")).Result;
			}
			try
			{
				HashSet<PlayerUpdateType> changeTypes = new HashSet<PlayerUpdateType>();
				Dictionary<string, SpiritUpdateType> spiritChanges = new Dictionary<string, SpiritUpdateType>();
				ExtractChangesForEvents(batchUpdate, changeTypes, spiritChanges);
				_batchQueue.QueueUpdate(batchUpdate, immediateSync);
				PublishEvents(changeTypes, spiritChanges, batchUpdate);
			}
			catch (global::System.Exception ex)
			{
				Console.WriteLine("Error applying service update: " + ex.Message);
				return global::System.Threading.Tasks.Task.FromResult<Result<bool>>(Result<bool>.FailureResult("Failed to apply service update: " + ex.Message)).Result;
			}
		}
		if (immediateSync)
		{
			await _batchQueue.FlushOnlineActionAsync();
		}
		return Result<bool>.SuccessResult(data: true);
	}

	[AsyncStateMachine(typeof(_003CEnsureSyncedAsync_003Ed__19))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task EnsureSyncedAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CEnsureSyncedAsync_003Ed__19 _003CEnsureSyncedAsync_003Ed__ = new _003CEnsureSyncedAsync_003Ed__19();
		_003CEnsureSyncedAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CEnsureSyncedAsync_003Ed__._003C_003E4__this = this;
		_003CEnsureSyncedAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CEnsureSyncedAsync_003Ed__._003C_003Et__builder)).Start<_003CEnsureSyncedAsync_003Ed__19>(ref _003CEnsureSyncedAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CEnsureSyncedAsync_003Ed__._003C_003Et__builder)).Task;
	}

	public Result<T> ExecuteUpdate<T>(Func<Player, ValidationResult> validate, Func<Player, T> update, Func<Player, T, PlayerBatchUpdate> buildBatchUpdate)
	{
		lock (_stateLock)
		{
			if (_currentSession == null)
			{
				return Result<T>.FailureResult("No active player session");
			}
			try
			{
				ValidationResult validationResult = validate.Invoke(_currentSession);
				if (!validationResult.IsValid)
				{
					return Result<T>.FailureResult(validationResult.ErrorMessage ?? "Validation failed");
				}
				T val = update.Invoke(_currentSession);
				PlayerBatchUpdate playerBatchUpdate = buildBatchUpdate.Invoke(_currentSession, val);
				_batchQueue.QueueUpdate(playerBatchUpdate);
				HashSet<PlayerUpdateType> changeTypes = new HashSet<PlayerUpdateType>();
				Dictionary<string, SpiritUpdateType> spiritChanges = new Dictionary<string, SpiritUpdateType>();
				ExtractChangesForEvents(playerBatchUpdate, changeTypes, spiritChanges);
				PublishEvents(changeTypes, spiritChanges, playerBatchUpdate);
				return Result<T>.SuccessResult(val);
			}
			catch (global::System.Exception ex)
			{
				Console.WriteLine(" Optimistic mutation error: " + ex.Message);
				Console.WriteLine(ex.StackTrace);
				return Result<T>.FailureResult("Mutation failed: " + ex.Message);
			}
		}
	}

	[AsyncStateMachine(typeof(_003CSyncWithServerAsync_003Ed__21))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task SyncWithServerAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSyncWithServerAsync_003Ed__21 _003CSyncWithServerAsync_003Ed__ = new _003CSyncWithServerAsync_003Ed__21();
		_003CSyncWithServerAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSyncWithServerAsync_003Ed__._003C_003E4__this = this;
		_003CSyncWithServerAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSyncWithServerAsync_003Ed__._003C_003Et__builder)).Start<_003CSyncWithServerAsync_003Ed__21>(ref _003CSyncWithServerAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSyncWithServerAsync_003Ed__._003C_003Et__builder)).Task;
	}

	public Player? GetCurrentPlayer()
	{
		return _currentSession;
	}

	public PlayerSpirit? GetPlayerSpirit(string playerSpiritId)
	{
		if (_currentSession?.PlayerSpirits == null)
		{
			return null;
		}
		PlayerSpirit playerSpirit = default(PlayerSpirit);
		return _currentSession.PlayerSpirits.TryGetValue(playerSpiritId, ref playerSpirit) ? playerSpirit : null;
	}

	public global::System.Collections.Generic.IReadOnlyList<PlayerSpirit> GetAllPlayerSpirits()
	{
		Player currentSession = _currentSession;
		if (currentSession?.PlayerSpirits == null)
		{
			return global::System.Array.Empty<PlayerSpirit>();
		}
		return (global::System.Collections.Generic.IReadOnlyList<PlayerSpirit>)Enumerable.ToList<PlayerSpirit>(currentSession.PlayerSpirits.Values).AsReadOnly();
	}

	public global::System.Collections.Generic.IReadOnlyList<PlayerSpirit> GetActiveSquad()
	{
		Player currentSession = _currentSession;
		if (currentSession == null)
		{
			return global::System.Array.Empty<PlayerSpirit>();
		}
		global::System.Collections.Generic.IReadOnlyList<string> activeSquad = currentSession.ActiveSquad;
		List<PlayerSpirit> val = new List<PlayerSpirit>();
		global::System.Collections.Generic.IEnumerator<string> enumerator = ((global::System.Collections.Generic.IEnumerable<string>)activeSquad).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				string current = enumerator.Current;
				if (!string.IsNullOrEmpty(current))
				{
					PlayerSpirit playerSpirit = GetPlayerSpirit(current);
					if (playerSpirit != null)
					{
						val.Add(playerSpirit);
					}
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
		return (global::System.Collections.Generic.IReadOnlyList<PlayerSpirit>)val.AsReadOnly();
	}

	public PlayerSpirit? GetPartnerSpirit()
	{
		Player currentSession = _currentSession;
		if (currentSession == null || string.IsNullOrEmpty(currentSession.PartnerSpiritId))
		{
			return null;
		}
		return GetPlayerSpirit(currentSession.PartnerSpiritId);
	}

	public Spirit? GetSpiritTemplate(int baseSpiritId)
	{
		return _spiritRepository.GetById(baseSpiritId.ToString());
	}

	public IReadOnlyDictionary<string, List<string>> GetSquads()
	{
		Player currentSession = _currentSession;
		if (currentSession == null)
		{
			return (IReadOnlyDictionary<string, List<string>>)(object)new ReadOnlyDictionary<string, List<string>>((IDictionary<string, List<string>>)(object)new Dictionary<string, List<string>>());
		}
		return currentSession.Squads;
	}

	public global::System.Collections.Generic.IReadOnlyList<string> GetActiveSquadComposition()
	{
		Player currentSession = _currentSession;
		if (currentSession == null)
		{
			return (global::System.Collections.Generic.IReadOnlyList<string>)new List<string>();
		}
		return (global::System.Collections.Generic.IReadOnlyList<string>)currentSession.Squads[currentSession.ActiveSquadSlot.ToString()];
	}

	private void ExtractChangesForEvents(PlayerBatchUpdate batchUpdate, HashSet<PlayerUpdateType> changeTypes, Dictionary<string, SpiritUpdateType> spiritChanges)
	{
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		if (_currentSession == null)
		{
			return;
		}
		if (batchUpdate.CurrencyChanges.Count > 0)
		{
			changeTypes.Add(PlayerUpdateType.Currencies);
		}
		if (batchUpdate.InventoryItemChanges.Count > 0)
		{
			changeTypes.Add(PlayerUpdateType.Inventory);
		}
		if (batchUpdate.InventoryKeysToDelete.Count > 0)
		{
			changeTypes.Add(PlayerUpdateType.Inventory);
		}
		if (batchUpdate.ExperienceGain > 0)
		{
			changeTypes.Add(PlayerUpdateType.Experience);
		}
		if (batchUpdate.UpdateLevel)
		{
			changeTypes.Add(PlayerUpdateType.LevelUp);
		}
		if (batchUpdate.NewEP.HasValue || batchUpdate.EnergyChange != 0 || batchUpdate.SPChange != 0)
		{
			changeTypes.Add(PlayerUpdateType.Energy);
		}
		if (batchUpdate.BattleStatsChange)
		{
			changeTypes.Add(PlayerUpdateType.BattleStats);
		}
		if (batchUpdate.UpdateActiveSquadSlot && batchUpdate.NewActiveSquadSlot.HasValue)
		{
			changeTypes.Add(PlayerUpdateType.Squad);
		}
		if (batchUpdate.SquadUpdates.Count > 0)
		{
			changeTypes.Add(PlayerUpdateType.Squad);
		}
		if (batchUpdate.UpdateBattleUnit && !string.IsNullOrEmpty(batchUpdate.ActiveBattleUnitId))
		{
			changeTypes.Add(PlayerUpdateType.Partner);
		}
		if (batchUpdate.SpiritFieldUpdates.Count != 0)
		{
			Enumerator<string, PlayerSpiritFieldUpdate> enumerator = batchUpdate.SpiritFieldUpdates.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, PlayerSpiritFieldUpdate> current = enumerator.Current;
					spiritChanges[current.Key] = current.Value.UpdateType;
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator).Dispose();
			}
		}
		if (batchUpdate.TaskUpdates.Count > 0 && !string.IsNullOrEmpty(batchUpdate.QuestId))
		{
			changeTypes.Add(PlayerUpdateType.Quests);
		}
		if (batchUpdate.GuildUpdates.HasUpdates())
		{
			changeTypes.Add(PlayerUpdateType.Guild);
		}
		if (batchUpdate.ViewedShopItems != null || batchUpdate.LastShopViewedLevel.HasValue)
		{
			changeTypes.Add(PlayerUpdateType.Inventory);
		}
		if (batchUpdate.SetAccountLinked.HasValue)
		{
			changeTypes.Add(PlayerUpdateType.AccountLinked);
		}
		if (!string.IsNullOrEmpty(batchUpdate.NewPlayerIcon))
		{
			changeTypes.Add(PlayerUpdateType.PlayerIcon);
		}
		if (batchUpdate.SpiritsToAdd.Count > 0)
		{
			Enumerator<NewSpiritDTO> enumerator2 = batchUpdate.SpiritsToAdd.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					NewSpiritDTO current2 = enumerator2.Current;
					spiritChanges.Add(current2.PlayerSpiritId, SpiritUpdateType.Add);
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator2).Dispose();
			}
		}
		if (batchUpdate.SpiritsToRemove.Count <= 0)
		{
			return;
		}
		Enumerator<string> enumerator3 = batchUpdate.SpiritsToRemove.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				string current3 = enumerator3.Current;
				spiritChanges.Add(current3, SpiritUpdateType.Sold);
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator3).Dispose();
		}
	}

	private void PublishEvents(HashSet<PlayerUpdateType> changeTypes, Dictionary<string, SpiritUpdateType> spiritChanges, PlayerBatchUpdate batchUpdate)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		PlayerBatchUpdate batchUpdate2 = batchUpdate;
		if (_currentSession == null)
		{
			return;
		}
		Enumerator<PlayerUpdateType> enumerator = changeTypes.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				PlayerUpdateType changeType = enumerator.Current;
				Dictionary<string, object> changedValues = BuildChangedValues(changeType, batchUpdate2);
				MainThread.BeginInvokeOnMainThread((Action)delegate
				{
					this.StateChanged?.Invoke((object)this, new StateChangedEventArgs(StateChangeScope.Player, ((object)changeType).ToString(), batchUpdate2.QuestId, (IReadOnlyDictionary<string, object>?)(object)changedValues));
				});
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator).Dispose();
		}
		Enumerator<string, SpiritUpdateType> enumerator2 = spiritChanges.GetEnumerator();
		try
		{
			string text = default(string);
			SpiritUpdateType spiritUpdateType = default(SpiritUpdateType);
			while (enumerator2.MoveNext())
			{
				enumerator2.Current.Deconstruct(ref text, ref spiritUpdateType);
				string spiritId = text;
				SpiritUpdateType updateType = spiritUpdateType;
				MainThread.BeginInvokeOnMainThread((Action)delegate
				{
					this.StateChanged?.Invoke((object)this, new StateChangedEventArgs(StateChangeScope.Spirit, ((object)updateType).ToString(), spiritId));
				});
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator2).Dispose();
		}
	}

	private Dictionary<string, object> BuildChangedValues(PlayerUpdateType changeType, PlayerBatchUpdate batch)
	{
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		if (_currentSession == null)
		{
			return new Dictionary<string, object>();
		}
		if (1 == 0)
		{
		}
		Dictionary<string, object> result = (Dictionary<string, object>)(changeType switch
		{
			PlayerUpdateType.Currencies => new Dictionary<string, object> { ["currencies"] = _currentSession.Currencies }, 
			PlayerUpdateType.Experience => new Dictionary<string, object> { ["exp"] = _currentSession.EXP }, 
			PlayerUpdateType.LevelUp => new Dictionary<string, object>
			{
				["level"] = _currentSession.PlayerLevel,
				["exp"] = _currentSession.EXP,
				["maxExp"] = _currentSession.MaxEXP,
				["ep"] = _currentSession.EP,
				["maxEp"] = _currentSession.MaxEP,
				["sp"] = _currentSession.SP,
				["maxSp"] = _currentSession.MaxSP
			}, 
			PlayerUpdateType.Energy => new Dictionary<string, object>
			{
				["ep"] = _currentSession.EP,
				["sp"] = _currentSession.SP
			}, 
			PlayerUpdateType.BattleStats => new Dictionary<string, object>
			{
				["title"] = _currentSession.BattleStats.Title ?? "Novice",
				["wins"] = _currentSession.BattleStats.Wins,
				["losses"] = _currentSession.BattleStats.Losses,
				["score"] = _currentSession.BattleStats.Score,
				["lastScoreUpdate"] = (object)(DateTimeOffset)(((_003F?)_currentSession.BattleStats.LastScoreUpdate) ?? DateTimeOffset.Now)
			}, 
			PlayerUpdateType.Squad => new Dictionary<string, object>
			{
				["squads"] = _currentSession.Squads,
				["activeSquadSlot"] = _currentSession.ActiveSquadSlot
			}, 
			PlayerUpdateType.Partner => new Dictionary<string, object> { ["battleUnitSpiritId"] = _currentSession.PartnerSpiritId ?? string.Empty }, 
			PlayerUpdateType.Inventory => new Dictionary<string, object> { ["inventory"] = ((object)_currentSession.Inventory) ?? ((object)new Dictionary<string, Inventory>()) }, 
			PlayerUpdateType.Quests => new Dictionary<string, object>
			{
				["questId"] = batch.QuestId,
				["taskUpdates"] = batch.TaskUpdates
			}, 
			PlayerUpdateType.AccountLinked => new Dictionary<string, object> { ["isAccountLinked"] = _currentSession.IsAccountLinked }, 
			PlayerUpdateType.Guild => new Dictionary<string, object>
			{
				["guildId"] = _currentSession.GuildId ?? string.Empty,
				["guildJoinedAt"] = (object)(DateTimeOffset)(((_003F?)_currentSession.GuildJoinedAt) ?? DateTimeOffset.UtcNow),
				["guildRole"] = _currentSession.GuildRole
			}, 
			PlayerUpdateType.PlayerIcon => new Dictionary<string, object> { ["icon"] = _currentSession.PlayerIcon ?? string.Empty }, 
			_ => new Dictionary<string, object>(), 
		});
		if (1 == 0)
		{
		}
		return result;
	}

	public void Dispose()
	{
	}
}
