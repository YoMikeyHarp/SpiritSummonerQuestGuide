using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Quests;

public record ExecuteQuestBattleRequest(string TaskId, string QuestId, string AreaId, bool BattleWon)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(ExecuteQuestBattleRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("ExecuteQuestBattleRequest");
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
		builder.Append("TaskId = ");
		builder.Append((object)TaskId);
		builder.Append(", QuestId = ");
		builder.Append((object)QuestId);
		builder.Append(", AreaId = ");
		builder.Append((object)AreaId);
		builder.Append(", BattleWon = ");
		builder.Append(((object)BattleWon).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(ExecuteQuestBattleRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(TaskId, other.TaskId) && EqualityComparer<string>.Default.Equals(QuestId, other.QuestId) && EqualityComparer<string>.Default.Equals(AreaId, other.AreaId) && EqualityComparer<bool>.Default.Equals(BattleWon, other.BattleWon));
	}
}
