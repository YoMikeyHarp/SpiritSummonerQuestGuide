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
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Spirits;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Interfaces.Services;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.Services;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.ViewModels.BottomSheet;

public class LevelUpSheetViewModel : ObservableObject
{
	[CompilerGenerated]
	private sealed class _003CCancel_003Ed__39 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public LevelUpSheetViewModel _003C_003E4__this;

		private bool _003CshouldCancel_003E5__1;

		private bool _003C_003Es__2;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				TaskAwaiter<bool> awaiter2;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_012e;
					}
					_003CshouldCancel_003E5__1 = true;
					if (!_003C_003E4__this.HasUnsavedChanges)
					{
						goto IL_00c4;
					}
					awaiter2 = _003C_003E4__this._navigationService.ShowConfirmationAsync("Unsaved Changes", "You have unsaved changes. Are you sure you want to cancel?").GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003CCancel_003Ed__39 _003CCancel_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CCancel_003Ed__39>(ref awaiter2, ref _003CCancel_003Ed__);
						return;
					}
				}
				else
				{
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__2 = awaiter2.GetResult();
				_003CshouldCancel_003E5__1 = _003C_003Es__2;
				goto IL_00c4;
				IL_012e:
				((TaskAwaiter)(ref awaiter)).GetResult();
				goto end_IL_0007;
				IL_00c4:
				if (_003CshouldCancel_003E5__1)
				{
					awaiter = _003C_003E4__this.DismissSheet().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter;
						_003CCancel_003Ed__39 _003CCancel_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCancel_003Ed__39>(ref awaiter, ref _003CCancel_003Ed__);
						return;
					}
					goto IL_012e;
				}
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
	private sealed class _003CConfirmLevelUp_003Ed__38 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public LevelUpSheetViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private int _003ClevelsGained_003E5__3;

		private LevelUpSpiritRequest _003Crequest_003E5__4;

		private Result<LevelUpSpiritResponse> _003Cresult_003E5__5;

		private Result<LevelUpSpiritResponse> _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter<Result<LevelUpSpiritResponse>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0300: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_01af: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0221: Unknown result type (might be due to invalid IL or missing references)
			//IL_0229: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 3u || _003C_003E4__this.CanConfirm)
				{
					try
					{
						TaskAwaiter awaiter;
						if ((uint)num > 2u)
						{
							if (num == 3)
							{
								awaiter = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_030f;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter<Result<LevelUpSpiritResponse>> awaiter4;
							TaskAwaiter awaiter3;
							TaskAwaiter awaiter2;
							switch (num)
							{
							default:
								_003C_003E4__this.IsProcessing = true;
								_003ClevelsGained_003E5__3 = _003C_003E4__this.CurrentLevel - _003C_003E4__this._originalLevel;
								_003Crequest_003E5__4 = new LevelUpSpiritRequest(_003C_003E4__this._spiritId, _003ClevelsGained_003E5__3);
								awaiter4 = _003C_003E4__this._levelUpUseCase.ExecuteAsync(_003Crequest_003E5__4).GetAwaiter();
								if (!awaiter4.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter4;
									_003CConfirmLevelUp_003Ed__38 _003CConfirmLevelUp_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<LevelUpSpiritResponse>>, _003CConfirmLevelUp_003Ed__38>(ref awaiter4, ref _003CConfirmLevelUp_003Ed__);
									return;
								}
								goto IL_0115;
							case 0:
								awaiter4 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<Result<LevelUpSpiritResponse>>);
								num = (_003C_003E1__state = -1);
								goto IL_0115;
							case 1:
								awaiter3 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_01cb;
							case 2:
								{
									awaiter2 = _003C_003Eu__2;
									_003C_003Eu__2 = default(TaskAwaiter);
									num = (_003C_003E1__state = -1);
									break;
								}
								IL_01cb:
								((TaskAwaiter)(ref awaiter3)).GetResult();
								goto end_IL_0028;
								IL_0115:
								_003C_003Es__6 = awaiter4.GetResult();
								_003Cresult_003E5__5 = _003C_003Es__6;
								_003C_003Es__6 = null;
								if (!_003Cresult_003E5__5.Success)
								{
									awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Level Up Failed", _003Cresult_003E5__5.ErrorMessage ?? "Failed to level up spirit. Please try again.").GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
									{
										num = (_003C_003E1__state = 1);
										_003C_003Eu__2 = awaiter3;
										_003CConfirmLevelUp_003Ed__38 _003CConfirmLevelUp_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirmLevelUp_003Ed__38>(ref awaiter3, ref _003CConfirmLevelUp_003Ed__);
										return;
									}
									goto IL_01cb;
								}
								awaiter2 = _003C_003E4__this.DismissSheet().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__2 = awaiter2;
									_003CConfirmLevelUp_003Ed__38 _003CConfirmLevelUp_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirmLevelUp_003Ed__38>(ref awaiter2, ref _003CConfirmLevelUp_003Ed__);
									return;
								}
								break;
							}
							((TaskAwaiter)(ref awaiter2)).GetResult();
							_003Crequest_003E5__4 = null;
							_003Cresult_003E5__5 = null;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
						}
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_0321;
						}
						_003Cex_003E5__7 = (global::System.Exception)_003C_003Es__1;
						Console.WriteLine("Error during level up: " + _003Cex_003E5__7.Message);
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "An unexpected error occurred while leveling up.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__2 = awaiter;
							_003CConfirmLevelUp_003Ed__38 _003CConfirmLevelUp_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirmLevelUp_003Ed__38>(ref awaiter, ref _003CConfirmLevelUp_003Ed__);
							return;
						}
						goto IL_030f;
						IL_030f:
						((TaskAwaiter)(ref awaiter)).GetResult();
						_003Cex_003E5__7 = null;
						goto IL_0321;
						IL_0321:
						_003C_003Es__1 = null;
						end_IL_0028:;
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsProcessing = false;
						}
					}
				}
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
	private sealed class _003CDismissSheet_003Ed__40 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public LevelUpSheetViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CDismissSheet_003Ed__40 _003CDismissSheet_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CDismissSheet_003Ed__40>(ref awaiter, ref _003CDismissSheet_003Ed__);
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

	private readonly IBottomSheetService _bottomSheetService;

	private readonly IPlayerStateService _stateService;

	private readonly INavigationService _navigationService;

	private readonly ISpiritBusinessService _spiritBusinessService;

	private readonly LevelUpSpiritUseCase _levelUpUseCase;

	private BottomSheet? _sheet;

	private readonly string _spiritId;

	private readonly string _spiritName;

	private readonly long _originalGold;

	private readonly int _originalLevel;

	private readonly int _originalHP;

	private readonly int _originalTrainingPoints;

	private readonly int _playerMaxLevel;

	[ObservableProperty]
	[NotifyPropertyChangedFor("RequiredGold")]
	[NotifyPropertyChangedFor("CanLevelUp")]
	[NotifyPropertyChangedFor("PreviewLevel")]
	[NotifyPropertyChangedFor("PreviewHP")]
	[NotifyPropertyChangedFor("PreviewTrainingPoints")]
	[NotifyPropertyChangedFor("CanAfford")]
	[NotifyPropertyChangedFor("IsAtLevelCap")]
	private int _currentLevel;

	[ObservableProperty]
	private int _currentHP;

	[ObservableProperty]
	[NotifyPropertyChangedFor("RequiredGold")]
	[NotifyPropertyChangedFor("CanLevelUp")]
	[NotifyPropertyChangedFor("CanAfford")]
	private long _currentGold;

	[ObservableProperty]
	[NotifyPropertyChangedFor("CanConfirm")]
	private bool _hasUnsavedChanges;

	[ObservableProperty]
	[NotifyPropertyChangedFor("CanLevelUp")]
	[NotifyPropertyChangedFor("CanConfirm")]
	private bool _isProcessing = false;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? previewLevelUpCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? confirmLevelUpCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? cancelCommand;

	public long RequiredGold => (long)_spiritBusinessService.CalculateLevelUpCost(CurrentLevel);

	public int PreviewLevel => CurrentLevel + 1;

	public int PreviewHP => (int)Math.Round(100.0 * Math.Pow(1.045, (double)(PreviewLevel - 1)));

	public int PreviewTrainingPoints => _originalTrainingPoints + (CurrentLevel - _originalLevel + 1) * 10;

	public bool CanAfford => CurrentGold >= RequiredGold;

	public bool IsAtLevelCap => CurrentLevel >= _playerMaxLevel;

	public bool CanLevelUp => CurrentLevel < _playerMaxLevel && CurrentGold >= RequiredGold;

	public bool CanConfirm => HasUnsavedChanges && !IsProcessing;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int CurrentLevel
	{
		get
		{
			return _currentLevel;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_currentLevel, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentLevel);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.RequiredGold);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanLevelUp);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PreviewLevel);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PreviewHP);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PreviewTrainingPoints);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanAfford);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsAtLevelCap);
				_currentLevel = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentLevel);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.RequiredGold);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanLevelUp);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PreviewLevel);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PreviewHP);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PreviewTrainingPoints);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanAfford);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsAtLevelCap);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int CurrentHP
	{
		get
		{
			return _currentHP;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_currentHP, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentHP);
				_currentHP = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentHP);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public long CurrentGold
	{
		get
		{
			return _currentGold;
		}
		set
		{
			if (!EqualityComparer<long>.Default.Equals(_currentGold, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentGold);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.RequiredGold);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanLevelUp);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanAfford);
				_currentGold = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentGold);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.RequiredGold);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanLevelUp);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanAfford);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool HasUnsavedChanges
	{
		get
		{
			return _hasUnsavedChanges;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasUnsavedChanges, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasUnsavedChanges);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanConfirm);
				_hasUnsavedChanges = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasUnsavedChanges);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanConfirm);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsProcessing
	{
		get
		{
			return _isProcessing;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isProcessing, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsProcessing);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanLevelUp);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanConfirm);
				_isProcessing = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsProcessing);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanLevelUp);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanConfirm);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand PreviewLevelUpCommand
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			RelayCommand obj = previewLevelUpCommand;
			if (obj == null)
			{
				RelayCommand val = new RelayCommand(new Action(PreviewLevelUp));
				RelayCommand val2 = val;
				previewLevelUpCommand = val;
				obj = val2;
			}
			return (IRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ConfirmLevelUpCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = confirmLevelUpCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)ConfirmLevelUp);
				AsyncRelayCommand val2 = val;
				confirmLevelUpCommand = val;
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
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)Cancel);
				AsyncRelayCommand val2 = val;
				cancelCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public void SetSheet(BottomSheet sheet)
	{
		_sheet = sheet;
	}

	public LevelUpSheetViewModel(string spiritId, string spiritName, int currentLevel, int currentHP, int trainingPoints, IBottomSheetService bottomSheetService, IPlayerStateService stateService, INavigationService navigationService, ISpiritBusinessService spiritBusinessService, LevelUpSpiritUseCase levelUpUseCase)
	{
		_bottomSheetService = bottomSheetService;
		_stateService = stateService;
		_navigationService = navigationService;
		_spiritBusinessService = spiritBusinessService;
		_levelUpUseCase = levelUpUseCase;
		_spiritId = spiritId;
		_spiritName = spiritName;
		_originalLevel = currentLevel;
		_originalHP = currentHP;
		_originalTrainingPoints = trainingPoints;
		Player currentPlayer = _stateService.GetCurrentPlayer();
		_originalGold = currentPlayer?.Currencies["gold"] ?? 0;
		_playerMaxLevel = currentPlayer?.PlayerLevel ?? 1;
		_currentLevel = _originalLevel;
		_currentHP = currentHP;
		CurrentGold = _originalGold;
	}

	private void CheckForUnsavedChanges()
	{
		HasUnsavedChanges = CurrentLevel != _originalLevel || CurrentGold != _originalGold;
	}

	[RelayCommand]
	private void PreviewLevelUp()
	{
		if (!IsProcessing && CanLevelUp)
		{
			long requiredGold = RequiredGold;
			CurrentLevel++;
			CurrentGold -= requiredGold;
			CheckForUnsavedChanges();
		}
	}

	[AsyncStateMachine(typeof(_003CConfirmLevelUp_003Ed__38))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task ConfirmLevelUp()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CConfirmLevelUp_003Ed__38 _003CConfirmLevelUp_003Ed__ = new _003CConfirmLevelUp_003Ed__38();
		_003CConfirmLevelUp_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CConfirmLevelUp_003Ed__._003C_003E4__this = this;
		_003CConfirmLevelUp_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CConfirmLevelUp_003Ed__._003C_003Et__builder)).Start<_003CConfirmLevelUp_003Ed__38>(ref _003CConfirmLevelUp_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CConfirmLevelUp_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CCancel_003Ed__39))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Cancel()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CCancel_003Ed__39 _003CCancel_003Ed__ = new _003CCancel_003Ed__39();
		_003CCancel_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CCancel_003Ed__._003C_003E4__this = this;
		_003CCancel_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CCancel_003Ed__._003C_003Et__builder)).Start<_003CCancel_003Ed__39>(ref _003CCancel_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CCancel_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CDismissSheet_003Ed__40))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task DismissSheet()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CDismissSheet_003Ed__40 _003CDismissSheet_003Ed__ = new _003CDismissSheet_003Ed__40();
		_003CDismissSheet_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CDismissSheet_003Ed__._003C_003E4__this = this;
		_003CDismissSheet_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CDismissSheet_003Ed__._003C_003Et__builder)).Start<_003CDismissSheet_003Ed__40>(ref _003CDismissSheet_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CDismissSheet_003Ed__._003C_003Et__builder)).Task;
	}
}
