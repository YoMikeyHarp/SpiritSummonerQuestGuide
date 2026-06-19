using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Domain.Interfaces.Services;

public interface IPlayerFactory
{
	Player CreateNewPlayer(string playerId, string username, string partnerSpiritId);
}
