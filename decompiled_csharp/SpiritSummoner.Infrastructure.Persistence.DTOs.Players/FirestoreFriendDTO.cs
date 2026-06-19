using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Plugin.Firebase.Firestore;

namespace SpiritSummoner.Infrastructure.Persistence.DTOs.Players;

public sealed class FirestoreFriendDTO : IFirestoreObject
{
	[FirestoreProperty("friendId")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string FriendId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[FirestoreProperty("friendName")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string FriendName
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[FirestoreProperty("addedAt")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset AddedAt
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}
}
