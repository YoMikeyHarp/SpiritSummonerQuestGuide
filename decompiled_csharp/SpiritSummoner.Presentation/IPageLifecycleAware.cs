namespace SpiritSummoner.Presentation;

public interface IPageLifecycleAware
{
	void OnPageAppearing();

	void OnPageDisappearing();
}
