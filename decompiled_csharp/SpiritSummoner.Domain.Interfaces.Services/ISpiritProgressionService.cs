using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Domain.Interfaces.Services;

public interface ISpiritProgressionService
{
	void LevelUp(PlayerSpirit playerSpirit);

	void LevelUpMultiple(PlayerSpirit playerSpirit, int levels);

	int CalculateHPAtLevel(int baseHP, int level);

	int CalculateTrainingPointsForLevel(int level);
}
