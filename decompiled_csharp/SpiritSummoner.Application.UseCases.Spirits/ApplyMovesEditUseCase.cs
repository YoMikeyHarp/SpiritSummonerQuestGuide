using System;
using System.Collections;
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

public class ApplyMovesEditUseCase : IUseCase<ApplyMovesEditRequest, ApplyMovesEditResponse>
{
	private readonly IPlayerStateService _stateService;

	public ApplyMovesEditUseCase(IPlayerStateService stateService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
	}

	public global::System.Threading.Tasks.Task<Result<ApplyMovesEditResponse>> ExecuteAsync(ApplyMovesEditRequest request)
	{
		ApplyMovesEditRequest request2 = request;
		if (string.IsNullOrEmpty(request2.SpiritId))
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<ApplyMovesEditResponse>>(Result<ApplyMovesEditResponse>.FailureResult("Spirit ID is required"));
		}
		if (request2.MoveChanges == null || request2.MoveChanges.Count == 0)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<ApplyMovesEditResponse>>(Result<ApplyMovesEditResponse>.FailureResult("No move changes provided"));
		}
		PlayerSpirit spirit = _stateService.GetPlayerSpirit(request2.SpiritId);
		if (spirit == null)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<ApplyMovesEditResponse>>(Result<ApplyMovesEditResponse>.FailureResult("Spirit not found in player's collection"));
		}
		Spirit spiritTemplate = _stateService.GetSpiritTemplate(spirit.BaseSpiritID);
		if (spiritTemplate == null)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<ApplyMovesEditResponse>>(Result<ApplyMovesEditResponse>.FailureResult("Spirit template not found"));
		}
		if (Enumerable.Count<MoveChangeRequest>((global::System.Collections.Generic.IEnumerable<MoveChangeRequest>)request2.MoveChanges, (Func<MoveChangeRequest, bool>)((MoveChangeRequest m) => m.IsActive)) == 0)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<ApplyMovesEditResponse>>(Result<ApplyMovesEditResponse>.FailureResult("At least one move must be active"));
		}
		global::System.Collections.Generic.IReadOnlyList<string> baseMoveNames = spiritTemplate.GetBaseMoveNames();
		global::System.Collections.Generic.IEnumerator<string> enumerator = ((global::System.Collections.Generic.IEnumerable<string>)baseMoveNames).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				string baseName = enumerator.Current;
				MoveChangeRequest moveChangeRequest = Enumerable.FirstOrDefault<MoveChangeRequest>((global::System.Collections.Generic.IEnumerable<MoveChangeRequest>)request2.MoveChanges, (Func<MoveChangeRequest, bool>)((MoveChangeRequest m) => m.MoveName == baseName));
				if (moveChangeRequest != null && !moveChangeRequest.IsActive)
				{
					return global::System.Threading.Tasks.Task.FromResult<Result<ApplyMovesEditResponse>>(Result<ApplyMovesEditResponse>.FailureResult("Base move '" + baseName + "' cannot be deactivated"));
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
		Dictionary<string, int> totalResourceCost = new Dictionary<string, int>();
		var result = _stateService.ExecuteUpdate(delegate(Player player)
		{
			//IL_0249: Unknown result type (might be due to invalid IL or missing references)
			//IL_024e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			//IL_025c: Unknown result type (might be due to invalid IL or missing references)
			global::System.Collections.Generic.IEnumerator<MoveChangeRequest> enumerator5 = Enumerable.Where<MoveChangeRequest>((global::System.Collections.Generic.IEnumerable<MoveChangeRequest>)request2.MoveChanges, (Func<MoveChangeRequest, bool>)((MoveChangeRequest m) => m.IsNewlyUnlocked)).GetEnumerator();
			string text3 = default(string);
			try
			{
				while (((global::System.Collections.IEnumerator)enumerator5).MoveNext())
				{
					MoveChangeRequest moveChange = enumerator5.Current;
					if (!Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)baseMoveNames, moveChange.MoveName))
					{
						List<Move>? learnableMoves = spiritTemplate.LearnableMoves;
						Move move = ((learnableMoves != null) ? Enumerable.FirstOrDefault<Move>((global::System.Collections.Generic.IEnumerable<Move>)learnableMoves, (Func<Move, bool>)((Move m) => m.Name == moveChange.MoveName)) : null);
						if (move == null)
						{
							return ValidationResult.Failure("Move '" + moveChange.MoveName + "' is not learnable by this spirit");
						}
						MoveRequirements unlockRequirements = move.UnlockRequirements;
						if (!unlockRequirements.IsFree)
						{
							if (unlockRequirements.SpiritLevelRequired > 0 && spirit.Level < unlockRequirements.SpiritLevelRequired)
							{
								return ValidationResult.Failure($"Spirit level {unlockRequirements.SpiritLevelRequired} required to unlock {moveChange.MoveName}");
							}
							if (unlockRequirements.PlayerLevelRequired > 0 && player.PlayerLevel < unlockRequirements.PlayerLevelRequired)
							{
								return ValidationResult.Failure($"Player level {unlockRequirements.PlayerLevelRequired} required to unlock {moveChange.MoveName}");
							}
							string crystalRequirement = ValidateUnlockMoveUseCase.GetCrystalRequirement(move.Power);
							if (!totalResourceCost.ContainsKey(crystalRequirement))
							{
								totalResourceCost[crystalRequirement] = 0;
							}
							Dictionary<string, int> val2 = totalResourceCost;
							text3 = crystalRequirement;
							val2[text3] += 1;
						}
					}
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator5)?.Dispose();
			}
			Enumerator<string, int> enumerator6 = totalResourceCost.GetEnumerator();
			try
			{
				int num5 = default(int);
				Inventory inventory = default(Inventory);
				while (enumerator6.MoveNext())
				{
					enumerator6.Current.Deconstruct(ref text3, ref num5);
					string text4 = text3;
					int num6 = num5;
					if (!player.HasInventoryItem(text4, num6))
					{
						int num7 = (player.Inventory.TryGetValue(text4, ref inventory) ? inventory.Amount : 0);
						return ValidationResult.Failure($"Insufficient {text4}. Required: {num6}, Available: {num7}", new ValidationError("INSUFFICIENT_ITEM", $"You need {num6}x {text4} to unlock selected moves", new Dictionary<string, object>
						{
							["ItemId"] = text4,
							["RequiredAmount"] = num6,
							["CurrentAmount"] = num7
						}));
					}
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator6).Dispose();
			}
			return ValidationResult.Success();
		}, delegate(Player player)
		{
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			PlayerSpirit playerSpirit = player.PlayerSpirits[request2.SpiritId];
			Dictionary<string, MoveStateUpdate> val = new Dictionary<string, MoveStateUpdate>();
			Enumerator<MoveChangeRequest> enumerator3 = request2.MoveChanges.GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					MoveChangeRequest current = enumerator3.Current;
					if (current.IsNewlyUnlocked)
					{
						playerSpirit.UnlockMove(current.MoveName);
					}
					playerSpirit.SetActiveMove(current.MoveName, current.IsActive);
					val[current.MoveName] = new MoveStateUpdate
					{
						MoveName = current.MoveName,
						IsUnlocked = (current.IsNewlyUnlocked || current.WasAlreadyUnlocked),
						IsActiveMove = current.IsActive
					};
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator3).Dispose();
			}
			Enumerator<string, int> enumerator4 = totalResourceCost.GetEnumerator();
			try
			{
				string text2 = default(string);
				int num3 = default(int);
				while (enumerator4.MoveNext())
				{
					enumerator4.Current.Deconstruct(ref text2, ref num3);
					string itemName = text2;
					int num4 = num3;
					player.AddInventoryItem(itemName, -num4);
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator4).Dispose();
			}
			return new
			{
				MoveUpdates = val
			};
		}, (Player player, updateResult) =>
		{
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty)
			};
			playerBatchUpdate.AddSpiritFieldUpdate(request2.SpiritId, delegate(PlayerSpiritFieldUpdate update)
			{
				update.UpdateType = SpiritUpdateType.Moves;
				update.MoveChanges = updateResult.MoveUpdates;
			});
			if (totalResourceCost.Count > 0)
			{
				Enumerator<string, int> enumerator2 = totalResourceCost.GetEnumerator();
				try
				{
					string text = default(string);
					int num = default(int);
					while (enumerator2.MoveNext())
					{
						enumerator2.Current.Deconstruct(ref text, ref num);
						string itemId = text;
						int num2 = num;
						playerBatchUpdate.ConsumeInventoryItem(itemId, -num2, player);
					}
				}
				finally
				{
					((global::System.IDisposable)enumerator2).Dispose();
				}
				playerBatchUpdate.UpdateInventory = true;
			}
			return playerBatchUpdate;
		});
		if (!result.Success)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<ApplyMovesEditResponse>>(Result<ApplyMovesEditResponse>.FailureResult(result.ErrorMessage ?? "Failed"));
		}
		return global::System.Threading.Tasks.Task.FromResult<Result<ApplyMovesEditResponse>>(Result<ApplyMovesEditResponse>.SuccessResult(new ApplyMovesEditResponse(request2.SpiritId, Enumerable.ToList<string>((global::System.Collections.Generic.IEnumerable<string>)result.Data.MoveUpdates.Keys), totalResourceCost)));
	}
}
