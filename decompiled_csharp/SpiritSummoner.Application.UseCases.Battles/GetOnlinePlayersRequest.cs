using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Battles;

public record GetOnlinePlayersRequest(int Limit = 10, int TeamSize = 3)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(GetOnlinePlayersRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("GetOnlinePlayersRequest");
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
		builder.Append("Limit = ");
		builder.Append(((object)Limit).ToString());
		builder.Append(", TeamSize = ");
		builder.Append(((object)TeamSize).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(GetOnlinePlayersRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<int>.Default.Equals(Limit, other.Limit) && EqualityComparer<int>.Default.Equals(TeamSize, other.TeamSize));
	}
}
