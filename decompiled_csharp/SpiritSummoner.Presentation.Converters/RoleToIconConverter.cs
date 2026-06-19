using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using SpiritSummoner.Domain.Enums.Guilds;

namespace SpiritSummoner.Presentation.Converters;

public class RoleToIconConverter : IMultiValueConverter
{
	public object Convert(object[] values, global::System.Type targetType, object parameter, CultureInfo culture)
	{
		if (values == null || values.Length == 0)
		{
			return "\ud83d\udc64";
		}
		if (!(values[0] is GuildRole guildRole) || 1 == 0)
		{
			return "\ud83d\udc64";
		}
		if (1 == 0)
		{
		}
		string result = guildRole switch
		{
			GuildRole.Guildmaster => "\ud83d\udc51", 
			GuildRole.Vice_Guildmaster => "⭐", 
			GuildRole.Officer => "\ud83d\udc8e", 
			GuildRole.Member => "\ud83d\udc64", 
			_ => "\ud83d\udc64", 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public object[] ConvertBack(object value, global::System.Type[] targetTypes, object parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
