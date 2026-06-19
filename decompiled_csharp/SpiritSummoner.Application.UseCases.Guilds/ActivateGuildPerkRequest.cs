using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Domain.Enums.Guilds;

namespace SpiritSummoner.Application.UseCases.Guilds;

public record ActivateGuildPerkRequest(GuildPerkType PerkType)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(ActivateGuildPerkRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("ActivateGuildPerkRequest");
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
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(ActivateGuildPerkRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<GuildPerkType>.Default.Equals(PerkType, other.PerkType));
	}
}
