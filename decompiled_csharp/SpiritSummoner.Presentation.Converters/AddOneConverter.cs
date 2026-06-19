using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace SpiritSummoner.Presentation.Converters;

public class AddOneConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		if (1 == 0)
		{
		}
		object result = ((value is int num) ? ((object)(num + 1)) : ((value is long num2) ? ((object)(num2 + 1)) : ((value is float num3) ? ((object)(num3 + 1f)) : ((value is double num4) ? ((object)(num4 + 1.0)) : ((!(value is decimal num5)) ? value : ((object)(num5 + 1m)))))));
		if (1 == 0)
		{
		}
		return result;
	}

	public object ConvertBack(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		if (1 == 0)
		{
		}
		object result = ((value is int num) ? ((object)(num - 1)) : ((value is long num2) ? ((object)(num2 - 1)) : ((value is float num3) ? ((object)(num3 - 1f)) : ((value is double num4) ? ((object)(num4 - 1.0)) : ((!(value is decimal num5)) ? value : ((object)(num5 - 1m)))))));
		if (1 == 0)
		{
		}
		return result;
	}
}
