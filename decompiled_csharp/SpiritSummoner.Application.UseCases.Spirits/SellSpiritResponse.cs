using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Spirits;

public record SellSpiritResponse(string SpiritId, int SpiritLevel, long GoldReceived, long NewGoldBalance, string? OrbDropped = null, int OrbQuantity = 0)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(SellSpiritResponse);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("SellSpiritResponse");
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
		builder.Append(", SpiritLevel = ");
		builder.Append(((object)SpiritLevel).ToString());
		builder.Append(", GoldReceived = ");
		builder.Append(((object)GoldReceived).ToString());
		builder.Append(", NewGoldBalance = ");
		builder.Append(((object)NewGoldBalance).ToString());
		builder.Append(", OrbDropped = ");
		builder.Append((object)OrbDropped);
		builder.Append(", OrbQuantity = ");
		builder.Append(((object)OrbQuantity).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(SellSpiritResponse? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(SpiritId, other.SpiritId) && EqualityComparer<int>.Default.Equals(SpiritLevel, other.SpiritLevel) && EqualityComparer<long>.Default.Equals(GoldReceived, other.GoldReceived) && EqualityComparer<long>.Default.Equals(NewGoldBalance, other.NewGoldBalance) && EqualityComparer<string>.Default.Equals(OrbDropped, other.OrbDropped) && EqualityComparer<int>.Default.Equals(OrbQuantity, other.OrbQuantity));
	}
}
