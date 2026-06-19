using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace SpiritSummoner.Presentation.Converters;

public class StringEqualConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		if (!(value is string text) || !(parameter is string text2))
		{
			return false;
		}
		return string.Equals(text, text2, (StringComparison)5);
	}

	public object ConvertBack(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException("StringEqualConverter does not support ConvertBack");
	}
}
