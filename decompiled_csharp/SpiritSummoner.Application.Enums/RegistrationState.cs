namespace SpiritSummoner.Application.Enums;

public enum RegistrationState
{
	NotStarted,
	Checking,
	AwaitingTermsAcceptance,
	OnboardingPreUsername,
	AwaitingUsername,
	AwaitingAccountLinkChoice,
	CreatingPlayer,
	OnboardingPostUsername,
	Complete,
	Failed
}
