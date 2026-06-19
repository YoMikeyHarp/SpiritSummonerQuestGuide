using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Timers;
using SpiritSummoner.Application.Interfaces;
using SpiritSummoner.Application.State;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Infrastructure.Services;

public class PresenceService : IPresenceService, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003CPingAsync_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PresenceService _003C_003E4__this;

		private string _003CplayerId_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_009e;
				}
				_003CplayerId_003E5__1 = _003C_003E4__this._playerState.CurrentPlayerId;
				if (!string.IsNullOrEmpty(_003CplayerId_003E5__1))
				{
					awaiter = _003C_003E4__this._playerRepository.UpdatePresenceAsync(_003CplayerId_003E5__1).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CPingAsync_003Ed__7 _003CPingAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CPingAsync_003Ed__7>(ref awaiter, ref _003CPingAsync_003Ed__);
						return;
					}
					goto IL_009e;
				}
				goto end_IL_0007;
				IL_009e:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CplayerId_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CplayerId_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IPlayerRepository _playerRepository;

	private readonly IPlayerStateService _playerState;

	private Timer? _timer;

	private static readonly TimeSpan HeartbeatInterval = TimeSpan.FromMinutes(3L);

	public PresenceService(IPlayerRepository playerRepository, IPlayerStateService playerState)
	{
		_playerRepository = playerRepository;
		_playerState = playerState;
	}

	public void Start()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		Stop();
		global::System.Threading.Tasks.Task.Run((Func<global::System.Threading.Tasks.Task>)PingAsync);
		_timer = new Timer(((TimeSpan)(ref HeartbeatInterval)).TotalMilliseconds);
		_timer.Elapsed += new ElapsedEventHandler(OnTimerElapsed);
		_timer.AutoReset = true;
		_timer.Start();
	}

	public void Stop()
	{
		Timer? timer = _timer;
		if (timer != null)
		{
			timer.Stop();
		}
		Timer? timer2 = _timer;
		if (timer2 != null)
		{
			((Component)timer2).Dispose();
		}
		_timer = null;
	}

	[AsyncStateMachine(typeof(_003CPingAsync_003Ed__7))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task PingAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CPingAsync_003Ed__7 _003CPingAsync_003Ed__ = new _003CPingAsync_003Ed__7();
		_003CPingAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CPingAsync_003Ed__._003C_003E4__this = this;
		_003CPingAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CPingAsync_003Ed__._003C_003Et__builder)).Start<_003CPingAsync_003Ed__7>(ref _003CPingAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CPingAsync_003Ed__._003C_003Et__builder)).Task;
	}

	private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
	{
		global::System.Threading.Tasks.Task.Run((Func<global::System.Threading.Tasks.Task>)PingAsync);
	}

	public void Dispose()
	{
		Stop();
	}
}
