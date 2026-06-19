using System;
using System.Collections.Generic;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Application.UseCases.Players;

public class UpdateSquadUseCase
{
	private readonly IPlayerStateService _stateService;

	public UpdateSquadUseCase(IPlayerStateService stateService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
	}

	public Result<UpdateSquadResponse> Execute(UpdateSquadRequest request)
	{
		UpdateSquadRequest request2 = request;
		if (request2.SquadSlot < 1 || request2.SquadSlot > 5)
		{
			return Result<UpdateSquadResponse>.FailureResult("Squad slot must be between 1 and 5");
		}
		if (request2.SpiritIds == null || request2.SpiritIds.Count != 3)
		{
			return Result<UpdateSquadResponse>.FailureResult("Squad must contain exactly 3 positions");
		}
		return _stateService.ExecuteUpdate<UpdateSquadResponse>((Player player) => ValidationResult.Success(), delegate(Player player)
		{
			player.UpdateSquad(request2.SquadSlot, request2.SpiritIds);
			if (request2.SetAsActive)
			{
				player.SetActiveSquadSlot(request2.SquadSlot);
			}
			return new UpdateSquadResponse(request2.SquadSlot, request2.SpiritIds, request2.SetAsActive);
		}, (Player player, UpdateSquadResponse response) => new PlayerBatchUpdate
		{
			PlayerId = (player.PlayerID ?? string.Empty),
			SquadUpdates = new Dictionary<string, List<string>> { [request2.SquadSlot.ToString()] = new List<string>((global::System.Collections.Generic.IEnumerable<string>)request2.SpiritIds) },
			UpdateActiveSquad = request2.SetAsActive,
			NewActiveSquadSlot = (request2.SetAsActive ? new int?(request2.SquadSlot) : null),
			NewActiveSquadComp = ((request2.SetAsActive || request2.SquadSlot == player.ActiveSquadSlot) ? new List<string>((global::System.Collections.Generic.IEnumerable<string>)request2.SpiritIds) : null)
		});
	}
}
