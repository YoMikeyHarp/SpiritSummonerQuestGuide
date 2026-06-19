using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Battles;

public class GetWarContributionSummaryUseCase : IUseCase<GetWarContributionSummaryRequest, WarContributionSummary>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<WarContributionSummary>> _003C_003Et__builder;

		public GetWarContributionSummaryRequest request;

		public GetWarContributionSummaryUseCase _003C_003E4__this;

		private Player _003Cplayer_003E5__1;

		private Guild _003Cguild_003E5__2;

		private string _003CplayerId_003E5__3;

		private string _003CwarId_003E5__4;

		private string _003CguildId_003E5__5;

		private List<Guild> _003Copponents_003E5__6;

		private int _003CattackCount_003E5__7;

		private int _003CraidCount_003E5__8;

		private int _003CcrystalsFromAttacks_003E5__9;

		private int _003CcrystalsFromRaids_003E5__10;

		private double _003CattackScore_003E5__11;

		private double _003CdefenseScore_003E5__12;

		private double _003CestimatedWarScore_003E5__13;

		private long _003CestimatedGuildCoins_003E5__14;

		private WarContributionSummary _003Csummary_003E5__15;

		private List<Guild> _003C_003Es__16;

		private Enumerator<Guild> _003C_003Es__17;

		private Guild _003Copponent_003E5__18;

		private GuildWarProgress _003Cprogress_003E5__19;

		private GuildWarProgress _003C_003Es__20;

		private TaskAwaiter<List<Guild>> _003C_003Eu__1;

		private TaskAwaiter<GuildWarProgress?> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_021b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_032e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<WarContributionSummary> result;
			try
			{
				TaskAwaiter<List<Guild>> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<List<Guild>>);
					num = (_003C_003E1__state = -1);
					goto IL_013f;
				}
				if (num == 1)
				{
					goto IL_018e;
				}
				_003Cplayer_003E5__1 = _003C_003E4__this._playerState.GetCurrentPlayer();
				if (_003Cplayer_003E5__1 == null)
				{
					result = Result<WarContributionSummary>.FailureResult("No player session");
				}
				else
				{
					_003Cguild_003E5__2 = _003C_003E4__this._guildState.GetCurrentGuild();
					if (_003Cguild_003E5__2 != null && _003Cguild_003E5__2.HasActiveWarSeason && _003Cguild_003E5__2.IsInWarSeason)
					{
						_003CplayerId_003E5__3 = _003Cplayer_003E5__1.PlayerID;
						_003CwarId_003E5__4 = _003Cguild_003E5__2.CurrentWarId;
						_003CguildId_003E5__5 = _003Cguild_003E5__2.ID;
						awaiter = _003C_003E4__this._warRepository.GetWarBucketOpponentsAsync(_003CguildId_003E5__5).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<Guild>>, _003CExecuteAsync_003Ed__4>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_013f;
					}
					result = Result<WarContributionSummary>.SuccessResult(WarContributionSummary.NotInWar());
				}
				goto end_IL_0007;
				IL_013f:
				_003C_003Es__16 = awaiter.GetResult();
				_003Copponents_003E5__6 = _003C_003Es__16;
				_003C_003Es__16 = null;
				_003CattackCount_003E5__7 = 0;
				_003CraidCount_003E5__8 = 0;
				_003CcrystalsFromAttacks_003E5__9 = 0;
				_003CcrystalsFromRaids_003E5__10 = 0;
				_003C_003Es__17 = _003Copponents_003E5__6.GetEnumerator();
				goto IL_018e;
				IL_018e:
				try
				{
					if (num != 1)
					{
						goto IL_02ff;
					}
					TaskAwaiter<GuildWarProgress> awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<GuildWarProgress>);
					num = (_003C_003E1__state = -1);
					goto IL_022a;
					IL_022a:
					_003C_003Es__20 = awaiter2.GetResult();
					_003Cprogress_003E5__19 = _003C_003Es__20;
					_003C_003Es__20 = null;
					if (_003Cprogress_003E5__19 != null)
					{
						_003CattackCount_003E5__7 += (int)CollectionExtensions.GetValueOrDefault<string, long>((IReadOnlyDictionary<string, long>)(object)_003Cprogress_003E5__19.PlayerAttackCounts, _003CplayerId_003E5__3, 0L);
						_003CraidCount_003E5__8 += CollectionExtensions.GetValueOrDefault<string, int>((IReadOnlyDictionary<string, int>)(object)_003Cprogress_003E5__19.PlayerRaidCounts, _003CplayerId_003E5__3, 0);
						_003CcrystalsFromAttacks_003E5__9 += CollectionExtensions.GetValueOrDefault<string, int>((IReadOnlyDictionary<string, int>)(object)_003Cprogress_003E5__19.PlayerTotalCrystalsAttack, _003CplayerId_003E5__3, 0);
						_003CcrystalsFromRaids_003E5__10 += CollectionExtensions.GetValueOrDefault<string, int>((IReadOnlyDictionary<string, int>)(object)_003Cprogress_003E5__19.PlayerTotalCrystalsRaid, _003CplayerId_003E5__3, 0);
						_003Cprogress_003E5__19 = null;
						_003Copponent_003E5__18 = null;
					}
					goto IL_02ff;
					IL_02ff:
					if (_003C_003Es__17.MoveNext())
					{
						_003Copponent_003E5__18 = _003C_003Es__17.Current;
						awaiter2 = _003C_003E4__this._warRepository.GetWarProgressAsync(_003CguildId_003E5__5, _003Copponent_003E5__18.ID, _003CwarId_003E5__4).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter2;
							_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<GuildWarProgress>, _003CExecuteAsync_003Ed__4>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_022a;
					}
				}
				finally
				{
					if (num < 0)
					{
						((global::System.IDisposable)_003C_003Es__17).Dispose();
					}
				}
				_003C_003Es__17 = default(Enumerator<Guild>);
				_003CattackScore_003E5__11 = (double)(_003CattackCount_003E5__7 + _003CraidCount_003E5__8 * 2) + (double)_003CcrystalsFromAttacks_003E5__9 / 100.0 + (double)_003CcrystalsFromRaids_003E5__10 / 50.0;
				_003CdefenseScore_003E5__12 = 0.0;
				_003CestimatedWarScore_003E5__13 = _003CattackScore_003E5__11 + _003CdefenseScore_003E5__12;
				_003CestimatedGuildCoins_003E5__14 = (long)Math.Round(_003CestimatedWarScore_003E5__13 * 2.0);
				_003Csummary_003E5__15 = new WarContributionSummary(_003CplayerId_003E5__3, _003CattackCount_003E5__7, _003CraidCount_003E5__8, _003CcrystalsFromAttacks_003E5__9, _003CcrystalsFromRaids_003E5__10, _003CdefenseScore_003E5__12, _003CestimatedWarScore_003E5__13, _003CestimatedGuildCoins_003E5__14, IsWarActive: true);
				result = Result<WarContributionSummary>.SuccessResult(_003Csummary_003E5__15);
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cplayer_003E5__1 = null;
				_003Cguild_003E5__2 = null;
				_003CplayerId_003E5__3 = null;
				_003CwarId_003E5__4 = null;
				_003CguildId_003E5__5 = null;
				_003Copponents_003E5__6 = null;
				_003Csummary_003E5__15 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cplayer_003E5__1 = null;
			_003Cguild_003E5__2 = null;
			_003CplayerId_003E5__3 = null;
			_003CwarId_003E5__4 = null;
			_003CguildId_003E5__5 = null;
			_003Copponents_003E5__6 = null;
			_003Csummary_003E5__15 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IPlayerStateService _playerState;

	private readonly IGuildStateService _guildState;

	private readonly IGuildWarRepository _warRepository;

	public GetWarContributionSummaryUseCase(IPlayerStateService playerState, IGuildStateService guildState, IGuildWarRepository warRepository)
	{
		_playerState = playerState;
		_guildState = guildState;
		_warRepository = warRepository;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__4))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<WarContributionSummary>> ExecuteAsync(GetWarContributionSummaryRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Player player = _playerState.GetCurrentPlayer();
		if (player == null)
		{
			return Result<WarContributionSummary>.FailureResult("No player session");
		}
		Guild guild = _guildState.GetCurrentGuild();
		if (guild == null || !guild.HasActiveWarSeason || !guild.IsInWarSeason)
		{
			return Result<WarContributionSummary>.SuccessResult(WarContributionSummary.NotInWar());
		}
		string playerId = player.PlayerID;
		string warId = guild.CurrentWarId;
		string guildId = guild.ID;
		List<Guild> opponents = await _warRepository.GetWarBucketOpponentsAsync(guildId);
		int attackCount = 0;
		int raidCount = 0;
		int crystalsFromAttacks = 0;
		int crystalsFromRaids = 0;
		Enumerator<Guild> enumerator = opponents.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Guild opponent = enumerator.Current;
				GuildWarProgress progress = await _warRepository.GetWarProgressAsync(guildId, opponent.ID, warId);
				if (progress != null)
				{
					attackCount += (int)CollectionExtensions.GetValueOrDefault<string, long>((IReadOnlyDictionary<string, long>)(object)progress.PlayerAttackCounts, playerId, 0L);
					raidCount += CollectionExtensions.GetValueOrDefault<string, int>((IReadOnlyDictionary<string, int>)(object)progress.PlayerRaidCounts, playerId, 0);
					crystalsFromAttacks += CollectionExtensions.GetValueOrDefault<string, int>((IReadOnlyDictionary<string, int>)(object)progress.PlayerTotalCrystalsAttack, playerId, 0);
					crystalsFromRaids += CollectionExtensions.GetValueOrDefault<string, int>((IReadOnlyDictionary<string, int>)(object)progress.PlayerTotalCrystalsRaid, playerId, 0);
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator).Dispose();
		}
		double attackScore = (double)(attackCount + raidCount * 2) + (double)crystalsFromAttacks / 100.0 + (double)crystalsFromRaids / 50.0;
		double defenseScore = 0.0;
		double estimatedWarScore = attackScore + defenseScore;
		long estimatedGuildCoins = (long)Math.Round(estimatedWarScore * 2.0);
		WarContributionSummary summary = new WarContributionSummary(playerId, attackCount, raidCount, crystalsFromAttacks, crystalsFromRaids, defenseScore, estimatedWarScore, estimatedGuildCoins, IsWarActive: true);
		return Result<WarContributionSummary>.SuccessResult(summary);
	}
}
