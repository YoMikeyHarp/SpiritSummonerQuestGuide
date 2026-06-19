using System.CodeDom.Compiler;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.BottomSheet;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.Views.Shop.Controls;

[XamlFilePath("Presentation\\Views\\BottomSheets\\ShopSheets\\ShopSpiritBottomSheet.xaml")]
public class ShopSpiritBottomSheet : BottomSheet
{
	private readonly IBottomSheetService _sheetService;

	public ShopSpiritBottomSheet(IBottomSheetService sheetService)
	{
		InitializeComponent();
		_sheetService = sheetService;
	}

	private void BottomSheet_Dismissed(object sender, DismissOrigin e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e == 0 && ((BindableObject)this).BindingContext is ShopSpiritSheetViewModel shopSpiritSheetViewModel)
		{
			shopSpiritSheetViewModel.SetResultGesture();
		}
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<ShopSpiritBottomSheet>(this, typeof(ShopSpiritBottomSheet));
	}
}
