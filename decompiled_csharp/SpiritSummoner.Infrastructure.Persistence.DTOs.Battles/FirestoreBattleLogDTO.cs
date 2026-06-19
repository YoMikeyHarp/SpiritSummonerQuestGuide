using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Plugin.Firebase.Firestore;
using SpiritSummoner.Domain.Entities.Battles;

namespace SpiritSummoner.Infrastructure.Persistence.DTOs.Battles;

public sealed class FirestoreBattleLogDTO : IFirestoreObject
{
	[FirestoreProperty("playerId")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string PlayerId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[FirestoreProperty("opponentPlayerId")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string OpponentPlayerId
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[FirestoreProperty("battleMode")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string BattleMode
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	[FirestoreProperty("victory")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool Victory
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("playerLevel")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int PlayerLevel
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("enemyLevel")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int EnemyLevel
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("livingSpiritsCount")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int LivingSpiritsCount
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("totalHealthPercentage")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public double TotalHealthPercentage
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("scoreChange")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int ScoreChange
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("createdAt")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset CreatedAt
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[FirestoreProperty("lines")]
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public List<string> Lines
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<string>();


	public static FirestoreBattleLogDTO FromEntity(BattleLog entity)
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		return new FirestoreBattleLogDTO
		{
			PlayerId = entity.PlayerId,
			OpponentPlayerId = entity.OpponentPlayerId,
			BattleMode = entity.BattleMode,
			Victory = entity.Victory,
			PlayerLevel = entity.PlayerLevel,
			EnemyLevel = entity.EnemyLevel,
			LivingSpiritsCount = entity.LivingSpiritsCount,
			TotalHealthPercentage = entity.TotalHealthPercentage,
			ScoreChange = entity.ScoreChange,
			CreatedAt = entity.CreatedAt,
			Lines = Enumerable.ToList<string>((global::System.Collections.Generic.IEnumerable<string>)entity.Lines)
		};
	}
}
