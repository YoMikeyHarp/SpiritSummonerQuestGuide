using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;

namespace SpiritSummoner.Presentation.ViewModels.Shared;

public class StarGlow : SKCanvasView
{
	public static readonly BindableProperty StarSizeProperty = BindableProperty.Create("StarSize", typeof(double), typeof(StarGlow), (object)54.0, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty PointsProperty = BindableProperty.Create("Points", typeof(int), typeof(StarGlow), (object)5, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty InnerRadiusRatioProperty = BindableProperty.Create("InnerRadiusRatio", typeof(double), typeof(StarGlow), (object)0.4, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty CenterColorProperty = BindableProperty.Create("CenterColor", typeof(Color), typeof(StarGlow), (object)Color.FromArgb("#EDF8EA"), (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty EdgeColorProperty = BindableProperty.Create("EdgeColor", typeof(Color), typeof(StarGlow), (object)Color.FromArgb("#1AEDF8EA"), (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty GlowColorProperty = BindableProperty.Create("GlowColor", typeof(Color), typeof(StarGlow), (object)Color.FromArgb("#EDF8EA"), (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty GlowRadiusProperty = BindableProperty.Create("GlowRadius", typeof(float), typeof(StarGlow), (object)5f, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty RotationAngleProperty = BindableProperty.Create("RotationAngle", typeof(double), typeof(StarGlow), (object)0.0, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public double StarSize
	{
		get
		{
			return (double)((BindableObject)this).GetValue(StarSizeProperty);
		}
		set
		{
			((BindableObject)this).SetValue(StarSizeProperty, (object)value);
		}
	}

	public int Points
	{
		get
		{
			return (int)((BindableObject)this).GetValue(PointsProperty);
		}
		set
		{
			((BindableObject)this).SetValue(PointsProperty, (object)value);
		}
	}

	public double InnerRadiusRatio
	{
		get
		{
			return (double)((BindableObject)this).GetValue(InnerRadiusRatioProperty);
		}
		set
		{
			((BindableObject)this).SetValue(InnerRadiusRatioProperty, (object)value);
		}
	}

	public Color CenterColor
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			return (Color)((BindableObject)this).GetValue(CenterColorProperty);
		}
		set
		{
			((BindableObject)this).SetValue(CenterColorProperty, (object)value);
		}
	}

	public Color EdgeColor
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			return (Color)((BindableObject)this).GetValue(EdgeColorProperty);
		}
		set
		{
			((BindableObject)this).SetValue(EdgeColorProperty, (object)value);
		}
	}

	public Color GlowColor
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			return (Color)((BindableObject)this).GetValue(GlowColorProperty);
		}
		set
		{
			((BindableObject)this).SetValue(GlowColorProperty, (object)value);
		}
	}

	public float GlowRadius
	{
		get
		{
			return (float)((BindableObject)this).GetValue(GlowRadiusProperty);
		}
		set
		{
			((BindableObject)this).SetValue(GlowRadiusProperty, (object)value);
		}
	}

	public double RotationAngle
	{
		get
		{
			return (double)((BindableObject)this).GetValue(RotationAngleProperty);
		}
		set
		{
			((BindableObject)this).SetValue(RotationAngleProperty, (object)value);
		}
	}

	private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
	{
		((SKCanvasView)(StarGlow)(object)bindable).InvalidateSurface();
	}

	protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		((SKCanvasView)this).OnPaintSurface(e);
		SKCanvas canvas = e.Surface.Canvas;
		canvas.Clear();
		SKImageInfo info = e.Info;
		int width = ((SKImageInfo)(ref info)).Width;
		info = e.Info;
		int height = ((SKImageInfo)(ref info)).Height;
		if (width <= 0 || height <= 0)
		{
			return;
		}
		float num = (float)width / 2f;
		float num2 = (float)height / 2f;
		float num3 = (float)(Math.Min(width, height) / 2) - GlowRadius - 2f;
		float num4 = num3;
		float innerRadius = num4 * (float)InnerRadiusRatio;
		SKPath val = CreateStarPath(num, num2, num4, innerRadius, Points, RotationAngle);
		try
		{
			if (GlowRadius > 0f)
			{
				SKPaint val2 = new SKPaint
				{
					Style = (SKPaintStyle)0,
					IsAntialias = true,
					MaskFilter = SKMaskFilter.CreateBlur((SKBlurStyle)0, GlowRadius)
				};
				try
				{
					SKShader val3 = SKShader.CreateRadialGradient(new SKPoint(num, num2), num4, (SKColor[])(object)new SKColor[2]
					{
						Extensions.ToSKColor(GlowColor),
						SKColors.Transparent
					}, new float[2] { 0f, 1f }, (SKShaderTileMode)0);
					try
					{
						val2.Shader = val3;
						canvas.DrawPath(val, val2);
					}
					finally
					{
						((global::System.IDisposable)val3)?.Dispose();
					}
				}
				finally
				{
					((global::System.IDisposable)val2)?.Dispose();
				}
			}
			SKPaint val4 = new SKPaint
			{
				Style = (SKPaintStyle)0,
				IsAntialias = true
			};
			try
			{
				SKShader val5 = SKShader.CreateRadialGradient(new SKPoint(num, num2), num4, (SKColor[])(object)new SKColor[2]
				{
					Extensions.ToSKColor(CenterColor),
					Extensions.ToSKColor(EdgeColor)
				}, new float[2] { 0f, 1f }, (SKShaderTileMode)0);
				try
				{
					val4.Shader = val5;
					canvas.DrawPath(val, val4);
				}
				finally
				{
					((global::System.IDisposable)val5)?.Dispose();
				}
			}
			finally
			{
				((global::System.IDisposable)val4)?.Dispose();
			}
		}
		finally
		{
			((global::System.IDisposable)val)?.Dispose();
		}
	}

	private SKPath CreateStarPath(float centerX, float centerY, float outerRadius, float innerRadius, int points, double rotationAngle)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		SKPath val = new SKPath();
		double num = Math.PI * 2.0 / (double)points;
		double num2 = -Math.PI / 2.0 + rotationAngle * Math.PI / 180.0;
		double num3 = num2;
		val.MoveTo(centerX + (float)((double)outerRadius * Math.Cos(num3)), centerY + (float)((double)outerRadius * Math.Sin(num3)));
		for (int i = 0; i < points; i++)
		{
			num3 = num2 + num * (double)i + num / 2.0;
			val.LineTo(centerX + (float)((double)innerRadius * Math.Cos(num3)), centerY + (float)((double)innerRadius * Math.Sin(num3)));
			num3 = num2 + num * (double)(i + 1);
			val.LineTo(centerX + (float)((double)outerRadius * Math.Cos(num3)), centerY + (float)((double)outerRadius * Math.Sin(num3)));
		}
		val.Close();
		return val;
	}

	protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		double num = StarSize + (double)(GlowRadius * 2f) + 4.0;
		return new SizeRequest(new Size(num, num));
	}
}
