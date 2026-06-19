using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Battles;

public record CompleteBattleRequest(int EnemyLevel, bool Victory, bool IsPvP = false, int LivingSpiritsCount = 0, double TotalHealthPercentage = 0.0, int PreCommittedScorePenalty = 0, string? QuestTaskId = null, bool QuestTaskCompleted = false, int QuestTaskStep = 0, string? OpponentPlayerId = null)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(CompleteBattleRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("CompleteBattleRequest");
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
		builder.Append("EnemyLevel = ");
		builder.Append(((object)EnemyLevel).ToString());
		builder.Append(", Victory = ");
		builder.Append(((object)Victory).ToString());
		builder.Append(", IsPvP = ");
		builder.Append(((object)IsPvP).ToString());
		builder.Append(", LivingSpiritsCount = ");
		builder.Append(((object)LivingSpiritsCount).ToString());
		builder.Append(", TotalHealthPercentage = ");
		builder.Append(((object)TotalHealthPercentage).ToString());
		builder.Append(", PreCommittedScorePenalty = ");
		builder.Append(((object)PreCommittedScorePenalty).ToString());
		builder.Append(", QuestTaskId = ");
		builder.Append((object)QuestTaskId);
		builder.Append(", QuestTaskCompleted = ");
		builder.Append(((object)QuestTaskCompleted).ToString());
		builder.Append(", QuestTaskStep = ");
		builder.Append(((object)QuestTaskStep).ToString());
		builder.Append(", OpponentPlayerId = ");
		builder.Append((object)OpponentPlayerId);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(CompleteBattleRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<int>.Default.Equals(EnemyLevel, other.EnemyLevel) && EqualityComparer<bool>.Default.Equals(Victory, other.Victory) && EqualityComparer<bool>.Default.Equals(IsPvP, other.IsPvP) && EqualityComparer<int>.Default.Equals(LivingSpiritsCount, other.LivingSpiritsCount) && EqualityComparer<double>.Default.Equals(TotalHealthPercentage, other.TotalHealthPercentage) && EqualityComparer<int>.Default.Equals(PreCommittedScorePenalty, other.PreCommittedScorePenalty) && EqualityComparer<string>.Default.Equals(QuestTaskId, other.QuestTaskId) && EqualityComparer<bool>.Default.Equals(QuestTaskCompleted, other.QuestTaskCompleted) && EqualityComparer<int>.Default.Equals(QuestTaskStep, other.QuestTaskStep) && EqualityComparer<string>.Default.Equals(OpponentPlayerId, other.OpponentPlayerId));
	}
}
