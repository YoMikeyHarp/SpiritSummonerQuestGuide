using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SpiritSummoner.Presentation.ViewModels.Guilds;

namespace SpiritSummoner.Application.UseCases.Guilds;

public record SearchGuildsRequest(string SearchText = "", GuildSearchFilters Filters = null, int PlayerLevel = 1, long PlayerTrophies = 0L, int Limit = 50)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(SearchGuildsRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("SearchGuildsRequest");
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
		builder.Append(", Filters = ");
		builder.Append((object)Filters);
		builder.Append(", PlayerLevel = ");
		builder.Append(((object)PlayerLevel).ToString());
		builder.Append(", PlayerTrophies = ");
		builder.Append(((object)PlayerTrophies).ToString());
		builder.Append(", Limit = ");
		builder.Append(((object)Limit).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(SearchGuildsRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(SearchText, other.SearchText) && EqualityComparer<GuildSearchFilters>.Default.Equals(Filters, other.Filters) && EqualityComparer<int>.Default.Equals(PlayerLevel, other.PlayerLevel) && EqualityComparer<long>.Default.Equals(PlayerTrophies, other.PlayerTrophies) && EqualityComparer<int>.Default.Equals(Limit, other.Limit));
	}
}
