using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.ApplicationModel;
using SpiritSummoner.Application.DTOs;
using SpiritSummoner.Application.DTOs.Session;
using SpiritSummoner.Application.Events;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.DailyGifts;
using SpiritSummoner.Domain.Enums.Common;
using SpiritSummoner.Domain.Enums.Shops;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Infrastructure.FirebaseListeners;
using SpiritSummoner.Infrastructure.Services;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.Popups;
using SpiritSummoner.Presentation.ViewModels.Shared;
using SpiritSummoner.Presentation.ViewModels.Spirits;
using SpiritSummoner.Presentation.Views.BottomSheets;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.ViewModels.StartUp;

public class MainViewModel : ObservableObject, ILoadableViewModel, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass23_0
	{
		private sealed class _003C_003COnNotificationReceived_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass23_0 _003C_003E4__this;

			private GuildWarNotificationBottomSheet _003Csheet_003E5__1;

			private global::System.Exception _003Cex_003E5__2;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
				//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
				//IL_00db: Unknown result type (might be due to invalid IL or missing references)
				//IL_0098: Unknown result type (might be due to invalid IL or missing references)
				//IL_009d: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
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
							_003Csheet_003E5__1 = ServiceProviderServiceExtensions.GetRequiredService<GuildWarNotificationBottomSheet>(_003C_003E4__this._003C_003E4__this._serviceProvider);
							_003Csheet_003E5__1.ViewModel.Initialize(_003C_003E4__this.args.Notification);
							if (_003C_003E4__this._003C_003E4__this._stateService.CurrentRoute.Contains("battleground"))
							{
								goto IL_00f2;
							}
							awaiter = _003C_003E4__this._003C_003E4__this._bottomSheetService.ShowSheetAsync((BottomSheet)(object)_003Csheet_003E5__1).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003C_003COnNotificationReceived_003Eb__0_003Ed _003C_003COnNotificationReceived_003Eb__0_003Ed = this;
								((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003COnNotificationReceived_003Eb__0_003Ed>(ref awaiter, ref _003C_003COnNotificationReceived_003Eb__0_003Ed);
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
						goto IL_00f2;
						IL_00f2:
						_003Csheet_003E5__1 = null;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__2 = ex;
						Console.WriteLine("GuildWar notification sheet error: " + _003Cex_003E5__2.Message);
					}
				}
				catch (global::System.Exception ex)
				{
					_003C_003E1__state = -2;
					((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
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

		public MainViewModel _003C_003E4__this;

		public NotificationReceivedEventArgs args;

		[AsyncStateMachine(typeof(_003C_003COnNotificationReceived_003Eb__0_003Ed))]
		[DebuggerStepThrough]
		internal void _003COnNotificationReceived_003Eb__0()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003COnNotificationReceived_003Eb__0_003Ed _003C_003COnNotificationReceived_003Eb__0_003Ed = new _003C_003COnNotificationReceived_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncVoidMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncVoidMethodBuilder)(ref _003C_003COnNotificationReceived_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003COnNotificationReceived_003Eb__0_003Ed>(ref _003C_003COnNotificationReceived_003Eb__0_003Ed);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass28_0
	{
		public DailyGiftDTO gift;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass28_1
	{
		public string rewardAmountText;

		public _003C_003Ec__DisplayClass28_0 CS_0024_003C_003E8__locals1;

		internal void _003COpenDailyGiftsAsync_003Eb__0(DailyGiftPopupViewModel vm)
		{
			vm.Title = CS_0024_003C_003E8__locals1.gift.Title ?? "Daily Gift!";
			vm.Description = CS_0024_003C_003E8__locals1.gift.Description ?? string.Empty;
			vm.IconSource = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.gift.IconSource) ? "icon_daily_gifts.png" : CS_0024_003C_003E8__locals1.gift.IconSource);
			vm.RewardAmountText = rewardAmountText;
		}
	}

	[CompilerGenerated]
	private sealed class _003CEditMovesAsync_003Ed__31 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public MainViewModel _003C_003E4__this;

		private InsufficientFundsResult _003Cresult_003E5__1;

		private InsufficientFundsResult _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<InsufficientFundsResult> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 1u)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					TaskAwaiter<InsufficientFundsResult> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_014f;
						}
						awaiter2 = _003C_003E4__this._spiritActionService.EditMovesAsync(_003C_003E4__this.PartnerSpirit?.Model, _003C_003E4__this.PartnerSpirit?.Model.SpiritMoves).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CEditMovesAsync_003Ed__31 _003CEditMovesAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<InsufficientFundsResult>, _003CEditMovesAsync_003Ed__31>(ref awaiter2, ref _003CEditMovesAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<InsufficientFundsResult>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__2 = awaiter2.GetResult();
					_003Cresult_003E5__1 = _003C_003Es__2;
					if (_003Cresult_003E5__1 == InsufficientFundsResult.Shop)
					{
						awaiter = _003C_003E4__this._navBarVm.NavigateToCommand.ExecuteAsync("//shop").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003CEditMovesAsync_003Ed__31 _003CEditMovesAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CEditMovesAsync_003Ed__31>(ref awaiter, ref _003CEditMovesAsync_003Ed__);
							return;
						}
						goto IL_014f;
					}
					goto end_IL_0011;
					IL_014f:
					((TaskAwaiter)(ref awaiter)).GetResult();
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine(_003Cex_003E5__3.Message);
					Console.WriteLine(_003Cex_003E5__3.StackTrace);
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
	private sealed class _003CLoadDataAsync_003Ed__24 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object param;

		public MainViewModel _003C_003E4__this;

		private string _003CplayerId_003E5__1;

		private List<PlayerNotificationDTO> _003Cinvites_003E5__2;

		private List<PlayerNotificationDTO> _003C_003Es__3;

		private List<DailyGiftDTO> _003C_003Es__4;

		private object _003C_003Es__5;

		private int _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter<List<PlayerNotificationDTO>> _003C_003Eu__1;

		private TaskAwaiter<List<DailyGiftDTO>> _003C_003Eu__2;

		private TaskAwaiter _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_0312: Unknown result type (might be due to invalid IL or missing references)
			//IL_0317: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_032c: Unknown result type (might be due to invalid IL or missing references)
			//IL_032e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_034b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0350: Unknown result type (might be due to invalid IL or missing references)
			//IL_0358: Unknown result type (might be due to invalid IL or missing references)
			//IL_0269: Unknown result type (might be due to invalid IL or missing references)
			//IL_026e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0276: Unknown result type (might be due to invalid IL or missing references)
			//IL_0230: Unknown result type (might be due to invalid IL or missing references)
			//IL_0235: Unknown result type (might be due to invalid IL or missing references)
			//IL_024a: Unknown result type (might be due to invalid IL or missing references)
			//IL_024c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<List<PlayerNotificationDTO>> awaiter2;
				TaskAwaiter<List<DailyGiftDTO>> awaiter;
				switch (num)
				{
				default:
					_003CplayerId_003E5__1 = _003C_003E4__this._stateService.CurrentPlayerId ?? "";
					awaiter2 = _003C_003E4__this._notificationListener.GetUnAnswearedNotificationsAsync(_003CplayerId_003E5__1).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003CLoadDataAsync_003Ed__24 _003CLoadDataAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<List<PlayerNotificationDTO>>, _003CLoadDataAsync_003Ed__24>(ref awaiter2, ref _003CLoadDataAsync_003Ed__);
						return;
					}
					goto IL_00b5;
				case 0:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<List<PlayerNotificationDTO>>);
					num = (_003C_003E1__state = -1);
					goto IL_00b5;
				case 1:
					awaiter = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<List<DailyGiftDTO>>);
					num = (_003C_003E1__state = -1);
					goto IL_0173;
				case 2:
				case 3:
					break;
					IL_00b5:
					_003C_003Es__3 = awaiter2.GetResult();
					_003Cinvites_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					_003C_003E4__this.HasGuildInvite = Enumerable.Any<PlayerNotificationDTO>((global::System.Collections.Generic.IEnumerable<PlayerNotificationDTO>)_003Cinvites_003E5__2, (Func<PlayerNotificationDTO, bool>)((PlayerNotificationDTO inv) => inv.Type == NotificationType.GuildInvitation));
					awaiter = _003C_003E4__this._dailyGiftService.GetUnredeemedGiftsAsync(_003CplayerId_003E5__1).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter;
						_003CLoadDataAsync_003Ed__24 _003CLoadDataAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<List<DailyGiftDTO>>, _003CLoadDataAsync_003Ed__24>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
						return;
					}
					goto IL_0173;
					IL_0173:
					_003C_003Es__4 = awaiter.GetResult();
					_003C_003E4__this._unredeemedGifts = _003C_003Es__4;
					_003C_003Es__4 = null;
					_003C_003E4__this.DailyGiftCount = _003C_003E4__this._unredeemedGifts.Count;
					if (!_003C_003E4__this._isCached)
					{
						break;
					}
					goto end_IL_0007;
				}
				try
				{
					TaskAwaiter awaiter3;
					if (num != 2)
					{
						if (num == 3)
						{
							awaiter3 = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0367;
						}
						_003C_003Es__6 = 0;
					}
					try
					{
						TaskAwaiter awaiter4;
						if (num == 2)
						{
							awaiter4 = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0285;
						}
						_003C_003E4__this.IsLoading = true;
						if (_003C_003E4__this._stateService.GetCurrentPlayer() == null)
						{
							awaiter4 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "No player data available.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter4;
								_003CLoadDataAsync_003Ed__24 _003CLoadDataAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__24>(ref awaiter4, ref _003CLoadDataAsync_003Ed__);
								return;
							}
							goto IL_0285;
						}
						_003C_003E4__this.LoadSpiritData();
						if (_003C_003E4__this.PartnerSpirit != null)
						{
							_003C_003E4__this._isCached = true;
						}
						goto end_IL_01e6;
						IL_0285:
						((TaskAwaiter)(ref awaiter4)).GetResult();
						goto end_IL_01cb;
						end_IL_01e6:;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__5 = ex;
						_003C_003Es__6 = 1;
					}
					int num2 = _003C_003Es__6;
					if (num2 != 1)
					{
						goto IL_03af;
					}
					_003Cex_003E5__7 = (global::System.Exception)_003C_003Es__5;
					awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Something went wrong...", "Please try again later.").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__3 = awaiter3;
						_003CLoadDataAsync_003Ed__24 _003CLoadDataAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__24>(ref awaiter3, ref _003CLoadDataAsync_003Ed__);
						return;
					}
					goto IL_0367;
					IL_0367:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					Console.WriteLine("Error loading data: " + _003Cex_003E5__7.Message);
					Console.WriteLine("Stack Trace: " + _003Cex_003E5__7.StackTrace);
					_003Cex_003E5__7 = null;
					goto IL_03af;
					IL_03af:
					_003C_003Es__5 = null;
					end_IL_01cb:;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsLoading = false;
					}
				}
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
	private sealed class _003CLoadSpiritData_003Ed__25 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public MainViewModel _003C_003E4__this;

		private string _003CpartnerId_003E5__1;

		private SpiritCardViewModel _003Cvm_003E5__2;

		private string _003CacquiredId_003E5__3;

		private ValueTuple<SpiritCardViewModel, string> _003C_003Es__4;

		private ValueTuple<SpiritCardViewModel, string> _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<ValueTuple<SpiritCardViewModel, string>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<ValueTuple<SpiritCardViewModel, string>> awaiter;
					if (num != 0)
					{
						_003CpartnerId_003E5__1 = _003C_003E4__this._stateService.GetCurrentPlayer().PartnerSpiritId;
						_003C_003E4__this.PartnerSpirit?.Dispose();
						if (!string.IsNullOrEmpty(_003C_003E4__this._acquiredPartnerSpiritId))
						{
							_003C_003E4__this._modelFactory.ReleaseModel(_003C_003E4__this._acquiredPartnerSpiritId);
						}
						awaiter = SpiritCardViewModelHelper.CreateViewModelWithTrackingAsync(_003C_003E4__this._serviceProvider, _003C_003E4__this._modelFactory, _003CpartnerId_003E5__1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadSpiritData_003Ed__25 _003CLoadSpiritData_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<ValueTuple<SpiritCardViewModel, string>>, _003CLoadSpiritData_003Ed__25>(ref awaiter, ref _003CLoadSpiritData_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<ValueTuple<SpiritCardViewModel, string>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__4 = awaiter.GetResult();
					_003C_003Es__5 = _003C_003Es__4;
					_003Cvm_003E5__2 = _003C_003Es__5.Item1;
					_003CacquiredId_003E5__3 = _003C_003Es__5.Item2;
					_003C_003Es__4 = default(ValueTuple<SpiritCardViewModel, string>);
					_003C_003Es__5 = default(ValueTuple<SpiritCardViewModel, string>);
					_003C_003E4__this.PartnerSpirit = _003Cvm_003E5__2;
					_003C_003E4__this._acquiredPartnerSpiritId = _003CacquiredId_003E5__3;
					_003CpartnerId_003E5__1 = null;
					_003Cvm_003E5__2 = null;
					_003CacquiredId_003E5__3 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__6 = ex;
					Console.WriteLine("Error loading spirit: " + _003Cex_003E5__6.Message);
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
	private sealed class _003CNavigateToSpiritDetails_003Ed__27 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string id;

		public MainViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_014e;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._navigationService.NavigateToAsync("//main/spiritdetails?spiritId=" + id).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CNavigateToSpiritDetails_003Ed__27 _003CNavigateToSpiritDetails_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToSpiritDetails_003Ed__27>(ref awaiter2, ref _003CNavigateToSpiritDetails_003Ed__);
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
					goto IL_0160;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error navigating to spiritpage", _003Cex_003E5__3.Message).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CNavigateToSpiritDetails_003Ed__27 _003CNavigateToSpiritDetails_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToSpiritDetails_003Ed__27>(ref awaiter, ref _003CNavigateToSpiritDetails_003Ed__);
					return;
				}
				goto IL_014e;
				IL_014e:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__3 = null;
				goto IL_0160;
				IL_0160:
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
	private sealed class _003COpenDailyGiftsAsync_003Ed__28 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public MainViewModel _003C_003E4__this;

		private List<DailyGiftDTO> _003CgiftsToRedeem_003E5__1;

		private Enumerator<DailyGiftDTO> _003C_003Es__2;

		private _003C_003Ec__DisplayClass28_0 _003C_003E8__3;

		private _003C_003Ec__DisplayClass28_1 _003C_003E8__4;

		private Result<RedeemDailyGiftResponse> _003Cresult_003E5__5;

		private Result<RedeemDailyGiftResponse> _003C_003Es__6;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<Result<RedeemDailyGiftResponse>> _003C_003Eu__2;

		private TaskAwaiter<object?> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02af: Unknown result type (might be due to invalid IL or missing references)
			//IL_025c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0262: Unknown result type (might be due to invalid IL or missing references)
			//IL_0269: Unknown result type (might be due to invalid IL or missing references)
			//IL_026e: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0283: Unknown result type (might be due to invalid IL or missing references)
			//IL_0285: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0348: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00a0;
				}
				if ((uint)(num - 1) > 1u)
				{
					if (_003C_003E4__this._unredeemedGifts.Count == 0)
					{
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Daily Gifts", "No new gifts available right now.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003COpenDailyGiftsAsync_003Ed__28 _003COpenDailyGiftsAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenDailyGiftsAsync_003Ed__28>(ref awaiter, ref _003COpenDailyGiftsAsync_003Ed__);
							return;
						}
						goto IL_00a0;
					}
					_003CgiftsToRedeem_003E5__1 = new List<DailyGiftDTO>((global::System.Collections.Generic.IEnumerable<DailyGiftDTO>)_003C_003E4__this._unredeemedGifts);
					_003C_003Es__2 = _003CgiftsToRedeem_003E5__1.GetEnumerator();
				}
				try
				{
					TaskAwaiter<object> awaiter2;
					if (num != 1)
					{
						if (num != 2)
						{
							goto IL_0319;
						}
						awaiter2 = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter<object>);
						num = (_003C_003E1__state = -1);
						goto IL_02be;
					}
					TaskAwaiter<Result<RedeemDailyGiftResponse>> awaiter3 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<Result<RedeemDailyGiftResponse>>);
					num = (_003C_003E1__state = -1);
					goto IL_01a4;
					IL_02be:
					awaiter2.GetResult();
					_003C_003E4__this._unredeemedGifts.Remove(_003C_003E8__4.CS_0024_003C_003E8__locals1.gift);
					_003C_003E4__this.DailyGiftCount = _003C_003E4__this._unredeemedGifts.Count;
					_003C_003E8__4 = null;
					_003Cresult_003E5__5 = null;
					_003C_003E8__3 = null;
					goto IL_0319;
					IL_0319:
					if (_003C_003Es__2.MoveNext())
					{
						_003C_003E8__3 = new _003C_003Ec__DisplayClass28_0();
						_003C_003E8__3.gift = _003C_003Es__2.Current;
						_003C_003E8__4 = new _003C_003Ec__DisplayClass28_1();
						_003C_003E8__4.CS_0024_003C_003E8__locals1 = _003C_003E8__3;
						awaiter3 = _003C_003E4__this._redeemDailyGiftUseCase.ExecuteAsync(_003C_003E8__4.CS_0024_003C_003E8__locals1.gift).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter3;
							_003COpenDailyGiftsAsync_003Ed__28 _003COpenDailyGiftsAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<RedeemDailyGiftResponse>>, _003COpenDailyGiftsAsync_003Ed__28>(ref awaiter3, ref _003COpenDailyGiftsAsync_003Ed__);
							return;
						}
						goto IL_01a4;
					}
					goto end_IL_00d6;
					IL_01a4:
					_003C_003Es__6 = awaiter3.GetResult();
					_003Cresult_003E5__5 = _003C_003Es__6;
					_003C_003Es__6 = null;
					if (!_003Cresult_003E5__5.Success || (object)_003Cresult_003E5__5.Data == null)
					{
						Console.WriteLine("Failed to redeem gift " + _003C_003E8__4.CS_0024_003C_003E8__locals1.gift.Id + ": " + _003Cresult_003E5__5.ErrorMessage);
						goto IL_0319;
					}
					_003C_003E8__4.rewardAmountText = BuildRewardAmountText(_003Cresult_003E5__5.Data);
					awaiter2 = _003C_003E4__this._popupService.ShowPopupAsync<DailyGiftPopupViewModel>((Action<DailyGiftPopupViewModel>)delegate(DailyGiftPopupViewModel vm)
					{
						vm.Title = _003C_003E8__4.CS_0024_003C_003E8__locals1.gift.Title ?? "Daily Gift!";
						vm.Description = _003C_003E8__4.CS_0024_003C_003E8__locals1.gift.Description ?? string.Empty;
						vm.IconSource = (string.IsNullOrEmpty(_003C_003E8__4.CS_0024_003C_003E8__locals1.gift.IconSource) ? "icon_daily_gifts.png" : _003C_003E8__4.CS_0024_003C_003E8__locals1.gift.IconSource);
						vm.RewardAmountText = _003C_003E8__4.rewardAmountText;
					}, default(CancellationToken)).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__3 = awaiter2;
						_003COpenDailyGiftsAsync_003Ed__28 _003COpenDailyGiftsAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003COpenDailyGiftsAsync_003Ed__28>(ref awaiter2, ref _003COpenDailyGiftsAsync_003Ed__);
						return;
					}
					goto IL_02be;
					end_IL_00d6:;
				}
				finally
				{
					if (num < 0)
					{
						((global::System.IDisposable)_003C_003Es__2).Dispose();
					}
				}
				_003C_003Es__2 = default(Enumerator<DailyGiftDTO>);
				goto end_IL_0007;
				IL_00a0:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CgiftsToRedeem_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CgiftsToRedeem_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003COpenGameNews_003Ed__29 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public MainViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<object?> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_0165;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter<object> awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._popupService.ShowPopupAsync<NewsDetailsPopupViewModel>((Action<NewsDetailsPopupViewModel>)delegate
						{
						}, default(CancellationToken)).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003COpenGameNews_003Ed__29 _003COpenGameNews_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003COpenGameNews_003Ed__29>(ref awaiter2, ref _003COpenGameNews_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<object>);
						num = (_003C_003E1__state = -1);
					}
					awaiter2.GetResult();
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_01a9;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to open game news.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__2 = awaiter;
					_003COpenGameNews_003Ed__29 _003COpenGameNews_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenGameNews_003Ed__29>(ref awaiter, ref _003COpenGameNews_003Ed__);
					return;
				}
				goto IL_0165;
				IL_0165:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine($"OpenGameNews error: {_003Cex_003E5__3}");
				_003Cex_003E5__3 = null;
				goto IL_01a9;
				IL_01a9:
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
	private sealed class _003COpenInvitations_003Ed__26 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public MainViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private object _003Cresult_003E5__3;

		private bool _003Caccepted_003E5__4;

		private object _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<object?> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_01a3;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter<object> awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._popupService.ShowPopupAsync<GuildInvitationsPopupViewModel>(default(CancellationToken)).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003COpenInvitations_003Ed__26 _003COpenInvitations_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003COpenInvitations_003Ed__26>(ref awaiter2, ref _003COpenInvitations_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<object>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__5 = awaiter2.GetResult();
					_003Cresult_003E5__3 = _003C_003Es__5;
					_003C_003Es__5 = null;
					int num2;
					if (_003Cresult_003E5__3 is bool)
					{
						_003Caccepted_003E5__4 = (bool)_003Cresult_003E5__3;
						num2 = 1;
					}
					else
					{
						num2 = 0;
					}
					if (((uint)num2 & (_003Caccepted_003E5__4 ? 1u : 0u)) != 0)
					{
						_003C_003E4__this.HasGuildInvite = false;
					}
					_003Cresult_003E5__3 = null;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num3 = _003C_003Es__2;
				if (num3 != 1)
				{
					goto IL_01e7;
				}
				_003Cex_003E5__6 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to open invitations.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__2 = awaiter;
					_003COpenInvitations_003Ed__26 _003COpenInvitations_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenInvitations_003Ed__26>(ref awaiter, ref _003COpenInvitations_003Ed__);
					return;
				}
				goto IL_01a3;
				IL_01a3:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine($"OpenInvitations error: {_003Cex_003E5__6}");
				_003Cex_003E5__6 = null;
				goto IL_01e7;
				IL_01e7:
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

	private readonly INavigationService _navigationService;

	private readonly IPlayerStateService _stateService;

	private readonly ISpiritActionService _spiritActionService;

	private readonly NavBarViewModel _navBarVm;

	private readonly SpiritCardModelFactory _modelFactory;

	private readonly IServiceProvider _serviceProvider;

	private readonly IPlayerNotificationListenerService _notificationListener;

	private readonly IPopupService _popupService;

	private readonly IBottomSheetService _bottomSheetService;

	private readonly IDailyGiftService _dailyGiftService;

	private readonly RedeemDailyGiftUseCase _redeemDailyGiftUseCase;

	private List<DailyGiftDTO> _unredeemedGifts = new List<DailyGiftDTO>();

	private static readonly HashSet<NotificationType> _guildWarPopupTypes;

	private string? _acquiredPartnerSpiritId;

	[ObservableProperty]
	private SpiritCardViewModel? _partnerSpirit;

	[ObservableProperty]
	private bool _isLoading;

	[ObservableProperty]
	private bool _hasGuildInvite = false;

	[ObservableProperty]
	private int _dailyGiftCount = 0;

	public bool _isCached = false;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<object?>? loadDataCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? openInvitationsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<string>? navigateToSpiritDetailsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? openDailyGiftsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? openGameNewsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? editMovesCommand;

	public NavBarViewModel NavbarVM => _navBarVm;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public SpiritCardViewModel? PartnerSpirit
	{
		get
		{
			return _partnerSpirit;
		}
		set
		{
			if (!EqualityComparer<SpiritCardViewModel>.Default.Equals(_partnerSpirit, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PartnerSpirit);
				_partnerSpirit = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PartnerSpirit);
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
	public bool HasGuildInvite
	{
		get
		{
			return _hasGuildInvite;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasGuildInvite, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasGuildInvite);
				_hasGuildInvite = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasGuildInvite);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int DailyGiftCount
	{
		get
		{
			return _dailyGiftCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_dailyGiftCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.DailyGiftCount);
				_dailyGiftCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.DailyGiftCount);
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
	public IAsyncRelayCommand OpenInvitationsCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = openInvitationsCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)OpenInvitations);
				AsyncRelayCommand val2 = val;
				openInvitationsCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<string> NavigateToSpiritDetailsCommand => (IAsyncRelayCommand<string>)(object)(navigateToSpiritDetailsCommand ?? (navigateToSpiritDetailsCommand = new AsyncRelayCommand<string>((Func<string, global::System.Threading.Tasks.Task>)NavigateToSpiritDetails)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand OpenDailyGiftsCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = openDailyGiftsCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)OpenDailyGiftsAsync);
				AsyncRelayCommand val2 = val;
				openDailyGiftsCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand OpenGameNewsCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = openGameNewsCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)OpenGameNews);
				AsyncRelayCommand val2 = val;
				openGameNewsCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand EditMovesCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = editMovesCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)EditMovesAsync);
				AsyncRelayCommand val2 = val;
				editMovesCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public MainViewModel(INavigationService navigationService, IPlayerStateService userSession, ISpiritActionService spiritActionService, NavBarViewModel navBarViewModel, SpiritCardModelFactory modelFactory, IServiceProvider serviceProvider, IPlayerNotificationListenerService playerNotificationListenerService, IPopupService popupService, IBottomSheetService bottomSheetService, IDailyGiftService dailyGiftService, RedeemDailyGiftUseCase redeemDailyGiftUseCase)
	{
		_navigationService = navigationService;
		_stateService = userSession;
		_spiritActionService = spiritActionService;
		_navBarVm = navBarViewModel;
		_modelFactory = modelFactory;
		_serviceProvider = serviceProvider;
		_notificationListener = playerNotificationListenerService;
		_popupService = popupService;
		_bottomSheetService = bottomSheetService;
		_dailyGiftService = dailyGiftService;
		_redeemDailyGiftUseCase = redeemDailyGiftUseCase;
		_stateService.StateChanged += OnPlayerStateChanged;
		_notificationListener.NotificationReceived += OnNotificationReceived;
	}

	private void OnPlayerStateChanged(object? sender, StateChangedEventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		string changeType = e.ChangeType;
		string text = changeType;
		if (text == "Partner")
		{
			MainThread.BeginInvokeOnMainThread((Action)([CompilerGenerated] () =>
			{
				LoadSpiritData();
			}));
		}
	}

	private void OnNotificationReceived(object? sender, NotificationReceivedEventArgs args)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		_003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass23_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		CS_0024_003C_003E8__locals0.args = args;
		if (CS_0024_003C_003E8__locals0.args.Notification.Type == NotificationType.GuildInvitation)
		{
			HasGuildInvite = true;
		}
		if (_guildWarPopupTypes.Contains(CS_0024_003C_003E8__locals0.args.Notification.Type))
		{
			MainThread.BeginInvokeOnMainThread((Action)([AsyncStateMachine(typeof(_003C_003Ec__DisplayClass23_0._003C_003COnNotificationReceived_003Eb__0_003Ed))] [DebuggerStepThrough] () =>
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				_003C_003Ec__DisplayClass23_0._003C_003COnNotificationReceived_003Eb__0_003Ed _003C_003COnNotificationReceived_003Eb__0_003Ed = new _003C_003Ec__DisplayClass23_0._003C_003COnNotificationReceived_003Eb__0_003Ed
				{
					_003C_003Et__builder = AsyncVoidMethodBuilder.Create(),
					_003C_003E4__this = CS_0024_003C_003E8__locals0,
					_003C_003E1__state = -1
				};
				((AsyncVoidMethodBuilder)(ref _003C_003COnNotificationReceived_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass23_0._003C_003COnNotificationReceived_003Eb__0_003Ed>(ref _003C_003COnNotificationReceived_003Eb__0_003Ed);
			}));
		}
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__24))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? param = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__24 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__24();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.param = param;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__24>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadSpiritData_003Ed__25))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadSpiritData()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadSpiritData_003Ed__25 _003CLoadSpiritData_003Ed__ = new _003CLoadSpiritData_003Ed__25();
		_003CLoadSpiritData_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadSpiritData_003Ed__._003C_003E4__this = this;
		_003CLoadSpiritData_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadSpiritData_003Ed__._003C_003Et__builder)).Start<_003CLoadSpiritData_003Ed__25>(ref _003CLoadSpiritData_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadSpiritData_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003COpenInvitations_003Ed__26))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task OpenInvitations()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COpenInvitations_003Ed__26 _003COpenInvitations_003Ed__ = new _003COpenInvitations_003Ed__26();
		_003COpenInvitations_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003COpenInvitations_003Ed__._003C_003E4__this = this;
		_003COpenInvitations_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003COpenInvitations_003Ed__._003C_003Et__builder)).Start<_003COpenInvitations_003Ed__26>(ref _003COpenInvitations_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003COpenInvitations_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CNavigateToSpiritDetails_003Ed__27))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task NavigateToSpiritDetails(string id)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CNavigateToSpiritDetails_003Ed__27 _003CNavigateToSpiritDetails_003Ed__ = new _003CNavigateToSpiritDetails_003Ed__27();
		_003CNavigateToSpiritDetails_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CNavigateToSpiritDetails_003Ed__._003C_003E4__this = this;
		_003CNavigateToSpiritDetails_003Ed__.id = id;
		_003CNavigateToSpiritDetails_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CNavigateToSpiritDetails_003Ed__._003C_003Et__builder)).Start<_003CNavigateToSpiritDetails_003Ed__27>(ref _003CNavigateToSpiritDetails_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CNavigateToSpiritDetails_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003COpenDailyGiftsAsync_003Ed__28))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task OpenDailyGiftsAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COpenDailyGiftsAsync_003Ed__28 _003COpenDailyGiftsAsync_003Ed__ = new _003COpenDailyGiftsAsync_003Ed__28();
		_003COpenDailyGiftsAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003COpenDailyGiftsAsync_003Ed__._003C_003E4__this = this;
		_003COpenDailyGiftsAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003COpenDailyGiftsAsync_003Ed__._003C_003Et__builder)).Start<_003COpenDailyGiftsAsync_003Ed__28>(ref _003COpenDailyGiftsAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003COpenDailyGiftsAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003COpenGameNews_003Ed__29))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task OpenGameNews()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COpenGameNews_003Ed__29 _003COpenGameNews_003Ed__ = new _003COpenGameNews_003Ed__29();
		_003COpenGameNews_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003COpenGameNews_003Ed__._003C_003E4__this = this;
		_003COpenGameNews_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003COpenGameNews_003Ed__._003C_003Et__builder)).Start<_003COpenGameNews_003Ed__29>(ref _003COpenGameNews_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003COpenGameNews_003Ed__._003C_003Et__builder)).Task;
	}

	private static string BuildRewardAmountText(RedeemDailyGiftResponse response)
	{
		string rewardType = response.RewardType;
		if (1 == 0)
		{
		}
		string result = ((rewardType == "gold") ? $"+ {response.Amount:N0} GOLD" : ((rewardType == "gems") ? $"+ {response.Amount:N0} GEMS" : ((rewardType == "exp") ? $"+ {response.Amount:N0} EXP" : ((!(rewardType == "spirit")) ? $"+ {response.Amount:N0} {(response.ItemKey ?? response.RewardType).ToUpper()}" : ("You got: " + (response.SpiritName ?? "a Spirit") + "!")))));
		if (1 == 0)
		{
		}
		return result;
	}

	[AsyncStateMachine(typeof(_003CEditMovesAsync_003Ed__31))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task EditMovesAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CEditMovesAsync_003Ed__31 _003CEditMovesAsync_003Ed__ = new _003CEditMovesAsync_003Ed__31();
		_003CEditMovesAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CEditMovesAsync_003Ed__._003C_003E4__this = this;
		_003CEditMovesAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CEditMovesAsync_003Ed__._003C_003Et__builder)).Start<_003CEditMovesAsync_003Ed__31>(ref _003CEditMovesAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CEditMovesAsync_003Ed__._003C_003Et__builder)).Task;
	}

	public void Dispose()
	{
		_stateService.StateChanged -= OnPlayerStateChanged;
		_notificationListener.NotificationReceived -= OnNotificationReceived;
		PartnerSpirit?.Dispose();
		if (!string.IsNullOrEmpty(_acquiredPartnerSpiritId))
		{
			_modelFactory.ReleaseModel(_acquiredPartnerSpiritId);
			_acquiredPartnerSpiritId = null;
		}
	}

	static MainViewModel()
	{
		HashSet<NotificationType> obj = new HashSet<NotificationType>();
		obj.Add(NotificationType.GuildWarEnrollmentReminder);
		obj.Add(NotificationType.GuildWarMatchFound);
		obj.Add(NotificationType.GuildWarRegistrationClosing);
		obj.Add(NotificationType.GuildWarDefenderManagement);
		obj.Add(NotificationType.GuildWarStarted);
		obj.Add(NotificationType.GuildWarDefenderExpiring);
		obj.Add(NotificationType.GuildWarEnded);
		_guildWarPopupTypes = obj;
	}
}
