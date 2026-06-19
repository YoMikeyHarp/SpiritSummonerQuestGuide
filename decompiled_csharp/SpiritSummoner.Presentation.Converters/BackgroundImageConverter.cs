using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using SpiritSummoner.Domain.Enums.Spirits;

namespace SpiritSummoner.Presentation.Converters;

public class BackgroundImageConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type? targetType, object? parameter, CultureInfo culture)
	{
		if (value is SpiritType spiritType)
		{
			if (1 == 0)
			{
			}
			string result = spiritType switch
			{
				SpiritType.Water => "bgwater.png", 
				SpiritType.Poison => "bgpoison.png", 
				SpiritType.Dark => "bgdark.png", 
				SpiritType.Fire => "bgfire.png", 
				SpiritType.Grass => "bggrass.png", 
				SpiritType.Light => "bglight.png", 
				SpiritType.Wind => "bgwind.png", 
				SpiritType.Electric => "bgelectric.png", 
				SpiritType.Ground => "bgground.png", 
				SpiritType.Neutral => "bgnormal.png", 
				SpiritType.Metal => "bgmetal.webp", 
				_ => null, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		return "stop.png";
	}

	public object ConvertBack(object? value, global::System.Type? targetType, object? parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
