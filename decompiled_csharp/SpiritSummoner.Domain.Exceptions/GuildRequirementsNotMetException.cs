using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Domain.Exceptions;

public class GuildRequirementsNotMetException : GuildException
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? RequiredLevel
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? RequiredTrophies
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? PlayerLevel
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int? PlayerTrophies
	{
		[CompilerGenerated]
		get;
	}

	public GuildRequirementsNotMetException(string guildId, int? requiredLevel = null, int? requiredTrophies = null, int? playerLevel = null, int? playerTrophies = null)
		: base(BuildMessage(requiredLevel, requiredTrophies, playerLevel, playerTrophies), guildId)
	{
		RequiredLevel = requiredLevel;
		RequiredTrophies = requiredTrophies;
		PlayerLevel = playerLevel;
		PlayerTrophies = playerTrophies;
	}

	private static string BuildMessage(int? reqLevel, int? reqTrophies, int? playerLevel, int? playerTrophies)
	{
		List<string> val = new List<string>();
		if (reqLevel.HasValue && playerLevel.HasValue && playerLevel < reqLevel)
		{
			val.Add($"level {playerLevel} < required {reqLevel}");
		}
		if (reqTrophies.HasValue && playerTrophies.HasValue && playerTrophies < reqTrophies)
		{
			val.Add($"trophies {playerTrophies} < required {reqTrophies}");
		}
		return (val.Count > 0) ? ("Guild requirements not met: " + string.Join(", ", (global::System.Collections.Generic.IEnumerable<string>)val)) : "Guild requirements not met";
	}
}
