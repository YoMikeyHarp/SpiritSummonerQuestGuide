using System;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Infrastructure.Persistence.DTOs;

namespace SpiritSummoner.Infrastructure.Persistence.Mapping;

public static class InventoryEntityMapper
{
	public static Inventory ToEntity(FirestoreInventoryDTO firestoreDto)
	{
		ArgumentNullException.ThrowIfNull((object)firestoreDto, "firestoreDto");
		return new Inventory
		{
			Name = firestoreDto.Name,
			Amount = firestoreDto.Amount
		};
	}
}
