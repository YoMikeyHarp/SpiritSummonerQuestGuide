using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Entities.Players;

namespace SpiritSummoner.Application.UseCases.Quests;

public class CompleteQuestTaskUseCase : IUseCase<CompleteQuestTaskRequest, PlayerBatchUpdate>
{
	[CompilerGenerated]
	private sealed class _003CExecuteAsync_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Result<PlayerBatchUpdate>> _003C_003Et__builder;

		public CompleteQuestTaskRequest request;

		public CompleteQuestTaskUseCase _003C_003E4__this;

		private PlayerBatchUpdate _003CbatchUpdate_003E5__1;

		private Random _003Crandom_003E5__2;

		private Enumerator<Item> _003C_003Es__3;

		private Item _003Citem_003E5__4;

		private Result<PlayerBatchUpdate> _003C_003Es__5;

		private TaskAwaiter<Result<PlayerBatchUpdate>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_024d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0252: Unknown result type (might be due to invalid IL or missing references)
			//IL_025a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d6: Expected O, but got Unknown
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0216: Unknown result type (might be due to invalid IL or missing references)
			//IL_021b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0230: Unknown result type (might be due to invalid IL or missing references)
			//IL_0232: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Result<PlayerBatchUpdate> result;
			try
			{
				TaskAwaiter<Result<PlayerBatchUpdate>> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Result<PlayerBatchUpdate>>);
					num = (_003C_003E1__state = -1);
					goto IL_0269;
				}
				if (request.Player == null)
				{
					result = Result<PlayerBatchUpdate>.FailureResult("Player not found");
				}
				else
				{
					if (request.Task != null)
					{
						_003CbatchUpdate_003E5__1 = new PlayerBatchUpdate
						{
							PlayerId = (request.Player.PlayerID ?? string.Empty),
							QuestId = request.Task.Id,
							CurrencyChanges = new Dictionary<string, long> { ["gold"] = request.Task.Rewards.Gold },
							TaskUpdates = new Dictionary<string, TaskProgress> { [request.Task.Id] = new TaskProgress
							{
								IsCompleted = false,
								Step = 0
							} }
						};
						if (request.Task.Rewards.Items != null && request.Task.Rewards.Items.Count > 0)
						{
							_003C_003Es__3 = request.Task.Rewards.Items.GetEnumerator();
							try
							{
								while (_003C_003Es__3.MoveNext())
								{
									_003Citem_003E5__4 = _003C_003Es__3.Current;
									_003CbatchUpdate_003E5__1.AddInventoryChange(_003Citem_003E5__4.Name, 1);
									_003Citem_003E5__4 = null;
								}
							}
							finally
							{
								if (num < 0)
								{
									((global::System.IDisposable)_003C_003Es__3).Dispose();
								}
							}
							_003C_003Es__3 = default(Enumerator<Item>);
						}
						_003Crandom_003E5__2 = new Random();
						if (_003Crandom_003E5__2.NextDouble() < 0.15)
						{
							_003CbatchUpdate_003E5__1.AddInventoryChange("soulOrbFragment", 1);
						}
						awaiter = global::System.Threading.Tasks.Task.FromResult<Result<PlayerBatchUpdate>>(Result<PlayerBatchUpdate>.SuccessResult(_003CbatchUpdate_003E5__1)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CExecuteAsync_003Ed__1 _003CExecuteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Result<PlayerBatchUpdate>>, _003CExecuteAsync_003Ed__1>(ref awaiter, ref _003CExecuteAsync_003Ed__);
							return;
						}
						goto IL_0269;
					}
					result = Result<PlayerBatchUpdate>.FailureResult("Quest task not found");
				}
				goto end_IL_0007;
				IL_0269:
				_003C_003Es__5 = awaiter.GetResult();
				result = _003C_003Es__5;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CbatchUpdate_003E5__1 = null;
				_003Crandom_003E5__2 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CbatchUpdate_003E5__1 = null;
			_003Crandom_003E5__2 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private const double SOUL_ORB_FRAGMENT_DROP_CHANCE = 0.15;

	[AsyncStateMachine(typeof(_003CExecuteAsync_003Ed__1))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Result<PlayerBatchUpdate>> ExecuteAsync(CompleteQuestTaskRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (request.Player == null)
		{
			return Result<PlayerBatchUpdate>.FailureResult("Player not found");
		}
		if (request.Task == null)
		{
			return Result<PlayerBatchUpdate>.FailureResult("Quest task not found");
		}
		PlayerBatchUpdate batchUpdate = new PlayerBatchUpdate
		{
			PlayerId = (request.Player.PlayerID ?? string.Empty),
			QuestId = request.Task.Id,
			CurrencyChanges = new Dictionary<string, long> { ["gold"] = request.Task.Rewards.Gold },
			TaskUpdates = new Dictionary<string, TaskProgress> { [request.Task.Id] = new TaskProgress
			{
				IsCompleted = false,
				Step = 0
			} }
		};
		if (request.Task.Rewards.Items != null && request.Task.Rewards.Items.Count > 0)
		{
			Enumerator<Item> enumerator = request.Task.Rewards.Items.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Item item = enumerator.Current;
					batchUpdate.AddInventoryChange(item.Name, 1);
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator).Dispose();
			}
		}
		Random random = new Random();
		if (random.NextDouble() < 0.15)
		{
			batchUpdate.AddInventoryChange("soulOrbFragment", 1);
		}
		return await global::System.Threading.Tasks.Task.FromResult<Result<PlayerBatchUpdate>>(Result<PlayerBatchUpdate>.SuccessResult(batchUpdate));
	}
}
