using System.Collections.Generic;
using System.Threading.Tasks;
using SpiritSummoner.Application.DTOs;

namespace SpiritSummoner.Infrastructure.Services;

public interface IDailyGiftService
{
	global::System.Threading.Tasks.Task<List<DailyGiftDTO>> GetUnredeemedGiftsAsync(string playerId);

	global::System.Threading.Tasks.Task MarkAsRedeemedAsync(string playerId, string giftId);
}
