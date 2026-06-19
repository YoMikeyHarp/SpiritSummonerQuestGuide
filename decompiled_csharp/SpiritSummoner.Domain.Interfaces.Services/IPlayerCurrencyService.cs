using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Domain.Interfaces.Services;

public interface IPlayerCurrencyService
{
	bool ModifyCurrency(Player player, string currencyType, long amount);

	void GainCurrency(Player player, int acqCurrency);

	bool HasEnoughCurrency(Player player, string currencyType, long amount);

	long GetCurrencyAmount(Player player, string currencyType);
}
