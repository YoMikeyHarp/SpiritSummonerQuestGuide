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
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Spirits;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Requirements;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Domain.Enums.Shops;
using SpiritSummoner.Domain.Interfaces.Services;
using SpiritSummoner.Presentation.Models;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.Services;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.ViewModels.BottomSheet;

public class MovesEditViewModel : ObservableObject, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003CCancel_003Ed__31 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public MovesEditViewModel _003C_003E4__this;

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
						_003CCancel_003Ed__31 _003CCancel_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CCancel_003Ed__31>(ref awaiter2, ref _003CCancel_003Ed__);
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
						_003CCancel_003Ed__31 _003CCancel_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCancel_003Ed__31>(ref awaiter, ref _003CCancel_003Ed__);
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
	private sealed class _003CConfirm_003Ed__30 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public MovesEditViewModel _003C_003E4__this;

		private List<MoveChangeRequest> _003CmoveChanges_003E5__1;

		private ApplyMovesEditRequest _003CapplyRequest_003E5__2;

		private Enumerator<string, MoveEditableState> _003C_003Es__3;

		private MoveEditableState _003CmoveState_003E5__4;

		private bool _003CwasOriginallyUnlocked_003E5__5;

		private bool _003CisNewlyUnlocked_003E5__6;

		private object _003C_003Es__7;

		private int _003C_003Es__8;

		private Result<ApplyMovesEditResponse> _003Cresult_003E5__9;

		private Result<ApplyMovesEditResponse> _003C_003Es__10;

		private global::System.Exception _003Cex_003E5__11;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<Result<ApplyMovesEditResponse>> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0616: Unknown result type (might be due to invalid IL or missing references)
			//IL_061b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_064c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0651: Unknown result type (might be due to invalid IL or missing references)
			//IL_0659: Unknown result type (might be due to invalid IL or missing references)
			//IL_0630: Unknown result type (might be due to invalid IL or missing references)
			//IL_0632: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0481: Unknown result type (might be due to invalid IL or missing references)
			//IL_0486: Unknown result type (might be due to invalid IL or missing references)
			//IL_048e: Unknown result type (might be due to invalid IL or missing references)
			//IL_050e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0513: Unknown result type (might be due to invalid IL or missing references)
			//IL_051b: Unknown result type (might be due to invalid IL or missing references)
			//IL_057c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0581: Unknown result type (might be due to invalid IL or missing references)
			//IL_0589: Unknown result type (might be due to invalid IL or missing references)
			//IL_0372: Unknown result type (might be due to invalid IL or missing references)
			//IL_0377: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_038c: Unknown result type (might be due to invalid IL or missing references)
			//IL_038e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0543: Unknown result type (might be due to invalid IL or missing references)
			//IL_0548: Unknown result type (might be due to invalid IL or missing references)
			//IL_055d: Unknown result type (might be due to invalid IL or missing references)
			//IL_055f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0274: Unknown result type (might be due to invalid IL or missing references)
			//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_02af: Unknown result type (might be due to invalid IL or missing references)
			//IL_0448: Unknown result type (might be due to invalid IL or missing references)
			//IL_044d: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_04da: Unknown result type (might be due to invalid IL or missing references)
			//IL_0462: Unknown result type (might be due to invalid IL or missing references)
			//IL_0464: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f1: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter4;
				TaskAwaiter awaiter3;
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				int num2;
				switch (num)
				{
				default:
					if (!_003C_003E4__this.HasUnsavedChanges)
					{
						awaiter4 = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter4;
							_003CConfirm_003Ed__30 _003CConfirm_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirm_003Ed__30>(ref awaiter4, ref _003CConfirm_003Ed__);
							return;
						}
						goto IL_00c6;
					}
					if (((Collection<MoveEditableState>)(object)_003C_003E4__this.ActiveMoves).Count == 0)
					{
						awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Active move error", "You need at least one move active!").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter3;
							_003CConfirm_003Ed__30 _003CConfirm_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirm_003Ed__30>(ref awaiter3, ref _003CConfirm_003Ed__);
							return;
						}
						goto IL_015c;
					}
					_003CmoveChanges_003E5__1 = new List<MoveChangeRequest>();
					_003C_003Es__3 = _003C_003E4__this._moveStates.Values.GetEnumerator();
					try
					{
						while (_003C_003Es__3.MoveNext())
						{
							_003CmoveState_003E5__4 = _003C_003Es__3.Current;
							if (_003CmoveState_003E5__4.HasChanges || _003CmoveState_003E5__4.IsActive)
							{
								_003CwasOriginallyUnlocked_003E5__5 = _003C_003E4__this._originallyUnlockedMoves.Contains(_003CmoveState_003E5__4.MoveId);
								_003CisNewlyUnlocked_003E5__6 = _003CmoveState_003E5__4.IsUnlocked && !_003CwasOriginallyUnlocked_003E5__5;
								_003CmoveChanges_003E5__1.Add(new MoveChangeRequest(_003CmoveState_003E5__4.MoveId, _003CisNewlyUnlocked_003E5__6, _003CwasOriginallyUnlocked_003E5__5, _003CmoveState_003E5__4.IsActive));
							}
							_003CmoveState_003E5__4 = null;
						}
					}
					finally
					{
						if (num < 0)
						{
							((global::System.IDisposable)_003C_003Es__3).Dispose();
						}
					}
					_003C_003Es__3 = default(Enumerator<string, MoveEditableState>);
					if (_003CmoveChanges_003E5__1.Count == 0)
					{
						awaiter2 = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = awaiter2;
							_003CConfirm_003Ed__30 _003CConfirm_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirm_003Ed__30>(ref awaiter2, ref _003CConfirm_003Ed__);
							return;
						}
						goto IL_02ff;
					}
					_003CapplyRequest_003E5__2 = new ApplyMovesEditRequest(_003C_003E4__this._playerSpiritId, _003CmoveChanges_003E5__1);
					_003C_003Es__8 = 0;
					goto case 3;
				case 0:
					awaiter4 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00c6;
				case 1:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_015c;
				case 2:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_02ff;
				case 3:
				case 4:
				case 5:
				case 6:
					try
					{
						TaskAwaiter<Result<ApplyMovesEditResponse>> awaiter8;
						TaskAwaiter awaiter7;
						TaskAwaiter awaiter6;
						TaskAwaiter awaiter5;
						switch (num)
						{
						default:
							awaiter8 = _003C_003E4__this._applyMovesEditUseCase.ExecuteAsync(_003CapplyRequest_003E5__2).GetAwaiter();
							if (!awaiter8.IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__2 = awaiter8;
								_003CConfirm_003Ed__30 _003CConfirm_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<ApplyMovesEditResponse>>, _003CConfirm_003Ed__30>(ref awaiter8, ref _003CConfirm_003Ed__);
								return;
							}
							goto IL_03c7;
						case 3:
							awaiter8 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<Result<ApplyMovesEditResponse>>);
							num = (_003C_003E1__state = -1);
							goto IL_03c7;
						case 4:
							awaiter7 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_049d;
						case 5:
							awaiter6 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_052a;
						case 6:
							{
								awaiter5 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								break;
							}
							IL_049d:
							((TaskAwaiter)(ref awaiter7)).GetResult();
							goto end_IL_0330;
							IL_03c7:
							_003C_003Es__10 = awaiter8.GetResult();
							_003Cresult_003E5__9 = _003C_003Es__10;
							_003C_003Es__10 = null;
							if (!_003Cresult_003E5__9.Success)
							{
								if (_003Cresult_003E5__9.ValidationErrors != null && _003Cresult_003E5__9.ValidationErrors.Count > 0)
								{
									awaiter7 = _003C_003E4__this.HandleValidationError(_003Cresult_003E5__9.ValidationErrors[0]).GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter7)).IsCompleted)
									{
										num = (_003C_003E1__state = 4);
										_003C_003Eu__1 = awaiter7;
										_003CConfirm_003Ed__30 _003CConfirm_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirm_003Ed__30>(ref awaiter7, ref _003CConfirm_003Ed__);
										return;
									}
									goto IL_049d;
								}
								awaiter6 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__9.ErrorMessage ?? "Failed to save changes").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter6)).IsCompleted)
								{
									num = (_003C_003E1__state = 5);
									_003C_003Eu__1 = awaiter6;
									_003CConfirm_003Ed__30 _003CConfirm_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirm_003Ed__30>(ref awaiter6, ref _003CConfirm_003Ed__);
									return;
								}
								goto IL_052a;
							}
							awaiter5 = _003C_003E4__this.DismissSheet().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
							{
								num = (_003C_003E1__state = 6);
								_003C_003Eu__1 = awaiter5;
								_003CConfirm_003Ed__30 _003CConfirm_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirm_003Ed__30>(ref awaiter5, ref _003CConfirm_003Ed__);
								return;
							}
							break;
							IL_052a:
							((TaskAwaiter)(ref awaiter6)).GetResult();
							goto end_IL_0330;
						}
						((TaskAwaiter)(ref awaiter5)).GetResult();
						_003Cresult_003E5__9 = null;
						goto IL_05bd;
						end_IL_0330:;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__7 = ex;
						_003C_003Es__8 = 1;
						goto IL_05bd;
					}
					goto end_IL_0007;
				case 7:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0668;
					}
					IL_015c:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					goto end_IL_0007;
					IL_05bd:
					num2 = _003C_003Es__8;
					if (num2 != 1)
					{
						break;
					}
					_003Cex_003E5__11 = (global::System.Exception)_003C_003Es__7;
					Console.WriteLine("Error confirming moves edit: " + _003Cex_003E5__11.Message);
					awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "An unexpected error occurred.").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 7);
						_003C_003Eu__1 = awaiter;
						_003CConfirm_003Ed__30 _003CConfirm_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirm_003Ed__30>(ref awaiter, ref _003CConfirm_003Ed__);
						return;
					}
					goto IL_0668;
					IL_00c6:
					((TaskAwaiter)(ref awaiter4)).GetResult();
					goto end_IL_0007;
					IL_0668:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003Cex_003E5__11 = null;
					break;
					IL_02ff:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					goto end_IL_0007;
				}
				_003C_003Es__7 = null;
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
	private sealed class _003CDismissSheet_003Ed__33 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public MovesEditViewModel _003C_003E4__this;

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
						_003CDismissSheet_003Ed__33 _003CDismissSheet_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CDismissSheet_003Ed__33>(ref awaiter, ref _003CDismissSheet_003Ed__);
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
	private sealed class _003CHandleValidationError_003Ed__32 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ValidationError error;

		public MovesEditViewModel _003C_003E4__this;

		private string _003CitemId_003E5__1;

		private object _003CitemIdObj_003E5__2;

		private int _003CrequiredAmount_003E5__3;

		private object _003CreqAmtObj_003E5__4;

		private int _003CcurrentAmount_003E5__5;

		private object _003CcurAmtObj_003E5__6;

		private bool _003CshouldNavigate_003E5__7;

		private int _003CrequiredLevel_003E5__8;

		private object _003CreqLvlObj_003E5__9;

		private int _003CcurrentLevel_003E5__10;

		private object _003CcurLvlObj_003E5__11;

		private int _003CrequiredSpiritLevel_003E5__12;

		private object _003CreqSLvlObj_003E5__13;

		private int _003CcurrentSpiritLevel_003E5__14;

		private object _003CcurSLvlObj_003E5__15;

		private string _003C_003Es__16;

		private bool _003C_003Es__17;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_01da: Unknown result type (might be due to invalid IL or missing references)
			//IL_01df: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0280: Unknown result type (might be due to invalid IL or missing references)
			//IL_0285: Unknown result type (might be due to invalid IL or missing references)
			//IL_028d: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_056c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0571: Unknown result type (might be due to invalid IL or missing references)
			//IL_0579: Unknown result type (might be due to invalid IL or missing references)
			//IL_0246: Unknown result type (might be due to invalid IL or missing references)
			//IL_024b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0260: Unknown result type (might be due to invalid IL or missing references)
			//IL_0262: Unknown result type (might be due to invalid IL or missing references)
			//IL_0532: Unknown result type (might be due to invalid IL or missing references)
			//IL_0537: Unknown result type (might be due to invalid IL or missing references)
			//IL_054c: Unknown result type (might be due to invalid IL or missing references)
			//IL_054e: Unknown result type (might be due to invalid IL or missing references)
			//IL_037b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0380: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0395: Unknown result type (might be due to invalid IL or missing references)
			//IL_0397: Unknown result type (might be due to invalid IL or missing references)
			//IL_04af: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04cb: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				TaskAwaiter awaiter3;
				TaskAwaiter<bool> awaiter5;
				TaskAwaiter awaiter4;
				switch (num)
				{
				default:
				{
					string fieldName = error.FieldName;
					_003C_003Es__16 = fieldName;
					string text = _003C_003Es__16;
					if (!(text == "INSUFFICIENT_ITEM"))
					{
						if (!(text == "INSUFFICIENT_LEVEL"))
						{
							if (text == "INSUFFICIENT_SPIRIT_LEVEL")
							{
								_003CrequiredSpiritLevel_003E5__12 = (error.Metadata.TryGetValue("RequiredSpiritLevel", ref _003CreqSLvlObj_003E5__13) ? ((int)_003CreqSLvlObj_003E5__13) : 0);
								_003CcurrentSpiritLevel_003E5__14 = (error.Metadata.TryGetValue("CurrentSpiritLevel", ref _003CcurSLvlObj_003E5__15) ? ((int)_003CcurSLvlObj_003E5__15) : 0);
								awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Spirit Level Too Low", $"{error.Message}\n\nRequired Spirit Level: {_003CrequiredSpiritLevel_003E5__12}\nCurrent Spirit Level: {_003CcurrentSpiritLevel_003E5__14}").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 3);
									_003C_003Eu__2 = awaiter2;
									_003CHandleValidationError_003Ed__32 _003CHandleValidationError_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleValidationError_003Ed__32>(ref awaiter2, ref _003CHandleValidationError_003Ed__);
									return;
								}
								goto IL_0505;
							}
							awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", error.Message).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 4);
								_003C_003Eu__2 = awaiter;
								_003CHandleValidationError_003Ed__32 _003CHandleValidationError_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleValidationError_003Ed__32>(ref awaiter, ref _003CHandleValidationError_003Ed__);
								return;
							}
							goto IL_0588;
						}
						_003CrequiredLevel_003E5__8 = (error.Metadata.TryGetValue("RequiredLevel", ref _003CreqLvlObj_003E5__9) ? ((int)_003CreqLvlObj_003E5__9) : 0);
						_003CcurrentLevel_003E5__10 = (error.Metadata.TryGetValue("CurrentLevel", ref _003CcurLvlObj_003E5__11) ? ((int)_003CcurLvlObj_003E5__11) : 0);
						awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Level Too Low", $"{error.Message}\n\nRequired Level: {_003CrequiredLevel_003E5__8}\nCurrent Level: {_003CcurrentLevel_003E5__10}").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter3;
							_003CHandleValidationError_003Ed__32 _003CHandleValidationError_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleValidationError_003Ed__32>(ref awaiter3, ref _003CHandleValidationError_003Ed__);
							return;
						}
						goto IL_03d1;
					}
					_003CitemId_003E5__1 = (error.Metadata.TryGetValue("ItemId", ref _003CitemIdObj_003E5__2) ? (_003CitemIdObj_003E5__2 as string) : null);
					_003CrequiredAmount_003E5__3 = (error.Metadata.TryGetValue("RequiredAmount", ref _003CreqAmtObj_003E5__4) ? ((int)_003CreqAmtObj_003E5__4) : 0);
					_003CcurrentAmount_003E5__5 = (error.Metadata.TryGetValue("CurrentAmount", ref _003CcurAmtObj_003E5__6) ? ((int)_003CcurAmtObj_003E5__6) : 0);
					awaiter5 = _003C_003E4__this._navigationService.ShowConfirmationAsync("Insufficient Items", $"{error.Message}\n\nRequired: {_003CrequiredAmount_003E5__3}\nYou have: {_003CcurrentAmount_003E5__5}\n\nGo to shop?").GetAwaiter();
					if (!awaiter5.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter5;
						_003CHandleValidationError_003Ed__32 _003CHandleValidationError_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CHandleValidationError_003Ed__32>(ref awaiter5, ref _003CHandleValidationError_003Ed__);
						return;
					}
					goto IL_01f5;
				}
				case 0:
					awaiter5 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_01f5;
				case 1:
					awaiter4 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_029c;
				case 2:
					awaiter3 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_03d1;
				case 3:
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0505;
				case 4:
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0588;
					}
					IL_029c:
					((TaskAwaiter)(ref awaiter4)).GetResult();
					break;
					IL_0505:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					break;
					IL_01f5:
					_003C_003Es__17 = awaiter5.GetResult();
					_003CshouldNavigate_003E5__7 = _003C_003Es__17;
					if (_003CshouldNavigate_003E5__7)
					{
						_003C_003E4__this._bottomSheetService.SetResult(_003C_003E4__this._sheetId, InsufficientFundsResult.Shop);
						awaiter4 = _003C_003E4__this.DismissSheet().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter4;
							_003CHandleValidationError_003Ed__32 _003CHandleValidationError_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CHandleValidationError_003Ed__32>(ref awaiter4, ref _003CHandleValidationError_003Ed__);
							return;
						}
						goto IL_029c;
					}
					break;
					IL_03d1:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					break;
					IL_0588:
					((TaskAwaiter)(ref awaiter)).GetResult();
					break;
				}
				_003CitemId_003E5__1 = null;
				_003CitemIdObj_003E5__2 = null;
				_003CreqAmtObj_003E5__4 = null;
				_003CcurAmtObj_003E5__6 = null;
				_003CreqLvlObj_003E5__9 = null;
				_003CcurLvlObj_003E5__11 = null;
				_003CreqSLvlObj_003E5__13 = null;
				_003CcurSLvlObj_003E5__15 = null;
				_003C_003Es__16 = null;
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
	private sealed class _003CUnlockMove_003Ed__27 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string moveId;

		public MovesEditViewModel _003C_003E4__this;

		private PlayerSpirit _003CplayerSpirit_003E5__1;

		private Spirit _003CbaseSpirit_003E5__2;

		private Move _003CmoveTemplate_003E5__3;

		private MoveRequirements _003Crequirements_003E5__4;

		private ValidateUnlockMoveRequest _003CvalidateRequest_003E5__5;

		private Result<ValidateUnlockMoveResponse> _003CvalidationResult_003E5__6;

		private ValidateUnlockMoveResponse _003Cresponse_003E5__7;

		private string _003CconfirmMessage_003E5__8;

		private bool _003Cconfirmed_003E5__9;

		private bool _003C_003Es__10;

		private Result<ValidateUnlockMoveResponse> _003C_003Es__11;

		private Enumerator<string, int> _003C_003Es__12;

		private string _003CitemName_003E5__13;

		private int _003Ccost_003E5__14;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter<Result<ValidateUnlockMoveResponse>> _003C_003Eu__2;

		private TaskAwaiter _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01da: Unknown result type (might be due to invalid IL or missing references)
			//IL_0295: Unknown result type (might be due to invalid IL or missing references)
			//IL_029a: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_036c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0371: Unknown result type (might be due to invalid IL or missing references)
			//IL_0379: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0407: Unknown result type (might be due to invalid IL or missing references)
			//IL_045f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0464: Unknown result type (might be due to invalid IL or missing references)
			//IL_025b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0260: Unknown result type (might be due to invalid IL or missing references)
			//IL_0275: Unknown result type (might be due to invalid IL or missing references)
			//IL_0277: Unknown result type (might be due to invalid IL or missing references)
			//IL_0471: Unknown result type (might be due to invalid IL or missing references)
			//IL_0476: Unknown result type (might be due to invalid IL or missing references)
			//IL_0332: Unknown result type (might be due to invalid IL or missing references)
			//IL_0337: Unknown result type (might be due to invalid IL or missing references)
			//IL_0519: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_034c: Unknown result type (might be due to invalid IL or missing references)
			//IL_034e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_03da: Unknown result type (might be due to invalid IL or missing references)
			//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_01af: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<bool> awaiter4;
				TaskAwaiter<Result<ValidateUnlockMoveResponse>> awaiter3;
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					if (!_003C_003E4__this._moveStates.ContainsKey(moveId) || _003C_003E4__this._moveStates[moveId].IsUnlocked)
					{
						break;
					}
					_003CplayerSpirit_003E5__1 = _003C_003E4__this._stateService.GetPlayerSpirit(_003C_003E4__this._playerSpiritId);
					if (_003CplayerSpirit_003E5__1 == null)
					{
						break;
					}
					_003CbaseSpirit_003E5__2 = _003C_003E4__this._stateService.GetSpiritTemplate(_003CplayerSpirit_003E5__1.BaseSpiritID);
					if (_003CbaseSpirit_003E5__2 == null)
					{
						break;
					}
					_003CmoveTemplate_003E5__3 = _003C_003E4__this._moveResolver.FindMoveTemplate(moveId, _003CbaseSpirit_003E5__2);
					if (_003CmoveTemplate_003E5__3 == null)
					{
						break;
					}
					_003Crequirements_003E5__4 = _003CmoveTemplate_003E5__3.UnlockRequirements;
					if (!_003Crequirements_003E5__4.IsFree)
					{
						_003CconfirmMessage_003E5__8 = _003C_003E4__this.BuildConfirmationMessage(_003Crequirements_003E5__4, _003CmoveTemplate_003E5__3.Power);
						awaiter4 = _003C_003E4__this._navigationService.ShowConfirmationAsync("Unlock " + moveId, _003CconfirmMessage_003E5__8).GetAwaiter();
						if (!awaiter4.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter4;
							_003CUnlockMove_003Ed__27 _003CUnlockMove_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CUnlockMove_003Ed__27>(ref awaiter4, ref _003CUnlockMove_003Ed__);
							return;
						}
						goto IL_01e9;
					}
					goto IL_021e;
				case 0:
					awaiter4 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_01e9;
				case 1:
					awaiter3 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<Result<ValidateUnlockMoveResponse>>);
					num = (_003C_003E1__state = -1);
					goto IL_02b1;
				case 2:
					awaiter2 = _003C_003Eu__3;
					_003C_003Eu__3 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0388;
				case 3:
					{
						awaiter = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0416;
					}
					IL_0388:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					break;
					IL_02b1:
					_003C_003Es__11 = awaiter3.GetResult();
					_003CvalidationResult_003E5__6 = _003C_003Es__11;
					_003C_003Es__11 = null;
					if (!_003CvalidationResult_003E5__6.Success)
					{
						if (_003CvalidationResult_003E5__6.ValidationErrors != null && _003CvalidationResult_003E5__6.ValidationErrors.Count > 0)
						{
							awaiter2 = _003C_003E4__this.HandleValidationError(_003CvalidationResult_003E5__6.ValidationErrors[0]).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter2;
								_003CUnlockMove_003Ed__27 _003CUnlockMove_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CUnlockMove_003Ed__27>(ref awaiter2, ref _003CUnlockMove_003Ed__);
								return;
							}
							goto IL_0388;
						}
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003CvalidationResult_003E5__6.ErrorMessage ?? "Failed to validate unlock").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__3 = awaiter;
							_003CUnlockMove_003Ed__27 _003CUnlockMove_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CUnlockMove_003Ed__27>(ref awaiter, ref _003CUnlockMove_003Ed__);
							return;
						}
						goto IL_0416;
					}
					_003C_003E4__this._moveStates[moveId].IsUnlocked = true;
					_003Cresponse_003E5__7 = _003CvalidationResult_003E5__6.Data;
					_003C_003Es__12 = _003Cresponse_003E5__7.ResourceCost.GetEnumerator();
					try
					{
						string text = default(string);
						int num2 = default(int);
						while (_003C_003Es__12.MoveNext())
						{
							_003C_003Es__12.Current.Deconstruct(ref text, ref num2);
							_003CitemName_003E5__13 = text;
							_003Ccost_003E5__14 = num2;
							if (_003C_003E4__this._localInventory.ContainsKey(_003CitemName_003E5__13))
							{
								Dictionary<string, int> localInventory = _003C_003E4__this._localInventory;
								text = _003CitemName_003E5__13;
								localInventory[text] -= _003Ccost_003E5__14;
							}
							_003CitemName_003E5__13 = null;
						}
					}
					finally
					{
						if (num < 0)
						{
							((global::System.IDisposable)_003C_003Es__12).Dispose();
						}
					}
					_003C_003Es__12 = default(Enumerator<string, int>);
					_003C_003E4__this.UpdateCounters();
					break;
					IL_01e9:
					_003C_003Es__10 = awaiter4.GetResult();
					_003Cconfirmed_003E5__9 = _003C_003Es__10;
					if (!_003Cconfirmed_003E5__9)
					{
						break;
					}
					_003CconfirmMessage_003E5__8 = null;
					goto IL_021e;
					IL_0416:
					((TaskAwaiter)(ref awaiter)).GetResult();
					break;
					IL_021e:
					_003CvalidateRequest_003E5__5 = new ValidateUnlockMoveRequest(_003C_003E4__this._playerSpiritId, moveId, _003C_003E4__this._localInventory);
					awaiter3 = _003C_003E4__this._validateUnlockMoveUseCase.ExecuteAsync(_003CvalidateRequest_003E5__5).GetAwaiter();
					if (!awaiter3.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter3;
						_003CUnlockMove_003Ed__27 _003CUnlockMove_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<ValidateUnlockMoveResponse>>, _003CUnlockMove_003Ed__27>(ref awaiter3, ref _003CUnlockMove_003Ed__);
						return;
					}
					goto IL_02b1;
				}
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CplayerSpirit_003E5__1 = null;
				_003CbaseSpirit_003E5__2 = null;
				_003CmoveTemplate_003E5__3 = null;
				_003Crequirements_003E5__4 = null;
				_003CvalidateRequest_003E5__5 = null;
				_003CvalidationResult_003E5__6 = null;
				_003Cresponse_003E5__7 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CplayerSpirit_003E5__1 = null;
			_003CbaseSpirit_003E5__2 = null;
			_003CmoveTemplate_003E5__3 = null;
			_003Crequirements_003E5__4 = null;
			_003CvalidateRequest_003E5__5 = null;
			_003CvalidationResult_003E5__6 = null;
			_003Cresponse_003E5__7 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IPlayerStateService _stateService;

	private readonly INavigationService _navigationService;

	private readonly IBottomSheetService _bottomSheetService;

	private readonly ValidateUnlockMoveUseCase _validateUnlockMoveUseCase;

	private readonly ApplyMovesEditUseCase _applyMovesEditUseCase;

	private readonly ISpiritMoveResolver _moveResolver;

	private BottomSheet? _sheet;

	private readonly string _playerSpiritId;

	private readonly string _sheetId;

	private readonly Dictionary<string, int> _localInventory = new Dictionary<string, int>();

	private readonly Dictionary<string, MoveEditableState> _moveStates = new Dictionary<string, MoveEditableState>();

	private readonly HashSet<string> _originallyUnlockedMoves = new HashSet<string>();

	[ObservableProperty]
	private ObservableCollection<MoveEditableState> _allLearnableMoves = new ObservableCollection<MoveEditableState>();

	[ObservableProperty]
	private ObservableCollection<MoveEditableState> _activeMoves = new ObservableCollection<MoveEditableState>();

	[ObservableProperty]
	[NotifyPropertyChangedFor("UnlockedSkillsRatio")]
	private int _unlockedMovesCount;

	[ObservableProperty]
	[NotifyPropertyChangedFor("UnlockedSkillsRatio")]
	private int _totalMovesCount;

	[ObservableProperty]
	private bool _hasUnsavedChanges;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<string>? tapMoveCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<string>? unlockMoveCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? clearAllMovesCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? confirmCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? cancelCommand;

	public string UnlockedSkillsRatio => $"{UnlockedMovesCount}/{TotalMovesCount}";

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<MoveEditableState> AllLearnableMoves
	{
		get
		{
			return _allLearnableMoves;
		}
		[MemberNotNull("_allLearnableMoves")]
		set
		{
			if (!EqualityComparer<ObservableCollection<MoveEditableState>>.Default.Equals(_allLearnableMoves, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.AllLearnableMoves);
				_allLearnableMoves = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.AllLearnableMoves);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<MoveEditableState> ActiveMoves
	{
		get
		{
			return _activeMoves;
		}
		[MemberNotNull("_activeMoves")]
		set
		{
			if (!EqualityComparer<ObservableCollection<MoveEditableState>>.Default.Equals(_activeMoves, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ActiveMoves);
				_activeMoves = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ActiveMoves);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int UnlockedMovesCount
	{
		get
		{
			return _unlockedMovesCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_unlockedMovesCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.UnlockedMovesCount);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.UnlockedSkillsRatio);
				_unlockedMovesCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.UnlockedMovesCount);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.UnlockedSkillsRatio);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int TotalMovesCount
	{
		get
		{
			return _totalMovesCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_totalMovesCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TotalMovesCount);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.UnlockedSkillsRatio);
				_totalMovesCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TotalMovesCount);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.UnlockedSkillsRatio);
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
				_hasUnsavedChanges = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasUnsavedChanges);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<string> TapMoveCommand => (IRelayCommand<string>)(object)(tapMoveCommand ?? (tapMoveCommand = new RelayCommand<string>((Action<string>)TapMove)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<string> UnlockMoveCommand => (IAsyncRelayCommand<string>)(object)(unlockMoveCommand ?? (unlockMoveCommand = new AsyncRelayCommand<string>((Func<string, global::System.Threading.Tasks.Task>)UnlockMove)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ClearAllMovesCommand
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			RelayCommand obj = clearAllMovesCommand;
			if (obj == null)
			{
				RelayCommand val = new RelayCommand(new Action(ClearAllMoves));
				RelayCommand val2 = val;
				clearAllMovesCommand = val;
				obj = val2;
			}
			return (IRelayCommand)(object)obj;
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

	public BottomSheet? SetSheet(BottomSheet sheet)
	{
		return _sheet = sheet;
	}

	public MovesEditViewModel(IPlayerStateService stateService, INavigationService navigationService, IBottomSheetService bottomSheetService, ValidateUnlockMoveUseCase validateUnlockMoveUseCase, ApplyMovesEditUseCase applyMovesEditUseCase, ISpiritMoveResolver moveResolver, string playerSpiritId, string sheetId)
	{
		_stateService = stateService;
		_navigationService = navigationService;
		_bottomSheetService = bottomSheetService;
		_validateUnlockMoveUseCase = validateUnlockMoveUseCase;
		_applyMovesEditUseCase = applyMovesEditUseCase;
		_moveResolver = moveResolver;
		_playerSpiritId = playerSpiritId;
		_sheetId = sheetId;
		InitializeLocalState();
	}

	private void InitializeLocalState()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
		Player currentPlayer = _stateService.GetCurrentPlayer();
		if (currentPlayer?.Inventory != null)
		{
			global::System.Collections.Generic.IEnumerator<KeyValuePair<string, Inventory>> enumerator = ((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, Inventory>>)currentPlayer.Inventory).GetEnumerator();
			try
			{
				while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
				{
					KeyValuePair<string, Inventory> current = enumerator.Current;
					_localInventory[current.Key] = current.Value.Amount;
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator)?.Dispose();
			}
		}
		PlayerSpirit playerSpirit = _stateService.GetPlayerSpirit(_playerSpiritId);
		if (playerSpirit?.Moves == null)
		{
			return;
		}
		Spirit spiritTemplate = _stateService.GetSpiritTemplate(playerSpirit.BaseSpiritID);
		if (spiritTemplate == null)
		{
			return;
		}
		global::System.Collections.Generic.IEnumerator<KeyValuePair<string, MoveState>> enumerator2 = ((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, MoveState>>)playerSpirit.Moves).GetEnumerator();
		try
		{
			string text = default(string);
			MoveState moveState = default(MoveState);
			while (((global::System.Collections.IEnumerator)enumerator2).MoveNext())
			{
				enumerator2.Current.Deconstruct(ref text, ref moveState);
				string text2 = text;
				MoveState moveState2 = moveState;
				if (string.IsNullOrEmpty(text2))
				{
					continue;
				}
				Move move = _moveResolver.FindMoveTemplate(text2, spiritTemplate);
				if (move != null)
				{
					bool isUnlocked = moveState2.IsUnlocked;
					bool isActiveMove = moveState2.IsActiveMove;
					bool isBasicMove = spiritTemplate.IsBaseMove(text2);
					MoveEditableState moveEditableState = new MoveEditableState(text2, isUnlocked, isActiveMove, move.Type, move.MoveType, move.Power, isBasicMove, move.UnlockRequirements.SpiritLevelRequired);
					((ObservableObject)moveEditableState).PropertyChanged += new PropertyChangedEventHandler(OnMoveEditableStateChanged);
					_moveStates[text2] = moveEditableState;
					if (isUnlocked)
					{
						_originallyUnlockedMoves.Add(text2);
					}
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator2)?.Dispose();
		}
		RefreshMoveCollections();
		UpdateCounters();
	}

	private void RefreshMoveCollections()
	{
		((Collection<MoveEditableState>)(object)AllLearnableMoves).Clear();
		((Collection<MoveEditableState>)(object)ActiveMoves).Clear();
		global::System.Collections.Generic.IEnumerator<MoveEditableState> enumerator = ((global::System.Collections.Generic.IEnumerable<MoveEditableState>)Enumerable.OrderBy<MoveEditableState, int>((global::System.Collections.Generic.IEnumerable<MoveEditableState>)_moveStates.Values, (Func<MoveEditableState, int>)((MoveEditableState m) => m.Power))).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				MoveEditableState current = enumerator.Current;
				if (current.IsActive)
				{
					((Collection<MoveEditableState>)(object)ActiveMoves).Add(current);
				}
				else
				{
					((Collection<MoveEditableState>)(object)AllLearnableMoves).Add(current);
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
	}

	private void OnMoveEditableStateChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "IsUnlocked")
		{
			UpdateCounters();
			CheckForUnsavedChanges();
		}
		else if (e.PropertyName == "IsActive")
		{
			CheckForUnsavedChanges();
		}
	}

	private void UpdateCounters()
	{
		UnlockedMovesCount = Enumerable.Count<MoveEditableState>((global::System.Collections.Generic.IEnumerable<MoveEditableState>)_moveStates.Values, (Func<MoveEditableState, bool>)((MoveEditableState m) => m.IsUnlocked));
		TotalMovesCount = _moveStates.Count;
	}

	private void CheckForUnsavedChanges()
	{
		HasUnsavedChanges = Enumerable.Any<MoveEditableState>((global::System.Collections.Generic.IEnumerable<MoveEditableState>)_moveStates.Values, (Func<MoveEditableState, bool>)((MoveEditableState m) => m.HasChanges));
	}

	[RelayCommand]
	private void TapMove(string moveId)
	{
		MoveEditableState moveEditableState = default(MoveEditableState);
		if (!_moveStates.TryGetValue(moveId, ref moveEditableState))
		{
			return;
		}
		if (moveEditableState.IsBasicMove && moveEditableState.IsActive)
		{
			_navigationService.ShowAlertAsync("Base Move", "This is a base move and cannot be deactivated.");
			return;
		}
		if (!moveEditableState.IsActive)
		{
			if (!moveEditableState.IsUnlocked || ((Collection<MoveEditableState>)(object)ActiveMoves).Count >= 4)
			{
				return;
			}
			moveEditableState.IsActive = true;
			((Collection<MoveEditableState>)(object)AllLearnableMoves).Remove(moveEditableState);
			((Collection<MoveEditableState>)(object)ActiveMoves).Add(moveEditableState);
		}
		else
		{
			moveEditableState.IsActive = false;
			((Collection<MoveEditableState>)(object)ActiveMoves).Remove(moveEditableState);
			int num = 0;
			global::System.Collections.Generic.IEnumerator<MoveEditableState> enumerator = ((Collection<MoveEditableState>)(object)AllLearnableMoves).GetEnumerator();
			try
			{
				while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
				{
					MoveEditableState current = enumerator.Current;
					if (string.Compare(moveId, current.MoveId, (StringComparison)4) > 0)
					{
						num++;
						continue;
					}
					break;
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator)?.Dispose();
			}
			((Collection<MoveEditableState>)(object)AllLearnableMoves).Insert(num, moveEditableState);
		}
		CheckForUnsavedChanges();
	}

	[AsyncStateMachine(typeof(_003CUnlockMove_003Ed__27))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task UnlockMove(string moveId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CUnlockMove_003Ed__27 _003CUnlockMove_003Ed__ = new _003CUnlockMove_003Ed__27();
		_003CUnlockMove_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CUnlockMove_003Ed__._003C_003E4__this = this;
		_003CUnlockMove_003Ed__.moveId = moveId;
		_003CUnlockMove_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CUnlockMove_003Ed__._003C_003Et__builder)).Start<_003CUnlockMove_003Ed__27>(ref _003CUnlockMove_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CUnlockMove_003Ed__._003C_003Et__builder)).Task;
	}

	private string BuildConfirmationMessage(MoveRequirements requirements, int movePower)
	{
		List<string> val = new List<string>();
		if (requirements.SpiritLevelRequired > 0)
		{
			val.Add($"Spirit Level {requirements.SpiritLevelRequired} required.");
		}
		else if (requirements.PlayerLevelRequired > 0)
		{
			val.Add($"Player Level {requirements.PlayerLevelRequired} required.");
		}
		string crystalRequirement = ValidateUnlockMoveUseCase.GetCrystalRequirement(movePower);
		val.Add($"Consume 1x {crystalRequirement}.\n(You have {CollectionExtensions.GetValueOrDefault<string, int>((IReadOnlyDictionary<string, int>)(object)_localInventory, crystalRequirement, 0)})");
		val.Add("Unlock this move?");
		return string.Join("\n\n", (global::System.Collections.Generic.IEnumerable<string>)val);
	}

	[RelayCommand]
	private void ClearAllMoves()
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		List<MoveEditableState> val = Enumerable.ToList<MoveEditableState>(Enumerable.Where<MoveEditableState>((global::System.Collections.Generic.IEnumerable<MoveEditableState>)ActiveMoves, (Func<MoveEditableState, bool>)((MoveEditableState m) => !m.IsBasicMove)));
		if (val.Count == 0)
		{
			_navigationService.ShowAlertAsync("No moves to clear", "All active moves are base moves and cannot be cleared.");
			return;
		}
		Enumerator<MoveEditableState> enumerator = val.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				MoveEditableState current = enumerator.Current;
				current.IsActive = false;
				((Collection<MoveEditableState>)(object)ActiveMoves).Remove(current);
				int num = 0;
				global::System.Collections.Generic.IEnumerator<MoveEditableState> enumerator2 = ((Collection<MoveEditableState>)(object)AllLearnableMoves).GetEnumerator();
				try
				{
					while (((global::System.Collections.IEnumerator)enumerator2).MoveNext())
					{
						MoveEditableState current2 = enumerator2.Current;
						if (string.Compare(current.MoveId, current2.MoveId, (StringComparison)4) > 0)
						{
							num++;
							continue;
						}
						break;
					}
				}
				finally
				{
					((global::System.IDisposable)enumerator2)?.Dispose();
				}
				((Collection<MoveEditableState>)(object)AllLearnableMoves).Insert(num, current);
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator).Dispose();
		}
		CheckForUnsavedChanges();
	}

	[AsyncStateMachine(typeof(_003CConfirm_003Ed__30))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Confirm()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CConfirm_003Ed__30 _003CConfirm_003Ed__ = new _003CConfirm_003Ed__30();
		_003CConfirm_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CConfirm_003Ed__._003C_003E4__this = this;
		_003CConfirm_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CConfirm_003Ed__._003C_003Et__builder)).Start<_003CConfirm_003Ed__30>(ref _003CConfirm_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CConfirm_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CCancel_003Ed__31))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Cancel()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CCancel_003Ed__31 _003CCancel_003Ed__ = new _003CCancel_003Ed__31();
		_003CCancel_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CCancel_003Ed__._003C_003E4__this = this;
		_003CCancel_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CCancel_003Ed__._003C_003Et__builder)).Start<_003CCancel_003Ed__31>(ref _003CCancel_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CCancel_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CHandleValidationError_003Ed__32))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task HandleValidationError(ValidationError error)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CHandleValidationError_003Ed__32 _003CHandleValidationError_003Ed__ = new _003CHandleValidationError_003Ed__32();
		_003CHandleValidationError_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CHandleValidationError_003Ed__._003C_003E4__this = this;
		_003CHandleValidationError_003Ed__.error = error;
		_003CHandleValidationError_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CHandleValidationError_003Ed__._003C_003Et__builder)).Start<_003CHandleValidationError_003Ed__32>(ref _003CHandleValidationError_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CHandleValidationError_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CDismissSheet_003Ed__33))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task DismissSheet()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CDismissSheet_003Ed__33 _003CDismissSheet_003Ed__ = new _003CDismissSheet_003Ed__33();
		_003CDismissSheet_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CDismissSheet_003Ed__._003C_003E4__this = this;
		_003CDismissSheet_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CDismissSheet_003Ed__._003C_003Et__builder)).Start<_003CDismissSheet_003Ed__33>(ref _003CDismissSheet_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CDismissSheet_003Ed__._003C_003Et__builder)).Task;
	}

	public void Dispose()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		Enumerator<string, MoveEditableState> enumerator = _moveStates.Values.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				MoveEditableState current = enumerator.Current;
				((ObservableObject)current).PropertyChanged -= new PropertyChangedEventHandler(OnMoveEditableStateChanged);
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator).Dispose();
		}
		GC.SuppressFinalize((object)this);
	}
}
