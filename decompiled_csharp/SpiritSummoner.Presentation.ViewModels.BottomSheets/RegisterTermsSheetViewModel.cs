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

public class RegisterTermsSheetViewModel : ObservableObject
{
	[CompilerGenerated]
	private sealed class _003CConfirmAsync_003Ed__11 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public RegisterTermsSheetViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00cd;
				}
				if (_003C_003E4__this.CanConfirm && _003C_003E4__this._sheet != null && _003C_003E4__this._sheetId != null)
				{
					_003C_003E4__this._bottomSheetService.SetResult(_003C_003E4__this._sheetId, result: true);
					awaiter = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CConfirmAsync_003Ed__11 _003CConfirmAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirmAsync_003Ed__11>(ref awaiter, ref _003CConfirmAsync_003Ed__);
						return;
					}
					goto IL_00cd;
				}
				goto end_IL_0007;
				IL_00cd:
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
	[NotifyPropertyChangedFor("CanConfirm")]
	private bool _termsAccepted;

	[ObservableProperty]
	[NotifyPropertyChangedFor("CanConfirm")]
	private bool _conductAccepted;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? toggleTermsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? toggleConductCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? confirmCommand;

	public bool CanConfirm => TermsAccepted && ConductAccepted;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool TermsAccepted
	{
		get
		{
			return _termsAccepted;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_termsAccepted, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TermsAccepted);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanConfirm);
				_termsAccepted = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TermsAccepted);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanConfirm);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ConductAccepted
	{
		get
		{
			return _conductAccepted;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_conductAccepted, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ConductAccepted);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanConfirm);
				_conductAccepted = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ConductAccepted);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanConfirm);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ToggleTermsCommand
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			RelayCommand obj = toggleTermsCommand;
			if (obj == null)
			{
				RelayCommand val = new RelayCommand(new Action(ToggleTerms));
				RelayCommand val2 = val;
				toggleTermsCommand = val;
				obj = val2;
			}
			return (IRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ToggleConductCommand
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			RelayCommand obj = toggleConductCommand;
			if (obj == null)
			{
				RelayCommand val = new RelayCommand(new Action(ToggleConduct));
				RelayCommand val2 = val;
				toggleConductCommand = val;
				obj = val2;
			}
			return (IRelayCommand)(object)obj;
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

	public RegisterTermsSheetViewModel(IBottomSheetService bottomSheetService)
	{
		_bottomSheetService = bottomSheetService;
	}

	public void Initialize(BottomSheet sheet, string sheetId)
	{
		_sheet = sheet;
		_sheetId = sheetId;
	}

	[RelayCommand]
	private void ToggleTerms()
	{
		TermsAccepted = !TermsAccepted;
	}

	[RelayCommand]
	private void ToggleConduct()
	{
		ConductAccepted = !ConductAccepted;
	}

	[AsyncStateMachine(typeof(_003CConfirmAsync_003Ed__11))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task ConfirmAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CConfirmAsync_003Ed__11 _003CConfirmAsync_003Ed__ = new _003CConfirmAsync_003Ed__11();
		_003CConfirmAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CConfirmAsync_003Ed__._003C_003E4__this = this;
		_003CConfirmAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CConfirmAsync_003Ed__._003C_003Et__builder)).Start<_003CConfirmAsync_003Ed__11>(ref _003CConfirmAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CConfirmAsync_003Ed__._003C_003Et__builder)).Task;
	}
}
