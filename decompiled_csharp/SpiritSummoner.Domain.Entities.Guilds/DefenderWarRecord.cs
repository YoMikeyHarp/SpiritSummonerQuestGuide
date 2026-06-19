using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Domain.Entities.Guilds;

public record DefenderWarRecord(int DefeatCount, DateTimeOffset DowntimeEnds, DateTimeOffset? LastFellAt = null, int CrystalsGained = 0)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(DefenderWarRecord);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("DefenderWarRecord");
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
		builder.Append("DefeatCount = ");
		builder.Append(((object)DefeatCount).ToString());
		builder.Append(", DowntimeEnds = ");
		DateTimeOffset downtimeEnds = DowntimeEnds;
		builder.Append(((object)(DateTimeOffset)(ref downtimeEnds)).ToString());
		builder.Append(", LastFellAt = ");
		builder.Append(((object)LastFellAt).ToString());
		builder.Append(", CrystalsGained = ");
		builder.Append(((object)CrystalsGained).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(DefenderWarRecord? other)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<int>.Default.Equals(DefeatCount, other.DefeatCount) && EqualityComparer<DateTimeOffset>.Default.Equals(DowntimeEnds, other.DowntimeEnds) && EqualityComparer<DateTimeOffset?>.Default.Equals(LastFellAt, other.LastFellAt) && EqualityComparer<int>.Default.Equals(CrystalsGained, other.CrystalsGained));
	}
}
