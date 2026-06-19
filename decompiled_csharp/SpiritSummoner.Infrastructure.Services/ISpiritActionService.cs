using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SpiritSummoner.Domain.Enums.Shops;
using SpiritSummoner.Presentation.Models;

namespace SpiritSummoner.Infrastructure.Services;

public interface ISpiritActionService
{
	global::System.Threading.Tasks.Task AddToSquadAsync(string spiritId);

	global::System.Threading.Tasks.Task AddToSquadPositionAsync(string spiritId, int position);

	global::System.Threading.Tasks.Task RemoveFromSquadAsync(string spiritId);

	global::System.Threading.Tasks.Task SwitchActiveSquadAsync(int newSquadSlot);

	global::System.Threading.Tasks.Task SetAsPartnerAsync(string spiritId);

	global::System.Threading.Tasks.Task ToggleSpiritFavorite(string spiritId);

	global::System.Threading.Tasks.Task<ValueTuple<bool, int>> SellSpiritAsync(string spiritId);

	global::System.Threading.Tasks.Task GoToSavedSquads();

	global::System.Threading.Tasks.Task<bool> EditAttributesAsync(SpiritCardModel spirit);

	global::System.Threading.Tasks.Task<InsufficientFundsResult> EditMovesAsync(SpiritCardModel spirit, ObservableCollection<MoveEditableState> moves);

	global::System.Threading.Tasks.Task<InsufficientFundsResult> EditGearsAsync(SpiritCardModel spirit, ItemModel? currentGear = null);

	global::System.Threading.Tasks.Task<InsufficientFundsResult> EditTalentsAsync(SpiritCardModel spirit, ItemModel? currentTalent = null);
}
