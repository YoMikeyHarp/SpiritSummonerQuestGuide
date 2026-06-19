using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Plugin.Firebase.Firestore;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Caching;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Moves;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Spirits;
using SpiritSummoner.Infrastructure.Persistence.Mapping;

namespace SpiritSummoner.Infrastructure.Persistence.Repositories;

public class SpiritRepository : ISpiritRepository
{
	[CompilerGenerated]
	private sealed class _003CGetByIdAsync_003Ed__6 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Spirit> _003C_003Et__builder;

		public string spiritId;

		public SpiritRepository _003C_003E4__this;

		private IDocumentReference _003CspiritRef_003E5__1;

		private IDocumentSnapshot<FirestoreSpiritDTO> _003Cdocument_003E5__2;

		private FirestoreSpiritDTO _003CfirestoreSpirit_003E5__3;

		private IDocumentSnapshot<FirestoreSpiritDTO> _003C_003Es__4;

		private Dictionary<string, Move> _003CbaseSpiritMoves_003E5__5;

		private Enumerator<string> _003C_003Es__6;

		private string _003CmoveRef_003E5__7;

		private IDocumentSnapshot<FirestoreMoveDTO> _003CmoveSnapshot_003E5__8;

		private IDocumentSnapshot<FirestoreMoveDTO> _003C_003Es__9;

		private global::System.Exception _003Cex_003E5__10;

		private TaskAwaiter<IDocumentSnapshot<FirestoreSpiritDTO>> _003C_003Eu__1;

