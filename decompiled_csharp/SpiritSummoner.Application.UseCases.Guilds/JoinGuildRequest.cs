using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Guilds;

public record JoinGuildRequest(string PlayerId, string PlayerName, string GuildId, int PlayerLevel = 1, long PlayerTrophies = 0L)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(JoinGuildRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("JoinGuildRequest");
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
		builder.Append(", PlayerName = ");
		builder.Append((object)PlayerName);
		builder.Append(", GuildId = ");
		builder.Append((object)GuildId);
		builder.Append(", PlayerLevel = ");
		builder.Append(((object)PlayerLevel).ToString());
		builder.Append(", PlayerTrophies = ");
		builder.Append(((object)PlayerTrophies).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(JoinGuildRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(PlayerId, other.PlayerId) && EqualityComparer<string>.Default.Equals(PlayerName, other.PlayerName) && EqualityComparer<string>.Default.Equals(GuildId, other.GuildId) && EqualityComparer<int>.Default.Equals(PlayerLevel, other.PlayerLevel) && EqualityComparer<long>.Default.Equals(PlayerTrophies, other.PlayerTrophies));
	}
}
