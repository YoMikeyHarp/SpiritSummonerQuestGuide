using System;
using System.Collections;
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
using SpiritSummoner.Domain.Interfaces.Services;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Contracts;

namespace SpiritSummoner.Application.UseCases.Quests;

public class ExecuteQuestTaskHoldUseCase : IUseCase<ExecuteQuestTaskHoldRequest, ExecuteQuestTaskHoldResult>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public ExecuteQuestTaskHoldRequest request;

		public QuestTask task;

		public int stepsToComplete;

		public int energyToSpend;

		public int newStep;

		public bool isTaskComplete;

		public long totalGold;

		public double totalExp;

		public DateTimeOffset now;

		public int levelsGained;

		public ExecuteQuestTaskHoldUseCase _003C_003E4__this;

		public global::System.Collections.Generic.IReadOnlyList<QuestTask> tasks;

		public List<string> resetChildIds;

		internal bool _003CExecuteAsync_003Eb__0(QuestTask t)
		{
			return t.Id == request.TaskId;
		}

		internal ValidationResult _003CExecuteAsync_003Eb__1(Player player)
		{
			int num = 0;
			PlayerQuest playerQuest = default(PlayerQuest);
			TaskProgress taskProgress = default(TaskProgress);
			if (player.PlayerQuests.TryGetValue(request.QuestId, ref playerQuest) && playerQuest.Tasks.TryGetValue(request.TaskId, ref taskProgress))
			{
				num = taskProgress.Step;
			}
			if (num >= task.TotalSteps)
			{
				return ValidationResult.Failure("Task already completed");
			}
			int num2 = task.TotalSteps - num;
			int eP = player.EP;
			stepsToComplete = Math.Min(num2, eP / task.Energy);
			if (stepsToComplete == 0)
			{
				return ValidationResult.Failure("Insufficient energy to complete any steps");
			}
			energyToSpend = stepsToComplete * task.Energy;
			newStep = num + stepsToComplete;
			isTaskComplete = newStep >= task.TotalSteps;
			if (task.Rewards != null)
			{
				totalGold = task.Rewards.Gold * stepsToComplete;
				totalExp = task.Rewards.Experience * stepsToComplete;
			}
			return ValidationResult.Success();
		}

		internal ExecuteQuestTaskHoldResult _003CExecuteAsync_003Eb__2(Player player)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			player.SetEP(player.EP - energyToSpend);
			player.SetLastEpRegenTime(now);
			player.UpdateQuestTaskProgress(request.QuestId, request.TaskId, (!isTaskComplete) ? newStep : 0, isTaskComplete);
			if (totalExp > 0.0)
			{
				levelsGained = _003C_003E4__this._playerProgressionService.GainExperience(player, totalExp);
			}
			if (totalGold != 0)
			{
				player.AddCurrency("gold", totalGold);
			}
			if (isTaskComplete && task.IsRepeatable)
			{
				CascadeResetDescendants(player, request.QuestId, task.Id, (global::System.Collections.Generic.IEnumerable<QuestTask>)tasks, resetChildIds);
			}
			return new ExecuteQuestTaskHoldResult
			{
				StepsCompleted = stepsToComplete,
				EnergySpent = energyToSpend,
				IsTaskComplete = isTaskComplete,
				NewStep = newStep,
				TotalSteps = task.TotalSteps,
				LevelsGained = levelsGained,
				TaskRewards = ((isTaskComplete && task.Rewards != null) ? new QuestTaskRewards
				{
					Gold = totalGold,
					Experience = totalExp
				} : null)
			};
		}

		internal PlayerBatchUpdate _003CExecuteAsync_003Eb__3(Player player, ExecuteQuestTaskHoldResult response)
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty),
				QuestId = request.QuestId,
				NewEP = player.EP,
				LastEpRegenTime = now,
				ExperienceGain = (int)Math.Round(totalExp),
				TaskUpdates = new Dictionary<string, TaskProgress> { [request.TaskId] = new TaskProgress
				{
					Step = ((!isTaskComplete) ? newStep : 0),
					IsCompleted = isTaskComplete
				} }
			};
			if (totalGold != 0)
			{
				playerBatchUpdate.CurrencyChanges = new Dictionary<string, long> { ["gold"] = totalGold };
			}
			if (levelsGained > 0)
			{
				playerBatchUpdate.SetLevelUp(player);
			}
			Enumerator<string> enumerator = resetChildIds.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					playerBatchUpdate.TaskUpdates[current] = new TaskProgress
					{
						Step = 0,
						IsCompleted = false
					};
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator).Dispose();
			}
			return playerBatchUpdate;
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<ExecuteQuestTaskHoldResult>> _003C_003Et__builder;

		public ExecuteQuestTaskHoldRequest request;

		public ExecuteQuestTaskHoldUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass5_0 _003C_003E8__1;

		private Result<ExecuteQuestTaskHoldResult> _003Cresult_003E5__2;

		private global::System.Collections.Generic.IReadOnlyList<QuestTask> _003C_003Es__3;

		private TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<QuestTask>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_0199: Unknown result type (might be due to invalid IL or missing references)
			//IL_019e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<ExecuteQuestTaskHoldResult> result;
			try
			{
				TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<QuestTask>> awaiter;
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass5_0();
					_003C_003E8__1.request = request;
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					awaiter = _003C_003E4__this._questRepository.GetTasksForAreaAsync(_003C_003E8__1.request.QuestId, _003C_003E8__1.request.AreaId).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CExecuteAsync_003Ed__5 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<QuestTask>>, _003CExecuteAsync_003Ed__5>(ref awaiter, ref _003CExecuteAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<QuestTask>>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__3 = awaiter.GetResult();
				_003C_003E8__1.tasks = _003C_003Es__3;
				_003C_003Es__3 = null;
				_003C_003E8__1.task = Enumerable.FirstOrDefault<QuestTask>((global::System.Collections.Generic.IEnumerable<QuestTask>)_003C_003E8__1.tasks, (Func<QuestTask, bool>)((QuestTask t) => t.Id == _003C_003E8__1.request.TaskId));
				if (_003C_003E8__1.task == null)
				{
					result = Result<ExecuteQuestTaskHoldResult>.FailureResult("Quest task not found");
				}
				else if (_003C_003E8__1.task.Battle)
				{
					result = Result<ExecuteQuestTaskHoldResult>.FailureResult("Cannot hold battle tasks");
				}
				else if (_003C_003E8__1.task.TotalSteps <= 1)
				{
					result = Result<ExecuteQuestTaskHoldResult>.FailureResult("Task only has 1 step - use regular execution");
				}
				else
				{
					_003C_003E8__1.now = _003C_003E4__this._serverTime.GetCurrentServerTime();
					_003C_003E8__1.stepsToComplete = 0;
					_003C_003E8__1.energyToSpend = 0;
					_003C_003E8__1.newStep = 0;
					_003C_003E8__1.isTaskComplete = false;
					_003C_003E8__1.totalGold = 0L;
					_003C_003E8__1.totalExp = 0.0;
					_003C_003E8__1.levelsGained = 0;
					_003C_003E8__1.resetChildIds = new List<string>();
					_003Cresult_003E5__2 = _003C_003E4__this._stateService.ExecuteUpdate<ExecuteQuestTaskHoldResult>(delegate(Player player)
					{
						int num2 = 0;
						PlayerQuest playerQuest = default(PlayerQuest);
						TaskProgress taskProgress = default(TaskProgress);
						if (player.PlayerQuests.TryGetValue(_003C_003E8__1.request.QuestId, ref playerQuest) && playerQuest.Tasks.TryGetValue(_003C_003E8__1.request.TaskId, ref taskProgress))
						{
							num2 = taskProgress.Step;
						}
						if (num2 >= _003C_003E8__1.task.TotalSteps)
						{
							return ValidationResult.Failure("Task already completed");
						}
						int num3 = _003C_003E8__1.task.TotalSteps - num2;
						int eP = player.EP;
						_003C_003E8__1.stepsToComplete = Math.Min(num3, eP / _003C_003E8__1.task.Energy);
						if (_003C_003E8__1.stepsToComplete == 0)
						{
							return ValidationResult.Failure("Insufficient energy to complete any steps");
						}
						_003C_003E8__1.energyToSpend = _003C_003E8__1.stepsToComplete * _003C_003E8__1.task.Energy;
						_003C_003E8__1.newStep = num2 + _003C_003E8__1.stepsToComplete;
						_003C_003E8__1.isTaskComplete = _003C_003E8__1.newStep >= _003C_003E8__1.task.TotalSteps;
						if (_003C_003E8__1.task.Rewards != null)
						{
							_003C_003E8__1.totalGold = _003C_003E8__1.task.Rewards.Gold * _003C_003E8__1.stepsToComplete;
							_003C_003E8__1.totalExp = _003C_003E8__1.task.Rewards.Experience * _003C_003E8__1.stepsToComplete;
						}
						return ValidationResult.Success();
					}, delegate(Player player)
					{
						//IL_0017: Unknown result type (might be due to invalid IL or missing references)
						player.SetEP(player.EP - _003C_003E8__1.energyToSpend);
						player.SetLastEpRegenTime(_003C_003E8__1.now);
						player.UpdateQuestTaskProgress(_003C_003E8__1.request.QuestId, _003C_003E8__1.request.TaskId, (!_003C_003E8__1.isTaskComplete) ? _003C_003E8__1.newStep : 0, _003C_003E8__1.isTaskComplete);
						if (_003C_003E8__1.totalExp > 0.0)
						{
							_003C_003E8__1.levelsGained = _003C_003E8__1._003C_003E4__this._playerProgressionService.GainExperience(player, _003C_003E8__1.totalExp);
						}
						if (_003C_003E8__1.totalGold != 0)
						{
							player.AddCurrency("gold", _003C_003E8__1.totalGold);
						}
						if (_003C_003E8__1.isTaskComplete && _003C_003E8__1.task.IsRepeatable)
						{
							CascadeResetDescendants(player, _003C_003E8__1.request.QuestId, _003C_003E8__1.task.Id, (global::System.Collections.Generic.IEnumerable<QuestTask>)_003C_003E8__1.tasks, _003C_003E8__1.resetChildIds);
						}
						return new ExecuteQuestTaskHoldResult
						{
							StepsCompleted = _003C_003E8__1.stepsToComplete,
							EnergySpent = _003C_003E8__1.energyToSpend,
							IsTaskComplete = _003C_003E8__1.isTaskComplete,
							NewStep = _003C_003E8__1.newStep,
							TotalSteps = _003C_003E8__1.task.TotalSteps,
							LevelsGained = _003C_003E8__1.levelsGained,
							TaskRewards = ((_003C_003E8__1.isTaskComplete && _003C_003E8__1.task.Rewards != null) ? new QuestTaskRewards
							{
								Gold = _003C_003E8__1.totalGold,
								Experience = _003C_003E8__1.totalExp
							} : null)
						};
					}, delegate(Player player, ExecuteQuestTaskHoldResult response)
					{
						//IL_0042: Unknown result type (might be due to invalid IL or missing references)
						//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
						//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
						PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
						{
							PlayerId = (player.PlayerID ?? string.Empty),
							QuestId = _003C_003E8__1.request.QuestId,
							NewEP = player.EP,
							LastEpRegenTime = _003C_003E8__1.now,
							ExperienceGain = (int)Math.Round(_003C_003E8__1.totalExp),
							TaskUpdates = new Dictionary<string, TaskProgress> { [_003C_003E8__1.request.TaskId] = new TaskProgress
							{
								Step = ((!_003C_003E8__1.isTaskComplete) ? _003C_003E8__1.newStep : 0),
								IsCompleted = _003C_003E8__1.isTaskComplete
							} }
						};
						if (_003C_003E8__1.totalGold != 0)
						{
							playerBatchUpdate.CurrencyChanges = new Dictionary<string, long> { ["gold"] = _003C_003E8__1.totalGold };
						}
						if (_003C_003E8__1.levelsGained > 0)
						{
							playerBatchUpdate.SetLevelUp(player);
						}
						Enumerator<string> enumerator = _003C_003E8__1.resetChildIds.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								string current = enumerator.Current;
								playerBatchUpdate.TaskUpdates[current] = new TaskProgress
								{
									Step = 0,
									IsCompleted = false
								};
							}
						}
						finally
						{
							((global::System.IDisposable)enumerator).Dispose();
						}
						return playerBatchUpdate;
					});
					result = (_003Cresult_003E5__2.Success ? Result<ExecuteQuestTaskHoldResult>.SuccessResult(_003Cresult_003E5__2.Data) : Result<ExecuteQuestTaskHoldResult>.FailureResult(_003Cresult_003E5__2.ErrorMessage ?? "Failed to execute hold-to-complete"));
				}
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

	private readonly IPlayerStateService _stateService;

	private readonly IQuestRepository _questRepository;

	private readonly IPlayerProgressionService _playerProgressionService;

	private readonly IServerTimeProvider _serverTime;

	public ExecuteQuestTaskHoldUseCase(IPlayerStateService stateService, IQuestRepository questRepository, IPlayerProgressionService playerProgressionService, IServerTimeProvider serverTime)
	{
		_stateService = stateService;
		_questRepository = questRepository;
		_playerProgressionService = playerProgressionService;
		_serverTime = serverTime;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__5))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<ExecuteQuestTaskHoldResult>> ExecuteAsync(ExecuteQuestTaskHoldRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		ExecuteQuestTaskHoldRequest request2 = request;
		global::System.Collections.Generic.IReadOnlyList<QuestTask> tasks = await _questRepository.GetTasksForAreaAsync(request2.QuestId, request2.AreaId);
		QuestTask task = Enumerable.FirstOrDefault<QuestTask>((global::System.Collections.Generic.IEnumerable<QuestTask>)tasks, (Func<QuestTask, bool>)((QuestTask t) => t.Id == request2.TaskId));
		if (task == null)
		{
			return Result<ExecuteQuestTaskHoldResult>.FailureResult("Quest task not found");
		}
		if (task.Battle)
		{
			return Result<ExecuteQuestTaskHoldResult>.FailureResult("Cannot hold battle tasks");
		}
		if (task.TotalSteps <= 1)
		{
			return Result<ExecuteQuestTaskHoldResult>.FailureResult("Task only has 1 step - use regular execution");
		}
		DateTimeOffset now = _serverTime.GetCurrentServerTime();
		int stepsToComplete = 0;
		int energyToSpend = 0;
		int newStep = 0;
		bool isTaskComplete = false;
		long totalGold = 0L;
		double totalExp = 0.0;
		int levelsGained = 0;
		List<string> resetChildIds = new List<string>();
		Result<ExecuteQuestTaskHoldResult> result = _stateService.ExecuteUpdate<ExecuteQuestTaskHoldResult>(delegate(Player player)
		{
			int num = 0;
			PlayerQuest playerQuest = default(PlayerQuest);
			TaskProgress taskProgress = default(TaskProgress);
			if (player.PlayerQuests.TryGetValue(request2.QuestId, ref playerQuest) && playerQuest.Tasks.TryGetValue(request2.TaskId, ref taskProgress))
			{
				num = taskProgress.Step;
			}
			if (num >= task.TotalSteps)
			{
				return ValidationResult.Failure("Task already completed");
			}
			int num2 = task.TotalSteps - num;
			int eP = player.EP;
			stepsToComplete = Math.Min(num2, eP / task.Energy);
			if (stepsToComplete == 0)
			{
				return ValidationResult.Failure("Insufficient energy to complete any steps");
			}
			energyToSpend = stepsToComplete * task.Energy;
			newStep = num + stepsToComplete;
			isTaskComplete = newStep >= task.TotalSteps;
			if (task.Rewards != null)
			{
				totalGold = task.Rewards.Gold * stepsToComplete;
				totalExp = task.Rewards.Experience * stepsToComplete;
			}
			return ValidationResult.Success();
		}, delegate(Player player)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			player.SetEP(player.EP - energyToSpend);
			player.SetLastEpRegenTime(now);
			player.UpdateQuestTaskProgress(request2.QuestId, request2.TaskId, (!isTaskComplete) ? newStep : 0, isTaskComplete);
			if (totalExp > 0.0)
			{
				levelsGained = _playerProgressionService.GainExperience(player, totalExp);
			}
			if (totalGold != 0)
			{
				player.AddCurrency("gold", totalGold);
			}
			if (isTaskComplete && task.IsRepeatable)
			{
				CascadeResetDescendants(player, request2.QuestId, task.Id, (global::System.Collections.Generic.IEnumerable<QuestTask>)tasks, resetChildIds);
			}
			return new ExecuteQuestTaskHoldResult
			{
				StepsCompleted = stepsToComplete,
				EnergySpent = energyToSpend,
				IsTaskComplete = isTaskComplete,
				NewStep = newStep,
				TotalSteps = task.TotalSteps,
				LevelsGained = levelsGained,
				TaskRewards = ((isTaskComplete && task.Rewards != null) ? new QuestTaskRewards
				{
					Gold = totalGold,
					Experience = totalExp
				} : null)
			};
		}, delegate(Player player, ExecuteQuestTaskHoldResult response)
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty),
				QuestId = request2.QuestId,
				NewEP = player.EP,
				LastEpRegenTime = now,
				ExperienceGain = (int)Math.Round(totalExp),
				TaskUpdates = new Dictionary<string, TaskProgress> { [request2.TaskId] = new TaskProgress
				{
					Step = ((!isTaskComplete) ? newStep : 0),
					IsCompleted = isTaskComplete
				} }
			};
			if (totalGold != 0)
			{
				playerBatchUpdate.CurrencyChanges = new Dictionary<string, long> { ["gold"] = totalGold };
			}
			if (levelsGained > 0)
			{
				playerBatchUpdate.SetLevelUp(player);
			}
			Enumerator<string> enumerator = resetChildIds.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					playerBatchUpdate.TaskUpdates[current] = new TaskProgress
					{
						Step = 0,
						IsCompleted = false
					};
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator).Dispose();
			}
			return playerBatchUpdate;
		});
		if (!result.Success)
		{
			return Result<ExecuteQuestTaskHoldResult>.FailureResult(result.ErrorMessage ?? "Failed to execute hold-to-complete");
		}
		return Result<ExecuteQuestTaskHoldResult>.SuccessResult(result.Data);
	}

	private static void CascadeResetDescendants(Player player, string questId, string parentId, global::System.Collections.Generic.IEnumerable<QuestTask> allTasks, List<string> resetChildIds)
	{
		string parentId2 = parentId;
		global::System.Collections.Generic.IEnumerator<QuestTask> enumerator = Enumerable.Where<QuestTask>(allTasks, (Func<QuestTask, bool>)((QuestTask t) => t.OrderRequirement == parentId2 && !t.IsRepeatable && t.Id != null)).GetEnumerator();
		try
		{
			PlayerQuest playerQuest = default(PlayerQuest);
			TaskProgress taskProgress = default(TaskProgress);
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				QuestTask current = enumerator.Current;
				if (player.PlayerQuests.TryGetValue(questId, ref playerQuest) && playerQuest.Tasks.TryGetValue(current.Id, ref taskProgress) && taskProgress.IsCompleted)
				{
					player.UpdateQuestTaskProgress(questId, current.Id, 0, isCompleted: false);
					resetChildIds.Add(current.Id);
				}
				CascadeResetDescendants(player, questId, current.Id, allTasks, resetChildIds);
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
	}
}
