using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Shop;

public record PurchaseSpiritResponse(bool Success, string PlayerSpiritId, string SpiritName, string SpiritImage, int Level, string CurrencyType, long CurrencySpent)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(PurchaseSpiritResponse);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("PurchaseSpiritResponse");
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
		builder.Append(", PlayerSpiritId = ");
		builder.Append((object)PlayerSpiritId);
		builder.Append(", SpiritName = ");
		builder.Append((object)SpiritName);
		builder.Append(", SpiritImage = ");
		builder.Append((object)SpiritImage);
		builder.Append(", Level = ");
		builder.Append(((object)Level).ToString());
		builder.Append(", CurrencyType = ");
		builder.Append((object)CurrencyType);
		builder.Append(", CurrencySpent = ");
		builder.Append(((object)CurrencySpent).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(PurchaseSpiritResponse? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<bool>.Default.Equals(Success, other.Success) && EqualityComparer<string>.Default.Equals(PlayerSpiritId, other.PlayerSpiritId) && EqualityComparer<string>.Default.Equals(SpiritName, other.SpiritName) && EqualityComparer<string>.Default.Equals(SpiritImage, other.SpiritImage) && EqualityComparer<int>.Default.Equals(Level, other.Level) && EqualityComparer<string>.Default.Equals(CurrencyType, other.CurrencyType) && EqualityComparer<long>.Default.Equals(CurrencySpent, other.CurrencySpent));
	}
}
