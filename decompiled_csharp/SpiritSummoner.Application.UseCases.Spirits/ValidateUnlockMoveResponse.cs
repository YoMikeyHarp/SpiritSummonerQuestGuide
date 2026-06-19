using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Spirits;

public record ValidateUnlockMoveResponse(string SpiritId, string MoveName, bool IsFree, Dictionary<string, int> ResourceCost, int RequiredLevel, int RequiredSpiritLevel)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(ValidateUnlockMoveResponse);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("ValidateUnlockMoveResponse");
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
		builder.Append(", MoveName = ");
		builder.Append((object)MoveName);
		builder.Append(", IsFree = ");
		builder.Append(((object)IsFree).ToString());
		builder.Append(", ResourceCost = ");
		builder.Append((object)ResourceCost);
		builder.Append(", RequiredLevel = ");
		builder.Append(((object)RequiredLevel).ToString());
		builder.Append(", RequiredSpiritLevel = ");
		builder.Append(((object)RequiredSpiritLevel).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(ValidateUnlockMoveResponse? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(SpiritId, other.SpiritId) && EqualityComparer<string>.Default.Equals(MoveName, other.MoveName) && EqualityComparer<bool>.Default.Equals(IsFree, other.IsFree) && EqualityComparer<Dictionary<string, int>>.Default.Equals(ResourceCost, other.ResourceCost) && EqualityComparer<int>.Default.Equals(RequiredLevel, other.RequiredLevel) && EqualityComparer<int>.Default.Equals(RequiredSpiritLevel, other.RequiredSpiritLevel));
	}
}
