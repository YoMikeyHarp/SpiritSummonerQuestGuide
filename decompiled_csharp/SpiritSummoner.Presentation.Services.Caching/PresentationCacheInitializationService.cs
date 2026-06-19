using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using SpiritSummoner.Application.State;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Presentation.ViewModels.Battles;
using SpiritSummoner.Presentation.ViewModels.BottomSheet;
using SpiritSummoner.Presentation.ViewModels.Collections;
using SpiritSummoner.Presentation.ViewModels.Guilds;
using SpiritSummoner.Presentation.ViewModels.Pouch;
using SpiritSummoner.Presentation.ViewModels.Quests;
using SpiritSummoner.Presentation.ViewModels.Shared;
using SpiritSummoner.Presentation.ViewModels.Shop;
using SpiritSummoner.Presentation.ViewModels.StartUp;
using SpiritSummoner.Presentation.Views;
using SpiritSummoner.Presentation.Views.Battle;
using SpiritSummoner.Presentation.Views.BottomSheets.Hub;
using SpiritSummoner.Presentation.Views.BottomSheets.Portal;
using SpiritSummoner.Presentation.Views.BottomSheets.SpiritSheets;
using SpiritSummoner.Presentation.Views.BottomSheets.SquadSheets;
using SpiritSummoner.Presentation.Views.Guilds;
using SpiritSummoner.Presentation.Views.Quests;
using SpiritSummoner.Presentation.Views.Shop;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.Services.Caching;

