using System.CodeDom.Compiler;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace SpiritSummoner.Presentation.Views.Onboarding;

[XamlFilePath("Presentation\\Views\\Onboarding\\OnboardingDialoguePage.xaml")]
public class OnboardingDialoguePage : ContentPage
{
	public OnboardingDialoguePage()
	{
		InitializeComponent();
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<OnboardingDialoguePage>(this, typeof(OnboardingDialoguePage));
	}
}
