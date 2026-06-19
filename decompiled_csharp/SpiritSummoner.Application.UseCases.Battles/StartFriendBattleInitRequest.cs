using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Battles;

public record StartFriendBattleInitRequest(string PlayerId, List<string> PlayerSpiritIds, string OpponentPlayerId, List<string> OpponentSpiritIds)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(StartFriendBattleInitRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("StartFriendBattleInitRequest");
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
		builder.Append("PlayerId = ");
		builder.Append((object)PlayerId);
		builder.Append(", PlayerSpiritIds = ");
		builder.Append((object)PlayerSpiritIds);
		builder.Append(", OpponentPlayerId = ");
		builder.Append((object)OpponentPlayerId);
		builder.Append(", OpponentSpiritIds = ");
		builder.Append((object)OpponentSpiritIds);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(StartFriendBattleInitRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(PlayerId, other.PlayerId) && EqualityComparer<List<string>>.Default.Equals(PlayerSpiritIds, other.PlayerSpiritIds) && EqualityComparer<string>.Default.Equals(OpponentPlayerId, other.OpponentPlayerId) && EqualityComparer<List<string>>.Default.Equals(OpponentSpiritIds, other.OpponentSpiritIds));
	}
}
