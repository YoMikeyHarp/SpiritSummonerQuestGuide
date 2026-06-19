using System;
using System.Collections.Generic;
using System.Linq;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Enums.Spirits;
using SpiritSummoner.Domain.Interfaces.Services;

namespace SpiritSummoner.Domain.Services;

public class SpiritBusinessService : ISpiritBusinessService
{
	public int CalculateResetTrainingPointsCost(Spirit spirit)
	{
		return (spirit.Level - 1) * 50;
	}

	public double CalculateLevelUpCost(int level)
	{
		if (1 == 0)
		{
		}
		double result = ((level < 70) ? ((level < 10) ? ((level > 4) ? (40.0 + 10.0 * (double)(level - 4) + 2.5 * (double)(level - 4) * (double)(level - 3)) : ((double)level * 10.0)) : ((level >= 25) ? (1600.0 * Math.Pow(1.146, (double)(level - 26))) : (4.355 * Math.Pow((double)(level - 10), 2.0) + 170.0))) : ((level > 80) ? 3000000.0 : (800000.0 + 112700.0 * (double)(level - 70))));
		if (1 == 0)
		{
		}
		return result;
	}

	public int CalculateMaxHP(int baseHp, int level)
	{
		if (baseHp <= 0)
		{
			baseHp = 100;
		}
		return (int)Math.Round((double)baseHp * Math.Pow(1.045, (double)(level - 1)));
	}

	public bool IsPhysicalAttacker(Spirit spirit)
	{
		if (spirit.LearnableMoves == null)
		{
			return false;
		}
		int num = Enumerable.Count<Move>((global::System.Collections.Generic.IEnumerable<Move>)spirit.LearnableMoves, (Func<Move, bool>)((Move move) => move.MoveType == MoveType.Physical && (move.Type == SpiritType.Neutral || move.Type == SpiritType.Melee)));
		int num2 = Enumerable.Count<Move>((global::System.Collections.Generic.IEnumerable<Move>)spirit.LearnableMoves, (Func<Move, bool>)((Move move) => move.MoveType == MoveType.Special && move.Type != SpiritType.Neutral && move.Type != SpiritType.Melee));
		return num >= num2;
	}
}
