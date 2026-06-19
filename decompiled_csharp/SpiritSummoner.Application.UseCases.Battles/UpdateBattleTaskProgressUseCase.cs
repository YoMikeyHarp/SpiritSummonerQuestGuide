using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Configuration.Battles;
using SpiritSummoner.Domain.Entities.Battles;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Enums.Battles;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Battles;

public class UpdateBattleTaskProgressUseCase : IUseCase<UpdateBattleTaskProgressRequest, UpdateBattleTaskProgressResponse>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<UpdateBattleTaskProgressResponse>> _003C_003Et__builder;

		public UpdateBattleTaskProgressRequest request;

		public UpdateBattleTaskProgressUseCase _003C_003E4__this;

		private Player _003Cplayer_003E5__1;

		private bool _003ChasMatchedOpponent_003E5__2;

		private string _003CdateKey_003E5__3;

		private PlayerDailyBattleTasks _003CtodayTasks_003E5__4;

		private List<string> _003CnewlyCompleted_003E5__5;

		private PlayerDailyBattleTasks _003C_003Es__6;

		private BattleTaskType[] _003C_003Es__7;

		private int _003C_003Es__8;

		private BattleTaskType _003CtaskType_003E5__9;

		private global::System.Collections.Generic.IEnumerator<BattleTaskDefinition> _003C_003Es__10;

		private BattleTaskDefinition _003Cdef_003E5__11;

		private bool _003CwasCompleted_003E5__12;

		private PlayerBattleTaskProgress _003Cbefore_003E5__13;

		private bool _003CisNowCompleted_003E5__14;

		private PlayerBattleTaskProgress _003Cafter_003E5__15;

		private global::System.Exception _003Cex_003E5__16;

		private TaskAwaiter<PlayerDailyBattleTasks?> _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_0352: Unknown result type (might be due to invalid IL or missing references)
			//IL_0357: Unknown result type (might be due to invalid IL or missing references)
			//IL_035f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0318: Unknown result type (might be due to invalid IL or missing references)
			//IL_031d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0332: Unknown result type (might be due to invalid IL or missing references)
			//IL_0334: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<UpdateBattleTaskProgressResponse> result;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter<PlayerDailyBattleTasks> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<PlayerDailyBattleTasks>);
						num = (_003C_003E1__state = -1);
						goto IL_00fb;
					}
					TaskAwaiter<bool> awaiter2;
					if (num == 1)
					{
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_036e;
					}
					_003Cplayer_003E5__1 = _003C_003E4__this._playerState.GetCurrentPlayer();
					if (_003Cplayer_003E5__1 != null)
					{
						_003ChasMatchedOpponent_003E5__2 = _003C_003E4__this._guildState.GetCurrentGuild()?.IsInWarSeason ?? false;
						_003CdateKey_003E5__3 = PlayerDailyBattleTasks.TodayKey;
						awaiter = _003C_003E4__this._playerRepository.GetDailyBattleTasksAsync(_003Cplayer_003E5__1.PlayerID, _003CdateKey_003E5__3).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<PlayerDailyBattleTasks>, _003CExecuteAsync_003Ed__4>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_00fb;
					}
					result = Result<UpdateBattleTaskProgressResponse>.FailureResult("Player not found");
					goto end_IL_0011;
					IL_00fb:
					_003C_003Es__6 = awaiter.GetResult();
					_003CtodayTasks_003E5__4 = _003C_003Es__6 ?? PlayerDailyBattleTasks.CreateNew();
					_003C_003Es__6 = null;
					_003CnewlyCompleted_003E5__5 = new List<string>();
					_003C_003Es__7 = request.TaskTypesToIncrement;
					for (_003C_003Es__8 = 0; _003C_003Es__8 < _003C_003Es__7.Length; _003C_003Es__8++)
					{
						_003CtaskType_003E5__9 = _003C_003Es__7[_003C_003Es__8];
						_003C_003Es__10 = BattleTaskDefinitions.GetByType(_003CtaskType_003E5__9).GetEnumerator();
						try
						{
							while (((global::System.Collections.IEnumerator)_003C_003Es__10).MoveNext())
							{
								_003Cdef_003E5__11 = _003C_003Es__10.Current;
								if (!_003Cdef_003E5__11.IsWarTask || _003ChasMatchedOpponent_003E5__2)
								{
									_003CwasCompleted_003E5__12 = _003CtodayTasks_003E5__4.Tasks.TryGetValue(_003Cdef_003E5__11.TaskId, ref _003Cbefore_003E5__13) && _003Cbefore_003E5__13.IsCompleted(_003Cdef_003E5__11.Target);
									_003CtodayTasks_003E5__4.IncrementTask(_003Cdef_003E5__11.TaskId, _003Cdef_003E5__11.Target);
									_003CisNowCompleted_003E5__14 = _003CtodayTasks_003E5__4.Tasks.TryGetValue(_003Cdef_003E5__11.TaskId, ref _003Cafter_003E5__15) && _003Cafter_003E5__15.IsCompleted(_003Cdef_003E5__11.Target);
									if (!_003CwasCompleted_003E5__12 & _003CisNowCompleted_003E5__14)
									{
										_003CnewlyCompleted_003E5__5.Add(_003Cdef_003E5__11.TaskId);
									}
									_003Cbefore_003E5__13 = null;
									_003Cafter_003E5__15 = null;
									_003Cdef_003E5__11 = null;
								}
							}
						}
						finally
						{
							if (num < 0 && _003C_003Es__10 != null)
							{
								((global::System.IDisposable)_003C_003Es__10).Dispose();
							}
						}
						_003C_003Es__10 = null;
					}
					_003C_003Es__7 = null;
					awaiter2 = _003C_003E4__this._playerRepository.SaveDailyBattleTasksAsync(_003Cplayer_003E5__1.PlayerID, _003CtodayTasks_003E5__4).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter2;
						_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__4>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_036e;
					IL_036e:
					awaiter2.GetResult();
					result = Result<UpdateBattleTaskProgressResponse>.SuccessResult(new UpdateBattleTaskProgressResponse((global::System.Collections.Generic.IReadOnlyList<string>)_003CnewlyCompleted_003E5__5));
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__16 = ex;
					Console.WriteLine($"UpdateBattleTaskProgressUseCase error: {_003Cex_003E5__16}");
					result = Result<UpdateBattleTaskProgressResponse>.FailureResult("Failed to update task progress");
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
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

	public UpdateBattleTaskProgressUseCase(IPlayerStateService playerState, IGuildStateService guildState, IPlayerRepository playerRepository)
	{
		_playerState = playerState;
		_guildState = guildState;
		_playerRepository = playerRepository;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__4))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<UpdateBattleTaskProgressResponse>> ExecuteAsync(UpdateBattleTaskProgressRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Player player = _playerState.GetCurrentPlayer();
			if (player == null)
			{
				return Result<UpdateBattleTaskProgressResponse>.FailureResult("Player not found");
			}
			bool hasMatchedOpponent = _guildState.GetCurrentGuild()?.IsInWarSeason ?? false;
			string dateKey = PlayerDailyBattleTasks.TodayKey;
			PlayerDailyBattleTasks todayTasks = (await _playerRepository.GetDailyBattleTasksAsync(player.PlayerID, dateKey)) ?? PlayerDailyBattleTasks.CreateNew();
			List<string> newlyCompleted = new List<string>();
			BattleTaskType[] taskTypesToIncrement = request.TaskTypesToIncrement;
			PlayerBattleTaskProgress before = default(PlayerBattleTaskProgress);
			PlayerBattleTaskProgress after = default(PlayerBattleTaskProgress);
			foreach (BattleTaskType taskType in taskTypesToIncrement)
			{
				global::System.Collections.Generic.IEnumerator<BattleTaskDefinition> enumerator = BattleTaskDefinitions.GetByType(taskType).GetEnumerator();
				try
				{
					while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
					{
						BattleTaskDefinition def = enumerator.Current;
						if (!def.IsWarTask || hasMatchedOpponent)
						{
							bool wasCompleted = todayTasks.Tasks.TryGetValue(def.TaskId, ref before) && before.IsCompleted(def.Target);
							todayTasks.IncrementTask(def.TaskId, def.Target);
							bool isNowCompleted = todayTasks.Tasks.TryGetValue(def.TaskId, ref after) && after.IsCompleted(def.Target);
							if (!wasCompleted && isNowCompleted)
							{
								newlyCompleted.Add(def.TaskId);
							}
							before = null;
							after = null;
						}
					}
				}
				finally
				{
					((global::System.IDisposable)enumerator)?.Dispose();
				}
			}
			await _playerRepository.SaveDailyBattleTasksAsync(player.PlayerID, todayTasks);
			return Result<UpdateBattleTaskProgressResponse>.SuccessResult(new UpdateBattleTaskProgressResponse((global::System.Collections.Generic.IReadOnlyList<string>)newlyCompleted));
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine($"UpdateBattleTaskProgressUseCase error: {ex}");
			return Result<UpdateBattleTaskProgressResponse>.FailureResult("Failed to update task progress");
		}
	}
}
