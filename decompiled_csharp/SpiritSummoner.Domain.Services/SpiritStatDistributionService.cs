using System;
using System.Collections.Generic;
using System.Linq;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;

namespace SpiritSummoner.Domain.Services;

public class SpiritStatDistributionService
{
	private readonly SpiritBusinessService _spiritBusinessService;

	public SpiritStatDistributionService(SpiritBusinessService spiritBusinessService)
	{
		_spiritBusinessService = spiritBusinessService;
	}

	public void DistributeTrainingPoints(PlayerSpirit playerSpirit, Spirit baseSpirit)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		Random val = new Random();
		bool flag = _spiritBusinessService.IsPhysicalAttacker(baseSpirit);
		Dictionary<string, double> obj = new Dictionary<string, double>();
		obj.Add("ATK", flag ? 0.5 : 0.0);
		obj.Add("SATK", flag ? 0.0 : 0.5);
		obj.Add("DEF", 0.1);
		obj.Add("SPD", 0.3);
		obj.Add("SDEF", 0.1);
		Dictionary<string, double> priorities = obj;
		int num = baseSpirit.TrainingPoints;
		while (num > 0)
		{
			string text = SelectAttributeBasedOnPriority(priorities, val);
			int num2 = val.Next(5, 20);
			if (num2 > num)
			{
				num2 = num;
			}
			string text2 = text;
			string text3 = text2;
			if (!(text3 == "ATK"))
			{
				if (!(text3 == "DEF"))
				{
					if (!(text3 == "SPD"))
					{
						if (!(text3 == "SATK"))
						{
							if (text3 == "SDEF")
							{
								playerSpirit.AddStatPoints(0, 0, 0, num2);
							}
						}
						else
						{
							playerSpirit.AddStatPoints(0, 0, num2);
						}
					}
					else
					{
						playerSpirit.AddStatPoints(0, 0, 0, 0, num2);
					}
				}
				else
				{
					playerSpirit.AddStatPoints(0, num2);
				}
			}
			else
			{
				playerSpirit.AddStatPoints(num2);
			}
			num -= num2;
		}
	}

	private string SelectAttributeBasedOnPriority(Dictionary<string, double> priorities, Random random)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		double num = Enumerable.Sum((global::System.Collections.Generic.IEnumerable<double>)priorities.Values);
		double num2 = random.NextDouble() * num;
		Enumerator<string, double> enumerator = priorities.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, double> current = enumerator.Current;
				if (num2 < current.Value)
				{
					return current.Key;
				}
				num2 -= current.Value;
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator).Dispose();
		}
		return Enumerable.First<string>((global::System.Collections.Generic.IEnumerable<string>)priorities.Keys);
	}
}
