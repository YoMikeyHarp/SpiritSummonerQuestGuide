using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Application.UseCases.Battles;

namespace SpiritSummoner.Application.UseCases.Guilds;

public record ProcessWarBattleResultData(int CrystalsAwarded, bool WasCapped, BattleRewards? PersonalRewards)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(ProcessWarBattleResultData);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("ProcessWarBattleResultData");
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
		builder.Append("CrystalsAwarded = ");
		builder.Append(((object)CrystalsAwarded).ToString());
		builder.Append(", WasCapped = ");
		builder.Append(((object)WasCapped).ToString());
		builder.Append(", PersonalRewards = ");
		builder.Append((object)PersonalRewards);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(ProcessWarBattleResultData? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<int>.Default.Equals(CrystalsAwarded, other.CrystalsAwarded) && EqualityComparer<bool>.Default.Equals(WasCapped, other.WasCapped) && EqualityComparer<BattleRewards>.Default.Equals(PersonalRewards, other.PersonalRewards));
	}
}
