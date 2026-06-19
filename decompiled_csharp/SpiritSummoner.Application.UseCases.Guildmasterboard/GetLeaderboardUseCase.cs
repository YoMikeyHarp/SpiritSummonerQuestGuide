using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.DTOs.Guildmasterboard;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Domain.Services;

namespace SpiritSummoner.Application.UseCases.Guildmasterboard;

public class GetLeaderboardUseCase : IUseCase<GetLeaderboardRequest, LeaderboardDataDTO>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public GetLeaderboardRequest request;

		public GetLeaderboardUseCase _003C_003E4__this;

		internal LeaderboardEntryDTO _003CExecuteAsync_003Eb__0(LeaderboardEntry entry, int index)
		{
			return MapToDTO(entry, index + 1, request.CurrentPlayerId, _003C_003E4__this._battleScoreCalculator);
		}

		internal LeaderboardEntryDTO _003CExecuteAsync_003Eb__1(LeaderboardEntry entry, int index)
		{
			return MapToDTO(entry, 3 + index + 1, request.CurrentPlayerId, _003C_003E4__this._battleScoreCalculator);
		}

		internal LeaderboardEntryDTO _003CExecuteAsync_003Eb__2(LeaderboardEntry entry, int index)
		{
			return MapToDTO(entry, index + 1, request.CurrentPlayerId, _003C_003E4__this._battleScoreCalculator);
		}

		internal bool _003CExecuteAsync_003Eb__3(LeaderboardEntry e)
		{
			return e.PlayerId == request.CurrentPlayerId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_1
	{
		public int nearbyStartRank;

		public _003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals1;

		internal LeaderboardEntryDTO _003CExecuteAsync_003Eb__4(LeaderboardEntry entry, int index)
		{
			return MapToDTO(entry, Math.Max(1, nearbyStartRank + index), CS_0024_003C_003E8__locals1.request.CurrentPlayerId, CS_0024_003C_003E8__locals1._003C_003E4__this._battleScoreCalculator);
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__6 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<LeaderboardDataDTO>> _003C_003Et__builder;

		public GetLeaderboardRequest request;

		public GetLeaderboardUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass6_0 _003C_003E8__1;

		private LeaderboardEntry _003CcurrentPlayerEntry_003E5__2;

		private int _003CplayerRank_003E5__3;

		private List<LeaderboardEntryDTO> _003CtopPlayers_003E5__4;

		private List<LeaderboardEntryDTO> _003CnearbyPlayers_003E5__5;

		private bool _003CisUnranked_003E5__6;

		private LeaderboardDataDTO _003Cresult_003E5__7;

		private LeaderboardEntry _003C_003Es__8;

		private int _003C_003Es__9;

		private List<LeaderboardEntry> _003Ctop_003E5__10;

		private List<LeaderboardEntry> _003C_003Es__11;

		private _003C_003Ec__DisplayClass6_1 _003C_003E8__12;

		private List<LeaderboardEntry> _003Ctop_003E5__13;

		private int _003CnearbyCount_003E5__14;

		private int _003CrangeAbove_003E5__15;

		private int _003CrangeBelow_003E5__16;

		private List<LeaderboardEntry> _003Cnearby_003E5__17;

		private int _003Cdeficit_003E5__18;

		private int _003CactualRangeAbove_003E5__19;

		private List<LeaderboardEntry> _003C_003Es__20;

		private List<LeaderboardEntry> _003C_003Es__21;

		private List<LeaderboardEntry> _003Cextended_003E5__22;

		private List<LeaderboardEntry> _003C_003Es__23;

		private global::System.Exception _003Cex_003E5__24;

		private TaskAwaiter<LeaderboardEntry?> _003C_003Eu__1;

		private TaskAwaiter<int> _003C_003Eu__2;

		private TaskAwaiter<List<LeaderboardEntry>> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0266: Unknown result type (might be due to invalid IL or missing references)
			//IL_026b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0273: Unknown result type (might be due to invalid IL or missing references)
			//IL_0370: Unknown result type (might be due to invalid IL or missing references)
			//IL_0375: Unknown result type (might be due to invalid IL or missing references)
			//IL_037d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0465: Unknown result type (might be due to invalid IL or missing references)
			//IL_046a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0472: Unknown result type (might be due to invalid IL or missing references)
			//IL_0555: Unknown result type (might be due to invalid IL or missing references)
			//IL_055a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0562: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_042c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0431: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_069a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0446: Unknown result type (might be due to invalid IL or missing references)
			//IL_0448: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Unknown result type (might be due to invalid IL or missing references)
			//IL_0337: Unknown result type (might be due to invalid IL or missing references)
			//IL_033c: Unknown result type (might be due to invalid IL or missing references)
			//IL_022d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0232: Unknown result type (might be due to invalid IL or missing references)
			//IL_051c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0521: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0351: Unknown result type (might be due to invalid IL or missing references)
			//IL_0353: Unknown result type (might be due to invalid IL or missing references)
			//IL_0247: Unknown result type (might be due to invalid IL or missing references)
			//IL_0249: Unknown result type (might be due to invalid IL or missing references)
			//IL_0536: Unknown result type (might be due to invalid IL or missing references)
			//IL_0538: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<LeaderboardDataDTO> result;
			try
			{
				if ((uint)num > 5u)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass6_0();
					_003C_003E8__1.request = request;
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
				}
				try
				{
					TaskAwaiter<LeaderboardEntry> awaiter6;
					TaskAwaiter<int> awaiter5;
					TaskAwaiter<List<LeaderboardEntry>> awaiter4;
					TaskAwaiter<List<LeaderboardEntry>> awaiter3;
					TaskAwaiter<List<LeaderboardEntry>> awaiter2;
					TaskAwaiter<List<LeaderboardEntry>> awaiter;
					switch (num)
					{
					default:
						awaiter6 = _003C_003E4__this._leaderboardRepository.GetPlayerEntryAsync(_003C_003E8__1.request.CurrentPlayerId).GetAwaiter();
						if (!awaiter6.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter6;
							_003CExecuteAsync_003Ed__6 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<LeaderboardEntry>, _003CExecuteAsync_003Ed__6>(ref awaiter6, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_00ec;
					case 0:
						awaiter6 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<LeaderboardEntry>);
						num = (_003C_003E1__state = -1);
						goto IL_00ec;
					case 1:
						awaiter5 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<int>);
						num = (_003C_003E1__state = -1);
						goto IL_01d3;
					case 2:
						awaiter4 = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter<List<LeaderboardEntry>>);
						num = (_003C_003E1__state = -1);
						goto IL_0282;
					case 3:
						awaiter3 = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter<List<LeaderboardEntry>>);
						num = (_003C_003E1__state = -1);
						goto IL_038c;
					case 4:
						awaiter2 = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter<List<LeaderboardEntry>>);
						num = (_003C_003E1__state = -1);
						goto IL_0481;
					case 5:
						{
							awaiter = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<List<LeaderboardEntry>>);
							num = (_003C_003E1__state = -1);
							goto IL_0571;
						}
						IL_0571:
						_003C_003Es__23 = awaiter.GetResult();
						_003Cextended_003E5__22 = _003C_003Es__23;
						_003C_003Es__23 = null;
						_003Cnearby_003E5__17 = _003Cextended_003E5__22;
						_003Cextended_003E5__22 = null;
						goto IL_05a5;
						IL_00ec:
						_003C_003Es__8 = awaiter6.GetResult();
						_003CcurrentPlayerEntry_003E5__2 = _003C_003Es__8;
						_003C_003Es__8 = null;
						if (_003CcurrentPlayerEntry_003E5__2 != null || _003C_003E4__this._playerStateService.GetCurrentPlayer() != null)
						{
							_003CcurrentPlayerEntry_003E5__2 = LeaderboardEntry.FromPlayer(_003C_003E4__this._playerStateService.GetCurrentPlayer());
							awaiter5 = _003C_003E4__this._leaderboardRepository.GetPlayerRankAsync(_003C_003E8__1.request.CurrentPlayerId).GetAwaiter();
							if (!awaiter5.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter5;
								_003CExecuteAsync_003Ed__6 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<int>, _003CExecuteAsync_003Ed__6>(ref awaiter5, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_01d3;
						}
						result = Result<LeaderboardDataDTO>.FailureResult("Player not found in leaderboard");
						goto end_IL_003e;
						IL_0481:
						_003C_003Es__21 = awaiter2.GetResult();
						_003Cnearby_003E5__17 = _003C_003Es__21;
						_003C_003Es__21 = null;
						_003Cdeficit_003E5__18 = _003CnearbyCount_003E5__14 - _003Cnearby_003E5__17.Count;
						if (_003Cdeficit_003E5__18 > 0 && _003CrangeAbove_003E5__15 + _003Cdeficit_003E5__18 > _003CrangeAbove_003E5__15)
						{
							awaiter = _003C_003E4__this._leaderboardRepository.GetPlayersAroundRankAsync(_003C_003E8__12.CS_0024_003C_003E8__locals1.request.CurrentPlayerId, _003CrangeAbove_003E5__15 + _003Cdeficit_003E5__18, _003CrangeBelow_003E5__16).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 5);
								_003C_003Eu__3 = awaiter;
								_003CExecuteAsync_003Ed__6 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<LeaderboardEntry>>, _003CExecuteAsync_003Ed__6>(ref awaiter, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_0571;
						}
						goto IL_05a5;
						IL_038c:
						_003C_003Es__20 = awaiter3.GetResult();
						_003Ctop_003E5__13 = _003C_003Es__20;
						_003C_003Es__20 = null;
						_003CtopPlayers_003E5__4 = Enumerable.ToList<LeaderboardEntryDTO>(Enumerable.Select<LeaderboardEntry, LeaderboardEntryDTO>((global::System.Collections.Generic.IEnumerable<LeaderboardEntry>)_003Ctop_003E5__13, (Func<LeaderboardEntry, int, LeaderboardEntryDTO>)((LeaderboardEntry entry, int index) => MapToDTO(entry, index + 1, _003C_003E8__12.CS_0024_003C_003E8__locals1.request.CurrentPlayerId, _003C_003E8__12.CS_0024_003C_003E8__locals1._003C_003E4__this._battleScoreCalculator))));
						_003CnearbyCount_003E5__14 = 5;
						_003CrangeAbove_003E5__15 = 2;
						_003CrangeBelow_003E5__16 = _003CnearbyCount_003E5__14 - 1 - _003CrangeAbove_003E5__15;
						awaiter2 = _003C_003E4__this._leaderboardRepository.GetPlayersAroundRankAsync(_003C_003E8__12.CS_0024_003C_003E8__locals1.request.CurrentPlayerId, _003CrangeAbove_003E5__15, _003CrangeBelow_003E5__16).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 4);
							_003C_003Eu__3 = awaiter2;
							_003CExecuteAsync_003Ed__6 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<LeaderboardEntry>>, _003CExecuteAsync_003Ed__6>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_0481;
						IL_0282:
						_003C_003Es__11 = awaiter4.GetResult();
						_003Ctop_003E5__10 = _003C_003Es__11;
						_003C_003Es__11 = null;
						_003CtopPlayers_003E5__4 = Enumerable.ToList<LeaderboardEntryDTO>(Enumerable.Select<LeaderboardEntry, LeaderboardEntryDTO>(Enumerable.Take<LeaderboardEntry>((global::System.Collections.Generic.IEnumerable<LeaderboardEntry>)_003Ctop_003E5__10, 3), (Func<LeaderboardEntry, int, LeaderboardEntryDTO>)((LeaderboardEntry entry, int index) => MapToDTO(entry, index + 1, _003C_003E8__1.request.CurrentPlayerId, _003C_003E8__1._003C_003E4__this._battleScoreCalculator))));
						_003CnearbyPlayers_003E5__5 = Enumerable.ToList<LeaderboardEntryDTO>(Enumerable.Select<LeaderboardEntry, LeaderboardEntryDTO>(Enumerable.Skip<LeaderboardEntry>((global::System.Collections.Generic.IEnumerable<LeaderboardEntry>)_003Ctop_003E5__10, 3), (Func<LeaderboardEntry, int, LeaderboardEntryDTO>)((LeaderboardEntry entry, int index) => MapToDTO(entry, 3 + index + 1, _003C_003E8__1.request.CurrentPlayerId, _003C_003E8__1._003C_003E4__this._battleScoreCalculator))));
						_003Ctop_003E5__10 = null;
						break;
						IL_05a5:
						_003CactualRangeAbove_003E5__19 = _003Cnearby_003E5__17.FindIndex((Predicate<LeaderboardEntry>)((LeaderboardEntry e) => e.PlayerId == _003C_003E8__12.CS_0024_003C_003E8__locals1.request.CurrentPlayerId));
						_003C_003E8__12.nearbyStartRank = ((_003CactualRangeAbove_003E5__19 >= 0) ? (_003CplayerRank_003E5__3 - _003CactualRangeAbove_003E5__19) : (_003CplayerRank_003E5__3 - _003CrangeAbove_003E5__15));
						_003CnearbyPlayers_003E5__5 = Enumerable.ToList<LeaderboardEntryDTO>(Enumerable.Select<LeaderboardEntry, LeaderboardEntryDTO>((global::System.Collections.Generic.IEnumerable<LeaderboardEntry>)_003Cnearby_003E5__17, (Func<LeaderboardEntry, int, LeaderboardEntryDTO>)((LeaderboardEntry entry, int index) => MapToDTO(entry, Math.Max(1, _003C_003E8__12.nearbyStartRank + index), _003C_003E8__12.CS_0024_003C_003E8__locals1.request.CurrentPlayerId, _003C_003E8__12.CS_0024_003C_003E8__locals1._003C_003E4__this._battleScoreCalculator))));
						_003C_003E8__12 = null;
						_003Ctop_003E5__13 = null;
						_003Cnearby_003E5__17 = null;
						break;
						IL_01d3:
						_003C_003Es__9 = awaiter5.GetResult();
						_003CplayerRank_003E5__3 = _003C_003Es__9;
						_003CisUnranked_003E5__6 = _003CplayerRank_003E5__3 == 0;
						if (_003CisUnranked_003E5__6 || _003CplayerRank_003E5__3 <= 3)
						{
							awaiter4 = _003C_003E4__this._leaderboardRepository.GetTopPlayersAsync(8).GetAwaiter();
							if (!awaiter4.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter4;
								_003CExecuteAsync_003Ed__6 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<LeaderboardEntry>>, _003CExecuteAsync_003Ed__6>(ref awaiter4, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_0282;
						}
						_003C_003E8__12 = new _003C_003Ec__DisplayClass6_1();
						_003C_003E8__12.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
						awaiter3 = _003C_003E4__this._leaderboardRepository.GetTopPlayersAsync(3).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__3 = awaiter3;
							_003CExecuteAsync_003Ed__6 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<LeaderboardEntry>>, _003CExecuteAsync_003Ed__6>(ref awaiter3, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_038c;
					}
					_003Cresult_003E5__7 = new LeaderboardDataDTO
					{
						TopPlayers = _003CtopPlayers_003E5__4,
						NearbyPlayers = _003CnearbyPlayers_003E5__5,
						CurrentPlayer = MapToDTO(_003CcurrentPlayerEntry_003E5__2, _003CplayerRank_003E5__3, _003C_003E8__1.request.CurrentPlayerId, _003C_003E4__this._battleScoreCalculator),
						IsPlayerUnranked = _003CisUnranked_003E5__6,
						LastRefreshed = DateTimeOffset.UtcNow
					};
					result = Result<LeaderboardDataDTO>.SuccessResult(_003Cresult_003E5__7);
					end_IL_003e:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__24 = ex;
					result = Result<LeaderboardDataDTO>.FailureResult("Failed to fetch leaderboard: " + _003Cex_003E5__24.Message);
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

	private const int TotalPlayersToFetch = 8;

	private const int TopPlayersCount = 3;

	private readonly ILeaderboardRepository _leaderboardRepository;

	private readonly IBattleScoreCalculator _battleScoreCalculator;

	private readonly IPlayerStateService _playerStateService;

	public GetLeaderboardUseCase(ILeaderboardRepository leaderboardRepository, IBattleScoreCalculator battleScoreCalculator, IPlayerStateService playerStateService)
	{
		_leaderboardRepository = leaderboardRepository;
		_battleScoreCalculator = battleScoreCalculator;
		_playerStateService = playerStateService;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__6))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<LeaderboardDataDTO>> ExecuteAsync(GetLeaderboardRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		GetLeaderboardRequest request2 = request;
		try
		{
			if (await _leaderboardRepository.GetPlayerEntryAsync(request2.CurrentPlayerId) == null && _playerStateService.GetCurrentPlayer() == null)
			{
				return Result<LeaderboardDataDTO>.FailureResult("Player not found in leaderboard");
			}
			LeaderboardEntry currentPlayerEntry = LeaderboardEntry.FromPlayer(_playerStateService.GetCurrentPlayer());
			int playerRank = await _leaderboardRepository.GetPlayerRankAsync(request2.CurrentPlayerId);
			bool isUnranked = playerRank == 0;
			List<LeaderboardEntryDTO> topPlayers;
			List<LeaderboardEntryDTO> nearbyPlayers;
			if (isUnranked || playerRank <= 3)
			{
				List<LeaderboardEntry> top = await _leaderboardRepository.GetTopPlayersAsync(8);
				topPlayers = Enumerable.ToList<LeaderboardEntryDTO>(Enumerable.Select<LeaderboardEntry, LeaderboardEntryDTO>(Enumerable.Take<LeaderboardEntry>((global::System.Collections.Generic.IEnumerable<LeaderboardEntry>)top, 3), (Func<LeaderboardEntry, int, LeaderboardEntryDTO>)((LeaderboardEntry entry, int index) => MapToDTO(entry, index + 1, request2.CurrentPlayerId, _battleScoreCalculator))));
				nearbyPlayers = Enumerable.ToList<LeaderboardEntryDTO>(Enumerable.Select<LeaderboardEntry, LeaderboardEntryDTO>(Enumerable.Skip<LeaderboardEntry>((global::System.Collections.Generic.IEnumerable<LeaderboardEntry>)top, 3), (Func<LeaderboardEntry, int, LeaderboardEntryDTO>)((LeaderboardEntry entry, int index) => MapToDTO(entry, 3 + index + 1, request2.CurrentPlayerId, _battleScoreCalculator))));
			}
			else
			{
				topPlayers = Enumerable.ToList<LeaderboardEntryDTO>(Enumerable.Select<LeaderboardEntry, LeaderboardEntryDTO>((global::System.Collections.Generic.IEnumerable<LeaderboardEntry>)(await _leaderboardRepository.GetTopPlayersAsync(3)), (Func<LeaderboardEntry, int, LeaderboardEntryDTO>)((LeaderboardEntry entry, int index) => MapToDTO(entry, index + 1, request2.CurrentPlayerId, _battleScoreCalculator))));
				int nearbyCount = 5;
				int rangeAbove = 2;
				int rangeBelow = nearbyCount - 1 - rangeAbove;
				List<LeaderboardEntry> nearby = await _leaderboardRepository.GetPlayersAroundRankAsync(request2.CurrentPlayerId, rangeAbove, rangeBelow);
				int deficit = nearbyCount - nearby.Count;
				if (deficit > 0 && rangeAbove + deficit > rangeAbove)
				{
					nearby = await _leaderboardRepository.GetPlayersAroundRankAsync(request2.CurrentPlayerId, rangeAbove + deficit, rangeBelow);
				}
				int actualRangeAbove = nearby.FindIndex((Predicate<LeaderboardEntry>)((LeaderboardEntry e) => e.PlayerId == request2.CurrentPlayerId));
				int nearbyStartRank = ((actualRangeAbove >= 0) ? (playerRank - actualRangeAbove) : (playerRank - rangeAbove));
				nearbyPlayers = Enumerable.ToList<LeaderboardEntryDTO>(Enumerable.Select<LeaderboardEntry, LeaderboardEntryDTO>((global::System.Collections.Generic.IEnumerable<LeaderboardEntry>)nearby, (Func<LeaderboardEntry, int, LeaderboardEntryDTO>)((LeaderboardEntry entry, int index) => MapToDTO(entry, Math.Max(1, nearbyStartRank + index), request2.CurrentPlayerId, _battleScoreCalculator))));
			}
			LeaderboardDataDTO result = new LeaderboardDataDTO
			{
				TopPlayers = topPlayers,
				NearbyPlayers = nearbyPlayers,
				CurrentPlayer = MapToDTO(currentPlayerEntry, playerRank, request2.CurrentPlayerId, _battleScoreCalculator),
				IsPlayerUnranked = isUnranked,
				LastRefreshed = DateTimeOffset.UtcNow
			};
			return Result<LeaderboardDataDTO>.SuccessResult(result);
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			return Result<LeaderboardDataDTO>.FailureResult("Failed to fetch leaderboard: " + ex.Message);
		}
	}

	private static LeaderboardEntryDTO MapToDTO(LeaderboardEntry entry, int rank, string currentPlayerId, IBattleScoreCalculator scoreCalculator)
	{
		return new LeaderboardEntryDTO
		{
			PlayerId = entry.PlayerId,
			PlayerName = entry.PlayerName,
			PlayerLevel = entry.PlayerLevel,
			Score = entry.Score,
			Rank = rank,
			Title = scoreCalculator.GetTitle(entry.Score, rank),
			Wins = entry.Wins,
			Losses = entry.Losses,
			IsCurrentPlayer = (entry.PlayerId == currentPlayerId)
		};
	}
}
