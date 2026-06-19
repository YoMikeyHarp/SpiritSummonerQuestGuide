using System.Threading.Tasks;

namespace SpiritSummoner.Application.Interfaces;

public interface IPresenceService
{
	void Start();

	void Stop();

	global::System.Threading.Tasks.Task PingAsync();
}
