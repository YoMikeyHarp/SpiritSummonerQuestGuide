using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace SpiritSummoner.Presentation.Converters;

public class IndexToColorConverter : IValueConverter
{
	public object Convert(object value, global::System.Type targetType, object parameter, CultureInfo culture)
	{
		int num = (int)value;
		int num2 = int.Parse(parameter.ToString());
		return (num == num2) ? "#FFD700" : "#4169E1";
	}

	public object ConvertBack(object value, global::System.Type targetType, object parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
