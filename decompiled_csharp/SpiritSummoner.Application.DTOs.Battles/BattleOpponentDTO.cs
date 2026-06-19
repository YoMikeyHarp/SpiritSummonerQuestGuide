using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Application.DTOs.Battles;

public record BattleOpponentDTO
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(BattleOpponentDTO);
		}
	}

	public string PlayerId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = string.Empty;


	public string Username
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = string.Empty;


	public int Level
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public string? Title
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public string? Icon
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = string.Empty;


	public long Reputation
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public global::System.Collections.Generic.IReadOnlyList<string> ActiveSquadSpiritIds
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = global::System.Array.Empty<string>();


	public global::System.Collections.Generic.IReadOnlyList<PlayerSpirit>? OpponentSpirits
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public bool HasSpirits => OpponentSpirits != null && ((global::System.Collections.Generic.IReadOnlyCollection<PlayerSpirit>)OpponentSpirits).Count > 0;

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("BattleOpponentDTO");
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
		builder.Append(", Username = ");
		builder.Append((object)Username);
		builder.Append(", Level = ");
		builder.Append(((object)Level).ToString());
		builder.Append(", Title = ");
		builder.Append((object)Title);
		builder.Append(", Icon = ");
		builder.Append((object)Icon);
		builder.Append(", Reputation = ");
		builder.Append(((object)Reputation).ToString());
		builder.Append(", ActiveSquadSpiritIds = ");
		builder.Append((object)ActiveSquadSpiritIds);
		builder.Append(", OpponentSpirits = ");
		builder.Append((object)OpponentSpirits);
		builder.Append(", HasSpirits = ");
		builder.Append(((object)HasSpirits).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(BattleOpponentDTO? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(PlayerId, other.PlayerId) && EqualityComparer<string>.Default.Equals(Username, other.Username) && EqualityComparer<int>.Default.Equals(Level, other.Level) && EqualityComparer<string>.Default.Equals(Title, other.Title) && EqualityComparer<string>.Default.Equals(Icon, other.Icon) && EqualityComparer<long>.Default.Equals(Reputation, other.Reputation) && EqualityComparer<global::System.Collections.Generic.IReadOnlyList<string>>.Default.Equals(ActiveSquadSpiritIds, other.ActiveSquadSpiritIds) && EqualityComparer<global::System.Collections.Generic.IReadOnlyList<PlayerSpirit>>.Default.Equals(OpponentSpirits, other.OpponentSpirits));
	}
}
