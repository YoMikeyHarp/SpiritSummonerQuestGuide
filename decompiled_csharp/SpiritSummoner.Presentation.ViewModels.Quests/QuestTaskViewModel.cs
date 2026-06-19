using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using SpiritSummoner.Application.DTOs.Battles;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.Events;
using SpiritSummoner.Application.Services;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Quests;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Quests;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Enums.Battles;
using SpiritSummoner.Domain.Enums.Quests;
using SpiritSummoner.Domain.ValueObjects.Quests;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Infrastructure.Caching;
using SpiritSummoner.Infrastructure.Services;
using SpiritSummoner.Presentation.Models;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.Battles;
using SpiritSummoner.Presentation.ViewModels.BottomSheet;
using SpiritSummoner.Presentation.ViewModels.Popups;
using SpiritSummoner.Presentation.ViewModels.Shared;
using SpiritSummoner.Presentation.ViewModels.Spirits;
using SpiritSummoner.Presentation.Views.BottomSheets.Portal;
using SpiritSummoner.Presentation.Views.BottomSheets.SpiritSheets;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.ViewModels.Quests;

public class QuestTaskViewModel : ObservableObject, ILoadableViewModel, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass62_0
	{
		public string taskId;

		internal bool _003CHandleQuestStateChangeAsync_003Eb__1(PlayerTaskViewModel pt)
		{
			return pt.Task?.Id == taskId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass76_0
	{
		public GetQuestTasksResult data;

		public QuestTaskViewModel _003C_003E4__this;

		internal PlayerTaskViewModel _003CLoadTasksAsync_003Eb__0(QuestTask task)
		{
			PlayerQuest? playerQuest = data.PlayerQuest;
			TaskProgress taskProgress = ((playerQuest != null) ? CollectionExtensions.GetValueOrDefault<string, TaskProgress>((IReadOnlyDictionary<string, TaskProgress>)(object)playerQuest.Tasks, task.Id ?? string.Empty) : null);
			int num = taskProgress?.Step ?? 0;
			bool completed = taskProgress?.IsCompleted ?? false;
			bool isVisible = _003C_003E4__this.IsTaskVisible(task, data.PlayerQuest, data.QuestTasks);
			Spirit spirit = default(Spirit);
			string opponentImageSource = ((((global::System.Collections.Generic.IReadOnlyCollection<QuestOpponent>)task.QuestOpponents).Count <= 1 || string.IsNullOrEmpty(task.OpponentImage)) ? ((((global::System.Collections.Generic.IReadOnlyCollection<QuestOpponent>)task.QuestOpponents).Count > 0 && _003C_003E4__this._cache.Spirits.TryGetValue(task.QuestOpponents[0].BaseSpiritId, ref spirit)) ? (spirit.Image ?? string.Empty) : string.Empty) : task.OpponentImage);
			return new PlayerTaskViewModel
			{
				Task = task,
				Step = num,
				Completed = completed,
				IsLocked = false,
				IsVisible = isVisible,
				PlayerEP = (_003C_003E4__this.Player?.EP ?? 0),
				AnimatedProgress = (double)num / (double)((task.TotalSteps <= 0) ? 1 : task.TotalSteps),
				OpponentImageSource = opponentImageSource
			};
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass86_0
	{
		public long gold;

		public double experience;

		internal void _003CShowCompletionPopup_003Eb__0(QuestRewardsPopupViewModel vm)
		{
			vm.CompletedText = "Quest Progressed";
			vm.CompletedText2 = "You've obtained these rewards:";
			vm.EarnedGold = gold.ToString();
			vm.EarnedEXP = experience.ToString();
			vm.IsItem = false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass87_0
	{
		public string spiritName;

		public int orbPlayerCount;

		internal void _003CShowItemDropPopup_003Eb__0(SpiritOrbDropPopupViewModel vm)
		{
			vm.CompletedText = spiritName + " dropped a Core Orb!";
			vm.CompletedText2 = "Core Orbs can be used in shop to collect new spirits to your collection";
			vm.OrbCount = 1;
			vm.OrbCountText = "x1";
			vm.OrbPlayerCount = orbPlayerCount;
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteBattleTask_003Ed__80 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PlayerTaskViewModel selectedTask;

		public QuestTaskViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private QuestTask _003Ctask_003E5__3;

		private int _003CenemyCount_003E5__4;

		private Result<PreCommitQuestBattleResult> _003CpreCommitResult_003E5__5;

		private BattleLaunchRequest _003CbattleRequest_003E5__6;

		private BattleResultDTO _003CbattleResult_003E5__7;

		private ExecuteQuestBattleRequest _003Crequest_003E5__8;

		private Result<ExecuteQuestBattleResult> _003Cresult_003E5__9;

		private Result<PreCommitQuestBattleResult> _003C_003Es__10;

		private BattleResultDTO _003C_003Es__11;

		private Result<ExecuteQuestBattleResult> _003C_003Es__12;

		private string _003CbaseSpiritId_003E5__13;

		private string _003CspiritDisplayName_003E5__14;

		private Spirit _003Cs_003E5__15;

		private global::System.Exception _003Cex_003E5__16;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<Result<PreCommitQuestBattleResult>> _003C_003Eu__2;

		private TaskAwaiter<BattleResultDTO> _003C_003Eu__3;

		private TaskAwaiter<Result<ExecuteQuestBattleResult>> _003C_003Eu__4;

		private TaskAwaiter<bool> _003C_003Eu__5;

		private void MoveNext()
		{
			//IL_0b41: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b46: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b5c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b5e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b7c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b81: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b89: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0218: Unknown result type (might be due to invalid IL or missing references)
			//IL_021d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0225: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_035d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0362: Unknown result type (might be due to invalid IL or missing references)
			//IL_036a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0415: Unknown result type (might be due to invalid IL or missing references)
			//IL_041a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0422: Unknown result type (might be due to invalid IL or missing references)
			//IL_04cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0762: Unknown result type (might be due to invalid IL or missing references)
			//IL_0767: Unknown result type (might be due to invalid IL or missing references)
			//IL_076f: Unknown result type (might be due to invalid IL or missing references)
			//IL_07d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_07d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_07dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_08a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_08aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_08b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_095d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0962: Unknown result type (might be due to invalid IL or missing references)
			//IL_096a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a83: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a88: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a90: Unknown result type (might be due to invalid IL or missing references)
			//IL_0796: Unknown result type (might be due to invalid IL or missing references)
			//IL_079b: Unknown result type (might be due to invalid IL or missing references)
			//IL_07b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_07b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0492: Unknown result type (might be due to invalid IL or missing references)
			//IL_0497: Unknown result type (might be due to invalid IL or missing references)
			//IL_086b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0870: Unknown result type (might be due to invalid IL or missing references)
			//IL_0922: Unknown result type (might be due to invalid IL or missing references)
			//IL_0927: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_0885: Unknown result type (might be due to invalid IL or missing references)
			//IL_0887: Unknown result type (might be due to invalid IL or missing references)
			//IL_093d: Unknown result type (might be due to invalid IL or missing references)
			//IL_093f: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_027e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0283: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a48: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a4d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0298: Unknown result type (might be due to invalid IL or missing references)
			//IL_029a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01de: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a63: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a65: Unknown result type (might be due to invalid IL or missing references)
			//IL_0323: Unknown result type (might be due to invalid IL or missing references)
			//IL_0328: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_033d: Unknown result type (might be due to invalid IL or missing references)
			//IL_033f: Unknown result type (might be due to invalid IL or missing references)
			//IL_03db: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0728: Unknown result type (might be due to invalid IL or missing references)
			//IL_072d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0742: Unknown result type (might be due to invalid IL or missing references)
			//IL_0744: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 10u)
				{
					goto IL_0041;
				}
				TaskAwaiter awaiter;
				if (num == 11)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0b98;
				}
				if (_003C_003E4__this._navigationService.CanNavigate())
				{
					_003C_003Es__2 = 0;
					goto IL_0041;
				}
				goto end_IL_0007;
				IL_0041:
				try
				{
					TaskAwaiter awaiter12;
					TaskAwaiter awaiter11;
					TaskAwaiter awaiter10;
					TaskAwaiter awaiter9;
					TaskAwaiter<Result<PreCommitQuestBattleResult>> awaiter8;
					TaskAwaiter awaiter7;
					TaskAwaiter awaiter6;
					TaskAwaiter<BattleResultDTO> awaiter5;
					TaskAwaiter<Result<ExecuteQuestBattleResult>> awaiter4;
					TaskAwaiter awaiter3;
					TaskAwaiter<bool> awaiter2;
					BattleLaunchRequest obj;
					List<string> obj2;
					global::System.Collections.Generic.IReadOnlyList<QuestOpponent> questOpponents;
					switch (num)
					{
					default:
						_003Ctask_003E5__3 = selectedTask.Task;
						if (_003Ctask_003E5__3 == null || _003C_003E4__this.Player == null)
						{
							awaiter12 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Invalid task or player data").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter12)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter12;
								_003CExecuteBattleTask_003Ed__80 _003CExecuteBattleTask_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteBattleTask_003Ed__80>(ref awaiter12, ref _003CExecuteBattleTask_003Ed__);
								return;
							}
							goto IL_0149;
						}
						_003CenemyCount_003E5__4 = ((global::System.Collections.Generic.IReadOnlyCollection<QuestOpponent>)_003Ctask_003E5__3.QuestOpponents)?.Count ?? 0;
						if (_003CenemyCount_003E5__4 == 3)
						{
							if (!Enumerable.All<string>((global::System.Collections.Generic.IEnumerable<string>)_003C_003E4__this.Player.ActiveSquad, (Func<string, bool>)((string id) => !string.IsNullOrEmpty(id))))
							{
								awaiter11 = _003C_003E4__this._navigationService.ShowAlertAsync("Invalid squad!", "Check your collection!").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter11)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__1 = awaiter11;
									_003CExecuteBattleTask_003Ed__80 _003CExecuteBattleTask_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteBattleTask_003Ed__80>(ref awaiter11, ref _003CExecuteBattleTask_003Ed__);
									return;
								}
								goto IL_0234;
							}
						}
						else if (string.IsNullOrEmpty(_003C_003E4__this.Player.PartnerSpiritId))
						{
							awaiter10 = _003C_003E4__this._navigationService.ShowAlertAsync("Invalid partner!", "Check your collection!").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter10)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__1 = awaiter10;
								_003CExecuteBattleTask_003Ed__80 _003CExecuteBattleTask_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteBattleTask_003Ed__80>(ref awaiter10, ref _003CExecuteBattleTask_003Ed__);
								return;
							}
							goto IL_02d4;
						}
						if (_003C_003E4__this.Player.EP < _003Ctask_003E5__3.Energy)
						{
							awaiter9 = _003C_003E4__this._navigationService.ShowAlertAsync("Insufficient EP!", "You don't have enough Energy Points for this battle.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter9)).IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__1 = awaiter9;
								_003CExecuteBattleTask_003Ed__80 _003CExecuteBattleTask_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteBattleTask_003Ed__80>(ref awaiter9, ref _003CExecuteBattleTask_003Ed__);
								return;
							}
							goto IL_0379;
						}
						awaiter8 = _003C_003E4__this._preCommitQuestBattleUseCase.ExecuteAsync(new PreCommitQuestBattleRequest(_003Ctask_003E5__3.Id, _003C_003E4__this._currentQuestId ?? string.Empty, _003C_003E4__this._currentAreaId ?? string.Empty)).GetAwaiter();
						if (!awaiter8.IsCompleted)
						{
							num = (_003C_003E1__state = 4);
							_003C_003Eu__2 = awaiter8;
							_003CExecuteBattleTask_003Ed__80 _003CExecuteBattleTask_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<PreCommitQuestBattleResult>>, _003CExecuteBattleTask_003Ed__80>(ref awaiter8, ref _003CExecuteBattleTask_003Ed__);
							return;
						}
						goto IL_0431;
					case 0:
						awaiter12 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0149;
					case 1:
						awaiter11 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0234;
					case 2:
						awaiter10 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_02d4;
					case 3:
						awaiter9 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0379;
					case 4:
						awaiter8 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<Result<PreCommitQuestBattleResult>>);
						num = (_003C_003E1__state = -1);
						goto IL_0431;
					case 5:
						awaiter7 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_04e8;
					case 6:
						awaiter6 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_077e;
					case 7:
						awaiter5 = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter<BattleResultDTO>);
						num = (_003C_003E1__state = -1);
						goto IL_07ec;
					case 8:
						awaiter4 = _003C_003Eu__4;
						_003C_003Eu__4 = default(TaskAwaiter<Result<ExecuteQuestBattleResult>>);
						num = (_003C_003E1__state = -1);
						goto IL_08c1;
					case 9:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0979;
					case 10:
						{
							awaiter2 = _003C_003Eu__5;
							_003C_003Eu__5 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							goto IL_0a9f;
						}
						IL_0979:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						selectedTask.IsPendingExecution = false;
						goto end_IL_0041;
						IL_0431:
						_003C_003Es__10 = awaiter8.GetResult();
						_003CpreCommitResult_003E5__5 = _003C_003Es__10;
						_003C_003Es__10 = null;
						if (!_003CpreCommitResult_003E5__5.Success)
						{
							awaiter7 = _003C_003E4__this._navigationService.ShowAlertAsync("Cannot Start Battle", _003CpreCommitResult_003E5__5.ErrorMessage ?? "Failed to start battle.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter7)).IsCompleted)
							{
								num = (_003C_003E1__state = 5);
								_003C_003Eu__1 = awaiter7;
								_003CExecuteBattleTask_003Ed__80 _003CExecuteBattleTask_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteBattleTask_003Ed__80>(ref awaiter7, ref _003CExecuteBattleTask_003Ed__);
								return;
							}
							goto IL_04e8;
						}
						obj = new BattleLaunchRequest
						{
							Mode = BattleMode.PVE,
							PlayerId = _003C_003E4__this.Player.PlayerID
						};
						if (_003CenemyCount_003E5__4 != 3)
						{
							obj2 = new List<string>(1);
							obj2.Add(_003C_003E4__this.Player.PartnerSpiritId ?? string.Empty);
						}
						else
						{
							obj2 = Enumerable.ToList<string>(Enumerable.Where<string>((global::System.Collections.Generic.IEnumerable<string>)_003C_003E4__this.Player.ActiveSquad, (Func<string, bool>)((string id) => !string.IsNullOrEmpty(id))));
						}
						obj.PlayerSpiritIds = obj2;
						questOpponents = _003Ctask_003E5__3.QuestOpponents;
						obj.OpponentLevel = ((questOpponents == null) ? null : Enumerable.FirstOrDefault<QuestOpponent>((global::System.Collections.Generic.IEnumerable<QuestOpponent>)questOpponents)?.Level).GetValueOrDefault(1);
						obj.QuestOpponents = _003Ctask_003E5__3.QuestOpponents;
						obj.QuestRoute = _003C_003E4__this._stateService.CurrentRoute;
						obj.QuestTaskId = _003Ctask_003E5__3.Id;
						obj.ChallengerBackgroundImage = ((((global::System.Collections.Generic.IReadOnlyCollection<QuestOpponent>)_003Ctask_003E5__3.QuestOpponents).Count == 3) ? _003Ctask_003E5__3.OpponentBackgroundImage : null);
						obj.ChallengerName = ((((global::System.Collections.Generic.IReadOnlyCollection<QuestOpponent>)_003Ctask_003E5__3.QuestOpponents).Count == 3) ? _003Ctask_003E5__3.OpponentName : null);
						obj.ChallengerGuildName = ((((global::System.Collections.Generic.IReadOnlyCollection<QuestOpponent>)_003Ctask_003E5__3.QuestOpponents).Count == 3) ? _003Ctask_003E5__3.OpponentGuild : null);
						obj.BattleId = _003CpreCommitResult_003E5__5.Data.BattleId;
						obj.CompletionSource = new TaskCompletionSource<BattleResultDTO>();
						obj.QuestRewards = new Rewards
						{
							Experience = _003Ctask_003E5__3.Rewards.Experience,
							Gold = _003Ctask_003E5__3.Rewards.Gold
						};
						_003CbattleRequest_003E5__6 = obj;
						awaiter6 = _003C_003E4__this._navigationService.NavigateToBattleViewAsync(_003C_003E4__this._stateService.CurrentRoute + "/battleground", _003CbattleRequest_003E5__6).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter6)).IsCompleted)
						{
							num = (_003C_003E1__state = 6);
							_003C_003Eu__1 = awaiter6;
							_003CExecuteBattleTask_003Ed__80 _003CExecuteBattleTask_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteBattleTask_003Ed__80>(ref awaiter6, ref _003CExecuteBattleTask_003Ed__);
							return;
						}
						goto IL_077e;
						IL_077e:
						((TaskAwaiter)(ref awaiter6)).GetResult();
						awaiter5 = _003CbattleRequest_003E5__6.CompletionSource.Task.GetAwaiter();
						if (!awaiter5.IsCompleted)
						{
							num = (_003C_003E1__state = 7);
							_003C_003Eu__3 = awaiter5;
							_003CExecuteBattleTask_003Ed__80 _003CExecuteBattleTask_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<BattleResultDTO>, _003CExecuteBattleTask_003Ed__80>(ref awaiter5, ref _003CExecuteBattleTask_003Ed__);
							return;
						}
						goto IL_07ec;
						IL_08c1:
						_003C_003Es__12 = awaiter4.GetResult();
						_003Cresult_003E5__9 = _003C_003Es__12;
						_003C_003Es__12 = null;
						if (!_003Cresult_003E5__9.Success)
						{
							awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__9.ErrorMessage ?? "Failed to process battle result.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 9);
								_003C_003Eu__1 = awaiter3;
								_003CExecuteBattleTask_003Ed__80 _003CExecuteBattleTask_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteBattleTask_003Ed__80>(ref awaiter3, ref _003CExecuteBattleTask_003Ed__);
								return;
							}
							goto IL_0979;
						}
						if (!_003Cresult_003E5__9.Data.IsTaskComplete || !_003Cresult_003E5__9.Data.OrbFragmentDropped)
						{
							break;
						}
						_003CbaseSpiritId_003E5__13 = _003Cresult_003E5__9.Data.SpiritName ?? string.Empty;
						_003CspiritDisplayName_003E5__14 = (_003C_003E4__this._cache.Spirits.TryGetValue(_003CbaseSpiritId_003E5__13, ref _003Cs_003E5__15) ? (_003Cs_003E5__15.Name ?? _003CbaseSpiritId_003E5__13) : _003CbaseSpiritId_003E5__13);
						awaiter2 = _003C_003E4__this.ShowItemDropPopup(_003CspiritDisplayName_003E5__14, _003Cresult_003E5__9.Data.OrbPlayerCount).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 10);
							_003C_003Eu__5 = awaiter2;
							_003CExecuteBattleTask_003Ed__80 _003CExecuteBattleTask_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteBattleTask_003Ed__80>(ref awaiter2, ref _003CExecuteBattleTask_003Ed__);
							return;
						}
						goto IL_0a9f;
						IL_02d4:
						((TaskAwaiter)(ref awaiter10)).GetResult();
						goto end_IL_0041;
						IL_0379:
						((TaskAwaiter)(ref awaiter9)).GetResult();
						selectedTask.IsPendingExecution = false;
						goto end_IL_0041;
						IL_0149:
						((TaskAwaiter)(ref awaiter12)).GetResult();
						goto end_IL_0041;
						IL_04e8:
						((TaskAwaiter)(ref awaiter7)).GetResult();
						selectedTask.IsPendingExecution = false;
						goto end_IL_0041;
						IL_07ec:
						_003C_003Es__11 = awaiter5.GetResult();
						_003CbattleResult_003E5__7 = _003C_003Es__11;
						_003C_003Es__11 = null;
						_003Crequest_003E5__8 = new ExecuteQuestBattleRequest(_003Ctask_003E5__3.Id, _003C_003E4__this._currentQuestId ?? string.Empty, _003C_003E4__this._currentAreaId ?? string.Empty, _003CbattleResult_003E5__7.Victory);
						awaiter4 = _003C_003E4__this._executeBattleUseCase.ExecuteAsync(_003Crequest_003E5__8).GetAwaiter();
						if (!awaiter4.IsCompleted)
						{
							num = (_003C_003E1__state = 8);
							_003C_003Eu__4 = awaiter4;
							_003CExecuteBattleTask_003Ed__80 _003CExecuteBattleTask_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<ExecuteQuestBattleResult>>, _003CExecuteBattleTask_003Ed__80>(ref awaiter4, ref _003CExecuteBattleTask_003Ed__);
							return;
						}
						goto IL_08c1;
						IL_0a9f:
						awaiter2.GetResult();
						_003CbaseSpiritId_003E5__13 = null;
						_003CspiritDisplayName_003E5__14 = null;
						_003Cs_003E5__15 = null;
						break;
						IL_0234:
						((TaskAwaiter)(ref awaiter11)).GetResult();
						goto end_IL_0041;
					}
					_003Ctask_003E5__3 = null;
					_003CpreCommitResult_003E5__5 = null;
					_003CbattleRequest_003E5__6 = null;
					_003CbattleResult_003E5__7 = null;
					_003Crequest_003E5__8 = null;
					_003Cresult_003E5__9 = null;
					goto IL_0afd;
					end_IL_0041:;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
					goto IL_0afd;
				}
				goto end_IL_0007;
				IL_0bdc:
				_003C_003Es__1 = null;
				goto end_IL_0007;
				IL_0afd:
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_0bdc;
				}
				_003Cex_003E5__16 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Battle Error", _003Cex_003E5__16.Message).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 11);
					_003C_003Eu__1 = awaiter;
					_003CExecuteBattleTask_003Ed__80 _003CExecuteBattleTask_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteBattleTask_003Ed__80>(ref awaiter, ref _003CExecuteBattleTask_003Ed__);
					return;
				}
				goto IL_0b98;
				IL_0b98:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine($"ExecuteBattleTask error: {_003Cex_003E5__16}");
				_003Cex_003E5__16 = null;
				goto IL_0bdc;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteHoldToComplete_003Ed__84 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PlayerTaskViewModel selectedTask;

		public CancellationToken cancellationToken;

		public QuestTaskViewModel _003C_003E4__this;

		private bool _003C_003Es__1;

		private object _003C_003Es__2;

		private int _003C_003Es__3;

		private QuestTask _003Ctask_003E5__4;

		private int _003CcurrentStepsToComplete_003E5__5;

		private Player _003Cplayer_003E5__6;

		private ExecuteQuestTaskRequest _003Crequest_003E5__7;

		private Result<ExecuteQuestTaskResult> _003Cresult_003E5__8;

		private int _003CnewStep_003E5__9;

		private bool _003CisComplete_003E5__10;

		private double _003Ctarget_003E5__11;

		private Result<ExecuteQuestTaskResult> _003C_003Es__12;

		private global::System.Exception _003Cex_003E5__13;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private TaskAwaiter<Result<ExecuteQuestTaskResult>> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_055a: Unknown result type (might be due to invalid IL or missing references)
			//IL_055f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_0574: Unknown result type (might be due to invalid IL or missing references)
			//IL_0576: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0593: Unknown result type (might be due to invalid IL or missing references)
			//IL_0598: Unknown result type (might be due to invalid IL or missing references)
			//IL_05a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_039e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0397: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<bool> awaiter;
				if (num != 0)
				{
					if ((uint)(num - 1) <= 3u)
					{
						goto IL_00b0;
					}
					awaiter = _003C_003E4__this._taskExecutionSemaphore.WaitAsync(0, CancellationToken.None).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CExecuteHoldToComplete_003Ed__84 _003CExecuteHoldToComplete_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteHoldToComplete_003Ed__84>(ref awaiter, ref _003CExecuteHoldToComplete_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__1 = awaiter.GetResult();
				if (_003C_003Es__1)
				{
					goto IL_00b0;
				}
				Console.WriteLine("Task execution already in progress");
				goto end_IL_0007;
				IL_00b0:
				try
				{
					TaskAwaiter awaiter2;
					if ((uint)(num - 1) > 2u)
					{
						if (num == 4)
						{
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_05af;
						}
						_003C_003Es__3 = 0;
					}
					try
					{
						TaskAwaiter awaiter5;
						TaskAwaiter<Result<ExecuteQuestTaskResult>> awaiter4;
						TaskAwaiter awaiter3;
						switch (num)
						{
						default:
							_003Ctask_003E5__4 = selectedTask.Task;
							if (_003C_003E4__this.Player == null || _003Ctask_003E5__4 == null)
							{
								awaiter5 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Invalid player or task data").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter5;
									_003CExecuteHoldToComplete_003Ed__84 _003CExecuteHoldToComplete_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteHoldToComplete_003Ed__84>(ref awaiter5, ref _003CExecuteHoldToComplete_003Ed__);
									return;
								}
								goto IL_0193;
							}
							selectedTask.IsHoldActive = true;
							_003CcurrentStepsToComplete_003E5__5 = _003Ctask_003E5__4.TotalSteps - selectedTask.Step;
							goto IL_04d0;
						case 1:
							awaiter5 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0193;
						case 2:
							awaiter4 = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<Result<ExecuteQuestTaskResult>>);
							num = (_003C_003E1__state = -1);
							goto IL_02fe;
						case 3:
							{
								awaiter3 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_03fd;
							}
							IL_0193:
							((TaskAwaiter)(ref awaiter5)).GetResult();
							goto end_IL_00cd;
							IL_02fe:
							_003C_003Es__12 = awaiter4.GetResult();
							_003Cresult_003E5__8 = _003C_003Es__12;
							_003C_003Es__12 = null;
							if (!_003Cresult_003E5__8.Success)
							{
								break;
							}
							_003CnewStep_003E5__9 = _003Cresult_003E5__8.Data.NewStep;
							_003CisComplete_003E5__10 = _003Cresult_003E5__8.Data.IsTaskComplete;
							_003Ctarget_003E5__11 = (double)_003CnewStep_003E5__9 / (double)_003Ctask_003E5__4.TotalSteps;
							awaiter3 = selectedTask.AnimateProgressToAsync(_003Ctarget_003E5__11, 300, _003CisComplete_003E5__10 ? CancellationToken.None : cancellationToken).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__2 = awaiter3;
								_003CExecuteHoldToComplete_003Ed__84 _003CExecuteHoldToComplete_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteHoldToComplete_003Ed__84>(ref awaiter3, ref _003CExecuteHoldToComplete_003Ed__);
								return;
							}
							goto IL_03fd;
							IL_04d0:
							if (((CancellationToken)(ref cancellationToken)).IsCancellationRequested)
							{
								break;
							}
							_003Cplayer_003E5__6 = _003C_003E4__this.Player;
							if (_003Cplayer_003E5__6 == null || selectedTask.Step >= _003Ctask_003E5__4.TotalSteps || !selectedTask.CanStartOrContinue || _003Cplayer_003E5__6.EP < _003Ctask_003E5__4.Energy)
							{
								break;
							}
							_003Crequest_003E5__7 = new ExecuteQuestTaskRequest(_003Ctask_003E5__4.Id ?? string.Empty, _003C_003E4__this._currentQuestId ?? string.Empty, _003C_003E4__this._currentAreaId ?? string.Empty);
							awaiter4 = _003C_003E4__this._executeTaskUseCase.ExecuteAsync(_003Crequest_003E5__7).GetAwaiter();
							if (!awaiter4.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter4;
								_003CExecuteHoldToComplete_003Ed__84 _003CExecuteHoldToComplete_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<ExecuteQuestTaskResult>>, _003CExecuteHoldToComplete_003Ed__84>(ref awaiter4, ref _003CExecuteHoldToComplete_003Ed__);
								return;
							}
							goto IL_02fe;
							IL_03fd:
							((TaskAwaiter)(ref awaiter3)).GetResult();
							selectedTask.Step = ((!_003CisComplete_003E5__10) ? _003CnewStep_003E5__9 : 0);
							if (_003CisComplete_003E5__10)
							{
								selectedTask.Completed = true;
							}
							if (_003CisComplete_003E5__10)
							{
								QuestTaskViewModel questTaskViewModel = _003C_003E4__this;
								ObservableCollection<PlayerTaskViewModel>? playerTasks = _003C_003E4__this.PlayerTasks;
								questTaskViewModel.CompletedTasksCount = ((playerTasks != null) ? Enumerable.Count<PlayerTaskViewModel>((global::System.Collections.Generic.IEnumerable<PlayerTaskViewModel>)playerTasks, (Func<PlayerTaskViewModel, bool>)((PlayerTaskViewModel t) => t.Completed)) : _003C_003E4__this.CompletedTasksCount);
								_003C_003E4__this.ReconcileVisibility();
								_003C_003E4__this.HandleTaskCompletionEffects(selectedTask, _003CcurrentStepsToComplete_003E5__5);
								break;
							}
							_003Cplayer_003E5__6 = null;
							_003Crequest_003E5__7 = null;
							_003Cresult_003E5__8 = null;
							goto IL_04d0;
						}
						_003Ctask_003E5__4 = null;
						goto IL_0509;
						end_IL_00cd:;
					}
					catch (OperationCanceledException)
					{
						goto IL_0509;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__2 = ex;
						_003C_003Es__3 = 1;
						goto IL_0509;
					}
					goto end_IL_00b0;
					IL_0509:
					int num2 = _003C_003Es__3;
					if (num2 != 1)
					{
						goto IL_05c1;
					}
					_003Cex_003E5__13 = (global::System.Exception)_003C_003Es__2;
					selectedTask.IsPendingExecution = false;
					awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Hold-to-complete error!", _003Cex_003E5__13.Message).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__2 = awaiter2;
						_003CExecuteHoldToComplete_003Ed__84 _003CExecuteHoldToComplete_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteHoldToComplete_003Ed__84>(ref awaiter2, ref _003CExecuteHoldToComplete_003Ed__);
						return;
					}
					goto IL_05af;
					IL_05af:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					_003Cex_003E5__13 = null;
					goto IL_05c1;
					IL_05c1:
					_003C_003Es__2 = null;
					end_IL_00b0:;
				}
				finally
				{
					if (num < 0)
					{
						selectedTask.IsHoldActive = false;
						_003C_003E4__this._taskExecutionSemaphore.Release();
						_003C_003E4__this._lastHoldCompletionTime = global::System.DateTime.UtcNow;
					}
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGoBack_003Ed__71 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public QuestTaskViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_013e;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CGoBack_003Ed__71 _003CGoBack_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoBack_003Ed__71>(ref awaiter2, ref _003CGoBack_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter2)).GetResult();
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_0150;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Navigation error", _003Cex_003E5__3.Message).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CGoBack_003Ed__71 _003CGoBack_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoBack_003Ed__71>(ref awaiter, ref _003CGoBack_003Ed__);
					return;
				}
				goto IL_013e;
				IL_013e:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__3 = null;
				goto IL_0150;
				IL_0150:
				_003C_003Es__1 = null;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGoToFullCollection_003Ed__75 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public QuestTaskViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0152;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._navigationService.NavigateToAsync(_003C_003E4__this._stateService.CurrentRoute + "/collection").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CGoToFullCollection_003Ed__75 _003CGoToFullCollection_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToFullCollection_003Ed__75>(ref awaiter2, ref _003CGoToFullCollection_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter2)).GetResult();
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_0175;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to open collection.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CGoToFullCollection_003Ed__75 _003CGoToFullCollection_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToFullCollection_003Ed__75>(ref awaiter, ref _003CGoToFullCollection_003Ed__);
					return;
				}
				goto IL_0152;
				IL_0152:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine(_003Cex_003E5__3.Message);
				_003Cex_003E5__3 = null;
				goto IL_0175;
				IL_0175:
				_003C_003Es__1 = null;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGoToPortal_003Ed__70 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public QuestTaskViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private BottomSheet _003Csheet_003E5__3;

		private BottomSheet _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<BottomSheet> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if ((uint)num > 1u)
				{
					if (num == 2)
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01da;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					TaskAwaiter<BottomSheet> awaiter3;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0125;
						}
						awaiter3 = _003C_003E4__this._navigationService.GetFullSheet<PortalBottomSheet, PortalSheetViewModel>("portal").GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CGoToPortal_003Ed__70 _003CGoToPortal_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<BottomSheet>, _003CGoToPortal_003Ed__70>(ref awaiter3, ref _003CGoToPortal_003Ed__);
							return;
						}
					}
					else
					{
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<BottomSheet>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__4 = awaiter3.GetResult();
					_003Csheet_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					awaiter2 = _003C_003E4__this._bottomSheetService.ShowSheetAsync(_003Csheet_003E5__3).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter2;
						_003CGoToPortal_003Ed__70 _003CGoToPortal_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToPortal_003Ed__70>(ref awaiter2, ref _003CGoToPortal_003Ed__);
						return;
					}
					goto IL_0125;
					IL_0125:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					_003Csheet_003E5__3 = null;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_01fd;
				}
				_003Cex_003E5__5 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Navigation Error", "Failed to navigate to portal.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 2);
					_003C_003Eu__2 = awaiter;
					_003CGoToPortal_003Ed__70 _003CGoToPortal_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToPortal_003Ed__70>(ref awaiter, ref _003CGoToPortal_003Ed__);
					return;
				}
				goto IL_01da;
				IL_01da:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine(_003Cex_003E5__5.Message);
				_003Cex_003E5__5 = null;
				goto IL_01fd;
				IL_01fd:
				_003C_003Es__1 = null;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CHandleQuestStateChangeAsync_003Ed__62 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public StateChangedEventArgs e;

		public QuestTaskViewModel _003C_003E4__this;

		private HashSet<string> _003CprocessedTaskIds_003E5__1;

		private HashSet<string> _003CdictTaskIds_003E5__2;

		private bool _003C_003Es__3;

		private object _003C_003Es__4;

		private int _003C_003Es__5;

		private Player _003Cplayer_003E5__6;

		private PlayerQuest _003CcurrentPlayerQuests_003E5__7;

		private List<string> _003CtasksNeedingVisibilityCheck_003E5__8;

		private HashSet<string> _003C_003Es__9;

		private Enumerator<string, TaskProgress> _003C_003Es__10;

		private Enumerator<string, TaskProgress> _003C_003Es__11;

		private _003C_003Ec__DisplayClass62_0 _003C_003E8__12;

		private TaskProgress _003CtaskProgress_003E5__13;

		private PlayerTaskViewModel _003CplayerTask_003E5__14;

		private bool _003CwasCompleted_003E5__15;

		private bool _003CisCompleted_003E5__16;

		private bool _003C_003Es__17;

		private global::System.Exception _003Cex_003E5__18;

		private Enumerator<PlayerTaskViewModel> _003C_003Es__19;

		private PlayerTaskViewModel _003Cpt_003E5__20;

		private string _003Cid_003E5__21;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0644: Unknown result type (might be due to invalid IL or missing references)
			//IL_0649: Unknown result type (might be due to invalid IL or missing references)
			//IL_0599: Unknown result type (might be due to invalid IL or missing references)
			//IL_059e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0723: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_05d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_05d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0364: Unknown result type (might be due to invalid IL or missing references)
			//IL_0369: Unknown result type (might be due to invalid IL or missing references)
			//IL_0371: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_032a: Unknown result type (might be due to invalid IL or missing references)
			//IL_032f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_022b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0230: Unknown result type (might be due to invalid IL or missing references)
			//IL_0344: Unknown result type (might be due to invalid IL or missing references)
			//IL_0346: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<bool> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_00a4;
				}
				if ((uint)(num - 1) <= 1u)
				{
					goto IL_00d6;
				}
				if (!(e.EntityId != _003C_003E4__this._currentQuestId))
				{
					awaiter = _003C_003E4__this._stateChangeSemaphore.WaitAsync(0).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CHandleQuestStateChangeAsync_003Ed__62 _003CHandleQuestStateChangeAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CHandleQuestStateChangeAsync_003Ed__62>(ref awaiter, ref _003CHandleQuestStateChangeAsync_003Ed__);
						return;
					}
					goto IL_00a4;
				}
				goto end_IL_0007;
				IL_00d6:
				try
				{
					TaskAwaiter awaiter2;
					if (num != 1)
					{
						if (num == 2)
						{
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_05ef;
						}
						_003C_003Es__5 = 0;
					}
					try
					{
						if (num == 1)
						{
							goto IL_0236;
						}
						if (_003C_003E4__this.PlayerTasks != null)
						{
							_003Cplayer_003E5__6 = _003C_003E4__this.Player;
							if (_003Cplayer_003E5__6 != null)
							{
								IReadOnlyDictionary<string, PlayerQuest> playerQuests = _003Cplayer_003E5__6.PlayerQuests;
								_003CcurrentPlayerQuests_003E5__7 = ((playerQuests != null) ? CollectionExtensions.GetValueOrDefault<string, PlayerQuest>(playerQuests, ((object)_003C_003E4__this.CurrentQuestType).ToString()) : null);
								if (_003CcurrentPlayerQuests_003E5__7 != null)
								{
									_003C_003Es__9 = new HashSet<string>();
									_003C_003Es__10 = _003CcurrentPlayerQuests_003E5__7.Tasks.Keys.GetEnumerator();
									try
									{
										while (_003C_003Es__10.MoveNext())
										{
											string current = _003C_003Es__10.Current;
											_003C_003Es__9.Add(current);
										}
									}
									finally
									{
										if (num < 0)
										{
											((global::System.IDisposable)_003C_003Es__10).Dispose();
										}
									}
									_003C_003Es__10 = default(Enumerator<string, TaskProgress>);
									_003CdictTaskIds_003E5__2 = _003C_003Es__9;
									_003C_003Es__9 = null;
									_003CtasksNeedingVisibilityCheck_003E5__8 = new List<string>();
									_003C_003Es__11 = _003CcurrentPlayerQuests_003E5__7.Tasks.Keys.GetEnumerator();
									goto IL_0236;
								}
							}
						}
						goto end_IL_00f1;
						IL_0236:
						try
						{
							if (num != 1)
							{
								goto IL_047f;
							}
							TaskAwaiter<bool> awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							goto IL_0380;
							IL_0380:
							_003C_003Es__17 = awaiter3.GetResult();
							_003CisCompleted_003E5__16 = _003C_003Es__17;
							if (_003CplayerTask_003E5__14 == _003C_003E4__this._currentHoldTask && (_003CisCompleted_003E5__16 || _003CplayerTask_003E5__14.Step >= _003CplayerTask_003E5__14.Task?.TotalSteps))
							{
								_003C_003E4__this.StopTaskHold();
							}
							if (_003CisCompleted_003E5__16)
							{
								_003C_003E4__this.HandleTaskCompletionEffects(_003CplayerTask_003E5__14);
							}
							if (!_003CwasCompleted_003E5__15 && _003CplayerTask_003E5__14.Completed)
							{
								_003CtasksNeedingVisibilityCheck_003E5__8.Add(_003C_003E8__12.taskId);
							}
							goto IL_0469;
							IL_047f:
							while (_003C_003Es__11.MoveNext())
							{
								_003C_003E8__12 = new _003C_003Ec__DisplayClass62_0();
								_003C_003E8__12.taskId = _003C_003Es__11.Current;
								_003CtaskProgress_003E5__13 = _003CcurrentPlayerQuests_003E5__7.Tasks[_003C_003E8__12.taskId];
								_003CplayerTask_003E5__14 = Enumerable.FirstOrDefault<PlayerTaskViewModel>((global::System.Collections.Generic.IEnumerable<PlayerTaskViewModel>)_003C_003E4__this._allPlayerTasks, (Func<PlayerTaskViewModel, bool>)((PlayerTaskViewModel pt) => pt.Task?.Id == _003C_003E8__12.taskId));
								if (_003CplayerTask_003E5__14 != null)
								{
									_003CprocessedTaskIds_003E5__1.Add(_003C_003E8__12.taskId);
									if (_003C_003E4__this._holdSessionActive && _003CplayerTask_003E5__14 == _003C_003E4__this._currentHoldTask)
									{
										continue;
									}
									goto IL_0308;
								}
								goto IL_0469;
							}
							goto end_IL_0236;
							IL_0308:
							_003CwasCompleted_003E5__15 = _003CplayerTask_003E5__14.Completed;
							awaiter3 = _003CplayerTask_003E5__14.UpdateProgress(_003CtaskProgress_003E5__13).GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter3;
								_003CHandleQuestStateChangeAsync_003Ed__62 _003CHandleQuestStateChangeAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CHandleQuestStateChangeAsync_003Ed__62>(ref awaiter3, ref _003CHandleQuestStateChangeAsync_003Ed__);
								return;
							}
							goto IL_0380;
							IL_0469:
							_003CtaskProgress_003E5__13 = null;
							_003CplayerTask_003E5__14 = null;
							_003C_003E8__12 = null;
							goto IL_047f;
							end_IL_0236:;
						}
						finally
						{
							if (num < 0)
							{
								((global::System.IDisposable)_003C_003Es__11).Dispose();
							}
						}
						_003C_003Es__11 = default(Enumerator<string, TaskProgress>);
						_003C_003E4__this.CompletedTasksCount = Enumerable.Count<PlayerTaskViewModel>((global::System.Collections.Generic.IEnumerable<PlayerTaskViewModel>)_003C_003E4__this.PlayerTasks, (Func<PlayerTaskViewModel, bool>)((PlayerTaskViewModel pt) => pt.Completed));
						if (_003CtasksNeedingVisibilityCheck_003E5__8.Count > 0)
						{
							_003C_003E4__this.ReconcileVisibility();
						}
						((ObservableObject)_003C_003E4__this).OnPropertyChanged("CurrentPlayerQuests");
						_003Cplayer_003E5__6 = null;
						_003CcurrentPlayerQuests_003E5__7 = null;
						_003CtasksNeedingVisibilityCheck_003E5__8 = null;
						goto IL_054b;
						end_IL_00f1:;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__4 = ex;
						_003C_003Es__5 = 1;
						goto IL_054b;
					}
					goto end_IL_00d6;
					IL_054b:
					int num2 = _003C_003Es__5;
					if (num2 != 1)
					{
						goto IL_0612;
					}
					_003Cex_003E5__18 = (global::System.Exception)_003C_003Es__4;
					awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to update quest progress: " + _003Cex_003E5__18.Message).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__2 = awaiter2;
						_003CHandleQuestStateChangeAsync_003Ed__62 _003CHandleQuestStateChangeAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleQuestStateChangeAsync_003Ed__62>(ref awaiter2, ref _003CHandleQuestStateChangeAsync_003Ed__);
						return;
					}
					goto IL_05ef;
					IL_05ef:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					Console.WriteLine(_003Cex_003E5__18.StackTrace);
					_003Cex_003E5__18 = null;
					goto IL_0612;
					IL_0612:
					_003C_003Es__4 = null;
					end_IL_00d6:;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this._stateChangeSemaphore.Release();
						_003C_003Es__19 = _003C_003E4__this._allPlayerTasks.GetEnumerator();
						try
						{
							while (_003C_003Es__19.MoveNext())
							{
								_003Cpt_003E5__20 = _003C_003Es__19.Current;
								if (!_003Cpt_003E5__20.IsPendingExecution)
								{
									continue;
								}
								_003Cid_003E5__21 = _003Cpt_003E5__20.Task?.Id ?? string.Empty;
								if (!_003CprocessedTaskIds_003E5__1.Contains(_003Cid_003E5__21))
								{
									HashSet<string> obj = _003CdictTaskIds_003E5__2;
									if (obj == null || obj.Contains(_003Cid_003E5__21))
									{
										goto IL_06e5;
									}
								}
								_003Cpt_003E5__20.IsPendingExecution = false;
								goto IL_06e5;
								IL_06e5:
								_003Cid_003E5__21 = null;
								_003Cpt_003E5__20 = null;
							}
						}
						finally
						{
							if (num < 0)
							{
								((global::System.IDisposable)_003C_003Es__19).Dispose();
							}
						}
						_003C_003Es__19 = default(Enumerator<PlayerTaskViewModel>);
					}
				}
				goto end_IL_0007;
				IL_00a4:
				_003C_003Es__3 = awaiter.GetResult();
				if (_003C_003Es__3)
				{
					_003CprocessedTaskIds_003E5__1 = new HashSet<string>();
					_003CdictTaskIds_003E5__2 = null;
					goto IL_00d6;
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CHandleTaskCompletionEffects_003Ed__85 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PlayerTaskViewModel selectedTask;

		public int holdCounter;

		public QuestTaskViewModel _003C_003E4__this;

		private QuestTask _003Ctask_003E5__1;

		private bool _003CshouldShowParagraph_003E5__2;

		private object _003C_003Es__3;

		private int _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0390: Unknown result type (might be due to invalid IL or missing references)
			//IL_0395: Unknown result type (might be due to invalid IL or missing references)
			//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0312: Unknown result type (might be due to invalid IL or missing references)
			//IL_0317: Unknown result type (might be due to invalid IL or missing references)
			//IL_031f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 2u)
				{
					goto IL_0043;
				}
				if (!selectedTask.IsShowingCompletionEffects)
				{
					_003Ctask_003E5__1 = selectedTask.Task;
					selectedTask.IsShowingCompletionEffects = true;
					goto IL_0043;
				}
				goto end_IL_0007;
				IL_0043:
				try
				{
					TaskAwaiter<bool> awaiter2;
					TaskAwaiter awaiter;
					switch (num)
					{
					default:
						if (!_003Ctask_003E5__1.Battle && selectedTask.Completed)
						{
							awaiter2 = _003C_003E4__this.ShowCompletionPopup(_003Ctask_003E5__1.Rewards.Gold * holdCounter, _003Ctask_003E5__1.Rewards.Experience * holdCounter).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003CHandleTaskCompletionEffects_003Ed__85 _003CHandleTaskCompletionEffects_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CHandleTaskCompletionEffects_003Ed__85>(ref awaiter2, ref _003CHandleTaskCompletionEffects_003Ed__);
								return;
							}
							goto IL_0118;
						}
						goto IL_0121;
					case 0:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_0118;
					case 1:
					{
						try
						{
							TaskAwaiter awaiter3;
							if (num != 1)
							{
								_003C_003E4__this._questParagraphService.Image = Enumerable.ToList<string>(Enumerable.Select<QuestParagraph, string>((global::System.Collections.Generic.IEnumerable<QuestParagraph>)_003Ctask_003E5__1.Paragraph, (Func<QuestParagraph, string>)((QuestParagraph p) => p.Image)));
								_003C_003E4__this._questParagraphService.ParagraphText = Enumerable.ToList<string>(Enumerable.Select<QuestParagraph, string>((global::System.Collections.Generic.IEnumerable<QuestParagraph>)_003Ctask_003E5__1.Paragraph, (Func<QuestParagraph, string>)((QuestParagraph p) => p.Text)));
								_003C_003E4__this._questParagraphService.questID = _003C_003E4__this._currentQuestId;
								_003C_003E4__this._questParagraphService.CurrentAreaName = _003C_003E4__this.CurrentAreaName ?? string.Empty;
								_003C_003E4__this._questParagraphService.CurrentIndex = 0;
								awaiter3 = _003C_003E4__this._navigationService.NavigateToAsync($"//questtasks/{_003C_003E4__this._currentQuestId}/{_003C_003E4__this.CurrentAreaName}/paragraph").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter3;
									_003CHandleTaskCompletionEffects_003Ed__85 _003CHandleTaskCompletionEffects_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleTaskCompletionEffects_003Ed__85>(ref awaiter3, ref _003CHandleTaskCompletionEffects_003Ed__);
									return;
								}
							}
							else
							{
								awaiter3 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
							}
							((TaskAwaiter)(ref awaiter3)).GetResult();
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__3 = ex;
							_003C_003Es__4 = 1;
						}
						int num2 = _003C_003Es__4;
						if (num2 != 1)
						{
							break;
						}
						_003Cex_003E5__5 = (global::System.Exception)_003C_003Es__3;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cex_003E5__5.Message).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter;
							_003CHandleTaskCompletionEffects_003Ed__85 _003CHandleTaskCompletionEffects_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleTaskCompletionEffects_003Ed__85>(ref awaiter, ref _003CHandleTaskCompletionEffects_003Ed__);
							return;
						}
						goto IL_03e6;
					}
					case 2:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_03e6;
						}
						IL_0121:
						_003CshouldShowParagraph_003E5__2 = _003Ctask_003E5__1.Paragraph.Count > 1 || (_003Ctask_003E5__1.Paragraph.Count == 1 && _003Ctask_003E5__1.Paragraph[0].View);
						if (_003CshouldShowParagraph_003E5__2)
						{
							_003C_003Es__4 = 0;
							goto case 1;
						}
						goto end_IL_0043;
						IL_03e6:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine(_003Cex_003E5__5.StackTrace);
						_003Cex_003E5__5 = null;
						break;
						IL_0118:
						awaiter2.GetResult();
						goto IL_0121;
					}
					_003C_003Es__3 = null;
					end_IL_0043:;
				}
				finally
				{
					if (num < 0)
					{
						selectedTask.ResetAnimatedProgress();
						selectedTask.IsShowingCompletionEffects = false;
					}
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CHandleTaskHoldAsync_003Ed__81 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PlayerTaskViewModel selectedTask;

		public CancellationToken cancellationToken;

		public QuestTaskViewModel _003C_003E4__this;

		private bool _003C_003Es__1;

		private global::System.Exception _003Cex_003E5__2;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<bool> awaiter;
				if (num != 0)
				{
					if ((uint)(num - 1) <= 1u)
					{
						goto IL_00a5;
					}
					awaiter = _003C_003E4__this._holdSemaphore.WaitAsync(0, cancellationToken).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CHandleTaskHoldAsync_003Ed__81 _003CHandleTaskHoldAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CHandleTaskHoldAsync_003Ed__81>(ref awaiter, ref _003CHandleTaskHoldAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__1 = awaiter.GetResult();
				if (_003C_003Es__1)
				{
					goto IL_00a5;
				}
				goto end_IL_0007;
				IL_00a5:
				try
				{
					TaskAwaiter awaiter2;
					TaskAwaiter awaiter3;
					if (num != 1)
					{
						if (num == 2)
						{
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_01da;
						}
						_003C_003E4__this._holdSessionActive = true;
						awaiter3 = global::System.Threading.Tasks.Task.Delay(300, cancellationToken).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter3;
							_003CHandleTaskHoldAsync_003Ed__81 _003CHandleTaskHoldAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleTaskHoldAsync_003Ed__81>(ref awaiter3, ref _003CHandleTaskHoldAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter3)).GetResult();
					if (_003C_003E4__this._holdSessionActive && _003C_003E4__this._currentHoldTask == selectedTask && selectedTask.CanHoldToComplete)
					{
						awaiter2 = _003C_003E4__this.ExecuteHoldToComplete(selectedTask, cancellationToken).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter2;
							_003CHandleTaskHoldAsync_003Ed__81 _003CHandleTaskHoldAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleTaskHoldAsync_003Ed__81>(ref awaiter2, ref _003CHandleTaskHoldAsync_003Ed__);
							return;
						}
						goto IL_01da;
					}
					goto end_IL_00a5;
					IL_01da:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					end_IL_00a5:;
				}
				catch (OperationCanceledException)
				{
					Console.WriteLine("Hold cancelled by user");
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__2 = ex;
					Console.WriteLine("Hold error: " + _003Cex_003E5__2.Message);
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this._holdSessionActive = false;
						_003C_003E4__this._holdSemaphore.Release();
						if (_003C_003E4__this._currentHoldTask == selectedTask)
						{
							_003C_003E4__this._currentHoldTask = null;
							EventHandler? holdShouldStop = _003C_003E4__this.HoldShouldStop;
							if (holdShouldStop != null)
							{
								holdShouldStop.Invoke((object)_003C_003E4__this, EventArgs.Empty);
							}
						}
					}
				}
				end_IL_0007:;
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CLoadDataAsync_003Ed__66 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object param;

		public QuestTaskViewModel _003C_003E4__this;

		private string _003CparamStr_003E5__1;

		private QuestType _003CquestType_003E5__2;

		private string _003CareaId_003E5__3;

		private object _003C_003Es__4;

		private int _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0397: Unknown result type (might be due to invalid IL or missing references)
			//IL_039c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_0191: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02db: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_030f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0314: Unknown result type (might be due to invalid IL or missing references)
			//IL_031c: Unknown result type (might be due to invalid IL or missing references)
			//IL_026e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0273: Unknown result type (might be due to invalid IL or missing references)
			//IL_0288: Unknown result type (might be due to invalid IL or missing references)
			//IL_028a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
				{
					_003C_003E4__this.IsLoading = true;
					if (_003C_003E4__this.Player == null)
					{
						awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "No player data available.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CLoadDataAsync_003Ed__66 _003CLoadDataAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__66>(ref awaiter2, ref _003CLoadDataAsync_003Ed__);
							return;
						}
						goto IL_00bc;
					}
					_003CparamStr_003E5__1 = param?.ToString();
					if (_003CparamStr_003E5__1 == null)
					{
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Invalid navigation parameters").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter;
							_003CLoadDataAsync_003Ed__66 _003CLoadDataAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__66>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
							return;
						}
						goto IL_0163;
					}
					ValueTuple<QuestType, string> val = _003C_003E4__this.ParseNavigationParams(_003CparamStr_003E5__1);
					_003CquestType_003E5__2 = val.Item1;
					_003CareaId_003E5__3 = val.Item2;
					if (_003C_003E4__this._currentAreaId != _003CareaId_003E5__3 || ((object)_003C_003E4__this._currentQuestType).ToString() != ((object)_003CquestType_003E5__2).ToString())
					{
						((Collection<PlayerTaskViewModel>)(object)_003C_003E4__this.PlayerTasks)?.Clear();
						_003C_003E4__this._allPlayerTasks.Clear();
						_003C_003E4__this.CurrentAreaName = "";
					}
					break;
				}
				case 0:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00bc;
				case 1:
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0163;
				case 2:
				case 3:
				case 4:
					break;
					IL_00bc:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					goto end_IL_0007;
					IL_0163:
					((TaskAwaiter)(ref awaiter)).GetResult();
					goto end_IL_0007;
				}
				try
				{
					TaskAwaiter awaiter3;
					if ((uint)(num - 2) > 1u)
					{
						if (num == 4)
						{
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_03ec;
						}
						_003C_003Es__5 = 0;
					}
					try
					{
						TaskAwaiter awaiter4;
						TaskAwaiter awaiter5;
						if (num != 2)
						{
							if (num == 3)
							{
								awaiter4 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_032b;
							}
							awaiter5 = _003C_003E4__this.LoadQuestData(_003CquestType_003E5__2, _003CareaId_003E5__3).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__1 = awaiter5;
								_003CLoadDataAsync_003Ed__66 _003CLoadDataAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__66>(ref awaiter5, ref _003CLoadDataAsync_003Ed__);
								return;
							}
						}
						else
						{
							awaiter5 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
						}
						((TaskAwaiter)(ref awaiter5)).GetResult();
						awaiter4 = _003C_003E4__this.LoadPartnerSpirit().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__1 = awaiter4;
							_003CLoadDataAsync_003Ed__66 _003CLoadDataAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__66>(ref awaiter4, ref _003CLoadDataAsync_003Ed__);
							return;
						}
						goto IL_032b;
						IL_032b:
						((TaskAwaiter)(ref awaiter4)).GetResult();
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__4 = ex;
						_003C_003Es__5 = 1;
					}
					int num2 = _003C_003Es__5;
					if (num2 != 1)
					{
						goto IL_040f;
					}
					_003Cex_003E5__6 = (global::System.Exception)_003C_003Es__4;
					awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to load quest data: " + _003Cex_003E5__6.Message).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__1 = awaiter3;
						_003CLoadDataAsync_003Ed__66 _003CLoadDataAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__66>(ref awaiter3, ref _003CLoadDataAsync_003Ed__);
						return;
					}
					goto IL_03ec;
					IL_03ec:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					Console.WriteLine(_003Cex_003E5__6.StackTrace);
					_003Cex_003E5__6 = null;
					goto IL_040f;
					IL_040f:
					_003C_003Es__4 = null;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsLoading = false;
					}
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CLoadPartnerSpirit_003Ed__69 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public QuestTaskViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private string _003CpartnerSpiritId_003E5__3;

		private SpiritCardModel _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<SpiritCardModel> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01de: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01fa;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter<SpiritCardModel> awaiter2;
					if (num == 0)
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<SpiritCardModel>);
						num = (_003C_003E1__state = -1);
						goto IL_00fa;
					}
					_003CpartnerSpiritId_003E5__3 = _003C_003E4__this._playerInfoModel?.PartnerSpiritId;
					if (!string.IsNullOrEmpty(_003CpartnerSpiritId_003E5__3))
					{
						if (!string.IsNullOrEmpty(_003C_003E4__this._acquiredPartnerSpiritId))
						{
							_003C_003E4__this._spiritCardModelFactory.ReleaseModel(_003C_003E4__this._acquiredPartnerSpiritId);
						}
						awaiter2 = _003C_003E4__this._spiritCardModelFactory.CreateModelAsync(_003CpartnerSpiritId_003E5__3).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CLoadPartnerSpirit_003Ed__69 _003CLoadPartnerSpirit_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<SpiritCardModel>, _003CLoadPartnerSpirit_003Ed__69>(ref awaiter2, ref _003CLoadPartnerSpirit_003Ed__);
							return;
						}
						goto IL_00fa;
					}
					goto end_IL_0022;
					IL_00fa:
					_003C_003Es__4 = awaiter2.GetResult();
					_003C_003E4__this.PartnerSpiritModel = _003C_003Es__4;
					_003C_003Es__4 = null;
					_003C_003E4__this._acquiredPartnerSpiritId = _003CpartnerSpiritId_003E5__3;
					_003CpartnerSpiritId_003E5__3 = null;
					goto IL_014e;
					end_IL_0022:;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
					goto IL_014e;
				}
				goto end_IL_0007;
				IL_014e:
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_020c;
				}
				_003Cex_003E5__5 = (global::System.Exception)_003C_003Es__1;
				Console.WriteLine("Error loading partner spirit: " + _003Cex_003E5__5.Message);
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error loading partner spirit", "Failed to load partner spirit data.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__2 = awaiter;
					_003CLoadPartnerSpirit_003Ed__69 _003CLoadPartnerSpirit_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadPartnerSpirit_003Ed__69>(ref awaiter, ref _003CLoadPartnerSpirit_003Ed__);
					return;
				}
				goto IL_01fa;
				IL_01fa:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__5 = null;
				goto IL_020c;
				IL_020c:
				_003C_003Es__1 = null;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CLoadQuestData_003Ed__68 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public QuestType questType;

		public string areaId;

		public QuestTaskViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00a5;
				}
				_003C_003E4__this.CurrentQuestType = questType;
				if (!string.IsNullOrEmpty(areaId))
				{
					awaiter = _003C_003E4__this.LoadTasksAsync(((object)questType).ToString(), areaId).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CLoadQuestData_003Ed__68 _003CLoadQuestData_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadQuestData_003Ed__68>(ref awaiter, ref _003CLoadQuestData_003Ed__);
						return;
					}
					goto IL_00a5;
				}
				goto end_IL_0007;
				IL_00a5:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CLoadTasksAsync_003Ed__76 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string questType;

		public string areaId;

		public QuestTaskViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private _003C_003Ec__DisplayClass76_0 _003C_003E8__3;

		private GetQuestTasksRequest _003Crequest_003E5__4;

		private Result<GetQuestTasksResult> _003Cresult_003E5__5;

		private Result<GetQuestTasksResult> _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter<Result<GetQuestTasksResult>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0395: Unknown result type (might be due to invalid IL or missing references)
			//IL_039a: Unknown result type (might be due to invalid IL or missing references)
			//IL_03af: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if ((uint)num > 2u)
				{
					if (num == 3)
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_03e7;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter<Result<GetQuestTasksResult>> awaiter4;
					TaskAwaiter awaiter3;
					TaskAwaiter awaiter2;
					Action? tasksLoaded;
					switch (num)
					{
					default:
						_003C_003E8__3 = new _003C_003Ec__DisplayClass76_0();
						_003C_003E8__3._003C_003E4__this = _003C_003E4__this;
						_003Crequest_003E5__4 = new GetQuestTasksRequest(questType, areaId);
						awaiter4 = _003C_003E4__this._getTasksUseCase.ExecuteAsync(_003Crequest_003E5__4).GetAwaiter();
						if (!awaiter4.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter4;
							_003CLoadTasksAsync_003Ed__76 _003CLoadTasksAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<GetQuestTasksResult>>, _003CLoadTasksAsync_003Ed__76>(ref awaiter4, ref _003CLoadTasksAsync_003Ed__);
							return;
						}
						goto IL_00e2;
					case 0:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<GetQuestTasksResult>>);
						num = (_003C_003E1__state = -1);
						goto IL_00e2;
					case 1:
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0196;
					case 2:
						{
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0203;
						}
						IL_0203:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						break;
						IL_00e2:
						_003C_003Es__6 = awaiter4.GetResult();
						_003Cresult_003E5__5 = _003C_003Es__6;
						_003C_003Es__6 = null;
						if (!_003Cresult_003E5__5.Success)
						{
							awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__5.ErrorMessage ?? "Failed to load tasks.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter3;
								_003CLoadTasksAsync_003Ed__76 _003CLoadTasksAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadTasksAsync_003Ed__76>(ref awaiter3, ref _003CLoadTasksAsync_003Ed__);
								return;
							}
							goto IL_0196;
						}
						_003C_003E8__3.data = _003Cresult_003E5__5.Data;
						_003C_003E4__this.CurrentAreaName = _003C_003E8__3.data.AreaName;
						_003C_003E4__this._allPlayerTasks = Enumerable.ToList<PlayerTaskViewModel>(Enumerable.Select<QuestTask, PlayerTaskViewModel>((global::System.Collections.Generic.IEnumerable<QuestTask>)_003C_003E8__3.data.QuestTasks, (Func<QuestTask, PlayerTaskViewModel>)delegate(QuestTask task)
						{
							PlayerQuest? playerQuest = _003C_003E8__3.data.PlayerQuest;
							TaskProgress taskProgress = ((playerQuest != null) ? CollectionExtensions.GetValueOrDefault<string, TaskProgress>((IReadOnlyDictionary<string, TaskProgress>)(object)playerQuest.Tasks, task.Id ?? string.Empty) : null);
							int num3 = taskProgress?.Step ?? 0;
							bool completed = taskProgress?.IsCompleted ?? false;
							bool isVisible = _003C_003E8__3._003C_003E4__this.IsTaskVisible(task, _003C_003E8__3.data.PlayerQuest, _003C_003E8__3.data.QuestTasks);
							Spirit spirit = default(Spirit);
							string opponentImageSource = ((((global::System.Collections.Generic.IReadOnlyCollection<QuestOpponent>)task.QuestOpponents).Count <= 1 || string.IsNullOrEmpty(task.OpponentImage)) ? ((((global::System.Collections.Generic.IReadOnlyCollection<QuestOpponent>)task.QuestOpponents).Count > 0 && _003C_003E8__3._003C_003E4__this._cache.Spirits.TryGetValue(task.QuestOpponents[0].BaseSpiritId, ref spirit)) ? (spirit.Image ?? string.Empty) : string.Empty) : task.OpponentImage);
							return new PlayerTaskViewModel
							{
								Task = task,
								Step = num3,
								Completed = completed,
								IsLocked = false,
								IsVisible = isVisible,
								PlayerEP = (_003C_003E8__3._003C_003E4__this.Player?.EP ?? 0),
								AnimatedProgress = (double)num3 / (double)((task.TotalSteps <= 0) ? 1 : task.TotalSteps),
								OpponentImageSource = opponentImageSource
							};
						}));
						_003C_003E4__this.PlayerTasks = new ObservableCollection<PlayerTaskViewModel>(Enumerable.Where<PlayerTaskViewModel>((global::System.Collections.Generic.IEnumerable<PlayerTaskViewModel>)_003C_003E4__this._allPlayerTasks, (Func<PlayerTaskViewModel, bool>)((PlayerTaskViewModel t) => t.IsVisible)));
						_003C_003E4__this.CompletedTasksCount = Enumerable.Count<PlayerTaskViewModel>((global::System.Collections.Generic.IEnumerable<PlayerTaskViewModel>)_003C_003E4__this.PlayerTasks, (Func<PlayerTaskViewModel, bool>)((PlayerTaskViewModel t) => t.Completed));
						_003C_003E4__this.TotalTasksCount = ((Collection<PlayerTaskViewModel>)(object)_003C_003E4__this.PlayerTasks).Count;
						tasksLoaded = _003C_003E4__this.TasksLoaded;
						if (tasksLoaded != null)
						{
							tasksLoaded.Invoke();
						}
						_003C_003E8__3 = null;
						_003Crequest_003E5__4 = null;
						_003Cresult_003E5__5 = null;
						goto end_IL_0023;
						IL_0196:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						awaiter2 = _003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter2;
							_003CLoadTasksAsync_003Ed__76 _003CLoadTasksAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadTasksAsync_003Ed__76>(ref awaiter2, ref _003CLoadTasksAsync_003Ed__);
							return;
						}
						goto IL_0203;
					}
					goto end_IL_0007;
					end_IL_0023:;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_03f9;
				}
				_003Cex_003E5__7 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error loading tasks", _003Cex_003E5__7.Message).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 3);
					_003C_003Eu__2 = awaiter;
					_003CLoadTasksAsync_003Ed__76 _003CLoadTasksAsync_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadTasksAsync_003Ed__76>(ref awaiter, ref _003CLoadTasksAsync_003Ed__);
					return;
				}
				goto IL_03e7;
				IL_03e7:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__7 = null;
				goto IL_03f9;
				IL_03f9:
				_003C_003Es__1 = null;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CNavigateToChat_003Ed__72 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public QuestTaskViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				TaskAwaiter awaiter2;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_00ed;
					}
					awaiter2 = _003C_003E4__this._navBarViewModel.NavigateToCommand.ExecuteAsync("//chat").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003CNavigateToChat_003Ed__72 _003CNavigateToChat_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToChat_003Ed__72>(ref awaiter2, ref _003CNavigateToChat_003Ed__);
						return;
					}
				}
				else
				{
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TaskAwaiter)(ref awaiter2)).GetResult();
				awaiter = _003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CNavigateToChat_003Ed__72 _003CNavigateToChat_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToChat_003Ed__72>(ref awaiter, ref _003CNavigateToChat_003Ed__);
					return;
				}
				goto IL_00ed;
				IL_00ed:
				((TaskAwaiter)(ref awaiter)).GetResult();
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CNavigateToSpiritDetails_003Ed__74 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string id;

		public QuestTaskViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_015e;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._navigationService.NavigateToAsync(_003C_003E4__this._stateService.CurrentRoute + "/spiritdetails?spiritId=" + id).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CNavigateToSpiritDetails_003Ed__74 _003CNavigateToSpiritDetails_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToSpiritDetails_003Ed__74>(ref awaiter2, ref _003CNavigateToSpiritDetails_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter2)).GetResult();
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_0170;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error navigating to spiritpage", _003Cex_003E5__3.Message).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CNavigateToSpiritDetails_003Ed__74 _003CNavigateToSpiritDetails_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToSpiritDetails_003Ed__74>(ref awaiter, ref _003CNavigateToSpiritDetails_003Ed__);
					return;
				}
				goto IL_015e;
				IL_015e:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__3 = null;
				goto IL_0170;
				IL_0170:
				_003C_003Es__1 = null;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003COnStateChanged_003Ed__60 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public StateChangedEventArgs e;

		public QuestTaskViewModel _003C_003E4__this;

		private StateChangeScope _003C_003Es__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00c9;
				}
				TaskAwaiter awaiter2;
				if (num == 1)
				{
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_014c;
				}
				StateChangeScope scope = e.Scope;
				_003C_003Es__1 = scope;
				StateChangeScope stateChangeScope = _003C_003Es__1;
				if (stateChangeScope != 0)
				{
					if (stateChangeScope == StateChangeScope.Quest)
					{
						awaiter2 = _003C_003E4__this.HandleQuestStateChangeAsync(e).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter2;
							_003COnStateChanged_003Ed__60 _003COnStateChanged_003Ed__ = this;
							((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnStateChanged_003Ed__60>(ref awaiter2, ref _003COnStateChanged_003Ed__);
							return;
						}
						goto IL_014c;
					}
				}
				else
				{
					if (e.ChangeType == "Quests")
					{
						awaiter = _003C_003E4__this.HandleQuestStateChangeAsync(e).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003COnStateChanged_003Ed__60 _003COnStateChanged_003Ed__ = this;
							((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COnStateChanged_003Ed__60>(ref awaiter, ref _003COnStateChanged_003Ed__);
							return;
						}
						goto IL_00c9;
					}
					_003C_003E4__this.HandlePlayerStateChange(e);
				}
				goto end_IL_0007;
				IL_00c9:
				((TaskAwaiter)(ref awaiter)).GetResult();
				goto end_IL_0007;
				IL_014c:
				((TaskAwaiter)(ref awaiter2)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003COpenSpiritsHoldNavigation_003Ed__88 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public QuestTaskViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private BottomSheet _003Csheet_003E5__3;

		private BottomSheet _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<BottomSheet> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if ((uint)num > 1u)
				{
					if (num == 2)
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01da;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					TaskAwaiter<BottomSheet> awaiter3;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0125;
						}
						awaiter3 = _003C_003E4__this._navigationService.GetFullSheet<SpiritHoldNavigationSheet, SpiritsHoldNavigationSheetViewModel>("spiritholdnav").GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003COpenSpiritsHoldNavigation_003Ed__88 _003COpenSpiritsHoldNavigation_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<BottomSheet>, _003COpenSpiritsHoldNavigation_003Ed__88>(ref awaiter3, ref _003COpenSpiritsHoldNavigation_003Ed__);
							return;
						}
					}
					else
					{
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<BottomSheet>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__4 = awaiter3.GetResult();
					_003Csheet_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					awaiter2 = _003C_003E4__this._bottomSheetService.ShowSheetAsync(_003Csheet_003E5__3).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter2;
						_003COpenSpiritsHoldNavigation_003Ed__88 _003COpenSpiritsHoldNavigation_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenSpiritsHoldNavigation_003Ed__88>(ref awaiter2, ref _003COpenSpiritsHoldNavigation_003Ed__);
						return;
					}
					goto IL_0125;
					IL_0125:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					_003Csheet_003E5__3 = null;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_01fd;
				}
				_003Cex_003E5__5 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Navigation Error", "Failed to navigate to opponent profile.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 2);
					_003C_003Eu__2 = awaiter;
					_003COpenSpiritsHoldNavigation_003Ed__88 _003COpenSpiritsHoldNavigation_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenSpiritsHoldNavigation_003Ed__88>(ref awaiter, ref _003COpenSpiritsHoldNavigation_003Ed__);
					return;
				}
				goto IL_01da;
				IL_01da:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine(_003Cex_003E5__5.Message);
				_003Cex_003E5__5 = null;
				goto IL_01fd;
				IL_01fd:
				_003C_003Es__1 = null;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSelectTask_003Ed__79 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PlayerTaskViewModel selectedTask;

		public QuestTaskViewModel _003C_003E4__this;

		private bool _003C_003Es__1;

		private object _003C_003Es__2;

		private int _003C_003Es__3;

		private ExecuteQuestTaskRequest _003Crequest_003E5__4;

		private Result<ExecuteQuestTaskResult> _003Cresult_003E5__5;

		private Result<ExecuteQuestTaskResult> _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private TaskAwaiter<Result<ExecuteQuestTaskResult>> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_043f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0444: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0459: Unknown result type (might be due to invalid IL or missing references)
			//IL_045b: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_0479: Unknown result type (might be due to invalid IL or missing references)
			//IL_047e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0486: Unknown result type (might be due to invalid IL or missing references)
			//IL_0225: Unknown result type (might be due to invalid IL or missing references)
			//IL_022a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0232: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_036b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0370: Unknown result type (might be due to invalid IL or missing references)
			//IL_0385: Unknown result type (might be due to invalid IL or missing references)
			//IL_0387: Unknown result type (might be due to invalid IL or missing references)
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0205: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<bool> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_00c3;
				}
				if ((uint)(num - 1) <= 3u)
				{
					goto IL_00ef;
				}
				TimeSpan val = global::System.DateTime.UtcNow - _003C_003E4__this._lastHoldCompletionTime;
				if (!(((TimeSpan)(ref val)).TotalMilliseconds < 300.0))
				{
					awaiter = _003C_003E4__this._taskExecutionSemaphore.WaitAsync(0).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CSelectTask_003Ed__79 _003CSelectTask_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CSelectTask_003Ed__79>(ref awaiter, ref _003CSelectTask_003Ed__);
						return;
					}
					goto IL_00c3;
				}
				Console.WriteLine("Suppressed tap due to recent hold completion");
				goto end_IL_0007;
				IL_00ef:
				try
				{
					TaskAwaiter awaiter2;
					if ((uint)(num - 1) > 2u)
					{
						if (num == 4)
						{
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0495;
						}
						_003C_003Es__3 = 0;
					}
					try
					{
						TaskAwaiter awaiter5;
						TaskAwaiter<Result<ExecuteQuestTaskResult>> awaiter4;
						TaskAwaiter awaiter3;
						switch (num)
						{
						default:
							if (selectedTask.Task != null)
							{
								if (selectedTask.IsShowingCompletionEffects || selectedTask.IsPendingExecution)
								{
									_003C_003E4__this.StopTaskHold();
								}
								else
								{
									if (selectedTask.Step < selectedTask.Task.TotalSteps)
									{
										selectedTask.IsPendingExecution = true;
										if (selectedTask.Task.Battle)
										{
											awaiter5 = _003C_003E4__this.ExecuteBattleTask(selectedTask).GetAwaiter();
											if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
											{
												num = (_003C_003E1__state = 1);
												_003C_003Eu__2 = awaiter5;
												_003CSelectTask_003Ed__79 _003CSelectTask_003Ed__ = this;
												((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSelectTask_003Ed__79>(ref awaiter5, ref _003CSelectTask_003Ed__);
												return;
											}
											goto IL_0241;
										}
										_003Crequest_003E5__4 = new ExecuteQuestTaskRequest(selectedTask.Task.Id, _003C_003E4__this._currentQuestId ?? string.Empty, _003C_003E4__this._currentAreaId ?? string.Empty);
										awaiter4 = _003C_003E4__this._executeTaskUseCase.ExecuteAsync(_003Crequest_003E5__4).GetAwaiter();
										if (!awaiter4.IsCompleted)
										{
											num = (_003C_003E1__state = 2);
											_003C_003Eu__3 = awaiter4;
											_003CSelectTask_003Ed__79 _003CSelectTask_003Ed__ = this;
											((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<ExecuteQuestTaskResult>>, _003CSelectTask_003Ed__79>(ref awaiter4, ref _003CSelectTask_003Ed__);
											return;
										}
										goto IL_02fd;
									}
									_003C_003E4__this.StopTaskHold();
								}
							}
							goto end_IL_010c;
						case 1:
							awaiter5 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0241;
						case 2:
							awaiter4 = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<Result<ExecuteQuestTaskResult>>);
							num = (_003C_003E1__state = -1);
							goto IL_02fd;
						case 3:
							{
								awaiter3 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_03c1;
							}
							IL_0241:
							((TaskAwaiter)(ref awaiter5)).GetResult();
							goto end_IL_010c;
							IL_03c1:
							((TaskAwaiter)(ref awaiter3)).GetResult();
							break;
							IL_02fd:
							_003C_003Es__6 = awaiter4.GetResult();
							_003Cresult_003E5__5 = _003C_003Es__6;
							_003C_003Es__6 = null;
							if (_003Cresult_003E5__5.Success)
							{
								break;
							}
							selectedTask.IsPendingExecution = false;
							awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__5.ErrorMessage ?? "Failed to execute task.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__2 = awaiter3;
								_003CSelectTask_003Ed__79 _003CSelectTask_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSelectTask_003Ed__79>(ref awaiter3, ref _003CSelectTask_003Ed__);
								return;
							}
							goto IL_03c1;
						}
						_003Crequest_003E5__4 = null;
						_003Cresult_003E5__5 = null;
						goto IL_03ee;
						end_IL_010c:;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__2 = ex;
						_003C_003Es__3 = 1;
						goto IL_03ee;
					}
					goto end_IL_00ef;
					IL_03ee:
					int num2 = _003C_003Es__3;
					if (num2 != 1)
					{
						goto IL_04a7;
					}
					_003Cex_003E5__7 = (global::System.Exception)_003C_003Es__2;
					selectedTask.IsPendingExecution = false;
					awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Task progress error!", _003Cex_003E5__7.Message).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__2 = awaiter2;
						_003CSelectTask_003Ed__79 _003CSelectTask_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSelectTask_003Ed__79>(ref awaiter2, ref _003CSelectTask_003Ed__);
						return;
					}
					goto IL_0495;
					IL_0495:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					_003Cex_003E5__7 = null;
					goto IL_04a7;
					IL_04a7:
					_003C_003Es__2 = null;
					end_IL_00ef:;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this._taskExecutionSemaphore.Release();
					}
				}
				goto end_IL_0007;
				IL_00c3:
				_003C_003Es__1 = awaiter.GetResult();
				if (_003C_003Es__1)
				{
					goto IL_00ef;
				}
				Console.WriteLine("Task execution already in progress, ignoring tap");
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CShowCompletionPopup_003Ed__86 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public long gold;

		public double experience;

		public QuestTaskViewModel _003C_003E4__this;

		private _003C_003Ec__DisplayClass86_0 _003C_003E8__1;

		private object _003C_003Es__2;

		private int _003C_003Es__3;

		private object _003Cresult_003E5__4;

		private bool _003CboolResult_003E5__5;

		private object _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter<object?> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01cd;
					}
					_003C_003E8__1 = new _003C_003Ec__DisplayClass86_0();
					_003C_003E8__1.gold = gold;
					_003C_003E8__1.experience = experience;
					_003C_003Es__3 = 0;
				}
				try
				{
					TaskAwaiter<object> awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._popupService.ShowPopupAsync<QuestRewardsPopupViewModel>((Action<QuestRewardsPopupViewModel>)delegate(QuestRewardsPopupViewModel vm)
						{
							vm.CompletedText = "Quest Progressed";
							vm.CompletedText2 = "You've obtained these rewards:";
							vm.EarnedGold = _003C_003E8__1.gold.ToString();
							vm.EarnedEXP = _003C_003E8__1.experience.ToString();
							vm.IsItem = false;
						}, default(CancellationToken)).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CShowCompletionPopup_003Ed__86 _003CShowCompletionPopup_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CShowCompletionPopup_003Ed__86>(ref awaiter2, ref _003CShowCompletionPopup_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<object>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__6 = awaiter2.GetResult();
					_003Cresult_003E5__4 = _003C_003Es__6;
					_003C_003Es__6 = null;
					int num2;
					if (_003Cresult_003E5__4 is bool)
					{
						_003CboolResult_003E5__5 = (bool)_003Cresult_003E5__4;
						num2 = 1;
					}
					else
					{
						num2 = 0;
					}
					result = (byte)((uint)num2 & (_003CboolResult_003E5__5 ? 1u : 0u)) != 0;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__2 = ex;
					_003C_003Es__3 = 1;
					goto IL_0136;
				}
				goto end_IL_0007;
				IL_0136:
				int num3 = _003C_003Es__3;
				if (num3 == 1)
				{
					_003Cex_003E5__7 = (global::System.Exception)_003C_003Es__2;
					awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error showing popup", _003Cex_003E5__7.Message).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter;
						_003CShowCompletionPopup_003Ed__86 _003CShowCompletionPopup_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CShowCompletionPopup_003Ed__86>(ref awaiter, ref _003CShowCompletionPopup_003Ed__);
						return;
					}
					goto IL_01cd;
				}
				_003C_003Es__2 = null;
				throw null;
				IL_01cd:
				((TaskAwaiter)(ref awaiter)).GetResult();
				result = false;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CShowItemDropPopup_003Ed__87 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string spiritName;

		public int orbPlayerCount;

		public QuestTaskViewModel _003C_003E4__this;

		private _003C_003Ec__DisplayClass87_0 _003C_003E8__1;

		private object _003C_003Es__2;

		private int _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<object?> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_018d;
					}
					_003C_003E8__1 = new _003C_003Ec__DisplayClass87_0();
					_003C_003E8__1.spiritName = spiritName;
					_003C_003E8__1.orbPlayerCount = orbPlayerCount;
					_003C_003Es__3 = 0;
				}
				try
				{
					TaskAwaiter<object> awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._popupService.ShowPopupAsync<SpiritOrbDropPopupViewModel>((Action<SpiritOrbDropPopupViewModel>)delegate(SpiritOrbDropPopupViewModel vm)
						{
							vm.CompletedText = _003C_003E8__1.spiritName + " dropped a Core Orb!";
							vm.CompletedText2 = "Core Orbs can be used in shop to collect new spirits to your collection";
							vm.OrbCount = 1;
							vm.OrbCountText = "x1";
							vm.OrbPlayerCount = _003C_003E8__1.orbPlayerCount;
						}, default(CancellationToken)).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CShowItemDropPopup_003Ed__87 _003CShowItemDropPopup_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CShowItemDropPopup_003Ed__87>(ref awaiter2, ref _003CShowItemDropPopup_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<object>);
						num = (_003C_003E1__state = -1);
					}
					awaiter2.GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__2 = ex;
					_003C_003Es__3 = 1;
					goto IL_00f6;
				}
				goto end_IL_0007;
				IL_00f6:
				int num2 = _003C_003Es__3;
				if (num2 == 1)
				{
					_003Cex_003E5__4 = (global::System.Exception)_003C_003Es__2;
					awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error showing popup", _003Cex_003E5__4.Message).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter;
						_003CShowItemDropPopup_003Ed__87 _003CShowItemDropPopup_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CShowItemDropPopup_003Ed__87>(ref awaiter, ref _003CShowItemDropPopup_003Ed__);
						return;
					}
					goto IL_018d;
				}
				_003C_003Es__2 = null;
				throw null;
				IL_018d:
				((TaskAwaiter)(ref awaiter)).GetResult();
				result = false;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly INavigationService _navigationService;

	private readonly IPlayerStateService _stateService;

	private readonly IPopupService _popupService;

	private readonly PlayerInfoModel _playerInfoModel;

	private readonly ExecuteQuestTaskUseCase _executeTaskUseCase;

	private readonly ExecuteQuestBattleUseCase _executeBattleUseCase;

	private readonly PreCommitQuestBattleUseCase _preCommitQuestBattleUseCase;

	private readonly GetQuestTasksForAreaUseCase _getTasksUseCase;

	private readonly ResetRepeatableTaskUseCase _resetRepeatableTaskUseCase;

	private readonly ExecuteQuestTaskHoldUseCase _executeTaskHoldUseCase;

	private readonly QuestParagraphService _questParagraphService;

	private readonly IChatUnreadService _chatUnreadService;

	private readonly NavBarViewModel _navBarViewModel;

	private readonly IStaticDataCacheService _cache;

	private readonly IBottomSheetService _bottomSheetService;

	private readonly SpiritCardModelFactory _spiritCardModelFactory;

	private bool _disposed = false;

	private CancellationTokenSource? _holdTaskCts;

	private PlayerTaskViewModel? _currentHoldTask;

	private List<PlayerTaskViewModel> _allPlayerTasks = new List<PlayerTaskViewModel>();

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private EventHandler? m_HoldShouldStop;

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private Action? m_TasksLoaded;

	private readonly SemaphoreSlim _holdSemaphore = new SemaphoreSlim(1, 1);

	private readonly SemaphoreSlim _taskExecutionSemaphore = new SemaphoreSlim(1, 1);

	private readonly SemaphoreSlim _stateChangeSemaphore = new SemaphoreSlim(1, 1);

	private bool _holdSessionActive = false;

	private string? _currentAreaId;

	private string? _currentQuestId;

	private string? _acquiredPartnerSpiritId;

	[ObservableProperty]
	private string? _currentAreaName;

	[ObservableProperty]
	private string _debugInfo = "";

	[ObservableProperty]
	private TouchState _currentTouchState = (TouchState)0;

	[ObservableProperty]
	private QuestType _currentQuestType = QuestType.story;

	[ObservableProperty]
	private ObservableCollection<PlayerTaskViewModel>? _playerTasks;

	[ObservableProperty]
	private bool _hasUnreadMessages;

	[ObservableProperty]
	private int _unreadMessageCount;

	[ObservableProperty]
	private bool _isLoading = true;

	[ObservableProperty]
	[NotifyPropertyChangedFor("HasTasks")]
	[NotifyPropertyChangedFor("TasksCompletionSummary")]
	private int _completedTasksCount;

	[ObservableProperty]
	[NotifyPropertyChangedFor("HasTasks")]
	[NotifyPropertyChangedFor("TasksCompletionSummary")]
	private int _totalTasksCount;

	[ObservableProperty]
	private SpiritCardModel? _partnerSpiritModel;

	private global::System.DateTime _lastHoldCompletionTime = global::System.DateTime.MinValue;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<object?>? loadDataCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goToPortalCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goBackCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? navigateToChatCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<string>? navigateToSpiritDetailsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goToFullCollectionCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<PlayerTaskViewModel>? selectTaskCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? openSpiritsHoldNavigationCommand;

	public bool HasTasks
	{
		get
		{
			ObservableCollection<PlayerTaskViewModel>? playerTasks = PlayerTasks;
			return playerTasks != null && Enumerable.Any<PlayerTaskViewModel>((global::System.Collections.Generic.IEnumerable<PlayerTaskViewModel>)playerTasks);
		}
	}

	public string TasksCompletionSummary => $"{CompletedTasksCount}/{TotalTasksCount} completed";

	private Player? Player => _stateService.GetCurrentPlayer();

	private PlayerQuest? CurrentPlayerQuests
	{
		get
		{
			Player? player = Player;
			object result;
			if (player == null)
			{
				result = null;
			}
			else
			{
				IReadOnlyDictionary<string, PlayerQuest> playerQuests = player.PlayerQuests;
				result = ((playerQuests != null) ? CollectionExtensions.GetValueOrDefault<string, PlayerQuest>(playerQuests, ((object)CurrentQuestType).ToString()) : null);
			}
			return (PlayerQuest?)result;
		}
	}

	public PlayerInfoModel PlayerInfoModel => _playerInfoModel;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Command OpenPortalCommand
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		internal set;
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? CurrentAreaName
	{
		get
		{
			return _currentAreaName;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_currentAreaName, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentAreaName);
				_currentAreaName = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentAreaName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string DebugInfo
	{
		get
		{
			return _debugInfo;
		}
		[MemberNotNull("_debugInfo")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_debugInfo, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.DebugInfo);
				_debugInfo = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.DebugInfo);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public TouchState CurrentTouchState
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _currentTouchState;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			if (!EqualityComparer<TouchState>.Default.Equals(_currentTouchState, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentTouchState);
				_currentTouchState = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentTouchState);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public QuestType CurrentQuestType
	{
		get
		{
			return _currentQuestType;
		}
		set
		{
			if (!EqualityComparer<QuestType>.Default.Equals(_currentQuestType, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentQuestType);
				_currentQuestType = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentQuestType);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<PlayerTaskViewModel>? PlayerTasks
	{
		get
		{
			return _playerTasks;
		}
		set
		{
			if (!EqualityComparer<ObservableCollection<PlayerTaskViewModel>>.Default.Equals(_playerTasks, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PlayerTasks);
				_playerTasks = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PlayerTasks);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool HasUnreadMessages
	{
		get
		{
			return _hasUnreadMessages;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasUnreadMessages, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasUnreadMessages);
				_hasUnreadMessages = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasUnreadMessages);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int UnreadMessageCount
	{
		get
		{
			return _unreadMessageCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_unreadMessageCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.UnreadMessageCount);
				_unreadMessageCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.UnreadMessageCount);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsLoading
	{
		get
		{
			return _isLoading;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isLoading, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsLoading);
				_isLoading = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsLoading);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int CompletedTasksCount
	{
		get
		{
			return _completedTasksCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_completedTasksCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CompletedTasksCount);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasTasks);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TasksCompletionSummary);
				_completedTasksCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CompletedTasksCount);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasTasks);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TasksCompletionSummary);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int TotalTasksCount
	{
		get
		{
			return _totalTasksCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_totalTasksCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TotalTasksCount);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasTasks);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TasksCompletionSummary);
				_totalTasksCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TotalTasksCount);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasTasks);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TasksCompletionSummary);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public SpiritCardModel? PartnerSpiritModel
	{
		get
		{
			return _partnerSpiritModel;
		}
		set
		{
			if (!EqualityComparer<SpiritCardModel>.Default.Equals(_partnerSpiritModel, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PartnerSpiritModel);
				_partnerSpiritModel = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PartnerSpiritModel);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<object?> LoadDataCommand
	{
		get
		{
			AsyncRelayCommand<object?>? obj = loadDataCommand;
			if (obj == null)
			{
				obj = (loadDataCommand = new AsyncRelayCommand<object>((Func<object, global::System.Threading.Tasks.Task>)LoadDataAsync));
			}
			return (IAsyncRelayCommand<object?>)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand GoToPortalCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = goToPortalCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)GoToPortal);
				AsyncRelayCommand val2 = val;
				goToPortalCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand GoBackCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = goBackCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)GoBack);
				AsyncRelayCommand val2 = val;
				goBackCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand NavigateToChatCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = navigateToChatCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)NavigateToChat);
				AsyncRelayCommand val2 = val;
				navigateToChatCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<string> NavigateToSpiritDetailsCommand => (IAsyncRelayCommand<string>)(object)(navigateToSpiritDetailsCommand ?? (navigateToSpiritDetailsCommand = new AsyncRelayCommand<string>((Func<string, global::System.Threading.Tasks.Task>)NavigateToSpiritDetails)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand GoToFullCollectionCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = goToFullCollectionCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)GoToFullCollection);
				AsyncRelayCommand val2 = val;
				goToFullCollectionCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<PlayerTaskViewModel> SelectTaskCommand => (IAsyncRelayCommand<PlayerTaskViewModel>)(object)(selectTaskCommand ?? (selectTaskCommand = new AsyncRelayCommand<PlayerTaskViewModel>((Func<PlayerTaskViewModel, global::System.Threading.Tasks.Task>)SelectTask)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand OpenSpiritsHoldNavigationCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = openSpiritsHoldNavigationCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)OpenSpiritsHoldNavigation);
				AsyncRelayCommand val2 = val;
				openSpiritsHoldNavigationCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public event EventHandler HoldShouldStop
	{
		[CompilerGenerated]
		add
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			EventHandler val = this.m_HoldShouldStop;
			EventHandler val2;
			do
			{
				val2 = val;
				EventHandler val3 = (EventHandler)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler>(ref this.m_HoldShouldStop, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			EventHandler val = this.m_HoldShouldStop;
			EventHandler val2;
			do
			{
				val2 = val;
				EventHandler val3 = (EventHandler)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler>(ref this.m_HoldShouldStop, val3, val2);
			}
			while (val != val2);
		}
	}

	public event Action TasksLoaded
	{
		[CompilerGenerated]
		add
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			Action val = this.m_TasksLoaded;
			Action val2;
			do
			{
				val2 = val;
				Action val3 = (Action)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<Action>(ref this.m_TasksLoaded, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			Action val = this.m_TasksLoaded;
			Action val2;
			do
			{
				val2 = val;
				Action val3 = (Action)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<Action>(ref this.m_TasksLoaded, val3, val2);
			}
			while (val != val2);
		}
	}

	public QuestTaskViewModel(INavigationService navigationService, IPlayerStateService stateService, IPopupService popupService, PlayerInfoModel playerInfoModel, ExecuteQuestTaskUseCase executeTaskUseCase, ExecuteQuestBattleUseCase executeBattleUseCase, PreCommitQuestBattleUseCase preCommitQuestBattleUseCase, GetQuestTasksForAreaUseCase getTasksUseCase, ResetRepeatableTaskUseCase resetRepeatableTaskUseCase, ExecuteQuestTaskHoldUseCase executeTaskHoldUseCase, QuestParagraphService questParagraphService, IChatUnreadService chatUnreadService, NavBarViewModel navBarViewModel, IStaticDataCacheService cache, SpiritCardModelFactory spiritCardModelFactory, IBottomSheetService bottomSheetService)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		_navigationService = navigationService;
		_stateService = stateService;
		_popupService = popupService;
		_playerInfoModel = playerInfoModel;
		_executeTaskUseCase = executeTaskUseCase;
		_executeBattleUseCase = executeBattleUseCase;
		_preCommitQuestBattleUseCase = preCommitQuestBattleUseCase;
		_getTasksUseCase = getTasksUseCase;
		_resetRepeatableTaskUseCase = resetRepeatableTaskUseCase;
		_executeTaskHoldUseCase = executeTaskHoldUseCase;
		_questParagraphService = questParagraphService;
		_chatUnreadService = chatUnreadService;
		_navBarViewModel = navBarViewModel;
		_cache = cache;
		_bottomSheetService = bottomSheetService;
		_spiritCardModelFactory = spiritCardModelFactory;
		_stateService.StateChanged += OnStateChanged;
		_chatUnreadService.UnreadCountChanged += new EventHandler(OnUnreadCountChanged);
		HasUnreadMessages = _chatUnreadService.HasUnread;
		UnreadMessageCount = _chatUnreadService.TotalUnreadCount;
	}

	[AsyncStateMachine(typeof(_003COnStateChanged_003Ed__60))]
	[DebuggerStepThrough]
	private void OnStateChanged(object? sender, StateChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COnStateChanged_003Ed__60 _003COnStateChanged_003Ed__ = new _003COnStateChanged_003Ed__60();
		_003COnStateChanged_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003COnStateChanged_003Ed__._003C_003E4__this = this;
		_003COnStateChanged_003Ed__.sender = sender;
		_003COnStateChanged_003Ed__.e = e;
		_003COnStateChanged_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003COnStateChanged_003Ed__._003C_003Et__builder)).Start<_003COnStateChanged_003Ed__60>(ref _003COnStateChanged_003Ed__);
	}

	private void HandlePlayerStateChange(StateChangedEventArgs e)
	{
		string changeType = e.ChangeType;
		if (changeType == "Energy")
		{
			if (PlayerTasks != null && Player != null)
			{
				UpdateTasksEnergyDisplay(Player.EP);
			}
			((ObservableObject)this).OnPropertyChanged("Player");
		}
		else if (changeType == "Experience" || changeType == "Currencies")
		{
			((ObservableObject)this).OnPropertyChanged("Player");
		}
		else if (changeType == "Partner")
		{
			((ObservableObject)this).OnPropertyChanged("PartnerSpiritModel");
		}
	}

	[AsyncStateMachine(typeof(_003CHandleQuestStateChangeAsync_003Ed__62))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task HandleQuestStateChangeAsync(StateChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CHandleQuestStateChangeAsync_003Ed__62 _003CHandleQuestStateChangeAsync_003Ed__ = new _003CHandleQuestStateChangeAsync_003Ed__62();
		_003CHandleQuestStateChangeAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CHandleQuestStateChangeAsync_003Ed__._003C_003E4__this = this;
		_003CHandleQuestStateChangeAsync_003Ed__.e = e;
		_003CHandleQuestStateChangeAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CHandleQuestStateChangeAsync_003Ed__._003C_003Et__builder)).Start<_003CHandleQuestStateChangeAsync_003Ed__62>(ref _003CHandleQuestStateChangeAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CHandleQuestStateChangeAsync_003Ed__._003C_003Et__builder)).Task;
	}

	private void UpdateTasksEnergyDisplay(int newEP)
	{
		if (PlayerTasks == null)
		{
			return;
		}
		global::System.Collections.Generic.IEnumerator<PlayerTaskViewModel> enumerator = ((Collection<PlayerTaskViewModel>)(object)PlayerTasks).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				PlayerTaskViewModel current = enumerator.Current;
				current.PlayerEP = newEP;
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
	}

	private void ReconcileVisibility()
	{
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		if (PlayerTasks == null)
		{
			return;
		}
		PlayerQuest currentPlayerQuests = CurrentPlayerQuests;
		Dictionary<string, TaskProgress> currentTasksDict = currentPlayerQuests?.Tasks;
		List<QuestTask> allTasks = Enumerable.ToList<QuestTask>(Enumerable.Where<QuestTask>(Enumerable.Select<PlayerTaskViewModel, QuestTask>((global::System.Collections.Generic.IEnumerable<PlayerTaskViewModel>)_allPlayerTasks, (Func<PlayerTaskViewModel, QuestTask>)((PlayerTaskViewModel t) => t.Task)), (Func<QuestTask, bool>)((QuestTask t) => t != null)));
		Enumerator<PlayerTaskViewModel> enumerator = _allPlayerTasks.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				PlayerTaskViewModel current = enumerator.Current;
				if (current.Task == null)
				{
					continue;
				}
				bool flag = IsTaskVisible(current.Task, currentPlayerQuests, allTasks);
				bool flag2 = ((Collection<PlayerTaskViewModel>)(object)PlayerTasks).Contains(current);
				if (flag && !flag2)
				{
					SyncDependentStateOnInsert(current, currentTasksDict);
					int idx = _allPlayerTasks.IndexOf(current);
					int num = Enumerable.Count<PlayerTaskViewModel>((global::System.Collections.Generic.IEnumerable<PlayerTaskViewModel>)PlayerTasks, (Func<PlayerTaskViewModel, bool>)((PlayerTaskViewModel p) => _allPlayerTasks.IndexOf(p) < idx));
					((Collection<PlayerTaskViewModel>)(object)PlayerTasks).Insert(num, current);
				}
				else if (!flag && flag2 && current != _currentHoldTask && !current.IsShowingCompletionEffects)
				{
					((Collection<PlayerTaskViewModel>)(object)PlayerTasks).Remove(current);
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator).Dispose();
		}
		CompletedTasksCount = Enumerable.Count<PlayerTaskViewModel>((global::System.Collections.Generic.IEnumerable<PlayerTaskViewModel>)PlayerTasks, (Func<PlayerTaskViewModel, bool>)((PlayerTaskViewModel t) => t.Completed));
		TotalTasksCount = ((Collection<PlayerTaskViewModel>)(object)PlayerTasks).Count;
		Action? tasksLoaded = this.TasksLoaded;
		if (tasksLoaded != null)
		{
			tasksLoaded.Invoke();
		}
	}

	private static void SyncDependentStateOnInsert(PlayerTaskViewModel dep, Dictionary<string, TaskProgress>? currentTasksDict)
	{
		string text = dep.Task?.Id ?? string.Empty;
		TaskProgress taskProgress = ((currentTasksDict != null) ? CollectionExtensions.GetValueOrDefault<string, TaskProgress>((IReadOnlyDictionary<string, TaskProgress>)(object)currentTasksDict, text) : null);
		int num = taskProgress?.Step ?? 0;
		bool flag = taskProgress?.IsCompleted ?? false;
		if (dep.Completed != flag || dep.Step != num)
		{
			Console.WriteLine($"[ChainInsert] Stale VM state for task '{text}'. VM(Step={dep.Step}, Completed={dep.Completed}) Dict(Step={num}, Completed={flag}, HasEntry={taskProgress != null}). Resyncing.");
		}
		dep.IsLocked = false;
		dep.Step = num;
		dep.Completed = flag;
		dep.AnimatedProgress = ((dep.Task != null && dep.Task.TotalSteps > 0) ? ((double)num / (double)dep.Task.TotalSteps) : 0.0);
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__66))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? param)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__66 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__66();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.param = param;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__66>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	private ValueTuple<QuestType, string> ParseNavigationParams(string paramStr)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		string[] array = paramStr.Split('/', (StringSplitOptions)0);
		string text = Enumerable.FirstOrDefault<string>((global::System.Collections.Generic.IEnumerable<string>)array);
		QuestType questType = default(QuestType);
		QuestType questType2 = (global::System.Enum.TryParse<QuestType>(text, ref questType) ? questType : QuestType.story);
		string text2 = (_currentAreaId = ((array.Length > 1) ? array[1] : string.Empty));
		_currentQuestId = ((object)questType2).ToString();
		return new ValueTuple<QuestType, string>(questType2, text2);
	}

	[AsyncStateMachine(typeof(_003CLoadQuestData_003Ed__68))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadQuestData(QuestType questType, string areaId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadQuestData_003Ed__68 _003CLoadQuestData_003Ed__ = new _003CLoadQuestData_003Ed__68();
		_003CLoadQuestData_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadQuestData_003Ed__._003C_003E4__this = this;
		_003CLoadQuestData_003Ed__.questType = questType;
		_003CLoadQuestData_003Ed__.areaId = areaId;
		_003CLoadQuestData_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadQuestData_003Ed__._003C_003Et__builder)).Start<_003CLoadQuestData_003Ed__68>(ref _003CLoadQuestData_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadQuestData_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadPartnerSpirit_003Ed__69))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadPartnerSpirit()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadPartnerSpirit_003Ed__69 _003CLoadPartnerSpirit_003Ed__ = new _003CLoadPartnerSpirit_003Ed__69();
		_003CLoadPartnerSpirit_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadPartnerSpirit_003Ed__._003C_003E4__this = this;
		_003CLoadPartnerSpirit_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadPartnerSpirit_003Ed__._003C_003Et__builder)).Start<_003CLoadPartnerSpirit_003Ed__69>(ref _003CLoadPartnerSpirit_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadPartnerSpirit_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGoToPortal_003Ed__70))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoToPortal()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoToPortal_003Ed__70 _003CGoToPortal_003Ed__ = new _003CGoToPortal_003Ed__70();
		_003CGoToPortal_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoToPortal_003Ed__._003C_003E4__this = this;
		_003CGoToPortal_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoToPortal_003Ed__._003C_003Et__builder)).Start<_003CGoToPortal_003Ed__70>(ref _003CGoToPortal_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoToPortal_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGoBack_003Ed__71))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoBack()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoBack_003Ed__71 _003CGoBack_003Ed__ = new _003CGoBack_003Ed__71();
		_003CGoBack_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoBack_003Ed__._003C_003E4__this = this;
		_003CGoBack_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Start<_003CGoBack_003Ed__71>(ref _003CGoBack_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CNavigateToChat_003Ed__72))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task NavigateToChat()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CNavigateToChat_003Ed__72 _003CNavigateToChat_003Ed__ = new _003CNavigateToChat_003Ed__72();
		_003CNavigateToChat_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CNavigateToChat_003Ed__._003C_003E4__this = this;
		_003CNavigateToChat_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CNavigateToChat_003Ed__._003C_003Et__builder)).Start<_003CNavigateToChat_003Ed__72>(ref _003CNavigateToChat_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CNavigateToChat_003Ed__._003C_003Et__builder)).Task;
	}

	private void OnUnreadCountChanged(object? sender, EventArgs e)
	{
		HasUnreadMessages = _chatUnreadService.HasUnread;
		UnreadMessageCount = _chatUnreadService.TotalUnreadCount;
	}

	[AsyncStateMachine(typeof(_003CNavigateToSpiritDetails_003Ed__74))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task NavigateToSpiritDetails(string id)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CNavigateToSpiritDetails_003Ed__74 _003CNavigateToSpiritDetails_003Ed__ = new _003CNavigateToSpiritDetails_003Ed__74();
		_003CNavigateToSpiritDetails_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CNavigateToSpiritDetails_003Ed__._003C_003E4__this = this;
		_003CNavigateToSpiritDetails_003Ed__.id = id;
		_003CNavigateToSpiritDetails_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CNavigateToSpiritDetails_003Ed__._003C_003Et__builder)).Start<_003CNavigateToSpiritDetails_003Ed__74>(ref _003CNavigateToSpiritDetails_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CNavigateToSpiritDetails_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGoToFullCollection_003Ed__75))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoToFullCollection()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoToFullCollection_003Ed__75 _003CGoToFullCollection_003Ed__ = new _003CGoToFullCollection_003Ed__75();
		_003CGoToFullCollection_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoToFullCollection_003Ed__._003C_003E4__this = this;
		_003CGoToFullCollection_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoToFullCollection_003Ed__._003C_003Et__builder)).Start<_003CGoToFullCollection_003Ed__75>(ref _003CGoToFullCollection_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoToFullCollection_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadTasksAsync_003Ed__76))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadTasksAsync(string questType, string areaId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadTasksAsync_003Ed__76 _003CLoadTasksAsync_003Ed__ = new _003CLoadTasksAsync_003Ed__76();
		_003CLoadTasksAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadTasksAsync_003Ed__._003C_003E4__this = this;
		_003CLoadTasksAsync_003Ed__.questType = questType;
		_003CLoadTasksAsync_003Ed__.areaId = areaId;
		_003CLoadTasksAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadTasksAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadTasksAsync_003Ed__76>(ref _003CLoadTasksAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadTasksAsync_003Ed__._003C_003Et__builder)).Task;
	}

	private bool IsTaskVisible(QuestTask task, PlayerQuest? playerQuest, List<QuestTask> allTasks)
	{
		TaskProgress taskProgress = ((playerQuest != null) ? CollectionExtensions.GetValueOrDefault<string, TaskProgress>((IReadOnlyDictionary<string, TaskProgress>)(object)playerQuest.Tasks, task.Id ?? string.Empty) : null);
		if (!task.IsRepeatable && taskProgress != null && taskProgress.IsCompleted)
		{
			return false;
		}
		if (!string.IsNullOrEmpty(task.OrderRequirement))
		{
			return ((playerQuest != null) ? CollectionExtensions.GetValueOrDefault<string, TaskProgress>((IReadOnlyDictionary<string, TaskProgress>)(object)playerQuest.Tasks, task.OrderRequirement) : null)?.IsCompleted ?? false;
		}
		if (task.LevelRequirement > 1)
		{
			return Player?.PlayerLevel >= task.LevelRequirement;
		}
		int highestCompletedOrder = GetHighestCompletedOrder(allTasks, playerQuest);
		return task.Order <= highestCompletedOrder + 1;
	}

	private int GetHighestCompletedOrder(List<QuestTask> tasks, PlayerQuest? playerQuest)
	{
		PlayerQuest playerQuest2 = playerQuest;
		if (playerQuest2?.Tasks == null || !Enumerable.Any<KeyValuePair<string, TaskProgress>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, TaskProgress>>)playerQuest2.Tasks))
		{
			return 0;
		}
		List<QuestTask> val = Enumerable.ToList<QuestTask>(Enumerable.Where<QuestTask>((global::System.Collections.Generic.IEnumerable<QuestTask>)tasks, (Func<QuestTask, bool>)((QuestTask t) => t.Id != null && (CollectionExtensions.GetValueOrDefault<string, TaskProgress>((IReadOnlyDictionary<string, TaskProgress>)(object)playerQuest2.Tasks, t.Id)?.IsCompleted ?? false))));
		return Enumerable.Any<QuestTask>((global::System.Collections.Generic.IEnumerable<QuestTask>)val) ? Enumerable.Max<QuestTask>((global::System.Collections.Generic.IEnumerable<QuestTask>)val, (Func<QuestTask, int>)((QuestTask t) => t.Order)) : 0;
	}

	[AsyncStateMachine(typeof(_003CSelectTask_003Ed__79))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task SelectTask(PlayerTaskViewModel selectedTask)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSelectTask_003Ed__79 _003CSelectTask_003Ed__ = new _003CSelectTask_003Ed__79();
		_003CSelectTask_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSelectTask_003Ed__._003C_003E4__this = this;
		_003CSelectTask_003Ed__.selectedTask = selectedTask;
		_003CSelectTask_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSelectTask_003Ed__._003C_003Et__builder)).Start<_003CSelectTask_003Ed__79>(ref _003CSelectTask_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSelectTask_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CExecuteBattleTask_003Ed__80))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ExecuteBattleTask(PlayerTaskViewModel selectedTask)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CExecuteBattleTask_003Ed__80 _003CExecuteBattleTask_003Ed__ = new _003CExecuteBattleTask_003Ed__80();
		_003CExecuteBattleTask_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CExecuteBattleTask_003Ed__._003C_003E4__this = this;
		_003CExecuteBattleTask_003Ed__.selectedTask = selectedTask;
		_003CExecuteBattleTask_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CExecuteBattleTask_003Ed__._003C_003Et__builder)).Start<_003CExecuteBattleTask_003Ed__80>(ref _003CExecuteBattleTask_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CExecuteBattleTask_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CHandleTaskHoldAsync_003Ed__81))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task HandleTaskHoldAsync(PlayerTaskViewModel selectedTask, CancellationToken cancellationToken)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		_003CHandleTaskHoldAsync_003Ed__81 _003CHandleTaskHoldAsync_003Ed__ = new _003CHandleTaskHoldAsync_003Ed__81();
		_003CHandleTaskHoldAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CHandleTaskHoldAsync_003Ed__._003C_003E4__this = this;
		_003CHandleTaskHoldAsync_003Ed__.selectedTask = selectedTask;
		_003CHandleTaskHoldAsync_003Ed__.cancellationToken = cancellationToken;
		_003CHandleTaskHoldAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CHandleTaskHoldAsync_003Ed__._003C_003Et__builder)).Start<_003CHandleTaskHoldAsync_003Ed__81>(ref _003CHandleTaskHoldAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CHandleTaskHoldAsync_003Ed__._003C_003Et__builder)).Task;
	}

	public void StartTaskHold(PlayerTaskViewModel selectedTask)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		if (!_holdSessionActive)
		{
			_currentHoldTask = selectedTask;
			_holdTaskCts = new CancellationTokenSource();
			HandleTaskHoldAsync(selectedTask, _holdTaskCts.Token);
		}
	}

	public void StopTaskHold()
	{
		_holdSessionActive = false;
		if (_holdTaskCts != null)
		{
			_holdTaskCts.Cancel();
			_holdTaskCts.Dispose();
			_holdTaskCts = null;
		}
		_currentHoldTask = null;
		EventHandler? holdShouldStop = this.HoldShouldStop;
		if (holdShouldStop != null)
		{
			holdShouldStop.Invoke((object)this, EventArgs.Empty);
		}
	}

	[AsyncStateMachine(typeof(_003CExecuteHoldToComplete_003Ed__84))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ExecuteHoldToComplete(PlayerTaskViewModel selectedTask, CancellationToken cancellationToken)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		_003CExecuteHoldToComplete_003Ed__84 _003CExecuteHoldToComplete_003Ed__ = new _003CExecuteHoldToComplete_003Ed__84();
		_003CExecuteHoldToComplete_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CExecuteHoldToComplete_003Ed__._003C_003E4__this = this;
		_003CExecuteHoldToComplete_003Ed__.selectedTask = selectedTask;
		_003CExecuteHoldToComplete_003Ed__.cancellationToken = cancellationToken;
		_003CExecuteHoldToComplete_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CExecuteHoldToComplete_003Ed__._003C_003Et__builder)).Start<_003CExecuteHoldToComplete_003Ed__84>(ref _003CExecuteHoldToComplete_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CExecuteHoldToComplete_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CHandleTaskCompletionEffects_003Ed__85))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task HandleTaskCompletionEffects(PlayerTaskViewModel selectedTask, int holdCounter = 1)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CHandleTaskCompletionEffects_003Ed__85 _003CHandleTaskCompletionEffects_003Ed__ = new _003CHandleTaskCompletionEffects_003Ed__85();
		_003CHandleTaskCompletionEffects_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CHandleTaskCompletionEffects_003Ed__._003C_003E4__this = this;
		_003CHandleTaskCompletionEffects_003Ed__.selectedTask = selectedTask;
		_003CHandleTaskCompletionEffects_003Ed__.holdCounter = holdCounter;
		_003CHandleTaskCompletionEffects_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CHandleTaskCompletionEffects_003Ed__._003C_003Et__builder)).Start<_003CHandleTaskCompletionEffects_003Ed__85>(ref _003CHandleTaskCompletionEffects_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CHandleTaskCompletionEffects_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CShowCompletionPopup_003Ed__86))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<bool> ShowCompletionPopup(long gold, double experience)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			object result = await _popupService.ShowPopupAsync<QuestRewardsPopupViewModel>((Action<QuestRewardsPopupViewModel>)delegate(QuestRewardsPopupViewModel vm)
			{
				vm.CompletedText = "Quest Progressed";
				vm.CompletedText2 = "You've obtained these rewards:";
				vm.EarnedGold = gold.ToString();
				vm.EarnedEXP = experience.ToString();
				vm.IsItem = false;
			}, default(CancellationToken));
			bool boolResult = default(bool);
			int num;
			if (result is bool)
			{
				boolResult = (bool)result;
				num = 1;
			}
			else
			{
				num = 0;
			}
			return (byte)((uint)num & (boolResult ? 1u : 0u)) != 0;
		}
		catch (global::System.Exception ex)
		{
			await _navigationService.ShowAlertAsync("Error showing popup", ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CShowItemDropPopup_003Ed__87))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<bool> ShowItemDropPopup(string spiritName, int orbPlayerCount)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string spiritName2 = spiritName;
		try
		{
			await _popupService.ShowPopupAsync<SpiritOrbDropPopupViewModel>((Action<SpiritOrbDropPopupViewModel>)delegate(SpiritOrbDropPopupViewModel vm)
			{
				vm.CompletedText = spiritName2 + " dropped a Core Orb!";
				vm.CompletedText2 = "Core Orbs can be used in shop to collect new spirits to your collection";
				vm.OrbCount = 1;
				vm.OrbCountText = "x1";
				vm.OrbPlayerCount = orbPlayerCount;
			}, default(CancellationToken));
			return true;
		}
		catch (global::System.Exception ex)
		{
			await _navigationService.ShowAlertAsync("Error showing popup", ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003COpenSpiritsHoldNavigation_003Ed__88))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task OpenSpiritsHoldNavigation()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COpenSpiritsHoldNavigation_003Ed__88 _003COpenSpiritsHoldNavigation_003Ed__ = new _003COpenSpiritsHoldNavigation_003Ed__88();
		_003COpenSpiritsHoldNavigation_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003COpenSpiritsHoldNavigation_003Ed__._003C_003E4__this = this;
		_003COpenSpiritsHoldNavigation_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003COpenSpiritsHoldNavigation_003Ed__._003C_003Et__builder)).Start<_003COpenSpiritsHoldNavigation_003Ed__88>(ref _003COpenSpiritsHoldNavigation_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003COpenSpiritsHoldNavigation_003Ed__._003C_003Et__builder)).Task;
	}

	public void DisposeOnNavigateAway()
	{
	}

	public void SubscribeOnAppear()
	{
	}

	public void Dispose()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		if (_disposed)
		{
			return;
		}
		StopTaskHold();
		_stateService.StateChanged -= OnStateChanged;
		_chatUnreadService.UnreadCountChanged -= new EventHandler(OnUnreadCountChanged);
		Enumerator<PlayerTaskViewModel> enumerator = _allPlayerTasks.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				PlayerTaskViewModel current = enumerator.Current;
				current.Dispose();
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator).Dispose();
		}
		if (!string.IsNullOrEmpty(_acquiredPartnerSpiritId))
		{
			_spiritCardModelFactory.ReleaseModel(_acquiredPartnerSpiritId);
			_acquiredPartnerSpiritId = null;
		}
		_holdSemaphore.Dispose();
		_taskExecutionSemaphore.Dispose();
		_stateChangeSemaphore.Dispose();
		((Collection<PlayerTaskViewModel>)(object)PlayerTasks)?.Clear();
		_allPlayerTasks.Clear();
		_disposed = true;
		GC.SuppressFinalize((object)this);
	}
}
