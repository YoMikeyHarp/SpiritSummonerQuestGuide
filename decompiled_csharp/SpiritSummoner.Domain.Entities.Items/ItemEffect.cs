using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Domain.Entities.Items;

public class ItemEffect
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, float>? FlatStatChanges
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, double>? StatMultipliers
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public float DamageMultiplier
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = 1f;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, float>? TypeDamageMultipliers
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, float>? ElementalResistances
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public float CritRateBonus
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public float CritDamageBonus
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public float AccuracyBonus
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public float EvasionBonus
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public float HealPerTurn
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public float DamagePerTurn
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public float RecoilDamage
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public SquadSynergyEffect? SquadSynergy
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public HPThresholdEffect? HpThresholdEffect
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool LocksMove
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool PreventsStatus
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<string>? GrantsImmunity
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int PriorityBonus
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<string>? UnlockedMoves
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<string>? SpecialAbilities
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool CanStack
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = true;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? StackingGroup
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int MaxStackCount
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = 0;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<string>? ClassRestrictions
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<string>? TypeRestrictions
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? CustomDescription
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public static ItemEffect Rehydrate(Dictionary<string, float>? flatStatChanges, Dictionary<string, double>? statMultipliers, float? damageMultiplier, Dictionary<string, float>? typeDamageMultipliers, Dictionary<string, float>? elementalResistances, float? critRateBonus, float? critDamageBonus, float? accuracyBonus, float? evasionBonus, float? healPerTurn, float? damagePerTurn, float? recoilDamage, SquadSynergyEffect? squadSynergy, HPThresholdEffect? hpThresholdEffect, bool? locksMove, bool? preventsStatus, List<string>? grantsImmunity, int? priorityBonus, List<string>? unlockedMoves, List<string>? specialAbilities, bool? canStack, string? stackingGroup, int? maxStackCount, List<string>? classRestrictions, List<string>? typeRestrictions, string? customDescription)
	{
		ItemEffect itemEffect = new ItemEffect();
		if (flatStatChanges != null)
		{
			itemEffect.FlatStatChanges = new Dictionary<string, float>((IDictionary<string, float>)(object)flatStatChanges);
		}
		if (statMultipliers != null)
		{
			itemEffect.StatMultipliers = new Dictionary<string, double>((IDictionary<string, double>)(object)statMultipliers);
		}
		if (damageMultiplier.HasValue)
		{
			itemEffect.DamageMultiplier = damageMultiplier.Value;
		}
		if (typeDamageMultipliers != null)
		{
			itemEffect.TypeDamageMultipliers = new Dictionary<string, float>((IDictionary<string, float>)(object)typeDamageMultipliers);
		}
		if (elementalResistances != null)
		{
			itemEffect.ElementalResistances = new Dictionary<string, float>((IDictionary<string, float>)(object)elementalResistances);
		}
		if (critRateBonus.HasValue)
		{
			itemEffect.CritRateBonus = critRateBonus.Value;
		}
		if (critDamageBonus.HasValue)
		{
			itemEffect.CritDamageBonus = critDamageBonus.Value;
		}
		if (accuracyBonus.HasValue)
		{
			itemEffect.AccuracyBonus = accuracyBonus.Value;
		}
		if (evasionBonus.HasValue)
		{
			itemEffect.EvasionBonus = evasionBonus.Value;
		}
		if (healPerTurn.HasValue)
		{
			itemEffect.HealPerTurn = healPerTurn.Value;
		}
		if (damagePerTurn.HasValue)
		{
			itemEffect.DamagePerTurn = damagePerTurn.Value;
		}
		if (recoilDamage.HasValue)
		{
			itemEffect.RecoilDamage = recoilDamage.Value;
		}
		if (squadSynergy != null)
		{
			itemEffect.SquadSynergy = squadSynergy;
		}
		if (hpThresholdEffect != null)
		{
			itemEffect.HpThresholdEffect = hpThresholdEffect;
		}
		if (locksMove.HasValue)
		{
			itemEffect.LocksMove = locksMove.Value;
		}
		if (preventsStatus.HasValue)
		{
			itemEffect.PreventsStatus = preventsStatus.Value;
		}
		if (grantsImmunity != null)
		{
			itemEffect.GrantsImmunity = new List<string>((global::System.Collections.Generic.IEnumerable<string>)grantsImmunity);
		}
		if (priorityBonus.HasValue)
		{
			itemEffect.PriorityBonus = priorityBonus.Value;
		}
		if (unlockedMoves != null)
		{
			itemEffect.UnlockedMoves = new List<string>((global::System.Collections.Generic.IEnumerable<string>)unlockedMoves);
		}
		if (specialAbilities != null)
		{
			itemEffect.SpecialAbilities = new List<string>((global::System.Collections.Generic.IEnumerable<string>)specialAbilities);
		}
		if (canStack.HasValue)
		{
			itemEffect.CanStack = canStack.Value;
		}
		if (stackingGroup != null)
		{
			itemEffect.StackingGroup = stackingGroup;
		}
		if (maxStackCount.HasValue)
		{
			itemEffect.MaxStackCount = maxStackCount.Value;
		}
		if (classRestrictions != null)
		{
			itemEffect.ClassRestrictions = new List<string>((global::System.Collections.Generic.IEnumerable<string>)classRestrictions);
		}
		if (typeRestrictions != null)
		{
			itemEffect.TypeRestrictions = new List<string>((global::System.Collections.Generic.IEnumerable<string>)typeRestrictions);
		}
		if (customDescription != null)
		{
			itemEffect.CustomDescription = customDescription;
		}
		return itemEffect;
	}
}
