using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;

namespace SpiritSummoner.Presentation.ViewModels.Shared;

public class OutlinedLabel : SKCanvasView
{
	public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(OutlinedLabel), (object)string.Empty, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnTextPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty FontSizeProperty = BindableProperty.Create("FontSize", typeof(double), typeof(OutlinedLabel), (object)14.0, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnTextPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create("FontFamily", typeof(string), typeof(OutlinedLabel), (object)"Poppins", (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnTextPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty FontAttributesProperty = BindableProperty.Create("FontAttributes", typeof(FontAttributes), typeof(OutlinedLabel), (object)(FontAttributes)0, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnTextPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(Color), typeof(OutlinedLabel), (object)Colors.White, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty StrokeColorProperty = BindableProperty.Create("StrokeColor", typeof(Color), typeof(OutlinedLabel), (object)Colors.Transparent, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty StrokeWidthProperty = BindableProperty.Create("StrokeWidth", typeof(double), typeof(OutlinedLabel), (object)1.0, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty UseGradientProperty = BindableProperty.Create("UseGradient", typeof(bool), typeof(OutlinedLabel), (object)false, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty GradientStopsProperty = BindableProperty.Create("GradientStops", typeof(ObservableCollection<GradientStopOutline>), typeof(OutlinedLabel), (object)null, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty GradientAngleProperty = BindableProperty.Create("GradientAngle", typeof(double), typeof(OutlinedLabel), (object)0.0, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty HasShadowProperty = BindableProperty.Create("HasShadow", typeof(bool), typeof(OutlinedLabel), (object)false, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty ShadowColorProperty = BindableProperty.Create("ShadowColor", typeof(Color), typeof(OutlinedLabel), (object)Color.FromRgba(0.0, 0.0, 0.0, 0.25), (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty ShadowOffsetXProperty = BindableProperty.Create("ShadowOffsetX", typeof(double), typeof(OutlinedLabel), (object)0.0, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty ShadowOffsetYProperty = BindableProperty.Create("ShadowOffsetY", typeof(double), typeof(OutlinedLabel), (object)2.0, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty ShadowBlurProperty = BindableProperty.Create("ShadowBlur", typeof(double), typeof(OutlinedLabel), (object)2.0, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty ShadowSpreadProperty = BindableProperty.Create("ShadowSpread", typeof(double), typeof(OutlinedLabel), (object)0.0, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty HasInnerShadowProperty = BindableProperty.Create("HasInnerShadow", typeof(bool), typeof(OutlinedLabel), (object)false, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty InnerShadowColorProperty = BindableProperty.Create("InnerShadowColor", typeof(Color), typeof(OutlinedLabel), (object)Color.FromRgba(0.0, 0.0, 0.0, 0.25), (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty InnerShadowOffsetXProperty = BindableProperty.Create("InnerShadowOffsetX", typeof(double), typeof(OutlinedLabel), (object)0.0, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty InnerShadowOffsetYProperty = BindableProperty.Create("InnerShadowOffsetY", typeof(double), typeof(OutlinedLabel), (object)1.0, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty InnerShadowBlurProperty = BindableProperty.Create("InnerShadowBlur", typeof(double), typeof(OutlinedLabel), (object)2.0, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	private SKRect _textBounds;

	public string Text
	{
		get
		{
			return (string)((BindableObject)this).GetValue(TextProperty);
		}
		set
		{
			((BindableObject)this).SetValue(TextProperty, (object)value);
		}
	}

	public double FontSize
	{
		get
		{
			return (double)((BindableObject)this).GetValue(FontSizeProperty);
		}
		set
		{
			((BindableObject)this).SetValue(FontSizeProperty, (object)value);
		}
	}

	public string FontFamily
	{
		get
		{
			return (string)((BindableObject)this).GetValue(FontFamilyProperty);
		}
		set
		{
			((BindableObject)this).SetValue(FontFamilyProperty, (object)value);
		}
	}

	public FontAttributes FontAttributes
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (FontAttributes)((BindableObject)this).GetValue(FontAttributesProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((BindableObject)this).SetValue(FontAttributesProperty, (object)value);
		}
	}

	public Color TextColor
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			return (Color)((BindableObject)this).GetValue(TextColorProperty);
		}
		set
		{
			((BindableObject)this).SetValue(TextColorProperty, (object)value);
		}
	}

	public Color StrokeColor
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			return (Color)((BindableObject)this).GetValue(StrokeColorProperty);
		}
		set
		{
			((BindableObject)this).SetValue(StrokeColorProperty, (object)value);
		}
	}

	public double StrokeWidth
	{
		get
		{
			return (double)((BindableObject)this).GetValue(StrokeWidthProperty);
		}
		set
		{
			((BindableObject)this).SetValue(StrokeWidthProperty, (object)value);
		}
	}

	public bool UseGradient
	{
		get
		{
			return (bool)((BindableObject)this).GetValue(UseGradientProperty);
		}
		set
		{
			((BindableObject)this).SetValue(UseGradientProperty, (object)value);
		}
	}

	public ObservableCollection<GradientStopOutline> GradientStops
	{
		get
		{
			return (ObservableCollection<GradientStopOutline>)((BindableObject)this).GetValue(GradientStopsProperty);
		}
		set
		{
			((BindableObject)this).SetValue(GradientStopsProperty, (object)value);
		}
	}

	public double GradientAngle
	{
		get
		{
			return (double)((BindableObject)this).GetValue(GradientAngleProperty);
		}
		set
		{
			((BindableObject)this).SetValue(GradientAngleProperty, (object)value);
		}
	}

	public bool HasShadow
	{
		get
		{
			return (bool)((BindableObject)this).GetValue(HasShadowProperty);
		}
		set
		{
			((BindableObject)this).SetValue(HasShadowProperty, (object)value);
		}
	}

	public Color ShadowColor
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			return (Color)((BindableObject)this).GetValue(ShadowColorProperty);
		}
		set
		{
			((BindableObject)this).SetValue(ShadowColorProperty, (object)value);
		}
	}

	public double ShadowOffsetX
	{
		get
		{
			return (double)((BindableObject)this).GetValue(ShadowOffsetXProperty);
		}
		set
		{
			((BindableObject)this).SetValue(ShadowOffsetXProperty, (object)value);
		}
	}

	public double ShadowOffsetY
	{
		get
		{
			return (double)((BindableObject)this).GetValue(ShadowOffsetYProperty);
		}
		set
		{
			((BindableObject)this).SetValue(ShadowOffsetYProperty, (object)value);
		}
	}

	public double ShadowBlur
	{
		get
		{
			return (double)((BindableObject)this).GetValue(ShadowBlurProperty);
		}
		set
		{
			((BindableObject)this).SetValue(ShadowBlurProperty, (object)value);
		}
	}

	public double ShadowSpread
	{
		get
		{
			return (double)((BindableObject)this).GetValue(ShadowSpreadProperty);
		}
		set
		{
			((BindableObject)this).SetValue(ShadowSpreadProperty, (object)value);
		}
	}

	public bool HasInnerShadow
	{
		get
		{
			return (bool)((BindableObject)this).GetValue(HasInnerShadowProperty);
		}
		set
		{
			((BindableObject)this).SetValue(HasInnerShadowProperty, (object)value);
		}
	}

	public Color InnerShadowColor
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			return (Color)((BindableObject)this).GetValue(InnerShadowColorProperty);
		}
		set
		{
			((BindableObject)this).SetValue(InnerShadowColorProperty, (object)value);
		}
	}

	public double InnerShadowOffsetX
	{
		get
		{
			return (double)((BindableObject)this).GetValue(InnerShadowOffsetXProperty);
		}
		set
		{
			((BindableObject)this).SetValue(InnerShadowOffsetXProperty, (object)value);
		}
	}

	public double InnerShadowOffsetY
	{
		get
		{
			return (double)((BindableObject)this).GetValue(InnerShadowOffsetYProperty);
		}
		set
		{
			((BindableObject)this).SetValue(InnerShadowOffsetYProperty, (object)value);
		}
	}

	public double InnerShadowBlur
	{
		get
		{
			return (double)((BindableObject)this).GetValue(InnerShadowBlurProperty);
		}
		set
		{
			((BindableObject)this).SetValue(InnerShadowBlurProperty, (object)value);
		}
	}

	public OutlinedLabel()
	{
		GradientStops = new ObservableCollection<GradientStopOutline>();
	}

	private static void OnTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
	{
		OutlinedLabel outlinedLabel = (OutlinedLabel)(object)bindable;
		outlinedLabel.MeasureText();
		((SKCanvasView)outlinedLabel).InvalidateSurface();
	}

	private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
	{
		((SKCanvasView)(OutlinedLabel)(object)bindable).InvalidateSurface();
	}

	private void MeasureText()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(Text))
		{
			((VisualElement)this).WidthRequest = 0.0;
			((VisualElement)this).HeightRequest = 0.0;
			return;
		}
		SKPaint val = CreatePaint((SKPaintStyle)0);
		try
		{
			_textBounds = default(SKRect);
			val.MeasureText(Text, ref _textBounds);
			float num = (float)StrokeWidth * 2f;
			float num2 = 0f;
			if (HasShadow)
			{
				float num3 = (float)ShadowBlur * 2f;
				float num4 = (float)(Math.Abs(ShadowOffsetX) + Math.Abs(ShadowOffsetY));
				float num5 = (float)Math.Abs(ShadowSpread);
				num2 = Math.Max(num2, num3 + num4 + num5);
			}
			if (HasInnerShadow)
			{
				float num6 = (float)InnerShadowBlur * 2f;
				num2 = Math.Max(num2, num6);
			}
			float num7 = num + num2;
			((VisualElement)this).WidthRequest = ((SKRect)(ref _textBounds)).Width + num7;
			((VisualElement)this).HeightRequest = ((SKRect)(ref _textBounds)).Height + num7;
		}
		finally
		{
			((global::System.IDisposable)val)?.Dispose();
		}
	}

	private SKPaint CreatePaint(SKPaintStyle style)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		SKFontStyleWeight val = (SKFontStyleWeight)(((global::System.Enum)FontAttributes).HasFlag((global::System.Enum)(object)(FontAttributes)1) ? 700 : 400);
		SKFontStyleSlant val2 = (SKFontStyleSlant)(((global::System.Enum)FontAttributes).HasFlag((global::System.Enum)(object)(FontAttributes)2) ? 1 : 0);
		SKTypeface val3 = null;
		if (!string.IsNullOrEmpty(FontFamily))
		{
			val3 = FontManagerCustom.GetTypeface(FontFamily, val, val2);
		}
		if (val3 == null)
		{
			val3 = SKTypeface.FromFamilyName(FontFamily ?? "Arial", val, (SKFontStyleWidth)5, val2);
		}
		return new SKPaint
		{
			Style = style,
			IsAntialias = true,
			TextSize = (float)FontSize,
			Typeface = val3,
			TextAlign = (SKTextAlign)0
		};
	}

	private void DrawDropShadow(SKCanvas canvas, float scale, float x, float y)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		SKPaint val = CreatePaint((SKPaintStyle)0);
		try
		{
			val.Color = Extensions.ToSKColor(ShadowColor);
			val.TextSize *= scale;
			float num = (float)ShadowBlur * scale * 0.5f;
			if (num > 0f)
			{
				val.MaskFilter = SKMaskFilter.CreateBlur((SKBlurStyle)0, num);
			}
			if (ShadowSpread != 0.0)
			{
				float strokeWidth = (float)ShadowSpread * scale;
				val.StrokeWidth = strokeWidth;
				val.Style = (SKPaintStyle)2;
			}
			float num2 = x + (float)ShadowOffsetX * scale;
			float num3 = y + (float)ShadowOffsetY * scale;
			canvas.DrawText(Text, num2, num3, val);
		}
		finally
		{
			((global::System.IDisposable)val)?.Dispose();
		}
	}

	private void DrawInnerShadow(SKCanvas canvas, float scale, float x, float y)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		canvas.SaveLayer((SKPaint)null);
		SKPaint val = CreatePaint((SKPaintStyle)0);
		try
		{
			val.TextSize *= scale;
			val.Color = SKColors.Transparent;
			val.Style = (SKPaintStyle)0;
			canvas.DrawText(Text, x, y, val);
		}
		finally
		{
			((global::System.IDisposable)val)?.Dispose();
		}
		SKPaint val2 = CreatePaint((SKPaintStyle)0);
		try
		{
			val2.Color = Extensions.ToSKColor(InnerShadowColor);
			val2.TextSize *= scale;
			float num = (float)InnerShadowBlur * scale * 0.5f;
			if (num > 0f)
			{
				val2.MaskFilter = SKMaskFilter.CreateBlur((SKBlurStyle)0, num);
			}
			float num2 = x - (float)InnerShadowOffsetX * scale;
			float num3 = y - (float)InnerShadowOffsetY * scale;
			val2.BlendMode = (SKBlendMode)6;
			canvas.DrawText(Text, num2, num3, val2);
		}
		finally
		{
			((global::System.IDisposable)val2)?.Dispose();
		}
		canvas.Restore();
	}

	protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		((SKCanvasView)this).OnPaintSurface(e);
		SKCanvas canvas = e.Surface.Canvas;
		canvas.Clear();
		if (string.IsNullOrEmpty(Text))
		{
			return;
		}
		SKImageInfo info = e.Info;
		float num = (float)((SKImageInfo)(ref info)).Width / (float)((VisualElement)this).Width;
		info = e.Info;
		float num2 = ((float)((SKImageInfo)(ref info)).Width - ((SKRect)(ref _textBounds)).Width * num) / 2f - ((SKRect)(ref _textBounds)).Left * num;
		info = e.Info;
		float num3 = ((float)((SKImageInfo)(ref info)).Height - ((SKRect)(ref _textBounds)).Height * num) / 2f - ((SKRect)(ref _textBounds)).Top * num;
		if (HasShadow)
		{
			DrawDropShadow(canvas, num, num2, num3);
		}
		SKPaint val = CreatePaint((SKPaintStyle)1);
		try
		{
			val.Color = Extensions.ToSKColor(StrokeColor);
			val.StrokeWidth = (float)StrokeWidth * num;
			val.TextSize *= num;
			canvas.DrawText(Text, num2, num3, val);
			SKPaint val2 = CreatePaint((SKPaintStyle)0);
			try
			{
				val2.TextSize *= num;
				if (UseGradient && GradientStops != null && ((Collection<GradientStopOutline>)(object)GradientStops).Count > 0)
				{
					double num4 = GradientAngle * Math.PI / 180.0;
					float num5 = num2 + ((SKRect)(ref _textBounds)).Width * num / 2f;
					float num6 = num3 - ((SKRect)(ref _textBounds)).Height * num / 2f;
					float num7 = Math.Max(((SKRect)(ref _textBounds)).Width, ((SKRect)(ref _textBounds)).Height) * num;
					float num8 = num5 - (float)(Math.Cos(num4) * (double)num7 / 2.0);
					float num9 = num6 - (float)(Math.Sin(num4) * (double)num7 / 2.0);
					float num10 = num5 + (float)(Math.Cos(num4) * (double)num7 / 2.0);
					float num11 = num6 + (float)(Math.Sin(num4) * (double)num7 / 2.0);
					SKColor[] array = Enumerable.ToArray<SKColor>(Enumerable.Select<GradientStopOutline, SKColor>((global::System.Collections.Generic.IEnumerable<GradientStopOutline>)GradientStops, (Func<GradientStopOutline, SKColor>)((GradientStopOutline s) => Extensions.ToSKColor(s.Color))));
					float[] array2 = Enumerable.ToArray<float>(Enumerable.Select<GradientStopOutline, float>((global::System.Collections.Generic.IEnumerable<GradientStopOutline>)GradientStops, (Func<GradientStopOutline, float>)((GradientStopOutline s) => s.Offset)));
					SKShader val3 = SKShader.CreateLinearGradient(new SKPoint(num8, num9), new SKPoint(num10, num11), array, array2, (SKShaderTileMode)0);
					try
					{
						val2.Shader = val3;
					}
					finally
					{
						((global::System.IDisposable)val3)?.Dispose();
					}
				}
				else
				{
					val2.Color = Extensions.ToSKColor(TextColor);
				}
				canvas.DrawText(Text, num2, num3, val2);
				if (HasInnerShadow)
				{
					DrawInnerShadow(canvas, num, num2, num3);
				}
			}
			finally
			{
				((global::System.IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((global::System.IDisposable)val)?.Dispose();
		}
	}

	protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		MeasureText();
		return ((VisualElement)this).OnMeasure(widthConstraint, heightConstraint);
	}
}
