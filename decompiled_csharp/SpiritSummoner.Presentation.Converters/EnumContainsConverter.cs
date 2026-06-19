using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using SpiritSummoner.Domain.Enums.Battles;

namespace SpiritSummoner.Presentation.Converters;

public class EnumContainsConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is BattlesType battlesType && parameter is string text)
		{
			BattlesType battlesType2 = default(BattlesType);
			if (global::System.Enum.TryParse<BattlesType>(text, ref battlesType2))
			{
				return battlesType == battlesType2;
			}
			return false;
		}
		return false;
	}

	public object ConvertBack(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
