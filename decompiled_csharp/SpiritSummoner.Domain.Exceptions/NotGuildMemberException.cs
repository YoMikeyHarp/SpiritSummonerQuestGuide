using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Domain.Exceptions;

public class NotGuildMemberException : GuildException
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string PlayerId
	{
		[CompilerGenerated]
		get;
	}

	public NotGuildMemberException(string playerId, string guildId)
		: base($"Player '{playerId}' is not a member of guild '{guildId}'", guildId)
	{
		PlayerId = playerId;
	}
}
