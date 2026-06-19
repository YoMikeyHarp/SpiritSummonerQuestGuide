using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.DTOs;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Interfaces.Services;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Shop;

public class PurchaseSpiritUseCase : IUseCase<PurchaseSpiritRequest, PurchaseSpiritResponse>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public string currencyType;

		public int currencyAmount;

		public string orbKey;

		public int orbAmount;

		public string itemRequired;

		public PlayerSpirit createdSpirit;

		public PurchaseSpiritUseCase _003C_003E4__this;

		public Spirit spirit;

		internal ValidationResult _003CExecuteAsync_003Eb__0(Player player)
		{
			long valueOrDefault = CollectionExtensions.GetValueOrDefault<string, long>(player.Currencies, currencyType, 0L);
			if (valueOrDefault < currencyAmount)
			{
				return ValidationResult.Failure($"Insufficient {currencyType}. Need {currencyAmount}, have {valueOrDefault}");
			}
			if (!string.IsNullOrEmpty(orbKey) && !player.HasInventoryItem(orbKey, orbAmount))
			{
				return ValidationResult.Failure("Missing required item: " + orbKey);
			}
			if (!string.IsNullOrEmpty(itemRequired) && !player.HasInventoryItem(itemRequired, orbAmount))
			{
				return ValidationResult.Failure("Missing required item: " + itemRequired);
			}
			return ValidationResult.Success();
		}

		internal PurchaseSpiritResponse _003CExecuteAsync_003Eb__1(Player player)
		{
			int level = Math.Max(1, player.PlayerLevel / 3);
			createdSpirit = _003C_003E4__this._playerSpiritFactory.CreateForPlayer(spirit, player, level);
			player.AddSpirit(createdSpirit);
			player.AddCurrency(currencyType, -currencyAmount);
			if (!string.IsNullOrEmpty(orbKey))
			{
				player.AddInventoryItem(orbKey, -orbAmount);
			}
			if (!string.IsNullOrEmpty(itemRequired))
			{
				player.AddInventoryItem(itemRequired, -orbAmount);
			}
			return new PurchaseSpiritResponse(Success: true, createdSpirit.PlayerSpiritID, spirit.Name ?? string.Empty, spirit.Image ?? string.Empty, level, currencyType, currencyAmount);
		}

		internal PlayerBatchUpdate _003CExecuteAsync_003Eb__2(Player player, PurchaseSpiritResponse response)
		{
			PlayerBatchUpdate obj = new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty)
			};
			List<NewSpiritDTO> obj2;
			if (createdSpirit == null)
			{
				obj2 = new List<NewSpiritDTO>();
			}
			else
			{
				obj2 = new List<NewSpiritDTO>();
				obj2.Add(NewSpiritDTO.FromPlayerSpirit(createdSpirit));
			}
			obj.SpiritsToAdd = obj2;
			obj.UpdateSpirits = createdSpirit != null;
			obj.CurrencyChanges = new Dictionary<string, long> { [currencyType] = -currencyAmount };
			PlayerBatchUpdate playerBatchUpdate = obj;
			if (!string.IsNullOrEmpty(orbKey))
			{
				playerBatchUpdate.ConsumeInventoryItem(orbKey, -orbAmount, player);
			}
			if (!string.IsNullOrEmpty(itemRequired))
			{
				playerBatchUpdate.ConsumeInventoryItem(itemRequired, -orbAmount, player);
			}
			return playerBatchUpdate;
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<PurchaseSpiritResponse>> _003C_003Et__builder;

		public PurchaseSpiritRequest request;

		public PurchaseSpiritUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass5_0 _003C_003E8__1;

		private Result<PurchaseSpiritResponse> _003Cresult_003E5__2;

		private Spirit _003C_003Es__3;

		private TaskAwaiter<Spirit?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<PurchaseSpiritResponse> result;
			try
			{
				TaskAwaiter<Spirit> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Spirit>);
					num = (_003C_003E1__state = -1);
					goto IL_00c0;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass5_0();
				_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
				if (!string.IsNullOrEmpty(request.SpiritId))
				{
					awaiter = _003C_003E4__this._spiritRepo.GetByIdAsync(request.SpiritId).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CExecuteAsync_003Ed__5 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Spirit>, _003CExecuteAsync_003Ed__5>(ref awaiter, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_00c0;
				}
				result = Result<PurchaseSpiritResponse>.FailureResult("Spirit ID is required");
				goto end_IL_0007;
				IL_00c0:
				_003C_003Es__3 = awaiter.GetResult();
				_003C_003E8__1.spirit = _003C_003Es__3;
				_003C_003Es__3 = null;
				if (_003C_003E8__1.spirit == null)
				{
					result = Result<PurchaseSpiritResponse>.FailureResult("Spirit not found");
				}
				else
				{
					_003C_003E8__1.currencyType = _003C_003E8__1.spirit.Requirements?.CurrencyCost?.Type ?? "gold";
					if (string.IsNullOrEmpty(_003C_003E8__1.currencyType))
					{
						_003C_003E8__1.currencyType = "gold";
					}
					if (_003C_003E8__1.currencyType == "clancredits")
					{
						_003C_003E8__1.currencyType = "guildCoins";
					}
					_003C_003E8__1.currencyAmount = (_003C_003E8__1.spirit.Requirements?.CurrencyCost?.Amount).GetValueOrDefault();
					if (_003C_003E8__1.currencyAmount == 0)
					{
						_003C_003E8__1.currencyAmount = 5000;
					}
					_003C_003E8__1.orbKey = _003C_003E8__1.spirit.Requirements?.ItemRequirement?.ItemType ?? (_003C_003E8__1.spirit.Name + " Orb #" + _003C_003E8__1.spirit.ID);
					_003C_003E8__1.itemRequired = string.Empty;
					if (_003C_003E8__1.orbKey != _003C_003E8__1.spirit.Name + " Orb #" + _003C_003E8__1.spirit.ID)
					{
						_003C_003E8__1.itemRequired = _003C_003E8__1.orbKey;
						_003C_003E8__1.orbKey = _003C_003E8__1.spirit.Name + " Orb #" + _003C_003E8__1.spirit.ID;
					}
					_003C_003E8__1.orbAmount = (_003C_003E8__1.spirit.Requirements?.ItemRequirement?.Amount).GetValueOrDefault(1);
					if (_003C_003E8__1.orbAmount == 0)
					{
						_003C_003E8__1.orbAmount = 1;
					}
					if (!request.RequireOrb)
					{
						_003C_003E8__1.orbKey = string.Empty;
					}
					_003C_003E8__1.createdSpirit = null;
					_003Cresult_003E5__2 = _003C_003E4__this._stateService.ExecuteUpdate<PurchaseSpiritResponse>(delegate(Player player)
					{
						long valueOrDefault = CollectionExtensions.GetValueOrDefault<string, long>(player.Currencies, _003C_003E8__1.currencyType, 0L);
						if (valueOrDefault < _003C_003E8__1.currencyAmount)
						{
							return ValidationResult.Failure($"Insufficient {_003C_003E8__1.currencyType}. Need {_003C_003E8__1.currencyAmount}, have {valueOrDefault}");
						}
						if (!string.IsNullOrEmpty(_003C_003E8__1.orbKey) && !player.HasInventoryItem(_003C_003E8__1.orbKey, _003C_003E8__1.orbAmount))
						{
							return ValidationResult.Failure("Missing required item: " + _003C_003E8__1.orbKey);
						}
						return (!string.IsNullOrEmpty(_003C_003E8__1.itemRequired) && !player.HasInventoryItem(_003C_003E8__1.itemRequired, _003C_003E8__1.orbAmount)) ? ValidationResult.Failure("Missing required item: " + _003C_003E8__1.itemRequired) : ValidationResult.Success();
					}, delegate(Player player)
					{
						int level = Math.Max(1, player.PlayerLevel / 3);
						_003C_003E8__1.createdSpirit = _003C_003E8__1._003C_003E4__this._playerSpiritFactory.CreateForPlayer(_003C_003E8__1.spirit, player, level);
						player.AddSpirit(_003C_003E8__1.createdSpirit);
						player.AddCurrency(_003C_003E8__1.currencyType, -_003C_003E8__1.currencyAmount);
						if (!string.IsNullOrEmpty(_003C_003E8__1.orbKey))
						{
							player.AddInventoryItem(_003C_003E8__1.orbKey, -_003C_003E8__1.orbAmount);
						}
						if (!string.IsNullOrEmpty(_003C_003E8__1.itemRequired))
						{
							player.AddInventoryItem(_003C_003E8__1.itemRequired, -_003C_003E8__1.orbAmount);
						}
						return new PurchaseSpiritResponse(Success: true, _003C_003E8__1.createdSpirit.PlayerSpiritID, _003C_003E8__1.spirit.Name ?? string.Empty, _003C_003E8__1.spirit.Image ?? string.Empty, level, _003C_003E8__1.currencyType, _003C_003E8__1.currencyAmount);
					}, delegate(Player player, PurchaseSpiritResponse response)
					{
						PlayerBatchUpdate obj = new PlayerBatchUpdate
						{
							PlayerId = (player.PlayerID ?? string.Empty)
						};
						List<NewSpiritDTO> obj2;
						if (_003C_003E8__1.createdSpirit == null)
						{
							obj2 = new List<NewSpiritDTO>();
						}
						else
						{
							obj2 = new List<NewSpiritDTO>();
							obj2.Add(NewSpiritDTO.FromPlayerSpirit(_003C_003E8__1.createdSpirit));
						}
						obj.SpiritsToAdd = obj2;
						obj.UpdateSpirits = _003C_003E8__1.createdSpirit != null;
						obj.CurrencyChanges = new Dictionary<string, long> { [_003C_003E8__1.currencyType] = -_003C_003E8__1.currencyAmount };
						PlayerBatchUpdate playerBatchUpdate = obj;
						if (!string.IsNullOrEmpty(_003C_003E8__1.orbKey))
						{
							playerBatchUpdate.ConsumeInventoryItem(_003C_003E8__1.orbKey, -_003C_003E8__1.orbAmount, player);
						}
						if (!string.IsNullOrEmpty(_003C_003E8__1.itemRequired))
						{
							playerBatchUpdate.ConsumeInventoryItem(_003C_003E8__1.itemRequired, -_003C_003E8__1.orbAmount, player);
						}
						return playerBatchUpdate;
					});
					result = (_003Cresult_003E5__2.Success ? Result<PurchaseSpiritResponse>.SuccessResult(_003Cresult_003E5__2.Data) : Result<PurchaseSpiritResponse>.FailureResult(_003Cresult_003E5__2.ErrorMessage ?? "Failed to purchase spirit"));
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Cresult_003E5__2 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Cresult_003E5__2 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly ISpiritRepository _spiritRepo;

	private readonly IPlayerStateService _stateService;

	private readonly IPlayerSpiritFactory _playerSpiritFactory;

	private const int LEVEL_DIVISOR = 3;

	public PurchaseSpiritUseCase(ISpiritRepository spiritRepo, IPlayerStateService stateService, IPlayerSpiritFactory playerSpiritFactory)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		_spiritRepo = spiritRepo ?? throw new ArgumentNullException("spiritRepo");
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
		_playerSpiritFactory = playerSpiritFactory ?? throw new ArgumentNullException("playerSpiritFactory");
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__5))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<PurchaseSpiritResponse>> ExecuteAsync(PurchaseSpiritRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(request.SpiritId))
		{
			return Result<PurchaseSpiritResponse>.FailureResult("Spirit ID is required");
		}
		Spirit spirit = await _spiritRepo.GetByIdAsync(request.SpiritId);
		if (spirit == null)
		{
			return Result<PurchaseSpiritResponse>.FailureResult("Spirit not found");
		}
		string currencyType = spirit.Requirements?.CurrencyCost?.Type ?? "gold";
		if (string.IsNullOrEmpty(currencyType))
		{
			currencyType = "gold";
		}
		if (currencyType == "clancredits")
		{
			currencyType = "guildCoins";
		}
		int currencyAmount = (spirit.Requirements?.CurrencyCost?.Amount).GetValueOrDefault();
		if (currencyAmount == 0)
		{
			currencyAmount = 5000;
		}
		string orbKey = spirit.Requirements?.ItemRequirement?.ItemType ?? (spirit.Name + " Orb #" + spirit.ID);
		string itemRequired = string.Empty;
		if (orbKey != spirit.Name + " Orb #" + spirit.ID)
		{
			itemRequired = orbKey;
			orbKey = spirit.Name + " Orb #" + spirit.ID;
		}
		int orbAmount = (spirit.Requirements?.ItemRequirement?.Amount).GetValueOrDefault(1);
		if (orbAmount == 0)
		{
			orbAmount = 1;
		}
		if (!request.RequireOrb)
		{
			orbKey = string.Empty;
		}
		PlayerSpirit createdSpirit = null;
		Result<PurchaseSpiritResponse> result = _stateService.ExecuteUpdate<PurchaseSpiritResponse>(delegate(Player player)
		{
			long valueOrDefault = CollectionExtensions.GetValueOrDefault<string, long>(player.Currencies, currencyType, 0L);
			if (valueOrDefault < currencyAmount)
			{
				return ValidationResult.Failure($"Insufficient {currencyType}. Need {currencyAmount}, have {valueOrDefault}");
			}
			if (!string.IsNullOrEmpty(orbKey) && !player.HasInventoryItem(orbKey, orbAmount))
			{
				return ValidationResult.Failure("Missing required item: " + orbKey);
			}
			return (!string.IsNullOrEmpty(itemRequired) && !player.HasInventoryItem(itemRequired, orbAmount)) ? ValidationResult.Failure("Missing required item: " + itemRequired) : ValidationResult.Success();
		}, delegate(Player player)
		{
			int level = Math.Max(1, player.PlayerLevel / 3);
			createdSpirit = _playerSpiritFactory.CreateForPlayer(spirit, player, level);
			player.AddSpirit(createdSpirit);
			player.AddCurrency(currencyType, -currencyAmount);
			if (!string.IsNullOrEmpty(orbKey))
			{
				player.AddInventoryItem(orbKey, -orbAmount);
			}
			if (!string.IsNullOrEmpty(itemRequired))
			{
				player.AddInventoryItem(itemRequired, -orbAmount);
			}
			return new PurchaseSpiritResponse(Success: true, createdSpirit.PlayerSpiritID, spirit.Name ?? string.Empty, spirit.Image ?? string.Empty, level, currencyType, currencyAmount);
		}, delegate(Player player, PurchaseSpiritResponse response)
		{
			PlayerBatchUpdate obj = new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty)
			};
			List<NewSpiritDTO> obj2;
			if (createdSpirit == null)
			{
				obj2 = new List<NewSpiritDTO>();
			}
			else
			{
				obj2 = new List<NewSpiritDTO>();
				obj2.Add(NewSpiritDTO.FromPlayerSpirit(createdSpirit));
			}
			obj.SpiritsToAdd = obj2;
			obj.UpdateSpirits = createdSpirit != null;
			obj.CurrencyChanges = new Dictionary<string, long> { [currencyType] = -currencyAmount };
			PlayerBatchUpdate playerBatchUpdate = obj;
			if (!string.IsNullOrEmpty(orbKey))
			{
				playerBatchUpdate.ConsumeInventoryItem(orbKey, -orbAmount, player);
			}
			if (!string.IsNullOrEmpty(itemRequired))
			{
				playerBatchUpdate.ConsumeInventoryItem(itemRequired, -orbAmount, player);
			}
			return playerBatchUpdate;
		});
		if (!result.Success)
		{
			return Result<PurchaseSpiritResponse>.FailureResult(result.ErrorMessage ?? "Failed to purchase spirit");
		}
		return Result<PurchaseSpiritResponse>.SuccessResult(result.Data);
	}
}
