using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Guildmasterboard;

namespace SpiritSummoner.Infrastructure.Persistence.Mapping;

public static class LeaderboardMapper
{
	public static LeaderboardEntry ToEntity(FirestoreLeaderboardEntryDTO dto)
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		return new LeaderboardEntry
		{
			PlayerId = dto.PlayerId,
			PlayerName = dto.PlayerName,
			PlayerLevel = dto.PlayerLevel,
			Score = dto.Score,
			Title = dto.Title,
			Wins = dto.Wins,
			Losses = dto.Losses,
			LastUpdated = dto.LastUpdated
		};
	}

	public static FirestoreLeaderboardEntryDTO ToFirestoreDTO(LeaderboardEntry entity)
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		return new FirestoreLeaderboardEntryDTO
		{
			PlayerId = entity.PlayerId,
			PlayerName = entity.PlayerName,
			PlayerLevel = entity.PlayerLevel,
			Score = entity.Score,
			Title = entity.Title,
			Wins = entity.Wins,
			Losses = entity.Losses,
			LastUpdated = entity.LastUpdated
		};
	}
}
