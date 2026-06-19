using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpiritSummoner.Domain.Entities.Guilds;

namespace SpiritSummoner.Domain.Repositories;

public interface IGuildWarRepository
{
	global::System.Threading.Tasks.Task<List<GuildWarHistory>> GetGuildWarHistoryAsync(string guildId, int limit = 20);

	global::System.Threading.Tasks.Task<bool> SignUpAsDefenderAsync(string guildId, string playerId, List<string> defenderSquad);

	global::System.Threading.Tasks.Task<bool> RemoveDefenderAsync(string guildId, string playerId);

	global::System.Threading.Tasks.Task<List<GuildMember>> GetDefendersAsync(string guildId);

	global::System.Threading.Tasks.Task<bool> SetMainDefendersAsync(string guildId, List<string> mainDefenderPlayerIds);

	global::System.Threading.Tasks.Task<List<GuildMember>> GetMainDefendersAsync(string guildId);

	global::System.Threading.Tasks.Task<int> RemoveExpiredDefendersAsync(string guildId);

	global::System.Threading.Tasks.Task<int> GetGuildCrystalsAsync(string guildId);

	global::System.Threading.Tasks.Task<bool> WriteRaidResultAsync(string defendingGuildId, string attackingGuildId, string warId, int crystalsGained, int startingCrystals, string attackingPlayerId, int newRaidCountThisHour, DateTimeOffset newRaidHourStart, int totalCrystalsRaidDelta);

	global::System.Threading.Tasks.Task<bool> UpdateAttackCountsAsync(string attackingGuildId, string defendingGuildId, string warId, Dictionary<string, long> playerAttackCounts, DateTimeOffset lastResetTime);

	global::System.Threading.Tasks.Task<GuildWarProgress?> GetWarProgressAsync(string attackingGuildId, string defendingGuildId, string warId);

	global::System.Threading.Tasks.Task<bool> WriteDefenderBattleResultAsync(string attackingGuildId, string defendingGuildId, string warId, bool isVictory, int startingCrystals, string defenderPlayerId, string? attackingPlayerId, int crystalsAwarded, DateTimeOffset? attackerHourlyStart, int attackerHourlyCrystals, int newDefenderDefeatedCount, DateTimeOffset defenderDowntimeEnds, DateTimeOffset? defenderLastFellAt, int defenderCrystalsGainedDelta);

	global::System.Threading.Tasks.Task<List<string>> GetAvailableDefendersAsync(string attackingGuildId, string defendingGuildId, string warId);

	global::System.Threading.Tasks.Task<GuildMember?> GetNextDefenderAsync(string attackingGuildId, string defendingGuildId, string warId);

	global::System.Threading.Tasks.Task<bool> RegisterAsDefenderAsync(Guild guild, string playerId, List<string> squadIds);

	global::System.Threading.Tasks.Task<bool> UnregisterAsDefenderAsync(string guildId, string playerId);

	global::System.Threading.Tasks.Task<bool> RefreshDefenderAsync(string guildId, string playerId);

	global::System.Threading.Tasks.Task<List<Guild>> GetWarBucketOpponentsAsync(string guildId);
}
