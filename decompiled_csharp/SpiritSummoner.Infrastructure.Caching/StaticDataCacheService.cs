using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Plugin.Firebase.Firestore;
using SpiritSummoner.Application.Services;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Entities.Quests;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Infrastructure.Diagnostics;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Items;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Moves;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Quests;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Spirits;
using SpiritSummoner.Infrastructure.Persistence.Mapping;

namespace SpiritSummoner.Infrastructure.Caching;

public class StaticDataCacheService : IStaticDataCacheService
{
	private sealed class StaticDataVersionsDTO : IFirestoreObject
	{
		[FirestoreProperty("spirits")]
		[field: CompilerGenerated]
		[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
		public int Spirits
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[FirestoreProperty("items")]
		[field: CompilerGenerated]
		[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
		public int Items
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[FirestoreProperty("gears")]
		[field: CompilerGenerated]
		[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
		public int Gears
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[FirestoreProperty("moves")]
		[field: CompilerGenerated]
		[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
		public int Moves
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[FirestoreProperty("talents")]
		[field: CompilerGenerated]
		[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
		public int Talents
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[FirestoreProperty("quests")]
		[field: CompilerGenerated]
		[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
		public int Quests
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetRemoteVersionsAsync_003Ed__81 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<StaticDataVersionsDTO> _003C_003Et__builder;

		public StaticDataCacheService _003C_003E4__this;

		private IDocumentSnapshot<StaticDataVersionsDTO> _003Csnapshot_003E5__1;

		private IDocumentSnapshot<StaticDataVersionsDTO> _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<IDocumentSnapshot<StaticDataVersionsDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			StaticDataVersionsDTO result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IDocumentSnapshot<StaticDataVersionsDTO>> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._firestore.GetDocument("config/staticDataVersions").GetDocumentSnapshotAsync<StaticDataVersionsDTO>((Source)0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetRemoteVersionsAsync_003Ed__81 _003CGetRemoteVersionsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<StaticDataVersionsDTO>>, _003CGetRemoteVersionsAsync_003Ed__81>(ref awaiter, ref _003CGetRemoteVersionsAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<StaticDataVersionsDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter.GetResult();
					_003Csnapshot_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					FirestoreReadCounter.Track("config/staticDataVersions");
					result = _003Csnapshot_003E5__1?.Data;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("Could not read static data versions from Firestore: " + _003Cex_003E5__3.Message);
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
	private sealed class _003CLoadGearsAsync_003Ed__75 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public int remoteVersion;

		public StaticDataCacheService _003C_003E4__this;

		private int _003Ccached_003E5__1;

		private Dictionary<string, Item> _003Cgears_003E5__2;

		private Dictionary<string, Item> _003C_003Es__3;

		private bool _003C_003Es__4;

		private TaskAwaiter<Dictionary<string, Item>?> _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private TaskAwaiter _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_021b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				TaskAwaiter<Dictionary<string, Item>> awaiter3;
				TaskAwaiter<bool> awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					_003Ccached_003E5__1 = _003C_003E4__this._preferences.Get("static_version_gears", -1);
					if (remoteVersion > 0 && remoteVersion == _003Ccached_003E5__1)
					{
						awaiter3 = _003C_003E4__this._sqliteCache.ReadCollectionAsync<Item>("gears").GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CLoadGearsAsync_003Ed__75 _003CLoadGearsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Dictionary<string, Item>>, _003CLoadGearsAsync_003Ed__75>(ref awaiter3, ref _003CLoadGearsAsync_003Ed__);
							return;
						}
						goto IL_00d1;
					}
					goto IL_0122;
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Dictionary<string, Item>>);
					num = (_003C_003E1__state = -1);
					goto IL_00d1;
				case 1:
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_0194;
				case 2:
					{
						awaiter = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_00d1:
					_003C_003Es__3 = awaiter3.GetResult();
					_003Cgears_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (_003Cgears_003E5__2 == null)
					{
						_003Cgears_003E5__2 = null;
						goto IL_0122;
					}
					_003C_003E4__this.Gears = _003Cgears_003E5__2;
					result = true;
					goto end_IL_0007;
					IL_0122:
					_003C_003E4__this.Gears = new Dictionary<string, Item>();
					awaiter2 = _003C_003E4__this.LoadStaticGearDataAsync().GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter2;
						_003CLoadGearsAsync_003Ed__75 _003CLoadGearsAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CLoadGearsAsync_003Ed__75>(ref awaiter2, ref _003CLoadGearsAsync_003Ed__);
						return;
					}
					goto IL_0194;
					IL_0194:
					_003C_003Es__4 = awaiter2.GetResult();
					if (_003C_003Es__4)
					{
						awaiter = _003C_003E4__this._sqliteCache.WriteCollectionAsync<Item>("gears", _003C_003E4__this.Gears).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__3 = awaiter;
							_003CLoadGearsAsync_003Ed__75 _003CLoadGearsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadGearsAsync_003Ed__75>(ref awaiter, ref _003CLoadGearsAsync_003Ed__);
							return;
						}
						break;
					}
					result = false;
					goto end_IL_0007;
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003C_003E4__this._preferences.Set("static_version_gears", remoteVersion);
				result = true;
				end_IL_0007:;
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
	private sealed class _003CLoadItemsAsync_003Ed__74 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public int remoteVersion;

		public StaticDataCacheService _003C_003E4__this;

		private int _003Ccached_003E5__1;

		private Dictionary<string, Item> _003Citems_003E5__2;

		private Dictionary<string, Item> _003C_003Es__3;

		private bool _003C_003Es__4;

		private TaskAwaiter<Dictionary<string, Item>?> _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private TaskAwaiter _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_021b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				TaskAwaiter<Dictionary<string, Item>> awaiter3;
				TaskAwaiter<bool> awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					_003Ccached_003E5__1 = _003C_003E4__this._preferences.Get("static_version_items", -1);
					if (remoteVersion > 0 && remoteVersion == _003Ccached_003E5__1)
					{
						awaiter3 = _003C_003E4__this._sqliteCache.ReadCollectionAsync<Item>("items").GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CLoadItemsAsync_003Ed__74 _003CLoadItemsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Dictionary<string, Item>>, _003CLoadItemsAsync_003Ed__74>(ref awaiter3, ref _003CLoadItemsAsync_003Ed__);
							return;
						}
						goto IL_00d1;
					}
					goto IL_0122;
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Dictionary<string, Item>>);
					num = (_003C_003E1__state = -1);
					goto IL_00d1;
				case 1:
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_0194;
				case 2:
					{
						awaiter = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_00d1:
					_003C_003Es__3 = awaiter3.GetResult();
					_003Citems_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (_003Citems_003E5__2 == null)
					{
						_003Citems_003E5__2 = null;
						goto IL_0122;
					}
					_003C_003E4__this.Items = _003Citems_003E5__2;
					result = true;
					goto end_IL_0007;
					IL_0122:
					_003C_003E4__this.Items = new Dictionary<string, Item>();
					awaiter2 = _003C_003E4__this.LoadStaticItemDataAsync().GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter2;
						_003CLoadItemsAsync_003Ed__74 _003CLoadItemsAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CLoadItemsAsync_003Ed__74>(ref awaiter2, ref _003CLoadItemsAsync_003Ed__);
						return;
					}
					goto IL_0194;
					IL_0194:
					_003C_003Es__4 = awaiter2.GetResult();
					if (_003C_003Es__4)
					{
						awaiter = _003C_003E4__this._sqliteCache.WriteCollectionAsync<Item>("items", _003C_003E4__this.Items).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__3 = awaiter;
							_003CLoadItemsAsync_003Ed__74 _003CLoadItemsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadItemsAsync_003Ed__74>(ref awaiter, ref _003CLoadItemsAsync_003Ed__);
							return;
						}
						break;
					}
					result = false;
					goto end_IL_0007;
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003C_003E4__this._preferences.Set("static_version_items", remoteVersion);
				result = true;
				end_IL_0007:;
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
	private sealed class _003CLoadMovesAsync_003Ed__76 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public int remoteVersion;

		public StaticDataCacheService _003C_003E4__this;

		private int _003Ccached_003E5__1;

		private Dictionary<string, Move> _003Cmoves_003E5__2;

		private Dictionary<string, Move> _003C_003Es__3;

		private bool _003C_003Es__4;

		private TaskAwaiter<Dictionary<string, Move>?> _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private TaskAwaiter _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_021b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				TaskAwaiter<Dictionary<string, Move>> awaiter3;
				TaskAwaiter<bool> awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					_003Ccached_003E5__1 = _003C_003E4__this._preferences.Get("static_version_moves", -1);
					if (remoteVersion > 0 && remoteVersion == _003Ccached_003E5__1)
					{
						awaiter3 = _003C_003E4__this._sqliteCache.ReadCollectionAsync<Move>("moves").GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CLoadMovesAsync_003Ed__76 _003CLoadMovesAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Dictionary<string, Move>>, _003CLoadMovesAsync_003Ed__76>(ref awaiter3, ref _003CLoadMovesAsync_003Ed__);
							return;
						}
						goto IL_00d1;
					}
					goto IL_0122;
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Dictionary<string, Move>>);
					num = (_003C_003E1__state = -1);
					goto IL_00d1;
				case 1:
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_0194;
				case 2:
					{
						awaiter = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_00d1:
					_003C_003Es__3 = awaiter3.GetResult();
					_003Cmoves_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (_003Cmoves_003E5__2 == null)
					{
						_003Cmoves_003E5__2 = null;
						goto IL_0122;
					}
					_003C_003E4__this.Moves = _003Cmoves_003E5__2;
					result = true;
					goto end_IL_0007;
					IL_0122:
					_003C_003E4__this.Moves = new Dictionary<string, Move>();
					awaiter2 = _003C_003E4__this.LoadStaticMovesAsync().GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter2;
						_003CLoadMovesAsync_003Ed__76 _003CLoadMovesAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CLoadMovesAsync_003Ed__76>(ref awaiter2, ref _003CLoadMovesAsync_003Ed__);
						return;
					}
					goto IL_0194;
					IL_0194:
					_003C_003Es__4 = awaiter2.GetResult();
					if (_003C_003Es__4)
					{
						awaiter = _003C_003E4__this._sqliteCache.WriteCollectionAsync<Move>("moves", _003C_003E4__this.Moves).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__3 = awaiter;
							_003CLoadMovesAsync_003Ed__76 _003CLoadMovesAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadMovesAsync_003Ed__76>(ref awaiter, ref _003CLoadMovesAsync_003Ed__);
							return;
						}
						break;
					}
					result = false;
					goto end_IL_0007;
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003C_003E4__this._preferences.Set("static_version_moves", remoteVersion);
				result = true;
				end_IL_0007:;
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
	private sealed class _003CLoadQuestsAsync_003Ed__78 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public int remoteVersion;

