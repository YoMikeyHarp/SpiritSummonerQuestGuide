using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Plugin.Firebase.Auth;
using SpiritSummoner.Application.Auth;
using SpiritSummoner.Application.Interfaces;
using SpiritSummoner.Application.Session;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Auth;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Infrastructure.Caching;
using SpiritSummoner.Infrastructure.FirebaseListeners;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.Services.Caching;
using SpiritSummoner.Presentation.ViewModels.Shared;
using SpiritSummoner.Presentation.Views.BottomSheets;
using SpiritSummoner.Presentation.Views.Popups.Shared;
using The49.Maui.BottomSheet;

namespace SpiritSummoner;

[XamlFilePath("AppShell.xaml")]
public class AppShell : Shell
{
	[CompilerGenerated]
	private sealed class _003C_003C_002Dctor_003Eb__14_0_003Ed : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public IFirebaseAuth auth;

		public AppShell _003C_003E4__this;

		private _003C_003Ec__DisplayClass14_0 _003C_003E8__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass14_0();
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003C_003E8__1.auth = auth;
					awaiter = MainThread.InvokeOnMainThreadAsync((Func<global::System.Threading.Tasks.Task>)([AsyncStateMachine(typeof(_003C_003Ec__DisplayClass14_0._003C_003C_002Dctor_003Eb__1_003Ed))] [DebuggerStepThrough] () =>
					{
						//IL_0007: Unknown result type (might be due to invalid IL or missing references)
						//IL_000c: Unknown result type (might be due to invalid IL or missing references)
						_003C_003Ec__DisplayClass14_0._003C_003C_002Dctor_003Eb__1_003Ed _003C_003C_002Dctor_003Eb__1_003Ed = new _003C_003Ec__DisplayClass14_0._003C_003C_002Dctor_003Eb__1_003Ed
						{
							_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
							_003C_003E4__this = _003C_003E8__1,
							_003C_003E1__state = -1
						};
						((AsyncTaskMethodBuilder)(ref _003C_003C_002Dctor_003Eb__1_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass14_0._003C_003C_002Dctor_003Eb__1_003Ed>(ref _003C_003C_002Dctor_003Eb__1_003Ed);
						return ((AsyncTaskMethodBuilder)(ref _003C_003C_002Dctor_003Eb__1_003Ed._003C_003Et__builder)).Task;
					})).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003C_003C_002Dctor_003Eb__14_0_003Ed _003C_003C_002Dctor_003Eb__14_0_003Ed = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003C_002Dctor_003Eb__14_0_003Ed>(ref awaiter, ref _003C_003C_002Dctor_003Eb__14_0_003Ed);
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
				_003C_003E8__1 = null;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003COnSessionInvalidated_003Eb__16_0_003Ed : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public AppShell _003C_003E4__this;

		private INavigationService _003CnavigationService_003E5__1;

		private ISessionInitializationService _003CsessionInitService_003E5__2;

		private IPresentationCacheInitializationService _003CpresentationInitService_003E5__3;

		private IPageCacheService _003CpageCacheService_003E5__4;

		private IGuildStateService _003CguildStateService_003E5__5;

		private IPlayerStateService _003CplayerStateService_003E5__6;

		private ISessionListenerService _003CsessionListener_003E5__7;

		private global::System.Exception _003Cex_003E5__8;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
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
							goto IL_020d;
						}
						_003CnavigationService_003E5__1 = ServiceProviderServiceExtensions.GetRequiredService<INavigationService>(_003C_003E4__this._serviceProvider);
						_003CnavigationService_003E5__1.StopNavigation();
						_003C_003E4__this._sessionListenerService.StopListening();
						awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Session Ended", "Your account was signed in on another device. You have been logged out.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003C_003COnSessionInvalidated_003Eb__16_0_003Ed _003C_003COnSessionInvalidated_003Eb__16_0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003COnSessionInvalidated_003Eb__16_0_003Ed>(ref awaiter2, ref _003C_003COnSessionInvalidated_003Eb__16_0_003Ed);
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
					_003CsessionInitService_003E5__2 = ServiceProviderServiceExtensions.GetRequiredService<ISessionInitializationService>(_003C_003E4__this._serviceProvider);
					_003CpresentationInitService_003E5__3 = ServiceProviderServiceExtensions.GetRequiredService<IPresentationCacheInitializationService>(_003C_003E4__this._serviceProvider);
					_003CpageCacheService_003E5__4 = ServiceProviderServiceExtensions.GetRequiredService<IPageCacheService>(_003C_003E4__this._serviceProvider);
					_003CguildStateService_003E5__5 = ServiceProviderServiceExtensions.GetRequiredService<IGuildStateService>(_003C_003E4__this._serviceProvider);
					_003CplayerStateService_003E5__6 = ServiceProviderServiceExtensions.GetRequiredService<IPlayerStateService>(_003C_003E4__this._serviceProvider);
					_003CplayerStateService_003E5__6.ClearSession();
					_003CguildStateService_003E5__5.ClearCurrentGuild();
					_003CsessionInitService_003E5__2.InvalidateCache();
					_003CpresentationInitService_003E5__3.InvalidateCache();
					_003CpageCacheService_003E5__4.EvictAll();
					_003CsessionListener_003E5__7 = ServiceProviderServiceExtensions.GetRequiredService<ISessionListenerService>(_003C_003E4__this._serviceProvider);
					_003CsessionListener_003E5__7.StopListening();
					_003C_003E4__this._presenceService.Stop();
					awaiter = _003C_003E4__this._firebaseAuth.SignOutAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter;
						_003C_003COnSessionInvalidated_003Eb__16_0_003Ed _003C_003COnSessionInvalidated_003Eb__16_0_003Ed = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003COnSessionInvalidated_003Eb__16_0_003Ed>(ref awaiter, ref _003C_003COnSessionInvalidated_003Eb__16_0_003Ed);
						return;
					}
					goto IL_020d;
					IL_020d:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003CnavigationService_003E5__1 = null;
					_003CsessionInitService_003E5__2 = null;
					_003CpresentationInitService_003E5__3 = null;
					_003CpageCacheService_003E5__4 = null;
					_003CguildStateService_003E5__5 = null;
					_003CplayerStateService_003E5__6 = null;
					_003CsessionListener_003E5__7 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__8 = ex;
					Console.WriteLine("AppShell: Error handling session invalidation: " + _003Cex_003E5__8.Message);
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
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		private sealed class _003C_003C_002Dctor_003Eb__1_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass14_0 _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
				//IL_006f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0074: Unknown result type (might be due to invalid IL or missing references)
				//IL_007b: Unknown result type (might be due to invalid IL or missing references)
				//IL_003b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0040: Unknown result type (might be due to invalid IL or missing references)
				//IL_0054: Unknown result type (might be due to invalid IL or missing references)
				//IL_0055: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						AppShell appShell = _003C_003E4__this._003C_003E4__this;
						IFirebaseUser currentUser = _003C_003E4__this.auth.CurrentUser;
						awaiter = appShell.HandleAuthStateChangeAsync((currentUser != null) ? currentUser.Uid : null).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003C_003C_002Dctor_003Eb__1_003Ed _003C_003C_002Dctor_003Eb__1_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003C_002Dctor_003Eb__1_003Ed>(ref awaiter, ref _003C_003C_002Dctor_003Eb__1_003Ed);
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

