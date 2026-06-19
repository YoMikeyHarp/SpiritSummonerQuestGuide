using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Quests;
using SpiritSummoner.Domain.Repositories;

namespace SpiritSummoner.Application.UseCases.Quests;

public class GetQuestAreasUseCase : IUseCase<GetQuestAreasRequest, List<Area>>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public GetQuestAreasRequest request;

		internal bool _003CExecuteAsync_003Eb__0(Area a)
		{
			return a.LevelRequired <= request.PlayerLevel;
		}

		internal bool _003CExecuteAsync_003Eb__1(Area a)
		{
			return string.IsNullOrEmpty(a.TaskRequired) || Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)request.CompletedTaskKeys, a.TaskRequired);
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<List<Area>>> _003C_003Et__builder;

		public GetQuestAreasRequest request;

		public GetQuestAreasUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass2_0 _003C_003E8__1;

		private global::System.Collections.Generic.IReadOnlyList<Area> _003Careas_003E5__2;

		private List<Area> _003CavailableAreas_003E5__3;

		private global::System.Collections.Generic.IReadOnlyList<Area> _003C_003Es__4;

		private TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Area>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<List<Area>> result;
			try
			{
				TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Area>> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Area>>);
					num = (_003C_003E1__state = -1);
					goto IL_00f4;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass2_0();
				_003C_003E8__1.request = request;
				if (string.IsNullOrEmpty(_003C_003E8__1.request.QuestId))
				{
					result = Result<List<Area>>.FailureResult("Quest ID is required");
				}
				else
				{
					if (_003C_003E8__1.request.PlayerLevel >= 0)
					{
						awaiter = _003C_003E4__this._questRepo.GetAreasForQuestAsync(_003C_003E8__1.request.QuestId).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CExecuteAsync_003Ed__2 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<global::System.Collections.Generic.IReadOnlyList<Area>>, _003CExecuteAsync_003Ed__2>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_00f4;
					}
					result = Result<List<Area>>.FailureResult("Invalid player level");
				}
				goto end_IL_0007;
				IL_00f4:
				_003C_003Es__4 = awaiter.GetResult();
				_003Careas_003E5__2 = _003C_003Es__4;
				_003C_003Es__4 = null;
				if (_003Careas_003E5__2 == null || !Enumerable.Any<Area>((global::System.Collections.Generic.IEnumerable<Area>)_003Careas_003E5__2))
				{
					result = Result<List<Area>>.FailureResult("No areas found for quest " + _003C_003E8__1.request.QuestId);
				}
				else
				{
					_003CavailableAreas_003E5__3 = Enumerable.ToList<Area>(Enumerable.Select<Area, Area>((global::System.Collections.Generic.IEnumerable<Area>)Enumerable.OrderBy<Area, int>(Enumerable.Where<Area>(Enumerable.Where<Area>((global::System.Collections.Generic.IEnumerable<Area>)_003Careas_003E5__2, (Func<Area, bool>)((Area a) => a.LevelRequired <= _003C_003E8__1.request.PlayerLevel)), (Func<Area, bool>)((Area a) => string.IsNullOrEmpty(a.TaskRequired) || Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)_003C_003E8__1.request.CompletedTaskKeys, a.TaskRequired))), (Func<Area, int>)((Area a) => a.Order)), (Func<Area, Area>)((Area a) => new Area
					{
						Id = (a.Id ?? string.Empty),
						Name = (a.Name ?? string.Empty),
						Order = a.Order,
						LevelRequired = a.LevelRequired,
						Image = (a.Image ?? string.Empty),
						IsSelected = a.IsSelected,
						TaskRequired = a.TaskRequired
					})));
					result = (Enumerable.Any<Area>((global::System.Collections.Generic.IEnumerable<Area>)_003CavailableAreas_003E5__3) ? Result<List<Area>>.SuccessResult(_003CavailableAreas_003E5__3) : Result<List<Area>>.FailureResult("No areas available at your level"));
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Careas_003E5__2 = null;
				_003CavailableAreas_003E5__3 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Careas_003E5__2 = null;
			_003CavailableAreas_003E5__3 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IQuestRepository _questRepo;

	public GetQuestAreasUseCase(IQuestRepository questRepo)
	{
		_questRepo = questRepo;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__2))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<List<Area>>> ExecuteAsync(GetQuestAreasRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		GetQuestAreasRequest request2 = request;
		if (string.IsNullOrEmpty(request2.QuestId))
		{
			return Result<List<Area>>.FailureResult("Quest ID is required");
		}
		if (request2.PlayerLevel < 0)
		{
			return Result<List<Area>>.FailureResult("Invalid player level");
		}
		global::System.Collections.Generic.IReadOnlyList<Area> areas = await _questRepo.GetAreasForQuestAsync(request2.QuestId);
		if (areas == null || !Enumerable.Any<Area>((global::System.Collections.Generic.IEnumerable<Area>)areas))
		{
			return Result<List<Area>>.FailureResult("No areas found for quest " + request2.QuestId);
		}
		List<Area> availableAreas = Enumerable.ToList<Area>(Enumerable.Select<Area, Area>((global::System.Collections.Generic.IEnumerable<Area>)Enumerable.OrderBy<Area, int>(Enumerable.Where<Area>(Enumerable.Where<Area>((global::System.Collections.Generic.IEnumerable<Area>)areas, (Func<Area, bool>)((Area a) => a.LevelRequired <= request2.PlayerLevel)), (Func<Area, bool>)((Area a) => string.IsNullOrEmpty(a.TaskRequired) || Enumerable.Contains<string>((global::System.Collections.Generic.IEnumerable<string>)request2.CompletedTaskKeys, a.TaskRequired))), (Func<Area, int>)((Area a) => a.Order)), (Func<Area, Area>)((Area a) => new Area
		{
			Id = (a.Id ?? string.Empty),
			Name = (a.Name ?? string.Empty),
			Order = a.Order,
			LevelRequired = a.LevelRequired,
			Image = (a.Image ?? string.Empty),
			IsSelected = a.IsSelected,
			TaskRequired = a.TaskRequired
		})));
		if (!Enumerable.Any<Area>((global::System.Collections.Generic.IEnumerable<Area>)availableAreas))
		{
			return Result<List<Area>>.FailureResult("No areas available at your level");
		}
		return Result<List<Area>>.SuccessResult(availableAreas);
	}
}
