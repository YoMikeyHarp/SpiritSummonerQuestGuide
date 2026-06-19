using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using SpiritSummoner.Application.DTOs.Battles;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Battles;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Guilds;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Enums.Battles;
using SpiritSummoner.Domain.Enums.Guilds;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Infrastructure.Contracts;
using SpiritSummoner.Presentation.Models;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.Battles;
using SpiritSummoner.Presentation.ViewModels.BottomSheet;
using SpiritSummoner.Presentation.ViewModels.Popups;
using SpiritSummoner.Presentation.ViewModels.Squads;
using SpiritSummoner.Presentation.Views.BottomSheets.Portal;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.ViewModels.Guilds;

public class GuildWarsViewModel : ObservableObject, ILoadableViewModel, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003C_003COnGuildStateChanged_003Eb__147_1_003Ed : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public GuildWarsViewModel _003C_003E4__this;

		private DateTimeOffset _003Cexpiry_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_020f: Unknown result type (might be due to invalid IL or missing references)
			//IL_021f: Unknown result type (might be due to invalid IL or missing references)
			//IL_023a: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_00ee;
					}
					awaiter2 = _003C_003E4__this.LoadDefenders().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003C_003COnGuildStateChanged_003Eb__147_1_003Ed _003C_003COnGuildStateChanged_003Eb__147_1_003Ed = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003COnGuildStateChanged_003Eb__147_1_003Ed>(ref awaiter2, ref _003C_003COnGuildStateChanged_003Eb__147_1_003Ed);
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
				if (_003C_003E4__this.HasMatchedOpponent)
				{
					awaiter = _003C_003E4__this.LoadBucketOpponents().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter;
						_003C_003COnGuildStateChanged_003Eb__147_1_003Ed _003C_003COnGuildStateChanged_003Eb__147_1_003Ed = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003COnGuildStateChanged_003Eb__147_1_003Ed>(ref awaiter, ref _003C_003COnGuildStateChanged_003Eb__147_1_003Ed);
						return;
					}
					goto IL_00ee;
				}
				goto IL_00f6;
				IL_00ee:
				((TaskAwaiter)(ref awaiter)).GetResult();
				goto IL_00f6;
				IL_00f6:
				if (_003C_003E4__this.Player != null && _003C_003E4__this.CurrentGuild != null)
				{
					_003C_003E4__this.IsDefender = Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)_003C_003E4__this.CurrentGuild.DefenderPlayerIds, _003C_003E4__this.Player.PlayerID);
					_003C_003E4__this.IsRegisteredDefender = _003C_003E4__this.IsDefender;
					if (_003C_003E4__this.IsDefender && _003C_003E4__this.CurrentGuild.DefenderSquads.ContainsKey(_003C_003E4__this.Player.PlayerID))
					{
						_003C_003E4__this.DefenderSquad = _003C_003E4__this.CurrentGuild.DefenderSquads[_003C_003E4__this.Player.PlayerID];
					}
					if (_003C_003E4__this.IsDefender && _003C_003E4__this.CurrentGuild.DefenderExpiryTimestamps.TryGetValue(_003C_003E4__this.Player.PlayerID, ref _003Cexpiry_003E5__1) && _003Cexpiry_003E5__1 > _003C_003E4__this._serverTimeProvider.GetCurrentServerTime())
					{
						_003C_003E4__this.StartDefenseTimer(_003Cexpiry_003E5__1);
					}
					else
					{
						_003C_003E4__this.StopDefenseTimer();
					}
					((ObservableObject)_003C_003E4__this).OnPropertyChanged("ActiveMemberRatio");
					((ObservableObject)_003C_003E4__this).OnPropertyChanged("ShowRefreshDefenseButton");
				}
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
	private sealed class _003C_003Ec__DisplayClass129_0
	{
		public BattleResultDTO battleResult;

		public GuildWarsViewModel _003C_003E4__this;

		public string defendingGuildName;

		public BattleRewards rewards;

		public BattleLaunchRequest battleLaunchRequest;

		internal void _003CShowBattleSummary_003Eb__0(BattleSummaryPopupViewModel vm)
		{
			//IL_0207: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_0211: Expected O, but got Unknown
			vm.PlayerSpirits = Enumerable.ToList<SpriteModelResultsRecord>(Enumerable.Select<SpiritBattleResult, SpriteModelResultsRecord>((global::System.Collections.Generic.IEnumerable<SpiritBattleResult>)battleResult.PlayerSpirits, (Func<SpiritBattleResult, SpriteModelResultsRecord>)((SpiritBattleResult spirit) => new SpriteModelResultsRecord(spirit.Image, spirit.Fainted ? "x.png" : "check.png", spirit.Fainted ? 0.3 : 1.0))));
			vm.EnemySpirits = Enumerable.ToList<SpriteModelResultsRecord>(Enumerable.Select<SpiritBattleResult, SpriteModelResultsRecord>((global::System.Collections.Generic.IEnumerable<SpiritBattleResult>)battleResult.EnemySpirits, (Func<SpiritBattleResult, SpriteModelResultsRecord>)((SpiritBattleResult spirit) => new SpriteModelResultsRecord(spirit.Image, spirit.Fainted ? "x.png" : "check.png", spirit.Fainted ? 0.3 : 1.0))));
			vm.IsGuildBattle = true;
			vm.PlayerGuildName = _003C_003E4__this.CurrentGuild?.Name ?? "";
			vm.EnemyGuildname = defendingGuildName;
			vm.OutcomeImagePlayer = (battleResult.Victory ? "staricon.png" : "x.png");
			vm.OutcomeImageEnemy = ((!battleResult.Victory) ? "staricon.png" : "x.png");
			vm.OutcomeText = (battleResult.Victory ? "VICTORY!" : "DEFEAT");
			vm.EarnedEXP = rewards?.Experience ?? 0;
			vm.EarnedGold = rewards?.Gold ?? 0;
			vm.EarnedReputation = rewards?.Reputation ?? 0;
			vm.PlayerName = _003C_003E4__this._playerStateService.GetCurrentPlayer()?.Playername;
			vm.EnemyName = battleLaunchRequest.DefenderName;
			vm.EnemyRank = battleLaunchRequest.OpponentLevel;
			vm.PlayerRank = _003C_003E4__this._playerStateService.GetCurrentPlayer()?.PlayerLevel ?? 0;
			vm.BackGround = (battleResult.Victory ? ((Brush)Application.Current.Resources["GradientWinSummary"]) : ((Brush)Application.Current.Resources["GradientLossSummary"]));
			vm.TextColor = (battleResult.Victory ? Color.FromArgb("#027242") : Color.FromArgb("#721502"));
		}
	}

	[CompilerGenerated]
	private sealed class _003CAttackDefender_003Ed__124 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildWarsViewModel _003C_003E4__this;

		private string _003Cmessage_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter3;
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					if (!_003C_003E4__this.HasActiveSeason)
					{
						_003Cmessage_003E5__1 = (_003C_003E4__this.HasMatchedButNotStarted ? "The war season has not started yet. Please wait for it to begin." : "Your guild is not in an active war season.");
						awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Cannot Battle", _003Cmessage_003E5__1).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CAttackDefender_003Ed__124 _003CAttackDefender_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAttackDefender_003Ed__124>(ref awaiter3, ref _003CAttackDefender_003Ed__);
							return;
						}
						goto IL_00cd;
					}
					if (((Collection<GuildWarTargetModel>)(object)_003C_003E4__this.BucketOpponents).Count == 0)
					{
						awaiter2 = _003C_003E4__this.LoadBucketOpponents().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter2;
							_003CAttackDefender_003Ed__124 _003CAttackDefender_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAttackDefender_003Ed__124>(ref awaiter2, ref _003CAttackDefender_003Ed__);
							return;
						}
						goto IL_0153;
					}
					goto IL_015b;
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00cd;
				case 1:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0153;
				case 2:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_00cd:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					goto end_IL_0007;
					IL_015b:
					awaiter = _003C_003E4__this._navigationService.NavigateToAsync(_003C_003E4__this._playerStateService.CurrentRoute + "/guildwarbattlelist").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = awaiter;
						_003CAttackDefender_003Ed__124 _003CAttackDefender_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAttackDefender_003Ed__124>(ref awaiter, ref _003CAttackDefender_003Ed__);
						return;
					}
					break;
					IL_0153:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					goto IL_015b;
				}
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
	private sealed class _003CAttackGuild_003Ed__125 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildWarTargetModel target;

		public GuildWarsViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00c2;
				}
				TaskAwaiter awaiter2;
				if (num == 1)
				{
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0140;
				}
				if (target != null)
				{
					if (target.CanRaid || target.IsInGuildBreak)
					{
						awaiter = _003C_003E4__this.RaidTargetAsync(target.Id, target.Name).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CAttackGuild_003Ed__125 _003CAttackGuild_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAttackGuild_003Ed__125>(ref awaiter, ref _003CAttackGuild_003Ed__);
							return;
						}
						goto IL_00c2;
					}
					awaiter2 = _003C_003E4__this.AttackTargetAsync(target.Id, target.Name).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter2;
						_003CAttackGuild_003Ed__125 _003CAttackGuild_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAttackGuild_003Ed__125>(ref awaiter2, ref _003CAttackGuild_003Ed__);
						return;
					}
					goto IL_0140;
				}
				goto end_IL_0007;
				IL_0140:
				((TaskAwaiter)(ref awaiter2)).GetResult();
				goto end_IL_0007;
				IL_00c2:
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
	private sealed class _003CAttackTargetAsync_003Ed__127 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string defendingGuildId;

		public string defendingGuildName;

		public GuildWarsViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private StartGuildWarBattleRequest _003Crequest_003E5__3;

		private Result<BattleLaunchRequest> _003Cresult_003E5__4;

		private BattleLaunchRequest _003CbattleRequest_003E5__5;

		private BattleResultDTO _003CbattleResult_003E5__6;

		private Result<BattleLaunchRequest> _003C_003Es__7;

		private BattleResultDTO _003C_003Es__8;

		private global::System.Exception _003Cex_003E5__9;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<Result<BattleLaunchRequest>> _003C_003Eu__2;

		private TaskAwaiter<BattleResultDTO> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_05d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_05da: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_05f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_060f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0614: Unknown result type (might be due to invalid IL or missing references)
			//IL_061c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_027d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0282: Unknown result type (might be due to invalid IL or missing references)
			//IL_028a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0309: Unknown result type (might be due to invalid IL or missing references)
			//IL_030e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0316: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_043a: Unknown result type (might be due to invalid IL or missing references)
			//IL_043f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0447: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0541: Unknown result type (might be due to invalid IL or missing references)
			//IL_0546: Unknown result type (might be due to invalid IL or missing references)
			//IL_054e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_046e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0473: Unknown result type (might be due to invalid IL or missing references)
			//IL_0507: Unknown result type (might be due to invalid IL or missing references)
			//IL_050c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_0488: Unknown result type (might be due to invalid IL or missing references)
			//IL_048a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0521: Unknown result type (might be due to invalid IL or missing references)
			//IL_0523: Unknown result type (might be due to invalid IL or missing references)
			//IL_0400: Unknown result type (might be due to invalid IL or missing references)
			//IL_0405: Unknown result type (might be due to invalid IL or missing references)
			//IL_036d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0372: Unknown result type (might be due to invalid IL or missing references)
			//IL_041a: Unknown result type (might be due to invalid IL or missing references)
			//IL_041c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0387: Unknown result type (might be due to invalid IL or missing references)
			//IL_0389: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Unknown result type (might be due to invalid IL or missing references)
			//IL_0248: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_025d: Unknown result type (might be due to invalid IL or missing references)
			//IL_025f: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 8u || (!string.IsNullOrEmpty(_003C_003E4__this.GuildId) && _003C_003E4__this.Player != null && _003C_003E4__this._navigationService.CanNavigate()))
				{
					try
					{
						TaskAwaiter awaiter;
						if ((uint)num > 7u)
						{
							if (num == 8)
							{
								awaiter = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_062b;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter awaiter9;
							TaskAwaiter<Result<BattleLaunchRequest>> awaiter8;
							TaskAwaiter awaiter7;
							TaskAwaiter awaiter6;
							TaskAwaiter awaiter5;
							TaskAwaiter awaiter4;
							TaskAwaiter<BattleResultDTO> awaiter3;
							TaskAwaiter awaiter2;
							switch (num)
							{
							default:
								_003C_003E4__this.IsLoading = true;
								awaiter9 = _003C_003E4__this._playerStateService.EnsureSyncedAsync().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter9)).IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter9;
									_003CAttackTargetAsync_003Ed__127 _003CAttackTargetAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAttackTargetAsync_003Ed__127>(ref awaiter9, ref _003CAttackTargetAsync_003Ed__);
									return;
								}
								goto IL_0132;
							case 0:
								awaiter9 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0132;
							case 1:
								awaiter8 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter<Result<BattleLaunchRequest>>);
								num = (_003C_003E1__state = -1);
								goto IL_01d2;
							case 2:
								awaiter7 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0299;
							case 3:
								awaiter6 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0325;
							case 4:
								awaiter5 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_03c3;
							case 5:
								awaiter4 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0456;
							case 6:
								awaiter3 = _003C_003Eu__3;
								_003C_003Eu__3 = default(TaskAwaiter<BattleResultDTO>);
								num = (_003C_003E1__state = -1);
								goto IL_04c4;
							case 7:
								{
									awaiter2 = _003C_003Eu__1;
									_003C_003Eu__1 = default(TaskAwaiter);
									num = (_003C_003E1__state = -1);
									break;
								}
								IL_0456:
								((TaskAwaiter)(ref awaiter4)).GetResult();
								awaiter3 = _003CbattleRequest_003E5__5.CompletionSource.Task.GetAwaiter();
								if (!awaiter3.IsCompleted)
								{
									num = (_003C_003E1__state = 6);
									_003C_003Eu__3 = awaiter3;
									_003CAttackTargetAsync_003Ed__127 _003CAttackTargetAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<BattleResultDTO>, _003CAttackTargetAsync_003Ed__127>(ref awaiter3, ref _003CAttackTargetAsync_003Ed__);
									return;
								}
								goto IL_04c4;
								IL_0132:
								((TaskAwaiter)(ref awaiter9)).GetResult();
								_003Crequest_003E5__3 = new StartGuildWarBattleRequest(_003C_003E4__this.GuildId, _003C_003E4__this.Player.PlayerID, defendingGuildId);
								awaiter8 = _003C_003E4__this._startGuildWarBattleUseCase.ExecuteAsync(_003Crequest_003E5__3).GetAwaiter();
								if (!awaiter8.IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter8;
									_003CAttackTargetAsync_003Ed__127 _003CAttackTargetAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<BattleLaunchRequest>>, _003CAttackTargetAsync_003Ed__127>(ref awaiter8, ref _003CAttackTargetAsync_003Ed__);
									return;
								}
								goto IL_01d2;
								IL_0299:
								((TaskAwaiter)(ref awaiter7)).GetResult();
								goto end_IL_0074;
								IL_01d2:
								_003C_003Es__7 = awaiter8.GetResult();
								_003Cresult_003E5__4 = _003C_003Es__7;
								_003C_003Es__7 = null;
								if (!_003Cresult_003E5__4.Success)
								{
									string? errorMessage = _003Cresult_003E5__4.ErrorMessage;
									if (errorMessage != null && errorMessage.StartsWith("No defenders remain"))
									{
										awaiter7 = _003C_003E4__this.RaidTargetAsync(defendingGuildId, defendingGuildName).GetAwaiter();
										if (!((TaskAwaiter)(ref awaiter7)).IsCompleted)
										{
											num = (_003C_003E1__state = 2);
											_003C_003Eu__1 = awaiter7;
											_003CAttackTargetAsync_003Ed__127 _003CAttackTargetAsync_003Ed__ = this;
											((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAttackTargetAsync_003Ed__127>(ref awaiter7, ref _003CAttackTargetAsync_003Ed__);
											return;
										}
										goto IL_0299;
									}
									awaiter6 = _003C_003E4__this._navigationService.ShowAlertAsync("Cannot Start Battle", _003Cresult_003E5__4.ErrorMessage ?? "Unknown error").GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter6)).IsCompleted)
									{
										num = (_003C_003E1__state = 3);
										_003C_003Eu__1 = awaiter6;
										_003CAttackTargetAsync_003Ed__127 _003CAttackTargetAsync_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAttackTargetAsync_003Ed__127>(ref awaiter6, ref _003CAttackTargetAsync_003Ed__);
										return;
									}
									goto IL_0325;
								}
								_003CbattleRequest_003E5__5 = _003Cresult_003E5__4.Data;
								if (_003CbattleRequest_003E5__5 == null)
								{
									awaiter5 = _003C_003E4__this._navigationService.ShowAlertAsync("Battle Error", "Failed to create battle request.").GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
									{
										num = (_003C_003E1__state = 4);
										_003C_003Eu__1 = awaiter5;
										_003CAttackTargetAsync_003Ed__127 _003CAttackTargetAsync_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAttackTargetAsync_003Ed__127>(ref awaiter5, ref _003CAttackTargetAsync_003Ed__);
										return;
									}
									goto IL_03c3;
								}
								awaiter4 = _003C_003E4__this._navigationService.NavigateToBattleViewAsync(_003C_003E4__this._playerStateService.CurrentRoute + "/battleground", _003CbattleRequest_003E5__5).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
								{
									num = (_003C_003E1__state = 5);
									_003C_003Eu__1 = awaiter4;
									_003CAttackTargetAsync_003Ed__127 _003CAttackTargetAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAttackTargetAsync_003Ed__127>(ref awaiter4, ref _003CAttackTargetAsync_003Ed__);
									return;
								}
								goto IL_0456;
								IL_04c4:
								_003C_003Es__8 = awaiter3.GetResult();
								_003CbattleResult_003E5__6 = _003C_003Es__8;
								_003C_003Es__8 = null;
								awaiter2 = _003C_003E4__this.ProcessGuildWarBattleResults(_003CbattleResult_003E5__6, _003CbattleRequest_003E5__5, defendingGuildId, defendingGuildName).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 7);
									_003C_003Eu__1 = awaiter2;
									_003CAttackTargetAsync_003Ed__127 _003CAttackTargetAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAttackTargetAsync_003Ed__127>(ref awaiter2, ref _003CAttackTargetAsync_003Ed__);
									return;
								}
								break;
								IL_03c3:
								((TaskAwaiter)(ref awaiter5)).GetResult();
								goto end_IL_0074;
								IL_0325:
								((TaskAwaiter)(ref awaiter6)).GetResult();
								goto end_IL_0074;
							}
							((TaskAwaiter)(ref awaiter2)).GetResult();
							_003Crequest_003E5__3 = null;
							_003Cresult_003E5__4 = null;
							_003CbattleRequest_003E5__5 = null;
							_003CbattleResult_003E5__6 = null;
							goto IL_0597;
							end_IL_0074:;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
							goto IL_0597;
						}
						goto end_IL_0059;
						IL_0597:
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_066f;
						}
						_003Cex_003E5__9 = (global::System.Exception)_003C_003Es__1;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Battle Error", "An error occurred during battle.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 8);
							_003C_003Eu__1 = awaiter;
							_003CAttackTargetAsync_003Ed__127 _003CAttackTargetAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAttackTargetAsync_003Ed__127>(ref awaiter, ref _003CAttackTargetAsync_003Ed__);
							return;
						}
						goto IL_062b;
						IL_062b:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine($"AttackTarget error: {_003Cex_003E5__9}");
						_003Cex_003E5__9 = null;
						goto IL_066f;
						IL_066f:
						_003C_003Es__1 = null;
						end_IL_0059:;
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsLoading = false;
						}
					}
				}
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
	private sealed class _003CGoBack_003Ed__139 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildWarsViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGoBack_003Ed__139 _003CGoBack_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoBack_003Ed__139>(ref awaiter, ref _003CGoBack_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
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
	private sealed class _003CGoToDefenderManagement_003Ed__141 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildWarsViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00a8;
				}
				if (!string.IsNullOrEmpty(_003C_003E4__this.GuildId))
				{
					awaiter = _003C_003E4__this._navigationService.NavigateToAsync("//guild/defenderManagement?guildId=" + _003C_003E4__this.CurrentGuild?.ID).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGoToDefenderManagement_003Ed__141 _003CGoToDefenderManagement_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToDefenderManagement_003Ed__141>(ref awaiter, ref _003CGoToDefenderManagement_003Ed__);
						return;
					}
					goto IL_00a8;
				}
				goto end_IL_0007;
				IL_00a8:
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
	private sealed class _003CGoToPortal_003Ed__144 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildWarsViewModel _003C_003E4__this;

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
							_003CGoToPortal_003Ed__144 _003CGoToPortal_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<BottomSheet>, _003CGoToPortal_003Ed__144>(ref awaiter3, ref _003CGoToPortal_003Ed__);
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
						_003CGoToPortal_003Ed__144 _003CGoToPortal_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToPortal_003Ed__144>(ref awaiter2, ref _003CGoToPortal_003Ed__);
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
					_003CGoToPortal_003Ed__144 _003CGoToPortal_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToPortal_003Ed__144>(ref awaiter, ref _003CGoToPortal_003Ed__);
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
	private sealed class _003CGoToWarHistory_003Ed__135 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildWarsViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_009c;
				}
				if (!string.IsNullOrEmpty(_003C_003E4__this.GuildId))
				{
					awaiter = _003C_003E4__this._navigationService.NavigateToAsync("//guild/warHistory?guildId=" + _003C_003E4__this.GuildId).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGoToWarHistory_003Ed__135 _003CGoToWarHistory_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToWarHistory_003Ed__135>(ref awaiter, ref _003CGoToWarHistory_003Ed__);
						return;
					}
					goto IL_009c;
				}
				goto end_IL_0007;
				IL_009c:
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
	private sealed class _003CLoadBucketOpponents_003Ed__122 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildWarsViewModel _003C_003E4__this;

		private string _003CwarId_003E5__1;

		private List<Guild> _003Copponents_003E5__2;

		private List<GuildWarTargetModel> _003Cmodels_003E5__3;

		private List<Guild> _003C_003Es__4;

		private Enumerator<Guild> _003C_003Es__5;

		private Guild _003Cg_003E5__6;

		private List<string> _003Cavailable_003E5__7;

		private List<string> _003C_003Es__8;

		private global::System.Exception _003Cex_003E5__9;

		private TaskAwaiter<List<Guild>> _003C_003Eu__1;

		private TaskAwaiter<List<string>> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 1u || !string.IsNullOrEmpty(_003C_003E4__this.GuildId))
				{
					try
					{
						TaskAwaiter<List<Guild>> awaiter;
						if (num != 0)
						{
							if (num == 1)
							{
								goto IL_010e;
							}
							_003CwarId_003E5__1 = _003C_003E4__this.CurrentGuild?.CurrentWarId ?? string.Empty;
							awaiter = _003C_003E4__this._guildRepository.GetWarBucketOpponentsAsync(_003C_003E4__this.GuildId).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CLoadBucketOpponents_003Ed__122 _003CLoadBucketOpponents_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<List<Guild>>, _003CLoadBucketOpponents_003Ed__122>(ref awaiter, ref _003CLoadBucketOpponents_003Ed__);
								return;
							}
						}
						else
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<List<Guild>>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__4 = awaiter.GetResult();
						_003Copponents_003E5__2 = _003C_003Es__4;
						_003C_003Es__4 = null;
						_003Cmodels_003E5__3 = new List<GuildWarTargetModel>();
						_003C_003Es__5 = _003Copponents_003E5__2.GetEnumerator();
						goto IL_010e;
						IL_010e:
						try
						{
							if (num != 1)
							{
								goto IL_027e;
							}
							TaskAwaiter<List<string>> awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<List<string>>);
							num = (_003C_003E1__state = -1);
							goto IL_01ae;
							IL_01ae:
							_003C_003Es__8 = awaiter2.GetResult();
							_003Cavailable_003E5__7 = _003C_003Es__8;
							_003C_003Es__8 = null;
							_003Cmodels_003E5__3.Add(new GuildWarTargetModel
							{
								Id = (_003Cg_003E5__6.ID ?? string.Empty),
								Name = (_003Cg_003E5__6.Name ?? "Unknown"),
								Emblem = _003Cg_003E5__6.Emblem,
								Level = _003Cg_003E5__6.Level,
								Trophies = _003Cg_003E5__6.Trophies,
								AvailableDefenders = _003Cavailable_003E5__7.Count,
								IsInGuildBreak = _003Cg_003E5__6.IsInGuildBreak
							});
							_003Cavailable_003E5__7 = null;
							_003Cg_003E5__6 = null;
							goto IL_027e;
							IL_027e:
							if (_003C_003Es__5.MoveNext())
							{
								_003Cg_003E5__6 = _003C_003Es__5.Current;
								awaiter2 = _003C_003E4__this._guildRepository.GetAvailableDefendersAsync(_003C_003E4__this.GuildId, _003Cg_003E5__6.ID, _003CwarId_003E5__1).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter2;
									_003CLoadBucketOpponents_003Ed__122 _003CLoadBucketOpponents_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<List<string>>, _003CLoadBucketOpponents_003Ed__122>(ref awaiter2, ref _003CLoadBucketOpponents_003Ed__);
									return;
								}
								goto IL_01ae;
							}
						}
						finally
						{
							if (num < 0)
							{
								((global::System.IDisposable)_003C_003Es__5).Dispose();
							}
						}
						_003C_003Es__5 = default(Enumerator<Guild>);
						_003C_003E4__this.BucketOpponents = new ObservableCollection<GuildWarTargetModel>(_003Cmodels_003E5__3);
						((ObservableObject)_003C_003E4__this).OnPropertyChanged("OpposingGuildName");
						_003CwarId_003E5__1 = null;
						_003Copponents_003E5__2 = null;
						_003Cmodels_003E5__3 = null;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__9 = ex;
						Console.WriteLine($"LoadBucketOpponents error: {_003Cex_003E5__9}");
					}
				}
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
	private sealed class _003CLoadCurrentGuild_003Ed__120 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildWarsViewModel _003C_003E4__this;

		private Guild _003Cguild_003E5__1;

		private Guild _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<Guild?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<Guild> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._guildRepository.GetByIdAsync(_003C_003E4__this.GuildId).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadCurrentGuild_003Ed__120 _003CLoadCurrentGuild_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CLoadCurrentGuild_003Ed__120>(ref awaiter, ref _003CLoadCurrentGuild_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Guild>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cguild_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					_003C_003E4__this.CurrentGuild = _003Cguild_003E5__1;
					_003Cguild_003E5__1 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine($"LoadCurrentGuild error: {_003Cex_003E5__3}");
				}
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
	private sealed class _003CLoadDataAsync_003Ed__115 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object parameter;

		public GuildWarsViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private string _003CguildId_003E5__3;

		private DateTimeOffset _003Cexpiry_003E5__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_040a: Unknown result type (might be due to invalid IL or missing references)
			//IL_040f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0417: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0328: Unknown result type (might be due to invalid IL or missing references)
			//IL_032d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0335: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0308: Unknown result type (might be due to invalid IL or missing references)
			//IL_030a: Unknown result type (might be due to invalid IL or missing references)
			//IL_029a: Unknown result type (might be due to invalid IL or missing references)
			//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 2u || !_003C_003E4__this.IsLoading)
				{
					try
					{
						TaskAwaiter awaiter;
						if ((uint)num > 1u)
						{
							if (num == 2)
							{
								awaiter = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0426;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter awaiter2;
							if (num == 0)
							{
								awaiter2 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0179;
							}
							TaskAwaiter awaiter3;
							if (num == 1)
							{
								awaiter3 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0344;
							}
							_003C_003E4__this.IsLoading = true;
							_003C_003E4__this.ErrorMessage = string.Empty;
							_003CguildId_003E5__3 = parameter as string;
							if (_003CguildId_003E5__3 != null)
							{
								_003C_003E4__this.GuildId = _003CguildId_003E5__3;
								_003C_003Ey__InlineArray4<global::System.Threading.Tasks.Task> buffer = default(_003C_003Ey__InlineArray4<global::System.Threading.Tasks.Task>);
								_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray4<global::System.Threading.Tasks.Task>, global::System.Threading.Tasks.Task>(ref buffer, 0) = _003C_003E4__this.LoadCurrentGuild();
								_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray4<global::System.Threading.Tasks.Task>, global::System.Threading.Tasks.Task>(ref buffer, 1) = _003C_003E4__this.LoadDefenders();
								_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray4<global::System.Threading.Tasks.Task>, global::System.Threading.Tasks.Task>(ref buffer, 2) = _003C_003E4__this.LoadWarStatistics();
								_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray4<global::System.Threading.Tasks.Task>, global::System.Threading.Tasks.Task>(ref buffer, 3) = _003C_003E4__this.LoadSquadData();
								awaiter2 = global::System.Threading.Tasks.Task.WhenAll(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray4<global::System.Threading.Tasks.Task>, global::System.Threading.Tasks.Task>(in buffer, 4)).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter2;
									_003CLoadDataAsync_003Ed__115 _003CLoadDataAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__115>(ref awaiter2, ref _003CLoadDataAsync_003Ed__);
									return;
								}
								goto IL_0179;
							}
							_003C_003E4__this.ErrorMessage = "No guild ID provided";
							goto end_IL_0025;
							IL_034c:
							_003C_003E4__this.NotifyWarPropertiesChanged();
							_003C_003E4__this.StartSeasonTimer();
							_003CguildId_003E5__3 = null;
							goto end_IL_0040;
							IL_0179:
							((TaskAwaiter)(ref awaiter2)).GetResult();
							if (_003C_003E4__this.Player != null && _003C_003E4__this.CurrentGuild != null)
							{
								_003C_003E4__this.IsDefender = Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)_003C_003E4__this.CurrentGuild.DefenderPlayerIds, _003C_003E4__this.Player.PlayerID);
								_003C_003E4__this.IsRegisteredDefender = _003C_003E4__this.IsDefender;
								if (_003C_003E4__this.IsDefender && _003C_003E4__this.CurrentGuild.DefenderSquads.ContainsKey(_003C_003E4__this.Player.PlayerID))
								{
									_003C_003E4__this.DefenderSquad = _003C_003E4__this.CurrentGuild.DefenderSquads[_003C_003E4__this.Player.PlayerID];
								}
								if (_003C_003E4__this.IsDefender && _003C_003E4__this.CurrentGuild.DefenderExpiryTimestamps.TryGetValue(_003C_003E4__this.Player.PlayerID, ref _003Cexpiry_003E5__4) && _003Cexpiry_003E5__4 > _003C_003E4__this._serverTimeProvider.GetCurrentServerTime())
								{
									_003C_003E4__this.StartDefenseTimer(_003Cexpiry_003E5__4);
								}
							}
							if (_003C_003E4__this.HasMatchedOpponent)
							{
								awaiter3 = _003C_003E4__this.LoadBucketOpponents().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__1 = awaiter3;
									_003CLoadDataAsync_003Ed__115 _003CLoadDataAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__115>(ref awaiter3, ref _003CLoadDataAsync_003Ed__);
									return;
								}
								goto IL_0344;
							}
							goto IL_034c;
							IL_0344:
							((TaskAwaiter)(ref awaiter3)).GetResult();
							goto IL_034c;
							end_IL_0040:;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
						}
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_046a;
						}
						_003Cex_003E5__5 = (global::System.Exception)_003C_003Es__1;
						_003C_003E4__this.ErrorMessage = "Failed to load war data";
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to load guild wars. Please try again.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = awaiter;
							_003CLoadDataAsync_003Ed__115 _003CLoadDataAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__115>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
							return;
						}
						goto IL_0426;
						IL_0426:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine($"GuildWarsViewModel.LoadDataAsync: {_003Cex_003E5__5}");
						_003Cex_003E5__5 = null;
						goto IL_046a;
						IL_046a:
						_003C_003Es__1 = null;
						end_IL_0025:;
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsLoading = false;
						}
					}
				}
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
	private sealed class _003CLoadDefenders_003Ed__121 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildWarsViewModel _003C_003E4__this;

		private List<GuildMember> _003Cdefenders_003E5__1;

		private List<GuildMember> _003CmainDefenders_003E5__2;

		private List<GuildMember> _003C_003Es__3;

		private List<GuildMember> _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<List<GuildMember>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter<List<GuildMember>> awaiter;
					TaskAwaiter<List<GuildMember>> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<List<GuildMember>>);
							num = (_003C_003E1__state = -1);
							goto IL_0135;
						}
						awaiter2 = _003C_003E4__this._guildRepository.GetDefendersAsync(_003C_003E4__this.GuildId).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CLoadDefenders_003Ed__121 _003CLoadDefenders_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<List<GuildMember>>, _003CLoadDefenders_003Ed__121>(ref awaiter2, ref _003CLoadDefenders_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<List<GuildMember>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter2.GetResult();
					_003Cdefenders_003E5__1 = _003C_003Es__3;
					_003C_003Es__3 = null;
					_003C_003E4__this.Defenders = new ObservableCollection<GuildMember>(_003Cdefenders_003E5__1);
					awaiter = _003C_003E4__this._guildRepository.GetMainDefendersAsync(_003C_003E4__this.GuildId).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter;
						_003CLoadDefenders_003Ed__121 _003CLoadDefenders_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<List<GuildMember>>, _003CLoadDefenders_003Ed__121>(ref awaiter, ref _003CLoadDefenders_003Ed__);
						return;
					}
					goto IL_0135;
					IL_0135:
					_003C_003Es__4 = awaiter.GetResult();
					_003CmainDefenders_003E5__2 = _003C_003Es__4;
					_003C_003Es__4 = null;
					_003C_003E4__this.MainDefenders = new ObservableCollection<GuildMember>(_003CmainDefenders_003E5__2);
					_003Cdefenders_003E5__1 = null;
					_003CmainDefenders_003E5__2 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					Console.WriteLine($"LoadDefenders error: {_003Cex_003E5__5}");
				}
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
	private sealed class _003CLoadSquadData_003Ed__117 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public GuildWarsViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00fc;
				}
				_003C_003Es__2 = 0;
				try
				{
					_003C_003E4__this.ActiveSquad?.Dispose();
					_003C_003E4__this.ActiveSquad = ActivatorUtilities.CreateInstance<SpiritSquadViewModel>(_003C_003E4__this._serviceProvider, global::System.Array.Empty<object>());
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
					goto IL_006a;
				}
				goto end_IL_0007;
				IL_00fc:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine($"Error loading squad: {_003Cex_003E5__3}");
				_003C_003E4__this.ActiveSquad = null;
				result = false;
				goto end_IL_0007;
				IL_006a:
				int num2 = _003C_003Es__2;
				if (num2 == 1)
				{
					_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
					awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to load squad data").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CLoadSquadData_003Ed__117 _003CLoadSquadData_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadSquadData_003Ed__117>(ref awaiter, ref _003CLoadSquadData_003Ed__);
						return;
					}
					goto IL_00fc;
				}
				_003C_003Es__1 = null;
				throw null;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(exception);
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

	[CompilerGenerated]
	private sealed class _003CLoadWarHistory_003Ed__118 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildWarsViewModel _003C_003E4__this;

		private List<GuildWarHistory> _003Chistory_003E5__1;

		private List<GuildWarHistory> _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<List<GuildWarHistory>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<List<GuildWarHistory>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._guildRepository.GetGuildWarHistoryAsync(_003C_003E4__this.GuildId, 10).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadWarHistory_003Ed__118 _003CLoadWarHistory_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<List<GuildWarHistory>>, _003CLoadWarHistory_003Ed__118>(ref awaiter, ref _003CLoadWarHistory_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<List<GuildWarHistory>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Chistory_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					_003C_003E4__this.WarHistory = new ObservableCollection<GuildWarHistory>(_003Chistory_003E5__1);
					_003Chistory_003E5__1 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine($"LoadWarHistory error: {_003Cex_003E5__3}");
				}
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
	private sealed class _003CProcessGuildWarBattleResults_003Ed__128 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleResultDTO battleResult;

		public BattleLaunchRequest battleRequest;

		public string defendingGuildId;

		public string defendingGuildName;

		public GuildWarsViewModel _003C_003E4__this;

		private Result<ProcessWarBattleResultData> _003Cresult_003E5__1;

		private ProcessWarBattleResultData _003Cdata_003E5__2;

		private Result<ProcessWarBattleResultData> _003C_003Es__3;

		private string _003CcrystalNote_003E5__4;

		private string _003Cmessage_003E5__5;

		private GuildWarProgress _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter<Result<ProcessWarBattleResultData>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private TaskAwaiter<GuildWarProgress?> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0216: Unknown result type (might be due to invalid IL or missing references)
			//IL_021b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0223: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02be: Unknown result type (might be due to invalid IL or missing references)
			//IL_0469: Unknown result type (might be due to invalid IL or missing references)
			//IL_046e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0476: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0591: Unknown result type (might be due to invalid IL or missing references)
			//IL_0596: Unknown result type (might be due to invalid IL or missing references)
			//IL_059e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0617: Unknown result type (might be due to invalid IL or missing references)
			//IL_061c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0624: Unknown result type (might be due to invalid IL or missing references)
			//IL_05de: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0278: Unknown result type (might be due to invalid IL or missing references)
			//IL_027d: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04be: Unknown result type (might be due to invalid IL or missing references)
			//IL_05f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_05fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0292: Unknown result type (might be due to invalid IL or missing references)
			//IL_0294: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0430: Unknown result type (might be due to invalid IL or missing references)
			//IL_0435: Unknown result type (might be due to invalid IL or missing references)
			//IL_0558: Unknown result type (might be due to invalid IL or missing references)
			//IL_055d: Unknown result type (might be due to invalid IL or missing references)
			//IL_044a: Unknown result type (might be due to invalid IL or missing references)
			//IL_044c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0572: Unknown result type (might be due to invalid IL or missing references)
			//IL_0574: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 6u)
				{
				}
				try
				{
					TaskAwaiter<Result<ProcessWarBattleResultData>> awaiter7;
					TaskAwaiter awaiter6;
					TaskAwaiter awaiter5;
					TaskAwaiter awaiter4;
					TaskAwaiter awaiter3;
					TaskAwaiter<GuildWarProgress> awaiter2;
					TaskAwaiter awaiter;
					switch (num)
					{
					default:
						if (!string.IsNullOrEmpty(battleRequest.OpponentPlayerId))
						{
							awaiter7 = _003C_003E4__this._processWarBattleResultUseCase.ExecuteAsync(new ProcessWarBattleResultRequest(_003C_003E4__this.CurrentGuild.ID, defendingGuildId, _003C_003E4__this.CurrentGuild?.CurrentWarId ?? string.Empty, _003C_003E4__this.Player?.PlayerID ?? string.Empty, battleRequest.OpponentPlayerId, battleRequest.OpponentLevel, battleResult.Victory, battleResult.OpponentLevel, battleResult.LivingSpiritsCount, battleResult.TotalHealthPercentage, battleRequest.PreCommittedScorePenalty)).GetAwaiter();
							if (!awaiter7.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter7;
								_003CProcessGuildWarBattleResults_003Ed__128 _003CProcessGuildWarBattleResults_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<ProcessWarBattleResultData>>, _003CProcessGuildWarBattleResults_003Ed__128>(ref awaiter7, ref _003CProcessGuildWarBattleResults_003Ed__);
								return;
							}
							goto IL_017c;
						}
						goto end_IL_0011;
					case 0:
						awaiter7 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<ProcessWarBattleResultData>>);
						num = (_003C_003E1__state = -1);
						goto IL_017c;
					case 1:
						awaiter6 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0232;
					case 2:
						awaiter5 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_02cd;
					case 3:
						awaiter4 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0485;
					case 4:
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_050e;
					case 5:
						awaiter2 = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter<GuildWarProgress>);
						num = (_003C_003E1__state = -1);
						goto IL_05ad;
					case 6:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_050e:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						goto IL_0517;
						IL_0232:
						((TaskAwaiter)(ref awaiter6)).GetResult();
						goto end_IL_0011;
						IL_05ad:
						_003C_003Es__6 = awaiter2.GetResult();
						_003C_003E4__this.CurrentProgress = _003C_003Es__6;
						_003C_003Es__6 = null;
						awaiter = _003C_003E4__this.LoadBucketOpponents().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 6);
							_003C_003Eu__2 = awaiter;
							_003CProcessGuildWarBattleResults_003Ed__128 _003CProcessGuildWarBattleResults_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessGuildWarBattleResults_003Ed__128>(ref awaiter, ref _003CProcessGuildWarBattleResults_003Ed__);
							return;
						}
						break;
						IL_0517:
						awaiter2 = _003C_003E4__this._guildRepository.GetWarProgressAsync(_003C_003E4__this.GuildId, defendingGuildId, _003C_003E4__this.CurrentGuild?.CurrentWarId ?? string.Empty).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 5);
							_003C_003Eu__3 = awaiter2;
							_003CProcessGuildWarBattleResults_003Ed__128 _003CProcessGuildWarBattleResults_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<GuildWarProgress>, _003CProcessGuildWarBattleResults_003Ed__128>(ref awaiter2, ref _003CProcessGuildWarBattleResults_003Ed__);
							return;
						}
						goto IL_05ad;
						IL_017c:
						_003C_003Es__3 = awaiter7.GetResult();
						_003Cresult_003E5__1 = _003C_003Es__3;
						_003C_003Es__3 = null;
						if (!_003Cresult_003E5__1.Success)
						{
							awaiter6 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__1.ErrorMessage ?? "Battle processing failed.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter6)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter6;
								_003CProcessGuildWarBattleResults_003Ed__128 _003CProcessGuildWarBattleResults_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessGuildWarBattleResults_003Ed__128>(ref awaiter6, ref _003CProcessGuildWarBattleResults_003Ed__);
								return;
							}
							goto IL_0232;
						}
						_003Cdata_003E5__2 = _003Cresult_003E5__1.Data;
						awaiter5 = _003C_003E4__this.ShowBattleSummary(battleResult, _003Cdata_003E5__2.PersonalRewards, battleRequest, defendingGuildName).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter5;
							_003CProcessGuildWarBattleResults_003Ed__128 _003CProcessGuildWarBattleResults_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessGuildWarBattleResults_003Ed__128>(ref awaiter5, ref _003CProcessGuildWarBattleResults_003Ed__);
							return;
						}
						goto IL_02cd;
						IL_02cd:
						((TaskAwaiter)(ref awaiter5)).GetResult();
						if (battleResult.Victory)
						{
							_003CcrystalNote_003E5__4 = (_003Cdata_003E5__2.WasCapped ? " (hourly cap reached)" : string.Empty);
							_003Cmessage_003E5__5 = $"Victory! Defeated {battleRequest.DefenderName}.\nAwarded {_003Cdata_003E5__2.CrystalsAwarded} crystals to your guild{_003CcrystalNote_003E5__4}!";
							if (_003Cdata_003E5__2.PersonalRewards != null)
							{
								_003Cmessage_003E5__5 += $"\n\nPersonal Rewards:\n+{_003Cdata_003E5__2.PersonalRewards.Experience} EXP\n+{_003Cdata_003E5__2.PersonalRewards.Gold} Gold";
							}
							awaiter4 = _003C_003E4__this._navigationService.ShowAlertAsync("Guild War Victory!", _003Cmessage_003E5__5).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__2 = awaiter4;
								_003CProcessGuildWarBattleResults_003Ed__128 _003CProcessGuildWarBattleResults_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessGuildWarBattleResults_003Ed__128>(ref awaiter4, ref _003CProcessGuildWarBattleResults_003Ed__);
								return;
							}
							goto IL_0485;
						}
						awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Defeat", "You were defeated. The defender's guild gains crystals.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 4);
							_003C_003Eu__2 = awaiter3;
							_003CProcessGuildWarBattleResults_003Ed__128 _003CProcessGuildWarBattleResults_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessGuildWarBattleResults_003Ed__128>(ref awaiter3, ref _003CProcessGuildWarBattleResults_003Ed__);
							return;
						}
						goto IL_050e;
						IL_0485:
						((TaskAwaiter)(ref awaiter4)).GetResult();
						_003CcrystalNote_003E5__4 = null;
						_003Cmessage_003E5__5 = null;
						goto IL_0517;
					}
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003C_003E4__this.NotifyCrystalPropertiesChanged();
					_003Cresult_003E5__1 = null;
					_003Cdata_003E5__2 = null;
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__7 = ex;
					Console.WriteLine($"Error processing guild war battle results: {_003Cex_003E5__7}");
				}
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
	private sealed class _003CRaidGuild_003Ed__126 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildWarTargetModel target;

		public GuildWarsViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0091;
				}
				if (target != null)
				{
					awaiter = _003C_003E4__this.RaidTargetAsync(target.Id, target.Name).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CRaidGuild_003Ed__126 _003CRaidGuild_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRaidGuild_003Ed__126>(ref awaiter, ref _003CRaidGuild_003Ed__);
						return;
					}
					goto IL_0091;
				}
				goto end_IL_0007;
				IL_0091:
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
	private sealed class _003CRaidTargetAsync_003Ed__132 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string defendingGuildId;

		public string defendingGuildName;

		public GuildWarsViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private string _003CplayerId_003E5__3;

		private GuildWarProgress _003Cprogress_003E5__4;

		private int _003CraidsLeft_003E5__5;

		private bool _003Cconfirmed_003E5__6;

		private Result<RaidCrystalsResult> _003Cresult_003E5__7;

		private RaidCrystalsResult _003Cdata_003E5__8;

		private string _003Cmessage_003E5__9;

		private GuildWarProgress _003C_003Es__10;

		private bool _003C_003Es__11;

		private Result<RaidCrystalsResult> _003C_003Es__12;

		private GuildWarProgress _003C_003Es__13;

		private global::System.Exception _003Cex_003E5__14;

		private TaskAwaiter<GuildWarProgress?> _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private TaskAwaiter<Result<RaidCrystalsResult>> _003C_003Eu__3;

		private TaskAwaiter _003C_003Eu__4;

		private void MoveNext()
		{
			//IL_06ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0708: Unknown result type (might be due to invalid IL or missing references)
			//IL_070a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0727: Unknown result type (might be due to invalid IL or missing references)
			//IL_072c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0734: Unknown result type (might be due to invalid IL or missing references)
			//IL_0148: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_024f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0254: Unknown result type (might be due to invalid IL or missing references)
			//IL_025c: Unknown result type (might be due to invalid IL or missing references)
			//IL_031d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0322: Unknown result type (might be due to invalid IL or missing references)
			//IL_032a: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0523: Unknown result type (might be due to invalid IL or missing references)
			//IL_0528: Unknown result type (might be due to invalid IL or missing references)
			//IL_0530: Unknown result type (might be due to invalid IL or missing references)
			//IL_05c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_05c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_0647: Unknown result type (might be due to invalid IL or missing references)
			//IL_064c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0654: Unknown result type (might be due to invalid IL or missing references)
			//IL_060e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0613: Unknown result type (might be due to invalid IL or missing references)
			//IL_0628: Unknown result type (might be due to invalid IL or missing references)
			//IL_062a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0216: Unknown result type (might be due to invalid IL or missing references)
			//IL_021b: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_039a: Unknown result type (might be due to invalid IL or missing references)
			//IL_039f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0230: Unknown result type (might be due to invalid IL or missing references)
			//IL_0232: Unknown result type (might be due to invalid IL or missing references)
			//IL_0504: Unknown result type (might be due to invalid IL or missing references)
			//IL_0506: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0588: Unknown result type (might be due to invalid IL or missing references)
			//IL_058d: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_05a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_05a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0300: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 7u || (!string.IsNullOrEmpty(_003C_003E4__this.GuildId) && !string.IsNullOrEmpty(defendingGuildId)))
				{
					try
					{
						TaskAwaiter awaiter;
						if ((uint)num > 6u)
						{
							if (num == 7)
							{
								awaiter = _003C_003Eu__4;
								_003C_003Eu__4 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0743;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter<GuildWarProgress> awaiter8;
							TaskAwaiter<bool> awaiter7;
							TaskAwaiter<Result<RaidCrystalsResult>> awaiter6;
							TaskAwaiter awaiter5;
							TaskAwaiter awaiter4;
							TaskAwaiter<GuildWarProgress> awaiter3;
							TaskAwaiter awaiter2;
							switch (num)
							{
							default:
								_003C_003E4__this.IsLoading = true;
								_003CplayerId_003E5__3 = _003C_003E4__this.Player?.PlayerID ?? string.Empty;
								awaiter8 = _003C_003E4__this._guildRepository.GetWarProgressAsync(_003C_003E4__this.GuildId, defendingGuildId, _003C_003E4__this.CurrentGuild?.CurrentWarId ?? string.Empty).GetAwaiter();
								if (!awaiter8.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter8;
									_003CRaidTargetAsync_003Ed__132 _003CRaidTargetAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<GuildWarProgress>, _003CRaidTargetAsync_003Ed__132>(ref awaiter8, ref _003CRaidTargetAsync_003Ed__);
									return;
								}
								goto IL_0163;
							case 0:
								awaiter8 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<GuildWarProgress>);
								num = (_003C_003E1__state = -1);
								goto IL_0163;
							case 1:
								awaiter7 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter<bool>);
								num = (_003C_003E1__state = -1);
								goto IL_026b;
							case 2:
								awaiter6 = _003C_003Eu__3;
								_003C_003Eu__3 = default(TaskAwaiter<Result<RaidCrystalsResult>>);
								num = (_003C_003E1__state = -1);
								goto IL_0339;
							case 3:
								awaiter5 = _003C_003Eu__4;
								_003C_003Eu__4 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_03ef;
							case 4:
								awaiter4 = _003C_003Eu__4;
								_003C_003Eu__4 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_053f;
							case 5:
								awaiter3 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<GuildWarProgress>);
								num = (_003C_003E1__state = -1);
								goto IL_05dd;
							case 6:
								{
									awaiter2 = _003C_003Eu__4;
									_003C_003Eu__4 = default(TaskAwaiter);
									num = (_003C_003E1__state = -1);
									break;
								}
								IL_0163:
								_003C_003Es__10 = awaiter8.GetResult();
								_003Cprogress_003E5__4 = _003C_003Es__10;
								_003C_003Es__10 = null;
								_003CraidsLeft_003E5__5 = 1 - (_003Cprogress_003E5__4?.GetEffectiveRaidCount(_003CplayerId_003E5__3) ?? 0);
								awaiter7 = _003C_003E4__this._navigationService.ShowConfirmationAsync("Raid Crystals", $"Raid {defendingGuildName}'s crystal storage?\n({_003CraidsLeft_003E5__5} raid(s) remaining this hour)").GetAwaiter();
								if (!awaiter7.IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter7;
									_003CRaidTargetAsync_003Ed__132 _003CRaidTargetAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CRaidTargetAsync_003Ed__132>(ref awaiter7, ref _003CRaidTargetAsync_003Ed__);
									return;
								}
								goto IL_026b;
								IL_05dd:
								_003C_003Es__13 = awaiter3.GetResult();
								_003C_003E4__this.CurrentProgress = _003C_003Es__13;
								_003C_003Es__13 = null;
								awaiter2 = _003C_003E4__this.LoadBucketOpponents().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 6);
									_003C_003Eu__4 = awaiter2;
									_003CRaidTargetAsync_003Ed__132 _003CRaidTargetAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRaidTargetAsync_003Ed__132>(ref awaiter2, ref _003CRaidTargetAsync_003Ed__);
									return;
								}
								break;
								IL_0339:
								_003C_003Es__12 = awaiter6.GetResult();
								_003Cresult_003E5__7 = _003C_003Es__12;
								_003C_003Es__12 = null;
								if (!_003Cresult_003E5__7.Success)
								{
									awaiter5 = _003C_003E4__this._navigationService.ShowAlertAsync("Cannot Raid", _003Cresult_003E5__7.ErrorMessage ?? string.Empty).GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
									{
										num = (_003C_003E1__state = 3);
										_003C_003Eu__4 = awaiter5;
										_003CRaidTargetAsync_003Ed__132 _003CRaidTargetAsync_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRaidTargetAsync_003Ed__132>(ref awaiter5, ref _003CRaidTargetAsync_003Ed__);
										return;
									}
									goto IL_03ef;
								}
								_003Cdata_003E5__8 = _003Cresult_003E5__7.Data;
								_003Cmessage_003E5__9 = $"You raided {_003Cdata_003E5__8.CrystalsGained} crystals from {defendingGuildName}!";
								if (_003Cdata_003E5__8.RaidsRemainingThisHour > 0)
								{
									_003Cmessage_003E5__9 += $"\n{_003Cdata_003E5__8.RaidsRemainingThisHour} raid(s) remaining this hour.";
								}
								awaiter4 = _003C_003E4__this._navigationService.ShowAlertAsync("Success!", _003Cmessage_003E5__9).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
								{
									num = (_003C_003E1__state = 4);
									_003C_003Eu__4 = awaiter4;
									_003CRaidTargetAsync_003Ed__132 _003CRaidTargetAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRaidTargetAsync_003Ed__132>(ref awaiter4, ref _003CRaidTargetAsync_003Ed__);
									return;
								}
								goto IL_053f;
								IL_026b:
								_003C_003Es__11 = awaiter7.GetResult();
								_003Cconfirmed_003E5__6 = _003C_003Es__11;
								if (_003Cconfirmed_003E5__6)
								{
									awaiter6 = _003C_003E4__this._raidCrystalsUseCase.ExecuteAsync(new RaidCrystalsRequest(_003C_003E4__this.GuildId, defendingGuildId, _003C_003E4__this.CurrentGuild?.CurrentWarId ?? string.Empty, _003CplayerId_003E5__3)).GetAwaiter();
									if (!awaiter6.IsCompleted)
									{
										num = (_003C_003E1__state = 2);
										_003C_003Eu__3 = awaiter6;
										_003CRaidTargetAsync_003Ed__132 _003CRaidTargetAsync_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<RaidCrystalsResult>>, _003CRaidTargetAsync_003Ed__132>(ref awaiter6, ref _003CRaidTargetAsync_003Ed__);
										return;
									}
									goto IL_0339;
								}
								goto end_IL_0055;
								IL_053f:
								((TaskAwaiter)(ref awaiter4)).GetResult();
								awaiter3 = _003C_003E4__this._guildRepository.GetWarProgressAsync(_003C_003E4__this.GuildId, defendingGuildId, _003C_003E4__this.CurrentGuild?.CurrentWarId ?? string.Empty).GetAwaiter();
								if (!awaiter3.IsCompleted)
								{
									num = (_003C_003E1__state = 5);
									_003C_003Eu__1 = awaiter3;
									_003CRaidTargetAsync_003Ed__132 _003CRaidTargetAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<GuildWarProgress>, _003CRaidTargetAsync_003Ed__132>(ref awaiter3, ref _003CRaidTargetAsync_003Ed__);
									return;
								}
								goto IL_05dd;
								IL_03ef:
								((TaskAwaiter)(ref awaiter5)).GetResult();
								goto end_IL_0055;
							}
							((TaskAwaiter)(ref awaiter2)).GetResult();
							_003C_003E4__this.NotifyCrystalPropertiesChanged();
							_003CplayerId_003E5__3 = null;
							_003Cprogress_003E5__4 = null;
							_003Cresult_003E5__7 = null;
							_003Cdata_003E5__8 = null;
							_003Cmessage_003E5__9 = null;
							goto IL_06b0;
							end_IL_0055:;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
							goto IL_06b0;
						}
						goto end_IL_003a;
						IL_06b0:
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_0787;
						}
						_003Cex_003E5__14 = (global::System.Exception)_003C_003Es__1;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to raid crystals.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 7);
							_003C_003Eu__4 = awaiter;
							_003CRaidTargetAsync_003Ed__132 _003CRaidTargetAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRaidTargetAsync_003Ed__132>(ref awaiter, ref _003CRaidTargetAsync_003Ed__);
							return;
						}
						goto IL_0743;
						IL_0743:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine($"RaidTarget error: {_003Cex_003E5__14}");
						_003Cex_003E5__14 = null;
						goto IL_0787;
						IL_0787:
						_003C_003Es__1 = null;
						end_IL_003a:;
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsLoading = false;
						}
					}
				}
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
	private sealed class _003CRefreshData_003Ed__136 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildWarsViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this.LoadDataAsync(_003C_003E4__this.GuildId).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CRefreshData_003Ed__136 _003CRefreshData_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRefreshData_003Ed__136>(ref awaiter, ref _003CRefreshData_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
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
	private sealed class _003CRefreshDefense_003Ed__131 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildWarsViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private RefreshDefenseRequest _003Crequest_003E5__3;

		private Result<DefenseRefreshResponse> _003Cresult_003E5__4;

		private Result<DefenseRefreshResponse> _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<Result<DefenseRefreshResponse>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0307: Unknown result type (might be due to invalid IL or missing references)
			//IL_0309: Unknown result type (might be due to invalid IL or missing references)
			//IL_0326: Unknown result type (might be due to invalid IL or missing references)
			//IL_032b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0333: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0234: Unknown result type (might be due to invalid IL or missing references)
			//IL_0239: Unknown result type (might be due to invalid IL or missing references)
			//IL_0241: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0200: Unknown result type (might be due to invalid IL or missing references)
			//IL_0280: Unknown result type (might be due to invalid IL or missing references)
			//IL_0215: Unknown result type (might be due to invalid IL or missing references)
			//IL_0217: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_0199: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 3u || (!string.IsNullOrEmpty(_003C_003E4__this.GuildId) && _003C_003E4__this.Player != null))
				{
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
								goto IL_0342;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter<Result<DefenseRefreshResponse>> awaiter4;
							TaskAwaiter awaiter3;
							TaskAwaiter awaiter2;
							switch (num)
							{
							default:
								_003C_003E4__this.IsLoading = true;
								_003Crequest_003E5__3 = new RefreshDefenseRequest(_003C_003E4__this.GuildId, _003C_003E4__this.Player.PlayerID);
								awaiter4 = _003C_003E4__this._refreshDefenseUseCase.ExecuteAsync(_003Crequest_003E5__3).GetAwaiter();
								if (!awaiter4.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter4;
									_003CRefreshDefense_003Ed__131 _003CRefreshDefense_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<DefenseRefreshResponse>>, _003CRefreshDefense_003Ed__131>(ref awaiter4, ref _003CRefreshDefense_003Ed__);
									return;
								}
								goto IL_0117;
							case 0:
								awaiter4 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<Result<DefenseRefreshResponse>>);
								num = (_003C_003E1__state = -1);
								goto IL_0117;
							case 1:
								awaiter3 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_01d4;
							case 2:
								{
									awaiter2 = _003C_003Eu__2;
									_003C_003Eu__2 = default(TaskAwaiter);
									num = (_003C_003E1__state = -1);
									break;
								}
								IL_01d4:
								((TaskAwaiter)(ref awaiter3)).GetResult();
								goto end_IL_003d;
								IL_0117:
								_003C_003Es__5 = awaiter4.GetResult();
								_003Cresult_003E5__4 = _003C_003Es__5;
								_003C_003Es__5 = null;
								if (!_003Cresult_003E5__4.Success)
								{
									awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Cannot Refresh", _003Cresult_003E5__4?.ErrorMessage ?? string.Empty).GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
									{
										num = (_003C_003E1__state = 1);
										_003C_003Eu__2 = awaiter3;
										_003CRefreshDefense_003Ed__131 _003CRefreshDefense_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRefreshDefense_003Ed__131>(ref awaiter3, ref _003CRefreshDefense_003Ed__);
										return;
									}
									goto IL_01d4;
								}
								awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Defense Refreshed", "Your defense is active for 8 hours. (Cost: 5 EP.)").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__2 = awaiter2;
									_003CRefreshDefense_003Ed__131 _003CRefreshDefense_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRefreshDefense_003Ed__131>(ref awaiter2, ref _003CRefreshDefense_003Ed__);
									return;
								}
								break;
							}
							((TaskAwaiter)(ref awaiter2)).GetResult();
							if (_003Cresult_003E5__4.Data != null)
							{
								_003C_003E4__this.StartDefenseTimer(_003Cresult_003E5__4.Data.NewExpiryTime);
							}
							_003Crequest_003E5__3 = null;
							_003Cresult_003E5__4 = null;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
						}
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_0386;
						}
						_003Cex_003E5__6 = (global::System.Exception)_003C_003Es__1;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to refresh defense.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__2 = awaiter;
							_003CRefreshDefense_003Ed__131 _003CRefreshDefense_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRefreshDefense_003Ed__131>(ref awaiter, ref _003CRefreshDefense_003Ed__);
							return;
						}
						goto IL_0342;
						IL_0342:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine($"RefreshDefense error: {_003Cex_003E5__6}");
						_003Cex_003E5__6 = null;
						goto IL_0386;
						IL_0386:
						_003C_003Es__1 = null;
						end_IL_003d:;
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsLoading = false;
						}
					}
				}
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
	private sealed class _003CRegisterAsWarMember_003Ed__130 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildWarsViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private Result<RegisterAsWarMemberResponse> _003Cresult_003E5__3;

		private string _003Cmessage_003E5__4;

		private Result<RegisterAsWarMemberResponse> _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<Result<RegisterAsWarMemberResponse>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_033f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0344: Unknown result type (might be due to invalid IL or missing references)
			//IL_0359: Unknown result type (might be due to invalid IL or missing references)
			//IL_035b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0378: Unknown result type (might be due to invalid IL or missing references)
			//IL_037d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0385: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0286: Unknown result type (might be due to invalid IL or missing references)
			//IL_028b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0293: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_024d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0252: Unknown result type (might be due to invalid IL or missing references)
			//IL_0267: Unknown result type (might be due to invalid IL or missing references)
			//IL_0269: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 3u || !string.IsNullOrEmpty(_003C_003E4__this.GuildId))
				{
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
								goto IL_0394;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter<Result<RegisterAsWarMemberResponse>> awaiter4;
							TaskAwaiter awaiter3;
							TaskAwaiter awaiter2;
							switch (num)
							{
							default:
								_003C_003E4__this.IsLoading = true;
								awaiter4 = _003C_003E4__this._registerAsWarMemberUseCase.ExecuteAsync(new RegisterAsWarMemberRequest(_003C_003E4__this.GuildId)).GetAwaiter();
								if (!awaiter4.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter4;
									_003CRegisterAsWarMember_003Ed__130 _003CRegisterAsWarMember_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<RegisterAsWarMemberResponse>>, _003CRegisterAsWarMember_003Ed__130>(ref awaiter4, ref _003CRegisterAsWarMember_003Ed__);
									return;
								}
								goto IL_00e5;
							case 0:
								awaiter4 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<Result<RegisterAsWarMemberResponse>>);
								num = (_003C_003E1__state = -1);
								goto IL_00e5;
							case 1:
								awaiter3 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_019b;
							case 2:
								{
									awaiter2 = _003C_003Eu__2;
									_003C_003Eu__2 = default(TaskAwaiter);
									num = (_003C_003E1__state = -1);
									break;
								}
								IL_019b:
								((TaskAwaiter)(ref awaiter3)).GetResult();
								goto end_IL_002a;
								IL_00e5:
								_003C_003Es__5 = awaiter4.GetResult();
								_003Cresult_003E5__3 = _003C_003Es__5;
								_003C_003Es__5 = null;
								if (!_003Cresult_003E5__3.Success)
								{
									awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Registration Failed", _003Cresult_003E5__3.ErrorMessage ?? "Unknown error").GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
									{
										num = (_003C_003E1__state = 1);
										_003C_003Eu__2 = awaiter3;
										_003CRegisterAsWarMember_003Ed__130 _003CRegisterAsWarMember_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRegisterAsWarMember_003Ed__130>(ref awaiter3, ref _003CRegisterAsWarMember_003Ed__);
										return;
									}
									goto IL_019b;
								}
								_003C_003E4__this.IsRegisteredDefender = _003Cresult_003E5__3.Data?.IsNowRegistered ?? false;
								if (_003C_003E4__this.IsRegisteredDefender)
								{
									_003C_003E4__this._updateBattleTaskProgressUseCase.ExecuteAsync(new UpdateBattleTaskProgressRequest(new BattleTaskType[1] { BattleTaskType.RegisterAsDefender }));
								}
								_003C_003E4__this.IsDefender = _003C_003E4__this.IsRegisteredDefender;
								_003Cmessage_003E5__4 = (_003C_003E4__this.IsRegisteredDefender ? "You are registered as a defender for the upcoming war!" : "You have withdrawn from the war.");
								awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("War Registration", _003Cmessage_003E5__4).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__2 = awaiter2;
									_003CRegisterAsWarMember_003Ed__130 _003CRegisterAsWarMember_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRegisterAsWarMember_003Ed__130>(ref awaiter2, ref _003CRegisterAsWarMember_003Ed__);
									return;
								}
								break;
							}
							((TaskAwaiter)(ref awaiter2)).GetResult();
							((ObservableObject)_003C_003E4__this).OnPropertyChanged("RegisterWarMemberButtonText");
							((ObservableObject)_003C_003E4__this).OnPropertyChanged("ActiveMemberRatio");
							((ObservableObject)_003C_003E4__this).OnPropertyChanged("ShowRefreshDefenseButton");
							_003Cresult_003E5__3 = null;
							_003Cmessage_003E5__4 = null;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
						}
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_03d8;
						}
						_003Cex_003E5__6 = (global::System.Exception)_003C_003Es__1;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to update war registration.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__2 = awaiter;
							_003CRegisterAsWarMember_003Ed__130 _003CRegisterAsWarMember_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRegisterAsWarMember_003Ed__130>(ref awaiter, ref _003CRegisterAsWarMember_003Ed__);
							return;
						}
						goto IL_0394;
						IL_0394:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine($"RegisterAsWarMember error: {_003Cex_003E5__6}");
						_003Cex_003E5__6 = null;
						goto IL_03d8;
						IL_03d8:
						_003C_003Es__1 = null;
						end_IL_002a:;
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsLoading = false;
						}
					}
				}
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
	private sealed class _003CRemoveDefender_003Ed__137 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildWarsViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private bool _003Cconfirmed_003E5__3;

		private bool _003Csuccess_003E5__4;

		private bool _003C_003Es__5;

		private bool _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_039e: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_0237: Unknown result type (might be due to invalid IL or missing references)
			//IL_023c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0244: Unknown result type (might be due to invalid IL or missing references)
			//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_02af: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0325: Unknown result type (might be due to invalid IL or missing references)
			//IL_032a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0332: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0271: Unknown result type (might be due to invalid IL or missing references)
			//IL_0276: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0203: Unknown result type (might be due to invalid IL or missing references)
			//IL_028b: Unknown result type (might be due to invalid IL or missing references)
			//IL_028d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_0306: Unknown result type (might be due to invalid IL or missing references)
			//IL_0308: Unknown result type (might be due to invalid IL or missing references)
			//IL_0218: Unknown result type (might be due to invalid IL or missing references)
			//IL_021a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 5u || (!string.IsNullOrEmpty(_003C_003E4__this.GuildId) && _003C_003E4__this.Player != null))
				{
					try
					{
						TaskAwaiter awaiter;
						if ((uint)num > 4u)
						{
							if (num == 5)
							{
								awaiter = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_03f3;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter<bool> awaiter6;
							TaskAwaiter<bool> awaiter5;
							TaskAwaiter awaiter4;
							TaskAwaiter awaiter3;
							TaskAwaiter awaiter2;
							switch (num)
							{
							default:
								_003C_003E4__this.IsLoading = true;
								awaiter6 = _003C_003E4__this._navigationService.ShowConfirmationAsync("Remove Defender", "Are you sure you want to stop being a defender?").GetAwaiter();
								if (!awaiter6.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter6;
									_003CRemoveDefender_003Ed__137 _003CRemoveDefender_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CRemoveDefender_003Ed__137>(ref awaiter6, ref _003CRemoveDefender_003Ed__);
									return;
								}
								goto IL_010e;
							case 0:
								awaiter6 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<bool>);
								num = (_003C_003E1__state = -1);
								goto IL_010e;
							case 1:
								awaiter5 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<bool>);
								num = (_003C_003E1__state = -1);
								goto IL_01bb;
							case 2:
								awaiter4 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0253;
							case 3:
								awaiter3 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_02c6;
							case 4:
								{
									awaiter2 = _003C_003Eu__2;
									_003C_003Eu__2 = default(TaskAwaiter);
									num = (_003C_003E1__state = -1);
									break;
								}
								IL_01bb:
								_003C_003Es__6 = awaiter5.GetResult();
								_003Csuccess_003E5__4 = _003C_003Es__6;
								if (_003Csuccess_003E5__4)
								{
									awaiter4 = _003C_003E4__this._navigationService.ShowAlertAsync("Success!", "You are no longer a defender.").GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
									{
										num = (_003C_003E1__state = 2);
										_003C_003Eu__2 = awaiter4;
										_003CRemoveDefender_003Ed__137 _003CRemoveDefender_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRemoveDefender_003Ed__137>(ref awaiter4, ref _003CRemoveDefender_003Ed__);
										return;
									}
									goto IL_0253;
								}
								awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to remove defender status.").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 4);
									_003C_003Eu__2 = awaiter2;
									_003CRemoveDefender_003Ed__137 _003CRemoveDefender_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRemoveDefender_003Ed__137>(ref awaiter2, ref _003CRemoveDefender_003Ed__);
									return;
								}
								break;
								IL_010e:
								_003C_003Es__5 = awaiter6.GetResult();
								_003Cconfirmed_003E5__3 = _003C_003Es__5;
								if (_003Cconfirmed_003E5__3)
								{
									awaiter5 = _003C_003E4__this._guildRepository.RemoveDefenderAsync(_003C_003E4__this.GuildId, _003C_003E4__this.Player.PlayerID).GetAwaiter();
									if (!awaiter5.IsCompleted)
									{
										num = (_003C_003E1__state = 1);
										_003C_003Eu__1 = awaiter5;
										_003CRemoveDefender_003Ed__137 _003CRemoveDefender_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CRemoveDefender_003Ed__137>(ref awaiter5, ref _003CRemoveDefender_003Ed__);
										return;
									}
									goto IL_01bb;
								}
								goto end_IL_0058;
								IL_0253:
								((TaskAwaiter)(ref awaiter4)).GetResult();
								awaiter3 = _003C_003E4__this.LoadDataAsync(_003C_003E4__this.GuildId).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
								{
									num = (_003C_003E1__state = 3);
									_003C_003Eu__2 = awaiter3;
									_003CRemoveDefender_003Ed__137 _003CRemoveDefender_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRemoveDefender_003Ed__137>(ref awaiter3, ref _003CRemoveDefender_003Ed__);
									return;
								}
								goto IL_02c6;
								IL_02c6:
								((TaskAwaiter)(ref awaiter3)).GetResult();
								goto IL_0360;
							}
							((TaskAwaiter)(ref awaiter2)).GetResult();
							goto IL_0360;
							end_IL_0058:;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
							goto IL_0360;
						}
						goto end_IL_003d;
						IL_0360:
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_0437;
						}
						_003Cex_003E5__7 = (global::System.Exception)_003C_003Es__1;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "An error occurred while removing defender status.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 5);
							_003C_003Eu__2 = awaiter;
							_003CRemoveDefender_003Ed__137 _003CRemoveDefender_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRemoveDefender_003Ed__137>(ref awaiter, ref _003CRemoveDefender_003Ed__);
							return;
						}
						goto IL_03f3;
						IL_03f3:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine($"RemoveDefender error: {_003Cex_003E5__7}");
						_003Cex_003E5__7 = null;
						goto IL_0437;
						IL_0437:
						_003C_003Es__1 = null;
						end_IL_003d:;
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsLoading = false;
						}
					}
				}
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
	private sealed class _003CShowBattleSummary_003Ed__129 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleResultDTO battleResult;

		public BattleRewards rewards;

		public BattleLaunchRequest battleLaunchRequest;

		public string defendingGuildName;

		public GuildWarsViewModel _003C_003E4__this;

		private _003C_003Ec__DisplayClass129_0 _003C_003E8__1;

		private TaskAwaiter<object?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<object> awaiter;
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass129_0();
					_003C_003E8__1.battleResult = battleResult;
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003C_003E8__1.defendingGuildName = defendingGuildName;
					_003C_003E8__1.rewards = rewards;
					_003C_003E8__1.battleLaunchRequest = battleLaunchRequest;
					awaiter = _003C_003E4__this._popupService.ShowPopupAsync<BattleSummaryPopupViewModel>((Action<BattleSummaryPopupViewModel>)delegate(BattleSummaryPopupViewModel vm)
					{
						//IL_0207: Unknown result type (might be due to invalid IL or missing references)
						//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
						//IL_0211: Expected O, but got Unknown
						vm.PlayerSpirits = Enumerable.ToList<SpriteModelResultsRecord>(Enumerable.Select<SpiritBattleResult, SpriteModelResultsRecord>((global::System.Collections.Generic.IEnumerable<SpiritBattleResult>)_003C_003E8__1.battleResult.PlayerSpirits, (Func<SpiritBattleResult, SpriteModelResultsRecord>)((SpiritBattleResult spirit) => new SpriteModelResultsRecord(spirit.Image, spirit.Fainted ? "x.png" : "check.png", spirit.Fainted ? 0.3 : 1.0))));
						vm.EnemySpirits = Enumerable.ToList<SpriteModelResultsRecord>(Enumerable.Select<SpiritBattleResult, SpriteModelResultsRecord>((global::System.Collections.Generic.IEnumerable<SpiritBattleResult>)_003C_003E8__1.battleResult.EnemySpirits, (Func<SpiritBattleResult, SpriteModelResultsRecord>)((SpiritBattleResult spirit) => new SpriteModelResultsRecord(spirit.Image, spirit.Fainted ? "x.png" : "check.png", spirit.Fainted ? 0.3 : 1.0))));
						vm.IsGuildBattle = true;
						vm.PlayerGuildName = _003C_003E8__1._003C_003E4__this.CurrentGuild?.Name ?? "";
						vm.EnemyGuildname = _003C_003E8__1.defendingGuildName;
						vm.OutcomeImagePlayer = (_003C_003E8__1.battleResult.Victory ? "staricon.png" : "x.png");
						vm.OutcomeImageEnemy = ((!_003C_003E8__1.battleResult.Victory) ? "staricon.png" : "x.png");
						vm.OutcomeText = (_003C_003E8__1.battleResult.Victory ? "VICTORY!" : "DEFEAT");
						vm.EarnedEXP = _003C_003E8__1.rewards?.Experience ?? 0;
						vm.EarnedGold = _003C_003E8__1.rewards?.Gold ?? 0;
						vm.EarnedReputation = _003C_003E8__1.rewards?.Reputation ?? 0;
						vm.PlayerName = _003C_003E8__1._003C_003E4__this._playerStateService.GetCurrentPlayer()?.Playername;
						vm.EnemyName = _003C_003E8__1.battleLaunchRequest.DefenderName;
						vm.EnemyRank = _003C_003E8__1.battleLaunchRequest.OpponentLevel;
						vm.PlayerRank = _003C_003E8__1._003C_003E4__this._playerStateService.GetCurrentPlayer()?.PlayerLevel ?? 0;
						vm.BackGround = (_003C_003E8__1.battleResult.Victory ? ((Brush)Application.Current.Resources["GradientWinSummary"]) : ((Brush)Application.Current.Resources["GradientLossSummary"]));
						vm.TextColor = (_003C_003E8__1.battleResult.Victory ? Color.FromArgb("#027242") : Color.FromArgb("#721502"));
					}, default(CancellationToken)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CShowBattleSummary_003Ed__129 _003CShowBattleSummary_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CShowBattleSummary_003Ed__129>(ref awaiter, ref _003CShowBattleSummary_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<object>);
					num = (_003C_003E1__state = -1);
				}
				awaiter.GetResult();
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CToggleWarEnrollment_003Ed__140 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildWarsViewModel _003C_003E4__this;

		private Player _003Cplayer_003E5__1;

		private object _003C_003Es__2;

		private int _003C_003Es__3;

		private bool _003CnewState_003E5__4;

		private bool _003Cconfirmed_003E5__5;

		private bool _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0443: Unknown result type (might be due to invalid IL or missing references)
			//IL_0448: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_045d: Unknown result type (might be due to invalid IL or missing references)
			//IL_045f: Unknown result type (might be due to invalid IL or missing references)
			//IL_047d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0482: Unknown result type (might be due to invalid IL or missing references)
			//IL_048a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0204: Unknown result type (might be due to invalid IL or missing references)
			//IL_0209: Unknown result type (might be due to invalid IL or missing references)
			//IL_0211: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0311: Unknown result type (might be due to invalid IL or missing references)
			//IL_0316: Unknown result type (might be due to invalid IL or missing references)
			//IL_031e: Unknown result type (might be due to invalid IL or missing references)
			//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_026e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0273: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_0288: Unknown result type (might be due to invalid IL or missing references)
			//IL_028a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0391: Unknown result type (might be due to invalid IL or missing references)
			//IL_0396: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0108;
				}
				if ((uint)(num - 1) <= 4u)
				{
					goto IL_0116;
				}
				if (!string.IsNullOrEmpty(_003C_003E4__this.GuildId) && _003C_003E4__this.CurrentGuild != null)
				{
					_003Cplayer_003E5__1 = _003C_003E4__this._playerStateService.GetCurrentPlayer();
					Player player = _003Cplayer_003E5__1;
					if (player == null || player.GuildRole != GuildRole.Guildmaster)
					{
						Player player2 = _003Cplayer_003E5__1;
						if (player2 == null || player2.GuildRole != GuildRole.Vice_Guildmaster)
						{
							awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Permission Denied", "Only guild leaders can toggle war enrollment.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CToggleWarEnrollment_003Ed__140 _003CToggleWarEnrollment_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CToggleWarEnrollment_003Ed__140>(ref awaiter, ref _003CToggleWarEnrollment_003Ed__);
								return;
							}
							goto IL_0108;
						}
					}
					goto IL_0116;
				}
				goto end_IL_0007;
				IL_0116:
				try
				{
					TaskAwaiter awaiter2;
					if ((uint)(num - 1) > 3u)
					{
						if (num == 5)
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0499;
						}
						_003C_003Es__3 = 0;
					}
					try
					{
						TaskAwaiter<bool> awaiter6;
						TaskAwaiter<bool> awaiter5;
						TaskAwaiter awaiter4;
						TaskAwaiter awaiter3;
						switch (num)
						{
						default:
							_003C_003E4__this.IsLoading = true;
							_003CnewState_003E5__4 = !_003C_003E4__this.CurrentGuild.IsOpenToWar;
							awaiter6 = _003C_003E4__this._navigationService.ShowConfirmationAsync(_003CnewState_003E5__4 ? "Enroll in Guild Wars" : "Withdraw from Guild Wars", _003CnewState_003E5__4 ? "Your guild will join a strength bucket when matchmaking completes. Are you sure?" : "Your guild will not participate in the next war cycle. Are you sure? (You have time to enroll again up until matchmaking begins)").GetAwaiter();
							if (!awaiter6.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter6;
								_003CToggleWarEnrollment_003Ed__140 _003CToggleWarEnrollment_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CToggleWarEnrollment_003Ed__140>(ref awaiter6, ref _003CToggleWarEnrollment_003Ed__);
								return;
							}
							goto IL_0220;
						case 1:
							awaiter6 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							goto IL_0220;
						case 2:
							awaiter5 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							goto IL_02c4;
						case 3:
							awaiter4 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_032d;
						case 4:
							{
								awaiter3 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								break;
							}
							IL_02c4:
							awaiter5.GetResult();
							awaiter4 = _003C_003E4__this.LoadCurrentGuild().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__1 = awaiter4;
								_003CToggleWarEnrollment_003Ed__140 _003CToggleWarEnrollment_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CToggleWarEnrollment_003Ed__140>(ref awaiter4, ref _003CToggleWarEnrollment_003Ed__);
								return;
							}
							goto IL_032d;
							IL_032d:
							((TaskAwaiter)(ref awaiter4)).GetResult();
							((ObservableObject)_003C_003E4__this).OnPropertyChanged("IsOpenToWar");
							((ObservableObject)_003C_003E4__this).OnPropertyChanged("NoOpponentMessage");
							((ObservableObject)_003C_003E4__this).OnPropertyChanged("HasMatchedOpponent");
							awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Enrollment Updated", _003CnewState_003E5__4 ? "Your guild is now enrolled for Guild Wars!" : "Your guild has been withdrawn from Guild Wars.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 4);
								_003C_003Eu__1 = awaiter3;
								_003CToggleWarEnrollment_003Ed__140 _003CToggleWarEnrollment_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CToggleWarEnrollment_003Ed__140>(ref awaiter3, ref _003CToggleWarEnrollment_003Ed__);
								return;
							}
							break;
							IL_0220:
							_003C_003Es__6 = awaiter6.GetResult();
							_003Cconfirmed_003E5__5 = _003C_003Es__6;
							if (_003Cconfirmed_003E5__5)
							{
								awaiter5 = _003C_003E4__this._guildRepository.SetWarEnrollmentAsync(_003C_003E4__this.GuildId, _003CnewState_003E5__4).GetAwaiter();
								if (!awaiter5.IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__2 = awaiter5;
									_003CToggleWarEnrollment_003Ed__140 _003CToggleWarEnrollment_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CToggleWarEnrollment_003Ed__140>(ref awaiter5, ref _003CToggleWarEnrollment_003Ed__);
									return;
								}
								goto IL_02c4;
							}
							goto end_IL_0133;
						}
						((TaskAwaiter)(ref awaiter3)).GetResult();
						goto IL_0405;
						end_IL_0133:;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__2 = ex;
						_003C_003Es__3 = 1;
						goto IL_0405;
					}
					goto end_IL_0116;
					IL_0405:
					int num2 = _003C_003Es__3;
					if (num2 != 1)
					{
						goto IL_04dd;
					}
					_003Cex_003E5__7 = (global::System.Exception)_003C_003Es__2;
					awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to update war enrollment.").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 5);
						_003C_003Eu__1 = awaiter2;
						_003CToggleWarEnrollment_003Ed__140 _003CToggleWarEnrollment_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CToggleWarEnrollment_003Ed__140>(ref awaiter2, ref _003CToggleWarEnrollment_003Ed__);
						return;
					}
					goto IL_0499;
					IL_0499:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					Console.WriteLine($"ToggleWarEnrollment error: {_003Cex_003E5__7}");
					_003Cex_003E5__7 = null;
					goto IL_04dd;
					IL_04dd:
					_003C_003Es__2 = null;
					end_IL_0116:;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsLoading = false;
					}
				}
				goto end_IL_0007;
				IL_0108:
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
	private sealed class _003CViewDefenders_003Ed__138 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildWarsViewModel _003C_003E4__this;

		private string _003CdefendersList_003E5__1;

		private string _003CmainDefendersList_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_0218: Unknown result type (might be due to invalid IL or missing references)
			//IL_0220: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_009e;
				}
				TaskAwaiter awaiter2;
				if (num != 1)
				{
					if (((Collection<GuildMember>)(object)_003C_003E4__this.Defenders).Count == 0)
					{
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("No Defenders", "No guild members have signed up as defenders yet.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CViewDefenders_003Ed__138 _003CViewDefenders_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CViewDefenders_003Ed__138>(ref awaiter, ref _003CViewDefenders_003Ed__);
							return;
						}
						goto IL_009e;
					}
					_003CdefendersList_003E5__1 = string.Join("\n", Enumerable.Select<GuildMember, string>((global::System.Collections.Generic.IEnumerable<GuildMember>)_003C_003E4__this.Defenders, (Func<GuildMember, string>)((GuildMember d) => $"• {d.PlayerName} (Lvl {d.Level})")));
					_003CmainDefendersList_003E5__2 = ((((Collection<GuildMember>)(object)_003C_003E4__this.MainDefenders).Count > 0) ? ("\n\nPriority Defenders:\n" + string.Join("\n", Enumerable.Select<GuildMember, string>((global::System.Collections.Generic.IEnumerable<GuildMember>)_003C_003E4__this.MainDefenders, (Func<GuildMember, string>)((GuildMember d) => "★ " + d.PlayerName)))) : "");
					awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync($"Defenders ({((Collection<GuildMember>)(object)_003C_003E4__this.Defenders).Count}/{_003C_003E4__this.CurrentGuild?.MaxDefenders ?? 0})", _003CdefendersList_003E5__1 + _003CmainDefendersList_003E5__2).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter2;
						_003CViewDefenders_003Ed__138 _003CViewDefenders_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CViewDefenders_003Ed__138>(ref awaiter2, ref _003CViewDefenders_003Ed__);
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
				goto end_IL_0007;
				IL_009e:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CdefendersList_003E5__1 = null;
				_003CmainDefendersList_003E5__2 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CdefendersList_003E5__1 = null;
			_003CmainDefendersList_003E5__2 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CViewWarDetails_003Ed__134 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildWarHistory war;

		public GuildWarsViewModel _003C_003E4__this;

		private string _003Cdetails_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0151;
				}
				if (war != null)
				{
					_003Cdetails_003E5__1 = $"Opponent: {war.OpponentGuildName}\nResult: {war.ResultDisplay}\nTrophy Change: {war.TrophyChangeDisplay}\nDate: {war.Timestamp:MMM dd, yyyy}";
					awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("War Details", _003Cdetails_003E5__1).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CViewWarDetails_003Ed__134 _003CViewWarDetails_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CViewWarDetails_003Ed__134>(ref awaiter, ref _003CViewWarDetails_003Ed__);
						return;
					}
					goto IL_0151;
				}
				goto end_IL_0007;
				IL_0151:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cdetails_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cdetails_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IGuildRepository _guildRepository;

	private readonly INavigationService _navigationService;

	private readonly IGuildStateService _guildStateService;

	private readonly IPlayerStateService _playerStateService;

	private readonly RefreshDefenseUseCase _refreshDefenseUseCase;

	private readonly RegisterAsWarMemberUseCase _registerAsWarMemberUseCase;

	private readonly StartGuildWarBattleUseCase _startGuildWarBattleUseCase;

	private readonly RaidCrystalsUseCase _raidCrystalsUseCase;

	private readonly ProcessWarBattleResultUseCase _processWarBattleResultUseCase;

	private readonly UpdateBattleTaskProgressUseCase _updateBattleTaskProgressUseCase;

	private readonly IPopupService _popupService;

	private readonly IServerTimeProvider _serverTimeProvider;

	private readonly PlayerInfoModel _playerInfoModel;

	private readonly IBottomSheetService _bottomSheetService;

	private readonly IServiceProvider _serviceProvider;

	private bool _disposed;

	private Timer? _defenseTimer;

	private Timer? _seasonTimer;

	[ObservableProperty]
	private string? _guildId;

	[ObservableProperty]
	private ObservableCollection<GuildWarHistory> _warHistory = new ObservableCollection<GuildWarHistory>();

	[ObservableProperty]
	private int _winsCount;

	[ObservableProperty]
	private int _lossesCount;

	[ObservableProperty]
	private bool _isLoading;

	[ObservableProperty]
	private string _errorMessage = string.Empty;

	[ObservableProperty]
	private string _selectedTab = "current";

	[ObservableProperty]
	[NotifyPropertyChangedFor("XPProgressText")]
	[NotifyPropertyChangedFor("XPProgress")]
	private Guild? _currentGuild;

	[ObservableProperty]
	private ObservableCollection<GuildMember> _defenders = new ObservableCollection<GuildMember>();

	[ObservableProperty]
	private ObservableCollection<GuildMember> _mainDefenders = new ObservableCollection<GuildMember>();

	[ObservableProperty]
	private ObservableCollection<GuildWarTargetModel> _bucketOpponents = new ObservableCollection<GuildWarTargetModel>();

	[ObservableProperty]
	private GuildWarProgress? _currentProgress;

	[ObservableProperty]
	private bool _isDefender;

	[ObservableProperty]
	private List<string> _defenderSquad = new List<string>();

	[ObservableProperty]
	private int _availableDefendersCount;

	[ObservableProperty]
	private bool _canRaidCrystals;

	[ObservableProperty]
	private TimeSpan? _timeUntilNextRaid;

	[ObservableProperty]
	private TimeSpan? _defenseTimeRemaining;

	[ObservableProperty]
	private double _defenseProgress;

	[ObservableProperty]
	private string _attackResetTimeText = "Resets at 18:00 UTC";

	[ObservableProperty]
	[NotifyPropertyChangedFor("ShowRefreshDefenseButton")]
	private bool _isDefending = false;

	[ObservableProperty]
	[NotifyPropertyChangedFor("RegisterWarMemberButtonText")]
	private bool _isRegisteredDefender = false;

	[ObservableProperty]
	private bool _isBattling = false;

	[ObservableProperty]
	private SpiritSquadViewModel? _activeSquad;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<string>? selectTabCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? attackDefenderCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<GuildWarTargetModel?>? attackGuildCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<GuildWarTargetModel?>? raidGuildCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? registerAsWarMemberCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? refreshDefenseCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<GuildWarHistory>? viewWarDetailsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goToWarHistoryCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? refreshDataCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? removeDefenderCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? viewDefendersCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goBackCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? toggleWarEnrollmentCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goToDefenderManagementCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goToPortalCommand;

	public bool HasActiveSeason => CurrentGuild?.HasActiveWarSeason ?? false;

	public bool HasMatchedOpponent => CurrentGuild?.IsInWarSeason ?? false;

	public bool IsOpenToWar => CurrentGuild?.IsOpenToWar ?? false;

	public string NoOpponentMessage
	{
		get
		{
			Guild? currentGuild = CurrentGuild;
			return (currentGuild != null && currentGuild.IsOpenToWar) ? "Enrolled!" : "Not enrolled. Toggle to participate.";
		}
	}

	public bool HasMatchedButNotStarted => HasMatchedOpponent && !HasActiveSeason;

	public bool IsInWar => HasActiveSeason || HasMatchedButNotStarted;

	public bool IsLeader
	{
		get
		{
			Player? player = Player;
			int result;
			if (player == null || player.GuildRole != GuildRole.Guildmaster)
			{
				Player? player2 = Player;
				result = ((player2 != null && player2.GuildRole == GuildRole.Vice_Guildmaster) ? 1 : 0);
			}
			else
			{
				result = 1;
			}
			return (byte)result != 0;
		}
	}

	public int DisplayWins => CurrentGuild?.TotalWins ?? 0;

	public int DisplayLosses => CurrentGuild?.TotalLosses ?? 0;

	public bool ShowRegisterForWarButton => HasMatchedButNotStarted;

	public string RegisterWarMemberButtonText => IsRegisteredDefender ? "WITHDRAW" : "REGISTER AS DEFENDER";

	public bool ShowDefendControls => HasActiveSeason;

	public bool ShowRefreshDefenseButton => HasActiveSeason && IsRegisteredDefender && !IsDefending;

	public bool ShowNotInWarMessage => !IsInWar;

	public string OpposingGuildTitle => HasMatchedOpponent ? "WAR BUCKET" : "PENDING MATCHMAKING";

	public string OpposingGuildName => (!HasMatchedOpponent) ? "Not in active war season" : ((((Collection<GuildWarTargetModel>)(object)BucketOpponents).Count > 0) ? $"{((Collection<GuildWarTargetModel>)(object)BucketOpponents).Count} rival guild(s)" : "Free-for-all");

	public string WarSeasonTitle => IsInWar ? "CURRENT WAR SEASON" : "MATCHMAKING STARTS SOON!";

	public string EnrollButtonText => IsOpenToWar ? "ENROLLED WAITING FOR MATCH..." : "ENROLL FOR GUILD WARS!";

	public string WarTimerLabel => HasActiveSeason ? ("War ends in: " + WarEndsIn) : (HasMatchedButNotStarted ? ("War starts in: " + WarStartsIn) : ("Season: " + SeasonTimeRemaining));

	public string WarEndsIn
	{
		get
		{
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			Guild? currentGuild = CurrentGuild;
			if (currentGuild == null || !currentGuild.CurrentSeasonEndDate.HasValue)
			{
				return "N/A";
			}
			TimeSpan val = CurrentGuild.CurrentSeasonEndDate.Value - _serverTimeProvider.GetCurrentServerTime();
			if (((TimeSpan)(ref val)).TotalSeconds <= 0.0)
			{
				return "Ended";
			}
			if (!(((TimeSpan)(ref val)).TotalDays >= 1.0))
			{
				if (!(((TimeSpan)(ref val)).TotalHours >= 1.0))
				{
					return $"{((TimeSpan)(ref val)).Minutes}m {((TimeSpan)(ref val)).Seconds}s";
				}
				return $"{((TimeSpan)(ref val)).Hours}h {((TimeSpan)(ref val)).Minutes}m";
			}
			return $"{(int)((TimeSpan)(ref val)).TotalDays}d {((TimeSpan)(ref val)).Hours}h";
		}
	}

	public string WarStartsIn
	{
		get
		{
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			Guild? currentGuild = CurrentGuild;
			if (currentGuild == null || !currentGuild.CurrentSeasonStartDate.HasValue)
			{
				return "N/A";
			}
			TimeSpan val = CurrentGuild.CurrentSeasonStartDate.Value - _serverTimeProvider.GetCurrentServerTime();
			if (((TimeSpan)(ref val)).TotalSeconds <= 0.0)
			{
				return "Starting...";
			}
			if (!(((TimeSpan)(ref val)).TotalDays >= 1.0))
			{
				if (!(((TimeSpan)(ref val)).TotalHours >= 1.0))
				{
					return $"{((TimeSpan)(ref val)).Minutes}m {((TimeSpan)(ref val)).Seconds}s";
				}
				return $"{((TimeSpan)(ref val)).Hours}h {((TimeSpan)(ref val)).Minutes}m";
			}
			return $"{(int)((TimeSpan)(ref val)).TotalDays}d {((TimeSpan)(ref val)).Hours}h";
		}
	}

	public Player? Player => _playerStateService?.GetCurrentPlayer();

	public PlayerInfoModel PlayerInfoModel => _playerInfoModel;

	public string XPProgressText => $"EXP {CurrentGuild?.CurrentXP:N0} / {CurrentGuild?.XPForNextLevel:N0}";

	public float XPProgress
	{
		get
		{
			Guild? currentGuild = CurrentGuild;
			return (currentGuild != null && currentGuild.XPForNextLevel > 0) ? ((float)CurrentGuild.CurrentXP / (float)CurrentGuild.XPForNextLevel) : 0f;
		}
	}

	public static float HourlyMaxCrystals => 500f;

	private int MyHourlyCrystals
	{
		get
		{
			int num = default(int);
			return (CurrentProgress != null && Player?.PlayerID != null && CurrentProgress.IsHourlyWindowActive(Player.PlayerID) && CurrentProgress.PlayerHourlyCrystals.TryGetValue(Player.PlayerID, ref num)) ? num : 0;
		}
	}

	public float CrystalStolenProgress => (float)MyHourlyCrystals / HourlyMaxCrystals;

	public string CrystalsStolenProgressText => $"{MyHourlyCrystals} / {(int)HourlyMaxCrystals} Hourly Max";

	public string HourlyCrystalResetText
	{
		get
		{
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			if (CurrentProgress == null || Player?.PlayerID == null)
			{
				return string.Empty;
			}
			string playerID = Player.PlayerID;
			if (!CurrentProgress.IsHourlyWindowActive(playerID))
			{
				return "Cap resets: Ready";
			}
			DateTimeOffset? val = default(DateTimeOffset?);
			if (!CurrentProgress.PlayerHourlyStarts.TryGetValue(playerID, ref val) || !val.HasValue)
			{
				return string.Empty;
			}
			DateTimeOffset value = val.Value;
			TimeSpan val2 = ((DateTimeOffset)(ref value)).AddHours(1.0) - _serverTimeProvider.GetCurrentServerTime();
			if (((TimeSpan)(ref val2)).TotalSeconds <= 0.0)
			{
				return "Cap resets: Ready";
			}
			if (!(((TimeSpan)(ref val2)).TotalMinutes < 1.0))
			{
				return $"Cap resets in: {(int)((TimeSpan)(ref val2)).TotalMinutes}m {((TimeSpan)(ref val2)).Seconds}s";
			}
			return $"Cap resets in: {(int)((TimeSpan)(ref val2)).TotalSeconds}s";
		}
	}

	public double? WinLossDiagonalAngle => (double)((DisplayWins == DisplayLosses) ? 90 : ((DisplayWins > DisplayLosses) ? (-45) : 45));

	public string WinLossRatio => (DisplayLosses + DisplayWins > 0) ? $"{(float)DisplayWins / (float)(DisplayLosses + DisplayWins) * 100f:F1}%" : "0%";

	public string? ActiveMemberRatio => (CurrentGuild != null) ? $"{CurrentGuild?.DefenderCount}/20" : "0/20";

	public string SeasonTimeRemaining
	{
		get
		{
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			Guild? currentGuild = CurrentGuild;
			if (currentGuild == null || !currentGuild.CurrentSeasonEndDate.HasValue)
			{
				return "N/A";
			}
			TimeSpan val = CurrentGuild.CurrentSeasonEndDate.Value - _serverTimeProvider.GetCurrentServerTime();
			if (((TimeSpan)(ref val)).TotalSeconds <= 0.0)
			{
				return "Ended";
			}
			if (!(((TimeSpan)(ref val)).TotalDays >= 1.0))
			{
				return $"{((TimeSpan)(ref val)).Hours}h";
			}
			return $"{((TimeSpan)(ref val)).Days}d";
		}
	}

	public string WinRateText
	{
		get
		{
			int num = WinsCount + LossesCount;
			if (num == 0)
			{
				return "0%";
			}
			double num2 = (double)WinsCount / (double)num * 100.0;
			return $"{num2:F1}%";
		}
	}

	public bool IsRegisteredForWar => CurrentGuild != null && CurrentGuild.Defenders.ContainsKey(_playerStateService.CurrentPlayerId ?? string.Empty);

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? GuildId
	{
		get
		{
			return _guildId;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_guildId, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.GuildId);
				_guildId = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.GuildId);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<GuildWarHistory> WarHistory
	{
		get
		{
			return _warHistory;
		}
		[MemberNotNull("_warHistory")]
		set
		{
			if (!EqualityComparer<ObservableCollection<GuildWarHistory>>.Default.Equals(_warHistory, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.WarHistory);
				_warHistory = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.WarHistory);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int WinsCount
	{
		get
		{
			return _winsCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_winsCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.WinsCount);
				_winsCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.WinsCount);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int LossesCount
	{
		get
		{
			return _lossesCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_lossesCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.LossesCount);
				_lossesCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.LossesCount);
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
	public string ErrorMessage
	{
		get
		{
			return _errorMessage;
		}
		[MemberNotNull("_errorMessage")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_errorMessage, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ErrorMessage);
				_errorMessage = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ErrorMessage);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string SelectedTab
	{
		get
		{
			return _selectedTab;
		}
		[MemberNotNull("_selectedTab")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_selectedTab, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SelectedTab);
				_selectedTab = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SelectedTab);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Guild? CurrentGuild
	{
		get
		{
			return _currentGuild;
		}
		set
		{
			if (!EqualityComparer<Guild>.Default.Equals(_currentGuild, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentGuild);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.XPProgressText);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.XPProgress);
				_currentGuild = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentGuild);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.XPProgressText);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.XPProgress);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<GuildMember> Defenders
	{
		get
		{
			return _defenders;
		}
		[MemberNotNull("_defenders")]
		set
		{
			if (!EqualityComparer<ObservableCollection<GuildMember>>.Default.Equals(_defenders, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Defenders);
				_defenders = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Defenders);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<GuildMember> MainDefenders
	{
		get
		{
			return _mainDefenders;
		}
		[MemberNotNull("_mainDefenders")]
		set
		{
			if (!EqualityComparer<ObservableCollection<GuildMember>>.Default.Equals(_mainDefenders, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.MainDefenders);
				_mainDefenders = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MainDefenders);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<GuildWarTargetModel> BucketOpponents
	{
		get
		{
			return _bucketOpponents;
		}
		[MemberNotNull("_bucketOpponents")]
		set
		{
			if (!EqualityComparer<ObservableCollection<GuildWarTargetModel>>.Default.Equals(_bucketOpponents, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.BucketOpponents);
				_bucketOpponents = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.BucketOpponents);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public GuildWarProgress? CurrentProgress
	{
		get
		{
			return _currentProgress;
		}
		set
		{
			if (!EqualityComparer<GuildWarProgress>.Default.Equals(_currentProgress, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentProgress);
				_currentProgress = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentProgress);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsDefender
	{
		get
		{
			return _isDefender;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isDefender, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsDefender);
				_isDefender = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsDefender);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public List<string> DefenderSquad
	{
		get
		{
			return _defenderSquad;
		}
		[MemberNotNull("_defenderSquad")]
		set
		{
			if (!EqualityComparer<List<string>>.Default.Equals(_defenderSquad, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.DefenderSquad);
				_defenderSquad = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.DefenderSquad);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int AvailableDefendersCount
	{
		get
		{
			return _availableDefendersCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_availableDefendersCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.AvailableDefendersCount);
				_availableDefendersCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.AvailableDefendersCount);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool CanRaidCrystals
	{
		get
		{
			return _canRaidCrystals;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_canRaidCrystals, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanRaidCrystals);
				_canRaidCrystals = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanRaidCrystals);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public TimeSpan? TimeUntilNextRaid
	{
		get
		{
			return _timeUntilNextRaid;
		}
		set
		{
			if (!EqualityComparer<TimeSpan?>.Default.Equals(_timeUntilNextRaid, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TimeUntilNextRaid);
				_timeUntilNextRaid = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TimeUntilNextRaid);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public TimeSpan? DefenseTimeRemaining
	{
		get
		{
			return _defenseTimeRemaining;
		}
		set
		{
			if (!EqualityComparer<TimeSpan?>.Default.Equals(_defenseTimeRemaining, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.DefenseTimeRemaining);
				_defenseTimeRemaining = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.DefenseTimeRemaining);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public double DefenseProgress
	{
		get
		{
			return _defenseProgress;
		}
		set
		{
			if (!EqualityComparer<double>.Default.Equals(_defenseProgress, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.DefenseProgress);
				_defenseProgress = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.DefenseProgress);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string AttackResetTimeText
	{
		get
		{
			return _attackResetTimeText;
		}
		[MemberNotNull("_attackResetTimeText")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_attackResetTimeText, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.AttackResetTimeText);
				_attackResetTimeText = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.AttackResetTimeText);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsDefending
	{
		get
		{
			return _isDefending;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isDefending, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsDefending);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowRefreshDefenseButton);
				_isDefending = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsDefending);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowRefreshDefenseButton);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsRegisteredDefender
	{
		get
		{
			return _isRegisteredDefender;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isRegisteredDefender, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsRegisteredDefender);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.RegisterWarMemberButtonText);
				_isRegisteredDefender = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsRegisteredDefender);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.RegisterWarMemberButtonText);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsBattling
	{
		get
		{
			return _isBattling;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isBattling, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsBattling);
				_isBattling = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsBattling);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public SpiritSquadViewModel? ActiveSquad
	{
		get
		{
			return _activeSquad;
		}
		set
		{
			if (!EqualityComparer<SpiritSquadViewModel>.Default.Equals(_activeSquad, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ActiveSquad);
				_activeSquad = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ActiveSquad);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<string> SelectTabCommand => (IRelayCommand<string>)(object)(selectTabCommand ?? (selectTabCommand = new RelayCommand<string>((Action<string>)SelectTab)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand AttackDefenderCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = attackDefenderCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)AttackDefender);
				AsyncRelayCommand val2 = val;
				attackDefenderCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<GuildWarTargetModel?> AttackGuildCommand => (IAsyncRelayCommand<GuildWarTargetModel?>)(object)(attackGuildCommand ?? (attackGuildCommand = new AsyncRelayCommand<GuildWarTargetModel>((Func<GuildWarTargetModel, global::System.Threading.Tasks.Task>)AttackGuild)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<GuildWarTargetModel?> RaidGuildCommand => (IAsyncRelayCommand<GuildWarTargetModel?>)(object)(raidGuildCommand ?? (raidGuildCommand = new AsyncRelayCommand<GuildWarTargetModel>((Func<GuildWarTargetModel, global::System.Threading.Tasks.Task>)RaidGuild)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand RegisterAsWarMemberCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = registerAsWarMemberCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)RegisterAsWarMember);
				AsyncRelayCommand val2 = val;
				registerAsWarMemberCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand RefreshDefenseCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = refreshDefenseCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)RefreshDefense);
				AsyncRelayCommand val2 = val;
				refreshDefenseCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<GuildWarHistory> ViewWarDetailsCommand => (IAsyncRelayCommand<GuildWarHistory>)(object)(viewWarDetailsCommand ?? (viewWarDetailsCommand = new AsyncRelayCommand<GuildWarHistory>((Func<GuildWarHistory, global::System.Threading.Tasks.Task>)ViewWarDetails)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand GoToWarHistoryCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = goToWarHistoryCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)GoToWarHistory);
				AsyncRelayCommand val2 = val;
				goToWarHistoryCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand RefreshDataCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = refreshDataCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)RefreshData);
				AsyncRelayCommand val2 = val;
				refreshDataCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand RemoveDefenderCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = removeDefenderCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)RemoveDefender);
				AsyncRelayCommand val2 = val;
				removeDefenderCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ViewDefendersCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = viewDefendersCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)ViewDefenders);
				AsyncRelayCommand val2 = val;
				viewDefendersCommand = val;
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
	public IAsyncRelayCommand ToggleWarEnrollmentCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = toggleWarEnrollmentCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)ToggleWarEnrollment);
				AsyncRelayCommand val2 = val;
				toggleWarEnrollmentCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand GoToDefenderManagementCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = goToDefenderManagementCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)GoToDefenderManagement);
				AsyncRelayCommand val2 = val;
				goToDefenderManagementCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
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

	public GuildWarsViewModel(IGuildRepository guildRepository, INavigationService navigationService, IGuildStateService guildStateService, IPlayerStateService playerStateService, RefreshDefenseUseCase refreshDefenseUseCase, RegisterAsWarMemberUseCase registerAsWarMemberUseCase, StartGuildWarBattleUseCase startGuildWarBattleUseCase, RaidCrystalsUseCase raidCrystalsUseCase, ProcessWarBattleResultUseCase processWarBattleResultUseCase, UpdateBattleTaskProgressUseCase updateBattleTaskProgressUseCase, IPopupService popupService, IServerTimeProvider serverTimeProvider, PlayerInfoModel playerInfoModel, IBottomSheetService bottomSheetService, IServiceProvider serviceProvider)
	{
		_guildRepository = guildRepository;
		_navigationService = navigationService;
		_guildStateService = guildStateService;
		_playerStateService = playerStateService;
		_refreshDefenseUseCase = refreshDefenseUseCase;
		_registerAsWarMemberUseCase = registerAsWarMemberUseCase;
		_startGuildWarBattleUseCase = startGuildWarBattleUseCase;
		_raidCrystalsUseCase = raidCrystalsUseCase;
		_processWarBattleResultUseCase = processWarBattleResultUseCase;
		_updateBattleTaskProgressUseCase = updateBattleTaskProgressUseCase;
		_popupService = popupService;
		_serverTimeProvider = serverTimeProvider;
		_playerInfoModel = playerInfoModel;
		_bottomSheetService = bottomSheetService;
		_serviceProvider = serviceProvider;
		_guildStateService.GuildStateChanged += OnGuildStateChanged;
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__115))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? parameter)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__115 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__115();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.parameter = parameter;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__115>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	private void NotifyWarPropertiesChanged()
	{
		((ObservableObject)this).OnPropertyChanged("HasActiveSeason");
		((ObservableObject)this).OnPropertyChanged("HasMatchedOpponent");
		((ObservableObject)this).OnPropertyChanged("IsOpenToWar");
		((ObservableObject)this).OnPropertyChanged("NoOpponentMessage");
		((ObservableObject)this).OnPropertyChanged("HasMatchedButNotStarted");
		((ObservableObject)this).OnPropertyChanged("IsInWar");
		((ObservableObject)this).OnPropertyChanged("IsLeader");
		((ObservableObject)this).OnPropertyChanged("DisplayWins");
		((ObservableObject)this).OnPropertyChanged("DisplayLosses");
		((ObservableObject)this).OnPropertyChanged("WinLossRatio");
		((ObservableObject)this).OnPropertyChanged("WinLossDiagonalAngle");
		((ObservableObject)this).OnPropertyChanged("ShowDefendControls");
		((ObservableObject)this).OnPropertyChanged("ShowRefreshDefenseButton");
		((ObservableObject)this).OnPropertyChanged("ShowNotInWarMessage");
		((ObservableObject)this).OnPropertyChanged("OpposingGuildTitle");
		((ObservableObject)this).OnPropertyChanged("OpposingGuildName");
		((ObservableObject)this).OnPropertyChanged("IsRegisteredForWar");
		((ObservableObject)this).OnPropertyChanged("WarSeasonTitle");
		((ObservableObject)this).OnPropertyChanged("EnrollButtonText");
		((ObservableObject)this).OnPropertyChanged("WarTimerLabel");
		((ObservableObject)this).OnPropertyChanged("WarEndsIn");
		((ObservableObject)this).OnPropertyChanged("WarStartsIn");
		((ObservableObject)this).OnPropertyChanged("ShowRegisterForWarButton");
		((ObservableObject)this).OnPropertyChanged("RegisterWarMemberButtonText");
		((ObservableObject)this).OnPropertyChanged("ActiveMemberRatio");
		((ObservableObject)this).OnPropertyChanged("HourlyCrystalResetText");
	}

	[AsyncStateMachine(typeof(_003CLoadSquadData_003Ed__117))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<bool> LoadSquadData()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ActiveSquad?.Dispose();
			ActiveSquad = ActivatorUtilities.CreateInstance<SpiritSquadViewModel>(_serviceProvider, global::System.Array.Empty<object>());
			return true;
		}
		catch (global::System.Exception ex)
		{
			await _navigationService.ShowAlertAsync("Error", "Failed to load squad data");
			Console.WriteLine($"Error loading squad: {ex}");
			ActiveSquad = null;
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CLoadWarHistory_003Ed__118))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadWarHistory()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadWarHistory_003Ed__118 _003CLoadWarHistory_003Ed__ = new _003CLoadWarHistory_003Ed__118();
		_003CLoadWarHistory_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadWarHistory_003Ed__._003C_003E4__this = this;
		_003CLoadWarHistory_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadWarHistory_003Ed__._003C_003Et__builder)).Start<_003CLoadWarHistory_003Ed__118>(ref _003CLoadWarHistory_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadWarHistory_003Ed__._003C_003Et__builder)).Task;
	}

	private global::System.Threading.Tasks.Task LoadWarStatistics()
	{
		try
		{
			WinsCount = CurrentGuild?.TotalWins ?? 0;
			LossesCount = CurrentGuild?.TotalLosses ?? 0;
			((ObservableObject)this).OnPropertyChanged("WinRateText");
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine($"LoadWarStatistics error: {ex}");
		}
		return global::System.Threading.Tasks.Task.CompletedTask;
	}

	[AsyncStateMachine(typeof(_003CLoadCurrentGuild_003Ed__120))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadCurrentGuild()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadCurrentGuild_003Ed__120 _003CLoadCurrentGuild_003Ed__ = new _003CLoadCurrentGuild_003Ed__120();
		_003CLoadCurrentGuild_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadCurrentGuild_003Ed__._003C_003E4__this = this;
		_003CLoadCurrentGuild_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadCurrentGuild_003Ed__._003C_003Et__builder)).Start<_003CLoadCurrentGuild_003Ed__120>(ref _003CLoadCurrentGuild_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadCurrentGuild_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadDefenders_003Ed__121))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadDefenders()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDefenders_003Ed__121 _003CLoadDefenders_003Ed__ = new _003CLoadDefenders_003Ed__121();
		_003CLoadDefenders_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDefenders_003Ed__._003C_003E4__this = this;
		_003CLoadDefenders_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDefenders_003Ed__._003C_003Et__builder)).Start<_003CLoadDefenders_003Ed__121>(ref _003CLoadDefenders_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDefenders_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadBucketOpponents_003Ed__122))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadBucketOpponents()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadBucketOpponents_003Ed__122 _003CLoadBucketOpponents_003Ed__ = new _003CLoadBucketOpponents_003Ed__122();
		_003CLoadBucketOpponents_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadBucketOpponents_003Ed__._003C_003E4__this = this;
		_003CLoadBucketOpponents_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadBucketOpponents_003Ed__._003C_003Et__builder)).Start<_003CLoadBucketOpponents_003Ed__122>(ref _003CLoadBucketOpponents_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadBucketOpponents_003Ed__._003C_003Et__builder)).Task;
	}

	[RelayCommand]
	private void SelectTab(string tab)
	{
		SelectedTab = tab;
	}

	[AsyncStateMachine(typeof(_003CAttackDefender_003Ed__124))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task AttackDefender()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CAttackDefender_003Ed__124 _003CAttackDefender_003Ed__ = new _003CAttackDefender_003Ed__124();
		_003CAttackDefender_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CAttackDefender_003Ed__._003C_003E4__this = this;
		_003CAttackDefender_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CAttackDefender_003Ed__._003C_003Et__builder)).Start<_003CAttackDefender_003Ed__124>(ref _003CAttackDefender_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CAttackDefender_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CAttackGuild_003Ed__125))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task AttackGuild(GuildWarTargetModel? target)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CAttackGuild_003Ed__125 _003CAttackGuild_003Ed__ = new _003CAttackGuild_003Ed__125();
		_003CAttackGuild_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CAttackGuild_003Ed__._003C_003E4__this = this;
		_003CAttackGuild_003Ed__.target = target;
		_003CAttackGuild_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CAttackGuild_003Ed__._003C_003Et__builder)).Start<_003CAttackGuild_003Ed__125>(ref _003CAttackGuild_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CAttackGuild_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRaidGuild_003Ed__126))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task RaidGuild(GuildWarTargetModel? target)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRaidGuild_003Ed__126 _003CRaidGuild_003Ed__ = new _003CRaidGuild_003Ed__126();
		_003CRaidGuild_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRaidGuild_003Ed__._003C_003E4__this = this;
		_003CRaidGuild_003Ed__.target = target;
		_003CRaidGuild_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRaidGuild_003Ed__._003C_003Et__builder)).Start<_003CRaidGuild_003Ed__126>(ref _003CRaidGuild_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRaidGuild_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CAttackTargetAsync_003Ed__127))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task AttackTargetAsync(string defendingGuildId, string defendingGuildName)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CAttackTargetAsync_003Ed__127 _003CAttackTargetAsync_003Ed__ = new _003CAttackTargetAsync_003Ed__127();
		_003CAttackTargetAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CAttackTargetAsync_003Ed__._003C_003E4__this = this;
		_003CAttackTargetAsync_003Ed__.defendingGuildId = defendingGuildId;
		_003CAttackTargetAsync_003Ed__.defendingGuildName = defendingGuildName;
		_003CAttackTargetAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CAttackTargetAsync_003Ed__._003C_003Et__builder)).Start<_003CAttackTargetAsync_003Ed__127>(ref _003CAttackTargetAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CAttackTargetAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CProcessGuildWarBattleResults_003Ed__128))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ProcessGuildWarBattleResults(BattleResultDTO battleResult, BattleLaunchRequest battleRequest, string defendingGuildId, string defendingGuildName)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CProcessGuildWarBattleResults_003Ed__128 _003CProcessGuildWarBattleResults_003Ed__ = new _003CProcessGuildWarBattleResults_003Ed__128();
		_003CProcessGuildWarBattleResults_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CProcessGuildWarBattleResults_003Ed__._003C_003E4__this = this;
		_003CProcessGuildWarBattleResults_003Ed__.battleResult = battleResult;
		_003CProcessGuildWarBattleResults_003Ed__.battleRequest = battleRequest;
		_003CProcessGuildWarBattleResults_003Ed__.defendingGuildId = defendingGuildId;
		_003CProcessGuildWarBattleResults_003Ed__.defendingGuildName = defendingGuildName;
		_003CProcessGuildWarBattleResults_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CProcessGuildWarBattleResults_003Ed__._003C_003Et__builder)).Start<_003CProcessGuildWarBattleResults_003Ed__128>(ref _003CProcessGuildWarBattleResults_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CProcessGuildWarBattleResults_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CShowBattleSummary_003Ed__129))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ShowBattleSummary(BattleResultDTO battleResult, BattleRewards rewards, BattleLaunchRequest battleLaunchRequest, string defendingGuildName)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CShowBattleSummary_003Ed__129 _003CShowBattleSummary_003Ed__ = new _003CShowBattleSummary_003Ed__129();
		_003CShowBattleSummary_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CShowBattleSummary_003Ed__._003C_003E4__this = this;
		_003CShowBattleSummary_003Ed__.battleResult = battleResult;
		_003CShowBattleSummary_003Ed__.rewards = rewards;
		_003CShowBattleSummary_003Ed__.battleLaunchRequest = battleLaunchRequest;
		_003CShowBattleSummary_003Ed__.defendingGuildName = defendingGuildName;
		_003CShowBattleSummary_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CShowBattleSummary_003Ed__._003C_003Et__builder)).Start<_003CShowBattleSummary_003Ed__129>(ref _003CShowBattleSummary_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CShowBattleSummary_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRegisterAsWarMember_003Ed__130))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task RegisterAsWarMember()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRegisterAsWarMember_003Ed__130 _003CRegisterAsWarMember_003Ed__ = new _003CRegisterAsWarMember_003Ed__130();
		_003CRegisterAsWarMember_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRegisterAsWarMember_003Ed__._003C_003E4__this = this;
		_003CRegisterAsWarMember_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRegisterAsWarMember_003Ed__._003C_003Et__builder)).Start<_003CRegisterAsWarMember_003Ed__130>(ref _003CRegisterAsWarMember_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRegisterAsWarMember_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRefreshDefense_003Ed__131))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task RefreshDefense()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRefreshDefense_003Ed__131 _003CRefreshDefense_003Ed__ = new _003CRefreshDefense_003Ed__131();
		_003CRefreshDefense_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRefreshDefense_003Ed__._003C_003E4__this = this;
		_003CRefreshDefense_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRefreshDefense_003Ed__._003C_003Et__builder)).Start<_003CRefreshDefense_003Ed__131>(ref _003CRefreshDefense_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRefreshDefense_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRaidTargetAsync_003Ed__132))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task RaidTargetAsync(string defendingGuildId, string defendingGuildName)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRaidTargetAsync_003Ed__132 _003CRaidTargetAsync_003Ed__ = new _003CRaidTargetAsync_003Ed__132();
		_003CRaidTargetAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRaidTargetAsync_003Ed__._003C_003E4__this = this;
		_003CRaidTargetAsync_003Ed__.defendingGuildId = defendingGuildId;
		_003CRaidTargetAsync_003Ed__.defendingGuildName = defendingGuildName;
		_003CRaidTargetAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRaidTargetAsync_003Ed__._003C_003Et__builder)).Start<_003CRaidTargetAsync_003Ed__132>(ref _003CRaidTargetAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRaidTargetAsync_003Ed__._003C_003Et__builder)).Task;
	}

	private void NotifyCrystalPropertiesChanged()
	{
		((ObservableObject)this).OnPropertyChanged("DisplayWins");
		((ObservableObject)this).OnPropertyChanged("DisplayLosses");
		((ObservableObject)this).OnPropertyChanged("CrystalStolenProgress");
		((ObservableObject)this).OnPropertyChanged("CrystalsStolenProgressText");
		((ObservableObject)this).OnPropertyChanged("HourlyCrystalResetText");
		((ObservableObject)this).OnPropertyChanged("WinLossRatio");
		((ObservableObject)this).OnPropertyChanged("WinLossDiagonalAngle");
	}

	[AsyncStateMachine(typeof(_003CViewWarDetails_003Ed__134))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task ViewWarDetails(GuildWarHistory war)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CViewWarDetails_003Ed__134 _003CViewWarDetails_003Ed__ = new _003CViewWarDetails_003Ed__134();
		_003CViewWarDetails_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CViewWarDetails_003Ed__._003C_003E4__this = this;
		_003CViewWarDetails_003Ed__.war = war;
		_003CViewWarDetails_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CViewWarDetails_003Ed__._003C_003Et__builder)).Start<_003CViewWarDetails_003Ed__134>(ref _003CViewWarDetails_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CViewWarDetails_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGoToWarHistory_003Ed__135))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoToWarHistory()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoToWarHistory_003Ed__135 _003CGoToWarHistory_003Ed__ = new _003CGoToWarHistory_003Ed__135();
		_003CGoToWarHistory_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoToWarHistory_003Ed__._003C_003E4__this = this;
		_003CGoToWarHistory_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoToWarHistory_003Ed__._003C_003Et__builder)).Start<_003CGoToWarHistory_003Ed__135>(ref _003CGoToWarHistory_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoToWarHistory_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRefreshData_003Ed__136))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task RefreshData()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRefreshData_003Ed__136 _003CRefreshData_003Ed__ = new _003CRefreshData_003Ed__136();
		_003CRefreshData_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRefreshData_003Ed__._003C_003E4__this = this;
		_003CRefreshData_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRefreshData_003Ed__._003C_003Et__builder)).Start<_003CRefreshData_003Ed__136>(ref _003CRefreshData_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRefreshData_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRemoveDefender_003Ed__137))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task RemoveDefender()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRemoveDefender_003Ed__137 _003CRemoveDefender_003Ed__ = new _003CRemoveDefender_003Ed__137();
		_003CRemoveDefender_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRemoveDefender_003Ed__._003C_003E4__this = this;
		_003CRemoveDefender_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRemoveDefender_003Ed__._003C_003Et__builder)).Start<_003CRemoveDefender_003Ed__137>(ref _003CRemoveDefender_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRemoveDefender_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CViewDefenders_003Ed__138))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task ViewDefenders()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CViewDefenders_003Ed__138 _003CViewDefenders_003Ed__ = new _003CViewDefenders_003Ed__138();
		_003CViewDefenders_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CViewDefenders_003Ed__._003C_003E4__this = this;
		_003CViewDefenders_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CViewDefenders_003Ed__._003C_003Et__builder)).Start<_003CViewDefenders_003Ed__138>(ref _003CViewDefenders_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CViewDefenders_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGoBack_003Ed__139))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoBack()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoBack_003Ed__139 _003CGoBack_003Ed__ = new _003CGoBack_003Ed__139();
		_003CGoBack_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoBack_003Ed__._003C_003E4__this = this;
		_003CGoBack_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Start<_003CGoBack_003Ed__139>(ref _003CGoBack_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CToggleWarEnrollment_003Ed__140))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task ToggleWarEnrollment()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CToggleWarEnrollment_003Ed__140 _003CToggleWarEnrollment_003Ed__ = new _003CToggleWarEnrollment_003Ed__140();
		_003CToggleWarEnrollment_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CToggleWarEnrollment_003Ed__._003C_003E4__this = this;
		_003CToggleWarEnrollment_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CToggleWarEnrollment_003Ed__._003C_003Et__builder)).Start<_003CToggleWarEnrollment_003Ed__140>(ref _003CToggleWarEnrollment_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CToggleWarEnrollment_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGoToDefenderManagement_003Ed__141))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoToDefenderManagement()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoToDefenderManagement_003Ed__141 _003CGoToDefenderManagement_003Ed__ = new _003CGoToDefenderManagement_003Ed__141();
		_003CGoToDefenderManagement_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoToDefenderManagement_003Ed__._003C_003E4__this = this;
		_003CGoToDefenderManagement_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoToDefenderManagement_003Ed__._003C_003Et__builder)).Start<_003CGoToDefenderManagement_003Ed__141>(ref _003CGoToDefenderManagement_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoToDefenderManagement_003Ed__._003C_003Et__builder)).Task;
	}

	private void StartDefenseTimer(DateTimeOffset expiryTime)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		StopDefenseTimer();
		_defenseTimer = new Timer(1000.0);
		_defenseTimer.Elapsed += (ElapsedEventHandler)delegate
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Expected O, but got Unknown
			TimeSpan remaining = expiryTime - _serverTimeProvider.GetCurrentServerTime();
			MainThread.BeginInvokeOnMainThread((Action)delegate
			{
				//IL_0075: Unknown result type (might be due to invalid IL or missing references)
				//IL_002a: Unknown result type (might be due to invalid IL or missing references)
				if (((TimeSpan)(ref remaining)).TotalSeconds <= 0.0)
				{
					DefenseTimeRemaining = TimeSpan.Zero;
					DefenseProgress = 0.0;
					StopDefenseTimer();
				}
				else
				{
					DefenseTimeRemaining = remaining;
					DefenseProgress = 0.0 + ((TimeSpan)(ref remaining)).TotalHours / 8.0;
					IsDefending = true;
				}
			});
		};
		_defenseTimer.Start();
	}

	private void StopDefenseTimer()
	{
		if (_defenseTimer != null)
		{
			_defenseTimer.Stop();
			((Component)_defenseTimer).Dispose();
			_defenseTimer = null;
			IsDefending = false;
		}
	}

	[AsyncStateMachine(typeof(_003CGoToPortal_003Ed__144))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoToPortal()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoToPortal_003Ed__144 _003CGoToPortal_003Ed__ = new _003CGoToPortal_003Ed__144();
		_003CGoToPortal_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoToPortal_003Ed__._003C_003E4__this = this;
		_003CGoToPortal_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoToPortal_003Ed__._003C_003Et__builder)).Start<_003CGoToPortal_003Ed__144>(ref _003CGoToPortal_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoToPortal_003Ed__._003C_003Et__builder)).Task;
	}

	private void StartSeasonTimer()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		StopSeasonTimer();
		_seasonTimer = new Timer(1000.0);
		_seasonTimer.Elapsed += (ElapsedEventHandler)([CompilerGenerated] (object? s, ElapsedEventArgs e) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			MainThread.BeginInvokeOnMainThread((Action)([CompilerGenerated] () =>
			{
				((ObservableObject)this).OnPropertyChanged("WarEndsIn");
				((ObservableObject)this).OnPropertyChanged("WarStartsIn");
				((ObservableObject)this).OnPropertyChanged("SeasonTimeRemaining");
				((ObservableObject)this).OnPropertyChanged("WarTimerLabel");
				((ObservableObject)this).OnPropertyChanged("HourlyCrystalResetText");
				((ObservableObject)this).OnPropertyChanged("CrystalStolenProgress");
				((ObservableObject)this).OnPropertyChanged("CrystalsStolenProgressText");
			}));
		});
		_seasonTimer.Start();
	}

	private void StopSeasonTimer()
	{
		if (_seasonTimer != null)
		{
			_seasonTimer.Stop();
			((Component)_seasonTimer).Dispose();
			_seasonTimer = null;
		}
	}

	private void OnGuildStateChanged(object? sender, GuildStateChangedEventArgs e)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		if (e.ChangeType == GuildChangeType.GuildProperties)
		{
			MainThread.BeginInvokeOnMainThread((Action)([CompilerGenerated] () =>
			{
				CurrentGuild = _guildStateService.GetCurrentGuild();
				NotifyWarPropertiesChanged();
				((ObservableObject)this).OnPropertyChanged("SeasonTimeRemaining");
				((ObservableObject)this).OnPropertyChanged("XPProgressText");
				((ObservableObject)this).OnPropertyChanged("XPProgress");
				((ObservableObject)this).OnPropertyChanged("CrystalStolenProgress");
				((ObservableObject)this).OnPropertyChanged("CrystalsStolenProgressText");
				((ObservableObject)this).OnPropertyChanged("DefenseTimeRemaining");
				if (Player != null && CurrentGuild != null)
				{
					IsRegisteredDefender = Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)CurrentGuild.DefenderPlayerIds, Player.PlayerID);
					IsDefender = IsRegisteredDefender;
					((ObservableObject)this).OnPropertyChanged("ActiveMemberRatio");
					((ObservableObject)this).OnPropertyChanged("ShowRefreshDefenseButton");
				}
			}));
		}
		if (e.ChangeType == GuildChangeType.War || e.ChangeType == GuildChangeType.Defenders)
		{
			MainThread.BeginInvokeOnMainThread((Action)([AsyncStateMachine(typeof(_003C_003COnGuildStateChanged_003Eb__147_1_003Ed))] [DebuggerStepThrough] [CompilerGenerated] () =>
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				_003C_003COnGuildStateChanged_003Eb__147_1_003Ed _003C_003COnGuildStateChanged_003Eb__147_1_003Ed = new _003C_003COnGuildStateChanged_003Eb__147_1_003Ed
				{
					_003C_003Et__builder = AsyncVoidMethodBuilder.Create(),
					_003C_003E4__this = this,
					_003C_003E1__state = -1
				};
				((AsyncVoidMethodBuilder)(ref _003C_003COnGuildStateChanged_003Eb__147_1_003Ed._003C_003Et__builder)).Start<_003C_003COnGuildStateChanged_003Eb__147_1_003Ed>(ref _003C_003COnGuildStateChanged_003Eb__147_1_003Ed);
			}));
		}
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			StopDefenseTimer();
			StopSeasonTimer();
			_guildStateService.GuildStateChanged -= OnGuildStateChanged;
			_disposed = true;
			GC.SuppressFinalize((object)this);
		}
	}
}
