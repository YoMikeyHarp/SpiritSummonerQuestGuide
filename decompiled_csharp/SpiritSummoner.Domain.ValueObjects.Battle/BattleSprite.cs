using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;

namespace SpiritSummoner.Domain.ValueObjects.Battle;

public class BattleSprite
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Spirit BaseSpirit
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public PlayerSpirit PlayerSpirit
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsPlayer
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, Item?> Equipments
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, Item>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int HP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int MaxHP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int ATK
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int DEF
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int SATK
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int SDEF
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int SPD
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int INT
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsStunned
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool HasTriggeredEntry
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public BattleSprite(Spirit baseSpirit, PlayerSpirit playerSpirit, bool isPlayer = false)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		BaseSpirit = baseSpirit ?? throw new ArgumentNullException("baseSpirit");
		PlayerSpirit = playerSpirit ?? throw new ArgumentNullException("playerSpirit");
		IsPlayer = isPlayer;
		MaxHP = playerSpirit.HP;
		HP = playerSpirit.HP;
		ATK = CalculateBaseStat(baseSpirit.BaseStats?.ATK ?? 0, playerSpirit.PointsATK, baseSpirit.BonusAttributes.ATK);
		DEF = CalculateBaseStat(baseSpirit.BaseStats?.DEF ?? 0, playerSpirit.PointsDEF, baseSpirit.BonusAttributes.DEF);
		SATK = CalculateBaseStat(baseSpirit.BaseStats?.SATK ?? 0, playerSpirit.PointsSATK, baseSpirit.BonusAttributes.SATK);
		SDEF = CalculateBaseStat(baseSpirit.BaseStats?.SDEF ?? 0, playerSpirit.PointsSDEF, baseSpirit.BonusAttributes.SDEF);
		SPD = CalculateBaseStat(baseSpirit.BaseStats?.SPD ?? 0, playerSpirit.PointsSPD, baseSpirit.BonusAttributes.SPD);
		INT = CalculateBaseStat(baseSpirit.BaseStats?.INT ?? 0, playerSpirit.PointsINT, baseSpirit.BonusAttributes.INT);
		string text = (IsPlayer ? "[P]" : "[E]");
		Debug.WriteLine($"[BattleStats] ══ {text}{baseSpirit.Name} ({playerSpirit.PlayerSpiritID}) ══ HP={MaxHP}");
		Debug.WriteLine($"[BattleStats]   Base+Pts×Bonus │ ATK={ATK}({baseSpirit.BaseStats?.ATK}+{playerSpirit.PointsATK}pts×{baseSpirit.BonusAttributes.ATK:F2}) DEF={DEF}({baseSpirit.BaseStats?.DEF}+{playerSpirit.PointsDEF}pts×{baseSpirit.BonusAttributes.DEF:F2}) MGK={SATK}({baseSpirit.BaseStats?.SATK}+{playerSpirit.PointsSATK}pts×{baseSpirit.BonusAttributes.SATK:F2})");
		Debug.WriteLine($"[BattleStats]                  │ MDF={SDEF}({baseSpirit.BaseStats?.SDEF}+{playerSpirit.PointsSDEF}pts×{baseSpirit.BonusAttributes.SDEF:F2}) SPD={SPD}({baseSpirit.BaseStats?.SPD}+{playerSpirit.PointsSPD}pts×{baseSpirit.BonusAttributes.SPD:F2}) INT={INT}({baseSpirit.BaseStats?.INT}+{playerSpirit.PointsINT}pts×{baseSpirit.BonusAttributes.INT:F2})");
	}

	private int CalculateBaseStat(int baseStat, int trainingPoints, double bonus)
	{
		return Convert.ToInt32((double)(baseStat + trainingPoints) * bonus);
	}

	public void UpdateStats(int maxHP, int atk, int def, int satk, int sdef, int spd, int intelligence)
	{
		Debug.WriteLine($"[BattleStats]   After Equipment │ HP:{HP}→{maxHP} ATK:{ATK}→{atk} DEF:{DEF}→{def} MGK:{SATK}→{satk} MDF:{SDEF}→{sdef} SPD:{SPD}→{spd} INT:{INT}→{intelligence}");
		if (HP >= MaxHP)
		{
			HP = maxHP;
		}
		else
		{
			HP = Math.Min(HP, maxHP);
		}
		MaxHP = maxHP;
		ATK = atk;
		DEF = def;
		SATK = satk;
		SDEF = sdef;
		SPD = spd;
		INT = intelligence;
	}

	public void SetEquipments(Item? gear, Item? talent, Item? heldItem)
	{
		Equipments.Clear();
		if (gear != null)
		{
			Equipments["gear"] = gear;
		}
		if (talent != null)
		{
			Equipments["talent"] = talent;
		}
		if (heldItem != null)
		{
			Equipments["heldItem"] = heldItem;
		}
	}
}
