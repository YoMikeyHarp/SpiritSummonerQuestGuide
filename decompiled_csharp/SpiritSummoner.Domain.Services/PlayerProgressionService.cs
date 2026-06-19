using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Interfaces.Services;

namespace SpiritSummoner.Domain.Services;

public class PlayerProgressionService : IPlayerProgressionService
{
	public int GainExperience(Player player, double exp)
	{
		if (player.PlayerLevel >= 80)
		{
			return 0;
		}
		player.SetExperience(player.EXP + exp);
		int num = 0;
		while (player.EXP >= player.MaxEXP && player.PlayerLevel < 80)
		{
			player.SetExperience(player.EXP - player.MaxEXP);
			LevelUp(player);
			num++;
		}
		if (player.PlayerLevel >= 80)
		{
			player.SetExperience(0.0);
			player.SetMaxEXP(0.0);
		}
		return num;
	}

	private void LevelUp(Player player)
	{
		player.SetLevel(player.PlayerLevel + 1);
		player.SetMaxEXP(LevelExpCurve.GetExpBetweenLevels(player.PlayerLevel));
		if (player.PlayerLevel % 2 != 0)
		{
			player.SetMaxEP(player.MaxEP + 1);
		}
		if (player.PlayerLevel % 5 == 0)
		{
			player.SetMaxSP(player.MaxSP + 1);
		}
		player.SetEP(player.MaxEP);
		player.SetSP(player.MaxSP);
	}

	public double CalculateNextEXPMax(int currentLevel)
	{
		return LevelExpCurve.GetExpBetweenLevels(currentLevel);
	}

	public double CalculateNextEXPMax(double currentMaxEXP)
	{
		return LevelExpCurve.GetExpBetweenLevels(1);
	}

	public double GetTotalEXPForLevel(int targetLevel)
	{
		return LevelExpCurve.GetTotalExpForLevel(targetLevel);
	}
}
