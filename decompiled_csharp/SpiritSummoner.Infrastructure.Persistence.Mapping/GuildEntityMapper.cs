using System;
using System.Collections.Generic;
using System.Linq;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Enums.Guilds;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Guilds;

namespace SpiritSummoner.Infrastructure.Persistence.Mapping;

public static class GuildEntityMapper
{
	public static Guild ToEntity(FirestoreGuildDTO dto)
	{
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		ArgumentNullException.ThrowIfNull((object)dto, "dto");
		Dictionary<string, FirestoreGuildDefenderDTO>? defenders = dto.Defenders;
		Dictionary<string, DefenderData> defenders2 = ((defenders != null) ? Enumerable.ToDictionary<KeyValuePair<string, FirestoreGuildDefenderDTO>, string, DefenderData>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreGuildDefenderDTO>>)defenders, (Func<KeyValuePair<string, FirestoreGuildDefenderDTO>, string>)((KeyValuePair<string, FirestoreGuildDefenderDTO> kv) => kv.Key), (Func<KeyValuePair<string, FirestoreGuildDefenderDTO>, DefenderData>)((KeyValuePair<string, FirestoreGuildDefenderDTO> kv) => new DefenderData(kv.Value.SquadIds ?? new List<string>(), kv.Value.SignUpAt, kv.Value.ExpiresAt, kv.Value.IsMainDefender, kv.Value.DowntimeEnds))) : null);
		Dictionary<string, FirestoreGuildActivePerkDTO>? activePerks = dto.ActivePerks;
		GuildPerkType guildPerkType = default(GuildPerkType);
		Dictionary<string, GuildActivePerk> activePerks2 = ((activePerks != null) ? Enumerable.ToDictionary<KeyValuePair<string, FirestoreGuildActivePerkDTO>, string, GuildActivePerk>(Enumerable.Where<KeyValuePair<string, FirestoreGuildActivePerkDTO>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreGuildActivePerkDTO>>)activePerks, (Func<KeyValuePair<string, FirestoreGuildActivePerkDTO>, bool>)((KeyValuePair<string, FirestoreGuildActivePerkDTO> kv) => global::System.Enum.TryParse<GuildPerkType>(kv.Key, ref guildPerkType))), (Func<KeyValuePair<string, FirestoreGuildActivePerkDTO>, string>)((KeyValuePair<string, FirestoreGuildActivePerkDTO> kv) => kv.Key), (Func<KeyValuePair<string, FirestoreGuildActivePerkDTO>, GuildActivePerk>)((KeyValuePair<string, FirestoreGuildActivePerkDTO> kv) => GuildActivePerk.Rehydrate(global::System.Enum.Parse<GuildPerkType>(kv.Key), kv.Value.Tier, kv.Value.ActivatedAt, kv.Value.ActivatedByPlayerId ?? string.Empty))) : null);
		return Guild.Rehydrate(dto.ID, dto.Name, dto.Description, dto.Emblem ?? "\ud83d\udc51", dto.Rank, dto.Level, dto.CurrentXP, dto.XPForNextLevel, dto.LeaderPlayerId, dto.MemberCount, dto.MaxMembers, null, dto.Crystals, dto.StartingCrystals, defenders2, dto.CurrentSeasonStartDate, dto.CurrentSeasonEndDate, dto.CurrentWarId, dto.IsOpenToWar, dto.GuildBreakEndsAt, dto.Trophies, dto.TotalWins, dto.TotalLosses, dto.GuildCoins, dto.IsPublic, dto.RequiresApproval, dto.MinLevelRequired, dto.MinTrophiesRequired, dto.CreatedAt, dto.LastActivityAt, dto.DisbandScheduledAt, activePerks2);
	}

	public static FirestoreGuildDTO ToDTO(Guild entity)
	{
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		ArgumentNullException.ThrowIfNull((object)entity, "entity");
		return new FirestoreGuildDTO
		{
			ID = entity.ID,
			Name = entity.Name,
			Description = entity.Description,
			Emblem = entity.Emblem,
			Rank = entity.Rank,
			Level = entity.Level,
			CurrentXP = entity.CurrentXP,
			XPForNextLevel = entity.XPForNextLevel,
			LeaderPlayerId = entity.LeaderPlayerId,
			MemberCount = entity.MemberCount,
			MaxMembers = entity.MaxMembers,
			Trophies = entity.Trophies,
			TotalWins = entity.TotalWins,
			TotalLosses = entity.TotalLosses,
			GuildCoins = entity.GuildCoins,
			IsOpenToWar = entity.IsOpenToWar,
			CurrentWarId = entity.CurrentWarId,
			GuildBreakEndsAt = entity.GuildBreakEndsAt,
			CurrentSeasonStartDate = entity.CurrentSeasonStartDate,
			CurrentSeasonEndDate = entity.CurrentSeasonEndDate,
			Crystals = entity.Crystals,
			StartingCrystals = entity.StartingCrystals,
			Defenders = Enumerable.ToDictionary<KeyValuePair<string, DefenderData>, string, FirestoreGuildDefenderDTO>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, DefenderData>>)entity.Defenders, (Func<KeyValuePair<string, DefenderData>, string>)((KeyValuePair<string, DefenderData> kv) => kv.Key), (Func<KeyValuePair<string, DefenderData>, FirestoreGuildDefenderDTO>)((KeyValuePair<string, DefenderData> kv) => new FirestoreGuildDefenderDTO
			{
				SquadIds = kv.Value.SquadIds,
				SignUpAt = kv.Value.SignUpAt,
				ExpiresAt = kv.Value.ExpiresAt,
				IsMainDefender = kv.Value.IsMainDefender,
				DowntimeEnds = kv.Value.DowntimeEnds
			})),
			IsPublic = entity.IsPublic,
			RequiresApproval = entity.RequiresApproval,
			MinLevelRequired = entity.MinLevelRequired,
			MinTrophiesRequired = entity.MinTrophiesRequired,
			CreatedAt = entity.CreatedAt,
			LastActivityAt = entity.LastActivityAt,
			DisbandScheduledAt = entity.DisbandScheduledAt,
			ActivePerks = ((entity.ActivePerks.Count > 0) ? Enumerable.ToDictionary<KeyValuePair<string, GuildActivePerk>, string, FirestoreGuildActivePerkDTO>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, GuildActivePerk>>)entity.ActivePerks, (Func<KeyValuePair<string, GuildActivePerk>, string>)((KeyValuePair<string, GuildActivePerk> kv) => kv.Key), (Func<KeyValuePair<string, GuildActivePerk>, FirestoreGuildActivePerkDTO>)((KeyValuePair<string, GuildActivePerk> kv) => new FirestoreGuildActivePerkDTO
			{
				Tier = kv.Value.Tier,
				ActivatedAt = kv.Value.ActivatedAt,
				ActivatedByPlayerId = kv.Value.ActivatedByPlayerId
			})) : null)
		};
	}
}
