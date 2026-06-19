using System.Collections.Generic;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Enums.Battles;
using SpiritSummoner.Domain.ValueObjects.Battle;

namespace SpiritSummoner.Domain.Interfaces.Services;

public interface IBattleCalculationService
{
	float GetEffectiveStat(BattleSprite spirit, string statName, BattleMode battleMode, Dictionary<string, Item> spiritEquipments);

	float CalculateDamage(BattleSprite attacker, BattleSprite defender, Move move, BattleMode mode, bool isCriticalHit);

	bool RollCriticalHit(BattleSprite attacker, BattleMode battleMode);

	bool RollHit(BattleSprite attacker, BattleSprite defender, BattleMode battleMode, float evasionMultiplier = 1f);

	float CalculateRecoilDamage(BattleSprite attacker, float damageDealt, BattleMode battleMode);

	void RecalculateAllStats(BattleSprite sprite, BattleMode battleMode);
}
