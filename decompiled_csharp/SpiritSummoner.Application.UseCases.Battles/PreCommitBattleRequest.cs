using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Battles;

public record PreCommitBattleRequest(int OpponentLevel, bool IsPvP)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(PreCommitBattleRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("PreCommitBattleRequest");
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
		builder.Append("OpponentLevel = ");
		builder.Append(((object)OpponentLevel).ToString());
		builder.Append(", IsPvP = ");
		builder.Append(((object)IsPvP).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(PreCommitBattleRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<int>.Default.Equals(OpponentLevel, other.OpponentLevel) && EqualityComparer<bool>.Default.Equals(IsPvP, other.IsPvP));
	}
}
