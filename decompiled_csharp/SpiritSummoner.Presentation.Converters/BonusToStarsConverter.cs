using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace SpiritSummoner.Presentation.Converters;

public class BonusToStarsConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is double num && num >= 1.0)
		{
			List<string> val = new List<string>();
			int num2 = (int)Math.Round((num - 1.0) * 20.0);
			int num3 = num2 / 2;
			bool flag = num2 % 2 == 1;
			for (int i = 0; i < num3; i++)
			{
				val.Add("icon_bonusstar.png");
			}
			if (flag)
			{
				val.Add("icon_bonusstarhalf.png");
			}
			return val;
		}
		return new List<string>();
	}

	public object ConvertBack(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
