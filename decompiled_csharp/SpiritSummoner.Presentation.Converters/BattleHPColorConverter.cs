using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace SpiritSummoner.Presentation.Converters;

public class BattleHPColorConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type? targetType, object? parameter, CultureInfo? culture)
	{
		if (value is double num)
		{
			if (num >= 0.9)
			{
				return Color.FromArgb("#EAE227");
			}
			if (num >= 0.7)
			{
				return Color.FromArgb("#32CD32");
			}
			if (num >= 0.5)
			{
				return Color.FromArgb("#ADFF2F");
			}
			if (num >= 0.3)
			{
				return Color.FromArgb("#FF8C00");
			}
			return Color.FromArgb("#FF4500");
		}
		return Color.FromArgb("#FFFFFFFF");
	}

	public object ConvertBack(object? value, global::System.Type? targetType, object? parameter, CultureInfo? culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
