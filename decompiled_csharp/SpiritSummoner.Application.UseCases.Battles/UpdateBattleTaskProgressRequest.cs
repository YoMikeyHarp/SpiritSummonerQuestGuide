using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Domain.Enums.Battles;

namespace SpiritSummoner.Application.UseCases.Battles;

public record UpdateBattleTaskProgressRequest(BattleTaskType[] TaskTypesToIncrement)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(UpdateBattleTaskProgressRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("UpdateBattleTaskProgressRequest");
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
		builder.Append("TaskTypesToIncrement = ");
		builder.Append((object)TaskTypesToIncrement);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(UpdateBattleTaskProgressRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<BattleTaskType[]>.Default.Equals(TaskTypesToIncrement, other.TaskTypesToIncrement));
	}
}
