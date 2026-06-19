using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace SpiritSummoner.Presentation.Converters;

public class BonusToImageClipConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is double num)
		{
			if (1 == 0)
			{
			}
			string result = ((num == 1.05) ? "stars_0.5.webp" : ((num == 1.1) ? "stars_1.webp" : ((num == 1.15) ? "stars_1.5.webp" : ((num == 1.2) ? "stars_2.webp" : ((num == 1.25) ? "stars_2.5.webp" : ((num != 1.3) ? "" : "stars_3.webp"))))));
			if (1 == 0)
			{
			}
			return result;
		}
		return "";
	}

	public object ConvertBack(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
