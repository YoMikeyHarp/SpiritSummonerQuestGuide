using System;
using System.Collections.Generic;

namespace SpiritSummoner.Domain.Services;

public static class StatConversions
{
	public static Dictionary<string, int> Compute(IReadOnlyDictionary<string, int> stats, IReadOnlySet<string> abilities)
	{
		Dictionary<string, int> val = new Dictionary<string, int>((IEqualityComparer<string>)(object)StringComparer.Ordinal);
		if (stats == null || abilities == null || ((global::System.Collections.Generic.IReadOnlyCollection<string>)abilities).Count == 0)
		{
			return val;
		}
		int num = default(int);
		if (abilities.Contains("atkToInt") && stats.TryGetValue("ATK", ref num))
		{
			val["INT"] = CollectionExtensions.GetValueOrDefault<string, int>((IReadOnlyDictionary<string, int>)(object)val, "INT") + (int)((float)num * 0.15f);
		}
		int num2 = default(int);
		if (abilities.Contains("intToSpd") && stats.TryGetValue("INT", ref num2))
		{
			int num3 = num2 + CollectionExtensions.GetValueOrDefault<string, int>((IReadOnlyDictionary<string, int>)(object)val, "INT");
			val["SPD"] = CollectionExtensions.GetValueOrDefault<string, int>((IReadOnlyDictionary<string, int>)(object)val, "SPD") + (int)((float)num3 * 0.2f);
		}
		int num4 = default(int);
		if (abilities.Contains("mindOverMatter") && stats.TryGetValue("INT", ref num4))
		{
			int num5 = num4 + CollectionExtensions.GetValueOrDefault<string, int>((IReadOnlyDictionary<string, int>)(object)val, "INT");
			int num6 = (int)((float)num5 * 0.3f);
			val["DEF"] = CollectionExtensions.GetValueOrDefault<string, int>((IReadOnlyDictionary<string, int>)(object)val, "DEF") + num6;
			val["SDEF"] = CollectionExtensions.GetValueOrDefault<string, int>((IReadOnlyDictionary<string, int>)(object)val, "SDEF") + num6;
		}
		return val;
	}
}
