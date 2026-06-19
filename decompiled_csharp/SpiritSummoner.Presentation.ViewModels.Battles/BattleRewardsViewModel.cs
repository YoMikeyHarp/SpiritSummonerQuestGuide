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
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.Events;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Battles;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Presentation.Navigation;

namespace SpiritSummoner.Presentation.ViewModels.Battles;

public class BattleRewardsViewModel : ObservableObject, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003CClaimChest_003Ed__29 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleRewardsViewModel _003C_003E4__this;

		private global::System.Threading.Tasks.Task<Result<BattleChestReward>> _003Cresult_003E5__1;

		private Result<BattleChestReward> _003CclaimResult_003E5__2;

		private Result<BattleChestReward> _003C_003Es__3;

		private BattleChestReward _003Creward_003E5__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<Result<BattleChestReward>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_027e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0283: Unknown result type (might be due to invalid IL or missing references)
			//IL_028b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0245: Unknown result type (might be due to invalid IL or missing references)
			//IL_024a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_025f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0261: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 2u || (_003C_003E4__this.IsChestClaimable && !_003C_003E4__this.IsClaimingChest))
				{
					try
					{
						TaskAwaiter<Result<BattleChestReward>> awaiter3;
						TaskAwaiter awaiter2;
						TaskAwaiter awaiter;
						switch (num)
						{
						default:
							_003C_003E4__this.IsClaimingChest = true;
							_003Cresult_003E5__1 = _003C_003E4__this._claimChestUseCase.ExecuteAsync(new ClaimDailyBattleChestRequest());
							awaiter3 = _003Cresult_003E5__1.GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter3;
								_003CClaimChest_003Ed__29 _003CClaimChest_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<BattleChestReward>>, _003CClaimChest_003Ed__29>(ref awaiter3, ref _003CClaimChest_003Ed__);
								return;
							}
							goto IL_00d6;
						case 0:
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<Result<BattleChestReward>>);
							num = (_003C_003E1__state = -1);
							goto IL_00d6;
						case 1:
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0206;
						case 2:
							{
								awaiter = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_029a;
							}
							IL_029a:
							((TaskAwaiter)(ref awaiter)).GetResult();
							break;
							IL_00d6:
							_003C_003Es__3 = awaiter3.GetResult();
							_003CclaimResult_003E5__2 = _003C_003Es__3;
							_003C_003Es__3 = null;
							if (_003CclaimResult_003E5__2.Success && _003CclaimResult_003E5__2.Data != null)
							{
								_003Creward_003E5__4 = _003CclaimResult_003E5__2.Data;
								_003C_003E4__this.RefreshChestState();
								awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Chest Claimed!", $"+{_003Creward_003E5__4.GoldReward} Gold\n+{_003Creward_003E5__4.EnergyReward} Energy").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter2;
									_003CClaimChest_003Ed__29 _003CClaimChest_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CClaimChest_003Ed__29>(ref awaiter2, ref _003CClaimChest_003Ed__);
									return;
								}
								goto IL_0206;
							}
							awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003CclaimResult_003E5__2.ErrorMessage ?? "Failed to claim chest").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__2 = awaiter;
								_003CClaimChest_003Ed__29 _003CClaimChest_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CClaimChest_003Ed__29>(ref awaiter, ref _003CClaimChest_003Ed__);
								return;
							}
							goto IL_029a;
							IL_0206:
							((TaskAwaiter)(ref awaiter2)).GetResult();
							_003Creward_003E5__4 = null;
							break;
						}
						_003Cresult_003E5__1 = null;
						_003CclaimResult_003E5__2 = null;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__5 = ex;
						Console.WriteLine($"ClaimChest error: {_003Cex_003E5__5}");
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsClaimingChest = false;
						}
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

	[CompilerGenerated]
	private sealed class _003CLoadAsync_003Ed__24 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleRewardsViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_007d;
				}
				if (!_003C_003E4__this._hasLoaded)
				{
					awaiter = _003C_003E4__this.RefreshAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CLoadAsync_003Ed__24 _003CLoadAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadAsync_003Ed__24>(ref awaiter, ref _003CLoadAsync_003Ed__);
						return;
					}
					goto IL_007d;
				}
				goto end_IL_0007;
				IL_007d:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003C_003E4__this._hasLoaded = true;
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
	private sealed class _003CRefresh_003Ed__25 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleRewardsViewModel _003C_003E4__this;

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
						_003CRefresh_003Ed__25 _003CRefresh_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRefresh_003Ed__25>(ref awaiter, ref _003CRefresh_003Ed__);
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
	private sealed class _003CRefreshAsync_003Ed__26 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleRewardsViewModel _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						_003C_003E4__this.IsLoading = true;
						_003C_003E4__this.ErrorMessage = string.Empty;
						_003C_003E4__this.RefreshChestState();
						awaiter = _003C_003E4__this.RefreshWarContributionAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CRefreshAsync_003Ed__26 _003CRefreshAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRefreshAsync_003Ed__26>(ref awaiter, ref _003CRefreshAsync_003Ed__);
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
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__1 = ex;
					_003C_003E4__this.ErrorMessage = "Failed to load rewards";
					Console.WriteLine($"BattleRewardsViewModel.RefreshAsync error: {_003Cex_003E5__1}");
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

	[CompilerGenerated]
	private sealed class _003CRefreshWarContributionAsync_003Ed__28 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleRewardsViewModel _003C_003E4__this;

		private Result<WarContributionSummary> _003Cresult_003E5__1;

		private WarContributionSummary _003Csummary_003E5__2;

		private Result<WarContributionSummary> _003C_003Es__3;

		private TaskAwaiter<Result<WarContributionSummary>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<Result<WarContributionSummary>> awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._getContributionUseCase.ExecuteAsync(new GetWarContributionSummaryRequest()).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CRefreshWarContributionAsync_003Ed__28 _003CRefreshWarContributionAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<WarContributionSummary>>, _003CRefreshWarContributionAsync_003Ed__28>(ref awaiter, ref _003CRefreshWarContributionAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Result<WarContributionSummary>>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__3 = awaiter.GetResult();
				_003Cresult_003E5__1 = _003C_003Es__3;
				_003C_003Es__3 = null;
				if (!_003Cresult_003E5__1.Success || _003Cresult_003E5__1.Data == null)
				{
					_003C_003E4__this.IsWarActive = false;
				}
				else
				{
					_003Csummary_003E5__2 = _003Cresult_003E5__1.Data;
					_003C_003E4__this.IsWarActive = _003Csummary_003E5__2.IsWarActive;
					_003C_003E4__this.AttackCount = _003Csummary_003E5__2.AttackCount;
					_003C_003E4__this.RaidCount = _003Csummary_003E5__2.RaidCount;
					_003C_003E4__this.TotalCrystals = _003Csummary_003E5__2.TotalCrystals;
					_003C_003E4__this.EstimatedWarScore = _003Csummary_003E5__2.EstimatedWarScore;
					_003C_003E4__this.EstimatedGuildCoins = _003Csummary_003E5__2.EstimatedGuildCoins;
				}
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cresult_003E5__1 = null;
				_003Csummary_003E5__2 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cresult_003E5__1 = null;
			_003Csummary_003E5__2 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IPlayerStateService _playerState;

	private readonly IGuildStateService _guildState;

	private readonly GetWarContributionSummaryUseCase _getContributionUseCase;

	private readonly ClaimDailyBattleChestUseCase _claimChestUseCase;

	private readonly INavigationService _navigationService;

	private bool _disposed;

	private bool _hasLoaded;

	[ObservableProperty]
	private double _chestFillProgress;

	[ObservableProperty]
	private int _battlesCompleted;

	[ObservableProperty]
	private bool _isChestClaimable;

	[ObservableProperty]
	private bool _isChestClaimed;

	[ObservableProperty]
	private bool _isClaimingChest;

	[ObservableProperty]
	private bool _isWarActive;

	[ObservableProperty]
	private int _attackCount;

	[ObservableProperty]
	private int _raidCount;

	[ObservableProperty]
	private int _totalCrystals;

	[ObservableProperty]
	private double _estimatedWarScore;

	[ObservableProperty]
	private long _estimatedGuildCoins;

	[ObservableProperty]
	private bool _isLoading;

	[ObservableProperty]
	private string _errorMessage = string.Empty;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? refreshCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? claimChestCommand;

	public int ChestFillTarget => 5;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public double ChestFillProgress
	{
		get
		{
			return _chestFillProgress;
		}
		set
		{
			if (!EqualityComparer<double>.Default.Equals(_chestFillProgress, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ChestFillProgress);
				_chestFillProgress = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ChestFillProgress);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int BattlesCompleted
	{
		get
		{
			return _battlesCompleted;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_battlesCompleted, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.BattlesCompleted);
				_battlesCompleted = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.BattlesCompleted);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsChestClaimable
	{
		get
		{
			return _isChestClaimable;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isChestClaimable, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsChestClaimable);
				_isChestClaimable = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsChestClaimable);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsChestClaimed
	{
		get
		{
			return _isChestClaimed;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isChestClaimed, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsChestClaimed);
				_isChestClaimed = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsChestClaimed);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsClaimingChest
	{
		get
		{
			return _isClaimingChest;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isClaimingChest, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsClaimingChest);
				_isClaimingChest = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsClaimingChest);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsWarActive
	{
		get
		{
			return _isWarActive;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isWarActive, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsWarActive);
				_isWarActive = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsWarActive);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int AttackCount
	{
		get
		{
			return _attackCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_attackCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.AttackCount);
				_attackCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.AttackCount);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int RaidCount
	{
		get
		{
			return _raidCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_raidCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.RaidCount);
				_raidCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.RaidCount);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int TotalCrystals
	{
		get
		{
			return _totalCrystals;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_totalCrystals, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TotalCrystals);
				_totalCrystals = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TotalCrystals);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public double EstimatedWarScore
	{
		get
		{
			return _estimatedWarScore;
		}
		set
		{
			if (!EqualityComparer<double>.Default.Equals(_estimatedWarScore, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.EstimatedWarScore);
				_estimatedWarScore = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.EstimatedWarScore);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public long EstimatedGuildCoins
	{
		get
		{
			return _estimatedGuildCoins;
		}
		set
		{
			if (!EqualityComparer<long>.Default.Equals(_estimatedGuildCoins, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.EstimatedGuildCoins);
				_estimatedGuildCoins = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.EstimatedGuildCoins);
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

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ClaimChestCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = claimChestCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)ClaimChest);
				AsyncRelayCommand val2 = val;
				claimChestCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public BattleRewardsViewModel(IPlayerStateService playerState, IGuildStateService guildState, GetWarContributionSummaryUseCase getContributionUseCase, ClaimDailyBattleChestUseCase claimChestUseCase, INavigationService navigationService)
	{
		_playerState = playerState;
		_guildState = guildState;
		_getContributionUseCase = getContributionUseCase;
		_claimChestUseCase = claimChestUseCase;
		_navigationService = navigationService;
		_playerState.StateChanged += OnPlayerStateChanged;
	}

	private void OnPlayerStateChanged(object? sender, StateChangedEventArgs e)
	{
		if (e.Scope == StateChangeScope.Player && e.ChangeType == "BattleStats")
		{
			RefreshChestState();
		}
	}

	[AsyncStateMachine(typeof(_003CLoadAsync_003Ed__24))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task LoadAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadAsync_003Ed__24 _003CLoadAsync_003Ed__ = new _003CLoadAsync_003Ed__24();
		_003CLoadAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadAsync_003Ed__._003C_003E4__this = this;
		_003CLoadAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadAsync_003Ed__24>(ref _003CLoadAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRefresh_003Ed__25))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Refresh()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRefresh_003Ed__25 _003CRefresh_003Ed__ = new _003CRefresh_003Ed__25();
		_003CRefresh_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRefresh_003Ed__._003C_003E4__this = this;
		_003CRefresh_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRefresh_003Ed__._003C_003Et__builder)).Start<_003CRefresh_003Ed__25>(ref _003CRefresh_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRefresh_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRefreshAsync_003Ed__26))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task RefreshAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRefreshAsync_003Ed__26 _003CRefreshAsync_003Ed__ = new _003CRefreshAsync_003Ed__26();
		_003CRefreshAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRefreshAsync_003Ed__._003C_003E4__this = this;
		_003CRefreshAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRefreshAsync_003Ed__._003C_003Et__builder)).Start<_003CRefreshAsync_003Ed__26>(ref _003CRefreshAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRefreshAsync_003Ed__._003C_003Et__builder)).Task;
	}

	private void RefreshChestState()
	{
		Player currentPlayer = _playerState.GetCurrentPlayer();
		if (currentPlayer != null)
		{
			DailyBattleChest dailyBattleChest = currentPlayer.DailyBattleChest;
			BattlesCompleted = dailyBattleChest.EffectiveBattlesCompleted;
			ChestFillProgress = dailyBattleChest.FillProgress;
			IsChestClaimable = dailyBattleChest.IsClaimable;
			IsChestClaimed = dailyBattleChest.IsClaimed;
		}
	}

	[AsyncStateMachine(typeof(_003CRefreshWarContributionAsync_003Ed__28))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task RefreshWarContributionAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRefreshWarContributionAsync_003Ed__28 _003CRefreshWarContributionAsync_003Ed__ = new _003CRefreshWarContributionAsync_003Ed__28();
		_003CRefreshWarContributionAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRefreshWarContributionAsync_003Ed__._003C_003E4__this = this;
		_003CRefreshWarContributionAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRefreshWarContributionAsync_003Ed__._003C_003Et__builder)).Start<_003CRefreshWarContributionAsync_003Ed__28>(ref _003CRefreshWarContributionAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRefreshWarContributionAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CClaimChest_003Ed__29))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task ClaimChest()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CClaimChest_003Ed__29 _003CClaimChest_003Ed__ = new _003CClaimChest_003Ed__29();
		_003CClaimChest_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CClaimChest_003Ed__._003C_003E4__this = this;
		_003CClaimChest_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CClaimChest_003Ed__._003C_003Et__builder)).Start<_003CClaimChest_003Ed__29>(ref _003CClaimChest_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CClaimChest_003Ed__._003C_003Et__builder)).Task;
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			_playerState.StateChanged -= OnPlayerStateChanged;
			_disposed = true;
			GC.SuppressFinalize((object)this);
		}
	}
}
