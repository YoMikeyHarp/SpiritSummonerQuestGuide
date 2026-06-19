using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Domain.Configuration.Guilds;
using SpiritSummoner.Domain.Enums.Guilds;

namespace SpiritSummoner.Domain.Entities.Guilds;

public class GuildActivePerk
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public GuildPerkType PerkType
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Tier
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset ActivatedAt
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string ActivatedByPlayerId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = string.Empty;


	public double GetEffectValue()
	{
		GuildPerkDefinition byType = GuildPerkDefinitions.GetByType(PerkType);
		if (byType == null)
		{
			return 0.0;
		}
		int num = Tier - 1;
		if (num < 0 || num >= ((global::System.Collections.Generic.IReadOnlyCollection<GuildPerkTierDefinition>)byType.Tiers).Count)
		{
			return 0.0;
		}
		return byType.Tiers[num].EffectValue;
	}

	public GuildPerkTierDefinition? GetNextTierDefinition()
	{
		GuildPerkDefinition byType = GuildPerkDefinitions.GetByType(PerkType);
		if (byType == null)
		{
			return null;
		}
		int tier = Tier;
		return (tier < ((global::System.Collections.Generic.IReadOnlyCollection<GuildPerkTierDefinition>)byType.Tiers).Count) ? byType.Tiers[tier] : null;
	}

	public bool IsMaxTier()
	{
		GuildPerkDefinition byType = GuildPerkDefinitions.GetByType(PerkType);
		return byType != null && Tier >= ((global::System.Collections.Generic.IReadOnlyCollection<GuildPerkTierDefinition>)byType.Tiers).Count;
	}

	public static GuildActivePerk Create(GuildPerkType type, int tier, string activatedByPlayerId)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		return new GuildActivePerk
		{
			PerkType = type,
			Tier = tier,
			ActivatedAt = DateTimeOffset.UtcNow,
			ActivatedByPlayerId = activatedByPlayerId
		};
	}

	public static GuildActivePerk Rehydrate(GuildPerkType type, int tier, DateTimeOffset activatedAt, string activatedByPlayerId)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		return new GuildActivePerk
		{
			PerkType = type,
			Tier = tier,
			ActivatedAt = activatedAt,
			ActivatedByPlayerId = activatedByPlayerId
		};
	}
}
