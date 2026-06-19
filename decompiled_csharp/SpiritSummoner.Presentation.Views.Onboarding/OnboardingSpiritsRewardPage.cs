using System.CodeDom.Compiler;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace SpiritSummoner.Presentation.Views.Onboarding;

[XamlFilePath("Presentation\\Views\\Onboarding\\OnboardingSpiritsRewardPage.xaml")]
public class OnboardingSpiritsRewardPage : ContentPage
{
	public OnboardingSpiritsRewardPage()
	{
		InitializeComponent();
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<OnboardingSpiritsRewardPage>(this, typeof(OnboardingSpiritsRewardPage));
	}
}
