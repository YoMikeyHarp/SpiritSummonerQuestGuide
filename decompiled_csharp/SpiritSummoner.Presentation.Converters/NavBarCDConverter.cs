using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace SpiritSummoner.Presentation.Converters;

public class NavBarCDConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type? targetType, object? parameter, CultureInfo? culture)
	{
		if (value is string text && parameter is string text2)
		{
			if (text == "Quest" && text2 == "Quest")
			{
				return true;
			}
			if (text == "Battle" && text2 == "Battle")
			{
				return true;
			}
		}
		return false;
	}

	public object ConvertBack(object? value, global::System.Type? targetType, object? parameter, CultureInfo? culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
