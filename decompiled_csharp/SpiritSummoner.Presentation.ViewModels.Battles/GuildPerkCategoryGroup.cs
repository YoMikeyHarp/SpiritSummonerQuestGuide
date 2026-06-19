using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Domain.Enums.Guilds;

namespace SpiritSummoner.Presentation.ViewModels.Battles;

public record GuildPerkCategoryGroup(GuildPerkCategory Category, string Label, global::System.Collections.Generic.IReadOnlyList<GuildPerkItemViewModel> Perks)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(GuildPerkCategoryGroup);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("GuildPerkCategoryGroup");
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
		builder.Append("Category = ");
		builder.Append(((object)Category).ToString());
		builder.Append(", Label = ");
		builder.Append((object)Label);
		builder.Append(", Perks = ");
		builder.Append((object)Perks);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(GuildPerkCategoryGroup? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<GuildPerkCategory>.Default.Equals(Category, other.Category) && EqualityComparer<string>.Default.Equals(Label, other.Label) && EqualityComparer<global::System.Collections.Generic.IReadOnlyList<GuildPerkItemViewModel>>.Default.Equals(Perks, other.Perks));
	}
}
