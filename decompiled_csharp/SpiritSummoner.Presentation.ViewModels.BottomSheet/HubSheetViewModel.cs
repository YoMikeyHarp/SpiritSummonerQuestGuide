using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.Events;
using SpiritSummoner.Application.Session;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Players;
using SpiritSummoner.Domain.Entities.Guilds;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Repositories;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Infrastructure.Contracts;
using SpiritSummoner.Infrastructure.Diagnostics;
using SpiritSummoner.Infrastructure.FirebaseListeners;
using SpiritSummoner.Presentation.Models;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.Services.Caching;
using SpiritSummoner.Presentation.ViewModels.Popups;
using SpiritSummoner.Presentation.ViewModels.Shared;
using SpiritSummoner.Presentation.Views.BottomSheets;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.ViewModels.BottomSheet;

public class HubSheetViewModel : ObservableObject, ILoadableViewModel, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003CDismissAsync_003Ed__30 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public HubSheetViewModel _003C_003E4__this;

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
					awaiter = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CDismissAsync_003Ed__30 _003CDismissAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CDismissAsync_003Ed__30>(ref awaiter, ref _003CDismissAsync_003Ed__);
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
	private sealed class _003CGoToGuildsAsync_003Ed__29 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public HubSheetViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if ((uint)num > 1u)
				{
					if (num == 2)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01c8;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					TaskAwaiter awaiter3;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0117;
						}
						awaiter3 = _003C_003E4__this._navBarViewModel.NavigateToCommand.ExecuteAsync("//guild").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CGoToGuildsAsync_003Ed__29 _003CGoToGuildsAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToGuildsAsync_003Ed__29>(ref awaiter3, ref _003CGoToGuildsAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
					}
					((TaskAwaiter)(ref awaiter3)).GetResult();
					awaiter2 = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter2;
						_003CGoToGuildsAsync_003Ed__29 _003CGoToGuildsAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToGuildsAsync_003Ed__29>(ref awaiter2, ref _003CGoToGuildsAsync_003Ed__);
						return;
					}
					goto IL_0117;
					IL_0117:
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
					goto IL_01fc;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Navigation error!", "Failed to  navigate to guilds, please try again!").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 2);
					_003C_003Eu__1 = awaiter;
					_003CGoToGuildsAsync_003Ed__29 _003CGoToGuildsAsync_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToGuildsAsync_003Ed__29>(ref awaiter, ref _003CGoToGuildsAsync_003Ed__);
					return;
				}
				goto IL_01c8;
				IL_01c8:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine(_003Cex_003E5__3.Message);
				Console.WriteLine(_003Cex_003E5__3.StackTrace);
				_003Cex_003E5__3 = null;
				goto IL_01fc;
				IL_01fc:
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
	private sealed class _003CGoToPouch_003Ed__26 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public HubSheetViewModel _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
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
					TaskAwaiter awaiter;
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_011c;
						}
						awaiter2 = _003C_003E4__this._navigationService.NavigateToAsync(_003C_003E4__this._stateService?.CurrentRoute + "/pouch").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CGoToPouch_003Ed__26 _003CGoToPouch_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToPouch_003Ed__26>(ref awaiter2, ref _003CGoToPouch_003Ed__);
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
					awaiter = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter;
						_003CGoToPouch_003Ed__26 _003CGoToPouch_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToPouch_003Ed__26>(ref awaiter, ref _003CGoToPouch_003Ed__);
						return;
					}
					goto IL_011c;
					IL_011c:
					((TaskAwaiter)(ref awaiter)).GetResult();
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__1 = ex;
					Console.WriteLine(_003Cex_003E5__1.Message);
					Console.WriteLine(_003Cex_003E5__1.StackTrace);
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
	private sealed class _003CGoToShop_003Ed__27 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public HubSheetViewModel _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
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
							goto IL_0105;
						}
						awaiter2 = _003C_003E4__this._navBarViewModel.NavigateToCommand.ExecuteAsync("//shop").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CGoToShop_003Ed__27 _003CGoToShop_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToShop_003Ed__27>(ref awaiter2, ref _003CGoToShop_003Ed__);
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
					awaiter = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter;
						_003CGoToShop_003Ed__27 _003CGoToShop_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToShop_003Ed__27>(ref awaiter, ref _003CGoToShop_003Ed__);
						return;
					}
					goto IL_0105;
					IL_0105:
					((TaskAwaiter)(ref awaiter)).GetResult();
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__1 = ex;
					Console.WriteLine(_003Cex_003E5__1.Message);
					Console.WriteLine(_003Cex_003E5__1.StackTrace);
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
	private sealed class _003CLinkAccount_003Ed__31 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public HubSheetViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private LinkAccountSheet _003ClinkSheet_003E5__3;

		private bool _003CisAccountLinked_003E5__4;

		private bool _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01da: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_020f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0214: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Expected O, but got Unknown
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_022b;
					}
					_003C_003Es__1 = null;
					_003C_003Es__2 = 0;
				}
				try
				{
					if (num != 0)
					{
					}
					try
					{
						TaskAwaiter<bool> awaiter2;
						if (num == 0)
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							goto IL_0120;
						}
						if (_003C_003E4__this._stateService.GetCurrentPlayer() == null)
						{
							goto end_IL_0031;
						}
						if (!_003C_003E4__this._stateService.GetCurrentPlayer().IsAccountLinked)
						{
							_003ClinkSheet_003E5__3 = ServiceProviderServiceExtensions.GetRequiredService<LinkAccountSheet>(_003C_003E4__this._serviceProvider);
							LinkAccountSheet linkAccountSheet = _003ClinkSheet_003E5__3;
							List<Detent> obj = new List<Detent>(1);
							obj.Add((Detent)new FullscreenDetent());
							((BottomSheet)linkAccountSheet).Detents = (global::System.Collections.Generic.IList<Detent>)obj;
							awaiter2 = _003C_003E4__this._bottomSheetService.ShowSheetAsync<bool>((BottomSheet)(object)_003ClinkSheet_003E5__3, _003ClinkSheet_003E5__3.SheetId).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003CLinkAccount_003Ed__31 _003CLinkAccount_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CLinkAccount_003Ed__31>(ref awaiter2, ref _003CLinkAccount_003Ed__);
								return;
							}
							goto IL_0120;
						}
						goto end_IL_0029;
						IL_0120:
						_003C_003Es__5 = awaiter2.GetResult();
						_003CisAccountLinked_003E5__4 = _003C_003Es__5;
						Console.WriteLine("Account linking result: " + (_003CisAccountLinked_003E5__4 ? "Linked" : "Guest"));
						((ObservableObject)_003C_003E4__this).OnPropertyChanged("IsAccountLinked");
						_003ClinkSheet_003E5__3 = null;
						goto end_IL_0029;
						end_IL_0031:;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__6 = ex;
						Console.WriteLine("Sign out failed: " + _003Cex_003E5__6.Message);
						goto end_IL_0029;
					}
					_003C_003Es__2 = 1;
					end_IL_0029:;
				}
				catch (object obj2)
				{
					_003C_003Es__1 = obj2;
				}
				awaiter = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__2 = awaiter;
					_003CLinkAccount_003Ed__31 _003CLinkAccount_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLinkAccount_003Ed__31>(ref awaiter, ref _003CLinkAccount_003Ed__);
					return;
				}
				goto IL_022b;
				IL_022b:
				((TaskAwaiter)(ref awaiter)).GetResult();
				object obj3 = _003C_003Es__1;
				if (obj3 != null)
				{
					if (!(obj3 is global::System.Exception ex2))
					{
						throw obj3;
					}
					ExceptionDispatchInfo.Capture(ex2).Throw();
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					_003C_003Es__1 = null;
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
	private sealed class _003CLoadDataAsync_003Ed__25 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object parameter;

		public HubSheetViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private BottomSheet _003Csheet_003E5__3;

		private Guild _003C_003Es__4;

		private Guild _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<Guild?> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0339: Unknown result type (might be due to invalid IL or missing references)
			//IL_033e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0353: Unknown result type (might be due to invalid IL or missing references)
			//IL_0355: Unknown result type (might be due to invalid IL or missing references)
			//IL_0370: Unknown result type (might be due to invalid IL or missing references)
			//IL_0375: Unknown result type (might be due to invalid IL or missing references)
			//IL_037d: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_0209: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0216: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02be: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_027f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0284: Unknown result type (might be due to invalid IL or missing references)
			//IL_0299: Unknown result type (might be due to invalid IL or missing references)
			//IL_029b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_038c;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter<Guild> awaiter4;
					TaskAwaiter<Guild> awaiter3;
					TaskAwaiter awaiter2;
					switch (num)
					{
					default:
					{
						if (parameter == null)
						{
							goto IL_0264;
						}
						ref BottomSheet reference = ref _003Csheet_003E5__3;
						object obj = parameter;
						reference = (BottomSheet)((obj is BottomSheet) ? obj : null);
						if (_003Csheet_003E5__3 == null)
						{
							goto IL_0264;
						}
						_003C_003E4__this._sheet = _003Csheet_003E5__3;
						if (_003C_003E4__this.HasGuild)
						{
							if (_003C_003E4__this.Guild == null)
							{
								awaiter4 = _003C_003E4__this._guildRepository.GetByIdAsync(_003C_003E4__this._playerInfoModel.GuildId).GetAwaiter();
								if (!awaiter4.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter4;
									_003CLoadDataAsync_003Ed__25 _003CLoadDataAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CLoadDataAsync_003Ed__25>(ref awaiter4, ref _003CLoadDataAsync_003Ed__);
									return;
								}
								goto IL_0128;
							}
							if (_003C_003E4__this.Guild.ID != _003C_003E4__this._playerInfoModel?.GuildId)
							{
								awaiter3 = _003C_003E4__this._guildRepository.GetByIdAsync(_003C_003E4__this._playerInfoModel?.GuildId ?? "").GetAwaiter();
								if (!awaiter3.IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__1 = awaiter3;
									_003CLoadDataAsync_003Ed__25 _003CLoadDataAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Guild>, _003CLoadDataAsync_003Ed__25>(ref awaiter3, ref _003CLoadDataAsync_003Ed__);
									return;
								}
								goto IL_0225;
							}
							break;
						}
						goto end_IL_0023;
					}
					case 0:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Guild>);
						num = (_003C_003E1__state = -1);
						goto IL_0128;
					case 1:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Guild>);
						num = (_003C_003E1__state = -1);
						goto IL_0225;
					case 2:
						{
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_02d5;
						}
						IL_0225:
						_003C_003Es__5 = awaiter3.GetResult();
						_003C_003E4__this.Guild = _003C_003Es__5 ?? new Guild
						{
							ID = string.Empty
						};
						_003C_003Es__5 = null;
						break;
						IL_0128:
						_003C_003Es__4 = awaiter4.GetResult();
						_003C_003E4__this.Guild = _003C_003Es__4 ?? new Guild
						{
							ID = string.Empty
						};
						_003C_003Es__4 = null;
						break;
						IL_0264:
						awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Something went wrong", "Please try again").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter2;
							_003CLoadDataAsync_003Ed__25 _003CLoadDataAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__25>(ref awaiter2, ref _003CLoadDataAsync_003Ed__);
							return;
						}
						goto IL_02d5;
						IL_02d5:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						break;
					}
					_003Csheet_003E5__3 = null;
					goto IL_02fb;
					end_IL_0023:;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
					goto IL_02fb;
				}
				goto end_IL_0007;
				IL_02fb:
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_03af;
				}
				_003Cex_003E5__6 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Something went wrong", "Please try again").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 3);
					_003C_003Eu__2 = awaiter;
					_003CLoadDataAsync_003Ed__25 _003CLoadDataAsync_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__25>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
					return;
				}
				goto IL_038c;
				IL_038c:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine(_003Cex_003E5__6.Message);
				_003Cex_003E5__6 = null;
				goto IL_03af;
				IL_03af:
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
	private sealed class _003COpenFullCollection_003Ed__28 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public HubSheetViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private object _003C_003Es__3;

		private int _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01da: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0206: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if ((uint)num > 1u)
				{
					if (num == 2)
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0215;
					}
					_003C_003Es__1 = null;
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_017d;
						}
						_003C_003Es__4 = 0;
					}
					try
					{
						TaskAwaiter awaiter3;
						if (num != 0)
						{
							awaiter3 = _003C_003E4__this._navigationService.NavigateToAsync(_003C_003E4__this._stateService.CurrentRoute + "/collection").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter3;
								_003COpenFullCollection_003Ed__28 _003COpenFullCollection_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenFullCollection_003Ed__28>(ref awaiter3, ref _003COpenFullCollection_003Ed__);
								return;
							}
						}
						else
						{
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
						}
						((TaskAwaiter)(ref awaiter3)).GetResult();
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__3 = ex;
						_003C_003Es__4 = 1;
					}
					int num2 = _003C_003Es__4;
					if (num2 != 1)
					{
						goto IL_018f;
					}
					_003Cex_003E5__5 = (global::System.Exception)_003C_003Es__3;
					awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Navigation Error", _003Cex_003E5__5.Message).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter2;
						_003COpenFullCollection_003Ed__28 _003COpenFullCollection_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenFullCollection_003Ed__28>(ref awaiter2, ref _003COpenFullCollection_003Ed__);
						return;
					}
					goto IL_017d;
					IL_017d:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					_003Cex_003E5__5 = null;
					goto IL_018f;
					IL_018f:
					_003C_003Es__3 = null;
				}
				catch (object obj)
				{
					_003C_003Es__1 = obj;
				}
				awaiter = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 2);
					_003C_003Eu__1 = awaiter;
					_003COpenFullCollection_003Ed__28 _003COpenFullCollection_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenFullCollection_003Ed__28>(ref awaiter, ref _003COpenFullCollection_003Ed__);
					return;
				}
				goto IL_0215;
				IL_0215:
				((TaskAwaiter)(ref awaiter)).GetResult();
				object obj2 = _003C_003Es__1;
				if (obj2 != null)
				{
					if (!(obj2 is global::System.Exception ex2))
					{
						throw obj2;
					}
					ExceptionDispatchInfo.Capture(ex2).Throw();
				}
				_ = _003C_003Es__2;
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
	private sealed class _003CSelectIcon_003Ed__24 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public HubSheetViewModel _003C_003E4__this;

		private object _003Cresult_003E5__1;

		private string _003CiconFile_003E5__2;

		private object _003C_003Es__3;

		private TaskAwaiter<object?> _003C_003Eu__1;

		private TaskAwaiter<Result<UpdatePlayerIconResponse>> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<Result<UpdatePlayerIconResponse>> awaiter;
				TaskAwaiter<object> awaiter2;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<Result<UpdatePlayerIconResponse>>);
						num = (_003C_003E1__state = -1);
						goto IL_0142;
					}
					awaiter2 = _003C_003E4__this._popupService.ShowPopupAsync<SelectPlayerIconPopupViewModel>(default(CancellationToken)).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003CSelectIcon_003Ed__24 _003CSelectIcon_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CSelectIcon_003Ed__24>(ref awaiter2, ref _003CSelectIcon_003Ed__);
						return;
					}
				}
				else
				{
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<object>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__3 = awaiter2.GetResult();
				_003Cresult_003E5__1 = _003C_003Es__3;
				_003C_003Es__3 = null;
				_003CiconFile_003E5__2 = _003Cresult_003E5__1 as string;
				if (_003CiconFile_003E5__2 != null && !string.IsNullOrEmpty(_003CiconFile_003E5__2))
				{
					awaiter = _003C_003E4__this._updatePlayerIconUseCase.ExecuteAsync(new UpdatePlayerIconRequest(_003CiconFile_003E5__2)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter;
						_003CSelectIcon_003Ed__24 _003CSelectIcon_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<UpdatePlayerIconResponse>>, _003CSelectIcon_003Ed__24>(ref awaiter, ref _003CSelectIcon_003Ed__);
						return;
					}
					goto IL_0142;
				}
				goto end_IL_0007;
				IL_0142:
				awaiter.GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cresult_003E5__1 = null;
				_003CiconFile_003E5__2 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cresult_003E5__1 = null;
			_003CiconFile_003E5__2 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSignOutAsync_003Ed__32 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public HubSheetViewModel _003C_003E4__this;

		private ISessionInitializationService _003CsessionInitService_003E5__1;

		private IPresentationCacheInitializationService _003CpresentationInitService_003E5__2;

		private ISessionListenerService _003CsessionListener_003E5__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
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
							goto IL_01a3;
						}
						_003CsessionInitService_003E5__1 = ServiceProviderServiceExtensions.GetRequiredService<ISessionInitializationService>(_003C_003E4__this._serviceProvider);
						_003CpresentationInitService_003E5__2 = ServiceProviderServiceExtensions.GetRequiredService<IPresentationCacheInitializationService>(_003C_003E4__this._serviceProvider);
						_003CsessionInitService_003E5__1.InvalidateCache();
						_003CpresentationInitService_003E5__2.InvalidateCache();
						_003C_003E4__this._pageCacheService.EvictAll();
						_003CsessionListener_003E5__3 = ServiceProviderServiceExtensions.GetRequiredService<ISessionListenerService>(_003C_003E4__this._serviceProvider);
						_003CsessionListener_003E5__3.StopListening();
						FirestoreReadCounter.LogSummary();
						FirestoreReadCounter.Reset();
						_003C_003E4__this._stateService.ClearSession();
						_003C_003E4__this._guildStateService.ClearCurrentGuild();
						awaiter2 = _003C_003E4__this._authService.SignOutAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CSignOutAsync_003Ed__32 _003CSignOutAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSignOutAsync_003Ed__32>(ref awaiter2, ref _003CSignOutAsync_003Ed__);
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
					awaiter = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter;
						_003CSignOutAsync_003Ed__32 _003CSignOutAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSignOutAsync_003Ed__32>(ref awaiter, ref _003CSignOutAsync_003Ed__);
						return;
					}
					goto IL_01a3;
					IL_01a3:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003CsessionInitService_003E5__1 = null;
					_003CpresentationInitService_003E5__2 = null;
					_003CsessionListener_003E5__3 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					Console.WriteLine("Sign out failed: " + _003Cex_003E5__4.Message);
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

	private readonly IBottomSheetService _bottomSheetService;

	private readonly IPlayerStateService _stateService;

	private readonly IGuildStateService _guildStateService;

	private readonly INavigationService _navigationService;

	private readonly NavBarViewModel _navBarViewModel;

	private readonly PlayerInfoModel _playerInfoModel;

	private readonly IAuthService _authService;

	private readonly IServiceProvider _serviceProvider;

	private readonly IGuildRepository _guildRepository;

	private readonly IPageCacheService _pageCacheService;

	private readonly UpdatePlayerIconUseCase _updatePlayerIconUseCase;

	private readonly IPopupService _popupService;

	private BottomSheet? _sheet;

	[ObservableProperty]
	private Guild? _guild;

	private bool _isDisposed;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? selectIconCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goToPouchCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goToShopCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? openFullCollectionCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goToGuildsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? linkAccountCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? signOutCommand;

	public PlayerInfoModel PlayerInfoModel => _playerInfoModel;

	public bool IsAccountLinked
	{
		get
		{
			Player currentPlayer = _stateService.GetCurrentPlayer();
			return currentPlayer != null && currentPlayer != null && currentPlayer.IsAccountLinked;
		}
	}

	public bool HasGuild => !string.IsNullOrEmpty(_playerInfoModel?.GuildId);

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Guild? Guild
	{
		get
		{
			return _guild;
		}
		set
		{
			if (!EqualityComparer<SpiritSummoner.Domain.Entities.Guilds.Guild>.Default.Equals(_guild, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Guild);
				_guild = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Guild);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand SelectIconCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = selectIconCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)SelectIcon);
				AsyncRelayCommand val2 = val;
				selectIconCommand = val;
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

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand GoToShopCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = goToShopCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)GoToShop);
				AsyncRelayCommand val2 = val;
				goToShopCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand OpenFullCollectionCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = openFullCollectionCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)OpenFullCollection);
				AsyncRelayCommand val2 = val;
				openFullCollectionCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand GoToGuildsCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = goToGuildsCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)GoToGuildsAsync);
				AsyncRelayCommand val2 = val;
				goToGuildsCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand LinkAccountCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = linkAccountCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)LinkAccount);
				AsyncRelayCommand val2 = val;
				linkAccountCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand SignOutCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = signOutCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)SignOutAsync);
				AsyncRelayCommand val2 = val;
				signOutCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public void SetSheet(BottomSheet sheet)
	{
		_sheet = sheet;
	}

	public HubSheetViewModel(IBottomSheetService bottomSheetService, INavigationService navigationService, IAuthService authService, NavBarViewModel navBarViewModel, PlayerInfoModel playerInfoModel, IServiceProvider serviceProvider, IGuildRepository guildRepository, IPageCacheService pageCacheService, IPlayerStateService playerStateService, IGuildStateService guildStateService, UpdatePlayerIconUseCase updatePlayerIconUseCase, IPopupService popupService)
	{
		_bottomSheetService = bottomSheetService;
		_navigationService = navigationService;
		_navBarViewModel = navBarViewModel;
		_playerInfoModel = playerInfoModel;
		_authService = authService;
		_serviceProvider = serviceProvider;
		_guildRepository = guildRepository;
		_pageCacheService = pageCacheService;
		_stateService = playerStateService;
		_guildStateService = guildStateService;
		_updatePlayerIconUseCase = updatePlayerIconUseCase;
		_popupService = popupService;
		_stateService.StateChanged += OnStateChanged;
	}

	private void OnStateChanged(object? sender, StateChangedEventArgs e)
	{
		if (e.Scope == StateChangeScope.Player && e.ChangeType == "Guild")
		{
			((ObservableObject)this).OnPropertyChanged("HasGuild");
		}
	}

	[AsyncStateMachine(typeof(_003CSelectIcon_003Ed__24))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task SelectIcon()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSelectIcon_003Ed__24 _003CSelectIcon_003Ed__ = new _003CSelectIcon_003Ed__24();
		_003CSelectIcon_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSelectIcon_003Ed__._003C_003E4__this = this;
		_003CSelectIcon_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSelectIcon_003Ed__._003C_003Et__builder)).Start<_003CSelectIcon_003Ed__24>(ref _003CSelectIcon_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSelectIcon_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__25))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? parameter)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__25 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__25();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.parameter = parameter;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__25>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGoToPouch_003Ed__26))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoToPouch()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoToPouch_003Ed__26 _003CGoToPouch_003Ed__ = new _003CGoToPouch_003Ed__26();
		_003CGoToPouch_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoToPouch_003Ed__._003C_003E4__this = this;
		_003CGoToPouch_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoToPouch_003Ed__._003C_003Et__builder)).Start<_003CGoToPouch_003Ed__26>(ref _003CGoToPouch_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoToPouch_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGoToShop_003Ed__27))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoToShop()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoToShop_003Ed__27 _003CGoToShop_003Ed__ = new _003CGoToShop_003Ed__27();
		_003CGoToShop_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoToShop_003Ed__._003C_003E4__this = this;
		_003CGoToShop_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoToShop_003Ed__._003C_003Et__builder)).Start<_003CGoToShop_003Ed__27>(ref _003CGoToShop_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoToShop_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003COpenFullCollection_003Ed__28))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task OpenFullCollection()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COpenFullCollection_003Ed__28 _003COpenFullCollection_003Ed__ = new _003COpenFullCollection_003Ed__28();
		_003COpenFullCollection_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003COpenFullCollection_003Ed__._003C_003E4__this = this;
		_003COpenFullCollection_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003COpenFullCollection_003Ed__._003C_003Et__builder)).Start<_003COpenFullCollection_003Ed__28>(ref _003COpenFullCollection_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003COpenFullCollection_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGoToGuildsAsync_003Ed__29))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task GoToGuildsAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoToGuildsAsync_003Ed__29 _003CGoToGuildsAsync_003Ed__ = new _003CGoToGuildsAsync_003Ed__29();
		_003CGoToGuildsAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoToGuildsAsync_003Ed__._003C_003E4__this = this;
		_003CGoToGuildsAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoToGuildsAsync_003Ed__._003C_003Et__builder)).Start<_003CGoToGuildsAsync_003Ed__29>(ref _003CGoToGuildsAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoToGuildsAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CDismissAsync_003Ed__30))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task DismissAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CDismissAsync_003Ed__30 _003CDismissAsync_003Ed__ = new _003CDismissAsync_003Ed__30();
		_003CDismissAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CDismissAsync_003Ed__._003C_003E4__this = this;
		_003CDismissAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CDismissAsync_003Ed__._003C_003Et__builder)).Start<_003CDismissAsync_003Ed__30>(ref _003CDismissAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CDismissAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLinkAccount_003Ed__31))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task LinkAccount()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLinkAccount_003Ed__31 _003CLinkAccount_003Ed__ = new _003CLinkAccount_003Ed__31();
		_003CLinkAccount_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLinkAccount_003Ed__._003C_003E4__this = this;
		_003CLinkAccount_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLinkAccount_003Ed__._003C_003Et__builder)).Start<_003CLinkAccount_003Ed__31>(ref _003CLinkAccount_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLinkAccount_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSignOutAsync_003Ed__32))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task SignOutAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSignOutAsync_003Ed__32 _003CSignOutAsync_003Ed__ = new _003CSignOutAsync_003Ed__32();
		_003CSignOutAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSignOutAsync_003Ed__._003C_003E4__this = this;
		_003CSignOutAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSignOutAsync_003Ed__._003C_003Et__builder)).Start<_003CSignOutAsync_003Ed__32>(ref _003CSignOutAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSignOutAsync_003Ed__._003C_003Et__builder)).Task;
	}

	public void Dispose()
	{
		if (!_isDisposed)
		{
			_stateService.StateChanged -= OnStateChanged;
			_isDisposed = true;
		}
	}
}
