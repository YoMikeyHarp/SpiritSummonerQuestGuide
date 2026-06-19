using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Interfaces.Services;

namespace SpiritSummoner.Application.UseCases.Battles;

public class ClaimDailyBattleChestUseCase : IUseCase<ClaimDailyBattleChestRequest, BattleChestReward>
{
	private readonly IPlayerStateService _stateService;

	private readonly IPlayerCurrencyService _currencyService;

	private const long GoldReward = 200L;

	private const int EnergyReward = 2;

	public ClaimDailyBattleChestUseCase(IPlayerStateService stateService, IPlayerCurrencyService currencyService)
	{
		_stateService = stateService;
		_currencyService = currencyService;
	}

	public global::System.Threading.Tasks.Task<Result<BattleChestReward>> ExecuteAsync(ClaimDailyBattleChestRequest request)
	{
		Result<BattleChestReward> result = _stateService.ExecuteUpdate<BattleChestReward>(delegate(Player player)
		{
			DailyBattleChest dailyBattleChest = player.DailyBattleChest;
			if (!dailyBattleChest.IsChestFull)
			{
				return ValidationResult.Failure("Chest is not full yet");
			}
			return dailyBattleChest.IsClaimed ? ValidationResult.Failure("Chest already claimed today") : ValidationResult.Success();
		}, [CompilerGenerated] (Player player) =>
		{
			player.DailyBattleChest.MarkClaimed();
			_currencyService.ModifyCurrency(player, "gold", 200L);
			player.SetEP(Math.Min(player.EP + 2, player.MaxEP));
			return new BattleChestReward(200L, 2);
		}, (Player player, BattleChestReward reward) => new PlayerBatchUpdate
		{
			PlayerId = (player.PlayerID ?? string.Empty),
			CurrencyChanges = new Dictionary<string, long> { ["gold"] = 200L },
			NewEP = player.EP,
			DailyBattleChestUpdate = new DailyBattleChestUpdate(player.DailyBattleChest.BattlesCompleted, player.DailyBattleChest.LastClaimedAt, player.DailyBattleChest.LastResetAt)
		});
		return global::System.Threading.Tasks.Task.FromResult<Result<BattleChestReward>>(result);
	}
}
