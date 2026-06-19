using SpiritSummoner.Domain.Enums.Spirits;

namespace SpiritSummoner.Domain.Interfaces.Services;

public interface ITypeEffectivenessService
{
	double GetEffectiveness(SpiritType attackType, SpiritType defenseType);

	double GetTotalEffectiveness(SpiritType attackType, SpiritType defenderType1, SpiritType defenderType2);

	bool IsSuperEffective(SpiritType attackType, SpiritType defenseType);

	bool IsNotVeryEffective(SpiritType attackType, SpiritType defenseType);

	bool IsImmune(SpiritType attackType, SpiritType defenseType);
}
