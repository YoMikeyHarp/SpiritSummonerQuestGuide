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
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Enums.Items;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Presentation.Models;

namespace SpiritSummoner.Application.UseCases.Items;

public class GetEquippableItemsUseCase : IUseCase<GetEquippableItemsRequest, GetEquippableItemsResponse>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public GetEquippableItemsUseCase _003C_003E4__this;

		public Spirit baseSpirit;

		public Player playerReadModel;

		public PlayerSpirit playerSpirit;

		public GetEquippableItemsRequest request;

		internal bool _003CExecuteAsync_003Eb__0(Item item)
		{
			return _003C_003E4__this.CanSpiritEquipItem(baseSpirit, item);
		}

		internal bool _003CExecuteAsync_003Eb__1(Item item)
		{
			return _003C_003E4__this.PlayerOwnsItem(playerReadModel.Inventory, item.ID);
		}

		internal bool _003CExecuteAsync_003Eb__2(Item item)
		{
			return item.ID != playerSpirit.GetEquippedItemId(Enumerable.First<ItemType>((global::System.Collections.Generic.IEnumerable<ItemType>)request.ItemTypes));
		}

		internal ItemModel _003CExecuteAsync_003Eb__3(Item item)
		{
			return _003C_003E4__this.MapToItemModel(item, playerReadModel.Inventory);
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<GetEquippableItemsResponse>> _003C_003Et__builder;

		public GetEquippableItemsRequest request;

		public GetEquippableItemsUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass4_0 _003C_003E8__1;

		private global::System.Collections.Generic.IReadOnlyList<Item> _003CallItems_003E5__2;

		private List<Item> _003CequippableItems_003E5__3;

		private List<ItemModel> _003CitemModels_003E5__4;

		private global::System.Collections.Generic.IReadOnlyList<Item> _003C_003Es__5;

		private TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Item>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0152: Unknown result type (might be due to invalid IL or missing references)
			//IL_0167: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<GetEquippableItemsResponse> result;
			try
			{
				TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Item>> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Item>>);
					num = (_003C_003E1__state = -1);
					goto IL_01a3;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass4_0();
				_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
				_003C_003E8__1.request = request;
				_003C_003E8__1.playerReadModel = _003C_003E4__this._stateService.GetCurrentPlayer();
				if (_003C_003E8__1.playerReadModel == null)
				{
					result = Result<GetEquippableItemsResponse>.FailureResult("No active session");
				}
				else
				{
					_003C_003E8__1.playerSpirit = _003C_003E4__this._stateService.GetPlayerSpirit(_003C_003E8__1.request.PlayerSpiritId);
					if (_003C_003E8__1.playerSpirit == null)
					{
						result = Result<GetEquippableItemsResponse>.FailureResult("Spirit not found");
					}
					else
					{
						_003C_003E8__1.baseSpirit = _003C_003E4__this._spiritRepository.GetById(_003C_003E8__1.request.BaseSpiritId);
						if (_003C_003E8__1.baseSpirit != null)
						{
							awaiter = _003C_003E4__this._itemRepository.GetItemsByTypeAndLevel(_003C_003E8__1.request.ItemTypes, _003C_003E4__this._stateService.GetCurrentPlayer().PlayerLevel).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Item>>, _003CExecuteAsync_003Ed__4>(ref awaiter, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_01a3;
						}
						result = Result<GetEquippableItemsResponse>.FailureResult("Spirit template not found");
					}
				}
				goto end_IL_0007;
				IL_01a3:
				_003C_003Es__5 = awaiter.GetResult();
				_003CallItems_003E5__2 = _003C_003Es__5;
				_003C_003Es__5 = null;
				_003CequippableItems_003E5__3 = Enumerable.ToList<Item>(Enumerable.Where<Item>(Enumerable.Where<Item>(Enumerable.Where<Item>((global::System.Collections.Generic.IEnumerable<Item>)_003CallItems_003E5__2, (Func<Item, bool>)((Item item) => _003C_003E8__1._003C_003E4__this.CanSpiritEquipItem(_003C_003E8__1.baseSpirit, item))), (Func<Item, bool>)((Item item) => _003C_003E8__1._003C_003E4__this.PlayerOwnsItem(_003C_003E8__1.playerReadModel.Inventory, item.ID))), (Func<Item, bool>)((Item item) => item.ID != _003C_003E8__1.playerSpirit.GetEquippedItemId(Enumerable.First<ItemType>((global::System.Collections.Generic.IEnumerable<ItemType>)_003C_003E8__1.request.ItemTypes)))));
				_003CitemModels_003E5__4 = Enumerable.ToList<ItemModel>(Enumerable.Select<Item, ItemModel>((global::System.Collections.Generic.IEnumerable<Item>)_003CequippableItems_003E5__3, (Func<Item, ItemModel>)((Item item) => _003C_003E8__1._003C_003E4__this.MapToItemModel(item, _003C_003E8__1.playerReadModel.Inventory))));
				result = Result<GetEquippableItemsResponse>.SuccessResult(new GetEquippableItemsResponse(_003CitemModels_003E5__4));
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003CallItems_003E5__2 = null;
				_003CequippableItems_003E5__3 = null;
				_003CitemModels_003E5__4 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003CallItems_003E5__2 = null;
			_003CequippableItems_003E5__3 = null;
			_003CitemModels_003E5__4 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IPlayerStateService _stateService;

	private readonly IItemRepository _itemRepository;

	private readonly ISpiritRepository _spiritRepository;

	public GetEquippableItemsUseCase(IPlayerStateService stateService, IItemRepository itemRepository, ISpiritRepository spiritRepository)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
		_itemRepository = itemRepository ?? throw new ArgumentNullException("itemRepository");
		_spiritRepository = spiritRepository ?? throw new ArgumentNullException("spiritRepository");
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__4))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<GetEquippableItemsResponse>> ExecuteAsync(GetEquippableItemsRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		GetEquippableItemsRequest request2 = request;
		Player playerReadModel = _stateService.GetCurrentPlayer();
		if (playerReadModel == null)
		{
			return Result<GetEquippableItemsResponse>.FailureResult("No active session");
		}
		PlayerSpirit playerSpirit = _stateService.GetPlayerSpirit(request2.PlayerSpiritId);
		if (playerSpirit == null)
		{
			return Result<GetEquippableItemsResponse>.FailureResult("Spirit not found");
		}
		Spirit baseSpirit = _spiritRepository.GetById(request2.BaseSpiritId);
		if (baseSpirit == null)
		{
			return Result<GetEquippableItemsResponse>.FailureResult("Spirit template not found");
		}
		List<Item> equippableItems = Enumerable.ToList<Item>(Enumerable.Where<Item>(Enumerable.Where<Item>(Enumerable.Where<Item>((global::System.Collections.Generic.IEnumerable<Item>)(await _itemRepository.GetItemsByTypeAndLevel(request2.ItemTypes, _stateService.GetCurrentPlayer().PlayerLevel)), (Func<Item, bool>)((Item item) => CanSpiritEquipItem(baseSpirit, item))), (Func<Item, bool>)((Item item) => PlayerOwnsItem(playerReadModel.Inventory, item.ID))), (Func<Item, bool>)((Item item) => item.ID != playerSpirit.GetEquippedItemId(Enumerable.First<ItemType>((global::System.Collections.Generic.IEnumerable<ItemType>)request2.ItemTypes)))));
		List<ItemModel> itemModels = Enumerable.ToList<ItemModel>(Enumerable.Select<Item, ItemModel>((global::System.Collections.Generic.IEnumerable<Item>)equippableItems, (Func<Item, ItemModel>)((Item item) => MapToItemModel(item, playerReadModel.Inventory))));
		return Result<GetEquippableItemsResponse>.SuccessResult(new GetEquippableItemsResponse(itemModels));
	}

	private bool CanSpiritEquipItem(Spirit spirit, Item item)
	{
		Spirit spirit2 = spirit;
		bool flag = true;
		List<string> val = item.Effect?.TypeRestrictions;
		if (val != null)
		{
			flag = Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)val, (Func<string, bool>)((string r) => r == ((object)spirit2.Type1).ToString() || r == ((object)spirit2.Type2).ToString()));
		}
		List<string> val2 = item.Effect?.ClassRestrictions;
		if (val2 != null)
		{
			flag = Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)val2, (Func<string, bool>)((string c) => c == spirit2.Category));
		}
		return true;
	}

	private bool PlayerOwnsItem(IReadOnlyDictionary<string, Inventory> inventory, string itemId)
	{
		string itemId2 = itemId;
		return Enumerable.Any<KeyValuePair<string, Inventory>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, Inventory>>)inventory, (Func<KeyValuePair<string, Inventory>, bool>)((KeyValuePair<string, Inventory> i) => i.Key == itemId2 && i.Value.Amount > 0));
	}

	private ItemModel MapToItemModel(Item domainItem, IReadOnlyDictionary<string, Inventory> inventory)
	{
		Inventory inventory2 = default(Inventory);
		return inventory.TryGetValue(domainItem.ID, ref inventory2) ? new ItemModel(domainItem.ID, domainItem?.Name ?? "", ((object)domainItem?.ItemType).ToString() ?? "items", inventory2?.Amount ?? 0, domainItem.Image ?? "", domainItem.Description ?? "", (domainItem.Requirements?.CurrencyCost?.Amount).GetValueOrDefault()) : new ItemModel();
	}
}
