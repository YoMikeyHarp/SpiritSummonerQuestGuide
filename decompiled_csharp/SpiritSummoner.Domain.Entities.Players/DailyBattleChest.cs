using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Domain.Entities.Players;

public class DailyBattleChest
{
	public const int FillTarget = 5;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int BattlesCompleted
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset? LastClaimedAt
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public DateTimeOffset LastResetAt
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = TodayMidnightUtc();


	public bool IsStale
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			DateTimeOffset val = LastResetAt;
			global::System.DateTime date = ((DateTimeOffset)(ref val)).Date;
			val = DateTimeOffset.UtcNow;
			return date < ((DateTimeOffset)(ref val)).Date;
		}
	}

	public int EffectiveBattlesCompleted => (!IsStale) ? BattlesCompleted : 0;

	public double FillProgress => Math.Min(1.0, (double)EffectiveBattlesCompleted / 5.0);

	public bool IsChestFull => EffectiveBattlesCompleted >= 5;

	public bool IsClaimed
	{
		get
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			int result;
			if (!IsStale && LastClaimedAt.HasValue)
			{
				DateTimeOffset val = LastClaimedAt.Value;
				global::System.DateTime date = ((DateTimeOffset)(ref val)).Date;
				val = DateTimeOffset.UtcNow;
				result = ((date == ((DateTimeOffset)(ref val)).Date) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}
	}

	public bool IsClaimable => IsChestFull && !IsClaimed;

	private static DateTimeOffset TodayMidnightUtc()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		DateTimeOffset utcNow = DateTimeOffset.UtcNow;
		return new DateTimeOffset(((DateTimeOffset)(ref utcNow)).Date, TimeSpan.Zero);
	}

	public static DailyBattleChest Rehydrate(int battlesCompleted, DateTimeOffset? lastClaimedAt, DateTimeOffset lastResetAt)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		return new DailyBattleChest
		{
			BattlesCompleted = battlesCompleted,
			LastClaimedAt = lastClaimedAt,
			LastResetAt = lastResetAt
		};
	}

	internal int IncrementBattles()
	{
		ResetIfStale();
		BattlesCompleted = Math.Min(BattlesCompleted + 1, 5);
		return BattlesCompleted;
	}

	internal void MarkClaimed()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		LastClaimedAt = DateTimeOffset.UtcNow;
	}

	private void ResetIfStale()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		if (IsStale)
		{
			BattlesCompleted = 0;
			LastClaimedAt = null;
			LastResetAt = TodayMidnightUtc();
		}
	}
}
