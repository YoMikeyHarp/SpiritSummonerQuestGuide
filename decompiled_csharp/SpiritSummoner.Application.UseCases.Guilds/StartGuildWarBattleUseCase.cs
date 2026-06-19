using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.DTOs.Battles;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Battles;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Enums.Battles;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Presentation.ViewModels.Battles;

namespace SpiritSummoner.Application.UseCases.Guilds;

public class StartGuildWarBattleUseCase : IUseCase<StartGuildWarBattleRequest, BattleLaunchRequest>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<BattleLaunchRequest>> _003C_003Et__builder;

		public StartGuildWarBattleRequest request;

		public StartGuildWarBattleUseCase _003C_003E4__this;

		private Player _003Cplayer_003E5__1;

		private Guild _003CattackingGuild_003E5__2;

		private List<string> _003CplayerSquad_003E5__3;

		private string _003CdefendingGuildId_003E5__4;

		private string _003CwarId_003E5__5;

		private Guild _003CdefendingGuild_003E5__6;

		private GuildWarProgress _003Cprogress_003E5__7;

		private Dictionary<string, long> _003CattackCounts_003E5__8;

		private GuildMember _003Cdefender_003E5__9;

		private List<string> _003CdefenderSquadIds_003E5__10;

		private Result<PreCommitBattleResult> _003CpreCommitResult_003E5__11;

		private BattleLaunchRequest _003CbattleRequest_003E5__12;

		private Guild _003C_003Es__13;

		private GuildWarProgress _003C_003Es__14;

		private GuildMember _003C_003Es__15;

		private Result<PreCommitBattleResult> _003C_003Es__16;

		private TaskAwaiter<Guild?> _003C_003Eu__1;

		private TaskAwaiter<GuildWarProgress?> _003C_003Eu__2;

		private TaskAwaiter<GuildMember?> _003C_003Eu__3;

		private TaskAwaiter<bool> _003C_003Eu__4;

		private TaskAwaiter<Result<PreCommitBattleResult>> _003C_003Eu__5;

		private void MoveNext()
		{
			//IL_0252: Unknown result type (might be due to invalid IL or missing references)
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			//IL_025f: Unknown result type (might be due to invalid IL or missing references)
			//IL_032f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0334: Unknown result type (might be due to invalid IL or missing references)
			//IL_033c: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0534: Unknown result type (might be due to invalid IL or missing references)
			//IL_0539: Unknown result type (might be due to invalid IL or missing references)
			//IL_0541: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_05c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0579: Unknown result type (might be due to invalid IL or missing references)
			//IL_057e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0593: Unknown result type (might be due to invalid IL or missing references)
			//IL_0595: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_030f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0311: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0514: Unknown result type (might be due to invalid IL or missing references)
			//IL_0516: Unknown result type (might be due to invalid IL or missing references)
			//IL_0218: Unknown result type (might be due to invalid IL or missing references)
			//IL_021d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0232: Unknown result type (might be due to invalid IL or missing references)
			//IL_0234: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<BattleLaunchRequest> result;
			try
			{
				TaskAwaiter<Guild> awaiter5;
				TaskAwaiter<GuildWarProgress> awaiter4;
				TaskAwaiter<GuildMember> awaiter3;
				TaskAwaiter<bool> awaiter2;
				TaskAwaiter<Result<PreCommitBattleResult>> awaiter;
				switch (num)
				{
				default:
					_003Cplayer_003E5__1 = _003C_003E4__this._playerStateService.GetCurrentPlayer();
					if (_003Cplayer_003E5__1 == null)
					{
						result = Result<BattleLaunchRequest>.FailureResult("Player not found");
					}
					else
					{
						_003CattackingGuild_003E5__2 = _003C_003E4__this._guildStateSerivce.GetCurrentGuild();
						if (_003CattackingGuild_003E5__2 == null)
						{
							result = Result<BattleLaunchRequest>.FailureResult("Your guild not found");
						}
						else if (string.IsNullOrEmpty(request.DefendingGuildId))
						{
							result = Result<BattleLaunchRequest>.FailureResult("No target guild selected.");
						}
						else if (request.DefendingGuildId == request.AttackingGuildId)
						{
							result = Result<BattleLaunchRequest>.FailureResult("You cannot attack your own guild.");
						}
						else if (!_003CattackingGuild_003E5__2.HasActiveWarSeason)
						{
							result = Result<BattleLaunchRequest>.FailureResult("No active war season. War starts Sunday @ 00:00 UTC.");
						}
						else if (!Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)_003CattackingGuild_003E5__2.DefenderPlayerIds, _003Cplayer_003E5__1.PlayerID))
						{
							result = Result<BattleLaunchRequest>.FailureResult("You are not registered as a defender for the war. Wait for next war seasons and make sure to register!");
						}
						else if (_003Cplayer_003E5__1.SP < 1)
						{
							result = Result<BattleLaunchRequest>.FailureResult("You need at least 1 SP to battle.");
						}
						else
						{
							_003CplayerSquad_003E5__3 = Enumerable.ToList<string>(Enumerable.Where<string>((global::System.Collections.Generic.IEnumerable<string>)_003Cplayer_003E5__1.ActiveSquad, (Func<string, bool>)((string s) => !string.IsNullOrEmpty(s))));
							if (_003CplayerSquad_003E5__3.Count == 3)
							{
								_003CdefendingGuildId_003E5__4 = request.DefendingGuildId;
								_003CwarId_003E5__5 = _003CattackingGuild_003E5__2.CurrentWarId ?? string.Empty;
								awaiter5 = _003C_003E4__this._guildRepo.GetByIdAsync(_003CdefendingGuildId_003E5__4).GetAwaiter();
								if (!awaiter5.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter5;
									_003CExecuteAsync_003Ed__5 _003CExecuteAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CExecuteAsync_003Ed__5>(ref awaiter5, ref _003CExecuteAsync_003Ed__);
									return;
								}
								goto IL_026e;
							}
							result = Result<BattleLaunchRequest>.FailureResult("You need exactly 3 spirits in your active squad.");
						}
					}
					goto end_IL_0007;
				case 0:
					awaiter5 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Guild>);
					num = (_003C_003E1__state = -1);
					goto IL_026e;
				case 1:
					awaiter4 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<GuildWarProgress>);
					num = (_003C_003E1__state = -1);
					goto IL_034b;
				case 2:
					awaiter3 = _003C_003Eu__3;
					_003C_003Eu__3 = default(TaskAwaiter<GuildMember>);
					num = (_003C_003E1__state = -1);
					goto IL_0409;
				case 3:
					awaiter2 = _003C_003Eu__4;
					_003C_003Eu__4 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_0550;
				case 4:
					{
						awaiter = _003C_003Eu__5;
						_003C_003Eu__5 = default(TaskAwaiter<Result<PreCommitBattleResult>>);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_034b:
					_003C_003Es__14 = awaiter4.GetResult();
					_003Cprogress_003E5__7 = _003C_003Es__14;
					_003C_003Es__14 = null;
					_003CattackCounts_003E5__8 = _003Cprogress_003E5__7?.PlayerAttackCounts ?? new Dictionary<string, long>();
					awaiter3 = _003C_003E4__this._guildRepo.GetNextDefenderAsync(request.AttackingGuildId, _003CdefendingGuildId_003E5__4, _003CwarId_003E5__5).GetAwaiter();
					if (!awaiter3.IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__3 = awaiter3;
						_003CExecuteAsync_003Ed__5 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<GuildMember>, _003CExecuteAsync_003Ed__5>(ref awaiter3, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_0409;
					IL_026e:
					_003C_003Es__13 = awaiter5.GetResult();
					_003CdefendingGuild_003E5__6 = _003C_003Es__13;
					_003C_003Es__13 = null;
					if (_003CdefendingGuild_003E5__6 == null)
					{
						result = Result<BattleLaunchRequest>.FailureResult("Opponent guild not found");
					}
					else
					{
						if (!_003CdefendingGuild_003E5__6.IsInGuildBreak)
						{
							awaiter4 = _003C_003E4__this._guildRepo.GetWarProgressAsync(request.AttackingGuildId, _003CdefendingGuildId_003E5__4, _003CwarId_003E5__5).GetAwaiter();
							if (!awaiter4.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter4;
								_003CExecuteAsync_003Ed__5 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<GuildWarProgress>, _003CExecuteAsync_003Ed__5>(ref awaiter4, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_034b;
						}
						result = Result<BattleLaunchRequest>.FailureResult("No defenders remain. You can now raid the opponent guild's crystals directly.");
					}
					goto end_IL_0007;
					IL_0409:
					_003C_003Es__15 = awaiter3.GetResult();
					_003Cdefender_003E5__9 = _003C_003Es__15;
					_003C_003Es__15 = null;
					if (_003Cdefender_003E5__9 == null)
					{
						result = Result<BattleLaunchRequest>.FailureResult("No defenders remain. You can now raid the opponent guild's crystals directly.");
					}
					else
					{
						if (_003CdefendingGuild_003E5__6.DefenderSquads.TryGetValue(_003Cdefender_003E5__9.PlayerId, ref _003CdefenderSquadIds_003E5__10) && _003CdefenderSquadIds_003E5__10.Count == 3)
						{
							_003CattackCounts_003E5__8[request.AttackingPlayerId] = CollectionExtensions.GetValueOrDefault<string, long>((IReadOnlyDictionary<string, long>)(object)_003CattackCounts_003E5__8, request.AttackingPlayerId, 0L) + 1;
							awaiter2 = _003C_003E4__this._guildRepo.UpdateAttackCountsAsync(request.AttackingGuildId, _003CdefendingGuildId_003E5__4, _003CwarId_003E5__5, _003CattackCounts_003E5__8, DateTimeOffset.UtcNow).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__4 = awaiter2;
								_003CExecuteAsync_003Ed__5 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__5>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_0550;
						}
						result = Result<BattleLaunchRequest>.FailureResult("Selected defender has invalid squad configuration.");
					}
					goto end_IL_0007;
					IL_0550:
					awaiter2.GetResult();
					awaiter = _003C_003E4__this._preCommitBattleUseCase.ExecuteAsync(new PreCommitBattleRequest(_003Cdefender_003E5__9.Level, IsPvP: true)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__5 = awaiter;
						_003CExecuteAsync_003Ed__5 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Result<PreCommitBattleResult>>, _003CExecuteAsync_003Ed__5>(ref awaiter, ref _003CExecuteAsync_003Ed__);
						return;
					}
					break;
				}
				_003C_003Es__16 = awaiter.GetResult();
				_003CpreCommitResult_003E5__11 = _003C_003Es__16;
				_003C_003Es__16 = null;
				if (!_003CpreCommitResult_003E5__11.Success)
				{
					result = Result<BattleLaunchRequest>.FailureResult(_003CpreCommitResult_003E5__11.ErrorMessage ?? "Failed to start battle");
				}
				else
				{
					_003CbattleRequest_003E5__12 = new BattleLaunchRequest
					{
						Mode = BattleMode.GuildWar,
						PlayerId = _003Cplayer_003E5__1.PlayerID,
						PlayerSpiritIds = _003CplayerSquad_003E5__3,
						OpponentPlayerId = _003Cdefender_003E5__9.PlayerId,
						OpponentLevel = _003Cdefender_003E5__9.Level,
						OpponentSpiritIds = _003CdefenderSquadIds_003E5__10,
						BattleId = _003CpreCommitResult_003E5__11.Data.BattleId,
						PreCommittedScorePenalty = _003CpreCommitResult_003E5__11.Data.PreCommittedScorePenalty,
						CompletionSource = new TaskCompletionSource<BattleResultDTO>(),
						AttackingGuildId = _003CattackingGuild_003E5__2.Name,
						DefendingGuildId = _003CdefendingGuild_003E5__6.Name,
						DefenderName = _003Cdefender_003E5__9.PlayerName
					};
					result = Result<BattleLaunchRequest>.SuccessResult(_003CbattleRequest_003E5__12);
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cplayer_003E5__1 = null;
				_003CattackingGuild_003E5__2 = null;
				_003CplayerSquad_003E5__3 = null;
				_003CdefendingGuildId_003E5__4 = null;
				_003CwarId_003E5__5 = null;
				_003CdefendingGuild_003E5__6 = null;
				_003Cprogress_003E5__7 = null;
				_003CattackCounts_003E5__8 = null;
				_003Cdefender_003E5__9 = null;
				_003CdefenderSquadIds_003E5__10 = null;
				_003CpreCommitResult_003E5__11 = null;
				_003CbattleRequest_003E5__12 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cplayer_003E5__1 = null;
			_003CattackingGuild_003E5__2 = null;
			_003CplayerSquad_003E5__3 = null;
			_003CdefendingGuildId_003E5__4 = null;
			_003CwarId_003E5__5 = null;
			_003CdefendingGuild_003E5__6 = null;
			_003Cprogress_003E5__7 = null;
			_003CattackCounts_003E5__8 = null;
			_003Cdefender_003E5__9 = null;
			_003CdefenderSquadIds_003E5__10 = null;
			_003CpreCommitResult_003E5__11 = null;
			_003CbattleRequest_003E5__12 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IGuildRepository _guildRepo;

	private readonly IPlayerStateService _playerStateService;

	private readonly IGuildStateService _guildStateSerivce;

	private readonly PreCommitBattleUseCase _preCommitBattleUseCase;

	public StartGuildWarBattleUseCase(IGuildRepository guildRepo, IPlayerStateService playerStateService, IGuildStateService guildStateService, PreCommitBattleUseCase preCommitBattleUseCase)
	{
		_guildRepo = guildRepo;
		_playerStateService = playerStateService;
		_guildStateSerivce = guildStateService;
		_preCommitBattleUseCase = preCommitBattleUseCase;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__5))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<BattleLaunchRequest>> ExecuteAsync(StartGuildWarBattleRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Player player = _playerStateService.GetCurrentPlayer();
		if (player == null)
		{
			return Result<BattleLaunchRequest>.FailureResult("Player not found");
		}
		Guild attackingGuild = _guildStateSerivce.GetCurrentGuild();
		if (attackingGuild == null)
		{
			return Result<BattleLaunchRequest>.FailureResult("Your guild not found");
		}
		if (string.IsNullOrEmpty(request.DefendingGuildId))
		{
			return Result<BattleLaunchRequest>.FailureResult("No target guild selected.");
		}
		if (request.DefendingGuildId == request.AttackingGuildId)
		{
			return Result<BattleLaunchRequest>.FailureResult("You cannot attack your own guild.");
		}
		if (!attackingGuild.HasActiveWarSeason)
		{
			return Result<BattleLaunchRequest>.FailureResult("No active war season. War starts Sunday @ 00:00 UTC.");
		}
		if (!Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)attackingGuild.DefenderPlayerIds, player.PlayerID))
		{
			return Result<BattleLaunchRequest>.FailureResult("You are not registered as a defender for the war. Wait for next war seasons and make sure to register!");
		}
		if (player.SP < 1)
		{
			return Result<BattleLaunchRequest>.FailureResult("You need at least 1 SP to battle.");
		}
		List<string> playerSquad = Enumerable.ToList<string>(Enumerable.Where<string>((global::System.Collections.Generic.IEnumerable<string>)player.ActiveSquad, (Func<string, bool>)((string s) => !string.IsNullOrEmpty(s))));
		if (playerSquad.Count != 3)
		{
			return Result<BattleLaunchRequest>.FailureResult("You need exactly 3 spirits in your active squad.");
		}
		string defendingGuildId = request.DefendingGuildId;
		string warId = attackingGuild.CurrentWarId ?? string.Empty;
		Guild defendingGuild = await _guildRepo.GetByIdAsync(defendingGuildId);
		if (defendingGuild == null)
		{
			return Result<BattleLaunchRequest>.FailureResult("Opponent guild not found");
		}
		if (defendingGuild.IsInGuildBreak)
		{
			return Result<BattleLaunchRequest>.FailureResult("No defenders remain. You can now raid the opponent guild's crystals directly.");
		}
		Dictionary<string, long> attackCounts = (await _guildRepo.GetWarProgressAsync(request.AttackingGuildId, defendingGuildId, warId))?.PlayerAttackCounts ?? new Dictionary<string, long>();
		GuildMember defender = await _guildRepo.GetNextDefenderAsync(request.AttackingGuildId, defendingGuildId, warId);
		if (defender == null)
		{
			return Result<BattleLaunchRequest>.FailureResult("No defenders remain. You can now raid the opponent guild's crystals directly.");
		}
		List<string> defenderSquadIds = default(List<string>);
		if (!defendingGuild.DefenderSquads.TryGetValue(defender.PlayerId, ref defenderSquadIds) || defenderSquadIds.Count != 3)
		{
			return Result<BattleLaunchRequest>.FailureResult("Selected defender has invalid squad configuration.");
		}
		attackCounts[request.AttackingPlayerId] = CollectionExtensions.GetValueOrDefault<string, long>((IReadOnlyDictionary<string, long>)(object)attackCounts, request.AttackingPlayerId, 0L) + 1;
		await _guildRepo.UpdateAttackCountsAsync(request.AttackingGuildId, defendingGuildId, warId, attackCounts, DateTimeOffset.UtcNow);
		Result<PreCommitBattleResult> preCommitResult = await _preCommitBattleUseCase.ExecuteAsync(new PreCommitBattleRequest(defender.Level, IsPvP: true));
		if (!preCommitResult.Success)
		{
			return Result<BattleLaunchRequest>.FailureResult(preCommitResult.ErrorMessage ?? "Failed to start battle");
		}
		BattleLaunchRequest battleRequest = new BattleLaunchRequest
		{
			Mode = BattleMode.GuildWar,
			PlayerId = player.PlayerID,
			PlayerSpiritIds = playerSquad,
			OpponentPlayerId = defender.PlayerId,
			OpponentLevel = defender.Level,
			OpponentSpiritIds = defenderSquadIds,
			BattleId = preCommitResult.Data.BattleId,
			PreCommittedScorePenalty = preCommitResult.Data.PreCommittedScorePenalty,
			CompletionSource = new TaskCompletionSource<BattleResultDTO>(),
			AttackingGuildId = attackingGuild.Name,
			DefendingGuildId = defendingGuild.Name,
			DefenderName = defender.PlayerName
		};
		return Result<BattleLaunchRequest>.SuccessResult(battleRequest);
	}
}
