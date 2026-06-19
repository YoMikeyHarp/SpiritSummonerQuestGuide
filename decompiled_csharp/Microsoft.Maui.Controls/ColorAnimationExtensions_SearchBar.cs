using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core.Extensions;
using Microsoft.Maui.Graphics;

namespace Microsoft.Maui.Controls;

[GeneratedCode("CommunityToolkit.Maui.SourceGenerators.Generators.TextColorToGenerator", "1.0.0.0")]
[ExcludeFromCodeCoverage]
internal static class ColorAnimationExtensions_SearchBar
{
	public static global::System.Threading.Tasks.Task<bool> TextColorTo(this SearchBar element, Color color, uint rate = 16u, uint length = 250u, Easing? easing = null, CancellationToken token = default(CancellationToken))
	{
		//IL_011e: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		((CancellationToken)(ref token)).ThrowIfCancellationRequested();
		ArgumentNullException.ThrowIfNull((object)element, "element");
		ArgumentNullException.ThrowIfNull((object)color, "color");
		if (element == null)
		{
			throw new ArgumentException("Element must implement ITextStyle", "element");
		}
		if (((InputView)element).TextColor == null)
		{
			Color val = (((InputView)element).TextColor = Colors.Transparent);
		}
		TaskCompletionSource<bool> animationCompletionSource = new TaskCompletionSource<bool>();
		try
		{
			Animation val2 = new Animation();
			val2.Add(0.0, 1.0, GetRedTransformAnimation(element, color.Red));
			val2.Add(0.0, 1.0, GetGreenTransformAnimation(element, color.Green));
			val2.Add(0.0, 1.0, GetBlueTransformAnimation(element, color.Blue));
			val2.Add(0.0, 1.0, GetAlphaTransformAnimation(element, color.Alpha));
			val2.Commit((IAnimatable)(object)element, "TextColorTo", rate, length, easing, (Action<double, bool>)delegate
			{
				animationCompletionSource.SetResult(true);
			}, (Func<bool>)null);
		}
		catch (ArgumentException val3)
		{
			ArgumentException val4 = val3;
			Trace.WriteLine($"{((MemberInfo)((global::System.Exception)(object)val4).GetType()).Name} thrown in {typeof(ColorAnimationExtensions_SearchBar).FullName}: {((global::System.Exception)(object)val4).Message}");
			animationCompletionSource.SetResult(false);
		}
		return animationCompletionSource.Task.WaitAsync(token);
		[CompilerGenerated]
		static Animation GetAlphaTransformAnimation(SearchBar element, float targetAlpha)
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			SearchBar element2 = element;
			return new Animation((Action<double>)delegate(double v)
			{
				((InputView)element2).TextColor = ((InputView)element2).TextColor.WithAlpha((float)v);
			}, (double)((InputView)element2).TextColor.Alpha, (double)targetAlpha, (Easing)null, (Action)null);
		}
		[CompilerGenerated]
		static Animation GetBlueTransformAnimation(SearchBar element, float targetBlue)
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			SearchBar element3 = element;
			return new Animation((Action<double>)delegate(double v)
			{
				((InputView)element3).TextColor = ColorConversionExtensions.WithBlue(((InputView)element3).TextColor, v);
			}, (double)((InputView)element3).TextColor.Blue, (double)targetBlue, (Easing)null, (Action)null);
		}
		[CompilerGenerated]
		static Animation GetGreenTransformAnimation(SearchBar element, float targetGreen)
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			SearchBar element4 = element;
			return new Animation((Action<double>)delegate(double v)
			{
				((InputView)element4).TextColor = ColorConversionExtensions.WithGreen(((InputView)element4).TextColor, v);
			}, (double)((InputView)element4).TextColor.Green, (double)targetGreen, (Easing)null, (Action)null);
		}
		[CompilerGenerated]
		static Animation GetRedTransformAnimation(SearchBar element, float targetRed)
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			SearchBar element5 = element;
			return new Animation((Action<double>)delegate(double v)
			{
				((InputView)element5).TextColor = ColorConversionExtensions.WithRed(((InputView)element5).TextColor, v);
			}, (double)((InputView)element5).TextColor.Red, (double)targetRed, (Easing)null, (Action)null);
		}
	}
}
