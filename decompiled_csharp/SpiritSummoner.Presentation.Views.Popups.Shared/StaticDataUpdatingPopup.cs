using System.CodeDom.Compiler;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.Xaml;

namespace SpiritSummoner.Presentation.Views.Popups.Shared;

[XamlFilePath("Presentation\\Views\\Popups\\Shared\\StaticDataUpdatingPopup.xaml")]
public class StaticDataUpdatingPopup : Popup
{
	public StaticDataUpdatingPopup()
	{
		InitializeComponent();
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<StaticDataUpdatingPopup>(this, typeof(StaticDataUpdatingPopup));
	}
}
