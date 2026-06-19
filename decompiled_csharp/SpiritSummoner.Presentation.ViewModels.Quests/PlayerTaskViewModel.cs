using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using SpiritSummoner.Domain.Entities.Players;
using SpiritSummoner.Domain.Entities.Quests;
using SpiritSummoner.Domain.ValueObjects.Quests;

namespace SpiritSummoner.Presentation.ViewModels.Quests;

public class PlayerTaskViewModel : ObservableObject
{
	[CompilerGenerated]
	private sealed class _003CAnimateProgressAsync_003Ed__44 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public double? targetOverride;

		public PlayerTaskViewModel _003C_003E4__this;

		private double _003CtargetProgress_003E5__1;

		private double _003CcurrentProgress_003E5__2;

		private int _003Cduration_003E5__3;

		private int _003Csteps_003E5__4;

		private double _003Cincrement_003E5__5;

		private int _003Cdelay_003E5__6;

		private int _003Ci_003E5__7;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				if (num != 0)
				{
					_003CtargetProgress_003E5__1 = targetOverride ?? _003C_003E4__this.ProgressRatio;
					_003CcurrentProgress_003E5__2 = _003C_003E4__this.AnimatedProgress;
					_003Cduration_003E5__3 = 75;
					_003Csteps_003E5__4 = 10;
					_003Cincrement_003E5__5 = (_003CtargetProgress_003E5__1 - _003CcurrentProgress_003E5__2) / (double)_003Csteps_003E5__4;
					_003Cdelay_003E5__6 = _003Cduration_003E5__3 / _003Csteps_003E5__4;
					_003Ci_003E5__7 = 0;
					goto IL_0134;
				}
				TaskAwaiter awaiter = _003C_003Eu__1;
				_003C_003Eu__1 = default(TaskAwaiter);
				num = (_003C_003E1__state = -1);
				goto IL_0119;
				IL_0134:
				if (_003Ci_003E5__7 < _003Csteps_003E5__4)
				{
					_003C_003E4__this.AnimatedProgress = _003CcurrentProgress_003E5__2 + _003Cincrement_003E5__5 * (double)(_003Ci_003E5__7 + 1);
					awaiter = global::System.Threading.Tasks.Task.Delay(_003Cdelay_003E5__6).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CAnimateProgressAsync_003Ed__44 _003CAnimateProgressAsync_003Ed__ = this;
						_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter, _003CAnimateProgressAsync_003Ed__44>(ref awaiter, ref _003CAnimateProgressAsync_003Ed__);
						return;
					}
					goto IL_0119;
				}
				_003C_003E4__this.AnimatedProgress = _003CtargetProgress_003E5__1;
				result = _003CtargetProgress_003E5__1 >= 1.0;
				goto end_IL_0007;
				IL_0119:
				((TaskAwaiter)(ref awaiter)).GetResult();
				_003Ci_003E5__7++;
				goto IL_0134;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CAnimateProgressToAsync_003Ed__41 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public double target;

		public int durationMs;

		public CancellationToken cancellationToken;

		public PlayerTaskViewModel _003C_003E4__this;

		private double _003Ccurrent_003E5__1;

		private int _003Cdelay_003E5__2;

		private double _003Cincrement_003E5__3;

		private int _003Ci_003E5__4;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num == 0)
				{
					goto IL_00ad;
				}
				_003Ccurrent_003E5__1 = _003C_003E4__this.AnimatedProgress;
				_003Cdelay_003E5__2 = Math.Max(1, durationMs / 10);
				_003Cincrement_003E5__3 = (target - _003Ccurrent_003E5__1) / 10.0;
				_003Ci_003E5__4 = 0;
				goto IL_014c;
				IL_00ad:
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						awaiter = global::System.Threading.Tasks.Task.Delay(_003Cdelay_003E5__2, cancellationToken).GetAwaiter();
						if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CAnimateProgressToAsync_003Ed__41 _003CAnimateProgressToAsync_003Ed__ = this;
							((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CAnimateProgressToAsync_003Ed__41>(ref awaiter, ref _003CAnimateProgressToAsync_003Ed__);
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
				catch (OperationCanceledException)
				{
					_003C_003E4__this.AnimatedProgress = target;
					goto end_IL_0007;
				}
				_003Ci_003E5__4++;
				goto IL_014c;
				IL_014c:
				if (_003Ci_003E5__4 < 10)
				{
					if (!((CancellationToken)(ref cancellationToken)).IsCancellationRequested)
					{
						_003C_003E4__this.AnimatedProgress = _003Ccurrent_003E5__1 + _003Cincrement_003E5__3 * (double)(_003Ci_003E5__4 + 1);
						goto IL_00ad;
					}
					_003C_003E4__this.AnimatedProgress = target;
				}
				else
				{
					_003C_003E4__this.AnimatedProgress = target;
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

	[CompilerGenerated]
	private sealed class _003CUpdateProgress_003Ed__40 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public TaskProgress progress;

		public PlayerTaskViewModel _003C_003E4__this;

		private bool _003CwasCompleted_003E5__1;

		private bool _003CjustCompleted_003E5__2;

		private bool _003CresidualCompletion_003E5__3;

		private bool _003CisCompleted_003E5__4;

		private bool _003C_003Es__5;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_014d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0152: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			bool result;
			try
			{
				TaskAwaiter<bool> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_0169;
				}
				_003CwasCompleted_003E5__1 = _003C_003E4__this.Completed;
				_003CjustCompleted_003E5__2 = progress.IsCompleted && progress.Step == 0 && !_003CwasCompleted_003E5__1;
				_003CresidualCompletion_003E5__3 = (progress.IsCompleted && progress.Step == 0) & _003CwasCompleted_003E5__1;
				_003C_003E4__this.Step = progress.Step;
				_003C_003E4__this.Completed = progress.IsCompleted;
				if (_003C_003E4__this.IsHoldActive)
				{
					result = _003CjustCompleted_003E5__2;
				}
				else
				{
					if (!_003CresidualCompletion_003E5__3)
					{
						_003C_003E4__this._animationCompletionSource = new TaskCompletionSource<bool>();
						awaiter = _003C_003E4__this.AnimateProgressAsync(_003CjustCompleted_003E5__2 ? new double?(1.0) : null).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = awaiter;
							_003CUpdateProgress_003Ed__40 _003CUpdateProgress_003Ed__ = this;
							_003C_003Et__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CUpdateProgress_003Ed__40>(ref awaiter, ref _003CUpdateProgress_003Ed__);
							return;
						}
						goto IL_0169;
					}
					result = false;
				}
				goto end_IL_0007;
				IL_0169:
				_003C_003Es__5 = awaiter.GetResult();
				_003CisCompleted_003E5__4 = _003C_003Es__5;
				_003C_003E4__this._animationCompletionSource.TrySetResult(_003CisCompleted_003E5__4);
				result = _003CisCompleted_003E5__4;
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CWaitForAnimationAsync_003Ed__43 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public PlayerTaskViewModel _003C_003E4__this;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter<bool> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<bool>);
					num = (_003C_003E1__state = -1);
					goto IL_0081;
				}
				if (_003C_003E4__this._animationCompletionSource != null)
				{
					awaiter = _003C_003E4__this._animationCompletionSource.Task.GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CWaitForAnimationAsync_003Ed__43 _003CWaitForAnimationAsync_003Ed__ = this;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<bool>, _003CWaitForAnimationAsync_003Ed__43>(ref awaiter, ref _003CWaitForAnimationAsync_003Ed__);
						return;
					}
					goto IL_0081;
				}
				goto end_IL_0007;
				IL_0081:
				awaiter.GetResult();
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

	private static readonly Brush WhiteBrush = Brush.op_Implicit(Color.FromArgb("#EDF8EA"));

	private Brush? _cachedGradientBrush;

	private CancellationTokenSource? _autoCompleteCts;

	[ObservableProperty]
	[NotifyPropertyChangedFor("CanHoldToComplete")]
	[NotifyPropertyChangedFor("ProgressRatio")]
	[NotifyPropertyChangedFor("BackgroundColor")]
	[NotifyPropertyChangedFor("OpponentsInfo")]
	private QuestTask? _task;

	[ObservableProperty]
	[NotifyPropertyChangedFor("BackgroundColor")]
	private bool _completed;

	[ObservableProperty]
	private bool _isLocked;

	[ObservableProperty]
	private bool _isVisible;

	[ObservableProperty]
	[NotifyPropertyChangedFor("CanHoldToComplete")]
	[NotifyPropertyChangedFor("ProgressRatio")]
	[NotifyPropertyChangedFor("BackgroundColor")]
	[NotifyPropertyChangedFor("InProgress")]
	[NotifyPropertyChangedFor("CanStartOrContinue")]
	[NotifyPropertyChangedFor("ProgressBarVisible")]
	private int _step;

	[ObservableProperty]
	private string? _selectedArea;

	[ObservableProperty]
	[NotifyPropertyChangedFor("CanHoldToComplete")]
	private int _playerEP;

	[ObservableProperty]
	private double _animatedProgress;

	[ObservableProperty]
	private bool _isHoldActive;

	[ObservableProperty]
	[NotifyPropertyChangedFor("CanStartOrContinue")]
	private bool _isShowingCompletionEffects;

	private TaskCompletionSource<bool>? _animationCompletionSource;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public bool IsPendingExecution
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string OpponentImageSource
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = string.Empty;


	public string OpponentsInfo => (Task?.QuestOpponents != null && ((global::System.Collections.Generic.IReadOnlyCollection<QuestOpponent>)Task.QuestOpponents).Count > 0) ? string.Join(", ", Enumerable.Select<QuestOpponent, string>((global::System.Collections.Generic.IEnumerable<QuestOpponent>)Task.QuestOpponents, (Func<QuestOpponent, string>)((QuestOpponent o) => $"Rank {o.Level} ({o.BaseSpiritId})"))) : string.Empty;

	public bool CanHoldToComplete => Task != null && PlayerEP > 0 && !Task.Battle && Task.TotalSteps > 1 && Step < Task.TotalSteps;

	public double ProgressRatio => (Task != null && Task.TotalSteps > 0) ? ((double)Step / (double)Task.TotalSteps) : 0.0;

	public bool InProgress => Step > 0 && Step < (Task?.TotalSteps ?? 0);

	public bool CanStartOrContinue => Task != null && Step < Task.TotalSteps && !IsShowingCompletionEffects;

	public int OpponentLevel => (Task?.QuestOpponents != null && ((global::System.Collections.Generic.IReadOnlyCollection<QuestOpponent>)Task.QuestOpponents).Count > 0) ? Task.QuestOpponents[0].Level : 0;

	public double OpponentDropRate => (Task?.QuestOpponents != null && ((global::System.Collections.Generic.IReadOnlyCollection<QuestOpponent>)Task.QuestOpponents).Count > 0) ? Task.QuestOpponents[0].DropRate : 0.0;

	public bool ProgressBarVisible
	{
		get
		{
			QuestTask? task = Task;
			return task != null && task.TotalSteps > 1;
		}
	}

	public Brush BackgroundColor
	{
		get
		{
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Expected O, but got Unknown
			if (Task != null && !Completed && Step == 0)
			{
				if (_cachedGradientBrush == null)
				{
					_cachedGradientBrush = (Brush)Application.Current.Resources["GradientNewQuest"];
				}
				return _cachedGradientBrush;
			}
			return WhiteBrush;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public QuestTask? Task
	{
		get
		{
			return _task;
		}
		set
		{
			if (!EqualityComparer<QuestTask>.Default.Equals(_task, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Task);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanHoldToComplete);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ProgressRatio);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.BackgroundColor);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.OpponentsInfo);
				_task = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Task);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanHoldToComplete);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ProgressRatio);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.BackgroundColor);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.OpponentsInfo);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool Completed
	{
		get
		{
			return _completed;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_completed, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Completed);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.BackgroundColor);
				_completed = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Completed);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.BackgroundColor);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsLocked
	{
		get
		{
			return _isLocked;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isLocked, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsLocked);
				_isLocked = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsLocked);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsVisible
	{
		get
		{
			return _isVisible;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isVisible, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsVisible);
				_isVisible = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsVisible);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int Step
	{
		get
		{
			return _step;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_step, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.Step);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanHoldToComplete);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ProgressRatio);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.BackgroundColor);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.InProgress);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanStartOrContinue);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.ProgressBarVisible);
				_step = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.Step);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanHoldToComplete);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ProgressRatio);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.BackgroundColor);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.InProgress);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanStartOrContinue);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.ProgressBarVisible);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? SelectedArea
	{
		get
		{
			return _selectedArea;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_selectedArea, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.SelectedArea);
				_selectedArea = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.SelectedArea);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public int PlayerEP
	{
		get
		{
			return _playerEP;
		}
		set
		{
			if (!EqualityComparer<int>.Default.Equals(_playerEP, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.PlayerEP);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanHoldToComplete);
				_playerEP = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.PlayerEP);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanHoldToComplete);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public double AnimatedProgress
	{
		get
		{
			return _animatedProgress;
		}
		set
		{
			if (!EqualityComparer<double>.Default.Equals(_animatedProgress, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.AnimatedProgress);
				_animatedProgress = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.AnimatedProgress);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsHoldActive
	{
		get
		{
			return _isHoldActive;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isHoldActive, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsHoldActive);
				_isHoldActive = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsHoldActive);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsShowingCompletionEffects
	{
		get
		{
			return _isShowingCompletionEffects;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isShowingCompletionEffects, value))
			{
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.IsShowingCompletionEffects);
				((ObservableObject)this).OnPropertyChanging(__KnownINotifyPropertyChangingArgs.CanStartOrContinue);
				_isShowingCompletionEffects = value;
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.IsShowingCompletionEffects);
				((ObservableObject)this).OnPropertyChanged(__KnownINotifyPropertyChangedArgs.CanStartOrContinue);
			}
		}
	}

	[AsyncStateMachine(typeof(_003CUpdateProgress_003Ed__40))]
	[DebuggerStepThrough]
	public async global::System.Threading.Tasks.Task<bool> UpdateProgress(TaskProgress progress)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		bool wasCompleted = Completed;
		bool justCompleted = progress.IsCompleted && progress.Step == 0 && !wasCompleted;
		bool residualCompletion = progress.IsCompleted && progress.Step == 0 && wasCompleted;
		Step = progress.Step;
		Completed = progress.IsCompleted;
		if (IsHoldActive)
		{
			return justCompleted;
		}
		if (residualCompletion)
		{
			return false;
		}
		_animationCompletionSource = new TaskCompletionSource<bool>();
		bool isCompleted = await AnimateProgressAsync(justCompleted ? new double?(1.0) : null);
		_animationCompletionSource.TrySetResult(isCompleted);
		return isCompleted;
	}

	[AsyncStateMachine(typeof(_003CAnimateProgressToAsync_003Ed__41))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task AnimateProgressToAsync(double target, int durationMs, CancellationToken cancellationToken)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		_003CAnimateProgressToAsync_003Ed__41 _003CAnimateProgressToAsync_003Ed__ = new _003CAnimateProgressToAsync_003Ed__41();
		_003CAnimateProgressToAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CAnimateProgressToAsync_003Ed__._003C_003E4__this = this;
		_003CAnimateProgressToAsync_003Ed__.target = target;
		_003CAnimateProgressToAsync_003Ed__.durationMs = durationMs;
		_003CAnimateProgressToAsync_003Ed__.cancellationToken = cancellationToken;
		_003CAnimateProgressToAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CAnimateProgressToAsync_003Ed__._003C_003Et__builder)).Start<_003CAnimateProgressToAsync_003Ed__41>(ref _003CAnimateProgressToAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CAnimateProgressToAsync_003Ed__._003C_003Et__builder)).Task;
	}

	public void ResetAnimatedProgress()
	{
		AnimatedProgress = 0.0;
	}

	[AsyncStateMachine(typeof(_003CWaitForAnimationAsync_003Ed__43))]
	[DebuggerStepThrough]
	public global::System.Threading.Tasks.Task WaitForAnimationAsync()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CWaitForAnimationAsync_003Ed__43 _003CWaitForAnimationAsync_003Ed__ = new _003CWaitForAnimationAsync_003Ed__43();
		_003CWaitForAnimationAsync_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CWaitForAnimationAsync_003Ed__._003C_003E4__this = this;
		_003CWaitForAnimationAsync_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CWaitForAnimationAsync_003Ed__._003C_003Et__builder)).Start<_003CWaitForAnimationAsync_003Ed__43>(ref _003CWaitForAnimationAsync_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CWaitForAnimationAsync_003Ed__._003C_003Et__builder)).Task;
	}

	[AsyncStateMachine(typeof(_003CAnimateProgressAsync_003Ed__44))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<bool> AnimateProgressAsync(double? targetOverride = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		double targetProgress = targetOverride ?? ProgressRatio;
		double currentProgress = AnimatedProgress;
		int duration = 75;
		int steps = 10;
		double increment = (targetProgress - currentProgress) / (double)steps;
		int delay = duration / steps;
		for (int i = 0; i < steps; i++)
		{
			AnimatedProgress = currentProgress + increment * (double)(i + 1);
			await global::System.Threading.Tasks.Task.Delay(delay);
		}
		AnimatedProgress = targetProgress;
		return targetProgress >= 1.0;
	}

	public void Dispose()
	{
		CancellationTokenSource? autoCompleteCts = _autoCompleteCts;
		if (autoCompleteCts != null)
		{
			autoCompleteCts.Cancel();
		}
		CancellationTokenSource? autoCompleteCts2 = _autoCompleteCts;
		if (autoCompleteCts2 != null)
		{
			autoCompleteCts2.Dispose();
		}
	}
}
