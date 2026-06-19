using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using SpiritSummoner.Presentation.Services;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.ViewModels.BottomSheets;

public class ConfirmUserNameSheetViewModel : ObservableObject
{
	[CompilerGenerated]
	private sealed class _003CCancelAsync_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ConfirmUserNameSheetViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00c0;
				}
				if (_003C_003E4__this._sheet != null && _003C_003E4__this._sheetId != null)
				{
					_003C_003E4__this._bottomSheetService.SetResult(_003C_003E4__this._sheetId, result: false);
					awaiter = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CCancelAsync_003Ed__7 _003CCancelAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCancelAsync_003Ed__7>(ref awaiter, ref _003CCancelAsync_003Ed__);
						return;
					}
					goto IL_00c0;
				}
				goto end_IL_0007;
				IL_00c0:
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
	private sealed class _003CConfirmAsync_003Ed__6 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ConfirmUserNameSheetViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00c0;
				}
				if (_003C_003E4__this._sheet != null && _003C_003E4__this._sheetId != null)
				{
					_003C_003E4__this._bottomSheetService.SetResult(_003C_003E4__this._sheetId, result: true);
					awaiter = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CConfirmAsync_003Ed__6 _003CConfirmAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirmAsync_003Ed__6>(ref awaiter, ref _003CConfirmAsync_003Ed__);
						return;
					}
					goto IL_00c0;
				}
				goto end_IL_0007;
				IL_00c0:
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

	private readonly IBottomSheetService _bottomSheetService;

	private BottomSheet? _sheet;

	private string? _sheetId;

	[ObservableProperty]
	private string _userName = string.Empty;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? confirmCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? cancelCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string UserName
	{
		get
		{
			return _userName;
		}
		[MemberNotNull("_userName")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_userName, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.UserName);
				_userName = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.UserName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ConfirmCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = confirmCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)ConfirmAsync);
				AsyncRelayCommand val2 = val;
				confirmCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand CancelCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = cancelCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)CancelAsync);
				AsyncRelayCommand val2 = val;
				cancelCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public ConfirmUserNameSheetViewModel(IBottomSheetService bottomSheetService)
	{
		_bottomSheetService = bottomSheetService;
	}

	public void Initialize(BottomSheet sheet, string sheetId, string userName)
	{
		_sheet = sheet;
		_sheetId = sheetId;
		UserName = userName;
	}

	[AsyncStateMachine(typeof(_003CConfirmAsync_003Ed__6))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task ConfirmAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CConfirmAsync_003Ed__6 _003CConfirmAsync_003Ed__ = new _003CConfirmAsync_003Ed__6();
		_003CConfirmAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CConfirmAsync_003Ed__._003C_003E4__this = this;
		_003CConfirmAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CConfirmAsync_003Ed__._003C_003Et__builder)).Start<_003CConfirmAsync_003Ed__6>(ref _003CConfirmAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CConfirmAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CCancelAsync_003Ed__7))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task CancelAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CCancelAsync_003Ed__7 _003CCancelAsync_003Ed__ = new _003CCancelAsync_003Ed__7();
		_003CCancelAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CCancelAsync_003Ed__._003C_003E4__this = this;
		_003CCancelAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CCancelAsync_003Ed__._003C_003Et__builder)).Start<_003CCancelAsync_003Ed__7>(ref _003CCancelAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CCancelAsync_003Ed__._003C_003Et__builder)).Task;
	}
}
