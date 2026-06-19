using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.Models;
using SpiritSummoner.Presentation.ViewModels.Shop;

namespace SpiritSummoner.Presentation.Views.Shop;

[XamlFilePath("Presentation\\Views\\Shop\\ShopHubPage.xaml")]
public class ShopHubPage : ContentView
{
	[CompilerGenerated]
	private sealed class _003CAnimateElementIn_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public VisualElement element;

		public int delay;

		public ShopHubPage _003C_003E4__this;

		private global::System.Threading.Tasks.Task<bool> _003CfadeTask_003E5__1;

		private global::System.Threading.Tasks.Task<bool> _003CtranslateTask_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<bool[]> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_0148: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<bool[]> awaiter;
				TaskAwaiter awaiter2;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<bool[]>);
						num = (_003C_003E1__state = -1);
						goto IL_0164;
					}
					if (delay <= 0)
					{
						goto IL_008d;
					}
					awaiter2 = global::System.Threading.Tasks.Task.Delay(delay).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003CAnimateElementIn_003Ed__5 _003CAnimateElementIn_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAnimateElementIn_003Ed__5>(ref awaiter2, ref _003CAnimateElementIn_003Ed__);
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
				goto IL_008d;
				IL_0164:
				awaiter.GetResult();
				goto end_IL_0007;
				IL_008d:
				_003CfadeTask_003E5__1 = ViewExtensions.FadeTo(element, 1.0, 300u, Easing.CubicOut);
				_003CtranslateTask_003E5__2 = ViewExtensions.TranslateTo(element, 0.0, 0.0, 300u, Easing.CubicOut);
				_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>> buffer = default(_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>);
				_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 0) = _003CfadeTask_003E5__1;
				_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 1) = _003CtranslateTask_003E5__2;
				awaiter = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer, 2)).GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__2 = awaiter;
					_003CAnimateElementIn_003Ed__5 _003CAnimateElementIn_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003CAnimateElementIn_003Ed__5>(ref awaiter, ref _003CAnimateElementIn_003Ed__);
					return;
				}
				goto IL_0164;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CfadeTask_003E5__1 = null;
				_003CtranslateTask_003E5__2 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CfadeTask_003E5__1 = null;
			_003CtranslateTask_003E5__2 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003COnBindingContextChanged_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public ShopHubPage _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_008d;
				}
				_003C_003E4__this._003C_003En__0();
				if (((BindableObject)_003C_003E4__this).BindingContext is ShopHubViewModel)
				{
					awaiter = _003C_003E4__this.PlayEntranceAnimation().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003COnBindingContextChanged_003Ed__2 _003COnBindingContextChanged_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnBindingContextChanged_003Ed__2>(ref awaiter, ref _003COnBindingContextChanged_003Ed__);
						return;
					}
					goto IL_008d;
				}
				goto end_IL_0007;
				IL_008d:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
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
	private sealed class _003CPlayEntranceAnimation_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ShopHubPage _003C_003E4__this;

		private global::System.Threading.Tasks.Task[] _003CtabAnimations_003E5__1;

		private global::System.Exception _003Cex_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_016f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
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
							goto IL_01bc;
						}
						((VisualElement)_003C_003E4__this.GoldTab).Opacity = 0.0;
						((VisualElement)_003C_003E4__this.CrystalsTab).Opacity = 0.0;
						((VisualElement)_003C_003E4__this.PremiumTab).Opacity = 0.0;
						((VisualElement)_003C_003E4__this.ContentArea).Opacity = 0.0;
						_003CtabAnimations_003E5__1 = new global::System.Threading.Tasks.Task[3]
						{
							_003C_003E4__this.AnimateElementIn((VisualElement)(object)_003C_003E4__this.GoldTab, 0),
							_003C_003E4__this.AnimateElementIn((VisualElement)(object)_003C_003E4__this.CrystalsTab, 100),
							_003C_003E4__this.AnimateElementIn((VisualElement)(object)_003C_003E4__this.PremiumTab, 200)
						};
						awaiter2 = global::System.Threading.Tasks.Task.WhenAll(_003CtabAnimations_003E5__1).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CPlayEntranceAnimation_003Ed__3 _003CPlayEntranceAnimation_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CPlayEntranceAnimation_003Ed__3>(ref awaiter2, ref _003CPlayEntranceAnimation_003Ed__);
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
					awaiter = _003C_003E4__this.AnimateElementIn((VisualElement)(object)_003C_003E4__this.ContentArea, 0).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter;
						_003CPlayEntranceAnimation_003Ed__3 _003CPlayEntranceAnimation_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CPlayEntranceAnimation_003Ed__3>(ref awaiter, ref _003CPlayEntranceAnimation_003Ed__);
						return;
					}
					goto IL_01bc;
					IL_01bc:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003CtabAnimations_003E5__1 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__2 = ex;
					((VisualElement)_003C_003E4__this.GoldTab).Opacity = 1.0;
					((VisualElement)_003C_003E4__this.CrystalsTab).Opacity = 1.0;
					((VisualElement)_003C_003E4__this.PremiumTab).Opacity = 1.0;
					((VisualElement)_003C_003E4__this.ContentArea).Opacity = 1.0;
					Console.WriteLine("Animation failed: " + _003Cex_003E5__2.Message);
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
	private sealed class _003CTouchBehavior_TouchGestureCompleted_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public TouchGestureCompletedEventArgs e;

		public ShopHubPage _003C_003E4__this;

		private ShopHubViewModel _003Cvm_003E5__1;

		private VisualElement _003Celement_003E5__2;

		private ItemModel _003Citem_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00e8;
				}
				object bindingContext = ((BindableObject)_003C_003E4__this).BindingContext;
				_003Cvm_003E5__1 = bindingContext as ShopHubViewModel;
				if (_003Cvm_003E5__1 != null)
				{
					ref VisualElement reference = ref _003Celement_003E5__2;
					object obj = sender;
					reference = (VisualElement)((obj is VisualElement) ? obj : null);
					while (_003Celement_003E5__2 != null)
					{
						bindingContext = ((BindableObject)_003Celement_003E5__2).BindingContext;
						_003Citem_003E5__3 = bindingContext as ItemModel;
						if (_003Citem_003E5__3 != null)
						{
							awaiter = _003Cvm_003E5__1.ShowItemPopupCommand.ExecuteAsync(_003Citem_003E5__3).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CTouchBehavior_TouchGestureCompleted_003Ed__1 _003CTouchBehavior_TouchGestureCompleted_003Ed__ = this;
								((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CTouchBehavior_TouchGestureCompleted_003Ed__1>(ref awaiter, ref _003CTouchBehavior_TouchGestureCompleted_003Ed__);
								return;
							}
							goto IL_00e8;
						}
						ref VisualElement reference2 = ref _003Celement_003E5__2;
						Element parent = ((Element)_003Celement_003E5__2).Parent;
						reference2 = (VisualElement)(object)((parent is VisualElement) ? parent : null);
						_003Citem_003E5__3 = null;
					}
				}
				goto end_IL_0007;
				IL_00e8:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cvm_003E5__1 = null;
				_003Celement_003E5__2 = null;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cvm_003E5__1 = null;
			_003Celement_003E5__2 = null;
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border ContentArea;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border GoldTab;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border CrystalsTab;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border PremiumTab;

	public ShopHubPage(ShopHubViewModel viewModel)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
	}

	[AsyncStateMachine(typeof(_003CTouchBehavior_TouchGestureCompleted_003Ed__1))]
	[DebuggerStepThrough]
	private void TouchBehavior_TouchGestureCompleted(object sender, TouchGestureCompletedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CTouchBehavior_TouchGestureCompleted_003Ed__1 _003CTouchBehavior_TouchGestureCompleted_003Ed__ = new _003CTouchBehavior_TouchGestureCompleted_003Ed__1();
		_003CTouchBehavior_TouchGestureCompleted_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CTouchBehavior_TouchGestureCompleted_003Ed__._003C_003E4__this = this;
		_003CTouchBehavior_TouchGestureCompleted_003Ed__.sender = sender;
		_003CTouchBehavior_TouchGestureCompleted_003Ed__.e = e;
		_003CTouchBehavior_TouchGestureCompleted_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CTouchBehavior_TouchGestureCompleted_003Ed__._003C_003Et__builder)).Start<_003CTouchBehavior_TouchGestureCompleted_003Ed__1>(ref _003CTouchBehavior_TouchGestureCompleted_003Ed__);
	}

	[AsyncStateMachine(typeof(_003COnBindingContextChanged_003Ed__2))]
	[DebuggerStepThrough]
	protected override void OnBindingContextChanged()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COnBindingContextChanged_003Ed__2 _003COnBindingContextChanged_003Ed__ = new _003COnBindingContextChanged_003Ed__2();
		_003COnBindingContextChanged_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003COnBindingContextChanged_003Ed__._003C_003E4__this = this;
		_003COnBindingContextChanged_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003COnBindingContextChanged_003Ed__._003C_003Et__builder)).Start<_003COnBindingContextChanged_003Ed__2>(ref _003COnBindingContextChanged_003Ed__);
	}

	[AsyncStateMachine(typeof(_003CPlayEntranceAnimation_003Ed__3))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task PlayEntranceAnimation()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CPlayEntranceAnimation_003Ed__3 _003CPlayEntranceAnimation_003Ed__ = new _003CPlayEntranceAnimation_003Ed__3();
		_003CPlayEntranceAnimation_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CPlayEntranceAnimation_003Ed__._003C_003E4__this = this;
		_003CPlayEntranceAnimation_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CPlayEntranceAnimation_003Ed__._003C_003Et__builder)).Start<_003CPlayEntranceAnimation_003Ed__3>(ref _003CPlayEntranceAnimation_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CPlayEntranceAnimation_003Ed__._003C_003Et__builder)).Task;
	}

	private void OnPouchTapped(object sender, EventArgs e)
	{
		if (((BindableObject)this).BindingContext is ShopHubViewModel shopHubViewModel && ((ICommand)shopHubViewModel.GoToPouchCommand).CanExecute((object)null))
		{
			((ICommand)shopHubViewModel.GoToPouchCommand).Execute((object)null);
		}
	}

	[AsyncStateMachine(typeof(_003CAnimateElementIn_003Ed__5))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task AnimateElementIn(VisualElement element, int delay)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CAnimateElementIn_003Ed__5 _003CAnimateElementIn_003Ed__ = new _003CAnimateElementIn_003Ed__5();
		_003CAnimateElementIn_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CAnimateElementIn_003Ed__._003C_003E4__this = this;
		_003CAnimateElementIn_003Ed__.element = element;
		_003CAnimateElementIn_003Ed__.delay = delay;
		_003CAnimateElementIn_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CAnimateElementIn_003Ed__._003C_003Et__builder)).Start<_003CAnimateElementIn_003Ed__5>(ref _003CAnimateElementIn_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CAnimateElementIn_003Ed__._003C_003Et__builder)).Task;
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	[MemberNotNull("ContentArea")]
	[MemberNotNull("GoldTab")]
	[MemberNotNull("CrystalsTab")]
	[MemberNotNull("PremiumTab")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<ShopHubPage>(this, typeof(ShopHubPage));
		ContentArea = NameScopeExtensions.FindByName<Border>((Element)(object)this, "ContentArea");
		GoldTab = NameScopeExtensions.FindByName<Border>((Element)(object)this, "GoldTab");
		CrystalsTab = NameScopeExtensions.FindByName<Border>((Element)(object)this, "CrystalsTab");
		PremiumTab = NameScopeExtensions.FindByName<Border>((Element)(object)this, "PremiumTab");
	}

	[CompilerGenerated]
	[DebuggerHidden]
	private void _003C_003En__0()
	{
		((ContentView)this).OnBindingContextChanged();
	}
}
