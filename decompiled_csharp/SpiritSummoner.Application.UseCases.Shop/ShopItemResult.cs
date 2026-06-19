using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Domain.Entities.Items;

namespace SpiritSummoner.Application.UseCases.Shop;

public record ShopItemResult(Item Item, bool IsNew)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(ShopItemResult);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("ShopItemResult");
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
		builder.Append("Item = ");
		builder.Append((object)Item);
		builder.Append(", IsNew = ");
		builder.Append(((object)IsNew).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(ShopItemResult? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<SpiritSummoner.Domain.Entities.Items.Item>.Default.Equals(Item, other.Item) && EqualityComparer<bool>.Default.Equals(IsNew, other.IsNew));
	}
}
