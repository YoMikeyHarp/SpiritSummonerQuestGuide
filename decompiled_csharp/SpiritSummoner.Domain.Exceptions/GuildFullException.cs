using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Domain.Exceptions;

public class GuildFullException : GuildException
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int MaxMembers
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int CurrentMembers
	{
		[CompilerGenerated]
		get;
	}

	public GuildFullException(string guildId, int currentMembers, int maxMembers)
		: base($"Guild is full ({currentMembers}/{maxMembers} members)", guildId)
	{
		CurrentMembers = currentMembers;
		MaxMembers = maxMembers;
	}
}
