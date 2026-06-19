using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Battles;

public record BattleTaskReward(long GoldReward, int EnergyReward, long GuildCoinsReward)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(BattleTaskReward);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("BattleTaskReward");
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
		builder.Append("GoldReward = ");
		builder.Append(((object)GoldReward).ToString());
		builder.Append(", EnergyReward = ");
		builder.Append(((object)EnergyReward).ToString());
		builder.Append(", GuildCoinsReward = ");
		builder.Append(((object)GuildCoinsReward).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(BattleTaskReward? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<long>.Default.Equals(GoldReward, other.GoldReward) && EqualityComparer<int>.Default.Equals(EnergyReward, other.EnergyReward) && EqualityComparer<long>.Default.Equals(GuildCoinsReward, other.GuildCoinsReward));
	}
}
