using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Enums.Battles;
using SpiritSummoner.Domain.Interfaces.Services;
using SpiritSummoner.Domain.ValueObjects.Battle;

namespace SpiritSummoner.Application.UseCases.Battles;

public class ExecuteBattleTurnUseCase : IUseCase<ExecuteBattleTurnRequest, BattleTurnResult>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__6 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<BattleTurnResult>> _003C_003Et__builder;

		public ExecuteBattleTurnRequest request;

		public ExecuteBattleTurnUseCase _003C_003E4__this;

		private BattleState _003Cstate_003E5__1;

		private BattleSprite _003CfirstAttacker_003E5__2;

		private BattleSprite _003CsecondAttacker_003E5__3;

		private bool _003CfirstIsPlayer_003E5__4;

		private int _003CattackCount_003E5__5;

		private BattleTurnResult _003Cresult_003E5__6;

		private BattleSprite _003CplayerSprite_003E5__7;

		private BattleSprite _003CopponentSprite_003E5__8;

		private int _003CplayerHPBefore_003E5__9;

		private int _003CopponentHPBefore_003E5__10;

		private bool _003CplayerDiedTurnEnd_003E5__11;

		private bool _003CenemyDiedTurnEnd_003E5__12;

		private int _003Ci_003E5__13;

		private AttackResult _003CattackResult_003E5__14;

		private bool _003CstopMultiHit_003E5__15;

		private AttackResult _003C_003Es__16;

		private KnockoutEffectResult _003CkoResult_003E5__17;

		private KnockoutEffectResult _003C_003Es__18;

		private KnockoutEffectResult _003CkoResult_003E5__19;

		private KnockoutEffectResult _003C_003Es__20;

		private AttackResult _003CcounterAttackResult_003E5__21;

		private AttackResult _003C_003Es__22;

		private KnockoutEffectResult _003CkoResult_003E5__23;

		private KnockoutEffectResult _003C_003Es__24;

		private KnockoutEffectResult _003CkoResult_003E5__25;

		private KnockoutEffectResult _003C_003Es__26;

		private KnockoutEffectResult _003CkoResult_003E5__27;

		private KnockoutEffectResult _003C_003Es__28;

		private KnockoutEffectResult _003CkoResult_003E5__29;

		private KnockoutEffectResult _003C_003Es__30;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<AttackResult> _003C_003Eu__2;

		private TaskAwaiter<KnockoutEffectResult> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0303: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03df: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_06fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_07c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_07c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_07d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_08cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_08d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_08dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a03: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a08: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a10: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b64: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b69: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b71: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c6f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c74: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c7c: Unknown result type (might be due to invalid IL or missing references)
			//IL_019e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0398: Unknown result type (might be due to invalid IL or missing references)
			//IL_039d: Unknown result type (might be due to invalid IL or missing references)
			//IL_078a: Unknown result type (might be due to invalid IL or missing references)
			//IL_078f: Unknown result type (might be due to invalid IL or missing references)
			//IL_04af: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0895: Unknown result type (might be due to invalid IL or missing references)
			//IL_089a: Unknown result type (might be due to invalid IL or missing references)
			//IL_07a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_07a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_08af: Unknown result type (might be due to invalid IL or missing references)
			//IL_08b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_09c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_09ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_09e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_09e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c34: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c39: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b2a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b2f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c4f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c51: Unknown result type (might be due to invalid IL or missing references)
			//IL_06b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b44: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b46: Unknown result type (might be due to invalid IL or missing references)
			//IL_06cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_06d1: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<BattleTurnResult> result;
			try
			{
				TaskAwaiter awaiter10;
				TaskAwaiter<AttackResult> awaiter9;
				TaskAwaiter<KnockoutEffectResult> awaiter8;
				TaskAwaiter<KnockoutEffectResult> awaiter7;
				TaskAwaiter<AttackResult> awaiter6;
				TaskAwaiter<KnockoutEffectResult> awaiter5;
				TaskAwaiter<KnockoutEffectResult> awaiter4;
				TaskAwaiter awaiter3;
				TaskAwaiter<KnockoutEffectResult> awaiter2;
				TaskAwaiter<KnockoutEffectResult> awaiter;
				ValueTuple<BattleSprite, BattleSprite, bool> val;
				switch (num)
				{
				default:
					if (request.BattleState == null)
					{
						result = Result<BattleTurnResult>.FailureResult("Battle state is null");
					}
					else
					{
						_003Cstate_003E5__1 = request.BattleState;
						if (_003Cstate_003E5__1.ActivePlayerSprite != null && _003Cstate_003E5__1.ActiveOpponentSprite != null)
						{
							Debug.WriteLine($"[BattleStats] ------- Turn #{_003Cstate_003E5__1.CurrentTurn} -------");
							awaiter10 = _003C_003E4__this._specialAbilityService.HandleTurnStartEffects(_003Cstate_003E5__1, _003Cstate_003E5__1.BattleMode).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter10)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter10;
								_003CExecuteAsync_003Ed__6 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteAsync_003Ed__6>(ref awaiter10, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_018a;
						}
						result = Result<BattleTurnResult>.FailureResult("No active spirits in battle");
					}
					goto end_IL_0007;
				case 0:
					awaiter10 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_018a;
				case 1:
					awaiter9 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<AttackResult>);
					num = (_003C_003E1__state = -1);
					goto IL_0312;
				case 2:
					awaiter8 = _003C_003Eu__3;
					_003C_003Eu__3 = default(TaskAwaiter<KnockoutEffectResult>);
					num = (_003C_003E1__state = -1);
					goto IL_03ee;
				case 3:
					awaiter7 = _003C_003Eu__3;
					_003C_003Eu__3 = default(TaskAwaiter<KnockoutEffectResult>);
					num = (_003C_003E1__state = -1);
					goto IL_0505;
				case 4:
					awaiter6 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<AttackResult>);
					num = (_003C_003E1__state = -1);
					goto IL_070b;
				case 5:
					awaiter5 = _003C_003Eu__3;
					_003C_003Eu__3 = default(TaskAwaiter<KnockoutEffectResult>);
					num = (_003C_003E1__state = -1);
					goto IL_07e0;
				case 6:
					awaiter4 = _003C_003Eu__3;
					_003C_003Eu__3 = default(TaskAwaiter<KnockoutEffectResult>);
					num = (_003C_003E1__state = -1);
					goto IL_08eb;
				case 7:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0a1f;
				case 8:
					awaiter2 = _003C_003Eu__3;
					_003C_003Eu__3 = default(TaskAwaiter<KnockoutEffectResult>);
					num = (_003C_003E1__state = -1);
					goto IL_0b80;
				case 9:
					{
						awaiter = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter<KnockoutEffectResult>);
						num = (_003C_003E1__state = -1);
						goto IL_0c8b;
					}
					IL_0b80:
					_003C_003Es__28 = awaiter2.GetResult();
					_003CkoResult_003E5__27 = _003C_003Es__28;
					_003C_003Es__28 = null;
					if (_003CkoResult_003E5__27.SpiritRevived)
					{
						_003Cresult_003E5__6.TurnEndEffects.PlayerHPAfter = _003CplayerSprite_003E5__7.HP;
					}
					else
					{
						_003Cresult_003E5__6.PlayerSpiritDefeated = true;
					}
					_003CkoResult_003E5__27 = null;
					goto IL_0be4;
					IL_0467:
					if (_003C_003E4__this.IsSpiritDefeated(_003CfirstAttacker_003E5__2))
					{
						awaiter7 = _003C_003E4__this._specialAbilityService.HandleSpiritKnockout(_003Cstate_003E5__1, _003CfirstAttacker_003E5__2, _003CsecondAttacker_003E5__3, _003Cstate_003E5__1.BattleMode).GetAwaiter();
						if (!awaiter7.IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__3 = awaiter7;
							_003CExecuteAsync_003Ed__6 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<KnockoutEffectResult>, _003CExecuteAsync_003Ed__6>(ref awaiter7, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_0505;
					}
					goto IL_057b;
					IL_095b:
					_003CcounterAttackResult_003E5__21 = null;
					goto IL_0964;
					IL_0505:
					_003C_003Es__20 = awaiter7.GetResult();
					_003CkoResult_003E5__19 = _003C_003Es__20;
					_003C_003Es__20 = null;
					ReflectKOResult(_003CattackResult_003E5__14, _003CfirstAttacker_003E5__2, _003CsecondAttacker_003E5__3, _003CkoResult_003E5__19, defenderWasKO: false);
					if (!_003CkoResult_003E5__19.SpiritRevived)
					{
						MarkSpiritDefeated(_003Cresult_003E5__6, _003CfirstIsPlayer_003E5__4);
						_003CstopMultiHit_003E5__15 = true;
					}
					_003CkoResult_003E5__19 = null;
					goto IL_057b;
					IL_0be4:
					if (!_003CenemyDiedTurnEnd_003E5__12 || _003Cresult_003E5__6.EnemySpiritDefeated)
					{
						break;
					}
					awaiter = _003C_003E4__this._specialAbilityService.HandleSpiritKnockout(_003Cstate_003E5__1, _003CopponentSprite_003E5__8, _003CplayerSprite_003E5__7, _003Cstate_003E5__1.BattleMode).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 9);
						_003C_003Eu__3 = awaiter;
						_003CExecuteAsync_003Ed__6 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<KnockoutEffectResult>, _003CExecuteAsync_003Ed__6>(ref awaiter, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_0c8b;
					IL_018a:
					((TaskAwaiter)(ref awaiter10)).GetResult();
					val = _003C_003E4__this.DetermineTurnOrder(_003Cstate_003E5__1);
					_003CfirstAttacker_003E5__2 = val.Item1;
					_003CsecondAttacker_003E5__3 = val.Item2;
					_003CfirstIsPlayer_003E5__4 = val.Item3;
					_003CattackCount_003E5__5 = _003C_003E4__this.GetAttackCount(_003CfirstAttacker_003E5__2, _003CsecondAttacker_003E5__3);
					_003Cresult_003E5__6 = new BattleTurnResult
					{
						FirstAttackerIsPlayer = _003CfirstIsPlayer_003E5__4,
						AttackCount = _003CattackCount_003E5__5,
						Attacks = new List<AttackResult>()
					};
					_003Ci_003E5__13 = 0;
					goto IL_05a3;
					IL_05a3:
					if (_003Ci_003E5__13 < _003CattackCount_003E5__5 && !_003C_003E4__this.IsSpiritDefeated(_003CfirstAttacker_003E5__2) && !_003C_003E4__this.IsSpiritDefeated(_003CsecondAttacker_003E5__3))
					{
						if (!_003CfirstAttacker_003E5__2.IsStunned)
						{
							awaiter9 = _003C_003E4__this.ExecuteAttack(_003CfirstAttacker_003E5__2, _003CsecondAttacker_003E5__3, _003CfirstIsPlayer_003E5__4, _003Cstate_003E5__1, request.PlayerMove).GetAwaiter();
							if (!awaiter9.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter9;
								_003CExecuteAsync_003Ed__6 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<AttackResult>, _003CExecuteAsync_003Ed__6>(ref awaiter9, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_0312;
						}
						List<AttackResult> attacks = _003Cresult_003E5__6.Attacks;
						AttackResult obj = new AttackResult
						{
							AttackerIsPlayer = _003CfirstIsPlayer_003E5__4,
							MoveName = "Stunned",
							Damage = 0
						};
						List<string> obj2 = new List<string>(1);
						obj2.Add("Can't move — stunned!");
						obj.SpecialEffectDescriptions = obj2;
						attacks.Add(obj);
					}
					goto IL_05e4;
					IL_07e0:
					_003C_003Es__24 = awaiter5.GetResult();
					_003CkoResult_003E5__23 = _003C_003Es__24;
					_003C_003Es__24 = null;
					ReflectKOResult(_003CcounterAttackResult_003E5__21, _003CsecondAttacker_003E5__3, _003CfirstAttacker_003E5__2, _003CkoResult_003E5__23, defenderWasKO: true);
					if (!_003CkoResult_003E5__23.SpiritRevived)
					{
						MarkSpiritDefeated(_003Cresult_003E5__6, _003CfirstIsPlayer_003E5__4);
					}
					_003CkoResult_003E5__23 = null;
					goto IL_084d;
					IL_057b:
					if (_003CstopMultiHit_003E5__15)
					{
						goto IL_05e4;
					}
					_003CattackResult_003E5__14 = null;
					_003Ci_003E5__13++;
					goto IL_05a3;
					IL_0964:
					_003CplayerSprite_003E5__7 = _003Cstate_003E5__1.ActivePlayerSprite;
					_003CopponentSprite_003E5__8 = _003Cstate_003E5__1.ActiveOpponentSprite;
					_003CplayerHPBefore_003E5__9 = _003CplayerSprite_003E5__7.HP;
					_003CopponentHPBefore_003E5__10 = _003CopponentSprite_003E5__8.HP;
					awaiter3 = _003C_003E4__this._specialAbilityService.HandleTurnEndEffects(_003Cstate_003E5__1, _003Cstate_003E5__1.BattleMode).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
					{
						num = (_003C_003E1__state = 7);
						_003C_003Eu__1 = awaiter3;
						_003CExecuteAsync_003Ed__6 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteAsync_003Ed__6>(ref awaiter3, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_0a1f;
					IL_05e4:
					if (!_003C_003E4__this.IsSpiritDefeated(_003CsecondAttacker_003E5__3) && !_003C_003E4__this.IsSpiritDefeated(_003CfirstAttacker_003E5__2))
					{
						if (!_003CsecondAttacker_003E5__3.IsStunned)
						{
							awaiter6 = _003C_003E4__this.ExecuteAttack(_003CsecondAttacker_003E5__3, _003CfirstAttacker_003E5__2, !_003CfirstIsPlayer_003E5__4, _003Cstate_003E5__1, request.PlayerMove).GetAwaiter();
							if (!awaiter6.IsCompleted)
							{
								num = (_003C_003E1__state = 4);
								_003C_003Eu__2 = awaiter6;
								_003CExecuteAsync_003Ed__6 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<AttackResult>, _003CExecuteAsync_003Ed__6>(ref awaiter6, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_070b;
						}
						List<AttackResult> attacks2 = _003Cresult_003E5__6.Attacks;
						AttackResult obj3 = new AttackResult
						{
							AttackerIsPlayer = !_003CfirstIsPlayer_003E5__4,
							MoveName = "Stunned",
							Damage = 0
						};
						List<string> obj4 = new List<string>(1);
						obj4.Add("Can't move — stunned!");
						obj3.SpecialEffectDescriptions = obj4;
						attacks2.Add(obj3);
					}
					goto IL_0964;
					IL_084d:
					if (_003C_003E4__this.IsSpiritDefeated(_003CsecondAttacker_003E5__3))
					{
						awaiter4 = _003C_003E4__this._specialAbilityService.HandleSpiritKnockout(_003Cstate_003E5__1, _003CsecondAttacker_003E5__3, _003CfirstAttacker_003E5__2, _003Cstate_003E5__1.BattleMode).GetAwaiter();
						if (!awaiter4.IsCompleted)
						{
							num = (_003C_003E1__state = 6);
							_003C_003Eu__3 = awaiter4;
							_003CExecuteAsync_003Ed__6 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<KnockoutEffectResult>, _003CExecuteAsync_003Ed__6>(ref awaiter4, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_08eb;
					}
					goto IL_095b;
					IL_0a1f:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					_003Cresult_003E5__6.TurnEndEffects = new TurnEndEffectResult
					{
						PlayerHPBefore = _003CplayerHPBefore_003E5__9,
						PlayerHPAfter = _003CplayerSprite_003E5__7.HP,
						PlayerMaxHP = _003CplayerSprite_003E5__7.MaxHP,
						EnemyHPBefore = _003CopponentHPBefore_003E5__10,
						EnemyHPAfter = _003CopponentSprite_003E5__8.HP,
						EnemyMaxHP = _003CopponentSprite_003E5__8.MaxHP
					};
					_003CplayerDiedTurnEnd_003E5__11 = _003CplayerHPBefore_003E5__9 > 0 && _003CplayerSprite_003E5__7.HP == 0;
					_003CenemyDiedTurnEnd_003E5__12 = _003CopponentHPBefore_003E5__10 > 0 && _003CopponentSprite_003E5__8.HP == 0;
					if (_003CplayerDiedTurnEnd_003E5__11 && !_003Cresult_003E5__6.PlayerSpiritDefeated)
					{
						awaiter2 = _003C_003E4__this._specialAbilityService.HandleSpiritKnockout(_003Cstate_003E5__1, _003CplayerSprite_003E5__7, _003CopponentSprite_003E5__8, _003Cstate_003E5__1.BattleMode).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 8);
							_003C_003Eu__3 = awaiter2;
							_003CExecuteAsync_003Ed__6 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<KnockoutEffectResult>, _003CExecuteAsync_003Ed__6>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_0b80;
					}
					goto IL_0be4;
					IL_0312:
					_003C_003Es__16 = awaiter9.GetResult();
					_003CattackResult_003E5__14 = _003C_003Es__16;
					_003C_003Es__16 = null;
					_003Cresult_003E5__6.Attacks.Add(_003CattackResult_003E5__14);
					_003CstopMultiHit_003E5__15 = false;
					if (_003C_003E4__this.IsSpiritDefeated(_003CsecondAttacker_003E5__3))
					{
						awaiter8 = _003C_003E4__this._specialAbilityService.HandleSpiritKnockout(_003Cstate_003E5__1, _003CsecondAttacker_003E5__3, _003CfirstAttacker_003E5__2, _003Cstate_003E5__1.BattleMode).GetAwaiter();
						if (!awaiter8.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__3 = awaiter8;
							_003CExecuteAsync_003Ed__6 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<KnockoutEffectResult>, _003CExecuteAsync_003Ed__6>(ref awaiter8, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_03ee;
					}
					goto IL_0467;
					IL_0c8b:
					_003C_003Es__30 = awaiter.GetResult();
					_003CkoResult_003E5__29 = _003C_003Es__30;
					_003C_003Es__30 = null;
					if (_003CkoResult_003E5__29.SpiritRevived)
					{
						_003Cresult_003E5__6.TurnEndEffects.EnemyHPAfter = _003CopponentSprite_003E5__8.HP;
					}
					else
					{
						_003Cresult_003E5__6.EnemySpiritDefeated = true;
					}
					_003CkoResult_003E5__29 = null;
					break;
					IL_08eb:
					_003C_003Es__26 = awaiter4.GetResult();
					_003CkoResult_003E5__25 = _003C_003Es__26;
					_003C_003Es__26 = null;
					ReflectKOResult(_003CcounterAttackResult_003E5__21, _003CsecondAttacker_003E5__3, _003CfirstAttacker_003E5__2, _003CkoResult_003E5__25, defenderWasKO: false);
					if (!_003CkoResult_003E5__25.SpiritRevived)
					{
						MarkSpiritDefeated(_003Cresult_003E5__6, !_003CfirstIsPlayer_003E5__4);
					}
					_003CkoResult_003E5__25 = null;
					goto IL_095b;
					IL_03ee:
					_003C_003Es__18 = awaiter8.GetResult();
					_003CkoResult_003E5__17 = _003C_003Es__18;
					_003C_003Es__18 = null;
					ReflectKOResult(_003CattackResult_003E5__14, _003CfirstAttacker_003E5__2, _003CsecondAttacker_003E5__3, _003CkoResult_003E5__17, defenderWasKO: true);
					if (!_003CkoResult_003E5__17.SpiritRevived)
					{
						MarkSpiritDefeated(_003Cresult_003E5__6, !_003CfirstIsPlayer_003E5__4);
						_003CstopMultiHit_003E5__15 = true;
					}
					_003CkoResult_003E5__17 = null;
					goto IL_0467;
					IL_070b:
					_003C_003Es__22 = awaiter6.GetResult();
					_003CcounterAttackResult_003E5__21 = _003C_003Es__22;
					_003C_003Es__22 = null;
					_003Cresult_003E5__6.Attacks.Add(_003CcounterAttackResult_003E5__21);
					if (_003C_003E4__this.IsSpiritDefeated(_003CfirstAttacker_003E5__2))
					{
						awaiter5 = _003C_003E4__this._specialAbilityService.HandleSpiritKnockout(_003Cstate_003E5__1, _003CfirstAttacker_003E5__2, _003CsecondAttacker_003E5__3, _003Cstate_003E5__1.BattleMode).GetAwaiter();
						if (!awaiter5.IsCompleted)
						{
							num = (_003C_003E1__state = 5);
							_003C_003Eu__3 = awaiter5;
							_003CExecuteAsync_003Ed__6 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<KnockoutEffectResult>, _003CExecuteAsync_003Ed__6>(ref awaiter5, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_07e0;
					}
					goto IL_084d;
				}
				_003Cresult_003E5__6.BattleEnded = _003C_003E4__this.CheckBattleEnded(_003Cstate_003E5__1);
				if (_003Cresult_003E5__6.BattleEnded)
				{
					_003Cresult_003E5__6.PlayerVictory = _003Cstate_003E5__1.ActivePlayerSprite.HP > 0;
				}
				_003Cresult_003E5__6.TurnEnded = true;
				_003Cstate_003E5__1.CurrentTurn++;
				result = Result<BattleTurnResult>.SuccessResult(_003Cresult_003E5__6);
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cstate_003E5__1 = null;
				_003CfirstAttacker_003E5__2 = null;
				_003CsecondAttacker_003E5__3 = null;
				_003Cresult_003E5__6 = null;
				_003CplayerSprite_003E5__7 = null;
				_003CopponentSprite_003E5__8 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cstate_003E5__1 = null;
			_003CfirstAttacker_003E5__2 = null;
			_003CsecondAttacker_003E5__3 = null;
			_003Cresult_003E5__6 = null;
			_003CplayerSprite_003E5__7 = null;
			_003CopponentSprite_003E5__8 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAttack_003Ed__10 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<AttackResult> _003C_003Et__builder;

		public BattleSprite attacker;

		public BattleSprite defender;

		public bool attackerIsPlayer;

		public BattleState state;

		public Move playerSelectedMove;

		public ExecuteBattleTurnUseCase _003C_003E4__this;

		private BattleMode _003CbattleMode_003E5__1;

		private Move _003Cmove_003E5__2;

		private int? _003CforcedSlot_003E5__3;

		private bool _003CdidHit_003E5__4;

		private double _003Ceffectiveness_003E5__5;

		private bool _003CisCritical_003E5__6;

		private float _003CbaseDamage_003E5__7;

		private int _003Cdamage_003E5__8;

		private int _003ColdHP_003E5__9;

		private int _003CactualDamage_003E5__10;

		private PostCombatEffectResult _003CpostCombatResult_003E5__11;

		private float _003CrecoilDamage_003E5__12;

		private PostCombatEffectResult _003C_003Es__13;

		private int _003CfatigueScaledHeal_003E5__14;

		private int _003CrecoilInt_003E5__15;

		private TaskAwaiter<PostCombatEffectResult> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_03de: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_03be: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			AttackResult result;
			try
			{
				TaskAwaiter<PostCombatEffectResult> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<PostCombatEffectResult>);
					num = (_003C_003E1__state = -1);
					goto IL_03fa;
				}
				_003CbattleMode_003E5__1 = state.BattleMode;
				_003CforcedSlot_003E5__3 = _003C_003E4__this._specialAbilityService.GetForcedMoveSlotIndex(attacker, _003CbattleMode_003E5__1);
				if (_003CforcedSlot_003E5__3.HasValue)
				{
					_003Cmove_003E5__2 = _003C_003E4__this.GetMoveAtSlot(attacker, _003CforcedSlot_003E5__3.Value) ?? _003C_003E4__this._battleAIService.GetRandomMove(attacker.PlayerSpirit, attacker.BaseSpirit, attacker, defender);
				}
				else if (attackerIsPlayer && playerSelectedMove != null)
				{
					_003Cmove_003E5__2 = playerSelectedMove;
				}
				else
				{
					_003Cmove_003E5__2 = _003C_003E4__this._battleAIService.GetRandomMove(attacker.PlayerSpirit, attacker.BaseSpirit, attacker, defender);
				}
				_003CdidHit_003E5__4 = _003C_003E4__this._battleCalcService.RollHit(attacker, defender, _003CbattleMode_003E5__1, state.FatigueEvasionMultiplier);
				if (_003CdidHit_003E5__4)
				{
					_003Ceffectiveness_003E5__5 = _003C_003E4__this._typeEffectivenessService.GetTotalEffectiveness(_003Cmove_003E5__2.Type, defender.BaseSpirit.Type1, defender.BaseSpirit.Type2);
					_003CisCritical_003E5__6 = _003C_003E4__this._battleCalcService.RollCriticalHit(attacker, _003CbattleMode_003E5__1);
					_003CbaseDamage_003E5__7 = _003C_003E4__this._battleCalcService.CalculateDamage(attacker, defender, _003Cmove_003E5__2, _003CbattleMode_003E5__1, _003CisCritical_003E5__6);
					_003CbaseDamage_003E5__7 = _003C_003E4__this._specialAbilityService.ApplyDamageModifiers(attacker, defender, _003CbaseDamage_003E5__7, _003Cmove_003E5__2, _003CbattleMode_003E5__1);
					_003CbaseDamage_003E5__7 = _003C_003E4__this._specialAbilityService.ApplyDamageReduction(defender, _003CbaseDamage_003E5__7, _003Cmove_003E5__2.Type, _003Cmove_003E5__2, _003CbattleMode_003E5__1);
					_003CbaseDamage_003E5__7 *= state.FatigueDamageMultiplier;
					_003Cdamage_003E5__8 = (int)Math.Max(1f, _003CbaseDamage_003E5__7);
					_003ColdHP_003E5__9 = defender.HP;
					defender.HP = Math.Max(0, defender.HP - _003Cdamage_003E5__8);
					_003CactualDamage_003E5__10 = _003ColdHP_003E5__9 - defender.HP;
					awaiter = _003C_003E4__this._specialAbilityService.HandlePostCombatEffects(attacker, defender, _003CactualDamage_003E5__10, _003Cmove_003E5__2, _003CbattleMode_003E5__1).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CExecuteAttack_003Ed__10 _003CExecuteAttack_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<PostCombatEffectResult>, _003CExecuteAttack_003Ed__10>(ref awaiter, ref _003CExecuteAttack_003Ed__);
						return;
					}
					goto IL_03fa;
				}
				AttackResult obj = new AttackResult
				{
					AttackerIsPlayer = attackerIsPlayer,
					MoveName = _003Cmove_003E5__2.Name,
					MoveType = _003Cmove_003E5__2.Type,
					Damage = 0,
					Missed = true,
					AttackerHPAfter = attacker.HP,
					AttackerMaxHP = attacker.MaxHP
				};
				List<string> obj2 = new List<string>(1);
				obj2.Add(defender.BaseSpirit.Name + " evaded the attack!");
				obj.SpecialEffectDescriptions = obj2;
				result = obj;
				goto end_IL_0007;
				IL_03fa:
				_003C_003Es__13 = awaiter.GetResult();
				_003CpostCombatResult_003E5__11 = _003C_003Es__13;
				_003C_003Es__13 = null;
				if (_003CpostCombatResult_003E5__11.AttackerHealAmount > 0)
				{
					_003CfatigueScaledHeal_003E5__14 = (int)((float)_003CpostCombatResult_003E5__11.AttackerHealAmount * state.FatigueHealMultiplier);
					attacker.HP = Math.Min(attacker.MaxHP, attacker.HP + _003CfatigueScaledHeal_003E5__14);
				}
				if (_003CpostCombatResult_003E5__11.DefenderReflectDamage > 0)
				{
					attacker.HP = Math.Max(0, attacker.HP - _003CpostCombatResult_003E5__11.DefenderReflectDamage);
				}
				_003CrecoilDamage_003E5__12 = _003C_003E4__this._battleCalcService.CalculateRecoilDamage(attacker, _003Cdamage_003E5__8, _003CbattleMode_003E5__1);
				if (_003CrecoilDamage_003E5__12 > 0f)
				{
					_003CrecoilInt_003E5__15 = (int)_003CrecoilDamage_003E5__12;
					attacker.HP = ((attacker.HP != 1) ? Math.Max(1, attacker.HP - _003CrecoilInt_003E5__15) : 0);
				}
				result = new AttackResult
				{
					AttackerIsPlayer = attackerIsPlayer,
					MoveName = (_003Cmove_003E5__2.Name ?? "Unknown Move"),
					MoveType = _003Cmove_003E5__2.Type,
					Damage = (int)_003CbaseDamage_003E5__7,
					IsCritical = _003CisCritical_003E5__6,
					Effectiveness = (float)_003Ceffectiveness_003E5__5,
					RecoilDamage = (int)_003CrecoilDamage_003E5__12,
					DefenderHPBefore = _003ColdHP_003E5__9,
					DefenderHPAfter = defender.HP,
					DefenderMaxHP = defender.MaxHP,
					AttackerHPAfter = attacker.HP,
					AttackerMaxHP = attacker.MaxHP,
					SpecialEffectDescriptions = _003CpostCombatResult_003E5__11.EffectDescriptions,
					StatusEffectsApplied = ((_003CpostCombatResult_003E5__11.StatusEffectsApplied.Count > 0) ? _003CpostCombatResult_003E5__11.StatusEffectsApplied : null)
				};
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cmove_003E5__2 = null;
				_003CpostCombatResult_003E5__11 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cmove_003E5__2 = null;
			_003CpostCombatResult_003E5__11 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IBattleCalculationService _battleCalcService;

	private readonly IBattleAIService _battleAIService;

	private readonly ITypeEffectivenessService _typeEffectivenessService;

	private readonly ISpecialAbilityService _specialAbilityService;

	private readonly ISpiritMoveResolver _moveResolver;

	public ExecuteBattleTurnUseCase(IBattleCalculationService battleCalcService, IBattleAIService battleAIService, ITypeEffectivenessService typeEffectivenessService, ISpecialAbilityService specialAbilityService, ISpiritMoveResolver moveResolver)
	{
		_battleCalcService = battleCalcService;
		_battleAIService = battleAIService;
		_typeEffectivenessService = typeEffectivenessService;
		_specialAbilityService = specialAbilityService;
		_moveResolver = moveResolver;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__6))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<BattleTurnResult>> ExecuteAsync(ExecuteBattleTurnRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (request.BattleState == null)
		{
			return Result<BattleTurnResult>.FailureResult("Battle state is null");
		}
		BattleState state = request.BattleState;
		if (state.ActivePlayerSprite == null || state.ActiveOpponentSprite == null)
		{
			return Result<BattleTurnResult>.FailureResult("No active spirits in battle");
		}
		Debug.WriteLine($"[BattleStats] ------- Turn #{state.CurrentTurn} -------");
		await _specialAbilityService.HandleTurnStartEffects(state, state.BattleMode);
		ValueTuple<BattleSprite, BattleSprite, bool> val = DetermineTurnOrder(state);
		BattleSprite firstAttacker = val.Item1;
		BattleSprite secondAttacker = val.Item2;
		bool firstIsPlayer = val.Item3;
		int attackCount = GetAttackCount(firstAttacker, secondAttacker);
		BattleTurnResult result = new BattleTurnResult
		{
			FirstAttackerIsPlayer = firstIsPlayer,
			AttackCount = attackCount,
			Attacks = new List<AttackResult>()
		};
		for (int i = 0; i < attackCount; i++)
		{
			if (IsSpiritDefeated(firstAttacker))
			{
				break;
			}
			if (IsSpiritDefeated(secondAttacker))
			{
				break;
			}
			if (firstAttacker.IsStunned)
			{
				List<AttackResult> attacks = result.Attacks;
				AttackResult obj = new AttackResult
				{
					AttackerIsPlayer = firstIsPlayer,
					MoveName = "Stunned",
					Damage = 0
				};
				List<string> obj2 = new List<string>(1);
				obj2.Add("Can't move — stunned!");
				obj.SpecialEffectDescriptions = obj2;
				attacks.Add(obj);
				break;
			}
			AttackResult attackResult = await ExecuteAttack(firstAttacker, secondAttacker, firstIsPlayer, state, request.PlayerMove);
			result.Attacks.Add(attackResult);
			bool stopMultiHit = false;
			if (IsSpiritDefeated(secondAttacker))
			{
				KnockoutEffectResult koResult4 = await _specialAbilityService.HandleSpiritKnockout(state, secondAttacker, firstAttacker, state.BattleMode);
				ReflectKOResult(attackResult, firstAttacker, secondAttacker, koResult4, defenderWasKO: true);
				if (!koResult4.SpiritRevived)
				{
					MarkSpiritDefeated(result, !firstIsPlayer);
					stopMultiHit = true;
				}
			}
			if (IsSpiritDefeated(firstAttacker))
			{
				KnockoutEffectResult koResult3 = await _specialAbilityService.HandleSpiritKnockout(state, firstAttacker, secondAttacker, state.BattleMode);
				ReflectKOResult(attackResult, firstAttacker, secondAttacker, koResult3, defenderWasKO: false);
				if (!koResult3.SpiritRevived)
				{
					MarkSpiritDefeated(result, firstIsPlayer);
					stopMultiHit = true;
				}
			}
			if (stopMultiHit)
			{
				break;
			}
		}
		if (!IsSpiritDefeated(secondAttacker) && !IsSpiritDefeated(firstAttacker))
		{
			if (secondAttacker.IsStunned)
			{
				List<AttackResult> attacks2 = result.Attacks;
				AttackResult obj3 = new AttackResult
				{
					AttackerIsPlayer = !firstIsPlayer,
					MoveName = "Stunned",
					Damage = 0
				};
				List<string> obj4 = new List<string>(1);
				obj4.Add("Can't move — stunned!");
				obj3.SpecialEffectDescriptions = obj4;
				attacks2.Add(obj3);
			}
			else
			{
				AttackResult counterAttackResult = await ExecuteAttack(secondAttacker, firstAttacker, !firstIsPlayer, state, request.PlayerMove);
				result.Attacks.Add(counterAttackResult);
				if (IsSpiritDefeated(firstAttacker))
				{
					KnockoutEffectResult koResult2 = await _specialAbilityService.HandleSpiritKnockout(state, firstAttacker, secondAttacker, state.BattleMode);
					ReflectKOResult(counterAttackResult, secondAttacker, firstAttacker, koResult2, defenderWasKO: true);
					if (!koResult2.SpiritRevived)
					{
						MarkSpiritDefeated(result, firstIsPlayer);
					}
				}
				if (IsSpiritDefeated(secondAttacker))
				{
					KnockoutEffectResult koResult = await _specialAbilityService.HandleSpiritKnockout(state, secondAttacker, firstAttacker, state.BattleMode);
					ReflectKOResult(counterAttackResult, secondAttacker, firstAttacker, koResult, defenderWasKO: false);
					if (!koResult.SpiritRevived)
					{
						MarkSpiritDefeated(result, !firstIsPlayer);
					}
				}
			}
		}
		BattleSprite playerSprite = state.ActivePlayerSprite;
		BattleSprite opponentSprite = state.ActiveOpponentSprite;
		int playerHPBefore = playerSprite.HP;
		int opponentHPBefore = opponentSprite.HP;
		await _specialAbilityService.HandleTurnEndEffects(state, state.BattleMode);
		result.TurnEndEffects = new TurnEndEffectResult
		{
			PlayerHPBefore = playerHPBefore,
			PlayerHPAfter = playerSprite.HP,
			PlayerMaxHP = playerSprite.MaxHP,
			EnemyHPBefore = opponentHPBefore,
			EnemyHPAfter = opponentSprite.HP,
			EnemyMaxHP = opponentSprite.MaxHP
		};
		bool playerDiedTurnEnd = playerHPBefore > 0 && playerSprite.HP == 0;
		bool enemyDiedTurnEnd = opponentHPBefore > 0 && opponentSprite.HP == 0;
		if (playerDiedTurnEnd && !result.PlayerSpiritDefeated)
		{
			if ((await _specialAbilityService.HandleSpiritKnockout(state, playerSprite, opponentSprite, state.BattleMode)).SpiritRevived)
			{
				result.TurnEndEffects.PlayerHPAfter = playerSprite.HP;
			}
			else
			{
				result.PlayerSpiritDefeated = true;
			}
		}
		if (enemyDiedTurnEnd && !result.EnemySpiritDefeated)
		{
			if ((await _specialAbilityService.HandleSpiritKnockout(state, opponentSprite, playerSprite, state.BattleMode)).SpiritRevived)
			{
				result.TurnEndEffects.EnemyHPAfter = opponentSprite.HP;
			}
			else
			{
				result.EnemySpiritDefeated = true;
			}
		}
		result.BattleEnded = CheckBattleEnded(state);
		if (result.BattleEnded)
		{
			result.PlayerVictory = state.ActivePlayerSprite.HP > 0;
		}
		result.TurnEnded = true;
		state.CurrentTurn++;
		return Result<BattleTurnResult>.SuccessResult(result);
	}

	private ValueTuple<BattleSprite, BattleSprite, bool> DetermineTurnOrder(BattleState state)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		BattleSprite activePlayerSprite = state.ActivePlayerSprite;
		BattleSprite activeOpponentSprite = state.ActiveOpponentSprite;
		int turnPriority = _specialAbilityService.GetTurnPriority(activePlayerSprite, state.BattleMode);
		int turnPriority2 = _specialAbilityService.GetTurnPriority(activeOpponentSprite, state.BattleMode);
		if (turnPriority != turnPriority2)
		{
			return (turnPriority > turnPriority2) ? new ValueTuple<BattleSprite, BattleSprite, bool>(activePlayerSprite, activeOpponentSprite, true) : new ValueTuple<BattleSprite, BattleSprite, bool>(activeOpponentSprite, activePlayerSprite, false);
		}
		if (activeOpponentSprite.SPD >= activePlayerSprite.SPD)
		{
			return new ValueTuple<BattleSprite, BattleSprite, bool>(activeOpponentSprite, activePlayerSprite, false);
		}
		return new ValueTuple<BattleSprite, BattleSprite, bool>(activePlayerSprite, activeOpponentSprite, true);
	}

	private Move? GetMoveAtSlot(BattleSprite sprite, int slotIndex)
	{
		IReadOnlyDictionary<string, MoveState>? moves = sprite.PlayerSpirit.Moves;
		List<string> val = ((moves != null) ? Enumerable.ToList<string>(Enumerable.Select<KeyValuePair<string, MoveState>, string>(Enumerable.Where<KeyValuePair<string, MoveState>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, MoveState>>)moves, (Func<KeyValuePair<string, MoveState>, bool>)((KeyValuePair<string, MoveState> m) => m.Value.IsActiveMove)), (Func<KeyValuePair<string, MoveState>, string>)((KeyValuePair<string, MoveState> m) => m.Key))) : null);
		if (val == null || slotIndex >= val.Count)
		{
			return null;
		}
		string moveName = val[slotIndex];
		return _moveResolver.FindMoveTemplate(moveName, sprite.BaseSpirit);
	}

	private int GetAttackCount(BattleSprite attacker, BattleSprite defender)
	{
		int sPD = attacker.SPD;
		int sPD2 = defender.SPD;
		int num = sPD - sPD2;
		if (num >= 90)
		{
			return 3;
		}
		if (num >= 50)
		{
			return 2;
		}
		if (num >= 20)
		{
			return 2;
		}
		return 1;
	}

	[AsyncStateMachine(typeof(_003CExecuteAttack_003Ed__10))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<AttackResult> ExecuteAttack(BattleSprite attacker, BattleSprite defender, bool attackerIsPlayer, BattleState state, Move? playerSelectedMove)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		BattleMode battleMode = state.BattleMode;
		int? forcedSlot = _specialAbilityService.GetForcedMoveSlotIndex(attacker, battleMode);
		Move move = (forcedSlot.HasValue ? (GetMoveAtSlot(attacker, forcedSlot.Value) ?? _battleAIService.GetRandomMove(attacker.PlayerSpirit, attacker.BaseSpirit, attacker, defender)) : ((!attackerIsPlayer || playerSelectedMove == null) ? _battleAIService.GetRandomMove(attacker.PlayerSpirit, attacker.BaseSpirit, attacker, defender) : playerSelectedMove));
		if (!_battleCalcService.RollHit(attacker, defender, battleMode, state.FatigueEvasionMultiplier))
		{
			AttackResult obj = new AttackResult
			{
				AttackerIsPlayer = attackerIsPlayer,
				MoveName = move.Name,
				MoveType = move.Type,
				Damage = 0,
				Missed = true,
				AttackerHPAfter = attacker.HP,
				AttackerMaxHP = attacker.MaxHP
			};
			List<string> obj2 = new List<string>(1);
			obj2.Add(defender.BaseSpirit.Name + " evaded the attack!");
			obj.SpecialEffectDescriptions = obj2;
			return obj;
		}
		double effectiveness = _typeEffectivenessService.GetTotalEffectiveness(move.Type, defender.BaseSpirit.Type1, defender.BaseSpirit.Type2);
		bool isCritical = _battleCalcService.RollCriticalHit(attacker, battleMode);
		float baseDamage = _battleCalcService.CalculateDamage(attacker, defender, move, battleMode, isCritical);
		baseDamage = _specialAbilityService.ApplyDamageModifiers(attacker, defender, baseDamage, move, battleMode);
		baseDamage = _specialAbilityService.ApplyDamageReduction(defender, baseDamage, move.Type, move, battleMode);
		baseDamage *= state.FatigueDamageMultiplier;
		int damage = (int)Math.Max(1f, baseDamage);
		int oldHP = defender.HP;
		defender.HP = Math.Max(0, defender.HP - damage);
		int actualDamage = oldHP - defender.HP;
		PostCombatEffectResult postCombatResult = await _specialAbilityService.HandlePostCombatEffects(attacker, defender, actualDamage, move, battleMode);
		if (postCombatResult.AttackerHealAmount > 0)
		{
			int fatigueScaledHeal = (int)((float)postCombatResult.AttackerHealAmount * state.FatigueHealMultiplier);
			attacker.HP = Math.Min(attacker.MaxHP, attacker.HP + fatigueScaledHeal);
		}
		if (postCombatResult.DefenderReflectDamage > 0)
		{
			attacker.HP = Math.Max(0, attacker.HP - postCombatResult.DefenderReflectDamage);
		}
		float recoilDamage = _battleCalcService.CalculateRecoilDamage(attacker, damage, battleMode);
		if (recoilDamage > 0f)
		{
			int recoilInt = (int)recoilDamage;
			attacker.HP = ((attacker.HP != 1) ? Math.Max(1, attacker.HP - recoilInt) : 0);
		}
		return new AttackResult
		{
			AttackerIsPlayer = attackerIsPlayer,
			MoveName = (move.Name ?? "Unknown Move"),
			MoveType = move.Type,
			Damage = (int)baseDamage,
			IsCritical = isCritical,
			Effectiveness = (float)effectiveness,
			RecoilDamage = (int)recoilDamage,
			DefenderHPBefore = oldHP,
			DefenderHPAfter = defender.HP,
			DefenderMaxHP = defender.MaxHP,
			AttackerHPAfter = attacker.HP,
			AttackerMaxHP = attacker.MaxHP,
			SpecialEffectDescriptions = postCombatResult.EffectDescriptions,
			StatusEffectsApplied = ((postCombatResult.StatusEffectsApplied.Count > 0) ? postCombatResult.StatusEffectsApplied : null)
		};
	}

	private static void ReflectKOResult(AttackResult attack, BattleSprite attackerSprite, BattleSprite defenderSprite, KnockoutEffectResult ko, bool defenderWasKO)
	{
		attack.AttackerHPAfter = attackerSprite.HP;
		attack.DefenderHPAfter = defenderSprite.HP;
		if (defenderWasKO)
		{
			attack.DefenderRevived = ko.SpiritRevived;
		}
		else
		{
			attack.AttackerRevived = ko.SpiritRevived;
		}
		if (ko.EffectDescriptions.Count > 0)
		{
			if (attack.SpecialEffectDescriptions == null)
			{
				List<string> val2 = (attack.SpecialEffectDescriptions = new List<string>());
			}
			attack.SpecialEffectDescriptions.AddRange((global::System.Collections.Generic.IEnumerable<string>)ko.EffectDescriptions);
		}
	}

	private bool IsSpiritDefeated(BattleSprite sprite)
	{
		return sprite.HP <= 0;
	}

	private static void MarkSpiritDefeated(BattleTurnResult result, bool isPlayer)
	{
		if (isPlayer)
		{
			result.PlayerSpiritDefeated = true;
		}
		else
		{
			result.EnemySpiritDefeated = true;
		}
	}

	private bool CheckBattleEnded(BattleState state)
	{
		if (Enumerable.All<BattleSprite>((global::System.Collections.Generic.IEnumerable<BattleSprite>)state.PlayerBattleSprites, (Func<BattleSprite, bool>)((BattleSprite s) => s.HP <= 0)))
		{
			state.BattleEnded = true;
			state.PlayerVictory = false;
			return true;
		}
		if (Enumerable.All<BattleSprite>((global::System.Collections.Generic.IEnumerable<BattleSprite>)state.OpponentBattleSprites, (Func<BattleSprite, bool>)((BattleSprite s) => s.HP <= 0)))
		{
			state.BattleEnded = true;
			state.PlayerVictory = true;
			return true;
		}
		return false;
	}
}
