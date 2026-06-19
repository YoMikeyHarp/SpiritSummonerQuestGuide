using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Battles;

public record StartFriendBattleRequest(string FriendPlayerId, bool Is3v3 = true)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(StartFriendBattleRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("StartFriendBattleRequest");
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
		builder.Append("FriendPlayerId = ");
		builder.Append((object)FriendPlayerId);
		builder.Append(", Is3v3 = ");
		builder.Append(((object)Is3v3).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(StartFriendBattleRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(FriendPlayerId, other.FriendPlayerId) && EqualityComparer<bool>.Default.Equals(Is3v3, other.Is3v3));
	}
}
