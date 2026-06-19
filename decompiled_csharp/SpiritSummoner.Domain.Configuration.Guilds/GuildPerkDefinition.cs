using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Domain.Enums.Guilds;

namespace SpiritSummoner.Domain.Configuration.Guilds;

public record GuildPerkDefinition(GuildPerkType Type, GuildPerkCategory Category, string Title, string Description, global::System.Collections.Generic.IReadOnlyList<GuildPerkTierDefinition> Tiers)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(GuildPerkDefinition);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("GuildPerkDefinition");
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
		builder.Append("Type = ");
		builder.Append(((object)Type).ToString());
		builder.Append(", Category = ");
		builder.Append(((object)Category).ToString());
		builder.Append(", Title = ");
		builder.Append((object)Title);
		builder.Append(", Description = ");
		builder.Append((object)Description);
		builder.Append(", Tiers = ");
		builder.Append((object)Tiers);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(GuildPerkDefinition? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<GuildPerkType>.Default.Equals(Type, other.Type) && EqualityComparer<GuildPerkCategory>.Default.Equals(Category, other.Category) && EqualityComparer<string>.Default.Equals(Title, other.Title) && EqualityComparer<string>.Default.Equals(Description, other.Description) && EqualityComparer<global::System.Collections.Generic.IReadOnlyList<GuildPerkTierDefinition>>.Default.Equals(Tiers, other.Tiers));
	}
}
