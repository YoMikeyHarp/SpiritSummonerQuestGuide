using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SpiritSummoner.Application.BatchUpdates;

public class BatchUpdateMerger
{
	private static readonly Dictionary<global::System.Type, PropertyMergeInfo[]> _mergeInfoCache = new Dictionary<global::System.Type, PropertyMergeInfo[]>();

	private static readonly object _cacheLock = new object();

	public PlayerBatchUpdate Merge(global::System.Collections.Generic.IEnumerable<PlayerBatchUpdate> updates)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		List<PlayerBatchUpdate> val = Enumerable.ToList<PlayerBatchUpdate>(updates);
		if (val.Count == 0)
		{
			throw new ArgumentException("No updates to merge", "updates");
		}
		if (val.Count == 1)
		{
			return val[0];
		}
		PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
		{
			PlayerId = val[0].PlayerId
		};
		PropertyMergeInfo[] mergeInfos = GetMergeInfos(typeof(PlayerBatchUpdate));
		Enumerator<PlayerBatchUpdate> enumerator = val.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				PlayerBatchUpdate current = enumerator.Current;
				PropertyMergeInfo[] array = mergeInfos;
				foreach (PropertyMergeInfo info in array)
				{
					MergeProperty(playerBatchUpdate, current, info);
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator).Dispose();
		}
		return playerBatchUpdate;
	}

	private void MergeProperty(object target, object source, PropertyMergeInfo info)
	{
		object value = info.Property.GetValue(source);
		object value2 = info.Property.GetValue(target);
		MergeType strategy = info.Strategy;
		if (1 == 0)
		{
		}
		object obj = strategy switch
		{
			MergeType.Ignore => value2, 
			MergeType.Computed => value2, 
			MergeType.Accumulate => AccumulateValues(value2, value, info.Property.PropertyType), 
			MergeType.AccumulateNullable => AccumulateNullable(value2, value), 
			MergeType.LatestWins => value ?? value2, 
			MergeType.LatestWinsNonNull => IsNonDefault(value, info.Property.PropertyType) ? value : value2, 
			MergeType.OrFlags => OrBools(value2, value), 
			MergeType.DictionaryAccumulate => MergeDictAccumulate(value2, value, info.Property.PropertyType), 
			MergeType.DictionaryReplace => MergeDictReplace(value2, value, info.Property.PropertyType), 
			MergeType.ListConcat => ConcatLists(value2, value, info.Property.PropertyType), 
			MergeType.DeepMerge => DeepMergeObjects(value2, value, info.Property.PropertyType), 
			_ => value2, 
		};
		if (1 == 0)
		{
		}
		object obj2 = obj;
		info.Property.SetValue(target, obj2);
	}

	private static PropertyMergeInfo[] GetMergeInfos(global::System.Type type)
	{
		global::System.Type type2 = type;
		lock (_cacheLock)
		{
			PropertyMergeInfo[] result = default(PropertyMergeInfo[]);
			if (_mergeInfoCache.TryGetValue(type2, ref result))
			{
				return result;
			}
			PropertyMergeInfo[] array = Enumerable.ToArray<PropertyMergeInfo>(Enumerable.Select<PropertyInfo, PropertyMergeInfo>(Enumerable.Where<PropertyInfo>((global::System.Collections.Generic.IEnumerable<PropertyInfo>)type2.GetProperties((BindingFlags)20), (Func<PropertyInfo, bool>)((PropertyInfo p) => p.CanRead && p.CanWrite)), (Func<PropertyInfo, PropertyMergeInfo>)delegate(PropertyInfo p)
			{
				MergeStrategyAttribute customAttribute = CustomAttributeExtensions.GetCustomAttribute<MergeStrategyAttribute>((MemberInfo)(object)p);
				if (customAttribute == null)
				{
					Console.WriteLine($"WARNING: Property {((MemberInfo)type2).Name}.{((MemberInfo)p).Name} is missing [MergeStrategy] attribute. Defaulting to Ignore.");
					return new PropertyMergeInfo(p, MergeType.Ignore);
				}
				return new PropertyMergeInfo(p, customAttribute.Strategy);
			}));
			_mergeInfoCache[type2] = array;
			return array;
		}
	}

	private static object AccumulateValues(object? a, object? b, global::System.Type propertyType)
	{
		if (propertyType == typeof(int))
		{
			return (int)(a ?? ((object)0)) + (int)(b ?? ((object)0));
		}
		if (propertyType == typeof(long))
		{
			return (long)(a ?? ((object)0L)) + (long)(b ?? ((object)0L));
		}
		if (propertyType == typeof(double))
		{
			return (double)(a ?? ((object)0.0)) + (double)(b ?? ((object)0.0));
		}
		if (propertyType == typeof(float))
		{
			return (float)(a ?? ((object)0f)) + (float)(b ?? ((object)0f));
		}
		return a ?? b ?? GetDefault(propertyType);
	}

	private static object? AccumulateNullable(object? a, object? b)
	{
		if (a == null && b == null)
		{
			return null;
		}
		if (a == null)
		{
			return b;
		}
		if (b == null)
		{
			return a;
		}
		if (a is int num && b is int num2)
		{
			return num + num2;
		}
		return b;
	}

	private static bool IsNonDefault(object? value, global::System.Type propertyType)
	{
		if (value == null)
		{
			return false;
		}
		if (propertyType == typeof(string))
		{
			return !string.IsNullOrEmpty((string)value);
		}
		if (propertyType == typeof(int))
		{
			return (int)value != 0;
		}
		if (propertyType == typeof(double))
		{
			return (double)value != 0.0;
		}
		if (propertyType == typeof(bool))
		{
			return (bool)value;
		}
		return value != GetDefault(propertyType);
	}

	private static object OrBools(object? a, object? b)
	{
		return (bool)(a ?? ((object)false)) | (bool)(b ?? ((object)false));
	}

	private static object MergeDictAccumulate(object? target, object? source, global::System.Type dictType)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		if (source == null)
		{
			return target ?? CreateDictionary(dictType);
		}
		if (target == null)
		{
			return CopyDictionary(source, dictType);
		}
		IDictionary val = (IDictionary)target;
		IDictionary val2 = (IDictionary)source;
		global::System.Type propertyType = dictType.GetGenericArguments()[1];
		IDictionaryEnumerator enumerator = val2.GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				DictionaryEntry val3 = (DictionaryEntry)((global::System.Collections.IEnumerator)enumerator).Current;
				if (val.Contains(((DictionaryEntry)(ref val3)).Key))
				{
					object a = val[((DictionaryEntry)(ref val3)).Key];
					val[((DictionaryEntry)(ref val3)).Key] = AccumulateValues(a, ((DictionaryEntry)(ref val3)).Value, propertyType);
				}
				else
				{
					val[((DictionaryEntry)(ref val3)).Key] = ((DictionaryEntry)(ref val3)).Value;
				}
			}
		}
		finally
		{
			if (enumerator is global::System.IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
		return val;
	}

	private static object MergeDictReplace(object? target, object? source, global::System.Type dictType)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		if (source == null)
		{
			return target ?? CreateDictionary(dictType);
		}
		if (target == null)
		{
			return CopyDictionary(source, dictType);
		}
		IDictionary val = (IDictionary)target;
		IDictionary val2 = (IDictionary)source;
		IDictionaryEnumerator enumerator = val2.GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				DictionaryEntry val3 = (DictionaryEntry)((global::System.Collections.IEnumerator)enumerator).Current;
				val[((DictionaryEntry)(ref val3)).Key] = ((DictionaryEntry)(ref val3)).Value;
			}
		}
		finally
		{
			if (enumerator is global::System.IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
		return val;
	}

	private static object? ConcatLists(object? target, object? source, global::System.Type listType)
	{
		if (source == null)
		{
			return target;
		}
		if (target == null)
		{
			global::System.Collections.IList list = (global::System.Collections.IList)Activator.CreateInstance(listType);
			foreach (object item in (global::System.Collections.IEnumerable)source)
			{
				list.Add(item);
			}
			return list;
		}
		global::System.Collections.IList list2 = (global::System.Collections.IList)target;
		foreach (object item2 in (global::System.Collections.IEnumerable)source)
		{
			list2.Add(item2);
		}
		return list2;
	}

	private static object DeepMergeObjects(object? target, object? source, global::System.Type objectType)
	{
		if (source == null)
		{
			return target ?? Activator.CreateInstance(objectType);
		}
		if (target == null)
		{
			return source;
		}
		if (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Dictionary<, >))
		{
			return DeepMergeDictionary(target, source, objectType);
		}
		PropertyMergeInfo[] mergeInfos = GetMergeInfos(objectType);
		PropertyMergeInfo[] array = mergeInfos;
		foreach (PropertyMergeInfo propertyMergeInfo in array)
		{
			object value = propertyMergeInfo.Property.GetValue(source);
			object value2 = propertyMergeInfo.Property.GetValue(target);
			MergeType strategy = propertyMergeInfo.Strategy;
			if (1 == 0)
			{
			}
			object obj = strategy switch
			{
				MergeType.Ignore => value2, 
				MergeType.Computed => value2, 
				MergeType.LatestWins => value ?? value2, 
				MergeType.AccumulateNullable => AccumulateNullable(value2, value), 
				_ => value ?? value2, 
			};
			if (1 == 0)
			{
			}
			object obj2 = obj;
			propertyMergeInfo.Property.SetValue(target, obj2);
		}
		return target;
	}

	private static object DeepMergeDictionary(object target, object source, global::System.Type dictType)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		IDictionary val = (IDictionary)target;
		IDictionary val2 = (IDictionary)source;
		global::System.Type type = dictType.GetGenericArguments()[1];
		PropertyMergeInfo[] mergeInfos = GetMergeInfos(type);
		IDictionaryEnumerator enumerator = val2.GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				DictionaryEntry val3 = (DictionaryEntry)((global::System.Collections.IEnumerator)enumerator).Current;
				if (val.Contains(((DictionaryEntry)(ref val3)).Key))
				{
					object obj = val[((DictionaryEntry)(ref val3)).Key];
					object value = ((DictionaryEntry)(ref val3)).Value;
					if (obj == null || value == null)
					{
						continue;
					}
					PropertyMergeInfo[] array = mergeInfos;
					foreach (PropertyMergeInfo propertyMergeInfo in array)
					{
						object value2 = propertyMergeInfo.Property.GetValue(value);
						object value3 = propertyMergeInfo.Property.GetValue(obj);
						MergeType strategy = propertyMergeInfo.Strategy;
						if (1 == 0)
						{
						}
						object obj2 = strategy switch
						{
							MergeType.Ignore => value3, 
							MergeType.Computed => value3, 
							MergeType.AccumulateNullable => AccumulateNullable(value3, value2), 
							MergeType.LatestWins => value2 ?? value3, 
							MergeType.DictionaryReplace => MergeDictReplace(value3, value2, propertyMergeInfo.Property.PropertyType), 
							_ => value2 ?? value3, 
						};
						if (1 == 0)
						{
						}
						object obj3 = obj2;
						propertyMergeInfo.Property.SetValue(obj, obj3);
					}
				}
				else
				{
					val[((DictionaryEntry)(ref val3)).Key] = ((DictionaryEntry)(ref val3)).Value;
				}
			}
		}
		finally
		{
			if (enumerator is global::System.IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
		return val;
	}

	private static object CreateDictionary(global::System.Type dictType)
	{
		return Activator.CreateInstance(dictType);
	}

	private static object CopyDictionary(object source, global::System.Type dictType)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		IDictionary val = (IDictionary)Activator.CreateInstance(dictType);
		IDictionaryEnumerator enumerator = ((IDictionary)source).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				DictionaryEntry val2 = (DictionaryEntry)((global::System.Collections.IEnumerator)enumerator).Current;
				val[((DictionaryEntry)(ref val2)).Key] = ((DictionaryEntry)(ref val2)).Value;
			}
		}
		finally
		{
			if (enumerator is global::System.IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
		return val;
	}

	private static object? GetDefault(global::System.Type type)
	{
		return type.IsValueType ? Activator.CreateInstance(type) : null;
	}

	public static void ValidateAttributes<T>()
	{
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		global::System.Type typeFromHandle = typeof(T);
		global::System.Collections.Generic.IEnumerable<PropertyInfo> enumerable = Enumerable.Where<PropertyInfo>((global::System.Collections.Generic.IEnumerable<PropertyInfo>)typeFromHandle.GetProperties((BindingFlags)20), (Func<PropertyInfo, bool>)((PropertyInfo p) => p.CanRead && p.CanWrite));
		List<string> val = Enumerable.ToList<string>(Enumerable.Select<PropertyInfo, string>(Enumerable.Where<PropertyInfo>(enumerable, (Func<PropertyInfo, bool>)((PropertyInfo p) => CustomAttributeExtensions.GetCustomAttribute<MergeStrategyAttribute>((MemberInfo)(object)p) == null)), (Func<PropertyInfo, string>)((PropertyInfo p) => ((MemberInfo)p).Name)));
		if (Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)val))
		{
			throw new InvalidOperationException($"Type {((MemberInfo)typeFromHandle).Name} has properties without [MergeStrategy] attributes: {string.Join(", ", (global::System.Collections.Generic.IEnumerable<string>)val)}. " + "Add the attribute to ensure proper merge behavior.");
		}
	}
}
