using System;

namespace SpiritSummoner.Domain.Services;

public static class LevelExpCurve
{
	public const int MaxLevel = 80;

	public static long GetTotalExpForLevel(int level)
	{
		if (level <= 1)
		{
			return 0L;
		}
		if (level > 80)
		{
			level = 80;
		}
		long num = 0L;
		for (int i = 1; i < level; i++)
		{
			num += GetExpBetweenLevels(i);
		}
		return num;
	}

	public static long GetExpBetweenLevels(int level)
	{
		if (level >= 80)
		{
			return 0L;
		}
		if (1 == 0)
		{
		}
		long result = ((level < 60) ? ((level < 20) ? (10L * (long)level * level) : ((level >= 40) ? ((long)(25.0 * Math.Pow((double)level, 2.8))) : ((long)(15.0 * Math.Pow((double)level, 2.6))))) : ((level >= 70) ? ((long)(25.0 * Math.Pow((double)level, 2.8) * 1.5625)) : ((long)(25.0 * Math.Pow((double)level, 2.8) * 1.25))));
		if (1 == 0)
		{
		}
		return result;
	}
}
