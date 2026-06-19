using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Guilds;

public record RaidCrystalsRequest(string AttackingGuildId, string DefendingGuildId, string WarId, string AttackingPlayerId)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(RaidCrystalsRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("RaidCrystalsRequest");
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
		builder.Append("AttackingGuildId = ");
		builder.Append((object)AttackingGuildId);
		builder.Append(", DefendingGuildId = ");
		builder.Append((object)DefendingGuildId);
		builder.Append(", WarId = ");
		builder.Append((object)WarId);
		builder.Append(", AttackingPlayerId = ");
		builder.Append((object)AttackingPlayerId);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(RaidCrystalsRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(AttackingGuildId, other.AttackingGuildId) && EqualityComparer<string>.Default.Equals(DefendingGuildId, other.DefendingGuildId) && EqualityComparer<string>.Default.Equals(WarId, other.WarId) && EqualityComparer<string>.Default.Equals(AttackingPlayerId, other.AttackingPlayerId));
	}
}
