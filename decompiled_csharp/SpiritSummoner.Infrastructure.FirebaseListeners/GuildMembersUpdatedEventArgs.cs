using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Domain.Entities.Guilds;

namespace SpiritSummoner.Infrastructure.FirebaseListeners;

public class GuildMembersUpdatedEventArgs : EventArgs
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, GuildMember> Members
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = new Dictionary<string, GuildMember>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string GuildId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = string.Empty;


	public GuildMembersUpdatedEventArgs(Dictionary<string, GuildMember> members, string guildId)
	{
		Members = members;
		GuildId = guildId;
	}
}
