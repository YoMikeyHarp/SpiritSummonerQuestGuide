using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using SpiritSummoner.Domain.Enums.Guilds;

namespace SpiritSummoner.Domain.Entities.Players;

public class Player
{
	private Dictionary<string, long> _currencies;

	private Dictionary<string, PlayerQuest> _playerQuests;

	private Dictionary<string, List<string>> _squads;

	private Dictionary<string, PlayerSpirit> _playerSpirits;

	private Dictionary<string, Inventory> _inventory;

	private List<string> _viewedShopItems;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? PlayerID
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Playername
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? PlayerPassword
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int PlayerLevel
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public double EXP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public double MaxEXP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int EP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int MaxEP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int SP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int MaxSP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	public IReadOnlyDictionary<string, long> Currencies => (IReadOnlyDictionary<string, long>)(object)_currencies;

	public IReadOnlyDictionary<string, PlayerQuest> PlayerQuests => (IReadOnlyDictionary<string, PlayerQuest>)(object)_playerQuests;

	public IReadOnlyDictionary<string, List<string>> Squads => (IReadOnlyDictionary<string, List<string>>)(object)_squads;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int ActiveSquadSlot
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	public global::System.Collections.Generic.IReadOnlyList<string> ActiveSquad => (global::System.Collections.Generic.IReadOnlyList<string>)_squads[ActiveSquadSlot.ToString()];

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string PartnerSpiritId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	public IReadOnlyDictionary<string, PlayerSpirit> PlayerSpirits => (IReadOnlyDictionary<string, PlayerSpirit>)(object)_playerSpirits;

	public IReadOnlyDictionary<string, Inventory> Inventory => (IReadOnlyDictionary<string, Inventory>)(object)_inventory;

	public global::System.Collections.Generic.IReadOnlyList<string> ViewedShopItems => (global::System.Collections.Generic.IReadOnlyList<string>)_viewedShopItems.AsReadOnly();

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int LastShopViewedLevel
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public BattleStats BattleStats
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset? LastEpRegenTime
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset? LastSpRegenTime
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? GuildId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public GuildRole GuildRole
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset? GuildJoinedAt
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DailyBattleChest DailyBattleChest
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsAccountLinked
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? PlayerIcon
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	public Player()
	{
		Dictionary<string, long> obj = new Dictionary<string, long>();
		obj.Add("gold", 0L);
		_currencies = obj;
		_playerQuests = new Dictionary<string, PlayerQuest>();
		Dictionary<string, List<string>> obj2 = new Dictionary<string, List<string>>();
		List<string> obj3 = new List<string>();
		obj3.Add("");
		obj3.Add("");
		obj3.Add("");
		obj2.Add("1", obj3);
		List<string> obj4 = new List<string>();
		obj4.Add("");
		obj4.Add("");
		obj4.Add("");
		obj2.Add("2", obj4);
		List<string> obj5 = new List<string>();
		obj5.Add("");
		obj5.Add("");
		obj5.Add("");
		obj2.Add("3", obj5);
		List<string> obj6 = new List<string>();
		obj6.Add("");
		obj6.Add("");
		obj6.Add("");
		obj2.Add("4", obj6);
		List<string> obj7 = new List<string>();
		obj7.Add("");
		obj7.Add("");
		obj7.Add("");
		obj2.Add("5", obj7);
		_squads = obj2;
		ActiveSquadSlot = 1;
		PartnerSpiritId = string.Empty;
		_playerSpirits = new Dictionary<string, PlayerSpirit>();
		_inventory = new Dictionary<string, Inventory>();
		_viewedShopItems = new List<string>();
		LastShopViewedLevel = 1;
		BattleStats = new BattleStats();
		DailyBattleChest = new DailyBattleChest();
		IsAccountLinked = false;
		base._002Ector();
	}

