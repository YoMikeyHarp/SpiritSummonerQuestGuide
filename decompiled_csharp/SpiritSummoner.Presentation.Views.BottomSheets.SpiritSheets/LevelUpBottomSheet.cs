using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.BottomSheet;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.Views.BottomSheets.SpiritSheets;

[XamlFilePath("Presentation\\Views\\BottomSheets\\SpiritSheets\\LevelUpBottomSheet.xaml")]
public class LevelUpBottomSheet : BottomSheet
{
	[CompilerGenerated]
	private sealed class _003C_003CLevelUpCallback_003Eb__5_0_003Ed : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public LevelUpBottomSheet _003C_003E4__this;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			try
			{
				((ICommand)_003C_003E4__this._viewModel.PreviewLevelUpCommand).Execute((object)null);
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
	private sealed class _003CLevelUpCallback_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object state;

		public LevelUpBottomSheet _003C_003E4__this;

		private void MoveNext()
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			int num = _003C_003E1__state;
			try
			{
				MainThread.BeginInvokeOnMainThread((Action)([AsyncStateMachine(typeof(_003C_003CLevelUpCallback_003Eb__5_0_003Ed))] [DebuggerStepThrough] [CompilerGenerated] () =>
				{
					//IL_0007: Unknown result type (might be due to invalid IL or missing references)
					//IL_000c: Unknown result type (might be due to invalid IL or missing references)
					_003C_003CLevelUpCallback_003Eb__5_0_003Ed _003C_003CLevelUpCallback_003Eb__5_0_003Ed = new _003C_003CLevelUpCallback_003Eb__5_0_003Ed
					{
						_003C_003Et__builder = AsyncVoidMethodBuilder.Create(),
						_003C_003E4__this = _003C_003E4__this,
						_003C_003E1__state = -1
					};
					((AsyncVoidMethodBuilder)(ref _003C_003CLevelUpCallback_003Eb__5_0_003Ed._003C_003Et__builder)).Start<_003C_003CLevelUpCallback_003Eb__5_0_003Ed>(ref _003C_003CLevelUpCallback_003Eb__5_0_003Ed);
				}));
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
	private sealed class _003COnCancelTapped_003Ed__8 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public EventArgs e;

		public LevelUpBottomSheet _003C_003E4__this;

		private LevelUpSheetViewModel _003Cvm_003E5__1;

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
				_003Cvm_003E5__1 = bindingContext as LevelUpSheetViewModel;
				if (_003Cvm_003E5__1 != null)
				{
					awaiter = _003Cvm_003E5__1.CancelCommand.ExecuteAsync((object)null).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003COnCancelTapped_003Ed__8 _003COnCancelTapped_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnCancelTapped_003Ed__8>(ref awaiter, ref _003COnCancelTapped_003Ed__);
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
	private sealed class _003COnConfirmTapped_003Ed__9 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public EventArgs e;

		public LevelUpBottomSheet _003C_003E4__this;

		private LevelUpSheetViewModel _003Cvm_003E5__1;

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
				_003Cvm_003E5__1 = bindingContext as LevelUpSheetViewModel;
				if (_003Cvm_003E5__1 != null)
				{
					awaiter = _003Cvm_003E5__1.ConfirmLevelUpCommand.ExecuteAsync((object)null).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003COnConfirmTapped_003Ed__9 _003COnConfirmTapped_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnConfirmTapped_003Ed__9>(ref awaiter, ref _003COnConfirmTapped_003Ed__);
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
	private sealed class _003COnTrainTapped_003Ed__10 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public EventArgs e;

		public LevelUpBottomSheet _003C_003E4__this;

		private LevelUpSheetViewModel _003Cvm_003E5__1;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			try
			{
				object bindingContext = ((BindableObject)_003C_003E4__this).BindingContext;
				_003Cvm_003E5__1 = bindingContext as LevelUpSheetViewModel;
				if (_003Cvm_003E5__1 != null)
				{
					IRelayCommand previewLevelUpCommand = _003Cvm_003E5__1.PreviewLevelUpCommand;
					if (previewLevelUpCommand != null)
					{
						((ICommand)previewLevelUpCommand).Execute((object)null);
					}
				}
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

	private Timer _levelUpTimer;

	private readonly IBottomSheetService _sheetService;

	private LevelUpSheetViewModel _viewModel;

	public LevelUpBottomSheet(IBottomSheetService sheetService)
	{
		InitializeComponent();
		_sheetService = sheetService;
	}

	private void TouchBehavior_LongPressCompleted(object sender, LongPressCompletedEventArgs e)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		if (((BindableObject)this).BindingContext is LevelUpSheetViewModel viewModel)
		{
			_viewModel = viewModel;
			_levelUpTimer = new Timer(new TimerCallback(LevelUpCallback), (object)null, 0, 100);
		}
	}

	[AsyncStateMachine(typeof(_003CLevelUpCallback_003Ed__5))]
	[DebuggerStepThrough]
	private void LevelUpCallback(object state)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLevelUpCallback_003Ed__5 _003CLevelUpCallback_003Ed__ = new _003CLevelUpCallback_003Ed__5();
		_003CLevelUpCallback_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CLevelUpCallback_003Ed__._003C_003E4__this = this;
		_003CLevelUpCallback_003Ed__.state = state;
		_003CLevelUpCallback_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CLevelUpCallback_003Ed__._003C_003Et__builder)).Start<_003CLevelUpCallback_003Ed__5>(ref _003CLevelUpCallback_003Ed__);
	}

