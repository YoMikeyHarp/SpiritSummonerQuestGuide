using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Spirits;

public record LevelUpSpiritResponse(string SpiritId, int NewLevel, int NewHP, int NewTrainingPoints, long GoldSpent)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(LevelUpSpiritResponse);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("LevelUpSpiritResponse");
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
		builder.Append("SpiritId = ");
		builder.Append((object)SpiritId);
		builder.Append(", NewLevel = ");
		builder.Append(((object)NewLevel).ToString());
		builder.Append(", NewHP = ");
		builder.Append(((object)NewHP).ToString());
		builder.Append(", NewTrainingPoints = ");
		builder.Append(((object)NewTrainingPoints).ToString());
		builder.Append(", GoldSpent = ");
		builder.Append(((object)GoldSpent).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(LevelUpSpiritResponse? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(SpiritId, other.SpiritId) && EqualityComparer<int>.Default.Equals(NewLevel, other.NewLevel) && EqualityComparer<int>.Default.Equals(NewHP, other.NewHP) && EqualityComparer<int>.Default.Equals(NewTrainingPoints, other.NewTrainingPoints) && EqualityComparer<long>.Default.Equals(GoldSpent, other.GoldSpent));
	}
}
