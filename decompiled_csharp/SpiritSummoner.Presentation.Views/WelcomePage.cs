using System;
using System.CodeDom.Compiler;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.StartUp;

namespace SpiritSummoner.Presentation.Views;

[XamlFilePath("Presentation\\Views\\Startup\\WelcomePage.xaml")]
public class WelcomePage : ContentPage
{
	public WelcomePage(WelcomeViewModel viewModel)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
	}

	protected override void OnAppearing()
	{
		((Page)this).OnAppearing();
		Console.WriteLine("Testing welcome appearing");
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<WelcomePage>(this, typeof(WelcomePage));
	}
}
