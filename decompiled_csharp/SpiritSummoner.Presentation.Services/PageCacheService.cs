using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.Services;

public class PageCacheService : IPageCacheService
{
	private sealed class DeepVmEntry
	{
		[field: CompilerGenerated]
		[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
		public object Vm
		{
			[CompilerGenerated]
			get;
		}

		[field: CompilerGenerated]
		[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
		public global::System.DateTime LastAccessedUtc
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		public DeepVmEntry(object vm)
		{
			Vm = vm;
			LastAccessedUtc = global::System.DateTime.UtcNow;
		}
	}

	private readonly ConcurrentDictionary<string, ContentView> _mainPageCache = new ConcurrentDictionary<string, ContentView>();

	private readonly ConcurrentDictionary<string, Func<ContentView>> _mainPageFactories = new ConcurrentDictionary<string, Func<ContentView>>();

	private readonly ConcurrentDictionary<string, BottomSheet> _sheetPageCache = new ConcurrentDictionary<string, BottomSheet>();

	private readonly ConcurrentDictionary<string, Func<BottomSheet>> _sheetPageFactories = new ConcurrentDictionary<string, Func<BottomSheet>>();

	private readonly ConcurrentDictionary<string, DeepVmEntry> _deepPageVMcache = new ConcurrentDictionary<string, DeepVmEntry>();

	private readonly ConcurrentDictionary<string, object> _mainPageVMcache = new ConcurrentDictionary<string, object>();

	private readonly ConcurrentDictionary<string, object> _sheetPageVMcache = new ConcurrentDictionary<string, object>();

	public ContentView? GetMainPage(string route)
	{
		ContentView result = default(ContentView);
		if (_mainPageCache.TryGetValue(route, ref result))
		{
			return result;
		}
		Func<ContentView> val = default(Func<ContentView>);
		if (_mainPageFactories.TryGetValue(route, ref val))
		{
			try
			{
				ContentView val2 = val.Invoke();
				_mainPageCache[route] = val2;
				return val2;
			}
			catch (global::System.Exception ex)
			{
				Console.WriteLine("Error creating page for route " + route + ": " + ex.Message);
				return null;
			}
		}
		return null;
	}

	public BottomSheet? GetSheetPage(string key)
	{
		BottomSheet result = default(BottomSheet);
		if (_sheetPageCache.TryGetValue(key, ref result))
		{
			return result;
		}
		Func<BottomSheet> val = default(Func<BottomSheet>);
		if (_sheetPageFactories.TryGetValue(key, ref val))
		{
			try
			{
				BottomSheet val2 = val.Invoke();
				_sheetPageCache[key] = val2;
				return val2;
			}
			catch (global::System.Exception ex)
			{
				Console.WriteLine("Error creating sheet for key " + key + ": " + ex.Message);
				return null;
			}
		}
		return null;
	}

	public void CacheMainPage(string route, Func<ContentView> factory)
	{
		_mainPageFactories.TryAdd(route, factory);
	}

	public void CacheSheetPage(string key, Func<BottomSheet> factory)
	{
		_sheetPageFactories.TryAdd(key, factory);
	}

	public T? GetDeepVM<T>(string key) where T : class
	{
		DeepVmEntry deepVmEntry = default(DeepVmEntry);
		if (_deepPageVMcache.TryGetValue(key, ref deepVmEntry))
		{
			deepVmEntry.LastAccessedUtc = global::System.DateTime.UtcNow;
			return deepVmEntry.Vm as T;
		}
		return null;
	}

	public T? GetMainVM<T>(string key) where T : class
	{
		object obj = default(object);
		return _mainPageVMcache.TryGetValue(key, ref obj) ? (obj as T) : null;
	}

	public T? GetSheetVM<T>(string key) where T : class
	{
		object obj = default(object);
		return _sheetPageVMcache.TryGetValue(key, ref obj) ? (obj as T) : null;
	}

	public void CacheDeepVM<T>(string key, T viewModel) where T : class
	{
		_deepPageVMcache.TryAdd(key, new DeepVmEntry(viewModel));
	}

	public void CacheMainVM<T>(string key, T viewModel) where T : class
	{
		_mainPageVMcache.TryAdd(key, (object)viewModel);
	}

	public void CacheSheetVM<T>(string key, T viewModel) where T : class
	{
		_sheetPageVMcache.TryAdd(key, (object)viewModel);
	}

	public void SweepIdleDeepVMs(TimeSpan maxIdle, string? activeRoute = null)
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		if (!string.IsNullOrEmpty(activeRoute))
		{
			global::System.Collections.Generic.IEnumerator<KeyValuePair<string, DeepVmEntry>> enumerator = _deepPageVMcache.GetEnumerator();
			try
			{
				while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
				{
					KeyValuePair<string, DeepVmEntry> current = enumerator.Current;
					if (activeRoute.StartsWith(current.Key, (StringComparison)4))
					{
						current.Value.LastAccessedUtc = global::System.DateTime.UtcNow;
					}
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator)?.Dispose();
			}
		}
		global::System.DateTime dateTime = global::System.DateTime.UtcNow - maxIdle;
		int num = 0;
		global::System.Collections.Generic.IEnumerator<KeyValuePair<string, DeepVmEntry>> enumerator2 = _deepPageVMcache.GetEnumerator();
		try
		{
			DeepVmEntry deepVmEntry = default(DeepVmEntry);
			while (((global::System.Collections.IEnumerator)enumerator2).MoveNext())
			{
				KeyValuePair<string, DeepVmEntry> current2 = enumerator2.Current;
				if (!(current2.Value.LastAccessedUtc >= dateTime) && _deepPageVMcache.TryRemove(current2.Key, ref deepVmEntry))
				{
					if (deepVmEntry.Vm is global::System.IDisposable disposable)
					{
						disposable.Dispose();
					}
					num++;
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator2)?.Dispose();
		}
		if (num > 0)
		{
			Console.WriteLine($"PageCacheService.SweepIdleDeepVMs: evicted {num} idle deep VM(s) older than {maxIdle}");
		}
	}

	public void EvictAll()
	{
		global::System.Collections.Generic.IEnumerator<DeepVmEntry> enumerator = ((global::System.Collections.Generic.IEnumerable<DeepVmEntry>)_deepPageVMcache.Values).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				DeepVmEntry current = enumerator.Current;
				if (current.Vm is global::System.IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
		global::System.Collections.Generic.IEnumerator<object> enumerator2 = ((global::System.Collections.Generic.IEnumerable<object>)_mainPageVMcache.Values).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator2).MoveNext())
			{
				object current2 = enumerator2.Current;
				if (current2 is global::System.IDisposable disposable2)
				{
					disposable2.Dispose();
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator2)?.Dispose();
		}
		global::System.Collections.Generic.IEnumerator<object> enumerator3 = ((global::System.Collections.Generic.IEnumerable<object>)_sheetPageVMcache.Values).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator3).MoveNext())
			{
				object current3 = enumerator3.Current;
				if (current3 is global::System.IDisposable disposable3)
				{
					disposable3.Dispose();
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator3)?.Dispose();
		}
		_deepPageVMcache.Clear();
		_mainPageVMcache.Clear();
		_sheetPageVMcache.Clear();
		_mainPageCache.Clear();
		_sheetPageCache.Clear();
		_mainPageFactories.Clear();
		_sheetPageFactories.Clear();
	}
}
