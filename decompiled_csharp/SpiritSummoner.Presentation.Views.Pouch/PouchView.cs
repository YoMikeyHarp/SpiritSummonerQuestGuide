using System.CodeDom.Compiler;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Pouch;

namespace SpiritSummoner.Presentation.Views.Pouch;

[XamlFilePath("Presentation\\Views\\Pouch\\PouchView.xaml")]
public class PouchView : ContentPage
{
	public PouchView(PouchViewModel viewModel)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<PouchView>(this, typeof(PouchView));
	}
}
