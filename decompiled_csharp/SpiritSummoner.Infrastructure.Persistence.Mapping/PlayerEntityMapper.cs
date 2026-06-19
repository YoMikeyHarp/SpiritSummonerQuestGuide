using System;
using System.Collections.Generic;
using System.Linq;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Enums.Guilds;
using SpiritSummoner.Infrastructure.Persistence.DTOs;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Players;

namespace SpiritSummoner.Infrastructure.Persistence.Mapping;

public static class PlayerEntityMapper
{
	public static Player ToEntity(FirestorePlayerDTO firestoreDto)
	{
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		ArgumentNullException.ThrowIfNull((object)firestoreDto, "firestoreDto");
		Dictionary<string, long> currencies = ((firestoreDto.Currencies != null) ? new Dictionary<string, long>((IDictionary<string, long>)(object)firestoreDto.Currencies) : null);
		Dictionary<string, FirestorePlayerQuestsDTO> playerQuests = firestoreDto.PlayerQuests;
		Dictionary<string, PlayerQuest> playerQuests2 = ((playerQuests != null) ? Enumerable.ToDictionary<KeyValuePair<string, FirestorePlayerQuestsDTO>, string, PlayerQuest>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestorePlayerQuestsDTO>>)playerQuests, (Func<KeyValuePair<string, FirestorePlayerQuestsDTO>, string>)((KeyValuePair<string, FirestorePlayerQuestsDTO> kvp) => kvp.Key), (Func<KeyValuePair<string, FirestorePlayerQuestsDTO>, PlayerQuest>)((KeyValuePair<string, FirestorePlayerQuestsDTO> kvp) => PlayerQuestEntityMapper.ToEntity(kvp.Value))) : null);
		Dictionary<string, List<string>> squads = firestoreDto.Squads;
		Dictionary<string, List<string>> squads2 = ((squads != null) ? Enumerable.ToDictionary<KeyValuePair<string, List<string>>, string, List<string>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, List<string>>>)squads, (Func<KeyValuePair<string, List<string>>, string>)((KeyValuePair<string, List<string>> kvp) => kvp.Key), (Func<KeyValuePair<string, List<string>>, List<string>>)delegate(KeyValuePair<string, List<string>> kvp)
		{
			List<string> value = kvp.Value;
			return ((value != null) ? Enumerable.ToList<string>((global::System.Collections.Generic.IEnumerable<string>)value) : null) ?? new List<string>();
		}) : null);
		List<FirestorePlayerSpiritDTO>? playerSpirits = firestoreDto.PlayerSpirits;
		Dictionary<string, PlayerSpirit> playerSpirits2 = ((playerSpirits != null) ? Enumerable.ToDictionary<PlayerSpirit, string, PlayerSpirit>(Enumerable.Where<PlayerSpirit>(Enumerable.Select<FirestorePlayerSpiritDTO, PlayerSpirit>((global::System.Collections.Generic.IEnumerable<FirestorePlayerSpiritDTO>)playerSpirits, (Func<FirestorePlayerSpiritDTO, PlayerSpirit>)PlayerSpiritEntityMapper.ToEntity), (Func<PlayerSpirit, bool>)((PlayerSpirit s) => !string.IsNullOrEmpty(s.PlayerSpiritID))), (Func<PlayerSpirit, string>)((PlayerSpirit s) => s.PlayerSpiritID), (Func<PlayerSpirit, PlayerSpirit>)((PlayerSpirit s) => s)) : null);
		Dictionary<string, FirestoreInventoryDTO>? inventory = firestoreDto.Inventory;
		Dictionary<string, Inventory> inventory2 = ((inventory != null) ? Enumerable.ToDictionary<KeyValuePair<string, FirestoreInventoryDTO>, string, Inventory>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreInventoryDTO>>)inventory, (Func<KeyValuePair<string, FirestoreInventoryDTO>, string>)((KeyValuePair<string, FirestoreInventoryDTO> kvp) => kvp.Key), (Func<KeyValuePair<string, FirestoreInventoryDTO>, Inventory>)((KeyValuePair<string, FirestoreInventoryDTO> kvp) => new Inventory
		{
			Name = kvp.Value.Name,
			Amount = kvp.Value.Amount
		})) : null);
		BattleStats battleStats = ((firestoreDto.BattleStats != null) ? BattleStats.Rehydrate(firestoreDto.BattleStats.Wins, firestoreDto.BattleStats.Losses, firestoreDto.BattleStats.Score, firestoreDto.BattleStats.Title ?? "Novice", firestoreDto.BattleStats.LastScoreUpdate) : null);
		GuildRole guildRole = default(GuildRole);
		return Player.Rehydrate(firestoreDto.PlayerID, firestoreDto.Playername, firestoreDto.PlayerLevel, firestoreDto.EXP, firestoreDto.MaxEXP, firestoreDto.EP, firestoreDto.MaxEP, firestoreDto.SP, firestoreDto.MaxSP, currencies, playerQuests2, squads2, firestoreDto.ActiveSquadSlot, firestoreDto.PartnerSpiritId, playerSpirits2, inventory2, firestoreDto.ViewedShopItems, firestoreDto.LastShopViewedLevel, battleStats, firestoreDto.LastEpRegenTime, firestoreDto.LastSpRegenTime, firestoreDto.GuildId, (!global::System.Enum.TryParse<GuildRole>(firestoreDto.GuildRole, ref guildRole)) ? GuildRole.Member : guildRole, firestoreDto.GuildJoinedAt, firestoreDto.IsAccountLinked, (firestoreDto.DailyBattleChest != null) ? DailyBattleChest.Rehydrate(firestoreDto.DailyBattleChest.BattlesCompleted, firestoreDto.DailyBattleChest.LastClaimedAt, firestoreDto.DailyBattleChest.LastResetAt) : null, firestoreDto.PlayerIcon);
	}

	public static Player ToEntity(FirestorePublicProfileDTO firestoreDto)
	{
		ArgumentNullException.ThrowIfNull((object)firestoreDto, "firestoreDto");
		List<FirestorePlayerSpiritDTO> playerSpirits = firestoreDto.PlayerSpirits;
		Dictionary<string, PlayerSpirit> playerSpirits2 = ((playerSpirits != null) ? Enumerable.ToDictionary<PlayerSpirit, string, PlayerSpirit>(Enumerable.Where<PlayerSpirit>(Enumerable.Select<FirestorePlayerSpiritDTO, PlayerSpirit>((global::System.Collections.Generic.IEnumerable<FirestorePlayerSpiritDTO>)playerSpirits, (Func<FirestorePlayerSpiritDTO, PlayerSpirit>)PlayerSpiritEntityMapper.ToEntity), (Func<PlayerSpirit, bool>)((PlayerSpirit s) => !string.IsNullOrEmpty(s.PlayerSpiritID))), (Func<PlayerSpirit, string>)((PlayerSpirit s) => s.PlayerSpiritID), (Func<PlayerSpirit, PlayerSpirit>)((PlayerSpirit s) => s)) : null);
		BattleStats battleStats = ((firestoreDto.BattleStats != null) ? BattleStats.Rehydrate(firestoreDto.BattleStats.Wins, firestoreDto.BattleStats.Losses, firestoreDto.BattleStats.Score, firestoreDto.BattleStats.Title ?? "Novice", firestoreDto.BattleStats.LastScoreUpdate) : null);
		string? playerID = firestoreDto.PlayerID;
		string? playerName = firestoreDto.PlayerName;
		int? playerLevel = firestoreDto.PlayerLevel;
		Dictionary<string, List<string>> obj = new Dictionary<string, List<string>>();
		obj.Add("1", firestoreDto.ActiveSquad);
		return Player.Rehydrate(playerID, playerName, playerLevel, null, null, null, null, null, null, null, null, obj, 1, firestoreDto.PartnerSpiritId, playerSpirits2, null, null, null, battleStats, null, null, firestoreDto.GuildId, null, null, null, null, firestoreDto.PlayerIcon);
	}

	public static List<Player> ToEntities(global::System.Collections.Generic.IEnumerable<FirestorePlayerDTO> firestoreDtos)
	{
		return ((firestoreDtos != null) ? Enumerable.ToList<Player>(Enumerable.Select<FirestorePlayerDTO, Player>(firestoreDtos, (Func<FirestorePlayerDTO, Player>)ToEntity)) : null) ?? new List<Player>();
	}

	public static List<Player> ToEntities(global::System.Collections.Generic.IEnumerable<FirestorePublicProfileDTO> firestoreDtos)
	{
		return ((firestoreDtos != null) ? Enumerable.ToList<Player>(Enumerable.Select<FirestorePublicProfileDTO, Player>(firestoreDtos, (Func<FirestorePublicProfileDTO, Player>)ToEntity)) : null) ?? new List<Player>();
	}
}
