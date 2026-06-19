using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Guilds;

namespace SpiritSummoner.Presentation.Views.Guilds;

[XamlFilePath("Presentation\\Views\\Guilds\\GuildWarHistoryPage.xaml")]
public class GuildWarHistoryPage : ContentPage
{
	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private ContentPage ThisPage;

	public GuildWarHistoryPage(GuildWarHistoryViewModel vm)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = vm;
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	[MemberNotNull("ThisPage")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<GuildWarHistoryPage>(this, typeof(GuildWarHistoryPage));
		ThisPage = NameScopeExtensions.FindByName<ContentPage>((Element)(object)this, "ThisPage");
	}
}
