using System;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Interfaces.Services;

namespace SpiritSummoner.Application.UseCases.Spirits;

public class UnequipItemUseCase : IUseCase<UnequipItemRequest, UnequipItemResponse>
{
	private readonly IPlayerStateService _stateService;

	private readonly IPlayerInventoryService _inventoryService;

	public UnequipItemUseCase(IPlayerStateService stateService, IPlayerInventoryService inventoryService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
		_inventoryService = inventoryService ?? throw new ArgumentNullException("inventoryService");
	}

	public global::System.Threading.Tasks.Task<Result<UnequipItemResponse>> ExecuteAsync(UnequipItemRequest request)
	{
		UnequipItemRequest request2 = request;
		if (string.IsNullOrEmpty(request2.SpiritId))
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<UnequipItemResponse>>(Result<UnequipItemResponse>.FailureResult("Spirit ID is required"));
		}
		if (request2.ItemType != 0 && request2.ItemType != EquipmentType.Talent && request2.ItemType != EquipmentType.HeldItem)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<UnequipItemResponse>>(Result<UnequipItemResponse>.FailureResult("Invalid item type"));
		}
		string unequippedItemId = null;
		var result = _stateService.ExecuteUpdate((Player player) => (!player.PlayerSpirits.ContainsKey(request2.SpiritId)) ? ValidationResult.Failure("Spirit not found in player's collection") : ValidationResult.Success(), delegate(Player player)
		{
			PlayerSpirit playerSpirit = player.PlayerSpirits[request2.SpiritId];
			EquipmentType itemType2 = request2.ItemType;
			if (1 == 0)
			{
			}
			string text = itemType2 switch
			{
				EquipmentType.Gear => playerSpirit.GearID, 
				EquipmentType.Talent => playerSpirit.TalentID, 
				EquipmentType.HeldItem => playerSpirit.HeldItemID, 
				_ => null, 
			};
			if (1 == 0)
			{
			}
			unequippedItemId = text;
			switch (request2.ItemType)
			{
			case EquipmentType.Gear:
				playerSpirit.EquipGear(null);
				break;
			case EquipmentType.Talent:
				playerSpirit.EquipTalent(null);
				break;
			case EquipmentType.HeldItem:
				playerSpirit.EquipHeldItem(null);
				break;
			}
			return new
			{
				SpiritId = request2.SpiritId,
				ItemType = request2.ItemType,
				UnequippedItemId = unequippedItemId
			};
		}, (Player player, updateResult) =>
		{
			PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty)
			};
			playerBatchUpdate.AddSpiritFieldUpdate(request2.SpiritId, delegate(PlayerSpiritFieldUpdate update)
			{
				EquipmentType itemType = request2.ItemType;
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
				switch (request2.ItemType)
				{
				case EquipmentType.Gear:
					update.SetGearId = "";
					break;
				case EquipmentType.Talent:
					update.SetTalentId = "";
					break;
				case EquipmentType.HeldItem:
					update.SetHeldItemId = "";
					break;
				}
			});
			return playerBatchUpdate;
		});
		if (!result.Success)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<UnequipItemResponse>>(Result<UnequipItemResponse>.FailureResult(result.ErrorMessage ?? "Failed to apply state update"));
		}
		return global::System.Threading.Tasks.Task.FromResult<Result<UnequipItemResponse>>(Result<UnequipItemResponse>.SuccessResult(new UnequipItemResponse(result.Data.SpiritId, result.Data.ItemType, result.Data.UnequippedItemId)));
	}
}
