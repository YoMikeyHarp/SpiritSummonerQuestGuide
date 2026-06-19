using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Guilds;

public class DeclineInvitationUseCase : IUseCase<DeclineInvitationRequest, bool>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<bool>> _003C_003Et__builder;

		public DeclineInvitationRequest request;

		public DeclineInvitationUseCase _003C_003E4__this;

		private bool _003Csuccess_003E5__1;

		private bool _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<bool> result;
			try
			{
				if (num == 0)
				{
					goto IL_0058;
				}
				if (string.IsNullOrWhiteSpace(request.InvitationId))
				{
					result = Result<bool>.FailureResult("Invitation ID is required");
				}
				else
				{
					if (!string.IsNullOrWhiteSpace(request.PlayerId))
					{
						goto IL_0058;
					}
					result = Result<bool>.FailureResult("Player ID is required");
				}
				goto end_IL_0007;
				IL_0058:
				try
				{
					TaskAwaiter<bool> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._guildRepository.DeclineInvitationAsync(request.InvitationId, request.PlayerId).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CExecuteAsync_003Ed__2 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__2>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Csuccess_003E5__1 = _003C_003Es__2;
					result = (_003Csuccess_003E5__1 ? Result<bool>.SuccessResult(data: true) : Result<bool>.FailureResult("Failed to decline invitation"));
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					result = Result<bool>.FailureResult("An error occurred while declining the invitation: " + _003Cex_003E5__3.Message);
				}
				end_IL_0007:;
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IGuildRepository _guildRepository;

	public DeclineInvitationUseCase(IGuildRepository guildRepository)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_guildRepository = guildRepository ?? throw new ArgumentNullException("guildRepository");
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__2))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<bool>> ExecuteAsync(DeclineInvitationRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrWhiteSpace(request.InvitationId))
		{
			return Result<bool>.FailureResult("Invitation ID is required");
		}
		if (string.IsNullOrWhiteSpace(request.PlayerId))
		{
			return Result<bool>.FailureResult("Player ID is required");
		}
		try
		{
			if (!(await _guildRepository.DeclineInvitationAsync(request.InvitationId, request.PlayerId)))
			{
				return Result<bool>.FailureResult("Failed to decline invitation");
			}
			return Result<bool>.SuccessResult(data: true);
		}
		catch (global::System.Exception ex)
		{
			return Result<bool>.FailureResult("An error occurred while declining the invitation: " + ex.Message);
		}
	}
}
