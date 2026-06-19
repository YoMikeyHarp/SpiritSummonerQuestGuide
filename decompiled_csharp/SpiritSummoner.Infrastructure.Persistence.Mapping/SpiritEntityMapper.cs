using System;
using System.Collections.Generic;
using System.Linq;
using SpiritSummoner.Domain.Entities.Requirements;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Spirits;

namespace SpiritSummoner.Infrastructure.Persistence.Mapping;

public static class SpiritEntityMapper
{
	public static Spirit ToEntity(FirestoreSpiritDTO firestoreDto, Dictionary<string, Move> moves)
	{
		Dictionary<string, Move> moves2 = moves;
		ArgumentNullException.ThrowIfNull((object)firestoreDto, "firestoreDto");
		BaseStats baseStats = ((firestoreDto.BaseStats != null) ? new BaseStats
		{
			ATK = firestoreDto.BaseStats.ATK,
			DEF = firestoreDto.BaseStats.DEF,
			SATK = firestoreDto.BaseStats.SATK,
			SDEF = firestoreDto.BaseStats.SDEF,
			HP = firestoreDto.BaseStats.HP,
			INT = firestoreDto.BaseStats.INT,
			Level = firestoreDto.BaseStats.Level,
			SPD = firestoreDto.BaseStats.SPD
		} : new BaseStats());
		BonusStats bonusAttributes = ((firestoreDto.BonusAttributes != null) ? new BonusStats
		{
			ATK = firestoreDto.BonusAttributes.ATK,
			DEF = firestoreDto.BonusAttributes.DEF,
			SATK = firestoreDto.BonusAttributes.SATK,
			SDEF = firestoreDto.BonusAttributes.SDEF,
			SPD = firestoreDto.BonusAttributes.SPD,
			INT = firestoreDto.BonusAttributes.INT
		} : new BonusStats());
		List<string>? learnableMoveIds = firestoreDto.LearnableMoveIds;
		List<Move> learnableMoves = ((learnableMoveIds != null) ? Enumerable.ToList<Move>(Enumerable.Select<string, Move>(Enumerable.Where<string>((global::System.Collections.Generic.IEnumerable<string>)learnableMoveIds, (Func<string, bool>)((string id) => moves2.ContainsKey(id))), (Func<string, Move>)((string id) => moves2[id]))) : null) ?? new List<Move>();
		RequirementTypes requirements = ((firestoreDto.Requirements != null) ? new RequirementTypes
		{
			LevelRequirement = new LevelRequirement
			{
				EvolveLevelRequired = ((firestoreDto.Requirements.LevelRequirement != null) ? firestoreDto.Requirements.LevelRequirement.EvolveLevelRequired : 0),
				PlayerLevelRequired = ((firestoreDto.Requirements.LevelRequirement != null) ? firestoreDto.Requirements.LevelRequirement.PlayerLevelRequired : 0),
				GuildRankRequired = ((firestoreDto.Requirements.LevelRequirement != null) ? firestoreDto.Requirements.LevelRequirement.GuildRankRequired : 0)
			},
			CurrencyCost = new CurrencyCostRequirement
			{
				Amount = ((firestoreDto.Requirements.CurrencyCost != null) ? firestoreDto.Requirements.CurrencyCost.Amount : 0),
				Type = ((firestoreDto.Requirements.CurrencyCost != null) ? firestoreDto.Requirements.CurrencyCost.Type : string.Empty)
			},
			ItemRequirement = new ItemRequirement
			{
				Amount = ((firestoreDto.Requirements.ItemRequirement != null) ? firestoreDto.Requirements.ItemRequirement.Amount : 0),
				ItemType = ((firestoreDto.Requirements.ItemRequirement != null) ? firestoreDto.Requirements.ItemRequirement.ItemType : string.Empty)
			},
			EvolveRequirements = new EvolveRequirement
			{
				LevelRequired = ((firestoreDto.Requirements.EvolveRequirements != null) ? firestoreDto.Requirements.EvolveRequirements.LevelRequired : 0),
				ItemRequired = ((firestoreDto.Requirements.EvolveRequirements != null) ? firestoreDto.Requirements.EvolveRequirements.ItemRequired : string.Empty),
				Amount = ((firestoreDto.Requirements.EvolveRequirements != null) ? firestoreDto.Requirements.EvolveRequirements.Amount : 0),
				CoresRequired = (firestoreDto.Requirements.EvolveRequirements?.CoresRequired ?? 10)
			}
		} : null);
		return Spirit.Rehydrate(firestoreDto.ID ?? string.Empty, firestoreDto.Name ?? string.Empty, firestoreDto.Type1, firestoreDto.Type2, firestoreDto.Category, firestoreDto.Category2, baseStats, bonusAttributes, learnableMoves, firestoreDto.Image ?? "stop.png", requirements, firestoreDto.Evolution, firestoreDto.PreEvolution, (firestoreDto.BaseMoveCount > 0) ? firestoreDto.BaseMoveCount : 2, firestoreDto.IsUnique);
	}

	public static List<Spirit> ToEntities(global::System.Collections.Generic.IEnumerable<FirestoreSpiritDTO> firestoreDtos, Dictionary<string, Move> moves)
	{
		Dictionary<string, Move> moves2 = moves;
		return ((firestoreDtos != null) ? Enumerable.ToList<Spirit>(Enumerable.Select<FirestoreSpiritDTO, Spirit>(firestoreDtos, (Func<FirestoreSpiritDTO, Spirit>)((FirestoreSpiritDTO dto) => ToEntity(dto, moves2)))) : null) ?? new List<Spirit>();
	}

	public static Dictionary<string, Spirit> ToEntityDictionary(Dictionary<string, FirestoreSpiritDTO> firestoreDtos, Dictionary<string, Move> moves)
	{
		Dictionary<string, Move> moves2 = moves;
		return ((firestoreDtos != null) ? Enumerable.ToDictionary<KeyValuePair<string, FirestoreSpiritDTO>, string, Spirit>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreSpiritDTO>>)firestoreDtos, (Func<KeyValuePair<string, FirestoreSpiritDTO>, string>)((KeyValuePair<string, FirestoreSpiritDTO> kvp) => kvp.Key), (Func<KeyValuePair<string, FirestoreSpiritDTO>, Spirit>)((KeyValuePair<string, FirestoreSpiritDTO> kvp) => ToEntity(kvp.Value, moves2))) : null) ?? new Dictionary<string, Spirit>();
	}
}
