using System;
using System.Collections.Generic;
using System.Linq;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.Interfaces;

namespace SpiritSummoner.Application.Services;

public class UpdatePriorityDeterminer : IUpdatePriorityDeterminer
{
	private const int CriticalCurrencyThreshold = 1000;

	private const int CriticalExperienceThreshold = 1000;

	public bool IsCriticalUpdate(PlayerBatchUpdate update)
	{
		if (Enumerable.Any<KeyValuePair<string, long>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, long>>)update.CurrencyChanges, (Func<KeyValuePair<string, long>, bool>)((KeyValuePair<string, long> c) => Math.Abs(c.Value) > 1000)))
		{
			return true;
		}
		if (update.ExperienceGain > 1000)
		{
			return true;
		}
		if (update.SpiritsToAdd.Count > 0)
		{
			return true;
		}
		if (update.SpiritsToRemove.Count > 0)
		{
			return true;
		}
		if (update.UpdateLevel)
		{
			return true;
		}
		return false;
	}
}
