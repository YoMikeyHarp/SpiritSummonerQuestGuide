using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Players;

public class GetFriendsUseCase : IUseCase<List<Friend>>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<List<Friend>>> _003C_003Et__builder;

		public GetFriendsUseCase _003C_003E4__this;

		private string _003CplayerId_003E5__1;

		private List<Friend> _003Cfriends_003E5__2;

		private List<Friend> _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<List<Friend>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<List<Friend>> result;
			try
			{
				if (num == 0)
				{
					goto IL_0045;
				}
				_003CplayerId_003E5__1 = _003C_003E4__this._playerState.CurrentPlayerId;
				if (!string.IsNullOrEmpty(_003CplayerId_003E5__1))
				{
					goto IL_0045;
				}
				result = Result<List<Friend>>.FailureResult("Not logged in");
				goto end_IL_0007;
				IL_0045:
				try
				{
					TaskAwaiter<List<Friend>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._playerRepository.GetFriendsAsync(_003CplayerId_003E5__1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<Friend>>, _003CExecuteAsync_003Ed__3>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<List<Friend>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter.GetResult();
					_003Cfriends_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					result = Result<List<Friend>>.SuccessResult(_003Cfriends_003E5__2);
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					result = Result<List<Friend>>.FailureResult("Failed to get friends: " + _003Cex_003E5__4.Message);
				}
				end_IL_0007:;
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003CplayerId_003E5__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003CplayerId_003E5__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IPlayerRepository _playerRepository;

	private readonly IPlayerStateService _playerState;

	public GetFriendsUseCase(IPlayerRepository playerRepository, IPlayerStateService playerState)
	{
		_playerRepository = playerRepository;
		_playerState = playerState;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__3))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<List<Friend>>> ExecuteAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string playerId = _playerState.CurrentPlayerId;
		if (string.IsNullOrEmpty(playerId))
		{
			return Result<List<Friend>>.FailureResult("Not logged in");
		}
		try
		{
			return Result<List<Friend>>.SuccessResult(await _playerRepository.GetFriendsAsync(playerId));
		}
		catch (global::System.Exception ex)
		{
			return Result<List<Friend>>.FailureResult("Failed to get friends: " + ex.Message);
		}
	}
}
