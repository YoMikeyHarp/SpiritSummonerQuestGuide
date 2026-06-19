using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Shop;

public class PurchaseCraftingItemUseCase : IUseCase<PurchaseCraftingItemRequest, PurchaseCraftingItemResponse>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public int requiredCrystals;

		public Item item;

		internal ValidationResult _003CExecuteAsync_003Eb__0(Player player)
		{
			long valueOrDefault = CollectionExtensions.GetValueOrDefault<string, long>(player.Currencies, "gems", 0L);
			if (valueOrDefault < requiredCrystals)
			{
				return ValidationResult.Failure($"Not enough crystals! Need {requiredCrystals}, have {valueOrDefault}");
			}
			return ValidationResult.Success();
		}

		internal PurchaseCraftingItemResponse _003CExecuteAsync_003Eb__1(Player player)
		{
			player.AddCurrency("gems", -requiredCrystals);
			player.AddInventoryItem(item.ID, 1);
			return new PurchaseCraftingItemResponse(Success: true, item.ID, item.Name, requiredCrystals);
		}

		internal PlayerBatchUpdate _003CExecuteAsync_003Eb__2(Player player, PurchaseCraftingItemResponse response)
		{
			return new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty),
				CurrencyChanges = new Dictionary<string, long> { ["gems"] = -requiredCrystals },
				InventoryItemChanges = new Dictionary<string, int> { [item.ID] = 1 }
			};
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<PurchaseCraftingItemResponse>> _003C_003Et__builder;

		public PurchaseCraftingItemRequest request;

		public PurchaseCraftingItemUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass3_0 _003C_003E8__1;

		private string _003CrequiredCraftingItem_003E5__2;

		private Result<PurchaseCraftingItemResponse> _003Cresult_003E5__3;

		private Item _003C_003Es__4;

		private TaskAwaiter<Item?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<PurchaseCraftingItemResponse> result;
			try
			{
				TaskAwaiter<Item> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Item>);
					num = (_003C_003E1__state = -1);
					goto IL_00af;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass3_0();
				if (!string.IsNullOrEmpty(request.ItemId))
				{
					awaiter = _003C_003E4__this._itemRepository.GetByIdAsync(request.ItemId).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Item>, _003CExecuteAsync_003Ed__3>(ref awaiter, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_00af;
				}
				result = Result<PurchaseCraftingItemResponse>.FailureResult("Item ID is required");
				goto end_IL_0007;
				IL_00af:
				_003C_003Es__4 = awaiter.GetResult();
				_003C_003E8__1.item = _003C_003Es__4;
				_003C_003Es__4 = null;
				if (_003C_003E8__1.item == null)
				{
					result = Result<PurchaseCraftingItemResponse>.FailureResult("Item not found");
				}
				else
				{
					_003C_003E8__1.requiredCrystals = (_003C_003E8__1.item.Requirements?.ItemRequirement?.Amount).GetValueOrDefault(1);
					_003CrequiredCraftingItem_003E5__2 = _003C_003E8__1.item.Requirements?.ItemRequirement?.ItemType;
					if (_003CrequiredCraftingItem_003E5__2 == "crystals" || _003CrequiredCraftingItem_003E5__2 == "crystal" || _003CrequiredCraftingItem_003E5__2 == "None")
					{
						_003CrequiredCraftingItem_003E5__2 = "gems";
					}
					else if (string.IsNullOrEmpty(_003CrequiredCraftingItem_003E5__2))
					{
						_003CrequiredCraftingItem_003E5__2 = "gems";
					}
					else if (_003CrequiredCraftingItem_003E5__2 == "gold")
					{
						_003CrequiredCraftingItem_003E5__2 = "gems";
					}
					_003Cresult_003E5__3 = _003C_003E4__this._stateService.ExecuteUpdate<PurchaseCraftingItemResponse>(delegate(Player player)
					{
						long valueOrDefault = CollectionExtensions.GetValueOrDefault<string, long>(player.Currencies, "gems", 0L);
						return (valueOrDefault < _003C_003E8__1.requiredCrystals) ? ValidationResult.Failure($"Not enough crystals! Need {_003C_003E8__1.requiredCrystals}, have {valueOrDefault}") : ValidationResult.Success();
					}, delegate(Player player)
					{
						player.AddCurrency("gems", -_003C_003E8__1.requiredCrystals);
						player.AddInventoryItem(_003C_003E8__1.item.ID, 1);
						return new PurchaseCraftingItemResponse(Success: true, _003C_003E8__1.item.ID, _003C_003E8__1.item.Name, _003C_003E8__1.requiredCrystals);
					}, (Player player, PurchaseCraftingItemResponse response) => new PlayerBatchUpdate
					{
						PlayerId = (player.PlayerID ?? string.Empty),
						CurrencyChanges = new Dictionary<string, long> { ["gems"] = -_003C_003E8__1.requiredCrystals },
						InventoryItemChanges = new Dictionary<string, int> { [_003C_003E8__1.item.ID] = 1 }
					});
					result = (_003Cresult_003E5__3.Success ? Result<PurchaseCraftingItemResponse>.SuccessResult(_003Cresult_003E5__3.Data) : Result<PurchaseCraftingItemResponse>.FailureResult(_003Cresult_003E5__3.ErrorMessage ?? "Failed to craft item"));
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003CrequiredCraftingItem_003E5__2 = null;
				_003Cresult_003E5__3 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003CrequiredCraftingItem_003E5__2 = null;
			_003Cresult_003E5__3 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IItemRepository _itemRepository;

	private readonly IPlayerStateService _stateService;

	public PurchaseCraftingItemUseCase(IItemRepository itemRepository, IPlayerStateService stateService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		_itemRepository = itemRepository ?? throw new ArgumentNullException("itemRepository");
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__3))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<PurchaseCraftingItemResponse>> ExecuteAsync(PurchaseCraftingItemRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(request.ItemId))
		{
			return Result<PurchaseCraftingItemResponse>.FailureResult("Item ID is required");
		}
		Item item = await _itemRepository.GetByIdAsync(request.ItemId);
		if (item == null)
		{
			return Result<PurchaseCraftingItemResponse>.FailureResult("Item not found");
		}
		int requiredCrystals = (item.Requirements?.ItemRequirement?.Amount).GetValueOrDefault(1);
		string requiredCraftingItem = item.Requirements?.ItemRequirement?.ItemType;
		if (requiredCraftingItem == "crystals" || requiredCraftingItem == "crystal" || requiredCraftingItem == "None" || string.IsNullOrEmpty(requiredCraftingItem) || requiredCraftingItem == "gold")
		{
		}
		Result<PurchaseCraftingItemResponse> result = _stateService.ExecuteUpdate<PurchaseCraftingItemResponse>(delegate(Player player)
		{
			long valueOrDefault = CollectionExtensions.GetValueOrDefault<string, long>(player.Currencies, "gems", 0L);
			return (valueOrDefault < requiredCrystals) ? ValidationResult.Failure($"Not enough crystals! Need {requiredCrystals}, have {valueOrDefault}") : ValidationResult.Success();
		}, delegate(Player player)
		{
			player.AddCurrency("gems", -requiredCrystals);
			player.AddInventoryItem(item.ID, 1);
			return new PurchaseCraftingItemResponse(Success: true, item.ID, item.Name, requiredCrystals);
		}, (Player player, PurchaseCraftingItemResponse response) => new PlayerBatchUpdate
		{
			PlayerId = (player.PlayerID ?? string.Empty),
			CurrencyChanges = new Dictionary<string, long> { ["gems"] = -requiredCrystals },
			InventoryItemChanges = new Dictionary<string, int> { [item.ID] = 1 }
		});
		if (!result.Success)
		{
			return Result<PurchaseCraftingItemResponse>.FailureResult(result.ErrorMessage ?? "Failed to craft item");
		}
		return Result<PurchaseCraftingItemResponse>.SuccessResult(result.Data);
	}
}
