using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Popups;

namespace SpiritSummoner.Presentation.Views.Popups.Shared;

[XamlFilePath("Presentation\\Views\\Popups\\ShopPopus\\InsufficientFundsPopup.xaml")]
public class InsufficientFundsPopup : Popup
{
	[CompilerGenerated]
	private sealed class _003CGoToQuestTapped_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public TouchGestureCompletedEventArgs e;

		public InsufficientFundsPopup _003C_003E4__this;

		private InsufficientFundsPopupViewModel _003Cvm_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0096;
				}
				object bindingContext = ((BindableObject)_003C_003E4__this).BindingContext;
				_003Cvm_003E5__1 = bindingContext as InsufficientFundsPopupViewModel;
				if (_003Cvm_003E5__1 != null)
				{
					awaiter = _003Cvm_003E5__1.GoToQuestCommand.ExecuteAsync((object)null).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGoToQuestTapped_003Ed__1 _003CGoToQuestTapped_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToQuestTapped_003Ed__1>(ref awaiter, ref _003CGoToQuestTapped_003Ed__);
						return;
					}
					goto IL_0096;
				}
				goto end_IL_0007;
				IL_0096:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cvm_003E5__1 = null;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cvm_003E5__1 = null;
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGoToShopTapped_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public TouchGestureCompletedEventArgs e;

		public InsufficientFundsPopup _003C_003E4__this;

		private InsufficientFundsPopupViewModel _003Cvm_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0096;
				}
				object bindingContext = ((BindableObject)_003C_003E4__this).BindingContext;
				_003Cvm_003E5__1 = bindingContext as InsufficientFundsPopupViewModel;
				if (_003Cvm_003E5__1 != null)
				{
					awaiter = _003Cvm_003E5__1.GoToShopCommand.ExecuteAsync((object)null).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGoToShopTapped_003Ed__2 _003CGoToShopTapped_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToShopTapped_003Ed__2>(ref awaiter, ref _003CGoToShopTapped_003Ed__);
						return;
					}
					goto IL_0096;
				}
				goto end_IL_0007;
				IL_0096:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cvm_003E5__1 = null;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cvm_003E5__1 = null;
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CMaybeLaterTapped_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public TouchGestureCompletedEventArgs e;

		public InsufficientFundsPopup _003C_003E4__this;

		private InsufficientFundsPopupViewModel _003Cvm_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0096;
				}
				object bindingContext = ((BindableObject)_003C_003E4__this).BindingContext;
				_003Cvm_003E5__1 = bindingContext as InsufficientFundsPopupViewModel;
				if (_003Cvm_003E5__1 != null)
				{
					awaiter = _003Cvm_003E5__1.CancelCommand.ExecuteAsync((object)null).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CMaybeLaterTapped_003Ed__3 _003CMaybeLaterTapped_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CMaybeLaterTapped_003Ed__3>(ref awaiter, ref _003CMaybeLaterTapped_003Ed__);
						return;
					}
					goto IL_0096;
				}
				goto end_IL_0007;
				IL_0096:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cvm_003E5__1 = null;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cvm_003E5__1 = null;
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	public InsufficientFundsPopup(InsufficientFundsPopupViewModel viewModel)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
	}

	[AsyncStateMachine(typeof(_003CGoToQuestTapped_003Ed__1))]
	[DebuggerStepThrough]
	private void GoToQuestTapped(object sender, TouchGestureCompletedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoToQuestTapped_003Ed__1 _003CGoToQuestTapped_003Ed__ = new _003CGoToQuestTapped_003Ed__1();
		_003CGoToQuestTapped_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CGoToQuestTapped_003Ed__._003C_003E4__this = this;
		_003CGoToQuestTapped_003Ed__.sender = sender;
		_003CGoToQuestTapped_003Ed__.e = e;
		_003CGoToQuestTapped_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CGoToQuestTapped_003Ed__._003C_003Et__builder)).Start<_003CGoToQuestTapped_003Ed__1>(ref _003CGoToQuestTapped_003Ed__);
	}

	[AsyncStateMachine(typeof(_003CGoToShopTapped_003Ed__2))]
	[DebuggerStepThrough]
	private void GoToShopTapped(object sender, TouchGestureCompletedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoToShopTapped_003Ed__2 _003CGoToShopTapped_003Ed__ = new _003CGoToShopTapped_003Ed__2();
		_003CGoToShopTapped_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CGoToShopTapped_003Ed__._003C_003E4__this = this;
		_003CGoToShopTapped_003Ed__.sender = sender;
		_003CGoToShopTapped_003Ed__.e = e;
		_003CGoToShopTapped_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CGoToShopTapped_003Ed__._003C_003Et__builder)).Start<_003CGoToShopTapped_003Ed__2>(ref _003CGoToShopTapped_003Ed__);
	}

	[AsyncStateMachine(typeof(_003CMaybeLaterTapped_003Ed__3))]
	[DebuggerStepThrough]
	private void MaybeLaterTapped(object sender, TouchGestureCompletedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CMaybeLaterTapped_003Ed__3 _003CMaybeLaterTapped_003Ed__ = new _003CMaybeLaterTapped_003Ed__3();
		_003CMaybeLaterTapped_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CMaybeLaterTapped_003Ed__._003C_003E4__this = this;
		_003CMaybeLaterTapped_003Ed__.sender = sender;
		_003CMaybeLaterTapped_003Ed__.e = e;
		_003CMaybeLaterTapped_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CMaybeLaterTapped_003Ed__._003C_003Et__builder)).Start<_003CMaybeLaterTapped_003Ed__3>(ref _003CMaybeLaterTapped_003Ed__);
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<InsufficientFundsPopup>(this, typeof(InsufficientFundsPopup));
	}
}
