using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Guilds;

namespace SpiritSummoner.Application.State;

public interface IGuildStateService
{
	string? CurrentGuildId { get; }

	bool HasActiveWar { get; }

	bool IsListening { get; }

	event EventHandler<GuildStateChangedEventArgs>? GuildStateChanged;

	global::System.Threading.Tasks.Task SetCurrentGuildAsync(string guildId);

	void ClearCurrentGuild();

	Guild? GetCurrentGuild();

	global::System.Collections.Generic.IReadOnlyList<GuildMember> GetMembers();

	GuildMember? GetMember(string playerId);

	global::System.Collections.Generic.IReadOnlyList<GuildMember> GetDefenders();

	global::System.Collections.Generic.IReadOnlyList<GuildMember> GetMainDefenders();

	global::System.Threading.Tasks.Task<Result<bool>> ApplyGuildUpdateAsync(GuildBatchUpdate batchUpdate);

	global::System.Threading.Tasks.Task<Result<bool>> RefreshGuildAsync();

	void StartRealtimeSync();

	void StopRealtimeSync();

	internal Guild? GetMutableGuild();
}
