using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using SpiritSummoner.Domain.Enums.Spirits;

namespace SpiritSummoner.Presentation.Converters;

public class CardBackgroundImageConverter : IValueConverter
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
				SpiritType.Water => "bg_water_card.png", 
				SpiritType.Poison => "bg_poison_card.png", 
				SpiritType.Dark => "bg_dark_card.png", 
				SpiritType.Fire => "bg_fire_card.png", 
				SpiritType.Grass => "bg_grass_card.png", 
				SpiritType.Light => "bg_light_card.png", 
				SpiritType.Wind => "bg_wind_card.png", 
				SpiritType.Electric => "bg_electric_card.png", 
				SpiritType.Ground => "bg_ground_card.png", 
				SpiritType.Neutral => "bg_neutral_card.png", 
				SpiritType.Metal => "bg_metal_card.png", 
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
