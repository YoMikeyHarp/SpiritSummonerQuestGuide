using System.CodeDom.Compiler;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace SpiritSummoner.Presentation.Views.Shared;

[XamlFilePath("Presentation\\Views\\Shared\\PlayerInfoBar.xaml")]
public class PlayerInfoBar : ContentView
{
	public PlayerInfoBar()
	{
		InitializeComponent();
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<PlayerInfoBar>(this, typeof(PlayerInfoBar));
	}
}
