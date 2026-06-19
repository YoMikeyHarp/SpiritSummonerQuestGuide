using System;
using System.CodeDom.Compiler;
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
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using SpiritSummoner.Application.DTOs.Battles;
using SpiritSummoner.Application.UseCases.Battles;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Enums.Battles;
using SpiritSummoner.Domain.Interfaces.Services;
using SpiritSummoner.Domain.ValueObjects.Battle;
using SpiritSummoner.Domain.ValueObjects.Quests;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Infrastructure.Diagnostics;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.ViewModels.Popups;

namespace SpiritSummoner.Presentation.ViewModels.Battles;

public class BattleViewModelRefactored : ObservableObject, ILoadableViewModel, global::System.IDisposable
{
	public enum BattleViewState
	{
		Idle,
		Initializing,
		VsScreen,
		Attacking,
		Switching,
		Ended
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass90_0
	{
		private sealed class _003C_003CAnimateHPDelta_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass90_0 _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
				//IL_005b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0060: Unknown result type (might be due to invalid IL or missing references)
				//IL_0067: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
				//IL_009f: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a7: Expected O, but got Unknown
				//IL_00ac: Expected O, but got Unknown
				//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
				//IL_0024: Unknown result type (might be due to invalid IL or missing references)
				//IL_0029: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
				//IL_003d: Unknown result type (might be due to invalid IL or missing references)
				//IL_003e: Unknown result type (might be due to invalid IL or missing references)
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
							goto IL_0102;
						}
						awaiter2 = global::System.Threading.Tasks.Task.Delay(1100).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003C_003CAnimateHPDelta_003Eb__0_003Ed _003C_003CAnimateHPDelta_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003CAnimateHPDelta_003Eb__0_003Ed>(ref awaiter2, ref _003C_003CAnimateHPDelta_003Eb__0_003Ed);
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
					Action obj = _003C_003E4__this._003C_003E9__1;
					if (obj == null)
					{
						_003C_003Ec__DisplayClass90_0 _003C_003Ec__DisplayClass90_ = _003C_003E4__this;
						Action val = delegate
						{
							if (_003C_003E4__this.isPlayer)
							{
								_003C_003E4__this._003C_003E4__this.ShowHealingBadgePlayer = false;
							}
							else
							{
								_003C_003E4__this._003C_003E4__this.ShowHealingBadgeEnemy = false;
							}
						};
						Action val2 = val;
						_003C_003Ec__DisplayClass90_._003C_003E9__1 = val;
						obj = val2;
					}
					awaiter = MainThread.InvokeOnMainThreadAsync(obj).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter;
						_003C_003CAnimateHPDelta_003Eb__0_003Ed _003C_003CAnimateHPDelta_003Eb__0_003Ed = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003CAnimateHPDelta_003Eb__0_003Ed>(ref awaiter, ref _003C_003CAnimateHPDelta_003Eb__0_003Ed);
						return;
					}
					goto IL_0102;
					IL_0102:
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

		public bool isPlayer;

		public BattleViewModelRefactored _003C_003E4__this;

		public Action _003C_003E9__1;

