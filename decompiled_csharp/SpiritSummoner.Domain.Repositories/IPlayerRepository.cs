using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Domain.Entities.Battles;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Players;

namespace SpiritSummoner.Domain.Repositories;

public interface IPlayerRepository
{
	global::System.Threading.Tasks.Task<Player?> GetPlayerByIdAsync(string id);

	global::System.Threading.Tasks.Task<List<Player>?> GetPlayersBattleAsync(int teamSize, int limitTo, string currentPlayerId, int currentPlayerLevel);

	global::System.Threading.Tasks.Task<Player?> GetPlayerBattleAsync(string playerId, int teamSize = 1);

	global::System.Threading.Tasks.Task<List<Player>> GetPlayersByIdsForBattleAsync(List<string> playerIds, int teamSize);

	global::System.Threading.Tasks.Task<Player?> AuthenticateAsync(string username, string password, string id);

	global::System.Threading.Tasks.Task<bool> CreatePlayerAsync(Player player);

	global::System.Threading.Tasks.Task CreateUserAsync(FirestoreUserDTO user);

	global::System.Threading.Tasks.Task<bool> CreatePublicProfile(Player player);

	global::System.Threading.Tasks.Task<bool> GetUserByIdAsync(string Id);

	global::System.Threading.Tasks.Task<string> GetEmailByUserAsync(string username);

	global::System.Threading.Tasks.Task<bool> LinkUserAsync(string playerId, string email);

	global::System.Threading.Tasks.Task DeleteUserAsync(FirestoreUserDTO user);

	global::System.Threading.Tasks.Task<BatchUpdateOutcome> BatchUpdatePlayerAsync(PlayerBatchUpdate batchUpdate);

	global::System.Threading.Tasks.Task<bool> CheckUsernameExistsAsync(string username);

	global::System.Threading.Tasks.Task<bool> DeletePlayerAsync(string playerId);

	global::System.Threading.Tasks.Task<List<Player>> SearchPlayersAsync(string searchText, int limit = 20);

	global::System.Threading.Tasks.Task<List<Friend>> GetFriendsAsync(string playerId);

	global::System.Threading.Tasks.Task<bool> AddFriendAsync(string playerId, Friend friend);

	global::System.Threading.Tasks.Task<bool> RemoveFriendAsync(string playerId, string friendId);

	global::System.Threading.Tasks.Task<PlayerDailyBattleTasks?> GetDailyBattleTasksAsync(string playerId, string dateKey);

	global::System.Threading.Tasks.Task<bool> SaveDailyBattleTasksAsync(string playerId, PlayerDailyBattleTasks tasks);

	global::System.Threading.Tasks.Task UpdatePresenceAsync(string playerId);

	global::System.Threading.Tasks.Task<Dictionary<string, ValueTuple<DateTimeOffset?, string?>>> GetFriendPresencesAsync(global::System.Collections.Generic.IEnumerable<string> playerIds);
}
