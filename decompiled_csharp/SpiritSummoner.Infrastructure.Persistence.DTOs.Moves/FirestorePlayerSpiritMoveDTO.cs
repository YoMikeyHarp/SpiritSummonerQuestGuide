using System.Diagnostics;
using System.Runtime.CompilerServices;
using Plugin.Firebase.Firestore;

namespace SpiritSummoner.Infrastructure.Persistence.DTOs.Moves;

public sealed class FirestorePlayerSpiritMoveDTO : IFirestoreObject
{
	[FirestoreProperty("is-active")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsActiveMove
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("is-unlocked")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsUnlocked
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}
}
