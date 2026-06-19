using System.Threading.Tasks;

namespace SpiritSummoner.Infrastructure.Contracts;

public interface IAppVersionService
{
	global::System.Threading.Tasks.Task<bool> IsClientUpToDateAsync();
}
