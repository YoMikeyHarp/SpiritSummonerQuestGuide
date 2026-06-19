using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Players;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Presentation.Navigation;

namespace SpiritSummoner.Presentation.ViewModels.Popups;

public class SearchPlayersPopupViewModel : ObservableObject
{
	[CompilerGenerated]
	private sealed class _003CClose_003Ed__17 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SearchPlayersPopupViewModel _003C_003E4__this;

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
						_003CClose_003Ed__17 _003CClose_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CClose_003Ed__17>(ref awaiter, ref _003CClose_003Ed__);
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
	private sealed class _003CSearchPlayers_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public SearchPlayersPopupViewModel _003C_003E4__this;

		private Player _003CcurrentPlayer_003E5__1;

		private SearchPlayersRequest _003Crequest_003E5__2;

		private Result<List<PlayerSearchResultModel>> _003Cresult_003E5__3;

		private Result<List<PlayerSearchResultModel>> _003C_003Es__4;

		private global::System.Exception _003Cex_003E5__5;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<Result<List<PlayerSearchResultModel>>> _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00e0;
				}
				if (num == 1)
				{
					goto IL_00ee;
				}
				if (!string.IsNullOrWhiteSpace(_003C_003E4__this.SearchText) && _003C_003E4__this.SearchText.Length >= 2)
				{
					if (!_003C_003E4__this.IsAccountLinked)
					{
						awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Account error", "You must link your account to chat and add friends!").GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CSearchPlayers_003Ed__14 _003CSearchPlayers_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSearchPlayers_003Ed__14>(ref awaiter, ref _003CSearchPlayers_003Ed__);
							return;
						}
						goto IL_00e0;
					}
					goto IL_00ee;
				}
				_003C_003E4__this.ErrorMessage = "Please enter at least 2 characters";
				goto end_IL_0007;
				IL_00ee:
				try
				{
					TaskAwaiter<Result<List<PlayerSearchResultModel>>> awaiter2;
					if (num == 1)
					{
						awaiter2 = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<Result<List<PlayerSearchResultModel>>>);
						num = (_003C_003E1__state = -1);
						goto IL_01e4;
					}
					_003C_003E4__this.IsSearching = true;
					_003C_003E4__this.ErrorMessage = string.Empty;
					_003CcurrentPlayer_003E5__1 = _003C_003E4__this._playerStateService.GetCurrentPlayer();
					if (_003CcurrentPlayer_003E5__1 != null)
					{
						_003Crequest_003E5__2 = new SearchPlayersRequest(_003C_003E4__this.SearchText, null, _003CcurrentPlayer_003E5__1.PlayerID);
						awaiter2 = _003C_003E4__this._searchPlayersUseCase.ExecuteAsync(_003Crequest_003E5__2).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter2;
							_003CSearchPlayers_003Ed__14 _003CSearchPlayers_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<List<PlayerSearchResultModel>>>, _003CSearchPlayers_003Ed__14>(ref awaiter2, ref _003CSearchPlayers_003Ed__);
							return;
						}
						goto IL_01e4;
					}
					_003C_003E4__this.ErrorMessage = "Not logged in";
					goto end_IL_00ee;
					IL_01e4:
					_003C_003Es__4 = awaiter2.GetResult();
					_003Cresult_003E5__3 = _003C_003Es__4;
					_003C_003Es__4 = null;
					if (_003Cresult_003E5__3.Success)
					{
						_003C_003E4__this.SearchResults = new ObservableCollection<PlayerSearchResultModel>(_003Cresult_003E5__3.Data ?? new List<PlayerSearchResultModel>());
					}
					else
					{
						_003C_003E4__this.ErrorMessage = _003Cresult_003E5__3.ErrorMessage ?? "Search failed";
						((Collection<PlayerSearchResultModel>)(object)_003C_003E4__this.SearchResults).Clear();
					}
					_003C_003E4__this.HasSearched = true;
					_003C_003E4__this.HasResults = ((Collection<PlayerSearchResultModel>)(object)_003C_003E4__this.SearchResults).Count > 0;
					_003CcurrentPlayer_003E5__1 = null;
					_003Crequest_003E5__2 = null;
					_003Cresult_003E5__3 = null;
					end_IL_00ee:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__5 = ex;
					_003C_003E4__this.ErrorMessage = "Failed to search players";
					Console.WriteLine($"SearchPlayers error: {_003Cex_003E5__5}");
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsSearching = false;
					}
				}
				goto end_IL_0007;
				IL_00e0:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
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
	private sealed class _003CSendFriendRequest_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PlayerSearchResultModel player;

		public SearchPlayersPopupViewModel _003C_003E4__this;

		private SendFriendRequestRequest _003Crequest_003E5__1;

		private Result<bool> _003Cresult_003E5__2;

		private Result<bool> _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<Result<bool>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 1u || !(player == null))
				{
					try
					{
						TaskAwaiter awaiter;
						TaskAwaiter<Result<bool>> awaiter2;
						if (num != 0)
						{
							if (num == 1)
							{
								awaiter = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								goto IL_0170;
							}
							_003Crequest_003E5__1 = new SendFriendRequestRequest(player.PlayerId);
							awaiter2 = _003C_003E4__this._sendFriendRequestUseCase.ExecuteAsync(_003Crequest_003E5__1).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003CSendFriendRequest_003Ed__15 _003CSendFriendRequest_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<bool>>, _003CSendFriendRequest_003Ed__15>(ref awaiter2, ref _003CSendFriendRequest_003Ed__);
								return;
							}
						}
						else
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<Result<bool>>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__3 = awaiter2.GetResult();
						_003Cresult_003E5__2 = _003C_003Es__3;
						_003C_003Es__3 = null;
						if (_003Cresult_003E5__2.Success)
						{
							awaiter = _003C_003E4__this._navigationService.ShowAlertAsync("Friend Request Sent", "Friend request sent to " + player.PlayerName + "!").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 1);
								_003C_003Eu__2 = awaiter;
								_003CSendFriendRequest_003Ed__15 _003CSendFriendRequest_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSendFriendRequest_003Ed__15>(ref awaiter, ref _003CSendFriendRequest_003Ed__);
								return;
							}
							goto IL_0170;
						}
						_003C_003E4__this.ErrorMessage = _003Cresult_003E5__2.ErrorMessage ?? "Failed to send friend request";
						goto IL_01d3;
						IL_01d3:
						_003Crequest_003E5__1 = null;
						_003Cresult_003E5__2 = null;
						goto end_IL_0026;
						IL_0170:
						((TaskAwaiter)(ref awaiter)).GetResult();
						((Collection<PlayerSearchResultModel>)(object)_003C_003E4__this.SearchResults).Remove(player);
						_003C_003E4__this.HasResults = ((Collection<PlayerSearchResultModel>)(object)_003C_003E4__this.SearchResults).Count > 0;
						goto IL_01d3;
						end_IL_0026:;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__4 = ex;
						_003C_003E4__this.ErrorMessage = "An error occurred";
						Console.WriteLine($"SendFriendRequest error: {_003Cex_003E5__4}");
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

	private readonly IPlayerStateService _playerStateService;

	private readonly IPopupService _popupService;

	private readonly INavigationService _navigationService;

	private readonly SearchPlayersUseCase _searchPlayersUseCase;

	private readonly SendFriendRequestUseCase _sendFriendRequestUseCase;

	[ObservableProperty]
	private string _searchText = string.Empty;

	[ObservableProperty]
	private ObservableCollection<PlayerSearchResultModel> _searchResults = new ObservableCollection<PlayerSearchResultModel>();

	[ObservableProperty]
	private bool _isSearching;

	[ObservableProperty]
	private bool _hasSearched;

	[ObservableProperty]
	private bool _hasResults;

	[ObservableProperty]
	private string _errorMessage = string.Empty;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? searchPlayersCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<PlayerSearchResultModel>? sendFriendRequestCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? clearSearchCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? closeCommand;

	public bool IsAccountLinked => (_playerStateService?.GetCurrentPlayer()?.IsAccountLinked).GetValueOrDefault();

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
	public ObservableCollection<PlayerSearchResultModel> SearchResults
	{
		get
		{
			return _searchResults;
		}
		[MemberNotNull("_searchResults")]
		set
		{
			if (!EqualityComparer<ObservableCollection<PlayerSearchResultModel>>.Default.Equals(_searchResults, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SearchResults);
				_searchResults = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SearchResults);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsSearching
	{
		get
		{
			return _isSearching;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isSearching, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsSearching);
				_isSearching = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsSearching);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool HasSearched
	{
		get
		{
			return _hasSearched;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasSearched, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasSearched);
				_hasSearched = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasSearched);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool HasResults
	{
		get
		{
			return _hasResults;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasResults, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasResults);
				_hasResults = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasResults);
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

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand SearchPlayersCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = searchPlayersCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)SearchPlayers);
				AsyncRelayCommand val2 = val;
				searchPlayersCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<PlayerSearchResultModel> SendFriendRequestCommand => (IAsyncRelayCommand<PlayerSearchResultModel>)(object)(sendFriendRequestCommand ?? (sendFriendRequestCommand = new AsyncRelayCommand<PlayerSearchResultModel>((Func<PlayerSearchResultModel, global::System.Threading.Tasks.Task>)SendFriendRequest)));

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
	public IAsyncRelayCommand CloseCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = closeCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)Close);
				AsyncRelayCommand val2 = val;
				closeCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public SearchPlayersPopupViewModel(IPlayerStateService playerStateService, IPopupService popupService, INavigationService navigationService, SearchPlayersUseCase searchPlayersUseCase, SendFriendRequestUseCase sendFriendRequestUseCase)
	{
		_playerStateService = playerStateService;
		_popupService = popupService;
		_navigationService = navigationService;
		_searchPlayersUseCase = searchPlayersUseCase;
		_sendFriendRequestUseCase = sendFriendRequestUseCase;
	}

	[AsyncStateMachine(typeof(_003CSearchPlayers_003Ed__14))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task SearchPlayers()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSearchPlayers_003Ed__14 _003CSearchPlayers_003Ed__ = new _003CSearchPlayers_003Ed__14();
		_003CSearchPlayers_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSearchPlayers_003Ed__._003C_003E4__this = this;
		_003CSearchPlayers_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSearchPlayers_003Ed__._003C_003Et__builder)).Start<_003CSearchPlayers_003Ed__14>(ref _003CSearchPlayers_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSearchPlayers_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CSendFriendRequest_003Ed__15))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task SendFriendRequest(PlayerSearchResultModel player)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSendFriendRequest_003Ed__15 _003CSendFriendRequest_003Ed__ = new _003CSendFriendRequest_003Ed__15();
		_003CSendFriendRequest_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSendFriendRequest_003Ed__._003C_003E4__this = this;
		_003CSendFriendRequest_003Ed__.player = player;
		_003CSendFriendRequest_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSendFriendRequest_003Ed__._003C_003Et__builder)).Start<_003CSendFriendRequest_003Ed__15>(ref _003CSendFriendRequest_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSendFriendRequest_003Ed__._003C_003Et__builder)).Task;
	}

	[RelayCommand]
	private void ClearSearch()
	{
		SearchText = string.Empty;
		((Collection<PlayerSearchResultModel>)(object)SearchResults).Clear();
		HasSearched = false;
		HasResults = false;
		ErrorMessage = string.Empty;
	}

	[AsyncStateMachine(typeof(_003CClose_003Ed__17))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Close()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CClose_003Ed__17 _003CClose_003Ed__ = new _003CClose_003Ed__17();
		_003CClose_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CClose_003Ed__._003C_003E4__this = this;
		_003CClose_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CClose_003Ed__._003C_003Et__builder)).Start<_003CClose_003Ed__17>(ref _003CClose_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CClose_003Ed__._003C_003Et__builder)).Task;
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSearchTextChanged(string value)
	{
		if (!string.IsNullOrEmpty(ErrorMessage))
		{
			ErrorMessage = string.Empty;
		}
	}
}
