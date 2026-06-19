using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SpiritSummoner.Presentation.ViewModels.Spirits;

namespace SpiritSummoner.Presentation.Controls.SpiritControls;

[XamlFilePath("Presentation\\Controls\\SpiritControls\\SpiritVerticalCardCollectionView.xaml")]
public class SpiritVerticalCardCollectionView : ContentView
{
	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private static EventHandler<SpiritVerticalCardCollectionView>? m_CardOverlayOpened;

	[CompilerGenerated]
	[DebuggerBrowsable(/*Could not decode attribute arguments.*/)]
	private static EventHandler? m_ResetAllCards;

	private CancellationTokenSource? _autoHideCts;

	private bool _longPressOccurred;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Grid DefaultContent;

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	private Border OptionsOverlay;

	private static event EventHandler<SpiritVerticalCardCollectionView>? CardOverlayOpened
	{
		[CompilerGenerated]
		add
		{
			EventHandler<SpiritVerticalCardCollectionView> val = SpiritVerticalCardCollectionView.m_CardOverlayOpened;
			EventHandler<SpiritVerticalCardCollectionView> val2;
			do
			{
				val2 = val;
				EventHandler<SpiritVerticalCardCollectionView> val3 = (EventHandler<SpiritVerticalCardCollectionView>)(object)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<SpiritVerticalCardCollectionView>>(ref SpiritVerticalCardCollectionView.m_CardOverlayOpened, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<SpiritVerticalCardCollectionView> val = SpiritVerticalCardCollectionView.m_CardOverlayOpened;
			EventHandler<SpiritVerticalCardCollectionView> val2;
			do
			{
				val2 = val;
				EventHandler<SpiritVerticalCardCollectionView> val3 = (EventHandler<SpiritVerticalCardCollectionView>)(object)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<SpiritVerticalCardCollectionView>>(ref SpiritVerticalCardCollectionView.m_CardOverlayOpened, val3, val2);
			}
			while (val != val2);
		}
	}

	private static event EventHandler ResetAllCards
	{
		[CompilerGenerated]
		add
		{
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Expected O, but got Unknown
			EventHandler val = SpiritVerticalCardCollectionView.m_ResetAllCards;
			EventHandler val2;
			do
			{
				val2 = val;
				EventHandler val3 = (EventHandler)global::System.Delegate.Combine((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler>(ref SpiritVerticalCardCollectionView.m_ResetAllCards, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Expected O, but got Unknown
			EventHandler val = SpiritVerticalCardCollectionView.m_ResetAllCards;
			EventHandler val2;
			do
			{
				val2 = val;
				EventHandler val3 = (EventHandler)global::System.Delegate.Remove((global::System.Delegate)(object)val2, (global::System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler>(ref SpiritVerticalCardCollectionView.m_ResetAllCards, val3, val2);
			}
			while (val != val2);
		}
	}

	public static void RequestResetAll()
	{
		EventHandler? resetAllCards = SpiritVerticalCardCollectionView.ResetAllCards;
		if (resetAllCards != null)
		{
			resetAllCards.Invoke((object)null, EventArgs.Empty);
		}
	}

	public SpiritVerticalCardCollectionView()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		InitializeComponent();
		((VisualElement)this).Loaded += new EventHandler(OnLoaded);
		((VisualElement)this).Unloaded += new EventHandler(OnUnloaded);
		ViewExtensions.ScaleTo((VisualElement)(object)this, 1.05, 100u, Easing.BounceOut);
	}

	public SpiritVerticalCardCollectionView(SpiritCardViewModel viewModel)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		InitializeComponent();
		((BindableObject)this).BindingContext = viewModel;
		((VisualElement)this).Loaded += new EventHandler(OnLoaded);
		((VisualElement)this).Unloaded += new EventHandler(OnUnloaded);
		ViewExtensions.ScaleTo((VisualElement)(object)this, 1.05, 100u, Easing.BounceOut);
	}

	private void OnLoaded(object? sender, EventArgs e)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		CardOverlayOpened += OnAnyCardOverlayOpened;
		ResetAllCards += new EventHandler(OnResetAllRequested);
	}

	private void OnUnloaded(object? sender, EventArgs e)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		CardOverlayOpened -= OnAnyCardOverlayOpened;
		ResetAllCards -= new EventHandler(OnResetAllRequested);
		CancellationTokenSource? autoHideCts = _autoHideCts;
		if (autoHideCts != null)
		{
			autoHideCts.Cancel();
		}
		CancellationTokenSource? autoHideCts2 = _autoHideCts;
		if (autoHideCts2 != null)
		{
			autoHideCts2.Dispose();
		}
		_autoHideCts = null;
	}

	private void OnAnyCardOverlayOpened(object? sender, SpiritVerticalCardCollectionView openedCard)
	{
		if (openedCard != this)
		{
			ResetToDefault();
		}
	}

	private void OnResetAllRequested(object? sender, EventArgs e)
	{
		ResetToDefault();
	}

	private void ResetToDefault()
	{
		CancellationTokenSource? autoHideCts = _autoHideCts;
		if (autoHideCts != null)
		{
			autoHideCts.Cancel();
		}
		((VisualElement)OptionsOverlay).IsVisible = false;
		((VisualElement)DefaultContent).IsVisible = true;
	}

	private void StartAutoHideTimer()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		CancellationTokenSource? autoHideCts = _autoHideCts;
		if (autoHideCts != null)
		{
			autoHideCts.Cancel();
		}
		_autoHideCts = new CancellationTokenSource();
		CancellationTokenSource autoHideCts2 = _autoHideCts;
		global::System.Threading.Tasks.Task.Delay(2500, autoHideCts2.Token).ContinueWith((Action<global::System.Threading.Tasks.Task>)([CompilerGenerated] (global::System.Threading.Tasks.Task t) =>
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Expected O, but got Unknown
			if (!t.IsCanceled)
			{
				MainThread.BeginInvokeOnMainThread(new Action(ResetToDefault));
			}
		}), TaskScheduler.Default);
	}

	private void OnCardTapped(object? sender, EventArgs e)
	{
		if (_longPressOccurred)
		{
			_longPressOccurred = false;
		}
		else if (((BindableObject)this).BindingContext is SpiritCardViewModel spiritCardViewModel)
		{
			IAsyncRelayCommand goToSpiritDetailsCommand = spiritCardViewModel.GoToSpiritDetailsCommand;
			if (goToSpiritDetailsCommand != null)
			{
				goToSpiritDetailsCommand.ExecuteAsync((object)null);
			}
		}
	}

	private void OnSellTapped(object? sender, EventArgs e)
	{
		if (_longPressOccurred)
		{
			_longPressOccurred = false;
			return;
		}
		if (((BindableObject)this).BindingContext is SpiritCardViewModel spiritCardViewModel)
		{
			spiritCardViewModel.SellSpiritCommand.ExecuteAsync((object)null);
		}
		ResetToDefault();
	}

	private void OnPartnerTapped(object? sender, EventArgs e)
	{
		if (_longPressOccurred)
		{
			_longPressOccurred = false;
			return;
		}
		if (((BindableObject)this).BindingContext is SpiritCardViewModel spiritCardViewModel)
		{
			spiritCardViewModel.SetAsPartnerCommand.ExecuteAsync((object)null);
		}
		ResetToDefault();
	}

	private void OnFavoriteTapped(object? sender, EventArgs e)
	{
		if (_longPressOccurred)
		{
			_longPressOccurred = false;
			return;
		}
		if (((BindableObject)this).BindingContext is SpiritCardViewModel spiritCardViewModel)
		{
			spiritCardViewModel.SetFavoriteCommand.ExecuteAsync((object)null);
		}
		ResetToDefault();
	}

	private void OnSquad1Tapped(object? sender, EventArgs e)
	{
		if (_longPressOccurred)
		{
			_longPressOccurred = false;
			return;
		}
		if (((BindableObject)this).BindingContext is SpiritCardViewModel spiritCardViewModel)
		{
			spiritCardViewModel.AddToSquadPositionCommand.ExecuteAsync("0");
		}
		ResetToDefault();
	}

	private void OnSquad2Tapped(object? sender, EventArgs e)
	{
		if (_longPressOccurred)
		{
			_longPressOccurred = false;
			return;
		}
		if (((BindableObject)this).BindingContext is SpiritCardViewModel spiritCardViewModel)
		{
			spiritCardViewModel.AddToSquadPositionCommand.ExecuteAsync("1");
		}
		ResetToDefault();
	}

	private void OnSquad3Tapped(object? sender, EventArgs e)
	{
		if (_longPressOccurred)
		{
			_longPressOccurred = false;
			return;
		}
		if (((BindableObject)this).BindingContext is SpiritCardViewModel spiritCardViewModel)
		{
			spiritCardViewModel.AddToSquadPositionCommand.ExecuteAsync("2");
		}
		ResetToDefault();
	}

	private void OnCardLongPressed(object? sender, LongPressCompletedEventArgs e)
	{
		_longPressOccurred = true;
		((VisualElement)OptionsOverlay).IsVisible = true;
		((VisualElement)DefaultContent).IsVisible = false;
		SpiritVerticalCardCollectionView.CardOverlayOpened?.Invoke((object)this, this);
		StartAutoHideTimer();
	}

	private void OnOptionsBackgroundTapped(object? sender, EventArgs e)
	{
	}

	private void OnOptionsLongPressed(object? sender, LongPressCompletedEventArgs e)
	{
		_longPressOccurred = true;
		ResetToDefault();
	}

	[GeneratedCode("Microsoft.Maui.Controls.SourceGen", "1.0.0.0")]
	[MemberNotNull("DefaultContent")]
	[MemberNotNull("OptionsOverlay")]
	private void InitializeComponent()
	{
		Extensions.LoadFromXaml<SpiritVerticalCardCollectionView>(this, typeof(SpiritVerticalCardCollectionView));
		DefaultContent = NameScopeExtensions.FindByName<Grid>((Element)(object)this, "DefaultContent");
		OptionsOverlay = NameScopeExtensions.FindByName<Border>((Element)(object)this, "OptionsOverlay");
	}
}
