using System;
using Microsoft.Maui.Controls;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.Services;

public interface IPageCacheService
{
	ContentView? GetMainPage(string route);

	BottomSheet? GetSheetPage(string key);

	T? GetMainVM<T>(string key) where T : class;

	T? GetDeepVM<T>(string key) where T : class;

	T? GetSheetVM<T>(string key) where T : class;

	void CacheMainPage(string route, Func<ContentView> factory);

	void CacheSheetPage(string key, Func<BottomSheet> factory);

	void CacheDeepVM<T>(string key, T viewModel) where T : class;

	void CacheMainVM<T>(string key, T viewModel) where T : class;

	void CacheSheetVM<T>(string key, T viewModel) where T : class;

	void EvictAll();

	void SweepIdleDeepVMs(TimeSpan maxIdle, string? activeRoute = null);
}
