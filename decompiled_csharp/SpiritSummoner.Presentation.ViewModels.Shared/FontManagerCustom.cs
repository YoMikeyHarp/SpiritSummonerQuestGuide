using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Android.App;
using Android.Content.Res;
using Microsoft.Maui.Storage;
using SkiaSharp;

namespace SpiritSummoner.Presentation.ViewModels.Shared;

public static class FontManagerCustom
{
	private static readonly Dictionary<string, SKTypeface> _typefaceCache = new Dictionary<string, SKTypeface>();

	private static readonly Dictionary<string, string> _fontAliases = new Dictionary<string, string>();

	public static void RegisterFontAlias(string fontFileName, string alias)
	{
		_fontAliases[alias] = fontFileName;
		_fontAliases[alias.ToLowerInvariant()] = fontFileName;
	}

	public static void Initialize()
	{
		RegisterFontAlias("OpenSans-Regular.ttf", "OpenSansRegular");
		RegisterFontAlias("OpenSans-Semibold.ttf", "OpenSansSemibold");
		RegisterFontAlias("Montserrat-Regular.ttf", "Montserrat");
		RegisterFontAlias("Montserrat-Black.ttf", "MontserratBlack");
		RegisterFontAlias("Montserrat-BlackItalic.ttf", "MontserratBlackItalic");
		RegisterFontAlias("Montserrat-Bold.ttf", "MontserratBold");
		RegisterFontAlias("Montserrat-BoldItalic.ttf", "MontserratBoldItalic");
		RegisterFontAlias("Montserrat-ExtraBold.ttf", "MontserratExtraBold");
		RegisterFontAlias("Montserrat-ExtraBoldItalic.ttf", "MontserratExtraBoldItalic");
		RegisterFontAlias("Montserrat-ExtraLight.ttf", "MontserratExtraLight");
		RegisterFontAlias("Montserrat-ExtraLightItalic.ttf", "MontserratExtraLightItalic");
		RegisterFontAlias("Montserrat-Italic.ttf", "MontserratItalic");
		RegisterFontAlias("Montserrat-Light.ttf", "MontserratLight");
		RegisterFontAlias("Montserrat-LightItalic.ttf", "MontserratLightItalic");
		RegisterFontAlias("Montserrat-Medium.ttf", "MontserratMedium");
		RegisterFontAlias("Montserrat-MediumItalic.ttf", "MontserratMediumItalic");
		RegisterFontAlias("Montserrat-SemiBold.ttf", "MontserratSemiBold");
		RegisterFontAlias("Montserrat-SemiBoldItalic.ttf", "MontserratSemiBoldItalic");
		RegisterFontAlias("Montserrat-Thin.ttf", "MontserratThin");
		RegisterFontAlias("Montserrat-ThinItalic.ttf", "MontserratThinItalic");
		RegisterFontAlias("Poppins-Regular.ttf", "Poppins");
		RegisterFontAlias("Poppins-Black.ttf", "PoppinsBlack");
		RegisterFontAlias("Poppins-BlackItalic.ttf", "PoppinsBlackItalic");
		RegisterFontAlias("Poppins-Bold.ttf", "PoppinsBold");
		RegisterFontAlias("Poppins-BoldItalic.ttf", "PoppinsBoldItalic");
		RegisterFontAlias("Poppins-ExtraBold.ttf", "PoppinsExtraBold");
		RegisterFontAlias("Poppins-ExtraBoldItalic.ttf", "PoppinsExtraBoldItalic");
		RegisterFontAlias("Poppins-ExtraLight.ttf", "PoppinsExtraLight");
		RegisterFontAlias("Poppins-ExtraLightItalic.ttf", "PoppinsExtraLightItalic");
		RegisterFontAlias("Poppins-Italic.ttf", "PoppinsItalic");
		RegisterFontAlias("Poppins-Light.ttf", "PoppinsLight");
		RegisterFontAlias("Poppins-LightItalic.ttf", "PoppinsLightItalic");
		RegisterFontAlias("Poppins-Medium.ttf", "PoppinsMedium");
		RegisterFontAlias("Poppins-MediumItalic.ttf", "PoppinsMediumItalic");
		RegisterFontAlias("Poppins-SemiBold.ttf", "PoppinsSemiBold");
		RegisterFontAlias("Poppins-SemiBoldItalic.ttf", "PoppinsSemiBoldItalic");
		RegisterFontAlias("Poppins-Thin.ttf", "PoppinsThin");
		RegisterFontAlias("Poppins-ThinItalic.ttf", "PoppinsThinItalic");
		RegisterFontAlias("Bungee-Regular.ttf", "Bungee");
		RegisterFontAlias("SelfDeceptionRegular-ALLWA.ttf", "SelfDeception");
		RegisterFontAlias("Italianno-Regular.ttf", "Italiano");
		RegisterFontAlias("SomeTypeMono-Bold.ttf", "SomeTypeMonoBold");
	}

