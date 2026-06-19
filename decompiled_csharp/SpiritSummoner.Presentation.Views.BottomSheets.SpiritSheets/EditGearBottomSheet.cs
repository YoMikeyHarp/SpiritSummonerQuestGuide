using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.BottomSheet;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.Views.BottomSheets.SpiritSheets;

[XamlFilePath("Presentation\\Views\\BottomSheets\\SpiritSheets\\EditGearBottomSheet.xaml")]
public class EditGearBottomSheet : BottomSheet
{
	[CompilerGenerated]
	private sealed class _003COnCancelTapped_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public EventArgs e;

		public EditGearBottomSheet _003C_003E4__this;

		private EditGearSheetViewModel _003Cvm_003E5__1;

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
				_003Cvm_003E5__1 = bindingContext as EditGearSheetViewModel;
				if (_003Cvm_003E5__1 != null)
				{
					awaiter = _003Cvm_003E5__1.CancelCommand.ExecuteAsync((object)null).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003COnCancelTapped_003Ed__2 _003COnCancelTapped_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnCancelTapped_003Ed__2>(ref awaiter, ref _003COnCancelTapped_003Ed__);
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
	private sealed class _003COnConfirmTapped_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public EventArgs e;

		public EditGearBottomSheet _003C_003E4__this;

		private EditGearSheetViewModel _003Cvm_003E5__1;

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
				_003Cvm_003E5__1 = bindingContext as EditGearSheetViewModel;
				if (_003Cvm_003E5__1 != null)
				{
					awaiter = _003Cvm_003E5__1.ConfirmCommand.ExecuteAsync((object)null).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003COnConfirmTapped_003Ed__3 _003COnConfirmTapped_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnConfirmTapped_003Ed__3>(ref awaiter, ref _003COnConfirmTapped_003Ed__);
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

	private readonly IBottomSheetService _sheetService;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border divider;

	public EditGearBottomSheet(IBottomSheetService sheetService)
	{
		InitializeComponent();
		_sheetService = sheetService;
	}

	[AsyncStateMachine(typeof(_003COnCancelTapped_003Ed__2))]
	[DebuggerStepThrough]
	private void OnCancelTapped(object sender, EventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COnCancelTapped_003Ed__2 _003COnCancelTapped_003Ed__ = new _003COnCancelTapped_003Ed__2();
		_003COnCancelTapped_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003COnCancelTapped_003Ed__._003C_003E4__this = this;
		_003COnCancelTapped_003Ed__.sender = sender;
		_003COnCancelTapped_003Ed__.e = e;
		_003COnCancelTapped_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003COnCancelTapped_003Ed__._003C_003Et__builder)).Start<_003COnCancelTapped_003Ed__2>(ref _003COnCancelTapped_003Ed__);
	}

	[AsyncStateMachine(typeof(_003COnConfirmTapped_003Ed__3))]
	[DebuggerStepThrough]
	private void OnConfirmTapped(object sender, EventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COnConfirmTapped_003Ed__3 _003COnConfirmTapped_003Ed__ = new _003COnConfirmTapped_003Ed__3();
		_003COnConfirmTapped_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003COnConfirmTapped_003Ed__._003C_003E4__this = this;
		_003COnConfirmTapped_003Ed__.sender = sender;
		_003COnConfirmTapped_003Ed__.e = e;
		_003COnConfirmTapped_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003COnConfirmTapped_003Ed__._003C_003Et__builder)).Start<_003COnConfirmTapped_003Ed__3>(ref _003COnConfirmTapped_003Ed__);
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	[MemberNotNull("divider")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<EditGearBottomSheet>(this, typeof(EditGearBottomSheet));
		divider = NameScopeExtensions.FindByName<Border>((Element)(object)this, "divider");
	}
}
