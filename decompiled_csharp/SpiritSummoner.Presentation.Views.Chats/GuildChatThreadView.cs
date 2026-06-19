using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Chat;

namespace SpiritSummoner.Presentation.Views.Chats;

[XamlFilePath("Presentation\\Views\\Chats\\GuildChatThreadView.xaml")]
public class GuildChatThreadView : ContentPage
{
	private GuildChatThreadViewModel? _viewModel;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private CollectionView MessagesCollectionView;

	public GuildChatThreadView(GuildChatThreadViewModel viewModel)
	{
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
	}

	protected override void OnBindingContextChanged()
	{
		((ContentPage)this).OnBindingContextChanged();
		if (_viewModel != null)
		{
			_viewModel.OlderMessagesLoaded -= OnOlderMessagesLoaded;
		}
		_viewModel = ((BindableObject)this).BindingContext as GuildChatThreadViewModel;
		if (_viewModel != null)
		{
			_viewModel.OlderMessagesLoaded += OnOlderMessagesLoaded;
		}
	}

	protected override void OnAppearing()
	{
		((Page)this).OnAppearing();
		_viewModel?.ResumeListening();
	}

	protected override void OnDisappearing()
	{
		((Page)this).OnDisappearing();
		_viewModel?.StopListening();
	}

	private void OnOlderMessagesLoaded(int prependedCount)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		MainThread.BeginInvokeOnMainThread((Action)delegate
		{
			GuildChatThreadViewModel? viewModel = _viewModel;
			if (viewModel != null && ((Collection<ChatMessageModel>)(object)viewModel.Messages).Count > prependedCount)
			{
				((ItemsView)MessagesCollectionView).ScrollTo(prependedCount, -1, (ScrollToPosition)3, false);
			}
		});
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	[MemberNotNull("MessagesCollectionView")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<GuildChatThreadView>(this, typeof(GuildChatThreadView));
		MessagesCollectionView = NameScopeExtensions.FindByName<CollectionView>((Element)(object)this, "MessagesCollectionView");
	}
}
