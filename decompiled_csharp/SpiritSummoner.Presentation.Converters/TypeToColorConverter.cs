using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using SpiritSummoner.Domain.Enums.Spirits;

namespace SpiritSummoner.Presentation.Converters;

public class TypeToColorConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type? targetType, object? parameter, CultureInfo culture)
	{
		if (value is SpiritType spiritType)
		{
			if (1 == 0)
			{
			}
			Color result = (Color)(spiritType switch
			{
				SpiritType.Water => Color.FromArgb("#3ABFFF"), 
				SpiritType.Poison => Color.FromArgb("#B881EC"), 
				SpiritType.Dark => Color.FromArgb("#6E598C"), 
				SpiritType.Fire => Color.FromArgb("#F47712"), 
				SpiritType.Grass => Color.FromArgb("#50AE58"), 
				SpiritType.Light => Color.FromArgb("#FFE960"), 
				SpiritType.Wind => Color.FromArgb("#65DCFC"), 
				SpiritType.Electric => Color.FromArgb("#FED238"), 
				SpiritType.Ground => Color.FromArgb("#C26709"), 
				SpiritType.Neutral => Color.FromArgb("#B9B8B9"), 
				SpiritType.Metal => Color.FromArgb("#727578"), 
				_ => Colors.Transparent, 
			});
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
