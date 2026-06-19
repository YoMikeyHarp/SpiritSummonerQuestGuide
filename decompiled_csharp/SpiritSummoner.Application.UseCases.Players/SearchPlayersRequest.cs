using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Players;

public record SearchPlayersRequest(string SearchText, string? ExcludeGuildId = null, string? ExcludePlayerId = null, int Limit = 20)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(SearchPlayersRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("SearchPlayersRequest");
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
		builder.Append("SearchText = ");
		builder.Append((object)SearchText);
		builder.Append(", ExcludeGuildId = ");
		builder.Append((object)ExcludeGuildId);
		builder.Append(", ExcludePlayerId = ");
		builder.Append((object)ExcludePlayerId);
		builder.Append(", Limit = ");
		builder.Append(((object)Limit).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(SearchPlayersRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(SearchText, other.SearchText) && EqualityComparer<string>.Default.Equals(ExcludeGuildId, other.ExcludeGuildId) && EqualityComparer<string>.Default.Equals(ExcludePlayerId, other.ExcludePlayerId) && EqualityComparer<int>.Default.Equals(Limit, other.Limit));
	}
}
