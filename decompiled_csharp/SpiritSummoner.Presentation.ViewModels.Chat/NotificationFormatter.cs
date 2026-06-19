using System.Collections.Generic;
using SpiritSummoner.Domain.Enums.Common;

namespace SpiritSummoner.Presentation.ViewModels.Chat;

public static class NotificationFormatter
{
	public static string GetIcon(NotificationType type)
	{
		if (1 == 0)
		{
		}
		string result = type switch
		{
			NotificationType.GuildInvitation => "⚔\ufe0f", 
			NotificationType.GuildInvitationAccepted => "✅", 
			NotificationType.GuildInvitationDeclined => "❌", 
			NotificationType.GuildJoinRequest => "\ud83d\udce8", 
			NotificationType.GuildJoined => "\ud83c\udff0", 
			NotificationType.GuildLeft => "\ud83d\udeaa", 
			NotificationType.GuildKicked => "\ud83d\udeab", 
			NotificationType.GuildPromoted => "⬆\ufe0f", 
			NotificationType.GuildDemoted => "⬇\ufe0f", 
			NotificationType.GuildDisbanded => "\ud83d\udc94", 
			NotificationType.GuildWarStarted => "\ud83d\udde1\ufe0f", 
			NotificationType.GuildWarAttacked => "\ud83d\udee1\ufe0f", 
			NotificationType.GuildWarVictory => "\ud83c\udfc6", 
			NotificationType.GuildWarDefeat => "\ud83d\udc80", 
			NotificationType.FriendRequest => "\ud83d\udc4b", 
			NotificationType.FriendRequestAccepted => "\ud83e\udd1d", 
			NotificationType.FriendRequestDeclined => "\ud83d\ude14", 
			NotificationType.TradeRequest => "\ud83d\udd04", 
			NotificationType.TradeAccepted => "\ud83d\udcb0", 
			NotificationType.TradeCompleted => "✔\ufe0f", 
			NotificationType.DirectMessage => "\ud83d\udcac", 
			NotificationType.GuildMessage => "\ud83d\udce2", 
			NotificationType.BattleChallengeReceived => "⚡", 
			NotificationType.BattleCompleted => "\ud83c\udfaf", 
			NotificationType.RewardAvailable => "\ud83c\udf81", 
			NotificationType.AchievementUnlocked => "\ud83c\udfc5", 
			_ => "\ud83d\udd14", 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static string GetTitle(NotificationType type)
	{
		if (1 == 0)
		{
		}
		string result = type switch
		{
			NotificationType.GuildInvitation => "Guild Invitation", 
			NotificationType.GuildInvitationAccepted => "Invitation Accepted", 
			NotificationType.GuildInvitationDeclined => "Invitation Declined", 
			NotificationType.GuildJoinRequest => "Join Request", 
			NotificationType.GuildJoined => "Guild Joined", 
			NotificationType.GuildLeft => "Guild Left", 
			NotificationType.GuildKicked => "Kicked from Guild", 
			NotificationType.GuildPromoted => "Promoted", 
			NotificationType.GuildDemoted => "Demoted", 
			NotificationType.GuildDisbanded => "Guild Disbanded", 
			NotificationType.GuildWarStarted => "Guild War Started", 
			NotificationType.GuildWarAttacked => "Under Attack", 
			NotificationType.GuildWarVictory => "Victory!", 
			NotificationType.GuildWarDefeat => "Defeat", 
			NotificationType.FriendRequest => "Friend Request", 
			NotificationType.FriendRequestAccepted => "Friend Request Accepted", 
			NotificationType.FriendRequestDeclined => "Friend Request Declined", 
			NotificationType.TradeRequest => "Trade Request", 
			NotificationType.TradeAccepted => "Trade Accepted", 
			NotificationType.TradeCompleted => "Trade Completed", 
			NotificationType.DirectMessage => "New Message", 
			NotificationType.GuildMessage => "Guild Message", 
			NotificationType.BattleChallengeReceived => "Battle Challenge", 
			NotificationType.BattleCompleted => "Battle Result", 
			NotificationType.RewardAvailable => "Reward Available", 
			NotificationType.AchievementUnlocked => "Achievement Unlocked", 
			_ => "Notification", 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static string GetBody(NotificationType type, Dictionary<string, object> data)
	{
		if (1 == 0)
		{
		}
		string result = type switch
		{
			NotificationType.FriendRequest => $"{data.GetStr("senderName")} (Lv {data.GetInt("senderLevel")}) sent you a friend request.", 
			NotificationType.FriendRequestAccepted => data.GetStr("accepterName") + " accepted your friend request.", 
			NotificationType.FriendRequestDeclined => "Your friend request was declined.", 
			NotificationType.GuildInvitation => "You've been invited to join " + data.GetStr("guildName") + ".", 
			NotificationType.GuildInvitationAccepted => data.GetStr("playerName") + " accepted your guild invitation.", 
			NotificationType.GuildInvitationDeclined => data.GetStr("playerName") + " declined your guild invitation.", 
			NotificationType.GuildJoinRequest => data.GetStr("playerName") + " wants to join your guild.", 
			NotificationType.GuildJoined => "You joined " + data.GetStr("guildName") + ".", 
			NotificationType.GuildLeft => "You left " + data.GetStr("guildName") + ".", 
			NotificationType.GuildKicked => "You were kicked from " + data.GetStr("guildName") + ".", 
			NotificationType.GuildPromoted => "You were promoted in " + data.GetStr("guildName") + ".", 
			NotificationType.GuildDemoted => "You were demoted in " + data.GetStr("guildName") + ".", 
			NotificationType.GuildDisbanded => data.GetStr("guildName") + " has been disbanded.", 
			NotificationType.GuildWarStarted => "A guild war has started. Prepare your squad!", 
			NotificationType.GuildWarAttacked => "Your guild was attacked by " + data.GetStr("attackerName") + ".", 
			NotificationType.GuildWarVictory => "Your guild won the war!", 
			NotificationType.GuildWarDefeat => "Your guild lost the war.", 
			NotificationType.TradeRequest => data.GetStr("senderName") + " sent you a trade request.", 
			NotificationType.TradeAccepted => "Your trade request was accepted.", 
			NotificationType.TradeCompleted => "A trade has been completed.", 
			NotificationType.DirectMessage => data.GetStr("senderName") + ": " + data.GetStr("preview"), 
			NotificationType.GuildMessage => data.GetStr("senderName") + ": " + data.GetStr("preview"), 
			NotificationType.BattleChallengeReceived => data.GetStr("challengerName") + " challenged you to a battle.", 
			NotificationType.BattleCompleted => data.GetBool("victory") ? "You won the battle!" : "You lost the battle.", 
			NotificationType.RewardAvailable => "A reward is ready to collect: " + data.GetStr("rewardName") + ".", 
			NotificationType.AchievementUnlocked => "Achievement unlocked: " + data.GetStr("achievementName") + ".", 
			_ => "You have a new notification.", 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
