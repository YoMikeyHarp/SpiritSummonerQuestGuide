using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Guilds;

public class ManageGuildInvitationsUseCase : IUseCase<GuildInvitationRequest, GuildInvitationResult>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<GuildInvitationResult>> _003C_003Et__builder;

		public GuildInvitationRequest request;

		public ManageGuildInvitationsUseCase _003C_003E4__this;

		private Guild _003Cguild_003E5__1;

		private bool _003Csuccess_003E5__2;

		private string _003Cmessage_003E5__3;

		private Guild _003C_003Es__4;

		private InvitationAction _003C_003Es__5;

		private bool _003C_003Es__6;

		private bool _003C_003Es__7;

		private bool _003C_003Es__8;

		private TaskAwaiter<Guild?> _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_029d: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0382: Unknown result type (might be due to invalid IL or missing references)
			//IL_0387: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_039c: Unknown result type (might be due to invalid IL or missing references)
			//IL_039e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<GuildInvitationResult> result;
			try
			{
				TaskAwaiter<Guild> awaiter4;
				TaskAwaiter<bool> awaiter3;
				TaskAwaiter<bool> awaiter2;
				TaskAwaiter<bool> awaiter;
				switch (num)
				{
				default:
					if (string.IsNullOrWhiteSpace(request.GuildId))
					{
						result = Result<GuildInvitationResult>.FailureResult("Guild ID is required");
					}
					else
					{
						if (!string.IsNullOrWhiteSpace(request.ActioningPlayerId))
						{
							awaiter4 = _003C_003E4__this._guildRepository.GetByIdAsync(request.GuildId).GetAwaiter();
							if (!awaiter4.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter4;
								_003CExecuteAsync_003Ed__2 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CExecuteAsync_003Ed__2>(ref awaiter4, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_00ed;
						}
						result = Result<GuildInvitationResult>.FailureResult("Player ID is required");
					}
					goto end_IL_0007;
				case 0:
					awaiter4 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Guild>);
					num = (_003C_003E1__state = -1);
					goto IL_00ed;
				case 1:
					awaiter3 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_020e;
				case 2:
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_02f3;
				case 3:
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_03d8;
					}
					IL_0246:
					if (!string.IsNullOrWhiteSpace(request.JoinRequestId))
					{
						awaiter2 = _003C_003E4__this._guildRepository.ApproveJoinRequestAsync(request.GuildId, request.JoinRequestId, request.ActioningPlayerId).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter2;
							_003CExecuteAsync_003Ed__2 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__2>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_02f3;
					}
					result = Result<GuildInvitationResult>.FailureResult("Join request ID is required");
					goto end_IL_0007;
					IL_03d8:
					_003C_003Es__8 = awaiter.GetResult();
					_003Csuccess_003E5__2 = _003C_003Es__8;
					_003Cmessage_003E5__3 = (_003Csuccess_003E5__2 ? "Join request rejected" : "Failed to reject join request");
					break;
					IL_032b:
					if (!string.IsNullOrWhiteSpace(request.JoinRequestId))
					{
						awaiter = _003C_003E4__this._guildRepository.RejectJoinRequestAsync(request.GuildId, request.JoinRequestId, request.ActioningPlayerId).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__2 = awaiter;
							_003CExecuteAsync_003Ed__2 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__2>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_03d8;
					}
					result = Result<GuildInvitationResult>.FailureResult("Join request ID is required");
					goto end_IL_0007;
					IL_02f3:
					_003C_003Es__7 = awaiter2.GetResult();
					_003Csuccess_003E5__2 = _003C_003Es__7;
					_003Cmessage_003E5__3 = (_003Csuccess_003E5__2 ? "Join request approved" : "Failed to approve join request");
					break;
					IL_020e:
					_003C_003Es__6 = awaiter3.GetResult();
					_003Csuccess_003E5__2 = _003C_003Es__6;
					_003Cmessage_003E5__3 = (_003Csuccess_003E5__2 ? "Invitation sent successfully" : "Failed to send invitation. Player may have already been invited.");
					break;
					IL_00ed:
					_003C_003Es__4 = awaiter4.GetResult();
					_003Cguild_003E5__1 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003Cguild_003E5__1 == null)
					{
						result = Result<GuildInvitationResult>.FailureResult("Guild not found");
					}
					else
					{
						InvitationAction action = request.Action;
						_003C_003Es__5 = action;
						switch (_003C_003Es__5)
						{
						case InvitationAction.SendInvitation:
							break;
						case InvitationAction.ApproveJoinRequest:
							goto IL_0246;
						case InvitationAction.RejectJoinRequest:
							goto IL_032b;
						default:
							result = Result<GuildInvitationResult>.FailureResult("Invalid action");
							goto end_IL_0007;
						}
						if (!string.IsNullOrWhiteSpace(request.TargetPlayerId))
						{
							awaiter3 = _003C_003E4__this._guildRepository.SendGuildInvitationAsync(request.GuildId, request.TargetPlayerId, request.ActioningPlayerId).GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter3;
								_003CExecuteAsync_003Ed__2 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__2>(ref awaiter3, ref _003CExecuteAsync_003Ed__);
								return;
							}
							goto IL_020e;
						}
						result = Result<GuildInvitationResult>.FailureResult("Target player ID is required");
					}
					goto end_IL_0007;
				}
				result = (_003Csuccess_003E5__2 ? Result<GuildInvitationResult>.SuccessResult(new GuildInvitationResult
				{
					Success = true,
					Message = _003Cmessage_003E5__3
				}) : Result<GuildInvitationResult>.FailureResult(_003Cmessage_003E5__3));
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cguild_003E5__1 = null;
				_003Cmessage_003E5__3 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cguild_003E5__1 = null;
			_003Cmessage_003E5__3 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IGuildRepository _guildRepository;

	public ManageGuildInvitationsUseCase(IGuildRepository guildRepository)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_guildRepository = guildRepository ?? throw new ArgumentNullException("guildRepository");
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__2))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<GuildInvitationResult>> ExecuteAsync(GuildInvitationRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrWhiteSpace(request.GuildId))
		{
			return Result<GuildInvitationResult>.FailureResult("Guild ID is required");
		}
		if (string.IsNullOrWhiteSpace(request.ActioningPlayerId))
		{
			return Result<GuildInvitationResult>.FailureResult("Player ID is required");
		}
		if (await _guildRepository.GetByIdAsync(request.GuildId) == null)
		{
			return Result<GuildInvitationResult>.FailureResult("Guild not found");
		}
		bool success;
		string message;
		switch (request.Action)
		{
		case InvitationAction.SendInvitation:
			if (string.IsNullOrWhiteSpace(request.TargetPlayerId))
			{
				return Result<GuildInvitationResult>.FailureResult("Target player ID is required");
			}
			success = await _guildRepository.SendGuildInvitationAsync(request.GuildId, request.TargetPlayerId, request.ActioningPlayerId);
			message = (success ? "Invitation sent successfully" : "Failed to send invitation. Player may have already been invited.");
			break;
		case InvitationAction.ApproveJoinRequest:
			if (string.IsNullOrWhiteSpace(request.JoinRequestId))
			{
				return Result<GuildInvitationResult>.FailureResult("Join request ID is required");
			}
			success = await _guildRepository.ApproveJoinRequestAsync(request.GuildId, request.JoinRequestId, request.ActioningPlayerId);
			message = (success ? "Join request approved" : "Failed to approve join request");
			break;
		case InvitationAction.RejectJoinRequest:
			if (string.IsNullOrWhiteSpace(request.JoinRequestId))
			{
				return Result<GuildInvitationResult>.FailureResult("Join request ID is required");
			}
			success = await _guildRepository.RejectJoinRequestAsync(request.GuildId, request.JoinRequestId, request.ActioningPlayerId);
			message = (success ? "Join request rejected" : "Failed to reject join request");
			break;
		default:
			return Result<GuildInvitationResult>.FailureResult("Invalid action");
		}
		if (!success)
		{
			return Result<GuildInvitationResult>.FailureResult(message);
		}
		return Result<GuildInvitationResult>.SuccessResult(new GuildInvitationResult
		{
			Success = true,
			Message = message
		});
	}
}
