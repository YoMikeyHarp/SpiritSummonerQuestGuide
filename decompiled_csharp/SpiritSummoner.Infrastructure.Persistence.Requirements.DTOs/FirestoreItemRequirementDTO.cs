using System.Diagnostics;
using System.Runtime.CompilerServices;
using Plugin.Firebase.Firestore;

namespace SpiritSummoner.Infrastructure.Persistence.Requirements.DTOs;

public sealed class FirestoreItemRequirementDTO : IFirestoreObject
{
	[FirestoreProperty("itemType")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? ItemType
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
}
