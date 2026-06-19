using System;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Application.UseCases.Players;

public class SwitchActiveSquadUseCase
{
	private readonly IPlayerStateService _stateService;

	public SwitchActiveSquadUseCase(IPlayerStateService stateService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
	}

	public global::System.Threading.Tasks.Task<Result<SwitchActiveSquadResponse>> ExecuteAsync(SwitchActiveSquadRequest request)
	{
		SwitchActiveSquadRequest request2 = request;
		if (request2.NewSquadSlot < 1 || request2.NewSquadSlot > 5)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<SwitchActiveSquadResponse>>(Result<SwitchActiveSquadResponse>.FailureResult("Squad slot must be between 1 and 5"));
		}
		Result<SwitchActiveSquadResponse> result = _stateService.ExecuteUpdate<SwitchActiveSquadResponse>(delegate(Player player)
		{
			string text = request2.NewSquadSlot.ToString();
			return (!player.Squads.ContainsKey(text)) ? ValidationResult.Failure("Squad slot does not exist") : ValidationResult.Success();
		}, delegate(Player player)
		{
			player.SetActiveSquadSlot(request2.NewSquadSlot);
			return new SwitchActiveSquadResponse(request2.NewSquadSlot);
		}, (Player player, SwitchActiveSquadResponse response) => new PlayerBatchUpdate
		{
			PlayerId = (player.PlayerID ?? string.Empty),
			NewActiveSquadSlot = request2.NewSquadSlot,
			UpdateActiveSquadSlot = true,
			NewActiveSquadComp = player.Squads[request2.NewSquadSlot.ToString()]
		});
		if (result.Success)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<SwitchActiveSquadResponse>>(Result<SwitchActiveSquadResponse>.SuccessResult(new SwitchActiveSquadResponse(request2.NewSquadSlot)));
		}
		return global::System.Threading.Tasks.Task.FromResult<Result<SwitchActiveSquadResponse>>(Result<SwitchActiveSquadResponse>.FailureResult(result.ErrorMessage ?? "Unknown error"));
	}
}
