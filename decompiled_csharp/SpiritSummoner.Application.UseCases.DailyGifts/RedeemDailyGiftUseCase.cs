using System;
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
using SpiritSummoner.Infrastructure.Services;

namespace SpiritSummoner.Application.UseCases.DailyGifts;

public class RedeemDailyGiftUseCase
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int originalLevel;

		public DailyGiftDTO gift;

		public Spirit spiritTemplate;

		public PlayerSpirit createdSpirit;

		public RedeemDailyGiftUseCase _003C_003E4__this;

		internal ValidationResult _003CExecuteAsync_003Eb__0(Player player)
		{
			originalLevel = player.PlayerLevel;
			return ValidationResult.Success();
		}

		internal RedeemDailyGiftResponse _003CExecuteAsync_003Eb__1(Player player)
		{
			if (gift.RewardType == "spirit" && spiritTemplate != null)
			{
				int level = Math.Max(1, player.PlayerLevel / 3);
				createdSpirit = _003C_003E4__this._playerSpiritFactory.CreateForPlayer(spiritTemplate, player, level);
			}
			return _003C_003E4__this.ApplyReward(player, gift, spiritTemplate, createdSpirit);
		}

		internal PlayerBatchUpdate _003CExecuteAsync_003Eb__2(Player player, RedeemDailyGiftResponse response)
		{
			return _003C_003E4__this.BuildBatch(player, response, gift, spiritTemplate, createdSpirit, originalLevel);
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<RedeemDailyGiftResponse>> _003C_003Et__builder;

		public DailyGiftDTO gift;

		public RedeemDailyGiftUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass7_0 _003C_003E8__1;

		private Result<RedeemDailyGiftResponse> _003Cresult_003E5__2;

		private string _003CplayerId_003E5__3;

		private Spirit _003C_003Es__4;

		private TaskAwaiter<Spirit?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<RedeemDailyGiftResponse> result;
			try
			{
				TaskAwaiter<Spirit> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Spirit>);
					num = (_003C_003E1__state = -1);
					goto IL_0167;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass7_0();
				_003C_003E8__1.gift = gift;
				_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
				if (_003C_003E8__1.gift == null)
				{
					result = Result<RedeemDailyGiftResponse>.FailureResult("Gift cannot be null");
				}
				else if (string.IsNullOrEmpty(_003C_003E8__1.gift.Id))
				{
					result = Result<RedeemDailyGiftResponse>.FailureResult("Gift ID is required");
				}
				else
				{
					_003C_003E8__1.spiritTemplate = null;
					_003C_003E8__1.createdSpirit = null;
					if (!(_003C_003E8__1.gift.RewardType == "spirit"))
					{
						goto IL_01cb;
					}
					if (!string.IsNullOrEmpty(_003C_003E8__1.gift.ItemKey))
					{
						awaiter = _003C_003E4__this._spiritRepo.GetByIdAsync(_003C_003E8__1.gift.ItemKey).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CExecuteAsync_003Ed__7 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Spirit>, _003CExecuteAsync_003Ed__7>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_0167;
					}
					result = Result<RedeemDailyGiftResponse>.FailureResult("Spirit gift requires a spirit template ID in ItemKey");
				}
				goto end_IL_0007;
				IL_01cb:
				_003C_003E8__1.originalLevel = 0;
				_003Cresult_003E5__2 = _003C_003E4__this._stateService.ExecuteUpdate<RedeemDailyGiftResponse>(delegate(Player player)
				{
					_003C_003E8__1.originalLevel = player.PlayerLevel;
					return ValidationResult.Success();
				}, delegate(Player player)
				{
					if (_003C_003E8__1.gift.RewardType == "spirit" && _003C_003E8__1.spiritTemplate != null)
					{
						int level = Math.Max(1, player.PlayerLevel / 3);
						_003C_003E8__1.createdSpirit = _003C_003E8__1._003C_003E4__this._playerSpiritFactory.CreateForPlayer(_003C_003E8__1.spiritTemplate, player, level);
					}
					return _003C_003E8__1._003C_003E4__this.ApplyReward(player, _003C_003E8__1.gift, _003C_003E8__1.spiritTemplate, _003C_003E8__1.createdSpirit);
				}, (Player player, RedeemDailyGiftResponse response) => _003C_003E8__1._003C_003E4__this.BuildBatch(player, response, _003C_003E8__1.gift, _003C_003E8__1.spiritTemplate, _003C_003E8__1.createdSpirit, _003C_003E8__1.originalLevel));
				if (!_003Cresult_003E5__2.Success)
				{
					result = Result<RedeemDailyGiftResponse>.FailureResult(_003Cresult_003E5__2.ErrorMessage ?? "Failed to redeem gift");
				}
				else
				{
					_003CplayerId_003E5__3 = _003C_003E4__this._stateService.CurrentPlayerId ?? string.Empty;
					_003C_003E4__this._dailyGiftService.MarkAsRedeemedAsync(_003CplayerId_003E5__3, _003C_003E8__1.gift.Id);
					result = Result<RedeemDailyGiftResponse>.SuccessResult(_003Cresult_003E5__2.Data);
				}
				goto end_IL_0007;
				IL_0167:
				_003C_003Es__4 = awaiter.GetResult();
				_003C_003E8__1.spiritTemplate = _003C_003Es__4;
				_003C_003Es__4 = null;
				if (_003C_003E8__1.spiritTemplate != null)
				{
					goto IL_01cb;
				}
				result = Result<RedeemDailyGiftResponse>.FailureResult("Spirit template '" + _003C_003E8__1.gift.ItemKey + "' not found");
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Cresult_003E5__2 = null;
				_003CplayerId_003E5__3 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Cresult_003E5__2 = null;
			_003CplayerId_003E5__3 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private const int LEVEL_DIVISOR = 3;

	private readonly IPlayerStateService _stateService;

	private readonly IPlayerProgressionService _progressionService;

	private readonly ISpiritRepository _spiritRepo;

	private readonly IDailyGiftService _dailyGiftService;

	private readonly IPlayerSpiritFactory _playerSpiritFactory;

	public RedeemDailyGiftUseCase(IPlayerStateService stateService, IPlayerProgressionService progressionService, ISpiritRepository spiritRepo, IDailyGiftService dailyGiftService, IPlayerSpiritFactory playerSpiritFactory)
	{
		_stateService = stateService;
		_progressionService = progressionService;
		_spiritRepo = spiritRepo;
		_dailyGiftService = dailyGiftService;
		_playerSpiritFactory = playerSpiritFactory;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__7))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<RedeemDailyGiftResponse>> ExecuteAsync(DailyGiftDTO gift)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		DailyGiftDTO gift2 = gift;
		if (gift2 == null)
		{
			return Result<RedeemDailyGiftResponse>.FailureResult("Gift cannot be null");
		}
		if (string.IsNullOrEmpty(gift2.Id))
		{
			return Result<RedeemDailyGiftResponse>.FailureResult("Gift ID is required");
		}
		Spirit spiritTemplate = null;
		PlayerSpirit createdSpirit = null;
		if (gift2.RewardType == "spirit")
		{
			if (string.IsNullOrEmpty(gift2.ItemKey))
			{
				return Result<RedeemDailyGiftResponse>.FailureResult("Spirit gift requires a spirit template ID in ItemKey");
			}
			spiritTemplate = await _spiritRepo.GetByIdAsync(gift2.ItemKey);
			if (spiritTemplate == null)
			{
				return Result<RedeemDailyGiftResponse>.FailureResult("Spirit template '" + gift2.ItemKey + "' not found");
			}
		}
		int originalLevel = 0;
		Result<RedeemDailyGiftResponse> result = _stateService.ExecuteUpdate<RedeemDailyGiftResponse>(delegate(Player player)
		{
			originalLevel = player.PlayerLevel;
			return ValidationResult.Success();
		}, delegate(Player player)
		{
			if (gift2.RewardType == "spirit" && spiritTemplate != null)
			{
				int level = Math.Max(1, player.PlayerLevel / 3);
				createdSpirit = _playerSpiritFactory.CreateForPlayer(spiritTemplate, player, level);
			}
			return ApplyReward(player, gift2, spiritTemplate, createdSpirit);
		}, (Player player, RedeemDailyGiftResponse response) => BuildBatch(player, response, gift2, spiritTemplate, createdSpirit, originalLevel));
		if (!result.Success)
		{
			return Result<RedeemDailyGiftResponse>.FailureResult(result.ErrorMessage ?? "Failed to redeem gift");
		}
		string playerId = _stateService.CurrentPlayerId ?? string.Empty;
		_dailyGiftService.MarkAsRedeemedAsync(playerId, gift2.Id);
		return Result<RedeemDailyGiftResponse>.SuccessResult(result.Data);
	}

	private RedeemDailyGiftResponse ApplyReward(Player player, DailyGiftDTO gift, Spirit? spiritTemplate, PlayerSpirit? newSpirit)
	{
		string rewardType = gift.RewardType;
		string text = rewardType;
		switch (_003CPrivateImplementationDetails_003E.ComputeStringHash(text))
		{
		case 3966162835u:
			if (!(text == "gold"))
			{
				break;
			}
			goto IL_00ee;
		case 2214363133u:
			if (!(text == "gems"))
			{
				break;
			}
			goto IL_00ee;
		case 1923516200u:
			if (text == "exp")
			{
				_progressionService.GainExperience(player, gift.Amount);
			}
			break;
		case 2671260646u:
			if (!(text == "item"))
			{
				break;
			}
			goto IL_0119;
		case 2064056110u:
			if (!(text == "gear"))
			{
				break;
			}
			goto IL_0119;
		case 2265984043u:
			if (!(text == "talent"))
			{
				break;
			}
			goto IL_0119;
		case 3325022696u:
			{
				if (text == "spirit" && spiritTemplate != null && newSpirit != null)
				{
					player.AddSpirit(newSpirit);
				}
				break;
			}
			IL_00ee:
			player.AddCurrency(gift.RewardType, gift.Amount);
			break;
			IL_0119:
			if (!string.IsNullOrEmpty(gift.ItemKey))
			{
				player.AddInventoryItem(gift.ItemKey, (int)gift.Amount);
			}
			break;
		}
		return new RedeemDailyGiftResponse(gift.RewardType, gift.Amount, gift.ItemKey, spiritTemplate?.Name);
	}

	private PlayerBatchUpdate BuildBatch(Player player, RedeemDailyGiftResponse response, DailyGiftDTO gift, Spirit? spiritTemplate, PlayerSpirit? newSpirit, int originalLevel)
	{
		PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
		{
			PlayerId = (player.PlayerID ?? string.Empty)
		};
		string rewardType = gift.RewardType;
		string text = rewardType;
		switch (_003CPrivateImplementationDetails_003E.ComputeStringHash(text))
		{
		case 3966162835u:
			if (!(text == "gold"))
			{
				break;
			}
			goto IL_011d;
		case 2214363133u:
			if (!(text == "gems"))
			{
				break;
			}
			goto IL_011d;
		case 1923516200u:
			if (text == "exp")
			{
				bool flag = player.PlayerLevel > originalLevel;
				playerBatchUpdate.ExperienceGain = (int)gift.Amount;
				if (flag)
				{
					playerBatchUpdate.SetLevelUp(player);
				}
			}
			break;
		case 2671260646u:
			if (!(text == "item"))
			{
				break;
			}
			goto IL_015c;
		case 2064056110u:
			if (!(text == "gear"))
			{
				break;
			}
			goto IL_015c;
		case 2265984043u:
			if (!(text == "talent"))
			{
				break;
			}
			goto IL_015c;
		case 3325022696u:
			{
				if (text == "spirit" && spiritTemplate != null && newSpirit != null)
				{
					playerBatchUpdate.SpiritsToAdd.Add(NewSpiritDTO.FromPlayerSpirit(newSpirit));
					playerBatchUpdate.UpdateSpirits = true;
				}
				break;
			}
			IL_011d:
			playerBatchUpdate.AddCurrencyChange(gift.RewardType, gift.Amount);
			break;
			IL_015c:
			if (!string.IsNullOrEmpty(gift.ItemKey))
			{
				playerBatchUpdate.AddInventoryChange(gift.ItemKey, (int)gift.Amount);
			}
			break;
		}
		return playerBatchUpdate;
	}
}
