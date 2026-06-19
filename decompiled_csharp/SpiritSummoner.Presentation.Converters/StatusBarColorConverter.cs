using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using SpiritSummoner.Domain.Enums.Spirits;

namespace SpiritSummoner.Presentation.Converters;

public class StatusBarColorConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type? targetType, object? parameter, CultureInfo culture)
	{
		if (value is SpiritType spiritType)
		{
			if (1 == 0)
			{
			}
			string result = spiritType switch
			{
				SpiritType.Water => "#FF42A2DE", 
				SpiritType.Poison => "#FFF86BEE", 
				SpiritType.Dark => "#FF252725", 
				SpiritType.Fire => "#FFE42727", 
				SpiritType.Grass => "#FF3CAA42", 
				SpiritType.Light => "#FFFEF489", 
				SpiritType.Wind => "#FF7992F4", 
				SpiritType.Electric => "#FFFAE998", 
				SpiritType.Ground => "#FFCB9A38", 
				SpiritType.Metal => "#FFB0B0B0", 
				SpiritType.Neutral => "#FFFFF9F9", 
				_ => "#FFFFF9F9", 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		if (value is string text)
		{
			if (1 == 0)
			{
			}
			string result;
			switch (_003CPrivateImplementationDetails_003E.ComputeStringHash(text))
			{
			case 3593819824u:
				if (!(text == "Water"))
				{
					goto default;
				}
				result = "#FFA2D7F8";
				break;
			case 3158204625u:
				if (!(text == "Poison"))
				{
					goto default;
				}
				result = "#FFFAC2F6";
				break;
			case 1163329637u:
				if (!(text == "Dark"))
				{
					goto default;
				}
				result = "#FF252725";
				break;
			case 4159608695u:
				if (!(text == "Earth"))
				{
					goto default;
				}
				result = "#FFF5D697";
				break;
			case 248996601u:
				if (!(text == "Fire"))
				{
					goto default;
				}
				result = "#FFFD7777";
				break;
			case 1479220765u:
				if (!(text == "Grass"))
				{
					goto default;
				}
				result = "#FF76CD73";
				break;
			case 2329082063u:
				if (!(text == "Light"))
				{
					goto default;
				}
				result = "#FFFEF489";
				break;
			case 3912435576u:
				if (!(text == "Neutral"))
				{
					goto default;
				}
				result = "#FFFFF9F9";
				break;
			case 2487303463u:
				if (!(text == "Wind"))
				{
					goto default;
				}
				result = "#FF7992F4";
				break;
			case 2238249950u:
				if (!(text == "Electric"))
				{
					goto default;
				}
				result = "#FFFAE998";
				break;
			case 3803529630u:
				if (!(text == "Ground"))
				{
					goto default;
				}
				result = "#FFFFF3B9";
				break;
			default:
				result = "#FFFFF9F9";
				break;
			}
			if (1 == 0)
			{
			}
			return result;
		}
		return "stop.png";
	}

	public object ConvertBack(object? value, global::System.Type? targetType, object? parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
