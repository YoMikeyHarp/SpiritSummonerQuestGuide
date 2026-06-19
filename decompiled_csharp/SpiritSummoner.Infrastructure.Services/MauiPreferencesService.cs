using System;
using Microsoft.Maui.Storage;
using SpiritSummoner.Application.Services;

namespace SpiritSummoner.Infrastructure.Services;

public class MauiPreferencesService : IPreferencesService
{
	public T? Get<T>(string key, T? defaultValue = default(T?))
	{
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		if (typeof(T) == typeof(string))
		{
			return (T)(object)Preferences.Get(key, (defaultValue as string) ?? string.Empty);
		}
		if (typeof(T) == typeof(bool))
		{
			return (T)(object)Preferences.Get(key, (bool)(object)defaultValue);
		}
		if (typeof(T) == typeof(int))
		{
			return (T)(object)Preferences.Get(key, (int)(object)defaultValue | 0);
		}
		if (typeof(T) == typeof(double))
		{
			return (T)(object)Preferences.Get(key, (double)(object)defaultValue);
		}
		if (typeof(T) == typeof(long))
		{
			return (T)(object)Preferences.Get(key, (long)(object)defaultValue);
		}
		if (typeof(T) == typeof(global::System.DateTime))
		{
			return (T)(object)Preferences.Get(key, (global::System.DateTime)(object)defaultValue);
		}
		throw new NotSupportedException($"Type {typeof(T)} is not supported by Preferences");
	}

	public void Set<T>(string key, T value)
	{
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		if (value == null)
		{
			Remove(key);
			return;
		}
		if (value is string text)
		{
			Preferences.Set(key, text);
			return;
		}
		if (value is bool)
		{
			object obj = value;
			bool flag = (bool)((obj is bool) ? obj : null);
			if (true)
			{
				Preferences.Set(key, flag);
				return;
			}
		}
		if (value is int)
		{
			object obj2 = value;
			int num = (int)((obj2 is int) ? obj2 : null);
			if (true)
			{
				Preferences.Set(key, num);
				return;
			}
		}
		if (value is double)
		{
			object obj3 = value;
			double num2 = (double)((obj3 is double) ? obj3 : null);
			if (true)
			{
				Preferences.Set(key, num2);
				return;
			}
		}
		if (value is long)
		{
			object obj4 = value;
			long num3 = (long)((obj4 is long) ? obj4 : null);
			if (true)
			{
				Preferences.Set(key, num3);
				return;
			}
		}
		if (value is global::System.DateTime)
		{
			object obj5 = value;
			global::System.DateTime dateTime = (global::System.DateTime)((obj5 is global::System.DateTime) ? obj5 : null);
			if (true)
			{
				Preferences.Set(key, dateTime);
				return;
			}
		}
		throw new NotSupportedException($"Type {typeof(T)} is not supported by Preferences");
	}

	public void Remove(string key)
	{
		Preferences.Remove(key);
	}

	public void Clear()
	{
		Preferences.Clear();
	}

	public bool ContainsKey(string key)
	{
		return Preferences.ContainsKey(key);
	}
}
