using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Application.Enums;

namespace SpiritSummoner.Application.Events;

public class StateChangedEventArgs : EventArgs
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public StateChangeScope Scope
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

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
	public string ChangeType
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


	public StateChangedEventArgs(StateChangeScope scope, string changeType, string? entityId = null, IReadOnlyDictionary<string, object>? changedValues = null)
	{
		Scope = scope;
		ChangeType = changeType;
		EntityId = entityId;
		ChangedValues = (IReadOnlyDictionary<string, object>)(((object)changedValues) ?? ((object)new Dictionary<string, object>()));
	}
}
