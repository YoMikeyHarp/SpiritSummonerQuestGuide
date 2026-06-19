using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.Events;
using SpiritSummoner.Application.State;
using SpiritSummoner.Presentation.Models;

namespace SpiritSummoner.Presentation.ViewModels.Spirits;

public class SpiritCardModelCache : global::System.IDisposable
{
	[RequiredMember]
	private class CacheEntry
	{
		public int ReferenceCount;

		[RequiredMember]
		[field: CompilerGenerated]
		[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
		public SpiritCardModel Model
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			init;
		}

		[field: CompilerGenerated]
		[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
		public DateTimeOffset LastAccess
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public CacheEntry()
		{
		}
	}

	public record CacheStats
	{
		[CompilerGenerated]
		protected virtual global::System.Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return typeof(CacheStats);
			}
		}

		public int TotalCount
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			init;
		}

		public int ActiveCount
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			init;
		}

		public int ColdCount
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			init;
		}

		public int TotalReferences
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			init;
		}

		[CompilerGenerated]
		public override string ToString()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			StringBuilder val = new StringBuilder();
			val.Append("CacheStats");
			val.Append(" { ");
			if (PrintMembers(val))
			{
				val.Append(' ');
			}
			val.Append('}');
			return ((object)val).ToString();
		}

		[CompilerGenerated]
		protected virtual bool PrintMembers(StringBuilder builder)
		{
			RuntimeHelpers.EnsureSufficientExecutionStack();
			builder.Append("TotalCount = ");
			builder.Append(((object)TotalCount).ToString());
			builder.Append(", ActiveCount = ");
			builder.Append(((object)ActiveCount).ToString());
			builder.Append(", ColdCount = ");
			builder.Append(((object)ColdCount).ToString());
			builder.Append(", TotalReferences = ");
			builder.Append(((object)TotalReferences).ToString());
			return true;
		}

		[CompilerGenerated]
		public virtual bool Equals(CacheStats? other)
		{
			return (object)this == other || ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<int>.Default.Equals(TotalCount, other.TotalCount) && EqualityComparer<int>.Default.Equals(ActiveCount, other.ActiveCount) && EqualityComparer<int>.Default.Equals(ColdCount, other.ColdCount) && EqualityComparer<int>.Default.Equals(TotalReferences, other.TotalReferences));
		}
	}

	[CompilerGenerated]
	private sealed class _003CAcquireAsync_003Ed__11 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<SpiritCardModel> _003C_003Et__builder;

		public string playerSpiritId;

		public SpiritCardModelCache _003C_003E4__this;

		private CacheEntry _003Centry_003E5__1;

		private SpiritCardModel _003Cmodel_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_022d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0232: Unknown result type (might be due to invalid IL or missing references)
			//IL_023a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_026c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_020f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			SpiritCardModel model;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0158;
				}
				if (num == 1)
				{
					goto IL_0161;
				}
				if (string.IsNullOrEmpty(playerSpiritId))
				{
					throw new ArgumentException("Spirit ID cannot be null or empty", "playerSpiritId");
				}
				if (!_003C_003E4__this._cache.TryGetValue(playerSpiritId, ref _003Centry_003E5__1))
				{
					awaiter = _003C_003E4__this._createLock.WaitAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CAcquireAsync_003Ed__11 _003CAcquireAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CAcquireAsync_003Ed__11>(ref awaiter, ref _003CAcquireAsync_003Ed__);
						return;
					}
					goto IL_0158;
				}
				Interlocked.Increment(ref _003Centry_003E5__1.ReferenceCount);
				_003Centry_003E5__1.LastAccess = DateTimeOffset.UtcNow;
				Debug.WriteLine($"[Cache] Acquired existing model: {playerSpiritId} (refCount={_003Centry_003E5__1.ReferenceCount})");
				model = _003Centry_003E5__1.Model;
				goto end_IL_0007;
				IL_0161:
				try
				{
					TaskAwaiter awaiter2;
					if (num == 1)
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0249;
					}
					if (!_003C_003E4__this._cache.TryGetValue(playerSpiritId, ref _003Centry_003E5__1))
					{
						_003Cmodel_003E5__2 = ActivatorUtilities.CreateInstance<SpiritCardModel>(_003C_003E4__this._serviceProvider, new object[1] { playerSpiritId });
						awaiter2 = _003Cmodel_003E5__2.InitializeAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter2;
							_003CAcquireAsync_003Ed__11 _003CAcquireAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CAcquireAsync_003Ed__11>(ref awaiter2, ref _003CAcquireAsync_003Ed__);
							return;
						}
						goto IL_0249;
					}
					Interlocked.Increment(ref _003Centry_003E5__1.ReferenceCount);
					_003Centry_003E5__1.LastAccess = DateTimeOffset.UtcNow;
					model = _003Centry_003E5__1.Model;
					goto end_IL_0161;
					IL_0249:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					_003Centry_003E5__1 = new CacheEntry
					{
						Model = _003Cmodel_003E5__2,
						ReferenceCount = 1,
						LastAccess = DateTimeOffset.UtcNow
					};
					_003C_003E4__this._cache[playerSpiritId] = _003Centry_003E5__1;
					Debug.WriteLine("[Cache] Created new model: " + playerSpiritId + " (refCount=1)");
					model = _003Cmodel_003E5__2;
					end_IL_0161:;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this._createLock.Release();
					}
				}
				goto end_IL_0007;
				IL_0158:
				((TaskAwaiter)(ref awaiter)).GetResult();
				goto IL_0161;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Centry_003E5__1 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Centry_003E5__1 = null;
			_003C_003Et__builder.SetResult(model);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IServiceProvider _serviceProvider;

	private readonly IPlayerStateService _stateService;

	private readonly ConcurrentDictionary<string, CacheEntry> _cache = new ConcurrentDictionary<string, CacheEntry>();

	private readonly SemaphoreSlim _createLock = new SemaphoreSlim(1, 1);

	private readonly Timer _evictionTimer;

	private bool _disposed;

	private const int MAX_COLD_ENTRIES = 20;

	private const int EVICTION_INTERVAL_MS = 60000;

	private const int COLD_ENTRY_TTL_SECONDS = 120;

	public SpiritCardModelCache(IServiceProvider serviceProvider, IPlayerStateService stateService)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		_serviceProvider = serviceProvider;
		_stateService = stateService;
		_stateService.StateChanged += OnStateChanged;
		_evictionTimer = new Timer((TimerCallback)([CompilerGenerated] (object? _) =>
		{
			EvictColdEntries();
		}), (object)null, 60000, 60000);
	}

	private void OnStateChanged(object? sender, StateChangedEventArgs e)
	{
		if (e.Scope == StateChangeScope.Player && e.ChangeType == "SessionEnd")
		{
			Clear();
		}
	}

	[AsyncStateMachine(typeof(_003CAcquireAsync_003Ed__11))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<SpiritCardModel> AcquireAsync(string playerSpiritId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(playerSpiritId))
		{
			throw new ArgumentException("Spirit ID cannot be null or empty", "playerSpiritId");
		}
		CacheEntry entry2 = default(CacheEntry);
		if (_cache.TryGetValue(playerSpiritId, ref entry2))
		{
			Interlocked.Increment(ref entry2.ReferenceCount);
			entry2.LastAccess = DateTimeOffset.UtcNow;
			Debug.WriteLine($"[Cache] Acquired existing model: {playerSpiritId} (refCount={entry2.ReferenceCount})");
			return entry2.Model;
		}
		await _createLock.WaitAsync();
		try
		{
			if (_cache.TryGetValue(playerSpiritId, ref entry2))
			{
				Interlocked.Increment(ref entry2.ReferenceCount);
				entry2.LastAccess = DateTimeOffset.UtcNow;
				return entry2.Model;
			}
			SpiritCardModel model = ActivatorUtilities.CreateInstance<SpiritCardModel>(_serviceProvider, new object[1] { playerSpiritId });
			await model.InitializeAsync();
			entry2 = new CacheEntry
			{
				Model = model,
				ReferenceCount = 1,
				LastAccess = DateTimeOffset.UtcNow
			};
			_cache[playerSpiritId] = entry2;
			Debug.WriteLine("[Cache] Created new model: " + playerSpiritId + " (refCount=1)");
			return model;
		}
		finally
		{
			_createLock.Release();
		}
	}

	public void Release(string playerSpiritId)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		CacheEntry cacheEntry = default(CacheEntry);
		if (!string.IsNullOrEmpty(playerSpiritId) && _cache.TryGetValue(playerSpiritId, ref cacheEntry))
		{
			int num = Interlocked.Decrement(ref cacheEntry.ReferenceCount);
			if (num <= 0)
			{
				cacheEntry.LastAccess = DateTimeOffset.UtcNow;
			}
			Debug.WriteLine($"[Cache] Released model: {playerSpiritId} (refCount={num})");
		}
	}

	public SpiritCardModel? GetIfCached(string playerSpiritId)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(playerSpiritId))
		{
			return null;
		}
		CacheEntry cacheEntry = default(CacheEntry);
		if (_cache.TryGetValue(playerSpiritId, ref cacheEntry))
		{
			cacheEntry.LastAccess = DateTimeOffset.UtcNow;
			return cacheEntry.Model;
		}
		return null;
	}

	public void Evict(string playerSpiritId)
	{
		CacheEntry cacheEntry = default(CacheEntry);
		if (_cache.TryRemove(playerSpiritId, ref cacheEntry))
		{
			cacheEntry.Model.Dispose();
			Debug.WriteLine("[Cache] Force evicted model: " + playerSpiritId);
		}
	}

	public void Clear()
	{
		global::System.Collections.Generic.IEnumerator<CacheEntry> enumerator = ((global::System.Collections.Generic.IEnumerable<CacheEntry>)_cache.Values).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				CacheEntry current = enumerator.Current;
				current.Model.Dispose();
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
		_cache.Clear();
		Debug.WriteLine("[Cache] Cleared all models");
	}

	private void EvictColdEntries()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		if (_disposed)
		{
			return;
		}
		DateTimeOffset utcNow = DateTimeOffset.UtcNow;
		DateTimeOffset coldThreshold = ((DateTimeOffset)(ref utcNow)).AddSeconds(-120.0);
		List<KeyValuePair<string, CacheEntry>> val = Enumerable.ToList<KeyValuePair<string, CacheEntry>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, CacheEntry>>)Enumerable.OrderBy<KeyValuePair<string, CacheEntry>, DateTimeOffset>(Enumerable.Where<KeyValuePair<string, CacheEntry>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, CacheEntry>>)_cache, (Func<KeyValuePair<string, CacheEntry>, bool>)((KeyValuePair<string, CacheEntry> kvp) => kvp.Value.ReferenceCount <= 0 && kvp.Value.LastAccess < coldThreshold)), (Func<KeyValuePair<string, CacheEntry>, DateTimeOffset>)((KeyValuePair<string, CacheEntry> kvp) => kvp.Value.LastAccess)));
		global::System.Collections.Generic.IEnumerable<KeyValuePair<string, CacheEntry>> enumerable = ((val.Count > 20) ? Enumerable.Take<KeyValuePair<string, CacheEntry>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, CacheEntry>>)val, val.Count - 20) : Enumerable.Where<KeyValuePair<string, CacheEntry>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, CacheEntry>>)val, (Func<KeyValuePair<string, CacheEntry>, bool>)((KeyValuePair<string, CacheEntry> e) => e.Value.LastAccess < coldThreshold)));
		global::System.Collections.Generic.IEnumerator<KeyValuePair<string, CacheEntry>> enumerator = enumerable.GetEnumerator();
		try
		{
			CacheEntry cacheEntry = default(CacheEntry);
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				KeyValuePair<string, CacheEntry> current = enumerator.Current;
				if (_cache.TryRemove(current.Key, ref cacheEntry))
				{
					cacheEntry.Model.Dispose();
					Debug.WriteLine("[Cache] Evicted cold model: " + current.Key);
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
	}

	public CacheStats GetStats()
	{
		List<CacheEntry> val = Enumerable.ToList<CacheEntry>((global::System.Collections.Generic.IEnumerable<CacheEntry>)_cache.Values);
		return new CacheStats
		{
			TotalCount = val.Count,
			ActiveCount = Enumerable.Count<CacheEntry>((global::System.Collections.Generic.IEnumerable<CacheEntry>)val, (Func<CacheEntry, bool>)((CacheEntry e) => e.ReferenceCount > 0)),
			ColdCount = Enumerable.Count<CacheEntry>((global::System.Collections.Generic.IEnumerable<CacheEntry>)val, (Func<CacheEntry, bool>)((CacheEntry e) => e.ReferenceCount <= 0)),
			TotalReferences = Enumerable.Sum<CacheEntry>((global::System.Collections.Generic.IEnumerable<CacheEntry>)val, (Func<CacheEntry, int>)((CacheEntry e) => Math.Max(0, e.ReferenceCount)))
		};
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			_disposed = true;
			_stateService.StateChanged -= OnStateChanged;
			_evictionTimer.Dispose();
			Clear();
			_createLock.Dispose();
		}
	}
}
