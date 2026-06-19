using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Application.UseCases.Battles;

public record RecordBattleStatisticsRequest(Player Player, bool Victory)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(RecordBattleStatisticsRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("RecordBattleStatisticsRequest");
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
		builder.Append("Player = ");
		builder.Append((object)Player);
		builder.Append(", Victory = ");
		builder.Append(((object)Victory).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(RecordBattleStatisticsRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<SpiritSummoner.Domain.Entities.Players.Player>.Default.Equals(Player, other.Player) && EqualityComparer<bool>.Default.Equals(Victory, other.Victory));
	}
}
