using System.CodeDom.Compiler;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace SpiritSummoner.Presentation.Views.Spirits;

[XamlFilePath("Presentation\\Views\\Spirits\\EvolveRequirementsPage.xaml")]
public class EvolveRequirementsPage : ContentPage
{
	public EvolveRequirementsPage()
	{
		InitializeComponent();
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<EvolveRequirementsPage>(this, typeof(EvolveRequirementsPage));
	}
}
