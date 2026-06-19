using SpiritSummoner.Domain.Entities.Requirements;
using SpiritSummoner.Domain.Entities.Spirits;

namespace SpiritSummoner.Domain.Interfaces.Services;

public interface IMoveUnlockService
{
	MoveRequirements CalculateUnlockRequirements(Move move);

	void SetUnlockRequirements(Move move);
}
