using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Battles;

public record GetBattleTasksResponse(global::System.Collections.Generic.IReadOnlyList<BattleTaskView> Tasks)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(GetBattleTasksResponse);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("GetBattleTasksResponse");
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
		builder.Append("Tasks = ");
		builder.Append((object)Tasks);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(GetBattleTasksResponse? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<global::System.Collections.Generic.IReadOnlyList<BattleTaskView>>.Default.Equals(Tasks, other.Tasks));
	}
}
