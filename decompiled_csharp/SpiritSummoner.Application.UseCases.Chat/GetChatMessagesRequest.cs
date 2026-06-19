using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Chat;

public record GetChatMessagesRequest(string ConversationId, int Limit = 50, DateTimeOffset? BeforeTimestamp = null)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(GetChatMessagesRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("GetChatMessagesRequest");
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
		builder.Append("ConversationId = ");
		builder.Append((object)ConversationId);
		builder.Append(", Limit = ");
		builder.Append(((object)Limit).ToString());
		builder.Append(", BeforeTimestamp = ");
		builder.Append(((object)BeforeTimestamp).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(GetChatMessagesRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(ConversationId, other.ConversationId) && EqualityComparer<int>.Default.Equals(Limit, other.Limit) && EqualityComparer<DateTimeOffset?>.Default.Equals(BeforeTimestamp, other.BeforeTimestamp));
	}
}
