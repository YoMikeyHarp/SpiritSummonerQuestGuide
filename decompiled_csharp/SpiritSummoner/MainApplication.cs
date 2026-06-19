using System;
using Android.App;
using Android.Runtime;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace SpiritSummoner;

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(nint handle, JniHandleOwnership ownership)
		: base((global::System.IntPtr)handle, ownership)
	{
	}//IL_0002: Unknown result type (might be due to invalid IL or missing references)


	protected override MauiApp CreateMauiApp()
	{
		return MauiProgram.CreateMauiApp();
	}
}
