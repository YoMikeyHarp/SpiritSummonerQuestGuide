using System;
using System.CodeDom.Compiler;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Guilds;
using SpiritSummoner.Presentation.ViewModels.Popups;

namespace SpiritSummoner.Presentation.Views.Popups.GuildPopups;

[XamlFilePath("Presentation\\Views\\Popups\\GuildPopups\\GuildSearchFilterPopup.xaml")]
public class GuildSearchFilterPopup : Popup
{
	private readonly GuildSearchFilterPopupViewModel _viewModel;

	public GuildSearchFilterPopup(GuildSearchFilterPopupViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		((BindableObject)this).BindingContext = viewModel;
	}

	private void OnCloseClicked(object sender, EventArgs e)
	{
		((Popup)this).Close((object)null);
	}

	private void OnApplyClicked(object sender, EventArgs e)
	{
		GuildSearchFilters guildSearchFilters = _viewModel.ApplyFilters();
		((Popup)this).Close((object)guildSearchFilters);
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<GuildSearchFilterPopup>(this, typeof(GuildSearchFilterPopup));
	}
}
