using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Domain.Exceptions;

public class MaxDefendersReachedException : GuildWarException
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int MaxDefenders
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int CurrentDefenders
	{
		[CompilerGenerated]
		get;
	}

	public MaxDefendersReachedException(string guildId, int currentDefenders, int maxDefenders)
		: base($"Maximum defenders reached ({currentDefenders}/{maxDefenders})", guildId)
	{
		CurrentDefenders = currentDefenders;
		MaxDefenders = maxDefenders;
	}
}
