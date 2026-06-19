using System;
using System.Collections;
using System.Collections.Generic;
using SpiritSummoner.Application.DTOs;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Services;
using SpiritSummoner.Presentation.Models;

namespace SpiritSummoner.Presentation.Utilities;

public static class AttributeProgressCalculator
{
	private const double MinEquipmentMult = 0.5;

	private const double MaxEquipmentMult = 2.0;

	public static global::System.Collections.Generic.IReadOnlyList<AttributeProgressModel> Calculate(PlayerSpirit playerSpirit, Spirit baseSpirit, global::System.Collections.Generic.IEnumerable<ItemEffect?>? itemEffects = null)
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0483: Unknown result type (might be due to invalid IL or missing references)
		//IL_048b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0493: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		if (playerSpirit == null || baseSpirit?.BaseStats == null)
		{
			return global::System.Array.Empty<AttributeProgressModel>();
		}
		List<AttributeProgressModel> val = new List<AttributeProgressModel>();
		BonusStats bonusStats = baseSpirit.BonusAttributes ?? new BonusStats();
		ValueTuple<string, string, int, int, double>[] array = new ValueTuple<string, string, int, int, double>[6]
		{
			new ValueTuple<string, string, int, int, double>("ATK", "icon_sword_common.webp", baseSpirit.BaseStats.ATK, playerSpirit.PointsATK, bonusStats.ATK),
			new ValueTuple<string, string, int, int, double>("DEF", "icon_shield.webp", baseSpirit.BaseStats.DEF, playerSpirit.PointsDEF, bonusStats.DEF),
			new ValueTuple<string, string, int, int, double>("MGK", "icon_critical.webp", baseSpirit.BaseStats.SATK, playerSpirit.PointsSATK, bonusStats.SATK),
			new ValueTuple<string, string, int, int, double>("MDF", "icon_defense.webp", baseSpirit.BaseStats.SDEF, playerSpirit.PointsSDEF, bonusStats.SDEF),
			new ValueTuple<string, string, int, int, double>("SPD", "icon_speed_rotated.webp", baseSpirit.BaseStats.SPD, playerSpirit.PointsSPD, bonusStats.SPD),
			new ValueTuple<string, string, int, int, double>("INT", "icon_int.png", baseSpirit.BaseStats.INT, playerSpirit.PointsINT, bonusStats.INT)
		};
		Dictionary<string, float> val2 = new Dictionary<string, float>((IEqualityComparer<string>)(object)StringComparer.OrdinalIgnoreCase);
		Dictionary<string, double> val3 = new Dictionary<string, double>((IEqualityComparer<string>)(object)StringComparer.OrdinalIgnoreCase);
		HashSet<string> val4 = new HashSet<string>((IEqualityComparer<string>)(object)StringComparer.Ordinal);
		if (itemEffects != null)
		{
			global::System.Collections.Generic.IEnumerator<ItemEffect> enumerator = itemEffects.GetEnumerator();
			try
			{
				string text = default(string);
				float num = default(float);
				float num3 = default(float);
				double num4 = default(double);
				double num6 = default(double);
				while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
				{
					ItemEffect current = enumerator.Current;
					if (current == null)
					{
						continue;
					}
					if (current.FlatStatChanges != null)
					{
						Enumerator<string, float> enumerator2 = current.FlatStatChanges.GetEnumerator();
						try
						{
							while (enumerator2.MoveNext())
							{
								enumerator2.Current.Deconstruct(ref text, ref num);
								string text2 = text;
								float num2 = num;
								val2.TryGetValue(text2, ref num3);
								val2[text2] = num3 + num2;
							}
						}
						finally
						{
							((global::System.IDisposable)enumerator2).Dispose();
						}
					}
					if (current.StatMultipliers != null)
					{
						Enumerator<string, double> enumerator3 = current.StatMultipliers.GetEnumerator();
						try
						{
							while (enumerator3.MoveNext())
							{
								enumerator3.Current.Deconstruct(ref text, ref num4);
								string text3 = text;
								double num5 = num4;
								val3.TryGetValue(text3, ref num6);
								val3[text3] = ((num6 == 0.0) ? 1.0 : num6) * num5;
							}
						}
						finally
						{
							((global::System.IDisposable)enumerator3).Dispose();
						}
					}
					if (current.SpecialAbilities == null)
					{
						continue;
					}
					Enumerator<string> enumerator4 = current.SpecialAbilities.GetEnumerator();
					try
					{
						while (enumerator4.MoveNext())
						{
							string current2 = enumerator4.Current;
							val4.Add(current2);
						}
					}
					finally
					{
						((global::System.IDisposable)enumerator4).Dispose();
					}
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator)?.Dispose();
			}
		}
		Dictionary<string, int> val5 = new Dictionary<string, int>((IEqualityComparer<string>)(object)StringComparer.Ordinal);
		ValueTuple<string, string, int, int, double>[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			ValueTuple<string, string, int, int, double> val6 = array2[i];
			string item = val6.Item1;
			int item2 = val6.Item3;
			int item3 = val6.Item4;
			double item4 = val6.Item5;
			if (1 == 0)
			{
			}
			string text = ((item == "MGK") ? "SATK" : ((!(item == "MDF")) ? item : "SDEF"));
			if (1 == 0)
			{
			}
			string text4 = text;
			float dictValue = GetDictValue<float>(val2, item, text4);
			double num7 = GetDictValue<double>(val3, item, text4);
			if (num7 == 0.0)
			{
				num7 = 1.0;
			}
			val5[text4] = ComputeFinalValue(item2, item3, item4, dictValue, num7);
		}
		Dictionary<string, int> val7 = StatConversions.Compute((IReadOnlyDictionary<string, int>)(object)val5, (IReadOnlySet<string>)(object)val4);
		int num8 = 0;
		ValueTuple<string, string, int, int, double>[] array3 = array;
		for (int j = 0; j < array3.Length; j++)
		{
			ValueTuple<string, string, int, int, double> val8 = array3[j];
			int item5 = val8.Item3;
			int item6 = val8.Item4;
			int num9 = item5 + item6;
			if (num9 > num8)
			{
				num8 = num9;
			}
		}
		int num10 = Math.Max((num8 + 49) / 50 * 50, 100);
		ValueTuple<string, string, int, int, double>[] array4 = array;
		for (int k = 0; k < array4.Length; k++)
		{
			ValueTuple<string, string, int, int, double> val9 = array4[k];
			string item7 = val9.Item1;
			string item8 = val9.Item2;
			int item9 = val9.Item3;
			int item10 = val9.Item4;
			double item11 = val9.Item5;
			int num11 = item9 + item10;
			int num12 = (int)((double)num11 * item11);
			if (1 == 0)
			{
			}
			string text = ((item7 == "MGK") ? "SATK" : ((!(item7 == "MDF")) ? item7 : "SDEF"));
			if (1 == 0)
			{
			}
			string text5 = text;
			float dictValue2 = GetDictValue<float>(val2, item7, text5);
			double num13 = GetDictValue<double>(val3, item7, text5);
			if (num13 == 0.0)
			{
				num13 = 1.0;
			}
			int valueOrDefault = CollectionExtensions.GetValueOrDefault<string, int>((IReadOnlyDictionary<string, int>)(object)val7, text5);
			bool flag = dictValue2 != 0f || num13 != 1.0 || valueOrDefault != 0;
			int num14 = ComputeFinalValue(item9, item10, item11, dictValue2, num13) + valueOrDefault;
			bool flag2 = flag && num14 < num12;
			double num15;
			double num16;
			double num17;
			if (!flag)
			{
				num15 = (double)num11 / (double)num10;
				num16 = (double)num12 / (double)num10;
				num17 = 0.0;
			}
			else if (flag2)
			{
				num15 = (double)num14 / (double)num10;
				num16 = (double)num14 / (double)num10;
				num17 = (double)num12 / (double)num10;
			}
			else
			{
				num15 = (double)num11 / (double)num10;
				num16 = (double)num12 / (double)num10;
				num17 = (double)num14 / (double)num10;
			}
			val.Add(new AttributeProgressModel(item7, item8, item9, item10, item11, num11, num14, Math.Min(num15, 1.0), Math.Min(num16, 1.0), Math.Min(num17, 1.0), flag2));
		}
		return (global::System.Collections.Generic.IReadOnlyList<AttributeProgressModel>)val.AsReadOnly();
	}

	public static int ComputeFinalValue(int baseValue, int allocatedPoints, double bonusMultiplier, float flatBuff = 0f, double itemMult = 1.0)
	{
		int num = (int)((double)(baseValue + allocatedPoints) * bonusMultiplier);
		if (itemMult == 0.0)
		{
			itemMult = 1.0;
		}
		itemMult = Math.Clamp(itemMult, 0.5, 2.0);
		return (int)((double)((float)num + flatBuff) * itemMult);
	}

	private static T GetDictValue<T>(Dictionary<string, T> dict, string key1, string key2)
	{
		T val = default(T);
		if (dict.TryGetValue(key1, ref val) && val != null)
		{
			return val;
		}
		T val2 = default(T);
		if (dict.TryGetValue(key2, ref val2) && val2 != null)
		{
			return val2;
		}
		return default(T);
	}

	public static global::System.Collections.Generic.IReadOnlyList<AttributeProgressModel> Calculate(SpiritPreviewDTO spiritPreviewDTO)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		if (spiritPreviewDTO == null)
		{
			return global::System.Array.Empty<AttributeProgressModel>();
		}
		List<AttributeProgressModel> val = new List<AttributeProgressModel>();
		ValueTuple<string, string, int, int, double>[] array = new ValueTuple<string, string, int, int, double>[6]
		{
			new ValueTuple<string, string, int, int, double>("ATK", "icon_sword_common.webp", spiritPreviewDTO.BaseATK, 0, spiritPreviewDTO.BonusATK),
			new ValueTuple<string, string, int, int, double>("DEF", "icon_shield.webp", spiritPreviewDTO.BaseDEF, 0, spiritPreviewDTO.BonusDEF),
			new ValueTuple<string, string, int, int, double>("MGK", "icon_critical.webp", spiritPreviewDTO.BaseSATK, 0, spiritPreviewDTO.BonusSATK),
			new ValueTuple<string, string, int, int, double>("MDF", "icon_defense.webp", spiritPreviewDTO.BaseSDEF, 0, spiritPreviewDTO.BonusSDEF),
			new ValueTuple<string, string, int, int, double>("SPD", "icon_speed_rotated.webp", spiritPreviewDTO.BaseSPD, 0, spiritPreviewDTO.BonusSPD),
			new ValueTuple<string, string, int, int, double>("INT", "icon_int.png", spiritPreviewDTO.BaseINT, 0, spiritPreviewDTO.BonusINT)
		};
		int num = 0;
		ValueTuple<string, string, int, int, double>[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			ValueTuple<string, string, int, int, double> val2 = array2[i];
			int item = val2.Item3;
			int item2 = val2.Item4;
			int num2 = item + item2;
			if (num2 > num)
			{
				num = num2;
			}
		}
		int num3 = Math.Max((num + 49) / 50 * 50, 100);
		ValueTuple<string, string, int, int, double>[] array3 = array;
		for (int j = 0; j < array3.Length; j++)
		{
			ValueTuple<string, string, int, int, double> val3 = array3[j];
			string item3 = val3.Item1;
			string item4 = val3.Item2;
			int item5 = val3.Item3;
			int item6 = val3.Item4;
			double item7 = val3.Item5;
			int num4 = item5 + item6;
			int num5 = (int)((double)num4 * item7);
			double num6 = (double)num4 / (double)num3;
			double num7 = (double)num5 / (double)num3;
			val.Add(new AttributeProgressModel(item3, item4, item5, item6, item7, num4, num5, Math.Min(num6, 1.0), Math.Min(num7, 1.0), 0.0));
		}
		return (global::System.Collections.Generic.IReadOnlyList<AttributeProgressModel>)val.AsReadOnly();
	}
}
