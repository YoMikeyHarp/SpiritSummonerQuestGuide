using System.Collections.Generic;
using SpiritSummoner.Domain.Entities.Spirits;

namespace SpiritSummoner.Domain.Interfaces.Services;

public interface ISpiritMoveResolver
{
	Move? FindMoveTemplate(string moveName, Spirit currentTemplate);

	global::System.Collections.Generic.IReadOnlyList<Move> GetAllMovesAcrossChain(Spirit currentTemplate);
}
