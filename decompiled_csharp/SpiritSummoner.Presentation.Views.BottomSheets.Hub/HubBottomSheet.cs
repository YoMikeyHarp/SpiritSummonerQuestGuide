using System;
using System.CodeDom.Compiler;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.BottomSheet;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.Views.BottomSheets.Hub;

[XamlFilePath("Presentation\\Views\\BottomSheets\\Hub\\HubBottomSheet.xaml")]
public class HubBottomSheet : BottomSheet
{
	private readonly IBottomSheetService _sheetService;

	public HubBottomSheet(IBottomSheetService sheetService)
	{
		InitializeComponent();
		_sheetService = sheetService;
	}

	private void OnPouchTapped(object sender, EventArgs e)
	{
		if (((BindableObject)this).BindingContext is HubSheetViewModel hubSheetViewModel && ((ICommand)hubSheetViewModel.GoToPouchCommand).CanExecute((object)null))
		{
			((ICommand)hubSheetViewModel.GoToPouchCommand).Execute((object)null);
		}
	}

	private void OnSpiritsTapped(object sender, EventArgs e)
	{
		if (((BindableObject)this).BindingContext is HubSheetViewModel hubSheetViewModel && ((ICommand)hubSheetViewModel.OpenFullCollectionCommand).CanExecute((object)null))
		{
			((ICommand)hubSheetViewModel.OpenFullCollectionCommand).Execute((object)null);
		}
	}

	private void OnShopTapped(object sender, EventArgs e)
	{
		if (((BindableObject)this).BindingContext is HubSheetViewModel hubSheetViewModel && ((ICommand)hubSheetViewModel.GoToShopCommand).CanExecute((object)null))
		{
			((ICommand)hubSheetViewModel.GoToShopCommand).Execute((object)null);
		}
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<HubBottomSheet>(this, typeof(HubBottomSheet));
	}
}
