using System.CodeDom.Compiler;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Guilds;

namespace SpiritSummoner.Presentation.Views.Guilds;

[XamlFilePath("Presentation\\Views\\Guilds\\GuildMembersPage.xaml")]
public class GuildMembersPage : ContentPage
{
	public GuildMembersPage(GuildMembersViewModel viewModel)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<GuildMembersPage>(this, typeof(GuildMembersPage));
	}
}
