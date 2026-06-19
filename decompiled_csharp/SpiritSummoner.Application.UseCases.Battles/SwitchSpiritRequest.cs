using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Battles;

public record SwitchSpiritRequest(BattleState BattleState, int NewSpiritIndex)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(SwitchSpiritRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("SwitchSpiritRequest");
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
		builder.Append("BattleState = ");
		builder.Append((object)BattleState);
		builder.Append(", NewSpiritIndex = ");
		builder.Append(((object)NewSpiritIndex).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(SwitchSpiritRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<SpiritSummoner.Application.UseCases.Battles.BattleState>.Default.Equals(BattleState, other.BattleState) && EqualityComparer<int>.Default.Equals(NewSpiritIndex, other.NewSpiritIndex));
	}
}
