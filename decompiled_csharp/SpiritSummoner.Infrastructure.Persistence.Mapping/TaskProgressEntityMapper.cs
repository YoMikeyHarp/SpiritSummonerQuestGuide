using System;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Players;

namespace SpiritSummoner.Infrastructure.Persistence.Mapping;

public static class TaskProgressEntityMapper
{
	public static TaskProgress ToEntity(FirestoreTaskProgressDTO firestoreDto)
	{
		ArgumentNullException.ThrowIfNull((object)firestoreDto, "firestoreDto");
		return new TaskProgress
		{
			IsCompleted = firestoreDto.IsCompleted,
			Step = firestoreDto.Step
		};
	}
}
