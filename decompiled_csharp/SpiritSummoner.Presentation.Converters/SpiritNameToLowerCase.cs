using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace SpiritSummoner.Presentation.Converters;

public class SpiritNameToLowerCase : IValueConverter
{
	public object Convert(object? value, global::System.Type? targetType, object? parameter, CultureInfo culture)
	{
		if (value is string text)
		{
			return text.ToLower().Replace(' ', '_') + ".png";
		}
		return value;
	}

	public object ConvertBack(object? value, global::System.Type? targetType, object? parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
