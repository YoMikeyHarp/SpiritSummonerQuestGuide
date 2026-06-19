using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Players;

public record UpdateSquadRequest(int SquadSlot, List<string> SpiritIds, bool SetAsActive = false)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(UpdateSquadRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("UpdateSquadRequest");
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
		builder.Append("SquadSlot = ");
		builder.Append(((object)SquadSlot).ToString());
		builder.Append(", SpiritIds = ");
		builder.Append((object)SpiritIds);
		builder.Append(", SetAsActive = ");
		builder.Append(((object)SetAsActive).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(UpdateSquadRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<int>.Default.Equals(SquadSlot, other.SquadSlot) && EqualityComparer<List<string>>.Default.Equals(SpiritIds, other.SpiritIds) && EqualityComparer<bool>.Default.Equals(SetAsActive, other.SetAsActive));
	}
}
