using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace SpiritSummoner.Presentation.Converters;

public class TaskActionToColorConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is string text)
		{
			string text2 = text.ToLower();
			if (1 == 0)
			{
			}
			object result;
			switch (_003CPrivateImplementationDetails_003E.ComputeStringHash(text2))
			{
			case 660393929u:
				if (!(text2 == "fight"))
				{
					goto default;
				}
				result = Application.Current.Resources["GradientTaskActionFight"];
				break;
			case 3728831771u:
				if (!(text2 == "duel"))
				{
					goto default;
				}
				result = Application.Current.Resources["GradientTaskActionFight"];
				break;
			case 3338526268u:
				if (!(text2 == "explore"))
				{
					goto default;
				}
				result = Application.Current.Resources["GradientTaskActionExplore"];
				break;
			case 3724402957u:
				if (!(text2 == "enter"))
				{
					goto default;
				}
				result = Application.Current.Resources["GradientTaskActionExplore"];
				break;
			case 3411225317u:
				if (!(text2 == "stop"))
				{
					goto default;
				}
				result = Application.Current.Resources["GradientTaskActionExplore"];
				break;
			case 2399039025u:
				if (!(text2 == "collect"))
				{
					goto default;
				}
				result = Application.Current.Resources["GradientTaskActionCollect"];
				break;
			case 136609321u:
				if (!(text2 == "accept"))
				{
					goto default;
				}
				result = Application.Current.Resources["GradientTaskActionCollect"];
				break;
			case 677985285u:
				if (!(text2 == "hear"))
				{
					goto default;
				}
				result = Application.Current.Resources["GradientTaskActionCollect"];
				break;
			case 338486351u:
				if (!(text2 == "talk"))
				{
					goto default;
				}
				result = Application.Current.Resources["GradientTaskActionCollect"];
				break;
			case 4258776482u:
				if (!(text2 == "receive"))
				{
					goto default;
				}
				result = Application.Current.Resources["GradientTaskActionCollect"];
				break;
			case 1015113409u:
				if (!(text2 == "craft"))
				{
					goto default;
				}
				result = Color.FromArgb("#3498DB");
				break;
			case 1362521689u:
				if (!(text2 == "trade"))
				{
					goto default;
				}
				result = Color.FromArgb("#9B59B6");
				break;
			case 1658572492u:
				if (!(text2 == "research"))
				{
					goto default;
				}
				result = Color.FromArgb("#F1C40F");
				break;
			default:
				result = Colors.Gray;
				break;
			}
			if (1 == 0)
			{
			}
			return result;
		}
		return Colors.Gray;
	}

	public object ConvertBack(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
