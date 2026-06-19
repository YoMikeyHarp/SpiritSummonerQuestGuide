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
using Microsoft.Extensions.DependencyInjection;
using SpiritSummoner.Application.State;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Infrastructure.Services;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.Squads;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.ViewModels.BottomSheet;

public class SavedSquadsSheetViewModel : ObservableObject, ILoadableViewModel, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003CCancel_003Ed__17 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SavedSquadsSheetViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_0139;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this.DismissAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CCancel_003Ed__17 _003CCancel_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCancel_003Ed__17>(ref awaiter2, ref _003CCancel_003Ed__);
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
					goto IL_015c;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error Canceling saved squads", _003Cex_003E5__3.Message).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CCancel_003Ed__17 _003CCancel_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCancel_003Ed__17>(ref awaiter, ref _003CCancel_003Ed__);
					return;
				}
				goto IL_0139;
				IL_0139:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine(_003Cex_003E5__3.StackTrace);
				_003Cex_003E5__3 = null;
				goto IL_015c;
				IL_015c:
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
	private sealed class _003CConfirm_003Ed__16 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SavedSquadsSheetViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private int _003CselectedSquadSlot_003E5__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 1u)
				{
					goto IL_004a;
				}
				TaskAwaiter awaiter;
				if (num == 2)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01f4;
				}
				if (!_003C_003E4__this.IsLoading && _003C_003E4__this.CurrentSquad != null)
				{
					_003C_003Es__2 = 0;
					goto IL_004a;
				}
				goto end_IL_0007;
				IL_01f4:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine("Error switching squad: " + _003Cex_003E5__4.Message);
				_003Cex_003E5__4 = null;
				goto IL_0221;
				IL_004a:
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
							goto IL_0143;
						}
						_003CselectedSquadSlot_003E5__3 = _003C_003E4__this.CurrentSquad.SquadSlot;
						awaiter3 = _003C_003E4__this._spiritActionService.SwitchActiveSquadAsync(_003CselectedSquadSlot_003E5__3).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CConfirm_003Ed__16 _003CConfirm_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirm_003Ed__16>(ref awaiter3, ref _003CConfirm_003Ed__);
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
					awaiter2 = _003C_003E4__this.DismissAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter2;
						_003CConfirm_003Ed__16 _003CConfirm_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirm_003Ed__16>(ref awaiter2, ref _003CConfirm_003Ed__);
						return;
					}
					goto IL_0143;
					IL_0143:
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
					goto IL_0221;
				}
				_003Cex_003E5__4 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to switch squad.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 2);
					_003C_003Eu__1 = awaiter;
					_003CConfirm_003Ed__16 _003CConfirm_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirm_003Ed__16>(ref awaiter, ref _003CConfirm_003Ed__);
					return;
				}
				goto IL_01f4;
				IL_0221:
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
	private sealed class _003CDismissAsync_003Ed__18 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SavedSquadsSheetViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003C_003E4__this.Dispose();
					awaiter = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CDismissAsync_003Ed__18 _003CDismissAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CDismissAsync_003Ed__18>(ref awaiter, ref _003CDismissAsync_003Ed__);
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
	private sealed class _003CInitializeSquads_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SavedSquadsSheetViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private List<ValueTuple<string, SpiritSquadViewModel>> _003CsquadList_003E5__3;

		private global::System.Collections.Generic.IEnumerable<SpiritSquadViewModel> _003CsortedSquads_003E5__4;

		private global::System.Collections.Generic.IEnumerator<KeyValuePair<string, List<string>>> _003C_003Es__5;

		private KeyValuePair<string, List<string>> _003CsquadConfig_003E5__6;

		private int _003Cindex_003E5__7;

		private SpiritSquadViewModel _003Csquad_003E5__8;

		private global::System.Collections.Generic.IEnumerator<SpiritSquadViewModel> _003C_003Es__9;

		private SpiritSquadViewModel _003Csquad_003E5__10;

		private global::System.Exception _003Cex_003E5__11;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_030d;
				}
				if (_003C_003E4__this._stateService.GetActiveSquad() != null)
				{
					_003C_003Es__2 = 0;
					try
					{
						((Collection<SpiritSquadViewModel>)(object)_003C_003E4__this.SquadCollection).Clear();
						_003CsquadList_003E5__3 = new List<ValueTuple<string, SpiritSquadViewModel>>();
						_003C_003Es__5 = ((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, List<string>>>)_003C_003E4__this._stateService.GetCurrentPlayer().Squads).GetEnumerator();
						try
						{
							while (((global::System.Collections.IEnumerator)_003C_003Es__5).MoveNext())
							{
								_003CsquadConfig_003E5__6 = _003C_003Es__5.Current;
								_003Cindex_003E5__7 = int.Parse(_003CsquadConfig_003E5__6.Key);
								_003Csquad_003E5__8 = ActivatorUtilities.CreateInstance<SpiritSquadViewModel>(_003C_003E4__this._serviceProvider, new object[2] { false, true });
								_003Csquad_003E5__8.SquadSlot = _003Cindex_003E5__7;
								_003Csquad_003E5__8.LoadSquadSlots();
								_003CsquadList_003E5__3.Add(new ValueTuple<string, SpiritSquadViewModel>(_003CsquadConfig_003E5__6.Key, _003Csquad_003E5__8));
								_003Csquad_003E5__8 = null;
								_003CsquadConfig_003E5__6 = default(KeyValuePair<string, List<string>>);
							}
						}
						finally
						{
							if (num < 0 && _003C_003Es__5 != null)
							{
								((global::System.IDisposable)_003C_003Es__5).Dispose();
							}
						}
						_003C_003Es__5 = null;
						_003CsortedSquads_003E5__4 = Enumerable.Select<ValueTuple<string, SpiritSquadViewModel>, SpiritSquadViewModel>((global::System.Collections.Generic.IEnumerable<ValueTuple<string, SpiritSquadViewModel>>)_003CsquadList_003E5__3, (Func<ValueTuple<string, SpiritSquadViewModel>, SpiritSquadViewModel>)((ValueTuple<string, SpiritSquadViewModel> s) => s.Item2));
						_003C_003Es__9 = _003CsortedSquads_003E5__4.GetEnumerator();
						try
						{
							while (((global::System.Collections.IEnumerator)_003C_003Es__9).MoveNext())
							{
								_003Csquad_003E5__10 = _003C_003Es__9.Current;
								((Collection<SpiritSquadViewModel>)(object)_003C_003E4__this.SquadCollection).Add(_003Csquad_003E5__10);
								_003Csquad_003E5__10 = null;
							}
						}
						finally
						{
							if (num < 0 && _003C_003Es__9 != null)
							{
								((global::System.IDisposable)_003C_003Es__9).Dispose();
							}
						}
						_003C_003Es__9 = null;
						_003C_003E4__this.CurrentSquad = Enumerable.FirstOrDefault<SpiritSquadViewModel>((global::System.Collections.Generic.IEnumerable<SpiritSquadViewModel>)_003C_003E4__this.SquadCollection, (Func<SpiritSquadViewModel, bool>)([CompilerGenerated] (SpiritSquadViewModel s) => s?.SquadSlot == _003C_003E4__this._stateService.GetCurrentPlayer().ActiveSquadSlot));
						_003C_003E4__this.CurrentSquad.IsActiveSquadSheet = true;
						_003C_003E4__this.CurrentSquadSlot = _003C_003E4__this._stateService.GetCurrentPlayer().ActiveSquadSlot;
						_003CsquadList_003E5__3 = null;
						_003CsortedSquads_003E5__4 = null;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__1 = ex;
						_003C_003Es__2 = 1;
					}
					int num2 = _003C_003Es__2;
					if (num2 != 1)
					{
						goto IL_031f;
					}
					_003Cex_003E5__11 = (global::System.Exception)_003C_003Es__1;
					awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error initializing squads", _003Cex_003E5__11.Message).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CInitializeSquads_003Ed__14 _003CInitializeSquads_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CInitializeSquads_003Ed__14>(ref awaiter, ref _003CInitializeSquads_003Ed__);
						return;
					}
					goto IL_030d;
				}
				goto end_IL_0007;
				IL_030d:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__11 = null;
				goto IL_031f;
				IL_031f:
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
	private sealed class _003CLoadDataAsync_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object parameter;

		public SavedSquadsSheetViewModel _003C_003E4__this;

		private BottomSheet _003Csheet_003E5__1;

		private object _003C_003Es__2;

		private int _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 1u && parameter != null)
				{
					ref BottomSheet reference = ref _003Csheet_003E5__1;
					object obj = parameter;
					reference = (BottomSheet)((obj is BottomSheet) ? obj : null);
					if (_003Csheet_003E5__1 != null)
					{
						_003C_003E4__this._sheet = _003Csheet_003E5__1;
					}
				}
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
							goto IL_018d;
						}
						_003C_003Es__3 = 0;
					}
					try
					{
						TaskAwaiter awaiter2;
						if (num != 0)
						{
							_003C_003E4__this.IsLoading = true;
							awaiter2 = _003C_003E4__this.InitializeSquads().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003CLoadDataAsync_003Ed__13 _003CLoadDataAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__13>(ref awaiter2, ref _003CLoadDataAsync_003Ed__);
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
						_003C_003Es__2 = ex;
						_003C_003Es__3 = 1;
					}
					int num2 = _003C_003Es__3;
					if (num2 == 1)
					{
						_003Cex_003E5__4 = (global::System.Exception)_003C_003Es__2;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error loading SavedSquads", _003Cex_003E5__4.Message).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter;
							_003CLoadDataAsync_003Ed__13 _003CLoadDataAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__13>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
							return;
						}
						goto IL_018d;
					}
					_003C_003Es__2 = null;
					goto end_IL_004d;
					IL_018d:
					((TaskAwaiter)(ref awaiter)).GetResult();
					end_IL_004d:;
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

	private readonly IBottomSheetService _bottomSheetService;

	private readonly ISpiritActionService _spiritActionService;

	private readonly IPlayerStateService _stateService;

	private readonly IServiceProvider _serviceProvider;

	private BottomSheet? _sheet;

	private bool _disposed;

	[ObservableProperty]
	private ObservableCollection<SpiritSquadViewModel?> _squadCollection = new ObservableCollection<SpiritSquadViewModel>();

	[ObservableProperty]
	private SpiritSquadViewModel? _currentSquad;

	[ObservableProperty]
	private int _currentSquadSlot;

	[ObservableProperty]
	private Dictionary<string, List<string>> _squadData = new Dictionary<string, List<string>>();

	[ObservableProperty]
	private bool _isLoading = false;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? initializeSquadsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<SpiritSquadViewModel>? setActiveSquadCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? confirmCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? cancelCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<SpiritSquadViewModel?> SquadCollection
	{
		get
		{
			return _squadCollection;
		}
		[MemberNotNull("_squadCollection")]
		set
		{
			if (!EqualityComparer<ObservableCollection<SpiritSquadViewModel>>.Default.Equals(_squadCollection, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SquadCollection);
				_squadCollection = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SquadCollection);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public SpiritSquadViewModel? CurrentSquad
	{
		get
		{
			return _currentSquad;
		}
		set
		{
			if (!EqualityComparer<SpiritSquadViewModel>.Default.Equals(_currentSquad, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentSquad);
				_currentSquad = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentSquad);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int CurrentSquadSlot
	{
		get
		{
			return _currentSquadSlot;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_currentSquadSlot, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentSquadSlot);
				_currentSquadSlot = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentSquadSlot);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Dictionary<string, List<string>> SquadData
	{
		get
		{
			return _squadData;
		}
		[MemberNotNull("_squadData")]
		set
		{
			if (!EqualityComparer<Dictionary<string, List<string>>>.Default.Equals(_squadData, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SquadData);
				_squadData = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SquadData);
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

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand InitializeSquadsCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = initializeSquadsCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)InitializeSquads);
				AsyncRelayCommand val2 = val;
				initializeSquadsCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<SpiritSquadViewModel> SetActiveSquadCommand => (IRelayCommand<SpiritSquadViewModel>)(object)(setActiveSquadCommand ?? (setActiveSquadCommand = new RelayCommand<SpiritSquadViewModel>((Action<SpiritSquadViewModel>)SetActiveSquad)));

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

	public SavedSquadsSheetViewModel(INavigationService navigationService, IPlayerStateService playerStateService, IBottomSheetService bottomSheetService, ISpiritActionService spiritActionService, IServiceProvider serviceProvider)
	{
		_navigationService = navigationService;
		_bottomSheetService = bottomSheetService;
		_spiritActionService = spiritActionService;
		_stateService = playerStateService;
		_serviceProvider = serviceProvider;
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__13))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? parameter)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__13 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__13();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.parameter = parameter;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__13>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CInitializeSquads_003Ed__14))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task InitializeSquads()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CInitializeSquads_003Ed__14 _003CInitializeSquads_003Ed__ = new _003CInitializeSquads_003Ed__14();
		_003CInitializeSquads_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CInitializeSquads_003Ed__._003C_003E4__this = this;
		_003CInitializeSquads_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CInitializeSquads_003Ed__._003C_003Et__builder)).Start<_003CInitializeSquads_003Ed__14>(ref _003CInitializeSquads_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CInitializeSquads_003Ed__._003C_003Et__builder)).Task;
	}

	[RelayCommand]
	private void SetActiveSquad(SpiritSquadViewModel selectedSquad)
	{
		CurrentSquad.IsActiveSquadSheet = false;
		CurrentSquad = selectedSquad;
		CurrentSquad.IsActiveSquadSheet = true;
		CurrentSquadSlot = selectedSquad.SquadSlot;
		((ObservableObject)this).OnPropertyChanged("IsActiveSquadSheet");
	}

	[AsyncStateMachine(typeof(_003CConfirm_003Ed__16))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Confirm()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CConfirm_003Ed__16 _003CConfirm_003Ed__ = new _003CConfirm_003Ed__16();
		_003CConfirm_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CConfirm_003Ed__._003C_003E4__this = this;
		_003CConfirm_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CConfirm_003Ed__._003C_003Et__builder)).Start<_003CConfirm_003Ed__16>(ref _003CConfirm_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CConfirm_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CCancel_003Ed__17))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task Cancel()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CCancel_003Ed__17 _003CCancel_003Ed__ = new _003CCancel_003Ed__17();
		_003CCancel_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CCancel_003Ed__._003C_003E4__this = this;
		_003CCancel_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CCancel_003Ed__._003C_003Et__builder)).Start<_003CCancel_003Ed__17>(ref _003CCancel_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CCancel_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CDismissAsync_003Ed__18))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task DismissAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CDismissAsync_003Ed__18 _003CDismissAsync_003Ed__ = new _003CDismissAsync_003Ed__18();
		_003CDismissAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CDismissAsync_003Ed__._003C_003E4__this = this;
		_003CDismissAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CDismissAsync_003Ed__._003C_003Et__builder)).Start<_003CDismissAsync_003Ed__18>(ref _003CDismissAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CDismissAsync_003Ed__._003C_003Et__builder)).Task;
	}

	public void Dispose()
	{
		if (_disposed)
		{
			return;
		}
		global::System.Collections.Generic.IEnumerator<SpiritSquadViewModel> enumerator = ((Collection<SpiritSquadViewModel>)(object)SquadCollection).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
			{
				enumerator.Current?.Dispose();
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator)?.Dispose();
		}
		((Collection<SpiritSquadViewModel>)(object)SquadCollection).Clear();
		_disposed = true;
		GC.SuppressFinalize((object)this);
	}
}
