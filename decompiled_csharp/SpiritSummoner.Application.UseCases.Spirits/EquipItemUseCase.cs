using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Interfaces.Services;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Spirits;

public class EquipItemUseCase : IUseCase<EquipItemRequest, EquipItemResponse>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public EquipItemRequest request;

		public string oldItemId;

		public EquipItemUseCase _003C_003E4__this;

		public Dictionary<string, int> inventoryChanges;

		public Action<PlayerSpiritFieldUpdate> _003C_003E9__5;

		internal ValidationResult _003CExecuteAsync_003Eb__0(Player player)
		{
			if (!player.PlayerSpirits.ContainsKey(request.SpiritId))
			{
				return ValidationResult.Failure("Spirit not found in player's collection");
			}
			if (!string.IsNullOrEmpty(request.ItemId) && !player.HasInventoryItem(request.ItemId))
			{
				return ValidationResult.Failure("Item '" + request.ItemId + "' not found in inventory");
			}
			return ValidationResult.Success();
		}

		internal _003C_003Ef__AnonymousType10<string, string, EquipmentType, string, bool> _003CExecuteAsync_003Eb__1(Player player)
		{
			PlayerSpirit playerSpirit = player.PlayerSpirits[request.SpiritId];
			EquipmentType itemType = request.ItemType;
			if (1 == 0)
			{
			}
			string text = itemType switch
			{
				EquipmentType.Gear => playerSpirit.GearID, 
				EquipmentType.Talent => playerSpirit.TalentID, 
				EquipmentType.HeldItem => playerSpirit.HeldItemID, 
				_ => null, 
			};
			if (1 == 0)
			{
			}
			oldItemId = text;
			switch (request.ItemType)
			{
			case EquipmentType.Gear:
				playerSpirit.EquipGear(request.ItemId);
				break;
			case EquipmentType.Talent:
				playerSpirit.EquipTalent(request.ItemId);
				break;
			case EquipmentType.HeldItem:
				playerSpirit.EquipHeldItem(request.ItemId);
				break;
			}
			if (!string.IsNullOrEmpty(request.ItemId))
			{
				_003C_003E4__this._inventoryService.ModifyInventory(player, request.ItemId, -1);
				inventoryChanges[request.ItemId] = -1;
			}
			return new
			{
				SpiritId = request.SpiritId,
				ItemId = request.ItemId,
				ItemType = request.ItemType,
				OldItemId = oldItemId,
				InventoryChanged = (inventoryChanges.Count > 0)
			};
		}

		internal PlayerBatchUpdate _003CExecuteAsync_003Eb__2(Player player, _003C_003Ef__AnonymousType10<string, string, EquipmentType, string, bool> updateResult)
		{
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty)
			};
			playerBatchUpdate.AddSpiritFieldUpdate(request.SpiritId, delegate(PlayerSpiritFieldUpdate update)
			{
				EquipmentType itemType = request.ItemType;
				if (1 == 0)
				{
				}
				SpiritUpdateType updateType = itemType switch
				{
					EquipmentType.Gear => SpiritUpdateType.Gear, 
					EquipmentType.Talent => SpiritUpdateType.Talent, 
					EquipmentType.HeldItem => SpiritUpdateType.HeldItem, 
					_ => SpiritUpdateType.Equipment, 
				};
				if (1 == 0)
				{
				}
				update.UpdateType = updateType;
				switch (request.ItemType)
				{
				case EquipmentType.Gear:
					update.SetGearId = request.ItemId;
					break;
				case EquipmentType.Talent:
					update.SetTalentId = request.ItemId;
					break;
				case EquipmentType.HeldItem:
					update.SetHeldItemId = request.ItemId;
					break;
				}
			});
			if (inventoryChanges.Count > 0)
			{
				Enumerator<string, int> enumerator = inventoryChanges.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<string, int> current = enumerator.Current;
						playerBatchUpdate.ConsumeInventoryItem(current.Key, current.Value, player);
					}
				}
				finally
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
				playerBatchUpdate.UpdateInventory = true;
			}
			return playerBatchUpdate;
		}

		internal void _003CExecuteAsync_003Eb__5(PlayerSpiritFieldUpdate update)
		{
			EquipmentType itemType = request.ItemType;
			if (1 == 0)
			{
			}
			SpiritUpdateType updateType = itemType switch
			{
				EquipmentType.Gear => SpiritUpdateType.Gear, 
				EquipmentType.Talent => SpiritUpdateType.Talent, 
				EquipmentType.HeldItem => SpiritUpdateType.HeldItem, 
				_ => SpiritUpdateType.Equipment, 
			};
			if (1 == 0)
			{
			}
			update.UpdateType = updateType;
			switch (request.ItemType)
			{
			case EquipmentType.Gear:
				update.SetGearId = request.ItemId;
				break;
			case EquipmentType.Talent:
				update.SetTalentId = request.ItemId;
				break;
			case EquipmentType.HeldItem:
				update.SetHeldItemId = request.ItemId;
				break;
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_1
	{
		public Spirit spirit;

		internal bool _003CExecuteAsync_003Eb__3(string tr)
		{
			return tr == ((object)spirit.Type1).ToString() || tr == ((object)spirit.Type2).ToString();
		}

		internal bool _003CExecuteAsync_003Eb__4(string cr)
		{
			return cr == spirit.Category || cr == spirit.Category2;
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<EquipItemResponse>> _003C_003Et__builder;

		public EquipItemRequest request;

		public EquipItemUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass5_0 _003C_003E8__1;

		private Item _003Citem_003E5__2;

		private List<string> _003CtypeRestrictions_003E5__3;

		private List<string> _003CclassRestrictions_003E5__4;

		private bool _003ChasTypeRestriction_003E5__5;

		private bool _003ChasClassRestriction_003E5__6;

		private Result<_003C_003Ef__AnonymousType10<string, string, EquipmentType, string, bool>> _003Cresult_003E5__7;

		private EquipmentType _003C_003Es__8;

		private Item _003C_003Es__9;

		private Item _003C_003Es__10;

		private Item _003C_003Es__11;

		private _003C_003Ec__DisplayClass5_1 _003C_003E8__12;

		private Spirit _003C_003Es__13;

		private TaskAwaiter<Item?> _003C_003Eu__1;

		private TaskAwaiter<Spirit?> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0208: Unknown result type (might be due to invalid IL or missing references)
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0215: Unknown result type (might be due to invalid IL or missing references)
			//IL_029f: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0402: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0265: Unknown result type (might be due to invalid IL or missing references)
			//IL_026a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_027f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0281: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<EquipItemResponse> result;
			try
			{
				TaskAwaiter<Item> awaiter4;
				TaskAwaiter<Item> awaiter3;
				TaskAwaiter<Item> awaiter2;
				TaskAwaiter<Spirit> awaiter;
				Item item;
				switch (num)
				{
				default:
					_003C_003E8__1 = new _003C_003Ec__DisplayClass5_0();
					_003C_003E8__1.request = request;
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					if (string.IsNullOrEmpty(_003C_003E8__1.request.SpiritId))
					{
						result = Result<EquipItemResponse>.FailureResult("Spirit ID is required");
					}
					else
					{
						if (_003C_003E8__1.request.ItemType == EquipmentType.Gear || _003C_003E8__1.request.ItemType == EquipmentType.Talent || _003C_003E8__1.request.ItemType == EquipmentType.HeldItem)
						{
							_003C_003Es__8 = _003C_003E8__1.request.ItemType;
							if (1 == 0)
							{
							}
							switch (_003C_003Es__8)
							{
							case EquipmentType.Gear:
								break;
							case EquipmentType.Talent:
								goto IL_01ae;
							case EquipmentType.HeldItem:
								goto IL_0245;
							default:
								goto IL_02d9;
							}
							awaiter4 = _003C_003E4__this._itemRepository.GetGearByIdAsync(_003C_003E8__1.request.ItemId).GetAwaiter();
							if (!awaiter4.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter4;
								_003CExecuteAsync_003Ed__5 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Item>, _003CExecuteAsync_003Ed__5>(ref awaiter4, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_018d;
						}
						result = Result<EquipItemResponse>.FailureResult("Invalid item type");
					}
					goto end_IL_0007;
				case 0:
					awaiter4 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Item>);
					num = (_003C_003E1__state = -1);
					goto IL_018d;
				case 1:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Item>);
					num = (_003C_003E1__state = -1);
					goto IL_0224;
				case 2:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Item>);
					num = (_003C_003E1__state = -1);
					goto IL_02bb;
				case 3:
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<Spirit>);
						num = (_003C_003E1__state = -1);
						goto IL_0411;
					}
					IL_0245:
					awaiter2 = _003C_003E4__this._itemRepository.GetByIdAsync(_003C_003E8__1.request.ItemId).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = awaiter2;
						_003CExecuteAsync_003Ed__5 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Item>, _003CExecuteAsync_003Ed__5>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_02bb;
					IL_02de:
					if (1 == 0)
					{
					}
					_003Citem_003E5__2 = item;
					if (_003Citem_003E5__2 != null)
					{
						_003CtypeRestrictions_003E5__3 = _003Citem_003E5__2.Effect?.TypeRestrictions;
						_003CclassRestrictions_003E5__4 = _003Citem_003E5__2.Effect?.ClassRestrictions;
						List<string> obj = _003CtypeRestrictions_003E5__3;
						_003ChasTypeRestriction_003E5__5 = obj != null && obj.Count > 0;
						List<string> obj2 = _003CclassRestrictions_003E5__4;
						_003ChasClassRestriction_003E5__6 = obj2 != null && obj2.Count > 0;
						if (!(_003ChasTypeRestriction_003E5__5 | _003ChasClassRestriction_003E5__6))
						{
							break;
						}
						_003C_003E8__12 = new _003C_003Ec__DisplayClass5_1();
						awaiter = _003C_003E4__this._spiritRepository.GetByIdAsync(_003C_003E8__1.request.BaseSpiritId).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__2 = awaiter;
							_003CExecuteAsync_003Ed__5 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Spirit>, _003CExecuteAsync_003Ed__5>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_0411;
					}
					result = Result<EquipItemResponse>.FailureResult("Item not found");
					goto end_IL_0007;
					IL_01ae:
					awaiter3 = _003C_003E4__this._itemRepository.GetTalentByIdAsync(_003C_003E8__1.request.ItemId).GetAwaiter();
					if (!awaiter3.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter3;
						_003CExecuteAsync_003Ed__5 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Item>, _003CExecuteAsync_003Ed__5>(ref awaiter3, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_0224;
					IL_0411:
					_003C_003Es__13 = awaiter.GetResult();
					_003C_003E8__12.spirit = _003C_003Es__13;
					_003C_003Es__13 = null;
					if (_003C_003E8__12.spirit == null)
					{
						result = Result<EquipItemResponse>.FailureResult("Spirit not found!");
					}
					else if (_003ChasTypeRestriction_003E5__5 && !Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)_003CtypeRestrictions_003E5__3, (Func<string, bool>)((string tr) => tr == ((object)_003C_003E8__12.spirit.Type1).ToString() || tr == ((object)_003C_003E8__12.spirit.Type2).ToString())))
					{
						result = Result<EquipItemResponse>.FailureResult(_003Citem_003E5__2.Name + " is restricted to " + string.Join(", ", (global::System.Collections.Generic.IEnumerable<string>)_003CtypeRestrictions_003E5__3) + " type(s).");
					}
					else
					{
						if (!_003ChasClassRestriction_003E5__6 || Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)_003CclassRestrictions_003E5__4, (Func<string, bool>)((string cr) => cr == _003C_003E8__12.spirit.Category || cr == _003C_003E8__12.spirit.Category2)))
						{
							_003C_003E8__12 = null;
							break;
						}
						result = Result<EquipItemResponse>.FailureResult(_003Citem_003E5__2.Name + " is restricted to " + string.Join(", ", (global::System.Collections.Generic.IEnumerable<string>)_003CclassRestrictions_003E5__4) + " class(es).");
					}
					goto end_IL_0007;
					IL_0224:
					_003C_003Es__10 = awaiter3.GetResult();
					item = _003C_003Es__10;
					_003C_003Es__10 = null;
					goto IL_02de;
					IL_02bb:
					_003C_003Es__11 = awaiter2.GetResult();
					item = _003C_003Es__11;
					_003C_003Es__11 = null;
					goto IL_02de;
					IL_018d:
					_003C_003Es__9 = awaiter4.GetResult();
					item = _003C_003Es__9;
					_003C_003Es__9 = null;
					goto IL_02de;
					IL_02d9:
					item = null;
					goto IL_02de;
				}
				_003C_003E8__1.oldItemId = null;
				_003C_003E8__1.inventoryChanges = new Dictionary<string, int>();
				_003Cresult_003E5__7 = _003C_003E4__this._stateService.ExecuteUpdate(delegate(Player player)
				{
					if (!player.PlayerSpirits.ContainsKey(_003C_003E8__1.request.SpiritId))
					{
						return ValidationResult.Failure("Spirit not found in player's collection");
					}
					return (!string.IsNullOrEmpty(_003C_003E8__1.request.ItemId) && !player.HasInventoryItem(_003C_003E8__1.request.ItemId)) ? ValidationResult.Failure("Item '" + _003C_003E8__1.request.ItemId + "' not found in inventory") : ValidationResult.Success();
				}, delegate(Player player)
				{
					PlayerSpirit playerSpirit = player.PlayerSpirits[_003C_003E8__1.request.SpiritId];
					EquipmentType itemType2 = _003C_003E8__1.request.ItemType;
					if (1 == 0)
					{
					}
					string oldItemId = itemType2 switch
					{
						EquipmentType.Gear => playerSpirit.GearID, 
						EquipmentType.Talent => playerSpirit.TalentID, 
						EquipmentType.HeldItem => playerSpirit.HeldItemID, 
						_ => null, 
					};
					if (1 == 0)
					{
					}
					_003C_003E8__1.oldItemId = oldItemId;
					switch (_003C_003E8__1.request.ItemType)
					{
					case EquipmentType.Gear:
						playerSpirit.EquipGear(_003C_003E8__1.request.ItemId);
						break;
					case EquipmentType.Talent:
						playerSpirit.EquipTalent(_003C_003E8__1.request.ItemId);
						break;
					case EquipmentType.HeldItem:
						playerSpirit.EquipHeldItem(_003C_003E8__1.request.ItemId);
						break;
					}
					if (!string.IsNullOrEmpty(_003C_003E8__1.request.ItemId))
					{
						_003C_003E8__1._003C_003E4__this._inventoryService.ModifyInventory(player, _003C_003E8__1.request.ItemId, -1);
						_003C_003E8__1.inventoryChanges[_003C_003E8__1.request.ItemId] = -1;
					}
					return new
					{
						SpiritId = _003C_003E8__1.request.SpiritId,
						ItemId = _003C_003E8__1.request.ItemId,
						ItemType = _003C_003E8__1.request.ItemType,
						OldItemId = _003C_003E8__1.oldItemId,
						InventoryChanged = (_003C_003E8__1.inventoryChanges.Count > 0)
					};
				}, (Player player, updateResult) =>
				{
					//IL_0068: Unknown result type (might be due to invalid IL or missing references)
					//IL_006d: Unknown result type (might be due to invalid IL or missing references)
					//IL_0072: Unknown result type (might be due to invalid IL or missing references)
					//IL_0077: Unknown result type (might be due to invalid IL or missing references)
					PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
					{
						PlayerId = (player.PlayerID ?? string.Empty)
					};
					playerBatchUpdate.AddSpiritFieldUpdate(_003C_003E8__1.request.SpiritId, delegate(PlayerSpiritFieldUpdate update)
					{
						EquipmentType itemType = _003C_003E8__1.request.ItemType;
						if (1 == 0)
						{
						}
						SpiritUpdateType updateType = itemType switch
						{
							EquipmentType.Gear => SpiritUpdateType.Gear, 
							EquipmentType.Talent => SpiritUpdateType.Talent, 
							EquipmentType.HeldItem => SpiritUpdateType.HeldItem, 
							_ => SpiritUpdateType.Equipment, 
						};
						if (1 == 0)
						{
						}
						update.UpdateType = updateType;
						switch (_003C_003E8__1.request.ItemType)
						{
						case EquipmentType.Gear:
							update.SetGearId = _003C_003E8__1.request.ItemId;
							break;
						case EquipmentType.Talent:
							update.SetTalentId = _003C_003E8__1.request.ItemId;
							break;
						case EquipmentType.HeldItem:
							update.SetHeldItemId = _003C_003E8__1.request.ItemId;
							break;
						}
					});
					if (_003C_003E8__1.inventoryChanges.Count > 0)
					{
						Enumerator<string, int> enumerator = _003C_003E8__1.inventoryChanges.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								KeyValuePair<string, int> current = enumerator.Current;
								playerBatchUpdate.ConsumeInventoryItem(current.Key, current.Value, player);
							}
						}
						finally
						{
							((global::System.IDisposable)enumerator).Dispose();
						}
						playerBatchUpdate.UpdateInventory = true;
					}
					return playerBatchUpdate;
				});
				result = (_003Cresult_003E5__7.Success ? Result<EquipItemResponse>.SuccessResult(new EquipItemResponse(_003Cresult_003E5__7.Data.SpiritId, _003Cresult_003E5__7.Data.ItemId, _003Cresult_003E5__7.Data.ItemType, _003Cresult_003E5__7.Data.OldItemId, _003Cresult_003E5__7.Data.InventoryChanged)) : Result<EquipItemResponse>.FailureResult(_003Cresult_003E5__7.ErrorMessage ?? "Failed to apply state update"));
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Citem_003E5__2 = null;
				_003CtypeRestrictions_003E5__3 = null;
				_003CclassRestrictions_003E5__4 = null;
				_003Cresult_003E5__7 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Citem_003E5__2 = null;
			_003CtypeRestrictions_003E5__3 = null;
			_003CclassRestrictions_003E5__4 = null;
			_003Cresult_003E5__7 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IPlayerStateService _stateService;

	private readonly IPlayerInventoryService _inventoryService;

	private readonly IItemRepository _itemRepository;

	private readonly ISpiritRepository _spiritRepository;

	public EquipItemUseCase(IPlayerStateService stateService, IPlayerInventoryService inventoryService, IItemRepository itemRepository, ISpiritRepository spiritRepository)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
		_inventoryService = inventoryService ?? throw new ArgumentNullException("inventoryService");
		_itemRepository = itemRepository ?? throw new ArgumentNullException("itemRepository");
		_spiritRepository = spiritRepository ?? throw new ArgumentNullException("spiritRepository");
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__5))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<EquipItemResponse>> ExecuteAsync(EquipItemRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		EquipItemRequest request2 = request;
		if (string.IsNullOrEmpty(request2.SpiritId))
		{
			return Result<EquipItemResponse>.FailureResult("Spirit ID is required");
		}
		if (request2.ItemType != 0 && request2.ItemType != EquipmentType.Talent && request2.ItemType != EquipmentType.HeldItem)
		{
			return Result<EquipItemResponse>.FailureResult("Invalid item type");
		}
		EquipmentType itemType = request2.ItemType;
		if (1 == 0)
		{
		}
		Item item2 = itemType switch
		{
			EquipmentType.Gear => await _itemRepository.GetGearByIdAsync(request2.ItemId), 
			EquipmentType.Talent => await _itemRepository.GetTalentByIdAsync(request2.ItemId), 
			EquipmentType.HeldItem => await _itemRepository.GetByIdAsync(request2.ItemId), 
			_ => null, 
		};
		if (1 == 0)
		{
		}
		Item item = item2;
		if (item == null)
		{
			return Result<EquipItemResponse>.FailureResult("Item not found");
		}
		List<string> typeRestrictions = item.Effect?.TypeRestrictions;
		List<string> classRestrictions = item.Effect?.ClassRestrictions;
		bool hasTypeRestriction = typeRestrictions != null && typeRestrictions.Count > 0;
		bool hasClassRestriction = classRestrictions != null && classRestrictions.Count > 0;
		if (hasTypeRestriction || hasClassRestriction)
		{
			Spirit spirit = await _spiritRepository.GetByIdAsync(request2.BaseSpiritId);
			if (spirit == null)
			{
				return Result<EquipItemResponse>.FailureResult("Spirit not found!");
			}
			if (hasTypeRestriction && !Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)typeRestrictions, (Func<string, bool>)((string tr) => tr == ((object)spirit.Type1).ToString() || tr == ((object)spirit.Type2).ToString())))
			{
				return Result<EquipItemResponse>.FailureResult(item.Name + " is restricted to " + string.Join(", ", (global::System.Collections.Generic.IEnumerable<string>)typeRestrictions) + " type(s).");
			}
			if (hasClassRestriction && !Enumerable.Any<string>((global::System.Collections.Generic.IEnumerable<string>)classRestrictions, (Func<string, bool>)((string cr) => cr == spirit.Category || cr == spirit.Category2)))
			{
				return Result<EquipItemResponse>.FailureResult(item.Name + " is restricted to " + string.Join(", ", (global::System.Collections.Generic.IEnumerable<string>)classRestrictions) + " class(es).");
			}
		}
		string oldItemId = null;
		Dictionary<string, int> inventoryChanges = new Dictionary<string, int>();
		var result = _stateService.ExecuteUpdate(delegate(Player player)
		{
			if (!player.PlayerSpirits.ContainsKey(request2.SpiritId))
			{
				return ValidationResult.Failure("Spirit not found in player's collection");
			}
			return (!string.IsNullOrEmpty(request2.ItemId) && !player.HasInventoryItem(request2.ItemId)) ? ValidationResult.Failure("Item '" + request2.ItemId + "' not found in inventory") : ValidationResult.Success();
		}, delegate(Player player)
		{
			PlayerSpirit playerSpirit = player.PlayerSpirits[request2.SpiritId];
			EquipmentType itemType3 = request2.ItemType;
			if (1 == 0)
			{
			}
			string text = itemType3 switch
			{
				EquipmentType.Gear => playerSpirit.GearID, 
				EquipmentType.Talent => playerSpirit.TalentID, 
				EquipmentType.HeldItem => playerSpirit.HeldItemID, 
				_ => null, 
			};
			if (1 == 0)
			{
			}
			oldItemId = text;
			switch (request2.ItemType)
			{
			case EquipmentType.Gear:
				playerSpirit.EquipGear(request2.ItemId);
				break;
			case EquipmentType.Talent:
				playerSpirit.EquipTalent(request2.ItemId);
				break;
			case EquipmentType.HeldItem:
				playerSpirit.EquipHeldItem(request2.ItemId);
				break;
			}
			if (!string.IsNullOrEmpty(request2.ItemId))
			{
				_inventoryService.ModifyInventory(player, request2.ItemId, -1);
				inventoryChanges[request2.ItemId] = -1;
			}
			return new
			{
				SpiritId = request2.SpiritId,
				ItemId = request2.ItemId,
				ItemType = request2.ItemType,
				OldItemId = oldItemId,
				InventoryChanged = (inventoryChanges.Count > 0)
			};
		}, (Player player, updateResult) =>
		{
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty)
			};
			playerBatchUpdate.AddSpiritFieldUpdate(request2.SpiritId, delegate(PlayerSpiritFieldUpdate update)
			{
				EquipmentType itemType2 = request2.ItemType;
				if (1 == 0)
				{
				}
				SpiritUpdateType updateType = itemType2 switch
				{
					EquipmentType.Gear => SpiritUpdateType.Gear, 
					EquipmentType.Talent => SpiritUpdateType.Talent, 
					EquipmentType.HeldItem => SpiritUpdateType.HeldItem, 
					_ => SpiritUpdateType.Equipment, 
				};
				if (1 == 0)
				{
				}
				update.UpdateType = updateType;
				switch (request2.ItemType)
				{
				case EquipmentType.Gear:
					update.SetGearId = request2.ItemId;
					break;
				case EquipmentType.Talent:
					update.SetTalentId = request2.ItemId;
					break;
				case EquipmentType.HeldItem:
					update.SetHeldItemId = request2.ItemId;
					break;
				}
			});
			if (inventoryChanges.Count > 0)
			{
				Enumerator<string, int> enumerator = inventoryChanges.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<string, int> current = enumerator.Current;
						playerBatchUpdate.ConsumeInventoryItem(current.Key, current.Value, player);
					}
				}
				finally
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
				playerBatchUpdate.UpdateInventory = true;
			}
			return playerBatchUpdate;
		});
		if (!result.Success)
		{
			return Result<EquipItemResponse>.FailureResult(result.ErrorMessage ?? "Failed to apply state update");
		}
		return Result<EquipItemResponse>.SuccessResult(new EquipItemResponse(result.Data.SpiritId, result.Data.ItemId, result.Data.ItemType, result.Data.OldItemId, result.Data.InventoryChanged));
	}
}
