using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Domain.Enums.Items;

namespace SpiritSummoner.Application.UseCases.Items;

public record GetEquippableItemsRequest(string PlayerSpiritId, string BaseSpiritId, List<ItemType> ItemTypes)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(GetEquippableItemsRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("GetEquippableItemsRequest");
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
		builder.Append("PlayerSpiritId = ");
		builder.Append((object)PlayerSpiritId);
		builder.Append(", BaseSpiritId = ");
		builder.Append((object)BaseSpiritId);
		builder.Append(", ItemTypes = ");
		builder.Append((object)ItemTypes);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(GetEquippableItemsRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(PlayerSpiritId, other.PlayerSpiritId) && EqualityComparer<string>.Default.Equals(BaseSpiritId, other.BaseSpiritId) && EqualityComparer<List<ItemType>>.Default.Equals(ItemTypes, other.ItemTypes));
	}
}
