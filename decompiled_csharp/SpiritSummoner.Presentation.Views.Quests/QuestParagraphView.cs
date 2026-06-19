using System.CodeDom.Compiler;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Quests;

namespace SpiritSummoner.Presentation.Views.Quests;

[XamlFilePath("Presentation\\Views\\Quests\\QuestParagraphView.xaml")]
public class QuestParagraphView : ContentPage
{
	public QuestParagraphView(QuestParagraphViewModel viewModel)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<QuestParagraphView>(this, typeof(QuestParagraphView));
	}
}
