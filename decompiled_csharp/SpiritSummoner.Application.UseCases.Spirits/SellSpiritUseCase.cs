using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;

namespace SpiritSummoner.Application.UseCases.Spirits;

public class SellSpiritUseCase
{
	private const int BASE_SELL_PRICE = 50;

	private const int LEVEL_MULTIPLIER = 10;

	private readonly IPlayerStateService _stateService;

	public SellSpiritUseCase(IPlayerStateService stateService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
	}

	public global::System.Threading.Tasks.Task<Result<SellSpiritResponse>> ExecuteAsync(SellSpiritRequest request)
	{
		SellSpiritRequest request2 = request;
		if (string.IsNullOrEmpty(request2.SpiritId))
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<SellSpiritResponse>>(Result<SellSpiritResponse>.FailureResult("Spirit ID is required"));
		}
		int spiritLevel = 0;
		int baseSpiritId = 0;
		long sellPrice = 0L;
		string droppedOrbName = null;
		int droppedOrbQty = 0;
		Result<SellSpiritResponse> result = _stateService.ExecuteUpdate<SellSpiritResponse>(delegate(Player player)
		{
			PlayerSpirit playerSpirit = default(PlayerSpirit);
			if (!player.PlayerSpirits.TryGetValue(request2.SpiritId, ref playerSpirit))
			{
				return ValidationResult.Failure("Spirit not found in player's collection");
			}
			if (Enumerable.Any<List<string>>(player.Squads.Values, (Func<List<string>, bool>)((List<string> squad) => squad.Contains(request2.SpiritId))))
			{
				return ValidationResult.Failure("Cannot sell a spirit that is in a squad");
			}
			if (player.PartnerSpiritId == request2.SpiritId)
			{
				return ValidationResult.Failure("Cannot sell the active battle unit");
			}
			spiritLevel = playerSpirit.Level;
			baseSpiritId = playerSpirit.BaseSpiritID;
			sellPrice = CalculateSellPrice(spiritLevel);
			return ValidationResult.Success();
		}, delegate(Player player)
		{
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			player.AddCurrency("gold", sellPrice);
			player.RemoveSpirit(request2.SpiritId);
			Spirit spiritTemplate = _stateService.GetSpiritTemplate(baseSpiritId);
			if (spiritTemplate != null)
			{
				ValueTuple<string, int, double> val = ComputeOrbDrop(spiritTemplate);
				string item = val.Item1;
				int item2 = val.Item2;
				double item3 = val.Item3;
				if (item2 > 0 && !string.IsNullOrEmpty(item) && Random.Shared.NextDouble() < item3)
				{
					player.AddInventoryItem(item, item2);
					droppedOrbName = item;
					droppedOrbQty = item2;
				}
			}
			return new SellSpiritResponse(request2.SpiritId, spiritLevel, sellPrice, player.Currencies["gold"], droppedOrbName, droppedOrbQty);
		}, delegate(Player player, SellSpiritResponse response)
		{
			PlayerBatchUpdate obj = new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty)
			};
			List<string> obj2 = new List<string>();
			obj2.Add(request2.SpiritId);
			obj.SpiritsToRemove = obj2;
			obj.CurrencyChanges = new Dictionary<string, long> { ["gold"] = sellPrice };
			obj.UpdateSpirits = true;
			PlayerBatchUpdate playerBatchUpdate = obj;
			if (!string.IsNullOrEmpty(droppedOrbName) && droppedOrbQty > 0)
			{
				playerBatchUpdate.InventoryItemChanges[droppedOrbName] = droppedOrbQty;
			}
			return playerBatchUpdate;
		});
		if (!result.Success || result.Data == null)
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<SellSpiritResponse>>(Result<SellSpiritResponse>.FailureResult(result.ErrorMessage ?? "Failed to sell spirit"));
		}
		return global::System.Threading.Tasks.Task.FromResult<Result<SellSpiritResponse>>(Result<SellSpiritResponse>.SuccessResult(result.Data));
	}

	private ValueTuple<string, int, double> ComputeOrbDrop(Spirit currentTemplate)
	{
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		Spirit spirit = currentTemplate;
		int num = 0;
		int num2 = 0;
		while (spirit.PreEvolution != 0)
		{
			Spirit spiritTemplate = _stateService.GetSpiritTemplate(spirit.PreEvolution);
			if (spiritTemplate == null)
			{
				break;
			}
			num += (spiritTemplate.Requirements?.EvolveRequirements?.CoresRequired).GetValueOrDefault();
			spirit = spiritTemplate;
			num2++;
		}
		string text = spirit.ID ?? string.Empty;
		string text2 = spirit.Name + " Orb #" + text;
		int num3 = ((num2 == 0) ? 1 : num);
		double num4 = 0.3 / (double)(num2 + 1);
		return new ValueTuple<string, int, double>(text2, num3, num4);
	}

	private long CalculateSellPrice(int level)
	{
		return 50 + level * 10;
	}
}
