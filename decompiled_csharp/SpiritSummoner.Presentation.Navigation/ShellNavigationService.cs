using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using SpiritSummoner.Application.State;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.Battles;
using SpiritSummoner.Presentation.ViewModels.Chat;
using SpiritSummoner.Presentation.ViewModels.Collections;
using SpiritSummoner.Presentation.ViewModels.Guilds;
using SpiritSummoner.Presentation.ViewModels.Onboarding;
using SpiritSummoner.Presentation.ViewModels.Popups;
using SpiritSummoner.Presentation.ViewModels.Pouch;
using SpiritSummoner.Presentation.ViewModels.Quests;
using SpiritSummoner.Presentation.ViewModels.Spirits;
using SpiritSummoner.Presentation.Views;
using SpiritSummoner.Presentation.Views.Battle;
using SpiritSummoner.Presentation.Views.Chats;
using SpiritSummoner.Presentation.Views.Collection;
using SpiritSummoner.Presentation.Views.Guilds;
using SpiritSummoner.Presentation.Views.Onboarding;
using SpiritSummoner.Presentation.Views.Pouch;
using SpiritSummoner.Presentation.Views.Quests;
using SpiritSummoner.Presentation.Views.Spirits;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.Navigation;

public class ShellNavigationService : INavigationService
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public string title;

		public string message;

		internal void _003CShowAlertAsync_003Eb__0(CustomAlertPopupViewModel vm)
		{
			vm.Title = title;
			vm.Message = message;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public string title;

		public string message;

		public string yesText;

		public string noText;

		internal void _003CShowConfirmationAsync_003Eb__0(CustomConfirmationPopupViewModel vm)
		{
			vm.Title = title;
			vm.Message = message;
			vm.YesButtonText = yesText;
			vm.NoButtonText = noText;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetFullSheet_003Ed__14<TView, TViewModel> : IAsyncStateMachine where TView : notnull, BottomSheet where TViewModel : class
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<BottomSheet> _003C_003Et__builder;

		public string cacheKey;

		public ShellNavigationService _003C_003E4__this;

		private string _003CslotIndex_003E5__1;

		private TViewModel _003Cvm_003E5__2;

		private BottomSheet _003Csheet_003E5__3;

		private ILoadableViewModel _003CiVM_003E5__4;

		private ILoadableViewModel _003CfullsheetVm_003E5__5;

		private Tuple<BottomSheet, string> _003CparameterTuple_003E5__6;

		private TaskAwaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0203: Unknown result type (might be due to invalid IL or missing references)
			//IL_0208: Unknown result type (might be due to invalid IL or missing references)
			//IL_0210: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_027e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0283: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0298: Unknown result type (might be due to invalid IL or missing references)
			//IL_029a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			BottomSheet result;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					TaskAwaiter awaiter2;
					if (num != 1)
					{
						_003CslotIndex_003E5__1 = string.Empty;
						if (cacheKey.Contains('/'))
						{
							_003CslotIndex_003E5__1 = Enumerable.Last<string>((global::System.Collections.Generic.IEnumerable<string>)cacheKey.Split("/", (StringSplitOptions)0));
							cacheKey = Enumerable.First<string>((global::System.Collections.Generic.IEnumerable<string>)cacheKey.Split("/", (StringSplitOptions)0));
						}
						_003Cvm_003E5__2 = _003C_003E4__this._pageCacheService.GetSheetVM<TViewModel>(cacheKey);
						if (_003Cvm_003E5__2 == null)
						{
							_003Cvm_003E5__2 = ServiceProviderServiceExtensions.GetRequiredService<TViewModel>(_003C_003E4__this._serviceProvider);
							_003C_003E4__this._pageCacheService.CacheSheetVM(cacheKey, _003Cvm_003E5__2);
						}
						_003Csheet_003E5__3 = _003C_003E4__this._pageCacheService.GetSheetPage(cacheKey);
						if (_003Csheet_003E5__3 == null)
						{
							_003Csheet_003E5__3 = (BottomSheet)(object)ServiceProviderServiceExtensions.GetRequiredService<TView>(_003C_003E4__this._serviceProvider);
							_003C_003E4__this._pageCacheService.CacheSheetPage(cacheKey, new Func<BottomSheet>((object)_003C_003E4__this._serviceProvider, (global::System.IntPtr)(nint)(delegate*<IServiceProvider, TView>)(&ServiceProviderServiceExtensions.GetRequiredService<TView>)));
						}
						if (_003Csheet_003E5__3 == null)
						{
							_003Csheet_003E5__3 = (BottomSheet)(object)ServiceProviderServiceExtensions.GetRequiredService<TView>(_003C_003E4__this._serviceProvider);
						}
						((BindableObject)_003Csheet_003E5__3).BindingContext = _003Cvm_003E5__2;
						_003CiVM_003E5__4 = _003Cvm_003E5__2 as ILoadableViewModel;
						if (_003CiVM_003E5__4 != null && string.IsNullOrEmpty(_003CslotIndex_003E5__1))
						{
							awaiter = _003CiVM_003E5__4.LoadDataAsync(_003Csheet_003E5__3).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CGetFullSheet_003Ed__14<TView, TViewModel> _003CGetFullSheet_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CGetFullSheet_003Ed__14<TView, TViewModel>>(ref awaiter, ref _003CGetFullSheet_003Ed__);
								return;
							}
							goto IL_021f;
						}
						_003CfullsheetVm_003E5__5 = _003Cvm_003E5__2 as ILoadableViewModel;
						if (_003CfullsheetVm_003E5__5 == null)
						{
							goto IL_02e4;
						}
						_003CparameterTuple_003E5__6 = Tuple.Create<BottomSheet, string>(_003Csheet_003E5__3, _003CslotIndex_003E5__1);
						awaiter2 = _003CfullsheetVm_003E5__5.LoadDataAsync(_003CparameterTuple_003E5__6).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter2;
							_003CGetFullSheet_003Ed__14<TView, TViewModel> _003CGetFullSheet_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CGetFullSheet_003Ed__14<TView, TViewModel>>(ref awaiter2, ref _003CGetFullSheet_003Ed__);
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
					_003CparameterTuple_003E5__6 = null;
					goto IL_02e4;
				}
				awaiter = _003C_003Eu__1;
				_003C_003Eu__1 = default(TaskAwaiter);
				num = (_003C_003E1__state = -1);
				goto IL_021f;
				IL_021f:
				((TaskAwaiter)(ref awaiter)).GetResult();
				goto IL_02eb;
				IL_02eb:
				result = _003Csheet_003E5__3;
				goto end_IL_0007;
				IL_02e4:
				_003CfullsheetVm_003E5__5 = null;
				goto IL_02eb;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CslotIndex_003E5__1 = null;
				_003Cvm_003E5__2 = null;
				_003Csheet_003E5__3 = null;
				_003CiVM_003E5__4 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CslotIndex_003E5__1 = null;
			_003Cvm_003E5__2 = null;
			_003Csheet_003E5__3 = null;
			_003CiVM_003E5__4 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetSheetVM_003Ed__15<TViewModel> : IAsyncStateMachine where TViewModel : class
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<TViewModel> _003C_003Et__builder;

		public string cacheKey;

		public ShellNavigationService _003C_003E4__this;

		private TViewModel _003Cvm_003E5__1;

		private ILoadableViewModel _003CiVM_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			TViewModel result;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003Cvm_003E5__1 = _003C_003E4__this._pageCacheService.GetSheetVM<TViewModel>(cacheKey);
					if (_003Cvm_003E5__1 == null)
					{
						_003Cvm_003E5__1 = ServiceProviderServiceExtensions.GetRequiredService<TViewModel>(_003C_003E4__this._serviceProvider);
						_003C_003E4__this._pageCacheService.CacheSheetVM(cacheKey, _003Cvm_003E5__1);
					}
					_003CiVM_003E5__2 = _003Cvm_003E5__1 as ILoadableViewModel;
					if (_003CiVM_003E5__2 == null)
					{
						goto IL_0104;
					}
					awaiter = _003CiVM_003E5__2.LoadDataAsync(null).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGetSheetVM_003Ed__15<TViewModel> _003CGetSheetVM_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CGetSheetVM_003Ed__15<TViewModel>>(ref awaiter, ref _003CGetSheetVM_003Ed__);
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
				goto IL_0104;
				IL_0104:
				result = _003Cvm_003E5__1;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cvm_003E5__1 = null;
				_003CiVM_003E5__2 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cvm_003E5__1 = null;
			_003CiVM_003E5__2 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGoBackAsync_003Ed__17 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ShellNavigationService _003C_003E4__this;

		private string _003CcurrentRoute_003E5__1;

		private string[] _003Csegments_003E5__2;

		private string _003CnewRoute_003E5__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
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
						_003CcurrentRoute_003E5__1 = _003C_003E4__this._userSession.CurrentRoute;
						_003Csegments_003E5__2 = _003CcurrentRoute_003E5__1.TrimStart('/').Split('/', (StringSplitOptions)0);
						if (_003Csegments_003E5__2.Length > 2)
						{
							((NavigableElement)Shell.Current).Navigation.RemovePage(Shell.Current.CurrentPage);
							goto IL_00ea;
						}
						awaiter = Shell.Current.GoToAsync(ShellNavigationState.op_Implicit(".."), true).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGoBackAsync_003Ed__17 _003CGoBackAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoBackAsync_003Ed__17>(ref awaiter, ref _003CGoBackAsync_003Ed__);
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
					goto IL_00ea;
					IL_00ea:
					_003CnewRoute_003E5__3 = "//" + string.Join("/", Enumerable.Take<string>((global::System.Collections.Generic.IEnumerable<string>)_003Csegments_003E5__2, _003Csegments_003E5__2.Length - 1));
					_003C_003E4__this._userSession.UpdateCurrentRoute(_003CnewRoute_003E5__3 ?? "");
					_003CcurrentRoute_003E5__1 = null;
					_003Csegments_003E5__2 = null;
					_003CnewRoute_003E5__3 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					Console.WriteLine(_003Cex_003E5__4.Message);
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
	private sealed class _003CGoBackModalAsync_003Ed__18 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ShellNavigationService _003C_003E4__this;

		private TaskAwaiter<Page> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<Page> awaiter;
				if (num != 0)
				{
					awaiter = ((NavigableElement)Shell.Current).Navigation.PopModalAsync().GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGoBackModalAsync_003Ed__18 _003CGoBackModalAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Page>, _003CGoBackModalAsync_003Ed__18>(ref awaiter, ref _003CGoBackModalAsync_003Ed__);
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
	private sealed class _003CNavigateToAsync_003Ed__10 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string route;

		public ShellNavigationService _003C_003E4__this;

		private string _003CnormalizedRoute_003E5__1;

		private string[] _003Csegments_003E5__2;

		private string _003ClastSegment_003E5__3;

		private string _003CfirstSegment_003E5__4;

		private string _003CiD_003E5__5;

		private LoginPage _003Cpage_003E5__6;

		private ILoadableViewModel _003Cvm_003E5__7;

		private WelcomePage _003Cpage_003E5__8;

		private ILoadableViewModel _003Cvm_003E5__9;

		private ContentPage _003CdeepPage_003E5__10;

		private string _003CcacheKey_003E5__11;

		private string _003Cquery_003E5__12;

		private string _003Cquery_003E5__13;

		private string _003Cquery_003E5__14;

		private string[] _003CcaseFindings_003E5__15;

		private string _003Cid_003E5__16;

		private string _003C_003Es__17;

		private string[] _003CcaseFindings_003E5__18;

		private string _003C_003Es__19;

		private string _003C_003Es__20;

		private global::System.Exception _003Cex_003E5__21;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_1750: Unknown result type (might be due to invalid IL or missing references)
			//IL_0224: Unknown result type (might be due to invalid IL or missing references)
			//IL_0229: Unknown result type (might be due to invalid IL or missing references)
			//IL_0231: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_0366: Unknown result type (might be due to invalid IL or missing references)
			//IL_036b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0373: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0407: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_0546: Unknown result type (might be due to invalid IL or missing references)
			//IL_054b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0553: Unknown result type (might be due to invalid IL or missing references)
			//IL_05cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_05d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_05d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_06e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0824: Unknown result type (might be due to invalid IL or missing references)
			//IL_0829: Unknown result type (might be due to invalid IL or missing references)
			//IL_0831: Unknown result type (might be due to invalid IL or missing references)
			//IL_0960: Unknown result type (might be due to invalid IL or missing references)
			//IL_0965: Unknown result type (might be due to invalid IL or missing references)
			//IL_096d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a70: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a75: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a7d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b7e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b83: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b8b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cb7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cbc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cc4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d55: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d5a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d62: Unknown result type (might be due to invalid IL or missing references)
			//IL_0df3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0df8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e00: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e91: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e96: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e9e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f2f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f34: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f3c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0fcd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0fd2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0fda: Unknown result type (might be due to invalid IL or missing references)
			//IL_10c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_10cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_10d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_119a: Unknown result type (might be due to invalid IL or missing references)
			//IL_119f: Unknown result type (might be due to invalid IL or missing references)
			//IL_11a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_1279: Unknown result type (might be due to invalid IL or missing references)
			//IL_127e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1286: Unknown result type (might be due to invalid IL or missing references)
			//IL_1363: Unknown result type (might be due to invalid IL or missing references)
			//IL_1368: Unknown result type (might be due to invalid IL or missing references)
			//IL_1370: Unknown result type (might be due to invalid IL or missing references)
			//IL_13ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_13f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_13fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_14ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_14f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_14f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_1581: Unknown result type (might be due to invalid IL or missing references)
			//IL_1586: Unknown result type (might be due to invalid IL or missing references)
			//IL_158e: Unknown result type (might be due to invalid IL or missing references)
			//IL_160c: Unknown result type (might be due to invalid IL or missing references)
			//IL_1611: Unknown result type (might be due to invalid IL or missing references)
			//IL_1619: Unknown result type (might be due to invalid IL or missing references)
			//IL_1697: Unknown result type (might be due to invalid IL or missing references)
			//IL_169c: Unknown result type (might be due to invalid IL or missing references)
			//IL_16a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_050c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0511: Unknown result type (might be due to invalid IL or missing references)
			//IL_03da: Unknown result type (might be due to invalid IL or missing references)
			//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0526: Unknown result type (might be due to invalid IL or missing references)
			//IL_0528: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_0283: Unknown result type (might be due to invalid IL or missing references)
			//IL_0288: Unknown result type (might be due to invalid IL or missing references)
			//IL_0204: Unknown result type (might be due to invalid IL or missing references)
			//IL_0206: Unknown result type (might be due to invalid IL or missing references)
			//IL_032c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0331: Unknown result type (might be due to invalid IL or missing references)
			//IL_029d: Unknown result type (might be due to invalid IL or missing references)
			//IL_029f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0592: Unknown result type (might be due to invalid IL or missing references)
			//IL_0597: Unknown result type (might be due to invalid IL or missing references)
			//IL_0478: Unknown result type (might be due to invalid IL or missing references)
			//IL_047d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0346: Unknown result type (might be due to invalid IL or missing references)
			//IL_0348: Unknown result type (might be due to invalid IL or missing references)
			//IL_06af: Unknown result type (might be due to invalid IL or missing references)
			//IL_06b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_0492: Unknown result type (might be due to invalid IL or missing references)
			//IL_0494: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a35: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a3a: Unknown result type (might be due to invalid IL or missing references)
			//IL_06c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_06cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a50: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a52: Unknown result type (might be due to invalid IL or missing references)
			//IL_07ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_07ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_0925: Unknown result type (might be due to invalid IL or missing references)
			//IL_092a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0804: Unknown result type (might be due to invalid IL or missing references)
			//IL_0806: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b43: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b48: Unknown result type (might be due to invalid IL or missing references)
			//IL_0940: Unknown result type (might be due to invalid IL or missing references)
			//IL_0942: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c7c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c81: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b5e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b60: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c97: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c99: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d1a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d1f: Unknown result type (might be due to invalid IL or missing references)
			//IL_108b: Unknown result type (might be due to invalid IL or missing references)
			//IL_1090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d35: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d37: Unknown result type (might be due to invalid IL or missing references)
			//IL_0db8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0dbd: Unknown result type (might be due to invalid IL or missing references)
			//IL_1328: Unknown result type (might be due to invalid IL or missing references)
			//IL_132d: Unknown result type (might be due to invalid IL or missing references)
			//IL_115f: Unknown result type (might be due to invalid IL or missing references)
			//IL_1164: Unknown result type (might be due to invalid IL or missing references)
			//IL_10a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_10a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0dd3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0dd5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e56: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e5b: Unknown result type (might be due to invalid IL or missing references)
			//IL_14b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_14b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_1343: Unknown result type (might be due to invalid IL or missing references)
			//IL_1345: Unknown result type (might be due to invalid IL or missing references)
			//IL_13b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_13b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_123e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1243: Unknown result type (might be due to invalid IL or missing references)
			//IL_117a: Unknown result type (might be due to invalid IL or missing references)
			//IL_117c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e71: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e73: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ef4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ef9: Unknown result type (might be due to invalid IL or missing references)
			//IL_14cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_14ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_1546: Unknown result type (might be due to invalid IL or missing references)
			//IL_154b: Unknown result type (might be due to invalid IL or missing references)
			//IL_15d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_15d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_13ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_13d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_1259: Unknown result type (might be due to invalid IL or missing references)
			//IL_125b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f0f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f11: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f92: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f97: Unknown result type (might be due to invalid IL or missing references)
			//IL_1561: Unknown result type (might be due to invalid IL or missing references)
			//IL_1563: Unknown result type (might be due to invalid IL or missing references)
			//IL_15ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_15ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_165c: Unknown result type (might be due to invalid IL or missing references)
			//IL_1661: Unknown result type (might be due to invalid IL or missing references)
			//IL_0fad: Unknown result type (might be due to invalid IL or missing references)
			//IL_0faf: Unknown result type (might be due to invalid IL or missing references)
			//IL_1677: Unknown result type (might be due to invalid IL or missing references)
			//IL_1679: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 26u || !_003C_003E4__this._freezeNavigation)
				{
					try
					{
						TaskAwaiter awaiter27;
						TaskAwaiter awaiter26;
						TaskAwaiter awaiter25;
						TaskAwaiter awaiter23;
						TaskAwaiter awaiter21;
						TaskAwaiter awaiter20;
						TaskAwaiter awaiter19;
						TaskAwaiter awaiter18;
						TaskAwaiter awaiter17;
						TaskAwaiter awaiter16;
						TaskAwaiter awaiter10;
						TaskAwaiter awaiter11;
						TaskAwaiter awaiter12;
						TaskAwaiter awaiter13;
						TaskAwaiter awaiter14;
						TaskAwaiter awaiter15;
						TaskAwaiter awaiter9;
						TaskAwaiter awaiter8;
						TaskAwaiter awaiter7;
						TaskAwaiter awaiter5;
						TaskAwaiter awaiter6;
						TaskAwaiter awaiter;
						TaskAwaiter awaiter2;
						TaskAwaiter awaiter3;
						TaskAwaiter awaiter4;
						TaskAwaiter awaiter24;
						TaskAwaiter awaiter22;
						object bindingContext;
						switch (num)
						{
						default:
						{
							_003CnormalizedRoute_003E5__1 = (route.StartsWith("//") ? route : ("//" + route));
							_003Csegments_003E5__2 = _003CnormalizedRoute_003E5__1.TrimStart('/').Split('/', (StringSplitOptions)0);
							_003ClastSegment_003E5__3 = Enumerable.Last<string>((global::System.Collections.Generic.IEnumerable<string>)_003Csegments_003E5__2);
							_003CfirstSegment_003E5__4 = Enumerable.First<string>((global::System.Collections.Generic.IEnumerable<string>)_003Csegments_003E5__2).TrimStart('/');
							_003CiD_003E5__5 = string.Empty;
							if (_003Csegments_003E5__2.Length == 1)
							{
								if (_003ClastSegment_003E5__3.StartsWith("collection"))
								{
									awaiter27 = _003C_003E4__this.NavigateToDeepPageAsync<FullCollectionNew, CollectionHubViewModel>(_003CnormalizedRoute_003E5__1, "//collection", string.Empty).GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter27)).IsCompleted)
									{
										num = (_003C_003E1__state = 0);
										_003C_003Eu__1 = awaiter27;
										_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter27, ref _003CNavigateToAsync_003Ed__);
										return;
									}
									goto IL_0240;
								}
								if (_003ClastSegment_003E5__3.StartsWith("chat"))
								{
									awaiter26 = _003C_003E4__this.NavigateToDeepPageAsync<ChatView, ChatViewModel>(_003CnormalizedRoute_003E5__1, "//chat", string.Empty).GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter26)).IsCompleted)
									{
										num = (_003C_003E1__state = 1);
										_003C_003Eu__1 = awaiter26;
										_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter26, ref _003CNavigateToAsync_003Ed__);
										return;
									}
									goto IL_02d9;
								}
								if (route == "//login")
								{
									_003Cpage_003E5__6 = ServiceProviderServiceExtensions.GetRequiredService<LoginPage>(_003C_003E4__this._serviceProvider);
									awaiter25 = ((NavigableElement)Shell.Current).Navigation.PushAsync((Page)(object)_003Cpage_003E5__6).GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter25)).IsCompleted)
									{
										num = (_003C_003E1__state = 2);
										_003C_003Eu__1 = awaiter25;
										_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter25, ref _003CNavigateToAsync_003Ed__);
										return;
									}
									goto IL_0382;
								}
								if (route == "//welcome")
								{
									_003Cpage_003E5__8 = ServiceProviderServiceExtensions.GetRequiredService<WelcomePage>(_003C_003E4__this._serviceProvider);
									awaiter23 = ((NavigableElement)Shell.Current).Navigation.PushAsync((Page)(object)_003Cpage_003E5__8).GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter23)).IsCompleted)
									{
										num = (_003C_003E1__state = 4);
										_003C_003Eu__1 = awaiter23;
										_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter23, ref _003CNavigateToAsync_003Ed__);
										return;
									}
									goto IL_04ce;
								}
								awaiter21 = Shell.Current.GoToAsync(ShellNavigationState.op_Implicit(_003CnormalizedRoute_003E5__1)).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter21)).IsCompleted)
								{
									num = (_003C_003E1__state = 6);
									_003C_003Eu__1 = awaiter21;
									_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter21, ref _003CNavigateToAsync_003Ed__);
									return;
								}
								goto IL_05e8;
							}
							_003CdeepPage_003E5__10 = null;
							_003CcacheKey_003E5__11 = null;
							if (_003ClastSegment_003E5__3.StartsWith("spiritdetails"))
							{
								_003Cquery_003E5__12 = (route.Contains('?') ? route.Split('?', (StringSplitOptions)0)[1] : null);
								string text = _003Cquery_003E5__12;
								_003CiD_003E5__5 = ((text != null) ? text.Split('=', (StringSplitOptions)0)[1] : null);
								_003CcacheKey_003E5__11 = "spiritID=" + _003CiD_003E5__5;
								awaiter20 = _003C_003E4__this.NavigateToDeepPageAsync<SpiritDetailsView, SpiritDetailsViewModel>(_003CnormalizedRoute_003E5__1, _003CcacheKey_003E5__11, _003CiD_003E5__5).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter20)).IsCompleted)
								{
									num = (_003C_003E1__state = 7);
									_003C_003Eu__1 = awaiter20;
									_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter20, ref _003CNavigateToAsync_003Ed__);
									return;
								}
								goto IL_0705;
							}
							if (_003ClastSegment_003E5__3.StartsWith("evolverequirements"))
							{
								_003Cquery_003E5__13 = (route.Contains('?') ? route.Split('?', (StringSplitOptions)0)[1] : null);
								string text2 = _003Cquery_003E5__13;
								_003CiD_003E5__5 = ((text2 != null) ? text2.Split('=', (StringSplitOptions)0)[1] : null) ?? string.Empty;
								if (Enumerable.Count<string>((global::System.Collections.Generic.IEnumerable<string>)_003CiD_003E5__5.Split('/', (StringSplitOptions)0)) > 0)
								{
									_003CiD_003E5__5 = Enumerable.First<string>((global::System.Collections.Generic.IEnumerable<string>)_003CiD_003E5__5.Split('/', (StringSplitOptions)0));
								}
								_003CcacheKey_003E5__11 = "//evolverequirements/" + _003CiD_003E5__5;
								awaiter19 = _003C_003E4__this.NavigateToDeepPageAsync<EvolveRequirementsPage, EvolveRequirementsViewModel>(_003CnormalizedRoute_003E5__1, _003CcacheKey_003E5__11, _003CiD_003E5__5).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter19)).IsCompleted)
								{
									num = (_003C_003E1__state = 8);
									_003C_003Eu__1 = awaiter19;
									_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter19, ref _003CNavigateToAsync_003Ed__);
									return;
								}
								goto IL_0840;
							}
							if (_003ClastSegment_003E5__3.StartsWith("evolve"))
							{
								_003Cquery_003E5__14 = (route.Contains('?') ? route.Split('?', (StringSplitOptions)0)[1] : null);
								string text3 = _003Cquery_003E5__14;
								_003CiD_003E5__5 = ((text3 != null) ? text3.Split('=', (StringSplitOptions)0)[1] : null) ?? string.Empty;
								if (Enumerable.Count<string>((global::System.Collections.Generic.IEnumerable<string>)_003CiD_003E5__5.Split('/', (StringSplitOptions)0)) > 0)
								{
									_003CiD_003E5__5 = Enumerable.First<string>((global::System.Collections.Generic.IEnumerable<string>)_003CiD_003E5__5.Split('/', (StringSplitOptions)0));
								}
								_003CcacheKey_003E5__11 = "//evolve/" + _003CiD_003E5__5;
								awaiter18 = _003C_003E4__this.NavigateToDeepPageAsync<EvolveView, EvolveViewModel>(_003CnormalizedRoute_003E5__1, _003CcacheKey_003E5__11, _003CiD_003E5__5).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter18)).IsCompleted)
								{
									num = (_003C_003E1__state = 9);
									_003C_003Eu__1 = awaiter18;
									_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter18, ref _003CNavigateToAsync_003Ed__);
									return;
								}
								goto IL_097c;
							}
							if (_003CfirstSegment_003E5__4.StartsWith("questtasks") && !_003ClastSegment_003E5__3.StartsWith("paragraph") && !_003ClastSegment_003E5__3.StartsWith("collection") && !_003ClastSegment_003E5__3.StartsWith("pouch"))
							{
								_003CiD_003E5__5 = _003Csegments_003E5__2[1] + "/" + _003Csegments_003E5__2[2];
								_003CcacheKey_003E5__11 = "//questtasks";
								awaiter17 = _003C_003E4__this.NavigateToDeepPageAsync<QuestTaskView, QuestTaskViewModel>(_003CnormalizedRoute_003E5__1, _003CcacheKey_003E5__11, _003CiD_003E5__5).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter17)).IsCompleted)
								{
									num = (_003C_003E1__state = 10);
									_003C_003Eu__1 = awaiter17;
									_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter17, ref _003CNavigateToAsync_003Ed__);
									return;
								}
								goto IL_0a8c;
							}
							string text5;
							if (_003CfirstSegment_003E5__4.StartsWith("guild") && !_003ClastSegment_003E5__3.StartsWith("collection") && !_003ClastSegment_003E5__3.StartsWith("pouch"))
							{
								if (_003Csegments_003E5__2.Length == 3)
								{
									_003CcacheKey_003E5__11 = "//guildwars";
									_003Cid_003E5__16 = Enumerable.Last<string>((global::System.Collections.Generic.IEnumerable<string>)Enumerable.Last<string>((global::System.Collections.Generic.IEnumerable<string>)_003Csegments_003E5__2[1].Split('?', (StringSplitOptions)0)).Split('=', (StringSplitOptions)0));
									awaiter16 = _003C_003E4__this.NavigateToDeepPageAsync<GuildWarBattleListPage, GuildWarsViewModel>(_003CnormalizedRoute_003E5__1, _003CcacheKey_003E5__11, _003Cid_003E5__16).GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter16)).IsCompleted)
									{
										num = (_003C_003E1__state = 11);
										_003C_003Eu__1 = awaiter16;
										_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter16, ref _003CNavigateToAsync_003Ed__);
										return;
									}
									goto IL_0b9a;
								}
								_003CcaseFindings_003E5__15 = _003Csegments_003E5__2[1].Split('?', (StringSplitOptions)0);
								string text4 = Enumerable.First<string>((global::System.Collections.Generic.IEnumerable<string>)_003CcaseFindings_003E5__15);
								_003C_003Es__17 = text4;
								text5 = _003C_003Es__17;
								if (!(text5 == "members"))
								{
									if (!(text5 == "wars"))
									{
										if (!(text5 == "defenderManagement"))
										{
											if (!(text5 == "warHistory"))
											{
												if (!(text5 == "warBattleList"))
												{
													if (!(text5 == "shop"))
													{
														goto IL_0ff3;
													}
													_003CcacheKey_003E5__11 = "//guildshop";
													awaiter10 = _003C_003E4__this.NavigateToDeepPageAsync<GuildShopPage, GuildShopViewModel>(_003CnormalizedRoute_003E5__1, _003CcacheKey_003E5__11, Enumerable.Last<string>((global::System.Collections.Generic.IEnumerable<string>)Enumerable.Last<string>((global::System.Collections.Generic.IEnumerable<string>)_003CcaseFindings_003E5__15).Split('=', (StringSplitOptions)0))).GetAwaiter();
													if (!((TaskAwaiter)(ref awaiter10)).IsCompleted)
													{
														num = (_003C_003E1__state = 17);
														_003C_003Eu__1 = awaiter10;
														_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
														((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter10, ref _003CNavigateToAsync_003Ed__);
														return;
													}
													goto IL_0fe9;
												}
												_003CcacheKey_003E5__11 = "//guildwarbattlelist";
												awaiter11 = _003C_003E4__this.NavigateToDeepPageAsync<GuildWarBattleListPage, GuildWarsViewModel>(_003CnormalizedRoute_003E5__1, _003CcacheKey_003E5__11, Enumerable.Last<string>((global::System.Collections.Generic.IEnumerable<string>)Enumerable.Last<string>((global::System.Collections.Generic.IEnumerable<string>)_003CcaseFindings_003E5__15).Split('=', (StringSplitOptions)0))).GetAwaiter();
												if (!((TaskAwaiter)(ref awaiter11)).IsCompleted)
												{
													num = (_003C_003E1__state = 16);
													_003C_003Eu__1 = awaiter11;
													_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
													((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter11, ref _003CNavigateToAsync_003Ed__);
													return;
												}
												goto IL_0f4b;
											}
											_003CcacheKey_003E5__11 = "//guildwarhistory";
											awaiter12 = _003C_003E4__this.NavigateToDeepPageAsync<GuildWarHistoryPage, GuildWarHistoryViewModel>(_003CnormalizedRoute_003E5__1, _003CcacheKey_003E5__11, Enumerable.Last<string>((global::System.Collections.Generic.IEnumerable<string>)Enumerable.Last<string>((global::System.Collections.Generic.IEnumerable<string>)_003CcaseFindings_003E5__15).Split('=', (StringSplitOptions)0))).GetAwaiter();
											if (!((TaskAwaiter)(ref awaiter12)).IsCompleted)
											{
												num = (_003C_003E1__state = 15);
												_003C_003Eu__1 = awaiter12;
												_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
												((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter12, ref _003CNavigateToAsync_003Ed__);
												return;
											}
											goto IL_0ead;
										}
										_003CcacheKey_003E5__11 = "//guilddefendermanagement";
										awaiter13 = _003C_003E4__this.NavigateToDeepPageAsync<GuildDefenderManagementPage, GuildDefenderManagementViewModel>(_003CnormalizedRoute_003E5__1, _003CcacheKey_003E5__11, Enumerable.Last<string>((global::System.Collections.Generic.IEnumerable<string>)Enumerable.Last<string>((global::System.Collections.Generic.IEnumerable<string>)_003CcaseFindings_003E5__15).Split('=', (StringSplitOptions)0))).GetAwaiter();
										if (!((TaskAwaiter)(ref awaiter13)).IsCompleted)
										{
											num = (_003C_003E1__state = 14);
											_003C_003Eu__1 = awaiter13;
											_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
											((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter13, ref _003CNavigateToAsync_003Ed__);
											return;
										}
										goto IL_0e0f;
									}
									_003CcacheKey_003E5__11 = "//guildwars";
									awaiter14 = _003C_003E4__this.NavigateToDeepPageAsync<GuildWarsPage, GuildWarsViewModel>(_003CnormalizedRoute_003E5__1, _003CcacheKey_003E5__11, Enumerable.Last<string>((global::System.Collections.Generic.IEnumerable<string>)Enumerable.Last<string>((global::System.Collections.Generic.IEnumerable<string>)_003CcaseFindings_003E5__15).Split('=', (StringSplitOptions)0))).GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter14)).IsCompleted)
									{
										num = (_003C_003E1__state = 13);
										_003C_003Eu__1 = awaiter14;
										_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter14, ref _003CNavigateToAsync_003Ed__);
										return;
									}
									goto IL_0d71;
								}
								_003CcacheKey_003E5__11 = "//guildmembers";
								awaiter15 = _003C_003E4__this.NavigateToDeepPageAsync<GuildMembersPage, GuildMembersViewModel>(_003CnormalizedRoute_003E5__1, _003CcacheKey_003E5__11, Enumerable.Last<string>((global::System.Collections.Generic.IEnumerable<string>)Enumerable.Last<string>((global::System.Collections.Generic.IEnumerable<string>)_003CcaseFindings_003E5__15).Split('=', (StringSplitOptions)0))).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter15)).IsCompleted)
								{
									num = (_003C_003E1__state = 12);
									_003C_003Eu__1 = awaiter15;
									_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter15, ref _003CNavigateToAsync_003Ed__);
									return;
								}
								goto IL_0cd3;
							}
							if (_003CfirstSegment_003E5__4.StartsWith("chat") && !_003ClastSegment_003E5__3.StartsWith("collection"))
							{
								_003CcaseFindings_003E5__18 = _003Csegments_003E5__2[1].Split('?', (StringSplitOptions)0);
								if (_003CcaseFindings_003E5__18.Length < 2)
								{
									_003CcacheKey_003E5__11 = "//chat";
									awaiter9 = _003C_003E4__this.NavigateToDeepPageAsync<ChatView, ChatViewModel>(_003CnormalizedRoute_003E5__1, _003CcacheKey_003E5__11, string.Empty).GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter9)).IsCompleted)
									{
										num = (_003C_003E1__state = 18);
										_003C_003Eu__1 = awaiter9;
										_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter9, ref _003CNavigateToAsync_003Ed__);
										return;
									}
									goto IL_10e2;
								}
								if (Enumerable.First<string>((global::System.Collections.Generic.IEnumerable<string>)_003CcaseFindings_003E5__18) == "dm")
								{
									_003CiD_003E5__5 = Enumerable.Last<string>((global::System.Collections.Generic.IEnumerable<string>)Enumerable.Last<string>((global::System.Collections.Generic.IEnumerable<string>)_003CcaseFindings_003E5__18).Split('=', (StringSplitOptions)0));
									_003CcacheKey_003E5__11 = "//chat/dm/" + _003CiD_003E5__5;
									awaiter8 = _003C_003E4__this.NavigateToDeepPageAsync<DirectMessageView, DirectMessageViewModel>(_003CnormalizedRoute_003E5__1, _003CcacheKey_003E5__11, _003CiD_003E5__5).GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter8)).IsCompleted)
									{
										num = (_003C_003E1__state = 19);
										_003C_003Eu__1 = awaiter8;
										_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter8, ref _003CNavigateToAsync_003Ed__);
										return;
									}
									goto IL_11b6;
								}
								if (Enumerable.First<string>((global::System.Collections.Generic.IEnumerable<string>)_003CcaseFindings_003E5__18) == "guildthread")
								{
									_003CiD_003E5__5 = Enumerable.Last<string>((global::System.Collections.Generic.IEnumerable<string>)Enumerable.Last<string>((global::System.Collections.Generic.IEnumerable<string>)_003CcaseFindings_003E5__18).Split('=', (StringSplitOptions)0));
									_003CcacheKey_003E5__11 = "//chat/guildthread/" + _003CiD_003E5__5.Split('|', (StringSplitOptions)0)[0];
									awaiter7 = _003C_003E4__this.NavigateToDeepPageAsync<GuildChatThreadView, GuildChatThreadViewModel>(_003CnormalizedRoute_003E5__1, _003CcacheKey_003E5__11, _003CiD_003E5__5).GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter7)).IsCompleted)
									{
										num = (_003C_003E1__state = 20);
										_003C_003Eu__1 = awaiter7;
										_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter7, ref _003CNavigateToAsync_003Ed__);
										return;
									}
									goto IL_1295;
								}
								goto IL_129e;
							}
							if (_003CfirstSegment_003E5__4.StartsWith("onboarding"))
							{
								string text6 = _003ClastSegment_003E5__3;
								_003C_003Es__19 = text6;
								text5 = _003C_003Es__19;
								if (!(text5 == "dialogue"))
								{
									if (!(text5 == "spirits"))
									{
										goto IL_1414;
									}
									_003CcacheKey_003E5__11 = "//onboarding/spirits";
									awaiter5 = _003C_003E4__this.NavigateToDeepPageAsync<OnboardingSpiritsRewardPage, OnboardingViewModel>(_003CnormalizedRoute_003E5__1, _003CcacheKey_003E5__11, string.Empty).GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
									{
										num = (_003C_003E1__state = 22);
										_003C_003Eu__1 = awaiter5;
										_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter5, ref _003CNavigateToAsync_003Ed__);
										return;
									}
									goto IL_140a;
								}
								_003CcacheKey_003E5__11 = "//onboarding/dialogue";
								awaiter6 = _003C_003E4__this.NavigateToDeepPageAsync<OnboardingDialoguePage, OnboardingViewModel>(_003CnormalizedRoute_003E5__1, _003CcacheKey_003E5__11, string.Empty).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter6)).IsCompleted)
								{
									num = (_003C_003E1__state = 21);
									_003C_003Eu__1 = awaiter6;
									_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter6, ref _003CNavigateToAsync_003Ed__);
									return;
								}
								goto IL_137f;
							}
							string text7 = _003ClastSegment_003E5__3;
							_003C_003Es__20 = text7;
							text5 = _003C_003Es__20;
							if (!(text5 == "battlelist"))
							{
								if (!(text5 == "pouch"))
								{
									if (!(text5 == "paragraph"))
									{
										if (!(text5 == "collection"))
										{
											goto IL_16bd;
										}
										_003CcacheKey_003E5__11 = "//collection";
										awaiter = _003C_003E4__this.NavigateToDeepPageAsync<FullCollectionNew, CollectionHubViewModel>(_003CnormalizedRoute_003E5__1, _003CcacheKey_003E5__11, string.Empty).GetAwaiter();
										if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
										{
											num = (_003C_003E1__state = 26);
											_003C_003Eu__1 = awaiter;
											_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
											((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter, ref _003CNavigateToAsync_003Ed__);
											return;
										}
										goto IL_16b3;
									}
									_003CcacheKey_003E5__11 = "//paragraph";
									awaiter2 = _003C_003E4__this.NavigateToDeepPageAsync<QuestParagraphView, QuestParagraphViewModel>(_003CnormalizedRoute_003E5__1, _003CcacheKey_003E5__11, string.Empty).GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
									{
										num = (_003C_003E1__state = 25);
										_003C_003Eu__1 = awaiter2;
										_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter2, ref _003CNavigateToAsync_003Ed__);
										return;
									}
									goto IL_1628;
								}
								_003CcacheKey_003E5__11 = "//pouch";
								awaiter3 = _003C_003E4__this.NavigateToDeepPageAsync<PouchView, PouchViewModel>(_003CnormalizedRoute_003E5__1, _003CcacheKey_003E5__11, _003CiD_003E5__5 ?? string.Empty).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
								{
									num = (_003C_003E1__state = 24);
									_003C_003Eu__1 = awaiter3;
									_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter3, ref _003CNavigateToAsync_003Ed__);
									return;
								}
								goto IL_159d;
							}
							_003CcacheKey_003E5__11 = "//battlelist";
							awaiter4 = _003C_003E4__this.NavigateToDeepPageAsync<BattleListView, BattleListViewModel>(_003CnormalizedRoute_003E5__1, _003CcacheKey_003E5__11, _003CiD_003E5__5 ?? string.Empty).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
							{
								num = (_003C_003E1__state = 23);
								_003C_003Eu__1 = awaiter4;
								_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter4, ref _003CNavigateToAsync_003Ed__);
								return;
							}
							goto IL_1508;
						}
						case 0:
							awaiter27 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0240;
						case 1:
							awaiter26 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_02d9;
						case 2:
							awaiter25 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0382;
						case 3:
							awaiter24 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0416;
						case 4:
							awaiter23 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_04ce;
						case 5:
							awaiter22 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0562;
						case 6:
							awaiter21 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_05e8;
						case 7:
							awaiter20 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0705;
						case 8:
							awaiter19 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0840;
						case 9:
							awaiter18 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_097c;
						case 10:
							awaiter17 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0a8c;
						case 11:
							awaiter16 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0b9a;
						case 12:
							awaiter15 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0cd3;
						case 13:
							awaiter14 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0d71;
						case 14:
							awaiter13 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0e0f;
						case 15:
							awaiter12 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0ead;
						case 16:
							awaiter11 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0f4b;
						case 17:
							awaiter10 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0fe9;
						case 18:
							awaiter9 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_10e2;
						case 19:
							awaiter8 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_11b6;
						case 20:
							awaiter7 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_1295;
						case 21:
							awaiter6 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_137f;
						case 22:
							awaiter5 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_140a;
						case 23:
							awaiter4 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_1508;
						case 24:
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_159d;
						case 25:
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_1628;
						case 26:
							{
								awaiter = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_16b3;
							}
							IL_0f4b:
							((TaskAwaiter)(ref awaiter11)).GetResult();
							goto IL_0ff3;
							IL_0e0f:
							((TaskAwaiter)(ref awaiter13)).GetResult();
							goto IL_0ff3;
							IL_16b3:
							((TaskAwaiter)(ref awaiter)).GetResult();
							goto IL_16bd;
							IL_0ead:
							((TaskAwaiter)(ref awaiter12)).GetResult();
							goto IL_0ff3;
							IL_0705:
							((TaskAwaiter)(ref awaiter20)).GetResult();
							_003Cquery_003E5__12 = null;
							goto IL_16c5;
							IL_0cd3:
							((TaskAwaiter)(ref awaiter15)).GetResult();
							goto IL_0ff3;
							IL_0240:
							((TaskAwaiter)(ref awaiter27)).GetResult();
							goto IL_05f1;
							IL_0840:
							((TaskAwaiter)(ref awaiter19)).GetResult();
							_003Cquery_003E5__13 = null;
							goto IL_16c5;
							IL_11b6:
							((TaskAwaiter)(ref awaiter8)).GetResult();
							goto IL_129e;
							IL_1414:
							_003C_003Es__19 = null;
							goto IL_16c5;
							IL_02d9:
							((TaskAwaiter)(ref awaiter26)).GetResult();
							goto IL_05f1;
							IL_0d71:
							((TaskAwaiter)(ref awaiter14)).GetResult();
							goto IL_0ff3;
							IL_097c:
							((TaskAwaiter)(ref awaiter18)).GetResult();
							ShellNavigationService.RemovePageOfType<EvolveRequirementsPage>();
							_003Cquery_003E5__14 = null;
							goto IL_16c5;
							IL_0ff3:
							_003C_003Es__17 = null;
							_003CcaseFindings_003E5__15 = null;
							goto IL_16c5;
							IL_0382:
							((TaskAwaiter)(ref awaiter25)).GetResult();
							bindingContext = ((BindableObject)_003Cpage_003E5__6).BindingContext;
							_003Cvm_003E5__7 = bindingContext as ILoadableViewModel;
							if (_003Cvm_003E5__7 != null)
							{
								awaiter24 = _003Cvm_003E5__7.LoadDataAsync(null).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter24)).IsCompleted)
								{
									num = (_003C_003E1__state = 3);
									_003C_003Eu__1 = awaiter24;
									_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter24, ref _003CNavigateToAsync_003Ed__);
									return;
								}
								goto IL_0416;
							}
							goto IL_041f;
							IL_1628:
							((TaskAwaiter)(ref awaiter2)).GetResult();
							goto IL_16bd;
							IL_1508:
							((TaskAwaiter)(ref awaiter4)).GetResult();
							goto IL_16bd;
							IL_0416:
							((TaskAwaiter)(ref awaiter24)).GetResult();
							goto IL_041f;
							IL_041f:
							_003Cpage_003E5__6 = null;
							_003Cvm_003E5__7 = null;
							goto IL_05f1;
							IL_159d:
							((TaskAwaiter)(ref awaiter3)).GetResult();
							goto IL_16bd;
							IL_137f:
							((TaskAwaiter)(ref awaiter6)).GetResult();
							goto IL_1414;
							IL_140a:
							((TaskAwaiter)(ref awaiter5)).GetResult();
							goto IL_1414;
							IL_04ce:
							((TaskAwaiter)(ref awaiter23)).GetResult();
							bindingContext = ((BindableObject)_003Cpage_003E5__8).BindingContext;
							_003Cvm_003E5__9 = bindingContext as ILoadableViewModel;
							if (_003Cvm_003E5__9 != null)
							{
								awaiter22 = _003Cvm_003E5__9.LoadDataAsync(null).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter22)).IsCompleted)
								{
									num = (_003C_003E1__state = 5);
									_003C_003Eu__1 = awaiter22;
									_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToAsync_003Ed__10>(ref awaiter22, ref _003CNavigateToAsync_003Ed__);
									return;
								}
								goto IL_0562;
							}
							goto IL_056b;
							IL_16bd:
							_003C_003Es__20 = null;
							goto IL_16c5;
							IL_16c5:
							_003CdeepPage_003E5__10 = null;
							_003CcacheKey_003E5__11 = null;
							break;
							IL_0562:
							((TaskAwaiter)(ref awaiter22)).GetResult();
							goto IL_056b;
							IL_056b:
							_003Cpage_003E5__8 = null;
							_003Cvm_003E5__9 = null;
							goto IL_05f1;
							IL_1295:
							((TaskAwaiter)(ref awaiter7)).GetResult();
							goto IL_129e;
							IL_0fe9:
							((TaskAwaiter)(ref awaiter10)).GetResult();
							goto IL_0ff3;
							IL_05e8:
							((TaskAwaiter)(ref awaiter21)).GetResult();
							goto IL_05f1;
							IL_05f1:
							_003C_003E4__this._userSession.UpdateCurrentRoute(_003CnormalizedRoute_003E5__1);
							break;
							IL_0b9a:
							((TaskAwaiter)(ref awaiter16)).GetResult();
							goto end_IL_0026;
							IL_10e2:
							((TaskAwaiter)(ref awaiter9)).GetResult();
							goto end_IL_0026;
							IL_0a8c:
							((TaskAwaiter)(ref awaiter17)).GetResult();
							goto IL_16c5;
							IL_129e:
							_003CcaseFindings_003E5__18 = null;
							goto IL_16c5;
						}
						_003CnormalizedRoute_003E5__1 = null;
						_003Csegments_003E5__2 = null;
						_003ClastSegment_003E5__3 = null;
						_003CfirstSegment_003E5__4 = null;
						_003CiD_003E5__5 = null;
						end_IL_0026:;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__21 = ex;
						Console.WriteLine("Navigation error: " + _003Cex_003E5__21.Message);
						Console.WriteLine("Stacktrace" + _003Cex_003E5__21.StackTrace);
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this._pageCacheService.SweepIdleDeepVMs(_deepVmIdleTimeout, _003C_003E4__this._userSession.CurrentRoute);
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
	private sealed class _003CNavigateToBattleViewAsync_003Ed__19 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string route;

		public BattleLaunchRequest request;

		public ShellNavigationService _003C_003E4__this;

		private BattleViewModelRefactored _003Cvm_003E5__1;

		private BattleView _003Cpage_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
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
						goto IL_0141;
					}
					_003Cvm_003E5__1 = ServiceProviderServiceExtensions.GetRequiredService<BattleViewModelRefactored>(_003C_003E4__this._serviceProvider);
					_003Cpage_003E5__2 = ServiceProviderServiceExtensions.GetRequiredService<BattleView>(_003C_003E4__this._serviceProvider);
					((BindableObject)_003Cpage_003E5__2).BindingContext = _003Cvm_003E5__1;
					_003C_003E4__this._userSession.UpdateCurrentRoute(route);
					awaiter2 = ((NavigableElement)Shell.Current).Navigation.PushAsync((Page)(object)_003Cpage_003E5__2).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003CNavigateToBattleViewAsync_003Ed__19 _003CNavigateToBattleViewAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToBattleViewAsync_003Ed__19>(ref awaiter2, ref _003CNavigateToBattleViewAsync_003Ed__);
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
				awaiter = _003Cvm_003E5__1.LoadDataAsync(request).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CNavigateToBattleViewAsync_003Ed__19 _003CNavigateToBattleViewAsync_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToBattleViewAsync_003Ed__19>(ref awaiter, ref _003CNavigateToBattleViewAsync_003Ed__);
					return;
				}
				goto IL_0141;
				IL_0141:
				((TaskAwaiter)(ref awaiter)).GetResult();
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cvm_003E5__1 = null;
				_003Cpage_003E5__2 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cvm_003E5__1 = null;
			_003Cpage_003E5__2 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CNavigateToDeepPageAsync_003Ed__12<TView, TViewModel> : IAsyncStateMachine where TView : notnull, ContentPage where TViewModel : class, ILoadableViewModel
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string route;

		public string cacheKey;

		public object id;

		public ShellNavigationService _003C_003E4__this;

		private TViewModel _003Cvm_003E5__1;

		private TView _003Cpage_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
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
						goto IL_01a7;
					}
					_003Cvm_003E5__1 = _003C_003E4__this._pageCacheService.GetDeepVM<TViewModel>(cacheKey);
					if (_003Cvm_003E5__1 == null)
					{
						_003Cvm_003E5__1 = ServiceProviderServiceExtensions.GetRequiredService<TViewModel>(_003C_003E4__this._serviceProvider);
						if (_cacheableDeepRoutes.Contains(cacheKey))
						{
							_003C_003E4__this._pageCacheService.CacheDeepVM(cacheKey, _003Cvm_003E5__1);
						}
					}
					_003Cpage_003E5__2 = ServiceProviderServiceExtensions.GetRequiredService<TView>(_003C_003E4__this._serviceProvider);
					((BindableObject)(object)_003Cpage_003E5__2).BindingContext = _003Cvm_003E5__1;
					awaiter2 = ((NavigableElement)Shell.Current).Navigation.PushAsync((Page)(object)_003Cpage_003E5__2).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003CNavigateToDeepPageAsync_003Ed__12<TView, TViewModel> _003CNavigateToDeepPageAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToDeepPageAsync_003Ed__12<TView, TViewModel>>(ref awaiter2, ref _003CNavigateToDeepPageAsync_003Ed__);
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
				awaiter = _003Cvm_003E5__1.LoadDataAsync(id).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CNavigateToDeepPageAsync_003Ed__12<TView, TViewModel> _003CNavigateToDeepPageAsync_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToDeepPageAsync_003Ed__12<TView, TViewModel>>(ref awaiter, ref _003CNavigateToDeepPageAsync_003Ed__);
					return;
				}
				goto IL_01a7;
				IL_01a7:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003C_003E4__this._userSession.UpdateCurrentRoute(route);
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cvm_003E5__1 = null;
				_003Cpage_003E5__2 = default(TView);
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cvm_003E5__1 = null;
			_003Cpage_003E5__2 = default(TView);
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CNavigateToMainPageAsync_003Ed__11<TView, TViewModel> : IAsyncStateMachine where TView : notnull, ContentView where TViewModel : class, ILoadableViewModel
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<object> _003C_003Et__builder;

		public string route;

		public string cacheKey;

		public object id;

		public ShellNavigationService _003C_003E4__this;

		private TViewModel _003Cvm_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			object result;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003Cvm_003E5__1 = _003C_003E4__this._pageCacheService.GetMainVM<TViewModel>(cacheKey);
					if (_003Cvm_003E5__1 == null)
					{
						_003Cvm_003E5__1 = ServiceProviderServiceExtensions.GetRequiredService<TViewModel>(_003C_003E4__this._serviceProvider);
						_003C_003E4__this._pageCacheService.CacheMainVM(cacheKey, _003Cvm_003E5__1);
					}
					awaiter = _003Cvm_003E5__1.LoadDataAsync(id).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CNavigateToMainPageAsync_003Ed__11<TView, TViewModel> _003CNavigateToMainPageAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToMainPageAsync_003Ed__11<TView, TViewModel>>(ref awaiter, ref _003CNavigateToMainPageAsync_003Ed__);
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
				_003C_003E4__this._userSession.UpdateCurrentRoute(route);
				result = _003Cvm_003E5__1;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cvm_003E5__1 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cvm_003E5__1 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CNavigateToWithParametersAsync_003Ed__20 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string route;

		public IDictionary<string, object> parameters;

		public ShellNavigationService _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = Shell.Current.GoToAsync(ShellNavigationState.op_Implicit(route), parameters).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CNavigateToWithParametersAsync_003Ed__20 _003CNavigateToWithParametersAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToWithParametersAsync_003Ed__20>(ref awaiter, ref _003CNavigateToWithParametersAsync_003Ed__);
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
	private sealed class _003CShowAlertAsync_003Ed__21 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string title;

		public string message;

		public ShellNavigationService _003C_003E4__this;

		private _003C_003Ec__DisplayClass21_0 _003C_003E8__1;

		private TaskAwaiter<object?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<object> awaiter;
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass21_0();
					_003C_003E8__1.title = title;
					_003C_003E8__1.message = message;
					awaiter = _003C_003E4__this._popupService.ShowPopupAsync<CustomAlertPopupViewModel>((Action<CustomAlertPopupViewModel>)delegate(CustomAlertPopupViewModel vm)
					{
						vm.Title = _003C_003E8__1.title;
						vm.Message = _003C_003E8__1.message;
					}, default(CancellationToken)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CShowAlertAsync_003Ed__21 _003CShowAlertAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CShowAlertAsync_003Ed__21>(ref awaiter, ref _003CShowAlertAsync_003Ed__);
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
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
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
	private sealed class _003CShowConfirmationAsync_003Ed__22 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string title;

		public string message;

		public string yesText;

		public string noText;

		public ShellNavigationService _003C_003E4__this;

		private _003C_003Ec__DisplayClass22_0 _003C_003E8__1;

		private object _003Cresult_003E5__2;

		private bool _003CboolResult_003E5__3;

		private object _003C_003Es__4;

		private TaskAwaiter<object?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				TaskAwaiter<object> awaiter;
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass22_0();
					_003C_003E8__1.title = title;
					_003C_003E8__1.message = message;
					_003C_003E8__1.yesText = yesText;
					_003C_003E8__1.noText = noText;
					awaiter = _003C_003E4__this._popupService.ShowPopupAsync<CustomConfirmationPopupViewModel>((Action<CustomConfirmationPopupViewModel>)delegate(CustomConfirmationPopupViewModel vm)
					{
						vm.Title = _003C_003E8__1.title;
						vm.Message = _003C_003E8__1.message;
						vm.YesButtonText = _003C_003E8__1.yesText;
						vm.NoButtonText = _003C_003E8__1.noText;
					}, default(CancellationToken)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CShowConfirmationAsync_003Ed__22 _003CShowConfirmationAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CShowConfirmationAsync_003Ed__22>(ref awaiter, ref _003CShowConfirmationAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<object>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__4 = awaiter.GetResult();
				_003Cresult_003E5__2 = _003C_003Es__4;
				_003C_003Es__4 = null;
				int num2;
				if (_003Cresult_003E5__2 is bool)
				{
					_003CboolResult_003E5__3 = (bool)_003Cresult_003E5__2;
					num2 = 1;
				}
				else
				{
					num2 = 0;
				}
				result = (byte)((uint)num2 & (_003CboolResult_003E5__3 ? 1u : 0u)) != 0;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003Cresult_003E5__2 = null;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003Cresult_003E5__2 = null;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private static readonly HashSet<string> _cacheableDeepRoutes;

	private static readonly TimeSpan _deepVmIdleTimeout;

	private bool _freezeNavigation = false;

	private readonly IPlayerStateService _userSession;

	private readonly IPageCacheService _pageCacheService;

	private readonly IServiceProvider _serviceProvider;

	private readonly IPopupService _popupService;

	public ShellNavigationService(IPlayerStateService userSession, IPageCacheService pageCacheService, IServiceProvider serviceProvider, IPopupService popupService)
	{
		_userSession = userSession;
		_pageCacheService = pageCacheService;
		_serviceProvider = serviceProvider;
		_popupService = popupService;
	}

	public void StopNavigation()
	{
		_freezeNavigation = true;
	}

	public bool CanNavigate()
	{
		return !_freezeNavigation;
	}

	[AsyncStateMachine(typeof(_003CNavigateToAsync_003Ed__10))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task NavigateToAsync(string route)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CNavigateToAsync_003Ed__10 _003CNavigateToAsync_003Ed__ = new _003CNavigateToAsync_003Ed__10();
		_003CNavigateToAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CNavigateToAsync_003Ed__._003C_003E4__this = this;
		_003CNavigateToAsync_003Ed__.route = route;
		_003CNavigateToAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CNavigateToAsync_003Ed__._003C_003Et__builder)).Start<_003CNavigateToAsync_003Ed__10>(ref _003CNavigateToAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CNavigateToAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CNavigateToMainPageAsync_003Ed__11<, >))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<object> NavigateToMainPageAsync<TView, TViewModel>(string route, string cacheKey, object id) where TView : ContentView where TViewModel : class, ILoadableViewModel
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		TViewModel vm = _pageCacheService.GetMainVM<TViewModel>(cacheKey);
		if (vm == null)
		{
			vm = ServiceProviderServiceExtensions.GetRequiredService<TViewModel>(_serviceProvider);
			_pageCacheService.CacheMainVM(cacheKey, vm);
		}
		await vm.LoadDataAsync(id);
		_userSession.UpdateCurrentRoute(route);
		return vm;
	}

	[AsyncStateMachine(typeof(_003CNavigateToDeepPageAsync_003Ed__12<, >))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task NavigateToDeepPageAsync<TView, TViewModel>(string route, string cacheKey, object id) where TView : ContentPage where TViewModel : class, ILoadableViewModel
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CNavigateToDeepPageAsync_003Ed__12<TView, TViewModel> _003CNavigateToDeepPageAsync_003Ed__ = new _003CNavigateToDeepPageAsync_003Ed__12<TView, TViewModel>();
		_003CNavigateToDeepPageAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CNavigateToDeepPageAsync_003Ed__._003C_003E4__this = this;
		_003CNavigateToDeepPageAsync_003Ed__.route = route;
		_003CNavigateToDeepPageAsync_003Ed__.cacheKey = cacheKey;
		_003CNavigateToDeepPageAsync_003Ed__.id = id;
		_003CNavigateToDeepPageAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CNavigateToDeepPageAsync_003Ed__._003C_003Et__builder)).Start<_003CNavigateToDeepPageAsync_003Ed__12<TView, TViewModel>>(ref _003CNavigateToDeepPageAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CNavigateToDeepPageAsync_003Ed__._003C_003Et__builder)).Task;
	}

	private static void RemovePageOfType<TPage>() where TPage : Page
	{
		Shell current = Shell.Current;
		INavigation val = ((current != null) ? ((NavigableElement)current).Navigation : null);
		if (val == null)
		{
			return;
		}
		Page val2 = Enumerable.FirstOrDefault<Page>((global::System.Collections.Generic.IEnumerable<Page>)val.NavigationStack, (Func<Page, bool>)((Page p) => p is TPage));
		if (val2 != null)
		{
			Shell current2 = Shell.Current;
			if (val2 != ((current2 != null) ? current2.CurrentPage : null))
			{
				val.RemovePage(val2);
			}
		}
	}

	[AsyncStateMachine(typeof(_003CGetFullSheet_003Ed__14<, >))]
	[DebuggerStepThrough]
	public unsafe async global::System.Threading.Tasks.Task<BottomSheet> GetFullSheet<TView, TViewModel>(string cacheKey) where TView : BottomSheet where TViewModel : class
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string slotIndex = string.Empty;
		if (cacheKey.Contains('/'))
		{
			slotIndex = Enumerable.Last<string>((global::System.Collections.Generic.IEnumerable<string>)cacheKey.Split("/", (StringSplitOptions)0));
			cacheKey = Enumerable.First<string>((global::System.Collections.Generic.IEnumerable<string>)cacheKey.Split("/", (StringSplitOptions)0));
		}
		TViewModel vm = _pageCacheService.GetSheetVM<TViewModel>(cacheKey);
		if (vm == null)
		{
			vm = ServiceProviderServiceExtensions.GetRequiredService<TViewModel>(_serviceProvider);
			_pageCacheService.CacheSheetVM(cacheKey, vm);
		}
		BottomSheet sheet = _pageCacheService.GetSheetPage(cacheKey);
		if (sheet == null)
		{
			sheet = (BottomSheet)(object)ServiceProviderServiceExtensions.GetRequiredService<TView>(_serviceProvider);
			_pageCacheService.CacheSheetPage(cacheKey, new Func<BottomSheet>((object)_serviceProvider, (global::System.IntPtr)(nint)(delegate*<IServiceProvider, TView>)(&ServiceProviderServiceExtensions.GetRequiredService<TView>)));
		}
		if (sheet == null)
		{
			sheet = (BottomSheet)(object)ServiceProviderServiceExtensions.GetRequiredService<TView>(_serviceProvider);
		}
		((BindableObject)sheet).BindingContext = vm;
		ILoadableViewModel iVM = vm as ILoadableViewModel;
		if (iVM != null && string.IsNullOrEmpty(slotIndex))
		{
			await iVM.LoadDataAsync(sheet);
		}
		else if (vm is ILoadableViewModel fullsheetVm)
		{
			Tuple<BottomSheet, string> parameterTuple = Tuple.Create<BottomSheet, string>(sheet, slotIndex);
			await fullsheetVm.LoadDataAsync(parameterTuple);
		}
		return sheet;
	}

	[AsyncStateMachine(typeof(_003CGetSheetVM_003Ed__15<>))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<TViewModel> GetSheetVM<TViewModel>(string cacheKey) where TViewModel : class
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		TViewModel vm = _pageCacheService.GetSheetVM<TViewModel>(cacheKey);
		if (vm == null)
		{
			vm = ServiceProviderServiceExtensions.GetRequiredService<TViewModel>(_serviceProvider);
			_pageCacheService.CacheSheetVM(cacheKey, vm);
		}
		if (vm is ILoadableViewModel iVM)
		{
			await iVM.LoadDataAsync(null);
		}
		return vm;
	}

	public BottomSheet GetSheetPage<TView>(string cacheKey) where TView : BottomSheet
	{
		BottomSheet val = _pageCacheService.GetSheetPage(cacheKey);
		if (val == null)
		{
			val = (BottomSheet)(object)ServiceProviderServiceExtensions.GetRequiredService<TView>(_serviceProvider);
		}
		return val;
	}

	[AsyncStateMachine(typeof(_003CGoBackAsync_003Ed__17))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task GoBackAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoBackAsync_003Ed__17 _003CGoBackAsync_003Ed__ = new _003CGoBackAsync_003Ed__17();
		_003CGoBackAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoBackAsync_003Ed__._003C_003E4__this = this;
		_003CGoBackAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoBackAsync_003Ed__._003C_003Et__builder)).Start<_003CGoBackAsync_003Ed__17>(ref _003CGoBackAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoBackAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGoBackModalAsync_003Ed__18))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task GoBackModalAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoBackModalAsync_003Ed__18 _003CGoBackModalAsync_003Ed__ = new _003CGoBackModalAsync_003Ed__18();
		_003CGoBackModalAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoBackModalAsync_003Ed__._003C_003E4__this = this;
		_003CGoBackModalAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoBackModalAsync_003Ed__._003C_003Et__builder)).Start<_003CGoBackModalAsync_003Ed__18>(ref _003CGoBackModalAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoBackModalAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CNavigateToBattleViewAsync_003Ed__19))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task NavigateToBattleViewAsync(string route, BattleLaunchRequest request)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CNavigateToBattleViewAsync_003Ed__19 _003CNavigateToBattleViewAsync_003Ed__ = new _003CNavigateToBattleViewAsync_003Ed__19();
		_003CNavigateToBattleViewAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CNavigateToBattleViewAsync_003Ed__._003C_003E4__this = this;
		_003CNavigateToBattleViewAsync_003Ed__.route = route;
		_003CNavigateToBattleViewAsync_003Ed__.request = request;
		_003CNavigateToBattleViewAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CNavigateToBattleViewAsync_003Ed__._003C_003Et__builder)).Start<_003CNavigateToBattleViewAsync_003Ed__19>(ref _003CNavigateToBattleViewAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CNavigateToBattleViewAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CNavigateToWithParametersAsync_003Ed__20))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task NavigateToWithParametersAsync(string route, IDictionary<string, object> parameters)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CNavigateToWithParametersAsync_003Ed__20 _003CNavigateToWithParametersAsync_003Ed__ = new _003CNavigateToWithParametersAsync_003Ed__20();
		_003CNavigateToWithParametersAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CNavigateToWithParametersAsync_003Ed__._003C_003E4__this = this;
		_003CNavigateToWithParametersAsync_003Ed__.route = route;
		_003CNavigateToWithParametersAsync_003Ed__.parameters = parameters;
		_003CNavigateToWithParametersAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CNavigateToWithParametersAsync_003Ed__._003C_003Et__builder)).Start<_003CNavigateToWithParametersAsync_003Ed__20>(ref _003CNavigateToWithParametersAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CNavigateToWithParametersAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CShowAlertAsync_003Ed__21))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task ShowAlertAsync(string title, string message)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CShowAlertAsync_003Ed__21 _003CShowAlertAsync_003Ed__ = new _003CShowAlertAsync_003Ed__21();
		_003CShowAlertAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CShowAlertAsync_003Ed__._003C_003E4__this = this;
		_003CShowAlertAsync_003Ed__.title = title;
		_003CShowAlertAsync_003Ed__.message = message;
		_003CShowAlertAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CShowAlertAsync_003Ed__._003C_003Et__builder)).Start<_003CShowAlertAsync_003Ed__21>(ref _003CShowAlertAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CShowAlertAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CShowConfirmationAsync_003Ed__22))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> ShowConfirmationAsync(string title, string message, string yesText = "Yes", string noText = "No")
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		string title2 = title;
		string message2 = message;
		string yesText2 = yesText;
		string noText2 = noText;
		object result = await _popupService.ShowPopupAsync<CustomConfirmationPopupViewModel>((Action<CustomConfirmationPopupViewModel>)delegate(CustomConfirmationPopupViewModel vm)
		{
			vm.Title = title2;
			vm.Message = message2;
			vm.YesButtonText = yesText2;
			vm.NoButtonText = noText2;
		}, default(CancellationToken));
		bool boolResult = default(bool);
		int num;
		if (result is bool)
		{
			boolResult = (bool)result;
			num = 1;
		}
		else
		{
			num = 0;
		}
		return (byte)((uint)num & (boolResult ? 1u : 0u)) != 0;
	}

	static ShellNavigationService()
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		HashSet<string> obj = new HashSet<string>();
		obj.Add("//pouch");
		obj.Add("//battlelist");
		obj.Add("//collection");
		obj.Add("//guildmembers");
		obj.Add("//guilddefendermanagement");
		obj.Add("//questtasks");
		_cacheableDeepRoutes = obj;
		_deepVmIdleTimeout = TimeSpan.FromMinutes(10L);
	}
}
