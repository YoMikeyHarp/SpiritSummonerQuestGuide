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

namespace SpiritSummoner.Application.UseCases.Quests;

public class ResetRepeatableTaskUseCase : IUseCase<ResetRepeatableTaskRequest, ResetRepeatableTaskResult>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public ResetRepeatableTaskRequest request;

		public QuestTask task;

		internal bool _003CExecuteAsync_003Eb__0(QuestTask t)
		{
			return t.Id == request.TaskId;
		}

		internal ValidationResult _003CExecuteAsync_003Eb__1(Player player)
		{
			int num = 0;
			bool flag = false;
			PlayerQuest playerQuest = default(PlayerQuest);
			TaskProgress taskProgress = default(TaskProgress);
			if (player.PlayerQuests.TryGetValue(request.QuestId, ref playerQuest) && playerQuest.Tasks.TryGetValue(request.TaskId, ref taskProgress))
			{
				num = taskProgress.Step;
				flag = taskProgress.IsCompleted;
			}
			if (!flag || num < task.TotalSteps)
			{
				return ValidationResult.Failure("Task is not completed yet");
			}
			return ValidationResult.Success();
		}

		internal ResetRepeatableTaskResult _003CExecuteAsync_003Eb__2(Player player)
		{
			player.UpdateQuestTaskProgress(request.QuestId, request.TaskId, 0, isCompleted: false);
			return new ResetRepeatableTaskResult
			{
				Success = true,
				ErrorMessage = null
			};
		}

		internal PlayerBatchUpdate _003CExecuteAsync_003Eb__3(Player player, ResetRepeatableTaskResult response)
		{
			return new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty),
				QuestId = request.QuestId,
				TaskUpdates = new Dictionary<string, TaskProgress> { [request.TaskId] = new TaskProgress
				{
					Step = 0,
					IsCompleted = false
				} }
			};
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<ResetRepeatableTaskResult>> _003C_003Et__builder;

		public ResetRepeatableTaskRequest request;

		public ResetRepeatableTaskUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass3_0 _003C_003E8__1;

		private global::System.Collections.Generic.IReadOnlyList<QuestTask> _003Ctasks_003E5__2;

		private Result<ResetRepeatableTaskResult> _003Cresult_003E5__3;

		private global::System.Collections.Generic.IReadOnlyList<QuestTask> _003C_003Es__4;

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
			int num = _003C_003E1__state;
			Result<ResetRepeatableTaskResult> result;
			try
			{
				TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<QuestTask>> awaiter;
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass3_0();
					_003C_003E8__1.request = request;
					awaiter = _003C_003E4__this._questRepository.GetTasksForAreaAsync(_003C_003E8__1.request.QuestId, _003C_003E8__1.request.AreaId).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<QuestTask>>, _003CExecuteAsync_003Ed__3>(ref awaiter, ref _003CExecuteAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<QuestTask>>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__4 = awaiter.GetResult();
				_003Ctasks_003E5__2 = _003C_003Es__4;
				_003C_003Es__4 = null;
				_003C_003E8__1.task = Enumerable.FirstOrDefault<QuestTask>((global::System.Collections.Generic.IEnumerable<QuestTask>)_003Ctasks_003E5__2, (Func<QuestTask, bool>)((QuestTask t) => t.Id == _003C_003E8__1.request.TaskId));
				if (_003C_003E8__1.task == null)
				{
					result = Result<ResetRepeatableTaskResult>.FailureResult("Quest task not found");
				}
				else if (!_003C_003E8__1.task.IsRepeatable)
				{
					result = Result<ResetRepeatableTaskResult>.FailureResult("Task is not repeatable");
				}
				else
				{
					_003Cresult_003E5__3 = _003C_003E4__this._stateService.ExecuteUpdate<ResetRepeatableTaskResult>(delegate(Player player)
					{
						int num2 = 0;
						bool flag = false;
						PlayerQuest playerQuest = default(PlayerQuest);
						TaskProgress taskProgress = default(TaskProgress);
						if (player.PlayerQuests.TryGetValue(_003C_003E8__1.request.QuestId, ref playerQuest) && playerQuest.Tasks.TryGetValue(_003C_003E8__1.request.TaskId, ref taskProgress))
						{
							num2 = taskProgress.Step;
							flag = taskProgress.IsCompleted;
						}
						return (!flag || num2 < _003C_003E8__1.task.TotalSteps) ? ValidationResult.Failure("Task is not completed yet") : ValidationResult.Success();
					}, delegate(Player player)
					{
						player.UpdateQuestTaskProgress(_003C_003E8__1.request.QuestId, _003C_003E8__1.request.TaskId, 0, isCompleted: false);
						return new ResetRepeatableTaskResult
						{
							Success = true,
							ErrorMessage = null
						};
					}, (Player player, ResetRepeatableTaskResult response) => new PlayerBatchUpdate
					{
						PlayerId = (player.PlayerID ?? string.Empty),
						QuestId = _003C_003E8__1.request.QuestId,
						TaskUpdates = new Dictionary<string, TaskProgress> { [_003C_003E8__1.request.TaskId] = new TaskProgress
						{
							Step = 0,
							IsCompleted = false
						} }
					});
					result = (_003Cresult_003E5__3.Success ? Result<ResetRepeatableTaskResult>.SuccessResult(_003Cresult_003E5__3.Data) : Result<ResetRepeatableTaskResult>.FailureResult(_003Cresult_003E5__3.ErrorMessage ?? "Failed to reset task"));
				}
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Ctasks_003E5__2 = null;
				_003Cresult_003E5__3 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Ctasks_003E5__2 = null;
			_003Cresult_003E5__3 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IPlayerStateService _stateService;

	private readonly IQuestRepository _questRepository;

	public ResetRepeatableTaskUseCase(IPlayerStateService stateService, IQuestRepository questRepository)
	{
		_stateService = stateService;
		_questRepository = questRepository;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__3))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<ResetRepeatableTaskResult>> ExecuteAsync(ResetRepeatableTaskRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		ResetRepeatableTaskRequest request2 = request;
		QuestTask task = Enumerable.FirstOrDefault<QuestTask>((global::System.Collections.Generic.IEnumerable<QuestTask>)(await _questRepository.GetTasksForAreaAsync(request2.QuestId, request2.AreaId)), (Func<QuestTask, bool>)((QuestTask t) => t.Id == request2.TaskId));
		if (task == null)
		{
			return Result<ResetRepeatableTaskResult>.FailureResult("Quest task not found");
		}
		if (!task.IsRepeatable)
		{
			return Result<ResetRepeatableTaskResult>.FailureResult("Task is not repeatable");
		}
		Result<ResetRepeatableTaskResult> result = _stateService.ExecuteUpdate<ResetRepeatableTaskResult>(delegate(Player player)
		{
			int num = 0;
			bool flag = false;
			PlayerQuest playerQuest = default(PlayerQuest);
			TaskProgress taskProgress = default(TaskProgress);
			if (player.PlayerQuests.TryGetValue(request2.QuestId, ref playerQuest) && playerQuest.Tasks.TryGetValue(request2.TaskId, ref taskProgress))
			{
				num = taskProgress.Step;
				flag = taskProgress.IsCompleted;
			}
			return (!flag || num < task.TotalSteps) ? ValidationResult.Failure("Task is not completed yet") : ValidationResult.Success();
		}, delegate(Player player)
		{
			player.UpdateQuestTaskProgress(request2.QuestId, request2.TaskId, 0, isCompleted: false);
			return new ResetRepeatableTaskResult
			{
				Success = true,
				ErrorMessage = null
			};
		}, (Player player, ResetRepeatableTaskResult response) => new PlayerBatchUpdate
		{
			PlayerId = (player.PlayerID ?? string.Empty),
			QuestId = request2.QuestId,
			TaskUpdates = new Dictionary<string, TaskProgress> { [request2.TaskId] = new TaskProgress
			{
				Step = 0,
				IsCompleted = false
			} }
		});
		if (!result.Success)
		{
			return Result<ResetRepeatableTaskResult>.FailureResult(result.ErrorMessage ?? "Failed to reset task");
		}
		return Result<ResetRepeatableTaskResult>.SuccessResult(result.Data);
	}
}
