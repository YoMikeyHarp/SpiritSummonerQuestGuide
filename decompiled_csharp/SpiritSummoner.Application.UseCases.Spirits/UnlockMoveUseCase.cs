using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Requirements;
using SpiritSummoner.Domain.Entities.Spirits;

namespace SpiritSummoner.Application.UseCases.Spirits;

public class UnlockMoveUseCase : IUseCase<UnlockMoveRequest, UnlockMoveResponse>
{
	private readonly IPlayerStateService _stateService;

	public UnlockMoveUseCase(IPlayerStateService stateService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
	}

	public global::System.Threading.Tasks.Task<Result<UnlockMoveResponse>> ExecuteAsync(UnlockMoveRequest request)
	{
		UnlockMoveRequest request2 = request;
		if (string.IsNullOrEmpty(request2.SpiritId))
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<UnlockMoveResponse>>(Result<UnlockMoveResponse>.FailureResult("Spirit ID is required"));
		}
		if (string.IsNullOrEmpty(request2.MoveName))
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<UnlockMoveResponse>>(Result<UnlockMoveResponse>.FailureResult("Move name is required"));
		}
		PlayerSpirit playerSpirit = _stateService.GetPlayerSpirit(request2.SpiritId);
		if (playerSpirit == null)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<UnlockMoveResponse>>(Result<UnlockMoveResponse>.FailureResult("Spirit not found in player's collection"));
		}
		if (playerSpirit.Moves != null && playerSpirit.Moves.ContainsKey(request2.MoveName) && playerSpirit.Moves[request2.MoveName].IsUnlocked)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<UnlockMoveResponse>>(Result<UnlockMoveResponse>.FailureResult("Move is already unlocked"));
		}
		Spirit spiritTemplate = _stateService.GetSpiritTemplate(playerSpirit.BaseSpiritID);
		if (spiritTemplate == null)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<UnlockMoveResponse>>(Result<UnlockMoveResponse>.FailureResult("Spirit template not found"));
		}
		List<Move>? learnableMoves = spiritTemplate.LearnableMoves;
		Move move = ((learnableMoves != null) ? Enumerable.FirstOrDefault<Move>((global::System.Collections.Generic.IEnumerable<Move>)learnableMoves, (Func<Move, bool>)((Move m) => m.Name == request2.MoveName)) : null);
		if (move == null)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<UnlockMoveResponse>>(Result<UnlockMoveResponse>.FailureResult("Move '" + request2.MoveName + "' is not learnable by this spirit"));
		}
		MoveRequirements requirements = move.UnlockRequirements;
		Dictionary<string, int> inventoryChanges = new Dictionary<string, int>();
		var result = _stateService.ExecuteUpdate(delegate(Player player)
		{
			if (!requirements.IsFree)
			{
				if (requirements.PlayerLevelRequired > 0 && player.PlayerLevel < requirements.PlayerLevelRequired)
				{
					return ValidationResult.Failure($"Player level {requirements.PlayerLevelRequired} required to unlock this move. Current level: {player.PlayerLevel}", new ValidationError("INSUFFICIENT_LEVEL", $"Reach level {requirements.PlayerLevelRequired} to unlock this move", new Dictionary<string, object>
					{
						["RequiredLevel"] = requirements.PlayerLevelRequired,
						["CurrentLevel"] = player.PlayerLevel
					}));
				}
				if (!string.IsNullOrEmpty(requirements.RequiredItem) && requirements.RequiredItemCount > 0 && !player.HasInventoryItem(requirements.RequiredItem, requirements.RequiredItemCount))
				{
					Inventory inventory = default(Inventory);
					int num = (player.Inventory.TryGetValue(requirements.RequiredItem, ref inventory) ? inventory.Amount : 0);
					return ValidationResult.Failure($"Insufficient {requirements.RequiredItem}. Required: {requirements.RequiredItemCount}, Available: {num}", new ValidationError("INSUFFICIENT_ITEM", $"You need {requirements.RequiredItemCount}x {requirements.RequiredItem} to unlock this move", new Dictionary<string, object>
					{
						["ItemId"] = requirements.RequiredItem,
						["RequiredAmount"] = requirements.RequiredItemCount,
						["CurrentAmount"] = num
					}));
				}
			}
			return ValidationResult.Success();
		}, delegate(Player player)
		{
			PlayerSpirit playerSpirit2 = player.PlayerSpirits[request2.SpiritId];
			if (!requirements.IsFree && !string.IsNullOrEmpty(requirements.RequiredItem) && requirements.RequiredItemCount > 0)
			{
				player.AddInventoryItem(requirements.RequiredItem, -requirements.RequiredItemCount);
				inventoryChanges[requirements.RequiredItem] = -requirements.RequiredItemCount;
			}
			playerSpirit2.UnlockMove(request2.MoveName);
			if (request2.SetAsActive)
			{
				playerSpirit2.SetActiveMove(request2.MoveName, isActive: true);
			}
			return new
			{
				MoveName = request2.MoveName,
				IsActive = request2.SetAsActive,
				ItemsConsumed = ((inventoryChanges.Count > 0) ? new Dictionary<string, int>((IDictionary<string, int>)(object)Enumerable.ToDictionary<KeyValuePair<string, int>, string, int>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, int>>)inventoryChanges, (Func<KeyValuePair<string, int>, string>)((KeyValuePair<string, int> k) => k.Key), (Func<KeyValuePair<string, int>, int>)((KeyValuePair<string, int> v) => Math.Abs(v.Value)))) : null)
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
				update.UpdateType = SpiritUpdateType.Moves;
				update.MoveChanges = new Dictionary<string, MoveStateUpdate> { [request2.MoveName] = new MoveStateUpdate
				{
					MoveName = request2.MoveName,
					IsUnlocked = true,
					IsActiveMove = request2.SetAsActive
				} };
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
			return global::System.Threading.Tasks.Task.FromResult<Result<UnlockMoveResponse>>(Result<UnlockMoveResponse>.FailureResult(result.ErrorMessage ?? "Failed to apply state update"));
		}
		return global::System.Threading.Tasks.Task.FromResult<Result<UnlockMoveResponse>>(Result<UnlockMoveResponse>.SuccessResult(new UnlockMoveResponse(request2.SpiritId, result.Data.MoveName, result.Data.IsActive, result.Data.ItemsConsumed)));
	}
}
