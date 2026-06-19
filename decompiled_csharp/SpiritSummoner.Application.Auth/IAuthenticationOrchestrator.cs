using System.Threading.Tasks;
using SpiritSummoner.Domain.Auth;

namespace SpiritSummoner.Application.Auth;

public interface IAuthenticationOrchestrator
{
	AuthenticationState CurrentState { get; }

	global::System.Threading.Tasks.Task<AuthenticationResult> HandleAuthStateChangeAsync(string? userId);

	void Reset();
}
