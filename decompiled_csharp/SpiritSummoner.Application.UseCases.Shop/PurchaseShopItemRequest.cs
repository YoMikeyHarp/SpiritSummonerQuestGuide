using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Domain.Enums.Items;

namespace SpiritSummoner.Application.UseCases.Shop;

public record PurchaseShopItemRequest(string ItemId, ItemType ItemType, int Quantity = 1, bool MarkAsViewed = true)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(PurchaseShopItemRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("PurchaseShopItemRequest");
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
		builder.Append("ItemId = ");
		builder.Append((object)ItemId);
		builder.Append(", ItemType = ");
		builder.Append(((object)ItemType).ToString());
		builder.Append(", Quantity = ");
		builder.Append(((object)Quantity).ToString());
		builder.Append(", MarkAsViewed = ");
		builder.Append(((object)MarkAsViewed).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(PurchaseShopItemRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(ItemId, other.ItemId) && EqualityComparer<ItemType>.Default.Equals(ItemType, other.ItemType) && EqualityComparer<int>.Default.Equals(Quantity, other.Quantity) && EqualityComparer<bool>.Default.Equals(MarkAsViewed, other.MarkAsViewed));
	}
}
