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

public class PurchaseShopItemUseCase : IUseCase<PurchaseShopItemRequest, PurchaseShopItemResponse>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public string currencyType;

		public int requiredAmount;

		public Item item;

		public PurchaseShopItemRequest request;

		internal ValidationResult _003CExecuteAsync_003Eb__0(Player player)
		{
			if (currencyType == "crystal")
			{
				currencyType = "gems";
			}
			else if (currencyType == "clancredits")
			{
				currencyType = "guildCoins";
			}
			long valueOrDefault = CollectionExtensions.GetValueOrDefault<string, long>(player.Currencies, currencyType, 0L);
			if (valueOrDefault < requiredAmount)
			{
				return ValidationResult.Failure($"Insufficient {currencyType}. Need {requiredAmount}, have {valueOrDefault}");
			}
			return ValidationResult.Success();
		}

		internal PurchaseShopItemResponse _003CExecuteAsync_003Eb__1(Player player)
		{
			player.AddCurrency(currencyType, -requiredAmount);
			player.AddInventoryItem(item.ID, request.Quantity);
			if (request.MarkAsViewed && !Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)player.ViewedShopItems, item.ID))
			{
				player.AddViewedShopItem(item.ID);
			}
			return new PurchaseShopItemResponse(Success: true, item.ID, item.Name, request.Quantity, requiredAmount, currencyType);
		}

		internal PlayerBatchUpdate _003CExecuteAsync_003Eb__2(Player player, PurchaseShopItemResponse response)
		{
			PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty),
				CurrencyChanges = new Dictionary<string, long> { [currencyType] = -requiredAmount },
				InventoryItemChanges = new Dictionary<string, int> { [item.ID] = request.Quantity }
			};
			if (request.MarkAsViewed)
			{
				List<string> obj = new List<string>();
				obj.Add(item.ID);
				playerBatchUpdate.ViewedShopItems = obj;
			}
			return playerBatchUpdate;
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<PurchaseShopItemResponse>> _003C_003Et__builder;

		public PurchaseShopItemRequest request;

		public PurchaseShopItemUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass3_0 _003C_003E8__1;

		private Result<PurchaseShopItemResponse> _003Cresult_003E5__2;

		private ItemType _003C_003Es__3;

		private Item _003C_003Es__4;

		private Item _003C_003Es__5;

		private Item _003C_003Es__6;

		private TaskAwaiter<Item?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_019e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_023e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Unknown result type (might be due to invalid IL or missing references)
			//IL_024b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_0204: Unknown result type (might be due to invalid IL or missing references)
			//IL_0209: Unknown result type (might be due to invalid IL or missing references)
			//IL_021e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0220: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<PurchaseShopItemResponse> result;
			try
			{
				TaskAwaiter<Item> awaiter2;
				TaskAwaiter<Item> awaiter;
				TaskAwaiter<Item> awaiter3;
				switch (num)
				{
				default:
					_003C_003E8__1 = new _003C_003Ec__DisplayClass3_0();
					_003C_003E8__1.request = request;
					if (!string.IsNullOrEmpty(_003C_003E8__1.request.ItemId))
					{
						ItemType itemType = _003C_003E8__1.request.ItemType;
						_003C_003Es__3 = itemType;
						ItemType itemType2 = _003C_003Es__3;
						if (itemType2 != ItemType.gear)
						{
							if (itemType2 == ItemType.talent)
							{
								awaiter2 = _003C_003E4__this._itemRepo.GetTalentByIdAsync(_003C_003E8__1.request.ItemId).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__1 = awaiter2;
									_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Item>, _003CExecuteAsync_003Ed__3>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
									return;
								}
								goto IL_01ba;
							}
							awaiter = _003C_003E4__this._itemRepo.GetByIdAsync(_003C_003E8__1.request.ItemId).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__1 = awaiter;
								_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Item>, _003CExecuteAsync_003Ed__3>(ref awaiter, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_025a;
						}
						awaiter3 = _003C_003E4__this._itemRepo.GetGearByIdAsync(_003C_003E8__1.request.ItemId).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Item>, _003CExecuteAsync_003Ed__3>(ref awaiter3, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_011a;
					}
					result = Result<PurchaseShopItemResponse>.FailureResult("Item ID is required");
					goto end_IL_0007;
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Item>);
					num = (_003C_003E1__state = -1);
					goto IL_011a;
				case 1:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Item>);
					num = (_003C_003E1__state = -1);
					goto IL_01ba;
				case 2:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Item>);
						num = (_003C_003E1__state = -1);
						goto IL_025a;
					}
					IL_011a:
					_003C_003Es__4 = awaiter3.GetResult();
					_003C_003E8__1.item = _003C_003Es__4;
					_003C_003Es__4 = null;
					break;
					IL_01ba:
					_003C_003Es__5 = awaiter2.GetResult();
					_003C_003E8__1.item = _003C_003Es__5;
					_003C_003Es__5 = null;
					break;
					IL_025a:
					_003C_003Es__6 = awaiter.GetResult();
					_003C_003E8__1.item = _003C_003Es__6;
					_003C_003Es__6 = null;
					break;
				}
				if (_003C_003E8__1.item == null || string.IsNullOrEmpty(_003C_003E8__1.item.ID))
				{
					result = Result<PurchaseShopItemResponse>.FailureResult("Item not found");
				}
				else
				{
					_003C_003E8__1.currencyType = _003C_003E8__1.item.Requirements?.CurrencyCost?.Type ?? "gold";
					_003C_003E8__1.requiredAmount = (_003C_003E8__1.item.Requirements?.CurrencyCost?.Amount).GetValueOrDefault();
					_003Cresult_003E5__2 = _003C_003E4__this._stateService.ExecuteUpdate<PurchaseShopItemResponse>(delegate(Player player)
					{
						if (_003C_003E8__1.currencyType == "crystal")
						{
							_003C_003E8__1.currencyType = "gems";
						}
						else if (_003C_003E8__1.currencyType == "clancredits")
						{
							_003C_003E8__1.currencyType = "guildCoins";
						}
						long valueOrDefault = CollectionExtensions.GetValueOrDefault<string, long>(player.Currencies, _003C_003E8__1.currencyType, 0L);
						return (valueOrDefault < _003C_003E8__1.requiredAmount) ? ValidationResult.Failure($"Insufficient {_003C_003E8__1.currencyType}. Need {_003C_003E8__1.requiredAmount}, have {valueOrDefault}") : ValidationResult.Success();
					}, delegate(Player player)
					{
						player.AddCurrency(_003C_003E8__1.currencyType, -_003C_003E8__1.requiredAmount);
						player.AddInventoryItem(_003C_003E8__1.item.ID, _003C_003E8__1.request.Quantity);
						if (_003C_003E8__1.request.MarkAsViewed && !Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)player.ViewedShopItems, _003C_003E8__1.item.ID))
						{
							player.AddViewedShopItem(_003C_003E8__1.item.ID);
						}
						return new PurchaseShopItemResponse(Success: true, _003C_003E8__1.item.ID, _003C_003E8__1.item.Name, _003C_003E8__1.request.Quantity, _003C_003E8__1.requiredAmount, _003C_003E8__1.currencyType);
					}, delegate(Player player, PurchaseShopItemResponse response)
					{
						PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
						{
							PlayerId = (player.PlayerID ?? string.Empty),
							CurrencyChanges = new Dictionary<string, long> { [_003C_003E8__1.currencyType] = -_003C_003E8__1.requiredAmount },
							InventoryItemChanges = new Dictionary<string, int> { [_003C_003E8__1.item.ID] = _003C_003E8__1.request.Quantity }
						};
						if (_003C_003E8__1.request.MarkAsViewed)
						{
							List<string> obj = new List<string>();
							obj.Add(_003C_003E8__1.item.ID);
							playerBatchUpdate.ViewedShopItems = obj;
						}
						return playerBatchUpdate;
					});
					result = (_003Cresult_003E5__2.Success ? Result<PurchaseShopItemResponse>.SuccessResult(_003Cresult_003E5__2.Data) : Result<PurchaseShopItemResponse>.FailureResult(_003Cresult_003E5__2.ErrorMessage ?? "Failed to complete purchase"));
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Cresult_003E5__2 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Cresult_003E5__2 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IItemRepository _itemRepo;

	private readonly IPlayerStateService _stateService;

	public PurchaseShopItemUseCase(IItemRepository itemRepo, IPlayerStateService stateService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		_itemRepo = itemRepo ?? throw new ArgumentNullException("itemRepo");
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__3))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<PurchaseShopItemResponse>> ExecuteAsync(PurchaseShopItemRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		PurchaseShopItemRequest request2 = request;
		if (string.IsNullOrEmpty(request2.ItemId))
		{
			return Result<PurchaseShopItemResponse>.FailureResult("Item ID is required");
		}
		Item item;
		switch (request2.ItemType)
		{
		case ItemType.gear:
			item = await _itemRepo.GetGearByIdAsync(request2.ItemId);
			break;
		case ItemType.talent:
			item = await _itemRepo.GetTalentByIdAsync(request2.ItemId);
			break;
		default:
			item = await _itemRepo.GetByIdAsync(request2.ItemId);
			break;
		}
		if (item == null || string.IsNullOrEmpty(item.ID))
		{
			return Result<PurchaseShopItemResponse>.FailureResult("Item not found");
		}
		string currencyType = item.Requirements?.CurrencyCost?.Type ?? "gold";
		int requiredAmount = (item.Requirements?.CurrencyCost?.Amount).GetValueOrDefault();
		Result<PurchaseShopItemResponse> result = _stateService.ExecuteUpdate<PurchaseShopItemResponse>(delegate(Player player)
		{
			if (currencyType == "crystal")
			{
				currencyType = "gems";
			}
			else if (currencyType == "clancredits")
			{
				currencyType = "guildCoins";
			}
			long valueOrDefault = CollectionExtensions.GetValueOrDefault<string, long>(player.Currencies, currencyType, 0L);
			return (valueOrDefault < requiredAmount) ? ValidationResult.Failure($"Insufficient {currencyType}. Need {requiredAmount}, have {valueOrDefault}") : ValidationResult.Success();
		}, delegate(Player player)
		{
			player.AddCurrency(currencyType, -requiredAmount);
			player.AddInventoryItem(item.ID, request2.Quantity);
			if (request2.MarkAsViewed && !Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)player.ViewedShopItems, item.ID))
			{
				player.AddViewedShopItem(item.ID);
			}
			return new PurchaseShopItemResponse(Success: true, item.ID, item.Name, request2.Quantity, requiredAmount, currencyType);
		}, delegate(Player player, PurchaseShopItemResponse response)
		{
			PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty),
				CurrencyChanges = new Dictionary<string, long> { [currencyType] = -requiredAmount },
				InventoryItemChanges = new Dictionary<string, int> { [item.ID] = request2.Quantity }
			};
			if (request2.MarkAsViewed)
			{
				List<string> obj = new List<string>();
				obj.Add(item.ID);
				playerBatchUpdate.ViewedShopItems = obj;
			}
			return playerBatchUpdate;
		});
		if (!result.Success)
		{
			return Result<PurchaseShopItemResponse>.FailureResult(result.ErrorMessage ?? "Failed to complete purchase");
		}
		return Result<PurchaseShopItemResponse>.SuccessResult(result.Data);
	}
}
