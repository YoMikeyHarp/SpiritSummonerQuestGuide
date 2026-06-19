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

namespace SpiritSummoner.Application.UseCases.Items;

public class GetPlayerInventoryUseCase : IUseCase<GetPlayerInventoryRequest, GetPlayerInventoryResponse>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<GetPlayerInventoryResponse>> _003C_003Et__builder;

		public GetPlayerInventoryRequest request;

		public GetPlayerInventoryUseCase _003C_003E4__this;

		private Player _003Cplayer_003E5__1;

		private List<Inventory> _003CownedInventoryItems_003E5__2;

		private List<string> _003CitemIds_003E5__3;

		private global::System.Collections.Generic.IReadOnlyList<Item?> _003CitemTemplates_003E5__4;

		private global::System.Collections.Generic.IReadOnlyList<Item?> _003C_003Es__5;

		private TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Item?>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0167: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<GetPlayerInventoryResponse> result;
			try
			{
				TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Item>> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Item>>);
					num = (_003C_003E1__state = -1);
					goto IL_0176;
				}
				_003Cplayer_003E5__1 = _003C_003E4__this._stateService.GetCurrentPlayer();
				if (_003Cplayer_003E5__1 == null)
				{
					result = Result<GetPlayerInventoryResponse>.FailureResult("No active session");
				}
				else
				{
					_003CownedInventoryItems_003E5__2 = Enumerable.ToList<Inventory>(Enumerable.Where<Inventory>(_003Cplayer_003E5__1.Inventory.Values, (Func<Inventory, bool>)((Inventory i) => i.Amount > 0)));
					if (Enumerable.Any<Inventory>((global::System.Collections.Generic.IEnumerable<Inventory>)_003CownedInventoryItems_003E5__2))
					{
						_003CitemIds_003E5__3 = Enumerable.ToList<string>(Enumerable.Where<string>(Enumerable.Select<Inventory, string>((global::System.Collections.Generic.IEnumerable<Inventory>)_003CownedInventoryItems_003E5__2, (Func<Inventory, string>)((Inventory i) => i.Name)), (Func<string, bool>)((string n) => !string.IsNullOrEmpty(n))));
						awaiter = _003C_003E4__this._itemRepository.GetByIdsAsync((global::System.Collections.Generic.IEnumerable<string>)_003CitemIds_003E5__3).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Item>>, _003CExecuteAsync_003Ed__3>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_0176;
					}
					result = Result<GetPlayerInventoryResponse>.SuccessResult(new GetPlayerInventoryResponse((global::System.Collections.Generic.IReadOnlyList<Inventory>)new List<Inventory>(), (global::System.Collections.Generic.IReadOnlyList<Item>)new List<Item>()));
				}
				goto end_IL_0007;
				IL_0176:
				_003C_003Es__5 = awaiter.GetResult();
				_003CitemTemplates_003E5__4 = _003C_003Es__5;
				_003C_003Es__5 = null;
				result = Result<GetPlayerInventoryResponse>.SuccessResult(new GetPlayerInventoryResponse((global::System.Collections.Generic.IReadOnlyList<Inventory>)_003CownedInventoryItems_003E5__2, (global::System.Collections.Generic.IReadOnlyList<Item>)Enumerable.ToList<Item>((global::System.Collections.Generic.IEnumerable<Item>)_003CitemTemplates_003E5__4)));
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cplayer_003E5__1 = null;
				_003CownedInventoryItems_003E5__2 = null;
				_003CitemIds_003E5__3 = null;
				_003CitemTemplates_003E5__4 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cplayer_003E5__1 = null;
			_003CownedInventoryItems_003E5__2 = null;
			_003CitemIds_003E5__3 = null;
			_003CitemTemplates_003E5__4 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IPlayerStateService _stateService;

	private readonly IItemRepository _itemRepository;

	public GetPlayerInventoryUseCase(IPlayerStateService stateService, IItemRepository itemRepository)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
		_itemRepository = itemRepository ?? throw new ArgumentNullException("itemRepository");
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__3))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<GetPlayerInventoryResponse>> ExecuteAsync(GetPlayerInventoryRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Player player = _stateService.GetCurrentPlayer();
		if (player == null)
		{
			return Result<GetPlayerInventoryResponse>.FailureResult("No active session");
		}
		List<Inventory> ownedInventoryItems = Enumerable.ToList<Inventory>(Enumerable.Where<Inventory>(player.Inventory.Values, (Func<Inventory, bool>)((Inventory i) => i.Amount > 0)));
		if (!Enumerable.Any<Inventory>((global::System.Collections.Generic.IEnumerable<Inventory>)ownedInventoryItems))
		{
			return Result<GetPlayerInventoryResponse>.SuccessResult(new GetPlayerInventoryResponse((global::System.Collections.Generic.IReadOnlyList<Inventory>)new List<Inventory>(), (global::System.Collections.Generic.IReadOnlyList<Item>)new List<Item>()));
		}
		List<string> itemIds = Enumerable.ToList<string>(Enumerable.Where<string>(Enumerable.Select<Inventory, string>((global::System.Collections.Generic.IEnumerable<Inventory>)ownedInventoryItems, (Func<Inventory, string>)((Inventory i) => i.Name)), (Func<string, bool>)((string n) => !string.IsNullOrEmpty(n))));
		return Result<GetPlayerInventoryResponse>.SuccessResult(new GetPlayerInventoryResponse((global::System.Collections.Generic.IReadOnlyList<Inventory>)ownedInventoryItems, (global::System.Collections.Generic.IReadOnlyList<Item>)Enumerable.ToList<Item>((global::System.Collections.Generic.IEnumerable<Item>)(await _itemRepository.GetByIdsAsync((global::System.Collections.Generic.IEnumerable<string>)itemIds)))));
	}
}
