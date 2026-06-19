using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Application.BatchUpdates;

namespace SpiritSummoner.Infrastructure.Services;

internal class PendingUpdate
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string Id
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public PlayerBatchUpdate PlayerBatchUpdate
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = null;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public global::System.DateTime CreatedAt
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int RetryCount
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}
}
