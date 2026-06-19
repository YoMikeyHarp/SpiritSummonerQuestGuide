using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Dispatching;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.Quests;

namespace SpiritSummoner.Presentation.Views.Quests;

[XamlFilePath("Presentation\\Views\\Quests\\QuestTaskView.xaml")]
public class QuestTaskView : ContentPage
{
	private global::System.DateTime _touchStartTime;

	private bool _isHolding;

	private readonly IPageCacheService _vmCache;

	private PlayerTaskViewModel? _activeHoldTask;

	private bool _holdStarted = false;

	private bool _longPressOccurred = false;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private CollectionView questCollection;

	public QuestTaskView(QuestTaskViewModel viewModel, IPageCacheService pageCacheService)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
		_vmCache = pageCacheService;
		Page.SetUseSafeArea(((Page)this).On<iOS>(), true);
	}

	protected override void OnAppearing()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		((Page)this).OnAppearing();
		QuestTaskViewModel deepVM = _vmCache.GetDeepVM<QuestTaskViewModel>("//questtasks");
		deepVM?.SubscribeOnAppear();
		if (deepVM != null)
		{
			deepVM.HoldShouldStop += new EventHandler(OnHoldShouldStop);
			deepVM.TasksLoaded += new Action(OnTasksLoaded);
			ObservableCollection<PlayerTaskViewModel>? playerTasks = deepVM.PlayerTasks;
			if (playerTasks != null && Enumerable.Any<PlayerTaskViewModel>((global::System.Collections.Generic.IEnumerable<PlayerTaskViewModel>)playerTasks))
			{
				ScrollToLastVisibleTask(deepVM);
			}
		}
	}

	protected override void OnDisappearing()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		((Page)this).OnDisappearing();
		QuestTaskViewModel deepVM = _vmCache.GetDeepVM<QuestTaskViewModel>("//questtasks");
		if (deepVM != null)
		{
			deepVM.HoldShouldStop -= new EventHandler(OnHoldShouldStop);
			deepVM.TasksLoaded -= new Action(OnTasksLoaded);
		}
		deepVM?.StopTaskHold();
		ResetHoldState();
		deepVM?.DisposeOnNavigateAway();
	}

	private void OnHoldShouldStop(object? sender, EventArgs e)
	{
		ResetHoldState();
	}

	private void OnTasksLoaded()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		QuestTaskViewModel vm = _vmCache.GetDeepVM<QuestTaskViewModel>("//questtasks");
		MainThread.BeginInvokeOnMainThread((Action)delegate
		{
			if (vm != null)
			{
				ScrollToLastVisibleTask(vm);
			}
		});
	}

	private void ScrollToLastVisibleTask(QuestTaskViewModel vm)
	{
		ObservableCollection<PlayerTaskViewModel>? playerTasks = vm.PlayerTasks;
		PlayerTaskViewModel playerTaskViewModel = ((playerTasks != null) ? Enumerable.LastOrDefault<PlayerTaskViewModel>((global::System.Collections.Generic.IEnumerable<PlayerTaskViewModel>)playerTasks, (Func<PlayerTaskViewModel, bool>)((PlayerTaskViewModel t) => t.IsVisible)) : null);
		if (playerTaskViewModel != null && vm.CurrentAreaName != "Champion's Challenge")
		{
			CollectionView obj = NameScopeExtensions.FindByName<CollectionView>((Element)(object)this, "questCollection");
			if (obj != null)
			{
				((ItemsView)obj).ScrollTo((object)playerTaskViewModel, (object)null, (ScrollToPosition)3, false);
			}
		}
	}

	private void ResetHoldState()
	{
		_isHolding = false;
		_activeHoldTask = null;
		_holdStarted = false;
	}

	private void TaskButton_TouchStateChanged(object sender, TouchStateChangedEventArgs e)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Invalid comparison between Unknown and I4
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		PlayerTaskViewModel task = null;
		TouchBehavior val = (TouchBehavior)((sender is TouchBehavior) ? sender : null);
		if (val != null)
		{
			object commandParameter = val.CommandParameter;
			Border val2 = (Border)((commandParameter is Border) ? commandParameter : null);
			if (val2 != null && ((BindableObject)val2).BindingContext is PlayerTaskViewModel playerTaskViewModel)
			{
				task = playerTaskViewModel;
			}
		}
		if (task == null)
		{
			return;
		}
		QuestTaskViewModel vm = _vmCache.GetDeepVM<QuestTaskViewModel>("//questtasks");
		if (vm == null)
		{
			return;
		}
		TouchState state = e.State;
		TouchState val3 = state;
		if ((int)val3 != 0)
		{
			if ((int)val3 != 1)
			{
				return;
			}
			if (_holdStarted || _isHolding)
			{
				Console.WriteLine("⚠\ufe0f Cannot start hold: Another hold is active");
				return;
			}
			if (!task.CanHoldToComplete)
			{
				Console.WriteLine("⚠\ufe0f Cannot start hold: Task not eligible for hold-to-complete");
				return;
			}
			_touchStartTime = global::System.DateTime.UtcNow;
			_isHolding = true;
			_activeHoldTask = task;
			DispatcherExtensions.StartTimer(((BindableObject)this).Dispatcher, TimeSpan.FromMilliseconds(50L, 0L), (Func<bool>)delegate
			{
				if (_isHolding && !_holdStarted && _activeHoldTask == task && task.CanHoldToComplete)
				{
					_holdStarted = true;
					vm.StartTaskHold(task);
				}
				return false;
			});
		}
		else if (_activeHoldTask == task || _isHolding)
		{
			vm.StopTaskHold();
			ResetHoldState();
		}
	}

	public void ForceStopHold()
	{
		_vmCache.GetDeepVM<QuestTaskViewModel>("//questtasks")?.StopTaskHold();
		ResetHoldState();
	}

	private void TouchBehavior_TouchGestureCompleted(object sender, TouchGestureCompletedEventArgs e)
	{
		Border val = (Border)((sender is Border) ? sender : null);
		if (val != null && ((BindableObject)val).BindingContext is PlayerTaskViewModel playerTaskViewModel && ((BindableObject)this).BindingContext is QuestTaskViewModel questTaskViewModel)
		{
			questTaskViewModel.SelectTaskCommand.ExecuteAsync(playerTaskViewModel);
		}
	}

	private void Partner_LongPressCompleted(object sender, LongPressCompletedEventArgs e)
	{
		_longPressOccurred = true;
		if (((BindableObject)this).BindingContext is QuestTaskViewModel questTaskViewModel)
		{
			questTaskViewModel.OpenSpiritsHoldNavigationCommand.ExecuteAsync((object)null);
		}
	}

	private void Partner_TouchGestureCompleted(object sender, TouchGestureCompletedEventArgs e)
	{
		if (_longPressOccurred)
		{
			_longPressOccurred = false;
		}
		else if (((BindableObject)this).BindingContext is QuestTaskViewModel questTaskViewModel)
		{
			questTaskViewModel.NavigateToSpiritDetailsCommand.ExecuteAsync(questTaskViewModel.PartnerSpiritModel.PlayerSpiritId);
		}
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	[MemberNotNull("questCollection")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<QuestTaskView>(this, typeof(QuestTaskView));
		questCollection = NameScopeExtensions.FindByName<CollectionView>((Element)(object)this, "questCollection");
	}
}
