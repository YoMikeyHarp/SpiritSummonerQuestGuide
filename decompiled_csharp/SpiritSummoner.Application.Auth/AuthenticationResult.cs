using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Domain.Auth;

namespace SpiritSummoner.Application.Auth;

[RequiredMember]
public record AuthenticationResult
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(AuthenticationResult);
		}
	}

	[RequiredMember]
	public NavigationRoute NavigationRoute
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public bool ShowLoadingOverlay
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public string? ErrorMessage
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public bool Success
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public AuthenticationState State
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public static AuthenticationResult CreateSuccess(NavigationRoute route, AuthenticationState state, bool showOverlay = false)
	{
		return new AuthenticationResult
		{
			NavigationRoute = route,
			ShowLoadingOverlay = showOverlay,
			Success = true,
			State = state
		};
	}

	public static AuthenticationResult CreateError(string errorMessage, NavigationRoute fallbackRoute)
	{
		return new AuthenticationResult
		{
			NavigationRoute = fallbackRoute,
			ShowLoadingOverlay = false,
			Success = false,
			ErrorMessage = errorMessage,
			State = AuthenticationState.Unauthenticated
		};
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("AuthenticationResult");
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
		builder.Append("NavigationRoute = ");
		builder.Append((object)NavigationRoute);
		builder.Append(", ShowLoadingOverlay = ");
		builder.Append(((object)ShowLoadingOverlay).ToString());
		builder.Append(", ErrorMessage = ");
		builder.Append((object)ErrorMessage);
		builder.Append(", Success = ");
		builder.Append(((object)Success).ToString());
		builder.Append(", State = ");
		builder.Append(((object)State).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(AuthenticationResult? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<SpiritSummoner.Domain.Auth.NavigationRoute>.Default.Equals(NavigationRoute, other.NavigationRoute) && EqualityComparer<bool>.Default.Equals(ShowLoadingOverlay, other.ShowLoadingOverlay) && EqualityComparer<string>.Default.Equals(ErrorMessage, other.ErrorMessage) && EqualityComparer<bool>.Default.Equals(Success, other.Success) && EqualityComparer<AuthenticationState>.Default.Equals(State, other.State));
	}

	[CompilerGenerated]
	[SetsRequiredMembers]
	protected AuthenticationResult(AuthenticationResult original)
	{
		NavigationRoute = original.NavigationRoute;
		ShowLoadingOverlay = original.ShowLoadingOverlay;
		ErrorMessage = original.ErrorMessage;
		Success = original.Success;
		State = original.State;
	}

	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public AuthenticationResult()
	{
	}
}
