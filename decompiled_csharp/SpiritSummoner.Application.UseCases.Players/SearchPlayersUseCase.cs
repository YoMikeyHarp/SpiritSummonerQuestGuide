using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Players;

public class SearchPlayersUseCase : IUseCase<SearchPlayersRequest, List<PlayerSearchResultModel>>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public SearchPlayersRequest request;

		internal bool _003CExecuteAsync_003Eb__0(Player p)
		{
			return p.PlayerID != request.ExcludePlayerId;
		}

		internal bool _003CExecuteAsync_003Eb__2(Player p)
		{
			return p.GuildId != request.ExcludeGuildId && p.PlayerID != request.ExcludePlayerId;
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<List<PlayerSearchResultModel>>> _003C_003Et__builder;

		public SearchPlayersRequest request;

		public SearchPlayersUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass2_0 _003C_003E8__1;

		private List<Player> _003Cplayers_003E5__2;

		private List<PlayerSearchResultModel> _003CfilteredPlayers_003E5__3;

		private List<Player> _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<List<Player>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<List<PlayerSearchResultModel>> result;
			try
			{
				if (num == 0)
				{
					goto IL_00c4;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass2_0();
				_003C_003E8__1.request = request;
				if (string.IsNullOrWhiteSpace(_003C_003E8__1.request.SearchText))
				{
					result = Result<List<PlayerSearchResultModel>>.FailureResult("Search text is required");
				}
				else if (_003C_003E8__1.request.SearchText.Length < 2)
				{
					result = Result<List<PlayerSearchResultModel>>.FailureResult("Search text must be at least 2 characters");
				}
				else
				{
					if (_003C_003E8__1.request.Limit > 0 && _003C_003E8__1.request.Limit <= 100)
					{
						goto IL_00c4;
					}
					result = Result<List<PlayerSearchResultModel>>.FailureResult("Limit must be between 1 and 100");
				}
				goto end_IL_0007;
				IL_00c4:
				try
				{
					TaskAwaiter<List<Player>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._playerService.SearchPlayersAsync(_003C_003E8__1.request.SearchText, _003C_003E8__1.request.Limit).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CExecuteAsync_003Ed__2 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<Player>>, _003CExecuteAsync_003Ed__2>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<List<Player>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__4 = awaiter.GetResult();
					_003Cplayers_003E5__2 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003Cplayers_003E5__2 == null || !Enumerable.Any<Player>((global::System.Collections.Generic.IEnumerable<Player>)_003Cplayers_003E5__2))
					{
						result = Result<List<PlayerSearchResultModel>>.SuccessResult(new List<PlayerSearchResultModel>());
					}
					else
					{
						_003CfilteredPlayers_003E5__3 = new List<PlayerSearchResultModel>();
						if (string.IsNullOrEmpty(_003C_003E8__1.request.ExcludeGuildId))
						{
							_003CfilteredPlayers_003E5__3 = Enumerable.ToList<PlayerSearchResultModel>(Enumerable.Select<Player, PlayerSearchResultModel>(Enumerable.Where<Player>((global::System.Collections.Generic.IEnumerable<Player>)_003Cplayers_003E5__2, (Func<Player, bool>)((Player p) => p.PlayerID != _003C_003E8__1.request.ExcludePlayerId)), (Func<Player, PlayerSearchResultModel>)((Player p) => new PlayerSearchResultModel
							{
								PlayerId = (p.PlayerID ?? string.Empty),
								PlayerName = (p.Playername ?? "Unknown"),
								Level = p.PlayerLevel,
								Trophies = (p.Currencies.ContainsKey("reputation") ? p.Currencies["reputation"] : 0),
								GuildId = p.GuildId,
								HasGuild = !string.IsNullOrEmpty(p.GuildId)
							})));
						}
						else
						{
							_003CfilteredPlayers_003E5__3 = Enumerable.ToList<PlayerSearchResultModel>(Enumerable.Select<Player, PlayerSearchResultModel>(Enumerable.Where<Player>((global::System.Collections.Generic.IEnumerable<Player>)_003Cplayers_003E5__2, (Func<Player, bool>)((Player p) => p.GuildId != _003C_003E8__1.request.ExcludeGuildId && p.PlayerID != _003C_003E8__1.request.ExcludePlayerId)), (Func<Player, PlayerSearchResultModel>)((Player p) => new PlayerSearchResultModel
							{
								PlayerId = (p.PlayerID ?? string.Empty),
								PlayerName = (p.Playername ?? "Unknown"),
								Level = p.PlayerLevel,
								Trophies = (p.Currencies.ContainsKey("reputation") ? p.Currencies["reputation"] : 0),
								GuildId = p.GuildId,
								HasGuild = !string.IsNullOrEmpty(p.GuildId)
							})));
						}
						result = Result<List<PlayerSearchResultModel>>.SuccessResult(_003CfilteredPlayers_003E5__3);
					}
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					result = Result<List<PlayerSearchResultModel>>.FailureResult("Failed to search players: " + _003Cex_003E5__5.Message);
				}
				end_IL_0007:;
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

	private readonly IPlayerRepository _playerService;

	public SearchPlayersUseCase(IPlayerRepository playerService)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_playerService = playerService ?? throw new ArgumentNullException("playerService");
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__2))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<List<PlayerSearchResultModel>>> ExecuteAsync(SearchPlayersRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		SearchPlayersRequest request2 = request;
		if (string.IsNullOrWhiteSpace(request2.SearchText))
		{
			return Result<List<PlayerSearchResultModel>>.FailureResult("Search text is required");
		}
		if (request2.SearchText.Length < 2)
		{
			return Result<List<PlayerSearchResultModel>>.FailureResult("Search text must be at least 2 characters");
		}
		if (request2.Limit <= 0 || request2.Limit > 100)
		{
			return Result<List<PlayerSearchResultModel>>.FailureResult("Limit must be between 1 and 100");
		}
		try
		{
			List<Player> players = await _playerService.SearchPlayersAsync(request2.SearchText, request2.Limit);
			if (players == null || !Enumerable.Any<Player>((global::System.Collections.Generic.IEnumerable<Player>)players))
			{
				return Result<List<PlayerSearchResultModel>>.SuccessResult(new List<PlayerSearchResultModel>());
			}
			new List<PlayerSearchResultModel>();
			List<PlayerSearchResultModel> filteredPlayers = ((!string.IsNullOrEmpty(request2.ExcludeGuildId)) ? Enumerable.ToList<PlayerSearchResultModel>(Enumerable.Select<Player, PlayerSearchResultModel>(Enumerable.Where<Player>((global::System.Collections.Generic.IEnumerable<Player>)players, (Func<Player, bool>)((Player p) => p.GuildId != request2.ExcludeGuildId && p.PlayerID != request2.ExcludePlayerId)), (Func<Player, PlayerSearchResultModel>)((Player p) => new PlayerSearchResultModel
			{
				PlayerId = (p.PlayerID ?? string.Empty),
				PlayerName = (p.Playername ?? "Unknown"),
				Level = p.PlayerLevel,
				Trophies = (p.Currencies.ContainsKey("reputation") ? p.Currencies["reputation"] : 0),
				GuildId = p.GuildId,
				HasGuild = !string.IsNullOrEmpty(p.GuildId)
			}))) : Enumerable.ToList<PlayerSearchResultModel>(Enumerable.Select<Player, PlayerSearchResultModel>(Enumerable.Where<Player>((global::System.Collections.Generic.IEnumerable<Player>)players, (Func<Player, bool>)((Player p) => p.PlayerID != request2.ExcludePlayerId)), (Func<Player, PlayerSearchResultModel>)((Player p) => new PlayerSearchResultModel
			{
				PlayerId = (p.PlayerID ?? string.Empty),
				PlayerName = (p.Playername ?? "Unknown"),
				Level = p.PlayerLevel,
				Trophies = (p.Currencies.ContainsKey("reputation") ? p.Currencies["reputation"] : 0),
				GuildId = p.GuildId,
				HasGuild = !string.IsNullOrEmpty(p.GuildId)
			}))));
			return Result<List<PlayerSearchResultModel>>.SuccessResult(filteredPlayers);
		}
		catch (global::System.Exception ex)
		{
			return Result<List<PlayerSearchResultModel>>.FailureResult("Failed to search players: " + ex.Message);
		}
	}
}
