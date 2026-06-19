using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Domain.Entities.Guilds;

public record DefenderData(List<string> SquadIds, DateTimeOffset SignUpAt, DateTimeOffset ExpiresAt, bool IsMainDefender, DateTimeOffset? DowntimeEnds = null)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(DefenderData);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("DefenderData");
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
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		RuntimeHelpers.EnsureSufficientExecutionStack();
		builder.Append("SquadIds = ");
		builder.Append((object)SquadIds);
		builder.Append(", SignUpAt = ");
		DateTimeOffset val = SignUpAt;
		builder.Append(((object)(DateTimeOffset)(ref val)).ToString());
		builder.Append(", ExpiresAt = ");
		val = ExpiresAt;
		builder.Append(((object)(DateTimeOffset)(ref val)).ToString());
		builder.Append(", IsMainDefender = ");
		builder.Append(((object)IsMainDefender).ToString());
		builder.Append(", DowntimeEnds = ");
		builder.Append(((object)DowntimeEnds).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(DefenderData? other)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<List<string>>.Default.Equals(SquadIds, other.SquadIds) && EqualityComparer<DateTimeOffset>.Default.Equals(SignUpAt, other.SignUpAt) && EqualityComparer<DateTimeOffset>.Default.Equals(ExpiresAt, other.ExpiresAt) && EqualityComparer<bool>.Default.Equals(IsMainDefender, other.IsMainDefender) && EqualityComparer<DateTimeOffset?>.Default.Equals(DowntimeEnds, other.DowntimeEnds));
	}
}
