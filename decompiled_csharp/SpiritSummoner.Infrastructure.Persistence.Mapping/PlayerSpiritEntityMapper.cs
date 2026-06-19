using System;
using System.Collections.Generic;
using System.Linq;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Moves;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Players;

namespace SpiritSummoner.Infrastructure.Persistence.Mapping;

public static class PlayerSpiritEntityMapper
{
	public static PlayerSpirit ToEntity(FirestorePlayerSpiritDTO firestoreDto)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		ArgumentNullException.ThrowIfNull((object)firestoreDto, "firestoreDto");
		Dictionary<string, FirestoreMoveStateDTO>? moves = firestoreDto.Moves;
		Dictionary<string, MoveState> moves2 = ((moves != null) ? Enumerable.ToDictionary<KeyValuePair<string, FirestoreMoveStateDTO>, string, MoveState>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreMoveStateDTO>>)moves, (Func<KeyValuePair<string, FirestoreMoveStateDTO>, string>)((KeyValuePair<string, FirestoreMoveStateDTO> kvp) => kvp.Key), (Func<KeyValuePair<string, FirestoreMoveStateDTO>, MoveState>)((KeyValuePair<string, FirestoreMoveStateDTO> kvp) => new MoveState
		{
			IsActiveMove = kvp.Value.IsActiveMove,
			IsUnlocked = kvp.Value.IsUnlocked
		})) : null);
		return PlayerSpirit.Rehydrate(firestoreDto.PlayerSpiritID, firestoreDto.PlayerName, firestoreDto.Name, firestoreDto.Nickname, firestoreDto.DateOwned, firestoreDto.BaseSpiritID, firestoreDto.Level, firestoreDto.HP, firestoreDto.TrainingPoints, firestoreDto.PointsATK, firestoreDto.PointsDEF, firestoreDto.PointsSATK, firestoreDto.PointsSDEF, firestoreDto.PointsSPD, firestoreDto.PointsINT, moves2, firestoreDto.IsFavorite, firestoreDto.HeldItemID, firestoreDto.GearID, firestoreDto.TalentID);
	}
}
