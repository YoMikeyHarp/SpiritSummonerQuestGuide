using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Interfaces.Services;

namespace SpiritSummoner.Domain.Services;

public class SpiritProgressionService : ISpiritProgressionService
{
	public void LevelUp(PlayerSpirit playerSpirit)
	{
		playerSpirit.SetLevel(playerSpirit.Level + 1);
		playerSpirit.SetHP(playerSpirit.HP + 5);
		playerSpirit.AddTrainingPoints(10);
	}

	public void LevelUpMultiple(PlayerSpirit playerSpirit, int levels)
	{
		for (int i = 0; i < levels; i++)
		{
			LevelUp(playerSpirit);
		}
	}

	public int CalculateHPAtLevel(int baseHP, int level)
	{
		return baseHP + 5 * (level - 1);
	}

	public int CalculateTrainingPointsForLevel(int level)
	{
		return level * 10;
	}
}
