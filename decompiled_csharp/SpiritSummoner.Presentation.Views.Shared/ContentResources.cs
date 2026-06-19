using System.CodeDom.Compiler;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace SpiritSummoner.Presentation.Views.Shared;

[XamlFilePath("Presentation\\Views\\Shared\\ContentResources.xaml")]
public class ContentResources : ResourceDictionary
{
	public ContentResources()
	{
		InitializeComponent();
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<ContentResources>(this, typeof(ContentResources));
	}
}
