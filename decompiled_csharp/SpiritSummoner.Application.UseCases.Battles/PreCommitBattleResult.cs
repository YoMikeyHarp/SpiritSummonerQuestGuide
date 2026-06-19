using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Battles;

public record PreCommitBattleResult(string BattleId, int PreCommittedScorePenalty)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(PreCommitBattleResult);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("PreCommitBattleResult");
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
		builder.Append("BattleId = ");
		builder.Append((object)BattleId);
		builder.Append(", PreCommittedScorePenalty = ");
		builder.Append(((object)PreCommittedScorePenalty).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(PreCommitBattleResult? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(BattleId, other.BattleId) && EqualityComparer<int>.Default.Equals(PreCommittedScorePenalty, other.PreCommittedScorePenalty));
	}
}
