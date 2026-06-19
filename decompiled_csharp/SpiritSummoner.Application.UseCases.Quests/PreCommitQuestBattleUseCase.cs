using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Quests;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Contracts;

namespace SpiritSummoner.Application.UseCases.Quests;

public class PreCommitQuestBattleUseCase : IUseCase<PreCommitQuestBattleRequest, PreCommitQuestBattleResult>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public PreCommitQuestBattleRequest request;

		public int energyCost;

		public DateTimeOffset now;

		internal bool _003CExecuteAsync_003Eb__0(QuestTask t)
		{
			return t.Id == request.TaskId;
		}

		internal ValidationResult _003CExecuteAsync_003Eb__1(Player player)
		{
			if (player.EP < energyCost)
			{
				return ValidationResult.Failure("Insufficient energy");
			}
			return ValidationResult.Success();
		}

		internal _003C_003Ef__AnonymousType6<string> _003CExecuteAsync_003Eb__2(Player player)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			player.SetEP(player.EP - energyCost);
			player.SetLastEpRegenTime(now);
			Guid val = Guid.NewGuid();
			return new
			{
				BattleId = ((object)(Guid)(ref val)).ToString()
			};
		}

		internal PlayerBatchUpdate _003CExecuteAsync_003Eb__3(Player player, _003C_003Ef__AnonymousType6<string> r)
		{
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			return new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty),
				NewEP = player.EP,
				LastEpRegenTime = now
			};
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<PreCommitQuestBattleResult>> _003C_003Et__builder;

		public PreCommitQuestBattleRequest request;

		public PreCommitQuestBattleUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass4_0 _003C_003E8__1;

		private global::System.Collections.Generic.IReadOnlyList<QuestTask> _003Ctasks_003E5__2;

		private QuestTask _003Ctask_003E5__3;

		private Result<_003C_003Ef__AnonymousType6<string>> _003Cresult_003E5__4;

		private global::System.Collections.Generic.IReadOnlyList<QuestTask> _003C_003Es__5;

		private TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<QuestTask>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<PreCommitQuestBattleResult> result;
			try
			{
				TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<QuestTask>> awaiter;
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass4_0();
					_003C_003E8__1.request = request;
					awaiter = _003C_003E4__this._questRepository.GetTasksForAreaAsync(_003C_003E8__1.request.QuestId, _003C_003E8__1.request.AreaId).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<QuestTask>>, _003CExecuteAsync_003Ed__4>(ref awaiter, ref _003CExecuteAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<QuestTask>>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__5 = awaiter.GetResult();
				_003Ctasks_003E5__2 = _003C_003Es__5;
				_003C_003Es__5 = null;
				_003Ctask_003E5__3 = Enumerable.FirstOrDefault<QuestTask>((global::System.Collections.Generic.IEnumerable<QuestTask>)_003Ctasks_003E5__2, (Func<QuestTask, bool>)((QuestTask t) => t.Id == _003C_003E8__1.request.TaskId));
				if (_003Ctask_003E5__3 == null)
				{
					result = Result<PreCommitQuestBattleResult>.FailureResult("Quest task not found");
				}
				else
				{
					_003C_003E8__1.energyCost = _003Ctask_003E5__3.Energy;
					_003C_003E8__1.now = _003C_003E4__this._serverTime.GetCurrentServerTime();
					_003Cresult_003E5__4 = _003C_003E4__this._stateService.ExecuteUpdate((Player player) => (player.EP < _003C_003E8__1.energyCost) ? ValidationResult.Failure("Insufficient energy") : ValidationResult.Success(), delegate(Player player)
					{
						//IL_0017: Unknown result type (might be due to invalid IL or missing references)
						//IL_0027: Unknown result type (might be due to invalid IL or missing references)
						//IL_002c: Unknown result type (might be due to invalid IL or missing references)
						player.SetEP(player.EP - _003C_003E8__1.energyCost);
						player.SetLastEpRegenTime(_003C_003E8__1.now);
						Guid val = Guid.NewGuid();
						return new
						{
							BattleId = ((object)(Guid)(ref val)).ToString()
						};
					}, (Player player, r) => new PlayerBatchUpdate
					{
						PlayerId = (player.PlayerID ?? string.Empty),
						NewEP = player.EP,
						LastEpRegenTime = _003C_003E8__1.now
					});
					result = ((_003Cresult_003E5__4.Success && _003Cresult_003E5__4.Data != null) ? Result<PreCommitQuestBattleResult>.SuccessResult(new PreCommitQuestBattleResult(_003Cresult_003E5__4.Data.BattleId)) : Result<PreCommitQuestBattleResult>.FailureResult(_003Cresult_003E5__4.ErrorMessage ?? "Failed to start quest battle"));
				}
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Ctasks_003E5__2 = null;
				_003Ctask_003E5__3 = null;
				_003Cresult_003E5__4 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Ctasks_003E5__2 = null;
			_003Ctask_003E5__3 = null;
			_003Cresult_003E5__4 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IPlayerStateService _stateService;

	private readonly IQuestRepository _questRepository;

	private readonly IServerTimeProvider _serverTime;

	public PreCommitQuestBattleUseCase(IPlayerStateService stateService, IQuestRepository questRepository, IServerTimeProvider serverTime)
	{
		_stateService = stateService;
		_questRepository = questRepository;
		_serverTime = serverTime;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__4))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<PreCommitQuestBattleResult>> ExecuteAsync(PreCommitQuestBattleRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		PreCommitQuestBattleRequest request2 = request;
		QuestTask task = Enumerable.FirstOrDefault<QuestTask>((global::System.Collections.Generic.IEnumerable<QuestTask>)(await _questRepository.GetTasksForAreaAsync(request2.QuestId, request2.AreaId)), (Func<QuestTask, bool>)((QuestTask t) => t.Id == request2.TaskId));
		if (task == null)
		{
			return Result<PreCommitQuestBattleResult>.FailureResult("Quest task not found");
		}
		int energyCost = task.Energy;
		DateTimeOffset now = _serverTime.GetCurrentServerTime();
		var result = _stateService.ExecuteUpdate((Player player) => (player.EP < energyCost) ? ValidationResult.Failure("Insufficient energy") : ValidationResult.Success(), delegate(Player player)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			player.SetEP(player.EP - energyCost);
			player.SetLastEpRegenTime(now);
			Guid val = Guid.NewGuid();
			return new
			{
				BattleId = ((object)(Guid)(ref val)).ToString()
			};
		}, (Player player, r) => new PlayerBatchUpdate
		{
			PlayerId = (player.PlayerID ?? string.Empty),
			NewEP = player.EP,
			LastEpRegenTime = now
		});
		if (!result.Success || result.Data == null)
		{
			return Result<PreCommitQuestBattleResult>.FailureResult(result.ErrorMessage ?? "Failed to start quest battle");
		}
		return Result<PreCommitQuestBattleResult>.SuccessResult(new PreCommitQuestBattleResult(result.Data.BattleId));
	}
}
