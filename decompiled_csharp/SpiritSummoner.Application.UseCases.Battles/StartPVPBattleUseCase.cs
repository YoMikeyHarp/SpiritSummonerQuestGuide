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

namespace SpiritSummoner.Application.UseCases.Battles;

public class StartPVPBattleUseCase : IUseCase<StartPVPBattleRequest, BattleState>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__6 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<BattleState>> _003C_003Et__builder;

		public StartPVPBattleRequest request;

		public StartPVPBattleUseCase _003C_003E4__this;

		private List<PlayerSpirit> _003CplayerSpirits_003E5__1;

		private List<BattleSprite> _003CplayerBattleSprites_003E5__2;

		private List<BattleSprite> _003CopponentBattleSprites_003E5__3;

		private BattleState _003CbattleState_003E5__4;

		private Enumerator<string> _003C_003Es__5;

		private string _003CspiritId_003E5__6;

		private PlayerSpirit _003Cspirit_003E5__7;

		private Enumerator<PlayerSpirit> _003C_003Es__8;

		private PlayerSpirit _003CplayerSpirit_003E5__9;

		private Spirit _003CbaseSpirit_003E5__10;

		private BattleSprite _003CbattleSprite_003E5__11;

		private Spirit _003C_003Es__12;

		private global::System.Collections.Generic.IEnumerator<PlayerSpirit> _003C_003Es__13;

		private PlayerSpirit _003CopponentSpirit_003E5__14;

		private Spirit _003CbaseSpirit_003E5__15;

		private BattleSprite _003CbattleSprite_003E5__16;

		private Spirit _003C_003Es__17;

		private global::System.Exception _003Cex_003E5__18;

		private TaskAwaiter<Spirit?> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0659: Unknown result type (might be due to invalid IL or missing references)
			//IL_065e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0666: Unknown result type (might be due to invalid IL or missing references)
			//IL_06d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_06dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_06e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_069e: Unknown result type (might be due to invalid IL or missing references)
			//IL_06a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_06b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_0231: Unknown result type (might be due to invalid IL or missing references)
			//IL_0236: Unknown result type (might be due to invalid IL or missing references)
			//IL_023e: Unknown result type (might be due to invalid IL or missing references)
			//IL_041b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0420: Unknown result type (might be due to invalid IL or missing references)
			//IL_0428: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_049f: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04de: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0211: Unknown result type (might be due to invalid IL or missing references)
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_036a: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_061f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0624: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_0639: Unknown result type (might be due to invalid IL or missing references)
			//IL_063b: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<BattleState> result;
			try
			{
				if ((uint)num > 5u)
				{
				}
				try
				{
					TaskAwaiter awaiter2;
					TaskAwaiter awaiter;
					switch (num)
					{
					default:
						if (request.PlayerSpiritIds == null || request.PlayerSpiritIds.Count == 0)
						{
							result = Result<BattleState>.FailureResult("Player squad is empty");
						}
						else if (request.OpponentSpirits == null || ((global::System.Collections.Generic.IReadOnlyCollection<PlayerSpirit>)request.OpponentSpirits).Count == 0)
						{
							result = Result<BattleState>.FailureResult("Opponent squad is empty");
						}
						else
						{
							_003CplayerSpirits_003E5__1 = new List<PlayerSpirit>();
							_003C_003Es__5 = request.PlayerSpiritIds.GetEnumerator();
							try
							{
								while (_003C_003Es__5.MoveNext())
								{
									_003CspiritId_003E5__6 = _003C_003Es__5.Current;
									_003Cspirit_003E5__7 = _003C_003E4__this._playerStateService.GetPlayerSpirit(_003CspiritId_003E5__6);
									if (_003Cspirit_003E5__7 != null)
									{
										_003CplayerSpirits_003E5__1.Add(_003Cspirit_003E5__7);
									}
									_003Cspirit_003E5__7 = null;
									_003CspiritId_003E5__6 = null;
								}
							}
							finally
							{
								if (num < 0)
								{
									((global::System.IDisposable)_003C_003Es__5).Dispose();
								}
							}
							_003C_003Es__5 = default(Enumerator<string>);
							if (_003CplayerSpirits_003E5__1.Count != 0)
							{
								_003CplayerBattleSprites_003E5__2 = new List<BattleSprite>();
								_003C_003Es__8 = _003CplayerSpirits_003E5__1.GetEnumerator();
								goto case 0;
							}
							result = Result<BattleState>.FailureResult("No valid player spirits found");
						}
						goto end_IL_0011;
					case 0:
					case 1:
						try
						{
							TaskAwaiter awaiter5;
							if (num != 0)
							{
								if (num != 1)
								{
									goto IL_033b;
								}
								awaiter5 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_030b;
							}
							TaskAwaiter<Spirit> awaiter6 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<Spirit>);
							num = (_003C_003E1__state = -1);
							goto IL_024d;
							IL_030b:
							((TaskAwaiter)(ref awaiter5)).GetResult();
							_003CplayerBattleSprites_003E5__2.Add(_003CbattleSprite_003E5__11);
							_003CbaseSpirit_003E5__10 = null;
							_003CbattleSprite_003E5__11 = null;
							_003CplayerSpirit_003E5__9 = null;
							goto IL_033b;
							IL_033b:
							if (_003C_003Es__8.MoveNext())
							{
								_003CplayerSpirit_003E5__9 = _003C_003Es__8.Current;
								awaiter6 = _003C_003E4__this._spiritRepository.GetByIdAsync(_003CplayerSpirit_003E5__9.BaseSpiritID.ToString()).GetAwaiter();
								if (!awaiter6.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter6;
									_003CExecuteAsync_003Ed__6 _003CExecuteAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Spirit>, _003CExecuteAsync_003Ed__6>(ref awaiter6, ref _003CExecuteAsync_003Ed__);
									return;
								}
								goto IL_024d;
							}
							goto end_IL_01aa;
							IL_024d:
							_003C_003Es__12 = awaiter6.GetResult();
							_003CbaseSpirit_003E5__10 = _003C_003Es__12;
							_003C_003Es__12 = null;
							if (_003CbaseSpirit_003E5__10 == null)
							{
								goto IL_033b;
							}
							_003CbattleSprite_003E5__11 = new BattleSprite(_003CbaseSpirit_003E5__10, _003CplayerSpirit_003E5__9, isPlayer: true);
							awaiter5 = _003C_003E4__this.LoadEquipmentForSprite(_003CbattleSprite_003E5__11, request.BattleMode).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter5;
								_003CExecuteAsync_003Ed__6 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteAsync_003Ed__6>(ref awaiter5, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_030b;
							end_IL_01aa:;
						}
						finally
						{
							if (num < 0)
							{
								((global::System.IDisposable)_003C_003Es__8).Dispose();
							}
						}
						_003C_003Es__8 = default(Enumerator<PlayerSpirit>);
						_003CopponentBattleSprites_003E5__3 = new List<BattleSprite>();
						_003C_003Es__13 = ((global::System.Collections.Generic.IEnumerable<PlayerSpirit>)request.OpponentSpirits).GetEnumerator();
						goto case 2;
					case 2:
					case 3:
						try
						{
							TaskAwaiter awaiter3;
							if (num != 2)
							{
								if (num != 3)
								{
									goto IL_0525;
								}
								awaiter3 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_04f5;
							}
							TaskAwaiter<Spirit> awaiter4 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<Spirit>);
							num = (_003C_003E1__state = -1);
							goto IL_0437;
							IL_04f5:
							((TaskAwaiter)(ref awaiter3)).GetResult();
							_003CopponentBattleSprites_003E5__3.Add(_003CbattleSprite_003E5__16);
							_003CbaseSpirit_003E5__15 = null;
							_003CbattleSprite_003E5__16 = null;
							_003CopponentSpirit_003E5__14 = null;
							goto IL_0525;
							IL_0525:
							if (((global::System.Collections.IEnumerator)_003C_003Es__13).MoveNext())
							{
								_003CopponentSpirit_003E5__14 = _003C_003Es__13.Current;
								awaiter4 = _003C_003E4__this._spiritRepository.GetByIdAsync(_003CopponentSpirit_003E5__14.BaseSpiritID.ToString()).GetAwaiter();
								if (!awaiter4.IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__1 = awaiter4;
									_003CExecuteAsync_003Ed__6 _003CExecuteAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Spirit>, _003CExecuteAsync_003Ed__6>(ref awaiter4, ref _003CExecuteAsync_003Ed__);
									return;
								}
								goto IL_0437;
							}
							goto end_IL_0393;
							IL_0437:
							_003C_003Es__17 = awaiter4.GetResult();
							_003CbaseSpirit_003E5__15 = _003C_003Es__17;
							_003C_003Es__17 = null;
							if (_003CbaseSpirit_003E5__15 == null)
							{
								goto IL_0525;
							}
							_003CbattleSprite_003E5__16 = new BattleSprite(_003CbaseSpirit_003E5__15, _003CopponentSpirit_003E5__14);
							awaiter3 = _003C_003E4__this.LoadEquipmentForSprite(_003CbattleSprite_003E5__16, request.BattleMode).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__2 = awaiter3;
								_003CExecuteAsync_003Ed__6 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteAsync_003Ed__6>(ref awaiter3, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_04f5;
							end_IL_0393:;
						}
						finally
						{
							if (num < 0 && _003C_003Es__13 != null)
							{
								((global::System.IDisposable)_003C_003Es__13).Dispose();
							}
						}
						_003C_003Es__13 = null;
						if (_003CplayerBattleSprites_003E5__2.Count == 0)
						{
							result = Result<BattleState>.FailureResult("Failed to create player battle sprites");
						}
						else
						{
							if (_003CopponentBattleSprites_003E5__3.Count != 0)
							{
								_003CbattleState_003E5__4 = new BattleState
								{
									BattleMode = request.BattleMode,
									PlayerBattleSprites = _003CplayerBattleSprites_003E5__2,
									OpponentBattleSprites = _003CopponentBattleSprites_003E5__3,
									CurrentTurn = 1,
									ActivePlayerSpiritIndex = 0,
									ActiveOpponentSpiritIndex = 0,
									IsPlayerTurn = true,
									BattleEnded = false
								};
								awaiter2 = _003C_003E4__this._specialAbilityService.HandleBattleStartEffects(_003CbattleState_003E5__4, request.BattleMode).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 4);
									_003C_003Eu__2 = awaiter2;
									_003CExecuteAsync_003Ed__6 _003CExecuteAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteAsync_003Ed__6>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
									return;
								}
								goto IL_0675;
							}
							result = Result<BattleState>.FailureResult("Failed to create opponent battle sprites");
						}
						goto end_IL_0011;
					case 4:
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0675;
					case 5:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_0675:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						awaiter = _003C_003E4__this._specialAbilityService.HandleSpiritEntersBattleEffects(_003CbattleState_003E5__4, request.BattleMode).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 5);
							_003C_003Eu__2 = awaiter;
							_003CExecuteAsync_003Ed__6 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteAsync_003Ed__6>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
						break;
					}
					((TaskAwaiter)(ref awaiter)).GetResult();
					result = Result<BattleState>.SuccessResult(_003CbattleState_003E5__4);
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__18 = ex;
					result = Result<BattleState>.FailureResult("Failed to initialize PVP battle: " + _003Cex_003E5__18.Message);
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
	private sealed class _003CLoadEquipmentForSprite_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleSprite sprite;

		public BattleMode battleMode;

		public StartPVPBattleUseCase _003C_003E4__this;

		private Item _003Cgear_003E5__1;

		private Item _003Ctalent_003E5__2;

		private Item _003CheldItem_003E5__3;

		private Item _003C_003Es__4;

		private Item _003C_003Es__5;

		private Item _003C_003Es__6;

		private Item _003C_003Es__7;

		private Item _003C_003Es__8;

		private Item _003C_003Es__9;

		private TaskAwaiter<Item?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0236: Unknown result type (might be due to invalid IL or missing references)
			//IL_023b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_0217: Unknown result type (might be due to invalid IL or missing references)
			//IL_0219: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<Item> awaiter3;
				TaskAwaiter<Item> awaiter2;
				TaskAwaiter<Item> awaiter;
				switch (num)
				{
				default:
					if (!string.IsNullOrEmpty(sprite.PlayerSpirit.GearID))
					{
						awaiter3 = _003C_003E4__this._itemRepository.GetGearByIdAsync(sprite.PlayerSpirit.GearID).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CLoadEquipmentForSprite_003Ed__7 _003CLoadEquipmentForSprite_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Item>, _003CLoadEquipmentForSprite_003Ed__7>(ref awaiter3, ref _003CLoadEquipmentForSprite_003Ed__);
							return;
						}
						goto IL_00b4;
					}
					_003C_003Es__4 = null;
					goto IL_00dd;
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Item>);
					num = (_003C_003E1__state = -1);
					goto IL_00b4;
				case 1:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Item>);
					num = (_003C_003E1__state = -1);
					goto IL_017c;
				case 2:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Item>);
						num = (_003C_003E1__state = -1);
						goto IL_0252;
					}
					IL_01a5:
					_003Ctalent_003E5__2 = _003C_003Es__6;
					_003C_003Es__6 = null;
					if (battleMode == BattleMode.PVE && !string.IsNullOrEmpty(sprite.PlayerSpirit.HeldItemID))
					{
						awaiter = _003C_003E4__this._itemRepository.GetByIdAsync(sprite.PlayerSpirit.HeldItemID).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = awaiter;
							_003CLoadEquipmentForSprite_003Ed__7 _003CLoadEquipmentForSprite_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Item>, _003CLoadEquipmentForSprite_003Ed__7>(ref awaiter, ref _003CLoadEquipmentForSprite_003Ed__);
							return;
						}
						goto IL_0252;
					}
					_003C_003Es__8 = null;
					break;
					IL_017c:
					_003C_003Es__7 = awaiter2.GetResult();
					_003C_003Es__6 = _003C_003Es__7;
					_003C_003Es__7 = null;
					goto IL_01a5;
					IL_00b4:
					_003C_003Es__5 = awaiter3.GetResult();
					_003C_003Es__4 = _003C_003Es__5;
					_003C_003Es__5 = null;
					goto IL_00dd;
					IL_0252:
					_003C_003Es__9 = awaiter.GetResult();
					_003C_003Es__8 = _003C_003Es__9;
					_003C_003Es__9 = null;
					break;
					IL_00dd:
					_003Cgear_003E5__1 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (!string.IsNullOrEmpty(sprite.PlayerSpirit.TalentID))
					{
						awaiter2 = _003C_003E4__this._itemRepository.GetTalentByIdAsync(sprite.PlayerSpirit.TalentID).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter2;
							_003CLoadEquipmentForSprite_003Ed__7 _003CLoadEquipmentForSprite_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Item>, _003CLoadEquipmentForSprite_003Ed__7>(ref awaiter2, ref _003CLoadEquipmentForSprite_003Ed__);
							return;
						}
						goto IL_017c;
					}
					_003C_003Es__6 = null;
					goto IL_01a5;
				}
				_003CheldItem_003E5__3 = _003C_003Es__8;
				_003C_003Es__8 = null;
				sprite.SetEquipments(_003Cgear_003E5__1, _003Ctalent_003E5__2, _003CheldItem_003E5__3);
				_003C_003E4__this._specialAbilityService.InitializeTurnBasedEffects(sprite, battleMode);
				_003C_003E4__this._battleCalculationService.RecalculateAllStats(sprite, battleMode);
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cgear_003E5__1 = null;
				_003Ctalent_003E5__2 = null;
				_003CheldItem_003E5__3 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cgear_003E5__1 = null;
			_003Ctalent_003E5__2 = null;
			_003CheldItem_003E5__3 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly ISpiritRepository _spiritRepository;

	private readonly IItemRepository _itemRepository;

	private readonly IPlayerStateService _playerStateService;

	private readonly IBattleCalculationService _battleCalculationService;

	private readonly ISpecialAbilityService _specialAbilityService;

	public StartPVPBattleUseCase(ISpiritRepository spiritRepository, IItemRepository itemRepository, IPlayerStateService playerStateService, IBattleCalculationService battleCalculationService, ISpecialAbilityService specialAbilityService)
	{
		_spiritRepository = spiritRepository;
		_itemRepository = itemRepository;
		_playerStateService = playerStateService;
		_battleCalculationService = battleCalculationService;
		_specialAbilityService = specialAbilityService;
		base._002Ector();
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__6))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<BattleState>> ExecuteAsync(StartPVPBattleRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (request.PlayerSpiritIds == null || request.PlayerSpiritIds.Count == 0)
			{
				return Result<BattleState>.FailureResult("Player squad is empty");
			}
			if (request.OpponentSpirits == null || ((global::System.Collections.Generic.IReadOnlyCollection<PlayerSpirit>)request.OpponentSpirits).Count == 0)
			{
				return Result<BattleState>.FailureResult("Opponent squad is empty");
			}
			List<PlayerSpirit> playerSpirits = new List<PlayerSpirit>();
			Enumerator<string> enumerator = request.PlayerSpiritIds.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string spiritId = enumerator.Current;
					PlayerSpirit spirit = _playerStateService.GetPlayerSpirit(spiritId);
					if (spirit != null)
					{
						playerSpirits.Add(spirit);
					}
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator).Dispose();
			}
			if (playerSpirits.Count == 0)
			{
				return Result<BattleState>.FailureResult("No valid player spirits found");
			}
			List<BattleSprite> playerBattleSprites = new List<BattleSprite>();
			Enumerator<PlayerSpirit> enumerator2 = playerSpirits.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					PlayerSpirit playerSpirit = enumerator2.Current;
					Spirit baseSpirit2 = await _spiritRepository.GetByIdAsync(playerSpirit.BaseSpiritID.ToString());
					if (baseSpirit2 != null)
					{
						BattleSprite battleSprite2 = new BattleSprite(baseSpirit2, playerSpirit, isPlayer: true);
						await LoadEquipmentForSprite(battleSprite2, request.BattleMode);
						playerBattleSprites.Add(battleSprite2);
					}
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator2).Dispose();
			}
			List<BattleSprite> opponentBattleSprites = new List<BattleSprite>();
			global::System.Collections.Generic.IEnumerator<PlayerSpirit> enumerator3 = ((global::System.Collections.Generic.IEnumerable<PlayerSpirit>)request.OpponentSpirits).GetEnumerator();
			try
			{
				while (((global::System.Collections.IEnumerator)enumerator3).MoveNext())
				{
					PlayerSpirit opponentSpirit = enumerator3.Current;
					Spirit baseSpirit = await _spiritRepository.GetByIdAsync(opponentSpirit.BaseSpiritID.ToString());
					if (baseSpirit != null)
					{
						BattleSprite battleSprite = new BattleSprite(baseSpirit, opponentSpirit);
						await LoadEquipmentForSprite(battleSprite, request.BattleMode);
						opponentBattleSprites.Add(battleSprite);
					}
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator3)?.Dispose();
			}
			if (playerBattleSprites.Count == 0)
			{
				return Result<BattleState>.FailureResult("Failed to create player battle sprites");
			}
			if (opponentBattleSprites.Count == 0)
			{
				return Result<BattleState>.FailureResult("Failed to create opponent battle sprites");
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
				BattleEnded = false
			};
			await _specialAbilityService.HandleBattleStartEffects(battleState, request.BattleMode);
			await _specialAbilityService.HandleSpiritEntersBattleEffects(battleState, request.BattleMode);
			return Result<BattleState>.SuccessResult(battleState);
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			return Result<BattleState>.FailureResult("Failed to initialize PVP battle: " + ex.Message);
		}
	}

	[AsyncStateMachine(typeof(_003CLoadEquipmentForSprite_003Ed__7))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadEquipmentForSprite(BattleSprite sprite, BattleMode battleMode)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadEquipmentForSprite_003Ed__7 _003CLoadEquipmentForSprite_003Ed__ = new _003CLoadEquipmentForSprite_003Ed__7();
		_003CLoadEquipmentForSprite_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadEquipmentForSprite_003Ed__._003C_003E4__this = this;
		_003CLoadEquipmentForSprite_003Ed__.sprite = sprite;
		_003CLoadEquipmentForSprite_003Ed__.battleMode = battleMode;
		_003CLoadEquipmentForSprite_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadEquipmentForSprite_003Ed__._003C_003Et__builder)).Start<_003CLoadEquipmentForSprite_003Ed__7>(ref _003CLoadEquipmentForSprite_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadEquipmentForSprite_003Ed__._003C_003Et__builder)).Task;
	}
}
