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

public class CreateGuildThreadUseCase : IUseCase<CreateGuildThreadRequest, Conversation>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<Conversation>> _003C_003Et__builder;

		public CreateGuildThreadRequest request;

		public CreateGuildThreadUseCase _003C_003E4__this;

		private Player _003CcurrentPlayer_003E5__1;

		private Conversation _003Cthread_003E5__2;

		private Conversation _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<Conversation?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<Conversation> result;
			try
			{
				if (num == 0)
				{
					goto IL_00ba;
				}
				if (string.IsNullOrEmpty(request.GuildId))
				{
					result = Result<Conversation>.FailureResult("Guild ID is required");
				}
				else if (string.IsNullOrWhiteSpace(request.Subject))
				{
					result = Result<Conversation>.FailureResult("Subject is required");
				}
				else if (request.Subject.Length > 80)
				{
					result = Result<Conversation>.FailureResult("Subject too long (max 80 characters)");
				}
				else
				{
					_003CcurrentPlayer_003E5__1 = _003C_003E4__this._playerState.GetCurrentPlayer();
					if (_003CcurrentPlayer_003E5__1 != null)
					{
						goto IL_00ba;
					}
					result = Result<Conversation>.FailureResult("Not logged in");
				}
				goto end_IL_0007;
				IL_00ba:
				try
				{
					TaskAwaiter<Conversation> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._chatRepository.CreateGuildThreadAsync(request.GuildId, request.Subject.Trim(), request.Icon, _003CcurrentPlayer_003E5__1.PlayerID).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Conversation>, _003CExecuteAsync_003Ed__3>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Conversation>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter.GetResult();
					_003Cthread_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					result = ((_003Cthread_003E5__2 != null) ? Result<Conversation>.SuccessResult(_003Cthread_003E5__2) : Result<Conversation>.FailureResult("Failed to create thread"));
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					result = Result<Conversation>.FailureResult("Failed to create thread: " + _003Cex_003E5__4.Message);
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

	public CreateGuildThreadUseCase(IChatRepository chatRepository, IPlayerStateService playerState)
	{
		_chatRepository = chatRepository;
		_playerState = playerState;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__3))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<Conversation>> ExecuteAsync(CreateGuildThreadRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(request.GuildId))
		{
			return Result<Conversation>.FailureResult("Guild ID is required");
		}
		if (string.IsNullOrWhiteSpace(request.Subject))
		{
			return Result<Conversation>.FailureResult("Subject is required");
		}
		if (request.Subject.Length > 80)
		{
			return Result<Conversation>.FailureResult("Subject too long (max 80 characters)");
		}
		Player currentPlayer = _playerState.GetCurrentPlayer();
		if (currentPlayer == null)
		{
			return Result<Conversation>.FailureResult("Not logged in");
		}
		try
		{
			Conversation thread = await _chatRepository.CreateGuildThreadAsync(request.GuildId, request.Subject.Trim(), request.Icon, currentPlayer.PlayerID);
			return (thread != null) ? Result<Conversation>.SuccessResult(thread) : Result<Conversation>.FailureResult("Failed to create thread");
		}
		catch (global::System.Exception ex)
		{
			return Result<Conversation>.FailureResult("Failed to create thread: " + ex.Message);
		}
	}
}
