using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Quests;

public record StartQuestRequest(string PlayerId, string QuestId, string AreaId, int PlayerLevel)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(StartQuestRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("StartQuestRequest");
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
		builder.Append("PlayerId = ");
		builder.Append((object)PlayerId);
		builder.Append(", QuestId = ");
		builder.Append((object)QuestId);
		builder.Append(", AreaId = ");
		builder.Append((object)AreaId);
		builder.Append(", PlayerLevel = ");
		builder.Append(((object)PlayerLevel).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(StartQuestRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(PlayerId, other.PlayerId) && EqualityComparer<string>.Default.Equals(QuestId, other.QuestId) && EqualityComparer<string>.Default.Equals(AreaId, other.AreaId) && EqualityComparer<int>.Default.Equals(PlayerLevel, other.PlayerLevel));
	}
}
