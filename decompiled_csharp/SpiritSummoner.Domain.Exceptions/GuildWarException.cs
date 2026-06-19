using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Domain.Exceptions;

public class GuildWarException : GuildException
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? OpponentGuildId
	{
		[CompilerGenerated]
		get;
	}

	public GuildWarException(string message, string? guildId = null, string? opponentGuildId = null)
		: base(message, guildId)
	{
		OpponentGuildId = opponentGuildId;
	}
}
