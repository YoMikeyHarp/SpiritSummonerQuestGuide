using Microsoft.Extensions.DependencyInjection;
using SpiritSummoner.Domain.Interfaces.Services;
using SpiritSummoner.Domain.Services;

namespace SpiritSummoner.Domain.Configuration;

public static class DependencyInjection
{
	public static IServiceCollection AddDomainServices(this IServiceCollection services)
	{
		ServiceCollectionServiceExtensions.AddSingleton<IPlayerProgressionService, PlayerProgressionService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IPlayerCurrencyService, PlayerCurrencyService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<ISpiritProgressionService, SpiritProgressionService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<ISpiritBusinessService, SpiritBusinessService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IBattleAIService, BattleAIService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<ISpecialAbilityService, SpecialAbilityService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IPlayerSpiritFactory, PlayerSpiritFactory>(services);
		ServiceCollectionServiceExtensions.AddSingleton<ISpiritMoveResolver, SpiritMoveResolver>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IPlayerFactory, PlayerFactory>(services);
		ServiceCollectionServiceExtensions.AddSingleton<SpiritStatDistributionService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IMoveUnlockService, MoveUnlockService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<ITypeEffectivenessService, TypeEffectivenessService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IBattleScoreCalculator, BattleScoreCalculator>(services);
		ServiceCollectionServiceExtensions.AddSingleton<BattleAIService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<SpiritStatDistributionService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<PlayerCurrencyService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<PlayerProgressionService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<SpiritBusinessService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<SpiritProgressionService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<SpiritStatDistributionService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<PlayerCurrencyService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<PlayerProgressionService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IPlayerInventoryService, PlayerInventoryService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IBattleCalculationService, BattleCalculationService>(services);
		return services;
	}
}
