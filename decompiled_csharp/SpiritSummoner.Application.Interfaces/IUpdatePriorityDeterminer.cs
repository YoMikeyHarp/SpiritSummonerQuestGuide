using SpiritSummoner.Application.BatchUpdates;

namespace SpiritSummoner.Application.Interfaces;

public interface IUpdatePriorityDeterminer
{
	bool IsCriticalUpdate(PlayerBatchUpdate update);
}
