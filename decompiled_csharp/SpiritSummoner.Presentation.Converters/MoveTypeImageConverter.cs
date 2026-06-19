using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using SpiritSummoner.Domain.Enums.Spirits;

namespace SpiritSummoner.Presentation.Converters;

public class MoveTypeImageConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is MoveType moveType)
		{
			if (moveType == MoveType.None)
			{
				return string.Empty;
			}
			if (parameter == null)
			{
				return (moveType == MoveType.Physical) ? "icon_physical.webp" : "icon_magical.webp";
			}
			if (parameter is string text && text == "transparent")
			{
				return (moveType == MoveType.Physical) ? "icon_physical_transparent.png" : "icon_magical_transparent.png";
			}
		}
		return string.Empty;
	}

	public object ConvertBack(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
