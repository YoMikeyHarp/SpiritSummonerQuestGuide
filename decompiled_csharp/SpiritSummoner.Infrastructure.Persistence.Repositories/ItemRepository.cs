using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Plugin.Firebase.Firestore;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Enums.Items;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Caching;
using SpiritSummoner.Infrastructure.Persistence.DTOs.Items;
using SpiritSummoner.Infrastructure.Persistence.Mapping;

namespace SpiritSummoner.Infrastructure.Persistence.Repositories;

public class ItemRepository : IItemRepository
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public ItemType type;

		internal bool _003CGetByTypeAsync_003Eb__0(Item i)
		{
			return i.ItemType == type;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public List<ItemType> itemTypes;

		public int playerLevel;

		internal bool _003CGetItemsByTypeAndLevel_003Eb__1(Item i)
		{
			return itemTypes.Contains(i.ItemType);
		}

		internal bool _003CGetItemsByTypeAndLevel_003Eb__2(Item i)
		{
			return (i.Requirements?.LevelRequirement?.PlayerLevelRequired).GetValueOrDefault(1) <= playerLevel;
		}

		internal bool _003CGetItemsByTypeAndLevel_003Eb__3(Item i)
		{
			return itemTypes.Contains(i.ItemType);
		}

		internal bool _003CGetItemsByTypeAndLevel_003Eb__4(Item i)
		{
			return (i.Requirements?.LevelRequirement?.PlayerLevelRequired).GetValueOrDefault(1) <= playerLevel;
		}

		internal bool _003CGetItemsByTypeAndLevel_003Eb__5(Item i)
		{
			return itemTypes.Contains(i.ItemType);
		}

		internal bool _003CGetItemsByTypeAndLevel_003Eb__6(Item i)
		{
			return (i.Requirements?.LevelRequirement?.PlayerLevelRequired).GetValueOrDefault(1) <= playerLevel;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetAllGearsAsync_003Ed__8 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<IReadOnlyDictionary<string, Item>> _003C_003Et__builder;

		public ItemRepository _003C_003E4__this;

		private IQuerySnapshot<FirestoreItemDTO> _003CfirestoreItems_003E5__1;

		private IQuerySnapshot<FirestoreItemDTO> _003C_003Es__2;

		private global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreItemDTO>> _003C_003Es__3;

		private IDocumentSnapshot<FirestoreItemDTO> _003Cdoc_003E5__4;

		private Item _003Citem_003E5__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<IQuerySnapshot<FirestoreItemDTO>> _003C_003Eu__1;

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
			IReadOnlyDictionary<string, Item> gears;
			try
			{
				if (num != 0 && _003C_003E4__this._staticDataCache.GearsFullyLoaded)
				{
					gears = (IReadOnlyDictionary<string, Item>)(object)_003C_003E4__this._staticDataCache.Gears;
				}
				else
				{
					try
					{
						TaskAwaiter<IQuerySnapshot<FirestoreItemDTO>> awaiter;
						if (num != 0)
						{
							awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection(_003C_003E4__this.CollectionNameGears)).GetDocumentsAsync<FirestoreItemDTO>((Source)0).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CGetAllGearsAsync_003Ed__8 _003CGetAllGearsAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreItemDTO>>, _003CGetAllGearsAsync_003Ed__8>(ref awaiter, ref _003CGetAllGearsAsync_003Ed__);
								return;
							}
						}
						else
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreItemDTO>>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__2 = awaiter.GetResult();
						_003CfirestoreItems_003E5__1 = _003C_003Es__2;
						_003C_003Es__2 = null;
						_003C_003Es__3 = _003CfirestoreItems_003E5__1.Documents.GetEnumerator();
						try
						{
							while (((global::System.Collections.IEnumerator)_003C_003Es__3).MoveNext())
							{
								_003Cdoc_003E5__4 = _003C_003Es__3.Current;
								if (_003Cdoc_003E5__4.Data != null)
								{
									_003Citem_003E5__5 = ItemEntityMapper.ToEntity(_003Cdoc_003E5__4.Data);
									if (!string.IsNullOrEmpty(_003Citem_003E5__5.ID))
									{
										_003C_003E4__this._staticDataCache.Gears[_003Citem_003E5__5.ID] = _003Citem_003E5__5;
									}
									_003Citem_003E5__5 = null;
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
						_003C_003E4__this._staticDataCache.SetGearsFullyLoaded();
						gears = (IReadOnlyDictionary<string, Item>)(object)_003C_003E4__this._staticDataCache.Gears;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__6 = ex;
						Console.WriteLine("Error fetching all items: " + _003Cex_003E5__6.Message);
						gears = (IReadOnlyDictionary<string, Item>)(object)_003C_003E4__this._staticDataCache.Gears;
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
			_003C_003Et__builder.SetResult(gears);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetAllItemsAsync_003Ed__6 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<IReadOnlyDictionary<string, Item>> _003C_003Et__builder;

		public ItemRepository _003C_003E4__this;

		private IQuerySnapshot<FirestoreItemDTO> _003CfirestoreItems_003E5__1;

		private IQuerySnapshot<FirestoreItemDTO> _003C_003Es__2;

		private global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreItemDTO>> _003C_003Es__3;

		private IDocumentSnapshot<FirestoreItemDTO> _003Cdoc_003E5__4;

		private Item _003Citem_003E5__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<IQuerySnapshot<FirestoreItemDTO>> _003C_003Eu__1;

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
			IReadOnlyDictionary<string, Item> items;
			try
			{
				if (num != 0 && _003C_003E4__this._staticDataCache.ItemsFullyLoaded)
				{
					items = (IReadOnlyDictionary<string, Item>)(object)_003C_003E4__this._staticDataCache.Items;
				}
				else
				{
					try
					{
						TaskAwaiter<IQuerySnapshot<FirestoreItemDTO>> awaiter;
						if (num != 0)
						{
							awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection(_003C_003E4__this.CollectionName)).GetDocumentsAsync<FirestoreItemDTO>((Source)0).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CGetAllItemsAsync_003Ed__6 _003CGetAllItemsAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreItemDTO>>, _003CGetAllItemsAsync_003Ed__6>(ref awaiter, ref _003CGetAllItemsAsync_003Ed__);
								return;
							}
						}
						else
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreItemDTO>>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__2 = awaiter.GetResult();
						_003CfirestoreItems_003E5__1 = _003C_003Es__2;
						_003C_003Es__2 = null;
						_003C_003Es__3 = _003CfirestoreItems_003E5__1.Documents.GetEnumerator();
						try
						{
							while (((global::System.Collections.IEnumerator)_003C_003Es__3).MoveNext())
							{
								_003Cdoc_003E5__4 = _003C_003Es__3.Current;
								if (_003Cdoc_003E5__4.Data != null)
								{
									_003Citem_003E5__5 = ItemEntityMapper.ToEntity(_003Cdoc_003E5__4.Data);
									if (!string.IsNullOrEmpty(_003Citem_003E5__5.ID))
									{
										_003C_003E4__this._staticDataCache.Items[_003Citem_003E5__5.ID] = _003Citem_003E5__5;
									}
									_003Citem_003E5__5 = null;
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
						_003C_003E4__this._staticDataCache.SetItemsFullyLoaded();
						items = (IReadOnlyDictionary<string, Item>)(object)_003C_003E4__this._staticDataCache.Items;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__6 = ex;
						Console.WriteLine("Error fetching all items: " + _003Cex_003E5__6.Message);
						items = (IReadOnlyDictionary<string, Item>)(object)_003C_003E4__this._staticDataCache.Items;
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
			_003C_003Et__builder.SetResult(items);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetAllTalentsAsync_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<IReadOnlyDictionary<string, Item>> _003C_003Et__builder;

		public ItemRepository _003C_003E4__this;

		private IQuerySnapshot<FirestoreItemDTO> _003CfirestoreItems_003E5__1;

		private IQuerySnapshot<FirestoreItemDTO> _003C_003Es__2;

		private global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreItemDTO>> _003C_003Es__3;

		private IDocumentSnapshot<FirestoreItemDTO> _003Cdoc_003E5__4;

		private Item _003Citem_003E5__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<IQuerySnapshot<FirestoreItemDTO>> _003C_003Eu__1;

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
			IReadOnlyDictionary<string, Item> talents;
			try
			{
				if (num != 0 && _003C_003E4__this._staticDataCache.TalentsFullyLoaded)
				{
					talents = (IReadOnlyDictionary<string, Item>)(object)_003C_003E4__this._staticDataCache.Talents;
				}
				else
				{
					try
					{
						TaskAwaiter<IQuerySnapshot<FirestoreItemDTO>> awaiter;
						if (num != 0)
						{
							awaiter = ((IQuery)_003C_003E4__this._firestore.GetCollection(_003C_003E4__this.CollectionNameTalents)).GetDocumentsAsync<FirestoreItemDTO>((Source)0).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CGetAllTalentsAsync_003Ed__7 _003CGetAllTalentsAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IQuerySnapshot<FirestoreItemDTO>>, _003CGetAllTalentsAsync_003Ed__7>(ref awaiter, ref _003CGetAllTalentsAsync_003Ed__);
								return;
							}
						}
						else
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<IQuerySnapshot<FirestoreItemDTO>>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__2 = awaiter.GetResult();
						_003CfirestoreItems_003E5__1 = _003C_003Es__2;
						_003C_003Es__2 = null;
						_003C_003Es__3 = _003CfirestoreItems_003E5__1.Documents.GetEnumerator();
						try
						{
							while (((global::System.Collections.IEnumerator)_003C_003Es__3).MoveNext())
							{
								_003Cdoc_003E5__4 = _003C_003Es__3.Current;
								if (_003Cdoc_003E5__4.Data != null)
								{
									_003Citem_003E5__5 = ItemEntityMapper.ToEntity(_003Cdoc_003E5__4.Data);
									if (!string.IsNullOrEmpty(_003Citem_003E5__5.ID))
									{
										_003C_003E4__this._staticDataCache.Talents[_003Citem_003E5__5.ID] = _003Citem_003E5__5;
									}
									_003Citem_003E5__5 = null;
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
						_003C_003E4__this._staticDataCache.SetTalentsFullyLoaded();
						talents = (IReadOnlyDictionary<string, Item>)(object)_003C_003E4__this._staticDataCache.Talents;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__6 = ex;
						Console.WriteLine("Error fetching all items: " + _003Cex_003E5__6.Message);
						talents = (IReadOnlyDictionary<string, Item>)(object)_003C_003E4__this._staticDataCache.Talents;
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
			_003C_003Et__builder.SetResult(talents);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetByIdAsync_003Ed__9 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Item> _003C_003Et__builder;

		public string itemId;

		public ItemRepository _003C_003E4__this;

		private bool _003CcacheCheck_003E5__1;

		private Item _003Citem_003E5__2;

		private IDocumentSnapshot<FirestoreItemDTO> _003CitemSnapshot_003E5__3;

		private IDocumentSnapshot<FirestoreItemDTO> _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<IDocumentSnapshot<FirestoreItemDTO>> _003C_003Eu__1;

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
			Item result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IDocumentSnapshot<FirestoreItemDTO>> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<FirestoreItemDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_00d8;
					}
					_003CcacheCheck_003E5__1 = _003C_003E4__this._staticDataCache.Items.TryGetValue(itemId, ref _003Citem_003E5__2);
					if (!_003CcacheCheck_003E5__1)
					{
						awaiter = _003C_003E4__this._firestore.GetCollection(_003C_003E4__this.CollectionName).GetDocument(itemId).GetDocumentSnapshotAsync<FirestoreItemDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetByIdAsync_003Ed__9 _003CGetByIdAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestoreItemDTO>>, _003CGetByIdAsync_003Ed__9>(ref awaiter, ref _003CGetByIdAsync_003Ed__);
							return;
						}
						goto IL_00d8;
					}
					result = _003Citem_003E5__2;
					goto end_IL_0010;
					IL_00d8:
					_003C_003Es__4 = awaiter.GetResult();
					_003CitemSnapshot_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003CitemSnapshot_003E5__3.Data != null)
					{
						_003C_003E4__this._staticDataCache.Items[itemId] = ItemEntityMapper.ToEntity(_003CitemSnapshot_003E5__3.Data);
						result = ItemEntityMapper.ToEntity(_003CitemSnapshot_003E5__3.Data);
					}
					else
					{
						result = null;
					}
					end_IL_0010:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					Console.WriteLine("Error fetching item " + itemId + ": " + _003Cex_003E5__5.Message);
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
	private sealed class _003CGetByIdsAsync_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<global::System.Collections.Generic.IReadOnlyList<Item?>> _003C_003Et__builder;

		public global::System.Collections.Generic.IEnumerable<string> itemIds;

		public ItemRepository _003C_003E4__this;

		private List<global::System.Threading.Tasks.Task<Item>> _003CtasksItems_003E5__1;

		private List<global::System.Threading.Tasks.Task<Item>> _003CtasksGears_003E5__2;

		private List<global::System.Threading.Tasks.Task<Item>> _003CtasksTalents_003E5__3;

		private List<global::System.Threading.Tasks.Task<Item>> _003Ctasks_003E5__4;

		private Item[] _003Citems_003E5__5;

		private List<Item> _003CfilteredItems_003E5__6;

		private global::System.Collections.Generic.IReadOnlyList<Item?> _003CreadOnlyMoves_003E5__7;

		private Item[] _003C_003Es__8;

		private TaskAwaiter<Item[]> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			global::System.Collections.Generic.IReadOnlyList<Item> result;
			try
			{
				TaskAwaiter<Item[]> awaiter;
				if (num != 0)
				{
					_003CtasksItems_003E5__1 = Enumerable.ToList<global::System.Threading.Tasks.Task<Item>>(Enumerable.Select<string, global::System.Threading.Tasks.Task<Item>>(itemIds, (Func<string, global::System.Threading.Tasks.Task<Item>>)([CompilerGenerated] (string id) => _003C_003E4__this.GetByIdAsync(id))));
					_003CtasksGears_003E5__2 = Enumerable.ToList<global::System.Threading.Tasks.Task<Item>>(Enumerable.Select<string, global::System.Threading.Tasks.Task<Item>>(itemIds, (Func<string, global::System.Threading.Tasks.Task<Item>>)([CompilerGenerated] (string id) => _003C_003E4__this.GetGearByIdAsync(id))));
					_003CtasksTalents_003E5__3 = Enumerable.ToList<global::System.Threading.Tasks.Task<Item>>(Enumerable.Select<string, global::System.Threading.Tasks.Task<Item>>(itemIds, (Func<string, global::System.Threading.Tasks.Task<Item>>)([CompilerGenerated] (string id) => _003C_003E4__this.GetTalentByIdAsync(id))));
					_003Ctasks_003E5__4 = Enumerable.ToList<global::System.Threading.Tasks.Task<Item>>(Enumerable.Concat<global::System.Threading.Tasks.Task<Item>>(Enumerable.Concat<global::System.Threading.Tasks.Task<Item>>((global::System.Collections.Generic.IEnumerable<global::System.Threading.Tasks.Task<Item>>)_003CtasksItems_003E5__1, (global::System.Collections.Generic.IEnumerable<global::System.Threading.Tasks.Task<Item>>)_003CtasksGears_003E5__2), (global::System.Collections.Generic.IEnumerable<global::System.Threading.Tasks.Task<Item>>)_003CtasksTalents_003E5__3));
					awaiter = global::System.Threading.Tasks.Task.WhenAll<Item>((global::System.Collections.Generic.IEnumerable<global::System.Threading.Tasks.Task<Item>>)_003Ctasks_003E5__4).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGetByIdsAsync_003Ed__12 _003CGetByIdsAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Item[]>, _003CGetByIdsAsync_003Ed__12>(ref awaiter, ref _003CGetByIdsAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Item[]>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__8 = awaiter.GetResult();
				_003Citems_003E5__5 = _003C_003Es__8;
				_003C_003Es__8 = null;
				_003CfilteredItems_003E5__6 = Enumerable.ToList<Item>(Enumerable.Where<Item>((global::System.Collections.Generic.IEnumerable<Item>)_003Citems_003E5__5, (Func<Item, bool>)((Item item) => item != null)));
				_003CreadOnlyMoves_003E5__7 = (global::System.Collections.Generic.IReadOnlyList<Item?>)_003CfilteredItems_003E5__6.AsReadOnly();
				result = _003CreadOnlyMoves_003E5__7;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CtasksItems_003E5__1 = null;
				_003CtasksGears_003E5__2 = null;
				_003CtasksTalents_003E5__3 = null;
				_003Ctasks_003E5__4 = null;
				_003Citems_003E5__5 = null;
				_003CfilteredItems_003E5__6 = null;
				_003CreadOnlyMoves_003E5__7 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CtasksItems_003E5__1 = null;
			_003CtasksGears_003E5__2 = null;
			_003CtasksTalents_003E5__3 = null;
			_003Ctasks_003E5__4 = null;
			_003Citems_003E5__5 = null;
			_003CfilteredItems_003E5__6 = null;
			_003CreadOnlyMoves_003E5__7 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetByTypeAsync_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<global::System.Collections.Generic.IReadOnlyList<Item>> _003C_003Et__builder;

		public ItemType type;

		public ItemRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass13_0 _003C_003E8__1;

		private List<Item> _003Citems_003E5__2;

		private ItemType _003C_003Es__3;

		private TaskAwaiter<IReadOnlyDictionary<string, Item>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			global::System.Collections.Generic.IReadOnlyList<Item> result;
			try
			{
				TaskAwaiter<IReadOnlyDictionary<string, Item>> awaiter2;
				TaskAwaiter<IReadOnlyDictionary<string, Item>> awaiter;
				TaskAwaiter<IReadOnlyDictionary<string, Item>> awaiter3;
				switch (num)
				{
				default:
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass13_0();
					_003C_003E8__1.type = type;
					ItemType itemType = _003C_003E8__1.type;
					_003C_003Es__3 = itemType;
					ItemType itemType2 = _003C_003Es__3;
					if (itemType2 != ItemType.gear)
					{
						if (itemType2 == ItemType.talent)
						{
							awaiter2 = _003C_003E4__this.GetAllTalentsAsync().GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter2;
								_003CGetByTypeAsync_003Ed__13 _003CGetByTypeAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IReadOnlyDictionary<string, Item>>, _003CGetByTypeAsync_003Ed__13>(ref awaiter2, ref _003CGetByTypeAsync_003Ed__);
								return;
							}
							goto IL_013f;
						}
						awaiter = _003C_003E4__this.GetAllItemsAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = awaiter;
							_003CGetByTypeAsync_003Ed__13 _003CGetByTypeAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IReadOnlyDictionary<string, Item>>, _003CGetByTypeAsync_003Ed__13>(ref awaiter, ref _003CGetByTypeAsync_003Ed__);
							return;
						}
						goto IL_01aa;
					}
					awaiter3 = _003C_003E4__this.GetAllGearsAsync().GetAwaiter();
					if (!awaiter3.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter3;
						_003CGetByTypeAsync_003Ed__13 _003CGetByTypeAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IReadOnlyDictionary<string, Item>>, _003CGetByTypeAsync_003Ed__13>(ref awaiter3, ref _003CGetByTypeAsync_003Ed__);
						return;
					}
					goto IL_00d1;
				}
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<IReadOnlyDictionary<string, Item>>);
					num = (_003C_003E1__state = -1);
					goto IL_00d1;
				case 1:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<IReadOnlyDictionary<string, Item>>);
					num = (_003C_003E1__state = -1);
					goto IL_013f;
				case 2:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IReadOnlyDictionary<string, Item>>);
						num = (_003C_003E1__state = -1);
						goto IL_01aa;
					}
					IL_01aa:
					awaiter.GetResult();
					break;
					IL_00d1:
					awaiter3.GetResult();
					break;
					IL_013f:
					awaiter2.GetResult();
					break;
				}
				_003Citems_003E5__2 = Enumerable.ToList<Item>(Enumerable.Where<Item>((global::System.Collections.Generic.IEnumerable<Item>)_003C_003E4__this._staticDataCache.Items.Values, (Func<Item, bool>)((Item i) => i.ItemType == _003C_003E8__1.type)));
				result = (global::System.Collections.Generic.IReadOnlyList<Item>)_003Citems_003E5__2.AsReadOnly();
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Citems_003E5__2 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Citems_003E5__2 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetGearByIdAsync_003Ed__10 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Item> _003C_003Et__builder;

		public string itemId;

		public ItemRepository _003C_003E4__this;

		private bool _003CcacheCheck_003E5__1;

		private Item _003Citem_003E5__2;

		private IDocumentSnapshot<FirestoreItemDTO> _003CitemSnapshot_003E5__3;

		private IDocumentSnapshot<FirestoreItemDTO> _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<IDocumentSnapshot<FirestoreItemDTO>> _003C_003Eu__1;

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
			Item result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IDocumentSnapshot<FirestoreItemDTO>> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<FirestoreItemDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_00d8;
					}
					_003CcacheCheck_003E5__1 = _003C_003E4__this._staticDataCache.Gears.TryGetValue(itemId, ref _003Citem_003E5__2);
					if (!_003CcacheCheck_003E5__1)
					{
						awaiter = _003C_003E4__this._firestore.GetCollection(_003C_003E4__this.CollectionNameGears).GetDocument(itemId).GetDocumentSnapshotAsync<FirestoreItemDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetGearByIdAsync_003Ed__10 _003CGetGearByIdAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestoreItemDTO>>, _003CGetGearByIdAsync_003Ed__10>(ref awaiter, ref _003CGetGearByIdAsync_003Ed__);
							return;
						}
						goto IL_00d8;
					}
					result = _003Citem_003E5__2;
					goto end_IL_0010;
					IL_00d8:
					_003C_003Es__4 = awaiter.GetResult();
					_003CitemSnapshot_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003CitemSnapshot_003E5__3.Data != null)
					{
						_003C_003E4__this._staticDataCache.Gears[itemId] = ItemEntityMapper.ToEntity(_003CitemSnapshot_003E5__3.Data);
						result = ItemEntityMapper.ToEntity(_003CitemSnapshot_003E5__3.Data);
					}
					else
					{
						result = null;
					}
					end_IL_0010:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					Console.WriteLine("Error fetching item " + itemId + ": " + _003Cex_003E5__5.Message);
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
	private sealed class _003CGetItemsByTypeAndLevel_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<global::System.Collections.Generic.IReadOnlyList<Item>> _003C_003Et__builder;

		public List<ItemType> itemTypes;

		public int playerLevel;

		public ItemRepository _003C_003E4__this;

		private _003C_003Ec__DisplayClass14_0 _003C_003E8__1;

		private bool _003CneedsItems_003E5__2;

		private bool _003CneedsGears_003E5__3;

		private bool _003CneedsTalents_003E5__4;

		private List<Item> _003Citems_003E5__5;

		private TaskAwaiter<IReadOnlyDictionary<string, Item>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			global::System.Collections.Generic.IReadOnlyList<Item> result;
			try
			{
				TaskAwaiter<IReadOnlyDictionary<string, Item>> awaiter3;
				TaskAwaiter<IReadOnlyDictionary<string, Item>> awaiter2;
				TaskAwaiter<IReadOnlyDictionary<string, Item>> awaiter;
				switch (num)
				{
				default:
					_003C_003E8__1 = new _003C_003Ec__DisplayClass14_0();
					_003C_003E8__1.itemTypes = itemTypes;
					_003C_003E8__1.playerLevel = playerLevel;
					_003CneedsItems_003E5__2 = Enumerable.Any<ItemType>((global::System.Collections.Generic.IEnumerable<ItemType>)_003C_003E8__1.itemTypes, (Func<ItemType, bool>)((ItemType t) => t != ItemType.gear && t != ItemType.talent));
					_003CneedsGears_003E5__3 = _003C_003E8__1.itemTypes.Contains(ItemType.gear);
					_003CneedsTalents_003E5__4 = _003C_003E8__1.itemTypes.Contains(ItemType.talent);
					if (_003CneedsItems_003E5__2)
					{
						awaiter3 = _003C_003E4__this.GetAllItemsAsync().GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CGetItemsByTypeAndLevel_003Ed__14 _003CGetItemsByTypeAndLevel_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IReadOnlyDictionary<string, Item>>, _003CGetItemsByTypeAndLevel_003Ed__14>(ref awaiter3, ref _003CGetItemsByTypeAndLevel_003Ed__);
							return;
						}
						goto IL_0123;
					}
					goto IL_012b;
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<IReadOnlyDictionary<string, Item>>);
					num = (_003C_003E1__state = -1);
					goto IL_0123;
				case 1:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<IReadOnlyDictionary<string, Item>>);
					num = (_003C_003E1__state = -1);
					goto IL_0198;
				case 2:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IReadOnlyDictionary<string, Item>>);
						num = (_003C_003E1__state = -1);
						goto IL_020d;
					}
					IL_01a0:
					if (!_003CneedsTalents_003E5__4)
					{
						break;
					}
					awaiter = _003C_003E4__this.GetAllTalentsAsync().GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = awaiter;
						_003CGetItemsByTypeAndLevel_003Ed__14 _003CGetItemsByTypeAndLevel_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IReadOnlyDictionary<string, Item>>, _003CGetItemsByTypeAndLevel_003Ed__14>(ref awaiter, ref _003CGetItemsByTypeAndLevel_003Ed__);
						return;
					}
					goto IL_020d;
					IL_012b:
					if (_003CneedsGears_003E5__3)
					{
						awaiter2 = _003C_003E4__this.GetAllGearsAsync().GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter2;
							_003CGetItemsByTypeAndLevel_003Ed__14 _003CGetItemsByTypeAndLevel_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IReadOnlyDictionary<string, Item>>, _003CGetItemsByTypeAndLevel_003Ed__14>(ref awaiter2, ref _003CGetItemsByTypeAndLevel_003Ed__);
							return;
						}
						goto IL_0198;
					}
					goto IL_01a0;
					IL_020d:
					awaiter.GetResult();
					break;
					IL_0198:
					awaiter2.GetResult();
					goto IL_01a0;
					IL_0123:
					awaiter3.GetResult();
					goto IL_012b;
				}
				_003Citems_003E5__5 = new List<Item>();
				if (_003CneedsItems_003E5__2)
				{
					_003Citems_003E5__5.AddRange(Enumerable.Where<Item>(Enumerable.Where<Item>((global::System.Collections.Generic.IEnumerable<Item>)_003C_003E4__this._staticDataCache.Items.Values, (Func<Item, bool>)((Item i) => _003C_003E8__1.itemTypes.Contains(i.ItemType))), (Func<Item, bool>)((Item i) => (i.Requirements?.LevelRequirement?.PlayerLevelRequired).GetValueOrDefault(1) <= _003C_003E8__1.playerLevel)));
				}
				if (_003CneedsGears_003E5__3)
				{
					_003Citems_003E5__5.AddRange(Enumerable.Where<Item>(Enumerable.Where<Item>((global::System.Collections.Generic.IEnumerable<Item>)_003C_003E4__this._staticDataCache.Gears.Values, (Func<Item, bool>)((Item i) => _003C_003E8__1.itemTypes.Contains(i.ItemType))), (Func<Item, bool>)((Item i) => (i.Requirements?.LevelRequirement?.PlayerLevelRequired).GetValueOrDefault(1) <= _003C_003E8__1.playerLevel)));
				}
				if (_003CneedsTalents_003E5__4)
				{
					_003Citems_003E5__5.AddRange(Enumerable.Where<Item>(Enumerable.Where<Item>((global::System.Collections.Generic.IEnumerable<Item>)_003C_003E4__this._staticDataCache.Talents.Values, (Func<Item, bool>)((Item i) => _003C_003E8__1.itemTypes.Contains(i.ItemType))), (Func<Item, bool>)((Item i) => (i.Requirements?.LevelRequirement?.PlayerLevelRequired).GetValueOrDefault(1) <= _003C_003E8__1.playerLevel)));
				}
				result = (global::System.Collections.Generic.IReadOnlyList<Item>)_003Citems_003E5__5.AsReadOnly();
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Citems_003E5__5 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Citems_003E5__5 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetTalentByIdAsync_003Ed__11 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<Item> _003C_003Et__builder;

		public string itemId;

		public ItemRepository _003C_003E4__this;

		private bool _003CcacheCheck_003E5__1;

		private Item _003Citem_003E5__2;

		private IDocumentSnapshot<FirestoreItemDTO> _003CitemSnapshot_003E5__3;

		private IDocumentSnapshot<FirestoreItemDTO> _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<IDocumentSnapshot<FirestoreItemDTO>> _003C_003Eu__1;

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
			Item result;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<IDocumentSnapshot<FirestoreItemDTO>> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<IDocumentSnapshot<FirestoreItemDTO>>);
						num = (_003C_003E1__state = -1);
						goto IL_00d8;
					}
					_003CcacheCheck_003E5__1 = _003C_003E4__this._staticDataCache.Talents.TryGetValue(itemId, ref _003Citem_003E5__2);
					if (!_003CcacheCheck_003E5__1)
					{
						awaiter = _003C_003E4__this._firestore.GetCollection(_003C_003E4__this.CollectionNameTalents).GetDocument(itemId).GetDocumentSnapshotAsync<FirestoreItemDTO>((Source)0)
							.GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGetTalentByIdAsync_003Ed__11 _003CGetTalentByIdAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IDocumentSnapshot<FirestoreItemDTO>>, _003CGetTalentByIdAsync_003Ed__11>(ref awaiter, ref _003CGetTalentByIdAsync_003Ed__);
							return;
						}
						goto IL_00d8;
					}
					result = _003Citem_003E5__2;
					goto end_IL_0010;
					IL_00d8:
					_003C_003Es__4 = awaiter.GetResult();
					_003CitemSnapshot_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003CitemSnapshot_003E5__3.Data != null)
					{
						_003C_003E4__this._staticDataCache.Talents[itemId] = ItemEntityMapper.ToEntity(_003CitemSnapshot_003E5__3.Data);
						result = ItemEntityMapper.ToEntity(_003CitemSnapshot_003E5__3.Data);
					}
					else
					{
						result = null;
					}
					end_IL_0010:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					Console.WriteLine("Error fetching item " + itemId + ": " + _003Cex_003E5__5.Message);
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

	private readonly string CollectionName = "items";

	private readonly string CollectionNameGears = "gears";

	private readonly string CollectionNameTalents = "talents";

	public ItemRepository(IStaticDataCacheService staticDataCache, IFirebaseFirestore firestore)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		_staticDataCache = staticDataCache ?? throw new ArgumentNullException("staticDataCache");
		_firestore = firestore ?? throw new ArgumentNullException("firestore");
	}

	[AsyncStateMachine(typeof(_003CGetAllItemsAsync_003Ed__6))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<IReadOnlyDictionary<string, Item>> GetAllItemsAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (_staticDataCache.ItemsFullyLoaded)
		{
			return (IReadOnlyDictionary<string, Item>)(object)_staticDataCache.Items;
		}
		try
		{
			global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreItemDTO>> enumerator = (await ((IQuery)_firestore.GetCollection(CollectionName)).GetDocumentsAsync<FirestoreItemDTO>((Source)0)).Documents.GetEnumerator();
			try
			{
				while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
				{
					IDocumentSnapshot<FirestoreItemDTO> doc = enumerator.Current;
					if (doc.Data != null)
					{
						Item item = ItemEntityMapper.ToEntity(doc.Data);
						if (!string.IsNullOrEmpty(item.ID))
						{
							_staticDataCache.Items[item.ID] = item;
						}
					}
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator)?.Dispose();
			}
			_staticDataCache.SetItemsFullyLoaded();
			return (IReadOnlyDictionary<string, Item>)(object)_staticDataCache.Items;
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine("Error fetching all items: " + ex.Message);
			return (IReadOnlyDictionary<string, Item>)(object)_staticDataCache.Items;
		}
	}

	[AsyncStateMachine(typeof(_003CGetAllTalentsAsync_003Ed__7))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<IReadOnlyDictionary<string, Item>> GetAllTalentsAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (_staticDataCache.TalentsFullyLoaded)
		{
			return (IReadOnlyDictionary<string, Item>)(object)_staticDataCache.Talents;
		}
		try
		{
			global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreItemDTO>> enumerator = (await ((IQuery)_firestore.GetCollection(CollectionNameTalents)).GetDocumentsAsync<FirestoreItemDTO>((Source)0)).Documents.GetEnumerator();
			try
			{
				while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
				{
					IDocumentSnapshot<FirestoreItemDTO> doc = enumerator.Current;
					if (doc.Data != null)
					{
						Item item = ItemEntityMapper.ToEntity(doc.Data);
						if (!string.IsNullOrEmpty(item.ID))
						{
							_staticDataCache.Talents[item.ID] = item;
						}
					}
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator)?.Dispose();
			}
			_staticDataCache.SetTalentsFullyLoaded();
			return (IReadOnlyDictionary<string, Item>)(object)_staticDataCache.Talents;
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine("Error fetching all items: " + ex.Message);
			return (IReadOnlyDictionary<string, Item>)(object)_staticDataCache.Talents;
		}
	}

	[AsyncStateMachine(typeof(_003CGetAllGearsAsync_003Ed__8))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<IReadOnlyDictionary<string, Item>> GetAllGearsAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (_staticDataCache.GearsFullyLoaded)
		{
			return (IReadOnlyDictionary<string, Item>)(object)_staticDataCache.Gears;
		}
		try
		{
			global::System.Collections.Generic.IEnumerator<IDocumentSnapshot<FirestoreItemDTO>> enumerator = (await ((IQuery)_firestore.GetCollection(CollectionNameGears)).GetDocumentsAsync<FirestoreItemDTO>((Source)0)).Documents.GetEnumerator();
			try
			{
				while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
				{
					IDocumentSnapshot<FirestoreItemDTO> doc = enumerator.Current;
					if (doc.Data != null)
					{
						Item item = ItemEntityMapper.ToEntity(doc.Data);
						if (!string.IsNullOrEmpty(item.ID))
						{
							_staticDataCache.Gears[item.ID] = item;
						}
					}
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator)?.Dispose();
			}
			_staticDataCache.SetGearsFullyLoaded();
			return (IReadOnlyDictionary<string, Item>)(object)_staticDataCache.Gears;
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine("Error fetching all items: " + ex.Message);
			return (IReadOnlyDictionary<string, Item>)(object)_staticDataCache.Gears;
		}
	}

	[AsyncStateMachine(typeof(_003CGetByIdAsync_003Ed__9))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Item?> GetByIdAsync(string itemId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Item item = default(Item);
			if (_staticDataCache.Items.TryGetValue(itemId, ref item))
			{
				return item;
			}
			IDocumentSnapshot<FirestoreItemDTO> itemSnapshot = await _firestore.GetCollection(CollectionName).GetDocument(itemId).GetDocumentSnapshotAsync<FirestoreItemDTO>((Source)0);
			if (itemSnapshot.Data != null)
			{
				_staticDataCache.Items[itemId] = ItemEntityMapper.ToEntity(itemSnapshot.Data);
				return ItemEntityMapper.ToEntity(itemSnapshot.Data);
			}
			return null;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error fetching item " + itemId + ": " + ex.Message);
			return null;
		}
	}

	[AsyncStateMachine(typeof(_003CGetGearByIdAsync_003Ed__10))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Item?> GetGearByIdAsync(string itemId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Item item = default(Item);
			if (_staticDataCache.Gears.TryGetValue(itemId, ref item))
			{
				return item;
			}
			IDocumentSnapshot<FirestoreItemDTO> itemSnapshot = await _firestore.GetCollection(CollectionNameGears).GetDocument(itemId).GetDocumentSnapshotAsync<FirestoreItemDTO>((Source)0);
			if (itemSnapshot.Data != null)
			{
				_staticDataCache.Gears[itemId] = ItemEntityMapper.ToEntity(itemSnapshot.Data);
				return ItemEntityMapper.ToEntity(itemSnapshot.Data);
			}
			return null;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error fetching item " + itemId + ": " + ex.Message);
			return null;
		}
	}

	[AsyncStateMachine(typeof(_003CGetTalentByIdAsync_003Ed__11))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<Item?> GetTalentByIdAsync(string itemId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Item item = default(Item);
			if (_staticDataCache.Talents.TryGetValue(itemId, ref item))
			{
				return item;
			}
			IDocumentSnapshot<FirestoreItemDTO> itemSnapshot = await _firestore.GetCollection(CollectionNameTalents).GetDocument(itemId).GetDocumentSnapshotAsync<FirestoreItemDTO>((Source)0);
			if (itemSnapshot.Data != null)
			{
				_staticDataCache.Talents[itemId] = ItemEntityMapper.ToEntity(itemSnapshot.Data);
				return ItemEntityMapper.ToEntity(itemSnapshot.Data);
			}
			return null;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error fetching item " + itemId + ": " + ex.Message);
			return null;
		}
	}

	[AsyncStateMachine(typeof(_003CGetByIdsAsync_003Ed__12))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<global::System.Collections.Generic.IReadOnlyList<Item?>> GetByIdsAsync(global::System.Collections.Generic.IEnumerable<string> itemIds)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		List<global::System.Threading.Tasks.Task<Item>> tasksItems = Enumerable.ToList<global::System.Threading.Tasks.Task<Item>>(Enumerable.Select<string, global::System.Threading.Tasks.Task<Item>>(itemIds, (Func<string, global::System.Threading.Tasks.Task<Item>>)([CompilerGenerated] (string id) => GetByIdAsync(id))));
		List<global::System.Threading.Tasks.Task<Item>> tasksGears = Enumerable.ToList<global::System.Threading.Tasks.Task<Item>>(Enumerable.Select<string, global::System.Threading.Tasks.Task<Item>>(itemIds, (Func<string, global::System.Threading.Tasks.Task<Item>>)([CompilerGenerated] (string id) => GetGearByIdAsync(id))));
		List<global::System.Threading.Tasks.Task<Item>> tasksTalents = Enumerable.ToList<global::System.Threading.Tasks.Task<Item>>(Enumerable.Select<string, global::System.Threading.Tasks.Task<Item>>(itemIds, (Func<string, global::System.Threading.Tasks.Task<Item>>)([CompilerGenerated] (string id) => GetTalentByIdAsync(id))));
		List<global::System.Threading.Tasks.Task<Item>> tasks = Enumerable.ToList<global::System.Threading.Tasks.Task<Item>>(Enumerable.Concat<global::System.Threading.Tasks.Task<Item>>(Enumerable.Concat<global::System.Threading.Tasks.Task<Item>>((global::System.Collections.Generic.IEnumerable<global::System.Threading.Tasks.Task<Item>>)tasksItems, (global::System.Collections.Generic.IEnumerable<global::System.Threading.Tasks.Task<Item>>)tasksGears), (global::System.Collections.Generic.IEnumerable<global::System.Threading.Tasks.Task<Item>>)tasksTalents));
		List<Item> filteredItems = Enumerable.ToList<Item>(Enumerable.Where<Item>((global::System.Collections.Generic.IEnumerable<Item>)(await global::System.Threading.Tasks.Task.WhenAll<Item>((global::System.Collections.Generic.IEnumerable<global::System.Threading.Tasks.Task<Item>>)tasks)), (Func<Item, bool>)((Item item) => item != null)));
		return (global::System.Collections.Generic.IReadOnlyList<Item?>)filteredItems.AsReadOnly();
	}

	[AsyncStateMachine(typeof(_003CGetByTypeAsync_003Ed__13))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<global::System.Collections.Generic.IReadOnlyList<Item>> GetByTypeAsync(ItemType type)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		switch (type)
		{
		case ItemType.gear:
			await GetAllGearsAsync();
			break;
		case ItemType.talent:
			await GetAllTalentsAsync();
			break;
		default:
			await GetAllItemsAsync();
			break;
		}
		List<Item> items = Enumerable.ToList<Item>(Enumerable.Where<Item>((global::System.Collections.Generic.IEnumerable<Item>)_staticDataCache.Items.Values, (Func<Item, bool>)((Item i) => i.ItemType == type)));
		return (global::System.Collections.Generic.IReadOnlyList<Item>)items.AsReadOnly();
	}

	[AsyncStateMachine(typeof(_003CGetItemsByTypeAndLevel_003Ed__14))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<global::System.Collections.Generic.IReadOnlyList<Item>> GetItemsByTypeAndLevel(List<ItemType> itemTypes, int playerLevel)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		List<ItemType> itemTypes2 = itemTypes;
		bool needsItems = Enumerable.Any<ItemType>((global::System.Collections.Generic.IEnumerable<ItemType>)itemTypes2, (Func<ItemType, bool>)((ItemType t) => t != ItemType.gear && t != ItemType.talent));
		bool needsGears = itemTypes2.Contains(ItemType.gear);
		bool needsTalents = itemTypes2.Contains(ItemType.talent);
		if (needsItems)
		{
			await GetAllItemsAsync();
		}
		if (needsGears)
		{
			await GetAllGearsAsync();
		}
		if (needsTalents)
		{
			await GetAllTalentsAsync();
		}
		List<Item> items = new List<Item>();
		if (needsItems)
		{
			items.AddRange(Enumerable.Where<Item>(Enumerable.Where<Item>((global::System.Collections.Generic.IEnumerable<Item>)_staticDataCache.Items.Values, (Func<Item, bool>)((Item i) => itemTypes2.Contains(i.ItemType))), (Func<Item, bool>)((Item i) => (i.Requirements?.LevelRequirement?.PlayerLevelRequired).GetValueOrDefault(1) <= playerLevel)));
		}
		if (needsGears)
		{
			items.AddRange(Enumerable.Where<Item>(Enumerable.Where<Item>((global::System.Collections.Generic.IEnumerable<Item>)_staticDataCache.Gears.Values, (Func<Item, bool>)((Item i) => itemTypes2.Contains(i.ItemType))), (Func<Item, bool>)((Item i) => (i.Requirements?.LevelRequirement?.PlayerLevelRequired).GetValueOrDefault(1) <= playerLevel)));
		}
		if (needsTalents)
		{
			items.AddRange(Enumerable.Where<Item>(Enumerable.Where<Item>((global::System.Collections.Generic.IEnumerable<Item>)_staticDataCache.Talents.Values, (Func<Item, bool>)((Item i) => itemTypes2.Contains(i.ItemType))), (Func<Item, bool>)((Item i) => (i.Requirements?.LevelRequirement?.PlayerLevelRequired).GetValueOrDefault(1) <= playerLevel)));
		}
		return (global::System.Collections.Generic.IReadOnlyList<Item>)items.AsReadOnly();
	}
}
