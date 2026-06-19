using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Domain.Entities.Guilds;

namespace SpiritSummoner.Infrastructure.FirebaseListeners;

public class GuildUpdatedEventArgs : EventArgs
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Guild? Guild
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string GuildId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public global::System.DateTime Timestamp
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = global::System.DateTime.UtcNow;


	public GuildUpdatedEventArgs(Guild? guild, string guildId)
	{
		Guild = guild;
		GuildId = guildId;
	}
}
