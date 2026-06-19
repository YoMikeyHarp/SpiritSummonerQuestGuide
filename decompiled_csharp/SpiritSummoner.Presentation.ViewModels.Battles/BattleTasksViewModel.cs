using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using SpiritSummoner.Application.UseCases.Battles;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Presentation.Navigation;

namespace SpiritSummoner.Presentation.ViewModels.Battles;

public class BattleTasksViewModel : ObservableObject, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003CClaimReward_003Ed__11 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string taskId;

		public BattleTasksViewModel _003C_003E4__this;

		private Result<BattleTaskReward> _003Cresult_003E5__1;

		private Result<BattleTaskReward> _003C_003Es__2;

		private BattleTaskReward _003Creward_003E5__3;

		private List<string> _003Cparts_003E5__4;

		private TaskAwaiter<Result<BattleTaskReward>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_027c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0281: Unknown result type (might be due to invalid IL or missing references)
			//IL_0289: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_037c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0381: Unknown result type (might be due to invalid IL or missing references)
			//IL_0389: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0346: Unknown result type (might be due to invalid IL or missing references)
			//IL_034b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0360: Unknown result type (might be due to invalid IL or missing references)
			//IL_0362: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Unknown result type (might be due to invalid IL or missing references)
			//IL_0248: Unknown result type (might be due to invalid IL or missing references)
			//IL_025d: Unknown result type (might be due to invalid IL or missing references)
			//IL_025f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<Result<BattleTaskReward>> awaiter4;
				TaskAwaiter awaiter3;
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					awaiter4 = _003C_003E4__this._claimRewardUseCase.ExecuteAsync(new ClaimBattleTaskRewardRequest(taskId)).GetAwaiter();
					if (!awaiter4.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter4;
						_003CClaimReward_003Ed__11 _003CClaimReward_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<BattleTaskReward>>, _003CClaimReward_003Ed__11>(ref awaiter4, ref _003CClaimReward_003Ed__);
						return;
					}
					goto IL_009e;
				case 0:
					awaiter4 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Result<BattleTaskReward>>);
					num = (_003C_003E1__state = -1);
					goto IL_009e;
				case 1:
					awaiter3 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0298;
				case 2:
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0300;
				case 3:
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_0300:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					_003Creward_003E5__3 = null;
					_003Cparts_003E5__4 = null;
					goto end_IL_0007;
					IL_009e:
					_003C_003Es__2 = awaiter4.GetResult();
					_003Cresult_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (_003Cresult_003E5__1.Success && _003Cresult_003E5__1.Data != null)
					{
						_003Creward_003E5__3 = _003Cresult_003E5__1.Data;
						_003Cparts_003E5__4 = new List<string>();
						if (_003Creward_003E5__3.GoldReward > 0)
						{
							_003Cparts_003E5__4.Add($"+{_003Creward_003E5__3.GoldReward} Crystals");
						}
						if (_003Creward_003E5__3.EnergyReward > 0)
						{
							_003Cparts_003E5__4.Add($"+{_003Creward_003E5__3.EnergyReward} Energy");
						}
						if (_003Creward_003E5__3.GuildCoinsReward > 0)
						{
							_003Cparts_003E5__4.Add($"+{_003Creward_003E5__3.GuildCoinsReward} Guild Coins");
						}
						awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Reward Claimed!", string.Join("\n", (global::System.Collections.Generic.IEnumerable<string>)_003Cparts_003E5__4)).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter3;
							_003CClaimReward_003Ed__11 _003CClaimReward_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CClaimReward_003Ed__11>(ref awaiter3, ref _003CClaimReward_003Ed__);
							return;
						}
						goto IL_0298;
					}
					awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__1.ErrorMessage ?? "Failed to claim reward").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__2 = awaiter;
						_003CClaimReward_003Ed__11 _003CClaimReward_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CClaimReward_003Ed__11>(ref awaiter, ref _003CClaimReward_003Ed__);
						return;
					}
					break;
					IL_0298:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					awaiter2 = _003C_003E4__this.RefreshAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__2 = awaiter2;
						_003CClaimReward_003Ed__11 _003CClaimReward_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CClaimReward_003Ed__11>(ref awaiter2, ref _003CClaimReward_003Ed__);
						return;
					}
					goto IL_0300;
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cresult_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cresult_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CLoadAsync_003Ed__8 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleTasksViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this.RefreshAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CLoadAsync_003Ed__8 _003CLoadAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadAsync_003Ed__8>(ref awaiter, ref _003CLoadAsync_003Ed__);
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
	private sealed class _003CRefresh_003Ed__9 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleTasksViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this.RefreshAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CRefresh_003Ed__9 _003CRefresh_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRefresh_003Ed__9>(ref awaiter, ref _003CRefresh_003Ed__);
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
	private sealed class _003CRefreshAsync_003Ed__10 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleTasksViewModel _003C_003E4__this;

		private Result<GetBattleTasksResponse> _003Cresult_003E5__1;

		private Result<GetBattleTasksResponse> _003C_003Es__2;

		private global::System.Collections.Generic.IEnumerator<BattleTaskView> _003C_003Es__3;

		private BattleTaskView _003Ctask_003E5__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<Result<GetBattleTasksResponse>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<Result<GetBattleTasksResponse>> awaiter;
					if (num != 0)
					{
						_003C_003E4__this.IsLoading = true;
						_003C_003E4__this.ErrorMessage = string.Empty;
						awaiter = _003C_003E4__this._getTasksUseCase.ExecuteAsync(new GetBattleTasksRequest()).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CRefreshAsync_003Ed__10 _003CRefreshAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<GetBattleTasksResponse>>, _003CRefreshAsync_003Ed__10>(ref awaiter, ref _003CRefreshAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<GetBattleTasksResponse>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cresult_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					if (!_003Cresult_003E5__1.Success || _003Cresult_003E5__1.Data == null)
					{
						_003C_003E4__this.ErrorMessage = _003Cresult_003E5__1.ErrorMessage ?? "Failed to load tasks";
					}
					else
					{
						((Collection<BattleTaskItemViewModel>)(object)_003C_003E4__this.Tasks).Clear();
						_003C_003Es__3 = ((global::System.Collections.Generic.IEnumerable<BattleTaskView>)_003Cresult_003E5__1.Data.Tasks).GetEnumerator();
						try
						{
							while (((global::System.Collections.IEnumerator)_003C_003Es__3).MoveNext())
							{
								_003Ctask_003E5__4 = _003C_003Es__3.Current;
								((Collection<BattleTaskItemViewModel>)(object)_003C_003E4__this.Tasks).Add(new BattleTaskItemViewModel(_003Ctask_003E5__4, _003C_003E4__this.ClaimReward));
								_003Ctask_003E5__4 = null;
							}
						}
						finally
						{
							if (num < 0 && _003C_003Es__3 != null)
							{
								((global::System.IDisposable)_003C_003Es__3).Dispose();
							}
						}
						_003C_003Es__3 = null;
						_003Cresult_003E5__1 = null;
					}
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					_003C_003E4__this.ErrorMessage = "Failed to load tasks";
					Console.WriteLine($"BattleTasksViewModel.RefreshAsync error: {_003Cex_003E5__5}");
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsLoading = false;
					}
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

	private readonly GetBattleTasksUseCase _getTasksUseCase;

	private readonly ClaimBattleTaskRewardUseCase _claimRewardUseCase;

	private readonly INavigationService _navigationService;

	private bool _disposed;

	[ObservableProperty]
	private ObservableCollection<BattleTaskItemViewModel> _tasks = new ObservableCollection<BattleTaskItemViewModel>();

	[ObservableProperty]
	private bool _isLoading;

	[ObservableProperty]
	private string _errorMessage = string.Empty;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? refreshCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<BattleTaskItemViewModel> Tasks
	{
		get
		{
			return _tasks;
		}
		[MemberNotNull("_tasks")]
		set
		{
			if (!EqualityComparer<ObservableCollection<BattleTaskItemViewModel>>.Default.Equals(_tasks, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Tasks);
				_tasks = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Tasks);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsLoading
	{
		get
		{
			return _isLoading;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isLoading, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsLoading);
				_isLoading = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsLoading);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string ErrorMessage
	{
		get
		{
			return _errorMessage;
		}
		[MemberNotNull("_errorMessage")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_errorMessage, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ErrorMessage);
				_errorMessage = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ErrorMessage);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand RefreshCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = refreshCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)Refresh);
				AsyncRelayCommand val2 = val;
				refreshCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public BattleTasksViewModel(GetBattleTasksUseCase getTasksUseCase, ClaimBattleTaskRewardUseCase claimRewardUseCase, INavigationService navigationService)
	{
		_getTasksUseCase = getTasksUseCase;
		_claimRewardUseCase = claimRewardUseCase;
		_navigationService = navigationService;
	}

	[AsyncStateMachine(typeof(_003CLoadAsync_003Ed__8))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task LoadAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadAsync_003Ed__8 _003CLoadAsync_003Ed__ = new _003CLoadAsync_003Ed__8();
		_003CLoadAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadAsync_003Ed__._003C_003E4__this = this;
		_003CLoadAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadAsync_003Ed__8>(ref _003CLoadAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRefresh_003Ed__9))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Refresh()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRefresh_003Ed__9 _003CRefresh_003Ed__ = new _003CRefresh_003Ed__9();
		_003CRefresh_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRefresh_003Ed__._003C_003E4__this = this;
		_003CRefresh_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRefresh_003Ed__._003C_003Et__builder)).Start<_003CRefresh_003Ed__9>(ref _003CRefresh_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRefresh_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRefreshAsync_003Ed__10))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task RefreshAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRefreshAsync_003Ed__10 _003CRefreshAsync_003Ed__ = new _003CRefreshAsync_003Ed__10();
		_003CRefreshAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRefreshAsync_003Ed__._003C_003E4__this = this;
		_003CRefreshAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRefreshAsync_003Ed__._003C_003Et__builder)).Start<_003CRefreshAsync_003Ed__10>(ref _003CRefreshAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRefreshAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CClaimReward_003Ed__11))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ClaimReward(string taskId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CClaimReward_003Ed__11 _003CClaimReward_003Ed__ = new _003CClaimReward_003Ed__11();
		_003CClaimReward_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CClaimReward_003Ed__._003C_003E4__this = this;
		_003CClaimReward_003Ed__.taskId = taskId;
		_003CClaimReward_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CClaimReward_003Ed__._003C_003Et__builder)).Start<_003CClaimReward_003Ed__11>(ref _003CClaimReward_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CClaimReward_003Ed__._003C_003Et__builder)).Task;
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			_disposed = true;
			GC.SuppressFinalize((object)this);
		}
	}
}
