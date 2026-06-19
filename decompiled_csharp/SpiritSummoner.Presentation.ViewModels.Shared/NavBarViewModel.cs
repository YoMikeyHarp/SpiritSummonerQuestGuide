using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.Events;
using SpiritSummoner.Application.Services;
using SpiritSummoner.Application.State;
using SpiritSummoner.Presentation.Models;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.Battles;
using SpiritSummoner.Presentation.ViewModels.BottomSheet;
using SpiritSummoner.Presentation.ViewModels.Guilds;
using SpiritSummoner.Presentation.ViewModels.Quests;
using SpiritSummoner.Presentation.ViewModels.Shop;
using SpiritSummoner.Presentation.ViewModels.StartUp;
using SpiritSummoner.Presentation.Views;
using SpiritSummoner.Presentation.Views.Battle;
using SpiritSummoner.Presentation.Views.BottomSheets.Hub;
using SpiritSummoner.Presentation.Views.Guilds;
using SpiritSummoner.Presentation.Views.Quests;
using SpiritSummoner.Presentation.Views.Shop;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.ViewModels.Shared;

public class NavBarViewModel : ObservableObject
{
	[CompilerGenerated]
	private sealed class _003CHubSheet_003Ed__21 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public NavBarViewModel _003C_003E4__this;

		private BottomSheet _003CcachedSheet_003E5__1;

