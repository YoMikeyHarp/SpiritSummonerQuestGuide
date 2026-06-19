using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Domain.Exceptions;

public class InsufficientGuildPermissionException : GuildException
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string PlayerId
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string Action
	{
		[CompilerGenerated]
		get;
	}

	public InsufficientGuildPermissionException(string playerId, string guildId, string action)
		: base($"Player '{playerId}' lacks permission to {action} in guild '{guildId}'", guildId)
	{
		PlayerId = playerId;
		Action = action;
	}
}
