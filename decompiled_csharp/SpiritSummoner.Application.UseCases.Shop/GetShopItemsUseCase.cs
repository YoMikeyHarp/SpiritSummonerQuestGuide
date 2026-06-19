using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Shop;

public class GetShopItemsUseCase : IUseCase<GetShopItemsRequest, GetShopItemsResponse>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public GetShopItemsRequest request;

		public Player player;

		internal bool _003CExecuteAsync_003Eb__0(Item i)
		{
			return i.Requirements?.CurrencyCost?.Type == request.CurrencyType;
		}

		internal ShopItemResult _003CExecuteAsync_003Eb__1(Item item)
		{
			int valueOrDefault = (item.Requirements?.LevelRequirement?.PlayerLevelRequired).GetValueOrDefault(1);
			bool isNew = valueOrDefault > player.LastShopViewedLevel && !string.IsNullOrEmpty(item.ID) && !Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)player.ViewedShopItems, item.ID);
			return new ShopItemResult(item, isNew);
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<GetShopItemsResponse>> _003C_003Et__builder;

		public GetShopItemsRequest request;

		public GetShopItemsUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass3_0 _003C_003E8__1;

		private global::System.Collections.Generic.IReadOnlyList<Item> _003Citems_003E5__2;

		private List<ShopItemResult> _003CitemsWithNewFlag_003E5__3;

		private global::System.Collections.Generic.IReadOnlyList<Item> _003C_003Es__4;

		private TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Item>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<GetShopItemsResponse> result;
			try
			{
				TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Item>> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Item>>);
					num = (_003C_003E1__state = -1);
					goto IL_00ee;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass3_0();
				_003C_003E8__1.request = request;
				_003C_003E8__1.player = _003C_003E4__this._stateService.GetCurrentPlayer();
				if (_003C_003E8__1.player != null)
				{
					awaiter = _003C_003E4__this._itemRepository.GetItemsByTypeAndLevel(_003C_003E8__1.request.ItemTypes, _003C_003E8__1.player.PlayerLevel).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Item>>, _003CExecuteAsync_003Ed__3>(ref awaiter, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_00ee;
				}
				result = Result<GetShopItemsResponse>.FailureResult("No active session");
				goto end_IL_0007;
				IL_00ee:
				_003C_003Es__4 = awaiter.GetResult();
				_003Citems_003E5__2 = _003C_003Es__4;
				_003C_003Es__4 = null;
				if (!string.IsNullOrEmpty(_003C_003E8__1.request.CurrencyType))
				{
					_003Citems_003E5__2 = (global::System.Collections.Generic.IReadOnlyList<Item>)Enumerable.ToList<Item>(Enumerable.Where<Item>((global::System.Collections.Generic.IEnumerable<Item>)_003Citems_003E5__2, (Func<Item, bool>)((Item i) => i.Requirements?.CurrencyCost?.Type == _003C_003E8__1.request.CurrencyType)));
				}
				_003CitemsWithNewFlag_003E5__3 = Enumerable.ToList<ShopItemResult>(Enumerable.Select<Item, ShopItemResult>((global::System.Collections.Generic.IEnumerable<Item>)_003Citems_003E5__2, (Func<Item, ShopItemResult>)delegate(Item item)
				{
					int valueOrDefault = (item.Requirements?.LevelRequirement?.PlayerLevelRequired).GetValueOrDefault(1);
					bool isNew = valueOrDefault > _003C_003E8__1.player.LastShopViewedLevel && !string.IsNullOrEmpty(item.ID) && !Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)_003C_003E8__1.player.ViewedShopItems, item.ID);
					return new ShopItemResult(item, isNew);
				}));
				result = Result<GetShopItemsResponse>.SuccessResult(new GetShopItemsResponse(_003CitemsWithNewFlag_003E5__3));
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Citems_003E5__2 = null;
				_003CitemsWithNewFlag_003E5__3 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Citems_003E5__2 = null;
			_003CitemsWithNewFlag_003E5__3 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IPlayerStateService _stateService;

	private readonly IItemRepository _itemRepository;

	public GetShopItemsUseCase(IPlayerStateService stateService, IItemRepository itemRepository)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
		_itemRepository = itemRepository ?? throw new ArgumentNullException("itemRepository");
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__3))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<GetShopItemsResponse>> ExecuteAsync(GetShopItemsRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		GetShopItemsRequest request2 = request;
		Player player = _stateService.GetCurrentPlayer();
		if (player == null)
		{
			return Result<GetShopItemsResponse>.FailureResult("No active session");
		}
		global::System.Collections.Generic.IReadOnlyList<Item> items = await _itemRepository.GetItemsByTypeAndLevel(request2.ItemTypes, player.PlayerLevel);
		if (!string.IsNullOrEmpty(request2.CurrencyType))
		{
			items = (global::System.Collections.Generic.IReadOnlyList<Item>)Enumerable.ToList<Item>(Enumerable.Where<Item>((global::System.Collections.Generic.IEnumerable<Item>)items, (Func<Item, bool>)((Item i) => i.Requirements?.CurrencyCost?.Type == request2.CurrencyType)));
		}
		List<ShopItemResult> itemsWithNewFlag = Enumerable.ToList<ShopItemResult>(Enumerable.Select<Item, ShopItemResult>((global::System.Collections.Generic.IEnumerable<Item>)items, (Func<Item, ShopItemResult>)delegate(Item item)
		{
			int valueOrDefault = (item.Requirements?.LevelRequirement?.PlayerLevelRequired).GetValueOrDefault(1);
			bool isNew = valueOrDefault > player.LastShopViewedLevel && !string.IsNullOrEmpty(item.ID) && !Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)player.ViewedShopItems, item.ID);
			return new ShopItemResult(item, isNew);
		}));
		return Result<GetShopItemsResponse>.SuccessResult(new GetShopItemsResponse(itemsWithNewFlag));
	}
}
