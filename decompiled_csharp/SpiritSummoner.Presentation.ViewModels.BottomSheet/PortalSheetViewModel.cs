using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using SpiritSummoner.Application.Services;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Presentation.Models;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.Shared;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.ViewModels.BottomSheet;

public class PortalSheetViewModel : ObservableObject, ILoadableViewModel, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003CDismissAsync_003Ed__16 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PortalSheetViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_008e;
				}
				if (_003C_003E4__this._sheet != null)
				{
					awaiter = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CDismissAsync_003Ed__16 _003CDismissAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CDismissAsync_003Ed__16>(ref awaiter, ref _003CDismissAsync_003Ed__);
						return;
					}
					goto IL_008e;
				}
				goto end_IL_0007;
				IL_008e:
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
	private sealed class _003CNavigateTo_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string route;

		public PortalSheetViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if ((uint)num > 1u)
				{
					if (num == 2)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01ff;
					}
					_003C_003Es__1 = null;
					_003C_003Es__2 = 0;
				}
				try
				{
					if ((uint)num > 1u)
					{
					}
					try
					{
						TaskAwaiter awaiter2;
						if (num == 0)
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_00d9;
						}
						TaskAwaiter awaiter3;
						if (num == 1)
						{
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0152;
						}
						if (_003C_003E4__this._navigationService.CanNavigate())
						{
							if (route != "//chat")
							{
								awaiter2 = _003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter2;
									_003CNavigateTo_003Ed__14 _003CNavigateTo_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateTo_003Ed__14>(ref awaiter2, ref _003CNavigateTo_003Ed__);
									return;
								}
								goto IL_00d9;
							}
							goto IL_00e1;
						}
						goto end_IL_0033;
						IL_00e1:
						awaiter3 = _003C_003E4__this._navBarViewModel.NavigateToCommand.ExecuteAsync(route).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter3;
							_003CNavigateTo_003Ed__14 _003CNavigateTo_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateTo_003Ed__14>(ref awaiter3, ref _003CNavigateTo_003Ed__);
							return;
						}
						goto IL_0152;
						IL_0152:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						goto end_IL_002a;
						IL_00d9:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						goto IL_00e1;
						end_IL_0033:;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__3 = ex;
						Console.WriteLine("Portal navigation error: " + _003Cex_003E5__3.Message);
						goto end_IL_002a;
					}
					_003C_003Es__2 = 1;
					end_IL_002a:;
				}
				catch (object obj)
				{
					_003C_003Es__1 = obj;
				}
				awaiter = _003C_003E4__this.DismissAsync().GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 2);
					_003C_003Eu__1 = awaiter;
					_003CNavigateTo_003Ed__14 _003CNavigateTo_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateTo_003Ed__14>(ref awaiter, ref _003CNavigateTo_003Ed__);
					return;
				}
				goto IL_01ff;
				IL_01ff:
				((TaskAwaiter)(ref awaiter)).GetResult();
				object obj2 = _003C_003Es__1;
				if (obj2 != null)
				{
					if (!(obj2 is global::System.Exception ex2))
					{
						throw obj2;
					}
					ExceptionDispatchInfo.Capture(ex2).Throw();
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					_003C_003Es__1 = null;
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

	private readonly IBottomSheetService _bottomSheetService;

	private readonly INavigationService _navigationService;

	private readonly NavBarViewModel _navBarViewModel;

	private readonly PlayerInfoModel _playerInfoModel;

	private readonly IChatUnreadService _chatUnreadService;

	private BottomSheet? _sheet;

	private bool _isDisposed;

	[ObservableProperty]
	private bool _hasUnReadMessages;

	[ObservableProperty]
	private int _unReadMessageCount;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<string>? navigateToCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? dismissCommand;

	public PlayerInfoModel PlayerInfoModel => _playerInfoModel;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool HasUnReadMessages
	{
		get
		{
			return _hasUnReadMessages;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasUnReadMessages, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasUnReadMessages);
				_hasUnReadMessages = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasUnReadMessages);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int UnReadMessageCount
	{
		get
		{
			return _unReadMessageCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_unReadMessageCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.UnReadMessageCount);
				_unReadMessageCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.UnReadMessageCount);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<string> NavigateToCommand => (IAsyncRelayCommand<string>)(object)(navigateToCommand ?? (navigateToCommand = new AsyncRelayCommand<string>((Func<string, global::System.Threading.Tasks.Task>)NavigateTo)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand DismissCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = dismissCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)Dismiss);
				AsyncRelayCommand val2 = val;
				dismissCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public void SetSheet(BottomSheet sheet)
	{
		_sheet = sheet;
	}

	public PortalSheetViewModel(IBottomSheetService bottomSheetService, INavigationService navigationService, NavBarViewModel navBarViewModel, PlayerInfoModel playerInfoModel, IChatUnreadService chatUnreadService)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		_bottomSheetService = bottomSheetService;
		_navigationService = navigationService;
		_navBarViewModel = navBarViewModel;
		_playerInfoModel = playerInfoModel;
		_chatUnreadService = chatUnreadService;
		_chatUnreadService.UnreadCountChanged += new EventHandler(OnUnreadCountChanged);
		HasUnReadMessages = _chatUnreadService.HasUnread;
		UnReadMessageCount = _chatUnreadService.TotalUnreadCount;
	}

	public global::System.Threading.Tasks.Task LoadDataAsync(object? parameter)
	{
		BottomSheet val = (BottomSheet)((parameter is BottomSheet) ? parameter : null);
		if (val != null)
		{
			_sheet = val;
		}
		return global::System.Threading.Tasks.Task.CompletedTask;
	}

	[AsyncStateMachine(typeof(_003CNavigateTo_003Ed__14))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task NavigateTo(string route)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CNavigateTo_003Ed__14 _003CNavigateTo_003Ed__ = new _003CNavigateTo_003Ed__14();
		_003CNavigateTo_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CNavigateTo_003Ed__._003C_003E4__this = this;
		_003CNavigateTo_003Ed__.route = route;
		_003CNavigateTo_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CNavigateTo_003Ed__._003C_003Et__builder)).Start<_003CNavigateTo_003Ed__14>(ref _003CNavigateTo_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CNavigateTo_003Ed__._003C_003Et__builder)).Task;
	}

	[RelayCommand]
	private global::System.Threading.Tasks.Task Dismiss()
	{
		return DismissAsync();
	}

	[AsyncStateMachine(typeof(_003CDismissAsync_003Ed__16))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task DismissAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CDismissAsync_003Ed__16 _003CDismissAsync_003Ed__ = new _003CDismissAsync_003Ed__16();
		_003CDismissAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CDismissAsync_003Ed__._003C_003E4__this = this;
		_003CDismissAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CDismissAsync_003Ed__._003C_003Et__builder)).Start<_003CDismissAsync_003Ed__16>(ref _003CDismissAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CDismissAsync_003Ed__._003C_003Et__builder)).Task;
	}

	private void OnUnreadCountChanged(object? sender, EventArgs e)
	{
		HasUnReadMessages = _chatUnreadService.HasUnread;
		UnReadMessageCount = _chatUnreadService.TotalUnreadCount;
	}

	public void Dispose()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		if (!_isDisposed)
		{
			_chatUnreadService.UnreadCountChanged -= new EventHandler(OnUnreadCountChanged);
			_isDisposed = true;
		}
	}
}
