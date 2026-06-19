using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Plugin.Firebase.Firestore;

namespace SpiritSummoner.Infrastructure.Persistence.DTOs.Items;

public class FirestoreHPThresholdEffect
{
	[FirestoreProperty("threshold")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public float Threshold
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("activatesBelowThreshold")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool ActivatesBelowThreshold
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = true;


	[FirestoreProperty("statMultipliers")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, double>? StatMultipliers
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("damageMultiplier")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public float DamageMultiplier
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = 1f;


	[FirestoreProperty("healPerTurn")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public float HealPerTurn
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = 0f;

}
