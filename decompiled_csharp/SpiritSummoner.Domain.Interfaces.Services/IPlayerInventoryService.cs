using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Domain.Interfaces.Services;

public interface IPlayerInventoryService
{
	bool ModifyInventory(Player player, string itemId, int amount);

	bool HasEnoughReqItem(Player player, string itemId, int amount);

	int GetItemAmount(Player player, string itemId);
}
