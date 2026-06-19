using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.BottomSheets;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.Views.BottomSheets;

[XamlFilePath("Presentation\\Views\\BottomSheets\\ConfirmUserNameSheet.xaml")]
public class ConfirmUserNameSheet : BottomSheet
{
	private readonly ConfirmUserNameSheetViewModel _viewModel;

	[field: CompilerGenerated]
	[field: DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	public string SheetId
	{
		[CompilerGenerated]
		get;
	}

	public ConfirmUserNameSheet(ConfirmUserNameSheetViewModel viewModel)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		Guid val = Guid.NewGuid();
		SheetId = ((object)(Guid)(ref val)).ToString();
		((BottomSheet)this)._002Ector();
		InitializeComponent();
		_viewModel = viewModel;
		((BindableObject)this).BindingContext = viewModel;
	}

	public void Initialize(string userName)
	{
		_viewModel.Initialize((BottomSheet)(object)this, SheetId, userName);
	}

	private void Confirm_TouchGestureCompleted(object sender, TouchGestureCompletedEventArgs e)
	{
		if (((BindableObject)this).BindingContext is ConfirmUserNameSheetViewModel confirmUserNameSheetViewModel)
		{
			confirmUserNameSheetViewModel.ConfirmCommand.ExecuteAsync((object)null);
		}
	}

	private void Cancel_TouchGestureCompleted1(object sender, TouchGestureCompletedEventArgs e)
	{
		if (((BindableObject)this).BindingContext is ConfirmUserNameSheetViewModel confirmUserNameSheetViewModel)
		{
			confirmUserNameSheetViewModel.CancelCommand.ExecuteAsync((object)null);
		}
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<ConfirmUserNameSheet>(this, typeof(ConfirmUserNameSheet));
	}
}
