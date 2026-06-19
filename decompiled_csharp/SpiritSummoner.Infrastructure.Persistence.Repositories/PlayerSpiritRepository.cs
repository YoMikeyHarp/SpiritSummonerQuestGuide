using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Plugin.Firebase.Firestore;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Players;
using SpiritSummoner.Infrastructure.Persistence.Mapping;

namespace SpiritSummoner.Infrastructure.Persistence.Repositories;

public class PlayerSpiritRepository : IPlayerSpiritRepository
{
	[CompilerGenerated]
	private sealed class _003CGetByIdAsync_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<PlayerSpirit> _003C_003Et__builder;

		public string playerId;

		public string playerSpiritId;

		public PlayerSpiritRepository _003C_003E4__this;

		private IDocumentSnapshot<FirestorePlayerSpiritDTO> _003CplayerSpiritDocument_003E5__1;

		private IDocumentSnapshot<FirestorePlayerSpiritDTO> _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<IDocumentSnapshot<FirestorePlayerSpiritDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PlayerSpirit result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IDocumentSnapshot<FirestorePlayerSpiritDTO>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._firestore.GetCollection("players").GetDocument(playerId + "/playerspirits/" + playerSpiritId).GetDocumentSnapshotAsync<FirestorePlayerSpiritDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetByIdAsync_003Ed__3 _003CGetByIdAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestorePlayerSpiritDTO>>, _003CGetByIdAsync_003Ed__3>(ref awaiter, ref _003CGetByIdAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<FirestorePlayerSpiritDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003CplayerSpiritDocument_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					result = ((_003CplayerSpiritDocument_003E5__1?.Data != null) ? PlayerSpiritEntityMapper.ToEntity(_003CplayerSpiritDocument_003E5__1.Data) : null);
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("Error retrieving playerspirits: " + _003Cex_003E5__3.Message);
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
	private sealed class _003CGetByIdsAsync_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<PlayerSpirit>> _003C_003Et__builder;

		public string playerId;

		public List<string> playerSpiritIds;

		public PlayerSpiritRepository _003C_003E4__this;

		private IQuerySnapshot<FirestorePlayerSpiritDTO> _003CplayerSpiritDocuments_003E5__1;

		private IQuerySnapshot<FirestorePlayerSpiritDTO> _003C_003Es__2;

		private ICollectionReference _003C_003Es__3;

		private List<string> _003C_003Es__4;

		private int _003C_003Es__5;

		private object[] _003C_003Es__6;

		private Enumerator<string> _003C_003Es__7;

		private global::System.Exception _003Cex_003E5__8;

		private TaskAwaiter<IQuerySnapshot<FirestorePlayerSpiritDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<PlayerSpirit> result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestorePlayerSpiritDTO>> awaiter;
					if (num != 0)
					{
						_003C_003Es__3 = _003C_003E4__this._firestore.GetCollection("players").GetDocument(playerId).GetCollection("playerspirits");
						_003C_003Es__4 = playerSpiritIds;
						_003C_003Es__5 = 0;
						_003C_003Es__6 = new object[_003C_003Es__4.Count];
						_003C_003Es__7 = _003C_003Es__4.GetEnumerator();
						try
						{
							while (_003C_003Es__7.MoveNext())
							{
								string current = _003C_003Es__7.Current;
								_003C_003Es__6[_003C_003Es__5] = current;
								_003C_003Es__5++;
							}
						}
						finally
						{
							if (num < 0)
							{
								((global::System.IDisposable)_003C_003Es__7).Dispose();
							}
						}
						_003C_003Es__7 = default(Enumerator<string>);
						awaiter = ((IQuery)_003C_003Es__3).WhereFieldIn("playerSpiritId", _003C_003Es__6).GetDocumentsAsync<FirestorePlayerSpiritDTO>((Source)0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetByIdsAsync_003Ed__4 _003CGetByIdsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestorePlayerSpiritDTO>>, _003CGetByIdsAsync_003Ed__4>(ref awaiter, ref _003CGetByIdsAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestorePlayerSpiritDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003C_003Es__3 = null;
					_003C_003Es__4 = null;
					_003C_003Es__6 = null;
					_003CplayerSpiritDocuments_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					result = ((_003CplayerSpiritDocuments_003E5__1?.Documents != null && Enumerable.Any<IDocumentSnapshot<FirestorePlayerSpiritDTO>>(_003CplayerSpiritDocuments_003E5__1.Documents)) ? Enumerable.ToList<PlayerSpirit>(Enumerable.Select<IDocumentSnapshot<FirestorePlayerSpiritDTO>, PlayerSpirit>(_003CplayerSpiritDocuments_003E5__1.Documents, (Func<IDocumentSnapshot<FirestorePlayerSpiritDTO>, PlayerSpirit>)((IDocumentSnapshot<FirestorePlayerSpiritDTO> doc) => PlayerSpiritEntityMapper.ToEntity(doc.Data)))) : new List<PlayerSpirit>());
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__8 = ex;
					Console.WriteLine("Error retrieving playerspirits: " + _003Cex_003E5__8.Message);
					result = new List<PlayerSpirit>();
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

	private const string CollectionName = "players";

	public PlayerSpiritRepository(IFirebaseFirestore firestore)
	{
		_firestore = firestore;
	}

	[AsyncStateMachine(typeof(_003CGetByIdAsync_003Ed__3))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<PlayerSpirit?> GetByIdAsync(string playerId, string playerSpiritId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentSnapshot<FirestorePlayerSpiritDTO> playerSpiritDocument = await _firestore.GetCollection("players").GetDocument(playerId + "/playerspirits/" + playerSpiritId).GetDocumentSnapshotAsync<FirestorePlayerSpiritDTO>((Source)0);
			if (playerSpiritDocument?.Data == null)
			{
				return null;
			}
			return PlayerSpiritEntityMapper.ToEntity(playerSpiritDocument.Data);
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error retrieving playerspirits: " + ex.Message);
			return null;
		}
	}

	[AsyncStateMachine(typeof(_003CGetByIdsAsync_003Ed__4))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<PlayerSpirit>> GetByIdsAsync(string playerId, List<string> playerSpiritIds)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ICollectionReference collection = _firestore.GetCollection("players").GetDocument(playerId).GetCollection("playerspirits");
			int num = 0;
			object[] array = new object[playerSpiritIds.Count];
			Enumerator<string> enumerator = playerSpiritIds.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					array[num] = current;
					num++;
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator).Dispose();
			}
			IQuerySnapshot<FirestorePlayerSpiritDTO> playerSpiritDocuments = await ((IQuery)collection).WhereFieldIn("playerSpiritId", array).GetDocumentsAsync<FirestorePlayerSpiritDTO>((Source)0);
			if (playerSpiritDocuments?.Documents == null || !Enumerable.Any<IDocumentSnapshot<FirestorePlayerSpiritDTO>>(playerSpiritDocuments.Documents))
			{
				return new List<PlayerSpirit>();
			}
			return Enumerable.ToList<PlayerSpirit>(Enumerable.Select<IDocumentSnapshot<FirestorePlayerSpiritDTO>, PlayerSpirit>(playerSpiritDocuments.Documents, (Func<IDocumentSnapshot<FirestorePlayerSpiritDTO>, PlayerSpirit>)((IDocumentSnapshot<FirestorePlayerSpiritDTO> doc) => PlayerSpiritEntityMapper.ToEntity(doc.Data))));
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error retrieving playerspirits: " + ex.Message);
			return new List<PlayerSpirit>();
		}
	}
}
