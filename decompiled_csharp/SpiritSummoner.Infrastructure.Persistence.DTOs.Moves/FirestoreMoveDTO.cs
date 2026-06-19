using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Plugin.Firebase.Firestore;
using SpiritSummoner.Domain.Enums.Spirits;

namespace SpiritSummoner.Infrastructure.Persistence.DTOs.Moves;

public sealed class FirestoreMoveDTO : IFirestoreObject
{
	[FirestoreProperty("Name")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Name
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("Type")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Typeraw
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public SpiritType Type
	{
		get
		{
			SpiritType spiritType = default(SpiritType);
			return global::System.Enum.TryParse<SpiritType>(Typeraw, ref spiritType) ? spiritType : SpiritType.None;
		}
	}

	[FirestoreProperty("Power")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Power
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("MoveType")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? MoveTyperaw
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public MoveType MoveType
	{
		get
		{
			MoveType moveType = default(MoveType);
			return global::System.Enum.TryParse<MoveType>(MoveTyperaw, ref moveType) ? moveType : MoveType.Physical;
		}
	}

	[FirestoreProperty("UnlockRequirements")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public FirestoreMoveRequirementsDTO UnlockRequirements
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new FirestoreMoveRequirementsDTO();

}
