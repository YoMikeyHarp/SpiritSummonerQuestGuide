using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Plugin.Firebase.Firestore;
using SpiritSummoner.Application.BatchUpdates;
using SpiritSummoner.Application.DTOs;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Domain.Entities.Battles;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Enums.Shops;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Persistence.DTOs;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Battles;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Guildmasterboard;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Moves;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Players;
using SpiritSummoner.Infrastructure.Persistence.Mapping;

namespace SpiritSummoner.Infrastructure.Persistence.Repositories;

public class PlayerRepository : IPlayerRepository
{
	[CompilerGenerated]
	private sealed class _003C_003CGetFriendPresencesAsync_003Eb__33_0_003Ed : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<ValueTuple<string, DateTimeOffset?, string>> _003C_003Et__builder;

		public string id;

		public PlayerRepository _003C_003E4__this;

		private IDocumentSnapshot<FirestorePublicProfileDTO> _003Csnapshot_003E5__1;

		private DateTimeOffset? _003Cts_003E5__2;

		private string _003Cicon_003E5__3;

		private IDocumentSnapshot<FirestorePublicProfileDTO> _003C_003Es__4;

		private TaskAwaiter<IDocumentSnapshot<FirestorePublicProfileDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			ValueTuple<string, DateTimeOffset?, string> result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IDocumentSnapshot<FirestorePublicProfileDTO>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._firestore.GetCollection("publicProfiles").GetDocument(id).GetDocumentSnapshotAsync<FirestorePublicProfileDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003C_003CGetFriendPresencesAsync_003Eb__33_0_003Ed _003C_003CGetFriendPresencesAsync_003Eb__33_0_003Ed = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestorePublicProfileDTO>>, _003C_003CGetFriendPresencesAsync_003Eb__33_0_003Ed>(ref awaiter, ref _003C_003CGetFriendPresencesAsync_003Eb__33_0_003Ed);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<FirestorePublicProfileDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__4 = awaiter.GetResult();
					_003Csnapshot_003E5__1 = _003C_003Es__4;
					_003C_003Es__4 = null;
					_003Cts_003E5__2 = _003Csnapshot_003E5__1?.Data?.LastOnlineAt;
					_003Cicon_003E5__3 = _003Csnapshot_003E5__1?.Data?.PlayerIcon;
					string text = id;
					DateTimeOffset? val = _003Cts_003E5__2;
					DateTimeOffset minValue = DateTimeOffset.MinValue;
					result = new ValueTuple<string, DateTimeOffset?, string>(text, (val.HasValue && val.GetValueOrDefault() == minValue) ? null : _003Cts_003E5__2, _003Cicon_003E5__3);
				}
				catch
				{
					result = new ValueTuple<string, DateTimeOffset?, string>(id, (DateTimeOffset?)null, (string)null);
				}
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(exception);
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
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public PlayerRepository _003C_003E4__this;

		public int teamSize;

		internal global::System.Threading.Tasks.Task<Player> _003CGetPlayersByIdsForBattleAsync_003Eb__0(string id)
		{
			return _003C_003E4__this.GetPlayerBattleAsync(id, teamSize);
		}
	}

	[CompilerGenerated]
	private sealed class _003CAddFriendAsync_003Ed__27 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string playerId;

		public Friend friend;

		public PlayerRepository _003C_003E4__this;

		private FirestoreFriendDTO _003Cdto_003E5__1;

		private global::System.Exception _003Cex_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						_003Cdto_003E5__1 = new FirestoreFriendDTO
						{
							FriendId = friend.FriendId,
							FriendName = friend.FriendName,
							AddedAt = friend.AddedAt
						};
						awaiter = _003C_003E4__this._firestore.GetCollection("players").GetDocument(playerId).GetCollection("friends")
							.GetDocument(friend.FriendId)
							.SetDataAsync((object)_003Cdto_003E5__1, (SetOptions)null)
							.GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CAddFriendAsync_003Ed__27 _003CAddFriendAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CAddFriendAsync_003Ed__27>(ref awaiter, ref _003CAddFriendAsync_003Ed__);
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
					Console.WriteLine("Error adding friend: " + _003Cex_003E5__2.Message);
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

	[CompilerGenerated]
	private sealed class _003CAuthenticateAsync_003Ed__10 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Player> _003C_003Et__builder;

		public string username;

		public string password;

		public string id;

		public PlayerRepository _003C_003E4__this;

		private IDocumentSnapshot<FirestorePlayerDTO> _003CplayerDocument_003E5__1;

		private IQuerySnapshot<FirestorePlayerDTO> _003CplayerQuery_003E5__2;

		private IDocumentSnapshot<FirestorePlayerDTO> _003Cdocument_003E5__3;

		private FirestorePlayerDTO _003Cplayer_003E5__4;

		private IQuerySnapshot<FirestorePlayerSpiritDTO> _003CplayerspiritsSubCollection_003E5__5;

		private IQuerySnapshot<FirestorePlayerQuestsDTO> _003Cquestsref_003E5__6;

		private IQuerySnapshot<FirestorePlayerDTO> _003C_003Es__7;

		private IDocumentSnapshot<FirestorePlayerDTO> _003C_003Es__8;

		private IQuerySnapshot<FirestorePlayerSpiritDTO> _003C_003Es__9;

		private global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestorePlayerSpiritDTO>> _003C_003Es__10;

		private IDocumentSnapshot<FirestorePlayerSpiritDTO> _003Cspirit_003E5__11;

		private FirestorePlayerSpiritDTO _003CconvertedSpirit_003E5__12;

		private IQuerySnapshot<FirestorePlayerQuestsDTO> _003C_003Es__13;

		private global::System.Exception _003Cex_003E5__14;

		private TaskAwaiter<IQuerySnapshot<FirestorePlayerDTO>> _003C_003Eu__1;

		private TaskAwaiter<IDocumentSnapshot<FirestorePlayerDTO>> _003C_003Eu__2;

		private TaskAwaiter<IQuerySnapshot<FirestorePlayerSpiritDTO>> _003C_003Eu__3;

		private TaskAwaiter<IQuerySnapshot<FirestorePlayerQuestsDTO>> _003C_003Eu__4;

		private void MoveNext()
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0256: Unknown result type (might be due to invalid IL or missing references)
			//IL_025b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0263: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0221: Unknown result type (might be due to invalid IL or missing references)
			//IL_0236: Unknown result type (might be due to invalid IL or missing references)
			//IL_0238: Unknown result type (might be due to invalid IL or missing references)
			//IL_036f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0374: Unknown result type (might be due to invalid IL or missing references)
			//IL_0389: Unknown result type (might be due to invalid IL or missing references)
			//IL_038b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Player result;
			try
			{
				if ((uint)num > 3u)
				{
				}
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestorePlayerDTO>> awaiter4;
					TaskAwaiter<IDocumentSnapshot<FirestorePlayerDTO>> awaiter3;
					TaskAwaiter<IQuerySnapshot<FirestorePlayerSpiritDTO>> awaiter2;
					TaskAwaiter<IQuerySnapshot<FirestorePlayerQuestsDTO>> awaiter;
					IDocumentSnapshot<FirestorePlayerDTO> obj;
					switch (num)
					{
					default:
						_003CplayerDocument_003E5__1 = null;
						_003CplayerQuery_003E5__2 = null;
						if (string.IsNullOrEmpty(id))
						{
							awaiter4 = ((IQuery)_003C_003E4__this._firestore.GetCollection("players")).WhereEqualsTo("playername", (object)username).WhereEqualsTo("playerpassword", (object)password).GetDocumentsAsync<FirestorePlayerDTO>((Source)0)
								.GetAwaiter();
							if (!awaiter4.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter4;
								_003CAuthenticateAsync_003Ed__10 _003CAuthenticateAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestorePlayerDTO>>, _003CAuthenticateAsync_003Ed__10>(ref awaiter4, ref _003CAuthenticateAsync_003Ed__);
								return;
							}
							goto IL_00ed;
						}
						awaiter3 = _003C_003E4__this._firestore.GetCollection("players").GetDocument(id).GetDocumentSnapshotAsync<FirestorePlayerDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter3;
							_003CAuthenticateAsync_003Ed__10 _003CAuthenticateAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestorePlayerDTO>>, _003CAuthenticateAsync_003Ed__10>(ref awaiter3, ref _003CAuthenticateAsync_003Ed__);
							return;
						}
						goto IL_0190;
					case 0:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestorePlayerDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_00ed;
					case 1:
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<IDocumentSnapshot<FirestorePlayerDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_0190;
					case 2:
						awaiter2 = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter<IQuerySnapshot<FirestorePlayerSpiritDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_0272;
					case 3:
						{
							awaiter = _003C_003Eu__4;
							_003C_003Eu__4 = default(TaskAwaiter<IQuerySnapshot<FirestorePlayerQuestsDTO>>);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_0272:
						_003C_003Es__9 = awaiter2.GetResult();
						_003CplayerspiritsSubCollection_003E5__5 = _003C_003Es__9;
						_003C_003Es__9 = null;
						_003C_003Es__10 = _003CplayerspiritsSubCollection_003E5__5.Documents.GetEnumerator();
						try
						{
							while (((global::System.Collections.IEnumerator)_003C_003Es__10).MoveNext())
							{
								_003Cspirit_003E5__11 = _003C_003Es__10.Current;
								_003CconvertedSpirit_003E5__12 = _003Cspirit_003E5__11.Data;
								_003CconvertedSpirit_003E5__12.PlayerSpiritID = _003Cspirit_003E5__11.Reference.Id;
								_003Cplayer_003E5__4.PlayerSpirits.Add(_003CconvertedSpirit_003E5__12);
								_003CconvertedSpirit_003E5__12 = null;
								_003Cspirit_003E5__11 = null;
							}
						}
						finally
						{
							if (num < 0 && _003C_003Es__10 != null)
							{
								((global::System.IDisposable)_003C_003Es__10).Dispose();
							}
						}
						_003C_003Es__10 = null;
						awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection("players/" + _003Cplayer_003E5__4.PlayerID + "/quests")).GetDocumentsAsync<FirestorePlayerQuestsDTO>((Source)0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__4 = awaiter;
							_003CAuthenticateAsync_003Ed__10 _003CAuthenticateAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestorePlayerQuestsDTO>>, _003CAuthenticateAsync_003Ed__10>(ref awaiter, ref _003CAuthenticateAsync_003Ed__);
							return;
						}
						break;
						IL_01b1:
						if (_003CplayerDocument_003E5__1 == null)
						{
							obj = Enumerable.First<IDocumentSnapshot<FirestorePlayerDTO>>(_003CplayerQuery_003E5__2.Documents);
						}
						else
						{
							IDocumentSnapshot<FirestorePlayerDTO> val = _003CplayerDocument_003E5__1;
							obj = val;
						}
						_003Cdocument_003E5__3 = obj;
						_003Cplayer_003E5__4 = _003Cdocument_003E5__3.Data;
						awaiter2 = ((IQuery)_003C_003E4__this._firestore.GetCollection("players/" + _003Cplayer_003E5__4.PlayerID + "/playerspirits")).GetDocumentsAsync<FirestorePlayerSpiritDTO>((Source)0).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__3 = awaiter2;
							_003CAuthenticateAsync_003Ed__10 _003CAuthenticateAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestorePlayerSpiritDTO>>, _003CAuthenticateAsync_003Ed__10>(ref awaiter2, ref _003CAuthenticateAsync_003Ed__);
							return;
						}
						goto IL_0272;
						IL_00ed:
						_003C_003Es__7 = awaiter4.GetResult();
						_003CplayerQuery_003E5__2 = _003C_003Es__7;
						_003C_003Es__7 = null;
						goto IL_01b1;
						IL_0190:
						_003C_003Es__8 = awaiter3.GetResult();
						_003CplayerDocument_003E5__1 = _003C_003Es__8;
						_003C_003Es__8 = null;
						goto IL_01b1;
					}
					_003C_003Es__13 = awaiter.GetResult();
					_003Cquestsref_003E5__6 = _003C_003Es__13;
					_003C_003Es__13 = null;
					_003Cplayer_003E5__4.PlayerQuests = Enumerable.ToDictionary<IDocumentSnapshot<FirestorePlayerQuestsDTO>, string, FirestorePlayerQuestsDTO>(_003Cquestsref_003E5__6.Documents, (Func<IDocumentSnapshot<FirestorePlayerQuestsDTO>, string>)((IDocumentSnapshot<FirestorePlayerQuestsDTO> s) => s.Reference.Id), (Func<IDocumentSnapshot<FirestorePlayerQuestsDTO>, FirestorePlayerQuestsDTO>)((IDocumentSnapshot<FirestorePlayerQuestsDTO> s) => s.Data));
					result = PlayerEntityMapper.ToEntity(_003Cplayer_003E5__4);
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__14 = ex;
					Console.WriteLine("Error auth" + _003Cex_003E5__14.Message);
					Console.WriteLine("Stacktrace", (object)(_003Cex_003E5__14.StackTrace ?? string.Empty));
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
	private sealed class _003CBatchUpdatePlayerAsync_003Ed__18 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<BatchUpdateOutcome> _003C_003Et__builder;

		public PlayerBatchUpdate batchUpdate;

		public PlayerRepository _003C_003E4__this;

		private IWriteBatch _003Cbatch_003E5__1;

		private IDocumentReference _003CplayerRef_003E5__2;

		private Dictionary<object, object> _003Cupdates_003E5__3;

		private Dictionary<object, object> _003CprofileUpdates_003E5__4;

		private Enumerator<string, long> _003C_003Es__5;

		private KeyValuePair<string, long> _003Ccurrency_003E5__6;

		private Enumerator<string, int> _003C_003Es__7;

		private KeyValuePair<string, int> _003Cchange_003E5__8;

		private Enumerator<string> _003C_003Es__9;

		private string _003Ckey_003E5__10;

		private Enumerator<string, List<string>> _003C_003Es__11;

		private KeyValuePair<string, List<string>> _003CsquadUpdate_003E5__12;

		private IDocumentReference _003CiconGuildMemberRef_003E5__13;

		private Dictionary<object, object> _003CguildMemberUpdates_003E5__14;

		private long _003CreputationChange_003E5__15;

		private IDocumentReference _003CguildMemberRef_003E5__16;

		private DailyBattleChestUpdate _003Cchest_003E5__17;

		private IDocumentReference _003CquestRef_003E5__18;

		private Dictionary<object, object> _003CquestUpdates_003E5__19;

		private Enumerator<string, TaskProgress> _003C_003Es__20;

		private KeyValuePair<string, TaskProgress> _003CtaskUpdate_003E5__21;

		private Enumerator<string, PlayerSpiritFieldUpdate> _003C_003Es__22;

		private KeyValuePair<string, PlayerSpiritFieldUpdate> _003CspiritUpdate_003E5__23;

		private IDocumentReference _003CspiritRef_003E5__24;

		private Dictionary<object, object> _003CspiritUpdates_003E5__25;

		private Enumerator<string, MoveStateUpdate> _003C_003Es__26;

		private KeyValuePair<string, MoveStateUpdate> _003CmoveUpdate_003E5__27;

		private Enumerator<NewSpiritDTO> _003C_003Es__28;

		private NewSpiritDTO _003CnewSpirit_003E5__29;

		private FirestorePlayerSpiritDTO _003CfirestoreSpiritData_003E5__30;

		private IDocumentReference _003CspiritRef_003E5__31;

		private Enumerator<string> _003C_003Es__32;

		private string _003CspiritId_003E5__33;

		private IDocumentReference _003CspiritRef_003E5__34;

		private IDocumentReference _003CprofileRef_003E5__35;

		private IDocumentSnapshot<FirestorePublicProfileDTO> _003Csnapshot_003E5__36;

		private IDocumentSnapshot<FirestorePublicProfileDTO> _003C_003Es__37;

		private global::System.Exception _003Cex_003E5__38;

		private global::System.Exception _003Cex_003E5__39;

		private TaskAwaiter<IDocumentSnapshot<FirestorePublicProfileDTO>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_1ac8: Unknown result type (might be due to invalid IL or missing references)
			//IL_1acd: Unknown result type (might be due to invalid IL or missing references)
			//IL_1ad5: Unknown result type (might be due to invalid IL or missing references)
			//IL_1b98: Unknown result type (might be due to invalid IL or missing references)
			//IL_1b9d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1ba5: Unknown result type (might be due to invalid IL or missing references)
			//IL_1c1e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1c23: Unknown result type (might be due to invalid IL or missing references)
			//IL_1c2b: Unknown result type (might be due to invalid IL or missing references)
			//IL_1be4: Unknown result type (might be due to invalid IL or missing references)
			//IL_1be9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_1bfe: Unknown result type (might be due to invalid IL or missing references)
			//IL_1c00: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			//IL_0346: Unknown result type (might be due to invalid IL or missing references)
			//IL_034b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_1b5e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1b63: Unknown result type (might be due to invalid IL or missing references)
			//IL_1b78: Unknown result type (might be due to invalid IL or missing references)
			//IL_1b7a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0359: Unknown result type (might be due to invalid IL or missing references)
			//IL_035e: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0524: Unknown result type (might be due to invalid IL or missing references)
			//IL_0529: Unknown result type (might be due to invalid IL or missing references)
			//IL_0415: Unknown result type (might be due to invalid IL or missing references)
			//IL_041a: Unknown result type (might be due to invalid IL or missing references)
			//IL_042b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0430: Unknown result type (might be due to invalid IL or missing references)
			//IL_0597: Unknown result type (might be due to invalid IL or missing references)
			//IL_0510: Unknown result type (might be due to invalid IL or missing references)
			//IL_04db: Unknown result type (might be due to invalid IL or missing references)
			//IL_069d: Unknown result type (might be due to invalid IL or missing references)
			//IL_070d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0712: Unknown result type (might be due to invalid IL or missing references)
			//IL_0720: Unknown result type (might be due to invalid IL or missing references)
			//IL_0725: Unknown result type (might be due to invalid IL or missing references)
			//IL_075e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0790: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bb7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bfb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cae: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cb3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0dc7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0dcc: Unknown result type (might be due to invalid IL or missing references)
			//IL_14dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_14e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_176f: Unknown result type (might be due to invalid IL or missing references)
			//IL_1774: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cc4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cc9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d3e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ddd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0de2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d73: Unknown result type (might be due to invalid IL or missing references)
			//IL_1552: Unknown result type (might be due to invalid IL or missing references)
			//IL_14ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_173e: Unknown result type (might be due to invalid IL or missing references)
			//IL_17fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_18fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_1a8e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1a93: Unknown result type (might be due to invalid IL or missing references)
			//IL_1aa8: Unknown result type (might be due to invalid IL or missing references)
			//IL_1aaa: Unknown result type (might be due to invalid IL or missing references)
			//IL_1476: Unknown result type (might be due to invalid IL or missing references)
			//IL_135d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1362: Unknown result type (might be due to invalid IL or missing references)
			//IL_1373: Unknown result type (might be due to invalid IL or missing references)
			//IL_1378: Unknown result type (might be due to invalid IL or missing references)
			//IL_13fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_1430: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			BatchUpdateOutcome result;
			try
			{
				if ((uint)num > 2u)
				{
				}
				try
				{
					TaskAwaiter<IDocumentSnapshot<FirestorePublicProfileDTO>> awaiter3;
					TaskAwaiter awaiter2;
					TaskAwaiter awaiter;
					switch (num)
					{
					default:
						_003Cbatch_003E5__1 = _003C_003E4__this._firestore.CreateBatch();
						_003CplayerRef_003E5__2 = _003C_003E4__this._firestore.GetCollection("players").GetDocument(batchUpdate.PlayerId);
						_003Cupdates_003E5__3 = new Dictionary<object, object>();
						if (batchUpdate.NewEP.HasValue)
						{
							_003Cupdates_003E5__3[(object)"playerep"] = batchUpdate.NewEP.Value;
							if (batchUpdate.LastEpRegenTime.HasValue)
							{
								_003Cupdates_003E5__3[(object)"lastEpRegenTime"] = batchUpdate.LastEpRegenTime.Value;
							}
						}
						else if (batchUpdate.EnergyChange != 0)
						{
							_003Cupdates_003E5__3[(object)"playerep"] = FieldValue.IntegerIncrement((long)batchUpdate.EnergyChange);
							if (batchUpdate.LastEpRegenTime.HasValue)
							{
								_003Cupdates_003E5__3[(object)"lastEpRegenTime"] = batchUpdate.LastEpRegenTime.Value;
							}
						}
						if (batchUpdate.SPChange != 0)
						{
							_003Cupdates_003E5__3[(object)"playersp"] = FieldValue.IntegerIncrement((long)batchUpdate.SPChange);
							if (batchUpdate.LastSpRegenTime.HasValue)
							{
								_003Cupdates_003E5__3[(object)"lastSpRegenTime"] = batchUpdate.LastSpRegenTime.Value;
							}
						}
						if (batchUpdate.ExperienceGain > 0)
						{
							_003Cupdates_003E5__3[(object)"playerexp"] = (batchUpdate.UpdateLevel ? ((object)batchUpdate.NewEXP) : FieldValue.IntegerIncrement((long)batchUpdate.ExperienceGain));
							if (batchUpdate.UpdateLevel)
							{
								_003Cupdates_003E5__3[(object)"playermaxexp"] = batchUpdate.NewMaxEXP;
								_003Cupdates_003E5__3[(object)"playerlevel"] = batchUpdate.NewPlayerLevel;
								_003Cupdates_003E5__3[(object)"playermaxep"] = batchUpdate.NewMaxEP;
								_003Cupdates_003E5__3[(object)"playermaxsp"] = batchUpdate.NewMaxSP;
								_003Cupdates_003E5__3[(object)"playerep"] = batchUpdate.NewMaxEP;
								_003Cupdates_003E5__3[(object)"playersp"] = batchUpdate.NewMaxSP;
							}
						}
						_003C_003Es__5 = batchUpdate.CurrencyChanges.GetEnumerator();
						try
						{
							while (_003C_003Es__5.MoveNext())
							{
								_003Ccurrency_003E5__6 = _003C_003Es__5.Current;
								if (_003Ccurrency_003E5__6.Value != 0)
								{
									_003Cupdates_003E5__3[(object)("playercurrencies." + _003Ccurrency_003E5__6.Key)] = FieldValue.IntegerIncrement(_003Ccurrency_003E5__6.Value);
								}
								_003Ccurrency_003E5__6 = default(KeyValuePair<string, long>);
							}
						}
						finally
						{
							if (num < 0)
							{
								((global::System.IDisposable)_003C_003Es__5).Dispose();
							}
						}
						_003C_003Es__5 = default(Enumerator<string, long>);
						if (batchUpdate.InventoryItemChanges.Count != 0)
						{
							_003C_003Es__7 = batchUpdate.InventoryItemChanges.GetEnumerator();
							try
							{
								while (_003C_003Es__7.MoveNext())
								{
									_003Cchange_003E5__8 = _003C_003Es__7.Current;
									if (_003Cchange_003E5__8.Value != 0 && !batchUpdate.InventoryKeysToDelete.Contains(_003Cchange_003E5__8.Key))
									{
										_003Cupdates_003E5__3[(object)("inventory." + _003Cchange_003E5__8.Key + ".amount")] = FieldValue.IntegerIncrement((long)_003Cchange_003E5__8.Value);
										_003Cupdates_003E5__3[(object)("inventory." + _003Cchange_003E5__8.Key + ".name")] = _003Cchange_003E5__8.Key;
									}
									_003Cchange_003E5__8 = default(KeyValuePair<string, int>);
								}
							}
							finally
							{
								if (num < 0)
								{
									((global::System.IDisposable)_003C_003Es__7).Dispose();
								}
							}
							_003C_003Es__7 = default(Enumerator<string, int>);
						}
						_003C_003Es__9 = batchUpdate.InventoryKeysToDelete.GetEnumerator();
						try
						{
							while (_003C_003Es__9.MoveNext())
							{
								_003Ckey_003E5__10 = _003C_003Es__9.Current;
								_003Cupdates_003E5__3[(object)("inventory." + _003Ckey_003E5__10)] = FieldValue.Delete();
								_003Ckey_003E5__10 = null;
							}
						}
						finally
						{
							if (num < 0)
							{
								((global::System.IDisposable)_003C_003Es__9).Dispose();
							}
						}
						_003C_003Es__9 = default(Enumerator<string>);
						if (batchUpdate.UpdateActiveSquadSlot && batchUpdate.NewActiveSquadSlot.HasValue)
						{
							_003Cupdates_003E5__3[(object)"activeSquadSlot"] = batchUpdate.NewActiveSquadSlot.Value;
						}
						if (batchUpdate.WinsChange != 0)
						{
							_003Cupdates_003E5__3[(object)"battleStats.wins"] = FieldValue.IntegerIncrement((long)batchUpdate.WinsChange);
						}
						if (batchUpdate.LossChange != 0)
						{
							_003Cupdates_003E5__3[(object)"battleStats.losses"] = FieldValue.IntegerIncrement((long)batchUpdate.LossChange);
						}
						if (batchUpdate.ScoreChange != 0)
						{
							_003Cupdates_003E5__3[(object)"battleStats.score"] = FieldValue.IntegerIncrement((long)batchUpdate.ScoreChange);
							_003Cupdates_003E5__3[(object)"battleStats.lastScoreUpdate"] = DateTimeOffset.UtcNow;
						}
						if (!string.IsNullOrEmpty(batchUpdate.NewTitle))
						{
							_003Cupdates_003E5__3[(object)"battleStats.title"] = batchUpdate.NewTitle;
						}
						if (batchUpdate.SquadUpdates.Count != 0)
						{
							_003C_003Es__11 = batchUpdate.SquadUpdates.GetEnumerator();
							try
							{
								while (_003C_003Es__11.MoveNext())
								{
									_003CsquadUpdate_003E5__12 = _003C_003Es__11.Current;
									_003Cupdates_003E5__3[(object)("squads." + _003CsquadUpdate_003E5__12.Key)] = _003CsquadUpdate_003E5__12.Value;
									_003CsquadUpdate_003E5__12 = default(KeyValuePair<string, List<string>>);
								}
							}
							finally
							{
								if (num < 0)
								{
									((global::System.IDisposable)_003C_003Es__11).Dispose();
								}
							}
							_003C_003Es__11 = default(Enumerator<string, List<string>>);
						}
						if (batchUpdate.UpdateBattleUnit && !string.IsNullOrEmpty(batchUpdate.ActiveBattleUnitId))
						{
							_003Cupdates_003E5__3[(object)"partnerSpiritID"] = batchUpdate.ActiveBattleUnitId;
						}
						if (!string.IsNullOrEmpty(batchUpdate.NewPlayerIcon))
						{
							_003Cupdates_003E5__3[(object)"playerIcon"] = batchUpdate.NewPlayerIcon;
						}
						if (!string.IsNullOrEmpty(batchUpdate.NewPlayerIcon) && !string.IsNullOrEmpty(batchUpdate.CurrentGuildId))
						{
							_003CiconGuildMemberRef_003E5__13 = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(batchUpdate.CurrentGuildId).GetCollection("members")
								.GetDocument(batchUpdate.PlayerId);
							_003Cbatch_003E5__1.UpdateData(_003CiconGuildMemberRef_003E5__13, new Dictionary<object, object> { [(object)"playerIcon"] = batchUpdate.NewPlayerIcon });
							_003CiconGuildMemberRef_003E5__13 = null;
						}
						if (!string.IsNullOrEmpty(batchUpdate.GuildUpdates.TargetPlayerId))
						{
							if (batchUpdate.GuildUpdates.HasUpdates())
							{
								_003Cupdates_003E5__3[(object)"guildId"] = batchUpdate.GuildUpdates.GuildId;
								if (batchUpdate.GuildUpdates.GuildRole != null)
								{
									_003Cupdates_003E5__3[(object)"guildRole"] = batchUpdate.GuildUpdates.GuildRole;
								}
								if (batchUpdate.GuildUpdates.GuildJoinedAt.HasValue)
								{
									_003Cupdates_003E5__3[(object)"guildJoinedAt"] = batchUpdate.GuildUpdates.GuildJoinedAt;
								}
							}
							if (!string.IsNullOrEmpty(batchUpdate.GuildUpdates.GuildId))
							{
								_003CguildMemberUpdates_003E5__14 = new Dictionary<object, object>();
								_003CguildMemberUpdates_003E5__14[(object)"level"] = FieldValue.IntegerIncrement(1L);
								if (batchUpdate.UpdateReputation && batchUpdate.CurrencyChanges.TryGetValue("reputation", ref _003CreputationChange_003E5__15))
								{
									_003CguildMemberUpdates_003E5__14[(object)"trophies"] = FieldValue.IntegerIncrement(_003CreputationChange_003E5__15);
								}
								_003CguildMemberRef_003E5__16 = _003C_003E4__this._firestore.GetCollection("guilds").GetDocument(batchUpdate.GuildUpdates.GuildId).GetCollection("members")
									.GetDocument(batchUpdate.PlayerId);
								_003Cbatch_003E5__1.UpdateData(_003CguildMemberRef_003E5__16, _003CguildMemberUpdates_003E5__14);
								_003CguildMemberUpdates_003E5__14 = null;
								_003CguildMemberRef_003E5__16 = null;
							}
						}
						if (batchUpdate.ViewedShopItems != null)
						{
							_003Cupdates_003E5__3[(object)"viewedShopItems"] = batchUpdate.ViewedShopItems;
						}
						if (batchUpdate.LastShopViewedLevel.HasValue)
						{
							_003Cupdates_003E5__3[(object)"lastShopViewedLevel"] = batchUpdate.LastShopViewedLevel.Value;
						}
						if (batchUpdate.SetAccountLinked.HasValue)
						{
							_003Cupdates_003E5__3[(object)"isAccountLinked"] = batchUpdate.SetAccountLinked.Value;
						}
						if (batchUpdate.DailyBattleChestUpdate != null)
						{
							_003Cchest_003E5__17 = batchUpdate.DailyBattleChestUpdate;
							_003Cupdates_003E5__3[(object)"dailyBattleChest.battlesCompleted"] = _003Cchest_003E5__17.BattlesCompleted;
							_003Cupdates_003E5__3[(object)"dailyBattleChest.lastResetAt"] = _003Cchest_003E5__17.LastResetAt;
							if (_003Cchest_003E5__17.LastClaimedAt.HasValue)
							{
								_003Cupdates_003E5__3[(object)"dailyBattleChest.lastClaimedAt"] = _003Cchest_003E5__17.LastClaimedAt.Value;
							}
							_003Cchest_003E5__17 = null;
						}
						if (Enumerable.Any<KeyValuePair<object, object>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<object, object>>)_003Cupdates_003E5__3))
						{
							_003Cbatch_003E5__1.UpdateData(_003CplayerRef_003E5__2, _003Cupdates_003E5__3);
						}
						if (Enumerable.Any<KeyValuePair<string, TaskProgress>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, TaskProgress>>)batchUpdate.TaskUpdates) && !string.IsNullOrEmpty(batchUpdate.QuestId))
						{
							_003CquestRef_003E5__18 = _003CplayerRef_003E5__2.GetCollection("quests").GetDocument(batchUpdate.QuestId);
							_003CquestUpdates_003E5__19 = new Dictionary<object, object>();
							_003C_003Es__20 = batchUpdate.TaskUpdates.GetEnumerator();
							try
							{
								while (_003C_003Es__20.MoveNext())
								{
									_003CtaskUpdate_003E5__21 = _003C_003Es__20.Current;
									_003CquestUpdates_003E5__19[(object)("tasks." + _003CtaskUpdate_003E5__21.Key)] = new Dictionary<string, object>
									{
										["isCompleted"] = _003CtaskUpdate_003E5__21.Value.IsCompleted,
										["step"] = _003CtaskUpdate_003E5__21.Value.Step
									};
									_003CtaskUpdate_003E5__21 = default(KeyValuePair<string, TaskProgress>);
								}
							}
							finally
							{
								if (num < 0)
								{
									((global::System.IDisposable)_003C_003Es__20).Dispose();
								}
							}
							_003C_003Es__20 = default(Enumerator<string, TaskProgress>);
							_003Cbatch_003E5__1.UpdateData(_003CquestRef_003E5__18, _003CquestUpdates_003E5__19);
							_003CquestRef_003E5__18 = null;
							_003CquestUpdates_003E5__19 = null;
						}
						if (Enumerable.Any<KeyValuePair<string, PlayerSpiritFieldUpdate>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, PlayerSpiritFieldUpdate>>)batchUpdate.SpiritFieldUpdates))
						{
							_003C_003Es__22 = batchUpdate.SpiritFieldUpdates.GetEnumerator();
							try
							{
								while (_003C_003Es__22.MoveNext())
								{
									_003CspiritUpdate_003E5__23 = _003C_003Es__22.Current;
									_003CspiritRef_003E5__24 = _003CplayerRef_003E5__2.GetCollection("playerspirits").GetDocument(_003CspiritUpdate_003E5__23.Key);
									_003CspiritUpdates_003E5__25 = new Dictionary<object, object>();
									if (_003CspiritUpdate_003E5__23.Value.LevelChange.HasValue)
									{
										_003CspiritUpdates_003E5__25[(object)"level"] = FieldValue.IntegerIncrement((long)_003CspiritUpdate_003E5__23.Value.LevelChange.Value);
									}
									if (_003CspiritUpdate_003E5__23.Value.HPChange.HasValue)
									{
										_003CspiritUpdates_003E5__25[(object)"HP"] = FieldValue.IntegerIncrement((long)_003CspiritUpdate_003E5__23.Value.HPChange.Value);
									}
									if (_003CspiritUpdate_003E5__23.Value.TrainingPointsChange.HasValue)
									{
										_003CspiritUpdates_003E5__25[(object)"points-unallocated"] = FieldValue.IntegerIncrement((long)_003CspiritUpdate_003E5__23.Value.TrainingPointsChange.Value);
									}
									if (_003CspiritUpdate_003E5__23.Value.SetPointsATK.HasValue)
									{
										_003CspiritUpdates_003E5__25[(object)"pointsATK"] = _003CspiritUpdate_003E5__23.Value.SetPointsATK.Value;
									}
									if (_003CspiritUpdate_003E5__23.Value.SetPointsDEF.HasValue)
									{
										_003CspiritUpdates_003E5__25[(object)"pointsDEF"] = _003CspiritUpdate_003E5__23.Value.SetPointsDEF.Value;
									}
									if (_003CspiritUpdate_003E5__23.Value.SetPointsSATK.HasValue)
									{
										_003CspiritUpdates_003E5__25[(object)"pointsMGK"] = _003CspiritUpdate_003E5__23.Value.SetPointsSATK.Value;
									}
									if (_003CspiritUpdate_003E5__23.Value.SetPointsSDEF.HasValue)
									{
										_003CspiritUpdates_003E5__25[(object)"pointsMDF"] = _003CspiritUpdate_003E5__23.Value.SetPointsSDEF.Value;
									}
									if (_003CspiritUpdate_003E5__23.Value.SetPointsSPD.HasValue)
									{
										_003CspiritUpdates_003E5__25[(object)"pointsSPD"] = _003CspiritUpdate_003E5__23.Value.SetPointsSPD.Value;
									}
									if (_003CspiritUpdate_003E5__23.Value.SetPointsINT.HasValue)
									{
										_003CspiritUpdates_003E5__25[(object)"pointsINT"] = _003CspiritUpdate_003E5__23.Value.SetPointsINT.Value;
									}
									if (!string.IsNullOrEmpty(_003CspiritUpdate_003E5__23.Value.SetNickname))
									{
										_003CspiritUpdates_003E5__25[(object)"nickname"] = _003CspiritUpdate_003E5__23.Value.SetNickname;
									}
									if (_003CspiritUpdate_003E5__23.Value.SetFavorite.HasValue)
									{
										_003CspiritUpdates_003E5__25[(object)"isFavorite"] = _003CspiritUpdate_003E5__23.Value.SetFavorite.Value;
									}
									if (_003CspiritUpdate_003E5__23.Value.SetHeldItemId != null)
									{
										_003CspiritUpdates_003E5__25[(object)"heldItemId"] = _003CspiritUpdate_003E5__23.Value.SetHeldItemId;
									}
									if (_003CspiritUpdate_003E5__23.Value.SetGearId != null)
									{
										_003CspiritUpdates_003E5__25[(object)"gearId"] = _003CspiritUpdate_003E5__23.Value.SetGearId;
									}
									if (_003CspiritUpdate_003E5__23.Value.SetTalentId != null)
									{
										_003CspiritUpdates_003E5__25[(object)"talentId"] = _003CspiritUpdate_003E5__23.Value.SetTalentId;
									}
									if (_003CspiritUpdate_003E5__23.Value.SetBaseSpiritId.HasValue)
									{
										_003CspiritUpdates_003E5__25[(object)"basespirit-ID"] = _003CspiritUpdate_003E5__23.Value.SetBaseSpiritId.Value;
									}
									if (!string.IsNullOrEmpty(_003CspiritUpdate_003E5__23.Value.SetName))
									{
										_003CspiritUpdates_003E5__25[(object)"name"] = _003CspiritUpdate_003E5__23.Value.SetName;
									}
									if (_003CspiritUpdate_003E5__23.Value.MoveChanges != null && _003CspiritUpdate_003E5__23.Value.MoveChanges.Count > 0)
									{
										if (_003CspiritUpdate_003E5__23.Value.UpdateType == SpiritUpdateType.Evolve)
										{
											_003CspiritUpdates_003E5__25[(object)"moves"] = Enumerable.ToDictionary<KeyValuePair<string, MoveStateUpdate>, string, object>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, MoveStateUpdate>>)_003CspiritUpdate_003E5__23.Value.MoveChanges, (Func<KeyValuePair<string, MoveStateUpdate>, string>)((KeyValuePair<string, MoveStateUpdate> m) => m.Key), (Func<KeyValuePair<string, MoveStateUpdate>, object>)((KeyValuePair<string, MoveStateUpdate> m) => new Dictionary<string, object>
											{
												["is-active"] = m.Value.IsActiveMove,
												["is-unlocked"] = m.Value.IsUnlocked
											}));
										}
										else
										{
											_003C_003Es__26 = _003CspiritUpdate_003E5__23.Value.MoveChanges.GetEnumerator();
											try
											{
												while (_003C_003Es__26.MoveNext())
												{
													_003CmoveUpdate_003E5__27 = _003C_003Es__26.Current;
													_003CspiritUpdates_003E5__25[(object)("moves." + _003CmoveUpdate_003E5__27.Key + ".is-active")] = _003CmoveUpdate_003E5__27.Value.IsActiveMove;
													_003CspiritUpdates_003E5__25[(object)("moves." + _003CmoveUpdate_003E5__27.Key + ".is-unlocked")] = _003CmoveUpdate_003E5__27.Value.IsUnlocked;
													_003CmoveUpdate_003E5__27 = default(KeyValuePair<string, MoveStateUpdate>);
												}
											}
											finally
											{
												if (num < 0)
												{
													((global::System.IDisposable)_003C_003Es__26).Dispose();
												}
											}
											_003C_003Es__26 = default(Enumerator<string, MoveStateUpdate>);
										}
									}
									if (Enumerable.Any<KeyValuePair<object, object>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<object, object>>)_003CspiritUpdates_003E5__25))
									{
										_003Cbatch_003E5__1.UpdateData(_003CspiritRef_003E5__24, _003CspiritUpdates_003E5__25);
									}
									_003CspiritRef_003E5__24 = null;
									_003CspiritUpdates_003E5__25 = null;
									_003CspiritUpdate_003E5__23 = default(KeyValuePair<string, PlayerSpiritFieldUpdate>);
								}
							}
							finally
							{
								if (num < 0)
								{
									((global::System.IDisposable)_003C_003Es__22).Dispose();
								}
							}
							_003C_003Es__22 = default(Enumerator<string, PlayerSpiritFieldUpdate>);
						}
						if (batchUpdate.SpiritsToAdd.Count > 0)
						{
							_003C_003Es__28 = batchUpdate.SpiritsToAdd.GetEnumerator();
							try
							{
								while (_003C_003Es__28.MoveNext())
								{
									_003CnewSpirit_003E5__29 = _003C_003Es__28.Current;
									FirestorePlayerSpiritDTO obj2 = new FirestorePlayerSpiritDTO
									{
										PlayerSpiritID = _003CnewSpirit_003E5__29.PlayerSpiritId,
										PlayerName = _003CnewSpirit_003E5__29.PlayerName,
										Name = _003CnewSpirit_003E5__29.Name,
										Nickname = _003CnewSpirit_003E5__29.Nickname,
										DateOwned = _003CnewSpirit_003E5__29.DateOwned,
										BaseSpiritID = _003CnewSpirit_003E5__29.BaseSpiritId,
										Level = _003CnewSpirit_003E5__29.Level,
										HP = _003CnewSpirit_003E5__29.HP,
										TrainingPoints = _003CnewSpirit_003E5__29.TrainingPoints,
										PointsATK = _003CnewSpirit_003E5__29.PointsATK,
										PointsDEF = _003CnewSpirit_003E5__29.PointsDEF,
										PointsSATK = _003CnewSpirit_003E5__29.PointsSATK,
										PointsSDEF = _003CnewSpirit_003E5__29.PointsSDEF,
										PointsSPD = _003CnewSpirit_003E5__29.PointsSPD,
										PointsINT = _003CnewSpirit_003E5__29.PointsINT,
										IsFavorite = _003CnewSpirit_003E5__29.IsFavorite,
										HeldItemID = _003CnewSpirit_003E5__29.HeldItemId,
										GearID = _003CnewSpirit_003E5__29.GearId,
										TalentID = _003CnewSpirit_003E5__29.TalentId
									};
									Dictionary<string, ValueTuple<bool, bool>> moves = _003CnewSpirit_003E5__29.Moves;
									obj2.Moves = ((moves != null) ? Enumerable.ToDictionary<KeyValuePair<string, ValueTuple<bool, bool>>, string, FirestoreMoveStateDTO>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, ValueTuple<bool, bool>>>)moves, (Func<KeyValuePair<string, ValueTuple<bool, bool>>, string>)((KeyValuePair<string, ValueTuple<bool, bool>> kv) => kv.Key), (Func<KeyValuePair<string, ValueTuple<bool, bool>>, FirestoreMoveStateDTO>)((KeyValuePair<string, ValueTuple<bool, bool>> kv) => new FirestoreMoveStateDTO
									{
										IsActiveMove = kv.Value.Item2,
										IsUnlocked = kv.Value.Item1
									})) : null);
									_003CfirestoreSpiritData_003E5__30 = obj2;
									_003CspiritRef_003E5__31 = _003CplayerRef_003E5__2.GetCollection("playerspirits").GetDocument(_003CnewSpirit_003E5__29.PlayerSpiritId);
									_003Cbatch_003E5__1.SetData(_003CspiritRef_003E5__31, (object)_003CfirestoreSpiritData_003E5__30, (SetOptions)null);
									_003CfirestoreSpiritData_003E5__30 = null;
									_003CspiritRef_003E5__31 = null;
									_003CnewSpirit_003E5__29 = null;
								}
							}
							finally
							{
								if (num < 0)
								{
									((global::System.IDisposable)_003C_003Es__28).Dispose();
								}
							}
							_003C_003Es__28 = default(Enumerator<NewSpiritDTO>);
						}
						if (batchUpdate.SpiritsToRemove.Count > 0)
						{
							_003C_003Es__32 = batchUpdate.SpiritsToRemove.GetEnumerator();
							try
							{
								while (_003C_003Es__32.MoveNext())
								{
									_003CspiritId_003E5__33 = _003C_003Es__32.Current;
									_003CspiritRef_003E5__34 = _003CplayerRef_003E5__2.GetCollection("playerspirits").GetDocument(_003CspiritId_003E5__33);
									_003Cbatch_003E5__1.DeleteDocument(_003CspiritRef_003E5__34);
									_003CspiritRef_003E5__34 = null;
									_003CspiritId_003E5__33 = null;
								}
							}
							finally
							{
								if (num < 0)
								{
									((global::System.IDisposable)_003C_003Es__32).Dispose();
								}
							}
							_003C_003Es__32 = default(Enumerator<string>);
						}
						_003CprofileUpdates_003E5__4 = new Dictionary<object, object>();
						if (batchUpdate.ExperienceGain > 0 && batchUpdate.UpdateLevel)
						{
							_003CprofileUpdates_003E5__4[(object)"playerlevel"] = batchUpdate.NewPlayerLevel;
						}
						if (batchUpdate.WinsChange != 0)
						{
							_003CprofileUpdates_003E5__4[(object)"battleStats.wins"] = FieldValue.IntegerIncrement((long)batchUpdate.WinsChange);
						}
						if (batchUpdate.LossChange != 0)
						{
							_003CprofileUpdates_003E5__4[(object)"battleStats.losses"] = FieldValue.IntegerIncrement((long)batchUpdate.LossChange);
						}
						if (batchUpdate.ScoreChange != 0)
						{
							_003CprofileUpdates_003E5__4[(object)"battleStats.score"] = FieldValue.IntegerIncrement((long)batchUpdate.ScoreChange);
							_003CprofileUpdates_003E5__4[(object)"battleStats.lastScoreUpdate"] = DateTimeOffset.UtcNow;
						}
						if (!string.IsNullOrEmpty(batchUpdate.NewTitle))
						{
							_003CprofileUpdates_003E5__4[(object)"battleStats.title"] = batchUpdate.NewTitle;
						}
						if (batchUpdate.NewActiveSquadComp != null)
						{
							_003CprofileUpdates_003E5__4[(object)"activeSquad"] = batchUpdate.NewActiveSquadComp;
						}
						if (batchUpdate.UpdateBattleUnit && !string.IsNullOrEmpty(batchUpdate.ActiveBattleUnitId))
						{
							_003CprofileUpdates_003E5__4[(object)"partnerSpiritID"] = batchUpdate.ActiveBattleUnitId;
						}
						if (!string.IsNullOrEmpty(batchUpdate.GuildUpdates.TargetPlayerId) && batchUpdate.GuildUpdates.GuildId != null)
						{
							_003CprofileUpdates_003E5__4[(object)"guildId"] = batchUpdate.GuildUpdates.GuildId;
						}
						if (!string.IsNullOrEmpty(batchUpdate.NewPlayerIcon))
						{
							_003CprofileUpdates_003E5__4[(object)"playerIcon"] = batchUpdate.NewPlayerIcon;
						}
						if (Enumerable.Any<KeyValuePair<object, object>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<object, object>>)_003CprofileUpdates_003E5__4))
						{
							_003CprofileRef_003E5__35 = _003C_003E4__this._firestore.GetCollection("publicProfiles").GetDocument(batchUpdate.PlayerId);
							awaiter3 = _003CprofileRef_003E5__35.GetDocumentSnapshotAsync<FirestorePublicProfileDTO>((Source)0).GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter3;
								_003CBatchUpdatePlayerAsync_003Ed__18 _003CBatchUpdatePlayerAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestorePublicProfileDTO>>, _003CBatchUpdatePlayerAsync_003Ed__18>(ref awaiter3, ref _003CBatchUpdatePlayerAsync_003Ed__);
								return;
							}
							goto IL_1ae4;
						}
						goto IL_1b53;
					case 0:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<FirestorePublicProfileDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_1ae4;
					case 1:
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_1bb4;
					case 2:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_1c3a;
						}
						IL_1bb4:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						if (!batchUpdate.UpdateLeaderboard)
						{
							break;
						}
						awaiter = _003C_003E4__this.UpdateLeaderboardEntry(batchUpdate.PlayerId).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter;
							_003CBatchUpdatePlayerAsync_003Ed__18 _003CBatchUpdatePlayerAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CBatchUpdatePlayerAsync_003Ed__18>(ref awaiter, ref _003CBatchUpdatePlayerAsync_003Ed__);
							return;
						}
						goto IL_1c3a;
						IL_1ae4:
						_003C_003Es__37 = awaiter3.GetResult();
						_003Csnapshot_003E5__36 = _003C_003Es__37;
						if (_003Csnapshot_003E5__36 != null && _003Csnapshot_003E5__36?.Data != null)
						{
							_003C_003Es__37 = null;
							_003Cbatch_003E5__1.UpdateData(_003CprofileRef_003E5__35, _003CprofileUpdates_003E5__4);
						}
						_003CprofileRef_003E5__35 = null;
						_003Csnapshot_003E5__36 = null;
						goto IL_1b53;
						IL_1c3a:
						((TaskAwaiter)(ref awaiter)).GetResult();
						break;
						IL_1b53:
						awaiter2 = _003Cbatch_003E5__1.CommitAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter2;
							_003CBatchUpdatePlayerAsync_003Ed__18 _003CBatchUpdatePlayerAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CBatchUpdatePlayerAsync_003Ed__18>(ref awaiter2, ref _003CBatchUpdatePlayerAsync_003Ed__);
							return;
						}
						goto IL_1bb4;
					}
					result = BatchUpdateOutcome.Success;
				}
				catch (global::System.Exception ex) when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					_003Cex_003E5__38 = ex;
					return _003Cex_003E5__38.Message.Contains("PERMISSION_DENIED", (StringComparison)5);
				}).Invoke())
				{
					Console.WriteLine("Batch update permanently rejected (permission denied): " + _003Cex_003E5__38.Message);
					result = BatchUpdateOutcome.PermanentFailure;
				}
				catch (global::System.Exception ex2)
				{
					_003Cex_003E5__39 = ex2;
					Console.WriteLine("Batch update failed (transient): " + _003Cex_003E5__39.Message);
					Console.WriteLine(_003Cex_003E5__39.StackTrace);
					result = BatchUpdateOutcome.TransientFailure;
				}
			}
			catch (global::System.Exception ex2)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex2);
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
	private sealed class _003CCheckUsernameExistsAsync_003Ed__16 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string username;

		public PlayerRepository _003C_003E4__this;

		private IQuerySnapshot<FirestoreUserDTO> _003CplayerQuery_003E5__1;

		private IQuerySnapshot<FirestoreUserDTO> _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<IQuerySnapshot<FirestoreUserDTO>> _003C_003Eu__1;

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
					TaskAwaiter<IQuerySnapshot<FirestoreUserDTO>> awaiter;
					if (num != 0)
					{
						awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection("users")).WhereEqualsTo("username", (object)username).LimitedTo(1).GetDocumentsAsync<FirestoreUserDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CCheckUsernameExistsAsync_003Ed__16 _003CCheckUsernameExistsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreUserDTO>>, _003CCheckUsernameExistsAsync_003Ed__16>(ref awaiter, ref _003CCheckUsernameExistsAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreUserDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003CplayerQuery_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					result = _003CplayerQuery_003E5__1.Count > 0;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("Error checking username: " + _003Cex_003E5__3.Message);
					result = true;
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
	private sealed class _003CCreatePlayerAsync_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public Player player;

		public PlayerRepository _003C_003E4__this;

		private IWriteBatch _003Cbatch_003E5__1;

		private FirestorePlayerDTO _003CnewPlayerDTO_003E5__2;

		private IDocumentReference _003CplayerRef_003E5__3;

		private global::System.Collections.Generic.IEnumerable<PlayerSpirit> _003CplayerSpirits_003E5__4;

		private Dictionary<string, FirestorePlayerQuestsDTO> _003CplayerQuests_003E5__5;

		private IDocumentReference _003CstoryQuestRef_003E5__6;

		private IDocumentReference _003CchallengeQuestRef_003E5__7;

		private global::System.Collections.Generic.IEnumerator<PlayerSpirit> _003C_003Es__8;

		private PlayerSpirit _003CplayerSpirit_003E5__9;

		private FirestorePlayerSpiritDTO _003CplayerSpiritDTO_003E5__10;

		private IDocumentReference _003CplayerSpiritRef_003E5__11;

		private FirestorePublicProfileDTO _003CpublicProfileDTO_003E5__12;

		private IDocumentReference _003CpublicProfileRef_003E5__13;

		private global::System.Exception _003Cex_003E5__14;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0978: Unknown result type (might be due to invalid IL or missing references)
			//IL_097d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0985: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_093e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0943: Unknown result type (might be due to invalid IL or missing references)
			//IL_0958: Unknown result type (might be due to invalid IL or missing references)
			//IL_095a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						ArgumentNullException.ThrowIfNull((object)player, "player");
						if (string.IsNullOrEmpty(player.PlayerID))
						{
							throw new ArgumentException("PlayerID is required", "player");
						}
						if (string.IsNullOrEmpty(player.Playername))
						{
							throw new ArgumentException("Playername is required", "player");
						}
						if (player.PlayerSpirits == null || ((global::System.Collections.Generic.IReadOnlyCollection<KeyValuePair<string, PlayerSpirit>>)player.PlayerSpirits).Count == 0)
						{
							throw new ArgumentException("Player must have at least one PlayerSpirit", "player");
						}
						if (player.PlayerQuests == null || !player.PlayerQuests.ContainsKey("story") || !player.PlayerQuests.ContainsKey("challenge"))
						{
							throw new ArgumentException("Player must have 'story' and 'challenge' quests", "player");
						}
						_003Cbatch_003E5__1 = _003C_003E4__this._firestore.CreateBatch();
						_003CnewPlayerDTO_003E5__2 = new FirestorePlayerDTO
						{
							PlayerID = player.PlayerID,
							Playername = player.Playername,
							PlayerPassword = player.PlayerPassword,
							EXP = player.EXP,
							MaxEXP = player.MaxEXP,
							EP = player.EP,
							MaxEP = player.MaxEP,
							SP = player.SP,
							MaxSP = player.MaxSP,
							PartnerSpiritId = player.PartnerSpiritId,
							PlayerLevel = player.PlayerLevel,
							LastEpRegenTime = player.LastEpRegenTime,
							LastSpRegenTime = player.LastSpRegenTime,
							Inventory = Enumerable.ToDictionary<KeyValuePair<string, Inventory>, string, FirestoreInventoryDTO>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, Inventory>>)player.Inventory, (Func<KeyValuePair<string, Inventory>, string>)((KeyValuePair<string, Inventory> kvp) => kvp.Key), (Func<KeyValuePair<string, Inventory>, FirestoreInventoryDTO>)((KeyValuePair<string, Inventory> kvp) => new FirestoreInventoryDTO
							{
								Name = kvp.Value.Name,
								Amount = kvp.Value.Amount
							})),
							Currencies = Enumerable.ToDictionary<KeyValuePair<string, long>, string, long>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, long>>)player.Currencies, (Func<KeyValuePair<string, long>, string>)((KeyValuePair<string, long> kvp) => kvp.Key), (Func<KeyValuePair<string, long>, long>)((KeyValuePair<string, long> kvp) => kvp.Value)),
							ActiveSquadSlot = player.ActiveSquadSlot,
							Squads = Enumerable.ToDictionary<KeyValuePair<string, List<string>>, string, List<string>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, List<string>>>)player.Squads, (Func<KeyValuePair<string, List<string>>, string>)((KeyValuePair<string, List<string>> kvp) => kvp.Key), (Func<KeyValuePair<string, List<string>>, List<string>>)((KeyValuePair<string, List<string>> kvp) => kvp.Value)),
							BattleStats = new FirestoreBattleStatsDTO
							{
								Wins = player.BattleStats.Wins,
								Losses = player.BattleStats.Losses,
								Score = player.BattleStats.Score,
								Title = player.BattleStats.Title,
								LastScoreUpdate = player.BattleStats.LastScoreUpdate
							},
							GuildId = player.GuildId,
							GuildJoinedAt = player.GuildJoinedAt,
							GuildRole = ((object)player.GuildRole).ToString(),
							ViewedShopItems = Enumerable.ToList<string>((global::System.Collections.Generic.IEnumerable<string>)player.ViewedShopItems),
							LastShopViewedLevel = player.LastShopViewedLevel
						};
						_003CplayerRef_003E5__3 = _003C_003E4__this._firestore.GetCollection("players").GetDocument(player.PlayerID);
						_003Cbatch_003E5__1.SetData(_003CplayerRef_003E5__3, (object)_003CnewPlayerDTO_003E5__2, (SetOptions)null);
						_003CplayerSpirits_003E5__4 = player.PlayerSpirits.Values;
						_003C_003Es__8 = _003CplayerSpirits_003E5__4.GetEnumerator();
						try
						{
							while (((global::System.Collections.IEnumerator)_003C_003Es__8).MoveNext())
							{
								_003CplayerSpirit_003E5__9 = _003C_003Es__8.Current;
								FirestorePlayerSpiritDTO obj = new FirestorePlayerSpiritDTO
								{
									PlayerSpiritID = _003CplayerSpirit_003E5__9.PlayerSpiritID,
									PlayerName = _003CplayerSpirit_003E5__9.PlayerName,
									Name = _003CplayerSpirit_003E5__9.Name,
									Nickname = _003CplayerSpirit_003E5__9.Nickname,
									DateOwned = _003CplayerSpirit_003E5__9.DateOwned,
									BaseSpiritID = _003CplayerSpirit_003E5__9.BaseSpiritID,
									Level = _003CplayerSpirit_003E5__9.Level,
									HP = _003CplayerSpirit_003E5__9.HP,
									TrainingPoints = _003CplayerSpirit_003E5__9.TrainingPoints,
									PointsATK = _003CplayerSpirit_003E5__9.PointsATK,
									PointsDEF = _003CplayerSpirit_003E5__9.PointsDEF,
									PointsSATK = _003CplayerSpirit_003E5__9.PointsSATK,
									PointsSDEF = _003CplayerSpirit_003E5__9.PointsSDEF,
									PointsSPD = _003CplayerSpirit_003E5__9.PointsSPD,
									PointsINT = _003CplayerSpirit_003E5__9.PointsINT,
									IsFavorite = _003CplayerSpirit_003E5__9.IsFavorite,
									HeldItemID = _003CplayerSpirit_003E5__9.HeldItemID,
									GearID = _003CplayerSpirit_003E5__9.GearID,
									TalentID = _003CplayerSpirit_003E5__9.TalentID
								};
								IReadOnlyDictionary<string, MoveState>? moves = _003CplayerSpirit_003E5__9.Moves;
								obj.Moves = ((moves != null) ? Enumerable.ToDictionary<KeyValuePair<string, MoveState>, string, FirestoreMoveStateDTO>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, MoveState>>)moves, (Func<KeyValuePair<string, MoveState>, string>)((KeyValuePair<string, MoveState> kv) => kv.Key), (Func<KeyValuePair<string, MoveState>, FirestoreMoveStateDTO>)((KeyValuePair<string, MoveState> kv) => new FirestoreMoveStateDTO
								{
									IsActiveMove = kv.Value.IsActiveMove,
									IsUnlocked = kv.Value.IsUnlocked
								})) : null);
								_003CplayerSpiritDTO_003E5__10 = obj;
								_003CplayerSpiritRef_003E5__11 = _003C_003E4__this._firestore.GetCollection("players/" + player.PlayerID + "/playerspirits").GetDocument(_003CplayerSpiritDTO_003E5__10.PlayerSpiritID);
								_003Cbatch_003E5__1.SetData(_003CplayerSpiritRef_003E5__11, (object)_003CplayerSpiritDTO_003E5__10, (SetOptions)null);
								_003CplayerSpiritDTO_003E5__10 = null;
								_003CplayerSpiritRef_003E5__11 = null;
								_003CplayerSpirit_003E5__9 = null;
							}
						}
						finally
						{
							if (num < 0 && _003C_003Es__8 != null)
							{
								((global::System.IDisposable)_003C_003Es__8).Dispose();
							}
						}
						_003C_003Es__8 = null;
						_003CplayerQuests_003E5__5 = Enumerable.ToDictionary<KeyValuePair<string, PlayerQuest>, string, FirestorePlayerQuestsDTO>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, PlayerQuest>>)player.PlayerQuests, (Func<KeyValuePair<string, PlayerQuest>, string>)((KeyValuePair<string, PlayerQuest> kvp) => kvp.Key), (Func<KeyValuePair<string, PlayerQuest>, FirestorePlayerQuestsDTO>)((KeyValuePair<string, PlayerQuest> kvp) => new FirestorePlayerQuestsDTO
						{
							QuestId = kvp.Value.QuestId,
							Tasks = Enumerable.ToDictionary<KeyValuePair<string, TaskProgress>, string, FirestoreTaskProgressDTO>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, TaskProgress>>)kvp.Value.Tasks, (Func<KeyValuePair<string, TaskProgress>, string>)((KeyValuePair<string, TaskProgress> taskKvp) => taskKvp.Key), (Func<KeyValuePair<string, TaskProgress>, FirestoreTaskProgressDTO>)((KeyValuePair<string, TaskProgress> taskKvp) => new FirestoreTaskProgressDTO
							{
								IsCompleted = taskKvp.Value.IsCompleted,
								Step = taskKvp.Value.Step
							}))
						}));
						_003CstoryQuestRef_003E5__6 = _003CplayerRef_003E5__3.GetCollection("quests").GetDocument("story");
						_003CchallengeQuestRef_003E5__7 = _003CplayerRef_003E5__3.GetCollection("quests").GetDocument("challenge");
						_003Cbatch_003E5__1.SetData(_003CstoryQuestRef_003E5__6, (object)_003CplayerQuests_003E5__5["story"], (SetOptions)null);
						_003Cbatch_003E5__1.SetData(_003CchallengeQuestRef_003E5__7, (object)_003CplayerQuests_003E5__5["challenge"], (SetOptions)null);
						if (player.IsAccountLinked)
						{
							FirestorePublicProfileDTO firestorePublicProfileDTO = new FirestorePublicProfileDTO();
							firestorePublicProfileDTO.PlayerName = player.Playername;
							firestorePublicProfileDTO.PlayerLevel = player.PlayerLevel;
							firestorePublicProfileDTO.BattleStats = new FirestoreBattleStatsDTO
							{
								Wins = player.BattleStats.Wins,
								Losses = player.BattleStats.Losses,
								Score = player.BattleStats.Score,
								Title = player.BattleStats.Title,
								LastScoreUpdate = player.BattleStats.LastScoreUpdate
							};
							firestorePublicProfileDTO.ActiveSquad.Add("");
							firestorePublicProfileDTO.ActiveSquad.Add("");
							firestorePublicProfileDTO.ActiveSquad.Add("");
							firestorePublicProfileDTO.PartnerSpiritId = player.PartnerSpiritId;
							firestorePublicProfileDTO.GuildId = player.GuildId;
							_003CpublicProfileDTO_003E5__12 = firestorePublicProfileDTO;
							_003CpublicProfileRef_003E5__13 = _003C_003E4__this._firestore.GetCollection("publicProfiles").GetDocument(player.PlayerID);
							_003Cbatch_003E5__1.SetData(_003CpublicProfileRef_003E5__13, (object)_003CpublicProfileDTO_003E5__12, (SetOptions)null);
							_003CpublicProfileDTO_003E5__12 = null;
							_003CpublicProfileRef_003E5__13 = null;
						}
						awaiter = _003Cbatch_003E5__1.CommitAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CCreatePlayerAsync_003Ed__5 _003CCreatePlayerAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CCreatePlayerAsync_003Ed__5>(ref awaiter, ref _003CCreatePlayerAsync_003Ed__);
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
					_003Cex_003E5__14 = ex;
					Console.WriteLine("Error creating player: " + _003Cex_003E5__14.Message);
					Console.WriteLine("StackTrace: " + _003Cex_003E5__14.StackTrace);
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

	[CompilerGenerated]
	private sealed class _003CCreatePublicProfile_003Ed__6 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public Player player;

		public PlayerRepository _003C_003E4__this;

		private FirestorePublicProfileDTO _003CpublicProfileDTO_003E5__1;

		private IDocumentReference _003CpublicProfileRef_003E5__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0191: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						_003CpublicProfileDTO_003E5__1 = new FirestorePublicProfileDTO
						{
							PlayerName = player.Playername,
							PlayerLevel = player.PlayerLevel,
							BattleStats = new FirestoreBattleStatsDTO
							{
								Wins = player.BattleStats.Wins,
								Losses = player.BattleStats.Losses,
								Score = player.BattleStats.Score,
								Title = player.BattleStats.Title,
								LastScoreUpdate = player.BattleStats.LastScoreUpdate
							},
							ActiveSquad = Enumerable.ToList<string>((global::System.Collections.Generic.IEnumerable<string>)player.Squads[player.ActiveSquadSlot.ToString()]),
							PartnerSpiritId = player.PartnerSpiritId,
							GuildId = player.GuildId
						};
						_003CpublicProfileRef_003E5__2 = _003C_003E4__this._firestore.GetCollection("publicProfiles").GetDocument(player.PlayerID);
						awaiter = _003C_003E4__this._firestore.GetCollection("publicProfiles").GetDocument(_003CpublicProfileRef_003E5__2.Id).SetDataAsync((object)_003CpublicProfileDTO_003E5__1, (SetOptions)null)
							.GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CCreatePublicProfile_003Ed__6 _003CCreatePublicProfile_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CCreatePublicProfile_003Ed__6>(ref awaiter, ref _003CCreatePublicProfile_003Ed__);
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
					_003Cex_003E5__3 = ex;
					Console.WriteLine("Creating public profile failed: " + _003Cex_003E5__3.Message);
					Console.WriteLine("Stacktrace " + _003Cex_003E5__3.StackTrace);
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

	[CompilerGenerated]
	private sealed class _003CCreateUserAsync_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public FirestoreUserDTO user;

		public PlayerRepository _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._firestore.GetCollection("users").GetDocument(user.UserID).SetDataAsync((object)user, (SetOptions)null)
						.GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CCreateUserAsync_003Ed__13 _003CCreateUserAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCreateUserAsync_003Ed__13>(ref awaiter, ref _003CCreateUserAsync_003Ed__);
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
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CDeletePlayerAsync_003Ed__17 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string playerId;

		public PlayerRepository _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._firestore.GetCollection("players").GetDocument(playerId).DeleteDocumentAsync()
							.GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CDeletePlayerAsync_003Ed__17 _003CDeletePlayerAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CDeletePlayerAsync_003Ed__17>(ref awaiter, ref _003CDeletePlayerAsync_003Ed__);
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
					_003Cex_003E5__1 = ex;
					Console.WriteLine("Error deleting player: " + _003Cex_003E5__1.Message);
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

	[CompilerGenerated]
	private sealed class _003CDeleteUserAsync_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public FirestoreUserDTO user;

		public PlayerRepository _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._firestore.GetCollection("users").GetDocument(user.UserID).DeleteDocumentAsync()
						.GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CDeleteUserAsync_003Ed__15 _003CDeleteUserAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CDeleteUserAsync_003Ed__15>(ref awaiter, ref _003CDeleteUserAsync_003Ed__);
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
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetDailyBattleTasksAsync_003Ed__30 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<PlayerDailyBattleTasks> _003C_003Et__builder;

		public string playerId;

		public string dateKey;

		public PlayerRepository _003C_003E4__this;

		private IDocumentSnapshot<FirestoreDailyBattleTasksDTO> _003Csnapshot_003E5__1;

		private IDocumentSnapshot<FirestoreDailyBattleTasksDTO> _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<IDocumentSnapshot<FirestoreDailyBattleTasksDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			PlayerDailyBattleTasks result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IDocumentSnapshot<FirestoreDailyBattleTasksDTO>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._firestore.GetCollection($"{"players"}/{playerId}/{"dailyBattleTasks"}").GetDocument(dateKey).GetDocumentSnapshotAsync<FirestoreDailyBattleTasksDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetDailyBattleTasksAsync_003Ed__30 _003CGetDailyBattleTasksAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestoreDailyBattleTasksDTO>>, _003CGetDailyBattleTasksAsync_003Ed__30>(ref awaiter, ref _003CGetDailyBattleTasksAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<FirestoreDailyBattleTasksDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Csnapshot_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					result = ((_003Csnapshot_003E5__1?.Data != null) ? PlayerDailyBattleTasks.Rehydrate(dateKey, _003Csnapshot_003E5__1.Data.ToTaskDict()) : null);
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("GetDailyBattleTasksAsync error: " + _003Cex_003E5__3.Message);
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
	private sealed class _003CGetEmailByUserAsync_003Ed__11 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

		public string username;

		public PlayerRepository _003C_003E4__this;

		private IQuerySnapshot<FirestoreUserDTO> _003Cuser_003E5__1;

		private IQuerySnapshot<FirestoreUserDTO> _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<IQuerySnapshot<FirestoreUserDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			string result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestoreUserDTO>> awaiter;
					if (num != 0)
					{
						awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection("users")).WhereEqualsTo("username", (object)username).GetDocumentsAsync<FirestoreUserDTO>((Source)0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetEmailByUserAsync_003Ed__11 _003CGetEmailByUserAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreUserDTO>>, _003CGetEmailByUserAsync_003Ed__11>(ref awaiter, ref _003CGetEmailByUserAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreUserDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Cuser_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					result = Enumerable.First<IDocumentSnapshot<FirestoreUserDTO>>(_003Cuser_003E5__1.Documents).Data.Email;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine(_003Cex_003E5__3.Message);
					Console.WriteLine(_003Cex_003E5__3.StackTrace);
					result = string.Empty;
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
	private sealed class _003CGetFriendPresencesAsync_003Ed__33 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Dictionary<string, ValueTuple<DateTimeOffset?, string?>>> _003C_003Et__builder;

		public global::System.Collections.Generic.IEnumerable<string> playerIds;

		public PlayerRepository _003C_003E4__this;

		private Dictionary<string, ValueTuple<DateTimeOffset?, string?>> _003Cresult_003E5__1;

		private global::System.Collections.Generic.IEnumerable<global::System.Threading.Tasks.Task<ValueTuple<string, DateTimeOffset?, string>>> _003Ctasks_003E5__2;

		private ValueTuple<string, DateTimeOffset?, string>[] _003Cresults_003E5__3;

		private ValueTuple<string, DateTimeOffset?, string>[] _003C_003Es__4;

		private ValueTuple<string, DateTimeOffset?, string>[] _003C_003Es__5;

		private int _003C_003Es__6;

		private string _003Cid_003E5__7;

		private DateTimeOffset? _003Cts_003E5__8;

		private string _003Cicon_003E5__9;

		private global::System.Exception _003Cex_003E5__10;

		private TaskAwaiter<ValueTuple<string, DateTimeOffset?, string>[]> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Dictionary<string, ValueTuple<DateTimeOffset?, string>> result;
			try
			{
				if (num != 0)
				{
					_003Cresult_003E5__1 = new Dictionary<string, ValueTuple<DateTimeOffset?, string>>();
				}
				try
				{
					TaskAwaiter<ValueTuple<string, DateTimeOffset?, string>[]> awaiter;
					if (num != 0)
					{
						_003Ctasks_003E5__2 = Enumerable.Select<string, global::System.Threading.Tasks.Task<ValueTuple<string, DateTimeOffset?, string>>>(playerIds, (Func<string, global::System.Threading.Tasks.Task<ValueTuple<string, DateTimeOffset?, string>>>)([AsyncStateMachine(typeof(_003C_003CGetFriendPresencesAsync_003Eb__33_0_003Ed))] [DebuggerStepThrough] [CompilerGenerated] async (string id) =>
						{
							//IL_0007: Unknown result type (might be due to invalid IL or missing references)
							//IL_000c: Unknown result type (might be due to invalid IL or missing references)
							try
							{
								IDocumentSnapshot<FirestorePublicProfileDTO> snapshot = await _003C_003E4__this._firestore.GetCollection("publicProfiles").GetDocument(id).GetDocumentSnapshotAsync<FirestorePublicProfileDTO>((Source)0);
								DateTimeOffset? ts = snapshot?.Data?.LastOnlineAt;
								string icon = snapshot?.Data?.PlayerIcon;
								DateTimeOffset? val2 = ts;
								DateTimeOffset minValue = DateTimeOffset.MinValue;
								return new ValueTuple<string, DateTimeOffset?, string>(id, (val2.HasValue && val2.GetValueOrDefault() == minValue) ? null : ts, icon);
							}
							catch
							{
								return new ValueTuple<string, DateTimeOffset?, string>(id, (DateTimeOffset?)null, (string)null);
							}
						}));
						awaiter = global::System.Threading.Tasks.Task.WhenAll<ValueTuple<string, DateTimeOffset?, string>>(_003Ctasks_003E5__2).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetFriendPresencesAsync_003Ed__33 _003CGetFriendPresencesAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<ValueTuple<string, DateTimeOffset?, string>[]>, _003CGetFriendPresencesAsync_003Ed__33>(ref awaiter, ref _003CGetFriendPresencesAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<ValueTuple<string, DateTimeOffset?, string>[]>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__4 = awaiter.GetResult();
					_003Cresults_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					_003C_003Es__5 = _003Cresults_003E5__3;
					for (_003C_003Es__6 = 0; _003C_003Es__6 < _003C_003Es__5.Length; _003C_003Es__6++)
					{
						ValueTuple<string, DateTimeOffset?, string> val = _003C_003Es__5[_003C_003Es__6];
						_003Cid_003E5__7 = val.Item1;
						_003Cts_003E5__8 = val.Item2;
						_003Cicon_003E5__9 = val.Item3;
						_003Cresult_003E5__1[_003Cid_003E5__7] = new ValueTuple<DateTimeOffset?, string>(_003Cts_003E5__8, _003Cicon_003E5__9);
						_003Cid_003E5__7 = null;
						_003Cicon_003E5__9 = null;
					}
					_003C_003Es__5 = null;
					_003Ctasks_003E5__2 = null;
					_003Cresults_003E5__3 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__10 = ex;
					Console.WriteLine("GetFriendPresencesAsync error: " + _003Cex_003E5__10.Message);
				}
				result = _003Cresult_003E5__1;
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003Cresult_003E5__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003Cresult_003E5__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetFriendsAsync_003Ed__26 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<Friend>> _003C_003Et__builder;

		public string playerId;

		public PlayerRepository _003C_003E4__this;

		private IQuerySnapshot<FirestoreFriendDTO> _003Csnapshot_003E5__1;

		private IQuerySnapshot<FirestoreFriendDTO> _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<IQuerySnapshot<FirestoreFriendDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<Friend> result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestoreFriendDTO>> awaiter;
					if (num != 0)
					{
						awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection("players").GetDocument(playerId).GetCollection("friends")).GetDocumentsAsync<FirestoreFriendDTO>((Source)0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetFriendsAsync_003Ed__26 _003CGetFriendsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreFriendDTO>>, _003CGetFriendsAsync_003Ed__26>(ref awaiter, ref _003CGetFriendsAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreFriendDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Csnapshot_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					result = ((_003Csnapshot_003E5__1?.Documents != null && Enumerable.Any<IDocumentSnapshot<FirestoreFriendDTO>>(_003Csnapshot_003E5__1.Documents)) ? Enumerable.ToList<Friend>(Enumerable.Select<IDocumentSnapshot<FirestoreFriendDTO>, Friend>(Enumerable.Where<IDocumentSnapshot<FirestoreFriendDTO>>(_003Csnapshot_003E5__1.Documents, (Func<IDocumentSnapshot<FirestoreFriendDTO>, bool>)((IDocumentSnapshot<FirestoreFriendDTO> d) => d.Data != null)), (Func<IDocumentSnapshot<FirestoreFriendDTO>, Friend>)((IDocumentSnapshot<FirestoreFriendDTO> d) => new Friend
					{
						FriendId = d.Data.FriendId,
						FriendName = d.Data.FriendName,
						AddedAt = d.Data.AddedAt
					}))) : new List<Friend>());
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("Error getting friends: " + _003Cex_003E5__3.Message);
					result = new List<Friend>();
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
	private sealed class _003CGetPlayerBattleAsync_003Ed__8 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Player> _003C_003Et__builder;

		public string playerId;

		public int teamSize;

		public PlayerRepository _003C_003E4__this;

		private IDocumentSnapshot<FirestorePublicProfileDTO> _003Csnapshot_003E5__1;

		private FirestorePublicProfileDTO _003Cplayer_003E5__2;

		private IDocumentSnapshot<FirestorePublicProfileDTO> _003C_003Es__3;

		private string _003CpartnerSpiritId_003E5__4;

		private IDocumentSnapshot<FirestorePlayerSpiritDTO> _003CpartnerSpirit_003E5__5;

		private IDocumentSnapshot<FirestorePlayerSpiritDTO> _003C_003Es__6;

		private IQuerySnapshot<FirestorePlayerSpiritDTO> _003CplayerspiritsSubCollection_003E5__7;

		private IQuerySnapshot<FirestorePlayerSpiritDTO> _003C_003Es__8;

		private global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestorePlayerSpiritDTO>> _003C_003Es__9;

		private IDocumentSnapshot<FirestorePlayerSpiritDTO> _003Cspirit_003E5__10;

		private FirestorePlayerSpiritDTO _003CconvertedSpirit_003E5__11;

		private global::System.Exception _003Cex_003E5__12;

		private TaskAwaiter<IDocumentSnapshot<FirestorePublicProfileDTO>> _003C_003Eu__1;

		private TaskAwaiter<IDocumentSnapshot<FirestorePlayerSpiritDTO>> _003C_003Eu__2;

		private TaskAwaiter<IQuerySnapshot<FirestorePlayerSpiritDTO>> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02da: Unknown result type (might be due to invalid IL or missing references)
			//IL_02df: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Player result;
			try
			{
				if ((uint)num > 2u)
				{
				}
				try
				{
					TaskAwaiter<IDocumentSnapshot<FirestorePublicProfileDTO>> awaiter3;
					TaskAwaiter<IDocumentSnapshot<FirestorePlayerSpiritDTO>> awaiter2;
					TaskAwaiter<IQuerySnapshot<FirestorePlayerSpiritDTO>> awaiter;
					switch (num)
					{
					default:
						awaiter3 = _003C_003E4__this._firestore.GetCollection("publicProfiles").GetDocument(playerId).GetDocumentSnapshotAsync<FirestorePublicProfileDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CGetPlayerBattleAsync_003Ed__8 _003CGetPlayerBattleAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestorePublicProfileDTO>>, _003CGetPlayerBattleAsync_003Ed__8>(ref awaiter3, ref _003CGetPlayerBattleAsync_003Ed__);
							return;
						}
						goto IL_00aa;
					case 0:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<FirestorePublicProfileDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_00aa;
					case 1:
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<IDocumentSnapshot<FirestorePlayerSpiritDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_01c2;
					case 2:
						{
							awaiter = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<IQuerySnapshot<FirestorePlayerSpiritDTO>>);
							num = (_003C_003E1__state = -1);
							goto IL_02f6;
						}
						IL_01c2:
						_003C_003Es__6 = awaiter2.GetResult();
						_003CpartnerSpirit_003E5__5 = _003C_003Es__6;
						_003C_003Es__6 = null;
						_003Cplayer_003E5__2.PlayerSpirits.Add(_003CpartnerSpirit_003E5__5.Data);
						_003CpartnerSpiritId_003E5__4 = null;
						_003CpartnerSpirit_003E5__5 = null;
						break;
						IL_00aa:
						_003C_003Es__3 = awaiter3.GetResult();
						_003Csnapshot_003E5__1 = _003C_003Es__3;
						_003C_003Es__3 = null;
						if (_003Csnapshot_003E5__1 != null && _003Csnapshot_003E5__1.Data != null)
						{
							_003Cplayer_003E5__2 = _003Csnapshot_003E5__1.Data;
							if (teamSize == 1)
							{
								_003CpartnerSpiritId_003E5__4 = _003Cplayer_003E5__2.PartnerSpiritId ?? string.Empty;
								awaiter2 = _003C_003E4__this._firestore.GetCollection("players/" + _003Cplayer_003E5__2.PlayerID + "/playerspirits").GetDocument(_003CpartnerSpiritId_003E5__4).GetDocumentSnapshotAsync<FirestorePlayerSpiritDTO>((Source)0)
									.GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter2;
									_003CGetPlayerBattleAsync_003Ed__8 _003CGetPlayerBattleAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestorePlayerSpiritDTO>>, _003CGetPlayerBattleAsync_003Ed__8>(ref awaiter2, ref _003CGetPlayerBattleAsync_003Ed__);
									return;
								}
								goto IL_01c2;
							}
							if (teamSize != 3)
							{
								break;
							}
							awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection("players/" + _003Cplayer_003E5__2.PlayerID + "/playerspirits")).WhereFieldIn("playerspirit-ID", new object[3]
							{
								_003Cplayer_003E5__2.ActiveSquad[0],
								_003Cplayer_003E5__2.ActiveSquad[1],
								_003Cplayer_003E5__2.ActiveSquad[2]
							}).GetDocumentsAsync<FirestorePlayerSpiritDTO>((Source)0).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter;
								_003CGetPlayerBattleAsync_003Ed__8 _003CGetPlayerBattleAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestorePlayerSpiritDTO>>, _003CGetPlayerBattleAsync_003Ed__8>(ref awaiter, ref _003CGetPlayerBattleAsync_003Ed__);
								return;
							}
							goto IL_02f6;
						}
						result = new Player();
						goto end_IL_0011;
						IL_02f6:
						_003C_003Es__8 = awaiter.GetResult();
						_003CplayerspiritsSubCollection_003E5__7 = _003C_003Es__8;
						_003C_003Es__8 = null;
						_003C_003Es__9 = _003CplayerspiritsSubCollection_003E5__7.Documents.GetEnumerator();
						try
						{
							while (((global::System.Collections.IEnumerator)_003C_003Es__9).MoveNext())
							{
								_003Cspirit_003E5__10 = _003C_003Es__9.Current;
								_003CconvertedSpirit_003E5__11 = _003Cspirit_003E5__10.Data;
								_003CconvertedSpirit_003E5__11.PlayerSpiritID = _003Cspirit_003E5__10.Reference.Id;
								_003Cplayer_003E5__2.PlayerSpirits.Add(_003CconvertedSpirit_003E5__11);
								_003CconvertedSpirit_003E5__11 = null;
								_003Cspirit_003E5__10 = null;
							}
						}
						finally
						{
							if (num < 0 && _003C_003Es__9 != null)
							{
								((global::System.IDisposable)_003C_003Es__9).Dispose();
							}
						}
						_003C_003Es__9 = null;
						_003CplayerspiritsSubCollection_003E5__7 = null;
						break;
					}
					result = PlayerEntityMapper.ToEntity(_003Cplayer_003E5__2);
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__12 = ex;
					Console.WriteLine("Error retrieving players: " + _003Cex_003E5__12.Message);
					result = new Player();
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
	private sealed class _003CGetPlayerByIdAsync_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Player> _003C_003Et__builder;

		public string id;

		public PlayerRepository _003C_003E4__this;

		private IDocumentSnapshot<FirestorePlayerDTO> _003CplayerDocument_003E5__1;

		private IDocumentSnapshot<FirestorePlayerDTO> _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<IDocumentSnapshot<FirestorePlayerDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			Player result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IDocumentSnapshot<FirestorePlayerDTO>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._firestore.GetCollection("players").GetDocument(id).GetDocumentSnapshotAsync<FirestorePlayerDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetPlayerByIdAsync_003Ed__4 _003CGetPlayerByIdAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestorePlayerDTO>>, _003CGetPlayerByIdAsync_003Ed__4>(ref awaiter, ref _003CGetPlayerByIdAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<FirestorePlayerDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003CplayerDocument_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					result = ((_003CplayerDocument_003E5__1?.Data != null) ? PlayerEntityMapper.ToEntity(_003CplayerDocument_003E5__1.Data) : null);
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("Error retrieving player by ID: " + _003Cex_003E5__3.Message);
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
	private sealed class _003CGetPlayersBattleAsync_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<Player>> _003C_003Et__builder;

		public int teamSize;

		public int limitTo;

		public string currentPlayerId;

		public int currentPlayerLevel;

		public PlayerRepository _003C_003E4__this;

		private List<FirestorePublicProfileDTO> _003Cplayers_003E5__1;

		private IQuerySnapshot<FirestorePublicProfileDTO> _003CquerySnapshot_003E5__2;

		private IQuerySnapshot<FirestorePublicProfileDTO> _003C_003Es__3;

		private global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestorePublicProfileDTO>> _003C_003Es__4;

		private IDocumentSnapshot<FirestorePublicProfileDTO> _003Cdocument_003E5__5;

		private FirestorePublicProfileDTO _003Cplayer_003E5__6;

		private string _003CpartnerSpiritId_003E5__7;

		private IDocumentSnapshot<FirestorePlayerSpiritDTO> _003CpartnerSpirit_003E5__8;

		private IDocumentSnapshot<FirestorePlayerSpiritDTO> _003C_003Es__9;

		private IQuerySnapshot<FirestorePlayerSpiritDTO> _003CplayerspiritsSubCollection_003E5__10;

		private IQuerySnapshot<FirestorePlayerSpiritDTO> _003C_003Es__11;

		private global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestorePlayerSpiritDTO>> _003C_003Es__12;

		private IDocumentSnapshot<FirestorePlayerSpiritDTO> _003Cspirit_003E5__13;

		private FirestorePlayerSpiritDTO _003CconvertedSpirit_003E5__14;

		private global::System.Exception _003Cex_003E5__15;

		private TaskAwaiter<IQuerySnapshot<FirestorePublicProfileDTO>> _003C_003Eu__1;

		private TaskAwaiter<IDocumentSnapshot<FirestorePlayerSpiritDTO>> _003C_003Eu__2;

		private TaskAwaiter<IQuerySnapshot<FirestorePlayerSpiritDTO>> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0248: Unknown result type (might be due to invalid IL or missing references)
			//IL_024d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0255: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0375: Unknown result type (might be due to invalid IL or missing references)
			//IL_037a: Unknown result type (might be due to invalid IL or missing references)
			//IL_038f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0391: Unknown result type (might be due to invalid IL or missing references)
			//IL_020f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0214: Unknown result type (might be due to invalid IL or missing references)
			//IL_0229: Unknown result type (might be due to invalid IL or missing references)
			//IL_022b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<Player> result;
			try
			{
				if ((uint)num > 2u)
				{
				}
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestorePublicProfileDTO>> awaiter;
					if (num != 0)
					{
						if ((uint)(num - 1) <= 1u)
						{
							goto IL_0132;
						}
						_003Cplayers_003E5__1 = new List<FirestorePublicProfileDTO>();
						awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection("publicProfiles")).WhereGreaterThanOrEqualsTo("playerlevel", (object)Math.Max(1, currentPlayerLevel - 5)).WhereLessThanOrEqualsTo("playerlevel", (object)(currentPlayerLevel + 5)).LimitedTo(limitTo)
							.GetDocumentsAsync<FirestorePublicProfileDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetPlayersBattleAsync_003Ed__7 _003CGetPlayersBattleAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestorePublicProfileDTO>>, _003CGetPlayersBattleAsync_003Ed__7>(ref awaiter, ref _003CGetPlayersBattleAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestorePublicProfileDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter.GetResult();
					_003CquerySnapshot_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (_003CquerySnapshot_003E5__2 != null)
					{
						_003C_003Es__4 = _003CquerySnapshot_003E5__2.Documents.GetEnumerator();
						goto IL_0132;
					}
					result = new List<Player>();
					goto end_IL_0011;
					IL_0132:
					try
					{
						TaskAwaiter<IQuerySnapshot<FirestorePlayerSpiritDTO>> awaiter2;
						if (num != 1)
						{
							if (num != 2)
							{
								goto IL_04c0;
							}
							awaiter2 = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<IQuerySnapshot<FirestorePlayerSpiritDTO>>);
							num = (_003C_003E1__state = -1);
							goto IL_03ca;
						}
						TaskAwaiter<IDocumentSnapshot<FirestorePlayerSpiritDTO>> awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<IDocumentSnapshot<FirestorePlayerSpiritDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_0264;
						IL_01d4:
						awaiter3 = _003C_003E4__this._firestore.GetCollection("players/" + _003Cplayer_003E5__6.PlayerID + "/playerspirits").GetDocument(_003CpartnerSpiritId_003E5__7).GetDocumentSnapshotAsync<FirestorePlayerSpiritDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter3;
							_003CGetPlayersBattleAsync_003Ed__7 _003CGetPlayersBattleAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestorePlayerSpiritDTO>>, _003CGetPlayersBattleAsync_003Ed__7>(ref awaiter3, ref _003CGetPlayersBattleAsync_003Ed__);
							return;
						}
						goto IL_0264;
						IL_02e6:
						if (teamSize == 3)
						{
							awaiter2 = ((IQuery)_003C_003E4__this._firestore.GetCollection("players/" + _003Cplayer_003E5__6.PlayerID + "/playerspirits")).WhereFieldIn("playerspirit-ID", new object[3]
							{
								_003Cplayer_003E5__6.ActiveSquad[0],
								_003Cplayer_003E5__6.ActiveSquad[1],
								_003Cplayer_003E5__6.ActiveSquad[2]
							}).GetDocumentsAsync<FirestorePlayerSpiritDTO>((Source)0).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter2;
								_003CGetPlayersBattleAsync_003Ed__7 _003CGetPlayersBattleAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestorePlayerSpiritDTO>>, _003CGetPlayersBattleAsync_003Ed__7>(ref awaiter2, ref _003CGetPlayersBattleAsync_003Ed__);
								return;
							}
							goto IL_03ca;
						}
						goto IL_049f;
						IL_03ca:
						_003C_003Es__11 = awaiter2.GetResult();
						_003CplayerspiritsSubCollection_003E5__10 = _003C_003Es__11;
						_003C_003Es__11 = null;
						_003C_003Es__12 = _003CplayerspiritsSubCollection_003E5__10.Documents.GetEnumerator();
						try
						{
							while (((global::System.Collections.IEnumerator)_003C_003Es__12).MoveNext())
							{
								_003Cspirit_003E5__13 = _003C_003Es__12.Current;
								_003CconvertedSpirit_003E5__14 = _003Cspirit_003E5__13.Data;
								_003CconvertedSpirit_003E5__14.PlayerSpiritID = _003Cspirit_003E5__13.Reference.Id;
								_003Cplayer_003E5__6.PlayerSpirits.Add(_003CconvertedSpirit_003E5__14);
								_003CconvertedSpirit_003E5__14 = null;
								_003Cspirit_003E5__13 = null;
							}
						}
						finally
						{
							if (num < 0 && _003C_003Es__12 != null)
							{
								((global::System.IDisposable)_003C_003Es__12).Dispose();
							}
						}
						_003C_003Es__12 = null;
						_003CplayerspiritsSubCollection_003E5__10 = null;
						goto IL_049f;
						IL_04c0:
						while (((global::System.Collections.IEnumerator)_003C_003Es__4).MoveNext())
						{
							_003Cdocument_003E5__5 = _003C_003Es__4.Current;
							_003Cplayer_003E5__6 = _003Cdocument_003E5__5.Data;
							if (_003Cplayer_003E5__6.PlayerID == currentPlayerId)
							{
								continue;
							}
							if (teamSize == 1)
							{
								_003CpartnerSpiritId_003E5__7 = _003Cplayer_003E5__6.PartnerSpiritId ?? string.Empty;
								if (string.IsNullOrEmpty(_003CpartnerSpiritId_003E5__7))
								{
									continue;
								}
								goto IL_01d4;
							}
							goto IL_02e6;
						}
						goto end_IL_0132;
						IL_0264:
						_003C_003Es__9 = awaiter3.GetResult();
						_003CpartnerSpirit_003E5__8 = _003C_003Es__9;
						_003C_003Es__9 = null;
						if (string.IsNullOrEmpty(_003CpartnerSpirit_003E5__8.Data.PlayerSpiritID))
						{
							_003CpartnerSpirit_003E5__8.Data.PlayerSpiritID = _003CpartnerSpiritId_003E5__7;
						}
						_003Cplayer_003E5__6.PlayerSpirits.Add(_003CpartnerSpirit_003E5__8.Data);
						_003CpartnerSpiritId_003E5__7 = null;
						_003CpartnerSpirit_003E5__8 = null;
						goto IL_049f;
						IL_049f:
						_003Cplayers_003E5__1.Add(_003Cplayer_003E5__6);
						_003Cplayer_003E5__6 = null;
						_003Cdocument_003E5__5 = null;
						goto IL_04c0;
						end_IL_0132:;
					}
					finally
					{
						if (num < 0 && _003C_003Es__4 != null)
						{
							((global::System.IDisposable)_003C_003Es__4).Dispose();
						}
					}
					_003C_003Es__4 = null;
					result = PlayerEntityMapper.ToEntities((global::System.Collections.Generic.IEnumerable<FirestorePublicProfileDTO>)_003Cplayers_003E5__1);
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__15 = ex;
					Console.WriteLine("Error retrieving players: " + _003Cex_003E5__15.Message);
					result = new List<Player>();
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
	private sealed class _003CGetPlayersByIdsForBattleAsync_003Ed__9 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<Player>> _003C_003Et__builder;

		public List<string> playerIds;

		public int teamSize;

		public PlayerRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass9_0 _003C_003E8__1;

		private global::System.Collections.Generic.IEnumerable<global::System.Threading.Tasks.Task<Player>> _003Ctasks_003E5__2;

		private Player[] _003Cresults_003E5__3;

		private Player[] _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<Player[]> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<Player> result;
			try
			{
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass9_0();
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003C_003E8__1.teamSize = teamSize;
				}
				try
				{
					TaskAwaiter<Player[]> awaiter;
					if (num != 0)
					{
						_003Ctasks_003E5__2 = Enumerable.Select<string, global::System.Threading.Tasks.Task<Player>>((global::System.Collections.Generic.IEnumerable<string>)playerIds, (Func<string, global::System.Threading.Tasks.Task<Player>>)((string id) => _003C_003E8__1._003C_003E4__this.GetPlayerBattleAsync(id, _003C_003E8__1.teamSize)));
						awaiter = global::System.Threading.Tasks.Task.WhenAll<Player>(_003Ctasks_003E5__2).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetPlayersByIdsForBattleAsync_003Ed__9 _003CGetPlayersByIdsForBattleAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Player[]>, _003CGetPlayersByIdsForBattleAsync_003Ed__9>(ref awaiter, ref _003CGetPlayersByIdsForBattleAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Player[]>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__4 = awaiter.GetResult();
					_003Cresults_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					result = Enumerable.ToList<Player>(Enumerable.Where<Player>((global::System.Collections.Generic.IEnumerable<Player>)_003Cresults_003E5__3, (Func<Player, bool>)((Player p) => p != null && !string.IsNullOrEmpty(p.PlayerID))));
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					Console.WriteLine("Error fetching players by IDs: " + _003Cex_003E5__5.Message);
					result = new List<Player>();
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetUserByIdAsync_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string Id;

		public PlayerRepository _003C_003E4__this;

		private IDocumentSnapshot<FirestoreUserDTO> _003Cuser_003E5__1;

		private IDocumentSnapshot<FirestoreUserDTO> _003C_003Es__2;

		private TaskAwaiter<IDocumentSnapshot<FirestoreUserDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				TaskAwaiter<IDocumentSnapshot<FirestoreUserDTO>> awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._firestore.GetCollection("users").GetDocument(Id).GetDocumentSnapshotAsync<FirestoreUserDTO>((Source)0)
						.GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGetUserByIdAsync_003Ed__12 _003CGetUserByIdAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestoreUserDTO>>, _003CGetUserByIdAsync_003Ed__12>(ref awaiter, ref _003CGetUserByIdAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<FirestoreUserDTO>>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__2 = awaiter.GetResult();
				_003Cuser_003E5__1 = _003C_003Es__2;
				_003C_003Es__2 = null;
				result = _003Cuser_003E5__1.Data != null;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cuser_003E5__1 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cuser_003E5__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CLinkUserAsync_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string playerId;

		public string email;

		public PlayerRepository _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						IDocumentReference document = _003C_003E4__this._firestore.GetCollection("users").GetDocument(playerId);
						Dictionary<object, object> obj = new Dictionary<object, object>();
						obj.Add((object)"email", (object)email);
						awaiter = document.UpdateDataAsync(obj).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLinkUserAsync_003Ed__14 _003CLinkUserAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CLinkUserAsync_003Ed__14>(ref awaiter, ref _003CLinkUserAsync_003Ed__);
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
					_003Cex_003E5__1 = ex;
					Console.WriteLine("Could not update email field: " + _003Cex_003E5__1.Message);
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

	[CompilerGenerated]
	private sealed class _003CRemoveFriendAsync_003Ed__28 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string playerId;

		public string friendId;

		public PlayerRepository _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._firestore.GetCollection("players").GetDocument(playerId).GetCollection("friends")
							.GetDocument(friendId)
							.DeleteDocumentAsync()
							.GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CRemoveFriendAsync_003Ed__28 _003CRemoveFriendAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CRemoveFriendAsync_003Ed__28>(ref awaiter, ref _003CRemoveFriendAsync_003Ed__);
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
					_003Cex_003E5__1 = ex;
					Console.WriteLine("Error removing friend: " + _003Cex_003E5__1.Message);
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

	[CompilerGenerated]
	private sealed class _003CRemovePlayerSpirit_003Ed__20 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string playerId;

		public string spiritId;

		public PlayerRepository _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._firestore.GetCollection("players").GetDocument(playerId + "/playerspirits/" + spiritId).DeleteDocumentAsync()
						.GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CRemovePlayerSpirit_003Ed__20 _003CRemovePlayerSpirit_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRemovePlayerSpirit_003Ed__20>(ref awaiter, ref _003CRemovePlayerSpirit_003Ed__);
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
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSaveDailyBattleTasksAsync_003Ed__31 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string playerId;

		public PlayerDailyBattleTasks tasks;

		public PlayerRepository _003C_003E4__this;

		private FirestoreDailyBattleTasksDTO _003Cdto_003E5__1;

		private global::System.Exception _003Cex_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						_003Cdto_003E5__1 = FirestoreDailyBattleTasksDTO.FromEntity(tasks);
						awaiter = _003C_003E4__this._firestore.GetCollection($"{"players"}/{playerId}/{"dailyBattleTasks"}").GetDocument(tasks.DateKey).SetDataAsync((object)_003Cdto_003E5__1, SetOptions.Merge())
							.GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CSaveDailyBattleTasksAsync_003Ed__31 _003CSaveDailyBattleTasksAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CSaveDailyBattleTasksAsync_003Ed__31>(ref awaiter, ref _003CSaveDailyBattleTasksAsync_003Ed__);
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
					Console.WriteLine("SaveDailyBattleTasksAsync error: " + _003Cex_003E5__2.Message);
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

	[CompilerGenerated]
	private sealed class _003CSearchPlayersAsync_003Ed__24 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<Player>> _003C_003Et__builder;

		public string searchText;

		public int limit;

		public PlayerRepository _003C_003E4__this;

		private string _003CsearchLower_003E5__1;

		private IQuerySnapshot<FirestorePublicProfileDTO> _003CquerySnapshot_003E5__2;

		private List<FirestorePublicProfileDTO> _003Cplayers_003E5__3;

		private IQuerySnapshot<FirestorePublicProfileDTO> _003C_003Es__4;

		private global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestorePublicProfileDTO>> _003C_003Es__5;

		private IDocumentSnapshot<FirestorePublicProfileDTO> _003Cdocument_003E5__6;

		private FirestorePublicProfileDTO _003CplayerDTO_003E5__7;

		private global::System.Exception _003Cex_003E5__8;

		private TaskAwaiter<IQuerySnapshot<FirestorePublicProfileDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<Player> result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestorePublicProfileDTO>> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestorePublicProfileDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_00bb;
					}
					if (!string.IsNullOrWhiteSpace(searchText))
					{
						_003CsearchLower_003E5__1 = searchText.ToLower();
						awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection("publicProfiles")).LimitedTo(100).GetDocumentsAsync<FirestorePublicProfileDTO>((Source)0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CSearchPlayersAsync_003Ed__24 _003CSearchPlayersAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestorePublicProfileDTO>>, _003CSearchPlayersAsync_003Ed__24>(ref awaiter, ref _003CSearchPlayersAsync_003Ed__);
							return;
						}
						goto IL_00bb;
					}
					result = new List<Player>();
					goto end_IL_0010;
					IL_00bb:
					_003C_003Es__4 = awaiter.GetResult();
					_003CquerySnapshot_003E5__2 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003CquerySnapshot_003E5__2 == null || !Enumerable.Any<IDocumentSnapshot<FirestorePublicProfileDTO>>(_003CquerySnapshot_003E5__2.Documents))
					{
						result = new List<Player>();
					}
					else
					{
						_003Cplayers_003E5__3 = new List<FirestorePublicProfileDTO>();
						_003C_003Es__5 = _003CquerySnapshot_003E5__2.Documents.GetEnumerator();
						try
						{
							while (((global::System.Collections.IEnumerator)_003C_003Es__5).MoveNext())
							{
								_003Cdocument_003E5__6 = _003C_003Es__5.Current;
								_003CplayerDTO_003E5__7 = _003Cdocument_003E5__6.Data;
								string? playerName = _003CplayerDTO_003E5__7.PlayerName;
								if (playerName != null && playerName.ToLower().Contains(_003CsearchLower_003E5__1))
								{
									_003Cplayers_003E5__3.Add(_003CplayerDTO_003E5__7);
									if (_003Cplayers_003E5__3.Count >= limit)
									{
										break;
									}
									_003CplayerDTO_003E5__7 = null;
									_003Cdocument_003E5__6 = null;
								}
							}
						}
						finally
						{
							if (num < 0 && _003C_003Es__5 != null)
							{
								((global::System.IDisposable)_003C_003Es__5).Dispose();
							}
						}
						_003C_003Es__5 = null;
						result = PlayerEntityMapper.ToEntities((global::System.Collections.Generic.IEnumerable<FirestorePublicProfileDTO>)_003Cplayers_003E5__3);
					}
					end_IL_0010:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__8 = ex;
					Console.WriteLine("Error searching players: " + _003Cex_003E5__8.Message);
					result = new List<Player>();
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
	private sealed class _003CUpdateLeaderboardEntry_003Ed__19 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string playerId;

		public PlayerRepository _003C_003E4__this;

		private Player _003Cplayer_003E5__1;

		private LeaderboardEntry _003CleaderboardEntry_003E5__2;

		private FirestoreLeaderboardEntryDTO _003Cdto_003E5__3;

		private Player _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<Player?> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					TaskAwaiter<Player> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0160;
						}
						awaiter2 = _003C_003E4__this.GetPlayerByIdAsync(playerId).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CUpdateLeaderboardEntry_003Ed__19 _003CUpdateLeaderboardEntry_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Player>, _003CUpdateLeaderboardEntry_003Ed__19>(ref awaiter2, ref _003CUpdateLeaderboardEntry_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Player>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__4 = awaiter2.GetResult();
					_003Cplayer_003E5__1 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003Cplayer_003E5__1 != null)
					{
						_003CleaderboardEntry_003E5__2 = LeaderboardEntry.FromPlayer(_003Cplayer_003E5__1);
						_003Cdto_003E5__3 = LeaderboardMapper.ToFirestoreDTO(_003CleaderboardEntry_003E5__2);
						awaiter = _003C_003E4__this._firestore.GetCollection("leaderboards").GetDocument(playerId).SetDataAsync((object)_003Cdto_003E5__3, SetOptions.Merge())
							.GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003CUpdateLeaderboardEntry_003Ed__19 _003CUpdateLeaderboardEntry_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CUpdateLeaderboardEntry_003Ed__19>(ref awaiter, ref _003CUpdateLeaderboardEntry_003Ed__);
							return;
						}
						goto IL_0160;
					}
					goto end_IL_0011;
					IL_0160:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003Cplayer_003E5__1 = null;
					_003CleaderboardEntry_003E5__2 = null;
					_003Cdto_003E5__3 = null;
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					Console.WriteLine("Error updating leaderboard entry: " + _003Cex_003E5__5.Message);
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CUpdatePlayerSpiritPurchase_003Ed__23 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

		public FirestorePlayerDTO player;

		public FirestorePlayerSpiritDTO playerSpiritAdded;

		public PlayerRepository _003C_003E4__this;

		private string _003CfieldPath_003E5__1;

		private Dictionary<string, FirestoreInventoryDTO> _003CinventoryForFirestore_003E5__2;

		private string _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<string> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			string empty;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter<string> awaiter;
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<string>);
							num = (_003C_003E1__state = -1);
							goto IL_0168;
						}
						_003CfieldPath_003E5__1 = "inventory";
						_003CinventoryForFirestore_003E5__2 = player.Inventory;
						IDocumentReference document = _003C_003E4__this._firestore.GetCollection("players").GetDocument(player.PlayerID);
						Dictionary<object, object> obj = new Dictionary<object, object>();
						obj.Add((object)_003CfieldPath_003E5__1, (object)(_003CinventoryForFirestore_003E5__2 ?? new Dictionary<string, FirestoreInventoryDTO>()));
						awaiter2 = document.UpdateDataAsync(obj).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CUpdatePlayerSpiritPurchase_003Ed__23 _003CUpdatePlayerSpiritPurchase_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CUpdatePlayerSpiritPurchase_003Ed__23>(ref awaiter2, ref _003CUpdatePlayerSpiritPurchase_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter2)).GetResult();
					awaiter = _003C_003E4__this.UpdatePlayerSpirits(player, playerSpiritAdded, playerSpiritAdded.PlayerSpiritID ?? string.Empty).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter;
						_003CUpdatePlayerSpiritPurchase_003Ed__23 _003CUpdatePlayerSpiritPurchase_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, _003CUpdatePlayerSpiritPurchase_003Ed__23>(ref awaiter, ref _003CUpdatePlayerSpiritPurchase_003Ed__);
						return;
					}
					goto IL_0168;
					IL_0168:
					_003C_003Es__3 = awaiter.GetResult();
					empty = _003C_003Es__3;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					Console.WriteLine("Error updating spirit purchase: " + _003Cex_003E5__4.Message);
					empty = string.Empty;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(empty);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CUpdatePlayerSpirits_003Ed__21 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

		public FirestorePlayerDTO player;

		public FirestorePlayerSpiritDTO playerSpirit;

		public string spiritId;

		public PlayerRepository _003C_003E4__this;

		private Dictionary<object, object> _003CfirestoreSpirit_003E5__1;

		private IWriteBatch _003Cbatch_003E5__2;

		private IDocumentReference _003CplayerRef_003E5__3;

		private Dictionary<object, object> _003Cupdates_003E5__4;

		private Enumerator<string, FirestoreMoveStateDTO> _003C_003Es__5;

		private KeyValuePair<string, FirestoreMoveStateDTO> _003Cmove_003E5__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0364: Unknown result type (might be due to invalid IL or missing references)
			//IL_0369: Unknown result type (might be due to invalid IL or missing references)
			//IL_048c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0491: Unknown result type (might be due to invalid IL or missing references)
			//IL_0499: Unknown result type (might be due to invalid IL or missing references)
			//IL_037a: Unknown result type (might be due to invalid IL or missing references)
			//IL_037f: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0429: Unknown result type (might be due to invalid IL or missing references)
			//IL_0452: Unknown result type (might be due to invalid IL or missing references)
			//IL_0457: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_046c: Unknown result type (might be due to invalid IL or missing references)
			//IL_046e: Unknown result type (might be due to invalid IL or missing references)
			//IL_029d: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			string empty;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_04a8;
						}
						Dictionary<object, object> obj4 = new Dictionary<object, object>
						{
							[(object)"playername"] = playerSpirit.PlayerName ?? "",
							[(object)"name"] = playerSpirit.Name ?? "",
							[(object)"nickname"] = playerSpirit.Nickname ?? ""
						};
						object obj5 = "dateOwned";
						DateTimeOffset dateOwned = playerSpirit.DateOwned;
						obj4[obj5] = ((DateTimeOffset)(ref dateOwned)).ToUniversalTime();
						object obj6 = "basespirit-ID";
						obj4[obj6] = playerSpirit.BaseSpiritID;
						object obj7 = "level";
						obj4[obj7] = playerSpirit.Level;
						object obj8 = "points-unallocated";
						obj4[obj8] = playerSpirit.TrainingPoints;
						object obj9 = "HP";
						obj4[obj9] = playerSpirit.HP;
						object obj10 = "pointsATK";
						obj4[obj10] = playerSpirit.PointsATK;
						object obj11 = "pointsDEF";
						obj4[obj11] = playerSpirit.PointsDEF;
						object obj12 = "pointsMGK";
						obj4[obj12] = playerSpirit.PointsSATK;
						object obj13 = "pointsMDF";
						obj4[obj13] = playerSpirit.PointsSDEF;
						object obj14 = "pointsSPD";
						obj4[obj14] = playerSpirit.PointsSPD;
						object obj15 = "pointsINT";
						obj4[obj15] = playerSpirit.PointsINT;
						object obj16 = "isFavorite";
						obj4[obj16] = playerSpirit.IsFavorite;
						object obj17 = "heldItemId";
						obj4[obj17] = playerSpirit.HeldItemID ?? "";
						object obj18 = "moves";
						obj4[obj18] = new Dictionary<object, object>();
						_003CfirestoreSpirit_003E5__1 = obj4;
						awaiter2 = _003C_003E4__this._firestore.GetCollection("players/" + player.PlayerID + "/playerspirits").GetDocument(spiritId).SetDataAsync(_003CfirestoreSpirit_003E5__1, (SetOptions)null)
							.GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CUpdatePlayerSpirits_003Ed__21 _003CUpdatePlayerSpirits_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CUpdatePlayerSpirits_003Ed__21>(ref awaiter2, ref _003CUpdatePlayerSpirits_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter2)).GetResult();
					_003Cbatch_003E5__2 = _003C_003E4__this._firestore.CreateBatch();
					_003CplayerRef_003E5__3 = _003C_003E4__this._firestore.GetCollection("players").GetDocument(player.PlayerID + "/playerspirits/" + spiritId);
					_003Cupdates_003E5__4 = new Dictionary<object, object>();
					_003C_003Es__5 = playerSpirit.Moves.GetEnumerator();
					try
					{
						while (_003C_003Es__5.MoveNext())
						{
							_003Cmove_003E5__6 = _003C_003Es__5.Current;
							_003Cupdates_003E5__4[(object)("moves." + _003Cmove_003E5__6.Key)] = new Dictionary<string, object>
							{
								["is-active"] = _003Cmove_003E5__6.Value.IsActiveMove,
								["is-unlocked"] = _003Cmove_003E5__6.Value.IsUnlocked
							};
							_003Cmove_003E5__6 = default(KeyValuePair<string, FirestoreMoveStateDTO>);
						}
					}
					finally
					{
						if (num < 0)
						{
							((global::System.IDisposable)_003C_003Es__5).Dispose();
						}
					}
					_003C_003Es__5 = default(Enumerator<string, FirestoreMoveStateDTO>);
					_003Cbatch_003E5__2.UpdateData(_003CplayerRef_003E5__3, _003Cupdates_003E5__4);
					awaiter = _003Cbatch_003E5__2.CommitAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter;
						_003CUpdatePlayerSpirits_003Ed__21 _003CUpdatePlayerSpirits_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CUpdatePlayerSpirits_003Ed__21>(ref awaiter, ref _003CUpdatePlayerSpirits_003Ed__);
						return;
					}
					goto IL_04a8;
					IL_04a8:
					((TaskAwaiter)(ref awaiter)).GetResult();
					empty = spiritId;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__7 = ex;
					Console.WriteLine(_003Cex_003E5__7.Message);
					Console.WriteLine(_003Cex_003E5__7.StackTrace);
					empty = string.Empty;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(empty);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CUpdatePresenceAsync_003Ed__32 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string playerId;

		public PlayerRepository _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						IDocumentReference document = _003C_003E4__this._firestore.GetCollection("publicProfiles").GetDocument(playerId);
						Dictionary<object, object> obj = new Dictionary<object, object>();
						obj.Add((object)"lastOnlineAt", (object)DateTimeOffset.UtcNow);
						awaiter = document.UpdateDataAsync(obj).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CUpdatePresenceAsync_003Ed__32 _003CUpdatePresenceAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CUpdatePresenceAsync_003Ed__32>(ref awaiter, ref _003CUpdatePresenceAsync_003Ed__);
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
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__1 = ex;
					Console.WriteLine("UpdatePresenceAsync error: " + _003Cex_003E5__1.Message);
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CUpdateShopPurchase_003Ed__22 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public FirestorePlayerDTO player;

		public ShopType shopType;

		public PlayerRepository _003C_003E4__this;

		private Dictionary<string, FirestoreInventoryDTO> _003CinventoryForFirestore_003E5__1;

		private string _003CfieldPath_003E5__2;

		private string _003CfieldPath_003E5__3;

		private string _003CfieldPathItem_003E5__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0200: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						TaskAwaiter awaiter2;
						if (num != 1)
						{
							_003CinventoryForFirestore_003E5__1 = player.Inventory;
							if (shopType == ShopType.items)
							{
								_003CfieldPath_003E5__2 = "inventory";
								IDocumentReference document = _003C_003E4__this._firestore.GetCollection("players").GetDocument(player.PlayerID);
								Dictionary<object, object> obj = new Dictionary<object, object>();
								obj.Add((object)_003CfieldPath_003E5__2, (object)_003CinventoryForFirestore_003E5__1);
								awaiter = document.UpdateDataAsync(obj).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter;
									_003CUpdateShopPurchase_003Ed__22 _003CUpdateShopPurchase_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CUpdateShopPurchase_003Ed__22>(ref awaiter, ref _003CUpdateShopPurchase_003Ed__);
									return;
								}
								goto IL_00e9;
							}
							_003CfieldPath_003E5__3 = $"playercurrencies.{shopType}";
							_003CfieldPathItem_003E5__4 = "inventory";
							IDocumentReference document2 = _003C_003E4__this._firestore.GetCollection("players").GetDocument(player.PlayerID);
							Dictionary<object, object> obj2 = new Dictionary<object, object>();
							obj2.Add((object)_003CfieldPath_003E5__3, (object)(player.Currencies?[((object)shopType).ToString()] ?? 0));
							obj2.Add((object)_003CfieldPathItem_003E5__4, (object)_003CinventoryForFirestore_003E5__1);
							awaiter2 = document2.UpdateDataAsync(obj2).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter2;
								_003CUpdateShopPurchase_003Ed__22 _003CUpdateShopPurchase_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CUpdateShopPurchase_003Ed__22>(ref awaiter2, ref _003CUpdateShopPurchase_003Ed__);
								return;
							}
						}
						else
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
						}
						((TaskAwaiter)(ref awaiter2)).GetResult();
						_003CfieldPath_003E5__3 = null;
						_003CfieldPathItem_003E5__4 = null;
						goto IL_0226;
					}
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00e9;
					IL_0226:
					result = true;
					goto end_IL_0011;
					IL_00e9:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003CfieldPath_003E5__2 = null;
					goto IL_0226;
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					Console.WriteLine("Error updating nickname: " + _003Cex_003E5__5.Message);
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

	private const string CollectionName = "players";

	private const string PublicProfileCollection = "publicProfiles";

	private const string FriendsSubcollection = "friends";

	private const string DailyBattleTasksCollection = "dailyBattleTasks";

	public PlayerRepository(IFirebaseFirestore firestore)
	{
		_firestore = firestore;
	}

	[AsyncStateMachine(typeof(_003CGetPlayerByIdAsync_003Ed__4))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Player?> GetPlayerByIdAsync(string id)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentSnapshot<FirestorePlayerDTO> playerDocument = await _firestore.GetCollection("players").GetDocument(id).GetDocumentSnapshotAsync<FirestorePlayerDTO>((Source)0);
			if (playerDocument?.Data == null)
			{
				return null;
			}
			return PlayerEntityMapper.ToEntity(playerDocument.Data);
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error retrieving player by ID: " + ex.Message);
			return null;
		}
	}

	[AsyncStateMachine(typeof(_003CCreatePlayerAsync_003Ed__5))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> CreatePlayerAsync(Player player)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ArgumentNullException.ThrowIfNull((object)player, "player");
			if (string.IsNullOrEmpty(player.PlayerID))
			{
				throw new ArgumentException("PlayerID is required", "player");
			}
			if (string.IsNullOrEmpty(player.Playername))
			{
				throw new ArgumentException("Playername is required", "player");
			}
			if (player.PlayerSpirits == null || ((global::System.Collections.Generic.IReadOnlyCollection<KeyValuePair<string, PlayerSpirit>>)player.PlayerSpirits).Count == 0)
			{
				throw new ArgumentException("Player must have at least one PlayerSpirit", "player");
			}
			if (player.PlayerQuests == null || !player.PlayerQuests.ContainsKey("story") || !player.PlayerQuests.ContainsKey("challenge"))
			{
				throw new ArgumentException("Player must have 'story' and 'challenge' quests", "player");
			}
			IWriteBatch batch = _firestore.CreateBatch();
			FirestorePlayerDTO newPlayerDTO = new FirestorePlayerDTO
			{
				PlayerID = player.PlayerID,
				Playername = player.Playername,
				PlayerPassword = player.PlayerPassword,
				EXP = player.EXP,
				MaxEXP = player.MaxEXP,
				EP = player.EP,
				MaxEP = player.MaxEP,
				SP = player.SP,
				MaxSP = player.MaxSP,
				PartnerSpiritId = player.PartnerSpiritId,
				PlayerLevel = player.PlayerLevel,
				LastEpRegenTime = player.LastEpRegenTime,
				LastSpRegenTime = player.LastSpRegenTime,
				Inventory = Enumerable.ToDictionary<KeyValuePair<string, Inventory>, string, FirestoreInventoryDTO>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, Inventory>>)player.Inventory, (Func<KeyValuePair<string, Inventory>, string>)((KeyValuePair<string, Inventory> kvp) => kvp.Key), (Func<KeyValuePair<string, Inventory>, FirestoreInventoryDTO>)((KeyValuePair<string, Inventory> kvp) => new FirestoreInventoryDTO
				{
					Name = kvp.Value.Name,
					Amount = kvp.Value.Amount
				})),
				Currencies = Enumerable.ToDictionary<KeyValuePair<string, long>, string, long>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, long>>)player.Currencies, (Func<KeyValuePair<string, long>, string>)((KeyValuePair<string, long> kvp) => kvp.Key), (Func<KeyValuePair<string, long>, long>)((KeyValuePair<string, long> kvp) => kvp.Value)),
				ActiveSquadSlot = player.ActiveSquadSlot,
				Squads = Enumerable.ToDictionary<KeyValuePair<string, List<string>>, string, List<string>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, List<string>>>)player.Squads, (Func<KeyValuePair<string, List<string>>, string>)((KeyValuePair<string, List<string>> kvp) => kvp.Key), (Func<KeyValuePair<string, List<string>>, List<string>>)((KeyValuePair<string, List<string>> kvp) => kvp.Value)),
				BattleStats = new FirestoreBattleStatsDTO
				{
					Wins = player.BattleStats.Wins,
					Losses = player.BattleStats.Losses,
					Score = player.BattleStats.Score,
					Title = player.BattleStats.Title,
					LastScoreUpdate = player.BattleStats.LastScoreUpdate
				},
				GuildId = player.GuildId,
				GuildJoinedAt = player.GuildJoinedAt,
				GuildRole = ((object)player.GuildRole).ToString(),
				ViewedShopItems = Enumerable.ToList<string>((global::System.Collections.Generic.IEnumerable<string>)player.ViewedShopItems),
				LastShopViewedLevel = player.LastShopViewedLevel
			};
			IDocumentReference playerRef = _firestore.GetCollection("players").GetDocument(player.PlayerID);
			batch.SetData(playerRef, (object)newPlayerDTO, (SetOptions)null);
			global::System.Collections.Generic.IEnumerable<PlayerSpirit> playerSpirits = player.PlayerSpirits.Values;
			global::System.Collections.Generic.IEnumerator<PlayerSpirit> enumerator = playerSpirits.GetEnumerator();
			try
			{
				while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
				{
					PlayerSpirit playerSpirit = enumerator.Current;
					FirestorePlayerSpiritDTO obj = new FirestorePlayerSpiritDTO
					{
						PlayerSpiritID = playerSpirit.PlayerSpiritID,
						PlayerName = playerSpirit.PlayerName,
						Name = playerSpirit.Name,
						Nickname = playerSpirit.Nickname,
						DateOwned = playerSpirit.DateOwned,
						BaseSpiritID = playerSpirit.BaseSpiritID,
						Level = playerSpirit.Level,
						HP = playerSpirit.HP,
						TrainingPoints = playerSpirit.TrainingPoints,
						PointsATK = playerSpirit.PointsATK,
						PointsDEF = playerSpirit.PointsDEF,
						PointsSATK = playerSpirit.PointsSATK,
						PointsSDEF = playerSpirit.PointsSDEF,
						PointsSPD = playerSpirit.PointsSPD,
						PointsINT = playerSpirit.PointsINT,
						IsFavorite = playerSpirit.IsFavorite,
						HeldItemID = playerSpirit.HeldItemID,
						GearID = playerSpirit.GearID,
						TalentID = playerSpirit.TalentID
					};
					IReadOnlyDictionary<string, MoveState>? moves = playerSpirit.Moves;
					obj.Moves = ((moves != null) ? Enumerable.ToDictionary<KeyValuePair<string, MoveState>, string, FirestoreMoveStateDTO>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, MoveState>>)moves, (Func<KeyValuePair<string, MoveState>, string>)((KeyValuePair<string, MoveState> kv) => kv.Key), (Func<KeyValuePair<string, MoveState>, FirestoreMoveStateDTO>)((KeyValuePair<string, MoveState> kv) => new FirestoreMoveStateDTO
					{
						IsActiveMove = kv.Value.IsActiveMove,
						IsUnlocked = kv.Value.IsUnlocked
					})) : null);
					FirestorePlayerSpiritDTO playerSpiritDTO = obj;
					IDocumentReference playerSpiritRef = _firestore.GetCollection("players/" + player.PlayerID + "/playerspirits").GetDocument(playerSpiritDTO.PlayerSpiritID);
					batch.SetData(playerSpiritRef, (object)playerSpiritDTO, (SetOptions)null);
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator)?.Dispose();
			}
			Dictionary<string, FirestorePlayerQuestsDTO> playerQuests = Enumerable.ToDictionary<KeyValuePair<string, PlayerQuest>, string, FirestorePlayerQuestsDTO>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, PlayerQuest>>)player.PlayerQuests, (Func<KeyValuePair<string, PlayerQuest>, string>)((KeyValuePair<string, PlayerQuest> kvp) => kvp.Key), (Func<KeyValuePair<string, PlayerQuest>, FirestorePlayerQuestsDTO>)((KeyValuePair<string, PlayerQuest> kvp) => new FirestorePlayerQuestsDTO
			{
				QuestId = kvp.Value.QuestId,
				Tasks = Enumerable.ToDictionary<KeyValuePair<string, TaskProgress>, string, FirestoreTaskProgressDTO>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, TaskProgress>>)kvp.Value.Tasks, (Func<KeyValuePair<string, TaskProgress>, string>)((KeyValuePair<string, TaskProgress> taskKvp) => taskKvp.Key), (Func<KeyValuePair<string, TaskProgress>, FirestoreTaskProgressDTO>)((KeyValuePair<string, TaskProgress> taskKvp) => new FirestoreTaskProgressDTO
				{
					IsCompleted = taskKvp.Value.IsCompleted,
					Step = taskKvp.Value.Step
				}))
			}));
			IDocumentReference storyQuestRef = playerRef.GetCollection("quests").GetDocument("story");
			IDocumentReference challengeQuestRef = playerRef.GetCollection("quests").GetDocument("challenge");
			batch.SetData(storyQuestRef, (object)playerQuests["story"], (SetOptions)null);
			batch.SetData(challengeQuestRef, (object)playerQuests["challenge"], (SetOptions)null);
			if (player.IsAccountLinked)
			{
				FirestorePublicProfileDTO firestorePublicProfileDTO = new FirestorePublicProfileDTO();
				firestorePublicProfileDTO.PlayerName = player.Playername;
				firestorePublicProfileDTO.PlayerLevel = player.PlayerLevel;
				firestorePublicProfileDTO.BattleStats = new FirestoreBattleStatsDTO
				{
					Wins = player.BattleStats.Wins,
					Losses = player.BattleStats.Losses,
					Score = player.BattleStats.Score,
					Title = player.BattleStats.Title,
					LastScoreUpdate = player.BattleStats.LastScoreUpdate
				};
				firestorePublicProfileDTO.ActiveSquad.Add("");
				firestorePublicProfileDTO.ActiveSquad.Add("");
				firestorePublicProfileDTO.ActiveSquad.Add("");
				firestorePublicProfileDTO.PartnerSpiritId = player.PartnerSpiritId;
				firestorePublicProfileDTO.GuildId = player.GuildId;
				FirestorePublicProfileDTO publicProfileDTO = firestorePublicProfileDTO;
				IDocumentReference publicProfileRef = _firestore.GetCollection("publicProfiles").GetDocument(player.PlayerID);
				batch.SetData(publicProfileRef, (object)publicProfileDTO, (SetOptions)null);
			}
			await batch.CommitAsync();
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error creating player: " + ex.Message);
			Console.WriteLine("StackTrace: " + ex.StackTrace);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CCreatePublicProfile_003Ed__6))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> CreatePublicProfile(Player player)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			FirestorePublicProfileDTO publicProfileDTO = new FirestorePublicProfileDTO
			{
				PlayerName = player.Playername,
				PlayerLevel = player.PlayerLevel,
				BattleStats = new FirestoreBattleStatsDTO
				{
					Wins = player.BattleStats.Wins,
					Losses = player.BattleStats.Losses,
					Score = player.BattleStats.Score,
					Title = player.BattleStats.Title,
					LastScoreUpdate = player.BattleStats.LastScoreUpdate
				},
				ActiveSquad = Enumerable.ToList<string>((global::System.Collections.Generic.IEnumerable<string>)player.Squads[player.ActiveSquadSlot.ToString()]),
				PartnerSpiritId = player.PartnerSpiritId,
				GuildId = player.GuildId
			};
			IDocumentReference publicProfileRef = _firestore.GetCollection("publicProfiles").GetDocument(player.PlayerID);
			await _firestore.GetCollection("publicProfiles").GetDocument(publicProfileRef.Id).SetDataAsync((object)publicProfileDTO, (SetOptions)null);
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Creating public profile failed: " + ex.Message);
			Console.WriteLine("Stacktrace " + ex.StackTrace);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CGetPlayersBattleAsync_003Ed__7))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<Player>?> GetPlayersBattleAsync(int teamSize, int limitTo, string currentPlayerId, int currentPlayerLevel)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			List<FirestorePublicProfileDTO> players = new List<FirestorePublicProfileDTO>();
			IQuerySnapshot<FirestorePublicProfileDTO> querySnapshot = await ((IQuery)_firestore.GetCollection("publicProfiles")).WhereGreaterThanOrEqualsTo("playerlevel", (object)Math.Max(1, currentPlayerLevel - 5)).WhereLessThanOrEqualsTo("playerlevel", (object)(currentPlayerLevel + 5)).LimitedTo(limitTo)
				.GetDocumentsAsync<FirestorePublicProfileDTO>((Source)0);
			if (querySnapshot == null)
			{
				return new List<Player>();
			}
			global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestorePublicProfileDTO>> enumerator = querySnapshot.Documents.GetEnumerator();
			try
			{
				while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
				{
					IDocumentSnapshot<FirestorePublicProfileDTO> document = enumerator.Current;
					FirestorePublicProfileDTO player = document.Data;
					if (player.PlayerID == currentPlayerId)
					{
						continue;
					}
					switch (teamSize)
					{
					case 1:
					{
						string partnerSpiritId = player.PartnerSpiritId ?? string.Empty;
						if (string.IsNullOrEmpty(partnerSpiritId))
						{
							continue;
						}
						IDocumentSnapshot<FirestorePlayerSpiritDTO> partnerSpirit = await _firestore.GetCollection("players/" + player.PlayerID + "/playerspirits").GetDocument(partnerSpiritId).GetDocumentSnapshotAsync<FirestorePlayerSpiritDTO>((Source)0);
						if (string.IsNullOrEmpty(partnerSpirit.Data.PlayerSpiritID))
						{
							partnerSpirit.Data.PlayerSpiritID = partnerSpiritId;
						}
						player.PlayerSpirits.Add(partnerSpirit.Data);
						break;
					}
					case 3:
					{
						global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestorePlayerSpiritDTO>> enumerator2 = (await ((IQuery)_firestore.GetCollection("players/" + player.PlayerID + "/playerspirits")).WhereFieldIn("playerspirit-ID", new object[3]
						{
							player.ActiveSquad[0],
							player.ActiveSquad[1],
							player.ActiveSquad[2]
						}).GetDocumentsAsync<FirestorePlayerSpiritDTO>((Source)0)).Documents.GetEnumerator();
						try
						{
							while (((global::System.Collections.IEnumerator)enumerator2).MoveNext())
							{
								IDocumentSnapshot<FirestorePlayerSpiritDTO> spirit = enumerator2.Current;
								FirestorePlayerSpiritDTO convertedSpirit = spirit.Data;
								convertedSpirit.PlayerSpiritID = spirit.Reference.Id;
								player.PlayerSpirits.Add(convertedSpirit);
							}
						}
						finally
						{
							((global::System.IDisposable)enumerator2)?.Dispose();
						}
						break;
					}
					}
					players.Add(player);
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator)?.Dispose();
			}
			return PlayerEntityMapper.ToEntities((global::System.Collections.Generic.IEnumerable<FirestorePublicProfileDTO>)players);
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error retrieving players: " + ex.Message);
			return new List<Player>();
		}
	}

	[AsyncStateMachine(typeof(_003CGetPlayerBattleAsync_003Ed__8))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Player>? GetPlayerBattleAsync(string playerId, int teamSize = 1)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentSnapshot<FirestorePublicProfileDTO> snapshot = await _firestore.GetCollection("publicProfiles").GetDocument(playerId).GetDocumentSnapshotAsync<FirestorePublicProfileDTO>((Source)0);
			if (snapshot == null || snapshot.Data == null)
			{
				return new Player();
			}
			FirestorePublicProfileDTO player = snapshot.Data;
			switch (teamSize)
			{
			case 1:
			{
				string partnerSpiritId = player.PartnerSpiritId ?? string.Empty;
				IDocumentSnapshot<FirestorePlayerSpiritDTO> partnerSpirit = await _firestore.GetCollection("players/" + player.PlayerID + "/playerspirits").GetDocument(partnerSpiritId).GetDocumentSnapshotAsync<FirestorePlayerSpiritDTO>((Source)0);
				player.PlayerSpirits.Add(partnerSpirit.Data);
				break;
			}
			case 3:
			{
				global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestorePlayerSpiritDTO>> enumerator = (await ((IQuery)_firestore.GetCollection("players/" + player.PlayerID + "/playerspirits")).WhereFieldIn("playerspirit-ID", new object[3]
				{
					player.ActiveSquad[0],
					player.ActiveSquad[1],
					player.ActiveSquad[2]
				}).GetDocumentsAsync<FirestorePlayerSpiritDTO>((Source)0)).Documents.GetEnumerator();
				try
				{
					while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
					{
						IDocumentSnapshot<FirestorePlayerSpiritDTO> spirit = enumerator.Current;
						FirestorePlayerSpiritDTO convertedSpirit = spirit.Data;
						convertedSpirit.PlayerSpiritID = spirit.Reference.Id;
						player.PlayerSpirits.Add(convertedSpirit);
					}
				}
				finally
				{
					((global::System.IDisposable)enumerator)?.Dispose();
				}
				break;
			}
			}
			return PlayerEntityMapper.ToEntity(player);
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error retrieving players: " + ex.Message);
			return new Player();
		}
	}

	[AsyncStateMachine(typeof(_003CGetPlayersByIdsForBattleAsync_003Ed__9))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<Player>> GetPlayersByIdsForBattleAsync(List<string> playerIds, int teamSize)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			global::System.Collections.Generic.IEnumerable<global::System.Threading.Tasks.Task<Player>> tasks = Enumerable.Select<string, global::System.Threading.Tasks.Task<Player>>((global::System.Collections.Generic.IEnumerable<string>)playerIds, (Func<string, global::System.Threading.Tasks.Task<Player>>)((string id) => GetPlayerBattleAsync(id, teamSize)));
			return Enumerable.ToList<Player>(Enumerable.Where<Player>((global::System.Collections.Generic.IEnumerable<Player>)(await global::System.Threading.Tasks.Task.WhenAll<Player>(tasks)), (Func<Player, bool>)((Player p) => p != null && !string.IsNullOrEmpty(p.PlayerID))));
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error fetching players by IDs: " + ex.Message);
			return new List<Player>();
		}
	}

	[AsyncStateMachine(typeof(_003CAuthenticateAsync_003Ed__10))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Player?> AuthenticateAsync(string username, string password, string id)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentSnapshot<FirestorePlayerDTO> playerDocument = null;
			IQuerySnapshot<FirestorePlayerDTO> playerQuery = null;
			if (string.IsNullOrEmpty(id))
			{
				playerQuery = await ((IQuery)_firestore.GetCollection("players")).WhereEqualsTo("playername", (object)username).WhereEqualsTo("playerpassword", (object)password).GetDocumentsAsync<FirestorePlayerDTO>((Source)0);
			}
			else
			{
				playerDocument = await _firestore.GetCollection("players").GetDocument(id).GetDocumentSnapshotAsync<FirestorePlayerDTO>((Source)0);
			}
			IDocumentSnapshot<FirestorePlayerDTO> document = (IDocumentSnapshot<FirestorePlayerDTO>)((playerDocument != null) ? ((object)playerDocument) : ((object)Enumerable.First<IDocumentSnapshot<FirestorePlayerDTO>>(playerQuery.Documents)));
			FirestorePlayerDTO player = document.Data;
			global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestorePlayerSpiritDTO>> enumerator = (await ((IQuery)_firestore.GetCollection("players/" + player.PlayerID + "/playerspirits")).GetDocumentsAsync<FirestorePlayerSpiritDTO>((Source)0)).Documents.GetEnumerator();
			try
			{
				while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
				{
					IDocumentSnapshot<FirestorePlayerSpiritDTO> spirit = enumerator.Current;
					FirestorePlayerSpiritDTO convertedSpirit = spirit.Data;
					convertedSpirit.PlayerSpiritID = spirit.Reference.Id;
					player.PlayerSpirits.Add(convertedSpirit);
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator)?.Dispose();
			}
			player.PlayerQuests = Enumerable.ToDictionary<IDocumentSnapshot<FirestorePlayerQuestsDTO>, string, FirestorePlayerQuestsDTO>((await ((IQuery)_firestore.GetCollection("players/" + player.PlayerID + "/quests")).GetDocumentsAsync<FirestorePlayerQuestsDTO>((Source)0)).Documents, (Func<IDocumentSnapshot<FirestorePlayerQuestsDTO>, string>)((IDocumentSnapshot<FirestorePlayerQuestsDTO> s) => s.Reference.Id), (Func<IDocumentSnapshot<FirestorePlayerQuestsDTO>, FirestorePlayerQuestsDTO>)((IDocumentSnapshot<FirestorePlayerQuestsDTO> s) => s.Data));
			return PlayerEntityMapper.ToEntity(player);
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error auth" + ex.Message);
			Console.WriteLine("Stacktrace", (object)(ex.StackTrace ?? string.Empty));
			return null;
		}
	}

	[AsyncStateMachine(typeof(_003CGetEmailByUserAsync_003Ed__11))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<string> GetEmailByUserAsync(string username)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			return Enumerable.First<IDocumentSnapshot<FirestoreUserDTO>>((await ((IQuery)_firestore.GetCollection("users")).WhereEqualsTo("username", (object)username).GetDocumentsAsync<FirestoreUserDTO>((Source)0)).Documents).Data.Email;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine(ex.Message);
			Console.WriteLine(ex.StackTrace);
			return string.Empty;
		}
	}

	[AsyncStateMachine(typeof(_003CGetUserByIdAsync_003Ed__12))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> GetUserByIdAsync(string Id)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return (await _firestore.GetCollection("users").GetDocument(Id).GetDocumentSnapshotAsync<FirestoreUserDTO>((Source)0)).Data != null;
	}

	[AsyncStateMachine(typeof(_003CCreateUserAsync_003Ed__13))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task CreateUserAsync(FirestoreUserDTO user)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CCreateUserAsync_003Ed__13 _003CCreateUserAsync_003Ed__ = new _003CCreateUserAsync_003Ed__13();
		_003CCreateUserAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CCreateUserAsync_003Ed__._003C_003E4__this = this;
		_003CCreateUserAsync_003Ed__.user = user;
		_003CCreateUserAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CCreateUserAsync_003Ed__._003C_003Et__builder)).Start<_003CCreateUserAsync_003Ed__13>(ref _003CCreateUserAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CCreateUserAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLinkUserAsync_003Ed__14))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> LinkUserAsync(string playerId, string email)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentReference document = _firestore.GetCollection("users").GetDocument(playerId);
			Dictionary<object, object> obj = new Dictionary<object, object>();
			obj.Add((object)"email", (object)email);
			await document.UpdateDataAsync(obj);
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Could not update email field: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CDeleteUserAsync_003Ed__15))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task DeleteUserAsync(FirestoreUserDTO user)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CDeleteUserAsync_003Ed__15 _003CDeleteUserAsync_003Ed__ = new _003CDeleteUserAsync_003Ed__15();
		_003CDeleteUserAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CDeleteUserAsync_003Ed__._003C_003E4__this = this;
		_003CDeleteUserAsync_003Ed__.user = user;
		_003CDeleteUserAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CDeleteUserAsync_003Ed__._003C_003Et__builder)).Start<_003CDeleteUserAsync_003Ed__15>(ref _003CDeleteUserAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CDeleteUserAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CCheckUsernameExistsAsync_003Ed__16))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> CheckUsernameExistsAsync(string username)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			return (await ((IQuery)_firestore.GetCollection("users")).WhereEqualsTo("username", (object)username).LimitedTo(1).GetDocumentsAsync<FirestoreUserDTO>((Source)0)).Count > 0;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error checking username: " + ex.Message);
			return true;
		}
	}

	[AsyncStateMachine(typeof(_003CDeletePlayerAsync_003Ed__17))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> DeletePlayerAsync(string playerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			await _firestore.GetCollection("players").GetDocument(playerId).DeleteDocumentAsync();
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error deleting player: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CBatchUpdatePlayerAsync_003Ed__18))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<BatchUpdateOutcome> BatchUpdatePlayerAsync(PlayerBatchUpdate batchUpdate)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IWriteBatch batch = _firestore.CreateBatch();
			IDocumentReference playerRef = _firestore.GetCollection("players").GetDocument(batchUpdate.PlayerId);
			Dictionary<object, object> updates = new Dictionary<object, object>();
			if (batchUpdate.NewEP.HasValue)
			{
				updates[(object)"playerep"] = batchUpdate.NewEP.Value;
				if (batchUpdate.LastEpRegenTime.HasValue)
				{
					updates[(object)"lastEpRegenTime"] = batchUpdate.LastEpRegenTime.Value;
				}
			}
			else if (batchUpdate.EnergyChange != 0)
			{
				updates[(object)"playerep"] = FieldValue.IntegerIncrement((long)batchUpdate.EnergyChange);
				if (batchUpdate.LastEpRegenTime.HasValue)
				{
					updates[(object)"lastEpRegenTime"] = batchUpdate.LastEpRegenTime.Value;
				}
			}
			if (batchUpdate.SPChange != 0)
			{
				updates[(object)"playersp"] = FieldValue.IntegerIncrement((long)batchUpdate.SPChange);
				if (batchUpdate.LastSpRegenTime.HasValue)
				{
					updates[(object)"lastSpRegenTime"] = batchUpdate.LastSpRegenTime.Value;
				}
			}
			if (batchUpdate.ExperienceGain > 0)
			{
				updates[(object)"playerexp"] = (batchUpdate.UpdateLevel ? ((object)batchUpdate.NewEXP) : FieldValue.IntegerIncrement((long)batchUpdate.ExperienceGain));
				if (batchUpdate.UpdateLevel)
				{
					updates[(object)"playermaxexp"] = batchUpdate.NewMaxEXP;
					updates[(object)"playerlevel"] = batchUpdate.NewPlayerLevel;
					updates[(object)"playermaxep"] = batchUpdate.NewMaxEP;
					updates[(object)"playermaxsp"] = batchUpdate.NewMaxSP;
					updates[(object)"playerep"] = batchUpdate.NewMaxEP;
					updates[(object)"playersp"] = batchUpdate.NewMaxSP;
				}
			}
			Enumerator<string, long> enumerator = batchUpdate.CurrencyChanges.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, long> currency = enumerator.Current;
					if (currency.Value != 0)
					{
						updates[(object)("playercurrencies." + currency.Key)] = FieldValue.IntegerIncrement(currency.Value);
					}
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator).Dispose();
			}
			if (batchUpdate.InventoryItemChanges.Count != 0)
			{
				Enumerator<string, int> enumerator2 = batchUpdate.InventoryItemChanges.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						KeyValuePair<string, int> change = enumerator2.Current;
						if (change.Value != 0 && !batchUpdate.InventoryKeysToDelete.Contains(change.Key))
						{
							updates[(object)("inventory." + change.Key + ".amount")] = FieldValue.IntegerIncrement((long)change.Value);
							updates[(object)("inventory." + change.Key + ".name")] = change.Key;
						}
					}
				}
				finally
				{
					((global::System.IDisposable)enumerator2).Dispose();
				}
			}
			Enumerator<string> enumerator3 = batchUpdate.InventoryKeysToDelete.GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					string key = enumerator3.Current;
					updates[(object)("inventory." + key)] = FieldValue.Delete();
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator3).Dispose();
			}
			if (batchUpdate.UpdateActiveSquadSlot && batchUpdate.NewActiveSquadSlot.HasValue)
			{
				updates[(object)"activeSquadSlot"] = batchUpdate.NewActiveSquadSlot.Value;
			}
			if (batchUpdate.WinsChange != 0)
			{
				updates[(object)"battleStats.wins"] = FieldValue.IntegerIncrement((long)batchUpdate.WinsChange);
			}
			if (batchUpdate.LossChange != 0)
			{
				updates[(object)"battleStats.losses"] = FieldValue.IntegerIncrement((long)batchUpdate.LossChange);
			}
			if (batchUpdate.ScoreChange != 0)
			{
				updates[(object)"battleStats.score"] = FieldValue.IntegerIncrement((long)batchUpdate.ScoreChange);
				updates[(object)"battleStats.lastScoreUpdate"] = DateTimeOffset.UtcNow;
			}
			if (!string.IsNullOrEmpty(batchUpdate.NewTitle))
			{
				updates[(object)"battleStats.title"] = batchUpdate.NewTitle;
			}
			if (batchUpdate.SquadUpdates.Count != 0)
			{
				Enumerator<string, List<string>> enumerator4 = batchUpdate.SquadUpdates.GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						KeyValuePair<string, List<string>> squadUpdate = enumerator4.Current;
						updates[(object)("squads." + squadUpdate.Key)] = squadUpdate.Value;
					}
				}
				finally
				{
					((global::System.IDisposable)enumerator4).Dispose();
				}
			}
			if (batchUpdate.UpdateBattleUnit && !string.IsNullOrEmpty(batchUpdate.ActiveBattleUnitId))
			{
				updates[(object)"partnerSpiritID"] = batchUpdate.ActiveBattleUnitId;
			}
			if (!string.IsNullOrEmpty(batchUpdate.NewPlayerIcon))
			{
				updates[(object)"playerIcon"] = batchUpdate.NewPlayerIcon;
			}
			if (!string.IsNullOrEmpty(batchUpdate.NewPlayerIcon) && !string.IsNullOrEmpty(batchUpdate.CurrentGuildId))
			{
				IDocumentReference iconGuildMemberRef = _firestore.GetCollection("guilds").GetDocument(batchUpdate.CurrentGuildId).GetCollection("members")
					.GetDocument(batchUpdate.PlayerId);
				batch.UpdateData(iconGuildMemberRef, new Dictionary<object, object> { [(object)"playerIcon"] = batchUpdate.NewPlayerIcon });
			}
			if (!string.IsNullOrEmpty(batchUpdate.GuildUpdates.TargetPlayerId))
			{
				if (batchUpdate.GuildUpdates.HasUpdates())
				{
					updates[(object)"guildId"] = batchUpdate.GuildUpdates.GuildId;
					if (batchUpdate.GuildUpdates.GuildRole != null)
					{
						updates[(object)"guildRole"] = batchUpdate.GuildUpdates.GuildRole;
					}
					if (batchUpdate.GuildUpdates.GuildJoinedAt.HasValue)
					{
						updates[(object)"guildJoinedAt"] = batchUpdate.GuildUpdates.GuildJoinedAt;
					}
				}
				if (!string.IsNullOrEmpty(batchUpdate.GuildUpdates.GuildId))
				{
					Dictionary<object, object> guildMemberUpdates = new Dictionary<object, object> { [(object)"level"] = FieldValue.IntegerIncrement(1L) };
					long reputationChange = default(long);
					if (batchUpdate.UpdateReputation && batchUpdate.CurrencyChanges.TryGetValue("reputation", ref reputationChange))
					{
						guildMemberUpdates[(object)"trophies"] = FieldValue.IntegerIncrement(reputationChange);
					}
					IDocumentReference guildMemberRef = _firestore.GetCollection("guilds").GetDocument(batchUpdate.GuildUpdates.GuildId).GetCollection("members")
						.GetDocument(batchUpdate.PlayerId);
					batch.UpdateData(guildMemberRef, guildMemberUpdates);
				}
			}
			if (batchUpdate.ViewedShopItems != null)
			{
				updates[(object)"viewedShopItems"] = batchUpdate.ViewedShopItems;
			}
			if (batchUpdate.LastShopViewedLevel.HasValue)
			{
				updates[(object)"lastShopViewedLevel"] = batchUpdate.LastShopViewedLevel.Value;
			}
			if (batchUpdate.SetAccountLinked.HasValue)
			{
				updates[(object)"isAccountLinked"] = batchUpdate.SetAccountLinked.Value;
			}
			if (batchUpdate.DailyBattleChestUpdate != null)
			{
				DailyBattleChestUpdate chest = batchUpdate.DailyBattleChestUpdate;
				updates[(object)"dailyBattleChest.battlesCompleted"] = chest.BattlesCompleted;
				updates[(object)"dailyBattleChest.lastResetAt"] = chest.LastResetAt;
				if (chest.LastClaimedAt.HasValue)
				{
					updates[(object)"dailyBattleChest.lastClaimedAt"] = chest.LastClaimedAt.Value;
				}
			}
			if (Enumerable.Any<KeyValuePair<object, object>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<object, object>>)updates))
			{
				batch.UpdateData(playerRef, updates);
			}
			if (Enumerable.Any<KeyValuePair<string, TaskProgress>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, TaskProgress>>)batchUpdate.TaskUpdates) && !string.IsNullOrEmpty(batchUpdate.QuestId))
			{
				IDocumentReference questRef = playerRef.GetCollection("quests").GetDocument(batchUpdate.QuestId);
				Dictionary<object, object> questUpdates = new Dictionary<object, object>();
				Enumerator<string, TaskProgress> enumerator5 = batchUpdate.TaskUpdates.GetEnumerator();
				try
				{
					while (enumerator5.MoveNext())
					{
						KeyValuePair<string, TaskProgress> taskUpdate = enumerator5.Current;
						questUpdates[(object)("tasks." + taskUpdate.Key)] = new Dictionary<string, object>
						{
							["isCompleted"] = taskUpdate.Value.IsCompleted,
							["step"] = taskUpdate.Value.Step
						};
					}
				}
				finally
				{
					((global::System.IDisposable)enumerator5).Dispose();
				}
				batch.UpdateData(questRef, questUpdates);
			}
			if (Enumerable.Any<KeyValuePair<string, PlayerSpiritFieldUpdate>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, PlayerSpiritFieldUpdate>>)batchUpdate.SpiritFieldUpdates))
			{
				Enumerator<string, PlayerSpiritFieldUpdate> enumerator6 = batchUpdate.SpiritFieldUpdates.GetEnumerator();
				try
				{
					while (enumerator6.MoveNext())
					{
						KeyValuePair<string, PlayerSpiritFieldUpdate> spiritUpdate = enumerator6.Current;
						IDocumentReference spiritRef3 = playerRef.GetCollection("playerspirits").GetDocument(spiritUpdate.Key);
						Dictionary<object, object> spiritUpdates = new Dictionary<object, object>();
						if (spiritUpdate.Value.LevelChange.HasValue)
						{
							spiritUpdates[(object)"level"] = FieldValue.IntegerIncrement((long)spiritUpdate.Value.LevelChange.Value);
						}
						if (spiritUpdate.Value.HPChange.HasValue)
						{
							spiritUpdates[(object)"HP"] = FieldValue.IntegerIncrement((long)spiritUpdate.Value.HPChange.Value);
						}
						if (spiritUpdate.Value.TrainingPointsChange.HasValue)
						{
							spiritUpdates[(object)"points-unallocated"] = FieldValue.IntegerIncrement((long)spiritUpdate.Value.TrainingPointsChange.Value);
						}
						if (spiritUpdate.Value.SetPointsATK.HasValue)
						{
							spiritUpdates[(object)"pointsATK"] = spiritUpdate.Value.SetPointsATK.Value;
						}
						if (spiritUpdate.Value.SetPointsDEF.HasValue)
						{
							spiritUpdates[(object)"pointsDEF"] = spiritUpdate.Value.SetPointsDEF.Value;
						}
						if (spiritUpdate.Value.SetPointsSATK.HasValue)
						{
							spiritUpdates[(object)"pointsMGK"] = spiritUpdate.Value.SetPointsSATK.Value;
						}
						if (spiritUpdate.Value.SetPointsSDEF.HasValue)
						{
							spiritUpdates[(object)"pointsMDF"] = spiritUpdate.Value.SetPointsSDEF.Value;
						}
						if (spiritUpdate.Value.SetPointsSPD.HasValue)
						{
							spiritUpdates[(object)"pointsSPD"] = spiritUpdate.Value.SetPointsSPD.Value;
						}
						if (spiritUpdate.Value.SetPointsINT.HasValue)
						{
							spiritUpdates[(object)"pointsINT"] = spiritUpdate.Value.SetPointsINT.Value;
						}
						if (!string.IsNullOrEmpty(spiritUpdate.Value.SetNickname))
						{
							spiritUpdates[(object)"nickname"] = spiritUpdate.Value.SetNickname;
						}
						if (spiritUpdate.Value.SetFavorite.HasValue)
						{
							spiritUpdates[(object)"isFavorite"] = spiritUpdate.Value.SetFavorite.Value;
						}
						if (spiritUpdate.Value.SetHeldItemId != null)
						{
							spiritUpdates[(object)"heldItemId"] = spiritUpdate.Value.SetHeldItemId;
						}
						if (spiritUpdate.Value.SetGearId != null)
						{
							spiritUpdates[(object)"gearId"] = spiritUpdate.Value.SetGearId;
						}
						if (spiritUpdate.Value.SetTalentId != null)
						{
							spiritUpdates[(object)"talentId"] = spiritUpdate.Value.SetTalentId;
						}
						if (spiritUpdate.Value.SetBaseSpiritId.HasValue)
						{
							spiritUpdates[(object)"basespirit-ID"] = spiritUpdate.Value.SetBaseSpiritId.Value;
						}
						if (!string.IsNullOrEmpty(spiritUpdate.Value.SetName))
						{
							spiritUpdates[(object)"name"] = spiritUpdate.Value.SetName;
						}
						if (spiritUpdate.Value.MoveChanges != null && spiritUpdate.Value.MoveChanges.Count > 0)
						{
							if (spiritUpdate.Value.UpdateType == SpiritUpdateType.Evolve)
							{
								spiritUpdates[(object)"moves"] = Enumerable.ToDictionary<KeyValuePair<string, MoveStateUpdate>, string, object>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, MoveStateUpdate>>)spiritUpdate.Value.MoveChanges, (Func<KeyValuePair<string, MoveStateUpdate>, string>)((KeyValuePair<string, MoveStateUpdate> m) => m.Key), (Func<KeyValuePair<string, MoveStateUpdate>, object>)((KeyValuePair<string, MoveStateUpdate> m) => new Dictionary<string, object>
								{
									["is-active"] = m.Value.IsActiveMove,
									["is-unlocked"] = m.Value.IsUnlocked
								}));
							}
							else
							{
								Enumerator<string, MoveStateUpdate> enumerator7 = spiritUpdate.Value.MoveChanges.GetEnumerator();
								try
								{
									while (enumerator7.MoveNext())
									{
										KeyValuePair<string, MoveStateUpdate> moveUpdate = enumerator7.Current;
										spiritUpdates[(object)("moves." + moveUpdate.Key + ".is-active")] = moveUpdate.Value.IsActiveMove;
										spiritUpdates[(object)("moves." + moveUpdate.Key + ".is-unlocked")] = moveUpdate.Value.IsUnlocked;
									}
								}
								finally
								{
									((global::System.IDisposable)enumerator7).Dispose();
								}
							}
						}
						if (Enumerable.Any<KeyValuePair<object, object>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<object, object>>)spiritUpdates))
						{
							batch.UpdateData(spiritRef3, spiritUpdates);
						}
					}
				}
				finally
				{
					((global::System.IDisposable)enumerator6).Dispose();
				}
			}
			if (batchUpdate.SpiritsToAdd.Count > 0)
			{
				Enumerator<NewSpiritDTO> enumerator8 = batchUpdate.SpiritsToAdd.GetEnumerator();
				try
				{
					while (enumerator8.MoveNext())
					{
						NewSpiritDTO newSpirit = enumerator8.Current;
						FirestorePlayerSpiritDTO obj2 = new FirestorePlayerSpiritDTO
						{
							PlayerSpiritID = newSpirit.PlayerSpiritId,
							PlayerName = newSpirit.PlayerName,
							Name = newSpirit.Name,
							Nickname = newSpirit.Nickname,
							DateOwned = newSpirit.DateOwned,
							BaseSpiritID = newSpirit.BaseSpiritId,
							Level = newSpirit.Level,
							HP = newSpirit.HP,
							TrainingPoints = newSpirit.TrainingPoints,
							PointsATK = newSpirit.PointsATK,
							PointsDEF = newSpirit.PointsDEF,
							PointsSATK = newSpirit.PointsSATK,
							PointsSDEF = newSpirit.PointsSDEF,
							PointsSPD = newSpirit.PointsSPD,
							PointsINT = newSpirit.PointsINT,
							IsFavorite = newSpirit.IsFavorite,
							HeldItemID = newSpirit.HeldItemId,
							GearID = newSpirit.GearId,
							TalentID = newSpirit.TalentId
						};
						Dictionary<string, ValueTuple<bool, bool>> moves = newSpirit.Moves;
						obj2.Moves = ((moves != null) ? Enumerable.ToDictionary<KeyValuePair<string, ValueTuple<bool, bool>>, string, FirestoreMoveStateDTO>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, ValueTuple<bool, bool>>>)moves, (Func<KeyValuePair<string, ValueTuple<bool, bool>>, string>)((KeyValuePair<string, ValueTuple<bool, bool>> kv) => kv.Key), (Func<KeyValuePair<string, ValueTuple<bool, bool>>, FirestoreMoveStateDTO>)((KeyValuePair<string, ValueTuple<bool, bool>> kv) => new FirestoreMoveStateDTO
						{
							IsActiveMove = kv.Value.Item2,
							IsUnlocked = kv.Value.Item1
						})) : null);
						FirestorePlayerSpiritDTO firestoreSpiritData = obj2;
						IDocumentReference spiritRef2 = playerRef.GetCollection("playerspirits").GetDocument(newSpirit.PlayerSpiritId);
						batch.SetData(spiritRef2, (object)firestoreSpiritData, (SetOptions)null);
					}
				}
				finally
				{
					((global::System.IDisposable)enumerator8).Dispose();
				}
			}
			if (batchUpdate.SpiritsToRemove.Count > 0)
			{
				Enumerator<string> enumerator9 = batchUpdate.SpiritsToRemove.GetEnumerator();
				try
				{
					while (enumerator9.MoveNext())
					{
						string spiritId = enumerator9.Current;
						IDocumentReference spiritRef = playerRef.GetCollection("playerspirits").GetDocument(spiritId);
						batch.DeleteDocument(spiritRef);
					}
				}
				finally
				{
					((global::System.IDisposable)enumerator9).Dispose();
				}
			}
			Dictionary<object, object> profileUpdates = new Dictionary<object, object>();
			if (batchUpdate.ExperienceGain > 0 && batchUpdate.UpdateLevel)
			{
				profileUpdates[(object)"playerlevel"] = batchUpdate.NewPlayerLevel;
			}
			if (batchUpdate.WinsChange != 0)
			{
				profileUpdates[(object)"battleStats.wins"] = FieldValue.IntegerIncrement((long)batchUpdate.WinsChange);
			}
			if (batchUpdate.LossChange != 0)
			{
				profileUpdates[(object)"battleStats.losses"] = FieldValue.IntegerIncrement((long)batchUpdate.LossChange);
			}
			if (batchUpdate.ScoreChange != 0)
			{
				profileUpdates[(object)"battleStats.score"] = FieldValue.IntegerIncrement((long)batchUpdate.ScoreChange);
				profileUpdates[(object)"battleStats.lastScoreUpdate"] = DateTimeOffset.UtcNow;
			}
			if (!string.IsNullOrEmpty(batchUpdate.NewTitle))
			{
				profileUpdates[(object)"battleStats.title"] = batchUpdate.NewTitle;
			}
			if (batchUpdate.NewActiveSquadComp != null)
			{
				profileUpdates[(object)"activeSquad"] = batchUpdate.NewActiveSquadComp;
			}
			if (batchUpdate.UpdateBattleUnit && !string.IsNullOrEmpty(batchUpdate.ActiveBattleUnitId))
			{
				profileUpdates[(object)"partnerSpiritID"] = batchUpdate.ActiveBattleUnitId;
			}
			if (!string.IsNullOrEmpty(batchUpdate.GuildUpdates.TargetPlayerId) && batchUpdate.GuildUpdates.GuildId != null)
			{
				profileUpdates[(object)"guildId"] = batchUpdate.GuildUpdates.GuildId;
			}
			if (!string.IsNullOrEmpty(batchUpdate.NewPlayerIcon))
			{
				profileUpdates[(object)"playerIcon"] = batchUpdate.NewPlayerIcon;
			}
			if (Enumerable.Any<KeyValuePair<object, object>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<object, object>>)profileUpdates))
			{
				IDocumentReference profileRef = _firestore.GetCollection("publicProfiles").GetDocument(batchUpdate.PlayerId);
				IDocumentSnapshot<FirestorePublicProfileDTO> snapshot = await profileRef.GetDocumentSnapshotAsync<FirestorePublicProfileDTO>((Source)0);
				if (snapshot != null && snapshot?.Data != null)
				{
					batch.UpdateData(profileRef, profileUpdates);
				}
			}
			await batch.CommitAsync();
			if (batchUpdate.UpdateLeaderboard)
			{
				await UpdateLeaderboardEntry(batchUpdate.PlayerId);
			}
			return BatchUpdateOutcome.Success;
		}
		catch (global::System.Exception ex2) when (ex2.Message.Contains("PERMISSION_DENIED", (StringComparison)5))
		{
			Console.WriteLine("Batch update permanently rejected (permission denied): " + ex2.Message);
			return BatchUpdateOutcome.PermanentFailure;
		}
		catch (global::System.Exception ex3)
		{
			global::System.Exception ex = ex3;
			Console.WriteLine("Batch update failed (transient): " + ex.Message);
			Console.WriteLine(ex.StackTrace);
			return BatchUpdateOutcome.TransientFailure;
		}
	}

	[AsyncStateMachine(typeof(_003CUpdateLeaderboardEntry_003Ed__19))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task UpdateLeaderboardEntry(string playerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CUpdateLeaderboardEntry_003Ed__19 _003CUpdateLeaderboardEntry_003Ed__ = new _003CUpdateLeaderboardEntry_003Ed__19();
		_003CUpdateLeaderboardEntry_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CUpdateLeaderboardEntry_003Ed__._003C_003E4__this = this;
		_003CUpdateLeaderboardEntry_003Ed__.playerId = playerId;
		_003CUpdateLeaderboardEntry_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CUpdateLeaderboardEntry_003Ed__._003C_003Et__builder)).Start<_003CUpdateLeaderboardEntry_003Ed__19>(ref _003CUpdateLeaderboardEntry_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CUpdateLeaderboardEntry_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRemovePlayerSpirit_003Ed__20))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task RemovePlayerSpirit(string playerId, string spiritId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRemovePlayerSpirit_003Ed__20 _003CRemovePlayerSpirit_003Ed__ = new _003CRemovePlayerSpirit_003Ed__20();
		_003CRemovePlayerSpirit_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRemovePlayerSpirit_003Ed__._003C_003E4__this = this;
		_003CRemovePlayerSpirit_003Ed__.playerId = playerId;
		_003CRemovePlayerSpirit_003Ed__.spiritId = spiritId;
		_003CRemovePlayerSpirit_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRemovePlayerSpirit_003Ed__._003C_003Et__builder)).Start<_003CRemovePlayerSpirit_003Ed__20>(ref _003CRemovePlayerSpirit_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRemovePlayerSpirit_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CUpdatePlayerSpirits_003Ed__21))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<string> UpdatePlayerSpirits(FirestorePlayerDTO player, FirestorePlayerSpiritDTO playerSpirit, string spiritId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Dictionary<object, object> obj4 = new Dictionary<object, object>
			{
				[(object)"playername"] = playerSpirit.PlayerName ?? "",
				[(object)"name"] = playerSpirit.Name ?? "",
				[(object)"nickname"] = playerSpirit.Nickname ?? ""
			};
			object obj5 = "dateOwned";
			DateTimeOffset dateOwned = playerSpirit.DateOwned;
			obj4[obj5] = ((DateTimeOffset)(ref dateOwned)).ToUniversalTime();
			object obj6 = "basespirit-ID";
			obj4[obj6] = playerSpirit.BaseSpiritID;
			object obj7 = "level";
			obj4[obj7] = playerSpirit.Level;
			object obj8 = "points-unallocated";
			obj4[obj8] = playerSpirit.TrainingPoints;
			object obj9 = "HP";
			obj4[obj9] = playerSpirit.HP;
			object obj10 = "pointsATK";
			obj4[obj10] = playerSpirit.PointsATK;
			object obj11 = "pointsDEF";
			obj4[obj11] = playerSpirit.PointsDEF;
			object obj12 = "pointsMGK";
			obj4[obj12] = playerSpirit.PointsSATK;
			object obj13 = "pointsMDF";
			obj4[obj13] = playerSpirit.PointsSDEF;
			object obj14 = "pointsSPD";
			obj4[obj14] = playerSpirit.PointsSPD;
			object obj15 = "pointsINT";
			obj4[obj15] = playerSpirit.PointsINT;
			object obj16 = "isFavorite";
			obj4[obj16] = playerSpirit.IsFavorite;
			object obj17 = "heldItemId";
			obj4[obj17] = playerSpirit.HeldItemID ?? "";
			object obj18 = "moves";
			obj4[obj18] = new Dictionary<object, object>();
			Dictionary<object, object> firestoreSpirit = obj4;
			await _firestore.GetCollection("players/" + player.PlayerID + "/playerspirits").GetDocument(spiritId).SetDataAsync(firestoreSpirit, (SetOptions)null);
			IWriteBatch batch = _firestore.CreateBatch();
			IDocumentReference playerRef = _firestore.GetCollection("players").GetDocument(player.PlayerID + "/playerspirits/" + spiritId);
			Dictionary<object, object> updates = new Dictionary<object, object>();
			Enumerator<string, FirestoreMoveStateDTO> enumerator = playerSpirit.Moves.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, FirestoreMoveStateDTO> move = enumerator.Current;
					updates[(object)("moves." + move.Key)] = new Dictionary<string, object>
					{
						["is-active"] = move.Value.IsActiveMove,
						["is-unlocked"] = move.Value.IsUnlocked
					};
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator).Dispose();
			}
			batch.UpdateData(playerRef, updates);
			await batch.CommitAsync();
			return spiritId;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine(ex.Message);
			Console.WriteLine(ex.StackTrace);
			return string.Empty;
		}
	}

	[AsyncStateMachine(typeof(_003CUpdateShopPurchase_003Ed__22))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> UpdateShopPurchase(FirestorePlayerDTO player, ShopType shopType)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Dictionary<string, FirestoreInventoryDTO> inventoryForFirestore = player.Inventory;
			if (shopType == ShopType.items)
			{
				string fieldPath = "inventory";
				IDocumentReference document = _firestore.GetCollection("players").GetDocument(player.PlayerID);
				Dictionary<object, object> obj = new Dictionary<object, object>();
				obj.Add((object)fieldPath, (object)inventoryForFirestore);
				await document.UpdateDataAsync(obj);
			}
			else
			{
				string fieldPath2 = $"playercurrencies.{shopType}";
				string fieldPathItem = "inventory";
				IDocumentReference document2 = _firestore.GetCollection("players").GetDocument(player.PlayerID);
				Dictionary<object, object> obj2 = new Dictionary<object, object>();
				obj2.Add((object)fieldPath2, (object)(player.Currencies?[((object)shopType).ToString()] ?? 0));
				obj2.Add((object)fieldPathItem, (object)inventoryForFirestore);
				await document2.UpdateDataAsync(obj2);
			}
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error updating nickname: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CUpdatePlayerSpiritPurchase_003Ed__23))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<string> UpdatePlayerSpiritPurchase(FirestorePlayerDTO player, FirestorePlayerSpiritDTO playerSpiritAdded)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			string fieldPath = "inventory";
			Dictionary<string, FirestoreInventoryDTO> inventoryForFirestore = player.Inventory;
			IDocumentReference document = _firestore.GetCollection("players").GetDocument(player.PlayerID);
			Dictionary<object, object> obj = new Dictionary<object, object>();
			obj.Add((object)fieldPath, (object)(inventoryForFirestore ?? new Dictionary<string, FirestoreInventoryDTO>()));
			await document.UpdateDataAsync(obj);
			return await UpdatePlayerSpirits(player, playerSpiritAdded, playerSpiritAdded.PlayerSpiritID ?? string.Empty);
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error updating spirit purchase: " + ex.Message);
			return string.Empty;
		}
	}

	[AsyncStateMachine(typeof(_003CSearchPlayersAsync_003Ed__24))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<Player>> SearchPlayersAsync(string searchText, int limit = 20)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (string.IsNullOrWhiteSpace(searchText))
			{
				return new List<Player>();
			}
			string searchLower = searchText.ToLower();
			IQuerySnapshot<FirestorePublicProfileDTO> querySnapshot = await ((IQuery)_firestore.GetCollection("publicProfiles")).LimitedTo(100).GetDocumentsAsync<FirestorePublicProfileDTO>((Source)0);
			if (querySnapshot == null || !Enumerable.Any<IDocumentSnapshot<FirestorePublicProfileDTO>>(querySnapshot.Documents))
			{
				return new List<Player>();
			}
			List<FirestorePublicProfileDTO> players = new List<FirestorePublicProfileDTO>();
			global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestorePublicProfileDTO>> enumerator = querySnapshot.Documents.GetEnumerator();
			try
			{
				while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
				{
					IDocumentSnapshot<FirestorePublicProfileDTO> document = enumerator.Current;
					FirestorePublicProfileDTO playerDTO = document.Data;
					string? playerName = playerDTO.PlayerName;
					if (playerName != null && playerName.ToLower().Contains(searchLower))
					{
						players.Add(playerDTO);
						if (players.Count >= limit)
						{
							break;
						}
					}
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator)?.Dispose();
			}
			return PlayerEntityMapper.ToEntities((global::System.Collections.Generic.IEnumerable<FirestorePublicProfileDTO>)players);
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error searching players: " + ex.Message);
			return new List<Player>();
		}
	}

	[AsyncStateMachine(typeof(_003CGetFriendsAsync_003Ed__26))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<Friend>> GetFriendsAsync(string playerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IQuerySnapshot<FirestoreFriendDTO> snapshot = await ((IQuery)_firestore.GetCollection("players").GetDocument(playerId).GetCollection("friends")).GetDocumentsAsync<FirestoreFriendDTO>((Source)0);
			if (snapshot?.Documents == null || !Enumerable.Any<IDocumentSnapshot<FirestoreFriendDTO>>(snapshot.Documents))
			{
				return new List<Friend>();
			}
			return Enumerable.ToList<Friend>(Enumerable.Select<IDocumentSnapshot<FirestoreFriendDTO>, Friend>(Enumerable.Where<IDocumentSnapshot<FirestoreFriendDTO>>(snapshot.Documents, (Func<IDocumentSnapshot<FirestoreFriendDTO>, bool>)((IDocumentSnapshot<FirestoreFriendDTO> d) => d.Data != null)), (Func<IDocumentSnapshot<FirestoreFriendDTO>, Friend>)((IDocumentSnapshot<FirestoreFriendDTO> d) => new Friend
			{
				FriendId = d.Data.FriendId,
				FriendName = d.Data.FriendName,
				AddedAt = d.Data.AddedAt
			})));
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error getting friends: " + ex.Message);
			return new List<Friend>();
		}
	}

	[AsyncStateMachine(typeof(_003CAddFriendAsync_003Ed__27))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> AddFriendAsync(string playerId, Friend friend)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			FirestoreFriendDTO dto = new FirestoreFriendDTO
			{
				FriendId = friend.FriendId,
				FriendName = friend.FriendName,
				AddedAt = friend.AddedAt
			};
			await _firestore.GetCollection("players").GetDocument(playerId).GetCollection("friends")
				.GetDocument(friend.FriendId)
				.SetDataAsync((object)dto, (SetOptions)null);
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error adding friend: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CRemoveFriendAsync_003Ed__28))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> RemoveFriendAsync(string playerId, string friendId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			await _firestore.GetCollection("players").GetDocument(playerId).GetCollection("friends")
				.GetDocument(friendId)
				.DeleteDocumentAsync();
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error removing friend: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CGetDailyBattleTasksAsync_003Ed__30))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<PlayerDailyBattleTasks?> GetDailyBattleTasksAsync(string playerId, string dateKey)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentSnapshot<FirestoreDailyBattleTasksDTO> snapshot = await _firestore.GetCollection($"{"players"}/{playerId}/{"dailyBattleTasks"}").GetDocument(dateKey).GetDocumentSnapshotAsync<FirestoreDailyBattleTasksDTO>((Source)0);
			if (snapshot?.Data == null)
			{
				return null;
			}
			return PlayerDailyBattleTasks.Rehydrate(dateKey, snapshot.Data.ToTaskDict());
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("GetDailyBattleTasksAsync error: " + ex.Message);
			return null;
		}
	}

	[AsyncStateMachine(typeof(_003CSaveDailyBattleTasksAsync_003Ed__31))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> SaveDailyBattleTasksAsync(string playerId, PlayerDailyBattleTasks tasks)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			FirestoreDailyBattleTasksDTO dto = FirestoreDailyBattleTasksDTO.FromEntity(tasks);
			await _firestore.GetCollection($"{"players"}/{playerId}/{"dailyBattleTasks"}").GetDocument(tasks.DateKey).SetDataAsync((object)dto, SetOptions.Merge());
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("SaveDailyBattleTasksAsync error: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CUpdatePresenceAsync_003Ed__32))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task UpdatePresenceAsync(string playerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CUpdatePresenceAsync_003Ed__32 _003CUpdatePresenceAsync_003Ed__ = new _003CUpdatePresenceAsync_003Ed__32();
		_003CUpdatePresenceAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CUpdatePresenceAsync_003Ed__._003C_003E4__this = this;
		_003CUpdatePresenceAsync_003Ed__.playerId = playerId;
		_003CUpdatePresenceAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CUpdatePresenceAsync_003Ed__._003C_003Et__builder)).Start<_003CUpdatePresenceAsync_003Ed__32>(ref _003CUpdatePresenceAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CUpdatePresenceAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGetFriendPresencesAsync_003Ed__33))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Dictionary<string, ValueTuple<DateTimeOffset?, string?>>> GetFriendPresencesAsync(global::System.Collections.Generic.IEnumerable<string> playerIds)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<string, ValueTuple<DateTimeOffset?, string?>> result = new Dictionary<string, ValueTuple<DateTimeOffset?, string>>();
		try
		{
			global::System.Collections.Generic.IEnumerable<global::System.Threading.Tasks.Task<ValueTuple<string, DateTimeOffset?, string>>> tasks = Enumerable.Select<string, global::System.Threading.Tasks.Task<ValueTuple<string, DateTimeOffset?, string>>>(playerIds, (Func<string, global::System.Threading.Tasks.Task<ValueTuple<string, DateTimeOffset?, string>>>)([AsyncStateMachine(typeof(_003C_003CGetFriendPresencesAsync_003Eb__33_0_003Ed))] [DebuggerStepThrough] [CompilerGenerated] async (string id) =>
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				try
				{
					IDocumentSnapshot<FirestorePublicProfileDTO> snapshot = await _firestore.GetCollection("publicProfiles").GetDocument(id).GetDocumentSnapshotAsync<FirestorePublicProfileDTO>((Source)0);
					DateTimeOffset? ts2 = snapshot?.Data?.LastOnlineAt;
					string icon2 = snapshot?.Data?.PlayerIcon;
					DateTimeOffset? val2 = ts2;
					DateTimeOffset minValue = DateTimeOffset.MinValue;
					return new ValueTuple<string, DateTimeOffset?, string>(id, (val2.HasValue && val2.GetValueOrDefault() == minValue) ? null : ts2, icon2);
				}
				catch
				{
					return new ValueTuple<string, DateTimeOffset?, string>(id, (DateTimeOffset?)null, (string)null);
				}
			}));
			ValueTuple<string, DateTimeOffset?, string>[] array = await global::System.Threading.Tasks.Task.WhenAll<ValueTuple<string, DateTimeOffset?, string>>(tasks);
			for (int i = 0; i < array.Length; i++)
			{
				ValueTuple<string, DateTimeOffset?, string> val = array[i];
				string id2 = val.Item1;
				DateTimeOffset? ts = val.Item2;
				string icon = val.Item3;
				result[id2] = new ValueTuple<DateTimeOffset?, string>(ts, icon);
			}
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("GetFriendPresencesAsync error: " + ex.Message);
		}
		return result;
	}
}
