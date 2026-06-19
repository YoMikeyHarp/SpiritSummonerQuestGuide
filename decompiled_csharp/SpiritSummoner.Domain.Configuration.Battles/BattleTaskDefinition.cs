using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Domain.Enums.Battles;

namespace SpiritSummoner.Domain.Configuration.Battles;

public record BattleTaskDefinition(string TaskId, BattleTaskType Type, string Title, string Description, int Target, bool IsWarTask, long CrystalReward, int EnergyReward, long GuildCoinsReward)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(BattleTaskDefinition);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("BattleTaskDefinition");
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
		builder.Append(", Type = ");
		builder.Append(((object)Type).ToString());
		builder.Append(", Title = ");
		builder.Append((object)Title);
		builder.Append(", Description = ");
		builder.Append((object)Description);
		builder.Append(", Target = ");
		builder.Append(((object)Target).ToString());
		builder.Append(", IsWarTask = ");
		builder.Append(((object)IsWarTask).ToString());
		builder.Append(", CrystalReward = ");
		builder.Append(((object)CrystalReward).ToString());
		builder.Append(", EnergyReward = ");
		builder.Append(((object)EnergyReward).ToString());
		builder.Append(", GuildCoinsReward = ");
		builder.Append(((object)GuildCoinsReward).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(BattleTaskDefinition? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(TaskId, other.TaskId) && EqualityComparer<BattleTaskType>.Default.Equals(Type, other.Type) && EqualityComparer<string>.Default.Equals(Title, other.Title) && EqualityComparer<string>.Default.Equals(Description, other.Description) && EqualityComparer<int>.Default.Equals(Target, other.Target) && EqualityComparer<bool>.Default.Equals(IsWarTask, other.IsWarTask) && EqualityComparer<long>.Default.Equals(CrystalReward, other.CrystalReward) && EqualityComparer<int>.Default.Equals(EnergyReward, other.EnergyReward) && EqualityComparer<long>.Default.Equals(GuildCoinsReward, other.GuildCoinsReward));
	}
}
