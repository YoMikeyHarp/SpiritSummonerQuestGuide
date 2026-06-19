using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.DailyGifts;

public record RedeemDailyGiftResponse(string RewardType, long Amount, string? ItemKey, string? SpiritName)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(RedeemDailyGiftResponse);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("RedeemDailyGiftResponse");
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
		builder.Append("RewardType = ");
		builder.Append((object)RewardType);
		builder.Append(", Amount = ");
		builder.Append(((object)Amount).ToString());
		builder.Append(", ItemKey = ");
		builder.Append((object)ItemKey);
		builder.Append(", SpiritName = ");
		builder.Append((object)SpiritName);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(RedeemDailyGiftResponse? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(RewardType, other.RewardType) && EqualityComparer<long>.Default.Equals(Amount, other.Amount) && EqualityComparer<string>.Default.Equals(ItemKey, other.ItemKey) && EqualityComparer<string>.Default.Equals(SpiritName, other.SpiritName));
	}
}
