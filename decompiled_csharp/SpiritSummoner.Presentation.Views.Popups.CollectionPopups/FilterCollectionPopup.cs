using System.CodeDom.Compiler;
using System.ComponentModel;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Popups;

namespace SpiritSummoner.Presentation.Views.Popups.CollectionPopups;

[XamlFilePath("Presentation\\Views\\Popups\\CollectionPopups\\FilterCollectionPopup.xaml")]
public class FilterCollectionPopup : Popup
{
	public FilterCollectionPopup(FilterCollectionPopupViewModel viewModel)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		FilterCollectionPopupViewModel viewModel2 = viewModel;
		((Popup)this)._002Ector();
		FilterCollectionPopup filterCollectionPopup = this;
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel2;
		((ObservableObject)viewModel2).PropertyChanged += (PropertyChangedEventHandler)delegate(object? _, PropertyChangedEventArgs args)
		{
			if (args.PropertyName == "Anchor")
			{
				((Popup)filterCollectionPopup).Anchor = viewModel2.Anchor;
			}
		};
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<FilterCollectionPopup>(this, typeof(FilterCollectionPopup));
	}
}
