using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Chat;

public record GetGuildThreadMessagesRequest(string GuildId, string ThreadId, int Limit = 25, DateTimeOffset? BeforeTimestamp = null)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(GetGuildThreadMessagesRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("GetGuildThreadMessagesRequest");
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
		builder.Append("GuildId = ");
		builder.Append((object)GuildId);
		builder.Append(", ThreadId = ");
		builder.Append((object)ThreadId);
		builder.Append(", Limit = ");
		builder.Append(((object)Limit).ToString());
		builder.Append(", BeforeTimestamp = ");
		builder.Append(((object)BeforeTimestamp).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(GetGuildThreadMessagesRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(GuildId, other.GuildId) && EqualityComparer<string>.Default.Equals(ThreadId, other.ThreadId) && EqualityComparer<int>.Default.Equals(Limit, other.Limit) && EqualityComparer<DateTimeOffset?>.Default.Equals(BeforeTimestamp, other.BeforeTimestamp));
	}
}
