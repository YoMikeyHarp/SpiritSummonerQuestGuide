using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Enums.Items;

namespace SpiritSummoner.Domain.Entities.Players;

public class PlayerSpirit
{
	private string? playerSpiritID;

	private Dictionary<string, MoveState>? _moves;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? PlayerName
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Name
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Nickname
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset DateOwned
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int BaseSpiritID
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Level
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int HP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int TrainingPoints
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int PointsATK
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int PointsDEF
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int PointsSATK
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int PointsSDEF
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int PointsSPD
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int PointsINT
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	public IReadOnlyDictionary<string, MoveState>? Moves => (IReadOnlyDictionary<string, MoveState>?)(object)_moves;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsFavorite
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = false;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? HeldItemID
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? GearID
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? TalentID
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	public bool HasGear => !string.IsNullOrEmpty(GearID);

	public bool HasTalent => !string.IsNullOrEmpty(TalentID);

	public string PlayerSpiritID
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			string text = playerSpiritID;
			if (text == null)
			{
				Guid val = Guid.NewGuid();
				text = ((object)(Guid)(ref val)).ToString();
			}
			return text;
		}
		private set
		{
			playerSpiritID = value;
		}
	}

	public PlayerSpirit()
	{
	}

	public static PlayerSpirit Rehydrate(string? playerSpiritId, string? playerName, string? name, string? nickname, DateTimeOffset? dateOwned, int? baseSpiritId, int? level, int? hp, int? trainingPoints, int? pointsAtk, int? pointsDef, int? pointsSatk, int? pointsSdef, int? pointsSpd, int? pointsInt, Dictionary<string, MoveState>? moves, bool? isFavorite, string? heldItemId, string? gearId, string? talentId)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		PlayerSpirit playerSpirit = new PlayerSpirit();
		if (playerSpiritId != null)
		{
			playerSpirit.PlayerSpiritID = playerSpiritId;
		}
		playerSpirit.PlayerName = playerName;
		playerSpirit.Name = name;
		playerSpirit.Nickname = nickname;
		if (dateOwned.HasValue)
		{
			playerSpirit.DateOwned = dateOwned.Value;
		}
		if (baseSpiritId.HasValue)
		{
			playerSpirit.BaseSpiritID = baseSpiritId.Value;
		}
		if (level.HasValue)
		{
			playerSpirit.Level = level.Value;
		}
		if (hp.HasValue)
		{
			playerSpirit.HP = hp.Value;
		}
		if (trainingPoints.HasValue)
		{
			playerSpirit.TrainingPoints = trainingPoints.Value;
		}
		if (pointsAtk.HasValue)
		{
			playerSpirit.PointsATK = pointsAtk.Value;
		}
		if (pointsDef.HasValue)
		{
			playerSpirit.PointsDEF = pointsDef.Value;
		}
		if (pointsSatk.HasValue)
		{
			playerSpirit.PointsSATK = pointsSatk.Value;
		}
		if (pointsSdef.HasValue)
		{
			playerSpirit.PointsSDEF = pointsSdef.Value;
		}
		if (pointsSpd.HasValue)
		{
			playerSpirit.PointsSPD = pointsSpd.Value;
		}
		if (pointsInt.HasValue)
		{
			playerSpirit.PointsINT = pointsInt.Value;
		}
		if (moves != null)
		{
			playerSpirit._moves = new Dictionary<string, MoveState>((IDictionary<string, MoveState>)(object)moves);
		}
		if (isFavorite.HasValue)
		{
			playerSpirit.IsFavorite = isFavorite.Value;
		}
		playerSpirit.HeldItemID = heldItemId;
		playerSpirit.GearID = gearId;
		playerSpirit.TalentID = talentId;
		return playerSpirit;
	}

	public PlayerSpirit(PlayerSpirit originalSpirit)
	{
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		playerSpiritID = originalSpirit.PlayerSpiritID;
		PlayerName = originalSpirit.PlayerName;
		Name = originalSpirit.Name;
		Nickname = originalSpirit.Nickname;
		HP = originalSpirit.HP;
		Level = originalSpirit.Level;
		BaseSpiritID = originalSpirit.BaseSpiritID;
		PointsATK = originalSpirit.PointsATK;
		PointsDEF = originalSpirit.PointsDEF;
		PointsSATK = originalSpirit.PointsSATK;
		PointsSDEF = originalSpirit.PointsSDEF;
		PointsSPD = originalSpirit.PointsSPD;
		PointsINT = originalSpirit.PointsINT;
		TrainingPoints = originalSpirit.TrainingPoints;
		IReadOnlyDictionary<string, MoveState>? moves = originalSpirit.Moves;
		_moves = ((moves != null) ? Enumerable.ToDictionary<KeyValuePair<string, MoveState>, string, MoveState>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, MoveState>>)moves, (Func<KeyValuePair<string, MoveState>, string>)((KeyValuePair<string, MoveState> kv) => kv.Key), (Func<KeyValuePair<string, MoveState>, MoveState>)((KeyValuePair<string, MoveState> kv) => new MoveState(kv.Value))) : null);
		DateOwned = originalSpirit.DateOwned;
		IsFavorite = originalSpirit.IsFavorite;
		HeldItemID = originalSpirit.HeldItemID;
		GearID = originalSpirit.GearID;
		TalentID = originalSpirit.TalentID;
	}

	internal static PlayerSpirit QuestSpirit(Spirit baseQuestSpirit, int level, global::System.Collections.Generic.IReadOnlyList<Move> questSpiritMoves, string opponentName)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		int num = baseQuestSpirit.BaseStats?.HP ?? 100;
		PlayerSpirit obj = new PlayerSpirit
		{
			Name = baseQuestSpirit.Name,
			HP = (int)Math.Round((double)num * Math.Pow(1.045, (double)(level - 1))),
			Level = level
		};
		Guid val = Guid.NewGuid();
		obj.PlayerSpiritID = ((object)(Guid)(ref val)).ToString();
		obj.PlayerName = opponentName;
		obj.BaseSpiritID = Convert.ToInt32(baseQuestSpirit.ID);
		obj._moves = Enumerable.ToDictionary<Move, string, MoveState>((global::System.Collections.Generic.IEnumerable<Move>)questSpiritMoves, (Func<Move, string>)((Move kv) => kv.Name ?? string.Empty), (Func<Move, MoveState>)((Move kv) => new MoveState(isActive: true, isUnlocked: true)));
		return obj;
	}

	internal void SetLevel(int level)
	{
		Level = level;
	}

	internal void SetHP(int hp)
	{
		HP = Math.Max(0, hp);
	}

	internal void SetTrainingPoints(int points)
	{
		TrainingPoints = Math.Max(0, points);
	}

	internal void AddTrainingPoints(int points)
	{
		TrainingPoints = Math.Max(0, TrainingPoints + points);
	}

	internal void SetStatPoints(int atk, int def, int satk, int sdef, int spd, int intel)
	{
		PointsATK = Math.Max(0, atk);
		PointsDEF = Math.Max(0, def);
		PointsSATK = Math.Max(0, satk);
		PointsSDEF = Math.Max(0, sdef);
		PointsSPD = Math.Max(0, spd);
		PointsINT = Math.Max(0, intel);
	}

	internal void AddStatPoints(int atk = 0, int def = 0, int satk = 0, int sdef = 0, int spd = 0, int intel = 0)
	{
		PointsATK += atk;
		PointsDEF += def;
		PointsSATK += satk;
		PointsSDEF += sdef;
		PointsSPD += spd;
		PointsINT += intel;
	}

	internal void SetNickname(string? nickname)
	{
		Nickname = nickname;
	}

	internal void SetFavorite(bool isFavorite)
	{
		IsFavorite = isFavorite;
	}

	internal void EquipHeldItem(string? itemId)
	{
		HeldItemID = itemId;
	}

	internal void EquipGear(string? gearId)
	{
		GearID = gearId;
	}

	internal void EquipTalent(string? talentId)
	{
		TalentID = talentId;
	}

	internal void UnlockMove(string moveName)
	{
		if (_moves == null)
		{
			_moves = new Dictionary<string, MoveState>();
		}
		if (!_moves.ContainsKey(moveName))
		{
			_moves[moveName] = new MoveState();
		}
		_moves[moveName].IsUnlocked = true;
	}

	internal void SetActiveMove(string moveName, bool isActive)
	{
		if (_moves != null && _moves.ContainsKey(moveName))
		{
			_moves[moveName].IsActiveMove = isActive;
		}
	}

	internal void DeactivateAllMoves()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (_moves == null)
		{
			return;
		}
		Enumerator<string, MoveState> enumerator = _moves.Values.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				MoveState current = enumerator.Current;
				current.IsActiveMove = false;
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator).Dispose();
		}
	}

	internal void SetPlayerSpiritID(string? id)
	{
		playerSpiritID = id;
	}

	internal void SetPlayerName(string? playerName)
	{
		PlayerName = playerName;
	}

	internal void SetName(string? name)
	{
		Name = name;
	}

	internal void SetBaseSpiritID(int baseSpiritId)
	{
		BaseSpiritID = baseSpiritId;
	}

	internal void SetDateOwned(global::System.DateTime dateOwned)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		DateOwned = DateTimeOffset.op_Implicit(dateOwned);
	}

	internal void SetMoves(Dictionary<string, MoveState>? moves)
	{
		_moves = moves;
	}

	internal void EvolveTo(Spirit evolvedTemplate, int hpGain)
	{
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		ArgumentNullException.ThrowIfNull((object)evolvedTemplate, "evolvedTemplate");
		if (Nickname == Name)
		{
			Nickname = evolvedTemplate.Name;
		}
		Name = evolvedTemplate.Name ?? Name;
		int baseSpiritID = default(int);
		if (int.TryParse(evolvedTemplate.ID, ref baseSpiritID))
		{
			BaseSpiritID = baseSpiritID;
		}
		HP = Math.Max(0, HP + hpGain);
		HashSet<string> val = new HashSet<string>(Enumerable.Where<string>(Enumerable.Select<Move, string>((global::System.Collections.Generic.IEnumerable<Move>)(evolvedTemplate.LearnableMoves ?? new List<Move>()), (Func<Move, string>)((Move m) => m.Name ?? string.Empty)), (Func<string, bool>)((string n) => !string.IsNullOrEmpty(n))));
		global::System.Collections.Generic.IReadOnlyList<string> baseMoveNames = evolvedTemplate.GetBaseMoveNames();
		Dictionary<string, MoveState> val2 = new Dictionary<string, MoveState>();
		if (_moves != null)
		{
			Enumerator<string, MoveState> enumerator = _moves.GetEnumerator();
			try
			{
				string text = default(string);
				MoveState moveState = default(MoveState);
				while (enumerator.MoveNext())
				{
					enumerator.Current.Deconstruct(ref text, ref moveState);
					string text2 = text;
					MoveState moveState2 = moveState;
					if (moveState2.IsUnlocked || val.Contains(text2))
					{
						val2[text2] = new MoveState(moveState2.IsActiveMove, moveState2.IsUnlocked);
					}
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator).Dispose();
			}
		}
		Enumerator<string> enumerator2 = val.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				string current = enumerator2.Current;
				if (!val2.ContainsKey(current))
				{
					val2[current] = new MoveState(isActive: false, isUnlocked: false);
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator2).Dispose();
		}
		global::System.Collections.Generic.IEnumerator<string> enumerator3 = ((global::System.Collections.Generic.IEnumerable<string>)baseMoveNames).GetEnumerator();
		try
		{
			MoveState moveState3 = default(MoveState);
			while (((global::System.Collections.IEnumerator)enumerator3).MoveNext())
			{
				string current2 = enumerator3.Current;
				if (val2.TryGetValue(current2, ref moveState3))
				{
					moveState3.IsUnlocked = true;
					moveState3.IsActiveMove = true;
				}
				else
				{
					val2[current2] = new MoveState(isActive: true, isUnlocked: true);
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator3)?.Dispose();
		}
		_moves = val2;
	}

	public string? GetEquippedItemId(object itemType)
	{
		if (1 == 0)
		{
		}
		if (!(itemType is ItemType))
		{
			goto IL_004d;
		}
		switch ((ItemType)itemType)
		{
		case ItemType.booster:
			break;
		case ItemType.gear:
			goto IL_003b;
		case ItemType.talent:
			goto IL_0044;
		default:
			goto IL_004d;
		}
		string result = HeldItemID;
		goto IL_0055;
		IL_0044:
		result = TalentID;
		goto IL_0055;
		IL_004d:
		result = string.Empty;
		goto IL_0055;
		IL_0055:
		if (1 == 0)
		{
		}
		return result;
		IL_003b:
		result = GearID;
		goto IL_0055;
	}
}
