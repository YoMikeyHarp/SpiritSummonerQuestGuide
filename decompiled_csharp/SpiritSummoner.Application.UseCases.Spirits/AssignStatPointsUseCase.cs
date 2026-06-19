using System;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Application.UseCases.Spirits;

public class AssignStatPointsUseCase : IUseCase<AssignStatPointsRequest, AssignStatPointsResponse>
{
	private readonly IPlayerStateService _stateService;

	public AssignStatPointsUseCase(IPlayerStateService stateService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
	}

	public global::System.Threading.Tasks.Task<Result<AssignStatPointsResponse>> ExecuteAsync(AssignStatPointsRequest request)
	{
		AssignStatPointsRequest request2 = request;
		if (string.IsNullOrEmpty(request2.SpiritId))
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<AssignStatPointsResponse>>(Result<AssignStatPointsResponse>.FailureResult("Spirit ID is required"));
		}
		if (request2.PointsATK < 0 || request2.PointsDEF < 0 || request2.PointsSATK < 0 || request2.PointsSDEF < 0 || request2.PointsSPD < 0 || request2.PointsINT < 0)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<AssignStatPointsResponse>>(Result<AssignStatPointsResponse>.FailureResult("Stat point assignments cannot be negative"));
		}
		int totalPointsToAssign = request2.PointsATK + request2.PointsDEF + request2.PointsSATK + request2.PointsSDEF + request2.PointsSPD + request2.PointsINT;
		var result = _stateService.ExecuteUpdate(delegate(Player player)
		{
			PlayerSpirit playerSpirit2 = default(PlayerSpirit);
			if (!player.PlayerSpirits.TryGetValue(request2.SpiritId, ref playerSpirit2))
			{
				return ValidationResult.Failure("Spirit not found in player's collection");
			}
			if (playerSpirit2.TrainingPoints < totalPointsToAssign)
			{
				return ValidationResult.Failure($"Insufficient training points. Have {playerSpirit2.TrainingPoints}, need {totalPointsToAssign}");
			}
			int num = playerSpirit2.Level * 10 - 10;
			int num2 = playerSpirit2.PointsATK + playerSpirit2.PointsDEF + playerSpirit2.PointsSATK + playerSpirit2.PointsSDEF + playerSpirit2.PointsSPD + playerSpirit2.PointsINT;
			int num3 = num2 + totalPointsToAssign;
			return (num3 > num) ? ValidationResult.Failure($"Cannot allocate {totalPointsToAssign} points. Would exceed max training points ({num})") : ValidationResult.Success();
		}, delegate(Player player)
		{
			PlayerSpirit playerSpirit = player.PlayerSpirits[request2.SpiritId];
			playerSpirit.AddStatPoints(request2.PointsATK, request2.PointsDEF, request2.PointsSATK, request2.PointsSDEF, request2.PointsSPD, request2.PointsINT);
			playerSpirit.SetTrainingPoints(playerSpirit.TrainingPoints - totalPointsToAssign);
			return new
			{
				SpiritId = request2.SpiritId,
				NewTrainingPoints = playerSpirit.TrainingPoints,
				NewPointsATK = playerSpirit.PointsATK,
				NewPointsDEF = playerSpirit.PointsDEF,
				NewPointsSATK = playerSpirit.PointsSATK,
				NewPointsSDEF = playerSpirit.PointsSDEF,
				NewPointsSPD = playerSpirit.PointsSPD,
				NewPointsINT = playerSpirit.PointsINT,
				PointsAssigned = totalPointsToAssign,
				TrainingPointsChange = -totalPointsToAssign
			};
		}, (Player player, updateResult) =>
		{
			PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty)
			};
			playerBatchUpdate.AddSpiritFieldUpdate(request2.SpiritId, delegate(PlayerSpiritFieldUpdate update)
			{
				update.UpdateType = SpiritUpdateType.StatPoints;
				update.TrainingPointsChange = updateResult.TrainingPointsChange;
				update.SetPointsATK = updateResult.NewPointsATK;
				update.SetPointsDEF = updateResult.NewPointsDEF;
				update.SetPointsSATK = updateResult.NewPointsSATK;
				update.SetPointsSDEF = updateResult.NewPointsSDEF;
				update.SetPointsSPD = updateResult.NewPointsSPD;
				update.SetPointsINT = updateResult.NewPointsINT;
			});
			return playerBatchUpdate;
		});
		if (!result.Success)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<AssignStatPointsResponse>>(Result<AssignStatPointsResponse>.FailureResult(result.ErrorMessage ?? "Failed to apply state update"));
		}
		return global::System.Threading.Tasks.Task.FromResult<Result<AssignStatPointsResponse>>(Result<AssignStatPointsResponse>.SuccessResult(new AssignStatPointsResponse(result.Data.SpiritId, result.Data.NewTrainingPoints, result.Data.NewPointsATK, result.Data.NewPointsDEF, result.Data.NewPointsSATK, result.Data.NewPointsSDEF, result.Data.NewPointsSPD, result.Data.NewPointsINT, result.Data.PointsAssigned)));
	}
}
