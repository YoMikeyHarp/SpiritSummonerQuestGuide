using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Configuration.Battles;
using SpiritSummoner.Domain.Entities.Battles;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Interfaces.Services;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Battles;

public class ClaimBattleTaskRewardUseCase : IUseCase<ClaimBattleTaskRewardRequest, BattleTaskReward>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public BattleTaskDefinition def;

		public ClaimBattleTaskRewardUseCase _003C_003E4__this;

		public BattleTaskReward reward;

		internal BattleTaskReward _003CExecuteAsync_003Eb__1(Player p)
		{
			if (def.CrystalReward > 0)
			{
				_003C_003E4__this._currencyService.ModifyCurrency(p, "gems", def.CrystalReward);
			}
			if (def.EnergyReward > 0)
			{
				p.SetEP(Math.Min(p.EP + def.EnergyReward, p.MaxEP));
			}
			if (def.GuildCoinsReward > 0)
			{
				_003C_003E4__this._currencyService.ModifyCurrency(p, "guildCoins", def.GuildCoinsReward);
			}
			return reward;
		}

		internal PlayerBatchUpdate _003CExecuteAsync_003Eb__2(Player p, BattleTaskReward _)
		{
			PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
			{
				PlayerId = (p.PlayerID ?? string.Empty)
			};
			Dictionary<string, long> val = new Dictionary<string, long>();
			if (def.CrystalReward > 0)
			{
				val["gems"] = def.CrystalReward;
			}
			if (def.GuildCoinsReward > 0)
			{
				val["guildCoins"] = def.GuildCoinsReward;
			}
			if (val.Count > 0)
			{
				playerBatchUpdate.CurrencyChanges = val;
			}
			if (def.EnergyReward > 0)
			{
				playerBatchUpdate.NewEP = p.EP;
			}
			return playerBatchUpdate;
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<BattleTaskReward>> _003C_003Et__builder;

		public ClaimBattleTaskRewardRequest request;

		public ClaimBattleTaskRewardUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass4_0 _003C_003E8__1;

		private Player _003Cplayer_003E5__2;

		private string _003CdateKey_003E5__3;

		private PlayerDailyBattleTasks _003CtodayTasks_003E5__4;

		private PlayerBattleTaskProgress _003Cprogress_003E5__5;

		private Result<BattleTaskReward> _003CupdateResult_003E5__6;

		private PlayerDailyBattleTasks _003C_003Es__7;

		private TaskAwaiter<PlayerDailyBattleTasks?> _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0324: Unknown result type (might be due to invalid IL or missing references)
			//IL_0329: Unknown result type (might be due to invalid IL or missing references)
			//IL_0331: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_0304: Unknown result type (might be due to invalid IL or missing references)
			//IL_0306: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<BattleTaskReward> result;
			try
			{
				TaskAwaiter<PlayerDailyBattleTasks> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<PlayerDailyBattleTasks>);
					num = (_003C_003E1__state = -1);
					goto IL_012e;
				}
				TaskAwaiter<bool> awaiter2;
				if (num == 1)
				{
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_0340;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass4_0();
				_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
				_003Cplayer_003E5__2 = _003C_003E4__this._playerState.GetCurrentPlayer();
				if (_003Cplayer_003E5__2 == null)
				{
					result = Result<BattleTaskReward>.FailureResult("Player not found");
				}
				else
				{
					_003C_003E8__1.def = BattleTaskDefinitions.GetById(request.TaskId);
					if (!(_003C_003E8__1.def == null))
					{
						_003CdateKey_003E5__3 = PlayerDailyBattleTasks.TodayKey;
						awaiter = _003C_003E4__this._playerRepository.GetDailyBattleTasksAsync(_003Cplayer_003E5__2.PlayerID, _003CdateKey_003E5__3).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<PlayerDailyBattleTasks>, _003CExecuteAsync_003Ed__4>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_012e;
					}
					result = Result<BattleTaskReward>.FailureResult("Unknown task");
				}
				goto end_IL_0007;
				IL_0340:
				awaiter2.GetResult();
				result = Result<BattleTaskReward>.SuccessResult(_003C_003E8__1.reward);
				goto end_IL_0007;
				IL_012e:
				_003C_003Es__7 = awaiter.GetResult();
				_003CtodayTasks_003E5__4 = _003C_003Es__7;
				_003C_003Es__7 = null;
				if (_003CtodayTasks_003E5__4 == null || !_003CtodayTasks_003E5__4.Tasks.TryGetValue(request.TaskId, ref _003Cprogress_003E5__5))
				{
					result = Result<BattleTaskReward>.FailureResult("Task not started");
				}
				else if (!_003Cprogress_003E5__5.IsCompleted(_003C_003E8__1.def.Target))
				{
					result = Result<BattleTaskReward>.FailureResult("Task not completed yet");
				}
				else if (_003Cprogress_003E5__5.IsRewardClaimed)
				{
					result = Result<BattleTaskReward>.FailureResult("Reward already claimed");
				}
				else
				{
					_003C_003E8__1.reward = new BattleTaskReward(_003C_003E8__1.def.CrystalReward, _003C_003E8__1.def.EnergyReward, _003C_003E8__1.def.GuildCoinsReward);
					_003CupdateResult_003E5__6 = _003C_003E4__this._playerState.ExecuteUpdate<BattleTaskReward>((Player _) => ValidationResult.Success(), delegate(Player p)
					{
						if (_003C_003E8__1.def.CrystalReward > 0)
						{
							_003C_003E8__1._003C_003E4__this._currencyService.ModifyCurrency(p, "gems", _003C_003E8__1.def.CrystalReward);
						}
						if (_003C_003E8__1.def.EnergyReward > 0)
						{
							p.SetEP(Math.Min(p.EP + _003C_003E8__1.def.EnergyReward, p.MaxEP));
						}
						if (_003C_003E8__1.def.GuildCoinsReward > 0)
						{
							_003C_003E8__1._003C_003E4__this._currencyService.ModifyCurrency(p, "guildCoins", _003C_003E8__1.def.GuildCoinsReward);
						}
						return _003C_003E8__1.reward;
					}, delegate(Player p, BattleTaskReward _)
					{
						PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
						{
							PlayerId = (p.PlayerID ?? string.Empty)
						};
						Dictionary<string, long> val = new Dictionary<string, long>();
						if (_003C_003E8__1.def.CrystalReward > 0)
						{
							val["gems"] = _003C_003E8__1.def.CrystalReward;
						}
						if (_003C_003E8__1.def.GuildCoinsReward > 0)
						{
							val["guildCoins"] = _003C_003E8__1.def.GuildCoinsReward;
						}
						if (val.Count > 0)
						{
							playerBatchUpdate.CurrencyChanges = val;
						}
						if (_003C_003E8__1.def.EnergyReward > 0)
						{
							playerBatchUpdate.NewEP = p.EP;
						}
						return playerBatchUpdate;
					});
					if (_003CupdateResult_003E5__6.Success)
					{
						_003CtodayTasks_003E5__4.ClaimTask(request.TaskId);
						awaiter2 = _003C_003E4__this._playerRepository.SaveDailyBattleTasksAsync(_003Cplayer_003E5__2.PlayerID, _003CtodayTasks_003E5__4).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter2;
							_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__4>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_0340;
					}
					result = Result<BattleTaskReward>.FailureResult(_003CupdateResult_003E5__6.ErrorMessage ?? "Failed to apply reward");
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Cplayer_003E5__2 = null;
				_003CdateKey_003E5__3 = null;
				_003CtodayTasks_003E5__4 = null;
				_003Cprogress_003E5__5 = null;
				_003CupdateResult_003E5__6 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Cplayer_003E5__2 = null;
			_003CdateKey_003E5__3 = null;
			_003CtodayTasks_003E5__4 = null;
			_003Cprogress_003E5__5 = null;
			_003CupdateResult_003E5__6 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IPlayerStateService _playerState;

	private readonly IPlayerCurrencyService _currencyService;

	private readonly IPlayerRepository _playerRepository;

	public ClaimBattleTaskRewardUseCase(IPlayerStateService playerState, IPlayerCurrencyService currencyService, IPlayerRepository playerRepository)
	{
		_playerState = playerState;
		_currencyService = currencyService;
		_playerRepository = playerRepository;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__4))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<BattleTaskReward>> ExecuteAsync(ClaimBattleTaskRewardRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Player player = _playerState.GetCurrentPlayer();
		if (player == null)
		{
			return Result<BattleTaskReward>.FailureResult("Player not found");
		}
		BattleTaskDefinition def = BattleTaskDefinitions.GetById(request.TaskId);
		if (def == null)
		{
			return Result<BattleTaskReward>.FailureResult("Unknown task");
		}
		string dateKey = PlayerDailyBattleTasks.TodayKey;
		PlayerDailyBattleTasks todayTasks = await _playerRepository.GetDailyBattleTasksAsync(player.PlayerID, dateKey);
		PlayerBattleTaskProgress progress = default(PlayerBattleTaskProgress);
		if (todayTasks == null || !todayTasks.Tasks.TryGetValue(request.TaskId, ref progress))
		{
			return Result<BattleTaskReward>.FailureResult("Task not started");
		}
		if (!progress.IsCompleted(def.Target))
		{
			return Result<BattleTaskReward>.FailureResult("Task not completed yet");
		}
		if (progress.IsRewardClaimed)
		{
			return Result<BattleTaskReward>.FailureResult("Reward already claimed");
		}
		BattleTaskReward reward = new BattleTaskReward(def.CrystalReward, def.EnergyReward, def.GuildCoinsReward);
		Result<BattleTaskReward> updateResult = _playerState.ExecuteUpdate<BattleTaskReward>((Player _) => ValidationResult.Success(), delegate(Player p)
		{
			if (def.CrystalReward > 0)
			{
				_currencyService.ModifyCurrency(p, "gems", def.CrystalReward);
			}
			if (def.EnergyReward > 0)
			{
				p.SetEP(Math.Min(p.EP + def.EnergyReward, p.MaxEP));
			}
			if (def.GuildCoinsReward > 0)
			{
				_currencyService.ModifyCurrency(p, "guildCoins", def.GuildCoinsReward);
			}
			return reward;
		}, delegate(Player p, BattleTaskReward _)
		{
			PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
			{
				PlayerId = (p.PlayerID ?? string.Empty)
			};
			Dictionary<string, long> val = new Dictionary<string, long>();
			if (def.CrystalReward > 0)
			{
				val["gems"] = def.CrystalReward;
			}
			if (def.GuildCoinsReward > 0)
			{
				val["guildCoins"] = def.GuildCoinsReward;
			}
			if (val.Count > 0)
			{
				playerBatchUpdate.CurrencyChanges = val;
			}
			if (def.EnergyReward > 0)
			{
				playerBatchUpdate.NewEP = p.EP;
			}
			return playerBatchUpdate;
		});
		if (!updateResult.Success)
		{
			return Result<BattleTaskReward>.FailureResult(updateResult.ErrorMessage ?? "Failed to apply reward");
		}
		todayTasks.ClaimTask(request.TaskId);
		await _playerRepository.SaveDailyBattleTasksAsync(player.PlayerID, todayTasks);
		return Result<BattleTaskReward>.SuccessResult(reward);
	}
}
