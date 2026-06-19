using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Presentation.Models;

public record InventoryItemReadModel(string Name, int Amount)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(InventoryItemReadModel);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("InventoryItemReadModel");
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
		builder.Append("Name = ");
		builder.Append((object)Name);
		builder.Append(", Amount = ");
		builder.Append(((object)Amount).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(InventoryItemReadModel? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(Name, other.Name) && EqualityComparer<int>.Default.Equals(Amount, other.Amount));
	}
}
