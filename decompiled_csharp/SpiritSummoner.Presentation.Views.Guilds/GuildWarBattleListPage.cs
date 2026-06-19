using System.CodeDom.Compiler;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Guilds;

namespace SpiritSummoner.Presentation.Views.Guilds;

[XamlFilePath("Presentation\\Views\\Guilds\\GuildWarBattleListPage.xaml")]
public class GuildWarBattleListPage : ContentPage
{
	public GuildWarBattleListPage(GuildWarsViewModel vm)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = vm;
	}

	private void TouchBehavior_TouchGestureCompleted(object sender, TouchGestureCompletedEventArgs e)
	{
		Border val = (Border)((sender is Border) ? sender : null);
		if (val != null && ((BindableObject)val).BindingContext is GuildWarTargetModel guildWarTargetModel && ((BindableObject)this).BindingContext is GuildWarsViewModel guildWarsViewModel)
		{
			guildWarsViewModel?.AttackGuildCommand.ExecuteAsync(guildWarTargetModel);
		}
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<GuildWarBattleListPage>(this, typeof(GuildWarBattleListPage));
	}
}
