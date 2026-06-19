using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Spirits;

namespace SpiritSummoner.Presentation.Controls.SpiritControls;

[XamlFilePath("Presentation\\Controls\\SpiritControls\\SpiritVerticalCardView.xaml")]
public class SpiritVerticalCardView : ContentView
{
	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Grid SpiritCard;

	public SpiritVerticalCardView(SpiritCardViewModel viewModel)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
		ViewExtensions.ScaleTo((VisualElement)(object)this, 1.05, 100u, Easing.BounceOut);
	}

	public SpiritVerticalCardView()
	{
		InitializeComponent();
		ViewExtensions.ScaleTo((VisualElement)(object)this, 1.05, 100u, Easing.BounceOut);
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	[MemberNotNull("SpiritCard")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<SpiritVerticalCardView>(this, typeof(SpiritVerticalCardView));
		SpiritCard = NameScopeExtensions.FindByName<Grid>((Element)(object)this, "SpiritCard");
	}
}
