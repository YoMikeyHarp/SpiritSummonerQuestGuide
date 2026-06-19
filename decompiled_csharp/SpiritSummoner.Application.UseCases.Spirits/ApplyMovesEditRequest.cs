using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Spirits;

public record ApplyMovesEditRequest(string SpiritId, List<MoveChangeRequest> MoveChanges)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(ApplyMovesEditRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("ApplyMovesEditRequest");
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
		builder.Append(", MoveChanges = ");
		builder.Append((object)MoveChanges);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(ApplyMovesEditRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(SpiritId, other.SpiritId) && EqualityComparer<List<MoveChangeRequest>>.Default.Equals(MoveChanges, other.MoveChanges));
	}
}
