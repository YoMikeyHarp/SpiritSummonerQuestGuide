using System;
using System.Threading.Tasks;
using SpiritSummoner.Application.UseCases.Guilds;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Domain.Repositories;

public interface IGuildCoreRepository
{
	global::System.Threading.Tasks.Task<Guild?> GetByIdAsync(string guildId);

	global::System.Threading.Tasks.Task<Guild?> CreateGuildAsync(CreateGuildRequest request, Player player);

	global::System.Threading.Tasks.Task<bool> UpdateAsync(Guild guild);

	global::System.Threading.Tasks.Task<bool> UpdateGuildRequestAsync(UpdateGuildRequest guild);

	global::System.Threading.Tasks.Task<bool> SetDisbandScheduleAsync(string guildId, DateTimeOffset? disbandAt);

	global::System.Threading.Tasks.Task<bool> DeleteAsync(string guildId);
}
