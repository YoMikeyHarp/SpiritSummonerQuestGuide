using System.CodeDom.Compiler;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Popups;

namespace SpiritSummoner.Presentation.Views.Popups.Shared;

[XamlFilePath("Presentation\\Views\\Popups\\Shared\\SearchPlayersPopup.xaml")]
public class SearchPlayersPopup : Popup
{
	public SearchPlayersPopup(SearchPlayersPopupViewModel viewModel)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<SearchPlayersPopup>(this, typeof(SearchPlayersPopup));
	}
}
