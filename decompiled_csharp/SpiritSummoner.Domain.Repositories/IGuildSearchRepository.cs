using System.Collections.Generic;
using System.Threading.Tasks;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Presentation.ViewModels.Guilds;

namespace SpiritSummoner.Domain.Repositories;

public interface IGuildSearchRepository
{
	global::System.Threading.Tasks.Task<List<GuildSearchResult>> SearchGuildsAsync(string searchText = "", GuildSearchFilters? filters = null, int playerLevel = 1, long playerTrophies = 0L, int limit = 50);

	global::System.Threading.Tasks.Task<List<Guild>> GetTopGuildsByTrophiesAsync(int limit = 50);

	global::System.Threading.Tasks.Task<List<Guild>> GetRecommendedGuildsAsync(string playerId, int limit = 10);
}
