using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Spirits;

public record ApplyMovesEditResponse(string SpiritId, List<string> MovesUpdated, Dictionary<string, int> ResourcesConsumed)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(ApplyMovesEditResponse);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("ApplyMovesEditResponse");
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
		builder.Append(", MovesUpdated = ");
		builder.Append((object)MovesUpdated);
		builder.Append(", ResourcesConsumed = ");
		builder.Append((object)ResourcesConsumed);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(ApplyMovesEditResponse? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(SpiritId, other.SpiritId) && EqualityComparer<List<string>>.Default.Equals(MovesUpdated, other.MovesUpdated) && EqualityComparer<Dictionary<string, int>>.Default.Equals(ResourcesConsumed, other.ResourcesConsumed));
	}
}
