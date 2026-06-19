using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using SpiritSummoner.Application.Events;
using SpiritSummoner.Application.State;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Infrastructure.Services;
using SpiritSummoner.Presentation.Models;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.BottomSheet;
using SpiritSummoner.Presentation.ViewModels.Spirits;
using SpiritSummoner.Presentation.Views.BottomSheets.SpiritSheets;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.ViewModels.Squads;

public class SpiritSquadViewModel : ObservableObject, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003CCheckIfInSquad_003Ed__39 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public List<string> updatedSquadComposition;

		public SpiritSquadViewModel _003C_003E4__this;

		private int _003Ci_003E5__1;

		private string _003CspiritId_003E5__2;

		private SpiritCardModel _003CcurrentModel_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
					_003Ci_003E5__1 = 0;
					goto IL_017d;
				}
				TaskAwaiter awaiter = _003C_003Eu__1;
				_003C_003Eu__1 = default(TaskAwaiter);
				num = (_003C_003E1__state = -1);
				goto IL_00f3;
				IL_015c:
				_003CspiritId_003E5__2 = null;
				_003CcurrentModel_003E5__3 = null;
				_003Ci_003E5__1++;
				goto IL_017d;
				IL_00f3:
				((TaskAwaiter)(ref awaiter)).GetResult();
				goto IL_00fc;
				IL_017d:
				if (_003Ci_003E5__1 < 3)
				{
					_003CspiritId_003E5__2 = Enumerable.ElementAtOrDefault<string>((global::System.Collections.Generic.IEnumerable<string>)updatedSquadComposition, _003Ci_003E5__1);
					_003CcurrentModel_003E5__3 = _003C_003E4__this.GetSlotModel(_003Ci_003E5__1);
					if (!string.IsNullOrEmpty(_003CspiritId_003E5__2))
					{
						if (_003CcurrentModel_003E5__3 == null || _003CcurrentModel_003E5__3.PlayerSpiritId != _003CspiritId_003E5__2)
						{
							awaiter = _003C_003E4__this.SetSlotModelAsync(_003Ci_003E5__1, _003CspiritId_003E5__2).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CCheckIfInSquad_003Ed__39 _003CCheckIfInSquad_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCheckIfInSquad_003Ed__39>(ref awaiter, ref _003CCheckIfInSquad_003Ed__);
								return;
							}
							goto IL_00f3;
						}
						goto IL_00fc;
					}
					if (_003CcurrentModel_003E5__3 != null)
					{
						_003C_003E4__this.ClearSlot(_003Ci_003E5__1);
						((ObservableObject)_003C_003E4__this).OnPropertyChanged(_003C_003E4__this.GetSlotPropertyName(_003Ci_003E5__1));
					}
					goto IL_015c;
				}
				goto end_IL_0007;
				IL_00fc:
				((ObservableObject)_003C_003E4__this).OnPropertyChanged(_003C_003E4__this.GetSlotPropertyName(_003Ci_003E5__1));
				goto IL_015c;
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
	private sealed class _003CLoadSquadSlots_003Ed__42 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public SpiritSquadViewModel _003C_003E4__this;

		private List<string> _003CcurrentSquad_003E5__1;

		private global::System.Exception _003Cex_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 2u && (_003C_003E4__this._playerState.GetAllPlayerSpirits() == null || ((global::System.Collections.Generic.IReadOnlyCollection<PlayerSpirit>)_003C_003E4__this._playerState.GetAllPlayerSpirits()).Count == 0))
				{
					_003C_003E4__this.ClearAllSlots();
				}
				else
				{
					try
					{
						TaskAwaiter awaiter3;
						TaskAwaiter awaiter2;
						TaskAwaiter awaiter;
						switch (num)
						{
						default:
							_003CcurrentSquad_003E5__1 = _003C_003E4__this.GetCurrentSquadComposition();
							awaiter3 = _003C_003E4__this.SetSlotModelAsync(0, Enumerable.ElementAtOrDefault<string>((global::System.Collections.Generic.IEnumerable<string>)_003CcurrentSquad_003E5__1, 0)).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter3;
								_003CLoadSquadSlots_003Ed__42 _003CLoadSquadSlots_003Ed__ = this;
								((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadSquadSlots_003Ed__42>(ref awaiter3, ref _003CLoadSquadSlots_003Ed__);
								return;
							}
							goto IL_00f0;
						case 0:
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_00f0;
						case 1:
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0165;
						case 2:
							{
								awaiter = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								break;
							}
							IL_0165:
							((TaskAwaiter)(ref awaiter2)).GetResult();
							awaiter = _003C_003E4__this.SetSlotModelAsync(2, Enumerable.ElementAtOrDefault<string>((global::System.Collections.Generic.IEnumerable<string>)_003CcurrentSquad_003E5__1, 2)).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__1 = awaiter;
								_003CLoadSquadSlots_003Ed__42 _003CLoadSquadSlots_003Ed__ = this;
								((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadSquadSlots_003Ed__42>(ref awaiter, ref _003CLoadSquadSlots_003Ed__);
								return;
							}
							break;
							IL_00f0:
							((TaskAwaiter)(ref awaiter3)).GetResult();
							awaiter2 = _003C_003E4__this.SetSlotModelAsync(1, Enumerable.ElementAtOrDefault<string>((global::System.Collections.Generic.IEnumerable<string>)_003CcurrentSquad_003E5__1, 1)).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter2;
								_003CLoadSquadSlots_003Ed__42 _003CLoadSquadSlots_003Ed__ = this;
								((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadSquadSlots_003Ed__42>(ref awaiter2, ref _003CLoadSquadSlots_003Ed__);
								return;
							}
							goto IL_0165;
						}
						((TaskAwaiter)(ref awaiter)).GetResult();
						((ObservableObject)_003C_003E4__this).OnPropertyChanged("Slot1");
						((ObservableObject)_003C_003E4__this).OnPropertyChanged("Slot2");
						((ObservableObject)_003C_003E4__this).OnPropertyChanged("Slot3");
						((ObservableObject)_003C_003E4__this).OnPropertyChanged("HasSpirits");
						((ObservableObject)_003C_003E4__this).OnPropertyChanged("SquadCompleteness");
						_003CcurrentSquad_003E5__1 = null;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__2 = ex;
						Console.WriteLine("Error loading squad slots: " + _003Cex_003E5__2.Message);
						_003C_003E4__this.ClearAllSlots();
					}
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

	[CompilerGenerated]
	private sealed class _003CNavigateToSpiritDetails_003Ed__51 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string id;

		public SpiritSquadViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_015e;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._navigationService.NavigateToAsync(_003C_003E4__this._playerState.CurrentRoute + "/spiritdetails?spiritId=" + id).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CNavigateToSpiritDetails_003Ed__51 _003CNavigateToSpiritDetails_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToSpiritDetails_003Ed__51>(ref awaiter2, ref _003CNavigateToSpiritDetails_003Ed__);
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
					goto IL_0170;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error navigating to spiritpage", _003Cex_003E5__3.Message).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CNavigateToSpiritDetails_003Ed__51 _003CNavigateToSpiritDetails_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToSpiritDetails_003Ed__51>(ref awaiter, ref _003CNavigateToSpiritDetails_003Ed__);
					return;
				}
				goto IL_015e;
				IL_015e:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__3 = null;
				goto IL_0170;
				IL_0170:
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
	private sealed class _003COpenSpiritsHoldNavigation_003Ed__52 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritSquadViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private BottomSheet _003Csheet_003E5__3;

		private BottomSheet _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<BottomSheet> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
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
						goto IL_01da;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					TaskAwaiter<BottomSheet> awaiter3;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0125;
						}
						awaiter3 = _003C_003E4__this._navigationService.GetFullSheet<SpiritHoldNavigationSheet, SpiritsHoldNavigationSheetViewModel>("spiritholdnav").GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003COpenSpiritsHoldNavigation_003Ed__52 _003COpenSpiritsHoldNavigation_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<BottomSheet>, _003COpenSpiritsHoldNavigation_003Ed__52>(ref awaiter3, ref _003COpenSpiritsHoldNavigation_003Ed__);
							return;
						}
					}
					else
					{
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<BottomSheet>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__4 = awaiter3.GetResult();
					_003Csheet_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					awaiter2 = _003C_003E4__this._bottomSheetService.ShowSheetAsync(_003Csheet_003E5__3).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter2;
						_003COpenSpiritsHoldNavigation_003Ed__52 _003COpenSpiritsHoldNavigation_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenSpiritsHoldNavigation_003Ed__52>(ref awaiter2, ref _003COpenSpiritsHoldNavigation_003Ed__);
						return;
					}
					goto IL_0125;
					IL_0125:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					_003Csheet_003E5__3 = null;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_01fd;
				}
				_003Cex_003E5__5 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Navigation Error", "Failed to navigate to opponent profile.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 2);
					_003C_003Eu__2 = awaiter;
					_003COpenSpiritsHoldNavigation_003Ed__52 _003COpenSpiritsHoldNavigation_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenSpiritsHoldNavigation_003Ed__52>(ref awaiter, ref _003COpenSpiritsHoldNavigation_003Ed__);
					return;
				}
				goto IL_01da;
				IL_01da:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine(_003Cex_003E5__5.Message);
				_003Cex_003E5__5 = null;
				goto IL_01fd;
				IL_01fd:
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
	private sealed class _003CRemoveFromSquad_003Ed__49 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string spiritId;

		public SpiritSquadViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private object _003C_003Es__3;

		private int _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01db: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_020f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0214: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 1u)
				{
					goto IL_0051;
				}
				TaskAwaiter awaiter;
				if (num == 2)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_022b;
				}
				if (!string.IsNullOrEmpty(spiritId) && _003C_003E4__this.IsActiveSquad)
				{
					_003C_003Es__1 = null;
					_003C_003Es__2 = 0;
					goto IL_0051;
				}
				goto end_IL_0007;
				IL_0051:
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
							goto IL_018c;
						}
						_003C_003Es__4 = 0;
					}
					try
					{
						TaskAwaiter awaiter3;
						if (num != 0)
						{
							awaiter3 = _003C_003E4__this._spiritActionService.RemoveFromSquadAsync(spiritId).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter3;
								_003CRemoveFromSquad_003Ed__49 _003CRemoveFromSquad_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRemoveFromSquad_003Ed__49>(ref awaiter3, ref _003CRemoveFromSquad_003Ed__);
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
						goto IL_01af;
					}
					_003Cex_003E5__5 = (global::System.Exception)_003C_003Es__3;
					awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to remove spirit from squad.").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter2;
						_003CRemoveFromSquad_003Ed__49 _003CRemoveFromSquad_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRemoveFromSquad_003Ed__49>(ref awaiter2, ref _003CRemoveFromSquad_003Ed__);
						return;
					}
					goto IL_018c;
					IL_018c:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					Console.WriteLine(_003Cex_003E5__5.StackTrace);
					_003Cex_003E5__5 = null;
					goto IL_01af;
					IL_01af:
					_003C_003Es__3 = null;
				}
				catch (object obj)
				{
					_003C_003Es__1 = obj;
				}
				awaiter = _003C_003E4__this._popupService.ClosePopupAsync((object)null).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 2);
					_003C_003Eu__1 = awaiter;
					_003CRemoveFromSquad_003Ed__49 _003CRemoveFromSquad_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRemoveFromSquad_003Ed__49>(ref awaiter, ref _003CRemoveFromSquad_003Ed__);
					return;
				}
				goto IL_022b;
				IL_022b:
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
	private sealed class _003CSavedSquads_003Ed__50 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritSquadViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_013e;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._spiritActionService.GoToSavedSquads().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CSavedSquads_003Ed__50 _003CSavedSquads_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSavedSquads_003Ed__50>(ref awaiter2, ref _003CSavedSquads_003Ed__);
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
					goto IL_0150;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Navigation Error", _003Cex_003E5__3.Message).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CSavedSquads_003Ed__50 _003CSavedSquads_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSavedSquads_003Ed__50>(ref awaiter, ref _003CSavedSquads_003Ed__);
					return;
				}
				goto IL_013e;
				IL_013e:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__3 = null;
				goto IL_0150;
				IL_0150:
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
	private sealed class _003CSetSlotModelAsync_003Ed__43 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public int slotIndex;

		public string spiritId;

		public SpiritSquadViewModel _003C_003E4__this;

		private SpiritCardModel _003Cmodel_003E5__1;

		private SpiritCardModel _003C_003Es__2;

		private int _003C_003Es__3;

		private TaskAwaiter<SpiritCardModel> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<SpiritCardModel> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<SpiritCardModel>);
					num = (_003C_003E1__state = -1);
					goto IL_00b3;
				}
				if (!string.IsNullOrEmpty(spiritId))
				{
					_003C_003E4__this.ReleaseSlot(slotIndex);
					awaiter = _003C_003E4__this._modelFactory.CreateModelAsync(spiritId).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CSetSlotModelAsync_003Ed__43 _003CSetSlotModelAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<SpiritCardModel>, _003CSetSlotModelAsync_003Ed__43>(ref awaiter, ref _003CSetSlotModelAsync_003Ed__);
						return;
					}
					goto IL_00b3;
				}
				_003C_003E4__this.ClearSlot(slotIndex);
				goto end_IL_0007;
				IL_00b3:
				_003C_003Es__2 = awaiter.GetResult();
				_003Cmodel_003E5__1 = _003C_003Es__2;
				_003C_003Es__2 = null;
				int num2 = slotIndex;
				_003C_003Es__3 = num2;
				switch (_003C_003Es__3)
				{
				case 0:
					_003C_003E4__this._slot1Model = _003Cmodel_003E5__1;
					_003C_003E4__this._slot1AcquiredId = spiritId;
					_003C_003E4__this._slot1VM?.Dispose();
					_003C_003E4__this._slot1VM = null;
					break;
				case 1:
					_003C_003E4__this._slot2Model = _003Cmodel_003E5__1;
					_003C_003E4__this._slot2AcquiredId = spiritId;
					_003C_003E4__this._slot2VM?.Dispose();
					_003C_003E4__this._slot2VM = null;
					break;
				case 2:
					_003C_003E4__this._slot3Model = _003Cmodel_003E5__1;
					_003C_003E4__this._slot3AcquiredId = spiritId;
					_003C_003E4__this._slot3VM?.Dispose();
					_003C_003E4__this._slot3VM = null;
					break;
				}
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cmodel_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cmodel_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IPlayerStateService _playerState;

	private readonly INavigationService _navigationService;

	private readonly IBottomSheetService _bottomSheetService;

	private readonly IPopupService _popupService;

	private readonly ISpiritActionService _spiritActionService;

	private readonly SpiritCardModelFactory _modelFactory;

	private readonly IServiceProvider _serviceProvider;

	private bool _disposed;

	private SpiritCardModel? _slot1Model;

	private SpiritCardModel? _slot2Model;

	private SpiritCardModel? _slot3Model;

	private string? _slot1AcquiredId;

	private string? _slot2AcquiredId;

	private string? _slot3AcquiredId;

	private SpiritCardViewModel? _slot1VM;

	private SpiritCardViewModel? _slot2VM;

	private SpiritCardViewModel? _slot3VM;

	[ObservableProperty]
	[NotifyPropertyChangedFor("HasSpirits")]
	[NotifyPropertyChangedFor("SquadCompleteness")]
	private bool _isLoading;

	[ObservableProperty]
	private bool _isActiveSquad;

	[ObservableProperty]
	private int _squadSlot = 1;

	[ObservableProperty]
	public bool _isActiveSquadSheet;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<string>? removeFromSquadCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? savedSquadsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<string>? navigateToSpiritDetailsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? openSpiritsHoldNavigationCommand;

	public string SquadDisplayName => $"Squad {SquadSlot}";

	public SpiritCardViewModel? Slot1
	{
		get
		{
			if (_slot1Model == null)
			{
				return null;
			}
			if (_slot1VM == null || _slot1VM.Model != _slot1Model)
			{
				_slot1VM = SpiritCardViewModelHelper.CreateViewModel(_serviceProvider, _slot1Model);
			}
			return _slot1VM;
		}
	}

	public SpiritCardViewModel? Slot2
	{
		get
		{
			if (_slot2Model == null)
			{
				return null;
			}
			if (_slot2VM == null || _slot2VM.Model != _slot2Model)
			{
				_slot2VM = SpiritCardViewModelHelper.CreateViewModel(_serviceProvider, _slot2Model);
			}
			return _slot2VM;
		}
	}

	public SpiritCardViewModel? Slot3
	{
		get
		{
			if (_slot3Model == null)
			{
				return null;
			}
			if (_slot3VM == null || _slot3VM.Model != _slot3Model)
			{
				_slot3VM = SpiritCardViewModelHelper.CreateViewModel(_serviceProvider, _slot3Model);
			}
			return _slot3VM;
		}
	}

	public bool HasSpirits => _slot1Model != null || _slot2Model != null || _slot3Model != null;

	public string SquadCompleteness => $"{GetFilledSlots()}/3 slots filled";

	public bool IsSquadFull => GetFilledSlots() == 3;

	public bool IsSquadEmpty => GetFilledSlots() == 0;

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
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasSpirits);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SquadCompleteness);
				_isLoading = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsLoading);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasSpirits);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SquadCompleteness);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsActiveSquad
	{
		get
		{
			return _isActiveSquad;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isActiveSquad, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsActiveSquad);
				_isActiveSquad = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsActiveSquad);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int SquadSlot
	{
		get
		{
			return _squadSlot;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_squadSlot, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SquadSlot);
				_squadSlot = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SquadSlot);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsActiveSquadSheet
	{
		get
		{
			return _isActiveSquadSheet;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isActiveSquadSheet, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsActiveSquadSheet);
				_isActiveSquadSheet = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsActiveSquadSheet);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<string> RemoveFromSquadCommand => (IAsyncRelayCommand<string>)(object)(removeFromSquadCommand ?? (removeFromSquadCommand = new AsyncRelayCommand<string>((Func<string, global::System.Threading.Tasks.Task>)RemoveFromSquad)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand SavedSquadsCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = savedSquadsCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)SavedSquads);
				AsyncRelayCommand val2 = val;
				savedSquadsCommand = val;
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
	public IAsyncRelayCommand OpenSpiritsHoldNavigationCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = openSpiritsHoldNavigationCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)OpenSpiritsHoldNavigation);
				AsyncRelayCommand val2 = val;
				openSpiritsHoldNavigationCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public SpiritSquadViewModel(INavigationService navigationService, IPopupService popupService, IBottomSheetService bottomSheetService, ISpiritActionService spiritActionService, SpiritCardModelFactory modelFactory, IServiceProvider serviceProvider, IPlayerStateService playerStateService, bool isActiveSquad = true, bool skipInitialLoad = false)
	{
		_navigationService = navigationService;
		_popupService = popupService;
		_spiritActionService = spiritActionService;
		_bottomSheetService = bottomSheetService;
		_isActiveSquad = isActiveSquad;
		_modelFactory = modelFactory;
		_serviceProvider = serviceProvider;
		_playerState = playerStateService;
		_playerState.StateChanged += OnPlayerStateChanged;
		if (!skipInitialLoad)
		{
			LoadSquadSlots();
		}
	}

	private void OnPlayerStateChanged(object? sender, StateChangedEventArgs e)
	{
		if (e.Scope != 0 || e.ChangeType != "Squad")
		{
			return;
		}
		object obj = default(object);
		object obj2 = default(object);
		if (e.ChangedValues.TryGetValue("squads", ref obj) && obj is Dictionary<string, List<string>> val && e.ChangedValues.TryGetValue("activeSquadSlot", ref obj2) && obj2 is int num)
		{
			string text = num.ToString();
			List<string> updatedSquadComposition = default(List<string>);
			if (val.TryGetValue(text, ref updatedSquadComposition))
			{
				CheckIfInSquad(updatedSquadComposition);
			}
		}
		((ObservableObject)this).OnPropertyChanged("HasSpirits");
		((ObservableObject)this).OnPropertyChanged("IsSquadEmpty");
		((ObservableObject)this).OnPropertyChanged("SquadCompleteness");
	}

	[AsyncStateMachine(typeof(_003CCheckIfInSquad_003Ed__39))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task CheckIfInSquad(List<string> updatedSquadComposition)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CCheckIfInSquad_003Ed__39 _003CCheckIfInSquad_003Ed__ = new _003CCheckIfInSquad_003Ed__39();
		_003CCheckIfInSquad_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CCheckIfInSquad_003Ed__._003C_003E4__this = this;
		_003CCheckIfInSquad_003Ed__.updatedSquadComposition = updatedSquadComposition;
		_003CCheckIfInSquad_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CCheckIfInSquad_003Ed__._003C_003Et__builder)).Start<_003CCheckIfInSquad_003Ed__39>(ref _003CCheckIfInSquad_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CCheckIfInSquad_003Ed__._003C_003Et__builder)).Task;
	}

	private SpiritCardModel? GetSlotModel(int slotIndex)
	{
		if (1 == 0)
		{
		}
		SpiritCardModel result = slotIndex switch
		{
			0 => _slot1Model, 
			1 => _slot2Model, 
			2 => _slot3Model, 
			_ => null, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	private string GetSlotPropertyName(int slotIndex)
	{
		if (1 == 0)
		{
		}
		string result = slotIndex switch
		{
			0 => "Slot1", 
			1 => "Slot2", 
			2 => "Slot3", 
			_ => string.Empty, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	[AsyncStateMachine(typeof(_003CLoadSquadSlots_003Ed__42))]
	[DebuggerStepThrough]
	public void LoadSquadSlots()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadSquadSlots_003Ed__42 _003CLoadSquadSlots_003Ed__ = new _003CLoadSquadSlots_003Ed__42();
		_003CLoadSquadSlots_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CLoadSquadSlots_003Ed__._003C_003E4__this = this;
		_003CLoadSquadSlots_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CLoadSquadSlots_003Ed__._003C_003Et__builder)).Start<_003CLoadSquadSlots_003Ed__42>(ref _003CLoadSquadSlots_003Ed__);
	}

	[AsyncStateMachine(typeof(_003CSetSlotModelAsync_003Ed__43))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task SetSlotModelAsync(int slotIndex, string? spiritId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSetSlotModelAsync_003Ed__43 _003CSetSlotModelAsync_003Ed__ = new _003CSetSlotModelAsync_003Ed__43();
		_003CSetSlotModelAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSetSlotModelAsync_003Ed__._003C_003E4__this = this;
		_003CSetSlotModelAsync_003Ed__.slotIndex = slotIndex;
		_003CSetSlotModelAsync_003Ed__.spiritId = spiritId;
		_003CSetSlotModelAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSetSlotModelAsync_003Ed__._003C_003Et__builder)).Start<_003CSetSlotModelAsync_003Ed__43>(ref _003CSetSlotModelAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSetSlotModelAsync_003Ed__._003C_003Et__builder)).Task;
	}

	private void ReleaseSlot(int slotIndex)
	{
		switch (slotIndex)
		{
		case 0:
			if (!string.IsNullOrEmpty(_slot1AcquiredId))
			{
				_modelFactory.ReleaseModel(_slot1AcquiredId);
			}
			_slot1AcquiredId = null;
			break;
		case 1:
			if (!string.IsNullOrEmpty(_slot2AcquiredId))
			{
				_modelFactory.ReleaseModel(_slot2AcquiredId);
			}
			_slot2AcquiredId = null;
			break;
		case 2:
			if (!string.IsNullOrEmpty(_slot3AcquiredId))
			{
				_modelFactory.ReleaseModel(_slot3AcquiredId);
			}
			_slot3AcquiredId = null;
			break;
		}
	}

	private void ClearSlot(int slotIndex)
	{
		ReleaseSlot(slotIndex);
		switch (slotIndex)
		{
		case 0:
			_slot1Model = null;
			_slot1VM?.Dispose();
			_slot1VM = null;
			break;
		case 1:
			_slot2Model = null;
			_slot2VM?.Dispose();
			_slot2VM = null;
			break;
		case 2:
			_slot3Model = null;
			_slot3VM?.Dispose();
			_slot3VM = null;
			break;
		}
	}

	private List<string> GetCurrentSquadComposition()
	{
		if (_playerState.GetActiveSquad() == null)
		{
			List<string> obj = new List<string>();
			obj.Add("");
			obj.Add("");
			obj.Add("");
			return obj;
		}
		if (IsActiveSquad)
		{
			return Enumerable.ToList<string>(Enumerable.Select<PlayerSpirit, string>((global::System.Collections.Generic.IEnumerable<PlayerSpirit>)_playerState.GetActiveSquad(), (Func<PlayerSpirit, string>)((PlayerSpirit s) => s.PlayerSpiritID)));
		}
		List<string> result = default(List<string>);
		if (_playerState.GetSquads().TryGetValue(SquadSlot.ToString(), ref result))
		{
			return result;
		}
		List<string> obj2 = new List<string>();
		obj2.Add("");
		obj2.Add("");
		obj2.Add("");
		return obj2;
	}

	private void ClearAllSlots()
	{
		ClearSlot(0);
		ClearSlot(1);
		ClearSlot(2);
		((ObservableObject)this).OnPropertyChanged("Slot1");
		((ObservableObject)this).OnPropertyChanged("Slot2");
		((ObservableObject)this).OnPropertyChanged("Slot3");
		((ObservableObject)this).OnPropertyChanged("HasSpirits");
		((ObservableObject)this).OnPropertyChanged("SquadCompleteness");
	}

	private int GetFilledSlots()
	{
		int num = 0;
		if (_slot1Model != null)
		{
			num++;
		}
		if (_slot2Model != null)
		{
			num++;
		}
		if (_slot3Model != null)
		{
			num++;
		}
		return num;
	}

	[AsyncStateMachine(typeof(_003CRemoveFromSquad_003Ed__49))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task RemoveFromSquad(string spiritId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRemoveFromSquad_003Ed__49 _003CRemoveFromSquad_003Ed__ = new _003CRemoveFromSquad_003Ed__49();
		_003CRemoveFromSquad_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRemoveFromSquad_003Ed__._003C_003E4__this = this;
		_003CRemoveFromSquad_003Ed__.spiritId = spiritId;
		_003CRemoveFromSquad_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRemoveFromSquad_003Ed__._003C_003Et__builder)).Start<_003CRemoveFromSquad_003Ed__49>(ref _003CRemoveFromSquad_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRemoveFromSquad_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSavedSquads_003Ed__50))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task SavedSquads()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSavedSquads_003Ed__50 _003CSavedSquads_003Ed__ = new _003CSavedSquads_003Ed__50();
		_003CSavedSquads_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSavedSquads_003Ed__._003C_003E4__this = this;
		_003CSavedSquads_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSavedSquads_003Ed__._003C_003Et__builder)).Start<_003CSavedSquads_003Ed__50>(ref _003CSavedSquads_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSavedSquads_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CNavigateToSpiritDetails_003Ed__51))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task NavigateToSpiritDetails(string id)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CNavigateToSpiritDetails_003Ed__51 _003CNavigateToSpiritDetails_003Ed__ = new _003CNavigateToSpiritDetails_003Ed__51();
		_003CNavigateToSpiritDetails_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CNavigateToSpiritDetails_003Ed__._003C_003E4__this = this;
		_003CNavigateToSpiritDetails_003Ed__.id = id;
		_003CNavigateToSpiritDetails_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CNavigateToSpiritDetails_003Ed__._003C_003Et__builder)).Start<_003CNavigateToSpiritDetails_003Ed__51>(ref _003CNavigateToSpiritDetails_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CNavigateToSpiritDetails_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003COpenSpiritsHoldNavigation_003Ed__52))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task OpenSpiritsHoldNavigation()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COpenSpiritsHoldNavigation_003Ed__52 _003COpenSpiritsHoldNavigation_003Ed__ = new _003COpenSpiritsHoldNavigation_003Ed__52();
		_003COpenSpiritsHoldNavigation_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003COpenSpiritsHoldNavigation_003Ed__._003C_003E4__this = this;
		_003COpenSpiritsHoldNavigation_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003COpenSpiritsHoldNavigation_003Ed__._003C_003Et__builder)).Start<_003COpenSpiritsHoldNavigation_003Ed__52>(ref _003COpenSpiritsHoldNavigation_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003COpenSpiritsHoldNavigation_003Ed__._003C_003Et__builder)).Task;
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			_playerState.StateChanged -= OnPlayerStateChanged;
			ReleaseSlot(0);
			ReleaseSlot(1);
			ReleaseSlot(2);
			_slot1VM?.Dispose();
			_slot2VM?.Dispose();
			_slot3VM?.Dispose();
			_slot1Model = null;
			_slot2Model = null;
			_slot3Model = null;
			_slot1VM = null;
			_slot2VM = null;
			_slot3VM = null;
			_disposed = true;
			GC.SuppressFinalize((object)this);
		}
	}
}
