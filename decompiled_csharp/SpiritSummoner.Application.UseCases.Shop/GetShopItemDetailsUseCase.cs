using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Shop;

public class GetShopItemDetailsUseCase : IUseCase<GetShopItemDetailsRequest, Item>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<Item>> _003C_003Et__builder;

		public GetShopItemDetailsRequest request;

		public GetShopItemDetailsUseCase _003C_003E4__this;

		private Item _003Citem_003E5__1;

		private Player _003Cplayer_003E5__2;

		private Inventory _003CitemReq_003E5__3;

		private Item _003C_003Es__4;

		private TaskAwaiter<Item?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<Item> result;
			try
			{
				TaskAwaiter<Item> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Item>);
					num = (_003C_003E1__state = -1);
					goto IL_00a1;
				}
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
					goto IL_00a1;
				}
				result = Result<Item>.FailureResult("Item ID is required");
				goto end_IL_0007;
				IL_00a1:
				_003C_003Es__4 = awaiter.GetResult();
				_003Citem_003E5__1 = _003C_003Es__4;
				_003C_003Es__4 = null;
				if (_003Citem_003E5__1 == null)
				{
					result = Result<Item>.FailureResult("Item not found");
				}
				else
				{
					_003Cplayer_003E5__2 = _003C_003E4__this._playerStateService.GetCurrentPlayer();
					if (_003Cplayer_003E5__2 == null)
					{
						result = Result<Item>.FailureResult("Player not found");
					}
					else
					{
						IReadOnlyDictionary<string, Inventory> inventory = _003Cplayer_003E5__2.Inventory;
						result = ((inventory == null || !inventory.TryGetValue(_003Citem_003E5__1.ID, ref _003CitemReq_003E5__3) || _003CitemReq_003E5__3.Amount <= 0) ? Result<Item>.ValidationFailureResult("Player does not have required item", "You dont have enough items") : Result<Item>.SuccessResult(_003Citem_003E5__1));
					}
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Citem_003E5__1 = null;
				_003Cplayer_003E5__2 = null;
				_003CitemReq_003E5__3 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Citem_003E5__1 = null;
			_003Cplayer_003E5__2 = null;
			_003CitemReq_003E5__3 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IItemRepository _itemRepository;

	private readonly IPlayerStateService _playerStateService;

	public GetShopItemDetailsUseCase(IItemRepository itemRepository, IPlayerStateService playerStateService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		_itemRepository = itemRepository ?? throw new ArgumentNullException("itemRepository");
		_playerStateService = playerStateService ?? throw new ArgumentNullException("playerStateService");
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__3))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<Item>> ExecuteAsync(GetShopItemDetailsRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(request.ItemId))
		{
			return Result<Item>.FailureResult("Item ID is required");
		}
		Item item = await _itemRepository.GetByIdAsync(request.ItemId);
		if (item == null)
		{
			return Result<Item>.FailureResult("Item not found");
		}
		Player player = _playerStateService.GetCurrentPlayer();
		if (player == null)
		{
			return Result<Item>.FailureResult("Player not found");
		}
		Inventory itemReq = default(Inventory);
		if ((player.Inventory?.TryGetValue(item.ID, ref itemReq) ?? false) && itemReq.Amount > 0)
		{
			return Result<Item>.SuccessResult(item);
		}
		return Result<Item>.ValidationFailureResult("Player does not have required item", "You dont have enough items");
	}
}
