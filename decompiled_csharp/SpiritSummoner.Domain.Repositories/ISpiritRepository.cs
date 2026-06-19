using System.Collections.Generic;
using System.Threading.Tasks;
using SpiritSummoner.Domain.Entities.Spirits;

namespace SpiritSummoner.Domain.Repositories;

public interface ISpiritRepository
{
	IReadOnlyDictionary<string, Spirit> GetAll();

	Spirit? GetById(string spiritId);

	global::System.Threading.Tasks.Task<Spirit?> GetByIdAsync(string spiritId);
}
