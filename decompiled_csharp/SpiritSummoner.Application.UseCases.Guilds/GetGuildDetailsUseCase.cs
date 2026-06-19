using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Guilds;

public class GetGuildDetailsUseCase : IUseCase<GetGuildDetailsRequest, Guild>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<Guild>> _003C_003Et__builder;

		public GetGuildDetailsRequest request;

		public GetGuildDetailsUseCase _003C_003E4__this;

		private Guild _003Cguild_003E5__1;

		private Guild _003C_003Es__2;

		private TaskAwaiter<Guild?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<Guild> result;
			try
			{
				TaskAwaiter<Guild> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Guild>);
					num = (_003C_003E1__state = -1);
					goto IL_00a1;
				}
				if (!string.IsNullOrWhiteSpace(request.GuildId))
				{
					awaiter = _003C_003E4__this._guildRepo.GetByIdAsync(request.GuildId).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CExecuteAsync_003Ed__2 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CExecuteAsync_003Ed__2>(ref awaiter, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_00a1;
				}
				result = Result<Guild>.FailureResult("Guild ID is required");
				goto end_IL_0007;
				IL_00a1:
				_003C_003Es__2 = awaiter.GetResult();
				_003Cguild_003E5__1 = _003C_003Es__2;
				_003C_003Es__2 = null;
				result = ((_003Cguild_003E5__1 != null) ? Result<Guild>.SuccessResult(_003Cguild_003E5__1) : Result<Guild>.FailureResult("Guild with ID '" + request.GuildId + "' not found"));
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cguild_003E5__1 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cguild_003E5__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IGuildRepository _guildRepo;

	public GetGuildDetailsUseCase(IGuildRepository guildRepo)
	{
		_guildRepo = guildRepo;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__2))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<Guild>> ExecuteAsync(GetGuildDetailsRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrWhiteSpace(request.GuildId))
		{
			return Result<Guild>.FailureResult("Guild ID is required");
		}
		Guild guild = await _guildRepo.GetByIdAsync(request.GuildId);
		if (guild == null)
		{
			return Result<Guild>.FailureResult("Guild with ID '" + request.GuildId + "' not found");
		}
		return Result<Guild>.SuccessResult(guild);
	}
}
