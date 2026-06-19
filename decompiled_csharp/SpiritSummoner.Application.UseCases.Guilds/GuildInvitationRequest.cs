using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Guilds;

public record GuildInvitationRequest(string GuildId, string ActioningPlayerId, InvitationAction Action, string? TargetPlayerId = null, string? JoinRequestId = null)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(GuildInvitationRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("GuildInvitationRequest");
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
		builder.Append(", ActioningPlayerId = ");
		builder.Append((object)ActioningPlayerId);
		builder.Append(", Action = ");
		builder.Append(((object)Action).ToString());
		builder.Append(", TargetPlayerId = ");
		builder.Append((object)TargetPlayerId);
		builder.Append(", JoinRequestId = ");
		builder.Append((object)JoinRequestId);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(GuildInvitationRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(GuildId, other.GuildId) && EqualityComparer<string>.Default.Equals(ActioningPlayerId, other.ActioningPlayerId) && EqualityComparer<InvitationAction>.Default.Equals(Action, other.Action) && EqualityComparer<string>.Default.Equals(TargetPlayerId, other.TargetPlayerId) && EqualityComparer<string>.Default.Equals(JoinRequestId, other.JoinRequestId));
	}
}
