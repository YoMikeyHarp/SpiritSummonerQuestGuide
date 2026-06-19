using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Chat;

namespace SpiritSummoner.Presentation.Views.Chats;

[XamlFilePath("Presentation\\Views\\Chats\\DirectMessageView.xaml")]
public class DirectMessageView : ContentPage
{
	private DirectMessageViewModel? _viewModel;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private CollectionView MessagesCollectionView;

	public DirectMessageView(DirectMessageViewModel viewModel)
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
		_viewModel = ((BindableObject)this).BindingContext as DirectMessageViewModel;
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
			DirectMessageViewModel? viewModel = _viewModel;
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
		Extensions.LoadFromXaml<DirectMessageView>(this, typeof(DirectMessageView));
		MessagesCollectionView = NameScopeExtensions.FindByName<CollectionView>((Element)(object)this, "MessagesCollectionView");
	}
}
