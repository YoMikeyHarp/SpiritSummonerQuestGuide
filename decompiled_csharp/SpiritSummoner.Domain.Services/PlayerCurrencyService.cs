using System.Collections.Generic;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Interfaces.Services;

namespace SpiritSummoner.Domain.Services;

public class PlayerCurrencyService : IPlayerCurrencyService
{
	public bool ModifyCurrency(Player player, string currencyType, long amount)
	{
		IReadOnlyDictionary<string, long> currencies = player.Currencies;
		long num = ((currencies != null) ? CollectionExtensions.GetValueOrDefault<string, long>(currencies, currencyType, 0L) : 0);
		if (amount < 0 && num + amount < 0)
		{
			return false;
		}
		player.AddCurrency(currencyType, amount);
		return true;
	}

	public void GainCurrency(Player player, int acqCurrency)
	{
		player.AddCurrency("gold", acqCurrency);
	}

	public bool HasEnoughCurrency(Player player, string currencyType, long amount)
	{
		if (player.Currencies == null || !player.Currencies.ContainsKey(currencyType))
		{
			return amount <= 0;
		}
		return player.Currencies[currencyType] >= amount;
	}

	public long GetCurrencyAmount(Player player, string currencyType)
	{
		if (player.Currencies == null || !player.Currencies.ContainsKey(currencyType))
		{
			return 0L;
		}
		return player.Currencies[currencyType];
	}
}
