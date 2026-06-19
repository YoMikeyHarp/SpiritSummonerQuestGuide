using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpiritSummoner.Application.UseCases.Players;

public record PlayerSearchResultModel
{
	[CompilerGenerated]
	protected virtual global::System.Type EqualityContract
	{
		[CompilerGenerated]
		get
		{
			return typeof(PlayerSearchResultModel);
		}
	}

	public string PlayerId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = string.Empty;


	public string PlayerName
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

	public long Trophies
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public string? GuildId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public bool HasGuild
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public string LevelDisplay => $"Lvl {Level}";

	public string TrophiesDisplay => $"{Trophies:N0} \ud83c\udfc6";

	public bool CanInvite => !HasGuild;

	[CompilerGenerated]
	public override string ToString()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		StringBuilder val = new StringBuilder();
		val.Append("PlayerSearchResultModel");
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
		builder.Append(", Level = ");
		builder.Append(((object)Level).ToString());
		builder.Append(", Trophies = ");
		builder.Append(((object)Trophies).ToString());
		builder.Append(", GuildId = ");
		builder.Append((object)GuildId);
		builder.Append(", HasGuild = ");
		builder.Append(((object)HasGuild).ToString());
		builder.Append(", LevelDisplay = ");
		builder.Append((object)LevelDisplay);
		builder.Append(", TrophiesDisplay = ");
		builder.Append((object)TrophiesDisplay);
		builder.Append(", CanInvite = ");
		builder.Append(((object)CanInvite).ToString());
		return true;
	}

	[CompilerGenerated]
	public virtual bool Equals(PlayerSearchResultModel? other)
	{
		return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(PlayerId, other.PlayerId) && EqualityComparer<string>.Default.Equals(PlayerName, other.PlayerName) && EqualityComparer<int>.Default.Equals(Level, other.Level) && EqualityComparer<long>.Default.Equals(Trophies, other.Trophies) && EqualityComparer<string>.Default.Equals(GuildId, other.GuildId) && EqualityComparer<bool>.Default.Equals(HasGuild, other.HasGuild));
	}
}
