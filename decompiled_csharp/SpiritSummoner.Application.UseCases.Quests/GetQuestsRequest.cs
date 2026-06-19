using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Quests;

public record GetQuestsRequest(int PlayerLevel, bool IncludeCompleted = false)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(GetQuestsRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("GetQuestsRequest");
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
		builder.Append("PlayerLevel = ");
		builder.Append(((object)PlayerLevel).ToString());
		builder.Append(", IncludeCompleted = ");
		builder.Append(((object)IncludeCompleted).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(GetQuestsRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<int>.Default.Equals(PlayerLevel, other.PlayerLevel) && EqualityComparer<bool>.Default.Equals(IncludeCompleted, other.IncludeCompleted));
	}
}
