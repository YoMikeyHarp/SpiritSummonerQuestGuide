using System;
using System.Collections.Generic;
using System.Linq;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Entities.Requirements;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Items;

namespace SpiritSummoner.Infrastructure.Persistence.Mapping;

public static class ItemEntityMapper
{
	public static Item ToEntity(FirestoreItemDTO firestoreDto)
	{
		ArgumentNullException.ThrowIfNull((object)firestoreDto, "firestoreDto");
		RequirementTypes requirements = ((firestoreDto.Requirements != null) ? new RequirementTypes
		{
			LevelRequirement = new LevelRequirement
			{
				EvolveLevelRequired = ((firestoreDto.Requirements.LevelRequirement != null) ? firestoreDto.Requirements.LevelRequirement.EvolveLevelRequired : 0),
				PlayerLevelRequired = ((firestoreDto.Requirements.LevelRequirement != null) ? firestoreDto.Requirements.LevelRequirement.PlayerLevelRequired : 0),
				GuildRankRequired = ((firestoreDto.Requirements.LevelRequirement != null) ? firestoreDto.Requirements.LevelRequirement.GuildRankRequired : 0)
			},
			CurrencyCost = new CurrencyCostRequirement
			{
				Amount = ((firestoreDto.Requirements.CurrencyCost != null) ? firestoreDto.Requirements.CurrencyCost.Amount : 0),
				Type = ((firestoreDto.Requirements.CurrencyCost != null) ? firestoreDto.Requirements.CurrencyCost.Type : "None")
			},
			ItemRequirement = new ItemRequirement
			{
				Amount = ((firestoreDto.Requirements.ItemRequirement != null) ? firestoreDto.Requirements.ItemRequirement.Amount : 0),
				ItemType = ((firestoreDto.Requirements.ItemRequirement != null) ? firestoreDto.Requirements.ItemRequirement.ItemType : "None")
			}
		} : null);
		object obj;
		if (firestoreDto.Effect == null)
		{
			obj = null;
		}
		else
		{
			obj = new ItemEffect();
			object obj2 = obj;
			Dictionary<string, long>? flatStatChanges = firestoreDto.Effect.FlatStatChanges;
			((ItemEffect)obj2).FlatStatChanges = ((flatStatChanges != null) ? Enumerable.ToDictionary<KeyValuePair<string, long>, string, float>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, long>>)flatStatChanges, (Func<KeyValuePair<string, long>, string>)((KeyValuePair<string, long> kv) => kv.Key), (Func<KeyValuePair<string, long>, float>)((KeyValuePair<string, long> kv) => kv.Value)) : null);
			object obj3 = obj;
			Dictionary<string, double>? statMultipliers = firestoreDto.Effect.StatMultipliers;
			((ItemEffect)obj3).StatMultipliers = ((statMultipliers != null) ? Enumerable.ToDictionary<KeyValuePair<string, double>, string, double>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, double>>)statMultipliers, (Func<KeyValuePair<string, double>, string>)((KeyValuePair<string, double> kv) => NormalizeStatKey(kv.Key)), (Func<KeyValuePair<string, double>, double>)((KeyValuePair<string, double> kv) => kv.Value)) : null);
			((ItemEffect)obj).DamageMultiplier = firestoreDto.Effect.DamageMultiplier;
			((ItemEffect)obj).AccuracyBonus = firestoreDto.Effect.AccuracyBonus;
			((ItemEffect)obj).CanStack = firestoreDto.Effect.CanStack;
			((ItemEffect)obj).ClassRestrictions = firestoreDto.Effect.ClassRestrictions;
			((ItemEffect)obj).CritDamageBonus = firestoreDto.Effect.CritDamageBonus;
			((ItemEffect)obj).CritRateBonus = firestoreDto.Effect.CritRateBonus;
			((ItemEffect)obj).CustomDescription = firestoreDto.Effect.CustomDescription;
			((ItemEffect)obj).DamagePerTurn = firestoreDto.Effect.DamagePerTurn;
			object obj4 = obj;
			Dictionary<string, double>? elementalResistances = firestoreDto.Effect.ElementalResistances;
			((ItemEffect)obj4).ElementalResistances = ((elementalResistances != null) ? Enumerable.ToDictionary<KeyValuePair<string, double>, string, float>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, double>>)elementalResistances, (Func<KeyValuePair<string, double>, string>)((KeyValuePair<string, double> kv) => kv.Key), (Func<KeyValuePair<string, double>, float>)((KeyValuePair<string, double> kv) => (float)kv.Value)) : null);
			((ItemEffect)obj).EvasionBonus = firestoreDto.Effect.EvasionBonus;
			((ItemEffect)obj).GrantsImmunity = firestoreDto.Effect.GrantsImmunity;
			((ItemEffect)obj).HealPerTurn = firestoreDto.Effect.HealPerTurn;
			object obj5 = obj;
			object obj6;
			if (firestoreDto.Effect.HPThresholdEffect == null)
			{
				obj6 = null;
			}
			else
			{
				obj6 = new HPThresholdEffect
				{
					ActivatesBelowThreshold = firestoreDto.Effect.HPThresholdEffect.ActivatesBelowThreshold,
					DamageMultiplier = firestoreDto.Effect.HPThresholdEffect.DamageMultiplier,
					HealPerTurn = firestoreDto.Effect.HPThresholdEffect.HealPerTurn
				};
				object obj7 = obj6;
				Dictionary<string, double>? statMultipliers2 = firestoreDto.Effect.HPThresholdEffect.StatMultipliers;
				((HPThresholdEffect)obj7).StatMultipliers = ((statMultipliers2 != null) ? Enumerable.ToDictionary<KeyValuePair<string, double>, string, float>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, double>>)statMultipliers2, (Func<KeyValuePair<string, double>, string>)((KeyValuePair<string, double> kv) => NormalizeStatKey(kv.Key)), (Func<KeyValuePair<string, double>, float>)((KeyValuePair<string, double> kv) => (float)kv.Value)) : null);
				((HPThresholdEffect)obj6).Threshold = firestoreDto.Effect.HPThresholdEffect.Threshold;
			}
			((ItemEffect)obj5).HpThresholdEffect = (HPThresholdEffect?)obj6;
			((ItemEffect)obj).LocksMove = firestoreDto.Effect.LocksMove;
			((ItemEffect)obj).MaxStackCount = firestoreDto.Effect.MaxStackCount;
			((ItemEffect)obj).PreventsStatus = firestoreDto.Effect.PreventsStatus;
			((ItemEffect)obj).PriorityBonus = firestoreDto.Effect.PriorityBonus;
			((ItemEffect)obj).RecoilDamage = firestoreDto.Effect.RecoilDamage;
			((ItemEffect)obj).SpecialAbilities = firestoreDto.Effect.SpecialAbilities;
			((ItemEffect)obj).SquadSynergy = ((firestoreDto.Effect.SquadSynergy != null) ? new SquadSynergyEffect
			{
				AppliesToAllSpirits = firestoreDto.Effect.SquadSynergy.AppliesToAllSpirits,
				BonusPerSpirit = firestoreDto.Effect.SquadSynergy.BonusPerSpirit,
				BoostedStat = NormalizeStatKey(firestoreDto.Effect.SquadSynergy.BoostedStat ?? string.Empty),
				MinimumCount = firestoreDto.Effect.SquadSynergy.MinimumCount,
				RequiredType = firestoreDto.Effect.SquadSynergy.RequiredType
			} : null);
			((ItemEffect)obj).StackingGroup = firestoreDto.Effect.StackingGroup;
			object obj8 = obj;
			Dictionary<string, double>? typeDamageMultipliers = firestoreDto.Effect.TypeDamageMultipliers;
			((ItemEffect)obj8).TypeDamageMultipliers = ((typeDamageMultipliers != null) ? Enumerable.ToDictionary<KeyValuePair<string, double>, string, float>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, double>>)typeDamageMultipliers, (Func<KeyValuePair<string, double>, string>)((KeyValuePair<string, double> kv) => kv.Key), (Func<KeyValuePair<string, double>, float>)((KeyValuePair<string, double> kv) => (float)kv.Value)) : null);
			((ItemEffect)obj).TypeRestrictions = firestoreDto.Effect.TypeRestrictions;
			((ItemEffect)obj).UnlockedMoves = firestoreDto.Effect.UnlockedMoves;
		}
		ItemEffect effect = (ItemEffect)obj;
		return Item.Rehydrate(firestoreDto.ID ?? string.Empty, firestoreDto.Name ?? string.Empty, firestoreDto.Description ?? string.Empty, firestoreDto.Image ?? string.Empty, firestoreDto.ItemType, requirements, effect);
	}

	public static List<Item> ToEntities(global::System.Collections.Generic.IEnumerable<FirestoreItemDTO> firestoreDtos)
	{
		return ((firestoreDtos != null) ? Enumerable.ToList<Item>(Enumerable.Select<FirestoreItemDTO, Item>(firestoreDtos, (Func<FirestoreItemDTO, Item>)ToEntity)) : null) ?? new List<Item>();
	}

	private static string NormalizeStatKey(string key)
	{
		if (1 == 0)
		{
		}
		string result = ((key == "MGK") ? "SATK" : ((!(key == "MDF")) ? key : "SDEF"));
		if (1 == 0)
		{
		}
		return result;
	}
}
