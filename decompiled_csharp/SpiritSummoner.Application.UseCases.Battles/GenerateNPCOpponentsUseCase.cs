using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.DTOs.Battles;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Interfaces.Services;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Caching;

namespace SpiritSummoner.Application.UseCases.Battles;

public class GenerateNPCOpponentsUseCase : IUseCase<GenerateNPCOpponentsRequest, List<BattleOpponentDTO>>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__8 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<List<BattleOpponentDTO>>> _003C_003Et__builder;

		public GenerateNPCOpponentsRequest request;

		public GenerateNPCOpponentsUseCase _003C_003E4__this;

		private IReadOnlyDictionary<string, Spirit> _003CallSpirits_003E5__1;

		private List<Spirit> _003CspiritsList_003E5__2;

		private Dictionary<string, int> _003CspiritStages_003E5__3;

		private List<BattleOpponentDTO> _003CnpcOpponents_003E5__4;

		private int _003Ci_003E5__5;

		private BattleOpponentDTO _003Cnpc_003E5__6;

		private global::System.Exception _003Cex_003E5__7;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			Result<List<BattleOpponentDTO>> result;
			try
			{
				try
				{
					_003CallSpirits_003E5__1 = _003C_003E4__this._spiritRepository.GetAll();
					_003CspiritsList_003E5__2 = Enumerable.ToList<Spirit>(Enumerable.Select<KeyValuePair<string, Spirit>, Spirit>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, Spirit>>)_003CallSpirits_003E5__1, (Func<KeyValuePair<string, Spirit>, Spirit>)((KeyValuePair<string, Spirit> p) => p.Value)));
					if (_003CspiritsList_003E5__2.Count == 0)
					{
						result = Result<List<BattleOpponentDTO>>.FailureResult("No spirits available for NPC generation");
					}
					else
					{
						_003CspiritStages_003E5__3 = _003C_003E4__this.CalculateSpiritStages(_003CspiritsList_003E5__2);
						_003CnpcOpponents_003E5__4 = new List<BattleOpponentDTO>();
						_003Ci_003E5__5 = 0;
						while (_003Ci_003E5__5 < request.Count)
						{
							_003Cnpc_003E5__6 = _003C_003E4__this.GenerateNPCOpponent(request.PlayerLevel, _003CspiritsList_003E5__2, _003CspiritStages_003E5__3);
							_003CnpcOpponents_003E5__4.Add(_003Cnpc_003E5__6);
							_003Cnpc_003E5__6 = null;
							_003Ci_003E5__5++;
						}
						result = Result<List<BattleOpponentDTO>>.SuccessResult(_003CnpcOpponents_003E5__4);
					}
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__7 = ex;
					result = Result<List<BattleOpponentDTO>>.FailureResult("Failed to generate NPC opponents: " + _003Cex_003E5__7.Message);
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly ISpiritRepository _spiritRepository;

	private readonly IPlayerSpiritFactory _playerSpiritFactory;

	private readonly IStaticDataCacheService _staticDataCache;

	private static readonly Random _random = new Random();

	private readonly List<string> _npcNames;

	private readonly List<string> _npcGuildNames;

	private static readonly global::System.Collections.Generic.IReadOnlyList<string> AvailableIcons = (global::System.Collections.Generic.IReadOnlyList<string>)Enumerable.ToList<string>(Enumerable.Select<int, string>(Enumerable.Range(1, 12), (Func<int, string>)((int i) => $"pfp{i}.png")));

	public GenerateNPCOpponentsUseCase(ISpiritRepository spiritRepository, IPlayerSpiritFactory playerSpiritFactory, IStaticDataCacheService staticDataCacheService)
	{
		List<string> obj = new List<string>();
		obj.Add("Summoner Steve");
		obj.Add("Spirit Walker");
		obj.Add("Rune Master");
		obj.Add("Mana Addict");
		obj.Add("High Summoner");
		obj.Add("Novice Ned");
		obj.Add("Grandmaster Jay");
		obj.Add("Battle Mage");
		obj.Add("Spirit Seeker");
		obj.Add("Void Caller");
		obj.Add("Arcane Andy");
		obj.Add("Mystic Mary");
		obj.Add("Summer Breeze");
		obj.Add("Winter Chill");
		obj.Add("Autumn Leaf");
		obj.Add("Spring Bloom");
		obj.Add("Sunny Day");
		obj.Add("Rain Dancer");
		obj.Add("Thunder Clap");
		obj.Add("Forest Walker");
		obj.Add("NoobMaster69");
		obj.Add("LagSpike");
		obj.Add("GitGud");
		obj.Add("Skill Issue");
		obj.Add("Main Character");
		obj.Add("RNGesus");
		obj.Add("Touch Grass");
		obj.Add("Error 404");
		obj.Add("Potion Seller");
		obj.Add("MyDadWorksHere");
		obj.Add("AFK Player");
		obj.Add("Loading...");
		obj.Add("Nerf This");
		obj.Add("Just One More");
		obj.Add("Skip Cutscene");
		obj.Add("Plot Armor");
		obj.Add("Ash Ketchum?");
		obj.Add("HeartOfCards");
		obj.Add("Geralt");
		obj.Add("Cloud Strife");
		obj.Add("Dovahkiin");
		obj.Add("Link");
		obj.Add("Snake");
		obj.Add("Stark");
		obj.Add("Leeroy J");
		obj.Add("SkyWalker");
		obj.Add("Neo");
		obj.Add("John Wick");
		obj.Add("Red Cap");
		obj.Add("Blue Shell");
		obj.Add("Chosen One");
		obj.Add("Hero Of Time");
		obj.Add("Shadow Fang");
		obj.Add("Crimson Eye");
		obj.Add("Night Shade");
		obj.Add("Wolf Pack");
		obj.Add("Dark Matter");
		obj.Add("Light Bringer");
		obj.Add("Chaos Theory");
		obj.Add("Zero Gravity");
		obj.Add("Neon City");
		obj.Add("Cyber Punk");
		obj.Add("Vortex");
		obj.Add("Eclipse");
		obj.Add("Mimic • SidImpure");
		obj.Add("Mimic • p4llin");
		obj.Add("Mimic • 00jyk");
		obj.Add("Mimic • OElrick0");
		obj.Add("Mimic • Akomo");
		obj.Add("Mimic • alzinhoo");
		obj.Add("Mimic • Ames");
		obj.Add("Mimic • AsaBoi");
		obj.Add("Mimic • Avara");
		obj.Add("Mimic • BN 3ISA");
		obj.Add("Mimic • CrazyReaderz");
		obj.Add("Mimic • Creamy Korean");
		obj.Add("Mimic • CutePapaya");
		obj.Add("Mimic • Cyclone");
		obj.Add("Mimic • Dark Daze");
		obj.Add("Mimic • Deviant");
		obj.Add("Mimic • Draco");
		obj.Add("Mimic • Drago");
		obj.Add("Mimic • Drogost");
		obj.Add("Mimic • Essephex");
		obj.Add("Mimic • fuegojr");
		obj.Add("Mimic • GeneralJTwust");
		obj.Add("Mimic • Geo");
		obj.Add("Mimic • GlobalRabbit");
		obj.Add("Mimic • Gloopy");
		obj.Add("Mimic • Hide on Clone");
		obj.Add("Mimic • Izaan");
		obj.Add("Mimic • Janni");
		obj.Add("Mimic • JT");
		obj.Add("Mimic • KapasaGamer808");
		obj.Add("Mimic • KidBoo");
		obj.Add("Mimic • knowledge_25");
		obj.Add("Mimic • KrazyKai");
		obj.Add("Mimic • Lo-Mein");
		obj.Add("Mimic • MKultrahhTTV");
		obj.Add("Mimic • Mog Knight Kiro");
		obj.Add("Mimic • Mucks");
		obj.Add("Mimic • Nami");
		obj.Add("Mimic • Nauy");
		obj.Add("Mimic • Nox");
		obj.Add("Mimic • SweetVicotry");
		obj.Add("Mimic • Tom");
		obj.Add("Mimic • VioletAster");
		obj.Add("Mimic • WeirdCooki");
		obj.Add("Mimic • WintrChris");
		obj.Add("Mimic • xlightskinmac11");
		obj.Add("Mimic • XStormin_NormanX");
		obj.Add("Mimic • Ztensity");
		obj.Add("Mimic • herostorm");
		_npcNames = obj;
		List<string> obj2 = new List<string>();
		obj2.Add("Spirit Walkers");
		obj2.Add("Iron Fist");
		obj2.Add("Mystic Dawn");
		obj2.Add("Shadow Cabal");
		obj2.Add("Light Keepers");
		obj2.Add("Void Runners");
		obj2.Add("Elements");
		obj2.Add("Beast Tamers");
		obj2.Add("Rune Guard");
		obj2.Add("Storm Chasers");
		obj2.Add("Night Watch");
		obj2.Add("Solar Flare");
		obj2.Add("Lunar Tide");
		obj2.Add("Forest Kin");
		obj2.Add("Mountain Peak");
		obj2.Add("Crimson Sky");
		_npcGuildNames = obj2;
		base._002Ector();
		_spiritRepository = spiritRepository;
		_playerSpiritFactory = playerSpiritFactory;
		_staticDataCache = staticDataCacheService;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__8))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<List<BattleOpponentDTO>>> ExecuteAsync(GenerateNPCOpponentsRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IReadOnlyDictionary<string, Spirit> allSpirits = _spiritRepository.GetAll();
			List<Spirit> spiritsList = Enumerable.ToList<Spirit>(Enumerable.Select<KeyValuePair<string, Spirit>, Spirit>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, Spirit>>)allSpirits, (Func<KeyValuePair<string, Spirit>, Spirit>)((KeyValuePair<string, Spirit> p) => p.Value)));
			if (spiritsList.Count == 0)
			{
				return Result<List<BattleOpponentDTO>>.FailureResult("No spirits available for NPC generation");
			}
			Dictionary<string, int> spiritStages = CalculateSpiritStages(spiritsList);
			List<BattleOpponentDTO> npcOpponents = new List<BattleOpponentDTO>();
			for (int i = 0; i < request.Count; i++)
			{
				BattleOpponentDTO npc = GenerateNPCOpponent(request.PlayerLevel, spiritsList, spiritStages);
				npcOpponents.Add(npc);
			}
			return Result<List<BattleOpponentDTO>>.SuccessResult(npcOpponents);
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			return Result<List<BattleOpponentDTO>>.FailureResult("Failed to generate NPC opponents: " + ex.Message);
		}
	}

	private Dictionary<string, int> CalculateSpiritStages(List<Spirit> spirits)
	{
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<string, int> val = new Dictionary<string, int>();
		HashSet<string> evolutionTargets = Enumerable.ToHashSet<string>(Enumerable.Where<string>(Enumerable.Select<Spirit, string>((global::System.Collections.Generic.IEnumerable<Spirit>)spirits, (Func<Spirit, string>)((Spirit s) => s.Evolution.ToString())), (Func<string, bool>)((string e) => !string.IsNullOrEmpty(e) && e != "0")));
		List<Spirit> stage1 = Enumerable.ToList<Spirit>(Enumerable.Where<Spirit>((global::System.Collections.Generic.IEnumerable<Spirit>)spirits, (Func<Spirit, bool>)((Spirit s) => !evolutionTargets.Contains(s.ID))));
		Enumerator<Spirit> enumerator = stage1.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Spirit current = enumerator.Current;
				val[current.ID] = 1;
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator).Dispose();
		}
		List<Spirit> stage2 = Enumerable.ToList<Spirit>(Enumerable.Where<Spirit>((global::System.Collections.Generic.IEnumerable<Spirit>)spirits, (Func<Spirit, bool>)((Spirit s) => Enumerable.Any<Spirit>((global::System.Collections.Generic.IEnumerable<Spirit>)stage1, (Func<Spirit, bool>)((Spirit baseForm) => baseForm.Evolution.ToString() == s.ID)))));
		Enumerator<Spirit> enumerator2 = stage2.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				Spirit current2 = enumerator2.Current;
				val[current2.ID] = 2;
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator2).Dispose();
		}
		List<Spirit> val2 = Enumerable.ToList<Spirit>(Enumerable.Where<Spirit>((global::System.Collections.Generic.IEnumerable<Spirit>)spirits, (Func<Spirit, bool>)((Spirit s) => Enumerable.Any<Spirit>((global::System.Collections.Generic.IEnumerable<Spirit>)stage2, (Func<Spirit, bool>)((Spirit midForm) => midForm.Evolution.ToString() == s.ID)))));
		Enumerator<Spirit> enumerator3 = val2.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				Spirit current3 = enumerator3.Current;
				val[current3.ID] = 3;
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator3).Dispose();
		}
		Enumerator<Spirit> enumerator4 = spirits.GetEnumerator();
		try
		{
			while (enumerator4.MoveNext())
			{
				Spirit current4 = enumerator4.Current;
				if (!val.ContainsKey(current4.ID))
				{
					val[current4.ID] = 1;
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator4).Dispose();
		}
		return val;
	}

	private BattleOpponentDTO GenerateNPCOpponent(int playerLevel, List<Spirit> availableSpirits, Dictionary<string, int> spiritStages)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<string, int> spiritStages2 = spiritStages;
		int num = Math.Max(1, playerLevel - 2);
		int num2 = playerLevel + 3;
		int npcLevel = _random.Next(num, num2);
		List<Spirit> availableSpirits2 = Enumerable.ToList<Spirit>(Enumerable.Where<Spirit>((global::System.Collections.Generic.IEnumerable<Spirit>)availableSpirits, (Func<Spirit, bool>)delegate(Spirit s)
		{
			if (npcLevel < 25 && s.IsUnique)
			{
				return false;
			}
			int valueOrDefault = CollectionExtensions.GetValueOrDefault<string, int>((IReadOnlyDictionary<string, int>)(object)spiritStages2, s.ID ?? string.Empty, 1);
			if (npcLevel < 15)
			{
				return valueOrDefault == 1;
			}
			return npcLevel >= 25 || valueOrDefault <= 2;
		}));
		Player player = CreateNPCPlayer(npcLevel);
		List<Spirit> val = SelectRandomSpirits(availableSpirits2, 3);
		List<PlayerSpirit> val2 = new List<PlayerSpirit>();
		Enumerator<Spirit> enumerator = val.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Spirit current = enumerator.Current;
				PlayerSpirit playerSpirit = _playerSpiritFactory.CreateRandomSpirit(player, current);
				int hP = (current.BaseStats?.HP ?? 100) + 5 * (player.PlayerLevel - 1);
				if (npcLevel >= 15)
				{
					string talentId = Enumerable.ToList<string>((global::System.Collections.Generic.IEnumerable<string>)_staticDataCache.Talents.Keys)[_random.Next(_staticDataCache.Talents.Count)];
					string gearId = Enumerable.ToList<string>((global::System.Collections.Generic.IEnumerable<string>)_staticDataCache.Gears.Keys)[_random.Next(_staticDataCache.Gears.Count)];
					playerSpirit.EquipTalent(talentId);
					playerSpirit.EquipGear(gearId);
				}
				playerSpirit.SetPlayerName(player.Playername ?? "NPC");
				Guid val3 = Guid.NewGuid();
				playerSpirit.SetPlayerSpiritID(((object)(Guid)(ref val3)).ToString());
				playerSpirit.SetBaseSpiritID(int.Parse(current.ID));
				playerSpirit.SetLevel(player.PlayerLevel);
				playerSpirit.SetHP(hP);
				val2.Add(playerSpirit);
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator).Dispose();
		}
		Enumerator<PlayerSpirit> enumerator2 = val2.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				PlayerSpirit current2 = enumerator2.Current;
				player.AddSpirit(current2);
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator2).Dispose();
		}
		List<string> activeSquadSpiritIds = Enumerable.ToList<string>(Enumerable.Where<string>(Enumerable.Select<PlayerSpirit, string>((global::System.Collections.Generic.IEnumerable<PlayerSpirit>)val2, (Func<PlayerSpirit, string>)((PlayerSpirit s) => s.PlayerSpiritID ?? string.Empty)), (Func<string, bool>)((string id) => !string.IsNullOrEmpty(id))));
		return new BattleOpponentDTO
		{
			PlayerId = (player.PlayerID ?? string.Empty),
			Username = (player.Playername ?? "NPC Player"),
			Level = player.PlayerLevel,
			Title = player.BattleStats?.Title,
			ActiveSquadSpiritIds = (global::System.Collections.Generic.IReadOnlyList<string>)activeSquadSpiritIds,
			OpponentSpirits = (global::System.Collections.Generic.IReadOnlyList<PlayerSpirit>?)val2,
			Icon = AvailableIcons[_random.Next(((global::System.Collections.Generic.IReadOnlyCollection<string>)AvailableIcons).Count)]
		};
	}

	private Player CreateNPCPlayer(int level)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		Guid val = Guid.NewGuid();
		string playerId = ((object)(Guid)(ref val)).ToString();
		string playerName = _npcNames[_random.Next(_npcNames.Count)];
		string guildId = _npcGuildNames[_random.Next(_npcGuildNames.Count)];
		string playerIcon = AvailableIcons[_random.Next(((global::System.Collections.Generic.IReadOnlyCollection<string>)AvailableIcons).Count)];
		int num = 100 + level * 5;
		int num2 = 20 + level * 2;
		double num3 = 100.0 * Math.Pow(1.5, (double)(level - 1));
		int? playerLevel = level;
		double? exp = 0.0;
		double? maxExp = num3;
		int? ep = num;
		int? maxEp = num;
		int? sp = num2;
		int? maxSp = num2;
		Dictionary<string, long> obj = new Dictionary<string, long>();
		obj.Add("gold", (long)(1000 * level));
		Dictionary<string, PlayerQuest> playerQuests = new Dictionary<string, PlayerQuest>();
		Dictionary<string, List<string>> obj2 = new Dictionary<string, List<string>>();
		List<string> obj3 = new List<string>();
		obj3.Add("");
		obj3.Add("");
		obj3.Add("");
		obj2.Add("1", obj3);
		return Player.Rehydrate(playerId, playerName, playerLevel, exp, maxExp, ep, maxEp, sp, maxSp, obj, playerQuests, obj2, 1, null, new Dictionary<string, PlayerSpirit>(), new Dictionary<string, Inventory>(), new List<string>(), 1, CreateNPCBattleStats(level), DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, guildId, null, null, false, null, playerIcon);
	}

	private BattleStats CreateNPCBattleStats(int level)
	{
		BattleStats battleStats = new BattleStats();
		if (level < 10)
		{
			battleStats.SetTitle("Novice");
		}
		else if (level < 20)
		{
			battleStats.SetTitle("Apprentice");
		}
		else if (level < 30)
		{
			battleStats.SetTitle("Adept");
		}
		else
		{
			battleStats.SetTitle("Champion");
		}
		int num = _random.Next(10, 50);
		int num2 = _random.Next(num / 3, num * 2 / 3);
		for (int i = 0; i < num2; i++)
		{
			battleStats.IncrementWins();
		}
		for (int j = 0; j < num - num2; j++)
		{
			battleStats.IncrementLosses();
		}
		return battleStats;
	}

	private List<Spirit> SelectRandomSpirits(List<Spirit> availableSpirits, int count)
	{
		List<Spirit> val = new List<Spirit>();
		List<Spirit> val2 = new List<Spirit>((global::System.Collections.Generic.IEnumerable<Spirit>)availableSpirits);
		for (int i = 0; i < count; i++)
		{
			if (val2.Count <= 0)
			{
				break;
			}
			int num = _random.Next(val2.Count);
			val.Add(val2[num]);
			val2.RemoveAt(num);
		}
		return val;
	}
}
