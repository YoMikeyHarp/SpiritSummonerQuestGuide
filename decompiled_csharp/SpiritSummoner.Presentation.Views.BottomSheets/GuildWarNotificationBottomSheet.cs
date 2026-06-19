using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.BottomSheets;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.Views.BottomSheets;

[XamlFilePath("Presentation\\Views\\BottomSheets\\GuildWarNotificationBottomSheet.xaml")]
public class GuildWarNotificationBottomSheet : BottomSheet
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public GuildWarNotificationViewModel ViewModel
	{
		[CompilerGenerated]
		get;
	}

	public GuildWarNotificationBottomSheet(GuildWarNotificationViewModel viewModel)
	{
		InitializeComponent();
		ViewModel = viewModel;
		ViewModel.SetSheet((BottomSheet)(object)this);
		((BindableObject)this).BindingContext = ViewModel;
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<GuildWarNotificationBottomSheet>(this, typeof(GuildWarNotificationBottomSheet));
	}
}
