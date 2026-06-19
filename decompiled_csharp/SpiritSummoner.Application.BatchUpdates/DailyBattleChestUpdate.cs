using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.BatchUpdates;

public record DailyBattleChestUpdate(int BattlesCompleted, DateTimeOffset? LastClaimedAt, DateTimeOffset LastResetAt)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(DailyBattleChestUpdate);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("DailyBattleChestUpdate");
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
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		RuntimeHelpers.EnsureSufficientExecutionStack();
		builder.Append("BattlesCompleted = ");
		builder.Append(((object)BattlesCompleted).ToString());
		builder.Append(", LastClaimedAt = ");
		builder.Append(((object)LastClaimedAt).ToString());
		builder.Append(", LastResetAt = ");
		DateTimeOffset lastResetAt = LastResetAt;
		builder.Append(((object)(DateTimeOffset)(ref lastResetAt)).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(DailyBattleChestUpdate? other)
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<int>.Default.Equals(BattlesCompleted, other.BattlesCompleted) && EqualityComparer<DateTimeOffset?>.Default.Equals(LastClaimedAt, other.LastClaimedAt) && EqualityComparer<DateTimeOffset>.Default.Equals(LastResetAt, other.LastResetAt));
	}
}
