using System.Threading.Tasks;
using SpiritSummoner.Domain.Entities.Battles;

namespace SpiritSummoner.Domain.Repositories;

public interface IBattleLogRepository
{
	global::System.Threading.Tasks.Task<bool> WriteAsync(BattleLog log);
}
