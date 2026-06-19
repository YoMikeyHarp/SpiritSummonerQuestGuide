using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;

namespace SpiritSummoner.Application.UseCases.Spirits;

public class SetActiveMoveUseCase : IUseCase<SetActiveMoveRequest, SetActiveMoveResponse>
{
	private const int MAX_ACTIVE_MOVES = 4;

	private readonly IPlayerStateService _stateService;

	public SetActiveMoveUseCase(IPlayerStateService stateService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
	}

	public global::System.Threading.Tasks.Task<Result<SetActiveMoveResponse>> ExecuteAsync(SetActiveMoveRequest request)
	{
		SetActiveMoveRequest request2 = request;
		if (string.IsNullOrEmpty(request2.SpiritId))
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<SetActiveMoveResponse>>(Result<SetActiveMoveResponse>.FailureResult("Spirit ID is required"));
		}
		if (string.IsNullOrEmpty(request2.MoveName))
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<SetActiveMoveResponse>>(Result<SetActiveMoveResponse>.FailureResult("Move name is required"));
		}
		var result = _stateService.ExecuteUpdate(delegate(Player player)
		{
			PlayerSpirit playerSpirit2 = default(PlayerSpirit);
			if (!player.PlayerSpirits.TryGetValue(request2.SpiritId, ref playerSpirit2))
			{
				return ValidationResult.Failure("Spirit not found in player's collection");
			}
			if (playerSpirit2.Moves == null || !playerSpirit2.Moves.ContainsKey(request2.MoveName))
			{
				return ValidationResult.Failure("Move not found for this spirit");
			}
			MoveState moveState2 = playerSpirit2.Moves[request2.MoveName];
			if (!moveState2.IsUnlocked)
			{
				return ValidationResult.Failure("Move must be unlocked before it can be set as active");
			}
			if (request2.SetAsActive)
			{
				int num = Enumerable.Count<KeyValuePair<string, MoveState>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, MoveState>>)playerSpirit2.Moves, (Func<KeyValuePair<string, MoveState>, bool>)((KeyValuePair<string, MoveState> m) => m.Value.IsActiveMove));
				if (num >= 4 && !moveState2.IsActiveMove)
				{
					return ValidationResult.Failure($"Maximum of {4} active moves allowed. Deactivate another move first.");
				}
			}
			return ValidationResult.Success();
		}, delegate(Player player)
		{
			PlayerSpirit playerSpirit = player.PlayerSpirits[request2.SpiritId];
			MoveState moveState = playerSpirit.Moves[request2.MoveName];
			playerSpirit.SetActiveMove(request2.MoveName, request2.SetAsActive);
			return new
			{
				MoveName = request2.MoveName,
				IsUnlocked = moveState.IsUnlocked,
				IsActive = request2.SetAsActive
			};
		}, (Player player, updateResult) =>
		{
			PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty)
			};
			playerBatchUpdate.AddSpiritFieldUpdate(request2.SpiritId, delegate(PlayerSpiritFieldUpdate update)
			{
				update.UpdateType = SpiritUpdateType.Moves;
				update.MoveChanges = new Dictionary<string, MoveStateUpdate> { [updateResult.MoveName] = new MoveStateUpdate
				{
					MoveName = updateResult.MoveName,
					IsUnlocked = updateResult.IsUnlocked,
					IsActiveMove = updateResult.IsActive
				} };
			});
			return playerBatchUpdate;
		});
		if (!result.Success)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<SetActiveMoveResponse>>(Result<SetActiveMoveResponse>.FailureResult(result.ErrorMessage ?? "Failed to apply state update"));
		}
		return global::System.Threading.Tasks.Task.FromResult<Result<SetActiveMoveResponse>>(Result<SetActiveMoveResponse>.SuccessResult(new SetActiveMoveResponse(request2.SpiritId, result.Data.MoveName, result.Data.IsActive)));
	}
}
