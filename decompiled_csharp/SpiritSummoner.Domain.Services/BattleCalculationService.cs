using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SpiritSummoner.Domain.Configuration;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Enums.Battles;
using SpiritSummoner.Domain.Enums.Items;
using SpiritSummoner.Domain.Enums.Spirits;
using SpiritSummoner.Domain.Interfaces.Services;
using SpiritSummoner.Domain.ValueObjects.Battle;

namespace SpiritSummoner.Domain.Services;

public class BattleCalculationService : IBattleCalculationService
{
	private readonly ITypeEffectivenessService _typeEffectivenessService;

	private readonly ISpecialAbilityService _specialAbilityService;

	private readonly BalanceConfig _config;

	public BattleCalculationService(ITypeEffectivenessService typeEffectivenessService, ISpecialAbilityService specialAbilityService)
	{
		_typeEffectivenessService = typeEffectivenessService;
		_specialAbilityService = specialAbilityService;
		_config = new BalanceConfig
		{
			MaxEquipmentStatMultiplier = 2f,
			MinEquipmentStatMultiplier = 0.5f,
			MaxSynergyStatMultiplier = 2f,
			MinSynergyStatMultiplier = 0.5f,
			MaxDamageMultiplier = 4f,
			MaxSingleHitDamagePercent = 0.6f,
			MinDamagePercent = 0.05f,
			MaxResistance = 0.1f,
			MinResistance = 2.5f,
			MaxCritRate = 0.75f,
			MaxCritDamageBonus = 1f,
			MaxSpeedMultiplier = 2.5f,
			MinSpeedMultiplier = 0.3f,
			MaxEvasionChance = 0.6f
		};
		base._002Ector();
	}

