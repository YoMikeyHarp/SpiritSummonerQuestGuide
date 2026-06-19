using System;
using System.Collections.Generic;
using System.Linq;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Enums.Spirits;
using SpiritSummoner.Domain.Interfaces.Services;
using SpiritSummoner.Domain.ValueObjects.Battle;

namespace SpiritSummoner.Domain.Services;

public class BattleAIService : IBattleAIService
{
	private readonly ITypeEffectivenessService _typeEffectivenessService;

	private readonly ISpiritMoveResolver _moveResolver;

	public BattleAIService(ITypeEffectivenessService typeEffectivenessService, ISpiritMoveResolver moveResolver)
	{
		_typeEffectivenessService = typeEffectivenessService;
		_moveResolver = moveResolver;
	}

	public Move GetRandomMove(PlayerSpirit playerSpirit, Spirit baseSpirit, BattleSprite attacker, BattleSprite defender)
	{
		Spirit baseSpirit2 = baseSpirit;
		BattleSprite attacker2 = attacker;
		BattleSprite defender2 = defender;
		IReadOnlyDictionary<string, MoveState>? moves = playerSpirit.Moves;
		List<Move> val = ((moves != null) ? Enumerable.ToList<Move>(Enumerable.Select<Move, Move>(Enumerable.Where<Move>(Enumerable.Select<KeyValuePair<string, MoveState>, Move>(Enumerable.Where<KeyValuePair<string, MoveState>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, MoveState>>)moves, (Func<KeyValuePair<string, MoveState>, bool>)((KeyValuePair<string, MoveState> m) => m.Value.IsActiveMove)), (Func<KeyValuePair<string, MoveState>, Move>)((KeyValuePair<string, MoveState> m) => _moveResolver.FindMoveTemplate(m.Key, baseSpirit2))), (Func<Move, bool>)((Move move) => move != null)), (Func<Move, Move>)((Move move) => move))) : null) ?? new List<Move>();
		if (val.Count == 0)
		{
			return new Move
			{
				Name = "null"
			};
		}
		List<double> val2 = Enumerable.ToList<double>(Enumerable.Select<Move, double>((global::System.Collections.Generic.IEnumerable<Move>)val, (Func<Move, double>)((Move move) => CalculateDesirability(move, attacker2, defender2))));
		double maxD = Enumerable.Max((global::System.Collections.Generic.IEnumerable<double>)val2);
		List<double> desirabilities = ((maxD > 0.0) ? Enumerable.ToList<double>(Enumerable.Select<double, double>((global::System.Collections.Generic.IEnumerable<double>)val2, (Func<double, double>)((double d) => d / maxD))) : val2);
		double beta = Math.Min((double)attacker2.INT / 100.0, 6.0);
		List<double> val3 = Softmax(desirabilities, beta);
		double num = Random.Shared.NextDouble();
		double num2 = 0.0;
		for (int i = 0; i < val3.Count; i++)
		{
			num2 += val3[i];
			if (num < num2)
			{
				return val[i];
			}
		}
		return val[val.Count - 1];
	}

	private double CalculateDesirability(Move move, BattleSprite attacker, BattleSprite defender)
	{
		double totalEffectiveness = _typeEffectivenessService.GetTotalEffectiveness(move.Type, defender.BaseSpirit.Type1, defender.BaseSpirit.Type2);
		double num = 1.0;
		if (attacker.BaseSpirit.Type1 == move.Type || attacker.BaseSpirit.Type2 == move.Type)
		{
			num = 1.5;
		}
		int num2 = ((move.MoveType == MoveType.Special) ? attacker.SATK : attacker.ATK);
		int num3 = ((move.MoveType == MoveType.Special) ? defender.SDEF : defender.DEF);
		return (double)move.Power * ((double)num2 / (double)num3) * totalEffectiveness * num;
	}

	private List<double> Softmax(List<double> desirabilities, double beta)
	{
		double maxD = Enumerable.Max((global::System.Collections.Generic.IEnumerable<double>)desirabilities);
		List<double> val = Enumerable.ToList<double>(Enumerable.Select<double, double>((global::System.Collections.Generic.IEnumerable<double>)desirabilities, (Func<double, double>)((double d) => Math.Exp(beta * (d - maxD)))));
		double sumExp = Enumerable.Sum((global::System.Collections.Generic.IEnumerable<double>)val);
		return Enumerable.ToList<double>(Enumerable.Select<double, double>((global::System.Collections.Generic.IEnumerable<double>)val, (Func<double, double>)((double exp) => exp / sumExp)));
	}
}
