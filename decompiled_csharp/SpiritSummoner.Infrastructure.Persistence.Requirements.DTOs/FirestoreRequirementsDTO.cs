using System.Diagnostics;
using System.Runtime.CompilerServices;
using Plugin.Firebase.Firestore;

namespace SpiritSummoner.Infrastructure.Persistence.Requirements.DTOs;

public sealed class FirestoreRequirementsDTO : IFirestoreObject
{
	[FirestoreProperty("levelRequirements")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public FirestoreLevelRequirementDTO? LevelRequirement
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("currencyCostRequirements")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public FirestoreCurrencyCostRequirementDTO? CurrencyCost
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("itemRequirement")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public FirestoreItemRequirementDTO? ItemRequirement
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("evolveRequirements")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public FirestoreEvolveRequirementDTO? EvolveRequirements
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}
}
