using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpiritSummoner.Domain.Entities.Quests;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Caching;

namespace SpiritSummoner.Infrastructure.Persistence.Repositories;

public class QuestRepository : IQuestRepository
{
	private readonly IStaticDataCacheService _staticDataCache;

	public QuestRepository(IStaticDataCacheService staticDataCache)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_staticDataCache = staticDataCache ?? throw new ArgumentNullException("staticDataCache");
	}

	public global::System.Threading.Tasks.Task<IReadOnlyDictionary<string, Quest>> GetAllQuestsAsync()
	{
		IReadOnlyDictionary<string, Quest> quests = (IReadOnlyDictionary<string, Quest>)(object)_staticDataCache.Quests;
		return global::System.Threading.Tasks.Task.FromResult<IReadOnlyDictionary<string, Quest>>(quests);
	}

	public global::System.Threading.Tasks.Task<global::System.Collections.Generic.IReadOnlyList<Area>> GetAreasForQuestAsync(string questId)
	{
		List<Area> val = default(List<Area>);
		if (_staticDataCache.AreasByQuest.TryGetValue(questId, ref val))
		{
			global::System.Collections.Generic.IReadOnlyList<Area> readOnlyList = (global::System.Collections.Generic.IReadOnlyList<Area>)val.AsReadOnly();
			return global::System.Threading.Tasks.Task.FromResult<global::System.Collections.Generic.IReadOnlyList<Area>>(readOnlyList);
		}
		global::System.Collections.Generic.IReadOnlyList<Area> readOnlyList2 = (global::System.Collections.Generic.IReadOnlyList<Area>)new List<Area>().AsReadOnly();
		return global::System.Threading.Tasks.Task.FromResult<global::System.Collections.Generic.IReadOnlyList<Area>>(readOnlyList2);
	}

	public global::System.Threading.Tasks.Task<global::System.Collections.Generic.IReadOnlyList<QuestTask>> GetTasksForAreaAsync(string questId, string areaId)
	{
		List<QuestTask> val = default(List<QuestTask>);
		if (_staticDataCache.TasksByArea.TryGetValue(areaId, ref val))
		{
			global::System.Collections.Generic.IReadOnlyList<QuestTask> readOnlyList = (global::System.Collections.Generic.IReadOnlyList<QuestTask>)val.AsReadOnly();
			return global::System.Threading.Tasks.Task.FromResult<global::System.Collections.Generic.IReadOnlyList<QuestTask>>(readOnlyList);
		}
		global::System.Collections.Generic.IReadOnlyList<QuestTask> readOnlyList2 = (global::System.Collections.Generic.IReadOnlyList<QuestTask>)new List<QuestTask>().AsReadOnly();
		return global::System.Threading.Tasks.Task.FromResult<global::System.Collections.Generic.IReadOnlyList<QuestTask>>(readOnlyList2);
	}
}
