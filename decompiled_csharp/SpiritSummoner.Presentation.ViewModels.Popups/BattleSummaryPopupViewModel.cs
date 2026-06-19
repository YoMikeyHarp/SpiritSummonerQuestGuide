using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using SpiritSummoner.Infrastructure.Diagnostics;

namespace SpiritSummoner.Presentation.ViewModels.Popups;

public class BattleSummaryPopupViewModel : ObservableObject
{
	[CompilerGenerated]
	private sealed class _003CTapToExit_003Ed__25 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleSummaryPopupViewModel _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0 || !_003C_003E4__this.IsClosing)
				{
					try
					{
						TaskAwaiter awaiter;
						if (num != 0)
						{
							_003C_003E4__this.IsClosing = true;
							awaiter = _003C_003E4__this._popupService.ClosePopupAsync((object)false).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CTapToExit_003Ed__25 _003CTapToExit_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CTapToExit_003Ed__25>(ref awaiter, ref _003CTapToExit_003Ed__);
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
						Console.WriteLine("Error closing popup: " + _003Cex_003E5__1.Message);
						_003C_003E4__this.IsClosing = false;
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsClosing = false;
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
	private sealed class _003CViewBattleLog_003Ed__24 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleSummaryPopupViewModel _003C_003E4__this;

		private TaskAwaiter<object?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<object> awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._popupService.ShowPopupAsync<BattleDebugLogPopupViewModel>(default(CancellationToken)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CViewBattleLog_003Ed__24 _003CViewBattleLog_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CViewBattleLog_003Ed__24>(ref awaiter, ref _003CViewBattleLog_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<object>);
					num = (_003C_003E1__state = -1);
				}
				awaiter.GetResult();
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

	private readonly IPopupService _popupService;

	[ObservableProperty]
	public List<SpriteModelResultsRecord> _playerSpirits;

	[ObservableProperty]
	public List<SpriteModelResultsRecord> _enemySpirits;

	[ObservableProperty]
	public string? _outcomeText;

	[ObservableProperty]
	public string? _outcomeImagePlayer;

	[ObservableProperty]
	public string? _outcomeImageEnemy;

	[ObservableProperty]
	private long _earnedGold;

	[ObservableProperty]
	private int _earnedEXP;

	[ObservableProperty]
	private long _earnedReputation;

	[ObservableProperty]
	private int _scoreChange;

	[ObservableProperty]
	public string? _playerName;

	[ObservableProperty]
	public string? _playerGuildName;

	[ObservableProperty]
	public string? _enemyName;

	[ObservableProperty]
	public string? _enemyGuildname;

	[ObservableProperty]
	public int _playerRank;

	[ObservableProperty]
	public int _enemyRank;

	[ObservableProperty]
	public Brush _backGround;

	[ObservableProperty]
	public Color _textColor;

	[ObservableProperty]
	public bool _hasRewards;

	[ObservableProperty]
	public bool _isGuildBattle;

	public bool IsClosing;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? viewBattleLogCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? tapToExitCommand;

	public bool IsBattleLogAvailable => BattleLogCapture.Instance.HasEntries;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public List<SpriteModelResultsRecord> PlayerSpirits
	{
		get
		{
			return _playerSpirits;
		}
		[MemberNotNull("_playerSpirits")]
		set
		{
			if (!EqualityComparer<List<SpriteModelResultsRecord>>.Default.Equals(_playerSpirits, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PlayerSpirits);
				_playerSpirits = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PlayerSpirits);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public List<SpriteModelResultsRecord> EnemySpirits
	{
		get
		{
			return _enemySpirits;
		}
		[MemberNotNull("_enemySpirits")]
		set
		{
			if (!EqualityComparer<List<SpriteModelResultsRecord>>.Default.Equals(_enemySpirits, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.EnemySpirits);
				_enemySpirits = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.EnemySpirits);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? OutcomeText
	{
		get
		{
			return _outcomeText;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_outcomeText, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.OutcomeText);
				_outcomeText = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.OutcomeText);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? OutcomeImagePlayer
	{
		get
		{
			return _outcomeImagePlayer;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_outcomeImagePlayer, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.OutcomeImagePlayer);
				_outcomeImagePlayer = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.OutcomeImagePlayer);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? OutcomeImageEnemy
	{
		get
		{
			return _outcomeImageEnemy;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_outcomeImageEnemy, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.OutcomeImageEnemy);
				_outcomeImageEnemy = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.OutcomeImageEnemy);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public long EarnedGold
	{
		get
		{
			return _earnedGold;
		}
		set
		{
			if (!EqualityComparer<long>.Default.Equals(_earnedGold, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.EarnedGold);
				_earnedGold = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.EarnedGold);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int EarnedEXP
	{
		get
		{
			return _earnedEXP;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_earnedEXP, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.EarnedEXP);
				_earnedEXP = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.EarnedEXP);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public long EarnedReputation
	{
		get
		{
			return _earnedReputation;
		}
		set
		{
			if (!EqualityComparer<long>.Default.Equals(_earnedReputation, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.EarnedReputation);
				_earnedReputation = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.EarnedReputation);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int ScoreChange
	{
		get
		{
			return _scoreChange;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_scoreChange, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ScoreChange);
				_scoreChange = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ScoreChange);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? PlayerName
	{
		get
		{
			return _playerName;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_playerName, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PlayerName);
				_playerName = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PlayerName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? PlayerGuildName
	{
		get
		{
			return _playerGuildName;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_playerGuildName, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PlayerGuildName);
				_playerGuildName = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PlayerGuildName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? EnemyName
	{
		get
		{
			return _enemyName;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_enemyName, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.EnemyName);
				_enemyName = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.EnemyName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? EnemyGuildname
	{
		get
		{
			return _enemyGuildname;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_enemyGuildname, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.EnemyGuildname);
				_enemyGuildname = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.EnemyGuildname);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int PlayerRank
	{
		get
		{
			return _playerRank;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_playerRank, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PlayerRank);
				_playerRank = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PlayerRank);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int EnemyRank
	{
		get
		{
			return _enemyRank;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_enemyRank, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.EnemyRank);
				_enemyRank = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.EnemyRank);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Brush BackGround
	{
		get
		{
			return _backGround;
		}
		[MemberNotNull("_backGround")]
		set
		{
			if (!EqualityComparer<Brush>.Default.Equals(_backGround, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.BackGround);
				_backGround = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.BackGround);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Color TextColor
	{
		get
		{
			return _textColor;
		}
		[MemberNotNull("_textColor")]
		set
		{
			if (!EqualityComparer<Color>.Default.Equals(_textColor, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TextColor);
				_textColor = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TextColor);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool HasRewards
	{
		get
		{
			return _hasRewards;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasRewards, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasRewards);
				_hasRewards = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasRewards);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsGuildBattle
	{
		get
		{
			return _isGuildBattle;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isGuildBattle, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsGuildBattle);
				_isGuildBattle = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsGuildBattle);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ViewBattleLogCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = viewBattleLogCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)ViewBattleLog);
				AsyncRelayCommand val2 = val;
				viewBattleLogCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand TapToExitCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = tapToExitCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)TapToExit);
				AsyncRelayCommand val2 = val;
				tapToExitCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public BattleSummaryPopupViewModel(IPopupService popupService)
	{
		_popupService = popupService;
		_playerSpirits = new List<SpriteModelResultsRecord>();
		_enemySpirits = new List<SpriteModelResultsRecord>();
		_hasRewards = true;
		_isGuildBattle = true;
		IsClosing = false;
		((ObservableObject)this)._002Ector();
	}

	[AsyncStateMachine(typeof(_003CViewBattleLog_003Ed__24))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task ViewBattleLog()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CViewBattleLog_003Ed__24 _003CViewBattleLog_003Ed__ = new _003CViewBattleLog_003Ed__24();
		_003CViewBattleLog_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CViewBattleLog_003Ed__._003C_003E4__this = this;
		_003CViewBattleLog_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CViewBattleLog_003Ed__._003C_003Et__builder)).Start<_003CViewBattleLog_003Ed__24>(ref _003CViewBattleLog_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CViewBattleLog_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CTapToExit_003Ed__25))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task TapToExit()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CTapToExit_003Ed__25 _003CTapToExit_003Ed__ = new _003CTapToExit_003Ed__25();
		_003CTapToExit_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CTapToExit_003Ed__._003C_003E4__this = this;
		_003CTapToExit_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CTapToExit_003Ed__._003C_003Et__builder)).Start<_003CTapToExit_003Ed__25>(ref _003CTapToExit_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CTapToExit_003Ed__._003C_003Et__builder)).Task;
	}
}
