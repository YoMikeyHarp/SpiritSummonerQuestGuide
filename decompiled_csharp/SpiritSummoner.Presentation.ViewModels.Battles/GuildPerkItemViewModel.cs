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
using SpiritSummoner.Application.UseCases.Guilds;
using SpiritSummoner.Domain.Enums.Guilds;

namespace SpiritSummoner.Presentation.ViewModels.Battles;

public class GuildPerkItemViewModel : ObservableObject
{
	[CompilerGenerated]
	private sealed class _003CActivate_003Ed__38 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public GuildPerkItemViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0)
				{
					goto IL_0041;
				}
				if (_003C_003E4__this.CanActivate && !_003C_003E4__this.IsActivating)
				{
					_003C_003E4__this.IsActivating = true;
					goto IL_0041;
				}
				goto end_IL_0007;
				IL_0041:
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						awaiter = _003C_003E4__this._activateCallback.Invoke(_003C_003E4__this.PerkType).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CActivate_003Ed__38 _003CActivate_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CActivate_003Ed__38>(ref awaiter, ref _003CActivate_003Ed__);
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
						_003C_003E4__this.IsActivating = false;
					}
				}
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

	private readonly GuildPerkView _view;

	private readonly Func<GuildPerkType, global::System.Threading.Tasks.Task> _activateCallback;

	[ObservableProperty]
	private bool _isActivating;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? activateCommand;

	public GuildPerkType PerkType => _view.PerkType;

	public string Title => _view.Title;

	public string Description => _view.Description;

	public int CurrentTier => _view.CurrentTier;

	public int MaxTier => _view.MaxTier;

	public bool IsActive => _view.IsActive;

	public bool IsMaxTier => _view.IsMaxTier;

	public string? ActiveEffectDescription => _view.ActiveEffectDescription;

	public string? NextEffectDescription => _view.NextEffectDescription;

	public int NextTierCrystalCost => _view.NextTierCrystalCost;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsLeader
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int GuildCrystals
	{
		[CompilerGenerated]
		get;
	}

	public bool CanActivate => IsLeader && !IsMaxTier && _view.CanAffordUpgrade;

	public bool CannotAfford => IsLeader && !IsMaxTier && !_view.CanAffordUpgrade;

	public string TierText => IsMaxTier ? $"Tier {CurrentTier} (MAX)" : (IsActive ? $"Tier {CurrentTier}" : "Inactive");

	public string ActivateButtonLabel => (CurrentTier == 0) ? "ACTIVATE" : "UPGRADE";

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsActivating
	{
		get
		{
			return _isActivating;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isActivating, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsActivating);
				_isActivating = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsActivating);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ActivateCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = activateCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)Activate);
				AsyncRelayCommand val2 = val;
				activateCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public GuildPerkItemViewModel(GuildPerkView view, bool isLeader, int guildCrystals, Func<GuildPerkType, global::System.Threading.Tasks.Task> activateCallback)
	{
		_view = view;
		_activateCallback = activateCallback;
		IsLeader = isLeader;
		GuildCrystals = guildCrystals;
	}

	[AsyncStateMachine(typeof(_003CActivate_003Ed__38))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Activate()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CActivate_003Ed__38 _003CActivate_003Ed__ = new _003CActivate_003Ed__38();
		_003CActivate_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CActivate_003Ed__._003C_003E4__this = this;
		_003CActivate_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CActivate_003Ed__._003C_003Et__builder)).Start<_003CActivate_003Ed__38>(ref _003CActivate_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CActivate_003Ed__._003C_003Et__builder)).Task;
	}
}
