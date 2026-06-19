using System.Threading.Tasks;
using SpiritSummoner.Application.DTOs.Session;

namespace SpiritSummoner.Infrastructure.Services;

public interface INotificationProcessorService
{
	global::System.Threading.Tasks.Task ProcessNotificationAsync(PlayerNotificationDTO notification);
}
