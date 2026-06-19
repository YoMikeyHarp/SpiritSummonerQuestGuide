using System.CodeDom.Compiler;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace SpiritSummoner.Presentation.Views.Battle.Controls;

[XamlFilePath("Presentation\\Views\\Battle\\Controls\\GuildPerksView.xaml")]
public class GuildPerksView : ContentView
{
	public GuildPerksView()
	{
		InitializeComponent();
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<GuildPerksView>(this, typeof(GuildPerksView));
	}
}
