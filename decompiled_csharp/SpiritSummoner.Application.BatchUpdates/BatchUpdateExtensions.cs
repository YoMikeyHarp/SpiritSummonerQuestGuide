using System;
using System.Collections.Generic;
using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Application.BatchUpdates;

public static class BatchUpdateExtensions
{
	public static void ConsumeInventoryItem(this PlayerBatchUpdate batch, string itemId, int delta, Player player)
	{
		Inventory inventory = default(Inventory);
		if (!player.Inventory.TryGetValue(itemId, ref inventory) || inventory.Amount <= 0)
		{
			batch.InventoryKeysToDelete.Add(itemId);
		}
		else
		{
			batch.AddInventoryChange(itemId, delta);
		}
	}

	public static void AddInventoryChange(this PlayerBatchUpdate batch, string itemName, int amountChange)
	{
		if (batch.InventoryItemChanges.ContainsKey(itemName))
		{
			Dictionary<string, int> inventoryItemChanges = batch.InventoryItemChanges;
			inventoryItemChanges[itemName] += amountChange;
		}
		else
		{
			batch.InventoryItemChanges[itemName] = amountChange;
		}
	}

	public static void AddInventoryChanges(this PlayerBatchUpdate batch, Dictionary<string, int> changes)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		Enumerator<string, int> enumerator = changes.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, int> current = enumerator.Current;
				batch.AddInventoryChange(current.Key, current.Value);
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator).Dispose();
		}
	}

	public static void AddCurrencyChange(this PlayerBatchUpdate batch, string currencyType, long delta)
	{
		if (batch.CurrencyChanges.ContainsKey(currencyType))
		{
			Dictionary<string, long> currencyChanges = batch.CurrencyChanges;
			currencyChanges[currencyType] += delta;
		}
		else
		{
			batch.CurrencyChanges[currencyType] = delta;
		}
	}

	public static void AddCurrencyChanges(this PlayerBatchUpdate batch, Dictionary<string, long> changes)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		Enumerator<string, long> enumerator = changes.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, long> current = enumerator.Current;
				batch.AddCurrencyChange(current.Key, current.Value);
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator).Dispose();
		}
	}

	public static void SetLevelUp(this PlayerBatchUpdate batch, Player player)
	{
		batch.UpdateLevel = true;
		batch.NewPlayerLevel = player.PlayerLevel;
		batch.NewMaxEXP = player.MaxEXP;
		batch.NewMaxEP = player.MaxEP;
		batch.NewMaxSP = player.MaxSP;
		batch.NewEXP = player.EXP;
	}

	public static void AddSpiritFieldUpdate(this PlayerBatchUpdate batch, string spiritId, Action<PlayerSpiritFieldUpdate> configure)
	{
		if (!batch.SpiritFieldUpdates.ContainsKey(spiritId))
		{
			batch.SpiritFieldUpdates[spiritId] = new PlayerSpiritFieldUpdate
			{
				SpiritId = spiritId
			};
		}
		configure.Invoke(batch.SpiritFieldUpdates[spiritId]);
	}
}
