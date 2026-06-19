using System.Diagnostics;
using System.Runtime.CompilerServices;
using Plugin.Firebase.Firestore;

namespace SpiritSummoner.Infrastructure.Persistence.Requirements.DTOs;

public sealed class FirestoreEvolveRequirementDTO : IFirestoreObject
{
	[FirestoreProperty("levelRequired")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int LevelRequired
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("itemRequired")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? ItemRequired
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("special")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Special
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("amount")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Amount
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("coresRequired")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int CoresRequired
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = 10;

}
