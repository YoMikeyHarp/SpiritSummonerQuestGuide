using System.CodeDom.Compiler;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Popups;

namespace SpiritSummoner.Presentation.Views.Popups.Shared;

[XamlFilePath("Presentation\\Views\\Popups\\Shared\\CustomAlertPopup.xaml")]
public class CustomAlertPopup : Popup
{
	public CustomAlertPopup(CustomAlertPopupViewModel viewModel)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<CustomAlertPopup>(this, typeof(CustomAlertPopup));
	}
}
