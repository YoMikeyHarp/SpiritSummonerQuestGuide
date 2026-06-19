using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using SpiritSummoner.Domain.Enums.Guilds;

namespace SpiritSummoner.Presentation.Converters;

public class RoleToColorConverter : IValueConverter
{
	public object Convert(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		if (!(value is GuildRole guildRole) || 1 == 0)
		{
			return Colors.Gray;
		}
		if (1 == 0)
		{
		}
		Color result = (Color)(guildRole switch
		{
			GuildRole.Guildmaster => Color.FromArgb("#FFD700"), 
			GuildRole.Vice_Guildmaster => Color.FromArgb("#60A5FA"), 
			GuildRole.Officer => Color.FromArgb("#A78BFA"), 
			GuildRole.Member => Color.FromArgb("#9CA3AF"), 
			_ => Colors.Gray, 
		});
		if (1 == 0)
		{
		}
		return result;
	}

	public object ConvertBack(object? value, global::System.Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		throw new NotImplementedException();
	}
}
