using System.Collections.Generic;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Interfaces.Services;

namespace SpiritSummoner.Domain.Services;

public class PlayerInventoryService : IPlayerInventoryService
{
	public bool ModifyInventory(Player player, string itemId, int amount)
	{
		Inventory inventory = default(Inventory);
		int num = (player.Inventory.TryGetValue(itemId, ref inventory) ? inventory.Amount : 0);
		if (amount < 0 && num + amount < 0)
		{
			return false;
		}
		player.AddInventoryItem(itemId, amount);
		return true;
	}

	public bool HasEnoughReqItem(Player player, string itemId, int amount)
	{
		if (player.Inventory == null || ((global::System.Collections.Generic.IReadOnlyCollection<KeyValuePair<string, Inventory>>)player.Inventory).Count == 0)
		{
			return amount <= 0;
		}
		Inventory inventory = default(Inventory);
		return player.Inventory.TryGetValue(itemId, ref inventory) && inventory.Amount >= amount;
	}

	public int GetItemAmount(Player player, string itemId)
	{
		if (player.Inventory == null || ((global::System.Collections.Generic.IReadOnlyCollection<KeyValuePair<string, Inventory>>)player.Inventory).Count == 0)
		{
			return 0;
		}
		Inventory inventory = default(Inventory);
		return player.Inventory.TryGetValue(itemId, ref inventory) ? inventory.Amount : 0;
	}
}
