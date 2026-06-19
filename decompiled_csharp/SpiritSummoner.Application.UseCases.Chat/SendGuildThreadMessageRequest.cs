using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Chat;

public record SendGuildThreadMessageRequest(string GuildId, string ThreadId, string Content)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(SendGuildThreadMessageRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("SendGuildThreadMessageRequest");
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
		builder.Append(", Content = ");
		builder.Append((object)Content);
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(SendGuildThreadMessageRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(GuildId, other.GuildId) && EqualityComparer<string>.Default.Equals(ThreadId, other.ThreadId) && EqualityComparer<string>.Default.Equals(Content, other.Content));
	}
}
