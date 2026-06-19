using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace SpiritSummoner.Presentation.Converters;

public class BoolToColorConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		if (!(value is bool flag) || !(parameter is string text))
		{
			return Colors.Transparent;
		}
		string[] array = text.Split(',', (StringSplitOptions)0);
		if (array.Length != 2)
		{
			return Colors.Transparent;
		}
		string text2 = (flag ? array[0].Trim() : array[1].Trim());
		string text3 = text2.ToLower();
		if (1 == 0)
		{
		}
		Color result = ((text3 == "transparent") ? Colors.Transparent : ((text3 == "red") ? Colors.Red : ((text3 == "green") ? Colors.Green : ((text3 == "blue") ? Colors.Blue : ((text3 == "white") ? Colors.White : ((!(text3 == "black")) ? ((!text3.StartsWith("#")) ? Colors.Transparent : Color.FromArgb(text3)) : Colors.Black))))));
		if (1 == 0)
		{
		}
		return result;
	}

	public object ConvertBack(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