	public static SKTypeface? GetTypeface(string fontFamilyOrAlias)
	{
		if (string.IsNullOrWhiteSpace(fontFamilyOrAlias))
		{
			return null;
		}
		SKTypeface result = default(SKTypeface);
		if (_typefaceCache.TryGetValue(fontFamilyOrAlias, ref result))
		{
			return result;
		}
		SKTypeface val = null;
		string fontFileName = default(string);
		if (_fontAliases.TryGetValue(fontFamilyOrAlias, ref fontFileName) || _fontAliases.TryGetValue(fontFamilyOrAlias.ToLowerInvariant(), ref fontFileName))
		{
			val = LoadTypefaceFromResource(fontFileName);
		}
		if (val == null)
		{
			string[] array = new string[3]
			{
				fontFamilyOrAlias + ".ttf",
				fontFamilyOrAlias + "-Regular.ttf",
				fontFamilyOrAlias + "Regular.ttf"
			};
			string[] array2 = array;
			foreach (string fontFileName2 in array2)
			{
				val = LoadTypefaceFromResource(fontFileName2);
				if (val != null)
				{
					break;
				}
			}
		}
		if (val != null)
		{
			_typefaceCache[fontFamilyOrAlias] = val;
		}
		return val;
	}

	[Obsolete("Use GetTypeface(string fontFamilyOrAlias) and pass the complete font alias like 'PoppinsBold' instead")]
	public static SKTypeface? GetTypeface(string fontFamily, SKFontStyleWeight weight, SKFontStyleSlant slant)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Invalid comparison between Unknown and I4
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Invalid comparison between Unknown and I4
		if ((int)weight == 700 && (int)slant == 1)
		{
			return GetTypeface(fontFamily + "BoldItalic") ?? GetTypeface(fontFamily + "-BoldItalic");
		}
		if ((int)weight == 700)
		{
			return GetTypeface(fontFamily + "Bold") ?? GetTypeface(fontFamily + "-Bold");
		}
		if ((int)slant == 1)
		{
			return GetTypeface(fontFamily + "Italic") ?? GetTypeface(fontFamily + "-Italic");
		}
		return GetTypeface(fontFamily);
	}

	private static SKTypeface? LoadTypefaceFromResource(string fontFileName)
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		string fontFileName2 = fontFileName;
		try
		{
			Debug.WriteLine("[FontManager] Attempting to load font: " + fontFileName2);
			try
			{
				AssetManager assets = Application.Context.Assets;
				if (assets != null)
				{
					Stream val = assets.Open(fontFileName2);
					try
					{
						if (val != null)
						{
							Debug.WriteLine("[FontManager] ✓ Loaded '" + fontFileName2 + "' from Android assets");
							MemoryStream val2 = new MemoryStream();
							try
							{
								val.CopyTo((Stream)(object)val2);
								((Stream)val2).Position = 0L;
								return SKTypeface.FromStream((Stream)(object)val2, 0);
							}
							finally
							{
								((global::System.IDisposable)val2)?.Dispose();
							}
						}
					}
					finally
					{
						((global::System.IDisposable)val)?.Dispose();
					}
				}
			}
			catch (global::System.Exception ex)
			{
				Debug.WriteLine("[FontManager] Android assets failed for '" + fontFileName2 + "': " + ex.Message);
			}
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			string text = Enumerable.FirstOrDefault<string>((global::System.Collections.Generic.IEnumerable<string>)executingAssembly.GetManifestResourceNames(), (Func<string, bool>)((string r) => r.EndsWith(fontFileName2, (StringComparison)5)));
			if (!string.IsNullOrEmpty(text))
			{
				Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(text);
				try
				{
					if (manifestResourceStream != null)
					{
						Debug.WriteLine("[FontManager] ✓ Loaded '" + fontFileName2 + "' from embedded resources");
						return SKTypeface.FromStream(manifestResourceStream, 0);
					}
				}
				finally
				{
					((global::System.IDisposable)manifestResourceStream)?.Dispose();
				}
			}
			string[] array = new string[4];
			_003C_003Ey__InlineArray5<string> buffer = default(_003C_003Ey__InlineArray5<string>);
			_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 0) = FileSystem.AppDataDirectory;
			_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 1) = "..";
			_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 2) = "Resources";
			_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 3) = "Fonts";
			_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 4) = fontFileName2;
			array[0] = Path.Combine(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray5<string>, string>(in buffer, 5));
			array[1] = Path.Combine(FileSystem.AppDataDirectory, "Fonts", fontFileName2);
			array[2] = Path.Combine(AppContext.BaseDirectory, "Resources", "Fonts", fontFileName2);
			array[3] = Path.Combine(AppContext.BaseDirectory, "Fonts", fontFileName2);
			string[] array2 = array;
			string[] array3 = array2;
			foreach (string text2 in array3)
			{
				try
				{
					if (File.Exists(text2))
					{
						Debug.WriteLine("[FontManager] ✓ Loaded '" + fontFileName2 + "' from file system: " + text2);
						return SKTypeface.FromFile(text2, 0);
					}
				}
				catch
				{
				}
			}
			Debug.WriteLine("[FontManager] ✗ Failed to load '" + fontFileName2 + "' - font not found in any location");
		}
		catch (global::System.Exception ex2)
		{
			Debug.WriteLine("[FontManager] ✗ Exception loading '" + fontFileName2 + "': " + ex2.Message);
			Debug.WriteLine("[FontManager] Stack trace: " + ex2.StackTrace);
		}
		return null;
	}

	public static void ClearCache()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		Enumerator<string, SKTypeface> enumerator = _typefaceCache.Values.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				SKTypeface current = enumerator.Current;
				if (current != null)
				{
					((SKNativeObject)current).Dispose();
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator).Dispose();
		}
		_typefaceCache.Clear();
	}
}
