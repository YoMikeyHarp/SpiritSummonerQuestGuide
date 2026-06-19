using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Storage;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;

namespace SpiritSummoner.Presentation.ViewModels.Shared;

public class BlendModeImage : SKCanvasView
{
	[CompilerGenerated]
	private sealed class _003CLoadBitmap_003Ed__19 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public BlendModeImage _003C_003E4__this;

		private SKBitmap _003Cimage_003E5__1;

		private string _003CimagePath_003E5__2;

		private string[] _003Cpaths_003E5__3;

		private AssetManager _003CassetManager_003E5__4;

		private SKBitmap _003C_003Es__5;

		private string[] _003C_003Es__6;

		private int _003C_003Es__7;

		private string _003Cpath_003E5__8;

		private Stream _003Cstream_003E5__9;

		private global::System.Exception _003Cex_003E5__10;

		private TaskAwaiter<SKBitmap> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			try
			{
				if (num != 0 && string.IsNullOrEmpty(_003C_003E4__this.Source))
				{
					_003C_003E4__this._bitmap = null;
				}
				else
				{
					try
					{
						TaskAwaiter<SKBitmap> awaiter;
						if (num != 0)
						{
							awaiter = _003C_003E4__this.LoadImage(ImageSource.op_Implicit(_003C_003E4__this.Source)).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_003C_003E1__state = 0);
								_003C_003Eu__1 = awaiter;
								_003CLoadBitmap_003Ed__19 _003CLoadBitmap_003Ed__ = this;
								((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<SKBitmap>, _003CLoadBitmap_003Ed__19>(ref awaiter, ref _003CLoadBitmap_003Ed__);
								return;
							}
						}
						else
						{
							awaiter = _003C_003Eu__1;
							_003C_003Eu__1 = default(TaskAwaiter<SKBitmap>);
							num = (_003C_003E1__state = -1);
						}
						_003C_003Es__5 = awaiter.GetResult();
						_003Cimage_003E5__1 = _003C_003Es__5;
						_003C_003Es__5 = null;
						if (_003Cimage_003E5__1 != null)
						{
							_003C_003E4__this._bitmap = _003Cimage_003E5__1;
						}
						else
						{
							_003C_003Ey__InlineArray5<string> buffer = default(_003C_003Ey__InlineArray5<string>);
							_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 0) = FileSystem.AppDataDirectory;
							_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 1) = "..";
							_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 2) = "Resources";
							_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 3) = "Images";
							_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 4) = _003C_003E4__this.Source;
							_003CimagePath_003E5__2 = Path.Combine(_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray5<string>, string>(in buffer, 5));
							if (File.Exists(_003CimagePath_003E5__2))
							{
								_003C_003E4__this._bitmap = SKBitmap.Decode(_003CimagePath_003E5__2);
							}
							else
							{
								_003Cpaths_003E5__3 = new string[3]
								{
									Path.Combine(AppContext.BaseDirectory, "Resources", "Images", _003C_003E4__this.Source),
									Path.Combine(FileSystem.AppDataDirectory, _003C_003E4__this.Source),
									_003C_003E4__this.Source
								};
								_003C_003Es__6 = _003Cpaths_003E5__3;
								_003C_003Es__7 = 0;
								while (true)
								{
									if (_003C_003Es__7 < _003C_003Es__6.Length)
									{
										_003Cpath_003E5__8 = _003C_003Es__6[_003C_003Es__7];
										if (File.Exists(_003Cpath_003E5__8))
										{
											_003C_003E4__this._bitmap = SKBitmap.Decode(_003Cpath_003E5__8);
											break;
										}
										_003Cpath_003E5__8 = null;
										_003C_003Es__7++;
										continue;
									}
									_003C_003Es__6 = null;
									_003CassetManager_003E5__4 = Application.Context.Assets;
									_003Cstream_003E5__9 = _003CassetManager_003E5__4.Open(_003C_003E4__this.Source);
									try
									{
										_003C_003E4__this._bitmap = SKBitmap.Decode(_003Cstream_003E5__9);
									}
									finally
									{
										if (num < 0 && _003Cstream_003E5__9 != null)
										{
											((global::System.IDisposable)_003Cstream_003E5__9).Dispose();
										}
									}
									_003Cstream_003E5__9 = null;
									_003Cimage_003E5__1 = null;
									_003CimagePath_003E5__2 = null;
									_003Cpaths_003E5__3 = null;
									_003CassetManager_003E5__4 = null;
									break;
								}
							}
						}
					}
					catch (global::System.Exception ex)
					{
						_003Cex_003E5__10 = ex;
						Debug.WriteLine("Failed to load image '" + _003C_003E4__this.Source + "': " + _003Cex_003E5__10.Message);
						_003C_003E4__this._bitmap = null;
					}
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CLoadImage_003Ed__18 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<SKBitmap> _003C_003Et__builder;

		public ImageSource source;

		public BlendModeImage _003C_003E4__this;

		private FileImageSource _003CfileSource_003E5__1;

		private string _003CfileName_003E5__2;

		private Context _003Ccontext_003E5__3;

		private int _003CresourceId_003E5__4;

		private Stream _003Cstream_003E5__5;

		private SKBitmap _003Cbitmap_003E5__6;

		private global::System.Exception _003Cex_003E5__7;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			SKBitmap result;
			try
			{
				Console.WriteLine($"Trying to load image: {source}");
				try
				{
					ref FileImageSource reference = ref _003CfileSource_003E5__1;
					ImageSource obj = source;
					reference = (FileImageSource)(object)((obj is FileImageSource) ? obj : null);
					if (_003CfileSource_003E5__1 != null)
					{
						_003CfileName_003E5__2 = Path.GetFileNameWithoutExtension(_003CfileSource_003E5__1.File);
						_003Ccontext_003E5__3 = Application.Context;
						_003CresourceId_003E5__4 = _003Ccontext_003E5__3.Resources.GetIdentifier(_003CfileName_003E5__2, "drawable", _003Ccontext_003E5__3.PackageName);
						if (_003CresourceId_003E5__4 == 0)
						{
							Console.WriteLine("Android resource not found: " + _003CfileName_003E5__2);
							result = null;
						}
						else
						{
							_003Cstream_003E5__5 = _003Ccontext_003E5__3.Resources.OpenRawResource(_003CresourceId_003E5__4);
							try
							{
								_003Cbitmap_003E5__6 = SKBitmap.Decode(_003Cstream_003E5__5);
								Console.WriteLine((_003Cbitmap_003E5__6 != null) ? "Image loaded successfully." : "Failed to decode image.");
								result = _003Cbitmap_003E5__6;
							}
							finally
							{
								if (num < 0 && _003Cstream_003E5__5 != null)
								{
									((global::System.IDisposable)_003Cstream_003E5__5).Dispose();
								}
							}
						}
					}
					else
					{
						Console.WriteLine("Unsupported ImageSource type on Android");
						result = null;
					}
				}
				catch (global::System.Exception ex)
				{
					_003Cex_003E5__7 = ex;
					Console.WriteLine("Error loading image: " + _003Cex_003E5__7.Message);
					result = null;
				}
			}
			catch (global::System.Exception ex)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(ex);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	public static readonly BindableProperty SourceProperty = BindableProperty.Create("Source", typeof(string), typeof(BlendModeImage), (object)null, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty BlendModeProperty = BindableProperty.Create("BlendMode", typeof(SKBlendMode), typeof(BlendModeImage), (object)(SKBlendMode)24, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty OpacityValueProperty = BindableProperty.Create("OpacityValue", typeof(double), typeof(BlendModeImage), (object)1.0, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	public static readonly BindableProperty BlendBackgroundProperty = BindableProperty.Create("BlendBackground", typeof(Brush), typeof(BlendModeImage), (object)null, (BindingMode)2, (ValidateValueDelegate)null, new BindingPropertyChangedDelegate(OnPropertyChanged), (BindingPropertyChangingDelegate)null, (CoerceValueDelegate)null, (CreateDefaultValueDelegate)null);

	private SKBitmap? _bitmap;

	public string Source
	{
		get
		{
			return (string)((BindableObject)this).GetValue(SourceProperty);
		}
		set
		{
			((BindableObject)this).SetValue(SourceProperty, (object)value);
		}
	}

	public SKBlendMode BlendMode
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (SKBlendMode)((BindableObject)this).GetValue(BlendModeProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((BindableObject)this).SetValue(BlendModeProperty, (object)value);
		}
	}

	public double OpacityValue
	{
		get
		{
			return (double)((BindableObject)this).GetValue(OpacityValueProperty);
		}
		set
		{
			((BindableObject)this).SetValue(OpacityValueProperty, (object)value);
		}
	}

	public Brush BlendBackground
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			return (Brush)((BindableObject)this).GetValue(BlendBackgroundProperty);
		}
		set
		{
			((BindableObject)this).SetValue(BlendBackgroundProperty, (object)value);
		}
	}

	private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
	{
		BlendModeImage blendModeImage = (BlendModeImage)(object)bindable;
		if (((object)bindable).GetType().GetProperty("Source") != (PropertyInfo)null && oldValue?.ToString() != newValue?.ToString())
		{
			blendModeImage.LoadBitmap();
		}
		((SKCanvasView)blendModeImage).InvalidateSurface();
	}

	[AsyncStateMachine(typeof(_003CLoadImage_003Ed__18))]
	[DebuggerStepThrough]
	private async global::System.Threading.Tasks.Task<SKBitmap> LoadImage(ImageSource source)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Console.WriteLine($"Trying to load image: {source}");
		try
		{
			FileImageSource fileSource = (FileImageSource)(object)((source is FileImageSource) ? source : null);
			if (fileSource != null)
			{
				string fileName = Path.GetFileNameWithoutExtension(fileSource.File);
				Context context = Application.Context;
				int resourceId = context.Resources.GetIdentifier(fileName, "drawable", context.PackageName);
				if (resourceId == 0)
				{
					Console.WriteLine("Android resource not found: " + fileName);
					return null;
				}
				Stream stream = context.Resources.OpenRawResource(resourceId);
				try
				{
					SKBitmap bitmap = SKBitmap.Decode(stream);
					Console.WriteLine((bitmap != null) ? "Image loaded successfully." : "Failed to decode image.");
					return bitmap;
				}
				finally
				{
					((global::System.IDisposable)stream)?.Dispose();
				}
			}
			Console.WriteLine("Unsupported ImageSource type on Android");
			return null;
		}
		catch (global::System.Exception ex2)
		{
			global::System.Exception ex = ex2;
			Console.WriteLine("Error loading image: " + ex.Message);
			return null;
		}
	}

	[AsyncStateMachine(typeof(_003CLoadBitmap_003Ed__19))]
	[DebuggerStepThrough]
	private global::System.Threading.Tasks.Task LoadBitmap()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		_003CLoadBitmap_003Ed__19 _003CLoadBitmap_003Ed__ = new _003CLoadBitmap_003Ed__19();
		_003CLoadBitmap_003Ed__._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
		_003CLoadBitmap_003Ed__._003C_003E4__this = this;
		_003CLoadBitmap_003Ed__._003C_003E1__state = -1;
		((AsyncTaskMethodBuilder)(ref _003CLoadBitmap_003Ed__._003C_003Et__builder)).Start<_003CLoadBitmap_003Ed__19>(ref _003CLoadBitmap_003Ed__);
		return ((AsyncTaskMethodBuilder)(ref _003CLoadBitmap_003Ed__._003C_003Et__builder)).Task;
	}

	protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Expected O, but got Unknown
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
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
		if (BlendBackground != null)
		{
			SKPaint val = new SKPaint
			{
				Style = (SKPaintStyle)0,
				IsAntialias = true
			};
			try
			{
				Brush blendBackground = BlendBackground;
				SolidColorBrush val2 = (SolidColorBrush)(object)((blendBackground is SolidColorBrush) ? blendBackground : null);
				if (val2 != null)
				{
					val.Color = Extensions.ToSKColor(val2.Color);
				}
				else
				{
					Brush blendBackground2 = BlendBackground;
					LinearGradientBrush val3 = (LinearGradientBrush)(object)((blendBackground2 is LinearGradientBrush) ? blendBackground2 : null);
					Point val4;
					if (val3 != null)
					{
						val4 = val3.StartPoint;
						float num = (float)(((Point)(ref val4)).X * (double)width);
						val4 = val3.StartPoint;
						SKPoint val5 = default(SKPoint);
						((SKPoint)(ref val5))._002Ector(num, (float)(((Point)(ref val4)).Y * (double)height));
						val4 = val3.EndPoint;
						float num2 = (float)(((Point)(ref val4)).X * (double)width);
						val4 = val3.EndPoint;
						SKPoint val6 = default(SKPoint);
						((SKPoint)(ref val6))._002Ector(num2, (float)(((Point)(ref val4)).Y * (double)height));
						SKColor[] array = Enumerable.ToArray<SKColor>(Enumerable.Select<GradientStop, SKColor>((global::System.Collections.Generic.IEnumerable<GradientStop>)((GradientBrush)val3).GradientStops, (Func<GradientStop, SKColor>)((GradientStop gs) => Extensions.ToSKColor(gs.Color))));
						float[] array2 = Enumerable.ToArray<float>(Enumerable.Select<GradientStop, float>((global::System.Collections.Generic.IEnumerable<GradientStop>)((GradientBrush)val3).GradientStops, (Func<GradientStop, float>)((GradientStop gs) => gs.Offset)));
						SKShader val7 = SKShader.CreateLinearGradient(val5, val6, array, array2, (SKShaderTileMode)0);
						try
						{
							val.Shader = val7;
						}
						finally
						{
							((global::System.IDisposable)val7)?.Dispose();
						}
					}
					else
					{
						Brush blendBackground3 = BlendBackground;
						RadialGradientBrush val8 = (RadialGradientBrush)(object)((blendBackground3 is RadialGradientBrush) ? blendBackground3 : null);
						if (val8 != null)
						{
							val4 = val8.Center;
							float num3 = (float)(((Point)(ref val4)).X * (double)width);
							val4 = val8.Center;
							SKPoint val9 = default(SKPoint);
							((SKPoint)(ref val9))._002Ector(num3, (float)(((Point)(ref val4)).Y * (double)height));
							float num4 = (float)(val8.Radius * (double)Math.Max(width, height));
							SKColor[] array3 = Enumerable.ToArray<SKColor>(Enumerable.Select<GradientStop, SKColor>((global::System.Collections.Generic.IEnumerable<GradientStop>)((GradientBrush)val8).GradientStops, (Func<GradientStop, SKColor>)((GradientStop gs) => Extensions.ToSKColor(gs.Color))));
							float[] array4 = Enumerable.ToArray<float>(Enumerable.Select<GradientStop, float>((global::System.Collections.Generic.IEnumerable<GradientStop>)((GradientBrush)val8).GradientStops, (Func<GradientStop, float>)((GradientStop gs) => gs.Offset)));
							SKShader val10 = SKShader.CreateRadialGradient(val9, num4, array3, array4, (SKShaderTileMode)0);
							try
							{
								val.Shader = val10;
							}
							finally
							{
								((global::System.IDisposable)val10)?.Dispose();
							}
						}
					}
				}
				canvas.DrawRect(0f, 0f, (float)width, (float)height, val);
			}
			finally
			{
				((global::System.IDisposable)val)?.Dispose();
			}
		}
		if (_bitmap == null)
		{
			return;
		}
		SKPaint val11 = new SKPaint
		{
			BlendMode = BlendMode,
			Color = ((SKColor)(ref SKColors.White)).WithAlpha((byte)(OpacityValue * 255.0)),
			IsAntialias = true,
			FilterQuality = (SKFilterQuality)3
		};
		try
		{
			float num5 = (float)width / (float)_bitmap.Width;
			float num6 = (float)height / (float)_bitmap.Height;
			float num7 = Math.Max(num5, num6);
			float num8 = (float)_bitmap.Width * num7;
			float num9 = (float)_bitmap.Height * num7;
			float num10 = ((float)width - num8) / 2f;
			float num11 = ((float)height - num9) / 2f;
			SKRect val12 = new SKRect(num10, num11, num10 + num8, num11 + num9);
			canvas.DrawBitmap(_bitmap, val12, val11);
		}
		finally
		{
			((global::System.IDisposable)val11)?.Dispose();
		}
	}

	protected override void OnParentSet()
	{
		((NavigableElement)this).OnParentSet();
		if (((Element)this).Parent != null && _bitmap == null && !string.IsNullOrEmpty(Source))
		{
			LoadBitmap();
			((SKCanvasView)this).InvalidateSurface();
		}
	}
}
