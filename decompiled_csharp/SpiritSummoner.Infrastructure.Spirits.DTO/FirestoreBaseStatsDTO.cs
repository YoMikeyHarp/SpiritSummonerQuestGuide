using System.Diagnostics;
using System.Runtime.CompilerServices;
using Plugin.Firebase.Firestore;

namespace SpiritSummoner.Infrastructure.Spirits.DTO;

public sealed class FirestoreBaseStatsDTO : IFirestoreObject
{
	[FirestoreProperty("Level")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Level
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("HP")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int HP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("ATK")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int ATK
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("DEF")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int DEF
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("MGK")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int SATK
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("MDF")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int SDEF
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("SPD")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int SPD
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("INT")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int INT
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}
}
