using System.CodeDom.Compiler;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Popups;

namespace SpiritSummoner.Presentation.Views.Popups.QuestPopups;

[XamlFilePath("Presentation\\Views\\Popups\\QuestPopups\\QuestRewardsPopup.xaml")]
public class QuestRewardsPopup : Popup
{
	public QuestRewardsPopup(QuestRewardsPopupViewModel viewModel)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
	}

	private void Popup_Closed(object sender, PopupClosedEventArgs e)
	{
		if (((BindableObject)this).BindingContext is QuestRewardsPopupViewModel questRewardsPopupViewModel)
		{
			questRewardsPopupViewModel.TapToExitCommand.ExecuteAsync((object)null);
		}
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<QuestRewardsPopup>(this, typeof(QuestRewardsPopup));
	}
}
