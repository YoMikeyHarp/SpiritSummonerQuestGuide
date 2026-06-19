using System.CodeDom.Compiler;
using Microsoft.Maui.Controls.Xaml;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.Views.BottomSheets.ChatSheets;

[XamlFilePath("Presentation\\Views\\BottomSheets\\ChatSheets\\NewGuildThreadBottomSheet.xaml")]
public class NewGuildThreadBottomSheet : BottomSheet
{
	public NewGuildThreadBottomSheet()
	{
		InitializeComponent();
	}

	private void BottomSheet_Dismissed(object sender, DismissOrigin e)
	{
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<NewGuildThreadBottomSheet>(this, typeof(NewGuildThreadBottomSheet));
	}
}
