using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Spirits;

public record AssignStatPointsRequest(string SpiritId, int PointsATK, int PointsDEF, int PointsSATK, int PointsSDEF, int PointsSPD, int PointsINT)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(AssignStatPointsRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("AssignStatPointsRequest");
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
		builder.Append(", PointsATK = ");
		builder.Append(((object)PointsATK).ToString());
		builder.Append(", PointsDEF = ");
		builder.Append(((object)PointsDEF).ToString());
		builder.Append(", PointsSATK = ");
		builder.Append(((object)PointsSATK).ToString());
		builder.Append(", PointsSDEF = ");
		builder.Append(((object)PointsSDEF).ToString());
		builder.Append(", PointsSPD = ");
		builder.Append(((object)PointsSPD).ToString());
		builder.Append(", PointsINT = ");
		builder.Append(((object)PointsINT).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(AssignStatPointsRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(SpiritId, other.SpiritId) && EqualityComparer<int>.Default.Equals(PointsATK, other.PointsATK) && EqualityComparer<int>.Default.Equals(PointsDEF, other.PointsDEF) && EqualityComparer<int>.Default.Equals(PointsSATK, other.PointsSATK) && EqualityComparer<int>.Default.Equals(PointsSDEF, other.PointsSDEF) && EqualityComparer<int>.Default.Equals(PointsSPD, other.PointsSPD) && EqualityComparer<int>.Default.Equals(PointsINT, other.PointsINT));
	}
}
