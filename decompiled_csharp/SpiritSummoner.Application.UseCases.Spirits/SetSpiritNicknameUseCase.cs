using System;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Application.UseCases.Spirits;

public class SetSpiritNicknameUseCase : IUseCase<SetSpiritNicknameRequest, SetSpiritNicknameResponse>
{
	private const int MAX_NICKNAME_LENGTH = 16;

	private readonly IPlayerStateService _stateService;

	public SetSpiritNicknameUseCase(IPlayerStateService stateService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
	}

	public global::System.Threading.Tasks.Task<Result<SetSpiritNicknameResponse>> ExecuteAsync(SetSpiritNicknameRequest request)
	{
		SetSpiritNicknameRequest request2 = request;
		if (string.IsNullOrEmpty(request2.SpiritId))
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<SetSpiritNicknameResponse>>(Result<SetSpiritNicknameResponse>.FailureResult("Spirit ID is required"));
		}
		if (request2.Nickname != null && request2.Nickname.Length > 16)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<SetSpiritNicknameResponse>>(Result<SetSpiritNicknameResponse>.ValidationFailureResult("Nickname", $"Nickname cannot exceed {16} characters"));
		}
		string nickname = request2.Nickname ?? string.Empty;
		var result = _stateService.ExecuteUpdate((Player player) => (!player.PlayerSpirits.ContainsKey(request2.SpiritId)) ? ValidationResult.Failure("Spirit not found in player's collection") : ValidationResult.Success(), delegate(Player player)
		{
			PlayerSpirit playerSpirit = player.PlayerSpirits[request2.SpiritId];
			playerSpirit.SetNickname(nickname);
			return new
			{
				Nickname = nickname
			};
		}, (Player player, updateResult) =>
		{
			PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty)
			};
			playerBatchUpdate.AddSpiritFieldUpdate(request2.SpiritId, delegate(PlayerSpiritFieldUpdate update)
			{
				update.UpdateType = SpiritUpdateType.Nickname;
				update.SetNickname = updateResult.Nickname;
			});
			return playerBatchUpdate;
		});
		if (!result.Success)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<SetSpiritNicknameResponse>>(Result<SetSpiritNicknameResponse>.FailureResult(result.ErrorMessage ?? "Failed to apply state update"));
		}
		return global::System.Threading.Tasks.Task.FromResult<Result<SetSpiritNicknameResponse>>(Result<SetSpiritNicknameResponse>.SuccessResult(new SetSpiritNicknameResponse(request2.SpiritId, nickname)));
	}
}
