using System;
using System.Runtime.CompilerServices;
using SpiritSummoner.Domain.Enums.Spirits;
using SpiritSummoner.Domain.Interfaces.Services;

namespace SpiritSummoner.Domain.Services;

public class TypeEffectivenessService : ITypeEffectivenessService
{
	private static readonly double[][] _effectivenessChart;

	public double GetEffectiveness(SpiritType attackType, SpiritType defenseType)
	{
		if (attackType == SpiritType.None || defenseType == SpiritType.None)
		{
			return 1.0;
		}
		int num = (int)(attackType - 1);
		int num2 = (int)(defenseType - 1);
		if (num < 0 || num >= _effectivenessChart.Length || num2 < 0 || num2 >= _effectivenessChart[num].Length)
		{
			return 1.0;
		}
		return _effectivenessChart[num][num2];
	}

	public double GetTotalEffectiveness(SpiritType attackType, SpiritType defenderType1, SpiritType defenderType2)
	{
		double effectiveness = GetEffectiveness(attackType, defenderType1);
		double effectiveness2 = GetEffectiveness(attackType, defenderType2);
		return effectiveness * effectiveness2;
	}

	public bool IsSuperEffective(SpiritType attackType, SpiritType defenseType)
	{
		double effectiveness = GetEffectiveness(attackType, defenseType);
		return effectiveness >= 2.0;
	}

	public bool IsNotVeryEffective(SpiritType attackType, SpiritType defenseType)
	{
		double effectiveness = GetEffectiveness(attackType, defenseType);
		return effectiveness > 0.0 && effectiveness <= 0.5;
	}

	public bool IsImmune(SpiritType attackType, SpiritType defenseType)
	{
		double effectiveness = GetEffectiveness(attackType, defenseType);
		return effectiveness == 0.0;
	}

	static TypeEffectivenessService()
	{
		double[][] array = new double[12][];
		double[] array2 = new double[12];
		RuntimeHelpers.InitializeArray((global::System.Array)array2, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		array[0] = array2;
		double[] array3 = new double[12];
		RuntimeHelpers.InitializeArray((global::System.Array)array3, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		array[1] = array3;
		double[] array4 = new double[12];
		RuntimeHelpers.InitializeArray((global::System.Array)array4, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		array[2] = array4;
		double[] array5 = new double[12];
		RuntimeHelpers.InitializeArray((global::System.Array)array5, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		array[3] = array5;
		double[] array6 = new double[12];
		RuntimeHelpers.InitializeArray((global::System.Array)array6, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		array[4] = array6;
		double[] array7 = new double[12];
		RuntimeHelpers.InitializeArray((global::System.Array)array7, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		array[5] = array7;
		double[] array8 = new double[12];
		RuntimeHelpers.InitializeArray((global::System.Array)array8, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		array[6] = array8;
		double[] array9 = new double[12];
		RuntimeHelpers.InitializeArray((global::System.Array)array9, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		array[7] = array9;
		double[] array10 = new double[12];
		RuntimeHelpers.InitializeArray((global::System.Array)array10, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		array[8] = array10;
		double[] array11 = new double[12];
		RuntimeHelpers.InitializeArray((global::System.Array)array11, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		array[9] = array11;
		double[] array12 = new double[12];
		RuntimeHelpers.InitializeArray((global::System.Array)array12, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		array[10] = array12;
		double[] array13 = new double[12];
		RuntimeHelpers.InitializeArray((global::System.Array)array13, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		array[11] = array13;
		_effectivenessChart = array;
	}
}
