namespace SpiritSummoner.Domain.Services;

public interface IBattleScoreCalculator
{
	int CalculateScoreChange(bool playerWon, int playerLevel, int opponentLevel, int currentScore, int livingSpiritsCount, double totalHealthPercentage, int timesFoughtRecently = 0);

	string GetTitle(int score, int globalRank);
}
