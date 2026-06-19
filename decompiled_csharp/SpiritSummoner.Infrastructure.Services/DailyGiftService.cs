using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Plugin.Firebase.Firestore;
using SpiritSummoner.Application.DTOs;
using SpiritSummoner.Infrastructure.Diagnostics;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Players;

namespace SpiritSummoner.Infrastructure.Services;

public class DailyGiftService : IDailyGiftService
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public HashSet<string> redeemedIds;

		internal bool _003CGetUnredeemedGiftsAsync_003Eb__0(DailyGiftDTO t)
		{
			return !redeemedIds.Contains(t.Id);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public DateTimeOffset now;

		internal bool _003CGetGiftTemplatesAsync_003Eb__1(FirestoreDailyGiftDTO dto)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			int result;
			if (dto != null)
			{
				if (dto.ExpiresAt.HasValue)
				{
					DateTimeOffset? expiresAt = dto.ExpiresAt;
					DateTimeOffset val = now;
					result = ((expiresAt.HasValue && expiresAt.GetValueOrDefault() > val) ? 1 : 0);
				}
				else
				{
					result = 1;
				}
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetGiftTemplatesAsync_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<DailyGiftDTO>> _003C_003Et__builder;

		public DailyGiftService _003C_003E4__this;

		private _003C_003Ec__DisplayClass4_0 _003C_003E8__1;

		private IQuerySnapshot<FirestoreDailyGiftDTO> _003Csnapshot_003E5__2;

		private IQuerySnapshot<FirestoreDailyGiftDTO> _003C_003Es__3;

		private TaskAwaiter<IQuerySnapshot<FirestoreDailyGiftDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<DailyGiftDTO> result;
			try
			{
				TaskAwaiter<IQuerySnapshot<FirestoreDailyGiftDTO>> awaiter;
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass4_0();
					awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection("dailyGifts")).OrderBy("createdAt", false).LimitedTo(50).GetDocumentsAsync<FirestoreDailyGiftDTO>((Source)0)
						.GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGetGiftTemplatesAsync_003Ed__4 _003CGetGiftTemplatesAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreDailyGiftDTO>>, _003CGetGiftTemplatesAsync_003Ed__4>(ref awaiter, ref _003CGetGiftTemplatesAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreDailyGiftDTO>>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__3 = awaiter.GetResult();
				_003Csnapshot_003E5__2 = _003C_003Es__3;
				_003C_003Es__3 = null;
				if (_003Csnapshot_003E5__2?.Documents == null || !Enumerable.Any<IDocumentSnapshot<FirestoreDailyGiftDTO>>(_003Csnapshot_003E5__2.Documents))
				{
					result = new List<DailyGiftDTO>();
				}
				else
				{
					FirestoreReadCounter.Track("GetGiftTemplates", Enumerable.Count<IDocumentSnapshot<FirestoreDailyGiftDTO>>(_003Csnapshot_003E5__2.Documents));
					_003C_003E8__1.now = DateTimeOffset.UtcNow;
					result = Enumerable.ToList<DailyGiftDTO>(Enumerable.Select<FirestoreDailyGiftDTO, DailyGiftDTO>(Enumerable.Where<FirestoreDailyGiftDTO>(Enumerable.Select<IDocumentSnapshot<FirestoreDailyGiftDTO>, FirestoreDailyGiftDTO>(_003Csnapshot_003E5__2.Documents, (Func<IDocumentSnapshot<FirestoreDailyGiftDTO>, FirestoreDailyGiftDTO>)((IDocumentSnapshot<FirestoreDailyGiftDTO> d) => d.Data)), (Func<FirestoreDailyGiftDTO, bool>)delegate(FirestoreDailyGiftDTO dto)
					{
						//IL_001b: Unknown result type (might be due to invalid IL or missing references)
						//IL_0020: Unknown result type (might be due to invalid IL or missing references)
						//IL_002f: Unknown result type (might be due to invalid IL or missing references)
						//IL_0034: Unknown result type (might be due to invalid IL or missing references)
						int result2;
						if (dto != null)
						{
							if (dto.ExpiresAt.HasValue)
							{
								DateTimeOffset? expiresAt = dto.ExpiresAt;
								DateTimeOffset now = _003C_003E8__1.now;
								result2 = ((expiresAt.HasValue && expiresAt.GetValueOrDefault() > now) ? 1 : 0);
							}
							else
							{
								result2 = 1;
							}
						}
						else
						{
							result2 = 0;
						}
						return (byte)result2 != 0;
					}), (Func<FirestoreDailyGiftDTO, DailyGiftDTO>)MapToDto));
				}
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
	private sealed class _003CGetRedeemedGiftIdsAsync_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<HashSet<string>> _003C_003Et__builder;

		public string playerId;

		public DailyGiftService _003C_003E4__this;

		private IQuerySnapshot<FirestoreRedeemedGiftDTO> _003Csnapshot_003E5__1;

		private IQuerySnapshot<FirestoreRedeemedGiftDTO> _003C_003Es__2;

		private TaskAwaiter<IQuerySnapshot<FirestoreRedeemedGiftDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			HashSet<string> result;
			try
			{
				TaskAwaiter<IQuerySnapshot<FirestoreRedeemedGiftDTO>> awaiter;
				if (num != 0)
				{
					awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection("players").GetDocument(playerId).GetCollection("redeemedGifts")).GetDocumentsAsync<FirestoreRedeemedGiftDTO>((Source)0).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGetRedeemedGiftIdsAsync_003Ed__5 _003CGetRedeemedGiftIdsAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreRedeemedGiftDTO>>, _003CGetRedeemedGiftIdsAsync_003Ed__5>(ref awaiter, ref _003CGetRedeemedGiftIdsAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreRedeemedGiftDTO>>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__2 = awaiter.GetResult();
				_003Csnapshot_003E5__1 = _003C_003Es__2;
				_003C_003Es__2 = null;
				if (_003Csnapshot_003E5__1?.Documents == null || !Enumerable.Any<IDocumentSnapshot<FirestoreRedeemedGiftDTO>>(_003Csnapshot_003E5__1.Documents))
				{
					result = new HashSet<string>();
				}
				else
				{
					FirestoreReadCounter.Track("GetRedeemedGifts", Enumerable.Count<IDocumentSnapshot<FirestoreRedeemedGiftDTO>>(_003Csnapshot_003E5__1.Documents));
					result = Enumerable.ToHashSet<string>(Enumerable.Where<string>(Enumerable.Select<IDocumentSnapshot<FirestoreRedeemedGiftDTO>, string>(_003Csnapshot_003E5__1.Documents, (Func<IDocumentSnapshot<FirestoreRedeemedGiftDTO>, string>)((IDocumentSnapshot<FirestoreRedeemedGiftDTO> d) => d.Data?.Id)), (Func<string, bool>)((string id) => !string.IsNullOrEmpty(id))));
				}
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
	private sealed class _003CGetUnredeemedGiftsAsync_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<List<DailyGiftDTO>> _003C_003Et__builder;

		public string playerId;

		public DailyGiftService _003C_003E4__this;

		private _003C_003Ec__DisplayClass2_0 _003C_003E8__1;

		private global::System.Threading.Tasks.Task<List<DailyGiftDTO>> _003CtemplatesTask_003E5__2;

		private global::System.Threading.Tasks.Task<HashSet<string>> _003CredeemedIdsTask_003E5__3;

		private List<DailyGiftDTO> _003Ctemplates_003E5__4;

		private List<DailyGiftDTO> _003C_003Es__5;

		private HashSet<string> _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<List<DailyGiftDTO>> _003C_003Eu__2;

		private TaskAwaiter<HashSet<string>> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_01af: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			List<DailyGiftDTO> result;
			try
			{
				if ((uint)num > 2u && string.IsNullOrEmpty(playerId))
				{
					result = new List<DailyGiftDTO>();
				}
				else
				{
					try
					{
						TaskAwaiter awaiter3;
						TaskAwaiter<List<DailyGiftDTO>> awaiter2;
						TaskAwaiter<HashSet<string>> awaiter;
						switch (num)
						{
						default:
						{
							_003C_003E8__1 = new _003C_003Ec__DisplayClass2_0();
							_003CtemplatesTask_003E5__2 = _003C_003E4__this.GetGiftTemplatesAsync();
							_003CredeemedIdsTask_003E5__3 = _003C_003E4__this.GetRedeemedGiftIdsAsync(playerId);
							_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task> buffer = default(_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task>);
							_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task>, global::System.Threading.Tasks.Task>(ref buffer, 0) = _003CtemplatesTask_003E5__2;
							_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task>, global::System.Threading.Tasks.Task>(ref buffer, 1) = _003CredeemedIdsTask_003E5__3;
							awaiter3 = global::System.Threading.Tasks.Task.WhenAll(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task>, global::System.Threading.Tasks.Task>(in buffer, 2)).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter3;
								_003CGetUnredeemedGiftsAsync_003Ed__2 _003CGetUnredeemedGiftsAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CGetUnredeemedGiftsAsync_003Ed__2>(ref awaiter3, ref _003CGetUnredeemedGiftsAsync_003Ed__);
								return;
							}
							goto IL_010b;
						}
						case 0:
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_010b;
						case 1:
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<List<DailyGiftDTO>>);
							num = (_003C_003E1__state = -1);
							goto IL_016f;
						case 2:
							{
								awaiter = _003C_003Eu__3;
								_003C_003Eu__3 = default(TaskAwaiter<HashSet<string>>);
								num = (_003C_003E1__state = -1);
								break;
							}
							IL_016f:
							_003C_003Es__5 = awaiter2.GetResult();
							_003Ctemplates_003E5__4 = _003C_003Es__5;
							_003C_003Es__5 = null;
							awaiter = _003CredeemedIdsTask_003E5__3.GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter;
								_003CGetUnredeemedGiftsAsync_003Ed__2 _003CGetUnredeemedGiftsAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<HashSet<string>>, _003CGetUnredeemedGiftsAsync_003Ed__2>(ref awaiter, ref _003CGetUnredeemedGiftsAsync_003Ed__);
								return;
							}
							break;
							IL_010b:
							((TaskAwaiter)(ref awaiter3)).GetResult();
							awaiter2 = _003CtemplatesTask_003E5__2.GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter2;
								_003CGetUnredeemedGiftsAsync_003Ed__2 _003CGetUnredeemedGiftsAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<DailyGiftDTO>>, _003CGetUnredeemedGiftsAsync_003Ed__2>(ref awaiter2, ref _003CGetUnredeemedGiftsAsync_003Ed__);
								return;
							}
							goto IL_016f;
						}
						_003C_003Es__6 = awaiter.GetResult();
						_003C_003E8__1.redeemedIds = _003C_003Es__6;
						_003C_003Es__6 = null;
						result = Enumerable.ToList<DailyGiftDTO>(Enumerable.Where<DailyGiftDTO>((global::System.Collections.Generic.IEnumerable<DailyGiftDTO>)_003Ctemplates_003E5__4, (Func<DailyGiftDTO, bool>)((DailyGiftDTO t) => !_003C_003E8__1.redeemedIds.Contains(t.Id))));
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__7 = ex;
						Console.WriteLine("DailyGiftService.GetUnredeemedGiftsAsync error: " + _003Cex_003E5__7.Message);
						result = new List<DailyGiftDTO>();
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
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CMarkAsRedeemedAsync_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string playerId;

		public string giftId;

		public DailyGiftService _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0 || (!string.IsNullOrEmpty(playerId) && !string.IsNullOrEmpty(giftId)))
				{
					try
					{
						TaskAwaiter awaiter;
						if (num != 0)
						{
							awaiter = _003C_003E4__this._firestore.GetCollection("players").GetDocument(playerId).GetCollection("redeemedGifts")
								.GetDocument(giftId)
								.SetDataAsync(new Dictionary<object, object> { [(object)"redeemedAt"] = FieldValue.ServerTimestamp() }, (SetOptions)null)
								.GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CMarkAsRedeemedAsync_003Ed__3 _003CMarkAsRedeemedAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CMarkAsRedeemedAsync_003Ed__3>(ref awaiter, ref _003CMarkAsRedeemedAsync_003Ed__);
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
						Console.WriteLine("DailyGiftService.MarkAsRedeemedAsync error: " + _003Cex_003E5__1.Message);
					}
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

	private readonly IFirebaseFirestore _firestore;

	public DailyGiftService(IFirebaseFirestore firestore)
	{
		_firestore = firestore;
	}

	[AsyncStateMachine(typeof(_003CGetUnredeemedGiftsAsync_003Ed__2))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<List<DailyGiftDTO>> GetUnredeemedGiftsAsync(string playerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(playerId))
		{
			return new List<DailyGiftDTO>();
		}
		try
		{
			global::System.Threading.Tasks.Task<List<DailyGiftDTO>> templatesTask = GetGiftTemplatesAsync();
			global::System.Threading.Tasks.Task<HashSet<string>> redeemedIdsTask = GetRedeemedGiftIdsAsync(playerId);
			_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task> buffer = default(_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task>);
			_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task>, global::System.Threading.Tasks.Task>(ref buffer, 0) = templatesTask;
			_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task>, global::System.Threading.Tasks.Task>(ref buffer, 1) = redeemedIdsTask;
			await global::System.Threading.Tasks.Task.WhenAll(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray2<global::System.Threading.Tasks.Task>, global::System.Threading.Tasks.Task>(in buffer, 2));
			List<DailyGiftDTO> templates = await templatesTask;
			HashSet<string> redeemedIds = await redeemedIdsTask;
			return Enumerable.ToList<DailyGiftDTO>(Enumerable.Where<DailyGiftDTO>((global::System.Collections.Generic.IEnumerable<DailyGiftDTO>)templates, (Func<DailyGiftDTO, bool>)((DailyGiftDTO t) => !redeemedIds.Contains(t.Id))));
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine("DailyGiftService.GetUnredeemedGiftsAsync error: " + ex.Message);
			return new List<DailyGiftDTO>();
		}
	}

	[AsyncStateMachine(typeof(_003CMarkAsRedeemedAsync_003Ed__3))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task MarkAsRedeemedAsync(string playerId, string giftId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CMarkAsRedeemedAsync_003Ed__3 _003CMarkAsRedeemedAsync_003Ed__ = new _003CMarkAsRedeemedAsync_003Ed__3();
		_003CMarkAsRedeemedAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CMarkAsRedeemedAsync_003Ed__._003C_003E4__this = this;
		_003CMarkAsRedeemedAsync_003Ed__.playerId = playerId;
		_003CMarkAsRedeemedAsync_003Ed__.giftId = giftId;
		_003CMarkAsRedeemedAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CMarkAsRedeemedAsync_003Ed__._003C_003Et__builder)).Start<_003CMarkAsRedeemedAsync_003Ed__3>(ref _003CMarkAsRedeemedAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CMarkAsRedeemedAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGetGiftTemplatesAsync_003Ed__4))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<List<DailyGiftDTO>> GetGiftTemplatesAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		IQuerySnapshot<FirestoreDailyGiftDTO> snapshot = await ((IQuery)_firestore.GetCollection("dailyGifts")).OrderBy("createdAt", false).LimitedTo(50).GetDocumentsAsync<FirestoreDailyGiftDTO>((Source)0);
		if (snapshot?.Documents == null || !Enumerable.Any<IDocumentSnapshot<FirestoreDailyGiftDTO>>(snapshot.Documents))
		{
			return new List<DailyGiftDTO>();
		}
		FirestoreReadCounter.Track("GetGiftTemplates", Enumerable.Count<IDocumentSnapshot<FirestoreDailyGiftDTO>>(snapshot.Documents));
		DateTimeOffset now = DateTimeOffset.UtcNow;
		return Enumerable.ToList<DailyGiftDTO>(Enumerable.Select<FirestoreDailyGiftDTO, DailyGiftDTO>(Enumerable.Where<FirestoreDailyGiftDTO>(Enumerable.Select<IDocumentSnapshot<FirestoreDailyGiftDTO>, FirestoreDailyGiftDTO>(snapshot.Documents, (Func<IDocumentSnapshot<FirestoreDailyGiftDTO>, FirestoreDailyGiftDTO>)((IDocumentSnapshot<FirestoreDailyGiftDTO> d) => d.Data)), (Func<FirestoreDailyGiftDTO, bool>)delegate(FirestoreDailyGiftDTO dto)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			int result;
			if (dto != null)
			{
				if (dto.ExpiresAt.HasValue)
				{
					DateTimeOffset? expiresAt = dto.ExpiresAt;
					DateTimeOffset val = now;
					result = ((expiresAt.HasValue && expiresAt.GetValueOrDefault() > val) ? 1 : 0);
				}
				else
				{
					result = 1;
				}
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}), (Func<FirestoreDailyGiftDTO, DailyGiftDTO>)MapToDto));
	}

	[AsyncStateMachine(typeof(_003CGetRedeemedGiftIdsAsync_003Ed__5))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<HashSet<string>> GetRedeemedGiftIdsAsync(string playerId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		IQuerySnapshot<FirestoreRedeemedGiftDTO> snapshot = await ((IQuery)_firestore.GetCollection("players").GetDocument(playerId).GetCollection("redeemedGifts")).GetDocumentsAsync<FirestoreRedeemedGiftDTO>((Source)0);
		if (snapshot?.Documents == null || !Enumerable.Any<IDocumentSnapshot<FirestoreRedeemedGiftDTO>>(snapshot.Documents))
		{
			return new HashSet<string>();
		}
		FirestoreReadCounter.Track("GetRedeemedGifts", Enumerable.Count<IDocumentSnapshot<FirestoreRedeemedGiftDTO>>(snapshot.Documents));
		return Enumerable.ToHashSet<string>(Enumerable.Where<string>(Enumerable.Select<IDocumentSnapshot<FirestoreRedeemedGiftDTO>, string>(snapshot.Documents, (Func<IDocumentSnapshot<FirestoreRedeemedGiftDTO>, string>)((IDocumentSnapshot<FirestoreRedeemedGiftDTO> d) => d.Data?.Id)), (Func<string, bool>)((string id) => !string.IsNullOrEmpty(id))));
	}

	private static DailyGiftDTO MapToDto(FirestoreDailyGiftDTO dto)
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		return new DailyGiftDTO
		{
			Id = (dto.Id ?? string.Empty),
			RewardType = (dto.RewardType ?? string.Empty),
			Amount = dto.Amount,
			ItemKey = dto.ItemKey,
			Title = dto.Title,
			Description = dto.Description,
			IconSource = dto.IconSource,
			ExpiresAt = dto.ExpiresAt,
			CreatedAt = dto.CreatedAt
		};
	}
}
