using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Guilds;

public record ProcessWarBattleResultRequest(string AttackingGuildId, string DefendingGuildId, string WarId, string AttackingPlayerId, string DefenderPlayerId, int DefenderLevel, bool Victory, int OpponentLevel, int LivingSpiritsCount, double TotalHealthPercentage, int PreCommittedScorePenalty = 0)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(ProcessWarBattleResultRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("ProcessWarBattleResultRequest");
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
		builder.Append("AttackingGuildId = ");
		builder.Append((object)AttackingGuildId);
		builder.Append(", DefendingGuildId = ");
		builder.Append((object)DefendingGuildId);
		builder.Append(", WarId = ");
		builder.Append((object)WarId);
		builder.Append(", AttackingPlayerId = ");
		builder.Append((object)AttackingPlayerId);
		builder.Append(", DefenderPlayerId = ");
		builder.Append((object)DefenderPlayerId);
		builder.Append(", DefenderLevel = ");
		builder.Append(((object)DefenderLevel).ToString());
		builder.Append(", Victory = ");
		builder.Append(((object)Victory).ToString());
		builder.Append(", OpponentLevel = ");
		builder.Append(((object)OpponentLevel).ToString());
		builder.Append(", LivingSpiritsCount = ");
		builder.Append(((object)LivingSpiritsCount).ToString());
		builder.Append(", TotalHealthPercentage = ");
		builder.Append(((object)TotalHealthPercentage).ToString());
		builder.Append(", PreCommittedScorePenalty = ");
		builder.Append(((object)PreCommittedScorePenalty).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(ProcessWarBattleResultRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(AttackingGuildId, other.AttackingGuildId) && EqualityComparer<string>.Default.Equals(DefendingGuildId, other.DefendingGuildId) && EqualityComparer<string>.Default.Equals(WarId, other.WarId) && EqualityComparer<string>.Default.Equals(AttackingPlayerId, other.AttackingPlayerId) && EqualityComparer<string>.Default.Equals(DefenderPlayerId, other.DefenderPlayerId) && EqualityComparer<int>.Default.Equals(DefenderLevel, other.DefenderLevel) && EqualityComparer<bool>.Default.Equals(Victory, other.Victory) && EqualityComparer<int>.Default.Equals(OpponentLevel, other.OpponentLevel) && EqualityComparer<int>.Default.Equals(LivingSpiritsCount, other.LivingSpiritsCount) && EqualityComparer<double>.Default.Equals(TotalHealthPercentage, other.TotalHealthPercentage) && EqualityComparer<int>.Default.Equals(PreCommittedScorePenalty, other.PreCommittedScorePenalty));
	}
}
