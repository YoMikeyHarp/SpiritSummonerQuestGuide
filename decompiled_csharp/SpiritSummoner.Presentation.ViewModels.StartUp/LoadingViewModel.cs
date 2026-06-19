using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using SpiritSummoner.Application.Session;
using SpiritSummoner.Application.State;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Infrastructure.Caching;
using SpiritSummoner.Infrastructure.Contracts;
using SpiritSummoner.Infrastructure.FirebaseListeners;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.Services.Caching;

namespace SpiritSummoner.Presentation.ViewModels.StartUp;

public class LoadingViewModel : ObservableObject
{
	[CompilerGenerated]
	private sealed class _003CLoadAsync_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public LoadingViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private Stopwatch _003Csw_003E5__3;

		private bool _003CisUpToDate_003E5__4;

		private bool _003CloadingStatic_003E5__5;

		private bool _003C_003Es__6;

		private bool _003C_003Es__7;

		private global::System.Exception _003Cex_003E5__8;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0667: Unknown result type (might be due to invalid IL or missing references)
			//IL_066c: Unknown result type (might be due to invalid IL or missing references)
			//IL_06a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_06a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_0710: Unknown result type (might be due to invalid IL or missing references)
			//IL_0715: Unknown result type (might be due to invalid IL or missing references)
			//IL_071d: Unknown result type (might be due to invalid IL or missing references)
			//IL_06d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_06de: Unknown result type (might be due to invalid IL or missing references)
			//IL_0681: Unknown result type (might be due to invalid IL or missing references)
			//IL_0683: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_0278: Unknown result type (might be due to invalid IL or missing references)
			//IL_027d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0285: Unknown result type (might be due to invalid IL or missing references)
			//IL_0357: Unknown result type (might be due to invalid IL or missing references)
			//IL_035c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0364: Unknown result type (might be due to invalid IL or missing references)
			//IL_0406: Unknown result type (might be due to invalid IL or missing references)
			//IL_040b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0413: Unknown result type (might be due to invalid IL or missing references)
			//IL_049b: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0517: Unknown result type (might be due to invalid IL or missing references)
			//IL_051c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0524: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_05bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_04de: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0579: Unknown result type (might be due to invalid IL or missing references)
			//IL_057e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_031e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0323: Unknown result type (might be due to invalid IL or missing references)
			//IL_023f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0244: Unknown result type (might be due to invalid IL or missing references)
			//IL_0462: Unknown result type (might be due to invalid IL or missing references)
			//IL_0467: Unknown result type (might be due to invalid IL or missing references)
			//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0593: Unknown result type (might be due to invalid IL or missing references)
			//IL_0595: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0338: Unknown result type (might be due to invalid IL or missing references)
			//IL_033a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0259: Unknown result type (might be due to invalid IL or missing references)
			//IL_025b: Unknown result type (might be due to invalid IL or missing references)
			//IL_047c: Unknown result type (might be due to invalid IL or missing references)
			//IL_047e: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					_003C_003Es__2 = 0;
					goto case 0;
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				{
					try
					{
						TaskAwaiter<bool> awaiter10;
						TaskAwaiter<bool> awaiter9;
						TaskAwaiter awaiter8;
						TaskAwaiter awaiter7;
						TaskAwaiter awaiter6;
						TaskAwaiter awaiter5;
						TaskAwaiter awaiter4;
						TaskAwaiter awaiter3;
						IPlayerStateService playerState;
						switch (num)
						{
						default:
							_003C_003E4__this.ShowRefresh = false;
							_003C_003E4__this.ShowUpdateRequired = false;
							_003Csw_003E5__3 = Stopwatch.StartNew();
							awaiter10 = _003C_003E4__this._appVersionService.IsClientUpToDateAsync().GetAwaiter();
							if (!awaiter10.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter10;
								_003CLoadAsync_003Ed__13 _003CLoadAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CLoadAsync_003Ed__13>(ref awaiter10, ref _003CLoadAsync_003Ed__);
								return;
							}
							goto IL_0124;
						case 0:
							awaiter10 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							goto IL_0124;
						case 1:
							awaiter9 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<bool>);
							num = (_003C_003E1__state = -1);
							goto IL_01f9;
						case 2:
							awaiter8 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0294;
						case 3:
							awaiter7 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0373;
						case 4:
							awaiter6 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0422;
						case 5:
							awaiter5 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_04b7;
						case 6:
							awaiter4 = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_0533;
						case 7:
							{
								awaiter3 = _003C_003Eu__2;
								_003C_003Eu__2 = default(TaskAwaiter);
								num = (_003C_003E1__state = -1);
								break;
							}
							IL_0294:
							((TaskAwaiter)(ref awaiter8)).GetResult();
							_003C_003E4__this.LoadingMessage = "Please check your internet connection and try again.";
							_003C_003E4__this.ShowRefresh = true;
							goto end_IL_0007;
							IL_0124:
							_003C_003Es__6 = awaiter10.GetResult();
							_003CisUpToDate_003E5__4 = _003C_003Es__6;
							if (_003CisUpToDate_003E5__4)
							{
								_003C_003E4__this._appVersionListener.StartListening();
								_003C_003E4__this.LoadingMessage = "Loading spirits and items...";
								_003C_003E4__this.Progress = 0.3;
								awaiter9 = _003C_003E4__this._staticDataService.LoadStaticDataAsync().GetAwaiter();
								if (!awaiter9.IsCompleted)
								{
									num = (_003C_003E1__state = 1);
									_003C_003Eu__1 = awaiter9;
									_003CLoadAsync_003Ed__13 _003CLoadAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CLoadAsync_003Ed__13>(ref awaiter9, ref _003CLoadAsync_003Ed__);
									return;
								}
								goto IL_01f9;
							}
							_003C_003E4__this.ShowUpdateRequired = true;
							goto end_IL_0007;
							IL_04b7:
							((TaskAwaiter)(ref awaiter5)).GetResult();
							_003C_003E4__this.Progress = 1.0;
							awaiter4 = global::System.Threading.Tasks.Task.Delay(300).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
							{
								num = (_003C_003E1__state = 6);
								_003C_003Eu__2 = awaiter4;
								_003CLoadAsync_003Ed__13 _003CLoadAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadAsync_003Ed__13>(ref awaiter4, ref _003CLoadAsync_003Ed__);
								return;
							}
							goto IL_0533;
							IL_042b:
							_003C_003E4__this.LoadingMessage = "Preparing your adventure...";
							_003C_003E4__this.Progress = 0.8;
							awaiter5 = _003C_003E4__this._presentationInitService.InitializeAsync(showProgress: true).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter5)).IsCompleted)
							{
								num = (_003C_003E1__state = 5);
								_003C_003Eu__2 = awaiter5;
								_003CLoadAsync_003Ed__13 _003CLoadAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadAsync_003Ed__13>(ref awaiter5, ref _003CLoadAsync_003Ed__);
								return;
							}
							goto IL_04b7;
							IL_0373:
							((TaskAwaiter)(ref awaiter7)).GetResult();
							_003C_003E4__this._sessionInitService.WireUpNotificationProcessor();
							playerState = _003C_003E4__this._playerState;
							if (new Func<Player>(playerState.GetCurrentPlayer) != null)
							{
								awaiter6 = _003C_003E4__this._sessionInitService.InitializeNotificationListenerAsync(_003C_003E4__this._playerState.CurrentPlayerId).GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter6)).IsCompleted)
								{
									num = (_003C_003E1__state = 4);
									_003C_003Eu__2 = awaiter6;
									_003CLoadAsync_003Ed__13 _003CLoadAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadAsync_003Ed__13>(ref awaiter6, ref _003CLoadAsync_003Ed__);
									return;
								}
								goto IL_0422;
							}
							goto IL_042b;
							IL_01f9:
							_003C_003Es__7 = awaiter9.GetResult();
							_003CloadingStatic_003E5__5 = _003C_003Es__7;
							if (!_003CloadingStatic_003E5__5)
							{
								awaiter8 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to load game data. Please check your connection and try again.").GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter8)).IsCompleted)
								{
									num = (_003C_003E1__state = 2);
									_003C_003Eu__2 = awaiter8;
									_003CLoadAsync_003Ed__13 _003CLoadAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadAsync_003Ed__13>(ref awaiter8, ref _003CLoadAsync_003Ed__);
									return;
								}
								goto IL_0294;
							}
							Console.WriteLine("Loading static completed in " + _003Csw_003E5__3.ElapsedMilliseconds + "ms");
							_003C_003E4__this.LoadingMessage = "Initializing session...";
							_003C_003E4__this.Progress = 0.5;
							awaiter7 = _003C_003E4__this._sessionInitService.InitializeStaticDataAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter7)).IsCompleted)
							{
								num = (_003C_003E1__state = 3);
								_003C_003Eu__2 = awaiter7;
								_003CLoadAsync_003Ed__13 _003CLoadAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadAsync_003Ed__13>(ref awaiter7, ref _003CLoadAsync_003Ed__);
								return;
							}
							goto IL_0373;
							IL_0533:
							((TaskAwaiter)(ref awaiter4)).GetResult();
							Console.WriteLine("Loadingpage completed in " + _003Csw_003E5__3.ElapsedMilliseconds + "ms");
							awaiter3 = _003C_003E4__this._navigationService.NavigateToAsync("//master").GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
							{
								num = (_003C_003E1__state = 7);
								_003C_003Eu__2 = awaiter3;
								_003CLoadAsync_003Ed__13 _003CLoadAsync_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadAsync_003Ed__13>(ref awaiter3, ref _003CLoadAsync_003Ed__);
								return;
							}
							break;
							IL_0422:
							((TaskAwaiter)(ref awaiter6)).GetResult();
							goto IL_042b;
						}
						((TaskAwaiter)(ref awaiter3)).GetResult();
						_003Csw_003E5__3 = null;
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
					_003Cex_003E5__8 = (global::System.Exception)_003C_003Es__1;
					Console.WriteLine("Error during loading: " + _003Cex_003E5__8.Message);
					Console.WriteLine("Stack trace: " + _003Cex_003E5__8.StackTrace);
					awaiter2 = _003C_003E4__this._navigationService.ShowAlertAsync("Error", "Failed to load game data. Please try logging in again.").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 8);
						_003C_003Eu__2 = awaiter2;
						_003CLoadAsync_003Ed__13 _003CLoadAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadAsync_003Ed__13>(ref awaiter2, ref _003CLoadAsync_003Ed__);
						return;
					}
					goto IL_06bc;
				}
				case 8:
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_06bc;
				case 9:
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_072c;
					}
					IL_072c:
					((TaskAwaiter)(ref awaiter)).GetResult();
					_003Cex_003E5__8 = null;
					break;
					IL_06bc:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					awaiter = _003C_003E4__this._navigationService.NavigateToAsync("//login").GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 9);
						_003C_003Eu__2 = awaiter;
						_003CLoadAsync_003Ed__13 _003CLoadAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadAsync_003Ed__13>(ref awaiter, ref _003CLoadAsync_003Ed__);
						return;
					}
					goto IL_072c;
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
	private sealed class _003CRefreshData_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public LoadingViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this.LoadAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CRefreshData_003Ed__14 _003CRefreshData_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CRefreshData_003Ed__14>(ref awaiter, ref _003CRefreshData_003Ed__);
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

	private readonly IStaticDataCacheService _staticDataService;

	private readonly ISessionInitializationService _sessionInitService;

	private readonly IPresentationCacheInitializationService _presentationInitService;

	private readonly INavigationService _navigationService;

	private readonly IAuthService _authService;

	private readonly IPlayerStateService _playerState;

	private readonly IAppVersionService _appVersionService;

	private readonly IAppVersionListenerService _appVersionListener;

	[ObservableProperty]
	private string _loadingMessage = "Loading game data...";

	[ObservableProperty]
	private double _progress = 0.0;

	[ObservableProperty]
	private bool _showRefresh = false;

	[ObservableProperty]
	private bool _showUpdateRequired = false;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? refreshDataCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string LoadingMessage
	{
		get
		{
			return _loadingMessage;
		}
		[MemberNotNull("_loadingMessage")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_loadingMessage, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.LoadingMessage);
				_loadingMessage = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.LoadingMessage);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public double Progress
	{
		get
		{
			return _progress;
		}
		set
		{
			if (!EqualityComparer<double>.Default.Equals(_progress, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Progress);
				_progress = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Progress);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowRefresh
	{
		get
		{
			return _showRefresh;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showRefresh, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowRefresh);
				_showRefresh = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowRefresh);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool ShowUpdateRequired
	{
		get
		{
			return _showUpdateRequired;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_showUpdateRequired, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ShowUpdateRequired);
				_showUpdateRequired = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ShowUpdateRequired);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand RefreshDataCommand
	{
		get
		{
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_002f: Expected O, but got Unknown
			AsyncRelayCommand obj = refreshDataCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)RefreshData, (Func<bool>)([CompilerGenerated] () => ShowRefresh));
				AsyncRelayCommand val2 = val;
				refreshDataCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public LoadingViewModel(IStaticDataCacheService staticDataService, ISessionInitializationService sessionInitService, IPresentationCacheInitializationService presentationInitService, INavigationService navigationService, IAuthService authService, IPlayerStateService playerState, IAppVersionService appVersionService, IAppVersionListenerService appVersionListener)
	{
		_staticDataService = staticDataService;
		_sessionInitService = sessionInitService;
		_presentationInitService = presentationInitService;
		_navigationService = navigationService;
		_authService = authService;
		_playerState = playerState;
		_appVersionService = appVersionService;
		_appVersionListener = appVersionListener;
	}

	[AsyncStateMachine(typeof(_003CLoadAsync_003Ed__13))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task LoadAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadAsync_003Ed__13 _003CLoadAsync_003Ed__ = new _003CLoadAsync_003Ed__13();
		_003CLoadAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadAsync_003Ed__._003C_003E4__this = this;
		_003CLoadAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadAsync_003Ed__13>(ref _003CLoadAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CRefreshData_003Ed__14))]
	[DebuggerStepThrough]
	[RelayCommand(CanExecute = "ShowRefresh")]
	public global::System.Threading.Tasks.Task RefreshData()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CRefreshData_003Ed__14 _003CRefreshData_003Ed__ = new _003CRefreshData_003Ed__14();
		_003CRefreshData_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CRefreshData_003Ed__._003C_003E4__this = this;
		_003CRefreshData_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CRefreshData_003Ed__._003C_003Et__builder)).Start<_003CRefreshData_003Ed__14>(ref _003CRefreshData_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CRefreshData_003Ed__._003C_003Et__builder)).Task;
	}
}
