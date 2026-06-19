using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Presentation.Models;

public record AttributeProgressModel(string Name, string Icon, int BaseValue, int AllocatedPoints, double BonusMultiplier, int RawValue, int FinalValue, double BaseProgress, double BonusProgress, double ItemBuffProgress, bool IsItemBuffNegative = false)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(AttributeProgressModel);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("AttributeProgressModel");
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
		builder.Append(", Icon = ");
		builder.Append((object)Icon);
		builder.Append(", BaseValue = ");
		builder.Append(((object)BaseValue).ToString());
		builder.Append(", AllocatedPoints = ");
		builder.Append(((object)AllocatedPoints).ToString());
		builder.Append(", BonusMultiplier = ");
		builder.Append(((object)BonusMultiplier).ToString());
		builder.Append(", RawValue = ");
		builder.Append(((object)RawValue).ToString());
		builder.Append(", FinalValue = ");
		builder.Append(((object)FinalValue).ToString());
		builder.Append(", BaseProgress = ");
		builder.Append(((object)BaseProgress).ToString());
		builder.Append(", BonusProgress = ");
		builder.Append(((object)BonusProgress).ToString());
		builder.Append(", ItemBuffProgress = ");
		builder.Append(((object)ItemBuffProgress).ToString());
		builder.Append(", IsItemBuffNegative = ");
		builder.Append(((object)IsItemBuffNegative).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(AttributeProgressModel? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(Name, other.Name) && EqualityComparer<string>.Default.Equals(Icon, other.Icon) && EqualityComparer<int>.Default.Equals(BaseValue, other.BaseValue) && EqualityComparer<int>.Default.Equals(AllocatedPoints, other.AllocatedPoints) && EqualityComparer<double>.Default.Equals(BonusMultiplier, other.BonusMultiplier) && EqualityComparer<int>.Default.Equals(RawValue, other.RawValue) && EqualityComparer<int>.Default.Equals(FinalValue, other.FinalValue) && EqualityComparer<double>.Default.Equals(BaseProgress, other.BaseProgress) && EqualityComparer<double>.Default.Equals(BonusProgress, other.BonusProgress) && EqualityComparer<double>.Default.Equals(ItemBuffProgress, other.ItemBuffProgress) && EqualityComparer<bool>.Default.Equals(IsItemBuffNegative, other.IsItemBuffNegative));
	}
}
