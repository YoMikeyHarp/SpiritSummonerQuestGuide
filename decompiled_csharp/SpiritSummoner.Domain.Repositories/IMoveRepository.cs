using System.Collections.Generic;
using System.Threading.Tasks;
using SpiritSummoner.Domain.Entities.Spirits;

namespace SpiritSummoner.Domain.Repositories;

public interface IMoveRepository
{
	global::System.Threading.Tasks.Task<Move?> GetByIdAsync(string moveId);

	global::System.Threading.Tasks.Task<global::System.Collections.Generic.IReadOnlyList<Move>> GetByIdsAsync(global::System.Collections.Generic.IEnumerable<string> moveIds);

	global::System.Threading.Tasks.Task<global::System.Collections.Generic.IReadOnlyList<Move>> GetBySpiritAsync(string spiritId);

	global::System.Threading.Tasks.Task<IReadOnlyDictionary<string, Move>> GetAllAsync();
}
