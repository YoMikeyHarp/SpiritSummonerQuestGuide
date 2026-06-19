using System.Diagnostics;
using System.Runtime.CompilerServices;
using Plugin.Firebase.Firestore;

namespace SpiritSummoner.Infrastructure.Persistence.DTOs.Squads;

public sealed class FirestoreSquadsDTO : IFirestoreObject
{
	[FirestoreProperty("squad1")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public FirestoreSquadDTO Squad1
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new FirestoreSquadDTO
	{
		Slot1SpiritId = "",
		Slot2SpiritId = "",
		Slot3SpiritId = ""
	};


	[FirestoreProperty("squad2")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public FirestoreSquadDTO Squad2
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new FirestoreSquadDTO
	{
		Slot1SpiritId = "",
		Slot2SpiritId = "",
		Slot3SpiritId = ""
	};


	[FirestoreProperty("squad3")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public FirestoreSquadDTO Squad3
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new FirestoreSquadDTO
	{
		Slot1SpiritId = "",
		Slot2SpiritId = "",
		Slot3SpiritId = ""
	};


	[FirestoreProperty("squad4")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public FirestoreSquadDTO Squad4
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new FirestoreSquadDTO
	{
		Slot1SpiritId = "",
		Slot2SpiritId = "",
		Slot3SpiritId = ""
	};


	[FirestoreProperty("squad5")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public FirestoreSquadDTO Squad5
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new FirestoreSquadDTO
	{
		Slot1SpiritId = "",
		Slot2SpiritId = "",
		Slot3SpiritId = ""
	};

}
