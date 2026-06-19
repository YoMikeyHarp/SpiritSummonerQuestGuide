using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Quests;

namespace SpiritSummoner.Presentation.Views.Quests;

[XamlFilePath("Presentation\\Views\\Quests\\QuestView.xaml")]
public class QuestView : ContentView
{
	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border test;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private CollectionView AreasCollectionView;

	public QuestView(QuestViewModel viewModel)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	[MemberNotNull("test")]
	[MemberNotNull("AreasCollectionView")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<QuestView>(this, typeof(QuestView));
		test = NameScopeExtensions.FindByName<Border>((Element)(object)this, "test");
		AreasCollectionView = NameScopeExtensions.FindByName<CollectionView>((Element)(object)this, "AreasCollectionView");
	}
}
