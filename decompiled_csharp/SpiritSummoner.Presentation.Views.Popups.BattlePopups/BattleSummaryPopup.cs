using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Popups;

namespace SpiritSummoner.Presentation.Views.Popups.BattlePopups;

[XamlFilePath("Presentation\\Views\\Popups\\BattlePopups\\BattleSummaryPopup.xaml")]
public class BattleSummaryPopup : Popup
{
	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border enemyLineup;

	public BattleSummaryPopup(BattleSummaryPopupViewModel viewModel)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
	}

	private void Popup_Closed(object sender, PopupClosedEventArgs e)
	{
		if (((BindableObject)this).BindingContext is BattleSummaryPopupViewModel battleSummaryPopupViewModel)
		{
			battleSummaryPopupViewModel.TapToExitCommand.ExecuteAsync((object)null);
		}
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	[MemberNotNull("enemyLineup")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<BattleSummaryPopup>(this, typeof(BattleSummaryPopup));
		enemyLineup = NameScopeExtensions.FindByName<Border>((Element)(object)this, "enemyLineup");
	}
}
