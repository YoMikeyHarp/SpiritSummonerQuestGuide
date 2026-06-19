using System.Collections.Generic;

namespace SpiritSummoner.Presentation.ViewModels.Chat;

internal static class _003CNotificationFormatter_003EFA0C1BD20EFDF4FBF62019861CCCB2CED0817F10051F906687F342127DE12B47C__DictExt
{
	public static string GetStr(this Dictionary<string, object> d, string key)
	{
		object obj = default(object);
		return (d.TryGetValue(key, ref obj) && obj is string text) ? text : string.Empty;
	}

	public static int GetInt(this Dictionary<string, object> d, string key)
	{
		object obj = default(object);
		bool flag = d.TryGetValue(key, ref obj);
		if (1 == 0)
		{
		}
		if (!flag)
		{
			goto IL_0044;
		}
		int result;
		if (obj is int num)
		{
			result = num;
		}
		else
		{
			if (!(obj is long num2))
			{
				goto IL_0044;
			}
			result = (int)num2;
		}
		goto IL_0048;
		IL_0044:
		result = 0;
		goto IL_0048;
		IL_0048:
		if (1 == 0)
		{
		}
		return result;
	}

	public static bool GetBool(this Dictionary<string, object> d, string key)
	{
		object obj = default(object);
		bool flag = default(bool);
		int num;
		if (d.TryGetValue(key, ref obj))
		{
			if (obj is bool)
			{
				flag = (bool)obj;
				num = 1;
			}
			else
			{
				num = 0;
			}
		}
		else
		{
			num = 0;
		}
		return (byte)((uint)num & (flag ? 1u : 0u)) != 0;
	}
}
