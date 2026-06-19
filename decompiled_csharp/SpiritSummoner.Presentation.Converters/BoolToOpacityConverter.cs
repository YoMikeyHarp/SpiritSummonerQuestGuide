using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace SpiritSummoner.Presentation.Converters;

public class BoolToOpacityConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type? targetType, object? parameter, CultureInfo? culture)
	{
		if (value is bool flag)
		{
			return flag ? 1.0 : 0.35;
		}
		return 1.0;
	}

	public object ConvertBack(object? value, global::System.Type? targetType, object? parameter, CultureInfo? culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
