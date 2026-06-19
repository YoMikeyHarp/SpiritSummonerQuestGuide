using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using SpiritSummoner.Application.State;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Enums.Guilds;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Presentation.Navigation;

namespace SpiritSummoner.Presentation.ViewModels.Guilds;

public class GuildWarHistoryViewModel : ObservableObject, ILoadableViewModel
{
	[CompilerGenerated]
	private sealed class _003CGoBack_003Ed__34 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildWarHistoryViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGoBack_003Ed__34 _003CGoBack_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoBack_003Ed__34>(ref awaiter, ref _003CGoBack_003Ed__);
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
	private sealed class _003CLoadDataAsync_003Ed__31 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object parameter;

		public GuildWarHistoryViewModel _003C_003E4__this;

		private string _003CguildId_003E5__1;

		private List<GuildWarHistory> _003Chistory_003E5__2;

		private List<GuildWarHistory> _003C_003Es__3;

		private TaskAwaiter<List<GuildWarHistory>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0)
				{
					goto IL_0066;
				}
				_003CguildId_003E5__1 = parameter as string;
				if (_003CguildId_003E5__1 != null)
				{
					_003C_003E4__this.GuildId = _003CguildId_003E5__1;
				}
				if (!string.IsNullOrEmpty(_003C_003E4__this.GuildId))
				{
					_003C_003E4__this.IsLoading = true;
					goto IL_0066;
				}
				goto end_IL_0007;
				IL_0066:
				try
				{
					TaskAwaiter<List<GuildWarHistory>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._guildWarRepository.GetGuildWarHistoryAsync(_003C_003E4__this.GuildId, 50).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadDataAsync_003Ed__31 _003CLoadDataAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<List<GuildWarHistory>>, _003CLoadDataAsync_003Ed__31>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<List<GuildWarHistory>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter.GetResult();
					_003Chistory_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					_003C_003E4__this.WarHistory = new ObservableCollection<GuildWarHistory>(_003Chistory_003E5__2);
					_003Chistory_003E5__2 = null;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsLoading = false;
					}
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CguildId_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CguildId_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CRefresh_003Ed__35 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildWarHistoryViewModel _003C_003E4__this;

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
					awaiter = _003C_003E4__this.LoadDataAsync(_003C_003E4__this.GuildId).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CRefresh_003Ed__35 _003CRefresh_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRefresh_003Ed__35>(ref awaiter, ref _003CRefresh_003Ed__);
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

	private readonly IGuildWarRepository _guildWarRepository;

	private readonly INavigationService _navigationService;

	private readonly IGuildStateService _guildStateService;

	[ObservableProperty]
	private string? _guildId;

	[ObservableProperty]
	[NotifyPropertyChangedFor("TotalWins")]
	[NotifyPropertyChangedFor("TotalLosses")]
	[NotifyPropertyChangedFor("WinRateText")]
	[NotifyPropertyChangedFor("RecordText")]
	private ObservableCollection<GuildWarHistory> _warHistory = new ObservableCollection<GuildWarHistory>();

	[ObservableProperty]
	private bool _isLoading;

	[ObservableProperty]
	[NotifyPropertyChangedFor("SelectedWarMvpName")]
	[NotifyPropertyChangedFor("SelectedAttackMvpName")]
	[NotifyPropertyChangedFor("SelectedDefenseMvpName")]
	[NotifyPropertyChangedFor("HasWarMvp")]
	[NotifyPropertyChangedFor("HasAttackMvp")]
	[NotifyPropertyChangedFor("HasDefenseMvp")]
	[NotifyPropertyChangedFor("HasAnyMvp")]
	private GuildWarHistory? _selectedWar;

	[ObservableProperty]
	private bool _isDetailVisible;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<GuildWarHistory>? showDetailCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? closeDetailCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goBackCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? refreshCommand;

	public int TotalWins => Enumerable.Count<GuildWarHistory>((global::System.Collections.Generic.IEnumerable<GuildWarHistory>)WarHistory, (Func<GuildWarHistory, bool>)((GuildWarHistory w) => w.Result == GuildWarResult.won));

	public int TotalLosses => Enumerable.Count<GuildWarHistory>((global::System.Collections.Generic.IEnumerable<GuildWarHistory>)WarHistory, (Func<GuildWarHistory, bool>)((GuildWarHistory w) => w.Result == GuildWarResult.lost));

	public string WinRateText => (((Collection<GuildWarHistory>)(object)WarHistory).Count == 0) ? "--" : $"{(int)((double)TotalWins / (double)((Collection<GuildWarHistory>)(object)WarHistory).Count * 100.0)}%";

	public string RecordText => $"{TotalWins}W  ·  {TotalLosses}L";

	public string SelectedWarMvpName => ResolveName(SelectedWar?.WarMVP);

	public string SelectedAttackMvpName => ResolveName(SelectedWar?.AttackMVP);

	public string SelectedDefenseMvpName => ResolveName(SelectedWar?.DefenseMVP);

	public bool HasWarMvp => !string.IsNullOrEmpty(SelectedWar?.WarMVP);

	public bool HasAttackMvp => !string.IsNullOrEmpty(SelectedWar?.AttackMVP);

	public bool HasDefenseMvp => !string.IsNullOrEmpty(SelectedWar?.DefenseMVP);

	public bool HasAnyMvp => HasWarMvp || HasAttackMvp || HasDefenseMvp;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? GuildId
	{
		get
		{
			return _guildId;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_guildId, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.GuildId);
				_guildId = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.GuildId);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<GuildWarHistory> WarHistory
	{
		get
		{
			return _warHistory;
		}
		[MemberNotNull("_warHistory")]
		set
		{
			if (!EqualityComparer<ObservableCollection<GuildWarHistory>>.Default.Equals(_warHistory, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.WarHistory);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TotalWins);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TotalLosses);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.WinRateText);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.RecordText);
				_warHistory = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.WarHistory);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TotalWins);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TotalLosses);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.WinRateText);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.RecordText);
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
	public GuildWarHistory? SelectedWar
	{
		get
		{
			return _selectedWar;
		}
		set
		{
			if (!EqualityComparer<GuildWarHistory>.Default.Equals(_selectedWar, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SelectedWar);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SelectedWarMvpName);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SelectedAttackMvpName);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SelectedDefenseMvpName);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasWarMvp);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasAttackMvp);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasDefenseMvp);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasAnyMvp);
				_selectedWar = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SelectedWar);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SelectedWarMvpName);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SelectedAttackMvpName);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SelectedDefenseMvpName);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasWarMvp);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasAttackMvp);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasDefenseMvp);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasAnyMvp);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsDetailVisible
	{
		get
		{
			return _isDetailVisible;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isDetailVisible, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsDetailVisible);
				_isDetailVisible = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsDetailVisible);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<GuildWarHistory> ShowDetailCommand => (IRelayCommand<GuildWarHistory>)(object)(showDetailCommand ?? (showDetailCommand = new RelayCommand<GuildWarHistory>((Action<GuildWarHistory>)ShowDetail)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand CloseDetailCommand
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			RelayCommand obj = closeDetailCommand;
			if (obj == null)
			{
				RelayCommand val = new RelayCommand(new Action(CloseDetail));
				RelayCommand val2 = val;
				closeDetailCommand = val;
				obj = val2;
			}
			return (IRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand GoBackCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = goBackCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)GoBack);
				AsyncRelayCommand val2 = val;
				goBackCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
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

	public GuildWarHistoryViewModel(IGuildWarRepository guildWarRepository, INavigationService navigationService, IGuildStateService guildStateService)
	{
		_guildWarRepository = guildWarRepository;
		_navigationService = navigationService;
		_guildStateService = guildStateService;
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__31))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? parameter)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__31 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__31();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.parameter = parameter;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__31>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[RelayCommand]
	private void ShowDetail(GuildWarHistory war)
	{
		SelectedWar = war;
		IsDetailVisible = true;
	}

	[RelayCommand]
	private void CloseDetail()
	{
		IsDetailVisible = false;
		SelectedWar = null;
	}

	[AsyncStateMachine(typeof(_003CGoBack_003Ed__34))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoBack()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoBack_003Ed__34 _003CGoBack_003Ed__ = new _003CGoBack_003Ed__34();
		_003CGoBack_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoBack_003Ed__._003C_003E4__this = this;
		_003CGoBack_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Start<_003CGoBack_003Ed__34>(ref _003CGoBack_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRefresh_003Ed__35))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Refresh()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRefresh_003Ed__35 _003CRefresh_003Ed__ = new _003CRefresh_003Ed__35();
		_003CRefresh_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRefresh_003Ed__._003C_003E4__this = this;
		_003CRefresh_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRefresh_003Ed__._003C_003Et__builder)).Start<_003CRefresh_003Ed__35>(ref _003CRefresh_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRefresh_003Ed__._003C_003Et__builder)).Task;
	}

	private string ResolveName(string? playerId)
	{
		if (string.IsNullOrEmpty(playerId))
		{
			return "—";
		}
		GuildMember member = _guildStateService.GetMember(playerId);
		if (member != null)
		{
			return member.PlayerName;
		}
		return (playerId.Length > 12) ? (playerId.Substring(0, 12) + "…") : playerId;
	}
}
