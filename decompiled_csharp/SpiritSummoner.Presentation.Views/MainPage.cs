using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.StartUp;

namespace SpiritSummoner.Presentation.Views;

[XamlFilePath("Presentation\\Views\\Main\\MainPage.xaml")]
public class MainPage : ContentView
{
	private MainViewModel vm;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border TalentBorder;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border GearBorder;

	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
		vm = viewModel;
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	[MemberNotNull("TalentBorder")]
	[MemberNotNull("GearBorder")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<MainPage>(this, typeof(MainPage));
		TalentBorder = NameScopeExtensions.FindByName<Border>((Element)(object)this, "TalentBorder");
		GearBorder = NameScopeExtensions.FindByName<Border>((Element)(object)this, "GearBorder");
	}
}
