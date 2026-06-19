using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace SpiritSummoner.Presentation.Converters;

public class MoveTextColorConverter : IValueConverter
{
	private static readonly Dictionary<string, Color> TypeColors;

	public object Convert(object? value, global::System.Type? targetType, object? parameter, CultureInfo? culture)
	{
		string text = value.ToString();
		Color val = default(Color);
		if (text != null && TypeColors.TryGetValue(text, ref val))
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

	static MoveTextColorConverter()
	{
		Dictionary<string, Color> obj = new Dictionary<string, Color>();
		obj.Add("Fire", Color.FromArgb("#FFFF6B6B"));
		obj.Add("Water", Color.FromArgb("#FF4A90E2"));
		obj.Add("Dark", Color.FromArgb("#FF262525"));
		obj.Add("Grass", Color.FromArgb("#FF27AE60"));
		obj.Add("Ground", Color.FromArgb("#FFF1C40F"));
		obj.Add("INT", Color.FromArgb("#FFE67E22"));
		TypeColors = obj;
	}
}
