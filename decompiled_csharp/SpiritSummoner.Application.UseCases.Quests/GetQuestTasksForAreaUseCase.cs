using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Quests;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Quests;

public class GetQuestTasksForAreaUseCase : IUseCase<GetQuestTasksRequest, GetQuestTasksResult>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public GetQuestTasksRequest request;

		internal bool _003CExecuteAsync_003Eb__1(Area a)
		{
			return a.Id == request.AreaId;
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<GetQuestTasksResult>> _003C_003Et__builder;

		public GetQuestTasksRequest request;

		public GetQuestTasksForAreaUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass3_0 _003C_003E8__1;

		private Player _003Cplayer_003E5__2;

		private global::System.Collections.Generic.IReadOnlyList<QuestTask> _003CquestTasks_003E5__3;

		private global::System.Collections.Generic.IReadOnlyList<Area> _003Careas_003E5__4;

		private PlayerQuest _003CplayerQuest_003E5__5;

		private global::System.Collections.Generic.IReadOnlyList<QuestTask> _003C_003Es__6;

		private global::System.Collections.Generic.IReadOnlyList<Area> _003C_003Es__7;

		private TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<QuestTask>> _003C_003Eu__1;

		private TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Area>> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<GetQuestTasksResult> result;
			try
			{
				TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<QuestTask>> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<QuestTask>>);
					num = (_003C_003E1__state = -1);
					goto IL_00ef;
				}
				TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Area>> awaiter2;
				if (num == 1)
				{
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Area>>);
					num = (_003C_003E1__state = -1);
					goto IL_01b4;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass3_0();
				_003C_003E8__1.request = request;
				_003Cplayer_003E5__2 = _003C_003E4__this._stateService.GetCurrentPlayer();
				if (_003Cplayer_003E5__2 != null)
				{
					awaiter = _003C_003E4__this._questRepository.GetTasksForAreaAsync(_003C_003E8__1.request.QuestType, _003C_003E8__1.request.AreaId).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<QuestTask>>, _003CExecuteAsync_003Ed__3>(ref awaiter, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_00ef;
				}
				result = Result<GetQuestTasksResult>.FailureResult("Player not found");
				goto end_IL_0007;
				IL_01b4:
				_003C_003Es__7 = awaiter2.GetResult();
				_003Careas_003E5__4 = _003C_003Es__7;
				_003C_003Es__7 = null;
				IReadOnlyDictionary<string, PlayerQuest> playerQuests = _003Cplayer_003E5__2.PlayerQuests;
				_003CplayerQuest_003E5__5 = ((playerQuests != null) ? CollectionExtensions.GetValueOrDefault<string, PlayerQuest>(playerQuests, _003C_003E8__1.request.QuestType) : null);
				result = Result<GetQuestTasksResult>.SuccessResult(new GetQuestTasksResult
				{
					QuestTasks = Enumerable.ToList<QuestTask>((global::System.Collections.Generic.IEnumerable<QuestTask>)Enumerable.OrderBy<QuestTask, int>((global::System.Collections.Generic.IEnumerable<QuestTask>)_003CquestTasks_003E5__3, (Func<QuestTask, int>)((QuestTask t) => t.Order))),
					PlayerQuest = _003CplayerQuest_003E5__5,
					QuestId = _003C_003E8__1.request.QuestType,
					AreaName = (Enumerable.FirstOrDefault<Area>((global::System.Collections.Generic.IEnumerable<Area>)_003Careas_003E5__4, (Func<Area, bool>)((Area a) => a.Id == _003C_003E8__1.request.AreaId))?.Name ?? "")
				});
				goto end_IL_0007;
				IL_00ef:
				_003C_003Es__6 = awaiter.GetResult();
				_003CquestTasks_003E5__3 = _003C_003Es__6;
				_003C_003Es__6 = null;
				if (_003CquestTasks_003E5__3 != null && Enumerable.Any<QuestTask>((global::System.Collections.Generic.IEnumerable<QuestTask>)_003CquestTasks_003E5__3))
				{
					awaiter2 = _003C_003E4__this._questRepository.GetAreasForQuestAsync(_003C_003E8__1.request.QuestType).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter2;
						_003CExecuteAsync_003Ed__3 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Area>>, _003CExecuteAsync_003Ed__3>(ref awaiter2, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_01b4;
				}
				result = Result<GetQuestTasksResult>.FailureResult("No tasks found for this area");
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Cplayer_003E5__2 = null;
				_003CquestTasks_003E5__3 = null;
				_003Careas_003E5__4 = null;
				_003CplayerQuest_003E5__5 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Cplayer_003E5__2 = null;
			_003CquestTasks_003E5__3 = null;
			_003Careas_003E5__4 = null;
			_003CplayerQuest_003E5__5 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IPlayerStateService _stateService;

	private readonly IQuestRepository _questRepository;

	public GetQuestTasksForAreaUseCase(IPlayerStateService stateService, IQuestRepository questRepository)
	{
		_stateService = stateService;
		_questRepository = questRepository;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__3))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<GetQuestTasksResult>> ExecuteAsync(GetQuestTasksRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		GetQuestTasksRequest request2 = request;
		Player player = _stateService.GetCurrentPlayer();
		if (player == null)
		{
			return Result<GetQuestTasksResult>.FailureResult("Player not found");
		}
		global::System.Collections.Generic.IReadOnlyList<QuestTask> questTasks = await _questRepository.GetTasksForAreaAsync(request2.QuestType, request2.AreaId);
		if (questTasks == null || !Enumerable.Any<QuestTask>((global::System.Collections.Generic.IEnumerable<QuestTask>)questTasks))
		{
			return Result<GetQuestTasksResult>.FailureResult("No tasks found for this area");
		}
		global::System.Collections.Generic.IReadOnlyList<Area> areas = await _questRepository.GetAreasForQuestAsync(request2.QuestType);
		IReadOnlyDictionary<string, PlayerQuest> playerQuests = player.PlayerQuests;
		PlayerQuest playerQuest = ((playerQuests != null) ? CollectionExtensions.GetValueOrDefault<string, PlayerQuest>(playerQuests, request2.QuestType) : null);
		return Result<GetQuestTasksResult>.SuccessResult(new GetQuestTasksResult
		{
			QuestTasks = Enumerable.ToList<QuestTask>((global::System.Collections.Generic.IEnumerable<QuestTask>)Enumerable.OrderBy<QuestTask, int>((global::System.Collections.Generic.IEnumerable<QuestTask>)questTasks, (Func<QuestTask, int>)((QuestTask t) => t.Order))),
			PlayerQuest = playerQuest,
			QuestId = request2.QuestType,
			AreaName = (Enumerable.FirstOrDefault<Area>((global::System.Collections.Generic.IEnumerable<Area>)areas, (Func<Area, bool>)((Area a) => a.Id == request2.AreaId))?.Name ?? "")
		});
	}
}
