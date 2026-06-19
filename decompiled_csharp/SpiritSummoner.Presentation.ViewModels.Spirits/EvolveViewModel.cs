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
using SpiritSummoner.Application.UseCases.Common;
using SpiritSummoner.Application.UseCases.Spirits;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Spirits;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Presentation.Navigation;

namespace SpiritSummoner.Presentation.ViewModels.Spirits;

public class EvolveViewModel : ObservableObject, ILoadableViewModel
{
	[CompilerGenerated]
	private sealed class _003CContinue_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public EvolveViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _003C_003E4__this._navigationService.GoBackAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CContinue_003Ed__15 _003CContinue_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CContinue_003Ed__15>(ref awaiter, ref _003CContinue_003Ed__);
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
	private sealed class _003CLoadDataAsync_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public object id;

		public EvolveViewModel _003C_003E4__this;

		private string _003CspiritId_003E5__1;

		private PlayerSpirit _003Cspirit_003E5__2;

		private Spirit _003Ctemplate_003E5__3;

		private Spirit _003CevolvedTemplate_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_01e6;
				}
				_003CspiritId_003E5__1 = id as string;
				if (_003CspiritId_003E5__1 != null && !string.IsNullOrEmpty(_003CspiritId_003E5__1))
				{
					_003C_003E4__this._spiritId = _003CspiritId_003E5__1;
					_003Cspirit_003E5__2 = _003C_003E4__this._playerStateService.GetPlayerSpirit(_003CspiritId_003E5__1);
					if (_003Cspirit_003E5__2 != null)
					{
						_003Ctemplate_003E5__3 = _003C_003E4__this._playerStateService.GetSpiritTemplate(_003Cspirit_003E5__2.BaseSpiritID);
						if (_003Ctemplate_003E5__3 != null)
						{
							_003CevolvedTemplate_003E5__4 = _003C_003E4__this._playerStateService.GetSpiritTemplate(_003Ctemplate_003E5__3.Evolution);
							if (_003CevolvedTemplate_003E5__4 != null)
							{
								_003C_003E4__this.CurrentSpiritName = _003Cspirit_003E5__2.Nickname ?? _003Cspirit_003E5__2.Name ?? string.Empty;
								_003C_003E4__this.CurrentSpiritImage = _003Ctemplate_003E5__3.Image ?? string.Empty;
								_003C_003E4__this.EvolvedSpiritName = _003CevolvedTemplate_003E5__4.Name ?? string.Empty;
								_003C_003E4__this.EvolvedSpiritImage = _003CevolvedTemplate_003E5__4.Image ?? string.Empty;
								_003C_003E4__this.IsLoaded = true;
								awaiter = _003C_003E4__this.StartEvolutionAsync().GetAwaiter();
								if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
								{
									num = (_003C_003E1__state = 0);
									_003C_003Eu__1 = awaiter;
									_003CLoadDataAsync_003Ed__13 _003CLoadDataAsync_003Ed__ = this;
									((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLoadDataAsync_003Ed__13>(ref awaiter, ref _003CLoadDataAsync_003Ed__);
									return;
								}
								goto IL_01e6;
							}
						}
					}
				}
				goto end_IL_0007;
				IL_01e6:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CspiritId_003E5__1 = null;
				_003Cspirit_003E5__2 = null;
				_003Ctemplate_003E5__3 = null;
				_003CevolvedTemplate_003E5__4 = null;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CspiritId_003E5__1 = null;
			_003Cspirit_003E5__2 = null;
			_003Ctemplate_003E5__3 = null;
			_003CevolvedTemplate_003E5__4 = null;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CStartEvolutionAsync_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public EvolveViewModel _003C_003E4__this;

		private Result<EvolveSpiritResponse> _003Cresult_003E5__1;

		private Result<EvolveSpiritResponse> _003C_003Es__2;

		private TaskAwaiter<Result<EvolveSpiritResponse>> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<Result<EvolveSpiritResponse>> awaiter;
				if (num != 0)
				{
					_003C_003E4__this.IsAnimating = true;
					awaiter = _003C_003E4__this._evolveSpiritUseCase.ExecuteAsync(new EvolveSpiritRequest(_003C_003E4__this._spiritId)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CStartEvolutionAsync_003Ed__14 _003CStartEvolutionAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<Result<EvolveSpiritResponse>>, _003CStartEvolutionAsync_003Ed__14>(ref awaiter, ref _003CStartEvolutionAsync_003Ed__);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Result<EvolveSpiritResponse>>);
					num = (_003C_003E1__state = -1);
				}
				_003C_003Es__2 = awaiter.GetResult();
				_003Cresult_003E5__1 = _003C_003Es__2;
				_003C_003Es__2 = null;
				if (!_003Cresult_003E5__1.Success)
				{
					_003C_003E4__this.ErrorMessage = _003Cresult_003E5__1.ErrorMessage ?? "Evolution failed";
					_003C_003E4__this.IsAnimating = false;
				}
				else
				{
					_003C_003E4__this.IsEvolved = true;
				}
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

	private readonly INavigationService _navigationService;

	private readonly IPlayerStateService _playerStateService;

	private readonly EvolveSpiritUseCase _evolveSpiritUseCase;

	private string? _spiritId;

	[ObservableProperty]
	private string _currentSpiritImage = string.Empty;

	[ObservableProperty]
	private string _currentSpiritName = string.Empty;

	[ObservableProperty]
	private string _evolvedSpiritImage = string.Empty;

	[ObservableProperty]
	private string _evolvedSpiritName = string.Empty;

	[ObservableProperty]
	private bool _isAnimating = false;

	[ObservableProperty]
	private bool _isEvolved = false;

	[ObservableProperty]
	private string _errorMessage = string.Empty;

	[ObservableProperty]
	private bool _isLoaded = false;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? continueCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string CurrentSpiritImage
	{
		get
		{
			return _currentSpiritImage;
		}
		[MemberNotNull("_currentSpiritImage")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_currentSpiritImage, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentSpiritImage);
				_currentSpiritImage = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentSpiritImage);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string CurrentSpiritName
	{
		get
		{
			return _currentSpiritName;
		}
		[MemberNotNull("_currentSpiritName")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_currentSpiritName, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CurrentSpiritName);
				_currentSpiritName = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CurrentSpiritName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string EvolvedSpiritImage
	{
		get
		{
			return _evolvedSpiritImage;
		}
		[MemberNotNull("_evolvedSpiritImage")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_evolvedSpiritImage, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.EvolvedSpiritImage);
				_evolvedSpiritImage = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.EvolvedSpiritImage);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string EvolvedSpiritName
	{
		get
		{
			return _evolvedSpiritName;
		}
		[MemberNotNull("_evolvedSpiritName")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_evolvedSpiritName, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.EvolvedSpiritName);
				_evolvedSpiritName = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.EvolvedSpiritName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsAnimating
	{
		get
		{
			return _isAnimating;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isAnimating, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsAnimating);
				_isAnimating = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsAnimating);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsEvolved
	{
		get
		{
			return _isEvolved;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isEvolved, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsEvolved);
				_isEvolved = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsEvolved);
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
	public bool IsLoaded
	{
		get
		{
			return _isLoaded;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isLoaded, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsLoaded);
				_isLoaded = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsLoaded);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ContinueCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = continueCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)Continue);
				AsyncRelayCommand val2 = val;
				continueCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public EvolveViewModel(INavigationService navigationService, IPlayerStateService playerStateService, EvolveSpiritUseCase evolveSpiritUseCase)
	{
		_navigationService = navigationService;
		_playerStateService = playerStateService;
		_evolveSpiritUseCase = evolveSpiritUseCase;
	}

	[AsyncStateMachine(typeof(_003CLoadDataAsync_003Ed__13))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task LoadDataAsync(object? id)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadDataAsync_003Ed__13 _003CLoadDataAsync_003Ed__ = new _003CLoadDataAsync_003Ed__13();
		_003CLoadDataAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadDataAsync_003Ed__._003C_003E4__this = this;
		_003CLoadDataAsync_003Ed__.id = id;
		_003CLoadDataAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Start<_003CLoadDataAsync_003Ed__13>(ref _003CLoadDataAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadDataAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CStartEvolutionAsync_003Ed__14))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task StartEvolutionAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CStartEvolutionAsync_003Ed__14 _003CStartEvolutionAsync_003Ed__ = new _003CStartEvolutionAsync_003Ed__14();
		_003CStartEvolutionAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CStartEvolutionAsync_003Ed__._003C_003E4__this = this;
		_003CStartEvolutionAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CStartEvolutionAsync_003Ed__._003C_003Et__builder)).Start<_003CStartEvolutionAsync_003Ed__14>(ref _003CStartEvolutionAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CStartEvolutionAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CContinue_003Ed__15))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Continue()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CContinue_003Ed__15 _003CContinue_003Ed__ = new _003CContinue_003Ed__15();
		_003CContinue_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CContinue_003Ed__._003C_003E4__this = this;
		_003CContinue_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CContinue_003Ed__._003C_003Et__builder)).Start<_003CContinue_003Ed__15>(ref _003CContinue_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CContinue_003Ed__._003C_003Et__builder)).Task;
	}
}
