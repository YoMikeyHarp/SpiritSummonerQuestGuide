using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Domain.Enums.Items;

namespace SpiritSummoner.Application.UseCases.Shop;

public record GetShopItemsRequest(List<ItemType> ItemTypes, string? CurrencyType = null)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(GetShopItemsRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("GetShopItemsRequest");
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
		builder.Append("ItemTypes = ");
		builder.Append((object)ItemTypes);
		builder.Append(", CurrencyType = ");
		builder.Append((object)CurrencyType);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(GetShopItemsRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<List<ItemType>>.Default.Equals(ItemTypes, other.ItemTypes) && EqualityComparer<string>.Default.Equals(CurrencyType, other.CurrencyType));
	}
}
