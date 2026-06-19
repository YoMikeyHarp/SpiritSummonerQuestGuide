using System.Threading.Tasks;

namespace SpiritSummoner.Presentation.Services.Caching;

public interface IPresentationCacheInitializationService
{
	bool IsInitialized { get; }

	global::System.Threading.Tasks.Task InitializeAsync(bool showProgress = false);

	void InvalidateCache();
}
