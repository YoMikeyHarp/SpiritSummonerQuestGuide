using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace SpiritSummoner.Presentation.Converters;

public class NicknameToFontSizeConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		double num = ParseBaseSize(parameter);
		int num2 = (value as string)?.Length ?? 0;
		if (1 == 0)
		{
		}
		double num3 = ((num2 <= 11) ? ((num2 > 8) ? 0.85 : 1.0) : ((num2 > 14) ? 0.6 : 0.72));
		if (1 == 0)
		{
		}
		double num4 = num3;
		double num5 = num * 0.55;
		return Math.Max(Math.Round(num * num4, 1), num5);
	}

	public object ConvertBack(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}

	private static double ParseBaseSize(object? parameter)
	{
		if (parameter is double result)
		{
			return result;
		}
		double result2 = default(double);
		if (parameter is string text && double.TryParse(text, (NumberStyles)167, (IFormatProvider)(object)CultureInfo.InvariantCulture, ref result2))
		{
			return result2;
		}
		return 24.0;
	}
}
