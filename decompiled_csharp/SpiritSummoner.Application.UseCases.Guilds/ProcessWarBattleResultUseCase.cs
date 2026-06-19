using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.UseCases.Battles;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Configuration;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Enums.Battles;
using SpiritSummoner.Domain.Enums.Guilds;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Guilds;

public class ProcessWarBattleResultUseCase : IUseCase<ProcessWarBattleResultRequest, ProcessWarBattleResultData>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<ProcessWarBattleResultData>> _003C_003Et__builder;

		public ProcessWarBattleResultRequest request;

		public ProcessWarBattleResultUseCase _003C_003E4__this;

		private Result<BattleRewards> _003CcompleteBattleResult_003E5__1;

		private BattleTaskType[] _003CtaskTypes_003E5__2;

		private GuildWarProgress _003Cprogress_003E5__3;

		private int _003CstartingCrystals_003E5__4;

		private int _003CcurrentCrystals_003E5__5;

		private Result<BattleRewards> _003C_003Es__6;

		private GuildWarProgress _003C_003Es__7;

		private Guild _003CdefendingGuild_003E5__8;

		private Guild _003C_003Es__9;

		private Guild _003CdefendingGuild_003E5__10;

		private Random _003Crandom_003E5__11;

		private double _003Cpct_003E5__12;

		private double _003CdefenderMult_003E5__13;

		private double _003CprotectionMult_003E5__14;

		private double _003Craw_003E5__15;

		private double _003CshieldReduction_003E5__16;

		private double _003Ccap_003E5__17;

		private int _003CcrystalsAwarded_003E5__18;

		private bool _003CwasCapped_003E5__19;

		private int _003CbudgetRemaining_003E5__20;

		private bool _003ChourlyWindowActive_003E5__21;

		private DateTimeOffset? _003CattackerHourlyStart_003E5__22;

		private DateTimeOffset? _003Cs_003E5__23;

		private int _003CpreviousHourlyCrystals_003E5__24;

		private int _003CnewHourlyCrystals_003E5__25;

		private double _003CrecoveryReduction_003E5__26;

		private int _003CdowntimeMinutes_003E5__27;

		private DateTimeOffset _003CdowntimeEnds_003E5__28;

		private int _003CcurrentDefeatedCount_003E5__29;

		private DefenderWarRecord _003Crec_003E5__30;

		private Guild _003C_003Es__31;

		private Random _003Crandom_003E5__32;

		private int _003CdefenseReward_003E5__33;

		private int _003CcurrentDefeatedCount_003E5__34;

		private DefenderWarRecord _003Crec_003E5__35;

		private DateTimeOffset _003CexistingDowntime_003E5__36;

		private DefenderWarRecord _003Cr2_003E5__37;

		private TaskAwaiter<Result<BattleRewards>> _003C_003Eu__1;

		private TaskAwaiter<GuildWarProgress?> _003C_003Eu__2;

		private TaskAwaiter<Guild?> _003C_003Eu__3;

		private TaskAwaiter<bool> _003C_003Eu__4;

		private void MoveNext()
		{
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0273: Unknown result type (might be due to invalid IL or missing references)
			//IL_0278: Unknown result type (might be due to invalid IL or missing references)
			//IL_0280: Unknown result type (might be due to invalid IL or missing references)
			//IL_0360: Unknown result type (might be due to invalid IL or missing references)
			//IL_0365: Unknown result type (might be due to invalid IL or missing references)
			//IL_036d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0737: Unknown result type (might be due to invalid IL or missing references)
			//IL_073c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0744: Unknown result type (might be due to invalid IL or missing references)
			//IL_08e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_08ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_08f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_039d: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a7: Expected O, but got Unknown
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_0199: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_023a: Unknown result type (might be due to invalid IL or missing references)
			//IL_023f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0254: Unknown result type (might be due to invalid IL or missing references)
			//IL_0256: Unknown result type (might be due to invalid IL or missing references)
			//IL_0784: Unknown result type (might be due to invalid IL or missing references)
			//IL_078e: Expected O, but got Unknown
			//IL_0327: Unknown result type (might be due to invalid IL or missing references)
			//IL_032c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0341: Unknown result type (might be due to invalid IL or missing references)
			//IL_0343: Unknown result type (might be due to invalid IL or missing references)
			//IL_0544: Unknown result type (might be due to invalid IL or missing references)
			//IL_0573: Unknown result type (might be due to invalid IL or missing references)
			//IL_0838: Unknown result type (might be due to invalid IL or missing references)
			//IL_082b: Unknown result type (might be due to invalid IL or missing references)
			//IL_083d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0894: Unknown result type (might be due to invalid IL or missing references)
			//IL_08ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_08b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_062d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0632: Unknown result type (might be due to invalid IL or missing references)
			//IL_063d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0642: Unknown result type (might be due to invalid IL or missing references)
			//IL_08c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_08ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_06e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_06fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0703: Unknown result type (might be due to invalid IL or missing references)
			//IL_0718: Unknown result type (might be due to invalid IL or missing references)
			//IL_071a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<ProcessWarBattleResultData> result;
			try
			{
				TaskAwaiter<Result<BattleRewards>> awaiter6;
				TaskAwaiter<GuildWarProgress> awaiter5;
				TaskAwaiter<Guild> awaiter4;
				TaskAwaiter<Guild> awaiter3;
				TaskAwaiter<bool> awaiter2;
				TaskAwaiter<bool> awaiter;
				DateTimeOffset utcNow;
				GuildWarProgress guildWarProgress;
				GuildWarProgress guildWarProgress2;
				GuildWarProgress guildWarProgress3;
				switch (num)
				{
				default:
					awaiter6 = _003C_003E4__this._completeBattleUseCase.ExecuteAsync(new CompleteBattleRequest(request.OpponentLevel, request.Victory, IsPvP: true, request.LivingSpiritsCount, request.TotalHealthPercentage, request.PreCommittedScorePenalty)).GetAwaiter();
					if (!awaiter6.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter6;
						_003CExecuteAsync_003Ed__5 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Result<BattleRewards>>, _003CExecuteAsync_003Ed__5>(ref awaiter6, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_00e9;
				case 0:
					awaiter6 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Result<BattleRewards>>);
					num = (_003C_003E1__state = -1);
					goto IL_00e9;
				case 1:
					awaiter5 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<GuildWarProgress>);
					num = (_003C_003E1__state = -1);
					goto IL_01d4;
				case 2:
					awaiter4 = _003C_003Eu__3;
					_003C_003Eu__3 = default(TaskAwaiter<Guild>);
					num = (_003C_003E1__state = -1);
					goto IL_028f;
				case 3:
					awaiter3 = _003C_003Eu__3;
					_003C_003Eu__3 = default(TaskAwaiter<Guild>);
					num = (_003C_003E1__state = -1);
					goto IL_037c;
				case 4:
					awaiter2 = _003C_003Eu__4;
					_003C_003Eu__4 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_0753;
				case 5:
					{
						awaiter = _003C_003Eu__4;
						_003C_003Eu__4 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_01d4:
					_003C_003Es__7 = awaiter5.GetResult();
					_003Cprogress_003E5__3 = _003C_003Es__7;
					_003C_003Es__7 = null;
					_003CstartingCrystals_003E5__4 = _003Cprogress_003E5__3?.StartingCrystals ?? 0;
					if (_003CstartingCrystals_003E5__4 == 0)
					{
						awaiter4 = _003C_003E4__this._guildRepository.GetByIdAsync(request.DefendingGuildId).GetAwaiter();
						if (!awaiter4.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__3 = awaiter4;
							_003CExecuteAsync_003Ed__5 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CExecuteAsync_003Ed__5>(ref awaiter4, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_028f;
					}
					goto IL_02d4;
					IL_00e9:
					_003C_003Es__6 = awaiter6.GetResult();
					_003CcompleteBattleResult_003E5__1 = _003C_003Es__6;
					_003C_003Es__6 = null;
					_003CtaskTypes_003E5__2 = ((!request.Victory) ? new BattleTaskType[1] : new BattleTaskType[3]
					{
						BattleTaskType.CompleteBattle,
						BattleTaskType.WinBattle,
						BattleTaskType.AttackWarDefender
					});
					_003C_003E4__this._updateBattleTaskProgressUseCase.ExecuteAsync(new UpdateBattleTaskProgressRequest(_003CtaskTypes_003E5__2));
					awaiter5 = _003C_003E4__this._guildWarRepository.GetWarProgressAsync(request.AttackingGuildId, request.DefendingGuildId, request.WarId).GetAwaiter();
					if (!awaiter5.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter5;
						_003CExecuteAsync_003Ed__5 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<GuildWarProgress>, _003CExecuteAsync_003Ed__5>(ref awaiter5, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_01d4;
					IL_037c:
					_003C_003Es__31 = awaiter3.GetResult();
					_003CdefendingGuild_003E5__10 = _003C_003Es__31;
					_003C_003Es__31 = null;
					_003Crandom_003E5__11 = new Random();
					_003Cpct_003E5__12 = _003Crandom_003E5__11.NextDouble() * 0.03 + 0.05;
					_003CdefenderMult_003E5__13 = 1.0 + (double)request.DefenderLevel / 100.0;
					_003CprotectionMult_003E5__14 = _003Cprogress_003E5__3?.ProtectionMultiplier ?? 1.0;
					_003Craw_003E5__15 = (double)_003CcurrentCrystals_003E5__5 * _003Cpct_003E5__12 * _003CdefenderMult_003E5__13 * _003CprotectionMult_003E5__14;
					_003CshieldReduction_003E5__16 = (_003CdefendingGuild_003E5__10?.GetActivePerk(GuildPerkType.CrystalShield)?.GetEffectValue()).GetValueOrDefault();
					_003Craw_003E5__15 *= 1.0 - _003CshieldReduction_003E5__16;
					_003Ccap_003E5__17 = (double)_003CcurrentCrystals_003E5__5 * 0.15;
					_003CcrystalsAwarded_003E5__18 = (int)Math.Min(_003Craw_003E5__15, _003Ccap_003E5__17);
					_003CwasCapped_003E5__19 = _003CcrystalsAwarded_003E5__18 < (int)_003Craw_003E5__15;
					_003CbudgetRemaining_003E5__20 = _003Cprogress_003E5__3?.HourlyBudgetRemaining(request.AttackingPlayerId) ?? 500;
					_003CcrystalsAwarded_003E5__18 = Math.Min(_003CcrystalsAwarded_003E5__18, _003CbudgetRemaining_003E5__20);
					_003ChourlyWindowActive_003E5__21 = _003Cprogress_003E5__3?.IsHourlyWindowActive(request.AttackingPlayerId) ?? false;
					_003CattackerHourlyStart_003E5__22 = ((!_003ChourlyWindowActive_003E5__21) ? new DateTimeOffset?(DateTimeOffset.UtcNow) : (_003Cprogress_003E5__3.PlayerHourlyStarts.TryGetValue(request.AttackingPlayerId, ref _003Cs_003E5__23) ? _003Cs_003E5__23 : new DateTimeOffset?(DateTimeOffset.UtcNow)));
					_003CpreviousHourlyCrystals_003E5__24 = (_003ChourlyWindowActive_003E5__21 ? CollectionExtensions.GetValueOrDefault<string, int>((IReadOnlyDictionary<string, int>)(object)_003Cprogress_003E5__3.PlayerHourlyCrystals, request.AttackingPlayerId, 0) : 0);
					_003CnewHourlyCrystals_003E5__25 = _003CpreviousHourlyCrystals_003E5__24 + _003CcrystalsAwarded_003E5__18;
					_003CrecoveryReduction_003E5__26 = (_003CdefendingGuild_003E5__10?.GetActivePerk(GuildPerkType.SwiftRecovery)?.GetEffectValue()).GetValueOrDefault();
					_003CdowntimeMinutes_003E5__27 = Math.Max(1, (int)(30.0 - _003CrecoveryReduction_003E5__26));
					utcNow = DateTimeOffset.UtcNow;
					_003CdowntimeEnds_003E5__28 = ((DateTimeOffset)(ref utcNow)).AddMinutes((double)_003CdowntimeMinutes_003E5__27);
					guildWarProgress = _003Cprogress_003E5__3;
					_003CcurrentDefeatedCount_003E5__29 = ((guildWarProgress != null && guildWarProgress.DefeatedDefenders.TryGetValue(request.DefenderPlayerId, ref _003Crec_003E5__30)) ? _003Crec_003E5__30.DefeatCount : 0);
					awaiter2 = _003C_003E4__this._guildWarRepository.WriteDefenderBattleResultAsync(request.AttackingGuildId, request.DefendingGuildId, request.WarId, isVictory: true, _003CstartingCrystals_003E5__4, request.DefenderPlayerId, request.AttackingPlayerId, _003CcrystalsAwarded_003E5__18, _003CattackerHourlyStart_003E5__22, _003CnewHourlyCrystals_003E5__25, _003CcurrentDefeatedCount_003E5__29 + 1, _003CdowntimeEnds_003E5__28, DateTimeOffset.UtcNow, 0).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__4 = awaiter2;
						_003CExecuteAsync_003Ed__5 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__5>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_0753;
					IL_02d4:
					_003CcurrentCrystals_003E5__5 = _003Cprogress_003E5__3?.CurrentCrystals ?? Math.Max(0, _003CstartingCrystals_003E5__4);
					if (request.Victory)
					{
						awaiter3 = _003C_003E4__this._guildRepository.GetByIdAsync(request.DefendingGuildId).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__3 = awaiter3;
							_003CExecuteAsync_003Ed__5 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CExecuteAsync_003Ed__5>(ref awaiter3, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_037c;
					}
					_003Crandom_003E5__32 = new Random();
					_003CdefenseReward_003E5__33 = Math.Max(1, (int)((double)_003CcurrentCrystals_003E5__5 * (_003Crandom_003E5__32.NextDouble() * 0.020000000000000004 + 0.03)));
					guildWarProgress2 = _003Cprogress_003E5__3;
					_003CcurrentDefeatedCount_003E5__34 = ((guildWarProgress2 != null && guildWarProgress2.DefeatedDefenders.TryGetValue(request.DefenderPlayerId, ref _003Crec_003E5__35)) ? _003Crec_003E5__35.DefeatCount : 0);
					guildWarProgress3 = _003Cprogress_003E5__3;
					_003CexistingDowntime_003E5__36 = ((guildWarProgress3 != null && guildWarProgress3.DefeatedDefenders.TryGetValue(request.DefenderPlayerId, ref _003Cr2_003E5__37)) ? _003Cr2_003E5__37.DowntimeEnds : DateTimeOffset.MinValue);
					awaiter = _003C_003E4__this._guildWarRepository.WriteDefenderBattleResultAsync(request.AttackingGuildId, request.DefendingGuildId, request.WarId, isVictory: false, _003CstartingCrystals_003E5__4, request.DefenderPlayerId, null, 0, null, 0, _003CcurrentDefeatedCount_003E5__34, _003CexistingDowntime_003E5__36, null, _003CdefenseReward_003E5__33).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 5);
						_003C_003Eu__4 = awaiter;
						_003CExecuteAsync_003Ed__5 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__5>(ref awaiter, ref _003CExecuteAsync_003Ed__);
						return;
					}
					break;
					IL_028f:
					_003C_003Es__9 = awaiter4.GetResult();
					_003CdefendingGuild_003E5__8 = _003C_003Es__9;
					_003C_003Es__9 = null;
					_003CstartingCrystals_003E5__4 = GuildConfiguration.GetStartingCrystals(_003CdefendingGuild_003E5__8?.Level ?? 1);
					_003CdefendingGuild_003E5__8 = null;
					goto IL_02d4;
					IL_0753:
					awaiter2.GetResult();
					result = Result<ProcessWarBattleResultData>.SuccessResult(new ProcessWarBattleResultData(_003CcrystalsAwarded_003E5__18, _003CwasCapped_003E5__19, _003CcompleteBattleResult_003E5__1.Data));
					goto end_IL_0007;
				}
				awaiter.GetResult();
				result = Result<ProcessWarBattleResultData>.SuccessResult(new ProcessWarBattleResultData(0, WasCapped: false, _003CcompleteBattleResult_003E5__1.Data));
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CcompleteBattleResult_003E5__1 = null;
				_003CtaskTypes_003E5__2 = null;
				_003Cprogress_003E5__3 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CcompleteBattleResult_003E5__1 = null;
			_003CtaskTypes_003E5__2 = null;
			_003Cprogress_003E5__3 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IGuildWarRepository _guildWarRepository;

	private readonly IGuildRepository _guildRepository;

	private readonly CompleteBattleUseCase _completeBattleUseCase;

	private readonly UpdateBattleTaskProgressUseCase _updateBattleTaskProgressUseCase;

	public ProcessWarBattleResultUseCase(IGuildWarRepository guildWarRepository, IGuildRepository guildRepository, CompleteBattleUseCase completeBattleUseCase, UpdateBattleTaskProgressUseCase updateBattleTaskProgressUseCase)
	{
		_guildWarRepository = guildWarRepository;
		_guildRepository = guildRepository;
		_completeBattleUseCase = completeBattleUseCase;
		_updateBattleTaskProgressUseCase = updateBattleTaskProgressUseCase;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__5))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<ProcessWarBattleResultData>> ExecuteAsync(ProcessWarBattleResultRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Result<BattleRewards> completeBattleResult = await _completeBattleUseCase.ExecuteAsync(new CompleteBattleRequest(request.OpponentLevel, request.Victory, IsPvP: true, request.LivingSpiritsCount, request.TotalHealthPercentage, request.PreCommittedScorePenalty));
		BattleTaskType[] taskTypes = ((!request.Victory) ? new BattleTaskType[1] : new BattleTaskType[3]
		{
			BattleTaskType.CompleteBattle,
			BattleTaskType.WinBattle,
			BattleTaskType.AttackWarDefender
		});
		_updateBattleTaskProgressUseCase.ExecuteAsync(new UpdateBattleTaskProgressRequest(taskTypes));
		GuildWarProgress progress = await _guildWarRepository.GetWarProgressAsync(request.AttackingGuildId, request.DefendingGuildId, request.WarId);
		int startingCrystals = progress?.StartingCrystals ?? 0;
		if (startingCrystals == 0)
		{
			startingCrystals = GuildConfiguration.GetStartingCrystals((await _guildRepository.GetByIdAsync(request.DefendingGuildId))?.Level ?? 1);
		}
		int currentCrystals = progress?.CurrentCrystals ?? Math.Max(0, startingCrystals);
		if (request.Victory)
		{
			Guild defendingGuild = await _guildRepository.GetByIdAsync(request.DefendingGuildId);
			Random random2 = new Random();
			double pct = random2.NextDouble() * 0.03 + 0.05;
			double defenderMult = 1.0 + (double)request.DefenderLevel / 100.0;
			double protectionMult = progress?.ProtectionMultiplier ?? 1.0;
			double raw2 = (double)currentCrystals * pct * defenderMult * protectionMult;
			double shieldReduction = (defendingGuild?.GetActivePerk(GuildPerkType.CrystalShield)?.GetEffectValue()).GetValueOrDefault();
			raw2 *= 1.0 - shieldReduction;
			double cap = (double)currentCrystals * 0.15;
			int crystalsAwarded2 = (int)Math.Min(raw2, cap);
			bool wasCapped = crystalsAwarded2 < (int)raw2;
			int budgetRemaining = progress?.HourlyBudgetRemaining(request.AttackingPlayerId) ?? 500;
			crystalsAwarded2 = Math.Min(crystalsAwarded2, budgetRemaining);
			bool hourlyWindowActive = progress?.IsHourlyWindowActive(request.AttackingPlayerId) ?? false;
			DateTimeOffset? s = default(DateTimeOffset?);
			DateTimeOffset? attackerHourlyStart = ((!hourlyWindowActive) ? new DateTimeOffset?(DateTimeOffset.UtcNow) : (progress.PlayerHourlyStarts.TryGetValue(request.AttackingPlayerId, ref s) ? s : new DateTimeOffset?(DateTimeOffset.UtcNow)));
			int previousHourlyCrystals = (hourlyWindowActive ? CollectionExtensions.GetValueOrDefault<string, int>((IReadOnlyDictionary<string, int>)(object)progress.PlayerHourlyCrystals, request.AttackingPlayerId, 0) : 0);
			int newHourlyCrystals = previousHourlyCrystals + crystalsAwarded2;
			double recoveryReduction = (defendingGuild?.GetActivePerk(GuildPerkType.SwiftRecovery)?.GetEffectValue()).GetValueOrDefault();
			int downtimeMinutes = Math.Max(1, (int)(30.0 - recoveryReduction));
			DateTimeOffset utcNow = DateTimeOffset.UtcNow;
			DateTimeOffset downtimeEnds = ((DateTimeOffset)(ref utcNow)).AddMinutes((double)downtimeMinutes);
			DefenderWarRecord rec = default(DefenderWarRecord);
			int currentDefeatedCount = ((progress?.DefeatedDefenders.TryGetValue(request.DefenderPlayerId, ref rec) ?? false) ? rec.DefeatCount : 0);
			await _guildWarRepository.WriteDefenderBattleResultAsync(request.AttackingGuildId, request.DefendingGuildId, request.WarId, isVictory: true, startingCrystals, request.DefenderPlayerId, request.AttackingPlayerId, crystalsAwarded2, attackerHourlyStart, newHourlyCrystals, currentDefeatedCount + 1, downtimeEnds, DateTimeOffset.UtcNow, 0);
			return Result<ProcessWarBattleResultData>.SuccessResult(new ProcessWarBattleResultData(crystalsAwarded2, wasCapped, completeBattleResult.Data));
		}
		Random random = new Random();
		int defenseReward = Math.Max(1, (int)((double)currentCrystals * (random.NextDouble() * 0.020000000000000004 + 0.03)));
		DefenderWarRecord rec2 = default(DefenderWarRecord);
		int currentDefeatedCount2 = ((progress?.DefeatedDefenders.TryGetValue(request.DefenderPlayerId, ref rec2) ?? false) ? rec2.DefeatCount : 0);
		DefenderWarRecord r2 = default(DefenderWarRecord);
		DateTimeOffset existingDowntime = ((progress?.DefeatedDefenders.TryGetValue(request.DefenderPlayerId, ref r2) ?? false) ? r2.DowntimeEnds : DateTimeOffset.MinValue);
		await _guildWarRepository.WriteDefenderBattleResultAsync(request.AttackingGuildId, request.DefendingGuildId, request.WarId, isVictory: false, startingCrystals, request.DefenderPlayerId, null, 0, null, 0, currentDefeatedCount2, existingDowntime, null, defenseReward);
		return Result<ProcessWarBattleResultData>.SuccessResult(new ProcessWarBattleResultData(0, WasCapped: false, completeBattleResult.Data));
	}
}
