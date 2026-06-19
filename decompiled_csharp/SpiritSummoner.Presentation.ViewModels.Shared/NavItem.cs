using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace SpiritSummoner.Presentation.ViewModels.Shared;

public record NavItem(string DisplayName, string Icon, string Route, ICommand Command)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(NavItem);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("NavItem");
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
		builder.Append("DisplayName = ");
		builder.Append((object)DisplayName);
		builder.Append(", Icon = ");
		builder.Append((object)Icon);
		builder.Append(", Route = ");
		builder.Append((object)Route);
		builder.Append(", Command = ");
		builder.Append((object)Command);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(NavItem? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(DisplayName, other.DisplayName) && EqualityComparer<string>.Default.Equals(Icon, other.Icon) && EqualityComparer<string>.Default.Equals(Route, other.Route) && EqualityComparer<ICommand>.Default.Equals(Command, other.Command));
	}
}
