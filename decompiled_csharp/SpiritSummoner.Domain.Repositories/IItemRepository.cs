using System.Collections.Generic;
using System.Threading.Tasks;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Enums.Items;

namespace SpiritSummoner.Domain.Repositories;

public interface IItemRepository
{
	global::System.Threading.Tasks.Task<IReadOnlyDictionary<string, Item>> GetAllItemsAsync();

	global::System.Threading.Tasks.Task<IReadOnlyDictionary<string, Item>> GetAllGearsAsync();

	global::System.Threading.Tasks.Task<IReadOnlyDictionary<string, Item>> GetAllTalentsAsync();

	global::System.Threading.Tasks.Task<Item?> GetByIdAsync(string itemId);

	global::System.Threading.Tasks.Task<Item?> GetGearByIdAsync(string itemId);

	global::System.Threading.Tasks.Task<Item?> GetTalentByIdAsync(string itemId);

	global::System.Threading.Tasks.Task<global::System.Collections.Generic.IReadOnlyList<Item>> GetByTypeAsync(ItemType type);

	global::System.Threading.Tasks.Task<global::System.Collections.Generic.IReadOnlyList<Item?>> GetByIdsAsync(global::System.Collections.Generic.IEnumerable<string> itemIds);

	global::System.Threading.Tasks.Task<global::System.Collections.Generic.IReadOnlyList<Item>> GetItemsByTypeAndLevel(List<ItemType> itemTypes, int playerLevel);
}
