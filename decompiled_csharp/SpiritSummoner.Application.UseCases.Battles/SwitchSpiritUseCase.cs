using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.UseCases.Common;

namespace SpiritSummoner.Application.UseCases.Battles;

public class SwitchSpiritUseCase : IUseCase<SwitchSpiritRequest, BattleState>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__0 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<BattleState>> _003C_003Et__builder;

		public SwitchSpiritRequest request;

		public SwitchSpiritUseCase _003C_003E4__this;

		private Result<BattleState> _003C_003Es__1;

		private TaskAwaiter<Result<BattleState>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<BattleState> result;
			try
			{
				TaskAwaiter<Result<BattleState>> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Result<BattleState>>);
					num = (_003C_003E1__state = -1);
					goto IL_0121;
				}
				if (request.BattleState == null)
				{
					result = Result<BattleState>.FailureResult("Battle state is null");
				}
				else if (request.BattleState.BattleEnded)
				{
					result = Result<BattleState>.FailureResult("Cannot switch spirits after battle has ended");
				}
				else
				{
					if (request.NewSpiritIndex != request.BattleState.ActivePlayerSpiritIndex)
					{
						request.BattleState.ActivePlayerSpiritIndex = request.NewSpiritIndex;
						request.BattleState.IsPlayerTurn = false;
						awaiter = global::System.Threading.Tasks.Task.FromResult<Result<BattleState>>(Result<BattleState>.SuccessResult(request.BattleState)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CExecuteAsync_003Ed__0 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Result<BattleState>>, _003CExecuteAsync_003Ed__0>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_0121;
					}
					result = Result<BattleState>.FailureResult("Spirit is already active");
				}
				goto end_IL_0007;
				IL_0121:
				_003C_003Es__1 = awaiter.GetResult();
				result = _003C_003Es__1;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(exception);
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

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__0))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<BattleState>> ExecuteAsync(SwitchSpiritRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (request.BattleState == null)
		{
			return Result<BattleState>.FailureResult("Battle state is null");
		}
		if (request.BattleState.BattleEnded)
		{
			return Result<BattleState>.FailureResult("Cannot switch spirits after battle has ended");
		}
		if (request.NewSpiritIndex == request.BattleState.ActivePlayerSpiritIndex)
		{
			return Result<BattleState>.FailureResult("Spirit is already active");
		}
		request.BattleState.ActivePlayerSpiritIndex = request.NewSpiritIndex;
		request.BattleState.IsPlayerTurn = false;
		return await global::System.Threading.Tasks.Task.FromResult<Result<BattleState>>(Result<BattleState>.SuccessResult(request.BattleState));
	}
}
