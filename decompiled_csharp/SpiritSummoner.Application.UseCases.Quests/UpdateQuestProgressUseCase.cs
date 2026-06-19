using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Quests;

public class UpdateQuestProgressUseCase : IUseCase<UpdateQuestProgressRequest, QuestProgress>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<QuestProgress>> _003C_003Et__builder;

		public UpdateQuestProgressRequest request;

		public UpdateQuestProgressUseCase _003C_003E4__this;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			Result<QuestProgress> result;
			try
			{
				result = Result<QuestProgress>.SuccessResult(request.QuestProgress);
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

	private readonly IQuestRepository _questRepo;

	public UpdateQuestProgressUseCase(IQuestRepository questRepo)
	{
		_questRepo = questRepo;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__2))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<QuestProgress>> ExecuteAsync(UpdateQuestProgressRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return Result<QuestProgress>.SuccessResult(request.QuestProgress);
	}
}