		public StaticDataCacheService _003C_003E4__this;

		private int _003Ccached_003E5__1;

		private Dictionary<string, Quest> _003Cquests_003E5__2;

		private Dictionary<string, List<Area>> _003Careas_003E5__3;

		private Dictionary<string, List<StaticDataSqliteCache.CachedQuestTask>> _003CcachedTasks_003E5__4;

		private Dictionary<string, Quest> _003C_003Es__5;

		private Dictionary<string, List<Area>> _003C_003Es__6;

		private Dictionary<string, List<StaticDataSqliteCache.CachedQuestTask>> _003C_003Es__7;

		private bool _003C_003Es__8;

		private TaskAwaiter<Dictionary<string, Quest>?> _003C_003Eu__1;

		private TaskAwaiter<Dictionary<string, List<Area>>?> _003C_003Eu__2;

		private TaskAwaiter<Dictionary<string, List<StaticDataSqliteCache.CachedQuestTask>>?> _003C_003Eu__3;

		private TaskAwaiter<bool> _003C_003Eu__4;

		private TaskAwaiter _003C_003Eu__5;

		private void MoveNext()
		{
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0329: Unknown result type (might be due to invalid IL or missing references)
			//IL_032e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0336: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_0440: Unknown result type (might be due to invalid IL or missing references)
			//IL_0445: Unknown result type (might be due to invalid IL or missing references)
			//IL_044d: Unknown result type (might be due to invalid IL or missing references)
			//IL_04cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_0406: Unknown result type (might be due to invalid IL or missing references)
			//IL_040b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0494: Unknown result type (might be due to invalid IL or missing references)
			//IL_0499: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0388: Unknown result type (might be due to invalid IL or missing references)
			//IL_038d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0420: Unknown result type (might be due to invalid IL or missing references)
			//IL_0422: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0309: Unknown result type (might be due to invalid IL or missing references)
			//IL_030b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				TaskAwaiter<Dictionary<string, Quest>> awaiter7;
				TaskAwaiter<Dictionary<string, List<Area>>> awaiter6;
				TaskAwaiter<Dictionary<string, List<StaticDataSqliteCache.CachedQuestTask>>> awaiter5;
				TaskAwaiter<bool> awaiter4;
				TaskAwaiter awaiter3;
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					_003Ccached_003E5__1 = _003C_003E4__this._preferences.Get("static_version_quests", -1);
					if (remoteVersion > 0 && remoteVersion == _003Ccached_003E5__1)
					{
						awaiter7 = _003C_003E4__this._sqliteCache.ReadCollectionAsync<Quest>("quests").GetAwaiter();
						if (!awaiter7.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter7;
							_003CLoadQuestsAsync_003Ed__78 _003CLoadQuestsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Dictionary<string, Quest>>, _003CLoadQuestsAsync_003Ed__78>(ref awaiter7, ref _003CLoadQuestsAsync_003Ed__);
							return;
						}
						goto IL_00f5;
					}
					goto IL_02b1;
				case 0:
					awaiter7 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Dictionary<string, Quest>>);
					num = (_003C_003E1__state = -1);
					goto IL_00f5;
				case 1:
					awaiter6 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<Dictionary<string, List<Area>>>);
					num = (_003C_003E1__state = -1);
					goto IL_0180;
				case 2:
					awaiter5 = _003C_003Eu__3;
					_003C_003Eu__3 = default(TaskAwaiter<Dictionary<string, List<StaticDataSqliteCache.CachedQuestTask>>>);
					num = (_003C_003E1__state = -1);
					goto IL_020b;
				case 3:
					awaiter4 = _003C_003Eu__4;
					_003C_003Eu__4 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_0345;
				case 4:
					awaiter3 = _003C_003Eu__5;
					_003C_003Eu__5 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_03de;
				case 5:
					awaiter2 = _003C_003Eu__5;
					_003C_003Eu__5 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_045c;
				case 6:
					{
						awaiter = _003C_003Eu__5;
						_003C_003Eu__5 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_020b:
					_003C_003Es__7 = awaiter5.GetResult();
					_003CcachedTasks_003E5__4 = _003C_003Es__7;
					_003C_003Es__7 = null;
					if (_003Cquests_003E5__2 == null || _003Careas_003E5__3 == null || _003CcachedTasks_003E5__4 == null)
					{
						_003Cquests_003E5__2 = null;
						_003Careas_003E5__3 = null;
						_003CcachedTasks_003E5__4 = null;
						goto IL_02b1;
					}
					_003C_003E4__this.Quests = _003Cquests_003E5__2;
					_003C_003E4__this.AreasByQuest = _003Careas_003E5__3;
					_003C_003E4__this.TasksByArea = _003C_003E4__this._sqliteCache.ToQuestTasksByArea(_003CcachedTasks_003E5__4);
					result = true;
					goto end_IL_0007;
					IL_03de:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					awaiter2 = _003C_003E4__this._sqliteCache.WriteListCollectionAsync<Area>("areasByQuest", _003C_003E4__this.AreasByQuest).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 5);
						_003C_003Eu__5 = awaiter2;
						_003CLoadQuestsAsync_003Ed__78 _003CLoadQuestsAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadQuestsAsync_003Ed__78>(ref awaiter2, ref _003CLoadQuestsAsync_003Ed__);
						return;
					}
					goto IL_045c;
					IL_0345:
					_003C_003Es__8 = awaiter4.GetResult();
					if (_003C_003Es__8)
					{
						awaiter3 = _003C_003E4__this._sqliteCache.WriteCollectionAsync<Quest>("quests", _003C_003E4__this.Quests).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 4);
							_003C_003Eu__5 = awaiter3;
							_003CLoadQuestsAsync_003Ed__78 _003CLoadQuestsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadQuestsAsync_003Ed__78>(ref awaiter3, ref _003CLoadQuestsAsync_003Ed__);
							return;
						}
						goto IL_03de;
					}
					result = false;
					goto end_IL_0007;
					IL_00f5:
					_003C_003Es__5 = awaiter7.GetResult();
					_003Cquests_003E5__2 = _003C_003Es__5;
					_003C_003Es__5 = null;
					awaiter6 = _003C_003E4__this._sqliteCache.ReadListCollectionAsync<Area>("areasByQuest").GetAwaiter();
					if (!awaiter6.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter6;
						_003CLoadQuestsAsync_003Ed__78 _003CLoadQuestsAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Dictionary<string, List<Area>>>, _003CLoadQuestsAsync_003Ed__78>(ref awaiter6, ref _003CLoadQuestsAsync_003Ed__);
						return;
					}
					goto IL_0180;
					IL_045c:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					awaiter = _003C_003E4__this._sqliteCache.WriteListCollectionAsync<StaticDataSqliteCache.CachedQuestTask>("tasksByArea", _003C_003E4__this._sqliteCache.ToCachedTasksByArea(_003C_003E4__this.TasksByArea)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 6);
						_003C_003Eu__5 = awaiter;
						_003CLoadQuestsAsync_003Ed__78 _003CLoadQuestsAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadQuestsAsync_003Ed__78>(ref awaiter, ref _003CLoadQuestsAsync_003Ed__);
						return;
					}
					break;
					IL_0180:
					_003C_003Es__6 = awaiter6.GetResult();
					_003Careas_003E5__3 = _003C_003Es__6;
					_003C_003Es__6 = null;
					awaiter5 = _003C_003E4__this._sqliteCache.ReadListCollectionAsync<StaticDataSqliteCache.CachedQuestTask>("tasksByArea").GetAwaiter();
					if (!awaiter5.IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__3 = awaiter5;
						_003CLoadQuestsAsync_003Ed__78 _003CLoadQuestsAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Dictionary<string, List<StaticDataSqliteCache.CachedQuestTask>>>, _003CLoadQuestsAsync_003Ed__78>(ref awaiter5, ref _003CLoadQuestsAsync_003Ed__);
						return;
					}
					goto IL_020b;
					IL_02b1:
					_003C_003E4__this.Quests = new Dictionary<string, Quest>();
					_003C_003E4__this.AreasByQuest = new Dictionary<string, List<Area>>();
					_003C_003E4__this.TasksByArea = new Dictionary<string, List<QuestTask>>();
					awaiter4 = _003C_003E4__this.LoadStaticQuestDataAsync().GetAwaiter();
					if (!awaiter4.IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__4 = awaiter4;
						_003CLoadQuestsAsync_003Ed__78 _003CLoadQuestsAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CLoadQuestsAsync_003Ed__78>(ref awaiter4, ref _003CLoadQuestsAsync_003Ed__);
						return;
					}
					goto IL_0345;
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003C_003E4__this._preferences.Set("static_version_quests", remoteVersion);
				result = true;
				end_IL_0007:;
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
	private sealed class _003CLoadSpiritsAsync_003Ed__73 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public int remoteVersion;

		public StaticDataCacheService _003C_003E4__this;

		private int _003Ccached_003E5__1;

		private Dictionary<string, Spirit> _003Cspirits_003E5__2;

		private Dictionary<string, Spirit> _003C_003Es__3;

		private bool _003C_003Es__4;

		private TaskAwaiter<Dictionary<string, Spirit>?> _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private TaskAwaiter _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_021b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				TaskAwaiter<Dictionary<string, Spirit>> awaiter3;
				TaskAwaiter<bool> awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					_003Ccached_003E5__1 = _003C_003E4__this._preferences.Get("static_version_spirits", -1);
					if (remoteVersion > 0 && remoteVersion == _003Ccached_003E5__1)
					{
						awaiter3 = _003C_003E4__this._sqliteCache.ReadCollectionAsync<Spirit>("spirits").GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CLoadSpiritsAsync_003Ed__73 _003CLoadSpiritsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Dictionary<string, Spirit>>, _003CLoadSpiritsAsync_003Ed__73>(ref awaiter3, ref _003CLoadSpiritsAsync_003Ed__);
							return;
						}
						goto IL_00d1;
					}
					goto IL_0122;
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Dictionary<string, Spirit>>);
					num = (_003C_003E1__state = -1);
					goto IL_00d1;
				case 1:
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_0194;
				case 2:
					{
						awaiter = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_00d1:
					_003C_003Es__3 = awaiter3.GetResult();
					_003Cspirits_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (_003Cspirits_003E5__2 == null)
					{
						_003Cspirits_003E5__2 = null;
						goto IL_0122;
					}
					_003C_003E4__this.Spirits = _003Cspirits_003E5__2;
					result = true;
					goto end_IL_0007;
					IL_0122:
					_003C_003E4__this.Spirits = new Dictionary<string, Spirit>();
					awaiter2 = _003C_003E4__this.LoadStaticSpiritsAsync().GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter2;
						_003CLoadSpiritsAsync_003Ed__73 _003CLoadSpiritsAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CLoadSpiritsAsync_003Ed__73>(ref awaiter2, ref _003CLoadSpiritsAsync_003Ed__);
						return;
					}
					goto IL_0194;
					IL_0194:
					_003C_003Es__4 = awaiter2.GetResult();
					if (_003C_003Es__4)
					{
						awaiter = _003C_003E4__this._sqliteCache.WriteCollectionAsync<Spirit>("spirits", _003C_003E4__this.Spirits).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__3 = awaiter;
							_003CLoadSpiritsAsync_003Ed__73 _003CLoadSpiritsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadSpiritsAsync_003Ed__73>(ref awaiter, ref _003CLoadSpiritsAsync_003Ed__);
							return;
						}
						break;
					}
					result = false;
					goto end_IL_0007;
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003C_003E4__this._preferences.Set("static_version_spirits", remoteVersion);
				result = true;
				end_IL_0007:;
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
	private sealed class _003CLoadStaticDataAsync_003Ed__72 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public StaticDataCacheService _003C_003E4__this;

		private StaticDataVersionsDTO _003Cremote_003E5__1;

		private bool[] _003Cresults_003E5__2;

		private StaticDataVersionsDTO _003C_003Es__3;

		private bool _003C_003Es__4;

		private bool[] _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<StaticDataVersionsDTO?> _003C_003Eu__2;

		private TaskAwaiter<bool> _003C_003Eu__3;

		private TaskAwaiter<bool[]> _003C_003Eu__4;

		private void MoveNext()
		{
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_027c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0281: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_016f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0296: Unknown result type (might be due to invalid IL or missing references)
			//IL_0298: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if ((uint)num > 3u)
				{
				}
				try
				{
					TaskAwaiter awaiter4;
					TaskAwaiter<StaticDataVersionsDTO> awaiter3;
					TaskAwaiter<bool> awaiter2;
					TaskAwaiter<bool[]> awaiter;
					switch (num)
					{
					default:
						awaiter4 = _003C_003E4__this._sqliteCache.InitializeAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter4;
							_003CLoadStaticDataAsync_003Ed__72 _003CLoadStaticDataAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadStaticDataAsync_003Ed__72>(ref awaiter4, ref _003CLoadStaticDataAsync_003Ed__);
							return;
						}
						goto IL_009e;
					case 0:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_009e;
					case 1:
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<StaticDataVersionsDTO>);
						num = (_003C_003E1__state = -1);
						goto IL_0107;
					case 2:
						awaiter2 = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_01a9;
					case 3:
						{
							awaiter = _003C_003Eu__4;
							_003C_003Eu__4 = default(TaskAwaiter<bool[]>);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_0107:
						_003C_003Es__3 = awaiter3.GetResult();
						_003Cremote_003E5__1 = _003C_003Es__3;
						_003C_003Es__3 = null;
						if (_003Cremote_003E5__1 != null)
						{
							awaiter2 = _003C_003E4__this.LoadMovesAsync(_003Cremote_003E5__1.Moves).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter2;
								_003CLoadStaticDataAsync_003Ed__72 _003CLoadStaticDataAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CLoadStaticDataAsync_003Ed__72>(ref awaiter2, ref _003CLoadStaticDataAsync_003Ed__);
								return;
							}
							goto IL_01a9;
						}
						result = false;
						goto end_IL_0011;
						IL_009e:
						((TaskAwaiter)(ref awaiter4)).GetResult();
						awaiter3 = _003C_003E4__this.GetRemoteVersionsAsync().GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter3;
							_003CLoadStaticDataAsync_003Ed__72 _003CLoadStaticDataAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<StaticDataVersionsDTO>, _003CLoadStaticDataAsync_003Ed__72>(ref awaiter3, ref _003CLoadStaticDataAsync_003Ed__);
							return;
						}
						goto IL_0107;
						IL_01a9:
						_003C_003Es__4 = awaiter2.GetResult();
						if (_003C_003Es__4)
						{
							_003C_003Ey__InlineArray5<global::System.Threading.Tasks.Task<bool>> buffer = default(_003C_003Ey__InlineArray5<global::System.Threading.Tasks.Task<bool>>);
							_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 0) = _003C_003E4__this.LoadSpiritsAsync(_003Cremote_003E5__1.Spirits);
							_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 1) = _003C_003E4__this.LoadItemsAsync(_003Cremote_003E5__1.Items);
							_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 2) = _003C_003E4__this.LoadGearsAsync(_003Cremote_003E5__1.Gears);
							_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 3) = _003C_003E4__this.LoadTalentsAsync(_003Cremote_003E5__1.Talents);
							_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 4) = _003C_003E4__this.LoadQuestsAsync(_003Cremote_003E5__1.Quests);
							awaiter = global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray5<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer, 5)).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__4 = awaiter;
								_003CLoadStaticDataAsync_003Ed__72 _003CLoadStaticDataAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003CLoadStaticDataAsync_003Ed__72>(ref awaiter, ref _003CLoadStaticDataAsync_003Ed__);
								return;
							}
							break;
						}
						result = false;
						goto end_IL_0011;
					}
					_003C_003Es__5 = awaiter.GetResult();
					_003Cresults_003E5__2 = _003C_003Es__5;
					_003C_003Es__5 = null;
					if (!Enumerable.All<bool>((global::System.Collections.Generic.IEnumerable<bool>)_003Cresults_003E5__2, (Func<bool, bool>)((bool r) => r)))
					{
						result = false;
					}
					else
					{
						_003C_003E4__this.ResolveTaskItemRewards();
						FirestoreReadCounter.LogSummary();
						_003C_003E4__this.StartVersionListener();
						result = true;
					}
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__6 = ex;
					Console.WriteLine("Error loading static data: " + _003Cex_003E5__6.Message);
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
	private sealed class _003CLoadStaticGearDataAsync_003Ed__85 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public StaticDataCacheService _003C_003E4__this;

		private ICollectionReference _003CitemsCollection_003E5__1;

		private IQuerySnapshot<FirestoreItemDTO> _003CitemsSnapshot_003E5__2;

		private IQuerySnapshot<FirestoreItemDTO> _003C_003Es__3;

		private global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreItemDTO>> _003C_003Es__4;

		private IDocumentSnapshot<FirestoreItemDTO> _003Cdoc_003E5__5;

		private FirestoreItemDTO _003Citem_003E5__6;

		private string _003CitemId_003E5__7;

		private global::System.Exception _003Cex_003E5__8;

		private TaskAwaiter<IQuerySnapshot<FirestoreItemDTO>> _003C_003Eu__1;

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
			bool result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestoreItemDTO>> awaiter;
					if (num != 0)
					{
						_003CitemsCollection_003E5__1 = _003C_003E4__this._firestore.GetCollection("gears");
						awaiter = ((IQuery)_003CitemsCollection_003E5__1).GetDocumentsAsync<FirestoreItemDTO>((Source)0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadStaticGearDataAsync_003Ed__85 _003CLoadStaticGearDataAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreItemDTO>>, _003CLoadStaticGearDataAsync_003Ed__85>(ref awaiter, ref _003CLoadStaticGearDataAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreItemDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter.GetResult();
					_003CitemsSnapshot_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					FirestoreReadCounter.Track("gears", Enumerable.Count<IDocumentSnapshot<FirestoreItemDTO>>(_003CitemsSnapshot_003E5__2.Documents));
					_003C_003Es__4 = _003CitemsSnapshot_003E5__2.Documents.GetEnumerator();
					try
					{
						while (((global::System.Collections.IEnumerator)_003C_003Es__4).MoveNext())
						{
							_003Cdoc_003E5__5 = _003C_003Es__4.Current;
							Console.WriteLine("Loading gear " + _003Cdoc_003E5__5.Reference.Id);
							_003Citem_003E5__6 = _003Cdoc_003E5__5.Data;
							_003CitemId_003E5__7 = _003Cdoc_003E5__5.Reference.Id;
							_003C_003E4__this.Gears[_003CitemId_003E5__7] = ItemEntityMapper.ToEntity(_003Citem_003E5__6);
							_003Citem_003E5__6 = null;
							_003CitemId_003E5__7 = null;
							_003Cdoc_003E5__5 = null;
						}
					}
					finally
					{
						if (num < 0 && _003C_003Es__4 != null)
						{
							((global::System.IDisposable)_003C_003Es__4).Dispose();
						}
					}
					_003C_003Es__4 = null;
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__8 = ex;
					Console.WriteLine("Error loading static items data: " + _003Cex_003E5__8.Message);
					Console.WriteLine(_003Cex_003E5__8.StackTrace);
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
	private sealed class _003CLoadStaticItemDataAsync_003Ed__86 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public StaticDataCacheService _003C_003E4__this;

		private ICollectionReference _003CitemsCollection_003E5__1;

		private IQuerySnapshot<FirestoreItemDTO> _003CitemsSnapshot_003E5__2;

		private IQuerySnapshot<FirestoreItemDTO> _003C_003Es__3;

		private global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreItemDTO>> _003C_003Es__4;

		private IDocumentSnapshot<FirestoreItemDTO> _003Cdoc_003E5__5;

		private FirestoreItemDTO _003Citem_003E5__6;

		private string _003CitemId_003E5__7;

		private global::System.Exception _003Cex_003E5__8;

		private TaskAwaiter<IQuerySnapshot<FirestoreItemDTO>> _003C_003Eu__1;

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
			bool result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestoreItemDTO>> awaiter;
					if (num != 0)
					{
						_003CitemsCollection_003E5__1 = _003C_003E4__this._firestore.GetCollection("items");
						awaiter = ((IQuery)_003CitemsCollection_003E5__1).GetDocumentsAsync<FirestoreItemDTO>((Source)0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadStaticItemDataAsync_003Ed__86 _003CLoadStaticItemDataAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreItemDTO>>, _003CLoadStaticItemDataAsync_003Ed__86>(ref awaiter, ref _003CLoadStaticItemDataAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreItemDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter.GetResult();
					_003CitemsSnapshot_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					FirestoreReadCounter.Track("items", Enumerable.Count<IDocumentSnapshot<FirestoreItemDTO>>(_003CitemsSnapshot_003E5__2.Documents));
					_003C_003Es__4 = _003CitemsSnapshot_003E5__2.Documents.GetEnumerator();
					try
					{
						while (((global::System.Collections.IEnumerator)_003C_003Es__4).MoveNext())
						{
							_003Cdoc_003E5__5 = _003C_003Es__4.Current;
							_003Citem_003E5__6 = _003Cdoc_003E5__5.Data;
							_003CitemId_003E5__7 = _003Cdoc_003E5__5.Reference.Id;
							_003C_003E4__this.Items[_003CitemId_003E5__7] = ItemEntityMapper.ToEntity(_003Citem_003E5__6);
							_003Citem_003E5__6 = null;
							_003CitemId_003E5__7 = null;
							_003Cdoc_003E5__5 = null;
						}
					}
					finally
					{
						if (num < 0 && _003C_003Es__4 != null)
						{
							((global::System.IDisposable)_003C_003Es__4).Dispose();
						}
					}
					_003C_003Es__4 = null;
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__8 = ex;
					Console.WriteLine("Error loading static items data: " + _003Cex_003E5__8.Message);
					Console.WriteLine(_003Cex_003E5__8.StackTrace);
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
	private sealed class _003CLoadStaticMovesAsync_003Ed__88 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public StaticDataCacheService _003C_003E4__this;

		private ICollectionReference _003CmovesCollection_003E5__1;

		private IQuerySnapshot<FirestoreMoveDTO> _003CmovesSnapshot_003E5__2;

		private IQuerySnapshot<FirestoreMoveDTO> _003C_003Es__3;

		private global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreMoveDTO>> _003C_003Es__4;

		private IDocumentSnapshot<FirestoreMoveDTO> _003Cdoc_003E5__5;

		private FirestoreMoveDTO _003Cmove_003E5__6;

		private string _003CmoveId_003E5__7;

		private global::System.Exception _003Cex_003E5__8;

		private TaskAwaiter<IQuerySnapshot<FirestoreMoveDTO>> _003C_003Eu__1;

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
			bool result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestoreMoveDTO>> awaiter;
					if (num != 0)
					{
						_003CmovesCollection_003E5__1 = _003C_003E4__this._firestore.GetCollection("moves");
						awaiter = ((IQuery)_003CmovesCollection_003E5__1).GetDocumentsAsync<FirestoreMoveDTO>((Source)0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadStaticMovesAsync_003Ed__88 _003CLoadStaticMovesAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreMoveDTO>>, _003CLoadStaticMovesAsync_003Ed__88>(ref awaiter, ref _003CLoadStaticMovesAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreMoveDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter.GetResult();
					_003CmovesSnapshot_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					FirestoreReadCounter.Track("moves", Enumerable.Count<IDocumentSnapshot<FirestoreMoveDTO>>(_003CmovesSnapshot_003E5__2.Documents));
					_003C_003Es__4 = _003CmovesSnapshot_003E5__2.Documents.GetEnumerator();
					try
					{
						while (((global::System.Collections.IEnumerator)_003C_003Es__4).MoveNext())
						{
							_003Cdoc_003E5__5 = _003C_003Es__4.Current;
							_003Cmove_003E5__6 = _003Cdoc_003E5__5.Data;
							_003CmoveId_003E5__7 = _003Cdoc_003E5__5.Reference.Id;
							_003C_003E4__this.Moves[_003CmoveId_003E5__7] = MoveEntityMapper.ToEntity(_003Cmove_003E5__6);
							_003Cmove_003E5__6 = null;
							_003CmoveId_003E5__7 = null;
							_003Cdoc_003E5__5 = null;
						}
					}
					finally
					{
						if (num < 0 && _003C_003Es__4 != null)
						{
							((global::System.IDisposable)_003C_003Es__4).Dispose();
						}
					}
					_003C_003Es__4 = null;
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__8 = ex;
					Console.WriteLine("Error loading static moves data: " + _003Cex_003E5__8.Message);
					Console.WriteLine(_003Cex_003E5__8.StackTrace);
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
	private sealed class _003CLoadStaticQuestDataAsync_003Ed__82 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public StaticDataCacheService _003C_003E4__this;

		private Stopwatch _003Csw_003E5__1;

		private ICollectionReference _003CquestsCollection_003E5__2;

		private IQuerySnapshot<FirestoreQuestDTO> _003CquestsSnapshot_003E5__3;

		private IQuerySnapshot<FirestoreQuestDTO> _003C_003Es__4;

		private global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreQuestDTO>> _003C_003Es__5;

		private IDocumentSnapshot<FirestoreQuestDTO> _003Cdoc_003E5__6;

		private FirestoreQuestDTO _003Cquest_003E5__7;

		private string _003CquestId_003E5__8;

		private ICollectionReference _003CareasCollection_003E5__9;

		private IQuerySnapshot<FirestoreAreasDTO> _003CareasSnapshot_003E5__10;

		private List<FirestoreAreasDTO> _003CareasList_003E5__11;

		private IQuerySnapshot<FirestoreAreasDTO> _003C_003Es__12;

		private global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreAreasDTO>> _003C_003Es__13;

		private IDocumentSnapshot<FirestoreAreasDTO> _003CareaDoc_003E5__14;

		private FirestoreAreasDTO _003Carea_003E5__15;

		private string _003CareaId_003E5__16;

		private ICollectionReference _003CtasksCollection_003E5__17;

		private IQuerySnapshot<FirestoreTaskDTO> _003CtasksSnapshot_003E5__18;

		private List<FirestoreTaskDTO> _003CtasksList_003E5__19;

		private IQuerySnapshot<FirestoreTaskDTO> _003C_003Es__20;

		private global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreTaskDTO>> _003C_003Es__21;

		private IDocumentSnapshot<FirestoreTaskDTO> _003CtaskDoc_003E5__22;

		private FirestoreTaskDTO _003CtaskData_003E5__23;

		private global::System.Exception _003Cex_003E5__24;

		private TaskAwaiter<IQuerySnapshot<FirestoreQuestDTO>> _003C_003Eu__1;

		private TaskAwaiter<IQuerySnapshot<FirestoreAreasDTO>> _003C_003Eu__2;

		private TaskAwaiter<IQuerySnapshot<FirestoreTaskDTO>> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0206: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0422: Unknown result type (might be due to invalid IL or missing references)
			//IL_0427: Unknown result type (might be due to invalid IL or missing references)
			//IL_042f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01da: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_0403: Unknown result type (might be due to invalid IL or missing references)
			//IL_0405: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if ((uint)num > 2u)
				{
				}
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestoreQuestDTO>> awaiter;
					if (num != 0)
					{
						if ((uint)(num - 1) <= 1u)
						{
							goto IL_0108;
						}
						_003Csw_003E5__1 = Stopwatch.StartNew();
						_003CquestsCollection_003E5__2 = _003C_003E4__this._firestore.GetCollection("quests");
						awaiter = ((IQuery)_003CquestsCollection_003E5__2).OrderBy("order", false).GetDocumentsAsync<FirestoreQuestDTO>((Source)0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadStaticQuestDataAsync_003Ed__82 _003CLoadStaticQuestDataAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreQuestDTO>>, _003CLoadStaticQuestDataAsync_003Ed__82>(ref awaiter, ref _003CLoadStaticQuestDataAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreQuestDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__4 = awaiter.GetResult();
					_003CquestsSnapshot_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					FirestoreReadCounter.Track("quests", Enumerable.Count<IDocumentSnapshot<FirestoreQuestDTO>>(_003CquestsSnapshot_003E5__3.Documents));
					_003C_003Es__5 = _003CquestsSnapshot_003E5__3.Documents.GetEnumerator();
					goto IL_0108;
					IL_0108:
					try
					{
						if (num != 1)
						{
							if (num != 2)
							{
								goto IL_0651;
							}
							goto IL_0273;
						}
						TaskAwaiter<IQuerySnapshot<FirestoreAreasDTO>> awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<IQuerySnapshot<FirestoreAreasDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_0215;
						IL_0215:
						_003C_003Es__12 = awaiter2.GetResult();
						_003CareasSnapshot_003E5__10 = _003C_003Es__12;
						_003C_003Es__12 = null;
						FirestoreReadCounter.Track("quests/*/areas", Enumerable.Count<IDocumentSnapshot<FirestoreAreasDTO>>(_003CareasSnapshot_003E5__10.Documents));
						_003CareasList_003E5__11 = new List<FirestoreAreasDTO>();
						_003C_003Es__13 = _003CareasSnapshot_003E5__10.Documents.GetEnumerator();
						goto IL_0273;
						IL_0273:
						try
						{
							if (num != 2)
							{
								goto IL_05b2;
							}
							TaskAwaiter<IQuerySnapshot<FirestoreTaskDTO>> awaiter3 = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<IQuerySnapshot<FirestoreTaskDTO>>);
							num = (_003C_003E1__state = -1);
							goto IL_043e;
							IL_043e:
							_003C_003Es__20 = awaiter3.GetResult();
							_003CtasksSnapshot_003E5__18 = _003C_003Es__20;
							_003C_003Es__20 = null;
							FirestoreReadCounter.Track("quests/*/areas/*/tasks", Enumerable.Count<IDocumentSnapshot<FirestoreTaskDTO>>(_003CtasksSnapshot_003E5__18.Documents));
							_003CtasksList_003E5__19 = new List<FirestoreTaskDTO>();
							_003C_003Es__21 = _003CtasksSnapshot_003E5__18.Documents.GetEnumerator();
							try
							{
								while (((global::System.Collections.IEnumerator)_003C_003Es__21).MoveNext())
								{
									_003CtaskDoc_003E5__22 = _003C_003Es__21.Current;
									_003CtaskData_003E5__23 = _003CtaskDoc_003E5__22.Data;
									if (string.IsNullOrEmpty(_003CtaskData_003E5__23.Id))
									{
										_003CtaskData_003E5__23.Id = _003CtaskDoc_003E5__22.Reference.Id;
									}
									_003CtasksList_003E5__19.Add(_003CtaskData_003E5__23);
									_003CtaskData_003E5__23 = null;
									_003CtaskDoc_003E5__22 = null;
								}
							}
							finally
							{
								if (num < 0 && _003C_003Es__21 != null)
								{
									((global::System.IDisposable)_003C_003Es__21).Dispose();
								}
							}
							_003C_003Es__21 = null;
							_003C_003E4__this.TasksByArea[_003CareaId_003E5__16] = Enumerable.ToList<QuestTask>(Enumerable.Select<FirestoreTaskDTO, QuestTask>((global::System.Collections.Generic.IEnumerable<FirestoreTaskDTO>)_003CtasksList_003E5__19, (Func<FirestoreTaskDTO, QuestTask>)QuestEntityMapper.ToEntity));
							_003Carea_003E5__15 = null;
							_003CareaId_003E5__16 = null;
							_003CtasksCollection_003E5__17 = null;
							_003CtasksSnapshot_003E5__18 = null;
							_003CtasksList_003E5__19 = null;
							_003CareaDoc_003E5__14 = null;
							goto IL_05b2;
							IL_05b2:
							if (((global::System.Collections.IEnumerator)_003C_003Es__13).MoveNext())
							{
								_003CareaDoc_003E5__14 = _003C_003Es__13.Current;
								_003Carea_003E5__15 = _003CareaDoc_003E5__14.Data;
								_003CareaId_003E5__16 = _003CareaDoc_003E5__14.Reference.Id;
								if (string.IsNullOrEmpty(_003Carea_003E5__15.Id))
								{
									_003Carea_003E5__15.Id = _003CareaId_003E5__16;
								}
								_003CareasList_003E5__11.Add(_003Carea_003E5__15);
								_003CtasksCollection_003E5__17 = ((_003Carea_003E5__15.Id == "ChallangeFights") ? _003C_003E4__this._firestore.GetCollection($"quests/{_003CquestId_003E5__8}/areas/{_003CareaId_003E5__16}/battles") : _003C_003E4__this._firestore.GetCollection($"quests/{_003CquestId_003E5__8}/areas/{_003CareaId_003E5__16}/tasks"));
								awaiter3 = ((IQuery)_003CtasksCollection_003E5__17).GetDocumentsAsync<FirestoreTaskDTO>((Source)0).GetAwaiter();
								if (!awaiter3.IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__3 = awaiter3;
									_003CLoadStaticQuestDataAsync_003Ed__82 _003CLoadStaticQuestDataAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreTaskDTO>>, _003CLoadStaticQuestDataAsync_003Ed__82>(ref awaiter3, ref _003CLoadStaticQuestDataAsync_003Ed__);
									return;
								}
								goto IL_043e;
							}
						}
						finally
						{
							if (num < 0 && _003C_003Es__13 != null)
							{
								((global::System.IDisposable)_003C_003Es__13).Dispose();
							}
						}
						_003C_003Es__13 = null;
						_003C_003E4__this.AreasByQuest[_003CquestId_003E5__8] = Enumerable.ToList<Area>(Enumerable.Select<FirestoreAreasDTO, Area>((global::System.Collections.Generic.IEnumerable<FirestoreAreasDTO>)_003CareasList_003E5__11, (Func<FirestoreAreasDTO, Area>)QuestEntityMapper.ToEntity));
						_003Cquest_003E5__7 = null;
						_003CquestId_003E5__8 = null;
						_003CareasCollection_003E5__9 = null;
						_003CareasSnapshot_003E5__10 = null;
						_003CareasList_003E5__11 = null;
						_003Cdoc_003E5__6 = null;
						goto IL_0651;
						IL_0651:
						if (((global::System.Collections.IEnumerator)_003C_003Es__5).MoveNext())
						{
							_003Cdoc_003E5__6 = _003C_003Es__5.Current;
							_003Cquest_003E5__7 = _003Cdoc_003E5__6.Data;
							_003CquestId_003E5__8 = _003Cdoc_003E5__6.Reference.Id;
							_003C_003E4__this.Quests[_003CquestId_003E5__8] = QuestEntityMapper.ToEntity(_003Cquest_003E5__7);
							_003CareasCollection_003E5__9 = _003C_003E4__this._firestore.GetCollection("quests/" + _003CquestId_003E5__8 + "/areas");
							awaiter2 = ((IQuery)_003CareasCollection_003E5__9).OrderBy("order", false).GetDocumentsAsync<FirestoreAreasDTO>((Source)0).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter2;
								_003CLoadStaticQuestDataAsync_003Ed__82 _003CLoadStaticQuestDataAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreAreasDTO>>, _003CLoadStaticQuestDataAsync_003Ed__82>(ref awaiter2, ref _003CLoadStaticQuestDataAsync_003Ed__);
								return;
							}
							goto IL_0215;
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
					Console.WriteLine("Loading static quest data completed in " + _003Csw_003E5__1.ElapsedMilliseconds + "ms");
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__24 = ex;
					Console.WriteLine("Error loading static quest data: " + _003Cex_003E5__24.Message);
					Console.WriteLine("Stacktrace: " + _003Cex_003E5__24.StackTrace);
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
	private sealed class _003CLoadStaticSpiritsAsync_003Ed__87 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public StaticDataCacheService _003C_003E4__this;

		private Stopwatch _003Csw_003E5__1;

		private ICollectionReference _003CspiritsCollection_003E5__2;

		private IQuerySnapshot<FirestoreSpiritDTO> _003CspiritsSnapshot_003E5__3;

		private IQuerySnapshot<FirestoreSpiritDTO> _003C_003Es__4;

		private global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreSpiritDTO>> _003C_003Es__5;

		private IDocumentSnapshot<FirestoreSpiritDTO> _003Cdoc_003E5__6;

		private FirestoreSpiritDTO _003Cspirit_003E5__7;

		private string _003CspiritId_003E5__8;

		private global::System.Exception _003Cex_003E5__9;

		private TaskAwaiter<IQuerySnapshot<FirestoreSpiritDTO>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestoreSpiritDTO>> awaiter;
					if (num != 0)
					{
						_003Csw_003E5__1 = Stopwatch.StartNew();
						_003CspiritsCollection_003E5__2 = _003C_003E4__this._firestore.GetCollection("spiritsTemp");
						awaiter = ((IQuery)_003CspiritsCollection_003E5__2).GetDocumentsAsync<FirestoreSpiritDTO>((Source)0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadStaticSpiritsAsync_003Ed__87 _003CLoadStaticSpiritsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreSpiritDTO>>, _003CLoadStaticSpiritsAsync_003Ed__87>(ref awaiter, ref _003CLoadStaticSpiritsAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreSpiritDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__4 = awaiter.GetResult();
					_003CspiritsSnapshot_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					FirestoreReadCounter.Track("spirits", Enumerable.Count<IDocumentSnapshot<FirestoreSpiritDTO>>(_003CspiritsSnapshot_003E5__3.Documents));
					_003C_003Es__5 = _003CspiritsSnapshot_003E5__3.Documents.GetEnumerator();
					try
					{
						while (((global::System.Collections.IEnumerator)_003C_003Es__5).MoveNext())
						{
							_003Cdoc_003E5__6 = _003C_003Es__5.Current;
							_003Cspirit_003E5__7 = _003Cdoc_003E5__6.Data;
							_003CspiritId_003E5__8 = _003Cdoc_003E5__6.Reference.Id;
							_003C_003E4__this.Spirits[_003CspiritId_003E5__8] = SpiritEntityMapper.ToEntity(_003Cspirit_003E5__7, _003C_003E4__this.Moves);
							_003Cspirit_003E5__7 = null;
							_003CspiritId_003E5__8 = null;
							_003Cdoc_003E5__6 = null;
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
					Console.WriteLine("Loading static spirits completed in " + _003Csw_003E5__1.ElapsedMilliseconds + "ms");
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__9 = ex;
					Console.WriteLine("Error loading static spirits data: " + _003Cex_003E5__9.Message);
					Console.WriteLine(_003Cex_003E5__9.StackTrace);
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
	private sealed class _003CLoadStaticTalentAsync_003Ed__84 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public StaticDataCacheService _003C_003E4__this;

		private ICollectionReference _003CitemsCollection_003E5__1;

		private IQuerySnapshot<FirestoreItemDTO> _003CitemsSnapshot_003E5__2;

		private IQuerySnapshot<FirestoreItemDTO> _003C_003Es__3;

		private global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreItemDTO>> _003C_003Es__4;

		private IDocumentSnapshot<FirestoreItemDTO> _003Cdoc_003E5__5;

		private FirestoreItemDTO _003Citem_003E5__6;

		private string _003CitemId_003E5__7;

		private global::System.Exception _003Cex_003E5__8;

		private TaskAwaiter<IQuerySnapshot<FirestoreItemDTO>> _003C_003Eu__1;

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
			bool result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IQuerySnapshot<FirestoreItemDTO>> awaiter;
					if (num != 0)
					{
						_003CitemsCollection_003E5__1 = _003C_003E4__this._firestore.GetCollection("talents");
						awaiter = ((IQuery)_003CitemsCollection_003E5__1).GetDocumentsAsync<FirestoreItemDTO>((Source)0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadStaticTalentAsync_003Ed__84 _003CLoadStaticTalentAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreItemDTO>>, _003CLoadStaticTalentAsync_003Ed__84>(ref awaiter, ref _003CLoadStaticTalentAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreItemDTO>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter.GetResult();
					_003CitemsSnapshot_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					FirestoreReadCounter.Track("talents", Enumerable.Count<IDocumentSnapshot<FirestoreItemDTO>>(_003CitemsSnapshot_003E5__2.Documents));
					_003C_003Es__4 = _003CitemsSnapshot_003E5__2.Documents.GetEnumerator();
					try
					{
						while (((global::System.Collections.IEnumerator)_003C_003Es__4).MoveNext())
						{
							_003Cdoc_003E5__5 = _003C_003Es__4.Current;
							Console.WriteLine("Loading talent " + _003Cdoc_003E5__5.Reference.Id);
							_003Citem_003E5__6 = _003Cdoc_003E5__5.Data;
							_003CitemId_003E5__7 = _003Cdoc_003E5__5.Reference.Id;
							_003C_003E4__this.Talents[_003CitemId_003E5__7] = ItemEntityMapper.ToEntity(_003Citem_003E5__6);
							_003Citem_003E5__6 = null;
							_003CitemId_003E5__7 = null;
							_003Cdoc_003E5__5 = null;
						}
					}
					finally
					{
						if (num < 0 && _003C_003Es__4 != null)
						{
							((global::System.IDisposable)_003C_003Es__4).Dispose();
						}
					}
					_003C_003Es__4 = null;
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__8 = ex;
					Console.WriteLine("Error loading static items data: " + _003Cex_003E5__8.Message);
					Console.WriteLine(_003Cex_003E5__8.StackTrace);
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
	private sealed class _003CLoadTalentsAsync_003Ed__77 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public int remoteVersion;

		public StaticDataCacheService _003C_003E4__this;

		private int _003Ccached_003E5__1;

		private Dictionary<string, Item> _003Ctalents_003E5__2;

		private Dictionary<string, Item> _003C_003Es__3;

		private bool _003C_003Es__4;

		private TaskAwaiter<Dictionary<string, Item>?> _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private TaskAwaiter _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_021b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				TaskAwaiter<Dictionary<string, Item>> awaiter3;
				TaskAwaiter<bool> awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					_003Ccached_003E5__1 = _003C_003E4__this._preferences.Get("static_version_talents", -1);
					if (remoteVersion > 0 && remoteVersion == _003Ccached_003E5__1)
					{
						awaiter3 = _003C_003E4__this._sqliteCache.ReadCollectionAsync<Item>("talents").GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CLoadTalentsAsync_003Ed__77 _003CLoadTalentsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Dictionary<string, Item>>, _003CLoadTalentsAsync_003Ed__77>(ref awaiter3, ref _003CLoadTalentsAsync_003Ed__);
							return;
						}
						goto IL_00d1;
					}
					goto IL_0122;
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Dictionary<string, Item>>);
					num = (_003C_003E1__state = -1);
					goto IL_00d1;
				case 1:
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_0194;
				case 2:
					{
						awaiter = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_00d1:
					_003C_003Es__3 = awaiter3.GetResult();
					_003Ctalents_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (_003Ctalents_003E5__2 == null)
					{
						_003Ctalents_003E5__2 = null;
						goto IL_0122;
					}
					_003C_003E4__this.Talents = _003Ctalents_003E5__2;
					result = true;
					goto end_IL_0007;
					IL_0122:
					_003C_003E4__this.Talents = new Dictionary<string, Item>();
					awaiter2 = _003C_003E4__this.LoadStaticTalentAsync().GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter2;
						_003CLoadTalentsAsync_003Ed__77 _003CLoadTalentsAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CLoadTalentsAsync_003Ed__77>(ref awaiter2, ref _003CLoadTalentsAsync_003Ed__);
						return;
					}
					goto IL_0194;
					IL_0194:
					_003C_003Es__4 = awaiter2.GetResult();
					if (_003C_003Es__4)
					{
						awaiter = _003C_003E4__this._sqliteCache.WriteCollectionAsync<Item>("talents", _003C_003E4__this.Talents).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__3 = awaiter;
							_003CLoadTalentsAsync_003Ed__77 _003CLoadTalentsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadTalentsAsync_003Ed__77>(ref awaiter, ref _003CLoadTalentsAsync_003Ed__);
							return;
						}
						break;
					}
					result = false;
					goto end_IL_0007;
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003C_003E4__this._preferences.Set("static_version_talents", remoteVersion);
				result = true;
				end_IL_0007:;
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
	private sealed class _003COnVersionSnapshot_003Ed__80 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public IDocumentSnapshot<StaticDataVersionsDTO> snapshot;

		public StaticDataCacheService _003C_003E4__this;

		private StaticDataVersionsDTO _003Cremote_003E5__1;

		private bool _003CmovesChanged_003E5__2;

		private bool _003CspiritsChanged_003E5__3;

		private bool _003CitemsChanged_003E5__4;

		private bool _003CgearsChanged_003E5__5;

		private bool _003CtalentsChanged_003E5__6;

		private bool _003CquestsChanged_003E5__7;

		private List<global::System.Threading.Tasks.Task<bool>> _003Ctasks_003E5__8;

		private bool[] _003Cresults_003E5__9;

		private bool _003C_003Es__10;

		private bool _003C_003Es__11;

		private bool _003C_003Es__12;

		private bool[] _003C_003Es__13;

		private global::System.Exception _003Cex_003E5__14;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter<bool[]> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0225: Unknown result type (might be due to invalid IL or missing references)
			//IL_022a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0232: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0205: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Unknown result type (might be due to invalid IL or missing references)
			//IL_0399: Unknown result type (might be due to invalid IL or missing references)
			//IL_039e: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 1u)
				{
					goto IL_019f;
				}
				if (snapshot?.Data != null)
				{
					_003Cremote_003E5__1 = snapshot.Data;
					_003CmovesChanged_003E5__2 = _003Cremote_003E5__1.Moves != _003C_003E4__this._preferences.Get("static_version_moves", -1);
					_003CspiritsChanged_003E5__3 = _003Cremote_003E5__1.Spirits != _003C_003E4__this._preferences.Get("static_version_spirits", -1);
					_003CitemsChanged_003E5__4 = _003Cremote_003E5__1.Items != _003C_003E4__this._preferences.Get("static_version_items", -1);
					_003CgearsChanged_003E5__5 = _003Cremote_003E5__1.Gears != _003C_003E4__this._preferences.Get("static_version_gears", -1);
					_003CtalentsChanged_003E5__6 = _003Cremote_003E5__1.Talents != _003C_003E4__this._preferences.Get("static_version_talents", -1);
					_003CquestsChanged_003E5__7 = _003Cremote_003E5__1.Quests != _003C_003E4__this._preferences.Get("static_version_quests", -1);
					if (_003CmovesChanged_003E5__2 || _003CspiritsChanged_003E5__3 || _003CitemsChanged_003E5__4 || _003CgearsChanged_003E5__5 || _003CtalentsChanged_003E5__6 || _003CquestsChanged_003E5__7)
					{
						Action? staticDataUpdateStarted = _003C_003E4__this.StaticDataUpdateStarted;
						if (staticDataUpdateStarted != null)
						{
							staticDataUpdateStarted.Invoke();
						}
						goto IL_019f;
					}
				}
				goto end_IL_0007;
				IL_019f:
				try
				{
					TaskAwaiter<bool[]> awaiter;
					TaskAwaiter<bool> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<bool[]>);
							num = (_003C_003E1__state = -1);
							goto IL_03ef;
						}
						_003C_003Es__10 = _003CmovesChanged_003E5__2;
						_003C_003Es__11 = _003C_003Es__10;
						if (!_003C_003Es__11)
						{
							goto IL_025d;
						}
						awaiter2 = _003C_003E4__this.LoadMovesAsync(_003Cremote_003E5__1.Moves).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003COnVersionSnapshot_003Ed__80 _003COnVersionSnapshot_003Ed__ = this;
							((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003COnVersionSnapshot_003Ed__80>(ref awaiter2, ref _003COnVersionSnapshot_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__12 = awaiter2.GetResult();
					_003C_003Es__11 = !_003C_003Es__12;
					goto IL_025d;
					IL_03ef:
					_003C_003Es__13 = awaiter.GetResult();
					_003Cresults_003E5__9 = _003C_003Es__13;
					_003C_003Es__13 = null;
					if (Enumerable.Any<bool>((global::System.Collections.Generic.IEnumerable<bool>)_003Cresults_003E5__9, (Func<bool, bool>)((bool r) => r)))
					{
						_003C_003E4__this.ResolveTaskItemRewards();
						Console.WriteLine("StaticDataCacheService: live update applied, firing StaticDataUpdated");
						Action? staticDataUpdated = _003C_003E4__this.StaticDataUpdated;
						if (staticDataUpdated != null)
						{
							staticDataUpdated.Invoke();
						}
					}
					_003Ctasks_003E5__8 = null;
					_003Cresults_003E5__9 = null;
					goto end_IL_019f;
					IL_025d:
					if (!_003C_003Es__11)
					{
						_003Ctasks_003E5__8 = new List<global::System.Threading.Tasks.Task<bool>>();
						if (_003CspiritsChanged_003E5__3)
						{
							_003Ctasks_003E5__8.Add(_003C_003E4__this.LoadSpiritsAsync(_003Cremote_003E5__1.Spirits));
						}
						if (_003CitemsChanged_003E5__4)
						{
							_003Ctasks_003E5__8.Add(_003C_003E4__this.LoadItemsAsync(_003Cremote_003E5__1.Items));
						}
						if (_003CgearsChanged_003E5__5)
						{
							_003Ctasks_003E5__8.Add(_003C_003E4__this.LoadGearsAsync(_003Cremote_003E5__1.Gears));
						}
						if (_003CtalentsChanged_003E5__6)
						{
							_003Ctasks_003E5__8.Add(_003C_003E4__this.LoadTalentsAsync(_003Cremote_003E5__1.Talents));
						}
						if (_003CquestsChanged_003E5__7)
						{
							_003Ctasks_003E5__8.Add(_003C_003E4__this.LoadQuestsAsync(_003Cremote_003E5__1.Quests));
						}
						if (_003Ctasks_003E5__8.Count != 0)
						{
							awaiter = global::System.Threading.Tasks.Task.WhenAll<bool>((global::System.Collections.Generic.IEnumerable<global::System.Threading.Tasks.Task<bool>>)_003Ctasks_003E5__8).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter;
								_003COnVersionSnapshot_003Ed__80 _003COnVersionSnapshot_003Ed__ = this;
								((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool[]>, _003COnVersionSnapshot_003Ed__80>(ref awaiter, ref _003COnVersionSnapshot_003Ed__);
								return;
							}
							goto IL_03ef;
						}
						Action? staticDataUpdated2 = _003C_003E4__this.StaticDataUpdated;
						if (staticDataUpdated2 != null)
						{
							staticDataUpdated2.Invoke();
						}
					}
					end_IL_019f:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__14 = ex;
					Console.WriteLine("StaticDataCacheService: OnVersionSnapshot error: " + _003Cex_003E5__14.Message);
				}
				finally
				{
					if (num < 0)
					{
						Action? staticDataUpdateEnded = _003C_003E4__this.StaticDataUpdateEnded;
						if (staticDataUpdateEnded != null)
						{
							staticDataUpdateEnded.Invoke();
						}
					}
				}
				end_IL_0007:;
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003Cremote_003E5__1 = null;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003Cremote_003E5__1 = null;
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IFirebaseFirestore _firestore;

	private readonly IPreferencesService _preferences;

	private readonly StaticDataSqliteCache _sqliteCache;

	private global::System.IDisposable? _versionListener;

	private const string PrefVersionSpirits = "static_version_spirits";

	private const string PrefVersionItems = "static_version_items";

	private const string PrefVersionGears = "static_version_gears";

	private const string PrefVersionMoves = "static_version_moves";

	private const string PrefVersionTalents = "static_version_talents";

	private const string PrefVersionQuests = "static_version_quests";

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private Action? m_StaticDataUpdateStarted;

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private Action? m_StaticDataUpdateEnded;

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private Action? m_StaticDataUpdated;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, Item> Items
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = new Dictionary<string, Item>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, Item> Gears
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = new Dictionary<string, Item>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, Item> Talents
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = new Dictionary<string, Item>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, Spirit> Spirits
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = new Dictionary<string, Spirit>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, Move> Moves
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = new Dictionary<string, Move>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, Quest> Quests
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = new Dictionary<string, Quest>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, List<Area>> AreasByQuest
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = new Dictionary<string, List<Area>>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Dictionary<string, List<QuestTask>> TasksByArea
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = new Dictionary<string, List<QuestTask>>();


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool ItemsFullyLoaded
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = false;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool GearsFullyLoaded
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = false;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool TalentsFullyLoaded
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = false;


	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool MovesFullyLoaded
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		private set;
	} = false;


	public event Action StaticDataUpdateStarted
	{
		[CompilerGenerated]
		add
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			Action val = this.m_StaticDataUpdateStarted;
			Action val2;
			do
			{
				val2 = val;
				Action val3 = (Action)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<Action>(ref this.m_StaticDataUpdateStarted, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			Action val = this.m_StaticDataUpdateStarted;
			Action val2;
			do
			{
				val2 = val;
				Action val3 = (Action)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<Action>(ref this.m_StaticDataUpdateStarted, val3, val2);
			}
			while (val != val2);
		}
	}

	public event Action StaticDataUpdateEnded
	{
		[CompilerGenerated]
		add
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			Action val = this.m_StaticDataUpdateEnded;
			Action val2;
			do
			{
				val2 = val;
				Action val3 = (Action)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<Action>(ref this.m_StaticDataUpdateEnded, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			Action val = this.m_StaticDataUpdateEnded;
			Action val2;
			do
			{
				val2 = val;
				Action val3 = (Action)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<Action>(ref this.m_StaticDataUpdateEnded, val3, val2);
			}
			while (val != val2);
		}
	}

	public event Action StaticDataUpdated
	{
		[CompilerGenerated]
		add
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			Action val = this.m_StaticDataUpdated;
			Action val2;
			do
			{
				val2 = val;
				Action val3 = (Action)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<Action>(ref this.m_StaticDataUpdated, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			Action val = this.m_StaticDataUpdated;
			Action val2;
			do
			{
				val2 = val;
				Action val3 = (Action)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<Action>(ref this.m_StaticDataUpdated, val3, val2);
			}
			while (val != val2);
		}
	}

	public void SetItemsFullyLoaded()
	{
		ItemsFullyLoaded = true;
	}

	public void SetGearsFullyLoaded()
	{
		GearsFullyLoaded = true;
	}

	public void SetTalentsFullyLoaded()
	{
		TalentsFullyLoaded = true;
	}

	public void SetMovesFullyLoaded()
	{
		MovesFullyLoaded = true;
	}

	public StaticDataCacheService(IFirebaseFirestore firestore, IPreferencesService preferences)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		_firestore = firestore ?? throw new ArgumentNullException("firestore");
		_preferences = preferences ?? throw new ArgumentNullException("preferences");
		_sqliteCache = new StaticDataSqliteCache();
	}

	[AsyncStateMachine(typeof(_003CLoadStaticDataAsync_003Ed__72))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> LoadStaticDataAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			await _sqliteCache.InitializeAsync();
			StaticDataVersionsDTO remote = await GetRemoteVersionsAsync();
			if (remote == null)
			{
				return false;
			}
			if (!(await LoadMovesAsync(remote.Moves)))
			{
				return false;
			}
			_003C_003Ey__InlineArray5<global::System.Threading.Tasks.Task<bool>> buffer = default(_003C_003Ey__InlineArray5<global::System.Threading.Tasks.Task<bool>>);
			_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 0) = LoadSpiritsAsync(remote.Spirits);
			_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 1) = LoadItemsAsync(remote.Items);
			_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 2) = LoadGearsAsync(remote.Gears);
			_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 3) = LoadTalentsAsync(remote.Talents);
			_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(ref buffer, 4) = LoadQuestsAsync(remote.Quests);
			if (!Enumerable.All<bool>((global::System.Collections.Generic.IEnumerable<bool>)(await global::System.Threading.Tasks.Task.WhenAll<bool>(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray5<global::System.Threading.Tasks.Task<bool>>, global::System.Threading.Tasks.Task<bool>>(in buffer, 5))), (Func<bool, bool>)((bool r) => r)))
			{
				return false;
			}
			ResolveTaskItemRewards();
			FirestoreReadCounter.LogSummary();
			StartVersionListener();
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error loading static data: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CLoadSpiritsAsync_003Ed__73))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<bool> LoadSpiritsAsync(int remoteVersion)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		int cached = _preferences.Get("static_version_spirits", -1);
		if (remoteVersion > 0 && remoteVersion == cached)
		{
			Dictionary<string, Spirit> spirits = await _sqliteCache.ReadCollectionAsync<Spirit>("spirits");
			if (spirits != null)
			{
				Spirits = spirits;
				return true;
			}
		}
		Spirits = new Dictionary<string, Spirit>();
		if (!(await LoadStaticSpiritsAsync()))
		{
			return false;
		}
		await _sqliteCache.WriteCollectionAsync<Spirit>("spirits", Spirits);
		_preferences.Set("static_version_spirits", remoteVersion);
		return true;
	}

	[AsyncStateMachine(typeof(_003CLoadItemsAsync_003Ed__74))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<bool> LoadItemsAsync(int remoteVersion)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		int cached = _preferences.Get("static_version_items", -1);
		if (remoteVersion > 0 && remoteVersion == cached)
		{
			Dictionary<string, Item> items = await _sqliteCache.ReadCollectionAsync<Item>("items");
			if (items != null)
			{
				Items = items;
				return true;
			}
		}
		Items = new Dictionary<string, Item>();
		if (!(await LoadStaticItemDataAsync()))
		{
			return false;
		}
		await _sqliteCache.WriteCollectionAsync<Item>("items", Items);
		_preferences.Set("static_version_items", remoteVersion);
		return true;
	}

	[AsyncStateMachine(typeof(_003CLoadGearsAsync_003Ed__75))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<bool> LoadGearsAsync(int remoteVersion)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		int cached = _preferences.Get("static_version_gears", -1);
		if (remoteVersion > 0 && remoteVersion == cached)
		{
			Dictionary<string, Item> gears = await _sqliteCache.ReadCollectionAsync<Item>("gears");
			if (gears != null)
			{
				Gears = gears;
				return true;
			}
		}
		Gears = new Dictionary<string, Item>();
		if (!(await LoadStaticGearDataAsync()))
		{
			return false;
		}
		await _sqliteCache.WriteCollectionAsync<Item>("gears", Gears);
		_preferences.Set("static_version_gears", remoteVersion);
		return true;
	}

	[AsyncStateMachine(typeof(_003CLoadMovesAsync_003Ed__76))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<bool> LoadMovesAsync(int remoteVersion)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		int cached = _preferences.Get("static_version_moves", -1);
		if (remoteVersion > 0 && remoteVersion == cached)
		{
			Dictionary<string, Move> moves = await _sqliteCache.ReadCollectionAsync<Move>("moves");
			if (moves != null)
			{
				Moves = moves;
				return true;
			}
		}
		Moves = new Dictionary<string, Move>();
		if (!(await LoadStaticMovesAsync()))
		{
			return false;
		}
		await _sqliteCache.WriteCollectionAsync<Move>("moves", Moves);
		_preferences.Set("static_version_moves", remoteVersion);
		return true;
	}

	[AsyncStateMachine(typeof(_003CLoadTalentsAsync_003Ed__77))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<bool> LoadTalentsAsync(int remoteVersion)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		int cached = _preferences.Get("static_version_talents", -1);
		if (remoteVersion > 0 && remoteVersion == cached)
		{
			Dictionary<string, Item> talents = await _sqliteCache.ReadCollectionAsync<Item>("talents");
			if (talents != null)
			{
				Talents = talents;
				return true;
			}
		}
		Talents = new Dictionary<string, Item>();
		if (!(await LoadStaticTalentAsync()))
		{
			return false;
		}
		await _sqliteCache.WriteCollectionAsync<Item>("talents", Talents);
		_preferences.Set("static_version_talents", remoteVersion);
		return true;
	}

	[AsyncStateMachine(typeof(_003CLoadQuestsAsync_003Ed__78))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<bool> LoadQuestsAsync(int remoteVersion)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		int cached = _preferences.Get("static_version_quests", -1);
		if (remoteVersion > 0 && remoteVersion == cached)
		{
			Dictionary<string, Quest> quests = await _sqliteCache.ReadCollectionAsync<Quest>("quests");
			Dictionary<string, List<Area>> areas = await _sqliteCache.ReadListCollectionAsync<Area>("areasByQuest");
			Dictionary<string, List<StaticDataSqliteCache.CachedQuestTask>> cachedTasks = await _sqliteCache.ReadListCollectionAsync<StaticDataSqliteCache.CachedQuestTask>("tasksByArea");
			if (quests != null && areas != null && cachedTasks != null)
			{
				Quests = quests;
				AreasByQuest = areas;
				TasksByArea = _sqliteCache.ToQuestTasksByArea(cachedTasks);
				return true;
			}
		}
		Quests = new Dictionary<string, Quest>();
		AreasByQuest = new Dictionary<string, List<Area>>();
		TasksByArea = new Dictionary<string, List<QuestTask>>();
		if (!(await LoadStaticQuestDataAsync()))
		{
			return false;
		}
		await _sqliteCache.WriteCollectionAsync<Quest>("quests", Quests);
		await _sqliteCache.WriteListCollectionAsync<Area>("areasByQuest", AreasByQuest);
		await _sqliteCache.WriteListCollectionAsync<StaticDataSqliteCache.CachedQuestTask>("tasksByArea", _sqliteCache.ToCachedTasksByArea(TasksByArea));
		_preferences.Set("static_version_quests", remoteVersion);
		return true;
	}

	private void StartVersionListener()
	{
		_versionListener?.Dispose();
		_versionListener = _firestore.GetCollection("config").GetDocument("staticDataVersions").AddSnapshotListener<StaticDataVersionsDTO>((Action<IDocumentSnapshot<StaticDataVersionsDTO>>)OnVersionSnapshot, (Action<global::System.Exception>)delegate(global::System.Exception ex)
		{
			Console.WriteLine("StaticDataCacheService: version listener error: " + ex?.Message);
		}, false);
	}

	[AsyncStateMachine(typeof(_003COnVersionSnapshot_003Ed__80))]
	[DebuggerStepThrough]
	private void OnVersionSnapshot(IDocumentSnapshot<StaticDataVersionsDTO>? snapshot)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COnVersionSnapshot_003Ed__80 _003COnVersionSnapshot_003Ed__ = new _003COnVersionSnapshot_003Ed__80();
		_003COnVersionSnapshot_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003COnVersionSnapshot_003Ed__._003C_003E4__this = this;
		_003COnVersionSnapshot_003Ed__.snapshot = snapshot;
		_003COnVersionSnapshot_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003COnVersionSnapshot_003Ed__._003C_003Et__builder)).Start<_003COnVersionSnapshot_003Ed__80>(ref _003COnVersionSnapshot_003Ed__);
	}

	[AsyncStateMachine(typeof(_003CGetRemoteVersionsAsync_003Ed__81))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<StaticDataVersionsDTO?> GetRemoteVersionsAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IDocumentSnapshot<StaticDataVersionsDTO> snapshot = await _firestore.GetDocument("config/staticDataVersions").GetDocumentSnapshotAsync<StaticDataVersionsDTO>((Source)0);
			FirestoreReadCounter.Track("config/staticDataVersions");
			return snapshot?.Data;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Could not read static data versions from Firestore: " + ex.Message);
			return null;
		}
	}

	[AsyncStateMachine(typeof(_003CLoadStaticQuestDataAsync_003Ed__82))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<bool> LoadStaticQuestDataAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Stopwatch sw = Stopwatch.StartNew();
			ICollectionReference questsCollection = _firestore.GetCollection("quests");
			IQuerySnapshot<FirestoreQuestDTO> questsSnapshot = await ((IQuery)questsCollection).OrderBy("order", false).GetDocumentsAsync<FirestoreQuestDTO>((Source)0);
			FirestoreReadCounter.Track("quests", Enumerable.Count<IDocumentSnapshot<FirestoreQuestDTO>>(questsSnapshot.Documents));
			global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreQuestDTO>> enumerator = questsSnapshot.Documents.GetEnumerator();
			try
			{
				while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
				{
					IDocumentSnapshot<FirestoreQuestDTO> doc = enumerator.Current;
					FirestoreQuestDTO quest = doc.Data;
					string questId = doc.Reference.Id;
					Quests[questId] = QuestEntityMapper.ToEntity(quest);
					ICollectionReference areasCollection = _firestore.GetCollection("quests/" + questId + "/areas");
					IQuerySnapshot<FirestoreAreasDTO> areasSnapshot = await ((IQuery)areasCollection).OrderBy("order", false).GetDocumentsAsync<FirestoreAreasDTO>((Source)0);
					FirestoreReadCounter.Track("quests/*/areas", Enumerable.Count<IDocumentSnapshot<FirestoreAreasDTO>>(areasSnapshot.Documents));
					List<FirestoreAreasDTO> areasList = new List<FirestoreAreasDTO>();
					global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreAreasDTO>> enumerator2 = areasSnapshot.Documents.GetEnumerator();
					try
					{
						while (((global::System.Collections.IEnumerator)enumerator2).MoveNext())
						{
							IDocumentSnapshot<FirestoreAreasDTO> areaDoc = enumerator2.Current;
							FirestoreAreasDTO area = areaDoc.Data;
							string areaId = areaDoc.Reference.Id;
							if (string.IsNullOrEmpty(area.Id))
							{
								area.Id = areaId;
							}
							areasList.Add(area);
							ICollectionReference tasksCollection = ((area.Id == "ChallangeFights") ? _firestore.GetCollection($"quests/{questId}/areas/{areaId}/battles") : _firestore.GetCollection($"quests/{questId}/areas/{areaId}/tasks"));
							IQuerySnapshot<FirestoreTaskDTO> tasksSnapshot = await ((IQuery)tasksCollection).GetDocumentsAsync<FirestoreTaskDTO>((Source)0);
							FirestoreReadCounter.Track("quests/*/areas/*/tasks", Enumerable.Count<IDocumentSnapshot<FirestoreTaskDTO>>(tasksSnapshot.Documents));
							List<FirestoreTaskDTO> tasksList = new List<FirestoreTaskDTO>();
							global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreTaskDTO>> enumerator3 = tasksSnapshot.Documents.GetEnumerator();
							try
							{
								while (((global::System.Collections.IEnumerator)enumerator3).MoveNext())
								{
									IDocumentSnapshot<FirestoreTaskDTO> taskDoc = enumerator3.Current;
									FirestoreTaskDTO taskData = taskDoc.Data;
									if (string.IsNullOrEmpty(taskData.Id))
									{
										taskData.Id = taskDoc.Reference.Id;
									}
									tasksList.Add(taskData);
								}
							}
							finally
							{
								((global::System.IDisposable)enumerator3)?.Dispose();
							}
							TasksByArea[areaId] = Enumerable.ToList<QuestTask>(Enumerable.Select<FirestoreTaskDTO, QuestTask>((global::System.Collections.Generic.IEnumerable<FirestoreTaskDTO>)tasksList, (Func<FirestoreTaskDTO, QuestTask>)QuestEntityMapper.ToEntity));
						}
					}
					finally
					{
						((global::System.IDisposable)enumerator2)?.Dispose();
					}
					AreasByQuest[questId] = Enumerable.ToList<Area>(Enumerable.Select<FirestoreAreasDTO, Area>((global::System.Collections.Generic.IEnumerable<FirestoreAreasDTO>)areasList, (Func<FirestoreAreasDTO, Area>)QuestEntityMapper.ToEntity));
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator)?.Dispose();
			}
			Console.WriteLine("Loading static quest data completed in " + sw.ElapsedMilliseconds + "ms");
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error loading static quest data: " + ex.Message);
			Console.WriteLine("Stacktrace: " + ex.StackTrace);
			return false;
		}
	}

	private void ResolveTaskItemRewards()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		Enumerator<string, List<QuestTask>> enumerator = TasksByArea.Values.GetEnumerator();
		try
		{
			Item item = default(Item);
			while (enumerator.MoveNext())
			{
				List<QuestTask> current = enumerator.Current;
				Enumerator<QuestTask> enumerator2 = current.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						QuestTask current2 = enumerator2.Current;
						if (current2.Rewards != null && current2.Rewards.ItemIds.Count != 0)
						{
							current2.Rewards.Items = Enumerable.ToList<Item>(Enumerable.OfType<Item>((global::System.Collections.IEnumerable)Enumerable.Select<string, Item>((global::System.Collections.Generic.IEnumerable<string>)current2.Rewards.ItemIds, (Func<string, Item>)([CompilerGenerated] (string id) => Items.TryGetValue(id, ref item) ? item : null))));
						}
					}
				}
				finally
				{
					((global::System.IDisposable)enumerator2).Dispose();
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator).Dispose();
		}
	}

	[AsyncStateMachine(typeof(_003CLoadStaticTalentAsync_003Ed__84))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<bool> LoadStaticTalentAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ICollectionReference itemsCollection = _firestore.GetCollection("talents");
			IQuerySnapshot<FirestoreItemDTO> itemsSnapshot = await ((IQuery)itemsCollection).GetDocumentsAsync<FirestoreItemDTO>((Source)0);
			FirestoreReadCounter.Track("talents", Enumerable.Count<IDocumentSnapshot<FirestoreItemDTO>>(itemsSnapshot.Documents));
			global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreItemDTO>> enumerator = itemsSnapshot.Documents.GetEnumerator();
			try
			{
				while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
				{
					IDocumentSnapshot<FirestoreItemDTO> doc = enumerator.Current;
					Console.WriteLine("Loading talent " + doc.Reference.Id);
					FirestoreItemDTO item = doc.Data;
					string itemId = doc.Reference.Id;
					Talents[itemId] = ItemEntityMapper.ToEntity(item);
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator)?.Dispose();
			}
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error loading static items data: " + ex.Message);
			Console.WriteLine(ex.StackTrace);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CLoadStaticGearDataAsync_003Ed__85))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<bool> LoadStaticGearDataAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ICollectionReference itemsCollection = _firestore.GetCollection("gears");
			IQuerySnapshot<FirestoreItemDTO> itemsSnapshot = await ((IQuery)itemsCollection).GetDocumentsAsync<FirestoreItemDTO>((Source)0);
			FirestoreReadCounter.Track("gears", Enumerable.Count<IDocumentSnapshot<FirestoreItemDTO>>(itemsSnapshot.Documents));
			global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreItemDTO>> enumerator = itemsSnapshot.Documents.GetEnumerator();
			try
			{
				while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
				{
					IDocumentSnapshot<FirestoreItemDTO> doc = enumerator.Current;
					Console.WriteLine("Loading gear " + doc.Reference.Id);
					FirestoreItemDTO item = doc.Data;
					string itemId = doc.Reference.Id;
					Gears[itemId] = ItemEntityMapper.ToEntity(item);
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator)?.Dispose();
			}
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error loading static items data: " + ex.Message);
			Console.WriteLine(ex.StackTrace);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CLoadStaticItemDataAsync_003Ed__86))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<bool> LoadStaticItemDataAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ICollectionReference itemsCollection = _firestore.GetCollection("items");
			IQuerySnapshot<FirestoreItemDTO> itemsSnapshot = await ((IQuery)itemsCollection).GetDocumentsAsync<FirestoreItemDTO>((Source)0);
			FirestoreReadCounter.Track("items", Enumerable.Count<IDocumentSnapshot<FirestoreItemDTO>>(itemsSnapshot.Documents));
			global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreItemDTO>> enumerator = itemsSnapshot.Documents.GetEnumerator();
			try
			{
				while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
				{
					IDocumentSnapshot<FirestoreItemDTO> doc = enumerator.Current;
					FirestoreItemDTO item = doc.Data;
					string itemId = doc.Reference.Id;
					Items[itemId] = ItemEntityMapper.ToEntity(item);
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator)?.Dispose();
			}
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error loading static items data: " + ex.Message);
			Console.WriteLine(ex.StackTrace);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CLoadStaticSpiritsAsync_003Ed__87))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<bool> LoadStaticSpiritsAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Stopwatch sw = Stopwatch.StartNew();
			ICollectionReference spiritsCollection = _firestore.GetCollection("spiritsTemp");
			IQuerySnapshot<FirestoreSpiritDTO> spiritsSnapshot = await ((IQuery)spiritsCollection).GetDocumentsAsync<FirestoreSpiritDTO>((Source)0);
			FirestoreReadCounter.Track("spirits", Enumerable.Count<IDocumentSnapshot<FirestoreSpiritDTO>>(spiritsSnapshot.Documents));
			global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreSpiritDTO>> enumerator = spiritsSnapshot.Documents.GetEnumerator();
			try
			{
				while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
				{
					IDocumentSnapshot<FirestoreSpiritDTO> doc = enumerator.Current;
					FirestoreSpiritDTO spirit = doc.Data;
					string spiritId = doc.Reference.Id;
					Spirits[spiritId] = SpiritEntityMapper.ToEntity(spirit, Moves);
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator)?.Dispose();
			}
			Console.WriteLine("Loading static spirits completed in " + sw.ElapsedMilliseconds + "ms");
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error loading static spirits data: " + ex.Message);
			Console.WriteLine(ex.StackTrace);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CLoadStaticMovesAsync_003Ed__88))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<bool> LoadStaticMovesAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ICollectionReference movesCollection = _firestore.GetCollection("moves");
			IQuerySnapshot<FirestoreMoveDTO> movesSnapshot = await ((IQuery)movesCollection).GetDocumentsAsync<FirestoreMoveDTO>((Source)0);
			FirestoreReadCounter.Track("moves", Enumerable.Count<IDocumentSnapshot<FirestoreMoveDTO>>(movesSnapshot.Documents));
			global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreMoveDTO>> enumerator = movesSnapshot.Documents.GetEnumerator();
			try
			{
				while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
				{
					IDocumentSnapshot<FirestoreMoveDTO> doc = enumerator.Current;
					FirestoreMoveDTO move = doc.Data;
					string moveId = doc.Reference.Id;
					Moves[moveId] = MoveEntityMapper.ToEntity(move);
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator)?.Dispose();
			}
			return true;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error loading static moves data: " + ex.Message);
			Console.WriteLine(ex.StackTrace);
			return false;
		}
	}
}
