using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using SpiritSummoner.Domain.Enums.Spirits;

namespace SpiritSummoner.Presentation.Converters;

public class PlatformImageConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type? targetType, object? parameter, CultureInfo culture)
	{
		SpiritType spiritType2;
		if (value is SpiritType spiritType)
		{
			spiritType2 = spiritType;
		}
		else
		{
			SpiritType spiritType3 = default(SpiritType);
			if (!global::System.Enum.TryParse<SpiritType>(value?.ToString(), ref spiritType3))
			{
				return "platformneutral.webp";
			}
			spiritType2 = spiritType3;
		}
		SpiritType? spiritType4 = null;
		SpiritType spiritType6 = default(SpiritType);
		if (parameter is SpiritType spiritType5)
		{
			spiritType4 = spiritType5;
		}
		else if (parameter != null && global::System.Enum.TryParse<SpiritType>(parameter.ToString(), ref spiritType6))
		{
			spiritType4 = spiritType6;
		}
		if (spiritType4.HasValue && spiritType4.Value != 0)
		{
			return $"platform_{GetTypeName(spiritType2)}_{GetTypeName(spiritType4.Value)}.png";
		}
		if (1 == 0)
		{
		}
		string result = spiritType2 switch
		{
			SpiritType.Water => "platformwater.webp", 
			SpiritType.Poison => "platformpoison.webp", 
			SpiritType.Dark => "platformdark.webp", 
			SpiritType.Ground => "platformearth.webp", 
			SpiritType.Fire => "platformfire.webp", 
			SpiritType.Grass => "platformgrass.webp", 
			SpiritType.Light => "platformlight.webp", 
			SpiritType.Wind => "platformwind.webp", 
			SpiritType.Neutral => "platformneutral.webp", 
			SpiritType.Metal => "platformmetal.webp", 
			SpiritType.Electric => "platformelectric.webp", 
			_ => "platformneutral.webp", 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	private static string GetTypeName(SpiritType type)
	{
		if (1 == 0)
		{
		}
		string result = type switch
		{
			SpiritType.Water => "water", 
			SpiritType.Poison => "poison", 
			SpiritType.Dark => "dark", 
			SpiritType.Ground => "earth", 
			SpiritType.Fire => "fire", 
			SpiritType.Grass => "grass", 
			SpiritType.Light => "light", 
			SpiritType.Wind => "wind", 
			SpiritType.Neutral => "neutral", 
			SpiritType.Metal => "metal", 
			SpiritType.Electric => "electric", 
			_ => "neutral", 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public object ConvertBack(object? value, global::System.Type? targetType, object? parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
