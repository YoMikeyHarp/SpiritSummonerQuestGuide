using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.BottomSheets;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.Views.BottomSheets;

[XamlFilePath("Presentation\\Views\\BottomSheets\\LinkAccountSheet.xaml")]
public class LinkAccountSheet : BottomSheet
{
	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string SheetId
	{
		[CompilerGenerated]
		get;
	}

	public LinkAccountSheet(LinkAccountSheetViewModel viewModel)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		Guid val = Guid.NewGuid();
		SheetId = ((object)(Guid)(ref val)).ToString();
		((BottomSheet)this)._002Ector();
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
		viewModel.Initialize((BottomSheet)(object)this, SheetId);
	}

	public void SetRegistrationMode(bool isRegistrationFlow)
	{
		((LinkAccountSheetViewModel)((BindableObject)this).BindingContext).SetRegistrationMode(isRegistrationFlow);
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<LinkAccountSheet>(this, typeof(LinkAccountSheet));
	}
}
