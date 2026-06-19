using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Domain.Interfaces.Services;

public interface IPlayerProgressionService
{
	int GainExperience(Player player, double exp);

	double CalculateNextEXPMax(int currentLevel);

	double CalculateNextEXPMax(double currentMaxEXP);

	double GetTotalEXPForLevel(int targetLevel);
}
