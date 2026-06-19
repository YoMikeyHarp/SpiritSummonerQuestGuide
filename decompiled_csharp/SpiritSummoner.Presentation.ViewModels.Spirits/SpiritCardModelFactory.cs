using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Presentation.Models;

namespace SpiritSummoner.Presentation.ViewModels.Spirits;

public class SpiritCardModelFactory
{
	[CompilerGenerated]
	private sealed class _003CCreateModelAsync_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<SpiritCardModel> _003C_003Et__builder;

		public string playerSpiritId;

		public SpiritCardModelFactory _003C_003E4__this;

		private SpiritCardModel _003C_003Es__1;

		private TaskAwaiter<SpiritCardModel> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			SpiritCardModel result;
			try
			{
				TaskAwaiter<SpiritCardModel> awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._cache.AcquireAsync(playerSpiritId).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CCreateModelAsync_003Ed__2 _003CCreateModelAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<SpiritCardModel>, _003CCreateModelAsync_003Ed__2>(ref awaiter, ref _003CCreateModelAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<SpiritCardModel>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__1 = awaiter.GetResult();
				result = _003C_003Es__1;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly SpiritCardModelCache _cache;

	public SpiritCardModelFactory(SpiritCardModelCache cache)
	{
		_cache = cache;
	}

	[AsyncStateMachine(typeof(_003CCreateModelAsync_003Ed__2))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<SpiritCardModel> CreateModelAsync(string playerSpiritId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return await _cache.AcquireAsync(playerSpiritId);
	}

	public void ReleaseModel(string playerSpiritId)
	{
		_cache.Release(playerSpiritId);
	}

	public SpiritCardModel? GetCachedModel(string playerSpiritId)
	{
		return _cache.GetIfCached(playerSpiritId);
	}

	public void EvictModel(string playerSpiritId)
	{
		_cache.Evict(playerSpiritId);
	}

	public SpiritCardModelCache.CacheStats GetCacheStats()
	{
		return _cache.GetStats();
	}
}
