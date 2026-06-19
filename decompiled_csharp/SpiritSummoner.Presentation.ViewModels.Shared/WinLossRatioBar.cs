using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;

namespace SpiritSummoner.Presentation.ViewModels.Shared;

public class WinLossRatioBar : SKCanvasView
{
	public static readonly BindableProperty WinsProperty = BindableProperty.Create("Wins", typeof(int), typeof(WinLossRatioBar), (object)0, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnDataPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty LossesProperty = BindableProperty.Create("Losses", typeof(int), typeof(WinLossRatioBar), (object)0, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnDataPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty WinRatioProperty = BindableProperty.Create("WinRatio", typeof(double), typeof(WinLossRatioBar), (object)0.0, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty BarHeightProperty = BindableProperty.Create("BarHeight", typeof(double), typeof(WinLossRatioBar), (object)80.0, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty DiagonalAngleProperty = BindableProperty.Create("DiagonalAngle", typeof(double), typeof(WinLossRatioBar), (object)65.0, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create("CornerRadius", typeof(float), typeof(WinLossRatioBar), (object)8f, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create("BorderWidth", typeof(float), typeof(WinLossRatioBar), (object)1f, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty BorderColorProperty = BindableProperty.Create("BorderColor", typeof(Color), typeof(WinLossRatioBar), (object)Color.FromArgb("#EDF8EA"), (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public int Wins
	{
		get
		{
			return (int)((BindableObject)this).GetValue(WinsProperty);
		}
		set
		{
			((BindableObject)this).SetValue(WinsProperty, (object)value);
		}
	}

	public int Losses
	{
		get
		{
			return (int)((BindableObject)this).GetValue(LossesProperty);
		}
		set
		{
			((BindableObject)this).SetValue(LossesProperty, (object)value);
		}
	}

	public double WinRatio
	{
		get
		{
			return (double)((BindableObject)this).GetValue(WinRatioProperty);
		}
		set
		{
			((BindableObject)this).SetValue(WinRatioProperty, (object)value);
		}
	}

	public double BarHeight
	{
		get
		{
			return (double)((BindableObject)this).GetValue(BarHeightProperty);
		}
		set
		{
			((BindableObject)this).SetValue(BarHeightProperty, (object)value);
		}
	}

	public double DiagonalAngle
	{
		get
		{
			return (double)((BindableObject)this).GetValue(DiagonalAngleProperty);
		}
		set
		{
			((BindableObject)this).SetValue(DiagonalAngleProperty, (object)value);
		}
	}

	public float CornerRadius
	{
		get
		{
			return (float)((BindableObject)this).GetValue(CornerRadiusProperty);
		}
		set
		{
			((BindableObject)this).SetValue(CornerRadiusProperty, (object)value);
		}
	}

	public float BorderWidth
	{
		get
		{
			return (float)((BindableObject)this).GetValue(BorderWidthProperty);
		}
		set
		{
			((BindableObject)this).SetValue(BorderWidthProperty, (object)value);
		}
	}

	public Color BorderColor
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			return (Color)((BindableObject)this).GetValue(BorderColorProperty);
		}
		set
		{
			((BindableObject)this).SetValue(BorderColorProperty, (object)value);
		}
	}

	private static void OnDataPropertyChanged(BindableObject bindable, object oldValue, object newValue)
	{
		WinLossRatioBar winLossRatioBar = (WinLossRatioBar)(object)bindable;
		winLossRatioBar.UpdateWinRatio();
		((SKCanvasView)winLossRatioBar).InvalidateSurface();
	}

	private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
	{
		((SKCanvasView)(WinLossRatioBar)(object)bindable).InvalidateSurface();
	}

	private void UpdateWinRatio()
	{
		int num = Wins + Losses;
		if (num > 0)
		{
			WinRatio = (double)Wins / (double)num * 100.0;
		}
		else
		{
			WinRatio = 50.0;
		}
	}

	protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		((SKCanvasView)this).OnPaintSurface(e);
		SKCanvas canvas = e.Surface.Canvas;
		canvas.Clear();
		SKImageInfo info = e.Info;
		int width = ((SKImageInfo)(ref info)).Width;
		info = e.Info;
		int height = ((SKImageInfo)(ref info)).Height;
		if (width > 0 && height > 0)
		{
			int num = Wins + Losses;
			float proportion = ((num > 0) ? ((float)Wins / (float)num) : 0.5f);
			float proportion2 = ((num > 0) ? ((float)Losses / (float)num) : 0.5f);
			float centerX = (float)width / 2f;
			double num2 = DiagonalAngle * Math.PI / 180.0;
			float diagonalOffset = (float)((double)(height / 2) / Math.Tan(num2));
			DrawWinSection(canvas, width, height, proportion, centerX, diagonalOffset);
			DrawLossSection(canvas, width, height, proportion2, centerX, diagonalOffset);
		}
	}

	private void DrawWinSection(SKCanvas canvas, float width, float height, float proportion, float centerX, float diagonalOffset)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Expected O, but got Unknown
		SKShader val = SKShader.CreateLinearGradient(new SKPoint(0f, 0f), new SKPoint(0f, height), (SKColor[])(object)new SKColor[3]
		{
			SKColor.Parse("#78CB55"),
			SKColor.Parse("#9EDA84"),
			SKColor.Parse("#67C441")
		}, new float[3] { 0f, 0.5f, 1f }, (SKShaderTileMode)0);
		try
		{
			SKPaint val2 = new SKPaint
			{
				Shader = val,
				IsAntialias = true,
				Style = (SKPaintStyle)0
			};
			try
			{
				SKPath val3 = new SKPath();
				try
				{
					val3.MoveTo(CornerRadius, 0f);
					val3.LineTo(centerX - diagonalOffset, 0f);
					val3.LineTo(centerX + diagonalOffset, height);
					val3.LineTo(CornerRadius, height);
					val3.ArcTo(new SKRect(0f, height - CornerRadius * 2f, CornerRadius * 2f, height), 90f, 90f, false);
					val3.LineTo(0f, CornerRadius);
					val3.ArcTo(new SKRect(0f, 0f, CornerRadius * 2f, CornerRadius * 2f), 180f, 90f, false);
					val3.Close();
					canvas.DrawPath(val3, val2);
					SKPaint val4 = new SKPaint
					{
						Style = (SKPaintStyle)1,
						Color = Extensions.ToSKColor(BorderColor),
						StrokeWidth = BorderWidth,
						IsAntialias = true
					};
					try
					{
						canvas.DrawPath(val3, val4);
					}
					finally
					{
						((global::System.IDisposable)val4)?.Dispose();
					}
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
		finally
		{
			((global::System.IDisposable)val)?.Dispose();
		}
	}

	private void DrawLossSection(SKCanvas canvas, float width, float height, float proportion, float centerX, float diagonalOffset)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected O, but got Unknown
		SKShader val = SKShader.CreateLinearGradient(new SKPoint(0f, 0f), new SKPoint(0f, height), (SKColor[])(object)new SKColor[3]
		{
			SKColor.Parse("#CB5560"),
			SKColor.Parse("#DA848D"),
			SKColor.Parse("#CB5560")
		}, new float[3] { 0f, 0.5f, 1f }, (SKShaderTileMode)0);
		try
		{
			SKPaint val2 = new SKPaint
			{
				Shader = val,
				IsAntialias = true,
				Style = (SKPaintStyle)0
			};
			try
			{
				SKPath val3 = new SKPath();
				try
				{
					val3.MoveTo(centerX - diagonalOffset, 0f);
					val3.LineTo(width - CornerRadius, 0f);
					val3.ArcTo(new SKRect(width - CornerRadius * 2f, 0f, width, CornerRadius * 2f), 270f, 90f, false);
					val3.LineTo(width, height - CornerRadius);
					val3.ArcTo(new SKRect(width - CornerRadius * 2f, height - CornerRadius * 2f, width, height), 0f, 90f, false);
					val3.LineTo(centerX + diagonalOffset, height);
					val3.LineTo(centerX - diagonalOffset, 0f);
					val3.Close();
					canvas.DrawPath(val3, val2);
					SKPaint val4 = new SKPaint
					{
						Style = (SKPaintStyle)1,
						Color = Extensions.ToSKColor(BorderColor),
						StrokeWidth = BorderWidth,
						IsAntialias = true
					};
					try
					{
						canvas.DrawPath(val3, val4);
					}
					finally
					{
						((global::System.IDisposable)val4)?.Dispose();
					}
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
		finally
		{
			((global::System.IDisposable)val)?.Dispose();
		}
	}

	protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		double barHeight = BarHeight;
		return new SizeRequest(new Size(widthConstraint, barHeight));
	}
}
