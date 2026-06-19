using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Enums.Battles;
using SpiritSummoner.Domain.Interfaces.Services;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Domain.ValueObjects.Battle;
using SpiritSummoner.Domain.ValueObjects.Quests;

namespace SpiritSummoner.Application.UseCases.Battles;

public class StartQuestBattleUseCase : IUseCase<StartQuestBattleRequest, BattleState>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__8 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<BattleState>> _003C_003Et__builder;

		public StartQuestBattleRequest request;

		public StartQuestBattleUseCase _003C_003E4__this;

		private List<BattleSprite> _003CplayerBattleSprites_003E5__1;

		private List<BattleSprite> _003CopponentBattleSprites_003E5__2;

		private BattleState _003CbattleState_003E5__3;

		private Enumerator<string> _003C_003Es__4;

		private string _003CplayerSpiritId_003E5__5;

		private PlayerSpirit _003CplayerSpirit_003E5__6;

		private Spirit _003CbaseSpirit_003E5__7;

		private BattleSprite _003CbattleSprite_003E5__8;

		private Spirit _003C_003Es__9;

		private global::System.Collections.Generic.IEnumerator<QuestOpponent> _003C_003Es__10;

		private QuestOpponent _003Copponent_003E5__11;

		private Spirit _003CbaseSpirit_003E5__12;

		private global::System.Collections.Generic.IReadOnlyList<Move> _003CquestSpiritMoves_003E5__13;

		private PlayerSpirit _003CopponentAsPlayerSpirit_003E5__14;

		private BattleSprite _003CbattleSprite_003E5__15;

		private Spirit _003C_003Es__16;

		private global::System.Collections.Generic.IReadOnlyList<Move> _003C_003Es__17;

		private TaskAwaiter<Spirit?> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Move>> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_068d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0692: Unknown result type (might be due to invalid IL or missing references)
			//IL_069a: Unknown result type (might be due to invalid IL or missing references)
			//IL_070c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0711: Unknown result type (might be due to invalid IL or missing references)
			//IL_0719: Unknown result type (might be due to invalid IL or missing references)
			//IL_06d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_06d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0258: Unknown result type (might be due to invalid IL or missing references)
			//IL_025d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0292: Unknown result type (might be due to invalid IL or missing references)
			//IL_0297: Unknown result type (might be due to invalid IL or missing references)
			//IL_029f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0442: Unknown result type (might be due to invalid IL or missing references)
			//IL_0447: Unknown result type (might be due to invalid IL or missing references)
			//IL_047c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0481: Unknown result type (might be due to invalid IL or missing references)
			//IL_0489: Unknown result type (might be due to invalid IL or missing references)
			//IL_0272: Unknown result type (might be due to invalid IL or missing references)
			//IL_0274: Unknown result type (might be due to invalid IL or missing references)
			//IL_045c: Unknown result type (might be due to invalid IL or missing references)
			//IL_045e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0382: Unknown result type (might be due to invalid IL or missing references)
			//IL_0387: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_0314: Unknown result type (might be due to invalid IL or missing references)
			//IL_039c: Unknown result type (might be due to invalid IL or missing references)
			//IL_039e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0653: Unknown result type (might be due to invalid IL or missing references)
			//IL_0658: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_066d: Unknown result type (might be due to invalid IL or missing references)
			//IL_066f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<BattleState> result;
			try
			{
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					if (request.PlayerSquad == null || request.PlayerSquad.Count == 0)
					{
						result = Result<BattleState>.FailureResult("Player squad is empty");
					}
					else
					{
						if (request.OpponentSquad != null && ((global::System.Collections.Generic.IReadOnlyCollection<QuestOpponent>)request.OpponentSquad).Count != 0)
						{
							_003CplayerBattleSprites_003E5__1 = new List<BattleSprite>();
							_003C_003Es__4 = request.PlayerSquad.GetEnumerator();
							goto case 0;
						}
						result = Result<BattleState>.FailureResult("Opponent squad is empty");
					}
					goto end_IL_0007;
				case 0:
				case 1:
					try
					{
						TaskAwaiter awaiter3;
						if (num != 0)
						{
							if (num != 1)
							{
								goto IL_02e5;
							}
							awaiter3 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_02ae;
						}
						TaskAwaiter<Spirit> awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Spirit>);
						num = (_003C_003E1__state = -1);
						goto IL_01b9;
						IL_02ae:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						_003CplayerBattleSprites_003E5__1.Add(_003CbattleSprite_003E5__8);
						_003CplayerSpirit_003E5__6 = null;
						_003CbaseSpirit_003E5__7 = null;
						_003CbattleSprite_003E5__8 = null;
						_003CplayerSpiritId_003E5__5 = null;
						goto IL_02e5;
						IL_02e5:
						if (!_003C_003Es__4.MoveNext())
						{
							goto end_IL_00cd;
						}
						_003CplayerSpiritId_003E5__5 = _003C_003Es__4.Current;
						_003CplayerSpirit_003E5__6 = _003C_003E4__this._playerStateService.GetPlayerSpirit(_003CplayerSpiritId_003E5__5);
						if (_003CplayerSpirit_003E5__6 != null)
						{
							awaiter4 = _003C_003E4__this._spiritRepository.GetByIdAsync(_003CplayerSpirit_003E5__6.BaseSpiritID.ToString()).GetAwaiter();
							if (!awaiter4.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter4;
								_003CExecuteAsync_003Ed__8 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Spirit>, _003CExecuteAsync_003Ed__8>(ref awaiter4, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_01b9;
						}
						result = Result<BattleState>.FailureResult("Playerspirit not found: " + _003CplayerSpiritId_003E5__5);
						goto end_IL_0007;
						IL_01b9:
						_003C_003Es__9 = awaiter4.GetResult();
						_003CbaseSpirit_003E5__7 = _003C_003Es__9;
						_003C_003Es__9 = null;
						if (_003CbaseSpirit_003E5__7 != null)
						{
							_003CbattleSprite_003E5__8 = new BattleSprite(_003CbaseSpirit_003E5__7, _003CplayerSpirit_003E5__6);
							awaiter3 = _003C_003E4__this.LoadEquipmentForSprite(_003CbattleSprite_003E5__8, request.BattleMode).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter3;
								_003CExecuteAsync_003Ed__8 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteAsync_003Ed__8>(ref awaiter3, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_02ae;
						}
						result = Result<BattleState>.FailureResult($"Base spirit not found: {_003CplayerSpirit_003E5__6.BaseSpiritID}");
						goto end_IL_0007;
						end_IL_00cd:;
					}
					finally
					{
						if (num < 0)
						{
							((global::System.IDisposable)_003C_003Es__4).Dispose();
						}
					}
					_003C_003Es__4 = default(Enumerator<string>);
					_003CopponentBattleSprites_003E5__2 = new List<BattleSprite>();
					_003C_003Es__10 = ((global::System.Collections.Generic.IEnumerable<QuestOpponent>)request.OpponentSquad).GetEnumerator();
					goto case 2;
				case 2:
				case 3:
					try
					{
						TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Move>> awaiter5;
						if (num != 2)
						{
							if (num != 3)
							{
								goto IL_0547;
							}
							awaiter5 = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Move>>);
							num = (_003C_003E1__state = -1);
							goto IL_0498;
						}
						TaskAwaiter<Spirit> awaiter6 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Spirit>);
						num = (_003C_003E1__state = -1);
						goto IL_03d8;
						IL_0498:
						_003C_003Es__17 = awaiter5.GetResult();
						_003CquestSpiritMoves_003E5__13 = _003C_003Es__17;
						_003C_003Es__17 = null;
						_003CopponentAsPlayerSpirit_003E5__14 = _003C_003E4__this._playerSpiritFactory.CreateQuestSpirit(_003CbaseSpirit_003E5__12, _003Copponent_003E5__11.Level, _003CquestSpiritMoves_003E5__13, request.ChallengerName ?? "Unknown");
						_003CbattleSprite_003E5__15 = new BattleSprite(_003CbaseSpirit_003E5__12, _003CopponentAsPlayerSpirit_003E5__14);
						_003CopponentBattleSprites_003E5__2.Add(_003CbattleSprite_003E5__15);
						_003CbaseSpirit_003E5__12 = null;
						_003CquestSpiritMoves_003E5__13 = null;
						_003CopponentAsPlayerSpirit_003E5__14 = null;
						_003CbattleSprite_003E5__15 = null;
						_003Copponent_003E5__11 = null;
						goto IL_0547;
						IL_0547:
						if (((global::System.Collections.IEnumerator)_003C_003Es__10).MoveNext())
						{
							_003Copponent_003E5__11 = _003C_003Es__10.Current;
							awaiter6 = _003C_003E4__this._spiritRepository.GetByIdAsync(_003Copponent_003E5__11.BaseSpiritId).GetAwaiter();
							if (!awaiter6.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__1 = awaiter6;
								_003CExecuteAsync_003Ed__8 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Spirit>, _003CExecuteAsync_003Ed__8>(ref awaiter6, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_03d8;
						}
						goto end_IL_033d;
						IL_03d8:
						_003C_003Es__16 = awaiter6.GetResult();
						_003CbaseSpirit_003E5__12 = _003C_003Es__16;
						_003C_003Es__16 = null;
						if (_003CbaseSpirit_003E5__12 != null)
						{
							awaiter5 = _003C_003E4__this._moveRepository.GetByIdsAsync((global::System.Collections.Generic.IEnumerable<string>)_003Copponent_003E5__11.MoveIDs).GetAwaiter();
							if (!awaiter5.IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__3 = awaiter5;
								_003CExecuteAsync_003Ed__8 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Move>>, _003CExecuteAsync_003Ed__8>(ref awaiter5, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_0498;
						}
						result = Result<BattleState>.FailureResult("Base spirit not found: " + _003Copponent_003E5__11.BaseSpiritId);
						goto end_IL_0007;
						end_IL_033d:;
					}
					finally
					{
						if (num < 0 && _003C_003Es__10 != null)
						{
							((global::System.IDisposable)_003C_003Es__10).Dispose();
						}
					}
					_003C_003Es__10 = null;
					_003CbattleState_003E5__3 = new BattleState
					{
						BattleMode = request.BattleMode,
						PlayerBattleSprites = _003CplayerBattleSprites_003E5__1,
						OpponentBattleSprites = _003CopponentBattleSprites_003E5__2,
						CurrentTurn = 1,
						ActivePlayerSpiritIndex = 0,
						ActiveOpponentSpiritIndex = 0,
						IsPlayerTurn = true,
						BattleEnded = false,
						QuestTaskId = request.QuestTaskId,
						CurrentQuestStep = request.CurrentQuestStep,
						ChallengerName = request.ChallengerName,
						ChallengerBackgroundImage = request.ChallengerBackgroundImage,
						ChallengerGuildName = request.ChallengerGuildname
					};
					awaiter2 = _003C_003E4__this._specialAbilityService.HandleBattleStartEffects(_003CbattleState_003E5__3, request.BattleMode).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__2 = awaiter2;
						_003CExecuteAsync_003Ed__8 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteAsync_003Ed__8>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_06a9;
				case 4:
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_06a9;
				case 5:
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_06a9:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					awaiter = _003C_003E4__this._specialAbilityService.HandleSpiritEntersBattleEffects(_003CbattleState_003E5__3, request.BattleMode).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 5);
						_003C_003Eu__2 = awaiter;
						_003CExecuteAsync_003Ed__8 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteAsync_003Ed__8>(ref awaiter, ref _003CExecuteAsync_003Ed__);
						return;
					}
					break;
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				result = Result<BattleState>.SuccessResult(_003CbattleState_003E5__3);
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CplayerBattleSprites_003E5__1 = null;
				_003CopponentBattleSprites_003E5__2 = null;
				_003CbattleState_003E5__3 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CplayerBattleSprites_003E5__1 = null;
			_003CopponentBattleSprites_003E5__2 = null;
			_003CbattleState_003E5__3 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CLoadEquipmentForSprite_003Ed__9 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleSprite sprite;

		public BattleMode battleMode;

		public StartQuestBattleUseCase _003C_003E4__this;

		private Item _003Cgear_003E5__1;

		private Item _003CheldItem_003E5__2;

		private Item _003Ctalent_003E5__3;

		private Item _003C_003Es__4;

		private Item _003C_003Es__5;

		private Item _003C_003Es__6;

		private Item _003C_003Es__7;

		private Item _003C_003Es__8;

		private Item _003C_003Es__9;

		private TaskAwaiter<Item?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_023a: Unknown result type (might be due to invalid IL or missing references)
			//IL_023f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0247: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0201: Unknown result type (might be due to invalid IL or missing references)
			//IL_0206: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0152: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_021b: Unknown result type (might be due to invalid IL or missing references)
			//IL_021d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<Item> awaiter3;
				TaskAwaiter<Item> awaiter2;
				TaskAwaiter<Item> awaiter;
				switch (num)
				{
				default:
					if (battleMode == BattleMode.PVP && !string.IsNullOrEmpty(sprite.PlayerSpirit.GearID))
					{
						awaiter3 = _003C_003E4__this._itemRepository.GetByIdAsync(sprite.PlayerSpirit.GearID).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CLoadEquipmentForSprite_003Ed__9 _003CLoadEquipmentForSprite_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Item>, _003CLoadEquipmentForSprite_003Ed__9>(ref awaiter3, ref _003CLoadEquipmentForSprite_003Ed__);
							return;
						}
						goto IL_00c3;
					}
					_003C_003Es__4 = null;
					goto IL_00ec;
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Item>);
					num = (_003C_003E1__state = -1);
					goto IL_00c3;
				case 1:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Item>);
					num = (_003C_003E1__state = -1);
					goto IL_018b;
				case 2:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Item>);
						num = (_003C_003E1__state = -1);
						goto IL_0256;
					}
					IL_01b4:
					_003CheldItem_003E5__2 = _003C_003Es__6;
					_003C_003Es__6 = null;
					if (!string.IsNullOrEmpty(sprite.PlayerSpirit.TalentID))
					{
						awaiter = _003C_003E4__this._itemRepository.GetTalentByIdAsync(sprite.PlayerSpirit.TalentID).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = awaiter;
							_003CLoadEquipmentForSprite_003Ed__9 _003CLoadEquipmentForSprite_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Item>, _003CLoadEquipmentForSprite_003Ed__9>(ref awaiter, ref _003CLoadEquipmentForSprite_003Ed__);
							return;
						}
						goto IL_0256;
					}
					_003C_003Es__8 = null;
					break;
					IL_0256:
					_003C_003Es__9 = awaiter.GetResult();
					_003C_003Es__8 = _003C_003Es__9;
					_003C_003Es__9 = null;
					break;
					IL_018b:
					_003C_003Es__7 = awaiter2.GetResult();
					_003C_003Es__6 = _003C_003Es__7;
					_003C_003Es__7 = null;
					goto IL_01b4;
					IL_00c3:
					_003C_003Es__5 = awaiter3.GetResult();
					_003C_003Es__4 = _003C_003Es__5;
					_003C_003Es__5 = null;
					goto IL_00ec;
					IL_00ec:
					_003Cgear_003E5__1 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (!string.IsNullOrEmpty(sprite.PlayerSpirit.HeldItemID))
					{
						awaiter2 = _003C_003E4__this._itemRepository.GetByIdAsync(sprite.PlayerSpirit.HeldItemID).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter2;
							_003CLoadEquipmentForSprite_003Ed__9 _003CLoadEquipmentForSprite_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Item>, _003CLoadEquipmentForSprite_003Ed__9>(ref awaiter2, ref _003CLoadEquipmentForSprite_003Ed__);
							return;
						}
						goto IL_018b;
					}
					_003C_003Es__6 = null;
					goto IL_01b4;
				}
				_003Ctalent_003E5__3 = _003C_003Es__8;
				_003C_003Es__8 = null;
				sprite.SetEquipments(_003Cgear_003E5__1, _003Ctalent_003E5__3, _003CheldItem_003E5__2);
				_003C_003E4__this._specialAbilityService.InitializeTurnBasedEffects(sprite, battleMode);
				_003C_003E4__this._battleCalculationService.RecalculateAllStats(sprite, battleMode);
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cgear_003E5__1 = null;
				_003CheldItem_003E5__2 = null;
				_003Ctalent_003E5__3 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cgear_003E5__1 = null;
			_003CheldItem_003E5__2 = null;
			_003Ctalent_003E5__3 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly ISpiritRepository _spiritRepository;

	private readonly IItemRepository _itemRepository;

	private readonly IMoveRepository _moveRepository;

	private readonly IPlayerSpiritFactory _playerSpiritFactory;

	private readonly IPlayerStateService _playerStateService;

	private readonly IBattleCalculationService _battleCalculationService;

	private readonly ISpecialAbilityService _specialAbilityService;

	public StartQuestBattleUseCase(ISpiritRepository spiritRepository, IItemRepository itemRepository, IPlayerSpiritFactory playerSpiritFactory, IMoveRepository moveRepository, IPlayerStateService playerStateService, IBattleCalculationService battleCalculationService, ISpecialAbilityService specialAbilityService)
	{
		_spiritRepository = spiritRepository;
		_itemRepository = itemRepository;
		_playerSpiritFactory = playerSpiritFactory;
		_moveRepository = moveRepository;
		_playerStateService = playerStateService;
		_battleCalculationService = battleCalculationService;
		_specialAbilityService = specialAbilityService;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__8))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<BattleState>> ExecuteAsync(StartQuestBattleRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (request.PlayerSquad == null || request.PlayerSquad.Count == 0)
		{
			return Result<BattleState>.FailureResult("Player squad is empty");
		}
		if (request.OpponentSquad == null || ((global::System.Collections.Generic.IReadOnlyCollection<QuestOpponent>)request.OpponentSquad).Count == 0)
		{
			return Result<BattleState>.FailureResult("Opponent squad is empty");
		}
		List<BattleSprite> playerBattleSprites = new List<BattleSprite>();
		Enumerator<string> enumerator = request.PlayerSquad.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				string playerSpiritId = enumerator.Current;
				PlayerSpirit playerSpirit = _playerStateService.GetPlayerSpirit(playerSpiritId);
				if (playerSpirit == null)
				{
					return Result<BattleState>.FailureResult("Playerspirit not found: " + playerSpiritId);
				}
				Spirit baseSpirit = await _spiritRepository.GetByIdAsync(playerSpirit.BaseSpiritID.ToString());
				if (baseSpirit == null)
				{
					return Result<BattleState>.FailureResult($"Base spirit not found: {playerSpirit.BaseSpiritID}");
				}
				BattleSprite battleSprite2 = new BattleSprite(baseSpirit, playerSpirit);
				await LoadEquipmentForSprite(battleSprite2, request.BattleMode);
				playerBattleSprites.Add(battleSprite2);
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator).Dispose();
		}
		List<BattleSprite> opponentBattleSprites = new List<BattleSprite>();
		global::System.Collections.Generic.IEnumerator<QuestOpponent> enumerator2 = ((global::System.Collections.Generic.IEnumerable<QuestOpponent>)request.OpponentSquad).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator2).MoveNext())
			{
				QuestOpponent opponent = enumerator2.Current;
				Spirit baseSpirit2 = await _spiritRepository.GetByIdAsync(opponent.BaseSpiritId);
				if (baseSpirit2 == null)
				{
					return Result<BattleState>.FailureResult("Base spirit not found: " + opponent.BaseSpiritId);
				}
				global::System.Collections.Generic.IReadOnlyList<Move> questSpiritMoves = await _moveRepository.GetByIdsAsync((global::System.Collections.Generic.IEnumerable<string>)opponent.MoveIDs);
				PlayerSpirit opponentAsPlayerSpirit = _playerSpiritFactory.CreateQuestSpirit(baseSpirit2, opponent.Level, questSpiritMoves, request.ChallengerName ?? "Unknown");
				BattleSprite battleSprite = new BattleSprite(baseSpirit2, opponentAsPlayerSpirit);
				opponentBattleSprites.Add(battleSprite);
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator2)?.Dispose();
		}
		BattleState battleState = new BattleState
		{
			BattleMode = request.BattleMode,
			PlayerBattleSprites = playerBattleSprites,
			OpponentBattleSprites = opponentBattleSprites,
			CurrentTurn = 1,
			ActivePlayerSpiritIndex = 0,
			ActiveOpponentSpiritIndex = 0,
			IsPlayerTurn = true,
			BattleEnded = false,
			QuestTaskId = request.QuestTaskId,
			CurrentQuestStep = request.CurrentQuestStep,
			ChallengerName = request.ChallengerName,
			ChallengerBackgroundImage = request.ChallengerBackgroundImage,
			ChallengerGuildName = request.ChallengerGuildname
		};
		await _specialAbilityService.HandleBattleStartEffects(battleState, request.BattleMode);
		await _specialAbilityService.HandleSpiritEntersBattleEffects(battleState, request.BattleMode);
		return Result<BattleState>.SuccessResult(battleState);
	}

	[AsyncStateMachine(typeof(_003CLoadEquipmentForSprite_003Ed__9))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadEquipmentForSprite(BattleSprite sprite, BattleMode battleMode)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadEquipmentForSprite_003Ed__9 _003CLoadEquipmentForSprite_003Ed__ = new _003CLoadEquipmentForSprite_003Ed__9();
		_003CLoadEquipmentForSprite_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadEquipmentForSprite_003Ed__._003C_003E4__this = this;
		_003CLoadEquipmentForSprite_003Ed__.sprite = sprite;
		_003CLoadEquipmentForSprite_003Ed__.battleMode = battleMode;
		_003CLoadEquipmentForSprite_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadEquipmentForSprite_003Ed__._003C_003Et__builder)).Start<_003CLoadEquipmentForSprite_003Ed__9>(ref _003CLoadEquipmentForSprite_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadEquipmentForSprite_003Ed__._003C_003Et__builder)).Task;
	}
}
