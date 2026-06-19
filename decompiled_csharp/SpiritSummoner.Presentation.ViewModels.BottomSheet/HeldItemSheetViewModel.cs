using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Items;
using SpiritSummoner.Domain.Enums.Items;
using SpiritSummoner.Presentation.Models;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.Services;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.ViewModels.BottomSheet;

public class HeldItemSheetViewModel : ObservableObject
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass23_0
	{
		private sealed class _003C_003CLoadAvailableItems_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass23_0 _003C_003E4__this;

			private Result<GetEquippableItemsResponse> _003Cresult_003E5__1;

			private Result<GetEquippableItemsResponse> _003C_003Es__2;

			private global::System.Exception _003Cex_003E5__3;

			private TaskAwaiter<Result<GetEquippableItemsResponse>> _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

			private void MoveNext()
			{
				//IL_007b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0080: Unknown result type (might be due to invalid IL or missing references)
				//IL_0087: Unknown result type (might be due to invalid IL or missing references)
				//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
				//IL_0203: Unknown result type (might be due to invalid IL or missing references)
				//IL_020b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0044: Unknown result type (might be due to invalid IL or missing references)
				//IL_0049: Unknown result type (might be due to invalid IL or missing references)
				//IL_005d: Unknown result type (might be due to invalid IL or missing references)
				//IL_005e: Unknown result type (might be due to invalid IL or missing references)
				//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
				//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_01df: Unknown result type (might be due to invalid IL or missing references)
				//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
				int num = _003C_003E1__state;
				try
				{
					if ((uint)num > 1u)
					{
					}
					try
					{
						TaskAwaiter awaiter;
						TaskAwaiter<Result<GetEquippableItemsResponse>> awaiter2;
						if (num != 0)
						{
							if (num == 1)
							{
								awaiter = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_021a;
							}
							awaiter2 = _003C_003E4__this._003C_003E4__this._getEquippableItemsUseCase.ExecuteAsync(_003C_003E4__this.request).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003C_003CLoadAvailableItems_003Eb__0_003Ed _003C_003CLoadAvailableItems_003Eb__0_003Ed = this;
								((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<GetEquippableItemsResponse>>, _003C_003CLoadAvailableItems_003Eb__0_003Ed>(ref awaiter2, ref _003C_003CLoadAvailableItems_003Eb__0_003Ed);
								return;
							}
						}
						else
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<Result<GetEquippableItemsResponse>>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__2 = awaiter2.GetResult();
						_003Cresult_003E5__1 = _003C_003Es__2;
						_003C_003Es__2 = null;
						if (_003Cresult_003E5__1.Success && _003Cresult_003E5__1.Data != null)
						{
							_003C_003E4__this._003C_003E4__this.AvailableItems = new ObservableCollection<ItemModel>(_003Cresult_003E5__1.Data.Items);
							_003C_003E4__this._003C_003E4__this.FilteredItems = new ObservableCollection<ItemModel>((global::System.Collections.Generic.IEnumerable<ItemModel>)Enumerable.OrderBy<ItemModel, string>(Enumerable.Where<ItemModel>((global::System.Collections.Generic.IEnumerable<ItemModel>)_003C_003E4__this._003C_003E4__this.AvailableItems, (Func<ItemModel, bool>)([CompilerGenerated] (ItemModel i) => i.Id != _003C_003E4__this._003C_003E4__this._currentHeldItemId)), (Func<ItemModel, string>)((ItemModel i) => i.Name)));
							_003C_003E4__this._003C_003E4__this.UnlockedItemsCount = ((Collection<ItemModel>)(object)_003C_003E4__this._003C_003E4__this.FilteredItems).Count;
							goto IL_0223;
						}
						awaiter = _003C_003E4__this._003C_003E4__this._navigationService.ShowAlertAsync("Error", _003Cresult_003E5__1.ErrorMessage ?? "Failed to load held items").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003C_003CLoadAvailableItems_003Eb__0_003Ed _003C_003CLoadAvailableItems_003Eb__0_003Ed = this;
							((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003C_003CLoadAvailableItems_003Eb__0_003Ed>(ref awaiter, ref _003C_003CLoadAvailableItems_003Eb__0_003Ed);
							return;
						}
						goto IL_021a;
						IL_0223:
						_003Cresult_003E5__1 = null;
						goto end_IL_0011;
						IL_021a:
						((TaskAwaiter)(ref awaiter)).GetResult();
						goto IL_0223;
						end_IL_0011:;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__3 = ex;
						Console.WriteLine("Error loading available held items: " + _003Cex_003E5__3.Message);
						_003C_003E4__this._003C_003E4__this.UnlockedItemsCount = 0;
					}
					finally
					{
						if (num < 0)
						{
							_003C_003E4__this._003C_003E4__this.IsLoading = false;
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

		public GetEquippableItemsRequest request;

		public HeldItemSheetViewModel _003C_003E4__this;

		[AsyncStateMachine(typeof(_003C_003CLoadAvailableItems_003Eb__0_003Ed))]
		[DebuggerStepThrough]
		internal void _003CLoadAvailableItems_003Eb__0()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_003C_003CLoadAvailableItems_003Eb__0_003Ed _003C_003CLoadAvailableItems_003Eb__0_003Ed = new _003C_003CLoadAvailableItems_003Eb__0_003Ed
			{
				_003C_003Et__builder = AsyncVoidMethodBuilder.Create(),
				_003C_003E4__this = this,
				_003C_003E1__state = -1
			};
			((AsyncVoidMethodBuilder)(ref _003C_003CLoadAvailableItems_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003CLoadAvailableItems_003Eb__0_003Ed>(ref _003C_003CLoadAvailableItems_003Eb__0_003Ed);
		}
	}

	[CompilerGenerated]
	private sealed class _003CCancel_003Ed__25 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public HeldItemSheetViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
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
					_003C_003E4__this._bottomSheetService.SetResult(_003C_003E4__this._sheetId, HeldItemResult.Cancel);
					awaiter = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CCancel_003Ed__25 _003CCancel_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCancel_003Ed__25>(ref awaiter, ref _003CCancel_003Ed__);
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
	private sealed class _003CConfirm_003Ed__26 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public HeldItemSheetViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00ce;
				}
				if (_003C_003E4__this.HasUnsavedChanges)
				{
					_003C_003E4__this._bottomSheetService.SetResult(_003C_003E4__this._sheetId, new HeldItemResult
					{
						Success = true,
						NewItemId = _003C_003E4__this.NewItemId
					});
					awaiter = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CConfirm_003Ed__26 _003CConfirm_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CConfirm_003Ed__26>(ref awaiter, ref _003CConfirm_003Ed__);
						return;
					}
					goto IL_00ce;
				}
				goto end_IL_0007;
				IL_00ce:
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
	private sealed class _003CGoToShop_003Ed__27 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public HeldItemSheetViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
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
					_003C_003E4__this._bottomSheetService.SetResult(_003C_003E4__this._sheetId, HeldItemResult.GoToShop);
					awaiter = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CGoToShop_003Ed__27 _003CGoToShop_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoToShop_003Ed__27>(ref awaiter, ref _003CGoToShop_003Ed__);
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
	private sealed class _003CRemoveItem_003Ed__28 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public HeldItemSheetViewModel _003C_003E4__this;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			try
			{
				_003C_003E4__this.NewItemId = null;
				_003C_003E4__this.SelectedItem = null;
				((ObservableObject)_003C_003E4__this).OnPropertyChanged("HasUnsavedChanges");
				((ObservableObject)_003C_003E4__this).OnPropertyChanged("IsItemSelected");
				((ObservableObject)_003C_003E4__this).OnPropertyChanged("HasItem");
				_003C_003E4__this.FilteredItems = new ObservableCollection<ItemModel>((global::System.Collections.Generic.IEnumerable<ItemModel>)Enumerable.OrderBy<ItemModel, string>(Enumerable.Where<ItemModel>((global::System.Collections.Generic.IEnumerable<ItemModel>)_003C_003E4__this.AvailableItems, (Func<ItemModel, bool>)([CompilerGenerated] (ItemModel i) => i.Id != _003C_003E4__this.SelectedItem?.Id)), (Func<ItemModel, string>)((ItemModel i) => i.Name)));
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

	private readonly IBottomSheetService _bottomSheetService;

	private readonly INavigationService _navigationService;

	private readonly GetEquippableItemsUseCase _getEquippableItemsUseCase;

	private readonly string _sheetId;

	private readonly string? _currentHeldItemId;

	private readonly string? _playerSpiritId;

	private readonly string? _baseSpiritId;

	private BottomSheet? _sheet;

	[ObservableProperty]
	private ObservableCollection<ItemModel> _availableItems = new ObservableCollection<ItemModel>();

	[ObservableProperty]
	private ObservableCollection<ItemModel> _filteredItems = new ObservableCollection<ItemModel>();

	[ObservableProperty]
	private ItemModel? _selectedItem;

	[ObservableProperty]
	[NotifyPropertyChangedFor("HasUnsavedChanges")]
	[NotifyPropertyChangedFor("IsItemSelected")]
	private string? _newItemId;

	[ObservableProperty]
	private int _unlockedItemsCount;

	[ObservableProperty]
	private bool _isLoading;

	[ObservableProperty]
	private ItemModel _currentHeldItem;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<ItemModel>? setItemCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? cancelCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? confirmCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goToShopCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? removeItemCommand;

	public bool HasUnsavedChanges => _newItemId != _currentHeldItemId;

	public bool IsItemSelected => !string.IsNullOrEmpty(_newItemId) && _newItemId != CurrentHeldItem?.Id;

	public bool HasItem => !string.IsNullOrEmpty(_currentHeldItemId);

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<ItemModel> AvailableItems
	{
		get
		{
			return _availableItems;
		}
		[MemberNotNull("_availableItems")]
		set
		{
			if (!EqualityComparer<ObservableCollection<ItemModel>>.Default.Equals(_availableItems, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.AvailableItems);
				_availableItems = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.AvailableItems);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ObservableCollection<ItemModel> FilteredItems
	{
		get
		{
			return _filteredItems;
		}
		[MemberNotNull("_filteredItems")]
		set
		{
			if (!EqualityComparer<ObservableCollection<ItemModel>>.Default.Equals(_filteredItems, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.FilteredItems);
				_filteredItems = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.FilteredItems);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ItemModel? SelectedItem
	{
		get
		{
			return _selectedItem;
		}
		set
		{
			if (!EqualityComparer<ItemModel>.Default.Equals(_selectedItem, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SelectedItem);
				_selectedItem = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SelectedItem);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? NewItemId
	{
		get
		{
			return _newItemId;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_newItemId, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.NewItemId);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasUnsavedChanges);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsItemSelected);
				_newItemId = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.NewItemId);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasUnsavedChanges);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsItemSelected);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int UnlockedItemsCount
	{
		get
		{
			return _unlockedItemsCount;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_unlockedItemsCount, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.UnlockedItemsCount);
				_unlockedItemsCount = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.UnlockedItemsCount);
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
	public ItemModel CurrentHeldItem
	{
		get
		{
			return _currentHeldItem;
		}
		[MemberNotNull("_currentHeldItem")]
		set
		{
			if (!EqualityComparer<ItemModel>.Default.Equals(_currentHeldItem, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentHeldItem);
				_currentHeldItem = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentHeldItem);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<ItemModel> SetItemCommand => (IRelayCommand<ItemModel>)(object)(setItemCommand ?? (setItemCommand = new RelayCommand<ItemModel>((Action<ItemModel>)SetItem)));

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
	public IAsyncRelayCommand GoToShopCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = goToShopCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)GoToShop);
				AsyncRelayCommand val2 = val;
				goToShopCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand RemoveItemCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = removeItemCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)RemoveItem);
				AsyncRelayCommand val2 = val;
				removeItemCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public BottomSheet? SetSheet(BottomSheet sheet)
	{
		return _sheet = sheet;
	}

	public HeldItemSheetViewModel(SpiritCardModel playerSpirit, string sheetId, IBottomSheetService bottomSheetService, INavigationService navigationService, GetEquippableItemsUseCase getEquippableItemsUseCase, ItemModel itemModel)
	{
		_bottomSheetService = bottomSheetService;
		_getEquippableItemsUseCase = getEquippableItemsUseCase;
		_navigationService = navigationService;
		_sheetId = sheetId;
		_currentHeldItemId = playerSpirit.HeldItemId;
		_playerSpiritId = playerSpirit.PlayerSpiritId;
		_baseSpiritId = playerSpirit.BaseSpiritId.ToString();
		_currentHeldItem = itemModel;
		LoadAvailableItems();
	}

	private void LoadAvailableItems()
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		try
		{
			_003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass23_0();
			CS_0024_003C_003E8__locals0._003C_003E4__this = this;
			IsLoading = true;
			string? playerSpiritId = _playerSpiritId;
			string? baseSpiritId = _baseSpiritId;
			int num = 1;
			List<ItemType> obj = new List<ItemType>(num);
			CollectionsMarshal.SetCount<ItemType>(obj, num);
			CollectionsMarshal.AsSpan<ItemType>(obj)[0] = ItemType.booster;
			CS_0024_003C_003E8__locals0.request = new GetEquippableItemsRequest(playerSpiritId, baseSpiritId, obj);
			MainThread.BeginInvokeOnMainThread((Action)([AsyncStateMachine(typeof(_003C_003Ec__DisplayClass23_0._003C_003CLoadAvailableItems_003Eb__0_003Ed))] [DebuggerStepThrough] () =>
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				_003C_003Ec__DisplayClass23_0._003C_003CLoadAvailableItems_003Eb__0_003Ed _003C_003CLoadAvailableItems_003Eb__0_003Ed = new _003C_003Ec__DisplayClass23_0._003C_003CLoadAvailableItems_003Eb__0_003Ed
				{
					_003C_003Et__builder = AsyncVoidMethodBuilder.Create(),
					_003C_003E4__this = CS_0024_003C_003E8__locals0,
					_003C_003E1__state = -1
				};
				((AsyncVoidMethodBuilder)(ref _003C_003CLoadAvailableItems_003Eb__0_003Ed._003C_003Et__builder)).Start<_003C_003Ec__DisplayClass23_0._003C_003CLoadAvailableItems_003Eb__0_003Ed>(ref _003C_003CLoadAvailableItems_003Eb__0_003Ed);
			}));
		}
		catch (global::System.Exception ex)
		{
			Console.WriteLine("Error initializing held item load: " + ex.Message);
			IsLoading = false;
		}
	}

	[RelayCommand]
	public void SetItem(ItemModel item)
	{
		if (item != null)
		{
			SelectedItem = item;
			NewItemId = item.Id;
			((ObservableObject)this).OnPropertyChanged("HasUnsavedChanges");
			((ObservableObject)this).OnPropertyChanged("HasItem");
			((ObservableObject)this).OnPropertyChanged("IsItemSelected");
			FilteredItems = new ObservableCollection<ItemModel>((global::System.Collections.Generic.IEnumerable<ItemModel>)Enumerable.OrderBy<ItemModel, string>(Enumerable.Where<ItemModel>((global::System.Collections.Generic.IEnumerable<ItemModel>)AvailableItems, (Func<ItemModel, bool>)([CompilerGenerated] (ItemModel i) => i.Id != SelectedItem.Id)), (Func<ItemModel, string>)((ItemModel i) => i.Name)));
		}
	}

	[AsyncStateMachine(typeof(_003CCancel_003Ed__25))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Cancel()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CCancel_003Ed__25 _003CCancel_003Ed__ = new _003CCancel_003Ed__25();
		_003CCancel_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CCancel_003Ed__._003C_003E4__this = this;
		_003CCancel_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CCancel_003Ed__._003C_003Et__builder)).Start<_003CCancel_003Ed__25>(ref _003CCancel_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CCancel_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CConfirm_003Ed__26))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Confirm()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CConfirm_003Ed__26 _003CConfirm_003Ed__ = new _003CConfirm_003Ed__26();
		_003CConfirm_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CConfirm_003Ed__._003C_003E4__this = this;
		_003CConfirm_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CConfirm_003Ed__._003C_003Et__builder)).Start<_003CConfirm_003Ed__26>(ref _003CConfirm_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CConfirm_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CGoToShop_003Ed__27))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task GoToShop()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoToShop_003Ed__27 _003CGoToShop_003Ed__ = new _003CGoToShop_003Ed__27();
		_003CGoToShop_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoToShop_003Ed__._003C_003E4__this = this;
		_003CGoToShop_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoToShop_003Ed__._003C_003Et__builder)).Start<_003CGoToShop_003Ed__27>(ref _003CGoToShop_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoToShop_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRemoveItem_003Ed__28))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task RemoveItem()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRemoveItem_003Ed__28 _003CRemoveItem_003Ed__ = new _003CRemoveItem_003Ed__28();
		_003CRemoveItem_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRemoveItem_003Ed__._003C_003E4__this = this;
		_003CRemoveItem_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRemoveItem_003Ed__._003C_003Et__builder)).Start<_003CRemoveItem_003Ed__28>(ref _003CRemoveItem_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRemoveItem_003Ed__._003C_003Et__builder)).Task;
	}
}
