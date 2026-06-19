using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Domain.Enums.Guilds;

namespace SpiritSummoner.Application.UseCases.Guilds;

public record ActivateGuildPerkResponse(GuildPerkType PerkType, int NewTier, string EffectDescription)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(ActivateGuildPerkResponse);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("ActivateGuildPerkResponse");
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
		builder.Append("PerkType = ");
		builder.Append(((object)PerkType).ToString());
		builder.Append(", NewTier = ");
		builder.Append(((object)NewTier).ToString());
		builder.Append(", EffectDescription = ");
		builder.Append((object)EffectDescription);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(ActivateGuildPerkResponse? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<GuildPerkType>.Default.Equals(PerkType, other.PerkType) && EqualityComparer<int>.Default.Equals(NewTier, other.NewTier) && EqualityComparer<string>.Default.Equals(EffectDescription, other.EffectDescription));
	}
}
