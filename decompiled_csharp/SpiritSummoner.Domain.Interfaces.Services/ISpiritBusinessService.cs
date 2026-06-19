using SpiritSummoner.Domain.Entities.Spirits;

namespace SpiritSummoner.Domain.Interfaces.Services;

public interface ISpiritBusinessService
{
	int CalculateResetTrainingPointsCost(Spirit spirit);

	double CalculateLevelUpCost(int level);

	bool IsPhysicalAttacker(Spirit spirit);

	int CalculateMaxHP(int baseHp, int level);
}
