using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Dispatching;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.Interfaces;
using SpiritSummoner.Application.State;
using SpiritSummoner.Infrastructure.Contracts;
using SpiritSummoner.Presentation.Services;

namespace SpiritSummoner;

[XamlFilePath("App.xaml")]
public class App : Application
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		private sealed class _003C_003CStartForegroundFlushTimer_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public object _;

			public EventArgs _;

			public _003C_003Ec__DisplayClass8_0 _003C_003E4__this;

			private global::System.Exception _003Cex_003E5__1;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
				//IL_007b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0080: Unknown result type (might be due to invalid IL or missing references)
				//IL_0087: Unknown result type (might be due to invalid IL or missing references)
				//IL_0044: Unknown result type (might be due to invalid IL or missing references)
				//IL_0049: Unknown result type (might be due to invalid IL or missing references)
				//IL_005d: Unknown result type (might be due to invalid IL or missing references)
				//IL_005e: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					if (num == 0 || _003C_003E4__this.batchQueue.HasPendingUpdates)
					{
						try
						{
							TaskAwaiter awaiter;
							if (num != 0)
							{
								awaiter = _003C_003E4__this.batchQueue.FlushQueueAsync().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter;
									_003C_003CStartForegroundFlushTimer_003Eb__0_003Ed _003C_003CStartForegroundFlushTimer_003Eb__0_003Ed = this;
									((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003CStartForegroundFlushTimer_003Eb__0_003Ed>(ref awaiter, ref _003C_003CStartForegroundFlushTimer_003Eb__0_003Ed);
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
						catch (global::System.Exception ex)
						{
							_003Cex_003E5__1 = ex;
							Console.WriteLine("Foreground flush failed: " + _003Cex_003E5__1.Message);
						}
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

		public IBatchQueueService batchQueue;

		[AsyncStateMachine(typeof(_003C_003CStartForegroundFlushTimer_003Eb__0_003Ed))]
		[DebuggerStepThrough]
		internal void _003CStartForegroundFlushTimer_003Eb__0(object? _, EventArgs _)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003CStartForegroundFlushTimer_003Eb__0_003Ed _003C_003CStartForegroundFlushTimer_003Eb__0_003Ed = new _003C_003CStartForegroundFlushTimer_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncVoidMethodBuilder.Create(),
				_003C_003E4__this = this,
				_ = _,
				_ = _,
				_003C_003E1__state = -1
			};
			((AsyncVoidMethodBuilder)(ref _003C_003CStartForegroundFlushTimer_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003CStartForegroundFlushTimer_003Eb__0_003Ed>(ref _003C_003CStartForegroundFlushTimer_003Eb__0_003Ed);
		}
	}

	[CompilerGenerated]
	private sealed class _003COnResume_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public App _003C_003E4__this;

		private IPresenceService _003CpresenceService_003E5__1;

		private global::System.Exception _003Cex_003E5__2;

		private IPlayerEnergyRegenerationService _003CenergyRegen_003E5__3;

		private global::System.Exception _003Cex_003E5__4;

		private IPageCacheService _003CpageCacheService_003E5__5;

		private IPlayerStateService _003CplayerState_003E5__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
					if (num == 1)
					{
						goto IL_00fe;
					}
					_003C_003E4__this._003C_003En__1();
					Console.WriteLine("App resumed - caches preserved for fast startup");
					IDispatcherTimer? foregroundFlushTimer = _003C_003E4__this._foregroundFlushTimer;
					if (foregroundFlushTimer != null)
					{
						foregroundFlushTimer.Start();
					}
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						_003CpresenceService_003E5__1 = ServiceProviderServiceExtensions.GetRequiredService<IPresenceService>(_003C_003E4__this._serviceProvider);
						awaiter = _003CpresenceService_003E5__1.PingAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003COnResume_003Ed__7 _003COnResume_003Ed__ = this;
							((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnResume_003Ed__7>(ref awaiter, ref _003COnResume_003Ed__);
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
					_003CpresenceService_003E5__1 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__2 = ex;
					Console.WriteLine("Failed to ping presence on resume: " + _003Cex_003E5__2.Message);
				}
				goto IL_00fe;
				IL_00fe:
				try
				{
					TaskAwaiter awaiter2;
					if (num != 1)
					{
						_003CenergyRegen_003E5__3 = ServiceProviderServiceExtensions.GetRequiredService<IPlayerEnergyRegenerationService>(_003C_003E4__this._serviceProvider);
						awaiter2 = _003CenergyRegen_003E5__3.RefreshAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter2;
							_003COnResume_003Ed__7 _003COnResume_003Ed__ = this;
							((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnResume_003Ed__7>(ref awaiter2, ref _003COnResume_003Ed__);
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
					_003CenergyRegen_003E5__3 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					Console.WriteLine("Failed to refresh energy regeneration on resume: " + _003Cex_003E5__4.Message);
				}
				try
				{
					_003CpageCacheService_003E5__5 = ServiceProviderServiceExtensions.GetRequiredService<IPageCacheService>(_003C_003E4__this._serviceProvider);
					_003CplayerState_003E5__6 = ServiceProviderServiceExtensions.GetRequiredService<IPlayerStateService>(_003C_003E4__this._serviceProvider);
					_003CpageCacheService_003E5__5.SweepIdleDeepVMs(TimeSpan.FromMinutes(10L), _003CplayerState_003E5__6.CurrentRoute);
					_003CpageCacheService_003E5__5 = null;
					_003CplayerState_003E5__6 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__7 = ex;
					Console.WriteLine("Failed to sweep idle page cache on resume: " + _003Cex_003E5__7.Message);
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
	private sealed class _003COnStart_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public App _003C_003E4__this;

		private IBatchQueueService _003CbatchQueue_003E5__1;

		private IPlayerEnergyRegenerationService _003CenergyRegen_003E5__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
					_003C_003E4__this._003C_003En__0();
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						BatchUpdateMerger.ValidateAttributes<PlayerBatchUpdate>();
						BatchUpdateMerger.ValidateAttributes<PlayerSpiritFieldUpdate>();
						BatchUpdateMerger.ValidateAttributes<PlayerGuildUpdate>();
						_003CbatchQueue_003E5__1 = ServiceProviderServiceExtensions.GetRequiredService<IBatchQueueService>(_003C_003E4__this._serviceProvider);
						awaiter = _003CbatchQueue_003E5__1.InitializeAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003COnStart_003Ed__5 _003COnStart_003Ed__ = this;
							((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnStart_003Ed__5>(ref awaiter, ref _003COnStart_003Ed__);
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
					_003CenergyRegen_003E5__2 = ServiceProviderServiceExtensions.GetRequiredService<IPlayerEnergyRegenerationService>(_003C_003E4__this._serviceProvider);
					Console.WriteLine("Energy regeneration service initialized.");
					_003C_003E4__this.StartForegroundFlushTimer(_003CbatchQueue_003E5__1);
					Console.WriteLine("App initialization completed successfully.");
					_003CbatchQueue_003E5__1 = null;
					_003CenergyRegen_003E5__2 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("Failed to initialize app services: " + _003Cex_003E5__3.Message);
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

	private static readonly TimeSpan ForegroundFlushInterval = TimeSpan.FromSeconds(45L);

	private readonly IServiceProvider _serviceProvider;

	private IDispatcherTimer? _foregroundFlushTimer;

	public App(IServiceProvider serviceProvider)
	{
		InitializeComponent();
		_serviceProvider = serviceProvider;
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		AppShell requiredService = ServiceProviderServiceExtensions.GetRequiredService<AppShell>(_serviceProvider);
		return new Window((Page)(object)requiredService);
	}

	[AsyncStateMachine(typeof(_003COnStart_003Ed__5))]
	[DebuggerStepThrough]
	protected override void OnStart()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COnStart_003Ed__5 _003COnStart_003Ed__ = new _003COnStart_003Ed__5();
		_003COnStart_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003COnStart_003Ed__._003C_003E4__this = this;
		_003COnStart_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003COnStart_003Ed__._003C_003Et__builder)).Start<_003COnStart_003Ed__5>(ref _003COnStart_003Ed__);
	}

	protected override void OnSleep()
	{
		((Application)this).OnSleep();
		IDispatcherTimer? foregroundFlushTimer = _foregroundFlushTimer;
		if (foregroundFlushTimer != null)
		{
			foregroundFlushTimer.Stop();
		}
		Console.WriteLine("App entering sleep - foreground flush timer paused");
	}

	[AsyncStateMachine(typeof(_003COnResume_003Ed__7))]
	[DebuggerStepThrough]
	protected override void OnResume()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COnResume_003Ed__7 _003COnResume_003Ed__ = new _003COnResume_003Ed__7();
		_003COnResume_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003COnResume_003Ed__._003C_003E4__this = this;
		_003COnResume_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003COnResume_003Ed__._003C_003Et__builder)).Start<_003COnResume_003Ed__7>(ref _003COnResume_003Ed__);
	}

	private void StartForegroundFlushTimer(IBatchQueueService batchQueue)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.batchQueue = batchQueue;
		Application current = Application.Current;
		IDispatcher val = ((current != null) ? ((BindableObject)current).Dispatcher : null) ?? ((BindableObject)this).Dispatcher;
		_foregroundFlushTimer = val.CreateTimer();
		_foregroundFlushTimer.Interval = ForegroundFlushInterval;
		_foregroundFlushTimer.IsRepeating = true;
		_foregroundFlushTimer.Tick += (EventHandler)([AsyncStateMachine(typeof(_003C_003Ec__DisplayClass8_0._003C_003CStartForegroundFlushTimer_003Eb__0_003Ed))] [DebuggerStepThrough] (object? _, EventArgs _) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003Ec__DisplayClass8_0._003C_003CStartForegroundFlushTimer_003Eb__0_003Ed _003C_003CStartForegroundFlushTimer_003Eb__0_003Ed = new _003C_003Ec__DisplayClass8_0._003C_003CStartForegroundFlushTimer_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncVoidMethodBuilder.Create(),
				_003C_003E4__this = CS_0024_003C_003E8__locals0,
				_ = _,
				_ = _,
				_003C_003E1__state = -1
			};
			((AsyncVoidMethodBuilder)(ref _003C_003CStartForegroundFlushTimer_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass8_0._003C_003CStartForegroundFlushTimer_003Eb__0_003Ed>(ref _003C_003CStartForegroundFlushTimer_003Eb__0_003Ed);
		});
		_foregroundFlushTimer.Start();
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<App>(this, typeof(App));
	}

	[CompilerGenerated]
	[DebuggerHidden]
	private void _003C_003En__0()
	{
		((Application)this).OnStart();
	}

	[CompilerGenerated]
	[DebuggerHidden]
	private void _003C_003En__1()
	{
		((Application)this).OnResume();
	}
}
