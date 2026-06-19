using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Domain.Entities.Spirits;

namespace SpiritSummoner.Application.UseCases.Battles;

public record ExecuteBattleTurnRequest(BattleState BattleState, Move? PlayerMove = null)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(ExecuteBattleTurnRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("ExecuteBattleTurnRequest");
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
		builder.Append(", PlayerMove = ");
		builder.Append((object)PlayerMove);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(ExecuteBattleTurnRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<SpiritSummoner.Application.UseCases.Battles.BattleState>.Default.Equals(BattleState, other.BattleState) && EqualityComparer<Move>.Default.Equals(PlayerMove, other.PlayerMove));
	}
}
