using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Plugin.Firebase.Firestore;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Domain.Services;
using SpiritSummoner.Infrastructure.Diagnostics;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Guildmasterboard;
using SpiritSummoner.Infrastructure.Persistence.Mapping;

namespace SpiritSummoner.Infrastructure.Persistence.Repositories;

public class LeaderboardRepository : ILeaderboardRepository
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public string playerId;

		internal bool _003CGetPlayersAroundRankAsync_003Eb__0(LeaderboardEntry e)
		{
			return e.PlayerId == playerId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public string playerId;

		internal bool _003CGetPlayerEntryAsync_003Eb__0(LeaderboardEntry e)
		{
			return e.PlayerId == playerId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public string playerId;

		internal bool _003CGetPlayerRankAsync_003Eb__0(LeaderboardEntry e)
		{
			return e.PlayerId == playerId;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetPlayerEntryAsync_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<LeaderboardEntry> _003C_003Et__builder;

		public string playerId;

		public LeaderboardRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass13_0 _003C_003E8__1;

		private List<LeaderboardEntry> _003Csnapshot_003E5__2;

		private LeaderboardEntry _003Centry_003E5__3;

		private List<LeaderboardEntry> _003C_003Es__4;

		private IDocumentSnapshot<FirestoreLeaderboardEntryDTO> _003Cdocument_003E5__5;

		private IDocumentSnapshot<FirestoreLeaderboardEntryDTO> _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter<List<LeaderboardEntry>> _003C_003Eu__1;

		private TaskAwaiter<IDocumentSnapshot<FirestoreLeaderboardEntryDTO>> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			LeaderboardEntry result;
			try
			{
				TaskAwaiter<List<LeaderboardEntry>> awaiter;
				if (num != 0)
				{
					if (num == 1)
					{
						goto IL_00f1;
					}
					_003C_003E8__1 = new _003C_003Ec__DisplayClass13_0();
					_003C_003E8__1.playerId = playerId;
					awaiter = _003C_003E4__this.GetSnapshotAsync().GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGetPlayerEntryAsync_003Ed__13 _003CGetPlayerEntryAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<LeaderboardEntry>>, _003CGetPlayerEntryAsync_003Ed__13>(ref awaiter, ref _003CGetPlayerEntryAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<List<LeaderboardEntry>>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__4 = awaiter.GetResult();
				_003Csnapshot_003E5__2 = _003C_003Es__4;
				_003C_003Es__4 = null;
				_003Centry_003E5__3 = Enumerable.FirstOrDefault<LeaderboardEntry>((global::System.Collections.Generic.IEnumerable<LeaderboardEntry>)_003Csnapshot_003E5__2, (Func<LeaderboardEntry, bool>)((LeaderboardEntry e) => e.PlayerId == _003C_003E8__1.playerId));
				if (_003Centry_003E5__3 == null)
				{
					goto IL_00f1;
				}
				result = _003Centry_003E5__3;
				goto end_IL_0007;
				IL_00f1:
				try
				{
					TaskAwaiter<IDocumentSnapshot<FirestoreLeaderboardEntryDTO>> awaiter2;
					if (num != 1)
					{
						awaiter2 = _003C_003E4__this._firestore.GetCollection("leaderboards").GetDocument(_003C_003E8__1.playerId).GetDocumentSnapshotAsync<FirestoreLeaderboardEntryDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter2;
							_003CGetPlayerEntryAsync_003Ed__13 _003CGetPlayerEntryAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestoreLeaderboardEntryDTO>>, _003CGetPlayerEntryAsync_003Ed__13>(ref awaiter2, ref _003CGetPlayerEntryAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<IDocumentSnapshot<FirestoreLeaderboardEntryDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__6 = awaiter2.GetResult();
					_003Cdocument_003E5__5 = _003C_003Es__6;
					_003C_003Es__6 = null;
					if (_003Cdocument_003E5__5?.Data == null)
					{
						result = null;
					}
					else
					{
						FirestoreReadCounter.Track("leaderboards [entry]");
						result = LeaderboardMapper.ToEntity(_003Cdocument_003E5__5.Data);
					}
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__7 = ex;
					Console.WriteLine("Error fetching player entry: " + _003Cex_003E5__7.Message);
					result = null;
				}
				end_IL_0007:;
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Csnapshot_003E5__2 = null;
				_003Centry_003E5__3 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Csnapshot_003E5__2 = null;
			_003Centry_003E5__3 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetPlayerRankAsync_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<int> _003C_003Et__builder;

		public string playerId;

		public LeaderboardRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass14_0 _003C_003E8__1;

		private List<LeaderboardEntry> _003Csnapshot_003E5__2;

		private int _003Cindex_003E5__3;

		private List<LeaderboardEntry> _003C_003Es__4;

		private TaskAwaiter<List<LeaderboardEntry>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			int result;
			try
			{
				TaskAwaiter<List<LeaderboardEntry>> awaiter;
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass14_0();
					_003C_003E8__1.playerId = playerId;
					awaiter = _003C_003E4__this.GetSnapshotAsync().GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGetPlayerRankAsync_003Ed__14 _003CGetPlayerRankAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<LeaderboardEntry>>, _003CGetPlayerRankAsync_003Ed__14>(ref awaiter, ref _003CGetPlayerRankAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<List<LeaderboardEntry>>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__4 = awaiter.GetResult();
				_003Csnapshot_003E5__2 = _003C_003Es__4;
				_003C_003Es__4 = null;
				_003Cindex_003E5__3 = _003Csnapshot_003E5__2.FindIndex((Predicate<LeaderboardEntry>)((LeaderboardEntry e) => e.PlayerId == _003C_003E8__1.playerId));
				result = ((_003Cindex_003E5__3 >= 0) ? (_003Cindex_003E5__3 + 1) : 0);
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Csnapshot_003E5__2 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Csnapshot_003E5__2 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetPlayersAroundRankAsync_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<LeaderboardEntry>> _003C_003Et__builder;

		public string playerId;

		public int rangeAbove;

		public int rangeBelow;

		public LeaderboardRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass12_0 _003C_003E8__1;

		private List<LeaderboardEntry> _003Csnapshot_003E5__2;

		private int _003Cindex_003E5__3;

		private int _003Cstart_003E5__4;

		private int _003Cend_003E5__5;

		private List<LeaderboardEntry> _003C_003Es__6;

		private TaskAwaiter<List<LeaderboardEntry>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<LeaderboardEntry> range;
			try
			{
				TaskAwaiter<List<LeaderboardEntry>> awaiter;
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass12_0();
					_003C_003E8__1.playerId = playerId;
					awaiter = _003C_003E4__this.GetSnapshotAsync().GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGetPlayersAroundRankAsync_003Ed__12 _003CGetPlayersAroundRankAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<LeaderboardEntry>>, _003CGetPlayersAroundRankAsync_003Ed__12>(ref awaiter, ref _003CGetPlayersAroundRankAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<List<LeaderboardEntry>>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__6 = awaiter.GetResult();
				_003Csnapshot_003E5__2 = _003C_003Es__6;
				_003C_003Es__6 = null;
				_003Cindex_003E5__3 = _003Csnapshot_003E5__2.FindIndex((Predicate<LeaderboardEntry>)((LeaderboardEntry e) => e.PlayerId == _003C_003E8__1.playerId));
				_003Cstart_003E5__4 = Math.Max(0, _003Cindex_003E5__3 - rangeAbove);
				_003Cend_003E5__5 = Math.Min(_003Csnapshot_003E5__2.Count - 1, _003Cindex_003E5__3 + rangeBelow);
				range = _003Csnapshot_003E5__2.GetRange(_003Cstart_003E5__4, _003Cend_003E5__5 - _003Cstart_003E5__4 + 1);
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Csnapshot_003E5__2 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Csnapshot_003E5__2 = null;
			_003C_003Et__builder.SetResult(range);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetSnapshotAsync_003Ed__9 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<LeaderboardEntry>> _003C_003Et__builder;

		public LeaderboardRepository _003C_003E4__this;

		private IQuerySnapshot<FirestoreLeaderboardEntryDTO> _003CquerySnapshot_003E5__1;

		private global::System.Collections.Generic.IEnumerable<IDocumentSnapshot<FirestoreLeaderboardEntryDTO>> _003Cdocs_003E5__2;

		private List<LeaderboardEntry> _003Clist_003E5__3;

		private IQuerySnapshot<FirestoreLeaderboardEntryDTO> _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<IQuerySnapshot<FirestoreLeaderboardEntryDTO>> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0152: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_023c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<LeaderboardEntry> result;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00ba;
				}
				if (num == 1)
				{
					goto IL_00c3;
				}
				if (_003C_003E4__this._snapshot == null || !(_003C_003E4__this._snapshotExpiresAt > global::System.DateTime.UtcNow))
				{
					awaiter = _003C_003E4__this._snapshotLock.WaitAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGetSnapshotAsync_003Ed__9 _003CGetSnapshotAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CGetSnapshotAsync_003Ed__9>(ref awaiter, ref _003CGetSnapshotAsync_003Ed__);
						return;
					}
					goto IL_00ba;
				}
				result = _003C_003E4__this._snapshot;
				goto end_IL_0007;
				IL_00c3:
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestoreLeaderboardEntryDTO>> awaiter2;
					if (num == 1)
					{
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<IQuerySnapshot<FirestoreLeaderboardEntryDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_018e;
					}
					if (_003C_003E4__this._snapshot == null || !(_003C_003E4__this._snapshotExpiresAt > global::System.DateTime.UtcNow))
					{
						awaiter2 = ((IQuery)_003C_003E4__this._firestore.GetCollection("leaderboards")).OrderBy("score", true).LimitedTo(100).GetDocumentsAsync<FirestoreLeaderboardEntryDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter2;
							_003CGetSnapshotAsync_003Ed__9 _003CGetSnapshotAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreLeaderboardEntryDTO>>, _003CGetSnapshotAsync_003Ed__9>(ref awaiter2, ref _003CGetSnapshotAsync_003Ed__);
							return;
						}
						goto IL_018e;
					}
					result = _003C_003E4__this._snapshot;
					goto end_IL_00c3;
					IL_018e:
					_003C_003Es__4 = awaiter2.GetResult();
					_003CquerySnapshot_003E5__1 = _003C_003Es__4;
					_003C_003Es__4 = null;
					_003Cdocs_003E5__2 = _003CquerySnapshot_003E5__1?.Documents;
					_003Clist_003E5__3 = ((_003Cdocs_003E5__2 == null) ? new List<LeaderboardEntry>() : Enumerable.ToList<LeaderboardEntry>(Enumerable.Select<IDocumentSnapshot<FirestoreLeaderboardEntryDTO>, LeaderboardEntry>(_003Cdocs_003E5__2, (Func<IDocumentSnapshot<FirestoreLeaderboardEntryDTO>, LeaderboardEntry>)((IDocumentSnapshot<FirestoreLeaderboardEntryDTO> d) => LeaderboardMapper.ToEntity(d.Data)))));
					FirestoreReadCounter.Track("leaderboards [snapshot]", _003Clist_003E5__3.Count);
					_003C_003E4__this._snapshot = _003Clist_003E5__3;
					_003C_003E4__this._snapshotExpiresAt = global::System.DateTime.UtcNow + CacheTtl;
					result = _003Clist_003E5__3;
					end_IL_00c3:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					Console.WriteLine("Error fetching leaderboard snapshot: " + _003Cex_003E5__5.Message);
					result = _003C_003E4__this._snapshot ?? new List<LeaderboardEntry>();
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this._snapshotLock.Release();
					}
				}
				goto end_IL_0007;
				IL_00ba:
				((TaskAwaiter)(ref awaiter)).GetResult();
				goto IL_00c3;
				end_IL_0007:;
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
	private sealed class _003CGetTopPlayersAsync_003Ed__11 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<LeaderboardEntry>> _003C_003Et__builder;

		public int count;

		public LeaderboardRepository _003C_003E4__this;

		private List<LeaderboardEntry> _003Csnapshot_003E5__1;

		private List<LeaderboardEntry> _003C_003Es__2;

		private TaskAwaiter<List<LeaderboardEntry>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<LeaderboardEntry> result;
			try
			{
				TaskAwaiter<List<LeaderboardEntry>> awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this.GetSnapshotAsync().GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGetTopPlayersAsync_003Ed__11 _003CGetTopPlayersAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<LeaderboardEntry>>, _003CGetTopPlayersAsync_003Ed__11>(ref awaiter, ref _003CGetTopPlayersAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<List<LeaderboardEntry>>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__2 = awaiter.GetResult();
				_003Csnapshot_003E5__1 = _003C_003Es__2;
				_003C_003Es__2 = null;
				result = Enumerable.ToList<LeaderboardEntry>(Enumerable.Take<LeaderboardEntry>((global::System.Collections.Generic.IEnumerable<LeaderboardEntry>)_003Csnapshot_003E5__1, count));
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Csnapshot_003E5__1 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Csnapshot_003E5__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CUpsertLeaderboardEntryAsync_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public LeaderboardEntry entry;

		public LeaderboardRepository _003C_003E4__this;

		private FirestoreLeaderboardEntryDTO _003Cdto_003E5__1;

		private global::System.Exception _003Cex_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
					_003C_003E4__this.InvalidateSnapshot();
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						entry.Title = _003C_003E4__this._scoreCalculator.GetTitle(entry.Score, 0);
						_003Cdto_003E5__1 = LeaderboardMapper.ToFirestoreDTO(entry);
						awaiter = _003C_003E4__this._firestore.GetCollection("leaderboards").GetDocument(entry.PlayerId).SetDataAsync((object)_003Cdto_003E5__1, SetOptions.Merge())
							.GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CUpsertLeaderboardEntryAsync_003Ed__15 _003CUpsertLeaderboardEntryAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CUpsertLeaderboardEntryAsync_003Ed__15>(ref awaiter, ref _003CUpsertLeaderboardEntryAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter)).GetResult();
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__2 = ex;
					Console.WriteLine("Error upserting leaderboard entry: " + _003Cex_003E5__2.Message);
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

	private readonly IBattleScoreCalculator _scoreCalculator;

	private const string CollectionName = "leaderboards";

	private const int SnapshotLimit = 100;

	private static readonly TimeSpan CacheTtl = TimeSpan.FromMinutes(5L);

	private List<LeaderboardEntry>? _snapshot;

	private global::System.DateTime _snapshotExpiresAt = global::System.DateTime.MinValue;

	private readonly SemaphoreSlim _snapshotLock = new SemaphoreSlim(1, 1);

	public LeaderboardRepository(IFirebaseFirestore firestore, IBattleScoreCalculator scoreCalculator)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		_firestore = firestore;
		_scoreCalculator = scoreCalculator;
	}

	[AsyncStateMachine(typeof(_003CGetSnapshotAsync_003Ed__9))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<List<LeaderboardEntry>> GetSnapshotAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (_snapshot != null && _snapshotExpiresAt > global::System.DateTime.UtcNow)
		{
			return _snapshot;
		}
		await _snapshotLock.WaitAsync();
		try
		{
			if (_snapshot != null && _snapshotExpiresAt > global::System.DateTime.UtcNow)
			{
				return _snapshot;
			}
			global::System.Collections.Generic.IEnumerable<IDocumentSnapshot<FirestoreLeaderboardEntryDTO>> docs = (await ((IQuery)_firestore.GetCollection("leaderboards")).OrderBy("score", true).LimitedTo(100).GetDocumentsAsync<FirestoreLeaderboardEntryDTO>((Source)0))?.Documents;
			List<LeaderboardEntry> list = ((docs == null) ? new List<LeaderboardEntry>() : Enumerable.ToList<LeaderboardEntry>(Enumerable.Select<IDocumentSnapshot<FirestoreLeaderboardEntryDTO>, LeaderboardEntry>(docs, (Func<IDocumentSnapshot<FirestoreLeaderboardEntryDTO>, LeaderboardEntry>)((IDocumentSnapshot<FirestoreLeaderboardEntryDTO> d) => LeaderboardMapper.ToEntity(d.Data)))));
			FirestoreReadCounter.Track("leaderboards [snapshot]", list.Count);
			_snapshot = list;
			_snapshotExpiresAt = global::System.DateTime.UtcNow + CacheTtl;
			return list;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error fetching leaderboard snapshot: " + ex.Message);
			return _snapshot ?? new List<LeaderboardEntry>();
		}
		finally
		{
			_snapshotLock.Release();
		}
	}

	private void InvalidateSnapshot()
	{
		_snapshot = null;
		_snapshotExpiresAt = global::System.DateTime.MinValue;
	}

	[AsyncStateMachine(typeof(_003CGetTopPlayersAsync_003Ed__11))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<LeaderboardEntry>> GetTopPlayersAsync(int count)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return Enumerable.ToList<LeaderboardEntry>(Enumerable.Take<LeaderboardEntry>((global::System.Collections.Generic.IEnumerable<LeaderboardEntry>)(await GetSnapshotAsync()), count));
	}

	[AsyncStateMachine(typeof(_003CGetPlayersAroundRankAsync_003Ed__12))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<LeaderboardEntry>> GetPlayersAroundRankAsync(string playerId, int rangeAbove, int rangeBelow)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string playerId2 = playerId;
		List<LeaderboardEntry> snapshot = await GetSnapshotAsync();
		int index = snapshot.FindIndex((Predicate<LeaderboardEntry>)((LeaderboardEntry e) => e.PlayerId == playerId2));
		int start = Math.Max(0, index - rangeAbove);
		int end = Math.Min(snapshot.Count - 1, index + rangeBelow);
		return snapshot.GetRange(start, end - start + 1);
	}

	[AsyncStateMachine(typeof(_003CGetPlayerEntryAsync_003Ed__13))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<LeaderboardEntry?> GetPlayerEntryAsync(string playerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string playerId2 = playerId;
		LeaderboardEntry entry = Enumerable.FirstOrDefault<LeaderboardEntry>((global::System.Collections.Generic.IEnumerable<LeaderboardEntry>)(await GetSnapshotAsync()), (Func<LeaderboardEntry, bool>)((LeaderboardEntry e) => e.PlayerId == playerId2));
		if (entry != null)
		{
			return entry;
		}
		try
		{
			IDocumentSnapshot<FirestoreLeaderboardEntryDTO> document = await _firestore.GetCollection("leaderboards").GetDocument(playerId2).GetDocumentSnapshotAsync<FirestoreLeaderboardEntryDTO>((Source)0);
			if (document?.Data == null)
			{
				return null;
			}
			FirestoreReadCounter.Track("leaderboards [entry]");
			return LeaderboardMapper.ToEntity(document.Data);
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine("Error fetching player entry: " + ex.Message);
			return null;
		}
	}

	[AsyncStateMachine(typeof(_003CGetPlayerRankAsync_003Ed__14))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<int> GetPlayerRankAsync(string playerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string playerId2 = playerId;
		int index = (await GetSnapshotAsync()).FindIndex((Predicate<LeaderboardEntry>)((LeaderboardEntry e) => e.PlayerId == playerId2));
		return (index >= 0) ? (index + 1) : 0;
	}

	[AsyncStateMachine(typeof(_003CUpsertLeaderboardEntryAsync_003Ed__15))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> UpsertLeaderboardEntryAsync(LeaderboardEntry entry)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		InvalidateSnapshot();
		try
		{
			entry.Title = _scoreCalculator.GetTitle(entry.Score, 0);
			FirestoreLeaderboardEntryDTO dto = LeaderboardMapper.ToFirestoreDTO(entry);
			await _firestore.GetCollection("leaderboards").GetDocument(entry.PlayerId).SetDataAsync((object)dto, SetOptions.Merge());
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error upserting leaderboard entry: " + ex.Message);
			return false;
		}
	}
}
