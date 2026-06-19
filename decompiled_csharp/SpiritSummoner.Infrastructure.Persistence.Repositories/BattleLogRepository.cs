using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Plugin.Firebase.Firestore;
using SpiritSummoner.Domain.Entities.Battles;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Battles;

namespace SpiritSummoner.Infrastructure.Persistence.Repositories;

public class BattleLogRepository : IBattleLogRepository
{
	[CompilerGenerated]
	private sealed class _003CWriteAsync_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public BattleLog log;

		public BattleLogRepository _003C_003E4__this;

		private FirestoreBattleLogDTO _003Cdto_003E5__1;

		private global::System.Exception _003Cex_003E5__2;

		private TaskAwaiter<IDocumentReference> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IDocumentReference> awaiter;
					if (num != 0)
					{
						_003Cdto_003E5__1 = FirestoreBattleLogDTO.FromEntity(log);
						awaiter = _003C_003E4__this._firestore.GetCollection("battleLogs").AddDocumentAsync((object)_003Cdto_003E5__1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CWriteAsync_003Ed__3 _003CWriteAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentReference>, _003CWriteAsync_003Ed__3>(ref awaiter, ref _003CWriteAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentReference>);
						num = (_003C_003E1__state = -1);
					}
					awaiter.GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__2 = ex;
					Console.WriteLine("Error writing battle log: " + _003Cex_003E5__2.Message);
					result = false;
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

	private readonly IFirebaseFirestore _firestore;

	private const string CollectionName = "battleLogs";

	public BattleLogRepository(IFirebaseFirestore firestore)
	{
		_firestore = firestore;
	}

	[AsyncStateMachine(typeof(_003CWriteAsync_003Ed__3))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> WriteAsync(BattleLog log)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			FirestoreBattleLogDTO dto = FirestoreBattleLogDTO.FromEntity(log);
			await _firestore.GetCollection("battleLogs").AddDocumentAsync((object)dto);
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error writing battle log: " + ex.Message);
			return false;
		}
	}
}
