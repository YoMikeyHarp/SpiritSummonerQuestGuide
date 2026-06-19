using System;
using System.Runtime.CompilerServices;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace SpiritSummoner.Presentation.Views.Animations;

public class BouncingImage : Image
{
	private Animation? _animation;

	public BouncingImage()
	{
		StartHoppingAnimation();
	}

	private void StartHoppingAnimation()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		Animation val = new Animation((Action<double>)([CompilerGenerated] (double t) =>
		{
			double translationX2 = Lerp(-10.0, 10.0, t);
			double translationY2 = -20.0 * t * (1.0 - t);
			((VisualElement)this).TranslationX = translationX2;
			((VisualElement)this).TranslationY = translationY2;
		}), 0.0, 1.0, Easing.SinInOut, (Action)null);
		Animation val2 = new Animation((Action<double>)([CompilerGenerated] (double t) =>
		{
			double translationX = Lerp(10.0, -10.0, t);
			double translationY = -20.0 * t * (1.0 - t);
			((VisualElement)this).TranslationX = translationX;
			((VisualElement)this).TranslationY = translationY;
		}), 0.0, 1.0, Easing.SinInOut, (Action)null);
		Animation val3 = new Animation();
		val3.Add(0.0, 0.5, val);
		val3.Add(0.5, 1.0, val2);
		_animation = val3;
		_animation.Commit((IAnimatable)(object)this, "HoppingAnimation", 16u, 2000u, (Easing)null, (Action<double, bool>)null, (Func<bool>)(() => true));
		[CompilerGenerated]
		static double Lerp(double from, double to, double t)
		{
			return from + (to - from) * t;
		}
	}
}
