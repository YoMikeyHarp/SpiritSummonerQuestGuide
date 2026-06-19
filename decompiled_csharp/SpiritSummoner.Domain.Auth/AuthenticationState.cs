namespace SpiritSummoner.Domain.Auth;

public enum AuthenticationState
{
	Unauthenticated,
	CheckingUserExists,
	RequiresRegistration,
	AwaitingUsername,
	CreatingPlayer,
	Onboarding,
	LoadingSession,
	Ready
}
