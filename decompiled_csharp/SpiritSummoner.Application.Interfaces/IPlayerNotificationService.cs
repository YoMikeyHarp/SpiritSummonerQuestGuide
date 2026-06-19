using System.Collections.Generic;
using System.Threading.Tasks;
using SpiritSummoner.Domain.Enums.Common;

namespace SpiritSummoner.Application.Interfaces;

public interface IPlayerNotificationService
{
	global::System.Threading.Tasks.Task SendAsync(string targetPlayerId, NotificationType type, Dictionary<string, object> data);

	global::System.Threading.Tasks.Task SendToManyAsync(global::System.Collections.Generic.IEnumerable<string> targetPlayerIds, NotificationType type, Dictionary<string, object> data);
}
