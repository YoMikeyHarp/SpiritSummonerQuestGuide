using System;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Application.UseCases.Players;

public class UpdatePlayerIconUseCase : IUseCase<UpdatePlayerIconRequest, UpdatePlayerIconResponse>
{
	private readonly IPlayerStateService _stateService;

	public UpdatePlayerIconUseCase(IPlayerStateService stateService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
	}

	public global::System.Threading.Tasks.Task<Result<UpdatePlayerIconResponse>> ExecuteAsync(UpdatePlayerIconRequest request)
	{
		UpdatePlayerIconRequest request2 = request;
		if (string.IsNullOrEmpty(request2.IconFile))
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<UpdatePlayerIconResponse>>(Result<UpdatePlayerIconResponse>.FailureResult("Icon file is required"));
		}
		Result<string> result = _stateService.ExecuteUpdate<string>((Player player) => ValidationResult.Success(), delegate(Player player)
		{
			player.SetPlayerIcon(request2.IconFile);
			return request2.IconFile;
		}, (Player player, string icon) => new PlayerBatchUpdate
		{
			PlayerId = (player.PlayerID ?? string.Empty),
			NewPlayerIcon = icon,
			CurrentGuildId = player.GuildId
		});
		if (!result.Success)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<UpdatePlayerIconResponse>>(Result<UpdatePlayerIconResponse>.FailureResult(result.ErrorMessage ?? "Failed to update icon"));
		}
		return global::System.Threading.Tasks.Task.FromResult<Result<UpdatePlayerIconResponse>>(Result<UpdatePlayerIconResponse>.SuccessResult(new UpdatePlayerIconResponse(result.Data)));
	}
}
