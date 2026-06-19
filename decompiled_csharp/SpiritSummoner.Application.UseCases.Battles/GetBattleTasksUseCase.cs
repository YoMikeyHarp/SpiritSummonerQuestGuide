using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Configuration.Battles;
using SpiritSummoner.Domain.Entities.Battles;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Battles;

public class GetBattleTasksUseCase : IUseCase<GetBattleTasksRequest, GetBattleTasksResponse>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public bool hasMatchedOpponent;

		public PlayerDailyBattleTasks todayTasks;

		internal bool _003CExecuteAsync_003Eb__0(BattleTaskDefinition def)
		{
			return !def.IsWarTask | hasMatchedOpponent;
		}

		internal BattleTaskView _003CExecuteAsync_003Eb__1(BattleTaskDefinition def)
		{
			PlayerBattleTaskProgress playerBattleTaskProgress = default(PlayerBattleTaskProgress);
			todayTasks.Tasks.TryGetValue(def.TaskId, ref playerBattleTaskProgress);
			int currentCount = playerBattleTaskProgress?.CurrentCount ?? 0;
			bool isCompleted = playerBattleTaskProgress?.IsCompleted(def.Target) ?? false;
			bool isRewardClaimed = playerBattleTaskProgress?.IsRewardClaimed ?? false;
			return new BattleTaskView(def.TaskId, def.Title, def.Description, currentCount, def.Target, isCompleted, isRewardClaimed, def.CrystalReward, def.EnergyReward, def.GuildCoinsReward, def.IsWarTask);
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<GetBattleTasksResponse>> _003C_003Et__builder;

		public GetBattleTasksRequest request;

		public GetBattleTasksUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass4_0 _003C_003E8__1;

		private Player _003Cplayer_003E5__2;

		private string _003CdateKey_003E5__3;

		private List<BattleTaskView> _003CtaskViews_003E5__4;

		private PlayerDailyBattleTasks _003C_003Es__5;

		private TaskAwaiter<PlayerDailyBattleTasks?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<GetBattleTasksResponse> result;
			try
			{
				TaskAwaiter<PlayerDailyBattleTasks> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<PlayerDailyBattleTasks>);
					num = (_003C_003E1__state = -1);
					goto IL_00f6;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass4_0();
				_003Cplayer_003E5__2 = _003C_003E4__this._playerState.GetCurrentPlayer();
				if (_003Cplayer_003E5__2 != null)
				{
					_003C_003E8__1.hasMatchedOpponent = _003C_003E4__this._guildState.GetCurrentGuild()?.IsInWarSeason ?? false;
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
					goto IL_00f6;
				}
				result = Result<GetBattleTasksResponse>.FailureResult("Player not found");
				goto end_IL_0007;
				IL_00f6:
				_003C_003Es__5 = awaiter.GetResult();
				_003C_003E8__1.todayTasks = _003C_003Es__5 ?? PlayerDailyBattleTasks.CreateNew();
				_003C_003Es__5 = null;
				_003CtaskViews_003E5__4 = Enumerable.ToList<BattleTaskView>(Enumerable.Select<BattleTaskDefinition, BattleTaskView>(Enumerable.Where<BattleTaskDefinition>((global::System.Collections.Generic.IEnumerable<BattleTaskDefinition>)BattleTaskDefinitions.All, (Func<BattleTaskDefinition, bool>)((BattleTaskDefinition def) => !def.IsWarTask | _003C_003E8__1.hasMatchedOpponent)), (Func<BattleTaskDefinition, BattleTaskView>)delegate(BattleTaskDefinition def)
				{
					PlayerBattleTaskProgress playerBattleTaskProgress = default(PlayerBattleTaskProgress);
					_003C_003E8__1.todayTasks.Tasks.TryGetValue(def.TaskId, ref playerBattleTaskProgress);
					int currentCount = playerBattleTaskProgress?.CurrentCount ?? 0;
					bool isCompleted = playerBattleTaskProgress?.IsCompleted(def.Target) ?? false;
					bool isRewardClaimed = playerBattleTaskProgress?.IsRewardClaimed ?? false;
					return new BattleTaskView(def.TaskId, def.Title, def.Description, currentCount, def.Target, isCompleted, isRewardClaimed, def.CrystalReward, def.EnergyReward, def.GuildCoinsReward, def.IsWarTask);
				}));
				result = Result<GetBattleTasksResponse>.SuccessResult(new GetBattleTasksResponse((global::System.Collections.Generic.IReadOnlyList<BattleTaskView>)_003CtaskViews_003E5__4));
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Cplayer_003E5__2 = null;
				_003CdateKey_003E5__3 = null;
				_003CtaskViews_003E5__4 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Cplayer_003E5__2 = null;
			_003CdateKey_003E5__3 = null;
			_003CtaskViews_003E5__4 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IPlayerStateService _playerState;

	private readonly IGuildStateService _guildState;

	private readonly IPlayerRepository _playerRepository;

	public GetBattleTasksUseCase(IPlayerStateService playerState, IGuildStateService guildState, IPlayerRepository playerRepository)
	{
		_playerState = playerState;
		_guildState = guildState;
		_playerRepository = playerRepository;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__4))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<GetBattleTasksResponse>> ExecuteAsync(GetBattleTasksRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Player player = _playerState.GetCurrentPlayer();
		if (player == null)
		{
			return Result<GetBattleTasksResponse>.FailureResult("Player not found");
		}
		bool hasMatchedOpponent = _guildState.GetCurrentGuild()?.IsInWarSeason ?? false;
		string dateKey = PlayerDailyBattleTasks.TodayKey;
		PlayerDailyBattleTasks todayTasks = (await _playerRepository.GetDailyBattleTasksAsync(player.PlayerID, dateKey)) ?? PlayerDailyBattleTasks.CreateNew();
		List<BattleTaskView> taskViews = Enumerable.ToList<BattleTaskView>(Enumerable.Select<BattleTaskDefinition, BattleTaskView>(Enumerable.Where<BattleTaskDefinition>((global::System.Collections.Generic.IEnumerable<BattleTaskDefinition>)BattleTaskDefinitions.All, (Func<BattleTaskDefinition, bool>)((BattleTaskDefinition def) => !def.IsWarTask || hasMatchedOpponent)), (Func<BattleTaskDefinition, BattleTaskView>)delegate(BattleTaskDefinition def)
		{
			PlayerBattleTaskProgress playerBattleTaskProgress = default(PlayerBattleTaskProgress);
			todayTasks.Tasks.TryGetValue(def.TaskId, ref playerBattleTaskProgress);
			int currentCount = playerBattleTaskProgress?.CurrentCount ?? 0;
			bool isCompleted = playerBattleTaskProgress?.IsCompleted(def.Target) ?? false;
			bool isRewardClaimed = playerBattleTaskProgress?.IsRewardClaimed ?? false;
			return new BattleTaskView(def.TaskId, def.Title, def.Description, currentCount, def.Target, isCompleted, isRewardClaimed, def.CrystalReward, def.EnergyReward, def.GuildCoinsReward, def.IsWarTask);
		}));
		return Result<GetBattleTasksResponse>.SuccessResult(new GetBattleTasksResponse((global::System.Collections.Generic.IReadOnlyList<BattleTaskView>)taskViews));
	}
}
