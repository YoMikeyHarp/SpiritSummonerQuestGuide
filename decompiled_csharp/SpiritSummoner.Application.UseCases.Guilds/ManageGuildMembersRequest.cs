using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Guilds;

public record ManageGuildMembersRequest(string GuildId, string TargetPlayerId, GuildMemberAction Action)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(ManageGuildMembersRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("ManageGuildMembersRequest");
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
	public virtual bool Equals(ManageGuildMembersRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(GuildId, other.GuildId) && EqualityComparer<string>.Default.Equals(TargetPlayerId, other.TargetPlayerId) && EqualityComparer<GuildMemberAction>.Default.Equals(Action, other.Action));
	}
}
