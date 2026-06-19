using System.Threading.Tasks;
using SpiritSummoner.Application.UseCases.Common;

namespace SpiritSummoner.Application.UseCases.Players;

public class DeclineFriendRequestUseCase : IUseCase<DeclineFriendRequestRequest, bool>
{
	public global::System.Threading.Tasks.Task<Result<bool>> ExecuteAsync(DeclineFriendRequestRequest request)
	{
		if (string.IsNullOrEmpty(request.NotificationId))
		{
			return global::System.Threading.Tasks.Task.FromResult<Result<bool>>(Result<bool>.FailureResult("Notification ID is required"));
		}
		return global::System.Threading.Tasks.Task.FromResult<Result<bool>>(Result<bool>.SuccessResult(data: true));
	}
}
