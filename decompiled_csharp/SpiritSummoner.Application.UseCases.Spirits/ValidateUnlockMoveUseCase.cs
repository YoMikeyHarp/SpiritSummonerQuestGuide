using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Requirements;
using SpiritSummoner.Domain.Entities.Spirits;

namespace SpiritSummoner.Application.UseCases.Spirits;

public class ValidateUnlockMoveUseCase : IUseCase<ValidateUnlockMoveRequest, ValidateUnlockMoveResponse>
{
	private readonly IPlayerStateService _stateService;

	public ValidateUnlockMoveUseCase(IPlayerStateService stateService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
	}

	public global::System.Threading.Tasks.Task<Result<ValidateUnlockMoveResponse>> ExecuteAsync(ValidateUnlockMoveRequest request)
	{
		ValidateUnlockMoveRequest request2 = request;
		if (string.IsNullOrEmpty(request2.SpiritId))
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<ValidateUnlockMoveResponse>>(Result<ValidateUnlockMoveResponse>.FailureResult("Spirit ID is required"));
		}
		if (string.IsNullOrEmpty(request2.MoveName))
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<ValidateUnlockMoveResponse>>(Result<ValidateUnlockMoveResponse>.FailureResult("Move name is required"));
		}
		Player currentPlayer = _stateService.GetCurrentPlayer();
		if (currentPlayer == null)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<ValidateUnlockMoveResponse>>(Result<ValidateUnlockMoveResponse>.FailureResult("No active player session"));
		}
		PlayerSpirit playerSpirit = _stateService.GetPlayerSpirit(request2.SpiritId);
		if (playerSpirit == null)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<ValidateUnlockMoveResponse>>(Result<ValidateUnlockMoveResponse>.FailureResult("Spirit not found in player's collection"));
		}
		if (playerSpirit.Moves != null && playerSpirit.Moves.ContainsKey(request2.MoveName) && playerSpirit.Moves[request2.MoveName].IsUnlocked)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<ValidateUnlockMoveResponse>>(Result<ValidateUnlockMoveResponse>.FailureResult("Move is already unlocked"));
		}
		Spirit spiritTemplate = _stateService.GetSpiritTemplate(playerSpirit.BaseSpiritID);
		if (spiritTemplate == null)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<ValidateUnlockMoveResponse>>(Result<ValidateUnlockMoveResponse>.FailureResult("Spirit template not found"));
		}
		List<Move>? learnableMoves = spiritTemplate.LearnableMoves;
		Move move = ((learnableMoves != null) ? Enumerable.FirstOrDefault<Move>((global::System.Collections.Generic.IEnumerable<Move>)learnableMoves, (Func<Move, bool>)((Move m) => m.Name == request2.MoveName)) : null);
		if (move == null)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<ValidateUnlockMoveResponse>>(Result<ValidateUnlockMoveResponse>.FailureResult("Move '" + request2.MoveName + "' is not learnable by this spirit"));
		}
		MoveRequirements unlockRequirements = move.UnlockRequirements;
		global::System.Collections.Generic.IReadOnlyList<string> baseMoveNames = spiritTemplate.GetBaseMoveNames();
		if (Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)baseMoveNames, request2.MoveName))
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<ValidateUnlockMoveResponse>>(Result<ValidateUnlockMoveResponse>.SuccessResult(new ValidateUnlockMoveResponse(request2.SpiritId, request2.MoveName, IsFree: true, new Dictionary<string, int>(), 0, 0)));
		}
		Dictionary<string, int> val = new Dictionary<string, int>();
		if (!unlockRequirements.IsFree)
		{
			if (unlockRequirements.SpiritLevelRequired > 0 && playerSpirit.Level < unlockRequirements.SpiritLevelRequired)
			{
				return global::System.Threading.Tasks.Task.FromResult<Result<ValidateUnlockMoveResponse>>(Result<ValidateUnlockMoveResponse>.FailureResult($"Spirit level {unlockRequirements.SpiritLevelRequired} required to unlock this move. Current spirit level: {playerSpirit.Level}", new ValidationError("INSUFFICIENT_SPIRIT_LEVEL", $"Reach spirit level {unlockRequirements.SpiritLevelRequired} to unlock this move", new Dictionary<string, object>
				{
					["RequiredSpiritLevel"] = unlockRequirements.SpiritLevelRequired,
					["CurrentSpiritLevel"] = playerSpirit.Level
				})));
			}
			if (unlockRequirements.PlayerLevelRequired > 0 && currentPlayer.PlayerLevel < unlockRequirements.PlayerLevelRequired)
			{
				return global::System.Threading.Tasks.Task.FromResult<Result<ValidateUnlockMoveResponse>>(Result<ValidateUnlockMoveResponse>.FailureResult($"Player level {unlockRequirements.PlayerLevelRequired} required to unlock this move. Current level: {currentPlayer.PlayerLevel}", new ValidationError("INSUFFICIENT_LEVEL", $"Reach level {unlockRequirements.PlayerLevelRequired} to unlock this move", new Dictionary<string, object>
				{
					["RequiredLevel"] = unlockRequirements.PlayerLevelRequired,
					["CurrentLevel"] = currentPlayer.PlayerLevel
				})));
			}
			int num = 0;
			int num2 = default(int);
			Inventory inventory = default(Inventory);
			if (request2.CurrentInventorySnapshot != null && request2.CurrentInventorySnapshot.TryGetValue(GetCrystalRequirement(move.Power), ref num2))
			{
				num = num2;
			}
			else if (currentPlayer.Inventory.TryGetValue(GetCrystalRequirement(move.Power), ref inventory))
			{
				num = inventory.Amount;
			}
			if (num < 1)
			{
				return global::System.Threading.Tasks.Task.FromResult<Result<ValidateUnlockMoveResponse>>(Result<ValidateUnlockMoveResponse>.FailureResult($"Insufficient {GetCrystalRequirement(move.Power)}. Required: {1}, Available: {num}", new ValidationError("INSUFFICIENT_ITEM", $"You need {1}x {GetCrystalRequirement(move.Power)} to unlock this move", new Dictionary<string, object>
				{
					["ItemId"] = GetCrystalRequirement(move.Power),
					["RequiredAmount"] = 1,
					["CurrentAmount"] = num
				})));
			}
			val[unlockRequirements.RequiredItem] = unlockRequirements.RequiredItemCount;
		}
		return global::System.Threading.Tasks.Task.FromResult<Result<ValidateUnlockMoveResponse>>(Result<ValidateUnlockMoveResponse>.SuccessResult(new ValidateUnlockMoveResponse(request2.SpiritId, request2.MoveName, unlockRequirements.IsFree, val, unlockRequirements.PlayerLevelRequired, unlockRequirements.SpiritLevelRequired)));
	}

	public static string GetCrystalRequirement(int power)
	{
		if (1 == 0)
		{
		}
		string result = ((power <= 120) ? ((power > 115) ? "greenCrystal" : "blueCrystal") : ((power > 125) ? "redCrystal" : "goldCrystal"));
		if (1 == 0)
		{
		}
		return result;
	}
}
