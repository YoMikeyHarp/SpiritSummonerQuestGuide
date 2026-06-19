using System;
using System.CodeDom.Compiler;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Guilds;

namespace SpiritSummoner.Presentation.Views.Guilds;

[XamlFilePath("Presentation\\Views\\Guilds\\GuildHubNewPage.xaml")]
public class GuildHubNewPage : ContentView
{
	public GuildHubNewPage(GuildHubViewModel vm)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		InitializeComponent();
		((BindableObject)this).BindingContext = vm;
		((VisualElement)this).Loaded += new EventHandler(GuildHub_Loaded);
		((VisualElement)this).Unloaded += new EventHandler(GuildHub_Unloaded);
	}

	private void GuildHub_Loaded(object? sender, EventArgs e)
	{
		if (((BindableObject)this).BindingContext is GuildHubViewModel guildHubViewModel)
		{
			guildHubViewModel.OnPageAppearingAsync();
		}
	}

	private void GuildHub_Unloaded(object? sender, EventArgs e)
	{
		if (((BindableObject)this).BindingContext is GuildHubViewModel guildHubViewModel)
		{
			guildHubViewModel.OnPageDisappearing();
		}
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<GuildHubNewPage>(this, typeof(GuildHubNewPage));
	}
}
