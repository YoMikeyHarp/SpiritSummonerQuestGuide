using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Interfaces.Services;

namespace SpiritSummoner.Application.UseCases.Spirits;

public class LevelUpSpiritUseCase : IUseCase<LevelUpSpiritRequest, LevelUpSpiritResponse>
{
	private const int HP_BOOST_PER_LEVEL = 10;

	private const int TRAINING_POINTS_PER_LEVEL = 10;

	private readonly IPlayerStateService _stateService;

	private readonly ISpiritBusinessService _spiritBusinessService;

	public LevelUpSpiritUseCase(IPlayerStateService stateService, ISpiritBusinessService spiritBusinessService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
		_spiritBusinessService = spiritBusinessService ?? throw new ArgumentNullException("spiritBusinessService");
	}

	public global::System.Threading.Tasks.Task<Result<LevelUpSpiritResponse>> ExecuteAsync(LevelUpSpiritRequest request)
	{
		LevelUpSpiritRequest request2 = request;
		if (string.IsNullOrEmpty(request2.SpiritId))
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<LevelUpSpiritResponse>>(Result<LevelUpSpiritResponse>.FailureResult("Spirit ID is required"));
		}
		if (request2.LevelsToGain <= 0)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<LevelUpSpiritResponse>>(Result<LevelUpSpiritResponse>.FailureResult("Levels to gain must be greater than 0"));
		}
		PlayerSpirit spirit = _stateService.GetPlayerSpirit(request2.SpiritId);
		if (spirit == null)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<LevelUpSpiritResponse>>(Result<LevelUpSpiritResponse>.FailureResult("Spirit not found in player's collection"));
		}
		Spirit spiritTemplate = _stateService.GetSpiritTemplate(spirit.BaseSpiritID);
		if (spiritTemplate == null)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<LevelUpSpiritResponse>>(Result<LevelUpSpiritResponse>.FailureResult("Spirit template not found"));
		}
		long totalCost = 0L;
		int levelsToGain = request2.LevelsToGain;
		var result = _stateService.ExecuteUpdate(delegate(Player player)
		{
			int num2 = spirit.Level + levelsToGain;
			if (num2 > player.PlayerLevel)
			{
				return ValidationResult.Failure($"Spirit level cannot exceed player level ({player.PlayerLevel})");
			}
			totalCost = 0L;
			for (int i = 0; i < levelsToGain; i++)
			{
				totalCost += (long)_spiritBusinessService.CalculateLevelUpCost(spirit.Level + i);
			}
			long valueOrDefault = CollectionExtensions.GetValueOrDefault<string, long>(player.Currencies, "gold", 0L);
			return (valueOrDefault < totalCost) ? ValidationResult.Failure($"Insufficient gold. Required: {totalCost}, Available: {valueOrDefault}") : ValidationResult.Success();
		}, delegate(Player player)
		{
			int num = levelsToGain * 10;
			int hP = spirit.HP;
			spirit.SetLevel(spirit.Level + levelsToGain);
			spirit.SetHP(_spiritBusinessService.CalculateMaxHP(spiritTemplate.BaseStats?.HP ?? 100, spirit.Level));
			spirit.AddTrainingPoints(num);
			player.AddCurrency("gold", -totalCost);
			return new
			{
				NewLevel = spirit.Level,
				NewHP = spirit.HP,
				NewTrainingPoints = spirit.TrainingPoints,
				LevelChange = levelsToGain,
				HPChange = spirit.HP - hP,
				TrainingPointsChange = num,
				GoldSpent = totalCost
			};
		}, (Player player, updateResult) =>
		{
			PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty),
				CurrencyChanges = new Dictionary<string, long> { ["gold"] = -updateResult.GoldSpent }
			};
			playerBatchUpdate.AddSpiritFieldUpdate(request2.SpiritId, delegate(PlayerSpiritFieldUpdate update)
			{
				update.UpdateType = SpiritUpdateType.Level;
				update.LevelChange = updateResult.LevelChange;
				update.HPChange = updateResult.HPChange;
				update.TrainingPointsChange = updateResult.TrainingPointsChange;
			});
			return playerBatchUpdate;
		});
		if (!result.Success)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<LevelUpSpiritResponse>>(Result<LevelUpSpiritResponse>.FailureResult(result.ErrorMessage ?? "Failed to apply state update"));
		}
		return global::System.Threading.Tasks.Task.FromResult<Result<LevelUpSpiritResponse>>(Result<LevelUpSpiritResponse>.SuccessResult(new LevelUpSpiritResponse(request2.SpiritId, result.Data.NewLevel, result.Data.NewHP, result.Data.NewTrainingPoints, result.Data.GoldSpent)));
	}
}