		[AsyncStateMachine(typeof(_003C_003CAnimateHPDelta_003Eb__0_003Ed))]
		[DebuggerStepThrough]
		internal global::System.Threading.Tasks.Task? _003CAnimateHPDelta_003Eb__0()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003CAnimateHPDelta_003Eb__0_003Ed _003C_003CAnimateHPDelta_003Eb__0_003Ed = new _003C_003CAnimateHPDelta_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CAnimateHPDelta_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003CAnimateHPDelta_003Eb__0_003Ed>(ref _003C_003CAnimateHPDelta_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateHPDelta_003Eb__0_003Ed._003C_003Et__builder)).Task;
		}

		internal void _003CAnimateHPDelta_003Eb__1()
		{
			if (isPlayer)
			{
				_003C_003E4__this.ShowHealingBadgePlayer = false;
			}
			else
			{
				_003C_003E4__this.ShowHealingBadgeEnemy = false;
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass95_0
	{
		public BattleViewModelRefactored _003C_003E4__this;

		public bool playerWon;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass95_1
	{
		private sealed class _003C_003CEndBattle_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass95_1 _003C_003E4__this;

			private bool _003CresultShown_003E5__1;

			private bool _003C_003Es__2;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

			private void MoveNext()
			{
				//IL_0076: Unknown result type (might be due to invalid IL or missing references)
				//IL_007b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0082: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
				//IL_010b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0110: Unknown result type (might be due to invalid IL or missing references)
				//IL_0118: Unknown result type (might be due to invalid IL or missing references)
				//IL_003f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0044: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
				//IL_0058: Unknown result type (might be due to invalid IL or missing references)
				//IL_0059: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					TaskAwaiter awaiter;
					TaskAwaiter<bool> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0127;
						}
						awaiter2 = _003C_003E4__this.CS_0024_003C_003E8__locals1._003C_003E4__this.ShowBattleResultPopup(_003C_003E4__this.CS_0024_003C_003E8__locals1.playerWon).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003C_003CEndBattle_003Eb__0_003Ed _003C_003CEndBattle_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003C_003CEndBattle_003Eb__0_003Ed>(ref awaiter2, ref _003C_003CEndBattle_003Eb__0_003Ed);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter2.GetResult();
					_003CresultShown_003E5__1 = _003C_003Es__2;
					if (_003CresultShown_003E5__1)
					{
						awaiter = _003C_003E4__this.CS_0024_003C_003E8__locals1._003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003C_003CEndBattle_003Eb__0_003Ed _003C_003CEndBattle_003Eb__0_003Ed = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003CEndBattle_003Eb__0_003Ed>(ref awaiter, ref _003C_003CEndBattle_003Eb__0_003Ed);
							return;
						}
						goto IL_0127;
					}
					goto end_IL_0007;
					IL_0127:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003C_003E4__this.CS_0024_003C_003E8__locals1._003C_003E4__this._completionSource?.TrySetResult(_003C_003E4__this.battleResult);
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

		public BattleResultDTO battleResult;

		public _003C_003Ec__DisplayClass95_0 CS_0024_003C_003E8__locals1;

		[AsyncStateMachine(typeof(_003C_003CEndBattle_003Eb__0_003Ed))]
		[DebuggerStepThrough]
		internal global::System.Threading.Tasks.Task _003CEndBattle_003Eb__0()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003CEndBattle_003Eb__0_003Ed _003C_003CEndBattle_003Eb__0_003Ed = new _003C_003CEndBattle_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncTaskMethodBuilder)(ref _003C_003CEndBattle_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003CEndBattle_003Eb__0_003Ed>(ref _003C_003CEndBattle_003Eb__0_003Ed);
			return ((AsyncTaskMethodBuilder)(ref _003C_003CEndBattle_003Eb__0_003Ed._003C_003Et__builder)).Task;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass97_0
	{
		public bool playerWon;

		public BattleViewModelRefactored _003C_003E4__this;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass97_1
	{
		public string enemyNameText;

		public _003C_003Ec__DisplayClass97_0 CS_0024_003C_003E8__locals1;

		internal void _003CShowBattleResultPopup_003Eb__0(QuestRewardsPopupViewModel vm)
		{
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b5: Expected O, but got Unknown
			vm.CompletedText = (CS_0024_003C_003E8__locals1.playerWon ? "Victory!" : "Defeat");
			vm.CompletedText2 = (CS_0024_003C_003E8__locals1.playerWon ? ("You defeated the wild " + enemyNameText + "!") : ("You lost to " + enemyNameText + "!"));
			long num = ((!CS_0024_003C_003E8__locals1.playerWon) ? 1 : (CS_0024_003C_003E8__locals1._003C_003E4__this._earnedRewards?.Gold ?? 0));
			int num2 = ((!CS_0024_003C_003E8__locals1.playerWon) ? 1 : (CS_0024_003C_003E8__locals1._003C_003E4__this._earnedRewards?.Experience ?? 0));
			vm.EarnedGold = num.ToString();
			vm.EarnedEXP = num2.ToString();
			vm.EarnedShards = (CS_0024_003C_003E8__locals1.playerWon ? 5 : 0);
			vm.TextColor = (CS_0024_003C_003E8__locals1.playerWon ? Color.FromArgb("#027242") : Color.FromArgb("#721502"));
			vm.StrokeColor = (CS_0024_003C_003E8__locals1.playerWon ? Color.FromArgb("#027242") : Color.FromArgb("#721502"));
			vm.ShadowColor = (CS_0024_003C_003E8__locals1.playerWon ? Color.FromArgb("#9EDA84") : Color.FromArgb("#DA848D"));
			vm.OutComeBackGround = (CS_0024_003C_003E8__locals1.playerWon ? ((Brush)Application.Current.Resources["VictoryPopupGradient"]) : ((Brush)Application.Current.Resources["DefeatPopupGradient"]));
			vm.IsItem = false;
			vm.ThirdItemText = "Crystals";
			vm.ThirdItemImage = "icon_crystal.png";
			vm.IsBattleLogAvailable = true;
		}
	}

	[CompilerGenerated]
	private sealed class _003CAnimateHPDelta_003Ed__90 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpriteModel sprite;

		public int hpBefore;

		public int hpAfter;

		public int maxHP;

		public bool isPlayer;

		public BattleViewModelRefactored _003C_003E4__this;

		private _003C_003Ec__DisplayClass90_0 _003C_003E8__1;

		private double _003ColdPercentage_003E5__2;

		private int _003Cdelta_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0283: Unknown result type (might be due to invalid IL or missing references)
			//IL_0288: Unknown result type (might be due to invalid IL or missing references)
			//IL_0290: Unknown result type (might be due to invalid IL or missing references)
			//IL_0333: Unknown result type (might be due to invalid IL or missing references)
			//IL_0338: Unknown result type (might be due to invalid IL or missing references)
			//IL_0340: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0301: Unknown result type (might be due to invalid IL or missing references)
			//IL_0316: Unknown result type (might be due to invalid IL or missing references)
			//IL_0318: Unknown result type (might be due to invalid IL or missing references)
			//IL_0249: Unknown result type (might be due to invalid IL or missing references)
			//IL_024e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0263: Unknown result type (might be due to invalid IL or missing references)
			//IL_0265: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_034f;
					}
					_003C_003E8__1 = new _003C_003Ec__DisplayClass90_0();
					_003C_003E8__1.isPlayer = isPlayer;
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003ColdPercentage_003E5__2 = ((maxHP > 0) ? ((double)hpBefore / (double)maxHP) : 0.0);
					sprite.MaxHP = maxHP;
					sprite.HP = hpAfter;
					sprite.HealthPercentage = ((maxHP > 0) ? ((double)hpAfter / (double)maxHP) : 0.0);
					_003Cdelta_003E5__3 = hpAfter - hpBefore;
					_003C_003E4__this.DamageText = ((_003Cdelta_003E5__3 > 0) ? $"+{_003Cdelta_003E5__3}" : $"{_003Cdelta_003E5__3}");
					_003C_003E4__this.HealthDrainFrom = _003ColdPercentage_003E5__2;
					_003C_003E4__this.HealthDrainTo = sprite.HealthPercentage;
					_003C_003E4__this.IsHealthDrainForPlayer = _003C_003E8__1.isPlayer;
					_003C_003E4__this.TriggerHealthDrain = !_003C_003E4__this.TriggerHealthDrain;
					if (_003C_003E8__1.isPlayer)
					{
						_003C_003E4__this.ShowDamagePlayer = true;
						_003C_003E4__this.ShowHealingPlayer = _003Cdelta_003E5__3 > 0;
					}
					else
					{
						_003C_003E4__this.ShowDamageEnemy = true;
						_003C_003E4__this.ShowHealingEnemy = _003Cdelta_003E5__3 > 0;
					}
					if (_003Cdelta_003E5__3 > 0)
					{
						if (_003C_003E8__1.isPlayer)
						{
							_003C_003E4__this.ShowHealingBadgePlayer = true;
						}
						else
						{
							_003C_003E4__this.ShowHealingBadgeEnemy = true;
						}
						global::System.Threading.Tasks.Task.Run((Func<global::System.Threading.Tasks.Task>)([AsyncStateMachine(typeof(_003C_003Ec__DisplayClass90_0._003C_003CAnimateHPDelta_003Eb__0_003Ed))] [DebuggerStepThrough] () =>
						{
							//IL_0007: Unknown result type (might be due to invalid IL or missing references)
							//IL_000c: Unknown result type (might be due to invalid IL or missing references)
							_003C_003Ec__DisplayClass90_0._003C_003CAnimateHPDelta_003Eb__0_003Ed _003C_003CAnimateHPDelta_003Eb__0_003Ed = new _003C_003Ec__DisplayClass90_0._003C_003CAnimateHPDelta_003Eb__0_003Ed
							{
								_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
								_003C_003E4__this = _003C_003E8__1,
								_003C_003E1__state = -1
							};
							((AsyncTaskMethodBuilder)(ref _003C_003CAnimateHPDelta_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass90_0._003C_003CAnimateHPDelta_003Eb__0_003Ed>(ref _003C_003CAnimateHPDelta_003Eb__0_003Ed);
							return ((AsyncTaskMethodBuilder)(ref _003C_003CAnimateHPDelta_003Eb__0_003Ed._003C_003Et__builder)).Task;
						}));
					}
					awaiter2 = global::System.Threading.Tasks.Task.Delay(700).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003CAnimateHPDelta_003Ed__90 _003CAnimateHPDelta_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAnimateHPDelta_003Ed__90>(ref awaiter2, ref _003CAnimateHPDelta_003Ed__);
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
				if (_003C_003E8__1.isPlayer)
				{
					_003C_003E4__this.ShowDamagePlayer = false;
					_003C_003E4__this.ShowHealingPlayer = false;
				}
				else
				{
					_003C_003E4__this.ShowDamageEnemy = false;
					_003C_003E4__this.ShowHealingEnemy = false;
				}
				awaiter = global::System.Threading.Tasks.Task.Delay(200).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CAnimateHPDelta_003Ed__90 _003CAnimateHPDelta_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAnimateHPDelta_003Ed__90>(ref awaiter, ref _003CAnimateHPDelta_003Ed__);
					return;
				}
				goto IL_034f;
				IL_034f:
				((TaskAwaiter)(ref awaiter)).GetResult();
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
	private sealed class _003CAnimateTurnEndEffects_003Ed__89 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public TurnEndEffectResult turnEnd;

		public BattleViewModelRefactored _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_0185;
					}
					if (!turnEnd.PlayerHPChanged || _003C_003E4__this.ActivePlayerSpirit == null)
					{
						goto IL_00d4;
					}
					awaiter2 = _003C_003E4__this.AnimateHPDelta(_003C_003E4__this.ActivePlayerSpirit, turnEnd.PlayerHPBefore, turnEnd.PlayerHPAfter, turnEnd.PlayerMaxHP, isPlayer: true).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003CAnimateTurnEndEffects_003Ed__89 _003CAnimateTurnEndEffects_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAnimateTurnEndEffects_003Ed__89>(ref awaiter2, ref _003CAnimateTurnEndEffects_003Ed__);
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
				goto IL_00d4;
				IL_00d4:
				if (turnEnd.EnemyHPChanged && _003C_003E4__this.ActiveEnemy != null)
				{
					awaiter = _003C_003E4__this.AnimateHPDelta(_003C_003E4__this.ActiveEnemy, turnEnd.EnemyHPBefore, turnEnd.EnemyHPAfter, turnEnd.EnemyMaxHP, isPlayer: false).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter;
						_003CAnimateTurnEndEffects_003Ed__89 _003CAnimateTurnEndEffects_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAnimateTurnEndEffects_003Ed__89>(ref awaiter, ref _003CAnimateTurnEndEffects_003Ed__);
						return;
					}
					goto IL_0185;
				}
				goto end_IL_0007;
				IL_0185:
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
	private sealed class _003CAnimateTurnResult_003Ed__86 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleTurnResult turnResult;

		public BattleViewModelRefactored _003C_003E4__this;

		private Enumerator<AttackResult> _003C_003Es__1;

		private AttackResult _003Cattack_003E5__2;

		private bool _003CattackerIsPlayer_003E5__3;

		private bool _003CdefenderIsPlayer_003E5__4;

		private Enumerator<ActiveStatusEffect> _003C_003Es__5;

		private ActiveStatusEffect _003Ceffect_003E5__6;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0191: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_023a: Unknown result type (might be due to invalid IL or missing references)
			//IL_023f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0247: Unknown result type (might be due to invalid IL or missing references)
			//IL_0306: Unknown result type (might be due to invalid IL or missing references)
			//IL_030b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0313: Unknown result type (might be due to invalid IL or missing references)
			//IL_041a: Unknown result type (might be due to invalid IL or missing references)
			//IL_041f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0427: Unknown result type (might be due to invalid IL or missing references)
			//IL_048a: Unknown result type (might be due to invalid IL or missing references)
			//IL_048f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0497: Unknown result type (might be due to invalid IL or missing references)
			//IL_0525: Unknown result type (might be due to invalid IL or missing references)
			//IL_052a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0532: Unknown result type (might be due to invalid IL or missing references)
			//IL_06d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_06db: Unknown result type (might be due to invalid IL or missing references)
			//IL_06e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0767: Unknown result type (might be due to invalid IL or missing references)
			//IL_076c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0774: Unknown result type (might be due to invalid IL or missing references)
			//IL_04eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0450: Unknown result type (might be due to invalid IL or missing references)
			//IL_0455: Unknown result type (might be due to invalid IL or missing references)
			//IL_0505: Unknown result type (might be due to invalid IL or missing references)
			//IL_0507: Unknown result type (might be due to invalid IL or missing references)
			//IL_0200: Unknown result type (might be due to invalid IL or missing references)
			//IL_0205: Unknown result type (might be due to invalid IL or missing references)
			//IL_046a: Unknown result type (might be due to invalid IL or missing references)
			//IL_046c: Unknown result type (might be due to invalid IL or missing references)
			//IL_07c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_021a: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_072d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0732: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0747: Unknown result type (might be due to invalid IL or missing references)
			//IL_0749: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_05c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_05cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_068c: Unknown result type (might be due to invalid IL or missing references)
			//IL_069c: Unknown result type (might be due to invalid IL or missing references)
			//IL_06a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_06b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_06b8: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 7u)
				{
					_003C_003Es__1 = turnResult.Attacks.GetEnumerator();
				}
				try
				{
					TaskAwaiter awaiter8;
					TaskAwaiter awaiter7;
					TaskAwaiter awaiter6;
					TaskAwaiter awaiter5;
					TaskAwaiter awaiter4;
					TaskAwaiter awaiter3;
					TaskAwaiter awaiter2;
					TaskAwaiter awaiter;
					List<ActiveStatusEffect>? statusEffectsApplied;
					switch (num)
					{
					case 0:
						awaiter8 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01ac;
					case 1:
						awaiter7 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0256;
					case 2:
						awaiter6 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0322;
					case 3:
						awaiter5 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0436;
					case 4:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_04a6;
					case 5:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0541;
					case 6:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_06f2;
					case 7:
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0783;
					default:
						{
							if (_003C_003Es__1.MoveNext())
							{
								_003Cattack_003E5__2 = _003C_003Es__1.Current;
								_003CattackerIsPlayer_003E5__3 = _003Cattack_003E5__2.AttackerIsPlayer;
								_003CdefenderIsPlayer_003E5__4 = !_003CattackerIsPlayer_003E5__3;
								_003C_003E4__this.IsPlayerTurn = _003CattackerIsPlayer_003E5__3;
								_003C_003E4__this.CurrentMoveName = _003Cattack_003E5__2.MoveName;
								_003C_003E4__this.CurrentMoveTypeIcon = "type" + ((object)_003Cattack_003E5__2.MoveType).ToString().ToLower() + ".png";
								_003C_003E4__this.Effectiveness = _003Cattack_003E5__2.Effectiveness;
								if (_003CattackerIsPlayer_003E5__3)
								{
									_003C_003E4__this.ShowMoveIndicatorPlayer = true;
								}
								else
								{
									_003C_003E4__this.ShowMoveIndicatorEnemy = true;
								}
								awaiter8 = global::System.Threading.Tasks.Task.Delay(350).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter8)).IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter8;
									_003CAnimateTurnResult_003Ed__86 _003CAnimateTurnResult_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAnimateTurnResult_003Ed__86>(ref awaiter8, ref _003CAnimateTurnResult_003Ed__);
									return;
								}
								goto IL_01ac;
							}
							break;
						}
						IL_01ac:
						((TaskAwaiter)(ref awaiter8)).GetResult();
						if (_003CattackerIsPlayer_003E5__3)
						{
							_003C_003E4__this.TriggerPlayerAttack = !_003C_003E4__this.TriggerPlayerAttack;
						}
						else
						{
							_003C_003E4__this.TriggerEnemyAttack = !_003C_003E4__this.TriggerEnemyAttack;
						}
						awaiter7 = global::System.Threading.Tasks.Task.Delay(250).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter7)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter7;
							_003CAnimateTurnResult_003Ed__86 _003CAnimateTurnResult_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAnimateTurnResult_003Ed__86>(ref awaiter7, ref _003CAnimateTurnResult_003Ed__);
							return;
						}
						goto IL_0256;
						IL_06f2:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						goto IL_06fb;
						IL_0541:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						if (_003CdefenderIsPlayer_003E5__4)
						{
							_003C_003E4__this.ShowCriticalPlayer = false;
						}
						else
						{
							_003C_003E4__this.ShowCriticalEnemy = false;
						}
						statusEffectsApplied = _003Cattack_003E5__2.StatusEffectsApplied;
						if (statusEffectsApplied != null && statusEffectsApplied.Count > 0)
						{
							object obj = _003Cattack_003E5__2?.StatusEffectsApplied;
							if (obj == null)
							{
								obj = new List<ActiveStatusEffect>(1);
								((List<ActiveStatusEffect>)obj).Add(new ActiveStatusEffect(StatusEffectType.None, 0, 0f));
							}
							_003C_003Es__5 = ((List<ActiveStatusEffect>)obj).GetEnumerator();
							try
							{
								while (_003C_003Es__5.MoveNext())
								{
									_003Ceffect_003E5__6 = _003C_003Es__5.Current;
									if (_003Ceffect_003E5__6.Type == StatusEffectType.Poison)
									{
										if (_003CdefenderIsPlayer_003E5__4)
										{
											_003C_003E4__this._poisonTurnsRemainingPlayer = _003Ceffect_003E5__6.TurnsRemaining;
											_003C_003E4__this.ShowPoisonBadgePlayer = true;
										}
										else
										{
											_003C_003E4__this._poisonTurnsRemainingEnemy = _003Ceffect_003E5__6.TurnsRemaining;
											_003C_003E4__this.ShowPoisonBadgeEnemy = true;
										}
									}
									_003Ceffect_003E5__6 = null;
								}
							}
							finally
							{
								if (num < 0)
								{
									((global::System.IDisposable)_003C_003Es__5).Dispose();
								}
							}
							_003C_003Es__5 = default(Enumerator<ActiveStatusEffect>);
							awaiter2 = global::System.Threading.Tasks.Task.Delay(600).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 6);
								_003C_003Eu__1 = awaiter2;
								_003CAnimateTurnResult_003Ed__86 _003CAnimateTurnResult_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAnimateTurnResult_003Ed__86>(ref awaiter2, ref _003CAnimateTurnResult_003Ed__);
								return;
							}
							goto IL_06f2;
						}
						goto IL_06fb;
						IL_0322:
						((TaskAwaiter)(ref awaiter6)).GetResult();
						if (_003CdefenderIsPlayer_003E5__4)
						{
							_003C_003E4__this.ShowStatusEffectPlayer = false;
						}
						else
						{
							_003C_003E4__this.ShowStatusEffectEnemy = false;
						}
						if (_003CattackerIsPlayer_003E5__3)
						{
							_003C_003E4__this.ShowMoveIndicatorPlayer = false;
						}
						else
						{
							_003C_003E4__this.ShowMoveIndicatorEnemy = false;
						}
						goto default;
						IL_04a6:
						((TaskAwaiter)(ref awaiter4)).GetResult();
						_003C_003E4__this.DamageTextColor = Color.FromArgb("#EDF8EA");
						_003C_003E4__this.DamageStrokeColor = Color.FromArgb("#DE0A00");
						awaiter3 = _003C_003E4__this.ApplyAttackerPostCombatAnimation(_003Cattack_003E5__2).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 5);
							_003C_003Eu__1 = awaiter3;
							_003CAnimateTurnResult_003Ed__86 _003CAnimateTurnResult_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAnimateTurnResult_003Ed__86>(ref awaiter3, ref _003CAnimateTurnResult_003Ed__);
							return;
						}
						goto IL_0541;
						IL_0256:
						((TaskAwaiter)(ref awaiter7)).GetResult();
						if (_003Cattack_003E5__2.Missed)
						{
							_003C_003E4__this.StatusEffectText = "EVADED!";
							_003C_003E4__this.StatusEffectColor = Color.FromArgb("#4A90D9");
							if (_003CdefenderIsPlayer_003E5__4)
							{
								_003C_003E4__this.ShowStatusEffectPlayer = true;
							}
							else
							{
								_003C_003E4__this.ShowStatusEffectEnemy = true;
							}
							awaiter6 = global::System.Threading.Tasks.Task.Delay(800).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter6)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__1 = awaiter6;
								_003CAnimateTurnResult_003Ed__86 _003CAnimateTurnResult_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAnimateTurnResult_003Ed__86>(ref awaiter6, ref _003CAnimateTurnResult_003Ed__);
								return;
							}
							goto IL_0322;
						}
						if (_003Cattack_003E5__2.IsCritical)
						{
							_003C_003E4__this.TriggerCriticalHit = !_003C_003E4__this.TriggerCriticalHit;
							if (_003CdefenderIsPlayer_003E5__4)
							{
								_003C_003E4__this.ShowCriticalPlayer = true;
							}
							else
							{
								_003C_003E4__this.ShowCriticalEnemy = true;
							}
							awaiter5 = global::System.Threading.Tasks.Task.Delay(200).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__1 = awaiter5;
								_003CAnimateTurnResult_003Ed__86 _003CAnimateTurnResult_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAnimateTurnResult_003Ed__86>(ref awaiter5, ref _003CAnimateTurnResult_003Ed__);
								return;
							}
							goto IL_0436;
						}
						goto IL_043f;
						IL_06fb:
						if (_003CattackerIsPlayer_003E5__3)
						{
							_003C_003E4__this.ShowMoveIndicatorPlayer = false;
						}
						else
						{
							_003C_003E4__this.ShowMoveIndicatorEnemy = false;
						}
						awaiter = global::System.Threading.Tasks.Task.Delay(350).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 7);
							_003C_003Eu__1 = awaiter;
							_003CAnimateTurnResult_003Ed__86 _003CAnimateTurnResult_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAnimateTurnResult_003Ed__86>(ref awaiter, ref _003CAnimateTurnResult_003Ed__);
							return;
						}
						goto IL_0783;
						IL_0436:
						((TaskAwaiter)(ref awaiter5)).GetResult();
						goto IL_043f;
						IL_0783:
						((TaskAwaiter)(ref awaiter)).GetResult();
						_003Cattack_003E5__2 = null;
						goto default;
						IL_043f:
						awaiter4 = _003C_003E4__this.ApplyDamageAnimation(_003Cattack_003E5__2).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
						{
							num = (_003C_003E1__state = 4);
							_003C_003Eu__1 = awaiter4;
							_003CAnimateTurnResult_003Ed__86 _003CAnimateTurnResult_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAnimateTurnResult_003Ed__86>(ref awaiter4, ref _003CAnimateTurnResult_003Ed__);
							return;
						}
						goto IL_04a6;
					}
				}
				finally
				{
					if (num < 0)
					{
						((global::System.IDisposable)_003C_003Es__1).Dispose();
					}
				}
				_003C_003Es__1 = default(Enumerator<AttackResult>);
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
	private sealed class _003CApplyAttackerPostCombatAnimation_003Ed__91 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public AttackResult attack;

		public BattleViewModelRefactored _003C_003E4__this;

		private bool _003CattackerIsPlayer_003E5__1;

		private SpriteModel _003CattackerSprite_003E5__2;

		private int _003ColdHP_003E5__3;

		private bool _003ChpDecreased_003E5__4;

		private double _003ColdHealthPercentage_003E5__5;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0291: Unknown result type (might be due to invalid IL or missing references)
			//IL_0296: Unknown result type (might be due to invalid IL or missing references)
			//IL_029e: Unknown result type (might be due to invalid IL or missing references)
			//IL_031e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0323: Unknown result type (might be due to invalid IL or missing references)
			//IL_032b: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_0301: Unknown result type (might be due to invalid IL or missing references)
			//IL_0303: Unknown result type (might be due to invalid IL or missing references)
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			//IL_025c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0271: Unknown result type (might be due to invalid IL or missing references)
			//IL_0273: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_02ad;
				}
				TaskAwaiter awaiter2;
				if (num == 1)
				{
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_033a;
				}
				_003CattackerIsPlayer_003E5__1 = attack.AttackerIsPlayer;
				_003CattackerSprite_003E5__2 = (_003CattackerIsPlayer_003E5__1 ? _003C_003E4__this.ActivePlayerSpirit : _003C_003E4__this.ActiveEnemy);
				if (_003CattackerSprite_003E5__2 != null && attack.AttackerHPAfter != _003CattackerSprite_003E5__2.HP)
				{
					_003ColdHP_003E5__3 = _003CattackerSprite_003E5__2.HP;
					_003ChpDecreased_003E5__4 = attack.AttackerHPAfter < _003ColdHP_003E5__3;
					_003ColdHealthPercentage_003E5__5 = _003CattackerSprite_003E5__2.HealthPercentage;
					_003CattackerSprite_003E5__2.MaxHP = attack.AttackerMaxHP;
					_003CattackerSprite_003E5__2.HP = attack.AttackerHPAfter;
					_003CattackerSprite_003E5__2.HealthPercentage = (double)attack.AttackerHPAfter / (double)attack.AttackerMaxHP;
					if (_003ChpDecreased_003E5__4 && attack.RecoilDamage > 0)
					{
						_003C_003E4__this.TriggerRecoilShake = !_003C_003E4__this.TriggerRecoilShake;
					}
					_003C_003E4__this.DamageText = (_003ChpDecreased_003E5__4 ? $"-{_003ColdHP_003E5__3 - attack.AttackerHPAfter}" : $"+{attack.AttackerHPAfter - _003ColdHP_003E5__3}");
					if (_003CattackerIsPlayer_003E5__1)
					{
						_003C_003E4__this.ShowDamagePlayer = true;
					}
					else
					{
						_003C_003E4__this.ShowDamageEnemy = true;
					}
					_003C_003E4__this.HealthDrainFrom = _003ColdHealthPercentage_003E5__5;
					_003C_003E4__this.HealthDrainTo = _003CattackerSprite_003E5__2.HealthPercentage;
					_003C_003E4__this.IsHealthDrainForPlayer = _003CattackerIsPlayer_003E5__1;
					_003C_003E4__this.TriggerHealthDrain = !_003C_003E4__this.TriggerHealthDrain;
					awaiter = global::System.Threading.Tasks.Task.Delay(600).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CApplyAttackerPostCombatAnimation_003Ed__91 _003CApplyAttackerPostCombatAnimation_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CApplyAttackerPostCombatAnimation_003Ed__91>(ref awaiter, ref _003CApplyAttackerPostCombatAnimation_003Ed__);
						return;
					}
					goto IL_02ad;
				}
				goto end_IL_0007;
				IL_033a:
				((TaskAwaiter)(ref awaiter2)).GetResult();
				goto end_IL_0007;
				IL_02ad:
				((TaskAwaiter)(ref awaiter)).GetResult();
				if (_003CattackerIsPlayer_003E5__1)
				{
					_003C_003E4__this.ShowDamagePlayer = false;
				}
				else
				{
					_003C_003E4__this.ShowDamageEnemy = false;
				}
				awaiter2 = global::System.Threading.Tasks.Task.Delay(150).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter2;
					_003CApplyAttackerPostCombatAnimation_003Ed__91 _003CApplyAttackerPostCombatAnimation_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CApplyAttackerPostCombatAnimation_003Ed__91>(ref awaiter2, ref _003CApplyAttackerPostCombatAnimation_003Ed__);
					return;
				}
				goto IL_033a;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CattackerSprite_003E5__2 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CattackerSprite_003E5__2 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CApplyDamageAnimation_003Ed__88 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public AttackResult attack;

		public BattleViewModelRefactored _003C_003E4__this;

		private bool _003CdefenderIsPlayer_003E5__1;

		private SpriteModel _003CdefenderSprite_003E5__2;

		private double _003ColdHealthPercentage_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_028f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0294: Unknown result type (might be due to invalid IL or missing references)
			//IL_029c: Unknown result type (might be due to invalid IL or missing references)
			//IL_031f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0324: Unknown result type (might be due to invalid IL or missing references)
			//IL_032c: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_0375: Unknown result type (might be due to invalid IL or missing references)
			//IL_037a: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0301: Unknown result type (might be due to invalid IL or missing references)
			//IL_038f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0391: Unknown result type (might be due to invalid IL or missing references)
			//IL_0255: Unknown result type (might be due to invalid IL or missing references)
			//IL_025a: Unknown result type (might be due to invalid IL or missing references)
			//IL_026f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0271: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter3;
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					_003CdefenderIsPlayer_003E5__1 = !attack.AttackerIsPlayer;
					_003CdefenderSprite_003E5__2 = (_003CdefenderIsPlayer_003E5__1 ? _003C_003E4__this.ActivePlayerSpirit : _003C_003E4__this.ActiveEnemy);
					if (_003CdefenderSprite_003E5__2 != null)
					{
						_003ColdHealthPercentage_003E5__3 = _003CdefenderSprite_003E5__2.HealthPercentage;
						_003CdefenderSprite_003E5__2.MaxHP = attack.DefenderMaxHP;
						_003CdefenderSprite_003E5__2.HP = attack.DefenderHPAfter;
						_003CdefenderSprite_003E5__2.HealthPercentage = (double)attack.DefenderHPAfter / (double)attack.DefenderMaxHP;
						_003C_003E4__this.DamageText = (attack.IsCritical ? $"-{attack.Damage}" : $"-{attack.Damage}");
						if (_003CdefenderSprite_003E5__2.HP <= 0)
						{
							_003C_003E4__this.DamageTextColor = Color.FromArgb("#DE0A00");
							_003C_003E4__this.DamageStrokeColor = Color.FromArgb("#EDF8EA");
						}
						Console.WriteLine($"BattleViewModel: Applying {attack.Damage} damage to {(_003CdefenderIsPlayer_003E5__1 ? "player" : "enemy")}");
						_003C_003E4__this.HealthDrainFrom = _003ColdHealthPercentage_003E5__3;
						_003C_003E4__this.HealthDrainTo = _003CdefenderSprite_003E5__2.HealthPercentage;
						_003C_003E4__this.IsHealthDrainForPlayer = _003CdefenderIsPlayer_003E5__1;
						_003C_003E4__this.TriggerHealthDrain = !_003C_003E4__this.TriggerHealthDrain;
						awaiter3 = global::System.Threading.Tasks.Task.Delay(50).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CApplyDamageAnimation_003Ed__88 _003CApplyDamageAnimation_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CApplyDamageAnimation_003Ed__88>(ref awaiter3, ref _003CApplyDamageAnimation_003Ed__);
							return;
						}
						goto IL_02ab;
					}
					goto end_IL_0007;
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_02ab;
				case 1:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_033b;
				case 2:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_033b:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					if (_003CdefenderIsPlayer_003E5__1)
					{
						_003C_003E4__this.ShowDamagePlayer = false;
					}
					else
					{
						_003C_003E4__this.ShowDamageEnemy = false;
					}
					awaiter = global::System.Threading.Tasks.Task.Delay(150).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = awaiter;
						_003CApplyDamageAnimation_003Ed__88 _003CApplyDamageAnimation_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CApplyDamageAnimation_003Ed__88>(ref awaiter, ref _003CApplyDamageAnimation_003Ed__);
						return;
					}
					break;
					IL_02ab:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					if (_003CdefenderIsPlayer_003E5__1)
					{
						_003C_003E4__this.ShowDamagePlayer = true;
					}
					else
					{
						_003C_003E4__this.ShowDamageEnemy = true;
					}
					awaiter2 = global::System.Threading.Tasks.Task.Delay(750).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter2;
						_003CApplyDamageAnimation_003Ed__88 _003CApplyDamageAnimation_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CApplyDamageAnimation_003Ed__88>(ref awaiter2, ref _003CApplyDamageAnimation_003Ed__);
						return;
					}
					goto IL_033b;
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CdefenderSprite_003E5__2 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CdefenderSprite_003E5__2 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CEndBattle_003Ed__95 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public bool playerWon;

		public BattleViewModelRefactored _003C_003E4__this;

		private _003C_003Ec__DisplayClass95_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass95_1 _003C_003E8__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass95_0();
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003C_003E8__1.playerWon = playerWon;
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						_003C_003E8__2 = new _003C_003Ec__DisplayClass95_1();
						_003C_003E8__2.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
						Console.WriteLine($"BattleViewModel: Battle ended - Player won: {_003C_003E8__2.CS_0024_003C_003E8__locals1.playerWon}");
						_003C_003E4__this.IsBattleActive = false;
						_003C_003E4__this.CurrentState = BattleViewState.Ended;
						_003C_003E8__2.battleResult = _003C_003E4__this.BuildBattleResult(_003C_003E8__2.CS_0024_003C_003E8__locals1.playerWon);
						awaiter = MainThread.InvokeOnMainThreadAsync((Func<global::System.Threading.Tasks.Task>)([AsyncStateMachine(typeof(_003C_003Ec__DisplayClass95_1._003C_003CEndBattle_003Eb__0_003Ed))] [DebuggerStepThrough] () =>
						{
							//IL_0007: Unknown result type (might be due to invalid IL or missing references)
							//IL_000c: Unknown result type (might be due to invalid IL or missing references)
							_003C_003Ec__DisplayClass95_1._003C_003CEndBattle_003Eb__0_003Ed _003C_003CEndBattle_003Eb__0_003Ed = new _003C_003Ec__DisplayClass95_1._003C_003CEndBattle_003Eb__0_003Ed
							{
								_003C_003Et__builder = AsyncTaskMethodBuilder.Create(),
								_003C_003E4__this = _003C_003E8__2,
								_003C_003E1__state = -1
							};
							((AsyncTaskMethodBuilder)(ref _003C_003CEndBattle_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass95_1._003C_003CEndBattle_003Eb__0_003Ed>(ref _003C_003CEndBattle_003Eb__0_003Ed);
							return ((AsyncTaskMethodBuilder)(ref _003C_003CEndBattle_003Eb__0_003Ed._003C_003Et__builder)).Task;
						})).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CEndBattle_003Ed__95 _003CEndBattle_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CEndBattle_003Ed__95>(ref awaiter, ref _003CEndBattle_003Ed__);
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
					_003C_003E8__2 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine($"EndBattle error: {_003Cex_003E5__3}");
					_003C_003E4__this._completionSource?.TrySetException(_003Cex_003E5__3);
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
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
	private sealed class _003CExecuteBattleRound_003Ed__85 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleViewModelRefactored _003C_003E4__this;

		private ExecuteBattleTurnRequest _003Crequest_003E5__1;

		private Result<BattleTurnResult> _003Cresult_003E5__2;

		private Result<BattleTurnResult> _003C_003Es__3;

		private TaskAwaiter<Result<BattleTurnResult>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_027d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0282: Unknown result type (might be due to invalid IL or missing references)
			//IL_028a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0308: Unknown result type (might be due to invalid IL or missing references)
			//IL_030d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0315: Unknown result type (might be due to invalid IL or missing references)
			//IL_0387: Unknown result type (might be due to invalid IL or missing references)
			//IL_038c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0394: Unknown result type (might be due to invalid IL or missing references)
			//IL_0413: Unknown result type (might be due to invalid IL or missing references)
			//IL_0418: Unknown result type (might be due to invalid IL or missing references)
			//IL_0420: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0244: Unknown result type (might be due to invalid IL or missing references)
			//IL_0249: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_034e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0353: Unknown result type (might be due to invalid IL or missing references)
			//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Unknown result type (might be due to invalid IL or missing references)
			//IL_025e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0260: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0368: Unknown result type (might be due to invalid IL or missing references)
			//IL_036a: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 5u || (_003C_003E4__this.CurrentState == BattleViewState.Idle && _003C_003E4__this._battleState != null))
				{
					try
					{
						TaskAwaiter<Result<BattleTurnResult>> awaiter6;
						TaskAwaiter awaiter5;
						TaskAwaiter awaiter4;
						TaskAwaiter awaiter3;
						TaskAwaiter awaiter2;
						TaskAwaiter awaiter;
						switch (num)
						{
						default:
							_003C_003E4__this.CurrentState = BattleViewState.Attacking;
							_003Crequest_003E5__1 = new ExecuteBattleTurnRequest(_003C_003E4__this._battleState);
							awaiter6 = _003C_003E4__this._executeBattleTurnUseCase.ExecuteAsync(_003Crequest_003E5__1).GetAwaiter();
							if (!awaiter6.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter6;
								_003CExecuteBattleRound_003Ed__85 _003CExecuteBattleRound_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<BattleTurnResult>>, _003CExecuteBattleRound_003Ed__85>(ref awaiter6, ref _003CExecuteBattleRound_003Ed__);
								return;
							}
							goto IL_0103;
						case 0:
							awaiter6 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<Result<BattleTurnResult>>);
							num = (_003C_003E1__state = -1);
							goto IL_0103;
						case 1:
							awaiter5 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_01d3;
						case 2:
							awaiter4 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0299;
						case 3:
							awaiter3 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0324;
						case 4:
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_03a3;
						case 5:
							{
								awaiter = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_042f;
							}
							IL_0299:
							((TaskAwaiter)(ref awaiter4)).GetResult();
							goto IL_02a1;
							IL_0103:
							_003C_003Es__3 = awaiter6.GetResult();
							_003Cresult_003E5__2 = _003C_003Es__3;
							_003C_003Es__3 = null;
							if (_003Cresult_003E5__2.Success && _003Cresult_003E5__2.Data != null)
							{
								awaiter5 = _003C_003E4__this.AnimateTurnResult(_003Cresult_003E5__2.Data).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter5;
									_003CExecuteBattleRound_003Ed__85 _003CExecuteBattleRound_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteBattleRound_003Ed__85>(ref awaiter5, ref _003CExecuteBattleRound_003Ed__);
									return;
								}
								goto IL_01d3;
							}
							Console.WriteLine("Battle turn failed: " + _003Cresult_003E5__2.ErrorMessage);
							goto end_IL_0038;
							IL_02a1:
							_003C_003E4__this.TickPoisonBadges();
							if (_003Cresult_003E5__2.Data.EnemySpiritDefeated)
							{
								awaiter3 = _003C_003E4__this.HandleDefeatedSpirit(defeatedSpiritIsPlayer: false).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
								{
									num = (_003C_003E1__state = 3);
									_003C_003Eu__2 = awaiter3;
									_003CExecuteBattleRound_003Ed__85 _003CExecuteBattleRound_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteBattleRound_003Ed__85>(ref awaiter3, ref _003CExecuteBattleRound_003Ed__);
									return;
								}
								goto IL_0324;
							}
							goto IL_032c;
							IL_03a3:
							((TaskAwaiter)(ref awaiter2)).GetResult();
							goto IL_03ab;
							IL_03ab:
							if (!_003Cresult_003E5__2.Data.BattleEnded)
							{
								break;
							}
							awaiter = _003C_003E4__this.EndBattle(_003Cresult_003E5__2.Data.PlayerVictory).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 5);
								_003C_003Eu__2 = awaiter;
								_003CExecuteBattleRound_003Ed__85 _003CExecuteBattleRound_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteBattleRound_003Ed__85>(ref awaiter, ref _003CExecuteBattleRound_003Ed__);
								return;
							}
							goto IL_042f;
							IL_01d3:
							((TaskAwaiter)(ref awaiter5)).GetResult();
							if (!_003Cresult_003E5__2.Data.BattleEnded)
							{
								_003C_003E4__this.CurrentTurn = _003C_003E4__this._battleState.CurrentTurn;
							}
							if (_003Cresult_003E5__2.Data.TurnEndEffects != null)
							{
								awaiter4 = _003C_003E4__this.AnimateTurnEndEffects(_003Cresult_003E5__2.Data.TurnEndEffects).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__2 = awaiter4;
									_003CExecuteBattleRound_003Ed__85 _003CExecuteBattleRound_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteBattleRound_003Ed__85>(ref awaiter4, ref _003CExecuteBattleRound_003Ed__);
									return;
								}
								goto IL_0299;
							}
							goto IL_02a1;
							IL_032c:
							if (_003Cresult_003E5__2.Data.PlayerSpiritDefeated)
							{
								awaiter2 = _003C_003E4__this.HandleDefeatedSpirit(defeatedSpiritIsPlayer: true).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 4);
									_003C_003Eu__2 = awaiter2;
									_003CExecuteBattleRound_003Ed__85 _003CExecuteBattleRound_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteBattleRound_003Ed__85>(ref awaiter2, ref _003CExecuteBattleRound_003Ed__);
									return;
								}
								goto IL_03a3;
							}
							goto IL_03ab;
							IL_0324:
							((TaskAwaiter)(ref awaiter3)).GetResult();
							goto IL_032c;
							IL_042f:
							((TaskAwaiter)(ref awaiter)).GetResult();
							break;
						}
						_003Crequest_003E5__1 = null;
						_003Cresult_003E5__2 = null;
						end_IL_0038:;
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.CurrentState = BattleViewState.Idle;
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
	private sealed class _003CGoBack_003Ed__98 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleViewModelRefactored _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						_003C_003E4__this.IsBattleActive = false;
						_003C_003E4__this.CurrentState = BattleViewState.Ended;
						awaiter = _003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGoBack_003Ed__98 _003CGoBack_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoBack_003Ed__98>(ref awaiter, ref _003CGoBack_003Ed__);
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
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__1 = ex;
					Console.WriteLine($"GoBack error: {_003Cex_003E5__1}");
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
	private sealed class _003CHandleDefeatedSpirit_003Ed__92 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public bool defeatedSpiritIsPlayer;

		public BattleViewModelRefactored _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0152: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_0273: Unknown result type (might be due to invalid IL or missing references)
			//IL_0278: Unknown result type (might be due to invalid IL or missing references)
			//IL_0280: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_023d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0242: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			//IL_0259: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter4;
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter3;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					if (defeatedSpiritIsPlayer)
					{
						Console.WriteLine("BattleViewModel: Player spirit defeated");
						((Collection<SpriteModel>)(object)_003C_003E4__this.PlayerSpirits)[_003C_003E4__this.ActivePlayerSpiritIndex].IsFainted = true;
						awaiter4 = global::System.Threading.Tasks.Task.Delay(300).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter4;
							_003CHandleDefeatedSpirit_003Ed__92 _003CHandleDefeatedSpirit_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleDefeatedSpirit_003Ed__92>(ref awaiter4, ref _003CHandleDefeatedSpirit_003Ed__);
							return;
						}
						goto IL_00cb;
					}
					Console.WriteLine("BattleViewModel: Enemy spirit defeated");
					((Collection<SpriteModel>)(object)_003C_003E4__this.EnemySpirits)[_003C_003E4__this.ActiveEnemyIndex].IsFainted = true;
					awaiter2 = global::System.Threading.Tasks.Task.Delay(300).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = awaiter2;
						_003CHandleDefeatedSpirit_003Ed__92 _003CHandleDefeatedSpirit_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleDefeatedSpirit_003Ed__92>(ref awaiter2, ref _003CHandleDefeatedSpirit_003Ed__);
						return;
					}
					goto IL_01fc;
				case 0:
					awaiter4 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00cb;
				case 1:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0161;
				case 2:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01fc;
				case 3:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_01fc:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					if (_003C_003E4__this.ActiveEnemyIndex + 1 < ((Collection<SpriteModel>)(object)_003C_003E4__this.EnemySpirits).Count)
					{
						awaiter = _003C_003E4__this.SwitchEnemySpirit().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__1 = awaiter;
							_003CHandleDefeatedSpirit_003Ed__92 _003CHandleDefeatedSpirit_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleDefeatedSpirit_003Ed__92>(ref awaiter, ref _003CHandleDefeatedSpirit_003Ed__);
							return;
						}
						break;
					}
					goto end_IL_0007;
					IL_0161:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					goto end_IL_0007;
					IL_00cb:
					((TaskAwaiter)(ref awaiter4)).GetResult();
					if (_003C_003E4__this.ActivePlayerSpiritIndex + 1 < ((Collection<SpriteModel>)(object)_003C_003E4__this.PlayerSpirits).Count)
					{
						awaiter3 = _003C_003E4__this.SwitchPlayerSpirit().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter3;
							_003CHandleDefeatedSpirit_003Ed__92 _003CHandleDefeatedSpirit_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleDefeatedSpirit_003Ed__92>(ref awaiter3, ref _003CHandleDefeatedSpirit_003Ed__);
							return;
						}
						goto IL_0161;
					}
					goto end_IL_0007;
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
	private sealed class _003CInitializeBattleFromRequest_003Ed__79 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<BattleState> _003C_003Et__builder;

		public BattleLaunchRequest request;

		public BattleViewModelRefactored _003C_003E4__this;

		private Result<BattleState> _003Cresult_003E5__1;

		private StartQuestBattleRequest _003CquestRequest_003E5__2;

		private Result<BattleState> _003C_003Es__3;

		private StartGuildWarBattleInitRequest _003CguildWarRequest_003E5__4;

		private Result<BattleState> _003C_003Es__5;

		private StartFriendBattleInitRequest _003CfriendBattleRequest_003E5__6;

		private Result<BattleState> _003C_003Es__7;

		private StartPVPBattleRequest _003CpvpRequest_003E5__8;

		private Result<BattleState> _003C_003Es__9;

		private global::System.Exception _003Cex_003E5__10;

		private TaskAwaiter<Result<BattleState>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_014d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0152: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_0231: Unknown result type (might be due to invalid IL or missing references)
			//IL_0236: Unknown result type (might be due to invalid IL or missing references)
			//IL_023e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0347: Unknown result type (might be due to invalid IL or missing references)
			//IL_034c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0354: Unknown result type (might be due to invalid IL or missing references)
			//IL_0440: Unknown result type (might be due to invalid IL or missing references)
			//IL_0445: Unknown result type (might be due to invalid IL or missing references)
			//IL_044d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_030d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0312: Unknown result type (might be due to invalid IL or missing references)
			//IL_0211: Unknown result type (might be due to invalid IL or missing references)
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_0327: Unknown result type (might be due to invalid IL or missing references)
			//IL_0329: Unknown result type (might be due to invalid IL or missing references)
			//IL_0406: Unknown result type (might be due to invalid IL or missing references)
			//IL_040b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0420: Unknown result type (might be due to invalid IL or missing references)
			//IL_0422: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			BattleState result;
			try
			{
				if ((uint)num > 3u)
				{
				}
				try
				{
					TaskAwaiter<Result<BattleState>> awaiter4;
					TaskAwaiter<Result<BattleState>> awaiter3;
					TaskAwaiter<Result<BattleState>> awaiter2;
					TaskAwaiter<Result<BattleState>> awaiter;
					switch (num)
					{
					default:
						if (!string.IsNullOrEmpty(request.QuestTaskId))
						{
							_003C_003E4__this._earnedRewards = new Rewards
							{
								Experience = (request.QuestRewards?.Experience ?? 0),
								Gold = (request.QuestRewards?.Gold ?? 0)
							};
							_003CquestRequest_003E5__2 = new StartQuestBattleRequest(request.PlayerSpiritIds, request.QuestOpponents, request.Mode, request.QuestTaskId, 0, request.ChallengerGuildName, request.ChallengerName, null, request.ChallengerBackgroundImage);
							awaiter4 = _003C_003E4__this._startQuestBattleUseCase.ExecuteAsync(_003CquestRequest_003E5__2).GetAwaiter();
							if (!awaiter4.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter4;
								_003CInitializeBattleFromRequest_003Ed__79 _003CInitializeBattleFromRequest_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Result<BattleState>>, _003CInitializeBattleFromRequest_003Ed__79>(ref awaiter4, ref _003CInitializeBattleFromRequest_003Ed__);
								return;
							}
							goto IL_0168;
						}
						if (request.IsGuildWarBattle)
						{
							_003CguildWarRequest_003E5__4 = new StartGuildWarBattleInitRequest(request.PlayerId, request.PlayerSpiritIds, request.OpponentPlayerId, request.OpponentSpiritIds);
							awaiter3 = _003C_003E4__this._startGuildWarBattleInitUseCase.ExecuteAsync(_003CguildWarRequest_003E5__4).GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter3;
								_003CInitializeBattleFromRequest_003Ed__79 _003CInitializeBattleFromRequest_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Result<BattleState>>, _003CInitializeBattleFromRequest_003Ed__79>(ref awaiter3, ref _003CInitializeBattleFromRequest_003Ed__);
								return;
							}
							goto IL_024d;
						}
						if (request.Mode == BattleMode.FriendBattle)
						{
							_003CfriendBattleRequest_003E5__6 = new StartFriendBattleInitRequest(request.PlayerId, request.PlayerSpiritIds, request.OpponentPlayerId, request.OpponentSpiritIds);
							awaiter2 = _003C_003E4__this._startFriendBattleInitUseCase.ExecuteAsync(_003CfriendBattleRequest_003E5__6).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__1 = awaiter2;
								_003CInitializeBattleFromRequest_003Ed__79 _003CInitializeBattleFromRequest_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Result<BattleState>>, _003CInitializeBattleFromRequest_003Ed__79>(ref awaiter2, ref _003CInitializeBattleFromRequest_003Ed__);
								return;
							}
							goto IL_0363;
						}
						if (request.HasOpponentSpirits)
						{
							_003CpvpRequest_003E5__8 = new StartPVPBattleRequest(request.PlayerId, request.PlayerSpiritIds, request.OpponentName ?? "Opponent", request.OpponentSpirits, request.Mode);
							awaiter = _003C_003E4__this._startPVPBattleUseCase.ExecuteAsync(_003CpvpRequest_003E5__8).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__1 = awaiter;
								_003CInitializeBattleFromRequest_003Ed__79 _003CInitializeBattleFromRequest_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Result<BattleState>>, _003CInitializeBattleFromRequest_003Ed__79>(ref awaiter, ref _003CInitializeBattleFromRequest_003Ed__);
								return;
							}
							goto IL_045c;
						}
						result = null;
						goto end_IL_0011;
					case 0:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<BattleState>>);
						num = (_003C_003E1__state = -1);
						goto IL_0168;
					case 1:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<BattleState>>);
						num = (_003C_003E1__state = -1);
						goto IL_024d;
					case 2:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<BattleState>>);
						num = (_003C_003E1__state = -1);
						goto IL_0363;
					case 3:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<Result<BattleState>>);
							num = (_003C_003E1__state = -1);
							goto IL_045c;
						}
						IL_0363:
						_003C_003Es__7 = awaiter2.GetResult();
						_003Cresult_003E5__1 = _003C_003Es__7;
						_003C_003Es__7 = null;
						_003CfriendBattleRequest_003E5__6 = null;
						break;
						IL_024d:
						_003C_003Es__5 = awaiter3.GetResult();
						_003Cresult_003E5__1 = _003C_003Es__5;
						_003C_003Es__5 = null;
						_003C_003E4__this.EnemyGuildName = request.DefendingGuildId;
						_003C_003E4__this.PlayerGuildName = request.AttackingGuildId;
						_003CguildWarRequest_003E5__4 = null;
						break;
						IL_0168:
						_003C_003Es__3 = awaiter4.GetResult();
						_003Cresult_003E5__1 = _003C_003Es__3;
						_003C_003Es__3 = null;
						_003CquestRequest_003E5__2 = null;
						break;
						IL_045c:
						_003C_003Es__9 = awaiter.GetResult();
						_003Cresult_003E5__1 = _003C_003Es__9;
						_003C_003Es__9 = null;
						_003CpvpRequest_003E5__8 = null;
						break;
					}
					if (!_003Cresult_003E5__1.Success)
					{
						Console.WriteLine("Failed to create battle state: " + _003Cresult_003E5__1.ErrorMessage);
						result = null;
					}
					else
					{
						result = _003Cresult_003E5__1.Data;
					}
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__10 = ex;
					Console.WriteLine($"InitializeBattleFromRequest error: {_003Cex_003E5__10}");
					result = null;
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

	[CompilerGenerated]
	private sealed class _003CInitializeBattleSequence_003Ed__83 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleViewModelRefactored _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_0231: Unknown result type (might be due to invalid IL or missing references)
			//IL_0236: Unknown result type (might be due to invalid IL or missing references)
			//IL_023e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0315: Unknown result type (might be due to invalid IL or missing references)
			//IL_031a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0322: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0212: Unknown result type (might be due to invalid IL or missing references)
			//IL_0214: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter4;
				TaskAwaiter awaiter3;
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					Console.WriteLine("BattleViewModel: InitializeBattleSequence started");
					_003C_003E4__this.CurrentState = BattleViewState.VsScreen;
					_003C_003E4__this.ShowVsScreen = true;
					_003C_003E4__this.VsScreenOpacity = 1.0;
					awaiter4 = global::System.Threading.Tasks.Task.Delay(2000).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter4;
						_003CInitializeBattleSequence_003Ed__83 _003CInitializeBattleSequence_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CInitializeBattleSequence_003Ed__83>(ref awaiter4, ref _003CInitializeBattleSequence_003Ed__);
						return;
					}
					goto IL_00ca;
				case 0:
					awaiter4 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00ca;
				case 1:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0153;
				case 2:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_024d;
				case 3:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_0263:
					Console.WriteLine("BattleViewModel: VS screen completed, starting battle with spirit entries");
					_003C_003E4__this.ShowVsScreen = false;
					_003C_003E4__this.TriggerPlayerEntry = !_003C_003E4__this.TriggerPlayerEntry;
					_003C_003E4__this.TriggerEnemyEntry = !_003C_003E4__this.TriggerEnemyEntry;
					_003C_003E4__this.CurrentTurn = _003C_003E4__this._battleState?.CurrentTurn ?? 1;
					awaiter = global::System.Threading.Tasks.Task.Delay(1000).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = awaiter;
						_003CInitializeBattleSequence_003Ed__83 _003CInitializeBattleSequence_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CInitializeBattleSequence_003Ed__83>(ref awaiter, ref _003CInitializeBattleSequence_003Ed__);
						return;
					}
					break;
					IL_00ca:
					((TaskAwaiter)(ref awaiter4)).GetResult();
					Console.WriteLine("BattleViewModel: Triggering VS fade");
					_003C_003E4__this.TriggerVsFade = !_003C_003E4__this.TriggerVsFade;
					awaiter3 = global::System.Threading.Tasks.Task.Delay(800).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter3;
						_003CInitializeBattleSequence_003Ed__83 _003CInitializeBattleSequence_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CInitializeBattleSequence_003Ed__83>(ref awaiter3, ref _003CInitializeBattleSequence_003Ed__);
						return;
					}
					goto IL_0153;
					IL_024d:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					_003C_003E4__this.ShowChallenge = false;
					goto IL_0263;
					IL_0153:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					if (!string.IsNullOrEmpty(_003C_003E4__this._battleState.QuestTaskId) && !string.IsNullOrEmpty(_003C_003E4__this._battleState.ChallengerBackgroundImage))
					{
						_003C_003E4__this.ChallengerName = _003C_003E4__this._battleState.ChallengerName ?? "";
						_003C_003E4__this.ChallengerBackgroundImage = _003C_003E4__this._battleState.ChallengerBackgroundImage ?? "";
						_003C_003E4__this.ShowChallenge = true;
						awaiter2 = global::System.Threading.Tasks.Task.Delay(1500).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = awaiter2;
							_003CInitializeBattleSequence_003Ed__83 _003CInitializeBattleSequence_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CInitializeBattleSequence_003Ed__83>(ref awaiter2, ref _003CInitializeBattleSequence_003Ed__);
							return;
						}
						goto IL_024d;
					}
					goto IL_0263;
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003C_003E4__this.CurrentState = BattleViewState.Idle;
				_003C_003E4__this.IsBattleActive = true;
				global::System.Threading.Tasks.Task.Run((Func<global::System.Threading.Tasks.Task>)_003C_003E4__this.StartBattleLoop);
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
	private sealed class _003CLoadDataAsync_003Ed__78 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object parameter;

		public BattleViewModelRefactored _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private BattleLaunchRequest _003ClaunchRequest_003E5__3;

		private BattleState _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<BattleState?> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0371: Unknown result type (might be due to invalid IL or missing references)
			//IL_0376: Unknown result type (might be due to invalid IL or missing references)
			//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_03af: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_044b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0450: Unknown result type (might be due to invalid IL or missing references)
			//IL_0458: Unknown result type (might be due to invalid IL or missing references)
			//IL_0415: Unknown result type (might be due to invalid IL or missing references)
			//IL_041a: Unknown result type (might be due to invalid IL or missing references)
			//IL_038b: Unknown result type (might be due to invalid IL or missing references)
			//IL_038d: Unknown result type (might be due to invalid IL or missing references)
			//IL_042f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0431: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02be: Unknown result type (might be due to invalid IL or missing references)
			//IL_027b: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					_003C_003Es__2 = 0;
					goto case 0;
				case 0:
				case 1:
				{
					try
					{
						TaskAwaiter awaiter3;
						TaskAwaiter<BattleState> awaiter4;
						if (num != 0)
						{
							if (num == 1)
							{
								awaiter3 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_030e;
							}
							Console.WriteLine("BattleViewModel: LoadDataAsync called");
							_003ClaunchRequest_003E5__3 = parameter as BattleLaunchRequest;
							if (_003ClaunchRequest_003E5__3 == null)
							{
								throw new ArgumentException("Invalid battle launch request");
							}
							_003C_003E4__this.CurrentState = BattleViewState.Initializing;
							_003C_003E4__this.BattleMode = _003ClaunchRequest_003E5__3.Mode;
							BattleLogCapture.Instance.BeginBattle();
							awaiter4 = _003C_003E4__this.InitializeBattleFromRequest(_003ClaunchRequest_003E5__3).GetAwaiter();
							if (!awaiter4.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter4;
								_003CLoadDataAsync_003Ed__78 _003CLoadDataAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<BattleState>, _003CLoadDataAsync_003Ed__78>(ref awaiter4, ref _003CLoadDataAsync_003Ed__);
								return;
							}
						}
						else
						{
							awaiter4 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<BattleState>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__4 = awaiter4.GetResult();
						_003C_003E4__this._battleState = _003C_003Es__4;
						_003C_003Es__4 = null;
						if (_003C_003E4__this._battleState == null)
						{
							throw new InvalidOperationException("Failed to initialize battle state");
						}
						_003C_003E4__this.PlayerSpirits = new ObservableCollection<SpriteModel>(Enumerable.Select<BattleSprite, SpriteModel>((global::System.Collections.Generic.IEnumerable<BattleSprite>)_003C_003E4__this._battleState.PlayerBattleSprites, (Func<BattleSprite, SpriteModel>)((BattleSprite bs) => new SpriteModel
						{
							Level = bs.PlayerSpirit.Level,
							Name = (bs.PlayerSpirit.Nickname ?? "Unknown"),
							PlayerName = (bs.PlayerSpirit.PlayerName ?? "Unknown"),
							Type1 = bs.BaseSpirit.Type1,
							Type2 = bs.BaseSpirit.Type2,
							HP = bs.MaxHP,
							MaxHP = bs.MaxHP,
							HealthPercentage = 1.0,
							Opacity = 1.0,
							Image = bs.BaseSpirit.Image
						})));
						_003C_003E4__this.EnemySpirits = new ObservableCollection<SpriteModel>(Enumerable.Select<BattleSprite, SpriteModel>((global::System.Collections.Generic.IEnumerable<BattleSprite>)_003C_003E4__this._battleState.OpponentBattleSprites, (Func<BattleSprite, SpriteModel>)((BattleSprite bs) => new SpriteModel
						{
							Type1 = bs.BaseSpirit.Type1,
							Type2 = bs.BaseSpirit.Type2,
							HP = bs.MaxHP,
							PlayerName = (bs.PlayerSpirit.PlayerName ?? "Unknown"),
							Name = (bs.BaseSpirit.Name ?? "Unknown"),
							Level = bs.PlayerSpirit.Level,
							MaxHP = bs.MaxHP,
							HealthPercentage = 1.0,
							Opacity = 1.0,
							Image = bs.BaseSpirit.Image
						})));
						_003C_003E4__this.ActivePlayerSpiritIndex = 0;
						_003C_003E4__this.ActiveEnemyIndex = 0;
						_003C_003E4__this.Is3v3 = ((Collection<SpriteModel>)(object)_003C_003E4__this.PlayerSpirits).Count == 3 && ((Collection<SpriteModel>)(object)_003C_003E4__this.EnemySpirits).Count == 3;
						((ObservableObject)_003C_003E4__this).OnPropertyChanged("ActivePlayerSpirit");
						((ObservableObject)_003C_003E4__this).OnPropertyChanged("ActiveEnemy");
						if (_003C_003E4__this.ActivePlayerSpirit == null || _003C_003E4__this.ActiveEnemy == null)
						{
							throw new InvalidOperationException("No valid spirits for battle");
						}
						_003C_003E4__this._dataIsLoaded = true;
						Console.WriteLine("BattleViewModel: Data loaded successfully");
						_003C_003E4__this._completionSource = _003ClaunchRequest_003E5__3.CompletionSource;
						awaiter3 = _003C_003E4__this.TryStartBattle().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter3;
							_003CLoadDataAsync_003Ed__78 _003CLoadDataAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__78>(ref awaiter3, ref _003CLoadDataAsync_003Ed__);
							return;
						}
						goto IL_030e;
						IL_030e:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						_003ClaunchRequest_003E5__3 = null;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__1 = ex;
						_003C_003Es__2 = 1;
					}
					int num2 = _003C_003Es__2;
					if (num2 != 1)
					{
						break;
					}
					_003Cex_003E5__5 = (global::System.Exception)_003C_003Es__1;
					awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Battle Error", "Failed to initialize battle").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__2 = awaiter2;
						_003CLoadDataAsync_003Ed__78 _003CLoadDataAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__78>(ref awaiter2, ref _003CLoadDataAsync_003Ed__);
						return;
					}
					goto IL_03c6;
				}
				case 2:
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_03c6;
				case 3:
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0467;
					}
					IL_0467:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003Cex_003E5__5 = null;
					break;
					IL_03c6:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					Console.WriteLine($"BattleViewModel.LoadDataAsync: {_003Cex_003E5__5}");
					awaiter = _003C_003E4__this._navigationService.NavigateToAsync("//master").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__2 = awaiter;
						_003CLoadDataAsync_003Ed__78 _003CLoadDataAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__78>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
						return;
					}
					goto IL_0467;
				}
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
	private sealed class _003CShowBattleResultPopup_003Ed__97 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public bool playerWon;

		public BattleViewModelRefactored _003C_003E4__this;

		private _003C_003Ec__DisplayClass97_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass97_1 _003C_003E8__2;

		private object _003Cresult_003E5__3;

		private object _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<object?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass97_0();
					_003C_003E8__1.playerWon = playerWon;
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
				}
				try
				{
					TaskAwaiter<object> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<object>);
						num = (_003C_003E1__state = -1);
						goto IL_016f;
					}
					_003C_003E8__2 = new _003C_003Ec__DisplayClass97_1();
					_003C_003E8__2.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
					if (_003C_003E4__this.BattleMode == BattleMode.PVE)
					{
						_003C_003E8__2.enemyNameText = ((((Collection<SpriteModel>)(object)_003C_003E4__this.EnemySpirits).Count <= 1) ? ("the wild " + (Enumerable.FirstOrDefault<SpriteModel>((global::System.Collections.Generic.IEnumerable<SpriteModel>)_003C_003E4__this.EnemySpirits)?.Name ?? "Unknown")) : (Enumerable.FirstOrDefault<SpriteModel>((global::System.Collections.Generic.IEnumerable<SpriteModel>)_003C_003E4__this.EnemySpirits)?.PlayerName ?? ""));
						awaiter = _003C_003E4__this._popupService.ShowPopupAsync<QuestRewardsPopupViewModel>((Action<QuestRewardsPopupViewModel>)delegate(QuestRewardsPopupViewModel vm)
						{
							//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
							//IL_0190: Unknown result type (might be due to invalid IL or missing references)
							//IL_01b5: Expected O, but got Unknown
							vm.CompletedText = (_003C_003E8__2.CS_0024_003C_003E8__locals1.playerWon ? "Victory!" : "Defeat");
							vm.CompletedText2 = (_003C_003E8__2.CS_0024_003C_003E8__locals1.playerWon ? ("You defeated the wild " + _003C_003E8__2.enemyNameText + "!") : ("You lost to " + _003C_003E8__2.enemyNameText + "!"));
							long num2 = ((!_003C_003E8__2.CS_0024_003C_003E8__locals1.playerWon) ? 1 : (_003C_003E8__2.CS_0024_003C_003E8__locals1._003C_003E4__this._earnedRewards?.Gold ?? 0));
							int num3 = ((!_003C_003E8__2.CS_0024_003C_003E8__locals1.playerWon) ? 1 : (_003C_003E8__2.CS_0024_003C_003E8__locals1._003C_003E4__this._earnedRewards?.Experience ?? 0));
							vm.EarnedGold = num2.ToString();
							vm.EarnedEXP = num3.ToString();
							vm.EarnedShards = (_003C_003E8__2.CS_0024_003C_003E8__locals1.playerWon ? 5 : 0);
							vm.TextColor = (_003C_003E8__2.CS_0024_003C_003E8__locals1.playerWon ? Color.FromArgb("#027242") : Color.FromArgb("#721502"));
							vm.StrokeColor = (_003C_003E8__2.CS_0024_003C_003E8__locals1.playerWon ? Color.FromArgb("#027242") : Color.FromArgb("#721502"));
							vm.ShadowColor = (_003C_003E8__2.CS_0024_003C_003E8__locals1.playerWon ? Color.FromArgb("#9EDA84") : Color.FromArgb("#DA848D"));
							vm.OutComeBackGround = (_003C_003E8__2.CS_0024_003C_003E8__locals1.playerWon ? ((Brush)Application.Current.Resources["VictoryPopupGradient"]) : ((Brush)Application.Current.Resources["DefeatPopupGradient"]));
							vm.IsItem = false;
							vm.ThirdItemText = "Crystals";
							vm.ThirdItemImage = "icon_crystal.png";
							vm.IsBattleLogAvailable = true;
						}, default(CancellationToken)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CShowBattleResultPopup_003Ed__97 _003CShowBattleResultPopup_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CShowBattleResultPopup_003Ed__97>(ref awaiter, ref _003CShowBattleResultPopup_003Ed__);
							return;
						}
						goto IL_016f;
					}
					result = true;
					goto end_IL_003d;
					IL_016f:
					_003C_003Es__4 = awaiter.GetResult();
					_003Cresult_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					result = true;
					end_IL_003d:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					Console.WriteLine($"ShowBattleResultPopup error: {_003Cex_003E5__5}");
					result = true;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
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
	private sealed class _003CStartBattleLoop_003Ed__84 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleViewModelRefactored _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_0307: Unknown result type (might be due to invalid IL or missing references)
			//IL_030c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0314: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0204: Unknown result type (might be due to invalid IL or missing references)
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if ((uint)num > 3u)
				{
					if (num == 4)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0323;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter5;
					TaskAwaiter awaiter4;
					TaskAwaiter awaiter3;
					TaskAwaiter awaiter2;
					switch (num)
					{
					default:
						Console.WriteLine("BattleViewModel: Battle loop started");
						awaiter5 = global::System.Threading.Tasks.Task.Delay(1000).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter5;
							_003CStartBattleLoop_003Ed__84 _003CStartBattleLoop_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CStartBattleLoop_003Ed__84>(ref awaiter5, ref _003CStartBattleLoop_003Ed__);
							return;
						}
						goto IL_00b4;
					case 0:
						awaiter5 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_00b4;
					case 1:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0147;
					case 2:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01b4;
					case 3:
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_021b;
						}
						IL_0147:
						((TaskAwaiter)(ref awaiter4)).GetResult();
						break;
						IL_00b4:
						((TaskAwaiter)(ref awaiter5)).GetResult();
						goto IL_0224;
						IL_0224:
						if (!_003C_003E4__this.IsBattleActive || _003C_003E4__this.CurrentState == BattleViewState.Ended || _003C_003E4__this._battleState == null)
						{
							break;
						}
						if (_003C_003E4__this._battleState.BattleEnded)
						{
							awaiter4 = _003C_003E4__this.EndBattle(_003C_003E4__this._battleState.PlayerVictory).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter4;
								_003CStartBattleLoop_003Ed__84 _003CStartBattleLoop_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CStartBattleLoop_003Ed__84>(ref awaiter4, ref _003CStartBattleLoop_003Ed__);
								return;
							}
							goto IL_0147;
						}
						awaiter3 = _003C_003E4__this.ExecuteBattleRound().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = awaiter3;
							_003CStartBattleLoop_003Ed__84 _003CStartBattleLoop_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CStartBattleLoop_003Ed__84>(ref awaiter3, ref _003CStartBattleLoop_003Ed__);
							return;
						}
						goto IL_01b4;
						IL_021b:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						goto IL_0224;
						IL_01b4:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						awaiter2 = global::System.Threading.Tasks.Task.Delay(500).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__1 = awaiter2;
							_003CStartBattleLoop_003Ed__84 _003CStartBattleLoop_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CStartBattleLoop_003Ed__84>(ref awaiter2, ref _003CStartBattleLoop_003Ed__);
							return;
						}
						goto IL_021b;
					}
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_0335;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				Console.WriteLine($"StartBattleLoop error: {_003Cex_003E5__3}");
				awaiter = _003C_003E4__this.EndBattle(playerWon: false).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 4);
					_003C_003Eu__1 = awaiter;
					_003CStartBattleLoop_003Ed__84 _003CStartBattleLoop_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CStartBattleLoop_003Ed__84>(ref awaiter, ref _003CStartBattleLoop_003Ed__);
					return;
				}
				goto IL_0323;
				IL_0323:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__3 = null;
				goto IL_0335;
				IL_0335:
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
	private sealed class _003CSwitchEnemySpirit_003Ed__94 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleViewModelRefactored _003C_003E4__this;

		private SpriteModel _003CnewSprite_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_0262: Unknown result type (might be due to invalid IL or missing references)
			//IL_0267: Unknown result type (might be due to invalid IL or missing references)
			//IL_026f: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0339: Unknown result type (might be due to invalid IL or missing references)
			//IL_033e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0346: Unknown result type (might be due to invalid IL or missing references)
			//IL_039d: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_041b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0420: Unknown result type (might be due to invalid IL or missing references)
			//IL_0428: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a9: Expected O, but got Unknown
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_0229: Unknown result type (might be due to invalid IL or missing references)
			//IL_022e: Unknown result type (might be due to invalid IL or missing references)
			//IL_028d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0292: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0300: Expected O, but got Unknown
			//IL_0300: Unknown result type (might be due to invalid IL or missing references)
			//IL_0305: Unknown result type (might be due to invalid IL or missing references)
			//IL_0364: Unknown result type (might be due to invalid IL or missing references)
			//IL_0369: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_0152: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Unknown result type (might be due to invalid IL or missing references)
			//IL_0245: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_031a: Unknown result type (might be due to invalid IL or missing references)
			//IL_031c: Unknown result type (might be due to invalid IL or missing references)
			//IL_037e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0380: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0401: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter7;
				TaskAwaiter awaiter6;
				TaskAwaiter awaiter5;
				TaskAwaiter awaiter4;
				TaskAwaiter awaiter3;
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					_003CnewSprite_003E5__1 = ((Collection<SpriteModel>)(object)_003C_003E4__this.EnemySpirits)[_003C_003E4__this.ActiveEnemyIndex + 1];
					_003CnewSprite_003E5__1.Opacity = 0.0;
					_003C_003E4__this.ShowMoveIndicatorPlayer = false;
					_003C_003E4__this.ShowMoveIndicatorEnemy = false;
					_003C_003E4__this.ShowDamagePlayer = false;
					_003C_003E4__this.ShowDamageEnemy = false;
					_003C_003E4__this.CurrentMoveName = null;
					_003C_003E4__this.CurrentMoveTypeIcon = null;
					_003C_003E4__this.DamageText = null;
					_003C_003E4__this._poisonTurnsRemainingEnemy = 0;
					_003C_003E4__this.ShowPoisonBadgeEnemy = false;
					_003C_003E4__this.ShowEvasionBadgeEnemy = false;
					_003C_003E4__this.ShowHealingBadgeEnemy = false;
					_003C_003E4__this.TriggerSpiritSwitchEnemy = !_003C_003E4__this.TriggerSpiritSwitchEnemy;
					awaiter7 = global::System.Threading.Tasks.Task.Delay(600).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter7)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter7;
						_003CSwitchEnemySpirit_003Ed__94 _003CSwitchEnemySpirit_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSwitchEnemySpirit_003Ed__94>(ref awaiter7, ref _003CSwitchEnemySpirit_003Ed__);
						return;
					}
					goto IL_018b;
				case 0:
					awaiter7 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_018b;
				case 1:
					awaiter6 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01fb;
				case 2:
					awaiter5 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_027e;
				case 3:
					awaiter4 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_02e2;
				case 4:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0355;
				case 5:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_03b9;
				case 6:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_0355:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					awaiter2 = global::System.Threading.Tasks.Task.Delay(100).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 5);
						_003C_003Eu__1 = awaiter2;
						_003CSwitchEnemySpirit_003Ed__94 _003CSwitchEnemySpirit_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSwitchEnemySpirit_003Ed__94>(ref awaiter2, ref _003CSwitchEnemySpirit_003Ed__);
						return;
					}
					goto IL_03b9;
					IL_018b:
					((TaskAwaiter)(ref awaiter7)).GetResult();
					awaiter6 = MainThread.InvokeOnMainThreadAsync((Action)([CompilerGenerated] () =>
					{
						_003C_003E4__this.ActiveEnemyIndex++;
						_003C_003E4__this._battleState.ActiveOpponentSpiritIndex++;
						((ObservableObject)_003C_003E4__this).OnPropertyChanged("ActiveEnemy");
					})).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter6)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter6;
						_003CSwitchEnemySpirit_003Ed__94 _003CSwitchEnemySpirit_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSwitchEnemySpirit_003Ed__94>(ref awaiter6, ref _003CSwitchEnemySpirit_003Ed__);
						return;
					}
					goto IL_01fb;
					IL_02e2:
					((TaskAwaiter)(ref awaiter4)).GetResult();
					awaiter3 = MainThread.InvokeOnMainThreadAsync((Action)([CompilerGenerated] () =>
					{
						_003C_003E4__this.HealthDrainFrom = 1.0;
						_003C_003E4__this.HealthDrainTo = 1.0;
						_003C_003E4__this.IsHealthDrainForPlayer = false;
						_003C_003E4__this.TriggerHealthDrain = !_003C_003E4__this.TriggerHealthDrain;
					})).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__1 = awaiter3;
						_003CSwitchEnemySpirit_003Ed__94 _003CSwitchEnemySpirit_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSwitchEnemySpirit_003Ed__94>(ref awaiter3, ref _003CSwitchEnemySpirit_003Ed__);
						return;
					}
					goto IL_0355;
					IL_01fb:
					((TaskAwaiter)(ref awaiter6)).GetResult();
					awaiter5 = _003C_003E4__this._specialAbilityService.HandleSpiritEntersBattleEffects(_003C_003E4__this._battleState, _003C_003E4__this.BattleMode).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = awaiter5;
						_003CSwitchEnemySpirit_003Ed__94 _003CSwitchEnemySpirit_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSwitchEnemySpirit_003Ed__94>(ref awaiter5, ref _003CSwitchEnemySpirit_003Ed__);
						return;
					}
					goto IL_027e;
					IL_03b9:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					_003C_003E4__this.TriggerEnemyEntry = !_003C_003E4__this.TriggerEnemyEntry;
					awaiter = global::System.Threading.Tasks.Task.Delay(900).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 6);
						_003C_003Eu__1 = awaiter;
						_003CSwitchEnemySpirit_003Ed__94 _003CSwitchEnemySpirit_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSwitchEnemySpirit_003Ed__94>(ref awaiter, ref _003CSwitchEnemySpirit_003Ed__);
						return;
					}
					break;
					IL_027e:
					((TaskAwaiter)(ref awaiter5)).GetResult();
					awaiter4 = global::System.Threading.Tasks.Task.Delay(100).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = awaiter4;
						_003CSwitchEnemySpirit_003Ed__94 _003CSwitchEnemySpirit_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSwitchEnemySpirit_003Ed__94>(ref awaiter4, ref _003CSwitchEnemySpirit_003Ed__);
						return;
					}
					goto IL_02e2;
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003CnewSprite_003E5__1.Opacity = 1.0;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CnewSprite_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CnewSprite_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSwitchPlayerSpirit_003Ed__93 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleViewModelRefactored _003C_003E4__this;

		private SpriteModel _003CnewSprite_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_0262: Unknown result type (might be due to invalid IL or missing references)
			//IL_0267: Unknown result type (might be due to invalid IL or missing references)
			//IL_026f: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0339: Unknown result type (might be due to invalid IL or missing references)
			//IL_033e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0346: Unknown result type (might be due to invalid IL or missing references)
			//IL_039d: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_041b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0420: Unknown result type (might be due to invalid IL or missing references)
			//IL_0428: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a9: Expected O, but got Unknown
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_0229: Unknown result type (might be due to invalid IL or missing references)
			//IL_022e: Unknown result type (might be due to invalid IL or missing references)
			//IL_028d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0292: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0300: Expected O, but got Unknown
			//IL_0300: Unknown result type (might be due to invalid IL or missing references)
			//IL_0305: Unknown result type (might be due to invalid IL or missing references)
			//IL_0364: Unknown result type (might be due to invalid IL or missing references)
			//IL_0369: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_0152: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Unknown result type (might be due to invalid IL or missing references)
			//IL_0245: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_031a: Unknown result type (might be due to invalid IL or missing references)
			//IL_031c: Unknown result type (might be due to invalid IL or missing references)
			//IL_037e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0380: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0401: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter7;
				TaskAwaiter awaiter6;
				TaskAwaiter awaiter5;
				TaskAwaiter awaiter4;
				TaskAwaiter awaiter3;
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					_003CnewSprite_003E5__1 = ((Collection<SpriteModel>)(object)_003C_003E4__this.PlayerSpirits)[_003C_003E4__this.ActivePlayerSpiritIndex + 1];
					_003CnewSprite_003E5__1.Opacity = 0.0;
					_003C_003E4__this.ShowMoveIndicatorPlayer = false;
					_003C_003E4__this.ShowMoveIndicatorEnemy = false;
					_003C_003E4__this.ShowDamagePlayer = false;
					_003C_003E4__this.ShowDamageEnemy = false;
					_003C_003E4__this.CurrentMoveName = null;
					_003C_003E4__this.CurrentMoveTypeIcon = null;
					_003C_003E4__this.DamageText = null;
					_003C_003E4__this._poisonTurnsRemainingPlayer = 0;
					_003C_003E4__this.ShowPoisonBadgePlayer = false;
					_003C_003E4__this.ShowEvasionBadgePlayer = false;
					_003C_003E4__this.ShowHealingBadgePlayer = false;
					_003C_003E4__this.TriggerSpiritSwitchPlayer = !_003C_003E4__this.TriggerSpiritSwitchPlayer;
					awaiter7 = global::System.Threading.Tasks.Task.Delay(600).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter7)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter7;
						_003CSwitchPlayerSpirit_003Ed__93 _003CSwitchPlayerSpirit_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSwitchPlayerSpirit_003Ed__93>(ref awaiter7, ref _003CSwitchPlayerSpirit_003Ed__);
						return;
					}
					goto IL_018b;
				case 0:
					awaiter7 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_018b;
				case 1:
					awaiter6 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01fb;
				case 2:
					awaiter5 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_027e;
				case 3:
					awaiter4 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_02e2;
				case 4:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0355;
				case 5:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_03b9;
				case 6:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_0355:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					awaiter2 = global::System.Threading.Tasks.Task.Delay(100).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 5);
						_003C_003Eu__1 = awaiter2;
						_003CSwitchPlayerSpirit_003Ed__93 _003CSwitchPlayerSpirit_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSwitchPlayerSpirit_003Ed__93>(ref awaiter2, ref _003CSwitchPlayerSpirit_003Ed__);
						return;
					}
					goto IL_03b9;
					IL_018b:
					((TaskAwaiter)(ref awaiter7)).GetResult();
					awaiter6 = MainThread.InvokeOnMainThreadAsync((Action)([CompilerGenerated] () =>
					{
						_003C_003E4__this.ActivePlayerSpiritIndex++;
						_003C_003E4__this._battleState.ActivePlayerSpiritIndex++;
						((ObservableObject)_003C_003E4__this).OnPropertyChanged("ActivePlayerSpirit");
					})).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter6)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter6;
						_003CSwitchPlayerSpirit_003Ed__93 _003CSwitchPlayerSpirit_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSwitchPlayerSpirit_003Ed__93>(ref awaiter6, ref _003CSwitchPlayerSpirit_003Ed__);
						return;
					}
					goto IL_01fb;
					IL_02e2:
					((TaskAwaiter)(ref awaiter4)).GetResult();
					awaiter3 = MainThread.InvokeOnMainThreadAsync((Action)([CompilerGenerated] () =>
					{
						_003C_003E4__this.HealthDrainFrom = 1.0;
						_003C_003E4__this.HealthDrainTo = 1.0;
						_003C_003E4__this.IsHealthDrainForPlayer = true;
						_003C_003E4__this.TriggerHealthDrain = !_003C_003E4__this.TriggerHealthDrain;
					})).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__1 = awaiter3;
						_003CSwitchPlayerSpirit_003Ed__93 _003CSwitchPlayerSpirit_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSwitchPlayerSpirit_003Ed__93>(ref awaiter3, ref _003CSwitchPlayerSpirit_003Ed__);
						return;
					}
					goto IL_0355;
					IL_01fb:
					((TaskAwaiter)(ref awaiter6)).GetResult();
					awaiter5 = _003C_003E4__this._specialAbilityService.HandleSpiritEntersBattleEffects(_003C_003E4__this._battleState, _003C_003E4__this.BattleMode).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = awaiter5;
						_003CSwitchPlayerSpirit_003Ed__93 _003CSwitchPlayerSpirit_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSwitchPlayerSpirit_003Ed__93>(ref awaiter5, ref _003CSwitchPlayerSpirit_003Ed__);
						return;
					}
					goto IL_027e;
					IL_03b9:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					_003C_003E4__this.TriggerPlayerEntry = !_003C_003E4__this.TriggerPlayerEntry;
					awaiter = global::System.Threading.Tasks.Task.Delay(900).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 6);
						_003C_003Eu__1 = awaiter;
						_003CSwitchPlayerSpirit_003Ed__93 _003CSwitchPlayerSpirit_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSwitchPlayerSpirit_003Ed__93>(ref awaiter, ref _003CSwitchPlayerSpirit_003Ed__);
						return;
					}
					break;
					IL_027e:
					((TaskAwaiter)(ref awaiter5)).GetResult();
					awaiter4 = global::System.Threading.Tasks.Task.Delay(100).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = awaiter4;
						_003CSwitchPlayerSpirit_003Ed__93 _003CSwitchPlayerSpirit_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSwitchPlayerSpirit_003Ed__93>(ref awaiter4, ref _003CSwitchPlayerSpirit_003Ed__);
						return;
					}
					goto IL_02e2;
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003CnewSprite_003E5__1.Opacity = 1.0;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CnewSprite_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CnewSprite_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CTryStartBattle_003Ed__82 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleViewModelRefactored _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00b3;
				}
				if (_003C_003E4__this._viewIsReady && _003C_003E4__this._dataIsLoaded && !_003C_003E4__this._battleStarted)
				{
					_003C_003E4__this._battleStarted = true;
					Console.WriteLine("BattleViewModel: Starting battle sequence");
					awaiter = _003C_003E4__this.InitializeBattleSequence().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CTryStartBattle_003Ed__82 _003CTryStartBattle_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CTryStartBattle_003Ed__82>(ref awaiter, ref _003CTryStartBattle_003Ed__);
						return;
					}
					goto IL_00b3;
				}
				goto end_IL_0007;
				IL_00b3:
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

	private readonly INavigationService _navigationService;

	private readonly IPopupService _popupService;

	private readonly StartPVPBattleUseCase _startPVPBattleUseCase;

	private readonly StartGuildWarBattleInitUseCase _startGuildWarBattleInitUseCase;

	private readonly StartFriendBattleInitUseCase _startFriendBattleInitUseCase;

	private readonly ExecuteBattleTurnUseCase _executeBattleTurnUseCase;

	private readonly CompleteBattleUseCase _completeBattleUseCase;

	private readonly StartQuestBattleUseCase _startQuestBattleUseCase;

	private readonly ISpecialAbilityService _specialAbilityService;

	private bool _disposed;

	private bool _viewIsReady = false;

	private bool _dataIsLoaded = false;

	private bool _battleStarted = false;

	private BattleState? _battleState;

	private TaskCompletionSource<BattleResultDTO>? _completionSource;

	private Rewards? _earnedRewards;

	[ObservableProperty]
	private BattleViewState _currentState = BattleViewState.Idle;

	[ObservableProperty]
	private BattleMode _battleMode;

	[ObservableProperty]
	private bool _is3v3 = false;

	[ObservableProperty]
	private ObservableCollection<SpriteModel> _playerSpirits = new ObservableCollection<SpriteModel>();

	[ObservableProperty]
	private ObservableCollection<SpriteModel> _enemySpirits = new ObservableCollection<SpriteModel>();

	[ObservableProperty]
	private string? _playerGuildName = string.Empty;

	[ObservableProperty]
	private string? _enemyGuildName = string.Empty;

	[ObservableProperty]
	private bool _isBattleActive = false;

	[ObservableProperty]
	private bool _showVsScreen = true;

	[ObservableProperty]
	private double _vsScreenOpacity = 1.0;

	[ObservableProperty]
	private bool _showChallenge = false;

	[ObservableProperty]
	private string _challengerName = string.Empty;

	[ObservableProperty]
	private string _challengerBackgroundImage = string.Empty;

	[ObservableProperty]
	private bool _showMoveIndicatorPlayer = false;

	[ObservableProperty]
	private bool _showMoveIndicatorEnemy = false;

	[ObservableProperty]
	private bool _showDamagePlayer = false;

	[ObservableProperty]
	private bool _showDamageEnemy = false;

	[ObservableProperty]
	private bool _showHealingPlayer = false;

	[ObservableProperty]
	private bool _showHealingEnemy = false;

	[ObservableProperty]
	private bool _triggerPlayerAttack = false;

	[ObservableProperty]
	private bool _triggerEnemyAttack = false;

	[ObservableProperty]
	private bool _triggerSpiritSwitchPlayer = false;

	[ObservableProperty]
	private bool _triggerSpiritSwitchEnemy = false;

	[ObservableProperty]
	private bool _triggerVsFade = false;

	[ObservableProperty]
	private bool _triggerPlayerEntry = false;

	[ObservableProperty]
	private bool _triggerEnemyEntry = false;

	[ObservableProperty]
	private bool _triggerCriticalHit = false;

	[ObservableProperty]
	private bool _triggerRecoilShake = false;

	[ObservableProperty]
	private bool _isPlayerTurn = true;

	[ObservableProperty]
	private bool _triggerHealthDrain = false;

	[ObservableProperty]
	private double _healthDrainFrom = 1.0;

	[ObservableProperty]
	private double _healthDrainTo = 1.0;

	[ObservableProperty]
	private bool _isHealthDrainForPlayer = false;

	[ObservableProperty]
	private bool _showCriticalPlayer = false;

	[ObservableProperty]
	private bool _showCriticalEnemy = false;

	[ObservableProperty]
	private bool _showEvasionBadgePlayer = false;

	[ObservableProperty]
	private bool _showEvasionBadgeEnemy = false;

	[ObservableProperty]
	private bool _showStatusEffectPlayer = false;

	[ObservableProperty]
	private bool _showStatusEffectEnemy = false;

	[ObservableProperty]
	private string _statusEffectText = string.Empty;

	[ObservableProperty]
	private Color _statusEffectColor = Colors.Purple;

	[ObservableProperty]
	private bool _showPoisonBadgePlayer = false;

	[ObservableProperty]
	private bool _showPoisonBadgeEnemy = false;

	[ObservableProperty]
	private bool _showHealingBadgePlayer = false;

	[ObservableProperty]
	private bool _showHealingBadgeEnemy = false;

	private int _poisonTurnsRemainingPlayer = 0;

	private int _poisonTurnsRemainingEnemy = 0;

	[ObservableProperty]
	private string? _currentMoveName;

	[ObservableProperty]
	private string? _currentMoveTypeIcon;

	[ObservableProperty]
	private string? _damageText;

	[ObservableProperty]
	private Color _damageTextColor = Color.FromArgb("#EDF8EA");

	[ObservableProperty]
	private Color _damageStrokeColor = Color.FromArgb("#DE0A00");

	[ObservableProperty]
	private double _effectiveness = 1.0;

	[ObservableProperty]
	private int _activePlayerSpiritIndex = -1;

	[ObservableProperty]
	private int _activeEnemyIndex = -1;

	[ObservableProperty]
	private int _currentTurn;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goBackCommand;

	public SpriteModel? ActivePlayerSpirit => (ActivePlayerSpiritIndex >= 0 && ActivePlayerSpiritIndex < ((Collection<SpriteModel>)(object)PlayerSpirits).Count) ? ((Collection<SpriteModel>)(object)PlayerSpirits)[ActivePlayerSpiritIndex] : null;

	public SpriteModel? ActiveEnemy => (ActiveEnemyIndex >= 0 && ActiveEnemyIndex < ((Collection<SpriteModel>)(object)EnemySpirits).Count) ? ((Collection<SpriteModel>)(object)EnemySpirits)[ActiveEnemyIndex] : null;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public BattleViewState CurrentState
	{
		get
		{
			return _currentState;
		}
		set
		{
			if (!EqualityComparer<BattleViewState>.Default.Equals(_currentState, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentState);
				_currentState = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentState);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public BattleMode BattleMode
	{
		get
		{
			return _battleMode;
		}
		set
		{
			if (!EqualityComparer<BattleMode>.Default.Equals(_battleMode, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.BattleMode);
				_battleMode = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.BattleMode);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool Is3v3
	{
		get
		{
			return _is3v3;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_is3v3, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Is3v3);
				_is3v3 = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Is3v3);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<SpriteModel> PlayerSpirits
	{
		get
		{
			return _playerSpirits;
		}
		[MemberNotNull("_playerSpirits")]
		set
		{
			if (!EqualityComparer<ObservableCollection<SpriteModel>>.Default.Equals(_playerSpirits, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PlayerSpirits);
				_playerSpirits = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PlayerSpirits);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<SpriteModel> EnemySpirits
	{
		get
		{
			return _enemySpirits;
		}
		[MemberNotNull("_enemySpirits")]
		set
		{
			if (!EqualityComparer<ObservableCollection<SpriteModel>>.Default.Equals(_enemySpirits, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.EnemySpirits);
				_enemySpirits = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.EnemySpirits);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? PlayerGuildName
	{
		get
		{
			return _playerGuildName;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_playerGuildName, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PlayerGuildName);
				_playerGuildName = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PlayerGuildName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? EnemyGuildName
	{
		get
		{
			return _enemyGuildName;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_enemyGuildName, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.EnemyGuildName);
				_enemyGuildName = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.EnemyGuildName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsBattleActive
	{
		get
		{
			return _isBattleActive;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isBattleActive, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsBattleActive);
				_isBattleActive = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsBattleActive);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowVsScreen
	{
		get
		{
			return _showVsScreen;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showVsScreen, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowVsScreen);
				_showVsScreen = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowVsScreen);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public double VsScreenOpacity
	{
		get
		{
			return _vsScreenOpacity;
		}
		set
		{
			if (!EqualityComparer<double>.Default.Equals(_vsScreenOpacity, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.VsScreenOpacity);
				_vsScreenOpacity = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.VsScreenOpacity);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowChallenge
	{
		get
		{
			return _showChallenge;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showChallenge, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowChallenge);
				_showChallenge = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowChallenge);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string ChallengerName
	{
		get
		{
			return _challengerName;
		}
		[MemberNotNull("_challengerName")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_challengerName, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ChallengerName);
				_challengerName = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ChallengerName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string ChallengerBackgroundImage
	{
		get
		{
			return _challengerBackgroundImage;
		}
		[MemberNotNull("_challengerBackgroundImage")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_challengerBackgroundImage, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ChallengerBackgroundImage);
				_challengerBackgroundImage = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ChallengerBackgroundImage);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowMoveIndicatorPlayer
	{
		get
		{
			return _showMoveIndicatorPlayer;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showMoveIndicatorPlayer, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowMoveIndicatorPlayer);
				_showMoveIndicatorPlayer = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowMoveIndicatorPlayer);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowMoveIndicatorEnemy
	{
		get
		{
			return _showMoveIndicatorEnemy;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showMoveIndicatorEnemy, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowMoveIndicatorEnemy);
				_showMoveIndicatorEnemy = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowMoveIndicatorEnemy);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowDamagePlayer
	{
		get
		{
			return _showDamagePlayer;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showDamagePlayer, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowDamagePlayer);
				_showDamagePlayer = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowDamagePlayer);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowDamageEnemy
	{
		get
		{
			return _showDamageEnemy;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showDamageEnemy, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowDamageEnemy);
				_showDamageEnemy = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowDamageEnemy);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowHealingPlayer
	{
		get
		{
			return _showHealingPlayer;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showHealingPlayer, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowHealingPlayer);
				_showHealingPlayer = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowHealingPlayer);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowHealingEnemy
	{
		get
		{
			return _showHealingEnemy;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showHealingEnemy, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowHealingEnemy);
				_showHealingEnemy = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowHealingEnemy);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool TriggerPlayerAttack
	{
		get
		{
			return _triggerPlayerAttack;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_triggerPlayerAttack, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TriggerPlayerAttack);
				_triggerPlayerAttack = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TriggerPlayerAttack);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool TriggerEnemyAttack
	{
		get
		{
			return _triggerEnemyAttack;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_triggerEnemyAttack, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TriggerEnemyAttack);
				_triggerEnemyAttack = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TriggerEnemyAttack);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool TriggerSpiritSwitchPlayer
	{
		get
		{
			return _triggerSpiritSwitchPlayer;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_triggerSpiritSwitchPlayer, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TriggerSpiritSwitchPlayer);
				_triggerSpiritSwitchPlayer = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TriggerSpiritSwitchPlayer);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool TriggerSpiritSwitchEnemy
	{
		get
		{
			return _triggerSpiritSwitchEnemy;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_triggerSpiritSwitchEnemy, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TriggerSpiritSwitchEnemy);
				_triggerSpiritSwitchEnemy = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TriggerSpiritSwitchEnemy);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool TriggerVsFade
	{
		get
		{
			return _triggerVsFade;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_triggerVsFade, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TriggerVsFade);
				_triggerVsFade = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TriggerVsFade);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool TriggerPlayerEntry
	{
		get
		{
			return _triggerPlayerEntry;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_triggerPlayerEntry, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TriggerPlayerEntry);
				_triggerPlayerEntry = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TriggerPlayerEntry);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool TriggerEnemyEntry
	{
		get
		{
			return _triggerEnemyEntry;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_triggerEnemyEntry, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TriggerEnemyEntry);
				_triggerEnemyEntry = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TriggerEnemyEntry);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool TriggerCriticalHit
	{
		get
		{
			return _triggerCriticalHit;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_triggerCriticalHit, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TriggerCriticalHit);
				_triggerCriticalHit = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TriggerCriticalHit);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool TriggerRecoilShake
	{
		get
		{
			return _triggerRecoilShake;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_triggerRecoilShake, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TriggerRecoilShake);
				_triggerRecoilShake = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TriggerRecoilShake);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsPlayerTurn
	{
		get
		{
			return _isPlayerTurn;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isPlayerTurn, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsPlayerTurn);
				_isPlayerTurn = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsPlayerTurn);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool TriggerHealthDrain
	{
		get
		{
			return _triggerHealthDrain;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_triggerHealthDrain, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TriggerHealthDrain);
				_triggerHealthDrain = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TriggerHealthDrain);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public double HealthDrainFrom
	{
		get
		{
			return _healthDrainFrom;
		}
		set
		{
			if (!EqualityComparer<double>.Default.Equals(_healthDrainFrom, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HealthDrainFrom);
				_healthDrainFrom = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HealthDrainFrom);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public double HealthDrainTo
	{
		get
		{
			return _healthDrainTo;
		}
		set
		{
			if (!EqualityComparer<double>.Default.Equals(_healthDrainTo, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HealthDrainTo);
				_healthDrainTo = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HealthDrainTo);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsHealthDrainForPlayer
	{
		get
		{
			return _isHealthDrainForPlayer;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isHealthDrainForPlayer, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsHealthDrainForPlayer);
				_isHealthDrainForPlayer = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsHealthDrainForPlayer);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowCriticalPlayer
	{
		get
		{
			return _showCriticalPlayer;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showCriticalPlayer, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowCriticalPlayer);
				_showCriticalPlayer = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowCriticalPlayer);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowCriticalEnemy
	{
		get
		{
			return _showCriticalEnemy;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showCriticalEnemy, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowCriticalEnemy);
				_showCriticalEnemy = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowCriticalEnemy);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowEvasionBadgePlayer
	{
		get
		{
			return _showEvasionBadgePlayer;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showEvasionBadgePlayer, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowEvasionBadgePlayer);
				_showEvasionBadgePlayer = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowEvasionBadgePlayer);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowEvasionBadgeEnemy
	{
		get
		{
			return _showEvasionBadgeEnemy;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showEvasionBadgeEnemy, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowEvasionBadgeEnemy);
				_showEvasionBadgeEnemy = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowEvasionBadgeEnemy);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowStatusEffectPlayer
	{
		get
		{
			return _showStatusEffectPlayer;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showStatusEffectPlayer, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowStatusEffectPlayer);
				_showStatusEffectPlayer = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowStatusEffectPlayer);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowStatusEffectEnemy
	{
		get
		{
			return _showStatusEffectEnemy;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showStatusEffectEnemy, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowStatusEffectEnemy);
				_showStatusEffectEnemy = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowStatusEffectEnemy);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string StatusEffectText
	{
		get
		{
			return _statusEffectText;
		}
		[MemberNotNull("_statusEffectText")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_statusEffectText, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.StatusEffectText);
				_statusEffectText = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.StatusEffectText);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Color StatusEffectColor
	{
		get
		{
			return _statusEffectColor;
		}
		[MemberNotNull("_statusEffectColor")]
		set
		{
			if (!EqualityComparer<Color>.Default.Equals(_statusEffectColor, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.StatusEffectColor);
				_statusEffectColor = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.StatusEffectColor);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowPoisonBadgePlayer
	{
		get
		{
			return _showPoisonBadgePlayer;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showPoisonBadgePlayer, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowPoisonBadgePlayer);
				_showPoisonBadgePlayer = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowPoisonBadgePlayer);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowPoisonBadgeEnemy
	{
		get
		{
			return _showPoisonBadgeEnemy;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showPoisonBadgeEnemy, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowPoisonBadgeEnemy);
				_showPoisonBadgeEnemy = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowPoisonBadgeEnemy);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowHealingBadgePlayer
	{
		get
		{
			return _showHealingBadgePlayer;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showHealingBadgePlayer, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowHealingBadgePlayer);
				_showHealingBadgePlayer = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowHealingBadgePlayer);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowHealingBadgeEnemy
	{
		get
		{
			return _showHealingBadgeEnemy;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showHealingBadgeEnemy, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowHealingBadgeEnemy);
				_showHealingBadgeEnemy = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowHealingBadgeEnemy);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? CurrentMoveName
	{
		get
		{
			return _currentMoveName;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_currentMoveName, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentMoveName);
				_currentMoveName = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentMoveName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? CurrentMoveTypeIcon
	{
		get
		{
			return _currentMoveTypeIcon;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_currentMoveTypeIcon, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentMoveTypeIcon);
				_currentMoveTypeIcon = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentMoveTypeIcon);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? DamageText
	{
		get
		{
			return _damageText;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_damageText, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.DamageText);
				_damageText = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.DamageText);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Color DamageTextColor
	{
		get
		{
			return _damageTextColor;
		}
		[MemberNotNull("_damageTextColor")]
		set
		{
			if (!EqualityComparer<Color>.Default.Equals(_damageTextColor, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.DamageTextColor);
				_damageTextColor = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.DamageTextColor);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Color DamageStrokeColor
	{
		get
		{
			return _damageStrokeColor;
		}
		[MemberNotNull("_damageStrokeColor")]
		set
		{
			if (!EqualityComparer<Color>.Default.Equals(_damageStrokeColor, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.DamageStrokeColor);
				_damageStrokeColor = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.DamageStrokeColor);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public double Effectiveness
	{
		get
		{
			return _effectiveness;
		}
		set
		{
			if (!EqualityComparer<double>.Default.Equals(_effectiveness, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Effectiveness);
				_effectiveness = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Effectiveness);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int ActivePlayerSpiritIndex
	{
		get
		{
			return _activePlayerSpiritIndex;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_activePlayerSpiritIndex, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ActivePlayerSpiritIndex);
				_activePlayerSpiritIndex = value;
				OnActivePlayerSpiritIndexChanged(value);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ActivePlayerSpiritIndex);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int ActiveEnemyIndex
	{
		get
		{
			return _activeEnemyIndex;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_activeEnemyIndex, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ActiveEnemyIndex);
				_activeEnemyIndex = value;
				OnActiveEnemyIndexChanged(value);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ActiveEnemyIndex);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int CurrentTurn
	{
		get
		{
			return _currentTurn;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_currentTurn, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentTurn);
				_currentTurn = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentTurn);
			}
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

	public BattleViewModelRefactored(INavigationService navigationService, IPopupService popupService, StartPVPBattleUseCase startPVPBattleUseCase, StartGuildWarBattleInitUseCase startGuildWarBattleInitUseCase, StartFriendBattleInitUseCase startFriendBattleInitUseCase, ExecuteBattleTurnUseCase executeBattleTurnUseCase, CompleteBattleUseCase completeBattleUseCase, StartQuestBattleUseCase startQuestBattleUseCase, ISpecialAbilityService specialAbilityService)
	{
		_navigationService = navigationService;
		_popupService = popupService;
		_startPVPBattleUseCase = startPVPBattleUseCase;
		_startGuildWarBattleInitUseCase = startGuildWarBattleInitUseCase;
		_startFriendBattleInitUseCase = startFriendBattleInitUseCase;
		_executeBattleTurnUseCase = executeBattleTurnUseCase;
		_completeBattleUseCase = completeBattleUseCase;
		_startQuestBattleUseCase = startQuestBattleUseCase;
		_specialAbilityService = specialAbilityService;
		_earnedRewards = new Rewards();
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__78))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? parameter)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__78 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__78();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.parameter = parameter;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__78>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CInitializeBattleFromRequest_003Ed__79))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<BattleState?> InitializeBattleFromRequest(BattleLaunchRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Result<BattleState> result;
			if (!string.IsNullOrEmpty(request.QuestTaskId))
			{
				_earnedRewards = new Rewards
				{
					Experience = (request.QuestRewards?.Experience ?? 0),
					Gold = (request.QuestRewards?.Gold ?? 0)
				};
				StartQuestBattleRequest questRequest = new StartQuestBattleRequest(request.PlayerSpiritIds, request.QuestOpponents, request.Mode, request.QuestTaskId, 0, request.ChallengerGuildName, request.ChallengerName, null, request.ChallengerBackgroundImage);
				result = await _startQuestBattleUseCase.ExecuteAsync(questRequest);
			}
			else if (request.IsGuildWarBattle)
			{
				StartGuildWarBattleInitRequest guildWarRequest = new StartGuildWarBattleInitRequest(request.PlayerId, request.PlayerSpiritIds, request.OpponentPlayerId, request.OpponentSpiritIds);
				result = await _startGuildWarBattleInitUseCase.ExecuteAsync(guildWarRequest);
				EnemyGuildName = request.DefendingGuildId;
				PlayerGuildName = request.AttackingGuildId;
			}
			else if (request.Mode == BattleMode.FriendBattle)
			{
				StartFriendBattleInitRequest friendBattleRequest = new StartFriendBattleInitRequest(request.PlayerId, request.PlayerSpiritIds, request.OpponentPlayerId, request.OpponentSpiritIds);
				result = await _startFriendBattleInitUseCase.ExecuteAsync(friendBattleRequest);
			}
			else
			{
				if (!request.HasOpponentSpirits)
				{
					return null;
				}
				StartPVPBattleRequest pvpRequest = new StartPVPBattleRequest(request.PlayerId, request.PlayerSpiritIds, request.OpponentName ?? "Opponent", request.OpponentSpirits, request.Mode);
				result = await _startPVPBattleUseCase.ExecuteAsync(pvpRequest);
			}
			if (!result.Success)
			{
				Console.WriteLine("Failed to create battle state: " + result.ErrorMessage);
				return null;
			}
			return result.Data;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine($"InitializeBattleFromRequest error: {ex}");
			return null;
		}
	}

	private string? ExtractQuestIdFromRoute(string questRoute)
	{
		string[] array = questRoute.Split('=', (StringSplitOptions)0);
		return (array.Length > 1) ? array[1] : null;
	}

	public void NotifyViewReady()
	{
		Console.WriteLine("BattleViewModel: NotifyViewReady called");
		_viewIsReady = true;
		global::System.Threading.Tasks.Task.Run((Func<global::System.Threading.Tasks.Task>)TryStartBattle);
	}

	[AsyncStateMachine(typeof(_003CTryStartBattle_003Ed__82))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task TryStartBattle()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CTryStartBattle_003Ed__82 _003CTryStartBattle_003Ed__ = new _003CTryStartBattle_003Ed__82();
		_003CTryStartBattle_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CTryStartBattle_003Ed__._003C_003E4__this = this;
		_003CTryStartBattle_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CTryStartBattle_003Ed__._003C_003Et__builder)).Start<_003CTryStartBattle_003Ed__82>(ref _003CTryStartBattle_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CTryStartBattle_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CInitializeBattleSequence_003Ed__83))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task InitializeBattleSequence()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CInitializeBattleSequence_003Ed__83 _003CInitializeBattleSequence_003Ed__ = new _003CInitializeBattleSequence_003Ed__83();
		_003CInitializeBattleSequence_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CInitializeBattleSequence_003Ed__._003C_003E4__this = this;
		_003CInitializeBattleSequence_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CInitializeBattleSequence_003Ed__._003C_003Et__builder)).Start<_003CInitializeBattleSequence_003Ed__83>(ref _003CInitializeBattleSequence_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CInitializeBattleSequence_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CStartBattleLoop_003Ed__84))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task StartBattleLoop()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CStartBattleLoop_003Ed__84 _003CStartBattleLoop_003Ed__ = new _003CStartBattleLoop_003Ed__84();
		_003CStartBattleLoop_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CStartBattleLoop_003Ed__._003C_003E4__this = this;
		_003CStartBattleLoop_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CStartBattleLoop_003Ed__._003C_003Et__builder)).Start<_003CStartBattleLoop_003Ed__84>(ref _003CStartBattleLoop_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CStartBattleLoop_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CExecuteBattleRound_003Ed__85))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ExecuteBattleRound()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CExecuteBattleRound_003Ed__85 _003CExecuteBattleRound_003Ed__ = new _003CExecuteBattleRound_003Ed__85();
		_003CExecuteBattleRound_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CExecuteBattleRound_003Ed__._003C_003E4__this = this;
		_003CExecuteBattleRound_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CExecuteBattleRound_003Ed__._003C_003Et__builder)).Start<_003CExecuteBattleRound_003Ed__85>(ref _003CExecuteBattleRound_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CExecuteBattleRound_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CAnimateTurnResult_003Ed__86))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task AnimateTurnResult(BattleTurnResult turnResult)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CAnimateTurnResult_003Ed__86 _003CAnimateTurnResult_003Ed__ = new _003CAnimateTurnResult_003Ed__86();
		_003CAnimateTurnResult_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CAnimateTurnResult_003Ed__._003C_003E4__this = this;
		_003CAnimateTurnResult_003Ed__.turnResult = turnResult;
		_003CAnimateTurnResult_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CAnimateTurnResult_003Ed__._003C_003Et__builder)).Start<_003CAnimateTurnResult_003Ed__86>(ref _003CAnimateTurnResult_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CAnimateTurnResult_003Ed__._003C_003Et__builder)).Task;
	}

	private void TickPoisonBadges()
	{
		if (_poisonTurnsRemainingPlayer > 0)
		{
			_poisonTurnsRemainingPlayer--;
			if (_poisonTurnsRemainingPlayer <= 0)
			{
				ShowPoisonBadgePlayer = false;
			}
		}
		if (_poisonTurnsRemainingEnemy > 0)
		{
			_poisonTurnsRemainingEnemy--;
			if (_poisonTurnsRemainingEnemy <= 0)
			{
				ShowPoisonBadgeEnemy = false;
			}
		}
	}

	[AsyncStateMachine(typeof(_003CApplyDamageAnimation_003Ed__88))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ApplyDamageAnimation(AttackResult attack)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CApplyDamageAnimation_003Ed__88 _003CApplyDamageAnimation_003Ed__ = new _003CApplyDamageAnimation_003Ed__88();
		_003CApplyDamageAnimation_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CApplyDamageAnimation_003Ed__._003C_003E4__this = this;
		_003CApplyDamageAnimation_003Ed__.attack = attack;
		_003CApplyDamageAnimation_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CApplyDamageAnimation_003Ed__._003C_003Et__builder)).Start<_003CApplyDamageAnimation_003Ed__88>(ref _003CApplyDamageAnimation_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CApplyDamageAnimation_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CAnimateTurnEndEffects_003Ed__89))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task AnimateTurnEndEffects(TurnEndEffectResult turnEnd)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CAnimateTurnEndEffects_003Ed__89 _003CAnimateTurnEndEffects_003Ed__ = new _003CAnimateTurnEndEffects_003Ed__89();
		_003CAnimateTurnEndEffects_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CAnimateTurnEndEffects_003Ed__._003C_003E4__this = this;
		_003CAnimateTurnEndEffects_003Ed__.turnEnd = turnEnd;
		_003CAnimateTurnEndEffects_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CAnimateTurnEndEffects_003Ed__._003C_003Et__builder)).Start<_003CAnimateTurnEndEffects_003Ed__89>(ref _003CAnimateTurnEndEffects_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CAnimateTurnEndEffects_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CAnimateHPDelta_003Ed__90))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task AnimateHPDelta(SpriteModel sprite, int hpBefore, int hpAfter, int maxHP, bool isPlayer)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CAnimateHPDelta_003Ed__90 _003CAnimateHPDelta_003Ed__ = new _003CAnimateHPDelta_003Ed__90();
		_003CAnimateHPDelta_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CAnimateHPDelta_003Ed__._003C_003E4__this = this;
		_003CAnimateHPDelta_003Ed__.sprite = sprite;
		_003CAnimateHPDelta_003Ed__.hpBefore = hpBefore;
		_003CAnimateHPDelta_003Ed__.hpAfter = hpAfter;
		_003CAnimateHPDelta_003Ed__.maxHP = maxHP;
		_003CAnimateHPDelta_003Ed__.isPlayer = isPlayer;
		_003CAnimateHPDelta_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CAnimateHPDelta_003Ed__._003C_003Et__builder)).Start<_003CAnimateHPDelta_003Ed__90>(ref _003CAnimateHPDelta_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CAnimateHPDelta_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CApplyAttackerPostCombatAnimation_003Ed__91))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ApplyAttackerPostCombatAnimation(AttackResult attack)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CApplyAttackerPostCombatAnimation_003Ed__91 _003CApplyAttackerPostCombatAnimation_003Ed__ = new _003CApplyAttackerPostCombatAnimation_003Ed__91();
		_003CApplyAttackerPostCombatAnimation_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CApplyAttackerPostCombatAnimation_003Ed__._003C_003E4__this = this;
		_003CApplyAttackerPostCombatAnimation_003Ed__.attack = attack;
		_003CApplyAttackerPostCombatAnimation_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CApplyAttackerPostCombatAnimation_003Ed__._003C_003Et__builder)).Start<_003CApplyAttackerPostCombatAnimation_003Ed__91>(ref _003CApplyAttackerPostCombatAnimation_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CApplyAttackerPostCombatAnimation_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CHandleDefeatedSpirit_003Ed__92))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task HandleDefeatedSpirit(bool defeatedSpiritIsPlayer)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CHandleDefeatedSpirit_003Ed__92 _003CHandleDefeatedSpirit_003Ed__ = new _003CHandleDefeatedSpirit_003Ed__92();
		_003CHandleDefeatedSpirit_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CHandleDefeatedSpirit_003Ed__._003C_003E4__this = this;
		_003CHandleDefeatedSpirit_003Ed__.defeatedSpiritIsPlayer = defeatedSpiritIsPlayer;
		_003CHandleDefeatedSpirit_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CHandleDefeatedSpirit_003Ed__._003C_003Et__builder)).Start<_003CHandleDefeatedSpirit_003Ed__92>(ref _003CHandleDefeatedSpirit_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CHandleDefeatedSpirit_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSwitchPlayerSpirit_003Ed__93))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task SwitchPlayerSpirit()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSwitchPlayerSpirit_003Ed__93 _003CSwitchPlayerSpirit_003Ed__ = new _003CSwitchPlayerSpirit_003Ed__93();
		_003CSwitchPlayerSpirit_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSwitchPlayerSpirit_003Ed__._003C_003E4__this = this;
		_003CSwitchPlayerSpirit_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSwitchPlayerSpirit_003Ed__._003C_003Et__builder)).Start<_003CSwitchPlayerSpirit_003Ed__93>(ref _003CSwitchPlayerSpirit_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSwitchPlayerSpirit_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSwitchEnemySpirit_003Ed__94))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task SwitchEnemySpirit()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSwitchEnemySpirit_003Ed__94 _003CSwitchEnemySpirit_003Ed__ = new _003CSwitchEnemySpirit_003Ed__94();
		_003CSwitchEnemySpirit_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSwitchEnemySpirit_003Ed__._003C_003E4__this = this;
		_003CSwitchEnemySpirit_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSwitchEnemySpirit_003Ed__._003C_003Et__builder)).Start<_003CSwitchEnemySpirit_003Ed__94>(ref _003CSwitchEnemySpirit_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSwitchEnemySpirit_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CEndBattle_003Ed__95))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task EndBattle(bool playerWon)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CEndBattle_003Ed__95 _003CEndBattle_003Ed__ = new _003CEndBattle_003Ed__95();
		_003CEndBattle_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CEndBattle_003Ed__._003C_003E4__this = this;
		_003CEndBattle_003Ed__.playerWon = playerWon;
		_003CEndBattle_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CEndBattle_003Ed__._003C_003Et__builder)).Start<_003CEndBattle_003Ed__95>(ref _003CEndBattle_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CEndBattle_003Ed__._003C_003Et__builder)).Task;
	}

	private BattleResultDTO BuildBattleResult(bool playerWon)
	{
		int livingSpiritsCount = Enumerable.Count<SpriteModel>((global::System.Collections.Generic.IEnumerable<SpriteModel>)PlayerSpirits, (Func<SpriteModel, bool>)((SpriteModel s) => s.HP > 0));
		double totalHealthPercentage = Enumerable.Sum<SpriteModel>((global::System.Collections.Generic.IEnumerable<SpriteModel>)PlayerSpirits, (Func<SpriteModel, double>)((SpriteModel s) => s.HealthPercentage));
		List<SpiritBattleResult> playerSpirits = Enumerable.ToList<SpiritBattleResult>(Enumerable.Select<SpriteModel, SpiritBattleResult>(Enumerable.Take<SpriteModel>((global::System.Collections.Generic.IEnumerable<SpriteModel>)PlayerSpirits, 3), (Func<SpriteModel, SpiritBattleResult>)((SpriteModel sprite) => new SpiritBattleResult
		{
			Name = (sprite.Name ?? "Unknown"),
			Image = (sprite.Image ?? string.Empty),
			HealthPercentage = sprite.HealthPercentage,
			Fainted = (sprite.HP <= 0)
		})));
		List<SpiritBattleResult> enemySpirits = Enumerable.ToList<SpiritBattleResult>(Enumerable.Select<SpriteModel, SpiritBattleResult>(Enumerable.Take<SpriteModel>((global::System.Collections.Generic.IEnumerable<SpriteModel>)EnemySpirits, 3), (Func<SpriteModel, SpiritBattleResult>)((SpriteModel sprite) => new SpiritBattleResult
		{
			Name = (sprite.Name ?? "Unknown"),
			Image = (sprite.Image ?? string.Empty),
			HealthPercentage = sprite.HealthPercentage,
			Fainted = (sprite.HP <= 0)
		})));
		BattleResultDTO obj = new BattleResultDTO
		{
			Victory = playerWon
		};
		BattleState? battleState = _battleState;
		int? obj2;
		if (battleState == null)
		{
			obj2 = null;
		}
		else
		{
			List<BattleSprite> opponentBattleSprites = battleState.OpponentBattleSprites;
			obj2 = ((opponentBattleSprites == null) ? null : Enumerable.FirstOrDefault<BattleSprite>((global::System.Collections.Generic.IEnumerable<BattleSprite>)opponentBattleSprites)?.PlayerSpirit?.Level);
		}
		int? num = obj2;
		obj.OpponentLevel = num.GetValueOrDefault(1);
		obj.IsPvP = BattleMode == BattleMode.PVP;
		obj.LivingSpiritsCount = livingSpiritsCount;
		obj.TotalHealthPercentage = totalHealthPercentage;
		obj.QuestTaskId = _battleState?.QuestTaskId;
		obj.QuestTaskCompleted = playerWon;
		obj.QuestTaskStep = _battleState?.CurrentQuestStep ?? 0;
		obj.PlayerSpirits = playerSpirits;
		obj.EnemySpirits = enemySpirits;
		return obj;
	}

	[AsyncStateMachine(typeof(_003CShowBattleResultPopup_003Ed__97))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<bool> ShowBattleResultPopup(bool playerWon)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (BattleMode != 0)
			{
				return true;
			}
			string enemyNameText = ((((Collection<SpriteModel>)(object)EnemySpirits).Count <= 1) ? ("the wild " + (Enumerable.FirstOrDefault<SpriteModel>((global::System.Collections.Generic.IEnumerable<SpriteModel>)EnemySpirits)?.Name ?? "Unknown")) : (Enumerable.FirstOrDefault<SpriteModel>((global::System.Collections.Generic.IEnumerable<SpriteModel>)EnemySpirits)?.PlayerName ?? ""));
			await _popupService.ShowPopupAsync<QuestRewardsPopupViewModel>((Action<QuestRewardsPopupViewModel>)delegate(QuestRewardsPopupViewModel vm)
			{
				//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
				//IL_0190: Unknown result type (might be due to invalid IL or missing references)
				//IL_01b5: Expected O, but got Unknown
				vm.CompletedText = (playerWon ? "Victory!" : "Defeat");
				vm.CompletedText2 = (playerWon ? ("You defeated the wild " + enemyNameText + "!") : ("You lost to " + enemyNameText + "!"));
				long num = ((!playerWon) ? 1 : (_earnedRewards?.Gold ?? 0));
				int num2 = ((!playerWon) ? 1 : (_earnedRewards?.Experience ?? 0));
				vm.EarnedGold = num.ToString();
				vm.EarnedEXP = num2.ToString();
				vm.EarnedShards = (playerWon ? 5 : 0);
				vm.TextColor = (playerWon ? Color.FromArgb("#027242") : Color.FromArgb("#721502"));
				vm.StrokeColor = (playerWon ? Color.FromArgb("#027242") : Color.FromArgb("#721502"));
				vm.ShadowColor = (playerWon ? Color.FromArgb("#9EDA84") : Color.FromArgb("#DA848D"));
				vm.OutComeBackGround = (playerWon ? ((Brush)Application.Current.Resources["VictoryPopupGradient"]) : ((Brush)Application.Current.Resources["DefeatPopupGradient"]));
				vm.IsItem = false;
				vm.ThirdItemText = "Crystals";
				vm.ThirdItemImage = "icon_crystal.png";
				vm.IsBattleLogAvailable = true;
			}, default(CancellationToken));
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine($"ShowBattleResultPopup error: {ex}");
			return true;
		}
	}

	[AsyncStateMachine(typeof(_003CGoBack_003Ed__98))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoBack()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoBack_003Ed__98 _003CGoBack_003Ed__ = new _003CGoBack_003Ed__98();
		_003CGoBack_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoBack_003Ed__._003C_003E4__this = this;
		_003CGoBack_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Start<_003CGoBack_003Ed__98>(ref _003CGoBack_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Task;
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			IsBattleActive = false;
			_disposed = true;
			GC.SuppressFinalize((object)this);
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnActivePlayerSpiritIndexChanged(int value)
	{
		((ObservableObject)this).OnPropertyChanged("ActivePlayerSpirit");
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnActiveEnemyIndexChanged(int value)
	{
		((ObservableObject)this).OnPropertyChanged("ActiveEnemy");
	}
}
