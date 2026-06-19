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
using SpiritSummoner.Application.UseCases.Spirits;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Quests;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Interfaces.Services;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Domain.ValueObjects.Quests;

namespace SpiritSummoner.Application.UseCases.Quests;

public class ExecuteQuestBattleUseCase : IUseCase<ExecuteQuestBattleRequest, ExecuteQuestBattleResult>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public ExecuteQuestBattleRequest request;

		public QuestTask task;

		public ExecuteQuestBattleUseCase _003C_003E4__this;

		public global::System.Collections.Generic.IReadOnlyList<QuestTask> tasks;

		internal bool _003CExecuteAsync_003Eb__0(QuestTask t)
		{
			return t.Id == request.TaskId;
		}

		internal _003C_003Ef__AnonymousType4<bool, int, int, Rewards, QuestBattleRewards, bool, int, string, string, List<string>> _003CExecuteAsync_003Eb__2(Player player)
		{
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			int levelsGained = 0;
			bool flag = false;
			QuestOpponent questOpponent = task.QuestOpponents[0];
			Spirit spirit = null;
			int opponentLevel = Enumerable.FirstOrDefault<QuestOpponent>((global::System.Collections.Generic.IEnumerable<QuestOpponent>)task.QuestOpponents)?.Level ?? 1;
			QuestBattleRewards questBattleRewards = CalculateBattleRewards(request.BattleWon, opponentLevel, task.Rewards);
			if (questBattleRewards != null && task.Rewards != null)
			{
				levelsGained = _003C_003E4__this._playerProgressionService.GainExperience(player, questBattleRewards.Experience);
			}
			if (request.BattleWon)
			{
				_003C_003E4__this.UpdateQuestProgress(player, request.QuestId, request.TaskId, 1, isComplete: true);
				_003C_003E4__this._playerCurrencyService.ModifyCurrency(player, "gold", questBattleRewards?.Gold ?? 0);
				_003C_003E4__this._playerCurrencyService.ModifyCurrency(player, "gems", 5L);
				if (new Random().NextDouble() < questOpponent.DropRate && ((global::System.Collections.Generic.IReadOnlyCollection<QuestOpponent>)task.QuestOpponents).Count == 1)
				{
					flag = true;
					spirit = _003C_003E4__this._spiritRepository.GetById(questOpponent.BaseSpiritId);
					_003C_003E4__this._playerInventoryService.ModifyInventory(player, spirit?.Name + " Orb #" + spirit.ID, 1);
				}
			}
			List<string> resetChildIds = new List<string>();
			if (request.BattleWon && task.IsRepeatable)
			{
				_003C_003E4__this.CascadeResetDescendants(player, request.QuestId, task.Id, (global::System.Collections.Generic.IEnumerable<QuestTask>)tasks, resetChildIds);
			}
			Inventory inventory = default(Inventory);
			return new
			{
				IsTaskComplete = request.BattleWon,
				TotalSteps = task.TotalSteps,
				LevelsGained = levelsGained,
				TaskRewards = task.Rewards,
				BattleRewards = questBattleRewards,
				OrbDropped = flag,
				OrbPlayerCount = (flag ? (player.Inventory.TryGetValue(spirit.Name + " Orb #" + spirit.ID, ref inventory) ? inventory.Amount : 0) : 0),
				SpiritName = questOpponent.BaseSpiritId,
				ItemRewards = (flag ? (spirit?.Name + " Orb #" + (spirit?.ID ?? "0")) : string.Empty),
				ResetChildIds = resetChildIds
			};
		}

		internal PlayerBatchUpdate _003CExecuteAsync_003Eb__3(Player player, _003C_003Ef__AnonymousType4<bool, int, int, Rewards, QuestBattleRewards, bool, int, string, string, List<string>> updateResult)
		{
			//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
			PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty),
				QuestId = request.QuestId,
				TaskUpdates = new Dictionary<string, TaskProgress> { [request.TaskId] = new TaskProgress
				{
					Step = ((!updateResult.IsTaskComplete) ? (request.BattleWon ? 1 : 0) : 0),
					IsCompleted = updateResult.IsTaskComplete
				} },
				ExperienceGain = (int)(updateResult.BattleRewards?.Experience ?? 0.0),
				CurrencyChanges = ((updateResult.BattleRewards != null && updateResult.IsTaskComplete) ? new Dictionary<string, long>
				{
					["gold"] = updateResult.BattleRewards.Gold,
					["gems"] = 5L
				} : new Dictionary<string, long>()),
				InventoryItemChanges = (updateResult.OrbDropped ? new Dictionary<string, int> { [updateResult.ItemRewards] = 1 } : new Dictionary<string, int>()),
				UpdateLevel = (updateResult.LevelsGained > 0),
				UpdateMaxEXP = (updateResult.LevelsGained > 0),
				NewPlayerLevel = ((updateResult.LevelsGained > 0) ? player.PlayerLevel : 0),
				GuildUpdates = ((updateResult.LevelsGained > 0) ? new PlayerGuildUpdate
				{
					GuildId = player.GuildId,
					TargetPlayerId = player.PlayerID
				} : new PlayerGuildUpdate
				{
					TargetPlayerId = string.Empty
				}),
				NewMaxEXP = ((updateResult.LevelsGained > 0) ? player.MaxEXP : 0.0),
				NewMaxEP = ((updateResult.LevelsGained > 0) ? player.MaxEP : 0),
				NewMaxSP = ((updateResult.LevelsGained > 0) ? player.MaxSP : 0),
				UpdateLeaderboard = false
			};
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
	private sealed class _003CExecuteAsync_003Ed__8 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<ExecuteQuestBattleResult>> _003C_003Et__builder;

		public ExecuteQuestBattleRequest request;

		public ExecuteQuestBattleUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass8_0 _003C_003E8__1;

		private Result<_003C_003Ef__AnonymousType4<bool, int, int, Rewards, QuestBattleRewards, bool, int, string, string, List<string>>> _003Cresult_003E5__2;

		private Result<UnequipItemResponse> _003CunEquipResult_003E5__3;

		private global::System.Collections.Generic.IReadOnlyList<QuestTask> _003C_003Es__4;

		private Result<UnequipItemResponse> _003C_003Es__5;

		private TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<QuestTask>> _003C_003Eu__1;

		private TaskAwaiter<Result<UnequipItemResponse>> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_023f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0244: Unknown result type (might be due to invalid IL or missing references)
			//IL_024c: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0206: Unknown result type (might be due to invalid IL or missing references)
			//IL_020b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0220: Unknown result type (might be due to invalid IL or missing references)
			//IL_0222: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<ExecuteQuestBattleResult> result;
			try
			{
				TaskAwaiter<Result<UnequipItemResponse>> awaiter;
				TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<QuestTask>> awaiter2;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<Result<UnequipItemResponse>>);
						num = (_003C_003E1__state = -1);
						goto IL_025b;
					}
					_003C_003E8__1 = new _003C_003Ec__DisplayClass8_0();
					_003C_003E8__1.request = request;
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					awaiter2 = _003C_003E4__this._questRepository.GetTasksForAreaAsync(_003C_003E8__1.request.QuestId, _003C_003E8__1.request.AreaId).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003CExecuteAsync_003Ed__8 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<QuestTask>>, _003CExecuteAsync_003Ed__8>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<QuestTask>>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__4 = awaiter2.GetResult();
				_003C_003E8__1.tasks = _003C_003Es__4;
				_003C_003Es__4 = null;
				_003C_003E8__1.task = Enumerable.FirstOrDefault<QuestTask>((global::System.Collections.Generic.IEnumerable<QuestTask>)_003C_003E8__1.tasks, (Func<QuestTask, bool>)((QuestTask t) => t.Id == _003C_003E8__1.request.TaskId));
				if (_003C_003E8__1.task == null)
				{
					result = Result<ExecuteQuestBattleResult>.FailureResult("Quest task not found");
				}
				else
				{
					_003Cresult_003E5__2 = _003C_003E4__this._stateService.ExecuteUpdate((Player player) => ValidationResult.Success(), delegate(Player player)
					{
						//IL_0105: Unknown result type (might be due to invalid IL or missing references)
						int levelsGained = 0;
						bool flag = false;
						QuestOpponent questOpponent = _003C_003E8__1.task.QuestOpponents[0];
						Spirit spirit = null;
						int opponentLevel = Enumerable.FirstOrDefault<QuestOpponent>((global::System.Collections.Generic.IEnumerable<QuestOpponent>)_003C_003E8__1.task.QuestOpponents)?.Level ?? 1;
						QuestBattleRewards questBattleRewards = CalculateBattleRewards(_003C_003E8__1.request.BattleWon, opponentLevel, _003C_003E8__1.task.Rewards);
						if (questBattleRewards != null && _003C_003E8__1.task.Rewards != null)
						{
							levelsGained = _003C_003E8__1._003C_003E4__this._playerProgressionService.GainExperience(player, questBattleRewards.Experience);
						}
						if (_003C_003E8__1.request.BattleWon)
						{
							_003C_003E8__1._003C_003E4__this.UpdateQuestProgress(player, _003C_003E8__1.request.QuestId, _003C_003E8__1.request.TaskId, 1, isComplete: true);
							_003C_003E8__1._003C_003E4__this._playerCurrencyService.ModifyCurrency(player, "gold", questBattleRewards?.Gold ?? 0);
							_003C_003E8__1._003C_003E4__this._playerCurrencyService.ModifyCurrency(player, "gems", 5L);
							if (new Random().NextDouble() < questOpponent.DropRate && ((global::System.Collections.Generic.IReadOnlyCollection<QuestOpponent>)_003C_003E8__1.task.QuestOpponents).Count == 1)
							{
								flag = true;
								spirit = _003C_003E8__1._003C_003E4__this._spiritRepository.GetById(questOpponent.BaseSpiritId);
								_003C_003E8__1._003C_003E4__this._playerInventoryService.ModifyInventory(player, spirit?.Name + " Orb #" + spirit.ID, 1);
							}
						}
						List<string> resetChildIds = new List<string>();
						if (_003C_003E8__1.request.BattleWon && _003C_003E8__1.task.IsRepeatable)
						{
							_003C_003E8__1._003C_003E4__this.CascadeResetDescendants(player, _003C_003E8__1.request.QuestId, _003C_003E8__1.task.Id, (global::System.Collections.Generic.IEnumerable<QuestTask>)_003C_003E8__1.tasks, resetChildIds);
						}
						Inventory inventory = default(Inventory);
						return new
						{
							IsTaskComplete = _003C_003E8__1.request.BattleWon,
							TotalSteps = _003C_003E8__1.task.TotalSteps,
							LevelsGained = levelsGained,
							TaskRewards = _003C_003E8__1.task.Rewards,
							BattleRewards = questBattleRewards,
							OrbDropped = flag,
							OrbPlayerCount = (flag ? (player.Inventory.TryGetValue(spirit.Name + " Orb #" + spirit.ID, ref inventory) ? inventory.Amount : 0) : 0),
							SpiritName = questOpponent.BaseSpiritId,
							ItemRewards = (flag ? (spirit?.Name + " Orb #" + (spirit?.ID ?? "0")) : string.Empty),
							ResetChildIds = resetChildIds
						};
					}, (Player player, updateResult) =>
					{
						//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
						//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
						PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
						{
							PlayerId = (player.PlayerID ?? string.Empty),
							QuestId = _003C_003E8__1.request.QuestId,
							TaskUpdates = new Dictionary<string, TaskProgress> { [_003C_003E8__1.request.TaskId] = new TaskProgress
							{
								Step = ((!updateResult.IsTaskComplete) ? (_003C_003E8__1.request.BattleWon ? 1 : 0) : 0),
								IsCompleted = updateResult.IsTaskComplete
							} },
							ExperienceGain = (int)(updateResult.BattleRewards?.Experience ?? 0.0),
							CurrencyChanges = ((updateResult.BattleRewards != null && updateResult.IsTaskComplete) ? new Dictionary<string, long>
							{
								["gold"] = updateResult.BattleRewards.Gold,
								["gems"] = 5L
							} : new Dictionary<string, long>()),
							InventoryItemChanges = (updateResult.OrbDropped ? new Dictionary<string, int> { [updateResult.ItemRewards] = 1 } : new Dictionary<string, int>()),
							UpdateLevel = (updateResult.LevelsGained > 0),
							UpdateMaxEXP = (updateResult.LevelsGained > 0),
							NewPlayerLevel = ((updateResult.LevelsGained > 0) ? player.PlayerLevel : 0),
							GuildUpdates = ((updateResult.LevelsGained > 0) ? new PlayerGuildUpdate
							{
								GuildId = player.GuildId,
								TargetPlayerId = player.PlayerID
							} : new PlayerGuildUpdate
							{
								TargetPlayerId = string.Empty
							}),
							NewMaxEXP = ((updateResult.LevelsGained > 0) ? player.MaxEXP : 0.0),
							NewMaxEP = ((updateResult.LevelsGained > 0) ? player.MaxEP : 0),
							NewMaxSP = ((updateResult.LevelsGained > 0) ? player.MaxSP : 0),
							UpdateLeaderboard = false
						};
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
					if (_003Cresult_003E5__2.Success)
					{
						awaiter = _003C_003E4__this._unequipItemUseCase.ExecuteAsync(new UnequipItemRequest(_003C_003E4__this._stateService.GetPartnerSpirit()?.PlayerSpiritID ?? "", EquipmentType.HeldItem)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003CExecuteAsync_003Ed__8 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Result<UnequipItemResponse>>, _003CExecuteAsync_003Ed__8>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_025b;
					}
					result = Result<ExecuteQuestBattleResult>.FailureResult(_003Cresult_003E5__2.ErrorMessage ?? "Failed");
				}
				goto end_IL_0007;
				IL_025b:
				_003C_003Es__5 = awaiter.GetResult();
				_003CunEquipResult_003E5__3 = _003C_003Es__5;
				_003C_003Es__5 = null;
				result = Result<ExecuteQuestBattleResult>.SuccessResult(new ExecuteQuestBattleResult
				{
					BattleWon = _003C_003E8__1.request.BattleWon,
					IsTaskComplete = _003C_003E8__1.request.BattleWon,
					NewStep = (_003C_003E8__1.request.BattleWon ? 1 : 0),
					TotalSteps = _003C_003E8__1.task.TotalSteps,
					BattleRewards = (_003Cresult_003E5__2.Data.BattleRewards ?? new QuestBattleRewards()),
					OrbFragmentDropped = _003Cresult_003E5__2.Data.OrbDropped,
					OrbPlayerCount = _003Cresult_003E5__2.Data.OrbPlayerCount,
					SpiritName = _003Cresult_003E5__2.Data.SpiritName,
					TaskRewards = ((_003Cresult_003E5__2.Data.IsTaskComplete && _003C_003E8__1.task.Rewards != null) ? new QuestTaskRewards
					{
						Gold = _003C_003E8__1.task.Rewards.Gold,
						Experience = _003C_003E8__1.task.Rewards.Experience
					} : null)
				});
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Cresult_003E5__2 = null;
				_003CunEquipResult_003E5__3 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Cresult_003E5__2 = null;
			_003CunEquipResult_003E5__3 = null;
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

	private readonly IPlayerInventoryService _playerInventoryService;

	private readonly UnequipItemUseCase _unequipItemUseCase;

	private readonly ISpiritRepository _spiritRepository;

	public ExecuteQuestBattleUseCase(IPlayerStateService stateService, IQuestRepository questRepository, IPlayerProgressionService playerProgressionService, IPlayerCurrencyService playerCurrencyService, IPlayerInventoryService playerInventoryService, UnequipItemUseCase unequipItemUseCase, ISpiritRepository spiritRepository)
	{
		_stateService = stateService;
		_questRepository = questRepository;
		_playerProgressionService = playerProgressionService;
		_playerCurrencyService = playerCurrencyService;
		_playerInventoryService = playerInventoryService;
		_unequipItemUseCase = unequipItemUseCase;
		_spiritRepository = spiritRepository;
		base._002Ector();
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__8))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<ExecuteQuestBattleResult>> ExecuteAsync(ExecuteQuestBattleRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		ExecuteQuestBattleRequest request2 = request;
		global::System.Collections.Generic.IReadOnlyList<QuestTask> tasks = await _questRepository.GetTasksForAreaAsync(request2.QuestId, request2.AreaId);
		QuestTask task = Enumerable.FirstOrDefault<QuestTask>((global::System.Collections.Generic.IEnumerable<QuestTask>)tasks, (Func<QuestTask, bool>)((QuestTask t) => t.Id == request2.TaskId));
		if (task == null)
		{
			return Result<ExecuteQuestBattleResult>.FailureResult("Quest task not found");
		}
		var result = _stateService.ExecuteUpdate((Player player) => ValidationResult.Success(), delegate(Player player)
		{
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			int levelsGained = 0;
			bool flag = false;
			QuestOpponent questOpponent = task.QuestOpponents[0];
			Spirit spirit = null;
			int opponentLevel = Enumerable.FirstOrDefault<QuestOpponent>((global::System.Collections.Generic.IEnumerable<QuestOpponent>)task.QuestOpponents)?.Level ?? 1;
			QuestBattleRewards questBattleRewards = CalculateBattleRewards(request2.BattleWon, opponentLevel, task.Rewards);
			if (questBattleRewards != null && task.Rewards != null)
			{
				levelsGained = _playerProgressionService.GainExperience(player, questBattleRewards.Experience);
			}
			if (request2.BattleWon)
			{
				UpdateQuestProgress(player, request2.QuestId, request2.TaskId, 1, isComplete: true);
				_playerCurrencyService.ModifyCurrency(player, "gold", questBattleRewards?.Gold ?? 0);
				_playerCurrencyService.ModifyCurrency(player, "gems", 5L);
				if (new Random().NextDouble() < questOpponent.DropRate && ((global::System.Collections.Generic.IReadOnlyCollection<QuestOpponent>)task.QuestOpponents).Count == 1)
				{
					flag = true;
					spirit = _spiritRepository.GetById(questOpponent.BaseSpiritId);
					_playerInventoryService.ModifyInventory(player, spirit?.Name + " Orb #" + spirit.ID, 1);
				}
			}
			List<string> resetChildIds = new List<string>();
			if (request2.BattleWon && task.IsRepeatable)
			{
				CascadeResetDescendants(player, request2.QuestId, task.Id, (global::System.Collections.Generic.IEnumerable<QuestTask>)tasks, resetChildIds);
			}
			Inventory inventory = default(Inventory);
			return new
			{
				IsTaskComplete = request2.BattleWon,
				TotalSteps = task.TotalSteps,
				LevelsGained = levelsGained,
				TaskRewards = task.Rewards,
				BattleRewards = questBattleRewards,
				OrbDropped = flag,
				OrbPlayerCount = (flag ? (player.Inventory.TryGetValue(spirit.Name + " Orb #" + spirit.ID, ref inventory) ? inventory.Amount : 0) : 0),
				SpiritName = questOpponent.BaseSpiritId,
				ItemRewards = (flag ? (spirit?.Name + " Orb #" + (spirit?.ID ?? "0")) : string.Empty),
				ResetChildIds = resetChildIds
			};
		}, (Player player, updateResult) =>
		{
			//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
			PlayerBatchUpdate playerBatchUpdate = new PlayerBatchUpdate
			{
				PlayerId = (player.PlayerID ?? string.Empty),
				QuestId = request2.QuestId,
				TaskUpdates = new Dictionary<string, TaskProgress> { [request2.TaskId] = new TaskProgress
				{
					Step = ((!updateResult.IsTaskComplete) ? (request2.BattleWon ? 1 : 0) : 0),
					IsCompleted = updateResult.IsTaskComplete
				} },
				ExperienceGain = (int)(updateResult.BattleRewards?.Experience ?? 0.0),
				CurrencyChanges = ((updateResult.BattleRewards != null && updateResult.IsTaskComplete) ? new Dictionary<string, long>
				{
					["gold"] = updateResult.BattleRewards.Gold,
					["gems"] = 5L
				} : new Dictionary<string, long>()),
				InventoryItemChanges = (updateResult.OrbDropped ? new Dictionary<string, int> { [updateResult.ItemRewards] = 1 } : new Dictionary<string, int>()),
				UpdateLevel = (updateResult.LevelsGained > 0),
				UpdateMaxEXP = (updateResult.LevelsGained > 0),
				NewPlayerLevel = ((updateResult.LevelsGained > 0) ? player.PlayerLevel : 0),
				GuildUpdates = ((updateResult.LevelsGained > 0) ? new PlayerGuildUpdate
				{
					GuildId = player.GuildId,
					TargetPlayerId = player.PlayerID
				} : new PlayerGuildUpdate
				{
					TargetPlayerId = string.Empty
				}),
				NewMaxEXP = ((updateResult.LevelsGained > 0) ? player.MaxEXP : 0.0),
				NewMaxEP = ((updateResult.LevelsGained > 0) ? player.MaxEP : 0),
				NewMaxSP = ((updateResult.LevelsGained > 0) ? player.MaxSP : 0),
				UpdateLeaderboard = false
			};
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
			return Result<ExecuteQuestBattleResult>.FailureResult(result.ErrorMessage ?? "Failed");
		}
		await _unequipItemUseCase.ExecuteAsync(new UnequipItemRequest(_stateService.GetPartnerSpirit()?.PlayerSpiritID ?? "", EquipmentType.HeldItem));
		return Result<ExecuteQuestBattleResult>.SuccessResult(new ExecuteQuestBattleResult
		{
			BattleWon = request2.BattleWon,
			IsTaskComplete = request2.BattleWon,
			NewStep = (request2.BattleWon ? 1 : 0),
			TotalSteps = task.TotalSteps,
			BattleRewards = (result.Data.BattleRewards ?? new QuestBattleRewards()),
			OrbFragmentDropped = result.Data.OrbDropped,
			OrbPlayerCount = result.Data.OrbPlayerCount,
			SpiritName = result.Data.SpiritName,
			TaskRewards = ((result.Data.IsTaskComplete && task.Rewards != null) ? new QuestTaskRewards
			{
				Gold = task.Rewards.Gold,
				Experience = task.Rewards.Experience
			} : null)
		});
	}

	private static QuestBattleRewards CalculateBattleRewards(bool playerWon, int opponentLevel, Rewards rewards)
	{
		if (playerWon)
		{
			return new QuestBattleRewards
			{
				Experience = rewards.Experience,
				Gold = rewards.Gold
			};
		}
		return new QuestBattleRewards
		{
			Experience = 1.0,
			Gold = 1L
		};
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