		public IFirebaseAuth auth;

		public AppShell _003C_003E4__this;

		[AsyncStateMachine(typeof(_003C_003C_002Dctor_003Eb__1_003Ed))]
		[DebuggerStepThrough]
		internal global::System.Threading.Tasks.Task _003C_002Ector_003Eb__1()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003C_002Dctor_003Eb__1_003Ed _003C_003C_002Dctor_003Eb__1_003Ed = new _003C_003C_002Dctor_003Eb__1_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003C_002Dctor_003Eb__1_003Ed._003C_003Et__builder)).Start<_003C_003C_002Dctor_003Eb__1_003Ed>(ref _003C_003C_002Dctor_003Eb__1_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003C_002Dctor_003Eb__1_003Ed._003C_003Et__builder)).Task;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		private sealed class _003C_003COnReconciliationRequired_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass17_0 _003C_003E4__this;

			private string _003CuserId_003E5__1;

			private Result<Player> _003Cresult_003E5__2;

			private Result<Player> _003C_003Es__3;

			private TaskAwaiter<Result<Player>> _003C_003Eu__1;

			private void MoveNext()
			{
				//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
				//IL_0088: Unknown result type (might be due to invalid IL or missing references)
				//IL_008d: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<Result<Player>> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<Player>>);
						num = (_003C_003E1__state = -1);
						goto IL_00da;
					}
					IFirebaseUser currentUser = _003C_003E4__this._003C_003E4__this._firebaseAuth.CurrentUser;
					_003CuserId_003E5__1 = ((currentUser != null) ? currentUser.Uid : null);
					if (!string.IsNullOrEmpty(_003CuserId_003E5__1))
					{
						Console.WriteLine("AppShell: Reconciling local state for player " + _003C_003E4__this.playerId + " — reloading from server.");
						awaiter = _003C_003E4__this._003C_003E4__this._sessionOrchestrator.ReconcileLocalStateAsync(_003CuserId_003E5__1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003C_003COnReconciliationRequired_003Eb__0_003Ed _003C_003COnReconciliationRequired_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<Player>>, _003C_003COnReconciliationRequired_003Eb__0_003Ed>(ref awaiter, ref _003C_003COnReconciliationRequired_003Eb__0_003Ed);
							return;
						}
						goto IL_00da;
					}
					goto end_IL_0007;
					IL_00da:
					_003C_003Es__3 = awaiter.GetResult();
					_003Cresult_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (_003Cresult_003E5__2.Success)
					{
						Console.WriteLine("AppShell: Reconciliation complete — local state refreshed from server.");
					}
					else
					{
						Console.WriteLine("AppShell: Reconciliation failed: " + _003Cresult_003E5__2.ErrorMessage);
					}
					end_IL_0007:;
				}
				catch (global::System.Exception exception)
				{
					_003C_003E1__state = -2;
					_003CuserId_003E5__1 = null;
					_003Cresult_003E5__2 = null;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003CuserId_003E5__1 = null;
				_003Cresult_003E5__2 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}
		}

		public AppShell _003C_003E4__this;

		public string playerId;

		[AsyncStateMachine(typeof(_003C_003COnReconciliationRequired_003Eb__0_003Ed))]
		[DebuggerStepThrough]
		internal global::System.Threading.Tasks.Task _003COnReconciliationRequired_003Eb__0()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003COnReconciliationRequired_003Eb__0_003Ed _003C_003COnReconciliationRequired_003Eb__0_003Ed = new _003C_003COnReconciliationRequired_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003COnReconciliationRequired_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003COnReconciliationRequired_003Eb__0_003Ed>(ref _003C_003COnReconciliationRequired_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003COnReconciliationRequired_003Eb__0_003Ed._003C_003Et__builder)).Task;
		}
	}

	[CompilerGenerated]
	private sealed class _003CHandleAuthStateChangeAsync_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string userId;

		public AppShell _003C_003E4__this;

		private AuthenticationResult _003Cresult_003E5__1;

		private AuthenticationResult _003C_003Es__2;

		private bool _003CisAccountLinked_003E5__3;

		private LinkAccountSheet _003ClinkSheet_003E5__4;

		private bool _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<AuthenticationResult> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private TaskAwaiter<bool> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_0491: Unknown result type (might be due to invalid IL or missing references)
			//IL_0496: Unknown result type (might be due to invalid IL or missing references)
			//IL_049e: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_029d: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0347: Unknown result type (might be due to invalid IL or missing references)
			//IL_034c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0354: Unknown result type (might be due to invalid IL or missing references)
			//IL_0232: Unknown result type (might be due to invalid IL or missing references)
			//IL_023c: Expected O, but got Unknown
			//IL_0264: Unknown result type (might be due to invalid IL or missing references)
			//IL_0269: Unknown result type (might be due to invalid IL or missing references)
			//IL_030e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0313: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_045b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0460: Unknown result type (might be due to invalid IL or missing references)
			//IL_027e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0280: Unknown result type (might be due to invalid IL or missing references)
			//IL_0328: Unknown result type (might be due to invalid IL or missing references)
			//IL_032a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_0475: Unknown result type (might be due to invalid IL or missing references)
			//IL_0477: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<AuthenticationResult> awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					if (string.IsNullOrEmpty(userId))
					{
						_003C_003E4__this._sessionListenerService.StopListening();
						_003C_003E4__this._presenceService.Stop();
					}
					awaiter2 = _003C_003E4__this._authOrchestrator.HandleAuthStateChangeAsync(userId).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003CHandleAuthStateChangeAsync_003Ed__15 _003CHandleAuthStateChangeAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<AuthenticationResult>, _003CHandleAuthStateChangeAsync_003Ed__15>(ref awaiter2, ref _003CHandleAuthStateChangeAsync_003Ed__);
						return;
					}
					goto IL_00ce;
				case 0:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<AuthenticationResult>);
					num = (_003C_003E1__state = -1);
					goto IL_00ce;
				case 1:
				case 2:
				case 3:
					try
					{
						TaskAwaiter awaiter5;
						TaskAwaiter<bool> awaiter4;
						TaskAwaiter awaiter3;
						LinkAccountSheet linkAccountSheet;
						List<Detent> obj;
						switch (num)
						{
						default:
							if (_003C_003E4__this._firebaseAuth.CurrentUser.IsAnonymous)
							{
								_003CisAccountLinked_003E5__3 = false;
								awaiter5 = _003C_003E4__this._navigationService.ShowAlertAsync("Something went wrong", "If you dont link your account you risk losing progress!").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter5;
									_003CHandleAuthStateChangeAsync_003Ed__15 _003CHandleAuthStateChangeAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleAuthStateChangeAsync_003Ed__15>(ref awaiter5, ref _003CHandleAuthStateChangeAsync_003Ed__);
									return;
								}
								goto IL_0207;
							}
							goto IL_02fe;
						case 1:
							awaiter5 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0207;
						case 2:
							awaiter4 = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							goto IL_02b9;
						case 3:
							{
								awaiter3 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								break;
							}
							IL_02fe:
							awaiter3 = _003C_003E4__this._firebaseAuth.SignOutAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__2 = awaiter3;
								_003CHandleAuthStateChangeAsync_003Ed__15 _003CHandleAuthStateChangeAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleAuthStateChangeAsync_003Ed__15>(ref awaiter3, ref _003CHandleAuthStateChangeAsync_003Ed__);
								return;
							}
							break;
							IL_02b9:
							_003C_003Es__5 = awaiter4.GetResult();
							_003CisAccountLinked_003E5__3 = _003C_003Es__5;
							Console.WriteLine("Account linking result: " + (_003CisAccountLinked_003E5__3 ? "Linked" : "Guest"));
							_003ClinkSheet_003E5__4 = null;
							goto IL_02fe;
							IL_0207:
							((TaskAwaiter)(ref awaiter5)).GetResult();
							_003ClinkSheet_003E5__4 = ServiceProviderServiceExtensions.GetRequiredService<LinkAccountSheet>(_003C_003E4__this._serviceProvider);
							linkAccountSheet = _003ClinkSheet_003E5__4;
							obj = new List<Detent>(1);
							obj.Add((Detent)new FullscreenDetent());
							((BottomSheet)linkAccountSheet).Detents = (global::System.Collections.Generic.IList<Detent>)obj;
							awaiter4 = _003C_003E4__this._bottomSheetService.ShowSheetAsync<bool>((BottomSheet)(object)_003ClinkSheet_003E5__4, _003ClinkSheet_003E5__4.SheetId).GetAwaiter();
							if (!awaiter4.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter4;
								_003CHandleAuthStateChangeAsync_003Ed__15 _003CHandleAuthStateChangeAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CHandleAuthStateChangeAsync_003Ed__15>(ref awaiter4, ref _003CHandleAuthStateChangeAsync_003Ed__);
								return;
							}
							goto IL_02b9;
						}
						((TaskAwaiter)(ref awaiter3)).GetResult();
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__6 = ex;
						Console.WriteLine("Failed to sign out after error: " + _003Cex_003E5__6.Message);
					}
					goto IL_0399;
				case 4:
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_0399:
					if (_003Cresult_003E5__1.Success && _003Cresult_003E5__1.State == AuthenticationState.Ready && !string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(_003C_003E4__this._sessionOrchestrator.CurrentSessionId))
					{
						_003C_003E4__this._sessionListenerService.StartListening(userId, _003C_003E4__this._sessionOrchestrator.CurrentSessionId);
						_003C_003E4__this._presenceService.Start();
					}
					if (!string.IsNullOrEmpty(_003Cresult_003E5__1.NavigationRoute.Route))
					{
						awaiter = _003C_003E4__this._navigationService.NavigateToAsync(_003Cresult_003E5__1.NavigationRoute.Route).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 4);
							_003C_003Eu__2 = awaiter;
							_003CHandleAuthStateChangeAsync_003Ed__15 _003CHandleAuthStateChangeAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleAuthStateChangeAsync_003Ed__15>(ref awaiter, ref _003CHandleAuthStateChangeAsync_003Ed__);
							return;
						}
						break;
					}
					goto end_IL_0007;
					IL_00ce:
					_003C_003Es__2 = awaiter2.GetResult();
					_003Cresult_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (!_003Cresult_003E5__1.Success)
					{
						_003C_003E4__this._navbarVM.CurrentPage = null;
						Console.WriteLine("Authentication failed: " + _003Cresult_003E5__1.ErrorMessage);
						if (!string.IsNullOrEmpty(userId))
						{
							goto case 1;
						}
					}
					goto IL_0399;
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003Cresult_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003Cresult_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003COnReconciliationRequired_003Ed__17 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public string playerId;

		public AppShell _003C_003E4__this;

		private _003C_003Ec__DisplayClass17_0 _003C_003E8__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass17_0();
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003C_003E8__1.playerId = playerId;
					awaiter = MainThread.InvokeOnMainThreadAsync((Func<global::System.Threading.Tasks.Task>)([AsyncStateMachine(typeof(_003C_003Ec__DisplayClass17_0._003C_003COnReconciliationRequired_003Eb__0_003Ed))] [DebuggerStepThrough] () =>
					{
						//IL_0007: Unknown result type (might be due to invalid IL or missing references)
						//IL_000c: Unknown result type (might be due to invalid IL or missing references)
						_003C_003Ec__DisplayClass17_0._003C_003COnReconciliationRequired_003Eb__0_003Ed _003C_003COnReconciliationRequired_003Eb__0_003Ed = new _003C_003Ec__DisplayClass17_0._003C_003COnReconciliationRequired_003Eb__0_003Ed
						{
							_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
							_003C_003E4__this = _003C_003E8__1,
							_003C_003E1__state = -1
						};
						((AsyncTaskMethodBuilder)(ref _003C_003COnReconciliationRequired_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass17_0._003C_003COnReconciliationRequired_003Eb__0_003Ed>(ref _003C_003COnReconciliationRequired_003Eb__0_003Ed);
						return ((AsyncTaskMethodBuilder)(ref _003C_003COnReconciliationRequired_003Eb__0_003Ed._003C_003Et__builder)).Task;
					})).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003COnReconciliationRequired_003Ed__17 _003COnReconciliationRequired_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnReconciliationRequired_003Ed__17>(ref awaiter, ref _003COnReconciliationRequired_003Ed__);
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
				_003C_003E8__1 = null;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003COnSessionInvalidated_003Ed__16 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public SessionInvalidatedEventArgs e;

		public AppShell _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = MainThread.InvokeOnMainThreadAsync((Func<global::System.Threading.Tasks.Task>)([AsyncStateMachine(typeof(_003C_003COnSessionInvalidated_003Eb__16_0_003Ed))] [DebuggerStepThrough] [CompilerGenerated] () =>
					{
						//IL_0007: Unknown result type (might be due to invalid IL or missing references)
						//IL_000c: Unknown result type (might be due to invalid IL or missing references)
						_003C_003COnSessionInvalidated_003Eb__16_0_003Ed _003C_003COnSessionInvalidated_003Eb__16_0_003Ed = new _003C_003COnSessionInvalidated_003Eb__16_0_003Ed
						{
							_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
							_003C_003E4__this = _003C_003E4__this,
							_003C_003E1__state = -1
						};
						((AsyncTaskMethodBuilder)(ref _003C_003COnSessionInvalidated_003Eb__16_0_003Ed._003C_003Et__builder)).Start<_003C_003COnSessionInvalidated_003Eb__16_0_003Ed>(ref _003C_003COnSessionInvalidated_003Eb__16_0_003Ed);
						return ((AsyncTaskMethodBuilder)(ref _003C_003COnSessionInvalidated_003Eb__16_0_003Ed._003C_003Et__builder)).Task;
					})).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003COnSessionInvalidated_003Ed__16 _003COnSessionInvalidated_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnSessionInvalidated_003Ed__16>(ref awaiter, ref _003COnSessionInvalidated_003Ed__);
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
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
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

	private readonly IFirebaseAuth _firebaseAuth;

	private readonly IAuthenticationOrchestrator _authOrchestrator;

	private readonly ISessionInitializationOrchestrator _sessionOrchestrator;

	private readonly NavBarViewModel _navbarVM;

	private readonly global::System.IDisposable? _authStateListener;

	private readonly INavigationService _navigationService;

	private readonly IServiceProvider _serviceProvider;

	private readonly IBottomSheetService _bottomSheetService;

	private readonly ISessionListenerService _sessionListenerService;

	private readonly IPresenceService _presenceService;

	private readonly IBatchQueueService _batchQueueService;

	private readonly IStaticDataCacheService _staticDataCacheService;

	private readonly IAppVersionListenerService _appVersionListenerService;

	private StaticDataUpdatingPopup? _updatingPopup;

	public AppShell(IFirebaseAuth firebaseAuth, IAuthenticationOrchestrator authOrchestrator, ISessionInitializationOrchestrator sessionOrchestrator, NavBarViewModel navBarViewModel, INavigationService navigationService, IServiceProvider serviceProvider, IBottomSheetService bottomSheetService, ISessionListenerService sessionListenerService, IPresenceService presenceService, IBatchQueueService batchQueueService, IStaticDataCacheService staticDataCacheService, IAppVersionListenerService appVersionListenerService)
	{
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		InitializeComponent();
		_firebaseAuth = firebaseAuth;
		_authOrchestrator = authOrchestrator;
		_sessionOrchestrator = sessionOrchestrator;
		_navbarVM = navBarViewModel;
		_navigationService = navigationService;
		_serviceProvider = serviceProvider;
		_bottomSheetService = bottomSheetService;
		_sessionListenerService = sessionListenerService;
		_presenceService = presenceService;
		_batchQueueService = batchQueueService;
		_staticDataCacheService = staticDataCacheService;
		_appVersionListenerService = appVersionListenerService;
		_sessionListenerService.SessionInvalidated += OnSessionInvalidated;
		_batchQueueService.ReconciliationRequired += OnReconciliationRequired;
		_staticDataCacheService.StaticDataUpdateStarted += new Action(OnStaticDataUpdateStarted);
		_staticDataCacheService.StaticDataUpdateEnded += new Action(OnStaticDataUpdateEnded);
		_appVersionListenerService.UpdateRequired += new EventHandler(OnUpdateRequired);
		_authStateListener = _firebaseAuth.AddAuthStateListener((Action<IFirebaseAuth>)([AsyncStateMachine(typeof(_003C_003C_002Dctor_003Eb__14_0_003Ed))] [DebuggerStepThrough] [CompilerGenerated] (IFirebaseAuth auth) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003C_002Dctor_003Eb__14_0_003Ed _003C_003C_002Dctor_003Eb__14_0_003Ed = new _003C_003C_002Dctor_003Eb__14_0_003Ed
			{
				_003C_003Et__builder = AsyncVoidMethodBuilder.Create(),
				_003C_003E4__this = this,
				auth = auth,
				_003C_003E1__state = -1
			};
			((AsyncVoidMethodBuilder)(ref _003C_003C_002Dctor_003Eb__14_0_003Ed._003C_003Et__builder)).Start<_003C_003C_002Dctor_003Eb__14_0_003Ed>(ref _003C_003C_002Dctor_003Eb__14_0_003Ed);
		}));
	}

	[AsyncStateMachine(typeof(_003CHandleAuthStateChangeAsync_003Ed__15))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task HandleAuthStateChangeAsync(string? userId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CHandleAuthStateChangeAsync_003Ed__15 _003CHandleAuthStateChangeAsync_003Ed__ = new _003CHandleAuthStateChangeAsync_003Ed__15();
		_003CHandleAuthStateChangeAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CHandleAuthStateChangeAsync_003Ed__._003C_003E4__this = this;
		_003CHandleAuthStateChangeAsync_003Ed__.userId = userId;
		_003CHandleAuthStateChangeAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CHandleAuthStateChangeAsync_003Ed__._003C_003Et__builder)).Start<_003CHandleAuthStateChangeAsync_003Ed__15>(ref _003CHandleAuthStateChangeAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CHandleAuthStateChangeAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003COnSessionInvalidated_003Ed__16))]
	[DebuggerStepThrough]
	private void OnSessionInvalidated(object? sender, SessionInvalidatedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COnSessionInvalidated_003Ed__16 _003COnSessionInvalidated_003Ed__ = new _003COnSessionInvalidated_003Ed__16();
		_003COnSessionInvalidated_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003COnSessionInvalidated_003Ed__._003C_003E4__this = this;
		_003COnSessionInvalidated_003Ed__.sender = sender;
		_003COnSessionInvalidated_003Ed__.e = e;
		_003COnSessionInvalidated_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003COnSessionInvalidated_003Ed__._003C_003Et__builder)).Start<_003COnSessionInvalidated_003Ed__16>(ref _003COnSessionInvalidated_003Ed__);
	}

	[AsyncStateMachine(typeof(_003COnReconciliationRequired_003Ed__17))]
	[DebuggerStepThrough]
	private void OnReconciliationRequired(object? sender, string playerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COnReconciliationRequired_003Ed__17 _003COnReconciliationRequired_003Ed__ = new _003COnReconciliationRequired_003Ed__17();
		_003COnReconciliationRequired_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003COnReconciliationRequired_003Ed__._003C_003E4__this = this;
		_003COnReconciliationRequired_003Ed__.sender = sender;
		_003COnReconciliationRequired_003Ed__.playerId = playerId;
		_003COnReconciliationRequired_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003COnReconciliationRequired_003Ed__._003C_003Et__builder)).Start<_003COnReconciliationRequired_003Ed__17>(ref _003COnReconciliationRequired_003Ed__);
	}

	private void OnUpdateRequired(object? sender, EventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		MainThread.BeginInvokeOnMainThread((Action)([CompilerGenerated] () =>
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			PopupExtensions.ShowPopupAsync<UpdateRequiredPopup>((Page)(object)this, new UpdateRequiredPopup(), default(CancellationToken));
		}));
	}

	private void OnStaticDataUpdateStarted()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		MainThread.BeginInvokeOnMainThread((Action)([CompilerGenerated] () =>
		{
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			string text = Shell.Current.CurrentState.Location.OriginalString ?? "";
			if (!text.Contains("battleground", (StringComparison)5))
			{
				_updatingPopup = new StaticDataUpdatingPopup();
				PopupExtensions.ShowPopupAsync<StaticDataUpdatingPopup>((Page)(object)this, _updatingPopup, default(CancellationToken));
			}
		}));
	}

	private void OnStaticDataUpdateEnded()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		MainThread.BeginInvokeOnMainThread((Action)([CompilerGenerated] () =>
		{
			StaticDataUpdatingPopup? updatingPopup = _updatingPopup;
			if (updatingPopup != null)
			{
				((Popup)updatingPopup).Close((object)null);
			}
			_updatingPopup = null;
		}));
	}

	protected override void OnDisappearing()
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		((Page)this).OnDisappearing();
		_authStateListener?.Dispose();
		_sessionListenerService.SessionInvalidated -= OnSessionInvalidated;
		_sessionListenerService.StopListening();
		_batchQueueService.ReconciliationRequired -= OnReconciliationRequired;
		_staticDataCacheService.StaticDataUpdateStarted -= new Action(OnStaticDataUpdateStarted);
		_staticDataCacheService.StaticDataUpdateEnded -= new Action(OnStaticDataUpdateEnded);
		_appVersionListenerService.UpdateRequired -= new EventHandler(OnUpdateRequired);
		_appVersionListenerService.StopListening();
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<AppShell>(this, typeof(AppShell));
	}
}
