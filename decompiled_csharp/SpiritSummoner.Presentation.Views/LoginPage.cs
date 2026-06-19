using System.CodeDom.Compiler;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Graphics;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Presentation.ViewModels.StartUp;

namespace SpiritSummoner.Presentation.Views;

[XamlFilePath("Presentation\\Views\\Startup\\LoginPage.xaml")]
public class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel viewModel)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
		Page.SetUseSafeArea(((Page)this).On<iOS>(), true);
		Application.Current.Resources["AppBackgroundColor"] = Color.FromArgb("#7CCB59");
	}

	protected override void OnAppearing()
	{
		((Page)this).OnAppearing();
		if (((BindableObject)this).BindingContext is ILoadableViewModel loadableViewModel)
		{
			loadableViewModel.LoadDataAsync(null);
		}
	}

	protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
	{
		((Page)this).OnNavigatedFrom(args);
		LoginViewModel loginViewModel = ((BindableObject)this).BindingContext as LoginViewModel;
		if (loginViewModel == null)
		{
		}
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<LoginPage>(this, typeof(LoginPage));
	}
}
