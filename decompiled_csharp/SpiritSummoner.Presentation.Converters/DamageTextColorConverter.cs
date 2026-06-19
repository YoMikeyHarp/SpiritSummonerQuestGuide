using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace SpiritSummoner.Presentation.Converters;

public class DamageTextColorConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is double num)
		{
			if (num < 1.0)
			{
				return Colors.SteelBlue;
			}
			if (num > 1.0)
			{
				return Colors.Crimson;
			}
			return Colors.Black;
		}
		return Colors.Black;
	}

	public object ConvertBack(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
