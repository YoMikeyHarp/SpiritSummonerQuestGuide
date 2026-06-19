using System;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Interfaces.Services;

namespace SpiritSummoner.Application.UseCases.Players;

public class GainExperienceUseCase
{
	private readonly IPlayerStateService _stateService;

	private readonly IPlayerProgressionService _progressionService;

	public GainExperienceUseCase(IPlayerStateService stateService, IPlayerProgressionService progressionService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
		_progressionService = progressionService ?? throw new ArgumentNullException("progressionService");
	}

	public Result<GainExperienceResponse> Execute(GainExperienceRequest request)
	{
		GainExperienceRequest request2 = request;
		if (request2.ExperienceAmount <= 0.0)
		{
			return Result<GainExperienceResponse>.FailureResult("Experience amount must be greater than 0");
		}
		int originalLevel = 0;
		return _stateService.ExecuteUpdate<GainExperienceResponse>(delegate(Player player)
		{
			originalLevel = player.PlayerLevel;
			return ValidationResult.Success();
		}, delegate(Player player)
		{
			int num = _progressionService.GainExperience(player, request2.ExperienceAmount);
			bool leveledUp = num > originalLevel;
			return new GainExperienceResponse(request2.ExperienceAmount, num, leveledUp, player.MaxEXP, player.MaxEP, player.MaxSP);
		}, (Player player, GainExperienceResponse response) => new PlayerBatchUpdate
		{
			PlayerId = (player.PlayerID ?? string.Empty),
			ExperienceGain = (int)request2.ExperienceAmount,
			UpdateLevel = response.LeveledUp,
			UpdateMaxEXP = response.LeveledUp,
			NewPlayerLevel = response.NewLevel,
			NewMaxEXP = (response.LeveledUp ? player.MaxEXP : player.MaxEXP),
			NewMaxEP = (response.LeveledUp ? player.MaxEP : 0),
			NewMaxSP = (response.LeveledUp ? player.MaxSP : 0)
		});
	}
}
