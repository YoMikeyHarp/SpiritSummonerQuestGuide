using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using SpiritSummoner.Application.DTOs;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.Events;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Shop;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Enums.Common;
using SpiritSummoner.Domain.Enums.Items;
using SpiritSummoner.Domain.Enums.Shops;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Infrastructure.Caching;
using SpiritSummoner.Presentation.Models;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.BottomSheet;
using SpiritSummoner.Presentation.ViewModels.Popups;
using SpiritSummoner.Presentation.ViewModels.Pouch;
using SpiritSummoner.Presentation.ViewModels.Shared;
using SpiritSummoner.Presentation.Views.Shop.Controls;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.ViewModels.Shop;

public class ShopHubViewModel : ObservableObject, ILoadableViewModel, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass61_0
	{
		public List<ItemModel> result;

		public ShopHubViewModel _003C_003E4__this;

		internal void _003CApplyFiltersAndSort_003Eb__2()
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			((Collection<ItemModel>)(object)_003C_003E4__this.AvailableItems).Clear();
			Enumerator<ItemModel> enumerator = result.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ItemModel current = enumerator.Current;
					((Collection<ItemModel>)(object)_003C_003E4__this.AvailableItems).Add(current);
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator).Dispose();
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass63_0
	{
		public ItemModel item;

		internal void _003CShowItemPopup_003Eb__0(ItemPopupViewModel vm)
		{
			vm.IsCrafting = false;
			vm.CurrentItem = item;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass69_0
	{
		public string message;

		public string currencyIcon;

		internal void _003CShowInsufficientFundsPopup_003Eb__0(InsufficientFundsPopupViewModel vm)
		{
			vm.Infotext = message;
			vm.Infotext2 = "Earn more by questing or purchase in shop!";
			vm.Image = currencyIcon;
			vm.IsGoToQuestVisible = true;
			vm.IsGoToShopVisible = false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass70_0
	{
		public string itemName;

		public string itemImage;

		public bool isSpirit;

		internal void _003CShowPurchaseCompletion_003Eb__0(QuestRewardsPopupViewModel vm)
		{
			vm.ItemName = itemName;
			vm.ItemImage = itemImage;
			vm.IsItem = true;
			vm.CompletedText2 = (isSpirit ? ("You just unlocked the spirit " + itemName + "!") : ("You just unlocked the item " + itemName + "!"));
		}
	}

	[CompilerGenerated]
	private sealed class _003CApplyFiltersAndSort_003Ed__61 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ShopHubViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Expected O, but got Unknown
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_009d;
				}
				_003C_003E4__this.IsLoading = true;
				if (_003C_003E4__this._allShopItems.Count != 0)
				{
					awaiter = global::System.Threading.Tasks.Task.Run((Action)([CompilerGenerated] () =>
					{
						//IL_013f: Unknown result type (might be due to invalid IL or missing references)
						//IL_0149: Expected O, but got Unknown
						_003C_003Ec__DisplayClass61_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass61_0
						{
							_003C_003E4__this = _003C_003E4__this
						};
						global::System.Collections.Generic.IEnumerable<ItemModel> enumerable = Enumerable.Where<ItemModel>((global::System.Collections.Generic.IEnumerable<ItemModel>)_003C_003E4__this._allShopItems, (Func<ItemModel, bool>)([CompilerGenerated] (ItemModel item) =>
						{
							bool flag = false;
							if (_003C_003E4__this.IsGoldTabActive)
							{
								flag = item.Type == "gear" || item.Type == "talent";
							}
							else if (_003C_003E4__this.IsPremiumTabActive)
							{
								flag = item.IsSpirit;
							}
							else if (_003C_003E4__this.IsCrystalsTabActive)
							{
								flag = item.Type == "booster" || item.Type == "unlock" || item.Type == "crafting";
							}
							bool flag2 = _003C_003E4__this.SelectedFilter == "all" || item.Type == _003C_003E4__this.SelectedFilter || item.SpiritType == _003C_003E4__this.SelectedFilter;
							bool flag3 = string.IsNullOrWhiteSpace(_003C_003E4__this.SearchText) || item.Name.Contains(_003C_003E4__this.SearchText, (StringComparison)5) || item.Type.Contains(_003C_003E4__this.SearchText, (StringComparison)5) || item.Rarity.Contains(_003C_003E4__this.SearchText, (StringComparison)5) || (!string.IsNullOrEmpty(item.Class) && item.Class.Contains(_003C_003E4__this.SearchText, (StringComparison)5)) || (!string.IsNullOrEmpty(item.Class2) && item.Class2.Contains(_003C_003E4__this.SearchText, (StringComparison)5));
							return flag && flag2 && flag3;
						}));
						SortType currentSort = _003C_003E4__this.CurrentSort;
						if (1 == 0)
						{
						}
						IOrderedEnumerable<ItemModel> val = (IOrderedEnumerable<ItemModel>)(currentSort switch
						{
							SortType.Name => Enumerable.OrderBy<ItemModel, string>(enumerable, (Func<ItemModel, string>)((ItemModel i) => i.Name)), 
							SortType.Rarity => Enumerable.ThenBy<ItemModel, string>(Enumerable.OrderByDescending<ItemModel, int>(enumerable, (Func<ItemModel, int>)([CompilerGenerated] (ItemModel i) => _003C_003E4__this.GetRarityOrder(i.Rarity))), (Func<ItemModel, string>)((ItemModel i) => i.Name)), 
							SortType.Price => Enumerable.ThenBy<ItemModel, string>(Enumerable.OrderByDescending<ItemModel, string>(enumerable, (Func<ItemModel, string>)((ItemModel i) => i.Cost)), (Func<ItemModel, string>)((ItemModel i) => i.Name)), 
							_ => Enumerable.OrderBy<ItemModel, string>(enumerable, (Func<ItemModel, string>)((ItemModel i) => i.Name)), 
						});
						if (1 == 0)
						{
						}
						IOrderedEnumerable<ItemModel> val2 = val;
						CS_0024_003C_003E8__locals0.result = Enumerable.ToList<ItemModel>((global::System.Collections.Generic.IEnumerable<ItemModel>)val2);
						MainThread.BeginInvokeOnMainThread((Action)delegate
						{
							//IL_0019: Unknown result type (might be due to invalid IL or missing references)
							//IL_001e: Unknown result type (might be due to invalid IL or missing references)
							((Collection<ItemModel>)(object)CS_0024_003C_003E8__locals0._003C_003E4__this.AvailableItems).Clear();
							Enumerator<ItemModel> enumerator = CS_0024_003C_003E8__locals0.result.GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									ItemModel current = enumerator.Current;
									((Collection<ItemModel>)(object)CS_0024_003C_003E8__locals0._003C_003E4__this.AvailableItems).Add(current);
								}
							}
							finally
							{
								((global::System.IDisposable)enumerator).Dispose();
							}
						});
					})).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CApplyFiltersAndSort_003Ed__61 _003CApplyFiltersAndSort_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CApplyFiltersAndSort_003Ed__61>(ref awaiter, ref _003CApplyFiltersAndSort_003Ed__);
						return;
					}
					goto IL_009d;
				}
				goto end_IL_0007;
				IL_009d:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003C_003E4__this.IsLoading = false;
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
	private sealed class _003CChangeCurrencyTab_003Ed__55 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string currencyTab;

		public ShopHubViewModel _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 1u || !(_003C_003E4__this.CurrentCurrencyTab == currencyTab))
				{
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
								goto IL_014d;
							}
							_003C_003E4__this.CurrentCurrencyTab = currencyTab;
							_003C_003E4__this.InitializeFilterChips();
							_003C_003E4__this.SelectFilter("all");
							if (!_003C_003E4__this.IsGoldTabActive)
							{
								goto IL_00ec;
							}
							awaiter2 = _003C_003E4__this.MarkItemsAsViewed().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003CChangeCurrencyTab_003Ed__55 _003CChangeCurrencyTab_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CChangeCurrencyTab_003Ed__55>(ref awaiter2, ref _003CChangeCurrencyTab_003Ed__);
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
						goto IL_00ec;
						IL_014d:
						((TaskAwaiter)(ref awaiter)).GetResult();
						goto end_IL_0030;
						IL_00ec:
						awaiter = _003C_003E4__this.UpdateBadgeCountsAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter;
							_003CChangeCurrencyTab_003Ed__55 _003CChangeCurrencyTab_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CChangeCurrencyTab_003Ed__55>(ref awaiter, ref _003CChangeCurrencyTab_003Ed__);
							return;
						}
						goto IL_014d;
						end_IL_0030:;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__1 = ex;
						_003C_003E4__this.ErrorMessage = "Error changing tab: " + _003Cex_003E5__1.Message;
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

	[CompilerGenerated]
	private sealed class _003CChangeCurrencyTabWithAnimation_003Ed__56 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string currencyTab;

		public ShopHubViewModel _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 1u || (!_003C_003E4__this.IsTabAnimating && !(_003C_003E4__this.CurrentCurrencyTab == currencyTab)))
				{
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
								goto IL_016a;
							}
							_003C_003E4__this.IsTabAnimating = true;
							_003C_003E4__this.CurrentCurrencyTab = currencyTab;
							_003C_003E4__this.InitializeFilterChips();
							_003C_003E4__this.SelectFilter("all");
							if (!_003C_003E4__this.IsGoldTabActive)
							{
								goto IL_0109;
							}
							awaiter2 = _003C_003E4__this.MarkItemsAsViewed().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003CChangeCurrencyTabWithAnimation_003Ed__56 _003CChangeCurrencyTabWithAnimation_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CChangeCurrencyTabWithAnimation_003Ed__56>(ref awaiter2, ref _003CChangeCurrencyTabWithAnimation_003Ed__);
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
						goto IL_0109;
						IL_016a:
						((TaskAwaiter)(ref awaiter)).GetResult();
						goto end_IL_0040;
						IL_0109:
						awaiter = _003C_003E4__this.UpdateBadgeCountsAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter;
							_003CChangeCurrencyTabWithAnimation_003Ed__56 _003CChangeCurrencyTabWithAnimation_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CChangeCurrencyTabWithAnimation_003Ed__56>(ref awaiter, ref _003CChangeCurrencyTabWithAnimation_003Ed__);
							return;
						}
						goto IL_016a;
						end_IL_0040:;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__1 = ex;
						_003C_003E4__this.ErrorMessage = "Error changing tab: " + _003Cex_003E5__1.Message;
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsTabAnimating = false;
						}
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

	[CompilerGenerated]
	private sealed class _003CCraftItem_003Ed__65 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ItemModel item;

		public ShopHubViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private Result<PurchaseCraftingItemResponse> _003Cresult_003E5__3;

		private Result<PurchaseCraftingItemResponse> _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<Result<PurchaseCraftingItemResponse>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0287: Unknown result type (might be due to invalid IL or missing references)
			//IL_028c: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Unknown result type (might be due to invalid IL or missing references)
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0214: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 2u)
				{
					goto IL_0035;
				}
				TaskAwaiter awaiter;
				if (num == 3)
				{
					awaiter = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_02dc;
				}
				if (item != null)
				{
					_003C_003Es__2 = 0;
					goto IL_0035;
				}
				goto end_IL_0007;
				IL_0320:
				_003C_003Es__1 = null;
				goto end_IL_0007;
				IL_02dc:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine($"CraftItem error: {_003Cex_003E5__5}");
				_003Cex_003E5__5 = null;
				goto IL_0320;
				IL_0035:
				try
				{
					TaskAwaiter<Result<PurchaseCraftingItemResponse>> awaiter4;
					TaskAwaiter awaiter3;
					TaskAwaiter awaiter2;
					switch (num)
					{
					default:
						awaiter4 = _003C_003E4__this._purchaseCraftingItemUseCase.ExecuteAsync(new PurchaseCraftingItemRequest(item.Id ?? string.Empty)).GetAwaiter();
						if (!awaiter4.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter4;
							_003CCraftItem_003Ed__65 _003CCraftItem_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<PurchaseCraftingItemResponse>>, _003CCraftItem_003Ed__65>(ref awaiter4, ref _003CCraftItem_003Ed__);
							return;
						}
						goto IL_00d1;
					case 0:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<PurchaseCraftingItemResponse>>);
						num = (_003C_003E1__state = -1);
						goto IL_00d1;
					case 1:
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0196;
					case 2:
						{
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0223;
						}
						IL_0223:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						break;
						IL_00d1:
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
								_003CCraftItem_003Ed__65 _003CCraftItem_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCraftItem_003Ed__65>(ref awaiter3, ref _003CCraftItem_003Ed__);
								return;
							}
							goto IL_0196;
						}
						awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Crafting Failed", _003Cresult_003E5__3.ErrorMessage ?? "Not enough crystals!").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter2;
							_003CCraftItem_003Ed__65 _003CCraftItem_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCraftItem_003Ed__65>(ref awaiter2, ref _003CCraftItem_003Ed__);
							return;
						}
						goto IL_0223;
						IL_0196:
						((TaskAwaiter)(ref awaiter3)).GetResult();
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
					goto IL_0320;
				}
				_003Cex_003E5__5 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to craft item").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 3);
					_003C_003Eu__2 = awaiter;
					_003CCraftItem_003Ed__65 _003CCraftItem_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCraftItem_003Ed__65>(ref awaiter, ref _003CCraftItem_003Ed__);
					return;
				}
				goto IL_02dc;
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
	private sealed class _003CGoToPouch_003Ed__72 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ShopHubViewModel _003C_003E4__this;

		private string _003CcurrentRoute_003E5__1;

		private global::System.Exception _003Cex_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

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
						_003CcurrentRoute_003E5__1 = _003C_003E4__this._playerStateService.CurrentRoute;
						awaiter = _003C_003E4__this._navigationService.NavigateToAsync(_003CcurrentRoute_003E5__1 + "/pouch").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGoToPouch_003Ed__72 _003CGoToPouch_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToPouch_003Ed__72>(ref awaiter, ref _003CGoToPouch_003Ed__);
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
					_003CcurrentRoute_003E5__1 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__2 = ex;
					Console.WriteLine(_003Cex_003E5__2.Message);
					Console.WriteLine(_003Cex_003E5__2.StackTrace);
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
	private sealed class _003CGoToSpirits_003Ed__71 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ShopHubViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
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
						goto IL_0155;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._navigationService.NavigateToAsync(_003C_003E4__this._playerStateService.CurrentRoute + "/collection").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CGoToSpirits_003Ed__71 _003CGoToSpirits_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToSpirits_003Ed__71>(ref awaiter2, ref _003CGoToSpirits_003Ed__);
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
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_0189;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Navigation Error", "Failed to navigate to spirit collection").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CGoToSpirits_003Ed__71 _003CGoToSpirits_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToSpirits_003Ed__71>(ref awaiter, ref _003CGoToSpirits_003Ed__);
					return;
				}
				goto IL_0155;
				IL_0155:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine(_003Cex_003E5__3.Message);
				Console.WriteLine(_003Cex_003E5__3.StackTrace);
				_003Cex_003E5__3 = null;
				goto IL_0189;
				IL_0189:
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
	private sealed class _003CLoadAllShopItems_003Ed__51 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ShopHubViewModel _003C_003E4__this;

		private Player _003Cplayer_003E5__1;

		private List<ItemModel> _003CshopItems_003E5__2;

		private List<ItemType> _003CitemTypes_003E5__3;

		private Result<GetShopItemsResponse> _003Cresult_003E5__4;

		private HashSet<string> _003CownedBaseSpiritIds_003E5__5;

		private Result<GetShopItemsResponse> _003C_003Es__6;

		private List<ShopItemResult> _003CnormalItems_003E5__7;

		private Enumerator<string, Spirit> _003C_003Es__8;

		private string _003CbaseSpiritId_003E5__9;

		private Spirit _003Cspirit_003E5__10;

		private string _003CorbKey_003E5__11;

		private Inventory _003Corb_003E5__12;

		private bool _003CisNew_003E5__13;

		private string _003CcurrencyType_003E5__14;

		private int _003Ccost_003E5__15;

		private TaskAwaiter<Result<GetShopItemsResponse>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02df: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c9: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<Result<GetShopItemsResponse>> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Result<GetShopItemsResponse>>);
					num = (_003C_003E1__state = -1);
					goto IL_00ee;
				}
				_003Cplayer_003E5__1 = _003C_003E4__this._playerStateService.GetCurrentPlayer();
				if (_003Cplayer_003E5__1 != null)
				{
					_003CshopItems_003E5__2 = new List<ItemModel>();
					List<ItemType> obj = new List<ItemType>();
					obj.Add(ItemType.booster);
					obj.Add(ItemType.items);
					obj.Add(ItemType.gear);
					obj.Add(ItemType.talent);
					obj.Add(ItemType.unlock);
					obj.Add(ItemType.crafting);
					_003CitemTypes_003E5__3 = obj;
					awaiter = _003C_003E4__this._getShopItemsUseCase.ExecuteAsync(new GetShopItemsRequest(_003CitemTypes_003E5__3)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CLoadAllShopItems_003Ed__51 _003CLoadAllShopItems_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<GetShopItemsResponse>>, _003CLoadAllShopItems_003Ed__51>(ref awaiter, ref _003CLoadAllShopItems_003Ed__);
						return;
					}
					goto IL_00ee;
				}
				goto end_IL_0007;
				IL_00ee:
				_003C_003Es__6 = awaiter.GetResult();
				_003Cresult_003E5__4 = _003C_003Es__6;
				_003C_003Es__6 = null;
				if (_003Cresult_003E5__4.Success && _003Cresult_003E5__4.Data != null)
				{
					_003CnormalItems_003E5__7 = Enumerable.ToList<ShopItemResult>(Enumerable.Where<ShopItemResult>((global::System.Collections.Generic.IEnumerable<ShopItemResult>)_003Cresult_003E5__4.Data.Items, (Func<ShopItemResult, bool>)((ShopItemResult x) => x.Item.Requirements?.CurrencyCost?.Type != "clancredits")));
					_003CshopItems_003E5__2.AddRange(Enumerable.Select<ShopItemResult, ItemModel>(Enumerable.Where<ShopItemResult>((global::System.Collections.Generic.IEnumerable<ShopItemResult>)_003CnormalItems_003E5__7, (Func<ShopItemResult, bool>)((ShopItemResult x) => x.Item.ItemType != ItemType.crafting && x.Item.ItemType != ItemType.unlock)), (Func<ShopItemResult, ItemModel>)((ShopItemResult x) => new ItemModel(x.Item, x.IsNew))));
					_003CshopItems_003E5__2.AddRange(Enumerable.Select<ShopItemResult, ItemModel>(Enumerable.Where<ShopItemResult>((global::System.Collections.Generic.IEnumerable<ShopItemResult>)_003CnormalItems_003E5__7, (Func<ShopItemResult, bool>)((ShopItemResult x) => x.Item.ItemType == ItemType.crafting)), (Func<ShopItemResult, ItemModel>)((ShopItemResult x) => new ItemModel(x.Item, "true"))));
					_003CshopItems_003E5__2.AddRange(Enumerable.Select<ShopItemResult, ItemModel>(Enumerable.Where<ShopItemResult>((global::System.Collections.Generic.IEnumerable<ShopItemResult>)_003CnormalItems_003E5__7, (Func<ShopItemResult, bool>)((ShopItemResult x) => x.Item.ItemType == ItemType.unlock)), (Func<ShopItemResult, ItemModel>)((ShopItemResult x) => new ItemModel(x.Item, x.IsNew))));
					_003CnormalItems_003E5__7 = null;
				}
				_003CownedBaseSpiritIds_003E5__5 = Enumerable.ToHashSet<string>(Enumerable.Select<PlayerSpirit, string>((global::System.Collections.Generic.IEnumerable<PlayerSpirit>)_003C_003E4__this._playerStateService.GetAllPlayerSpirits(), (Func<PlayerSpirit, string>)((PlayerSpirit i) => i.BaseSpiritID.ToString())));
				_003C_003Es__8 = _003C_003E4__this._cache.Spirits.GetEnumerator();
				try
				{
					string text = default(string);
					Spirit spirit = default(Spirit);
					while (_003C_003Es__8.MoveNext())
					{
						_003C_003Es__8.Current.Deconstruct(ref text, ref spirit);
						_003CbaseSpiritId_003E5__9 = text;
						_003Cspirit_003E5__10 = spirit;
						if (_003Cspirit_003E5__10.Requirements?.CurrencyCost == null || _003Cspirit_003E5__10.Requirements.CurrencyCost.Type == "clancredits")
						{
							continue;
						}
						_003CorbKey_003E5__11 = _003Cspirit_003E5__10.Name + " Orb #" + _003Cspirit_003E5__10.ID;
						if (_003Cplayer_003E5__1.Inventory != null && _003Cplayer_003E5__1.Inventory.TryGetValue(_003CorbKey_003E5__11, ref _003Corb_003E5__12) && _003Corb_003E5__12.Amount > 0)
						{
							_003CisNew_003E5__13 = !_003CownedBaseSpiritIds_003E5__5.Contains(_003CbaseSpiritId_003E5__9);
							_003CcurrencyType_003E5__14 = _003Cspirit_003E5__10.Requirements.CurrencyCost.Type ?? "gold";
							_003Ccost_003E5__15 = _003Cspirit_003E5__10.Requirements.CurrencyCost.Amount;
							if (string.IsNullOrEmpty(_003CcurrencyType_003E5__14))
							{
								_003CcurrencyType_003E5__14 = "gold";
							}
							_003CshopItems_003E5__2.Add(new ItemModel(_003Cspirit_003E5__10, _003CisNew_003E5__13, _003CcurrencyType_003E5__14, _003Ccost_003E5__15));
							_003CorbKey_003E5__11 = null;
							_003Corb_003E5__12 = null;
							_003CcurrencyType_003E5__14 = null;
							_003CbaseSpiritId_003E5__9 = null;
							_003Cspirit_003E5__10 = null;
						}
					}
				}
				finally
				{
					if (num < 0)
					{
						((global::System.IDisposable)_003C_003Es__8).Dispose();
					}
				}
				_003C_003Es__8 = default(Enumerator<string, Spirit>);
				_003C_003E4__this._allShopItems = _003CshopItems_003E5__2;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cplayer_003E5__1 = null;
				_003CshopItems_003E5__2 = null;
				_003CitemTypes_003E5__3 = null;
				_003Cresult_003E5__4 = null;
				_003CownedBaseSpiritIds_003E5__5 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cplayer_003E5__1 = null;
			_003CshopItems_003E5__2 = null;
			_003CitemTypes_003E5__3 = null;
			_003Cresult_003E5__4 = null;
			_003CownedBaseSpiritIds_003E5__5 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CLoadDataAsync_003Ed__50 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object param;

		public ShopHubViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_023c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0241: Unknown result type (might be due to invalid IL or missing references)
			//IL_0256: Unknown result type (might be due to invalid IL or missing references)
			//IL_0258: Unknown result type (might be due to invalid IL or missing references)
			//IL_0276: Unknown result type (might be due to invalid IL or missing references)
			//IL_027b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0283: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 3u || (!_003C_003E4__this._isCached && !_003C_003E4__this.IsLoading))
				{
					try
					{
						TaskAwaiter awaiter;
						if ((uint)num > 2u)
						{
							if (num == 3)
							{
								awaiter = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0292;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter awaiter4;
							TaskAwaiter awaiter3;
							TaskAwaiter awaiter2;
							switch (num)
							{
							default:
								_003C_003E4__this.IsLoading = true;
								_003C_003E4__this.ErrorMessage = string.Empty;
								awaiter4 = _003C_003E4__this.LoadAllShopItems().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter4;
									_003CLoadDataAsync_003Ed__50 _003CLoadDataAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__50>(ref awaiter4, ref _003CLoadDataAsync_003Ed__);
									return;
								}
								goto IL_00f1;
							case 0:
								awaiter4 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_00f1;
							case 1:
								awaiter3 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_015a;
							case 2:
								{
									awaiter2 = _003C_003Eu__1;
									_003C_003Eu__1 = default(TaskAwaiter);
									num = (_003C_003E1__state = -1);
									break;
								}
								IL_015a:
								((TaskAwaiter)(ref awaiter3)).GetResult();
								awaiter2 = _003C_003E4__this.UpdateBadgeCountsAsync().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__1 = awaiter2;
									_003CLoadDataAsync_003Ed__50 _003CLoadDataAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__50>(ref awaiter2, ref _003CLoadDataAsync_003Ed__);
									return;
								}
								break;
								IL_00f1:
								((TaskAwaiter)(ref awaiter4)).GetResult();
								awaiter3 = _003C_003E4__this.ApplyFiltersAndSort().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__1 = awaiter3;
									_003CLoadDataAsync_003Ed__50 _003CLoadDataAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__50>(ref awaiter3, ref _003CLoadDataAsync_003Ed__);
									return;
								}
								goto IL_015a;
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
							goto IL_02d6;
						}
						_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
						_003C_003E4__this.ErrorMessage = "Failed to load shop data";
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to load shop data. Please try again.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__1 = awaiter;
							_003CLoadDataAsync_003Ed__50 _003CLoadDataAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__50>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
							return;
						}
						goto IL_0292;
						IL_0292:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine($"ShopHubViewModel.LoadDataAsync: {_003Cex_003E5__3}");
						_003Cex_003E5__3 = null;
						goto IL_02d6;
						IL_02d6:
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
	private sealed class _003CMarkItemsAsViewed_003Ed__54 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ShopHubViewModel _003C_003E4__this;

		private Result<MarkShopItemsViewedResponse> _003Cresult_003E5__1;

		private Result<MarkShopItemsViewedResponse> _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<Result<MarkShopItemsViewedResponse>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0203: Unknown result type (might be due to invalid IL or missing references)
			//IL_020b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_01df: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 3u)
				{
				}
				try
				{
					TaskAwaiter<Result<MarkShopItemsViewedResponse>> awaiter4;
					TaskAwaiter awaiter3;
					TaskAwaiter awaiter2;
					TaskAwaiter awaiter;
					switch (num)
					{
					default:
						awaiter4 = _003C_003E4__this._markItemsViewedUseCase.ExecuteAsync(new MarkShopItemsViewedRequest()).GetAwaiter();
						if (!awaiter4.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter4;
							_003CMarkItemsAsViewed_003Ed__54 _003CMarkItemsAsViewed_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<MarkShopItemsViewedResponse>>, _003CMarkItemsAsViewed_003Ed__54>(ref awaiter4, ref _003CMarkItemsAsViewed_003Ed__);
							return;
						}
						goto IL_00a2;
					case 0:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<MarkShopItemsViewedResponse>>);
						num = (_003C_003E1__state = -1);
						goto IL_00a2;
					case 1:
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_014a;
					case 2:
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01b2;
					case 3:
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_021a;
						}
						IL_01b2:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						awaiter = _003C_003E4__this.UpdateBadgeCountsAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__2 = awaiter;
							_003CMarkItemsAsViewed_003Ed__54 _003CMarkItemsAsViewed_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CMarkItemsAsViewed_003Ed__54>(ref awaiter, ref _003CMarkItemsAsViewed_003Ed__);
							return;
						}
						goto IL_021a;
						IL_00a2:
						_003C_003Es__2 = awaiter4.GetResult();
						_003Cresult_003E5__1 = _003C_003Es__2;
						_003C_003Es__2 = null;
						if (!_003Cresult_003E5__1.Success || !_003Cresult_003E5__1.Data.Updated)
						{
							break;
						}
						awaiter3 = _003C_003E4__this.LoadAllShopItems().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter3;
							_003CMarkItemsAsViewed_003Ed__54 _003CMarkItemsAsViewed_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CMarkItemsAsViewed_003Ed__54>(ref awaiter3, ref _003CMarkItemsAsViewed_003Ed__);
							return;
						}
						goto IL_014a;
						IL_014a:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						awaiter2 = _003C_003E4__this.ApplyFiltersAndSort().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter2;
							_003CMarkItemsAsViewed_003Ed__54 _003CMarkItemsAsViewed_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CMarkItemsAsViewed_003Ed__54>(ref awaiter2, ref _003CMarkItemsAsViewed_003Ed__);
							return;
						}
						goto IL_01b2;
						IL_021a:
						((TaskAwaiter)(ref awaiter)).GetResult();
						break;
					}
					_003Cresult_003E5__1 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine($"MarkItemsAsViewed error: {_003Cex_003E5__3}");
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
	private sealed class _003CProcessItemPurchase_003Ed__64 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ItemModel item;

		public ShopHubViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private PurchaseShopItemRequest _003Crequest_003E5__3;

		private Result<PurchaseShopItemResponse> _003CpurchaseResult_003E5__4;

		private Result<PurchaseShopItemResponse> _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<Result<PurchaseShopItemResponse>> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0359: Unknown result type (might be due to invalid IL or missing references)
			//IL_035e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0373: Unknown result type (might be due to invalid IL or missing references)
			//IL_0375: Unknown result type (might be due to invalid IL or missing references)
			//IL_0393: Unknown result type (might be due to invalid IL or missing references)
			//IL_0398: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_0230: Unknown result type (might be due to invalid IL or missing references)
			//IL_0235: Unknown result type (might be due to invalid IL or missing references)
			//IL_023d: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0298: Unknown result type (might be due to invalid IL or missing references)
			//IL_029d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0210: Unknown result type (might be due to invalid IL or missing references)
			//IL_0212: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 4u || !_003C_003E4__this.IsProcessingPurchase)
				{
					try
					{
						TaskAwaiter awaiter;
						if ((uint)num > 3u)
						{
							if (num == 4)
							{
								awaiter = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_03af;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter awaiter5;
							TaskAwaiter<Result<PurchaseShopItemResponse>> awaiter4;
							TaskAwaiter awaiter3;
							TaskAwaiter awaiter2;
							switch (num)
							{
							default:
								_003C_003E4__this.IsProcessingPurchase = true;
								if (item.Type == "crafting")
								{
									awaiter5 = _003C_003E4__this.CraftItem(item).GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
									{
										num = (_003C_003E1__state = 0);
										_003C_003Eu__1 = awaiter5;
										_003CProcessItemPurchase_003Ed__64 _003CProcessItemPurchase_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessItemPurchase_003Ed__64>(ref awaiter5, ref _003CProcessItemPurchase_003Ed__);
										return;
									}
									goto IL_00f5;
								}
								_003Crequest_003E5__3 = new PurchaseShopItemRequest(item.Id ?? string.Empty, global::System.Enum.Parse<ItemType>(item.Type));
								awaiter4 = _003C_003E4__this._purchaseItemUseCase.ExecuteAsync(_003Crequest_003E5__3).GetAwaiter();
								if (!awaiter4.IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter4;
									_003CProcessItemPurchase_003Ed__64 _003CProcessItemPurchase_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<PurchaseShopItemResponse>>, _003CProcessItemPurchase_003Ed__64>(ref awaiter4, ref _003CProcessItemPurchase_003Ed__);
									return;
								}
								goto IL_019f;
							case 0:
								awaiter5 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_00f5;
							case 1:
								awaiter4 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter<Result<PurchaseShopItemResponse>>);
								num = (_003C_003E1__state = -1);
								goto IL_019f;
							case 2:
								awaiter3 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_024c;
							case 3:
								{
									awaiter2 = _003C_003Eu__1;
									_003C_003Eu__1 = default(TaskAwaiter);
									num = (_003C_003E1__state = -1);
									goto IL_02ee;
								}
								IL_024c:
								((TaskAwaiter)(ref awaiter3)).GetResult();
								break;
								IL_02ee:
								((TaskAwaiter)(ref awaiter2)).GetResult();
								break;
								IL_00f5:
								((TaskAwaiter)(ref awaiter5)).GetResult();
								goto end_IL_0025;
								IL_019f:
								_003C_003Es__5 = awaiter4.GetResult();
								_003CpurchaseResult_003E5__4 = _003C_003Es__5;
								_003C_003Es__5 = null;
								if (_003CpurchaseResult_003E5__4.Success)
								{
									awaiter3 = _003C_003E4__this.ShowPurchaseCompletion(item.Name, item.Icon, isSpirit: false).GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
									{
										num = (_003C_003E1__state = 2);
										_003C_003Eu__1 = awaiter3;
										_003CProcessItemPurchase_003Ed__64 _003CProcessItemPurchase_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessItemPurchase_003Ed__64>(ref awaiter3, ref _003CProcessItemPurchase_003Ed__);
										return;
									}
									goto IL_024c;
								}
								if (string.IsNullOrEmpty(_003CpurchaseResult_003E5__4.ErrorMessage))
								{
									break;
								}
								awaiter2 = _003C_003E4__this.ShowInsufficientFundsPopup(_003CpurchaseResult_003E5__4.ErrorMessage, item.CurrencyType).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 3);
									_003C_003Eu__1 = awaiter2;
									_003CProcessItemPurchase_003Ed__64 _003CProcessItemPurchase_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessItemPurchase_003Ed__64>(ref awaiter2, ref _003CProcessItemPurchase_003Ed__);
									return;
								}
								goto IL_02ee;
							}
							_003Crequest_003E5__3 = null;
							_003CpurchaseResult_003E5__4 = null;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
						}
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_03f3;
						}
						_003Cex_003E5__6 = (global::System.Exception)_003C_003Es__1;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Purchase Error", "Failed to complete purchase").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 4);
							_003C_003Eu__1 = awaiter;
							_003CProcessItemPurchase_003Ed__64 _003CProcessItemPurchase_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessItemPurchase_003Ed__64>(ref awaiter, ref _003CProcessItemPurchase_003Ed__);
							return;
						}
						goto IL_03af;
						IL_03af:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine($"ProcessItemPurchase error: {_003Cex_003E5__6}");
						_003Cex_003E5__6 = null;
						goto IL_03f3;
						IL_03f3:
						_003C_003Es__1 = null;
						end_IL_0025:;
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsProcessingPurchase = false;
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
	private sealed class _003CProcessSpiritPurchase_003Ed__67 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string spiritId;

		public ShopHubViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private PurchaseSpiritRequest _003Crequest_003E5__3;

		private Result<PurchaseSpiritResponse> _003Cresult_003E5__4;

		private Result<PurchaseSpiritResponse> _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<Result<PurchaseSpiritResponse>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0311: Unknown result type (might be due to invalid IL or missing references)
			//IL_0313: Unknown result type (might be due to invalid IL or missing references)
			//IL_0330: Unknown result type (might be due to invalid IL or missing references)
			//IL_0335: Unknown result type (might be due to invalid IL or missing references)
			//IL_033d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_0209: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0216: Unknown result type (might be due to invalid IL or missing references)
			//IL_0271: Unknown result type (might be due to invalid IL or missing references)
			//IL_0276: Unknown result type (might be due to invalid IL or missing references)
			//IL_027e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0238: Unknown result type (might be due to invalid IL or missing references)
			//IL_023d: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0252: Unknown result type (might be due to invalid IL or missing references)
			//IL_0254: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if ((uint)num > 3u)
				{
					if (num == 4)
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_034c;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter<Result<PurchaseSpiritResponse>> awaiter5;
					TaskAwaiter awaiter4;
					TaskAwaiter awaiter3;
					TaskAwaiter awaiter2;
					switch (num)
					{
					default:
						_003Crequest_003E5__3 = new PurchaseSpiritRequest(spiritId);
						awaiter5 = _003C_003E4__this._purchaseSpiritUseCase.ExecuteAsync(_003Crequest_003E5__3).GetAwaiter();
						if (!awaiter5.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter5;
							_003CProcessSpiritPurchase_003Ed__67 _003CProcessSpiritPurchase_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<PurchaseSpiritResponse>>, _003CProcessSpiritPurchase_003Ed__67>(ref awaiter5, ref _003CProcessSpiritPurchase_003Ed__);
							return;
						}
						goto IL_00c7;
					case 0:
						awaiter5 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<PurchaseSpiritResponse>>);
						num = (_003C_003E1__state = -1);
						goto IL_00c7;
					case 1:
						awaiter4 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0197;
					case 2:
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0225;
					case 3:
						{
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_0197:
						((TaskAwaiter)(ref awaiter4)).GetResult();
						goto end_IL_0007;
						IL_00c7:
						_003C_003Es__5 = awaiter5.GetResult();
						_003Cresult_003E5__4 = _003C_003Es__5;
						_003C_003Es__5 = null;
						if (!_003Cresult_003E5__4.Success)
						{
							awaiter4 = _003C_003E4__this.ShowInsufficientFundsPopup(_003Cresult_003E5__4.ErrorMessage ?? "Purchase failed", _003Cresult_003E5__4.Data?.CurrencyType ?? _003C_003E4__this.CurrentCurrencyTab).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter4;
								_003CProcessSpiritPurchase_003Ed__67 _003CProcessSpiritPurchase_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessSpiritPurchase_003Ed__67>(ref awaiter4, ref _003CProcessSpiritPurchase_003Ed__);
								return;
							}
							goto IL_0197;
						}
						awaiter3 = _003C_003E4__this.ShowPurchaseCompletion(_003Cresult_003E5__4.Data.SpiritName, _003Cresult_003E5__4.Data.SpiritImage, isSpirit: true).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter3;
							_003CProcessSpiritPurchase_003Ed__67 _003CProcessSpiritPurchase_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessSpiritPurchase_003Ed__67>(ref awaiter3, ref _003CProcessSpiritPurchase_003Ed__);
							return;
						}
						goto IL_0225;
						IL_0225:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						awaiter2 = _003C_003E4__this.RefreshItemsAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__2 = awaiter2;
							_003CProcessSpiritPurchase_003Ed__67 _003CProcessSpiritPurchase_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessSpiritPurchase_003Ed__67>(ref awaiter2, ref _003CProcessSpiritPurchase_003Ed__);
							return;
						}
						break;
					}
					((TaskAwaiter)(ref awaiter2)).GetResult();
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
					goto IL_0390;
				}
				_003Cex_003E5__6 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to process spirit purchase").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 4);
					_003C_003Eu__2 = awaiter;
					_003CProcessSpiritPurchase_003Ed__67 _003CProcessSpiritPurchase_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessSpiritPurchase_003Ed__67>(ref awaiter, ref _003CProcessSpiritPurchase_003Ed__);
					return;
				}
				goto IL_034c;
				IL_034c:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine($"ProcessSpiritPurchase error: {_003Cex_003E5__6}");
				_003Cex_003E5__6 = null;
				goto IL_0390;
				IL_0390:
				_003C_003Es__1 = null;
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
	private sealed class _003CRefreshItemsAsync_003Ed__52 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ShopHubViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter3;
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					awaiter3 = _003C_003E4__this.LoadAllShopItems().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter3;
						_003CRefreshItemsAsync_003Ed__52 _003CRefreshItemsAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRefreshItemsAsync_003Ed__52>(ref awaiter3, ref _003CRefreshItemsAsync_003Ed__);
						return;
					}
					goto IL_0085;
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0085;
				case 1:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00ea;
				case 2:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_00ea:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					awaiter = _003C_003E4__this.UpdateBadgeCountsAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = awaiter;
						_003CRefreshItemsAsync_003Ed__52 _003CRefreshItemsAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRefreshItemsAsync_003Ed__52>(ref awaiter, ref _003CRefreshItemsAsync_003Ed__);
						return;
					}
					break;
					IL_0085:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					awaiter2 = _003C_003E4__this.ApplyFiltersAndSort().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter2;
						_003CRefreshItemsAsync_003Ed__52 _003CRefreshItemsAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRefreshItemsAsync_003Ed__52>(ref awaiter2, ref _003CRefreshItemsAsync_003Ed__);
						return;
					}
					goto IL_00ea;
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
	private sealed class _003CShowInsufficientFundsPopup_003Ed__69 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string message;

		public string currencyType;

		public ShopHubViewModel _003C_003E4__this;

		private _003C_003Ec__DisplayClass69_0 _003C_003E8__1;

		private object _003Cresult_003E5__2;

		private InsufficientFundsResult _003Caction_003E5__3;

		private object _003C_003Es__4;

		private TaskAwaiter<object?> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				TaskAwaiter<object> awaiter2;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_019b;
					}
					_003C_003E8__1 = new _003C_003Ec__DisplayClass69_0();
					_003C_003E8__1.message = message;
					_003C_003E8__1.currencyIcon = ((currencyType == "crystal") ? "icon_crystal.png" : "icon_gold.png");
					awaiter2 = _003C_003E4__this._popupService.ShowPopupAsync<InsufficientFundsPopupViewModel>((Action<InsufficientFundsPopupViewModel>)delegate(InsufficientFundsPopupViewModel vm)
					{
						vm.Infotext = _003C_003E8__1.message;
						vm.Infotext2 = "Earn more by questing or purchase in shop!";
						vm.Image = _003C_003E8__1.currencyIcon;
						vm.IsGoToQuestVisible = true;
						vm.IsGoToShopVisible = false;
					}, default(CancellationToken)).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003CShowInsufficientFundsPopup_003Ed__69 _003CShowInsufficientFundsPopup_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CShowInsufficientFundsPopup_003Ed__69>(ref awaiter2, ref _003CShowInsufficientFundsPopup_003Ed__);
						return;
					}
				}
				else
				{
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<object>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__4 = awaiter2.GetResult();
				_003Cresult_003E5__2 = _003C_003Es__4;
				_003C_003Es__4 = null;
				if (_003Cresult_003E5__2 is InsufficientFundsResult)
				{
					_003Caction_003E5__3 = (InsufficientFundsResult)_003Cresult_003E5__2;
					if (_003Caction_003E5__3 == InsufficientFundsResult.Quest)
					{
						awaiter = _003C_003E4__this._navBarViewModel.NavigateToCommand.ExecuteAsync("//quest").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003CShowInsufficientFundsPopup_003Ed__69 _003CShowInsufficientFundsPopup_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CShowInsufficientFundsPopup_003Ed__69>(ref awaiter, ref _003CShowInsufficientFundsPopup_003Ed__);
							return;
						}
						goto IL_019b;
					}
				}
				goto end_IL_0007;
				IL_019b:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Cresult_003E5__2 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Cresult_003E5__2 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CShowItemPopup_003Ed__63 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ItemModel item;

		public ShopHubViewModel _003C_003E4__this;

		private _003C_003Ec__DisplayClass63_0 _003C_003E8__1;

		private object _003Cresult_003E5__2;

		private bool _003Cconfirmed_003E5__3;

		private object _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<object?> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_016f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_0226: Unknown result type (might be due to invalid IL or missing references)
			//IL_022b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0233: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0206: Unknown result type (might be due to invalid IL or missing references)
			//IL_0208: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 2u)
				{
					goto IL_0054;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass63_0();
				_003C_003E8__1.item = item;
				if (_003C_003E4__this.CanPurchase && _003C_003E8__1.item != null)
				{
					goto IL_0054;
				}
				goto end_IL_0007;
				IL_0054:
				try
				{
					TaskAwaiter awaiter3;
					TaskAwaiter<object> awaiter2;
					TaskAwaiter awaiter;
					int num2;
					switch (num)
					{
					default:
						if (_003C_003E8__1.item.IsSpirit)
						{
							awaiter3 = _003C_003E4__this.ShowSpiritPurchase(_003C_003E8__1.item.SpiritId).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter3;
								_003CShowItemPopup_003Ed__63 _003CShowItemPopup_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CShowItemPopup_003Ed__63>(ref awaiter3, ref _003CShowItemPopup_003Ed__);
								return;
							}
							goto IL_00f8;
						}
						awaiter2 = _003C_003E4__this._popupService.ShowPopupAsync<ItemPopupViewModel>((Action<ItemPopupViewModel>)delegate(ItemPopupViewModel vm)
						{
							vm.IsCrafting = false;
							vm.CurrentItem = _003C_003E8__1.item;
						}, default(CancellationToken)).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter2;
							_003CShowItemPopup_003Ed__63 _003CShowItemPopup_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CShowItemPopup_003Ed__63>(ref awaiter2, ref _003CShowItemPopup_003Ed__);
							return;
						}
						goto IL_0186;
					case 0:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_00f8;
					case 1:
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<object>);
						num = (_003C_003E1__state = -1);
						goto IL_0186;
					case 2:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0242;
						}
						IL_0242:
						((TaskAwaiter)(ref awaiter)).GetResult();
						break;
						IL_0186:
						_003C_003Es__4 = awaiter2.GetResult();
						_003Cresult_003E5__2 = _003C_003Es__4;
						_003C_003Es__4 = null;
						if (_003Cresult_003E5__2 is bool)
						{
							_003Cconfirmed_003E5__3 = (bool)_003Cresult_003E5__2;
							num2 = 1;
						}
						else
						{
							num2 = 0;
						}
						if (((uint)num2 & (_003Cconfirmed_003E5__3 ? 1u : 0u)) == 0)
						{
							break;
						}
						awaiter = _003C_003E4__this.ProcessItemPurchase(_003C_003E8__1.item).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = awaiter;
							_003CShowItemPopup_003Ed__63 _003CShowItemPopup_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CShowItemPopup_003Ed__63>(ref awaiter, ref _003CShowItemPopup_003Ed__);
							return;
						}
						goto IL_0242;
						IL_00f8:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						goto end_IL_0054;
					}
					_003Cresult_003E5__2 = null;
					end_IL_0054:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					_003C_003E4__this.ErrorMessage = "Failed to show item popup";
					Console.WriteLine($"ShowItemPopup error: {_003Cex_003E5__5}");
				}
				end_IL_0007:;
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CShowPurchaseCompletion_003Ed__70 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string itemName;

		public string itemImage;

		public bool isSpirit;

		public ShopHubViewModel _003C_003E4__this;

		private _003C_003Ec__DisplayClass70_0 _003C_003E8__1;

		private global::System.Exception _003Cex_003E5__2;

		private TaskAwaiter<object?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass70_0();
					_003C_003E8__1.itemName = itemName;
					_003C_003E8__1.itemImage = itemImage;
					_003C_003E8__1.isSpirit = isSpirit;
				}
				try
				{
					TaskAwaiter<object> awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._popupService.ShowPopupAsync<QuestRewardsPopupViewModel>((Action<QuestRewardsPopupViewModel>)delegate(QuestRewardsPopupViewModel vm)
						{
							vm.ItemName = _003C_003E8__1.itemName;
							vm.ItemImage = _003C_003E8__1.itemImage;
							vm.IsItem = true;
							vm.CompletedText2 = (_003C_003E8__1.isSpirit ? ("You just unlocked the spirit " + _003C_003E8__1.itemName + "!") : ("You just unlocked the item " + _003C_003E8__1.itemName + "!"));
						}, default(CancellationToken)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CShowPurchaseCompletion_003Ed__70 _003CShowPurchaseCompletion_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CShowPurchaseCompletion_003Ed__70>(ref awaiter, ref _003CShowPurchaseCompletion_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<object>);
						num = (_003C_003E1__state = -1);
					}
					awaiter.GetResult();
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__2 = ex;
					Console.WriteLine($"ShowPurchaseCompletion error: {_003Cex_003E5__2}");
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CShowSpiritPurchase_003Ed__66 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string spiritId;

		public ShopHubViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private Result<GetSpiritPreviewResponse> _003CpreviewResult_003E5__3;

		private GetSpiritPreviewResponse _003Cdata_003E5__4;

		private ShopResult _003CpurchaseResult_003E5__5;

		private Result<GetSpiritPreviewResponse> _003C_003Es__6;

		private ShopResult _003C_003Es__7;

		private global::System.Exception _003Cex_003E5__8;

		private TaskAwaiter<Result<GetSpiritPreviewResponse>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private TaskAwaiter<ShopResult> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_035a: Unknown result type (might be due to invalid IL or missing references)
			//IL_035f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0374: Unknown result type (might be due to invalid IL or missing references)
			//IL_0376: Unknown result type (might be due to invalid IL or missing references)
			//IL_0393: Unknown result type (might be due to invalid IL or missing references)
			//IL_0398: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0244: Unknown result type (might be due to invalid IL or missing references)
			//IL_0249: Unknown result type (might be due to invalid IL or missing references)
			//IL_0251: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_029a: Unknown result type (might be due to invalid IL or missing references)
			//IL_029f: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_020b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0210: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0225: Unknown result type (might be due to invalid IL or missing references)
			//IL_0227: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 4u || (_003C_003E4__this.CanPurchase && !string.IsNullOrEmpty(spiritId)))
				{
					try
					{
						TaskAwaiter awaiter;
						if ((uint)num > 3u)
						{
							if (num == 4)
							{
								awaiter = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_03af;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter<Result<GetSpiritPreviewResponse>> awaiter5;
							TaskAwaiter awaiter4;
							TaskAwaiter<ShopResult> awaiter3;
							TaskAwaiter awaiter2;
							switch (num)
							{
							default:
								_003C_003E4__this.IsProcessingPurchase = true;
								awaiter5 = _003C_003E4__this._getSpiritPreviewUseCase.ExecuteAsync(new GetSpiritPreviewRequest(spiritId)).GetAwaiter();
								if (!awaiter5.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter5;
									_003CShowSpiritPurchase_003Ed__66 _003CShowSpiritPurchase_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<GetSpiritPreviewResponse>>, _003CShowSpiritPurchase_003Ed__66>(ref awaiter5, ref _003CShowSpiritPurchase_003Ed__);
									return;
								}
								goto IL_00f4;
							case 0:
								awaiter5 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<Result<GetSpiritPreviewResponse>>);
								num = (_003C_003E1__state = -1);
								goto IL_00f4;
							case 1:
								awaiter4 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_01ab;
							case 2:
								awaiter3 = _003C_003Eu__3;
								_003C_003Eu__3 = default(TaskAwaiter<ShopResult>);
								num = (_003C_003E1__state = -1);
								goto IL_0260;
							case 3:
								{
									awaiter2 = _003C_003Eu__2;
									_003C_003Eu__2 = default(TaskAwaiter);
									num = (_003C_003E1__state = -1);
									goto IL_02ef;
								}
								IL_02ef:
								((TaskAwaiter)(ref awaiter2)).GetResult();
								break;
								IL_00f4:
								_003C_003Es__6 = awaiter5.GetResult();
								_003CpreviewResult_003E5__3 = _003C_003Es__6;
								_003C_003Es__6 = null;
								if (!_003CpreviewResult_003E5__3.Success || _003CpreviewResult_003E5__3.Data == null)
								{
									awaiter4 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Spirit not found").GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
									{
										num = (_003C_003E1__state = 1);
										_003C_003Eu__2 = awaiter4;
										_003CShowSpiritPurchase_003Ed__66 _003CShowSpiritPurchase_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CShowSpiritPurchase_003Ed__66>(ref awaiter4, ref _003CShowSpiritPurchase_003Ed__);
										return;
									}
									goto IL_01ab;
								}
								_003Cdata_003E5__4 = _003CpreviewResult_003E5__3.Data;
								awaiter3 = _003C_003E4__this.ShowSpiritPurchaseSheet(_003Cdata_003E5__4.SpiritPreview, _003Cdata_003E5__4.CurrencyType, _003Cdata_003E5__4.CurrencyAmount, _003Cdata_003E5__4.OrbName, _003Cdata_003E5__4.OrbAmount).GetAwaiter();
								if (!awaiter3.IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__3 = awaiter3;
									_003CShowSpiritPurchase_003Ed__66 _003CShowSpiritPurchase_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<ShopResult>, _003CShowSpiritPurchase_003Ed__66>(ref awaiter3, ref _003CShowSpiritPurchase_003Ed__);
									return;
								}
								goto IL_0260;
								IL_0260:
								_003C_003Es__7 = awaiter3.GetResult();
								_003CpurchaseResult_003E5__5 = _003C_003Es__7;
								if (_003CpurchaseResult_003E5__5 != 0)
								{
									break;
								}
								awaiter2 = _003C_003E4__this.ProcessSpiritPurchase(spiritId).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 3);
									_003C_003Eu__2 = awaiter2;
									_003CShowSpiritPurchase_003Ed__66 _003CShowSpiritPurchase_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CShowSpiritPurchase_003Ed__66>(ref awaiter2, ref _003CShowSpiritPurchase_003Ed__);
									return;
								}
								goto IL_02ef;
								IL_01ab:
								((TaskAwaiter)(ref awaiter4)).GetResult();
								goto end_IL_0050;
							}
							_003CpreviewResult_003E5__3 = null;
							_003Cdata_003E5__4 = null;
							goto IL_031c;
							end_IL_0050:;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
							goto IL_031c;
						}
						goto end_IL_0035;
						IL_031c:
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_03f3;
						}
						_003Cex_003E5__8 = (global::System.Exception)_003C_003Es__1;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to process spirit purchase").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 4);
							_003C_003Eu__2 = awaiter;
							_003CShowSpiritPurchase_003Ed__66 _003CShowSpiritPurchase_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CShowSpiritPurchase_003Ed__66>(ref awaiter, ref _003CShowSpiritPurchase_003Ed__);
							return;
						}
						goto IL_03af;
						IL_03af:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine($"ShowSpiritPurchase error: {_003Cex_003E5__8}");
						_003Cex_003E5__8 = null;
						goto IL_03f3;
						IL_03f3:
						_003C_003Es__1 = null;
						end_IL_0035:;
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsProcessingPurchase = false;
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
	private sealed class _003CShowSpiritPurchaseSheet_003Ed__68 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<ShopResult> _003C_003Et__builder;

		public SpiritPreviewDTO spiritPreview;

		public string currencyType;

		public int currencyAmount;

		public string orbName;

		public int orbAmount;

		public ShopHubViewModel _003C_003E4__this;

		private string _003CsheetId_003E5__1;

		private BottomSheet _003Csheet_003E5__2;

		private ShopSpiritSheetViewModel _003Cvm_003E5__3;

		private ShopResult _003Cresult_003E5__4;

		private ShopResult _003C_003Es__5;

		private TaskAwaiter<ShopResult> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			ShopResult result;
			try
			{
				TaskAwaiter<ShopResult> awaiter;
				if (num != 0)
				{
					Guid val = Guid.NewGuid();
					_003CsheetId_003E5__1 = ((object)(Guid)(ref val)).ToString();
					_003Csheet_003E5__2 = _003C_003E4__this._navigationService.GetSheetPage<ShopSpiritBottomSheet>("shopspirit");
					_003Cvm_003E5__3 = new ShopSpiritSheetViewModel(spiritPreview, currencyType, currencyAmount, orbName, orbAmount, _003C_003E4__this._bottomSheetService, _003C_003E4__this._playerStateService, _003CsheetId_003E5__1);
					((BindableObject)_003Csheet_003E5__2).BindingContext = _003Cvm_003E5__3;
					_003Cvm_003E5__3.SetSheet(_003Csheet_003E5__2);
					awaiter = _003C_003E4__this._bottomSheetService.ShowSheetAsync<ShopResult>(_003Csheet_003E5__2, _003CsheetId_003E5__1).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CShowSpiritPurchaseSheet_003Ed__68 _003CShowSpiritPurchaseSheet_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<ShopResult>, _003CShowSpiritPurchaseSheet_003Ed__68>(ref awaiter, ref _003CShowSpiritPurchaseSheet_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<ShopResult>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__5 = awaiter.GetResult();
				_003Cresult_003E5__4 = _003C_003Es__5;
				result = _003Cresult_003E5__4;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CsheetId_003E5__1 = null;
				_003Csheet_003E5__2 = null;
				_003Cvm_003E5__3 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CsheetId_003E5__1 = null;
			_003Csheet_003E5__2 = null;
			_003Cvm_003E5__3 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CToggleSearch_003Ed__57 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ShopHubViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00c9;
				}
				_003C_003E4__this.IsSearchActive = !_003C_003E4__this.IsSearchActive;
				if (!_003C_003E4__this.IsSearchActive)
				{
					_003C_003E4__this.SearchText = string.Empty;
					awaiter = _003C_003E4__this.ApplyFiltersAndSort().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CToggleSearch_003Ed__57 _003CToggleSearch_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CToggleSearch_003Ed__57>(ref awaiter, ref _003CToggleSearch_003Ed__);
						return;
					}
					goto IL_00c9;
				}
				_003C_003E4__this.CurrentSort = SortType.Name;
				_003C_003E4__this.SelectFilter("all");
				goto end_IL_0007;
				IL_00c9:
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

	private readonly INavigationService _navigationService;

	private readonly IPlayerStateService _playerStateService;

	private readonly IBottomSheetService _bottomSheetService;

	private readonly IPopupService _popupService;

	private readonly NavBarViewModel _navBarViewModel;

	private readonly PlayerInfoModel _playerInfoModel;

	private readonly PurchaseShopItemUseCase _purchaseItemUseCase;

	private readonly PurchaseSpiritUseCase _purchaseSpiritUseCase;

	private readonly GetSpiritPreviewUseCase _getSpiritPreviewUseCase;

	private readonly GetShopItemsUseCase _getShopItemsUseCase;

	private readonly MarkShopItemsViewedUseCase _markItemsViewedUseCase;

	private readonly IStaticDataCacheService _cache;

	private readonly PurchaseCraftingItemUseCase _purchaseCraftingItemUseCase;

	private bool _disposed;

	private bool _isCached;

	private List<ItemModel> _allShopItems = new List<ItemModel>();

	[ObservableProperty]
	private bool _isSearchActive;

	[ObservableProperty]
	private string _searchText = string.Empty;

	[ObservableProperty]
	private int _newItemsCount = 0;

	[ObservableProperty]
	private bool _isTabAnimating = false;

	[ObservableProperty]
	[NotifyPropertyChangedFor("IsGoldTabActive")]
	[NotifyPropertyChangedFor("IsCrystalsTabActive")]
	[NotifyPropertyChangedFor("IsPremiumTabActive")]
	[NotifyPropertyChangedFor("ShowNewBadge")]
	private string _currentCurrencyTab = "gold";

	[ObservableProperty]
	private ObservableCollection<ItemModel> _availableItems = new ObservableCollection<ItemModel>();

	[ObservableProperty]
	[NotifyPropertyChangedFor("CanPurchase")]
	private bool _isLoading;

	[ObservableProperty]
	[NotifyPropertyChangedFor("CanPurchase")]
	private bool _isProcessingPurchase;

	[ObservableProperty]
	private string _errorMessage = string.Empty;

	[ObservableProperty]
	private ObservableCollection<FilterChipModel> _filterChips = new ObservableCollection<FilterChipModel>();

	[ObservableProperty]
	private string _selectedFilter = "all";

	[ObservableProperty]
	[NotifyPropertyChangedFor("IsSortByNameActive")]
	[NotifyPropertyChangedFor("IsSortByRarityActive")]
	[NotifyPropertyChangedFor("IsSortByPriceActive")]
	private SortType _currentSort = SortType.Name;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<object?>? loadDataCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<string>? changeCurrencyTabCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<string>? changeCurrencyTabWithAnimationCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? toggleSearchCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<string>? selectFilterCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<string>? changeSortTypeCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? clearSearchCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<ItemModel>? showItemPopupCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<ItemModel>? craftItemCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goToSpiritsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goToPouchCommand;

	public PlayerInfoModel CurrentPlayer => _playerInfoModel;

	public bool CanPurchase => !IsLoading && !IsProcessingPurchase;

	public bool IsGoldTabActive => CurrentCurrencyTab == "gold";

	public bool IsCrystalsTabActive => CurrentCurrencyTab == "crystal";

	public bool IsPremiumTabActive => CurrentCurrencyTab == "premium";

	public bool ShowNewBadge => NewItemsCount > 0;

	public bool IsSortByNameActive => CurrentSort == SortType.Name;

	public bool IsSortByRarityActive => CurrentSort == SortType.Rarity;

	public bool IsSortByPriceActive => CurrentSort == SortType.Price;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsSearchActive
	{
		get
		{
			return _isSearchActive;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isSearchActive, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsSearchActive);
				_isSearchActive = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsSearchActive);
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
	public int NewItemsCount
	{
		get
		{
			return _newItemsCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_newItemsCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.NewItemsCount);
				_newItemsCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.NewItemsCount);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsTabAnimating
	{
		get
		{
			return _isTabAnimating;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isTabAnimating, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsTabAnimating);
				_isTabAnimating = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsTabAnimating);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string CurrentCurrencyTab
	{
		get
		{
			return _currentCurrencyTab;
		}
		[MemberNotNull("_currentCurrencyTab")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_currentCurrencyTab, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentCurrencyTab);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsGoldTabActive);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsCrystalsTabActive);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsPremiumTabActive);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowNewBadge);
				_currentCurrencyTab = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentCurrencyTab);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsGoldTabActive);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsCrystalsTabActive);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsPremiumTabActive);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowNewBadge);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<ItemModel> AvailableItems
	{
		get
		{
			return _availableItems;
		}
		[MemberNotNull("_availableItems")]
		set
		{
			if (!EqualityComparer<ObservableCollection<ItemModel>>.Default.Equals(_availableItems, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.AvailableItems);
				_availableItems = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.AvailableItems);
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
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanPurchase);
				_isLoading = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsLoading);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanPurchase);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsProcessingPurchase
	{
		get
		{
			return _isProcessingPurchase;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isProcessingPurchase, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsProcessingPurchase);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanPurchase);
				_isProcessingPurchase = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsProcessingPurchase);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanPurchase);
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
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsSortByPriceActive);
				_currentSort = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentSort);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsSortByNameActive);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsSortByRarityActive);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsSortByPriceActive);
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
	public IAsyncRelayCommand<string> ChangeCurrencyTabCommand => (IAsyncRelayCommand<string>)(object)(changeCurrencyTabCommand ?? (changeCurrencyTabCommand = new AsyncRelayCommand<string>((Func<string, global::System.Threading.Tasks.Task>)ChangeCurrencyTab)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<string> ChangeCurrencyTabWithAnimationCommand => (IAsyncRelayCommand<string>)(object)(changeCurrencyTabWithAnimationCommand ?? (changeCurrencyTabWithAnimationCommand = new AsyncRelayCommand<string>((Func<string, global::System.Threading.Tasks.Task>)ChangeCurrencyTabWithAnimation)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ToggleSearchCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = toggleSearchCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)ToggleSearch);
				AsyncRelayCommand val2 = val;
				toggleSearchCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<string> SelectFilterCommand => (IRelayCommand<string>)(object)(selectFilterCommand ?? (selectFilterCommand = new RelayCommand<string>((Action<string>)SelectFilter)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<string> ChangeSortTypeCommand => (IRelayCommand<string>)(object)(changeSortTypeCommand ?? (changeSortTypeCommand = new RelayCommand<string>((Action<string>)ChangeSortType)));

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
	public IAsyncRelayCommand<ItemModel> ShowItemPopupCommand => (IAsyncRelayCommand<ItemModel>)(object)(showItemPopupCommand ?? (showItemPopupCommand = new AsyncRelayCommand<ItemModel>((Func<ItemModel, global::System.Threading.Tasks.Task>)ShowItemPopup)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<ItemModel> CraftItemCommand => (IAsyncRelayCommand<ItemModel>)(object)(craftItemCommand ?? (craftItemCommand = new AsyncRelayCommand<ItemModel>((Func<ItemModel, global::System.Threading.Tasks.Task>)CraftItem)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand GoToSpiritsCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = goToSpiritsCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)GoToSpirits);
				AsyncRelayCommand val2 = val;
				goToSpiritsCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand GoToPouchCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = goToPouchCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)GoToPouch);
				AsyncRelayCommand val2 = val;
				goToPouchCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public ShopHubViewModel(INavigationService navigationService, IPlayerStateService playerStateService, IPopupService popupService, IBottomSheetService bottomSheetService, NavBarViewModel navBarViewModel, PlayerInfoModel playerInfoModel, PurchaseShopItemUseCase purchaseItemUseCase, PurchaseSpiritUseCase purchaseSpiritUseCase, GetSpiritPreviewUseCase getSpiritPreviewUseCase, GetShopItemsUseCase getShopItemsUseCase, MarkShopItemsViewedUseCase markItemsViewedUseCase, IStaticDataCacheService cache, PurchaseCraftingItemUseCase purchaseCraftingItemUseCase)
	{
		_navigationService = navigationService;
		_playerStateService = playerStateService;
		_popupService = popupService;
		_bottomSheetService = bottomSheetService;
		_navBarViewModel = navBarViewModel;
		_playerInfoModel = playerInfoModel;
		_purchaseItemUseCase = purchaseItemUseCase;
		_purchaseSpiritUseCase = purchaseSpiritUseCase;
		_getSpiritPreviewUseCase = getSpiritPreviewUseCase;
		_getShopItemsUseCase = getShopItemsUseCase;
		_markItemsViewedUseCase = markItemsViewedUseCase;
		_cache = cache;
		_purchaseCraftingItemUseCase = purchaseCraftingItemUseCase;
		InitializeFilterChips();
		SubscribeToEvents();
	}

	private void InitializeFilterChips()
	{
		if (IsGoldTabActive)
		{
			ObservableCollection<FilterChipModel> obj = new ObservableCollection<FilterChipModel>();
			((Collection<FilterChipModel>)(object)obj).Add(new FilterChipModel("all", "All", "icon_items.png", isSelected: true));
			((Collection<FilterChipModel>)(object)obj).Add(new FilterChipModel("gear", "Gears", "icon_gear.webp", isSelected: false));
			((Collection<FilterChipModel>)(object)obj).Add(new FilterChipModel("talent", "Talents", "icon_talent.webp", isSelected: false));
			FilterChips = obj;
		}
		else if (IsCrystalsTabActive)
		{
			ObservableCollection<FilterChipModel> obj2 = new ObservableCollection<FilterChipModel>();
			((Collection<FilterChipModel>)(object)obj2).Add(new FilterChipModel("all", "All", "icon_items.png", isSelected: true));
			((Collection<FilterChipModel>)(object)obj2).Add(new FilterChipModel("booster", "Booster", "icon_booster.png", isSelected: false));
			((Collection<FilterChipModel>)(object)obj2).Add(new FilterChipModel("unlock", "Unlock", "icon_items.png", isSelected: false));
			((Collection<FilterChipModel>)(object)obj2).Add(new FilterChipModel("crafting", "Crafting", "icons_crafting.png", isSelected: false));
			FilterChips = obj2;
		}
		else if (IsPremiumTabActive)
		{
			ObservableCollection<FilterChipModel> obj3 = new ObservableCollection<FilterChipModel>();
			((Collection<FilterChipModel>)(object)obj3).Add(new FilterChipModel("all", "All", "icon_items.png", isSelected: true));
			((Collection<FilterChipModel>)(object)obj3).Add(new FilterChipModel("fire", "Fire", "", isSelected: false));
			((Collection<FilterChipModel>)(object)obj3).Add(new FilterChipModel("water", "Water", "", isSelected: false));
			((Collection<FilterChipModel>)(object)obj3).Add(new FilterChipModel("ground", "Ground", "", isSelected: false));
			((Collection<FilterChipModel>)(object)obj3).Add(new FilterChipModel("wind", "Wind", "", isSelected: false));
			((Collection<FilterChipModel>)(object)obj3).Add(new FilterChipModel("light", "Light", "", isSelected: false));
			((Collection<FilterChipModel>)(object)obj3).Add(new FilterChipModel("dark", "Dark", "", isSelected: false));
			((Collection<FilterChipModel>)(object)obj3).Add(new FilterChipModel("grass", "Grass", "", isSelected: false));
			((Collection<FilterChipModel>)(object)obj3).Add(new FilterChipModel("electric", "Electric", "", isSelected: false));
			((Collection<FilterChipModel>)(object)obj3).Add(new FilterChipModel("poison", "Poison", "", isSelected: false));
			((Collection<FilterChipModel>)(object)obj3).Add(new FilterChipModel("metal", "Metal", "", isSelected: false));
			((Collection<FilterChipModel>)(object)obj3).Add(new FilterChipModel("neutral", "Neutral", "", isSelected: false));
			FilterChips = obj3;
		}
	}

	private void SubscribeToEvents()
	{
		_playerStateService.StateChanged += OnStateChanged;
	}

	private void OnStateChanged(object? sender, StateChangedEventArgs e)
	{
		if (e.Scope == StateChangeScope.Player && !(e.ChangeType == "Currencies"))
		{
			if (e.ChangeType == "Inventory")
			{
				RefreshItemsAsync();
			}
			else if (e.ChangeType == "LevelUp")
			{
				RefreshItemsAsync();
			}
		}
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__50))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? param = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__50 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__50();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.param = param;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__50>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadAllShopItems_003Ed__51))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadAllShopItems()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadAllShopItems_003Ed__51 _003CLoadAllShopItems_003Ed__ = new _003CLoadAllShopItems_003Ed__51();
		_003CLoadAllShopItems_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadAllShopItems_003Ed__._003C_003E4__this = this;
		_003CLoadAllShopItems_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadAllShopItems_003Ed__._003C_003Et__builder)).Start<_003CLoadAllShopItems_003Ed__51>(ref _003CLoadAllShopItems_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadAllShopItems_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRefreshItemsAsync_003Ed__52))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task RefreshItemsAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRefreshItemsAsync_003Ed__52 _003CRefreshItemsAsync_003Ed__ = new _003CRefreshItemsAsync_003Ed__52();
		_003CRefreshItemsAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRefreshItemsAsync_003Ed__._003C_003E4__this = this;
		_003CRefreshItemsAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRefreshItemsAsync_003Ed__._003C_003Et__builder)).Start<_003CRefreshItemsAsync_003Ed__52>(ref _003CRefreshItemsAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRefreshItemsAsync_003Ed__._003C_003Et__builder)).Task;
	}

	private global::System.Threading.Tasks.Task UpdateBadgeCountsAsync()
	{
		NewItemsCount = Enumerable.Count<ItemModel>((global::System.Collections.Generic.IEnumerable<ItemModel>)_allShopItems, (Func<ItemModel, bool>)([CompilerGenerated] (ItemModel x) => x.IsNew && x.CurrencyType == CurrentCurrencyTab));
		return global::System.Threading.Tasks.Task.CompletedTask;
	}

	[AsyncStateMachine(typeof(_003CMarkItemsAsViewed_003Ed__54))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task MarkItemsAsViewed()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CMarkItemsAsViewed_003Ed__54 _003CMarkItemsAsViewed_003Ed__ = new _003CMarkItemsAsViewed_003Ed__54();
		_003CMarkItemsAsViewed_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CMarkItemsAsViewed_003Ed__._003C_003E4__this = this;
		_003CMarkItemsAsViewed_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CMarkItemsAsViewed_003Ed__._003C_003Et__builder)).Start<_003CMarkItemsAsViewed_003Ed__54>(ref _003CMarkItemsAsViewed_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CMarkItemsAsViewed_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CChangeCurrencyTab_003Ed__55))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task ChangeCurrencyTab(string currencyTab)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CChangeCurrencyTab_003Ed__55 _003CChangeCurrencyTab_003Ed__ = new _003CChangeCurrencyTab_003Ed__55();
		_003CChangeCurrencyTab_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CChangeCurrencyTab_003Ed__._003C_003E4__this = this;
		_003CChangeCurrencyTab_003Ed__.currencyTab = currencyTab;
		_003CChangeCurrencyTab_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CChangeCurrencyTab_003Ed__._003C_003Et__builder)).Start<_003CChangeCurrencyTab_003Ed__55>(ref _003CChangeCurrencyTab_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CChangeCurrencyTab_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CChangeCurrencyTabWithAnimation_003Ed__56))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task ChangeCurrencyTabWithAnimation(string currencyTab)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CChangeCurrencyTabWithAnimation_003Ed__56 _003CChangeCurrencyTabWithAnimation_003Ed__ = new _003CChangeCurrencyTabWithAnimation_003Ed__56();
		_003CChangeCurrencyTabWithAnimation_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CChangeCurrencyTabWithAnimation_003Ed__._003C_003E4__this = this;
		_003CChangeCurrencyTabWithAnimation_003Ed__.currencyTab = currencyTab;
		_003CChangeCurrencyTabWithAnimation_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CChangeCurrencyTabWithAnimation_003Ed__._003C_003Et__builder)).Start<_003CChangeCurrencyTabWithAnimation_003Ed__56>(ref _003CChangeCurrencyTabWithAnimation_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CChangeCurrencyTabWithAnimation_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CToggleSearch_003Ed__57))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task ToggleSearch()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CToggleSearch_003Ed__57 _003CToggleSearch_003Ed__ = new _003CToggleSearch_003Ed__57();
		_003CToggleSearch_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CToggleSearch_003Ed__._003C_003E4__this = this;
		_003CToggleSearch_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CToggleSearch_003Ed__._003C_003Et__builder)).Start<_003CToggleSearch_003Ed__57>(ref _003CToggleSearch_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CToggleSearch_003Ed__._003C_003Et__builder)).Task;
	}

	[RelayCommand]
	public void SelectFilter(string filterId)
	{
		if (string.IsNullOrEmpty(filterId))
		{
			return;
		}
		SelectedFilter = filterId;
		global::System.Collections.Generic.IEnumerator<FilterChipModel> enumerator = ((Collection<FilterChipModel>)(object)FilterChips).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				FilterChipModel current = enumerator.Current;
				current.IsSelected = current.Id == filterId;
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
		ApplyFiltersAndSort();
	}

	[RelayCommand]
	public void ChangeSortType(string sortType)
	{
		SortType currentSort = default(SortType);
		if (global::System.Enum.TryParse<SortType>(sortType, ref currentSort))
		{
			CurrentSort = currentSort;
			ApplyFiltersAndSort();
		}
	}

	[RelayCommand]
	public void ClearSearch()
	{
		SearchText = string.Empty;
	}

	[AsyncStateMachine(typeof(_003CApplyFiltersAndSort_003Ed__61))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ApplyFiltersAndSort()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CApplyFiltersAndSort_003Ed__61 _003CApplyFiltersAndSort_003Ed__ = new _003CApplyFiltersAndSort_003Ed__61();
		_003CApplyFiltersAndSort_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CApplyFiltersAndSort_003Ed__._003C_003E4__this = this;
		_003CApplyFiltersAndSort_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CApplyFiltersAndSort_003Ed__._003C_003Et__builder)).Start<_003CApplyFiltersAndSort_003Ed__61>(ref _003CApplyFiltersAndSort_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CApplyFiltersAndSort_003Ed__._003C_003Et__builder)).Task;
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

	[AsyncStateMachine(typeof(_003CShowItemPopup_003Ed__63))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task ShowItemPopup(ItemModel item)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CShowItemPopup_003Ed__63 _003CShowItemPopup_003Ed__ = new _003CShowItemPopup_003Ed__63();
		_003CShowItemPopup_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CShowItemPopup_003Ed__._003C_003E4__this = this;
		_003CShowItemPopup_003Ed__.item = item;
		_003CShowItemPopup_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CShowItemPopup_003Ed__._003C_003Et__builder)).Start<_003CShowItemPopup_003Ed__63>(ref _003CShowItemPopup_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CShowItemPopup_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CProcessItemPurchase_003Ed__64))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ProcessItemPurchase(ItemModel item)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CProcessItemPurchase_003Ed__64 _003CProcessItemPurchase_003Ed__ = new _003CProcessItemPurchase_003Ed__64();
		_003CProcessItemPurchase_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CProcessItemPurchase_003Ed__._003C_003E4__this = this;
		_003CProcessItemPurchase_003Ed__.item = item;
		_003CProcessItemPurchase_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CProcessItemPurchase_003Ed__._003C_003Et__builder)).Start<_003CProcessItemPurchase_003Ed__64>(ref _003CProcessItemPurchase_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CProcessItemPurchase_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CCraftItem_003Ed__65))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task CraftItem(ItemModel item)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CCraftItem_003Ed__65 _003CCraftItem_003Ed__ = new _003CCraftItem_003Ed__65();
		_003CCraftItem_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CCraftItem_003Ed__._003C_003E4__this = this;
		_003CCraftItem_003Ed__.item = item;
		_003CCraftItem_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CCraftItem_003Ed__._003C_003Et__builder)).Start<_003CCraftItem_003Ed__65>(ref _003CCraftItem_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CCraftItem_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CShowSpiritPurchase_003Ed__66))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ShowSpiritPurchase(string spiritId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CShowSpiritPurchase_003Ed__66 _003CShowSpiritPurchase_003Ed__ = new _003CShowSpiritPurchase_003Ed__66();
		_003CShowSpiritPurchase_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CShowSpiritPurchase_003Ed__._003C_003E4__this = this;
		_003CShowSpiritPurchase_003Ed__.spiritId = spiritId;
		_003CShowSpiritPurchase_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CShowSpiritPurchase_003Ed__._003C_003Et__builder)).Start<_003CShowSpiritPurchase_003Ed__66>(ref _003CShowSpiritPurchase_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CShowSpiritPurchase_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CProcessSpiritPurchase_003Ed__67))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ProcessSpiritPurchase(string spiritId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CProcessSpiritPurchase_003Ed__67 _003CProcessSpiritPurchase_003Ed__ = new _003CProcessSpiritPurchase_003Ed__67();
		_003CProcessSpiritPurchase_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CProcessSpiritPurchase_003Ed__._003C_003E4__this = this;
		_003CProcessSpiritPurchase_003Ed__.spiritId = spiritId;
		_003CProcessSpiritPurchase_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CProcessSpiritPurchase_003Ed__._003C_003Et__builder)).Start<_003CProcessSpiritPurchase_003Ed__67>(ref _003CProcessSpiritPurchase_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CProcessSpiritPurchase_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CShowSpiritPurchaseSheet_003Ed__68))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<ShopResult> ShowSpiritPurchaseSheet(SpiritPreviewDTO spiritPreview, string currencyType, int currencyAmount, string orbName, int orbAmount)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Guid val = Guid.NewGuid();
		string sheetId = ((object)(Guid)(ref val)).ToString();
		BottomSheet sheet = _navigationService.GetSheetPage<ShopSpiritBottomSheet>("shopspirit");
		ShopSpiritSheetViewModel vm = (ShopSpiritSheetViewModel)(((BindableObject)sheet).BindingContext = new ShopSpiritSheetViewModel(spiritPreview, currencyType, currencyAmount, orbName, orbAmount, _bottomSheetService, _playerStateService, sheetId));
		vm.SetSheet(sheet);
		return await _bottomSheetService.ShowSheetAsync<ShopResult>(sheet, sheetId);
	}

	[AsyncStateMachine(typeof(_003CShowInsufficientFundsPopup_003Ed__69))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ShowInsufficientFundsPopup(string message, string currencyType)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CShowInsufficientFundsPopup_003Ed__69 _003CShowInsufficientFundsPopup_003Ed__ = new _003CShowInsufficientFundsPopup_003Ed__69();
		_003CShowInsufficientFundsPopup_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CShowInsufficientFundsPopup_003Ed__._003C_003E4__this = this;
		_003CShowInsufficientFundsPopup_003Ed__.message = message;
		_003CShowInsufficientFundsPopup_003Ed__.currencyType = currencyType;
		_003CShowInsufficientFundsPopup_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CShowInsufficientFundsPopup_003Ed__._003C_003Et__builder)).Start<_003CShowInsufficientFundsPopup_003Ed__69>(ref _003CShowInsufficientFundsPopup_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CShowInsufficientFundsPopup_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CShowPurchaseCompletion_003Ed__70))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task ShowPurchaseCompletion(string itemName, string itemImage, bool isSpirit)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CShowPurchaseCompletion_003Ed__70 _003CShowPurchaseCompletion_003Ed__ = new _003CShowPurchaseCompletion_003Ed__70();
		_003CShowPurchaseCompletion_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CShowPurchaseCompletion_003Ed__._003C_003E4__this = this;
		_003CShowPurchaseCompletion_003Ed__.itemName = itemName;
		_003CShowPurchaseCompletion_003Ed__.itemImage = itemImage;
		_003CShowPurchaseCompletion_003Ed__.isSpirit = isSpirit;
		_003CShowPurchaseCompletion_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CShowPurchaseCompletion_003Ed__._003C_003Et__builder)).Start<_003CShowPurchaseCompletion_003Ed__70>(ref _003CShowPurchaseCompletion_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CShowPurchaseCompletion_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGoToSpirits_003Ed__71))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoToSpirits()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoToSpirits_003Ed__71 _003CGoToSpirits_003Ed__ = new _003CGoToSpirits_003Ed__71();
		_003CGoToSpirits_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoToSpirits_003Ed__._003C_003E4__this = this;
		_003CGoToSpirits_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoToSpirits_003Ed__._003C_003Et__builder)).Start<_003CGoToSpirits_003Ed__71>(ref _003CGoToSpirits_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoToSpirits_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGoToPouch_003Ed__72))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoToPouch()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoToPouch_003Ed__72 _003CGoToPouch_003Ed__ = new _003CGoToPouch_003Ed__72();
		_003CGoToPouch_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoToPouch_003Ed__._003C_003E4__this = this;
		_003CGoToPouch_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoToPouch_003Ed__._003C_003Et__builder)).Start<_003CGoToPouch_003Ed__72>(ref _003CGoToPouch_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoToPouch_003Ed__._003C_003Et__builder)).Task;
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
