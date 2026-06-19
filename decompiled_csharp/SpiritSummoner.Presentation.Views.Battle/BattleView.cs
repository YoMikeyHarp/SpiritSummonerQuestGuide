using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Battles;
using SpiritSummoner.Presentation.ViewModels.Shared;
using epj.ProgressBar.Maui;

namespace SpiritSummoner.Presentation.Views.Battle;

[XamlFilePath("Presentation\\Views\\Battle\\BattleView.xaml")]
public class BattleView : ContentPage
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public Func<global::System.Threading.Tasks.Task> animationAction;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_1
	{
		private sealed class _003C_003CSafeAnimateOnMainThread_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass9_1 _003C_003E4__this;

			private global::System.Exception _003Cex_003E5__1;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
				//IL_0064: Unknown result type (might be due to invalid IL or missing references)
				//IL_0069: Unknown result type (might be due to invalid IL or missing references)
				//IL_0070: Unknown result type (might be due to invalid IL or missing references)
				//IL_002d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0032: Unknown result type (might be due to invalid IL or missing references)
				//IL_0046: Unknown result type (might be due to invalid IL or missing references)
				//IL_0047: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
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
							awaiter = _003C_003E4__this.CS_0024_003C_003E8__locals1.animationAction.Invoke().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003C_003CSafeAnimateOnMainThread_003Eb__0_003Ed _003C_003CSafeAnimateOnMainThread_003Eb__0_003Ed = this;
								((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003CSafeAnimateOnMainThread_003Eb__0_003Ed>(ref awaiter, ref _003C_003CSafeAnimateOnMainThread_003Eb__0_003Ed);
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
						_003C_003E4__this.tcs.SetResult(true);
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__1 = ex;
						Console.WriteLine("SafeAnimateOnMainThread error: " + _003Cex_003E5__1.Message);
						_003C_003E4__this.tcs.SetException(_003Cex_003E5__1);
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

		public TaskCompletionSource<bool> tcs;

		public _003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals1;

		[AsyncStateMachine(typeof(_003C_003CSafeAnimateOnMainThread_003Eb__0_003Ed))]
		[DebuggerStepThrough]
		internal void _003CSafeAnimateOnMainThread_003Eb__0()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003CSafeAnimateOnMainThread_003Eb__0_003Ed _003C_003CSafeAnimateOnMainThread_003Eb__0_003Ed = new _003C_003CSafeAnimateOnMainThread_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncVoidMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncVoidMethodBuilder)(ref _003C_003CSafeAnimateOnMainThread_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003CSafeAnimateOnMainThread_003Eb__0_003Ed>(ref _003C_003CSafeAnimateOnMainThread_003Eb__0_003Ed);
		}
	}

	[CompilerGenerated]
	private sealed class _003CAnimateTurnTrackerGlow_003Ed__8 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleView _003C_003E4__this;

		private TaskAwaiter<bool[]> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<bool[]> awaiter;
				TaskAwaiter<bool[]> awaiter2;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool[]>);
						num = (_003C_003E1__state = -1);
						goto IL_01bf;
					}
					((VisualElement)_003C_003E4__this.TurnTrackerLabel).Scale = 0.92;
					_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>> buffer = default(_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>);
					_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 0) = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.TurnTrackerLabel, 1.0, 180u, Easing.CubicOut);
					_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 1) = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.TurnTrackerLabel, 1.12, 180u, Easing.CubicOut);
					awaiter2 = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer, 2)).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003CAnimateTurnTrackerGlow_003Ed__8 _003CAnimateTurnTrackerGlow_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003CAnimateTurnTrackerGlow_003Ed__8>(ref awaiter2, ref _003CAnimateTurnTrackerGlow_003Ed__);
						return;
					}
				}
				else
				{
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool[]>);
					num = (_003C_003E1__state = -1);
				}
				awaiter2.GetResult();
				_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>> buffer2 = default(_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>);
				_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer2, 0) = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.TurnTrackerLabel, 1.0, 140u, Easing.CubicIn);
				_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer2, 1) = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.TurnTrackerLabel, 0.87, 320u, Easing.CubicInOut);
				awaiter = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer2, 2)).GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CAnimateTurnTrackerGlow_003Ed__8 _003CAnimateTurnTrackerGlow_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003CAnimateTurnTrackerGlow_003Ed__8>(ref awaiter, ref _003CAnimateTurnTrackerGlow_003Ed__);
					return;
				}
				goto IL_01bf;
				IL_01bf:
				awaiter.GetResult();
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
	private sealed class _003CHandleBattleStateChange_003Ed__11 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleView _003C_003E4__this;

		private bool _003CplayerWon_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0249: Unknown result type (might be due to invalid IL or missing references)
			//IL_024e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0256: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_0288: Unknown result type (might be due to invalid IL or missing references)
			//IL_028d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_020f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0214: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0229: Unknown result type (might be due to invalid IL or missing references)
			//IL_022b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter4;
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter3;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					if (_003C_003E4__this._viewModel.CurrentState == BattleViewModelRefactored.BattleViewState.Ended)
					{
						_003CplayerWon_003E5__1 = _003C_003E4__this._viewModel?.ActiveEnemy?.HP < _003C_003E4__this._viewModel?.ActivePlayerSpirit?.HP;
						if (_003CplayerWon_003E5__1)
						{
							awaiter4 = _003C_003E4__this._animationService.AnimateVictoryPose(_003C_003E4__this.PlayerSprite).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter4;
								_003CHandleBattleStateChange_003Ed__11 _003CHandleBattleStateChange_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleBattleStateChange_003Ed__11>(ref awaiter4, ref _003CHandleBattleStateChange_003Ed__);
								return;
							}
							goto IL_016c;
						}
						awaiter2 = _003C_003E4__this._animationService.AnimateVictoryPose(_003C_003E4__this.EnemySprite).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = awaiter2;
							_003CHandleBattleStateChange_003Ed__11 _003CHandleBattleStateChange_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleBattleStateChange_003Ed__11>(ref awaiter2, ref _003CHandleBattleStateChange_003Ed__);
							return;
						}
						goto IL_0265;
					}
					goto end_IL_0007;
				case 0:
					awaiter4 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_016c;
				case 1:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01e5;
				case 2:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0265;
				case 3:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_0265:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					awaiter = _003C_003E4__this._animationService.AnimateDefeatPose(_003C_003E4__this.PlayerSprite).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = awaiter;
						_003CHandleBattleStateChange_003Ed__11 _003CHandleBattleStateChange_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleBattleStateChange_003Ed__11>(ref awaiter, ref _003CHandleBattleStateChange_003Ed__);
						return;
					}
					break;
					IL_01e5:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					goto end_IL_0007;
					IL_016c:
					((TaskAwaiter)(ref awaiter4)).GetResult();
					awaiter3 = _003C_003E4__this._animationService.AnimateDefeatPose(_003C_003E4__this.EnemySprite).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter3;
						_003CHandleBattleStateChange_003Ed__11 _003CHandleBattleStateChange_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleBattleStateChange_003Ed__11>(ref awaiter3, ref _003CHandleBattleStateChange_003Ed__);
						return;
					}
					goto IL_01e5;
				}
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

	[CompilerGenerated]
	private sealed class _003CHandleSpiritIndexChange_003Ed__10 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public bool isPlayer;

		public BattleView _003C_003E4__this;

		private ObservableCollection<SpriteModel> _003Cspirits_003E5__1;

		private int _003CcurrentIndex_003E5__2;

		private Image _003Csprite_003E5__3;

		private SpriteModel _003CpreviousSpirit_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_0148: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_015e;
				}
				_003Cspirits_003E5__1 = (isPlayer ? _003C_003E4__this._viewModel.PlayerSpirits : _003C_003E4__this._viewModel.EnemySpirits);
				_003CcurrentIndex_003E5__2 = (isPlayer ? _003C_003E4__this._viewModel.ActivePlayerSpiritIndex : _003C_003E4__this._viewModel.ActiveEnemyIndex);
				_003Csprite_003E5__3 = (isPlayer ? _003C_003E4__this.PlayerSprite : _003C_003E4__this.EnemySprite);
				if (_003CcurrentIndex_003E5__2 > 0 && _003CcurrentIndex_003E5__2 - 1 < ((Collection<SpriteModel>)(object)_003Cspirits_003E5__1).Count)
				{
					_003CpreviousSpirit_003E5__4 = ((Collection<SpriteModel>)(object)_003Cspirits_003E5__1)[_003CcurrentIndex_003E5__2 - 1];
					if (_003CpreviousSpirit_003E5__4.Opacity <= 0.5)
					{
						awaiter = _003C_003E4__this._animationService.AnimateDefeatPose(_003Csprite_003E5__3).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CHandleSpiritIndexChange_003Ed__10 _003CHandleSpiritIndexChange_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleSpiritIndexChange_003Ed__10>(ref awaiter, ref _003CHandleSpiritIndexChange_003Ed__);
							return;
						}
						goto IL_015e;
					}
					goto IL_0167;
				}
				goto end_IL_0007;
				IL_0167:
				_003CpreviousSpirit_003E5__4 = null;
				goto end_IL_0007;
				IL_015e:
				((TaskAwaiter)(ref awaiter)).GetResult();
				goto IL_0167;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cspirits_003E5__1 = null;
				_003Csprite_003E5__3 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cspirits_003E5__1 = null;
			_003Csprite_003E5__3 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003COnViewModelPropertyChanged_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public PropertyChangedEventArgs e;

		public BattleView _003C_003E4__this;

		private string _003C_003Es__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0623: Unknown result type (might be due to invalid IL or missing references)
			//IL_0628: Unknown result type (might be due to invalid IL or missing references)
			//IL_0630: Unknown result type (might be due to invalid IL or missing references)
			//IL_06a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_06a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_06af: Unknown result type (might be due to invalid IL or missing references)
			//IL_0721: Unknown result type (might be due to invalid IL or missing references)
			//IL_0726: Unknown result type (might be due to invalid IL or missing references)
			//IL_072e: Unknown result type (might be due to invalid IL or missing references)
			//IL_07a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_07a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_07ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_081f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0824: Unknown result type (might be due to invalid IL or missing references)
			//IL_082c: Unknown result type (might be due to invalid IL or missing references)
			//IL_089e: Unknown result type (might be due to invalid IL or missing references)
			//IL_08a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_08ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_091d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0922: Unknown result type (might be due to invalid IL or missing references)
			//IL_092a: Unknown result type (might be due to invalid IL or missing references)
			//IL_099c: Unknown result type (might be due to invalid IL or missing references)
			//IL_09a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_09a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a1b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a20: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a28: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ab1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ab6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0abe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b2e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b33: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b3b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bae: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bb3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bbb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c2e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c33: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c3b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cae: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cb3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cbb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d2e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d33: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d3b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0dae: Unknown result type (might be due to invalid IL or missing references)
			//IL_0db3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0dbb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e2e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e33: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e3b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0eae: Unknown result type (might be due to invalid IL or missing references)
			//IL_0eb3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ebb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f2e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f33: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f3b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0fae: Unknown result type (might be due to invalid IL or missing references)
			//IL_0fb3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0fbb: Unknown result type (might be due to invalid IL or missing references)
			//IL_102e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1033: Unknown result type (might be due to invalid IL or missing references)
			//IL_103b: Unknown result type (might be due to invalid IL or missing references)
			//IL_10ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_10b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_10bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_112e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1133: Unknown result type (might be due to invalid IL or missing references)
			//IL_113b: Unknown result type (might be due to invalid IL or missing references)
			//IL_11ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_11b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_11bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_122e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1233: Unknown result type (might be due to invalid IL or missing references)
			//IL_123b: Unknown result type (might be due to invalid IL or missing references)
			//IL_1443: Unknown result type (might be due to invalid IL or missing references)
			//IL_1448: Unknown result type (might be due to invalid IL or missing references)
			//IL_1450: Unknown result type (might be due to invalid IL or missing references)
			//IL_0668: Unknown result type (might be due to invalid IL or missing references)
			//IL_066d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0df3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0df8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d73: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d78: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cf3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cf8: Unknown result type (might be due to invalid IL or missing references)
			//IL_08e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_08e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bf3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bf8: Unknown result type (might be due to invalid IL or missing references)
			//IL_1173: Unknown result type (might be due to invalid IL or missing references)
			//IL_1178: Unknown result type (might be due to invalid IL or missing references)
			//IL_0682: Unknown result type (might be due to invalid IL or missing references)
			//IL_0684: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e0e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e10: Unknown result type (might be due to invalid IL or missing references)
			//IL_07e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_07ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_10f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_10f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d8e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d90: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d0e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d10: Unknown result type (might be due to invalid IL or missing references)
			//IL_08fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_08ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ef3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ef8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c0e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c10: Unknown result type (might be due to invalid IL or missing references)
			//IL_118e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1190: Unknown result type (might be due to invalid IL or missing references)
			//IL_0603: Unknown result type (might be due to invalid IL or missing references)
			//IL_0605: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e73: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e78: Unknown result type (might be due to invalid IL or missing references)
			//IL_07ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0801: Unknown result type (might be due to invalid IL or missing references)
			//IL_110e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0864: Unknown result type (might be due to invalid IL or missing references)
			//IL_0869: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f73: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f78: Unknown result type (might be due to invalid IL or missing references)
			//IL_1073: Unknown result type (might be due to invalid IL or missing references)
			//IL_1078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f0e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f10: Unknown result type (might be due to invalid IL or missing references)
			//IL_06e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b73: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b78: Unknown result type (might be due to invalid IL or missing references)
			//IL_0af3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0af8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a76: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a7b: Unknown result type (might be due to invalid IL or missing references)
			//IL_140b: Unknown result type (might be due to invalid IL or missing references)
			//IL_1410: Unknown result type (might be due to invalid IL or missing references)
			//IL_09e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_09e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e8e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e90: Unknown result type (might be due to invalid IL or missing references)
			//IL_0766: Unknown result type (might be due to invalid IL or missing references)
			//IL_076b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ff3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ff8: Unknown result type (might be due to invalid IL or missing references)
			//IL_087e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0880: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f8e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f90: Unknown result type (might be due to invalid IL or missing references)
			//IL_108e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0701: Unknown result type (might be due to invalid IL or missing references)
			//IL_0703: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b8e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b90: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b0e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b10: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a91: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a93: Unknown result type (might be due to invalid IL or missing references)
			//IL_11f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_11f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_1426: Unknown result type (might be due to invalid IL or missing references)
			//IL_1428: Unknown result type (might be due to invalid IL or missing references)
			//IL_09fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_09fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c73: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c78: Unknown result type (might be due to invalid IL or missing references)
			//IL_0780: Unknown result type (might be due to invalid IL or missing references)
			//IL_0782: Unknown result type (might be due to invalid IL or missing references)
			//IL_100e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0962: Unknown result type (might be due to invalid IL or missing references)
			//IL_0967: Unknown result type (might be due to invalid IL or missing references)
			//IL_120e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1210: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c8e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c90: Unknown result type (might be due to invalid IL or missing references)
			//IL_097c: Unknown result type (might be due to invalid IL or missing references)
			//IL_097e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				string text;
				TaskAwaiter awaiter26;
				TaskAwaiter awaiter25;
				TaskAwaiter awaiter24;
				TaskAwaiter awaiter23;
				TaskAwaiter awaiter22;
				TaskAwaiter awaiter21;
				TaskAwaiter awaiter20;
				TaskAwaiter awaiter19;
				TaskAwaiter awaiter18;
				TaskAwaiter awaiter17;
				TaskAwaiter awaiter16;
				TaskAwaiter awaiter15;
				TaskAwaiter awaiter14;
				TaskAwaiter awaiter13;
				TaskAwaiter awaiter12;
				TaskAwaiter awaiter11;
				TaskAwaiter awaiter10;
				TaskAwaiter awaiter9;
				TaskAwaiter awaiter8;
				TaskAwaiter awaiter7;
				TaskAwaiter awaiter6;
				TaskAwaiter awaiter5;
				TaskAwaiter awaiter4;
				TaskAwaiter awaiter3;
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
				{
					Console.WriteLine($"BattleView: Property changed - {e.PropertyName} on thread {Environment.CurrentManagedThreadId}");
					string propertyName = e.PropertyName;
					_003C_003Es__1 = propertyName;
					text = _003C_003Es__1;
					switch (_003CPrivateImplementationDetails_003E.ComputeStringHash(text))
					{
					case 1886062194u:
						break;
					case 2488214782u:
						goto IL_0396;
					case 3124683601u:
						goto IL_03ab;
					case 1211524538u:
						goto IL_03c0;
					case 1086647111u:
						goto IL_03d5;
					case 472871863u:
						goto IL_03ea;
					case 3945201186u:
						goto IL_03ff;
					case 551167427u:
						goto IL_0414;
					case 2047801953u:
						goto IL_0429;
					case 2546512937u:
						goto IL_043e;
					case 2771183795u:
						goto IL_0453;
					case 2846189158u:
						goto IL_0468;
					case 1366290680u:
						goto IL_047d;
					case 4120159299u:
						goto IL_0492;
					case 315444216u:
						goto IL_04a7;
					case 1229372739u:
						goto IL_04bc;
					case 1289539583u:
						goto IL_04d1;
					case 3330562378u:
						goto IL_04e6;
					case 4187722273u:
						goto IL_04fb;
					case 1065348394u:
						goto IL_0510;
					case 4072873126u:
						goto IL_0525;
					case 763883077u:
						goto IL_053a;
					case 2735209196u:
						goto IL_054f;
					case 2672569695u:
						goto IL_0564;
					case 3127499701u:
						if (text == "ActivePlayerSpiritIndex")
						{
							Console.WriteLine($"BattleView: ActivePlayerSpiritIndex changed to {_003C_003E4__this._viewModel.ActivePlayerSpiritIndex}");
							if (_003C_003E4__this._viewModel.ActivePlayerSpirit != null)
							{
								Console.WriteLine($"BattleView: New ActivePlayerSpirit - HP%: {_003C_003E4__this._viewModel.ActivePlayerSpirit.HealthPercentage:P0}, Opacity: {_003C_003E4__this._viewModel.ActivePlayerSpirit.Opacity}");
							}
						}
						goto end_IL_0008;
					case 2138790483u:
						if (text == "ActiveEnemyIndex")
						{
							Console.WriteLine($"BattleView: ActiveEnemyIndex changed to {_003C_003E4__this._viewModel.ActiveEnemyIndex}");
							if (_003C_003E4__this._viewModel.ActiveEnemy != null)
							{
								Console.WriteLine($"BattleView: New ActiveEnemy - HP%: {_003C_003E4__this._viewModel.ActiveEnemy.HealthPercentage:P0}, Opacity: {_003C_003E4__this._viewModel.ActiveEnemy.Opacity}");
							}
						}
						goto end_IL_0008;
					case 2394340175u:
						goto IL_05a3;
					case 3507761657u:
						if (text == "CurrentTurn")
						{
							_003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this.AnimateTurnTrackerGlow());
						}
						goto end_IL_0008;
					default:
						goto end_IL_0008;
					}
					if (!(text == "TriggerVsFade"))
					{
						break;
					}
					awaiter26 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimateVsScreenFade(_003C_003E4__this.VsCanvas)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter26)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter26;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter26, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_063f;
				}
				case 0:
					awaiter26 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_063f;
				case 1:
					awaiter25 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_06be;
				case 2:
					awaiter24 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_073d;
				case 3:
					awaiter23 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_07bc;
				case 4:
					awaiter22 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_083b;
				case 5:
					awaiter21 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_08ba;
				case 6:
					awaiter20 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0939;
				case 7:
					awaiter19 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_09b8;
				case 8:
					awaiter18 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0a37;
				case 9:
					awaiter17 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0acd;
				case 10:
					awaiter16 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0b4a;
				case 11:
					awaiter15 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0bca;
				case 12:
					awaiter14 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0c4a;
				case 13:
					awaiter13 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0cca;
				case 14:
					awaiter12 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0d4a;
				case 15:
					awaiter11 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0dca;
				case 16:
					awaiter10 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0e4a;
				case 17:
					awaiter9 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0eca;
				case 18:
					awaiter8 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0f4a;
				case 19:
					awaiter7 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0fca;
				case 20:
					awaiter6 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_104a;
				case 21:
					awaiter5 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_10ca;
				case 22:
					awaiter4 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_114a;
				case 23:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_11ca;
				case 24:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_124a;
				case 25:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_145f;
					}
					IL_05a3:
					if (!(text == "CurrentState"))
					{
						break;
					}
					awaiter = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this.HandleBattleStateChange()).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 25);
						_003C_003Eu__1 = awaiter;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_145f;
					IL_0939:
					((TaskAwaiter)(ref awaiter20)).GetResult();
					break;
					IL_03ea:
					if (!(text == "TriggerSpiritSwitchPlayer"))
					{
						break;
					}
					awaiter21 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimateSpiritSwitchOut(_003C_003E4__this.PlayerSprite, isPlayer: true)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter21)).IsCompleted)
					{
						num = (_003C_003E1__state = 5);
						_003C_003Eu__1 = awaiter21;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter21, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_08ba;
					IL_145f:
					((TaskAwaiter)(ref awaiter)).GetResult();
					break;
					IL_0564:
					if (!(text == "ShowHealingBadgeEnemy"))
					{
						break;
					}
					awaiter2 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimateStatusIcon((View)(object)_003C_003E4__this.HealingBadgeEnemy, _003C_003E4__this._viewModel.ShowHealingBadgeEnemy, isPlayer: false)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 24);
						_003C_003Eu__1 = awaiter2;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter2, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_124a;
					IL_0c4a:
					((TaskAwaiter)(ref awaiter14)).GetResult();
					break;
					IL_0453:
					if (!(text == "ShowMoveIndicatorPlayer"))
					{
						break;
					}
					awaiter15 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimateMoveIndicator((View)(object)_003C_003E4__this.MoveIndicatorPlayer, _003C_003E4__this._viewModel.ShowMoveIndicatorPlayer)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter15)).IsCompleted)
					{
						num = (_003C_003E1__state = 11);
						_003C_003Eu__1 = awaiter15;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter15, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_0bca;
					IL_124a:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					break;
					IL_054f:
					if (!(text == "ShowHealingBadgePlayer"))
					{
						break;
					}
					awaiter3 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimateStatusIcon((View)(object)_003C_003E4__this.HealingBadgePlayer, _003C_003E4__this._viewModel.ShowHealingBadgePlayer, isPlayer: true)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
					{
						num = (_003C_003E1__state = 23);
						_003C_003Eu__1 = awaiter3;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter3, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_11ca;
					IL_0cca:
					((TaskAwaiter)(ref awaiter13)).GetResult();
					break;
					IL_073d:
					((TaskAwaiter)(ref awaiter24)).GetResult();
					break;
					IL_11ca:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					break;
					IL_053a:
					if (!(text == "ShowPoisonBadgeEnemy"))
					{
						break;
					}
					awaiter4 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimateStatusIcon((View)(object)_003C_003E4__this.PoisonBadgeEnemy, _003C_003E4__this._viewModel.ShowPoisonBadgeEnemy, isPlayer: false)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
					{
						num = (_003C_003E1__state = 22);
						_003C_003Eu__1 = awaiter4;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter4, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_114a;
					IL_0bca:
					((TaskAwaiter)(ref awaiter15)).GetResult();
					break;
					IL_043e:
					if (!(text == "TriggerHealthDrain"))
					{
						break;
					}
					if (_003C_003E4__this._viewModel.IsHealthDrainForPlayer)
					{
						awaiter17 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimateHealthDrain(_003C_003E4__this.PlayerHealthBar, _003C_003E4__this._viewModel.HealthDrainFrom, _003C_003E4__this._viewModel.HealthDrainTo)).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter17)).IsCompleted)
						{
							num = (_003C_003E1__state = 9);
							_003C_003Eu__1 = awaiter17;
							_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
							((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter17, ref _003COnViewModelPropertyChanged_003Ed__);
							return;
						}
						goto IL_0acd;
					}
					awaiter16 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimateHealthDrain(_003C_003E4__this.EnemyHealthBar, _003C_003E4__this._viewModel.HealthDrainFrom, _003C_003E4__this._viewModel.HealthDrainTo)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter16)).IsCompleted)
					{
						num = (_003C_003E1__state = 10);
						_003C_003Eu__1 = awaiter16;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter16, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_0b4a;
					IL_114a:
					((TaskAwaiter)(ref awaiter4)).GetResult();
					break;
					IL_0525:
					if (!(text == "ShowPoisonBadgePlayer"))
					{
						break;
					}
					awaiter5 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimateStatusIcon((View)(object)_003C_003E4__this.PoisonBadgePlayer, _003C_003E4__this._viewModel.ShowPoisonBadgePlayer, isPlayer: true)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
					{
						num = (_003C_003E1__state = 21);
						_003C_003Eu__1 = awaiter5;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter5, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_10ca;
					IL_08ba:
					((TaskAwaiter)(ref awaiter21)).GetResult();
					break;
					IL_03d5:
					if (!(text == "TriggerEnemyEntry"))
					{
						break;
					}
					awaiter22 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimateSpiritEntry(_003C_003E4__this.EnemySprite, isPlayer: false)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter22)).IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__1 = awaiter22;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter22, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_083b;
					IL_10ca:
					((TaskAwaiter)(ref awaiter5)).GetResult();
					break;
					IL_0510:
					if (!(text == "ShowEvasionBadgeEnemy"))
					{
						break;
					}
					awaiter6 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimateStatusIcon((View)(object)_003C_003E4__this.EvasionBadgeEnemy, _003C_003E4__this._viewModel.ShowEvasionBadgeEnemy, isPlayer: false)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter6)).IsCompleted)
					{
						num = (_003C_003E1__state = 20);
						_003C_003Eu__1 = awaiter6;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter6, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_104a;
					IL_0468:
					if (!(text == "ShowMoveIndicatorEnemy"))
					{
						break;
					}
					awaiter14 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimateMoveIndicator((View)(object)_003C_003E4__this.MoveIndicatorEnemy, _003C_003E4__this._viewModel.ShowMoveIndicatorEnemy)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter14)).IsCompleted)
					{
						num = (_003C_003E1__state = 12);
						_003C_003Eu__1 = awaiter14;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter14, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_0c4a;
					IL_0acd:
					((TaskAwaiter)(ref awaiter17)).GetResult();
					break;
					IL_104a:
					((TaskAwaiter)(ref awaiter6)).GetResult();
					break;
					IL_04fb:
					if (!(text == "ShowStatusEffectEnemy"))
					{
						break;
					}
					awaiter7 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimateStatusBadge((View)(object)_003C_003E4__this.StatusBadgeEnemy, _003C_003E4__this._viewModel.ShowStatusEffectEnemy)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter7)).IsCompleted)
					{
						num = (_003C_003E1__state = 19);
						_003C_003Eu__1 = awaiter7;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter7, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_0fca;
					IL_0396:
					if (!(text == "TriggerPlayerAttack"))
					{
						break;
					}
					awaiter25 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimatePlayerAttack(_003C_003E4__this.PlayerSprite, _003C_003E4__this.BattleContent, _003C_003E4__this._viewModel.Effectiveness)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter25)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter25;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter25, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_06be;
					IL_083b:
					((TaskAwaiter)(ref awaiter22)).GetResult();
					break;
					IL_0fca:
					((TaskAwaiter)(ref awaiter7)).GetResult();
					break;
					IL_04e6:
					if (!(text == "ShowStatusEffectPlayer"))
					{
						break;
					}
					awaiter8 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimateStatusBadge((View)(object)_003C_003E4__this.StatusBadgePlayer, _003C_003E4__this._viewModel.ShowStatusEffectPlayer)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter8)).IsCompleted)
					{
						num = (_003C_003E1__state = 18);
						_003C_003Eu__1 = awaiter8;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter8, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_0f4a;
					IL_0b4a:
					((TaskAwaiter)(ref awaiter16)).GetResult();
					break;
					IL_0429:
					if (!(text == "TriggerRecoilShake"))
					{
						break;
					}
					awaiter18 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimateScreenShake(_003C_003E4__this.BattleContent, 0.5)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter18)).IsCompleted)
					{
						num = (_003C_003E1__state = 8);
						_003C_003Eu__1 = awaiter18;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter18, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_0a37;
					IL_0f4a:
					((TaskAwaiter)(ref awaiter8)).GetResult();
					break;
					IL_04d1:
					if (!(text == "ShowEvasionBadgePlayer"))
					{
						break;
					}
					awaiter9 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimateStatusIcon((View)(object)_003C_003E4__this.EvasionBadgePlayer, _003C_003E4__this._viewModel.ShowEvasionBadgePlayer, isPlayer: true)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter9)).IsCompleted)
					{
						num = (_003C_003E1__state = 17);
						_003C_003Eu__1 = awaiter9;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter9, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_0eca;
					IL_03c0:
					if (!(text == "TriggerPlayerEntry"))
					{
						break;
					}
					awaiter23 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimateSpiritEntry(_003C_003E4__this.PlayerSprite, isPlayer: true)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter23)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = awaiter23;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter23, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_07bc;
					IL_063f:
					((TaskAwaiter)(ref awaiter26)).GetResult();
					break;
					IL_0eca:
					((TaskAwaiter)(ref awaiter9)).GetResult();
					break;
					IL_04bc:
					if (!(text == "ShowCriticalEnemy"))
					{
						break;
					}
					awaiter10 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimateCriticalLabel((View)(object)_003C_003E4__this.CriticalLabelEnemy, _003C_003E4__this._viewModel.ShowCriticalEnemy)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter10)).IsCompleted)
					{
						num = (_003C_003E1__state = 16);
						_003C_003Eu__1 = awaiter10;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter10, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_0e4a;
					IL_0a37:
					((TaskAwaiter)(ref awaiter18)).GetResult();
					break;
					IL_0414:
					if (!(text == "TriggerCriticalHit"))
					{
						break;
					}
					awaiter19 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimateCriticalHit(_003C_003E4__this.BattleContent)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter19)).IsCompleted)
					{
						num = (_003C_003E1__state = 7);
						_003C_003Eu__1 = awaiter19;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter19, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_09b8;
					IL_0e4a:
					((TaskAwaiter)(ref awaiter10)).GetResult();
					break;
					IL_04a7:
					if (!(text == "ShowCriticalPlayer"))
					{
						break;
					}
					awaiter11 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimateCriticalLabel((View)(object)_003C_003E4__this.CriticalLabelPlayer, _003C_003E4__this._viewModel.ShowCriticalPlayer)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter11)).IsCompleted)
					{
						num = (_003C_003E1__state = 15);
						_003C_003Eu__1 = awaiter11;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter11, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_0dca;
					IL_06be:
					((TaskAwaiter)(ref awaiter25)).GetResult();
					break;
					IL_07bc:
					((TaskAwaiter)(ref awaiter23)).GetResult();
					break;
					IL_0dca:
					((TaskAwaiter)(ref awaiter11)).GetResult();
					break;
					IL_0492:
					if (!(text == "ShowDamageEnemy"))
					{
						break;
					}
					awaiter12 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimateDamageIndicator(_003C_003E4__this.DamageIndicatorEnemy, _003C_003E4__this._viewModel.ShowDamageEnemy, _003C_003E4__this._viewModel.Effectiveness)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter12)).IsCompleted)
					{
						num = (_003C_003E1__state = 14);
						_003C_003Eu__1 = awaiter12;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter12, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_0d4a;
					IL_09b8:
					((TaskAwaiter)(ref awaiter19)).GetResult();
					break;
					IL_03ff:
					if (!(text == "TriggerSpiritSwitchEnemy"))
					{
						break;
					}
					awaiter20 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimateSpiritSwitchOut(_003C_003E4__this.EnemySprite, isPlayer: false)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter20)).IsCompleted)
					{
						num = (_003C_003E1__state = 6);
						_003C_003Eu__1 = awaiter20;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter20, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_0939;
					IL_0d4a:
					((TaskAwaiter)(ref awaiter12)).GetResult();
					break;
					IL_047d:
					if (!(text == "ShowDamagePlayer"))
					{
						break;
					}
					awaiter13 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimateDamageIndicator(_003C_003E4__this.DamageIndicatorPlayer, _003C_003E4__this._viewModel.ShowDamagePlayer, _003C_003E4__this._viewModel.Effectiveness)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter13)).IsCompleted)
					{
						num = (_003C_003E1__state = 13);
						_003C_003Eu__1 = awaiter13;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter13, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_0cca;
					IL_03ab:
					if (!(text == "TriggerEnemyAttack"))
					{
						break;
					}
					awaiter24 = _003C_003E4__this.SafeAnimateOnMainThread([CompilerGenerated] () => _003C_003E4__this._animationService.AnimateEnemyAttack(_003C_003E4__this.EnemySprite, _003C_003E4__this.BattleContent, _003C_003E4__this._viewModel.Effectiveness)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter24)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = awaiter24;
						_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__7>(ref awaiter24, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_073d;
					end_IL_0008:
					break;
				}
				_003C_003Es__1 = null;
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

	[CompilerGenerated]
	private sealed class _003CSafeAnimateOnMainThread_003Ed__9 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public Func<global::System.Threading.Tasks.Task> animationAction;

		public BattleView _003C_003E4__this;

		private _003C_003Ec__DisplayClass9_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass9_1 _003C_003E8__2;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Expected O, but got Unknown
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00a2;
				}
				TaskAwaiter<bool> awaiter2;
				if (num != 1)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass9_0();
					_003C_003E8__1.animationAction = animationAction;
					if (MainThread.IsMainThread)
					{
						awaiter = _003C_003E8__1.animationAction.Invoke().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CSafeAnimateOnMainThread_003Ed__9 _003CSafeAnimateOnMainThread_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSafeAnimateOnMainThread_003Ed__9>(ref awaiter, ref _003CSafeAnimateOnMainThread_003Ed__);
							return;
						}
						goto IL_00a2;
					}
					_003C_003E8__2 = new _003C_003Ec__DisplayClass9_1();
					_003C_003E8__2.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
					_003C_003E8__2.tcs = new TaskCompletionSource<bool>();
					MainThread.BeginInvokeOnMainThread((Action)([AsyncStateMachine(typeof(_003C_003Ec__DisplayClass9_1._003C_003CSafeAnimateOnMainThread_003Eb__0_003Ed))] [DebuggerStepThrough] () =>
					{
						//IL_0007: Unknown result type (might be due to invalid IL or missing references)
						//IL_000c: Unknown result type (might be due to invalid IL or missing references)
						_003C_003Ec__DisplayClass9_1._003C_003CSafeAnimateOnMainThread_003Eb__0_003Ed _003C_003CSafeAnimateOnMainThread_003Eb__0_003Ed = new _003C_003Ec__DisplayClass9_1._003C_003CSafeAnimateOnMainThread_003Eb__0_003Ed
						{
							_003C_003Et__builder = AsyncVoidMethodBuilder.Create(),
							_003C_003E4__this = _003C_003E8__2,
							_003C_003E1__state = -1
						};
						((AsyncVoidMethodBuilder)(ref _003C_003CSafeAnimateOnMainThread_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass9_1._003C_003CSafeAnimateOnMainThread_003Eb__0_003Ed>(ref _003C_003CSafeAnimateOnMainThread_003Eb__0_003Ed);
					}));
					awaiter2 = _003C_003E8__2.tcs.Task.GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter2;
						_003CSafeAnimateOnMainThread_003Ed__9 _003CSafeAnimateOnMainThread_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CSafeAnimateOnMainThread_003Ed__9>(ref awaiter2, ref _003CSafeAnimateOnMainThread_003Ed__);
						return;
					}
				}
				else
				{
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
				}
				awaiter2.GetResult();
				_003C_003E8__2 = null;
				goto end_IL_0007;
				IL_00a2:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private BattleViewModelRefactored? _viewModel;

	private IBattleAnimationService _animationService;

	private bool _isViewReady = false;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Image VsCanvas;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Grid BattleContent;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Image BattleBackground;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private ProgressBar EnemyHealthBar;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Grid EnemyArea;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Image EnemySprite;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private HorizontalStackLayout DamageIndicatorEnemy;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private OutlinedLabel CriticalLabelEnemy;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border StatusBadgeEnemy;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border EvasionBadgeEnemy;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border PoisonBadgeEnemy;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border HealingBadgeEnemy;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border MoveIndicatorEnemy;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Grid PlayerArea;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Image PlayerSprite;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private HorizontalStackLayout DamageIndicatorPlayer;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private OutlinedLabel CriticalLabelPlayer;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border StatusBadgePlayer;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private ProgressBar PlayerHealthBar;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private OutlinedLabel TurnTrackerLabel;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border EvasionBadgePlayer;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border PoisonBadgePlayer;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border HealingBadgePlayer;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border MoveIndicatorPlayer;

	public BattleView(BattleViewModelRefactored viewModel, IBattleAnimationService animationService)
	{
		Console.WriteLine("BattleView: Constructor called with ViewModel instance");
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
		_viewModel = viewModel;
		_animationService = animationService;
		Console.WriteLine("BattleView: Constructor completed, ViewModel set");
	}

	protected override bool OnBackButtonPressed()
	{
		return true;
	}

	protected override void OnBindingContextChanged()
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((ContentPage)this).OnBindingContextChanged();
		if (((BindableObject)this).BindingContext is BattleViewModelRefactored viewModel)
		{
			Console.WriteLine("BattleView: BindingContext changed to BattleViewModelRefactored");
			if (_viewModel != null)
			{
				Console.WriteLine("BattleView: Unsubscribing from previous ViewModel");
				((ObservableObject)_viewModel).PropertyChanged -= new PropertyChangedEventHandler(OnViewModelPropertyChanged);
			}
			_viewModel = viewModel;
			Console.WriteLine("BattleView: Subscribing to new ViewModel");
		}
		else if (((BindableObject)this).BindingContext == null)
		{
			Console.WriteLine("BattleView: BindingContext set to null!");
			if (_viewModel != null)
			{
				((ObservableObject)_viewModel).PropertyChanged -= new PropertyChangedEventHandler(OnViewModelPropertyChanged);
				_viewModel = null;
			}
		}
		else
		{
			object bindingContext = ((BindableObject)this).BindingContext;
			Console.WriteLine("BattleView: BindingContext set to unexpected type: " + ((bindingContext != null) ? ((MemberInfo)bindingContext.GetType()).Name : null));
		}
	}

	protected override void OnAppearing()
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		((Page)this).OnAppearing();
		Console.WriteLine("BattleView: OnAppearing called");
		if (_viewModel == null)
		{
			Console.WriteLine("BattleView: ERROR - _viewModel is null in OnAppearing!");
		}
		else if (!_isViewReady)
		{
			_isViewReady = true;
			((ObservableObject)_viewModel).PropertyChanged += new PropertyChangedEventHandler(OnViewModelPropertyChanged);
			Console.WriteLine("BattleView: PropertyChanged event subscribed");
			_viewModel.NotifyViewReady();
			Console.WriteLine("BattleView: NotifyViewReady called");
		}
	}

	[AsyncStateMachine(typeof(_003COnViewModelPropertyChanged_003Ed__7))]
	[DebuggerStepThrough]
	private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COnViewModelPropertyChanged_003Ed__7 _003COnViewModelPropertyChanged_003Ed__ = new _003COnViewModelPropertyChanged_003Ed__7();
		_003COnViewModelPropertyChanged_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003COnViewModelPropertyChanged_003Ed__._003C_003E4__this = this;
		_003COnViewModelPropertyChanged_003Ed__.sender = sender;
		_003COnViewModelPropertyChanged_003Ed__.e = e;
		_003COnViewModelPropertyChanged_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003COnViewModelPropertyChanged_003Ed__._003C_003Et__builder)).Start<_003COnViewModelPropertyChanged_003Ed__7>(ref _003COnViewModelPropertyChanged_003Ed__);
	}

	[AsyncStateMachine(typeof(_003CAnimateTurnTrackerGlow_003Ed__8))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task AnimateTurnTrackerGlow()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CAnimateTurnTrackerGlow_003Ed__8 _003CAnimateTurnTrackerGlow_003Ed__ = new _003CAnimateTurnTrackerGlow_003Ed__8();
		_003CAnimateTurnTrackerGlow_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CAnimateTurnTrackerGlow_003Ed__._003C_003E4__this = this;
		_003CAnimateTurnTrackerGlow_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CAnimateTurnTrackerGlow_003Ed__._003C_003Et__builder)).Start<_003CAnimateTurnTrackerGlow_003Ed__8>(ref _003CAnimateTurnTrackerGlow_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CAnimateTurnTrackerGlow_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSafeAnimateOnMainThread_003Ed__9))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task SafeAnimateOnMainThread(Func<global::System.Threading.Tasks.Task> animationAction)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSafeAnimateOnMainThread_003Ed__9 _003CSafeAnimateOnMainThread_003Ed__ = new _003CSafeAnimateOnMainThread_003Ed__9();
		_003CSafeAnimateOnMainThread_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSafeAnimateOnMainThread_003Ed__._003C_003E4__this = this;
		_003CSafeAnimateOnMainThread_003Ed__.animationAction = animationAction;
		_003CSafeAnimateOnMainThread_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSafeAnimateOnMainThread_003Ed__._003C_003Et__builder)).Start<_003CSafeAnimateOnMainThread_003Ed__9>(ref _003CSafeAnimateOnMainThread_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSafeAnimateOnMainThread_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CHandleSpiritIndexChange_003Ed__10))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task HandleSpiritIndexChange(bool isPlayer)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CHandleSpiritIndexChange_003Ed__10 _003CHandleSpiritIndexChange_003Ed__ = new _003CHandleSpiritIndexChange_003Ed__10();
		_003CHandleSpiritIndexChange_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CHandleSpiritIndexChange_003Ed__._003C_003E4__this = this;
		_003CHandleSpiritIndexChange_003Ed__.isPlayer = isPlayer;
		_003CHandleSpiritIndexChange_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CHandleSpiritIndexChange_003Ed__._003C_003Et__builder)).Start<_003CHandleSpiritIndexChange_003Ed__10>(ref _003CHandleSpiritIndexChange_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CHandleSpiritIndexChange_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CHandleBattleStateChange_003Ed__11))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task HandleBattleStateChange()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CHandleBattleStateChange_003Ed__11 _003CHandleBattleStateChange_003Ed__ = new _003CHandleBattleStateChange_003Ed__11();
		_003CHandleBattleStateChange_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CHandleBattleStateChange_003Ed__._003C_003E4__this = this;
		_003CHandleBattleStateChange_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CHandleBattleStateChange_003Ed__._003C_003Et__builder)).Start<_003CHandleBattleStateChange_003Ed__11>(ref _003CHandleBattleStateChange_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CHandleBattleStateChange_003Ed__._003C_003Et__builder)).Task;
	}

	protected override void OnDisappearing()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		((Page)this).OnDisappearing();
		Console.WriteLine("BattleView: Enhanced OnDisappearing called");
		((ObservableObject)_viewModel).PropertyChanged -= new PropertyChangedEventHandler(OnViewModelPropertyChanged);
		Console.WriteLine("BattleView: PropertyChanged unsubscribed");
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	[MemberNotNull("VsCanvas")]
	[MemberNotNull("BattleContent")]
	[MemberNotNull("BattleBackground")]
	[MemberNotNull("EnemyHealthBar")]
	[MemberNotNull("EnemyArea")]
	[MemberNotNull("EnemySprite")]
	[MemberNotNull("DamageIndicatorEnemy")]
	[MemberNotNull("CriticalLabelEnemy")]
	[MemberNotNull("StatusBadgeEnemy")]
	[MemberNotNull("EvasionBadgeEnemy")]
	[MemberNotNull("PoisonBadgeEnemy")]
	[MemberNotNull("HealingBadgeEnemy")]
	[MemberNotNull("MoveIndicatorEnemy")]
	[MemberNotNull("PlayerArea")]
	[MemberNotNull("PlayerSprite")]
	[MemberNotNull("DamageIndicatorPlayer")]
	[MemberNotNull("CriticalLabelPlayer")]
	[MemberNotNull("StatusBadgePlayer")]
	[MemberNotNull("PlayerHealthBar")]
	[MemberNotNull("TurnTrackerLabel")]
	[MemberNotNull("EvasionBadgePlayer")]
	[MemberNotNull("PoisonBadgePlayer")]
	[MemberNotNull("HealingBadgePlayer")]
	[MemberNotNull("MoveIndicatorPlayer")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<BattleView>(this, typeof(BattleView));
		VsCanvas = NameScopeExtensions.FindByName<Image>((Element)(object)this, "VsCanvas");
		BattleContent = NameScopeExtensions.FindByName<Grid>((Element)(object)this, "BattleContent");
		BattleBackground = NameScopeExtensions.FindByName<Image>((Element)(object)this, "BattleBackground");
		EnemyHealthBar = NameScopeExtensions.FindByName<ProgressBar>((Element)(object)this, "EnemyHealthBar");
		EnemyArea = NameScopeExtensions.FindByName<Grid>((Element)(object)this, "EnemyArea");
		EnemySprite = NameScopeExtensions.FindByName<Image>((Element)(object)this, "EnemySprite");
		DamageIndicatorEnemy = NameScopeExtensions.FindByName<HorizontalStackLayout>((Element)(object)this, "DamageIndicatorEnemy");
		CriticalLabelEnemy = NameScopeExtensions.FindByName<OutlinedLabel>((Element)(object)this, "CriticalLabelEnemy");
		StatusBadgeEnemy = NameScopeExtensions.FindByName<Border>((Element)(object)this, "StatusBadgeEnemy");
		EvasionBadgeEnemy = NameScopeExtensions.FindByName<Border>((Element)(object)this, "EvasionBadgeEnemy");
		PoisonBadgeEnemy = NameScopeExtensions.FindByName<Border>((Element)(object)this, "PoisonBadgeEnemy");
		HealingBadgeEnemy = NameScopeExtensions.FindByName<Border>((Element)(object)this, "HealingBadgeEnemy");
		MoveIndicatorEnemy = NameScopeExtensions.FindByName<Border>((Element)(object)this, "MoveIndicatorEnemy");
		PlayerArea = NameScopeExtensions.FindByName<Grid>((Element)(object)this, "PlayerArea");
		PlayerSprite = NameScopeExtensions.FindByName<Image>((Element)(object)this, "PlayerSprite");
		DamageIndicatorPlayer = NameScopeExtensions.FindByName<HorizontalStackLayout>((Element)(object)this, "DamageIndicatorPlayer");
		CriticalLabelPlayer = NameScopeExtensions.FindByName<OutlinedLabel>((Element)(object)this, "CriticalLabelPlayer");
		StatusBadgePlayer = NameScopeExtensions.FindByName<Border>((Element)(object)this, "StatusBadgePlayer");
		PlayerHealthBar = NameScopeExtensions.FindByName<ProgressBar>((Element)(object)this, "PlayerHealthBar");
		TurnTrackerLabel = NameScopeExtensions.FindByName<OutlinedLabel>((Element)(object)this, "TurnTrackerLabel");
		EvasionBadgePlayer = NameScopeExtensions.FindByName<Border>((Element)(object)this, "EvasionBadgePlayer");
		PoisonBadgePlayer = NameScopeExtensions.FindByName<Border>((Element)(object)this, "PoisonBadgePlayer");
		HealingBadgePlayer = NameScopeExtensions.FindByName<Border>((Element)(object)this, "HealingBadgePlayer");
		MoveIndicatorPlayer = NameScopeExtensions.FindByName<Border>((Element)(object)this, "MoveIndicatorPlayer");
	}
}
