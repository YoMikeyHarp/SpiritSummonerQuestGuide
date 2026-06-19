using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Application.DTOs;

namespace SpiritSummoner.Application.UseCases.Shop;

public record GetSpiritPreviewResponse(SpiritPreviewDTO SpiritPreview, string CurrencyType = "gold", int CurrencyAmount = 0, string OrbName = "", int OrbAmount = 0)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(GetSpiritPreviewResponse);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("GetSpiritPreviewResponse");
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
		builder.Append("SpiritPreview = ");
		builder.Append((object)SpiritPreview);
		builder.Append(", CurrencyType = ");
		builder.Append((object)CurrencyType);
		builder.Append(", CurrencyAmount = ");
		builder.Append(((object)CurrencyAmount).ToString());
		builder.Append(", OrbName = ");
		builder.Append((object)OrbName);
		builder.Append(", OrbAmount = ");
		builder.Append(((object)OrbAmount).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(GetSpiritPreviewResponse? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<SpiritPreviewDTO>.Default.Equals(SpiritPreview, other.SpiritPreview) && EqualityComparer<string>.Default.Equals(CurrencyType, other.CurrencyType) && EqualityComparer<int>.Default.Equals(CurrencyAmount, other.CurrencyAmount) && EqualityComparer<string>.Default.Equals(OrbName, other.OrbName) && EqualityComparer<int>.Default.Equals(OrbAmount, other.OrbAmount));
	}
}
