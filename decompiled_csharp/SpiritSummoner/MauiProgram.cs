using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Android.App;
using Android.Content;
using Android.OS;
using CommunityToolkit.Maui;
using Firebase;
using MauiIcons.Core;
using MauiIcons.FontAwesome.Solid;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.LifecycleEvents;
using Microsoft.Maui.Networking;
using Plugin.Firebase.Analytics;
using Plugin.Firebase.AppCheck;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Core.Platforms.Android;
using Plugin.Firebase.Crashlytics;
using Plugin.Firebase.Firestore;
using SkiaSharp.Views.Maui.Controls.Hosting;
using SpiritSummoner.Application.Configuration;
using SpiritSummoner.Domain.Configuration;
using SpiritSummoner.Infrastructure.Configuration;
using SpiritSummoner.Infrastructure.Contracts;
using SpiritSummoner.Infrastructure.Diagnostics;
using SpiritSummoner.Infrastructure.Services;
using SpiritSummoner.Presentation.Configuration;
using SpiritSummoner.Presentation.ViewModels.Shared;
using The49.Maui.BottomSheet;

namespace SpiritSummoner;

public static class MauiProgram
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Action<Options> _003C_003E9__0_0;

		public static Action<IFontCollection> _003C_003E9__0_1;

		public static Func<Activity> _003C_003E9__1_7;

		public static OnCreate _003C_003E9__1_6;

		public static Action<IAndroidLifecycleBuilder> _003C_003E9__1_5;

		public static Action<ILifecycleBuilder> _003C_003E9__1_0;

		public static Func<IServiceProvider, IFirebaseFirestore> _003C_003E9__1_1;

		public static Func<IServiceProvider, IFirebaseAuth> _003C_003E9__1_2;

		public static Func<IServiceProvider, IFirebaseCrashlytics> _003C_003E9__1_3;

		public static Func<IServiceProvider, IFirebaseAnalytics> _003C_003E9__1_4;

		internal void _003CCreateMauiApp_003Eb__0_0(Options x)
		{
			x.SetDefaultIconSize(30.0);
			x.SetDefaultFontOverride(true);
			x.SetDefaultIconAutoScaling(true);
		}

		internal void _003CCreateMauiApp_003Eb__0_1(IFontCollection fonts)
		{
			FontCollectionExtensions.AddFont(fonts, "OpenSans-Regular.ttf", "OpenSansRegular");
			FontCollectionExtensions.AddFont(fonts, "OpenSans-Semibold.ttf", "OpenSansSemibold");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-Regular.ttf", "Montserrat");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-Black.ttf", "MontserratBlack");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-BlackItalic.ttf", "MontserratBlackItalic");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-Bold.ttf", "MontserratBold");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-BoldItalic.ttf", "MontserratBoldItalic");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-ExtraBold.ttf", "MontserratExtraBold");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-ExtraBoldItalic.ttf", "MontserratExtraBoldItalic");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-ExtraLight.ttf", "MontserratExtraLight");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-ExtraLightItalic.ttf", "MontserratExtraLightItalic");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-Italic.ttf", "MontserratItalic");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-Light.ttf", "MontserratLight");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-LightItalic.ttf", "MontserratLightItalic");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-Medium.ttf", "MontserratMedium");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-MediumItalic.ttf", "MontserratMediumItalic");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-SemiBold.ttf", "MontserratSemiBold");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-SemiBoldItalic.ttf", "MontserratSemiBoldItalic");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-Thin.ttf", "MontserratThin");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-ThinItalic.ttf", "MontserratThinItalic");
			FontCollectionExtensions.AddFont(fonts, "Poppins-Regular.ttf", "Poppins");
			FontCollectionExtensions.AddFont(fonts, "Poppins-Black.ttf", "PoppinsBlack");
			FontCollectionExtensions.AddFont(fonts, "Poppins-BlackItalic.ttf", "PoppinsBlackItalic");
			FontCollectionExtensions.AddFont(fonts, "Poppins-Bold.ttf", "PoppinsBold");
			FontCollectionExtensions.AddFont(fonts, "Poppins-BoldItalic.ttf", "PoppinsBoldItalic");
			FontCollectionExtensions.AddFont(fonts, "Poppins-ExtraBold.ttf", "PoppinsExtraBold");
			FontCollectionExtensions.AddFont(fonts, "Poppins-ExtraBoldItalic.ttf", "PoppinsExtraBoldItalic");
			FontCollectionExtensions.AddFont(fonts, "Poppins-ExtraLight.ttf", "PoppinsExtraLight");
			FontCollectionExtensions.AddFont(fonts, "Poppins-ExtraLightItalic.ttf", "PoppinsExtraLightItalic");
			FontCollectionExtensions.AddFont(fonts, "Poppins-Italic.ttf", "PoppinsItalic");
			FontCollectionExtensions.AddFont(fonts, "Poppins-Light.ttf", "PoppinsLight");
			FontCollectionExtensions.AddFont(fonts, "Poppins-LightItalic.ttf", "PoppinsLightItalic");
			FontCollectionExtensions.AddFont(fonts, "Poppins-Medium.ttf", "PoppinsMedium");
			FontCollectionExtensions.AddFont(fonts, "Poppins-MediumItalic.ttf", "PoppinsMediumItalic");
			FontCollectionExtensions.AddFont(fonts, "Poppins-SemiBold.ttf", "PoppinsSemiBold");
			FontCollectionExtensions.AddFont(fonts, "Poppins-SemiBoldItalic.ttf", "PoppinsSemiBoldItalic");
			FontCollectionExtensions.AddFont(fonts, "Poppins-Thin.ttf", "PoppinsThin");
			FontCollectionExtensions.AddFont(fonts, "Poppins-ThinItalic.ttf", "PoppinsThinItalic");
			FontCollectionExtensions.AddFont(fonts, "Bungee-Regular.ttf", "Bungee");
			FontCollectionExtensions.AddFont(fonts, "SelfDeceptionRegular-ALLWA.ttf", "SelfDeception");
			FontCollectionExtensions.AddFont(fonts, "Italianno-Regular.ttf", "Italiano");
		}

		internal void _003CRegisterFirebaseServices_003Eb__1_0(ILifecycleBuilder events)
		{
			AndroidLifecycleExtensions.AddAndroid(events, (Action<IAndroidLifecycleBuilder>)delegate(IAndroidLifecycleBuilder android)
			{
				//IL_0015: Unknown result type (might be due to invalid IL or missing references)
				//IL_001a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0020: Expected O, but got Unknown
				object obj = _003C_003E9__1_6;
				if (obj == null)
				{
					OnCreate val = delegate(Activity activity, Bundle? _)
					{
						CrossFirebaseAppCheck.Configure(AppCheckOptions.Debug);
						CrossFirebase.Initialize(activity, (Func<Activity>)(() => Platform.CurrentActivity), (FirebaseOptions)null, (string)null);
						CrossFirebaseCrashlytics.Current.SetCrashlyticsCollectionEnabled(true);
						FirebaseAnalyticsImplementation.Initialize((Context)(object)activity);
					};
					_003C_003E9__1_6 = val;
					obj = (object)val;
				}
				AndroidLifecycleBuilderExtensions.OnCreate(android, (OnCreate)obj);
			});
		}

		internal void _003CRegisterFirebaseServices_003Eb__1_5(IAndroidLifecycleBuilder android)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Expected O, but got Unknown
			object obj = _003C_003E9__1_6;
			if (obj == null)
			{
				OnCreate val = delegate(Activity activity, Bundle? _)
				{
					CrossFirebaseAppCheck.Configure(AppCheckOptions.Debug);
					CrossFirebase.Initialize(activity, (Func<Activity>)(() => Platform.CurrentActivity), (FirebaseOptions)null, (string)null);
					CrossFirebaseCrashlytics.Current.SetCrashlyticsCollectionEnabled(true);
					FirebaseAnalyticsImplementation.Initialize((Context)(object)activity);
				};
				_003C_003E9__1_6 = val;
				obj = (object)val;
			}
			AndroidLifecycleBuilderExtensions.OnCreate(android, (OnCreate)obj);
		}

		internal void _003CRegisterFirebaseServices_003Eb__1_6(Activity activity, Bundle? _)
		{
			CrossFirebaseAppCheck.Configure(AppCheckOptions.Debug);
			CrossFirebase.Initialize(activity, (Func<Activity>)(() => Platform.CurrentActivity), (FirebaseOptions)null, (string)null);
			CrossFirebaseCrashlytics.Current.SetCrashlyticsCollectionEnabled(true);
			FirebaseAnalyticsImplementation.Initialize((Context)(object)activity);
		}

		internal Activity _003CRegisterFirebaseServices_003Eb__1_7()
		{
			return Platform.CurrentActivity;
		}

		internal IFirebaseFirestore _003CRegisterFirebaseServices_003Eb__1_1(IServiceProvider _)
		{
			return CrossFirebaseFirestore.Current;
		}

		internal IFirebaseAuth _003CRegisterFirebaseServices_003Eb__1_2(IServiceProvider _)
		{
			return CrossFirebaseAuth.Current;
		}

		internal IFirebaseCrashlytics _003CRegisterFirebaseServices_003Eb__1_3(IServiceProvider _)
		{
			return CrossFirebaseCrashlytics.Current;
		}

		internal IFirebaseAnalytics _003CRegisterFirebaseServices_003Eb__1_4(IServiceProvider _)
		{
			return CrossFirebaseAnalytics.Current;
		}
	}

	public static MauiApp CreateMauiApp()
	{
		MauiAppBuilder val = MauiApp.CreateBuilder(true);
		FontsMauiAppBuilderExtensions.ConfigureFonts(BuilderExtension.UseMauiIconsCore(MauiAppBuilderExtensions.UseBottomSheet(AppHostBuilderExtensions.UseSkiaSharp(AppBuilderExtensions.UseMauiCommunityToolkit(BuilderExtensions.UseFontAwesomeSolidMauiIcons(AppHostBuilderExtensions.UseMauiApp<App>(val).RegisterFirebaseServices()), (Action<Options>)null))), (Action<Options>)delegate(Options x)
		{
			x.SetDefaultIconSize(30.0);
			x.SetDefaultFontOverride(true);
			x.SetDefaultIconAutoScaling(true);
		}), (Action<IFontCollection>)delegate(IFontCollection fonts)
		{
			FontCollectionExtensions.AddFont(fonts, "OpenSans-Regular.ttf", "OpenSansRegular");
			FontCollectionExtensions.AddFont(fonts, "OpenSans-Semibold.ttf", "OpenSansSemibold");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-Regular.ttf", "Montserrat");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-Black.ttf", "MontserratBlack");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-BlackItalic.ttf", "MontserratBlackItalic");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-Bold.ttf", "MontserratBold");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-BoldItalic.ttf", "MontserratBoldItalic");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-ExtraBold.ttf", "MontserratExtraBold");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-ExtraBoldItalic.ttf", "MontserratExtraBoldItalic");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-ExtraLight.ttf", "MontserratExtraLight");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-ExtraLightItalic.ttf", "MontserratExtraLightItalic");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-Italic.ttf", "MontserratItalic");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-Light.ttf", "MontserratLight");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-LightItalic.ttf", "MontserratLightItalic");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-Medium.ttf", "MontserratMedium");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-MediumItalic.ttf", "MontserratMediumItalic");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-SemiBold.ttf", "MontserratSemiBold");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-SemiBoldItalic.ttf", "MontserratSemiBoldItalic");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-Thin.ttf", "MontserratThin");
			FontCollectionExtensions.AddFont(fonts, "Montserrat-ThinItalic.ttf", "MontserratThinItalic");
			FontCollectionExtensions.AddFont(fonts, "Poppins-Regular.ttf", "Poppins");
			FontCollectionExtensions.AddFont(fonts, "Poppins-Black.ttf", "PoppinsBlack");
			FontCollectionExtensions.AddFont(fonts, "Poppins-BlackItalic.ttf", "PoppinsBlackItalic");
			FontCollectionExtensions.AddFont(fonts, "Poppins-Bold.ttf", "PoppinsBold");
			FontCollectionExtensions.AddFont(fonts, "Poppins-BoldItalic.ttf", "PoppinsBoldItalic");
			FontCollectionExtensions.AddFont(fonts, "Poppins-ExtraBold.ttf", "PoppinsExtraBold");
			FontCollectionExtensions.AddFont(fonts, "Poppins-ExtraBoldItalic.ttf", "PoppinsExtraBoldItalic");
			FontCollectionExtensions.AddFont(fonts, "Poppins-ExtraLight.ttf", "PoppinsExtraLight");
			FontCollectionExtensions.AddFont(fonts, "Poppins-ExtraLightItalic.ttf", "PoppinsExtraLightItalic");
			FontCollectionExtensions.AddFont(fonts, "Poppins-Italic.ttf", "PoppinsItalic");
			FontCollectionExtensions.AddFont(fonts, "Poppins-Light.ttf", "PoppinsLight");
			FontCollectionExtensions.AddFont(fonts, "Poppins-LightItalic.ttf", "PoppinsLightItalic");
			FontCollectionExtensions.AddFont(fonts, "Poppins-Medium.ttf", "PoppinsMedium");
			FontCollectionExtensions.AddFont(fonts, "Poppins-MediumItalic.ttf", "PoppinsMediumItalic");
			FontCollectionExtensions.AddFont(fonts, "Poppins-SemiBold.ttf", "PoppinsSemiBold");
			FontCollectionExtensions.AddFont(fonts, "Poppins-SemiBoldItalic.ttf", "PoppinsSemiBoldItalic");
			FontCollectionExtensions.AddFont(fonts, "Poppins-Thin.ttf", "PoppinsThin");
			FontCollectionExtensions.AddFont(fonts, "Poppins-ThinItalic.ttf", "PoppinsThinItalic");
			FontCollectionExtensions.AddFont(fonts, "Bungee-Regular.ttf", "Bungee");
			FontCollectionExtensions.AddFont(fonts, "SelfDeceptionRegular-ALLWA.ttf", "SelfDeception");
			FontCollectionExtensions.AddFont(fonts, "Italianno-Regular.ttf", "Italiano");
		});
		FontManagerCustom.Initialize();
		DebugLoggerFactoryExtensions.AddDebug(val.Logging);
		if (!Trace.Listeners.Contains((TraceListener)(object)BattleLogCapture.Instance))
		{
			Trace.Listeners.Add((TraceListener)(object)BattleLogCapture.Instance);
		}
		IServiceCollection services = val.Services;
		RegisterServices(in services);
		return val.Build();
	}

	private static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
	{
		MauiAppHostBuilderExtensions.ConfigureLifecycleEvents(builder, (Action<ILifecycleBuilder>)delegate(ILifecycleBuilder events)
		{
			AndroidLifecycleExtensions.AddAndroid(events, (Action<IAndroidLifecycleBuilder>)delegate(IAndroidLifecycleBuilder android)
			{
				//IL_0015: Unknown result type (might be due to invalid IL or missing references)
				//IL_001a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0020: Expected O, but got Unknown
				object obj = _003C_003Ec._003C_003E9__1_6;
				if (obj == null)
				{
					OnCreate val = delegate(Activity activity, Bundle? _)
					{
						CrossFirebaseAppCheck.Configure(AppCheckOptions.Debug);
						CrossFirebase.Initialize(activity, (Func<Activity>)(() => Platform.CurrentActivity), (FirebaseOptions)null, (string)null);
						CrossFirebaseCrashlytics.Current.SetCrashlyticsCollectionEnabled(true);
						FirebaseAnalyticsImplementation.Initialize((Context)(object)activity);
					};
					_003C_003Ec._003C_003E9__1_6 = val;
					obj = (object)val;
				}
				AndroidLifecycleBuilderExtensions.OnCreate(android, (OnCreate)obj);
			});
		});
		ServiceCollectionServiceExtensions.AddSingleton<IFirebaseFirestore>(builder.Services, (Func<IServiceProvider, IFirebaseFirestore>)((IServiceProvider _) => CrossFirebaseFirestore.Current));
		ServiceCollectionServiceExtensions.AddSingleton<IFirebaseAuth>(builder.Services, (Func<IServiceProvider, IFirebaseAuth>)((IServiceProvider _) => CrossFirebaseAuth.Current));
		ServiceCollectionServiceExtensions.AddSingleton<IFirebaseCrashlytics>(builder.Services, (Func<IServiceProvider, IFirebaseCrashlytics>)((IServiceProvider _) => CrossFirebaseCrashlytics.Current));
		ServiceCollectionServiceExtensions.AddSingleton<IFirebaseAnalytics>(builder.Services, (Func<IServiceProvider, IFirebaseAnalytics>)((IServiceProvider _) => CrossFirebaseAnalytics.Current));
		return builder;
	}

	private static void RegisterServices(in IServiceCollection services)
	{
		services.AddDomainServices();
		services.AddApplicationServices();
		services.AddInfrastructureServices();
		services.AddPresentationServices();
		ServiceCollectionServiceExtensions.AddTransient<AppShell>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IAuthService, AuthService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<QuestParagraphService>(services);
		ServiceCollectionServiceExtensions.AddSingleton<IConnectivity>(services, Connectivity.Current);
	}
}
