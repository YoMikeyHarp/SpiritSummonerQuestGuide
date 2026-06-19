using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.ValueObjects.Battle;

namespace SpiritSummoner.Domain.Interfaces.Services;

public interface IBattleAIService
{
	Move GetRandomMove(PlayerSpirit playerSpirit, Spirit baseSpirit, BattleSprite attacker, BattleSprite defender);
}
