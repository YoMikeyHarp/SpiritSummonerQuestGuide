using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Infrastructure.Services;
using SpiritSummoner.Presentation.Navigation;

namespace SpiritSummoner.Presentation.ViewModels.Quests;

public class QuestParagraphViewModel : ObservableObject, ILoadableViewModel
{
	[CompilerGenerated]
	private sealed class _003CGoBack_003Ed__8 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public QuestParagraphViewModel _003C_003E4__this;

		private QuestParagraphService _003Csvc_003E5__1;

		private int _003CnextIndex_003E5__2;

		private global::System.Exception _003Cex_003E5__3;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0)
				{
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						_003Csvc_003E5__1 = _003C_003E4__this._questParagraphService;
						_003CnextIndex_003E5__2 = _003Csvc_003E5__1.CurrentIndex + 1;
						if (_003CnextIndex_003E5__2 < _003Csvc_003E5__1.ParagraphText.Count)
						{
							_003Csvc_003E5__1.CurrentIndex = _003CnextIndex_003E5__2;
							_003C_003E4__this.Image = Enumerable.ElementAtOrDefault<string>((global::System.Collections.Generic.IEnumerable<string>)_003Csvc_003E5__1.Image, _003CnextIndex_003E5__2);
							_003C_003E4__this.Paragraph = Enumerable.ElementAtOrDefault<string>((global::System.Collections.Generic.IEnumerable<string>)_003Csvc_003E5__1.ParagraphText, _003CnextIndex_003E5__2);
							goto IL_0121;
						}
						awaiter = _003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CGoBack_003Ed__8 _003CGoBack_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CGoBack_003Ed__8>(ref awaiter, ref _003CGoBack_003Ed__);
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
					goto IL_0121;
					IL_0121:
					_003Csvc_003E5__1 = null;
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__3 = ex;
					Console.WriteLine(_003Cex_003E5__3.Message);
					Console.WriteLine(_003Cex_003E5__3.StackTrace ?? string.Empty);
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

	private readonly INavigationService _navigationService;

	private readonly QuestParagraphService _questParagraphService;

	[ObservableProperty]
	private string? _image;

	[ObservableProperty]
	private string? _paragraph;

	[ObservableProperty]
	private string? _questID;

	[ObservableProperty]
	private bool _hasSecondCharacter = false;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<object?>? loadDataCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? goBackCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? Image
	{
		get
		{
			return _image;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_image, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Image);
				_image = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Image);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? Paragraph
	{
		get
		{
			return _paragraph;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_paragraph, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Paragraph);
				_paragraph = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Paragraph);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? QuestID
	{
		get
		{
			return _questID;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_questID, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.QuestID);
				_questID = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.QuestID);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool HasSecondCharacter
	{
		get
		{
			return _hasSecondCharacter;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_hasSecondCharacter, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.HasSecondCharacter);
				_hasSecondCharacter = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.HasSecondCharacter);
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

	public QuestParagraphViewModel(INavigationService navigationService, QuestParagraphService questParagraphService)
	{
		_navigationService = navigationService;
		_questParagraphService = questParagraphService;
	}

	[RelayCommand]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? parameter = null)
	{
		int currentIndex = _questParagraphService.CurrentIndex;
		Image = Enumerable.ElementAtOrDefault<string>((global::System.Collections.Generic.IEnumerable<string>)_questParagraphService.Image, currentIndex);
		Paragraph = Enumerable.ElementAtOrDefault<string>((global::System.Collections.Generic.IEnumerable<string>)_questParagraphService.ParagraphText, currentIndex);
		QuestID = _questParagraphService.questID;
		return global::System.Threading.Tasks.Task.CompletedTask;
	}

	[AsyncStateMachine(typeof(_003CGoBack_003Ed__8))]
	[DebuggerStepThrough]
	[RelayCommand]
	public global::System.Threading.Tasks.Task GoBack()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CGoBack_003Ed__8 _003CGoBack_003Ed__ = new _003CGoBack_003Ed__8();
		_003CGoBack_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CGoBack_003Ed__._003C_003E4__this = this;
		_003CGoBack_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Start<_003CGoBack_003Ed__8>(ref _003CGoBack_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CGoBack_003Ed__._003C_003Et__builder)).Task;
	}
}
