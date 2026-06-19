using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Spirits;

public record EquipItemRequest(string SpiritId, string BaseSpiritId, string ItemId, EquipmentType ItemType)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(EquipItemRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("EquipItemRequest");
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
		builder.Append(", BaseSpiritId = ");
		builder.Append((object)BaseSpiritId);
		builder.Append(", ItemId = ");
		builder.Append((object)ItemId);
		builder.Append(", ItemType = ");
		builder.Append(((object)ItemType).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(EquipItemRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(SpiritId, other.SpiritId) && EqualityComparer<string>.Default.Equals(BaseSpiritId, other.BaseSpiritId) && EqualityComparer<string>.Default.Equals(ItemId, other.ItemId) && EqualityComparer<EquipmentType>.Default.Equals(ItemType, other.ItemType));
	}
}
