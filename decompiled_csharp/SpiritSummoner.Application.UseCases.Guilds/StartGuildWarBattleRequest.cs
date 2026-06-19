using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Guilds;

public record StartGuildWarBattleRequest(string AttackingGuildId, string AttackingPlayerId, string DefendingGuildId)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(StartGuildWarBattleRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("StartGuildWarBattleRequest");
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
		builder.Append(", AttackingPlayerId = ");
		builder.Append((object)AttackingPlayerId);
		builder.Append(", DefendingGuildId = ");
		builder.Append((object)DefendingGuildId);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(StartGuildWarBattleRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(AttackingGuildId, other.AttackingGuildId) && EqualityComparer<string>.Default.Equals(AttackingPlayerId, other.AttackingPlayerId) && EqualityComparer<string>.Default.Equals(DefendingGuildId, other.DefendingGuildId));
	}
}
