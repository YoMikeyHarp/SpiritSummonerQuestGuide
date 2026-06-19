namespace SpiritSummoner.Domain.Exceptions;

public class NoDefendersAvailableException : GuildWarException
{
	public NoDefendersAvailableException(string guildId, string opponentGuildId)
		: base("No defenders available to battle in guild '" + opponentGuildId + "'", guildId, opponentGuildId)
	{
	}
}
