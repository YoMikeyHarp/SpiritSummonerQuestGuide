using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Chat;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Chat;

public class SendGuildThreadMessageUseCase : IUseCase<SendGuildThreadMessageRequest, bool>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<bool>> _003C_003Et__builder;

		public SendGuildThreadMessageRequest request;

		public SendGuildThreadMessageUseCase _003C_003E4__this;

		private Player _003CcurrentPlayer_003E5__1;

		private ChatMessage _003Cmessage_003E5__2;

		private bool _003Csuccess_003E5__3;

		private bool _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_019e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<bool> result;
			try
			{
				if (num == 0)
				{
					goto IL_00d2;
				}
				if (string.IsNullOrEmpty(request.GuildId) || string.IsNullOrEmpty(request.ThreadId))
				{
					result = Result<bool>.FailureResult("GuildId and ThreadId are required");
				}
				else if (string.IsNullOrWhiteSpace(request.Content))
				{
					result = Result<bool>.FailureResult("Message content is required");
				}
				else if (request.Content.Length > 500)
				{
					result = Result<bool>.FailureResult("Message too long (max 500 characters)");
				}
				else
				{
					_003CcurrentPlayer_003E5__1 = _003C_003E4__this._playerState.GetCurrentPlayer();
					if (_003CcurrentPlayer_003E5__1 != null)
					{
						goto IL_00d2;
					}
					result = Result<bool>.FailureResult("Not logged in");
				}
				goto end_IL_0007;
				IL_00d2:
				try
				{
					TaskAwaiter<bool> awaiter;
					if (num != 0)
					{
						_003Cmessage_003E5__2 = new ChatMessage
						{
							SenderId = _003CcurrentPlayer_003E5__1.PlayerID,
							SenderName = (_003CcurrentPlayer_003E5__1.Playername ?? "Unknown"),
							Content = request.Content.Trim(),
							CreatedAt = DateTimeOffset.UtcNow
						};
						awaiter = _003C_003E4__this._chatRepository.SendGuildThreadMessageAsync(request.GuildId, request.ThreadId, _003Cmessage_003E5__2).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CExecuteAsync_003Ed__3>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__4 = awaiter.GetResult();
					_003Csuccess_003E5__3 = _003C_003Es__4;
					result = (_003Csuccess_003E5__3 ? Result<bool>.SuccessResult(data: true) : Result<bool>.FailureResult("Failed to send message"));
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					result = Result<bool>.FailureResult("Failed to send message: " + _003Cex_003E5__5.Message);
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

	private readonly IChatRepository _chatRepository;

	private readonly IPlayerStateService _playerState;

	public SendGuildThreadMessageUseCase(IChatRepository chatRepository, IPlayerStateService playerState)
	{
		_chatRepository = chatRepository;
		_playerState = playerState;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__3))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<bool>> ExecuteAsync(SendGuildThreadMessageRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(request.GuildId) || string.IsNullOrEmpty(request.ThreadId))
		{
			return Result<bool>.FailureResult("GuildId and ThreadId are required");
		}
		if (string.IsNullOrWhiteSpace(request.Content))
		{
			return Result<bool>.FailureResult("Message content is required");
		}
		if (request.Content.Length > 500)
		{
			return Result<bool>.FailureResult("Message too long (max 500 characters)");
		}
		Player currentPlayer = _playerState.GetCurrentPlayer();
		if (currentPlayer == null)
		{
			return Result<bool>.FailureResult("Not logged in");
		}
		try
		{
			ChatMessage message = new ChatMessage
			{
				SenderId = currentPlayer.PlayerID,
				SenderName = (currentPlayer.Playername ?? "Unknown"),
				Content = request.Content.Trim(),
				CreatedAt = DateTimeOffset.UtcNow
			};
			return (await _chatRepository.SendGuildThreadMessageAsync(request.GuildId, request.ThreadId, message)) ? Result<bool>.SuccessResult(data: true) : Result<bool>.FailureResult("Failed to send message");
		}
		catch (global::System.Exception ex)
		{
			return Result<bool>.FailureResult("Failed to send message: " + ex.Message);
		}
	}
}
