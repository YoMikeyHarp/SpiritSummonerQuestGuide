using System;
using System.Collections.ObjectModel;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using SpiritSummoner.Domain.Enums.Battles;
using SpiritSummoner.Domain.Enums.Items;
using SpiritSummoner.Domain.Enums.Quests;

namespace SpiritSummoner.Presentation.Converters;

public class ShopItemSelectConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type? targetType, object? parameter, CultureInfo culture)
	{
		if (value is ItemType itemType && parameter is string text)
		{
			if (1 == 0)
			{
			}
			Brush result;
			switch (itemType)
			{
			case ItemType.spirits:
				if (!(text == "spirits"))
				{
					goto default;
				}
				result = Background(isSelected: true);
				break;
			case ItemType.booster:
				if (!(text == "booster"))
				{
					goto default;
				}
				result = Background(isSelected: true);
				break;
			case ItemType.unlock:
				if (!(text == "unlock"))
				{
					goto default;
				}
				result = Background(isSelected: true);
				break;
			default:
				result = Background(isSelected: false);
				break;
			}
			if (1 == 0)
			{
			}
			return result;
		}
		if (value is QuestType questType && parameter is string text2)
		{
			if (1 == 0)
			{
			}
			Brush result;
			switch (questType)
			{
			case QuestType.story:
				if (!(text2 == "story"))
				{
					goto default;
				}
				result = Background(isSelected: true);
				break;
			case QuestType.challenge:
				if (!(text2 == "challenge"))
				{
					goto default;
				}
				result = Background(isSelected: true);
				break;
			case QuestType.dojo:
				if (!(text2 == "dojo"))
				{
					goto default;
				}
				result = Background(isSelected: true);
				break;
			default:
				result = Background(isSelected: false);
				break;
			}
			if (1 == 0)
			{
			}
			return result;
		}
		if (value is BattlesType battlesType && parameter is string text3)
		{
			if (1 == 0)
			{
			}
			Brush result;
			switch (battlesType)
			{
			case BattlesType.PvP1v1:
				if (!(text3 == "PvP1v1"))
				{
					goto default;
				}
				result = Background(isSelected: true);
				break;
			case BattlesType.PvP3v3:
				if (!(text3 == "PvP3v3"))
				{
					goto default;
				}
				result = Background(isSelected: true);
				break;
			case BattlesType.NPC:
				if (!(text3 == "NPC3v3"))
				{
					goto default;
				}
				result = Background(isSelected: true);
				break;
			default:
				result = Background(isSelected: false);
				break;
			}
			if (1 == 0)
			{
			}
			return result;
		}
		if (value is string text4 && parameter is string text5)
		{
			return string.Equals(text4, text5, (StringComparison)5) ? Background(isSelected: true) : Background(isSelected: false);
		}
		if (value is bool flag)
		{
			return flag ? "#F39C12" : "#FF717171";
		}
		return "#FF717171";
	}

	public object ConvertBack(object? value, global::System.Type? targetType, object? parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}

	private static Brush Background(bool isSelected)
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00b4: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00cf: Expected O, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		//IL_00ea: Expected O, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_0105: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected O, but got Unknown
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0026: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0041: Expected O, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_005c: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		LinearGradientBrush val2;
		if (!isSelected)
		{
			GradientStopCollection val = new GradientStopCollection();
			((Collection<GradientStop>)val).Add(new GradientStop(Color.FromArgb("#ABD66F"), 0f));
			((Collection<GradientStop>)val).Add(new GradientStop(Color.FromArgb("#74BF0C"), 0.5048f));
			((Collection<GradientStop>)val).Add(new GradientStop(Color.FromArgb("#74BF0C"), 1f));
			val2 = new LinearGradientBrush(val, new Point(0.0, 0.0), new Point(0.0, 1.0));
		}
		else
		{
			GradientStopCollection val3 = new GradientStopCollection();
			((Collection<GradientStop>)val3).Add(new GradientStop(Color.FromArgb("#95BF69"), 0f));
			((Collection<GradientStop>)val3).Add(new GradientStop(Color.FromArgb("#78B13F"), 0.25f));
			((Collection<GradientStop>)val3).Add(new GradientStop(Color.FromArgb("#5EA219"), 0.5048f));
			((Collection<GradientStop>)val3).Add(new GradientStop(Color.FromArgb("#4D9800"), 1f));
			val2 = new LinearGradientBrush(val3, new Point(0.0, 0.0), new Point(0.0, 1.0));
		}
		return (Brush)val2;
	}
}
