using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Plugin.Firebase.Firestore;

namespace SpiritSummoner.Infrastructure.Persistence.DTOs.Players;

public sealed class FirestorePlayerDTO : IFirestoreObject
{
	[FirestoreDocumentId]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? PlayerID
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("playername")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Playername
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("playerpassword")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? PlayerPassword
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("playerlevel")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int PlayerLevel
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("playerexp")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public double EXP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("playermaxexp")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public double MaxEXP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("playerep")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int EP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("playermaxep")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int MaxEP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("playersp")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int SP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("playermaxsp")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int MaxSP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("playercurrencies")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, long>? Currencies
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, long>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, FirestorePlayerQuestsDTO> PlayerQuests
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, FirestorePlayerQuestsDTO>();


	[FirestoreProperty("activeSquadSlot")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int ActiveSquadSlot
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = 1;


	[FirestoreProperty("squads")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, List<string>> Squads
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, List<string>>();


	[FirestoreProperty("partnerSpiritID")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string PartnerSpiritId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<FirestorePlayerSpiritDTO>? PlayerSpirits
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<FirestorePlayerSpiritDTO>();


	[FirestoreProperty("inventory")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, FirestoreInventoryDTO>? Inventory
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("viewedShopItems")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<string> ViewedShopItems
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<string>();


	[FirestoreProperty("lastShopViewedLevel")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int LastShopViewedLevel
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = 1;


	[FirestoreProperty("battleStats")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public FirestoreBattleStatsDTO BattleStats
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new FirestoreBattleStatsDTO();


	[FirestoreProperty("lastEpRegenTime")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset? LastEpRegenTime
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("lastSpRegenTime")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset? LastSpRegenTime
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("guildId")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? GuildId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("guildRole")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? GuildRole
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("guildJoinedAt")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset? GuildJoinedAt
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("isAccountLinked")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsAccountLinked
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = false;


	[FirestoreProperty("activeSessionId")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? ActiveSessionId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("dailyBattleChest")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public FirestoreDailyBattleChestDTO? DailyBattleChest
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("playerIcon")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? PlayerIcon
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}
}
