using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using SpiritSummoner.Infrastructure.Cache;
using SpiritSummoner.Presentation.ViewModels.Battles;
using The49.Maui.BottomSheet;

namespace SpiritSummoner.Presentation.Navigation;

public interface INavigationService
{
	void StopNavigation();

	bool CanNavigate();

	global::System.Threading.Tasks.Task NavigateToAsync(string route);

	global::System.Threading.Tasks.Task GoBackAsync();

	global::System.Threading.Tasks.Task GoBackModalAsync();

	global::System.Threading.Tasks.Task NavigateToWithParametersAsync(string route, IDictionary<string, object> parameters);

	global::System.Threading.Tasks.Task ShowAlertAsync(string title, string message);

	global::System.Threading.Tasks.Task NavigateToBattleViewAsync(string route, BattleLaunchRequest request);

	global::System.Threading.Tasks.Task<bool> ShowConfirmationAsync(string title, string message, string yesText = "Yes", string noText = "No");

	global::System.Threading.Tasks.Task<TViewModel> GetSheetVM<TViewModel>(string cacheKey) where TViewModel : class;

	BottomSheet GetSheetPage<TView>(string cacheKey) where TView : BottomSheet;

	global::System.Threading.Tasks.Task<BottomSheet> GetFullSheet<TView, TViewModel>(string cacheKey) where TView : BottomSheet where TViewModel : class;

	global::System.Threading.Tasks.Task<object> NavigateToMainPageAsync<TView, TViewModel>(string route, string cacheKey, object id) where TView : ContentView where TViewModel : class, ILoadableViewModel;
}
