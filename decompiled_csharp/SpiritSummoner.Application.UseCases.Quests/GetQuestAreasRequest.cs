using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Quests;

public record GetQuestAreasRequest(string QuestId, int PlayerLevel, global::System.Collections.Generic.IReadOnlyList<string> CompletedTaskKeys)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(GetQuestAreasRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("GetQuestAreasRequest");
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
		builder.Append("QuestId = ");
		builder.Append((object)QuestId);
		builder.Append(", PlayerLevel = ");
		builder.Append(((object)PlayerLevel).ToString());
		builder.Append(", CompletedTaskKeys = ");
		builder.Append((object)CompletedTaskKeys);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(GetQuestAreasRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(QuestId, other.QuestId) && EqualityComparer<int>.Default.Equals(PlayerLevel, other.PlayerLevel) && EqualityComparer<global::System.Collections.Generic.IReadOnlyList<string>>.Default.Equals(CompletedTaskKeys, other.CompletedTaskKeys));
	}
}
