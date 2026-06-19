using System;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Application.UseCases.Spirits;

public class ResetStatPointsUseCase : IUseCase<ResetStatPointsRequest, ResetStatPointsResponse>
{
	public const int GoldCostPerLevel = 50;

	private readonly IPlayerStateService _stateService;

	public ResetStatPointsUseCase(IPlayerStateService stateService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
	}

	public global::System.Threading.Tasks.Task<Result<ResetStatPointsResponse>> ExecuteAsync(ResetStatPointsRequest request)
	{
		ResetStatPointsRequest request2 = request;
		if (string.IsNullOrEmpty(request2.SpiritId))
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<ResetStatPointsResponse>>(Result<ResetStatPointsResponse>.FailureResult("Spirit ID is required"));
		}
		var result = _stateService.ExecuteUpdate(delegate(Player player)
		{
			PlayerSpirit playerSpirit2 = default(PlayerSpirit);
			if (!player.PlayerSpirits.TryGetValue(request2.SpiritId, ref playerSpirit2))
			{
				return ValidationResult.Failure("Spirit not found in player's collection");
			}
			if (playerSpirit2.PointsATK + playerSpirit2.PointsDEF + playerSpirit2.PointsSATK + playerSpirit2.PointsSDEF + playerSpirit2.PointsSPD + playerSpirit2.PointsINT == 0)
			{
				return ValidationResult.Failure("No stat points are currently allocated");
			}
			long num3 = (long)playerSpirit2.Level * 50L;
			long num4 = default(long);
			long num5 = (player.Currencies.TryGetValue("gold", ref num4) ? num4 : 0);
			return (num5 < num3) ? ValidationResult.Failure("INSUFFICIENT_GOLD") : ValidationResult.Success();
		}, delegate(Player player)
		{
			PlayerSpirit playerSpirit = player.PlayerSpirits[request2.SpiritId];
			long num = (long)playerSpirit.Level * 50L;
			int num2 = playerSpirit.Level * 10 - 10;
			int trainingPointsRestored = playerSpirit.PointsATK + playerSpirit.PointsDEF + playerSpirit.PointsSATK + playerSpirit.PointsSDEF + playerSpirit.PointsSPD + playerSpirit.PointsINT;
			playerSpirit.SetStatPoints(0, 0, 0, 0, 0, 0);
			playerSpirit.SetTrainingPoints(num2);
			player.AddCurrency("gold", -num);
			return new
			{
				SpiritId = request2.SpiritId,
				GoldSpent = num,
				RestoredTrainingPoints = num2,
				TrainingPointsRestored = trainingPointsRestored
			};
		}, (Player player, updateResult) =>
		{
			PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty)
			};
			playerBatchUpdate.CurrencyChanges["gold"] = -updateResult.GoldSpent;
			playerBatchUpdate.AddSpiritFieldUpdate(request2.SpiritId, delegate(PlayerSpiritFieldUpdate update)
			{
				update.UpdateType = SpiritUpdateType.StatPoints;
				update.TrainingPointsChange = updateResult.TrainingPointsRestored;
				update.SetPointsATK = 0;
				update.SetPointsDEF = 0;
				update.SetPointsSATK = 0;
				update.SetPointsSDEF = 0;
				update.SetPointsSPD = 0;
				update.SetPointsINT = 0;
			});
			return playerBatchUpdate;
		});
		if (!result.Success)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<ResetStatPointsResponse>>(Result<ResetStatPointsResponse>.FailureResult(result.ErrorMessage ?? "Failed to reset stat points"));
		}
		return global::System.Threading.Tasks.Task.FromResult<Result<ResetStatPointsResponse>>(Result<ResetStatPointsResponse>.SuccessResult(new ResetStatPointsResponse(result.Data.SpiritId, result.Data.GoldSpent, result.Data.RestoredTrainingPoints)));
	}
}
