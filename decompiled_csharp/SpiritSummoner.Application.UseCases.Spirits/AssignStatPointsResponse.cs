using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Spirits;

public record AssignStatPointsResponse(string SpiritId, int NewTrainingPoints, int NewPointsATK, int NewPointsDEF, int NewPointsSATK, int NewPointsSDEF, int NewPointsSPD, int NewPointsINT, int PointsAssigned)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(AssignStatPointsResponse);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("AssignStatPointsResponse");
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
		builder.Append(", NewTrainingPoints = ");
		builder.Append(((object)NewTrainingPoints).ToString());
		builder.Append(", NewPointsATK = ");
		builder.Append(((object)NewPointsATK).ToString());
		builder.Append(", NewPointsDEF = ");
		builder.Append(((object)NewPointsDEF).ToString());
		builder.Append(", NewPointsSATK = ");
		builder.Append(((object)NewPointsSATK).ToString());
		builder.Append(", NewPointsSDEF = ");
		builder.Append(((object)NewPointsSDEF).ToString());
		builder.Append(", NewPointsSPD = ");
		builder.Append(((object)NewPointsSPD).ToString());
		builder.Append(", NewPointsINT = ");
		builder.Append(((object)NewPointsINT).ToString());
		builder.Append(", PointsAssigned = ");
		builder.Append(((object)PointsAssigned).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(AssignStatPointsResponse? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(SpiritId, other.SpiritId) && EqualityComparer<int>.Default.Equals(NewTrainingPoints, other.NewTrainingPoints) && EqualityComparer<int>.Default.Equals(NewPointsATK, other.NewPointsATK) && EqualityComparer<int>.Default.Equals(NewPointsDEF, other.NewPointsDEF) && EqualityComparer<int>.Default.Equals(NewPointsSATK, other.NewPointsSATK) && EqualityComparer<int>.Default.Equals(NewPointsSDEF, other.NewPointsSDEF) && EqualityComparer<int>.Default.Equals(NewPointsSPD, other.NewPointsSPD) && EqualityComparer<int>.Default.Equals(NewPointsINT, other.NewPointsINT) && EqualityComparer<int>.Default.Equals(PointsAssigned, other.PointsAssigned));
	}
}
