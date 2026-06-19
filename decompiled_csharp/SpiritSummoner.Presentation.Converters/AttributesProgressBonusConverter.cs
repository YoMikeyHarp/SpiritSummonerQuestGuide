using System;
using System.Globalization;
using Microsoft.Maui.Graphics;

namespace SpiritSummoner.Presentation.Converters;

public class AttributesProgressBonusConverter
{
	public object Convert(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is string text)
		{
			if (1 == 0)
			{
			}
			Color result = ((text == "ATK") ? Colors.Red : ((text == "DEF") ? Colors.Blue : ((text == "MGK") ? Colors.Purple : ((text == "MDF") ? Colors.LightGreen : ((text == "SPD") ? Colors.Yellow : ((!(text == "INT")) ? Colors.White : Colors.Orange))))));
			if (1 == 0)
			{
			}
			return result;
		}
		return Colors.White;
	}

	public object ConvertBack(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
