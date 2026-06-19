using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.Interfaces;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Enums.Common;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Players;

public class AcceptFriendRequestUseCase : IUseCase<AcceptFriendRequestRequest, bool>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<bool>> _003C_003Et__builder;

		public AcceptFriendRequestRequest request;

		public AcceptFriendRequestUseCase _003C_003E4__this;

		private Player _003CcurrentPlayer_003E5__1;

		private DateTimeOffset _003Cnow_003E5__2;

		private Friend _003CmyFriend_003E5__3;

		private Friend _003CtheirFriend_003E5__4;

		private bool _003CaddMine_003E5__5;

		private bool _003CaddTheirs_003E5__6;

		private Dictionary<string, object> _003Cdata_003E5__7;

		private bool _003C_003Es__8;

		private bool _003C_003Es__9;

		private global::System.Exception _003Cex_003E5__10;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_0218: Unknown result type (might be due to invalid IL or missing references)
			//IL_021d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0225: Unknown result type (might be due to invalid IL or missing references)
			//IL_0316: Unknown result type (might be due to invalid IL or missing references)
			//IL_031b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0323: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01de: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<bool> result;
			try
			{
				if ((uint)num <= 2u)
				{
					goto IL_007d;
				}
				if (string.IsNullOrEmpty(request.SenderId) || string.IsNullOrEmpty(request.SenderName))
				{
					result = Result<bool>.FailureResult("Sender information is required");
				}
				else
				{
					_003CcurrentPlayer_003E5__1 = _003C_003E4__this._playerState.GetCurrentPlayer();
					if (_003CcurrentPlayer_003E5__1 != null)
					{
						goto IL_007d;
					}
					result = Result<bool>.FailureResult("Not logged in");
				}
				goto end_IL_0007;
				IL_007d:
				try
				{
					TaskAwaiter<bool> awaiter3;
					TaskAwaiter<bool> awaiter2;
					TaskAwaiter awaiter;
					switch (num)
					{
					default:
						_003Cnow_003E5__2 = DateTimeOffset.UtcNow;
						_003CmyFriend_003E5__3 = new Friend
						{
							FriendId = request.SenderId,
							FriendName = request.SenderName,
							AddedAt = _003Cnow_003E5__2
						};
						_003CtheirFriend_003E5__4 = new Friend
						{
							FriendId = _003CcurrentPlayer_003E5__1.PlayerID,
							FriendName = (_003CcurrentPlayer_003E5__1.Playername ?? "Unknown"),
							AddedAt = _003Cnow_003E5__2
						};
						awaiter3 = _003C_003E4__this._playerRepository.AddFriendAsync(_003CcurrentPlayer_003E5__1.PlayerID, _003CmyFriend_003E5__3).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__4>(ref awaiter3, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_01a4;
					case 0:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_01a4;
					case 1:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_0234;
					case 2:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_01a4:
						_003C_003Es__8 = awaiter3.GetResult();
						_003CaddMine_003E5__5 = _003C_003Es__8;
						awaiter2 = _003C_003E4__this._playerRepository.AddFriendAsync(request.SenderId, _003CtheirFriend_003E5__4).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter2;
							_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__4>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_0234;
						IL_0234:
						_003C_003Es__9 = awaiter2.GetResult();
						_003CaddTheirs_003E5__6 = _003C_003Es__9;
						if (_003CaddMine_003E5__5 && _003CaddTheirs_003E5__6)
						{
							Dictionary<string, object> obj = new Dictionary<string, object>();
							obj.Add("accepterId", (object)_003CcurrentPlayer_003E5__1.PlayerID);
							obj.Add("accepterName", (object)(_003CcurrentPlayer_003E5__1.Playername ?? "Unknown"));
							_003Cdata_003E5__7 = obj;
							awaiter = _003C_003E4__this._notificationService.SendAsync(request.SenderId, NotificationType.FriendRequestAccepted, _003Cdata_003E5__7).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__2 = awaiter;
								_003CExecuteAsync_003Ed__4 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CExecuteAsync_003Ed__4>(ref awaiter, ref _003CExecuteAsync_003Ed__);
								return;
							}
							break;
						}
						result = Result<bool>.FailureResult("Failed to add friend");
						goto end_IL_007d;
					}
					((TaskAwaiter)(ref awaiter)).GetResult();
					result = Result<bool>.SuccessResult(data: true);
					end_IL_007d:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__10 = ex;
					result = Result<bool>.FailureResult("Failed to accept friend request: " + _003Cex_003E5__10.Message);
				}
				end_IL_0007:;
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003CcurrentPlayer_003E5__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003CcurrentPlayer_003E5__1 = null;
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

	public AcceptFriendRequestUseCase(IPlayerRepository playerRepository, IPlayerNotificationService notificationService, IPlayerStateService playerState)
	{
		_playerRepository = playerRepository;
		_notificationService = notificationService;
		_playerState = playerState;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__4))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<bool>> ExecuteAsync(AcceptFriendRequestRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(request.SenderId) || string.IsNullOrEmpty(request.SenderName))
		{
			return Result<bool>.FailureResult("Sender information is required");
		}
		Player currentPlayer = _playerState.GetCurrentPlayer();
		if (currentPlayer == null)
		{
			return Result<bool>.FailureResult("Not logged in");
		}
		try
		{
			DateTimeOffset now = DateTimeOffset.UtcNow;
			Friend myFriend = new Friend
			{
				FriendId = request.SenderId,
				FriendName = request.SenderName,
				AddedAt = now
			};
			Friend theirFriend = new Friend
			{
				FriendId = currentPlayer.PlayerID,
				FriendName = (currentPlayer.Playername ?? "Unknown"),
				AddedAt = now
			};
			bool addMine = await _playerRepository.AddFriendAsync(currentPlayer.PlayerID, myFriend);
			bool addTheirs = await _playerRepository.AddFriendAsync(request.SenderId, theirFriend);
			if (!addMine || !addTheirs)
			{
				return Result<bool>.FailureResult("Failed to add friend");
			}
			Dictionary<string, object> obj = new Dictionary<string, object>();
			obj.Add("accepterId", (object)currentPlayer.PlayerID);
			obj.Add("accepterName", (object)(currentPlayer.Playername ?? "Unknown"));
			Dictionary<string, object> data = obj;
			await _notificationService.SendAsync(request.SenderId, NotificationType.FriendRequestAccepted, data);
			return Result<bool>.SuccessResult(data: true);
		}
		catch (global::System.Exception ex)
		{
			return Result<bool>.FailureResult("Failed to accept friend request: " + ex.Message);
		}
	}
}
