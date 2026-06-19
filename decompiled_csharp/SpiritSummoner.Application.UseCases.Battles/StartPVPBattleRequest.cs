using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Enums.Battles;

namespace SpiritSummoner.Application.UseCases.Battles;

public record StartPVPBattleRequest(string PlayerId, List<string> PlayerSpiritIds, string OpponentName, global::System.Collections.Generic.IReadOnlyList<PlayerSpirit> OpponentSpirits, BattleMode BattleMode)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(StartPVPBattleRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("StartPVPBattleRequest");
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
		builder.Append(", OpponentName = ");
		builder.Append((object)OpponentName);
		builder.Append(", OpponentSpirits = ");
		builder.Append((object)OpponentSpirits);
		builder.Append(", BattleMode = ");
		builder.Append(((object)BattleMode).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(StartPVPBattleRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(PlayerId, other.PlayerId) && EqualityComparer<List<string>>.Default.Equals(PlayerSpiritIds, other.PlayerSpiritIds) && EqualityComparer<string>.Default.Equals(OpponentName, other.OpponentName) && EqualityComparer<global::System.Collections.Generic.IReadOnlyList<PlayerSpirit>>.Default.Equals(OpponentSpirits, other.OpponentSpirits) && EqualityComparer<BattleMode>.Default.Equals(BattleMode, other.BattleMode));
	}
}
