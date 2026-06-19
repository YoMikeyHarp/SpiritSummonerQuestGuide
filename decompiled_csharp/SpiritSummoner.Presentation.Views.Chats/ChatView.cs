using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Chat;

namespace SpiritSummoner.Presentation.Views.Chats;

[XamlFilePath("Presentation\\Views\\Chats\\ChatView.xaml")]
public class ChatView : ContentPage
{
	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Grid masterGrid;

	public ChatView()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		((Page)this).OnAppearing();
		if (((BindableObject)this).BindingContext is ChatViewModel)
		{
			((BindableObject)this).OnPropertyChanged("PartnerSpiritImage");
		}
	}

	private void OnFriendFightTapped(object sender, TouchGestureCompletedEventArgs e)
	{
		if (((BindableObject)this).BindingContext is ChatViewModel chatViewModel)
		{
			Border val = (Border)((sender is Border) ? sender : null);
			if (val != null && ((BindableObject)val).BindingContext is ChatPlayerModel chatPlayerModel)
			{
				chatViewModel.FightCommand.ExecuteAsync(chatPlayerModel);
			}
		}
	}

	private void PartnerTapped(object sender, TouchGestureCompletedEventArgs e)
	{
		if (((BindableObject)this).BindingContext is ChatViewModel chatViewModel)
		{
			chatViewModel?.NavigateToSpiritDetailsCommand.ExecuteAsync(chatViewModel.PartnerSpiritModel.PlayerSpiritId);
		}
	}

	private void ParnterLongPress(object sender, LongPressCompletedEventArgs e)
	{
		if (((BindableObject)this).BindingContext is ChatViewModel chatViewModel && chatViewModel != null)
		{
			chatViewModel.OpenSpiritsHoldNavigationCommand.ExecuteAsync((object)null);
		}
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	[MemberNotNull("masterGrid")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<ChatView>(this, typeof(ChatView));
		masterGrid = NameScopeExtensions.FindByName<Grid>((Element)(object)this, "masterGrid");
	}
}
