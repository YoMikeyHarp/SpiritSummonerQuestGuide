using System.CodeDom.Compiler;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.Services;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.Views.BottomSheets.SpiritSheets;

[XamlFilePath("Presentation\\Views\\BottomSheets\\SpiritSheets\\SpiritsMoreBottomSheet.xaml")]
public class SpiritsMoreBottomSheet : BottomSheet
{
	private readonly IBottomSheetService _sheetService;

	public SpiritsMoreBottomSheet(IBottomSheetService sheetService)
	{
		InitializeComponent();
		_sheetService = sheetService;
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<SpiritsMoreBottomSheet>(this, typeof(SpiritsMoreBottomSheet));
	}
}
