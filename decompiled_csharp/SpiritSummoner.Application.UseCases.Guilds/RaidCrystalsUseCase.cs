using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Configuration;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Enums.Guilds;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Guilds;

public class RaidCrystalsUseCase : IUseCase<RaidCrystalsRequest, RaidCrystalsResult>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<RaidCrystalsResult>> _003C_003Et__builder;

		public RaidCrystalsRequest request;

		public RaidCrystalsUseCase _003C_003E4__this;

		private GuildWarProgress _003Cprogress_003E5__1;

		private int _003CstartingCrystals_003E5__2;

		private Guild _003CattackerGuild_003E5__3;

		private double _003CbattleFrenzyBonus_003E5__4;

		private int _003CeffectiveMaxRaids_003E5__5;

		private int _003CraidIndex_003E5__6;

		private int _003CcurrentCrystals_003E5__7;

		private double _003CbaseRaid_003E5__8;

		private double _003CindexMult_003E5__9;

		private double _003Cdecay_003E5__10;

		private double _003Cprotection_003E5__11;

		private double _003Cfatigue_003E5__12;

		private int _003CcrystalsGained_003E5__13;

		private bool _003ChourExpired_003E5__14;

		private int _003CnewRaidCountThisHour_003E5__15;

		private DateTimeOffset _003CnewRaidHourStart_003E5__16;

		private DateTimeOffset? _003Cs_003E5__17;

		private bool _003Csuccess_003E5__18;

		private int _003CraidsRemaining_003E5__19;

		private GuildWarProgress _003C_003Es__20;

		private Guild _003CdefendingGuild_003E5__21;

		private Guild _003C_003Es__22;

		private TimeSpan? _003CtimeUntilReset_003E5__23;

		private bool _003C_003Es__24;

		private TaskAwaiter<GuildWarProgress?> _003C_003Eu__1;

		private TaskAwaiter<Guild?> _003C_003Eu__2;

		private TaskAwaiter<bool> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04be: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0272: Unknown result type (might be due to invalid IL or missing references)
			//IL_041c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0421: Unknown result type (might be due to invalid IL or missing references)
			//IL_0470: Unknown result type (might be due to invalid IL or missing references)
			//IL_0480: Unknown result type (might be due to invalid IL or missing references)
			//IL_0485: Unknown result type (might be due to invalid IL or missing references)
			//IL_0408: Unknown result type (might be due to invalid IL or missing references)
			//IL_049a: Unknown result type (might be due to invalid IL or missing references)
			//IL_049c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0415: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<RaidCrystalsResult> result;
			try
			{
				TaskAwaiter<GuildWarProgress> awaiter3;
				TaskAwaiter<Guild> awaiter2;
				TaskAwaiter<bool> awaiter;
				switch (num)
				{
				default:
					awaiter3 = _003C_003E4__this._guildWarRepository.GetWarProgressAsync(request.AttackingGuildId, request.DefendingGuildId, request.WarId).GetAwaiter();
					if (!awaiter3.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter3;
						_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<GuildWarProgress>, _003CExecuteAsync_003Ed__4>(ref awaiter3, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_00ab;
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<GuildWarProgress>);
					num = (_003C_003E1__state = -1);
					goto IL_00ab;
				case 1:
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<Guild>);
					num = (_003C_003E1__state = -1);
					goto IL_0166;
				case 2:
					{
						awaiter = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_01ab:
					_003CattackerGuild_003E5__3 = _003C_003E4__this._guildStateService.GetCurrentGuild();
					_003CbattleFrenzyBonus_003E5__4 = (_003CattackerGuild_003E5__3?.GetActivePerk(GuildPerkType.BattleFrenzy)?.GetEffectValue()).GetValueOrDefault();
					_003CeffectiveMaxRaids_003E5__5 = 1 + (int)_003CbattleFrenzyBonus_003E5__4;
					_003CraidIndex_003E5__6 = _003Cprogress_003E5__1?.GetEffectiveRaidCount(request.AttackingPlayerId) ?? 0;
					if (_003CraidIndex_003E5__6 < _003CeffectiveMaxRaids_003E5__5)
					{
						_003CcurrentCrystals_003E5__7 = _003Cprogress_003E5__1?.CurrentCrystals ?? _003CstartingCrystals_003E5__2;
						_003CbaseRaid_003E5__8 = (double)_003CcurrentCrystals_003E5__7 * 0.02;
						_003CindexMult_003E5__9 = GuildConfiguration.GetRaidIndexMultiplier(_003CraidIndex_003E5__6);
						_003Cdecay_003E5__10 = 1.0 / (1.0 + (double)_003CraidIndex_003E5__6 * 0.25);
						_003Cprotection_003E5__11 = _003Cprogress_003E5__1?.ProtectionMultiplier ?? 1.0;
						_003Cfatigue_003E5__12 = _003Cprogress_003E5__1?.DefenseFatigueMultiplier ?? 1.0;
						_003CcrystalsGained_003E5__13 = (int)(_003CbaseRaid_003E5__8 * _003CindexMult_003E5__9 * _003Cdecay_003E5__10 * _003Cprotection_003E5__11 * _003Cfatigue_003E5__12);
						_003ChourExpired_003E5__14 = _003Cprogress_003E5__1?.IsPlayerRaidHourExpired(request.AttackingPlayerId) ?? true;
						_003CnewRaidCountThisHour_003E5__15 = _003CraidIndex_003E5__6 + 1;
						_003CnewRaidHourStart_003E5__16 = (_003ChourExpired_003E5__14 ? DateTimeOffset.UtcNow : ((_003Cprogress_003E5__1.PlayerRaidHourStarts.TryGetValue(request.AttackingPlayerId, ref _003Cs_003E5__17) && _003Cs_003E5__17.HasValue) ? _003Cs_003E5__17.Value : DateTimeOffset.UtcNow));
						awaiter = _003C_003E4__this._guildWarRepository.WriteRaidResultAsync(request.DefendingGuildId, request.AttackingGuildId, request.WarId, _003CcrystalsGained_003E5__13, _003CstartingCrystals_003E5__2, request.AttackingPlayerId, _003CnewRaidCountThisHour_003E5__15, _003CnewRaidHourStart_003E5__16, _003CcrystalsGained_003E5__13).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__3 = awaiter;
							_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__4>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
						break;
					}
					_003CtimeUntilReset_003E5__23 = _003Cprogress_003E5__1?.GetTimeUntilRaidReset(request.AttackingPlayerId);
					result = Result<RaidCrystalsResult>.FailureResult($"Max {_003CeffectiveMaxRaids_003E5__5} raids per hour reached");
					goto end_IL_0007;
					IL_00ab:
					_003C_003Es__20 = awaiter3.GetResult();
					_003Cprogress_003E5__1 = _003C_003Es__20;
					_003C_003Es__20 = null;
					_003CstartingCrystals_003E5__2 = _003Cprogress_003E5__1?.StartingCrystals ?? 0;
					if (_003CstartingCrystals_003E5__2 == 0)
					{
						awaiter2 = _003C_003E4__this._guildRepository.GetByIdAsync(request.DefendingGuildId).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter2;
							_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CExecuteAsync_003Ed__4>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_0166;
					}
					goto IL_01ab;
					IL_0166:
					_003C_003Es__22 = awaiter2.GetResult();
					_003CdefendingGuild_003E5__21 = _003C_003Es__22;
					_003C_003Es__22 = null;
					_003CstartingCrystals_003E5__2 = GuildConfiguration.GetStartingCrystals(_003CdefendingGuild_003E5__21?.Level ?? 1);
					_003CdefendingGuild_003E5__21 = null;
					goto IL_01ab;
				}
				_003C_003Es__24 = awaiter.GetResult();
				_003Csuccess_003E5__18 = _003C_003Es__24;
				if (!_003Csuccess_003E5__18)
				{
					result = Result<RaidCrystalsResult>.FailureResult("Raid failed due to an unexpected error");
				}
				else
				{
					_003CraidsRemaining_003E5__19 = _003CeffectiveMaxRaids_003E5__5 - _003CnewRaidCountThisHour_003E5__15;
					result = Result<RaidCrystalsResult>.SuccessResult(new RaidCrystalsResult(_003CcrystalsGained_003E5__13, _003CraidsRemaining_003E5__19, _003CeffectiveMaxRaids_003E5__5));
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cprogress_003E5__1 = null;
				_003CattackerGuild_003E5__3 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cprogress_003E5__1 = null;
			_003CattackerGuild_003E5__3 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IGuildWarRepository _guildWarRepository;

	private readonly IGuildRepository _guildRepository;

	private readonly IGuildStateService _guildStateService;

	public RaidCrystalsUseCase(IGuildWarRepository guildWarRepository, IGuildRepository guildRepository, IGuildStateService guildStateService)
	{
		_guildWarRepository = guildWarRepository;
		_guildRepository = guildRepository;
		_guildStateService = guildStateService;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__4))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<RaidCrystalsResult>> ExecuteAsync(RaidCrystalsRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		GuildWarProgress progress = await _guildWarRepository.GetWarProgressAsync(request.AttackingGuildId, request.DefendingGuildId, request.WarId);
		int startingCrystals = progress?.StartingCrystals ?? 0;
		if (startingCrystals == 0)
		{
			startingCrystals = GuildConfiguration.GetStartingCrystals((await _guildRepository.GetByIdAsync(request.DefendingGuildId))?.Level ?? 1);
		}
		double battleFrenzyBonus = (_guildStateService.GetCurrentGuild()?.GetActivePerk(GuildPerkType.BattleFrenzy)?.GetEffectValue()).GetValueOrDefault();
		int effectiveMaxRaids = 1 + (int)battleFrenzyBonus;
		int raidIndex = progress?.GetEffectiveRaidCount(request.AttackingPlayerId) ?? 0;
		if (raidIndex >= effectiveMaxRaids)
		{
			if (progress != null)
			{
				new TimeSpan?(progress.GetTimeUntilRaidReset(request.AttackingPlayerId));
			}
			return Result<RaidCrystalsResult>.FailureResult($"Max {effectiveMaxRaids} raids per hour reached");
		}
		int currentCrystals = progress?.CurrentCrystals ?? startingCrystals;
		double baseRaid = (double)currentCrystals * 0.02;
		double indexMult = GuildConfiguration.GetRaidIndexMultiplier(raidIndex);
		double decay = 1.0 / (1.0 + (double)raidIndex * 0.25);
		double protection = progress?.ProtectionMultiplier ?? 1.0;
		double fatigue = progress?.DefenseFatigueMultiplier ?? 1.0;
		int crystalsGained = (int)(baseRaid * indexMult * decay * protection * fatigue);
		bool hourExpired = progress?.IsPlayerRaidHourExpired(request.AttackingPlayerId) ?? true;
		int newRaidCountThisHour = raidIndex + 1;
		DateTimeOffset? s = default(DateTimeOffset?);
		DateTimeOffset newRaidHourStart = (hourExpired ? DateTimeOffset.UtcNow : ((progress.PlayerRaidHourStarts.TryGetValue(request.AttackingPlayerId, ref s) && s.HasValue) ? s.Value : DateTimeOffset.UtcNow));
		if (!(await _guildWarRepository.WriteRaidResultAsync(request.DefendingGuildId, request.AttackingGuildId, request.WarId, crystalsGained, startingCrystals, request.AttackingPlayerId, newRaidCountThisHour, newRaidHourStart, crystalsGained)))
		{
			return Result<RaidCrystalsResult>.FailureResult("Raid failed due to an unexpected error");
		}
		int raidsRemaining = effectiveMaxRaids - newRaidCountThisHour;
		return Result<RaidCrystalsResult>.SuccessResult(new RaidCrystalsResult(crystalsGained, raidsRemaining, effectiveMaxRaids));
	}
}
