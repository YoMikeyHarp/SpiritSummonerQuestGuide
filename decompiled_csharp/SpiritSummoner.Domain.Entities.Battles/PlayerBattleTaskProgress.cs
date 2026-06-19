using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SpiritSummoner.Domain.Entities.Battles;

public class PlayerBattleTaskProgress
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int CurrentCount
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsRewardClaimed
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	}

	public bool IsCompleted(int target)
	{
		return CurrentCount >= target;
	}

	internal void Increment(int target)
	{
		if (CurrentCount < target)
		{
			CurrentCount++;
		}
	}

	internal void MarkClaimed()
	{
		IsRewardClaimed = true;
	}

	public static PlayerBattleTaskProgress Rehydrate(int count, bool claimed)
	{
		return new PlayerBattleTaskProgress
		{
			CurrentCount = count,
			IsRewardClaimed = claimed
		};
	}
}
