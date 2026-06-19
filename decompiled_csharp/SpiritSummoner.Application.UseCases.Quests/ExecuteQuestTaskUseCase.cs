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
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Quests;
using SpiritSummoner.Domain.Interfaces.Services;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Domain.ValueObjects.Quests;
using SpiritSummoner.Infrastructure.Contracts;

namespace SpiritSummoner.Application.UseCases.Quests;

public class ExecuteQuestTaskUseCase : IUseCase<ExecuteQuestTaskRequest, ExecuteQuestTaskResult>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public ExecuteQuestTaskRequest request;

		public QuestTask task;

		public ExecuteQuestTaskUseCase _003C_003E4__this;

		public DateTimeOffset now;

		public global::System.Collections.Generic.IReadOnlyList<QuestTask> tasks;

		internal bool _003CExecuteAsync_003Eb__0(QuestTask t)
		{
			return t.Id == request.TaskId;
		}

		internal ValidationResult _003CExecuteAsync_003Eb__1(Player player)
		{
			if (player.EP < task.Energy)
			{
				return ValidationResult.Failure("Insufficient energy");
			}
			int currentTaskStep = _003C_003E4__this.GetCurrentTaskStep(player, request.QuestId, request.TaskId);
			if (currentTaskStep >= task.TotalSteps)
			{
				return ValidationResult.Failure("Task already completed");
			}
			return ValidationResult.Success();
		}

		internal _003C_003Ef__AnonymousType5<bool, int, int, int, Rewards, long, double, List<string>> _003CExecuteAsync_003Eb__2(Player player)
		{
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			int currentTaskStep = _003C_003E4__this.GetCurrentTaskStep(player, request.QuestId, request.TaskId);
			int num = currentTaskStep + 1;
			bool flag = num >= task.TotalSteps;
			player.SetEP(player.EP - task.Energy);
			player.SetLastEpRegenTime(now);
			long num2 = task.Rewards?.Gold ?? 0;
			double num3 = task.Rewards?.Experience ?? 0;
			int levelsGained = 0;
			if (num3 > 0.0)
			{
				levelsGained = _003C_003E4__this._playerProgressionService.GainExperience(player, num3);
			}
			if (num2 != 0)
			{
				_003C_003E4__this._playerCurrencyService.ModifyCurrency(player, "gold", num2);
			}
			if (flag && task.Rewards != null)
			{
				_003C_003E4__this._playerCurrencyService.ModifyCurrency(player, "reputation", task.Rewards.Reputation);
			}
			_003C_003E4__this.UpdateQuestProgress(player, request.QuestId, request.TaskId, num, flag);
			List<string> resetChildIds = new List<string>();
			if (flag && task.IsRepeatable)
			{
				_003C_003E4__this.CascadeResetDescendants(player, request.QuestId, task.Id, (global::System.Collections.Generic.IEnumerable<QuestTask>)tasks, resetChildIds);
			}
			return new
			{
				IsTaskComplete = flag,
				NewStep = num,
				TotalSteps = task.TotalSteps,
				LevelsGained = levelsGained,
				TaskRewards = (flag ? task.Rewards : null),
				TapGold = num2,
				TapExp = num3,
				ResetChildIds = resetChildIds
			};
		}

		internal PlayerBatchUpdate _003CExecuteAsync_003Eb__3(Player player, _003C_003Ef__AnonymousType5<bool, int, int, int, Rewards, long, double, List<string>> updateResult)
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty),
				QuestId = request.QuestId,
				NewEP = player.EP,
				LastEpRegenTime = now,
				ExperienceGain = (int)Math.Round(updateResult.TapExp),
				TaskUpdates = new Dictionary<string, TaskProgress> { [request.TaskId] = new TaskProgress
				{
					Step = ((!updateResult.IsTaskComplete) ? updateResult.NewStep : 0),
					IsCompleted = updateResult.IsTaskComplete
				} }
			};
			if (updateResult.TapGold != 0)
			{
				playerBatchUpdate.AddCurrencyChange("gold", updateResult.TapGold);
			}
			if (updateResult.IsTaskComplete && task.Rewards != null)
			{
				playerBatchUpdate.UpdateReputation = true;
				playerBatchUpdate.AddCurrencyChange("reputation", task.Rewards.Reputation);
			}
			if (updateResult.LevelsGained > 0)
			{
				playerBatchUpdate.SetLevelUp(player);
			}
			Enumerator<string> enumerator = updateResult.ResetChildIds.GetEnumerator();
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
	private sealed class _003CExecuteAsync_003Ed__6 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<ExecuteQuestTaskResult>> _003C_003Et__builder;

		public ExecuteQuestTaskRequest request;

		public ExecuteQuestTaskUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass6_0 _003C_003E8__1;

		private Result<_003C_003Ef__AnonymousType5<bool, int, int, int, Rewards, long, double, List<string>>> _003Cresult_003E5__2;

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
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<ExecuteQuestTaskResult> result;
			try
			{
				TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<QuestTask>> awaiter;
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass6_0();
					_003C_003E8__1.request = request;
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					awaiter = _003C_003E4__this._questRepository.GetTasksForAreaAsync(_003C_003E8__1.request.QuestId, _003C_003E8__1.request.AreaId).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CExecuteAsync_003Ed__6 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<QuestTask>>, _003CExecuteAsync_003Ed__6>(ref awaiter, ref _003CExecuteAsync_003Ed__);
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
					result = Result<ExecuteQuestTaskResult>.FailureResult("Quest task not found");
				}
				else if (_003C_003E8__1.task.Battle)
				{
					result = Result<ExecuteQuestTaskResult>.FailureResult("Use ExecuteQuestBattleUseCase");
				}
				else
				{
					_003C_003E8__1.now = _003C_003E4__this._serverTime.GetCurrentServerTime();
					_003Cresult_003E5__2 = _003C_003E4__this._stateService.ExecuteUpdate(delegate(Player player)
					{
						if (player.EP < _003C_003E8__1.task.Energy)
						{
							return ValidationResult.Failure("Insufficient energy");
						}
						int currentTaskStep2 = _003C_003E8__1._003C_003E4__this.GetCurrentTaskStep(player, _003C_003E8__1.request.QuestId, _003C_003E8__1.request.TaskId);
						return (currentTaskStep2 >= _003C_003E8__1.task.TotalSteps) ? ValidationResult.Failure("Task already completed") : ValidationResult.Success();
					}, delegate(Player player)
					{
						//IL_0055: Unknown result type (might be due to invalid IL or missing references)
						int currentTaskStep = _003C_003E8__1._003C_003E4__this.GetCurrentTaskStep(player, _003C_003E8__1.request.QuestId, _003C_003E8__1.request.TaskId);
						int num2 = currentTaskStep + 1;
						bool flag = num2 >= _003C_003E8__1.task.TotalSteps;
						player.SetEP(player.EP - _003C_003E8__1.task.Energy);
						player.SetLastEpRegenTime(_003C_003E8__1.now);
						long num3 = _003C_003E8__1.task.Rewards?.Gold ?? 0;
						double num4 = _003C_003E8__1.task.Rewards?.Experience ?? 0;
						int levelsGained = 0;
						if (num4 > 0.0)
						{
							levelsGained = _003C_003E8__1._003C_003E4__this._playerProgressionService.GainExperience(player, num4);
						}
						if (num3 != 0)
						{
							_003C_003E8__1._003C_003E4__this._playerCurrencyService.ModifyCurrency(player, "gold", num3);
						}
						if (flag && _003C_003E8__1.task.Rewards != null)
						{
							_003C_003E8__1._003C_003E4__this._playerCurrencyService.ModifyCurrency(player, "reputation", _003C_003E8__1.task.Rewards.Reputation);
						}
						_003C_003E8__1._003C_003E4__this.UpdateQuestProgress(player, _003C_003E8__1.request.QuestId, _003C_003E8__1.request.TaskId, num2, flag);
						List<string> resetChildIds = new List<string>();
						if (flag && _003C_003E8__1.task.IsRepeatable)
						{
							_003C_003E8__1._003C_003E4__this.CascadeResetDescendants(player, _003C_003E8__1.request.QuestId, _003C_003E8__1.task.Id, (global::System.Collections.Generic.IEnumerable<QuestTask>)_003C_003E8__1.tasks, resetChildIds);
						}
						return new
						{
							IsTaskComplete = flag,
							NewStep = num2,
							TotalSteps = _003C_003E8__1.task.TotalSteps,
							LevelsGained = levelsGained,
							TaskRewards = (flag ? _003C_003E8__1.task.Rewards : null),
							TapGold = num3,
							TapExp = num4,
							ResetChildIds = resetChildIds
						};
					}, (Player player, updateResult) =>
					{
						//IL_0042: Unknown result type (might be due to invalid IL or missing references)
						//IL_0134: Unknown result type (might be due to invalid IL or missing references)
						//IL_0139: Unknown result type (might be due to invalid IL or missing references)
						PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
						{
							PlayerId = (player.PlayerID ?? string.Empty),
							QuestId = _003C_003E8__1.request.QuestId,
							NewEP = player.EP,
							LastEpRegenTime = _003C_003E8__1.now,
							ExperienceGain = (int)Math.Round(updateResult.TapExp),
							TaskUpdates = new Dictionary<string, TaskProgress> { [_003C_003E8__1.request.TaskId] = new TaskProgress
							{
								Step = ((!updateResult.IsTaskComplete) ? updateResult.NewStep : 0),
								IsCompleted = updateResult.IsTaskComplete
							} }
						};
						if (updateResult.TapGold != 0)
						{
							playerBatchUpdate.AddCurrencyChange("gold", updateResult.TapGold);
						}
						if (updateResult.IsTaskComplete && _003C_003E8__1.task.Rewards != null)
						{
							playerBatchUpdate.UpdateReputation = true;
							playerBatchUpdate.AddCurrencyChange("reputation", _003C_003E8__1.task.Rewards.Reputation);
						}
						if (updateResult.LevelsGained > 0)
						{
							playerBatchUpdate.SetLevelUp(player);
						}
						Enumerator<string> enumerator = updateResult.ResetChildIds.GetEnumerator();
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
					result = (_003Cresult_003E5__2.Success ? Result<ExecuteQuestTaskResult>.SuccessResult(new ExecuteQuestTaskResult
					{
						IsTaskComplete = _003Cresult_003E5__2.Data.IsTaskComplete,
						NewStep = _003Cresult_003E5__2.Data.NewStep,
						TotalSteps = _003Cresult_003E5__2.Data.TotalSteps,
						LevelsGained = _003Cresult_003E5__2.Data.LevelsGained,
						TaskRewards = ((_003Cresult_003E5__2.Data.TaskRewards != null) ? new QuestTaskRewards
						{
							Gold = _003Cresult_003E5__2.Data.TaskRewards.Gold,
							Experience = _003Cresult_003E5__2.Data.TaskRewards.Experience,
							Items = Enumerable.ToList<string>(Enumerable.Select<Item, string>((global::System.Collections.Generic.IEnumerable<Item>)_003Cresult_003E5__2.Data.TaskRewards.Items, (Func<Item, string>)((Item x) => x.Name)))
						} : null)
					}) : Result<ExecuteQuestTaskResult>.FailureResult(_003Cresult_003E5__2.ErrorMessage ?? "Failed"));
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

	private readonly IPlayerCurrencyService _playerCurrencyService;

	private readonly IServerTimeProvider _serverTime;

	public ExecuteQuestTaskUseCase(IPlayerStateService stateService, IQuestRepository questRepository, IPlayerProgressionService playerProgressionService, IPlayerCurrencyService playerCurrencyService, IServerTimeProvider serverTime)
	{
		_stateService = stateService;
		_questRepository = questRepository;
		_playerProgressionService = playerProgressionService;
		_playerCurrencyService = playerCurrencyService;
		_serverTime = serverTime;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__6))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<ExecuteQuestTaskResult>> ExecuteAsync(ExecuteQuestTaskRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		ExecuteQuestTaskRequest request2 = request;
		global::System.Collections.Generic.IReadOnlyList<QuestTask> tasks = await _questRepository.GetTasksForAreaAsync(request2.QuestId, request2.AreaId);
		QuestTask task = Enumerable.FirstOrDefault<QuestTask>((global::System.Collections.Generic.IEnumerable<QuestTask>)tasks, (Func<QuestTask, bool>)((QuestTask t) => t.Id == request2.TaskId));
		if (task == null)
		{
			return Result<ExecuteQuestTaskResult>.FailureResult("Quest task not found");
		}
		if (task.Battle)
		{
			return Result<ExecuteQuestTaskResult>.FailureResult("Use ExecuteQuestBattleUseCase");
		}
		DateTimeOffset now = _serverTime.GetCurrentServerTime();
		var result = _stateService.ExecuteUpdate(delegate(Player player)
		{
			if (player.EP < task.Energy)
			{
				return ValidationResult.Failure("Insufficient energy");
			}
			int currentTaskStep2 = GetCurrentTaskStep(player, request2.QuestId, request2.TaskId);
			return (currentTaskStep2 >= task.TotalSteps) ? ValidationResult.Failure("Task already completed") : ValidationResult.Success();
		}, delegate(Player player)
		{
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			int currentTaskStep = GetCurrentTaskStep(player, request2.QuestId, request2.TaskId);
			int num = currentTaskStep + 1;
			bool flag = num >= task.TotalSteps;
			player.SetEP(player.EP - task.Energy);
			player.SetLastEpRegenTime(now);
			long num2 = task.Rewards?.Gold ?? 0;
			double num3 = task.Rewards?.Experience ?? 0;
			int levelsGained = 0;
			if (num3 > 0.0)
			{
				levelsGained = _playerProgressionService.GainExperience(player, num3);
			}
			if (num2 != 0)
			{
				_playerCurrencyService.ModifyCurrency(player, "gold", num2);
			}
			if (flag && task.Rewards != null)
			{
				_playerCurrencyService.ModifyCurrency(player, "reputation", task.Rewards.Reputation);
			}
			UpdateQuestProgress(player, request2.QuestId, request2.TaskId, num, flag);
			List<string> resetChildIds = new List<string>();
			if (flag && task.IsRepeatable)
			{
				CascadeResetDescendants(player, request2.QuestId, task.Id, (global::System.Collections.Generic.IEnumerable<QuestTask>)tasks, resetChildIds);
			}
			return new
			{
				IsTaskComplete = flag,
				NewStep = num,
				TotalSteps = task.TotalSteps,
				LevelsGained = levelsGained,
				TaskRewards = (flag ? task.Rewards : null),
				TapGold = num2,
				TapExp = num3,
				ResetChildIds = resetChildIds
			};
		}, (Player player, updateResult) =>
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty),
				QuestId = request2.QuestId,
				NewEP = player.EP,
				LastEpRegenTime = now,
				ExperienceGain = (int)Math.Round(updateResult.TapExp),
				TaskUpdates = new Dictionary<string, TaskProgress> { [request2.TaskId] = new TaskProgress
				{
					Step = ((!updateResult.IsTaskComplete) ? updateResult.NewStep : 0),
					IsCompleted = updateResult.IsTaskComplete
				} }
			};
			if (updateResult.TapGold != 0)
			{
				playerBatchUpdate.AddCurrencyChange("gold", updateResult.TapGold);
			}
			if (updateResult.IsTaskComplete && task.Rewards != null)
			{
				playerBatchUpdate.UpdateReputation = true;
				playerBatchUpdate.AddCurrencyChange("reputation", task.Rewards.Reputation);
			}
			if (updateResult.LevelsGained > 0)
			{
				playerBatchUpdate.SetLevelUp(player);
			}
			Enumerator<string> enumerator = updateResult.ResetChildIds.GetEnumerator();
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
			return Result<ExecuteQuestTaskResult>.FailureResult(result.ErrorMessage ?? "Failed");
		}
		return Result<ExecuteQuestTaskResult>.SuccessResult(new ExecuteQuestTaskResult
		{
			IsTaskComplete = result.Data.IsTaskComplete,
			NewStep = result.Data.NewStep,
			TotalSteps = result.Data.TotalSteps,
			LevelsGained = result.Data.LevelsGained,
			TaskRewards = ((result.Data.TaskRewards != null) ? new QuestTaskRewards
			{
				Gold = result.Data.TaskRewards.Gold,
				Experience = result.Data.TaskRewards.Experience,
				Items = Enumerable.ToList<string>(Enumerable.Select<Item, string>((global::System.Collections.Generic.IEnumerable<Item>)result.Data.TaskRewards.Items, (Func<Item, string>)((Item x) => x.Name)))
			} : null)
		});
	}

	private int GetCurrentTaskStep(Player player, string questId, string taskId)
	{
		PlayerQuest playerQuest = default(PlayerQuest);
		TaskProgress taskProgress = default(TaskProgress);
		if (player.PlayerQuests.TryGetValue(questId, ref playerQuest) && playerQuest.Tasks.TryGetValue(taskId, ref taskProgress))
		{
			return taskProgress.Step;
		}
		return 0;
	}

	private void CascadeResetDescendants(Player player, string questId, string parentId, global::System.Collections.Generic.IEnumerable<QuestTask> allTasks, List<string> resetChildIds)
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
					UpdateQuestProgress(player, questId, current.Id, 0, isComplete: false);
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

	private void UpdateQuestProgress(Player player, string questId, string taskId, int newStep, bool isComplete)
	{
		Dictionary<string, PlayerQuest> val = new Dictionary<string, PlayerQuest>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, PlayerQuest>>)player.PlayerQuests);
		PlayerQuest playerQuest = default(PlayerQuest);
		if (!val.TryGetValue(questId, ref playerQuest))
		{
			playerQuest = (val[questId] = new PlayerQuest
			{
				QuestId = questId,
				Tasks = new Dictionary<string, TaskProgress>()
			});
		}
		Dictionary<string, TaskProgress> val2 = new Dictionary<string, TaskProgress>((IDictionary<string, TaskProgress>)(object)playerQuest.Tasks);
		val2[taskId] = new TaskProgress
		{
			Step = ((!isComplete) ? newStep : 0),
			IsCompleted = isComplete
		};
		val[questId] = new PlayerQuest
		{
			QuestId = questId,
			Tasks = val2
		};
		player.SetPlayerQuests(val);
	}
}
