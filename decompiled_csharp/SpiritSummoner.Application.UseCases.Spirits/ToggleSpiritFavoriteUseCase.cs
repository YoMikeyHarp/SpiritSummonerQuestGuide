using System;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Application.UseCases.Spirits;

public class ToggleSpiritFavoriteUseCase : IUseCase<ToggleSpiritFavoriteRequest, ToggleSpiritFavoriteResponse>
{
	private readonly IPlayerStateService _stateService;

	public ToggleSpiritFavoriteUseCase(IPlayerStateService stateService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
	}

	public global::System.Threading.Tasks.Task<Result<ToggleSpiritFavoriteResponse>> ExecuteAsync(ToggleSpiritFavoriteRequest request)
	{
		ToggleSpiritFavoriteRequest request2 = request;
		if (string.IsNullOrEmpty(request2.SpiritId))
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<ToggleSpiritFavoriteResponse>>(Result<ToggleSpiritFavoriteResponse>.FailureResult("Spirit ID is required"));
		}
		PlayerSpirit playerSpirit = _stateService.GetPlayerSpirit(request2.SpiritId);
		if (playerSpirit == null)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<ToggleSpiritFavoriteResponse>>(Result<ToggleSpiritFavoriteResponse>.FailureResult("Spirit not found in player collection"));
		}
		var result = _stateService.ExecuteUpdate((Player player) => (!player.PlayerSpirits.ContainsKey(request2.SpiritId)) ? ValidationResult.Failure("Spirit not found in player's collection") : ValidationResult.Success(), delegate
		{
			bool flag = !playerSpirit.IsFavorite;
			playerSpirit.SetFavorite(flag);
			return new
			{
				IsFavorite = flag
			};
		}, (Player player, updateResult) =>
		{
			PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty)
			};
			playerBatchUpdate.AddSpiritFieldUpdate(request2.SpiritId, delegate(PlayerSpiritFieldUpdate update)
			{
				update.UpdateType = SpiritUpdateType.Favorite;
				update.SetFavorite = updateResult.IsFavorite;
			});
			return playerBatchUpdate;
		});
		if (!result.Success)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<ToggleSpiritFavoriteResponse>>(Result<ToggleSpiritFavoriteResponse>.FailureResult(result.ErrorMessage ?? "Failed to apply state update"));
		}
		return global::System.Threading.Tasks.Task.FromResult<Result<ToggleSpiritFavoriteResponse>>(Result<ToggleSpiritFavoriteResponse>.SuccessResult(new ToggleSpiritFavoriteResponse(request2.SpiritId, result.Data.IsFavorite)));
	}
}