		private TaskAwaiter<IDocumentSnapshot<FirestoreMoveDTO>> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0262: Unknown result type (might be due to invalid IL or missing references)
			//IL_0267: Unknown result type (might be due to invalid IL or missing references)
			//IL_026f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0228: Unknown result type (might be due to invalid IL or missing references)
			//IL_022d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0242: Unknown result type (might be due to invalid IL or missing references)
			//IL_0244: Unknown result type (might be due to invalid IL or missing references)
			//IL_0327: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Spirit result;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter<IDocumentSnapshot<FirestoreSpiritDTO>> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<FirestoreSpiritDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_00ec;
					}
					if (num == 1)
					{
						goto IL_01e3;
					}
					if (!_003C_003E4__this._staticDataCache.Spirits.ContainsKey(spiritId))
					{
						_003CspiritRef_003E5__1 = _003C_003E4__this._firestore.GetCollection("spiritsTemp").GetDocument(spiritId);
						awaiter = _003CspiritRef_003E5__1.GetDocumentSnapshotAsync<FirestoreSpiritDTO>((Source)0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetByIdAsync_003Ed__6 _003CGetByIdAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestoreSpiritDTO>>, _003CGetByIdAsync_003Ed__6>(ref awaiter, ref _003CGetByIdAsync_003Ed__);
							return;
						}
						goto IL_00ec;
					}
					result = _003C_003E4__this._staticDataCache.Spirits[spiritId];
					goto end_IL_0011;
					IL_01e3:
					try
					{
						if (num != 1)
						{
							goto IL_02f8;
						}
						TaskAwaiter<IDocumentSnapshot<FirestoreMoveDTO>> awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<IDocumentSnapshot<FirestoreMoveDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_027e;
						IL_027e:
						_003C_003Es__9 = awaiter2.GetResult();
						_003CmoveSnapshot_003E5__8 = _003C_003Es__9;
						_003C_003Es__9 = null;
						if (_003CmoveSnapshot_003E5__8.Data != null)
						{
							_003CbaseSpiritMoves_003E5__5.Add(_003CmoveSnapshot_003E5__8.Data.Name ?? "No Name", MoveEntityMapper.ToEntity(_003CmoveSnapshot_003E5__8.Data));
						}
						_003CmoveSnapshot_003E5__8 = null;
						_003CmoveRef_003E5__7 = null;
						goto IL_02f8;
						IL_02f8:
						if (_003C_003Es__6.MoveNext())
						{
							_003CmoveRef_003E5__7 = _003C_003Es__6.Current;
							awaiter2 = _003C_003E4__this._firestore.GetCollection("moves").GetDocument(_003CmoveRef_003E5__7).GetDocumentSnapshotAsync<FirestoreMoveDTO>((Source)0)
								.GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter2;
								_003CGetByIdAsync_003Ed__6 _003CGetByIdAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestoreMoveDTO>>, _003CGetByIdAsync_003Ed__6>(ref awaiter2, ref _003CGetByIdAsync_003Ed__);
								return;
							}
							goto IL_027e;
						}
					}
					finally
					{
						if (num < 0)
						{
							((global::System.IDisposable)_003C_003Es__6).Dispose();
						}
					}
					_003C_003Es__6 = default(Enumerator<string>);
					result = SpiritEntityMapper.ToEntity(_003CfirestoreSpirit_003E5__3, _003CbaseSpiritMoves_003E5__5);
					goto end_IL_0011;
					IL_00ec:
					_003C_003Es__4 = awaiter.GetResult();
					_003Cdocument_003E5__2 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003Cdocument_003E5__2?.Data == null)
					{
						result = null;
					}
					else
					{
						_003CfirestoreSpirit_003E5__3 = _003Cdocument_003E5__2.Data;
						_003CfirestoreSpirit_003E5__3.ID = _003Cdocument_003E5__2.Reference.Id;
						if (_003C_003E4__this._staticDataCache.MovesFullyLoaded)
						{
							result = SpiritEntityMapper.ToEntity(_003CfirestoreSpirit_003E5__3, _003C_003E4__this._staticDataCache.Moves);
						}
						else
						{
							if (_003CfirestoreSpirit_003E5__3.LearnableMoveIds != null && _003CfirestoreSpirit_003E5__3.LearnableMoveIds.Count > 0)
							{
								_003CbaseSpiritMoves_003E5__5 = new Dictionary<string, Move>();
								_003C_003Es__6 = _003CfirestoreSpirit_003E5__3.LearnableMoveIds.GetEnumerator();
								goto IL_01e3;
							}
							result = new Spirit();
						}
					}
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__10 = ex;
					Console.WriteLine("Error retrieving spirit " + spiritId + ": " + _003Cex_003E5__10.Message);
					Console.WriteLine("Stacktrace" + _003Cex_003E5__10.StackTrace);
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

	private readonly IStaticDataCacheService _staticDataCache;

	private readonly IFirebaseFirestore _firestore;

	private const string CollectionName = "spiritsTemp";

	public SpiritRepository(IStaticDataCacheService staticDataCache, IFirebaseFirestore firestore)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		_staticDataCache = staticDataCache ?? throw new ArgumentNullException("staticDataCache");
		_firestore = firestore ?? throw new ArgumentNullException("_firestore");
	}

	public IReadOnlyDictionary<string, Spirit> GetAll()
	{
		return (IReadOnlyDictionary<string, Spirit>)(object)_staticDataCache.Spirits;
	}

	public Spirit? GetById(string spiritId)
	{
		Spirit result = default(Spirit);
		_staticDataCache.Spirits.TryGetValue(spiritId, ref result);
		return result;
	}

	[AsyncStateMachine(typeof(_003CGetByIdAsync_003Ed__6))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Spirit?> GetByIdAsync(string spiritId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (_staticDataCache.Spirits.ContainsKey(spiritId))
			{
				return _staticDataCache.Spirits[spiritId];
			}
			IDocumentReference spiritRef = _firestore.GetCollection("spiritsTemp").GetDocument(spiritId);
			IDocumentSnapshot<FirestoreSpiritDTO> document = await spiritRef.GetDocumentSnapshotAsync<FirestoreSpiritDTO>((Source)0);
			if (document?.Data == null)
			{
				return null;
			}
			FirestoreSpiritDTO firestoreSpirit = document.Data;
			firestoreSpirit.ID = document.Reference.Id;
			if (_staticDataCache.MovesFullyLoaded)
			{
				return SpiritEntityMapper.ToEntity(firestoreSpirit, _staticDataCache.Moves);
			}
			if (firestoreSpirit.LearnableMoveIds != null && firestoreSpirit.LearnableMoveIds.Count > 0)
			{
				Dictionary<string, Move> baseSpiritMoves = new Dictionary<string, Move>();
				Enumerator<string> enumerator = firestoreSpirit.LearnableMoveIds.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						string moveRef = enumerator.Current;
						IDocumentSnapshot<FirestoreMoveDTO> moveSnapshot = await _firestore.GetCollection("moves").GetDocument(moveRef).GetDocumentSnapshotAsync<FirestoreMoveDTO>((Source)0);
						if (moveSnapshot.Data != null)
						{
							baseSpiritMoves.Add(moveSnapshot.Data.Name ?? "No Name", MoveEntityMapper.ToEntity(moveSnapshot.Data));
						}
					}
				}
				finally
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
				return SpiritEntityMapper.ToEntity(firestoreSpirit, baseSpiritMoves);
			}
			return new Spirit();
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error retrieving spirit " + spiritId + ": " + ex.Message);
			Console.WriteLine("Stacktrace" + ex.StackTrace);
			return null;
		}
	}
}
