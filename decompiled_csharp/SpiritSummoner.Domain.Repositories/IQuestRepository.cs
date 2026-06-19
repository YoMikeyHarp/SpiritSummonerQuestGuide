using System.Collections.Generic;
using System.Threading.Tasks;
using SpiritSummoner.Domain.Entities.Quests;

namespace SpiritSummoner.Domain.Repositories;

public interface IQuestRepository
{
	global::System.Threading.Tasks.Task<IReadOnlyDictionary<string, Quest>> GetAllQuestsAsync();

	global::System.Threading.Tasks.Task<global::System.Collections.Generic.IReadOnlyList<Area>> GetAreasForQuestAsync(string questId);

	global::System.Threading.Tasks.Task<global::System.Collections.Generic.IReadOnlyList<QuestTask>> GetTasksForAreaAsync(string questId, string areaId);
}
