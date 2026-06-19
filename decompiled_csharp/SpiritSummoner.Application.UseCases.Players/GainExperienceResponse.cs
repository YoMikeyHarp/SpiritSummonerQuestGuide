using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Players;

public record GainExperienceResponse(double ExperienceGained, int NewLevel, bool LeveledUp, double NewMaxEXP, int NewMaxEP, int NewMaxSP)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(GainExperienceResponse);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("GainExperienceResponse");
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
		builder.Append("ExperienceGained = ");
		builder.Append(((object)ExperienceGained).ToString());
		builder.Append(", NewLevel = ");
		builder.Append(((object)NewLevel).ToString());
		builder.Append(", LeveledUp = ");
		builder.Append(((object)LeveledUp).ToString());
		builder.Append(", NewMaxEXP = ");
		builder.Append(((object)NewMaxEXP).ToString());
		builder.Append(", NewMaxEP = ");
		builder.Append(((object)NewMaxEP).ToString());
		builder.Append(", NewMaxSP = ");
		builder.Append(((object)NewMaxSP).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(GainExperienceResponse? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<double>.Default.Equals(ExperienceGained, other.ExperienceGained) && EqualityComparer<int>.Default.Equals(NewLevel, other.NewLevel) && EqualityComparer<bool>.Default.Equals(LeveledUp, other.LeveledUp) && EqualityComparer<double>.Default.Equals(NewMaxEXP, other.NewMaxEXP) && EqualityComparer<int>.Default.Equals(NewMaxEP, other.NewMaxEP) && EqualityComparer<int>.Default.Equals(NewMaxSP, other.NewMaxSP));
	}
}
