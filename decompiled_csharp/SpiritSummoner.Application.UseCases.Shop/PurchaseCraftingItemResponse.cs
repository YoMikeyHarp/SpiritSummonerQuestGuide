using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Shop;

public record PurchaseCraftingItemResponse(bool Success, string ItemId, string? ItemName, int CrystalsSpent)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(PurchaseCraftingItemResponse);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("PurchaseCraftingItemResponse");
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
		builder.Append("Success = ");
		builder.Append(((object)Success).ToString());
		builder.Append(", ItemId = ");
		builder.Append((object)ItemId);
		builder.Append(", ItemName = ");
		builder.Append((object)ItemName);
		builder.Append(", CrystalsSpent = ");
		builder.Append(((object)CrystalsSpent).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(PurchaseCraftingItemResponse? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<bool>.Default.Equals(Success, other.Success) && EqualityComparer<string>.Default.Equals(ItemId, other.ItemId) && EqualityComparer<string>.Default.Equals(ItemName, other.ItemName) && EqualityComparer<int>.Default.Equals(CrystalsSpent, other.CrystalsSpent));
	}
}
