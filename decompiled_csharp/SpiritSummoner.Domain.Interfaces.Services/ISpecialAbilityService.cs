using System.Threading.Tasks;
using SpiritSummoner.Application.UseCases.Battles;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Enums.Battles;
using SpiritSummoner.Domain.Enums.Spirits;
using SpiritSummoner.Domain.ValueObjects.Battle;

namespace SpiritSummoner.Domain.Interfaces.Services;

public interface ISpecialAbilityService
{
	global::System.Threading.Tasks.Task HandleBattleStartEffects(BattleState battleState, BattleMode battleMode);

	global::System.Threading.Tasks.Task HandleSpiritEntersBattleEffects(BattleState battleState, BattleMode battleMode);

	float ApplyDamageModifiers(BattleSprite attacker, BattleSprite defender, float baseDamage, Move move, BattleMode battleMode);

	float ApplyDamageReduction(BattleSprite defender, float incomingDamage, SpiritType attackType, Move move, BattleMode battleMode);

	global::System.Threading.Tasks.Task<PostCombatEffectResult> HandlePostCombatEffects(BattleSprite attacker, BattleSprite defender, int damageDealt, Move move, BattleMode battleMode);

	global::System.Threading.Tasks.Task HandleTurnStartEffects(BattleState battleState, BattleMode battleMode);

	global::System.Threading.Tasks.Task HandleTurnEndEffects(BattleState battleState, BattleMode battleMode);

	global::System.Threading.Tasks.Task<KnockoutEffectResult> HandleSpiritKnockout(BattleState battleState, BattleSprite koSpirit, BattleSprite attacker, BattleMode battleMode);

	float CalculateSquadSynergyBonus(BattleState battleState, BattleSprite spirit, string statName);

	float GetStoredSquadSynergyBonus(string spiritId, string statName);

	void InitializeTurnBasedEffects(BattleSprite sprite, BattleMode battleMode);

	void ResetTemporaryEffects(BattleSprite sprite);

	bool HasOpeningStrikePriority(BattleSprite sprite, BattleMode battleMode);

	int GetTurnPriority(BattleSprite sprite, BattleMode battleMode);

	int? GetForcedMoveSlotIndex(BattleSprite sprite, BattleMode battleMode);

	float GetTemporaryStatMultiplier(string spiritId, string statName);

	float GetDefenseModifier(BattleSprite attacker, BattleSprite defender, Move move, BattleMode battleMode);
}
