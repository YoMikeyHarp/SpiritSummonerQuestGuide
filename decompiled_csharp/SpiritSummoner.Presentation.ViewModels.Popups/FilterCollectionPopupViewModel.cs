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
using Microsoft.Maui.Controls;
using SpiritSummoner.Presentation.Navigation;

namespace SpiritSummoner.Presentation.ViewModels.Popups;

public class FilterCollectionPopupViewModel : ObservableObject
{
	[CompilerGenerated]
	private sealed class _003CApplyFilters_003Ed__19 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public FilterCollectionPopupViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private List<string> _003CselectedTypes_003E5__3;

		private List<string> _003CselectedCategories_003E5__4;

		private bool _003Cfavorites_003E5__5;

		private FilterCriteria _003Ccriteria_003E5__6;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0222: Unknown result type (might be due to invalid IL or missing references)
			//IL_0227: Unknown result type (might be due to invalid IL or missing references)
			//IL_023c: Unknown result type (might be due to invalid IL or missing references)
			//IL_023e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0258: Unknown result type (might be due to invalid IL or missing references)
			//IL_025d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0265: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_0274;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						_003CselectedTypes_003E5__3 = Enumerable.ToList<string>(Enumerable.Select<FilterRecord, string>(Enumerable.Where<FilterRecord>((global::System.Collections.Generic.IEnumerable<FilterRecord>)_003C_003E4__this.TypeFilters, (Func<FilterRecord, bool>)((FilterRecord f) => f.IsChecked)), (Func<FilterRecord, string>)((FilterRecord f) => f.Name)));
						_003CselectedCategories_003E5__4 = Enumerable.ToList<string>(Enumerable.Select<FilterRecord, string>(Enumerable.Where<FilterRecord>((global::System.Collections.Generic.IEnumerable<FilterRecord>)_003C_003E4__this.CategoryFilters, (Func<FilterRecord, bool>)((FilterRecord f) => f.IsChecked)), (Func<FilterRecord, string>)((FilterRecord f) => f.Name)));
						_003Cfavorites_003E5__5 = Enumerable.FirstOrDefault<FilterRecord>((global::System.Collections.Generic.IEnumerable<FilterRecord>)_003C_003E4__this.Filters, (Func<FilterRecord, bool>)((FilterRecord f) => f.Name == "Favorites"))?.IsChecked ?? false;
						_003Ccriteria_003E5__6 = new FilterCriteria((global::System.Collections.Generic.IEnumerable<string>)_003CselectedTypes_003E5__3, (global::System.Collections.Generic.IEnumerable<string>)_003CselectedCategories_003E5__4, _003Cfavorites_003E5__5);
						_003C_003E4__this.FilterUpdated?.Invoke(_003Ccriteria_003E5__6);
						awaiter2 = _003C_003E4__this._popupService.ClosePopupAsync((object)null).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CApplyFilters_003Ed__19 _003CApplyFilters_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CApplyFilters_003Ed__19>(ref awaiter2, ref _003CApplyFilters_003Ed__);
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
					_003CselectedTypes_003E5__3 = null;
					_003CselectedCategories_003E5__4 = null;
					_003Ccriteria_003E5__6 = null;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_027f;
				}
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to apply filters.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CApplyFilters_003Ed__19 _003CApplyFilters_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CApplyFilters_003Ed__19>(ref awaiter, ref _003CApplyFilters_003Ed__);
					return;
				}
				goto IL_0274;
				IL_0274:
				((TaskAwaiter)(ref awaiter)).GetResult();
				goto IL_027f;
				IL_027f:
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
	private sealed class _003CApplyFiltersAndClose_003Ed__16 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public FilterCollectionPopupViewModel _003C_003E4__this;

		private List<string> _003CselectedTypes_003E5__1;

		private List<string> _003CselectedCategories_003E5__2;

		private bool _003Cfavorites_003E5__3;

		private FilterCriteria _003Ccriteria_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_0209: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_0218;
					}
					_003CselectedTypes_003E5__1 = Enumerable.ToList<string>(Enumerable.Select<FilterRecord, string>(Enumerable.Where<FilterRecord>((global::System.Collections.Generic.IEnumerable<FilterRecord>)_003C_003E4__this.TypeFilters, (Func<FilterRecord, bool>)((FilterRecord f) => f.IsChecked)), (Func<FilterRecord, string>)((FilterRecord f) => f.Name)));
					_003CselectedCategories_003E5__2 = Enumerable.ToList<string>(Enumerable.Select<FilterRecord, string>(Enumerable.Where<FilterRecord>((global::System.Collections.Generic.IEnumerable<FilterRecord>)_003C_003E4__this.CategoryFilters, (Func<FilterRecord, bool>)((FilterRecord f) => f.IsChecked)), (Func<FilterRecord, string>)((FilterRecord f) => f.Name)));
					_003Cfavorites_003E5__3 = Enumerable.FirstOrDefault<FilterRecord>((global::System.Collections.Generic.IEnumerable<FilterRecord>)_003C_003E4__this.Filters, (Func<FilterRecord, bool>)((FilterRecord f) => f.Name == "Favorites"))?.IsChecked ?? false;
					_003Ccriteria_003E5__4 = new FilterCriteria((global::System.Collections.Generic.IEnumerable<string>)_003CselectedTypes_003E5__1, (global::System.Collections.Generic.IEnumerable<string>)_003CselectedCategories_003E5__2, _003Cfavorites_003E5__3);
					_003C_003E4__this.FilterUpdated?.Invoke(_003Ccriteria_003E5__4);
					awaiter2 = global::System.Threading.Tasks.Task.Delay(150).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003CApplyFiltersAndClose_003Ed__16 _003CApplyFiltersAndClose_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CApplyFiltersAndClose_003Ed__16>(ref awaiter2, ref _003CApplyFiltersAndClose_003Ed__);
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
				awaiter = _003C_003E4__this._popupService.ClosePopupAsync((object)null).GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CApplyFiltersAndClose_003Ed__16 _003CApplyFiltersAndClose_003Ed__ = this;
					((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CApplyFiltersAndClose_003Ed__16>(ref awaiter, ref _003CApplyFiltersAndClose_003Ed__);
					return;
				}
				goto IL_0218;
				IL_0218:
				((TaskAwaiter)(ref awaiter)).GetResult();
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CselectedTypes_003E5__1 = null;
				_003CselectedCategories_003E5__2 = null;
				_003Ccriteria_003E5__4 = null;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CselectedTypes_003E5__1 = null;
			_003CselectedCategories_003E5__2 = null;
			_003Ccriteria_003E5__4 = null;
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CClearFilters_003Ed__17 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public FilterCollectionPopupViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private FilterCriteria _003CemptyFilter_003E5__3;

		private global::System.Collections.Generic.IEnumerator<FilterRecord> _003C_003Es__4;

		private FilterRecord _003Cfilter_003E5__5;

		private global::System.Collections.Generic.IEnumerator<FilterRecord> _003C_003Es__6;

		private FilterRecord _003Cfilter_003E5__7;

		private global::System.Collections.Generic.IEnumerator<FilterRecord> _003C_003Es__8;

		private FilterRecord _003Cfilter_003E5__9;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_027b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0280: Unknown result type (might be due to invalid IL or missing references)
			//IL_0295: Unknown result type (might be due to invalid IL or missing references)
			//IL_0297: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02be: Unknown result type (might be due to invalid IL or missing references)
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_0218: Unknown result type (might be due to invalid IL or missing references)
			//IL_021f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_02cd;
					}
					_003C_003Es__2 = 0;
				}
				try
				{
					TaskAwaiter awaiter2;
					if (num != 0)
					{
						_003C_003Es__4 = ((Collection<FilterRecord>)(object)_003C_003E4__this.Filters).GetEnumerator();
						try
						{
							while (((global::System.Collections.IEnumerator)_003C_003Es__4).MoveNext())
							{
								_003Cfilter_003E5__5 = _003C_003Es__4.Current;
								_003Cfilter_003E5__5.IsChecked = false;
								_003Cfilter_003E5__5 = null;
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
						_003C_003Es__6 = ((Collection<FilterRecord>)(object)_003C_003E4__this.TypeFilters).GetEnumerator();
						try
						{
							while (((global::System.Collections.IEnumerator)_003C_003Es__6).MoveNext())
							{
								_003Cfilter_003E5__7 = _003C_003Es__6.Current;
								_003Cfilter_003E5__7.IsChecked = false;
								_003Cfilter_003E5__7 = null;
							}
						}
						finally
						{
							if (num < 0 && _003C_003Es__6 != null)
							{
								((global::System.IDisposable)_003C_003Es__6).Dispose();
							}
						}
						_003C_003Es__6 = null;
						_003C_003Es__8 = ((Collection<FilterRecord>)(object)_003C_003E4__this.CategoryFilters).GetEnumerator();
						try
						{
							while (((global::System.Collections.IEnumerator)_003C_003Es__8).MoveNext())
							{
								_003Cfilter_003E5__9 = _003C_003Es__8.Current;
								_003Cfilter_003E5__9.IsChecked = false;
								_003Cfilter_003E5__9 = null;
							}
						}
						finally
						{
							if (num < 0 && _003C_003Es__8 != null)
							{
								((global::System.IDisposable)_003C_003Es__8).Dispose();
							}
						}
						_003C_003Es__8 = null;
						_003C_003E4__this.CurrentFilters = _003C_003E4__this.Filters;
						_003C_003E4__this.IsBaseFilters = true;
						_003CemptyFilter_003E5__3 = new FilterCriteria((global::System.Collections.Generic.IEnumerable<string>)new List<string>(), (global::System.Collections.Generic.IEnumerable<string>)new List<string>(), Favorites: false);
						_003C_003E4__this.FilterUpdated?.Invoke(_003CemptyFilter_003E5__3);
						awaiter2 = _003C_003E4__this._popupService.ClosePopupAsync((object)null).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CClearFilters_003Ed__17 _003CClearFilters_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CClearFilters_003Ed__17>(ref awaiter2, ref _003CClearFilters_003Ed__);
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
					_003CemptyFilter_003E5__3 = null;
				}
				catch (global::System.Exception ex)
				{
					_003C_003Es__1 = ex;
					_003C_003Es__2 = 1;
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					goto IL_02d8;
				}
				awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to clear filters.").GetAwaiter();
				if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__1 = awaiter;
					_003CClearFilters_003Ed__17 _003CClearFilters_003Ed__ = this;
					((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CClearFilters_003Ed__17>(ref awaiter, ref _003CClearFilters_003Ed__);
					return;
				}
				goto IL_02cd;
				IL_02cd:
				((TaskAwaiter)(ref awaiter)).GetResult();
				goto IL_02d8;
				IL_02d8:
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
	private sealed class _003CClosePopup_003Ed__20 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public FilterCollectionPopupViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._popupService.ClosePopupAsync((object)null).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CClosePopup_003Ed__20 _003CClosePopup_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CClosePopup_003Ed__20>(ref awaiter, ref _003CClosePopup_003Ed__);
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

	private readonly IPopupService _popupService;

	private readonly INavigationService _navigationService;

	[ObservableProperty]
	private ObservableCollection<FilterRecord> _filters;

	[ObservableProperty]
	private ObservableCollection<FilterRecord> _typeFilters;

	[ObservableProperty]
	private ObservableCollection<FilterRecord> _categoryFilters;

	[ObservableProperty]
	private ObservableCollection<FilterRecord> _currentFilters;

	[ObservableProperty]
	private View? _anchor;

	[ObservableProperty]
	private bool _isBaseFilters = true;

	[ObservableProperty]
	private FilterCriteria _filterCriteria = new FilterCriteria((global::System.Collections.Generic.IEnumerable<string>)new List<string>(), (global::System.Collections.Generic.IEnumerable<string>)new List<string>(), Favorites: false);

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private Action<FilterCriteria>? m_FilterUpdated;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<FilterRecord>? toggleFilterCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? clearFiltersCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? toBaseFilterCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? applyFiltersCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? closePopupCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<FilterRecord> Filters
	{
		get
		{
			return _filters;
		}
		[MemberNotNull("_filters")]
		set
		{
			if (!EqualityComparer<ObservableCollection<FilterRecord>>.Default.Equals(_filters, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Filters);
				_filters = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Filters);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<FilterRecord> TypeFilters
	{
		get
		{
			return _typeFilters;
		}
		[MemberNotNull("_typeFilters")]
		set
		{
			if (!EqualityComparer<ObservableCollection<FilterRecord>>.Default.Equals(_typeFilters, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TypeFilters);
				_typeFilters = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TypeFilters);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<FilterRecord> CategoryFilters
	{
		get
		{
			return _categoryFilters;
		}
		[MemberNotNull("_categoryFilters")]
		set
		{
			if (!EqualityComparer<ObservableCollection<FilterRecord>>.Default.Equals(_categoryFilters, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CategoryFilters);
				_categoryFilters = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CategoryFilters);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<FilterRecord> CurrentFilters
	{
		get
		{
			return _currentFilters;
		}
		[MemberNotNull("_currentFilters")]
		set
		{
			if (!EqualityComparer<ObservableCollection<FilterRecord>>.Default.Equals(_currentFilters, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentFilters);
				_currentFilters = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentFilters);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public View? Anchor
	{
		get
		{
			return _anchor;
		}
		set
		{
			if (!EqualityComparer<View>.Default.Equals(_anchor, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Anchor);
				_anchor = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Anchor);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsBaseFilters
	{
		get
		{
			return _isBaseFilters;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isBaseFilters, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsBaseFilters);
				_isBaseFilters = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsBaseFilters);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public FilterCriteria FilterCriteria
	{
		get
		{
			return _filterCriteria;
		}
		[MemberNotNull("_filterCriteria")]
		set
		{
			if (!EqualityComparer<SpiritSummoner.Presentation.ViewModels.Popups.FilterCriteria>.Default.Equals(_filterCriteria, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.FilterCriteria);
				_filterCriteria = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.FilterCriteria);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<FilterRecord> ToggleFilterCommand => (IRelayCommand<FilterRecord>)(object)(toggleFilterCommand ?? (toggleFilterCommand = new RelayCommand<FilterRecord>((Action<FilterRecord>)ToggleFilter)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ClearFiltersCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = clearFiltersCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)ClearFilters);
				AsyncRelayCommand val2 = val;
				clearFiltersCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ToBaseFilterCommand
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			RelayCommand obj = toBaseFilterCommand;
			if (obj == null)
			{
				RelayCommand val = new RelayCommand(new Action(ToBaseFilter));
				RelayCommand val2 = val;
				toBaseFilterCommand = val;
				obj = val2;
			}
			return (IRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ApplyFiltersCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = applyFiltersCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)ApplyFilters);
				AsyncRelayCommand val2 = val;
				applyFiltersCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ClosePopupCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = closePopupCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)ClosePopup);
				AsyncRelayCommand val2 = val;
				closePopupCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public event Action<FilterCriteria>? FilterUpdated
	{
		[CompilerGenerated]
		add
		{
			Action<FilterCriteria> val = this.m_FilterUpdated;
			Action<FilterCriteria> val2;
			do
			{
				val2 = val;
				Action<FilterCriteria> val3 = (Action<FilterCriteria>)(object)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<Action<FilterCriteria>>(ref this.m_FilterUpdated, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			Action<FilterCriteria> val = this.m_FilterUpdated;
			Action<FilterCriteria> val2;
			do
			{
				val2 = val;
				Action<FilterCriteria> val3 = (Action<FilterCriteria>)(object)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<Action<FilterCriteria>>(ref this.m_FilterUpdated, val3, val2);
			}
			while (val != val2);
		}
	}

	public FilterCollectionPopupViewModel(IPopupService popupService, INavigationService navigationService)
	{
		_popupService = popupService;
		_navigationService = navigationService;
		InitializeDefaultFilters();
	}

	private void InitializeDefaultFilters()
	{
		ObservableCollection<FilterRecord> obj = new ObservableCollection<FilterRecord>();
		((Collection<FilterRecord>)(object)obj).Add(new FilterRecord("Type", isChecked: false));
		((Collection<FilterRecord>)(object)obj).Add(new FilterRecord("Category", isChecked: false));
		((Collection<FilterRecord>)(object)obj).Add(new FilterRecord("Favorites", isChecked: false));
		Filters = obj;
		CurrentFilters = Filters;
		ObservableCollection<FilterRecord> obj2 = new ObservableCollection<FilterRecord>();
		((Collection<FilterRecord>)(object)obj2).Add(new FilterRecord("Fire", isChecked: false));
		((Collection<FilterRecord>)(object)obj2).Add(new FilterRecord("Water", isChecked: false));
		((Collection<FilterRecord>)(object)obj2).Add(new FilterRecord("Ground", isChecked: false));
		((Collection<FilterRecord>)(object)obj2).Add(new FilterRecord("Wind", isChecked: false));
		((Collection<FilterRecord>)(object)obj2).Add(new FilterRecord("Light", isChecked: false));
		((Collection<FilterRecord>)(object)obj2).Add(new FilterRecord("Dark", isChecked: false));
		((Collection<FilterRecord>)(object)obj2).Add(new FilterRecord("Grass", isChecked: false));
		((Collection<FilterRecord>)(object)obj2).Add(new FilterRecord("Electric", isChecked: false));
		((Collection<FilterRecord>)(object)obj2).Add(new FilterRecord("Poison", isChecked: false));
		((Collection<FilterRecord>)(object)obj2).Add(new FilterRecord("Metal", isChecked: false));
		((Collection<FilterRecord>)(object)obj2).Add(new FilterRecord("Neutral", isChecked: false));
		((Collection<FilterRecord>)(object)obj2).Add(new FilterRecord("Melee", isChecked: false));
		TypeFilters = obj2;
		ObservableCollection<FilterRecord> obj3 = new ObservableCollection<FilterRecord>();
		((Collection<FilterRecord>)(object)obj3).Add(new FilterRecord("Animal", isChecked: false));
		((Collection<FilterRecord>)(object)obj3).Add(new FilterRecord("Beast", isChecked: false));
		((Collection<FilterRecord>)(object)obj3).Add(new FilterRecord("Dragon", isChecked: false));
		((Collection<FilterRecord>)(object)obj3).Add(new FilterRecord("Elemental", isChecked: false));
		((Collection<FilterRecord>)(object)obj3).Add(new FilterRecord("Fairy", isChecked: false));
		((Collection<FilterRecord>)(object)obj3).Add(new FilterRecord("Insect", isChecked: false));
		((Collection<FilterRecord>)(object)obj3).Add(new FilterRecord("Shadow", isChecked: false));
		((Collection<FilterRecord>)(object)obj3).Add(new FilterRecord("Unique", isChecked: false));
		((Collection<FilterRecord>)(object)obj3).Add(new FilterRecord("Fish", isChecked: false));
		((Collection<FilterRecord>)(object)obj3).Add(new FilterRecord("Flower", isChecked: false));
		CategoryFilters = obj3;
	}

	public void UpdateFilters()
	{
		ObservableCollection<FilterRecord> obj = new ObservableCollection<FilterRecord>();
		((Collection<FilterRecord>)(object)obj).Add(new FilterRecord("Type", Enumerable.Any<string>(FilterCriteria.SelectedTypes)));
		((Collection<FilterRecord>)(object)obj).Add(new FilterRecord("Category", Enumerable.Any<string>(FilterCriteria.SelectedCategories)));
		((Collection<FilterRecord>)(object)obj).Add(new FilterRecord("Favorites", FilterCriteria.Favorites));
		Filters = obj;
		CurrentFilters = Filters;
		for (int i = 0; i < ((Collection<FilterRecord>)(object)TypeFilters).Count; i++)
		{
			FilterRecord filterRecord = ((Collection<FilterRecord>)(object)TypeFilters)[i];
			((Collection<FilterRecord>)(object)TypeFilters)[i] = new FilterRecord(filterRecord.Name, Enumerable.Contains<string>(FilterCriteria.SelectedTypes, filterRecord.Name));
		}
		for (int j = 0; j < ((Collection<FilterRecord>)(object)CategoryFilters).Count; j++)
		{
			FilterRecord filterRecord2 = ((Collection<FilterRecord>)(object)CategoryFilters)[j];
			((Collection<FilterRecord>)(object)CategoryFilters)[j] = new FilterRecord(filterRecord2.Name, Enumerable.Contains<string>(FilterCriteria.SelectedCategories, filterRecord2.Name));
		}
		((ObservableObject)this).OnPropertyChanged("TypeFilters");
		((ObservableObject)this).OnPropertyChanged("CategoryFilters");
	}

	[RelayCommand]
	private void ToggleFilter(FilterRecord filter)
	{
		FilterRecord filter2 = filter;
		if (filter2 == null)
		{
			return;
		}
		filter2.IsChecked = !filter2.IsChecked;
		string name = filter2.Name;
		string text = name;
		if (!(text == "Type"))
		{
			if (!(text == "Category"))
			{
				if (text == "Favorites")
				{
					FilterRecord filterRecord = Enumerable.FirstOrDefault<FilterRecord>((global::System.Collections.Generic.IEnumerable<FilterRecord>)Filters, (Func<FilterRecord, bool>)((FilterRecord f) => f.Name == "Favorites"));
					if (filterRecord != null)
					{
						filterRecord.IsChecked = filter2.IsChecked;
					}
					ApplyFiltersAndClose();
				}
				else if (Enumerable.Any<FilterRecord>((global::System.Collections.Generic.IEnumerable<FilterRecord>)TypeFilters, (Func<FilterRecord, bool>)((FilterRecord tf) => tf.Name == filter2.Name)))
				{
					FilterRecord filterRecord2 = Enumerable.FirstOrDefault<FilterRecord>((global::System.Collections.Generic.IEnumerable<FilterRecord>)Filters, (Func<FilterRecord, bool>)((FilterRecord f) => f.Name == "Type"));
					if (filterRecord2 != null)
					{
						filterRecord2.IsChecked = Enumerable.Any<FilterRecord>((global::System.Collections.Generic.IEnumerable<FilterRecord>)TypeFilters, (Func<FilterRecord, bool>)((FilterRecord tf) => tf.IsChecked));
					}
					ApplyFiltersAndClose();
				}
				else
				{
					if (!Enumerable.Any<FilterRecord>((global::System.Collections.Generic.IEnumerable<FilterRecord>)CategoryFilters, (Func<FilterRecord, bool>)((FilterRecord cf) => cf.Name == filter2.Name)))
					{
						return;
					}
					FilterRecord filterRecord3 = Enumerable.FirstOrDefault<FilterRecord>((global::System.Collections.Generic.IEnumerable<FilterRecord>)Filters, (Func<FilterRecord, bool>)((FilterRecord f) => f.Name == "Category"));
					if (filterRecord3 != null)
					{
						filterRecord3.IsChecked = Enumerable.Any<FilterRecord>((global::System.Collections.Generic.IEnumerable<FilterRecord>)CategoryFilters, (Func<FilterRecord, bool>)((FilterRecord cf) => cf.IsChecked));
					}
					ApplyFiltersAndClose();
				}
				return;
			}
			if (filter2.IsChecked)
			{
				CurrentFilters = CategoryFilters;
				IsBaseFilters = false;
				return;
			}
			global::System.Collections.Generic.IEnumerator<FilterRecord> enumerator = ((Collection<FilterRecord>)(object)CategoryFilters).GetEnumerator();
			try
			{
				while (((global::System.Collections.IEnumerator)enumerator).MoveNext())
				{
					FilterRecord current = enumerator.Current;
					current.IsChecked = false;
				}
			}
			finally
			{
				((global::System.IDisposable)enumerator)?.Dispose();
			}
			CurrentFilters = Filters;
			IsBaseFilters = true;
			ApplyFiltersAndClose();
			return;
		}
		if (filter2.IsChecked)
		{
			CurrentFilters = TypeFilters;
			IsBaseFilters = false;
			return;
		}
		global::System.Collections.Generic.IEnumerator<FilterRecord> enumerator2 = ((Collection<FilterRecord>)(object)TypeFilters).GetEnumerator();
		try
		{
			while (((global::System.Collections.IEnumerator)enumerator2).MoveNext())
			{
				FilterRecord current2 = enumerator2.Current;
				current2.IsChecked = false;
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator2)?.Dispose();
		}
		CurrentFilters = Filters;
		IsBaseFilters = true;
		ApplyFiltersAndClose();
	}

	[AsyncStateMachine(typeof(_003CApplyFiltersAndClose_003Ed__16))]
	[DebuggerStepThrough]
	private void ApplyFiltersAndClose()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CApplyFiltersAndClose_003Ed__16 _003CApplyFiltersAndClose_003Ed__ = new _003CApplyFiltersAndClose_003Ed__16();
		_003CApplyFiltersAndClose_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CApplyFiltersAndClose_003Ed__._003C_003E4__this = this;
		_003CApplyFiltersAndClose_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CApplyFiltersAndClose_003Ed__._003C_003Et__builder)).Start<_003CApplyFiltersAndClose_003Ed__16>(ref _003CApplyFiltersAndClose_003Ed__);
	}

	[AsyncStateMachine(typeof(_003CClearFilters_003Ed__17))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task ClearFilters()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CClearFilters_003Ed__17 _003CClearFilters_003Ed__ = new _003CClearFilters_003Ed__17();
		_003CClearFilters_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CClearFilters_003Ed__._003C_003E4__this = this;
		_003CClearFilters_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CClearFilters_003Ed__._003C_003Et__builder)).Start<_003CClearFilters_003Ed__17>(ref _003CClearFilters_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CClearFilters_003Ed__._003C_003Et__builder)).Task;
	}

	[RelayCommand]
	private void ToBaseFilter()
	{
		CurrentFilters = Filters;
		IsBaseFilters = true;
	}

	[AsyncStateMachine(typeof(_003CApplyFilters_003Ed__19))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task ApplyFilters()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CApplyFilters_003Ed__19 _003CApplyFilters_003Ed__ = new _003CApplyFilters_003Ed__19();
		_003CApplyFilters_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CApplyFilters_003Ed__._003C_003E4__this = this;
		_003CApplyFilters_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CApplyFilters_003Ed__._003C_003Et__builder)).Start<_003CApplyFilters_003Ed__19>(ref _003CApplyFilters_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CApplyFilters_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CClosePopup_003Ed__20))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task ClosePopup()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CClosePopup_003Ed__20 _003CClosePopup_003Ed__ = new _003CClosePopup_003Ed__20();
		_003CClosePopup_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CClosePopup_003Ed__._003C_003E4__this = this;
		_003CClosePopup_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CClosePopup_003Ed__._003C_003Et__builder)).Start<_003CClosePopup_003Ed__20>(ref _003CClosePopup_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CClosePopup_003Ed__._003C_003Et__builder)).Task;
	}
}
