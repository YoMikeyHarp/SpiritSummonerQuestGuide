using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Battles;

public record UpdateBattleTaskProgressResponse(global::System.Collections.Generic.IReadOnlyList<string> NewlyCompletedTaskIds)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(UpdateBattleTaskProgressResponse);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("UpdateBattleTaskProgressResponse");
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
		builder.Append("NewlyCompletedTaskIds = ");
		builder.Append((object)NewlyCompletedTaskIds);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(UpdateBattleTaskProgressResponse? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<global::System.Collections.Generic.IReadOnlyList<string>>.Default.Equals(NewlyCompletedTaskIds, other.NewlyCompletedTaskIds));
	}
}
