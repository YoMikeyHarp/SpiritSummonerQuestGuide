using System.CodeDom.Compiler;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Popups;

namespace SpiritSummoner.Presentation.Views.Popups.GuildPopups;

[XamlFilePath("Presentation\\Views\\Popups\\GuildPopups\\CreateGuildPopup.xaml")]
public class CreateGuildPopup : Popup
{
	public CreateGuildPopup(CreateGuildPopupViewModel vm)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = vm;
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<CreateGuildPopup>(this, typeof(CreateGuildPopup));
	}
}
