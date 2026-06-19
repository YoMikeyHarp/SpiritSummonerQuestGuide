using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Presentation.Models;

public record PlayerSpiritAttributeModel(string Name, double BaseProgress, double BonusProgress, double Ratio, int Total, string Image)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(PlayerSpiritAttributeModel);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("PlayerSpiritAttributeModel");
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
		builder.Append("Name = ");
		builder.Append((object)Name);
		builder.Append(", BaseProgress = ");
		builder.Append(((object)BaseProgress).ToString());
		builder.Append(", BonusProgress = ");
		builder.Append(((object)BonusProgress).ToString());
		builder.Append(", Ratio = ");
		builder.Append(((object)Ratio).ToString());
		builder.Append(", Total = ");
		builder.Append(((object)Total).ToString());
		builder.Append(", Image = ");
		builder.Append((object)Image);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(PlayerSpiritAttributeModel? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(Name, other.Name) && EqualityComparer<double>.Default.Equals(BaseProgress, other.BaseProgress) && EqualityComparer<double>.Default.Equals(BonusProgress, other.BonusProgress) && EqualityComparer<double>.Default.Equals(Ratio, other.Ratio) && EqualityComparer<int>.Default.Equals(Total, other.Total) && EqualityComparer<string>.Default.Equals(Image, other.Image));
	}
}
