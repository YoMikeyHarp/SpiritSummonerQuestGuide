using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Microsoft.Maui.Controls;
using Microsoft.Maui.Dispatching;
using Microsoft.Maui.Graphics;
using SpiritSummoner.Application.DTOs.Battles;
using SpiritSummoner.Application.Events;
using SpiritSummoner.Application.Services;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Battles;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Enums.Battles;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Infrastructure.Contracts;
using SpiritSummoner.Infrastructure.Services;
using SpiritSummoner.Presentation.Models;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.BottomSheet;
using SpiritSummoner.Presentation.ViewModels.Popups;
using SpiritSummoner.Presentation.ViewModels.Shared;
using SpiritSummoner.Presentation.ViewModels.Spirits;
using SpiritSummoner.Presentation.ViewModels.Squads;
using SpiritSummoner.Presentation.Views.BottomSheets.Portal;
using SpiritSummoner.Presentation.Views.BottomSheets.SpiritSheets;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.ViewModels.Battles;

public class BattleListViewModel : ObservableObject, ILoadableViewModel, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass80_0
	{
		public BattleOpponentPresentationModel opponent;

		internal bool _003CProcessBattleResults_003Eb__0(BattleOpponentPresentationModel o)
		{
			return o.PlayerId == opponent.PlayerId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass81_0
	{
		public BattleResultDTO battleResult;

		public BattleRewards rewards;

		public BattleListViewModel _003C_003E4__this;

		public BattleOpponentPresentationModel opponent;

		internal void _003CShowBattleSummary_003Eb__0(BattleSummaryPopupViewModel vm)
		{
			//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d6: Expected O, but got Unknown
			vm.PlayerSpirits = Enumerable.ToList<SpriteModelResultsRecord>(Enumerable.Select<SpiritBattleResult, SpriteModelResultsRecord>((global::System.Collections.Generic.IEnumerable<SpiritBattleResult>)battleResult.PlayerSpirits, (Func<SpiritBattleResult, SpriteModelResultsRecord>)((SpiritBattleResult spirit) => new SpriteModelResultsRecord(spirit.Image, spirit.Fainted ? "x.png" : "check.png", spirit.Fainted ? 0.3 : 1.0))));
			vm.EnemySpirits = Enumerable.ToList<SpriteModelResultsRecord>(Enumerable.Select<SpiritBattleResult, SpriteModelResultsRecord>((global::System.Collections.Generic.IEnumerable<SpiritBattleResult>)battleResult.EnemySpirits, (Func<SpiritBattleResult, SpriteModelResultsRecord>)((SpiritBattleResult spirit) => new SpriteModelResultsRecord(spirit.Image, spirit.Fainted ? "x.png" : "check.png", spirit.Fainted ? 0.3 : 1.0))));
			vm.OutcomeImagePlayer = (battleResult.Victory ? "staricon.png" : "x.png");
			vm.OutcomeImageEnemy = ((!battleResult.Victory) ? "staricon.png" : "x.png");
			vm.OutcomeText = (battleResult.Victory ? "VICTORY!" : "DEFEAT");
			vm.EarnedEXP = rewards?.Experience ?? 0;
			vm.EarnedGold = rewards?.Gold ?? 0;
			vm.EarnedReputation = rewards?.Reputation ?? 0;
			vm.ScoreChange = rewards?.ScoreChange ?? 0;
			vm.PlayerName = _003C_003E4__this.PlayerInfoModel.PlayerName;
			vm.EnemyName = opponent.Username;
			vm.EnemyRank = opponent.Level;
			vm.PlayerRank = _003C_003E4__this.PlayerInfoModel.PlayerLevel;
			vm.BackGround = (battleResult.Victory ? ((Brush)Application.Current.Resources["GradientWinSummary"]) : ((Brush)Application.Current.Resources["GradientLossSummary"]));
			vm.TextColor = (battleResult.Victory ? Color.FromArgb("#027242") : Color.FromArgb("#721502"));
		}
	}

	[CompilerGenerated]
	private sealed class _003CGoBack_003Ed__75 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleListViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_0138;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CGoBack_003Ed__75 _003CGoBack_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoBack_003Ed__75>(ref awaiter2, ref _003CGoBack_003Ed__);
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
					goto IL_015b;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Navigation Error", "Failed to go back").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CGoBack_003Ed__75 _003CGoBack_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoBack_003Ed__75>(ref awaiter, ref _003CGoBack_003Ed__);
					return;
				}
				goto IL_0138;
				IL_0138:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine(_003Cex_003E5__3.Message);
				_003Cex_003E5__3 = null;
				goto IL_015b;
				IL_015b:
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
	private sealed class _003CGoToFullCollection_003Ed__73 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleListViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_0152;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._navigationService.NavigateToAsync(_003C_003E4__this._stateService.CurrentRoute + "/collection").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CGoToFullCollection_003Ed__73 _003CGoToFullCollection_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToFullCollection_003Ed__73>(ref awaiter2, ref _003CGoToFullCollection_003Ed__);
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
					goto IL_0175;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to open collection.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CGoToFullCollection_003Ed__73 _003CGoToFullCollection_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToFullCollection_003Ed__73>(ref awaiter, ref _003CGoToFullCollection_003Ed__);
					return;
				}
				goto IL_0152;
				IL_0152:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine(_003Cex_003E5__3.Message);
				_003Cex_003E5__3 = null;
				goto IL_0175;
				IL_0175:
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
	private sealed class _003CGoToPortal_003Ed__72 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleListViewModel _003C_003E4__this;

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
						awaiter3 = _003C_003E4__this._navigationService.GetFullSheet<PortalBottomSheet, PortalSheetViewModel>("portal").GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CGoToPortal_003Ed__72 _003CGoToPortal_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<BottomSheet>, _003CGoToPortal_003Ed__72>(ref awaiter3, ref _003CGoToPortal_003Ed__);
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
						_003CGoToPortal_003Ed__72 _003CGoToPortal_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToPortal_003Ed__72>(ref awaiter2, ref _003CGoToPortal_003Ed__);
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
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Navigation Error", "Failed to navigate to portal.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 2);
					_003C_003Eu__2 = awaiter;
					_003CGoToPortal_003Ed__72 _003CGoToPortal_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToPortal_003Ed__72>(ref awaiter, ref _003CGoToPortal_003Ed__);
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
	private sealed class _003CGoToSquads_003Ed__74 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleListViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private ISpiritActionService _003CspiritActionService_003E5__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_0156;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						_003CspiritActionService_003E5__3 = ServiceProviderServiceExtensions.GetRequiredService<ISpiritActionService>(_003C_003E4__this._serviceProvider);
						awaiter2 = _003CspiritActionService_003E5__3.GoToSavedSquads().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CGoToSquads_003Ed__74 _003CGoToSquads_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToSquads_003Ed__74>(ref awaiter2, ref _003CGoToSquads_003Ed__);
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
					_003CspiritActionService_003E5__3 = null;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_0168;
				}
				_003Cex_003E5__4 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Navigation Error", _003Cex_003E5__4.Message).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CGoToSquads_003Ed__74 _003CGoToSquads_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToSquads_003Ed__74>(ref awaiter, ref _003CGoToSquads_003Ed__);
					return;
				}
				goto IL_0156;
				IL_0156:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__4 = null;
				goto IL_0168;
				IL_0168:
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
	private sealed class _003CLoadDataAsync_003Ed__57 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object parameter;

		public BattleListViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_023d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0242: Unknown result type (might be due to invalid IL or missing references)
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			//IL_0259: Unknown result type (might be due to invalid IL or missing references)
			//IL_0277: Unknown result type (might be due to invalid IL or missing references)
			//IL_027c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0284: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 3u || (!_003C_003E4__this._isCached && !_003C_003E4__this.IsLoading))
				{
					try
					{
						TaskAwaiter awaiter;
						if ((uint)num > 2u)
						{
							if (num == 3)
							{
								awaiter = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0293;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter awaiter4;
							TaskAwaiter<bool> awaiter3;
							TaskAwaiter awaiter2;
							switch (num)
							{
							default:
								_003C_003E4__this.IsLoading = true;
								_003C_003E4__this.ErrorMessage = string.Empty;
								_003C_003E4__this.CurrentBattleType = BattlesType.PvP3v3;
								awaiter4 = _003C_003E4__this.LoadPartnerSpirit().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter4;
									_003CLoadDataAsync_003Ed__57 _003CLoadDataAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__57>(ref awaiter4, ref _003CLoadDataAsync_003Ed__);
									return;
								}
								goto IL_00fe;
							case 0:
								awaiter4 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_00fe;
							case 1:
								awaiter3 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter<bool>);
								num = (_003C_003E1__state = -1);
								goto IL_0167;
							case 2:
								{
									awaiter2 = _003C_003Eu__1;
									_003C_003Eu__1 = default(TaskAwaiter);
									num = (_003C_003E1__state = -1);
									break;
								}
								IL_0167:
								awaiter3.GetResult();
								awaiter2 = _003C_003E4__this.LoadOpponents().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__1 = awaiter2;
									_003CLoadDataAsync_003Ed__57 _003CLoadDataAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__57>(ref awaiter2, ref _003CLoadDataAsync_003Ed__);
									return;
								}
								break;
								IL_00fe:
								((TaskAwaiter)(ref awaiter4)).GetResult();
								awaiter3 = _003C_003E4__this.LoadSquadData().GetAwaiter();
								if (!awaiter3.IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__2 = awaiter3;
									_003CLoadDataAsync_003Ed__57 _003CLoadDataAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CLoadDataAsync_003Ed__57>(ref awaiter3, ref _003CLoadDataAsync_003Ed__);
									return;
								}
								goto IL_0167;
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
							goto IL_02d7;
						}
						_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
						_003C_003E4__this.ErrorMessage = "Failed to load battle data";
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to load battle data. Please try again.").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 3);
							_003C_003Eu__1 = awaiter;
							_003CLoadDataAsync_003Ed__57 _003CLoadDataAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__57>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
							return;
						}
						goto IL_0293;
						IL_0293:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine($"BattleListViewModel.LoadDataAsync: {_003Cex_003E5__3}");
						_003Cex_003E5__3 = null;
						goto IL_02d7;
						IL_02d7:
						_003C_003Es__1 = null;
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsLoading = false;
							_003C_003E4__this.IsLoaded = true;
							_003C_003E4__this._isCached = true;
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
	private sealed class _003CLoadNPCOpponents_003Ed__64 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleListViewModel _003C_003E4__this;

		private GenerateNPCOpponentsRequest _003Crequest_003E5__1;

		private Result<List<BattleOpponentDTO>> _003Cresult_003E5__2;

		private Result<List<BattleOpponentDTO>> _003C_003Es__3;

		private List<BattleOpponentPresentationModel> _003Cmodels_003E5__4;

		private Enumerator<BattleOpponentPresentationModel> _003C_003Es__5;

		private BattleOpponentPresentationModel _003Copponent_003E5__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter<Result<List<BattleOpponentDTO>>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<Result<List<BattleOpponentDTO>>> awaiter;
					if (num != 0)
					{
						((Collection<BattleOpponentPresentationModel>)(object)_003C_003E4__this.Summoners).Clear();
						_003Crequest_003E5__1 = new GenerateNPCOpponentsRequest(_003C_003E4__this.PlayerInfoModel.PlayerLevel, 15);
						awaiter = _003C_003E4__this._generateNPCOpponentsUseCase.ExecuteAsync(_003Crequest_003E5__1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadNPCOpponents_003Ed__64 _003CLoadNPCOpponents_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<List<BattleOpponentDTO>>>, _003CLoadNPCOpponents_003Ed__64>(ref awaiter, ref _003CLoadNPCOpponents_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<List<BattleOpponentDTO>>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter.GetResult();
					_003Cresult_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (_003Cresult_003E5__2.Success && _003Cresult_003E5__2.Data != null)
					{
						_003Cmodels_003E5__4 = Enumerable.ToList<BattleOpponentPresentationModel>(Enumerable.Select<BattleOpponentDTO, BattleOpponentPresentationModel>((global::System.Collections.Generic.IEnumerable<BattleOpponentDTO>)_003Cresult_003E5__2.Data, (Func<BattleOpponentDTO, BattleOpponentPresentationModel>)BattleOpponentPresentationModel.FromDTO));
						_003C_003E4__this._opponentCache[_003C_003E4__this.CurrentBattleType] = _003Cmodels_003E5__4;
						_003C_003Es__5 = _003Cmodels_003E5__4.GetEnumerator();
						try
						{
							while (_003C_003Es__5.MoveNext())
							{
								_003Copponent_003E5__6 = _003C_003Es__5.Current;
								((Collection<BattleOpponentPresentationModel>)(object)_003C_003E4__this.Summoners).Add(_003Copponent_003E5__6);
								_003Copponent_003E5__6 = null;
							}
						}
						finally
						{
							if (num < 0)
							{
								((global::System.IDisposable)_003C_003Es__5).Dispose();
							}
						}
						_003C_003Es__5 = default(Enumerator<BattleOpponentPresentationModel>);
						_003Cmodels_003E5__4 = null;
					}
					else
					{
						_003C_003E4__this.ErrorMessage = _003Cresult_003E5__2.ErrorMessage ?? "Failed to generate NPC opponents";
					}
					_003Crequest_003E5__1 = null;
					_003Cresult_003E5__2 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__7 = ex;
					_003C_003E4__this.ErrorMessage = "Failed to generate NPC opponents";
					Console.WriteLine($"LoadNPCOpponents error: {_003Cex_003E5__7}");
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
	private sealed class _003CLoadOnlineOpponents_003Ed__63 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public int teamSize;

		public BattleListViewModel _003C_003E4__this;

		private GetOnlinePlayersRequest _003Crequest_003E5__1;

		private Result<List<BattleOpponentDTO>> _003Cresult_003E5__2;

		private Result<List<BattleOpponentDTO>> _003C_003Es__3;

		private List<BattleOpponentPresentationModel> _003Cmodels_003E5__4;

		private Enumerator<BattleOpponentPresentationModel> _003C_003Es__5;

		private BattleOpponentPresentationModel _003Copponent_003E5__6;

		private global::System.Exception _003Cex_003E5__7;

		private TaskAwaiter<Result<List<BattleOpponentDTO>>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<Result<List<BattleOpponentDTO>>> awaiter;
					if (num != 0)
					{
						((Collection<BattleOpponentPresentationModel>)(object)_003C_003E4__this.Summoners).Clear();
						_003Crequest_003E5__1 = new GetOnlinePlayersRequest(15, teamSize);
						awaiter = _003C_003E4__this._getOnlinePlayersUseCase.ExecuteAsync(_003Crequest_003E5__1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadOnlineOpponents_003Ed__63 _003CLoadOnlineOpponents_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<List<BattleOpponentDTO>>>, _003CLoadOnlineOpponents_003Ed__63>(ref awaiter, ref _003CLoadOnlineOpponents_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<List<BattleOpponentDTO>>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter.GetResult();
					_003Cresult_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (_003Cresult_003E5__2.Success && _003Cresult_003E5__2.Data != null)
					{
						_003Cmodels_003E5__4 = _003C_003E4__this.FilterDefeatedOpponents(Enumerable.ToList<BattleOpponentPresentationModel>(Enumerable.Select<BattleOpponentDTO, BattleOpponentPresentationModel>((global::System.Collections.Generic.IEnumerable<BattleOpponentDTO>)_003Cresult_003E5__2.Data, (Func<BattleOpponentDTO, BattleOpponentPresentationModel>)BattleOpponentPresentationModel.FromDTO)));
						_003C_003E4__this._opponentCache[_003C_003E4__this.CurrentBattleType] = _003Cmodels_003E5__4;
						_003C_003Es__5 = _003Cmodels_003E5__4.GetEnumerator();
						try
						{
							while (_003C_003Es__5.MoveNext())
							{
								_003Copponent_003E5__6 = _003C_003Es__5.Current;
								((Collection<BattleOpponentPresentationModel>)(object)_003C_003E4__this.Summoners).Add(_003Copponent_003E5__6);
								_003Copponent_003E5__6 = null;
							}
						}
						finally
						{
							if (num < 0)
							{
								((global::System.IDisposable)_003C_003Es__5).Dispose();
							}
						}
						_003C_003Es__5 = default(Enumerator<BattleOpponentPresentationModel>);
						_003Cmodels_003E5__4 = null;
					}
					else
					{
						_003C_003E4__this.ErrorMessage = _003Cresult_003E5__2.ErrorMessage ?? "Failed to load opponents";
					}
					_003Crequest_003E5__1 = null;
					_003Cresult_003E5__2 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__7 = ex;
					_003C_003E4__this.ErrorMessage = "Failed to load online opponents";
					Console.WriteLine($"LoadOnlineOpponents error: {_003Cex_003E5__7}");
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
	private sealed class _003CLoadOpponents_003Ed__60 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleListViewModel _003C_003E4__this;

		private BattlesType _003C_003Es__1;

		private global::System.Exception _003Cex_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 2u)
				{
				}
				try
				{
					TaskAwaiter awaiter3;
					TaskAwaiter awaiter2;
					TaskAwaiter awaiter;
					switch (num)
					{
					default:
					{
						BattlesType currentBattleType = _003C_003E4__this.CurrentBattleType;
						_003C_003Es__1 = currentBattleType;
						switch (_003C_003Es__1)
						{
						case BattlesType.NPC:
							goto IL_0063;
						case BattlesType.PvP1v1:
							goto IL_00ce;
						case BattlesType.PvP3v3:
							goto IL_0156;
						}
						goto end_IL_0011;
					}
					case 0:
						awaiter3 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_00c1;
					case 1:
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0149;
					case 2:
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							break;
						}
						IL_0156:
						if (_003C_003E4__this.EnoughLevel)
						{
							awaiter = _003C_003E4__this.LoadOnlineOpponents(3).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__1 = awaiter;
								_003CLoadOpponents_003Ed__60 _003CLoadOpponents_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadOpponents_003Ed__60>(ref awaiter, ref _003CLoadOpponents_003Ed__);
								return;
							}
							break;
						}
						goto end_IL_0011;
						IL_00c1:
						((TaskAwaiter)(ref awaiter3)).GetResult();
						goto end_IL_0011;
						IL_0149:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						goto end_IL_0011;
						IL_00ce:
						if (_003C_003E4__this.EnoughLevel)
						{
							awaiter2 = _003C_003E4__this.LoadOnlineOpponents(1).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__1 = awaiter2;
								_003CLoadOpponents_003Ed__60 _003CLoadOpponents_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadOpponents_003Ed__60>(ref awaiter2, ref _003CLoadOpponents_003Ed__);
								return;
							}
							goto IL_0149;
						}
						goto end_IL_0011;
						IL_0063:
						awaiter3 = _003C_003E4__this.LoadNPCOpponents().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter3;
							_003CLoadOpponents_003Ed__60 _003CLoadOpponents_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadOpponents_003Ed__60>(ref awaiter3, ref _003CLoadOpponents_003Ed__);
							return;
						}
						goto IL_00c1;
					}
					((TaskAwaiter)(ref awaiter)).GetResult();
					end_IL_0011:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__2 = ex;
					_003C_003E4__this.ErrorMessage = "Failed to load opponents";
					Console.WriteLine($"LoadOpponents error: {_003Cex_003E5__2}");
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
	private sealed class _003CLoadPartnerSpirit_003Ed__58 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleListViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private string _003CpartnerSpiritId_003E5__3;

		private SpiritCardModel _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<SpiritCardModel> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01de: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_01fa;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter<SpiritCardModel> awaiter2;
					if (num == 0)
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<SpiritCardModel>);
						num = (_003C_003E1__state = -1);
						goto IL_00fa;
					}
					_003CpartnerSpiritId_003E5__3 = _003C_003E4__this._playerInfoModel?.PartnerSpiritId;
					if (!string.IsNullOrEmpty(_003CpartnerSpiritId_003E5__3))
					{
						if (!string.IsNullOrEmpty(_003C_003E4__this._acquiredPartnerSpiritId))
						{
							_003C_003E4__this._spiritCardModelFactory.ReleaseModel(_003C_003E4__this._acquiredPartnerSpiritId);
						}
						awaiter2 = _003C_003E4__this._spiritCardModelFactory.CreateModelAsync(_003CpartnerSpiritId_003E5__3).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CLoadPartnerSpirit_003Ed__58 _003CLoadPartnerSpirit_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<SpiritCardModel>, _003CLoadPartnerSpirit_003Ed__58>(ref awaiter2, ref _003CLoadPartnerSpirit_003Ed__);
							return;
						}
						goto IL_00fa;
					}
					goto end_IL_0022;
					IL_00fa:
					_003C_003Es__4 = awaiter2.GetResult();
					_003C_003E4__this.PartnerSpiritModel = _003C_003Es__4;
					_003C_003Es__4 = null;
					_003C_003E4__this._acquiredPartnerSpiritId = _003CpartnerSpiritId_003E5__3;
					_003CpartnerSpiritId_003E5__3 = null;
					goto IL_014e;
					end_IL_0022:;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
					goto IL_014e;
				}
				goto end_IL_0007;
				IL_014e:
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_020c;
				}
				_003Cex_003E5__5 = (global::System.Exception)_003C_003Es__1;
				Console.WriteLine("Error loading partner spirit: " + _003Cex_003E5__5.Message);
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error loading partner spirit", "Failed to load partner spirit data.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__2 = awaiter;
					_003CLoadPartnerSpirit_003Ed__58 _003CLoadPartnerSpirit_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadPartnerSpirit_003Ed__58>(ref awaiter, ref _003CLoadPartnerSpirit_003Ed__);
					return;
				}
				goto IL_01fa;
				IL_01fa:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__5 = null;
				goto IL_020c;
				IL_020c:
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
	private sealed class _003CLoadSquadData_003Ed__59 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public BattleListViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00fc;
				}
				_003C_003Es__2 = 0;
				try
				{
					_003C_003E4__this.ActiveSquad?.Dispose();
					_003C_003E4__this.ActiveSquad = ActivatorUtilities.CreateInstance<SpiritSquadViewModel>(_003C_003E4__this._serviceProvider, global::System.Array.Empty<object>());
					result = true;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
					goto IL_006a;
				}
				goto end_IL_0007;
				IL_00fc:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine($"Error loading squad: {_003Cex_003E5__3}");
				_003C_003E4__this.ActiveSquad = null;
				result = false;
				goto end_IL_0007;
				IL_006a:
				int num2 = _003C_003Es__2;
				if (num2 == 1)
				{
					_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
					awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to load squad data").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CLoadSquadData_003Ed__59 _003CLoadSquadData_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadSquadData_003Ed__59>(ref awaiter, ref _003CLoadSquadData_003Ed__);
						return;
					}
					goto IL_00fc;
				}
				_003C_003Es__1 = null;
				throw null;
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
	private sealed class _003CNavigateToChat_003Ed__76 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleListViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._navBarViewModel.NavigateToCommand.ExecuteAsync("//chat").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CNavigateToChat_003Ed__76 _003CNavigateToChat_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToChat_003Ed__76>(ref awaiter, ref _003CNavigateToChat_003Ed__);
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
	private sealed class _003CNavigateToSpiritDetails_003Ed__71 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string id;

		public BattleListViewModel _003C_003E4__this;

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
						awaiter2 = _003C_003E4__this._navigationService.NavigateToAsync(_003C_003E4__this._stateService.CurrentRoute + "/spiritdetails?spiritId=" + id).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CNavigateToSpiritDetails_003Ed__71 _003CNavigateToSpiritDetails_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToSpiritDetails_003Ed__71>(ref awaiter2, ref _003CNavigateToSpiritDetails_003Ed__);
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
					_003CNavigateToSpiritDetails_003Ed__71 _003CNavigateToSpiritDetails_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToSpiritDetails_003Ed__71>(ref awaiter, ref _003CNavigateToSpiritDetails_003Ed__);
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
	private sealed class _003COpenSpiritsHoldNavigation_003Ed__82 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleListViewModel _003C_003E4__this;

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
							_003COpenSpiritsHoldNavigation_003Ed__82 _003COpenSpiritsHoldNavigation_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<BottomSheet>, _003COpenSpiritsHoldNavigation_003Ed__82>(ref awaiter3, ref _003COpenSpiritsHoldNavigation_003Ed__);
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
						_003COpenSpiritsHoldNavigation_003Ed__82 _003COpenSpiritsHoldNavigation_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenSpiritsHoldNavigation_003Ed__82>(ref awaiter2, ref _003COpenSpiritsHoldNavigation_003Ed__);
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
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Navigation Error", "Failed to open sheet").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 2);
					_003C_003Eu__2 = awaiter;
					_003COpenSpiritsHoldNavigation_003Ed__82 _003COpenSpiritsHoldNavigation_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COpenSpiritsHoldNavigation_003Ed__82>(ref awaiter, ref _003COpenSpiritsHoldNavigation_003Ed__);
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
	private sealed class _003CProcessBattleResults_003Ed__80 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleResultDTO battleResult;

		public BattleOpponentPresentationModel opponent;

		public BattleLaunchRequest battleRequest;

		public BattleListViewModel _003C_003E4__this;

		private _003C_003Ec__DisplayClass80_0 _003C_003E8__1;

		private CompleteBattleRequest _003CcompleteBattleRequest_003E5__2;

		private Result<BattleRewards> _003Cresult_003E5__3;

		private BattleTaskType[] _003CtaskTypes_003E5__4;

		private Result<BattleRewards> _003C_003Es__5;

		private BattlesType _003C_003Es__6;

		private List<BattleOpponentPresentationModel> _003Ccached_003E5__7;

		private global::System.Exception _003Cex_003E5__8;

		private TaskAwaiter<Result<BattleRewards>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_0328: Unknown result type (might be due to invalid IL or missing references)
			//IL_032d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0335: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0255: Unknown result type (might be due to invalid IL or missing references)
			//IL_0309: Unknown result type (might be due to invalid IL or missing references)
			//IL_030b: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 1u)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass80_0();
					_003C_003E8__1.opponent = opponent;
				}
				try
				{
					TaskAwaiter awaiter;
					TaskAwaiter<Result<BattleRewards>> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0344;
						}
						_003CcompleteBattleRequest_003E5__2 = new CompleteBattleRequest(battleResult.OpponentLevel, battleResult.Victory, battleResult.IsPvP && _003C_003E4__this.CurrentBattleType != BattlesType.NPC, battleResult.LivingSpiritsCount, battleResult.TotalHealthPercentage, battleRequest.PreCommittedScorePenalty, battleResult.QuestTaskId, battleResult.QuestTaskCompleted, battleResult.QuestTaskStep);
						awaiter2 = _003C_003E4__this._completeBattleUseCase.ExecuteAsync(_003CcompleteBattleRequest_003E5__2).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CProcessBattleResults_003Ed__80 _003CProcessBattleResults_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<BattleRewards>>, _003CProcessBattleResults_003Ed__80>(ref awaiter2, ref _003CProcessBattleResults_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<BattleRewards>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__5 = awaiter2.GetResult();
					_003Cresult_003E5__3 = _003C_003Es__5;
					_003C_003Es__5 = null;
					_003C_003Es__6 = _003C_003E4__this.CurrentBattleType;
					if (1 == 0)
					{
					}
					BattlesType battlesType = _003C_003Es__6;
					BattleTaskType[] array;
					if (battlesType != 0)
					{
						if (battlesType != BattlesType.PvP1v1 || !battleResult.Victory)
						{
							goto IL_01ba;
						}
						array = new BattleTaskType[3]
						{
							BattleTaskType.CompleteBattle,
							BattleTaskType.WinBattle,
							BattleTaskType.WinBattle1v1
						};
					}
					else
					{
						if (!battleResult.Victory)
						{
							goto IL_01ba;
						}
						array = new BattleTaskType[3]
						{
							BattleTaskType.CompleteBattle,
							BattleTaskType.WinBattle,
							BattleTaskType.WinBattle3v3
						};
					}
					goto IL_01e3;
					IL_01ba:
					array = ((!battleResult.Victory) ? new BattleTaskType[1] : new BattleTaskType[3]
					{
						BattleTaskType.CompleteBattle,
						BattleTaskType.WinBattle,
						BattleTaskType.WinBattlePvE
					});
					goto IL_01e3;
					IL_01e3:
					if (1 == 0)
					{
					}
					_003CtaskTypes_003E5__4 = array;
					_003C_003E4__this._updateBattleTaskProgressUseCase.ExecuteAsync(new UpdateBattleTaskProgressRequest(_003CtaskTypes_003E5__4));
					if (battleResult.Victory && battleResult.IsPvP)
					{
						_003C_003E4__this._defeatedOpponents[_003C_003E8__1.opponent.PlayerId] = _003C_003E4__this._serverTimeProvider.GetCurrentServerTime();
						((Collection<BattleOpponentPresentationModel>)(object)_003C_003E4__this.Summoners).Remove(_003C_003E8__1.opponent);
						if (_003C_003E4__this._opponentCache.TryGetValue(_003C_003E4__this.CurrentBattleType, ref _003Ccached_003E5__7))
						{
							_003Ccached_003E5__7.RemoveAll((Predicate<BattleOpponentPresentationModel>)((BattleOpponentPresentationModel o) => o.PlayerId == _003C_003E8__1.opponent.PlayerId));
						}
						_003Ccached_003E5__7 = null;
					}
					awaiter = _003C_003E4__this.ShowBattleSummary(battleResult, _003C_003E8__1.opponent, _003Cresult_003E5__3.Data).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter;
						_003CProcessBattleResults_003Ed__80 _003CProcessBattleResults_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CProcessBattleResults_003Ed__80>(ref awaiter, ref _003CProcessBattleResults_003Ed__);
						return;
					}
					goto IL_0344;
					IL_0344:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003CcompleteBattleRequest_003E5__2 = null;
					_003Cresult_003E5__3 = null;
					_003CtaskTypes_003E5__4 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__8 = ex;
					Console.WriteLine($"Error processing battle results: {_003Cex_003E5__8}");
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003E8__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
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
	private sealed class _003CRefreshOpponents_003Ed__62 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleListViewModel _003C_003E4__this;

		private global::System.Exception _003Cex_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0 && !_003C_003E4__this.CanRefresh)
				{
					_003C_003E4__this.IsRefreshing = false;
					_003C_003E4__this.ShowCooldownAlert();
				}
				else
				{
					try
					{
						TaskAwaiter awaiter;
						if (num != 0)
						{
							_003C_003E4__this.IsRefreshing = true;
							_003C_003E4__this.ErrorMessage = string.Empty;
							_003C_003E4__this._opponentCache.Remove(_003C_003E4__this.CurrentBattleType);
							awaiter = _003C_003E4__this.LoadOpponents().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CRefreshOpponents_003Ed__62 _003CRefreshOpponents_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRefreshOpponents_003Ed__62>(ref awaiter, ref _003CRefreshOpponents_003Ed__);
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
						_003C_003E4__this._lastRefreshByType[_003C_003E4__this.CurrentBattleType] = _003C_003E4__this._serverTimeProvider.GetCurrentServerTime();
						_003C_003E4__this.StartCooldownTimer();
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__1 = ex;
						_003C_003E4__this.ErrorMessage = "Failed to refresh opponents";
						Console.WriteLine($"RefreshOpponents error: {_003Cex_003E5__1}");
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsRefreshing = false;
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
	private sealed class _003CSelectBattleType_003Ed__61 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string battleType;

		public BattleListViewModel _003C_003E4__this;

		private BattlesType _003CparsedBattleType_003E5__1;

		private List<BattleOpponentPresentationModel> _003Ccached_003E5__2;

		private List<BattleOpponentPresentationModel> _003Cfiltered_003E5__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					if (num == 0)
					{
						goto IL_0104;
					}
					if (!_003C_003E4__this.IsLoading && global::System.Enum.TryParse<BattlesType>(battleType, ref _003CparsedBattleType_003E5__1) && _003C_003E4__this.CurrentBattleType != _003CparsedBattleType_003E5__1 && !_003C_003E4__this.IsBattling)
					{
						_003C_003E4__this.CurrentBattleType = _003CparsedBattleType_003E5__1;
						if (!_003C_003E4__this._opponentCache.TryGetValue(_003CparsedBattleType_003E5__1, ref _003Ccached_003E5__2))
						{
							goto IL_0104;
						}
						_003Cfiltered_003E5__3 = _003C_003E4__this.FilterDefeatedOpponents(_003Ccached_003E5__2);
						_003C_003E4__this._opponentCache[_003CparsedBattleType_003E5__1] = _003Cfiltered_003E5__3;
						_003C_003E4__this.Summoners = new ObservableCollection<BattleOpponentPresentationModel>(_003Cfiltered_003E5__3);
					}
					goto end_IL_0010;
					IL_0104:
					try
					{
						TaskAwaiter awaiter;
						if (num != 0)
						{
							_003C_003E4__this.IsLoading = true;
							awaiter = _003C_003E4__this.LoadOpponents().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CSelectBattleType_003Ed__61 _003CSelectBattleType_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSelectBattleType_003Ed__61>(ref awaiter, ref _003CSelectBattleType_003Ed__);
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
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsLoading = false;
						}
					}
					_003Ccached_003E5__2 = null;
					end_IL_0010:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					_003C_003E4__this.ErrorMessage = "Failed to change battle type";
					Console.WriteLine($"SelectBattleType error: {_003Cex_003E5__4}");
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
	private sealed class _003CShowBattleSummary_003Ed__81 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleResultDTO battleResult;

		public BattleOpponentPresentationModel opponent;

		public BattleRewards rewards;

		public BattleListViewModel _003C_003E4__this;

		private _003C_003Ec__DisplayClass81_0 _003C_003E8__1;

		private TaskAwaiter<object?> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<object> awaiter;
				if (num != 0)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass81_0();
					_003C_003E8__1.battleResult = battleResult;
					_003C_003E8__1.rewards = rewards;
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003C_003E8__1.opponent = opponent;
					awaiter = _003C_003E4__this._popupService.ShowPopupAsync<BattleSummaryPopupViewModel>((Action<BattleSummaryPopupViewModel>)delegate(BattleSummaryPopupViewModel vm)
					{
						//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
						//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
						//IL_01d6: Expected O, but got Unknown
						vm.PlayerSpirits = Enumerable.ToList<SpriteModelResultsRecord>(Enumerable.Select<SpiritBattleResult, SpriteModelResultsRecord>((global::System.Collections.Generic.IEnumerable<SpiritBattleResult>)_003C_003E8__1.battleResult.PlayerSpirits, (Func<SpiritBattleResult, SpriteModelResultsRecord>)((SpiritBattleResult spirit) => new SpriteModelResultsRecord(spirit.Image, spirit.Fainted ? "x.png" : "check.png", spirit.Fainted ? 0.3 : 1.0))));
						vm.EnemySpirits = Enumerable.ToList<SpriteModelResultsRecord>(Enumerable.Select<SpiritBattleResult, SpriteModelResultsRecord>((global::System.Collections.Generic.IEnumerable<SpiritBattleResult>)_003C_003E8__1.battleResult.EnemySpirits, (Func<SpiritBattleResult, SpriteModelResultsRecord>)((SpiritBattleResult spirit) => new SpriteModelResultsRecord(spirit.Image, spirit.Fainted ? "x.png" : "check.png", spirit.Fainted ? 0.3 : 1.0))));
						vm.OutcomeImagePlayer = (_003C_003E8__1.battleResult.Victory ? "staricon.png" : "x.png");
						vm.OutcomeImageEnemy = ((!_003C_003E8__1.battleResult.Victory) ? "staricon.png" : "x.png");
						vm.OutcomeText = (_003C_003E8__1.battleResult.Victory ? "VICTORY!" : "DEFEAT");
						vm.EarnedEXP = _003C_003E8__1.rewards?.Experience ?? 0;
						vm.EarnedGold = _003C_003E8__1.rewards?.Gold ?? 0;
						vm.EarnedReputation = _003C_003E8__1.rewards?.Reputation ?? 0;
						vm.ScoreChange = _003C_003E8__1.rewards?.ScoreChange ?? 0;
						vm.PlayerName = _003C_003E8__1._003C_003E4__this.PlayerInfoModel.PlayerName;
						vm.EnemyName = _003C_003E8__1.opponent.Username;
						vm.EnemyRank = _003C_003E8__1.opponent.Level;
						vm.PlayerRank = _003C_003E8__1._003C_003E4__this.PlayerInfoModel.PlayerLevel;
						vm.BackGround = (_003C_003E8__1.battleResult.Victory ? ((Brush)Application.Current.Resources["GradientWinSummary"]) : ((Brush)Application.Current.Resources["GradientLossSummary"]));
						vm.TextColor = (_003C_003E8__1.battleResult.Victory ? Color.FromArgb("#027242") : Color.FromArgb("#721502"));
					}, default(CancellationToken)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CShowBattleSummary_003Ed__81 _003CShowBattleSummary_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CShowBattleSummary_003Ed__81>(ref awaiter, ref _003CShowBattleSummary_003Ed__);
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
	private sealed class _003CStartBattle_003Ed__78 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleOpponentPresentationModel opponent;

		public BattleListViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private ValueTuple<bool, string> _003CvalidationResult_003E5__3;

		private bool _003CisPvP_003E5__4;

		private Result<PreCommitBattleResult> _003CpreCommitResult_003E5__5;

		private BattleLaunchRequest _003CbattleRequest_003E5__6;

		private BattleResultDTO _003CbattleResult_003E5__7;

		private Result<PreCommitBattleResult> _003C_003Es__8;

		private BattleResultDTO _003C_003Es__9;

		private global::System.Exception _003Cex_003E5__10;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<Result<PreCommitBattleResult>> _003C_003Eu__2;

		private TaskAwaiter<BattleResultDTO> _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_0710: Unknown result type (might be due to invalid IL or missing references)
			//IL_0715: Unknown result type (might be due to invalid IL or missing references)
			//IL_072a: Unknown result type (might be due to invalid IL or missing references)
			//IL_072c: Unknown result type (might be due to invalid IL or missing references)
			//IL_074a: Unknown result type (might be due to invalid IL or missing references)
			//IL_074f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0757: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_01de: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0251: Unknown result type (might be due to invalid IL or missing references)
			//IL_0256: Unknown result type (might be due to invalid IL or missing references)
			//IL_025e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0576: Unknown result type (might be due to invalid IL or missing references)
			//IL_057b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0583: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_05f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0677: Unknown result type (might be due to invalid IL or missing references)
			//IL_067c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0684: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_05aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_05af: Unknown result type (might be due to invalid IL or missing references)
			//IL_063d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0642: Unknown result type (might be due to invalid IL or missing references)
			//IL_06a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_05c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_05c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0657: Unknown result type (might be due to invalid IL or missing references)
			//IL_0659: Unknown result type (might be due to invalid IL or missing references)
			//IL_0217: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0369: Unknown result type (might be due to invalid IL or missing references)
			//IL_036e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0231: Unknown result type (might be due to invalid IL or missing references)
			//IL_0233: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0383: Unknown result type (might be due to invalid IL or missing references)
			//IL_0385: Unknown result type (might be due to invalid IL or missing references)
			//IL_053c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0541: Unknown result type (might be due to invalid IL or missing references)
			//IL_0556: Unknown result type (might be due to invalid IL or missing references)
			//IL_0558: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 8u || (_003C_003E4__this.CanBattle && !(opponent == null) && _003C_003E4__this._navigationService.CanNavigate()))
				{
					try
					{
						TaskAwaiter awaiter;
						if ((uint)num > 7u)
						{
							if (num == 8)
							{
								awaiter = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0766;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter awaiter9;
							TaskAwaiter awaiter8;
							TaskAwaiter awaiter7;
							TaskAwaiter<Result<PreCommitBattleResult>> awaiter6;
							TaskAwaiter awaiter5;
							TaskAwaiter awaiter4;
							TaskAwaiter<BattleResultDTO> awaiter3;
							TaskAwaiter awaiter2;
							BattleLaunchRequest obj;
							object obj2;
							switch (num)
							{
							default:
								_003C_003E4__this.IsBattling = true;
								_003CvalidationResult_003E5__3 = _003C_003E4__this.ValidateBattlePreconditions();
								if (!_003CvalidationResult_003E5__3.Item1)
								{
									awaiter9 = _003C_003E4__this._navigationService.ShowAlertAsync("Cannot Start Battle", _003CvalidationResult_003E5__3.Item2).GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter9)).IsCompleted)
									{
										num = (_003C_003E1__state = 0);
										_003C_003Eu__1 = awaiter9;
										_003CStartBattle_003Ed__78 _003CStartBattle_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CStartBattle_003Ed__78>(ref awaiter9, ref _003CStartBattle_003Ed__);
										return;
									}
									goto IL_0168;
								}
								if (!opponent.HasSpirits)
								{
									awaiter8 = _003C_003E4__this._navigationService.ShowAlertAsync("Cannot Start Battle", "Opponent data is not available. Please refresh the list.").GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter8)).IsCompleted)
									{
										num = (_003C_003E1__state = 1);
										_003C_003Eu__1 = awaiter8;
										_003CStartBattle_003Ed__78 _003CStartBattle_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CStartBattle_003Ed__78>(ref awaiter8, ref _003CStartBattle_003Ed__);
										return;
									}
									goto IL_01fa;
								}
								awaiter7 = _003C_003E4__this._stateService.EnsureSyncedAsync().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter7)).IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__1 = awaiter7;
									_003CStartBattle_003Ed__78 _003CStartBattle_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CStartBattle_003Ed__78>(ref awaiter7, ref _003CStartBattle_003Ed__);
									return;
								}
								goto IL_026d;
							case 0:
								awaiter9 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0168;
							case 1:
								awaiter8 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_01fa;
							case 2:
								awaiter7 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_026d;
							case 3:
								awaiter6 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter<Result<PreCommitBattleResult>>);
								num = (_003C_003E1__state = -1);
								goto IL_0308;
							case 4:
								awaiter5 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_03bf;
							case 5:
								awaiter4 = _003C_003Eu__1;
								_003C_003Eu__1 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0592;
							case 6:
								awaiter3 = _003C_003Eu__3;
								_003C_003Eu__3 = default(TaskAwaiter<BattleResultDTO>);
								num = (_003C_003E1__state = -1);
								goto IL_0600;
							case 7:
								{
									awaiter2 = _003C_003Eu__1;
									_003C_003Eu__1 = default(TaskAwaiter);
									num = (_003C_003E1__state = -1);
									break;
								}
								IL_0308:
								_003C_003Es__8 = awaiter6.GetResult();
								_003CpreCommitResult_003E5__5 = _003C_003Es__8;
								_003C_003Es__8 = null;
								if (!_003CpreCommitResult_003E5__5.Success)
								{
									awaiter5 = _003C_003E4__this._navigationService.ShowAlertAsync("Cannot Start Battle", _003CpreCommitResult_003E5__5.ErrorMessage ?? "Failed to start battle.").GetAwaiter();
									if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
									{
										num = (_003C_003E1__state = 4);
										_003C_003Eu__1 = awaiter5;
										_003CStartBattle_003Ed__78 _003CStartBattle_003Ed__ = this;
										((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CStartBattle_003Ed__78>(ref awaiter5, ref _003CStartBattle_003Ed__);
										return;
									}
									goto IL_03bf;
								}
								obj = new BattleLaunchRequest
								{
									Mode = BattleMode.PVP
								};
								if (_003C_003E4__this.CurrentBattleType != 0 && _003C_003E4__this.CurrentBattleType != BattlesType.NPC)
								{
									obj2 = new List<string>(1);
									((List<string>)obj2).Add(_003C_003E4__this._stateService.GetCurrentPlayer()?.PartnerSpiritId ?? "");
								}
								else
								{
									Player? currentPlayer = _003C_003E4__this._stateService.GetCurrentPlayer();
									obj2 = ((currentPlayer != null) ? Enumerable.ToList<string>(Enumerable.Where<string>((global::System.Collections.Generic.IEnumerable<string>)currentPlayer.ActiveSquad, (Func<string, bool>)((string id) => !string.IsNullOrEmpty(id)))) : null) ?? new List<string>();
								}
								obj.PlayerSpiritIds = (List<string>)obj2;
								obj.OpponentPlayerId = opponent.PlayerId;
								obj.OpponentName = opponent.Username;
								obj.OpponentLevel = opponent.Level;
								obj.OpponentSpirits = opponent.OpponentSpirits;
								obj.BattleId = _003CpreCommitResult_003E5__5.Data.BattleId;
								obj.PreCommittedScorePenalty = _003CpreCommitResult_003E5__5.Data.PreCommittedScorePenalty;
								obj.CompletionSource = new TaskCompletionSource<BattleResultDTO>();
								_003CbattleRequest_003E5__6 = obj;
								awaiter4 = _003C_003E4__this._navigationService.NavigateToBattleViewAsync(_003C_003E4__this._stateService?.CurrentRoute + "/battleground", _003CbattleRequest_003E5__6).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
								{
									num = (_003C_003E1__state = 5);
									_003C_003Eu__1 = awaiter4;
									_003CStartBattle_003Ed__78 _003CStartBattle_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CStartBattle_003Ed__78>(ref awaiter4, ref _003CStartBattle_003Ed__);
									return;
								}
								goto IL_0592;
								IL_026d:
								((TaskAwaiter)(ref awaiter7)).GetResult();
								_003CisPvP_003E5__4 = _003C_003E4__this.CurrentBattleType != BattlesType.NPC;
								awaiter6 = _003C_003E4__this._preCommitBattleUseCase.ExecuteAsync(new PreCommitBattleRequest(opponent.Level, _003CisPvP_003E5__4)).GetAwaiter();
								if (!awaiter6.IsCompleted)
								{
									num = (_003C_003E1__state = 3);
									_003C_003Eu__2 = awaiter6;
									_003CStartBattle_003Ed__78 _003CStartBattle_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<PreCommitBattleResult>>, _003CStartBattle_003Ed__78>(ref awaiter6, ref _003CStartBattle_003Ed__);
									return;
								}
								goto IL_0308;
								IL_0168:
								((TaskAwaiter)(ref awaiter9)).GetResult();
								goto end_IL_0052;
								IL_0592:
								((TaskAwaiter)(ref awaiter4)).GetResult();
								awaiter3 = _003CbattleRequest_003E5__6.CompletionSource.Task.GetAwaiter();
								if (!awaiter3.IsCompleted)
								{
									num = (_003C_003E1__state = 6);
									_003C_003Eu__3 = awaiter3;
									_003CStartBattle_003Ed__78 _003CStartBattle_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<BattleResultDTO>, _003CStartBattle_003Ed__78>(ref awaiter3, ref _003CStartBattle_003Ed__);
									return;
								}
								goto IL_0600;
								IL_03bf:
								((TaskAwaiter)(ref awaiter5)).GetResult();
								goto end_IL_0052;
								IL_0600:
								_003C_003Es__9 = awaiter3.GetResult();
								_003CbattleResult_003E5__7 = _003C_003Es__9;
								_003C_003Es__9 = null;
								awaiter2 = _003C_003E4__this.ProcessBattleResults(_003CbattleResult_003E5__7, opponent, _003CbattleRequest_003E5__6).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
								{
									num = (_003C_003E1__state = 7);
									_003C_003Eu__1 = awaiter2;
									_003CStartBattle_003Ed__78 _003CStartBattle_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CStartBattle_003Ed__78>(ref awaiter2, ref _003CStartBattle_003Ed__);
									return;
								}
								break;
								IL_01fa:
								((TaskAwaiter)(ref awaiter8)).GetResult();
								goto end_IL_0052;
							}
							((TaskAwaiter)(ref awaiter2)).GetResult();
							_003CvalidationResult_003E5__3 = default(ValueTuple<bool, string>);
							_003CpreCommitResult_003E5__5 = null;
							_003CbattleRequest_003E5__6 = null;
							_003CbattleResult_003E5__7 = null;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
						}
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_07aa;
						}
						_003Cex_003E5__10 = (global::System.Exception)_003C_003Es__1;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Battle Error", "An error occurred during battle").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 8);
							_003C_003Eu__1 = awaiter;
							_003CStartBattle_003Ed__78 _003CStartBattle_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CStartBattle_003Ed__78>(ref awaiter, ref _003CStartBattle_003Ed__);
							return;
						}
						goto IL_0766;
						IL_0766:
						((TaskAwaiter)(ref awaiter)).GetResult();
						Console.WriteLine($"StartBattle error: {_003Cex_003E5__10}");
						_003Cex_003E5__10 = null;
						goto IL_07aa;
						IL_07aa:
						_003C_003Es__1 = null;
						end_IL_0052:;
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this.IsBattling = false;
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

	private readonly INavigationService _navigationService;

	private readonly IPopupService _popupService;

	private readonly IPlayerStateService _stateService;

	private readonly PlayerInfoModel _playerInfoModel;

	private readonly SpiritCardModelFactory _spiritCardModelFactory;

	private readonly IServiceProvider _serviceProvider;

	private readonly GetOnlinePlayersUseCase _getOnlinePlayersUseCase;

	private readonly GenerateNPCOpponentsUseCase _generateNPCOpponentsUseCase;

	private readonly CompleteBattleUseCase _completeBattleUseCase;

	private readonly PreCommitBattleUseCase _preCommitBattleUseCase;

	private readonly UpdateBattleTaskProgressUseCase _updateBattleTaskProgressUseCase;

	private readonly IChatUnreadService _chatUnreadService;

	private readonly NavBarViewModel _navBarViewModel;

	private readonly IServerTimeProvider _serverTimeProvider;

	private readonly IBottomSheetService _bottomSheetService;

	private bool _disposed;

	private bool _isCached = false;

	private const int MINIUM_LEVEL_PVP3v3 = 10;

	private const int MINIUM_LEVEL_NPC = 5;

	private const int MINIUM_LEVEL_PVP1v1 = 1;

	private const int REFRESH_COOLDOWN_MINUTES = 5;

	private const double DEFEATED_COOLDOWN_MINUTES = 0.1;

	private IDispatcherTimer? _cooldownTimer;

	private readonly Dictionary<BattlesType, List<BattleOpponentPresentationModel>> _opponentCache = new Dictionary<BattlesType, List<BattleOpponentPresentationModel>>();

	private readonly Dictionary<BattlesType, DateTimeOffset> _lastRefreshByType = new Dictionary<BattlesType, DateTimeOffset>();

	private readonly Dictionary<string, DateTimeOffset> _defeatedOpponents = new Dictionary<string, DateTimeOffset>();

	private string? _acquiredPartnerSpiritId;

	[ObservableProperty]
	[NotifyPropertyChangedFor("CanBattle")]
	private bool _isBattling = false;

	[ObservableProperty]
	private SpiritSquadViewModel? _activeSquad;

	[ObservableProperty]
	private SpiritCardModel? _partnerSpiritModel;

	[ObservableProperty]
	[NotifyPropertyChangedFor("EnoughLevel")]
	[NotifyPropertyChangedFor("MinimumLevelRequired")]
	[NotifyPropertyChangedFor("CanRefresh")]
	private BattlesType _currentBattleType;

	[ObservableProperty]
	private ObservableCollection<BattleOpponentPresentationModel> _summoners = new ObservableCollection<BattleOpponentPresentationModel>();

	[ObservableProperty]
	[NotifyPropertyChangedFor("CanBattle")]
	private bool _isLoading;

	[ObservableProperty]
	private bool _isLoaded;

	[ObservableProperty]
	private string _errorMessage = string.Empty;

	[ObservableProperty]
	[NotifyPropertyChangedFor("CanRefresh")]
	private bool _isRefreshing;

	[ObservableProperty]
	private string _refreshCooldownText = string.Empty;

	[ObservableProperty]
	private bool _hasUnreadMessages;

	[ObservableProperty]
	private int _unreadMessageCount;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<object?>? loadDataCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<string>? selectBattleTypeCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? refreshOpponentsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<string>? navigateToSpiritDetailsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goToPortalCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goToFullCollectionCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goToSquadsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goBackCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? navigateToChatCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<BattleOpponentPresentationModel>? startBattleCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? openSpiritsHoldNavigationCommand;

	public bool CanBattle => !IsLoading && !IsBattling;

	public bool CanRefresh
	{
		get
		{
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			DateTimeOffset val = default(DateTimeOffset);
			return !IsRefreshing && !IsLoading && (!_lastRefreshByType.TryGetValue(CurrentBattleType, ref val) || _serverTimeProvider.GetCurrentServerTime() - val >= TimeSpan.FromMinutes(5L));
		}
	}

	public bool HasValidSquad
	{
		get
		{
			int result;
			if (CurrentBattleType != 0 && CurrentBattleType != BattlesType.NPC)
			{
				result = ((!string.IsNullOrEmpty(_stateService.GetCurrentPlayer().PartnerSpiritId)) ? 1 : 0);
			}
			else
			{
				IPlayerStateService stateService = _stateService;
				if (stateService == null)
				{
					result = 0;
				}
				else
				{
					Player? currentPlayer = stateService.GetCurrentPlayer();
					result = (((currentPlayer != null) ? new bool?(Enumerable.All<string>((global::System.Collections.Generic.IEnumerable<string>)currentPlayer.Squads[_playerInfoModel.ActiveSquadSlot.ToString()], (Func<string, bool>)((string l) => !string.IsNullOrEmpty(l)))) : null).GetValueOrDefault() ? 1 : 0);
				}
			}
			return (byte)result != 0;
		}
	}

	public bool HasEnoughSP
	{
		get
		{
			PlayerInfoModel playerInfoModel = _playerInfoModel;
			return playerInfoModel != null && playerInfoModel.BattlePoints >= 1;
		}
	}

	public PlayerInfoModel PlayerInfoModel => _playerInfoModel;

	public bool IsAccountLinked
	{
		get
		{
			IPlayerStateService stateService = _stateService;
			return stateService != null && (stateService.GetCurrentPlayer()?.IsAccountLinked).GetValueOrDefault();
		}
	}

	public int MinimumLevelRequired
	{
		get
		{
			BattlesType currentBattleType = CurrentBattleType;
			if (1 == 0)
			{
			}
			int result = currentBattleType switch
			{
				BattlesType.PvP3v3 => 10, 
				BattlesType.NPC => 5, 
				_ => 1, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
	}

	public bool EnoughLevel => _stateService?.GetCurrentPlayer()?.PlayerLevel >= MinimumLevelRequired;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsBattling
	{
		get
		{
			return _isBattling;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isBattling, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsBattling);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanBattle);
				_isBattling = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsBattling);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanBattle);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public SpiritSquadViewModel? ActiveSquad
	{
		get
		{
			return _activeSquad;
		}
		set
		{
			if (!EqualityComparer<SpiritSquadViewModel>.Default.Equals(_activeSquad, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ActiveSquad);
				_activeSquad = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ActiveSquad);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public SpiritCardModel? PartnerSpiritModel
	{
		get
		{
			return _partnerSpiritModel;
		}
		set
		{
			if (!EqualityComparer<SpiritCardModel>.Default.Equals(_partnerSpiritModel, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PartnerSpiritModel);
				_partnerSpiritModel = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PartnerSpiritModel);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public BattlesType CurrentBattleType
	{
		get
		{
			return _currentBattleType;
		}
		set
		{
			if (!EqualityComparer<BattlesType>.Default.Equals(_currentBattleType, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentBattleType);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.EnoughLevel);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.MinimumLevelRequired);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanRefresh);
				_currentBattleType = value;
				OnCurrentBattleTypeChanged(value);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentBattleType);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.EnoughLevel);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MinimumLevelRequired);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanRefresh);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<BattleOpponentPresentationModel> Summoners
	{
		get
		{
			return _summoners;
		}
		[MemberNotNull("_summoners")]
		set
		{
			if (!EqualityComparer<ObservableCollection<BattleOpponentPresentationModel>>.Default.Equals(_summoners, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Summoners);
				_summoners = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Summoners);
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
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanBattle);
				_isLoading = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsLoading);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanBattle);
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

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsRefreshing
	{
		get
		{
			return _isRefreshing;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isRefreshing, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsRefreshing);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanRefresh);
				_isRefreshing = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsRefreshing);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanRefresh);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string RefreshCooldownText
	{
		get
		{
			return _refreshCooldownText;
		}
		[MemberNotNull("_refreshCooldownText")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_refreshCooldownText, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.RefreshCooldownText);
				_refreshCooldownText = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.RefreshCooldownText);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool HasUnreadMessages
	{
		get
		{
			return _hasUnreadMessages;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasUnreadMessages, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasUnreadMessages);
				_hasUnreadMessages = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasUnreadMessages);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int UnreadMessageCount
	{
		get
		{
			return _unreadMessageCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_unreadMessageCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.UnreadMessageCount);
				_unreadMessageCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.UnreadMessageCount);
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
	public IAsyncRelayCommand<string> SelectBattleTypeCommand => (IAsyncRelayCommand<string>)(object)(selectBattleTypeCommand ?? (selectBattleTypeCommand = new AsyncRelayCommand<string>((Func<string, global::System.Threading.Tasks.Task>)SelectBattleType)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand RefreshOpponentsCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = refreshOpponentsCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)RefreshOpponents);
				AsyncRelayCommand val2 = val;
				refreshOpponentsCommand = val;
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
	public IAsyncRelayCommand GoToPortalCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = goToPortalCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)GoToPortal);
				AsyncRelayCommand val2 = val;
				goToPortalCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand GoToFullCollectionCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = goToFullCollectionCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)GoToFullCollection);
				AsyncRelayCommand val2 = val;
				goToFullCollectionCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand GoToSquadsCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = goToSquadsCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)GoToSquads);
				AsyncRelayCommand val2 = val;
				goToSquadsCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand GoBackCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = goBackCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)GoBack);
				AsyncRelayCommand val2 = val;
				goBackCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand NavigateToChatCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = navigateToChatCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)NavigateToChat);
				AsyncRelayCommand val2 = val;
				navigateToChatCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<BattleOpponentPresentationModel> StartBattleCommand => (IAsyncRelayCommand<BattleOpponentPresentationModel>)(object)(startBattleCommand ?? (startBattleCommand = new AsyncRelayCommand<BattleOpponentPresentationModel>((Func<BattleOpponentPresentationModel, global::System.Threading.Tasks.Task>)StartBattle)));

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

	public BattleListViewModel(INavigationService navigationService, IPopupService popupService, PlayerInfoModel playerInfoModel, IServiceProvider serviceProvider, IPlayerStateService playerStateService, GetOnlinePlayersUseCase getOnlinePlayersUseCase, GenerateNPCOpponentsUseCase generateNPCOpponentsUseCase, CompleteBattleUseCase completeBattleUseCase, PreCommitBattleUseCase preCommitBattleUseCase, UpdateBattleTaskProgressUseCase updateBattleTaskProgressUseCase, SpiritCardModelFactory spiritCardModelFactory, IChatUnreadService chatUnreadService, NavBarViewModel navBarViewModel, IServerTimeProvider serverTimeProvider, IBottomSheetService bottomSheetService)
	{
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		_navigationService = navigationService;
		_popupService = popupService;
		_playerInfoModel = playerInfoModel;
		_serviceProvider = serviceProvider;
		_stateService = playerStateService;
		_getOnlinePlayersUseCase = getOnlinePlayersUseCase;
		_generateNPCOpponentsUseCase = generateNPCOpponentsUseCase;
		_completeBattleUseCase = completeBattleUseCase;
		_preCommitBattleUseCase = preCommitBattleUseCase;
		_updateBattleTaskProgressUseCase = updateBattleTaskProgressUseCase;
		_spiritCardModelFactory = spiritCardModelFactory;
		_chatUnreadService = chatUnreadService;
		_navBarViewModel = navBarViewModel;
		_serverTimeProvider = serverTimeProvider;
		_bottomSheetService = bottomSheetService;
		_stateService.StateChanged += OnPlayerStateChanged;
		_chatUnreadService.UnreadCountChanged += new EventHandler(OnUnreadCountChanged);
		HasUnreadMessages = _chatUnreadService.HasUnread;
		UnreadMessageCount = _chatUnreadService.TotalUnreadCount;
	}

	private void OnPlayerStateChanged(object? sender, StateChangedEventArgs e)
	{
		if (e.Scope != 0)
		{
			return;
		}
		string changeType = e.ChangeType;
		string text = changeType;
		if (!(text == "Energy"))
		{
			if (!(text == "Squad"))
			{
				if (text == "Partner")
				{
					((ObservableObject)this).OnPropertyChanged("HasValidSquad");
					((ObservableObject)this).OnPropertyChanged("CanBattle");
					LoadPartnerSpirit();
				}
			}
			else
			{
				LoadDataAsync();
			}
		}
		else
		{
			((ObservableObject)this).OnPropertyChanged("HasEnoughSP");
			((ObservableObject)this).OnPropertyChanged("CanBattle");
		}
		((ObservableObject)this).OnPropertyChanged("Player");
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__57))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? parameter = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__57 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__57();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.parameter = parameter;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__57>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadPartnerSpirit_003Ed__58))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadPartnerSpirit()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadPartnerSpirit_003Ed__58 _003CLoadPartnerSpirit_003Ed__ = new _003CLoadPartnerSpirit_003Ed__58();
		_003CLoadPartnerSpirit_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadPartnerSpirit_003Ed__._003C_003E4__this = this;
		_003CLoadPartnerSpirit_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadPartnerSpirit_003Ed__._003C_003Et__builder)).Start<_003CLoadPartnerSpirit_003Ed__58>(ref _003CLoadPartnerSpirit_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadPartnerSpirit_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadSquadData_003Ed__59))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<bool> LoadSquadData()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ActiveSquad?.Dispose();
			ActiveSquad = ActivatorUtilities.CreateInstance<SpiritSquadViewModel>(_serviceProvider, global::System.Array.Empty<object>());
			return true;
		}
		catch (global::System.Exception ex)
		{
			await _navigationService.ShowAlertAsync("Error", "Failed to load squad data");
			Console.WriteLine($"Error loading squad: {ex}");
			ActiveSquad = null;
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CLoadOpponents_003Ed__60))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadOpponents()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadOpponents_003Ed__60 _003CLoadOpponents_003Ed__ = new _003CLoadOpponents_003Ed__60();
		_003CLoadOpponents_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadOpponents_003Ed__._003C_003E4__this = this;
		_003CLoadOpponents_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadOpponents_003Ed__._003C_003Et__builder)).Start<_003CLoadOpponents_003Ed__60>(ref _003CLoadOpponents_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadOpponents_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSelectBattleType_003Ed__61))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task SelectBattleType(string battleType)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSelectBattleType_003Ed__61 _003CSelectBattleType_003Ed__ = new _003CSelectBattleType_003Ed__61();
		_003CSelectBattleType_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSelectBattleType_003Ed__._003C_003E4__this = this;
		_003CSelectBattleType_003Ed__.battleType = battleType;
		_003CSelectBattleType_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSelectBattleType_003Ed__._003C_003Et__builder)).Start<_003CSelectBattleType_003Ed__61>(ref _003CSelectBattleType_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSelectBattleType_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRefreshOpponents_003Ed__62))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task RefreshOpponents()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRefreshOpponents_003Ed__62 _003CRefreshOpponents_003Ed__ = new _003CRefreshOpponents_003Ed__62();
		_003CRefreshOpponents_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRefreshOpponents_003Ed__._003C_003E4__this = this;
		_003CRefreshOpponents_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRefreshOpponents_003Ed__._003C_003Et__builder)).Start<_003CRefreshOpponents_003Ed__62>(ref _003CRefreshOpponents_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRefreshOpponents_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadOnlineOpponents_003Ed__63))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadOnlineOpponents(int teamSize)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadOnlineOpponents_003Ed__63 _003CLoadOnlineOpponents_003Ed__ = new _003CLoadOnlineOpponents_003Ed__63();
		_003CLoadOnlineOpponents_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadOnlineOpponents_003Ed__._003C_003E4__this = this;
		_003CLoadOnlineOpponents_003Ed__.teamSize = teamSize;
		_003CLoadOnlineOpponents_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadOnlineOpponents_003Ed__._003C_003Et__builder)).Start<_003CLoadOnlineOpponents_003Ed__63>(ref _003CLoadOnlineOpponents_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadOnlineOpponents_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadNPCOpponents_003Ed__64))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadNPCOpponents()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadNPCOpponents_003Ed__64 _003CLoadNPCOpponents_003Ed__ = new _003CLoadNPCOpponents_003Ed__64();
		_003CLoadNPCOpponents_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadNPCOpponents_003Ed__._003C_003E4__this = this;
		_003CLoadNPCOpponents_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadNPCOpponents_003Ed__._003C_003Et__builder)).Start<_003CLoadNPCOpponents_003Ed__64>(ref _003CLoadNPCOpponents_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadNPCOpponents_003Ed__._003C_003Et__builder)).Task;
	}

	private List<BattleOpponentPresentationModel> FilterDefeatedOpponents(List<BattleOpponentPresentationModel> opponents)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		List<string> val = Enumerable.ToList<string>(Enumerable.Select<KeyValuePair<string, DateTimeOffset>, string>(Enumerable.Where<KeyValuePair<string, DateTimeOffset>>((global::System.Collections.Generic.IEnumerable<KeyValuePair<string, DateTimeOffset>>)_defeatedOpponents, (Func<KeyValuePair<string, DateTimeOffset>, bool>)([CompilerGenerated] (KeyValuePair<string, DateTimeOffset> kv) => _serverTimeProvider.GetCurrentServerTime() - kv.Value >= TimeSpan.FromMinutes(0.1))), (Func<KeyValuePair<string, DateTimeOffset>, string>)((KeyValuePair<string, DateTimeOffset> kv) => kv.Key)));
		Enumerator<string> enumerator = val.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				_defeatedOpponents.Remove(current);
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator).Dispose();
		}
		return Enumerable.ToList<BattleOpponentPresentationModel>(Enumerable.Where<BattleOpponentPresentationModel>((global::System.Collections.Generic.IEnumerable<BattleOpponentPresentationModel>)opponents, (Func<BattleOpponentPresentationModel, bool>)([CompilerGenerated] (BattleOpponentPresentationModel o) => !_defeatedOpponents.ContainsKey(o.PlayerId))));
	}

	private void StartCooldownTimer()
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		StopCooldownTimer();
		Application current = Application.Current;
		_cooldownTimer = ((current != null) ? ((BindableObject)current).Dispatcher.CreateTimer() : null);
		if (_cooldownTimer != null)
		{
			_cooldownTimer.Interval = TimeSpan.FromSeconds(1L);
			_cooldownTimer.Tick += new EventHandler(OnCooldownTimerTick);
			UpdateCooldownText();
			_cooldownTimer.Start();
		}
	}

	private void OnCooldownTimerTick(object? sender, EventArgs e)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		DateTimeOffset val = default(DateTimeOffset);
		if (!_lastRefreshByType.TryGetValue(CurrentBattleType, ref val))
		{
			StopCooldownTimer();
			RefreshCooldownText = string.Empty;
			((ObservableObject)this).OnPropertyChanged("CanRefresh");
			return;
		}
		TimeSpan val2 = TimeSpan.FromMinutes(5L) - (_serverTimeProvider.GetCurrentServerTime() - val);
		if (val2 <= TimeSpan.Zero)
		{
			StopCooldownTimer();
			RefreshCooldownText = string.Empty;
			((ObservableObject)this).OnPropertyChanged("CanRefresh");
		}
		else
		{
			RefreshCooldownText = $"Refresh available in {((TimeSpan)(ref val2)).Minutes}:{((TimeSpan)(ref val2)).Seconds:D2}";
		}
	}

	private void StopCooldownTimer()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		if (_cooldownTimer != null)
		{
			_cooldownTimer.Stop();
			_cooldownTimer.Tick -= new EventHandler(OnCooldownTimerTick);
			_cooldownTimer = null;
		}
	}

	private void UpdateCooldownText()
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		DateTimeOffset val = default(DateTimeOffset);
		if (!_lastRefreshByType.TryGetValue(CurrentBattleType, ref val))
		{
			RefreshCooldownText = string.Empty;
			((ObservableObject)this).OnPropertyChanged("CanRefresh");
			return;
		}
		TimeSpan val2 = TimeSpan.FromMinutes(5L) - (_serverTimeProvider.GetCurrentServerTime() - val);
		RefreshCooldownText = ((val2 > TimeSpan.Zero) ? $"Refresh available in {((TimeSpan)(ref val2)).Minutes}:{((TimeSpan)(ref val2)).Seconds:D2}" : string.Empty);
		((ObservableObject)this).OnPropertyChanged("CanRefresh");
	}

	private void ShowCooldownAlert()
	{
		if (!EnoughLevel)
		{
			string message = ((CurrentBattleType == BattlesType.PvP3v3) ? $"You must progress to Level {MinimumLevelRequired} to compete in 3v3 battles" : $"You must progress to Level {MinimumLevelRequired} to compete in 1v1 battles");
			_navigationService.ShowAlertAsync("Level Required", message);
		}
		else if (!string.IsNullOrEmpty(RefreshCooldownText))
		{
			_navigationService.ShowAlertAsync("Refresh Cooldown", RefreshCooldownText);
		}
		else
		{
			_navigationService.ShowAlertAsync("Refresh Cooldown!", "Refresh is currently on cooldown!");
		}
	}

	[AsyncStateMachine(typeof(_003CNavigateToSpiritDetails_003Ed__71))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task NavigateToSpiritDetails(string id)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CNavigateToSpiritDetails_003Ed__71 _003CNavigateToSpiritDetails_003Ed__ = new _003CNavigateToSpiritDetails_003Ed__71();
		_003CNavigateToSpiritDetails_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CNavigateToSpiritDetails_003Ed__._003C_003E4__this = this;
		_003CNavigateToSpiritDetails_003Ed__.id = id;
		_003CNavigateToSpiritDetails_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CNavigateToSpiritDetails_003Ed__._003C_003Et__builder)).Start<_003CNavigateToSpiritDetails_003Ed__71>(ref _003CNavigateToSpiritDetails_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CNavigateToSpiritDetails_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGoToPortal_003Ed__72))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoToPortal()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoToPortal_003Ed__72 _003CGoToPortal_003Ed__ = new _003CGoToPortal_003Ed__72();
		_003CGoToPortal_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoToPortal_003Ed__._003C_003E4__this = this;
		_003CGoToPortal_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoToPortal_003Ed__._003C_003Et__builder)).Start<_003CGoToPortal_003Ed__72>(ref _003CGoToPortal_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoToPortal_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGoToFullCollection_003Ed__73))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoToFullCollection()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoToFullCollection_003Ed__73 _003CGoToFullCollection_003Ed__ = new _003CGoToFullCollection_003Ed__73();
		_003CGoToFullCollection_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoToFullCollection_003Ed__._003C_003E4__this = this;
		_003CGoToFullCollection_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoToFullCollection_003Ed__._003C_003Et__builder)).Start<_003CGoToFullCollection_003Ed__73>(ref _003CGoToFullCollection_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoToFullCollection_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGoToSquads_003Ed__74))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoToSquads()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoToSquads_003Ed__74 _003CGoToSquads_003Ed__ = new _003CGoToSquads_003Ed__74();
		_003CGoToSquads_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoToSquads_003Ed__._003C_003E4__this = this;
		_003CGoToSquads_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoToSquads_003Ed__._003C_003Et__builder)).Start<_003CGoToSquads_003Ed__74>(ref _003CGoToSquads_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoToSquads_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGoBack_003Ed__75))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoBack()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoBack_003Ed__75 _003CGoBack_003Ed__ = new _003CGoBack_003Ed__75();
		_003CGoBack_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoBack_003Ed__._003C_003E4__this = this;
		_003CGoBack_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Start<_003CGoBack_003Ed__75>(ref _003CGoBack_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CNavigateToChat_003Ed__76))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task NavigateToChat()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CNavigateToChat_003Ed__76 _003CNavigateToChat_003Ed__ = new _003CNavigateToChat_003Ed__76();
		_003CNavigateToChat_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CNavigateToChat_003Ed__._003C_003E4__this = this;
		_003CNavigateToChat_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CNavigateToChat_003Ed__._003C_003Et__builder)).Start<_003CNavigateToChat_003Ed__76>(ref _003CNavigateToChat_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CNavigateToChat_003Ed__._003C_003Et__builder)).Task;
	}

	private void OnUnreadCountChanged(object? sender, EventArgs e)
	{
		HasUnreadMessages = _chatUnreadService.HasUnread;
		UnreadMessageCount = _chatUnreadService.TotalUnreadCount;
	}

	[AsyncStateMachine(typeof(_003CStartBattle_003Ed__78))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task StartBattle(BattleOpponentPresentationModel opponent)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CStartBattle_003Ed__78 _003CStartBattle_003Ed__ = new _003CStartBattle_003Ed__78();
		_003CStartBattle_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CStartBattle_003Ed__._003C_003E4__this = this;
		_003CStartBattle_003Ed__.opponent = opponent;
		_003CStartBattle_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CStartBattle_003Ed__._003C_003Et__builder)).Start<_003CStartBattle_003Ed__78>(ref _003CStartBattle_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CStartBattle_003Ed__._003C_003Et__builder)).Task;
	}

	private ValueTuple<bool, string> ValidateBattlePreconditions()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		IPlayerStateService stateService = _stateService;
		if (new Func<Player>(stateService.GetCurrentPlayer) == null)
		{
			return new ValueTuple<bool, string>(false, "Player data not available");
		}
		if (!HasValidSquad)
		{
			return new ValueTuple<bool, string>(false, "Invalid squad! Check your collection!");
		}
		if (!HasEnoughSP)
		{
			return new ValueTuple<bool, string>(false, "Not enough SP! SP amount too low!");
		}
		return new ValueTuple<bool, string>(true, string.Empty);
	}

	[AsyncStateMachine(typeof(_003CProcessBattleResults_003Ed__80))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ProcessBattleResults(BattleResultDTO battleResult, BattleOpponentPresentationModel opponent, BattleLaunchRequest battleRequest)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CProcessBattleResults_003Ed__80 _003CProcessBattleResults_003Ed__ = new _003CProcessBattleResults_003Ed__80();
		_003CProcessBattleResults_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CProcessBattleResults_003Ed__._003C_003E4__this = this;
		_003CProcessBattleResults_003Ed__.battleResult = battleResult;
		_003CProcessBattleResults_003Ed__.opponent = opponent;
		_003CProcessBattleResults_003Ed__.battleRequest = battleRequest;
		_003CProcessBattleResults_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CProcessBattleResults_003Ed__._003C_003Et__builder)).Start<_003CProcessBattleResults_003Ed__80>(ref _003CProcessBattleResults_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CProcessBattleResults_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CShowBattleSummary_003Ed__81))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ShowBattleSummary(BattleResultDTO battleResult, BattleOpponentPresentationModel opponent, BattleRewards? rewards)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CShowBattleSummary_003Ed__81 _003CShowBattleSummary_003Ed__ = new _003CShowBattleSummary_003Ed__81();
		_003CShowBattleSummary_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CShowBattleSummary_003Ed__._003C_003E4__this = this;
		_003CShowBattleSummary_003Ed__.battleResult = battleResult;
		_003CShowBattleSummary_003Ed__.opponent = opponent;
		_003CShowBattleSummary_003Ed__.rewards = rewards;
		_003CShowBattleSummary_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CShowBattleSummary_003Ed__._003C_003Et__builder)).Start<_003CShowBattleSummary_003Ed__81>(ref _003CShowBattleSummary_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CShowBattleSummary_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003COpenSpiritsHoldNavigation_003Ed__82))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task OpenSpiritsHoldNavigation()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COpenSpiritsHoldNavigation_003Ed__82 _003COpenSpiritsHoldNavigation_003Ed__ = new _003COpenSpiritsHoldNavigation_003Ed__82();
		_003COpenSpiritsHoldNavigation_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003COpenSpiritsHoldNavigation_003Ed__._003C_003E4__this = this;
		_003COpenSpiritsHoldNavigation_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003COpenSpiritsHoldNavigation_003Ed__._003C_003Et__builder)).Start<_003COpenSpiritsHoldNavigation_003Ed__82>(ref _003COpenSpiritsHoldNavigation_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003COpenSpiritsHoldNavigation_003Ed__._003C_003Et__builder)).Task;
	}

	public void Dispose()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		if (!_disposed)
		{
			_stateService.StateChanged -= OnPlayerStateChanged;
			_chatUnreadService.UnreadCountChanged -= new EventHandler(OnUnreadCountChanged);
			StopCooldownTimer();
			_opponentCache.Clear();
			_lastRefreshByType.Clear();
			_defeatedOpponents.Clear();
			if (!string.IsNullOrEmpty(_acquiredPartnerSpiritId))
			{
				_spiritCardModelFactory.ReleaseModel(_acquiredPartnerSpiritId);
				_acquiredPartnerSpiritId = null;
			}
			ActiveSquad?.Dispose();
			_disposed = true;
			GC.SuppressFinalize((object)this);
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnCurrentBattleTypeChanged(BattlesType value)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		StopCooldownTimer();
		UpdateCooldownText();
		DateTimeOffset val = default(DateTimeOffset);
		if (_lastRefreshByType.TryGetValue(value, ref val))
		{
			TimeSpan val2 = TimeSpan.FromMinutes(5L) - (_serverTimeProvider.GetCurrentServerTime() - val);
			if (val2 > TimeSpan.Zero)
			{
				StartCooldownTimer();
			}
		}
	}
}
