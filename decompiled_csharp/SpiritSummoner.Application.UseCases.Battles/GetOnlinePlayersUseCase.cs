using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.DTOs.Battles;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Battles;

public class GetOnlinePlayersUseCase : IUseCase<GetOnlinePlayersRequest, List<BattleOpponentDTO>>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public GetOnlinePlayersRequest request;

		internal BattleOpponentDTO _003CExecuteAsync_003Eb__2(Player p)
		{
			return MapToDTO(p, request.TeamSize);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_1
	{
		public HashSet<string> existingIds;

		internal bool _003CExecuteAsync_003Eb__4(LeaderboardEntry e)
		{
			return !existingIds.Contains(e.PlayerId);
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<List<BattleOpponentDTO>>> _003C_003Et__builder;

		public GetOnlinePlayersRequest request;

		public GetOnlinePlayersUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass5_0 _003C_003E8__1;

		private string _003CcurrentPlayerId_003E5__2;

		private int _003CcurrentPlayerLevel_003E5__3;

		private List<Player> _003Cplayers_003E5__4;

		private global::System.Collections.Generic.IEnumerable<Player> _003CvalidPlayers_003E5__5;

		private List<BattleOpponentDTO> _003Copponents_003E5__6;

		private List<Player> _003C_003Es__7;

		private _003C_003Ec__DisplayClass5_1 _003C_003E8__8;

		private List<LeaderboardEntry> _003Cnearby_003E5__9;

		private List<string> _003CfallbackIds_003E5__10;

		private List<LeaderboardEntry> _003C_003Es__11;

		private List<Player> _003CfallbackPlayers_003E5__12;

		private List<Player> _003C_003Es__13;

		private global::System.Exception _003Cex_003E5__14;

		private TaskAwaiter<List<Player>?> _003C_003Eu__1;

		private TaskAwaiter<List<LeaderboardEntry>> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_0212: Unknown result type (might be due to invalid IL or missing references)
			//IL_0217: Unknown result type (might be due to invalid IL or missing references)
			//IL_021f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0331: Unknown result type (might be due to invalid IL or missing references)
			//IL_0336: Unknown result type (might be due to invalid IL or missing references)
			//IL_033e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01de: Unknown result type (might be due to invalid IL or missing references)
			//IL_0312: Unknown result type (might be due to invalid IL or missing references)
			//IL_0314: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<List<BattleOpponentDTO>> result;
			try
			{
				if ((uint)num > 2u)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass5_0();
					_003C_003E8__1.request = request;
				}
				try
				{
					TaskAwaiter<List<Player>> awaiter3;
					TaskAwaiter<List<LeaderboardEntry>> awaiter2;
					TaskAwaiter<List<Player>> awaiter;
					switch (num)
					{
					default:
						_003CcurrentPlayerId_003E5__2 = _003C_003E4__this._playerStateService.CurrentPlayerId;
						_003CcurrentPlayerLevel_003E5__3 = _003C_003E4__this._playerStateService.GetCurrentPlayer()?.PlayerLevel ?? 1;
						awaiter3 = _003C_003E4__this._playerRepository.GetPlayersBattleAsync(_003C_003E8__1.request.TeamSize, _003C_003E8__1.request.Limit, _003CcurrentPlayerId_003E5__2, _003CcurrentPlayerLevel_003E5__3).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CExecuteAsync_003Ed__5 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<Player>>, _003CExecuteAsync_003Ed__5>(ref awaiter3, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_0117;
					case 0:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<List<Player>>);
						num = (_003C_003E1__state = -1);
						goto IL_0117;
					case 1:
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<List<LeaderboardEntry>>);
						num = (_003C_003E1__state = -1);
						goto IL_022e;
					case 2:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<List<Player>>);
							num = (_003C_003E1__state = -1);
							goto IL_034d;
						}
						IL_022e:
						_003C_003Es__11 = awaiter2.GetResult();
						_003Cnearby_003E5__9 = _003C_003Es__11;
						_003C_003Es__11 = null;
						_003CfallbackIds_003E5__10 = Enumerable.ToList<string>(Enumerable.Take<string>(Enumerable.Select<LeaderboardEntry, string>(Enumerable.Where<LeaderboardEntry>((global::System.Collections.Generic.IEnumerable<LeaderboardEntry>)_003Cnearby_003E5__9, (Func<LeaderboardEntry, bool>)((LeaderboardEntry e) => !_003C_003E8__8.existingIds.Contains(e.PlayerId))), (Func<LeaderboardEntry, string>)((LeaderboardEntry e) => e.PlayerId)), _003C_003E8__1.request.Limit - _003Cplayers_003E5__4.Count));
						if (_003CfallbackIds_003E5__10.Count > 0)
						{
							awaiter = _003C_003E4__this._playerRepository.GetPlayersByIdsForBattleAsync(_003CfallbackIds_003E5__10, _003C_003E8__1.request.TeamSize).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__1 = awaiter;
								_003CExecuteAsync_003Ed__5 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<Player>>, _003CExecuteAsync_003Ed__5>(ref awaiter, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_034d;
						}
						goto IL_0387;
						IL_0387:
						_003C_003E8__8 = null;
						_003Cnearby_003E5__9 = null;
						_003CfallbackIds_003E5__10 = null;
						break;
						IL_0117:
						_003C_003Es__7 = awaiter3.GetResult();
						_003Cplayers_003E5__4 = _003C_003Es__7;
						_003C_003Es__7 = null;
						if (_003Cplayers_003E5__4 == null)
						{
							_003Cplayers_003E5__4 = new List<Player>();
						}
						if (_003Cplayers_003E5__4.Count >= 20)
						{
							break;
						}
						_003C_003E8__8 = new _003C_003Ec__DisplayClass5_1();
						_003C_003E8__8.existingIds = Enumerable.ToHashSet<string>(Enumerable.Select<Player, string>((global::System.Collections.Generic.IEnumerable<Player>)_003Cplayers_003E5__4, (Func<Player, string>)((Player p) => p.PlayerID)));
						_003C_003E8__8.existingIds.Add(_003CcurrentPlayerId_003E5__2);
						awaiter2 = _003C_003E4__this._leaderboardRepository.GetPlayersAroundRankAsync(_003CcurrentPlayerId_003E5__2, 100, 100).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter2;
							_003CExecuteAsync_003Ed__5 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<LeaderboardEntry>>, _003CExecuteAsync_003Ed__5>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_022e;
						IL_034d:
						_003C_003Es__13 = awaiter.GetResult();
						_003CfallbackPlayers_003E5__12 = _003C_003Es__13;
						_003C_003Es__13 = null;
						_003Cplayers_003E5__4.AddRange((global::System.Collections.Generic.IEnumerable<Player>)_003CfallbackPlayers_003E5__12);
						_003CfallbackPlayers_003E5__12 = null;
						goto IL_0387;
					}
					if (_003Cplayers_003E5__4.Count == 0)
					{
						result = Result<List<BattleOpponentDTO>>.SuccessResult(new List<BattleOpponentDTO>());
					}
					else
					{
						_003CvalidPlayers_003E5__5 = ((_003C_003E8__1.request.TeamSize == 3) ? Enumerable.Where<Player>((global::System.Collections.Generic.IEnumerable<Player>)_003Cplayers_003E5__4, (Func<Player, bool>)((Player p) => ((global::System.Collections.Generic.IReadOnlyCollection<string>)p.ActiveSquad).Count > 0 && ((global::System.Collections.Generic.IReadOnlyCollection<KeyValuePair<string, PlayerSpirit>>)p.PlayerSpirits).Count >= 3)) : Enumerable.Where<Player>((global::System.Collections.Generic.IEnumerable<Player>)_003Cplayers_003E5__4, (Func<Player, bool>)((Player p) => !string.IsNullOrEmpty(p.PartnerSpiritId) && ((global::System.Collections.Generic.IReadOnlyCollection<KeyValuePair<string, PlayerSpirit>>)p.PlayerSpirits).Count >= 1)));
						_003Copponents_003E5__6 = Enumerable.ToList<BattleOpponentDTO>(Enumerable.Select<Player, BattleOpponentDTO>(_003CvalidPlayers_003E5__5, (Func<Player, BattleOpponentDTO>)((Player p) => MapToDTO(p, _003C_003E8__1.request.TeamSize))));
						result = Result<List<BattleOpponentDTO>>.SuccessResult(_003Copponents_003E5__6);
					}
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__14 = ex;
					result = Result<List<BattleOpponentDTO>>.FailureResult("Failed to fetch online players: " + _003Cex_003E5__14.Message);
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

	private const int MinimumOpponents = 20;

	private readonly IPlayerRepository _playerRepository;

	private readonly IPlayerStateService _playerStateService;

	private readonly ILeaderboardRepository _leaderboardRepository;

	public GetOnlinePlayersUseCase(IPlayerRepository playerRepository, IPlayerStateService playerStateService, ILeaderboardRepository leaderboardRepository)
	{
		_playerRepository = playerRepository;
		_playerStateService = playerStateService;
		_leaderboardRepository = leaderboardRepository;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__5))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<List<BattleOpponentDTO>>> ExecuteAsync(GetOnlinePlayersRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		GetOnlinePlayersRequest request2 = request;
		try
		{
			string currentPlayerId = _playerStateService.CurrentPlayerId;
			int currentPlayerLevel = _playerStateService.GetCurrentPlayer()?.PlayerLevel ?? 1;
			List<Player> players = await _playerRepository.GetPlayersBattleAsync(request2.TeamSize, request2.Limit, currentPlayerId, currentPlayerLevel);
			if (players == null)
			{
				players = new List<Player>();
			}
			if (players.Count < 20)
			{
				HashSet<string> existingIds = Enumerable.ToHashSet<string>(Enumerable.Select<Player, string>((global::System.Collections.Generic.IEnumerable<Player>)players, (Func<Player, string>)((Player p) => p.PlayerID)));
				existingIds.Add(currentPlayerId);
				List<string> fallbackIds = Enumerable.ToList<string>(Enumerable.Take<string>(Enumerable.Select<LeaderboardEntry, string>(Enumerable.Where<LeaderboardEntry>((global::System.Collections.Generic.IEnumerable<LeaderboardEntry>)(await _leaderboardRepository.GetPlayersAroundRankAsync(currentPlayerId, 100, 100)), (Func<LeaderboardEntry, bool>)((LeaderboardEntry e) => !existingIds.Contains(e.PlayerId))), (Func<LeaderboardEntry, string>)((LeaderboardEntry e) => e.PlayerId)), request2.Limit - players.Count));
				if (fallbackIds.Count > 0)
				{
					players.AddRange((global::System.Collections.Generic.IEnumerable<Player>)(await _playerRepository.GetPlayersByIdsForBattleAsync(fallbackIds, request2.TeamSize)));
				}
			}
			if (players.Count == 0)
			{
				return Result<List<BattleOpponentDTO>>.SuccessResult(new List<BattleOpponentDTO>());
			}
			global::System.Collections.Generic.IEnumerable<Player> validPlayers = ((request2.TeamSize == 3) ? Enumerable.Where<Player>((global::System.Collections.Generic.IEnumerable<Player>)players, (Func<Player, bool>)((Player p) => ((global::System.Collections.Generic.IReadOnlyCollection<string>)p.ActiveSquad).Count > 0 && ((global::System.Collections.Generic.IReadOnlyCollection<KeyValuePair<string, PlayerSpirit>>)p.PlayerSpirits).Count >= 3)) : Enumerable.Where<Player>((global::System.Collections.Generic.IEnumerable<Player>)players, (Func<Player, bool>)((Player p) => !string.IsNullOrEmpty(p.PartnerSpiritId) && ((global::System.Collections.Generic.IReadOnlyCollection<KeyValuePair<string, PlayerSpirit>>)p.PlayerSpirits).Count >= 1)));
			List<BattleOpponentDTO> opponents = Enumerable.ToList<BattleOpponentDTO>(Enumerable.Select<Player, BattleOpponentDTO>(validPlayers, (Func<Player, BattleOpponentDTO>)((Player p) => MapToDTO(p, request2.TeamSize))));
			return Result<List<BattleOpponentDTO>>.SuccessResult(opponents);
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			return Result<List<BattleOpponentDTO>>.FailureResult("Failed to fetch online players: " + ex.Message);
		}
	}

	private static BattleOpponentDTO MapToDTO(Player p, int teamSize)
	{
		Player p2 = p;
		global::System.Collections.Generic.IReadOnlyList<string> readOnlyList2;
		if (teamSize != 3)
		{
			List<string> obj = new List<string>();
			obj.Add(p2.PartnerSpiritId ?? string.Empty);
			global::System.Collections.Generic.IReadOnlyList<string> readOnlyList = (global::System.Collections.Generic.IReadOnlyList<string>)obj;
			readOnlyList2 = readOnlyList;
		}
		else
		{
			readOnlyList2 = p2.ActiveSquad;
		}
		global::System.Collections.Generic.IReadOnlyList<string> readOnlyList3 = readOnlyList2;
		PlayerSpirit playerSpirit = default(PlayerSpirit);
		List<PlayerSpirit> opponentSpirits = Enumerable.ToList<PlayerSpirit>(Enumerable.Where<PlayerSpirit>(Enumerable.Select<string, PlayerSpirit>(Enumerable.Where<string>((global::System.Collections.Generic.IEnumerable<string>)readOnlyList3, (Func<string, bool>)((string id) => !string.IsNullOrEmpty(id))), (Func<string, PlayerSpirit>)((string id) => p2.PlayerSpirits.TryGetValue(id, ref playerSpirit) ? playerSpirit : null)), (Func<PlayerSpirit, bool>)((PlayerSpirit s) => s != null)));
		return new BattleOpponentDTO
		{
			PlayerId = (p2.PlayerID ?? string.Empty),
			Username = (p2.Playername ?? "Unknown"),
			Level = p2.PlayerLevel,
			Title = p2.BattleStats?.Title,
			ActiveSquadSpiritIds = readOnlyList3,
			OpponentSpirits = (global::System.Collections.Generic.IReadOnlyList<PlayerSpirit>?)opponentSpirits,
			Icon = p2.PlayerIcon,
			Reputation = p2.BattleStats.Score
		};
	}
}
