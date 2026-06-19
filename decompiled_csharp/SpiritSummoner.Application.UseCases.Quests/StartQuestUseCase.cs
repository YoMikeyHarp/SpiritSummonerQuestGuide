using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Quests;

public class StartQuestUseCase : IUseCase<StartQuestRequest, QuestProgress>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<QuestProgress>> _003C_003Et__builder;

		public StartQuestRequest request;

		public StartQuestUseCase _003C_003E4__this;

		private QuestProgress _003CquestProgress_003E5__1;

		private void MoveNext()
		{
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<QuestProgress> result;
			try
			{
				_003CquestProgress_003E5__1 = new QuestProgress
				{
					PlayerId = request.PlayerId,
					QuestId = request.QuestId,
					AreaId = request.AreaId,
					CurrentTaskId = null,
					CurrentStep = 0,
					IsCompleted = false,
					StartedAt = DateTimeOffset.UtcNow
				};
				result = Result<QuestProgress>.SuccessResult(_003CquestProgress_003E5__1);
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CquestProgress_003E5__1 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CquestProgress_003E5__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IQuestRepository _questRepo;

	public StartQuestUseCase(IQuestRepository questRepo)
	{
		_questRepo = questRepo;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__2))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<QuestProgress>> ExecuteAsync(StartQuestRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		QuestProgress questProgress = new QuestProgress
		{
			PlayerId = request.PlayerId,
			QuestId = request.QuestId,
			AreaId = request.AreaId,
			CurrentTaskId = null,
			CurrentStep = 0,
			IsCompleted = false,
			StartedAt = DateTimeOffset.UtcNow
		};
		return Result<QuestProgress>.SuccessResult(questProgress);
	}
}
