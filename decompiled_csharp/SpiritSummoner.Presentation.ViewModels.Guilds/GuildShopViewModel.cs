using System;
using System.CodeDom.Compiler;
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
using Microsoft.Maui.Controls;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Shop;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Enums.Items;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Infrastructure.Caching;
using SpiritSummoner.Presentation.Models;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.ViewModels.Popups;

namespace SpiritSummoner.Presentation.ViewModels.Guilds;

public class GuildShopViewModel : ObservableObject, ILoadableViewModel, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public ItemModel item;

		internal void _003CShowItemPopup_003Eb__0(ItemPopupViewModel vm)
		{
			vm.IsCrafting = false;
			vm.CurrentItem = item;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass23_0
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
	private sealed class _003CGoBack_003Ed__24 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildShopViewModel _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter<Page> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<Page> awaiter;
					if (num != 0)
					{
						awaiter = ((NavigableElement)Shell.Current).Navigation.PopAsync().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGoBack_003Ed__24 _003CGoBack_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Page>, _003CGoBack_003Ed__24>(ref awaiter, ref _003CGoBack_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Page>);
						num = (_003C_003E1__state = -1);
					}
					awaiter.GetResult();
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__1 = ex;
					Console.WriteLine($"GuildShopViewModel.GoBack: {_003Cex_003E5__1}");
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
	private sealed class _003CLoadDataAsync_003Ed__19 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object param;

		public GuildShopViewModel _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0111;
				}
				if (!_003C_003E4__this.IsLoading)
				{
					try
					{
						_003C_003E4__this.IsLoading = true;
						_003C_003E4__this.ErrorMessage = string.Empty;
						_003C_003E4__this.BuildShopPages();
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__1 = ex;
						_003C_003E4__this.ErrorMessage = "Failed to load guild shop";
						Console.WriteLine($"GuildShopViewModel.LoadDataAsync: {_003Cex_003E5__1}");
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsLoading = false;
						}
					}
					awaiter = global::System.Threading.Tasks.Task.CompletedTask.GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CLoadDataAsync_003Ed__19 _003CLoadDataAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__19>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
						return;
					}
					goto IL_0111;
				}
				goto end_IL_0007;
				IL_0111:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
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
	private sealed class _003CProcessPurchase_003Ed__22 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ItemModel item;

		public GuildShopViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private Result<PurchaseSpiritResponse> _003Cresult_003E5__3;

		private Result<PurchaseSpiritResponse> _003C_003Es__4;

		private PurchaseShopItemRequest _003Crequest_003E5__5;

		private Result<PurchaseShopItemResponse> _003Cresult_003E5__6;

		private Result<PurchaseShopItemResponse> _003C_003Es__7;

		private global::System.Exception _003Cex_003E5__8;

		private TaskAwaiter<Result<PurchaseSpiritResponse>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private TaskAwaiter<Result<PurchaseShopItemResponse>> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0502: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0248: Unknown result type (might be due to invalid IL or missing references)
			//IL_024d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0255: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0301: Unknown result type (might be due to invalid IL or missing references)
			//IL_0309: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0434: Unknown result type (might be due to invalid IL or missing references)
			//IL_0439: Unknown result type (might be due to invalid IL or missing references)
			//IL_0441: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_036e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0373: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0388: Unknown result type (might be due to invalid IL or missing references)
			//IL_038a: Unknown result type (might be due to invalid IL or missing references)
			//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02de: Unknown result type (might be due to invalid IL or missing references)
			//IL_0228: Unknown result type (might be due to invalid IL or missing references)
			//IL_022a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0414: Unknown result type (might be due to invalid IL or missing references)
			//IL_0416: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 6u || !_003C_003E4__this.IsProcessingPurchase)
				{
					try
					{
						TaskAwaiter awaiter;
						if ((uint)num > 5u)
						{
							if (num == 6)
							{
								awaiter = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0511;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter<Result<PurchaseSpiritResponse>> awaiter7;
							TaskAwaiter<Result<PurchaseShopItemResponse>> awaiter4;
							TaskAwaiter awaiter6;
							TaskAwaiter awaiter5;
							TaskAwaiter awaiter3;
							TaskAwaiter awaiter2;
							switch (num)
							{
							default:
								_003C_003E4__this.IsProcessingPurchase = true;
								if (item.IsSpirit)
								{
									awaiter7 = _003C_003E4__this._purchaseSpiritUseCase.ExecuteAsync(new PurchaseSpiritRequest(item.SpiritId, RequireOrb: false)).GetAwaiter();
									if (!awaiter7.IsCompleted)
									{
										num = (_003C_003E1__state = 0);
										_003C_003Eu__1 = awaiter7;
										_003CProcessPurchase_003Ed__22 _003CProcessPurchase_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<PurchaseSpiritResponse>>, _003CProcessPurchase_003Ed__22>(ref awaiter7, ref _003CProcessPurchase_003Ed__);
										return;
									}
									goto IL_0113;
								}
								_003Crequest_003E5__5 = new PurchaseShopItemRequest(item.Id ?? string.Empty, global::System.Enum.Parse<ItemType>(item.Type), 1, MarkAsViewed: false);
								awaiter4 = _003C_003E4__this._purchaseItemUseCase.ExecuteAsync(_003Crequest_003E5__5).GetAwaiter();
								if (!awaiter4.IsCompleted)
								{
									num = (_003C_003E1__state = 3);
									_003C_003Eu__3 = awaiter4;
									_003CProcessPurchase_003Ed__22 _003CProcessPurchase_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<PurchaseShopItemResponse>>, _003CProcessPurchase_003Ed__22>(ref awaiter4, ref _003CProcessPurchase_003Ed__);
									return;
								}
								goto IL_0318;
							case 0:
								awaiter7 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<Result<PurchaseSpiritResponse>>);
								num = (_003C_003E1__state = -1);
								goto IL_0113;
							case 1:
								awaiter6 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_01ca;
							case 2:
								awaiter5 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0264;
							case 3:
								awaiter4 = _003C_003Eu__3;
								_003C_003Eu__3 = default(TaskAwaiter<Result<PurchaseShopItemResponse>>);
								num = (_003C_003E1__state = -1);
								goto IL_0318;
							case 4:
								awaiter3 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_03c4;
							case 5:
								{
									awaiter2 = _003C_003Eu__2;
									_003C_003Eu__2 = default(TaskAwaiter);
									num = (_003C_003E1__state = -1);
									goto IL_0450;
								}
								IL_03c4:
								((TaskAwaiter)(ref awaiter3)).GetResult();
								break;
								IL_0450:
								((TaskAwaiter)(ref awaiter2)).GetResult();
								break;
								IL_0113:
								_003C_003Es__4 = awaiter7.GetResult();
								_003Cresult_003E5__3 = _003C_003Es__4;
								_003C_003Es__4 = null;
								if (_003Cresult_003E5__3.Success)
								{
									awaiter6 = _003C_003E4__this.ShowPurchaseCompletion(_003Cresult_003E5__3.Data.SpiritName, _003Cresult_003E5__3.Data.SpiritImage, isSpirit: true).GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter6)).IsCompleted)
									{
										num = (_003C_003E1__state = 1);
										_003C_003Eu__2 = awaiter6;
										_003CProcessPurchase_003Ed__22 _003CProcessPurchase_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessPurchase_003Ed__22>(ref awaiter6, ref _003CProcessPurchase_003Ed__);
										return;
									}
									goto IL_01ca;
								}
								awaiter5 = _003C_003E4__this._navigationService.ShowAlertAsync("Purchase Failed", _003Cresult_003E5__3.ErrorMessage ?? "Not enough guild coins!").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__2 = awaiter5;
									_003CProcessPurchase_003Ed__22 _003CProcessPurchase_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessPurchase_003Ed__22>(ref awaiter5, ref _003CProcessPurchase_003Ed__);
									return;
								}
								goto IL_0264;
								IL_026d:
								_003Cresult_003E5__3 = null;
								goto end_IL_0040;
								IL_0318:
								_003C_003Es__7 = awaiter4.GetResult();
								_003Cresult_003E5__6 = _003C_003Es__7;
								_003C_003Es__7 = null;
								if (_003Cresult_003E5__6.Success)
								{
									awaiter3 = _003C_003E4__this.ShowPurchaseCompletion(item.Name, item.Icon, isSpirit: false).GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
									{
										num = (_003C_003E1__state = 4);
										_003C_003Eu__2 = awaiter3;
										_003CProcessPurchase_003Ed__22 _003CProcessPurchase_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessPurchase_003Ed__22>(ref awaiter3, ref _003CProcessPurchase_003Ed__);
										return;
									}
									goto IL_03c4;
								}
								awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Purchase Failed", _003Cresult_003E5__6.ErrorMessage ?? "Not enough guild coins!").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 5);
									_003C_003Eu__2 = awaiter2;
									_003CProcessPurchase_003Ed__22 _003CProcessPurchase_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessPurchase_003Ed__22>(ref awaiter2, ref _003CProcessPurchase_003Ed__);
									return;
								}
								goto IL_0450;
								IL_01ca:
								((TaskAwaiter)(ref awaiter6)).GetResult();
								_003C_003E4__this.BuildShopPages();
								goto IL_026d;
								IL_0264:
								((TaskAwaiter)(ref awaiter5)).GetResult();
								goto IL_026d;
							}
							_003Crequest_003E5__5 = null;
							_003Cresult_003E5__6 = null;
							end_IL_0040:;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
						}
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_0555;
						}
						_003Cex_003E5__8 = (global::System.Exception)_003C_003Es__1;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Purchase Error", "Failed to complete purchase").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 6);
							_003C_003Eu__2 = awaiter;
							_003CProcessPurchase_003Ed__22 _003CProcessPurchase_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessPurchase_003Ed__22>(ref awaiter, ref _003CProcessPurchase_003Ed__);
							return;
						}
						goto IL_0511;
						IL_0511:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine($"GuildShopViewModel.ProcessPurchase: {_003Cex_003E5__8}");
						_003Cex_003E5__8 = null;
						goto IL_0555;
						IL_0555:
						_003C_003Es__1 = null;
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
	private sealed class _003CShowItemPopup_003Ed__21 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ItemModel item;

		public GuildShopViewModel _003C_003E4__this;

		private _003C_003Ec__DisplayClass21_0 _003C_003E8__1;

		private object _003Cresult_003E5__2;

		private bool _003Cconfirmed_003E5__3;

		private object _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<object?> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0274: Unknown result type (might be due to invalid IL or missing references)
			//IL_0279: Unknown result type (might be due to invalid IL or missing references)
			//IL_0281: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0199: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_023a: Unknown result type (might be due to invalid IL or missing references)
			//IL_023f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0254: Unknown result type (might be due to invalid IL or missing references)
			//IL_0256: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0132;
				}
				if ((uint)(num - 1) <= 1u)
				{
					goto IL_0140;
				}
				_003C_003E8__1 = new _003C_003Ec__DisplayClass21_0();
				_003C_003E8__1.item = item;
				if (_003C_003E4__this.CanPurchase && _003C_003E8__1.item != null)
				{
					if (_003C_003E8__1.item.GuildShopLevel > _003C_003E4__this._guildLevel)
					{
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Locked", $"Reach guild level {_003C_003E8__1.item.GuildShopLevel} to unlock these items.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CShowItemPopup_003Ed__21 _003CShowItemPopup_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CShowItemPopup_003Ed__21>(ref awaiter, ref _003CShowItemPopup_003Ed__);
							return;
						}
						goto IL_0132;
					}
					goto IL_0140;
				}
				goto end_IL_0007;
				IL_0140:
				try
				{
					TaskAwaiter awaiter2;
					TaskAwaiter<object> awaiter3;
					if (num != 1)
					{
						if (num == 2)
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0290;
						}
						awaiter3 = _003C_003E4__this._popupService.ShowPopupAsync<ItemPopupViewModel>((Action<ItemPopupViewModel>)delegate(ItemPopupViewModel vm)
						{
							vm.IsCrafting = false;
							vm.CurrentItem = _003C_003E8__1.item;
						}, default(CancellationToken)).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter3;
							_003CShowItemPopup_003Ed__21 _003CShowItemPopup_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CShowItemPopup_003Ed__21>(ref awaiter3, ref _003CShowItemPopup_003Ed__);
							return;
						}
					}
					else
					{
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<object>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__4 = awaiter3.GetResult();
					_003Cresult_003E5__2 = _003C_003Es__4;
					_003C_003Es__4 = null;
					int num2;
					if (_003Cresult_003E5__2 is bool)
					{
						_003Cconfirmed_003E5__3 = (bool)_003Cresult_003E5__2;
						num2 = 1;
					}
					else
					{
						num2 = 0;
					}
					if (((uint)num2 & (_003Cconfirmed_003E5__3 ? 1u : 0u)) != 0)
					{
						awaiter2 = _003C_003E4__this.ProcessPurchase(_003C_003E8__1.item).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = awaiter2;
							_003CShowItemPopup_003Ed__21 _003CShowItemPopup_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CShowItemPopup_003Ed__21>(ref awaiter2, ref _003CShowItemPopup_003Ed__);
							return;
						}
						goto IL_0290;
					}
					goto IL_0298;
					IL_0290:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					goto IL_0298;
					IL_0298:
					_003Cresult_003E5__2 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					_003C_003E4__this.ErrorMessage = "Failed to show item popup";
					Console.WriteLine($"GuildShopViewModel.ShowItemPopup: {_003Cex_003E5__5}");
				}
				goto end_IL_0007;
				IL_0132:
				((TaskAwaiter)(ref awaiter)).GetResult();
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
	private sealed class _003CShowPurchaseCompletion_003Ed__23 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string itemName;

		public string itemImage;

		public bool isSpirit;

		public GuildShopViewModel _003C_003E4__this;

		private _003C_003Ec__DisplayClass23_0 _003C_003E8__1;

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
					_003C_003E8__1 = new _003C_003Ec__DisplayClass23_0();
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
							_003CShowPurchaseCompletion_003Ed__23 _003CShowPurchaseCompletion_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CShowPurchaseCompletion_003Ed__23>(ref awaiter, ref _003CShowPurchaseCompletion_003Ed__);
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
					Console.WriteLine($"GuildShopViewModel.ShowPurchaseCompletion: {_003Cex_003E5__2}");
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

	private readonly INavigationService _navigationService;

	private readonly IGuildStateService _guildStateService;

	private readonly IStaticDataCacheService _cache;

	private readonly IPopupService _popupService;

	private readonly PlayerInfoModel _playerInfoModel;

	private readonly PurchaseShopItemUseCase _purchaseItemUseCase;

	private readonly PurchaseSpiritUseCase _purchaseSpiritUseCase;

	private bool _disposed;

	private int _guildLevel;

	[ObservableProperty]
	private ObservableCollection<GuildLevelPage> _shopPages = new ObservableCollection<GuildLevelPage>();

	[ObservableProperty]
	private GuildLevelPage? _currentGuildShopItems;

	[ObservableProperty]
	[NotifyPropertyChangedFor("CanPurchase")]
	private bool _isLoading;

	[ObservableProperty]
	[NotifyPropertyChangedFor("CanPurchase")]
	private bool _isProcessingPurchase;

	[ObservableProperty]
	private string _errorMessage = string.Empty;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<object?>? loadDataCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<ItemModel>? showItemPopupCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goBackCommand;

	public PlayerInfoModel CurrentPlayer => _playerInfoModel;

	public bool CanPurchase => !IsLoading && !IsProcessingPurchase;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<GuildLevelPage> ShopPages
	{
		get
		{
			return _shopPages;
		}
		[MemberNotNull("_shopPages")]
		set
		{
			if (!EqualityComparer<ObservableCollection<GuildLevelPage>>.Default.Equals(_shopPages, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShopPages);
				_shopPages = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShopPages);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public GuildLevelPage? CurrentGuildShopItems
	{
		get
		{
			return _currentGuildShopItems;
		}
		set
		{
			if (!EqualityComparer<GuildLevelPage>.Default.Equals(_currentGuildShopItems, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentGuildShopItems);
				_currentGuildShopItems = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentGuildShopItems);
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
	public IAsyncRelayCommand<ItemModel> ShowItemPopupCommand => (IAsyncRelayCommand<ItemModel>)(object)(showItemPopupCommand ?? (showItemPopupCommand = new AsyncRelayCommand<ItemModel>((Func<ItemModel, global::System.Threading.Tasks.Task>)ShowItemPopup)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand GoBackCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = goBackCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)GoBack);
				AsyncRelayCommand val2 = val;
				goBackCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public GuildShopViewModel(INavigationService navigationService, IGuildStateService guildStateService, IStaticDataCacheService cache, IPopupService popupService, PlayerInfoModel playerInfoModel, PurchaseShopItemUseCase purchaseItemUseCase, PurchaseSpiritUseCase purchaseSpiritUseCase)
	{
		_navigationService = navigationService;
		_guildStateService = guildStateService;
		_cache = cache;
		_popupService = popupService;
		_playerInfoModel = playerInfoModel;
		_purchaseItemUseCase = purchaseItemUseCase;
		_purchaseSpiritUseCase = purchaseSpiritUseCase;
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__19))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? param = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__19 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__19();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.param = param;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__19>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	private void BuildShopPages()
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		_guildLevel = _guildStateService.GetCurrentGuild()?.Level ?? 0;
		List<ItemModel> val = new List<ItemModel>();
		ValueCollection<string, Item>[] array = new ValueCollection<string, Item>[3]
		{
			_cache.Items.Values,
			_cache.Gears.Values,
			_cache.Talents.Values
		};
		ValueCollection<string, Item>[] array2 = array;
		foreach (ValueCollection<string, Item> val2 in array2)
		{
			Enumerator<string, Item> enumerator = val2.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Item current = enumerator.Current;
					if (!(current.Requirements?.CurrencyCost?.Type != "clancredits") && (current.Requirements.LevelRequirement?.GuildRankRequired ?? 0) <= _guildLevel + 1)
					{
						val.Add(new ItemModel(current, isNew: false));
					}
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator).Dispose();
			}
		}
		Enumerator<string, Spirit> enumerator2 = _cache.Spirits.Values.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				Spirit current2 = enumerator2.Current;
				if (!(current2.Requirements?.CurrencyCost?.Type != "clancredits") && (current2.Requirements.LevelRequirement?.GuildRankRequired ?? 0) <= _guildLevel + 1)
				{
					val.Add(new ItemModel(current2, isNew: false, "clancredits", current2.Requirements.CurrencyCost.Amount, current2.Requirements.LevelRequirement?.GuildRankRequired ?? 0));
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator2).Dispose();
		}
		List<GuildLevelPage> val3 = Enumerable.ToList<GuildLevelPage>(Enumerable.Select<IGrouping<int, ItemModel>, GuildLevelPage>((global::System.Collections.Generic.IEnumerable<IGrouping<int, ItemModel>>)Enumerable.OrderBy<IGrouping<int, ItemModel>, int>(Enumerable.GroupBy<ItemModel, int>((global::System.Collections.Generic.IEnumerable<ItemModel>)val, (Func<ItemModel, int>)((ItemModel i) => i.GuildShopLevel)), (Func<IGrouping<int, ItemModel>, int>)((IGrouping<int, ItemModel> g) => g.Key)), (Func<IGrouping<int, ItemModel>, GuildLevelPage>)([CompilerGenerated] (IGrouping<int, ItemModel> g) => new GuildLevelPage
		{
			Level = g.Key,
			IsLocked = (g.Key > _guildLevel),
			Items = new ObservableCollection<ItemModel>((global::System.Collections.Generic.IEnumerable<ItemModel>)Enumerable.OrderBy<ItemModel, string>((global::System.Collections.Generic.IEnumerable<ItemModel>)g, (Func<ItemModel, string>)((ItemModel i) => i.Name)))
		})));
		ShopPages = new ObservableCollection<GuildLevelPage>(val3);
		CurrentGuildShopItems = Enumerable.FirstOrDefault<GuildLevelPage>((global::System.Collections.Generic.IEnumerable<GuildLevelPage>)val3, (Func<GuildLevelPage, bool>)([CompilerGenerated] (GuildLevelPage p) => p.Level == _guildLevel)) ?? Enumerable.LastOrDefault<GuildLevelPage>((global::System.Collections.Generic.IEnumerable<GuildLevelPage>)val3);
	}

	[AsyncStateMachine(typeof(_003CShowItemPopup_003Ed__21))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task ShowItemPopup(ItemModel item)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CShowItemPopup_003Ed__21 _003CShowItemPopup_003Ed__ = new _003CShowItemPopup_003Ed__21();
		_003CShowItemPopup_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CShowItemPopup_003Ed__._003C_003E4__this = this;
		_003CShowItemPopup_003Ed__.item = item;
		_003CShowItemPopup_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CShowItemPopup_003Ed__._003C_003Et__builder)).Start<_003CShowItemPopup_003Ed__21>(ref _003CShowItemPopup_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CShowItemPopup_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CProcessPurchase_003Ed__22))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ProcessPurchase(ItemModel item)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CProcessPurchase_003Ed__22 _003CProcessPurchase_003Ed__ = new _003CProcessPurchase_003Ed__22();
		_003CProcessPurchase_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CProcessPurchase_003Ed__._003C_003E4__this = this;
		_003CProcessPurchase_003Ed__.item = item;
		_003CProcessPurchase_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CProcessPurchase_003Ed__._003C_003Et__builder)).Start<_003CProcessPurchase_003Ed__22>(ref _003CProcessPurchase_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CProcessPurchase_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CShowPurchaseCompletion_003Ed__23))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ShowPurchaseCompletion(string itemName, string itemImage, bool isSpirit)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CShowPurchaseCompletion_003Ed__23 _003CShowPurchaseCompletion_003Ed__ = new _003CShowPurchaseCompletion_003Ed__23();
		_003CShowPurchaseCompletion_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CShowPurchaseCompletion_003Ed__._003C_003E4__this = this;
		_003CShowPurchaseCompletion_003Ed__.itemName = itemName;
		_003CShowPurchaseCompletion_003Ed__.itemImage = itemImage;
		_003CShowPurchaseCompletion_003Ed__.isSpirit = isSpirit;
		_003CShowPurchaseCompletion_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CShowPurchaseCompletion_003Ed__._003C_003Et__builder)).Start<_003CShowPurchaseCompletion_003Ed__23>(ref _003CShowPurchaseCompletion_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CShowPurchaseCompletion_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGoBack_003Ed__24))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoBack()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoBack_003Ed__24 _003CGoBack_003Ed__ = new _003CGoBack_003Ed__24();
		_003CGoBack_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoBack_003Ed__._003C_003E4__this = this;
		_003CGoBack_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Start<_003CGoBack_003Ed__24>(ref _003CGoBack_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Task;
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			_disposed = true;
			GC.SuppressFinalize((object)this);
		}
	}
}
