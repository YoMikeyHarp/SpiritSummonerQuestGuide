using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpiritSummoner.Domain.Repositories;

public interface ILeaderboardRepository
{
	global::System.Threading.Tasks.Task<List<LeaderboardEntry>> GetTopPlayersAsync(int count);

	global::System.Threading.Tasks.Task<List<LeaderboardEntry>> GetPlayersAroundRankAsync(string playerId, int rangeAbove, int rangeBelow);

	global::System.Threading.Tasks.Task<LeaderboardEntry?> GetPlayerEntryAsync(string playerId);

	global::System.Threading.Tasks.Task<int> GetPlayerRankAsync(string playerId);

	global::System.Threading.Tasks.Task<bool> UpsertLeaderboardEntryAsync(LeaderboardEntry entry);
}
