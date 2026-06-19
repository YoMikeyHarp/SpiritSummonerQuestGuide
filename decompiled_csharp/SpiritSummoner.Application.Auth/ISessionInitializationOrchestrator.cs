using System.Threading.Tasks;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Application.Auth;

public interface ISessionInitializationOrchestrator
{
	string? CurrentSessionId { get; }

	global::System.Threading.Tasks.Task<Result<Player>> InitializeSessionAsync(string userId);

	bool IsSessionValid();

	void ClearSession();

	global::System.Threading.Tasks.Task<Result<Player>> ReconcileLocalStateAsync(string userId);
}
