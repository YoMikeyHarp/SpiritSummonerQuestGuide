using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Players;
using SpiritSummoner.Application.UseCases.Spirits;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Enums.Shops;
using SpiritSummoner.Presentation.Models;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.BottomSheet;
using SpiritSummoner.Presentation.ViewModels.Spirits;
using SpiritSummoner.Presentation.Views.BottomSheets.SpiritSheets;
using SpiritSummoner.Presentation.Views.BottomSheets.SquadSheets;
using SpiritSummoner.Presentation.Views.Spirits.Controls;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Infrastructure.Services;

public class SpiritActionService : ISpiritActionService
{
	[CompilerGenerated]
	private sealed class _003CAddToSquadAsync_003Ed__8 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string spiritId;

		public SpiritActionService _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Collections.Generic.IReadOnlyList<PlayerSpirit> _003CactiveSquad_003E5__3;

		private int _003CemptySlot_003E5__4;

		private int _003Ci_003E5__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0305: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02db: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0240: Unknown result type (might be due to invalid IL or missing references)
			//IL_0245: Unknown result type (might be due to invalid IL or missing references)
			//IL_024d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Unknown result type (might be due to invalid IL or missing references)
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_0221: Unknown result type (might be due to invalid IL or missing references)
			//IL_0223: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					if (_003C_003E4__this._stateService.CurrentPlayerId == null)
					{
						awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "No active player session.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CAddToSquadAsync_003Ed__8 _003CAddToSquadAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAddToSquadAsync_003Ed__8>(ref awaiter2, ref _003CAddToSquadAsync_003Ed__);
							return;
						}
						goto IL_00b0;
					}
					_003C_003Es__2 = 0;
					goto case 1;
				case 0:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00b0;
				case 1:
				case 2:
				{
					try
					{
						TaskAwaiter awaiter3;
						if (num == 1)
						{
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_01e3;
						}
						TaskAwaiter awaiter4;
						if (num != 2)
						{
							_003CactiveSquad_003E5__3 = _003C_003E4__this._stateService.GetActiveSquad();
							_003CemptySlot_003E5__4 = -1;
							_003Ci_003E5__5 = 0;
							while (_003Ci_003E5__5 < 3)
							{
								if (_003Ci_003E5__5 >= ((global::System.Collections.Generic.IReadOnlyCollection<PlayerSpirit>)_003CactiveSquad_003E5__3).Count || _003CactiveSquad_003E5__3[_003Ci_003E5__5] == null)
								{
									_003CemptySlot_003E5__4 = _003Ci_003E5__5;
									break;
								}
								_003Ci_003E5__5++;
							}
							if (_003CemptySlot_003E5__4 == -1)
							{
								awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Squad Full", "Your squad is full. Remove a spirit first.").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__1 = awaiter3;
									_003CAddToSquadAsync_003Ed__8 _003CAddToSquadAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAddToSquadAsync_003Ed__8>(ref awaiter3, ref _003CAddToSquadAsync_003Ed__);
									return;
								}
								goto IL_01e3;
							}
							awaiter4 = _003C_003E4__this.AddToSquadPositionAsync(spiritId, _003CemptySlot_003E5__4).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__1 = awaiter4;
								_003CAddToSquadAsync_003Ed__8 _003CAddToSquadAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAddToSquadAsync_003Ed__8>(ref awaiter4, ref _003CAddToSquadAsync_003Ed__);
								return;
							}
						}
						else
						{
							awaiter4 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
						}
						((TaskAwaiter)(ref awaiter4)).GetResult();
						_003CactiveSquad_003E5__3 = null;
						goto end_IL_00c5;
						IL_01e3:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						goto end_IL_0007;
						end_IL_00c5:;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__1 = ex;
						_003C_003Es__2 = 1;
					}
					int num2 = _003C_003Es__2;
					if (num2 != 1)
					{
						break;
					}
					_003Cex_003E5__6 = (global::System.Exception)_003C_003Es__1;
					awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to add spirit to squad.").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = awaiter;
						_003CAddToSquadAsync_003Ed__8 _003CAddToSquadAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAddToSquadAsync_003Ed__8>(ref awaiter, ref _003CAddToSquadAsync_003Ed__);
						return;
					}
					goto IL_0314;
				}
				case 3:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0314;
					}
					IL_0314:
					((TaskAwaiter)(ref awaiter)).GetResult();
					Console.WriteLine("Error adding to squad: " + _003Cex_003E5__6.Message);
					_003Cex_003E5__6 = null;
					break;
					IL_00b0:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					goto end_IL_0007;
				}
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
	private sealed class _003CAddToSquadPositionAsync_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string spiritId;

		public int position;

		public SpiritActionService _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private AddSpiritToSquadRequest _003Crequest_003E5__3;

		private AddSpiritToSquadUseCase _003CaddToSquadUseCase_003E5__4;

		private Result<AddSpiritToSquadResponse> _003Cresult_003E5__5;

		private Result<AddSpiritToSquadResponse> _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter<Result<AddSpiritToSquadResponse>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0206: Unknown result type (might be due to invalid IL or missing references)
			//IL_0208: Unknown result type (might be due to invalid IL or missing references)
			//IL_0225: Unknown result type (might be due to invalid IL or missing references)
			//IL_022a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0232: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_0241;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					TaskAwaiter<Result<AddSpiritToSquadResponse>> awaiter3;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter2 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_017a;
						}
						_003Crequest_003E5__3 = new AddSpiritToSquadRequest(position, spiritId);
						_003CaddToSquadUseCase_003E5__4 = ServiceProviderServiceExtensions.GetRequiredService<AddSpiritToSquadUseCase>(_003C_003E4__this._serviceProvider);
						awaiter3 = _003CaddToSquadUseCase_003E5__4.ExecuteAsync(_003Crequest_003E5__3).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CAddToSquadPositionAsync_003Ed__7 _003CAddToSquadPositionAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<AddSpiritToSquadResponse>>, _003CAddToSquadPositionAsync_003Ed__7>(ref awaiter3, ref _003CAddToSquadPositionAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<AddSpiritToSquadResponse>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__6 = awaiter3.GetResult();
					_003Cresult_003E5__5 = _003C_003Es__6;
					_003C_003Es__6 = null;
					if (!_003Cresult_003E5__5.Success)
					{
						awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__5.ErrorMessage ?? "Failed to add spirit to squad.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter2;
							_003CAddToSquadPositionAsync_003Ed__7 _003CAddToSquadPositionAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAddToSquadPositionAsync_003Ed__7>(ref awaiter2, ref _003CAddToSquadPositionAsync_003Ed__);
							return;
						}
						goto IL_017a;
					}
					goto IL_0183;
					IL_0183:
					_003Crequest_003E5__3 = null;
					_003CaddToSquadUseCase_003E5__4 = null;
					_003Cresult_003E5__5 = null;
					goto end_IL_0023;
					IL_017a:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					goto IL_0183;
					end_IL_0023:;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_026e;
				}
				_003Cex_003E5__7 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to add spirit to squad.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 2);
					_003C_003Eu__2 = awaiter;
					_003CAddToSquadPositionAsync_003Ed__7 _003CAddToSquadPositionAsync_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAddToSquadPositionAsync_003Ed__7>(ref awaiter, ref _003CAddToSquadPositionAsync_003Ed__);
					return;
				}
				goto IL_0241;
				IL_0241:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine("Error adding to squad: " + _003Cex_003E5__7.Message);
				_003Cex_003E5__7 = null;
				goto IL_026e;
				IL_026e:
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
	private sealed class _003CEditAttributesAsync_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public SpiritCardModel spirit;

		public SpiritActionService _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private AttributesEditBottomSheet _003Csheet_003E5__3;

		private AttributesEditViewModel _003Cvm_003E5__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Expected O, but got Unknown
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
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
						goto IL_01d7;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						_003Csheet_003E5__3 = new AttributesEditBottomSheet(_003C_003E4__this._bottomSheetService);
						_003Cvm_003E5__4 = ActivatorUtilities.CreateInstance<AttributesEditViewModel>(_003C_003E4__this._serviceProvider, new object[2] { spirit.PlayerSpiritId, spirit.ItemEffects });
						((BindableObject)_003Csheet_003E5__3).BindingContext = _003Cvm_003E5__4;
						_003Cvm_003E5__4.SetSheet((BottomSheet)(object)_003Csheet_003E5__3);
						AttributesEditBottomSheet attributesEditBottomSheet = _003Csheet_003E5__3;
						List<Detent> obj = new List<Detent>(1);
						obj.Add((Detent)new FullscreenDetent());
						((BottomSheet)attributesEditBottomSheet).Detents = (global::System.Collections.Generic.IList<Detent>)obj;
						awaiter2 = _003C_003E4__this._bottomSheetService.ShowSheetAsync((BottomSheet)(object)_003Csheet_003E5__3).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CEditAttributesAsync_003Ed__15 _003CEditAttributesAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CEditAttributesAsync_003Ed__15>(ref awaiter2, ref _003CEditAttributesAsync_003Ed__);
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
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
					goto IL_0147;
				}
				goto end_IL_0007;
				IL_0147:
				int num2 = _003C_003Es__2;
				if (num2 == 1)
				{
					_003Cex_003E5__5 = (global::System.Exception)_003C_003Es__1;
					awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to open attributes editor.").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter;
						_003CEditAttributesAsync_003Ed__15 _003CEditAttributesAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CEditAttributesAsync_003Ed__15>(ref awaiter, ref _003CEditAttributesAsync_003Ed__);
						return;
					}
					goto IL_01d7;
				}
				_003C_003Es__1 = null;
				throw null;
				IL_01d7:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine("Error editing attributes: " + _003Cex_003E5__5.Message);
				result = false;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CEditGearsAsync_003Ed__17 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<InsufficientFundsResult> _003C_003Et__builder;

		public SpiritCardModel spirit;

		public ItemModel currentGear;

		public SpiritActionService _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private string _003CsheetId_003E5__3;

		private EditGearBottomSheet _003Csheet_003E5__4;

		private EditGearSheetViewModel _003Cvm_003E5__5;

		private GearResult _003Cresult_003E5__6;

		private GearResult _003C_003Es__7;

		private EquipItemUseCase _003CequipUseCase_003E5__8;

		private EquipItemRequest _003Crequest_003E5__9;

		private Result<EquipItemResponse> _003CequipResult_003E5__10;

		private Result<EquipItemResponse> _003C_003Es__11;

		private global::System.Exception _003Cex_003E5__12;

		private TaskAwaiter<GearResult> _003C_003Eu__1;

		private TaskAwaiter<Result<EquipItemResponse>> _003C_003Eu__2;

		private TaskAwaiter _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0402: Unknown result type (might be due to invalid IL or missing references)
			//IL_0407: Unknown result type (might be due to invalid IL or missing references)
			//IL_040f: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_027d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0282: Unknown result type (might be due to invalid IL or missing references)
			//IL_028a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0333: Unknown result type (might be due to invalid IL or missing references)
			//IL_0338: Unknown result type (might be due to invalid IL or missing references)
			//IL_0340: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Expected O, but got Unknown
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0313: Unknown result type (might be due to invalid IL or missing references)
			//IL_0315: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Unknown result type (might be due to invalid IL or missing references)
			//IL_0248: Unknown result type (might be due to invalid IL or missing references)
			//IL_025d: Unknown result type (might be due to invalid IL or missing references)
			//IL_025f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			InsufficientFundsResult result;
			try
			{
				TaskAwaiter awaiter;
				if ((uint)num > 2u)
				{
					if (num == 3)
					{
						awaiter = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_041e;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter<GearResult> awaiter4;
					TaskAwaiter<Result<EquipItemResponse>> awaiter3;
					TaskAwaiter awaiter2;
					switch (num)
					{
					default:
					{
						Guid val = Guid.NewGuid();
						_003CsheetId_003E5__3 = ((object)(Guid)(ref val)).ToString();
						_003Csheet_003E5__4 = new EditGearBottomSheet(_003C_003E4__this._bottomSheetService);
						_003Cvm_003E5__5 = ActivatorUtilities.CreateInstance<EditGearSheetViewModel>(_003C_003E4__this._serviceProvider, new object[2] { spirit, _003CsheetId_003E5__3 });
						_003Cvm_003E5__5.SetCurrentItem(currentGear);
						((BindableObject)_003Csheet_003E5__4).BindingContext = _003Cvm_003E5__5;
						_003Cvm_003E5__5.SetSheet((BottomSheet)(object)_003Csheet_003E5__4);
						EditGearBottomSheet editGearBottomSheet = _003Csheet_003E5__4;
						List<Detent> obj = new List<Detent>(1);
						obj.Add((Detent)new FullscreenDetent());
						((BottomSheet)editGearBottomSheet).Detents = (global::System.Collections.Generic.IList<Detent>)obj;
						awaiter4 = _003C_003E4__this._bottomSheetService.ShowSheetAsync<GearResult>((BottomSheet)(object)_003Csheet_003E5__4, _003CsheetId_003E5__3).GetAwaiter();
						if (!awaiter4.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter4;
							_003CEditGearsAsync_003Ed__17 _003CEditGearsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<GearResult>, _003CEditGearsAsync_003Ed__17>(ref awaiter4, ref _003CEditGearsAsync_003Ed__);
							return;
						}
						goto IL_0167;
					}
					case 0:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<GearResult>);
						num = (_003C_003E1__state = -1);
						goto IL_0167;
					case 1:
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<Result<EquipItemResponse>>);
						num = (_003C_003E1__state = -1);
						goto IL_0299;
					case 2:
						{
							awaiter2 = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_034f;
						}
						IL_034f:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						goto IL_0357;
						IL_0167:
						_003C_003Es__7 = awaiter4.GetResult();
						_003Cresult_003E5__6 = _003C_003Es__7;
						_003C_003Es__7 = null;
						if (!(_003Cresult_003E5__6?.NewItemId == "SHOP"))
						{
							GearResult gearResult = _003Cresult_003E5__6;
							if (gearResult == null || !gearResult.Success)
							{
								break;
							}
							GearResult gearResult2 = _003Cresult_003E5__6;
							if (gearResult2 == null || gearResult2.Unequipped)
							{
								break;
							}
							_003CequipUseCase_003E5__8 = ServiceProviderServiceExtensions.GetRequiredService<EquipItemUseCase>(_003C_003E4__this._serviceProvider);
							_003Crequest_003E5__9 = new EquipItemRequest(spirit.PlayerSpiritId, spirit.BaseSpiritId.ToString(), _003Cresult_003E5__6.NewItemId, EquipmentType.Gear);
							awaiter3 = _003CequipUseCase_003E5__8.ExecuteAsync(_003Crequest_003E5__9).GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter3;
								_003CEditGearsAsync_003Ed__17 _003CEditGearsAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Result<EquipItemResponse>>, _003CEditGearsAsync_003Ed__17>(ref awaiter3, ref _003CEditGearsAsync_003Ed__);
								return;
							}
							goto IL_0299;
						}
						result = InsufficientFundsResult.Shop;
						goto end_IL_0023;
						IL_0299:
						_003C_003Es__11 = awaiter3.GetResult();
						_003CequipResult_003E5__10 = _003C_003Es__11;
						_003C_003Es__11 = null;
						if (!_003CequipResult_003E5__10.Success)
						{
							awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003CequipResult_003E5__10.ErrorMessage ?? "Failed to equip gear.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter2;
								_003CEditGearsAsync_003Ed__17 _003CEditGearsAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CEditGearsAsync_003Ed__17>(ref awaiter2, ref _003CEditGearsAsync_003Ed__);
								return;
							}
							goto IL_034f;
						}
						goto IL_0357;
						IL_0357:
						_003CequipUseCase_003E5__8 = null;
						_003Crequest_003E5__9 = null;
						_003CequipResult_003E5__10 = null;
						break;
					}
					result = InsufficientFundsResult.None;
					end_IL_0023:;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
					goto IL_0387;
				}
				goto end_IL_0007;
				IL_0387:
				int num2 = _003C_003Es__2;
				if (num2 == 1)
				{
					_003Cex_003E5__12 = (global::System.Exception)_003C_003Es__1;
					awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cex_003E5__12.Message).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__3 = awaiter;
						_003CEditGearsAsync_003Ed__17 _003CEditGearsAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CEditGearsAsync_003Ed__17>(ref awaiter, ref _003CEditGearsAsync_003Ed__);
						return;
					}
					goto IL_041e;
				}
				_003C_003Es__1 = null;
				throw null;
				IL_041e:
				((TaskAwaiter)(ref awaiter)).GetResult();
				result = InsufficientFundsResult.None;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CEditMovesAsync_003Ed__16 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<InsufficientFundsResult> _003C_003Et__builder;

		public SpiritCardModel spirit;

		public ObservableCollection<MoveEditableState> moves;

		public SpiritActionService _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private string _003CsheetId_003E5__3;

		private MovesEditBottomSheet _003Csheet_003E5__4;

		private MovesEditViewModel _003Cvm_003E5__5;

		private InsufficientFundsResult _003Cresult_003E5__6;

		private InsufficientFundsResult _003CinsufficientFundsResult_003E5__7;

		private InsufficientFundsResult _003C_003Es__8;

		private global::System.Exception _003Cex_003E5__9;

		private TaskAwaiter<InsufficientFundsResult> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_0208: Unknown result type (might be due to invalid IL or missing references)
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0215: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			InsufficientFundsResult result;
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
						goto IL_0224;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter<InsufficientFundsResult> awaiter2;
					if (num != 0)
					{
						Guid val = Guid.NewGuid();
						_003CsheetId_003E5__3 = ((object)(Guid)(ref val)).ToString();
						_003Csheet_003E5__4 = new MovesEditBottomSheet(_003C_003E4__this._bottomSheetService);
						_003Cvm_003E5__5 = ActivatorUtilities.CreateInstance<MovesEditViewModel>(_003C_003E4__this._serviceProvider, new object[2] { spirit.PlayerSpiritId, _003CsheetId_003E5__3 });
						((BindableObject)_003Csheet_003E5__4).BindingContext = _003Cvm_003E5__5;
						_003Cvm_003E5__5.SetSheet((BottomSheet)(object)_003Csheet_003E5__4);
						MovesEditBottomSheet movesEditBottomSheet = _003Csheet_003E5__4;
						List<Detent> obj = new List<Detent>(1);
						obj.Add((Detent)new FullscreenDetent());
						((BottomSheet)movesEditBottomSheet).Detents = (global::System.Collections.Generic.IList<Detent>)obj;
						awaiter2 = _003C_003E4__this._bottomSheetService.ShowSheetAsync<InsufficientFundsResult>((BottomSheet)(object)_003Csheet_003E5__4, _003CsheetId_003E5__3).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CEditMovesAsync_003Ed__16 _003CEditMovesAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<InsufficientFundsResult>, _003CEditMovesAsync_003Ed__16>(ref awaiter2, ref _003CEditMovesAsync_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<InsufficientFundsResult>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__8 = awaiter2.GetResult();
					_003Cresult_003E5__6 = _003C_003Es__8;
					_003CinsufficientFundsResult_003E5__7 = _003Cresult_003E5__6;
					result = (true ? _003CinsufficientFundsResult_003E5__7 : InsufficientFundsResult.None);
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
					goto IL_0193;
				}
				goto end_IL_0007;
				IL_0193:
				int num2 = _003C_003Es__2;
				if (num2 == 1)
				{
					_003Cex_003E5__9 = (global::System.Exception)_003C_003Es__1;
					awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to open moves editor.").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter;
						_003CEditMovesAsync_003Ed__16 _003CEditMovesAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CEditMovesAsync_003Ed__16>(ref awaiter, ref _003CEditMovesAsync_003Ed__);
						return;
					}
					goto IL_0224;
				}
				_003C_003Es__1 = null;
				throw null;
				IL_0224:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine("Error editing moves: " + _003Cex_003E5__9.Message);
				result = InsufficientFundsResult.None;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CEditTalentsAsync_003Ed__18 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<InsufficientFundsResult> _003C_003Et__builder;

		public SpiritCardModel spirit;

		public ItemModel currentTalent;

		public SpiritActionService _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private string _003CsheetId_003E5__3;

		private EditTalentBottomSheet _003Csheet_003E5__4;

		private EditTalentSheetViewModel _003Cvm_003E5__5;

		private TalentResult _003Cresult_003E5__6;

		private TalentResult _003C_003Es__7;

		private EquipItemUseCase _003CequipUseCase_003E5__8;

		private EquipItemRequest _003Crequest_003E5__9;

		private Result<EquipItemResponse> _003CequipResult_003E5__10;

		private Result<EquipItemResponse> _003C_003Es__11;

		private global::System.Exception _003Cex_003E5__12;

		private TaskAwaiter<TalentResult> _003C_003Eu__1;

		private TaskAwaiter<Result<EquipItemResponse>> _003C_003Eu__2;

		private TaskAwaiter _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0402: Unknown result type (might be due to invalid IL or missing references)
			//IL_0407: Unknown result type (might be due to invalid IL or missing references)
			//IL_040f: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_027d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0282: Unknown result type (might be due to invalid IL or missing references)
			//IL_028a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0333: Unknown result type (might be due to invalid IL or missing references)
			//IL_0338: Unknown result type (might be due to invalid IL or missing references)
			//IL_0340: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Expected O, but got Unknown
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0313: Unknown result type (might be due to invalid IL or missing references)
			//IL_0315: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Unknown result type (might be due to invalid IL or missing references)
			//IL_0248: Unknown result type (might be due to invalid IL or missing references)
			//IL_025d: Unknown result type (might be due to invalid IL or missing references)
			//IL_025f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			InsufficientFundsResult result;
			try
			{
				TaskAwaiter awaiter;
				if ((uint)num > 2u)
				{
					if (num == 3)
					{
						awaiter = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_041e;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter<TalentResult> awaiter4;
					TaskAwaiter<Result<EquipItemResponse>> awaiter3;
					TaskAwaiter awaiter2;
					switch (num)
					{
					default:
					{
						Guid val = Guid.NewGuid();
						_003CsheetId_003E5__3 = ((object)(Guid)(ref val)).ToString();
						_003Csheet_003E5__4 = new EditTalentBottomSheet(_003C_003E4__this._bottomSheetService);
						_003Cvm_003E5__5 = ActivatorUtilities.CreateInstance<EditTalentSheetViewModel>(_003C_003E4__this._serviceProvider, new object[2] { spirit, _003CsheetId_003E5__3 });
						_003Cvm_003E5__5.SetCurrentItem(currentTalent);
						((BindableObject)_003Csheet_003E5__4).BindingContext = _003Cvm_003E5__5;
						_003Cvm_003E5__5.SetSheet((BottomSheet)(object)_003Csheet_003E5__4);
						EditTalentBottomSheet editTalentBottomSheet = _003Csheet_003E5__4;
						List<Detent> obj = new List<Detent>(1);
						obj.Add((Detent)new FullscreenDetent());
						((BottomSheet)editTalentBottomSheet).Detents = (global::System.Collections.Generic.IList<Detent>)obj;
						awaiter4 = _003C_003E4__this._bottomSheetService.ShowSheetAsync<TalentResult>((BottomSheet)(object)_003Csheet_003E5__4, _003CsheetId_003E5__3).GetAwaiter();
						if (!awaiter4.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter4;
							_003CEditTalentsAsync_003Ed__18 _003CEditTalentsAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<TalentResult>, _003CEditTalentsAsync_003Ed__18>(ref awaiter4, ref _003CEditTalentsAsync_003Ed__);
							return;
						}
						goto IL_0167;
					}
					case 0:
						awaiter4 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<TalentResult>);
						num = (_003C_003E1__state = -1);
						goto IL_0167;
					case 1:
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<Result<EquipItemResponse>>);
						num = (_003C_003E1__state = -1);
						goto IL_0299;
					case 2:
						{
							awaiter2 = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_034f;
						}
						IL_034f:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						goto IL_0357;
						IL_0167:
						_003C_003Es__7 = awaiter4.GetResult();
						_003Cresult_003E5__6 = _003C_003Es__7;
						_003C_003Es__7 = null;
						if (!(_003Cresult_003E5__6?.NewItemId == "SHOP"))
						{
							TalentResult talentResult = _003Cresult_003E5__6;
							if (talentResult == null || !talentResult.Success)
							{
								break;
							}
							TalentResult talentResult2 = _003Cresult_003E5__6;
							if (talentResult2 == null || talentResult2.Unequipped)
							{
								break;
							}
							_003CequipUseCase_003E5__8 = ServiceProviderServiceExtensions.GetRequiredService<EquipItemUseCase>(_003C_003E4__this._serviceProvider);
							_003Crequest_003E5__9 = new EquipItemRequest(spirit.PlayerSpiritId, spirit.BaseSpiritId.ToString(), _003Cresult_003E5__6.NewItemId, EquipmentType.Talent);
							awaiter3 = _003CequipUseCase_003E5__8.ExecuteAsync(_003Crequest_003E5__9).GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter3;
								_003CEditTalentsAsync_003Ed__18 _003CEditTalentsAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Result<EquipItemResponse>>, _003CEditTalentsAsync_003Ed__18>(ref awaiter3, ref _003CEditTalentsAsync_003Ed__);
								return;
							}
							goto IL_0299;
						}
						result = InsufficientFundsResult.Shop;
						goto end_IL_0023;
						IL_0299:
						_003C_003Es__11 = awaiter3.GetResult();
						_003CequipResult_003E5__10 = _003C_003Es__11;
						_003C_003Es__11 = null;
						if (!_003CequipResult_003E5__10.Success)
						{
							awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003CequipResult_003E5__10.ErrorMessage ?? "Failed to equip talent.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter2;
								_003CEditTalentsAsync_003Ed__18 _003CEditTalentsAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CEditTalentsAsync_003Ed__18>(ref awaiter2, ref _003CEditTalentsAsync_003Ed__);
								return;
							}
							goto IL_034f;
						}
						goto IL_0357;
						IL_0357:
						_003CequipUseCase_003E5__8 = null;
						_003Crequest_003E5__9 = null;
						_003CequipResult_003E5__10 = null;
						break;
					}
					result = InsufficientFundsResult.None;
					end_IL_0023:;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
					goto IL_0387;
				}
				goto end_IL_0007;
				IL_0387:
				int num2 = _003C_003Es__2;
				if (num2 == 1)
				{
					_003Cex_003E5__12 = (global::System.Exception)_003C_003Es__1;
					awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cex_003E5__12.Message).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__3 = awaiter;
						_003CEditTalentsAsync_003Ed__18 _003CEditTalentsAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CEditTalentsAsync_003Ed__18>(ref awaiter, ref _003CEditTalentsAsync_003Ed__);
						return;
					}
					goto IL_041e;
				}
				_003C_003Es__1 = null;
				throw null;
				IL_041e:
				((TaskAwaiter)(ref awaiter)).GetResult();
				result = InsufficientFundsResult.None;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CGoToSavedSquads_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SpiritActionService _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private Stopwatch _003Csw_003E5__3;

		private BottomSheet _003CcachedSheet_003E5__4;

		private BottomSheet _003C_003Es__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter<BottomSheet> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0221: Unknown result type (might be due to invalid IL or missing references)
			//IL_0226: Unknown result type (might be due to invalid IL or missing references)
			//IL_023b: Unknown result type (might be due to invalid IL or missing references)
			//IL_023d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			//IL_025c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0264: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Expected O, but got Unknown
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_0273;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter<BottomSheet> awaiter2;
					if (num == 0)
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<BottomSheet>);
						num = (_003C_003E1__state = -1);
						goto IL_00c4;
					}
					TaskAwaiter awaiter3;
					if (num == 1)
					{
						awaiter3 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01b1;
					}
					if (_003C_003E4__this._navigationService.CanNavigate())
					{
						_003Csw_003E5__3 = Stopwatch.StartNew();
						awaiter2 = _003C_003E4__this._navigationService.GetFullSheet<SavedSquadsBottomSheet, SavedSquadsSheetViewModel>("savedsquads").GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CGoToSavedSquads_003Ed__14 _003CGoToSavedSquads_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<BottomSheet>, _003CGoToSavedSquads_003Ed__14>(ref awaiter2, ref _003CGoToSavedSquads_003Ed__);
							return;
						}
						goto IL_00c4;
					}
					goto end_IL_0023;
					IL_01b1:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					_003Csw_003E5__3 = null;
					_003CcachedSheet_003E5__4 = null;
					goto IL_01dd;
					IL_00c4:
					_003C_003Es__5 = awaiter2.GetResult();
					_003CcachedSheet_003E5__4 = _003C_003Es__5;
					_003C_003Es__5 = null;
					Console.WriteLine($"Getting cached sheet took: {_003Csw_003E5__3.ElapsedMilliseconds} ms");
					BottomSheet obj = _003CcachedSheet_003E5__4;
					List<Detent> obj2 = new List<Detent>(1);
					obj2.Add((Detent)new FullscreenDetent());
					obj.Detents = (global::System.Collections.Generic.IList<Detent>)obj2;
					awaiter3 = _003C_003E4__this._bottomSheetService.ShowSheetAsync(_003CcachedSheet_003E5__4).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter3;
						_003CGoToSavedSquads_003Ed__14 _003CGoToSavedSquads_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToSavedSquads_003Ed__14>(ref awaiter3, ref _003CGoToSavedSquads_003Ed__);
						return;
					}
					goto IL_01b1;
					end_IL_0023:;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
					goto IL_01dd;
				}
				goto end_IL_0007;
				IL_01dd:
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_0285;
				}
				_003Cex_003E5__6 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Navigation Error", _003Cex_003E5__6.Message).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 2);
					_003C_003Eu__2 = awaiter;
					_003CGoToSavedSquads_003Ed__14 _003CGoToSavedSquads_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToSavedSquads_003Ed__14>(ref awaiter, ref _003CGoToSavedSquads_003Ed__);
					return;
				}
				goto IL_0273;
				IL_0273:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__6 = null;
				goto IL_0285;
				IL_0285:
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
	private sealed class _003CRemoveFromSquadAsync_003Ed__9 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string spiritId;

		public SpiritActionService _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Collections.Generic.IReadOnlyList<PlayerSpirit> _003CactiveSquad_003E5__3;

		private int _003CsquadSlot_003E5__4;

		private int _003Ci_003E5__5;

		private global::System.Exception _003Cex_003E5__6;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_023f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0244: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0278: Unknown result type (might be due to invalid IL or missing references)
			//IL_027d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0285: Unknown result type (might be due to invalid IL or missing references)
			//IL_0259: Unknown result type (might be due to invalid IL or missing references)
			//IL_025b: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				int num2;
				switch (num)
				{
				default:
					if (_003C_003E4__this._stateService.CurrentPlayerId == null)
					{
						awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "No active player session.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CRemoveFromSquadAsync_003Ed__9 _003CRemoveFromSquadAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRemoveFromSquadAsync_003Ed__9>(ref awaiter2, ref _003CRemoveFromSquadAsync_003Ed__);
							return;
						}
						goto IL_00ac;
					}
					_003C_003Es__2 = 0;
					goto case 1;
				case 0:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00ac;
				case 1:
					try
					{
						TaskAwaiter awaiter3;
						if (num == 1)
						{
							awaiter3 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_01dc;
						}
						_003CactiveSquad_003E5__3 = _003C_003E4__this._stateService.GetActiveSquad();
						_003CsquadSlot_003E5__4 = -1;
						_003Ci_003E5__5 = 0;
						while (_003Ci_003E5__5 < ((global::System.Collections.Generic.IReadOnlyCollection<PlayerSpirit>)_003CactiveSquad_003E5__3).Count)
						{
							if (_003CactiveSquad_003E5__3[_003Ci_003E5__5]?.PlayerSpiritID == spiritId)
							{
								_003CsquadSlot_003E5__4 = _003Ci_003E5__5;
								break;
							}
							_003Ci_003E5__5++;
						}
						if (_003CsquadSlot_003E5__4 != -1)
						{
							awaiter3 = _003C_003E4__this.AddToSquadPositionAsync(string.Empty, _003CsquadSlot_003E5__4).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter3;
								_003CRemoveFromSquadAsync_003Ed__9 _003CRemoveFromSquadAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRemoveFromSquadAsync_003Ed__9>(ref awaiter3, ref _003CRemoveFromSquadAsync_003Ed__);
								return;
							}
							goto IL_01dc;
						}
						goto end_IL_00c1;
						IL_01dc:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						_003CactiveSquad_003E5__3 = null;
						goto IL_0201;
						end_IL_00c1:;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__1 = ex;
						_003C_003Es__2 = 1;
						goto IL_0201;
					}
					goto end_IL_0007;
				case 2:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0294;
					}
					IL_0294:
					((TaskAwaiter)(ref awaiter)).GetResult();
					Console.WriteLine("Error removing from squad: " + _003Cex_003E5__6.Message);
					_003Cex_003E5__6 = null;
					break;
					IL_00ac:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					goto end_IL_0007;
					IL_0201:
					num2 = _003C_003Es__2;
					if (num2 != 1)
					{
						break;
					}
					_003Cex_003E5__6 = (global::System.Exception)_003C_003Es__1;
					awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to remove spirit from squad.").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = awaiter;
						_003CRemoveFromSquadAsync_003Ed__9 _003CRemoveFromSquadAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRemoveFromSquadAsync_003Ed__9>(ref awaiter, ref _003CRemoveFromSquadAsync_003Ed__);
						return;
					}
					goto IL_0294;
				}
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
	private sealed class _003CSellSpiritAsync_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<ValueTuple<bool, int>> _003C_003Et__builder;

		public string spiritId;

		public SpiritActionService _003C_003E4__this;

		private Player _003CplayerReadModel_003E5__1;

		private object _003C_003Es__2;

		private int _003C_003Es__3;

		private PlayerSpirit _003Cspirit_003E5__4;

		private int _003CgoldReward_003E5__5;

		private string _003CdisplayName_003E5__6;

		private bool _003Cconfirmed_003E5__7;

		private SellSpiritRequest _003Crequest_003E5__8;

		private SellSpiritUseCase _003CsellSpiritUseCase_003E5__9;

		private Result<SellSpiritResponse> _003Cresult_003E5__10;

		private bool _003C_003Es__11;

		private Result<SellSpiritResponse> _003C_003Es__12;

		private global::System.Exception _003Cex_003E5__13;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private TaskAwaiter<Result<SellSpiritResponse>> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_0648: Unknown result type (might be due to invalid IL or missing references)
			//IL_064d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0682: Unknown result type (might be due to invalid IL or missing references)
			//IL_0687: Unknown result type (might be due to invalid IL or missing references)
			//IL_068f: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_06cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_0662: Unknown result type (might be due to invalid IL or missing references)
			//IL_0664: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_070a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_024e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0253: Unknown result type (might be due to invalid IL or missing references)
			//IL_025b: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0300: Unknown result type (might be due to invalid IL or missing references)
			//IL_0428: Unknown result type (might be due to invalid IL or missing references)
			//IL_042d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0435: Unknown result type (might be due to invalid IL or missing references)
			//IL_04eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_05c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_05cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_05d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01da: Unknown result type (might be due to invalid IL or missing references)
			//IL_01df: Unknown result type (might be due to invalid IL or missing references)
			//IL_0274: Unknown result type (might be due to invalid IL or missing references)
			//IL_0279: Unknown result type (might be due to invalid IL or missing references)
			//IL_0319: Unknown result type (might be due to invalid IL or missing references)
			//IL_031e: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_05f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_046e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0473: Unknown result type (might be due to invalid IL or missing references)
			//IL_0557: Unknown result type (might be due to invalid IL or missing references)
			//IL_055c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0214: Unknown result type (might be due to invalid IL or missing references)
			//IL_0219: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_04cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_04cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_058c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0591: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02be: Unknown result type (might be due to invalid IL or missing references)
			//IL_022e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0230: Unknown result type (might be due to invalid IL or missing references)
			//IL_05a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_05a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0408: Unknown result type (might be due to invalid IL or missing references)
			//IL_040a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			ValueTuple<bool, int> result;
			try
			{
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				int num2;
				switch (num)
				{
				default:
					_003CplayerReadModel_003E5__1 = _003C_003E4__this._stateService.GetCurrentPlayer();
					if (_003CplayerReadModel_003E5__1 == null)
					{
						awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "No active player session.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CSellSpiritAsync_003Ed__13 _003CSellSpiritAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CSellSpiritAsync_003Ed__13>(ref awaiter2, ref _003CSellSpiritAsync_003Ed__);
							return;
						}
						goto IL_00d3;
					}
					_003C_003Es__3 = 0;
					goto case 1;
				case 0:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00d3;
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
					try
					{
						TaskAwaiter awaiter8;
						TaskAwaiter awaiter7;
						TaskAwaiter awaiter6;
						TaskAwaiter<bool> awaiter5;
						TaskAwaiter<Result<SellSpiritResponse>> awaiter4;
						TaskAwaiter awaiter3;
						switch (num)
						{
						default:
							_003Cspirit_003E5__4 = _003C_003E4__this._stateService.GetPlayerSpirit(spiritId);
							if (_003Cspirit_003E5__4 == null)
							{
								awaiter8 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Spirit not found.").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter8)).IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__1 = awaiter8;
									_003CSellSpiritAsync_003Ed__13 _003CSellSpiritAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CSellSpiritAsync_003Ed__13>(ref awaiter8, ref _003CSellSpiritAsync_003Ed__);
									return;
								}
								goto IL_01d0;
							}
							if (_003Cspirit_003E5__4.IsFavorite)
							{
								awaiter7 = _003C_003E4__this._navigationService.ShowAlertAsync("Cannot Sell!", "You can't sell a favorite spirit!").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter7)).IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__1 = awaiter7;
									_003CSellSpiritAsync_003Ed__13 _003CSellSpiritAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CSellSpiritAsync_003Ed__13>(ref awaiter7, ref _003CSellSpiritAsync_003Ed__);
									return;
								}
								goto IL_026a;
							}
							if (_003CplayerReadModel_003E5__1.PartnerSpiritId == spiritId)
							{
								awaiter6 = _003C_003E4__this._navigationService.ShowAlertAsync("Cannot Sell!", "You can't sell your partner spirit!").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter6)).IsCompleted)
								{
									num = (_003C_003E1__state = 3);
									_003C_003Eu__1 = awaiter6;
									_003CSellSpiritAsync_003Ed__13 _003CSellSpiritAsync_003Ed__ = this;
									_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CSellSpiritAsync_003Ed__13>(ref awaiter6, ref _003CSellSpiritAsync_003Ed__);
									return;
								}
								goto IL_030f;
							}
							_003CgoldReward_003E5__5 = 50 + _003Cspirit_003E5__4.Level * 10;
							_003CdisplayName_003E5__6 = ((!string.IsNullOrEmpty(_003Cspirit_003E5__4.Nickname)) ? _003Cspirit_003E5__4.Nickname : (_003Cspirit_003E5__4?.Name ?? "Spirit"));
							awaiter5 = _003C_003E4__this._navigationService.ShowConfirmationAsync("Sell Spirit?", $"Sell {_003CdisplayName_003E5__6} for {_003CgoldReward_003E5__5} G?").GetAwaiter();
							if (!awaiter5.IsCompleted)
							{
								num = (_003C_003E1__state = 4);
								_003C_003Eu__2 = awaiter5;
								_003CSellSpiritAsync_003Ed__13 _003CSellSpiritAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CSellSpiritAsync_003Ed__13>(ref awaiter5, ref _003CSellSpiritAsync_003Ed__);
								return;
							}
							goto IL_0444;
						case 1:
							awaiter8 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_01d0;
						case 2:
							awaiter7 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_026a;
						case 3:
							awaiter6 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_030f;
						case 4:
							awaiter5 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							goto IL_0444;
						case 5:
							awaiter4 = _003C_003Eu__3;
							_003C_003Eu__3 = default(TaskAwaiter<Result<SellSpiritResponse>>);
							num = (_003C_003E1__state = -1);
							goto IL_0507;
						case 6:
							{
								awaiter3 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								break;
							}
							IL_030f:
							((TaskAwaiter)(ref awaiter6)).GetResult();
							result = new ValueTuple<bool, int>(false, 0);
							goto end_IL_00f0;
							IL_0507:
							_003C_003Es__12 = awaiter4.GetResult();
							_003Cresult_003E5__10 = _003C_003Es__12;
							_003C_003Es__12 = null;
							if (_003Cresult_003E5__10.Success)
							{
								_003C_003E4__this._modelFactory.EvictModel(spiritId);
								result = new ValueTuple<bool, int>(true, _003CgoldReward_003E5__5);
								goto end_IL_0008;
							}
							awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__10.ErrorMessage ?? "Failed to sell spirit.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 6);
								_003C_003Eu__1 = awaiter3;
								_003CSellSpiritAsync_003Ed__13 _003CSellSpiritAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CSellSpiritAsync_003Ed__13>(ref awaiter3, ref _003CSellSpiritAsync_003Ed__);
								return;
							}
							break;
							IL_01d0:
							((TaskAwaiter)(ref awaiter8)).GetResult();
							result = new ValueTuple<bool, int>(false, 0);
							goto end_IL_00f0;
							IL_026a:
							((TaskAwaiter)(ref awaiter7)).GetResult();
							result = new ValueTuple<bool, int>(false, 0);
							goto end_IL_00f0;
							IL_0444:
							_003C_003Es__11 = awaiter5.GetResult();
							_003Cconfirmed_003E5__7 = _003C_003Es__11;
							if (!_003Cconfirmed_003E5__7)
							{
								result = new ValueTuple<bool, int>(false, 0);
								goto end_IL_0008;
							}
							_003Crequest_003E5__8 = new SellSpiritRequest(spiritId);
							_003CsellSpiritUseCase_003E5__9 = ServiceProviderServiceExtensions.GetRequiredService<SellSpiritUseCase>(_003C_003E4__this._serviceProvider);
							awaiter4 = _003CsellSpiritUseCase_003E5__9.ExecuteAsync(_003Crequest_003E5__8).GetAwaiter();
							if (!awaiter4.IsCompleted)
							{
								num = (_003C_003E1__state = 5);
								_003C_003Eu__3 = awaiter4;
								_003CSellSpiritAsync_003Ed__13 _003CSellSpiritAsync_003Ed__ = this;
								_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Result<SellSpiritResponse>>, _003CSellSpiritAsync_003Ed__13>(ref awaiter4, ref _003CSellSpiritAsync_003Ed__);
								return;
							}
							goto IL_0507;
						}
						((TaskAwaiter)(ref awaiter3)).GetResult();
						result = new ValueTuple<bool, int>(false, 0);
						end_IL_00f0:;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__2 = ex;
						_003C_003Es__3 = 1;
						goto IL_060a;
					}
					break;
				case 7:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_069e;
					}
					IL_069e:
					((TaskAwaiter)(ref awaiter)).GetResult();
					Console.WriteLine(_003Cex_003E5__13.Message);
					Console.WriteLine(_003Cex_003E5__13.StackTrace);
					result = new ValueTuple<bool, int>(false, 0);
					break;
					IL_00d3:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					result = new ValueTuple<bool, int>(false, 0);
					break;
					IL_060a:
					num2 = _003C_003Es__3;
					if (num2 == 1)
					{
						_003Cex_003E5__13 = (global::System.Exception)_003C_003Es__2;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to sell spirit.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 7);
							_003C_003Eu__1 = awaiter;
							_003CSellSpiritAsync_003Ed__13 _003CSellSpiritAsync_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CSellSpiritAsync_003Ed__13>(ref awaiter, ref _003CSellSpiritAsync_003Ed__);
							return;
						}
						goto IL_069e;
					}
					_003C_003Es__2 = null;
					_003CplayerReadModel_003E5__1 = null;
					throw null;
					end_IL_0008:
					break;
				}
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSetAsPartnerAsync_003Ed__11 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string spiritId;

		public SpiritActionService _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private SetPartnerSpiritRequest _003Crequest_003E5__3;

		private SetPartnerSpiritUseCase _003CsetPartnerSpiritUseCase_003E5__4;

		private Result<SetPartnerSpiritResponse> _003Cresult_003E5__5;

		private Result<SetPartnerSpiritResponse> _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<Result<SetPartnerSpiritResponse>> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_028e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0293: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_0200: Unknown result type (might be due to invalid IL or missing references)
			//IL_0205: Unknown result type (might be due to invalid IL or missing references)
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					if (_003C_003E4__this._stateService.CurrentPlayerId == null)
					{
						awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "No active player session.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CSetAsPartnerAsync_003Ed__11 _003CSetAsPartnerAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSetAsPartnerAsync_003Ed__11>(ref awaiter2, ref _003CSetAsPartnerAsync_003Ed__);
							return;
						}
						goto IL_00b0;
					}
					_003C_003Es__2 = 0;
					goto case 1;
				case 0:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00b0;
				case 1:
				case 2:
				{
					try
					{
						TaskAwaiter awaiter3;
						TaskAwaiter<Result<SetPartnerSpiritResponse>> awaiter4;
						if (num != 1)
						{
							if (num == 2)
							{
								awaiter3 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_021c;
							}
							_003Crequest_003E5__3 = new SetPartnerSpiritRequest(spiritId);
							_003CsetPartnerSpiritUseCase_003E5__4 = ServiceProviderServiceExtensions.GetRequiredService<SetPartnerSpiritUseCase>(_003C_003E4__this._serviceProvider);
							awaiter4 = _003CsetPartnerSpiritUseCase_003E5__4.ExecuteAsync(_003Crequest_003E5__3).GetAwaiter();
							if (!awaiter4.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter4;
								_003CSetAsPartnerAsync_003Ed__11 _003CSetAsPartnerAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<SetPartnerSpiritResponse>>, _003CSetAsPartnerAsync_003Ed__11>(ref awaiter4, ref _003CSetAsPartnerAsync_003Ed__);
								return;
							}
						}
						else
						{
							awaiter4 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<Result<SetPartnerSpiritResponse>>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__6 = awaiter4.GetResult();
						_003Cresult_003E5__5 = _003C_003Es__6;
						_003C_003Es__6 = null;
						if (!_003Cresult_003E5__5.Success)
						{
							awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__5.ErrorMessage ?? "Failed to set partner spirit.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__1 = awaiter3;
								_003CSetAsPartnerAsync_003Ed__11 _003CSetAsPartnerAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSetAsPartnerAsync_003Ed__11>(ref awaiter3, ref _003CSetAsPartnerAsync_003Ed__);
								return;
							}
							goto IL_021c;
						}
						goto IL_0225;
						IL_0225:
						_003Crequest_003E5__3 = null;
						_003CsetPartnerSpiritUseCase_003E5__4 = null;
						_003Cresult_003E5__5 = null;
						goto end_IL_00c5;
						IL_021c:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						goto IL_0225;
						end_IL_00c5:;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__1 = ex;
						_003C_003Es__2 = 1;
					}
					int num2 = _003C_003Es__2;
					if (num2 != 1)
					{
						break;
					}
					_003Cex_003E5__7 = (global::System.Exception)_003C_003Es__1;
					awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to set partner spirit.").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = awaiter;
						_003CSetAsPartnerAsync_003Ed__11 _003CSetAsPartnerAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSetAsPartnerAsync_003Ed__11>(ref awaiter, ref _003CSetAsPartnerAsync_003Ed__);
						return;
					}
					goto IL_02e3;
				}
				case 3:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_02e3;
					}
					IL_02e3:
					((TaskAwaiter)(ref awaiter)).GetResult();
					Console.WriteLine("Error setting partner: " + _003Cex_003E5__7.Message);
					_003Cex_003E5__7 = null;
					break;
					IL_00b0:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					goto end_IL_0007;
				}
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
	private sealed class _003CSwitchActiveSquadAsync_003Ed__10 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public int newSquadSlot;

		public SpiritActionService _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private SwitchActiveSquadRequest _003Crequest_003E5__3;

		private SwitchActiveSquadUseCase _003CswitchActiveSquadUseCase_003E5__4;

		private Result<SwitchActiveSquadResponse> _003Cresult_003E5__5;

		private Result<SwitchActiveSquadResponse> _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<Result<SwitchActiveSquadResponse>> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_028e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0293: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_0200: Unknown result type (might be due to invalid IL or missing references)
			//IL_0205: Unknown result type (might be due to invalid IL or missing references)
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					if (_003C_003E4__this._stateService.CurrentPlayerId == null)
					{
						awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "No active player session.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CSwitchActiveSquadAsync_003Ed__10 _003CSwitchActiveSquadAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSwitchActiveSquadAsync_003Ed__10>(ref awaiter2, ref _003CSwitchActiveSquadAsync_003Ed__);
							return;
						}
						goto IL_00b0;
					}
					_003C_003Es__2 = 0;
					goto case 1;
				case 0:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00b0;
				case 1:
				case 2:
				{
					try
					{
						TaskAwaiter awaiter3;
						TaskAwaiter<Result<SwitchActiveSquadResponse>> awaiter4;
						if (num != 1)
						{
							if (num == 2)
							{
								awaiter3 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_021c;
							}
							_003Crequest_003E5__3 = new SwitchActiveSquadRequest(newSquadSlot);
							_003CswitchActiveSquadUseCase_003E5__4 = ServiceProviderServiceExtensions.GetRequiredService<SwitchActiveSquadUseCase>(_003C_003E4__this._serviceProvider);
							awaiter4 = _003CswitchActiveSquadUseCase_003E5__4.ExecuteAsync(_003Crequest_003E5__3).GetAwaiter();
							if (!awaiter4.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter4;
								_003CSwitchActiveSquadAsync_003Ed__10 _003CSwitchActiveSquadAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<SwitchActiveSquadResponse>>, _003CSwitchActiveSquadAsync_003Ed__10>(ref awaiter4, ref _003CSwitchActiveSquadAsync_003Ed__);
								return;
							}
						}
						else
						{
							awaiter4 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<Result<SwitchActiveSquadResponse>>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__6 = awaiter4.GetResult();
						_003Cresult_003E5__5 = _003C_003Es__6;
						_003C_003Es__6 = null;
						if (!_003Cresult_003E5__5.Success)
						{
							awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__5.ErrorMessage ?? "Failed to switch squad.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__1 = awaiter3;
								_003CSwitchActiveSquadAsync_003Ed__10 _003CSwitchActiveSquadAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSwitchActiveSquadAsync_003Ed__10>(ref awaiter3, ref _003CSwitchActiveSquadAsync_003Ed__);
								return;
							}
							goto IL_021c;
						}
						goto IL_0225;
						IL_0225:
						_003Crequest_003E5__3 = null;
						_003CswitchActiveSquadUseCase_003E5__4 = null;
						_003Cresult_003E5__5 = null;
						goto end_IL_00c5;
						IL_021c:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						goto IL_0225;
						end_IL_00c5:;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__1 = ex;
						_003C_003Es__2 = 1;
					}
					int num2 = _003C_003Es__2;
					if (num2 != 1)
					{
						break;
					}
					_003Cex_003E5__7 = (global::System.Exception)_003C_003Es__1;
					awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to switch squad.").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = awaiter;
						_003CSwitchActiveSquadAsync_003Ed__10 _003CSwitchActiveSquadAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSwitchActiveSquadAsync_003Ed__10>(ref awaiter, ref _003CSwitchActiveSquadAsync_003Ed__);
						return;
					}
					goto IL_02e3;
				}
				case 3:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_02e3;
					}
					IL_02e3:
					((TaskAwaiter)(ref awaiter)).GetResult();
					Console.WriteLine("Error switching squad: " + _003Cex_003E5__7.Message);
					_003Cex_003E5__7 = null;
					break;
					IL_00b0:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					goto end_IL_0007;
				}
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
	private sealed class _003CToggleSpiritFavorite_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string spiritId;

		public SpiritActionService _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private ToggleSpiritFavoriteRequest _003Crequest_003E5__3;

		private ToggleSpiritFavoriteUseCase _003CtoggleFavoriteUseCase_003E5__4;

		private Result<ToggleSpiritFavoriteResponse> _003Cresult_003E5__5;

		private Result<ToggleSpiritFavoriteResponse> _003C_003Es__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<Result<ToggleSpiritFavoriteResponse>> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_028e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0293: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_0200: Unknown result type (might be due to invalid IL or missing references)
			//IL_0205: Unknown result type (might be due to invalid IL or missing references)
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					if (_003C_003E4__this._stateService.CurrentPlayerId == null)
					{
						awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "No active player session.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CToggleSpiritFavorite_003Ed__12 _003CToggleSpiritFavorite_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CToggleSpiritFavorite_003Ed__12>(ref awaiter2, ref _003CToggleSpiritFavorite_003Ed__);
							return;
						}
						goto IL_00b0;
					}
					_003C_003Es__2 = 0;
					goto case 1;
				case 0:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00b0;
				case 1:
				case 2:
				{
					try
					{
						TaskAwaiter awaiter3;
						TaskAwaiter<Result<ToggleSpiritFavoriteResponse>> awaiter4;
						if (num != 1)
						{
							if (num == 2)
							{
								awaiter3 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_021c;
							}
							_003Crequest_003E5__3 = new ToggleSpiritFavoriteRequest(spiritId);
							_003CtoggleFavoriteUseCase_003E5__4 = ServiceProviderServiceExtensions.GetRequiredService<ToggleSpiritFavoriteUseCase>(_003C_003E4__this._serviceProvider);
							awaiter4 = _003CtoggleFavoriteUseCase_003E5__4.ExecuteAsync(_003Crequest_003E5__3).GetAwaiter();
							if (!awaiter4.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter4;
								_003CToggleSpiritFavorite_003Ed__12 _003CToggleSpiritFavorite_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<ToggleSpiritFavoriteResponse>>, _003CToggleSpiritFavorite_003Ed__12>(ref awaiter4, ref _003CToggleSpiritFavorite_003Ed__);
								return;
							}
						}
						else
						{
							awaiter4 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<Result<ToggleSpiritFavoriteResponse>>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__6 = awaiter4.GetResult();
						_003Cresult_003E5__5 = _003C_003Es__6;
						_003C_003Es__6 = null;
						if (!_003Cresult_003E5__5.Success)
						{
							awaiter3 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__5.ErrorMessage ?? "Failed to update favorite status.").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__1 = awaiter3;
								_003CToggleSpiritFavorite_003Ed__12 _003CToggleSpiritFavorite_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CToggleSpiritFavorite_003Ed__12>(ref awaiter3, ref _003CToggleSpiritFavorite_003Ed__);
								return;
							}
							goto IL_021c;
						}
						goto IL_0225;
						IL_0225:
						_003Crequest_003E5__3 = null;
						_003CtoggleFavoriteUseCase_003E5__4 = null;
						_003Cresult_003E5__5 = null;
						goto end_IL_00c5;
						IL_021c:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						goto IL_0225;
						end_IL_00c5:;
					}
					catch (global::System.Exception ex)
					{
						_003C_003Es__1 = ex;
						_003C_003Es__2 = 1;
					}
					int num2 = _003C_003Es__2;
					if (num2 != 1)
					{
						break;
					}
					_003Cex_003E5__7 = (global::System.Exception)_003C_003Es__1;
					awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to update spirit favorite status.").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = awaiter;
						_003CToggleSpiritFavorite_003Ed__12 _003CToggleSpiritFavorite_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CToggleSpiritFavorite_003Ed__12>(ref awaiter, ref _003CToggleSpiritFavorite_003Ed__);
						return;
					}
					goto IL_02e0;
				}
				case 3:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_02e0;
					}
					IL_02e0:
					((TaskAwaiter)(ref awaiter)).GetResult();
					Console.WriteLine(_003Cex_003E5__7.StackTrace);
					_003Cex_003E5__7 = null;
					break;
					IL_00b0:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					goto end_IL_0007;
				}
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

	private readonly IPlayerStateService _stateService;

	private readonly IPopupService _popupService;

	private readonly INavigationService _navigationService;

	private readonly IBottomSheetService _bottomSheetService;

	private readonly IServiceProvider _serviceProvider;

	private readonly SpiritCardModelFactory _modelFactory;

	public SpiritActionService(IPlayerStateService stateService, IServiceProvider serviceProvider, IPopupService popupService, INavigationService navigationService, IBottomSheetService bottomSheetService, SpiritCardModelFactory modelFactory)
	{
		_stateService = stateService;
		_serviceProvider = serviceProvider;
		_popupService = popupService;
		_navigationService = navigationService;
		_bottomSheetService = bottomSheetService;
		_modelFactory = modelFactory;
	}

	[AsyncStateMachine(typeof(_003CAddToSquadPositionAsync_003Ed__7))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task AddToSquadPositionAsync(string spiritId, int position)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CAddToSquadPositionAsync_003Ed__7 _003CAddToSquadPositionAsync_003Ed__ = new _003CAddToSquadPositionAsync_003Ed__7();
		_003CAddToSquadPositionAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CAddToSquadPositionAsync_003Ed__._003C_003E4__this = this;
		_003CAddToSquadPositionAsync_003Ed__.spiritId = spiritId;
		_003CAddToSquadPositionAsync_003Ed__.position = position;
		_003CAddToSquadPositionAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CAddToSquadPositionAsync_003Ed__._003C_003Et__builder)).Start<_003CAddToSquadPositionAsync_003Ed__7>(ref _003CAddToSquadPositionAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CAddToSquadPositionAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CAddToSquadAsync_003Ed__8))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task AddToSquadAsync(string spiritId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CAddToSquadAsync_003Ed__8 _003CAddToSquadAsync_003Ed__ = new _003CAddToSquadAsync_003Ed__8();
		_003CAddToSquadAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CAddToSquadAsync_003Ed__._003C_003E4__this = this;
		_003CAddToSquadAsync_003Ed__.spiritId = spiritId;
		_003CAddToSquadAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CAddToSquadAsync_003Ed__._003C_003Et__builder)).Start<_003CAddToSquadAsync_003Ed__8>(ref _003CAddToSquadAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CAddToSquadAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRemoveFromSquadAsync_003Ed__9))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task RemoveFromSquadAsync(string spiritId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRemoveFromSquadAsync_003Ed__9 _003CRemoveFromSquadAsync_003Ed__ = new _003CRemoveFromSquadAsync_003Ed__9();
		_003CRemoveFromSquadAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRemoveFromSquadAsync_003Ed__._003C_003E4__this = this;
		_003CRemoveFromSquadAsync_003Ed__.spiritId = spiritId;
		_003CRemoveFromSquadAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRemoveFromSquadAsync_003Ed__._003C_003Et__builder)).Start<_003CRemoveFromSquadAsync_003Ed__9>(ref _003CRemoveFromSquadAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRemoveFromSquadAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSwitchActiveSquadAsync_003Ed__10))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task SwitchActiveSquadAsync(int newSquadSlot)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSwitchActiveSquadAsync_003Ed__10 _003CSwitchActiveSquadAsync_003Ed__ = new _003CSwitchActiveSquadAsync_003Ed__10();
		_003CSwitchActiveSquadAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSwitchActiveSquadAsync_003Ed__._003C_003E4__this = this;
		_003CSwitchActiveSquadAsync_003Ed__.newSquadSlot = newSquadSlot;
		_003CSwitchActiveSquadAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSwitchActiveSquadAsync_003Ed__._003C_003Et__builder)).Start<_003CSwitchActiveSquadAsync_003Ed__10>(ref _003CSwitchActiveSquadAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSwitchActiveSquadAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSetAsPartnerAsync_003Ed__11))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task SetAsPartnerAsync(string spiritId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSetAsPartnerAsync_003Ed__11 _003CSetAsPartnerAsync_003Ed__ = new _003CSetAsPartnerAsync_003Ed__11();
		_003CSetAsPartnerAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSetAsPartnerAsync_003Ed__._003C_003E4__this = this;
		_003CSetAsPartnerAsync_003Ed__.spiritId = spiritId;
		_003CSetAsPartnerAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSetAsPartnerAsync_003Ed__._003C_003Et__builder)).Start<_003CSetAsPartnerAsync_003Ed__11>(ref _003CSetAsPartnerAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSetAsPartnerAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CToggleSpiritFavorite_003Ed__12))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task ToggleSpiritFavorite(string spiritId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CToggleSpiritFavorite_003Ed__12 _003CToggleSpiritFavorite_003Ed__ = new _003CToggleSpiritFavorite_003Ed__12();
		_003CToggleSpiritFavorite_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CToggleSpiritFavorite_003Ed__._003C_003E4__this = this;
		_003CToggleSpiritFavorite_003Ed__.spiritId = spiritId;
		_003CToggleSpiritFavorite_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CToggleSpiritFavorite_003Ed__._003C_003Et__builder)).Start<_003CToggleSpiritFavorite_003Ed__12>(ref _003CToggleSpiritFavorite_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CToggleSpiritFavorite_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSellSpiritAsync_003Ed__13))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<ValueTuple<bool, int>> SellSpiritAsync(string spiritId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Player playerReadModel = _stateService.GetCurrentPlayer();
		if (playerReadModel == null)
		{
			await _navigationService.ShowAlertAsync("Error", "No active player session.");
			return new ValueTuple<bool, int>(false, 0);
		}
		try
		{
			PlayerSpirit spirit = _stateService.GetPlayerSpirit(spiritId);
			if (spirit == null)
			{
				await _navigationService.ShowAlertAsync("Error", "Spirit not found.");
				return new ValueTuple<bool, int>(false, 0);
			}
			if (spirit.IsFavorite)
			{
				await _navigationService.ShowAlertAsync("Cannot Sell!", "You can't sell a favorite spirit!");
				return new ValueTuple<bool, int>(false, 0);
			}
			if (playerReadModel.PartnerSpiritId == spiritId)
			{
				await _navigationService.ShowAlertAsync("Cannot Sell!", "You can't sell your partner spirit!");
				return new ValueTuple<bool, int>(false, 0);
			}
			int goldReward = 50 + spirit.Level * 10;
			string displayName = ((!string.IsNullOrEmpty(spirit.Nickname)) ? spirit.Nickname : (spirit?.Name ?? "Spirit"));
			if (!(await _navigationService.ShowConfirmationAsync("Sell Spirit?", $"Sell {displayName} for {goldReward} G?")))
			{
				return new ValueTuple<bool, int>(false, 0);
			}
			SellSpiritRequest request = new SellSpiritRequest(spiritId);
			SellSpiritUseCase sellSpiritUseCase = ServiceProviderServiceExtensions.GetRequiredService<SellSpiritUseCase>(_serviceProvider);
			Result<SellSpiritResponse> result = await sellSpiritUseCase.ExecuteAsync(request);
			if (result.Success)
			{
				_modelFactory.EvictModel(spiritId);
				return new ValueTuple<bool, int>(true, goldReward);
			}
			await _navigationService.ShowAlertAsync("Error", result.ErrorMessage ?? "Failed to sell spirit.");
			return new ValueTuple<bool, int>(false, 0);
		}
		catch (global::System.Exception ex)
		{
			await _navigationService.ShowAlertAsync("Error", "Failed to sell spirit.");
			Console.WriteLine(ex.Message);
			Console.WriteLine(ex.StackTrace);
			return new ValueTuple<bool, int>(false, 0);
		}
	}

	[AsyncStateMachine(typeof(_003CGoToSavedSquads_003Ed__14))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task GoToSavedSquads()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoToSavedSquads_003Ed__14 _003CGoToSavedSquads_003Ed__ = new _003CGoToSavedSquads_003Ed__14();
		_003CGoToSavedSquads_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoToSavedSquads_003Ed__._003C_003E4__this = this;
		_003CGoToSavedSquads_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoToSavedSquads_003Ed__._003C_003Et__builder)).Start<_003CGoToSavedSquads_003Ed__14>(ref _003CGoToSavedSquads_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoToSavedSquads_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CEditAttributesAsync_003Ed__15))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> EditAttributesAsync(SpiritCardModel spirit)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			AttributesEditBottomSheet sheet = new AttributesEditBottomSheet(_bottomSheetService);
			AttributesEditViewModel vm = (AttributesEditViewModel)(((BindableObject)sheet).BindingContext = ActivatorUtilities.CreateInstance<AttributesEditViewModel>(_serviceProvider, new object[2] { spirit.PlayerSpiritId, spirit.ItemEffects }));
			vm.SetSheet((BottomSheet)(object)sheet);
			List<Detent> obj = new List<Detent>(1);
			obj.Add((Detent)new FullscreenDetent());
			((BottomSheet)sheet).Detents = (global::System.Collections.Generic.IList<Detent>)obj;
			await _bottomSheetService.ShowSheetAsync((BottomSheet)(object)sheet);
			return true;
		}
		catch (global::System.Exception ex)
		{
			await _navigationService.ShowAlertAsync("Error", "Failed to open attributes editor.");
			Console.WriteLine("Error editing attributes: " + ex.Message);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CEditMovesAsync_003Ed__16))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<InsufficientFundsResult> EditMovesAsync(SpiritCardModel spirit, ObservableCollection<MoveEditableState> moves)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Guid val = Guid.NewGuid();
			string sheetId = ((object)(Guid)(ref val)).ToString();
			MovesEditBottomSheet sheet = new MovesEditBottomSheet(_bottomSheetService);
			MovesEditViewModel vm = (MovesEditViewModel)(((BindableObject)sheet).BindingContext = ActivatorUtilities.CreateInstance<MovesEditViewModel>(_serviceProvider, new object[2] { spirit.PlayerSpiritId, sheetId }));
			vm.SetSheet((BottomSheet)(object)sheet);
			List<Detent> obj = new List<Detent>(1);
			obj.Add((Detent)new FullscreenDetent());
			((BottomSheet)sheet).Detents = (global::System.Collections.Generic.IList<Detent>)obj;
			InsufficientFundsResult insufficientFundsResult = await _bottomSheetService.ShowSheetAsync<InsufficientFundsResult>((BottomSheet)(object)sheet, sheetId);
			if (true)
			{
				return insufficientFundsResult;
			}
			return InsufficientFundsResult.None;
		}
		catch (global::System.Exception ex)
		{
			await _navigationService.ShowAlertAsync("Error", "Failed to open moves editor.");
			Console.WriteLine("Error editing moves: " + ex.Message);
			return InsufficientFundsResult.None;
		}
	}

	[AsyncStateMachine(typeof(_003CEditGearsAsync_003Ed__17))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<InsufficientFundsResult> EditGearsAsync(SpiritCardModel spirit, ItemModel? currentGear = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Guid val = Guid.NewGuid();
			string sheetId = ((object)(Guid)(ref val)).ToString();
			EditGearBottomSheet sheet = new EditGearBottomSheet(_bottomSheetService);
			EditGearSheetViewModel vm = ActivatorUtilities.CreateInstance<EditGearSheetViewModel>(_serviceProvider, new object[2] { spirit, sheetId });
			vm.SetCurrentItem(currentGear);
			((BindableObject)sheet).BindingContext = vm;
			vm.SetSheet((BottomSheet)(object)sheet);
			List<Detent> obj = new List<Detent>(1);
			obj.Add((Detent)new FullscreenDetent());
			((BottomSheet)sheet).Detents = (global::System.Collections.Generic.IList<Detent>)obj;
			GearResult result = await _bottomSheetService.ShowSheetAsync<GearResult>((BottomSheet)(object)sheet, sheetId);
			if (result?.NewItemId == "SHOP")
			{
				return InsufficientFundsResult.Shop;
			}
			int num;
			if (result?.Success ?? false)
			{
				num = ((result != null && !result.Unequipped) ? 1 : 0);
			}
			else
			{
				num = 0;
			}
			if (num != 0)
			{
				EquipItemUseCase equipUseCase = ServiceProviderServiceExtensions.GetRequiredService<EquipItemUseCase>(_serviceProvider);
				EquipItemRequest request = new EquipItemRequest(spirit.PlayerSpiritId, spirit.BaseSpiritId.ToString(), result.NewItemId, EquipmentType.Gear);
				Result<EquipItemResponse> equipResult = await equipUseCase.ExecuteAsync(request);
				if (!equipResult.Success)
				{
					await _navigationService.ShowAlertAsync("Error", equipResult.ErrorMessage ?? "Failed to equip gear.");
				}
			}
			return InsufficientFundsResult.None;
		}
		catch (global::System.Exception ex)
		{
			await _navigationService.ShowAlertAsync("Error", ex.Message);
			return InsufficientFundsResult.None;
		}
	}

	[AsyncStateMachine(typeof(_003CEditTalentsAsync_003Ed__18))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<InsufficientFundsResult> EditTalentsAsync(SpiritCardModel spirit, ItemModel? currentTalent = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Guid val = Guid.NewGuid();
			string sheetId = ((object)(Guid)(ref val)).ToString();
			EditTalentBottomSheet sheet = new EditTalentBottomSheet(_bottomSheetService);
			EditTalentSheetViewModel vm = ActivatorUtilities.CreateInstance<EditTalentSheetViewModel>(_serviceProvider, new object[2] { spirit, sheetId });
			vm.SetCurrentItem(currentTalent);
			((BindableObject)sheet).BindingContext = vm;
			vm.SetSheet((BottomSheet)(object)sheet);
			List<Detent> obj = new List<Detent>(1);
			obj.Add((Detent)new FullscreenDetent());
			((BottomSheet)sheet).Detents = (global::System.Collections.Generic.IList<Detent>)obj;
			TalentResult result = await _bottomSheetService.ShowSheetAsync<TalentResult>((BottomSheet)(object)sheet, sheetId);
			if (result?.NewItemId == "SHOP")
			{
				return InsufficientFundsResult.Shop;
			}
			int num;
			if (result?.Success ?? false)
			{
				num = ((result != null && !result.Unequipped) ? 1 : 0);
			}
			else
			{
				num = 0;
			}
			if (num != 0)
			{
				EquipItemUseCase equipUseCase = ServiceProviderServiceExtensions.GetRequiredService<EquipItemUseCase>(_serviceProvider);
				EquipItemRequest request = new EquipItemRequest(spirit.PlayerSpiritId, spirit.BaseSpiritId.ToString(), result.NewItemId, EquipmentType.Talent);
				Result<EquipItemResponse> equipResult = await equipUseCase.ExecuteAsync(request);
				if (!equipResult.Success)
				{
					await _navigationService.ShowAlertAsync("Error", equipResult.ErrorMessage ?? "Failed to equip talent.");
				}
			}
			return InsufficientFundsResult.None;
		}
		catch (global::System.Exception ex)
		{
			await _navigationService.ShowAlertAsync("Error", ex.Message);
			return InsufficientFundsResult.None;
		}
	}
}
