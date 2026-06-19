using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Application.State;

public class GuildStateChangedEventArgs : EventArgs
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public GuildChangeType ChangeType
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
	public string? EntityId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public IReadOnlyDictionary<string, object> ChangedValues
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = (IReadOnlyDictionary<string, object>)(object)new Dictionary<string, object>();


	public GuildStateChangedEventArgs(GuildChangeType changeType, string guildId, string? entityId = null, IReadOnlyDictionary<string, object>? changedValues = null)
	{
		ChangeType = changeType;
		GuildId = guildId;
		EntityId = entityId;
		ChangedValues = (IReadOnlyDictionary<string, object>)(((object)changedValues) ?? ((object)new Dictionary<string, object>()));
	}
}
