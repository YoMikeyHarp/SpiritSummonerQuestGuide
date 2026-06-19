using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;

namespace SpiritSummoner.Application.DTOs;

public class NewSpiritDTO
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string PlayerSpiritId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string PlayerName
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int BaseSpiritId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string Name
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = string.Empty;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? Nickname
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Level
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int HP
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int TrainingPoints
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int PointsATK
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int PointsDEF
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int PointsSATK
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int PointsSDEF
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int PointsSPD
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int PointsINT
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? HeldItemId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? GearId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string? TalentId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsFavorite
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, ValueTuple<bool, bool>> Moves
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	} = new Dictionary<string, ValueTuple<bool, bool>>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset DateOwned
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		init;
	}

	public static NewSpiritDTO FromPlayerSpirit(PlayerSpirit spirit)
	{
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		ArgumentNullException.ThrowIfNull((object)spirit, "spirit");
		Dictionary<string, ValueTuple<bool, bool>> val = new Dictionary<string, ValueTuple<bool, bool>>();
		if (spirit.Moves != null)
		{
			global::System.Collections.Generic.IEnumerator<KeyValuePair<string, MoveState>> enumerator = ((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, MoveState>>)spirit.Moves).GetEnumerator();
			try
			{
				string text = default(string);
				MoveState moveState = default(MoveState);
				while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
				{
					enumerator.Current.Deconstruct(ref text, ref moveState);
					string text2 = text;
					MoveState moveState2 = moveState;
					val[text2] = new ValueTuple<bool, bool>(moveState2.IsUnlocked, moveState2.IsActiveMove);
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator)?.Dispose();
			}
		}
		return new NewSpiritDTO
		{
			PlayerSpiritId = spirit.PlayerSpiritID,
			BaseSpiritId = spirit.BaseSpiritID,
			Name = (spirit.Name ?? string.Empty),
			Nickname = spirit.Nickname,
			PlayerName = (spirit.PlayerName ?? string.Empty),
			Level = spirit.Level,
			HP = spirit.HP,
			TrainingPoints = spirit.TrainingPoints,
			PointsATK = spirit.PointsATK,
			PointsDEF = spirit.PointsDEF,
			PointsSATK = spirit.PointsSATK,
			PointsSDEF = spirit.PointsSDEF,
			PointsSPD = spirit.PointsSPD,
			PointsINT = spirit.PointsINT,
			HeldItemId = spirit.HeldItemID,
			GearId = spirit.GearID,
			TalentId = spirit.TalentID,
			IsFavorite = spirit.IsFavorite,
			Moves = val,
			DateOwned = spirit.DateOwned
		};
	}
}
