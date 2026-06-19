using System;
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

public class StartGuildWarBattleInitUseCase : IUseCase<StartGuildWarBattleInitRequest, BattleState>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<BattleState>> _003C_003Et__builder;

		public StartGuildWarBattleInitRequest request;

		public StartGuildWarBattleInitUseCase _003C_003E4__this;

		private List<PlayerSpirit> _003CplayerSpirits_003E5__1;

		private List<PlayerSpirit> _003CopponentSpirits_003E5__2;

		private List<BattleSprite> _003CplayerBattleSprites_003E5__3;

		private List<BattleSprite> _003CopponentBattleSprites_003E5__4;

		private BattleState _003CbattleState_003E5__5;

		private Enumerator<string> _003C_003Es__6;

		private string _003CspiritId_003E5__7;

		private PlayerSpirit _003Cspirit_003E5__8;

		private Enumerator<string> _003C_003Es__9;

		private string _003CspiritId_003E5__10;

		private PlayerSpirit _003Cspirit_003E5__11;

		private PlayerSpirit _003C_003Es__12;

		private Enumerator<PlayerSpirit> _003C_003Es__13;

		private PlayerSpirit _003CplayerSpirit_003E5__14;

		private Spirit _003CbaseSpirit_003E5__15;

		private BattleSprite _003CbattleSprite_003E5__16;

		private Spirit _003C_003Es__17;

		private Enumerator<PlayerSpirit> _003C_003Es__18;

		private PlayerSpirit _003CopponentSpirit_003E5__19;

		private Spirit _003CbaseSpirit_003E5__20;

		private BattleSprite _003CbattleSprite_003E5__21;

		private Spirit _003C_003Es__22;

		private global::System.Exception _003Cex_003E5__23;

		private TaskAwaiter<PlayerSpirit?> _003C_003Eu__1;

		private TaskAwaiter<Spirit?> _003C_003Eu__2;

		private TaskAwaiter _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_07c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_07c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_07cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0835: Unknown result type (might be due to invalid IL or missing references)
			//IL_083a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0842: Unknown result type (might be due to invalid IL or missing references)
			//IL_07fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0800: Unknown result type (might be due to invalid IL or missing references)
			//IL_0815: Unknown result type (might be due to invalid IL or missing references)
			//IL_0817: Unknown result type (might be due to invalid IL or missing references)
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			//IL_025c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0264: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_059d: Unknown result type (might be due to invalid IL or missing references)
			//IL_05a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_05aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_021d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0222: Unknown result type (might be due to invalid IL or missing references)
			//IL_043c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0441: Unknown result type (might be due to invalid IL or missing references)
			//IL_0476: Unknown result type (might be due to invalid IL or missing references)
			//IL_047b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0483: Unknown result type (might be due to invalid IL or missing references)
			//IL_0617: Unknown result type (might be due to invalid IL or missing references)
			//IL_061c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0651: Unknown result type (might be due to invalid IL or missing references)
			//IL_0656: Unknown result type (might be due to invalid IL or missing references)
			//IL_065e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0237: Unknown result type (might be due to invalid IL or missing references)
			//IL_0239: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0456: Unknown result type (might be due to invalid IL or missing references)
			//IL_0458: Unknown result type (might be due to invalid IL or missing references)
			//IL_0631: Unknown result type (might be due to invalid IL or missing references)
			//IL_0633: Unknown result type (might be due to invalid IL or missing references)
			//IL_032f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0334: Unknown result type (might be due to invalid IL or missing references)
			//IL_0388: Unknown result type (might be due to invalid IL or missing references)
			//IL_038d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0563: Unknown result type (might be due to invalid IL or missing references)
			//IL_0568: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_050a: Unknown result type (might be due to invalid IL or missing references)
			//IL_050f: Unknown result type (might be due to invalid IL or missing references)
			//IL_057d: Unknown result type (might be due to invalid IL or missing references)
			//IL_057f: Unknown result type (might be due to invalid IL or missing references)
			//IL_06cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0786: Unknown result type (might be due to invalid IL or missing references)
			//IL_078b: Unknown result type (might be due to invalid IL or missing references)
			//IL_07a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_07a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0191: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<BattleState> result;
			try
			{
				if ((uint)num > 6u)
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
						else if (string.IsNullOrEmpty(request.OpponentPlayerId))
						{
							result = Result<BattleState>.FailureResult("Opponent player ID is required for Guild War battles");
						}
						else if (request.OpponentSpiritIds == null || request.OpponentSpiritIds.Count == 0)
						{
							result = Result<BattleState>.FailureResult("Opponent squad is empty");
						}
						else
						{
							_003CplayerSpirits_003E5__1 = new List<PlayerSpirit>();
							_003C_003Es__6 = request.PlayerSpiritIds.GetEnumerator();
							try
							{
								while (_003C_003Es__6.MoveNext())
								{
									_003CspiritId_003E5__7 = _003C_003Es__6.Current;
									_003Cspirit_003E5__8 = _003C_003E4__this._playerStateService.GetPlayerSpirit(_003CspiritId_003E5__7);
									if (_003Cspirit_003E5__8 != null)
									{
										_003CplayerSpirits_003E5__1.Add(_003Cspirit_003E5__8);
									}
									_003Cspirit_003E5__8 = null;
									_003CspiritId_003E5__7 = null;
								}
							}
							finally
							{
								if (num < 0)
								{
									((global::System.IDisposable)_003C_003Es__6).Dispose();
								}
							}
							_003C_003Es__6 = default(Enumerator<string>);
							if (_003CplayerSpirits_003E5__1.Count != 0)
							{
								_003CopponentSpirits_003E5__2 = new List<PlayerSpirit>();
								_003C_003Es__9 = request.OpponentSpiritIds.GetEnumerator();
								goto case 0;
							}
							result = Result<BattleState>.FailureResult("No valid player spirits found");
						}
						goto end_IL_0011;
					case 0:
						try
						{
							if (num != 0)
							{
								goto IL_02c3;
							}
							TaskAwaiter<PlayerSpirit> awaiter7 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<PlayerSpirit>);
							num = (_003C_003E1__state = -1);
							goto IL_0273;
							IL_0273:
							_003C_003Es__12 = awaiter7.GetResult();
							_003Cspirit_003E5__11 = _003C_003Es__12;
							_003C_003Es__12 = null;
							if (_003Cspirit_003E5__11 != null)
							{
								_003CopponentSpirits_003E5__2.Add(_003Cspirit_003E5__11);
							}
							_003Cspirit_003E5__11 = null;
							_003CspiritId_003E5__10 = null;
							goto IL_02c3;
							IL_02c3:
							if (_003C_003Es__9.MoveNext())
							{
								_003CspiritId_003E5__10 = _003C_003Es__9.Current;
								awaiter7 = _003C_003E4__this._playerSpiritRepository.GetByIdAsync(request.OpponentPlayerId, _003CspiritId_003E5__10).GetAwaiter();
								if (!awaiter7.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter7;
									_003CExecuteAsync_003Ed__7 _003CExecuteAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<PlayerSpirit>, _003CExecuteAsync_003Ed__7>(ref awaiter7, ref _003CExecuteAsync_003Ed__);
									return;
								}
								goto IL_0273;
							}
						}
						finally
						{
							if (num < 0)
							{
								((global::System.IDisposable)_003C_003Es__9).Dispose();
							}
						}
						_003C_003Es__9 = default(Enumerator<string>);
						if (_003CopponentSpirits_003E5__2.Count != 0)
						{
							_003CplayerBattleSprites_003E5__3 = new List<BattleSprite>();
							_003C_003Es__13 = _003CplayerSpirits_003E5__1.GetEnumerator();
							goto case 1;
						}
						result = Result<BattleState>.FailureResult("No valid opponent spirits found");
						goto end_IL_0011;
					case 1:
					case 2:
						try
						{
							TaskAwaiter awaiter5;
							if (num != 1)
							{
								if (num != 2)
								{
									goto IL_04c2;
								}
								awaiter5 = _003C_003Eu__3;
								_003C_003Eu__3 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0492;
							}
							TaskAwaiter<Spirit> awaiter6 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<Spirit>);
							num = (_003C_003E1__state = -1);
							goto IL_03de;
							IL_0492:
							((TaskAwaiter)(ref awaiter5)).GetResult();
							_003CplayerBattleSprites_003E5__3.Add(_003CbattleSprite_003E5__16);
							_003CbaseSpirit_003E5__15 = null;
							_003CbattleSprite_003E5__16 = null;
							_003CplayerSpirit_003E5__14 = null;
							goto IL_04c2;
							IL_04c2:
							if (_003C_003Es__13.MoveNext())
							{
								_003CplayerSpirit_003E5__14 = _003C_003Es__13.Current;
								awaiter6 = _003C_003E4__this._spiritRepository.GetByIdAsync(_003CplayerSpirit_003E5__14.BaseSpiritID.ToString()).GetAwaiter();
								if (!awaiter6.IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter6;
									_003CExecuteAsync_003Ed__7 _003CExecuteAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Spirit>, _003CExecuteAsync_003Ed__7>(ref awaiter6, ref _003CExecuteAsync_003Ed__);
									return;
								}
								goto IL_03de;
							}
							goto end_IL_033a;
							IL_03de:
							_003C_003Es__17 = awaiter6.GetResult();
							_003CbaseSpirit_003E5__15 = _003C_003Es__17;
							_003C_003Es__17 = null;
							if (_003CbaseSpirit_003E5__15 == null)
							{
								goto IL_04c2;
							}
							_003CbattleSprite_003E5__16 = new BattleSprite(_003CbaseSpirit_003E5__15, _003CplayerSpirit_003E5__14);
							awaiter5 = _003C_003E4__this.LoadEquipmentForSprite(_003CbattleSprite_003E5__16, BattleMode.GuildWar).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter5;
								_003CExecuteAsync_003Ed__7 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteAsync_003Ed__7>(ref awaiter5, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_0492;
							end_IL_033a:;
						}
						finally
						{
							if (num < 0)
							{
								((global::System.IDisposable)_003C_003Es__13).Dispose();
							}
						}
						_003C_003Es__13 = default(Enumerator<PlayerSpirit>);
						_003CopponentBattleSprites_003E5__4 = new List<BattleSprite>();
						_003C_003Es__18 = _003CopponentSpirits_003E5__2.GetEnumerator();
						goto case 3;
					case 3:
					case 4:
						try
						{
							TaskAwaiter awaiter3;
							if (num != 3)
							{
								if (num != 4)
								{
									goto IL_069d;
								}
								awaiter3 = _003C_003Eu__3;
								_003C_003Eu__3 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_066d;
							}
							TaskAwaiter<Spirit> awaiter4 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<Spirit>);
							num = (_003C_003E1__state = -1);
							goto IL_05b9;
							IL_066d:
							((TaskAwaiter)(ref awaiter3)).GetResult();
							_003CopponentBattleSprites_003E5__4.Add(_003CbattleSprite_003E5__21);
							_003CbaseSpirit_003E5__20 = null;
							_003CbattleSprite_003E5__21 = null;
							_003CopponentSpirit_003E5__19 = null;
							goto IL_069d;
							IL_069d:
							if (_003C_003Es__18.MoveNext())
							{
								_003CopponentSpirit_003E5__19 = _003C_003Es__18.Current;
								awaiter4 = _003C_003E4__this._spiritRepository.GetByIdAsync(_003CopponentSpirit_003E5__19.BaseSpiritID.ToString()).GetAwaiter();
								if (!awaiter4.IsCompleted)
								{
									num = (_003C_003E1__state = 3);
									_003C_003Eu__2 = awaiter4;
									_003CExecuteAsync_003Ed__7 _003CExecuteAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Spirit>, _003CExecuteAsync_003Ed__7>(ref awaiter4, ref _003CExecuteAsync_003Ed__);
									return;
								}
								goto IL_05b9;
							}
							goto end_IL_0515;
							IL_05b9:
							_003C_003Es__22 = awaiter4.GetResult();
							_003CbaseSpirit_003E5__20 = _003C_003Es__22;
							_003C_003Es__22 = null;
							if (_003CbaseSpirit_003E5__20 == null)
							{
								goto IL_069d;
							}
							_003CbattleSprite_003E5__21 = new BattleSprite(_003CbaseSpirit_003E5__20, _003CopponentSpirit_003E5__19);
							awaiter3 = _003C_003E4__this.LoadEquipmentForSprite(_003CbattleSprite_003E5__21, BattleMode.GuildWar).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 4);
								_003C_003Eu__3 = awaiter3;
								_003CExecuteAsync_003Ed__7 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteAsync_003Ed__7>(ref awaiter3, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_066d;
							end_IL_0515:;
						}
						finally
						{
							if (num < 0)
							{
								((global::System.IDisposable)_003C_003Es__18).Dispose();
							}
						}
						_003C_003Es__18 = default(Enumerator<PlayerSpirit>);
						if (_003CplayerBattleSprites_003E5__3.Count == 0)
						{
							result = Result<BattleState>.FailureResult("Failed to create player battle sprites");
						}
						else
						{
							if (_003CopponentBattleSprites_003E5__4.Count != 0)
							{
								_003CbattleState_003E5__5 = new BattleState
								{
									BattleMode = BattleMode.GuildWar,
									PlayerBattleSprites = _003CplayerBattleSprites_003E5__3,
									OpponentBattleSprites = _003CopponentBattleSprites_003E5__4,
									CurrentTurn = 1,
									ActivePlayerSpiritIndex = 0,
									ActiveOpponentSpiritIndex = 0,
									IsPlayerTurn = true,
									BattleEnded = false
								};
								awaiter2 = _003C_003E4__this._specialAbilityService.HandleBattleStartEffects(_003CbattleState_003E5__5, BattleMode.GuildWar).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 5);
									_003C_003Eu__3 = awaiter2;
									_003CExecuteAsync_003Ed__7 _003CExecuteAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteAsync_003Ed__7>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
									return;
								}
								goto IL_07dc;
							}
							result = Result<BattleState>.FailureResult("Failed to create opponent battle sprites");
						}
						goto end_IL_0011;
					case 5:
						awaiter2 = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_07dc;
					case 6:
						{
							awaiter = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_07dc:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						awaiter = _003C_003E4__this._specialAbilityService.HandleSpiritEntersBattleEffects(_003CbattleState_003E5__5, BattleMode.GuildWar).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 6);
							_003C_003Eu__3 = awaiter;
							_003CExecuteAsync_003Ed__7 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteAsync_003Ed__7>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
						break;
					}
					((TaskAwaiter)(ref awaiter)).GetResult();
					result = Result<BattleState>.SuccessResult(_003CbattleState_003E5__5);
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__23 = ex;
					result = Result<BattleState>.FailureResult("Failed to initialize Guild War battle: " + _003Cex_003E5__23.Message);
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
	private sealed class _003CLoadEquipmentForSprite_003Ed__8 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleSprite sprite;

		public BattleMode battleMode;

		public StartGuildWarBattleInitUseCase _003C_003E4__this;

		private Item _003Cgear_003E5__1;

		private Item _003Ctalent_003E5__2;

		private Item _003C_003Es__3;

		private Item _003C_003Es__4;

		private Item _003C_003Es__5;

		private Item _003C_003Es__6;

		private TaskAwaiter<Item?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<Item> awaiter;
				TaskAwaiter<Item> awaiter2;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Item>);
						num = (_003C_003E1__state = -1);
						goto IL_016e;
					}
					if (string.IsNullOrEmpty(sprite.PlayerSpirit.GearID))
					{
						_003C_003Es__3 = null;
						goto IL_00cf;
					}
					awaiter2 = _003C_003E4__this._itemRepository.GetGearByIdAsync(sprite.PlayerSpirit.GearID).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003CLoadEquipmentForSprite_003Ed__8 _003CLoadEquipmentForSprite_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Item>, _003CLoadEquipmentForSprite_003Ed__8>(ref awaiter2, ref _003CLoadEquipmentForSprite_003Ed__);
						return;
					}
				}
				else
				{
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Item>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__4 = awaiter2.GetResult();
				_003C_003Es__3 = _003C_003Es__4;
				_003C_003Es__4 = null;
				goto IL_00cf;
				IL_016e:
				_003C_003Es__6 = awaiter.GetResult();
				_003C_003Es__5 = _003C_003Es__6;
				_003C_003Es__6 = null;
				goto IL_0197;
				IL_0197:
				_003Ctalent_003E5__2 = _003C_003Es__5;
				_003C_003Es__5 = null;
				sprite.SetEquipments(_003Cgear_003E5__1, _003Ctalent_003E5__2, null);
				_003C_003E4__this._specialAbilityService.InitializeTurnBasedEffects(sprite, battleMode);
				_003C_003E4__this._battleCalculationService.RecalculateAllStats(sprite, battleMode);
				goto end_IL_0007;
				IL_00cf:
				_003Cgear_003E5__1 = _003C_003Es__3;
				_003C_003Es__3 = null;
				if (!string.IsNullOrEmpty(sprite.PlayerSpirit.TalentID))
				{
					awaiter = _003C_003E4__this._itemRepository.GetTalentByIdAsync(sprite.PlayerSpirit.TalentID).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter;
						_003CLoadEquipmentForSprite_003Ed__8 _003CLoadEquipmentForSprite_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Item>, _003CLoadEquipmentForSprite_003Ed__8>(ref awaiter, ref _003CLoadEquipmentForSprite_003Ed__);
						return;
					}
					goto IL_016e;
				}
				_003C_003Es__5 = null;
				goto IL_0197;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cgear_003E5__1 = null;
				_003Ctalent_003E5__2 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cgear_003E5__1 = null;
			_003Ctalent_003E5__2 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly ISpiritRepository _spiritRepository;

	private readonly IItemRepository _itemRepository;

	private readonly IPlayerSpiritRepository _playerSpiritRepository;

	private readonly IPlayerStateService _playerStateService;

	private readonly IBattleCalculationService _battleCalculationService;

	private readonly ISpecialAbilityService _specialAbilityService;

	public StartGuildWarBattleInitUseCase(ISpiritRepository spiritRepository, IItemRepository itemRepository, IPlayerSpiritRepository playerSpiritRepository, IPlayerStateService playerStateService, IBattleCalculationService battleCalculationService, ISpecialAbilityService specialAbilityService)
	{
		_spiritRepository = spiritRepository;
		_itemRepository = itemRepository;
		_playerSpiritRepository = playerSpiritRepository;
		_playerStateService = playerStateService;
		_battleCalculationService = battleCalculationService;
		_specialAbilityService = specialAbilityService;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__7))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<BattleState>> ExecuteAsync(StartGuildWarBattleInitRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (request.PlayerSpiritIds == null || request.PlayerSpiritIds.Count == 0)
			{
				return Result<BattleState>.FailureResult("Player squad is empty");
			}
			if (string.IsNullOrEmpty(request.OpponentPlayerId))
			{
				return Result<BattleState>.FailureResult("Opponent player ID is required for Guild War battles");
			}
			if (request.OpponentSpiritIds == null || request.OpponentSpiritIds.Count == 0)
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
			List<PlayerSpirit> opponentSpirits = new List<PlayerSpirit>();
			Enumerator<string> enumerator2 = request.OpponentSpiritIds.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					string spiritId2 = enumerator2.Current;
					PlayerSpirit spirit2 = await _playerSpiritRepository.GetByIdAsync(request.OpponentPlayerId, spiritId2);
					if (spirit2 != null)
					{
						opponentSpirits.Add(spirit2);
					}
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator2).Dispose();
			}
			if (opponentSpirits.Count == 0)
			{
				return Result<BattleState>.FailureResult("No valid opponent spirits found");
			}
			List<BattleSprite> playerBattleSprites = new List<BattleSprite>();
			Enumerator<PlayerSpirit> enumerator3 = playerSpirits.GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					PlayerSpirit playerSpirit = enumerator3.Current;
					Spirit baseSpirit2 = await _spiritRepository.GetByIdAsync(playerSpirit.BaseSpiritID.ToString());
					if (baseSpirit2 != null)
					{
						BattleSprite battleSprite2 = new BattleSprite(baseSpirit2, playerSpirit);
						await LoadEquipmentForSprite(battleSprite2, BattleMode.GuildWar);
						playerBattleSprites.Add(battleSprite2);
					}
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator3).Dispose();
			}
			List<BattleSprite> opponentBattleSprites = new List<BattleSprite>();
			Enumerator<PlayerSpirit> enumerator4 = opponentSpirits.GetEnumerator();
			try
			{
				while (enumerator4.MoveNext())
				{
					PlayerSpirit opponentSpirit = enumerator4.Current;
					Spirit baseSpirit = await _spiritRepository.GetByIdAsync(opponentSpirit.BaseSpiritID.ToString());
					if (baseSpirit != null)
					{
						BattleSprite battleSprite = new BattleSprite(baseSpirit, opponentSpirit);
						await LoadEquipmentForSprite(battleSprite, BattleMode.GuildWar);
						opponentBattleSprites.Add(battleSprite);
					}
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator4).Dispose();
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
				BattleMode = BattleMode.GuildWar,
				PlayerBattleSprites = playerBattleSprites,
				OpponentBattleSprites = opponentBattleSprites,
				CurrentTurn = 1,
				ActivePlayerSpiritIndex = 0,
				ActiveOpponentSpiritIndex = 0,
				IsPlayerTurn = true,
				BattleEnded = false
			};
			await _specialAbilityService.HandleBattleStartEffects(battleState, BattleMode.GuildWar);
			await _specialAbilityService.HandleSpiritEntersBattleEffects(battleState, BattleMode.GuildWar);
			return Result<BattleState>.SuccessResult(battleState);
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			return Result<BattleState>.FailureResult("Failed to initialize Guild War battle: " + ex.Message);
		}
	}

	[AsyncStateMachine(typeof(_003CLoadEquipmentForSprite_003Ed__8))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadEquipmentForSprite(BattleSprite sprite, BattleMode battleMode)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadEquipmentForSprite_003Ed__8 _003CLoadEquipmentForSprite_003Ed__ = new _003CLoadEquipmentForSprite_003Ed__8();
		_003CLoadEquipmentForSprite_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadEquipmentForSprite_003Ed__._003C_003E4__this = this;
		_003CLoadEquipmentForSprite_003Ed__.sprite = sprite;
		_003CLoadEquipmentForSprite_003Ed__.battleMode = battleMode;
		_003CLoadEquipmentForSprite_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadEquipmentForSprite_003Ed__._003C_003Et__builder)).Start<_003CLoadEquipmentForSprite_003Ed__8>(ref _003CLoadEquipmentForSprite_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadEquipmentForSprite_003Ed__._003C_003Et__builder)).Task;
	}
}
