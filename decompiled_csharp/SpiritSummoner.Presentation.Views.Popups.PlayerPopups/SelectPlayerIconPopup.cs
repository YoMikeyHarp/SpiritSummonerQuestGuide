using System.CodeDom.Compiler;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Popups;

namespace SpiritSummoner.Presentation.Views.Popups.PlayerPopups;

[XamlFilePath("Presentation\\Views\\Popups\\PlayerPopups\\SelectPlayerIconPopup.xaml")]
public class SelectPlayerIconPopup : Popup
{
	public SelectPlayerIconPopup(SelectPlayerIconPopupViewModel vm)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = vm;
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<SelectPlayerIconPopup>(this, typeof(SelectPlayerIconPopup));
	}
}
