using System;
using System.Threading.Tasks;

namespace SpiritSummoner.Infrastructure.Contracts;

public interface IPlayerEnergyRegenerationService
{
	bool IsRegenerating { get; }

	event EventHandler<RegenerationCooldownEventArgs>? CooldownTick;

	void StartRegeneration();

	void StopRegeneration();

	global::System.Threading.Tasks.Task RefreshAsync();
}
