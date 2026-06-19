using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Interfaces.Services;

namespace SpiritSummoner.Domain.Services;

public class PlayerSpiritFactory : IPlayerSpiritFactory
{
	private const int TRAINING_POINTS_PER_LEVEL = 10;

	private readonly SpiritStatDistributionService _statDistributionService;

	private readonly ISpiritBusinessService _spiritBusinessService;

	public PlayerSpiritFactory(SpiritStatDistributionService statDistributionService, ISpiritBusinessService spiritBusinessService)
	{
		_statDistributionService = statDistributionService;
		_spiritBusinessService = spiritBusinessService;
	}

	public PlayerSpirit CreateForPlayer(Spirit template, Player owner, int level, string? playerSpiritId = null)
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		ArgumentNullException.ThrowIfNull((object)template, "template");
		ArgumentNullException.ThrowIfNull((object)owner, "owner");
		if (level < 1)
		{
			level = 1;
		}
		int num = default(int);
		int.TryParse(template.ID, ref num);
		string text = playerSpiritId;
		if (text == null)
		{
			Guid val = Guid.NewGuid();
			text = ((object)(Guid)(ref val)).ToString();
		}
		return PlayerSpirit.Rehydrate(text, owner.Playername, template.Name, template.Name, DateTimeOffset.UtcNow, num, level, CalculateInitialHP(template, level), CalculateInitialTrainingPoints(level), 0, 0, 0, 0, 0, 0, BuildInitialMoves(template), false, null, null, null);
	}

	public int CalculateInitialHP(Spirit template, int level)
	{
		return _spiritBusinessService.CalculateMaxHP((template?.BaseStats?.HP).GetValueOrDefault(), level);
	}

	public int CalculateInitialTrainingPoints(int level)
	{
		return (level > 1) ? (level * 10 - 10) : 0;
	}

	private static Dictionary<string, MoveState> BuildInitialMoves(Spirit template)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<string, MoveState> val = new Dictionary<string, MoveState>();
		if (template.LearnableMoves == null || template.LearnableMoves.Count == 0)
		{
			return val;
		}
		global::System.Collections.Generic.IReadOnlyList<string> baseMoveNames = template.GetBaseMoveNames();
		Enumerator<Move> enumerator = template.LearnableMoves.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Move current = enumerator.Current;
				bool flag = Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)baseMoveNames, current.Name);
				val[current.Name ?? string.Empty] = new MoveState(flag, flag);
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator).Dispose();
		}
		return val;
	}

	public PlayerSpirit CreateRandomSpirit(Player npcPlayer, Spirit baseSpirit)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		Spirit spirit = new Spirit(baseSpirit)
		{
			Level = npcPlayer.PlayerLevel,
			TrainingPoints = npcPlayer.PlayerLevel * 10
		};
		PlayerSpirit playerSpirit = new PlayerSpirit();
		_statDistributionService.DistributeTrainingPoints(playerSpirit, spirit);
		if (spirit.LearnableMoves != null)
		{
			Enumerator<Move> enumerator = spirit.LearnableMoves.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Move current = enumerator.Current;
					if (!string.IsNullOrEmpty(current.Name))
					{
						playerSpirit.UnlockMove(current.Name);
						playerSpirit.SetActiveMove(current.Name, isActive: true);
					}
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator).Dispose();
			}
		}
		return playerSpirit;
	}

	public PlayerSpirit CreateQuestSpirit(Spirit questSpirit, int level, global::System.Collections.Generic.IReadOnlyList<Move> moves, string opponentName)
	{
		questSpirit.Level = level;
		questSpirit.TrainingPoints = level * 10;
		PlayerSpirit playerSpirit = PlayerSpirit.QuestSpirit(questSpirit, level, moves, opponentName);
		_statDistributionService.DistributeTrainingPoints(playerSpirit, questSpirit);
		global::System.Collections.Generic.IEnumerator<Move> enumerator = ((global::System.Collections.Generic.IEnumerable<Move>)moves).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				Move current = enumerator.Current;
				if (!string.IsNullOrEmpty(current.Name))
				{
					playerSpirit.UnlockMove(current.Name);
					playerSpirit.SetActiveMove(current.Name, isActive: true);
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
		return playerSpirit;
	}

	public PlayerSpirit CreateStarterSpirit(string ownerUsername, Spirit baseSpirit)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrWhiteSpace(ownerUsername))
		{
			throw new ArgumentException("Owner username cannot be empty", "ownerUsername");
		}
		ArgumentNullException.ThrowIfNull((object)baseSpirit, "baseSpirit");
		PlayerSpirit playerSpirit = new PlayerSpirit();
		Guid val = Guid.NewGuid();
		playerSpirit.SetPlayerSpiritID(((object)(Guid)(ref val)).ToString());
		playerSpirit.SetPlayerName(ownerUsername);
		playerSpirit.SetName(baseSpirit.Name);
		playerSpirit.SetNickname(baseSpirit.Name);
		playerSpirit.SetBaseSpiritID(Convert.ToInt32(baseSpirit.ID));
		playerSpirit.SetDateOwned(global::System.DateTime.UtcNow);
		playerSpirit.SetLevel(1);
		playerSpirit.SetHP(baseSpirit.BaseStats?.HP ?? 100);
		playerSpirit.SetTrainingPoints(0);
		playerSpirit.SetStatPoints(0, 0, 0, 0, 0, 0);
		playerSpirit.EquipHeldItem(null);
		playerSpirit.EquipGear(null);
		playerSpirit.EquipTalent(null);
		playerSpirit.SetFavorite(isFavorite: false);
		if (baseSpirit.LearnableMoves != null && baseSpirit.LearnableMoves.Count > 0)
		{
			global::System.Collections.Generic.IReadOnlyList<string> baseMoveNames = baseSpirit.GetBaseMoveNames();
			Dictionary<string, MoveState> val2 = new Dictionary<string, MoveState>();
			Enumerator<Move> enumerator = baseSpirit.LearnableMoves.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Move current = enumerator.Current;
					bool flag = Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)baseMoveNames, current.Name);
					val2[current.Name ?? ""] = new MoveState
					{
						IsUnlocked = flag,
						IsActiveMove = flag
					};
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator).Dispose();
			}
			playerSpirit.SetMoves(val2);
		}
		return playerSpirit;
	}
}
