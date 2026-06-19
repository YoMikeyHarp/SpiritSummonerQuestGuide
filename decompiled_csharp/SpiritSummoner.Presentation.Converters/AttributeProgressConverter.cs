using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace SpiritSummoner.Presentation.Converters;

public class AttributeProgressConverter : IValueConverter
{
	private static readonly Dictionary<string, Color> AttributeColors;

	public object Convert(object? value, global::System.Type? targetType, object? parameter, CultureInfo? culture)
	{
		Color val = default(Color);
		if (value is string text && AttributeColors.TryGetValue(text, ref val))
		{
			float num = default(float);
			if (parameter is string text2 && float.TryParse(text2, ref num))
			{
				return val.WithAlpha(num);
			}
			return val;
		}
		return Color.FromArgb("#FFFFFFFF");
	}

	public object ConvertBack(object? value, global::System.Type? targetType, object? parameter, CultureInfo? culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}

	static AttributeProgressConverter()
	{
		Dictionary<string, Color> obj = new Dictionary<string, Color>();
		obj.Add("ATK", Color.FromArgb("#FFFF6B6B"));
		obj.Add("DEF", Color.FromArgb("#FF4A90E2"));
		obj.Add("MGK", Color.FromArgb("#FF9B59B6"));
		obj.Add("MDF", Color.FromArgb("#FF27AE60"));
		obj.Add("SPD", Color.FromArgb("#FFF1C40F"));
		obj.Add("INT", Color.FromArgb("#FFE67E22"));
		AttributeColors = obj;
	}
}
