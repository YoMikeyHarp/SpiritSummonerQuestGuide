using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Items;
using SpiritSummoner.Application.UseCases.Spirits;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Enums.Shops;
using SpiritSummoner.Domain.Enums.Spirits;
using SpiritSummoner.Domain.Interfaces.Services;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Infrastructure.Services;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.BottomSheet;
using SpiritSummoner.Presentation.ViewModels.Popups;
using SpiritSummoner.Presentation.ViewModels.Shared;
using SpiritSummoner.Presentation.Views.BottomSheets.SpiritSheets;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.ViewModels.Spirits;

public class SpiritDetailsViewModel : ObservableObject, global::System.IDisposable, ILoadableViewModel
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass45_0
	{
		public string orbDropped;

		public int orbQty;

		internal void _003CSellSpirit_003Eb__0(SpiritOrbDropPopupViewModel vm)
		{
			vm.CompletedText = "Found " + orbDropped + "!";
			vm.CompletedText2 = "Spirit Orbs can be used in shop to evolve spirits in your collection";
			vm.OrbCount = orbQty;
			vm.OrbCountText = $"x{orbQty}";
		}
	}

	[CompilerGenerated]
	private sealed class _003CClose_003Ed__33 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritDetailsViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003C_003E4__this.Dispose();
					awaiter = _003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CClose_003Ed__33 _003CClose_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CClose_003Ed__33>(ref awaiter, ref _003CClose_003Ed__);
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
	private sealed class _003CEditMovesAsync_003Ed__38 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritDetailsViewModel _003C_003E4__this;

		private InsufficientFundsResult _003Cresult_003E5__1;

		private InsufficientFundsResult _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<InsufficientFundsResult> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 1u || (_003C_003E4__this.CanPerformActions && _003C_003E4__this.SpiritCardModel?.Model != null))
				{
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
								goto IL_0166;
							}
							awaiter2 = _003C_003E4__this._spiritActionService.EditMovesAsync(_003C_003E4__this.SpiritCardModel.Model, _003C_003E4__this.SpiritCardModel.Model.SpiritMoves).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003CEditMovesAsync_003Ed__38 _003CEditMovesAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<InsufficientFundsResult>, _003CEditMovesAsync_003Ed__38>(ref awaiter2, ref _003CEditMovesAsync_003Ed__);
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
							awaiter = _003C_003E4__this.HandleGoToShopAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter;
								_003CEditMovesAsync_003Ed__38 _003CEditMovesAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CEditMovesAsync_003Ed__38>(ref awaiter, ref _003CEditMovesAsync_003Ed__);
								return;
							}
							goto IL_0166;
						}
						goto end_IL_0044;
						IL_0166:
						((TaskAwaiter)(ref awaiter)).GetResult();
						end_IL_0044:;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__3 = ex;
						Console.WriteLine(_003Cex_003E5__3.Message);
						Console.WriteLine(_003Cex_003E5__3.StackTrace);
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
	private sealed class _003CHandleGoToShopAsync_003Ed__34 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritDetailsViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_00f9;
					}
					_003C_003E4__this.Dispose();
					awaiter2 = _003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003CHandleGoToShopAsync_003Ed__34 _003CHandleGoToShopAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleGoToShopAsync_003Ed__34>(ref awaiter2, ref _003CHandleGoToShopAsync_003Ed__);
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
				awaiter = _003C_003E4__this._navBarViewModel.NavigateToCommand.ExecuteAsync("//shop").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CHandleGoToShopAsync_003Ed__34 _003CHandleGoToShopAsync_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleGoToShopAsync_003Ed__34>(ref awaiter, ref _003CHandleGoToShopAsync_003Ed__);
					return;
				}
				goto IL_00f9;
				IL_00f9:
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
	private sealed class _003CLevelUp_003Ed__37 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritDetailsViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private PlayerSpirit _003CspiritReadModel_003E5__3;

		private LevelUpBottomSheet _003Csheet_003E5__4;

		private LevelUpSheetViewModel _003Cvm_003E5__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0248: Unknown result type (might be due to invalid IL or missing references)
			//IL_024d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0262: Unknown result type (might be due to invalid IL or missing references)
			//IL_0264: Unknown result type (might be due to invalid IL or missing references)
			//IL_0282: Unknown result type (might be due to invalid IL or missing references)
			//IL_0287: Unknown result type (might be due to invalid IL or missing references)
			//IL_028f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0167: Expected O, but got Unknown
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_019e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 1u || (_003C_003E4__this.CanPerformActions && _003C_003E4__this.SpiritCardModel != null))
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
								goto IL_029e;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter awaiter2;
							if (num == 0)
							{
								awaiter2 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_01d7;
							}
							_003C_003E4__this.IsLoading = true;
							_003CspiritReadModel_003E5__3 = _003C_003E4__this._playerStateService.GetPlayerSpirit(_003C_003E4__this.SpiritId);
							if (_003CspiritReadModel_003E5__3 != null)
							{
								_003Csheet_003E5__4 = new LevelUpBottomSheet(_003C_003E4__this._bottomSheetService);
								_003Cvm_003E5__5 = new LevelUpSheetViewModel(_003CspiritReadModel_003E5__3.PlayerSpiritID, _003CspiritReadModel_003E5__3.Name, _003CspiritReadModel_003E5__3.Level, _003CspiritReadModel_003E5__3.HP, _003CspiritReadModel_003E5__3.TrainingPoints, _003C_003E4__this._bottomSheetService, _003C_003E4__this._playerStateService, _003C_003E4__this._navigationService, _003C_003E4__this._spiritBusinessService, _003C_003E4__this._levelUpUseCase);
								((BindableObject)_003Csheet_003E5__4).BindingContext = _003Cvm_003E5__5;
								_003Cvm_003E5__5.SetSheet((BottomSheet)(object)_003Csheet_003E5__4);
								LevelUpBottomSheet levelUpBottomSheet = _003Csheet_003E5__4;
								List<Detent> obj = new List<Detent>(1);
								obj.Add((Detent)new FullscreenDetent());
								((BottomSheet)levelUpBottomSheet).Detents = (global::System.Collections.Generic.IList<Detent>)obj;
								awaiter2 = _003C_003E4__this._bottomSheetService.ShowSheetAsync((BottomSheet)(object)_003Csheet_003E5__4).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter2;
									_003CLevelUp_003Ed__37 _003CLevelUp_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLevelUp_003Ed__37>(ref awaiter2, ref _003CLevelUp_003Ed__);
									return;
								}
								goto IL_01d7;
							}
							goto end_IL_0052;
							IL_01d7:
							((TaskAwaiter)(ref awaiter2)).GetResult();
							_003CspiritReadModel_003E5__3 = null;
							_003Csheet_003E5__4 = null;
							_003Cvm_003E5__5 = null;
							goto IL_020a;
							end_IL_0052:;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
							goto IL_020a;
						}
						goto end_IL_0038;
						IL_020a:
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_02dc;
						}
						_003Cex_003E5__6 = (global::System.Exception)_003C_003Es__1;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Level up failed.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter;
							_003CLevelUp_003Ed__37 _003CLevelUp_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLevelUp_003Ed__37>(ref awaiter, ref _003CLevelUp_003Ed__);
							return;
						}
						goto IL_029e;
						IL_029e:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine("Level up error: " + _003Cex_003E5__6.Message);
						Console.WriteLine(_003Cex_003E5__6.StackTrace);
						_003Cex_003E5__6 = null;
						goto IL_02dc;
						IL_02dc:
						_003C_003Es__1 = null;
						end_IL_0038:;
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
	private sealed class _003CLoadDataAsync_003Ed__31 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object id;

		public SpiritDetailsViewModel _003C_003E4__this;

		private string _003CspiritId_003E5__1;

		private bool _003C_003Es__2;

		private object _003C_003Es__3;

		private int _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0223: Unknown result type (might be due to invalid IL or missing references)
			//IL_0228: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_023d: Unknown result type (might be due to invalid IL or missing references)
			//IL_023f: Unknown result type (might be due to invalid IL or missing references)
			//IL_025d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0262: Unknown result type (might be due to invalid IL or missing references)
			//IL_026a: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<bool> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_00f2;
				}
				if ((uint)(num - 1) <= 1u)
				{
					goto IL_0112;
				}
				_003CspiritId_003E5__1 = id as string;
				if (_003CspiritId_003E5__1 != null && !string.IsNullOrEmpty(_003CspiritId_003E5__1) && (!_003C_003E4__this.IsLoaded || !(_003CspiritId_003E5__1 == _003C_003E4__this.SpiritId) || !_003C_003E4__this.HasValidSpirit))
				{
					awaiter = _003C_003E4__this._loadSemaphore.WaitAsync(0).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CLoadDataAsync_003Ed__31 _003CLoadDataAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CLoadDataAsync_003Ed__31>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
						return;
					}
					goto IL_00f2;
				}
				goto end_IL_0007;
				IL_00f2:
				_003C_003Es__2 = awaiter.GetResult();
				if (_003C_003Es__2)
				{
					goto IL_0112;
				}
				goto end_IL_0007;
				IL_0112:
				try
				{
					TaskAwaiter awaiter2;
					if (num != 1)
					{
						if (num == 2)
						{
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0279;
						}
						_003C_003Es__4 = 0;
					}
					try
					{
						TaskAwaiter awaiter3;
						if (num != 1)
						{
							_003C_003E4__this.IsLoading = true;
							awaiter3 = _003C_003E4__this.LoadSpiritDataAsync(_003CspiritId_003E5__1).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter3;
								_003CLoadDataAsync_003Ed__31 _003CLoadDataAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__31>(ref awaiter3, ref _003CLoadDataAsync_003Ed__);
								return;
							}
						}
						else
						{
							awaiter3 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
						}
						((TaskAwaiter)(ref awaiter3)).GetResult();
						_003C_003E4__this.IsLoaded = true;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__3 = ex;
						_003C_003Es__4 = 1;
					}
					int num2 = _003C_003Es__4;
					if (num2 != 1)
					{
						goto IL_028b;
					}
					_003Cex_003E5__5 = (global::System.Exception)_003C_003Es__3;
					awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to load spirit: " + _003Cex_003E5__5.Message).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__2 = awaiter2;
						_003CLoadDataAsync_003Ed__31 _003CLoadDataAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__31>(ref awaiter2, ref _003CLoadDataAsync_003Ed__);
						return;
					}
					goto IL_0279;
					IL_0279:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					_003Cex_003E5__5 = null;
					goto IL_028b;
					IL_028b:
					_003C_003Es__3 = null;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsLoading = false;
						_003C_003E4__this._loadSemaphore.Release();
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
	private sealed class _003CLoadSpiritDataAsync_003Ed__32 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string spiritId;

		public SpiritDetailsViewModel _003C_003E4__this;

		private PlayerSpirit _003CspiritReadModel_003E5__1;

		private SpiritCardViewModel _003Cvm_003E5__2;

		private string _003CacquiredId_003E5__3;

		private ValueTuple<SpiritCardViewModel, string> _003C_003Es__4;

		private ValueTuple<SpiritCardViewModel, string> _003C_003Es__5;

		private Color _003Ccolor_003E5__6;

		private TaskAwaiter<ValueTuple<SpiritCardViewModel, string>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<ValueTuple<SpiritCardViewModel, string>> awaiter;
				if (num != 0)
				{
					_003C_003E4__this.SpiritId = spiritId;
					_003CspiritReadModel_003E5__1 = _003C_003E4__this._playerStateService.GetPlayerSpirit(spiritId);
					if (_003CspiritReadModel_003E5__1 == null)
					{
						throw new global::System.Exception("Spirit not found");
					}
					_003C_003E4__this.SpiritCardModel?.Dispose();
					if (!string.IsNullOrEmpty(_003C_003E4__this._acquiredSpiritId))
					{
						_003C_003E4__this._modelFactory.ReleaseModel(_003C_003E4__this._acquiredSpiritId);
					}
					awaiter = SpiritCardViewModelHelper.CreateViewModelWithTrackingAsync(_003C_003E4__this._serviceProvider, _003C_003E4__this._modelFactory, spiritId).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CLoadSpiritDataAsync_003Ed__32 _003CLoadSpiritDataAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<ValueTuple<SpiritCardViewModel, string>>, _003CLoadSpiritDataAsync_003Ed__32>(ref awaiter, ref _003CLoadSpiritDataAsync_003Ed__);
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
				_003C_003E4__this.SpiritCardModel = _003Cvm_003E5__2;
				_003C_003E4__this._acquiredSpiritId = _003CacquiredId_003E5__3;
				_003C_003E4__this.Nickname = _003CspiritReadModel_003E5__1.Nickname ?? _003CspiritReadModel_003E5__1.Name;
				if (_003C_003E4__this.SpiritCardModel != null)
				{
					_003Ccolor_003E5__6 = Colors.Black;
					_003C_003E4__this.StatusBarColor = _003Ccolor_003E5__6;
					_003Ccolor_003E5__6 = null;
				}
				else
				{
					_003C_003E4__this.StatusBarColor = Colors.Black;
				}
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CspiritReadModel_003E5__1 = null;
				_003Cvm_003E5__2 = null;
				_003CacquiredId_003E5__3 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CspiritReadModel_003E5__1 = null;
			_003Cvm_003E5__2 = null;
			_003CacquiredId_003E5__3 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003COpenGearSelection_003Ed__39 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritDetailsViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private InsufficientFundsResult _003Cresult_003E5__3;

		private InsufficientFundsResult _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<InsufficientFundsResult> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01db: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_020f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0214: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 2u || (_003C_003E4__this.CanPerformActions && _003C_003E4__this.SpiritCardModel?.Model != null))
				{
					try
					{
						TaskAwaiter awaiter;
						if ((uint)num > 1u)
						{
							if (num == 2)
							{
								awaiter = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_022b;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter awaiter2;
							TaskAwaiter<InsufficientFundsResult> awaiter3;
							if (num != 0)
							{
								if (num == 1)
								{
									awaiter2 = _003C_003Eu__2;
									_003C_003Eu__2 = default(TaskAwaiter);
									num = (_003C_003E1__state = -1);
									goto IL_017a;
								}
								_003C_003E4__this.IsLoading = true;
								awaiter3 = _003C_003E4__this._spiritActionService.EditGearsAsync(_003C_003E4__this.SpiritCardModel.Model).GetAwaiter();
								if (!awaiter3.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter3;
									_003COpenGearSelection_003Ed__39 _003COpenGearSelection_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<InsufficientFundsResult>, _003COpenGearSelection_003Ed__39>(ref awaiter3, ref _003COpenGearSelection_003Ed__);
									return;
								}
							}
							else
							{
								awaiter3 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<InsufficientFundsResult>);
								num = (_003C_003E1__state = -1);
							}
							_003C_003Es__4 = awaiter3.GetResult();
							_003Cresult_003E5__3 = _003C_003Es__4;
							if (_003Cresult_003E5__3 == InsufficientFundsResult.Shop)
							{
								awaiter2 = _003C_003E4__this.HandleGoToShopAsync().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter2;
									_003COpenGearSelection_003Ed__39 _003COpenGearSelection_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenGearSelection_003Ed__39>(ref awaiter2, ref _003COpenGearSelection_003Ed__);
									return;
								}
								goto IL_017a;
							}
							goto end_IL_005f;
							IL_017a:
							((TaskAwaiter)(ref awaiter2)).GetResult();
							end_IL_005f:;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
						}
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_0258;
						}
						_003Cex_003E5__5 = (global::System.Exception)_003C_003Es__1;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to open gear selection.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter;
							_003COpenGearSelection_003Ed__39 _003COpenGearSelection_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenGearSelection_003Ed__39>(ref awaiter, ref _003COpenGearSelection_003Ed__);
							return;
						}
						goto IL_022b;
						IL_022b:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine("OpenGearSelection error: " + _003Cex_003E5__5.Message);
						_003Cex_003E5__5 = null;
						goto IL_0258;
						IL_0258:
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
	private sealed class _003COpenItemSelection_003Ed__41 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritDetailsViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private string _003CsheetId_003E5__3;

		private GetEquippableItemsUseCase _003CgetEquippableItemsUseCase_003E5__4;

		private HeldItemBottomSheet _003Csheet_003E5__5;

		private HeldItemSheetViewModel _003Cvm_003E5__6;

		private HeldItemResult _003Cresult_003E5__7;

		private HeldItemResult _003C_003Es__8;

		private global::System.Exception _003Cex_003E5__9;

		private TaskAwaiter<HeldItemResult> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0418: Unknown result type (might be due to invalid IL or missing references)
			//IL_041d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0432: Unknown result type (might be due to invalid IL or missing references)
			//IL_0434: Unknown result type (might be due to invalid IL or missing references)
			//IL_0452: Unknown result type (might be due to invalid IL or missing references)
			//IL_0457: Unknown result type (might be due to invalid IL or missing references)
			//IL_045f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0279: Unknown result type (might be due to invalid IL or missing references)
			//IL_027e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0286: Unknown result type (might be due to invalid IL or missing references)
			//IL_0313: Unknown result type (might be due to invalid IL or missing references)
			//IL_0318: Unknown result type (might be due to invalid IL or missing references)
			//IL_0320: Unknown result type (might be due to invalid IL or missing references)
			//IL_037c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0381: Unknown result type (might be due to invalid IL or missing references)
			//IL_0389: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0342: Unknown result type (might be due to invalid IL or missing references)
			//IL_0347: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Expected O, but got Unknown
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_035c: Unknown result type (might be due to invalid IL or missing references)
			//IL_035e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_023f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0244: Unknown result type (might be due to invalid IL or missing references)
			//IL_0259: Unknown result type (might be due to invalid IL or missing references)
			//IL_025b: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02de: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 4u || (_003C_003E4__this.CanPerformActions && _003C_003E4__this.SpiritCardModel?.Model != null))
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
								goto IL_046e;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter<HeldItemResult> awaiter5;
							TaskAwaiter awaiter4;
							TaskAwaiter awaiter3;
							TaskAwaiter awaiter2;
							switch (num)
							{
							default:
							{
								_003C_003E4__this.IsLoading = true;
								Guid val = Guid.NewGuid();
								_003CsheetId_003E5__3 = ((object)(Guid)(ref val)).ToString();
								_003CgetEquippableItemsUseCase_003E5__4 = ServiceProviderServiceExtensions.GetRequiredService<GetEquippableItemsUseCase>(_003C_003E4__this._serviceProvider);
								_003Csheet_003E5__5 = new HeldItemBottomSheet(_003C_003E4__this._bottomSheetService);
								_003Cvm_003E5__6 = new HeldItemSheetViewModel(_003C_003E4__this.SpiritCardModel.Model, _003CsheetId_003E5__3, _003C_003E4__this._bottomSheetService, _003C_003E4__this._navigationService, _003CgetEquippableItemsUseCase_003E5__4, _003C_003E4__this.SpiritCardModel.HeldItem);
								((BindableObject)_003Csheet_003E5__5).BindingContext = _003Cvm_003E5__6;
								if (_003Cvm_003E5__6 != null)
								{
									_003Cvm_003E5__6.SetSheet((BottomSheet)(object)_003Csheet_003E5__5);
								}
								HeldItemBottomSheet heldItemBottomSheet = _003Csheet_003E5__5;
								List<Detent> obj = new List<Detent>(1);
								obj.Add((Detent)new FullscreenDetent());
								((BottomSheet)heldItemBottomSheet).Detents = (global::System.Collections.Generic.IList<Detent>)obj;
								awaiter5 = _003C_003E4__this._bottomSheetService.ShowSheetAsync<HeldItemResult>((BottomSheet)(object)_003Csheet_003E5__5, _003CsheetId_003E5__3).GetAwaiter();
								if (!awaiter5.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter5;
									_003COpenItemSelection_003Ed__41 _003COpenItemSelection_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<HeldItemResult>, _003COpenItemSelection_003Ed__41>(ref awaiter5, ref _003COpenItemSelection_003Ed__);
									return;
								}
								goto IL_01ec;
							}
							case 0:
								awaiter5 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<HeldItemResult>);
								num = (_003C_003E1__state = -1);
								goto IL_01ec;
							case 1:
								awaiter4 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0295;
							case 2:
								awaiter3 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_032f;
							case 3:
								{
									awaiter2 = _003C_003Eu__2;
									_003C_003Eu__2 = default(TaskAwaiter);
									num = (_003C_003E1__state = -1);
									goto IL_0398;
								}
								IL_032f:
								((TaskAwaiter)(ref awaiter3)).GetResult();
								awaiter2 = _003C_003E4__this.HandleGoToShopAsync().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 3);
									_003C_003Eu__2 = awaiter2;
									_003COpenItemSelection_003Ed__41 _003COpenItemSelection_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenItemSelection_003Ed__41>(ref awaiter2, ref _003COpenItemSelection_003Ed__);
									return;
								}
								goto IL_0398;
								IL_0295:
								((TaskAwaiter)(ref awaiter4)).GetResult();
								break;
								IL_0398:
								((TaskAwaiter)(ref awaiter2)).GetResult();
								break;
								IL_01ec:
								_003C_003Es__8 = awaiter5.GetResult();
								_003Cresult_003E5__7 = _003C_003Es__8;
								_003C_003Es__8 = null;
								if (_003Cresult_003E5__7 != null && _003Cresult_003E5__7.Success)
								{
									awaiter4 = _003C_003E4__this.UpdateHeldItemAsync(_003Cresult_003E5__7.NewItemId).GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
									{
										num = (_003C_003E1__state = 1);
										_003C_003Eu__2 = awaiter4;
										_003COpenItemSelection_003Ed__41 _003COpenItemSelection_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenItemSelection_003Ed__41>(ref awaiter4, ref _003COpenItemSelection_003Ed__);
										return;
									}
									goto IL_0295;
								}
								if (!(_003Cresult_003E5__7?.NewItemId == "SHOP"))
								{
									break;
								}
								awaiter3 = _003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__2 = awaiter3;
									_003COpenItemSelection_003Ed__41 _003COpenItemSelection_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenItemSelection_003Ed__41>(ref awaiter3, ref _003COpenItemSelection_003Ed__);
									return;
								}
								goto IL_032f;
							}
							_003CsheetId_003E5__3 = null;
							_003CgetEquippableItemsUseCase_003E5__4 = null;
							_003Csheet_003E5__5 = null;
							_003Cvm_003E5__6 = null;
							_003Cresult_003E5__7 = null;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
						}
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_04b9;
						}
						_003Cex_003E5__9 = (global::System.Exception)_003C_003Es__1;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to open item selection.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 4);
							_003C_003Eu__2 = awaiter;
							_003COpenItemSelection_003Ed__41 _003COpenItemSelection_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenItemSelection_003Ed__41>(ref awaiter, ref _003COpenItemSelection_003Ed__);
							return;
						}
						goto IL_046e;
						IL_046e:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine("Item selection error: " + _003Cex_003E5__9.Message);
						Console.WriteLine(_003Cex_003E5__9.StackTrace);
						_003C_003E4__this.IsLoading = false;
						_003Cex_003E5__9 = null;
						goto IL_04b9;
						IL_04b9:
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
	private sealed class _003COpenTalentSelection_003Ed__40 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritDetailsViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private InsufficientFundsResult _003Cresult_003E5__3;

		private InsufficientFundsResult _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<InsufficientFundsResult> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01db: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_020f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0214: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 2u || (_003C_003E4__this.CanPerformActions && _003C_003E4__this.SpiritCardModel?.Model != null))
				{
					try
					{
						TaskAwaiter awaiter;
						if ((uint)num > 1u)
						{
							if (num == 2)
							{
								awaiter = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_022b;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter awaiter2;
							TaskAwaiter<InsufficientFundsResult> awaiter3;
							if (num != 0)
							{
								if (num == 1)
								{
									awaiter2 = _003C_003Eu__2;
									_003C_003Eu__2 = default(TaskAwaiter);
									num = (_003C_003E1__state = -1);
									goto IL_017a;
								}
								_003C_003E4__this.IsLoading = true;
								awaiter3 = _003C_003E4__this._spiritActionService.EditTalentsAsync(_003C_003E4__this.SpiritCardModel.Model).GetAwaiter();
								if (!awaiter3.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter3;
									_003COpenTalentSelection_003Ed__40 _003COpenTalentSelection_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<InsufficientFundsResult>, _003COpenTalentSelection_003Ed__40>(ref awaiter3, ref _003COpenTalentSelection_003Ed__);
									return;
								}
							}
							else
							{
								awaiter3 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<InsufficientFundsResult>);
								num = (_003C_003E1__state = -1);
							}
							_003C_003Es__4 = awaiter3.GetResult();
							_003Cresult_003E5__3 = _003C_003Es__4;
							if (_003Cresult_003E5__3 == InsufficientFundsResult.Shop)
							{
								awaiter2 = _003C_003E4__this.HandleGoToShopAsync().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter2;
									_003COpenTalentSelection_003Ed__40 _003COpenTalentSelection_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenTalentSelection_003Ed__40>(ref awaiter2, ref _003COpenTalentSelection_003Ed__);
									return;
								}
								goto IL_017a;
							}
							goto end_IL_005f;
							IL_017a:
							((TaskAwaiter)(ref awaiter2)).GetResult();
							end_IL_005f:;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
						}
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_0258;
						}
						_003Cex_003E5__5 = (global::System.Exception)_003C_003Es__1;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to open talent selection.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter;
							_003COpenTalentSelection_003Ed__40 _003COpenTalentSelection_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenTalentSelection_003Ed__40>(ref awaiter, ref _003COpenTalentSelection_003Ed__);
							return;
						}
						goto IL_022b;
						IL_022b:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine("OpenTalentSelection error: " + _003Cex_003E5__5.Message);
						_003Cex_003E5__5 = null;
						goto IL_0258;
						IL_0258:
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
	private sealed class _003CSellSpirit_003Ed__45 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritDetailsViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private _003C_003Ec__DisplayClass45_0 _003C_003E8__3;

		private PlayerSpirit _003CspiritReadModel_003E5__4;

		private int _003CgoldReward_003E5__5;

		private string _003CdisplayName_003E5__6;

		private bool _003Cconfirmed_003E5__7;

		private SellSpiritRequest _003Crequest_003E5__8;

		private Result<SellSpiritResponse> _003Cresult_003E5__9;

		private bool _003C_003Es__10;

		private Result<SellSpiritResponse> _003C_003Es__11;

		private global::System.Exception _003Cex_003E5__12;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter<Result<SellSpiritResponse>> _003C_003Eu__2;

		private TaskAwaiter _003C_003Eu__3;

		private TaskAwaiter<object?> _003C_003Eu__4;

		private void MoveNext()
		{
			//IL_05a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_05a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_05be: Unknown result type (might be due to invalid IL or missing references)
			//IL_05c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_05de: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_05eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_035f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0364: Unknown result type (might be due to invalid IL or missing references)
			//IL_036c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0452: Unknown result type (might be due to invalid IL or missing references)
			//IL_0457: Unknown result type (might be due to invalid IL or missing references)
			//IL_045f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0508: Unknown result type (might be due to invalid IL or missing references)
			//IL_050d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0515: Unknown result type (might be due to invalid IL or missing references)
			//IL_026e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0273: Unknown result type (might be due to invalid IL or missing references)
			//IL_0288: Unknown result type (might be due to invalid IL or missing references)
			//IL_028a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0325: Unknown result type (might be due to invalid IL or missing references)
			//IL_032a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01af: Unknown result type (might be due to invalid IL or missing references)
			//IL_033f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0341: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_0418: Unknown result type (might be due to invalid IL or missing references)
			//IL_041d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0432: Unknown result type (might be due to invalid IL or missing references)
			//IL_0434: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 4u)
				{
					goto IL_004a;
				}
				TaskAwaiter awaiter;
				if (num == 5)
				{
					awaiter = _003C_003Eu__3;
					_003C_003Eu__3 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_05fa;
				}
				if (_003C_003E4__this.CanPerformActions && _003C_003E4__this.SpiritCardModel != null)
				{
					_003C_003Es__2 = 0;
					goto IL_004a;
				}
				goto end_IL_0007;
				IL_05fa:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine("SellSpirit error: " + _003Cex_003E5__12.Message);
				Console.WriteLine(_003Cex_003E5__12.StackTrace);
				_003C_003E4__this.IsLoading = false;
				_003Cex_003E5__12 = null;
				goto IL_0645;
				IL_0566:
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_0645;
				}
				_003Cex_003E5__12 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to sell spirit").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 5);
					_003C_003Eu__3 = awaiter;
					_003CSellSpirit_003Ed__45 _003CSellSpirit_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSellSpirit_003Ed__45>(ref awaiter, ref _003CSellSpirit_003Ed__);
					return;
				}
				goto IL_05fa;
				IL_004a:
				try
				{
					TaskAwaiter<bool> awaiter6;
					TaskAwaiter<Result<SellSpiritResponse>> awaiter5;
					TaskAwaiter awaiter4;
					TaskAwaiter awaiter3;
					TaskAwaiter<object> awaiter2;
					switch (num)
					{
					default:
						_003C_003E8__3 = new _003C_003Ec__DisplayClass45_0();
						_003C_003E4__this.IsLoading = true;
						_003CspiritReadModel_003E5__4 = _003C_003E4__this._playerStateService.GetPlayerSpirit(_003C_003E4__this.SpiritId);
						if (_003CspiritReadModel_003E5__4 != null)
						{
							_003CgoldReward_003E5__5 = _003CspiritReadModel_003E5__4.Level * 20;
							_003CdisplayName_003E5__6 = ((!string.IsNullOrEmpty(_003CspiritReadModel_003E5__4.Nickname)) ? _003CspiritReadModel_003E5__4.Nickname : (_003C_003E4__this.SpiritCardModel?.Model.Name ?? "Spirit"));
							awaiter6 = _003C_003E4__this._navigationService.ShowConfirmationAsync("Sell Spirit?", $"Sell {_003CdisplayName_003E5__6} for {_003CgoldReward_003E5__5} G?").GetAwaiter();
							if (!awaiter6.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter6;
								_003CSellSpirit_003Ed__45 _003CSellSpirit_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CSellSpirit_003Ed__45>(ref awaiter6, ref _003CSellSpirit_003Ed__);
								return;
							}
							goto IL_01fd;
						}
						_003C_003E4__this.IsLoading = false;
						goto end_IL_004a;
					case 0:
						awaiter6 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_01fd;
					case 1:
						awaiter5 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<Result<SellSpiritResponse>>);
						num = (_003C_003E1__state = -1);
						goto IL_02c4;
					case 2:
						awaiter4 = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_037b;
					case 3:
						awaiter3 = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_046e;
					case 4:
						{
							awaiter2 = _003C_003Eu__4;
							_003C_003Eu__4 = default(TaskAwaiter<object>);
							num = (_003C_003E1__state = -1);
							goto IL_0524;
						}
						IL_01fd:
						_003C_003Es__10 = awaiter6.GetResult();
						_003Cconfirmed_003E5__7 = _003C_003Es__10;
						if (_003Cconfirmed_003E5__7)
						{
							_003Crequest_003E5__8 = new SellSpiritRequest(_003C_003E4__this.SpiritCardModel.Model.PlayerSpiritId);
							awaiter5 = _003C_003E4__this._sellSpiritUseCase.ExecuteAsync(_003Crequest_003E5__8).GetAwaiter();
							if (!awaiter5.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter5;
								_003CSellSpirit_003Ed__45 _003CSellSpirit_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<SellSpiritResponse>>, _003CSellSpirit_003Ed__45>(ref awaiter5, ref _003CSellSpirit_003Ed__);
								return;
							}
							goto IL_02c4;
						}
						_003C_003E4__this.IsLoading = false;
						goto end_IL_004a;
						IL_037b:
						((TaskAwaiter)(ref awaiter4)).GetResult();
						_003C_003E4__this.IsLoading = false;
						goto end_IL_004a;
						IL_02c4:
						_003C_003Es__11 = awaiter5.GetResult();
						_003Cresult_003E5__9 = _003C_003Es__11;
						_003C_003Es__11 = null;
						if (!_003Cresult_003E5__9.Success)
						{
							awaiter4 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__9.ErrorMessage ?? "Failed to sell spirit").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter4;
								_003CSellSpirit_003Ed__45 _003CSellSpirit_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSellSpirit_003Ed__45>(ref awaiter4, ref _003CSellSpirit_003Ed__);
								return;
							}
							goto IL_037b;
						}
						_003C_003E8__3.orbDropped = _003Cresult_003E5__9.Data?.OrbDropped;
						_003C_003E8__3.orbQty = _003Cresult_003E5__9.Data?.OrbQuantity ?? 0;
						_003C_003E4__this.SpiritCardModel?.Model?.Dispose();
						_003C_003E4__this.SpiritCardModel = null;
						awaiter3 = _003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__3 = awaiter3;
							_003CSellSpirit_003Ed__45 _003CSellSpirit_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSellSpirit_003Ed__45>(ref awaiter3, ref _003CSellSpirit_003Ed__);
							return;
						}
						goto IL_046e;
						IL_046e:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						if (string.IsNullOrEmpty(_003C_003E8__3.orbDropped) || _003C_003E8__3.orbQty <= 0)
						{
							break;
						}
						awaiter2 = _003C_003E4__this._popupService.ShowPopupAsync<SpiritOrbDropPopupViewModel>((Action<SpiritOrbDropPopupViewModel>)delegate(SpiritOrbDropPopupViewModel vm)
						{
							vm.CompletedText = "Found " + _003C_003E8__3.orbDropped + "!";
							vm.CompletedText2 = "Spirit Orbs can be used in shop to evolve spirits in your collection";
							vm.OrbCount = _003C_003E8__3.orbQty;
							vm.OrbCountText = $"x{_003C_003E8__3.orbQty}";
						}, default(CancellationToken)).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 4);
							_003C_003Eu__4 = awaiter2;
							_003CSellSpirit_003Ed__45 _003CSellSpirit_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CSellSpirit_003Ed__45>(ref awaiter2, ref _003CSellSpirit_003Ed__);
							return;
						}
						goto IL_0524;
						IL_0524:
						awaiter2.GetResult();
						break;
					}
					_003C_003E8__3 = null;
					_003CspiritReadModel_003E5__4 = null;
					_003CdisplayName_003E5__6 = null;
					_003Crequest_003E5__8 = null;
					_003Cresult_003E5__9 = null;
					goto IL_0566;
					end_IL_004a:;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
					goto IL_0566;
				}
				goto end_IL_0007;
				IL_0645:
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
	private sealed class _003CSpiritsMore_003Ed__43 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritDetailsViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private string _003CsheetId_003E5__3;

		private SpiritsMoreBottomSheet _003Csheet_003E5__4;

		private SpiritsMoreSheetViewModel _003Cvm_003E5__5;

		private SpiritsMoreResult _003Cresult_003E5__6;

		private SpiritsMoreResult _003C_003Es__7;

		private SpiritsMoreResult _003C_003Es__8;

		private global::System.Exception _003Cex_003E5__9;

		private TaskAwaiter<SpiritsMoreResult> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_022e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0233: Unknown result type (might be due to invalid IL or missing references)
			//IL_023b: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0327: Unknown result type (might be due to invalid IL or missing references)
			//IL_032c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0334: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0152: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_026f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0274: Unknown result type (might be due to invalid IL or missing references)
			//IL_0307: Unknown result type (might be due to invalid IL or missing references)
			//IL_0309: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0210: Unknown result type (might be due to invalid IL or missing references)
			//IL_0289: Unknown result type (might be due to invalid IL or missing references)
			//IL_028b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 4u || (_003C_003E4__this.CanPerformActions && _003C_003E4__this.SpiritCardModel != null))
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
								goto IL_040c;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter<SpiritsMoreResult> awaiter5;
							TaskAwaiter awaiter4;
							TaskAwaiter awaiter3;
							TaskAwaiter awaiter2;
							SpiritsMoreResult spiritsMoreResult;
							switch (num)
							{
							default:
							{
								_003C_003E4__this.IsLoading = true;
								Guid val = Guid.NewGuid();
								_003CsheetId_003E5__3 = ((object)(Guid)(ref val)).ToString();
								_003Csheet_003E5__4 = new SpiritsMoreBottomSheet(_003C_003E4__this._bottomSheetService);
								_003Cvm_003E5__5 = new SpiritsMoreSheetViewModel(_003C_003E4__this._bottomSheetService, _003C_003E4__this._navigationService, _003CsheetId_003E5__3, _003C_003E4__this.SpiritCardModel.Model.IsFavorite);
								((BindableObject)_003Csheet_003E5__4).BindingContext = _003Cvm_003E5__5;
								_003Cvm_003E5__5.SetSheet((BottomSheet)(object)_003Csheet_003E5__4);
								awaiter5 = _003C_003E4__this._bottomSheetService.ShowSheetAsync<SpiritsMoreResult>((BottomSheet)(object)_003Csheet_003E5__4, _003CsheetId_003E5__3).GetAwaiter();
								if (!awaiter5.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter5;
									_003CSpiritsMore_003Ed__43 _003CSpiritsMore_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<SpiritsMoreResult>, _003CSpiritsMore_003Ed__43>(ref awaiter5, ref _003CSpiritsMore_003Ed__);
									return;
								}
								goto IL_018b;
							}
							case 0:
								awaiter5 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<SpiritsMoreResult>);
								num = (_003C_003E1__state = -1);
								goto IL_018b;
							case 1:
								awaiter4 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_024a;
							case 2:
								awaiter3 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_02c5;
							case 3:
								{
									awaiter2 = _003C_003Eu__2;
									_003C_003Eu__2 = default(TaskAwaiter);
									num = (_003C_003E1__state = -1);
									goto IL_0343;
								}
								IL_024a:
								((TaskAwaiter)(ref awaiter4)).GetResult();
								break;
								IL_018b:
								_003C_003Es__7 = awaiter5.GetResult();
								_003Cresult_003E5__6 = _003C_003Es__7;
								spiritsMoreResult = _003Cresult_003E5__6;
								_003C_003Es__8 = spiritsMoreResult;
								switch (_003C_003Es__8)
								{
								case SpiritsMoreResult.EditName:
									break;
								case SpiritsMoreResult.Favorite:
									goto IL_0257;
								case SpiritsMoreResult.Sell:
									goto IL_02cf;
								default:
									goto end_IL_0054;
								}
								_003C_003E4__this.IsLoading = false;
								awaiter4 = _003C_003E4__this.ToggleEditCommand.ExecuteAsync((object)null).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter4;
									_003CSpiritsMore_003Ed__43 _003CSpiritsMore_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSpiritsMore_003Ed__43>(ref awaiter4, ref _003CSpiritsMore_003Ed__);
									return;
								}
								goto IL_024a;
								IL_02cf:
								_003C_003E4__this.IsLoading = false;
								awaiter2 = _003C_003E4__this.SellSpiritCommand.ExecuteAsync((object)null).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 3);
									_003C_003Eu__2 = awaiter2;
									_003CSpiritsMore_003Ed__43 _003CSpiritsMore_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSpiritsMore_003Ed__43>(ref awaiter2, ref _003CSpiritsMore_003Ed__);
									return;
								}
								goto IL_0343;
								IL_02c5:
								((TaskAwaiter)(ref awaiter3)).GetResult();
								break;
								IL_0343:
								((TaskAwaiter)(ref awaiter2)).GetResult();
								break;
								IL_0257:
								_003C_003E4__this.IsLoading = false;
								awaiter3 = _003C_003E4__this.ToggleFavoriteAsync().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__2 = awaiter3;
									_003CSpiritsMore_003Ed__43 _003CSpiritsMore_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSpiritsMore_003Ed__43>(ref awaiter3, ref _003CSpiritsMore_003Ed__);
									return;
								}
								goto IL_02c5;
								end_IL_0054:
								break;
							}
							_003CsheetId_003E5__3 = null;
							_003Csheet_003E5__4 = null;
							_003Cvm_003E5__5 = null;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
						}
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_044d;
						}
						_003Cex_003E5__9 = (global::System.Exception)_003C_003Es__1;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to show options menu.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 4);
							_003C_003Eu__2 = awaiter;
							_003CSpiritsMore_003Ed__43 _003CSpiritsMore_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSpiritsMore_003Ed__43>(ref awaiter, ref _003CSpiritsMore_003Ed__);
							return;
						}
						goto IL_040c;
						IL_040c:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine(_003Cex_003E5__9.Message);
						Console.WriteLine(_003Cex_003E5__9.StackTrace);
						_003C_003E4__this.IsLoading = false;
						_003Cex_003E5__9 = null;
						goto IL_044d;
						IL_044d:
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
	private sealed class _003CToggleEdit_003Ed__46 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritDetailsViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private string _003CcurrentNickname_003E5__3;

		private SetSpiritNicknameRequest _003Crequest_003E5__4;

		private Result<SetSpiritNicknameResponse> _003Cresult_003E5__5;

		private Result<SetSpiritNicknameResponse> _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter<Result<SetSpiritNicknameResponse>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_030e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0313: Unknown result type (might be due to invalid IL or missing references)
			//IL_031b: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_0222: Unknown result type (might be due to invalid IL or missing references)
			//IL_0227: Unknown result type (might be due to invalid IL or missing references)
			//IL_022f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_0204: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 2u)
				{
					goto IL_004b;
				}
				if (_003C_003E4__this.CanPerformActions && _003C_003E4__this.SpiritCardModel != null)
				{
					if (_003C_003E4__this.IsEditing)
					{
						goto IL_004b;
					}
					_003C_003E4__this.Nickname = _003C_003E4__this.SpiritCardModel.Model.Nickname ?? _003C_003E4__this.SpiritCardModel.Model.Name;
					goto IL_0406;
				}
				goto end_IL_0007;
				IL_0406:
				_003C_003E4__this.IsEditing = !_003C_003E4__this.IsEditing;
				goto end_IL_0007;
				IL_004b:
				try
				{
					TaskAwaiter awaiter;
					if ((uint)num > 1u)
					{
						if (num == 2)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_032a;
						}
						_003C_003Es__2 = 0;
					}
					try
					{
						TaskAwaiter awaiter2;
						TaskAwaiter<Result<SetSpiritNicknameResponse>> awaiter3;
						if (num != 0)
						{
							if (num == 1)
							{
								awaiter2 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_023e;
							}
							_003C_003E4__this.IsLoading = true;
							_003CcurrentNickname_003E5__3 = _003C_003E4__this.SpiritCardModel.Model.Nickname ?? _003C_003E4__this.SpiritCardModel.Model.Name;
							if (string.IsNullOrWhiteSpace(_003C_003E4__this.Nickname) || !(_003C_003E4__this.Nickname != _003CcurrentNickname_003E5__3))
							{
								goto IL_0279;
							}
							_003Crequest_003E5__4 = new SetSpiritNicknameRequest(_003C_003E4__this.SpiritCardModel.Model.PlayerSpiritId, _003C_003E4__this.Nickname);
							awaiter3 = _003C_003E4__this._setSpiritNicknameUseCase.ExecuteAsync(_003Crequest_003E5__4).GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter3;
								_003CToggleEdit_003Ed__46 _003CToggleEdit_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<SetSpiritNicknameResponse>>, _003CToggleEdit_003Ed__46>(ref awaiter3, ref _003CToggleEdit_003Ed__);
								return;
							}
						}
						else
						{
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<Result<SetSpiritNicknameResponse>>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__6 = awaiter3.GetResult();
						_003Cresult_003E5__5 = _003C_003Es__6;
						_003C_003Es__6 = null;
						if (!_003Cresult_003E5__5.Success)
						{
							awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__5.ErrorMessage ?? "Failed to save nickname").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter2;
								_003CToggleEdit_003Ed__46 _003CToggleEdit_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CToggleEdit_003Ed__46>(ref awaiter2, ref _003CToggleEdit_003Ed__);
								return;
							}
							goto IL_023e;
						}
						_003Crequest_003E5__4 = null;
						_003Cresult_003E5__5 = null;
						goto IL_0279;
						IL_023e:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						_003C_003E4__this.Nickname = _003CcurrentNickname_003E5__3;
						_003C_003E4__this.IsLoading = false;
						goto end_IL_004b;
						IL_0279:
						_003CcurrentNickname_003E5__3 = null;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__1 = ex;
						_003C_003Es__2 = 1;
					}
					int num2 = _003C_003Es__2;
					if (num2 == 1)
					{
						_003Cex_003E5__7 = (global::System.Exception)_003C_003Es__1;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to save nickname").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter;
							_003CToggleEdit_003Ed__46 _003CToggleEdit_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CToggleEdit_003Ed__46>(ref awaiter, ref _003CToggleEdit_003Ed__);
							return;
						}
						goto IL_032a;
					}
					_003C_003Es__1 = null;
					goto IL_0406;
					IL_032a:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003C_003E4__this.Nickname = _003C_003E4__this.SpiritCardModel.Model.Nickname ?? _003C_003E4__this.SpiritCardModel.Model.Name;
					Console.WriteLine("ToggleEdit error: " + _003Cex_003E5__7.Message);
					Console.WriteLine(_003Cex_003E5__7.StackTrace);
					_003C_003E4__this.IsLoading = false;
					end_IL_004b:;
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
	private sealed class _003CToggleFavoriteAsync_003Ed__44 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritDetailsViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private ToggleSpiritFavoriteRequest _003Crequest_003E5__3;

		private Result<ToggleSpiritFavoriteResponse> _003Cresult_003E5__4;

		private Result<ToggleSpiritFavoriteResponse> _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<Result<ToggleSpiritFavoriteResponse>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0211: Unknown result type (might be due to invalid IL or missing references)
			//IL_0226: Unknown result type (might be due to invalid IL or missing references)
			//IL_0228: Unknown result type (might be due to invalid IL or missing references)
			//IL_0245: Unknown result type (might be due to invalid IL or missing references)
			//IL_024a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0252: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 2u || _003C_003E4__this.SpiritCardModel != null)
				{
					try
					{
						TaskAwaiter awaiter;
						if ((uint)num > 1u)
						{
							if (num == 2)
							{
								awaiter = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0261;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter awaiter2;
							TaskAwaiter<Result<ToggleSpiritFavoriteResponse>> awaiter3;
							if (num != 0)
							{
								if (num == 1)
								{
									awaiter2 = _003C_003Eu__2;
									_003C_003Eu__2 = default(TaskAwaiter);
									num = (_003C_003E1__state = -1);
									goto IL_01a1;
								}
								_003C_003E4__this.IsLoading = true;
								_003Crequest_003E5__3 = new ToggleSpiritFavoriteRequest(_003C_003E4__this.SpiritCardModel.Model.PlayerSpiritId);
								awaiter3 = _003C_003E4__this._toggleFavoriteUseCase.ExecuteAsync(_003Crequest_003E5__3).GetAwaiter();
								if (!awaiter3.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter3;
									_003CToggleFavoriteAsync_003Ed__44 _003CToggleFavoriteAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<ToggleSpiritFavoriteResponse>>, _003CToggleFavoriteAsync_003Ed__44>(ref awaiter3, ref _003CToggleFavoriteAsync_003Ed__);
									return;
								}
							}
							else
							{
								awaiter3 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<Result<ToggleSpiritFavoriteResponse>>);
								num = (_003C_003E1__state = -1);
							}
							_003C_003Es__5 = awaiter3.GetResult();
							_003Cresult_003E5__4 = _003C_003Es__5;
							_003C_003Es__5 = null;
							if (!_003Cresult_003E5__4.Success)
							{
								awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__4.ErrorMessage ?? "Failed to toggle favorite status").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter2;
									_003CToggleFavoriteAsync_003Ed__44 _003CToggleFavoriteAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CToggleFavoriteAsync_003Ed__44>(ref awaiter2, ref _003CToggleFavoriteAsync_003Ed__);
									return;
								}
								goto IL_01a1;
							}
							goto IL_01aa;
							IL_01aa:
							_003Crequest_003E5__3 = null;
							_003Cresult_003E5__4 = null;
							goto end_IL_0043;
							IL_01a1:
							((TaskAwaiter)(ref awaiter2)).GetResult();
							goto IL_01aa;
							end_IL_0043:;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
						}
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_028e;
						}
						_003Cex_003E5__6 = (global::System.Exception)_003C_003Es__1;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to toggle favorite status").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter;
							_003CToggleFavoriteAsync_003Ed__44 _003CToggleFavoriteAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CToggleFavoriteAsync_003Ed__44>(ref awaiter, ref _003CToggleFavoriteAsync_003Ed__);
							return;
						}
						goto IL_0261;
						IL_0261:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine("ToggleFavorite error: " + _003Cex_003E5__6.Message);
						_003Cex_003E5__6 = null;
						goto IL_028e;
						IL_028e:
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
	private sealed class _003CTransform_003Ed__35 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritDetailsViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private Spirit _003Ctemplate_003E5__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0245: Unknown result type (might be due to invalid IL or missing references)
			//IL_024a: Unknown result type (might be due to invalid IL or missing references)
			//IL_025f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0261: Unknown result type (might be due to invalid IL or missing references)
			//IL_027f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0284: Unknown result type (might be due to invalid IL or missing references)
			//IL_028c: Unknown result type (might be due to invalid IL or missing references)
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0191: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 2u || (_003C_003E4__this.CanPerformActions && _003C_003E4__this.SpiritCardModel?.Model != null))
				{
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
								goto IL_029b;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter awaiter2;
							if (num == 0)
							{
								awaiter2 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0138;
							}
							TaskAwaiter awaiter3;
							if (num != 1)
							{
								_003C_003E4__this.IsLoading = true;
								_003Ctemplate_003E5__3 = _003C_003E4__this._playerStateService.GetSpiritTemplate(_003C_003E4__this.SpiritCardModel.Model.BaseSpiritId);
								if (_003Ctemplate_003E5__3 == null || _003Ctemplate_003E5__3.Evolution == 0)
								{
									awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Cannot Evolve", "This spirit has no further evolution.").GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
									{
										num = (_003C_003E1__state = 0);
										_003C_003Eu__1 = awaiter2;
										_003CTransform_003Ed__35 _003CTransform_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CTransform_003Ed__35>(ref awaiter2, ref _003CTransform_003Ed__);
										return;
									}
									goto IL_0138;
								}
								_003C_003E4__this.IsLoading = false;
								awaiter3 = _003C_003E4__this._navigationService.NavigateToAsync("//" + _003C_003E4__this._playerStateService.CurrentRoute + "/evolverequirements?spiritID=" + _003C_003E4__this.SpiritId).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__1 = awaiter3;
									_003CTransform_003Ed__35 _003CTransform_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CTransform_003Ed__35>(ref awaiter3, ref _003CTransform_003Ed__);
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
							_003Ctemplate_003E5__3 = null;
							goto end_IL_005f;
							IL_0138:
							((TaskAwaiter)(ref awaiter2)).GetResult();
							goto end_IL_0044;
							end_IL_005f:;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
						}
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_02d9;
						}
						_003Cex_003E5__4 = (global::System.Exception)_003C_003Es__1;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Could not start evolution.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = awaiter;
							_003CTransform_003Ed__35 _003CTransform_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CTransform_003Ed__35>(ref awaiter, ref _003CTransform_003Ed__);
							return;
						}
						goto IL_029b;
						IL_029b:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine("Transform error: " + _003Cex_003E5__4.Message);
						Console.WriteLine(_003Cex_003E5__4.StackTrace);
						_003Cex_003E5__4 = null;
						goto IL_02d9;
						IL_02d9:
						_003C_003Es__1 = null;
						end_IL_0044:;
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
	private sealed class _003CUpdateHeldItemAsync_003Ed__42 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string newItemId;

		public SpiritDetailsViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private EquipItemRequest _003Crequest_003E5__3;

		private Result<EquipItemResponse> _003Cresult_003E5__4;

		private Result<EquipItemResponse> _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<Result<EquipItemResponse>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0237: Unknown result type (might be due to invalid IL or missing references)
			//IL_023c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0251: Unknown result type (might be due to invalid IL or missing references)
			//IL_0253: Unknown result type (might be due to invalid IL or missing references)
			//IL_0271: Unknown result type (might be due to invalid IL or missing references)
			//IL_0276: Unknown result type (might be due to invalid IL or missing references)
			//IL_027e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 2u)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if ((uint)num > 1u)
					{
						if (num == 2)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_028d;
						}
						_003C_003Es__2 = 0;
					}
					try
					{
						TaskAwaiter<Result<EquipItemResponse>> awaiter2;
						if (num == 0)
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<Result<EquipItemResponse>>);
							num = (_003C_003E1__state = -1);
							goto IL_0113;
						}
						TaskAwaiter awaiter3;
						if (num == 1)
						{
							awaiter3 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_01ca;
						}
						if (_003C_003E4__this.SpiritCardModel != null)
						{
							_003C_003E4__this.IsLoading = true;
							_003Crequest_003E5__3 = new EquipItemRequest(_003C_003E4__this.SpiritCardModel.Model.PlayerSpiritId, _003C_003E4__this.SpiritCardModel.Model.BaseSpiritId.ToString(), newItemId, EquipmentType.HeldItem);
							awaiter2 = _003C_003E4__this._equipItemUseCase.ExecuteAsync(_003Crequest_003E5__3).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003CUpdateHeldItemAsync_003Ed__42 _003CUpdateHeldItemAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<EquipItemResponse>>, _003CUpdateHeldItemAsync_003Ed__42>(ref awaiter2, ref _003CUpdateHeldItemAsync_003Ed__);
								return;
							}
							goto IL_0113;
						}
						goto end_IL_002c;
						IL_01ca:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						goto end_IL_002c;
						IL_0113:
						_003C_003Es__5 = awaiter2.GetResult();
						_003Cresult_003E5__4 = _003C_003Es__5;
						_003C_003Es__5 = null;
						if (!_003Cresult_003E5__4.Success)
						{
							awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__4.ErrorMessage ?? "Failed to update held item.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter3;
								_003CUpdateHeldItemAsync_003Ed__42 _003CUpdateHeldItemAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CUpdateHeldItemAsync_003Ed__42>(ref awaiter3, ref _003CUpdateHeldItemAsync_003Ed__);
								return;
							}
							goto IL_01ca;
						}
						_003Crequest_003E5__3 = null;
						_003Cresult_003E5__4 = null;
						goto IL_01fb;
						end_IL_002c:;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__1 = ex;
						_003C_003Es__2 = 1;
						goto IL_01fb;
					}
					goto end_IL_0011;
					IL_01fb:
					int num2 = _003C_003Es__2;
					if (num2 != 1)
					{
						goto IL_02cb;
					}
					_003Cex_003E5__6 = (global::System.Exception)_003C_003Es__1;
					awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to update held item.").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__2 = awaiter;
						_003CUpdateHeldItemAsync_003Ed__42 _003CUpdateHeldItemAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CUpdateHeldItemAsync_003Ed__42>(ref awaiter, ref _003CUpdateHeldItemAsync_003Ed__);
						return;
					}
					goto IL_028d;
					IL_028d:
					((TaskAwaiter)(ref awaiter)).GetResult();
					Console.WriteLine("Update held item error: " + _003Cex_003E5__6.Message);
					Console.WriteLine(_003Cex_003E5__6.StackTrace);
					_003Cex_003E5__6 = null;
					goto IL_02cb;
					IL_02cb:
					_003C_003Es__1 = null;
					end_IL_0011:;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsLoading = false;
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

	private readonly INavigationService _navigationService;

	private readonly IPlayerStateService _playerStateService;

	private readonly ISpiritActionService _spiritActionService;

	private readonly IBottomSheetService _bottomSheetService;

	private readonly SpiritCardModelFactory _modelFactory;

	private readonly NavBarViewModel _navBarViewModel;

	private readonly EquipItemUseCase _equipItemUseCase;

	private readonly ToggleSpiritFavoriteUseCase _toggleFavoriteUseCase;

	private readonly SellSpiritUseCase _sellSpiritUseCase;

	private readonly SetSpiritNicknameUseCase _setSpiritNicknameUseCase;

	private readonly ISpiritBusinessService _spiritBusinessService;

	private readonly LevelUpSpiritUseCase _levelUpUseCase;

	private readonly GetItemByIdUseCase _getItemByIdUseCase;

	private readonly IPopupService _popupService;

	private readonly IServiceProvider _serviceProvider;

	private bool _disposed = false;

	private readonly SemaphoreSlim _loadSemaphore = new SemaphoreSlim(1, 1);

	private string? _acquiredSpiritId;

	[ObservableProperty]
	private Color _statusBarColor;

	[ObservableProperty]
	private string? _spiritId;

	[ObservableProperty]
	[NotifyPropertyChangedFor("HasValidSpirit")]
	[NotifyPropertyChangedFor("CanPerformActions")]
	private SpiritCardViewModel? _spiritCardModel;

	[ObservableProperty]
	private bool _isEditing;

	[ObservableProperty]
	private string _nickname = string.Empty;

	[ObservableProperty]
	private bool _isLoaded = false;

	[ObservableProperty]
	private bool _isLoading = false;

	[ObservableProperty]
	private string _errorMessage = string.Empty;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? closeCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? transformCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? levelUpCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? editMovesCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? openGearSelectionCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? openTalentSelectionCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? openItemSelectionCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? spiritsMoreCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? sellSpiritCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? toggleEditCommand;

	public bool HasValidSpirit => SpiritCardModel != null;

	public bool CanPerformActions => HasValidSpirit && !IsLoading;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Color StatusBarColor
	{
		get
		{
			return _statusBarColor;
		}
		[MemberNotNull("_statusBarColor")]
		set
		{
			if (!EqualityComparer<Color>.Default.Equals(_statusBarColor, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.StatusBarColor);
				_statusBarColor = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.StatusBarColor);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? SpiritId
	{
		get
		{
			return _spiritId;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_spiritId, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SpiritId);
				_spiritId = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SpiritId);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public SpiritCardViewModel? SpiritCardModel
	{
		get
		{
			return _spiritCardModel;
		}
		set
		{
			if (!EqualityComparer<SpiritCardViewModel>.Default.Equals(_spiritCardModel, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SpiritCardModel);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasValidSpirit);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanPerformActions);
				_spiritCardModel = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SpiritCardModel);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasValidSpirit);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanPerformActions);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsEditing
	{
		get
		{
			return _isEditing;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isEditing, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsEditing);
				_isEditing = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsEditing);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Nickname
	{
		get
		{
			return _nickname;
		}
		[MemberNotNull("_nickname")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_nickname, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Nickname);
				_nickname = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Nickname);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsLoaded
	{
		get
		{
			return _isLoaded;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isLoaded, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsLoaded);
				_isLoaded = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsLoaded);
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

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand TransformCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = transformCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)Transform);
				AsyncRelayCommand val2 = val;
				transformCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand LevelUpCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = levelUpCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)LevelUp);
				AsyncRelayCommand val2 = val;
				levelUpCommand = val;
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

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand OpenGearSelectionCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = openGearSelectionCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)OpenGearSelection);
				AsyncRelayCommand val2 = val;
				openGearSelectionCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand OpenTalentSelectionCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = openTalentSelectionCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)OpenTalentSelection);
				AsyncRelayCommand val2 = val;
				openTalentSelectionCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand OpenItemSelectionCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = openItemSelectionCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)OpenItemSelection);
				AsyncRelayCommand val2 = val;
				openItemSelectionCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand SpiritsMoreCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = spiritsMoreCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)SpiritsMore);
				AsyncRelayCommand val2 = val;
				spiritsMoreCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand SellSpiritCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = sellSpiritCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)SellSpirit);
				AsyncRelayCommand val2 = val;
				sellSpiritCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ToggleEditCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = toggleEditCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)ToggleEdit);
				AsyncRelayCommand val2 = val;
				toggleEditCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public SpiritDetailsViewModel(INavigationService navigationService, IPlayerStateService playerStateService, ISpiritActionService spiritActionService, IBottomSheetService bottomSheetService, GetItemByIdUseCase getItemByIdUseCase, SpiritCardModelFactory modelFactory, NavBarViewModel navBarViewModel, EquipItemUseCase equipItemUseCase, ToggleSpiritFavoriteUseCase toggleFavoriteUseCase, SellSpiritUseCase sellSpiritUseCase, SetSpiritNicknameUseCase setSpiritNicknameUseCase, ISpiritBusinessService spiritBusinessService, LevelUpSpiritUseCase levelUpUseCase, IPopupService popupService, IServiceProvider serviceProvider)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		_navigationService = navigationService;
		_playerStateService = playerStateService;
		_spiritActionService = spiritActionService;
		_bottomSheetService = bottomSheetService;
		_getItemByIdUseCase = getItemByIdUseCase;
		_modelFactory = modelFactory;
		_navBarViewModel = navBarViewModel;
		_equipItemUseCase = equipItemUseCase;
		_toggleFavoriteUseCase = toggleFavoriteUseCase;
		_sellSpiritUseCase = sellSpiritUseCase;
		_setSpiritNicknameUseCase = setSpiritNicknameUseCase;
		_spiritBusinessService = spiritBusinessService;
		_levelUpUseCase = levelUpUseCase;
		_popupService = popupService;
		_serviceProvider = serviceProvider;
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__31))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? id)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__31 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__31();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.id = id;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__31>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadSpiritDataAsync_003Ed__32))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadSpiritDataAsync(string spiritId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadSpiritDataAsync_003Ed__32 _003CLoadSpiritDataAsync_003Ed__ = new _003CLoadSpiritDataAsync_003Ed__32();
		_003CLoadSpiritDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadSpiritDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadSpiritDataAsync_003Ed__.spiritId = spiritId;
		_003CLoadSpiritDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadSpiritDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadSpiritDataAsync_003Ed__32>(ref _003CLoadSpiritDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadSpiritDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CClose_003Ed__33))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Close()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CClose_003Ed__33 _003CClose_003Ed__ = new _003CClose_003Ed__33();
		_003CClose_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CClose_003Ed__._003C_003E4__this = this;
		_003CClose_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CClose_003Ed__._003C_003Et__builder)).Start<_003CClose_003Ed__33>(ref _003CClose_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CClose_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CHandleGoToShopAsync_003Ed__34))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task HandleGoToShopAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CHandleGoToShopAsync_003Ed__34 _003CHandleGoToShopAsync_003Ed__ = new _003CHandleGoToShopAsync_003Ed__34();
		_003CHandleGoToShopAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CHandleGoToShopAsync_003Ed__._003C_003E4__this = this;
		_003CHandleGoToShopAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CHandleGoToShopAsync_003Ed__._003C_003Et__builder)).Start<_003CHandleGoToShopAsync_003Ed__34>(ref _003CHandleGoToShopAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CHandleGoToShopAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CTransform_003Ed__35))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Transform()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CTransform_003Ed__35 _003CTransform_003Ed__ = new _003CTransform_003Ed__35();
		_003CTransform_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CTransform_003Ed__._003C_003E4__this = this;
		_003CTransform_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CTransform_003Ed__._003C_003Et__builder)).Start<_003CTransform_003Ed__35>(ref _003CTransform_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CTransform_003Ed__._003C_003Et__builder)).Task;
	}

	public static string ToCompactNumber(long number)
	{
		string[] array = new string[5] { "", "K", "M", "B", "T" };
		double num = number;
		int num2 = 0;
		while (num >= 1000.0 && num2 < array.Length - 1)
		{
			num /= 1000.0;
			num2++;
		}
		return (num % 1.0 == 0.0) ? $"{num:0}{array[num2]}" : $"{num:0.#}{array[num2]}";
	}

	[AsyncStateMachine(typeof(_003CLevelUp_003Ed__37))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task LevelUp()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLevelUp_003Ed__37 _003CLevelUp_003Ed__ = new _003CLevelUp_003Ed__37();
		_003CLevelUp_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLevelUp_003Ed__._003C_003E4__this = this;
		_003CLevelUp_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLevelUp_003Ed__._003C_003Et__builder)).Start<_003CLevelUp_003Ed__37>(ref _003CLevelUp_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLevelUp_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CEditMovesAsync_003Ed__38))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task EditMovesAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CEditMovesAsync_003Ed__38 _003CEditMovesAsync_003Ed__ = new _003CEditMovesAsync_003Ed__38();
		_003CEditMovesAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CEditMovesAsync_003Ed__._003C_003E4__this = this;
		_003CEditMovesAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CEditMovesAsync_003Ed__._003C_003Et__builder)).Start<_003CEditMovesAsync_003Ed__38>(ref _003CEditMovesAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CEditMovesAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003COpenGearSelection_003Ed__39))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task OpenGearSelection()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COpenGearSelection_003Ed__39 _003COpenGearSelection_003Ed__ = new _003COpenGearSelection_003Ed__39();
		_003COpenGearSelection_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003COpenGearSelection_003Ed__._003C_003E4__this = this;
		_003COpenGearSelection_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003COpenGearSelection_003Ed__._003C_003Et__builder)).Start<_003COpenGearSelection_003Ed__39>(ref _003COpenGearSelection_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003COpenGearSelection_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003COpenTalentSelection_003Ed__40))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task OpenTalentSelection()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COpenTalentSelection_003Ed__40 _003COpenTalentSelection_003Ed__ = new _003COpenTalentSelection_003Ed__40();
		_003COpenTalentSelection_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003COpenTalentSelection_003Ed__._003C_003E4__this = this;
		_003COpenTalentSelection_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003COpenTalentSelection_003Ed__._003C_003Et__builder)).Start<_003COpenTalentSelection_003Ed__40>(ref _003COpenTalentSelection_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003COpenTalentSelection_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003COpenItemSelection_003Ed__41))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task OpenItemSelection()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COpenItemSelection_003Ed__41 _003COpenItemSelection_003Ed__ = new _003COpenItemSelection_003Ed__41();
		_003COpenItemSelection_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003COpenItemSelection_003Ed__._003C_003E4__this = this;
		_003COpenItemSelection_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003COpenItemSelection_003Ed__._003C_003Et__builder)).Start<_003COpenItemSelection_003Ed__41>(ref _003COpenItemSelection_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003COpenItemSelection_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CUpdateHeldItemAsync_003Ed__42))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task UpdateHeldItemAsync(string? newItemId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CUpdateHeldItemAsync_003Ed__42 _003CUpdateHeldItemAsync_003Ed__ = new _003CUpdateHeldItemAsync_003Ed__42();
		_003CUpdateHeldItemAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CUpdateHeldItemAsync_003Ed__._003C_003E4__this = this;
		_003CUpdateHeldItemAsync_003Ed__.newItemId = newItemId;
		_003CUpdateHeldItemAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CUpdateHeldItemAsync_003Ed__._003C_003Et__builder)).Start<_003CUpdateHeldItemAsync_003Ed__42>(ref _003CUpdateHeldItemAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CUpdateHeldItemAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSpiritsMore_003Ed__43))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task SpiritsMore()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSpiritsMore_003Ed__43 _003CSpiritsMore_003Ed__ = new _003CSpiritsMore_003Ed__43();
		_003CSpiritsMore_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSpiritsMore_003Ed__._003C_003E4__this = this;
		_003CSpiritsMore_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSpiritsMore_003Ed__._003C_003Et__builder)).Start<_003CSpiritsMore_003Ed__43>(ref _003CSpiritsMore_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSpiritsMore_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CToggleFavoriteAsync_003Ed__44))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ToggleFavoriteAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CToggleFavoriteAsync_003Ed__44 _003CToggleFavoriteAsync_003Ed__ = new _003CToggleFavoriteAsync_003Ed__44();
		_003CToggleFavoriteAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CToggleFavoriteAsync_003Ed__._003C_003E4__this = this;
		_003CToggleFavoriteAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CToggleFavoriteAsync_003Ed__._003C_003Et__builder)).Start<_003CToggleFavoriteAsync_003Ed__44>(ref _003CToggleFavoriteAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CToggleFavoriteAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSellSpirit_003Ed__45))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task SellSpirit()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSellSpirit_003Ed__45 _003CSellSpirit_003Ed__ = new _003CSellSpirit_003Ed__45();
		_003CSellSpirit_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSellSpirit_003Ed__._003C_003E4__this = this;
		_003CSellSpirit_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSellSpirit_003Ed__._003C_003Et__builder)).Start<_003CSellSpirit_003Ed__45>(ref _003CSellSpirit_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSellSpirit_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CToggleEdit_003Ed__46))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task ToggleEdit()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CToggleEdit_003Ed__46 _003CToggleEdit_003Ed__ = new _003CToggleEdit_003Ed__46();
		_003CToggleEdit_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CToggleEdit_003Ed__._003C_003E4__this = this;
		_003CToggleEdit_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CToggleEdit_003Ed__._003C_003Et__builder)).Start<_003CToggleEdit_003Ed__46>(ref _003CToggleEdit_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CToggleEdit_003Ed__._003C_003Et__builder)).Task;
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			SpiritCardModel?.Dispose();
			if (!string.IsNullOrEmpty(_acquiredSpiritId))
			{
				_modelFactory.ReleaseModel(_acquiredSpiritId);
				_acquiredSpiritId = null;
			}
			SemaphoreSlim loadSemaphore = _loadSemaphore;
			if (loadSemaphore != null)
			{
				loadSemaphore.Dispose();
			}
			_disposed = true;
		}
	}
}
