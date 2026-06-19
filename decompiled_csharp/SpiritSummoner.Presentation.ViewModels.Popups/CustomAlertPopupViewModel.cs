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

public class CustomAlertPopupViewModel : ObservableObject
{
	[CompilerGenerated]
	private sealed class _003COk_003Ed__6 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public CustomAlertPopupViewModel _003C_003E4__this;

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
								_003COk_003Ed__6 _003COk_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003COk_003Ed__6>(ref awaiter, ref _003COk_003Ed__);
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

	[ObservableProperty]
	private string _title = string.Empty;

	[ObservableProperty]
	private string _message = string.Empty;

	[ObservableProperty]
	private Color _strokeColor = Color.FromArgb("#EFB646");

	private bool _isClosing;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? okCommand;

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
	public IAsyncRelayCommand OkCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = okCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)Ok);
				AsyncRelayCommand val2 = val;
				okCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public CustomAlertPopupViewModel(IPopupService popupService)
	{
		_popupService = popupService;
	}

	[AsyncStateMachine(typeof(_003COk_003Ed__6))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task Ok()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003COk_003Ed__6 _003COk_003Ed__ = new _003COk_003Ed__6();
		_003COk_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003COk_003Ed__._003C_003E4__this = this;
		_003COk_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003COk_003Ed__._003C_003Et__builder)).Start<_003COk_003Ed__6>(ref _003COk_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003COk_003Ed__._003C_003Et__builder)).Task;
	}
}
