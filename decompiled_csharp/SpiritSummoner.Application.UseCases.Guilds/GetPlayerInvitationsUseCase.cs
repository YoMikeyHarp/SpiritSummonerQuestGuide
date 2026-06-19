using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Guilds;

public class GetPlayerInvitationsUseCase : IUseCase<GetPlayerInvitationsRequest, List<GuildInvitation>>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<List<GuildInvitation>>> _003C_003Et__builder;

		public GetPlayerInvitationsRequest request;

		public GetPlayerInvitationsUseCase _003C_003E4__this;

		private List<GuildInvitation> _003Cinvitations_003E5__1;

		private List<GuildInvitation> _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<List<GuildInvitation>> _003C_003Eu__1;

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
			Result<List<GuildInvitation>> result;
			try
			{
				if (num != 0 && string.IsNullOrWhiteSpace(request.PlayerId))
				{
					result = Result<List<GuildInvitation>>.FailureResult("Player ID is required");
				}
				else
				{
					try
					{
						TaskAwaiter<List<GuildInvitation>> awaiter;
						if (num != 0)
						{
							awaiter = _003C_003E4__this._guildRepository.GetPlayerInvitationsAsync(request.PlayerId).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CExecuteAsync_003Ed__2 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<GuildInvitation>>, _003CExecuteAsync_003Ed__2>(ref awaiter, ref _003CExecuteAsync_003Ed__);
								return;
							}
						}
						else
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<List<GuildInvitation>>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__2 = awaiter.GetResult();
						_003Cinvitations_003E5__1 = _003C_003Es__2;
						_003C_003Es__2 = null;
						result = ((_003Cinvitations_003E5__1 != null) ? Result<List<GuildInvitation>>.SuccessResult(_003Cinvitations_003E5__1) : Result<List<GuildInvitation>>.SuccessResult(new List<GuildInvitation>()));
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__3 = ex;
						result = Result<List<GuildInvitation>>.FailureResult("Failed to retrieve invitations: " + _003Cex_003E5__3.Message);
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

	public GetPlayerInvitationsUseCase(IGuildRepository guildRepository)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_guildRepository = guildRepository ?? throw new ArgumentNullException("guildRepository");
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__2))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<List<GuildInvitation>>> ExecuteAsync(GetPlayerInvitationsRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrWhiteSpace(request.PlayerId))
		{
			return Result<List<GuildInvitation>>.FailureResult("Player ID is required");
		}
		try
		{
			List<GuildInvitation> invitations = await _guildRepository.GetPlayerInvitationsAsync(request.PlayerId);
			if (invitations == null)
			{
				return Result<List<GuildInvitation>>.SuccessResult(new List<GuildInvitation>());
			}
			return Result<List<GuildInvitation>>.SuccessResult(invitations);
		}
		catch (global::System.Exception ex)
		{
			return Result<List<GuildInvitation>>.FailureResult("Failed to retrieve invitations: " + ex.Message);
		}
	}
}
