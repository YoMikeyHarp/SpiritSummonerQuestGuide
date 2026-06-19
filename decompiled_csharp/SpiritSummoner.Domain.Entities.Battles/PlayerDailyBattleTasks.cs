using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Domain.Entities.Battles;

public class PlayerDailyBattleTasks
{
	private Dictionary<string, PlayerBattleTaskProgress> _tasks = new Dictionary<string, PlayerBattleTaskProgress>();

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string DateKey
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = string.Empty;


	public IReadOnlyDictionary<string, PlayerBattleTaskProgress> Tasks => (IReadOnlyDictionary<string, PlayerBattleTaskProgress>)(object)_tasks;

	public static string TodayKey
	{
		get
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0005: Unknown result type (might be due to invalid IL or missing references)
			DateTimeOffset utcNow = DateTimeOffset.UtcNow;
			return ((DateTimeOffset)(ref utcNow)).ToString("yyyy-MM-dd");
		}
	}

	public static PlayerDailyBattleTasks CreateNew()
	{
		return new PlayerDailyBattleTasks
		{
			DateKey = TodayKey
		};
	}

	public static PlayerDailyBattleTasks Rehydrate(string dateKey, Dictionary<string, PlayerBattleTaskProgress> tasks)
	{
		return new PlayerDailyBattleTasks
		{
			DateKey = dateKey,
			_tasks = tasks
		};
	}

	internal void IncrementTask(string taskId, int target)
	{
		PlayerBattleTaskProgress playerBattleTaskProgress = default(PlayerBattleTaskProgress);
		if (!_tasks.TryGetValue(taskId, ref playerBattleTaskProgress))
		{
			playerBattleTaskProgress = new PlayerBattleTaskProgress();
			_tasks[taskId] = playerBattleTaskProgress;
		}
		playerBattleTaskProgress.Increment(target);
	}

	internal void ClaimTask(string taskId)
	{
		PlayerBattleTaskProgress playerBattleTaskProgress = default(PlayerBattleTaskProgress);
		if (_tasks.TryGetValue(taskId, ref playerBattleTaskProgress))
		{
			playerBattleTaskProgress.MarkClaimed();
		}
	}
}
