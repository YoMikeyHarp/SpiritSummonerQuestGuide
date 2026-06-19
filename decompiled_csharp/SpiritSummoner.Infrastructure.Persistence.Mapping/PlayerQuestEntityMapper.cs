using System;
using System.Collections.Generic;
using System.Linq;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Players;

namespace SpiritSummoner.Infrastructure.Persistence.Mapping;

public static class PlayerQuestEntityMapper
{
	public static PlayerQuest ToEntity(FirestorePlayerQuestsDTO firestoreDto)
	{
		ArgumentNullException.ThrowIfNull((object)firestoreDto, "firestoreDto");
		Dictionary<string, FirestoreTaskProgressDTO> tasks = firestoreDto.Tasks;
		Dictionary<string, TaskProgress> tasks2 = ((tasks != null) ? Enumerable.ToDictionary<KeyValuePair<string, FirestoreTaskProgressDTO>, string, TaskProgress>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, FirestoreTaskProgressDTO>>)tasks, (Func<KeyValuePair<string, FirestoreTaskProgressDTO>, string>)((KeyValuePair<string, FirestoreTaskProgressDTO> kvp) => kvp.Key), (Func<KeyValuePair<string, FirestoreTaskProgressDTO>, TaskProgress>)((KeyValuePair<string, FirestoreTaskProgressDTO> kvp) => TaskProgressEntityMapper.ToEntity(kvp.Value))) : null) ?? new Dictionary<string, TaskProgress>();
		return new PlayerQuest
		{
			QuestId = firestoreDto.QuestId,
			Tasks = tasks2
		};
	}
}
