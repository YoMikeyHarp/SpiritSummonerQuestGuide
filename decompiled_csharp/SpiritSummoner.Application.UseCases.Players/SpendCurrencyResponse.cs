using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Players;

public record SpendCurrencyResponse(string CurrencyType, long AmountSpent, long NewBalance)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(SpendCurrencyResponse);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("SpendCurrencyResponse");
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
		builder.Append("CurrencyType = ");
		builder.Append((object)CurrencyType);
		builder.Append(", AmountSpent = ");
		builder.Append(((object)AmountSpent).ToString());
		builder.Append(", NewBalance = ");
		builder.Append(((object)NewBalance).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(SpendCurrencyResponse? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(CurrencyType, other.CurrencyType) && EqualityComparer<long>.Default.Equals(AmountSpent, other.AmountSpent) && EqualityComparer<long>.Default.Equals(NewBalance, other.NewBalance));
	}
}
