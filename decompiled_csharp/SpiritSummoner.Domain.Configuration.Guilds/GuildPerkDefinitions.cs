using System;
using System.Collections.Generic;
using System.Linq;
using SpiritSummoner.Domain.Enums.Guilds;

namespace SpiritSummoner.Domain.Configuration.Guilds;

public static class GuildPerkDefinitions
{
	public static readonly global::System.Collections.Generic.IReadOnlyList<GuildPerkDefinition> All = new GuildPerkDefinition[6]
	{
		new GuildPerkDefinition(GuildPerkType.WarlordBlessing, GuildPerkCategory.General, "Warlord's Blessing", "All guild members earn more EXP from every battle type.", new GuildPerkTierDefinition[3]
		{
			new GuildPerkTierDefinition(300, 0.05, "+5% EXP from all battles"),
			new GuildPerkTierDefinition(600, 0.1, "+10% EXP from all battles"),
			new GuildPerkTierDefinition(1000, 0.15, "+15% EXP from all battles")
		}),
		new GuildPerkDefinition(GuildPerkType.ScoreSurge, GuildPerkCategory.PvP, "Score Surge", "Guild members gain bonus ranking score on PvP victories (1v1 and 3v3).", new GuildPerkTierDefinition[3]
		{
			new GuildPerkTierDefinition(400, 0.03, "+3% score on PvP wins"),
			new GuildPerkTierDefinition(700, 0.05, "+5% score on PvP wins"),
			new GuildPerkTierDefinition(1100, 0.08, "+8% score on PvP wins")
		}),
		new GuildPerkDefinition(GuildPerkType.LossBuffer, GuildPerkCategory.PvP, "Loss Buffer", "Guild members lose less ranking score when defeated in PvP (1v1 and 3v3).", new GuildPerkTierDefinition[3]
		{
			new GuildPerkTierDefinition(400, 0.1, "-10% score lost on PvP defeats"),
			new GuildPerkTierDefinition(700, 0.15, "-15% score lost on PvP defeats"),
			new GuildPerkTierDefinition(1100, 0.2, "-20% score lost on PvP defeats")
		}),
		new GuildPerkDefinition(GuildPerkType.BattleFrenzy, GuildPerkCategory.GuildWar, "Battle Frenzy", "Increases the number of raid attempts each member gets per war hour.", new GuildPerkTierDefinition[3]
		{
			new GuildPerkTierDefinition(200, 1.0, "+1 war raid per hour"),
			new GuildPerkTierDefinition(450, 2.0, "+2 war raids per hour"),
			new GuildPerkTierDefinition(800, 3.0, "+3 war raids per hour")
		}),
		new GuildPerkDefinition(GuildPerkType.SwiftRecovery, GuildPerkCategory.GuildWar, "Swift Recovery", "Reduces the time defenders must wait after being defeated before they can defend again.", new GuildPerkTierDefinition[3]
		{
			new GuildPerkTierDefinition(300, 5.0, "Defender downtime: 30 → 25 min"),
			new GuildPerkTierDefinition(550, 10.0, "Defender downtime: 30 → 20 min"),
			new GuildPerkTierDefinition(900, 15.0, "Defender downtime: 30 → 15 min")
		}),
		new GuildPerkDefinition(GuildPerkType.CrystalShield, GuildPerkCategory.GuildWar, "Crystal Shield", "Reduces the number of crystals the guild loses when a defender is defeated.", new GuildPerkTierDefinition[3]
		{
			new GuildPerkTierDefinition(350, 0.05, "-5% crystals lost on defense"),
			new GuildPerkTierDefinition(650, 0.08, "-8% crystals lost on defense"),
			new GuildPerkTierDefinition(1050, 0.12, "-12% crystals lost on defense")
		})
	};

	public static GuildPerkDefinition? GetByType(GuildPerkType type)
	{
		return Enumerable.FirstOrDefault<GuildPerkDefinition>((global::System.Collections.Generic.IEnumerable<GuildPerkDefinition>)All, (Func<GuildPerkDefinition, bool>)((GuildPerkDefinition d) => d.Type == type));
	}

	public static global::System.Collections.Generic.IEnumerable<GuildPerkDefinition> GetByCategory(GuildPerkCategory category)
	{
		return Enumerable.Where<GuildPerkDefinition>((global::System.Collections.Generic.IEnumerable<GuildPerkDefinition>)All, (Func<GuildPerkDefinition, bool>)((GuildPerkDefinition d) => d.Category == category));
	}
}
