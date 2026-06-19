using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SpiritSummoner.Infrastructure.Diagnostics;

public static class FirestoreReadCounter
{
	private static readonly Dictionary<string, int> _counts = new Dictionary<string, int>();

	private static readonly object _lock = new object();

	private static global::System.DateTime _sessionStart = global::System.DateTime.UtcNow;

	public static int Total
	{
		get
		{
			lock (_lock)
			{
				return Enumerable.Sum((global::System.Collections.Generic.IEnumerable<int>)_counts.Values);
			}
		}
	}

	public static void Track(string collectionKey, int documentCount = 1)
	{
		lock (_lock)
		{
			int num = default(int);
			_counts.TryGetValue(collectionKey, ref num);
			_counts[collectionKey] = num + documentCount;
		}
		int total = Total;
		if (total % 100 == 0)
		{
			LogSummary();
		}
	}

	public static void LogSummary()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		lock (_lock)
		{
			TimeSpan val = global::System.DateTime.UtcNow - _sessionStart;
			int num = Enumerable.Sum((global::System.Collections.Generic.IEnumerable<int>)_counts.Values);
			double num2 = ((((TimeSpan)(ref val)).TotalMinutes > 0.0) ? ((double)num / ((TimeSpan)(ref val)).TotalMinutes) : 0.0);
			Console.WriteLine("=== FirestoreReadCounter ===");
			Console.WriteLine($"  Session duration : {val:mm\\:ss}");
			Console.WriteLine($"  Total reads      : {num}  ({num2:F1}/min)");
			Console.WriteLine("  By collection:");
			global::System.Collections.Generic.IEnumerator<KeyValuePair<string, int>> enumerator = ((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, int>>)Enumerable.OrderByDescending<KeyValuePair<string, int>, int>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, int>>)_counts, (Func<KeyValuePair<string, int>, int>)((KeyValuePair<string, int> x) => x.Value))).GetEnumerator();
			try
			{
				while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
				{
					KeyValuePair<string, int> current = enumerator.Current;
					Console.WriteLine($"    {current.Key,-35} {current.Value,6}");
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator)?.Dispose();
			}
			Console.WriteLine("============================");
		}
	}

	public static void Reset()
	{
		lock (_lock)
		{
			_counts.Clear();
			_sessionStart = global::System.DateTime.UtcNow;
		}
	}
}
