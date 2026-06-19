using System;

namespace SpiritSummoner.Domain.Services;

public class BattleScoreCalculator : IBattleScoreCalculator
{
	public int CalculateScoreChange(bool playerWon, int playerLevel, int opponentLevel, int currentScore, int livingSpiritsCount, double totalHealthPercentage, int timesFoughtRecently = 0)
	{
		if (playerWon)
		{
			return CalculateWinScore(playerLevel, opponentLevel, currentScore, livingSpiritsCount, totalHealthPercentage, timesFoughtRecently);
		}
		return CalculateLossScore(playerLevel, opponentLevel, currentScore);
	}

	public string GetTitle(int score, int globalRank)
	{
		if (globalRank == 1)
		{
			return "Grand Summoner King";
		}
		if (1 == 0)
		{
		}
		string result = ((score >= 10000) ? ((score >= 16000) ? ((score >= 25000) ? "Arch Summoner" : ((score < 20000) ? "Void Walker" : "High Summoner")) : ((score < 13000) ? "Spirit Lord" : "Master Summoner")) : ((score >= 2000) ? ((score >= 5000) ? ((score < 7500) ? "Champion" : "Grand Champion") : ((score < 3500) ? "Elite Summoner" : "Battle Mage")) : ((score >= 500) ? ((score < 1000) ? "Adept" : "Mystic") : ((score < 250) ? "Novice" : "Apprentice"))));
		if (1 == 0)
		{
		}
		return result;
	}

	private static int CalculateWinScore(int playerLevel, int opponentLevel, int currentScore, int livingSpiritsCount, double totalHealthPercentage, int timesFoughtRecently)
	{
		double num = ((currentScore >= 16000) ? 10.0 : ((currentScore >= 10000) ? 15.0 : ((currentScore >= 5000) ? 20.0 : 30.0)));
		int num2 = opponentLevel - playerLevel;
		double num3 = 1.0;
		if (num2 > 0)
		{
			num3 = Math.Min(1.5, 1.0 + (double)num2 * 0.05);
		}
		else if (num2 < 0)
		{
			num3 = Math.Max(0.1, 1.0 + (double)num2 * 0.1);
		}
		double num4 = (double)livingSpiritsCount * 5.0;
		double num5 = totalHealthPercentage * 10.0 * 2.0;
		double num6 = Math.Pow(0.75, (double)timesFoughtRecently);
		double num7 = (num * num3 + num4 + num5) * num6;
		return (int)Math.Max(1.0, Math.Round(num7));
	}

	private static int CalculateLossScore(int playerLevel, int opponentLevel, int currentScore)
	{
		double num = ((currentScore >= 16000) ? (-60.0) : ((currentScore >= 10000) ? (-45.0) : ((currentScore >= 5000) ? (-35.0) : (-25.0))));
		int num2 = opponentLevel - playerLevel;
		int num3 = 0;
		if (num2 < -2)
		{
			num3 = Math.Abs(num2 + 2) * -10;
		}
		if (num2 > 5)
		{
			num *= 0.5;
		}
		double num4 = num + (double)num3;
		return (int)Math.Min(-15.0, Math.Round(num4));
	}
}
