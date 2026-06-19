using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using SpiritSummoner.Application.DTOs.Session;
using SpiritSummoner.Application.Events;
using SpiritSummoner.Application.State;
using SpiritSummoner.Infrastructure.Caching;
using SpiritSummoner.Infrastructure.FirebaseListeners;
using SpiritSummoner.Infrastructure.Services;

namespace SpiritSummoner.Application.Session;

public class SessionInitializationService : ISessionInitializationService
{
	[CompilerGenerated]
	private sealed class _003C_003CWireUpNotificationProcessor_003Eb__14_0_003Ed : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public NotificationReceivedEventArgs args;

		public SessionInitializationService _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_010b;
						}
						awaiter2 = _003C_003E4__this._notificationProcessor.ProcessNotificationAsync(args.Notification).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003C_003CWireUpNotificationProcessor_003Eb__14_0_003Ed _003C_003CWireUpNotificationProcessor_003Eb__14_0_003Ed = this;
							((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003CWireUpNotificationProcessor_003Eb__14_0_003Ed>(ref awaiter2, ref _003C_003CWireUpNotificationProcessor_003Eb__14_0_003Ed);
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
					awaiter = _003C_003E4__this._notificationListener.MarkAsReadAsync(args.Notification.Id).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter;
						_003C_003CWireUpNotificationProcessor_003Eb__14_0_003Ed _003C_003CWireUpNotificationProcessor_003Eb__14_0_003Ed = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003CWireUpNotificationProcessor_003Eb__14_0_003Ed>(ref awaiter, ref _003C_003CWireUpNotificationProcessor_003Eb__14_0_003Ed);
						return;
					}
					goto IL_010b;
					IL_010b:
					((TaskAwaiter)(ref awaiter)).GetResult();
					Console.WriteLine("Processed notification: " + args.Notification.Id);
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__1 = ex;
					Console.WriteLine("Failed to process notification: " + _003Cex_003E5__1.Message);
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CInitializeNotificationListenerAsync_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string playerId;

		public SessionInitializationService _003C_003E4__this;

		private List<PlayerNotificationDTO> _003CunreadNotifications_003E5__1;

		private List<PlayerNotificationDTO> _003C_003Es__2;

		private Enumerator<PlayerNotificationDTO> _003C_003Es__3;

		private PlayerNotificationDTO _003Cnotification_003E5__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<List<PlayerNotificationDTO>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0148: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_020b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0210: Unknown result type (might be due to invalid IL or missing references)
			//IL_0225: Unknown result type (might be due to invalid IL or missing references)
			//IL_0227: Unknown result type (might be due to invalid IL or missing references)
			//IL_0244: Unknown result type (might be due to invalid IL or missing references)
			//IL_0249: Unknown result type (might be due to invalid IL or missing references)
			//IL_0251: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_01af: Unknown result type (might be due to invalid IL or missing references)
			//IL_029f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 2u && string.IsNullOrEmpty(playerId))
				{
					Console.WriteLine("Cannot initialize notification listener: No player ID");
				}
				else
				{
					try
					{
						TaskAwaiter<List<PlayerNotificationDTO>> awaiter;
						if (num != 0)
						{
							if ((uint)(num - 1) <= 1u)
							{
								goto IL_0153;
							}
							_003C_003E4__this._notificationListener.StartListener(playerId);
							awaiter = _003C_003E4__this._notificationListener.GetUnreadNotificationsAsync(playerId).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CInitializeNotificationListenerAsync_003Ed__13 _003CInitializeNotificationListenerAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<List<PlayerNotificationDTO>>, _003CInitializeNotificationListenerAsync_003Ed__13>(ref awaiter, ref _003CInitializeNotificationListenerAsync_003Ed__);
								return;
							}
						}
						else
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<List<PlayerNotificationDTO>>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__2 = awaiter.GetResult();
						_003CunreadNotifications_003E5__1 = _003C_003Es__2;
						_003C_003Es__2 = null;
						if (Enumerable.Any<PlayerNotificationDTO>((global::System.Collections.Generic.IEnumerable<PlayerNotificationDTO>)_003CunreadNotifications_003E5__1))
						{
							Console.WriteLine($"Processing {_003CunreadNotifications_003E5__1.Count} pending notifications");
							_003C_003Es__3 = _003CunreadNotifications_003E5__1.GetEnumerator();
							goto IL_0153;
						}
						goto IL_02a6;
						IL_02a6:
						Console.WriteLine("Notification listener initialized successfully");
						_003CunreadNotifications_003E5__1 = null;
						goto end_IL_0031;
						IL_0153:
						try
						{
							TaskAwaiter awaiter2;
							if (num != 1)
							{
								if (num != 2)
								{
									goto IL_0270;
								}
								awaiter2 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0260;
							}
							TaskAwaiter awaiter3 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_01e8;
							IL_0260:
							((TaskAwaiter)(ref awaiter2)).GetResult();
							_003Cnotification_003E5__4 = null;
							goto IL_0270;
							IL_0270:
							if (_003C_003Es__3.MoveNext())
							{
								_003Cnotification_003E5__4 = _003C_003Es__3.Current;
								awaiter3 = _003C_003E4__this._notificationProcessor.ProcessNotificationAsync(_003Cnotification_003E5__4).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter3;
									_003CInitializeNotificationListenerAsync_003Ed__13 _003CInitializeNotificationListenerAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CInitializeNotificationListenerAsync_003Ed__13>(ref awaiter3, ref _003CInitializeNotificationListenerAsync_003Ed__);
									return;
								}
								goto IL_01e8;
							}
							goto end_IL_0153;
							IL_01e8:
							((TaskAwaiter)(ref awaiter3)).GetResult();
							awaiter2 = _003C_003E4__this._notificationListener.MarkAsReadAsync(_003Cnotification_003E5__4.Id).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__2 = awaiter2;
								_003CInitializeNotificationListenerAsync_003Ed__13 _003CInitializeNotificationListenerAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CInitializeNotificationListenerAsync_003Ed__13>(ref awaiter2, ref _003CInitializeNotificationListenerAsync_003Ed__);
								return;
							}
							goto IL_0260;
							end_IL_0153:;
						}
						finally
						{
							if (num < 0)
							{
								((global::System.IDisposable)_003C_003Es__3).Dispose();
							}
						}
						_003C_003Es__3 = default(Enumerator<PlayerNotificationDTO>);
						goto IL_02a6;
						end_IL_0031:;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__5 = ex;
						Console.WriteLine("Failed to initialize notification listener: " + _003Cex_003E5__5.Message);
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
	private sealed class _003CInitializeStaticDataAsync_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SessionInitializationService _003C_003E4__this;

		private Stopwatch _003Csw_003E5__1;

		private global::System.Exception _003Cex_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0)
				{
					goto IL_003a;
				}
				if (!_003C_003E4__this._isInitialized)
				{
					Console.WriteLine("Initializing static data cache...");
					_003Csw_003E5__1 = Stopwatch.StartNew();
					goto IL_003a;
				}
				goto end_IL_0007;
				IL_003a:
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						awaiter = global::System.Threading.Tasks.Task.CompletedTask.GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CInitializeStaticDataAsync_003Ed__12 _003CInitializeStaticDataAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CInitializeStaticDataAsync_003Ed__12>(ref awaiter, ref _003CInitializeStaticDataAsync_003Ed__);
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
					_003C_003E4__this._isInitialized = true;
					_003Csw_003E5__1.Stop();
					Console.WriteLine($"Static data cache initialized in {_003Csw_003E5__1.ElapsedMilliseconds}ms");
					EventHandler? staticDataLoaded = _003C_003E4__this.StaticDataLoaded;
					if (staticDataLoaded != null)
					{
						staticDataLoaded.Invoke((object)_003C_003E4__this, EventArgs.Empty);
					}
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__2 = ex;
					Console.WriteLine("Failed to initialize static data: " + _003Cex_003E5__2.Message);
					throw;
				}
				end_IL_0007:;
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003Csw_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003Csw_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IStaticDataCacheService _staticDataCache;

	private readonly IPlayerStateService _playerState;

	private readonly IPlayerNotificationListenerService _notificationListener;

	private readonly INotificationProcessorService _notificationProcessor;

	private bool _isInitialized = false;

	private bool _isNotificationProcessorWired = false;

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private EventHandler? m_StaticDataLoaded;

	public bool IsInitialized => _isInitialized;

	public event EventHandler StaticDataLoaded
	{
		[CompilerGenerated]
		add
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			EventHandler val = this.m_StaticDataLoaded;
			EventHandler val2;
			do
			{
				val2 = val;
				EventHandler val3 = (EventHandler)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler>(ref this.m_StaticDataLoaded, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			EventHandler val = this.m_StaticDataLoaded;
			EventHandler val2;
			do
			{
				val2 = val;
				EventHandler val3 = (EventHandler)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler>(ref this.m_StaticDataLoaded, val3, val2);
			}
			while (val != val2);
		}
	}

	public SessionInitializationService(IStaticDataCacheService staticDataCache, IPlayerStateService playerState, IPlayerNotificationListenerService notificationListener, INotificationProcessorService notificationProcessor)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		_staticDataCache = staticDataCache ?? throw new ArgumentNullException("staticDataCache");
		_playerState = playerState ?? throw new ArgumentNullException("playerState");
		_notificationListener = notificationListener ?? throw new ArgumentNullException("notificationListener");
		_notificationProcessor = notificationProcessor ?? throw new ArgumentNullException("notificationProcessor");
	}

	[AsyncStateMachine(typeof(_003CInitializeStaticDataAsync_003Ed__12))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task InitializeStaticDataAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CInitializeStaticDataAsync_003Ed__12 _003CInitializeStaticDataAsync_003Ed__ = new _003CInitializeStaticDataAsync_003Ed__12();
		_003CInitializeStaticDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CInitializeStaticDataAsync_003Ed__._003C_003E4__this = this;
		_003CInitializeStaticDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CInitializeStaticDataAsync_003Ed__._003C_003Et__builder)).Start<_003CInitializeStaticDataAsync_003Ed__12>(ref _003CInitializeStaticDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CInitializeStaticDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CInitializeNotificationListenerAsync_003Ed__13))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task InitializeNotificationListenerAsync(string playerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CInitializeNotificationListenerAsync_003Ed__13 _003CInitializeNotificationListenerAsync_003Ed__ = new _003CInitializeNotificationListenerAsync_003Ed__13();
		_003CInitializeNotificationListenerAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CInitializeNotificationListenerAsync_003Ed__._003C_003E4__this = this;
		_003CInitializeNotificationListenerAsync_003Ed__.playerId = playerId;
		_003CInitializeNotificationListenerAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CInitializeNotificationListenerAsync_003Ed__._003C_003Et__builder)).Start<_003CInitializeNotificationListenerAsync_003Ed__13>(ref _003CInitializeNotificationListenerAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CInitializeNotificationListenerAsync_003Ed__._003C_003Et__builder)).Task;
	}

	public void WireUpNotificationProcessor()
	{
		if (_isNotificationProcessorWired)
		{
			return;
		}
		try
		{
			_notificationListener.NotificationReceived += [AsyncStateMachine(typeof(_003C_003CWireUpNotificationProcessor_003Eb__14_0_003Ed))] [DebuggerStepThrough] [CompilerGenerated] (object? sender, NotificationReceivedEventArgs args) =>
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				_003C_003CWireUpNotificationProcessor_003Eb__14_0_003Ed _003C_003CWireUpNotificationProcessor_003Eb__14_0_003Ed = new _003C_003CWireUpNotificationProcessor_003Eb__14_0_003Ed
				{
					_003C_003Et__builder = AsyncVoidMethodBuilder.Create(),
					_003C_003E4__this = this,
					sender = sender,
					args = args,
					_003C_003E1__state = -1
				};
				((AsyncVoidMethodBuilder)(ref _003C_003CWireUpNotificationProcessor_003Eb__14_0_003Ed._003C_003Et__builder)).Start<_003C_003CWireUpNotificationProcessor_003Eb__14_0_003Ed>(ref _003C_003CWireUpNotificationProcessor_003Eb__14_0_003Ed);
			};
			_isNotificationProcessorWired = true;
			Console.WriteLine("Notification processor wired up successfully");
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine("Failed to wire up notification processor: " + ex.Message);
		}
	}

	public void InvalidateCache()
	{
		_isInitialized = false;
		Console.WriteLine("Session initialization cache invalidated");
	}
}
