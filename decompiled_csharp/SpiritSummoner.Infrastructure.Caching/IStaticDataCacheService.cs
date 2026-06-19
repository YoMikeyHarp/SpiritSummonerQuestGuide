using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Entities.Quests;
using SpiritSummoner.Domain.Entities.Spirits;

namespace SpiritSummoner.Infrastructure.Caching;

public interface IStaticDataCacheService
{
	Dictionary<string, Item> Items { get; }

	Dictionary<string, Item> Gears { get; }

	Dictionary<string, Item> Talents { get; }

	Dictionary<string, Spirit> Spirits { get; }

	Dictionary<string, Move> Moves { get; }

	Dictionary<string, Quest> Quests { get; }

	Dictionary<string, List<Area>> AreasByQuest { get; }

	Dictionary<string, List<QuestTask>> TasksByArea { get; }

	bool ItemsFullyLoaded { get; }

	bool TalentsFullyLoaded { get; }

	bool GearsFullyLoaded { get; }

	bool MovesFullyLoaded { get; }

	event Action StaticDataUpdateStarted;

	event Action StaticDataUpdateEnded;

	event Action StaticDataUpdated;

	void SetItemsFullyLoaded();

	void SetGearsFullyLoaded();

	void SetTalentsFullyLoaded();

	void SetMovesFullyLoaded();

	global::System.Threading.Tasks.Task<bool> LoadStaticDataAsync();
}
