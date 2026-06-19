using System;
using System.Runtime.CompilerServices;
using SpiritSummoner.Domain.Enums.Spirits;

namespace SpiritSummoner.Domain.Enums.Battles;

public class TypeChart
{
	private static double[][] chart;

	internal static double GetEffectiveness(SpiritType attackType, SpiritType defenseType)
	{
		if (attackType == SpiritType.None || defenseType == SpiritType.None)
		{
			return 1.0;
		}
		int num = (int)(attackType - 1);
		int num2 = (int)(defenseType - 1);
		if (num < 0 || num >= chart.Length || num2 < 0 || num2 >= chart[0].Length)
		{
			return 1.0;
		}
		return chart[num][num2];
	}

	static TypeChart()
	{
		double[][] array = new double[11][];
		double[] array2 = new double[11];
		RuntimeHelpers.InitializeArray((global::System.Array)array2, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		array[0] = array2;
		double[] array3 = new double[11];
		RuntimeHelpers.InitializeArray((global::System.Array)array3, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		array[1] = array3;
		double[] array4 = new double[11];
		RuntimeHelpers.InitializeArray((global::System.Array)array4, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		array[2] = array4;
		double[] array5 = new double[11];
		RuntimeHelpers.InitializeArray((global::System.Array)array5, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		array[3] = array5;
		double[] array6 = new double[11];
		RuntimeHelpers.InitializeArray((global::System.Array)array6, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		array[4] = array6;
		double[] array7 = new double[11];
		RuntimeHelpers.InitializeArray((global::System.Array)array7, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		array[5] = array7;
		double[] array8 = new double[11];
		RuntimeHelpers.InitializeArray((global::System.Array)array8, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		array[6] = array8;
		double[] array9 = new double[11];
		RuntimeHelpers.InitializeArray((global::System.Array)array9, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		array[7] = array9;
		double[] array10 = new double[11];
		RuntimeHelpers.InitializeArray((global::System.Array)array10, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		array[8] = array10;
		double[] array11 = new double[11];
		RuntimeHelpers.InitializeArray((global::System.Array)array11, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		array[9] = array11;
		double[] array12 = new double[11];
		RuntimeHelpers.InitializeArray((global::System.Array)array12, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		array[10] = array12;
		chart = array;
	}
}
