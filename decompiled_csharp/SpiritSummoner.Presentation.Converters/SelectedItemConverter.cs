using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace SpiritSummoner.Presentation.Converters;

public class SelectedItemConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		if (value is bool flag)
		{
			return (!flag) ? ((object)Brush.op_Implicit(Colors.White)) : ((object)(Brush)Application.Current.Resources["GradientSelectedSpirit"]);
		}
		return Colors.White;
	}

	public object ConvertBack(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
