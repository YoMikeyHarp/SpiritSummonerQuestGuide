using System;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Application.UseCases.Players;

public class SetPartnerSpiritUseCase : IUseCase<SetPartnerSpiritRequest, SetPartnerSpiritResponse>
{
	private readonly IPlayerStateService _stateService;

	public SetPartnerSpiritUseCase(IPlayerStateService stateService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
	}

	public global::System.Threading.Tasks.Task<Result<SetPartnerSpiritResponse>> ExecuteAsync(SetPartnerSpiritRequest request)
	{
		SetPartnerSpiritRequest request2 = request;
		if (string.IsNullOrEmpty(request2.SpiritId))
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<SetPartnerSpiritResponse>>(Result<SetPartnerSpiritResponse>.FailureResult("Spirit ID is required"));
		}
		Result<string> result = _stateService.ExecuteUpdate<string>((Player player) => (!player.PlayerSpirits.ContainsKey(request2.SpiritId)) ? ValidationResult.Failure("Spirit not found in player's collection") : ValidationResult.Success(), delegate(Player player)
		{
			player.SetPartnerSpirit(request2.SpiritId);
			return request2.SpiritId;
		}, (Player player, string spiritId) => new PlayerBatchUpdate
		{
			PlayerId = (player.PlayerID ?? string.Empty),
			ActiveBattleUnitId = spiritId,
			UpdateBattleUnit = true
		});
		if (!result.Success)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<SetPartnerSpiritResponse>>(Result<SetPartnerSpiritResponse>.FailureResult(result.ErrorMessage ?? "Failed to apply state update"));
		}
		return global::System.Threading.Tasks.Task.FromResult<Result<SetPartnerSpiritResponse>>(Result<SetPartnerSpiritResponse>.SuccessResult(new SetPartnerSpiritResponse(result.Data)));
	}
}
