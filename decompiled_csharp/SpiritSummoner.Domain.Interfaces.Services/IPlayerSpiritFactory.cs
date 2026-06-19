using System.Collections.Generic;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;

namespace SpiritSummoner.Domain.Interfaces.Services;

public interface IPlayerSpiritFactory
{
	PlayerSpirit CreateRandomSpirit(Player npcPlayer, Spirit baseSpirit);

	PlayerSpirit CreateQuestSpirit(Spirit questSpirit, int level, global::System.Collections.Generic.IReadOnlyList<Move> moves, string opponentName);

	PlayerSpirit CreateStarterSpirit(string ownerUsername, Spirit baseSpirit);

	PlayerSpirit CreateForPlayer(Spirit template, Player owner, int level, string? playerSpiritId = null);

	int CalculateInitialHP(Spirit template, int level);

	int CalculateInitialTrainingPoints(int level);
}
