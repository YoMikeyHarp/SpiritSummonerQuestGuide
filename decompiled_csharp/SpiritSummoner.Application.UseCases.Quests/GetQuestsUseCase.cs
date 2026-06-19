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

public class GetQuestsUseCase : IUseCase<GetQuestsRequest, List<Quest>>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public GetQuestsRequest request;

		internal bool _003CExecuteAsync_003Eb__0(KeyValuePair<string, Quest> q)
		{
			return q.Value.IsActive && q.Value.LevelRequired <= request.PlayerLevel;
		}
	}

	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<List<Quest>>> _003C_003Et__builder;

		public GetQuestsRequest request;

		public GetQuestsUseCase _003C_003E4__this;

		private _003C_003Ec__DisplayClass2_0 _003C_003E8__1;

		private IReadOnlyDictionary<string, Quest> _003CallQuests_003E5__2;

		private List<Quest> _003CavailableQuests_003E5__3;

		private IReadOnlyDictionary<string, Quest> _003C_003Es__4;

		private TaskAwaiter<IReadOnlyDictionary<string, Quest>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<List<Quest>> result;
			try
			{
				TaskAwaiter<IReadOnlyDictionary<string, Quest>> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<IReadOnlyDictionary<string, Quest>>);
					num = (_003C_003E1__state = -1);
					goto IL_00b8;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass2_0();
				_003C_003E8__1.request = request;
				if (_003C_003E8__1.request.PlayerLevel >= 0)
				{
					awaiter = _003C_003E4__this._questRepo.GetAllQuestsAsync().GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CExecuteAsync_003Ed__2 _003CExecuteAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IReadOnlyDictionary<string, Quest>>, _003CExecuteAsync_003Ed__2>(ref awaiter, ref _003CExecuteAsync_003Ed__);
						return;
					}
					goto IL_00b8;
				}
				result = Result<List<Quest>>.FailureResult("Invalid player level");
				goto end_IL_0007;
				IL_00b8:
				_003C_003Es__4 = awaiter.GetResult();
				_003CallQuests_003E5__2 = _003C_003Es__4;
				_003C_003Es__4 = null;
				if (_003CallQuests_003E5__2 == null || !Enumerable.Any<KeyValuePair<string, Quest>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, Quest>>)_003CallQuests_003E5__2))
				{
					result = Result<List<Quest>>.FailureResult("No quests available");
				}
				else
				{
					_003CavailableQuests_003E5__3 = Enumerable.ToList<Quest>(Enumerable.Select<KeyValuePair<string, Quest>, Quest>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, Quest>>)Enumerable.OrderBy<KeyValuePair<string, Quest>, int>(Enumerable.Where<KeyValuePair<string, Quest>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, Quest>>)_003CallQuests_003E5__2, (Func<KeyValuePair<string, Quest>, bool>)((KeyValuePair<string, Quest> q) => q.Value.IsActive && q.Value.LevelRequired <= _003C_003E8__1.request.PlayerLevel)), (Func<KeyValuePair<string, Quest>, int>)((KeyValuePair<string, Quest> q) => q.Value.Order)), (Func<KeyValuePair<string, Quest>, Quest>)((KeyValuePair<string, Quest> q) => new Quest
					{
						Id = (q.Value.Id ?? string.Empty),
						Name = (q.Value.Name ?? string.Empty),
						Order = q.Value.Order,
						Image = (q.Value.Image ?? string.Empty),
						LevelRequired = q.Value.LevelRequired,
						IsActive = q.Value.IsActive,
						Event = q.Value.Event
					})));
					result = Result<List<Quest>>.SuccessResult(_003CavailableQuests_003E5__3);
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003CallQuests_003E5__2 = null;
				_003CavailableQuests_003E5__3 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003CallQuests_003E5__2 = null;
			_003CavailableQuests_003E5__3 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IQuestRepository _questRepo;

	public GetQuestsUseCase(IQuestRepository questRepo)
	{
		_questRepo = questRepo;
	}

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__2))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<List<Quest>>> ExecuteAsync(GetQuestsRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		GetQuestsRequest request2 = request;
		if (request2.PlayerLevel < 0)
		{
			return Result<List<Quest>>.FailureResult("Invalid player level");
		}
		IReadOnlyDictionary<string, Quest> allQuests = await _questRepo.GetAllQuestsAsync();
		if (allQuests == null || !Enumerable.Any<KeyValuePair<string, Quest>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, Quest>>)allQuests))
		{
			return Result<List<Quest>>.FailureResult("No quests available");
		}
		List<Quest> availableQuests = Enumerable.ToList<Quest>(Enumerable.Select<KeyValuePair<string, Quest>, Quest>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, Quest>>)Enumerable.OrderBy<KeyValuePair<string, Quest>, int>(Enumerable.Where<KeyValuePair<string, Quest>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, Quest>>)allQuests, (Func<KeyValuePair<string, Quest>, bool>)((KeyValuePair<string, Quest> q) => q.Value.IsActive && q.Value.LevelRequired <= request2.PlayerLevel)), (Func<KeyValuePair<string, Quest>, int>)((KeyValuePair<string, Quest> q) => q.Value.Order)), (Func<KeyValuePair<string, Quest>, Quest>)((KeyValuePair<string, Quest> q) => new Quest
		{
			Id = (q.Value.Id ?? string.Empty),
			Name = (q.Value.Name ?? string.Empty),
			Order = q.Value.Order,
			Image = (q.Value.Image ?? string.Empty),
			LevelRequired = q.Value.LevelRequired,
			IsActive = q.Value.IsActive,
			Event = q.Value.Event
		})));
		return Result<List<Quest>>.SuccessResult(availableQuests);
	}
}
