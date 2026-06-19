using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.Controls.SpiritControls;
using SpiritSummoner.Presentation.Services;
using SpiritSummoner.Presentation.ViewModels.Collections;

namespace SpiritSummoner.Presentation.Views.Collection;

[XamlFilePath("Presentation\\Views\\Collection\\FullCollectionNew.xaml")]
public class FullCollectionNew : ContentPage
{
	private readonly IPageCacheService _vmCache;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private ImageButton FilterIcon;

	public FullCollectionNew(IPageCacheService vmCache)
	{
		InitializeComponent();
		_vmCache = vmCache;
	}

	protected override void OnAppearing()
	{
		((Page)this).OnAppearing();
		if (((BindableObject)this).BindingContext is CollectionHubViewModel)
		{
			_vmCache.GetDeepVM<CollectionHubViewModel>("//collection")?.DisposeMessages();
		}
	}

	protected override void OnDisappearing()
	{
		((Page)this).OnDisappearing();
		SpiritVerticalCardCollectionView.RequestResetAll();
	}

	private void Partner_TouchGestureCompleted(object sender, TouchGestureCompletedEventArgs e)
	{
		if (((BindableObject)this).BindingContext is CollectionHubViewModel collectionHubViewModel)
		{
			collectionHubViewModel.NavigateToSpiritDetailsCommand.ExecuteAsync((object)collectionHubViewModel.PlayerInfoModel.PartnerSpiritId);
		}
	}

	private void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
	{
		SpiritVerticalCardCollectionView.RequestResetAll();
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	[MemberNotNull("FilterIcon")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<FullCollectionNew>(this, typeof(FullCollectionNew));
		FilterIcon = NameScopeExtensions.FindByName<ImageButton>((Element)(object)this, "FilterIcon");
	}
}
