using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace SpiritSummoner.Presentation.Converters;

public class EffectivenessIconConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is double num)
		{
			if (num < 1.0)
			{
				return "icon_noteffective.webp";
			}
			if (num > 1.0)
			{
				return "icon_effective.webp";
			}
			return "";
		}
		return "";
	}

	public object ConvertBack(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
