using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Plugin.Firebase.Firestore;

namespace SpiritSummoner.Infrastructure.Persistence.DTOs.Quests;

public sealed class FirestoreQuestOpponentDTO : IFirestoreObject
{
	[FirestoreProperty("spirit-settings")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public FirestoreSpiritSettingsDTO? SpiritSettings
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new FirestoreSpiritSettingsDTO();


	[FirestoreProperty("spiritId")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? BaseSpiritId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("moveIds")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<string>? MoveIds
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<string>();

}
