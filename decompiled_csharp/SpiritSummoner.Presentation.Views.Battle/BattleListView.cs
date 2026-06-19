using System.CodeDom.Compiler;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.Models;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.Battles;

namespace SpiritSummoner.Presentation.Views.Battle;

[XamlFilePath("Presentation\\Views\\Battle\\BattleListView.xaml")]
public class BattleListView : ContentPage
{
	private readonly IPageCacheService _vmCache;

	private bool _longPressOccurred;

	public BattleListView(BattleListViewModel viewModel, IPageCacheService vmCache)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
		_vmCache = vmCache;
	}

	private void TouchBehavior_TouchGestureCompleted(object sender, TouchGestureCompletedEventArgs e)
	{
		Border val = (Border)((sender is Border) ? sender : null);
		if (val != null && ((BindableObject)val).BindingContext is BattleOpponentPresentationModel battleOpponentPresentationModel)
		{
			_vmCache.GetDeepVM<BattleListViewModel>("//battlelist")?.StartBattleCommand.ExecuteAsync(battleOpponentPresentationModel);
		}
	}

	private void Partner_LongPressCompleted(object sender, LongPressCompletedEventArgs e)
	{
		_longPressOccurred = true;
		if (((BindableObject)this).BindingContext is BattleListViewModel battleListViewModel)
		{
			battleListViewModel.OpenSpiritsHoldNavigationCommand.ExecuteAsync((object)null);
		}
	}

	private void Partner_TouchGestureCompleted(object sender, TouchGestureCompletedEventArgs e)
	{
		if (_longPressOccurred)
		{
			_longPressOccurred = false;
		}
		else if (((BindableObject)this).BindingContext is BattleListViewModel battleListViewModel)
		{
			battleListViewModel.NavigateToSpiritDetailsCommand.ExecuteAsync(battleListViewModel.PartnerSpiritModel.PlayerSpiritId);
		}
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<BattleListView>(this, typeof(BattleListView));
	}
}
