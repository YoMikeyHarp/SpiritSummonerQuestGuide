using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Chat;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Chat;

public class GetGuildThreadMessagesUseCase : IUseCase<GetGuildThreadMessagesRequest, List<ChatMessage>>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<List<ChatMessage>>> _003C_003Et__builder;

		public GetGuildThreadMessagesRequest request;

		public GetGuildThreadMessagesUseCase _003C_003E4__this;

		private List<ChatMessage> _003Cmessages_003E5__1;

		private List<ChatMessage> _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<List<ChatMessage>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<List<ChatMessage>> result;
			try
			{
				if (num != 0 && (string.IsNullOrEmpty(request.GuildId) || string.IsNullOrEmpty(request.ThreadId)))
				{
					result = Result<List<ChatMessage>>.FailureResult("GuildId and ThreadId are required");
				}
				else
				{
					try
					{
						TaskAwaiter<List<ChatMessage>> awaiter;
						if (num != 0)
						{
							awaiter = _003C_003E4__this._chatRepository.GetGuildThreadMessagesAsync(request.GuildId, request.ThreadId, request.Limit, request.BeforeTimestamp).GetAwaiter();
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

	public GetGuildThreadMessagesUseCase(IChatRepository chatRepository)
	{
		_chatRepository = chatRepository;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__2))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<List<ChatMessage>>> ExecuteAsync(GetGuildThreadMessagesRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(request.GuildId) || string.IsNullOrEmpty(request.ThreadId))
		{
			return Result<List<ChatMessage>>.FailureResult("GuildId and ThreadId are required");
		}
		try
		{
			return Result<List<ChatMessage>>.SuccessResult(await _chatRepository.GetGuildThreadMessagesAsync(request.GuildId, request.ThreadId, request.Limit, request.BeforeTimestamp));
		}
		catch (global::System.Exception ex)
		{
			return Result<List<ChatMessage>>.FailureResult("Failed to get messages: " + ex.Message);
		}
	}
}
