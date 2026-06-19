using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using SpiritSummoner.Domain.Entities.Requirements;
using SpiritSummoner.Domain.Enums.Spirits;

namespace SpiritSummoner.Domain.Entities.Spirits;

public class Spirit
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? ID
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Name
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Level
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public SpiritType Type1
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public SpiritType Type2
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public BaseStats? BaseStats
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<Move>? LearnableMoves
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int TrainingPoints
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Image
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public BonusStats BonusAttributes
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new BonusStats();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public RequirementTypes? Requirements
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Evolution
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int PreEvolution
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = 0;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Category
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Category2
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int BaseMoveCount
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = 2;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsUnique
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = false;


	public global::System.Collections.Generic.IReadOnlyList<string> GetBaseMoveNames()
	{
		if (LearnableMoves == null || LearnableMoves.Count == 0)
		{
			return global::System.Array.Empty<string>();
		}
		return (global::System.Collections.Generic.IReadOnlyList<string>)Enumerable.ToList<string>(Enumerable.Where<string>(Enumerable.Select<Move, string>(Enumerable.Take<Move>((global::System.Collections.Generic.IEnumerable<Move>)Enumerable.OrderBy<Move, int>((global::System.Collections.Generic.IEnumerable<Move>)LearnableMoves, (Func<Move, int>)((Move m) => m.Power)), BaseMoveCount), (Func<Move, string>)((Move m) => m.Name ?? string.Empty)), (Func<string, bool>)((string n) => !string.IsNullOrEmpty(n))));
	}

	public bool IsBaseMove(string? moveName)
	{
		if (string.IsNullOrEmpty(moveName))
		{
			return false;
		}
		return Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)GetBaseMoveNames(), moveName);
	}

	public Spirit()
	{
	}

	public Spirit(Spirit original)
	{
		ID = original.ID;
		Name = original.Name;
		Level = original.Level;
		Type1 = original.Type1;
		Type2 = original.Type2;
		Category = original.Category;
		Category2 = original.Category2;
		BaseStats = original.BaseStats;
		LearnableMoves = original.LearnableMoves;
		TrainingPoints = original.TrainingPoints;
		Image = original.Image;
		Evolution = original.Evolution;
		PreEvolution = original.PreEvolution;
		BonusAttributes = original.BonusAttributes;
		Requirements = original.Requirements;
		BaseMoveCount = original.BaseMoveCount;
		IsUnique = original.IsUnique;
	}

	public static Spirit Rehydrate(string id, string name, SpiritType type1, SpiritType type2, string? category, string? category2, BaseStats baseStats, BonusStats bonusAttributes, List<Move> learnableMoves, string image, RequirementTypes? requirements, int evolution, int preEvolution = 0, int baseMoveCount = 2, bool isUnique = false)
	{
		return new Spirit
		{
			ID = id,
			Name = name,
			Type1 = type1,
			Type2 = type2,
			Category = category,
			Category2 = category2,
			BaseStats = baseStats,
			BonusAttributes = bonusAttributes,
			LearnableMoves = learnableMoves,
			Image = image,
			Requirements = requirements,
			Evolution = evolution,
			PreEvolution = preEvolution,
			BaseMoveCount = baseMoveCount,
			IsUnique = isUnique,
			Level = 1,
			TrainingPoints = 0
		};
	}
}
