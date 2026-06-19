using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.BottomSheet;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.Views.BottomSheets.SpiritSheets;

[XamlFilePath("Presentation\\Views\\BottomSheets\\SpiritSheets\\AttributesEditBottomSheet.xaml")]
public class AttributesEditBottomSheet : BottomSheet
{
	[CompilerGenerated]
	private sealed class _003COnCancelTapped_003Ed__11 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public EventArgs e;

		public AttributesEditBottomSheet _003C_003E4__this;

		private AttributesEditViewModel _003Cvm_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
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
				_003C_003E4__this.StopCrementing();
				object bindingContext = ((BindableObject)_003C_003E4__this).BindingContext;
				_003Cvm_003E5__1 = bindingContext as AttributesEditViewModel;
				if (_003Cvm_003E5__1 != null)
				{
					awaiter = _003Cvm_003E5__1.CancelCommand.ExecuteAsync((object)null).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003COnCancelTapped_003Ed__11 _003COnCancelTapped_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnCancelTapped_003Ed__11>(ref awaiter, ref _003COnCancelTapped_003Ed__);
						return;
					}
					goto IL_00a2;
				}
				goto end_IL_0007;
				IL_00a2:
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
	private sealed class _003COnConfirmTapped_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public EventArgs e;

		public AttributesEditBottomSheet _003C_003E4__this;

		private AttributesEditViewModel _003Cvm_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
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
				_003C_003E4__this.StopCrementing();
				object bindingContext = ((BindableObject)_003C_003E4__this).BindingContext;
				_003Cvm_003E5__1 = bindingContext as AttributesEditViewModel;
				if (_003Cvm_003E5__1 != null)
				{
					awaiter = _003Cvm_003E5__1.ConfirmCommand.ExecuteAsync((object)null).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003COnConfirmTapped_003Ed__12 _003COnConfirmTapped_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnConfirmTapped_003Ed__12>(ref awaiter, ref _003COnConfirmTapped_003Ed__);
						return;
					}
					goto IL_00a2;
				}
				goto end_IL_0007;
				IL_00a2:
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

	private readonly IBottomSheetService _bottomSheetService;

	private Timer _crementTimer;

	private string _currentAttributeName;

	private AttributesEditViewModel _viewModel;

	private readonly object _timerLock = new object();

	public AttributesEditBottomSheet(IBottomSheetService bottomSheetService)
	{
		InitializeComponent();
		_bottomSheetService = bottomSheetService;
	}

	private void OnDecrement10Tapped(object sender, EventArgs e)
	{
		BindableObject val = (BindableObject)((sender is BindableObject) ? sender : null);
		if (val != null && val.BindingContext is AttributeEditable attributeEditable && ((BindableObject)this).BindingContext is AttributesEditViewModel attributesEditViewModel)
		{
			attributesEditViewModel.Decrement10(attributeEditable.Name);
		}
	}

	private void OnDecrementTapped(object sender, EventArgs e)
	{
		BindableObject val = (BindableObject)((sender is BindableObject) ? sender : null);
		if (val != null && val.BindingContext is AttributeEditable attributeEditable && ((BindableObject)this).BindingContext is AttributesEditViewModel attributesEditViewModel)
		{
			attributesEditViewModel.Decrement(attributeEditable.Name);
		}
	}

	private void OnIncrementTapped(object sender, EventArgs e)
	{
		BindableObject val = (BindableObject)((sender is BindableObject) ? sender : null);
		if (val != null && val.BindingContext is AttributeEditable attributeEditable && ((BindableObject)this).BindingContext is AttributesEditViewModel attributesEditViewModel)
		{
			attributesEditViewModel.Increment(attributeEditable.Name);
		}
	}

	private void OnIncrement10Tapped(object sender, EventArgs e)
	{
		BindableObject val = (BindableObject)((sender is BindableObject) ? sender : null);
		if (val != null && val.BindingContext is AttributeEditable attributeEditable && ((BindableObject)this).BindingContext is AttributesEditViewModel attributesEditViewModel)
		{
			attributesEditViewModel.Increment10(attributeEditable.Name);
		}
	}

	private void BottomSheet_Dismissed(object sender, DismissOrigin e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		StopCrementing();
		if ((int)e == 0 && ((BindableObject)this).BindingContext is AttributesEditViewModel attributesEditViewModel)
		{
			attributesEditViewModel.Dispose();
		}
	}

	[AsyncStateMachine(typeof(_003COnCancelTapped_003Ed__11))]
	[DebuggerStepThrough]
	private void OnCancelTapped(object sender, EventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COnCancelTapped_003Ed__11 _003COnCancelTapped_003Ed__ = new _003COnCancelTapped_003Ed__11();
		_003COnCancelTapped_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003COnCancelTapped_003Ed__._003C_003E4__this = this;
		_003COnCancelTapped_003Ed__.sender = sender;
		_003COnCancelTapped_003Ed__.e = e;
		_003COnCancelTapped_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003COnCancelTapped_003Ed__._003C_003Et__builder)).Start<_003COnCancelTapped_003Ed__11>(ref _003COnCancelTapped_003Ed__);
	}

	[AsyncStateMachine(typeof(_003COnConfirmTapped_003Ed__12))]
	[DebuggerStepThrough]
	private void OnConfirmTapped(object sender, EventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COnConfirmTapped_003Ed__12 _003COnConfirmTapped_003Ed__ = new _003COnConfirmTapped_003Ed__12();
		_003COnConfirmTapped_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003COnConfirmTapped_003Ed__._003C_003E4__this = this;
		_003COnConfirmTapped_003Ed__.sender = sender;
		_003COnConfirmTapped_003Ed__.e = e;
		_003COnConfirmTapped_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003COnConfirmTapped_003Ed__._003C_003Et__builder)).Start<_003COnConfirmTapped_003Ed__12>(ref _003COnConfirmTapped_003Ed__);
	}

	private void TouchBehavior_LongPressCompleted(object sender, LongPressCompletedEventArgs e)
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected O, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected O, but got Unknown
		if (!(((BindableObject)this).BindingContext is AttributesEditViewModel viewModel))
		{
			return;
		}
		object longPressCommandParameter = e.LongPressCommandParameter;
		Label val = (Label)((longPressCommandParameter is Label) ? longPressCommandParameter : null);
		if (val == null || !(((BindableObject)val).BindingContext is AttributeEditable attributeEditable))
		{
			return;
		}
		_viewModel = viewModel;
		_currentAttributeName = attributeEditable.Name;
		lock (_timerLock)
		{
			Timer crementTimer = _crementTimer;
			if (crementTimer != null)
			{
				crementTimer.Dispose();
			}
			if (val.Text == "+1")
			{
				_crementTimer = new Timer(new TimerCallback(IncrementCallback), (object)null, 100, 100);
			}
			else if (val.Text == "+10" || val.Text == "10")
			{
				_crementTimer = new Timer(new TimerCallback(Increment10Callback), (object)null, 100, 100);
			}
			else if (val.Text == "-1")
			{
				_crementTimer = new Timer(new TimerCallback(DecrementCallback), (object)null, 100, 100);
			}
			else if (val.Text == "-10")
			{
				_crementTimer = new Timer(new TimerCallback(Decrement10Callback), (object)null, 100, 100);
			}
		}
	}

	private void DecrementCallback(object state)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		lock (_timerLock)
		{
			if (_crementTimer == null)
			{
				return;
			}
		}
		MainThread.BeginInvokeOnMainThread((Action)([CompilerGenerated] () =>
		{
			_viewModel?.Decrement(_currentAttributeName);
		}));
	}

	private void Decrement10Callback(object state)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		lock (_timerLock)
		{
			if (_crementTimer == null)
			{
				return;
			}
		}
		MainThread.BeginInvokeOnMainThread((Action)([CompilerGenerated] () =>
		{
			_viewModel?.Decrement10(_currentAttributeName);
		}));
	}

	private void IncrementCallback(object state)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		lock (_timerLock)
		{
			if (_crementTimer == null)
			{
				return;
			}
		}
		MainThread.BeginInvokeOnMainThread((Action)([CompilerGenerated] () =>
		{
			_viewModel?.Increment(_currentAttributeName);
		}));
	}

	private void Increment10Callback(object state)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		lock (_timerLock)
		{
			if (_crementTimer == null)
			{
				return;
			}
		}
		MainThread.BeginInvokeOnMainThread((Action)([CompilerGenerated] () =>
		{
			_viewModel?.Increment10(_currentAttributeName);
		}));
	}

	private void TouchBehavior_TouchStateChanged(object sender, TouchStateChangedEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.State != 1)
		{
			StopCrementing();
		}
	}

	private void StopCrementing()
	{
		lock (_timerLock)
		{
			Timer crementTimer = _crementTimer;
			if (crementTimer != null)
			{
				crementTimer.Dispose();
			}
			_crementTimer = null;
		}
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<AttributesEditBottomSheet>(this, typeof(AttributesEditBottomSheet));
	}
}
