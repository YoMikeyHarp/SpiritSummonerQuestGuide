using System;
using System.Collections.Generic;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Interfaces.Services;

namespace SpiritSummoner.Domain.Services;

public class PlayerFactory : IPlayerFactory
{
	public Player CreateNewPlayer(string playerId, string username, string partnerSpiritId)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrWhiteSpace(playerId))
		{
			throw new ArgumentException("Player ID cannot be empty", "playerId");
		}
		if (string.IsNullOrWhiteSpace(username))
		{
			throw new ArgumentException("Username cannot be empty", "username");
		}
		if (string.IsNullOrWhiteSpace(partnerSpiritId))
		{
			throw new ArgumentException("Partner spirit ID cannot be empty", "partnerSpiritId");
		}
		Player player = new Player();
		typeof(Player).GetProperty("PlayerID").SetValue((object)player, (object)playerId);
		typeof(Player).GetProperty("Playername").SetValue((object)player, (object)username);
		player.SetLevel(1);
		player.SetExperience(0.0);
		player.SetMaxEXP(20.0);
		player.SetMaxEP(12);
		player.SetEP(12);
		player.SetMaxSP(5);
		player.SetSP(5);
		player.SetCurrency("gold", 500L);
		player.SetCurrency("gems", 0L);
		player.SetCurrency("clancredits", 0L);
		player.SetCurrency("reputation", 0L);
		player.SetPartnerSpirit(partnerSpiritId);
		player.SetActiveSquadSlot(1);
		typeof(Player).GetProperty("LastEpRegenTime").SetValue((object)player, (object)DateTimeOffset.UtcNow);
		typeof(Player).GetProperty("LastSpRegenTime").SetValue((object)player, (object)DateTimeOffset.UtcNow);
		PlayerQuest obj = new PlayerQuest
		{
			QuestId = "story"
		};
		Dictionary<string, TaskProgress> obj2 = new Dictionary<string, TaskProgress>();
		obj2.Add("story_darkforest_task001", new TaskProgress
		{
			IsCompleted = false,
			Step = 0
		});
		obj.Tasks = obj2;
		PlayerQuest playerQuest = obj;
		PlayerQuest obj3 = new PlayerQuest
		{
			QuestId = "challenge"
		};
		Dictionary<string, TaskProgress> obj4 = new Dictionary<string, TaskProgress>();
		obj4.Add("beta_battles_001", new TaskProgress
		{
			IsCompleted = false,
			Step = 0
		});
		obj3.Tasks = obj4;
		PlayerQuest playerQuest2 = obj3;
		Dictionary<string, PlayerQuest> obj5 = new Dictionary<string, PlayerQuest>();
		obj5.Add("story", playerQuest);
		obj5.Add("challenge", playerQuest2);
		player.SetPlayerQuests(obj5);
		return player;
	}
}
