using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using SpiritSummoner.Application.DTOs.Session;
using SpiritSummoner.Application.State;
using SpiritSummoner.Domain.Enums.Common;
using SpiritSummoner.Presentation.Navigation;
using SpiritSummoner.Presentation.Services;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.ViewModels.BottomSheets;

public class GuildWarNotificationViewModel : ObservableObject
{
	[CompilerGenerated]
	private sealed class _003CDismiss_003Ed__17 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildWarNotificationViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_008b;
				}
				if (_003C_003E4__this._sheet != null)
				{
					awaiter = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CDismiss_003Ed__17 _003CDismiss_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CDismiss_003Ed__17>(ref awaiter, ref _003CDismiss_003Ed__);
						return;
					}
					goto IL_008b;
				}
				goto end_IL_0007;
				IL_008b:
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
	private sealed class _003CNavigateToGuildWars_003Ed__16 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildWarNotificationViewModel _003C_003E4__this;

		private object _003C_003Es__1;

		private int _003C_003Es__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_0167: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
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
						goto IL_01b7;
					}
					_003C_003Es__1 = null;
					_003C_003Es__2 = 0;
				}
				try
				{
					if (num != 0)
					{
					}
					try
					{
						TaskAwaiter awaiter2;
						if (num == 0)
						{
							awaiter2 = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_00e7;
						}
						if (!string.IsNullOrEmpty(_003C_003E4__this._playerState.GetCurrentPlayer()?.GuildId))
						{
							awaiter2 = _003C_003E4__this._navigationService.NavigateToAsync("//guild/wars?guildId=" + _003C_003E4__this._playerState.GetCurrentPlayer().GuildId).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter2;
								_003CNavigateToGuildWars_003Ed__16 _003CNavigateToGuildWars_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToGuildWars_003Ed__16>(ref awaiter2, ref _003CNavigateToGuildWars_003Ed__);
								return;
							}
							goto IL_00e7;
						}
						goto end_IL_0031;
						IL_00e7:
						((TaskAwaiter)(ref awaiter2)).GetResult();
						goto end_IL_0029;
						end_IL_0031:;
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__3 = ex;
						Console.WriteLine("GuildWarNotificationViewModel: Navigation error: " + _003Cex_003E5__3.Message);
						goto end_IL_0029;
					}
					_003C_003Es__2 = 1;
					end_IL_0029:;
				}
				catch (object obj)
				{
					_003C_003Es__1 = obj;
				}
				if (_003C_003E4__this._sheet != null)
				{
					awaiter = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = awaiter;
						_003CNavigateToGuildWars_003Ed__16 _003CNavigateToGuildWars_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNavigateToGuildWars_003Ed__16>(ref awaiter, ref _003CNavigateToGuildWars_003Ed__);
						return;
					}
					goto IL_01b7;
				}
				goto IL_01bf;
				IL_01b7:
				((TaskAwaiter)(ref awaiter)).GetResult();
				goto IL_01bf;
				IL_01bf:
				object obj2 = _003C_003Es__1;
				if (obj2 != null)
				{
					if (!(obj2 is global::System.Exception ex2))
					{
						throw obj2;
					}
					ExceptionDispatchInfo.Capture(ex2).Throw();
				}
				int num2 = _003C_003Es__2;
				if (num2 != 1)
				{
					_003C_003Es__1 = null;
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

	private readonly IBottomSheetService _bottomSheetService;

	private readonly INavigationService _navigationService;

	private readonly IPlayerStateService _playerState;

	private BottomSheet? _sheet;

	[ObservableProperty]
	private string _title = string.Empty;

	[ObservableProperty]
	private string _body = string.Empty;

	[ObservableProperty]
	private bool _hasRewards;

	[ObservableProperty]
	private int _coinsEarned;

	[ObservableProperty]
	private int _trophiesGained;

	[ObservableProperty]
	private string? _mvpTitle;

	[ObservableProperty]
	private bool _hasMvpTitle;

	[ObservableProperty]
	private string _resultText = string.Empty;

	[ObservableProperty]
	private bool _hasResult;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? navigateToGuildWarsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? dismissCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Title
	{
		get
		{
			return _title;
		}
		[MemberNotNull("_title")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_title, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Title);
				_title = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Title);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Body
	{
		get
		{
			return _body;
		}
		[MemberNotNull("_body")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_body, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Body);
				_body = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Body);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool HasRewards
	{
		get
		{
			return _hasRewards;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasRewards, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasRewards);
				_hasRewards = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasRewards);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int CoinsEarned
	{
		get
		{
			return _coinsEarned;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_coinsEarned, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CoinsEarned);
				_coinsEarned = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CoinsEarned);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int TrophiesGained
	{
		get
		{
			return _trophiesGained;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_trophiesGained, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.TrophiesGained);
				_trophiesGained = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.TrophiesGained);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? MvpTitle
	{
		get
		{
			return _mvpTitle;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_mvpTitle, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.MvpTitle);
				_mvpTitle = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.MvpTitle);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool HasMvpTitle
	{
		get
		{
			return _hasMvpTitle;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasMvpTitle, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasMvpTitle);
				_hasMvpTitle = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasMvpTitle);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string ResultText
	{
		get
		{
			return _resultText;
		}
		[MemberNotNull("_resultText")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_resultText, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ResultText);
				_resultText = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ResultText);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool HasResult
	{
		get
		{
			return _hasResult;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasResult, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasResult);
				_hasResult = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasResult);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand NavigateToGuildWarsCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = navigateToGuildWarsCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)NavigateToGuildWars);
				AsyncRelayCommand val2 = val;
				navigateToGuildWarsCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand DismissCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = dismissCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)Dismiss);
				AsyncRelayCommand val2 = val;
				dismissCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public void SetSheet(BottomSheet sheet)
	{
		_sheet = sheet;
	}

	public GuildWarNotificationViewModel(IBottomSheetService bottomSheetService, INavigationService navigationService, IPlayerStateService playerStateService)
	{
		_bottomSheetService = bottomSheetService;
		_navigationService = navigationService;
		_playerState = playerStateService;
	}

	public void Initialize(PlayerNotificationDTO notification)
	{
		Dictionary<string, object> data = notification.Data ?? new Dictionary<string, object>();
		switch (notification.Type)
		{
		case NotificationType.GuildWarEnrollmentReminder:
			Title = "Guild War Enrollment Open";
			Body = "Your guild is not enrolled in the upcoming war. Open Guild Wars to register before Saturday 18:00 UTC.";
			break;
		case NotificationType.GuildWarMatchFound:
			Title = "Matchmaking Complete!";
			Body = "Your guild has been matched against " + OpponentName() + ". War begins soon — register your defenders before the window closes!";
			break;
		case NotificationType.GuildWarRegistrationClosing:
		{
			int num = GetInt("minutesLeft");
			Title = "Registration Closing Soon";
			Body = $"Only {num} minute{((num == 1) ? "" : "s")} left to register for war against {OpponentName()}. Sign up your defenders now!";
			break;
		}
		case NotificationType.GuildWarDefenderManagement:
		{
			int num2 = GetInt("minutesLeft");
			Title = "Defender Management Reminder";
			Body = $"{num2} minute{((num2 == 1) ? "" : "s")} left to finalize your guild's defenders against {OpponentName()}. Ensure your main defenders are set!";
			break;
		}
		case NotificationType.GuildWarStarted:
			Title = "Guild War Has Begun!";
			Body = "The war against " + OpponentName() + " has started! Attack their defenders and steal crystals to claim victory!";
			break;
		case NotificationType.GuildWarDefenderExpiring:
			Title = "Your Defender Squad Expires Soon";
			Body = "Your defender squad for the war against " + OpponentName() + " expires in ~30 minutes. Re-sign up to keep defending your guild!";
			break;
		case NotificationType.GuildWarEnded:
		{
			string text = GetString("result");
			int coinsEarned = GetInt("coinsEarned");
			int trophiesGained = GetInt("trophiesGained");
			string text2 = GetString("title");
			Title = ((text == "won") ? "Victory! Guild War Ended" : ((text == "lost") ? "Defeat. Guild War Ended" : "Draw! Guild War Ended"));
			Body = "The war against " + OpponentName() + " has concluded. Your rewards are ready!";
			HasRewards = true;
			CoinsEarned = coinsEarned;
			TrophiesGained = trophiesGained;
			MvpTitle = (string.IsNullOrEmpty(text2) ? null : text2);
			HasMvpTitle = !string.IsNullOrEmpty(text2);
			if (1 == 0)
			{
			}
			string resultText = ((text == "won") ? "Victory" : ((!(text == "lost")) ? "Draw" : "Defeat"));
			if (1 == 0)
			{
			}
			ResultText = resultText;
			HasResult = true;
			break;
		}
		default:
			Title = "Guild War Update";
			Body = "Check your guild for the latest war information.";
			break;
		}
		[CompilerGenerated]
		int GetInt(string key)
		{
			object obj2 = default(object);
			object obj3 = default(object);
			object obj4 = default(object);
			int num5 = default(int);
			return (int)((data.TryGetValue(key, ref obj2) && obj2 is long num3) ? num3 : ((data.TryGetValue(key, ref obj3) && obj3 is int num4) ? num4 : (data.TryGetValue(key, ref obj4) ? (int.TryParse(obj4?.ToString(), ref num5) ? num5 : 0) : 0)));
		}
		[CompilerGenerated]
		string GetString(string key)
		{
			object obj5 = default(object);
			return (!data.TryGetValue(key, ref obj5)) ? string.Empty : (obj5?.ToString() ?? string.Empty);
		}
		[CompilerGenerated]
		string OpponentName()
		{
			object obj = default(object);
			return (!data.TryGetValue("opponentName", ref obj)) ? "your opponent" : (obj?.ToString() ?? "your opponent");
		}
	}

	[AsyncStateMachine(typeof(_003CNavigateToGuildWars_003Ed__16))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task NavigateToGuildWars()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CNavigateToGuildWars_003Ed__16 _003CNavigateToGuildWars_003Ed__ = new _003CNavigateToGuildWars_003Ed__16();
		_003CNavigateToGuildWars_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CNavigateToGuildWars_003Ed__._003C_003E4__this = this;
		_003CNavigateToGuildWars_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CNavigateToGuildWars_003Ed__._003C_003Et__builder)).Start<_003CNavigateToGuildWars_003Ed__16>(ref _003CNavigateToGuildWars_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CNavigateToGuildWars_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CDismiss_003Ed__17))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Dismiss()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CDismiss_003Ed__17 _003CDismiss_003Ed__ = new _003CDismiss_003Ed__17();
		_003CDismiss_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CDismiss_003Ed__._003C_003E4__this = this;
		_003CDismiss_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CDismiss_003Ed__._003C_003Et__builder)).Start<_003CDismiss_003Ed__17>(ref _003CDismiss_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CDismiss_003Ed__._003C_003Et__builder)).Task;
	}
}
