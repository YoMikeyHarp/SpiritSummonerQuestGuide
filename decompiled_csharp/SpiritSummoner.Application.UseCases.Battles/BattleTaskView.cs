using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Battles;

public record BattleTaskView(string TaskId, string Title, string Description, int CurrentCount, int Target, bool IsCompleted, bool IsRewardClaimed, long GoldReward, int EnergyReward, long GuildCoinsReward, bool IsWarTask)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(BattleTaskView);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("BattleTaskView");
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
		builder.Append(", Title = ");
		builder.Append((object)Title);
		builder.Append(", Description = ");
		builder.Append((object)Description);
		builder.Append(", CurrentCount = ");
		builder.Append(((object)CurrentCount).ToString());
		builder.Append(", Target = ");
		builder.Append(((object)Target).ToString());
		builder.Append(", IsCompleted = ");
		builder.Append(((object)IsCompleted).ToString());
		builder.Append(", IsRewardClaimed = ");
		builder.Append(((object)IsRewardClaimed).ToString());
		builder.Append(", GoldReward = ");
		builder.Append(((object)GoldReward).ToString());
		builder.Append(", EnergyReward = ");
		builder.Append(((object)EnergyReward).ToString());
		builder.Append(", GuildCoinsReward = ");
		builder.Append(((object)GuildCoinsReward).ToString());
		builder.Append(", IsWarTask = ");
		builder.Append(((object)IsWarTask).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(BattleTaskView? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(TaskId, other.TaskId) && EqualityComparer<string>.Default.Equals(Title, other.Title) && EqualityComparer<string>.Default.Equals(Description, other.Description) && EqualityComparer<int>.Default.Equals(CurrentCount, other.CurrentCount) && EqualityComparer<int>.Default.Equals(Target, other.Target) && EqualityComparer<bool>.Default.Equals(IsCompleted, other.IsCompleted) && EqualityComparer<bool>.Default.Equals(IsRewardClaimed, other.IsRewardClaimed) && EqualityComparer<long>.Default.Equals(GoldReward, other.GoldReward) && EqualityComparer<int>.Default.Equals(EnergyReward, other.EnergyReward) && EqualityComparer<long>.Default.Equals(GuildCoinsReward, other.GuildCoinsReward) && EqualityComparer<bool>.Default.Equals(IsWarTask, other.IsWarTask));
	}
}
