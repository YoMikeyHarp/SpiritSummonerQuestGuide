using System.Threading.Tasks;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Auth;
using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Application.Auth;

public interface IRegistrationOrchestrator
{
	bool IsAnonymousRegistration { get; }

	RegistrationState CurrentState { get; }

	OnboardingStep CurrentOnboardingStep { get; }

	string? PendingUserId { get; }

	string? Username { get; }

	OnboardingDialogueData? CurrentDialogueData { get; }

	StarterSpiritData? StarterSpirit { get; }

	bool IsInOnboarding { get; }

	global::System.Threading.Tasks.Task<Result<bool>> StartRegistrationAsync(string userId, bool isAnonymous = false);

	NavigationRoute AcceptTermsAndStartOnboarding();

	OnboardingNavigationResult AdvanceOnboarding();

	global::System.Threading.Tasks.Task<Result<Player>> CompleteRegistrationAsync(string username, bool isAccountLinked = true);

	NavigationRoute StartPostUsernameOnboarding(string username);

	global::System.Threading.Tasks.Task<RegistrationResumeResult> CheckAndResumeRegistrationAsync(string userId);

	global::System.Threading.Tasks.Task CancelRegistrationAsync();

	void Reset();

	global::System.Threading.Tasks.Task LoadStarterSpiritsAsync();
}
