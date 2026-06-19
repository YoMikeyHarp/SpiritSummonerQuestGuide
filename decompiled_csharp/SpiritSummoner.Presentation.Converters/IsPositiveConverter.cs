using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace SpiritSummoner.Presentation.Converters;

public class IsPositiveConverter : IValueConverter
{
	public object? Convert(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		return value is int num && num > 0;
	}

	public object? ConvertBack(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
