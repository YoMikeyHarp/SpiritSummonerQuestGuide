using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Application.UseCases.Items;

public record GetPlayerInventoryResponse(global::System.Collections.Generic.IReadOnlyList<Inventory> PlayerInventory, global::System.Collections.Generic.IReadOnlyList<Item> ItemTemplates)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(GetPlayerInventoryResponse);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("GetPlayerInventoryResponse");
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
		builder.Append("PlayerInventory = ");
		builder.Append((object)PlayerInventory);
		builder.Append(", ItemTemplates = ");
		builder.Append((object)ItemTemplates);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(GetPlayerInventoryResponse? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<global::System.Collections.Generic.IReadOnlyList<Inventory>>.Default.Equals(PlayerInventory, other.PlayerInventory) && EqualityComparer<global::System.Collections.Generic.IReadOnlyList<Item>>.Default.Equals(ItemTemplates, other.ItemTemplates));
	}
}
