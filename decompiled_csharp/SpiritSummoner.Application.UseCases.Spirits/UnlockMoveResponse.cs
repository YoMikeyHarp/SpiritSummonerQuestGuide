using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Spirits;

public record UnlockMoveResponse(string SpiritId, string MoveName, bool IsActive, Dictionary<string, int>? ItemsConsumed = null)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(UnlockMoveResponse);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("UnlockMoveResponse");
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
		builder.Append(", IsActive = ");
		builder.Append(((object)IsActive).ToString());
		builder.Append(", ItemsConsumed = ");
		builder.Append((object)ItemsConsumed);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(UnlockMoveResponse? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(SpiritId, other.SpiritId) && EqualityComparer<string>.Default.Equals(MoveName, other.MoveName) && EqualityComparer<bool>.Default.Equals(IsActive, other.IsActive) && EqualityComparer<Dictionary<string, int>>.Default.Equals(ItemsConsumed, other.ItemsConsumed));
	}
}
