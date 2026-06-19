using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Domain.Exceptions;

public class AlreadyInGuildException : GuildException
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string PlayerId
	{
		[CompilerGenerated]
		get;
	}

	public AlreadyInGuildException(string playerId, string guildId)
		: base($"Player '{playerId}' is already in guild '{guildId}'", guildId)
	{
		PlayerId = playerId;
	}
}
