using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Spirits;

public record UnequipItemResponse(string SpiritId, EquipmentType ItemType, string? UnequippedItemId)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(UnequipItemResponse);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("UnequipItemResponse");
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
		builder.Append("SpiritId = ");
		builder.Append((object)SpiritId);
		builder.Append(", ItemType = ");
		builder.Append(((object)ItemType).ToString());
		builder.Append(", UnequippedItemId = ");
		builder.Append((object)UnequippedItemId);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(UnequipItemResponse? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(SpiritId, other.SpiritId) && EqualityComparer<EquipmentType>.Default.Equals(ItemType, other.ItemType) && EqualityComparer<string>.Default.Equals(UnequippedItemId, other.UnequippedItemId));
	}
}
