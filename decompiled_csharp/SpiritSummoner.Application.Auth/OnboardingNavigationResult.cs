using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Domain.Auth;

namespace SpiritSummoner.Application.Auth;

[RequiredMember]
public record OnboardingNavigationResult
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(OnboardingNavigationResult);
		}
	}

	[RequiredMember]
	public NavigationRoute Route
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public bool ShouldNavigateToUsernameSelection
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public bool IsComplete
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public static OnboardingNavigationResult Navigate(NavigationRoute route)
	{
		return new OnboardingNavigationResult
		{
			Route = route
		};
	}

	public static OnboardingNavigationResult ToUsernameSelection()
	{
		return new OnboardingNavigationResult
		{
			Route = NavigationRoute.Login,
			ShouldNavigateToUsernameSelection = true
		};
	}

	public static OnboardingNavigationResult Complete()
	{
		return new OnboardingNavigationResult
		{
			Route = NavigationRoute.Loading,
			IsComplete = true
		};
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("OnboardingNavigationResult");
		val.Append(" { ");
		if (PrintMembers(val))
		{
			val.Append(' ');
		}
		val.Append('}');
		return ((object)val).ToString();
	}

	[CompilerGenerated]
	protected virtual bool PrintMembers(StringBuilder builder)
	{
		RuntimeHelpers.EnsureSufficientExecutionStack();
		builder.Append("Route = ");
		builder.Append((object)Route);
		builder.Append(", ShouldNavigateToUsernameSelection = ");
		builder.Append(((object)ShouldNavigateToUsernameSelection).ToString());
		builder.Append(", IsComplete = ");
		builder.Append(((object)IsComplete).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(OnboardingNavigationResult? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<NavigationRoute>.Default.Equals(Route, other.Route) && EqualityComparer<bool>.Default.Equals(ShouldNavigateToUsernameSelection, other.ShouldNavigateToUsernameSelection) && EqualityComparer<bool>.Default.Equals(IsComplete, other.IsComplete));
	}

	[CompilerGenerated]
	[SetsRequiredMembers]
	protected OnboardingNavigationResult(OnboardingNavigationResult original)
	{
		Route = original.Route;
		ShouldNavigateToUsernameSelection = original.ShouldNavigateToUsernameSelection;
		IsComplete = original.IsComplete;
	}

	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public OnboardingNavigationResult()
	{
	}
}
