using System.CodeDom.Compiler;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.StartUp;

namespace SpiritSummoner.Presentation.Views;

[XamlFilePath("Presentation\\Views\\Startup\\LoadingPage.xaml")]
public class LoadingPage : ContentPage
{
	public LoadingPage(LoadingViewModel viewModel)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
	}

	protected override void OnAppearing()
	{
		((Page)this).OnAppearing();
		if (((BindableObject)this).BindingContext is LoadingViewModel loadingViewModel)
		{
			loadingViewModel.LoadAsync();
		}
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<LoadingPage>(this, typeof(LoadingPage));
	}
}
