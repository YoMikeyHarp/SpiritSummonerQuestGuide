using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Plugin.Firebase.Firestore;

namespace SpiritSummoner.Infrastructure.Persistence.DTOs.Guilds;

public sealed class FirestoreGuildActivePerkDTO : IFirestoreObject
{
	[FirestoreProperty("tier")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Tier
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("activatedAt")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset ActivatedAt
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("activatedByPlayerId")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? ActivatedByPlayerId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}
}
