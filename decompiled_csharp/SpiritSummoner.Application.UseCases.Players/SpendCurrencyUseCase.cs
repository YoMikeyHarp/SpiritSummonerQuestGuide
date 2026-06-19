using System;
using System.Collections.Generic;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Application.UseCases.Players;

public class SpendCurrencyUseCase
{
	private readonly IPlayerStateService _stateService;

	public SpendCurrencyUseCase(IPlayerStateService stateService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
	}

	public Result<SpendCurrencyResponse> Execute(SpendCurrencyRequest request)
	{
		SpendCurrencyRequest request2 = request;
		if (string.IsNullOrEmpty(request2.CurrencyType))
		{
			return Result<SpendCurrencyResponse>.FailureResult("Currency type is required");
		}
		if (request2.Amount <= 0)
		{
			return Result<SpendCurrencyResponse>.FailureResult("Amount must be greater than 0");
		}
		return _stateService.ExecuteUpdate<SpendCurrencyResponse>(delegate(Player player)
		{
			long valueOrDefault = CollectionExtensions.GetValueOrDefault<string, long>(player.Currencies, request2.CurrencyType, 0L);
			return (valueOrDefault < request2.Amount) ? ValidationResult.Failure($"Insufficient {request2.CurrencyType}. Need {request2.Amount}, have {valueOrDefault}") : ValidationResult.Success();
		}, delegate(Player player)
		{
			player.AddCurrency(request2.CurrencyType, -request2.Amount);
			return new SpendCurrencyResponse(request2.CurrencyType, request2.Amount, player.Currencies[request2.CurrencyType]);
		}, (Player player, SpendCurrencyResponse response) => new PlayerBatchUpdate
		{
			PlayerId = (player.PlayerID ?? string.Empty),
			CurrencyChanges = new Dictionary<string, long> { [request2.CurrencyType] = -request2.Amount }
		});
	}
}
