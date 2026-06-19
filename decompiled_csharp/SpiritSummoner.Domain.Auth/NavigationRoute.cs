using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Domain.Auth;

[RequiredMember]
public record NavigationRoute
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(NavigationRoute);
		}
	}

	[RequiredMember]
	public string Route
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

	public static NavigationRoute Welcome => new NavigationRoute
	{
		Route = "//welcome",
		ShowLoadingOverlay = false
	};

	public static NavigationRoute Login => new NavigationRoute
	{
		Route = "//login",
		ShowLoadingOverlay = false
	};

	public static NavigationRoute Loading => new NavigationRoute
	{
		Route = "//loading",
		ShowLoadingOverlay = true
	};

	public static NavigationRoute Main => new NavigationRoute
	{
		Route = "//main",
		ShowLoadingOverlay = false
	};

	public static NavigationRoute OnboardingDialogue => new NavigationRoute
	{
		Route = "//onboarding/dialogue",
		ShowLoadingOverlay = false
	};

	public static NavigationRoute OnboardingSpirits => new NavigationRoute
	{
		Route = "//onboarding/spirits",
		ShowLoadingOverlay = false
	};

	public static NavigationRoute Stay => new NavigationRoute
	{
		Route = string.Empty,
		ShowLoadingOverlay = false
	};

	public static NavigationRoute Custom(string route, bool showOverlay = false)
	{
		return new NavigationRoute
		{
			Route = route,
			ShowLoadingOverlay = showOverlay
		};
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("NavigationRoute");
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
		builder.Append(", ShowLoadingOverlay = ");
		builder.Append(((object)ShowLoadingOverlay).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(NavigationRoute? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(Route, other.Route) && EqualityComparer<bool>.Default.Equals(ShowLoadingOverlay, other.ShowLoadingOverlay));
	}

	[CompilerGenerated]
	[SetsRequiredMembers]
	protected NavigationRoute(NavigationRoute original)
	{
		Route = original.Route;
		ShowLoadingOverlay = original.ShowLoadingOverlay;
	}

	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public NavigationRoute()
	{
	}
}
