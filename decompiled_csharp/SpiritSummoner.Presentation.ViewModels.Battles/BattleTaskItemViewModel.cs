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
using SpiritSummoner.Application.UseCases.Battles;

namespace SpiritSummoner.Presentation.ViewModels.Battles;

public class BattleTaskItemViewModel : ObservableObject
{
	[CompilerGenerated]
	private sealed class _003CClaim_003Ed__48 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BattleTaskItemViewModel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0 || (!_003C_003E4__this.IsClaiming && _003C_003E4__this.CanClaim))
				{
					try
					{
						TaskAwaiter awaiter;
						if (num != 0)
						{
							_003C_003E4__this.IsClaiming = true;
							awaiter = _003C_003E4__this._claimDelegate.Invoke(_003C_003E4__this.TaskId).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CClaim_003Ed__48 _003CClaim_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CClaim_003Ed__48>(ref awaiter, ref _003CClaim_003Ed__);
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
							_003C_003E4__this.IsClaiming = false;
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

	private readonly Func<string, global::System.Threading.Tasks.Task> _claimDelegate;

	[ObservableProperty]
	private bool _isClaiming;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? claimCommand;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string TaskId
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string Title
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string Description
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int CurrentCount
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int Target
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsCompleted
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsRewardClaimed
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public long GoldReward
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public int EnergyReward
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public long GuildCoinsReward
	{
		[CompilerGenerated]
		get;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsWarTask
	{
		[CompilerGenerated]
		get;
	}

	public bool CanClaim => IsCompleted && !IsRewardClaimed;

	public string ProgressText => $"{CurrentCount}/{Target}";

	public double FillProgress => (Target > 0) ? Math.Min(1.0, (double)CurrentCount / (double)Target) : 0.0;

	public bool HasGoldReward => GoldReward > 0;

	public bool HasEnergyReward => EnergyReward > 0;

	public bool HasGuildCoinsReward => GuildCoinsReward > 0;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsClaiming
	{
		get
		{
			return _isClaiming;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isClaiming, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsClaiming);
				_isClaiming = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsClaiming);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ClaimCommand
	{
		get
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0023: Expected O, but got Unknown
			AsyncRelayCommand obj = claimCommand;
			if (obj == null)
			{
				AsyncRelayCommand val = new AsyncRelayCommand((Func<global::System.Threading.Tasks.Task>)Claim);
				AsyncRelayCommand val2 = val;
				claimCommand = val;
				obj = val2;
			}
			return (IAsyncRelayCommand)(object)obj;
		}
	}

	public BattleTaskItemViewModel(BattleTaskView view, Func<string, global::System.Threading.Tasks.Task> claimDelegate)
	{
		_claimDelegate = claimDelegate;
		TaskId = view.TaskId;
		Title = view.Title;
		Description = view.Description;
		CurrentCount = view.CurrentCount;
		Target = view.Target;
		IsCompleted = view.IsCompleted;
		IsRewardClaimed = view.IsRewardClaimed;
		GoldReward = view.GoldReward;
		EnergyReward = view.EnergyReward;
		GuildCoinsReward = view.GuildCoinsReward;
		IsWarTask = view.IsWarTask;
	}

	[AsyncStateMachine(typeof(_003CClaim_003Ed__48))]
	[DebuggerStepThrough]
	[RelayCommand]
	private global::System.Threading.Tasks.Task Claim()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CClaim_003Ed__48 _003CClaim_003Ed__ = new _003CClaim_003Ed__48();
		_003CClaim_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CClaim_003Ed__._003C_003E4__this = this;
		_003CClaim_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CClaim_003Ed__._003C_003Et__builder)).Start<_003CClaim_003Ed__48>(ref _003CClaim_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CClaim_003Ed__._003C_003Et__builder)).Task;
	}
}
