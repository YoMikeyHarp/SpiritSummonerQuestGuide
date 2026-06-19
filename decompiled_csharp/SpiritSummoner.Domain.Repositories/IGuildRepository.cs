using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpiritSummoner.Domain.Enums.Common;

namespace SpiritSummoner.Domain.Repositories;

public interface IGuildRepository : IGuildCoreRepository, IGuildMemberRepository, IGuildSearchRepository, IGuildWarRepository
{
	global::System.Threading.Tasks.Task<bool> AddGuildXPAsync(string guildId, int xpAmount, string? source = null);

	global::System.Threading.Tasks.Task<bool> UpdateGuildTrophiesAsync(string guildId, int trophyChange);

	global::System.Threading.Tasks.Task<bool> AddGuildCoinsAsync(string guildId, int coinsAmount);

	global::System.Threading.Tasks.Task<bool> SpendGuildCoinsAsync(string guildId, int coinsAmount);

	global::System.Threading.Tasks.Task<bool> SetWarEnrollmentAsync(string guildId, bool isOpenToWar);

	global::System.Threading.Tasks.Task<bool> ApplyGuildPerkAsync(string guildId, string perkKey, int tier, DateTimeOffset activatedAt, string activatedByPlayerId, int crystalCost);

	global::System.Threading.Tasks.Task SendNotificationToPlayerAsync(string targetPlayerId, NotificationType type, Dictionary<string, object> data);
}
