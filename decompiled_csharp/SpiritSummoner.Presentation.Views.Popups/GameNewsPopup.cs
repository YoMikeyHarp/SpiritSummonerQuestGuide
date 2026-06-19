using System.CodeDom.Compiler;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Popups;

namespace SpiritSummoner.Presentation.Views.Popups;

[XamlFilePath("Presentation\\Views\\Popups\\GameNewsPopup.xaml")]
public class GameNewsPopup : Popup
{
	public GameNewsPopup(NewsDetailsPopupViewModel viewModel)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
	}

	private void Popup_Closed(object sender, PopupClosedEventArgs e)
	{
		if (((BindableObject)this).BindingContext is NewsDetailsPopupViewModel newsDetailsPopupViewModel)
		{
			newsDetailsPopupViewModel.TapToExitCommand.ExecuteAsync((object)null);
		}
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<GameNewsPopup>(this, typeof(GameNewsPopup));
	}
}