	public void RecalculateAllStats(BattleSprite sprite, BattleMode battleMode)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		List<string> val = new List<string>();
		if (sprite.Equipments != null)
		{
			Enumerator<string, Item> enumerator = sprite.Equipments.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, Item> current = enumerator.Current;
					if (current.Value == null)
					{
						continue;
					}
					Item value = current.Value;
					List<string> val2 = new List<string>();
					if (value.Effect != null)
					{
						if (value.Effect.FlatStatChanges != null)
						{
							global::System.Collections.Generic.IEnumerator<KeyValuePair<string, float>> enumerator2 = Enumerable.Where<KeyValuePair<string, float>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, float>>)value.Effect.FlatStatChanges, (Func<KeyValuePair<string, float>, bool>)((KeyValuePair<string, float> s) => s.Value != 0f)).GetEnumerator();
							try
							{
								while (((global::System.Collections.IEnumerator)enumerator2).MoveNext())
								{
									KeyValuePair<string, float> current2 = enumerator2.Current;
									string text = ((current2.Value > 0f) ? "+" : "");
									val2.Add($"{text}{current2.Value} {current2.Key.ToUpper()}");
								}
							}
							finally
							{
								((global::System.IDisposable)enumerator2)?.Dispose();
							}
						}
						if (value.Effect.StatMultipliers != null)
						{
							global::System.Collections.Generic.IEnumerator<KeyValuePair<string, double>> enumerator3 = Enumerable.Where<KeyValuePair<string, double>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, double>>)value.Effect.StatMultipliers, (Func<KeyValuePair<string, double>, bool>)((KeyValuePair<string, double> s) => Math.Abs(s.Value - 1.0) > 0.001)).GetEnumerator();
							try
							{
								while (((global::System.Collections.IEnumerator)enumerator3).MoveNext())
								{
									KeyValuePair<string, double> current3 = enumerator3.Current;
									string text2 = current3.Key.ToUpper();
									if (1 == 0)
									{
									}
									string text3 = ((text2 == "SATK") ? "MGK" : ((!(text2 == "SDEF")) ? current3.Key.ToUpper() : "MDF"));
									if (1 == 0)
									{
									}
									string text4 = text3;
									val2.Add($"×{current3.Value} {text4}");
								}
							}
							finally
							{
								((global::System.IDisposable)enumerator3)?.Dispose();
							}
						}
					}
					string text5 = ((val2.Count > 0) ? (" (" + string.Join(", ", (global::System.Collections.Generic.IEnumerable<string>)val2) + ")") : "");
					val.Add(current.Key + ":" + value.Name + text5);
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator).Dispose();
			}
		}
		string text6 = ((val.Count > 0) ? string.Join(" | ", (global::System.Collections.Generic.IEnumerable<string>)val) : "None");
		string text7 = (sprite.IsPlayer ? "[P]" : "[E]");
		Debug.WriteLine($"Recalculating stats for {text7}{sprite.BaseSpirit.Name} equipment: {text6}");
		Debug.WriteLine($"[BattleStats]   After Equipment │ ATK:{sprite.ATK}→{Convert.ToInt32(GetEffectiveStat(sprite, "Attack", battleMode, sprite.Equipments))} DEF:{sprite.DEF}→{Convert.ToInt32(GetEffectiveStat(sprite, "Defense", battleMode, sprite.Equipments))} MGK:{sprite.SATK}→{Convert.ToInt32(GetEffectiveStat(sprite, "SpecialAttack", battleMode, sprite.Equipments))} MDF:{sprite.SDEF}→{Convert.ToInt32(GetEffectiveStat(sprite, "SpecialDefense", battleMode, sprite.Equipments))} SPD:{sprite.SPD}→{Convert.ToInt32(GetEffectiveStat(sprite, "Speed", battleMode, sprite.Equipments))} INT:{sprite.INT}→{Convert.ToInt32(GetEffectiveStat(sprite, "Intelligence", battleMode, sprite.Equipments))}");
	}

	private static string GetItemSlot(BattleSprite sprite, Item item)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		if (sprite.Equipments == null)
		{
			return "?";
		}
		Enumerator<string, Item> enumerator = sprite.Equipments.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, Item> current = enumerator.Current;
				if (current.Value == item)
				{
					return current.Key;
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator).Dispose();
		}
		return "?";
	}

	public float GetEffectiveStat(BattleSprite spirit, string statName, BattleMode battleMode, Dictionary<string, Item> equipments)
	{
		float baseStat = GetBaseStat(spirit, statName);
		if (1 == 0)
		{
		}
		string text = ((statName == "Attack") ? "ATK" : ((statName == "Defense") ? "DEF" : ((statName == "SpecialAttack") ? "SATK" : ((statName == "SpecialDefense") ? "SDEF" : ((statName == "Speed") ? "SPD" : ((!(statName == "Intelligence")) ? statName : "INT"))))));
		if (1 == 0)
		{
		}
		string text2 = text;
		Item item = default(Item);
		float num = ((!string.IsNullOrEmpty(spirit.PlayerSpirit?.GearID) && equipments.TryGetValue("gear", ref item)) ? GetFlatStatChange(text2, item, battleMode) : 0f);
		Item item2 = default(Item);
		float num2 = ((!string.IsNullOrEmpty(spirit.PlayerSpirit?.TalentID) && equipments.TryGetValue("talent", ref item2)) ? GetFlatStatChange(text2, item2, battleMode) : 0f);
		float num3 = 0f;
		if (battleMode == BattleMode.PVE)
		{
			Item item3 = default(Item);
			num3 = ((!string.IsNullOrEmpty(spirit.PlayerSpirit?.HeldItemID) && equipments.TryGetValue("heldItem", ref item3)) ? GetFlatStatChange(text2, item3, battleMode) : 0f);
		}
		float num4 = num + num2 + num3;
		baseStat += num4;
		float num5 = GetEquipmentStatMultiplier(spirit, text2, equipments, battleMode) * GetHPThresholdMultiplier(spirit, text2, battleMode);
		float num6 = Math.Clamp(num5, _config.MinEquipmentStatMultiplier, _config.MaxEquipmentStatMultiplier);
		float squadSynergyMultiplier = GetSquadSynergyMultiplier(spirit.PlayerSpirit.PlayerSpiritID, text2);
		float num7 = Math.Clamp(squadSynergyMultiplier, _config.MinSynergyStatMultiplier, _config.MaxSynergyStatMultiplier);
		if (Math.Abs(num5 - num6) > 0.001f || Math.Abs(squadSynergyMultiplier - num7) > 0.001f)
		{
			Debug.WriteLine($"[BattleCalc] StatCap ({spirit.BaseSpirit.Name} {text2}) — equip {num5:F2}→{num6:F2}, synergy {squadSynergyMultiplier:F2}→{num7:F2}");
		}
		baseStat *= num6 * num7;
		float temporaryStatMultiplier = _specialAbilityService.GetTemporaryStatMultiplier(spirit.PlayerSpirit.PlayerSpiritID, text2);
		if (temporaryStatMultiplier != 1f)
		{
			baseStat *= temporaryStatMultiplier;
		}
		return Math.Max(1f, baseStat);
	}

	private float GetBaseStat(BattleSprite spirit, string statName)
	{
		if (1 == 0)
		{
		}
		int num;
		switch (_003CPrivateImplementationDetails_003E.ComputeStringHash(statName))
		{
		case 174817312u:
			if (!(statName == "Speed"))
			{
				goto default;
			}
			num = Convert.ToInt32((double)(spirit.BaseSpirit.BaseStats.SPD + spirit.PlayerSpirit.PointsSPD) * spirit.BaseSpirit.BonusAttributes.SPD);
			break;
		case 2343121693u:
			if (!(statName == "Attack"))
			{
				goto default;
			}
			num = Convert.ToInt32((double)(spirit.BaseSpirit.BaseStats.ATK + spirit.PlayerSpirit.PointsATK) * spirit.BaseSpirit.BonusAttributes.ATK);
			break;
		case 3026228236u:
			if (!(statName == "SpecialAttack"))
			{
				goto default;
			}
			num = Convert.ToInt32((double)(spirit.BaseSpirit.BaseStats.SATK + spirit.PlayerSpirit.PointsSATK) * spirit.BaseSpirit.BonusAttributes.SATK);
			break;
		case 4240138483u:
			if (!(statName == "Defense"))
			{
				goto default;
			}
			num = Convert.ToInt32((double)(spirit.BaseSpirit.BaseStats.DEF + spirit.PlayerSpirit.PointsDEF) * spirit.BaseSpirit.BonusAttributes.DEF);
			break;
		case 1141182172u:
			if (!(statName == "SpecialDefense"))
			{
				goto default;
			}
			num = Convert.ToInt32((double)(spirit.BaseSpirit.BaseStats.SDEF + spirit.PlayerSpirit.PointsSDEF) * spirit.BaseSpirit.BonusAttributes.SDEF);
			break;
		case 1894470373u:
			if (!(statName == "HP"))
			{
				goto default;
			}
			num = spirit.PlayerSpirit.HP;
			break;
		case 2921231842u:
			if (!(statName == "Intelligence"))
			{
				goto default;
			}
			num = Convert.ToInt32((double)(spirit.BaseSpirit.BaseStats.INT + spirit.PlayerSpirit.PointsINT) * spirit.BaseSpirit.BonusAttributes.INT);
			break;
		default:
			num = 0;
			break;
		}
		if (1 == 0)
		{
		}
		return num;
	}

	private float GetFlatStatChange(string statName, Item item, BattleMode battleMode = BattleMode.PVP)
	{
		float num = 0f;
		float num2 = default(float);
		if (item != null && item.ItemType == ItemType.gear && item?.Effect?.FlatStatChanges != null && item.Effect.FlatStatChanges.TryGetValue(statName, ref num2))
		{
			num += num2;
		}
		float num3 = default(float);
		if (item != null && item.ItemType == ItemType.talent && item?.Effect?.FlatStatChanges != null && item.Effect.FlatStatChanges.TryGetValue(statName, ref num3))
		{
			num += num3;
		}
		float num4 = default(float);
		if (battleMode == BattleMode.PVE && item != null && item.ItemType == ItemType.booster && item?.Effect?.FlatStatChanges != null && item.Effect.FlatStatChanges.TryGetValue(statName, ref num4))
		{
			num += num4;
		}
		return num;
	}

	private float GetEquipmentStatMultiplier(BattleSprite spirit, string statName, Dictionary<string, Item> equipments, BattleMode battleMode)
	{
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		if (equipments == null)
		{
			return 1f;
		}
		List<Item> val = new List<Item>();
		Item item = default(Item);
		if (battleMode != BattleMode.PVP && equipments.TryGetValue("heldItem", ref item) && item != null)
		{
			val.Add(item);
		}
		Item item2 = default(Item);
		if (battleMode == BattleMode.PVP && equipments.TryGetValue("gear", ref item2) && item2 != null)
		{
			val.Add(item2);
		}
		Item item3 = default(Item);
		if (equipments.TryGetValue("talent", ref item3) && item3 != null)
		{
			val.Add(item3);
		}
		float num = 1f;
		Enumerator<Item> enumerator = val.GetEnumerator();
		try
		{
			double num2 = default(double);
			while (enumerator.MoveNext())
			{
				Item current = enumerator.Current;
				if (CanStack(current, val, spirit) && current.Effect?.StatMultipliers != null && current.Effect.StatMultipliers.TryGetValue(statName, ref num2))
				{
					num *= (float)num2;
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator).Dispose();
		}
		return num;
	}

	private bool CanStack(Item item, List<Item> equippedItems, BattleSprite spirit)
	{
		Item item2 = item;
		if (!string.IsNullOrEmpty(item2.Effect?.StackingGroup))
		{
			int num = Enumerable.Count<Item>((global::System.Collections.Generic.IEnumerable<Item>)equippedItems, (Func<Item, bool>)((Item i) => i?.Effect?.StackingGroup == item2.Effect.StackingGroup));
			if (num > 1 && !item2.Effect.CanStack)
			{
				return false;
			}
			if (item2.Effect.MaxStackCount > 0 && num > item2.Effect.MaxStackCount)
			{
				return false;
			}
		}
		return true;
	}

	private bool CanSpiritEquip(PlayerSpirit spirit, Item item, Spirit baseSpirit)
	{
		if (item?.Effect == null)
		{
			return true;
		}
		if (item.Effect.ClassRestrictions != null && Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)item.Effect.ClassRestrictions) && baseSpirit.Category != null && !item.Effect.ClassRestrictions.Contains(baseSpirit.Category))
		{
			return false;
		}
		if (item.Effect.TypeRestrictions != null && Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)item.Effect.TypeRestrictions))
		{
			string text = ((object)baseSpirit.Type1).ToString();
			string text2 = ((object)baseSpirit.Type2).ToString();
			if (!item.Effect.TypeRestrictions.Contains(text) && !item.Effect.TypeRestrictions.Contains(text2))
			{
				return false;
			}
		}
		return true;
	}

	public float CalculateDamage(BattleSprite attacker, BattleSprite defender, Move move, BattleMode mode, bool isCriticalHit)
	{
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		float num = ((move.MoveType == MoveType.Special) ? GetEffectiveStat(attacker, "SpecialAttack", mode, attacker.Equipments) : GetEffectiveStat(attacker, "Attack", mode, attacker.Equipments));
		float num2 = ((move.MoveType == MoveType.Special) ? GetEffectiveStat(defender, "SpecialDefense", mode, defender.Equipments) : GetEffectiveStat(defender, "Defense", mode, defender.Equipments));
		float defenseModifier = _specialAbilityService.GetDefenseModifier(attacker, defender, move, mode);
		float num3 = num2;
		num2 = Math.Max(1f, num2 * defenseModifier);
		if (Math.Abs(defenseModifier - 1f) > 0.0001f)
		{
			Debug.WriteLine($"[BattleCalc] DefenseMod ({attacker.BaseSpirit.Name}→{defender.BaseSpirit.Name}) — DEF {num3:F0}×{defenseModifier:F2}={num2:F0}");
		}
		float num4 = ((float)(2 * attacker.PlayerSpirit.Level) / 5f + 2f) * (float)move.Power * num / num2 / 50f + 2f;
		float num5 = num4;
		float num6 = num4;
		float num7 = CalculateTypeEffectiveness(move, defender);
		num4 *= num7;
		float num8 = 1f;
		if (attacker.BaseSpirit.Type1 == move.Type || attacker.BaseSpirit.Type2 == move.Type)
		{
			num8 = 1.5f;
			num4 *= num8;
		}
		float num9 = 1f;
		if (isCriticalHit)
		{
			float critDamageBonus = GetCritDamageBonus(attacker, mode);
			critDamageBonus = Math.Min(critDamageBonus, _config.MaxCritDamageBonus);
			num9 = 1.5f + critDamageBonus;
			num4 *= num9;
		}
		float damageMultiplier = GetDamageMultiplier(attacker, move.Type, mode);
		damageMultiplier = Math.Min(damageMultiplier, _config.MaxDamageMultiplier);
		num4 *= damageMultiplier;
		float hPThresholdDamageMultiplier = GetHPThresholdDamageMultiplier(attacker, mode);
		hPThresholdDamageMultiplier = Math.Min(hPThresholdDamageMultiplier, 2f);
		num4 *= hPThresholdDamageMultiplier;
		float elementalResistance = GetElementalResistance(defender, move.Type, mode);
		elementalResistance *= GetDamageMultiplierReduction(defender, move.Type, mode);
		elementalResistance = Math.Clamp(elementalResistance, _config.MaxResistance, 1f / _config.MaxResistance);
		num4 *= elementalResistance;
		Random val = new Random();
		float num10 = (float)(val.NextDouble() * 0.15 + 0.85);
		num4 *= num10;
		float num11 = num6 * _config.MinDamagePercent;
		bool flag = num4 < num11;
		num4 = Math.Max(num4, num11);
		float num12 = Math.Max(1f, num4);
		float num13 = Math.Max(0f, (float)defender.HP - num12);
		string text = (attacker.IsPlayer ? "[P]" : "[E]");
		string text2 = (defender.IsPlayer ? "[P]" : "[E]");
		Debug.WriteLine($"[BattleCalc] Damage — {text}{attacker.BaseSpirit.Name} used {move.Name}{(isCriticalHit ? " (CRIT!)" : "")} on {text2}{defender.BaseSpirit.Name}");
		Debug.WriteLine($"[BattleCalc]   Stats │ {((move.MoveType == MoveType.Physical) ? "ATK" : "MGK")}={num:F0} {((move.MoveType == MoveType.Physical) ? "DEF" : "MDF")}={num2:F0} → base={num5:F1}");
		Debug.WriteLine($"[BattleCalc]   Mults │ type×{num7:F2} STAB×{num8:F2} crit×{num9:F2} dmg×{damageMultiplier:F2} hpThresh×{hPThresholdDamageMultiplier:F2} resist×{elementalResistance:F2} rand×{num10:F2}");
		Debug.WriteLine($"[BattleCalc]   → final={num12:F1}{(flag ? $" (floored to {_config.MinDamagePercent:P0} min)" : string.Empty)} (HP: {defender.HP:F0} → {num13:F0})");
		return num12;
	}

	public bool RollHit(BattleSprite attacker, BattleSprite defender, BattleMode battleMode, float evasionMultiplier = 1f)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		float evasionBonus = GetEvasionBonus(defender, battleMode);
		float num = evasionBonus * evasionMultiplier;
		float accuracyBonus = GetAccuracyBonus(attacker, battleMode);
		float num2 = Math.Clamp(1f - num + accuracyBonus, 0.1f, 1f);
		Random val = new Random();
		bool flag = val.NextDouble() < (double)num2;
		string text = ((evasionMultiplier < 0.999f) ? $" (fatigue ×{evasionMultiplier:F2})" : string.Empty);
		if (!flag)
		{
			Debug.WriteLine($"[BattleCalc] RollHit ({attacker.BaseSpirit.Name}→{defender.BaseSpirit.Name}) — evasion:{num:P0}{text} acc:{accuracyBonus:P0} hitChance:{num2:P0} → MISS");
		}
		else if (num > 0f || accuracyBonus > 0f)
		{
			Debug.WriteLine($"[BattleCalc] RollHit ({attacker.BaseSpirit.Name}→{defender.BaseSpirit.Name}) — evasion:{num:P0}{text} acc:{accuracyBonus:P0} hitChance:{num2:P0} → HIT");
		}
		return flag;
	}

	private float GetEvasionBonus(BattleSprite defender, BattleMode battleMode)
	{
		float num = 0f;
		Item item = default(Item);
		if (battleMode != BattleMode.PVP && defender.Equipments.TryGetValue("heldItem", ref item) && item != null)
		{
			num += item.Effect?.EvasionBonus ?? 0f;
		}
		Item item2 = default(Item);
		if (defender.Equipments.TryGetValue("gear", ref item2) && item2 != null)
		{
			num += item2.Effect?.EvasionBonus ?? 0f;
		}
		Item item3 = default(Item);
		if (defender.Equipments.TryGetValue("talent", ref item3) && item3 != null)
		{
			num += item3.Effect?.EvasionBonus ?? 0f;
		}
		num += IntBonus(defender.INT, 0.25f, 200f);
		return (num > _config.MaxEvasionChance) ? _config.MaxEvasionChance : num;
	}

	private static float GetAccuracyBonus(BattleSprite attacker, BattleMode battleMode)
	{
		float num = 0f;
		Item item = default(Item);
		if (battleMode != BattleMode.PVP && attacker.Equipments.TryGetValue("heldItem", ref item) && item != null)
		{
			num += item.Effect?.AccuracyBonus ?? 0f;
		}
		Item item2 = default(Item);
		if (attacker.Equipments.TryGetValue("gear", ref item2) && item2 != null)
		{
			num += item2.Effect?.AccuracyBonus ?? 0f;
		}
		Item item3 = default(Item);
		if (attacker.Equipments.TryGetValue("talent", ref item3) && item3 != null)
		{
			num += item3.Effect?.AccuracyBonus ?? 0f;
		}
		return num + IntBonus(attacker.INT, 0.25f, 200f);
	}

	private static float IntBonus(float intVal, float maxBonus, float halfwayPoint)
	{
		float num = intVal - 100f;
		if (num <= 0f)
		{
			return num * (maxBonus / halfwayPoint);
		}
		return maxBonus * num / (num + halfwayPoint);
	}

	public bool RollCriticalHit(BattleSprite attacker, BattleMode battleMode)
	{
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		float num = 0.0625f;
		Item item = default(Item);
		if (battleMode != BattleMode.PVP && attacker.Equipments.TryGetValue("heldItem", ref item))
		{
			num += (item?.Effect?.CritRateBonus).GetValueOrDefault();
		}
		Item item2 = default(Item);
		if (attacker.Equipments.TryGetValue("gear", ref item2))
		{
			num += (item2?.Effect?.CritRateBonus).GetValueOrDefault();
		}
		Item item3 = default(Item);
		if (attacker.Equipments.TryGetValue("talent", ref item3))
		{
			num += (item3?.Effect?.CritRateBonus).GetValueOrDefault();
		}
		num += IntBonus(attacker.INT, 0.2f, 200f);
		num = Math.Min(num, _config.MaxCritRate);
		Random val = new Random();
		bool flag = val.NextDouble() < (double)num;
		if (flag)
		{
			Debug.WriteLine($"[BattleCalc] RollCrit ({attacker.BaseSpirit.Name}) — critRate:{num:P1} → CRIT");
		}
		return flag;
	}

	private float CalculateTypeEffectiveness(Move move, BattleSprite defender)
	{
		return (float)_typeEffectivenessService.GetTotalEffectiveness(move.Type, defender.BaseSpirit.Type1, defender.BaseSpirit.Type2);
	}

	private float GetDamageMultiplier(BattleSprite spirit, SpiritType moveType, BattleMode battleMode)
	{
		float num = 1f;
		List<Item> val = new List<Item>();
		Item item = default(Item);
		if (battleMode != BattleMode.PVP && spirit.Equipments.TryGetValue("heldItem", ref item) && item?.Effect != null)
		{
			val.Add(item);
		}
		Item item2 = default(Item);
		if (spirit.Equipments.TryGetValue("gear", ref item2) && item2?.Effect != null)
		{
			val.Add(item2);
		}
		Item item3 = default(Item);
		if (spirit.Equipments.TryGetValue("talent", ref item3) && item3?.Effect != null)
		{
			val.Add(item3);
		}
		global::System.Collections.Generic.IEnumerator<Item> enumerator = Enumerable.Where<Item>((global::System.Collections.Generic.IEnumerable<Item>)val, (Func<Item, bool>)((Item i) => i != null)).GetEnumerator();
		try
		{
			float num2 = default(float);
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				Item current = enumerator.Current;
				if (current.Effect != null)
				{
					if (current.Effect.DamageMultiplier != 1f)
					{
						Debug.WriteLine($"[AbilityFX] [{GetItemSlot(spirit, current)}] {current.Name} ({spirit.BaseSpirit.Name}) — global damage ×{current.Effect.DamageMultiplier:F2}");
						num *= current.Effect.DamageMultiplier;
					}
					string text = ((object)moveType).ToString();
					if (current.Effect.TypeDamageMultipliers != null && current.Effect.TypeDamageMultipliers.TryGetValue(text, ref num2))
					{
						Debug.WriteLine($"[AbilityFX] [{GetItemSlot(spirit, current)}] {current.Name} ({spirit.BaseSpirit.Name}) — {text} type damage ×{num2:F2}");
						num *= num2;
					}
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
		return num;
	}

	private float GetDamageMultiplierReduction(BattleSprite spirit, SpiritType moveType, BattleMode battleMode)
	{
		float num = 1f;
		List<Item> val = new List<Item>();
		Item item = default(Item);
		if (battleMode != BattleMode.PVP && spirit.Equipments.TryGetValue("heldItem", ref item) && item?.Effect != null)
		{
			val.Add(item);
		}
		Item item2 = default(Item);
		if (spirit.Equipments.TryGetValue("gear", ref item2) && item2?.Effect != null)
		{
			val.Add(item2);
		}
		Item item3 = default(Item);
		if (spirit.Equipments.TryGetValue("talent", ref item3) && item3?.Effect != null)
		{
			val.Add(item3);
		}
		global::System.Collections.Generic.IEnumerator<Item> enumerator = Enumerable.Where<Item>((global::System.Collections.Generic.IEnumerable<Item>)val, (Func<Item, bool>)((Item i) => i != null)).GetEnumerator();
		try
		{
			float num2 = default(float);
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				Item current = enumerator.Current;
				if (current.Effect != null)
				{
					if (current.Effect.DamageMultiplier != 1f)
					{
						Debug.WriteLine($"[AbilityFX] [{GetItemSlot(spirit, current)}] {current.Name} ({spirit.BaseSpirit.Name}) — global damage ×{current.Effect.DamageMultiplier:F2}");
						num *= current.Effect.DamageMultiplier;
					}
					string text = ((object)moveType).ToString();
					if (current.Effect.TypeDamageMultipliers != null && current.Effect.TypeDamageMultipliers.TryGetValue(text, ref num2))
					{
						Debug.WriteLine($"[AbilityFX] [{GetItemSlot(spirit, current)}] {current.Name} ({spirit.BaseSpirit.Name}) — {text} type damage ×{num2:F2}");
						num *= num2;
					}
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
		return num;
	}

	private float GetHPThresholdDamageMultiplier(BattleSprite spirit, BattleMode battleMode)
	{
		if (string.IsNullOrEmpty(spirit.PlayerSpirit.TalentID))
		{
			return 1f;
		}
		Item item = default(Item);
		if (!spirit.Equipments.TryGetValue("talent", ref item) || item == null)
		{
			return 1f;
		}
		if (item.Effect?.HpThresholdEffect == null)
		{
			return 1f;
		}
		HPThresholdEffect hpThresholdEffect = item.Effect.HpThresholdEffect;
		float num = (float)spirit.HP / (float)spirit.MaxHP;
		if (!(hpThresholdEffect.ActivatesBelowThreshold ? (num <= hpThresholdEffect.Threshold) : (num >= hpThresholdEffect.Threshold)) || hpThresholdEffect.DamageMultiplier == 1f)
		{
			return 1f;
		}
		string text = (hpThresholdEffect.ActivatesBelowThreshold ? $"HP under {hpThresholdEffect.Threshold:P0}" : $"HP over {hpThresholdEffect.Threshold:P0}");
		Debug.WriteLine($"[AbilityFX] [talent] {item.Name} ({spirit.BaseSpirit.Name}) — {text} → damage ×{hpThresholdEffect.DamageMultiplier:F2}");
		return hpThresholdEffect.DamageMultiplier;
	}

	private float GetElementalResistance(BattleSprite defender, SpiritType attackType, BattleMode battleMode)
	{
		float num = 1f;
		string text = ((object)attackType).ToString();
		Item item = default(Item);
		float num2 = default(float);
		if (defender.Equipments.TryGetValue("gear", ref item) && item != null && item.Effect?.ElementalResistances != null && item.Effect.ElementalResistances.TryGetValue(text, ref num2))
		{
			num *= num2;
		}
		Item item2 = default(Item);
		float num3 = default(float);
		if (defender.Equipments.TryGetValue("talent", ref item2) && item2 != null && item2.Effect?.ElementalResistances != null && item2.Effect.ElementalResistances.TryGetValue(text, ref num3))
		{
			num *= num3;
		}
		return num;
	}

	private float GetCritDamageBonus(BattleSprite spirit, BattleMode battleMode)
	{
		float num = 0f;
		Item item = default(Item);
		if (battleMode != BattleMode.PVP && spirit.Equipments.TryGetValue("heldItem", ref item) && item != null)
		{
			num += item.Effect?.CritDamageBonus ?? 0f;
		}
		Item item2 = default(Item);
		if (spirit.Equipments.TryGetValue("gear", ref item2) && item2 != null)
		{
			num += item2.Effect?.CritDamageBonus ?? 0f;
		}
		Item item3 = default(Item);
		if (spirit.Equipments.TryGetValue("talent", ref item3) && item3 != null)
		{
			num += item3.Effect?.CritDamageBonus ?? 0f;
		}
		return num;
	}

	private float GetSquadSynergyMultiplier(string spiritId, string statName)
	{
		return _specialAbilityService.GetStoredSquadSynergyBonus(spiritId, statName);
	}

	private float GetHPThresholdMultiplier(BattleSprite spirit, string statName, BattleMode battleMode)
	{
		if (string.IsNullOrEmpty(spirit.PlayerSpirit.TalentID))
		{
			return 1f;
		}
		Item item = default(Item);
		if (!spirit.Equipments.TryGetValue("talent", ref item) || item == null)
		{
			return 1f;
		}
		if (item.Effect?.HpThresholdEffect == null)
		{
			return 1f;
		}
		HPThresholdEffect hpThresholdEffect = item.Effect.HpThresholdEffect;
		float num = (float)spirit.HP / (float)spirit.MaxHP;
		if (!(hpThresholdEffect.ActivatesBelowThreshold ? (num <= hpThresholdEffect.Threshold) : (num >= hpThresholdEffect.Threshold)))
		{
			return 1f;
		}
		float num2 = default(float);
		if (hpThresholdEffect.StatMultipliers != null && hpThresholdEffect.StatMultipliers.TryGetValue(statName, ref num2))
		{
			string text = (hpThresholdEffect.ActivatesBelowThreshold ? $"HP under {hpThresholdEffect.Threshold:P0}" : $"HP over {hpThresholdEffect.Threshold:P0}");
			if (1 == 0)
			{
			}
			string text2 = ((statName == "SATK") ? "MGK" : ((!(statName == "SDEF")) ? statName : "MDF"));
			if (1 == 0)
			{
			}
			string text3 = text2;
			Debug.WriteLine($"[AbilityFX] [talent] {item.Name} ({spirit.BaseSpirit.Name}) — {text} → {text3} ×{num2:F2}");
			return num2;
		}
		return 1f;
	}

	public float CalculateRecoilDamage(BattleSprite attacker, float damageDealt, BattleMode battleMode)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		float num = 0f;
		Item item = default(Item);
		Item item2 = default(Item);
		Item item3 = default(Item);
		ValueTuple<string, Item>[] array = new ValueTuple<string, Item>[3]
		{
			new ValueTuple<string, Item>("gear", attacker.Equipments.TryGetValue("gear", ref item) ? item : null),
			new ValueTuple<string, Item>("talent", attacker.Equipments.TryGetValue("talent", ref item2) ? item2 : null),
			new ValueTuple<string, Item>("heldItem", (battleMode != BattleMode.PVP && attacker.Equipments.TryGetValue("heldItem", ref item3)) ? item3 : null)
		};
		ValueTuple<string, Item>[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			ValueTuple<string, Item> val = array2[i];
			string item4 = val.Item1;
			Item item5 = val.Item2;
			if (item5?.Effect != null)
			{
				float recoilDamage = item5.Effect.RecoilDamage;
				if (!(recoilDamage <= 0f))
				{
					float num2 = damageDealt * recoilDamage;
					num += num2;
					Debug.WriteLine($"[AbilityFX] [{item4}] recoil {item5.Name} ({attacker.BaseSpirit.Name}) — {recoilDamage:P0} of {damageDealt:F1} dmg → -{num2:F1} HP");
				}
			}
		}
		return num;
	}
}
