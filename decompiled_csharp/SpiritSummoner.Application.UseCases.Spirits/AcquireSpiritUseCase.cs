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

namespace SpiritSummoner.Application.UseCases.Spirits;

public class AcquireSpiritUseCase : IUseCase<AcquireSpiritRequest, AcquireSpiritResponse>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public AcquireSpiritRequest request;

		public Spirit baseSpirit;

		public PlayerSpirit createdSpirit;

		public AcquireSpiritUseCase _003C_003E4__this;

		internal ValidationResult _003CExecuteAsync_003Eb__0(Player player)
		{
			if (request.DeductSoulOrb)
			{
				string itemName = $"soulOrb{baseSpirit.Type1}";
				if (!player.HasInventoryItem(itemName))
				{
					return ValidationResult.Failure($"No {baseSpirit.Type1} Soul Orb available");
				}
			}
			return ValidationResult.Success();
		}

		internal AcquireSpiritResponse _003CExecuteAsync_003Eb__1(Player player)
		{
			int level = Math.Max(1, player.PlayerLevel / 3);
			createdSpirit = _003C_003E4__this._playerSpiritFactory.CreateForPlayer(baseSpirit, player, level);
			player.AddSpirit(createdSpirit);
			if (request.DeductSoulOrb)
			{
				string itemName = $"soulOrb{baseSpirit.Type1}";
				player.AddInventoryItem(itemName, -1);
			}
			return new AcquireSpiritResponse(Success: true, createdSpirit.PlayerSpiritID, baseSpirit.Name ?? string.Empty, baseSpirit.Image ?? string.Empty, level);
		}

		internal PlayerBatchUpdate _003CExecuteAsync_003Eb__2(Player player, AcquireSpiritResponse response)
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
			PlayerBatchUpdate playerBatchUpdate = obj;
			if (request.DeductSoulOrb)
			{
				string itemId = $"soulOrb{baseSpirit.Type1}";
				playerBatchUpdate.ConsumeInventoryItem(itemId, -1, player);
			}
			return playerBatchUpdate;
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<AcquireSpiritResponse>> _003C_003Et__builder;

		public AcquireSpiritRequest request;

		public AcquireSpiritUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass5_0 _003C_003E8__1;

		private Result<AcquireSpiritResponse> _003Cresult_003E5__2;

		private Spirit _003C_003Es__3;

		private TaskAwaiter<Spirit?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<AcquireSpiritResponse> result;
			try
			{
				TaskAwaiter<Spirit> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Spirit>);
					num = (_003C_003E1__state = -1);
					goto IL_00db;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass5_0();
				_003C_003E8__1.request = request;
				_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
				if (!string.IsNullOrEmpty(_003C_003E8__1.request.SpiritId))
				{
					awaiter = _003C_003E4__this._spiritRepo.GetByIdAsync(_003C_003E8__1.request.SpiritId).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CExecuteAsync_003Ed__5 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Spirit>, _003CExecuteAsync_003Ed__5>(ref awaiter, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_00db;
				}
				result = Result<AcquireSpiritResponse>.FailureResult("Spirit ID is required");
				goto end_IL_0007;
				IL_00db:
				_003C_003Es__3 = awaiter.GetResult();
				_003C_003E8__1.baseSpirit = _003C_003Es__3;
				_003C_003Es__3 = null;
				if (_003C_003E8__1.baseSpirit == null)
				{
					result = Result<AcquireSpiritResponse>.FailureResult("Spirit not found");
				}
				else
				{
					_003C_003E8__1.createdSpirit = null;
					_003Cresult_003E5__2 = _003C_003E4__this._stateService.ExecuteUpdate<AcquireSpiritResponse>(delegate(Player player)
					{
						if (_003C_003E8__1.request.DeductSoulOrb)
						{
							string itemName2 = $"soulOrb{_003C_003E8__1.baseSpirit.Type1}";
							if (!player.HasInventoryItem(itemName2))
							{
								return ValidationResult.Failure($"No {_003C_003E8__1.baseSpirit.Type1} Soul Orb available");
							}
						}
						return ValidationResult.Success();
					}, delegate(Player player)
					{
						int level = Math.Max(1, player.PlayerLevel / 3);
						_003C_003E8__1.createdSpirit = _003C_003E8__1._003C_003E4__this._playerSpiritFactory.CreateForPlayer(_003C_003E8__1.baseSpirit, player, level);
						player.AddSpirit(_003C_003E8__1.createdSpirit);
						if (_003C_003E8__1.request.DeductSoulOrb)
						{
							string itemName = $"soulOrb{_003C_003E8__1.baseSpirit.Type1}";
							player.AddInventoryItem(itemName, -1);
						}
						return new AcquireSpiritResponse(Success: true, _003C_003E8__1.createdSpirit.PlayerSpiritID, _003C_003E8__1.baseSpirit.Name ?? string.Empty, _003C_003E8__1.baseSpirit.Image ?? string.Empty, level);
					}, delegate(Player player, AcquireSpiritResponse response)
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
						PlayerBatchUpdate playerBatchUpdate = obj;
						if (_003C_003E8__1.request.DeductSoulOrb)
						{
							string itemId = $"soulOrb{_003C_003E8__1.baseSpirit.Type1}";
							playerBatchUpdate.ConsumeInventoryItem(itemId, -1, player);
						}
						return playerBatchUpdate;
					});
					result = (_003Cresult_003E5__2.Success ? Result<AcquireSpiritResponse>.SuccessResult(_003Cresult_003E5__2.Data) : Result<AcquireSpiritResponse>.FailureResult(_003Cresult_003E5__2.ErrorMessage ?? "Failed to acquire spirit"));
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

	public AcquireSpiritUseCase(ISpiritRepository spiritRepo, IPlayerStateService stateService, IPlayerSpiritFactory playerSpiritFactory)
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
	public async global::System.Threading.Tasks.Task<Result<AcquireSpiritResponse>> ExecuteAsync(AcquireSpiritRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		AcquireSpiritRequest request2 = request;
		if (string.IsNullOrEmpty(request2.SpiritId))
		{
			return Result<AcquireSpiritResponse>.FailureResult("Spirit ID is required");
		}
		Spirit baseSpirit = await _spiritRepo.GetByIdAsync(request2.SpiritId);
		if (baseSpirit == null)
		{
			return Result<AcquireSpiritResponse>.FailureResult("Spirit not found");
		}
		PlayerSpirit createdSpirit = null;
		Result<AcquireSpiritResponse> result = _stateService.ExecuteUpdate<AcquireSpiritResponse>(delegate(Player player)
		{
			if (request2.DeductSoulOrb)
			{
				string itemName2 = $"soulOrb{baseSpirit.Type1}";
				if (!player.HasInventoryItem(itemName2))
				{
					return ValidationResult.Failure($"No {baseSpirit.Type1} Soul Orb available");
				}
			}
			return ValidationResult.Success();
		}, delegate(Player player)
		{
			int level = Math.Max(1, player.PlayerLevel / 3);
			createdSpirit = _playerSpiritFactory.CreateForPlayer(baseSpirit, player, level);
			player.AddSpirit(createdSpirit);
			if (request2.DeductSoulOrb)
			{
				string itemName = $"soulOrb{baseSpirit.Type1}";
				player.AddInventoryItem(itemName, -1);
			}
			return new AcquireSpiritResponse(Success: true, createdSpirit.PlayerSpiritID, baseSpirit.Name ?? string.Empty, baseSpirit.Image ?? string.Empty, level);
		}, delegate(Player player, AcquireSpiritResponse response)
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
			PlayerBatchUpdate playerBatchUpdate = obj;
			if (request2.DeductSoulOrb)
			{
				string itemId = $"soulOrb{baseSpirit.Type1}";
				playerBatchUpdate.ConsumeInventoryItem(itemId, -1, player);
			}
			return playerBatchUpdate;
		});
		if (!result.Success)
		{
			return Result<AcquireSpiritResponse>.FailureResult(result.ErrorMessage ?? "Failed to acquire spirit");
		}
		return Result<AcquireSpiritResponse>.SuccessResult(result.Data);
	}
}
