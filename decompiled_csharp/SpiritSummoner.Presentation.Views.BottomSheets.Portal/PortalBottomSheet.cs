using System.CodeDom.Compiler;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.Services;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.Views.BottomSheets.Portal;

[XamlFilePath("Presentation\\Views\\BottomSheets\\Portal\\PortalBottomSheet.xaml")]
public class PortalBottomSheet : BottomSheet
{
	private readonly IBottomSheetService _sheetService;

	public PortalBottomSheet(IBottomSheetService sheetService)
	{
		InitializeComponent();
		_sheetService = sheetService;
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<PortalBottomSheet>(this, typeof(PortalBottomSheet));
	}
}
