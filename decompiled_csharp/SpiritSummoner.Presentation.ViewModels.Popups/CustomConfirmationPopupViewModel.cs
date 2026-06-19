using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Graphics;

namespace SpiritSummoner.Presentation.ViewModels.Popups;

public class CustomConfirmationPopupViewModel : ObservableObject
{
	[CompilerGenerated]
	private sealed class _003CNo_003Ed__9 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public CustomConfirmationPopupViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
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
							awaiter = _003C_003E4__this._popupService.ClosePopupAsync((object)false).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CNo_003Ed__9 _003CNo_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CNo_003Ed__9>(ref awaiter, ref _003CNo_003Ed__);
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

	[CompilerGenerated]
	private sealed class _003CYes_003Ed__8 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public CustomConfirmationPopupViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
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
							awaiter = _003C_003E4__this._popupService.ClosePopupAsync((object)true).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CYes_003Ed__8 _003CYes_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CYes_003Ed__8>(ref awaiter, ref _003CYes_003Ed__);
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
					catch (global::System.Exception)
					{
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

	[ObservableProperty]
	private string _title = string.Empty;

	[ObservableProperty]
	private string _message = string.Empty;

	[ObservableProperty]
	private string _yesButtonText = "Yes";

	[ObservableProperty]
	private string _noButtonText = "No";

	[ObservableProperty]
	private Color _strokeColor = Color.FromArgb("#EFB646");

	private bool _isClosing;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? yesCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? noCommand;

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
	public string Message
	{
		get
		{
			return _message;
		}
		[MemberNotNull("_message")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_message, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Message);
				_message = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Message);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string YesButtonText
	{
		get
		{
			return _yesButtonText;
		}
		[MemberNotNull("_yesButtonText")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_yesButtonText, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.YesButtonText);
				_yesButtonText = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.YesButtonText);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string NoButtonText
	{
		get
		{
			return _noButtonText;
		}
		[MemberNotNull("_noButtonText")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_noButtonText, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.NoButtonText);
				_noButtonText = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.NoButtonText);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Color StrokeColor
	{
		get
		{
			return _strokeColor;
		}
		[MemberNotNull("_strokeColor")]
		set
		{
			if (!EqualityComparer<Color>.Default.Equals(_strokeColor, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.StrokeColor);
				_strokeColor = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.StrokeColor);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand YesCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = yesCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)Yes);
				AsyncRelayCommand val2 = val;
				yesCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand NoCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = noCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)No);
				AsyncRelayCommand val2 = val;
				noCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public CustomConfirmationPopupViewModel(IPopupService popupService)
	{
		_popupService = popupService;
	}

	[AsyncStateMachine(typeof(_003CYes_003Ed__8))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task Yes()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CYes_003Ed__8 _003CYes_003Ed__ = new _003CYes_003Ed__8();
		_003CYes_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CYes_003Ed__._003C_003E4__this = this;
		_003CYes_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CYes_003Ed__._003C_003Et__builder)).Start<_003CYes_003Ed__8>(ref _003CYes_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CYes_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CNo_003Ed__9))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task No()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CNo_003Ed__9 _003CNo_003Ed__ = new _003CNo_003Ed__9();
		_003CNo_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CNo_003Ed__._003C_003E4__this = this;
		_003CNo_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CNo_003Ed__._003C_003Et__builder)).Start<_003CNo_003Ed__9>(ref _003CNo_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CNo_003Ed__._003C_003Et__builder)).Task;
	}
}
