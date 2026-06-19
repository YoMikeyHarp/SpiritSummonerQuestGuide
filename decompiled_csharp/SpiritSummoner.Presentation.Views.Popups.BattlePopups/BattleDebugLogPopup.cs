using System.CodeDom.Compiler;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Devices;
using Microsoft.Maui.Graphics;
using SpiritSummoner.Presentation.ViewModels.Popups;

namespace SpiritSummoner.Presentation.Views.Popups.BattlePopups;

[XamlFilePath("Presentation\\Views\\Popups\\BattlePopups\\BattleDebugLogPopup.xaml")]
public class BattleDebugLogPopup : Popup
{
	public BattleDebugLogPopup(BattleDebugLogPopupViewModel viewModel)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
		DisplayInfo mainDisplayInfo = DeviceDisplay.Current.MainDisplayInfo;
		double num = ((((DisplayInfo)(ref mainDisplayInfo)).Density <= 0.0) ? 1.0 : ((DisplayInfo)(ref mainDisplayInfo)).Density);
		double num2 = ((DisplayInfo)(ref mainDisplayInfo)).Width / num;
		double num3 = ((DisplayInfo)(ref mainDisplayInfo)).Height / num;
		((Popup)this).Size = new Size(num2 * 0.92, num3 * 0.85);
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<BattleDebugLogPopup>(this, typeof(BattleDebugLogPopup));
	}
}
