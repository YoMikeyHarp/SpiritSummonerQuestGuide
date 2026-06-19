using System.CodeDom.Compiler;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.BottomSheet;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.Views.BottomSheets.SpiritSheets;

[XamlFilePath("Presentation\\Views\\BottomSheets\\SpiritSheets\\SpiritHoldNavigationSheet.xaml")]
public class SpiritHoldNavigationSheet : BottomSheet
{
	private readonly IBottomSheetService _sheetService;

	public SpiritHoldNavigationSheet(IBottomSheetService sheetService)
	{
		InitializeComponent();
		_sheetService = sheetService;
	}

	private void NavigateToPartner(object sender, TouchGestureCompletedEventArgs e)
	{
		if (((BindableObject)this).BindingContext is SpiritsHoldNavigationSheetViewModel spiritsHoldNavigationSheetViewModel && spiritsHoldNavigationSheetViewModel != null)
		{
			spiritsHoldNavigationSheetViewModel.NavigateToPartnerCommand.ExecuteAsync((object)null);
		}
	}

	private void SavedSquads(object sender, TouchGestureCompletedEventArgs e)
	{
		if (((BindableObject)this).BindingContext is SpiritsHoldNavigationSheetViewModel spiritsHoldNavigationSheetViewModel && spiritsHoldNavigationSheetViewModel != null)
		{
			spiritsHoldNavigationSheetViewModel.SavedSquadsCommand.ExecuteAsync((object)null);
		}
	}

	private void NavigateToCollection(object sender, TouchGestureCompletedEventArgs e)
	{
		if (((BindableObject)this).BindingContext is SpiritsHoldNavigationSheetViewModel spiritsHoldNavigationSheetViewModel && spiritsHoldNavigationSheetViewModel != null)
		{
			spiritsHoldNavigationSheetViewModel.GoToCollectionCommand.ExecuteAsync((object)null);
		}
	}

	private void Dissmiss(object sender, TouchGestureCompletedEventArgs e)
	{
		if (((BindableObject)this).BindingContext is SpiritsHoldNavigationSheetViewModel spiritsHoldNavigationSheetViewModel && spiritsHoldNavigationSheetViewModel != null)
		{
			spiritsHoldNavigationSheetViewModel.DismissSheetCommand.ExecuteAsync((object)null);
		}
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<SpiritHoldNavigationSheet>(this, typeof(SpiritHoldNavigationSheet));
	}
}
