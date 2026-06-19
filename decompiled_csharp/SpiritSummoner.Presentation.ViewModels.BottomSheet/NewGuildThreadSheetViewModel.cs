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
using SpiritSummoner.Application.State;
using SpiritSummoner.Application.UseCases.Chat;
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Domain.Entities.Chat;
using SpiritSummoner.Presentation.Services;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.ViewModels.BottomSheet;

public class NewGuildThreadSheetViewModel : ObservableObject
{
	[CompilerGenerated]
	private sealed class _003CSubmit_003Ed__18 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public NewGuildThreadSheetViewModel _003C_003E4__this;

		private string _003CguildId_003E5__1;

		private Result<Conversation> _003Cresult_003E5__2;

		private Result<Conversation> _003C_003Es__3;

		private global::System.Exception _003Cex_003E5__4;

		private TaskAwaiter<Result<Conversation>> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if ((uint)num <= 1u)
				{
					goto IL_0077;
				}
				_003CguildId_003E5__1 = _003C_003E4__this._playerState.GetCurrentPlayer()?.GuildId;
				if (!string.IsNullOrEmpty(_003CguildId_003E5__1))
				{
					_003C_003E4__this.IsSubmitting = true;
					_003C_003E4__this.ErrorMessage = string.Empty;
					goto IL_0077;
				}
				_003C_003E4__this.ErrorMessage = "You must be in a guild to create a thread.";
				goto end_IL_0007;
				IL_0077:
				try
				{
					TaskAwaiter awaiter;
					TaskAwaiter<Result<Conversation>> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter);
							num = (_003C_003E1__state = -1);
							goto IL_01ec;
						}
						awaiter2 = _003C_003E4__this._createGuildThreadUseCase.ExecuteAsync(new CreateGuildThreadRequest(_003CguildId_003E5__1, _003C_003E4__this.Subject.Trim(), _003C_003E4__this.SelectedIcon)).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter2;
							_003CSubmit_003Ed__18 _003CSubmit_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<Conversation>>, _003CSubmit_003Ed__18>(ref awaiter2, ref _003CSubmit_003Ed__);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<Result<Conversation>>);
						num = (_003C_003E1__state = -1);
					}
					_003C_003Es__3 = awaiter2.GetResult();
					_003Cresult_003E5__2 = _003C_003Es__3;
					_003C_003Es__3 = null;
					if (_003Cresult_003E5__2.Success && _003Cresult_003E5__2.Data != null)
					{
						_003C_003E4__this.OnThreadCreated?.Invoke(_003Cresult_003E5__2.Data);
						awaiter = _003C_003E4__this._bottomSheetService.DismissAsync(_003C_003E4__this._sheet).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__2 = awaiter;
							_003CSubmit_003Ed__18 _003CSubmit_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSubmit_003Ed__18>(ref awaiter, ref _003CSubmit_003Ed__);
							return;
						}
						goto IL_01ec;
					}
					_003C_003E4__this.ErrorMessage = _003Cresult_003E5__2.ErrorMessage ?? "Failed to create thread.";
					goto IL_0219;
					IL_0219:
					_003Cresult_003E5__2 = null;
					goto end_IL_0077;
					IL_01ec:
					((TaskAwaiter)(ref awaiter)).GetResult();
					goto IL_0219;
					end_IL_0077:;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__4 = ex;
					_003C_003E4__this.ErrorMessage = "Unexpected error: " + _003Cex_003E5__4.Message;
				}
				finally
				{
					if (num < 0)
					{
						_003C_003E4__this.IsSubmitting = false;
					}
				}
				end_IL_0007:;
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003CguildId_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003CguildId_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly CreateGuildThreadUseCase _createGuildThreadUseCase;

	private readonly IPlayerStateService _playerState;

	private readonly IBottomSheetService _bottomSheetService;

	private BottomSheet? _sheet;

	[ObservableProperty]
	public string[] _availableIcons = new string[8] { "\ud83d\udcac", "\ud83d\udce2", "⚔\ufe0f", "\ud83c\udfc6", "\ud83c\udfae", "\ud83d\udccb", "\ud83d\udd25", "❓" };

	[ObservableProperty]
	[NotifyPropertyChangedFor("CanSubmit")]
	private string _subject = string.Empty;

	[ObservableProperty]
	[NotifyPropertyChangedFor("CanSubmit")]
	private bool _isSubmitting;

	[ObservableProperty]
	private string _errorMessage = string.Empty;

	[ObservableProperty]
	private string _selectedIcon = "\ud83d\udcac";

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<string>? selectIconCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? submitCommand;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public Action<Conversation>? OnThreadCreated
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public bool CanSubmit => !string.IsNullOrWhiteSpace(Subject) && Subject.Length <= 80 && !IsSubmitting;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string[] AvailableIcons
	{
		get
		{
			return _availableIcons;
		}
		[MemberNotNull("_availableIcons")]
		set
		{
			if (!EqualityComparer<string[]>.Default.Equals(_availableIcons, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.AvailableIcons);
				_availableIcons = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.AvailableIcons);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Subject
	{
		get
		{
			return _subject;
		}
		[MemberNotNull("_subject")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_subject, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Subject);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanSubmit);
				_subject = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Subject);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanSubmit);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsSubmitting
	{
		get
		{
			return _isSubmitting;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isSubmitting, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsSubmitting);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanSubmit);
				_isSubmitting = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsSubmitting);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanSubmit);
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
	public string SelectedIcon
	{
		get
		{
			return _selectedIcon;
		}
		[MemberNotNull("_selectedIcon")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_selectedIcon, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SelectedIcon);
				_selectedIcon = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SelectedIcon);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<string> SelectIconCommand => (IRelayCommand<string>)(object)(selectIconCommand ?? (selectIconCommand = new RelayCommand<string>((Action<string>)SelectIcon)));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand SubmitCommand
	{
		get
		{
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_002f: Expected O, but got Unknown
			AsyncRelayCommand obj = submitCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)Submit, (Func<bool>)([CompilerGenerated] () => CanSubmit));
				AsyncRelayCommand val2 = val;
				submitCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public void SetSheet(BottomSheet sheet)
	{
		_sheet = sheet;
	}

	[RelayCommand]
	private void SelectIcon(string icon)
	{
		SelectedIcon = icon;
	}

	public NewGuildThreadSheetViewModel(CreateGuildThreadUseCase createGuildThreadUseCase, IPlayerStateService playerState, IBottomSheetService bottomSheetService)
	{
		_createGuildThreadUseCase = createGuildThreadUseCase;
		_playerState = playerState;
		_bottomSheetService = bottomSheetService;
	}

	[AsyncStateMachine(typeof(_003CSubmit_003Ed__18))]
	[DebuggerStepThrough]
	[RelayCommand(CanExecute = "CanSubmit")]
	private global::System.Threading.Tasks.Task Submit()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CSubmit_003Ed__18 _003CSubmit_003Ed__ = new _003CSubmit_003Ed__18();
		_003CSubmit_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CSubmit_003Ed__._003C_003E4__this = this;
		_003CSubmit_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CSubmit_003Ed__._003C_003Et__builder)).Start<_003CSubmit_003Ed__18>(ref _003CSubmit_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CSubmit_003Ed__._003C_003Et__builder)).Task;
	}
}
