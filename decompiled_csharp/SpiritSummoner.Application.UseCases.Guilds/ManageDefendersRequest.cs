using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Guilds;

public record ManageDefendersRequest(string GuildId, string TargetPlayerId, DefenderAction Action)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(ManageDefendersRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("ManageDefendersRequest");
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
		builder.Append("GuildId = ");
		builder.Append((object)GuildId);
		builder.Append(", TargetPlayerId = ");
		builder.Append((object)TargetPlayerId);
		builder.Append(", Action = ");
		builder.Append(((object)Action).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(ManageDefendersRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(GuildId, other.GuildId) && EqualityComparer<string>.Default.Equals(TargetPlayerId, other.TargetPlayerId) && EqualityComparer<DefenderAction>.Default.Equals(Action, other.Action));
	}
}
