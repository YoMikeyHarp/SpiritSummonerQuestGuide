using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using epj.ProgressBar.Maui;

namespace SpiritSummoner.Presentation.ViewModels.Battles;

public class BattleAnimationService : IBattleAnimationService
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		private sealed class _003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass10_0 _003C_003E4__this;

			private TaskAwaiter<bool[]> _003C_003Eu__1;

			private void MoveNext()
			{
				//IL_010e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0113: Unknown result type (might be due to invalid IL or missing references)
				//IL_011a: Unknown result type (might be due to invalid IL or missing references)
				//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
				//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
				//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
				//IL_0204: Unknown result type (might be due to invalid IL or missing references)
				//IL_0209: Unknown result type (might be due to invalid IL or missing references)
				//IL_0211: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
				//IL_00db: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
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
							goto IL_0220;
						}
						((VisualElement)_003C_003E4__this.sprite).AnchorX = 0.5;
						((VisualElement)_003C_003E4__this.sprite).AnchorY = (_003C_003E4__this.isPlayer ? 1.0 : 0.0);
						_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>> buffer = default(_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 0) = ViewExtensions.ScaleYTo((VisualElement)(object)_003C_003E4__this.sprite, 0.6, 140u, Easing.CubicIn);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 1) = ViewExtensions.ScaleXTo((VisualElement)(object)_003C_003E4__this.sprite, 1.15, 140u, Easing.CubicIn);
						awaiter2 = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer, 2)).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed _003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed>(ref awaiter2, ref _003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed);
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
					_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>> buffer2 = default(_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>);
					_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer2, 0) = ViewExtensions.ScaleYTo((VisualElement)(object)_003C_003E4__this.sprite, 0.05, 180u, Easing.CubicIn);
					_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer2, 1) = ViewExtensions.ScaleXTo((VisualElement)(object)_003C_003E4__this.sprite, 0.05, 180u, Easing.CubicIn);
					_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer2, 2) = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.sprite, 0.0, 180u, Easing.CubicIn);
					awaiter = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer2, 3)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter;
						_003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed _003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed>(ref awaiter, ref _003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed);
						return;
					}
					goto IL_0220;
					IL_0220:
					awaiter.GetResult();
					((VisualElement)_003C_003E4__this.sprite).ScaleX = 1.0;
					((VisualElement)_003C_003E4__this.sprite).ScaleY = 1.0;
					((VisualElement)_003C_003E4__this.sprite).Scale = 1.0;
					((VisualElement)_003C_003E4__this.sprite).AnchorY = 0.5;
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

		public Image sprite;

		public bool isPlayer;

		[AsyncStateMachine(typeof(_003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed))]
		[DebuggerStepThrough]
		internal global::System.Threading.Tasks.Task _003CAnimateSpiritSwitchOut_003Eb__0()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed _003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed = new _003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed>(ref _003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed._003C_003Et__builder)).Task;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		private sealed class _003C_003CAnimateCriticalLabel_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass11_0 _003C_003E4__this;

			private TaskAwaiter<bool[]> _003C_003Eu__1;

			private TaskAwaiter<bool> _003C_003Eu__2;

			private void MoveNext()
			{
				//IL_012b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0130: Unknown result type (might be due to invalid IL or missing references)
				//IL_0138: Unknown result type (might be due to invalid IL or missing references)
				//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
				//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
				//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
				//IL_029c: Unknown result type (might be due to invalid IL or missing references)
				//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
				//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
				//IL_016f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0174: Unknown result type (might be due to invalid IL or missing references)
				//IL_0262: Unknown result type (might be due to invalid IL or missing references)
				//IL_0267: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
				//IL_0189: Unknown result type (might be due to invalid IL or missing references)
				//IL_018b: Unknown result type (might be due to invalid IL or missing references)
				//IL_027c: Unknown result type (might be due to invalid IL or missing references)
				//IL_027e: Unknown result type (might be due to invalid IL or missing references)
				//IL_010b: Unknown result type (might be due to invalid IL or missing references)
				//IL_010d: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<bool[]> awaiter3;
					TaskAwaiter<bool[]> awaiter;
					TaskAwaiter<bool> awaiter2;
					switch (num)
					{
					default:
					{
						if (_003C_003E4__this.show)
						{
							((VisualElement)_003C_003E4__this.label).Opacity = 0.0;
							((VisualElement)_003C_003E4__this.label).Scale = 0.5;
							((VisualElement)_003C_003E4__this.label).IsVisible = true;
							_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>> buffer = default(_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>);
							_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 0) = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.label, 1.0, 150u, Easing.CubicOut);
							_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 1) = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.label, 1.3, 200u, Easing.BounceOut);
							awaiter3 = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer, 2)).GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter3;
								_003C_003CAnimateCriticalLabel_003Eb__0_003Ed _003C_003CAnimateCriticalLabel_003Eb__0_003Ed = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003C_003CAnimateCriticalLabel_003Eb__0_003Ed>(ref awaiter3, ref _003C_003CAnimateCriticalLabel_003Eb__0_003Ed);
								return;
							}
							goto IL_0147;
						}
						_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>> buffer2 = default(_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer2, 0) = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.label, 0.0, 250u, Easing.CubicIn);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer2, 1) = ViewExtensions.TranslateTo((VisualElement)(object)_003C_003E4__this.label, ((VisualElement)_003C_003E4__this.label).TranslationX, ((VisualElement)_003C_003E4__this.label).TranslationY - 30.0, 250u, Easing.CubicOut);
						awaiter = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer2, 2)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = awaiter;
							_003C_003CAnimateCriticalLabel_003Eb__0_003Ed _003C_003CAnimateCriticalLabel_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003C_003CAnimateCriticalLabel_003Eb__0_003Ed>(ref awaiter, ref _003C_003CAnimateCriticalLabel_003Eb__0_003Ed);
							return;
						}
						break;
					}
					case 0:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool[]>);
						num = (_003C_003E1__state = -1);
						goto IL_0147;
					case 1:
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_01c5;
					case 2:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<bool[]>);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_0147:
						awaiter3.GetResult();
						awaiter2 = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.label, 1.0, 100u, Easing.CubicInOut).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter2;
							_003C_003CAnimateCriticalLabel_003Eb__0_003Ed _003C_003CAnimateCriticalLabel_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003C_003CAnimateCriticalLabel_003Eb__0_003Ed>(ref awaiter2, ref _003C_003CAnimateCriticalLabel_003Eb__0_003Ed);
							return;
						}
						goto IL_01c5;
						IL_01c5:
						awaiter2.GetResult();
						goto end_IL_0007;
					}
					awaiter.GetResult();
					View label = _003C_003E4__this.label;
					((VisualElement)label).TranslationY = ((VisualElement)label).TranslationY + 30.0;
					((VisualElement)_003C_003E4__this.label).Opacity = 0.0;
					((VisualElement)_003C_003E4__this.label).IsVisible = false;
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

		public bool show;

		public View label;

		[AsyncStateMachine(typeof(_003C_003CAnimateCriticalLabel_003Eb__0_003Ed))]
		[DebuggerStepThrough]
		internal global::System.Threading.Tasks.Task _003CAnimateCriticalLabel_003Eb__0()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003CAnimateCriticalLabel_003Eb__0_003Ed _003C_003CAnimateCriticalLabel_003Eb__0_003Ed = new _003C_003CAnimateCriticalLabel_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateCriticalLabel_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003CAnimateCriticalLabel_003Eb__0_003Ed>(ref _003C_003CAnimateCriticalLabel_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateCriticalLabel_003Eb__0_003Ed._003C_003Et__builder)).Task;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		private sealed class _003C_003CAnimateStatusIcon_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass12_0 _003C_003E4__this;

			private double _003CoffscreenX_003E5__1;

			private TaskAwaiter<bool[]> _003C_003Eu__1;

			private TaskAwaiter<bool> _003C_003Eu__2;

			private void MoveNext()
			{
				//IL_019e: Unknown result type (might be due to invalid IL or missing references)
				//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
				//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
				//IL_021f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0224: Unknown result type (might be due to invalid IL or missing references)
				//IL_022c: Unknown result type (might be due to invalid IL or missing references)
				//IL_032a: Unknown result type (might be due to invalid IL or missing references)
				//IL_032f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0337: Unknown result type (might be due to invalid IL or missing references)
				//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
				//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
				//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
				//IL_0201: Unknown result type (might be due to invalid IL or missing references)
				//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
				//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
				//IL_0164: Unknown result type (might be due to invalid IL or missing references)
				//IL_0169: Unknown result type (might be due to invalid IL or missing references)
				//IL_030a: Unknown result type (might be due to invalid IL or missing references)
				//IL_030c: Unknown result type (might be due to invalid IL or missing references)
				//IL_017e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0180: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<bool[]> awaiter3;
					TaskAwaiter<bool[]> awaiter;
					TaskAwaiter<bool> awaiter2;
					switch (num)
					{
					default:
					{
						_003CoffscreenX_003E5__1 = (_003C_003E4__this.isPlayer ? (-250) : 250);
						if (_003C_003E4__this.show)
						{
							((VisualElement)_003C_003E4__this.badge).TranslationX = _003CoffscreenX_003E5__1;
							((VisualElement)_003C_003E4__this.badge).Opacity = 0.0;
							((VisualElement)_003C_003E4__this.badge).Scale = 0.85;
							((VisualElement)_003C_003E4__this.badge).IsVisible = true;
							_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>> buffer = default(_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>);
							_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 0) = ViewExtensions.TranslateTo((VisualElement)(object)_003C_003E4__this.badge, 0.0, ((VisualElement)_003C_003E4__this.badge).TranslationY, 350u, Easing.CubicOut);
							_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 1) = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.badge, 1.0, 220u, Easing.CubicOut);
							_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 2) = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.badge, 2.0, 350u, Easing.CubicOut);
							awaiter3 = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer, 3)).GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter3;
								_003C_003CAnimateStatusIcon_003Eb__0_003Ed _003C_003CAnimateStatusIcon_003Eb__0_003Ed = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003C_003CAnimateStatusIcon_003Eb__0_003Ed>(ref awaiter3, ref _003C_003CAnimateStatusIcon_003Eb__0_003Ed);
								return;
							}
							goto IL_01ba;
						}
						_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>> buffer2 = default(_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer2, 0) = ViewExtensions.TranslateTo((VisualElement)(object)_003C_003E4__this.badge, _003CoffscreenX_003E5__1, ((VisualElement)_003C_003E4__this.badge).TranslationY, 280u, Easing.CubicIn);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer2, 1) = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.badge, 0.0, 240u, Easing.CubicIn);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer2, 2) = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.badge, 0.85, 280u, Easing.CubicIn);
						awaiter = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer2, 3)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = awaiter;
							_003C_003CAnimateStatusIcon_003Eb__0_003Ed _003C_003CAnimateStatusIcon_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003C_003CAnimateStatusIcon_003Eb__0_003Ed>(ref awaiter, ref _003C_003CAnimateStatusIcon_003Eb__0_003Ed);
							return;
						}
						break;
					}
					case 0:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool[]>);
						num = (_003C_003E1__state = -1);
						goto IL_01ba;
					case 1:
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_023b;
					case 2:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<bool[]>);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_01ba:
						awaiter3.GetResult();
						awaiter2 = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.badge, 1.0, 130u, Easing.CubicInOut).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter2;
							_003C_003CAnimateStatusIcon_003Eb__0_003Ed _003C_003CAnimateStatusIcon_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003C_003CAnimateStatusIcon_003Eb__0_003Ed>(ref awaiter2, ref _003C_003CAnimateStatusIcon_003Eb__0_003Ed);
							return;
						}
						goto IL_023b;
						IL_023b:
						awaiter2.GetResult();
						goto end_IL_0007;
					}
					awaiter.GetResult();
					((VisualElement)_003C_003E4__this.badge).IsVisible = false;
					((VisualElement)_003C_003E4__this.badge).TranslationX = 0.0;
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

		public bool isPlayer;

		public bool show;

		public View badge;

		[AsyncStateMachine(typeof(_003C_003CAnimateStatusIcon_003Eb__0_003Ed))]
		[DebuggerStepThrough]
		internal global::System.Threading.Tasks.Task _003CAnimateStatusIcon_003Eb__0()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003CAnimateStatusIcon_003Eb__0_003Ed _003C_003CAnimateStatusIcon_003Eb__0_003Ed = new _003C_003CAnimateStatusIcon_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateStatusIcon_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003CAnimateStatusIcon_003Eb__0_003Ed>(ref _003C_003CAnimateStatusIcon_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateStatusIcon_003Eb__0_003Ed._003C_003Et__builder)).Task;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		private sealed class _003C_003CAnimateStatusBadge_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass13_0 _003C_003E4__this;

			private TaskAwaiter<bool[]> _003C_003Eu__1;

			private TaskAwaiter<bool> _003C_003Eu__2;

			private void MoveNext()
			{
				//IL_012b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0130: Unknown result type (might be due to invalid IL or missing references)
				//IL_0138: Unknown result type (might be due to invalid IL or missing references)
				//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
				//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
				//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
				//IL_0278: Unknown result type (might be due to invalid IL or missing references)
				//IL_027d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0285: Unknown result type (might be due to invalid IL or missing references)
				//IL_016f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0174: Unknown result type (might be due to invalid IL or missing references)
				//IL_0241: Unknown result type (might be due to invalid IL or missing references)
				//IL_0246: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
				//IL_0189: Unknown result type (might be due to invalid IL or missing references)
				//IL_018b: Unknown result type (might be due to invalid IL or missing references)
				//IL_025b: Unknown result type (might be due to invalid IL or missing references)
				//IL_025d: Unknown result type (might be due to invalid IL or missing references)
				//IL_010b: Unknown result type (might be due to invalid IL or missing references)
				//IL_010d: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<bool[]> awaiter3;
					TaskAwaiter<bool[]> awaiter;
					TaskAwaiter<bool> awaiter2;
					switch (num)
					{
					default:
					{
						if (_003C_003E4__this.show)
						{
							((VisualElement)_003C_003E4__this.badge).Opacity = 0.0;
							((VisualElement)_003C_003E4__this.badge).Scale = 0.6;
							((VisualElement)_003C_003E4__this.badge).IsVisible = true;
							_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>> buffer = default(_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>);
							_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 0) = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.badge, 1.0, 200u, Easing.CubicOut);
							_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 1) = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.badge, 1.1, 250u, Easing.BounceOut);
							awaiter3 = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer, 2)).GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter3;
								_003C_003CAnimateStatusBadge_003Eb__0_003Ed _003C_003CAnimateStatusBadge_003Eb__0_003Ed = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003C_003CAnimateStatusBadge_003Eb__0_003Ed>(ref awaiter3, ref _003C_003CAnimateStatusBadge_003Eb__0_003Ed);
								return;
							}
							goto IL_0147;
						}
						_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>> buffer2 = default(_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer2, 0) = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.badge, 0.0, 300u, Easing.CubicIn);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer2, 1) = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.badge, 0.7, 300u, Easing.CubicIn);
						awaiter = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer2, 2)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = awaiter;
							_003C_003CAnimateStatusBadge_003Eb__0_003Ed _003C_003CAnimateStatusBadge_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003C_003CAnimateStatusBadge_003Eb__0_003Ed>(ref awaiter, ref _003C_003CAnimateStatusBadge_003Eb__0_003Ed);
							return;
						}
						break;
					}
					case 0:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool[]>);
						num = (_003C_003E1__state = -1);
						goto IL_0147;
					case 1:
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_01c5;
					case 2:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<bool[]>);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_0147:
						awaiter3.GetResult();
						awaiter2 = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.badge, 1.0, 80u, Easing.CubicInOut).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter2;
							_003C_003CAnimateStatusBadge_003Eb__0_003Ed _003C_003CAnimateStatusBadge_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003C_003CAnimateStatusBadge_003Eb__0_003Ed>(ref awaiter2, ref _003C_003CAnimateStatusBadge_003Eb__0_003Ed);
							return;
						}
						goto IL_01c5;
						IL_01c5:
						awaiter2.GetResult();
						goto end_IL_0007;
					}
					awaiter.GetResult();
					((VisualElement)_003C_003E4__this.badge).IsVisible = false;
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

		public bool show;

		public View badge;

		[AsyncStateMachine(typeof(_003C_003CAnimateStatusBadge_003Eb__0_003Ed))]
		[DebuggerStepThrough]
		internal global::System.Threading.Tasks.Task _003CAnimateStatusBadge_003Eb__0()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003CAnimateStatusBadge_003Eb__0_003Ed _003C_003CAnimateStatusBadge_003Eb__0_003Ed = new _003C_003CAnimateStatusBadge_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateStatusBadge_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003CAnimateStatusBadge_003Eb__0_003Ed>(ref _003C_003CAnimateStatusBadge_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateStatusBadge_003Eb__0_003Ed._003C_003Et__builder)).Task;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		private sealed class _003C_003CAnimateVictoryPose_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass14_0 _003C_003E4__this;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

			private TaskAwaiter<bool[]> _003C_003Eu__3;

			private void MoveNext()
			{
				//IL_008b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0090: Unknown result type (might be due to invalid IL or missing references)
				//IL_0097: Unknown result type (might be due to invalid IL or missing references)
				//IL_0113: Unknown result type (might be due to invalid IL or missing references)
				//IL_0118: Unknown result type (might be due to invalid IL or missing references)
				//IL_0120: Unknown result type (might be due to invalid IL or missing references)
				//IL_017a: Unknown result type (might be due to invalid IL or missing references)
				//IL_017f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0187: Unknown result type (might be due to invalid IL or missing references)
				//IL_024a: Unknown result type (might be due to invalid IL or missing references)
				//IL_024f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0257: Unknown result type (might be due to invalid IL or missing references)
				//IL_0054: Unknown result type (might be due to invalid IL or missing references)
				//IL_0059: Unknown result type (might be due to invalid IL or missing references)
				//IL_00da: Unknown result type (might be due to invalid IL or missing references)
				//IL_00df: Unknown result type (might be due to invalid IL or missing references)
				//IL_0141: Unknown result type (might be due to invalid IL or missing references)
				//IL_0146: Unknown result type (might be due to invalid IL or missing references)
				//IL_0214: Unknown result type (might be due to invalid IL or missing references)
				//IL_0219: Unknown result type (might be due to invalid IL or missing references)
				//IL_006d: Unknown result type (might be due to invalid IL or missing references)
				//IL_006e: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
				//IL_015b: Unknown result type (might be due to invalid IL or missing references)
				//IL_015d: Unknown result type (might be due to invalid IL or missing references)
				//IL_022e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0230: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<bool> awaiter4;
					TaskAwaiter<bool> awaiter3;
					TaskAwaiter awaiter2;
					TaskAwaiter<bool[]> awaiter;
					_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>> buffer;
					switch (num)
					{
					default:
						awaiter4 = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.sprite, 1.2, 200u, Easing.CubicOut).GetAwaiter();
						if (!awaiter4.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter4;
							_003C_003CAnimateVictoryPose_003Eb__0_003Ed _003C_003CAnimateVictoryPose_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003C_003CAnimateVictoryPose_003Eb__0_003Ed>(ref awaiter4, ref _003C_003CAnimateVictoryPose_003Eb__0_003Ed);
							return;
						}
						goto IL_00a6;
					case 0:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_00a6;
					case 1:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_012f;
					case 2:
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0196;
					case 3:
						{
							awaiter = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<bool[]>);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_012f:
						awaiter3.GetResult();
						awaiter2 = global::System.Threading.Tasks.Task.Delay(300).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter2;
							_003C_003CAnimateVictoryPose_003Eb__0_003Ed _003C_003CAnimateVictoryPose_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003CAnimateVictoryPose_003Eb__0_003Ed>(ref awaiter2, ref _003C_003CAnimateVictoryPose_003Eb__0_003Ed);
							return;
						}
						goto IL_0196;
						IL_00a6:
						awaiter4.GetResult();
						awaiter3 = ViewExtensions.TranslateTo((VisualElement)(object)_003C_003E4__this.sprite, 0.0, -20.0, 200u, Easing.CubicOut).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter3;
							_003C_003CAnimateVictoryPose_003Eb__0_003Ed _003C_003CAnimateVictoryPose_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003C_003CAnimateVictoryPose_003Eb__0_003Ed>(ref awaiter3, ref _003C_003CAnimateVictoryPose_003Eb__0_003Ed);
							return;
						}
						goto IL_012f;
						IL_0196:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						buffer = default(_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 0) = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.sprite, 1.05, 400u, Easing.BounceOut);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 1) = ViewExtensions.TranslateTo((VisualElement)(object)_003C_003E4__this.sprite, 0.0, 0.0, 400u, Easing.BounceOut);
						awaiter = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer, 2)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__3 = awaiter;
							_003C_003CAnimateVictoryPose_003Eb__0_003Ed _003C_003CAnimateVictoryPose_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003C_003CAnimateVictoryPose_003Eb__0_003Ed>(ref awaiter, ref _003C_003CAnimateVictoryPose_003Eb__0_003Ed);
							return;
						}
						break;
					}
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

		public Image sprite;

		[AsyncStateMachine(typeof(_003C_003CAnimateVictoryPose_003Eb__0_003Ed))]
		[DebuggerStepThrough]
		internal global::System.Threading.Tasks.Task _003CAnimateVictoryPose_003Eb__0()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003CAnimateVictoryPose_003Eb__0_003Ed _003C_003CAnimateVictoryPose_003Eb__0_003Ed = new _003C_003CAnimateVictoryPose_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateVictoryPose_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003CAnimateVictoryPose_003Eb__0_003Ed>(ref _003C_003CAnimateVictoryPose_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateVictoryPose_003Eb__0_003Ed._003C_003Et__builder)).Task;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		private sealed class _003C_003CAnimateDefeatPose_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass15_0 _003C_003E4__this;

			private TaskAwaiter<bool[]> _003C_003Eu__1;

			private void MoveNext()
			{
				//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<bool[]> awaiter;
					if (num != 0)
					{
						_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>> buffer = default(_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 0) = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.sprite, 0.0, 500u, Easing.CubicIn);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 1) = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.sprite, 0.5, 500u, Easing.CubicIn);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 2) = ViewExtensions.TranslateTo((VisualElement)(object)_003C_003E4__this.sprite, 0.0, 30.0, 500u, Easing.CubicIn);
						awaiter = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer, 3)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003C_003CAnimateDefeatPose_003Eb__0_003Ed _003C_003CAnimateDefeatPose_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003C_003CAnimateDefeatPose_003Eb__0_003Ed>(ref awaiter, ref _003C_003CAnimateDefeatPose_003Eb__0_003Ed);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool[]>);
						num = (_003C_003E1__state = -1);
					}
					awaiter.GetResult();
					((VisualElement)_003C_003E4__this.sprite).Scale = 1.0;
					((VisualElement)_003C_003E4__this.sprite).TranslationY = 0.0;
					((VisualElement)_003C_003E4__this.sprite).Opacity = 0.0;
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

		public Image sprite;

		[AsyncStateMachine(typeof(_003C_003CAnimateDefeatPose_003Eb__0_003Ed))]
		[DebuggerStepThrough]
		internal global::System.Threading.Tasks.Task _003CAnimateDefeatPose_003Eb__0()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003CAnimateDefeatPose_003Eb__0_003Ed _003C_003CAnimateDefeatPose_003Eb__0_003Ed = new _003C_003CAnimateDefeatPose_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateDefeatPose_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003CAnimateDefeatPose_003Eb__0_003Ed>(ref _003C_003CAnimateDefeatPose_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateDefeatPose_003Eb__0_003Ed._003C_003Et__builder)).Task;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		private sealed class _003C_003CAnimateMoveIndicator_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass16_0 _003C_003E4__this;

			private TaskAwaiter<bool[]> _003C_003Eu__1;

			private TaskAwaiter<bool> _003C_003Eu__2;

			private void MoveNext()
			{
				//IL_012b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0130: Unknown result type (might be due to invalid IL or missing references)
				//IL_0138: Unknown result type (might be due to invalid IL or missing references)
				//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
				//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
				//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
				//IL_0272: Unknown result type (might be due to invalid IL or missing references)
				//IL_0277: Unknown result type (might be due to invalid IL or missing references)
				//IL_027f: Unknown result type (might be due to invalid IL or missing references)
				//IL_016f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0174: Unknown result type (might be due to invalid IL or missing references)
				//IL_023b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0240: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
				//IL_0189: Unknown result type (might be due to invalid IL or missing references)
				//IL_018b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0255: Unknown result type (might be due to invalid IL or missing references)
				//IL_0257: Unknown result type (might be due to invalid IL or missing references)
				//IL_010b: Unknown result type (might be due to invalid IL or missing references)
				//IL_010d: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<bool[]> awaiter3;
					TaskAwaiter<bool[]> awaiter;
					TaskAwaiter<bool> awaiter2;
					switch (num)
					{
					default:
					{
						if (_003C_003E4__this.show)
						{
							((VisualElement)_003C_003E4__this.indicator).Opacity = 0.0;
							((VisualElement)_003C_003E4__this.indicator).Scale = 0.6;
							((VisualElement)_003C_003E4__this.indicator).IsVisible = true;
							_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>> buffer = default(_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>);
							_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 0) = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.indicator, 1.0, 250u, Easing.CubicOut);
							_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 1) = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.indicator, 1.1, 200u, Easing.BounceOut);
							awaiter3 = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer, 2)).GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter3;
								_003C_003CAnimateMoveIndicator_003Eb__0_003Ed _003C_003CAnimateMoveIndicator_003Eb__0_003Ed = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003C_003CAnimateMoveIndicator_003Eb__0_003Ed>(ref awaiter3, ref _003C_003CAnimateMoveIndicator_003Eb__0_003Ed);
								return;
							}
							goto IL_0147;
						}
						_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>> buffer2 = default(_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer2, 0) = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.indicator, 0.0, 100u, Easing.CubicIn);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer2, 1) = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.indicator, 0.8, 100u, Easing.CubicIn);
						awaiter = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer2, 2)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = awaiter;
							_003C_003CAnimateMoveIndicator_003Eb__0_003Ed _003C_003CAnimateMoveIndicator_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003C_003CAnimateMoveIndicator_003Eb__0_003Ed>(ref awaiter, ref _003C_003CAnimateMoveIndicator_003Eb__0_003Ed);
							return;
						}
						break;
					}
					case 0:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool[]>);
						num = (_003C_003E1__state = -1);
						goto IL_0147;
					case 1:
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_01c5;
					case 2:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<bool[]>);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_0147:
						awaiter3.GetResult();
						awaiter2 = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.indicator, 1.0, 75u, Easing.CubicInOut).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter2;
							_003C_003CAnimateMoveIndicator_003Eb__0_003Ed _003C_003CAnimateMoveIndicator_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003C_003CAnimateMoveIndicator_003Eb__0_003Ed>(ref awaiter2, ref _003C_003CAnimateMoveIndicator_003Eb__0_003Ed);
							return;
						}
						goto IL_01c5;
						IL_01c5:
						awaiter2.GetResult();
						goto end_IL_0007;
					}
					awaiter.GetResult();
					((VisualElement)_003C_003E4__this.indicator).IsVisible = false;
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

		public bool show;

		public View indicator;

		[AsyncStateMachine(typeof(_003C_003CAnimateMoveIndicator_003Eb__0_003Ed))]
		[DebuggerStepThrough]
		internal global::System.Threading.Tasks.Task _003CAnimateMoveIndicator_003Eb__0()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003CAnimateMoveIndicator_003Eb__0_003Ed _003C_003CAnimateMoveIndicator_003Eb__0_003Ed = new _003C_003CAnimateMoveIndicator_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateMoveIndicator_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003CAnimateMoveIndicator_003Eb__0_003Ed>(ref _003C_003CAnimateMoveIndicator_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateMoveIndicator_003Eb__0_003Ed._003C_003Et__builder)).Task;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		private sealed class _003C_003CAnimateDamageIndicator_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass17_0 _003C_003E4__this;

			private double _003CtargetScale_003E5__1;

			private TaskAwaiter<bool[]> _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

			private TaskAwaiter<bool> _003C_003Eu__3;

			private void MoveNext()
			{
				//IL_019c: Unknown result type (might be due to invalid IL or missing references)
				//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
				//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
				//IL_0204: Unknown result type (might be due to invalid IL or missing references)
				//IL_0209: Unknown result type (might be due to invalid IL or missing references)
				//IL_0211: Unknown result type (might be due to invalid IL or missing references)
				//IL_0282: Unknown result type (might be due to invalid IL or missing references)
				//IL_0287: Unknown result type (might be due to invalid IL or missing references)
				//IL_028f: Unknown result type (might be due to invalid IL or missing references)
				//IL_03a1: Unknown result type (might be due to invalid IL or missing references)
				//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
				//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
				//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
				//IL_0248: Unknown result type (might be due to invalid IL or missing references)
				//IL_024d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0367: Unknown result type (might be due to invalid IL or missing references)
				//IL_036c: Unknown result type (might be due to invalid IL or missing references)
				//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
				//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
				//IL_0262: Unknown result type (might be due to invalid IL or missing references)
				//IL_0264: Unknown result type (might be due to invalid IL or missing references)
				//IL_0381: Unknown result type (might be due to invalid IL or missing references)
				//IL_0383: Unknown result type (might be due to invalid IL or missing references)
				//IL_0162: Unknown result type (might be due to invalid IL or missing references)
				//IL_0167: Unknown result type (might be due to invalid IL or missing references)
				//IL_017c: Unknown result type (might be due to invalid IL or missing references)
				//IL_017e: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<bool[]> awaiter4;
					TaskAwaiter<bool[]> awaiter;
					TaskAwaiter awaiter3;
					TaskAwaiter<bool> awaiter2;
					switch (num)
					{
					default:
					{
						if (_003C_003E4__this.show)
						{
							((VisualElement)_003C_003E4__this.indicator).Opacity = 0.0;
							((VisualElement)_003C_003E4__this.indicator).Scale = 0.3;
							((VisualElement)_003C_003E4__this.indicator).TranslationY = 0.0;
							((VisualElement)_003C_003E4__this.indicator).IsVisible = true;
							_003CtargetScale_003E5__1 = ((_003C_003E4__this.effectiveness >= 2.0) ? 1.4 : ((_003C_003E4__this.effectiveness <= 0.5) ? 0.9 : 1.2));
							_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>> buffer = default(_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>);
							_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 0) = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.indicator, 1.0, 200u, Easing.CubicOut);
							_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 1) = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.indicator, _003CtargetScale_003E5__1, 225u, Easing.BounceOut);
							awaiter4 = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer, 2)).GetAwaiter();
							if (!awaiter4.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter4;
								_003C_003CAnimateDamageIndicator_003Eb__0_003Ed _003C_003CAnimateDamageIndicator_003Eb__0_003Ed = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003C_003CAnimateDamageIndicator_003Eb__0_003Ed>(ref awaiter4, ref _003C_003CAnimateDamageIndicator_003Eb__0_003Ed);
								return;
							}
							goto IL_01b8;
						}
						_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>> buffer2 = default(_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer2, 0) = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.indicator, 0.0, 350u, Easing.CubicIn);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer2, 1) = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.indicator, 0.6, 350u, Easing.CubicIn);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer2, 2) = ViewExtensions.TranslateTo((VisualElement)(object)_003C_003E4__this.indicator, ((VisualElement)_003C_003E4__this.indicator).TranslationX, ((VisualElement)_003C_003E4__this.indicator).TranslationY - 50.0, 300u, Easing.CubicOut);
						awaiter = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer2, 3)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__1 = awaiter;
							_003C_003CAnimateDamageIndicator_003Eb__0_003Ed _003C_003CAnimateDamageIndicator_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003C_003CAnimateDamageIndicator_003Eb__0_003Ed>(ref awaiter, ref _003C_003CAnimateDamageIndicator_003Eb__0_003Ed);
							return;
						}
						break;
					}
					case 0:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool[]>);
						num = (_003C_003E1__state = -1);
						goto IL_01b8;
					case 1:
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0220;
					case 2:
						awaiter2 = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_029e;
					case 3:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<bool[]>);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_0220:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						awaiter2 = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.indicator, 1.0, 100u, Easing.CubicInOut).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__3 = awaiter2;
							_003C_003CAnimateDamageIndicator_003Eb__0_003Ed _003C_003CAnimateDamageIndicator_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003C_003CAnimateDamageIndicator_003Eb__0_003Ed>(ref awaiter2, ref _003C_003CAnimateDamageIndicator_003Eb__0_003Ed);
							return;
						}
						goto IL_029e;
						IL_029e:
						awaiter2.GetResult();
						goto end_IL_0007;
						IL_01b8:
						awaiter4.GetResult();
						awaiter3 = global::System.Threading.Tasks.Task.Delay(200).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter3;
							_003C_003CAnimateDamageIndicator_003Eb__0_003Ed _003C_003CAnimateDamageIndicator_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003CAnimateDamageIndicator_003Eb__0_003Ed>(ref awaiter3, ref _003C_003CAnimateDamageIndicator_003Eb__0_003Ed);
							return;
						}
						goto IL_0220;
					}
					awaiter.GetResult();
					((VisualElement)_003C_003E4__this.indicator).TranslationY = 0.0;
					((VisualElement)_003C_003E4__this.indicator).IsVisible = false;
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

		public bool show;

		public HorizontalStackLayout indicator;

		public double effectiveness;

		[AsyncStateMachine(typeof(_003C_003CAnimateDamageIndicator_003Eb__0_003Ed))]
		[DebuggerStepThrough]
		internal global::System.Threading.Tasks.Task _003CAnimateDamageIndicator_003Eb__0()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003CAnimateDamageIndicator_003Eb__0_003Ed _003C_003CAnimateDamageIndicator_003Eb__0_003Ed = new _003C_003CAnimateDamageIndicator_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateDamageIndicator_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003CAnimateDamageIndicator_003Eb__0_003Ed>(ref _003C_003CAnimateDamageIndicator_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateDamageIndicator_003Eb__0_003Ed._003C_003Et__builder)).Task;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		private sealed class _003C_003CAnimateVsScreenFade_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass1_0 _003C_003E4__this;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

			private TaskAwaiter<bool[]> _003C_003Eu__3;

			private void MoveNext()
			{
				//IL_0082: Unknown result type (might be due to invalid IL or missing references)
				//IL_0087: Unknown result type (might be due to invalid IL or missing references)
				//IL_008e: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
				//IL_01af: Unknown result type (might be due to invalid IL or missing references)
				//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
				//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
				//IL_004b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0050: Unknown result type (might be due to invalid IL or missing references)
				//IL_00af: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
				//IL_0179: Unknown result type (might be due to invalid IL or missing references)
				//IL_017e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0064: Unknown result type (might be due to invalid IL or missing references)
				//IL_0065: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
				//IL_0193: Unknown result type (might be due to invalid IL or missing references)
				//IL_0195: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<bool> awaiter3;
					TaskAwaiter awaiter2;
					TaskAwaiter<bool[]> awaiter;
					_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>> buffer;
					switch (num)
					{
					default:
						awaiter3 = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.vsCanvas, 0.85, 300u, Easing.CubicInOut).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003C_003CAnimateVsScreenFade_003Eb__0_003Ed _003C_003CAnimateVsScreenFade_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003C_003CAnimateVsScreenFade_003Eb__0_003Ed>(ref awaiter3, ref _003C_003CAnimateVsScreenFade_003Eb__0_003Ed);
							return;
						}
						goto IL_009d;
					case 0:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_009d;
					case 1:
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0104;
					case 2:
						{
							awaiter = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<bool[]>);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_0104:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						buffer = default(_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 0) = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.vsCanvas, 0.0, 300u, Easing.CubicInOut);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 1) = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.vsCanvas, 0.7, 300u, Easing.CubicInOut);
						awaiter = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer, 2)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__3 = awaiter;
							_003C_003CAnimateVsScreenFade_003Eb__0_003Ed _003C_003CAnimateVsScreenFade_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003C_003CAnimateVsScreenFade_003Eb__0_003Ed>(ref awaiter, ref _003C_003CAnimateVsScreenFade_003Eb__0_003Ed);
							return;
						}
						break;
						IL_009d:
						awaiter3.GetResult();
						awaiter2 = global::System.Threading.Tasks.Task.Delay(200).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter2;
							_003C_003CAnimateVsScreenFade_003Eb__0_003Ed _003C_003CAnimateVsScreenFade_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003CAnimateVsScreenFade_003Eb__0_003Ed>(ref awaiter2, ref _003C_003CAnimateVsScreenFade_003Eb__0_003Ed);
							return;
						}
						goto IL_0104;
					}
					awaiter.GetResult();
					((VisualElement)_003C_003E4__this.vsCanvas).Scale = 1.0;
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

		public Image vsCanvas;

		[AsyncStateMachine(typeof(_003C_003CAnimateVsScreenFade_003Eb__0_003Ed))]
		[DebuggerStepThrough]
		internal global::System.Threading.Tasks.Task _003CAnimateVsScreenFade_003Eb__0()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003CAnimateVsScreenFade_003Eb__0_003Ed _003C_003CAnimateVsScreenFade_003Eb__0_003Ed = new _003C_003CAnimateVsScreenFade_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateVsScreenFade_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003CAnimateVsScreenFade_003Eb__0_003Ed>(ref _003C_003CAnimateVsScreenFade_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateVsScreenFade_003Eb__0_003Ed._003C_003Et__builder)).Task;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		private sealed class _003C_003CAnimateAttackCore_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass4_0 _003C_003E4__this;

			private double _003CoriginalX_003E5__1;

			private double _003CoriginalY_003E5__2;

			private double _003CoriginalScale_003E5__3;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

			private TaskAwaiter<bool[]> _003C_003Eu__3;

			private void MoveNext()
			{
				//IL_00df: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
				//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
				//IL_0145: Unknown result type (might be due to invalid IL or missing references)
				//IL_014a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0152: Unknown result type (might be due to invalid IL or missing references)
				//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
				//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
				//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
				//IL_024f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0254: Unknown result type (might be due to invalid IL or missing references)
				//IL_025c: Unknown result type (might be due to invalid IL or missing references)
				//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
				//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
				//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
				//IL_03af: Unknown result type (might be due to invalid IL or missing references)
				//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
				//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
				//IL_010c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0111: Unknown result type (might be due to invalid IL or missing references)
				//IL_0189: Unknown result type (might be due to invalid IL or missing references)
				//IL_018e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0216: Unknown result type (might be due to invalid IL or missing references)
				//IL_021b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0283: Unknown result type (might be due to invalid IL or missing references)
				//IL_0288: Unknown result type (might be due to invalid IL or missing references)
				//IL_0379: Unknown result type (might be due to invalid IL or missing references)
				//IL_037e: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
				//IL_0126: Unknown result type (might be due to invalid IL or missing references)
				//IL_0128: Unknown result type (might be due to invalid IL or missing references)
				//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
				//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
				//IL_0230: Unknown result type (might be due to invalid IL or missing references)
				//IL_0232: Unknown result type (might be due to invalid IL or missing references)
				//IL_029d: Unknown result type (might be due to invalid IL or missing references)
				//IL_029f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0393: Unknown result type (might be due to invalid IL or missing references)
				//IL_0395: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<bool> awaiter6;
					TaskAwaiter awaiter5;
					TaskAwaiter<bool> awaiter4;
					TaskAwaiter<bool> awaiter3;
					TaskAwaiter awaiter2;
					TaskAwaiter<bool[]> awaiter;
					_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>> buffer;
					switch (num)
					{
					default:
						_003CoriginalX_003E5__1 = ((VisualElement)_003C_003E4__this.sprite).TranslationX;
						_003CoriginalY_003E5__2 = ((VisualElement)_003C_003E4__this.sprite).TranslationY;
						_003CoriginalScale_003E5__3 = ((VisualElement)_003C_003E4__this.sprite).Scale;
						awaiter6 = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.sprite, 0.9, 120u, Easing.CubicIn).GetAwaiter();
						if (!awaiter6.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter6;
							_003C_003CAnimateAttackCore_003Eb__0_003Ed _003C_003CAnimateAttackCore_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003C_003CAnimateAttackCore_003Eb__0_003Ed>(ref awaiter6, ref _003C_003CAnimateAttackCore_003Eb__0_003Ed);
							return;
						}
						goto IL_00fa;
					case 0:
						awaiter6 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_00fa;
					case 1:
						awaiter5 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0161;
					case 2:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_01de;
					case 3:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_026b;
					case 4:
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_02d8;
					case 5:
						{
							awaiter = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<bool[]>);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_01de:
						awaiter4.GetResult();
						awaiter3 = ViewExtensions.TranslateTo((VisualElement)(object)_003C_003E4__this.sprite, _003C_003E4__this.dx, _003C_003E4__this.dy, 180u, Easing.CubicOut).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__1 = awaiter3;
							_003C_003CAnimateAttackCore_003Eb__0_003Ed _003C_003CAnimateAttackCore_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003C_003CAnimateAttackCore_003Eb__0_003Ed>(ref awaiter3, ref _003C_003CAnimateAttackCore_003Eb__0_003Ed);
							return;
						}
						goto IL_026b;
						IL_00fa:
						awaiter6.GetResult();
						awaiter5 = global::System.Threading.Tasks.Task.Delay(300).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter5;
							_003C_003CAnimateAttackCore_003Eb__0_003Ed _003C_003CAnimateAttackCore_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003CAnimateAttackCore_003Eb__0_003Ed>(ref awaiter5, ref _003C_003CAnimateAttackCore_003Eb__0_003Ed);
							return;
						}
						goto IL_0161;
						IL_02d8:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						_003C_003E4__this._003C_003E4__this.AnimateScreenShake(_003C_003E4__this.battleContent, IntensityFor(_003C_003E4__this.effectiveness));
						buffer = default(_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 0) = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.sprite, _003CoriginalScale_003E5__3, 200u, Easing.SpringOut);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 1) = ViewExtensions.TranslateTo((VisualElement)(object)_003C_003E4__this.sprite, _003CoriginalX_003E5__1, _003CoriginalY_003E5__2, 250u, Easing.SpringOut);
						awaiter = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer, 2)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 5);
							_003C_003Eu__3 = awaiter;
							_003C_003CAnimateAttackCore_003Eb__0_003Ed _003C_003CAnimateAttackCore_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003C_003CAnimateAttackCore_003Eb__0_003Ed>(ref awaiter, ref _003C_003CAnimateAttackCore_003Eb__0_003Ed);
							return;
						}
						break;
						IL_0161:
						((TaskAwaiter)(ref awaiter5)).GetResult();
						awaiter4 = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.sprite, 1.15, 80u, Easing.CubicOut).GetAwaiter();
						if (!awaiter4.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = awaiter4;
							_003C_003CAnimateAttackCore_003Eb__0_003Ed _003C_003CAnimateAttackCore_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003C_003CAnimateAttackCore_003Eb__0_003Ed>(ref awaiter4, ref _003C_003CAnimateAttackCore_003Eb__0_003Ed);
							return;
						}
						goto IL_01de;
						IL_026b:
						awaiter3.GetResult();
						awaiter2 = global::System.Threading.Tasks.Task.Delay(_003C_003E4__this.impactHoldMs).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 4);
							_003C_003Eu__2 = awaiter2;
							_003C_003CAnimateAttackCore_003Eb__0_003Ed _003C_003CAnimateAttackCore_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003CAnimateAttackCore_003Eb__0_003Ed>(ref awaiter2, ref _003C_003CAnimateAttackCore_003Eb__0_003Ed);
							return;
						}
						goto IL_02d8;
					}
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

		public Image sprite;

		public double dx;

		public double dy;

		public int impactHoldMs;

		public BattleAnimationService _003C_003E4__this;

		public Grid battleContent;

		public double effectiveness;

		[AsyncStateMachine(typeof(_003C_003CAnimateAttackCore_003Eb__0_003Ed))]
		[DebuggerStepThrough]
		internal global::System.Threading.Tasks.Task _003CAnimateAttackCore_003Eb__0()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003CAnimateAttackCore_003Eb__0_003Ed _003C_003CAnimateAttackCore_003Eb__0_003Ed = new _003C_003CAnimateAttackCore_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateAttackCore_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003CAnimateAttackCore_003Eb__0_003Ed>(ref _003C_003CAnimateAttackCore_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateAttackCore_003Eb__0_003Ed._003C_003Et__builder)).Task;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		private sealed class _003C_003CAnimateScreenShake_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass6_0 _003C_003E4__this;

			private double _003CshakeDistance_003E5__1;

			private int _003CshakeCount_003E5__2;

			private double _003CoriginalX_003E5__3;

			private double _003CoriginalY_003E5__4;

			private int _003Ci_003E5__5;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private void MoveNext()
			{
				//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
				//IL_0101: Unknown result type (might be due to invalid IL or missing references)
				//IL_016f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0174: Unknown result type (might be due to invalid IL or missing references)
				//IL_017b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0211: Unknown result type (might be due to invalid IL or missing references)
				//IL_0216: Unknown result type (might be due to invalid IL or missing references)
				//IL_021e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0138: Unknown result type (might be due to invalid IL or missing references)
				//IL_013d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0151: Unknown result type (might be due to invalid IL or missing references)
				//IL_0152: Unknown result type (might be due to invalid IL or missing references)
				//IL_00be: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
				//IL_01db: Unknown result type (might be due to invalid IL or missing references)
				//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
				//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
				//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<bool> awaiter3;
					TaskAwaiter<bool> awaiter2;
					TaskAwaiter<bool> awaiter;
					switch (num)
					{
					default:
						_003CshakeDistance_003E5__1 = 8.0 * _003C_003E4__this.intensity;
						_003CshakeCount_003E5__2 = ((_003C_003E4__this.intensity >= 1.5) ? 4 : 3);
						_003CoriginalX_003E5__3 = ((VisualElement)_003C_003E4__this.battleContent).TranslationX;
						_003CoriginalY_003E5__4 = ((VisualElement)_003C_003E4__this.battleContent).TranslationY;
						_003Ci_003E5__5 = 0;
						goto IL_01a5;
					case 0:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_0110;
					case 1:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_018a;
					case 2:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_018a:
						awaiter2.GetResult();
						_003Ci_003E5__5++;
						goto IL_01a5;
						IL_0110:
						awaiter3.GetResult();
						awaiter2 = ViewExtensions.TranslateTo((VisualElement)(object)_003C_003E4__this.battleContent, 0.0 - _003CshakeDistance_003E5__1, _003CoriginalY_003E5__4, 50u, (Easing)null).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter2;
							_003C_003CAnimateScreenShake_003Eb__0_003Ed _003C_003CAnimateScreenShake_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003C_003CAnimateScreenShake_003Eb__0_003Ed>(ref awaiter2, ref _003C_003CAnimateScreenShake_003Eb__0_003Ed);
							return;
						}
						goto IL_018a;
						IL_01a5:
						if (_003Ci_003E5__5 < _003CshakeCount_003E5__2)
						{
							awaiter3 = ViewExtensions.TranslateTo((VisualElement)(object)_003C_003E4__this.battleContent, _003CshakeDistance_003E5__1, _003CoriginalY_003E5__4, 50u, (Easing)null).GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter3;
								_003C_003CAnimateScreenShake_003Eb__0_003Ed _003C_003CAnimateScreenShake_003Eb__0_003Ed = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003C_003CAnimateScreenShake_003Eb__0_003Ed>(ref awaiter3, ref _003C_003CAnimateScreenShake_003Eb__0_003Ed);
								return;
							}
							goto IL_0110;
						}
						awaiter = ViewExtensions.TranslateTo((VisualElement)(object)_003C_003E4__this.battleContent, _003CoriginalX_003E5__3, _003CoriginalY_003E5__4, 50u, (Easing)null).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = awaiter;
							_003C_003CAnimateScreenShake_003Eb__0_003Ed _003C_003CAnimateScreenShake_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003C_003CAnimateScreenShake_003Eb__0_003Ed>(ref awaiter, ref _003C_003CAnimateScreenShake_003Eb__0_003Ed);
							return;
						}
						break;
					}
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

		public double intensity;

		public Grid battleContent;

		[AsyncStateMachine(typeof(_003C_003CAnimateScreenShake_003Eb__0_003Ed))]
		[DebuggerStepThrough]
		internal global::System.Threading.Tasks.Task _003CAnimateScreenShake_003Eb__0()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003CAnimateScreenShake_003Eb__0_003Ed _003C_003CAnimateScreenShake_003Eb__0_003Ed = new _003C_003CAnimateScreenShake_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateScreenShake_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003CAnimateScreenShake_003Eb__0_003Ed>(ref _003C_003CAnimateScreenShake_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateScreenShake_003Eb__0_003Ed._003C_003Et__builder)).Task;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		private sealed class _003C_003CAnimateCriticalHit_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass8_0 _003C_003E4__this;

			private int _003Ci_003E5__1;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private void MoveNext()
			{
				//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
				//IL_00af: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
				//IL_012d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0132: Unknown result type (might be due to invalid IL or missing references)
				//IL_0139: Unknown result type (might be due to invalid IL or missing references)
				//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
				//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
				//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
				//IL_024c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0251: Unknown result type (might be due to invalid IL or missing references)
				//IL_0259: Unknown result type (might be due to invalid IL or missing references)
				//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
				//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
				//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
				//IL_0213: Unknown result type (might be due to invalid IL or missing references)
				//IL_0218: Unknown result type (might be due to invalid IL or missing references)
				//IL_028c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0291: Unknown result type (might be due to invalid IL or missing references)
				//IL_010f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0110: Unknown result type (might be due to invalid IL or missing references)
				//IL_022d: Unknown result type (might be due to invalid IL or missing references)
				//IL_022f: Unknown result type (might be due to invalid IL or missing references)
				//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
				//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
				//IL_0073: Unknown result type (might be due to invalid IL or missing references)
				//IL_0078: Unknown result type (might be due to invalid IL or missing references)
				//IL_019a: Unknown result type (might be due to invalid IL or missing references)
				//IL_019f: Unknown result type (might be due to invalid IL or missing references)
				//IL_008c: Unknown result type (might be due to invalid IL or missing references)
				//IL_008d: Unknown result type (might be due to invalid IL or missing references)
				//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
				//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<bool> awaiter5;
					TaskAwaiter<bool> awaiter4;
					TaskAwaiter<bool> awaiter3;
					TaskAwaiter<bool> awaiter2;
					TaskAwaiter<bool> awaiter;
					switch (num)
					{
					default:
						_003Ci_003E5__1 = 0;
						goto IL_0163;
					case 0:
						awaiter5 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_00c5;
					case 1:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_0148;
					case 2:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_01ef;
					case 3:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_0268;
					case 4:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_0163:
						if (_003Ci_003E5__1 < 4)
						{
							awaiter5 = ViewExtensions.TranslateTo((VisualElement)(object)_003C_003E4__this.battleArea, -15.0, 0.0, 25u, Easing.Linear).GetAwaiter();
							if (!awaiter5.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter5;
								_003C_003CAnimateCriticalHit_003Eb__0_003Ed _003C_003CAnimateCriticalHit_003Eb__0_003Ed = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003C_003CAnimateCriticalHit_003Eb__0_003Ed>(ref awaiter5, ref _003C_003CAnimateCriticalHit_003Eb__0_003Ed);
								return;
							}
							goto IL_00c5;
						}
						awaiter3 = ViewExtensions.TranslateTo((VisualElement)(object)_003C_003E4__this.battleArea, 0.0, 0.0, 25u, (Easing)null).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = awaiter3;
							_003C_003CAnimateCriticalHit_003Eb__0_003Ed _003C_003CAnimateCriticalHit_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003C_003CAnimateCriticalHit_003Eb__0_003Ed>(ref awaiter3, ref _003C_003CAnimateCriticalHit_003Eb__0_003Ed);
							return;
						}
						goto IL_01ef;
						IL_0268:
						awaiter2.GetResult();
						awaiter = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.battleArea, 1.0, 50u, (Easing)null).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 4);
							_003C_003Eu__1 = awaiter;
							_003C_003CAnimateCriticalHit_003Eb__0_003Ed _003C_003CAnimateCriticalHit_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003C_003CAnimateCriticalHit_003Eb__0_003Ed>(ref awaiter, ref _003C_003CAnimateCriticalHit_003Eb__0_003Ed);
							return;
						}
						break;
						IL_0148:
						awaiter4.GetResult();
						_003Ci_003E5__1++;
						goto IL_0163;
						IL_01ef:
						awaiter3.GetResult();
						awaiter2 = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.battleArea, 0.6, 50u, (Easing)null).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__1 = awaiter2;
							_003C_003CAnimateCriticalHit_003Eb__0_003Ed _003C_003CAnimateCriticalHit_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003C_003CAnimateCriticalHit_003Eb__0_003Ed>(ref awaiter2, ref _003C_003CAnimateCriticalHit_003Eb__0_003Ed);
							return;
						}
						goto IL_0268;
						IL_00c5:
						awaiter5.GetResult();
						awaiter4 = ViewExtensions.TranslateTo((VisualElement)(object)_003C_003E4__this.battleArea, 15.0, 0.0, 25u, Easing.Linear).GetAwaiter();
						if (!awaiter4.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter4;
							_003C_003CAnimateCriticalHit_003Eb__0_003Ed _003C_003CAnimateCriticalHit_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003C_003CAnimateCriticalHit_003Eb__0_003Ed>(ref awaiter4, ref _003C_003CAnimateCriticalHit_003Eb__0_003Ed);
							return;
						}
						goto IL_0148;
					}
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

		public Grid battleArea;

		[AsyncStateMachine(typeof(_003C_003CAnimateCriticalHit_003Eb__0_003Ed))]
		[DebuggerStepThrough]
		internal global::System.Threading.Tasks.Task _003CAnimateCriticalHit_003Eb__0()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003CAnimateCriticalHit_003Eb__0_003Ed _003C_003CAnimateCriticalHit_003Eb__0_003Ed = new _003C_003CAnimateCriticalHit_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateCriticalHit_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003CAnimateCriticalHit_003Eb__0_003Ed>(ref _003C_003CAnimateCriticalHit_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateCriticalHit_003Eb__0_003Ed._003C_003Et__builder)).Task;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		private sealed class _003C_003CAnimateSpiritEntry_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass9_0 _003C_003E4__this;

			private TaskAwaiter<bool[]> _003C_003Eu__1;

			private void MoveNext()
			{
				//IL_014e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0153: Unknown result type (might be due to invalid IL or missing references)
				//IL_015a: Unknown result type (might be due to invalid IL or missing references)
				//IL_011a: Unknown result type (might be due to invalid IL or missing references)
				//IL_011f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0133: Unknown result type (might be due to invalid IL or missing references)
				//IL_0134: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter<bool[]> awaiter;
					if (num != 0)
					{
						((VisualElement)_003C_003E4__this.sprite).Opacity = 0.0;
						((VisualElement)_003C_003E4__this.sprite).Scale = 0.8;
						((VisualElement)_003C_003E4__this.sprite).TranslationX = (_003C_003E4__this.isPlayer ? (-50.0) : 50.0);
						_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>> buffer = default(_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 0) = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.sprite, 1.0, 400u, Easing.CubicOut);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 1) = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.sprite, 1.0, 400u, Easing.SpringOut);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 2) = ViewExtensions.TranslateTo((VisualElement)(object)_003C_003E4__this.sprite, 0.0, 0.0, 400u, Easing.CubicOut);
						awaiter = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray3<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer, 3)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003C_003CAnimateSpiritEntry_003Eb__0_003Ed _003C_003CAnimateSpiritEntry_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003C_003CAnimateSpiritEntry_003Eb__0_003Ed>(ref awaiter, ref _003C_003CAnimateSpiritEntry_003Eb__0_003Ed);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool[]>);
						num = (_003C_003E1__state = -1);
					}
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

		public Image sprite;

		public bool isPlayer;

		[AsyncStateMachine(typeof(_003C_003CAnimateSpiritEntry_003Eb__0_003Ed))]
		[DebuggerStepThrough]
		internal global::System.Threading.Tasks.Task _003CAnimateSpiritEntry_003Eb__0()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003CAnimateSpiritEntry_003Eb__0_003Ed _003C_003CAnimateSpiritEntry_003Eb__0_003Ed = new _003C_003CAnimateSpiritEntry_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateSpiritEntry_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003CAnimateSpiritEntry_003Eb__0_003Ed>(ref _003C_003CAnimateSpiritEntry_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateSpiritEntry_003Eb__0_003Ed._003C_003Et__builder)).Task;
		}
	}

	[CompilerGenerated]
	private sealed class _003CRunSafe_003Ed__0 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string name;

		public Func<global::System.Threading.Tasks.Task> body;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
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
						awaiter = body.Invoke().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CRunSafe_003Ed__0 _003CRunSafe_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRunSafe_003Ed__0>(ref awaiter, ref _003CRunSafe_003Ed__);
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
					Console.WriteLine("BattleAnimationService: " + name + " error: " + _003Cex_003E5__1.Message);
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

	[AsyncStateMachine(typeof(_003CRunSafe_003Ed__0))]
	[DebuggerStepThrough]
	private static global::System.Threading.Tasks.Task RunSafe(string name, Func<global::System.Threading.Tasks.Task> body)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRunSafe_003Ed__0 _003CRunSafe_003Ed__ = new _003CRunSafe_003Ed__0();
		_003CRunSafe_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRunSafe_003Ed__.name = name;
		_003CRunSafe_003Ed__.body = body;
		_003CRunSafe_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRunSafe_003Ed__._003C_003Et__builder)).Start<_003CRunSafe_003Ed__0>(ref _003CRunSafe_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRunSafe_003Ed__._003C_003Et__builder)).Task;
	}

	public global::System.Threading.Tasks.Task AnimateVsScreenFade(Image vsCanvas)
	{
		_003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass1_0();
		CS_0024_003C_003E8__locals0.vsCanvas = vsCanvas;
		if (CS_0024_003C_003E8__locals0.vsCanvas == null)
		{
			return global::System.Threading.Tasks.Task.CompletedTask;
		}
		return RunSafe("AnimateVsScreenFade", [AsyncStateMachine(typeof(_003C_003Ec__DisplayClass1_0._003C_003CAnimateVsScreenFade_003Eb__0_003Ed))] [DebuggerStepThrough] () =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003Ec__DisplayClass1_0._003C_003CAnimateVsScreenFade_003Eb__0_003Ed _003C_003CAnimateVsScreenFade_003Eb__0_003Ed = new _003C_003Ec__DisplayClass1_0._003C_003CAnimateVsScreenFade_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = CS_0024_003C_003E8__locals0,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateVsScreenFade_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass1_0._003C_003CAnimateVsScreenFade_003Eb__0_003Ed>(ref _003C_003CAnimateVsScreenFade_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateVsScreenFade_003Eb__0_003Ed._003C_003Et__builder)).Task;
		});
	}

	public global::System.Threading.Tasks.Task AnimatePlayerAttack(Image playerSprite, Grid battleContent, double effectiveness = 1.0)
	{
		return AnimateAttackCore("AnimatePlayerAttack", playerSprite, battleContent, 70.0, -150.0, 80, effectiveness);
	}

	public global::System.Threading.Tasks.Task AnimateEnemyAttack(Image enemySprite, Grid battleContent, double effectiveness = 1.0)
	{
		return AnimateAttackCore("AnimateEnemyAttack", enemySprite, battleContent, -125.0, 195.0, 200, effectiveness);
	}

	private global::System.Threading.Tasks.Task AnimateAttackCore(string name, Image sprite, Grid battleContent, double dx, double dy, int impactHoldMs, double effectiveness)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.sprite = sprite;
		CS_0024_003C_003E8__locals0.dx = dx;
		CS_0024_003C_003E8__locals0.dy = dy;
		CS_0024_003C_003E8__locals0.impactHoldMs = impactHoldMs;
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.battleContent = battleContent;
		CS_0024_003C_003E8__locals0.effectiveness = effectiveness;
		if (CS_0024_003C_003E8__locals0.sprite == null)
		{
			return global::System.Threading.Tasks.Task.CompletedTask;
		}
		return RunSafe(name, [AsyncStateMachine(typeof(_003C_003Ec__DisplayClass4_0._003C_003CAnimateAttackCore_003Eb__0_003Ed))] [DebuggerStepThrough] () =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003Ec__DisplayClass4_0._003C_003CAnimateAttackCore_003Eb__0_003Ed _003C_003CAnimateAttackCore_003Eb__0_003Ed = new _003C_003Ec__DisplayClass4_0._003C_003CAnimateAttackCore_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = CS_0024_003C_003E8__locals0,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateAttackCore_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass4_0._003C_003CAnimateAttackCore_003Eb__0_003Ed>(ref _003C_003CAnimateAttackCore_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateAttackCore_003Eb__0_003Ed._003C_003Et__builder)).Task;
		});
	}

	private static double IntensityFor(double effectiveness)
	{
		return (effectiveness >= 2.0) ? 1.5 : ((effectiveness <= 0.5) ? 0.3 : 1.0);
	}

	public global::System.Threading.Tasks.Task AnimateScreenShake(Grid battleContent, double intensity = 1.0)
	{
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals0.intensity = intensity;
		CS_0024_003C_003E8__locals0.battleContent = battleContent;
		if (CS_0024_003C_003E8__locals0.battleContent == null)
		{
			return global::System.Threading.Tasks.Task.CompletedTask;
		}
		return RunSafe("AnimateScreenShake", [AsyncStateMachine(typeof(_003C_003Ec__DisplayClass6_0._003C_003CAnimateScreenShake_003Eb__0_003Ed))] [DebuggerStepThrough] () =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003Ec__DisplayClass6_0._003C_003CAnimateScreenShake_003Eb__0_003Ed _003C_003CAnimateScreenShake_003Eb__0_003Ed = new _003C_003Ec__DisplayClass6_0._003C_003CAnimateScreenShake_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = CS_0024_003C_003E8__locals0,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateScreenShake_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass6_0._003C_003CAnimateScreenShake_003Eb__0_003Ed>(ref _003C_003CAnimateScreenShake_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateScreenShake_003Eb__0_003Ed._003C_003Et__builder)).Task;
		});
	}

	public global::System.Threading.Tasks.Task AnimateHealthDrain(ProgressBar healthBar, double fromValue, double toValue)
	{
		ProgressBar healthBar2 = healthBar;
		if (healthBar2 == null)
		{
			return global::System.Threading.Tasks.Task.CompletedTask;
		}
		return RunSafe("AnimateHealthDrain", delegate
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Expected O, but got Unknown
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			TaskCompletionSource tcs = new TaskCompletionSource();
			Animation val = new Animation((Action<double>)delegate(double v)
			{
				healthBar2.Progress = (float)v;
			}, fromValue, toValue, (Easing)null, (Action)null);
			val.Commit((IAnimatable)(object)healthBar2, "HealthDrain", 16u, 500u, Easing.CubicOut, (Action<double, bool>)delegate
			{
				tcs.TrySetResult();
			}, (Func<bool>)null);
			return tcs.Task;
		});
	}

	public global::System.Threading.Tasks.Task AnimateCriticalHit(Grid battleArea)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.battleArea = battleArea;
		if (CS_0024_003C_003E8__locals0.battleArea == null)
		{
			return global::System.Threading.Tasks.Task.CompletedTask;
		}
		return RunSafe("AnimateCriticalHit", [AsyncStateMachine(typeof(_003C_003Ec__DisplayClass8_0._003C_003CAnimateCriticalHit_003Eb__0_003Ed))] [DebuggerStepThrough] () =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003Ec__DisplayClass8_0._003C_003CAnimateCriticalHit_003Eb__0_003Ed _003C_003CAnimateCriticalHit_003Eb__0_003Ed = new _003C_003Ec__DisplayClass8_0._003C_003CAnimateCriticalHit_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = CS_0024_003C_003E8__locals0,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateCriticalHit_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass8_0._003C_003CAnimateCriticalHit_003Eb__0_003Ed>(ref _003C_003CAnimateCriticalHit_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateCriticalHit_003Eb__0_003Ed._003C_003Et__builder)).Task;
		});
	}

	public global::System.Threading.Tasks.Task AnimateSpiritEntry(Image sprite, bool isPlayer)
	{
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.sprite = sprite;
		CS_0024_003C_003E8__locals0.isPlayer = isPlayer;
		if (CS_0024_003C_003E8__locals0.sprite == null)
		{
			return global::System.Threading.Tasks.Task.CompletedTask;
		}
		return RunSafe("AnimateSpiritEntry", [AsyncStateMachine(typeof(_003C_003Ec__DisplayClass9_0._003C_003CAnimateSpiritEntry_003Eb__0_003Ed))] [DebuggerStepThrough] () =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003Ec__DisplayClass9_0._003C_003CAnimateSpiritEntry_003Eb__0_003Ed _003C_003CAnimateSpiritEntry_003Eb__0_003Ed = new _003C_003Ec__DisplayClass9_0._003C_003CAnimateSpiritEntry_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = CS_0024_003C_003E8__locals0,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateSpiritEntry_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass9_0._003C_003CAnimateSpiritEntry_003Eb__0_003Ed>(ref _003C_003CAnimateSpiritEntry_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateSpiritEntry_003Eb__0_003Ed._003C_003Et__builder)).Task;
		});
	}

	public global::System.Threading.Tasks.Task AnimateSpiritSwitchOut(Image sprite, bool isPlayer)
	{
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals0.sprite = sprite;
		CS_0024_003C_003E8__locals0.isPlayer = isPlayer;
		if (CS_0024_003C_003E8__locals0.sprite == null)
		{
			return global::System.Threading.Tasks.Task.CompletedTask;
		}
		return RunSafe("AnimateSpiritSwitchOut", [AsyncStateMachine(typeof(_003C_003Ec__DisplayClass10_0._003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed))] [DebuggerStepThrough] () =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003Ec__DisplayClass10_0._003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed _003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed = new _003C_003Ec__DisplayClass10_0._003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = CS_0024_003C_003E8__locals0,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass10_0._003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed>(ref _003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateSpiritSwitchOut_003Eb__0_003Ed._003C_003Et__builder)).Task;
		});
	}

	public global::System.Threading.Tasks.Task AnimateCriticalLabel(View label, bool show)
	{
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals0.show = show;
		CS_0024_003C_003E8__locals0.label = label;
		if (CS_0024_003C_003E8__locals0.label == null)
		{
			return global::System.Threading.Tasks.Task.CompletedTask;
		}
		return RunSafe("AnimateCriticalLabel", [AsyncStateMachine(typeof(_003C_003Ec__DisplayClass11_0._003C_003CAnimateCriticalLabel_003Eb__0_003Ed))] [DebuggerStepThrough] () =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003Ec__DisplayClass11_0._003C_003CAnimateCriticalLabel_003Eb__0_003Ed _003C_003CAnimateCriticalLabel_003Eb__0_003Ed = new _003C_003Ec__DisplayClass11_0._003C_003CAnimateCriticalLabel_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = CS_0024_003C_003E8__locals0,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateCriticalLabel_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass11_0._003C_003CAnimateCriticalLabel_003Eb__0_003Ed>(ref _003C_003CAnimateCriticalLabel_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateCriticalLabel_003Eb__0_003Ed._003C_003Et__builder)).Task;
		});
	}

	public global::System.Threading.Tasks.Task AnimateStatusIcon(View badge, bool show, bool isPlayer)
	{
		_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass12_0();
		CS_0024_003C_003E8__locals0.isPlayer = isPlayer;
		CS_0024_003C_003E8__locals0.show = show;
		CS_0024_003C_003E8__locals0.badge = badge;
		if (CS_0024_003C_003E8__locals0.badge == null)
		{
			return global::System.Threading.Tasks.Task.CompletedTask;
		}
		return RunSafe("AnimateStatusIcon", [AsyncStateMachine(typeof(_003C_003Ec__DisplayClass12_0._003C_003CAnimateStatusIcon_003Eb__0_003Ed))] [DebuggerStepThrough] () =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003Ec__DisplayClass12_0._003C_003CAnimateStatusIcon_003Eb__0_003Ed _003C_003CAnimateStatusIcon_003Eb__0_003Ed = new _003C_003Ec__DisplayClass12_0._003C_003CAnimateStatusIcon_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = CS_0024_003C_003E8__locals0,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateStatusIcon_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass12_0._003C_003CAnimateStatusIcon_003Eb__0_003Ed>(ref _003C_003CAnimateStatusIcon_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateStatusIcon_003Eb__0_003Ed._003C_003Et__builder)).Task;
		});
	}

	public global::System.Threading.Tasks.Task AnimateStatusBadge(View badge, bool show)
	{
		_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass13_0();
		CS_0024_003C_003E8__locals0.show = show;
		CS_0024_003C_003E8__locals0.badge = badge;
		if (CS_0024_003C_003E8__locals0.badge == null)
		{
			return global::System.Threading.Tasks.Task.CompletedTask;
		}
		return RunSafe("AnimateStatusBadge", [AsyncStateMachine(typeof(_003C_003Ec__DisplayClass13_0._003C_003CAnimateStatusBadge_003Eb__0_003Ed))] [DebuggerStepThrough] () =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003Ec__DisplayClass13_0._003C_003CAnimateStatusBadge_003Eb__0_003Ed _003C_003CAnimateStatusBadge_003Eb__0_003Ed = new _003C_003Ec__DisplayClass13_0._003C_003CAnimateStatusBadge_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = CS_0024_003C_003E8__locals0,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateStatusBadge_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass13_0._003C_003CAnimateStatusBadge_003Eb__0_003Ed>(ref _003C_003CAnimateStatusBadge_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateStatusBadge_003Eb__0_003Ed._003C_003Et__builder)).Task;
		});
	}

	public global::System.Threading.Tasks.Task AnimateVictoryPose(Image sprite)
	{
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass14_0();
		CS_0024_003C_003E8__locals0.sprite = sprite;
		if (CS_0024_003C_003E8__locals0.sprite == null)
		{
			return global::System.Threading.Tasks.Task.CompletedTask;
		}
		return RunSafe("AnimateVictoryPose", [AsyncStateMachine(typeof(_003C_003Ec__DisplayClass14_0._003C_003CAnimateVictoryPose_003Eb__0_003Ed))] [DebuggerStepThrough] () =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003Ec__DisplayClass14_0._003C_003CAnimateVictoryPose_003Eb__0_003Ed _003C_003CAnimateVictoryPose_003Eb__0_003Ed = new _003C_003Ec__DisplayClass14_0._003C_003CAnimateVictoryPose_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = CS_0024_003C_003E8__locals0,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateVictoryPose_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass14_0._003C_003CAnimateVictoryPose_003Eb__0_003Ed>(ref _003C_003CAnimateVictoryPose_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateVictoryPose_003Eb__0_003Ed._003C_003Et__builder)).Task;
		});
	}

	public global::System.Threading.Tasks.Task AnimateDefeatPose(Image sprite)
	{
		_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass15_0();
		CS_0024_003C_003E8__locals0.sprite = sprite;
		if (CS_0024_003C_003E8__locals0.sprite == null)
		{
			return global::System.Threading.Tasks.Task.CompletedTask;
		}
		return RunSafe("AnimateDefeatPose", [AsyncStateMachine(typeof(_003C_003Ec__DisplayClass15_0._003C_003CAnimateDefeatPose_003Eb__0_003Ed))] [DebuggerStepThrough] () =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003Ec__DisplayClass15_0._003C_003CAnimateDefeatPose_003Eb__0_003Ed _003C_003CAnimateDefeatPose_003Eb__0_003Ed = new _003C_003Ec__DisplayClass15_0._003C_003CAnimateDefeatPose_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = CS_0024_003C_003E8__locals0,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateDefeatPose_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass15_0._003C_003CAnimateDefeatPose_003Eb__0_003Ed>(ref _003C_003CAnimateDefeatPose_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateDefeatPose_003Eb__0_003Ed._003C_003Et__builder)).Task;
		});
	}

	public global::System.Threading.Tasks.Task AnimateMoveIndicator(View indicator, bool show)
	{
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals0.show = show;
		CS_0024_003C_003E8__locals0.indicator = indicator;
		if (CS_0024_003C_003E8__locals0.indicator == null)
		{
			return global::System.Threading.Tasks.Task.CompletedTask;
		}
		return RunSafe("AnimateMoveIndicator", [AsyncStateMachine(typeof(_003C_003Ec__DisplayClass16_0._003C_003CAnimateMoveIndicator_003Eb__0_003Ed))] [DebuggerStepThrough] () =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003Ec__DisplayClass16_0._003C_003CAnimateMoveIndicator_003Eb__0_003Ed _003C_003CAnimateMoveIndicator_003Eb__0_003Ed = new _003C_003Ec__DisplayClass16_0._003C_003CAnimateMoveIndicator_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = CS_0024_003C_003E8__locals0,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateMoveIndicator_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass16_0._003C_003CAnimateMoveIndicator_003Eb__0_003Ed>(ref _003C_003CAnimateMoveIndicator_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateMoveIndicator_003Eb__0_003Ed._003C_003Et__builder)).Task;
		});
	}

	public global::System.Threading.Tasks.Task AnimateDamageIndicator(HorizontalStackLayout indicator, bool show, double effectiveness = 1.0)
	{
		_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass17_0();
		CS_0024_003C_003E8__locals0.show = show;
		CS_0024_003C_003E8__locals0.indicator = indicator;
		CS_0024_003C_003E8__locals0.effectiveness = effectiveness;
		if (CS_0024_003C_003E8__locals0.indicator == null)
		{
			return global::System.Threading.Tasks.Task.CompletedTask;
		}
		return RunSafe("AnimateDamageIndicator", [AsyncStateMachine(typeof(_003C_003Ec__DisplayClass17_0._003C_003CAnimateDamageIndicator_003Eb__0_003Ed))] [DebuggerStepThrough] () =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003Ec__DisplayClass17_0._003C_003CAnimateDamageIndicator_003Eb__0_003Ed _003C_003CAnimateDamageIndicator_003Eb__0_003Ed = new _003C_003Ec__DisplayClass17_0._003C_003CAnimateDamageIndicator_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = CS_0024_003C_003E8__locals0,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateDamageIndicator_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass17_0._003C_003CAnimateDamageIndicator_003Eb__0_003Ed>(ref _003C_003CAnimateDamageIndicator_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateDamageIndicator_003Eb__0_003Ed._003C_003Et__builder)).Task;
		});
	}
}
