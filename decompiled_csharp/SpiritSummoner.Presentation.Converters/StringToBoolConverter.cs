using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace SpiritSummoner.Presentation.Converters;

public class StringToBoolConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		if (value == null)
		{
			return false;
		}
		if (parameter is string text && text.Equals("Invert", (StringComparison)5))
		{
			return string.IsNullOrEmpty(value?.ToString());
		}
		return !string.IsNullOrEmpty(value?.ToString());
	}

	public object ConvertBack(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
