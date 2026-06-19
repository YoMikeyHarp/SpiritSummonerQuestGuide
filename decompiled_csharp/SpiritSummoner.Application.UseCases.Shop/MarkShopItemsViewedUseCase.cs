using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Enums.Items;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Shop;

public class MarkShopItemsViewedUseCase : IUseCase<MarkShopItemsViewedRequest, MarkShopItemsViewedResponse>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public Player player;

		public List<string> newViewedItems;

		internal bool _003CExecuteAsync_003Eb__0(Item item)
		{
			return !string.IsNullOrEmpty(item.ID) && !Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)player.ViewedShopItems, item.ID);
		}

		internal _003C_003Ef__AnonymousType7<int> _003CExecuteAsync_003Eb__3(Player p)
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			Enumerator<string> enumerator = newViewedItems.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					p.AddViewedShopItem(current);
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator).Dispose();
			}
			p.SetLastShopViewedLevel(p.PlayerLevel);
			return new
			{
				ItemsMarked = newViewedItems.Count
			};
		}

		internal PlayerBatchUpdate _003CExecuteAsync_003Eb__4(Player p, _003C_003Ef__AnonymousType7<int> updateResult)
		{
			return new PlayerBatchUpdate
			{
				PlayerId = (p.PlayerID ?? string.Empty),
				ViewedShopItems = newViewedItems,
				LastShopViewedLevel = p.PlayerLevel
			};
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<MarkShopItemsViewedResponse>> _003C_003Et__builder;

		public MarkShopItemsViewedRequest request;

		public MarkShopItemsViewedUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass3_0 _003C_003E8__1;

		private List<ItemType> _003CitemTypes_003E5__2;

		private global::System.Collections.Generic.IReadOnlyList<Item> _003CallAvailableItems_003E5__3;

		private Result<_003C_003Ef__AnonymousType7<int>> _003Cresult_003E5__4;

		private global::System.Collections.Generic.IReadOnlyList<Item> _003C_003Es__5;

		private TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Item>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<MarkShopItemsViewedResponse> result;
			try
			{
				TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Item>> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Item>>);
					num = (_003C_003E1__state = -1);
					goto IL_0106;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass3_0();
				_003C_003E8__1.player = _003C_003E4__this._stateService.GetCurrentPlayer();
				if (_003C_003E8__1.player != null)
				{
					List<ItemType> obj = new List<ItemType>();
					obj.Add(ItemType.booster);
					obj.Add(ItemType.unlock);
					obj.Add(ItemType.items);
					obj.Add(ItemType.gear);
					obj.Add(ItemType.talent);
					_003CitemTypes_003E5__2 = obj;
					awaiter = _003C_003E4__this._itemRepository.GetItemsByTypeAndLevel(_003CitemTypes_003E5__2, _003C_003E8__1.player.PlayerLevel).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Item>>, _003CExecuteAsync_003Ed__3>(ref awaiter, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_0106;
				}
				result = Result<MarkShopItemsViewedResponse>.FailureResult("No active session");
				goto end_IL_0007;
				IL_0106:
				_003C_003Es__5 = awaiter.GetResult();
				_003CallAvailableItems_003E5__3 = _003C_003Es__5;
				_003C_003Es__5 = null;
				_003C_003E8__1.newViewedItems = Enumerable.ToList<string>(Enumerable.Select<Item, string>(Enumerable.Where<Item>((global::System.Collections.Generic.IEnumerable<Item>)_003CallAvailableItems_003E5__3, (Func<Item, bool>)((Item item) => !string.IsNullOrEmpty(item.ID) && !Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)_003C_003E8__1.player.ViewedShopItems, item.ID))), (Func<Item, string>)((Item item) => item.ID)));
				if (_003C_003E8__1.newViewedItems.Count == 0 && _003C_003E8__1.player.LastShopViewedLevel >= _003C_003E8__1.player.PlayerLevel)
				{
					result = Result<MarkShopItemsViewedResponse>.SuccessResult(new MarkShopItemsViewedResponse(Updated: false, 0));
				}
				else
				{
					_003Cresult_003E5__4 = _003C_003E4__this._stateService.ExecuteUpdate((Player p) => ValidationResult.Success(), delegate(Player p)
					{
						//IL_0008: Unknown result type (might be due to invalid IL or missing references)
						//IL_000d: Unknown result type (might be due to invalid IL or missing references)
						Enumerator<string> enumerator = _003C_003E8__1.newViewedItems.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								string current = enumerator.Current;
								p.AddViewedShopItem(current);
							}
						}
						finally
						{
							((global::System.IDisposable)enumerator).Dispose();
						}
						p.SetLastShopViewedLevel(p.PlayerLevel);
						return new
						{
							ItemsMarked = _003C_003E8__1.newViewedItems.Count
						};
					}, (Player p, updateResult) => new PlayerBatchUpdate
					{
						PlayerId = (p.PlayerID ?? string.Empty),
						ViewedShopItems = _003C_003E8__1.newViewedItems,
						LastShopViewedLevel = p.PlayerLevel
					});
					result = (_003Cresult_003E5__4.Success ? Result<MarkShopItemsViewedResponse>.SuccessResult(new MarkShopItemsViewedResponse(Updated: true, _003Cresult_003E5__4.Data.ItemsMarked)) : Result<MarkShopItemsViewedResponse>.FailureResult(_003Cresult_003E5__4.ErrorMessage ?? "Failed to mark items as viewed"));
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003CitemTypes_003E5__2 = null;
				_003CallAvailableItems_003E5__3 = null;
				_003Cresult_003E5__4 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003CitemTypes_003E5__2 = null;
			_003CallAvailableItems_003E5__3 = null;
			_003Cresult_003E5__4 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IPlayerStateService _stateService;

	private readonly IItemRepository _itemRepository;

	public MarkShopItemsViewedUseCase(IPlayerStateService stateService, IItemRepository itemRepository)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
		_itemRepository = itemRepository ?? throw new ArgumentNullException("itemRepository");
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__3))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<MarkShopItemsViewedResponse>> ExecuteAsync(MarkShopItemsViewedRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Player player = _stateService.GetCurrentPlayer();
		if (player == null)
		{
			return Result<MarkShopItemsViewedResponse>.FailureResult("No active session");
		}
		List<ItemType> obj = new List<ItemType>();
		obj.Add(ItemType.booster);
		obj.Add(ItemType.unlock);
		obj.Add(ItemType.items);
		obj.Add(ItemType.gear);
		obj.Add(ItemType.talent);
		List<ItemType> itemTypes = obj;
		List<string> newViewedItems = Enumerable.ToList<string>(Enumerable.Select<Item, string>(Enumerable.Where<Item>((global::System.Collections.Generic.IEnumerable<Item>)(await _itemRepository.GetItemsByTypeAndLevel(itemTypes, player.PlayerLevel)), (Func<Item, bool>)((Item item) => !string.IsNullOrEmpty(item.ID) && !Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)player.ViewedShopItems, item.ID))), (Func<Item, string>)((Item item) => item.ID)));
		if (newViewedItems.Count == 0 && player.LastShopViewedLevel >= player.PlayerLevel)
		{
			return Result<MarkShopItemsViewedResponse>.SuccessResult(new MarkShopItemsViewedResponse(Updated: false, 0));
		}
		var result = _stateService.ExecuteUpdate((Player p) => ValidationResult.Success(), delegate(Player p)
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			Enumerator<string> enumerator = newViewedItems.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					p.AddViewedShopItem(current);
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator).Dispose();
			}
			p.SetLastShopViewedLevel(p.PlayerLevel);
			return new
			{
				ItemsMarked = newViewedItems.Count
			};
		}, (Player p, updateResult) => new PlayerBatchUpdate
		{
			PlayerId = (p.PlayerID ?? string.Empty),
			ViewedShopItems = newViewedItems,
			LastShopViewedLevel = p.PlayerLevel
		});
		if (!result.Success)
		{
			return Result<MarkShopItemsViewedResponse>.FailureResult(result.ErrorMessage ?? "Failed to mark items as viewed");
		}
		return Result<MarkShopItemsViewedResponse>.SuccessResult(new MarkShopItemsViewedResponse(Updated: true, result.Data.ItemsMarked));
	}
}