	public Player(Player originalPlayer)
	{
		Dictionary<string, long> obj = new Dictionary<string, long>();
		obj.Add("gold", 0L);
		_currencies = obj;
		_playerQuests = new Dictionary<string, PlayerQuest>();
		Dictionary<string, List<string>> obj2 = new Dictionary<string, List<string>>();
		List<string> obj3 = new List<string>();
		obj3.Add("");
		obj3.Add("");
		obj3.Add("");
		obj2.Add("1", obj3);
		List<string> obj4 = new List<string>();
		obj4.Add("");
		obj4.Add("");
		obj4.Add("");
		obj2.Add("2", obj4);
		List<string> obj5 = new List<string>();
		obj5.Add("");
		obj5.Add("");
		obj5.Add("");
		obj2.Add("3", obj5);
		List<string> obj6 = new List<string>();
		obj6.Add("");
		obj6.Add("");
		obj6.Add("");
		obj2.Add("4", obj6);
		List<string> obj7 = new List<string>();
		obj7.Add("");
		obj7.Add("");
		obj7.Add("");
		obj2.Add("5", obj7);
		_squads = obj2;
		ActiveSquadSlot = 1;
		PartnerSpiritId = string.Empty;
		_playerSpirits = new Dictionary<string, PlayerSpirit>();
		_inventory = new Dictionary<string, Inventory>();
		_viewedShopItems = new List<string>();
		LastShopViewedLevel = 1;
		BattleStats = new BattleStats();
		DailyBattleChest = new DailyBattleChest();
		IsAccountLinked = false;
		base._002Ector();
		PlayerID = originalPlayer.PlayerID;
		Playername = originalPlayer.Playername;
		PlayerPassword = originalPlayer.PlayerPassword;
		PlayerLevel = originalPlayer.PlayerLevel;
		EXP = originalPlayer.EXP;
		MaxEXP = originalPlayer.MaxEXP;
		EP = originalPlayer.EP;
		MaxEP = originalPlayer.MaxEP;
		SP = originalPlayer.SP;
		MaxSP = originalPlayer.MaxSP;
		IReadOnlyDictionary<string, long> currencies = originalPlayer.Currencies;
		_currencies = ((currencies != null) ? Enumerable.ToDictionary<KeyValuePair<string, long>, string, long>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, long>>)currencies, (Func<KeyValuePair<string, long>, string>)((KeyValuePair<string, long> kv) => kv.Key), (Func<KeyValuePair<string, long>, long>)((KeyValuePair<string, long> kv) => kv.Value)) : null) ?? new Dictionary<string, long>();
		_playerQuests = new Dictionary<string, PlayerQuest>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, PlayerQuest>>)originalPlayer.PlayerQuests);
		PartnerSpiritId = originalPlayer.PartnerSpiritId;
		ActiveSquadSlot = originalPlayer.ActiveSquadSlot;
		_squads = Enumerable.ToDictionary<KeyValuePair<string, List<string>>, string, List<string>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, List<string>>>)originalPlayer.Squads, (Func<KeyValuePair<string, List<string>>, string>)((KeyValuePair<string, List<string>> kv) => kv.Key), (Func<KeyValuePair<string, List<string>>, List<string>>)((KeyValuePair<string, List<string>> kv) => new List<string>((global::System.Collections.Generic.IEnumerable<string>)kv.Value)));
		_playerSpirits = Enumerable.ToDictionary<KeyValuePair<string, PlayerSpirit>, string, PlayerSpirit>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, PlayerSpirit>>)originalPlayer.PlayerSpirits, (Func<KeyValuePair<string, PlayerSpirit>, string>)((KeyValuePair<string, PlayerSpirit> kvp) => kvp.Key), (Func<KeyValuePair<string, PlayerSpirit>, PlayerSpirit>)((KeyValuePair<string, PlayerSpirit> kvp) => new PlayerSpirit(kvp.Value)));
		_inventory = new Dictionary<string, Inventory>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, Inventory>>)originalPlayer.Inventory);
		_viewedShopItems = new List<string>((global::System.Collections.Generic.IEnumerable<string>)originalPlayer.ViewedShopItems);
		LastShopViewedLevel = originalPlayer.LastShopViewedLevel;
		BattleStats = originalPlayer.BattleStats;
		GuildId = originalPlayer.GuildId;
		GuildRole = originalPlayer.GuildRole;
		GuildJoinedAt = originalPlayer.GuildJoinedAt;
		LastEpRegenTime = originalPlayer.LastEpRegenTime;
		LastSpRegenTime = originalPlayer.LastSpRegenTime;
		DailyBattleChest = originalPlayer.DailyBattleChest;
		IsAccountLinked = originalPlayer.IsAccountLinked;
		PlayerIcon = originalPlayer.PlayerIcon;
	}

	public static Player Rehydrate(string? playerId, string? playerName, int? playerLevel, double? exp, double? maxExp, int? ep, int? maxEp, int? sp, int? maxSp, Dictionary<string, long>? currencies, Dictionary<string, PlayerQuest>? playerQuests, Dictionary<string, List<string>>? squads, int? activeSquadSlot, string? partnerSpiritId, Dictionary<string, PlayerSpirit>? playerSpirits, Dictionary<string, Inventory>? inventory, List<string>? viewedShopItems, int? lastShopViewedLevel, BattleStats? battleStats, DateTimeOffset? lastEpRegenTime, DateTimeOffset? lastSpRegenTime, string? guildId, GuildRole? guildRole, DateTimeOffset? guildJoinedAt, bool? isAccountLinked = null, DailyBattleChest? dailyBattleChest = null, string? playerIcon = null)
	{
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		Player player = new Player();
		if (playerId != null)
		{
			player.PlayerID = playerId;
		}
		if (playerName != null)
		{
			player.Playername = playerName;
		}
		if (playerLevel.HasValue)
		{
			player.PlayerLevel = playerLevel.Value;
		}
		if (exp.HasValue)
		{
			player.EXP = exp.Value;
		}
		if (maxExp.HasValue)
		{
			player.MaxEXP = maxExp.Value;
		}
		if (ep.HasValue)
		{
			player.EP = ep.Value;
		}
		if (maxEp.HasValue)
		{
			player.MaxEP = maxEp.Value;
		}
		if (sp.HasValue)
		{
			player.SP = sp.Value;
		}
		if (maxSp.HasValue)
		{
			player.MaxSP = maxSp.Value;
		}
		if (currencies != null)
		{
			player._currencies = new Dictionary<string, long>((IDictionary<string, long>)(object)currencies);
		}
		if (playerQuests != null)
		{
			player._playerQuests = new Dictionary<string, PlayerQuest>((IDictionary<string, PlayerQuest>)(object)playerQuests);
		}
		if (squads != null)
		{
			player._squads = Enumerable.ToDictionary<KeyValuePair<string, List<string>>, string, List<string>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, List<string>>>)squads, (Func<KeyValuePair<string, List<string>>, string>)((KeyValuePair<string, List<string>> kvp) => kvp.Key), (Func<KeyValuePair<string, List<string>>, List<string>>)((KeyValuePair<string, List<string>> kvp) => new List<string>((global::System.Collections.Generic.IEnumerable<string>)kvp.Value)));
		}
		if (activeSquadSlot.HasValue && player._squads.ContainsKey(activeSquadSlot.Value.ToString()))
		{
			player.ActiveSquadSlot = activeSquadSlot.Value;
		}
		if (partnerSpiritId != null)
		{
			player.PartnerSpiritId = partnerSpiritId;
		}
		if (playerSpirits != null)
		{
			player._playerSpirits = new Dictionary<string, PlayerSpirit>((IDictionary<string, PlayerSpirit>)(object)playerSpirits);
		}
		if (inventory != null)
		{
			player._inventory = new Dictionary<string, Inventory>((IDictionary<string, Inventory>)(object)inventory);
		}
		if (viewedShopItems != null)
		{
			player._viewedShopItems = new List<string>((global::System.Collections.Generic.IEnumerable<string>)viewedShopItems);
		}
		if (lastShopViewedLevel.HasValue)
		{
			player.LastShopViewedLevel = lastShopViewedLevel.Value;
		}
		if (battleStats != null)
		{
			player.BattleStats = battleStats;
		}
		player.LastEpRegenTime = lastEpRegenTime;
		player.LastSpRegenTime = lastSpRegenTime;
		if (guildId != null)
		{
			player.GuildId = guildId;
		}
		if (guildRole.HasValue)
		{
			player.GuildRole = guildRole.Value;
		}
		if (guildJoinedAt.HasValue)
		{
			player.GuildJoinedAt = guildJoinedAt.Value;
		}
		if (isAccountLinked.HasValue)
		{
			player.IsAccountLinked = isAccountLinked.Value;
		}
		if (dailyBattleChest != null)
		{
			player.DailyBattleChest = dailyBattleChest;
		}
		if (playerIcon != null)
		{
			player.PlayerIcon = playerIcon;
		}
		return player;
	}

	internal void SetLevel(int level)
	{
		PlayerLevel = level;
	}

	internal void SetExperience(double exp)
	{
		EXP = Math.Max(0.0, exp);
	}

	internal void SetMaxEXP(double maxExp)
	{
		MaxEXP = maxExp;
	}

	internal void SetEP(int value)
	{
		EP = Math.Max(0, Math.Min(value, MaxEP));
	}

	internal void SetMaxEP(int value)
	{
		MaxEP = value;
	}

	internal void SetSP(int value)
	{
		SP = Math.Max(0, Math.Min(value, MaxSP));
	}

	internal void SetMaxSP(int value)
	{
		MaxSP = value;
	}

	internal void AddCurrency(string currencyType, long amount)
	{
		if (!_currencies.ContainsKey(currencyType))
		{
			_currencies[currencyType] = 0L;
		}
		_currencies[currencyType] = Math.Max(0L, _currencies[currencyType] + amount);
	}

	internal void SetCurrency(string currencyType, long value)
	{
		_currencies[currencyType] = Math.Max(0L, value);
	}

	internal void AddSpirit(PlayerSpirit spirit)
	{
		ArgumentNullException.ThrowIfNull((object)spirit, "spirit");
		_playerSpirits[spirit.PlayerSpiritID] = spirit;
	}

	internal void RemoveSpirit(string spiritId)
	{
		_playerSpirits.Remove(spiritId);
	}

	internal PlayerSpirit? GetSpirit(string spiritId)
	{
		PlayerSpirit playerSpirit = default(PlayerSpirit);
		return _playerSpirits.TryGetValue(spiritId, ref playerSpirit) ? playerSpirit : null;
	}

	internal void RemoveInventoryItem(string itemName)
	{
		_inventory.Remove(itemName);
	}

	internal void AddInventoryItem(string itemName, int amount)
	{
		if (!_inventory.ContainsKey(itemName))
		{
			_inventory[itemName] = new Inventory
			{
				Name = itemName,
				Amount = 0
			};
		}
		_inventory[itemName].Amount = Math.Max(0, _inventory[itemName].Amount + amount);
	}

	internal void SetInventoryAmount(string itemName, int amount)
	{
		if (!_inventory.ContainsKey(itemName))
		{
			_inventory[itemName] = new Inventory
			{
				Name = itemName,
				Amount = 0
			};
		}
		_inventory[itemName].Amount = Math.Max(0, amount);
	}

	internal bool HasInventoryItem(string itemName, int requiredAmount = 1)
	{
		Inventory inventory = default(Inventory);
		return _inventory.TryGetValue(itemName, ref inventory) && inventory.Amount >= requiredAmount;
	}

	internal void SetActiveSquadSlot(int slot)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		if (slot < 1 || slot > 5)
		{
			throw new ArgumentOutOfRangeException("slot", "Squad slot must be between 1 and 5");
		}
		ActiveSquadSlot = slot;
	}

	internal void SetPartnerSpirit(string spiritId)
	{
		PartnerSpiritId = spiritId ?? string.Empty;
	}

	internal void IncrementWins()
	{
		BattleStats.IncrementWins();
	}

	internal void IncrementLosses()
	{
		BattleStats.IncrementLosses();
	}

	internal void DecrementLosses()
	{
		BattleStats.DecrementLosses();
	}

	internal void SetGuildInfo(string? guildId, GuildRole role, DateTimeOffset? joinedAt)
	{
		GuildId = guildId;
		GuildRole = role;
		GuildJoinedAt = joinedAt;
	}

	internal void SetGuildInfo(string? guildId, GuildRole role)
	{
		GuildId = guildId;
		GuildRole = role;
	}

	internal void SetLastEpRegenTime(DateTimeOffset? time)
	{
		LastEpRegenTime = time;
	}

	internal void SetLastSpRegenTime(DateTimeOffset? time)
	{
		LastSpRegenTime = time;
	}

	internal void SetPlayerID(string? playerId)
	{
		PlayerID = playerId;
	}

	internal void SetPlayername(string? playername)
	{
		Playername = playername;
	}

	internal void SetPlayerPassword(string? password)
	{
		PlayerPassword = password;
	}

	internal void SetSquads(Dictionary<string, List<string>> squads)
	{
		ArgumentNullException.ThrowIfNull((object)squads, "squads");
		_squads = squads;
	}

	internal void SetViewedShopItems(List<string> items)
	{
		ArgumentNullException.ThrowIfNull((object)items, "items");
		_viewedShopItems = items;
	}

	internal void AddViewedShopItem(string itemId)
	{
		if (!string.IsNullOrEmpty(itemId) && !_viewedShopItems.Contains(itemId))
		{
			_viewedShopItems.Add(itemId);
		}
	}

	internal void SetLastShopViewedLevel(int level)
	{
		LastShopViewedLevel = level;
	}

	internal void SetInventory(Dictionary<string, Inventory> inventory)
	{
		ArgumentNullException.ThrowIfNull((object)inventory, "inventory");
		_inventory = inventory;
	}

	internal void SetPlayerSpirits(Dictionary<string, PlayerSpirit> spirits)
	{
		ArgumentNullException.ThrowIfNull((object)spirits, "spirits");
		_playerSpirits = spirits;
	}

	internal void SetPlayerQuests(Dictionary<string, PlayerQuest> quests)
	{
		ArgumentNullException.ThrowIfNull((object)quests, "quests");
		_playerQuests = quests;
	}

	internal void SetCurrencies(Dictionary<string, long> currencies)
	{
		ArgumentNullException.ThrowIfNull((object)currencies, "currencies");
		_currencies = currencies;
	}

	internal void SetBattleStats(BattleStats stats)
	{
		ArgumentNullException.ThrowIfNull((object)stats, "stats");
		BattleStats = stats;
	}

	internal void UpdateSquad(int squadSlot, List<string> currentSquad)
	{
		_squads[squadSlot.ToString()] = currentSquad;
	}

	internal void SetAccountLinked(bool isLinked)
	{
		IsAccountLinked = isLinked;
	}

	internal void SetPlayerIcon(string iconFile)
	{
		PlayerIcon = iconFile;
	}

	internal void SetDailyBattleChest(DailyBattleChest chest)
	{
		DailyBattleChest = chest;
	}

	internal void UpdateQuestTaskProgress(string questId, string taskId, int step, bool isCompleted)
	{
		PlayerQuest playerQuest = default(PlayerQuest);
		if (!_playerQuests.TryGetValue(questId, ref playerQuest))
		{
			playerQuest = new PlayerQuest
			{
				QuestId = questId
			};
			_playerQuests[questId] = playerQuest;
		}
		playerQuest.Tasks[taskId] = new TaskProgress
		{
			Step = step,
			IsCompleted = isCompleted
		};
	}

	internal void AddExperience(double amount)
	{
		if (!(amount <= 0.0))
		{
			EXP = Math.Max(0.0, EXP + amount);
		}
	}
}
