using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Plugin.Firebase.Firestore;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Caching;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Moves;
using SpiritSummoner.Infrastructure.Persistence.Mapping;

namespace SpiritSummoner.Infrastructure.Persistence.Repositories;

public class MoveRepository : IMoveRepository
{
	[CompilerGenerated]
	private sealed class _003CGetAllAsync_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<IReadOnlyDictionary<string, Move>> _003C_003Et__builder;

		public MoveRepository _003C_003E4__this;

		private IQuerySnapshot<FirestoreMoveDTO> _003CfirestoreMoves_003E5__1;

		private IQuerySnapshot<FirestoreMoveDTO> _003C_003Es__2;

		private global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreMoveDTO>> _003C_003Es__3;

		private IDocumentSnapshot<FirestoreMoveDTO> _003Cdoc_003E5__4;

		private Move _003Cmove_003E5__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<IQuerySnapshot<FirestoreMoveDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			IReadOnlyDictionary<string, Move> moves;
			try
			{
				if (num != 0 && _003C_003E4__this._staticDataCache.MovesFullyLoaded)
				{
					moves = (IReadOnlyDictionary<string, Move>)(object)_003C_003E4__this._staticDataCache.Moves;
				}
				else
				{
					try
					{
						TaskAwaiter<IQuerySnapshot<FirestoreMoveDTO>> awaiter;
						if (num != 0)
						{
							awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection(_003C_003E4__this.CollectionName)).GetDocumentsAsync<FirestoreMoveDTO>((Source)0).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CGetAllAsync_003Ed__7 _003CGetAllAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreMoveDTO>>, _003CGetAllAsync_003Ed__7>(ref awaiter, ref _003CGetAllAsync_003Ed__);
								return;
							}
						}
						else
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreMoveDTO>>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__2 = awaiter.GetResult();
						_003CfirestoreMoves_003E5__1 = _003C_003Es__2;
						_003C_003Es__2 = null;
						_003C_003Es__3 = _003CfirestoreMoves_003E5__1.Documents.GetEnumerator();
						try
						{
							while (((global::System.Collections.IEnumerator)_003C_003Es__3).MoveNext())
							{
								_003Cdoc_003E5__4 = _003C_003Es__3.Current;
								if (_003Cdoc_003E5__4.Data != null)
								{
									_003Cmove_003E5__5 = MoveEntityMapper.ToEntity(_003Cdoc_003E5__4.Data);
									if (!string.IsNullOrEmpty(_003Cmove_003E5__5.Name))
									{
										_003C_003E4__this._staticDataCache.Moves[_003Cmove_003E5__5.Name] = _003Cmove_003E5__5;
									}
									_003Cmove_003E5__5 = null;
								}
								_003Cdoc_003E5__4 = null;
							}
						}
						finally
						{
							if (num < 0 && _003C_003Es__3 != null)
							{
								((global::System.IDisposable)_003C_003Es__3).Dispose();
							}
						}
						_003C_003Es__3 = null;
						_003C_003E4__this._staticDataCache.SetMovesFullyLoaded();
						moves = (IReadOnlyDictionary<string, Move>)(object)_003C_003E4__this._staticDataCache.Moves;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__6 = ex;
						Console.WriteLine("Error fetching all moves: " + _003Cex_003E5__6.Message);
						moves = (IReadOnlyDictionary<string, Move>)(object)_003C_003E4__this._staticDataCache.Moves;
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
			_003C_003Et__builder.SetResult(moves);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetByIdAsync_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Move> _003C_003Et__builder;

		public string moveId;

		public MoveRepository _003C_003E4__this;

		private bool _003CcacheCheck_003E5__1;

		private Move _003Cmove_003E5__2;

		private IDocumentSnapshot<FirestoreMoveDTO> _003CmoveSnapshot_003E5__3;

		private IDocumentSnapshot<FirestoreMoveDTO> _003C_003Es__4;

		private Move _003CfetchedMove_003E5__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<IDocumentSnapshot<FirestoreMoveDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Move result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IDocumentSnapshot<FirestoreMoveDTO>> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<FirestoreMoveDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_00d8;
					}
					_003CcacheCheck_003E5__1 = _003C_003E4__this._staticDataCache.Moves.TryGetValue(moveId, ref _003Cmove_003E5__2);
					if (!_003CcacheCheck_003E5__1)
					{
						awaiter = _003C_003E4__this._firestore.GetCollection(_003C_003E4__this.CollectionName).GetDocument(moveId).GetDocumentSnapshotAsync<FirestoreMoveDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetByIdAsync_003Ed__4 _003CGetByIdAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestoreMoveDTO>>, _003CGetByIdAsync_003Ed__4>(ref awaiter, ref _003CGetByIdAsync_003Ed__);
							return;
						}
						goto IL_00d8;
					}
					result = _003Cmove_003E5__2;
					goto end_IL_0010;
					IL_00d8:
					_003C_003Es__4 = awaiter.GetResult();
					_003CmoveSnapshot_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003CmoveSnapshot_003E5__3.Data != null)
					{
						_003CfetchedMove_003E5__5 = MoveEntityMapper.ToEntity(_003CmoveSnapshot_003E5__3.Data);
						_003C_003E4__this._staticDataCache.Moves[moveId] = _003CfetchedMove_003E5__5;
						result = _003CfetchedMove_003E5__5;
					}
					else
					{
						result = null;
					}
					end_IL_0010:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__6 = ex;
					Console.WriteLine("Error fetching move " + moveId + ": " + _003Cex_003E5__6.Message);
					result = null;
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

	[CompilerGenerated]
	private sealed class _003CGetByIdsAsync_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<global::System.Collections.Generic.IReadOnlyList<Move>> _003C_003Et__builder;

		public global::System.Collections.Generic.IEnumerable<string> moveIds;

		public MoveRepository _003C_003E4__this;

		private List<global::System.Threading.Tasks.Task<Move>> _003Ctasks_003E5__1;

		private Move[] _003Cmoves_003E5__2;

		private List<Move> _003CfilteredMoves_003E5__3;

		private global::System.Collections.Generic.IReadOnlyList<Move> _003CreadOnlyMoves_003E5__4;

		private Move[] _003C_003Es__5;

		private TaskAwaiter<Move[]> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			global::System.Collections.Generic.IReadOnlyList<Move> result;
			try
			{
				TaskAwaiter<Move[]> awaiter;
				if (num != 0)
				{
					global::System.Collections.Generic.IEnumerable<string> enumerable = moveIds;
					MoveRepository moveRepository = _003C_003E4__this;
					_003Ctasks_003E5__1 = Enumerable.ToList<global::System.Threading.Tasks.Task<Move>>(Enumerable.Select<string, global::System.Threading.Tasks.Task<Move>>(enumerable, (Func<string, global::System.Threading.Tasks.Task<Move>>)moveRepository.GetByIdAsync));
					awaiter = global::System.Threading.Tasks.Task.WhenAll<Move>((global::System.Collections.Generic.IEnumerable<global::System.Threading.Tasks.Task<Move>>)_003Ctasks_003E5__1).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGetByIdsAsync_003Ed__5 _003CGetByIdsAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Move[]>, _003CGetByIdsAsync_003Ed__5>(ref awaiter, ref _003CGetByIdsAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Move[]>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__5 = awaiter.GetResult();
				_003Cmoves_003E5__2 = _003C_003Es__5;
				_003C_003Es__5 = null;
				_003CfilteredMoves_003E5__3 = Enumerable.ToList<Move>(Enumerable.Cast<Move>((global::System.Collections.IEnumerable)Enumerable.Where<Move>((global::System.Collections.Generic.IEnumerable<Move>)_003Cmoves_003E5__2, (Func<Move, bool>)((Move move) => move != null))));
				_003CreadOnlyMoves_003E5__4 = (global::System.Collections.Generic.IReadOnlyList<Move>)_003CfilteredMoves_003E5__3.AsReadOnly();
				result = _003CreadOnlyMoves_003E5__4;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Ctasks_003E5__1 = null;
				_003Cmoves_003E5__2 = null;
				_003CfilteredMoves_003E5__3 = null;
				_003CreadOnlyMoves_003E5__4 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Ctasks_003E5__1 = null;
			_003Cmoves_003E5__2 = null;
			_003CfilteredMoves_003E5__3 = null;
			_003CreadOnlyMoves_003E5__4 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IStaticDataCacheService _staticDataCache;

	private readonly IFirebaseFirestore _firestore;

	private readonly string CollectionName = "moves";

	public MoveRepository(IStaticDataCacheService staticDataCache, IFirebaseFirestore firestore)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		_staticDataCache = staticDataCache ?? throw new ArgumentNullException("staticDataCache");
		_firestore = firestore ?? throw new ArgumentNullException("firestore");
	}

	[AsyncStateMachine(typeof(_003CGetByIdAsync_003Ed__4))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Move?> GetByIdAsync(string moveId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Move move = default(Move);
			if (_staticDataCache.Moves.TryGetValue(moveId, ref move))
			{
				return move;
			}
			IDocumentSnapshot<FirestoreMoveDTO> moveSnapshot = await _firestore.GetCollection(CollectionName).GetDocument(moveId).GetDocumentSnapshotAsync<FirestoreMoveDTO>((Source)0);
			if (moveSnapshot.Data != null)
			{
				Move fetchedMove = MoveEntityMapper.ToEntity(moveSnapshot.Data);
				_staticDataCache.Moves[moveId] = fetchedMove;
				return fetchedMove;
			}
			return null;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error fetching move " + moveId + ": " + ex.Message);
			return null;
		}
	}

	[AsyncStateMachine(typeof(_003CGetByIdsAsync_003Ed__5))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<global::System.Collections.Generic.IReadOnlyList<Move>> GetByIdsAsync(global::System.Collections.Generic.IEnumerable<string> moveIds)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		MoveRepository moveRepository = this;
		List<global::System.Threading.Tasks.Task<Move>> tasks = Enumerable.ToList<global::System.Threading.Tasks.Task<Move>>(Enumerable.Select<string, global::System.Threading.Tasks.Task<Move>>(moveIds, (Func<string, global::System.Threading.Tasks.Task<Move>>)moveRepository.GetByIdAsync));
		List<Move> filteredMoves = Enumerable.ToList<Move>(Enumerable.Cast<Move>((global::System.Collections.IEnumerable)Enumerable.Where<Move>((global::System.Collections.Generic.IEnumerable<Move>)(await global::System.Threading.Tasks.Task.WhenAll<Move>((global::System.Collections.Generic.IEnumerable<global::System.Threading.Tasks.Task<Move>>)tasks)), (Func<Move, bool>)((Move move) => move != null))));
		return (global::System.Collections.Generic.IReadOnlyList<Move>)filteredMoves.AsReadOnly();
	}

	public global::System.Threading.Tasks.Task<global::System.Collections.Generic.IReadOnlyList<Move>> GetBySpiritAsync(string spiritId)
	{
		Spirit spirit = default(Spirit);
		if (_staticDataCache.Spirits.TryGetValue(spiritId, ref spirit))
		{
			List<Move> val = spirit.LearnableMoves ?? new List<Move>();
			global::System.Collections.Generic.IReadOnlyList<Move> readOnlyList = (global::System.Collections.Generic.IReadOnlyList<Move>)val.AsReadOnly();
			return global::System.Threading.Tasks.Task.FromResult<global::System.Collections.Generic.IReadOnlyList<Move>>(readOnlyList);
		}
		global::System.Collections.Generic.IReadOnlyList<Move> readOnlyList2 = (global::System.Collections.Generic.IReadOnlyList<Move>)new List<Move>().AsReadOnly();
		return global::System.Threading.Tasks.Task.FromResult<global::System.Collections.Generic.IReadOnlyList<Move>>(readOnlyList2);
	}

	[AsyncStateMachine(typeof(_003CGetAllAsync_003Ed__7))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<IReadOnlyDictionary<string, Move>> GetAllAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (_staticDataCache.MovesFullyLoaded)
		{
			return (IReadOnlyDictionary<string, Move>)(object)_staticDataCache.Moves;
		}
		try
		{
			global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreMoveDTO>> enumerator = (await ((IQuery)_firestore.GetCollection(CollectionName)).GetDocumentsAsync<FirestoreMoveDTO>((Source)0)).Documents.GetEnumerator();
			try
			{
				while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
				{
					IDocumentSnapshot<FirestoreMoveDTO> doc = enumerator.Current;
					if (doc.Data != null)
					{
						Move move = MoveEntityMapper.ToEntity(doc.Data);
						if (!string.IsNullOrEmpty(move.Name))
						{
							_staticDataCache.Moves[move.Name] = move;
						}
					}
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator)?.Dispose();
			}
			_staticDataCache.SetMovesFullyLoaded();
			return (IReadOnlyDictionary<string, Move>)(object)_staticDataCache.Moves;
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine("Error fetching all moves: " + ex.Message);
			return (IReadOnlyDictionary<string, Move>)(object)_staticDataCache.Moves;
		}
	}
}
