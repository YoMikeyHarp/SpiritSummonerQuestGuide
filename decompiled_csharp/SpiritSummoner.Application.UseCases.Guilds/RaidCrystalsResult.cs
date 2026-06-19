using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Guilds;

public record RaidCrystalsResult(int CrystalsGained, int RaidsRemainingThisHour, int EffectiveMaxRaids)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(RaidCrystalsResult);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("RaidCrystalsResult");
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
		builder.Append("CrystalsGained = ");
		builder.Append(((object)CrystalsGained).ToString());
		builder.Append(", RaidsRemainingThisHour = ");
		builder.Append(((object)RaidsRemainingThisHour).ToString());
		builder.Append(", EffectiveMaxRaids = ");
		builder.Append(((object)EffectiveMaxRaids).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(RaidCrystalsResult? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<int>.Default.Equals(CrystalsGained, other.CrystalsGained) && EqualityComparer<int>.Default.Equals(RaidsRemainingThisHour, other.RaidsRemainingThisHour) && EqualityComparer<int>.Default.Equals(EffectiveMaxRaids, other.EffectiveMaxRaids));
	}
}
