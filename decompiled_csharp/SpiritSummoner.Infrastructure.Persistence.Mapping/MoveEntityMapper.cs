using System;
using System.Collections.Generic;
using System.Linq;
using SpiritSummoner.Domain.Entities.Requirements;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Moves;

namespace SpiritSummoner.Infrastructure.Persistence.Mapping;

public static class MoveEntityMapper
{
	public static Move ToEntity(FirestoreMoveDTO firestoreDto)
	{
		ArgumentNullException.ThrowIfNull((object)firestoreDto, "firestoreDto");
		MoveRequirements unlockRequirements = ((firestoreDto.UnlockRequirements != null) ? new MoveRequirements(isFree: false, (firestoreDto.UnlockRequirements.RequiredItemRaw != null) ? firestoreDto.UnlockRequirements.RequiredItemRaw.Id : string.Empty, firestoreDto.UnlockRequirements.RequiredItemCount, firestoreDto.UnlockRequirements.PlayerLevelRequired, GetLevelRequired(firestoreDto.Power)) : new MoveRequirements(isFree: false, null, 0, 0));
		return Move.Rehydrate(firestoreDto.Name ?? string.Empty, firestoreDto.Type, firestoreDto.Power, firestoreDto.MoveType, unlockRequirements);
	}

	public static List<Move> ToEntities(global::System.Collections.Generic.IEnumerable<FirestoreMoveDTO> firestoreDtos)
	{
		return ((firestoreDtos != null) ? Enumerable.ToList<Move>(Enumerable.Select<FirestoreMoveDTO, Move>(firestoreDtos, (Func<FirestoreMoveDTO, Move>)ToEntity)) : null) ?? new List<Move>();
	}

	public static int GetLevelRequired(int power)
	{
		if (power <= 115)
		{
			if (power > 100)
			{
				if (power <= 110)
				{
					return 5;
				}
				return 10;
			}
			return 1;
		}
		if (power <= 125)
		{
			if (power <= 120)
			{
				return 15;
			}
			return 20;
		}
		if (power < 150)
		{
			return 25;
		}
		return 30;
	}
}