	private void TouchBehavior_TouchStateChanged(object sender, TouchStateChangedEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.State != 1)
		{
			StopLeveling();
		}
	}

	private void StopLeveling()
	{
		Timer levelUpTimer = _levelUpTimer;
		if (levelUpTimer != null)
		{
			levelUpTimer.Dispose();
		}
		_levelUpTimer = null;
	}

	[AsyncStateMachine(typeof(_003COnCancelTapped_003Ed__8))]
	[DebuggerStepThrough]
	private void OnCancelTapped(object sender, EventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COnCancelTapped_003Ed__8 _003COnCancelTapped_003Ed__ = new _003COnCancelTapped_003Ed__8();
		_003COnCancelTapped_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003COnCancelTapped_003Ed__._003C_003E4__this = this;
		_003COnCancelTapped_003Ed__.sender = sender;
		_003COnCancelTapped_003Ed__.e = e;
		_003COnCancelTapped_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003COnCancelTapped_003Ed__._003C_003Et__builder)).Start<_003COnCancelTapped_003Ed__8>(ref _003COnCancelTapped_003Ed__);
	}

	[AsyncStateMachine(typeof(_003COnConfirmTapped_003Ed__9))]
	[DebuggerStepThrough]
	private void OnConfirmTapped(object sender, EventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COnConfirmTapped_003Ed__9 _003COnConfirmTapped_003Ed__ = new _003COnConfirmTapped_003Ed__9();
		_003COnConfirmTapped_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003COnConfirmTapped_003Ed__._003C_003E4__this = this;
		_003COnConfirmTapped_003Ed__.sender = sender;
		_003COnConfirmTapped_003Ed__.e = e;
		_003COnConfirmTapped_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003COnConfirmTapped_003Ed__._003C_003Et__builder)).Start<_003COnConfirmTapped_003Ed__9>(ref _003COnConfirmTapped_003Ed__);
	}

	[AsyncStateMachine(typeof(_003COnTrainTapped_003Ed__10))]
	[DebuggerStepThrough]
	private void OnTrainTapped(object sender, EventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COnTrainTapped_003Ed__10 _003COnTrainTapped_003Ed__ = new _003COnTrainTapped_003Ed__10();
		_003COnTrainTapped_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003COnTrainTapped_003Ed__._003C_003E4__this = this;
		_003COnTrainTapped_003Ed__.sender = sender;
		_003COnTrainTapped_003Ed__.e = e;
		_003COnTrainTapped_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003COnTrainTapped_003Ed__._003C_003Et__builder)).Start<_003COnTrainTapped_003Ed__10>(ref _003COnTrainTapped_003Ed__);
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<LevelUpBottomSheet>(this, typeof(LevelUpBottomSheet));
	}
}
