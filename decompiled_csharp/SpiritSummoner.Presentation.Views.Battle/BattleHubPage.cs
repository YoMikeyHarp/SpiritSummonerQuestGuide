using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Graphics;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.Battles;

namespace SpiritSummoner.Presentation.Views.Battle;

[XamlFilePath("Presentation\\Views\\Battle\\BattleHubPage.xaml")]
public class BattleHubPage : ContentView
{
	[CompilerGenerated]
	private sealed class _003CBattleHubPage_Loaded_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public object sender;

		public EventArgs e;

		public BattleHubPage _003C_003E4__this;

		private BattleHubViewModel _003CviewModel_003E5__1;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0095;
				}
				object bindingContext = ((BindableObject)_003C_003E4__this).BindingContext;
				_003CviewModel_003E5__1 = bindingContext as BattleHubViewModel;
				if (_003CviewModel_003E5__1 != null)
				{
					awaiter = _003CviewModel_003E5__1.TasksViewModel.LoadAsync().GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						_003CBattleHubPage_Loaded_003Ed__2 _003CBattleHubPage_Loaded_003Ed__ = this;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CBattleHubPage_Loaded_003Ed__2>(ref awaiter, ref _003CBattleHubPage_Loaded_003Ed__);
						return;
					}
					goto IL_0095;
				}
				goto end_IL_0007;
				IL_0095:
				((TaskAwaiter)(ref awaiter)).GetResult();
				end_IL_0007:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003CviewModel_003E5__1 = null;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CviewModel_003E5__1 = null;
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	private IPageCacheService _vmCache;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border MainBorder;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border TasksBorder;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border RewardsBorder;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border PerksBorder;

	public BattleHubPage(BattleHubViewModel viewModel, IPageCacheService vmCache)
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
		_vmCache = vmCache;
		_003F val = MainBorder;
		object staticResourceTasks = viewModel.StaticResourceTasks;
		((VisualElement)val).Background = (Brush)((staticResourceTasks is Brush) ? staticResourceTasks : null);
		((VisualElement)TasksBorder).Background = Brush.op_Implicit(Colors.Transparent);
		TasksBorder.Stroke = Brush.op_Implicit(Colors.Transparent);
		_003F val2 = RewardsBorder;
		object staticResourceRewards = viewModel.StaticResourceRewards;
		((VisualElement)val2).Background = (Brush)((staticResourceRewards is Brush) ? staticResourceRewards : null);
		RewardsBorder.Stroke = Brush.op_Implicit(Colors.SlateGray);
		_003F val3 = PerksBorder;
		object staticResourcePerks = viewModel.StaticResourcePerks;
		((VisualElement)val3).Background = (Brush)((staticResourcePerks is Brush) ? staticResourcePerks : null);
		PerksBorder.Stroke = Brush.op_Implicit(Colors.SlateGray);
		((VisualElement)this).Loaded += new EventHandler(BattleHubPage_Loaded);
	}

	[AsyncStateMachine(typeof(_003CBattleHubPage_Loaded_003Ed__2))]
	[DebuggerStepThrough]
	private void BattleHubPage_Loaded(object? sender, EventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CBattleHubPage_Loaded_003Ed__2 _003CBattleHubPage_Loaded_003Ed__ = new _003CBattleHubPage_Loaded_003Ed__2();
		_003CBattleHubPage_Loaded_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CBattleHubPage_Loaded_003Ed__._003C_003E4__this = this;
		_003CBattleHubPage_Loaded_003Ed__.sender = sender;
		_003CBattleHubPage_Loaded_003Ed__.e = e;
		_003CBattleHubPage_Loaded_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CBattleHubPage_Loaded_003Ed__._003C_003Et__builder)).Start<_003CBattleHubPage_Loaded_003Ed__2>(ref _003CBattleHubPage_Loaded_003Ed__);
	}

	private void TASKS_TouchCompleted(object sender, TouchGestureCompletedEventArgs e)
	{
		if (((BindableObject)this).BindingContext is BattleHubViewModel battleHubViewModel)
		{
			((IRelayCommand<string>)(object)battleHubViewModel.SwitchTabCommand).Execute("Tasks");
			_003F val = MainBorder;
			object staticResourceTasks = battleHubViewModel.StaticResourceTasks;
			((VisualElement)val).Background = (Brush)((staticResourceTasks is Brush) ? staticResourceTasks : null);
			((VisualElement)TasksBorder).Background = Brush.op_Implicit(Colors.Transparent);
			TasksBorder.Stroke = Brush.op_Implicit(Colors.Transparent);
			_003F val2 = RewardsBorder;
			object staticResourceRewards = battleHubViewModel.StaticResourceRewards;
			((VisualElement)val2).Background = (Brush)((staticResourceRewards is Brush) ? staticResourceRewards : null);
			RewardsBorder.Stroke = Brush.op_Implicit(Colors.SlateGray);
			_003F val3 = PerksBorder;
			object staticResourcePerks = battleHubViewModel.StaticResourcePerks;
			((VisualElement)val3).Background = (Brush)((staticResourcePerks is Brush) ? staticResourcePerks : null);
			PerksBorder.Stroke = Brush.op_Implicit(Colors.SlateGray);
		}
	}

	private void REWARDS_TouchCompleted(object sender, TouchGestureCompletedEventArgs e)
	{
		if (((BindableObject)this).BindingContext is BattleHubViewModel battleHubViewModel)
		{
			((IRelayCommand<string>)(object)battleHubViewModel.SwitchTabCommand).Execute("Rewards");
			_003F val = MainBorder;
			object staticResourceRewards = battleHubViewModel.StaticResourceRewards;
			((VisualElement)val).Background = (Brush)((staticResourceRewards is Brush) ? staticResourceRewards : null);
			((VisualElement)RewardsBorder).Background = Brush.op_Implicit(Colors.Transparent);
			RewardsBorder.Stroke = Brush.op_Implicit(Colors.Transparent);
			_003F val2 = TasksBorder;
			object staticResourceTasks = battleHubViewModel.StaticResourceTasks;
			((VisualElement)val2).Background = (Brush)((staticResourceTasks is Brush) ? staticResourceTasks : null);
			TasksBorder.Stroke = Brush.op_Implicit(Colors.SlateGray);
			_003F val3 = PerksBorder;
			object staticResourcePerks = battleHubViewModel.StaticResourcePerks;
			((VisualElement)val3).Background = (Brush)((staticResourcePerks is Brush) ? staticResourcePerks : null);
			PerksBorder.Stroke = Brush.op_Implicit(Colors.SlateGray);
		}
	}

	private void PERKS_TouchCompleted(object sender, TouchGestureCompletedEventArgs e)
	{
		if (((BindableObject)this).BindingContext is BattleHubViewModel battleHubViewModel)
		{
			((IRelayCommand<string>)(object)battleHubViewModel.SwitchTabCommand).Execute("Perks");
			_003F val = MainBorder;
			object staticResourcePerks = battleHubViewModel.StaticResourcePerks;
			((VisualElement)val).Background = (Brush)((staticResourcePerks is Brush) ? staticResourcePerks : null);
			((VisualElement)PerksBorder).Background = Brush.op_Implicit(Colors.Transparent);
			PerksBorder.Stroke = Brush.op_Implicit(Colors.Transparent);
			_003F val2 = TasksBorder;
			object staticResourceTasks = battleHubViewModel.StaticResourceTasks;
			((VisualElement)val2).Background = (Brush)((staticResourceTasks is Brush) ? staticResourceTasks : null);
			TasksBorder.Stroke = Brush.op_Implicit(Colors.SlateGray);
			_003F val3 = RewardsBorder;
			object staticResourceRewards = battleHubViewModel.StaticResourceRewards;
			((VisualElement)val3).Background = (Brush)((staticResourceRewards is Brush) ? staticResourceRewards : null);
			RewardsBorder.Stroke = Brush.op_Implicit(Colors.SlateGray);
		}
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	[MemberNotNull("MainBorder")]
	[MemberNotNull("TasksBorder")]
	[MemberNotNull("RewardsBorder")]
	[MemberNotNull("PerksBorder")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<BattleHubPage>(this, typeof(BattleHubPage));
		MainBorder = NameScopeExtensions.FindByName<Border>((Element)(object)this, "MainBorder");
		TasksBorder = NameScopeExtensions.FindByName<Border>((Element)(object)this, "TasksBorder");
		RewardsBorder = NameScopeExtensions.FindByName<Border>((Element)(object)this, "RewardsBorder");
		PerksBorder = NameScopeExtensions.FindByName<Border>((Element)(object)this, "PerksBorder");
	}
}
