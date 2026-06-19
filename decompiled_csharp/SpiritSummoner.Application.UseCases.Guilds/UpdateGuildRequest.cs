using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Guilds;

public record UpdateGuildRequest(string GuildId, string LeaderPlayerId, string LeaderPlayerName, string GuildName, string? Description = null, string? Emblem = null, bool IsPublic = true, bool RequiresApproval = false, int MinLevelRequired = 1, int MinTrophiesRequired = 0)
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(UpdateGuildRequest);
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("UpdateGuildRequest");
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
		builder.Append(", LeaderPlayerId = ");
		builder.Append((object)LeaderPlayerId);
		builder.Append(", LeaderPlayerName = ");
		builder.Append((object)LeaderPlayerName);
		builder.Append(", GuildName = ");
		builder.Append((object)GuildName);
		builder.Append(", Description = ");
		builder.Append((object)Description);
		builder.Append(", Emblem = ");
		builder.Append((object)Emblem);
		builder.Append(", IsPublic = ");
		builder.Append(((object)IsPublic).ToString());
		builder.Append(", RequiresApproval = ");
		builder.Append(((object)RequiresApproval).ToString());
		builder.Append(", MinLevelRequired = ");
		builder.Append(((object)MinLevelRequired).ToString());
		builder.Append(", MinTrophiesRequired = ");
		builder.Append(((object)MinTrophiesRequired).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(UpdateGuildRequest? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(GuildId, other.GuildId) && EqualityComparer<string>.Default.Equals(LeaderPlayerId, other.LeaderPlayerId) && EqualityComparer<string>.Default.Equals(LeaderPlayerName, other.LeaderPlayerName) && EqualityComparer<string>.Default.Equals(GuildName, other.GuildName) && EqualityComparer<string>.Default.Equals(Description, other.Description) && EqualityComparer<string>.Default.Equals(Emblem, other.Emblem) && EqualityComparer<bool>.Default.Equals(IsPublic, other.IsPublic) && EqualityComparer<bool>.Default.Equals(RequiresApproval, other.RequiresApproval) && EqualityComparer<int>.Default.Equals(MinLevelRequired, other.MinLevelRequired) && EqualityComparer<int>.Default.Equals(MinTrophiesRequired, other.MinTrophiesRequired));
	}
}
