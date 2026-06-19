using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Domain.Enums.Shops;

namespace SpiritSummoner.Presentation.ViewModels.Shop;

public record ShopAreas(string Name, string Image, ShopType ShopType)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(ShopAreas);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("ShopAreas");
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
		builder.Append(", Image = ");
		builder.Append((object)Image);
		builder.Append(", ShopType = ");
		builder.Append(((object)ShopType).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(ShopAreas? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(Name, other.Name) && EqualityComparer<string>.Default.Equals(Image, other.Image) && EqualityComparer<ShopType>.Default.Equals(ShopType, other.ShopType));
	}
}
