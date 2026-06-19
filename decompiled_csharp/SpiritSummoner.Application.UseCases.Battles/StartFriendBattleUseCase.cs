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
using SpiritSummoner.Domain.Enums.Battles;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Presentation.ViewModels.Battles;

namespace SpiritSummoner.Application.UseCases.Battles;

public class StartFriendBattleUseCase : IUseCase<StartFriendBattleRequest, BattleLaunchRequest>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<BattleLaunchRequest>> _003C_003Et__builder;

		public StartFriendBattleRequest request;

		public StartFriendBattleUseCase _003C_003E4__this;

		private Player _003Cplayer_003E5__1;

		private Player _003Cfriend_003E5__2;

		private List<string> _003CplayerSquad_003E5__3;

		private BattleLaunchRequest _003CbattleRequest_003E5__4;

		private Player _003C_003Es__5;

		private TaskAwaiter<Player?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<BattleLaunchRequest> result;
			try
			{
				TaskAwaiter<Player> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Player>);
					num = (_003C_003E1__state = -1);
					goto IL_00b4;
				}
				_003Cplayer_003E5__1 = _003C_003E4__this._playerStateService.GetCurrentPlayer();
				if (_003Cplayer_003E5__1 != null)
				{
					awaiter = _003C_003E4__this._playerRepo.GetPlayerBattleAsync(request.FriendPlayerId).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Player>, _003CExecuteAsync_003Ed__4>(ref awaiter, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_00b4;
				}
				result = Result<BattleLaunchRequest>.FailureResult("Player not found");
				goto end_IL_0007;
				IL_00b4:
				_003C_003Es__5 = awaiter.GetResult();
				_003Cfriend_003E5__2 = _003C_003Es__5;
				_003C_003Es__5 = null;
				if (_003Cfriend_003E5__2 == null)
				{
					result = Result<BattleLaunchRequest>.FailureResult("Your friend was not found");
				}
				else
				{
					List<string> obj;
					if (!request.Is3v3)
					{
						obj = new List<string>();
						obj.Add(_003Cplayer_003E5__1.PartnerSpiritId);
					}
					else
					{
						obj = Enumerable.ToList<string>(Enumerable.Where<string>((global::System.Collections.Generic.IEnumerable<string>)_003Cplayer_003E5__1.ActiveSquad, (Func<string, bool>)((string s) => !string.IsNullOrEmpty(s))));
					}
					_003CplayerSquad_003E5__3 = obj;
					if (_003CplayerSquad_003E5__3.Count != 3)
					{
						_003CplayerSquad_003E5__3.Clear();
						_003CplayerSquad_003E5__3.Add(_003Cplayer_003E5__1.PartnerSpiritId);
					}
					BattleLaunchRequest obj2 = new BattleLaunchRequest
					{
						Mode = BattleMode.FriendBattle,
						PlayerId = _003Cplayer_003E5__1.PlayerID,
						PlayerSpiritIds = _003CplayerSquad_003E5__3,
						OpponentPlayerId = _003Cfriend_003E5__2.PlayerID,
						OpponentLevel = _003Cfriend_003E5__2.PlayerLevel
					};
					List<string> obj3;
					if (_003CplayerSquad_003E5__3.Count != 3)
					{
						obj3 = new List<string>(1);
						obj3.Add(_003Cfriend_003E5__2.PartnerSpiritId);
					}
					else
					{
						obj3 = Enumerable.ToList<string>((global::System.Collections.Generic.IEnumerable<string>)_003Cfriend_003E5__2.ActiveSquad);
					}
					obj2.OpponentSpiritIds = obj3;
					obj2.CompletionSource = new TaskCompletionSource<BattleResultDTO>();
					_003CbattleRequest_003E5__4 = obj2;
					result = Result<BattleLaunchRequest>.SuccessResult(_003CbattleRequest_003E5__4);
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cplayer_003E5__1 = null;
				_003Cfriend_003E5__2 = null;
				_003CplayerSquad_003E5__3 = null;
				_003CbattleRequest_003E5__4 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cplayer_003E5__1 = null;
			_003Cfriend_003E5__2 = null;
			_003CplayerSquad_003E5__3 = null;
			_003CbattleRequest_003E5__4 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IPlayerRepository _playerRepo;

	private readonly IPlayerStateService _playerStateService;

	private readonly IGuildStateService _guildStateSerivce;

	public StartFriendBattleUseCase(IPlayerRepository playerRepository, IPlayerStateService playerStateService, IGuildStateService guildStateService)
	{
		_playerRepo = playerRepository;
		_playerStateService = playerStateService;
		_guildStateSerivce = guildStateService;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__4))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<BattleLaunchRequest>> ExecuteAsync(StartFriendBattleRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Player player = _playerStateService.GetCurrentPlayer();
		if (player == null)
		{
			return Result<BattleLaunchRequest>.FailureResult("Player not found");
		}
		Player friend = await _playerRepo.GetPlayerBattleAsync(request.FriendPlayerId);
		if (friend == null)
		{
			return Result<BattleLaunchRequest>.FailureResult("Your friend was not found");
		}
		List<string> obj;
		if (!request.Is3v3)
		{
			obj = new List<string>();
			obj.Add(player.PartnerSpiritId);
		}
		else
		{
			obj = Enumerable.ToList<string>(Enumerable.Where<string>((global::System.Collections.Generic.IEnumerable<string>)player.ActiveSquad, (Func<string, bool>)((string s) => !string.IsNullOrEmpty(s))));
		}
		List<string> playerSquad = obj;
		if (playerSquad.Count != 3)
		{
			playerSquad.Clear();
			playerSquad.Add(player.PartnerSpiritId);
		}
		BattleLaunchRequest obj2 = new BattleLaunchRequest
		{
			Mode = BattleMode.FriendBattle,
			PlayerId = player.PlayerID,
			PlayerSpiritIds = playerSquad,
			OpponentPlayerId = friend.PlayerID,
			OpponentLevel = friend.PlayerLevel
		};
		List<string> obj3;
		if (playerSquad.Count != 3)
		{
			obj3 = new List<string>(1);
			obj3.Add(friend.PartnerSpiritId);
		}
		else
		{
			obj3 = Enumerable.ToList<string>((global::System.Collections.Generic.IEnumerable<string>)friend.ActiveSquad);
		}
		obj2.OpponentSpiritIds = obj3;
		obj2.CompletionSource = new TaskCompletionSource<BattleResultDTO>();
		BattleLaunchRequest battleRequest = obj2;
		return Result<BattleLaunchRequest>.SuccessResult(battleRequest);
	}
}
