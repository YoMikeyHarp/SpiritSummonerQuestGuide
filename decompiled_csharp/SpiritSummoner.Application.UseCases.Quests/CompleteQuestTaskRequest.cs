using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Quests;

namespace SpiritSummoner.Application.UseCases.Quests;

public record CompleteQuestTaskRequest(Player Player, QuestTask Task)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(CompleteQuestTaskRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("CompleteQuestTaskRequest");
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
		builder.Append(", Task = ");
		builder.Append((object)Task);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(CompleteQuestTaskRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<SpiritSummoner.Domain.Entities.Players.Player>.Default.Equals(Player, other.Player) && EqualityComparer<QuestTask>.Default.Equals(Task, other.Task));
	}
}
