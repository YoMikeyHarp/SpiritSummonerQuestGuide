using System;
using System.CodeDom.Compiler;
using System.Collections;
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
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Application.Events;
using SpiritSummoner.Application.Services;
using SpiritSummoner.Application.State;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Enums.Shops;
using SpiritSummoner.Infrastructure.Cache;
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
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.ViewModels.Collections;

public class CollectionHubViewModel : ObservableObject, ILoadableViewModel, global::System.IDisposable
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass45_0
	{
		public string spiritId;

		internal bool _003CRemoveFromCollection_003Eb__3(SpiritCardViewModel s)
		{
			return s.Model.PlayerSpiritId == spiritId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass54_0
	{
		public View anchorView;

		public CollectionHubViewModel _003C_003E4__this;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass54_1
	{
		public FilterCollectionPopupViewModel filterVm;

		public _003C_003Ec__DisplayClass54_0 CS_0024_003C_003E8__locals1;

		internal void _003CShowFilterPopup_003Eb__0(FilterCollectionPopupViewModel vm)
		{
			filterVm = vm;
			vm.Anchor = CS_0024_003C_003E8__locals1.anchorView;
			vm.FilterCriteria = CS_0024_003C_003E8__locals1._003C_003E4__this.CurrentFilterCriteria;
			vm.UpdateFilters();
			vm.FilterUpdated += CS_0024_003C_003E8__locals1._003C_003E4__this.OnFilterUpdated;
		}
	}

	[CompilerGenerated]
	private sealed class _003CApplyFiltersAndSearch_003Ed__51 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public CollectionHubViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected O, but got Unknown
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = global::System.Threading.Tasks.Task.Run((Action)([CompilerGenerated] () =>
					{
						List<SpiritCardViewModel> val2 = (_003C_003E4__this.FilteredSpirits = Enumerable.ToList<SpiritCardViewModel>(Enumerable.Where<SpiritCardViewModel>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)_003C_003E4__this._originalSpirits, (Func<SpiritCardViewModel, bool>)([CompilerGenerated] (SpiritCardViewModel spirit) =>
						{
							bool flag = (!Enumerable.Any<string>(_003C_003E4__this.CurrentFilterCriteria.SelectedTypes) || Enumerable.Contains<string>(_003C_003E4__this.CurrentFilterCriteria.SelectedTypes, ((object)spirit.Model?.Type1).ToString() ?? "") || Enumerable.Contains<string>(_003C_003E4__this.CurrentFilterCriteria.SelectedTypes, ((object)spirit.Model.Type2).ToString() ?? "")) && (!Enumerable.Any<string>(_003C_003E4__this.CurrentFilterCriteria.SelectedCategories) || Enumerable.Contains<string>(_003C_003E4__this.CurrentFilterCriteria.SelectedCategories, spirit.Model.Class ?? "")) && (!_003C_003E4__this.CurrentFilterCriteria.Favorites || spirit.Model.IsFavorite);
							int num2;
							if (!string.IsNullOrWhiteSpace(_003C_003E4__this.SearchText))
							{
								string? nickname = spirit.Model.Nickname;
								if (nickname == null || !nickname.Contains(_003C_003E4__this.SearchText, (StringComparison)5))
								{
									string name = spirit.Model.Name;
									if ((name == null || !name.Contains(_003C_003E4__this.SearchText, (StringComparison)5)) && !((object)spirit.Model.Type1).ToString().Contains(_003C_003E4__this.SearchText, (StringComparison)5) && !((object)spirit.Model.Type2).ToString().Contains(_003C_003E4__this.SearchText, (StringComparison)5))
									{
										num2 = ((spirit.Model.Class?.Contains(_003C_003E4__this.SearchText, (StringComparison)5) ?? false) ? 1 : 0);
										goto IL_01a4;
									}
								}
							}
							num2 = 1;
							goto IL_01a4;
							IL_01a4:
							bool flag2 = (byte)num2 != 0;
							return flag && flag2;
						}))));
						((ObservableObject)_003C_003E4__this).OnPropertyChanged("AllSpirits");
						OrderBy orderBy = _003C_003E4__this.OrderBy;
						if (1 == 0)
						{
						}
						global::System.Collections.Generic.IEnumerable<SpiritCardViewModel> enumerable = orderBy switch
						{
							OrderBy.Recent => _003C_003E4__this.IsUp ? Enumerable.AsEnumerable<SpiritCardViewModel>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)Enumerable.OrderByDescending<SpiritCardViewModel, DateTimeOffset>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)val2, (Func<SpiritCardViewModel, DateTimeOffset>)((SpiritCardViewModel s) => s.Model.DateOwned))) : Enumerable.AsEnumerable<SpiritCardViewModel>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)Enumerable.OrderBy<SpiritCardViewModel, DateTimeOffset>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)val2, (Func<SpiritCardViewModel, DateTimeOffset>)((SpiritCardViewModel s) => s.Model.DateOwned))), 
							OrderBy.Level => _003C_003E4__this.IsUp ? Enumerable.AsEnumerable<SpiritCardViewModel>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)Enumerable.OrderByDescending<SpiritCardViewModel, int>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)val2, (Func<SpiritCardViewModel, int>)((SpiritCardViewModel s) => s.Model.Level))) : Enumerable.AsEnumerable<SpiritCardViewModel>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)Enumerable.OrderBy<SpiritCardViewModel, int>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)val2, (Func<SpiritCardViewModel, int>)((SpiritCardViewModel s) => s.Model.Level))), 
							OrderBy.Type => _003C_003E4__this.IsUp ? Enumerable.AsEnumerable<SpiritCardViewModel>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)Enumerable.OrderBy<SpiritCardViewModel, string>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)val2, (Func<SpiritCardViewModel, string>)((SpiritCardViewModel s) => ((object)s.Model?.Type1).ToString() ?? ""))) : Enumerable.AsEnumerable<SpiritCardViewModel>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)Enumerable.OrderByDescending<SpiritCardViewModel, string>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)val2, (Func<SpiritCardViewModel, string>)((SpiritCardViewModel s) => ((object)s.Model.Type1).ToString() ?? ""))), 
							OrderBy.Index => _003C_003E4__this.IsUp ? Enumerable.AsEnumerable<SpiritCardViewModel>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)Enumerable.OrderBy<SpiritCardViewModel, int>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)val2, (Func<SpiritCardViewModel, int>)((SpiritCardViewModel s) => s.Model.BaseSpiritId))) : Enumerable.AsEnumerable<SpiritCardViewModel>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)Enumerable.OrderByDescending<SpiritCardViewModel, int>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)val2, (Func<SpiritCardViewModel, int>)((SpiritCardViewModel s) => s.Model.BaseSpiritId))), 
							OrderBy.Name => _003C_003E4__this.IsUp ? Enumerable.AsEnumerable<SpiritCardViewModel>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)Enumerable.OrderBy<SpiritCardViewModel, string>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)val2, (Func<SpiritCardViewModel, string>)((SpiritCardViewModel s) => s.Model.Nickname ?? ""))) : Enumerable.AsEnumerable<SpiritCardViewModel>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)Enumerable.OrderByDescending<SpiritCardViewModel, string>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)val2, (Func<SpiritCardViewModel, string>)((SpiritCardViewModel s) => s.Model.Nickname ?? ""))), 
							_ => Enumerable.AsEnumerable<SpiritCardViewModel>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)val2), 
						};
						if (1 == 0)
						{
						}
						global::System.Collections.Generic.IEnumerable<SpiritCardViewModel> enumerable2 = enumerable;
						_003C_003E4__this.AllSpirits = new ObservableCollection<SpiritCardViewModel>(enumerable2);
					})).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CApplyFiltersAndSearch_003Ed__51 _003CApplyFiltersAndSearch_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CApplyFiltersAndSearch_003Ed__51>(ref awaiter, ref _003CApplyFiltersAndSearch_003Ed__);
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
	private sealed class _003CChangeSortType_003Ed__49 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string sortType;

		public CollectionHubViewModel _003C_003E4__this;

		private OrderBy _003CparsedEnum_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00cd;
				}
				if (global::System.Enum.TryParse<OrderBy>(sortType, ref _003CparsedEnum_003E5__1))
				{
					if (_003C_003E4__this.OrderBy == _003CparsedEnum_003E5__1)
					{
						_003C_003E4__this.IsUp = !_003C_003E4__this.IsUp;
					}
					_003C_003E4__this.OrderBy = _003CparsedEnum_003E5__1;
					awaiter = _003C_003E4__this.ApplyFiltersAndSearch().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CChangeSortType_003Ed__49 _003CChangeSortType_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CChangeSortType_003Ed__49>(ref awaiter, ref _003CChangeSortType_003Ed__);
						return;
					}
					goto IL_00cd;
				}
				goto end_IL_0007;
				IL_00cd:
				((TaskAwaiter)(ref awaiter)).GetResult();
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
	private sealed class _003CGoBack_003Ed__57 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public CollectionHubViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGoBack_003Ed__57 _003CGoBack_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoBack_003Ed__57>(ref awaiter, ref _003CGoBack_003Ed__);
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
	private sealed class _003CGoToIndexView_003Ed__47 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public CollectionHubViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_0143;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						awaiter2 = _003C_003E4__this._navigationService.NavigateToAsync("//collection/spiritindex").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CGoToIndexView_003Ed__47 _003CGoToIndexView_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToIndexView_003Ed__47>(ref awaiter2, ref _003CGoToIndexView_003Ed__);
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
					goto IL_0155;
				}
				_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Navigation Error", _003Cex_003E5__3.Message).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CGoToIndexView_003Ed__47 _003CGoToIndexView_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToIndexView_003Ed__47>(ref awaiter, ref _003CGoToIndexView_003Ed__);
					return;
				}
				goto IL_0143;
				IL_0143:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Cex_003E5__3 = null;
				goto IL_0155;
				IL_0155:
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
	private sealed class _003CGoToPortal_003Ed__56 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public CollectionHubViewModel _003C_003E4__this;

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
							_003CGoToPortal_003Ed__56 _003CGoToPortal_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<BottomSheet>, _003CGoToPortal_003Ed__56>(ref awaiter3, ref _003CGoToPortal_003Ed__);
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
						_003CGoToPortal_003Ed__56 _003CGoToPortal_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToPortal_003Ed__56>(ref awaiter2, ref _003CGoToPortal_003Ed__);
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
					_003CGoToPortal_003Ed__56 _003CGoToPortal_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToPortal_003Ed__56>(ref awaiter, ref _003CGoToPortal_003Ed__);
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
	private sealed class _003CLoadCollection_003Ed__44 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public CollectionHubViewModel _003C_003E4__this;

		private List<string> _003CallSpiritIds_003E5__1;

		private ObservableCollection<SpiritCardViewModel> _003Cvms_003E5__2;

		private List<string> _003Cids_003E5__3;

		private global::System.Collections.Generic.IEnumerator<SpiritCardViewModel> _003C_003Es__4;

		private SpiritCardViewModel _003Cvm_003E5__5;

		private ValueTuple<ObservableCollection<SpiritCardViewModel>, List<string>> _003C_003Es__6;

		private ValueTuple<ObservableCollection<SpiritCardViewModel>, List<string>> _003C_003Es__7;

		private global::System.Exception _003Cex_003E5__8;

		private TaskAwaiter<ValueTuple<ObservableCollection<SpiritCardViewModel>, List<string>>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0209: Unknown result type (might be due to invalid IL or missing references)
			//IL_0215: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<ValueTuple<ObservableCollection<SpiritCardViewModel>, List<string>>> awaiter;
					if (num != 0)
					{
						if (_003C_003E4__this._originalSpirits != null)
						{
							_003C_003Es__4 = ((Collection<SpiritCardViewModel>)(object)_003C_003E4__this._originalSpirits).GetEnumerator();
							try
							{
								while (((global::System.Collections.IEnumerator)_003C_003Es__4).MoveNext())
								{
									_003Cvm_003E5__5 = _003C_003Es__4.Current;
									_003Cvm_003E5__5?.Dispose();
									_003Cvm_003E5__5 = null;
								}
							}
							finally
							{
								if (num < 0 && _003C_003Es__4 != null)
								{
									((global::System.IDisposable)_003C_003Es__4).Dispose();
								}
							}
							_003C_003Es__4 = null;
						}
						SpiritCardViewModelHelper.ReleaseAll(_003C_003E4__this._modelFactory, (global::System.Collections.Generic.IEnumerable<string>?)_003C_003E4__this._acquiredSpiritIds);
						_003C_003E4__this._acquiredSpiritIds.Clear();
						_003CallSpiritIds_003E5__1 = Enumerable.ToList<string>(Enumerable.Where<string>(Enumerable.Select<PlayerSpirit, string>((global::System.Collections.Generic.IEnumerable<PlayerSpirit>)Enumerable.OrderByDescending<PlayerSpirit, int>((global::System.Collections.Generic.IEnumerable<PlayerSpirit>)_003C_003E4__this._stateService.GetAllPlayerSpirits(), (Func<PlayerSpirit, int>)((PlayerSpirit s) => s.Level)), (Func<PlayerSpirit, string>)((PlayerSpirit s) => s.PlayerSpiritID)), (Func<string, bool>)((string ps) => ps != null)));
						awaiter = SpiritCardViewModelHelper.CreateCollectionWithTrackingAsync(_003C_003E4__this._serviceProvider, _003C_003E4__this._modelFactory, (global::System.Collections.Generic.IEnumerable<string>)_003CallSpiritIds_003E5__1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CLoadCollection_003Ed__44 _003CLoadCollection_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<ValueTuple<ObservableCollection<SpiritCardViewModel>, List<string>>>, _003CLoadCollection_003Ed__44>(ref awaiter, ref _003CLoadCollection_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<ValueTuple<ObservableCollection<SpiritCardViewModel>, List<string>>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__6 = awaiter.GetResult();
					_003C_003Es__7 = _003C_003Es__6;
					_003Cvms_003E5__2 = _003C_003Es__7.Item1;
					_003Cids_003E5__3 = _003C_003Es__7.Item2;
					_003C_003Es__6 = default(ValueTuple<ObservableCollection<SpiritCardViewModel>, List<string>>);
					_003C_003Es__7 = default(ValueTuple<ObservableCollection<SpiritCardViewModel>, List<string>>);
					_003C_003E4__this._acquiredSpiritIds = _003Cids_003E5__3;
					_003C_003E4__this._originalSpirits = _003Cvms_003E5__2;
					_003C_003E4__this.AllSpirits = new ObservableCollection<SpiritCardViewModel>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)Enumerable.OrderByDescending<SpiritCardViewModel, int>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)_003C_003E4__this._originalSpirits, (Func<SpiritCardViewModel, int>)((SpiritCardViewModel s) => s.Model.Level)));
					_003CallSpiritIds_003E5__1 = null;
					_003Cvms_003E5__2 = null;
					_003Cids_003E5__3 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__8 = ex;
					_003C_003E4__this.ErrorMessage = "Failed to load favorites: " + _003Cex_003E5__8.Message;
					Debug.WriteLine($"LoadFavoriteSpiritsAsync error: {_003Cex_003E5__8}");
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
	private sealed class _003CLoadDataAsync_003Ed__43 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object param;

		public CollectionHubViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 2u || !_003C_003E4__this._isCached)
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
								goto IL_0206;
							}
							_003C_003Es__2 = 0;
						}
						try
						{
							TaskAwaiter<bool> awaiter2;
							TaskAwaiter awaiter3;
							if (num != 0)
							{
								if (num == 1)
								{
									awaiter2 = _003C_003Eu__2;
									_003C_003Eu__2 = default(TaskAwaiter<bool>);
									num = (_003C_003E1__state = -1);
									goto IL_0125;
								}
								_003C_003E4__this.IsLoading = true;
								awaiter3 = _003C_003E4__this.LoadCollection().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter3;
									_003CLoadDataAsync_003Ed__43 _003CLoadDataAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__43>(ref awaiter3, ref _003CLoadDataAsync_003Ed__);
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
							awaiter2 = _003C_003E4__this.LoadSquadData().GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter2;
								_003CLoadDataAsync_003Ed__43 _003CLoadDataAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CLoadDataAsync_003Ed__43>(ref awaiter2, ref _003CLoadDataAsync_003Ed__);
								return;
							}
							goto IL_0125;
							IL_0125:
							awaiter2.GetResult();
							_003C_003E4__this._isCached = true;
						}
						catch (global::System.Exception ex)
						{
							_003C_003Es__1 = ex;
							_003C_003Es__2 = 1;
						}
						int num2 = _003C_003Es__2;
						if (num2 != 1)
						{
							goto IL_0218;
						}
						_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
						_003C_003E4__this.ErrorMessage = "Failed to load collection: " + _003Cex_003E5__3.Message;
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003C_003E4__this.ErrorMessage).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 2);
							_003C_003Eu__1 = awaiter;
							_003CLoadDataAsync_003Ed__43 _003CLoadDataAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__43>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
							return;
						}
						goto IL_0206;
						IL_0206:
						((TaskAwaiter)(ref awaiter)).GetResult();
						_003Cex_003E5__3 = null;
						goto IL_0218;
						IL_0218:
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
	private sealed class _003CLoadSquadData_003Ed__46 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public CollectionHubViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
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
					goto IL_0120;
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
				IL_0120:
				((TaskAwaiter)(ref awaiter)).GetResult();
				Console.WriteLine(_003Cex_003E5__3.StackTrace);
				result = false;
				goto end_IL_0007;
				IL_006a:
				int num2 = _003C_003Es__2;
				if (num2 == 1)
				{
					_003Cex_003E5__3 = (global::System.Exception)_003C_003Es__1;
					_003C_003E4__this.ErrorMessage = "Failed to load squad: " + _003Cex_003E5__3.Message;
					awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003C_003E4__this.ErrorMessage).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CLoadSquadData_003Ed__46 _003CLoadSquadData_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadSquadData_003Ed__46>(ref awaiter, ref _003CLoadSquadData_003Ed__);
						return;
					}
					goto IL_0120;
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
	private sealed class _003CNavigateToChat_003Ed__58 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public CollectionHubViewModel _003C_003E4__this;

		private NavBarViewModel _003C_navBarViewModel_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_00fe;
					}
					_003C_navBarViewModel_003E5__1 = ServiceProviderServiceExtensions.GetRequiredService<NavBarViewModel>(_003C_003E4__this._serviceProvider);
					awaiter2 = _003C_navBarViewModel_003E5__1.NavigateToCommand.ExecuteAsync("//chat").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003CNavigateToChat_003Ed__58 _003CNavigateToChat_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToChat_003Ed__58>(ref awaiter2, ref _003CNavigateToChat_003Ed__);
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
				awaiter = _003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CNavigateToChat_003Ed__58 _003CNavigateToChat_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToChat_003Ed__58>(ref awaiter, ref _003CNavigateToChat_003Ed__);
					return;
				}
				goto IL_00fe;
				IL_00fe:
				((TaskAwaiter)(ref awaiter)).GetResult();
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_navBarViewModel_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_navBarViewModel_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CNavigateToSpiritDetails_003Ed__60 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public CollectionHubViewModel _003C_003E4__this;

		private string _003CspiritId_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
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
					_003CspiritId_003E5__1 = _003C_003E4__this._stateService.GetPartnerSpirit().PlayerSpiritID;
					awaiter = _003C_003E4__this._navigationService.NavigateToAsync(_003C_003E4__this._stateService.CurrentRoute + "/spiritdetails?spiritId=" + _003CspiritId_003E5__1).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CNavigateToSpiritDetails_003Ed__60 _003CNavigateToSpiritDetails_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToSpiritDetails_003Ed__60>(ref awaiter, ref _003CNavigateToSpiritDetails_003Ed__);
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
				_003CspiritId_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CspiritId_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CRefreshCollection_003Ed__48 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public CollectionHubViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_003C_003E4__this._isCached = false;
					awaiter = _003C_003E4__this.LoadDataAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CRefreshCollection_003Ed__48 _003CRefreshCollection_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRefreshCollection_003Ed__48>(ref awaiter, ref _003CRefreshCollection_003Ed__);
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
	private sealed class _003CRemoveFromCollection_003Ed__45 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public string spiritId;

		public CollectionHubViewModel _003C_003E4__this;

		private _003C_003Ec__DisplayClass45_0 _003C_003E8__1;

		private List<string> _003CallSpiritIds_003E5__2;

		private SpiritCardViewModel _003CspiritToRemove_003E5__3;

		private global::System.Exception _003Cex_003E5__4;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			try
			{
				_003C_003E8__1 = new _003C_003Ec__DisplayClass45_0();
				_003C_003E8__1.spiritId = spiritId;
				try
				{
					SpiritCardViewModelHelper.ReleaseModel(_003C_003E4__this._modelFactory, _003C_003E8__1.spiritId);
					_003C_003E4__this._acquiredSpiritIds.Clear();
					_003CallSpiritIds_003E5__2 = Enumerable.ToList<string>(Enumerable.Where<string>(Enumerable.Select<PlayerSpirit, string>((global::System.Collections.Generic.IEnumerable<PlayerSpirit>)Enumerable.OrderByDescending<PlayerSpirit, int>((global::System.Collections.Generic.IEnumerable<PlayerSpirit>)_003C_003E4__this._stateService.GetAllPlayerSpirits(), (Func<PlayerSpirit, int>)((PlayerSpirit s) => s.Level)), (Func<PlayerSpirit, string>)((PlayerSpirit s) => s.PlayerSpiritID)), (Func<string, bool>)((string ps) => ps != null)));
					_003C_003E4__this._acquiredSpiritIds.Remove(_003C_003E8__1.spiritId);
					ObservableCollection<SpiritCardViewModel>? originalSpirits = _003C_003E4__this._originalSpirits;
					_003CspiritToRemove_003E5__3 = ((originalSpirits != null) ? Enumerable.FirstOrDefault<SpiritCardViewModel>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)originalSpirits, (Func<SpiritCardViewModel, bool>)((SpiritCardViewModel s) => s.Model.PlayerSpiritId == _003C_003E8__1.spiritId)) : null);
					if (_003CspiritToRemove_003E5__3 != null)
					{
						((Collection<SpiritCardViewModel>)(object)_003C_003E4__this._originalSpirits)?.Remove(_003CspiritToRemove_003E5__3);
						((Collection<SpiritCardViewModel>)(object)_003C_003E4__this.AllSpirits).Remove(_003CspiritToRemove_003E5__3);
						_003CspiritToRemove_003E5__3.Dispose();
					}
					_003CallSpiritIds_003E5__2 = null;
					_003CspiritToRemove_003E5__3 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					_003C_003E4__this.ErrorMessage = "Failed to remove spirit from collection: " + _003Cex_003E5__4.Message;
					Debug.WriteLine($"Remove spirit error: {_003Cex_003E5__4}");
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
	private sealed class _003CSavedSquads_003Ed__61 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public CollectionHubViewModel _003C_003E4__this;

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
							_003CSavedSquads_003Ed__61 _003CSavedSquads_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSavedSquads_003Ed__61>(ref awaiter2, ref _003CSavedSquads_003Ed__);
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
					_003CSavedSquads_003Ed__61 _003CSavedSquads_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSavedSquads_003Ed__61>(ref awaiter, ref _003CSavedSquads_003Ed__);
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
	private sealed class _003CShowFilterPopup_003Ed__54 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public View anchorView;

		public CollectionHubViewModel _003C_003E4__this;

		private _003C_003Ec__DisplayClass54_0 _003C_003E8__1;

		private _003C_003Ec__DisplayClass54_1 _003C_003E8__2;

		private object _003C_003Es__3;

		private int _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter<object?> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num > 1u)
				{
					_003C_003E8__1 = new _003C_003Ec__DisplayClass54_0();
					_003C_003E8__1.anchorView = anchorView;
					_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
					_003C_003E8__2 = new _003C_003Ec__DisplayClass54_1();
					_003C_003E8__2.CS_0024_003C_003E8__locals1 = _003C_003E8__1;
					_003C_003E8__2.filterVm = null;
				}
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
							goto IL_01bb;
						}
						_003C_003Es__4 = 0;
					}
					try
					{
						TaskAwaiter<object> awaiter2;
						if (num != 0)
						{
							awaiter2 = _003C_003E4__this._popupService.ShowPopupAsync<FilterCollectionPopupViewModel>((Action<FilterCollectionPopupViewModel>)delegate(FilterCollectionPopupViewModel vm)
							{
								_003C_003E8__2.filterVm = vm;
								vm.Anchor = _003C_003E8__2.CS_0024_003C_003E8__locals1.anchorView;
								vm.FilterCriteria = _003C_003E8__2.CS_0024_003C_003E8__locals1._003C_003E4__this.CurrentFilterCriteria;
								vm.UpdateFilters();
								vm.FilterUpdated += _003C_003E8__2.CS_0024_003C_003E8__locals1._003C_003E4__this.OnFilterUpdated;
							}, default(CancellationToken)).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003CShowFilterPopup_003Ed__54 _003CShowFilterPopup_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<object>, _003CShowFilterPopup_003Ed__54>(ref awaiter2, ref _003CShowFilterPopup_003Ed__);
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
						_003C_003Es__3 = ex;
						_003C_003Es__4 = 1;
					}
					int num2 = _003C_003Es__4;
					if (num2 != 1)
					{
						goto IL_01cd;
					}
					_003Cex_003E5__5 = (global::System.Exception)_003C_003Es__3;
					awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cex_003E5__5.Message).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter;
						_003CShowFilterPopup_003Ed__54 _003CShowFilterPopup_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CShowFilterPopup_003Ed__54>(ref awaiter, ref _003CShowFilterPopup_003Ed__);
						return;
					}
					goto IL_01bb;
					IL_01bb:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003Cex_003E5__5 = null;
					goto IL_01cd;
					IL_01cd:
					_003C_003Es__3 = null;
				}
				finally
				{
					if (num < 0 && _003C_003E8__2.filterVm != null)
					{
						_003C_003E8__2.filterVm.FilterUpdated -= _003C_003E4__this.OnFilterUpdated;
					}
				}
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

	private readonly INavigationService _navigationService;

	private readonly IPlayerStateService _stateService;

	private readonly PlayerInfoModel _playerInfoModel;

	private readonly SpiritCardModelFactory _modelFactory;

	private readonly IPopupService _popupService;

	private readonly IServiceProvider _serviceProvider;

	private readonly ISpiritActionService _spiritActionService;

	private readonly IChatUnreadService _chatUnreadService;

	private readonly IBottomSheetService _bottomSheetService;

	private ObservableCollection<SpiritCardViewModel>? _originalSpirits;

	private List<string> _acquiredSpiritIds = new List<string>();

	private bool _disposed;

	private bool _isCached;

	[ObservableProperty]
	private bool _isUp = true;

	[ObservableProperty]
	[NotifyPropertyChangedFor("IsOrderByRecentActive")]
	[NotifyPropertyChangedFor("IsOrderByLevelActive")]
	[NotifyPropertyChangedFor("IsOrderByTypeActive")]
	[NotifyPropertyChangedFor("IsOrderByIndexActive")]
	[NotifyPropertyChangedFor("IsOrderByNameActive")]
	private OrderBy _orderBy = OrderBy.Level;

	[ObservableProperty]
	private List<SpiritCardViewModel> _filteredSpirits = new List<SpiritCardViewModel>();

	[ObservableProperty]
	private FilterCriteria _currentFilterCriteria = new FilterCriteria((global::System.Collections.Generic.IEnumerable<string>)new List<string>(), (global::System.Collections.Generic.IEnumerable<string>)new List<string>(), Favorites: false);

	[ObservableProperty]
	private string _searchText = string.Empty;

	[ObservableProperty]
	private bool _isOrderBySearch = false;

	[ObservableProperty]
	private SpiritSquadViewModel? _activeSquad;

	[ObservableProperty]
	private ObservableCollection<SpiritCardViewModel?> _allSpirits = new ObservableCollection<SpiritCardViewModel>();

	[ObservableProperty]
	private bool _isLoading;

	[ObservableProperty]
	private string _errorMessage = string.Empty;

	[ObservableProperty]
	private bool _hasUnreadMessages;

	[ObservableProperty]
	private int _unreadMessageCount;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<object?>? loadDataCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goToIndexViewCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? refreshCollectionCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<string>? changeSortTypeCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? toggleOrderSearchCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<View>? showFilterPopupCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? clearSearchCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goToPortalCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goBackCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? navigateToChatCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? navigateToSpiritDetailsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? savedSquadsCommand;

	public bool IsOrderByRecentActive => OrderBy == OrderBy.Recent;

	public bool IsOrderByLevelActive => OrderBy == OrderBy.Level;

	public bool IsOrderByTypeActive => OrderBy == OrderBy.Type;

	public bool IsOrderByIndexActive => OrderBy == OrderBy.Index;

	public bool IsOrderByNameActive => OrderBy == OrderBy.Name;

	public string? PartnerSpiritImage => _stateService.GetSpiritTemplate(_stateService.GetPartnerSpirit().BaseSpiritID)?.Image;

	public string? PartnerSpiritNickname => _stateService.GetPartnerSpirit()?.Nickname ?? "";

	public PlayerInfoModel PlayerInfoModel => _playerInfoModel;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsUp
	{
		get
		{
			return _isUp;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isUp, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsUp);
				_isUp = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsUp);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public OrderBy OrderBy
	{
		get
		{
			return _orderBy;
		}
		set
		{
			if (!EqualityComparer<OrderBy>.Default.Equals(_orderBy, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.OrderBy);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsOrderByRecentActive);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsOrderByLevelActive);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsOrderByTypeActive);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsOrderByIndexActive);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsOrderByNameActive);
				_orderBy = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.OrderBy);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsOrderByRecentActive);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsOrderByLevelActive);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsOrderByTypeActive);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsOrderByIndexActive);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsOrderByNameActive);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public List<SpiritCardViewModel> FilteredSpirits
	{
		get
		{
			return _filteredSpirits;
		}
		[MemberNotNull("_filteredSpirits")]
		set
		{
			if (!EqualityComparer<List<SpiritCardViewModel>>.Default.Equals(_filteredSpirits, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.FilteredSpirits);
				_filteredSpirits = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.FilteredSpirits);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public FilterCriteria CurrentFilterCriteria
	{
		get
		{
			return _currentFilterCriteria;
		}
		[MemberNotNull("_currentFilterCriteria")]
		set
		{
			if (!EqualityComparer<FilterCriteria>.Default.Equals(_currentFilterCriteria, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentFilterCriteria);
				_currentFilterCriteria = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentFilterCriteria);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string SearchText
	{
		get
		{
			return _searchText;
		}
		[MemberNotNull("_searchText")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_searchText, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SearchText);
				_searchText = value;
				OnSearchTextChanged(value);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SearchText);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsOrderBySearch
	{
		get
		{
			return _isOrderBySearch;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isOrderBySearch, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsOrderBySearch);
				_isOrderBySearch = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsOrderBySearch);
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
	public ObservableCollection<SpiritCardViewModel?> AllSpirits
	{
		get
		{
			return _allSpirits;
		}
		[MemberNotNull("_allSpirits")]
		set
		{
			if (!EqualityComparer<ObservableCollection<SpiritCardViewModel>>.Default.Equals(_allSpirits, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.AllSpirits);
				_allSpirits = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.AllSpirits);
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
	public IAsyncRelayCommand GoToIndexViewCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = goToIndexViewCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)GoToIndexView);
				AsyncRelayCommand val2 = val;
				goToIndexViewCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand RefreshCollectionCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = refreshCollectionCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)RefreshCollection);
				AsyncRelayCommand val2 = val;
				refreshCollectionCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<string> ChangeSortTypeCommand => (IAsyncRelayCommand<string>)(object)(changeSortTypeCommand ?? (changeSortTypeCommand = new AsyncRelayCommand<string>((Func<string, global::System.Threading.Tasks.Task>)ChangeSortType)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ToggleOrderSearchCommand
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			RelayCommand obj = toggleOrderSearchCommand;
			if (obj == null)
			{
				RelayCommand val = new RelayCommand(new Action(ToggleOrderSearch));
				RelayCommand val2 = val;
				toggleOrderSearchCommand = val;
				obj = val2;
			}
			return (IRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<View> ShowFilterPopupCommand => (IAsyncRelayCommand<View>)(object)(showFilterPopupCommand ?? (showFilterPopupCommand = new AsyncRelayCommand<View>((Func<View, global::System.Threading.Tasks.Task>)ShowFilterPopup)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ClearSearchCommand
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			RelayCommand obj = clearSearchCommand;
			if (obj == null)
			{
				RelayCommand val = new RelayCommand(new Action(ClearSearch));
				RelayCommand val2 = val;
				clearSearchCommand = val;
				obj = val2;
			}
			return (IRelayCommand)(object)obj;
		}
	}

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
	public IAsyncRelayCommand NavigateToSpiritDetailsCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = navigateToSpiritDetailsCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)NavigateToSpiritDetails);
				AsyncRelayCommand val2 = val;
				navigateToSpiritDetailsCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

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

	public CollectionHubViewModel(INavigationService navigationService, IPlayerStateService stateService, PlayerInfoModel playerInfoModel, SpiritCardModelFactory modelFactory, IPopupService popupService, IServiceProvider serviceProvider, ISpiritActionService spiritActionService, IChatUnreadService chatUnreadService, IBottomSheetService bottomSheetService)
	{
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		_navigationService = navigationService;
		_stateService = stateService ?? throw new ArgumentNullException("stateService");
		_playerInfoModel = playerInfoModel;
		_modelFactory = modelFactory;
		_serviceProvider = serviceProvider;
		_popupService = popupService;
		_spiritActionService = spiritActionService;
		_chatUnreadService = chatUnreadService;
		_bottomSheetService = bottomSheetService;
		_stateService.StateChanged += OnStateChanged;
		_chatUnreadService.UnreadCountChanged += new EventHandler(OnUnreadCountChanged);
	}

	private void OnStateChanged(object? sender, StateChangedEventArgs e)
	{
		switch (e.Scope)
		{
		case StateChangeScope.Player:
			if (e.ChangeType == "Partner")
			{
				((ObservableObject)this).OnPropertyChanged("PartnerSpiritImage");
			}
			((ObservableObject)this).OnPropertyChanged("PartnerSpiritNickname");
			break;
		case StateChangeScope.Spirit:
		{
			string entityId = e.EntityId;
			if (e.ChangeType == "Sold")
			{
				RemoveFromCollection(entityId);
			}
			if (e.ChangeType == "Add")
			{
				LoadCollection();
			}
			break;
		}
		}
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__43))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? param = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__43 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__43();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.param = param;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__43>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadCollection_003Ed__44))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadCollection()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadCollection_003Ed__44 _003CLoadCollection_003Ed__ = new _003CLoadCollection_003Ed__44();
		_003CLoadCollection_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadCollection_003Ed__._003C_003E4__this = this;
		_003CLoadCollection_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadCollection_003Ed__._003C_003Et__builder)).Start<_003CLoadCollection_003Ed__44>(ref _003CLoadCollection_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadCollection_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRemoveFromCollection_003Ed__45))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task RemoveFromCollection(string spiritId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRemoveFromCollection_003Ed__45 _003CRemoveFromCollection_003Ed__ = new _003CRemoveFromCollection_003Ed__45();
		_003CRemoveFromCollection_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRemoveFromCollection_003Ed__._003C_003E4__this = this;
		_003CRemoveFromCollection_003Ed__.spiritId = spiritId;
		_003CRemoveFromCollection_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRemoveFromCollection_003Ed__._003C_003Et__builder)).Start<_003CRemoveFromCollection_003Ed__45>(ref _003CRemoveFromCollection_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRemoveFromCollection_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CLoadSquadData_003Ed__46))]
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
			ErrorMessage = "Failed to load squad: " + ex.Message;
			await _navigationService.ShowAlertAsync("Error", ErrorMessage);
			Console.WriteLine(ex.StackTrace);
			return false;
		}
	}

	[AsyncStateMachine(typeof(_003CGoToIndexView_003Ed__47))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoToIndexView()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoToIndexView_003Ed__47 _003CGoToIndexView_003Ed__ = new _003CGoToIndexView_003Ed__47();
		_003CGoToIndexView_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoToIndexView_003Ed__._003C_003E4__this = this;
		_003CGoToIndexView_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoToIndexView_003Ed__._003C_003Et__builder)).Start<_003CGoToIndexView_003Ed__47>(ref _003CGoToIndexView_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoToIndexView_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRefreshCollection_003Ed__48))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task RefreshCollection()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRefreshCollection_003Ed__48 _003CRefreshCollection_003Ed__ = new _003CRefreshCollection_003Ed__48();
		_003CRefreshCollection_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRefreshCollection_003Ed__._003C_003E4__this = this;
		_003CRefreshCollection_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRefreshCollection_003Ed__._003C_003Et__builder)).Start<_003CRefreshCollection_003Ed__48>(ref _003CRefreshCollection_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRefreshCollection_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CChangeSortType_003Ed__49))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task ChangeSortType(string sortType)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CChangeSortType_003Ed__49 _003CChangeSortType_003Ed__ = new _003CChangeSortType_003Ed__49();
		_003CChangeSortType_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CChangeSortType_003Ed__._003C_003E4__this = this;
		_003CChangeSortType_003Ed__.sortType = sortType;
		_003CChangeSortType_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CChangeSortType_003Ed__._003C_003Et__builder)).Start<_003CChangeSortType_003Ed__49>(ref _003CChangeSortType_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CChangeSortType_003Ed__._003C_003Et__builder)).Task;
	}

	private void OnFilterUpdated(FilterCriteria criteria)
	{
		ApplyFilters(criteria);
	}

	[AsyncStateMachine(typeof(_003CApplyFiltersAndSearch_003Ed__51))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task ApplyFiltersAndSearch()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CApplyFiltersAndSearch_003Ed__51 _003CApplyFiltersAndSearch_003Ed__ = new _003CApplyFiltersAndSearch_003Ed__51();
		_003CApplyFiltersAndSearch_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CApplyFiltersAndSearch_003Ed__._003C_003E4__this = this;
		_003CApplyFiltersAndSearch_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CApplyFiltersAndSearch_003Ed__._003C_003Et__builder)).Start<_003CApplyFiltersAndSearch_003Ed__51>(ref _003CApplyFiltersAndSearch_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CApplyFiltersAndSearch_003Ed__._003C_003Et__builder)).Task;
	}

	public void ApplyFilters(FilterCriteria criteria)
	{
		CurrentFilterCriteria = criteria;
		ApplyFiltersAndSearch();
	}

	[RelayCommand]
	private void ToggleOrderSearch()
	{
		if (IsOrderBySearch)
		{
			AllSpirits = new ObservableCollection<SpiritCardViewModel>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)Enumerable.OrderByDescending<SpiritCardViewModel, int>((global::System.Collections.Generic.IEnumerable<SpiritCardViewModel>)_originalSpirits, (Func<SpiritCardViewModel, int>)((SpiritCardViewModel s) => s.Model?.Level ?? 0)));
			OrderBy = OrderBy.Level;
		}
		IsOrderBySearch = !IsOrderBySearch;
	}

	[AsyncStateMachine(typeof(_003CShowFilterPopup_003Ed__54))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task ShowFilterPopup(View anchorView)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CShowFilterPopup_003Ed__54 _003CShowFilterPopup_003Ed__ = new _003CShowFilterPopup_003Ed__54();
		_003CShowFilterPopup_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CShowFilterPopup_003Ed__._003C_003E4__this = this;
		_003CShowFilterPopup_003Ed__.anchorView = anchorView;
		_003CShowFilterPopup_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CShowFilterPopup_003Ed__._003C_003Et__builder)).Start<_003CShowFilterPopup_003Ed__54>(ref _003CShowFilterPopup_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CShowFilterPopup_003Ed__._003C_003Et__builder)).Task;
	}

	[RelayCommand]
	public void ClearSearch()
	{
		SearchText = string.Empty;
	}

	[AsyncStateMachine(typeof(_003CGoToPortal_003Ed__56))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoToPortal()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoToPortal_003Ed__56 _003CGoToPortal_003Ed__ = new _003CGoToPortal_003Ed__56();
		_003CGoToPortal_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoToPortal_003Ed__._003C_003E4__this = this;
		_003CGoToPortal_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoToPortal_003Ed__._003C_003Et__builder)).Start<_003CGoToPortal_003Ed__56>(ref _003CGoToPortal_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoToPortal_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGoBack_003Ed__57))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoBack()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoBack_003Ed__57 _003CGoBack_003Ed__ = new _003CGoBack_003Ed__57();
		_003CGoBack_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoBack_003Ed__._003C_003E4__this = this;
		_003CGoBack_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Start<_003CGoBack_003Ed__57>(ref _003CGoBack_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CNavigateToChat_003Ed__58))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task NavigateToChat()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CNavigateToChat_003Ed__58 _003CNavigateToChat_003Ed__ = new _003CNavigateToChat_003Ed__58();
		_003CNavigateToChat_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CNavigateToChat_003Ed__._003C_003E4__this = this;
		_003CNavigateToChat_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CNavigateToChat_003Ed__._003C_003Et__builder)).Start<_003CNavigateToChat_003Ed__58>(ref _003CNavigateToChat_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CNavigateToChat_003Ed__._003C_003Et__builder)).Task;
	}

	private void OnUnreadCountChanged(object? sender, EventArgs e)
	{
		HasUnreadMessages = _chatUnreadService.HasUnread;
		UnreadMessageCount = _chatUnreadService.TotalUnreadCount;
	}

	[AsyncStateMachine(typeof(_003CNavigateToSpiritDetails_003Ed__60))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task NavigateToSpiritDetails()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CNavigateToSpiritDetails_003Ed__60 _003CNavigateToSpiritDetails_003Ed__ = new _003CNavigateToSpiritDetails_003Ed__60();
		_003CNavigateToSpiritDetails_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CNavigateToSpiritDetails_003Ed__._003C_003E4__this = this;
		_003CNavigateToSpiritDetails_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CNavigateToSpiritDetails_003Ed__._003C_003Et__builder)).Start<_003CNavigateToSpiritDetails_003Ed__60>(ref _003CNavigateToSpiritDetails_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CNavigateToSpiritDetails_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSavedSquads_003Ed__61))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task SavedSquads()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSavedSquads_003Ed__61 _003CSavedSquads_003Ed__ = new _003CSavedSquads_003Ed__61();
		_003CSavedSquads_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSavedSquads_003Ed__._003C_003E4__this = this;
		_003CSavedSquads_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSavedSquads_003Ed__._003C_003Et__builder)).Start<_003CSavedSquads_003Ed__61>(ref _003CSavedSquads_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSavedSquads_003Ed__._003C_003Et__builder)).Task;
	}

	public void DisposeMessages()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		_chatUnreadService.UnreadCountChanged -= new EventHandler(OnUnreadCountChanged);
	}

	public void Dispose()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		if (_disposed)
		{
			return;
		}
		_stateService.StateChanged -= OnStateChanged;
		_chatUnreadService.UnreadCountChanged -= new EventHandler(OnUnreadCountChanged);
		if (_originalSpirits != null)
		{
			global::System.Collections.Generic.IEnumerator<SpiritCardViewModel> enumerator = ((Collection<SpiritCardViewModel>)(object)_originalSpirits).GetEnumerator();
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
		}
		SpiritCardViewModelHelper.ReleaseAll(_modelFactory, (global::System.Collections.Generic.IEnumerable<string>?)_acquiredSpiritIds);
		_acquiredSpiritIds.Clear();
		((Collection<SpiritCardViewModel>)(object)AllSpirits).Clear();
		((Collection<SpiritCardViewModel>)(object)_originalSpirits)?.Clear();
		ActiveSquad?.Dispose();
		_disposed = true;
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSearchTextChanged(string value)
	{
		ApplyFiltersAndSearch();
	}
}
