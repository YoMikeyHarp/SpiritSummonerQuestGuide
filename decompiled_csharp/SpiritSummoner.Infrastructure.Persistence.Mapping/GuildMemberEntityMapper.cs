using System;
using System.Collections.Generic;
using System.Linq;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Enums.Guilds;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Guilds;

namespace SpiritSummoner.Infrastructure.Persistence.Mapping;

public static class GuildMemberEntityMapper
{
	public static GuildMember ToEntity(FirestoreGuildMemberDTO dto)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		ArgumentNullException.ThrowIfNull((object)dto, "dto");
		string? playerId = dto.PlayerId ?? string.Empty;
		string? playerName = dto.PlayerName ?? string.Empty;
		GuildRole guildRole = default(GuildRole);
		GuildRole role = ((!global::System.Enum.TryParse<GuildRole>(dto.Role, ref guildRole)) ? GuildRole.Member : guildRole);
		int level = dto.Level;
		int trophies = dto.Trophies;
		int contribution = dto.Contribution;
		int weeklyContribution = dto.WeeklyContribution;
		DateTimeOffset joinedAt = dto.JoinedAt;
		DateTimeOffset lastActiveAt = dto.LastActiveAt;
		bool isOnline = dto.IsOnline;
		string playerIcon = dto.PlayerIcon;
		return GuildMember.Rehydrate(playerId, playerName, role, level, trophies, contribution, weeklyContribution, joinedAt, lastActiveAt, isOnline, null, null, playerIcon);
	}

	public static FirestoreGuildMemberDTO ToDTO(GuildMember entity)
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		ArgumentNullException.ThrowIfNull((object)entity, "entity");
		return new FirestoreGuildMemberDTO
		{
			PlayerId = entity.PlayerId,
			PlayerName = entity.PlayerName,
			Role = ((object)entity.Role).ToString(),
			Level = entity.Level,
			Trophies = entity.Trophies,
			Contribution = entity.Contribution,
			WeeklyContribution = entity.WeeklyContribution,
			JoinedAt = entity.JoinedAt,
			LastActiveAt = entity.LastActiveAt,
			IsOnline = entity.IsOnline,
			PlayerIcon = entity.PlayerIcon
		};
	}

	public static Dictionary<string, GuildMember> ToEntityDictionary(global::System.Collections.Generic.IEnumerable<ValueTuple<string, FirestoreGuildMemberDTO>> members)
	{
		return Enumerable.ToDictionary<ValueTuple<string, FirestoreGuildMemberDTO>, string, GuildMember>(members, (Func<ValueTuple<string, FirestoreGuildMemberDTO>, string>)((ValueTuple<string, FirestoreGuildMemberDTO> m) => m.Item1), (Func<ValueTuple<string, FirestoreGuildMemberDTO>, GuildMember>)((ValueTuple<string, FirestoreGuildMemberDTO> m) => ToEntity(m.Item2)));
	}
}
