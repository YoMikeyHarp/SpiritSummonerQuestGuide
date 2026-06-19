namespace SpiritSummoner.Domain.Exceptions;

public class GuildNotFoundException : GuildException
{
	public GuildNotFoundException(string guildId)
		: base("Guild '" + guildId + "' not found", guildId)
	{
	}
}
