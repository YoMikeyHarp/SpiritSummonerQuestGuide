using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.UseCases.Common;

namespace SpiritSummoner.Application.UseCases.Battles;

public class RecordBattleStatisticsUseCase : IUseCase<RecordBattleStatisticsRequest, PlayerBatchUpdate>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__0 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<PlayerBatchUpdate>> _003C_003Et__builder;

		public RecordBattleStatisticsRequest request;

		public RecordBattleStatisticsUseCase _003C_003E4__this;

		private PlayerBatchUpdate _003CbatchUpdate_003E5__1;

		private Result<PlayerBatchUpdate> _003C_003Es__2;

		private TaskAwaiter<Result<PlayerBatchUpdate>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<PlayerBatchUpdate> result;
			try
			{
				TaskAwaiter<Result<PlayerBatchUpdate>> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Result<PlayerBatchUpdate>>);
					num = (_003C_003E1__state = -1);
					goto IL_00ef;
				}
				if (request.Player != null)
				{
					_003CbatchUpdate_003E5__1 = new PlayerBatchUpdate
					{
						PlayerId = (request.Player.PlayerID ?? string.Empty),
						WinsChange = (request.Victory ? 1 : 0),
						LossChange = ((!request.Victory) ? 1 : 0)
					};
					awaiter = global::System.Threading.Tasks.Task.FromResult<Result<PlayerBatchUpdate>>(Result<PlayerBatchUpdate>.SuccessResult(_003CbatchUpdate_003E5__1)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CExecuteAsync_003Ed__0 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Result<PlayerBatchUpdate>>, _003CExecuteAsync_003Ed__0>(ref awaiter, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_00ef;
				}
				result = Result<PlayerBatchUpdate>.FailureResult("Player not found");
				goto end_IL_0007;
				IL_00ef:
				_003C_003Es__2 = awaiter.GetResult();
				result = _003C_003Es__2;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CbatchUpdate_003E5__1 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CbatchUpdate_003E5__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__0))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<PlayerBatchUpdate>> ExecuteAsync(RecordBattleStatisticsRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (request.Player == null)
		{
			return Result<PlayerBatchUpdate>.FailureResult("Player not found");
		}
		PlayerBatchUpdate batchUpdate = new PlayerBatchUpdate
		{
			PlayerId = (request.Player.PlayerID ?? string.Empty),
			WinsChange = (request.Victory ? 1 : 0),
			LossChange = ((!request.Victory) ? 1 : 0)
		};
		return await global::System.Threading.Tasks.Task.FromResult<Result<PlayerBatchUpdate>>(Result<PlayerBatchUpdate>.SuccessResult(batchUpdate));
	}
}
