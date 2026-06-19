using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Chat;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Chat;

public class GetChatMessagesUseCase : IUseCase<GetChatMessagesRequest, List<ChatMessage>>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<List<ChatMessage>>> _003C_003Et__builder;

		public GetChatMessagesRequest request;

		public GetChatMessagesUseCase _003C_003E4__this;

		private List<ChatMessage> _003Cmessages_003E5__1;

		private List<ChatMessage> _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<List<ChatMessage>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<List<ChatMessage>> result;
			try
			{
				if (num != 0 && string.IsNullOrEmpty(request.ConversationId))
				{
					result = Result<List<ChatMessage>>.FailureResult("Conversation ID is required");
				}
				else
				{
					try
					{
						TaskAwaiter<List<ChatMessage>> awaiter;
						if (num != 0)
						{
							awaiter = _003C_003E4__this._chatRepository.GetMessagesAsync(request.ConversationId, request.Limit, request.BeforeTimestamp).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CExecuteAsync_003Ed__2 _003CExecuteAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<ChatMessage>>, _003CExecuteAsync_003Ed__2>(ref awaiter, ref _003CExecuteAsync_003Ed__);
								return;
							}
						}
						else
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<List<ChatMessage>>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__2 = awaiter.GetResult();
						_003Cmessages_003E5__1 = _003C_003Es__2;
						_003C_003Es__2 = null;
						result = Result<List<ChatMessage>>.SuccessResult(_003Cmessages_003E5__1);
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__3 = ex;
						result = Result<List<ChatMessage>>.FailureResult("Failed to get messages: " + _003Cex_003E5__3.Message);
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

	private readonly IChatRepository _chatRepository;

	public GetChatMessagesUseCase(IChatRepository chatRepository)
	{
		_chatRepository = chatRepository;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__2))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<List<ChatMessage>>> ExecuteAsync(GetChatMessagesRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(request.ConversationId))
		{
			return Result<List<ChatMessage>>.FailureResult("Conversation ID is required");
		}
		try
		{
			return Result<List<ChatMessage>>.SuccessResult(await _chatRepository.GetMessagesAsync(request.ConversationId, request.Limit, request.BeforeTimestamp));
		}
		catch (global::System.Exception ex)
		{
			return Result<List<ChatMessage>>.FailureResult("Failed to get messages: " + ex.Message);
		}
	}
}
