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
using SpiritSummoner.Domain.Enums.Spirits;
using SpiritSummoner.Domain.Interfaces.Services;

namespace SpiritSummoner.Application.UseCases.Spirits;

public class EvolveSpiritUseCase
{
	private readonly IPlayerStateService _stateService;

	private readonly ISpiritBusinessService _spiritBusinessService;

	public EvolveSpiritUseCase(IPlayerStateService stateService, ISpiritBusinessService spiritBusinessService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
		_spiritBusinessService = spiritBusinessService ?? throw new ArgumentNullException("spiritBusinessService");
	}

	public global::System.Threading.Tasks.Task<Result<EvolveSpiritResponse>> ExecuteAsync(EvolveSpiritRequest request)
	{
		EvolveSpiritRequest request2 = request;
		if (string.IsNullOrEmpty(request2.SpiritId))
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<EvolveSpiritResponse>>(Result<EvolveSpiritResponse>.FailureResult("Spirit ID is required"));
		}
		PlayerSpirit spirit = _stateService.GetPlayerSpirit(request2.SpiritId);
		if (spirit == null)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<EvolveSpiritResponse>>(Result<EvolveSpiritResponse>.FailureResult("Spirit not found"));
		}
		Spirit template = _stateService.GetSpiritTemplate(spirit.BaseSpiritID);
		if (template == null || template.Evolution == 0)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<EvolveSpiritResponse>>(Result<EvolveSpiritResponse>.FailureResult("This spirit cannot evolve"));
		}
		Spirit evolvedTemplate = _stateService.GetSpiritTemplate(template.Evolution);
		if (evolvedTemplate == null)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<EvolveSpiritResponse>>(Result<EvolveSpiritResponse>.FailureResult("Evolved form data not found"));
		}
		EvolveRequirement evolveRequirement = template.Requirements?.EvolveRequirements;
		string itemRequired = evolveRequirement?.ItemRequired;
		int amount = evolveRequirement?.Amount ?? 1;
		int spiritLevelRequired = evolveRequirement?.LevelRequired ?? 0;
		int playerLevelRequired = (template.Requirements?.LevelRequirement?.PlayerLevelRequired).GetValueOrDefault();
		bool isGoldCost = string.Equals(itemRequired, "gold", (StringComparison)5) || itemRequired.Contains("Orb", (StringComparison)1);
		int coresRequired = (template.Requirements?.EvolveRequirements?.CoresRequired).GetValueOrDefault(10);
		bool? obj;
		if (evolveRequirement == null)
		{
			obj = null;
		}
		else
		{
			string? itemRequired2 = evolveRequirement.ItemRequired;
			obj = ((itemRequired2 != null) ? new bool?(!itemRequired2.Contains("Orb", (StringComparison)1)) : null);
		}
		bool? flag = obj;
		string orbRequired = (flag.GetValueOrDefault() ? (template.Name + " Orb #" + template.ID) : (evolveRequirement?.ItemRequired ?? ""));
		string special = template.Requirements?.EvolveRequirements?.Special ?? string.Empty;
		if (string.IsNullOrEmpty(special))
		{
			special = GetEvoItemRequired(template.Type1);
		}
		var result = _stateService.ExecuteUpdate(delegate(Player player)
		{
			if (spiritLevelRequired > 0 && spirit.Level < spiritLevelRequired)
			{
				return ValidationResult.Failure($"Spirit must be at least level {spiritLevelRequired} to evolve (currently {spirit.Level})");
			}
			if (playerLevelRequired > 0 && player.PlayerLevel < playerLevelRequired)
			{
				return ValidationResult.Failure($"Player must be at least level {playerLevelRequired} to evolve this spirit (currently {player.PlayerLevel})");
			}
			if (!string.IsNullOrEmpty(itemRequired) && amount > 0)
			{
				if (isGoldCost)
				{
					long valueOrDefault = CollectionExtensions.GetValueOrDefault<string, long>(player.Currencies, "gold", 0L);
					if (valueOrDefault < amount)
					{
						return ValidationResult.Failure($"Insufficient gold. Required: {amount} G, Available: {valueOrDefault} G");
					}
				}
				else
				{
					if (amount == 0 && itemRequired.Contains("Orb", (StringComparison)1))
					{
						amount = 25;
					}
					if (!itemRequired.Contains("Orb", (StringComparison)1) && !player.HasInventoryItem(itemRequired, amount))
					{
						return ValidationResult.Failure($"Missing required item: {amount}x {itemRequired}");
					}
					long valueOrDefault2 = CollectionExtensions.GetValueOrDefault<string, long>(player.Currencies, "gold", 0L);
					if (valueOrDefault2 < amount)
					{
						return ValidationResult.Failure($"Insufficient gold. Required: {amount} G, Available: {valueOrDefault2} G");
					}
				}
			}
			if (!string.IsNullOrEmpty(special) && !player.HasInventoryItem(special))
			{
				return ValidationResult.Failure("Missing required item: 1x " + special.ToUpper());
			}
			return (coresRequired > 0 && !string.IsNullOrEmpty(orbRequired) && !player.HasInventoryItem(orbRequired, coresRequired)) ? ValidationResult.Failure($"Missing required item: {coresRequired}x {orbRequired}") : ValidationResult.Success();
		}, delegate(Player player)
		{
			PlayerSpirit playerSpirit = _stateService.GetPlayerSpirit(request2.SpiritId);
			if (!string.IsNullOrEmpty(itemRequired) && amount > 0)
			{
				if (isGoldCost)
				{
					player.AddCurrency("gold", -amount);
				}
				player.AddInventoryItem(itemRequired, -amount);
			}
			if (!string.IsNullOrEmpty(orbRequired) && !itemRequired.Contains("Orb", (StringComparison)1))
			{
				player.AddInventoryItem(orbRequired, -coresRequired);
			}
			player.AddInventoryItem(special, -1);
			int num = _spiritBusinessService.CalculateMaxHP(template.BaseStats?.HP ?? 0, playerSpirit.Level);
			int num2 = _spiritBusinessService.CalculateMaxHP(evolvedTemplate.BaseStats?.HP ?? 0, playerSpirit.Level);
			int num3 = num2 - num;
			playerSpirit.EvolveTo(evolvedTemplate, num3);
			return new
			{
				NewBaseSpiritId = template.Evolution,
				NewName = (evolvedTemplate.Name ?? playerSpirit.Name),
				NewImage = evolvedTemplate.Image,
				Moves = playerSpirit.Moves,
				NewNickname = playerSpirit.Nickname,
				HPChange = num3,
				OrbConsumed = ((!string.IsNullOrEmpty(orbRequired)) ? orbRequired : string.Empty),
				AmountOrbsConsumed = ((!string.IsNullOrEmpty(orbRequired)) ? coresRequired : 0),
				SpecialConsumed = ((!string.IsNullOrEmpty(GetEvoItemRequired(template.Type1))) ? GetEvoItemRequired(template.Type1) : string.Empty)
			};
		}, (Player player, updateResult) =>
		{
			PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty)
			};
			if (!string.IsNullOrEmpty(itemRequired) && amount > 0)
			{
				if (isGoldCost)
				{
					playerBatchUpdate.CurrencyChanges["gold"] = -amount;
				}
				else
				{
					playerBatchUpdate.InventoryItemChanges[itemRequired] = -amount;
				}
			}
			if (!string.IsNullOrEmpty(updateResult.OrbConsumed))
			{
				playerBatchUpdate.InventoryItemChanges[updateResult.OrbConsumed] = -updateResult.AmountOrbsConsumed;
			}
			if (!string.IsNullOrEmpty(updateResult.SpecialConsumed))
			{
				playerBatchUpdate.InventoryItemChanges[updateResult.SpecialConsumed] = -1;
			}
			playerBatchUpdate.AddSpiritFieldUpdate(request2.SpiritId, delegate(PlayerSpiritFieldUpdate update)
			{
				update.UpdateType = SpiritUpdateType.Evolve;
				update.SetBaseSpiritId = updateResult.NewBaseSpiritId;
				update.SetName = updateResult.NewName;
				IReadOnlyDictionary<string, MoveState> moves = updateResult.Moves;
				update.MoveChanges = ((moves != null) ? Enumerable.ToDictionary<KeyValuePair<string, MoveState>, string, MoveStateUpdate>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, MoveState>>)moves, (Func<KeyValuePair<string, MoveState>, string>)((KeyValuePair<string, MoveState> kv) => kv.Key), (Func<KeyValuePair<string, MoveState>, MoveStateUpdate>)((KeyValuePair<string, MoveState> kv) => new MoveStateUpdate(kv.Key, kv.Value.IsActiveMove, kv.Value.IsUnlocked))) : null);
				update.SetNickname = updateResult.NewNickname;
				update.HPChange = updateResult.HPChange;
			});
			return playerBatchUpdate;
		});
		if (!result.Success || result.Data == null)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<EvolveSpiritResponse>>(Result<EvolveSpiritResponse>.FailureResult(result.ErrorMessage ?? "Failed to evolve spirit"));
		}
		return global::System.Threading.Tasks.Task.FromResult<Result<EvolveSpiritResponse>>(Result<EvolveSpiritResponse>.SuccessResult(new EvolveSpiritResponse(request2.SpiritId, result.Data.NewBaseSpiritId, result.Data.NewName, result.Data.NewImage)));
	}

	public static string GetEvoItemRequired(SpiritType spiritType)
	{
		if (1 == 0)
		{
		}
		string result = spiritType switch
		{
			SpiritType.Water => "seashell", 
			SpiritType.Poison => "mushroom", 
			SpiritType.Dark => "onyx", 
			SpiritType.Fire => "flint", 
			SpiritType.Grass => "seed", 
			SpiritType.Light => "diamond", 
			SpiritType.Wind => "feather", 
			SpiritType.Electric => string.Empty, 
			SpiritType.Ground => "clay", 
			SpiritType.Neutral => "pearl", 
			SpiritType.Metal => string.Empty, 
			_ => string.Empty, 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
