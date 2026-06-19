using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel;
using SpiritSummoner.Application.Events;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Items;
using SpiritSummoner.Application.UseCases.Shop;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Enums.Common;
using SpiritSummoner.Domain.Enums.Items;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Presentation.Models;
using SpiritSummoner.Presentation.Navigation;

namespace SpiritSummoner.Presentation.ViewModels.Pouch;

public class PouchViewModel : ObservableObject, ILoadableViewModel, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003C_003COnStateChanged_003Eb__38_0_003Ed : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public PouchViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this.RefreshInventoryItems().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003C_003COnStateChanged_003Eb__38_0_003Ed _003C_003COnStateChanged_003Eb__38_0_003Ed = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003COnStateChanged_003Eb__38_0_003Ed>(ref awaiter, ref _003C_003COnStateChanged_003Eb__38_0_003Ed);
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
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass41_0
	{
		public Inventory inventoryItem;

		internal bool _003CLoadInventoryItems_003Eb__0(Item t)
		{
			return t.ID == inventoryItem.Name;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass50_0
	{
		public List<ItemModel> result;

		public PouchViewModel _003C_003E4__this;

		internal void _003CApplyFiltersAndSort_003Eb__2()
		{
			_003C_003E4__this.DisplayedItems = new ObservableCollection<ItemModel>(result);
			_003C_003E4__this.FilteredItemCount = result.Count;
		}
	}

	[CompilerGenerated]
	private sealed class _003CApplyFiltersAndSort_003Ed__50 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PouchViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected O, but got Unknown
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = global::System.Threading.Tasks.Task.Run((Action)([CompilerGenerated] () =>
					{
						//IL_0117: Unknown result type (might be due to invalid IL or missing references)
						//IL_0121: Expected O, but got Unknown
						_003C_003Ec__DisplayClass50_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass50_0
						{
							_003C_003E4__this = _003C_003E4__this
						};
						global::System.Collections.Generic.IEnumerable<ItemModel> enumerable = Enumerable.Where<ItemModel>((global::System.Collections.Generic.IEnumerable<ItemModel>)_003C_003E4__this._allItems, (Func<ItemModel, bool>)([CompilerGenerated] (ItemModel item) =>
						{
							bool flag = _003C_003E4__this.SelectedFilter == "all" || item.Type == _003C_003E4__this.SelectedFilter;
							bool flag2 = string.IsNullOrWhiteSpace(_003C_003E4__this.SearchText) || item.Name.Contains(_003C_003E4__this.SearchText, (StringComparison)5) || item.Type.Contains(_003C_003E4__this.SearchText, (StringComparison)5) || item.Rarity.Contains(_003C_003E4__this.SearchText, (StringComparison)5);
							return flag && flag2;
						}));
						SortType currentSort = _003C_003E4__this.CurrentSort;
						if (1 == 0)
						{
						}
						global::System.Collections.Generic.IEnumerable<ItemModel> enumerable2 = currentSort switch
						{
							SortType.Name => (global::System.Collections.Generic.IEnumerable<ItemModel>)Enumerable.OrderBy<ItemModel, string>(enumerable, (Func<ItemModel, string>)((ItemModel i) => i.Name)), 
							SortType.Rarity => (global::System.Collections.Generic.IEnumerable<ItemModel>)Enumerable.ThenBy<ItemModel, string>(Enumerable.OrderByDescending<ItemModel, int>(enumerable, (Func<ItemModel, int>)([CompilerGenerated] (ItemModel i) => _003C_003E4__this.GetRarityOrder(i.Rarity))), (Func<ItemModel, string>)((ItemModel i) => i.Name)), 
							SortType.Quantity => (global::System.Collections.Generic.IEnumerable<ItemModel>)Enumerable.ThenBy<ItemModel, string>(Enumerable.OrderByDescending<ItemModel, int>(enumerable, (Func<ItemModel, int>)((ItemModel i) => i.Quantity)), (Func<ItemModel, string>)((ItemModel i) => i.Name)), 
							_ => enumerable, 
						};
						if (1 == 0)
						{
						}
						global::System.Collections.Generic.IEnumerable<ItemModel> enumerable3 = enumerable2;
						CS_0024_003C_003E8__locals0.result = Enumerable.ToList<ItemModel>(enumerable3);
						MainThread.BeginInvokeOnMainThread((Action)delegate
						{
							CS_0024_003C_003E8__locals0._003C_003E4__this.DisplayedItems = new ObservableCollection<ItemModel>(CS_0024_003C_003E8__locals0.result);
							CS_0024_003C_003E8__locals0._003C_003E4__this.FilteredItemCount = CS_0024_003C_003E8__locals0.result.Count;
						});
					})).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CApplyFiltersAndSort_003Ed__50 _003CApplyFiltersAndSort_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CApplyFiltersAndSort_003Ed__50>(ref awaiter, ref _003CApplyFiltersAndSort_003Ed__);
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
	private sealed class _003CChangeSortType_003Ed__48 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string sortType;

		public PouchViewModel _003C_003E4__this;

		private SortType _003CparsedEnum_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00b8;
				}
				if (global::System.Enum.TryParse<SortType>(sortType, ref _003CparsedEnum_003E5__1) && _003C_003E4__this.CurrentSort != _003CparsedEnum_003E5__1)
				{
					_003C_003E4__this.CurrentSort = _003CparsedEnum_003E5__1;
					awaiter = _003C_003E4__this.ApplyFiltersAndSort().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CChangeSortType_003Ed__48 _003CChangeSortType_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CChangeSortType_003Ed__48>(ref awaiter, ref _003CChangeSortType_003Ed__);
						return;
					}
					goto IL_00b8;
				}
				goto end_IL_0007;
				IL_00b8:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
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
	private sealed class _003CClose_003Ed__53 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PouchViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CClose_003Ed__53 _003CClose_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CClose_003Ed__53>(ref awaiter, ref _003CClose_003Ed__);
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
	private sealed class _003CCraftItem_003Ed__46 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ItemModel item;

		public PouchViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private Result<PurchaseCraftingItemResponse> _003Cresult_003E5__3;

		private Result<PurchaseCraftingItemResponse> _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<Result<PurchaseCraftingItemResponse>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0301: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_023b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0240: Unknown result type (might be due to invalid IL or missing references)
			//IL_0248: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_021e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 3u || (item != null && !_003C_003E4__this.IsProcessingCraft))
				{
					try
					{
						TaskAwaiter awaiter;
						if ((uint)num > 2u)
						{
							if (num == 3)
							{
								awaiter = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0310;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter<Result<PurchaseCraftingItemResponse>> awaiter4;
							TaskAwaiter awaiter3;
							TaskAwaiter awaiter2;
							switch (num)
							{
							default:
								_003C_003E4__this.IsProcessingCraft = true;
								awaiter4 = _003C_003E4__this._purchaseCraftingItemUseCase.ExecuteAsync(new PurchaseCraftingItemRequest(item.Id ?? string.Empty)).GetAwaiter();
								if (!awaiter4.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter4;
									_003CCraftItem_003Ed__46 _003CCraftItem_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<PurchaseCraftingItemResponse>>, _003CCraftItem_003Ed__46>(ref awaiter4, ref _003CCraftItem_003Ed__);
									return;
								}
								goto IL_00f4;
							case 0:
								awaiter4 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<Result<PurchaseCraftingItemResponse>>);
								num = (_003C_003E1__state = -1);
								goto IL_00f4;
							case 1:
								awaiter3 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_01b9;
							case 2:
								{
									awaiter2 = _003C_003Eu__2;
									_003C_003Eu__2 = default(TaskAwaiter);
									num = (_003C_003E1__state = -1);
									goto IL_0257;
								}
								IL_0257:
								((TaskAwaiter)(ref awaiter2)).GetResult();
								break;
								IL_00f4:
								_003C_003Es__4 = awaiter4.GetResult();
								_003Cresult_003E5__3 = _003C_003Es__4;
								_003C_003Es__4 = null;
								if (_003Cresult_003E5__3.Success)
								{
									awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Success", "Crafted " + _003Cresult_003E5__3.Data?.ItemName + "!").GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
									{
										num = (_003C_003E1__state = 1);
										_003C_003Eu__2 = awaiter3;
										_003CCraftItem_003Ed__46 _003CCraftItem_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCraftItem_003Ed__46>(ref awaiter3, ref _003CCraftItem_003Ed__);
										return;
									}
									goto IL_01b9;
								}
								awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Crafting Failed", _003Cresult_003E5__3.ErrorMessage ?? "Not enough crystals!").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__2 = awaiter2;
									_003CCraftItem_003Ed__46 _003CCraftItem_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCraftItem_003Ed__46>(ref awaiter2, ref _003CCraftItem_003Ed__);
									return;
								}
								goto IL_0257;
								IL_01b9:
								((TaskAwaiter)(ref awaiter3)).GetResult();
								((ObservableObject)_003C_003E4__this).OnPropertyChanged("PlayerCrystals");
								break;
							}
							_003Cresult_003E5__3 = null;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
						}
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_0354;
						}
						_003Cex_003E5__5 = (global::System.Exception)_003C_003Es__1;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to craft item").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__2 = awaiter;
							_003CCraftItem_003Ed__46 _003CCraftItem_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCraftItem_003Ed__46>(ref awaiter, ref _003CCraftItem_003Ed__);
							return;
						}
						goto IL_0310;
						IL_0310:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine($"CraftItem error: {_003Cex_003E5__5}");
						_003Cex_003E5__5 = null;
						goto IL_0354;
						IL_0354:
						_003C_003Es__1 = null;
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsProcessingCraft = false;
						}
					}
				}
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
	private sealed class _003CLoadCraftingItems_003Ed__42 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PouchViewModel _003C_003E4__this;

		private List<ItemType> _003CitemTypes_003E5__1;

		private Result<GetShopItemsResponse> _003Cresult_003E5__2;

		private Result<GetShopItemsResponse> _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<Result<GetShopItemsResponse>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<Result<GetShopItemsResponse>> awaiter;
					if (num != 0)
					{
						List<ItemType> obj = new List<ItemType>();
						obj.Add(ItemType.crafting);
						_003CitemTypes_003E5__1 = obj;
						awaiter = _003C_003E4__this._getShopItemsUseCase.ExecuteAsync(new GetShopItemsRequest(_003CitemTypes_003E5__1)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadCraftingItems_003Ed__42 _003CLoadCraftingItems_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<GetShopItemsResponse>>, _003CLoadCraftingItems_003Ed__42>(ref awaiter, ref _003CLoadCraftingItems_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<GetShopItemsResponse>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter.GetResult();
					_003Cresult_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (_003Cresult_003E5__2.Success && _003Cresult_003E5__2.Data != null)
					{
						_003C_003E4__this._craftingItems = Enumerable.ToList<ItemModel>(Enumerable.Select<ShopItemResult, ItemModel>((global::System.Collections.Generic.IEnumerable<ShopItemResult>)_003Cresult_003E5__2.Data.Items, (Func<ShopItemResult, ItemModel>)((ShopItemResult x) => new ItemModel(x.Item))));
					}
					_003CitemTypes_003E5__1 = null;
					_003Cresult_003E5__2 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					Console.WriteLine("Error loading crafting items: " + _003Cex_003E5__4.Message);
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
	private sealed class _003CLoadDataAsync_003Ed__40 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object param;

		public PouchViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 1u || (!_003C_003E4__this._isCached && !_003C_003E4__this.IsLoading))
				{
					try
					{
						TaskAwaiter awaiter;
						if (num != 0)
						{
							if (num == 1)
							{
								awaiter = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_01a6;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter awaiter2;
							if (num != 0)
							{
								_003C_003E4__this.IsLoading = true;
								_003C_003E4__this.ErrorMessage = string.Empty;
								awaiter2 = _003C_003E4__this.LoadInventoryItems().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter2;
									_003CLoadDataAsync_003Ed__40 _003CLoadDataAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__40>(ref awaiter2, ref _003CLoadDataAsync_003Ed__);
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
							_003C_003E4__this._isCached = true;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
						}
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_01ea;
						}
						_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
						_003C_003E4__this.ErrorMessage = "Failed to load pouch data";
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to load your items. Please try again.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter;
							_003CLoadDataAsync_003Ed__40 _003CLoadDataAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__40>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
							return;
						}
						goto IL_01a6;
						IL_01a6:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine($"PouchViewModel.LoadDataAsync: {_003Cex_003E5__3}");
						_003Cex_003E5__3 = null;
						goto IL_01ea;
						IL_01ea:
						_003C_003Es__1 = null;
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsLoading = false;
						}
					}
				}
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
	private sealed class _003CLoadInventoryItems_003Ed__41 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PouchViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private GetPlayerInventoryRequest _003Crequest_003E5__3;

		private Result<GetPlayerInventoryResponse> _003Cresult_003E5__4;

		private Result<GetPlayerInventoryResponse> _003C_003Es__5;

		private List<ItemModel> _003CitemModels_003E5__6;

		private global::System.Collections.Generic.IEnumerator<Inventory> _003C_003Es__7;

		private _003C_003Ec__DisplayClass41_0 _003C_003E8__8;

		private Item _003CitemTemplate_003E5__9;

		private Spirit _003Cspirit_003E5__10;

		private int _003Cresult1_003E5__11;

		private global::System.Exception _003Cex_003E5__12;

		private TaskAwaiter<Result<GetPlayerInventoryResponse>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_04ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0508: Unknown result type (might be due to invalid IL or missing references)
			//IL_050a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0524: Unknown result type (might be due to invalid IL or missing references)
			//IL_0529: Unknown result type (might be due to invalid IL or missing references)
			//IL_0531: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0390: Unknown result type (might be due to invalid IL or missing references)
			//IL_0395: Unknown result type (might be due to invalid IL or missing references)
			//IL_039d: Unknown result type (might be due to invalid IL or missing references)
			//IL_043b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0440: Unknown result type (might be due to invalid IL or missing references)
			//IL_0448: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0402: Unknown result type (might be due to invalid IL or missing references)
			//IL_0407: Unknown result type (might be due to invalid IL or missing references)
			//IL_041c: Unknown result type (might be due to invalid IL or missing references)
			//IL_041e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0357: Unknown result type (might be due to invalid IL or missing references)
			//IL_035c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0371: Unknown result type (might be due to invalid IL or missing references)
			//IL_0373: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if ((uint)num > 2u)
				{
					if (num == 3)
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0540;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter<Result<GetPlayerInventoryResponse>> awaiter4;
					TaskAwaiter awaiter3;
					TaskAwaiter awaiter2;
					switch (num)
					{
					default:
						_003Crequest_003E5__3 = new GetPlayerInventoryRequest();
						awaiter4 = _003C_003E4__this._getPlayerInventoryUseCase.ExecuteAsync(_003Crequest_003E5__3).GetAwaiter();
						if (!awaiter4.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter4;
							_003CLoadInventoryItems_003Ed__41 _003CLoadInventoryItems_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<GetPlayerInventoryResponse>>, _003CLoadInventoryItems_003Ed__41>(ref awaiter4, ref _003CLoadInventoryItems_003Ed__);
							return;
						}
						goto IL_00b7;
					case 0:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<GetPlayerInventoryResponse>>);
						num = (_003C_003E1__state = -1);
						goto IL_00b7;
					case 1:
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_03ac;
					case 2:
						{
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0457;
						}
						IL_03b4:
						_003CitemModels_003E5__6 = null;
						break;
						IL_00b7:
						_003C_003Es__5 = awaiter4.GetResult();
						_003Cresult_003E5__4 = _003C_003Es__5;
						_003C_003Es__5 = null;
						if (_003Cresult_003E5__4.Success && _003Cresult_003E5__4.Data != null)
						{
							_003CitemModels_003E5__6 = new List<ItemModel>();
							_003C_003Es__7 = ((global::System.Collections.Generic.IEnumerable<Inventory>)_003Cresult_003E5__4.Data.PlayerInventory).GetEnumerator();
							try
							{
								while (((global::System.Collections.IEnumerator)_003C_003Es__7).MoveNext())
								{
									_003C_003E8__8 = new _003C_003Ec__DisplayClass41_0();
									_003C_003E8__8.inventoryItem = _003C_003Es__7.Current;
									_003CitemTemplate_003E5__9 = Enumerable.FirstOrDefault<Item>((global::System.Collections.Generic.IEnumerable<Item>)_003Cresult_003E5__4.Data.ItemTemplates, (Func<Item, bool>)((Item t) => t.ID == _003C_003E8__8.inventoryItem.Name));
									if (_003CitemTemplate_003E5__9 != null)
									{
										_003CitemModels_003E5__6.Add(new ItemModel(_003CitemTemplate_003E5__9, _003C_003E8__8.inventoryItem));
									}
									else if (_003C_003E8__8.inventoryItem.Name.Contains("Orb"))
									{
										_003Cspirit_003E5__10 = _003C_003E4__this._playerStateService.GetSpiritTemplate(int.TryParse(Enumerable.Last<string>((global::System.Collections.Generic.IEnumerable<string>)_003C_003E8__8.inventoryItem.Name.Split('#', (StringSplitOptions)0)), ref _003Cresult1_003E5__11) ? _003Cresult1_003E5__11 : 0);
										if (_003Cspirit_003E5__10 != null)
										{
											_003CitemModels_003E5__6.Add(new ItemModel(_003Cspirit_003E5__10, (_003Cspirit_003E5__10.Requirements?.CurrencyCost?.Amount).GetValueOrDefault(2000), _003C_003E8__8.inventoryItem.Amount));
										}
										_003Cspirit_003E5__10 = null;
									}
									else
									{
										_003CitemModels_003E5__6.Add(new ItemModel(_003C_003E8__8.inventoryItem));
									}
									_003CitemTemplate_003E5__9 = null;
									_003C_003E8__8 = null;
								}
							}
							finally
							{
								if (num < 0 && _003C_003Es__7 != null)
								{
									((global::System.IDisposable)_003C_003Es__7).Dispose();
								}
							}
							_003C_003Es__7 = null;
							_003C_003E4__this._allItems = new ObservableCollection<ItemModel>(_003CitemModels_003E5__6);
							_003C_003E4__this.TotalItemCount = ((Collection<ItemModel>)(object)_003C_003E4__this._allItems).Count;
							if (!_003C_003E4__this.IsCraftingMode)
							{
								awaiter3 = _003C_003E4__this.ApplyFiltersAndSort().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter3;
									_003CLoadInventoryItems_003Ed__41 _003CLoadInventoryItems_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadInventoryItems_003Ed__41>(ref awaiter3, ref _003CLoadInventoryItems_003Ed__);
									return;
								}
								goto IL_03ac;
							}
							goto IL_03b4;
						}
						_003C_003E4__this.ErrorMessage = _003Cresult_003E5__4.ErrorMessage ?? "Failed to load inventory";
						awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003C_003E4__this.ErrorMessage).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter2;
							_003CLoadInventoryItems_003Ed__41 _003CLoadInventoryItems_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadInventoryItems_003Ed__41>(ref awaiter2, ref _003CLoadInventoryItems_003Ed__);
							return;
						}
						goto IL_0457;
						IL_0457:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						break;
						IL_03ac:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						goto IL_03b4;
					}
					_003Crequest_003E5__3 = null;
					_003Cresult_003E5__4 = null;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_0552;
				}
				_003Cex_003E5__12 = (global::System.Exception)_003C_003Es__1;
				Console.WriteLine("Error loading inventory items: " + _003Cex_003E5__12.Message);
				_003C_003E4__this.ErrorMessage = "Failed to load inventory";
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to load your items. Please try again.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 3);
					_003C_003Eu__2 = awaiter;
					_003CLoadInventoryItems_003Ed__41 _003CLoadInventoryItems_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadInventoryItems_003Ed__41>(ref awaiter, ref _003CLoadInventoryItems_003Ed__);
					return;
				}
				goto IL_0540;
				IL_0540:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__12 = null;
				goto IL_0552;
				IL_0552:
				_003C_003Es__1 = null;
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
	private sealed class _003CRefreshInventoryItems_003Ed__43 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PouchViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this.LoadInventoryItems().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CRefreshInventoryItems_003Ed__43 _003CRefreshInventoryItems_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRefreshInventoryItems_003Ed__43>(ref awaiter, ref _003CRefreshInventoryItems_003Ed__);
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
				if (_003C_003E4__this.IsCraftingMode)
				{
					_003C_003E4__this.ApplyCraftingDisplay();
				}
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
	private sealed class _003CSelectFilter_003Ed__47 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string filterId;

		public PouchViewModel _003C_003E4__this;

		private global::System.Collections.Generic.IEnumerator<FilterChipModel> _003C_003Es__1;

		private FilterChipModel _003Cchip_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0126;
				}
				if (!(_003C_003E4__this.SelectedFilter == filterId))
				{
					_003C_003E4__this.SelectedFilter = filterId;
					_003C_003Es__1 = ((Collection<FilterChipModel>)(object)_003C_003E4__this.FilterChips).GetEnumerator();
					try
					{
						while (((global::System.Collections.IEnumerator)_003C_003Es__1).MoveNext())
						{
							_003Cchip_003E5__2 = _003C_003Es__1.Current;
							_003Cchip_003E5__2.IsSelected = _003Cchip_003E5__2.Id == _003C_003E4__this.SelectedFilter;
							_003Cchip_003E5__2 = null;
						}
					}
					finally
					{
						if (num < 0 && _003C_003Es__1 != null)
						{
							((global::System.IDisposable)_003C_003Es__1).Dispose();
						}
					}
					_003C_003Es__1 = null;
					awaiter = _003C_003E4__this.ApplyFiltersAndSort().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CSelectFilter_003Ed__47 _003CSelectFilter_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSelectFilter_003Ed__47>(ref awaiter, ref _003CSelectFilter_003Ed__);
						return;
					}
					goto IL_0126;
				}
				goto end_IL_0007;
				IL_0126:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
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
	private sealed class _003CShowItemDetails_003Ed__51 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ItemModel item;

		public PouchViewModel _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			try
			{
				if (item != null)
				{
					try
					{
						item.DescriptionVisible = !item.DescriptionVisible;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__1 = ex;
						_003C_003E4__this.ErrorMessage = "Failed to show item details";
						Console.WriteLine($"ShowItemDetails error: {_003Cex_003E5__1}");
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

	private readonly INavigationService _navigationService;

	private readonly IPlayerStateService _playerStateService;

	private readonly GetPlayerInventoryUseCase _getPlayerInventoryUseCase;

	private readonly GetShopItemsUseCase _getShopItemsUseCase;

	private readonly PurchaseCraftingItemUseCase _purchaseCraftingItemUseCase;

	private bool _disposed;

	private bool _isCached;

	private ObservableCollection<ItemModel> _allItems = new ObservableCollection<ItemModel>();

	private List<ItemModel> _craftingItems = new List<ItemModel>();

	[ObservableProperty]
	private ObservableCollection<ItemModel> _displayedItems = new ObservableCollection<ItemModel>();

	[ObservableProperty]
	private ObservableCollection<FilterChipModel> _filterChips = new ObservableCollection<FilterChipModel>();

	[ObservableProperty]
	[NotifyPropertyChangedFor("ItemCountText")]
	[NotifyPropertyChangedFor("HasNoItems")]
	private int _filteredItemCount = 0;

	[ObservableProperty]
	private int _totalItemCount = 0;

	[ObservableProperty]
	private string _searchText = string.Empty;

	[ObservableProperty]
	private string _selectedFilter = "all";

	[ObservableProperty]
	[NotifyPropertyChangedFor("IsSortByNameActive")]
	[NotifyPropertyChangedFor("IsSortByRarityActive")]
	[NotifyPropertyChangedFor("IsSortByQuantityActive")]
	private SortType _currentSort = SortType.Name;

	[ObservableProperty]
	private bool _isLoading;

	[ObservableProperty]
	private string _errorMessage = string.Empty;

	[ObservableProperty]
	[NotifyPropertyChangedFor("PageTitle")]
	[NotifyPropertyChangedFor("ShowFilterChips")]
	private bool _isCraftingMode;

	[ObservableProperty]
	private bool _isProcessingCraft;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<object?>? loadDataCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? toggleCraftingModeCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<ItemModel>? craftItemCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<string>? selectFilterCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<string>? changeSortTypeCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? clearSearchCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<ItemModel>? showItemDetailsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? closeCommand;

	public string ItemCountText => $"{FilteredItemCount} items found";

	public bool HasNoItems => FilteredItemCount == 0 && !IsLoading;

	public string PageTitle => IsCraftingMode ? "CRAFTING" : "POUCH";

	public bool ShowFilterChips => !IsCraftingMode;

	public long PlayerCrystals
	{
		get
		{
			Player? currentPlayer = _playerStateService.GetCurrentPlayer();
			long? obj;
			if (currentPlayer == null)
			{
				obj = null;
			}
			else
			{
				IReadOnlyDictionary<string, long> currencies = currentPlayer.Currencies;
				obj = ((currencies != null) ? new long?(CollectionExtensions.GetValueOrDefault<string, long>(currencies, "gems", 0L)) : null);
			}
			long? num = obj;
			return num.GetValueOrDefault();
		}
	}

	public bool IsSortByNameActive => CurrentSort == SortType.Name;

	public bool IsSortByRarityActive => CurrentSort == SortType.Rarity;

	public bool IsSortByQuantityActive => CurrentSort == SortType.Quantity;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<ItemModel> DisplayedItems
	{
		get
		{
			return _displayedItems;
		}
		[MemberNotNull("_displayedItems")]
		set
		{
			if (!EqualityComparer<ObservableCollection<ItemModel>>.Default.Equals(_displayedItems, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.DisplayedItems);
				_displayedItems = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.DisplayedItems);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<FilterChipModel> FilterChips
	{
		get
		{
			return _filterChips;
		}
		[MemberNotNull("_filterChips")]
		set
		{
			if (!EqualityComparer<ObservableCollection<FilterChipModel>>.Default.Equals(_filterChips, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.FilterChips);
				_filterChips = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.FilterChips);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int FilteredItemCount
	{
		get
		{
			return _filteredItemCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_filteredItemCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.FilteredItemCount);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ItemCountText);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasNoItems);
				_filteredItemCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.FilteredItemCount);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ItemCountText);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasNoItems);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int TotalItemCount
	{
		get
		{
			return _totalItemCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_totalItemCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TotalItemCount);
				_totalItemCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TotalItemCount);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string SearchText
	{
		get
		{
			return _searchText;
		}
		[MemberNotNull("_searchText")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_searchText, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SearchText);
				_searchText = value;
				OnSearchTextChanged(value);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SearchText);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string SelectedFilter
	{
		get
		{
			return _selectedFilter;
		}
		[MemberNotNull("_selectedFilter")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_selectedFilter, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SelectedFilter);
				_selectedFilter = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SelectedFilter);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public SortType CurrentSort
	{
		get
		{
			return _currentSort;
		}
		set
		{
			if (!EqualityComparer<SortType>.Default.Equals(_currentSort, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentSort);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsSortByNameActive);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsSortByRarityActive);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsSortByQuantityActive);
				_currentSort = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentSort);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsSortByNameActive);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsSortByRarityActive);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsSortByQuantityActive);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsLoading
	{
		get
		{
			return _isLoading;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isLoading, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsLoading);
				_isLoading = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsLoading);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string ErrorMessage
	{
		get
		{
			return _errorMessage;
		}
		[MemberNotNull("_errorMessage")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_errorMessage, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ErrorMessage);
				_errorMessage = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ErrorMessage);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsCraftingMode
	{
		get
		{
			return _isCraftingMode;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isCraftingMode, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsCraftingMode);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PageTitle);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowFilterChips);
				_isCraftingMode = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsCraftingMode);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PageTitle);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowFilterChips);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsProcessingCraft
	{
		get
		{
			return _isProcessingCraft;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isProcessingCraft, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsProcessingCraft);
				_isProcessingCraft = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsProcessingCraft);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<object?> LoadDataCommand
	{
		get
		{
			AsyncRelayCommand<object?>? obj = loadDataCommand;
			if (obj == null)
			{
				obj = (loadDataCommand = new AsyncRelayCommand<object>((Func<object, global::System.Threading.Tasks.Task>)LoadDataAsync));
			}
			return (IAsyncRelayCommand<object?>)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ToggleCraftingModeCommand
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			RelayCommand obj = toggleCraftingModeCommand;
			if (obj == null)
			{
				RelayCommand val = new RelayCommand(new Action(ToggleCraftingMode));
				RelayCommand val2 = val;
				toggleCraftingModeCommand = val;
				obj = val2;
			}
			return (IRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<ItemModel> CraftItemCommand => (IAsyncRelayCommand<ItemModel>)(object)(craftItemCommand ?? (craftItemCommand = new AsyncRelayCommand<ItemModel>((Func<ItemModel, global::System.Threading.Tasks.Task>)CraftItem)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<string> SelectFilterCommand => (IAsyncRelayCommand<string>)(object)(selectFilterCommand ?? (selectFilterCommand = new AsyncRelayCommand<string>((Func<string, global::System.Threading.Tasks.Task>)SelectFilter)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<string> ChangeSortTypeCommand => (IAsyncRelayCommand<string>)(object)(changeSortTypeCommand ?? (changeSortTypeCommand = new AsyncRelayCommand<string>((Func<string, global::System.Threading.Tasks.Task>)ChangeSortType)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ClearSearchCommand
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			RelayCommand obj = clearSearchCommand;
			if (obj == null)
			{
				RelayCommand val = new RelayCommand(new Action(ClearSearch));
				RelayCommand val2 = val;
				clearSearchCommand = val;
				obj = val2;
			}
			return (IRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<ItemModel> ShowItemDetailsCommand => (IAsyncRelayCommand<ItemModel>)(object)(showItemDetailsCommand ?? (showItemDetailsCommand = new AsyncRelayCommand<ItemModel>((Func<ItemModel, global::System.Threading.Tasks.Task>)ShowItemDetails)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand CloseCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = closeCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)Close);
				AsyncRelayCommand val2 = val;
				closeCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public PouchViewModel(INavigationService navigationService, IPlayerStateService playerStateService, GetPlayerInventoryUseCase getPlayerInventoryUseCase, GetShopItemsUseCase getShopItemsUseCase, PurchaseCraftingItemUseCase purchaseCraftingItemUseCase, ISpiritRepository spiritRepository)
	{
		_navigationService = navigationService;
		_playerStateService = playerStateService;
		_getPlayerInventoryUseCase = getPlayerInventoryUseCase;
		_getShopItemsUseCase = getShopItemsUseCase;
		_purchaseCraftingItemUseCase = purchaseCraftingItemUseCase;
		InitializeFilterChips();
		SubscribeToEvents();
	}

	private void SubscribeToEvents()
	{
		_playerStateService.StateChanged += OnStateChanged;
	}

	private void OnStateChanged(object? sender, StateChangedEventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		if (e.Scope != 0)
		{
			return;
		}
		if (e.ChangeType == "Inventory")
		{
			MainThread.BeginInvokeOnMainThread((Action)([AsyncStateMachine(typeof(_003C_003COnStateChanged_003Eb__38_0_003Ed))] [DebuggerStepThrough] [CompilerGenerated] () =>
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				_003C_003COnStateChanged_003Eb__38_0_003Ed _003C_003COnStateChanged_003Eb__38_0_003Ed = new _003C_003COnStateChanged_003Eb__38_0_003Ed
				{
					_003C_003Et__builder = AsyncVoidMethodBuilder.Create(),
					_003C_003E4__this = this,
					_003C_003E1__state = -1
				};
				((AsyncVoidMethodBuilder)(ref _003C_003COnStateChanged_003Eb__38_0_003Ed._003C_003Et__builder)).Start<_003C_003COnStateChanged_003Eb__38_0_003Ed>(ref _003C_003COnStateChanged_003Eb__38_0_003Ed);
			}));
		}
		else if (e.ChangeType == "Currencies")
		{
			((ObservableObject)this).OnPropertyChanged("PlayerCrystals");
		}
	}

	private void InitializeFilterChips()
	{
		ObservableCollection<FilterChipModel> obj = new ObservableCollection<FilterChipModel>();
		((Collection<FilterChipModel>)(object)obj).Add(new FilterChipModel("all", "All", "icon_items.png", isSelected: true));
		((Collection<FilterChipModel>)(object)obj).Add(new FilterChipModel("gear", "Gears", "icon_gear.webp", isSelected: false));
		((Collection<FilterChipModel>)(object)obj).Add(new FilterChipModel("talent", "Talents", "icon_talent.webp", isSelected: false));
		((Collection<FilterChipModel>)(object)obj).Add(new FilterChipModel("orb", "Core Orbs", "core_icon.png", isSelected: false));
		((Collection<FilterChipModel>)(object)obj).Add(new FilterChipModel("booster", "booster", "icon_booster.png", isSelected: false));
		((Collection<FilterChipModel>)(object)obj).Add(new FilterChipModel("unlock", "Unlocks", "icon_unlock.png", isSelected: false));
		((Collection<FilterChipModel>)(object)obj).Add(new FilterChipModel("crafting", "Crafting", "icon_crafting.png", isSelected: false));
		FilterChips = obj;
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__40))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? param = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__40 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__40();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.param = param;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__40>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadInventoryItems_003Ed__41))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadInventoryItems()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadInventoryItems_003Ed__41 _003CLoadInventoryItems_003Ed__ = new _003CLoadInventoryItems_003Ed__41();
		_003CLoadInventoryItems_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadInventoryItems_003Ed__._003C_003E4__this = this;
		_003CLoadInventoryItems_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadInventoryItems_003Ed__._003C_003Et__builder)).Start<_003CLoadInventoryItems_003Ed__41>(ref _003CLoadInventoryItems_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadInventoryItems_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadCraftingItems_003Ed__42))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadCraftingItems()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadCraftingItems_003Ed__42 _003CLoadCraftingItems_003Ed__ = new _003CLoadCraftingItems_003Ed__42();
		_003CLoadCraftingItems_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadCraftingItems_003Ed__._003C_003E4__this = this;
		_003CLoadCraftingItems_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadCraftingItems_003Ed__._003C_003Et__builder)).Start<_003CLoadCraftingItems_003Ed__42>(ref _003CLoadCraftingItems_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadCraftingItems_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRefreshInventoryItems_003Ed__43))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task RefreshInventoryItems()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRefreshInventoryItems_003Ed__43 _003CRefreshInventoryItems_003Ed__ = new _003CRefreshInventoryItems_003Ed__43();
		_003CRefreshInventoryItems_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRefreshInventoryItems_003Ed__._003C_003E4__this = this;
		_003CRefreshInventoryItems_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRefreshInventoryItems_003Ed__._003C_003Et__builder)).Start<_003CRefreshInventoryItems_003Ed__43>(ref _003CRefreshInventoryItems_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRefreshInventoryItems_003Ed__._003C_003Et__builder)).Task;
	}

	[RelayCommand]
	public void ToggleCraftingMode()
	{
		IsCraftingMode = !IsCraftingMode;
		if (IsCraftingMode)
		{
			ApplyCraftingDisplay();
		}
		else
		{
			ApplyFiltersAndSort();
		}
	}

	private void ApplyCraftingDisplay()
	{
		List<ItemModel> val = Enumerable.ToList<ItemModel>((global::System.Collections.Generic.IEnumerable<ItemModel>)_craftingItems);
		DisplayedItems = new ObservableCollection<ItemModel>(val);
		FilteredItemCount = val.Count;
		((ObservableObject)this).OnPropertyChanged("PlayerCrystals");
	}

	[AsyncStateMachine(typeof(_003CCraftItem_003Ed__46))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task CraftItem(ItemModel item)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CCraftItem_003Ed__46 _003CCraftItem_003Ed__ = new _003CCraftItem_003Ed__46();
		_003CCraftItem_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CCraftItem_003Ed__._003C_003E4__this = this;
		_003CCraftItem_003Ed__.item = item;
		_003CCraftItem_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CCraftItem_003Ed__._003C_003Et__builder)).Start<_003CCraftItem_003Ed__46>(ref _003CCraftItem_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CCraftItem_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSelectFilter_003Ed__47))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task SelectFilter(string filterId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSelectFilter_003Ed__47 _003CSelectFilter_003Ed__ = new _003CSelectFilter_003Ed__47();
		_003CSelectFilter_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSelectFilter_003Ed__._003C_003E4__this = this;
		_003CSelectFilter_003Ed__.filterId = filterId;
		_003CSelectFilter_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSelectFilter_003Ed__._003C_003Et__builder)).Start<_003CSelectFilter_003Ed__47>(ref _003CSelectFilter_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSelectFilter_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CChangeSortType_003Ed__48))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task ChangeSortType(string sortType)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CChangeSortType_003Ed__48 _003CChangeSortType_003Ed__ = new _003CChangeSortType_003Ed__48();
		_003CChangeSortType_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CChangeSortType_003Ed__._003C_003E4__this = this;
		_003CChangeSortType_003Ed__.sortType = sortType;
		_003CChangeSortType_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CChangeSortType_003Ed__._003C_003Et__builder)).Start<_003CChangeSortType_003Ed__48>(ref _003CChangeSortType_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CChangeSortType_003Ed__._003C_003Et__builder)).Task;
	}

	[RelayCommand]
	public void ClearSearch()
	{
		SearchText = string.Empty;
	}

	[AsyncStateMachine(typeof(_003CApplyFiltersAndSort_003Ed__50))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ApplyFiltersAndSort()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CApplyFiltersAndSort_003Ed__50 _003CApplyFiltersAndSort_003Ed__ = new _003CApplyFiltersAndSort_003Ed__50();
		_003CApplyFiltersAndSort_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CApplyFiltersAndSort_003Ed__._003C_003E4__this = this;
		_003CApplyFiltersAndSort_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CApplyFiltersAndSort_003Ed__._003C_003Et__builder)).Start<_003CApplyFiltersAndSort_003Ed__50>(ref _003CApplyFiltersAndSort_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CApplyFiltersAndSort_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CShowItemDetails_003Ed__51))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task ShowItemDetails(ItemModel item)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CShowItemDetails_003Ed__51 _003CShowItemDetails_003Ed__ = new _003CShowItemDetails_003Ed__51();
		_003CShowItemDetails_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CShowItemDetails_003Ed__._003C_003E4__this = this;
		_003CShowItemDetails_003Ed__.item = item;
		_003CShowItemDetails_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CShowItemDetails_003Ed__._003C_003Et__builder)).Start<_003CShowItemDetails_003Ed__51>(ref _003CShowItemDetails_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CShowItemDetails_003Ed__._003C_003Et__builder)).Task;
	}

	private int GetRarityOrder(string rarity)
	{
		if (1 == 0)
		{
		}
		int result = ((rarity == "legendary") ? 5 : ((rarity == "epic") ? 4 : ((rarity == "rare") ? 3 : ((rarity == "uncommon") ? 2 : ((rarity == "common") ? 1 : 0)))));
		if (1 == 0)
		{
		}
		return result;
	}

	[AsyncStateMachine(typeof(_003CClose_003Ed__53))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Close()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CClose_003Ed__53 _003CClose_003Ed__ = new _003CClose_003Ed__53();
		_003CClose_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CClose_003Ed__._003C_003E4__this = this;
		_003CClose_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CClose_003Ed__._003C_003Et__builder)).Start<_003CClose_003Ed__53>(ref _003CClose_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CClose_003Ed__._003C_003Et__builder)).Task;
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			_playerStateService.StateChanged -= OnStateChanged;
			_disposed = true;
			GC.SuppressFinalize((object)this);
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSearchTextChanged(string value)
	{
		ApplyFiltersAndSort();
	}
}
