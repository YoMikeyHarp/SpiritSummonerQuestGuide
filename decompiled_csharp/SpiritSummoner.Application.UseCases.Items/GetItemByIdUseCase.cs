using System;
using System.Threading.Tasks;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Enums.Items;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Items;

public class GetItemByIdUseCase
{
	private readonly IItemRepository _itemRepository;

	public GetItemByIdUseCase(IItemRepository itemRepository)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_itemRepository = itemRepository ?? throw new ArgumentNullException("itemRepository");
	}

	public global::System.Threading.Tasks.Task<Item?> ExecuteAsync(string itemId, ItemType itemType)
	{
		if (1 == 0)
		{
		}
		global::System.Threading.Tasks.Task<Item> result = itemType switch
		{
			ItemType.items => _itemRepository.GetByIdAsync(itemId), 
			ItemType.gear => _itemRepository.GetGearByIdAsync(itemId), 
			ItemType.talent => _itemRepository.GetTalentByIdAsync(itemId), 
			_ => _itemRepository.GetByIdAsync(itemId), 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
