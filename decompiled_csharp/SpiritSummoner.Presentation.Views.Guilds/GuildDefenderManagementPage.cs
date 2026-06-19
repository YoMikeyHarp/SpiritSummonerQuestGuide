using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Guilds;

namespace SpiritSummoner.Presentation.Views.Guilds;

[XamlFilePath("Presentation\\Views\\Guilds\\GuildDefenderManagementPage.xaml")]
public class GuildDefenderManagementPage : ContentPage
{
	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private HorizontalStackLayout MainDefendersList;

	public GuildDefenderManagementPage(GuildDefenderManagementViewModel viewModel)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	[MemberNotNull("MainDefendersList")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<GuildDefenderManagementPage>(this, typeof(GuildDefenderManagementPage));
		MainDefendersList = NameScopeExtensions.FindByName<HorizontalStackLayout>((Element)(object)this, "MainDefendersList");
	}
}
