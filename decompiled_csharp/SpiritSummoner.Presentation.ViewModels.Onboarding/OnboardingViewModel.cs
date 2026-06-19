using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using SpiritSummoner.Application.Auth;
using SpiritSummoner.Application.Enums;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Presentation.Navigation;

namespace SpiritSummoner.Presentation.ViewModels.Onboarding;

public class OnboardingViewModel : ObservableObject, ILoadableViewModel
{
	[CompilerGenerated]
	private sealed class _003CLoadDataAsync_003Ed__9 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object parameter;

		public OnboardingViewModel _003C_003E4__this;

		private OnboardingStep _003Cstep_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0092;
				}
				_003Cstep_003E5__1 = _003C_003E4__this._registrationOrchestrator.CurrentOnboardingStep;
				if (_003Cstep_003E5__1 == OnboardingStep.FirstSpiritsCard)
				{
					awaiter = _003C_003E4__this._registrationOrchestrator.LoadStarterSpiritsAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CLoadDataAsync_003Ed__9 _003CLoadDataAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__9>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
						return;
					}
					goto IL_0092;
				}
				_003C_003E4__this.UpdateFromOrchestrator();
				goto end_IL_0007;
				IL_0092:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003C_003E4__this.UpdateSpiritsFromOrchestrator();
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
	private sealed class _003CTapToContinue_003Ed__10 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public OnboardingViewModel _003C_003E4__this;

		private OnboardingNavigationResult _003Cresult_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Unknown result type (might be due to invalid IL or missing references)
			//IL_020f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0299: Unknown result type (might be due to invalid IL or missing references)
			//IL_029e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_0263: Unknown result type (might be due to invalid IL or missing references)
			//IL_0268: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_027d: Unknown result type (might be due to invalid IL or missing references)
			//IL_027f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter4;
				TaskAwaiter awaiter3;
				TaskAwaiter awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					_003Cresult_003E5__1 = _003C_003E4__this._registrationOrchestrator.AdvanceOnboarding();
					if (_003Cresult_003E5__1.ShouldNavigateToUsernameSelection)
					{
						awaiter4 = _003C_003E4__this._navigationService.NavigateToAsync(_003Cresult_003E5__1.Route.Route).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter4)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter4;
							_003CTapToContinue_003Ed__10 _003CTapToContinue_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CTapToContinue_003Ed__10>(ref awaiter4, ref _003CTapToContinue_003Ed__);
							return;
						}
						goto IL_00cf;
					}
					if (_003Cresult_003E5__1.IsComplete)
					{
						awaiter3 = _003C_003E4__this._navigationService.NavigateToAsync(_003Cresult_003E5__1.Route.Route).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter3)).IsCompleted)
						{
							num = (_003C_003E1__state = 1);
							_003C_003Eu__1 = awaiter3;
							_003CTapToContinue_003Ed__10 _003CTapToContinue_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CTapToContinue_003Ed__10>(ref awaiter3, ref _003CTapToContinue_003Ed__);
							return;
						}
						goto IL_0166;
					}
					if (_003C_003E4__this._registrationOrchestrator.CurrentOnboardingStep == OnboardingStep.FirstSpiritsCard)
					{
						if (_003C_003E4__this.StarterSpirits == null || _003C_003E4__this.StarterSpirits.Count == 0)
						{
							awaiter2 = _003C_003E4__this._registrationOrchestrator.LoadStarterSpiritsAsync().GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__1 = awaiter2;
								_003CTapToContinue_003Ed__10 _003CTapToContinue_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CTapToContinue_003Ed__10>(ref awaiter2, ref _003CTapToContinue_003Ed__);
								return;
							}
							goto IL_021e;
						}
						goto IL_0226;
					}
					_003C_003E4__this.UpdateFromOrchestrator();
					goto IL_0243;
				case 0:
					awaiter4 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00cf;
				case 1:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0166;
				case 2:
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_021e;
				case 3:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_0226:
					_003C_003E4__this.UpdateSpiritsFromOrchestrator();
					goto IL_0243;
					IL_021e:
					((TaskAwaiter)(ref awaiter2)).GetResult();
					goto IL_0226;
					IL_00cf:
					((TaskAwaiter)(ref awaiter4)).GetResult();
					goto end_IL_0007;
					IL_0166:
					((TaskAwaiter)(ref awaiter3)).GetResult();
					goto end_IL_0007;
					IL_0243:
					awaiter = _003C_003E4__this._navigationService.NavigateToAsync(_003Cresult_003E5__1.Route.Route).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = awaiter;
						_003CTapToContinue_003Ed__10 _003CTapToContinue_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CTapToContinue_003Ed__10>(ref awaiter, ref _003CTapToContinue_003Ed__);
						return;
					}
					break;
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cresult_003E5__1 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cresult_003E5__1 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private readonly IRegistrationOrchestrator _registrationOrchestrator;

	private readonly INavigationService _navigationService;

	[ObservableProperty]
	private string? _speakerName;

	[ObservableProperty]
	private string? _dialogueText;

	[ObservableProperty]
	private string? _characterImage1;

	[ObservableProperty]
	private string? _characterImage2;

	[ObservableProperty]
	private bool _hasSecondCharacter;

	[ObservableProperty]
	private List<OnboardingSpiritReadModel>? _starterSpirits;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? tapToContinueCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? SpeakerName
	{
		get
		{
			return _speakerName;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_speakerName, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SpeakerName);
				_speakerName = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SpeakerName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? DialogueText
	{
		get
		{
			return _dialogueText;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_dialogueText, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.DialogueText);
				_dialogueText = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.DialogueText);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? CharacterImage1
	{
		get
		{
			return _characterImage1;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_characterImage1, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CharacterImage1);
				_characterImage1 = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CharacterImage1);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? CharacterImage2
	{
		get
		{
			return _characterImage2;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_characterImage2, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CharacterImage2);
				_characterImage2 = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CharacterImage2);
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

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public List<OnboardingSpiritReadModel>? StarterSpirits
	{
		get
		{
			return _starterSpirits;
		}
		set
		{
			if (!EqualityComparer<List<OnboardingSpiritReadModel>>.Default.Equals(_starterSpirits, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.StarterSpirits);
				_starterSpirits = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.StarterSpirits);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand TapToContinueCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = tapToContinueCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)TapToContinue);
				AsyncRelayCommand val2 = val;
				tapToContinueCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public OnboardingViewModel(IRegistrationOrchestrator registrationOrchestrator, INavigationService navigationService)
	{
		_registrationOrchestrator = registrationOrchestrator;
		_navigationService = navigationService;
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__9))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? parameter = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__9 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__9();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.parameter = parameter;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__9>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CTapToContinue_003Ed__10))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task TapToContinue()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CTapToContinue_003Ed__10 _003CTapToContinue_003Ed__ = new _003CTapToContinue_003Ed__10();
		_003CTapToContinue_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CTapToContinue_003Ed__._003C_003E4__this = this;
		_003CTapToContinue_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CTapToContinue_003Ed__._003C_003Et__builder)).Start<_003CTapToContinue_003Ed__10>(ref _003CTapToContinue_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CTapToContinue_003Ed__._003C_003Et__builder)).Task;
	}

	private void UpdateFromOrchestrator()
	{
		OnboardingDialogueData currentDialogueData = _registrationOrchestrator.CurrentDialogueData;
		if (currentDialogueData != null)
		{
			SpeakerName = currentDialogueData.SpeakerName;
			DialogueText = currentDialogueData.Text;
			CharacterImage1 = currentDialogueData.Image1;
			CharacterImage2 = currentDialogueData.Image2;
			HasSecondCharacter = !string.IsNullOrEmpty(currentDialogueData.Image2);
		}
	}

	private void UpdateSpiritsFromOrchestrator()
	{
		StarterSpiritData starterSpirit = _registrationOrchestrator.StarterSpirit;
		if (starterSpirit != null)
		{
			OnboardingSpiritReadModel onboardingSpiritReadModel = new OnboardingSpiritReadModel(starterSpirit);
			int num = 1;
			List<OnboardingSpiritReadModel> obj = new List<OnboardingSpiritReadModel>(num);
			CollectionsMarshal.SetCount<OnboardingSpiritReadModel>(obj, num);
			CollectionsMarshal.AsSpan<OnboardingSpiritReadModel>(obj)[0] = onboardingSpiritReadModel;
			StarterSpirits = obj;
		}
	}
}
