using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.Events;
using SpiritSummoner.Application.State;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Enums.Guilds;
using SpiritSummoner.Infrastructure.Contracts;

namespace SpiritSummoner.Presentation.Models;

public class PlayerInfoModel : ObservableObject, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003CInitializeAsync_003Ed__55 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PlayerInfoModel _003C_003E4__this;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			try
			{
				_003C_003E4__this._stateService.StateChanged -= _003C_003E4__this.OnStateChanged;
				_003C_003E4__this._regenerationService.CooldownTick -= _003C_003E4__this.OnCooldownTick;
				_003C_003E4__this.UpdateFromState();
				_003C_003E4__this._stateService.StateChanged += _003C_003E4__this.OnStateChanged;
				_003C_003E4__this._regenerationService.CooldownTick += _003C_003E4__this.OnCooldownTick;
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

	private readonly IPlayerStateService _stateService;

	private readonly IPlayerEnergyRegenerationService _regenerationService;

	private bool _disposed;

	[ObservableProperty]
	private string _playerId = string.Empty;

	[ObservableProperty]
	private string _playerName = string.Empty;

	[ObservableProperty]
	[NotifyPropertyChangedFor("ExpProgress")]
	[NotifyPropertyChangedFor("ExpByMax")]
	[NotifyPropertyChangedFor("BadgeImage")]
	private int _playerLevel;

	[ObservableProperty]
	[NotifyPropertyChangedFor("ExpProgress")]
	[NotifyPropertyChangedFor("ExpByMax")]
	private double _currentExp;

	[ObservableProperty]
	[NotifyPropertyChangedFor("ExpProgress")]
	[NotifyPropertyChangedFor("ExpByMax")]
	private double _maxExp;

	[ObservableProperty]
	[NotifyPropertyChangedFor("EpDisplay")]
	[NotifyPropertyChangedFor("EpProgress")]
	private int _energyPoints;

	[ObservableProperty]
	[NotifyPropertyChangedFor("EpDisplay")]
	[NotifyPropertyChangedFor("EpProgress")]
	private int _maxEnergyPoints;

	[ObservableProperty]
	[NotifyPropertyChangedFor("SpDisplay")]
	[NotifyPropertyChangedFor("SpProgress")]
	private int _battlePoints;

	[ObservableProperty]
	[NotifyPropertyChangedFor("SpDisplay")]
	[NotifyPropertyChangedFor("SpProgress")]
	private int _maxBattlePoints;

	[ObservableProperty]
	private string _epCooldown = string.Empty;

	[ObservableProperty]
	private string _spCooldown = string.Empty;

	[ObservableProperty]
	private long _gold;

	[ObservableProperty]
	private long _gems;

	[ObservableProperty]
	private long _guildCoins;

	[ObservableProperty]
	private Dictionary<string, List<string>>? _playerSquads;

	[ObservableProperty]
	private int _activeSquadSlot;

	[ObservableProperty]
	private string? _partnerSpiritId;

	[ObservableProperty]
	[NotifyPropertyChangedFor("WinLossRecord")]
	[NotifyPropertyChangedFor("WinRate")]
	private int _wins;

	[ObservableProperty]
	[NotifyPropertyChangedFor("WinLossRecord")]
	[NotifyPropertyChangedFor("WinRate")]
	private int _losses;

	[ObservableProperty]
	private string _title = "Novice";

	[ObservableProperty]
	private int _battleScore;

	[ObservableProperty]
	private string _guildId = string.Empty;

	[ObservableProperty]
	private GuildRole _guildRole;

	[ObservableProperty]
	private DateTimeOffset? _guildJoinedAt;

	[ObservableProperty]
	private bool _isAccountLinked;

	[ObservableProperty]
	private IReadOnlyDictionary<string, PlayerSpirit>? _playerSpirits;

	[ObservableProperty]
	private IReadOnlyDictionary<string, PlayerQuest>? _playerQuests;

	[ObservableProperty]
	private IReadOnlyDictionary<string, Inventory>? _playerInventory;

	[ObservableProperty]
	private global::System.Collections.Generic.IReadOnlyList<string> _viewedShopItems = global::System.Array.Empty<string>();

	[ObservableProperty]
	private int _lastShopViewedLevel = 1;

	[ObservableProperty]
	[NotifyPropertyChangedFor("HasIcon")]
	private string _icon = string.Empty;

	public bool HasIcon => !string.IsNullOrEmpty(_icon);

	public string WinLossRecord => $"{Wins}W - {Losses}L";

	public double WinRate => (Wins + Losses > 0) ? ((double)Wins / (double)(Wins + Losses) * 100.0) : 0.0;

	public double ExpProgress => (MaxExp > 0.0) ? (CurrentExp / MaxExp) : 0.0;

	public string ExpByMax => $"{CurrentExp:F0} / {MaxExp:F0}";

	public string EpDisplay => $"{EnergyPoints}/{MaxEnergyPoints}";

	public string SpDisplay => $"{BattlePoints}/{MaxBattlePoints}";

	public double EpProgress => (MaxEnergyPoints > 0) ? ((double)EnergyPoints / (double)MaxEnergyPoints) : 0.0;

	public double SpProgress => (MaxBattlePoints > 0) ? ((double)BattlePoints / (double)MaxBattlePoints) : 0.0;

	public string BadgeImage
	{
		get
		{
			if (PlayerLevel >= 80)
			{
				return "badge_adamantite.png";
			}
			if (PlayerLevel >= 60)
			{
				return "badge_mithril.png";
			}
			if (PlayerLevel >= 45)
			{
				return "badge_platinum.png";
			}
			if (PlayerLevel >= 30)
			{
				return "badge_gold.png";
			}
			if (PlayerLevel >= 15)
			{
				return "badge_silver.png";
			}
			return "badge_bronze.png";
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string PlayerId
	{
		get
		{
			return _playerId;
		}
		[MemberNotNull("_playerId")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_playerId, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PlayerId);
				_playerId = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PlayerId);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string PlayerName
	{
		get
		{
			return _playerName;
		}
		[MemberNotNull("_playerName")]
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
	public int PlayerLevel
	{
		get
		{
			return _playerLevel;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_playerLevel, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PlayerLevel);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ExpProgress);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ExpByMax);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.BadgeImage);
				_playerLevel = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PlayerLevel);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ExpProgress);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ExpByMax);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.BadgeImage);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public double CurrentExp
	{
		get
		{
			return _currentExp;
		}
		set
		{
			if (!EqualityComparer<double>.Default.Equals(_currentExp, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentExp);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ExpProgress);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ExpByMax);
				_currentExp = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentExp);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ExpProgress);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ExpByMax);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public double MaxExp
	{
		get
		{
			return _maxExp;
		}
		set
		{
			if (!EqualityComparer<double>.Default.Equals(_maxExp, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.MaxExp);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ExpProgress);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ExpByMax);
				_maxExp = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MaxExp);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ExpProgress);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ExpByMax);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int EnergyPoints
	{
		get
		{
			return _energyPoints;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_energyPoints, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.EnergyPoints);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.EpDisplay);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.EpProgress);
				_energyPoints = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.EnergyPoints);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.EpDisplay);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.EpProgress);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int MaxEnergyPoints
	{
		get
		{
			return _maxEnergyPoints;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_maxEnergyPoints, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.MaxEnergyPoints);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.EpDisplay);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.EpProgress);
				_maxEnergyPoints = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MaxEnergyPoints);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.EpDisplay);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.EpProgress);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int BattlePoints
	{
		get
		{
			return _battlePoints;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_battlePoints, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.BattlePoints);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SpDisplay);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SpProgress);
				_battlePoints = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.BattlePoints);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SpDisplay);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SpProgress);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int MaxBattlePoints
	{
		get
		{
			return _maxBattlePoints;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_maxBattlePoints, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.MaxBattlePoints);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SpDisplay);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SpProgress);
				_maxBattlePoints = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MaxBattlePoints);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SpDisplay);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SpProgress);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string EpCooldown
	{
		get
		{
			return _epCooldown;
		}
		[MemberNotNull("_epCooldown")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_epCooldown, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.EpCooldown);
				_epCooldown = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.EpCooldown);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string SpCooldown
	{
		get
		{
			return _spCooldown;
		}
		[MemberNotNull("_spCooldown")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_spCooldown, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SpCooldown);
				_spCooldown = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SpCooldown);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public long Gold
	{
		get
		{
			return _gold;
		}
		set
		{
			if (!EqualityComparer<long>.Default.Equals(_gold, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Gold);
				_gold = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Gold);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public long Gems
	{
		get
		{
			return _gems;
		}
		set
		{
			if (!EqualityComparer<long>.Default.Equals(_gems, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Gems);
				_gems = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Gems);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public long GuildCoins
	{
		get
		{
			return _guildCoins;
		}
		set
		{
			if (!EqualityComparer<long>.Default.Equals(_guildCoins, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.GuildCoins);
				_guildCoins = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.GuildCoins);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Dictionary<string, List<string>>? PlayerSquads
	{
		get
		{
			return _playerSquads;
		}
		set
		{
			if (!EqualityComparer<Dictionary<string, List<string>>>.Default.Equals(_playerSquads, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PlayerSquads);
				_playerSquads = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PlayerSquads);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int ActiveSquadSlot
	{
		get
		{
			return _activeSquadSlot;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_activeSquadSlot, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ActiveSquadSlot);
				_activeSquadSlot = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ActiveSquadSlot);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? PartnerSpiritId
	{
		get
		{
			return _partnerSpiritId;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_partnerSpiritId, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PartnerSpiritId);
				_partnerSpiritId = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PartnerSpiritId);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int Wins
	{
		get
		{
			return _wins;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_wins, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Wins);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.WinLossRecord);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.WinRate);
				_wins = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Wins);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.WinLossRecord);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.WinRate);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int Losses
	{
		get
		{
			return _losses;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_losses, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Losses);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.WinLossRecord);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.WinRate);
				_losses = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Losses);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.WinLossRecord);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.WinRate);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Title
	{
		get
		{
			return _title;
		}
		[MemberNotNull("_title")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_title, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Title);
				_title = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Title);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int BattleScore
	{
		get
		{
			return _battleScore;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_battleScore, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.BattleScore);
				_battleScore = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.BattleScore);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string GuildId
	{
		get
		{
			return _guildId;
		}
		[MemberNotNull("_guildId")]
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
	public GuildRole GuildRole
	{
		get
		{
			return _guildRole;
		}
		set
		{
			if (!EqualityComparer<GuildRole>.Default.Equals(_guildRole, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.GuildRole);
				_guildRole = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.GuildRole);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public DateTimeOffset? GuildJoinedAt
	{
		get
		{
			return _guildJoinedAt;
		}
		set
		{
			if (!EqualityComparer<DateTimeOffset?>.Default.Equals(_guildJoinedAt, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.GuildJoinedAt);
				_guildJoinedAt = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.GuildJoinedAt);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsAccountLinked
	{
		get
		{
			return _isAccountLinked;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isAccountLinked, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsAccountLinked);
				_isAccountLinked = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsAccountLinked);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IReadOnlyDictionary<string, PlayerSpirit>? PlayerSpirits
	{
		get
		{
			return _playerSpirits;
		}
		set
		{
			if (!EqualityComparer<IReadOnlyDictionary<string, PlayerSpirit>>.Default.Equals(_playerSpirits, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PlayerSpirits);
				_playerSpirits = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PlayerSpirits);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IReadOnlyDictionary<string, PlayerQuest>? PlayerQuests
	{
		get
		{
			return _playerQuests;
		}
		set
		{
			if (!EqualityComparer<IReadOnlyDictionary<string, PlayerQuest>>.Default.Equals(_playerQuests, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PlayerQuests);
				_playerQuests = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PlayerQuests);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IReadOnlyDictionary<string, Inventory>? PlayerInventory
	{
		get
		{
			return _playerInventory;
		}
		set
		{
			if (!EqualityComparer<IReadOnlyDictionary<string, Inventory>>.Default.Equals(_playerInventory, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PlayerInventory);
				_playerInventory = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PlayerInventory);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public global::System.Collections.Generic.IReadOnlyList<string> ViewedShopItems
	{
		get
		{
			return _viewedShopItems;
		}
		[MemberNotNull("_viewedShopItems")]
		set
		{
			if (!EqualityComparer<global::System.Collections.Generic.IReadOnlyList<string>>.Default.Equals(_viewedShopItems, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ViewedShopItems);
				_viewedShopItems = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ViewedShopItems);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int LastShopViewedLevel
	{
		get
		{
			return _lastShopViewedLevel;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_lastShopViewedLevel, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.LastShopViewedLevel);
				_lastShopViewedLevel = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.LastShopViewedLevel);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Icon
	{
		get
		{
			return _icon;
		}
		[MemberNotNull("_icon")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_icon, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Icon);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasIcon);
				_icon = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Icon);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasIcon);
			}
		}
	}

	public PlayerInfoModel(IPlayerStateService stateService, IPlayerEnergyRegenerationService regenerationService)
	{
		_stateService = stateService;
		_regenerationService = regenerationService;
	}

	[AsyncStateMachine(typeof(_003CInitializeAsync_003Ed__55))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task InitializeAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CInitializeAsync_003Ed__55 _003CInitializeAsync_003Ed__ = new _003CInitializeAsync_003Ed__55();
		_003CInitializeAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CInitializeAsync_003Ed__._003C_003E4__this = this;
		_003CInitializeAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CInitializeAsync_003Ed__._003C_003Et__builder)).Start<_003CInitializeAsync_003Ed__55>(ref _003CInitializeAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CInitializeAsync_003Ed__._003C_003Et__builder)).Task;
	}

	private void UpdateFromState()
	{
		Player currentPlayer = _stateService.GetCurrentPlayer();
		if (currentPlayer != null)
		{
			PlayerId = currentPlayer.PlayerID ?? string.Empty;
			PlayerName = currentPlayer.Playername ?? string.Empty;
			PlayerLevel = currentPlayer.PlayerLevel;
			CurrentExp = currentPlayer.EXP;
			MaxExp = currentPlayer.MaxEXP;
			EnergyPoints = currentPlayer.EP;
			MaxEnergyPoints = currentPlayer.MaxEP;
			BattlePoints = currentPlayer.SP;
			MaxBattlePoints = currentPlayer.MaxSP;
			Gold = CollectionExtensions.GetValueOrDefault<string, long>(currentPlayer.Currencies, "gold", 0L);
			Gems = CollectionExtensions.GetValueOrDefault<string, long>(currentPlayer.Currencies, "gems", 0L);
			GuildCoins = CollectionExtensions.GetValueOrDefault<string, long>(currentPlayer.Currencies, "guildCoins", 0L);
			PlayerSquads = Enumerable.ToDictionary<KeyValuePair<string, List<string>>, string, List<string>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, List<string>>>)currentPlayer.Squads, (Func<KeyValuePair<string, List<string>>, string>)((KeyValuePair<string, List<string>> entry) => entry.Key), (Func<KeyValuePair<string, List<string>>, List<string>>)((KeyValuePair<string, List<string>> entry) => Enumerable.ToList<string>((global::System.Collections.Generic.IEnumerable<string>)entry.Value)));
			ActiveSquadSlot = currentPlayer.ActiveSquadSlot;
			PartnerSpiritId = currentPlayer.PartnerSpiritId;
			Wins = currentPlayer.BattleStats?.Wins ?? 0;
			Losses = currentPlayer.BattleStats?.Losses ?? 0;
			Title = currentPlayer.BattleStats?.Title ?? "Novice";
			BattleScore = currentPlayer.BattleStats?.Score ?? 0;
			GuildId = currentPlayer.GuildId ?? string.Empty;
			GuildRole = currentPlayer.GuildRole;
			GuildJoinedAt = currentPlayer.GuildJoinedAt;
			IsAccountLinked = currentPlayer.IsAccountLinked;
			Icon = currentPlayer.PlayerIcon ?? string.Empty;
			PlayerSpirits = currentPlayer.PlayerSpirits;
			PlayerQuests = currentPlayer.PlayerQuests;
			PlayerInventory = currentPlayer.Inventory;
			ViewedShopItems = currentPlayer.ViewedShopItems;
			LastShopViewedLevel = currentPlayer.LastShopViewedLevel;
		}
	}

	private void OnStateChanged(object? sender, StateChangedEventArgs e)
	{
		//IL_06b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cd: Unknown result type (might be due to invalid IL or missing references)
		if (e.Scope == StateChangeScope.Spirit)
		{
			Player currentPlayer = _stateService.GetCurrentPlayer();
			if (currentPlayer != null)
			{
				PlayerSpirits = currentPlayer.PlayerSpirits;
			}
		}
		else
		{
			if (e.Scope != 0)
			{
				return;
			}
			string changeType = e.ChangeType;
			string text = changeType;
			switch (_003CPrivateImplementationDetails_003E.ComputeStringHash(text))
			{
			case 2543512253u:
				if (text == "SessionStart")
				{
					UpdateFromState();
				}
				break;
			case 1366952894u:
				if (text == "Currencies")
				{
					IReadOnlyDictionary<string, long> val2 = CollectionExtensions.GetValueOrDefault<string, object>(e.ChangedValues, "currencies") as IReadOnlyDictionary<string, long>;
					Gold = ((val2 != null) ? CollectionExtensions.GetValueOrDefault<string, long>(val2, "gold", 0L) : 0);
					Gems = ((val2 != null) ? CollectionExtensions.GetValueOrDefault<string, long>(val2, "gems", 0L) : 0);
					GuildCoins = ((val2 != null) ? CollectionExtensions.GetValueOrDefault<string, long>(val2, "guildCoins", 0L) : 0);
				}
				break;
			case 2900596553u:
				if (text == "Experience")
				{
					CurrentExp = (double)e.ChangedValues["exp"];
				}
				break;
			case 2865623320u:
				if (text == "LevelUp")
				{
					PlayerLevel = (int)e.ChangedValues["level"];
					CurrentExp = (double)e.ChangedValues["exp"];
					MaxExp = (double)e.ChangedValues["maxExp"];
					MaxEnergyPoints = (int)e.ChangedValues["maxEp"];
					EnergyPoints = (int)e.ChangedValues["ep"];
					MaxBattlePoints = (int)e.ChangedValues["maxSp"];
					BattlePoints = (int)e.ChangedValues["sp"];
				}
				break;
			case 388468149u:
				if (text == "Energy")
				{
					EnergyPoints = (int)e.ChangedValues["ep"];
					BattlePoints = (int)e.ChangedValues["sp"];
				}
				break;
			case 2142907034u:
				if (text == "BattleStats")
				{
					object obj4 = default(object);
					if (e.ChangedValues.TryGetValue("title", ref obj4))
					{
						Title = obj4?.ToString() ?? "Novice";
					}
					object obj5 = default(object);
					if (e.ChangedValues.TryGetValue("wins", ref obj5))
					{
						Wins = Convert.ToInt32(obj5);
					}
					object obj6 = default(object);
					if (e.ChangedValues.TryGetValue("losses", ref obj6))
					{
						Losses = Convert.ToInt32(obj6);
					}
					object obj7 = default(object);
					if (e.ChangedValues.TryGetValue("score", ref obj7))
					{
						BattleScore = Convert.ToInt32(obj7);
					}
				}
				break;
			case 4219141457u:
			{
				if (!(text == "Squad"))
				{
					break;
				}
				object obj = default(object);
				if (e.ChangedValues.TryGetValue("squads", ref obj) && obj is IReadOnlyDictionary<string, List<string>> val)
				{
					PlayerSquads = Enumerable.ToDictionary<KeyValuePair<string, List<string>>, string, List<string>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, List<string>>>)val, (Func<KeyValuePair<string, List<string>>, string>)((KeyValuePair<string, List<string>> entry) => entry.Key), (Func<KeyValuePair<string, List<string>>, List<string>>)((KeyValuePair<string, List<string>> entry) => Enumerable.ToList<string>((global::System.Collections.Generic.IEnumerable<string>)entry.Value)));
				}
				object obj2 = default(object);
				if (e.ChangedValues.TryGetValue("activeSquadSlot", ref obj2) && obj2 is int activeSquadSlot)
				{
					ActiveSquadSlot = activeSquadSlot;
				}
				break;
			}
			case 380798809u:
				if (text == "Partner")
				{
					PartnerSpiritId = CollectionExtensions.GetValueOrDefault<string, object>(e.ChangedValues, "battleUnitSpiritId")?.ToString() ?? string.Empty;
				}
				break;
			case 3369262303u:
				if (text == "Inventory")
				{
					object obj8 = default(object);
					if (e.ChangedValues.TryGetValue("inventory", ref obj8) && obj8 is IReadOnlyDictionary<string, Inventory> playerInventory)
					{
						PlayerInventory = playerInventory;
					}
					Player currentPlayer3 = _stateService.GetCurrentPlayer();
					if (currentPlayer3 != null)
					{
						ViewedShopItems = currentPlayer3.ViewedShopItems;
						LastShopViewedLevel = currentPlayer3.LastShopViewedLevel;
					}
				}
				break;
			case 130666986u:
				if (text == "Quests")
				{
					Player currentPlayer2 = _stateService.GetCurrentPlayer();
					if (currentPlayer2 != null)
					{
						PlayerQuests = currentPlayer2.PlayerQuests;
					}
				}
				break;
			case 915960032u:
				if (text == "Guild")
				{
					GuildId = CollectionExtensions.GetValueOrDefault<string, object>(e.ChangedValues, "guildId")?.ToString() ?? string.Empty;
					object obj9 = default(object);
					if (e.ChangedValues.TryGetValue("guildRole", ref obj9) && obj9 is GuildRole guildRole)
					{
						GuildRole = guildRole;
					}
					object obj10 = default(object);
					if (e.ChangedValues.TryGetValue("guildJoinedAt", ref obj10) && obj10 is DateTimeOffset val3)
					{
						GuildJoinedAt = val3;
					}
				}
				break;
			case 148751709u:
			{
				object obj3 = default(object);
				if (text == "AccountLinked" && e.ChangedValues.TryGetValue("isAccountLinked", ref obj3) && obj3 is bool isAccountLinked)
				{
					IsAccountLinked = isAccountLinked;
				}
				break;
			}
			case 154136769u:
				if (text == "PlayerIcon")
				{
					Icon = CollectionExtensions.GetValueOrDefault<string, object>(e.ChangedValues, "icon")?.ToString() ?? string.Empty;
				}
				break;
			}
		}
	}

	private void OnCooldownTick(object? sender, RegenerationCooldownEventArgs e)
	{
		EpCooldown = e.EpCooldown;
		SpCooldown = e.SpCooldown;
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			_stateService.StateChanged -= OnStateChanged;
			_regenerationService.CooldownTick -= OnCooldownTick;
			_disposed = true;
			GC.SuppressFinalize((object)this);
		}
	}
}
