using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Domain.Configuration.Guilds;

public record GuildPerkTierDefinition(int CrystalCost, double EffectValue, string EffectDescription)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(GuildPerkTierDefinition);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("GuildPerkTierDefinition");
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
		builder.Append("CrystalCost = ");
		builder.Append(((object)CrystalCost).ToString());
		builder.Append(", EffectValue = ");
		builder.Append(((object)EffectValue).ToString());
		builder.Append(", EffectDescription = ");
		builder.Append((object)EffectDescription);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(GuildPerkTierDefinition? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<int>.Default.Equals(CrystalCost, other.CrystalCost) && EqualityComparer<double>.Default.Equals(EffectValue, other.EffectValue) && EqualityComparer<string>.Default.Equals(EffectDescription, other.EffectDescription));
	}
}
