using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel;

namespace SpiritSummoner.Presentation.ViewModels.Popups;

public class NewsDetailsPopupViewModel : ObservableObject
{
	[CompilerGenerated]
	private sealed class _003COpenDiscord_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public NewsDetailsPopupViewModel _003C_003E4__this;

		private string _003Curl_003E5__1;

		private global::System.Exception _003Cex_003E5__2;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter<bool> awaiter;
					if (num != 0)
					{
						_003Curl_003E5__1 = "https://discord.com/channels/675412391244070931/1417698021814308944";
						awaiter = LauncherExtensions.OpenAsync(Launcher.Default, _003Curl_003E5__1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003COpenDiscord_003Ed__4 _003COpenDiscord_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003COpenDiscord_003Ed__4>(ref awaiter, ref _003COpenDiscord_003Ed__);
							return;
						}
					}
					else
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
					}
					awaiter.GetResult();
					_003Curl_003E5__1 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__2 = ex;
					Console.WriteLine($"Failed to open Discord link: {_003Cex_003E5__2}");
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
	private sealed class _003CTapToExit_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public NewsDetailsPopupViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0 || !_003C_003E4__this._isClosing)
				{
					try
					{
						TaskAwaiter awaiter;
						if (num != 0)
						{
							_003C_003E4__this._isClosing = true;
							awaiter = _003C_003E4__this._popupService.ClosePopupAsync((object)null).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CTapToExit_003Ed__3 _003CTapToExit_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CTapToExit_003Ed__3>(ref awaiter, ref _003CTapToExit_003Ed__);
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
							_003C_003E4__this._isClosing = false;
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

	private readonly IPopupService _popupService;

	private bool _isClosing;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? tapToExitCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? openDiscordCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand TapToExitCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = tapToExitCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)TapToExit);
				AsyncRelayCommand val2 = val;
				tapToExitCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand OpenDiscordCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = openDiscordCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)OpenDiscord);
				AsyncRelayCommand val2 = val;
				openDiscordCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public NewsDetailsPopupViewModel(IPopupService popupService)
	{
		_popupService = popupService;
	}

	[AsyncStateMachine(typeof(_003CTapToExit_003Ed__3))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task TapToExit()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CTapToExit_003Ed__3 _003CTapToExit_003Ed__ = new _003CTapToExit_003Ed__3();
		_003CTapToExit_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CTapToExit_003Ed__._003C_003E4__this = this;
		_003CTapToExit_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CTapToExit_003Ed__._003C_003Et__builder)).Start<_003CTapToExit_003Ed__3>(ref _003CTapToExit_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CTapToExit_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003COpenDiscord_003Ed__4))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task OpenDiscord()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COpenDiscord_003Ed__4 _003COpenDiscord_003Ed__ = new _003COpenDiscord_003Ed__4();
		_003COpenDiscord_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003COpenDiscord_003Ed__._003C_003E4__this = this;
		_003COpenDiscord_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003COpenDiscord_003Ed__._003C_003Et__builder)).Start<_003COpenDiscord_003Ed__4>(ref _003COpenDiscord_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003COpenDiscord_003Ed__._003C_003Et__builder)).Task;
	}
}
