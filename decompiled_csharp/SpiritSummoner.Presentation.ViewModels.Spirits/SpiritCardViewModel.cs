using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.Events;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Items;
using SpiritSummoner.Domain.Entities.Items;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Enums.Items;
using SpiritSummoner.Domain.Enums.Shops;
using SpiritSummoner.Infrastructure.Services;
using SpiritSummoner.Presentation.Models;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.ViewModels.Shared;

namespace SpiritSummoner.Presentation.ViewModels.Spirits;

public class SpiritCardViewModel : ObservableObject, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003CAddToSquadPosition_003Ed__37 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string position;

		public SpiritCardViewModel _003C_003E4__this;

		private int _003CsquadPosition_003E5__1;

		private object _003C_003Es__2;

		private int _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_016f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0)
				{
					goto IL_004f;
				}
				TaskAwaiter awaiter;
				if (num == 1)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01bd;
				}
				if (int.TryParse(position, ref _003CsquadPosition_003E5__1) && _003C_003E4__this.CanPerformActions)
				{
					_003C_003Es__3 = 0;
					goto IL_004f;
				}
				goto end_IL_0007;
				IL_01bd:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__4 = null;
				goto IL_01cf;
				IL_012c:
				int num2 = _003C_003Es__3;
				if (num2 != 1)
				{
					goto IL_01cf;
				}
				_003Cex_003E5__4 = (global::System.Exception)_003C_003Es__2;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to add spirit to squad position.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CAddToSquadPosition_003Ed__37 _003CAddToSquadPosition_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAddToSquadPosition_003Ed__37>(ref awaiter, ref _003CAddToSquadPosition_003Ed__);
					return;
				}
				goto IL_01bd;
				IL_004f:
				try
				{
					TaskAwaiter awaiter2;
					if (num == 0)
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0101;
					}
					if (_003C_003E4__this._model != null && !string.IsNullOrEmpty(_003C_003E4__this._model.PlayerSpiritId))
					{
						awaiter2 = _003C_003E4__this._spiritActionService.AddToSquadPositionAsync(_003C_003E4__this._model.PlayerSpiritId, _003CsquadPosition_003E5__1).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CAddToSquadPosition_003Ed__37 _003CAddToSquadPosition_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAddToSquadPosition_003Ed__37>(ref awaiter2, ref _003CAddToSquadPosition_003Ed__);
							return;
						}
						goto IL_0101;
					}
					goto end_IL_004f;
					IL_0101:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					_003C_003E4__this.IsSquadSelectionVisible = false;
					goto IL_012c;
					end_IL_004f:;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__2 = ex;
					_003C_003Es__3 = 1;
					goto IL_012c;
				}
				goto end_IL_0007;
				IL_01cf:
				_003C_003Es__2 = null;
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
	private sealed class _003CEditAttributes_003Ed__46 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritCardViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0)
				{
					goto IL_0049;
				}
				TaskAwaiter awaiter;
				if (num == 1)
				{
					awaiter = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_016c;
				}
				if (_003C_003E4__this.CanPerformActions && _003C_003E4__this._model != null)
				{
					_003C_003Es__2 = 0;
					goto IL_0049;
				}
				goto end_IL_0007;
				IL_016c:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__3 = null;
				goto IL_017e;
				IL_0049:
				try
				{
					TaskAwaiter<bool> awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._spiritActionService.EditAttributesAsync(_003C_003E4__this._model).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CEditAttributes_003Ed__46 _003CEditAttributes_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CEditAttributes_003Ed__46>(ref awaiter2, ref _003CEditAttributes_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
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
					goto IL_017e;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to open attributes editor.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__2 = awaiter;
					_003CEditAttributes_003Ed__46 _003CEditAttributes_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CEditAttributes_003Ed__46>(ref awaiter, ref _003CEditAttributes_003Ed__);
					return;
				}
				goto IL_016c;
				IL_017e:
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
	private sealed class _003CEditGear_003Ed__48 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritCardViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private InsufficientFundsResult _003Cresult_003E5__3;

		private InsufficientFundsResult _003CfundsResult_003E5__4;

		private InsufficientFundsResult _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<InsufficientFundsResult> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0284: Unknown result type (might be due to invalid IL or missing references)
			//IL_0289: Unknown result type (might be due to invalid IL or missing references)
			//IL_029e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0205: Unknown result type (might be due to invalid IL or missing references)
			//IL_020a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0212: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_016f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 2u)
				{
					goto IL_004a;
				}
				TaskAwaiter awaiter;
				if (num == 3)
				{
					awaiter = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_02d6;
				}
				if (_003C_003E4__this.CanPerformActions && _003C_003E4__this._model != null)
				{
					_003C_003Es__2 = 0;
					goto IL_004a;
				}
				goto end_IL_0007;
				IL_02d6:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__6 = null;
				goto IL_02e8;
				IL_004a:
				try
				{
					TaskAwaiter<InsufficientFundsResult> awaiter4;
					TaskAwaiter awaiter3;
					TaskAwaiter awaiter2;
					switch (num)
					{
					default:
						awaiter4 = _003C_003E4__this._spiritActionService.EditGearsAsync(_003C_003E4__this._model, _003C_003E4__this.Gear).GetAwaiter();
						if (!awaiter4.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter4;
							_003CEditGear_003Ed__48 _003CEditGear_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<InsufficientFundsResult>, _003CEditGear_003Ed__48>(ref awaiter4, ref _003CEditGear_003Ed__);
							return;
						}
						goto IL_00e3;
					case 0:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<InsufficientFundsResult>);
						num = (_003C_003E1__state = -1);
						goto IL_00e3;
					case 1:
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01aa;
					case 2:
						{
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_01aa:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						goto IL_01b2;
						IL_00e3:
						_003C_003Es__5 = awaiter4.GetResult();
						_003Cresult_003E5__3 = _003C_003Es__5;
						_003CfundsResult_003E5__4 = _003Cresult_003E5__3;
						if (_003CfundsResult_003E5__4 == InsufficientFundsResult.Shop)
						{
							if (_003C_003E4__this._playerState.CurrentRoute.TrimStart('/').Split('/', (StringSplitOptions)0).Length > 1)
							{
								awaiter3 = _003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter3;
									_003CEditGear_003Ed__48 _003CEditGear_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CEditGear_003Ed__48>(ref awaiter3, ref _003CEditGear_003Ed__);
									return;
								}
								goto IL_01aa;
							}
							goto IL_01b2;
						}
						goto end_IL_004a;
						IL_01b2:
						awaiter2 = _003C_003E4__this._navBarVM.NavigateToCommand.ExecuteAsync("//shop").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter2;
							_003CEditGear_003Ed__48 _003CEditGear_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CEditGear_003Ed__48>(ref awaiter2, ref _003CEditGear_003Ed__);
							return;
						}
						break;
					}
					((TaskAwaiter)(ref awaiter2)).GetResult();
					end_IL_004a:;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_02e8;
				}
				_003Cex_003E5__6 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error showing popup", _003Cex_003E5__6.Message).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 3);
					_003C_003Eu__2 = awaiter;
					_003CEditGear_003Ed__48 _003CEditGear_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CEditGear_003Ed__48>(ref awaiter, ref _003CEditGear_003Ed__);
					return;
				}
				goto IL_02d6;
				IL_02e8:
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
	private sealed class _003CEditMoves_003Ed__47 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritCardViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter<InsufficientFundsResult> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0)
				{
					goto IL_0049;
				}
				TaskAwaiter awaiter;
				if (num == 1)
				{
					awaiter = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_017c;
				}
				if (_003C_003E4__this.CanPerformActions && _003C_003E4__this._model != null)
				{
					_003C_003Es__2 = 0;
					goto IL_0049;
				}
				goto end_IL_0007;
				IL_017c:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__3 = null;
				goto IL_018e;
				IL_0049:
				try
				{
					TaskAwaiter<InsufficientFundsResult> awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._spiritActionService.EditMovesAsync(_003C_003E4__this._model, _003C_003E4__this._model.SpiritMoves).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CEditMoves_003Ed__47 _003CEditMoves_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<InsufficientFundsResult>, _003CEditMoves_003Ed__47>(ref awaiter2, ref _003CEditMoves_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<InsufficientFundsResult>);
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
					goto IL_018e;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to open moves editor.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__2 = awaiter;
					_003CEditMoves_003Ed__47 _003CEditMoves_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CEditMoves_003Ed__47>(ref awaiter, ref _003CEditMoves_003Ed__);
					return;
				}
				goto IL_017c;
				IL_018e:
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
	private sealed class _003CEditTalent_003Ed__49 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritCardViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private InsufficientFundsResult _003Cresult_003E5__3;

		private InsufficientFundsResult _003CfundsResult_003E5__4;

		private InsufficientFundsResult _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<InsufficientFundsResult> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0284: Unknown result type (might be due to invalid IL or missing references)
			//IL_0289: Unknown result type (might be due to invalid IL or missing references)
			//IL_029e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0205: Unknown result type (might be due to invalid IL or missing references)
			//IL_020a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0212: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_016f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 2u)
				{
					goto IL_004a;
				}
				TaskAwaiter awaiter;
				if (num == 3)
				{
					awaiter = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_02d6;
				}
				if (_003C_003E4__this.CanPerformActions && _003C_003E4__this._model != null)
				{
					_003C_003Es__2 = 0;
					goto IL_004a;
				}
				goto end_IL_0007;
				IL_02d6:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__6 = null;
				goto IL_02e8;
				IL_004a:
				try
				{
					TaskAwaiter<InsufficientFundsResult> awaiter4;
					TaskAwaiter awaiter3;
					TaskAwaiter awaiter2;
					switch (num)
					{
					default:
						awaiter4 = _003C_003E4__this._spiritActionService.EditTalentsAsync(_003C_003E4__this._model, _003C_003E4__this.Talent).GetAwaiter();
						if (!awaiter4.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter4;
							_003CEditTalent_003Ed__49 _003CEditTalent_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<InsufficientFundsResult>, _003CEditTalent_003Ed__49>(ref awaiter4, ref _003CEditTalent_003Ed__);
							return;
						}
						goto IL_00e3;
					case 0:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<InsufficientFundsResult>);
						num = (_003C_003E1__state = -1);
						goto IL_00e3;
					case 1:
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01aa;
					case 2:
						{
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_01aa:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						goto IL_01b2;
						IL_00e3:
						_003C_003Es__5 = awaiter4.GetResult();
						_003Cresult_003E5__3 = _003C_003Es__5;
						_003CfundsResult_003E5__4 = _003Cresult_003E5__3;
						if (_003CfundsResult_003E5__4 == InsufficientFundsResult.Shop)
						{
							if (_003C_003E4__this._playerState.CurrentRoute.TrimStart('/').Split('/', (StringSplitOptions)0).Length > 1)
							{
								awaiter3 = _003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter3;
									_003CEditTalent_003Ed__49 _003CEditTalent_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CEditTalent_003Ed__49>(ref awaiter3, ref _003CEditTalent_003Ed__);
									return;
								}
								goto IL_01aa;
							}
							goto IL_01b2;
						}
						goto end_IL_004a;
						IL_01b2:
						awaiter2 = _003C_003E4__this._navBarVM.NavigateToCommand.ExecuteAsync("//shop").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__2 = awaiter2;
							_003CEditTalent_003Ed__49 _003CEditTalent_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CEditTalent_003Ed__49>(ref awaiter2, ref _003CEditTalent_003Ed__);
							return;
						}
						break;
					}
					((TaskAwaiter)(ref awaiter2)).GetResult();
					end_IL_004a:;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_02e8;
				}
				_003Cex_003E5__6 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error showing popup", _003Cex_003E5__6.Message).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 3);
					_003C_003Eu__2 = awaiter;
					_003CEditTalent_003Ed__49 _003CEditTalent_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CEditTalent_003Ed__49>(ref awaiter, ref _003CEditTalent_003Ed__);
					return;
				}
				goto IL_02d6;
				IL_02e8:
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
	private sealed class _003CGoToSpiritDetails_003Ed__36 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritCardViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0)
				{
					goto IL_0039;
				}
				TaskAwaiter awaiter;
				if (num == 1)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0181;
				}
				if (_003C_003E4__this.CanPerformActions)
				{
					_003C_003Es__2 = 0;
					goto IL_0039;
				}
				goto end_IL_0007;
				IL_0193:
				_003C_003Es__1 = null;
				goto end_IL_0007;
				IL_0181:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__3 = null;
				goto IL_0193;
				IL_0039:
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._navigationService.NavigateToAsync(_003C_003E4__this._playerState.CurrentRoute + "/spiritdetails?spiritId=" + _003C_003E4__this._model.PlayerSpiritId).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CGoToSpiritDetails_003Ed__36 _003CGoToSpiritDetails_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToSpiritDetails_003Ed__36>(ref awaiter2, ref _003CGoToSpiritDetails_003Ed__);
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
					goto IL_0193;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Navigation Error", _003Cex_003E5__3.Message).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CGoToSpiritDetails_003Ed__36 _003CGoToSpiritDetails_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToSpiritDetails_003Ed__36>(ref awaiter, ref _003CGoToSpiritDetails_003Ed__);
					return;
				}
				goto IL_0181;
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
	private sealed class _003CLoadGearAsync_003Ed__42 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritCardViewModel _003C_003E4__this;

		private string _003CitemId_003E5__1;

		private Item _003Citem_003E5__2;

		private Item _003C_003Es__3;

		private TaskAwaiter<Item?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<Item> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Item>);
					num = (_003C_003E1__state = -1);
					goto IL_00e3;
				}
				_003CitemId_003E5__1 = _003C_003E4__this.Model?.GearId;
				if (!string.IsNullOrEmpty(_003CitemId_003E5__1))
				{
					awaiter = _003C_003E4__this._getItemByIdUseCase.ExecuteAsync(_003CitemId_003E5__1, ItemType.gear).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CLoadGearAsync_003Ed__42 _003CLoadGearAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Item>, _003CLoadGearAsync_003Ed__42>(ref awaiter, ref _003CLoadGearAsync_003Ed__);
						return;
					}
					goto IL_00e3;
				}
				_003C_003E4__this.Gear = null;
				_003C_003E4__this._gearEffect = null;
				_003C_003E4__this.RefreshModelItemEffects();
				((ObservableObject)_003C_003E4__this).OnPropertyChanged("HasGear");
				goto end_IL_0007;
				IL_00e3:
				_003C_003Es__3 = awaiter.GetResult();
				_003Citem_003E5__2 = _003C_003Es__3;
				_003C_003Es__3 = null;
				_003C_003E4__this.Gear = ((_003Citem_003E5__2 != null) ? new ItemModel(_003Citem_003E5__2) : null);
				_003C_003E4__this._gearEffect = _003Citem_003E5__2?.Effect;
				_003C_003E4__this.RefreshModelItemEffects();
				((ObservableObject)_003C_003E4__this).OnPropertyChanged("HasGear");
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CitemId_003E5__1 = null;
				_003Citem_003E5__2 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CitemId_003E5__1 = null;
			_003Citem_003E5__2 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CLoadHeldItemAsync_003Ed__41 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritCardViewModel _003C_003E4__this;

		private string _003CitemId_003E5__1;

		private Item _003Citem_003E5__2;

		private Item _003C_003Es__3;

		private TaskAwaiter<Item?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<Item> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Item>);
					num = (_003C_003E1__state = -1);
					goto IL_00d2;
				}
				_003CitemId_003E5__1 = _003C_003E4__this.Model?.HeldItemId;
				if (!string.IsNullOrEmpty(_003CitemId_003E5__1))
				{
					awaiter = _003C_003E4__this._getItemByIdUseCase.ExecuteAsync(_003CitemId_003E5__1, ItemType.items).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CLoadHeldItemAsync_003Ed__41 _003CLoadHeldItemAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Item>, _003CLoadHeldItemAsync_003Ed__41>(ref awaiter, ref _003CLoadHeldItemAsync_003Ed__);
						return;
					}
					goto IL_00d2;
				}
				_003C_003E4__this.HeldItem = null;
				_003C_003E4__this._heldItemEffect = null;
				_003C_003E4__this.RefreshModelItemEffects();
				goto end_IL_0007;
				IL_00d2:
				_003C_003Es__3 = awaiter.GetResult();
				_003Citem_003E5__2 = _003C_003Es__3;
				_003C_003Es__3 = null;
				_003C_003E4__this.HeldItem = ((_003Citem_003E5__2 != null) ? new ItemModel(_003Citem_003E5__2) : null);
				_003C_003E4__this._heldItemEffect = _003Citem_003E5__2?.Effect;
				_003C_003E4__this.RefreshModelItemEffects();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CitemId_003E5__1 = null;
				_003Citem_003E5__2 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CitemId_003E5__1 = null;
			_003Citem_003E5__2 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CLoadTalentAsync_003Ed__43 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritCardViewModel _003C_003E4__this;

		private string _003CitemId_003E5__1;

		private Item _003Citem_003E5__2;

		private Item _003C_003Es__3;

		private TaskAwaiter<Item?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<Item> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Item>);
					num = (_003C_003E1__state = -1);
					goto IL_00e3;
				}
				_003CitemId_003E5__1 = _003C_003E4__this.Model?.TalentId;
				if (!string.IsNullOrEmpty(_003CitemId_003E5__1))
				{
					awaiter = _003C_003E4__this._getItemByIdUseCase.ExecuteAsync(_003CitemId_003E5__1, ItemType.talent).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CLoadTalentAsync_003Ed__43 _003CLoadTalentAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Item>, _003CLoadTalentAsync_003Ed__43>(ref awaiter, ref _003CLoadTalentAsync_003Ed__);
						return;
					}
					goto IL_00e3;
				}
				_003C_003E4__this.Talent = null;
				_003C_003E4__this._talentEffect = null;
				_003C_003E4__this.RefreshModelItemEffects();
				((ObservableObject)_003C_003E4__this).OnPropertyChanged("HasTalent");
				goto end_IL_0007;
				IL_00e3:
				_003C_003Es__3 = awaiter.GetResult();
				_003Citem_003E5__2 = _003C_003Es__3;
				_003C_003Es__3 = null;
				_003C_003E4__this.Talent = ((_003Citem_003E5__2 != null) ? new ItemModel(_003Citem_003E5__2) : null);
				_003C_003E4__this._talentEffect = _003Citem_003E5__2?.Effect;
				_003C_003E4__this.RefreshModelItemEffects();
				((ObservableObject)_003C_003E4__this).OnPropertyChanged("HasTalent");
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CitemId_003E5__1 = null;
				_003Citem_003E5__2 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CitemId_003E5__1 = null;
			_003Citem_003E5__2 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CRemoveFromSquad_003Ed__38 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritCardViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0)
				{
					goto IL_0039;
				}
				TaskAwaiter awaiter;
				if (num == 1)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0194;
				}
				if (_003C_003E4__this.CanPerformActions)
				{
					_003C_003Es__2 = 0;
					goto IL_0039;
				}
				goto end_IL_0007;
				IL_0039:
				try
				{
					TaskAwaiter awaiter2;
					if (num == 0)
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_00e5;
					}
					if (_003C_003E4__this._model != null && !string.IsNullOrEmpty(_003C_003E4__this._model.PlayerSpiritId))
					{
						awaiter2 = _003C_003E4__this._spiritActionService.RemoveFromSquadAsync(_003C_003E4__this._model.PlayerSpiritId).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CRemoveFromSquad_003Ed__38 _003CRemoveFromSquad_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRemoveFromSquad_003Ed__38>(ref awaiter2, ref _003CRemoveFromSquad_003Ed__);
							return;
						}
						goto IL_00e5;
					}
					goto end_IL_0039;
					IL_00e5:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					goto IL_0103;
					end_IL_0039:;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
					goto IL_0103;
				}
				goto end_IL_0007;
				IL_01a6:
				_003C_003Es__1 = null;
				goto end_IL_0007;
				IL_0103:
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_01a6;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to remove spirit from squad.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CRemoveFromSquad_003Ed__38 _003CRemoveFromSquad_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRemoveFromSquad_003Ed__38>(ref awaiter, ref _003CRemoveFromSquad_003Ed__);
					return;
				}
				goto IL_0194;
				IL_0194:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__3 = null;
				goto IL_01a6;
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
	private sealed class _003CSellSpirit_003Ed__45 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritCardViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private ValueTuple<bool, int> _003CsellResult_003E5__3;

		private ValueTuple<bool, int> _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<ValueTuple<bool, int>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_023d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0242: Unknown result type (might be due to invalid IL or missing references)
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			//IL_0259: Unknown result type (might be due to invalid IL or missing references)
			//IL_0274: Unknown result type (might be due to invalid IL or missing references)
			//IL_0279: Unknown result type (might be due to invalid IL or missing references)
			//IL_0281: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 1u)
				{
					goto IL_003a;
				}
				TaskAwaiter awaiter;
				if (num == 2)
				{
					awaiter = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0290;
				}
				if (_003C_003E4__this.CanPerformActions)
				{
					_003C_003Es__2 = 0;
					goto IL_003a;
				}
				goto end_IL_0007;
				IL_003a:
				try
				{
					TaskAwaiter<ValueTuple<bool, int>> awaiter2;
					if (num == 0)
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<ValueTuple<bool, int>>);
						num = (_003C_003E1__state = -1);
						goto IL_00f1;
					}
					TaskAwaiter awaiter3;
					if (num == 1)
					{
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01e0;
					}
					if (_003C_003E4__this._model != null && !string.IsNullOrEmpty(_003C_003E4__this._model.PlayerSpiritId))
					{
						awaiter2 = _003C_003E4__this._spiritActionService.SellSpiritAsync(_003C_003E4__this._model.PlayerSpiritId).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CSellSpirit_003Ed__45 _003CSellSpirit_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<ValueTuple<bool, int>>, _003CSellSpirit_003Ed__45>(ref awaiter2, ref _003CSellSpirit_003Ed__);
							return;
						}
						goto IL_00f1;
					}
					goto end_IL_003a;
					IL_00f1:
					_003C_003Es__4 = awaiter2.GetResult();
					_003CsellResult_003E5__3 = _003C_003Es__4;
					if (_003CsellResult_003E5__3.Item1)
					{
						awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Spirit Sold!", $"{_003C_003E4__this._model.Name} was sold! You earned {_003CsellResult_003E5__3.Item2} G!").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter3;
							_003CSellSpirit_003Ed__45 _003CSellSpirit_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSellSpirit_003Ed__45>(ref awaiter3, ref _003CSellSpirit_003Ed__);
							return;
						}
						goto IL_01e0;
					}
					goto IL_01ff;
					IL_01e0:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					goto IL_01ff;
					end_IL_003a:;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
					goto IL_01ff;
				}
				goto end_IL_0007;
				IL_02b3:
				_003C_003Es__1 = null;
				goto end_IL_0007;
				IL_01ff:
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_02b3;
				}
				_003Cex_003E5__5 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to set as partner spirit.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 2);
					_003C_003Eu__2 = awaiter;
					_003CSellSpirit_003Ed__45 _003CSellSpirit_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSellSpirit_003Ed__45>(ref awaiter, ref _003CSellSpirit_003Ed__);
					return;
				}
				goto IL_0290;
				IL_0290:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine(_003Cex_003E5__5.Message);
				_003Cex_003E5__5 = null;
				goto IL_02b3;
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
	private sealed class _003CSetAsPartner_003Ed__39 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritCardViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0)
				{
					goto IL_0049;
				}
				TaskAwaiter awaiter;
				if (num == 1)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01a4;
				}
				if (_003C_003E4__this.CanSetAsPartner && _003C_003E4__this.CanPerformActions)
				{
					_003C_003Es__2 = 0;
					goto IL_0049;
				}
				goto end_IL_0007;
				IL_01a4:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__3 = null;
				goto IL_01b6;
				IL_0113:
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_01b6;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to set as partner spirit.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CSetAsPartner_003Ed__39 _003CSetAsPartner_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSetAsPartner_003Ed__39>(ref awaiter, ref _003CSetAsPartner_003Ed__);
					return;
				}
				goto IL_01a4;
				IL_0049:
				try
				{
					TaskAwaiter awaiter2;
					if (num == 0)
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_00f5;
					}
					if (_003C_003E4__this._model != null && !string.IsNullOrEmpty(_003C_003E4__this._model.PlayerSpiritId))
					{
						awaiter2 = _003C_003E4__this._spiritActionService.SetAsPartnerAsync(_003C_003E4__this._model.PlayerSpiritId).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CSetAsPartner_003Ed__39 _003CSetAsPartner_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSetAsPartner_003Ed__39>(ref awaiter2, ref _003CSetAsPartner_003Ed__);
							return;
						}
						goto IL_00f5;
					}
					goto end_IL_0049;
					IL_00f5:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					goto IL_0113;
					end_IL_0049:;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
					goto IL_0113;
				}
				goto end_IL_0007;
				IL_01b6:
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
	private sealed class _003CSetFavorite_003Ed__40 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritCardViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0)
				{
					goto IL_0039;
				}
				TaskAwaiter awaiter;
				if (num == 1)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0194;
				}
				if (_003C_003E4__this.CanPerformActions)
				{
					_003C_003Es__2 = 0;
					goto IL_0039;
				}
				goto end_IL_0007;
				IL_0039:
				try
				{
					TaskAwaiter awaiter2;
					if (num == 0)
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_00e5;
					}
					if (_003C_003E4__this._model != null && !string.IsNullOrEmpty(_003C_003E4__this._model.PlayerSpiritId))
					{
						awaiter2 = _003C_003E4__this._spiritActionService.ToggleSpiritFavorite(_003C_003E4__this._model.PlayerSpiritId).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CSetFavorite_003Ed__40 _003CSetFavorite_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSetFavorite_003Ed__40>(ref awaiter2, ref _003CSetFavorite_003Ed__);
							return;
						}
						goto IL_00e5;
					}
					goto end_IL_0039;
					IL_00e5:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					goto IL_0103;
					end_IL_0039:;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
					goto IL_0103;
				}
				goto end_IL_0007;
				IL_01b7:
				_003C_003Es__1 = null;
				goto end_IL_0007;
				IL_0103:
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_01b7;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to set as partner spirit.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CSetFavorite_003Ed__40 _003CSetFavorite_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSetFavorite_003Ed__40>(ref awaiter, ref _003CSetFavorite_003Ed__);
					return;
				}
				goto IL_0194;
				IL_0194:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine(_003Cex_003E5__3.Message);
				_003Cex_003E5__3 = null;
				goto IL_01b7;
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

	private readonly IPlayerStateService _playerState;

	private readonly INavigationService _navigationService;

	private readonly ISpiritActionService _spiritActionService;

	private readonly PlayerInfoModel _playerInfoModel;

	private readonly NavBarViewModel _navBarVM;

	private readonly GetItemByIdUseCase _getItemByIdUseCase;

	private SpiritCardModel? _model;

	private bool _isLoading = false;

	private bool _disposed = false;

	private ItemEffect? _heldItemEffect;

	private ItemEffect? _gearEffect;

	private ItemEffect? _talentEffect;

	[ObservableProperty]
	private bool _isSquadSelectionVisible = false;

	[ObservableProperty]
	private ItemModel? _heldItem;

	[ObservableProperty]
	private ItemModel? _gear;

	[ObservableProperty]
	private ItemModel? _talent;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goToSpiritDetailsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<string>? addToSquadPositionCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? removeFromSquadCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? setAsPartnerCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? setFavoriteCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? sellSpiritCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? editAttributesCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? editMovesCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? editGearCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? editTalentCommand;

	public bool HasSpirit => _model != null;

	public bool CanPerformActions => HasSpirit && !_isLoading;

	public SpiritCardModel? Model => _model;

	public bool IsInActiveSquad => Enumerable.Any<PlayerSpirit>((global::System.Collections.Generic.IEnumerable<PlayerSpirit>)_playerState.GetActiveSquad(), (Func<PlayerSpirit, bool>)([CompilerGenerated] (PlayerSpirit s) => s?.PlayerSpiritID == _model?.PlayerSpiritId));

	public bool IsPartnerSpirit => _playerState.GetCurrentPlayer()?.PartnerSpiritId == _model?.PlayerSpiritId;

	public bool CanSetAsPartner => !IsPartnerSpirit;

	public bool HasTalent => Talent != null;

	public bool HasGear => Gear != null;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsSquadSelectionVisible
	{
		get
		{
			return _isSquadSelectionVisible;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isSquadSelectionVisible, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsSquadSelectionVisible);
				_isSquadSelectionVisible = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsSquadSelectionVisible);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ItemModel? HeldItem
	{
		get
		{
			return _heldItem;
		}
		set
		{
			if (!EqualityComparer<ItemModel>.Default.Equals(_heldItem, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HeldItem);
				_heldItem = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HeldItem);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ItemModel? Gear
	{
		get
		{
			return _gear;
		}
		set
		{
			if (!EqualityComparer<ItemModel>.Default.Equals(_gear, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Gear);
				_gear = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Gear);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ItemModel? Talent
	{
		get
		{
			return _talent;
		}
		set
		{
			if (!EqualityComparer<ItemModel>.Default.Equals(_talent, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Talent);
				_talent = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Talent);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand GoToSpiritDetailsCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = goToSpiritDetailsCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)GoToSpiritDetails);
				AsyncRelayCommand val2 = val;
				goToSpiritDetailsCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<string> AddToSquadPositionCommand => (IAsyncRelayCommand<string>)(object)(addToSquadPositionCommand ?? (addToSquadPositionCommand = new AsyncRelayCommand<string>((Func<string, global::System.Threading.Tasks.Task>)AddToSquadPosition)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand RemoveFromSquadCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = removeFromSquadCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)RemoveFromSquad);
				AsyncRelayCommand val2 = val;
				removeFromSquadCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand SetAsPartnerCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = setAsPartnerCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)SetAsPartner);
				AsyncRelayCommand val2 = val;
				setAsPartnerCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand SetFavoriteCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = setFavoriteCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)SetFavorite);
				AsyncRelayCommand val2 = val;
				setFavoriteCommand = val;
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
	public IAsyncRelayCommand EditAttributesCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = editAttributesCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)EditAttributes);
				AsyncRelayCommand val2 = val;
				editAttributesCommand = val;
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
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)EditMoves);
				AsyncRelayCommand val2 = val;
				editMovesCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand EditGearCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = editGearCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)EditGear);
				AsyncRelayCommand val2 = val;
				editGearCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand EditTalentCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = editTalentCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)EditTalent);
				AsyncRelayCommand val2 = val;
				editTalentCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public SpiritCardViewModel(IPlayerStateService playerState, INavigationService navigationService, ISpiritActionService spiritActionService, PlayerInfoModel playerInfoModel, NavBarViewModel navBarViewModel, GetItemByIdUseCase getItemByIdUseCase)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		_playerState = playerState;
		_navigationService = navigationService;
		_spiritActionService = spiritActionService;
		_playerInfoModel = playerInfoModel;
		_navBarVM = navBarViewModel;
		_getItemByIdUseCase = getItemByIdUseCase;
		((ObservableObject)_playerInfoModel).PropertyChanged += new PropertyChangedEventHandler(OnPlayerInfoModelPropertyChanged);
		_playerState.StateChanged += OnStateChanged;
	}

	public void SetModel(SpiritCardModel model)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_model = model ?? throw new ArgumentNullException("model");
		LoadGearAsync();
		LoadTalentAsync();
		LoadHeldItemAsync();
		((ObservableObject)this).OnPropertyChanged("HasSpirit");
		((ObservableObject)this).OnPropertyChanged("CanPerformActions");
		((ObservableObject)this).OnPropertyChanged("Model");
		((ObservableObject)this).OnPropertyChanged("IsInActiveSquad");
		((ObservableObject)this).OnPropertyChanged("IsPartnerSpirit");
		((ObservableObject)this).OnPropertyChanged("CanSetAsPartner");
	}

	private void OnStateChanged(object? sender, StateChangedEventArgs e)
	{
		if (e.EntityId != _model?.PlayerSpiritId)
		{
			return;
		}
		StateChangeScope scope = e.Scope;
		StateChangeScope stateChangeScope = scope;
		if (stateChangeScope != StateChangeScope.Spirit)
		{
			return;
		}
		string changeType = e.ChangeType;
		string text = changeType;
		if (!(text == "Gear"))
		{
			if (!(text == "Talent"))
			{
				if (text == "HeldItem")
				{
					LoadHeldItemAsync();
				}
			}
			else
			{
				LoadTalentAsync();
			}
		}
		else
		{
			LoadGearAsync();
		}
	}

	private void OnPlayerInfoModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		string text = propertyName;
		if (!(text == "PartnerSpiritId"))
		{
			if (text == "PlayerSquads")
			{
				((ObservableObject)this).OnPropertyChanged("IsInActiveSquad");
			}
		}
		else
		{
			((ObservableObject)this).OnPropertyChanged("IsPartnerSpirit");
			((ObservableObject)this).OnPropertyChanged("CanSetAsPartner");
		}
	}

	[AsyncStateMachine(typeof(_003CGoToSpiritDetails_003Ed__36))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoToSpiritDetails()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoToSpiritDetails_003Ed__36 _003CGoToSpiritDetails_003Ed__ = new _003CGoToSpiritDetails_003Ed__36();
		_003CGoToSpiritDetails_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoToSpiritDetails_003Ed__._003C_003E4__this = this;
		_003CGoToSpiritDetails_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoToSpiritDetails_003Ed__._003C_003Et__builder)).Start<_003CGoToSpiritDetails_003Ed__36>(ref _003CGoToSpiritDetails_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoToSpiritDetails_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CAddToSquadPosition_003Ed__37))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task AddToSquadPosition(string position)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CAddToSquadPosition_003Ed__37 _003CAddToSquadPosition_003Ed__ = new _003CAddToSquadPosition_003Ed__37();
		_003CAddToSquadPosition_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CAddToSquadPosition_003Ed__._003C_003E4__this = this;
		_003CAddToSquadPosition_003Ed__.position = position;
		_003CAddToSquadPosition_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CAddToSquadPosition_003Ed__._003C_003Et__builder)).Start<_003CAddToSquadPosition_003Ed__37>(ref _003CAddToSquadPosition_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CAddToSquadPosition_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRemoveFromSquad_003Ed__38))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task RemoveFromSquad()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRemoveFromSquad_003Ed__38 _003CRemoveFromSquad_003Ed__ = new _003CRemoveFromSquad_003Ed__38();
		_003CRemoveFromSquad_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRemoveFromSquad_003Ed__._003C_003E4__this = this;
		_003CRemoveFromSquad_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRemoveFromSquad_003Ed__._003C_003Et__builder)).Start<_003CRemoveFromSquad_003Ed__38>(ref _003CRemoveFromSquad_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRemoveFromSquad_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSetAsPartner_003Ed__39))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task SetAsPartner()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSetAsPartner_003Ed__39 _003CSetAsPartner_003Ed__ = new _003CSetAsPartner_003Ed__39();
		_003CSetAsPartner_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSetAsPartner_003Ed__._003C_003E4__this = this;
		_003CSetAsPartner_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSetAsPartner_003Ed__._003C_003Et__builder)).Start<_003CSetAsPartner_003Ed__39>(ref _003CSetAsPartner_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSetAsPartner_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSetFavorite_003Ed__40))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task SetFavorite()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSetFavorite_003Ed__40 _003CSetFavorite_003Ed__ = new _003CSetFavorite_003Ed__40();
		_003CSetFavorite_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSetFavorite_003Ed__._003C_003E4__this = this;
		_003CSetFavorite_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSetFavorite_003Ed__._003C_003Et__builder)).Start<_003CSetFavorite_003Ed__40>(ref _003CSetFavorite_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSetFavorite_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadHeldItemAsync_003Ed__41))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadHeldItemAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadHeldItemAsync_003Ed__41 _003CLoadHeldItemAsync_003Ed__ = new _003CLoadHeldItemAsync_003Ed__41();
		_003CLoadHeldItemAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadHeldItemAsync_003Ed__._003C_003E4__this = this;
		_003CLoadHeldItemAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadHeldItemAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadHeldItemAsync_003Ed__41>(ref _003CLoadHeldItemAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadHeldItemAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadGearAsync_003Ed__42))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadGearAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadGearAsync_003Ed__42 _003CLoadGearAsync_003Ed__ = new _003CLoadGearAsync_003Ed__42();
		_003CLoadGearAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadGearAsync_003Ed__._003C_003E4__this = this;
		_003CLoadGearAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadGearAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadGearAsync_003Ed__42>(ref _003CLoadGearAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadGearAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadTalentAsync_003Ed__43))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadTalentAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadTalentAsync_003Ed__43 _003CLoadTalentAsync_003Ed__ = new _003CLoadTalentAsync_003Ed__43();
		_003CLoadTalentAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadTalentAsync_003Ed__._003C_003E4__this = this;
		_003CLoadTalentAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadTalentAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadTalentAsync_003Ed__43>(ref _003CLoadTalentAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadTalentAsync_003Ed__._003C_003Et__builder)).Task;
	}

	private void RefreshModelItemEffects()
	{
		_model?.SetItemEffects(new _003C_003Ez__ReadOnlyArray<ItemEffect>(new ItemEffect[3] { _heldItemEffect, _gearEffect, _talentEffect }));
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

	[AsyncStateMachine(typeof(_003CEditAttributes_003Ed__46))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task EditAttributes()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CEditAttributes_003Ed__46 _003CEditAttributes_003Ed__ = new _003CEditAttributes_003Ed__46();
		_003CEditAttributes_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CEditAttributes_003Ed__._003C_003E4__this = this;
		_003CEditAttributes_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CEditAttributes_003Ed__._003C_003Et__builder)).Start<_003CEditAttributes_003Ed__46>(ref _003CEditAttributes_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CEditAttributes_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CEditMoves_003Ed__47))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task EditMoves()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CEditMoves_003Ed__47 _003CEditMoves_003Ed__ = new _003CEditMoves_003Ed__47();
		_003CEditMoves_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CEditMoves_003Ed__._003C_003E4__this = this;
		_003CEditMoves_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CEditMoves_003Ed__._003C_003Et__builder)).Start<_003CEditMoves_003Ed__47>(ref _003CEditMoves_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CEditMoves_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CEditGear_003Ed__48))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task EditGear()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CEditGear_003Ed__48 _003CEditGear_003Ed__ = new _003CEditGear_003Ed__48();
		_003CEditGear_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CEditGear_003Ed__._003C_003E4__this = this;
		_003CEditGear_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CEditGear_003Ed__._003C_003Et__builder)).Start<_003CEditGear_003Ed__48>(ref _003CEditGear_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CEditGear_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CEditTalent_003Ed__49))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task EditTalent()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CEditTalent_003Ed__49 _003CEditTalent_003Ed__ = new _003CEditTalent_003Ed__49();
		_003CEditTalent_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CEditTalent_003Ed__._003C_003E4__this = this;
		_003CEditTalent_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CEditTalent_003Ed__._003C_003Et__builder)).Start<_003CEditTalent_003Ed__49>(ref _003CEditTalent_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CEditTalent_003Ed__._003C_003Et__builder)).Task;
	}

	public void Dispose()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		if (!_disposed)
		{
			_disposed = true;
			((ObservableObject)_playerInfoModel).PropertyChanged -= new PropertyChangedEventHandler(OnPlayerInfoModelPropertyChanged);
			_playerState.StateChanged -= OnStateChanged;
			_model = null;
			GC.SuppressFinalize((object)this);
		}
	}
}
