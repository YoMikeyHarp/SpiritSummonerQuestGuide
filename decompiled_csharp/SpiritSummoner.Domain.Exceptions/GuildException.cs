using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Domain.Exceptions;

public abstract class GuildException : global::System.Exception
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? GuildId
	{
		[CompilerGenerated]
		get;
	}

	protected GuildException(string message, string? guildId = null)
		: base(message)
	{
		GuildId = guildId;
	}

	protected GuildException(string message, string? guildId, global::System.Exception innerException)
		: base(message, innerException)
	{
		GuildId = guildId;
	}
}
