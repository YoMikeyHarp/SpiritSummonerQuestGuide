using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Spirits;

public record ValidateUnlockMoveRequest(string SpiritId, string MoveName, Dictionary<string, int>? CurrentInventorySnapshot = null)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(ValidateUnlockMoveRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("ValidateUnlockMoveRequest");
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
		builder.Append(", CurrentInventorySnapshot = ");
		builder.Append((object)CurrentInventorySnapshot);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(ValidateUnlockMoveRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(SpiritId, other.SpiritId) && EqualityComparer<string>.Default.Equals(MoveName, other.MoveName) && EqualityComparer<Dictionary<string, int>>.Default.Equals(CurrentInventorySnapshot, other.CurrentInventorySnapshot));
	}
}
