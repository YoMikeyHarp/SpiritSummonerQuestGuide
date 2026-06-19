using System.CodeDom.Compiler;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Popups;

namespace SpiritSummoner.Presentation.Views.Popups.GuildPopups;

[XamlFilePath("Presentation\\Views\\Popups\\GuildPopups\\InvitePlayerPopup.xaml")]
public class InvitePlayerPopup : Popup
{
	public InvitePlayerPopup(InvitePlayerPopupViewModel viewModel)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<InvitePlayerPopup>(this, typeof(InvitePlayerPopup));
	}
}
