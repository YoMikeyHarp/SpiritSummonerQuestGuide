using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Spirits;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.Popups;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.ViewModels.BottomSheet;

public class AttributesEditViewModel : ObservableObject, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public long goldCost;

		internal void _003CReset_003Eb__0(InsufficientFundsPopupViewModel vm)
		{
			vm.Infotext = $"You need {goldCost} gold to reset stat points.";
			vm.Infotext2 = "Earn more gold by completing quests!";
			vm.Image = "icon_gold_reward.png";
			vm.IsGoToQuestVisible = true;
			vm.IsGoToShopVisible = false;
		}
	}

	[CompilerGenerated]
	private sealed class _003CCancel_003Ed__30 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public AttributesEditViewModel _003C_003E4__this;

		private bool _003CshouldCancel_003E5__1;

		private bool _003C_003Es__2;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				TaskAwaiter<bool> awaiter2;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_012e;
					}
					_003CshouldCancel_003E5__1 = true;
					if (!_003C_003E4__this.HasUnsavedChanges)
					{
						goto IL_00c4;
					}
					awaiter2 = _003C_003E4__this._navigationService.ShowConfirmationAsync("Unsaved Changes", "You have unsaved changes. Are you sure you want to cancel?").GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003CCancel_003Ed__30 _003CCancel_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CCancel_003Ed__30>(ref awaiter2, ref _003CCancel_003Ed__);
						return;
					}
				}
				else
				{
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__2 = awaiter2.GetResult();
				_003CshouldCancel_003E5__1 = _003C_003Es__2;
				goto IL_00c4;
				IL_012e:
				((TaskAwaiter)(ref awaiter)).GetResult();
				goto end_IL_0007;
				IL_00c4:
				if (_003CshouldCancel_003E5__1)
				{
					awaiter = _003C_003E4__this.DismissSheet().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter;
						_003CCancel_003Ed__30 _003CCancel_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCancel_003Ed__30>(ref awaiter, ref _003CCancel_003Ed__);
						return;
					}
					goto IL_012e;
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
	private sealed class _003CConfirm_003Ed__27 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public AttributesEditViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private AssignStatPointsRequest _003Crequest_003E5__3;

		private Result<AssignStatPointsResponse> _003Cresult_003E5__4;

		private Result<AssignStatPointsResponse> _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<Result<AssignStatPointsResponse>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_037e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0383: Unknown result type (might be due to invalid IL or missing references)
			//IL_0398: Unknown result type (might be due to invalid IL or missing references)
			//IL_039a: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0270: Unknown result type (might be due to invalid IL or missing references)
			//IL_0275: Unknown result type (might be due to invalid IL or missing references)
			//IL_027d: Unknown result type (might be due to invalid IL or missing references)
			//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_019e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02be: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0237: Unknown result type (might be due to invalid IL or missing references)
			//IL_023c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0251: Unknown result type (might be due to invalid IL or missing references)
			//IL_0253: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 3u || _003C_003E4__this.CanConfirm)
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
								goto IL_03d0;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter<Result<AssignStatPointsResponse>> awaiter4;
							TaskAwaiter awaiter3;
							TaskAwaiter awaiter2;
							switch (num)
							{
							default:
								_003C_003E4__this.IsProcessing = true;
								_003Crequest_003E5__3 = new AssignStatPointsRequest(_003C_003E4__this._playerSpiritId, _003C_003E4__this.GetCurrentAttributeValue("ATK") - _003C_003E4__this._originalAttributePoints["ATK"], _003C_003E4__this.GetCurrentAttributeValue("DEF") - _003C_003E4__this._originalAttributePoints["DEF"], _003C_003E4__this.GetCurrentAttributeValue("MGK") - _003C_003E4__this._originalAttributePoints["MGK"], _003C_003E4__this.GetCurrentAttributeValue("MDF") - _003C_003E4__this._originalAttributePoints["MDF"], _003C_003E4__this.GetCurrentAttributeValue("SPD") - _003C_003E4__this._originalAttributePoints["SPD"], _003C_003E4__this.GetCurrentAttributeValue("INT") - _003C_003E4__this._originalAttributePoints["INT"]);
								awaiter4 = _003C_003E4__this._assignStatPointsUseCase.ExecuteAsync(_003Crequest_003E5__3).GetAwaiter();
								if (!awaiter4.IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter4;
									_003CConfirm_003Ed__27 _003CConfirm_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<AssignStatPointsResponse>>, _003CConfirm_003Ed__27>(ref awaiter4, ref _003CConfirm_003Ed__);
									return;
								}
								goto IL_01d6;
							case 0:
								awaiter4 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter<Result<AssignStatPointsResponse>>);
								num = (_003C_003E1__state = -1);
								goto IL_01d6;
							case 1:
								awaiter3 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_028c;
							case 2:
								{
									awaiter2 = _003C_003Eu__2;
									_003C_003Eu__2 = default(TaskAwaiter);
									num = (_003C_003E1__state = -1);
									break;
								}
								IL_028c:
								((TaskAwaiter)(ref awaiter3)).GetResult();
								goto end_IL_0028;
								IL_01d6:
								_003C_003Es__5 = awaiter4.GetResult();
								_003Cresult_003E5__4 = _003C_003Es__5;
								_003C_003Es__5 = null;
								if (!_003Cresult_003E5__4.Success)
								{
									awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Update Failed", _003Cresult_003E5__4.ErrorMessage ?? "Failed to save attribute changes. Please try again.").GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
									{
										num = (_003C_003E1__state = 1);
										_003C_003Eu__2 = awaiter3;
										_003CConfirm_003Ed__27 _003CConfirm_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirm_003Ed__27>(ref awaiter3, ref _003CConfirm_003Ed__);
										return;
									}
									goto IL_028c;
								}
								awaiter2 = _003C_003E4__this.DismissSheet().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__2 = awaiter2;
									_003CConfirm_003Ed__27 _003CConfirm_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirm_003Ed__27>(ref awaiter2, ref _003CConfirm_003Ed__);
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
							goto IL_03e2;
						}
						_003Cex_003E5__6 = (global::System.Exception)_003C_003Es__1;
						Console.WriteLine("Error confirming attribute changes: " + _003Cex_003E5__6.Message);
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "An unexpected error occurred while saving changes.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__2 = awaiter;
							_003CConfirm_003Ed__27 _003CConfirm_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirm_003Ed__27>(ref awaiter, ref _003CConfirm_003Ed__);
							return;
						}
						goto IL_03d0;
						IL_03d0:
						((TaskAwaiter)(ref awaiter)).GetResult();
						_003Cex_003E5__6 = null;
						goto IL_03e2;
						IL_03e2:
						_003C_003Es__1 = null;
						end_IL_0028:;
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsProcessing = false;
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
	private sealed class _003CDismissSheet_003Ed__31 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public AttributesEditViewModel _003C_003E4__this;

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
						_003CDismissSheet_003Ed__31 _003CDismissSheet_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CDismissSheet_003Ed__31>(ref awaiter, ref _003CDismissSheet_003Ed__);
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
				_003C_003E4__this.Dispose();
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
	private sealed class _003CReset_003Ed__26 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public AttributesEditViewModel _003C_003E4__this;

		private _003C_003Ec__DisplayClass26_0 _003C_003E8__1;

		private PlayerSpirit _003CplayerSpirit_003E5__2;

		private int _003CtotalAllocated_003E5__3;

		private bool _003Cconfirmed_003E5__4;

		private Result<ResetStatPointsResponse> _003Cresult_003E5__5;

		private bool _003C_003Es__6;

		private Result<ResetStatPointsResponse> _003C_003Es__7;

		private PlayerSpirit _003CupdatedSpirit_003E5__8;

		private Enumerator<string> _003C_003Es__9;

		private string _003Ckey_003E5__10;

		private global::System.Collections.Generic.IEnumerator<AttributeEditable> _003C_003Es__11;

		private AttributeEditable _003Cattribute_003E5__12;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private TaskAwaiter<Result<ResetStatPointsResponse>> _003C_003Eu__3;

		private TaskAwaiter<object?> _003C_003Eu__4;

		private void MoveNext()
		{
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Unknown result type (might be due to invalid IL or missing references)
			//IL_021d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0222: Unknown result type (might be due to invalid IL or missing references)
			//IL_022a: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_04db: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0569: Unknown result type (might be due to invalid IL or missing references)
			//IL_056e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0576: Unknown result type (might be due to invalid IL or missing references)
			//IL_0286: Unknown result type (might be due to invalid IL or missing references)
			//IL_028b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0328: Unknown result type (might be due to invalid IL or missing references)
			//IL_032d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0494: Unknown result type (might be due to invalid IL or missing references)
			//IL_049a: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_052f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0534: Unknown result type (might be due to invalid IL or missing references)
			//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_04bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0549: Unknown result type (might be due to invalid IL or missing references)
			//IL_054b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0390: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter5;
				TaskAwaiter<bool> awaiter4;
				TaskAwaiter<Result<ResetStatPointsResponse>> awaiter3;
				TaskAwaiter<object> awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					_003C_003E8__1 = new _003C_003Ec__DisplayClass26_0();
					_003CplayerSpirit_003E5__2 = _003C_003E4__this._stateService.GetPlayerSpirit(_003C_003E4__this._playerSpiritId);
					if (_003CplayerSpirit_003E5__2 != null)
					{
						_003CtotalAllocated_003E5__3 = _003CplayerSpirit_003E5__2.PointsATK + _003CplayerSpirit_003E5__2.PointsDEF + _003CplayerSpirit_003E5__2.PointsSATK + _003CplayerSpirit_003E5__2.PointsSDEF + _003CplayerSpirit_003E5__2.PointsSPD + _003CplayerSpirit_003E5__2.PointsINT;
						if (_003CtotalAllocated_003E5__3 == 0)
						{
							awaiter5 = _003C_003E4__this._navigationService.ShowAlertAsync("No Points Allocated", "There are no stat points allocated to reset.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter5;
								_003CReset_003Ed__26 _003CReset_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CReset_003Ed__26>(ref awaiter5, ref _003CReset_003Ed__);
								return;
							}
							goto IL_0143;
						}
						_003C_003E8__1.goldCost = (long)_003CplayerSpirit_003E5__2.Level * 50L;
						awaiter4 = _003C_003E4__this._navigationService.ShowConfirmationAsync("Reset Stat Points", $"Reset all allocated stat points for {_003C_003E8__1.goldCost} gold?\n\nAll {_003CtotalAllocated_003E5__3} points will be fully restored.").GetAwaiter();
						if (!awaiter4.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter4;
							_003CReset_003Ed__26 _003CReset_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CReset_003Ed__26>(ref awaiter4, ref _003CReset_003Ed__);
							return;
						}
						goto IL_0239;
					}
					goto end_IL_0007;
				case 0:
					awaiter5 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0143;
				case 1:
					awaiter4 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_0239;
				case 2:
					awaiter3 = _003C_003Eu__3;
					_003C_003Eu__3 = default(TaskAwaiter<Result<ResetStatPointsResponse>>);
					num = (_003C_003E1__state = -1);
					goto IL_02dc;
				case 3:
					awaiter2 = _003C_003Eu__4;
					_003C_003Eu__4 = default(TaskAwaiter<object>);
					num = (_003C_003E1__state = -1);
					goto IL_04f7;
				case 4:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_0239:
					_003C_003Es__6 = awaiter4.GetResult();
					_003Cconfirmed_003E5__4 = _003C_003Es__6;
					if (_003Cconfirmed_003E5__4)
					{
						awaiter3 = _003C_003E4__this._resetStatPointsUseCase.ExecuteAsync(new ResetStatPointsRequest(_003C_003E4__this._playerSpiritId)).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__3 = awaiter3;
							_003CReset_003Ed__26 _003CReset_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<ResetStatPointsResponse>>, _003CReset_003Ed__26>(ref awaiter3, ref _003CReset_003Ed__);
							return;
						}
						goto IL_02dc;
					}
					goto end_IL_0007;
					IL_04f7:
					awaiter2.GetResult();
					goto end_IL_0007;
					IL_02dc:
					_003C_003Es__7 = awaiter3.GetResult();
					_003Cresult_003E5__5 = _003C_003Es__7;
					_003C_003Es__7 = null;
					if (!_003Cresult_003E5__5.Success)
					{
						if (_003Cresult_003E5__5.ErrorMessage == "INSUFFICIENT_GOLD")
						{
							awaiter2 = _003C_003E4__this._popupService.ShowPopupAsync<InsufficientFundsPopupViewModel>((Action<InsufficientFundsPopupViewModel>)delegate(InsufficientFundsPopupViewModel vm)
							{
								vm.Infotext = $"You need {_003C_003E8__1.goldCost} gold to reset stat points.";
								vm.Infotext2 = "Earn more gold by completing quests!";
								vm.Image = "icon_gold_reward.png";
								vm.IsGoToQuestVisible = true;
								vm.IsGoToShopVisible = false;
							}, default(CancellationToken)).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__4 = awaiter2;
								_003CReset_003Ed__26 _003CReset_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CReset_003Ed__26>(ref awaiter2, ref _003CReset_003Ed__);
								return;
							}
							goto IL_04f7;
						}
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Reset Failed", _003Cresult_003E5__5.ErrorMessage ?? "Failed to reset stat points. Please try again.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 4);
							_003C_003Eu__1 = awaiter;
							_003CReset_003Ed__26 _003CReset_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CReset_003Ed__26>(ref awaiter, ref _003CReset_003Ed__);
							return;
						}
						break;
					}
					_003C_003Es__9 = Enumerable.ToList<string>((global::System.Collections.Generic.IEnumerable<string>)_003C_003E4__this._originalAttributePoints.Keys).GetEnumerator();
					try
					{
						while (_003C_003Es__9.MoveNext())
						{
							_003Ckey_003E5__10 = _003C_003Es__9.Current;
							_003C_003E4__this._originalAttributePoints[_003Ckey_003E5__10] = 0;
							_003Ckey_003E5__10 = null;
						}
					}
					finally
					{
						if (num < 0)
						{
							((global::System.IDisposable)_003C_003Es__9).Dispose();
						}
					}
					_003C_003Es__9 = default(Enumerator<string>);
					_003C_003Es__11 = ((Collection<AttributeEditable>)(object)_003C_003E4__this.Attributes).GetEnumerator();
					try
					{
						while (((global::System.Collections.IEnumerator)_003C_003Es__11).MoveNext())
						{
							_003Cattribute_003E5__12 = _003C_003Es__11.Current;
							_003Cattribute_003E5__12.Points = 0;
							_003Cattribute_003E5__12 = null;
						}
					}
					finally
					{
						if (num < 0 && _003C_003Es__11 != null)
						{
							((global::System.IDisposable)_003C_003Es__11).Dispose();
						}
					}
					_003C_003Es__11 = null;
					_003CupdatedSpirit_003E5__8 = _003C_003E4__this._stateService.GetPlayerSpirit(_003C_003E4__this._playerSpiritId);
					if (_003CupdatedSpirit_003E5__8 != null)
					{
						_003C_003E4__this.RemainingTrainingPoints = _003CupdatedSpirit_003E5__8.TrainingPoints;
					}
					_003CupdatedSpirit_003E5__8 = null;
					goto end_IL_0007;
					IL_0143:
					((TaskAwaiter)(ref awaiter5)).GetResult();
					goto end_IL_0007;
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				_003CplayerSpirit_003E5__2 = null;
				_003Cresult_003E5__5 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			_003CplayerSpirit_003E5__2 = null;
			_003Cresult_003E5__5 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IBottomSheetService _bottomSheetService;

	private readonly IPlayerStateService _stateService;

	private readonly INavigationService _navigationService;

	private readonly IPopupService _popupService;

	private readonly AssignStatPointsUseCase _assignStatPointsUseCase;

	private readonly ResetStatPointsUseCase _resetStatPointsUseCase;

	private BottomSheet _sheet;

	private readonly string _playerSpiritId;

	private readonly global::System.Collections.Generic.IReadOnlyList<ItemEffect?> _itemEffects;

	private readonly Dictionary<string, int> _originalAttributePoints;

	[ObservableProperty]
	private ObservableCollection<AttributeEditable> _attributes = new ObservableCollection<AttributeEditable>();

	[ObservableProperty]
	[NotifyPropertyChangedFor("CanConfirm")]
	private bool _hasUnsavedChanges;

	[ObservableProperty]
	[NotifyPropertyChangedFor("CanConfirm")]
	private bool _isProcessing;

	[ObservableProperty]
	private int _remainingTrainingPoints;

	[ObservableProperty]
	private int _currentHP;

	[ObservableProperty]
	private int _currentLevel;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<string>? incrementCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<string>? increment10Command;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? resetCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? confirmCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<string>? decrementCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<string>? decrement10Command;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? cancelCommand;

	public bool CanConfirm => HasUnsavedChanges && !IsProcessing;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<AttributeEditable> Attributes
	{
		get
		{
			return _attributes;
		}
		[MemberNotNull("_attributes")]
		set
		{
			if (!EqualityComparer<ObservableCollection<AttributeEditable>>.Default.Equals(_attributes, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Attributes);
				_attributes = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Attributes);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool HasUnsavedChanges
	{
		get
		{
			return _hasUnsavedChanges;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasUnsavedChanges, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasUnsavedChanges);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanConfirm);
				_hasUnsavedChanges = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasUnsavedChanges);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanConfirm);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsProcessing
	{
		get
		{
			return _isProcessing;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isProcessing, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsProcessing);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanConfirm);
				_isProcessing = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsProcessing);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanConfirm);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int RemainingTrainingPoints
	{
		get
		{
			return _remainingTrainingPoints;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_remainingTrainingPoints, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.RemainingTrainingPoints);
				_remainingTrainingPoints = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.RemainingTrainingPoints);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int CurrentHP
	{
		get
		{
			return _currentHP;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_currentHP, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentHP);
				_currentHP = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentHP);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int CurrentLevel
	{
		get
		{
			return _currentLevel;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_currentLevel, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentLevel);
				_currentLevel = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentLevel);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<string> IncrementCommand => (IRelayCommand<string>)(object)(incrementCommand ?? (incrementCommand = new RelayCommand<string>((Action<string>)Increment)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<string> Increment10Command => (IRelayCommand<string>)(object)(increment10Command ?? (increment10Command = new RelayCommand<string>((Action<string>)Increment10)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ResetCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = resetCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)Reset);
				AsyncRelayCommand val2 = val;
				resetCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ConfirmCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = confirmCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)Confirm);
				AsyncRelayCommand val2 = val;
				confirmCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<string> DecrementCommand => (IRelayCommand<string>)(object)(decrementCommand ?? (decrementCommand = new RelayCommand<string>((Action<string>)Decrement)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<string> Decrement10Command => (IRelayCommand<string>)(object)(decrement10Command ?? (decrement10Command = new RelayCommand<string>((Action<string>)Decrement10)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand CancelCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = cancelCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)Cancel);
				AsyncRelayCommand val2 = val;
				cancelCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public AttributesEditViewModel(string playerSpiritId, global::System.Collections.Generic.IReadOnlyList<ItemEffect?> itemEffects, IBottomSheetService bottomSheetService, IPlayerStateService stateService, INavigationService navigationService, IPopupService popupService, AssignStatPointsUseCase assignStatPointsUseCase, ResetStatPointsUseCase resetStatPointsUseCase)
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		_bottomSheetService = bottomSheetService;
		_stateService = stateService;
		_navigationService = navigationService;
		_popupService = popupService;
		_assignStatPointsUseCase = assignStatPointsUseCase;
		_resetStatPointsUseCase = resetStatPointsUseCase;
		_playerSpiritId = playerSpiritId;
		_itemEffects = itemEffects ?? global::System.Array.Empty<ItemEffect>();
		PlayerSpirit playerSpirit = _stateService.GetPlayerSpirit(_playerSpiritId);
		if (playerSpirit == null)
		{
			throw new ArgumentException("Player spirit with ID " + _playerSpiritId + " not found");
		}
		_originalAttributePoints = new Dictionary<string, int>
		{
			["ATK"] = playerSpirit.PointsATK,
			["DEF"] = playerSpirit.PointsDEF,
			["MGK"] = playerSpirit.PointsSATK,
			["MDF"] = playerSpirit.PointsSDEF,
			["SPD"] = playerSpirit.PointsSPD,
			["INT"] = playerSpirit.PointsINT
		};
		_currentHP = playerSpirit.HP;
		_currentLevel = playerSpirit.Level;
		_remainingTrainingPoints = playerSpirit.TrainingPoints;
		InitializeAttributes();
	}

	private void InitializeAttributes()
	{
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03be: Expected O, but got Unknown
		((Collection<AttributeEditable>)(object)Attributes).Clear();
		PlayerSpirit playerSpirit = _stateService.GetPlayerSpirit(_playerSpiritId);
		if (playerSpirit == null)
		{
			return;
		}
		Spirit spiritTemplate = _stateService.GetSpiritTemplate(playerSpirit.BaseSpiritID);
		if (spiritTemplate == null || spiritTemplate.BaseStats == null)
		{
			return;
		}
		BonusStats bonusStats = spiritTemplate.BonusAttributes ?? new BonusStats();
		Dictionary<string, float> val = new Dictionary<string, float>((IEqualityComparer<string>)(object)StringComparer.OrdinalIgnoreCase);
		Dictionary<string, double> val2 = new Dictionary<string, double>((IEqualityComparer<string>)(object)StringComparer.OrdinalIgnoreCase);
		global::System.Collections.Generic.IEnumerator<ItemEffect> enumerator = ((global::System.Collections.Generic.IEnumerable<ItemEffect>)_itemEffects).GetEnumerator();
		try
		{
			string text = default(string);
			float num = default(float);
			float num3 = default(float);
			double num4 = default(double);
			double num6 = default(double);
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				ItemEffect current = enumerator.Current;
				if (current == null)
				{
					continue;
				}
				if (current.FlatStatChanges != null)
				{
					Enumerator<string, float> enumerator2 = current.FlatStatChanges.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							enumerator2.Current.Deconstruct(ref text, ref num);
							string text2 = text;
							float num2 = num;
							val.TryGetValue(text2, ref num3);
							val[text2] = num3 + num2;
						}
					}
					finally
					{
						((global::System.IDisposable)enumerator2).Dispose();
					}
				}
				if (current.StatMultipliers == null)
				{
					continue;
				}
				Enumerator<string, double> enumerator3 = current.StatMultipliers.GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						enumerator3.Current.Deconstruct(ref text, ref num4);
						string text3 = text;
						double num5 = num4;
						val2.TryGetValue(text3, ref num6);
						val2[text3] = ((num6 == 0.0) ? 1.0 : num6) * num5;
					}
				}
				finally
				{
					((global::System.IDisposable)enumerator3).Dispose();
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
		var array = new[]
		{
			new
			{
				Name = "ATK",
				CanonicalKey = "ATK",
				Base = spiritTemplate.BaseStats.ATK,
				Bonus = bonusStats.ATK,
				Points = playerSpirit.PointsATK,
				Description = "Physical attack power"
			},
			new
			{
				Name = "DEF",
				CanonicalKey = "DEF",
				Base = spiritTemplate.BaseStats.DEF,
				Bonus = bonusStats.DEF,
				Points = playerSpirit.PointsDEF,
				Description = "Physical defense power"
			},
			new
			{
				Name = "MGK",
				CanonicalKey = "SATK",
				Base = spiritTemplate.BaseStats.SATK,
				Bonus = bonusStats.SATK,
				Points = playerSpirit.PointsSATK,
				Description = "Magical attack power"
			},
			new
			{
				Name = "MDF",
				CanonicalKey = "SDEF",
				Base = spiritTemplate.BaseStats.SDEF,
				Bonus = bonusStats.SDEF,
				Points = playerSpirit.PointsSDEF,
				Description = "Magical defense power"
			},
			new
			{
				Name = "SPD",
				CanonicalKey = "SPD",
				Base = spiritTemplate.BaseStats.SPD,
				Bonus = bonusStats.SPD,
				Points = playerSpirit.PointsSPD,
				Description = "Attack order priority"
			},
			new
			{
				Name = "INT",
				CanonicalKey = "INT",
				Base = spiritTemplate.BaseStats.INT,
				Bonus = bonusStats.INT,
				Points = playerSpirit.PointsINT,
				Description = "Intelligence"
			}
		};
		var array2 = array;
		float num7 = default(float);
		double num8 = default(double);
		foreach (var anon in array2)
		{
			val.TryGetValue(anon.Name, ref num7);
			if (num7 == 0f)
			{
				val.TryGetValue(anon.CanonicalKey, ref num7);
			}
			val2.TryGetValue(anon.Name, ref num8);
			if (num8 == 0.0)
			{
				val2.TryGetValue(anon.CanonicalKey, ref num8);
			}
			if (num8 == 0.0)
			{
				num8 = 1.0;
			}
			AttributeEditable attributeEditable = new AttributeEditable(anon.Name, anon.Base, anon.Points, anon.Bonus, anon.Description, num7, num8);
			((ObservableObject)attributeEditable).PropertyChanged += new PropertyChangedEventHandler(OnAttributePropertyChanged);
			((Collection<AttributeEditable>)(object)Attributes).Add(attributeEditable);
		}
	}

	private void OnAttributePropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Points" && sender is AttributeEditable)
		{
			CheckForUnsavedChanges();
		}
	}

	private void CheckForUnsavedChanges()
	{
		HasUnsavedChanges = Enumerable.Any<KeyValuePair<string, int>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, int>>)_originalAttributePoints, (Func<KeyValuePair<string, int>, bool>)([CompilerGenerated] (KeyValuePair<string, int> original) =>
		{
			int currentAttributeValue = GetCurrentAttributeValue(original.Key);
			return original.Value != currentAttributeValue;
		}));
	}

	private int GetCurrentAttributeValue(string attributeName)
	{
		string attributeName2 = attributeName;
		return Enumerable.FirstOrDefault<AttributeEditable>((global::System.Collections.Generic.IEnumerable<AttributeEditable>)Attributes, (Func<AttributeEditable, bool>)((AttributeEditable a) => a.Name == attributeName2))?.Points ?? 0;
	}

	public void SetSheet(BottomSheet sheet)
	{
		_sheet = sheet;
	}

	[RelayCommand]
	public void Increment(string attributeName)
	{
		string attributeName2 = attributeName;
		AttributeEditable attributeEditable = Enumerable.FirstOrDefault<AttributeEditable>((global::System.Collections.Generic.IEnumerable<AttributeEditable>)Attributes, (Func<AttributeEditable, bool>)((AttributeEditable a) => a.Name == attributeName2));
		if (attributeEditable != null && RemainingTrainingPoints >= 1)
		{
			attributeEditable.Points++;
			RemainingTrainingPoints--;
		}
	}

	[RelayCommand]
	public void Increment10(string attributeName)
	{
		for (int i = 0; i < 10; i++)
		{
			if (RemainingTrainingPoints <= 0)
			{
				break;
			}
			Increment(attributeName);
		}
	}

	[AsyncStateMachine(typeof(_003CReset_003Ed__26))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Reset()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CReset_003Ed__26 _003CReset_003Ed__ = new _003CReset_003Ed__26();
		_003CReset_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CReset_003Ed__._003C_003E4__this = this;
		_003CReset_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CReset_003Ed__._003C_003Et__builder)).Start<_003CReset_003Ed__26>(ref _003CReset_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CReset_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CConfirm_003Ed__27))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Confirm()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CConfirm_003Ed__27 _003CConfirm_003Ed__ = new _003CConfirm_003Ed__27();
		_003CConfirm_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CConfirm_003Ed__._003C_003E4__this = this;
		_003CConfirm_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CConfirm_003Ed__._003C_003Et__builder)).Start<_003CConfirm_003Ed__27>(ref _003CConfirm_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CConfirm_003Ed__._003C_003Et__builder)).Task;
	}

	[RelayCommand]
	public void Decrement(string attributeName)
	{
		string attributeName2 = attributeName;
		AttributeEditable attributeEditable = Enumerable.FirstOrDefault<AttributeEditable>((global::System.Collections.Generic.IEnumerable<AttributeEditable>)Attributes, (Func<AttributeEditable, bool>)((AttributeEditable a) => a.Name == attributeName2));
		if (attributeEditable != null)
		{
			int num = _originalAttributePoints[attributeEditable.Name];
			if (attributeEditable.Points > num)
			{
				attributeEditable.Points--;
				RemainingTrainingPoints++;
			}
		}
	}

	[RelayCommand]
	public void Decrement10(string attributeName)
	{
		string attributeName2 = attributeName;
		AttributeEditable attributeEditable = Enumerable.FirstOrDefault<AttributeEditable>((global::System.Collections.Generic.IEnumerable<AttributeEditable>)Attributes, (Func<AttributeEditable, bool>)((AttributeEditable a) => a.Name == attributeName2));
		if (attributeEditable != null)
		{
			int num = _originalAttributePoints[attributeEditable.Name];
			int num2 = attributeEditable.Points - num;
			int num3 = Math.Min(10, num2);
			if (num3 > 0)
			{
				attributeEditable.Points -= num3;
				RemainingTrainingPoints += num3;
			}
		}
	}

	[AsyncStateMachine(typeof(_003CCancel_003Ed__30))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Cancel()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CCancel_003Ed__30 _003CCancel_003Ed__ = new _003CCancel_003Ed__30();
		_003CCancel_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CCancel_003Ed__._003C_003E4__this = this;
		_003CCancel_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CCancel_003Ed__._003C_003Et__builder)).Start<_003CCancel_003Ed__30>(ref _003CCancel_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CCancel_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CDismissSheet_003Ed__31))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task DismissSheet()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CDismissSheet_003Ed__31 _003CDismissSheet_003Ed__ = new _003CDismissSheet_003Ed__31();
		_003CDismissSheet_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CDismissSheet_003Ed__._003C_003E4__this = this;
		_003CDismissSheet_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CDismissSheet_003Ed__._003C_003Et__builder)).Start<_003CDismissSheet_003Ed__31>(ref _003CDismissSheet_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CDismissSheet_003Ed__._003C_003Et__builder)).Task;
	}

	public void Dispose()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		global::System.Collections.Generic.IEnumerator<AttributeEditable> enumerator = ((Collection<AttributeEditable>)(object)Attributes).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				AttributeEditable current = enumerator.Current;
				((ObservableObject)current).PropertyChanged -= new PropertyChangedEventHandler(OnAttributePropertyChanged);
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
		GC.SuppressFinalize((object)this);
	}
}
