using System.Collections.Generic;
using System.Threading.Tasks;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Enums.Guilds;

namespace SpiritSummoner.Domain.Repositories;

public interface IGuildMemberRepository
{
	global::System.Threading.Tasks.Task<bool> JoinGuildAsync(string playerId, string playerName, string guildId, int playerLevel);

	global::System.Threading.Tasks.Task<bool> LeaveGuildAsync(string playerId, string guildId, Guild currentGuild);

	global::System.Threading.Tasks.Task<bool> KickMemberAsync(string guildId, string targetPlayerId, string kickedByPlayerId);

	global::System.Threading.Tasks.Task<bool> PromoteMemberAsync(string guildId, string targetPlayerId, GuildRole newRole);

	global::System.Threading.Tasks.Task<bool> DemoteMemberAsync(string guildId, string targetPlayerId, GuildRole newRole);

	global::System.Threading.Tasks.Task<bool> TransferLeadershipAsync(string guildId, string newLeaderId, string currentLeaderId);

	global::System.Threading.Tasks.Task<GuildMember?> GetMemberAsync(string guildId, string playerId);

	global::System.Threading.Tasks.Task<Dictionary<string, GuildMember>> GetGuildMembersAsync(string guildId);

	global::System.Threading.Tasks.Task<bool> UpdateMemberContributionAsync(string guildId, string playerId, int contributionAmount);

	global::System.Threading.Tasks.Task<bool> SendJoinRequestAsync(string playerId, string guildId, string? message = null);

	global::System.Threading.Tasks.Task<bool> ApproveJoinRequestAsync(string guildId, string requestId, string approvedByPlayerId);

	global::System.Threading.Tasks.Task<bool> RejectJoinRequestAsync(string guildId, string requestId, string rejectedByPlayerId);

	global::System.Threading.Tasks.Task<List<GuildJoinRequest>> GetPendingJoinRequestsAsync(string guildId);

	global::System.Threading.Tasks.Task<bool> SendGuildInvitationAsync(string guildId, string targetPlayerId, string invitedByPlayerId);

	global::System.Threading.Tasks.Task<bool> AcceptInvitationAsync(string invitationId, string playerId, Player currentPlayer);

	global::System.Threading.Tasks.Task<bool> DeclineInvitationAsync(string invitationId, string playerId);

	global::System.Threading.Tasks.Task<List<GuildInvitation>> GetPlayerInvitationsAsync(string playerId);
}
