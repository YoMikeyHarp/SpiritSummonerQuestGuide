using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.BatchUpdates;

public record GuildActivePerkUpdate(int Tier, DateTimeOffset ActivatedAt, string ActivatedByPlayerId)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(GuildActivePerkUpdate);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("GuildActivePerkUpdate");
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
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		RuntimeHelpers.EnsureSufficientExecutionStack();
		builder.Append("Tier = ");
		builder.Append(((object)Tier).ToString());
		builder.Append(", ActivatedAt = ");
		DateTimeOffset activatedAt = ActivatedAt;
		builder.Append(((object)(DateTimeOffset)(ref activatedAt)).ToString());
		builder.Append(", ActivatedByPlayerId = ");
		builder.Append((object)ActivatedByPlayerId);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(GuildActivePerkUpdate? other)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<int>.Default.Equals(Tier, other.Tier) && EqualityComparer<DateTimeOffset>.Default.Equals(ActivatedAt, other.ActivatedAt) && EqualityComparer<string>.Default.Equals(ActivatedByPlayerId, other.ActivatedByPlayerId));
	}
}
