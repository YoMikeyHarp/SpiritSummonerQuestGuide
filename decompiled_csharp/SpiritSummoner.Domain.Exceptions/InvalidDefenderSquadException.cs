using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Domain.Exceptions;

public class InvalidDefenderSquadException : GuildWarException
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int RequiredSize
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int ActualSize
	{
		[CompilerGenerated]
		get;
	}

	public InvalidDefenderSquadException(string guildId, int actualSize, int requiredSize = 3)
		: base($"Defender squad must have exactly {requiredSize} spirits (got {actualSize})", guildId)
	{
		RequiredSize = requiredSize;
		ActualSize = actualSize;
	}
}
