using System.CodeDom.Compiler;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Guilds;

namespace SpiritSummoner.Presentation.Views.Guilds;

[XamlFilePath("Presentation\\Views\\Guilds\\GuildWarsNewPage.xaml")]
public class GuildWarsPage : ContentPage
{
	public GuildWarsPage(GuildWarsViewModel vm)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = vm;
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<GuildWarsPage>(this, typeof(GuildWarsPage));
	}
}
