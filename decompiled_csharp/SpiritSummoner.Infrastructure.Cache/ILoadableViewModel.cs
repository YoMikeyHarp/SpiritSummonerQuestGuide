using System.Threading.Tasks;

namespace SpiritSummoner.Infrastructure.Cache;

public interface ILoadableViewModel
{
	global::System.Threading.Tasks.Task LoadDataAsync(object? parameter);
}
