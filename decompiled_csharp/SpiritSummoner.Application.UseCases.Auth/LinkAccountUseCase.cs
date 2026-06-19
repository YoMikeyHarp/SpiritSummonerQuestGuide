using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Auth;

public class LinkAccountUseCase
{
	[CompilerGenerated]
	private sealed class _003CExecute_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<bool>> _003C_003Et__builder;

		public LinkAccountRequest request;

		public LinkAccountUseCase _003C_003E4__this;

		private bool _003CupdateUserResult_003E5__1;

		private Result<_003C_003Ef__AnonymousType0<Player>> _003Cresult_003E5__2;

		private bool _003CcreatePublicProfile_003E5__3;

		private bool _003C_003Es__4;

		private bool _003C_003Es__5;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0200: Unknown result type (might be due to invalid IL or missing references)
			//IL_0205: Unknown result type (might be due to invalid IL or missing references)
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<bool> result;
			try
			{
				TaskAwaiter<bool> awaiter;
				TaskAwaiter<bool> awaiter2;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_021c;
					}
					awaiter2 = _003C_003E4__this._playerRepositroy.LinkUserAsync(_003C_003E4__this._stateService.CurrentPlayerId ?? string.Empty, request.Email ?? string.Empty).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003CExecute_003Ed__3 _003CExecute_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecute_003Ed__3>(ref awaiter2, ref _003CExecute_003Ed__);
						return;
					}
				}
				else
				{
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__4 = awaiter2.GetResult();
				_003CupdateUserResult_003E5__1 = _003C_003Es__4;
				if (!_003CupdateUserResult_003E5__1)
				{
					result = Result<bool>.FailureResult("Error linking account");
				}
				else
				{
					_003Cresult_003E5__2 = _003C_003E4__this._stateService.ExecuteUpdate((Player player) => player.IsAccountLinked ? ValidationResult.Failure("Account is already linked") : ValidationResult.Success(), delegate(Player player)
					{
						player.SetAccountLinked(isLinked: true);
						return new { player };
					}, (Player player, _) => new PlayerBatchUpdate
					{
						PlayerId = player.PlayerID,
						SetAccountLinked = true
					});
					if (_003Cresult_003E5__2.Success)
					{
						_003CcreatePublicProfile_003E5__3 = false;
						if (_003Cresult_003E5__2.Success && _003Cresult_003E5__2.Data != null)
						{
							awaiter = _003C_003E4__this._playerRepositroy.CreatePublicProfile(_003Cresult_003E5__2.Data.player).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter;
								_003CExecute_003Ed__3 _003CExecute_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecute_003Ed__3>(ref awaiter, ref _003CExecute_003Ed__);
								return;
							}
							goto IL_021c;
						}
						goto IL_0236;
					}
					result = Result<bool>.FailureResult("Error linking account");
				}
				goto end_IL_0007;
				IL_0236:
				result = Result<bool>.SuccessResult(_003Cresult_003E5__2.Success & _003CcreatePublicProfile_003E5__3);
				goto end_IL_0007;
				IL_021c:
				_003C_003Es__5 = awaiter.GetResult();
				_003CcreatePublicProfile_003E5__3 = _003C_003Es__5;
				goto IL_0236;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cresult_003E5__2 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cresult_003E5__2 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IPlayerStateService _stateService;

	private readonly IPlayerRepository _playerRepositroy;

	public LinkAccountUseCase(IPlayerStateService stateService, IPlayerRepository playerRepository)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
		_playerRepositroy = playerRepository ?? throw new ArgumentNullException("playerRepository");
	}

	[AsyncStateMachine(typeof(_003CExecute_003Ed__3))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<bool>> Execute(LinkAccountRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (!(await _playerRepositroy.LinkUserAsync(_stateService.CurrentPlayerId ?? string.Empty, request.Email ?? string.Empty)))
		{
			return Result<bool>.FailureResult("Error linking account");
		}
		var result = _stateService.ExecuteUpdate((Player player) => player.IsAccountLinked ? ValidationResult.Failure("Account is already linked") : ValidationResult.Success(), delegate(Player player)
		{
			player.SetAccountLinked(isLinked: true);
			return new { player };
		}, (Player player, _) => new PlayerBatchUpdate
		{
			PlayerId = player.PlayerID,
			SetAccountLinked = true
		});
		if (!result.Success)
		{
			return Result<bool>.FailureResult("Error linking account");
		}
		bool createPublicProfile = false;
		if (result.Success && result.Data != null)
		{
			createPublicProfile = await _playerRepositroy.CreatePublicProfile(result.Data.player);
		}
		return Result<bool>.SuccessResult(result.Success && createPublicProfile);
	}
}
