using System.CodeDom.Compiler;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Spirits;
using SpiritSummoner.Presentation.ViewModels.Squads;

namespace SpiritSummoner.Presentation.Controls.SquadControls;

[XamlFilePath("Presentation\\Controls\\SquadControls\\SpiritsSquadBottomCardView.xaml")]
public class SpiritsSquadBottomCardView : ContentView
{
	private bool _longPressOccurred = false;

	public SpiritsSquadBottomCardView(SpiritSquadViewModel viewModel)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
	}

	public SpiritsSquadBottomCardView()
	{
		InitializeComponent();
	}

	private void TouchBehavior_TouchGestureCompleted(object sender, TouchGestureCompletedEventArgs e)
	{
		if (_longPressOccurred)
		{
			_longPressOccurred = false;
		}
		else if (((BindableObject)this).BindingContext is SpiritSquadViewModel spiritSquadViewModel)
		{
			Grid val = (Grid)((sender is Grid) ? sender : null);
			if (val != null && ((BindableObject)val).BindingContext is SpiritCardViewModel spiritCardViewModel)
			{
				spiritSquadViewModel.NavigateToSpiritDetailsCommand.ExecuteAsync(spiritCardViewModel.Model.PlayerSpiritId);
			}
		}
	}

	private void TouchBehavior_LongPressCompleted(object sender, LongPressCompletedEventArgs e)
	{
		_longPressOccurred = true;
		if (((BindableObject)this).BindingContext is SpiritSquadViewModel spiritSquadViewModel)
		{
			Grid val = (Grid)((sender is Grid) ? sender : null);
			if (val != null && ((BindableObject)val).BindingContext is SpiritCardViewModel)
			{
				spiritSquadViewModel.OpenSpiritsHoldNavigationCommand.ExecuteAsync((object)null);
			}
		}
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<SpiritsSquadBottomCardView>(this, typeof(SpiritsSquadBottomCardView));
	}
}
