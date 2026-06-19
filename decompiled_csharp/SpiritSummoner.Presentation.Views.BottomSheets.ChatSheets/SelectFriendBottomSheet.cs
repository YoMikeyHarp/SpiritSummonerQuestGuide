using System.CodeDom.Compiler;
using Microsoft.Maui.Controls.Xaml;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.Views.BottomSheets.ChatSheets;

[XamlFilePath("Presentation\\Views\\BottomSheets\\ChatSheets\\SelectFriendBottomSheet.xaml")]
public class SelectFriendBottomSheet : BottomSheet
{
	public SelectFriendBottomSheet()
	{
		InitializeComponent();
	}

	private void BottomSheet_Dismissed(object sender, DismissOrigin e)
	{
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<SelectFriendBottomSheet>(this, typeof(SelectFriendBottomSheet));
	}
}