		private BottomSheet _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<BottomSheet> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter<BottomSheet> awaiter;
					if (num == 0)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<BottomSheet>);
						num = (_003C_003E1__state = -1);
						goto IL_00a7;
					}
					TaskAwaiter awaiter2;
					if (num == 1)
					{
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0132;
					}
					if (_003C_003E4__this._navigationService.CanNavigate())
					{
						awaiter = _003C_003E4__this._navigationService.GetFullSheet<HubBottomSheet, HubSheetViewModel>("hub").GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CHubSheet_003Ed__21 _003CHubSheet_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<BottomSheet>, _003CHubSheet_003Ed__21>(ref awaiter, ref _003CHubSheet_003Ed__);
							return;
						}
						goto IL_00a7;
					}
					goto end_IL_0011;
					IL_0132:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					_003CcachedSheet_003E5__1 = null;
					goto end_IL_0011;
					IL_00a7:
					_003C_003Es__2 = awaiter.GetResult();
					_003CcachedSheet_003E5__1 = _003C_003Es__2;
					_003C_003Es__2 = null;
					awaiter2 = _003C_003E4__this._bottomSheetService.ShowSheetAsync(_003CcachedSheet_003E5__1).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter2;
						_003CHubSheet_003Ed__21 _003CHubSheet_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHubSheet_003Ed__21>(ref awaiter2, ref _003CHubSheet_003Ed__);
						return;
					}
					goto IL_0132;
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine("Navigation Error" + _003Cex_003E5__3.Message);
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
	private sealed class _003CInitialize_003Ed__18 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public NavBarViewModel _003C_003E4__this;

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
					awaiter = _003C_003E4__this._playerInfoModel.InitializeAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CInitialize_003Ed__18 _003CInitialize_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CInitialize_003Ed__18>(ref awaiter, ref _003CInitialize_003Ed__);
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
				_003C_003E4__this.VisibleItems = new ObservableCollection<NavItem>(_003C_003E4__this._allItems);
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
	private sealed class _003CNavigateTo_003Ed__20 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string route;

		public NavBarViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private string _003CnormalizedRoute_003E5__3;

		private string _003CbaseRoute_003E5__4;

		private ContentView _003Cview_003E5__5;

		private ContentView _003C_003Es__6;

		private string _003C_003Es__7;

		private object _003C_003Es__8;

		private object _003C_003Es__9;

		private object _003C_003Es__10;

		private object _003C_003Es__11;

		private object _003C_003Es__12;

		private object _003C_003Es__13;

		private global::System.Exception _003Cex_003E5__14;

		private TaskAwaiter<object> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_06b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_06b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_06cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_06cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_06e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0262: Unknown result type (might be due to invalid IL or missing references)
			//IL_0267: Unknown result type (might be due to invalid IL or missing references)
			//IL_026f: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0303: Unknown result type (might be due to invalid IL or missing references)
			//IL_038a: Unknown result type (might be due to invalid IL or missing references)
			//IL_038f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0397: Unknown result type (might be due to invalid IL or missing references)
			//IL_041e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0423: Unknown result type (might be due to invalid IL or missing references)
			//IL_042b: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_0546: Unknown result type (might be due to invalid IL or missing references)
			//IL_054b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0553: Unknown result type (might be due to invalid IL or missing references)
			//IL_061d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0622: Unknown result type (might be due to invalid IL or missing references)
			//IL_062a: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_05fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0228: Unknown result type (might be due to invalid IL or missing references)
			//IL_022d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0242: Unknown result type (might be due to invalid IL or missing references)
			//IL_0244: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0350: Unknown result type (might be due to invalid IL or missing references)
			//IL_0355: Unknown result type (might be due to invalid IL or missing references)
			//IL_036a: Unknown result type (might be due to invalid IL or missing references)
			//IL_036c: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0400: Unknown result type (might be due to invalid IL or missing references)
			//IL_0478: Unknown result type (might be due to invalid IL or missing references)
			//IL_047d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0492: Unknown result type (might be due to invalid IL or missing references)
			//IL_0494: Unknown result type (might be due to invalid IL or missing references)
			//IL_050c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0511: Unknown result type (might be due to invalid IL or missing references)
			//IL_0526: Unknown result type (might be due to invalid IL or missing references)
			//IL_0528: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if ((uint)num > 6u)
				{
					if (num == 7)
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0704;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter<object> awaiter4;
					TaskAwaiter<object> awaiter3;
					TaskAwaiter<object> awaiter5;
					TaskAwaiter<object> awaiter6;
					TaskAwaiter<object> awaiter7;
					TaskAwaiter<object> awaiter8;
					TaskAwaiter awaiter2;
					object bindingContext;
					switch (num)
					{
					default:
						if (_003C_003E4__this._navigationService.CanNavigate() && !(_003C_003E4__this._playerState.CurrentRoute == route))
						{
							_003CnormalizedRoute_003E5__3 = (route.StartsWith("//") ? route : ("//" + route));
							_003CbaseRoute_003E5__4 = _003CnormalizedRoute_003E5__3.Split('/', (StringSplitOptions)0)[2];
							_003Cview_003E5__5 = _003C_003E4__this._pageCacheService.GetMainPage("//" + _003CbaseRoute_003E5__4);
							if (_003Cview_003E5__5 != null)
							{
								_003C_003E4__this.CurrentRoute = _003CnormalizedRoute_003E5__3;
								if (_003CbaseRoute_003E5__4.ToLower() == "guild" || _003CbaseRoute_003E5__4.ToLower() == "battlehub")
								{
									_003C_003E4__this.IsPlayerInfoVisible = false;
								}
								else
								{
									_003C_003E4__this.IsPlayerInfoVisible = true;
								}
								_003C_003Es__6 = _003Cview_003E5__5;
								_003C_003Es__7 = _003CbaseRoute_003E5__4.ToLower();
								if (1 == 0)
								{
								}
								string text = _003C_003Es__7;
								if (!(text == "main"))
								{
									if (!(text == "quest"))
									{
										if (!(text == "battlehub"))
										{
											if (!(text == "shop"))
											{
												if (text == "guild")
												{
													awaiter4 = _003C_003E4__this._navigationService.NavigateToMainPageAsync<GuildHubNewPage, GuildHubViewModel>(route, route, null).GetAwaiter();
													if (!awaiter4.IsCompleted)
													{
														num = (_003C_003E1__state = 4);
														_003C_003Eu__1 = awaiter4;
														_003CNavigateTo_003Ed__20 _003CNavigateTo_003Ed__ = this;
														((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CNavigateTo_003Ed__20>(ref awaiter4, ref _003CNavigateTo_003Ed__);
														return;
													}
													goto IL_04ce;
												}
												awaiter3 = _003C_003E4__this._navigationService.NavigateToMainPageAsync<MainPage, MainViewModel>(route, route, null).GetAwaiter();
												if (!awaiter3.IsCompleted)
												{
													num = (_003C_003E1__state = 5);
													_003C_003Eu__1 = awaiter3;
													_003CNavigateTo_003Ed__20 _003CNavigateTo_003Ed__ = this;
													((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CNavigateTo_003Ed__20>(ref awaiter3, ref _003CNavigateTo_003Ed__);
													return;
												}
												goto IL_0562;
											}
											awaiter5 = _003C_003E4__this._navigationService.NavigateToMainPageAsync<ShopHubPage, ShopHubViewModel>(route, route, null).GetAwaiter();
											if (!awaiter5.IsCompleted)
											{
												num = (_003C_003E1__state = 3);
												_003C_003Eu__1 = awaiter5;
												_003CNavigateTo_003Ed__20 _003CNavigateTo_003Ed__ = this;
												((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CNavigateTo_003Ed__20>(ref awaiter5, ref _003CNavigateTo_003Ed__);
												return;
											}
											goto IL_043a;
										}
										awaiter6 = _003C_003E4__this._navigationService.NavigateToMainPageAsync<BattleHubPage, BattleHubViewModel>(route, route, null).GetAwaiter();
										if (!awaiter6.IsCompleted)
										{
											num = (_003C_003E1__state = 2);
											_003C_003Eu__1 = awaiter6;
											_003CNavigateTo_003Ed__20 _003CNavigateTo_003Ed__ = this;
											((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CNavigateTo_003Ed__20>(ref awaiter6, ref _003CNavigateTo_003Ed__);
											return;
										}
										goto IL_03a6;
									}
									awaiter7 = _003C_003E4__this._navigationService.NavigateToMainPageAsync<QuestView, QuestViewModel>(route, route, null).GetAwaiter();
									if (!awaiter7.IsCompleted)
									{
										num = (_003C_003E1__state = 1);
										_003C_003Eu__1 = awaiter7;
										_003CNavigateTo_003Ed__20 _003CNavigateTo_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CNavigateTo_003Ed__20>(ref awaiter7, ref _003CNavigateTo_003Ed__);
										return;
									}
									goto IL_0312;
								}
								awaiter8 = _003C_003E4__this._navigationService.NavigateToMainPageAsync<MainPage, MainViewModel>(route, route, null).GetAwaiter();
								if (!awaiter8.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter8;
									_003CNavigateTo_003Ed__20 _003CNavigateTo_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CNavigateTo_003Ed__20>(ref awaiter8, ref _003CNavigateTo_003Ed__);
									return;
								}
								goto IL_027e;
							}
							awaiter2 = _003C_003E4__this._navigationService.NavigateToAsync(_003CnormalizedRoute_003E5__3).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 6);
								_003C_003Eu__2 = awaiter2;
								_003CNavigateTo_003Ed__20 _003CNavigateTo_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateTo_003Ed__20>(ref awaiter2, ref _003CNavigateTo_003Ed__);
								return;
							}
							goto IL_0639;
						}
						goto end_IL_0023;
					case 0:
						awaiter8 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<object>);
						num = (_003C_003E1__state = -1);
						goto IL_027e;
					case 1:
						awaiter7 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<object>);
						num = (_003C_003E1__state = -1);
						goto IL_0312;
					case 2:
						awaiter6 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<object>);
						num = (_003C_003E1__state = -1);
						goto IL_03a6;
					case 3:
						awaiter5 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<object>);
						num = (_003C_003E1__state = -1);
						goto IL_043a;
					case 4:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<object>);
						num = (_003C_003E1__state = -1);
						goto IL_04ce;
					case 5:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<object>);
						num = (_003C_003E1__state = -1);
						goto IL_0562;
					case 6:
						{
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0639;
						}
						IL_043a:
						_003C_003Es__11 = awaiter5.GetResult();
						bindingContext = _003C_003Es__11;
						_003C_003Es__11 = null;
						goto IL_0580;
						IL_0639:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						break;
						IL_04ce:
						_003C_003Es__12 = awaiter4.GetResult();
						bindingContext = _003C_003Es__12;
						_003C_003Es__12 = null;
						goto IL_0580;
						IL_027e:
						_003C_003Es__8 = awaiter8.GetResult();
						bindingContext = _003C_003Es__8;
						_003C_003Es__8 = null;
						goto IL_0580;
						IL_03a6:
						_003C_003Es__10 = awaiter6.GetResult();
						bindingContext = _003C_003Es__10;
						_003C_003Es__10 = null;
						goto IL_0580;
						IL_0580:
						if (1 == 0)
						{
						}
						((BindableObject)_003C_003Es__6).BindingContext = bindingContext;
						_003C_003Es__6 = null;
						_003C_003Es__7 = null;
						_003C_003E4__this._playerState.UpdateCurrentRoute(_003CnormalizedRoute_003E5__3);
						_003C_003E4__this.CurrentPage = _003Cview_003E5__5;
						break;
						IL_0562:
						_003C_003Es__13 = awaiter3.GetResult();
						bindingContext = _003C_003Es__13;
						_003C_003Es__13 = null;
						goto IL_0580;
						IL_0312:
						_003C_003Es__9 = awaiter7.GetResult();
						bindingContext = _003C_003Es__9;
						_003C_003Es__9 = null;
						goto IL_0580;
					}
					_003CnormalizedRoute_003E5__3 = null;
					_003CbaseRoute_003E5__4 = null;
					_003Cview_003E5__5 = null;
					goto IL_066d;
					end_IL_0023:;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
					goto IL_066d;
				}
				goto end_IL_0007;
				IL_066d:
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_0716;
				}
				_003Cex_003E5__14 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cex_003E5__14.Message).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 7);
					_003C_003Eu__2 = awaiter;
					_003CNavigateTo_003Ed__20 _003CNavigateTo_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateTo_003Ed__20>(ref awaiter, ref _003CNavigateTo_003Ed__);
					return;
				}
				goto IL_0704;
				IL_0704:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__14 = null;
				goto IL_0716;
				IL_0716:
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

	private readonly INavigationService _navigationService;

	private readonly IPlayerStateService _playerState;

	private readonly IBottomSheetService _bottomSheetService;

	private PlayerInfoModel _playerInfoModel;

	private readonly List<NavItem> _allItems = new List<NavItem>();

	private readonly IPageCacheService _pageCacheService;

	private readonly IChatUnreadService _chatUnreadService;

	[ObservableProperty]
	private ObservableCollection<NavItem> _visibleItems = new ObservableCollection<NavItem>();

	[ObservableProperty]
	private bool _hasUnReadMessages;

	[ObservableProperty]
	private int _unReadMessageCount;

	[ObservableProperty]
	private string? _currentRoute;

	[ObservableProperty]
	private ContentView? _currentPage;

	[ObservableProperty]
	private bool _isPlayerInfoVisible = true;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<string>? navigateToCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? hubSheetCommand;

	public PlayerInfoModel? PlayerInfoModel
	{
		get
		{
			return _playerInfoModel;
		}
		set
		{
			((ObservableObject)this).SetProperty<PlayerInfoModel>(ref _playerInfoModel, value, "PlayerInfoModel");
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<NavItem> VisibleItems
	{
		get
		{
			return _visibleItems;
		}
		[MemberNotNull("_visibleItems")]
		set
		{
			if (!EqualityComparer<ObservableCollection<NavItem>>.Default.Equals(_visibleItems, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.VisibleItems);
				_visibleItems = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.VisibleItems);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool HasUnReadMessages
	{
		get
		{
			return _hasUnReadMessages;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasUnReadMessages, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasUnReadMessages);
				_hasUnReadMessages = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasUnReadMessages);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int UnReadMessageCount
	{
		get
		{
			return _unReadMessageCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_unReadMessageCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.UnReadMessageCount);
				_unReadMessageCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.UnReadMessageCount);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? CurrentRoute
	{
		get
		{
			return _currentRoute;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_currentRoute, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentRoute);
				_currentRoute = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentRoute);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ContentView? CurrentPage
	{
		get
		{
			return _currentPage;
		}
		set
		{
			if (!EqualityComparer<ContentView>.Default.Equals(_currentPage, value))
			{
				ContentView currentPage = _currentPage;
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentPage);
				_currentPage = value;
				OnCurrentPageChanged(currentPage, value);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentPage);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsPlayerInfoVisible
	{
		get
		{
			return _isPlayerInfoVisible;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isPlayerInfoVisible, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsPlayerInfoVisible);
				_isPlayerInfoVisible = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsPlayerInfoVisible);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<string> NavigateToCommand => (IAsyncRelayCommand<string>)(object)(navigateToCommand ?? (navigateToCommand = new AsyncRelayCommand<string>((Func<string, global::System.Threading.Tasks.Task>)NavigateTo)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand HubSheetCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = hubSheetCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)HubSheet);
				AsyncRelayCommand val2 = val;
				hubSheetCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public NavBarViewModel(INavigationService navigationService, IBottomSheetService bottomSheetService, IPlayerStateService playerState, PlayerInfoModel playerInfoModel, IPageCacheService pageCacheService, IChatUnreadService chatUnreadService)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		_pageCacheService = pageCacheService;
		_navigationService = navigationService;
		_playerState = playerState;
		_bottomSheetService = bottomSheetService;
		_playerInfoModel = playerInfoModel;
		_chatUnreadService = chatUnreadService;
		_chatUnreadService.UnreadCountChanged += new EventHandler(OnUnreadCountChanged);
		List<NavItem> obj = new List<NavItem>();
		obj.Add(new NavItem("Quest", "icon_quest_outlined.png", "//quest", (ICommand)(object)NavigateToCommand));
		obj.Add(new NavItem("Battle", "icon_battle_outlined.png", "//battlehub", (ICommand)(object)NavigateToCommand));
		obj.Add(new NavItem("Home", "icon_home_outlined.png", "//main", (ICommand)(object)NavigateToCommand));
		obj.Add(new NavItem("Chat", "icon_chat_outlined.png", "//chat", (ICommand)(object)NavigateToCommand));
		obj.Add(new NavItem("Hub", "icon_hub_outlined.png", "//hub", (ICommand)(object)HubSheetCommand));
		_allItems = obj;
		_playerState.StateChanged += OnPlayerStateChanged;
		if (_playerState.GetCurrentPlayer() != null)
		{
			Initialize();
		}
	}

	private void OnPlayerStateChanged(object? sender, StateChangedEventArgs e)
	{
		if (e.Scope == StateChangeScope.Player && _playerState.GetCurrentPlayer() != null)
		{
			Initialize();
		}
	}

	[AsyncStateMachine(typeof(_003CInitialize_003Ed__18))]
	[DebuggerStepThrough]
	private void Initialize()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CInitialize_003Ed__18 _003CInitialize_003Ed__ = new _003CInitialize_003Ed__18();
		_003CInitialize_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CInitialize_003Ed__._003C_003E4__this = this;
		_003CInitialize_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CInitialize_003Ed__._003C_003Et__builder)).Start<_003CInitialize_003Ed__18>(ref _003CInitialize_003Ed__);
	}

	public ContentView GetPage(string route)
	{
		return _pageCacheService.GetMainPage(route);
	}

	[AsyncStateMachine(typeof(_003CNavigateTo_003Ed__20))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task NavigateTo(string route)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CNavigateTo_003Ed__20 _003CNavigateTo_003Ed__ = new _003CNavigateTo_003Ed__20();
		_003CNavigateTo_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CNavigateTo_003Ed__._003C_003E4__this = this;
		_003CNavigateTo_003Ed__.route = route;
		_003CNavigateTo_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CNavigateTo_003Ed__._003C_003Et__builder)).Start<_003CNavigateTo_003Ed__20>(ref _003CNavigateTo_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CNavigateTo_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CHubSheet_003Ed__21))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task HubSheet()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CHubSheet_003Ed__21 _003CHubSheet_003Ed__ = new _003CHubSheet_003Ed__21();
		_003CHubSheet_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CHubSheet_003Ed__._003C_003E4__this = this;
		_003CHubSheet_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CHubSheet_003Ed__._003C_003Et__builder)).Start<_003CHubSheet_003Ed__21>(ref _003CHubSheet_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CHubSheet_003Ed__._003C_003Et__builder)).Task;
	}

	private void OnUnreadCountChanged(object? sender, EventArgs e)
	{
		HasUnReadMessages = _chatUnreadService.HasUnread;
		UnReadMessageCount = _chatUnreadService.TotalUnreadCount;
	}

	public void Dispose()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		CurrentPage = null;
		_playerInfoModel.Dispose();
		_chatUnreadService.UnreadCountChanged -= new EventHandler(OnUnreadCountChanged);
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnCurrentPageChanged(ContentView? oldValue, ContentView? newValue)
	{
		if (oldValue != newValue && ((oldValue != null) ? ((BindableObject)oldValue).BindingContext : null) is IPageLifecycleAware pageLifecycleAware)
		{
			pageLifecycleAware.OnPageDisappearing();
		}
		if (((newValue != null) ? ((BindableObject)newValue).BindingContext : null) is IPageLifecycleAware pageLifecycleAware2)
		{
			pageLifecycleAware2.OnPageAppearing();
		}
	}
}
