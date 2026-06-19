using System;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Services;
using SpiritSummoner.Infrastructure.Contracts;

namespace SpiritSummoner.Application.UseCases.Battles;

public class PreCommitBattleUseCase : IUseCase<PreCommitBattleRequest, PreCommitBattleResult>
{
	private readonly IBattleScoreCalculator _scoreCalculator;

	private readonly IPlayerStateService _stateService;

	private readonly IServerTimeProvider _serverTime;

	public PreCommitBattleUseCase(IBattleScoreCalculator scoreCalculator, IPlayerStateService stateService, IServerTimeProvider serverTime)
	{
		_scoreCalculator = scoreCalculator;
		_stateService = stateService;
		_serverTime = serverTime;
	}

	public global::System.Threading.Tasks.Task<Result<PreCommitBattleResult>> ExecuteAsync(PreCommitBattleRequest request)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		PreCommitBattleRequest request2 = request;
		DateTimeOffset now = _serverTime.GetCurrentServerTime();
		var result = _stateService.ExecuteUpdate(delegate(Player player)
		{
			if (request2.OpponentLevel <= 0)
			{
				return ValidationResult.Failure("Enemy level must be greater than 0");
			}
			return (player.SP < 1) ? ValidationResult.Failure("Insufficient SP for battle") : ValidationResult.Success();
		}, delegate(Player player)
		{
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			int scorePenalty = 0;
			int lossChange = 0;
			if (request2.IsPvP && player.IsAccountLinked)
			{
				int num = _scoreCalculator.CalculateScoreChange(playerWon: false, player.PlayerLevel, request2.OpponentLevel, player.BattleStats.Score, 0, 0.0);
				int score = player.BattleStats.Score;
				int num2 = Math.Max(0, score + num);
				scorePenalty = num2 - score;
				player.BattleStats.SetScore(num2);
				string title = _scoreCalculator.GetTitle(player.BattleStats.Score, 0);
				player.BattleStats.SetTitle(title);
				player.BattleStats.IncrementLosses();
				lossChange = 1;
			}
			player.SetSP(player.SP - 1);
			player.SetLastSpRegenTime(now);
			player.DailyBattleChest.IncrementBattles();
			Guid val = Guid.NewGuid();
			return new
			{
				BattleId = ((object)(Guid)(ref val)).ToString(),
				lossChange = lossChange,
				ScorePenalty = scorePenalty,
				NewTitle = player.BattleStats.Title
			};
		}, (Player player, r) => new PlayerBatchUpdate
		{
			PlayerId = (player.PlayerID ?? string.Empty),
			SPChange = -1,
			LossChange = r.lossChange,
			ScoreChange = r.ScorePenalty,
			NewTitle = r.NewTitle,
			LastSpRegenTime = now,
			UpdateLeaderboard = request2.IsPvP,
			DailyBattleChestUpdate = new DailyBattleChestUpdate(player.DailyBattleChest.BattlesCompleted, player.DailyBattleChest.LastClaimedAt, player.DailyBattleChest.LastResetAt)
		});
		if (!result.Success || result.Data == null)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<PreCommitBattleResult>>(Result<PreCommitBattleResult>.FailureResult(result.ErrorMessage ?? "Failed to pre-commit battle"));
		}
		return global::System.Threading.Tasks.Task.FromResult<Result<PreCommitBattleResult>>(Result<PreCommitBattleResult>.SuccessResult(new PreCommitBattleResult(result.Data.BattleId, result.Data.ScorePenalty)));
	}
}
