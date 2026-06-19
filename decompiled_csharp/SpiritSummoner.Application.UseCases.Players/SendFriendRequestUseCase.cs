using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.Interfaces;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Enums.Common;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Players;

public class SendFriendRequestUseCase : IUseCase<SendFriendRequestRequest, bool>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public SendFriendRequestRequest request;

		internal bool _003CExecuteAsync_003Eb__0(Friend f)
		{
			return f.FriendId == request.TargetPlayerId;
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<bool>> _003C_003Et__builder;

		public SendFriendRequestRequest request;

		public SendFriendRequestUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass4_0 _003C_003E8__1;

		private Player _003CcurrentPlayer_003E5__2;

		private List<Friend> _003Cfriends_003E5__3;

		private Dictionary<string, object> _003Cdata_003E5__4;

		private List<Friend> _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<List<Friend>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_0258: Unknown result type (might be due to invalid IL or missing references)
			//IL_025d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0265: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_021e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0223: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0238: Unknown result type (might be due to invalid IL or missing references)
			//IL_023a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<bool> result;
			try
			{
				if ((uint)num <= 1u)
				{
					goto IL_00c2;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass4_0();
				_003C_003E8__1.request = request;
				if (string.IsNullOrEmpty(_003C_003E8__1.request.TargetPlayerId))
				{
					result = Result<bool>.FailureResult("Target player ID is required");
				}
				else
				{
					_003CcurrentPlayer_003E5__2 = _003C_003E4__this._playerState.GetCurrentPlayer();
					if (_003CcurrentPlayer_003E5__2 == null)
					{
						result = Result<bool>.FailureResult("Not logged in");
					}
					else
					{
						if (!(_003CcurrentPlayer_003E5__2.PlayerID == _003C_003E8__1.request.TargetPlayerId))
						{
							goto IL_00c2;
						}
						result = Result<bool>.FailureResult("Cannot send friend request to yourself");
					}
				}
				goto end_IL_0007;
				IL_00c2:
				try
				{
					TaskAwaiter awaiter;
					TaskAwaiter<List<Friend>> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0274;
						}
						awaiter2 = _003C_003E4__this._playerRepository.GetFriendsAsync(_003CcurrentPlayer_003E5__2.PlayerID).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<Friend>>, _003CExecuteAsync_003Ed__4>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<List<Friend>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__5 = awaiter2.GetResult();
					_003Cfriends_003E5__3 = _003C_003Es__5;
					_003C_003Es__5 = null;
					if (!Enumerable.Any<Friend>((global::System.Collections.Generic.IEnumerable<Friend>)_003Cfriends_003E5__3, (Func<Friend, bool>)((Friend f) => f.FriendId == _003C_003E8__1.request.TargetPlayerId)))
					{
						Dictionary<string, object> obj = new Dictionary<string, object>();
						obj.Add("senderId", (object)_003CcurrentPlayer_003E5__2.PlayerID);
						obj.Add("senderName", (object)(_003CcurrentPlayer_003E5__2.Playername ?? "Unknown"));
						obj.Add("senderLevel", (object)_003CcurrentPlayer_003E5__2.PlayerLevel);
						_003Cdata_003E5__4 = obj;
						awaiter = _003C_003E4__this._notificationService.SendAsync(_003C_003E8__1.request.TargetPlayerId, NotificationType.FriendRequest, _003Cdata_003E5__4).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteAsync_003Ed__4>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_0274;
					}
					result = Result<bool>.FailureResult("Already friends with this player");
					goto end_IL_00c2;
					IL_0274:
					((TaskAwaiter)(ref awaiter)).GetResult();
					result = Result<bool>.SuccessResult(data: true);
					end_IL_00c2:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__6 = ex;
					result = Result<bool>.FailureResult("Failed to send friend request: " + _003Cex_003E5__6.Message);
				}
				end_IL_0007:;
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003CcurrentPlayer_003E5__2 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003CcurrentPlayer_003E5__2 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IPlayerRepository _playerRepository;

	private readonly IPlayerNotificationService _notificationService;

	private readonly IPlayerStateService _playerState;

	public SendFriendRequestUseCase(IPlayerRepository playerRepository, IPlayerNotificationService notificationService, IPlayerStateService playerState)
	{
		_playerRepository = playerRepository;
		_notificationService = notificationService;
		_playerState = playerState;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__4))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<bool>> ExecuteAsync(SendFriendRequestRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		SendFriendRequestRequest request2 = request;
		if (string.IsNullOrEmpty(request2.TargetPlayerId))
		{
			return Result<bool>.FailureResult("Target player ID is required");
		}
		Player currentPlayer = _playerState.GetCurrentPlayer();
		if (currentPlayer == null)
		{
			return Result<bool>.FailureResult("Not logged in");
		}
		if (currentPlayer.PlayerID == request2.TargetPlayerId)
		{
			return Result<bool>.FailureResult("Cannot send friend request to yourself");
		}
		try
		{
			if (Enumerable.Any<Friend>((global::System.Collections.Generic.IEnumerable<Friend>)(await _playerRepository.GetFriendsAsync(currentPlayer.PlayerID)), (Func<Friend, bool>)((Friend f) => f.FriendId == request2.TargetPlayerId)))
			{
				return Result<bool>.FailureResult("Already friends with this player");
			}
			Dictionary<string, object> obj = new Dictionary<string, object>();
			obj.Add("senderId", (object)currentPlayer.PlayerID);
			obj.Add("senderName", (object)(currentPlayer.Playername ?? "Unknown"));
			obj.Add("senderLevel", (object)currentPlayer.PlayerLevel);
			Dictionary<string, object> data = obj;
			await _notificationService.SendAsync(request2.TargetPlayerId, NotificationType.FriendRequest, data);
			return Result<bool>.SuccessResult(data: true);
		}
		catch (global::System.Exception ex)
		{
			return Result<bool>.FailureResult("Failed to send friend request: " + ex.Message);
		}
	}
}
