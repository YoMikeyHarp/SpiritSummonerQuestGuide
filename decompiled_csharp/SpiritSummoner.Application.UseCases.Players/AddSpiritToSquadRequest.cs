using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Players;

public record AddSpiritToSquadRequest(int PositionInSquad, string SpiritId)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(AddSpiritToSquadRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("AddSpiritToSquadRequest");
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
		builder.Append("PositionInSquad = ");
		builder.Append(((object)PositionInSquad).ToString());
		builder.Append(", SpiritId = ");
		builder.Append((object)SpiritId);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(AddSpiritToSquadRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<int>.Default.Equals(PositionInSquad, other.PositionInSquad) && EqualityComparer<string>.Default.Equals(SpiritId, other.SpiritId));
	}
}
