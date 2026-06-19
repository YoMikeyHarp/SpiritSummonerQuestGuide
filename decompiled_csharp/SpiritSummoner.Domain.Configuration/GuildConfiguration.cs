namespace SpiritSummoner.Domain.Configuration;

public static class GuildConfiguration
{
	public const int MaxDefenders = 25;

	public const int MaxMainDefenders = 5;

	public const int RequiredDefenderSquadSize = 3;

	public const int DefenderExpirationHours = 30;

	public const double MainDefenderSelectionProbability = 0.75;

	public const int DefenderDowntimeMinutes = 30;

	public const int GuildBreakMinutes = 30;

	public const int InitialWarAttacks = 3;

	public const int RaidCooldownHours = 1;

	public const int OpponentRefreshCooldownHours = 4;

	public const double DefenderCrystalPercentMin = 0.05;

	public const double DefenderCrystalPercentMax = 0.08;

	public const double DefenderCrystalCapPercent = 0.15;

	public const double RaidBasePercent = 0.02;

	public const int MaxRaidsPerHour = 1;

	public const double RaidDecayFactor = 0.25;

	public const double DefenseRewardPercentMin = 0.03;

	public const double DefenseRewardPercentMax = 0.05;

	public const int HourlyMaxCrystals = 500;

	public const int BonusCrystalThreshold = 1000;

	public const int BonusCrystalXP = 1000;

	public const double DefenseFatigue4hThreshold = 4.0;

	public const double DefenseFatigue4hMultiplier = 1.5;

	public const double DefenseFatigue8hThreshold = 8.0;

	public const double DefenseFatigue8hMultiplier = 2.0;

	public const int StartingCrystalsTier1MaxLevel = 5;

	public const int StartingCrystalsTier2MaxLevel = 10;

	public const int StartingCrystalsTier1 = 1000;

	public const int StartingCrystalsTier2 = 1500;

	public const int StartingCrystalsTier3 = 2000;

	public const int CrystalsPerTrophyUnit = 100;

	public const int TrophiesPerUnit = 10;

	public const int MaxLevelDifferenceForAttack = 5;

	public const int DefaultOpponentLimit = 5;

	public static double GetRaidIndexMultiplier(int raidIndexInHour)
	{
		if (1 == 0)
		{
		}
		double result = raidIndexInHour switch
		{
			0 => 0.5, 
			1 => 1.0, 
			_ => 1.5, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static int GetStartingCrystals(int guildLevel)
	{
		if (guildLevel < 5)
		{
			return 1000;
		}
		if (guildLevel < 10)
		{
			return 1500;
		}
		return 2000;
	}

	public static int CalculateTrophiesFromCrystals(int crystals)
	{
		return crystals / 100 * 10;
	}
}
