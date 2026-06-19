using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Enums.Guilds;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Guilds;

public class GetPendingJoinRequestsUseCase : IUseCase<GetPendingJoinRequestsRequest, List<GuildJoinRequest>>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<List<GuildJoinRequest>>> _003C_003Et__builder;

		public GetPendingJoinRequestsRequest request;

		public GetPendingJoinRequestsUseCase _003C_003E4__this;

		private List<GuildJoinRequest> _003CjoinRequests_003E5__1;

		private List<GuildJoinRequest> _003CpendingRequests_003E5__2;

		private List<GuildJoinRequest> _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<List<GuildJoinRequest>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<List<GuildJoinRequest>> result;
			try
			{
				if (num != 0 && string.IsNullOrWhiteSpace(request.GuildId))
				{
					result = Result<List<GuildJoinRequest>>.FailureResult("Guild ID is required");
				}
				else
				{
					try
					{
						TaskAwaiter<List<GuildJoinRequest>> awaiter;
						if (num != 0)
						{
							awaiter = _003C_003E4__this._guildRepository.GetPendingJoinRequestsAsync(request.GuildId).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CExecuteAsync_003Ed__2 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<GuildJoinRequest>>, _003CExecuteAsync_003Ed__2>(ref awaiter, ref _003CExecuteAsync_003Ed__);
								return;
							}
						}
						else
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<List<GuildJoinRequest>>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__3 = awaiter.GetResult();
						_003CjoinRequests_003E5__1 = _003C_003Es__3;
						_003C_003Es__3 = null;
						if (_003CjoinRequests_003E5__1 == null)
						{
							result = Result<List<GuildJoinRequest>>.SuccessResult(new List<GuildJoinRequest>());
						}
						else
						{
							_003CpendingRequests_003E5__2 = Enumerable.ToList<GuildJoinRequest>(Enumerable.Where<GuildJoinRequest>((global::System.Collections.Generic.IEnumerable<GuildJoinRequest>)_003CjoinRequests_003E5__1, (Func<GuildJoinRequest, bool>)((GuildJoinRequest r) => r.Status == JoinRequestStatus.Pending)));
							result = Result<List<GuildJoinRequest>>.SuccessResult(_003CpendingRequests_003E5__2);
						}
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__4 = ex;
						result = Result<List<GuildJoinRequest>>.FailureResult("Failed to retrieve join requests: " + _003Cex_003E5__4.Message);
					}
				}
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

	public GetPendingJoinRequestsUseCase(IGuildRepository guildRepository)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_guildRepository = guildRepository ?? throw new ArgumentNullException("guildRepository");
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__2))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<List<GuildJoinRequest>>> ExecuteAsync(GetPendingJoinRequestsRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrWhiteSpace(request.GuildId))
		{
			return Result<List<GuildJoinRequest>>.FailureResult("Guild ID is required");
		}
		try
		{
			List<GuildJoinRequest> joinRequests = await _guildRepository.GetPendingJoinRequestsAsync(request.GuildId);
			if (joinRequests == null)
			{
				return Result<List<GuildJoinRequest>>.SuccessResult(new List<GuildJoinRequest>());
			}
			List<GuildJoinRequest> pendingRequests = Enumerable.ToList<GuildJoinRequest>(Enumerable.Where<GuildJoinRequest>((global::System.Collections.Generic.IEnumerable<GuildJoinRequest>)joinRequests, (Func<GuildJoinRequest, bool>)((GuildJoinRequest r) => r.Status == JoinRequestStatus.Pending)));
			return Result<List<GuildJoinRequest>>.SuccessResult(pendingRequests);
		}
		catch (global::System.Exception ex)
		{
			return Result<List<GuildJoinRequest>>.FailureResult("Failed to retrieve join requests: " + ex.Message);
		}
	}
}
