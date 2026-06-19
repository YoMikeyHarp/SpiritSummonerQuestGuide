using System.Collections.Generic;
using System.Threading.Tasks;
using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Domain.Repositories;

public interface IPlayerSpiritRepository
{
	global::System.Threading.Tasks.Task<PlayerSpirit?> GetByIdAsync(string playerId, string playerSpiritId);

	global::System.Threading.Tasks.Task<List<PlayerSpirit>> GetByIdsAsync(string playerId, List<string> playerSpiritIds);
}
