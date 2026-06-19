using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using SpiritSummoner.Domain.Enums.Spirits;

namespace SpiritSummoner.Presentation.Converters;

public class NameToImageConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		SpiritType spiritType = default(SpiritType);
		if (value is SpiritType)
		{
			spiritType = (SpiritType)value;
			if (spiritType != 0)
			{
				goto IL_0035;
			}
		}
		if (!(value is string text) || !global::System.Enum.TryParse<SpiritType>(text, ref spiritType) || spiritType == SpiritType.None)
		{
			return "";
		}
		goto IL_0035;
		IL_0035:
		return "type" + ((object)spiritType).ToString().ToLower() + ".png";
	}

	public object ConvertBack(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
