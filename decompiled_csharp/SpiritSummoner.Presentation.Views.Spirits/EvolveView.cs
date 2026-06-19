using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Spirits;

namespace SpiritSummoner.Presentation.Views.Spirits;

[XamlFilePath("Presentation\\Views\\Spirits\\EvolveView.xaml")]
public class EvolveView : ContentPage
{
	[CompilerGenerated]
	private sealed class _003C_003CPlayEvolveAnimationAsync_003Eb__5_0_003Ed : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public EvolveView _003C_003E4__this;

		private int _003Ci_003E5__1;

		private TaskAwaiter<bool[]> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01af: Unknown result type (might be due to invalid IL or missing references)
			//IL_028b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0290: Unknown result type (might be due to invalid IL or missing references)
			//IL_0298: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0254: Unknown result type (might be due to invalid IL or missing references)
			//IL_0259: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_026e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0270: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<bool[]> awaiter3;
				TaskAwaiter<bool[]> awaiter2;
				TaskAwaiter<bool[]> awaiter;
				_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>> buffer2;
				_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>> buffer3;
				switch (num)
				{
				default:
					_003Ci_003E5__1 = 0;
					goto IL_01d9;
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool[]>);
					num = (_003C_003E1__state = -1);
					goto IL_00f7;
				case 1:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool[]>);
					num = (_003C_003E1__state = -1);
					goto IL_01be;
				case 2:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool[]>);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_01d9:
					if (_003Ci_003E5__1 < 3)
					{
						_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>> buffer = default(_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 0) = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.CurrentSpiritImage, 1.15, 200u, Easing.SinInOut);
						_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 1) = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.GlowOverlay, 0.35, 200u, (Easing)null);
						awaiter3 = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer, 2)).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003C_003CPlayEvolveAnimationAsync_003Eb__5_0_003Ed _003C_003CPlayEvolveAnimationAsync_003Eb__5_0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003C_003CPlayEvolveAnimationAsync_003Eb__5_0_003Ed>(ref awaiter3, ref _003C_003CPlayEvolveAnimationAsync_003Eb__5_0_003Ed);
							return;
						}
						goto IL_00f7;
					}
					buffer2 = default(_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>);
					_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer2, 0) = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.CurrentSpiritImage, 1.3, 300u, Easing.SinIn);
					_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer2, 1) = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.GlowOverlay, 1.0, 300u, (Easing)null);
					awaiter = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer2, 2)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = awaiter;
						_003C_003CPlayEvolveAnimationAsync_003Eb__5_0_003Ed _003C_003CPlayEvolveAnimationAsync_003Eb__5_0_003Ed = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003C_003CPlayEvolveAnimationAsync_003Eb__5_0_003Ed>(ref awaiter, ref _003C_003CPlayEvolveAnimationAsync_003Eb__5_0_003Ed);
						return;
					}
					break;
					IL_01be:
					awaiter2.GetResult();
					_003Ci_003E5__1++;
					goto IL_01d9;
					IL_00f7:
					awaiter3.GetResult();
					buffer3 = default(_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>);
					_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer3, 0) = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.CurrentSpiritImage, 1.0, 200u, Easing.SinInOut);
					_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer3, 1) = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.GlowOverlay, 0.0, 200u, (Easing)null);
					awaiter2 = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer3, 2)).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter2;
						_003C_003CPlayEvolveAnimationAsync_003Eb__5_0_003Ed _003C_003CPlayEvolveAnimationAsync_003Eb__5_0_003Ed = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003C_003CPlayEvolveAnimationAsync_003Eb__5_0_003Ed>(ref awaiter2, ref _003C_003CPlayEvolveAnimationAsync_003Eb__5_0_003Ed);
						return;
					}
					goto IL_01be;
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

	[CompilerGenerated]
	private sealed class _003C_003CRevealEvolvedSpiritAsync_003Eb__6_0_003Ed : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public EvolveView _003C_003E4__this;

		private TaskAwaiter<bool[]> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_01c9;
					}
					_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>> buffer = default(_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>);
					_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 0) = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.CurrentSpiritContainer, 0.0, 400u, (Easing)null);
					_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 1) = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.GlowOverlay, 0.0, 400u, (Easing)null);
					awaiter2 = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer, 2)).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003C_003CRevealEvolvedSpiritAsync_003Eb__6_0_003Ed _003C_003CRevealEvolvedSpiritAsync_003Eb__6_0_003Ed = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003C_003CRevealEvolvedSpiritAsync_003Eb__6_0_003Ed>(ref awaiter2, ref _003C_003CRevealEvolvedSpiritAsync_003Eb__6_0_003Ed);
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
				((VisualElement)_003C_003E4__this.CurrentSpiritContainer).IsVisible = false;
				((VisualElement)_003C_003E4__this.EvolvedSpiritContainer).Scale = 0.7;
				_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>> buffer2 = default(_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>);
				_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer2, 0) = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.EvolvedSpiritContainer, 1.0, 500u, Easing.CubicOut);
				_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer2, 1) = ViewExtensions.ScaleTo((VisualElement)(object)_003C_003E4__this.EvolvedSpiritContainer, 1.0, 500u, Easing.SpringOut);
				awaiter = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer2, 2)).GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003C_003CRevealEvolvedSpiritAsync_003Eb__6_0_003Ed _003C_003CRevealEvolvedSpiritAsync_003Eb__6_0_003Ed = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003C_003CRevealEvolvedSpiritAsync_003Eb__6_0_003Ed>(ref awaiter, ref _003C_003CRevealEvolvedSpiritAsync_003Eb__6_0_003Ed);
					return;
				}
				goto IL_01c9;
				IL_01c9:
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
	private sealed class _003C_003CShowErrorAsync_003Eb__7_0_003Ed : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public EvolveView _003C_003E4__this;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<bool> awaiter3;
				TaskAwaiter<bool> awaiter2;
				TaskAwaiter<bool> awaiter;
				switch (num)
				{
				default:
					awaiter3 = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.CurrentSpiritContainer, 0.0, 300u, (Easing)null).GetAwaiter();
					if (!awaiter3.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter3;
						_003C_003CShowErrorAsync_003Eb__7_0_003Ed _003C_003CShowErrorAsync_003Eb__7_0_003Ed = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003C_003CShowErrorAsync_003Eb__7_0_003Ed>(ref awaiter3, ref _003C_003CShowErrorAsync_003Eb__7_0_003Ed);
						return;
					}
					goto IL_0099;
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_0099;
				case 1:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_0112;
				case 2:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_0112:
					awaiter2.GetResult();
					((VisualElement)_003C_003E4__this.CurrentSpiritContainer).IsVisible = false;
					((VisualElement)_003C_003E4__this.ErrorContainer).IsVisible = true;
					awaiter = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.ErrorContainer, 1.0, 300u, (Easing)null).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = awaiter;
						_003C_003CShowErrorAsync_003Eb__7_0_003Ed _003C_003CShowErrorAsync_003Eb__7_0_003Ed = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003C_003CShowErrorAsync_003Eb__7_0_003Ed>(ref awaiter, ref _003C_003CShowErrorAsync_003Eb__7_0_003Ed);
						return;
					}
					break;
					IL_0099:
					awaiter3.GetResult();
					awaiter2 = ViewExtensions.FadeTo((VisualElement)(object)_003C_003E4__this.GlowOverlay, 0.0, 200u, (Easing)null).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter2;
						_003C_003CShowErrorAsync_003Eb__7_0_003Ed _003C_003CShowErrorAsync_003Eb__7_0_003Ed = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003C_003CShowErrorAsync_003Eb__7_0_003Ed>(ref awaiter2, ref _003C_003CShowErrorAsync_003Eb__7_0_003Ed);
						return;
					}
					goto IL_0112;
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

	[CompilerGenerated]
	private sealed class _003COnViewModelPropertyChanged_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public PropertyChangedEventArgs e;

		public EvolveView _003C_003E4__this;

		private string _003C_003Es__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter3;
				switch (num)
				{
				default:
				{
					string propertyName = e.PropertyName;
					_003C_003Es__1 = propertyName;
					string text = _003C_003Es__1;
					if (!(text == "IsAnimating"))
					{
						if (!(text == "IsEvolved"))
						{
							if (!(text == "ErrorMessage") || string.IsNullOrEmpty(_003C_003E4__this._viewModel?.ErrorMessage))
							{
								break;
							}
							awaiter = _003C_003E4__this.ShowErrorAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__1 = awaiter;
								_003COnViewModelPropertyChanged_003Ed__4 _003COnViewModelPropertyChanged_003Ed__ = this;
								((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__4>(ref awaiter, ref _003COnViewModelPropertyChanged_003Ed__);
								return;
							}
							goto IL_020a;
						}
						EvolveViewModel? viewModel = _003C_003E4__this._viewModel;
						if (viewModel == null || !viewModel.IsEvolved)
						{
							break;
						}
						awaiter2 = _003C_003E4__this.RevealEvolvedSpiritAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter2;
							_003COnViewModelPropertyChanged_003Ed__4 _003COnViewModelPropertyChanged_003Ed__ = this;
							((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__4>(ref awaiter2, ref _003COnViewModelPropertyChanged_003Ed__);
							return;
						}
						goto IL_017f;
					}
					EvolveViewModel? viewModel2 = _003C_003E4__this._viewModel;
					if (viewModel2 == null || !viewModel2.IsAnimating)
					{
						break;
					}
					awaiter3 = _003C_003E4__this.PlayEvolveAnimationAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter3;
						_003COnViewModelPropertyChanged_003Ed__4 _003COnViewModelPropertyChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnViewModelPropertyChanged_003Ed__4>(ref awaiter3, ref _003COnViewModelPropertyChanged_003Ed__);
						return;
					}
					goto IL_00f3;
				}
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00f3;
				case 1:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_017f;
				case 2:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_020a;
					}
					IL_017f:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					break;
					IL_020a:
					((TaskAwaiter)(ref awaiter)).GetResult();
					break;
					IL_00f3:
					((TaskAwaiter)(ref awaiter3)).GetResult();
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
	private sealed class _003CPlayEvolveAnimationAsync_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public EvolveView _003C_003E4__this;

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
					awaiter = MainThread.InvokeOnMainThreadAsync((Func<global::System.Threading.Tasks.Task>)([AsyncStateMachine(typeof(_003C_003CPlayEvolveAnimationAsync_003Eb__5_0_003Ed))] [DebuggerStepThrough] [CompilerGenerated] () =>
					{
						//IL_0007: Unknown result type (might be due to invalid IL or missing references)
						//IL_000c: Unknown result type (might be due to invalid IL or missing references)
						_003C_003CPlayEvolveAnimationAsync_003Eb__5_0_003Ed _003C_003CPlayEvolveAnimationAsync_003Eb__5_0_003Ed = new _003C_003CPlayEvolveAnimationAsync_003Eb__5_0_003Ed
						{
							_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
							_003C_003E4__this = _003C_003E4__this,
							_003C_003E1__state = -1
						};
						((AsyncTaskMethodBuilder)(ref _003C_003CPlayEvolveAnimationAsync_003Eb__5_0_003Ed._003C_003Et__builder)).Start<_003C_003CPlayEvolveAnimationAsync_003Eb__5_0_003Ed>(ref _003C_003CPlayEvolveAnimationAsync_003Eb__5_0_003Ed);
						return ((AsyncTaskMethodBuilder)(ref _003C_003CPlayEvolveAnimationAsync_003Eb__5_0_003Ed._003C_003Et__builder)).Task;
					})).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CPlayEvolveAnimationAsync_003Ed__5 _003CPlayEvolveAnimationAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CPlayEvolveAnimationAsync_003Ed__5>(ref awaiter, ref _003CPlayEvolveAnimationAsync_003Ed__);
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
	private sealed class _003CRevealEvolvedSpiritAsync_003Ed__6 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public EvolveView _003C_003E4__this;

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
					awaiter = MainThread.InvokeOnMainThreadAsync((Func<global::System.Threading.Tasks.Task>)([AsyncStateMachine(typeof(_003C_003CRevealEvolvedSpiritAsync_003Eb__6_0_003Ed))] [DebuggerStepThrough] [CompilerGenerated] () =>
					{
						//IL_0007: Unknown result type (might be due to invalid IL or missing references)
						//IL_000c: Unknown result type (might be due to invalid IL or missing references)
						_003C_003CRevealEvolvedSpiritAsync_003Eb__6_0_003Ed _003C_003CRevealEvolvedSpiritAsync_003Eb__6_0_003Ed = new _003C_003CRevealEvolvedSpiritAsync_003Eb__6_0_003Ed
						{
							_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
							_003C_003E4__this = _003C_003E4__this,
							_003C_003E1__state = -1
						};
						((AsyncTaskMethodBuilder)(ref _003C_003CRevealEvolvedSpiritAsync_003Eb__6_0_003Ed._003C_003Et__builder)).Start<_003C_003CRevealEvolvedSpiritAsync_003Eb__6_0_003Ed>(ref _003C_003CRevealEvolvedSpiritAsync_003Eb__6_0_003Ed);
						return ((AsyncTaskMethodBuilder)(ref _003C_003CRevealEvolvedSpiritAsync_003Eb__6_0_003Ed._003C_003Et__builder)).Task;
					})).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CRevealEvolvedSpiritAsync_003Ed__6 _003CRevealEvolvedSpiritAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRevealEvolvedSpiritAsync_003Ed__6>(ref awaiter, ref _003CRevealEvolvedSpiritAsync_003Ed__);
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
	private sealed class _003CShowErrorAsync_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public EvolveView _003C_003E4__this;

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
					awaiter = MainThread.InvokeOnMainThreadAsync((Func<global::System.Threading.Tasks.Task>)([AsyncStateMachine(typeof(_003C_003CShowErrorAsync_003Eb__7_0_003Ed))] [DebuggerStepThrough] [CompilerGenerated] () =>
					{
						//IL_0007: Unknown result type (might be due to invalid IL or missing references)
						//IL_000c: Unknown result type (might be due to invalid IL or missing references)
						_003C_003CShowErrorAsync_003Eb__7_0_003Ed _003C_003CShowErrorAsync_003Eb__7_0_003Ed = new _003C_003CShowErrorAsync_003Eb__7_0_003Ed
						{
							_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
							_003C_003E4__this = _003C_003E4__this,
							_003C_003E1__state = -1
						};
						((AsyncTaskMethodBuilder)(ref _003C_003CShowErrorAsync_003Eb__7_0_003Ed._003C_003Et__builder)).Start<_003C_003CShowErrorAsync_003Eb__7_0_003Ed>(ref _003C_003CShowErrorAsync_003Eb__7_0_003Ed);
						return ((AsyncTaskMethodBuilder)(ref _003C_003CShowErrorAsync_003Eb__7_0_003Ed._003C_003Et__builder)).Task;
					})).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CShowErrorAsync_003Ed__7 _003CShowErrorAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CShowErrorAsync_003Ed__7>(ref awaiter, ref _003CShowErrorAsync_003Ed__);
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

	private EvolveViewModel? _viewModel;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private BoxView GlowOverlay;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private VerticalStackLayout CurrentSpiritContainer;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Image CurrentSpiritImage;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private ActivityIndicator EvolvingIndicator;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private VerticalStackLayout EvolvedSpiritContainer;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Image EvolvedSpiritImage;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private VerticalStackLayout ErrorContainer;

	public EvolveView()
	{
		InitializeComponent();
	}

	protected override void OnBindingContextChanged()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		((ContentPage)this).OnBindingContextChanged();
		if (_viewModel != null)
		{
			((ObservableObject)_viewModel).PropertyChanged -= new PropertyChangedEventHandler(OnViewModelPropertyChanged);
		}
		_viewModel = ((BindableObject)this).BindingContext as EvolveViewModel;
		if (_viewModel != null)
		{
			((ObservableObject)_viewModel).PropertyChanged += new PropertyChangedEventHandler(OnViewModelPropertyChanged);
		}
	}

	protected override void OnDisappearing()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		((Page)this).OnDisappearing();
		if (_viewModel != null)
		{
			((ObservableObject)_viewModel).PropertyChanged -= new PropertyChangedEventHandler(OnViewModelPropertyChanged);
		}
	}

	[AsyncStateMachine(typeof(_003COnViewModelPropertyChanged_003Ed__4))]
	[DebuggerStepThrough]
	private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COnViewModelPropertyChanged_003Ed__4 _003COnViewModelPropertyChanged_003Ed__ = new _003COnViewModelPropertyChanged_003Ed__4();
		_003COnViewModelPropertyChanged_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003COnViewModelPropertyChanged_003Ed__._003C_003E4__this = this;
		_003COnViewModelPropertyChanged_003Ed__.sender = sender;
		_003COnViewModelPropertyChanged_003Ed__.e = e;
		_003COnViewModelPropertyChanged_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003COnViewModelPropertyChanged_003Ed__._003C_003Et__builder)).Start<_003COnViewModelPropertyChanged_003Ed__4>(ref _003COnViewModelPropertyChanged_003Ed__);
	}

	[AsyncStateMachine(typeof(_003CPlayEvolveAnimationAsync_003Ed__5))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task PlayEvolveAnimationAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CPlayEvolveAnimationAsync_003Ed__5 _003CPlayEvolveAnimationAsync_003Ed__ = new _003CPlayEvolveAnimationAsync_003Ed__5();
		_003CPlayEvolveAnimationAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CPlayEvolveAnimationAsync_003Ed__._003C_003E4__this = this;
		_003CPlayEvolveAnimationAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CPlayEvolveAnimationAsync_003Ed__._003C_003Et__builder)).Start<_003CPlayEvolveAnimationAsync_003Ed__5>(ref _003CPlayEvolveAnimationAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CPlayEvolveAnimationAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRevealEvolvedSpiritAsync_003Ed__6))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task RevealEvolvedSpiritAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRevealEvolvedSpiritAsync_003Ed__6 _003CRevealEvolvedSpiritAsync_003Ed__ = new _003CRevealEvolvedSpiritAsync_003Ed__6();
		_003CRevealEvolvedSpiritAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRevealEvolvedSpiritAsync_003Ed__._003C_003E4__this = this;
		_003CRevealEvolvedSpiritAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRevealEvolvedSpiritAsync_003Ed__._003C_003Et__builder)).Start<_003CRevealEvolvedSpiritAsync_003Ed__6>(ref _003CRevealEvolvedSpiritAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRevealEvolvedSpiritAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CShowErrorAsync_003Ed__7))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ShowErrorAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CShowErrorAsync_003Ed__7 _003CShowErrorAsync_003Ed__ = new _003CShowErrorAsync_003Ed__7();
		_003CShowErrorAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CShowErrorAsync_003Ed__._003C_003E4__this = this;
		_003CShowErrorAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CShowErrorAsync_003Ed__._003C_003Et__builder)).Start<_003CShowErrorAsync_003Ed__7>(ref _003CShowErrorAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CShowErrorAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	[MemberNotNull("GlowOverlay")]
	[MemberNotNull("CurrentSpiritContainer")]
	[MemberNotNull("CurrentSpiritImage")]
	[MemberNotNull("EvolvingIndicator")]
	[MemberNotNull("EvolvedSpiritContainer")]
	[MemberNotNull("EvolvedSpiritImage")]
	[MemberNotNull("ErrorContainer")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<EvolveView>(this, typeof(EvolveView));
		GlowOverlay = NameScopeExtensions.FindByName<BoxView>((Element)(object)this, "GlowOverlay");
		CurrentSpiritContainer = NameScopeExtensions.FindByName<VerticalStackLayout>((Element)(object)this, "CurrentSpiritContainer");
		CurrentSpiritImage = NameScopeExtensions.FindByName<Image>((Element)(object)this, "CurrentSpiritImage");
		EvolvingIndicator = NameScopeExtensions.FindByName<ActivityIndicator>((Element)(object)this, "EvolvingIndicator");
		EvolvedSpiritContainer = NameScopeExtensions.FindByName<VerticalStackLayout>((Element)(object)this, "EvolvedSpiritContainer");
		EvolvedSpiritImage = NameScopeExtensions.FindByName<Image>((Element)(object)this, "EvolvedSpiritImage");
		ErrorContainer = NameScopeExtensions.FindByName<VerticalStackLayout>((Element)(object)this, "ErrorContainer");
	}
}
