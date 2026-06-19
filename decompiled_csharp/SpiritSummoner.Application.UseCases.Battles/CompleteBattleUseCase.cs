using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Battles;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Interfaces.Services;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Domain.Services;
using SpiritSummoner.Infrastructure.Diagnostics;

namespace SpiritSummoner.Application.UseCases.Battles;

public class CompleteBattleUseCase : IUseCase<CompleteBattleRequest, BattleRewards>
{
	private readonly IBattleScoreCalculator _scoreCalculator;

	private readonly IPlayerStateService _stateService;

	private readonly IPlayerProgressionService _playerProgressionService;

	private readonly IPlayerCurrencyService _playerCurrencyService;

	private readonly IBattleLogRepository _battleLogRepository;

	public CompleteBattleUseCase(IBattleScoreCalculator scoreCalculator, IPlayerStateService playerStateService, IPlayerProgressionService playerProgressionService, IPlayerCurrencyService playerCurrencyService, IBattleLogRepository battleLogRepository)
	{
		_scoreCalculator = scoreCalculator;
		_stateService = playerStateService;
		_playerProgressionService = playerProgressionService;
		_playerCurrencyService = playerCurrencyService;
		_battleLogRepository = battleLogRepository;
		base._002Ector();
	}

	public global::System.Threading.Tasks.Task<Result<BattleRewards>> ExecuteAsync(CompleteBattleRequest request)
	{
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		CompleteBattleRequest request2 = request;
		var result = _stateService.ExecuteUpdate((Player player) => (request2.EnemyLevel <= 0) ? ValidationResult.Failure("Enemy level must be greater than 0") : ValidationResult.Success(), delegate(Player player)
		{
			double expToNextLevel = _playerProgressionService.CalculateNextEXPMax(player.PlayerLevel);
			BattleRewards battleRewards = CalculateBattleRewards(request2.Victory, player.PlayerLevel, request2.EnemyLevel, expToNextLevel, request2.IsPvP);
			int scoreChange = 0;
			int winsDelta = 0;
			int lossDelta = 0;
			if (request2.IsPvP && player.IsAccountLinked)
			{
				int num = _scoreCalculator.CalculateScoreChange(request2.Victory, player.PlayerLevel, request2.EnemyLevel, player.BattleStats.Score - request2.PreCommittedScorePenalty, request2.LivingSpiritsCount, request2.TotalHealthPercentage);
				scoreChange = (battleRewards.ScoreChange = num - request2.PreCommittedScorePenalty);
				int score = Math.Max(0, player.BattleStats.Score + scoreChange);
				player.BattleStats.SetScore(score);
				string title = _scoreCalculator.GetTitle(score, 0);
				player.BattleStats.SetTitle(title);
				int score2 = player.BattleStats.Score;
				int num3 = Math.Max(0, score2 - request2.PreCommittedScorePenalty + num);
				player.BattleStats.SetScore(num3);
				scoreChange = num3 - score2;
				battleRewards.ScoreChange = scoreChange;
				scoreChange = num3 - score2;
				battleRewards.ScoreChange = num;
				if (request2.Victory)
				{
					player.BattleStats.IncrementWins();
					player.BattleStats.DecrementLosses();
					winsDelta = 1;
					lossDelta = -1;
				}
			}
			int levelsGained = 0;
			if (battleRewards.Experience > 0)
			{
				levelsGained = _playerProgressionService.GainExperience(player, battleRewards.Experience);
				_playerCurrencyService.ModifyCurrency(player, "gold", battleRewards.Gold);
				_playerCurrencyService.ModifyCurrency(player, "reputation", battleRewards.Reputation);
			}
			return new
			{
				Rewards = battleRewards,
				ScoreChange = scoreChange,
				WinsDelta = winsDelta,
				LossDelta = lossDelta,
				NewTitle = player.BattleStats.Title,
				LevelsGained = levelsGained,
				PlayerId = (player.PlayerID ?? string.Empty),
				PlayerLevel = player.PlayerLevel
			};
		}, (Player player, updateResult) =>
		{
			PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty),
				ExperienceGain = updateResult.Rewards.Experience,
				CurrencyChanges = new Dictionary<string, long>
				{
					["gold"] = updateResult.Rewards.Gold,
					["reputation"] = updateResult.Rewards.Reputation
				},
				UpdateReputation = (updateResult.Rewards.Reputation > 0),
				GuildUpdates = ((updateResult.LevelsGained > 0) ? new PlayerGuildUpdate
				{
					GuildId = player.GuildId,
					TargetPlayerId = player.PlayerID
				} : new PlayerGuildUpdate
				{
					TargetPlayerId = string.Empty
				}),
				WinsChange = updateResult.WinsDelta,
				LossChange = updateResult.LossDelta,
				ScoreChange = updateResult.ScoreChange,
				NewTitle = updateResult.NewTitle,
				UpdateLeaderboard = request2.IsPvP
			};
			if (updateResult.LevelsGained > 0)
			{
				playerBatchUpdate.SetLevelUp(player);
			}
			if (!string.IsNullOrEmpty(request2.QuestTaskId))
			{
				playerBatchUpdate.TaskUpdates = new Dictionary<string, TaskProgress> { [request2.QuestTaskId] = new TaskProgress
				{
					IsCompleted = request2.QuestTaskCompleted,
					Step = request2.QuestTaskStep
				} };
			}
			return playerBatchUpdate;
		});
		if (!result.Success || result.Data == null)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<BattleRewards>>(Result<BattleRewards>.FailureResult(result.ErrorMessage ?? "Failed to complete battle"));
		}
		if (request2.IsPvP)
		{
			List<string> lines = Enumerable.ToList<string>((global::System.Collections.Generic.IEnumerable<string>)BattleLogCapture.Instance.Snapshot());
			BattleLog log = new BattleLog
			{
				PlayerId = result.Data.PlayerId,
				OpponentPlayerId = (request2.OpponentPlayerId ?? string.Empty),
				BattleMode = "PVP",
				Victory = request2.Victory,
				PlayerLevel = result.Data.PlayerLevel,
				EnemyLevel = request2.EnemyLevel,
				LivingSpiritsCount = request2.LivingSpiritsCount,
				TotalHealthPercentage = request2.TotalHealthPercentage,
				ScoreChange = result.Data.ScoreChange,
				CreatedAt = DateTimeOffset.UtcNow,
				Lines = lines
			};
			_battleLogRepository.WriteAsync(log);
		}
		return global::System.Threading.Tasks.Task.FromResult<Result<BattleRewards>>(Result<BattleRewards>.SuccessResult(result.Data.Rewards));
	}

	private static BattleRewards CalculateBattleRewards(bool playerWon, int playerLevel, int opponentLevel, double expToNextLevel, bool isPvP)
	{
		double num = (double)opponentLevel / (double)Math.Max(1, playerLevel);
		num = Math.Clamp(num, 0.5, 2.0);
		double num3;
		if (isPvP)
		{
			if (1 == 0)
			{
			}
			double num2 = ((playerLevel < 60) ? ((playerLevel < 20) ? 0.02 : ((playerLevel >= 40) ? 0.008 : 0.015)) : ((playerLevel >= 70) ? 0.0014 : 0.004));
			if (1 == 0)
			{
			}
			num3 = num2;
		}
		else
		{
			if (1 == 0)
			{
			}
			double num2 = ((playerLevel < 60) ? ((playerLevel < 20) ? 0.02 : ((playerLevel >= 40) ? 0.008 : 0.015)) : ((playerLevel >= 70) ? 0.0014 : 0.004));
			if (1 == 0)
			{
			}
			num3 = num2;
		}
		double num4 = expToNextLevel * num3 * num;
		double num5 = num4 * 1.0;
		int num6 = (int)(25.0 * num);
		return new BattleRewards
		{
			Experience = (playerWon ? ((int)Math.Max(1.0, num4)) : ((!isPvP) ? 1 : ((int)Math.Max(1.0, num4 * 0.02)))),
			Gold = (playerWon ? ((long)Math.Max(10.0, num5)) : (isPvP ? ((long)Math.Max(5.0, num5 * 0.02)) : 1)),
			Reputation = (playerWon ? (num6 + 25) : (num6 / 2))
		};
	}
}
