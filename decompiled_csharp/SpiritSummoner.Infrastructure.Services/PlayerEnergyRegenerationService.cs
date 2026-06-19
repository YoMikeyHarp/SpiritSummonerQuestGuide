using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui.Dispatching;
using SpiritSummoner.Application.Events;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Players;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Infrastructure.Contracts;

namespace SpiritSummoner.Infrastructure.Services;

public class PlayerEnergyRegenerationService : IPlayerEnergyRegenerationService, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003CCalculateOfflineRegenerationAsync_003Ed__20 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PlayerEnergyRegenerationService _003C_003E4__this;

		private DateTimeOffset _003Cnow_003E5__1;

		private Result<OfflineRegenerationResponse> _003Cresult_003E5__2;

		private void MoveNext()
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				_003Cnow_003E5__1 = _003C_003E4__this._serverTimeProvider.GetCurrentServerTime();
				_003Cresult_003E5__2 = _003C_003E4__this._regenerateUseCase.CalculateOfflineRegeneration(_003Cnow_003E5__1);
				if (_003Cresult_003E5__2.Success && _003Cresult_003E5__2.Data != null)
				{
					_003C_003E4__this._nextEpTick = _003Cresult_003E5__2.Data.NextEpTick;
					_003C_003E4__this._nextSpTick = _003Cresult_003E5__2.Data.NextSpTick;
					Console.WriteLine($"Offline regeneration complete: EP={_003Cresult_003E5__2.Data.CurrentEP}/{_003Cresult_003E5__2.Data.MaxEP} (+{_003Cresult_003E5__2.Data.EPGained}), SP={_003Cresult_003E5__2.Data.CurrentSP}/{_003Cresult_003E5__2.Data.MaxSP} (+{_003Cresult_003E5__2.Data.SPGained})");
				}
				else
				{
					Console.WriteLine("Offline regeneration failed: " + _003Cresult_003E5__2.ErrorMessage);
				}
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cresult_003E5__2 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cresult_003E5__2 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CInitializeRegenerationAsync_003Ed__19 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PlayerEnergyRegenerationService _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0 || (!_003C_003E4__this._isRegenerating && _003C_003E4__this._playerState.CurrentPlayerId != null))
				{
					try
					{
						TaskAwaiter awaiter;
						if (num != 0)
						{
							awaiter = _003C_003E4__this.CalculateOfflineRegenerationAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CInitializeRegenerationAsync_003Ed__19 _003CInitializeRegenerationAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CInitializeRegenerationAsync_003Ed__19>(ref awaiter, ref _003CInitializeRegenerationAsync_003Ed__);
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
						_003C_003E4__this.StartRegeneration();
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__1 = ex;
						Console.WriteLine("Error initializing regeneration: " + _003Cex_003E5__1.Message);
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
	private sealed class _003CRefreshAsync_003Ed__22 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PlayerEnergyRegenerationService _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
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
				if (_003C_003E4__this._playerState.CurrentPlayerId != null)
				{
					Console.WriteLine("\ud83d\udd04 RefreshAsync: re-syncing regeneration after resume");
					_003C_003E4__this.StopRegeneration();
					awaiter = _003C_003E4__this.InitializeRegenerationAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CRefreshAsync_003Ed__22 _003CRefreshAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRefreshAsync_003Ed__22>(ref awaiter, ref _003CRefreshAsync_003Ed__);
						return;
					}
					goto IL_00a8;
				}
				Console.WriteLine("\ud83d\udd04 RefreshAsync: no active session, skipping");
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

	private readonly IPlayerStateService _playerState;

	private readonly RegeneratePlayerEnergyUseCase _regenerateUseCase;

	private readonly IServerTimeProvider _serverTimeProvider;

	private IDispatcherTimer? _epTimer;

	private IDispatcherTimer? _spTimer;

	private IDispatcherTimer? _uiUpdateTimer;

	private DateTimeOffset _nextEpTick;

	private DateTimeOffset _nextSpTick;

	private bool _isRegenerating;

	private bool _disposed;

	private readonly object _epLock = new object();

	private readonly object _spLock = new object();

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private EventHandler<RegenerationCooldownEventArgs>? m_CooldownTick;

	public bool IsRegenerating => _isRegenerating;

	public event EventHandler<RegenerationCooldownEventArgs>? CooldownTick
	{
		[CompilerGenerated]
		add
		{
			EventHandler<RegenerationCooldownEventArgs> val = this.m_CooldownTick;
			EventHandler<RegenerationCooldownEventArgs> val2;
			do
			{
				val2 = val;
				EventHandler<RegenerationCooldownEventArgs> val3 = (EventHandler<RegenerationCooldownEventArgs>)(object)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<RegenerationCooldownEventArgs>>(ref this.m_CooldownTick, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<RegenerationCooldownEventArgs> val = this.m_CooldownTick;
			EventHandler<RegenerationCooldownEventArgs> val2;
			do
			{
				val2 = val;
				EventHandler<RegenerationCooldownEventArgs> val3 = (EventHandler<RegenerationCooldownEventArgs>)(object)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<RegenerationCooldownEventArgs>>(ref this.m_CooldownTick, val3, val2);
			}
			while (val != val2);
		}
	}

	public PlayerEnergyRegenerationService(IPlayerStateService playerState, RegeneratePlayerEnergyUseCase regenerateUseCase, IServerTimeProvider serverTimeProvider)
	{
		_playerState = playerState;
		_regenerateUseCase = regenerateUseCase;
		_serverTimeProvider = serverTimeProvider;
		Console.WriteLine("\ud83d\udd27 PlayerEnergyRegenerationService constructor called");
		_playerState.StateChanged += OnStateChanged;
		Console.WriteLine("\ud83d\udd27 Subscribed to PlayerStateService.StateChanged event");
		if (_playerState.CurrentPlayerId != null)
		{
			Console.WriteLine("\ud83d\udd27 Player already logged in (" + _playerState.CurrentPlayerId + "), initializing regeneration");
			InitializeRegenerationAsync();
		}
		else
		{
			Console.WriteLine("\ud83d\udd27 No active session yet, waiting for SessionStart event");
		}
	}

	private void OnStateChanged(object? sender, StateChangedEventArgs e)
	{
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Expected O, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e5: Expected O, but got Unknown
		Console.WriteLine($"\ud83d\udd14 PlayerEnergyRegenerationService.OnStateChanged: Scope={e.Scope}, ChangeType={e.ChangeType}");
		if (e.Scope != 0)
		{
			Console.WriteLine("   ↳ Ignoring - not Player scope");
		}
		else if (e.ChangeType == "SessionStart" && !_isRegenerating)
		{
			Console.WriteLine("   ↳ SessionStart detected! Initializing regeneration...");
			InitializeRegenerationAsync();
		}
		else
		{
			if (!(e.ChangeType == "Energy") || !_isRegenerating)
			{
				return;
			}
			Player currentPlayer = _playerState.GetCurrentPlayer();
			if (currentPlayer == null)
			{
				return;
			}
			if (currentPlayer.EP < currentPlayer.MaxEP && _epTimer == null)
			{
				lock (_epLock)
				{
					if (_epTimer == null)
					{
						DateTimeOffset currentServerTime = _serverTimeProvider.GetCurrentServerTime();
						_nextEpTick = ((DateTimeOffset)(ref currentServerTime)).AddMinutes(1.0);
						TimeSpan initialDelay = TimeSpan.FromMinutes(1L);
						Console.WriteLine($"\ud83d\udd04 EP dropped below max ({currentPlayer.EP}/{currentPlayer.MaxEP})");
						Console.WriteLine($"   Now: {currentServerTime:HH:mm:ss}, Next tick: {_nextEpTick:HH:mm:ss}, Delay: {((TimeSpan)(ref initialDelay)).TotalSeconds:F1}s");
						_epTimer = CreateDelayedTimer(initialDelay, TimeSpan.FromMinutes(1L), new Action(RegenerateEp));
					}
				}
			}
			if (currentPlayer.SP >= currentPlayer.MaxSP || _spTimer != null)
			{
				return;
			}
			lock (_spLock)
			{
				if (_spTimer == null)
				{
					DateTimeOffset currentServerTime2 = _serverTimeProvider.GetCurrentServerTime();
					_nextSpTick = ((DateTimeOffset)(ref currentServerTime2)).AddMinutes(2.0);
					TimeSpan initialDelay2 = TimeSpan.FromMinutes(2L);
					Console.WriteLine($"\ud83d\udd04 SP dropped below max ({currentPlayer.SP}/{currentPlayer.MaxSP})");
					Console.WriteLine($"   Now: {currentServerTime2:HH:mm:ss}, Next tick: {_nextSpTick:HH:mm:ss}, Delay: {((TimeSpan)(ref initialDelay2)).TotalSeconds:F1}s");
					_spTimer = CreateDelayedTimer(initialDelay2, TimeSpan.FromMinutes(2L), new Action(RegenerateSp));
				}
			}
		}
	}

	[AsyncStateMachine(typeof(_003CInitializeRegenerationAsync_003Ed__19))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task InitializeRegenerationAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CInitializeRegenerationAsync_003Ed__19 _003CInitializeRegenerationAsync_003Ed__ = new _003CInitializeRegenerationAsync_003Ed__19();
		_003CInitializeRegenerationAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CInitializeRegenerationAsync_003Ed__._003C_003E4__this = this;
		_003CInitializeRegenerationAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CInitializeRegenerationAsync_003Ed__._003C_003Et__builder)).Start<_003CInitializeRegenerationAsync_003Ed__19>(ref _003CInitializeRegenerationAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CInitializeRegenerationAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CCalculateOfflineRegenerationAsync_003Ed__20))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task CalculateOfflineRegenerationAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CCalculateOfflineRegenerationAsync_003Ed__20 _003CCalculateOfflineRegenerationAsync_003Ed__ = new _003CCalculateOfflineRegenerationAsync_003Ed__20();
		_003CCalculateOfflineRegenerationAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CCalculateOfflineRegenerationAsync_003Ed__._003C_003E4__this = this;
		_003CCalculateOfflineRegenerationAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CCalculateOfflineRegenerationAsync_003Ed__._003C_003Et__builder)).Start<_003CCalculateOfflineRegenerationAsync_003Ed__20>(ref _003CCalculateOfflineRegenerationAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CCalculateOfflineRegenerationAsync_003Ed__._003C_003Et__builder)).Task;
	}

	public void StartRegeneration()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Expected O, but got Unknown
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Expected O, but got Unknown
		if (_isRegenerating || _playerState.CurrentPlayerId == null)
		{
			return;
		}
		_isRegenerating = true;
		DateTimeOffset currentServerTime = _serverTimeProvider.GetCurrentServerTime();
		TimeSpan initialDelay = ((_nextEpTick > currentServerTime) ? (_nextEpTick - currentServerTime) : TimeSpan.Zero);
		TimeSpan initialDelay2 = ((_nextSpTick > currentServerTime) ? (_nextSpTick - currentServerTime) : TimeSpan.Zero);
		Player currentPlayer = _playerState.GetCurrentPlayer();
		if (currentPlayer != null)
		{
			if (currentPlayer.EP < currentPlayer.MaxEP)
			{
				_epTimer = CreateDelayedTimer(initialDelay, TimeSpan.FromMinutes(1L), new Action(RegenerateEp));
				Console.WriteLine($"Started EP timer. Current: {currentPlayer.EP}/{currentPlayer.MaxEP}, Next tick in: {((TimeSpan)(ref initialDelay)).TotalSeconds:F1}s");
			}
			else
			{
				Console.WriteLine($"Skipped EP timer - at max ({currentPlayer.EP}/{currentPlayer.MaxEP})");
			}
			if (currentPlayer.SP < currentPlayer.MaxSP)
			{
				_spTimer = CreateDelayedTimer(initialDelay2, TimeSpan.FromMinutes(2L), new Action(RegenerateSp));
				Console.WriteLine($"Started SP timer. Current: {currentPlayer.SP}/{currentPlayer.MaxSP}, Next tick in: {((TimeSpan)(ref initialDelay2)).TotalSeconds:F1}s");
			}
			else
			{
				Console.WriteLine($"Skipped SP timer - at max ({currentPlayer.SP}/{currentPlayer.MaxSP})");
			}
			_uiUpdateTimer = CreateTimer(TimeSpan.FromSeconds(1L), new Action(UpdateUI));
			Console.WriteLine("Regeneration started.");
		}
	}

	[AsyncStateMachine(typeof(_003CRefreshAsync_003Ed__22))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task RefreshAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRefreshAsync_003Ed__22 _003CRefreshAsync_003Ed__ = new _003CRefreshAsync_003Ed__22();
		_003CRefreshAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRefreshAsync_003Ed__._003C_003E4__this = this;
		_003CRefreshAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRefreshAsync_003Ed__._003C_003Et__builder)).Start<_003CRefreshAsync_003Ed__22>(ref _003CRefreshAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRefreshAsync_003Ed__._003C_003Et__builder)).Task;
	}

	public void StopRegeneration()
	{
		if (_isRegenerating)
		{
			IDispatcherTimer? epTimer = _epTimer;
			if (epTimer != null)
			{
				epTimer.Stop();
			}
			IDispatcherTimer? spTimer = _spTimer;
			if (spTimer != null)
			{
				spTimer.Stop();
			}
			IDispatcherTimer? uiUpdateTimer = _uiUpdateTimer;
			if (uiUpdateTimer != null)
			{
				uiUpdateTimer.Stop();
			}
			_epTimer = null;
			_spTimer = null;
			_uiUpdateTimer = null;
			_isRegenerating = false;
			Console.WriteLine("Regeneration service stopped");
		}
	}

	private IDispatcherTimer CreateTimer(TimeSpan interval, Action callback)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		Action callback2 = callback;
		IDispatcher forCurrentThread = Dispatcher.GetForCurrentThread();
		IDispatcherTimer val = ((forCurrentThread != null) ? forCurrentThread.CreateTimer() : null);
		if (val == null)
		{
			throw new InvalidOperationException("Could not create timer - no dispatcher available");
		}
		val.Interval = interval;
		val.Tick += (EventHandler)delegate
		{
			callback2.Invoke();
		};
		val.Start();
		return val;
	}

	private IDispatcherTimer CreateDelayedTimer(TimeSpan initialDelay, TimeSpan interval, Action callback)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		Action callback2 = callback;
		IDispatcher forCurrentThread = Dispatcher.GetForCurrentThread();
		IDispatcherTimer timer = ((forCurrentThread != null) ? forCurrentThread.CreateTimer() : null);
		if (timer == null)
		{
			throw new InvalidOperationException("Could not create timer - no dispatcher available");
		}
		if (initialDelay <= TimeSpan.Zero)
		{
			timer.Interval = TimeSpan.FromMilliseconds(10L, 0L);
			bool fired = false;
			timer.Tick += (EventHandler)delegate
			{
				//IL_0038: Unknown result type (might be due to invalid IL or missing references)
				if (!fired)
				{
					fired = true;
					callback2.Invoke();
					timer.Interval = interval;
				}
				else
				{
					callback2.Invoke();
				}
			};
			timer.Start();
			return timer;
		}
		bool firstTick = true;
		timer.Interval = initialDelay;
		timer.Tick += (EventHandler)delegate
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			if (firstTick)
			{
				firstTick = false;
				timer.Interval = interval;
			}
			callback2.Invoke();
		};
		timer.Start();
		return timer;
	}

	private void RegenerateEp()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		lock (_epLock)
		{
			Player currentPlayer = _playerState.GetCurrentPlayer();
			DateTimeOffset currentServerTime = _serverTimeProvider.GetCurrentServerTime();
			if (currentPlayer == null || currentPlayer.EP >= currentPlayer.MaxEP)
			{
				IDispatcherTimer? epTimer = _epTimer;
				if (epTimer != null)
				{
					epTimer.Stop();
				}
				_epTimer = null;
				_nextEpTick = ((DateTimeOffset)(ref currentServerTime)).AddMinutes(1.0);
				return;
			}
			try
			{
				Result<RegenerateEnergyResponse> result = _regenerateUseCase.RegenerateEP(currentServerTime);
				if (result.Success && result.Data != null)
				{
					_nextEpTick = ((DateTimeOffset)(ref currentServerTime)).AddMinutes(1.0);
					Console.WriteLine($" EP regenerated instantly: {result.Data.NewValue}/{result.Data.MaxValue}");
					if (result.Data.AtMax)
					{
						IDispatcherTimer? epTimer2 = _epTimer;
						if (epTimer2 != null)
						{
							epTimer2.Stop();
						}
						_epTimer = null;
						Console.WriteLine("EP at max, stopping timer");
					}
				}
				else
				{
					IDispatcherTimer? epTimer3 = _epTimer;
					if (epTimer3 != null)
					{
						epTimer3.Stop();
					}
					_epTimer = null;
					_nextEpTick = ((DateTimeOffset)(ref currentServerTime)).AddMinutes(1.0);
				}
			}
			catch (global::System.Exception ex)
			{
				Console.WriteLine(" Error regenerating EP: " + ex.Message);
			}
		}
	}

	private void RegenerateSp()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		lock (_spLock)
		{
			Player currentPlayer = _playerState.GetCurrentPlayer();
			DateTimeOffset currentServerTime = _serverTimeProvider.GetCurrentServerTime();
			if (currentPlayer == null || currentPlayer.SP >= currentPlayer.MaxSP)
			{
				IDispatcherTimer? spTimer = _spTimer;
				if (spTimer != null)
				{
					spTimer.Stop();
				}
				_spTimer = null;
				_nextSpTick = ((DateTimeOffset)(ref currentServerTime)).AddMinutes(2.0);
				return;
			}
			try
			{
				Result<RegenerateEnergyResponse> result = _regenerateUseCase.RegenerateSP(currentServerTime);
				if (result.Success && result.Data != null)
				{
					_nextSpTick = ((DateTimeOffset)(ref currentServerTime)).AddMinutes(2.0);
					Console.WriteLine($"SP regenerated instantly: {result.Data.NewValue}/{result.Data.MaxValue}");
					if (result.Data.AtMax)
					{
						IDispatcherTimer? spTimer2 = _spTimer;
						if (spTimer2 != null)
						{
							spTimer2.Stop();
						}
						_spTimer = null;
						Console.WriteLine("SP at max, stopping timer");
					}
				}
				else
				{
					IDispatcherTimer? spTimer3 = _spTimer;
					if (spTimer3 != null)
					{
						spTimer3.Stop();
					}
					_spTimer = null;
					_nextSpTick = ((DateTimeOffset)(ref currentServerTime)).AddMinutes(2.0);
				}
			}
			catch (global::System.Exception ex)
			{
				Console.WriteLine(" Error regenerating SP: " + ex.Message);
			}
		}
	}

	private void UpdateUI()
	{
		try
		{
			this.CooldownTick?.Invoke((object)this, new RegenerationCooldownEventArgs(GetEpCooldown(), GetSpCooldown()));
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine("Error raising cooldown tick event: " + ex.Message);
		}
	}

	private string GetEpCooldown()
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		lock (_epLock)
		{
			Player currentPlayer = _playerState.GetCurrentPlayer();
			if (currentPlayer == null || currentPlayer.EP >= currentPlayer.MaxEP)
			{
				return string.Empty;
			}
			DateTimeOffset currentServerTime = _serverTimeProvider.GetCurrentServerTime();
			TimeSpan val = _nextEpTick - currentServerTime;
			if (((TimeSpan)(ref val)).TotalSeconds < -5.0)
			{
				Console.WriteLine($"⚠\ufe0f EP cooldown way behind ({((TimeSpan)(ref val)).TotalSeconds:F1}s), waiting for timer restart...");
				return "00:01";
			}
			if (((TimeSpan)(ref val)).TotalSeconds < 0.0)
			{
				return "00:00";
			}
			return ((TimeSpan)(ref val)).ToString("mm\\:ss");
		}
	}

	private string GetSpCooldown()
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		lock (_spLock)
		{
			Player currentPlayer = _playerState.GetCurrentPlayer();
			if (currentPlayer == null || currentPlayer.SP >= currentPlayer.MaxSP)
			{
				return string.Empty;
			}
			DateTimeOffset currentServerTime = _serverTimeProvider.GetCurrentServerTime();
			TimeSpan val = _nextSpTick - currentServerTime;
			if (((TimeSpan)(ref val)).TotalSeconds < -5.0)
			{
				Console.WriteLine($"⚠\ufe0f SP cooldown way behind ({((TimeSpan)(ref val)).TotalSeconds:F1}s), waiting for timer restart...");
				return "00:01";
			}
			if (((TimeSpan)(ref val)).TotalSeconds < 0.0)
			{
				return "00:00";
			}
			return ((TimeSpan)(ref val)).ToString("mm\\:ss");
		}
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			_playerState.StateChanged -= OnStateChanged;
			StopRegeneration();
			_disposed = true;
			GC.SuppressFinalize((object)this);
		}
	}
}
