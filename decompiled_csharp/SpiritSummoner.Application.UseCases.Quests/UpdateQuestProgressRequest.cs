using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Quests;

public record UpdateQuestProgressRequest(QuestProgress QuestProgress, string TaskId, int NewStep, bool IsLastTask = false)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(UpdateQuestProgressRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("UpdateQuestProgressRequest");
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
		builder.Append("QuestProgress = ");
		builder.Append((object)QuestProgress);
		builder.Append(", TaskId = ");
		builder.Append((object)TaskId);
		builder.Append(", NewStep = ");
		builder.Append(((object)NewStep).ToString());
		builder.Append(", IsLastTask = ");
		builder.Append(((object)IsLastTask).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(UpdateQuestProgressRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<SpiritSummoner.Application.UseCases.Quests.QuestProgress>.Default.Equals(QuestProgress, other.QuestProgress) && EqualityComparer<string>.Default.Equals(TaskId, other.TaskId) && EqualityComparer<int>.Default.Equals(NewStep, other.NewStep) && EqualityComparer<bool>.Default.Equals(IsLastTask, other.IsLastTask));
	}
}