public class PresentationCacheInitializationService : IPresentationCacheInitializationService
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		private sealed class _003C_003CInitializeAsync_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass8_0 _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
				//IL_0066: Unknown result type (might be due to invalid IL or missing references)
				//IL_006b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0072: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
				//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
				//IL_013c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0141: Unknown result type (might be due to invalid IL or missing references)
				//IL_0149: Unknown result type (might be due to invalid IL or missing references)
				//IL_002f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0034: Unknown result type (might be due to invalid IL or missing references)
				//IL_0099: Unknown result type (might be due to invalid IL or missing references)
				//IL_009e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0103: Unknown result type (might be due to invalid IL or missing references)
				//IL_0108: Unknown result type (might be due to invalid IL or missing references)
				//IL_0048: Unknown result type (might be due to invalid IL or missing references)
				//IL_0049: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
				//IL_011d: Unknown result type (might be due to invalid IL or missing references)
				//IL_011f: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter awaiter3;
					TaskAwaiter awaiter2;
					TaskAwaiter awaiter;
					switch (num)
					{
					default:
						awaiter3 = global::System.Threading.Tasks.Task.Delay(100).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003C_003CInitializeAsync_003Eb__0_003Ed _003C_003CInitializeAsync_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003CInitializeAsync_003Eb__0_003Ed>(ref awaiter3, ref _003C_003CInitializeAsync_003Eb__0_003Ed);
							return;
						}
						goto IL_0081;
					case 0:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0081;
					case 1:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_00eb;
					case 2:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_00eb:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						awaiter = _003C_003E4__this._003C_003E4__this.CacheBottomSheetsAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = awaiter;
							_003C_003CInitializeAsync_003Eb__0_003Ed _003C_003CInitializeAsync_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003CInitializeAsync_003Eb__0_003Ed>(ref awaiter, ref _003C_003CInitializeAsync_003Eb__0_003Ed);
							return;
						}
						break;
						IL_0081:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						awaiter2 = _003C_003E4__this._003C_003E4__this.CacheSecondaryPagesAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter2;
							_003C_003CInitializeAsync_003Eb__0_003Ed _003C_003CInitializeAsync_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003CInitializeAsync_003Eb__0_003Ed>(ref awaiter2, ref _003C_003CInitializeAsync_003Eb__0_003Ed);
							return;
						}
						goto IL_00eb;
					}
					((TaskAwaiter)(ref awaiter)).GetResult();
					Console.WriteLine($"Background presentation cache warming completed in {_003C_003E4__this.sw.ElapsedMilliseconds}ms");
				}
				catch (global::System.Exception exception)
				{
					_003C_003E1__state = -2;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}
		}

		public PresentationCacheInitializationService _003C_003E4__this;

		public Stopwatch sw;

		[AsyncStateMachine(typeof(_003C_003CInitializeAsync_003Eb__0_003Ed))]
		[DebuggerStepThrough]
		internal global::System.Threading.Tasks.Task? _003CInitializeAsync_003Eb__0()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003CInitializeAsync_003Eb__0_003Ed _003C_003CInitializeAsync_003Eb__0_003Ed = new _003C_003CInitializeAsync_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CInitializeAsync_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003CInitializeAsync_003Eb__0_003Ed>(ref _003C_003CInitializeAsync_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CInitializeAsync_003Eb__0_003Ed._003C_003Et__builder)).Task;
		}
	}

	[CompilerGenerated]
	private sealed class _003CCacheBottomSheetsAsync_003Ed__11 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PresentationCacheInitializationService _003C_003E4__this;

		private HubSheetViewModel _003ChubVM_003E5__1;

		private PortalSheetViewModel _003CportalVM_003E5__2;

		private SpiritsHoldNavigationSheetViewModel _003CspiritHoldNavVM_003E5__3;

		private global::System.Exception _003Cex_003E5__4;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			try
			{
				try
				{
					_003C_003E4__this._pageCacheService.CacheSheetPage("savedsquads", [CompilerGenerated] () => (BottomSheet)(object)ServiceProviderServiceExtensions.GetRequiredService<SavedSquadsBottomSheet>(_003C_003E4__this._serviceProvider));
					_003C_003E4__this._pageCacheService.CacheSheetPage("hub", [CompilerGenerated] () => (BottomSheet)(object)ServiceProviderServiceExtensions.GetRequiredService<HubBottomSheet>(_003C_003E4__this._serviceProvider));
					_003ChubVM_003E5__1 = ServiceProviderServiceExtensions.GetRequiredService<HubSheetViewModel>(_003C_003E4__this._serviceProvider);
					_003C_003E4__this._pageCacheService.CacheSheetVM("hub", _003ChubVM_003E5__1);
					_003C_003E4__this._pageCacheService.CacheSheetPage("portal", [CompilerGenerated] () => (BottomSheet)(object)ServiceProviderServiceExtensions.GetRequiredService<PortalBottomSheet>(_003C_003E4__this._serviceProvider));
					_003CportalVM_003E5__2 = ServiceProviderServiceExtensions.GetRequiredService<PortalSheetViewModel>(_003C_003E4__this._serviceProvider);
					_003C_003E4__this._pageCacheService.CacheSheetVM("portal", _003CportalVM_003E5__2);
					_003C_003E4__this._pageCacheService.CacheSheetPage("spiritholdnav", [CompilerGenerated] () => (BottomSheet)(object)ServiceProviderServiceExtensions.GetRequiredService<SpiritHoldNavigationSheet>(_003C_003E4__this._serviceProvider));
					_003CspiritHoldNavVM_003E5__3 = ServiceProviderServiceExtensions.GetRequiredService<SpiritsHoldNavigationSheetViewModel>(_003C_003E4__this._serviceProvider);
					_003C_003E4__this._pageCacheService.CacheSheetVM("spiritholdnav", _003CspiritHoldNavVM_003E5__3);
					Console.WriteLine("Bottomsheet cache completed");
					_003ChubVM_003E5__1 = null;
					_003CportalVM_003E5__2 = null;
					_003CspiritHoldNavVM_003E5__3 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					Console.WriteLine("cache bottom failed" + _003Cex_003E5__4.Message);
					Console.WriteLine(_003Cex_003E5__4.StackTrace);
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCacheMainPageAsync_003Ed__9 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PresentationCacheInitializationService _003C_003E4__this;

		private QuestViewModel _003CquestVM_003E5__1;

		private ILoadableViewModel _003Cloadableq_003E5__2;

		private MainViewModel _003CmainVM_003E5__3;

		private ILoadableViewModel _003CloadableMain_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				TaskAwaiter awaiter2;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01cd;
					}
					_003C_003E4__this._pageCacheService.CacheMainPage("//quest", [CompilerGenerated] () => (ContentView)(object)ServiceProviderServiceExtensions.GetRequiredService<QuestView>(_003C_003E4__this._serviceProvider));
					_003CquestVM_003E5__1 = ServiceProviderServiceExtensions.GetRequiredService<QuestViewModel>(_003C_003E4__this._serviceProvider);
					_003C_003E4__this._pageCacheService.CacheMainVM("//quest", _003CquestVM_003E5__1);
					_003Cloadableq_003E5__2 = _003CquestVM_003E5__1;
					if (_003Cloadableq_003E5__2 == null)
					{
						goto IL_00f7;
					}
					awaiter2 = _003Cloadableq_003E5__2.LoadDataAsync(null).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003CCacheMainPageAsync_003Ed__9 _003CCacheMainPageAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCacheMainPageAsync_003Ed__9>(ref awaiter2, ref _003CCacheMainPageAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TaskAwaiter)(ref awaiter2)).GetResult();
				goto IL_00f7;
				IL_01cd:
				((TaskAwaiter)(ref awaiter)).GetResult();
				goto end_IL_0007;
				IL_00f7:
				_003C_003E4__this._pageCacheService.CacheMainPage("//main", [CompilerGenerated] () => (ContentView)(object)ServiceProviderServiceExtensions.GetRequiredService<MainPage>(_003C_003E4__this._serviceProvider));
				_003CmainVM_003E5__3 = ServiceProviderServiceExtensions.GetRequiredService<MainViewModel>(_003C_003E4__this._serviceProvider);
				_003C_003E4__this._pageCacheService.CacheMainVM("//main", _003CmainVM_003E5__3);
				_003CloadableMain_003E5__4 = _003CmainVM_003E5__3;
				if (_003CloadableMain_003E5__4 != null)
				{
					awaiter = _003CloadableMain_003E5__4.LoadDataAsync(null).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter;
						_003CCacheMainPageAsync_003Ed__9 _003CCacheMainPageAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCacheMainPageAsync_003Ed__9>(ref awaiter, ref _003CCacheMainPageAsync_003Ed__);
						return;
					}
					goto IL_01cd;
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CquestVM_003E5__1 = null;
				_003Cloadableq_003E5__2 = null;
				_003CmainVM_003E5__3 = null;
				_003CloadableMain_003E5__4 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CquestVM_003E5__1 = null;
			_003Cloadableq_003E5__2 = null;
			_003CmainVM_003E5__3 = null;
			_003CloadableMain_003E5__4 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCacheSecondaryPagesAsync_003Ed__10 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PresentationCacheInitializationService _003C_003E4__this;

		private CollectionHubViewModel _003CcollectionVM_003E5__1;

		private ILoadableViewModel _003Cloadable_003E5__2;

		private GuildHubViewModel _003CguildVM_003E5__3;

		private ILoadableViewModel _003Cloadable1_003E5__4;

		private BattleHubViewModel _003CbattleVM_003E5__5;

		private ILoadableViewModel _003Cloadable2_003E5__6;

		private ShopHubViewModel _003CshopVM_003E5__7;

		private ILoadableViewModel _003Cloadable3_003E5__8;

		private PouchViewModel _003CpouchVM_003E5__9;

		private ILoadableViewModel _003Cloadable4_003E5__10;

		private global::System.Exception _003Cex_003E5__11;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_028e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0293: Unknown result type (might be due to invalid IL or missing references)
			//IL_029b: Unknown result type (might be due to invalid IL or missing references)
			//IL_036b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0370: Unknown result type (might be due to invalid IL or missing references)
			//IL_0378: Unknown result type (might be due to invalid IL or missing references)
			//IL_0421: Unknown result type (might be due to invalid IL or missing references)
			//IL_0426: Unknown result type (might be due to invalid IL or missing references)
			//IL_042e: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0255: Unknown result type (might be due to invalid IL or missing references)
			//IL_025a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0332: Unknown result type (might be due to invalid IL or missing references)
			//IL_0337: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_026f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0271: Unknown result type (might be due to invalid IL or missing references)
			//IL_034c: Unknown result type (might be due to invalid IL or missing references)
			//IL_034e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0402: Unknown result type (might be due to invalid IL or missing references)
			//IL_0404: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 4u)
				{
				}
				try
				{
					TaskAwaiter awaiter5;
					TaskAwaiter awaiter4;
					TaskAwaiter awaiter3;
					TaskAwaiter awaiter2;
					TaskAwaiter awaiter;
					switch (num)
					{
					default:
						_003CcollectionVM_003E5__1 = ServiceProviderServiceExtensions.GetRequiredService<CollectionHubViewModel>(_003C_003E4__this._serviceProvider);
						_003C_003E4__this._pageCacheService.CacheDeepVM("//collection", _003CcollectionVM_003E5__1);
						_003Cloadable_003E5__2 = _003CcollectionVM_003E5__1;
						if (_003Cloadable_003E5__2 != null)
						{
							awaiter5 = _003Cloadable_003E5__2.LoadDataAsync(null).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter5;
								_003CCacheSecondaryPagesAsync_003Ed__10 _003CCacheSecondaryPagesAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCacheSecondaryPagesAsync_003Ed__10>(ref awaiter5, ref _003CCacheSecondaryPagesAsync_003Ed__);
								return;
							}
							goto IL_00f0;
						}
						goto IL_00f8;
					case 0:
						awaiter5 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_00f0;
					case 1:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01cd;
					case 2:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_02aa;
					case 3:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0387;
					case 4:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_043d;
						}
						IL_0387:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						goto IL_038f;
						IL_02aa:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						goto IL_02b2;
						IL_00f0:
						((TaskAwaiter)(ref awaiter5)).GetResult();
						goto IL_00f8;
						IL_00f8:
						_003C_003E4__this._pageCacheService.CacheMainPage("//guild", [CompilerGenerated] () => (ContentView)(object)ServiceProviderServiceExtensions.GetRequiredService<GuildHubNewPage>(_003C_003E4__this._serviceProvider));
						_003CguildVM_003E5__3 = ServiceProviderServiceExtensions.GetRequiredService<GuildHubViewModel>(_003C_003E4__this._serviceProvider);
						_003C_003E4__this._pageCacheService.CacheMainVM("//guild", _003CguildVM_003E5__3);
						_003Cloadable1_003E5__4 = _003CguildVM_003E5__3;
						if (_003Cloadable1_003E5__4 != null)
						{
							awaiter4 = _003Cloadable1_003E5__4.LoadDataAsync(null).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter4;
								_003CCacheSecondaryPagesAsync_003Ed__10 _003CCacheSecondaryPagesAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCacheSecondaryPagesAsync_003Ed__10>(ref awaiter4, ref _003CCacheSecondaryPagesAsync_003Ed__);
								return;
							}
							goto IL_01cd;
						}
						goto IL_01d5;
						IL_02b2:
						_003C_003E4__this._pageCacheService.CacheMainPage("//shop", [CompilerGenerated] () => (ContentView)(object)ServiceProviderServiceExtensions.GetRequiredService<ShopHubPage>(_003C_003E4__this._serviceProvider));
						_003CshopVM_003E5__7 = ServiceProviderServiceExtensions.GetRequiredService<ShopHubViewModel>(_003C_003E4__this._serviceProvider);
						_003C_003E4__this._pageCacheService.CacheMainVM("//shop", _003CshopVM_003E5__7);
						_003Cloadable3_003E5__8 = _003CshopVM_003E5__7;
						if (_003Cloadable3_003E5__8 != null)
						{
							awaiter2 = _003Cloadable3_003E5__8.LoadDataAsync(null).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__1 = awaiter2;
								_003CCacheSecondaryPagesAsync_003Ed__10 _003CCacheSecondaryPagesAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCacheSecondaryPagesAsync_003Ed__10>(ref awaiter2, ref _003CCacheSecondaryPagesAsync_003Ed__);
								return;
							}
							goto IL_0387;
						}
						goto IL_038f;
						IL_038f:
						_003CpouchVM_003E5__9 = ServiceProviderServiceExtensions.GetRequiredService<PouchViewModel>(_003C_003E4__this._serviceProvider);
						_003C_003E4__this._pageCacheService.CacheDeepVM("//pouch", _003CpouchVM_003E5__9);
						_003Cloadable4_003E5__10 = _003CpouchVM_003E5__9;
						if (_003Cloadable4_003E5__10 == null)
						{
							break;
						}
						awaiter = _003Cloadable4_003E5__10.LoadDataAsync(null).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 4);
							_003C_003Eu__1 = awaiter;
							_003CCacheSecondaryPagesAsync_003Ed__10 _003CCacheSecondaryPagesAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCacheSecondaryPagesAsync_003Ed__10>(ref awaiter, ref _003CCacheSecondaryPagesAsync_003Ed__);
							return;
						}
						goto IL_043d;
						IL_01cd:
						((TaskAwaiter)(ref awaiter4)).GetResult();
						goto IL_01d5;
						IL_01d5:
						_003C_003E4__this._pageCacheService.CacheMainPage("//battlehub", [CompilerGenerated] () => (ContentView)(object)ServiceProviderServiceExtensions.GetRequiredService<BattleHubPage>(_003C_003E4__this._serviceProvider));
						_003CbattleVM_003E5__5 = ServiceProviderServiceExtensions.GetRequiredService<BattleHubViewModel>(_003C_003E4__this._serviceProvider);
						_003C_003E4__this._pageCacheService.CacheMainVM("//battlehub", _003CbattleVM_003E5__5);
						_003Cloadable2_003E5__6 = _003CbattleVM_003E5__5;
						if (_003Cloadable2_003E5__6 != null)
						{
							awaiter3 = _003Cloadable2_003E5__6.LoadDataAsync(null).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__1 = awaiter3;
								_003CCacheSecondaryPagesAsync_003Ed__10 _003CCacheSecondaryPagesAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCacheSecondaryPagesAsync_003Ed__10>(ref awaiter3, ref _003CCacheSecondaryPagesAsync_003Ed__);
								return;
							}
							goto IL_02aa;
						}
						goto IL_02b2;
						IL_043d:
						((TaskAwaiter)(ref awaiter)).GetResult();
						break;
					}
					Console.WriteLine("Secondary cache completed");
					_003CcollectionVM_003E5__1 = null;
					_003Cloadable_003E5__2 = null;
					_003CguildVM_003E5__3 = null;
					_003Cloadable1_003E5__4 = null;
					_003CbattleVM_003E5__5 = null;
					_003Cloadable2_003E5__6 = null;
					_003CshopVM_003E5__7 = null;
					_003Cloadable3_003E5__8 = null;
					_003CpouchVM_003E5__9 = null;
					_003Cloadable4_003E5__10 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__11 = ex;
					Console.WriteLine("cache seconday failed" + _003Cex_003E5__11.Message);
					Console.WriteLine(_003Cex_003E5__11.StackTrace);
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CInitializeAsync_003Ed__8 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public bool showProgress;

		public PresentationCacheInitializationService _003C_003E4__this;

		private _003C_003Ec__DisplayClass8_0 _003C_003E8__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00d9;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass8_0();
				_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
				if (!_003C_003E4__this._isInitialized)
				{
					IPlayerStateService sessionManager = _003C_003E4__this._sessionManager;
					if (new Func<Player>(sessionManager.GetCurrentPlayer) != null)
					{
						Console.WriteLine("Starting presentation cache warming...");
						_003C_003E8__1.sw = Stopwatch.StartNew();
						awaiter = _003C_003E4__this.CacheMainPageAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CInitializeAsync_003Ed__8 _003CInitializeAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CInitializeAsync_003Ed__8>(ref awaiter, ref _003CInitializeAsync_003Ed__);
							return;
						}
						goto IL_00d9;
					}
				}
				goto end_IL_0007;
				IL_00d9:
				((TaskAwaiter)(ref awaiter)).GetResult();
				global::System.Threading.Tasks.Task.Run((Func<global::System.Threading.Tasks.Task>)([AsyncStateMachine(typeof(_003C_003Ec__DisplayClass8_0._003C_003CInitializeAsync_003Eb__0_003Ed))] [DebuggerStepThrough] () =>
				{
					//IL_0007: Unknown result type (might be due to invalid IL or missing references)
					//IL_000c: Unknown result type (might be due to invalid IL or missing references)
					_003C_003Ec__DisplayClass8_0._003C_003CInitializeAsync_003Eb__0_003Ed _003C_003CInitializeAsync_003Eb__0_003Ed = new _003C_003Ec__DisplayClass8_0._003C_003CInitializeAsync_003Eb__0_003Ed
					{
						_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
						_003C_003E4__this = _003C_003E8__1,
						_003C_003E1__state = -1
					};
					((AsyncTaskMethodBuilder)(ref _003C_003CInitializeAsync_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass8_0._003C_003CInitializeAsync_003Eb__0_003Ed>(ref _003C_003CInitializeAsync_003Eb__0_003Ed);
					return ((AsyncTaskMethodBuilder)(ref _003C_003CInitializeAsync_003Eb__0_003Ed._003C_003Et__builder)).Task;
				}));
				_003C_003E4__this._isInitialized = true;
				Console.WriteLine($"Priority presentation cache warming completed in {_003C_003E8__1.sw.ElapsedMilliseconds}ms");
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IPageCacheService _pageCacheService;

	private readonly IServiceProvider _serviceProvider;

	private readonly IPlayerStateService _sessionManager;

	private readonly NavBarViewModel _navbarVM;

	private bool _isInitialized = false;

	public bool IsInitialized => _isInitialized;

	public PresentationCacheInitializationService(IPageCacheService pageCacheService, IServiceProvider serviceProvider, IPlayerStateService sessionManager, NavBarViewModel navBarViewModel)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		_pageCacheService = pageCacheService ?? throw new ArgumentNullException("pageCacheService");
		_serviceProvider = serviceProvider ?? throw new ArgumentNullException("serviceProvider");
		_sessionManager = sessionManager ?? throw new ArgumentNullException("sessionManager");
		_navbarVM = navBarViewModel ?? throw new ArgumentNullException("navBarViewModel");
	}

	[AsyncStateMachine(typeof(_003CInitializeAsync_003Ed__8))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task InitializeAsync(bool showProgress = false)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CInitializeAsync_003Ed__8 _003CInitializeAsync_003Ed__ = new _003CInitializeAsync_003Ed__8();
		_003CInitializeAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CInitializeAsync_003Ed__._003C_003E4__this = this;
		_003CInitializeAsync_003Ed__.showProgress = showProgress;
		_003CInitializeAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CInitializeAsync_003Ed__._003C_003Et__builder)).Start<_003CInitializeAsync_003Ed__8>(ref _003CInitializeAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CInitializeAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CCacheMainPageAsync_003Ed__9))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task CacheMainPageAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CCacheMainPageAsync_003Ed__9 _003CCacheMainPageAsync_003Ed__ = new _003CCacheMainPageAsync_003Ed__9();
		_003CCacheMainPageAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CCacheMainPageAsync_003Ed__._003C_003E4__this = this;
		_003CCacheMainPageAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CCacheMainPageAsync_003Ed__._003C_003Et__builder)).Start<_003CCacheMainPageAsync_003Ed__9>(ref _003CCacheMainPageAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CCacheMainPageAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CCacheSecondaryPagesAsync_003Ed__10))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task CacheSecondaryPagesAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CCacheSecondaryPagesAsync_003Ed__10 _003CCacheSecondaryPagesAsync_003Ed__ = new _003CCacheSecondaryPagesAsync_003Ed__10();
		_003CCacheSecondaryPagesAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CCacheSecondaryPagesAsync_003Ed__._003C_003E4__this = this;
		_003CCacheSecondaryPagesAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CCacheSecondaryPagesAsync_003Ed__._003C_003Et__builder)).Start<_003CCacheSecondaryPagesAsync_003Ed__10>(ref _003CCacheSecondaryPagesAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CCacheSecondaryPagesAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CCacheBottomSheetsAsync_003Ed__11))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task CacheBottomSheetsAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CCacheBottomSheetsAsync_003Ed__11 _003CCacheBottomSheetsAsync_003Ed__ = new _003CCacheBottomSheetsAsync_003Ed__11();
		_003CCacheBottomSheetsAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CCacheBottomSheetsAsync_003Ed__._003C_003E4__this = this;
		_003CCacheBottomSheetsAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CCacheBottomSheetsAsync_003Ed__._003C_003Et__builder)).Start<_003CCacheBottomSheetsAsync_003Ed__11>(ref _003CCacheBottomSheetsAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CCacheBottomSheetsAsync_003Ed__._003C_003Et__builder)).Task;
	}

	public void InvalidateCache()
	{
		_isInitialized = false;
		_pageCacheService.EvictAll();
		_navbarVM.CurrentPage = null;
		Console.WriteLine("Presentation cache invalidated");
	}
}
