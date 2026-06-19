using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace SpiritSummoner.Presentation.Converters;

public class EqualityToColorConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		if (value == null || parameter == null)
		{
			return Colors.Transparent;
		}
		string text = parameter.ToString();
		if (string.IsNullOrEmpty(text))
		{
			return Colors.Transparent;
		}
		string[] array = text.Split(':', (StringSplitOptions)0);
		if (array.Length != 2)
		{
			return Colors.Transparent;
		}
		string text2 = array[0];
		string[] array2 = array[1].Split(',', (StringSplitOptions)0);
		if (array2.Length != 2)
		{
			return Colors.Transparent;
		}
		string text3 = value.ToString();
		string text4 = (string.Equals(text3, text2, (StringComparison)5) ? array2[0] : array2[1]);
		return Color.FromArgb(text4);
	}

	public object ConvertBack(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
