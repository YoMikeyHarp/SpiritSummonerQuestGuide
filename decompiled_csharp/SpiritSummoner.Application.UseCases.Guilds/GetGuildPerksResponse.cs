using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Guilds;

public record GetGuildPerksResponse(global::System.Collections.Generic.IReadOnlyList<GuildPerkView> Perks, int GuildCrystals, bool IsLeader)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(GetGuildPerksResponse);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("GetGuildPerksResponse");
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
		builder.Append("Perks = ");
		builder.Append((object)Perks);
		builder.Append(", GuildCrystals = ");
		builder.Append(((object)GuildCrystals).ToString());
		builder.Append(", IsLeader = ");
		builder.Append(((object)IsLeader).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(GetGuildPerksResponse? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<global::System.Collections.Generic.IReadOnlyList<GuildPerkView>>.Default.Equals(Perks, other.Perks) && EqualityComparer<int>.Default.Equals(GuildCrystals, other.GuildCrystals) && EqualityComparer<bool>.Default.Equals(IsLeader, other.IsLeader));
	}
}
