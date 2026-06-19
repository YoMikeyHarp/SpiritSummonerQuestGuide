using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Spirits;

public record EvolveSpiritResponse(string SpiritId, int NewBaseSpiritId, string? NewName, string? NewImage)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(EvolveSpiritResponse);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("EvolveSpiritResponse");
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
		builder.Append(", NewBaseSpiritId = ");
		builder.Append(((object)NewBaseSpiritId).ToString());
		builder.Append(", NewName = ");
		builder.Append((object)NewName);
		builder.Append(", NewImage = ");
		builder.Append((object)NewImage);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(EvolveSpiritResponse? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(SpiritId, other.SpiritId) && EqualityComparer<int>.Default.Equals(NewBaseSpiritId, other.NewBaseSpiritId) && EqualityComparer<string>.Default.Equals(NewName, other.NewName) && EqualityComparer<string>.Default.Equals(NewImage, other.NewImage));
	}
}
