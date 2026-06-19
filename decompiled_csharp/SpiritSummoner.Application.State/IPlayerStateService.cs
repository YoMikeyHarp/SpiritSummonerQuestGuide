using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.Events;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;

namespace SpiritSummoner.Application.State;

public interface IPlayerStateService
{
	string? CurrentPlayerId { get; }

	string CurrentRoute { get; }

	event EventHandler<StateChangedEventArgs>? StateChanged;

	internal void SetCurrentSession(Player session);

	void ClearSession();

	void UpdateCurrentRoute(string newRoute);

	Result<T> ExecuteUpdate<T>(Func<Player, ValidationResult> validate, Func<Player, T> update, Func<Player, T, PlayerBatchUpdate> buildBatchUpdate);

	global::System.Threading.Tasks.Task SyncWithServerAsync();

	global::System.Threading.Tasks.Task<Result<bool>> ApplyUpdateWithImmediateSyncAsync(PlayerBatchUpdate batchUpdate);

	global::System.Threading.Tasks.Task EnsureSyncedAsync();

	Player? GetCurrentPlayer();

	PlayerSpirit? GetPlayerSpirit(string playerSpiritId);

	global::System.Collections.Generic.IReadOnlyList<PlayerSpirit> GetAllPlayerSpirits();

	global::System.Collections.Generic.IReadOnlyList<PlayerSpirit> GetActiveSquad();

	PlayerSpirit? GetPartnerSpirit();

	Spirit? GetSpiritTemplate(int baseSpiritId);

	IReadOnlyDictionary<string, List<string>> GetSquads();

	global::System.Collections.Generic.IReadOnlyList<string> GetActiveSquadComposition();
}
